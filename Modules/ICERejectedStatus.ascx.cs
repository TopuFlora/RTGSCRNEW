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
    public partial class ICERejectedStatus : System.Web.UI.UserControl
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
            ICEBranchViewDiv.Style["height"] = sHeight;

            ICEDB db   = new ICEDB();
            DataTable dt;
            if (sECEType == 11)
            {
                dt = db.GetBranchRejectedStatusRV();
            }
            else
            {
                dt = db.GetBranchRejectedStatusHV();
            }
            //DataTable dt            = db.GetBranchStatus(sECEType);

            BranchGrid.DataSource   = dt;
            BranchGrid.DataBind();

            string HRV;
            if (sECEType > 11)
            {
                HRV = "HV";
                BranchGrid.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#dee9fc");
            }
            else
            {
                HRV = "RV";
                BranchGrid.RowStyle.BackColor = System.Drawing.Color.LightYellow;
            }
            LblTotal.Text = "ICE Rej -" + HRV; 

            try
            {
                Maker.Text      = dt.Compute("SUM(C0)", "").ToString();
                Checker.Text    = dt.Compute("SUM(C1)", "").ToString();
            }
            catch
            {
            }
            dt.Dispose();
            BranchGrid.Dispose();
        }
        
    }
}