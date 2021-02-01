using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using System.IO;

namespace FloraSoft.CR
{
    public partial class FileUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            
            string filename = Path.GetFileName(FileUpload1.FileName);
            FileUpload1.SaveAs(Server.MapPath("~/ExcelFile") + "\\" + filename);
           

            SqlConnection myDBConnection = new SqlConnection(AppVariables.ConStrVVDD);
            myDBConnection.Open();

            SqlBulkCopy myBulkCopy = new SqlBulkCopy(myDBConnection);
            myBulkCopy.BulkCopyTimeout = 300;
            myBulkCopy.DestinationTableName = "RealizationStatus";

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
    }
}