using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using System.IO;
using FloraSoft.CR.DAL;

namespace FloraSoft.CR
{
    public partial class WaivedCharge : System.Web.UI.Page
    {
        WaivedChargeDB waivedDB = new WaivedChargeDB();

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
                    gvWaivedCharge.Columns[11].Visible = false;
                }
                else if (Request.Cookies["RoleID"].Value == "CRC")
                {
                    gvWaivedCharge.Columns[10].Visible = false;
                    gvWaivedCharge.Columns[12].Visible = false;
                    gvWaivedCharge.Columns[13].Visible = false;
                    btnAdd.Visible = false;
                }
                BindData();
            }
        }
        private void BindData()
        {
            gvWaivedCharge.DataSource = waivedDB.GetWaivedCharge(0);
            gvWaivedCharge.DataBind();
        }
        private void Clear()
        {
            txtAccountNumber.Text = "";
            txtBankComCont.Text = "";
            txtBankComContACNo.Text = "";
            txtBankVATCont.Text = "";
            txtBankVATContACNo.Text = "";
            txtSCommission.Text = "";
            txtSVAT.Text = "";
            btnInsert.Text = "Insert";
            chkBulkEntry.Checked = false;
            hdfChargeID.Value = null;

        }
       
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            panAdd.Visible = true;       
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            panAdd.Visible = false;          
            Clear();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(hdfChargeID.Value))
            {
                waivedDB.InsertWaivedCharge(txtAccountNumber.Text, Convert.ToInt32(ddlClearingType.SelectedValue), Convert.ToInt32(txtSCommission.Text),
                    Convert.ToInt32(txtBankComCont.Text), txtBankComContACNo.Text, Convert.ToInt32(txtSVAT.Text), Convert.ToInt32(txtBankVATCont.Text),
                    txtBankVATContACNo.Text, chkBulkEntry.Checked, 1, Request.Cookies["LoginID"].Value);
                BindData();
                Clear();
                panAdd.Visible = false;
            }
            else if (!String.IsNullOrEmpty(hdfChargeID.Value) && btnInsert.Text == "Delete")
            {
                waivedDB.DeleteWaivedCharge(Convert.ToInt32(hdfChargeID.Value), Request.Cookies["LoginID"].Value);
                BindData();
                Clear();
                panAdd.Visible = false;
            }
            else if (!String.IsNullOrEmpty(hdfChargeID.Value) && btnInsert.Text == "Update")
            {
                waivedDB.UpdateWaivedCharge(Convert.ToInt32(hdfChargeID.Value), txtAccountNumber.Text, Convert.ToInt32(ddlClearingType.SelectedValue), Convert.ToInt32(txtSCommission.Text),
                        Convert.ToInt32(txtBankComCont.Text), txtBankComContACNo.Text, Convert.ToInt32(txtSVAT.Text), Convert.ToInt32(txtBankVATCont.Text),
                        txtBankVATContACNo.Text, chkBulkEntry.Checked, 3);
                BindData();
                Clear();
                panAdd.Visible = false;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            panAdd.Visible = false;
            if (String.IsNullOrEmpty(txtAccountNo.Text))
            {
                gvWaivedCharge.DataSource = waivedDB.GetWaivedCharge(0);
                gvWaivedCharge.DataBind();
            }
            else
            {
                gvWaivedCharge.DataSource = waivedDB.GetWaivedChargeByAc(txtAccountNo.Text);
                gvWaivedCharge.DataBind();
            }
        }

        protected void gvWaivedCharge_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Approve")
            {
                LinkButton lnkBtn = (LinkButton)e.CommandSource;    // the button
                GridViewRow myRow = (GridViewRow)lnkBtn.Parent.Parent;  // the row
                GridView myGrid = (GridView)sender; // the gridview
                string DataID = myGrid.DataKeys[myRow.RowIndex].Value.ToString();
                int ID = Int32.Parse(DataID);

                waivedDB.UpdateWaivedChargeStatus(ID);
                Response.Redirect("WaivedCharge.aspx");

            }
            else if (e.CommandName == "ChargeEdit")
            {
                ImageButton lnkBtn = (ImageButton)e.CommandSource;
                GridViewRow myRow = (GridViewRow)lnkBtn.Parent.Parent;
                GridView myGrid = (GridView)sender;
                string ID = myGrid.DataKeys[myRow.RowIndex].Value.ToString();
                int ChargeID = Int32.Parse(ID);
                DataTable dr = waivedDB.GetWaivedCharge(ChargeID);
                if(dr.Rows.Count>0)
                {
                    hdfChargeID.Value = ChargeID.ToString();
                    ddlClearingType.SelectedValue = dr.Rows[0]["ClearingType"].ToString();
                    txtAccountNumber.Text = dr.Rows[0]["AccountNumber"].ToString();
                    txtBankComCont.Text = dr.Rows[0]["BankComCont"].ToString();
                    txtBankComContACNo.Text = dr.Rows[0]["BankComContACNo"].ToString();
                    txtBankVATCont.Text = dr.Rows[0]["BankVATCont"].ToString();
                    txtBankVATContACNo.Text = dr.Rows[0]["BankVATContACNo"].ToString();
                    txtSCommission.Text = dr.Rows[0]["SCommission"].ToString();
                    txtSVAT.Text = dr.Rows[0]["SVAT"].ToString();
                    chkBulkEntry.Checked = (dr.Rows[0]["BulkEntry"].ToString() == "Yes");
                }

                panAdd.Visible = true;
                btnInsert.Text = "Update";

            }
            else if (e.CommandName == "ChargeDelete")
            {
                ImageButton lnkBtn = (ImageButton)e.CommandSource;
                GridViewRow myRow = (GridViewRow)lnkBtn.Parent.Parent;
                GridView myGrid = (GridView)sender;
                string ID = myGrid.DataKeys[myRow.RowIndex].Value.ToString();
                int ChargeID = Int32.Parse(ID);

                DataTable dr = waivedDB.GetWaivedCharge(ChargeID);
                if (dr.Rows.Count > 0)
                {
                    hdfChargeID.Value = ChargeID.ToString();
                    ddlClearingType.SelectedValue = dr.Rows[0]["ClearingType"].ToString();
                    txtAccountNumber.Text = dr.Rows[0]["AccountNumber"].ToString();
                    txtBankComCont.Text = dr.Rows[0]["BankComCont"].ToString();
                    txtBankComContACNo.Text = dr.Rows[0]["BankComContACNo"].ToString();
                    txtBankVATCont.Text = dr.Rows[0]["BankVATCont"].ToString();
                    txtBankVATContACNo.Text = dr.Rows[0]["BankVATContACNo"].ToString();
                    txtSCommission.Text = dr.Rows[0]["SCommission"].ToString();
                    txtSVAT.Text = dr.Rows[0]["SVAT"].ToString();
                    chkBulkEntry.Checked = (dr.Rows[0]["BulkEntry"].ToString() == "Yes");
                }

                panAdd.Visible = true;
                btnInsert.Text = "Delete";
            }
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvWaivedCharge.DataSource = waivedDB.GetWaivedCChargeByStatus(Convert.ToInt32(ddlStatus.SelectedValue));
            gvWaivedCharge.DataBind();
        }   
    
    }
}