using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewProjectERP.NPD
{
    public partial class PD_DashBorad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CategoryList();
                string CatagoryName = "";
                if (Request.QueryString["Cat"] != null)
                {
                    CatagoryName = (Request.QueryString["Cat"]);
                    ddlCategory.Text = CatagoryName;
                    LoadDashBroad(Int32.Parse(CatagoryName));
                }
                
            }
        }

        public void CategoryList()
        {
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            // string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT ProductCategoryID,ProductCategoryName FROM npd_productcategory_tbl"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    ddlCategory.DataSource = cmd.ExecuteReader();
                    ddlCategory.DataTextField = "ProductCategoryName";
                    ddlCategory.DataValueField = "ProductCategoryID";
                    ddlCategory.DataBind();
                    con.Close();
                }
            }
            ddlCategory.Items.Insert(0, new ListItem("--Select Product Category--", "0"));
        }

        protected void btnApproved_Click(object sender, EventArgs e)
        {
       
            int Userids = 0;
            int Result = 0;

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
                        int ID =Int32.Parse((row.FindControl("lblID") as Label).Text);
                        int SampleID = Int32.Parse((row.FindControl("lblSampleID") as Label).Text);
                        int SampleQty = Int32.Parse((row.FindControl("lblSampleQty") as TextBox).Text);
                        int Statusgr = Int32.Parse((row.FindControl("ddlStatusgr") as DropDownList).SelectedValue);

                        //string Pro_Job_Qty = (row.FindControl("lblPro_Job_Qty") as Label).Text;
                        //string Pro_Update_Plan_Id = (row.FindControl("lblPro_Update_Plan_Id") as Label).Text;
                        //FileUpload FileUpload = (row.FindControl("FileUpload1") as FileUpload);

                        //string StatusID = (row.FindControl("lblPro_De_Status") as Label).Text;

                        Userids = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
                        if (isChecked)
                        {
                            try
                            {
                    string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
                    using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(constr))
                    {
                        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "CALL updateCatagroyes_wise_Status_QtyUpdate(@_ID,@_Status,@_ApprovedBY, @_ApprovedDate, @_SampleQty, @_catagoryID);";

                        cmd.Parameters.Add("@_ID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ID;
                        cmd.Parameters.Add("@_Status", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Statusgr;
                        cmd.Parameters.Add("@_ApprovedBY", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 61;
                        cmd.Parameters.Add("@_ApprovedDate", MySql.Data.MySqlClient.MySqlDbType.Datetime).Value = System.DateTime.Now.Date;
                        cmd.Parameters.Add("@_SampleQty", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = SampleQty;
                        cmd.Parameters.Add("@_catagoryID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddlCategory.SelectedValue;
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
                }
            }
            else
            {
                lblMsg.Text = "Please Select Order Number!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;

            }
            lblMsg.Text = "Confirmation Date Updated Successfully!";
            lblMsg.ForeColor = System.Drawing.Color.Green;
            btnExit_Click(sender, e);

        }

        protected void btnReject_Click(object sender, EventArgs e)
        {

        }

        protected void btnExit_Click(object sender, EventArgs e)
        {

            Response.Redirect("/NPD/PD_DashBorad.aspx?");
       
        }

        protected void lblSpec_Click(object sender, EventArgs e)
        {

            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            //  Label JobCardID = (Label)gvRow.FindControl("lblJobCardID");
            //Label ID = (Label)gvRow.FindControl("lblID");
            Label SampleID = (Label)gvRow.FindControl("lblSampleName");

            if (Int32.Parse(ddlCategory.SelectedValue) == 1)
            {
                Response.Redirect("../NPD/NPD_Woven_Spec.aspx?ID=" + SampleID.Text);
            }
            else if (Int32.Parse(ddlCategory.SelectedValue) == 2)
            {
                Response.Redirect("../NPD/NPD_PFL_Spec.aspx?ID=" + SampleID.Text);
            }
            else if (Int32.Parse(ddlCategory.SelectedValue) == 5)
            {
                Response.Redirect("../NPD/NPD_Offset_Spec.aspx?ID=" + SampleID.Text);
            }
              
          
          
        }

        protected void lblMaterials_Click(object sender, EventArgs e)
        {

            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            //  Label JobCardID = (Label)gvRow.FindControl("lblJobCardID");
            //Label ID = (Label)gvRow.FindControl("lblID");
            Label SampleID = (Label)gvRow.FindControl("lblSampleID");

            if (Int32.Parse(ddlCategory.SelectedValue) == 1)
            {
                Response.Redirect("../NPD/Npd_Woven_Materials.aspx?SampleID=" + SampleID.Text);
            }
            else if (Int32.Parse(ddlCategory.SelectedValue) == 2)
            {
                Response.Redirect("../NPD/Npd_pfl_Materials.aspx?SampleID=" + SampleID.Text);
            }
            else if (Int32.Parse(ddlCategory.SelectedValue) == 5)
            {
                Response.Redirect("../NPD/Npd_Offset_Materials.aspx?SampleID=" + SampleID.Text);
            }

        }

        protected void lblTechnical_Click(object sender, EventArgs e)
        {

            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            //  Label JobCardID = (Label)gvRow.FindControl("lblJobCardID");
            //Label ID = (Label)gvRow.FindControl("lblID");
            Label SampleID = (Label)gvRow.FindControl("lblSampleID");

            if (Int32.Parse(ddlCategory.SelectedValue) == 1)
            {
                Response.Redirect("../NPD/npd_Woven_techonical.aspx?SampleID=" + SampleID.Text);
            }
            else if (Int32.Parse(ddlCategory.SelectedValue) == 2)
            {
                Response.Redirect("../NPD/npd_pfl_techonical.aspx?SampleID=" + SampleID.Text);
            }
            else if (Int32.Parse(ddlCategory.SelectedValue) == 5)
            {
                Response.Redirect("../NPD/npd_Offset_techonical.aspx?SampleID=" + SampleID.Text);
            }
        }

        protected void gvPD_DashBoard_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               
                DropDownList ddlStatusgr = (e.Row.FindControl("ddlStatusgr") as DropDownList);
                //ddlStatusgr.DataSource = dtStockType;
                //ddlStatusgr.DataTextField = "ListItem";
                //ddlStatusgr.DataValueField = "ID";
                //ddlStatusgr.DataBind();

                DataRow row = ((DataRowView)e.Row.DataItem).Row;
                var lblStockType = e.Row.FindControl("lblStatus") as Label;
                ddlStatusgr.SelectedValue = lblStockType.Text;


            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow row = e.Row as GridViewRow;
                string SampleQty = (row.FindControl("lblSampleQty") as TextBox).Text;
                if (SampleQty.ToString() == "") { (row.FindControl("lblSampleQty") as TextBox).Text = "1000"; }
            }


        }

        protected void Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Status = 0;
            if (ddlCategory.SelectedItem.Text == "Please Select")
            {
                Response.Write("<script>alert('Please Select Category Name');</script>");
                ddlCategory.Focus();
                return;
            }
            else if (ddlStatus.SelectedItem.Text != "Please Select")
            {
                Status = Int32.Parse(ddlStatus.SelectedValue);
            }
            DataTable dt = DashBroadCommom_GridLoad(Int32.Parse(ddlCategory.SelectedValue), Status);

            //else if (ddlStatus.SelectedItem.Text == "Please Select")
            //{
            //    Response.Write("<script>alert('Please Select Status');</script>");
            //    ddlStatus.Focus();
            //    return;
            //}
            //DataTable dt = DashBroadCommom_GridLoad(Int32.Parse(ddlCategory.SelectedValue), Int32.Parse(ddlStatus.SelectedValue));

       gvPD_DashBoard.DataSource = dt;
       gvPD_DashBoard.DataBind();

        }

        public DataTable DashBroadCommom_GridLoad(int _CategoryId, int _StatusID)
        {
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("pd_Woven_dashbroad_load_proc", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@_catagoryID", _CategoryId);
                    cmd.Parameters.AddWithValue("@_Status", _StatusID);
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
          
        }

        private void LoadDashBroad(int Cat)
        {
            int Status = 0;
            if (ddlCategory.SelectedItem.Text == "Please Select")
            {
                Response.Write("<script>alert('Please Select Category Name');</script>");
                ddlCategory.Focus();
                return;
            }

            else if (ddlStatus.SelectedItem.Text != "Please Select")
            {
                Status = Int32.Parse(ddlStatus.SelectedValue);
            }
            DataTable dt = DashBroadCommom_GridLoad(Cat, Status);

            gvPD_DashBoard.DataSource = dt;
            gvPD_DashBoard.DataBind();
        }
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            int Status = 0;
            if (ddlCategory.SelectedItem.Text == "Please Select")
            {
                Response.Write("<script>alert('Please Select Category Name');</script>");
                ddlCategory.Focus();
                return;
            }

            else if (ddlStatus.SelectedItem.Text != "Please Select")
            {
                Status = Int32.Parse(ddlStatus.SelectedValue);
            }
            DataTable dt = DashBroadCommom_GridLoad(Int32.Parse(ddlCategory.SelectedValue), Status);

            gvPD_DashBoard.DataSource = dt;
            gvPD_DashBoard.DataBind();
        }

        protected void lblSendRequisition_Click(object sender, EventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            //  Label JobCardID = (Label)gvRow.FindControl("lblJobCardID");
            //Label ID = (Label)gvRow.FindControl("lblID");
            Label SampleID = (Label)gvRow.FindControl("lblSampleID");

            if (Int32.Parse(ddlCategory.SelectedValue) == 1)
            {
                Response.Redirect("../INVENTORY/INV_Requisition.aspx?SampleID=" + SampleID.Text);
            }
            else if (Int32.Parse(ddlCategory.SelectedValue) == 2)
            {
                Response.Redirect("../INVENTORY/INV_Requisition.aspx?SampleID=" + SampleID.Text);
            }
            else if (Int32.Parse(ddlCategory.SelectedValue) == 5)
            {
                Response.Redirect("../INVENTORY/INV_Requisition.aspx?SampleID=" + SampleID.Text);
            }

        }
      
    }
}