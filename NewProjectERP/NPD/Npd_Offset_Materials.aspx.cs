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
    public partial class Npd_Offset_Materials : System.Web.UI.Page
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
                SampleNamelIST();
                UoM();
                StoreItem();
                SupplierList();
                OffsetBoardType();
                BatchList();
                Commom_GridLoad(sampleID);
                btnEdit.Visible = false;
            }


        }
        public void Commom_GridLoad(int SampleID)
        {
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                //using (MySqlCommand cmd = new MySqlCommand("Load_grid_Offset_Material_proc", con))
                using (MySqlCommand cmd = new MySqlCommand("Load_grid_Offset_Material_proc1", con))
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
        public void OffsetBoardType()
        {
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            // string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("LoadOffsetBoardType"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    con.Open();
                    ddlBoardType.DataSource = cmd.ExecuteReader();
                    ddlBoardType.DataTextField = "ListItem";
                    ddlBoardType.DataValueField = "ID";
                    ddlBoardType.DataBind();
                    con.Close();
                }
            }
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
        public void BatchList()
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
                    ddlBatch.DataSource = cmd.ExecuteReader();
                    ddlBatch.DataTextField = "ListItem";
                    ddlBatch.DataValueField = "ID";
                    ddlBatch.DataBind();
                    con.Close();
                }
            }
            ddlBatch.Items.Insert(0, new ListItem("--Select Batch--", "0"));
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
                    ddlSupplier.DataSource = cmd.ExecuteReader();
                    ddlSupplier.DataTextField = "SupplierName";
                    ddlSupplier.DataValueField = "SupplierID";
                    ddlSupplier.DataBind();
                    con.Close();
                }
            }
            ddlSupplier.Items.Insert(0, new ListItem("--Select Supplier--", "0"));
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            NPD_Offset_SPEC pfl = new NPD_Offset_SPEC();
            int BoardType = 0;
            int FSC = 0;
            int SupplierID = 0;
            int BatchID = 0;
            decimal BoardGSM = 0;

            if (ddlBoardType.SelectedItem.ToString() != "")
            {
                BoardType = Int32.Parse(ddlBoardType.SelectedValue);
            }

            if (ddlFSC.SelectedItem.ToString() == "Yes")
            {
                FSC = 1;
            }

            if (ddlSupplier.SelectedItem.ToString() != "")
            {
                SupplierID = Int32.Parse(ddlSupplier.SelectedValue);
            }

            if (ddlBatch.SelectedItem.ToString() != "")
            {
                BatchID = Int32.Parse(ddlBatch.SelectedValue);
            }

            if (txtBoardGSM.Text != "0")
            {
                BoardGSM = Decimal.Parse(txtBoardGSM.Text);
            }

            try
            {
                pfl.InsertUpdate_npd_Offset_materials(0, Int32.Parse(ddlSampleID.SelectedValue), BoardType, BoardGSM, FSC, txtBoardColor.Text, txtAthesiveColor.Text, Int32.Parse(ddlStoreItemID.SelectedValue), Decimal.Parse(txtQuanity.Text), Int32.Parse(ddlUnit.SelectedValue), txtMahenCode.Text, SupplierID, BatchID, 68, Convert.ToDateTime(System.DateTime.Now), 0, 1);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            Commom_GridLoad(0);
            btnExit_Click(sender, e);

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

            NPD_Offset_SPEC pfl = new NPD_Offset_SPEC();
            int BoardType = 0;
            int FSC = 0;
            int SupplierID = 0;
            int BatchID = 0;
            decimal BoardGSM = 0;

            if (ddlBoardType.SelectedItem.ToString() != "")
            {
                BoardType = Int32.Parse(ddlBoardType.SelectedValue);
            }

            if (ddlFSC.SelectedItem.ToString() == "Yes")
            {
                FSC = 1;
            }

            if (ddlSupplier.SelectedItem.ToString() != "")
            {
                SupplierID = Int32.Parse(ddlSupplier.SelectedValue);
            }

            if (ddlBatch.SelectedItem.ToString() != "")
            {
                BatchID = Int32.Parse(ddlBatch.SelectedValue);
            }

            if (txtBoardGSM.Text != "0")
            {
                BoardGSM = Decimal.Parse(txtBoardGSM.Text);
            }

            try
            {
                pfl.InsertUpdate_npd_Offset_materials(Int32.Parse(Label1.Text), Int32.Parse(ddlSampleID.SelectedValue), BoardType, BoardGSM, FSC, txtBoardColor.Text, txtAthesiveColor.Text, Int32.Parse(ddlStoreItemID.SelectedValue), Decimal.Parse(txtQuanity.Text), Int32.Parse(ddlUnit.SelectedValue), txtMahenCode.Text, SupplierID, BatchID, 68, Convert.ToDateTime(System.DateTime.Now), 0, 2);
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
            Response.Redirect("/NPD/Npd_Offset_Materials.aspx?");
        }
        private void showTechnicalData()
        {
            lblMsg.Text = "";
            btnEdit.Visible = true;
            btnDelete.Visible = false;
            btnSave.Visible = false;
            Label1.Text = gvDepartment.SelectedRow.Cells[1].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlSampleID.Text = gvDepartment.SelectedRow.Cells[2].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlBoardType.Text = gvDepartment.SelectedRow.Cells[4].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtBoardGSM.Text = gvDepartment.SelectedRow.Cells[6].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlFSC.Text = gvDepartment.SelectedRow.Cells[7].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtBoardColor.Text = gvDepartment.SelectedRow.Cells[8].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtAthesiveColor.Text = gvDepartment.SelectedRow.Cells[9].Text.Replace("amp;", "").Replace("&nbsp;", "");

            ddlStoreItemID.Text = gvDepartment.SelectedRow.Cells[10].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtQuanity.Text = gvDepartment.SelectedRow.Cells[12].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlUnit.Text = gvDepartment.SelectedRow.Cells[13].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtMahenCode.Text = gvDepartment.SelectedRow.Cells[15].Text.Replace("amp;", "").Replace("&nbsp;", "");

            ddlSupplier.Text = gvDepartment.SelectedRow.Cells[16].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlBatch.Text = gvDepartment.SelectedRow.Cells[18].Text.Replace("amp;", "").Replace("&nbsp;", "");


        }
        protected void gvDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            btnEdit.Visible = true;
            btnDelete.Visible = false;
            btnSave.Visible = false;
            Label1.Text = gvDepartment.SelectedRow.Cells[1].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlSampleID.Text = gvDepartment.SelectedRow.Cells[2].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlBoardType.Text = gvDepartment.SelectedRow.Cells[4].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtBoardGSM.Text = gvDepartment.SelectedRow.Cells[6].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlFSC.Text = gvDepartment.SelectedRow.Cells[7].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtBoardColor.Text = gvDepartment.SelectedRow.Cells[8].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtAthesiveColor.Text = gvDepartment.SelectedRow.Cells[9].Text.Replace("amp;", "").Replace("&nbsp;", "");

            ddlStoreItemID.Text = gvDepartment.SelectedRow.Cells[10].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtQuanity.Text = gvDepartment.SelectedRow.Cells[12].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlUnit.Text = gvDepartment.SelectedRow.Cells[13].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtMahenCode.Text = gvDepartment.SelectedRow.Cells[15].Text.Replace("amp;", "").Replace("&nbsp;", "");

            ddlSupplier.Text = gvDepartment.SelectedRow.Cells[16].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlBatch.Text = gvDepartment.SelectedRow.Cells[18].Text.Replace("amp;", "").Replace("&nbsp;", "");


        }
    }
}