using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FLoraSoft.CR.DAL;
using System.Data.SqlClient;

namespace FloraSoft.CR
{
    public partial class StandardCharge : System.Web.UI.Page
    {
        StandardChargeDB standardDB = new StandardChargeDB();
       
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
                    gvStandardCharge.Columns[5].Visible = false;
                    gvStandardCharge.Columns[8].Visible = false;
                }
                else if (Request.Cookies["RoleID"].Value == "CRC")
                {
                    //gvStandardCharge.Columns[6].Visible = false;
                    //gvStandardCharge.Columns[7].Visible = false;
                  

                    btnAdd.Visible = false;   
                }     
                BindData();
            }
        }
        private void BindData()
        {
            SqlDataReader sr = standardDB.GetStandardCharge(0);
            gvStandardCharge.DataSource = sr;
            gvStandardCharge.DataBind();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(hdfChargeID.Value))
            {
                standardDB.InsertStandardCharge(Convert.ToInt32(txtCommission.Text), Convert.ToInt32(txtVAT.Text),
                     null,
                    1, Request.Cookies["LoginID"].Value);
                BindData();
                Clear();
                panAdd.Visible = false;
                
            }
            else if (!String.IsNullOrEmpty(hdfChargeID.Value) && btnInsert.Text=="Delete")
            {
                standardDB.DeleteStandardCharge(Convert.ToInt32(hdfChargeID.Value), Request.Cookies["LoginID"].Value);
                BindData();
                Clear();
                panAdd.Visible = false;
            }
            else if (!String.IsNullOrEmpty(hdfChargeID.Value) && btnInsert.Text == "Update")
            {
                standardDB.UpdateStandardCharge(Convert.ToInt32(hdfChargeID.Value), Convert.ToInt32(txtCommission.Text), Convert.ToInt32(txtVAT.Text),
                null,
                  3, Request.Cookies["LoginID"].Value);
                BindData();
                Clear();
                panAdd.Visible = false;
            }

        }
       
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
            panAdd.Visible = false;
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            panAdd.Visible = true;
        }

        protected void ddlGHOEditSearch_SelectedIndexChanged(object sender, EventArgs e)
        {         
            panAdd.Visible = false;
            DropDownList ddlGHo = (DropDownList)sender;
            if (ddlGHo.SelectedValue == "All")
            {
                gvStandardCharge.DataSource = standardDB.GetStandardCharge(0);
                gvStandardCharge.DataBind();
            }
            else
            {
                gvStandardCharge.DataSource = standardDB.GetStandardChargeByGHO(ddlGHo.SelectedValue);
                gvStandardCharge.DataBind();
            }
        }

        protected void gvStandardCharge_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
            if (e.CommandName == "Approve")
            {
                LinkButton lnkBtn = (LinkButton)e.CommandSource; 
                GridViewRow myRow = (GridViewRow)lnkBtn.Parent.Parent; 
                GridView myGrid = (GridView)sender; 
                string ID = myGrid.DataKeys[myRow.RowIndex].Value.ToString();
                int ChargeID = Int32.Parse(ID);
                standardDB.UpdateStandardChargeStatus(ChargeID);
                Response.Redirect("StandardCharge.aspx");
            }
            if (e.CommandName == "DisApprove")
            {
                LinkButton lnkBtn = (LinkButton)e.CommandSource;
                GridViewRow myRow = (GridViewRow)lnkBtn.Parent.Parent;
                GridView myGrid = (GridView)sender;
                string ID = myGrid.DataKeys[myRow.RowIndex].Value.ToString();
                int ChargeID = Int32.Parse(ID);
                standardDB.UpdateStandardChargeStatusDisApprove(ChargeID, true);
                Response.Redirect("StandardCharge.aspx");
            }
            if (e.CommandName == "ChargeEdit")
            {
                ImageButton lnkBtn = (ImageButton)e.CommandSource;
                GridViewRow myRow = (GridViewRow)lnkBtn.Parent.Parent;
                GridView myGrid = (GridView)sender;
                string ID = myGrid.DataKeys[myRow.RowIndex].Value.ToString();
                int ChargeID = Int32.Parse(ID);
                SqlDataReader dr = standardDB.GetStandardCharge(ChargeID);
                while (dr.Read() )
                {
                    hdfChargeID.Value = ChargeID.ToString();
                    txtCommission.Text = dr["Commission"].ToString ();
                    txtVAT.Text = dr["VAT"].ToString ();
                    //ddlClearingType.SelectedValue = dr["ClearingType"].ToString ();
                   // ddlGHO.SelectedValue = (string)dr["GHO"];
                    //if(dr["BulkEntry"].ToString() == "Yes")
                    //chkBulkEntry.Checked = true;
                    //else chkBulkEntry.Checked = false; 
                }
                dr.Close();
                dr.Dispose();

                panAdd.Visible = true;
                btnInsert.Text = "Update";
            }

            if (e.CommandName == "ChargeDelete")
            {
                ImageButton lnkBtn = (ImageButton)e.CommandSource;
                GridViewRow myRow = (GridViewRow)lnkBtn.Parent.Parent;
                GridView myGrid = (GridView)sender;
                string ID = myGrid.DataKeys[myRow.RowIndex].Value.ToString();
                int ChargeID = Int32.Parse(ID);
                SqlDataReader dr = standardDB.GetStandardCharge(ChargeID);
                while (dr.Read())
                {
                    hdfChargeID.Value = ChargeID.ToString();
                    txtCommission.Text = dr["Commission"].ToString();
                    txtVAT.Text = dr["VAT"].ToString();
                   // ddlClearingType.SelectedValue = dr["ClearingType"].ToString();
                   //// ddlGHO.SelectedValue = (string)dr["GHO"];
                   // chkBulkEntry.Checked = (bool)dr["BulkEntry"];
                }
                dr.Close();
                dr.Dispose();

                panAdd.Visible = true;
                btnInsert.Text = "Delete"; 
            }
        }
        protected void Clear()
        {
            btnInsert.Text = "Insert";
            txtCommission.Text = "";
            txtVAT.Text = "";
            hdfChargeID.Value = null;
            
        }
    }
}