using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using FLoraSoft.CR.DAL;
using FloraSoft.CR.DAL;
using ClosedXML.Excel;


namespace FloraSoft.CR
{
    public class SearchData
    {
       

        public string txtFromDate = "";
        public string txtToDate = "";
    }

    public partial class WebForm2 : System.Web.UI.Page
    {
        ReportDB reportDB = new ReportDB();


        protected void Page_PreRender(object sender, EventArgs e)
        {
            for (int i = 0; i < this.gvGenerateFlatFile.Rows.Count; i++)
            {
                ((CheckBox)this.gvGenerateFlatFile.Rows[i].FindControl("chkID")).Checked = CheckSelectAll.Checked;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = Convert.ToDateTime(GetSystemReadableDate(txtFromDate.Text, true));
                DateTime toDate = Convert.ToDateTime(GetSystemReadableDate(txtToDate.Text, true));
                string Type = ddlCategory.SelectedValue.Trim();
               // DataTable dt = reportDB.SearchforFlatFileGenerate(fromDate, toDate, Type);
                DataTable dt = reportDB.FlatFileGenerate(fromDate, toDate, Type);
                gvGenerateFlatFile.DataSource = dt;
                gvGenerateFlatFile.DataBind();
            }
            catch { }
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            PacsData data = new PacsData();

            for (int i = 0; i < this.gvGenerateFlatFile.Rows.Count; i++)
            {
                if (((CheckBox)this.gvGenerateFlatFile.Rows[i].FindControl("chkID")).Checked)
                {
                    string text = ((Label)this.gvGenerateFlatFile.Rows[i].FindControl("lblID")).Text;
                }
                DataTable dt = GetData();

                if (dt.Rows.Count > 0)
                {
                     string xlsFileName = System.DateTime.Today.ToString("yyyyMMdd") + "-T" + System.DateTime.Now.ToString("HHmmss") + ".xlsx";

                    XLWorkbook workbook = new XLWorkbook();
                    workbook.Worksheets.Add(dt, "Sheet1");

                    // Prepare the response
                    httpResponse = Response;
                    httpResponse.Clear();
                    httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    string attachment = "attachment; filename=" + xlsFileName;
                    httpResponse.AddHeader("content-disposition", attachment);

                    // Flush the workbook to the Response.OutputStream
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        workbook.SaveAs(memoryStream);
                        memoryStream.WriteTo(httpResponse.OutputStream);
                        memoryStream.Close();
                    }
                    dt.Dispose();
                    httpResponse.End();

                }
                //reportDB.UpdateOutwardChargeVatStatus(data);
            }
        }


        private DataTable GetData()
        {
            DateTime fromDate = Convert.ToDateTime(GetSystemReadableDate(txtFromDate.Text, true));
            DateTime toDate = Convert.ToDateTime(GetSystemReadableDate(txtToDate.Text, true));
            string Type = ddlCategory.SelectedValue.Trim();
            return reportDB.FlatFileGenerate(fromDate, toDate, Type);
           
        }
        private void BindData()
        {
            DataTable dt = GetData();
            gvGenerateFlatFile.DataSource = dt;
            gvGenerateFlatFile.DataBind();
        }

        public HttpResponse httpResponse { get; set; }

}
}