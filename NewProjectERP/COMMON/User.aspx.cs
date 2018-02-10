using NewProjectERP.DAC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace NewProjectERP
{

    public partial class User : System.Web.UI.Page
    {
        //int indexOfColumn = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
             //   AccessButton();
             ////   ViewUser("");
             //   CardNoList();
             //   DeptList();
             //   RoleList();
                LanguageList();
                //StatusList();
             //   MultiRoleList();

             //   txtLoginID.Text = "";
             //   txtPassword.Text = "";

                btnEdit.Visible = false;
                btnResetPassword.Visible = false;
             //   btnSaveAndSameBatch.Visible = true;
             //   btnDelete.Visible = false;
            }            
        }

        public void LanguageList()
        {
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            // string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("LangguageList_proc"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    con.Open();
                    ddlLanguage.DataSource = cmd.ExecuteReader();
                    ddlLanguage.DataTextField = "LanguageName";
                    ddlLanguage.DataValueField = "Language_ID";
                    ddlLanguage.DataBind();
                    con.Close();
                }
            }
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
        private void CardNoList()
        {
            //CommonDB cdb = new CommonDB();
            //ddCardNo.DataSource = cdb.GetdtBySp("Complain_GetCardNoList_Proc1");
            //ddCardNo.DataTextField = "CardNo";
            //ddCardNo.DataValueField = "CardNo";
            //ddCardNo.DataBind();
            //ddCardNo.Items.Insert(0, "Please Select");
            //ddCardNo.Items.Insert(1, "Party");
        }
        private void MultiRoleList()
        {
            //CommonDB cdb = new CommonDB();
            //cblRole.DataSource = cdb.GetdtBySp("sp_UserRole_proc");
            //cblRole.DataTextField = "Role Name";
            //cblRole.DataValueField = "RoleID";
            //cblRole.DataBind();
        }
        private void DeptList()
        {
            //CommonDB cdb = new CommonDB();
            //ddlDept.DataSource = cdb.GetdtBySp("Com_GetDepartmntList_prc");
            //ddlDept.DataTextField = "Department Name";
            //ddlDept.DataValueField = "DepartmentID";
            //ddlDept.DataBind();
            //ddlDept.Items.Insert(0, "Please Select");            
        }
        private void AccessButton()
        {
            //string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
            //string sRet = oInfo.Name;
            //CommonDB dbs = new CommonDB();
            //int PageID = dbs.GetReturnColumnValue("Config_ModuleWisePage_tbl", "PageName", sRet, "PageID");
            //DataTable Dep = dbs.OperationAccess(Convert.ToInt32(Request.Cookies["RoleID"].Value), PageID);

            //btnSaveAndSameBatch.Enabled = false;
            //btnDelete.Enabled = false;
            //btnEdit.Enabled = false;

            //if (Dep.Rows[0][0].ToString() == "True")
            //{
            //    btnSaveAndSameBatch.Enabled = true;
            //}
            //if (Dep.Rows[0][1].ToString() == "True")
            //{
            //    btnEdit.Enabled = true;
            //}
            //if (Dep.Rows[0][2].ToString() == "True")
            //{
            //    btnDelete.Enabled = true;
            //}
        }
        private void Clear()
        {
          //  ddlEmployee.Items.Clear();
          //  txtLoginID.Text = "";
          //  txtPassword.Text = "";
          //  DeptList();
          //  RoleList();
          //  MultiRoleList();
          //  StatusList();
          ////  ViewUser("");
          //  btnEdit.Visible = false;
          //  btnSaveAndSameBatch.Visible = true;
          //  btnDelete.Visible = false;
          //  ddlEmployee.Focus();          
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            ////string msg = "";
            //UserDB DB = new UserDB();
            //int RoleID = 0;
            //try
            //{
            //    int Userids = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);

            //    if (ddlDept.SelectedItem.Text == "Please Select")
            //    {
            //        lblMsg.Text = "Please Select a Department ...";
            //        //Response.Write("<script>alert('" + lblMsg.Text + "');</script>");
            //        lblMsg.ForeColor = System.Drawing.Color.Green;
            //        ddlDept.Focus();
            //        return;
            //    }

            //    if (ddlEmployee.SelectedItem.Text == "")
            //    {
            //        lblMsg.Text = "Please Select an Employee ...";
            //       // Response.Write("<script>alert('" + lblMsg.Text + "');</script>");
            //        lblMsg.ForeColor = System.Drawing.Color.Green;
            //        ddlEmployee.Focus();
            //        return;
            //    }

            //    if (txtLoginID.Text == "")
            //    {
            //        lblMsg.Text = "Please insert an login id ...";
            //        //Response.Write("<script>alert('" + lblMsg.Text + "');</script>");
            //        lblMsg.ForeColor = System.Drawing.Color.Green;
            //        txtLoginID.Focus();
            //        return;
            //    }

            //    //if (txtPassword.Text == "")
            //    //{
            //    //    lblMsg.Text = "Please insert an password ...";
            //    //    Response.Write("<script>alert('" + lblMsg.Text + "');</script>");
            //    //    txtPassword.Focus();
            //    //    return;
            //    //}

            //    //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "ConfirmEdit()", true);

            //    string confirmValue = Request.Form["confirm_Edit_value"];
            //    if (confirmValue == "Yes")
            //    {
            //        //DB.InsertUpdateUser(Userids, Convert.ToInt32(ddlEmployee.SelectedItem.Value.ToString()), txtLoginID.Text, DB.Encrypt(txtPassword.Text), Convert.ToInt32(ddlRole.SelectedItem.Value.ToString()), DateTime.Now, ddlStatus.SelectedItem.ToString(), 2);
                    
            //        for (int i = 0; i < cblRole.Items.Count; i++)
            //        {
            //            if (cblRole.Items[i].Selected)
            //            {
            //                RoleID = Convert.ToInt32(cblRole.Items[i].Value);
            //                DB.InsertUpdateUser(Userids, Convert.ToInt32(ddlEmployee.SelectedItem.Value.ToString()), txtLoginID.Text, DB.Encrypt(txtPassword.Text), RoleID, DateTime.Now, ddlStatus.SelectedItem.ToString(), 2);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        return;
            //    }

            //    lblMsg.Text = "User Edited Successfully ...";
            //    lblMsg.ForeColor = System.Drawing.Color.Green;
            //    //Response.Write("<script>alert('" + lblMsg.Text + "');</script>");

            //    Clear();
            //}
            //catch (Exception ex)
            //{
            //    lblMsg.Text = "Please Enter Valid Information";
            //    //Response.Write("<script>alert('" + msg + "');</script>");
            //    lblMsg.ForeColor = System.Drawing.Color.Red;
            //}
            //finally
            //{

            //}
        }

        private void ViewUser(string LoginID,string FindType)
        {
            //SqlCommand command = new SqlCommand();
            //SqlDataAdapter adapter = new SqlDataAdapter();
            //DataSet ds = new DataSet();
            //ds.Clear();
            //SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            //myConnection.Open();
            //command.Connection = myConnection;
            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "Com_GetUserInfoByType";
            //SqlParameter parameterIndentID = new SqlParameter("@LoginID", SqlDbType.VarChar, 50);
            //parameterIndentID.Value = LoginID;
            //command.Parameters.Add(parameterIndentID);

            //SqlParameter parameterIndentID1 = new SqlParameter("@FindType", SqlDbType.VarChar, 50);
            //parameterIndentID1.Value = FindType;
            //command.Parameters.Add(parameterIndentID1);

            //adapter = new SqlDataAdapter(command);
            //adapter.Fill(ds);
            //myConnection.Close();
            //GridView1.DataSource = ds.Tables[0];
            //GridView1.DataBind();
        }

        private void RoleList()
        {
            //SqlCommand command = new SqlCommand();
            //SqlDataAdapter adapter = new SqlDataAdapter();
            //DataTable ds = new DataTable();
            //ds.Clear();
            //SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            //myConnection.Open();
            //command.Connection = myConnection;
            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "sp_UserRole_proc";
            //adapter = new SqlDataAdapter(command);
            //adapter.Fill(ds);
            //myConnection.Close();
            //ddlRole.DataSource = ds;
            //ddlRole.DataTextField = "Role Name";
            //ddlRole.DataValueField = "RoleID";
            //ddlRole.DataBind();
            ////ddlRole.Items.Insert(0, "Please Select");
        }

        private void StatusList()
        {
            //ddlStatus.Items.Add(1,"ACTIVE");
            //ddlStatus.Items.Add(0,"INACTIVE");
        }

        private void EmployeeList(int DeptID)
        {
          //  CommonDB cdb = new CommonDB();
          //  DataTable ds = cdb.SearchCommonTbl3888(DeptID, "Com_GetEmployeeListByDeptName_proc");
          //  ddlEmployee.DataSource = ds;
          //  ddlEmployee.DataTextField = "empname";
          //  ddlEmployee.DataValueField = "Emp_ID";
          //  ddlEmployee.DataBind();

          ////  CommonDB cdb1 = new CommonDB();
          //  DataTable ds1 = cdb.SearchCommonTbl3888(DeptID, "Com_GetEmployeeListByDeptCardNo_proc");
          //  ddCardNo.DataSource = ds1;
          //  ddCardNo.DataTextField = "PrevEmpID";
          //  ddCardNo.DataValueField = "Emp_ID";
          //  ddCardNo.DataBind();

          //  ddlEmployee.Text = ddCardNo.SelectedValue;
        }
        private void EmployeeCardList(string DeptID)
        {
            //CommonDB cdb = new CommonDB();
            //DataTable ds = cdb.SearchCommonTbl3(DeptID, "Com_GetEmployeeListByDeptName_proc");
            //ddlEmployee.DataSource = ds;
            //ddlEmployee.DataTextField = "empname";
            //ddlEmployee.DataValueField = "Emp_ID";
            //ddlEmployee.DataBind();

            //CommonDB cdb1 = new CommonDB();
            //DataTable ds1 = cdb1.SearchCommonTbl3(DeptID, "Com_GetEmployeeCardByDeptName_proc");
            //ddCardNo.DataSource = ds1;
            //ddCardNo.DataTextField = "PrevEmpID";
            //ddCardNo.DataValueField = "Emp_ID";
            //ddCardNo.DataBind();

           
        }
        private void EmployeeListAll()
        {
            //CommonDB cdb = new CommonDB();
            //DataTable ds = cdb.GetdtBySp("Com_GetEmpList_Proc");
            //ddlEmployee.DataSource = ds;
            //ddlEmployee.DataTextField = "empname";
            //ddlEmployee.DataValueField = "Emp_ID";
            //ddlEmployee.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                 string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
                using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(constr))
                {
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "CALL InsertUpdate_UserTbl_proc(@LoginUserID,@Language_ID,@LoginID,@Password, @UserStatus, @CommandID);";


                    cmd.Parameters.Add("@LoginUserID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 0;
                    cmd.Parameters.Add("@Language_ID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddlLanguage.SelectedValue;
                    cmd.Parameters.Add("@LoginID", MySql.Data.MySqlClient.MySqlDbType.String).Value = txtLoginID.Text;
                    cmd.Parameters.Add("@Password", MySql.Data.MySqlClient.MySqlDbType.String).Value = txtPassword.Text;
                    cmd.Parameters.Add("@UserStatus", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = ddlStatus.SelectedValue;
                    cmd.Parameters.Add("@CommandID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = 1;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                btnExit_Click(sender, e);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        protected void btnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("/COMMON/User.aspx?");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lblMsg.Text = "";
            //CommonDB cdb = new CommonDB();
            //UserDB udb = new UserDB();
            //btnEdit.Visible = true;
            //btnSaveAndSameBatch.Visible = false;
            //btnDelete.Visible = false;

            ////lblpass.Visible = false;
           
            ////lblstar.Visible = false;
            
            //ddlDept.SelectedValue = cdb.GetReturnColumnValueStr("Com_EmployeeOfficialInfo_tbl", "Emp_ID", GridView1.SelectedRow.Cells[2].Text.Replace("amp;", "").Replace("&nbsp;",""), "Dep_ID");
            //EmployeeList(Convert.ToInt32(ddlDept.SelectedValue));
            //ddlEmployee.SelectedValue = GridView1.SelectedRow.Cells[2].Text.Replace("amp;", "").Replace("&nbsp;", "");
            //txtLoginID.Text = GridView1.SelectedRow.Cells[5].Text.Replace("amp;", "").Replace("&nbsp;", "");
            //txtPassword.Text = udb.Encrypt(GridView1.SelectedRow.Cells[4].Text).Replace("amp;", "").Replace("&nbsp;", "");
            //ddlRole.SelectedValue = GridView1.SelectedRow.Cells[3].Text.Replace("amp;", "").Replace("&nbsp;", "");

            //if (GridView1.SelectedRow.Cells[3].Text.Replace("amp;", "").Replace("&nbsp;", "") != "")
            //{
            //    string RoleID = GridView1.SelectedRow.Cells[3].Text.Replace("amp;", "").Replace("&nbsp;", "");

            //    MultiRoleList();

            //    for (int i = 0; i < cblRole.Items.Count; i++)
            //    {
            //        if (cblRole.Items[i].Value.ToString() == RoleID)
            //        {
            //            cblRole.Items[i].Selected = true;
            //        }
            //        else
            //        {
            //            cblRole.Items[i].Selected = false;
            //        }
            //    }
            //}

            //ddlStatus.SelectedValue = GridView1.SelectedRow.Cells[7].Text.Replace("amp;", "").Replace("&nbsp;", "");
           
            //ddlEmployee.Focus();

            //txtPassword.ReadOnly = true;
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
           
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.Cells.Count > indexOfColumn)
            //{
            //    e.Row.Cells[1].Visible = false;
            //    e.Row.Cells[2].Visible = false;
            //    e.Row.Cells[3].Visible = false;
            //    e.Row.Cells[4].Visible = false;
            //} 
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //GridView1.PageIndex = e.NewPageIndex;
            //ViewUser(FindLoginID.Text, ddlSearch.SelectedItem.ToString());
        }

        protected void FindLoginID_TextChanged(object sender, EventArgs e)
        {

           // ViewUser(FindLoginID.Text, ddlSearch.SelectedItem.ToString());
        }
        protected void btnFind_Click(object sender, EventArgs e)
        {
            //ViewUser(FindLoginID.Text, ddlSearch.SelectedItem.ToString());
        }
        protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            //EmployeeList(Convert.ToInt32(ddlDept.SelectedValue));
        }
        protected void ddCardNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddCardNo.SelectedIndex != 0)
            //{
            //    ddlEmployee.Text = ddCardNo.SelectedValue;
            //}
        
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //UserDB DB = new UserDB();

            ////ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "ConfirmDelete()", true);

            //string confirmValue = Request.Form["confirm_delete_value"];
            //if (confirmValue == "Yes")
            //{
            //    DB.InsertUpdateUser(0, Convert.ToInt32(ddlEmployee.SelectedItem.Value.ToString()), txtLoginID.Text, DB.Encrypt(txtPassword.Text), Convert.ToInt32(ddlRole.SelectedItem.Value.ToString()), DateTime.Now, ddlStatus.SelectedItem.ToString(), 3);
            //    Clear();
            //    //Response.Write("<script>alert('Delete Successfully ...');</script>");
            //    lblMsg.Text = "Delete Successfully";
            //    lblMsg.ForeColor = System.Drawing.Color.Green;
            //}
            //else
            //{
            //    return;
            //}

        }


        protected void btnResetPassword_OnClick(object sender, EventArgs e)
        {
            //UserDB DB = new UserDB();

            //try
            //{
            //    int Userids = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);

            //    if (ddlDept.SelectedItem.Text == "Please Select")
            //    {
            //        lblMsg.Text = "Please Select a Department ...";
            //        lblMsg.ForeColor = System.Drawing.Color.Green;
            //        ddlDept.Focus();
            //        return;
            //    }

            //    if (ddlEmployee.SelectedItem.Text == "")
            //    {
            //        lblMsg.Text = "Please Select an Employee ...";
            //        lblMsg.ForeColor = System.Drawing.Color.Green;
            //        ddlEmployee.Focus();
            //        return;
            //    }

            //    if (txtLoginID.Text == "")
            //    {
            //        lblMsg.Text = "Please insert an login id ...";
            //        lblMsg.ForeColor = System.Drawing.Color.Green;
            //        txtLoginID.Focus();
            //        return;
            //    }

            //    DB.InsertUpdateUser(Userids, Convert.ToInt32(ddlEmployee.SelectedItem.Value.ToString()), txtLoginID.Text, "5F-A2-85-E1-BE-BE-0A-66-23-E3-3A-FC-04-A1-FB-D5", Convert.ToInt32(ddlRole.SelectedItem.Value.ToString()), DateTime.Now, ddlStatus.SelectedItem.ToString(), 2);
                
            //    lblMsg.Text = "Reset Password Successfully ...";
            //    lblMsg.ForeColor = System.Drawing.Color.Green;

            //    Clear();
            //}
            //catch (Exception ex)
            //{
            //    lblMsg.Text = "Please Enter Valid Information";
            //    lblMsg.ForeColor = System.Drawing.Color.Red;
            //}
            //finally
            //{

            //}
        }
    }
}