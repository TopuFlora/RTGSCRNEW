using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace FloraSoft
{
    public class OCEAckDB
    {
        public DataTable GetBatchFileList(string BatchID)
        {
            Guid BatchIDGuid = new Guid(BatchID);

            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("OCE_GetBatchFileList", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterBatchID = new SqlParameter("@BatchID", SqlDbType.UniqueIdentifier, 50);
            parameterBatchID.Value = BatchIDGuid;
            myCommand.SelectCommand.Parameters.Add(parameterBatchID);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public DataTable GetOCEAck(string AckStatus)
        {

            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("OCE_GetAck", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterAckStatus = new SqlParameter("@AckStatus", SqlDbType.VarChar, 20);
            parameterAckStatus.Value = AckStatus;
            myCommand.SelectCommand.Parameters.Add(parameterAckStatus);


            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public DataTable GetAckCount()
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("OCE_GetAckCount", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public void UpdateAck(int FileID, int Run, string SettlementDate, string SettlementTime)
        {

            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("OCE_UpdateACK", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterFileID = new SqlParameter("@FileID", SqlDbType.Int, 4);
            parameterFileID.Value = FileID;
            myCommand.Parameters.Add(parameterFileID); 
            
            SqlParameter parameterRun = new SqlParameter("@Run", SqlDbType.Int, 4);
            parameterRun.Value = Run;
            myCommand.Parameters.Add(parameterRun);

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.VarChar, 8);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.Parameters.Add(parameterSettlementDate);

            SqlParameter parameterSettlementTime = new SqlParameter("@SettlementTime", SqlDbType.VarChar, 4);
            parameterSettlementTime.Value = SettlementTime;
            myCommand.Parameters.Add(parameterSettlementTime);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }
    }
}

