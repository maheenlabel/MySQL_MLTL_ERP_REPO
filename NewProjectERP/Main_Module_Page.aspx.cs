using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Threading;

namespace NewProjectERP
{
    public partial class Main_Module_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["shortlanguageName"] != null)
            {
                string shortlanguageName = Request.QueryString["shortlanguageName"];
                 }
        }
        private void setLang(string _culture)
        {
            //int i = -1;
            //CultureInfo ci = new CultureInfo(_culture);
            //Thread.CurrentThread.CurrentCulture = ci;
            //Thread.CurrentThread.CurrentUICulture = ci;
            //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Module_Page));
            //for (i = 0; i < this.Controls.Count; i++)
            //{
            //    resources.ApplyResources(this.Controls[i], this.Controls[i].Name);
            //}
        }
    }
}