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

namespace FloraSoft.modules
{
    public partial class OutwardAckCount : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OCEAckDB db = new OCEAckDB();
            DataTable dt = db.GetAckCount();
            AckGrid.DataSource = dt;
            AckGrid.DataBind();
            dt.Dispose();
            AckGrid.Dispose();
        }
    }
}