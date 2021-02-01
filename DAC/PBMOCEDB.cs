using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FloraSoft
{
    public class PBMOCEDB
    {
        public void GenerateOCE(Guid CartID, int UserID, string IPAddress)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr.Replace("ACH","ACHPBM"));
            SqlCommand myCommand = new SqlCommand("ACH_GenerateOCE", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandTimeout = 3600;

            SqlParameter parameterCartID = new SqlParameter("@CartID", SqlDbType.UniqueIdentifier, 50);
            parameterCartID.Value = CartID;
            myCommand.Parameters.Add(parameterCartID);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
            parameterUserID.Value = UserID;
            myCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.VarChar, 20);
            parameterIPAddress.Value = IPAddress;
            myCommand.Parameters.Add(parameterIPAddress);
            
            myConnection.Open();
            myCommand.ExecuteNonQuery();

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

        }
        public SqlDataReader GetOCEFileNames(Guid CartID)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr.Replace("ACH","ACHPBM"));
            SqlCommand myCommand = new SqlCommand("ACH_GetOCEFileNames", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCartID = new SqlParameter("@CartID", SqlDbType.UniqueIdentifier, 50);
            parameterCartID.Value = CartID;
            myCommand.Parameters.Add(parameterCartID);

            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return result;
        }
        public SqlDataReader GetOCEByFileName(string FileName)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr.Replace("ACH","ACHPBM"));
            SqlCommand myCommand = new SqlCommand("ACH_GetOCEByFileName", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandTimeout = 3600;

            SqlParameter parameterFileName = new SqlParameter("@FileName", SqlDbType.VarChar, 80);
            parameterFileName.Value = FileName;
            myCommand.Parameters.Add(parameterFileName);

            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return result;
        }
        public SqlDataReader GetOCEImage(string FileName)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr.Replace("ACH","ACHPBM"));
            SqlCommand myCommand = new SqlCommand("ACH_GetOCEImage", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandTimeout = 3600;

            SqlParameter parameterFileName = new SqlParameter("@FileName", SqlDbType.NVarChar, 80);
            parameterFileName.Value = FileName;
            myCommand.Parameters.Add(parameterFileName);

            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return result;
        }
    }
}
