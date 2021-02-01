using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;


namespace FloraSoft
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Login_Click(object sender, EventArgs e)
        {
            //string UserID = "0";

            //UserDB db = new UserDB();
            //UserInfo uinfo = new UserInfo();


            //if (IsAuthenticated(ConfigurationManager.AppSettings["ADServer"], UserName.Text, Pass.Text))
            //{
            //    uinfo = db.Login(UserName.Text);
            //    UserID = uinfo.UserID;
            //}
            //if (UserID == "0")
            //{
            //    if (Tried.Value == "")
            //        Tried.Value = "0";
            //    string LoginTries = Tried.Value;
            //    int NewVal = Int32.Parse(LoginTries) + 1;
            //    Tried.Value = NewVal.ToString();
            //    if (NewVal > 2)
            //    {
            //        db.LockUser(UserName.Text.Trim());
            //        MyMessage.Text = UserName.Text.Trim() + " has been locked.";
            //    }
            //    else
            //    {
            //        MyMessage.Text = "Login failed (AD): Please try again";
            //    }
            //}

            string UserID = "0";
            UserDB db = new UserDB();
            UserInfo uinfo = new UserInfo();
            string a = ConfigurationManager.AppSettings["ADLogin"].ToUpper();
            if (a!= "TRUE")
            {
                uinfo = db.ADLogin(UserName.Text);
                UserID = uinfo.UserID;
            }
            else if (this.IsAuthenticated(ConfigurationManager.AppSettings["ADServer"], this.UserName.Text, this.Pass.Text))
            {
                uinfo = db.ADLogin(UserName.Text);
                UserID = uinfo.UserID;
            }
            if (UserID == "0")
            {
                string text2 = this.Tried.Value;
                if (text2 == "")
                {
                    text2 = "0";
                }
                int num = int.Parse(text2) + 1;
                this.Tried.Value = num.ToString();
                if (num > 2)
                {
                    db.LockUser(this.UserName.Text.Trim());
                    this.MyMessage.Text = this.UserName.Text + " account has been locked.";
                }
                else
                {
                    MyMessage.Text = "Login failed (AD): Please try again";
                }
            }
            else
            {
                Response.Cookies["LoginID"].Value   = UserName.Text;
                Response.Cookies["ZoneID"].Value    = uinfo.ZoneID;
                Response.Cookies["BranchID"].Value  = uinfo.BranchID;
                Response.Cookies["RoutingNo"].Value = uinfo.RoutingNo;

                Response.Cookies["UserName"].Value  = uinfo.UserName;
                Response.Cookies["BranchName"].Value= uinfo.BranchName;
                Response.Cookies["BankCode"].Value  = uinfo.BankCode;
                Response.Cookies["BankName"].Value  = uinfo.BankName;


                FormsAuthentication.RedirectFromLoginPage(UserID, false);
                Response.Redirect("SelectRole.aspx");

                uinfo = null;

                try
                {
                    PBMServer.Service1 pbm = new FloraSoft.PBMServer.Service1();
                    AppVariable.IsConnected = pbm.AreYouUp();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    AppVariable.IsConnected = false;
                }
                FormsAuthentication.RedirectFromLoginPage(UserID, false);
            }
        }

        public bool IsAuthenticated(string srvr, string usr, string pwd)
        {
            bool authenticated = false;
            try
            {
                using (PrincipalContext Context = new PrincipalContext(ContextType.Domain, srvr))
                {
                    if (Context == null)
                    {
                        authenticated = false;
                        MyMessage.Text = "Login failed: Please try again (hsbcAD)";
                    }
                    else
                    {
                        authenticated = Context.ValidateCredentials(usr, pwd);
                        //authenticated = true;
                    }
                    MyMessage.Text = "";
                }
            }
            catch (DirectoryServicesCOMException cex)
            {
                MyMessage.Text = "Error: " + cex.Message;
            }
            catch (Exception ex)
            {
                MyMessage.Text = "Error: " + ex.Message;
            }
            return authenticated;
        }
    }
}