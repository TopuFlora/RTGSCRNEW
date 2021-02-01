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

namespace FloraSoft
{
    public partial class SelectUserRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUserRole();
            }
        }

        private void BindUserRole()
        {
            int UserID = Int32.Parse(Context.User.Identity.Name);
            RoleDB Role = new RoleDB();
            ddluserrole.DataSource = Role.GetUserRoles(UserID);
            ddluserrole.DataBind();
        }

     
        protected void Login_Click(object sender, EventArgs e)
        {
            string UserID = Context.User.Identity.Name;
            Response.Cookies["RoleID"].Value = ddluserrole.SelectedItem.Value;
            Response.Cookies["RoleName"].Value = ddluserrole.SelectedItem.Text;

            if ((ddluserrole.SelectedItem.Value == "CRM") || (ddluserrole.SelectedItem.Value == "CRC"))
            {
                FormsAuthentication.SetAuthCookie(UserID, false);
                Response.Redirect("CR/Default.aspx");
            } 
            }
    }
}
