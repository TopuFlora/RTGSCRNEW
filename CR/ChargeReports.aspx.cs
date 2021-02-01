using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FloraSoft.CR.DAL;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace FloraSoft.CR
{
    public partial class ChargeReports : System.Web.UI.Page
    {
        ReportDB reportDB = new ReportDB();
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Request.Cookies["RoleID"].Value == "CRM" || Request.Cookies["RoleID"].Value == "CRC"))
            {
                Response.Redirect("~/AccessDenied.aspx");
            }

            //WelcomeMsg.Text = "Welcome " + Request.Cookies["UserName"].Value + " (" + Request.Cookies["RoleName"].Value + ") of " + Request.Cookies["BranchName"].Value + " branch.";

            if (ddlReportList.SelectedValue.ToString() == "-1")
            {
                ddlYear.Enabled = false;
                ddlMonth.Enabled = false;
                ddlDayFrom.Enabled = false;
                ddlDayTo.Enabled = false;
                ddlReportCriteria.Enabled = false;
            }
            if (!IsPostBack)
            {

            }
        }

        protected void ddlReportList_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearing();
            if (ddlReportList.SelectedValue.ToString() == "0")
            {
                ddlReportCriteria.Enabled = true;
            }
            else if (ddlReportList.SelectedValue.ToString() == "1")
            {
                ddlReportCriteria.Enabled = true;
            }
            else if (ddlReportList.SelectedValue.ToString() == "2")
            {
                ddlReportCriteria.Enabled = true;
            }

            else if (ddlReportList.SelectedValue.ToString() == "-1")
            {
                ddlYear.Enabled = false;
                ddlMonth.Enabled = false;
                ddlDayFrom.Enabled = false;
                ddlDayTo.Enabled = false;
                ddlReportCriteria.Enabled = false;
            }
        }

        protected void ddlReportCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlReportCriteria.SelectedValue.ToString() == "0")
            {
                ddlYear.Enabled = false;
                ddlMonth.Enabled = false;
                ddlDayFrom.Enabled = false;
                ddlDayTo.Enabled = false;
            }
            else if (ddlReportCriteria.SelectedValue.ToString() == "1")
            {
                ddlYear.Enabled = true;
                ddlMonth.Enabled = true;
                ddlDayFrom.Enabled = true;
                ddlDayTo.Enabled = true;
            }
            else if (ddlReportCriteria.SelectedValue.ToString() == "-1")
            {
                ddlYear.Enabled = false;
                ddlMonth.Enabled = false;
                ddlDayFrom.Enabled = false;
                ddlDayTo.Enabled = false;
            }
        }

        protected void imgBtnReportView_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string year = ddlYear.SelectedValue.ToString();
                string month = ddlMonth.SelectedValue.ToString();
                string dayTo = ddlDayTo.SelectedValue.ToString();
                string dayFrom = ddlDayFrom.SelectedValue.ToString();
                string dateFrom = month + "/" + dayFrom + "/" + year;
                string dateTo = month + "/" + dayTo + "/" + year;
                DateTime fronDate = Convert.ToDateTime(dateFrom);
                DateTime toDate = Convert.ToDateTime(dateTo);

                if (ddlReportList.SelectedValue.ToString() == "0")
                {
                    if (parameterValidate("0"))
                    {
                        dt = reportDB.GenericChargeReport(fronDate, toDate);
                        gvReport.DataSource = dt;
                        gvReport.DataBind();
                    }
                    return;
                }
                else if (ddlReportList.SelectedValue.ToString() == "1")
                {
                    if (parameterValidate("1"))
                    {
                        dt = reportDB.ChargeDeductionReport(fronDate, toDate, Convert.ToBoolean(ddlReportCriteria.SelectedValue.ToString()));
                        gvReport.DataSource = dt;
                        gvReport.DataBind();
                    }
                    return;
                }

                else if (ddlReportList.SelectedValue.ToString() == "2")
                {
                    if (parameterValidate("2"))
                    {
                        dt = reportDB.ChargeRealizationReport(fronDate, toDate, Convert.ToBoolean(ddlReportCriteria.SelectedValue.ToString()));
                        gvReport.DataSource = dt;
                        gvReport.DataBind();
                    }
                    return;
                }
                else if (ddlReportList.SelectedValue.ToString() == "-1")
                {
                    lblMessage.Text = "Select report option";
                }
            }
            catch { }
        }

        protected void imgBtnPDFReport_Click(object sender, ImageClickEventArgs e)
        {
            string year = ddlYear.SelectedValue.ToString();
            string month = ddlMonth.SelectedValue.ToString();
            string dayTo = ddlDayTo.SelectedValue.ToString();
            string dayFrom = ddlDayFrom.SelectedValue.ToString();

            string dateFrom = month + "/" + dayFrom + "/" + year;
            string dateTo = month + "/" + dayTo + "/" + year;
            DateTime fronDate = Convert.ToDateTime(dateFrom);
            DateTime toDate = Convert.ToDateTime(dateTo);


            if (ddlReportList.SelectedValue.ToString() == "0")
            {
                if (parameterValidate("0"))
                {

                    dt = reportDB.GenericChargeReport(fronDate, toDate);
                    ExportToPdf(dt, "CHQ-SL", "BANK", "CHQ-RotNo", "CLG-Type", "DATE",
                      "BEN-ACno", "GHO", "Amount", "CC", "CV", "BC", "BV", "Total", "Status");
                }
                return;
            }
            else if (ddlReportList.SelectedValue.ToString() == "1")
            {
                if (parameterValidate("1"))
                {
                    bool reportCriteria = Convert.ToBoolean(ddlReportCriteria.SelectedValue.ToString());

                    if (reportCriteria)
                    {

                        dt = reportDB.ChargeDeductionReport(fronDate, toDate, true);

                        ExportToPdf(dt, "ACNO", "CHQ-SL", "BANK", "CHQ-RotNo", "CLG-Type", "DATE",
                            "CC", "CV", "BC", "BV", "Total", "Collected", "UnCollected");
                    }
                    else
                    {
                        // dt = rbll.ChargeDeductionReport(Convert.ToDateTime(txtDayFrom.Text), Convert.ToDateTime(txtDayTo.Text), true);
                        ExportToPdf(dt, "ACNO", "CHQ-SL", "BANK", "CHQ-RotNo", "CLG-Type", "DATE",
                            "CC", "CV", "BC", "BV", "Total", "Collected", "UnCollected");
                    }
                }
                return;
            }

            else if (ddlReportList.SelectedValue.ToString() == "2")
            {

                if (parameterValidate("2"))
                {
                    bool reportCriteria = Convert.ToBoolean(ddlReportCriteria.SelectedValue.ToString());
                    if (reportCriteria)
                    {
                        dt = reportDB.ChargeRealizationReport(fronDate, toDate, true);
                        ExportToPdf(dt, "CHQ-SL", "BANK", "CHQ-RotNo", "CLG-Type", "DATE",
                      "BEN-ACno", "GHO", "Collected", "UnCollected");
                    }
                    else
                    {
                        dt = reportDB.ChargeRealizationReport(fronDate, toDate, false);
                        ExportToPdf(dt, "CHQ-SL", "BANK", "CHQ-RotNo", "CLG-Type", "DATE",
                      "BEN-ACno", "GHO", "Collected", "UnCollected");

                    }
                }
            }

            //else if (ddlReportList.SelectedValue.ToString() == "3")
            //{
            //    if (parameterValidate("3"))
            //    {
            //        dt = reportDB.CustomerChargeReport(fronDate, toDate);
            //        ExportToPdf(dt, "CHQ-SL", "BANK", "CHQ-RotNo", "CLG-Type", "DATE",
            //        "BEN-ACno", "GHO", "Amount", "Collected", "UnCollected");
            //    }
            //}

            else if (ddlReportList.SelectedValue.ToString() == "-1")
            {
                lblMessage.Text = "Select report option";
            }
        }

        protected void imgBtnExlReport_Click(object sender, ImageClickEventArgs e)
        {
            string year = ddlYear.SelectedValue.ToString();
            string month = ddlMonth.SelectedValue.ToString();
            string dayTo = ddlDayTo.SelectedValue.ToString();
            string dayFrom = ddlDayFrom.SelectedValue.ToString();

            DateTime fronDate = Convert.ToDateTime(year + month + dayFrom);
            DateTime toDate = Convert.ToDateTime(year + month + dayTo);
            if (ddlReportList.SelectedValue.ToString() == "0")
            {
                if (parameterValidate("0"))
                {
                    dt = reportDB.GenericChargeReport(fronDate, toDate);
                    ExportToExcel(dt, "GenericCharge.xls");
                }
                return;
            }
            else if (ddlReportList.SelectedValue.ToString() == "1")
            {
                if (parameterValidate("1"))
                {
                    bool reportCriteria = Convert.ToBoolean(ddlReportCriteria.SelectedValue.ToString());

                    if (reportCriteria)
                    {
                        dt = reportDB.ChargeDeductionReport(fronDate, toDate, true);
                        ExportToExcel(dt, "ChargeDeductionReportAccountWise.xls");
                    }
                    else
                    {
                        dt = reportDB.ChargeDeductionReport(fronDate, toDate, false);
                        ExportToExcel(dt, "ChargeDeductionReportBranchWise.xls");
                    }
                }
                return;
            }

            else if (ddlReportList.SelectedValue.ToString() == "2")
            {
                if (parameterValidate("2"))
                {
                    bool reportCriteria = Convert.ToBoolean(ddlReportCriteria.SelectedValue.ToString());
                    if (reportCriteria)
                    {
                        dt = reportDB.ChargeRealizationReport(fronDate, toDate, true);
                        ExportToExcel(dt, "ChargeRealizationReportAccountWise.xls");
                    }
                    else
                    {
                        dt = reportDB.ChargeRealizationReport(fronDate, toDate, false);
                        ExportToExcel(dt, "ChargeRealizationReportBranchWise.xls");
                    }
                }
            }

            else if (ddlReportList.SelectedValue.ToString() == "3")
            {
                if (parameterValidate("3"))
                {
                    return;
                }
            }

            else if (ddlReportList.SelectedValue.ToString() == "-1")
            {
                lblMessage.Text = "Select report option";
            }
            return;
        }

        private bool parameterValidate(string reportNo)
        {
            if (reportNo == "0")
            {
                if (ddlYear.SelectedIndex != -1 && ddlMonth.SelectedIndex != -1 && ddlDayFrom.SelectedIndex != -1 && ddlDayTo.SelectedIndex != -1)
                {
                    return true;
                }
            }
            else if (reportNo == "1")
            {
                if (ddlYear.SelectedIndex != -1 && ddlMonth.SelectedIndex != -1 && ddlDayFrom.SelectedIndex != -1 && ddlDayTo.SelectedIndex != -1 && ddlReportCriteria.SelectedValue != "-1")
                {
                    return true;
                }
            }
            else if (reportNo == "2")
            {
                if (ddlYear.SelectedIndex != -1 && ddlMonth.SelectedIndex != -1 && ddlDayFrom.SelectedIndex != -1 && ddlDayTo.SelectedIndex != -1 && ddlReportCriteria.SelectedValue != "-1")
                {
                    return true;
                }
            }
            else if (reportNo == "3")
            {
                if (ddlYear.SelectedIndex != -1 && ddlMonth.SelectedIndex != -1 && ddlDayFrom.SelectedIndex != -1 && ddlDayTo.SelectedIndex != -1)
                {
                    return true;
                }
            }
            return false;
        }

        private void clearing()
        {
            ddlYear.SelectedIndex = -1;
            ddlMonth.SelectedIndex = -1;
            ddlDayFrom.SelectedIndex = -1;
            ddlDayTo.SelectedIndex = -1;

            ddlReportCriteria.SelectedIndex = 0;
            lblMessage.Text = "";
            gvReport.DataSourceID = null;
            gvReport.DataBind();
        }

        //======================== Method For report File Format================================================//////
       
        public void ExportToPdf(DataTable myDataTable, params string[] headerList)
        {
            if (myDataTable.Rows.Count == 0)
            {
                return;
            }

            Document pdfDoc = new Document(PageSize.A4, 10, 10, 8, 8);
            try
            {
                PdfWriter.GetInstance(pdfDoc, System.Web.HttpContext.Current.Response.OutputStream);
                pdfDoc.Open();
                //Chunk c = new Chunk( "HSBC", FontFactory.GetFont("Verdana", 11));
                //Paragraph p = new Paragraph();
                //p.Alignment = Element.ALIGN_CENTER;
                //p.Add(c);
                //pdfDoc.Add(p);

                string imageFilePath = Server.MapPath("~/Images") + "\\" + "hsbc.jpg";

                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageFilePath);
                //Resize image depend upon your need
                //jpg.ScaleToFit(80f, 60f);
                //Give space before image
                jpg.SpacingBefore = 0f;
                //Give some space after the image
                jpg.SpacingAfter = 1f;
                jpg.Alignment = Element.ALIGN_CENTER;
                pdfDoc.Add(jpg);

                Font font8 = FontFactory.GetFont("ARIAL", 7);
                DataTable dt = myDataTable;
                if (dt != null)
                {
                    //Craete instance of the pdf table and set the number of column in that table
                    PdfPTable PdfTable = new PdfPTable(dt.Columns.Count);
                    PdfPCell PdfPCell = null;

                    Font fnt = new Font(Font.HELVETICA, 8);

                    foreach (string columheader in headerList)
                    {
                        PdfTable.AddCell(new iTextSharp.text.Phrase(columheader, fnt));
                    }

                    for (int rows = 0; rows < dt.Rows.Count; rows++)
                    {
                        for (int column = 0; column < dt.Columns.Count; column++)
                        {
                            PdfPCell = new PdfPCell(new Phrase(new Chunk(dt.Rows[rows][column].ToString(), font8)));
                            PdfTable.AddCell(PdfPCell);
                        }
                    }
                    //PdfTable.SpacingBefore = 15f; // Give some space after the text or it may overlap the table
                    pdfDoc.Add(PdfTable); // add pdf table to the document
                }
                pdfDoc.Close();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment; filename= SampleExport.pdf");
                System.Web.HttpContext.Current.Response.Write(pdfDoc);

                Response.Flush();
                Response.End();
                //HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch (DocumentException de)
            {
                System.Web.HttpContext.Current.Response.Write(de.Message);
            }
            catch (IOException ioEx)
            {
                System.Web.HttpContext.Current.Response.Write(ioEx.Message);
            }
            catch (Exception ex)
            {
                System.Web.HttpContext.Current.Response.Write(ex.Message);
            }
        }

        public static void ExportToSpreadsheet(DataTable table, string name)
        {
            HttpContext context = HttpContext.Current;
            context.Response.Clear();

            foreach (DataColumn column in table.Columns)
            {
                context.Response.Write(column.ColumnName + ";");
            }

            context.Response.Write(Environment.NewLine);

            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    context.Response.Write(row[i].ToString().Replace(";", string.Empty) + ";");
                }
                context.Response.Write(Environment.NewLine);
            }
            context.Response.ContentType = "application/vnd.ms-excel";
            context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + name + ".xls");
            context.Response.End();
        }

        public void ExportToExcel(DataTable dt, string filename)
        {
            if (dt.Rows.Count > 0)
            {
                string excelHeader = "HSBC";
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();
                dgGrid.DataSource = dt;
                dgGrid.DataBind();
                hw.WriteLine("<b><u><font size='3'> " + excelHeader + "</font></u></b>");
                dgGrid.RenderControl(hw);
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                this.EnableViewState = false;
                Response.Write(tw.ToString());
                Response.End();
            }
            return;
        }

    }
}
