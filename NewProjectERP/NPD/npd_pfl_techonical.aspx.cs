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
    public partial class npd_pfl_techonical : System.Web.UI.Page
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
                MachineNameList();
                Commom_GridLoad(sampleID);
                btnEdit.Visible = false;

              
            }

        }

        public void Commom_GridLoad(int SampleID)
        {
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
               // using (MySqlCommand cmd = new MySqlCommand("Load_gridnpd_pfl_techonical_pro", con))
                using (MySqlCommand cmd = new MySqlCommand("Load_gridnpd_pfl_techonical_pro1", con))
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

        public void MachineNameList()
        {
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            // string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("npd_Pfl_machineList_Proc"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    con.Open();
                    ddlMachineID.DataSource = cmd.ExecuteReader();
                    ddlMachineID.DataTextField = "MachineNo";
                    ddlMachineID.DataValueField = "MachineID";
                    ddlMachineID.DataBind();
                    con.Close();
                }
            }
            ddlMachineID.Items.Insert(0, new ListItem("--Select Machine No--", "0"));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            NPD_PFL_SPEC pfl=new NPD_PFL_SPEC();
            try
            {
                pfl.InsertUpdatepfl_techonical(0, Int32.Parse(ddlSampleID.SelectedValue), Decimal.Parse(txtOverallLength.Text), Decimal.Parse(txtOverallWidth.Text), Decimal.Parse(txtFinishedLength.Text), Decimal.Parse(txtFinishedWidth.Text), Int32.Parse(txtForntSideColor.Text), Int32.Parse(txtBackSideColor.Text), txtRibbonType.Text, Int32.Parse(txtRibbonColor.Text), Decimal.Parse(txtRibbonWidth.Text), Int32.Parse(txtEdgeQuality.Text), Int32.Parse(txtFaceQuality.Text), txtItemDescription.Text, Int32.Parse(ddlMachineID.SelectedValue), Int32.Parse(txtFirstHeatPlateTemp.Text), Int32.Parse(txtSecondHeatPlateTemp.Text), txtMachineSpeed.Text, txtFinishType.Text, txtFoldingType.Text, txtCuringTime.Text, txtCuiringTemparature.Text, txtItemAttributes.Text, txtKeyEntry1.Text,
                    txtKeyEntry2.Text, txtKeyEntry3.Text, txtKeyEntry4.Text, txtKeyEntry5.Text, txtKeyEntry6.Text, txtKeyEntry7.Text, txtKeyEntry8.Text, txtKeyEntry9.Text, txtKeyEntry10.Text, 68, Convert.ToDateTime(System.DateTime.Now), 0, 1);

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
            NPD_PFL_SPEC pfl = new NPD_PFL_SPEC();
            try
            {
                pfl.InsertUpdatepfl_techonical(Int32.Parse(Label1.Text), Int32.Parse(ddlSampleID.SelectedValue), Decimal.Parse(txtOverallLength.Text), Decimal.Parse(txtOverallWidth.Text), Decimal.Parse(txtFinishedLength.Text), Decimal.Parse(txtFinishedWidth.Text), Int32.Parse(txtForntSideColor.Text), Int32.Parse(txtBackSideColor.Text), txtRibbonType.Text, Int32.Parse(txtRibbonColor.Text), Decimal.Parse(txtRibbonWidth.Text), Int32.Parse(txtEdgeQuality.Text), Int32.Parse(txtFaceQuality.Text), txtItemDescription.Text, Int32.Parse(ddlMachineID.SelectedValue), Int32.Parse(txtFirstHeatPlateTemp.Text), Int32.Parse(txtSecondHeatPlateTemp.Text), txtMachineSpeed.Text, txtFinishType.Text, txtFoldingType.Text, txtCuringTime.Text, txtCuiringTemparature.Text, txtItemAttributes.Text, txtKeyEntry1.Text,
                    txtKeyEntry2.Text, txtKeyEntry3.Text, txtKeyEntry4.Text, txtKeyEntry5.Text, txtKeyEntry6.Text, txtKeyEntry7.Text, txtKeyEntry8.Text, txtKeyEntry9.Text, txtKeyEntry10.Text, 68, Convert.ToDateTime(System.DateTime.Now), 0, 2);

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
            Response.Redirect("/NPD/npd_pfl_techonical.aspx?");
        }
        private void showTechnicalData()
        {
            lblMsg.Text = "";
            btnEdit.Visible = true;
            btnDelete.Visible = false;
            btnSave.Visible = false;
            Label1.Text = gvDepartment.SelectedRow.Cells[1].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlSampleID.Text = gvDepartment.SelectedRow.Cells[2].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtOverallLength.Text = gvDepartment.SelectedRow.Cells[4].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtOverallWidth.Text = gvDepartment.SelectedRow.Cells[5].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtFinishedLength.Text = gvDepartment.SelectedRow.Cells[6].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtFinishedWidth.Text = gvDepartment.SelectedRow.Cells[7].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtForntSideColor.Text = gvDepartment.SelectedRow.Cells[8].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtBackSideColor.Text = gvDepartment.SelectedRow.Cells[9].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtRibbonType.Text = gvDepartment.SelectedRow.Cells[10].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtRibbonColor.Text = gvDepartment.SelectedRow.Cells[11].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtRibbonWidth.Text = gvDepartment.SelectedRow.Cells[12].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtEdgeQuality.Text = gvDepartment.SelectedRow.Cells[13].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtFaceQuality.Text = gvDepartment.SelectedRow.Cells[14].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtItemDescription.Text = gvDepartment.SelectedRow.Cells[15].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlMachineID.Text = gvDepartment.SelectedRow.Cells[16].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtFirstHeatPlateTemp.Text = gvDepartment.SelectedRow.Cells[18].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtSecondHeatPlateTemp.Text = gvDepartment.SelectedRow.Cells[19].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtMachineSpeed.Text = gvDepartment.SelectedRow.Cells[20].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtFinishType.Text = gvDepartment.SelectedRow.Cells[21].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtFoldingType.Text = gvDepartment.SelectedRow.Cells[22].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtCuringTime.Text = gvDepartment.SelectedRow.Cells[23].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtCuiringTemparature.Text = gvDepartment.SelectedRow.Cells[24].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtItemAttributes.Text = gvDepartment.SelectedRow.Cells[25].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry1.Text = gvDepartment.SelectedRow.Cells[26].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry2.Text = gvDepartment.SelectedRow.Cells[27].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry3.Text = gvDepartment.SelectedRow.Cells[28].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry4.Text = gvDepartment.SelectedRow.Cells[29].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry5.Text = gvDepartment.SelectedRow.Cells[30].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry6.Text = gvDepartment.SelectedRow.Cells[31].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry7.Text = gvDepartment.SelectedRow.Cells[32].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry8.Text = gvDepartment.SelectedRow.Cells[33].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry9.Text = gvDepartment.SelectedRow.Cells[34].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry10.Text = gvDepartment.SelectedRow.Cells[35].Text.Replace("amp;", "").Replace("&nbsp;", "");
        }
        protected void gvDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            btnEdit.Visible = true;
            btnDelete.Visible = false;
            btnSave.Visible = false;
            Label1.Text = gvDepartment.SelectedRow.Cells[1].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlSampleID.Text = gvDepartment.SelectedRow.Cells[2].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtOverallLength.Text = gvDepartment.SelectedRow.Cells[4].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtOverallWidth.Text = gvDepartment.SelectedRow.Cells[5].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtFinishedLength.Text = gvDepartment.SelectedRow.Cells[6].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtFinishedWidth.Text = gvDepartment.SelectedRow.Cells[7].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtForntSideColor.Text = gvDepartment.SelectedRow.Cells[8].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtBackSideColor.Text = gvDepartment.SelectedRow.Cells[9].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtRibbonType.Text = gvDepartment.SelectedRow.Cells[10].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtRibbonColor.Text = gvDepartment.SelectedRow.Cells[11].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtRibbonWidth.Text = gvDepartment.SelectedRow.Cells[12].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtEdgeQuality.Text = gvDepartment.SelectedRow.Cells[13].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtFaceQuality.Text = gvDepartment.SelectedRow.Cells[14].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtItemDescription.Text = gvDepartment.SelectedRow.Cells[15].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlMachineID.Text = gvDepartment.SelectedRow.Cells[16].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtFirstHeatPlateTemp.Text = gvDepartment.SelectedRow.Cells[18].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtSecondHeatPlateTemp.Text = gvDepartment.SelectedRow.Cells[19].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtMachineSpeed.Text = gvDepartment.SelectedRow.Cells[20].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtFinishType.Text = gvDepartment.SelectedRow.Cells[21].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtFoldingType.Text = gvDepartment.SelectedRow.Cells[22].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtCuringTime.Text = gvDepartment.SelectedRow.Cells[23].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtCuiringTemparature.Text = gvDepartment.SelectedRow.Cells[24].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtItemAttributes.Text = gvDepartment.SelectedRow.Cells[25].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry1.Text = gvDepartment.SelectedRow.Cells[26].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry2.Text = gvDepartment.SelectedRow.Cells[27].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry3.Text = gvDepartment.SelectedRow.Cells[28].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry4.Text = gvDepartment.SelectedRow.Cells[29].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry5.Text = gvDepartment.SelectedRow.Cells[30].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry6.Text = gvDepartment.SelectedRow.Cells[31].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry7.Text = gvDepartment.SelectedRow.Cells[32].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry8.Text = gvDepartment.SelectedRow.Cells[33].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry9.Text = gvDepartment.SelectedRow.Cells[34].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry10.Text = gvDepartment.SelectedRow.Cells[35].Text.Replace("amp;", "").Replace("&nbsp;", "");

        }

        protected void gvDepartment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > indexOfColumn)
            {
                e.Row.Cells[10].Visible = false;
                e.Row.Cells[12].Visible = false;
                e.Row.Cells[13].Visible = false;
                e.Row.Cells[14].Visible = false;
                e.Row.Cells[15].Visible = false;
                e.Row.Cells[16].Visible = false;
                e.Row.Cells[17].Visible = false;
             

            } 
        }

    }
}