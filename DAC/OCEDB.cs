using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace FloraSoft
{
    public class OCEDB
    {
        public DataTable GetBranchStatus(int ClearingType)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("OCE_GetBranchStatus", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterClearingType = new SqlParameter("@ClearingType", SqlDbType.TinyInt);
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
        public DataTable GetBranchStatusHV()
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("OCE_GetBranchStatusHV", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public DataTable GetBranchStatusRV()
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("OCE_GetBranchStatusRV", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public DataTable GetDiscardedCheques(string DiscardType, int ECEType)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("OCE_GetDiscardType", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterDiscardType = new SqlParameter("@DiscardType", SqlDbType.VarChar, 20);
            parameterDiscardType.Value = DiscardType;
            myCommand.SelectCommand.Parameters.Add(parameterDiscardType);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterECEType = new SqlParameter("@ECEType", SqlDbType.Int, 4);
            parameterECEType.Value = ECEType;
            myCommand.SelectCommand.Parameters.Add(parameterECEType);


            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public SqlDataReader GetSingleImage(string CheckID)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("OCE_GetSingleImage", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            Guid CheckIDGuid = new Guid(CheckID);

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier, 50);
            parameterCheckID.Value = CheckIDGuid;
            myCommand.Parameters.Add(parameterCheckID);

            myConnection.Open();
            SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }
        public void DeleteCheck(string CheckID, int UserID, string IPAddress)
        {
            Guid CheckIDGuid = new Guid(CheckID);

            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("OCE_DeleteCheck", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier, 50);
            parameterCheckID.Value = CheckIDGuid;
            myCommand.Parameters.Add(parameterCheckID);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
            parameterUserID.Value = UserID;
            myCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.VarChar, 20);
            parameterIPAddress.Value = IPAddress;
            myCommand.Parameters.Add(parameterIPAddress);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }
        public void EmptyCart()
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("OCE_EmptyCart", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();
        }
        public void ResendCheck(Guid CheckID, int CheckRoutingNo, int CheckSLNo, int CheckTransCode, int RepInd)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("OCE_ResendCheck", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier, 50);
            parameterCheckID.Value = CheckID;
            myCommand.Parameters.Add(parameterCheckID);

            SqlParameter parameterCheckRoutingNo = new SqlParameter("@CheckRoutingNo", SqlDbType.Int, 4);
            parameterCheckRoutingNo.Value = CheckRoutingNo;
            myCommand.Parameters.Add(parameterCheckRoutingNo);

            SqlParameter parameterCheckSLNo = new SqlParameter("@CheckSLNo", SqlDbType.Int, 4);
            parameterCheckSLNo.Value = CheckSLNo;
            myCommand.Parameters.Add(parameterCheckSLNo);

            SqlParameter parameterCheckTransCode = new SqlParameter("@CheckTransCode", SqlDbType.TinyInt);
            parameterCheckTransCode.Value = CheckTransCode;
            myCommand.Parameters.Add(parameterCheckTransCode);

            SqlParameter parameterRepInd = new SqlParameter("@RepInd", SqlDbType.TinyInt);
            parameterRepInd.Value = RepInd;
            myCommand.Parameters.Add(parameterRepInd);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }
        public SqlDataReader GetRejectedOutwardListImages(int RoutingNo, bool HV, int TransCode, string SettlementDate)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("[OCE_GetRejectedOutwardListImages]", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandTimeout = 360;

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.Int, 4);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.Parameters.Add(parameterRoutingNo);

            SqlParameter parameterHV = new SqlParameter("@HV", SqlDbType.Bit);
            parameterHV.Value = HV;
            myCommand.Parameters.Add(parameterHV);

            SqlParameter parameterTransCode = new SqlParameter("@TransCode", SqlDbType.TinyInt);
            parameterTransCode.Value = TransCode;
            myCommand.Parameters.Add(parameterTransCode);

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.VarChar, 8);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.Parameters.Add(parameterSettlementDate);

            myConnection.Open();
            SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }

        public DataTable GetChargeReport(int ECEType, int ReportType, int SearchType, string SearchStr)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("OCE_GetChargeReport", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterECEType = new SqlParameter("@ECEType", SqlDbType.Int, 4);
            parameterECEType.Value = ECEType;
            myCommand.SelectCommand.Parameters.Add(parameterECEType);

            SqlParameter parameterReportType = new SqlParameter("@ReportType", SqlDbType.Int, 4);
            parameterReportType.Value = ReportType;
            myCommand.SelectCommand.Parameters.Add(parameterReportType);

            SqlParameter parameterSearchType = new SqlParameter("@SearchType", SqlDbType.Int, 4);
            parameterSearchType.Value = SearchType;
            myCommand.SelectCommand.Parameters.Add(parameterSearchType);

            SqlParameter parameterSearchStr = new SqlParameter("@SearchStr", SqlDbType.VarChar, 20);
            parameterSearchStr.Value = SearchStr;
            myCommand.SelectCommand.Parameters.Add(parameterSearchStr);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

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

