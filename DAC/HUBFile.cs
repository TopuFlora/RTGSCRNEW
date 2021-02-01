using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;

namespace FloraSoft
{
    public class HUBFile
    {
        public string BulkExcelUpload(string fileName, string DestTableName)
        {
            string result = "";
            try
            {
                SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
                myConnection.Open();
                SqlBulkCopy myBulkCopy = new SqlBulkCopy(myConnection);
                myBulkCopy.BulkCopyTimeout = 300;
                myBulkCopy.DestinationTableName = DestTableName;

                DataTable excelDT = new DataTable();
                string excelConnString = @"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + fileName + ";" + "Extended Properties=" + "\"" + "Excel 12.0;HDR=YES;" + "\"";
                OleDbConnection myExcelConn = new OleDbConnection(excelConnString);
                myExcelConn.Open();

                DataTable dbSchema = myExcelConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dbSchema == null || dbSchema.Rows.Count < 1)
                {
                    throw new Exception("Error: Could not determine the name of the first worksheet.");
                }
                string firstSheetName = dbSchema.Rows[0]["TABLE_NAME"].ToString();

                OleDbCommand myCmdExcel = new OleDbCommand();
                myCmdExcel.CommandText = "SELECT * FROM [" + firstSheetName + "]";
                myCmdExcel.Connection = myExcelConn;

                OleDbDataAdapter oda = new OleDbDataAdapter();
                oda.SelectCommand = myCmdExcel;
                oda.Fill(excelDT);

                myExcelConn.Close();

                myBulkCopy.WriteToServer(excelDT);
                myConnection.Close();
            }
            catch (Exception ex)
            {
                result = result + ex.ToString();
            }
            result = result + "Uploaded";
            return result;
        }

        public void ExecuteSQL(string commandText, string databaseName)
        {
            SqlConnection connection = new SqlConnection(AppVariables.DailyConStr(databaseName));
            SqlCommand command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = commandText;

            connection.Open();
            try
            {
                command.ExecuteNonQuery();
            }
            catch 
            {
            }
            command.Dispose();
            connection.Close();
            connection.Dispose();
        }
        public string GetFileName(string SettlementDate, bool IsDay0, string EnvelopType)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("HUB_GetFileName", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.VarChar, 8);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.Parameters.Add(parameterSettlementDate);

            SqlParameter parameterIsDay0 = new SqlParameter("@IsDay0", SqlDbType.Bit);
            parameterIsDay0.Value = IsDay0;
            myCommand.Parameters.Add(parameterIsDay0);

            SqlParameter parameterEnvelopType = new SqlParameter("@EnvelopType", SqlDbType.VarChar, 3);
            parameterEnvelopType.Value = EnvelopType;
            myCommand.Parameters.Add(parameterEnvelopType);

            SqlParameter parameterFileName = new SqlParameter("@FileName", SqlDbType.VarChar, 20);
            parameterFileName.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterFileName);

            myConnection.Open();
            myCommand.ExecuteNonQuery();

            string FileName = (string)parameterFileName.Value;

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

            return FileName;
        }
        public void SetICEExpCheckID()
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("HUB_SetICEExpCheckID", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myConnection.Open();
            myCommand.ExecuteNonQuery();

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }
        public string GetCurDBName()
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ACH_GetCurrentDB", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCurDBName = new SqlParameter("@CurDBName", SqlDbType.VarChar, 11);
            parameterCurDBName.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterCurDBName);

            myConnection.Open();
            myCommand.ExecuteNonQuery();

            string CurDBName = (string)parameterCurDBName.Value;

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
            return CurDBName;
        }
        public SqlDataReader GetOCEData(string SettlementDate, string FlatFileName, bool HV, int DayType)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("HUB_GetOCEData", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.VarChar, 8);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.Parameters.Add(parameterSettlementDate);

            SqlParameter parameterFlatFileName = new SqlParameter("@FlatFileName", SqlDbType.VarChar, 10);
            parameterFlatFileName.Value = FlatFileName;
            myCommand.Parameters.Add(parameterFlatFileName);

            SqlParameter parameterHV = new SqlParameter("@HV", SqlDbType.Bit);
            parameterHV.Value = HV;
            myCommand.Parameters.Add(parameterHV);

            SqlParameter parameterDayType = new SqlParameter("@DayType", SqlDbType.Bit);
            parameterDayType.Value = DayType;
            myCommand.Parameters.Add(parameterDayType); 
            
            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            return result;

        }

        public SqlDataReader GetICEData(string SettlementDate, string FlatFileName, bool HV, bool Regenerate)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("HUB_GetICEData", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.VarChar, 8);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.Parameters.Add(parameterSettlementDate);

            SqlParameter parameterFlatFileName = new SqlParameter("@FlatFileName", SqlDbType.VarChar, 10);
            parameterFlatFileName.Value = FlatFileName;
            myCommand.Parameters.Add(parameterFlatFileName);

            SqlParameter parameterHV = new SqlParameter("@HV", SqlDbType.Bit);
            parameterHV.Value = HV;
            myCommand.Parameters.Add(parameterHV);

            SqlParameter parameterRegenerate = new SqlParameter("@Regenerate", SqlDbType.Bit);
            parameterRegenerate.Value = Regenerate;
            myCommand.Parameters.Add(parameterRegenerate);

            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            return result;
        }

        public SqlDataReader GetOREData(string SettlementDate, string FlatFileName, bool HV)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("HUB_GetOREData", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.VarChar, 8);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.Parameters.Add(parameterSettlementDate);

            SqlParameter parameterFlatFileName = new SqlParameter("@FlatFileName", SqlDbType.VarChar, 10);
            parameterFlatFileName.Value = FlatFileName;
            myCommand.Parameters.Add(parameterFlatFileName);

            SqlParameter parameterHV = new SqlParameter("@HV", SqlDbType.Bit);
            parameterHV.Value = HV;
            myCommand.Parameters.Add(parameterHV);

            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            return result;
        }

        public SqlDataReader GetIREData(string SettlementDate, string FlatFileName, bool HV)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("HUB_GetIREData", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.VarChar, 8);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.Parameters.Add(parameterSettlementDate);

            SqlParameter parameterFlatFileName = new SqlParameter("@FlatFileName", SqlDbType.VarChar, 10);
            parameterFlatFileName.Value = FlatFileName;
            myCommand.Parameters.Add(parameterFlatFileName);

            SqlParameter parameterHV = new SqlParameter("@HV", SqlDbType.Bit);
            parameterHV.Value = HV;
            myCommand.Parameters.Add(parameterHV);

            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            return result;
        }

        public SqlDataReader GetChargeData(string SettlementDate, string FlatFileName, bool HV)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("HUB_GetChargeData", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.VarChar, 8);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.Parameters.Add(parameterSettlementDate);

            SqlParameter parameterFlatFileName = new SqlParameter("@FlatFileName", SqlDbType.VarChar, 10);
            parameterFlatFileName.Value = FlatFileName;
            myCommand.Parameters.Add(parameterFlatFileName);

            SqlParameter parameterHV = new SqlParameter("@HV", SqlDbType.Bit);
            parameterHV.Value = HV;
            myCommand.Parameters.Add(parameterHV);

            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            return result;
        }

        public void InsertHubAccepReject(string FileName, string AccountNumber, string AccountName, string CheckSLNo, 
            string CheckAmount, string SPINARRATIVE, string TRNStatus, string RejectReason)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ACH_InsertHUBAcceptReject", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterFileName = new SqlParameter("@FileName", SqlDbType.VarChar, 18);
            parameterFileName.Value = FileName;
            myCommand.Parameters.Add(parameterFileName);

            SqlParameter parameterAccountNumber = new SqlParameter("@AccountNumber", SqlDbType.VarChar, 18);
            parameterAccountNumber.Value = AccountNumber;
            myCommand.Parameters.Add(parameterAccountNumber);

            SqlParameter parameterAccountName = new SqlParameter("@AccountName", SqlDbType.VarChar, 10);
            parameterAccountName.Value = AccountName;
            myCommand.Parameters.Add(parameterAccountName);

            SqlParameter parameterCheckSLNo = new SqlParameter("@CheckSLNo", SqlDbType.VarChar, 7);
            parameterCheckSLNo.Value = CheckSLNo;
            myCommand.Parameters.Add(parameterCheckSLNo);

            SqlParameter parameterCheckAmount = new SqlParameter("@CheckAmount", SqlDbType.VarChar, 27);
            parameterCheckAmount.Value = CheckAmount;
            myCommand.Parameters.Add(parameterCheckAmount);

            SqlParameter parameterSPINARRATIVE = new SqlParameter("@SPINARRATIVE", SqlDbType.VarChar, 26);
            parameterSPINARRATIVE.Value = SPINARRATIVE;
            myCommand.Parameters.Add(parameterSPINARRATIVE);

            SqlParameter parameterTRNStatus = new SqlParameter("@TRNStatus", SqlDbType.VarChar, 11);
            parameterTRNStatus.Value = TRNStatus;
            myCommand.Parameters.Add(parameterTRNStatus);

            SqlParameter parameterRejectReason = new SqlParameter("@RejectReason", SqlDbType.VarChar, 25);
            parameterRejectReason.Value = RejectReason;
            myCommand.Parameters.Add(parameterRejectReason);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }

        public DataTable GetPastFlatFile(string SettlementDate, int FileType)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("HUB_GetPastFlatFile", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.VarChar, 8);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.SelectCommand.Parameters.Add(parameterSettlementDate);

            SqlParameter parameterFileType = new SqlParameter("@FileType", SqlDbType.Int, 4);
            parameterFileType.Value = FileType;
            myCommand.SelectCommand.Parameters.Add(parameterFileType);
            
            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
    }
}