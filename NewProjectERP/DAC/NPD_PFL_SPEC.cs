using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace NewProjectERP.DAC
{
    public class NPD_PFL_SPEC
    {

        public DataTable SearchCommonTbl(string str)
        {
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
              using (MySqlCommand cmd = new MySqlCommand("sp_LOV_proc", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Param", str);
                  using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
     
        public void InsertUpdateBankDetails(int BankID, string BankName, string BranchName, string BankAddress, string Telephone, string ContactPerson, string AccNo,
                                           string SwiftNo, string EMail, int BankType, int CreatedBy, int CommandID)
        {
            //MySqlConnection myConnection = new MySqlConnection(AppVariables.ConStr);
            string myConnection = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(myConnection)) { 

            MySqlCommand myCommand = new MySqlCommand("Com_Insert_Update_Bank_Proc", con);
            myCommand.CommandType = CommandType.StoredProcedure;

            MySqlParameter parameterCompanyID = new MySqlParameter("@BankID", SqlDbType.Int);
            parameterCompanyID.Value = BankID;
            myCommand.Parameters.Add(parameterCompanyID);

            MySqlParameter parameterCompanyName = new MySqlParameter("@BankName", SqlDbType.VarChar);
            parameterCompanyName.Value = BankName;
            myCommand.Parameters.Add(parameterCompanyName);

            MySqlParameter parameterShortName = new MySqlParameter("@BranchName", SqlDbType.VarChar);
            parameterShortName.Value = BranchName;
            myCommand.Parameters.Add(parameterShortName);

            MySqlParameter parameterAddress = new MySqlParameter("@BankAddress", SqlDbType.NVarChar);
            parameterAddress.Value = BankAddress;
            myCommand.Parameters.Add(parameterAddress);

            MySqlParameter parameterPhone = new MySqlParameter("@Telephone", SqlDbType.NVarChar);
            parameterPhone.Value = Telephone;
            myCommand.Parameters.Add(parameterPhone);

            MySqlParameter parameterFax = new MySqlParameter("@ContactPerson", SqlDbType.VarChar);
            parameterFax.Value = ContactPerson;
            myCommand.Parameters.Add(parameterFax);

            MySqlParameter parameterEmail = new MySqlParameter("@AccNo", SqlDbType.NVarChar);
            parameterEmail.Value = AccNo;
            myCommand.Parameters.Add(parameterEmail);

            MySqlParameter parameterWeb = new MySqlParameter("@SwiftNo", SqlDbType.NVarChar);
            parameterWeb.Value = SwiftNo;
            myCommand.Parameters.Add(parameterWeb);

            MySqlParameter parameterDistrict = new MySqlParameter("@EMail", SqlDbType.NVarChar);
            parameterDistrict.Value = EMail;
            myCommand.Parameters.Add(parameterDistrict);

            MySqlParameter parameterPostCode = new MySqlParameter("@BankType", SqlDbType.Int);
            parameterPostCode.Value = BankType;
            myCommand.Parameters.Add(parameterPostCode);

            MySqlParameter parameterUserID = new MySqlParameter("@CreatedBy", SqlDbType.Int);
            parameterUserID.Value = CreatedBy;
            myCommand.Parameters.Add(parameterUserID);

            MySqlParameter parameterCreatedDate = new MySqlParameter("@CreatedDate", SqlDbType.Date);
            parameterCreatedDate.Value = DateTime.Now.Date;
            myCommand.Parameters.Add(parameterCreatedDate);

            MySqlParameter parameterCommandID = new MySqlParameter("@CommandID", SqlDbType.Int);
            parameterCommandID.Value = CommandID;
            myCommand.Parameters.Add(parameterCommandID);

            //myConnection.Open();
            //myCommand.ExecuteNonQuery();
            //myConnection.Close();
            }
        } 
         public void InsertUpdateMaterials(int Material_ID, int SampleID, int StoreItemID, decimal Quanity, int Unit,string MahenCode, int CreatedBy , DateTime CreationDate, int status, int CommandID)
        {
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(constr))
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "CALL InsertUpdate_npd_pfl_materials_proc(@Material_ID ,@SampleID ,@StoreItemID ,@Quanity,@Unit,@MahenCode ,@CreatedBy ,@CreationDate,@Status,@CommandID);";

                cmd.Parameters.Add("@Material_ID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Material_ID;
                cmd.Parameters.Add("@SampleID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = SampleID;
                cmd.Parameters.Add("@StoreItemID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = StoreItemID;


                cmd.Parameters.Add("@Quanity", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = Quanity;
                cmd.Parameters.Add("@Unit", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Unit;



                cmd.Parameters.Add("@MahenCode", MySql.Data.MySqlClient.MySqlDbType.String).Value = MahenCode;
                cmd.Parameters.Add("@CreatedBy", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = CreatedBy;



                cmd.Parameters.Add("@CreationDate", MySql.Data.MySqlClient.MySqlDbType.DateTime).Value = CreationDate;
                cmd.Parameters.Add("@Status", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = status;
                cmd.Parameters.Add("@CommandID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = CommandID;



                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

         public void InsertUpdatepfl_techonical(int Techonical_ID , int SampleID ,decimal  Overall_Length , decimal Overall_Width , decimal Finished_Length , decimal Finished_Width , 
             int Fornt_Side_Color , int Back_Side_Color, string Ribbon_Type , int Ribbon_Color ,decimal Ribbon_Width, int Edge_Quality , int Face_Quality , string Item_Description ,
             int MachineID , int FirstHeatPlateTemp , int SecondHeatPlateTemp , string MachineSpeed , string FinishType ,string FoldingType , string CuringTime , 
             string CuiringTemparature  , string ItemAttributes , string KeyEntry1 , string KeyEntry2 , string KeyEntry3 , string KeyEntry4 , string KeyEntry5, 
             string KeyEntry6 , string KeyEntry7 , string KeyEntry8 , string KeyEntry9 , string KeyEntry10 ,int CreatedBy , DateTime CreationDate, int status, int CommandID)
         {
             string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
             using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(constr))
             {
                 MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                 cmd.Connection = conn;
                 cmd.CommandText = "CALL InsertUpdatePFL_Techonical_proc(@Techonical_ID, @SampleID, @Overall_Length , @Overall_Width , @Finished_Length , @Finished_Width , @Fornt_Side_Color , @Back_Side_Color , @Ribbon_Type,  @Ribbon_Color , @Ribbon_Width , @Edge_Quality, @Face_Quality , @Item_Description ,  @MachineID , @FirstHeatPlateTemp , @SecondHeatPlateTemp , @MachineSpeed ,  @FinishType , @FoldingType , @CuringTime,  @CuiringTemparature , @ItemAttributes, @KeyEntry1 ,  @KeyEntry2 , @KeyEntry3, @KeyEntry4, @KeyEntry5 , @KeyEntry6, @KeyEntry7 , @KeyEntry8 ,@KeyEntry9 , @KeyEntry10 , @CreatedBy,@CreationDate,@Status, @CommandID);";

                 cmd.Parameters.Add("@Techonical_ID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Techonical_ID;
                 cmd.Parameters.Add("@SampleID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = SampleID;
                 cmd.Parameters.Add("@Overall_Length", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = Overall_Length;
                 cmd.Parameters.Add("@Overall_Width", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = Overall_Width;


                 cmd.Parameters.Add("@Finished_Length", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = Finished_Length;
                 cmd.Parameters.Add("@Finished_Width", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = Finished_Width;

                 cmd.Parameters.Add("@Fornt_Side_Color", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Fornt_Side_Color;
                 cmd.Parameters.Add("@Back_Side_Color", MySql.Data.MySqlClient.MySqlDbType.Int32).Value =Back_Side_Color;
                 cmd.Parameters.Add("@Ribbon_Type", MySql.Data.MySqlClient.MySqlDbType.String).Value = Ribbon_Type;
                 cmd.Parameters.Add("@Ribbon_Color", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Ribbon_Color;
                 cmd.Parameters.Add("@Ribbon_Width", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = Ribbon_Width;
                 cmd.Parameters.Add("@Edge_Quality", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Edge_Quality;
                 cmd.Parameters.Add("@Face_Quality", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Face_Quality;


                 cmd.Parameters.Add("@Item_Description", MySql.Data.MySqlClient.MySqlDbType.String).Value = Item_Description;

                 cmd.Parameters.Add("@MachineID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = MachineID;



                 cmd.Parameters.Add("@FirstHeatPlateTemp", MySql.Data.MySqlClient.MySqlDbType.Int32).Value =FirstHeatPlateTemp;
                 cmd.Parameters.Add("@SecondHeatPlateTemp", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = SecondHeatPlateTemp;


                 cmd.Parameters.Add("@MachineSpeed", MySql.Data.MySqlClient.MySqlDbType.String).Value = MachineSpeed;
                 cmd.Parameters.Add("@FinishType", MySql.Data.MySqlClient.MySqlDbType.String).Value = FinishType;
                 cmd.Parameters.Add("@FoldingType", MySql.Data.MySqlClient.MySqlDbType.String).Value = FoldingType;

                 cmd.Parameters.Add("@CuringTime", MySql.Data.MySqlClient.MySqlDbType.String).Value = CuringTime;

                 cmd.Parameters.Add("@CuiringTemparature", MySql.Data.MySqlClient.MySqlDbType.String).Value = CuiringTemparature;
                 cmd.Parameters.Add("@ItemAttributes", MySql.Data.MySqlClient.MySqlDbType.String).Value = ItemAttributes;
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
                 cmd.Parameters.Add("@CreationDate", MySql.Data.MySqlClient.MySqlDbType.Datetime).Value = CreationDate;
                 cmd.Parameters.Add("@Status", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = status;         

                
                 cmd.Parameters.Add("@CommandID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = CommandID;


                 conn.Open();
                 cmd.ExecuteNonQuery();
             }
         }

         public void InsertUpdate_Woven_techonical(int Woven_Techonical_ID, int SampleID, int WarpColor, int WeavingType, string FileName, decimal Pick,
             decimal Cutter, decimal LengthCuttoCut, string DamaskLengh, string Finishedlength, decimal Width, decimal Huk, int StracingInfo, int IroningInfo,
             int UltraSonicCutting, string Wash_Starch_Ironing_Time, decimal PickWheel, string KeyEntry1, string KeyEntry2, string KeyEntry3, string KeyEntry4, string KeyEntry5,
             string KeyEntry6, string KeyEntry7, string KeyEntry8, string KeyEntry9, string KeyEntry10,int StatusID, int CreatedBy, DateTime CreatedDate,  int CommandID)
         {
             string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
             using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(constr))
             {
                 MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                 cmd.Connection = conn;
                 cmd.CommandText = "CALL InsertUpdatenpd_woven_techonical_proc(@Techonical_ID, @SampleID, @WarpColor , @WeavingType , @FileName , @Pick , @Cutter , @LengthCuttoCut, @DamaskLengh,  @Finishedlength , @Width , @Huk, @StracingInfo , @IroningInfo ,  @UltraSonicCutting , @Wash_Starch_Ironing_Time , @PickWheel, @KeyEntry1 ,  @KeyEntry2 , @KeyEntry3, @KeyEntry4, @KeyEntry5 , @KeyEntry6, @KeyEntry7 , @KeyEntry8 ,@KeyEntry9 , @KeyEntry10 , @StatusID,  @CreatedBy,@CreatedDate,@CommandID);";

                 cmd.Parameters.Add("@Techonical_ID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Woven_Techonical_ID;
                 cmd.Parameters.Add("@SampleID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = SampleID;
                 cmd.Parameters.Add("@WarpColor", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = WarpColor;
                 cmd.Parameters.Add("@WeavingType", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = WeavingType;
                 cmd.Parameters.Add("@FileName", MySql.Data.MySqlClient.MySqlDbType.String).Value = FileName;
                 cmd.Parameters.Add("@Pick", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = Pick;
                 cmd.Parameters.Add("@Cutter", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = Cutter;
                 cmd.Parameters.Add("@LengthCuttoCut", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = LengthCuttoCut;
                 cmd.Parameters.Add("@DamaskLengh", MySql.Data.MySqlClient.MySqlDbType.String).Value = DamaskLengh;
                 cmd.Parameters.Add("@Finishedlength", MySql.Data.MySqlClient.MySqlDbType.String).Value = Finishedlength;
                 cmd.Parameters.Add("@Width", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = Width;
                 cmd.Parameters.Add("@Huk", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = Huk;
                 cmd.Parameters.Add("@StracingInfo", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = StracingInfo;
                 cmd.Parameters.Add("@IroningInfo", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = IroningInfo;
                 cmd.Parameters.Add("@UltraSonicCutting", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = UltraSonicCutting;
                 cmd.Parameters.Add("@Wash_Starch_Ironing_Time", MySql.Data.MySqlClient.MySqlDbType.String).Value = Wash_Starch_Ironing_Time;
                 cmd.Parameters.Add("@PickWheel", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = PickWheel;                
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
                  cmd.Parameters.Add("@StatusID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = StatusID;
                 cmd.Parameters.Add("@CreatedBy", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = CreatedBy;
                 cmd.Parameters.Add("@CreatedDate", MySql.Data.MySqlClient.MySqlDbType.Datetime).Value = CreatedDate;  
                 cmd.Parameters.Add("@CommandID", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = CommandID;
                 conn.Open();
                 cmd.ExecuteNonQuery();
             }
         }

         public DataTable DuplicateDateTableWoven(int inBrandID, int inProgramID, decimal inLength, decimal inWidth, int inQuotedPrice, string inImagepath)
         {
             string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
             using (MySqlConnection con = new MySqlConnection(constr))
             {
                 using (MySqlCommand cmd = new MySqlCommand("CHECK_npd_woven_spec_OR_NOT", con))
                 {
                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.AddWithValue("@inBrandID", inBrandID);
                     cmd.Parameters.AddWithValue("@inProgramID", inProgramID);
                     cmd.Parameters.AddWithValue("@inLength", inLength);
                     cmd.Parameters.AddWithValue("@inWidth", inWidth);
                     cmd.Parameters.AddWithValue("@inQuotedPrice", inQuotedPrice);
                     cmd.Parameters.AddWithValue("@inImagepath", inImagepath);
                     using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                     {
                         DataTable dt = new DataTable();
                         sda.Fill(dt);
                         return dt;
                     }
                 }
             }
         }

         public DataTable DuplicateDateTable(int inBrandID, int inProgramID, decimal inLength, decimal inWidth, int inQuotedPrice, string inImagepath)
         {
             string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
             using (MySqlConnection con = new MySqlConnection(constr))
             {
                 using (MySqlCommand cmd = new MySqlCommand("CHECK_npd_pfl_spec_OR_NOT", con))
                 {
                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.AddWithValue("@inBrandID", inBrandID);
                     cmd.Parameters.AddWithValue("@inProgramID", inProgramID);
                     cmd.Parameters.AddWithValue("@inLength", inLength);
                     cmd.Parameters.AddWithValue("@inWidth", inWidth);
                     cmd.Parameters.AddWithValue("@inQuotedPrice", inQuotedPrice);
                     cmd.Parameters.AddWithValue("@inImagepath", inImagepath);
                     using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                     {
                         DataTable dt = new DataTable();
                         sda.Fill(dt);
                         return dt;
                     }
                 }
             }
         }
         public DataTable DuplicateDateTableOffset(int inBrandID, int inProgramID, decimal inLength, decimal inWidth, decimal inPaperGSM, decimal inNoofups, int inQuotedPrice, string inImagepath)
         {
             string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
             using (MySqlConnection con = new MySqlConnection(constr))
             {
                 using (MySqlCommand cmd = new MySqlCommand("CHECK_npd_pfl_spec_OR_NOT", con))
                 {
                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.AddWithValue("@inBrandID", inBrandID);
                     cmd.Parameters.AddWithValue("@inProgramID", inProgramID);
                     cmd.Parameters.AddWithValue("@inLength", inLength);
                     cmd.Parameters.AddWithValue("@inWidth", inWidth);
                     cmd.Parameters.AddWithValue("@inPaperGSM", inPaperGSM);
                     cmd.Parameters.AddWithValue("@inNoofups", inNoofups);
                     cmd.Parameters.AddWithValue("@inQuotedPrice", inQuotedPrice);
                     cmd.Parameters.AddWithValue("@inImagepath", inImagepath);
                     using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                     {
                         DataTable dt = new DataTable();
                         sda.Fill(dt);
                         return dt;
                     }
                 }
             }
         }


         public DataTable WovenDuplicateSampleName(string inSampleName)
         {
             string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
             using (MySqlConnection con = new MySqlConnection(constr))
             {
                 using (MySqlCommand cmd = new MySqlCommand("Chack_Woven_SampleName_pro", con))
                 {
                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.AddWithValue("@inSampleName", inSampleName);
                     using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                     {
                         DataTable dt = new DataTable();
                         sda.Fill(dt);
                         return dt;
                     }
                 }
             }
         }

         public DataTable DuplicateSampleName(string inSampleName)
         {
             string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
             using (MySqlConnection con = new MySqlConnection(constr))
             {
                 using (MySqlCommand cmd = new MySqlCommand("Chack_SampleName_pro", con))
                 {
                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.AddWithValue("@inSampleName", inSampleName);
                     using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                     {
                         DataTable dt = new DataTable();
                         sda.Fill(dt);
                         return dt;
                     }
                 }
             }
         }

         public DataTable DuplicateSampleNameoffset(string inSampleName)
         {
             string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
             using (MySqlConnection con = new MySqlConnection(constr))
             {
                 using (MySqlCommand cmd = new MySqlCommand("Chack_Offset_SampleName_pro", con))
                 {
                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.AddWithValue("@inSampleName", inSampleName);
                     using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                     {
                         DataTable dt = new DataTable();
                         sda.Fill(dt);
                         return dt;
                     }
                 }
             }
         }

    }
}