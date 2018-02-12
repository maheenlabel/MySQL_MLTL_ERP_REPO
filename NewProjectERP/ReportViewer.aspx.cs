using CrystalDecisions.CrystalReports.Engine;
using NewProjectERP.INVENTORY;
using NewProjectERP.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewProjectERP
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Report"] == "PurchaseRequition")
                {
                    int PurchaseRequitionID = Convert.ToInt32(Request.QueryString["PurchaseRequitionID"]);

                    Supplier_WiseItem(PurchaseRequitionID);
                }

            }

        }

        protected void Supplier_WiseItem(int PurchaseRequitionID)
        {
             SupplierWiseItem_rtp Report = new SupplierWiseItem_rtp();

            try
            {
                INV_RequisitionGenerate db = new INV_RequisitionGenerate();
                DataTable MyData = db.LoadPurchaseRequitionID_wise(PurchaseRequitionID);
                Report.SetDataSource(MyData);

                string Filename = "PI IN HAND DISCOUNT";
                CrystalReportViewer1.ReportSource = Report;
                CrystalReportViewer1.DataBind();

                Report.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Context.Response, false, Filename);

                System.GC.SuppressFinalize(db);
                HttpContext.Current.Response.Close();
                Report.Close();
                Report.Dispose();
                MyData.Dispose();
            }
            catch
            {


            }
            finally
            {
                //reportQueue.Enqueue(Report);
                //if (reportQueue.Count > 5) ((ReportDocument)reportQueue.Dequeue()).Dispose();

            }
        }
    }
}