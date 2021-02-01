using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace FloraSoft
{
    public class OCEAckItemDB
    {
        public DataTable GetAckItem(string FileName)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("OCE_GetAckItem", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterFileName = new SqlParameter("@FileName", SqlDbType.VarChar, 80);
            parameterFileName.Value = FileName;
            myCommand.SelectCommand.Parameters.Add(parameterFileName);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }

        public DataTable GetAllBranchInvalidItem(int routingNo)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("OCE_GetAllBranchInvalidItem", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter paramRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.Int, 4);
            paramRoutingNo.Value = routingNo;
            myCommand.SelectCommand.Parameters.Add(paramRoutingNo);


            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public DataTable GetAllInvalidItem()
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("OCE_GetAllInvalidItem", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public void RemoveOCEAckItem(int AckID)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("OCE_RemoveOCEAckItem", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterAckID = new SqlParameter("@AckID", SqlDbType.Int, 4);
            parameterAckID.Value = AckID;
            myCommand.Parameters.Add(parameterAckID);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }
    }
}

