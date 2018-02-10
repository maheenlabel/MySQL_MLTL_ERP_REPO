using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace autosearch
{
    public partial class AutoSearchCompleted : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<string> GetAutoCompleteData(string username)
        {
            List<string> result = new List<string>();
            SqlConnection con = new SqlConnection("Data Source=MLTL-DEV-2;Initial Catalog=MLTL-ERP-LATEST;User ID=sa");

            SqlCommand cmd = new SqlCommand("select DISTINCT FirstName from Com_EmployeePersonalInfo_tbl where FirstName LIKE '%'+@Name+'%'", con);
            con.Open();
            cmd.Parameters.AddWithValue("@Name", username);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                result.Add(dr["FirstName"].ToString());
            }
            return result;
        }
    }
}
