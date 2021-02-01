using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FloraSoft
{
    public class ErrorFileDB
	{
        public string GetErrorFiles()
        {
            string xml = "";
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("PBM_GetErrorFiles", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myConnection.Open();
            SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                string folder = (string) dr[0];
                string count  = dr[1].ToString();
                xml += "<" + folder+"-"+count + "/>";
            }
            dr.Close();
            dr.Dispose();
            return "<AiDPS><PBMImport>" + xml + "</PBMImport></AiDPS>";
        }
    }
}

