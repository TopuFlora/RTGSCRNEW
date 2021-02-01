using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;

namespace FloraSoft
{
    public partial class InwardStatusTree : System.Web.UI.UserControl
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            //LoadData();
        }
        //private void LoadData()
        //{
        //    ICEDB db = new ICEDB();
        //    string PageName = ".." + Request.Url.AbsolutePath;

        //    string statusxml = "";
        //    XmlDataSource xds = new XmlDataSource();
        //    xds.ID = "inwardtree"+System.DateTime.Now.Ticks.ToString();
            
        //    SqlDataReader dr = db.GetInwardStatusTreeXML(PageName,Int32.Parse(Request.Cookies["BranchID"].Value));
        //    while (dr.Read())
        //    {
        //        statusxml = (string)dr[0];
        //    }
        //    dr.Close();
        //    dr.Dispose();

        //    xds.Data = "<Total_InwardCheques>" + statusxml + "</Total_InwardCheques>"; ;

        //    StatusTreeView.DataSource = xds;
        //    StatusTreeView.DataBind();
        //    StatusTreeView.ExpandAll();
        //}
        
    }
}