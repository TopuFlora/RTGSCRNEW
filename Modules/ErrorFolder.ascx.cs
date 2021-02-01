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
    public partial class ErrorFolder : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            ErrorFileDB db = new ErrorFileDB();

            XmlDataSource xds = new XmlDataSource();
            xds.ID = "ErrorTree" + System.DateTime.Now.Ticks.ToString();

            xds.Data = db.GetErrorFiles();

            ErrorTreeView.DataSource = xds;
            ErrorTreeView.DataBind();
            ErrorTreeView.CollapseAll();
        }
        
    }
}