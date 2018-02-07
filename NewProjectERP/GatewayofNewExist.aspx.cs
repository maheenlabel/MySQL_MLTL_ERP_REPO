using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewProjectERP
{
    public partial class GatewayofNewExist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CategoryList();
            }
          
        }
        [WebMethod]
        public static List<string> GetAutoCompleteData(string username)
        {
            List<string> result = new List<string>();
           // SqlConnection con = new SqlConnection("Data Source=MLTL-DEV-2;Initial Catalog=MLTL-ERP-LATEST;User ID=sa");
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            MySqlConnection con = new MySqlConnection(constr);
            MySqlCommand cmd = new MySqlCommand("select DISTINCT ProductCategoryName from npd_productcategory_tbl where ProductCategoryName LIKE '%'+@Name+'%'", con);
            con.Open();
            cmd.Parameters.AddWithValue("@Name", username);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                result.Add(dr["ProductCategoryName"].ToString());
            }
            return result;
        }
       
        public void CategoryList()
        {
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            // string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT ProductCategoryID,ProductCategoryName FROM npd_productcategory_tbl"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    ddlCategory.DataSource = cmd.ExecuteReader();
                    ddlCategory.DataTextField = "ProductCategoryName";
                    ddlCategory.DataValueField = "ProductCategoryID";
                    ddlCategory.DataBind();
                    con.Close();
                }
            }
            ddlCategory.Items.Insert(0, new ListItem("--Select Product Category--", "0"));
        }
        public int Samplefound(string Category,string product)
        {
            int ProductFound = 0;
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    // using (MySqlCommand cmd = new MySqlCommand("Load_grid_Woven_Techonical_pro", con))
                    using (MySqlCommand cmd = new MySqlCommand("CheckProductCategoryWise", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Category", Category);
                        cmd.Parameters.AddWithValue("@product", product);
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {

                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            ProductFound = Convert.ToInt32(dt.Rows[0][0]);


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ProductFound = 0;
            }
            return ProductFound;
        }
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSerachItem.Focus();
            
        }

        protected void linkTsepc_Click(object sender, EventArgs e)
        {
             string CallCategory = ddlCategory.SelectedItem.ToString();
            int samplefound=0;
            samplefound = Samplefound(CallCategory, txtSerachItem.Text);
            if (samplefound == 0)
            {
                txtSerachItem.Text = "Product spec not found";
                return;
            }
            else
            {
                if (CallCategory.Trim() == "Woven")
                {
                    Response.Redirect("NPD/NPD_Woven_Spec.aspx?ID=" + txtSerachItem.Text);

                }
                else if (CallCategory == "PFL")
                {
                    Response.Redirect("NPD/NPD_PFL_Spec.aspx?ID=" + txtSerachItem.Text);
                }
                else if (CallCategory == "Screen Print")
                {
                    Response.Redirect("WovenSpectedDataSheet.aspx?ID=" + txtSerachItem.Text);
                }
                else if (CallCategory == "Offset")
                {
                    Response.Redirect("NPD/NPD_Offset_Spec.aspx?ID=" + txtSerachItem.Text);
                }
                else if (CallCategory == "Heat Transfer")
                {
                    Response.Redirect("NPD/WovenSpectedDataSheet.aspx?ID=" + txtSerachItem.Text);
                }
                else if (CallCategory == "Thermal")
                {
                    Response.Redirect("NPD/WovenSpectedDataSheet.aspx?ID=" + txtSerachItem.Text);
                }
                else if (CallCategory == "Button Label")
                {
                    Response.Redirect("NPD/WovenSpectedDataSheet.aspx?ID=" + txtSerachItem.Text);
                }
                else
                {

                }
            }
        }
     
    }
}