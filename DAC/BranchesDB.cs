using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
namespace FloraSoft
{
	public class BranchesDB
	{
        public DataTable GetBranchesByBankCode(int BankCode)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);

            SqlDataAdapter myCommand = new SqlDataAdapter("ACH_GetBranchesByBankCode", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterBankCode = new SqlParameter("@BankCode", SqlDbType.Int, 4);
            parameterBankCode.Value = BankCode;
            myCommand.SelectCommand.Parameters.Add(parameterBankCode);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public DataTable GetZoneBranchesOfAUser(int UserID)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);

            SqlDataAdapter myCommand = new SqlDataAdapter("ACH_GetZoneBranchesOfAUser", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
            parameterUserID.Value = UserID;
            myCommand.SelectCommand.Parameters.Add(parameterUserID);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }

        public DataTable GetBranchesByZoneID(int zoneID)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);

            SqlDataAdapter myCommand = new SqlDataAdapter("ACH_GetBranchesByZoneID", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterZoneID = new SqlParameter("@ZoneID", SqlDbType.Int, 4);
            parameterZoneID.Value = zoneID;
            myCommand.SelectCommand.Parameters.Add(parameterZoneID);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public SqlDataReader GetBranchesByBankID(int BankID)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ACH_GetBranchesByBankID", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterBankID = new SqlParameter("@BankID", SqlDbType.Int, 4);
            parameterBankID.Value = BankID;
            myCommand.Parameters.Add(parameterBankID);

            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return result;
        }
        public SqlDataReader GetBranchesByClearingHouseID(int ClearingHouseID)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ACH_GetBranchesByClearingHouseID", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterClearingHouseID = new SqlParameter("@ClearingHouseID", SqlDbType.Int, 4);
            parameterClearingHouseID.Value = ClearingHouseID;
            myCommand.Parameters.Add(parameterClearingHouseID);

            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return result;
        }
        public int InsertBranches(int ZoneID, String BranchName, int RoutingNo)
        {
            UserDB user      = new UserDB();
            string EntryHash = user.Encrypt(RoutingNo.ToString() + "AA");

            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ACH_InsertBranch", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterZoneID = new SqlParameter("@ZoneID", SqlDbType.Int, 4);
            parameterZoneID.Value = ZoneID;
            myCommand.Parameters.Add(parameterZoneID);

            SqlParameter parameterBranchName = new SqlParameter("@BranchName", SqlDbType.NVarChar, 50);
            parameterBranchName.Value = BranchName;
            myCommand.Parameters.Add(parameterBranchName);

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.Int, 4);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.Parameters.Add(parameterRoutingNo);

            SqlParameter parameterEntryHash = new SqlParameter("@EntryHash", SqlDbType.NVarChar, 50);
            parameterEntryHash.Value = EntryHash;
            myCommand.Parameters.Add(parameterEntryHash); 
            
            SqlParameter parameterBranchID = new SqlParameter("@BranchID", SqlDbType.Int, 4);
            parameterBranchID.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterBranchID);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            return (int)parameterBranchID.Value;
        }


        //----------------------------------------------------------------------
        // Method UpdateBranches
        //----------------------------------------------------------------------
        public void UpdateBranch(int BranchID, String BranchName, int RoutingNo)
        {
            UserDB user = new UserDB();
            string EntryHash = user.Encrypt(RoutingNo.ToString() + "AA");
            
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ACH_UpdateBranch", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterBranchID = new SqlParameter("@BranchID", SqlDbType.Int, 4);
            parameterBranchID.Value = BranchID;
            myCommand.Parameters.Add(parameterBranchID);

            SqlParameter parameterBranchName = new SqlParameter("@BranchName", SqlDbType.NVarChar, 50);
            parameterBranchName.Value = BranchName;
            myCommand.Parameters.Add(parameterBranchName);

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.Int, 4);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.Parameters.Add(parameterRoutingNo);

            SqlParameter parameterEntryHash = new SqlParameter("@EntryHash", SqlDbType.NVarChar, 50);
            parameterEntryHash.Value = EntryHash;
            myCommand.Parameters.Add(parameterEntryHash); 
            
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
    }
}

