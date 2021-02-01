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
    public partial class OCEBranchStatus : System.Web.UI.UserControl
    {
        protected int sClearingType;
        protected string sHeight;

        public string ClearingType
        {
            get { return sClearingType.ToString(); }
            set { sClearingType = Int32.Parse(value); }
        }
        public string Height
        {
            get { return sHeight; }
            set { sHeight = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            OCEBranchViewDiv.Style["height"] = sHeight;
            OCEDB db = new OCEDB();
            DataTable dt;
            if (sClearingType == 1)
            {
                dt = db.GetBranchStatusRV();
            }
            else
            {
                dt = db.GetBranchStatusHV();
            }

            //DataTable dt = db.GetBranchStatus(sClearingType);
            BranchGrid.DataSource = dt;
            BranchGrid.DataBind();

            string HRV;
            if (sClearingType > 1)
            {
                HRV = "HV";
                BranchGrid.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#dee9fc");
            }
            else
            {
                HRV = "RV";
                BranchGrid.RowStyle.BackColor = System.Drawing.Color.LightYellow;
            }
            LblTotal.Text = "OCE -" + HRV;
            try
            {
                Scanman.Text    = dt.Compute("SUM(S1)", "").ToString();
                Maker.Text      = dt.Compute("SUM(S2)", "").ToString();
                Checker.Text    = dt.Compute("SUM(S4)", "").ToString();
                Admin.InnerText = dt.Compute("SUM(S5)", "").ToString();
                Admin.HRef      = "../CreateOCE.aspx?ClearingType=" + sClearingType;
                if ((Admin.InnerText != "0") && (Admin.InnerText != ""))
                {
                    Admin.Style["background-color"] = "Yellow";
                    Admin.Style["color"] = "Red";
                }
                PBM.Text    = dt.Compute("SUM(S6)", "").ToString();
                Total.Text  = dt.Compute("SUM(T)", "").ToString();
                IQA.Text    = dt.Compute("SUM(S8)", "").ToString();
                IRE.Text    = dt.Compute("SUM(S9)", "").ToString();
            }
            catch
            {
            }
            dt.Dispose();
            BranchGrid.Dispose();
        }
        
    }
}