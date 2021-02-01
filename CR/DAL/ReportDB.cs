using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace FloraSoft.CR.DAL
{
    class PacsData
    {
        public string OutwardID = "";
        public string ChargeFileName = "";
        public string VATFileName = "";
        public string Type = "";
    }
    public class ReportDB
    {
        internal System.Data.DataTable GenericChargeReport(DateTime fronDate, DateTime toDate)
        {
            SqlConnection myConnection = new SqlConnection(FLoraSoft.CR.DAL.AppVariables.ConStrVVDD);
            SqlDataAdapter myCommand = new SqlDataAdapter("CR_BankContibution", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            myCommand.SelectCommand.Parameters.Add("@From", SqlDbType.DateTime, 8).Value = fronDate;
            myCommand.SelectCommand.Parameters.Add("@TO", SqlDbType.DateTime, 8).Value = toDate;
            myCommand.SelectCommand.Parameters.Add("@ReportCriteria", SqlDbType.Bit, 1).Value = 1;
            try
            {
                myConnection.Open();
            }
            catch
            {

            }
            DataTable dt = new DataTable();
            myCommand.Fill(dt);
            return dt;
        }

        internal System.Data.DataTable ChargeDeductionReport(DateTime fronDate, DateTime toDate, bool p)
        {
            SqlConnection myConnection = new SqlConnection(FLoraSoft.CR.DAL.AppVariables.ConStrVVDD);
            SqlDataAdapter myCommand = new SqlDataAdapter("CR_CollectedCharge", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            //SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
            //parameterUserID.Value = UserID;
            //myCommand.SelectCommand.Parameters.Add(parameterUserID);

            //SqlParameter parameterMonth = new SqlParameter("@Month", SqlDbType.Int, 4);
            //parameterMonth.Value = Month;
            //myCommand.SelectCommand.Parameters.Add(parameterMonth);

            //SqlParameter parameterYearID = new SqlParameter("@Year", SqlDbType.Int, 4);
            //parameterYearID.Value = Year;
            //myCommand.SelectCommand.Parameters.Add(parameterYearID);
            try
            {
                myConnection.Open();
            }
            catch
            {

            }
            DataTable dt = new DataTable();
            myCommand.Fill(dt);
            return dt;
        }

        internal System.Data.DataTable ChargeRealizationReport(DateTime fronDate, DateTime toDate, bool p)
        {
            SqlConnection myConnection = new SqlConnection(FLoraSoft.CR.DAL.AppVariables.ConStrVVDD);
            SqlDataAdapter myCommand = new SqlDataAdapter("CR_UnCollectedCharge", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            //SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
            //parameterUserID.Value = UserID;
            //myCommand.SelectCommand.Parameters.Add(parameterUserID);

            //SqlParameter parameterMonth = new SqlParameter("@Month", SqlDbType.Int, 4);
            //parameterMonth.Value = Month;
            //myCommand.SelectCommand.Parameters.Add(parameterMonth);

            //SqlParameter parameterYearID = new SqlParameter("@Year", SqlDbType.Int, 4);
            //parameterYearID.Value = Year;
            //myCommand.SelectCommand.Parameters.Add(parameterYearID);
            try
            {
                myConnection.Open();
            }
            catch
            {

            }
            DataTable dt = new DataTable();
            myCommand.Fill(dt);
            return dt;
        }


        internal DataTable SearchUserHistory(DateTime fromDate, DateTime toDate, string chargeType, string activityType, string userId)
        {
            SqlConnection myConnection = new SqlConnection(FLoraSoft.CR.DAL.AppVariables.ConStrVVDD);
            SqlDataAdapter myCommand = new SqlDataAdapter("UserActivityHistorySelect", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            myCommand.SelectCommand.Parameters.Add("@FromDate", SqlDbType.Date, 8).Value = fromDate;

            myCommand.SelectCommand.Parameters.Add("@ToDate", SqlDbType.Date, 8).Value = toDate;

            myCommand.SelectCommand.Parameters.Add("@ChargeType", SqlDbType.VarChar, 30).Value = chargeType;

            myCommand.SelectCommand.Parameters.Add("@ActivityType", SqlDbType.VarChar, 20).Value = activityType;

            myCommand.SelectCommand.Parameters.Add("@UserID", SqlDbType.VarChar, 20).Value = userId;

            try
            {
                myConnection.Open();
            }
            catch
            {

            }
            DataTable dt = new DataTable();
            myCommand.Fill(dt);
            return dt;
        }
        internal DataTable Search(DateTime fromDate, DateTime toDate, string Type, String AccountNo)
        {
            SqlConnection myConnection = new SqlConnection(FLoraSoft.CR.DAL.AppVariables.ConStrVVDD);
            SqlDataAdapter myCommand = new SqlDataAdapter("SearchReportSelect", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            myCommand.SelectCommand.Parameters.Add("@FromDate", SqlDbType.Date, 8).Value = fromDate;

            myCommand.SelectCommand.Parameters.Add("@ToDate", SqlDbType.Date, 8).Value = toDate;

            myCommand.SelectCommand.Parameters.Add("@Type", SqlDbType.VarChar, 30).Value = Type;

            myCommand.SelectCommand.Parameters.Add("@AccountNo", SqlDbType.VarChar, 20).Value = AccountNo;

            //myCommand.SelectCommand.Parameters.Add("@UserID", SqlDbType.VarChar, 20).Value = userId; 

            try
            {
                myConnection.Open();
            }
            catch
            {

            }
            DataTable dt = new DataTable();
            myCommand.Fill(dt);
            return dt;
        }
        internal DataTable SearchforFlatFileGenerate(DateTime fromDate, DateTime toDate, string Type)
        {
            SqlConnection myConnection = new SqlConnection(FLoraSoft.CR.DAL.AppVariables.ConStrVVDD);
            SqlDataAdapter myCommand = new SqlDataAdapter("SearchReportSelectforFlatFile", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            //myCommand.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            myCommand.SelectCommand.Parameters.Add("@FromDate", SqlDbType.Date, 8).Value = fromDate;
            myCommand.SelectCommand.Parameters.Add("@ToDate", SqlDbType.Date, 8).Value = toDate;

            myCommand.SelectCommand.Parameters.Add("@Type", SqlDbType.VarChar, 30).Value = Type;

            // myCommand.SelectCommand.Parameters.Add("@AccountNo", SqlDbType.VarChar, 20).Value = AccountNo;

            //myCommand.SelectCommand.Parameters.Add("@UserID", SqlDbType.VarChar, 20).Value = userId; 

            try
            {
                myConnection.Open();
            }
            catch
            {

            }
            DataTable dt = new DataTable();
            myCommand.Fill(dt);
            return dt;
        }

        internal DataTable FlatFileGenerate(DateTime fromDate, DateTime toDate, string Type)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("RTGS_SearchForFlatFile", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            //myCommand.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            myCommand.SelectCommand.Parameters.Add("@FromDate", SqlDbType.Date, 8).Value = fromDate;
            myCommand.SelectCommand.Parameters.Add("@ToDate", SqlDbType.Date, 8).Value = toDate;

            myCommand.SelectCommand.Parameters.Add("@Type", SqlDbType.VarChar, 30).Value = Type;

            // myCommand.SelectCommand.Parameters.Add("@AccountNo", SqlDbType.VarChar, 20).Value = AccountNo;

            //myCommand.SelectCommand.Parameters.Add("@UserID", SqlDbType.VarChar, 20).Value = userId; 

            try
            {
                myConnection.Open();
            }
            catch
            {

            }
            DataTable dt = new DataTable();
            myCommand.Fill(dt);
            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();
            return dt;
        }
        public DataTable GetUploadList()
        {
            SqlConnection myConnection = new SqlConnection(FLoraSoft.CR.DAL.AppVariables.ConStrVVDD);

            SqlDataAdapter myCommand = new SqlDataAdapter("CRDB_GetUploadList", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }

        //public void UpdateOutwardChargeVatStatus(PacsData data)
        //{
        //    SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
        //    SqlCommand myCommand = new SqlCommand("CR_UpdateOutwardChargeVatStatus", myConnection);
        //    myCommand.CommandType = CommandType.StoredProcedure;

        //    SqlParameter parameterOutwardID = new SqlParameter("@OutwardID", SqlDbType.VarChar, 50);
        //    parameterOutwardID.Value = data.OutwardID;
        //    myCommand.Parameters.Add(parameterOutwardID);

        //    SqlParameter parameterChargeFileName = new SqlParameter("@ChargeFileName", SqlDbType.VarChar, 3);
        //    parameterChargeFileName.Value = data.ChargeFileName;
        //    myCommand.Parameters.Add(parameterChargeFileName);

        //    SqlParameter parameterVATFileName = new SqlParameter("@VATFileName", SqlDbType.VarChar, 50);
        //    parameterVATFileName.Value = data.VATFileName;
        //    myCommand.Parameters.Add(parameterVATFileName);

        //    SqlParameter parameterType = new SqlParameter("@Type", SqlDbType.VarChar, 50);
        //    parameterType.Value = data.Type;
        //    myCommand.Parameters.Add(parameterType);

        //    myConnection.Open();
        //    myCommand.ExecuteNonQuery();

        //    myConnection.Close();
        //    myCommand.Dispose();
        //    myConnection.Dispose();
        //}
    }
}