using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace FloraSoft
{
    public class ICEImageDB
    {
        public SqlDataReader GetSingleImage(string CheckID)
        {
            Guid CheckIDGuid = new Guid(CheckID);

            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ICE_GetSingleImage", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier, 50);
            parameterCheckID.Value = CheckIDGuid;
            myCommand.Parameters.Add(parameterCheckID);

            myConnection.Open();
            SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }
        public SqlDataReader GetICEImages(bool ClearingType, int StartSLNo)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ICE_GetICEImages", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterClearingType = new SqlParameter("@ClearingType", SqlDbType.Bit, 1);
            parameterClearingType.Value = ClearingType;
            myCommand.Parameters.Add(parameterClearingType);

            SqlParameter parameterStartSLNo = new SqlParameter("@StartSLNo", SqlDbType.Int, 4);
            parameterStartSLNo.Value = StartSLNo;
            myCommand.Parameters.Add(parameterStartSLNo);

            myConnection.Open();

            SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }
        public int GetCheckCount(bool ClearingType)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ICE_GetCheckCount", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterClearingType = new SqlParameter("@ClearingType", SqlDbType.Bit, 1);
            parameterClearingType.Value = ClearingType;
            myCommand.Parameters.Add(parameterClearingType);

            SqlParameter parameterCheckCount = new SqlParameter("@CheckCount", SqlDbType.Int, 4);
            parameterCheckCount.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterCheckCount); 

            myConnection.Open();
            myCommand.ExecuteNonQuery();

            int CheckCount = (int)parameterCheckCount.Value;

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

            return CheckCount;
        }
        public int GetTodaysCheckCount(int ClearingType)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ICE_GetTodaysCheckCount", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterClearingType = new SqlParameter("@ClearingType", SqlDbType.Int, 4);
            parameterClearingType.Value = ClearingType;
            myCommand.Parameters.Add(parameterClearingType);

            SqlParameter parameterCheckCount = new SqlParameter("@CheckCount", SqlDbType.Int, 4);
            parameterCheckCount.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterCheckCount);

            myConnection.Open();
            myCommand.ExecuteNonQuery();

            int CheckCount = (int)parameterCheckCount.Value;

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

            return CheckCount;
        }
        public SqlDataReader GetSingleArcImage(string CheckID)
        {
            Guid CheckIDGuid = new Guid(CheckID);

            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ARC_GetSingleICEImage", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier, 50);
            parameterCheckID.Value = CheckIDGuid;
            myCommand.Parameters.Add(parameterCheckID);

            myConnection.Open();
            SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }
    }
}
