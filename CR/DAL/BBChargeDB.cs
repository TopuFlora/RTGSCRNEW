using FloraSoft;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FLoraSoft.CR.DAL
{

    public class BBChargeDB
    {
        internal SqlDataReader GetBBCharge(int ChargeID)
        {
            SqlConnection myConnection = new SqlConnection(FLoraSoft.CR.DAL.AppVariables.ConStrVVDD);
            SqlCommand myCommand = new SqlCommand("CR_BBChargeSelect", myConnection);
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

        internal void UpdateBBCharge(int ChargeID, string RVBBCharge, string HVBBchage, string RVHBBCharge, int STATUS, string UserID )
        {
            SqlConnection myConnection = new SqlConnection(FLoraSoft.CR.DAL.AppVariables.ConStrVVDD);
            SqlCommand myCommand = new SqlCommand("CR_BBChargeUpdate", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterChargeID = new SqlParameter("@ChargeID", SqlDbType.Int);
            parameterChargeID.Value = ChargeID;
            myCommand.Parameters.Add(parameterChargeID);

            SqlParameter parameterRVBBCharge = new SqlParameter("@RVBBCharge", SqlDbType.Int);
            parameterRVBBCharge.Value = RVBBCharge;
            myCommand.Parameters.Add(parameterRVBBCharge);

            SqlParameter parameterHVBBchage = new SqlParameter("@HVBBchage", SqlDbType.Int);
            parameterHVBBchage.Value = HVBBchage;
            myCommand.Parameters.Add(parameterHVBBchage);

            SqlParameter parameterRVHBBCharge = new SqlParameter("@RVHBBCharge", SqlDbType.Int);
            parameterRVHBBCharge.Value = RVHBBCharge;
            myCommand.Parameters.Add(parameterRVHBBCharge);

            SqlParameter parameterSTATUS = new SqlParameter("@STATUS", SqlDbType.Int);
            parameterSTATUS.Value = STATUS;
            myCommand.Parameters.Add(parameterSTATUS);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.VarChar);
            parameterUserID.Value = UserID;
            myCommand.Parameters.Add(parameterUserID);
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

        internal void UpdateBBChargeStatus(int ChargeID,string UserID)
        {
            SqlConnection myConnection = new SqlConnection(FLoraSoft.CR.DAL.AppVariables.ConStrVVDD);
            SqlCommand myCommand = new SqlCommand("BBChargeStatusUpdate", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterChargeID = new SqlParameter("@ChargeID", SqlDbType.Int);
            parameterChargeID.Value = ChargeID;
            myCommand.Parameters.Add(parameterChargeID);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.VarChar);
            parameterUserID.Value = UserID;
            myCommand.Parameters.Add(parameterUserID);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }

        //public DataTable SearchOutward(FloraSoft.CR.WebForm2.SearchData data)
        //{
        //    SqlConnection myConnection = new SqlConnection(FLoraSoft.CR.DAL.AppVariables.ConStrVVDD);

        //    SqlDataAdapter myCommand = new SqlDataAdapter("SearchOutward", myConnection);
        //    myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

        //    SqlParameter parameterFormID = new SqlParameter("@FormID", SqlDbType.Int, 4);
        //    parameterFormID.Value = data.FormID;
        //    myCommand.SelectCommand.Parameters.Add(parameterFormID);

        //    SqlParameter parameterSenderActNo = new SqlParameter("@SenderActNo", SqlDbType.VarChar, 20);
        //    parameterSenderActNo.Value = data.SenderActNo;
        //    myCommand.SelectCommand.Parameters.Add(parameterSenderActNo);

        //    SqlParameter parameterReceiversAct = new SqlParameter("@ReceiversAct", SqlDbType.VarChar, 20);
        //    parameterReceiversAct.Value = data.ReceiversAct;
        //    myCommand.SelectCommand.Parameters.Add(parameterReceiversAct);

        //    SqlParameter parameterFrSettlementDate = new SqlParameter("@FrSettlementDate", SqlDbType.VarChar, 10);
        //    parameterFrSettlementDate.Value = data.FrSettlementDate;
        //    myCommand.SelectCommand.Parameters.Add(parameterFrSettlementDate);

        //    SqlParameter parameterToSettlementDate = new SqlParameter("@ToSettlementDate", SqlDbType.VarChar, 10);
        //    parameterToSettlementDate.Value = data.ToSettlementDate;
        //    myCommand.SelectCommand.Parameters.Add(parameterToSettlementDate);

        //    SqlParameter parameterDeptID = new SqlParameter("@DeptID", SqlDbType.Int, 4);
        //    parameterDeptID.Value = data.DeptID;
        //    myCommand.SelectCommand.Parameters.Add(parameterDeptID);

        //    SqlParameter parameterBranchID = new SqlParameter("@BranchID", SqlDbType.VarChar, 10);
        //    parameterBranchID.Value = data.BranchID;
        //    myCommand.SelectCommand.Parameters.Add(parameterBranchID);

        //    SqlParameter parameterCCY = new SqlParameter("@CCY", SqlDbType.VarChar, 3);
        //    parameterCCY.Value = data.CCY;
        //    myCommand.SelectCommand.Parameters.Add(parameterCCY);

        //    SqlParameter parameterOtherBank = new SqlParameter("@OtherBank", SqlDbType.VarChar, 8);
        //    parameterOtherBank.Value = data.OtherBank;
        //    myCommand.SelectCommand.Parameters.Add(parameterOtherBank);

        //    SqlParameter parameterComparer = new SqlParameter("@Comparer", SqlDbType.VarChar, 1);
        //    parameterComparer.Value = data.Comparer;
        //    myCommand.SelectCommand.Parameters.Add(parameterComparer);

        //    SqlParameter parameterAmount = new SqlParameter("@Amount", SqlDbType.Money);
        //    parameterAmount.Value = data.Amount;
        //    myCommand.SelectCommand.Parameters.Add(parameterAmount);


        //    myConnection.Open();
        //    DataTable dt = new DataTable();
        //    myCommand.Fill(dt);

        //    myConnection.Close();
        //    myCommand.Dispose();
        //    myConnection.Dispose();

        //    return dt;
        //}

        public DataTable SearchOutwardChargeData(string Outwardid, String FormName)
        {
            SqlConnection myConnection = new SqlConnection(AppVariable.ServerLogin); 
            SqlDataAdapter myCommand = new SqlDataAdapter("VVDD_SearchOutwardChargeData", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            //SqlParameter parameterDeptID = new SqlParameter("@DeptID", SqlDbType.Int, 4);
            //parameterDeptID.Value = DeptID;
            //myCommand.SelectCommand.Parameters.Add(parameterDeptID);

            SqlParameter parameterOutwardid = new SqlParameter("@Outwardid", SqlDbType.VarChar, 30);
            parameterOutwardid.Value = Outwardid;
            myCommand.SelectCommand.Parameters.Add(parameterOutwardid);

            //SqlParameter parameterStatusID = new SqlParameter("@StatusID", SqlDbType.Int, 4);
            //parameterStatusID.Value = StatusID;
            //myCommand.SelectCommand.Parameters.Add(parameterStatusID);

            SqlParameter parameterFormName = new SqlParameter("@FormName", SqlDbType.VarChar, 10);
            parameterFormName.Value = FormName;
            myCommand.SelectCommand.Parameters.Add(parameterFormName);

            myConnection.Open();

            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();
            return dt;
        }

        public DataTable SearchOutwardVATeData(string Outwardid, String FormName)
        {
            SqlConnection myConnection = new SqlConnection(AppVariable.ServerLogin);
            SqlDataAdapter myCommand = new SqlDataAdapter("VVDD_SearchOutwardVATData", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterOutwardid = new SqlParameter("@Outwardid", SqlDbType.VarChar, 30);
            parameterOutwardid.Value = Outwardid;
            myCommand.SelectCommand.Parameters.Add(parameterOutwardid);

            //SqlParameter parameterStatusID = new SqlParameter("@StatusID", SqlDbType.Int, 4);
            //parameterStatusID.Value = StatusID;
            //myCommand.SelectCommand.Parameters.Add(parameterStatusID);

            SqlParameter parameterFormName = new SqlParameter("@FormName", SqlDbType.VarChar, 10);
            parameterFormName.Value = FormName;
            myCommand.SelectCommand.Parameters.Add(parameterFormName);

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