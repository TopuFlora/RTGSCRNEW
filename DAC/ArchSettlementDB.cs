using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
namespace FloraSoft
{
    public class ArchSettlementDB
    {
        public DataTable SearchOCE(int BureauBankCode, int SettlementDate, int RoutingNo, int TransCode, int BankCode, long CheckActNo, int CheckSLNo, long CheckAmount, string Compare)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ARC_SearchOCE", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterBureauBankCode = new SqlParameter("@BureauBankCode", SqlDbType.Int, 4);
            parameterBureauBankCode.Value = BureauBankCode;
            myCommand.SelectCommand.Parameters.Add(parameterBureauBankCode);

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.Int, 4);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.SelectCommand.Parameters.Add(parameterSettlementDate);

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.Int, 4);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.SelectCommand.Parameters.Add(parameterRoutingNo);

            SqlParameter parameterTransCode = new SqlParameter("@TransCode", SqlDbType.Int, 4);
            parameterTransCode.Value = TransCode;
            myCommand.SelectCommand.Parameters.Add(parameterTransCode);

            SqlParameter parameterBankCode = new SqlParameter("@BankCode", SqlDbType.Int, 4);
            parameterBankCode.Value = BankCode;
            myCommand.SelectCommand.Parameters.Add(parameterBankCode);

            SqlParameter parameterCheckActNo = new SqlParameter("@CheckActNo", SqlDbType.BigInt, 16);
            parameterCheckActNo.Value = CheckActNo;
            myCommand.SelectCommand.Parameters.Add(parameterCheckActNo);

            SqlParameter parameterCheckSLNo = new SqlParameter("@CheckSLNo", SqlDbType.Int, 4);
            parameterCheckSLNo.Value = CheckSLNo;
            myCommand.SelectCommand.Parameters.Add(parameterCheckSLNo);

            SqlParameter parameterCheckAmount = new SqlParameter("@CheckAmount", SqlDbType.BigInt, 16);
            parameterCheckAmount.Value = CheckAmount;
            myCommand.SelectCommand.Parameters.Add(parameterCheckAmount);

            SqlParameter parameterCompare = new SqlParameter("@Compare", SqlDbType.Char,1);
            parameterCompare.Value = Compare;
            myCommand.SelectCommand.Parameters.Add(parameterCompare);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);
            return dt;
        }
        public DataTable SearchICE(int BureauBankCode, int SettlementDate, int RoutingNo, int TransCode, int BankCode, long CheckActNo, int CheckSLNo, long CheckAmount, string Compare)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ARC_SearchICE", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterBureauBankCode = new SqlParameter("@BureauBankCode", SqlDbType.Int, 4);
            parameterBureauBankCode.Value = BureauBankCode;
            myCommand.SelectCommand.Parameters.Add(parameterBureauBankCode);

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.Int, 4);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.SelectCommand.Parameters.Add(parameterSettlementDate);

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.Int, 4);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.SelectCommand.Parameters.Add(parameterRoutingNo);

            SqlParameter parameterTransCode = new SqlParameter("@TransCode", SqlDbType.Int, 4);
            parameterTransCode.Value = TransCode;
            myCommand.SelectCommand.Parameters.Add(parameterTransCode);

            SqlParameter parameterBankCode = new SqlParameter("@BankCode", SqlDbType.Int, 4);
            parameterBankCode.Value = BankCode;
            myCommand.SelectCommand.Parameters.Add(parameterBankCode);

            SqlParameter parameterCheckActNo = new SqlParameter("@CheckActNo", SqlDbType.BigInt, 16);
            parameterCheckActNo.Value = CheckActNo;
            myCommand.SelectCommand.Parameters.Add(parameterCheckActNo);

            SqlParameter parameterCheckSLNo = new SqlParameter("@CheckSLNo", SqlDbType.Int, 4);
            parameterCheckSLNo.Value = CheckSLNo;
            myCommand.SelectCommand.Parameters.Add(parameterCheckSLNo);

            SqlParameter parameterCheckAmount = new SqlParameter("@CheckAmount", SqlDbType.BigInt, 16);
            parameterCheckAmount.Value = CheckAmount;
            myCommand.SelectCommand.Parameters.Add(parameterCheckAmount);

            SqlParameter parameterCompare = new SqlParameter("@Compare", SqlDbType.Char, 1);
            parameterCompare.Value = Compare;
            myCommand.SelectCommand.Parameters.Add(parameterCompare);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);
            return dt;
        }
        public DataTable PrintSearchOCE(int BureauBankCode, int SettlementDate, int RoutingNo, int TransCode, int BankCode, long CheckActNo, int CheckSLNo, long CheckAmount)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ARC_SearchPrintOCE", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterBureauBankCode = new SqlParameter("@BureauBankCode", SqlDbType.Int, 4);
            parameterBureauBankCode.Value = BureauBankCode;
            myCommand.SelectCommand.Parameters.Add(parameterBureauBankCode);

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.Int, 4);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.SelectCommand.Parameters.Add(parameterSettlementDate);

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.Int, 4);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.SelectCommand.Parameters.Add(parameterRoutingNo);

            SqlParameter parameterTransCode = new SqlParameter("@TransCode", SqlDbType.Int, 4);
            parameterTransCode.Value = TransCode;
            myCommand.SelectCommand.Parameters.Add(parameterTransCode);

            SqlParameter parameterBankCode = new SqlParameter("@BankCode", SqlDbType.Int, 4);
            parameterBankCode.Value = BankCode;
            myCommand.SelectCommand.Parameters.Add(parameterBankCode);

            SqlParameter parameterCheckActNo = new SqlParameter("@CheckActNo", SqlDbType.BigInt, 16);
            parameterCheckActNo.Value = CheckActNo;
            myCommand.SelectCommand.Parameters.Add(parameterCheckActNo);

            SqlParameter parameterCheckSLNo = new SqlParameter("@CheckSLNo", SqlDbType.Int, 4);
            parameterCheckSLNo.Value = CheckSLNo;
            myCommand.SelectCommand.Parameters.Add(parameterCheckSLNo);

            SqlParameter parameterCheckAmount = new SqlParameter("@CheckAmount", SqlDbType.BigInt, 16);
            parameterCheckAmount.Value = CheckAmount;
            myCommand.SelectCommand.Parameters.Add(parameterCheckAmount);


            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);
            return dt;
        }
        public DataTable PrintSearchICE(int BureauBankCode, int SettlementDate, int RoutingNo, int TransCode, int BankCode, long CheckActNo, int CheckSLNo, long CheckAmount)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ARC_SearchPrintICE", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterBureauBankCode = new SqlParameter("@BureauBankCode", SqlDbType.Int, 4);
            parameterBureauBankCode.Value = BureauBankCode;
            myCommand.SelectCommand.Parameters.Add(parameterBureauBankCode);

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.Int, 4);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.SelectCommand.Parameters.Add(parameterSettlementDate);

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.Int, 4);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.SelectCommand.Parameters.Add(parameterRoutingNo);

            SqlParameter parameterTransCode = new SqlParameter("@TransCode", SqlDbType.Int, 4);
            parameterTransCode.Value = TransCode;
            myCommand.SelectCommand.Parameters.Add(parameterTransCode);

            SqlParameter parameterBankCode = new SqlParameter("@BankCode", SqlDbType.Int, 4);
            parameterBankCode.Value = BankCode;
            myCommand.SelectCommand.Parameters.Add(parameterBankCode);

            SqlParameter parameterCheckActNo = new SqlParameter("@CheckActNo", SqlDbType.BigInt, 16);
            parameterCheckActNo.Value = CheckActNo;
            myCommand.SelectCommand.Parameters.Add(parameterCheckActNo);

            SqlParameter parameterCheckSLNo = new SqlParameter("@CheckSLNo", SqlDbType.Int, 4);
            parameterCheckSLNo.Value = CheckSLNo;
            myCommand.SelectCommand.Parameters.Add(parameterCheckSLNo);

            SqlParameter parameterCheckAmount = new SqlParameter("@CheckAmount", SqlDbType.BigInt, 16);
            parameterCheckAmount.Value = CheckAmount;
            myCommand.SelectCommand.Parameters.Add(parameterCheckAmount);


            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);
            return dt;
        }
        public DataTable GetBankSettlement(int SettlementDate, bool HV)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ARC_GetBankSettlement", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.Int, 4);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.SelectCommand.Parameters.Add(parameterSettlementDate);

            SqlParameter parameterHV = new SqlParameter("@HV", SqlDbType.Bit);
            parameterHV.Value = HV;
            myCommand.SelectCommand.Parameters.Add(parameterHV);

            myConnection.Open();
            DataTable dt = new DataTable();
            try
            {
                myCommand.Fill(dt);
            }
            catch
            {
            }

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public DataTable GetBranchSettlement(int SettlementDate, bool HV)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ARC_GetBranchSettlement", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.Int, 4);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.SelectCommand.Parameters.Add(parameterSettlementDate);

            SqlParameter parameterHV = new SqlParameter("@HV", SqlDbType.Bit);
            parameterHV.Value = HV;
            myCommand.SelectCommand.Parameters.Add(parameterHV);

            myConnection.Open();
            DataTable dt = new DataTable();
            try
            {
                myCommand.Fill(dt);
            }
            catch
            {
            }

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public DataTable GetOCESettlement(bool HV, int SettlementDate, int BankCode, int RoutingNo, int OtherBankCode, int CheckTransCode, int ReturnType)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);

            SqlDataAdapter myCommand = new SqlDataAdapter("ARC_GetOCESettlement", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterHV = new SqlParameter("@HV", SqlDbType.Bit);
            parameterHV.Value = HV;
            myCommand.SelectCommand.Parameters.Add(parameterHV);

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.Int, 4);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.SelectCommand.Parameters.Add(parameterSettlementDate);

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
            try
            {
                myCommand.Fill(dt);
            }
            catch
            {
            }
            return dt;
        }
        public DataTable GetICESettlement(bool HV, int SettlementDate, int BankCode, int RoutingNo, int OtherBankCode, int CheckTransCode, int ReturnType)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);

            SqlDataAdapter myCommand = new SqlDataAdapter("ARC_GetICESettlement", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterHV = new SqlParameter("@HV", SqlDbType.Bit);
            parameterHV.Value = HV;
            myCommand.SelectCommand.Parameters.Add(parameterHV);

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.Int, 4);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.SelectCommand.Parameters.Add(parameterSettlementDate);

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
            try
            {
                myCommand.Fill(dt);
            }
            catch
            {
            }
            return dt;
        }
    }
}

