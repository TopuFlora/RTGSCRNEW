using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FLoraSoft.CR.DAL;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using System.Data;

namespace FloraSoft.CR
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SpecialChargeDB specialDB = new SpecialChargeDB();
      
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
                    gvSpecialCharge.Columns[8].Visible = false;
                    gvSpecialCharge.Columns[9].Visible = false;
                    gvSpecialCharge.Columns[12].Visible = false;
                }
                else if (Request.Cookies["RoleID"].Value == "CRC")
                {
                    //gvSpecialCharge.Columns[10].Visible = false;
                    gvSpecialCharge.Columns[11].Visible = false;
                    gvSpecialCharge.Columns[12].Visible = false;
                    gvSpecialCharge.Columns[10].Visible = false;
                   
                    btnAdd.Visible = false;
                    btnBulkUpload.Visible = false; 
                }
                BindData();
            }
        }
        
        private void BindData()
        {         
            gvSpecialCharge.DataSource = specialDB.GetSpecialCharge(0);     
            gvSpecialCharge.DataBind();
        }
        private void Clear()
        {
            hdfChargeID.Value = null;
            txtAccountNumber.Text = "";
            txtBankComCont.Text = "";
            txtBankComContACNo.Text = "";
            txtBankVATCont.Text = "";
            txtBankVATContACNo.Text = "";
            txtSCommission.Text = "";
            txtSVAT.Text = "";
            btnInsert.Text = "Insert";
            //chkBulkEntry.Checked = false; 
             
        }
        
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            panAdd.Visible = true;
            panBulk.Visible = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            panAdd.Visible = false;
            panBulk.Visible = false; 
            Clear();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(hdfChargeID.Value))
            {
                specialDB.InsertSpecialCharge(txtAccountNumber.Text, Convert.ToInt32(txtSCommission.Text),
                    Convert.ToInt32(txtBankComCont.Text), txtBankComContACNo.Text, Convert.ToInt32(txtSVAT.Text), Convert.ToInt32(txtBankVATCont.Text),
                    txtBankVATContACNo.Text,  1, Request.Cookies["LoginID"].Value);
                BindData();
                Clear();
                panAdd.Visible = false;
            }
            else if(!String.IsNullOrEmpty(hdfChargeID.Value) && btnInsert.Text=="Delete")
            {
                specialDB.DeleteSpecialCharge(Convert.ToInt32(hdfChargeID.Value), Request.Cookies["LoginID"].Value);
                BindData();
                Clear();
                panAdd.Visible = false;
            }
            else if (!String.IsNullOrEmpty(hdfChargeID.Value) && btnInsert.Text == "Update")
            {
                specialDB.UpdateSpecialCharge(Convert.ToInt32(hdfChargeID.Value),txtAccountNumber.Text,  Convert.ToInt32(txtSCommission.Text),
                        Convert.ToInt32(txtBankComCont.Text), txtBankComContACNo.Text, Convert.ToInt32(txtSVAT.Text), Convert.ToInt32(txtBankVATCont.Text),
                        txtBankVATContACNo.Text,  3, Request.Cookies["LoginID"].Value);
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
               
                gvSpecialCharge.DataSource = specialDB.GetSpecialCharge(0);
                gvSpecialCharge.DataBind();
            }
            else{
            gvSpecialCharge.DataSource = specialDB.GetSpecialChargeByAc(txtAccountNo.Text);
            gvSpecialCharge.DataBind();
            }
        }

        protected void gvSpecialCharge_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
            if (e.CommandName == "Approve")
            {
                LinkButton lnkBtn = (LinkButton)e.CommandSource;    // the button
                GridViewRow myRow = (GridViewRow)lnkBtn.Parent.Parent;  // the row
                GridView myGrid = (GridView)sender; // the gridview
                string DataID = myGrid.DataKeys[myRow.RowIndex].Value.ToString();
                int ID = Int32.Parse(DataID);

                specialDB.UpdateSpecialChargeStatus(ID);
                Response.Redirect("SpecialCharge.aspx");

            }
            if (e.CommandName == "DisApprove")
            {
                LinkButton lnkBtn = (LinkButton)e.CommandSource;
                GridViewRow myRow = (GridViewRow)lnkBtn.Parent.Parent;
                GridView myGrid = (GridView)sender;
                string ID = myGrid.DataKeys[myRow.RowIndex].Value.ToString();
                int ChargeID = Int32.Parse(ID);
                specialDB.UpdateSpecialChargeStatusDisApprove(ChargeID, true);
                Response.Redirect("SpecialCharge.aspx");
            }
            else if (e.CommandName == "ChargeEdit")
            {
                ImageButton lnkBtn = (ImageButton)e.CommandSource;
                GridViewRow myRow = (GridViewRow)lnkBtn.Parent.Parent;
                GridView myGrid = (GridView)sender;
                string ID = myGrid.DataKeys[myRow.RowIndex].Value.ToString();
                int ChargeID = Int32.Parse(ID);

                DataTable dr = specialDB.GetSpecialCharge(ChargeID);
                if(dr.Rows.Count >0 )
                {    
                    hdfChargeID.Value = ChargeID.ToString();
                    //ddlClearingType.SelectedValue = dr.Rows[0]["ClearingType"].ToString();
                    txtAccountNumber.Text = dr.Rows[0]["AccountNumber"].ToString();
                    txtBankComCont.Text = dr.Rows[0]["BankComCont"].ToString();
                    txtBankComContACNo.Text = dr.Rows[0]["BankComContACNo"].ToString();
                    txtBankVATCont.Text = dr.Rows[0]["BankVATCont"].ToString();
                    txtBankVATContACNo.Text = dr.Rows[0]["BankVATContACNo"].ToString();
                    txtSCommission.Text = dr.Rows[0]["SCommission"].ToString();
                    txtSVAT.Text = dr.Rows[0]["SVAT"].ToString();
                    //chkBulkEntry.Checked = (dr.Rows[0]["BulkEntry"].ToString()=="Yes");
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
                DataTable dr = specialDB.GetSpecialCharge(ChargeID);
                if (dr.Rows.Count > 0)
                {
                    hdfChargeID.Value = ChargeID.ToString();
                    //ddlClearingType.SelectedValue = dr.Rows[0]["ClearingType"].ToString();
                    txtAccountNumber.Text = dr.Rows[0]["AccountNumber"].ToString();
                    txtBankComCont.Text = dr.Rows[0]["BankComCont"].ToString();
                    txtBankComContACNo.Text = dr.Rows[0]["BankComContACNo"].ToString();
                    txtBankVATCont.Text = dr.Rows[0]["BankVATCont"].ToString();
                    txtBankVATContACNo.Text = dr.Rows[0]["BankVATContACNo"].ToString();
                    txtSCommission.Text = dr.Rows[0]["SCommission"].ToString();
                    txtSVAT.Text = dr.Rows[0]["SVAT"].ToString();
                    //chkBulkEntry.Checked = (dr.Rows[0]["BulkEntry"].ToString() == "Yes");
                }
               panAdd.Visible = true;
               btnInsert.Text = "Delete";
            }
        }

        protected void btnBulkUpload_Click(object sender, EventArgs e)
        {
            panBulk.Visible = true;
            panAdd.Visible = false;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string filename = Path.GetFileName(FileUpload1.FileName);
            FileUpload1.SaveAs(Server.MapPath("~/CR") + "\\" + filename);


            SqlConnection myDBConnection = new SqlConnection(FLoraSoft.CR.DAL.AppVariables.ConStrVVDD);
            myDBConnection.Open();

            SqlBulkCopy myBulkCopy = new SqlBulkCopy(myDBConnection);
            myBulkCopy.BulkCopyTimeout = 300;
            myBulkCopy.DestinationTableName = "SpecialCharge";

            string serversidefile = Server.MapPath("~/ExcelFile") + "\\" + filename;

            string excelConnString = @"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + serversidefile + ";" + "Extended Properties=" + "\"" + "Excel 12.0;HDR=YES;" + "\"";
            OleDbConnection myExcelConn = new OleDbConnection(excelConnString);
            DataTable dt = new DataTable();
            myExcelConn.Open();

            OleDbCommand myCmdExcel = new OleDbCommand();
            myCmdExcel.CommandText = "SELECT * FROM [Sheet1$]";

            myCmdExcel.Connection = myExcelConn;

            OleDbDataAdapter oda = new OleDbDataAdapter();
            oda.SelectCommand = myCmdExcel;
            oda.Fill(dt);

            myExcelConn.Close();
            myBulkCopy.WriteToServer(dt);
            myDBConnection.Close();

            FileInfo myfileinf = new FileInfo(serversidefile);
            myfileinf.Delete();


        }

        protected void txtAccountNumber_TextChanged(object sender, EventArgs e)
        {
            //MQService.MQWebService cbs = new MQService.MQWebService();
       
            //string mqRespone = cbs.GetResponse(txtAccountNo.Text, Request.Cookies["LoginID"].Value, "N");

            //if (mqRespone.Contains("Invalid Account Number"))
            //{
            //    return;
            //}
            //else
            //{
            //    txtAcStatus.Text = mqRespone.Substring(1539, 8);
            //    txtAcName.Text = mqRespone.Substring(640, 28);

            //    txtAcRestriction.Text = mqRespone.Substring(1599, 50);

            //}
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvSpecialCharge.DataSource = specialDB.GetSpecialChargeByStatus(Convert.ToInt32(ddlStatus.SelectedValue));
            gvSpecialCharge.DataBind();       
        }

        protected void gvSpecialCharge_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSpecialCharge.PageIndex = e.NewPageIndex;
            BindData();
        }
    }
}