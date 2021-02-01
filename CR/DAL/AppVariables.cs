using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FLoraSoft.CR.DAL
{
    internal static class AppVariables
    {
        //private static string PassWord = "Password=0;";
        //private static string UserID = "User ID=sa;";

        private static string PassWord = "Password=platinumfloor967;";
        private static string UserID = "User ID=floraweb;";
        private static string InitialCatalog = "Initial Catalog=CRDB;";

        public static string ConStrVVDD { get { return crDB; } }

        private static string crDB = "Data Source=" + ConfigurationManager.AppSettings["CRConnection"].ToString()+";" + InitialCatalog + UserID + PassWord;
    }
}