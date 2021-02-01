using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Microsoft.Win32;

namespace FloraSoft
{
    public class AppVariable
    {
        public static bool IsConnected;
        public static string ServerLogin = "server=" + ConfigurationManager.AppSettings["DBServer"] + ";database=RTGS;uid=floraweb;pwd=platinumfloor967";
    }
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }
    }
}