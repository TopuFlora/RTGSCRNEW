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
    public partial class ICECheckStatus : System.Web.UI.UserControl
    {
        protected string RoutingNo    = "";
        protected string ClearingType = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            DropDownList ECEList = (DropDownList)Page.FindControl("ClearingTypeList");
            DropDownList BrList = (DropDownList)Page.FindControl("BranchList");

            RoutingNo = BrList.SelectedValue;
            ClearingType = ECEList.SelectedValue;
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {


            ICEDB db = new ICEDB();
            DataTable dt = db.GetCheckStatus(Int32.Parse(RoutingNo), Int32.Parse(ClearingType));
            StatusGrid.DataSource = dt;
            StatusGrid.DataBind();
            try
            {
                StatusGrid.FooterRow.Cells[1].Text = dt.Compute("SUM(CheckCount)", "").ToString();
                StatusGrid.FooterRow.Cells[2].Text = dt.Compute("SUM(TotalAmount)", "").ToString();
            }
            catch
            {
            }
            dt.Dispose();
            StatusGrid.Dispose();
        }
        
    }
}