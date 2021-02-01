using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace FloraSoft
{
     public class InwardCheckInfo
    {
        public string checkslno = "";
        public string routingno = "";
        public string transcode = "";

        public string LastMaker   = ""; 
        public string LastChecker = "";

        public string signatureimage = "";

        public string totinwclgchecks = "";
        public string checksremainingtoHUB = "";
        public string checksuploadedtoHUB = "";
        public string HUBdealno = "";
        public string ChequeAcceptanceStatus = "";
        public string Remarks = "";

        public string Exception1 = "";
        public string Exception2 = "";
        public string Exception3 = "";

        public string AccountNo = "";
        public string AccountName = "";
        public string AccountType = "";
        public string AccountStatus = "";
        public string AccountRestriction = "";
        public string Amount = "";
        public string RMcode = "";
        public string RMName = "";
        public string RMEmail = "";

        public string SPInstr = "";

        public string PositivepayStatus = "";
        public string PositivepayDate = "";
        public string PositivepayLogger = "";

        public string returncd = "";
        public string discardReason = "";
        public string discardComments = "";

        public string SigningAccountNo = "";
        public string SigningInstrucfor = "";
        public string NumberofSignatures = "";
        public string NumbertoSign = "";
        public string SpecialInstructions = "";
        public string SignatureName = "";
        public string ValidFrom = "";
        public string ValidTo = "";
        public string SigningLimit = "";
        public string SigningInstructions = "";
        public string SigningNote = "";
    }
    public class ICEDB
    {
        public Guid GetNextInwardCheckID(string LoginID, string IPAddress, string CheckID, int QueueID, int NextQueueID, int ParameterID, string DiscardComments)
        {
            Guid CheckIDGuid = new Guid(CheckID);

            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ICE_GetNextInwardCheckID", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterLoginID = new SqlParameter("@LoginID", SqlDbType.VarChar, 20);
            parameterLoginID.Value = LoginID;
            myCommand.Parameters.Add(parameterLoginID);

            SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.VarChar, 50);
            parameterIPAddress.Value = IPAddress;
            myCommand.Parameters.Add(parameterIPAddress); 
           
            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier, 50);
            parameterCheckID.Value = CheckIDGuid;
            myCommand.Parameters.Add(parameterCheckID);

            SqlParameter parameterQueueID = new SqlParameter("@QueueID", SqlDbType.Int, 4);
            parameterQueueID.Value = QueueID;
            myCommand.Parameters.Add(parameterQueueID);

            SqlParameter parameterNextQueueID = new SqlParameter("@NextQueueID", SqlDbType.Int, 4);
            parameterNextQueueID.Value = NextQueueID;
            myCommand.Parameters.Add(parameterNextQueueID);
            
            SqlParameter parameterParameterID = new SqlParameter("@ParameterID", SqlDbType.Int, 4);
            parameterParameterID.Value = ParameterID;
            myCommand.Parameters.Add(parameterParameterID);

            SqlParameter parameterDiscardComments = new SqlParameter("@DiscardComments", SqlDbType.VarChar, 100);
            parameterDiscardComments.Value = DiscardComments;
            myCommand.Parameters.Add(parameterDiscardComments); 
              
            SqlParameter parameterNextCheckID = new SqlParameter("@NextCheckID", SqlDbType.UniqueIdentifier, 50);
            parameterNextCheckID.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterNextCheckID); 
            
            myConnection.Open();
            myCommand.ExecuteNonQuery();

            Guid NextCheckIDGuid = (Guid)parameterNextCheckID.Value;

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

            return NextCheckIDGuid;
        }

        public Guid DiscardAndGetNextInwardCheckID(string LoginID, string IPAddress, string CheckID, int ParameterID, int QueueID, int ReturnCD, string DiscardComments)
        {
            Guid CheckIDGuid = new Guid(CheckID);

            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ICE_DiscardAndGetNextInwardCheckID", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterLoginID = new SqlParameter("@LoginID", SqlDbType.VarChar, 20);
            parameterLoginID.Value = LoginID;
            myCommand.Parameters.Add(parameterLoginID);

            SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.VarChar, 50);
            parameterIPAddress.Value = IPAddress;
            myCommand.Parameters.Add(parameterIPAddress); 
           
            
            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier, 50);
            parameterCheckID.Value = CheckIDGuid;
            myCommand.Parameters.Add(parameterCheckID);

            SqlParameter parameterParameterID = new SqlParameter("@ParameterID", SqlDbType.Int, 4);
            parameterParameterID.Value = ParameterID;
            myCommand.Parameters.Add(parameterParameterID);

            SqlParameter parameterQueueID = new SqlParameter("@QueueID", SqlDbType.Int, 4);
            parameterQueueID.Value = QueueID;
            myCommand.Parameters.Add(parameterQueueID);

            SqlParameter parameterReturnCD = new SqlParameter("@ReturnCD", SqlDbType.TinyInt, 1);
            parameterReturnCD.Value = ReturnCD;
            myCommand.Parameters.Add(parameterReturnCD);

            SqlParameter parameterDiscardComments = new SqlParameter("@DiscardComments", SqlDbType.VarChar, 100);
            parameterDiscardComments.Value = DiscardComments;
            myCommand.Parameters.Add(parameterDiscardComments);

            SqlParameter parameterNextCheckID = new SqlParameter("@NextCheckID", SqlDbType.UniqueIdentifier, 50);
            parameterNextCheckID.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterNextCheckID);

            myConnection.Open();
            myCommand.ExecuteNonQuery();

            Guid NextCheckIDGuid = (Guid)parameterNextCheckID.Value;

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

            return NextCheckIDGuid;
        }
        public DataTable GetBranchStatus(int ECEType)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ICE_GetBranchStatus", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterECEType = new SqlParameter("@ECEType", SqlDbType.TinyInt);
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
        public DataTable GetPreviousReturnHistory(int CheckSLNo, long CheckActNo)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ICE_GetPreviousReturnHistory", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCheckSLNo = new SqlParameter("@CheckSLNo", SqlDbType.Int, 4);
            parameterCheckSLNo.Value = CheckSLNo;
            myCommand.SelectCommand.Parameters.Add(parameterCheckSLNo);

            SqlParameter parameterCheckActNo = new SqlParameter("@CheckActNo", SqlDbType.BigInt, 8);
            parameterCheckActNo.Value = CheckActNo;
            myCommand.SelectCommand.Parameters.Add(parameterCheckActNo);

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
            SqlDataAdapter myCommand = new SqlDataAdapter("ICE_GetBranchStatusHV", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public DataTable GetHUBException(int ReportType, int ECEType)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ICE_GetExceptionReport", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterReportType = new SqlParameter("@ReportType", SqlDbType.Int, 4);
            parameterReportType.Value = ReportType;
            myCommand.SelectCommand.Parameters.Add(parameterReportType);

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
        public DataTable GetHUBAcceptReject(int SettlementDate, int ReportType)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ACH_GetHUBAcceptReject", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.Int, 4);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.SelectCommand.Parameters.Add(parameterSettlementDate); 
            
            SqlParameter parameterReportType = new SqlParameter("@ReportType", SqlDbType.Int, 4);
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
        public DataTable GetHUBORE()
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ICE_GetHUBORE", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public DataTable GetInwardPerformance()
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ICE_GetInwardPerformance", myConnection);
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
            SqlDataAdapter myCommand = new SqlDataAdapter("ICE_GetBranchStatusRV", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public DataTable GetBranchRejectedStatusHV()
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ICE_GetBranchRejectedStatusHV", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public DataTable GetBranchRejectedStatusRV()
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ICE_GetBranchRejectedStatusRV", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return dt;
        }
        public DataTable GetCheckQueue(int RoutingNo, int ECEType)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ICE_GetCheckQueue", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.Int, 4);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.SelectCommand.Parameters.Add(parameterRoutingNo);

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
        public DataTable GetCheckStatus(int RoutingNo, int ECEType)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ICE_GetCheckStatus", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.Int, 4);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.SelectCommand.Parameters.Add(parameterRoutingNo);

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
        public DataTable GetInwardQueueForManual(int ECEType, int CheckSLNo)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ICE_GetInwardQueueForManual", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;
            myCommand.SelectCommand.CommandTimeout = 3600;

            SqlParameter parameterECEType = new SqlParameter("@ECEType", SqlDbType.TinyInt);
            parameterECEType.Value = ECEType;
            myCommand.SelectCommand.Parameters.Add(parameterECEType);

            SqlParameter parameterCheckSLNo = new SqlParameter("@CheckSLNo", SqlDbType.Int);
            parameterCheckSLNo.Value = CheckSLNo;
            myCommand.SelectCommand.Parameters.Add(parameterCheckSLNo);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);
            return dt;
        }
        public DataTable GetInwardQueueBySLNo(int CheckSLNo)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ICE_GetInwardQueueBySLNo", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;
            myCommand.SelectCommand.CommandTimeout = 3600;

            SqlParameter parameterCheckSLNo = new SqlParameter("@CheckSLNo", SqlDbType.Int);
            parameterCheckSLNo.Value = CheckSLNo;
            myCommand.SelectCommand.Parameters.Add(parameterCheckSLNo);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);
            return dt;
        }
        public DataTable GetInwardQueue(int RoleID, int ClearingType, int GHOType, string CheckStatus, string SrchType, string SrchValue)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ICE_GetInwardQueue", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;
            myCommand.SelectCommand.CommandTimeout = 3600;

            SqlParameter parameterRoleID = new SqlParameter("@RoleID", SqlDbType.TinyInt);
            parameterRoleID.Value = RoleID;
            myCommand.SelectCommand.Parameters.Add(parameterRoleID);

            SqlParameter parameterClearingType = new SqlParameter("@ClearingType", SqlDbType.TinyInt);
            parameterClearingType.Value = ClearingType;
            myCommand.SelectCommand.Parameters.Add(parameterClearingType);
            
            SqlParameter parameterGHOType = new SqlParameter("@GHOType", SqlDbType.TinyInt);
            parameterGHOType.Value = GHOType;
            myCommand.SelectCommand.Parameters.Add(parameterGHOType);

            SqlParameter parameterCheckStatus = new SqlParameter("@CheckStatus", SqlDbType.VarChar, 20);
            parameterCheckStatus.Value = CheckStatus;
            myCommand.SelectCommand.Parameters.Add(parameterCheckStatus);

            SqlParameter parameterSrchType = new SqlParameter("@SrchType", SqlDbType.VarChar, 20);
            parameterSrchType.Value = SrchType;
            myCommand.SelectCommand.Parameters.Add(parameterSrchType);

            SqlParameter parameterSrchValue = new SqlParameter("@SrchValue", SqlDbType.VarChar, 20);
            parameterSrchValue.Value = SrchValue;
            myCommand.SelectCommand.Parameters.Add(parameterSrchValue);          

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);
            return dt;
        }
        public DataTable GetReadyBatches(int ECEType)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ICE_GetReadyBatches", myConnection);
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
        public SqlDataReader GetNextInwardCheck(int RoutingNo, int UserID, int ECEType, int TransCode)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ICE_GetNextInwardCheck", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.Int, 4);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.Parameters.Add(parameterRoutingNo);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
            parameterUserID.Value = UserID;
            myCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterECEType = new SqlParameter("@ECEType", SqlDbType.TinyInt);
            parameterECEType.Value = ECEType;
            myCommand.Parameters.Add(parameterECEType);

            SqlParameter parameterTransCode = new SqlParameter("@TransCode", SqlDbType.TinyInt);
            parameterTransCode.Value = TransCode;
            myCommand.Parameters.Add(parameterTransCode);

            myConnection.Open();
            SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }
        public SqlDataReader GetSingleInwardCheck(string CheckID, int UserID, int RoleID)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ICE_GetSingleInwardCheck", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            Guid CheckIDGuid = new Guid(CheckID);

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier, 50);
            parameterCheckID.Value = CheckIDGuid;
            myCommand.Parameters.Add(parameterCheckID);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
            parameterUserID.Value = UserID;
            myCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterRoleID = new SqlParameter("@RoleID", SqlDbType.Int, 4);
            parameterRoleID.Value = RoleID;
            myCommand.Parameters.Add(parameterRoleID);

            myConnection.Open();
            SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }
        public SqlDataReader GetSingleImage(string CheckID)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ICE_GetSingleImage", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            Guid CheckIDGuid = new Guid(CheckID);

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier, 50);
            parameterCheckID.Value = CheckIDGuid;
            myCommand.Parameters.Add(parameterCheckID);

            myConnection.Open();
            SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }
        public SqlDataReader GetSingleInwardCheckForChecker(string CheckID, int UserID)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ICE_GetSingleInwardCheckForChecker", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            Guid CheckIDGuid = new Guid(CheckID);

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier, 50);
            parameterCheckID.Value = CheckIDGuid;
            myCommand.Parameters.Add(parameterCheckID);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
            parameterUserID.Value = UserID;
            myCommand.Parameters.Add(parameterUserID);

            myConnection.Open();
            SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }
        public SqlDataReader GetNextInwardCheckForChecker(int RoutingNo, int UserID, int ECEType, int TransCode)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ICE_GetNextInwardCheckForChecker", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.Int, 4);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.Parameters.Add(parameterRoutingNo);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
            parameterUserID.Value = UserID;
            myCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterECEType = new SqlParameter("@ECEType", SqlDbType.TinyInt);
            parameterECEType.Value = ECEType;
            myCommand.Parameters.Add(parameterECEType);

            SqlParameter parameterTransCode = new SqlParameter("@TransCode", SqlDbType.TinyInt);
            parameterTransCode.Value = TransCode;
            myCommand.Parameters.Add(parameterTransCode);

            myConnection.Open();
            SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }
        public void UpdateByMaker(string CheckID, int ReturnCD, int UserID, string IPAddress)
        {
            Guid CheckIDGuid = new Guid(CheckID);

            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ICE_UpdateByMaker", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier, 50);
            parameterCheckID.Value = CheckIDGuid;
            myCommand.Parameters.Add(parameterCheckID);

            SqlParameter parameterReturnCD = new SqlParameter("@ReturnCD", SqlDbType.Int, 4);
            parameterReturnCD.Value = ReturnCD;
            myCommand.Parameters.Add(parameterReturnCD);

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
        public string ApproveByChecker(string CheckID, string LoginID, string IPAddress)
        {
            Guid CheckIDGuid = new Guid(CheckID);

            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ICE_ApproveByChecker", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier, 50);
            parameterCheckID.Value = CheckIDGuid;
            myCommand.Parameters.Add(parameterCheckID);

            SqlParameter parameterLoginID = new SqlParameter("@LoginID", SqlDbType.VarChar, 50);
            parameterLoginID.Value = LoginID;
            myCommand.Parameters.Add(parameterLoginID);

            SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.VarChar, 20);
            parameterIPAddress.Value = IPAddress;
            myCommand.Parameters.Add(parameterIPAddress);

            SqlParameter parameterNextCheckID = new SqlParameter("@NextCheckID", SqlDbType.UniqueIdentifier, 50);
            parameterNextCheckID.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterNextCheckID);

            myConnection.Open();
            myCommand.ExecuteNonQuery();

            Guid NextCheckIDGuid = (Guid)parameterNextCheckID.Value;

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

            return NextCheckIDGuid.ToString();
        }
        public string HoldByChecker(string CheckID, string RejectedReason, string LoginID, string IPAddress)
        {
            Guid CheckIDGuid = new Guid(CheckID);

            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ICE_HoldByChecker", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier, 50);
            parameterCheckID.Value = CheckIDGuid;
            myCommand.Parameters.Add(parameterCheckID);

            SqlParameter parameterLoginID = new SqlParameter("@LoginID", SqlDbType.VarChar, 50);
            parameterLoginID.Value = LoginID;
            myCommand.Parameters.Add(parameterLoginID);

            SqlParameter parameterRejectedReason = new SqlParameter("@RejectedReason", SqlDbType.VarChar, 100);
            parameterRejectedReason.Value = RejectedReason;
            myCommand.Parameters.Add(parameterRejectedReason);

            SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.VarChar, 20);
            parameterIPAddress.Value = IPAddress;
            myCommand.Parameters.Add(parameterIPAddress);

            SqlParameter parameterNextCheckID = new SqlParameter("@NextCheckID", SqlDbType.UniqueIdentifier, 50);
            parameterNextCheckID.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterNextCheckID);

            myConnection.Open();
            myCommand.ExecuteNonQuery();

            Guid NextCheckIDGuid = (Guid)parameterNextCheckID.Value;

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

            return NextCheckIDGuid.ToString();
        }
        public string ReturnByChecker(string CheckID, string RejectedReason, string LoginID, string IPAddress)
        {
            Guid CheckIDGuid = new Guid(CheckID);

            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ICE_ReturnByChecker", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier, 50);
            parameterCheckID.Value = CheckIDGuid;
            myCommand.Parameters.Add(parameterCheckID);

            SqlParameter parameterRejectedReason = new SqlParameter("@RejectedReason", SqlDbType.VarChar, 100);
            parameterRejectedReason.Value = RejectedReason;
            myCommand.Parameters.Add(parameterRejectedReason);

            SqlParameter parameterLoginID = new SqlParameter("@LoginID", SqlDbType.VarChar, 50);
            parameterLoginID.Value = LoginID;
            myCommand.Parameters.Add(parameterLoginID);

            SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.VarChar, 20);
            parameterIPAddress.Value = IPAddress;
            myCommand.Parameters.Add(parameterIPAddress);

            SqlParameter parameterNextCheckID = new SqlParameter("@NextCheckID", SqlDbType.UniqueIdentifier, 50);
            parameterNextCheckID.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterNextCheckID); 
            
            myConnection.Open();
            myCommand.ExecuteNonQuery();

            Guid NextCheckIDGuid = (Guid)parameterNextCheckID.Value;

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

            return NextCheckIDGuid.ToString();
        }

        public string ReferByChecker(string CheckID, int LevelID, string RejectedReason, string LoginID, string IPAddress)
        {
            Guid CheckIDGuid = new Guid(CheckID);

            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ICE_ReferByChecker", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier, 50);
            parameterCheckID.Value = CheckIDGuid;
            myCommand.Parameters.Add(parameterCheckID);

            SqlParameter parameterLevelID = new SqlParameter("@LevelID", SqlDbType.Int, 4);
            parameterLevelID.Value = LevelID;
            myCommand.Parameters.Add(parameterLevelID);

            SqlParameter parameterRejectedReason = new SqlParameter("@RejectedReason", SqlDbType.VarChar, 100);
            parameterRejectedReason.Value = RejectedReason;
            myCommand.Parameters.Add(parameterRejectedReason);

            SqlParameter parameterLoginID = new SqlParameter("@LoginID", SqlDbType.VarChar, 50);
            parameterLoginID.Value = LoginID;
            myCommand.Parameters.Add(parameterLoginID);

            SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.VarChar, 20);
            parameterIPAddress.Value = IPAddress;
            myCommand.Parameters.Add(parameterIPAddress);

            SqlParameter parameterNextCheckID = new SqlParameter("@NextCheckID", SqlDbType.UniqueIdentifier, 50);
            parameterNextCheckID.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterNextCheckID);

            myConnection.Open();
            myCommand.ExecuteNonQuery();

            Guid NextCheckIDGuid = (Guid)parameterNextCheckID.Value;

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

            return NextCheckIDGuid.ToString();
        }

        public void ChangeQueue(string CheckID, int QueueID, int UserID, string IPAddress)
        {
            Guid CheckIDGuid = new Guid(CheckID);

            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ICE_ChangeQueue", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier, 50);
            parameterCheckID.Value = CheckIDGuid;
            myCommand.Parameters.Add(parameterCheckID);

            SqlParameter parameterQueueID = new SqlParameter("@QueueID", SqlDbType.Int, 4);
            parameterQueueID.Value = QueueID;
            myCommand.Parameters.Add(parameterQueueID);

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

        public void UpdateByAdmin(string CheckID, int returnCD, string LoginID, string IPAddress)
        {
            Guid CheckIDGuid = new Guid(CheckID);

            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ICE_UpdateByAdmin", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier, 50);
            parameterCheckID.Value = CheckIDGuid;
            myCommand.Parameters.Add(parameterCheckID);

            SqlParameter parameterReturnCD = new SqlParameter("@ReturnCD", SqlDbType.Int, 4);
            parameterReturnCD.Value = returnCD;
            myCommand.Parameters.Add(parameterReturnCD);

            SqlParameter parameterLoginID = new SqlParameter("@LoginID", SqlDbType.VarChar, 20);
            parameterLoginID.Value = LoginID;
            myCommand.Parameters.Add(parameterLoginID);

            SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.VarChar, 20);
            parameterIPAddress.Value = IPAddress;
            myCommand.Parameters.Add(parameterIPAddress);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }
        public void AddToCart(string CheckID, Guid CartID)
        {
            Guid GuidCheckID = new Guid(CheckID);

            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ICE_AddToCart", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandTimeout = 3600;

            SqlParameter parameterCheckID = new SqlParameter("@CheckID", SqlDbType.UniqueIdentifier, 50);
            parameterCheckID.Value = GuidCheckID;
            myCommand.Parameters.Add(parameterCheckID);

            SqlParameter parameterCartID = new SqlParameter("@CartID", SqlDbType.UniqueIdentifier, 50);
            parameterCartID.Value = CartID;
            myCommand.Parameters.Add(parameterCartID);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
        public SqlDataReader GetCartICE(string CartID)
        {
            Guid GuidCartID = new Guid(CartID);

            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ICE_GetCartICE", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCartID = new SqlParameter("@CartID", SqlDbType.UniqueIdentifier, 50);
            parameterCartID.Value = GuidCartID;
            myCommand.Parameters.Add(parameterCartID);

            myConnection.Open();
            SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }

        public SqlDataReader GetRejectedInwardListImages(int RoutingNo, bool HV, int TransCode,string SettlementDate)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("[ICE_GetRejectedInwardListImages]", myConnection);
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

            SqlParameter parameterSettlementDate = new SqlParameter("@SettlementDate", SqlDbType.VarChar,8);
            parameterSettlementDate.Value = SettlementDate;
            myCommand.Parameters.Add(parameterSettlementDate);

            myConnection.Open();
            SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }
        public SqlDataReader GetInwardListImages(int RoutingNo, int ECEType, int TransCode)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ICE_GetInwardListImages", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandTimeout = 360;

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.Int, 4);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.Parameters.Add(parameterRoutingNo);

            SqlParameter parameterECEType = new SqlParameter("@ECEType", SqlDbType.TinyInt);
            parameterECEType.Value = ECEType;
            myCommand.Parameters.Add(parameterECEType);

            SqlParameter parameterTransCode = new SqlParameter("@TransCode", SqlDbType.TinyInt);
            parameterTransCode.Value = TransCode;
            myCommand.Parameters.Add(parameterTransCode);
            
            myConnection.Open();
            SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }
        public DataTable GetZoneStatus(int ZoneID, int ECEType)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ICE_GetZoneStatus", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterZoneID = new SqlParameter("@ZoneID", SqlDbType.Int, 4);
            parameterZoneID.Value = ZoneID;
            myCommand.SelectCommand.Parameters.Add(parameterZoneID);

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
        public SqlDataReader GetInwardChequeImages(int ECEType, int StartSLNo)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ICE_GetChequeImages", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterECEType = new SqlParameter("@ECEType", SqlDbType.Int, 4);
            parameterECEType.Value = ECEType;
            myCommand.Parameters.Add(parameterECEType);

            SqlParameter parameterStartSLNo = new SqlParameter("@StartSLNo", SqlDbType.Int, 4);
            parameterStartSLNo.Value = StartSLNo;
            myCommand.Parameters.Add(parameterStartSLNo);

            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return result;
        }
        public void EmptyCart()
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ICE_EmptyCart", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();
        }
    }
}
