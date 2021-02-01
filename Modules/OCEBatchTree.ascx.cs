
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
    public partial class OCEBatchTree : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ZonesDB db = new ZonesDB();
                ZoneList.DataSource = db.GetZonesByBankCode(Int32.Parse(Request.Cookies["BankCode"].Value));
                ZoneList.DataBind();
                if (Request.QueryString["RoutingNo"] != null)
                {
                    ZoneList.SelectedValue = db.GetZoneIDByRoutingNo(Int32.Parse(Request.QueryString["RoutingNo"])).ToString();
                }
                BindBranchList();
                if (Request.QueryString["RoutingNo"] != null)
                {
                    BranchList.SelectedValue = Request.QueryString["RoutingNo"];
                }
                if (Request.QueryString["ClearingType"] != null)
                {
                    ClearingTypeList.SelectedValue = Request.QueryString["ClearingType"];
                }
                if(Request.Cookies["RoleID"].Value != "4")
                {
                    ZoneList.SelectedValue = Request.Cookies["ZoneID"].Value;
                    ZoneList.Enabled = false;
                    BindBranchList();
                    BranchList.SelectedValue = Request.Cookies["RoutingNo"].Value;
                    BranchList.Enabled = false;
                }
            }
        }
        private void BindBranchList()
        {
            BranchesDB db = new BranchesDB();
            BranchList.DataSource = db.GetBranchesByZoneID(Int32.Parse(ZoneList.SelectedValue));
            BranchList.DataBind();
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            string PageName = Request.Url.AbsolutePath;
            OCEBatchDB db = new OCEBatchDB();

            string statusxml = "";
            
            XmlDataSource xds = new XmlDataSource();
            xds.ID = "ocebatchtree" + System.DateTime.Now.Ticks.ToString();
            SqlDataReader dr = db.GetBatchTree(PageName, Int32.Parse(BranchList.SelectedValue),Int32.Parse(ClearingTypeList.SelectedValue));
            while (dr.Read())
            {
                statusxml = statusxml + (string)dr[0];
            }
            dr.Close();
            dr.Dispose();
            xds.Data = "<Batches>" + statusxml + "</Batches>"; ;

            StatusTreeView1.DataSource = xds;
            StatusTreeView1.DataBind();
            StatusTreeView1.ExpandAll();
        }

        protected void ZoneList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindBranchList();
        }        
    }
}