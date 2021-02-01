using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace FloraSoft
{
    public class IREDB
    {
        public DataTable GetIRE(int RoutingNo, int ClearingType)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);

            SqlDataAdapter myCommand = new SqlDataAdapter("OCE_GetIRE", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.Int, 4);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.SelectCommand.Parameters.Add(parameterRoutingNo);

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
        public void RemoveIRE(int IREID)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("OCE_RemoveIRE", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterIREID = new SqlParameter("@IREID", SqlDbType.Int, 4);
            parameterIREID.Value = IREID;
            myCommand.Parameters.Add(parameterIREID);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }
        public void InsertIREFromOCE(string CheckID, int ReturnCD)
        {
            Guid CheckIDGuid = new Guid(CheckID);
            
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("OCE_InsertIREFromOCE", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier, 50);
            parameterCheckID.Value = CheckIDGuid;
            myCommand.Parameters.Add(parameterCheckID);

            SqlParameter parameterReturnCD = new SqlParameter("@ReturnCD", SqlDbType.Int, 4);
            parameterReturnCD.Value = ReturnCD;
            myCommand.Parameters.Add(parameterReturnCD);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
        public void UpdateIREMissingCheckID()
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("OCE_UpdateIREMissingCheckID", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }
    }
}
