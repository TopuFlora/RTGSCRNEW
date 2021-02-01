using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace FloraSoft
{
    public class ICEHistoryDB
    {
        public SqlDataReader GetICEHistoryBySLNo(int CheckSLNo)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ICE_GetHistoryBySLNo", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCheckSLNo = new SqlParameter("@CheckSLNo", SqlDbType.Int, 4);
            parameterCheckSLNo.Value = CheckSLNo;
            myCommand.Parameters.Add(parameterCheckSLNo);

            myConnection.Open();
            SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }
    }
}
