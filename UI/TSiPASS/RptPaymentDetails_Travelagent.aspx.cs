using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class UI_TSiPASS_RptPaymentDetails_Travelagent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        comFunctions cmf = new comFunctions();
        Cls_travelagent Gen = new Cls_travelagent();
        DataTable myDtNewRecdr = new DataTable();

        DataSet ds = new DataSet();
        ds = Gen.GetPaymentDetails_Travelagent(Request.QueryString[0].ToString().Trim());

        grdDetails.DataSource = ds.Tables[0];
        grdDetails.DataBind();
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink h1 = (HyperLink)e.Row.Cells[1].Controls[0];
            h1.Target = "_blank";
        }

    }



}