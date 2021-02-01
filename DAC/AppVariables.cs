using System;
using System.Data.SqlClient;
using System.Configuration;


namespace FloraSoft
{
    public static class AppVariables
    {
        public static string ConStr = AppVariable.ServerLogin;
        public static string DailyConStr (string CurDBName)
        {
            SqlConnectionStringBuilder scb = new SqlConnectionStringBuilder();
            scb.DataSource = ConfigurationManager.AppSettings["DBServer"];
            scb.InitialCatalog = CurDBName;
            scb.UserID = "floraweb";
            scb.Password = "platinumfloor967";
            return scb.ConnectionString;
        }
    }
}
