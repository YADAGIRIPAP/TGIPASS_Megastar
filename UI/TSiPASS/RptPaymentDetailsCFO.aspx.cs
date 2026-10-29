using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UI_TSiPASS_RptPaymentDetailsCFO : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int delete = 0;
        comFunctions cmf = new comFunctions();
        General Gen = new General();
        DataRow dtrdr;
        DataTable myDtNewRecdr = new DataTable();

        DataSet ds = new DataSet();
        ds = Gen.GetPaymentDetailscfo(Request.QueryString[0].ToString().Trim());

        grdDetails.DataSource = ds.Tables[0];
        grdDetails.DataBind();
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            HyperLink h1 = (HyperLink)e.Row.Cells[1].Controls[0];

            h1.Target = "_blank";
            h1.NavigateUrl = "frmViewAttachmentDetailsDD.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ID")).Trim();

        }

    }
}