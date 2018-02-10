using MySql.Data.MySqlClient;
using NewProjectERP.DAC;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewProjectERP
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //UserName.Focus();
            }

        }

        public DataTable Get_Login_wise_Language(string LogID, string Paword)
        {
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("Get_Login_wise_Language_ShortName_proc", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LogID", LogID);
                    cmd.Parameters.AddWithValue("@Paword", Paword);
                    
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
     

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
         DataTable dt= Get_Login_wise_Language(UserName.Text, Pass.Text);
         string shortlanguageName = dt.Rows[0]["ShortName"].ToString();
         Session["Lang"] = shortlanguageName;

            //Response.Cookies["RoleID"].Value = uinfo.RoleID;
            //string UserID = "0";
            //string RoleID = "";
            //UserDB db = new UserDB();
            //UserInfo uinfo = new UserInfo();
            //CommonDB cdb = new CommonDB();
            //int EmpID = cdb.GetReturnColumnValue("Com_UserInfo_tbl", "LoginID", UserName.Text, "Emp_ID");
            //int CompanyID = cdb.GetReturnColumnValue("Com_EmployeeOfficialInfo_tbl", "Emp_ID", EmpID.ToString(), "CompanyID");

            ////string BroadCastMsg = cdb.GetReturnCMsgValue("ComBroadCastingMsg", "Flag", "mlt", "RunMsg");
            //uinfo = db.ERP_Login(UserName.Text, Pass.Text, CompanyID);
            //UserID = uinfo.UserID;
            //RoleID = uinfo.RoleID;

            //if (UserID != "0")
            //{
            //    Response.Cookies["RoleID"].Value = uinfo.RoleID;
            //    Response.Cookies["RoleName"].Value = uinfo.RoleName;
            //    Response.Cookies["UserName"].Value = uinfo.UserName;

            //    Response.Cookies["CompanyID"].Value = uinfo.ComapanyID;
            //    Response.Cookies["DepartmentID"].Value = uinfo.DepartmentID;
            //    Response.Cookies["Designation"].Value = uinfo.Designation;
            //    Response.Cookies["DesigID"].Value = uinfo.DesigID;
            //    Response.Cookies["UserID"].Value = uinfo.UserID;
            //    Response.Cookies["EmpID"].Value = uinfo.EmpID;
            //    Response.Cookies["IsDeptHead"].Value = uinfo.IsDeptHead;
            //    Response.Cookies["IsManagement"].Value = uinfo.IsManagement;
            //    Response.Cookies["SMTPAddress"].Value = uinfo.SMTPAddress;
            //    Response.Cookies["PortNo"].Value = uinfo.PortNo;
            //    Response.Cookies["SSL"].Value = uinfo.SSL;
            //    Response.Cookies["FromAddress"].Value = uinfo.FromAddress;
            //    Response.Cookies["EmailConfigPassword"].Value = uinfo.EmailConfigPassword;

            //    //  Response.Cookies["BroadCastMsg"].Value = BroadCastMsg;
            //    Session["UserID"] = uinfo.UserID;

            //    FormsAuthentication.RedirectFromLoginPage(UserID, true);
            //    FormsAuthentication.SetAuthCookie(UserID, true);


            //    //HttpCookie aCookie = new HttpCookie("lastVisitID");
            //    //aCookie.Value = uinfo.UserID.ToString();
            //    //Response.Cookies.Add(aCookie);

            //    InsertIntoUserLog(1);

            //    // Response.Redirect("Default.aspx");
            //    ////  NewtonAdded
            //    //CommonDB log = new CommonDB();
            //    //log.LogFileClear();
            //    ////newtonCODE End
            //Response.Redirect("Main_Module_Page.aspx");

           // Response.Redirect("Main_Module_Page.aspx?&shortlanguageName=" + shortlanguageName);
            Response.Redirect("GatewayofNewExist.aspx? ModuleID=1");  

            //}
            //else
            //{
            //    MyMessage.Text = "Please Enter Correct Login ID or Password";
            //    MyMessage.ForeColor = System.Drawing.Color.Red;
            //}

        }

        protected void linkCategory_Click(object sender, EventArgs e)
        {
            Response.Redirect("COMMON/User.aspx");
        }
        //private void InsertIntoUserLog(int OperationType)
        //{
        //    CommonDB cdb = new CommonDB();

        //    UserLogDB uld = new UserLogDB();

        //    int Userids = Convert.ToInt32(HttpContext.Current.Session["UserID"]);

        //    int EmpID = cdb.GetReturnColumnValue("Com_UserInfo_tbl", "UserID", Userids.ToString(), "Emp_ID");

        //    int PageID = 0;

        //    int ModuleID = 0;

        //    DateTime OperationTime = DateTime.Now;

        //    string hostName = Dns.GetHostName();
        //    string IPAddress = Dns.GetHostByName(hostName).AddressList[0].ToString();

        //    int RoleID = cdb.GetReturnColumnValue("Com_UserInfo_tbl", "UserID", Userids.ToString(), "RoleID");

        //    uld.InsertUserLog(Userids, EmpID, ModuleID, PageID, OperationType, OperationTime, IPAddress, RoleID);
        //}
    }
}