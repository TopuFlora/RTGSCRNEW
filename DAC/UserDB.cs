using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace FloraSoft
{
    public class UserInfo
    {
        public string UserID;
        public string ZoneID;
        public string BranchID;
        public string RoutingNo;
        public string BankCode;
        public string UserName;
        public string RoleName;
        public string BranchName;
        public string BankName;
        public string RoleCount;
        public string RoleID;
        public string RoleCD;
        public string DeptID;
        public bool AllBranch;
        public decimal TransLimit;
        public string DeptName;
        public int DaysRemaining;
        public bool ChangePwdNow;
        public string ExpMsg;
    }
    public class PasswordPolicy
    {
        public  string PasswordPolicyTest(string Pwd, int UserID)
        {
            string result = IsMinSixDigits(Pwd);
            if (result != "OK")
            {
                return result;
            }
            result = IsNotSameAsLoginID(Pwd, UserID);
            if (result != "OK")
            {
                return result;
            }
            result = IsAlphaNumeric(Pwd);
            if (result != "OK")
            {
                return result;
            }
            result = IsRepeatingOldPassword(Pwd, UserID);
            if (result != "OK")
            {
                return result;
            }
            return "OK";
        }
        public string IsNotSameAsLoginID(string Pwd, int UserID)
        {
            UserDB user = new UserDB();
            string LoginID = "";
            SqlDataReader dr = user.GetSingleUser(UserID);
            while (dr.Read())
            {
                LoginID = (string)dr["LoginID"];
            }
            dr.Close();
            dr.Dispose();

            if (LoginID != Pwd)
            {
                return "OK";
            }
            else
            {
                return "Your Password can not be the same as your LoginID";
            }
        }
        public string IsExpiring(int DaysPassedSinceLastChange)
        {
            if (DaysPassedSinceLastChange > 89)
            {
                return "Your Password has expired. Please contact Administrator.";
            }
            if (DaysPassedSinceLastChange > 84)
            {
                return "Your Password will expire in " + (90 - DaysPassedSinceLastChange).ToString() + " day(s). Please change your password ASAP.";
            }
            return "OK";
        }
        private string IsMinSixDigits(string Pwd)
        {
            if (Pwd.Length > 5)
            {
                return "OK";
            }
            else
            {
                return "Password must be atleast 6 characters.";
            }
        }
        private string IsAlphaNumeric(string Pwd)
        {
            string alphaLow = "abcdefghijklmnopqrtuvwxyz";
            string alphaUp  = "ABCDEFGHIJKLMNOPQRTUVWXYZ";
            string numeric  = "0123456789";
            string special  = "~!@#$%^&*";
            char[] p = Pwd.ToCharArray();

            bool AlphaLowFound = false;
            bool AlphaUpFound  = false;
            bool NumFound      = false;
            bool SpFound       = false;

            foreach (char c in p)
            {
                if (alphaLow.IndexOf(c) != -1)
                {
                    AlphaLowFound = true;
                }
                if (alphaUp.IndexOf(c) != -1)
                {
                    AlphaUpFound = true;
                } 
                if (numeric.IndexOf(c) != -1)
                {
                    NumFound = true;
                }
                if (special.IndexOf(c) != -1)
                {
                    SpFound = true;
                }
            }
            if ((AlphaLowFound) && (AlphaUpFound) && (NumFound) && (SpFound))
            {
                return "OK";
            }
            else
            {
                return "Password must contain both Alpha (both lower and upper case) and Numeric and Special Characters.";
            }
        }
        private string IsRepeatingOldPassword(string Pwd, int UserID)
        {
            bool repeating = false;
            UserDB user   = new UserDB();
            string NewPwd = user.Encrypt(Pwd);

            SqlDataReader dr = GetLast3Passwords(UserID);
            while(dr.Read())
            {
                if (NewPwd == (string) dr["Password"])
                {
                    repeating = true;
                }
            }
            dr.Close();
            dr.Dispose();

            if (repeating)
            {
                return "Can not use the same password that you have used during the last 4 changes.";
            }
            else
            {
                return "OK";
            }
        }
        private SqlDataReader GetLast3Passwords(int UserID)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ACH_GetLast3Passwords", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int);
            parameterUserID.Value = UserID;
            myCommand.Parameters.Add(parameterUserID);

            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return result;
        }
    }
    public class UserDB
    {
        public UserInfo Login(string LoginID)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ACH_UserLogin", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterLoginID = new SqlParameter("@LoginID", SqlDbType.NVarChar, 50);
            parameterLoginID.Value = LoginID;
            myCommand.Parameters.Add(parameterLoginID);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
            parameterUserID.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterZoneID = new SqlParameter("@ZoneID", SqlDbType.Int, 4);
            parameterZoneID.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterZoneID);

            SqlParameter parameterBranchID = new SqlParameter("@BranchID", SqlDbType.Int, 4);
            parameterBranchID.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterBranchID);

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.Int, 4);
            parameterRoutingNo.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterRoutingNo);

            SqlParameter parameterUserName = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
            parameterUserName.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterUserName);

            SqlParameter parameterBranchName = new SqlParameter("@BranchName", SqlDbType.NVarChar, 50);
            parameterBranchName.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterBranchName);

            SqlParameter parameterBankCode = new SqlParameter("@BankCode", SqlDbType.NVarChar, 3);
            parameterBankCode.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterBankCode);

            SqlParameter parameterBankName = new SqlParameter("@BankName", SqlDbType.NVarChar, 50);
            parameterBankName.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterBankName);


            myConnection.Open();
            myCommand.ExecuteNonQuery();

            UserInfo ui = new UserInfo();

            ui.UserID = parameterUserID.Value.ToString();

            ui.ZoneID = parameterZoneID.Value.ToString();
            ui.BranchID = parameterBranchID.Value.ToString();
            ui.RoutingNo = parameterRoutingNo.Value.ToString();

            ui.BankCode = (string)parameterBankCode.Value;
            ui.UserName = (string)parameterUserName.Value;
            ui.BranchName = (string)parameterBranchName.Value;
            ui.BankName = (string)parameterBankName.Value;


            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

            //string ContraHash = Encrypt(ui.UserID.ToString().PadLeft(3, '0') + ui.RoleID.ToString().PadLeft(3, '0') + ui.BranchID.ToString().PadLeft(3, '0') + "AA");
            //if (ContraHash != ui.EntryHash)
            //{
            //    ui.UserID = "0";
            //}

            //ContraHash = Encrypt(ui.RoutingNo + "AA");
            //if (ContraHash != ui.BranchHash)
            //{
            //    ui.UserID = "0";
            //}           

            return ui;
        }


        public UserInfo ADLogin(string LoginID)
        {
            SqlConnection myConnection = new SqlConnection(FLoraSoft.CR.DAL.AppVariables.ConStrVVDD);
            SqlCommand myCommand = new SqlCommand("USER_ADLogin", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterLoginID = new SqlParameter("@LoginID", SqlDbType.NVarChar, 50);
            parameterLoginID.Value = LoginID;
            myCommand.Parameters.Add(parameterLoginID);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
            parameterUserID.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterRoleCount = new SqlParameter("@RoleCount", SqlDbType.Int, 4);
            parameterRoleCount.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterRoleCount);

            SqlParameter parameterRoleID = new SqlParameter("@RoleID", SqlDbType.Int, 4);
            parameterRoleID.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterRoleID);

            SqlParameter parameterRoleCD = new SqlParameter("@RoleCD", SqlDbType.VarChar, 4);
            parameterRoleCD.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterRoleCD);

            SqlParameter parameterDeptID = new SqlParameter("@DeptID", SqlDbType.Int, 4);
            parameterDeptID.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterDeptID);

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.Int, 4);
            parameterRoutingNo.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterRoutingNo);

            SqlParameter parameterAllBranch = new SqlParameter("@AllBranch", SqlDbType.Bit, 1);
            parameterAllBranch.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterAllBranch);

            SqlParameter parameterTransLimit = new SqlParameter("@TransLimit", SqlDbType.Money, 8);
            parameterTransLimit.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterTransLimit);

            SqlParameter parameterDeptName = new SqlParameter("@DeptName", SqlDbType.VarChar, 50);
            parameterDeptName.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterDeptName);

            SqlParameter parameterUserName = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
            parameterUserName.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterUserName);

            SqlParameter parameterRoleName = new SqlParameter("@RoleName", SqlDbType.NVarChar, 50);
            parameterRoleName.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterRoleName);

            SqlParameter parameterBranchName = new SqlParameter("@BranchName", SqlDbType.NVarChar, 50);
            parameterBranchName.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterBranchName);

            SqlParameter parameterBankName = new SqlParameter("@BankName", SqlDbType.NVarChar, 50);
            parameterBankName.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterBankName);

            SqlParameter parameterChangePwdNow = new SqlParameter("@ChangePwdNow", SqlDbType.Bit);
            parameterChangePwdNow.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterChangePwdNow);

            SqlParameter parameterDaysPassed = new SqlParameter("@DaysPassed", SqlDbType.Int, 4);
            parameterDaysPassed.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterDaysPassed);

            SqlParameter parameterExpMsg = new SqlParameter("@ExpMsg", SqlDbType.VarChar, 50);
            parameterExpMsg.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterExpMsg);


            myConnection.Open();
            myCommand.ExecuteNonQuery();

            UserInfo ui = new UserInfo();

            ui.UserID = parameterUserID.Value.ToString();
            ui.RoleCount = parameterRoleCount.Value.ToString();
            ui.RoleID = parameterRoleID.Value.ToString();
            ui.RoleCD = (string)parameterRoleCD.Value;
            ui.DeptID = parameterDeptID.Value.ToString();
            ui.RoutingNo = parameterRoutingNo.Value.ToString();
            ui.AllBranch = (bool)parameterAllBranch.Value;

            ui.TransLimit = (decimal)parameterTransLimit.Value;
            ui.DeptName = (string)parameterDeptName.Value;
            ui.UserName = (string)parameterUserName.Value;
            ui.RoleName = (string)parameterRoleName.Value;
            ui.BranchName = (string)parameterBranchName.Value;
            ui.BankName = (string)parameterBankName.Value;

            ui.DaysRemaining = (int)parameterDaysPassed.Value;
            ui.ExpMsg = (string)parameterExpMsg.Value;

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

            return ui;
        }


        public void UpdateUser(int UserID, String UserName, String Department, String ContactNo, String LoginID, int EnteredBy, string IPAddress)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ACH_UpdateUser", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
            parameterUserID.Value = UserID;
            myCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterUserName = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
            parameterUserName.Value = UserName;
            myCommand.Parameters.Add(parameterUserName);

            SqlParameter parameterDepartment = new SqlParameter("@Department", SqlDbType.VarChar, 50);
            parameterDepartment.Value = Department;
            myCommand.Parameters.Add(parameterDepartment);

            SqlParameter parameterContactNo = new SqlParameter("@ContactNo", SqlDbType.VarChar, 50);
            parameterContactNo.Value = ContactNo;
            myCommand.Parameters.Add(parameterContactNo);

            SqlParameter parameterLoginID = new SqlParameter("@LoginID", SqlDbType.VarChar, 50);
            parameterLoginID.Value = LoginID;
            myCommand.Parameters.Add(parameterLoginID);

            SqlParameter parameterEnteredBy = new SqlParameter("@EnteredBy", SqlDbType.Int, 4);
            parameterEnteredBy.Value = EnteredBy;
            myCommand.Parameters.Add(parameterEnteredBy); 
            
            SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.VarChar, 20);
            parameterIPAddress.Value = IPAddress;
            myCommand.Parameters.Add(parameterIPAddress);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

        }
        public void ChangeUserStatus(int UserID, int UserRole, int BranchID, string UserStatus, int EnteredBy, string IPAddress)
        {
            string EntryHash = "";
            if (UserStatus == "ACTIVE")
            {
                EntryHash = Encrypt(UserID.ToString().PadLeft(3, '0') + UserRole.ToString().PadLeft(3, '0') + BranchID.ToString().PadLeft(3, '0') + "AA");
            }

            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ACH_ChangeUserStatus", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.NVarChar, 50);
            parameterUserID.Value = UserID;
            myCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterUserStatus = new SqlParameter("@UserStatus", SqlDbType.NVarChar, 50);
            parameterUserStatus.Value = UserStatus;
            myCommand.Parameters.Add(parameterUserStatus);

            SqlParameter parameterEntryHash = new SqlParameter("@EntryHash", SqlDbType.NVarChar, 50);
            parameterEntryHash.Value = EntryHash;
            myCommand.Parameters.Add(parameterEntryHash);

            SqlParameter parameterEnteredBy = new SqlParameter("@EnteredBy", SqlDbType.Int, 4);
            parameterEnteredBy.Value = EnteredBy;
            myCommand.Parameters.Add(parameterEnteredBy);

            SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.NVarChar, 40);
            parameterIPAddress.Value = IPAddress;
            myCommand.Parameters.Add(parameterIPAddress);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

        }
        public void LogOut(int UserID)
        {
            SqlConnection myConnection = new SqlConnection(FLoraSoft.CR.DAL.AppVariables.ConStrVVDD);
            SqlCommand myCommand = new SqlCommand("ACH_UserLogout", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
            parameterUserID.Value = UserID;
            myCommand.Parameters.Add(parameterUserID);

            //SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.VarChar, 50);
            //parameterIPAddress.Value = IPAddress;
            //myCommand.Parameters.Add(parameterIPAddress);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }

        public void LockUser(string LoginID)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ACH_LockUser", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterLoginID = new SqlParameter("@LoginID", SqlDbType.NVarChar, 50);
            parameterLoginID.Value = LoginID;
            myCommand.Parameters.Add(parameterLoginID);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();        
        }
        public SqlDataReader GetAllUsers(int BankID)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ACH_GetUsers", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterBankID = new SqlParameter("@BankID", SqlDbType.Int, 4);
            parameterBankID.Value = BankID;
            myCommand.Parameters.Add(parameterBankID);

            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return result;
        }
        public SqlDataReader GetUserByBranchID(int BranchID)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ACH_GetUserByBranchID", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterBranchID = new SqlParameter("@BranchID", SqlDbType.Int, 4);
            parameterBranchID.Value = BranchID;
            myCommand.Parameters.Add(parameterBranchID);

            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return result;
        }
        public SqlDataReader GetUserList()
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ACH_GetUserList", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return result;
        }
        public SqlDataReader GetSingleUser(int userID)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ACH_GetSingleUser", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int);
            parameterUserID.Value = userID;
            myCommand.Parameters.Add(parameterUserID);

            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return result;
        }
        public int ChangePassword(int UserID, String OldPassword, String NewPassword, String IPAddress)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ACH_ChangePassword", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int,4);
            parameterUserID.Value = UserID;
            myCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterOldPassword = new SqlParameter("@OldPassword", SqlDbType.NVarChar, 50);
            parameterOldPassword.Value = OldPassword;
            myCommand.Parameters.Add(parameterOldPassword);

            SqlParameter parameterNewPassword = new SqlParameter("@NewPassword", SqlDbType.NVarChar, 50);
            parameterNewPassword.Value = NewPassword;
            myCommand.Parameters.Add(parameterNewPassword);

            SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.VarChar, 20);
            parameterIPAddress.Value = IPAddress;
            myCommand.Parameters.Add(parameterIPAddress);

            SqlParameter parameterStatus = new SqlParameter("@Status", SqlDbType.Int, 4);
            parameterStatus.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterStatus);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            return (int)parameterStatus.Value;
        }
        public void ResetPassword(int userID, string password)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ACH_ResetPassword", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
            parameterUserID.Value = userID;
            myCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterPassword = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
            parameterPassword.Value = Encrypt(password);
            myCommand.Parameters.Add(parameterPassword);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
        public int InsertUser(int BranchID, int UserRole, String UserName, String Department, String ContactNo, String LoginID, 
            String Password, int EnteredBy, string IPAddress)
        {
            //string EntryHash = Encrypt(UserID.ToString().PadLeft(3, '0') + UserRole.ToString().PadLeft(3, '0') + BranchID.ToString().PadLeft(3, '0') + "AA");
            
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ACH_InsertSingleUser", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterBranchID = new SqlParameter("@BranchID", SqlDbType.Int);
            parameterBranchID.Value = BranchID;
            myCommand.Parameters.Add(parameterBranchID);

            SqlParameter parameterUserRole = new SqlParameter("@UserRole", SqlDbType.NVarChar, 50);
            parameterUserRole.Value = UserRole;
            myCommand.Parameters.Add(parameterUserRole);
            
            SqlParameter parameterUserName = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
            parameterUserName.Value = UserName;
            myCommand.Parameters.Add(parameterUserName);

            SqlParameter parameterDepartment = new SqlParameter("@Department", SqlDbType.NVarChar, 50);
            parameterDepartment.Value = Department;
            myCommand.Parameters.Add(parameterDepartment);

            SqlParameter parameterContactNo = new SqlParameter("@ContactNo", SqlDbType.NVarChar, 50);
            parameterContactNo.Value = ContactNo;
            myCommand.Parameters.Add(parameterContactNo);

            SqlParameter parameterLoginID = new SqlParameter("@LoginID", SqlDbType.NVarChar, 50);
            parameterLoginID.Value = LoginID;
            myCommand.Parameters.Add(parameterLoginID);

            SqlParameter parameterPassword = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
            parameterPassword.Value = Encrypt(Password);
            myCommand.Parameters.Add(parameterPassword);

            SqlParameter parameterEnteredBy = new SqlParameter("@EnteredBy", SqlDbType.Int, 4);
            parameterEnteredBy.Value = EnteredBy;
            myCommand.Parameters.Add(parameterEnteredBy);

            SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.NVarChar, 40);
            parameterIPAddress.Value = IPAddress;
            myCommand.Parameters.Add(parameterIPAddress);

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
            parameterUserID.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterUserID);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            return (int)parameterUserID.Value;

        }
        public void UpdateSingleUser(int UserID, int UserRole, String LoginID, String UserName, String Department, 
            String ContactNo, int EnteredBy, string IPAddress)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ACH_UpdateSingleUser", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.NVarChar, 50);
            parameterUserID.Value = UserID;
            myCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterUserRole = new SqlParameter("@UserRole", SqlDbType.NVarChar, 50);
            parameterUserRole.Value = UserRole;
            myCommand.Parameters.Add(parameterUserRole);

            SqlParameter parameterLoginID = new SqlParameter("@LoginID", SqlDbType.NVarChar, 50);
            parameterLoginID.Value = LoginID;
            myCommand.Parameters.Add(parameterLoginID); 
            
            SqlParameter parameterUserName = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
            parameterUserName.Value = UserName;
            myCommand.Parameters.Add(parameterUserName);

            SqlParameter parameterDepartment = new SqlParameter("@Department", SqlDbType.NVarChar, 50);
            parameterDepartment.Value = Department;
            myCommand.Parameters.Add(parameterDepartment);

            SqlParameter parameterContactNo = new SqlParameter("@ContactNo", SqlDbType.NVarChar, 50);
            parameterContactNo.Value = ContactNo;
            myCommand.Parameters.Add(parameterContactNo);

            SqlParameter parameterEnteredBy = new SqlParameter("@EnteredBy", SqlDbType.Int, 4);
            parameterEnteredBy.Value = EnteredBy;
            myCommand.Parameters.Add(parameterEnteredBy);

            SqlParameter parameterIPAddress = new SqlParameter("@IPAddress", SqlDbType.NVarChar, 40);
            parameterIPAddress.Value = IPAddress;
            myCommand.Parameters.Add(parameterIPAddress);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

        }
        public string Encrypt(string cleanString)
        {
            Byte[] clearBytes = new UnicodeEncoding().GetBytes(cleanString);
            Byte[] hashedBytes = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(clearBytes);

            return BitConverter.ToString(hashedBytes);
        }

        public DataTable SearchUserHistory(string LoginID, int Month, int Year)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ACH_SearchUserHistory", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterLoginID = new SqlParameter("@LoginID", SqlDbType.VarChar, 50);
            parameterLoginID.Value = LoginID;
            myCommand.SelectCommand.Parameters.Add(parameterLoginID);

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

        public DataTable GetLevelsToRefer(int RoleID)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ACH_GetLevelsToRefer", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterRoleID = new SqlParameter("@RoleID", SqlDbType.Int, 4);
            parameterRoleID.Value = RoleID;
            myCommand.SelectCommand.Parameters.Add(parameterRoleID);

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);
            return dt;
        }
        public DataTable GetCheckerLevel()
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("ACH_GetCheckerLevel", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);
            return dt;
        }
    }
}


    

