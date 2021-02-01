using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace FloraSoft
{
    public class OREDB
    {
        public DataTable GetORE(int RoutingNo, int ClearingType, int StatusID)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);

            SqlDataAdapter myCommand = new SqlDataAdapter("ICE_GetORE", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.Int, 4);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.SelectCommand.Parameters.Add(parameterRoutingNo);

            SqlParameter parameterClearingType = new SqlParameter("@ClearingType", SqlDbType.Int, 4);
            parameterClearingType.Value = ClearingType;
            myCommand.SelectCommand.Parameters.Add(parameterClearingType);

            SqlParameter parameterStatusID = new SqlParameter("@StatusID", SqlDbType.Int, 4);
            parameterStatusID.Value = StatusID;
            myCommand.SelectCommand.Parameters.Add(parameterStatusID);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public void RemoveORE(int FileID)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ICE_RemoveORE", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterFileID = new SqlParameter("@FileID", SqlDbType.Int, 4);
            parameterFileID.Value = FileID;
            myCommand.Parameters.Add(parameterFileID);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }
        public void InsertOREFromICE(string CheckID)
        {
            Guid CheckIDGuid = new Guid(CheckID);

            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ICE_InsertOREFromICE", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier, 50);
            parameterCheckID.Value = CheckIDGuid;
            myCommand.Parameters.Add(parameterCheckID);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
        public void UpdateOREACK(int FileID, string SettlementDate, int Accepted)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ICE_UpdateOREACK", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterFileID = new SqlParameter("@FileID", SqlDbType.Int, 4);
            parameterFileID.Value = FileID;
            myCommand.Parameters.Add(parameterFileID);

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.VarChar, 8);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.Parameters.Add(parameterSettlementDate);

            SqlParameter parameterAccepted = new SqlParameter("@Accepted", SqlDbType.Int, 4);
            parameterAccepted.Value = Accepted;
            myCommand.Parameters.Add(parameterAccepted); 
                        
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }
    }
}
