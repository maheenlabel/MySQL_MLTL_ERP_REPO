using MySql.Data.MySqlClient;
using NewProjectERP.DAC;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewProjectERP.INVENTORY
{
    public partial class INV_Requisition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int sampleID = 0;
                if (Request.QueryString["SampleID"] != null)
                {
                    sampleID = Int32.Parse(Request.QueryString["SampleID"]);
                }
                LoadRequisitionGrid(sampleID);
            }

        }
        //public SqlDataReader BindSupplier()
        //{
        //    Config_CommonDB cdb = new Config_CommonDB();
        //    return cdb.GetSupplier();
        //}

        private void LoadRequisitionGrid(int sampleID)
        {
           DataTable dt= DashBroadCommom_GridLoad(sampleID);

            gvPD_DashBoard.DataSource = dt;
            gvPD_DashBoard.DataBind();
        }
        public DataTable DashBroadCommom_GridLoad(int _SampleID)
        {
            string constr = ConfigurationManager.ConnectionStrings["MaheenERPConnection2"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("Load_Requisition_Gridview", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@_SampleID", _SampleID);
                   
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();                        
                        sda.Fill(dt);
                        return dt;
                       
                    }
                }
            }

        }

        protected void gvPD_DashBoard_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Config_CommonDB cdb = new Config_CommonDB();
                DataTable dtSupplier = cdb.GetdtBySp("Load_SupplierList_proc");
                DropDownList ddlSupplier = (e.Row.FindControl("ddlSupplier") as DropDownList);
                ddlSupplier.DataSource = dtSupplier;
                ddlSupplier.DataTextField = "SupplierName";
                ddlSupplier.DataValueField = "SupplierID";
                ddlSupplier.DataBind();

                DataRow row = ((DataRowView)e.Row.DataItem).Row;
                //var lblSupplier = e.Row.FindControl("lblSupplier") as Label;
                //ddlSupplier.SelectedValue = lblSupplier.Text;
            }
        }

        protected void lblSampleQty_TextChanged(object sender, EventArgs e)
        {

            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
            //NamingContainer return the container that the control sits in
            Label Qty = (Label)row.FindControl("lblQty");

            TextBox rate = (TextBox)row.FindControl("lblSampleQty");
            Label amount = (Label)row.FindControl("lblAmount");
            //decimal vcutter = Decimal.Parse(txtCutter.Text);
            //if (vdenier.Text == "")
            //{
            //    Response.Write("<script>alert('Please Enter Denier');</script>");
            //    return;
            //}
            decimal requiredQty1 = 0;
            requiredQty1 =
           
            requiredQty1 = Convert.ToDecimal(Decimal.Parse(Qty.Text) *( Decimal.Parse(rate.Text))) ;
            amount.Text = requiredQty1.ToString();
            //TabName.Value = "Imaage_Sample";
        }

        protected void btnGenerateRequisition_Click(object sender, EventArgs e)
        {

        }

        protected void btnSearchRequisition_Click(object sender, EventArgs e)
        {

        }
    }
}