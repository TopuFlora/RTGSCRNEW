using FloraSoft;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FLoraSoft.CR.DAL
{
    public class OutwardDB
    {
        public DataTable GetOutwardList(string RoutingNo, int StatusID)
        {
            SqlConnection myConnection = new SqlConnection(AppVariable.ServerLogin);
            SqlDataAdapter myCommand = new SqlDataAdapter("GetListOutward", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.VarChar, 20);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.SelectCommand.Parameters.Add(parameterRoutingNo);

            SqlParameter parameterStatusID = new SqlParameter("@StatusID", SqlDbType.Int, 4);
            parameterStatusID.Value = StatusID;
            myCommand.SelectCommand.Parameters.Add(parameterStatusID);

            myConnection.Open();

            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();
            return dt;
        }

        public DataTable SearchOutwardChargeData(string Outwardid, String FormName)
        {
            SqlConnection myConnection = new SqlConnection(AppVariable.ServerLogin);
            SqlDataAdapter myCommand = new SqlDataAdapter("VVDD_SearchOutwardChargeData", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            //SqlParameter parameterDeptID = new SqlParameter("@DeptID", SqlDbType.Int, 4);
            //parameterDeptID.Value = DeptID;
            //myCommand.SelectCommand.Parameters.Add(parameterDeptID);

            SqlParameter parameterOutwardid = new SqlParameter("@Outwardid", SqlDbType.VarChar, 30);
            parameterOutwardid.Value = Outwardid;
            myCommand.SelectCommand.Parameters.Add(parameterOutwardid);

            //SqlParameter parameterStatusID = new SqlParameter("@StatusID", SqlDbType.Int, 4);
            //parameterStatusID.Value = StatusID;
            //myCommand.SelectCommand.Parameters.Add(parameterStatusID);

            SqlParameter parameterFormName = new SqlParameter("@FormName", SqlDbType.VarChar, 10);
            parameterFormName.Value = FormName;
            myCommand.SelectCommand.Parameters.Add(parameterFormName);

            myConnection.Open();

            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();
            return dt;
        }

        public DataTable SearchOutwardVATeData(string Outwardid, String FormName)
        {
            SqlConnection myConnection = new SqlConnection(AppVariable.ServerLogin);
            SqlDataAdapter myCommand = new SqlDataAdapter("VVDD_SearchOutwardVATData", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterOutwardid = new SqlParameter("@Outwardid", SqlDbType.VarChar, 30);
            parameterOutwardid.Value = Outwardid;
            myCommand.SelectCommand.Parameters.Add(parameterOutwardid);

            //SqlParameter parameterStatusID = new SqlParameter("@StatusID", SqlDbType.Int, 4);
            //parameterStatusID.Value = StatusID;
            //myCommand.SelectCommand.Parameters.Add(parameterStatusID);

            SqlParameter parameterFormName = new SqlParameter("@FormName", SqlDbType.VarChar, 10);
            parameterFormName.Value = FormName;
            myCommand.SelectCommand.Parameters.Add(parameterFormName);

            myConnection.Open();

            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();
            return dt;
        }

   }
}