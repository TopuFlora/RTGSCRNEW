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
    public partial class ICEQueueList : System.Web.UI.UserControl
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            DropDownList ECEList = (DropDownList) Page.FindControl("ClearingTypeList");
            DropDownList BrList  = (DropDownList) Page.FindControl("BranchList");

            ICEDB db = new ICEDB();
            DataTable dt = db.GetCheckQueue(Int32.Parse(BrList.SelectedValue), Int32.Parse(ECEList.SelectedValue));
            BranchGrid.DataSource = dt;
            BranchGrid.DataBind();
            try
            {
                BranchGrid.FooterRow.Cells[1].Text = dt.Compute("SUM(CheckCount)", "").ToString();
                BranchGrid.FooterRow.Cells[2].Text = dt.Compute("SUM(TotalAmount)", "").ToString();
            }
            catch
            {
            }
            dt.Dispose();
            BranchGrid.Dispose();
        }
        
    }
}