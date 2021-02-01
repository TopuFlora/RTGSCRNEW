using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FloraSoft.CR.DAL;
using System.Data;

namespace FloraSoft.CR
{
    public partial class UseHistory : System.Web.UI.Page
    {
        ReportDB reportDB = new ReportDB();
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Request.Cookies["RoleID"].Value == "CRM" || Request.Cookies["RoleID"].Value == "CRC"))
            {
                Response.Redirect("~/AccessDenied.aspx");
            }
        }

        protected void btnShowHistory_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = Convert.ToDateTime(GetSystemReadableDate(txtFromDate.Text, true));
                DateTime toDate = Convert.ToDateTime(GetSystemReadableDate(txtToDate.Text, true));
                string chargeType = ddlChargeType.SelectedValue.Trim();
                string activity = ddlActivity.SelectedValue.Trim();
                string userId = txtUserID.Text.Trim();

                DataTable dt = reportDB.SearchUserHistory(fromDate, toDate, chargeType, activity, userId);
                gvHistory.DataSource = dt;
                gvHistory.DataBind();
            }
            catch { }
        }
        public DateTime GetSystemReadableDate(string strDate, bool isServer)
        {
            if (isServer == false)
                return Convert.ToDateTime(strDate);
            string[] arrayDate;
            string strNew = null;
            if (strDate.Contains("/"))
            {
                arrayDate = strDate.Split('/');
                strNew = arrayDate[1] + "/" + arrayDate[0] + "/" + arrayDate[2];
            }
            else
            {
                if (strDate.Contains("-"))
                {
                    arrayDate = strDate.Split('-');
                    strNew = arrayDate[1] + "-" + arrayDate[0] + "-" + arrayDate[2];
                }
            }

            return Convert.ToDateTime(strNew);
        }
    }
}