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
using System.Globalization;
using System.Threading;

namespace NewProjectERP.NPD
{
    public partial class npd_Offset_techonical : System.Web.UI.Page
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
                MachineNameList();

                Commom_GridLoad(sampleID);
                btnEdit.Visible = false;

                //if (ddlLanguages.Items.FindByValue(CultureInfo.CurrentCulture.Name) != null)
                //{
                //    ddlLanguages.Items.FindByValue(CultureInfo.CurrentCulture.Name).Selected = true;
                //}
            }

        }
        protected override void InitializeCulture()
        {
            string language = Session["Lang"].ToString();
            //string language = "en-us";

            ////Detect User's Language.
            //if (Request.UserLanguages != null)
            //{
            //    //Set the Language.
            //    language = Request.UserLanguages[0];
            //}

            ////Check if PostBack is caused by Language DropDownList.
            //if (Request.Form["__EVENTTARGET"] != null && Request.Form["__EVENTTARGET"].Contains("ddlLanguages"))
            //{
            //    //Set the Language.
            //    language = Request.Form[Request.Form["__EVENTTARGET"]];
            //}

            ////Set the Culture.
            Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
        }

        public void Commom_GridLoad(int SampleID)
        {
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                //using (MySqlCommand cmd = new MySqlCommand("Load_grid_Offset_Technical", con))
                using (MySqlCommand cmd = new MySqlCommand("Load_grid_Offset_Technical1", con))
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
            //string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            //// string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            //using (MySqlConnection con = new MySqlConnection(constr))
            //{
            //    using (MySqlCommand cmd = new MySqlCommand("npd_Pfl_machineList_Proc"))
            //    {
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Connection = con;
            //        con.Open();
            //        ddlMachineID.DataSource = cmd.ExecuteReader();
            //        ddlMachineID.DataTextField = "MachineNo";
            //        ddlMachineID.DataValueField = "MachineID";
            //        ddlMachineID.DataBind();
            //        con.Close();
            //    }
            //}
            //ddlMachineID.Items.Insert(0, new ListItem("--Select Machine No--", "0"));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            NPD_Offset_SPEC pfl = new NPD_Offset_SPEC();

            int Cutting_Emboss = 0;
            int Cutting_Debossing = 0;
            int Die_Cutting = 0;
            int Punch_hole_size = 0;
            int Perforation = 0;

            if (ddlCuttingEmboss.SelectedItem.ToString() == "Yes")
            {
                Cutting_Emboss = 1;
            }

            if (ddlCuttingDebossing.SelectedItem.ToString() == "Yes")
            {
                Cutting_Debossing = 1;
            }

            if (ddlDieCutting.SelectedItem.ToString() == "Yes")
            {
                Die_Cutting = 1;
            }

            if (ddlPunch.SelectedItem.ToString() == "Yes")
            {
                Punch_hole_size = 1;
            }

            if (ddlPerforation.SelectedItem.ToString() == "Yes")
            {
                Perforation = 1;
            }

            try
            {
                pfl.InsertUpdateOffset_Technical(0, Int32.Parse(ddlSampleID.SelectedValue), Decimal.Parse(txtOverallLength.Text), Decimal.Parse(txtOverallWidth.Text), 
                    Decimal.Parse(txtFinishedLength.Text), Decimal.Parse(txtFinishedWidth.Text), Int32.Parse(txtForntSideColor.Text), Int32.Parse(txtBackSideColor.Text),
                    Cutting_Emboss, Cutting_Debossing, Die_Cutting, Punch_hole_size,
                    Perforation, txtKeyEntry1.Text, txtKeyEntry2.Text, txtKeyEntry3.Text, txtKeyEntry4.Text, txtKeyEntry5.Text, txtKeyEntry6.Text, 
                    txtKeyEntry7.Text, txtKeyEntry8.Text, txtKeyEntry9.Text, txtKeyEntry10.Text, 68, Convert.ToDateTime(System.DateTime.Now), 0, 1);

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

            int Cutting_Emboss = 0;
            int Cutting_Debossing = 0;
            int Die_Cutting = 0;
            int Punch_hole_size = 0;
            int Perforation = 0;

            if (ddlCuttingEmboss.SelectedItem.ToString() == "Yes")
            {
                Cutting_Emboss = 1;
            }

            if (ddlCuttingDebossing.SelectedItem.ToString() == "Yes")
            {
                Cutting_Debossing = 1;
            }

            if (ddlDieCutting.SelectedItem.ToString() == "Yes")
            {
                Die_Cutting = 1;
            }

            if (ddlPunch.SelectedItem.ToString() == "Yes")
            {
                Punch_hole_size = 1;
            }

            if (ddlPerforation.SelectedItem.ToString() == "Yes")
            {
                Perforation = 1;
            }

            try
            {
                pfl.InsertUpdateOffset_Technical(Int32.Parse(Label1.Text), Int32.Parse(ddlSampleID.SelectedValue), Decimal.Parse(txtOverallLength.Text), Decimal.Parse(txtOverallWidth.Text),
                    Decimal.Parse(txtFinishedLength.Text), Decimal.Parse(txtFinishedWidth.Text), Int32.Parse(txtForntSideColor.Text), Int32.Parse(txtBackSideColor.Text),
                    Cutting_Emboss, Cutting_Debossing, Die_Cutting, Punch_hole_size,
                    Perforation, txtKeyEntry1.Text, txtKeyEntry2.Text, txtKeyEntry3.Text, txtKeyEntry4.Text, txtKeyEntry5.Text, txtKeyEntry6.Text,
                    txtKeyEntry7.Text, txtKeyEntry8.Text, txtKeyEntry9.Text, txtKeyEntry10.Text, 68, Convert.ToDateTime(System.DateTime.Now), 0, 2);

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
            Response.Redirect("/NPD/npd_Offset_techonical.aspx?");
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
            ddlCuttingEmboss.Text = gvDepartment.SelectedRow.Cells[10].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlCuttingDebossing.Text = gvDepartment.SelectedRow.Cells[11].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlDieCutting.Text = gvDepartment.SelectedRow.Cells[12].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlPunch.Text = gvDepartment.SelectedRow.Cells[13].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlPerforation.Text = gvDepartment.SelectedRow.Cells[14].Text.Replace("amp;", "").Replace("&nbsp;", "");

            txtKeyEntry1.Text = gvDepartment.SelectedRow.Cells[15].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry2.Text = gvDepartment.SelectedRow.Cells[16].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry3.Text = gvDepartment.SelectedRow.Cells[17].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry4.Text = gvDepartment.SelectedRow.Cells[18].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry5.Text = gvDepartment.SelectedRow.Cells[19].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry6.Text = gvDepartment.SelectedRow.Cells[20].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry7.Text = gvDepartment.SelectedRow.Cells[21].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry8.Text = gvDepartment.SelectedRow.Cells[22].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry9.Text = gvDepartment.SelectedRow.Cells[23].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry10.Text = gvDepartment.SelectedRow.Cells[24].Text.Replace("amp;", "").Replace("&nbsp;", "");
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
            ddlCuttingEmboss.Text = gvDepartment.SelectedRow.Cells[10].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlCuttingDebossing.Text = gvDepartment.SelectedRow.Cells[11].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlDieCutting.Text = gvDepartment.SelectedRow.Cells[12].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlPunch.Text = gvDepartment.SelectedRow.Cells[13].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlPerforation.Text = gvDepartment.SelectedRow.Cells[14].Text.Replace("amp;", "").Replace("&nbsp;", "");
           
            txtKeyEntry1.Text = gvDepartment.SelectedRow.Cells[15].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry2.Text = gvDepartment.SelectedRow.Cells[16].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry3.Text = gvDepartment.SelectedRow.Cells[17].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry4.Text = gvDepartment.SelectedRow.Cells[18].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry5.Text = gvDepartment.SelectedRow.Cells[19].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry6.Text = gvDepartment.SelectedRow.Cells[20].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry7.Text = gvDepartment.SelectedRow.Cells[21].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry8.Text = gvDepartment.SelectedRow.Cells[22].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry9.Text = gvDepartment.SelectedRow.Cells[23].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtKeyEntry10.Text = gvDepartment.SelectedRow.Cells[24].Text.Replace("amp;", "").Replace("&nbsp;", "");

        }
    }
}