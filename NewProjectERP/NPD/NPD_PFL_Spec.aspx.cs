using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Globalization;
using NewProjectERP.DAC;

namespace MLTL_ERP
{
    public partial class NPD_PFL_Spec : System.Web.UI.Page
    {
        int indexOfColumn = 1;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                string sampleID = "";
                if (Request.QueryString["ID"] != null)
                {
                    sampleID = (Request.QueryString["ID"]);
                }
                Commom_GridLoad(sampleID);

                Brand();
                ProductSubCategory();
                Client();
                Company();
                Executive();
                UoM();
            
                btnEdit.Visible = false;
             
               
            }

        }

        protected override void InitializeCulture()
        {
            string language = Session["Lang"].ToString();

            //Detect User's Language.
            //if (Session["Lang"].ToString() != null)
            //{
            //    //Set the Language.
            //    language = Session["Lang"].ToString();
            //}

            //Check if PostBack is caused by Language DropDownList.
            //if (Request.Form["__EVENTTARGET"] != null && Request.Form["__EVENTTARGET"].Contains(Session["Lang"].ToString()))
            //{
            //    //Set the Language.
            //    language = Request.Form[Request.Form["__EVENTTARGET"]];
            //}

            //Set the Culture.
            Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            //string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
            //string sRet = oInfo.Name;
            //CommonDB dbs = new CommonDB();
            //DataTable dt = dbs.COM_GetModuleIDByPageName(sRet);
            //Response.Redirect("/Default.aspx?ModuleID=" + dt.Rows[0][1].ToString());
        }

        public void Brand()
        {
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            // string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("Load_Brand_DropDownBox_proc"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    con.Open();
                    ddBrand.DataSource = cmd.ExecuteReader();
                    ddBrand.DataTextField = "BrandName";
                    ddBrand.DataValueField = "BrandID";
                    ddBrand.DataBind();
                    con.Close();
                }
            }
            ddBrand.Items.Insert(0, new ListItem("--Select Brand--", "0"));
        }

        protected void ddBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddBrand.SelectedItem.Text=="--Select Brand--")
            {  
                lblMsg.Text = "please Select Brand";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                return;
            }
            ProgramList(Convert.ToInt32(ddBrand.SelectedItem.Value.ToString()));

        }

        private void SubBrand()
        {

            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {

                using (MySqlCommand cmd = new MySqlCommand("SubBrand_in_DownBox_proc"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@bR_ID", BrandID);

                    cmd.Connection = con;
                    con.Open();
                    ddlProgram.DataSource = cmd.ExecuteReader();
                    ddlProgram.DataTextField = "ProgramName";
                    ddlProgram.DataValueField = "ProgramID";
                    ddlProgram.DataBind();
                    con.Close();
                }
            
            }
            ddlProgram.Items.Insert(0, new ListItem("--Select Sub Brand--", "0"));

        }
        private void ProgramList(int BrandID)
        {

            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {

                using (MySqlCommand cmd = new MySqlCommand("Load_Brand_WiseSubBrand_in_DownBox_proc"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@bR_ID", BrandID);

                    cmd.Connection = con;
                    con.Open();
                    ddlProgram.DataSource = cmd.ExecuteReader();
                    ddlProgram.DataTextField = "ProgramName";
                    ddlProgram.DataValueField = "ProgramID";
                    ddlProgram.DataBind();
                    con.Close();
                }
               
            }
            ddlProgram.Items.Insert(0, new ListItem("--Select Sub Brand--", "0"));

        }

        public void ProductSubCategory()
        {
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            // string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("Load_PFL_ProductSubCategory_PRO"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    con.Open();
                    ddSubCategory.DataSource = cmd.ExecuteReader();
                    ddSubCategory.DataTextField = "ProductSubCategoryName";
                    ddSubCategory.DataValueField = "ProductSubCategoryID";
                    ddSubCategory.DataBind();
                    con.Close();
                }
            }
            ddSubCategory.Items.Insert(0, new ListItem("--Select SubCategory--", "0"));
        }


        public void Client()
        {
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            // string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("Load_CustomerProfile_proc"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    con.Open();
                    ddClient.DataSource = cmd.ExecuteReader();
                    ddClient.DataTextField = "ClientName";
                    ddClient.DataValueField = "ClientID";
                    ddClient.DataBind();
                    con.Close();
                }
            }
            ddClient.Items.Insert(0, new ListItem("--Select Client--", "0"));
        }
        public void Company()
        {
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            // string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("Load_company_proc"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    con.Open();
                    ddlCompany.DataSource = cmd.ExecuteReader();
                    ddlCompany.DataTextField = "CompanyName";
                    ddlCompany.DataValueField = "CompanyID";
                    ddlCompany.DataBind();
                    con.Close();
                }
            }
            ddlCompany.Items.Insert(0, new ListItem("--Select Company--", "0"));
        }

        public DataTable Retrun_SampleID( string SampleName)
        {

            
            
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("Retrun_SampleID_proc", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                      cmd.Parameters.AddWithValue("@NewCustomerSampleName", SampleName);
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {

                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        public void Commom_GridLoad(string SampleID)
        {
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("lOAD_Grid_PFL_spec_proc", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@samplesname", SampleID);
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

            showSpecdata();
        }
        public void Executive()
        {
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            // string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("Load_EmployeeList_pro"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    con.Open();
                    ddPDExecutive.DataSource = cmd.ExecuteReader();
                    ddPDExecutive.DataTextField = "FirstName";
                    ddPDExecutive.DataValueField = "Emp_ID";
                    ddPDExecutive.DataBind();
                    con.Close();
                }
            }
            ddPDExecutive.Items.Insert(0, new ListItem("--Select PD Executive--", "0"));
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                NPD_PFL_SPEC DB = new NPD_PFL_SPEC();
                DataTable DuplicateDate1 = DB.DuplicateSampleName((txtSampleName.Text.Trim()));
                if (DuplicateDate1.Rows[0][0].ToString() == "1")
                {
                    Response.Write("<script>alert('This " + txtSampleName.Text + " Duplicate ');</script>");
                    return;
                }
                // (string inSampleName, int inBrandID, int inProgramID, decimal inLength, decimal inWidth, int inQuotedPrice)
                DataTable DuplicateDate = DB.DuplicateDateTable(Int32.Parse(ddBrand.SelectedValue), Int32.Parse(ddlProgram.SelectedValue), Decimal.Parse(txtLenghtmm.Text.Trim()), Decimal.Parse(txtwidthmm.Text.Trim()), Int32.Parse(txtQuotedPrice.Text.Trim()), txtImagepath.Text.Trim());

                if (DuplicateDate.Rows[0][0].ToString() == "1")
                {
                    Response.Write("<script>alert('Some Data All ready Sample create ');</script>");
                    return;
                }

               

                string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
                using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(constr))
                {
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "CALL InsertUpdatePFL_GeneralSpce_spec(@GSampleID,@SampleNo,@SampleName,@CustomerSampleName, @BrandID, @ProgramID, @ProductCategoryID,@ProductSubCategoryID, @ClientID, @CompanyID, @NPDExecutive, @Unit, @Length, @Width, @QuotedPrice, @ArtworkLocation_FileName, @Imagepath, @Cancel, @CreatedBy ,@CreationDate, @Status , @TotalNoOfColor , @ModifyBy, @ModifyDate, @CommandID);";


                    cmd.Parameters.Add("@GSampleID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 0;
                    cmd.Parameters.Add("@SampleNo", MySql.Data.MySqlClient.MySqlDbType.String).Value = "";
                    cmd.Parameters.Add("@SampleName", MySql.Data.MySqlClient.MySqlDbType.String).Value = txtSampleName.Text;
                    cmd.Parameters.Add("@CustomerSampleName", MySql.Data.MySqlClient.MySqlDbType.String).Value = "";
                    cmd.Parameters.Add("@BrandID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddBrand.SelectedValue;


                    cmd.Parameters.Add("@ProgramID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddlProgram.SelectedValue;
                    cmd.Parameters.Add("@ProductCategoryID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 2;
                    cmd.Parameters.Add("@ProductSubCategoryID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddSubCategory.SelectedValue;



                    cmd.Parameters.Add("@ClientID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddClient.SelectedValue;
                    cmd.Parameters.Add("@CompanyID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddlCompany.SelectedValue;



                    cmd.Parameters.Add("@NPDExecutive", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddPDExecutive.SelectedValue;
                    cmd.Parameters.Add("@Unit", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddlUnit.SelectedValue;



                    cmd.Parameters.Add("@Length", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = txtLenghtmm.Text;
                    cmd.Parameters.Add("@Width", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = txtwidthmm.Text;


                    cmd.Parameters.Add("@QuotedPrice", MySql.Data.MySqlClient.MySqlDbType.String).Value = txtQuotedPrice.Text;
                    cmd.Parameters.Add("@ArtworkLocation_FileName", MySql.Data.MySqlClient.MySqlDbType.String).Value = txtArtworkLocation.Text;



                    cmd.Parameters.Add("@Imagepath", MySql.Data.MySqlClient.MySqlDbType.String).Value = txtImagepath.Text;
                    cmd.Parameters.Add("@Cancel", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddlCancel.SelectedValue;


                    cmd.Parameters.Add("@CreatedBy", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 68;
                    cmd.Parameters.Add("@CreationDate", MySql.Data.MySqlClient.MySqlDbType.Datetime).Value = System.DateTime.Now.Date;
                    cmd.Parameters.Add("@Status", MySql.Data.MySqlClient.MySqlDbType.String).Value = 0;

                    cmd.Parameters.Add("@TotalNoOfColor", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = txtTotalColor.Text;

                    cmd.Parameters.Add("@ModifyBy", MySql.Data.MySqlClient.MySqlDbType.String).Value = 68;
                    cmd.Parameters.Add("@ModifyDate", MySql.Data.MySqlClient.MySqlDbType.Datetime).Value = System.DateTime.Now.Date;
                    cmd.Parameters.Add("@CommandID", MySql.Data.MySqlClient.MySqlDbType.String).Value = 1;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }


              DataTable sa=Retrun_SampleID(txtSampleName.Text);
               // string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
                using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(constr))
                {
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "CALL InsertUpdatePFL_spec(@PFL_spec_ID,@SampleID,@SampleName, @BrandID, @ProgramID, @ProductCategoryID,@ProductSubCategoryID, @ClientID, @CompanyID, @NPDExecutive, @Unit, @Length, @Width, @QuotedPrice, @ArtworkLocation_FileName, @Imagepath, @Cancel, @CreatedBy ,@CreationDate, @Status , @TotalNoOfColor , @ModifyBy, @ModifyDate, @CommandID);";

                    cmd.Parameters.Add("@PFL_spec_ID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 0;
                    cmd.Parameters.Add("@SampleID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = sa.Rows[0]["SampleID"].ToString();
                    cmd.Parameters.Add("@SampleName", MySql.Data.MySqlClient.MySqlDbType.String).Value = txtSampleName.Text;
                    cmd.Parameters.Add("@BrandID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddBrand.SelectedValue;


                    cmd.Parameters.Add("@ProgramID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddlProgram.SelectedValue;
                    cmd.Parameters.Add("@ProductCategoryID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 2;
                    cmd.Parameters.Add("@ProductSubCategoryID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddSubCategory.SelectedValue;



                    cmd.Parameters.Add("@ClientID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddClient.SelectedValue;
                    cmd.Parameters.Add("@CompanyID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddlCompany.SelectedValue;



                    cmd.Parameters.Add("@NPDExecutive", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddPDExecutive.SelectedValue;
                    cmd.Parameters.Add("@Unit", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddlUnit.SelectedValue;



                    cmd.Parameters.Add("@Length", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = txtLenghtmm.Text;
                    cmd.Parameters.Add("@Width", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = txtwidthmm.Text;


                    cmd.Parameters.Add("@QuotedPrice", MySql.Data.MySqlClient.MySqlDbType.String).Value = txtQuotedPrice.Text;
                    cmd.Parameters.Add("@ArtworkLocation_FileName", MySql.Data.MySqlClient.MySqlDbType.String).Value = txtArtworkLocation.Text;



                    cmd.Parameters.Add("@Imagepath", MySql.Data.MySqlClient.MySqlDbType.String).Value = txtImagepath.Text;
                    cmd.Parameters.Add("@Cancel", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddlCancel.SelectedValue;


                    cmd.Parameters.Add("@CreatedBy", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 68;
                    cmd.Parameters.Add("@CreationDate", MySql.Data.MySqlClient.MySqlDbType.Datetime).Value = System.DateTime.Now.Date;
                    cmd.Parameters.Add("@Status", MySql.Data.MySqlClient.MySqlDbType.String).Value = 0;

                    cmd.Parameters.Add("@TotalNoOfColor", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = txtTotalColor.Text;

                    cmd.Parameters.Add("@ModifyBy", MySql.Data.MySqlClient.MySqlDbType.String).Value = 68;
                    cmd.Parameters.Add("@ModifyDate", MySql.Data.MySqlClient.MySqlDbType.Datetime).Value = System.DateTime.Now.Date;
                    cmd.Parameters.Add("@CommandID", MySql.Data.MySqlClient.MySqlDbType.String).Value = 1;


                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            Commom_GridLoad("");
            btnExit_Click(sender, e);
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("/NPD/NPD_PFL_Spec.aspx?");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
                using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(constr))
                {
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "CALL InsertUpdatePFL_spec(@spec_ID,@SampleID,@SampleName, @BrandID, @ProgramID, @ProductCategoryID,@ProductSubCategoryID, @ClientID, @CompanyID, @NPDExecutive, @Unit, @Length, @Width, @QuotedPrice, @ArtworkLocation_FileName, @Imagepath, @Cancel, @CreatedBy ,@CreationDate, @Status , @TotalNoOfColor , @ModifyBy, @ModifyDate, @CommandID);";

                    cmd.Parameters.Add("@spec_ID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Label1.Text;
                    cmd.Parameters.Add("@SampleID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Label2.Text; ;
                    cmd.Parameters.Add("@SampleName", MySql.Data.MySqlClient.MySqlDbType.String).Value = txtSampleName.Text;
                    cmd.Parameters.Add("@BrandID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddBrand.SelectedValue;


                    cmd.Parameters.Add("@ProgramID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddlProgram.SelectedValue;
                    cmd.Parameters.Add("@ProductCategoryID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 2;
                    cmd.Parameters.Add("@ProductSubCategoryID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddSubCategory.SelectedValue;



                    cmd.Parameters.Add("@ClientID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddClient.SelectedValue;
                    cmd.Parameters.Add("@CompanyID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddlCompany.SelectedValue;



                    cmd.Parameters.Add("@NPDExecutive", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddPDExecutive.SelectedValue;
                    cmd.Parameters.Add("@Unit", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddlUnit.SelectedValue;



                    cmd.Parameters.Add("@Length", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = txtLenghtmm.Text;
                    cmd.Parameters.Add("@Width", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = txtwidthmm.Text;


                    cmd.Parameters.Add("@QuotedPrice", MySql.Data.MySqlClient.MySqlDbType.String).Value = txtQuotedPrice.Text;
                    cmd.Parameters.Add("@ArtworkLocation_FileName", MySql.Data.MySqlClient.MySqlDbType.String).Value = txtArtworkLocation.Text;



                    cmd.Parameters.Add("@Imagepath", MySql.Data.MySqlClient.MySqlDbType.String).Value = txtImagepath.Text;
                    cmd.Parameters.Add("@Cancel", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddlCancel.SelectedValue;


                    cmd.Parameters.Add("@CreatedBy", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 68;
                    cmd.Parameters.Add("@CreationDate", MySql.Data.MySqlClient.MySqlDbType.Datetime).Value = System.DateTime.Now.Date;
                    cmd.Parameters.Add("@Status", MySql.Data.MySqlClient.MySqlDbType.String).Value = 0;

                    cmd.Parameters.Add("@TotalNoOfColor", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = txtTotalColor.Text;

                    cmd.Parameters.Add("@ModifyBy", MySql.Data.MySqlClient.MySqlDbType.String).Value = 68;
                    cmd.Parameters.Add("@ModifyDate", MySql.Data.MySqlClient.MySqlDbType.Datetime).Value = System.DateTime.Now.Date;
                    cmd.Parameters.Add("@CommandID", MySql.Data.MySqlClient.MySqlDbType.String).Value = 2;




                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            Commom_GridLoad("");
            btnExit_Click(sender, e);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
        private void showSpecdata()
        {
            lblMsg.Text = "";
            btnEdit.Visible = true;
            btnDelete.Visible = false;
            btnSave.Visible = false;
            Label1.Text = gvDepartment.SelectedRow.Cells[1].Text.Replace("amp;", "").Replace("&nbsp;", "");
            Label2.Text = gvDepartment.SelectedRow.Cells[2].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtSampleName.Text = gvDepartment.SelectedRow.Cells[3].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddBrand.Text = gvDepartment.SelectedRow.Cells[4].Text.Replace("amp;", "").Replace("&nbsp;", "");
            SubBrand();
            ddlProgram.Text = gvDepartment.SelectedRow.Cells[6].Text.Replace("amp;", "").Replace("&nbsp;", "");

            ddSubCategory.Text = gvDepartment.SelectedRow.Cells[9].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddClient.Text = gvDepartment.SelectedRow.Cells[11].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlCompany.Text = gvDepartment.SelectedRow.Cells[13].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddPDExecutive.Text = gvDepartment.SelectedRow.Cells[15].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlUnit.Text = gvDepartment.SelectedRow.Cells[17].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtLenghtmm.Text = gvDepartment.SelectedRow.Cells[19].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtwidthmm.Text = gvDepartment.SelectedRow.Cells[20].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtQuotedPrice.Text = gvDepartment.SelectedRow.Cells[21].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtArtworkLocation.Text = gvDepartment.SelectedRow.Cells[22].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtImagepath.Text = gvDepartment.SelectedRow.Cells[23].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlCancel.Text = gvDepartment.SelectedRow.Cells[24].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtTotalColor.Text = gvDepartment.SelectedRow.Cells[25].Text.Replace("amp;", "").Replace("&nbsp;", "");
          
        }
        protected void gvDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            btnEdit.Visible = true;
            btnDelete.Visible = false;
            btnSave.Visible = false;
            Label1.Text = gvDepartment.SelectedRow.Cells[1].Text.Replace("amp;", "").Replace("&nbsp;", "");
            Label2.Text = gvDepartment.SelectedRow.Cells[2].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtSampleName.Text = gvDepartment.SelectedRow.Cells[3].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddBrand.Text = gvDepartment.SelectedRow.Cells[4].Text.Replace("amp;", "").Replace("&nbsp;", "");
            SubBrand();
            ddlProgram.Text = gvDepartment.SelectedRow.Cells[6].Text.Replace("amp;", "").Replace("&nbsp;", "");
          
            ddSubCategory.Text = gvDepartment.SelectedRow.Cells[9].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddClient.Text = gvDepartment.SelectedRow.Cells[11].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlCompany.Text = gvDepartment.SelectedRow.Cells[13].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddPDExecutive.Text = gvDepartment.SelectedRow.Cells[15].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlUnit.Text = gvDepartment.SelectedRow.Cells[17].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtLenghtmm.Text = gvDepartment.SelectedRow.Cells[19].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtwidthmm.Text = gvDepartment.SelectedRow.Cells[20].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtQuotedPrice.Text = gvDepartment.SelectedRow.Cells[21].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtArtworkLocation.Text = gvDepartment.SelectedRow.Cells[22].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtImagepath.Text = gvDepartment.SelectedRow.Cells[23].Text.Replace("amp;", "").Replace("&nbsp;", "");
            ddlCancel.Text = gvDepartment.SelectedRow.Cells[24].Text.Replace("amp;", "").Replace("&nbsp;", "");
            txtTotalColor.Text = gvDepartment.SelectedRow.Cells[25].Text.Replace("amp;", "").Replace("&nbsp;", "");
          
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
                e.Row.Cells[18].Visible = false;
                e.Row.Cells[19].Visible = false;
                e.Row.Cells[20].Visible = false;
                e.Row.Cells[21].Visible = false;
                e.Row.Cells[22].Visible = false;
                e.Row.Cells[23].Visible = false;
                e.Row.Cells[23].Visible = false;
                e.Row.Cells[25].Visible = false;
                
            } 
        }

        protected void linkTechnical_Click(object sender, EventArgs e)
        {
            Response.Redirect("../NPD/npd_pfl_techonical.aspx?SampleID=" + Label2.Text);

        }

        protected void LinkbuttonMaterials_Click(object sender, EventArgs e)
        {
            Response.Redirect("../NPD/Npd_pfl_Materials.aspx?SampleID=" + Label2.Text);
        }
    }
}