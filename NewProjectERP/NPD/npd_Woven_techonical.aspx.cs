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
    public partial class npd_Woven_techonical : System.Web.UI.Page
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
                WarpColor();
                WeavingTypeList();
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

        public void WarpColor()
        {
            NPD_PFL_SPEC pfl = new NPD_PFL_SPEC();
            txtColor.DataSource = pfl.SearchCommonTbl("Color");
            txtColor.DataTextField = "ListItem";
            txtColor.DataValueField = "ID";
            txtColor.DataBind();
        }

        private void WeavingTypeList()
        {
            NPD_PFL_SPEC pfl = new NPD_PFL_SPEC();
            ddlWeavingType.DataSource = pfl.SearchCommonTbl("WovevingStyle");
            ddlWeavingType.DataTextField = "ListItem";
            ddlWeavingType.DataValueField = "ID";
            ddlWeavingType.DataBind();
        }

        public void Commom_GridLoad(int SampleID)
        {
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
               // using (MySqlCommand cmd = new MySqlCommand("Load_grid_Woven_Techonical_pro", con))
                using (MySqlCommand cmd = new MySqlCommand("Load_grid_Woven_Techonical_pro1", con))
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
            NPD_PFL_SPEC pfl=new NPD_PFL_SPEC();
            try
            {
                pfl.InsertUpdate_Woven_techonical(0, Int32.Parse(ddlSampleID.SelectedValue), Int32.Parse(txtColor.Text), Int32.Parse(ddlWeavingType.Text),
                    txtFileName.Text, Decimal.Parse(txtPick.Text), Decimal.Parse(txtCutter.Text), Decimal.Parse(txtLengthCuttoCut.Text), txtDamaskLengh.Text, txtFinishedlength.Text, Decimal.Parse(txtWidth.Text), Decimal.Parse(txtHuk.Text), Int32.Parse(ddlStracingInfo.SelectedValue),
                     Int32.Parse(ddlIronicInfo.SelectedValue), Int32.Parse(ddlUltrasonicCutting.SelectedValue),txtWash_Starch_Ironing_Time.Text, Decimal.Parse(txtPickWheel.Text), txtKeyEntry1.Text,
                  txtKeyEntry2.Text, txtKeyEntry3.Text, txtKeyEntry4.Text, txtKeyEntry5.Text, txtKeyEntry6.Text, txtKeyEntry7.Text, txtKeyEntry8.Text, txtKeyEntry9.Text, txtKeyEntry10.Text,0, 68, Convert.ToDateTime(System.DateTime.Now),1);
                btnExit_Click(sender, e);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

            Commom_GridLoad(0);
        }

        protected void gvDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            btnEdit.Visible = true;
            btnDelete.Visible = false;
            btnSave.Visible = false;
            Label1.Text = gvDepartment.SelectedRow.Cells[1].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlSampleID.Text = gvDepartment.SelectedRow.Cells[2].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtColor.Text = gvDepartment.SelectedRow.Cells[4].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlWeavingType.Text = gvDepartment.SelectedRow.Cells[6].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtFileName.Text = gvDepartment.SelectedRow.Cells[9].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtPick.Text = gvDepartment.SelectedRow.Cells[9].Text.Replace("amp;", "").Replace("&nbsp;", "");

            txtCutter.Text = gvDepartment.SelectedRow.Cells[10].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtLengthCuttoCut.Text = gvDepartment.SelectedRow.Cells[11].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtDamaskLengh.Text = gvDepartment.SelectedRow.Cells[12].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtFinishedlength.Text = gvDepartment.SelectedRow.Cells[13].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtWidth.Text = gvDepartment.SelectedRow.Cells[14].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtHuk.Text = gvDepartment.SelectedRow.Cells[15].Text.Replace("amp;", "").Replace("&nbsp;", "");

            ddlStracingInfo.Text = gvDepartment.SelectedRow.Cells[16].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlIronicInfo.Text = gvDepartment.SelectedRow.Cells[17].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlUltrasonicCutting.Text = gvDepartment.SelectedRow.Cells[18].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtWash_Starch_Ironing_Time.Text = gvDepartment.SelectedRow.Cells[19].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtPickWheel.Text = gvDepartment.SelectedRow.Cells[20].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry1.Text = gvDepartment.SelectedRow.Cells[21].Text.Replace("amp;", "").Replace("&nbsp;", "");

            txtKeyEntry2.Text = gvDepartment.SelectedRow.Cells[22].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry3.Text = gvDepartment.SelectedRow.Cells[23].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry4.Text = gvDepartment.SelectedRow.Cells[24].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry5.Text = gvDepartment.SelectedRow.Cells[25].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry6.Text = gvDepartment.SelectedRow.Cells[26].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry7.Text = gvDepartment.SelectedRow.Cells[27].Text.Replace("amp;", "").Replace("&nbsp;", "");

            txtKeyEntry8.Text = gvDepartment.SelectedRow.Cells[28].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry9.Text = gvDepartment.SelectedRow.Cells[29].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry10.Text = gvDepartment.SelectedRow.Cells[30].Text.Replace("amp;", "").Replace("&nbsp;", "");
          

        }


        private void showTechnicalData()
        {

            lblMsg.Text = "";
            btnEdit.Visible = true;
            btnDelete.Visible = false;
            btnSave.Visible = false;
            Label1.Text = gvDepartment.SelectedRow.Cells[1].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlSampleID.Text = gvDepartment.SelectedRow.Cells[2].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtColor.Text = gvDepartment.SelectedRow.Cells[4].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlWeavingType.Text = gvDepartment.SelectedRow.Cells[6].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtFileName.Text = gvDepartment.SelectedRow.Cells[9].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtPick.Text = gvDepartment.SelectedRow.Cells[9].Text.Replace("amp;", "").Replace("&nbsp;", "");

            txtCutter.Text = gvDepartment.SelectedRow.Cells[10].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtLengthCuttoCut.Text = gvDepartment.SelectedRow.Cells[11].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtDamaskLengh.Text = gvDepartment.SelectedRow.Cells[12].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtFinishedlength.Text = gvDepartment.SelectedRow.Cells[13].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtWidth.Text = gvDepartment.SelectedRow.Cells[14].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtHuk.Text = gvDepartment.SelectedRow.Cells[15].Text.Replace("amp;", "").Replace("&nbsp;", "");

            ddlStracingInfo.Text = gvDepartment.SelectedRow.Cells[16].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlIronicInfo.Text = gvDepartment.SelectedRow.Cells[17].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlUltrasonicCutting.Text = gvDepartment.SelectedRow.Cells[18].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtWash_Starch_Ironing_Time.Text = gvDepartment.SelectedRow.Cells[19].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtPickWheel.Text = gvDepartment.SelectedRow.Cells[20].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry1.Text = gvDepartment.SelectedRow.Cells[21].Text.Replace("amp;", "").Replace("&nbsp;", "");

            txtKeyEntry2.Text = gvDepartment.SelectedRow.Cells[22].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry3.Text = gvDepartment.SelectedRow.Cells[23].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry4.Text = gvDepartment.SelectedRow.Cells[24].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry5.Text = gvDepartment.SelectedRow.Cells[25].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry6.Text = gvDepartment.SelectedRow.Cells[26].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry7.Text = gvDepartment.SelectedRow.Cells[27].Text.Replace("amp;", "").Replace("&nbsp;", "");

            txtKeyEntry8.Text = gvDepartment.SelectedRow.Cells[28].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry9.Text = gvDepartment.SelectedRow.Cells[29].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry10.Text = gvDepartment.SelectedRow.Cells[30].Text.Replace("amp;", "").Replace("&nbsp;", "");
        }
        protected void btnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("/NPD/npd_Woven_techonical.aspx?");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

            NPD_PFL_SPEC pfl = new NPD_PFL_SPEC();
            try
            {
                pfl.InsertUpdate_Woven_techonical(Int32.Parse(Label1.Text), Int32.Parse(ddlSampleID.SelectedValue), Int32.Parse(txtColor.Text), Int32.Parse(ddlWeavingType.Text),
                    txtFileName.Text, Decimal.Parse(txtPick.Text), Decimal.Parse(txtCutter.Text), Decimal.Parse(txtLengthCuttoCut.Text), txtDamaskLengh.Text, txtFinishedlength.Text, Decimal.Parse(txtWidth.Text), Decimal.Parse(txtHuk.Text), Int32.Parse(ddlStracingInfo.SelectedValue),
                     Int32.Parse(ddlIronicInfo.SelectedValue), Int32.Parse(ddlUltrasonicCutting.SelectedValue), txtWash_Starch_Ironing_Time.Text, Decimal.Parse(txtPickWheel.Text), txtKeyEntry1.Text,
                  txtKeyEntry2.Text, txtKeyEntry3.Text, txtKeyEntry4.Text, txtKeyEntry5.Text, txtKeyEntry6.Text, txtKeyEntry7.Text, txtKeyEntry8.Text, txtKeyEntry9.Text, txtKeyEntry10.Text, 0, 68, Convert.ToDateTime(System.DateTime.Now), 2);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            Commom_GridLoad(0);
            btnExit_Click(sender, e);
        }

        protected void gvDepartment_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.Cells.Count > indexOfColumn)
            {
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[10].Visible = false;
                e.Row.Cells[12].Visible = false;
                e.Row.Cells[13].Visible = false;
                e.Row.Cells[14].Visible = false;
                e.Row.Cells[15].Visible = false;
                e.Row.Cells[16].Visible = false;
                e.Row.Cells[17].Visible = false;
                e.Row.Cells[18].Visible = false;
                e.Row.Cells[19].Visible = false;
                e.Row.Cells[20].Visible = false;
                e.Row.Cells[21].Visible = false;
                e.Row.Cells[22].Visible = false;

                e.Row.Cells[23].Visible = false;
                e.Row.Cells[24].Visible = false;
                e.Row.Cells[25].Visible = false;
                e.Row.Cells[26].Visible = false;
                e.Row.Cells[27].Visible = false;
                e.Row.Cells[28].Visible = false;
                e.Row.Cells[29].Visible = false;
            
            } 

        }
    }
}