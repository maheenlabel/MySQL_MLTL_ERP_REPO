using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.Odbc;
using MySql.Data.MySqlClient;
using System.Web.Configuration; 

namespace NewProjectERP
{
    public partial class categorySampleApproval : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string shortlanguageName = "";
            if (Request.QueryString["shortlanguageName"] != null)
            {
                 shortlanguageName = Request.QueryString["shortlanguageName"]; 
            }
           BindDataGrid();
        }
        private void BindDataGrid()
        {
            using (MySqlConnection con1 = new MySqlConnection(WebConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString))
            using (MySqlCommand cmd = new MySqlCommand("SELECT ProductCategoryID,ProductCategoryName FROM npd_productcategory_tbl", con1))
            {
                con1.Open();
                DataGrid1.DataSource = cmd.ExecuteReader(
                    CommandBehavior.CloseConnection |
                    CommandBehavior.SingleResult);
                DataGrid1.DataBind();
            }
        }

        protected void linkCategory_Click(object sender, EventArgs e)
        {
             //<a class="more CsM" href="PFLSpectedDataSheet.aspx?ModuleID=1">PFL <i class="m-icon-swapright m-icon-white"></i>
             //                   <a class="more CsM" href="Default.aspx?ModuleID=1">Screen Print  <i class="m-icon-swapright m-icon-white"></i>
             //                   <a class="more CsM" href="WovenSpectedDataSheet.aspx?ModuleID=1">Woven <i class="m-icon-swapright m-icon-white"></i>
             //                   <a class="more CsM" href="Default.aspx?ModuleID=1">Offse <i class="m-icon-swapright m-icon-white"></i>
             //                   <a class="more CsM" href="Default.aspx?ModuleID=1">Heat Transfer<i class="m-icon-swapright m-icon-white"></i>
             //                   <a class="more CsM" href="Default.aspx?ModuleID=1">Thermal <i class="m-icon-swapright m-icon-white"></i>
             //                   <a class="more CsM" href="Default.aspx?ModuleID=1">Button Label  <i class="m-icon-swapright m-icon-white"></i>
             //                   <a class="more CsM" href="Default.aspx?ModuleID=1">Rebbon  <i class="m-icon-swapright m-icon-white"></i>
             //                   </a>
            string CallCategory=((LinkButton)sender).Text;
           
            if (CallCategory.Trim() == "Woven")
            {
                Response.Redirect("NPD/PD_DashBorad.aspx?Cat=1");
            }
            else if (CallCategory == "PFL")
            {
                Response.Redirect("NPD/PD_DashBorad.aspx?Cat=2");
            }
            else if (CallCategory == "Screen Print")
            {
                Response.Redirect("NPD/PD_DashBorad.aspx?Cat=3");
            }
            else if (CallCategory == "Offset")
            {
                Response.Redirect("NPD/PD_DashBorad.aspx?Cat=5");
            }
            else if (CallCategory == "Heat Transfer")
            {
                Response.Redirect("NPD/PD_DashBorad.aspx?Cat=1");
            }
            else if (CallCategory == "Thermal")
            {
                Response.Redirect("NPD/PD_DashBorad.aspx?Cat=1");
            }
            else if (CallCategory == "Button Label")
            {
                Response.Redirect("NPD/PD_DashBorad.aspx?Cat=1");
            }
        }
    }
}