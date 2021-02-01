using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace FloraSoft
{
    public class AuditDB
    {
        public DataTable SearchOutwardCheckHistory(string LoginID, string CheckActNo, string CheckSLNo, int Day, int Month, int Year)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ACH_SearchOutwardCheckHistory", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterLoginID = new SqlParameter("@LoginID", SqlDbType.VarChar, 50);
            parameterLoginID.Value = LoginID;
            myCommand.SelectCommand.Parameters.Add(parameterLoginID);

            SqlParameter parameterCheckActNo = new SqlParameter("@CheckActNo", SqlDbType.NChar, 13);
            parameterCheckActNo.Value = CheckActNo;
            myCommand.SelectCommand.Parameters.Add(parameterCheckActNo);

            SqlParameter parameterCheckSLNo = new SqlParameter("@CheckSLNo", SqlDbType.NChar, 7);
            parameterCheckSLNo.Value = CheckSLNo;
            myCommand.SelectCommand.Parameters.Add(parameterCheckSLNo);

            SqlParameter parameterDay = new SqlParameter("@Day", SqlDbType.Int, 4);
            parameterDay.Value = Day;
            myCommand.SelectCommand.Parameters.Add(parameterDay);

            SqlParameter parameterMonth = new SqlParameter("@Month", SqlDbType.Int, 4);
            parameterMonth.Value = Month;
            myCommand.SelectCommand.Parameters.Add(parameterMonth);

            SqlParameter parameterYearID = new SqlParameter("@Year", SqlDbType.Int, 4);
            parameterYearID.Value = Year;
            myCommand.SelectCommand.Parameters.Add(parameterYearID);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);
            return dt;
        }
        public DataTable SearchInwardCheckHistory(string LoginID, string CheckActNo, string CheckSLNo, int Day, int Month, int Year)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ACH_SearchInwardCheckHistory", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterLoginID = new SqlParameter("@LoginID", SqlDbType.VarChar, 20);
            parameterLoginID.Value = LoginID;
            myCommand.SelectCommand.Parameters.Add(parameterLoginID);

            SqlParameter parameterCheckActNo = new SqlParameter("@CheckActNo", SqlDbType.NChar, 13);
            parameterCheckActNo.Value = CheckActNo;
            myCommand.SelectCommand.Parameters.Add(parameterCheckActNo);

            SqlParameter parameterCheckSLNo = new SqlParameter("@CheckSLNo", SqlDbType.NChar, 7);
            parameterCheckSLNo.Value = CheckSLNo;
            myCommand.SelectCommand.Parameters.Add(parameterCheckSLNo);

            SqlParameter parameterDay = new SqlParameter("@Day", SqlDbType.Int, 4);
            parameterDay.Value = Day;
            myCommand.SelectCommand.Parameters.Add(parameterDay);

            SqlParameter parameterMonth = new SqlParameter("@Month", SqlDbType.Int, 4);
            parameterMonth.Value = Month;
            myCommand.SelectCommand.Parameters.Add(parameterMonth);

            SqlParameter parameterYearID = new SqlParameter("@Year", SqlDbType.Int, 4);
            parameterYearID.Value = Year;
            myCommand.SelectCommand.Parameters.Add(parameterYearID);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);
            return dt;
        }
    }
}

