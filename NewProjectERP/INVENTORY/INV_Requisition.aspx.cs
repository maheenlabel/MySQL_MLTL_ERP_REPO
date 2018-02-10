using MySql.Data.MySqlClient;
using NewProjectERP.DAC;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewProjectERP.DAC;
namespace NewProjectERP.INVENTORY
{
    public partial class INV_Requisition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int sampleID = 0;
                if (Request.QueryString["SampleID"] != null)
                {
                    sampleID = Int32.Parse(Request.QueryString["SampleID"]);
                }
                LoadRequisitionGrid(sampleID);
            }

        }
        //public SqlDataReader BindSupplier()
        //{
        //    Config_CommonDB cdb = new Config_CommonDB();
        //    return cdb.GetSupplier();
        //}

        private void LoadRequisitionGrid(int sampleID)
        {
           DataTable dt= DashBroadCommom_GridLoad(sampleID);

            gvPD_DashBoard.DataSource = dt;
            gvPD_DashBoard.DataBind();
        }
        public DataTable DashBroadCommom_GridLoad(int _SampleID)
        {
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("Load_Requisition_Gridview", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@_SampleID", _SampleID);
                   
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();                        
                        sda.Fill(dt);
                        return dt;
                       
                    }
                }
            }

        }
        //public DataTable GetAutoGenNo(string trantype)
        //{
        //    string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
        //    using (MySqlConnection con = new MySqlConnection(constr))
        //    {
        //        using (MySqlCommand cmd = new MySqlCommand("generatetranno", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@intrantype", trantype);

        //            using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
        //            {
        //                DataTable dt = new DataTable();
        //                sda.Fill(dt);
        //                return dt;

        //            }
        //        }
        //    }

        //}
        protected void gvPD_DashBoard_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Config_CommonDB cdb = new Config_CommonDB();
                DataTable dtSupplier = cdb.GetdtBySp("Load_SupplierList_proc");
                DropDownList ddlSupplier = (e.Row.FindControl("ddlSupplier") as DropDownList);
                ddlSupplier.DataSource = dtSupplier;
                ddlSupplier.DataTextField = "SupplierName";
                ddlSupplier.DataValueField = "SupplierID";
                ddlSupplier.DataBind();

                DataRow row = ((DataRowView)e.Row.DataItem).Row;
                //var lblSupplier = e.Row.FindControl("lblSupplier") as Label;
                //ddlSupplier.SelectedValue = lblSupplier.Text;
            }
        }

        protected void lblSampleQty_TextChanged(object sender, EventArgs e)
        {

            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
            //NamingContainer return the container that the control sits in
            Label Qty = (Label)row.FindControl("lblQty");

            TextBox rate = (TextBox)row.FindControl("lblSampleQty");
            Label amount = (Label)row.FindControl("lblAmount");
            //decimal vcutter = Decimal.Parse(txtCutter.Text);
            //if (vdenier.Text == "")
            //{
            //    Response.Write("<script>alert('Please Enter Denier');</script>");
            //    return;
            //}
            decimal requiredQty1 = 0;
            requiredQty1 =
           
            requiredQty1 = Convert.ToDecimal(Decimal.Parse(Qty.Text) *( Decimal.Parse(rate.Text))) ;
            amount.Text = requiredQty1.ToString();
            //TabName.Value = "Imaage_Sample";
        }

        public DataTable Retrun_MaxID()
        {
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("requisitionmaxID_pro", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                   
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        protected void btnGenerateRequisition_Click(object sender, EventArgs e)
        {
 
             //    Config_CommonDB cm = new DAC.Config_CommonDB();
             //string getTranNo=cm.ReturnTranTypeWise("inv_purchaserequitionmaster_tbl", "PurchaseRequitionID","Requisition");
                // string getTranNo = cm.ReturnTranTypeWise("com_userinfo_tbl", "UserID", "Requisition");


                 int Userids = 0;
                 int Result = 0;
                 int cSupID = 0;
                 int pSupID = 0;
                 int SampleID = 0;
                 int i = 0;
                 foreach (GridViewRow row in gvPD_DashBoard.Rows)
                 {
                     if (row.RowType == DataControlRowType.DataRow)
                     {
                         bool isChecked = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;

                         if (isChecked)
                         {
                             i++;
                         }
                     }
                 }
                 if (i > 0)
                 {

                     foreach (GridViewRow row in gvPD_DashBoard.Rows)
                     {
                         if (row.RowType == DataControlRowType.DataRow)
                         {
                             bool isChecked = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;
                             //int ID = Int32.Parse((row.FindControl("lblID") as Label).Text);
                             SampleID = Int32.Parse((row.FindControl("lblSampleID") as Label).Text);
                             // string SampleName = (row.FindControl("lblSampleName") as TextBox).Text;
                             int ItemID = Int32.Parse((row.FindControl("lblItemID") as Label).Text);
                             //  string ItemCode = (row.FindControl("lblItemCode") as Label).Text;
                             decimal Qty = Decimal.Parse((row.FindControl("lblQty") as Label).Text);
                             decimal SampleQty = Decimal.Parse((row.FindControl("lblSampleQty") as TextBox).Text);
                             decimal Amount = Decimal.Parse((row.FindControl("lblAmount") as Label).Text);
                             int Supplier = Int32.Parse((row.FindControl("ddlSupplier") as DropDownList).SelectedValue);
                             Userids = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
                             int Material_ID = Int32.Parse((row.FindControl("lblWoven_Material_ID") as Label).Text);

                             cSupID = Supplier;
                             if (cSupID !=pSupID)
                             {

                                 Config_CommonDB cm = new DAC.Config_CommonDB();
                                 string getTranNo = cm.ReturnTranTypeWise("inv_purchaserequitionmaster_tbl", "PurchaseRequitionID", "Requisition");


                                 if (isChecked)
                                 {
                                     try
                                     {
                                         string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
                                         using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(constr))
                                         {
                                             MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                                             cmd.Connection = conn;
                                             cmd.CommandText = "CALL InsertRequestion_masterDetails_pro(@_PurchaseRequitionNo,@_PurchaseRequitionDate,@_PreparedBy, @_Status, @_SupplierID, @_SampleID,@CommandID);";

                                             cmd.Parameters.Add("@_PurchaseRequitionNo", MySql.Data.MySqlClient.MySqlDbType.String).Value = getTranNo;
                                             cmd.Parameters.Add("@_PurchaseRequitionDate", MySql.Data.MySqlClient.MySqlDbType.Datetime).Value = System.DateTime.Now.Date;
                                             cmd.Parameters.Add("@_PreparedBy", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 61;
                                             cmd.Parameters.Add("@_Status", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 0;
                                             cmd.Parameters.Add("@_SupplierID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Supplier;
                                             cmd.Parameters.Add("@_SampleID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = SampleID;
                                             //cmd.Parameters.Add("@_ProductID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ItemID;
                                             //cmd.Parameters.Add("@_RequisitionQTY", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = Qty;
                                             //cmd.Parameters.Add("@_Rate", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = SampleQty;
                                             //cmd.Parameters.Add("@_Amount", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = Amount;
                                             cmd.Parameters.Add("@CommandID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 1;
                                             conn.Open();
                                             cmd.ExecuteNonQuery();
                                         }
                                         DataTable sa = Retrun_MaxID();

                                         using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(constr))
                                         {
                                             MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                                             cmd.Connection = conn;
                                             cmd.CommandText = "CALL InsertRequestion_Details_pro(@_PurchaseRequitionID,@_ProductID, @_RequisitionQTY, @_Rate, @_Status,@_PreparedBy,@_SupplierID,@_Amount,@CommandID);";

                                             //cmd.Parameters.Add("@_PurchaseRequitionNo", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = getTranNo;
                                             cmd.Parameters.Add("@_PurchaseRequitionID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = sa.Rows[0]["MasterlastID"].ToString();
                                             cmd.Parameters.Add("@_ProductID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ItemID;
                                             cmd.Parameters.Add("@_RequisitionQTY", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = Qty;
                                             cmd.Parameters.Add("@_Rate", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = SampleQty;
                                             cmd.Parameters.Add("@_Status", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 0;
                                             cmd.Parameters.Add("@_PreparedBy", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 61;
                                             cmd.Parameters.Add("@_SupplierID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Supplier;
                                             cmd.Parameters.Add("@_Amount", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = Amount;
                                             cmd.Parameters.Add("@CommandID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 2;
                                          
                                             conn.Open();
                                             cmd.ExecuteNonQuery();
                                         }

                                         using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(constr))
                                         {
                                             MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                                             cmd.Connection = conn;
                                             cmd.CommandText = "CALL material_requisition_status_Update_pro(@Material_ID);";
                                             cmd.Parameters.Add("@Material_ID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Material_ID;

                                             conn.Open();
                                             cmd.ExecuteNonQuery();
                                         
                                         }

                                     }
                                     catch (Exception ex)
                                     {
                                         lblMsg.Text = "Please Enter Correct Information";
                                         lblMsg.ForeColor = System.Drawing.Color.Red;
                                     }
                                 }
                             }
                             else
                             {
                                 if (isChecked)
                                 {
                                     try
                                     {
                                         DataTable sa = Retrun_MaxID();
                                         string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
                                         using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(constr))
                                         {

                                             MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                                             cmd.Connection = conn;
                                             cmd.CommandText = "CALL InsertRequestion_Details_pro(@_PurchaseRequitionID,@_ProductID, @_RequisitionQTY, @_Rate, @_Status,@_PreparedBy,@_SupplierID,@_Amount,@CommandID);";

                                             //cmd.Parameters.Add("@_PurchaseRequitionNo", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = getTranNo;
                                             cmd.Parameters.Add("@_PurchaseRequitionID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = sa.Rows[0]["MasterlastID"].ToString();
                                             cmd.Parameters.Add("@_ProductID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ItemID;
                                             cmd.Parameters.Add("@_RequisitionQTY", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = Qty;
                                             cmd.Parameters.Add("@_Rate", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = SampleQty;
                                             cmd.Parameters.Add("@_Status", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 0;
                                             cmd.Parameters.Add("@_PreparedBy", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 61;
                                             cmd.Parameters.Add("@_SupplierID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Supplier;
                                             cmd.Parameters.Add("@_Amount", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = Amount;
                                             cmd.Parameters.Add("@CommandID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 2;
                                             conn.Open();
                                             cmd.ExecuteNonQuery();
                                         }
                                         using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(constr))
                                         {
                                             MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                                             cmd.Connection = conn;
                                             cmd.CommandText = "CALL material_requisition_status_Update_pro(@Material_ID);";
                                             cmd.Parameters.Add("@Material_ID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Material_ID;

                                             conn.Open();
                                             cmd.ExecuteNonQuery();

                                         }

                                     }
                                     catch (Exception ex)
                                     {
                                         lblMsg.Text = "Please Enter Correct Information";
                                         lblMsg.ForeColor = System.Drawing.Color.Red;
                                     }
                                 }
                             }                             

                             pSupID = Supplier;

                             //Config_CommonDB cm = new DAC.Config_CommonDB();
                             //string getTranNo = cm.ReturnTranTypeWise("inv_purchaserequitionmaster_tbl", "PurchaseRequitionID", "Requisition");


                             //if (isChecked)
                             //{
                             //    try
                             //    {
                             //        string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
                             //        using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(constr))
                             //        {
                             //            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                             //            cmd.Connection = conn;
                             //            cmd.CommandText = "CALL InsertRequestion_masterDetails_pro(@_PurchaseRequitionNo,@_PurchaseRequitionDate,@_PreparedBy, @_Status, @_SupplierID, @_SampleID,@_ProductID,@_RequisitionQTY,@_Rate,@_Amount,@CommandID);";

                             //            cmd.Parameters.Add("@_PurchaseRequitionNo", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = getTranNo;
                             //            cmd.Parameters.Add("@_PurchaseRequitionDate", MySql.Data.MySqlClient.MySqlDbType.Datetime).Value = System.DateTime.Now.Date;
                             //            cmd.Parameters.Add("@_PreparedBy", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 61;
                             //            cmd.Parameters.Add("@_Status", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 0;
                             //            cmd.Parameters.Add("@_SupplierID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Supplier;
                             //            cmd.Parameters.Add("@_SampleID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = SampleID;
                             //            cmd.Parameters.Add("@_ProductID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ItemID;
                             //            cmd.Parameters.Add("@_RequisitionQTY", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = Qty;
                             //            cmd.Parameters.Add("@_Rate", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = SampleQty;
                             //            cmd.Parameters.Add("@_Amount", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = Amount;
                             //            cmd.Parameters.Add("@CommandID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 1;
                             //            conn.Open();
                             //            cmd.ExecuteNonQuery();
                             //        }

                             //    }
                             //    catch (Exception ex)
                             //    {
                             //        lblMsg.Text = "Please Enter Correct Information";
                             //        lblMsg.ForeColor = System.Drawing.Color.Red;
                             //    }
                             //}
                         }
                     }
                 }
                 else
                 {
                     lblMsg.Text = "Please Select Order Number!";
                     lblMsg.ForeColor = System.Drawing.Color.Red;
                     return;

                 }
                 lblMsg.Text = "Requisition Date Updated Successfully!";
                 lblMsg.ForeColor = System.Drawing.Color.Green;
                 Response.Redirect("INVENTORY/INV_RequisitionGenerate.aspx?SampleID=" + SampleID);
            //btnExit_Click(sender, e);
        }

        protected void btnSearchRequisition_Click(object sender, EventArgs e)
        {

        }
    }
}