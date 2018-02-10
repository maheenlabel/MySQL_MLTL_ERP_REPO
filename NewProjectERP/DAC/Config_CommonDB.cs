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

        public DataTable ReturnTranNo(string tablename,string columnname)
        {
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("retunLastTranNo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tablename", tablename);
                    cmd.Parameters.AddWithValue("@ColumnName", columnname);
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        DataSet dt = new DataSet();
                        sda.Fill(dt);
                        return dt.Tables[0];

                    }
                }
            }



        }
        public DataTable GetAutoGenNo(string trantype)
        {
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("generatetranno", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@intrantype", trantype);

                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;

                    }
                }
            }

        }
        public string ReturnTranTypeWise(string tablename, string columnname,string typename)
        {
            string gnstr1 =null;
            string middleNoFormated = null;
            string gnstr =typename.Substring(0,3).ToUpper()+  "-0000000001-" + DateTime.Now.Year.ToString();
            DataTable gntb = GetAutoGenNo(typename);
            if (gntb.Rows.Count>0)
            {
                 gnstr1 = Convert.ToString(gntb.Rows[0][0]);
                 Config_CommonDB cm = new DAC.Config_CommonDB();
                 DataTable tranNotb = cm.ReturnTranNo(tablename, columnname);
                 if (tranNotb.Rows.Count > 0 && tranNotb.Rows[0][0].ToString()!=string.Empty)
                 {
                     gnstr1 = Convert.ToString(tranNotb.Rows[0][0]);
                     middleNoFormated = "000000000" + Convert.ToString(Convert.ToInt32(gnstr1) + 1);
                     gnstr = typename.Substring(0, 3).ToUpper() + "-" + middleNoFormated.Substring(middleNoFormated.Length - 10) +"-" + DateTime.Now.Year.ToString();
                 }
                 
                 
            }
            return gnstr;
        }
        /*
                public SqlDataReader GetSupplier()
                {

                    string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
                    using (MySqlConnection con = new MySqlConnection(constr))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("Load_SupplierList_proc", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@sample", SampleID);
                            using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                sda.Fill(dt);
                                return dt;

                            }
                        }
                    }
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