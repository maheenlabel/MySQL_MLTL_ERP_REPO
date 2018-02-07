using MySql.Data.MySqlClient;
using NewProjectERP.DAC;
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
    public partial class Npd_Woven_Materials : System.Web.UI.Page
    {

        int indexOfColumn = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int sampleID = 0;
                if (Request.QueryString["SampleID"] != null)
                {
                    sampleID = Int32.Parse(Request.QueryString["SampleID"]);
                }

                SampleNamelIST();
                UoM();
                StoreItem();
                SupplierList();
                Commom_GridLoad(sampleID);
                btnEdit.Visible = false;
            }


        }

        public void SampleNamelIST()
        {
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            // string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("Npd_Sample_List"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    con.Open();
                    ddlSampleID.DataSource = cmd.ExecuteReader();
                    ddlSampleID.DataTextField = "SampleName";
                    ddlSampleID.DataValueField = "SampleID";
                    ddlSampleID.DataBind();
                    con.Close();
                }
            }
            ddlSampleID.Items.Insert(0, new ListItem("--Select Sample Name--", "0"));
        }

        public void UoM()
        {
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            // string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("Load_Unit_of_measure_proc"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    con.Open();
                    ddlUnit.DataSource = cmd.ExecuteReader();
                    ddlUnit.DataTextField = "ListItem";
                    ddlUnit.DataValueField = "ID";
                    ddlUnit.DataBind();
                    con.Close();
                }
            }
            ddlUnit.Items.Insert(0, new ListItem("--Select Unit--", "0"));
        }
        public void StoreItem()
        {
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            // string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("ItemList_Proc"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    con.Open();
                    ddlStoreItemID.DataSource = cmd.ExecuteReader();
                    ddlStoreItemID.DataTextField = "ItemCode";
                    ddlStoreItemID.DataValueField = "ItemID";
                    ddlStoreItemID.DataBind();
                    con.Close();
                }
            }
            ddlStoreItemID.Items.Insert(0, new ListItem("--Select Item--", "0"));
        }

        public void SupplierList()
        {
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            // string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("Load_SupplierList_proc"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    con.Open();
                    ddlSupplerID.DataSource = cmd.ExecuteReader();
                    ddlSupplerID.DataTextField = "SupplierName";
                    ddlSupplerID.DataValueField = "SupplierID";
                    ddlSupplerID.DataBind();
                    con.Close();
                }
            }
            ddlSupplerID.Items.Insert(0, new ListItem("--Select Supplier Name--", "0"));
        }

        public void Commom_GridLoad(int SampleID)
        {
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
               // using (MySqlCommand cmd = new MySqlCommand("Load_grid_Woven_Material_proc", con))
                using (MySqlCommand cmd = new MySqlCommand("Load_grid_Woven_Material_proc1", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                       cmd.Parameters.AddWithValue("@sample", SampleID);
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        gvDepartment.DataSource = dt;
                        gvDepartment.DataBind();
                    }
                }
            }
            gvDepartment.SelectedIndex = 0;
            showTechnicalData();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            NPD_PFL_SPEC pfl = new NPD_PFL_SPEC();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
                using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(constr))
                {
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "CALL InsertUpdate_npd_woven_material_proc(@Woven_Material_ID, @SampleID, @StoreItemID, @MaheenCode, @Quanity, @Unit, @Color_Name, @Denier, @Pick_Yarnwise, @SuppilerID, @Batch_ID, @StatusID, @CreatedBy, @CreatedDate, @CommandID);";

                    cmd.Parameters.Add("@Woven_Material_ID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 0;
                    cmd.Parameters.Add("@SampleID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddlSampleID.SelectedValue;
                    cmd.Parameters.Add("@StoreItemID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddlStoreItemID.SelectedValue;
                    cmd.Parameters.Add("@MaheenCode", MySql.Data.MySqlClient.MySqlDbType.String).Value = txtMahenCode.Text;
                    cmd.Parameters.Add("@Quanity", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = txtQuanity.Text;
                    cmd.Parameters.Add("@Unit", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddlUnit.SelectedValue;
                    cmd.Parameters.Add("@Color_Name", MySql.Data.MySqlClient.MySqlDbType.String).Value = txtColorName.Text;
                    cmd.Parameters.Add("@Denier", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = txtDenier.Text;
                    cmd.Parameters.Add("@Pick_Yarnwise", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = txtPick_Yarnwise.Text;
                    cmd.Parameters.Add("@SuppilerID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddlSupplerID.SelectedValue;
                    cmd.Parameters.Add("@Batch_ID", MySql.Data.MySqlClient.MySqlDbType.String).Value = txtBatch.Text;
                    cmd.Parameters.Add("@StatusID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 0;
                    cmd.Parameters.Add("@CreatedBy", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 68;
                    cmd.Parameters.Add("@CreatedDate", MySql.Data.MySqlClient.MySqlDbType.DateTime).Value = System.DateTime.Now.Date;              
                    cmd.Parameters.Add("@CommandID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 1;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

              //  pfl.InsertUpdateMaterials(0, Int32.Parse(ddlSampleID.SelectedValue), Int32.Parse(ddlStoreItemID.SelectedValue), Decimal.Parse( txtQuanity.Text), Int32.Parse(ddlUnit.SelectedValue), txtMahenCode.Text, 68, Convert.ToDateTime(System.DateTime.Now), 0, 1);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            Commom_GridLoad(0);
            btnExit_Click(sender, e);
        }

        protected void gvDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            btnEdit.Visible = true;
            btnDelete.Visible = false;
            btnSave.Visible = false;
            Label1.Text = gvDepartment.SelectedRow.Cells[1].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlSampleID.Text = gvDepartment.SelectedRow.Cells[2].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlStoreItemID.Text = gvDepartment.SelectedRow.Cells[4].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtMahenCode.Text = gvDepartment.SelectedRow.Cells[6].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtQuanity.Text = gvDepartment.SelectedRow.Cells[7].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlUnit.Text = gvDepartment.SelectedRow.Cells[8].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtColorName.Text = gvDepartment.SelectedRow.Cells[10].Text.Replace("amp;", "").Replace("&nbsp;", "");

            txtDenier.Text = gvDepartment.SelectedRow.Cells[11].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtPick_Yarnwise.Text = gvDepartment.SelectedRow.Cells[12].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlSupplerID.Text = gvDepartment.SelectedRow.Cells[13].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtBatch.Text = gvDepartment.SelectedRow.Cells[15].Text.Replace("amp;", "").Replace("&nbsp;", "");


        }
        private void showTechnicalData()
        {
            lblMsg.Text = "";
            btnEdit.Visible = true;
            btnDelete.Visible = false;
            btnSave.Visible = false;
            Label1.Text = gvDepartment.SelectedRow.Cells[1].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlSampleID.Text = gvDepartment.SelectedRow.Cells[2].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlStoreItemID.Text = gvDepartment.SelectedRow.Cells[4].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtMahenCode.Text = gvDepartment.SelectedRow.Cells[6].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtQuanity.Text = gvDepartment.SelectedRow.Cells[7].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlUnit.Text = gvDepartment.SelectedRow.Cells[8].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtColorName.Text = gvDepartment.SelectedRow.Cells[10].Text.Replace("amp;", "").Replace("&nbsp;", "");

            txtDenier.Text = gvDepartment.SelectedRow.Cells[11].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtPick_Yarnwise.Text = gvDepartment.SelectedRow.Cells[12].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlSupplerID.Text = gvDepartment.SelectedRow.Cells[13].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtBatch.Text = gvDepartment.SelectedRow.Cells[15].Text.Replace("amp;", "").Replace("&nbsp;", "");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            NPD_PFL_SPEC pfl = new NPD_PFL_SPEC();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
                using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(constr))
                {
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "CALL InsertUpdate_npd_woven_material_proc(@Woven_Material_ID, @SampleID, @StoreItemID, @MaheenCode, @Quanity, @Unit, @Color_Name, @Denier, @Pick_Yarnwise, @SuppilerID, @Batch_ID, @StatusID, @CreatedBy, @CreatedDate, @CommandID);";

                    cmd.Parameters.Add("@Woven_Material_ID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Label1.Text;
                    cmd.Parameters.Add("@SampleID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddlSampleID.SelectedValue;
                    cmd.Parameters.Add("@StoreItemID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddlStoreItemID.SelectedValue;
                    cmd.Parameters.Add("@MaheenCode", MySql.Data.MySqlClient.MySqlDbType.String).Value = txtMahenCode.Text;
                    cmd.Parameters.Add("@Quanity", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = txtQuanity.Text;
                    cmd.Parameters.Add("@Unit", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddlUnit.SelectedValue;
                    cmd.Parameters.Add("@Color_Name", MySql.Data.MySqlClient.MySqlDbType.String).Value = txtColorName.Text;
                    cmd.Parameters.Add("@Denier", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = txtDenier.Text;
                    cmd.Parameters.Add("@Pick_Yarnwise", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = txtPick_Yarnwise.Text;
                    cmd.Parameters.Add("@SuppilerID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddlSupplerID.SelectedValue;
                    cmd.Parameters.Add("@Batch_ID", MySql.Data.MySqlClient.MySqlDbType.String).Value = txtBatch.Text;
                    cmd.Parameters.Add("@StatusID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 0;
                    cmd.Parameters.Add("@CreatedBy", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 68;
                    cmd.Parameters.Add("@CreatedDate", MySql.Data.MySqlClient.MySqlDbType.DateTime).Value = System.DateTime.Now.Date;
                    cmd.Parameters.Add("@CommandID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 2;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                //  pfl.InsertUpdateMaterials(0, Int32.Parse(ddlSampleID.SelectedValue), Int32.Parse(ddlStoreItemID.SelectedValue), Decimal.Parse( txtQuanity.Text), Int32.Parse(ddlUnit.SelectedValue), txtMahenCode.Text, 68, Convert.ToDateTime(System.DateTime.Now), 0, 1);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            Commom_GridLoad(0);
            btnExit_Click(sender, e);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("/NPD/Npd_Woven_Materials.aspx?");
        }

        protected void gvDepartment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > indexOfColumn)
            {
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].Visible = false;


            } 
        }

      
    }
}