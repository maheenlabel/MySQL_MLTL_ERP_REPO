using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;


namespace NewProjectERP
{
    public partial class TestPageNewton : System.Web.UI.Page
    {
        private const string ConnStr = "Driver={MySQL ODBC 3.51 Driver};Server=192.168.12.45;Database=mltl-erp-latest;uid=root;pwd=01011978;option=3";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //using (OdbcConnection con = new OdbcConnection(ConnStr))
            //using (OdbcCommand cmd = new OdbcCommand("{call newton();}", con))
            //{
            //    con.Open();
            //    //gvDepartment.DataSource = cmd.ExecuteReader(
            //    //    CommandBehavior.CloseConnection |
            //    //    CommandBehavior.SingleResult);
            //    //gvDepartment.DataBind();

            //    gvDepartment.DataSource = cmd.ExecuteReader(
            //      CommandBehavior.CloseConnection |
            //   CommandBehavior.Default);
            //    gvDepartment.DataBind();
            //}
            this.GetCustomer(int.Parse(txtBrandName.Text.Trim()));
        }


        private void GetCustomer(int WorkOrderID)
        {
            //string conn = "server=192.168.12.45;database=mltl-erp-latest;Persist Security Info=True;User Id=root;password=01011978";
            //OdbcConnection connect = new OdbcConnection(ConnStr);
            //connect.Open();
            ////  OdbcCommand ODBCCommand = new OdbcCommand("{call TestSP (?)}", connect);
            //OdbcCommand ODBCCommand = new OdbcCommand("{call Search_WorkorderId_wise (?)}", connect);

            //ODBCCommand.CommandType = CommandType.StoredProcedure;
            //ODBCCommand.Parameters.AddWithValue("@Workorder_id", WorkOrderID);


            //gvDepartment.DataSource = ODBCCommand.ExecuteReader(
            //        CommandBehavior.CloseConnection |
            //     CommandBehavior.Default);
            //gvDepartment.DataBind();

            ////  string constr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            //using (MySqlConnection con = new MySqlConnection(conn))
            //{
            //    using (MySqlCommand cmd = new MySqlCommand("Search_WorkorderId_wise", con))
            //    {
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@Workorder_id", WorkOrderID);
            //        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
            //        {
            //            DataTable dt = new DataTable();
            //            sda.Fill(dt);
            //            gvDepartment.DataSource = dt;
            //            gvDepartment.DataBind();
            //        }
            //    }
            //}

          //  MySqlConnection sql_conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString);


          //  //Here is where it differs...instead of calling it as a stored procedure type I just run it as a typical //mysql query would call it
          ////  MySqlCommand cmd = new MySqlCommand();
          ////  cmd.Connection = sql_conn;
          ////// cmd.CommandText = "CALL Search_WorkorderId_wise (@Workorder_id,)";
          ////  cmd.CommandText = "CALL ORD_ExportOrderToExcel_Proc (?,?,?,?)";
            
          //  ////an out parameter
          //  //cmd.Parameters.AddWithValue(para1, MySqlDbType.Int32);
          //  //cmd.Parameters[para1].Direction = ParameterDirection.Output;

          //  //an in parameter 

          //  //cmd.Parameters.AddWithValue("@Workorder_id", WorkOrderID);
          //  //cmd.Parameters["@Workorder_id"].Direction = ParameterDirection.Input;
          //  sql_conn.Open();
          //  MySqlCommand ODBCCommand = new MySqlCommand("{call 'ORD_ExportOrderToExcel_Proc' (?,?,?,?)}", sql_conn);

          //  ODBCCommand.CommandType = CommandType.StoredProcedure;
          //  ODBCCommand.Parameters.AddWithValue("@companyid", 1);
          //  ODBCCommand.Parameters.AddWithValue("@categoryid", 1);
          //  ODBCCommand.Parameters.AddWithValue("@fromdate", "2017-01-01");
          //  ODBCCommand.Parameters.AddWithValue("@todate", "2017-02-28");



          //  gvDepartment.DataSource = ODBCCommand.ExecuteReader(
          //          CommandBehavior.CloseConnection |
          //       CommandBehavior.Default);
          //  gvDepartment.DataBind();

           

            //MySqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            //DataTable dt = new DataTable();
            //dt.Load(rdr);
            //gvDepartment.DataSource = dt;
            //gvDepartment.DataBind();


            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
               // using (MySqlCommand cmd = new MySqlCommand("ORD_ExportOrderToExcel_Proc", con))
                using (MySqlCommand cmd = new MySqlCommand("Search_WorkorderId_wise", con))
                
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Workorder_id", WorkOrderID);
                    //cmd.Parameters.AddWithValue("@companyid", 1);
                    //cmd.Parameters.AddWithValue("@categoryid", 1);
                    //cmd.Parameters.AddWithValue("@fromdate", "2017-01-01");
                    //cmd.Parameters.AddWithValue("@todate", "2017-02-28");

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

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnExit_Click(object sender, EventArgs e)
        {

        }
    }
}