using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace FloraSoft
{
    public class SettlementDB
    {
        public DataTable GetSettlementSummary(int SettlementDate, int ClearingHouseID, int HV, bool ReportType)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ACH_GetSettlementSummary", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.Int);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.SelectCommand.Parameters.Add(parameterSettlementDate);

            SqlParameter parameterClearingHouseID = new SqlParameter("@ClearingHouseID", SqlDbType.Int);
            parameterClearingHouseID.Value = ClearingHouseID;
            myCommand.SelectCommand.Parameters.Add(parameterClearingHouseID);

            SqlParameter parameterHV = new SqlParameter("@HV", SqlDbType.Int, 4);
            parameterHV.Value = HV;
            myCommand.SelectCommand.Parameters.Add(parameterHV);

            SqlParameter parameterReportType = new SqlParameter("@ReportType", SqlDbType.Bit);
            parameterReportType.Value = ReportType;
            myCommand.SelectCommand.Parameters.Add(parameterReportType);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public DataTable GetBranchSettlementSummaryHRV_S(int SettlementDate)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ACH_GetBranchSettlementSummaryHRV-S", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.Int);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.SelectCommand.Parameters.Add(parameterSettlementDate);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        //public DataTable GetBranchApproval(int RoutingNo)
        //{
        //    SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
        //    SqlDataAdapter myCommand = new SqlDataAdapter("ACH_GetBranchApproval", myConnection);
        //    myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

        //    SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.Int, 4);
        //    parameterRoutingNo.Value = RoutingNo;
        //    myCommand.SelectCommand.Parameters.Add(parameterRoutingNo);

        //    myConnection.Open();
        //    DataTable dt = new DataTable();
        //    myCommand.Fill(dt);

        //    myConnection.Close();
        //    myCommand.Dispose();
        //    myConnection.Dispose();

        //    return dt;
        //}
        public DataTable GetBankSettlementHV()
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ACH_GetBankSettlementHV", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public DataTable GetBankSettlementRV()
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ACH_GetBankSettlementRV", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public DataTable GetBranchSettlement(int ClearingType)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ACH_GetBranchSettlementByClearingType", myConnection);
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
        public DataTable GetBranchSettlementHV()
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ACH_GetBranchSettlementHV", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public DataTable GetBranchSettlementRV()
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ACH_GetBranchSettlementRV", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public DataTable GetSettlement(int SettlementDate, bool ICLType, bool HV, int BankCode, int ClearingHouseID, int RoutingNo, int OtherBankCode, int CheckTransCode, int ReturnType)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);

            SqlDataAdapter myCommand = new SqlDataAdapter("ACH_GetSettlement", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.Int, 4);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.SelectCommand.Parameters.Add(parameterSettlementDate);
            
            SqlParameter parameterICLType = new SqlParameter("@ICLType", SqlDbType.Bit);
            parameterICLType.Value = ICLType;
            myCommand.SelectCommand.Parameters.Add(parameterICLType);

            SqlParameter parameterHV = new SqlParameter("@HV", SqlDbType.Bit);
            parameterHV.Value = HV;
            myCommand.SelectCommand.Parameters.Add(parameterHV);

            SqlParameter parameterBankCode = new SqlParameter("@BankCode", SqlDbType.Int, 4);
            parameterBankCode.Value = BankCode;
            myCommand.SelectCommand.Parameters.Add(parameterBankCode);

            SqlParameter parameterClearingHouseID = new SqlParameter("@ClearingHouseID", SqlDbType.Int, 4);
            parameterClearingHouseID.Value = ClearingHouseID;
            myCommand.SelectCommand.Parameters.Add(parameterClearingHouseID);

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.Int, 4);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.SelectCommand.Parameters.Add(parameterRoutingNo);

            SqlParameter parameterOtherBankCode = new SqlParameter("@OtherBankCode", SqlDbType.Int, 4);
            parameterOtherBankCode.Value = OtherBankCode;
            myCommand.SelectCommand.Parameters.Add(parameterOtherBankCode);

            SqlParameter parameterCheckTransCode = new SqlParameter("@CheckTransCode", SqlDbType.TinyInt);
            parameterCheckTransCode.Value = CheckTransCode;
            myCommand.SelectCommand.Parameters.Add(parameterCheckTransCode);

            SqlParameter parameterReturnType = new SqlParameter("@ReturnType", SqlDbType.TinyInt);
            parameterReturnType.Value = ReturnType;
            myCommand.SelectCommand.Parameters.Add(parameterReturnType);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);
            return dt;
        }

        public DataTable GetCBSSettlement(int SettlementDate, bool ICLType, bool HV, int BankCode, int ClearingHouseID, int RoutingNo, int OtherBankCode, int CheckTransCode, int ReturnType)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);

            SqlDataAdapter myCommand = new SqlDataAdapter("ACH_GetCBSSettlement", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.Int, 4);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.SelectCommand.Parameters.Add(parameterSettlementDate);

            SqlParameter parameterICLType = new SqlParameter("@ICLType", SqlDbType.Bit);
            parameterICLType.Value = ICLType;
            myCommand.SelectCommand.Parameters.Add(parameterICLType);

            SqlParameter parameterHV = new SqlParameter("@HV", SqlDbType.Bit);
            parameterHV.Value = HV;
            myCommand.SelectCommand.Parameters.Add(parameterHV);

            SqlParameter parameterBankCode = new SqlParameter("@BankCode", SqlDbType.Int, 4);
            parameterBankCode.Value = BankCode;
            myCommand.SelectCommand.Parameters.Add(parameterBankCode);

            SqlParameter parameterClearingHouseID = new SqlParameter("@ClearingHouseID", SqlDbType.Int, 4);
            parameterClearingHouseID.Value = ClearingHouseID;
            myCommand.SelectCommand.Parameters.Add(parameterClearingHouseID);

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.Int, 4);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.SelectCommand.Parameters.Add(parameterRoutingNo);

            SqlParameter parameterOtherBankCode = new SqlParameter("@OtherBankCode", SqlDbType.Int, 4);
            parameterOtherBankCode.Value = OtherBankCode;
            myCommand.SelectCommand.Parameters.Add(parameterOtherBankCode);

            SqlParameter parameterCheckTransCode = new SqlParameter("@CheckTransCode", SqlDbType.TinyInt);
            parameterCheckTransCode.Value = CheckTransCode;
            myCommand.SelectCommand.Parameters.Add(parameterCheckTransCode);

            SqlParameter parameterReturnType = new SqlParameter("@ReturnType", SqlDbType.TinyInt);
            parameterReturnType.Value = ReturnType;
            myCommand.SelectCommand.Parameters.Add(parameterReturnType);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);
            return dt;
        }
        public SqlDataReader GetSettlementImages(int SettlementDate, bool ICLType, bool HV, int BankCode, int ClearingHouseID, int RoutingNo, int OtherBankCode, int CheckTransCode, int ReturnType, int StartSLNo)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ACH_GetSettlementImages", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.Int, 4);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.Parameters.Add(parameterSettlementDate);

            SqlParameter parameterICLType = new SqlParameter("@ICLType", SqlDbType.Bit);
            parameterICLType.Value = ICLType;
            myCommand.Parameters.Add(parameterICLType);

            SqlParameter parameterHV = new SqlParameter("@HV", SqlDbType.Bit);
            parameterHV.Value = HV;
            myCommand.Parameters.Add(parameterHV);

            SqlParameter parameterBankCode = new SqlParameter("@BankCode", SqlDbType.Int, 4);
            parameterBankCode.Value = BankCode;
            myCommand.Parameters.Add(parameterBankCode);

            SqlParameter parameterClearingHouseID = new SqlParameter("@ClearingHouseID", SqlDbType.Int, 4);
            parameterClearingHouseID.Value = ClearingHouseID;
            myCommand.Parameters.Add(parameterClearingHouseID);

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.Int, 4);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.Parameters.Add(parameterRoutingNo);

            SqlParameter parameterOtherBankCode = new SqlParameter("@OtherBankCode", SqlDbType.Int, 4);
            parameterOtherBankCode.Value = OtherBankCode;
            myCommand.Parameters.Add(parameterOtherBankCode);

            SqlParameter parameterCheckTransCode = new SqlParameter("@CheckTransCode", SqlDbType.TinyInt);
            parameterCheckTransCode.Value = CheckTransCode;
            myCommand.Parameters.Add(parameterCheckTransCode);

            SqlParameter parameterReturnType = new SqlParameter("@ReturnType", SqlDbType.TinyInt);
            parameterReturnType.Value = ReturnType;
            myCommand.Parameters.Add(parameterReturnType);

            SqlParameter parameterStartSLNo = new SqlParameter("@StartSLNo", SqlDbType.Int, 4);
            parameterStartSLNo.Value = StartSLNo;
            myCommand.Parameters.Add(parameterStartSLNo);

            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return result;
        }
        public DataTable GetOCESettlement(bool HV, int BankCode, int RoutingNo, int OtherBankCode, int CheckTransCode, int ReturnType)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);

            SqlDataAdapter myCommand = new SqlDataAdapter("OCE_GetSettlement", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterHV = new SqlParameter("@HV", SqlDbType.Bit);
            parameterHV.Value = HV;
            myCommand.SelectCommand.Parameters.Add(parameterHV);

            SqlParameter parameterBankCode = new SqlParameter("@BankCode", SqlDbType.Int, 4);
            parameterBankCode.Value = BankCode;
            myCommand.SelectCommand.Parameters.Add(parameterBankCode);

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.Int, 4);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.SelectCommand.Parameters.Add(parameterRoutingNo);

            SqlParameter parameterOtherBankCode = new SqlParameter("@OtherBankCode", SqlDbType.Int, 4);
            parameterOtherBankCode.Value = OtherBankCode;
            myCommand.SelectCommand.Parameters.Add(parameterOtherBankCode);

            SqlParameter parameterCheckTransCode = new SqlParameter("@CheckTransCode", SqlDbType.TinyInt);
            parameterCheckTransCode.Value = CheckTransCode;
            myCommand.SelectCommand.Parameters.Add(parameterCheckTransCode);

            SqlParameter parameterReturnType = new SqlParameter("@ReturnType", SqlDbType.TinyInt);
            parameterReturnType.Value = ReturnType;
            myCommand.SelectCommand.Parameters.Add(parameterReturnType);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);
            return dt;
        }
        public DataTable GetICESettlement(bool HV, int BankCode, int RoutingNo, int OtherBankCode, int CheckTransCode, int ReturnType)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);

            SqlDataAdapter myCommand = new SqlDataAdapter("ICE_GetSettlement", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterHV = new SqlParameter("@HV", SqlDbType.Bit);
            parameterHV.Value = HV;
            myCommand.SelectCommand.Parameters.Add(parameterHV);

            SqlParameter parameterBankCode = new SqlParameter("@BankCode", SqlDbType.Int, 4);
            parameterBankCode.Value = BankCode;
            myCommand.SelectCommand.Parameters.Add(parameterBankCode);

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.Int, 4);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.SelectCommand.Parameters.Add(parameterRoutingNo);

            SqlParameter parameterOtherBankCode = new SqlParameter("@OtherBankCode", SqlDbType.Int, 4);
            parameterOtherBankCode.Value = OtherBankCode;
            myCommand.SelectCommand.Parameters.Add(parameterOtherBankCode);

            SqlParameter parameterCheckTransCode = new SqlParameter("@CheckTransCode", SqlDbType.TinyInt);
            parameterCheckTransCode.Value = CheckTransCode;
            myCommand.SelectCommand.Parameters.Add(parameterCheckTransCode);

            SqlParameter parameterReturnType = new SqlParameter("@ReturnType", SqlDbType.TinyInt);
            parameterReturnType.Value = ReturnType;
            myCommand.SelectCommand.Parameters.Add(parameterReturnType);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);
            return dt;
        }
        public DataTable GetMonthlyCharges(int Month, int Year, int HV, bool ReportType)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ARC_GetMonthlyCharges", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterMonth = new SqlParameter("@Month", SqlDbType.Int);
            parameterMonth.Value = Month;
            myCommand.SelectCommand.Parameters.Add(parameterMonth);

            SqlParameter parameterYear = new SqlParameter("@Year", SqlDbType.Int);
            parameterYear.Value = Year;
            myCommand.SelectCommand.Parameters.Add(parameterYear);

            SqlParameter parameterHV = new SqlParameter("@HV", SqlDbType.Int, 4);
            parameterHV.Value = HV;
            myCommand.SelectCommand.Parameters.Add(parameterHV);

            SqlParameter parameterReportType = new SqlParameter("@ReportType", SqlDbType.Bit);
            parameterReportType.Value = ReportType;
            myCommand.SelectCommand.Parameters.Add(parameterReportType);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public DataTable GetBranchOCEChargeUpload_UCBL(int SettlementDate, int PresRoutingNo)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ACH_GetOCEBranchChargeUpload_UCBL", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.Int, 4);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.SelectCommand.Parameters.Add(parameterSettlementDate);

            SqlParameter parameterPresRoutingNo = new SqlParameter("@PresRoutingNo", SqlDbType.Int, 4);
            parameterPresRoutingNo.Value = PresRoutingNo;
            myCommand.SelectCommand.Parameters.Add(parameterPresRoutingNo);

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

