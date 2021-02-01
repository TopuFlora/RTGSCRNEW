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
    public partial class AdminButtons : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AppVariable.IsConnected)
            {
                SyncImage.ImageUrl = "~/Images/Sync.gif";
            }
            else
            {
                try
                {
                    PBMServer.Service1 pbm = new FloraSoft.PBMServer.Service1();
                    AppVariable.IsConnected = pbm.AreYouUp();
                    SyncImage.ImageUrl = "~/Images/Sync.gif";
                }
                catch
                {
                    AppVariable.IsConnected = false;
                }

            }
        }
    }
}
