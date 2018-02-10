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
    public partial class Npd_pfl_Materials : System.Web.UI.Page
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
                Commom_GridLoad(sampleID);
                btnEdit.Visible = false;
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            NPD_PFL_SPEC pfl = new NPD_PFL_SPEC();
            try
            {
                //string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
                //using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(constr))
                //{
                //    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                //    cmd.Connection = conn;
                //    cmd.CommandText = "CALL InsertUpdate_npd_pfl_materials_proc(@Pfl_Material_ID ,@SampleID ,@StoreItemID ,@Quanity,@Unit,@MahenCode ,@CreatedBy ,@CreationDate,@Status,@CommandID);";

                //    cmd.Parameters.Add("@Pfl_Material_ID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 0;
                //    cmd.Parameters.Add("@SampleID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddlSampleID.SelectedValue;
                //    cmd.Parameters.Add("@StoreItemID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddlStoreItemID.SelectedValue;


                //    cmd.Parameters.Add("@Quanity", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = txtQuanity.Text;
                //    cmd.Parameters.Add("@Unit", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddlUnit.SelectedValue;



                //    cmd.Parameters.Add("@MahenCode", MySql.Data.MySqlClient.MySqlDbType.String).Value = txtMahenCode.Text;
                //    cmd.Parameters.Add("@CreatedBy", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 68;



                //    cmd.Parameters.Add("@CreationDate", MySql.Data.MySqlClient.MySqlDbType.DateTime).Value = System.DateTime.Now.Date; 
                //    cmd.Parameters.Add("@Status", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 0;
                //    cmd.Parameters.Add("@CommandID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 1;



                //    conn.Open();
                //    cmd.ExecuteNonQuery();
                //}

                pfl.InsertUpdateMaterials(0, Int32.Parse(ddlSampleID.SelectedValue), Int32.Parse(ddlStoreItemID.SelectedValue), Decimal.Parse( txtQuanity.Text), Int32.Parse(ddlUnit.SelectedValue), txtMahenCode.Text, 68, Convert.ToDateTime(System.DateTime.Now), 0, 1);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            Commom_GridLoad(0);
            btnExit_Click(sender, e);

        }

        public void Commom_GridLoad( int SampleID)
        {
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                //using (MySqlCommand cmd = new MySqlCommand("Load_Gridview_Pfl_Material", con))
                using (MySqlCommand cmd = new MySqlCommand("Load_Gridview_Pfl_Material1", con))
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
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
           
                NPD_PFL_SPEC pfl = new NPD_PFL_SPEC();
                try
                {

                    pfl.InsertUpdateMaterials(Int32.Parse(Label1.Text), Int32.Parse(ddlSampleID.SelectedValue), Int32.Parse(ddlStoreItemID.SelectedValue), Decimal.Parse(txtQuanity.Text), Int32.Parse(ddlUnit.SelectedValue), txtMahenCode.Text, 68, Convert.ToDateTime(System.DateTime.Now), 0, 2);
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
            Response.Redirect("/NPD/Npd_pfl_Materials.aspx?");
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
            txtQuanity.Text = gvDepartment.SelectedRow.Cells[6].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlUnit.Text = gvDepartment.SelectedRow.Cells[7].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtMahenCode.Text = gvDepartment.SelectedRow.Cells[9].Text.Replace("amp;", "").Replace("&nbsp;", "");
            //txtBrandName.Focus();
        }

        protected void gvDepartment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > indexOfColumn)
            {
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].Visible = false;

       
            } 

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
            txtQuanity.Text = gvDepartment.SelectedRow.Cells[6].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlUnit.Text = gvDepartment.SelectedRow.Cells[7].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtMahenCode.Text = gvDepartment.SelectedRow.Cells[9].Text.Replace("amp;", "").Replace("&nbsp;", "");
            //txtBrandName.Focus();
        }
    }
}