using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using FLoraSoft.CR.DAL;

namespace FloraSoft.CR
{
    public partial class BBCharge : System.Web.UI.Page
    {
        BBChargeDB bbChangeDB = new BBChargeDB(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Request.Cookies["RoleID"].Value == "CRM" || Request.Cookies["RoleID"].Value == "CRC"))
            {
                Response.Redirect("~/AccessDenied.aspx");
            }

            //WelcomeMsg.Text = "Welcome " + Request.Cookies["UserName"].Value + " (" + Request.Cookies["RoleName"].Value + ") of " + Request.Cookies["BranchName"].Value + " branch.";
            if (!IsPostBack)
            {
                if (Request.Cookies["RoleID"].Value == "CRM")
                {
                   gvBBCharge.Columns[5].Visible = false;

                }
                else if (Request.Cookies["RoleID"].Value == "CRC")
                {
                    panAdd.Visible = false;
                    gvBBCharge.Columns[4].Visible = false;
                    gvBBCharge.Columns[6].Visible = false;
                      
                }
                BindData();
            }
        }

        private void BindData()
        {
            SqlDataReader sr = bbChangeDB.GetBBCharge(0);
            gvBBCharge.DataSource = sr;
            gvBBCharge.DataBind();
           
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            panAdd.Visible = false;
            Clear();
        }

        private void Clear()
        {          
            txtHVBBCharge.Text = "";
            txtRVBBCharge.Text = "";
            txtHVBBCharge.Text = "";
            hdfChargeID.Value = null; 
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            bbChangeDB.UpdateBBCharge(Convert.ToInt32(hdfChargeID.Value), txtRVBBCharge.Text, txtHVBBCharge.Text,txtRVHBBCharge.Text, 3, Request.Cookies["LoginID"].Value);
            BindData();
            Clear();
            panAdd.Visible = false;
        }
        protected void gvBBCharge_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Approve")
            {
                LinkButton lnkBtn = (LinkButton)e.CommandSource;    // the button
                GridViewRow myRow = (GridViewRow)lnkBtn.Parent.Parent;  // the row
                GridView myGrid = (GridView)sender; // the gridview
                string DataID = myGrid.DataKeys[myRow.RowIndex].Value.ToString();
                int ID = Int32.Parse(DataID);

                bbChangeDB.UpdateBBChargeStatus(ID, Request.Cookies["LoginID"].Value);
                Response.Redirect("BBCharge.aspx");

            }
            if (e.CommandName == "ChargeEdit")
            {
                ImageButton lnkBtn = (ImageButton)e.CommandSource;
                GridViewRow myRow = (GridViewRow)lnkBtn.Parent.Parent;
                GridView myGrid = (GridView)sender;
                string ID = myGrid.DataKeys[myRow.RowIndex].Value.ToString();
                int ChargeID = Int32.Parse(ID);
                SqlDataReader dr = bbChangeDB.GetBBCharge(ChargeID);
                while (dr.Read())
                {
                    hdfChargeID.Value = ChargeID.ToString(); 
                    txtHVBBCharge.Text = dr["HVBBChrg"].ToString();
                    txtRVBBCharge.Text = dr["RVBBChrg"].ToString();
                    txtRVHBBCharge.Text = dr["RVHBBChrg"].ToString();
                }
                dr.Close();
                dr.Dispose();
                panAdd.Visible = true;         
            }
        }
    }
}