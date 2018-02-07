using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NewProjectERP.DAC
{
    public class Config_CommonDB
    {
        public DataTable GetdtBySp(string spName)
        {          
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {               
                using (MySqlCommand cmd = new MySqlCommand(spName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@sample", SampleID);
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        DataSet dt = new DataSet();
                        sda.Fill(dt);
                        return dt.Tables[0];
                      
                    }
                }
            }
          


        }
/*
        public SqlDataReader GetSupplier()
        {

            //string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            //using (MySqlConnection con = new MySqlConnection(constr))
            //{
            //    using (MySqlCommand cmd = new MySqlCommand("Load_SupplierList_proc", con))
            //    {
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        //cmd.Parameters.AddWithValue("@sample", SampleID);
            //        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
            //        {
            //            DataTable dt = new DataTable();
            //            sda.Fill(dt);
            //            return dt;

            //        }
            //    }
            //}
            /////////////////////////////
            //string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            
            //using (MySqlConnection con = new MySqlConnection(constr))
            //{
            //    using (MySqlCommand cmd = new MySqlCommand("Load_SupplierList_proc"))
            //    {
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Connection = con;
            //        con.Open();
            //        SqlDataReader result = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            //        return result;
            //        con.Close();
            //    }
            //}

            //////////////////////////


            //SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            //SqlCommand myCommand = new SqlCommand("Inv_GetSupplierList_prc", myConnection);
            //myCommand.CommandType = CommandType.StoredProcedure;

            //myConnection.Open();
            //SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            //return result;
        }
        */
    }
}