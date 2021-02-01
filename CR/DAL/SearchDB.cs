using FloraSoft;
using FloraSoft.CR;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FLoraSoft.CR.DAL 
{
    public class SearchDB
	{
        public DataTable SearchOutwardChargeData(DateTime fromDate, DateTime toDate)
        {
            SqlConnection myConnection = new SqlConnection(AppVariable.ServerLogin);

            SqlDataAdapter myCommand = new SqlDataAdapter("CR_SearchOutwardChargeData", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            myCommand.SelectCommand.Parameters.Add("@FromDate", SqlDbType.Date, 8).Value = fromDate;

            myCommand.SelectCommand.Parameters.Add("@ToDate", SqlDbType.Date, 8).Value = toDate;

            //myCommand.SelectCommand.Parameters.Add("@Type", SqlDbType.VarChar, 30).Value =Type;

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }

        public DataTable SearchOutwardVATData(DateTime fromDate, DateTime toDate)
        {
            SqlConnection myConnection = new SqlConnection(AppVariable.ServerLogin);

            SqlDataAdapter myCommand = new SqlDataAdapter("CR_SearchOutwardVATData", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;


            myCommand.SelectCommand.Parameters.Add("@FromDate", SqlDbType.Date, 8).Value = fromDate;

            myCommand.SelectCommand.Parameters.Add("@ToDate", SqlDbType.Date, 8).Value = toDate;

            //myCommand.SelectCommand.Parameters.Add("@Type", SqlDbType.VarChar, 30).Value = Type;

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

