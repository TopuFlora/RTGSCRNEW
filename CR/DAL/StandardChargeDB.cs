using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace FLoraSoft.CR.DAL
{
    public class StandardChargeDB
    {

        internal SqlDataReader GetStandardCharge(int ChargeID)
        {
            SqlConnection myConnection = new SqlConnection(FLoraSoft.CR.DAL.AppVariables.ConStrVVDD);
            SqlCommand myCommand = new SqlCommand("CR_StandardChargeSelect", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter parameterChargeID = new SqlParameter("@ChargeID", SqlDbType.Int);
            parameterChargeID.Value = ChargeID;
            myCommand.Parameters.Add(parameterChargeID);
            try
            {
                myConnection.Open();
            }
            catch
            {

            }
            SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }

        internal void UpdateStandardCharge(int ChargeID, int Commission, int VAT,
            string GHO, int STATUS, string UserID)
        {
            SqlConnection myConnection = new SqlConnection(FLoraSoft.CR.DAL.AppVariables.ConStrVVDD);
            SqlCommand myCommand = new SqlCommand("[CR_StandardChargeUpdate]", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter parameterChargeID = new SqlParameter("@ChargeID", SqlDbType.Int);
            parameterChargeID.Value = ChargeID;
            myCommand.Parameters.Add(parameterChargeID);

            SqlParameter parameterCommission = new SqlParameter("@Commission", SqlDbType.Int);
            parameterCommission.Value = Commission;
            myCommand.Parameters.Add(parameterCommission);

            SqlParameter parameterVAT = new SqlParameter("@VAT", SqlDbType.Int);
            parameterVAT.Value = VAT;
            myCommand.Parameters.Add(parameterVAT);

            //SqlParameter parameterClearingType = new SqlParameter("@ClearingType", SqlDbType.Int);
            //parameterClearingType.Value = ClearingType;
            //myCommand.Parameters.Add(parameterClearingType);

            SqlParameter parameterGHO = new SqlParameter("@GHO", SqlDbType.VarChar);
            parameterGHO.Value = GHO;
            myCommand.Parameters.Add(parameterGHO);

            //SqlParameter parameterBulkEntry = new SqlParameter("@BulkEntry", SqlDbType.Bit);
            //parameterBulkEntry.Value = BulkEntry;
            //myCommand.Parameters.Add(parameterBulkEntry);


            SqlParameter parameterSTATUS = new SqlParameter("@STATUS", SqlDbType.Int);
            parameterSTATUS.Value = STATUS;
            myCommand.Parameters.Add(parameterSTATUS);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.VarChar, 15);
            parameterUserID.Value = UserID;
            myCommand.Parameters.Add(parameterUserID);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }

        internal void InsertStandardCharge(int Commission, int VAT, string GHO, int STATUS, string UserID)
        {
            SqlConnection myConnection = new SqlConnection(FLoraSoft.CR.DAL.AppVariables.ConStrVVDD);
            SqlCommand myCommand = new SqlCommand("[CR_StandardChargeInsert]", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCommission = new SqlParameter("@Commission", SqlDbType.Int);
            parameterCommission.Value = Commission;
            myCommand.Parameters.Add(parameterCommission);

            SqlParameter parameterVAT = new SqlParameter("@VAT", SqlDbType.Int);
            parameterVAT.Value = VAT;
            myCommand.Parameters.Add(parameterVAT);

            //SqlParameter parameterClearingType = new SqlParameter("@ClearingType", SqlDbType.Int);
            //parameterClearingType.Value = ClearingType;
            //myCommand.Parameters.Add(parameterClearingType);

            SqlParameter parameterGHO = new SqlParameter("@GHO", SqlDbType.VarChar);
            parameterGHO.Value = GHO;
            myCommand.Parameters.Add(parameterGHO);

            //SqlParameter parameterBulkEntry = new SqlParameter("@BulkEntry", SqlDbType.Bit);
            //parameterBulkEntry.Value = BulkEntry;
            //myCommand.Parameters.Add(parameterBulkEntry);

            SqlParameter parameterSTATUS = new SqlParameter("@STATUS", SqlDbType.Int);
            parameterSTATUS.Value = STATUS;
            myCommand.Parameters.Add(parameterSTATUS);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.VarChar,15);
            parameterUserID.Value = UserID;
            myCommand.Parameters.Add(parameterUserID);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }

        internal void DeleteStandardCharge(int ChargeID,string UserID)
        {
            SqlConnection myConnection = new SqlConnection(FLoraSoft.CR.DAL.AppVariables.ConStrVVDD);
            SqlCommand myCommand = new SqlCommand("[CR_StandardChargeDelete]", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter parameterChargeID = new SqlParameter("@ChargeID", SqlDbType.Int);
            parameterChargeID.Value = ChargeID;
            myCommand.Parameters.Add(parameterChargeID);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.VarChar, 15);
            parameterUserID.Value = UserID;
            myCommand.Parameters.Add(parameterUserID);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }

        internal SqlDataReader GetStandardChargeByGHO(string GHO)
        {
            SqlConnection myConnection = new SqlConnection(FLoraSoft.CR.DAL.AppVariables.ConStrVVDD);
            SqlCommand myCommand = new SqlCommand("[CR_StandardChargeSelect]", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter parameterGHO = new SqlParameter("@GHO", SqlDbType.VarChar,3 );
            parameterGHO.Value = GHO;
            myCommand.Parameters.Add(parameterGHO);
            try
            {
                myConnection.Open();
            }
            catch
            {

            }
            SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
           return dr;
        }

        internal void UpdateStandardChargeStatus(int ChargeID)
        {
            SqlConnection myConnection = new SqlConnection(FLoraSoft.CR.DAL.AppVariables.ConStrVVDD);
            SqlCommand myCommand = new SqlCommand("StandardChargeStatusUpdate", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter parameterChargeID = new SqlParameter("@ChargeID", SqlDbType.Int);
            parameterChargeID.Value = ChargeID;
            myCommand.Parameters.Add(parameterChargeID);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }

        internal void UpdateStandardChargeStatusDisApprove(int ChargeID, bool isDisapprove)
        {
            SqlConnection myConnection = new SqlConnection(FLoraSoft.CR.DAL.AppVariables.ConStrVVDD);
            SqlCommand myCommand = new SqlCommand("StandardChargeStatusUpdate", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            
            SqlParameter parameterChargeID = new SqlParameter("@ChargeID", SqlDbType.Int);
            parameterChargeID.Value = ChargeID;
            myCommand.Parameters.Add(parameterChargeID);

            SqlParameter parameterisDisapprove = new SqlParameter("@isDisapprove", SqlDbType.Bit);
            parameterisDisapprove.Value = isDisapprove;
            myCommand.Parameters.Add(parameterisDisapprove);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();

        }


    }
}