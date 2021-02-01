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
    public partial class BranchSettlement : System.Web.UI.UserControl
    {
        protected int sECEType;

        protected string sHeight;

        public string ECEType
        {
            get { return sECEType.ToString(); }
            set { sECEType = Int32.Parse(value); }
        }
        public string Height
        {
            get { return sHeight; }
            set { sHeight = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            SettlementViewDiv.Style["height"] = sHeight;

            SettlementDB db = new SettlementDB();
            DataTable dt;
            if (sECEType == 1)
            {
                dt = db.GetBranchSettlementRV();
            }
            else
            {
                dt = db.GetBranchSettlementHV();
            }
            //DataTable dt = db.GetBranchSettlement(sECEType);
            SettlementGrid.DataSource = dt;
            SettlementGrid.DataBind();

            string HRV;
            if (sECEType > 1)
            {
                HRV = "HV";
                SettlementGrid.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#dee9fc");
            }
            else
            {
                HRV = "RV";
                SettlementGrid.RowStyle.BackColor = System.Drawing.Color.LightYellow;
            } 
            LblTotal.Text = "Total -" + HRV;

            try
            {
                OCE.Text = dt.Compute("SUM(OCE)", "").ToString();
                ICE.Text = dt.Compute("SUM(ICE)", "").ToString();
                ORE.Text = dt.Compute("SUM(ORE)", "").ToString();
                IRE.Text = dt.Compute("SUM(IRE)", "").ToString();

                iOCE.Text = dt.Compute("SUM(iOCE)", "").ToString();
                iICE.Text = dt.Compute("SUM(iICE)", "").ToString();
                iORE.Text = dt.Compute("SUM(iORE)", "").ToString();
                iIRE.Text = dt.Compute("SUM(iIRE)", "").ToString();
            }
            catch
            {
            }
            //dt.Dispose();
            SettlementGrid.Dispose();
        }

        protected void PrintBtn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("SettlementSummary.aspx?ReportType=1&ClearingType=" + sECEType);
        }
    }
}