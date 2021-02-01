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
//using FloraSoft;
namespace FloraSoft.CR
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserDB db = new UserDB();
            int userID = int.Parse(this.Context.User.Identity.Name);
            db.LogOut(userID);
        }


    }
}
