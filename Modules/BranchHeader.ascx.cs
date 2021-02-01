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

namespace FloraSoft
{
    public partial class BranchHeader : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.Cookies["RoleID"].Value != "5") && (Request.Cookies["RoleID"].Value != "6") && (Request.Cookies["RoleID"].Value != "11") && (Request.Cookies["RoleID"].Value != "12"))
            {
                Response.Redirect("AccessDenied.aspx");
            }
            WelcomeMsg.Text = "Welcome " + Request.Cookies["UserName"].Value + " (" + Request.Cookies["RoleName"].Value + ") of " + Request.Cookies["BranchName"].Value + " branch.";
        }
        
    }
}