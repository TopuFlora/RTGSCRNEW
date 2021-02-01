using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace FloraSoft
{
    public class OCEBatchDB
    {
        public DataTable GetBranchBatchList(int RoutingNo)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("OCE_GetBranchBatchList", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.Int);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.SelectCommand.Parameters.Add(parameterRoutingNo);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }

        public DataTable GetBatchChecks(string BatchID)
        {
            Guid BatchIDGuid = new Guid(BatchID);

            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);

            SqlDataAdapter myCommand = new SqlDataAdapter("OCE_GetBatchChecks", myConnection);
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

        public SqlDataReader GetBatchTree(string PageName, int RoutingNo , int ClearingType)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("OCE_GetBatchTree", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterPageName = new SqlParameter("@PageName", SqlDbType.VarChar, 100);
            parameterPageName.Value = PageName;
            myCommand.Parameters.Add(parameterPageName);

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.Int);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.Parameters.Add(parameterRoutingNo);

            SqlParameter parameterClearingType = new SqlParameter("@ClearingType", SqlDbType.Int);
            parameterClearingType.Value = ClearingType;
            myCommand.Parameters.Add(parameterClearingType);

            myConnection.Open();
            SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }

        public void MoveBatch(string BatchID, int RoutingNo)
        {
            Guid BatchIDGuid = new Guid(BatchID);
            
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("OCE_MoveBatch", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterBatchID = new SqlParameter("@BatchID", SqlDbType.UniqueIdentifier, 50);
            parameterBatchID.Value = BatchIDGuid;
            myCommand.Parameters.Add(parameterBatchID);

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.Int, 4);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.Parameters.Add(parameterRoutingNo);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }
        public void ChangeClearingType(string BatchID, int ClearingType)
        {
            Guid BatchIDGuid = new Guid(BatchID);

            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("OCE_ChangeClearingType", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterBatchID = new SqlParameter("@BatchID", SqlDbType.UniqueIdentifier, 50);
            parameterBatchID.Value = BatchIDGuid;
            myCommand.Parameters.Add(parameterBatchID);

            SqlParameter parameterClearingType = new SqlParameter("@ClearingType", SqlDbType.Int, 4);
            parameterClearingType.Value = ClearingType;
            myCommand.Parameters.Add(parameterClearingType);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }
        public void DeleteBatch(string BatchID, int UserID, string IPAddress)
        {
            Guid BatchIDGuid = new Guid(BatchID);

            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("OCE_DeleteBatch", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterBatchID = new SqlParameter("@BatchID", SqlDbType.UniqueIdentifier, 50);
            parameterBatchID.Value = BatchIDGuid;
            myCommand.Parameters.Add(parameterBatchID);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
            parameterUserID.Value = UserID;
            myCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.VarChar, 20);
            parameterIPAddress.Value = IPAddress;
            myCommand.Parameters.Add(parameterIPAddress); 
            
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

        }

        public void ChangeBatchStatus(string BatchID, int StatusID)
        {
            Guid BatchIDGuid = new Guid(BatchID);

            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("OCE_ChangeBatchStatus", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterBatchID = new SqlParameter("@BatchID", SqlDbType.UniqueIdentifier, 50);
            parameterBatchID.Value = BatchIDGuid;
            myCommand.Parameters.Add(parameterBatchID);

            SqlParameter parameterStatusID = new SqlParameter("@StatusID", SqlDbType.Int, 4);
            parameterStatusID.Value = StatusID;
            myCommand.Parameters.Add(parameterStatusID);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }

        public DataTable GetReadyBatches(int ClearingType)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("OCE_GetReadyBatches", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterClearingType = new SqlParameter("@ClearingType", SqlDbType.Int, 4);
            parameterClearingType.Value = ClearingType;
            myCommand.SelectCommand.Parameters.Add(parameterClearingType); 
            
            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public void AddToCart(string BatchID, Guid CartID)
        {
            Guid GuidBatchID = new Guid(BatchID);

            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("OCE_AddToCart", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandTimeout = 3600;

            SqlParameter parameterBatchID = new SqlParameter("@BatchID", SqlDbType.UniqueIdentifier, 50);
            parameterBatchID.Value = GuidBatchID;
            myCommand.Parameters.Add(parameterBatchID);

            SqlParameter parameterCartID = new SqlParameter("@CartID", SqlDbType.UniqueIdentifier, 50);
            parameterCartID.Value = CartID;
            myCommand.Parameters.Add(parameterCartID);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
        public DataTable GetBatchStatus(int RoutingNo, int ClearingType, int Today)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("OCE_GetBatchStatus", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.Int, 4);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.SelectCommand.Parameters.Add(parameterRoutingNo);

            SqlParameter parameterClearingType = new SqlParameter("@ClearingType", SqlDbType.Int, 4);
            parameterClearingType.Value = ClearingType;
            myCommand.SelectCommand.Parameters.Add(parameterClearingType);

            SqlParameter parameterToday = new SqlParameter("@Today", SqlDbType.Bit);
            parameterToday.Value = Today;
            myCommand.SelectCommand.Parameters.Add(parameterToday);

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

