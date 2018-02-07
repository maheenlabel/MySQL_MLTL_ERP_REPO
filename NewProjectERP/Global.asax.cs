using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace NewProjectERP
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        public class AppVariable
        {
            //public static bool IsConnected;
            //public static string ServerLogin = "server=" + ConfigurationManager.AppSettings["DBServer"] + ";database=" + ConfigurationManager.AppSettings["DB"] + ";uid=MyLabelAdmin;pwd=";

            static string userName = string.IsNullOrEmpty(ConfigurationManager.AppSettings["UserName"]) ? "labeladmin" : ConfigurationManager.AppSettings["UserName"].ToString();
            static string password = string.IsNullOrEmpty(ConfigurationManager.AppSettings["Password"]) ? "" : ConfigurationManager.AppSettings["Password"].ToString();
            static string DBServer = string.IsNullOrEmpty(ConfigurationManager.AppSettings["DBServer"]) ? "" : ConfigurationManager.AppSettings["DBServer"].ToString();
            static string database = string.IsNullOrEmpty(ConfigurationManager.AppSettings["DB"]) ? "" : ConfigurationManager.AppSettings["DB"].ToString();
            static string appName = string.IsNullOrEmpty(ConfigurationManager.AppSettings["Appname"]) ? "" : ConfigurationManager.AppSettings["Appname"];

            public static bool IsConnected;
            public static string ServerLogin = "server=" + DBServer + ";database=" + database + ";uid=" + userName + ";pwd=" + password + ";App=" + appName + ";Connection Timeout=800";

        }
    }
}