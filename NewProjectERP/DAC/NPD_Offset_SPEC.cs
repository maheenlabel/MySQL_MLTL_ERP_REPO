using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace NewProjectERP.DAC
{
    public class NPD_Offset_SPEC
    {
        public void InsertUpdate_npd_Offset_materials(int Material_ID, int SampleID,int BoardType,decimal BoardGSM,int IsFSC,string BoardColor,string AdhesiveColor,
            int StoreItemID, decimal Quanity, int Unit, string MahenCode,int SupplierID,int BatchID, int CreatedBy, DateTime CreationDate, int status, int CommandID)
        {
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(constr))
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "CALL InsertUpdate_npd_Offset_materials_proc(@Pfl_Material_ID ,@SampleID ,@BoardType,@BoardGSM,@IsFSC,@BoardColor,@AdhesiveColor,@StoreItemID ,@Quanity,@Unit,@MahenCode ,@SupplierID,@BatchID,@CreatedBy ,@CreationDate,@Status,@CommandID);";

                cmd.Parameters.Add("@Pfl_Material_ID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Material_ID;
                cmd.Parameters.Add("@SampleID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = SampleID;

                cmd.Parameters.Add("@BoardType", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = BoardType;
                cmd.Parameters.Add("@BoardGSM", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = BoardGSM;
                cmd.Parameters.Add("@IsFSC", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = IsFSC;
                cmd.Parameters.Add("@BoardColor", MySql.Data.MySqlClient.MySqlDbType.String).Value = BoardColor;
                cmd.Parameters.Add("@AdhesiveColor", MySql.Data.MySqlClient.MySqlDbType.String).Value = AdhesiveColor;

                cmd.Parameters.Add("@StoreItemID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = StoreItemID;

                cmd.Parameters.Add("@Quanity", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = Quanity;
                cmd.Parameters.Add("@Unit", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Unit;

                cmd.Parameters.Add("@MahenCode", MySql.Data.MySqlClient.MySqlDbType.String).Value = MahenCode;

                cmd.Parameters.Add("@SupplierID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = SupplierID;
                cmd.Parameters.Add("@BatchID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = BatchID;

                cmd.Parameters.Add("@CreatedBy", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = CreatedBy;

                cmd.Parameters.Add("@CreationDate", MySql.Data.MySqlClient.MySqlDbType.DateTime).Value = CreationDate;
                cmd.Parameters.Add("@Status", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = status;
                cmd.Parameters.Add("@CommandID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = CommandID;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

         public void InsertUpdateOffset_Technical(int Techonical_ID, int SampleID, decimal Overall_Length, decimal Overall_Width, decimal Finished_Length, decimal Finished_Width,
             int Fornt_Side_Color, int Back_Side_Color, int Cutting_Emboss, int Cutting_Debossing, int Die_Cutting, int Punch_hole_size, int Perforation, string KeyEntry1, string KeyEntry2, string KeyEntry3, string KeyEntry4, string KeyEntry5, 
             string KeyEntry6 , string KeyEntry7 , string KeyEntry8 , string KeyEntry9 , string KeyEntry10 ,int CreatedBy , DateTime CreationDate, int status, int CommandID)
         {
             string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
             using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(constr))
             {
                 MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                 cmd.Connection = conn;
                 cmd.CommandText = "CALL InsertUpdateOffset_Technical_proc(@Techonical_ID, @SampleID, @Overall_Length , @Overall_Width , @Finished_Length , @Finished_Width , @Fornt_Side_Color , @Back_Side_Color , @Cutting_Emboss,  @Cutting_Debossing , @Die_Cutting , @Punch_hole_size, @Perforation, @KeyEntry1 ,  @KeyEntry2 , @KeyEntry3, @KeyEntry4, @KeyEntry5 , @KeyEntry6, @KeyEntry7 , @KeyEntry8 ,@KeyEntry9 , @KeyEntry10 , @CreatedBy,@CreationDate,@Status, @CommandID);";

                 cmd.Parameters.Add("@Techonical_ID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Techonical_ID;
                 cmd.Parameters.Add("@SampleID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = SampleID;
                 cmd.Parameters.Add("@Overall_Length", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = Overall_Length;
                 cmd.Parameters.Add("@Overall_Width", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = Overall_Width;


                 cmd.Parameters.Add("@Finished_Length", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = Finished_Length;
                 cmd.Parameters.Add("@Finished_Width", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = Finished_Width;

                 cmd.Parameters.Add("@Fornt_Side_Color", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Fornt_Side_Color;
                 cmd.Parameters.Add("@Back_Side_Color", MySql.Data.MySqlClient.MySqlDbType.Int32).Value =Back_Side_Color;
                 cmd.Parameters.Add("@Cutting_Emboss", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Cutting_Emboss;
                 cmd.Parameters.Add("@Cutting_Debossing", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Cutting_Debossing;
                 cmd.Parameters.Add("@Die_Cutting", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Die_Cutting;
                 cmd.Parameters.Add("@Punch_hole_size", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Punch_hole_size;
                 cmd.Parameters.Add("@Perforation", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Perforation;
                 cmd.Parameters.Add("@KeyEntry1", MySql.Data.MySqlClient.MySqlDbType.String).Value = KeyEntry1;
                 cmd.Parameters.Add("@KeyEntry2", MySql.Data.MySqlClient.MySqlDbType.String).Value = KeyEntry2;
                 
                 cmd.Parameters.Add("@KeyEntry3", MySql.Data.MySqlClient.MySqlDbType.String).Value = KeyEntry3;
                 cmd.Parameters.Add("@KeyEntry4", MySql.Data.MySqlClient.MySqlDbType.String).Value = KeyEntry4;
                 cmd.Parameters.Add("@KeyEntry5", MySql.Data.MySqlClient.MySqlDbType.String).Value = KeyEntry5;

                 cmd.Parameters.Add("@KeyEntry6", MySql.Data.MySqlClient.MySqlDbType.String).Value = KeyEntry6;

                 cmd.Parameters.Add("@KeyEntry7", MySql.Data.MySqlClient.MySqlDbType.String).Value = KeyEntry7;
                 cmd.Parameters.Add("@KeyEntry8", MySql.Data.MySqlClient.MySqlDbType.String).Value = KeyEntry8;
                 cmd.Parameters.Add("@KeyEntry9", MySql.Data.MySqlClient.MySqlDbType.String).Value = KeyEntry9;


                 
                 cmd.Parameters.Add("@KeyEntry10", MySql.Data.MySqlClient.MySqlDbType.String).Value = KeyEntry10;
                   cmd.Parameters.Add("@CreatedBy", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = CreatedBy;
<<<<<<< HEAD
                   cmd.Parameters.Add("@CreationDate", MySql.Data.MySqlClient.MySqlDbType.DateTime).Value = CreationDate;
=======
                 cmd.Parameters.Add("@CreationDate", MySql.Data.MySqlClient.MySqlDbType.Datetime).Value = CreationDate;
>>>>>>> e13348d52d15e4a0a11d272188477b8c7aab4b10
                 cmd.Parameters.Add("@Status", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = status;         

                
                 cmd.Parameters.Add("@CommandID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = CommandID;


                 conn.Open();
                 cmd.ExecuteNonQuery();
             }
         }


    }
}