using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace FloraSoft.CR.DAL
{
    public class WaivedChargeDB
    {
        internal void InsertWaivedCharge(string AccountNumber, int ClearingType, int SCommission, int BankComCont,
            string BankComContACNo, int SVAT, int BankVATCont, string BankVATContACNo, bool BulkEntry, int Status, string UserID)
        {
            SqlConnection myConnection = new SqlConnection(FLoraSoft.CR.DAL.AppVariables.ConStrVVDD);
            SqlCommand myCommand = new SqlCommand("CR_WaivedChargeInsert", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter parameterAccountNumber = new SqlParameter("@AccountNumber", SqlDbType.VarChar);
            parameterAccountNumber.Value = AccountNumber;
            myCommand.Parameters.Add(parameterAccountNumber);

            SqlParameter parameterClearingType = new SqlParameter("@ClearingType", SqlDbType.Int);
            parameterClearingType.Value = ClearingType;
            myCommand.Parameters.Add(parameterClearingType);

            // SqlParameter parameterGHO = new SqlParameter("@GHO", SqlDbType.VarChar);
            //   parameterGHO.Value = GHO;
            //   myCommand.Parameters.Add(parameterGHO);

            SqlParameter parameterSCommission = new SqlParameter("@SCommission", SqlDbType.Int);
            parameterSCommission.Value = SCommission;
            myCommand.Parameters.Add(parameterSCommission);

            SqlParameter parameterBankComCont = new SqlParameter("@BankComCont", SqlDbType.Int);
            parameterBankComCont.Value = BankComCont;
            myCommand.Parameters.Add(parameterBankComCont);

            SqlParameter parameterBankComContACNo = new SqlParameter("@BankComContACNo", SqlDbType.VarChar);
            parameterBankComContACNo.Value = BankComContACNo;
            myCommand.Parameters.Add(parameterBankComContACNo);

            SqlParameter parameterSVAT = new SqlParameter("@SVAT", SqlDbType.Int);
            parameterSVAT.Value = SVAT;
            myCommand.Parameters.Add(parameterSVAT);

            SqlParameter parameterBankVATCont = new SqlParameter("@BankVATCont", SqlDbType.Int);
            parameterBankVATCont.Value = BankVATCont;
            myCommand.Parameters.Add(parameterBankVATCont);

            SqlParameter parameterBankVATContACNo = new SqlParameter("@BankVATContACNo", SqlDbType.VarChar);
            parameterBankVATContACNo.Value = BankVATContACNo;
            myCommand.Parameters.Add(parameterBankVATContACNo);

            SqlParameter parameterBulkEntry = new SqlParameter("@BulkEntry", SqlDbType.Bit);
            parameterBulkEntry.Value = BulkEntry;
            myCommand.Parameters.Add(parameterBulkEntry);

            SqlParameter parameterStatus = new SqlParameter("@Status", SqlDbType.Int);
            parameterStatus.Value = Status;
            myCommand.Parameters.Add(parameterStatus);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.VarChar);
            parameterUserID.Value = UserID;
            myCommand.Parameters.Add(parameterUserID);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }

        internal void UpdateWaivedCharge(int ChargeID, string AccountNumber, int ClearingType, int SCommission,
            int BankComCont, string BankComContACNo, int SVAT, int BankVATCont, string BankVATContACNo, bool BulkEntry,
            int Status)
        {
            SqlConnection myConnection = new SqlConnection(FLoraSoft.CR.DAL.AppVariables.ConStrVVDD);
            SqlCommand myCommand = new SqlCommand("CR_WaivedChargeUpdate", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter parameterChargeID = new SqlParameter("@ChargeID", SqlDbType.Int);
            parameterChargeID.Value = ChargeID;
            myCommand.Parameters.Add(parameterChargeID);

            SqlParameter parameterAccountNumber = new SqlParameter("@AccountNumber", SqlDbType.VarChar);
            parameterAccountNumber.Value = AccountNumber;
            myCommand.Parameters.Add(parameterAccountNumber);

            SqlParameter parameterClearingType = new SqlParameter("@ClearingType", SqlDbType.Int);
            parameterClearingType.Value = ClearingType;
            myCommand.Parameters.Add(parameterClearingType);


            // SqlParameter parameterGHO = new SqlParameter("@GHO", SqlDbType.VarChar);
            //   parameterGHO.Value = GHO;
            //   myCommand.Parameters.Add(parameterGHO);

            SqlParameter parameterSCommission = new SqlParameter("@SCommission", SqlDbType.Int);
            parameterSCommission.Value = SCommission;
            myCommand.Parameters.Add(parameterSCommission);

            SqlParameter parameterBankComCont = new SqlParameter("@BankComCont", SqlDbType.Int);
            parameterBankComCont.Value = BankComCont;
            myCommand.Parameters.Add(parameterBankComCont);

            SqlParameter parameterBankComContACNo = new SqlParameter("@BankComContACNo", SqlDbType.VarChar);
            parameterBankComContACNo.Value = BankComContACNo;
            myCommand.Parameters.Add(parameterBankComContACNo);

            SqlParameter parameterSVAT = new SqlParameter("@SVAT", SqlDbType.Int);
            parameterSVAT.Value = SVAT;
            myCommand.Parameters.Add(parameterSVAT);

            SqlParameter parameterBankVATCont = new SqlParameter("@BankVATCont", SqlDbType.Int);
            parameterBankVATCont.Value = BankVATCont;
            myCommand.Parameters.Add(parameterBankVATCont);

            SqlParameter parameterBankVATContACNo = new SqlParameter("@BankVATContACNo", SqlDbType.VarChar);
            parameterBankVATContACNo.Value = BankVATContACNo;
            myCommand.Parameters.Add(parameterBankVATContACNo);

            SqlParameter parameterBulkEntry = new SqlParameter("@BulkEntry", SqlDbType.Bit);
            parameterBulkEntry.Value = BulkEntry;
            myCommand.Parameters.Add(parameterBulkEntry);

            SqlParameter parameterStatus = new SqlParameter("@Status", SqlDbType.Int);
            parameterStatus.Value = Status;
            myCommand.Parameters.Add(parameterStatus);
            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myConnection.Close();
            }
            catch
            {
                myConnection.Close();
            }
        }

        internal DataTable GetWaivedCharge(int ChargeID)
        {
            SqlConnection myConnection = new SqlConnection(FLoraSoft.CR.DAL.AppVariables.ConStrVVDD);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CR_WaivedChargeSelect", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter parameterChargeID = new SqlParameter("@ChargeID", SqlDbType.Int);
            parameterChargeID.Value = ChargeID;
            myAdapter.SelectCommand.Parameters.Add(parameterChargeID);

            DataTable dt = new DataTable("WaivedCharge");
            myConnection.Open();

            try
            {
                myAdapter.SelectCommand.ExecuteNonQuery();
                myAdapter.Fill(dt);
                myConnection.Close();
                myConnection.Dispose();
            }
            catch
            {
                myConnection.Close();
            }
            return dt;
        }

        internal void DeleteWaivedCharge(int ChargeID, string UserID)
        {
            SqlConnection myConnection = new SqlConnection(FLoraSoft.CR.DAL.AppVariables.ConStrVVDD);
            SqlCommand myCommand = new SqlCommand("CR_WaivedChargeDelete", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterChargeID = new SqlParameter("@ChargeID", SqlDbType.Int);
            parameterChargeID.Value = ChargeID;
            myCommand.Parameters.Add(parameterChargeID);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int);
            parameterUserID.Value = UserID;
            myCommand.Parameters.Add(parameterUserID);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }

        internal DataTable GetWaivedChargeByAc(string AccountNumber)
        {
            SqlConnection myConnection = new SqlConnection(FLoraSoft.CR.DAL.AppVariables.ConStrVVDD);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CR_WaivedChargeSelect", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter parameterAccountNumber = new SqlParameter("@AccountNumber", SqlDbType.VarChar);
            parameterAccountNumber.Value = AccountNumber;
            myAdapter.SelectCommand.Parameters.Add(parameterAccountNumber);

            DataTable dt = new DataTable("WaivedCharge");
            myConnection.Open();

            try
            {
                myAdapter.SelectCommand.ExecuteNonQuery();
                myAdapter.Fill(dt);
                myConnection.Close();
                myConnection.Dispose();
            }
            catch
            {
                myConnection.Close();
            }
            return dt;
        }

        internal DataTable GetWaivedCChargeByStatus(int STATUS)
        {
            SqlConnection myConnection = new SqlConnection(FLoraSoft.CR.DAL.AppVariables.ConStrVVDD);

            SqlDataAdapter myAdapter = new SqlDataAdapter("CR_WaivedChargeSelect", myConnection);
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter parameterSTATUS = new SqlParameter("@STATUS", SqlDbType.Int);
            parameterSTATUS.Value = STATUS;
            myAdapter.SelectCommand.Parameters.Add(parameterSTATUS);

            DataTable dt = new DataTable("WaivedCharge");
            myConnection.Open();

            try
            {
                myAdapter.SelectCommand.ExecuteNonQuery();
                myAdapter.Fill(dt);
                myConnection.Close();
                myConnection.Dispose();
            }
            catch
            {
                myConnection.Close();
            }
            return dt;
        }
        
        internal void UpdateWaivedChargeStatus(int ChargeID)
        {
            SqlConnection myConnection = new SqlConnection(FLoraSoft.CR.DAL.AppVariables.ConStrVVDD);
            SqlCommand myCommand = new SqlCommand("WaivedChargeStatusUpdate", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter parameterChargeID = new SqlParameter("@ChargeID", SqlDbType.Int);
            parameterChargeID.Value = ChargeID;
            myCommand.Parameters.Add(parameterChargeID);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
    }
}