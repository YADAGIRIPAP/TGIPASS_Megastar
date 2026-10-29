using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;


public partial class UI_TSiPASS_TotalBuildDescPaymentDetals : System.Web.UI.Page
{
    General Gen = new General();
    decimal TotalFee = Convert.ToDecimal("0");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string fromdate="", todate = "";
            DataSet dspay = new DataSet();
            dspay = Gen.GetBilldeskpaymentDetailsall(fromdate, todate);
            if (dspay.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = dspay.Tables[0];
                grdDetails.DataBind();

                foreach (GridViewRow row in grdDetails.Rows)
                {
                   
                    row.Cells[5].Attributes.CssStyle["text-align"] = "Right";
                    row.Cells[5].Attributes.CssStyle["Width"] = "100px";
                   
                }
            }
        }
    }


    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
            decimal TotalFee1 = Convert.ToDecimal(e.Row.Cells[5].Text);
            TotalFee = TotalFee + TotalFee1;
        }
        if ((e.Row.RowType == DataControlRowType.Footer))
        {
            e.Row.Cells[4].Text = "Total Fee";
            e.Row.Cells[5].Text = Convert.ToDecimal(TotalFee.ToString()).ToString("#,##0");
            e.Row.Cells[5].Attributes.CssStyle["text-align"] = "Right";
        }
    }
}