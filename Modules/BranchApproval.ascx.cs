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
    public partial class BranchApproval : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
        private void BindData()
        {
            DataTable dt = GetData();

            if (dt.Rows.Count > 0)
            {
                SettlementGrid.DataSource = dt;
                SettlementGrid.Columns[0].FooterText = "Total";
                SettlementGrid.Columns[1].FooterText = dt.Compute("SUM(iOCE)", "").ToString();
                SettlementGrid.Columns[2].FooterText = dt.Compute("SUM(OCE)", "").ToString();

                SettlementGrid.Columns[3].FooterText = dt.Compute("SUM(iICE)", "").ToString();
                SettlementGrid.Columns[4].FooterText = dt.Compute("SUM(ICE)", "").ToString();

                SettlementGrid.Columns[5].FooterText = dt.Compute("SUM(iORE)", "").ToString();
                SettlementGrid.Columns[6].FooterText = dt.Compute("SUM(ORE)", "").ToString();

                SettlementGrid.Columns[7].FooterText = dt.Compute("SUM(iIRE)", "").ToString();
                SettlementGrid.Columns[8].FooterText = dt.Compute("SUM(IRE)", "").ToString();
                SettlementGrid.Columns[9].FooterText = dt.Compute("SUM(OCEApr)", "").ToString();
                SettlementGrid.Columns[10].FooterText = dt.Compute("SUM(ICEApr)", "").ToString();
                SettlementGrid.Columns[11].FooterText = dt.Compute("SUM(Net)", "").ToString();

                SettlementGrid.DataBind();
            }
        }
        private DataTable GetData()
        {
            SettlementDB db = new SettlementDB();
            return null;// db.GetBranchApproval(Int32.Parse(Request.Cookies["RoutingNo"].Value));
        }
    }
}