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
    public partial class ICEBranchStatus : System.Web.UI.UserControl
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

            ICEDB db                = new ICEDB();
            DataTable dt;
            if (sECEType == 11)
            {
                dt = db.GetBranchStatusRV();
            }
            else
            {
                dt = db.GetBranchStatusHV();
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
            LblTotal.Text = "ICE -" + HRV; 

            try
            {
                Flora.Text      = dt.Compute("SUM(C0)", "").ToString();
                HUB.Text        = dt.Compute("SUM(C1)", "").ToString();
                Maker.Text      = dt.Compute("SUM(C2)", "").ToString();
                Checker.Text    = dt.Compute("SUM(C3)", "").ToString();
                Approved.Text   = dt.Compute("SUM(C4)", "").ToString();
                Admin.InnerText = dt.Compute("SUM(C5)", "").ToString();
                Admin.HRef      = "../CreateORE.aspx?ECEType=" + sECEType;

                if ((Admin.InnerText != "0") && (Admin.InnerText != ""))
                {
                    Admin.Style["background-color"] = "Yellow";
                    Admin.Style["color"]            = "Red";
                }

                ORE.Text    = dt.Compute("SUM(C6)", "").ToString();
                Total.Text  = dt.Compute("SUM(T)", "").ToString();
            }
            catch
            {
            }
            dt.Dispose();
            BranchGrid.Dispose();
        }
        
    }
}