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
    public partial class ICEZoneStatus : System.Web.UI.UserControl
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {

            ICEDB db = new ICEDB();

            DataTable dt = db.GetZoneStatus(Int32.Parse(Request.Cookies["ZoneID"].Value),Int32.Parse(Session["CurrentClearingType"].ToString()));
            BranchGrid.DataSource = dt;
            BranchGrid.DataBind();
            try
            {
                BranchGrid.FooterRow.Cells[1].Text = dt.Compute("SUM(Maker)", "").ToString();
                BranchGrid.FooterRow.Cells[2].Text = dt.Compute("SUM(Checker)", "").ToString();
            }
            catch
            {
            }
            dt.Dispose();
            BranchGrid.Dispose();
        }
        
    }
}