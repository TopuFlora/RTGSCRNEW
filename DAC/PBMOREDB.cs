using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FloraSoft
{
    public class PBMOREDB
    {
        public void GenerateORE(Guid CartID, string LoginID, string IPAddress)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr.Replace("ACH","ACHPBM"));
            SqlCommand myCommand = new SqlCommand("ACH_GenerateORE", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandTimeout = 3600;

            SqlParameter parameterCartID = new SqlParameter("@CartID", SqlDbType.UniqueIdentifier, 50);
            parameterCartID.Value = CartID;
            myCommand.Parameters.Add(parameterCartID);

            SqlParameter parameterLoginID = new SqlParameter("@LoginID", SqlDbType.VarChar, 20);
            parameterLoginID.Value = LoginID;
            myCommand.Parameters.Add(parameterLoginID);

            SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.VarChar, 20);
            parameterIPAddress.Value = IPAddress;
            myCommand.Parameters.Add(parameterIPAddress);
            
            myConnection.Open();
            myCommand.ExecuteNonQuery();

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

        }
        public SqlDataReader GetOREFileNames(Guid CartID)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr.Replace("ACH","ACHPBM"));
            SqlCommand myCommand = new SqlCommand("ACH_GetOREFileNames", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCartID = new SqlParameter("@CartID", SqlDbType.UniqueIdentifier, 50);
            parameterCartID.Value = CartID;
            myCommand.Parameters.Add(parameterCartID);

            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return result;
        }
        public SqlDataReader GetOREByFileName(string FileName)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr.Replace("ACH","ACHPBM"));
            SqlCommand myCommand = new SqlCommand("ACH_GetOREByFileName", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandTimeout = 3600;

            SqlParameter parameterFileName = new SqlParameter("@FileName", SqlDbType.VarChar, 80);
            parameterFileName.Value = FileName;
            myCommand.Parameters.Add(parameterFileName);

            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return result;
        }
    }
}
