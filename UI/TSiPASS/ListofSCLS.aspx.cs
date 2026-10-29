using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_TSiPASS_ListofSCLS : System.Web.UI.Page
{
    General gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            ds = gen.getSLClist();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
            }
        }
    }
    protected void BtnSave1_Click(object sender, EventArgs e)
    {

    }

    protected void grdDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        int indexrow = int.Parse(e.CommandArgument.ToString());
        GridViewRow gvrow = grdDetails.Rows[indexrow];
        HyperLink enterid = (HyperLink)gvrow.FindControl("hSLCNumber");

        Response.Redirect("IncentiveWiseSLClist.aspx?SLCNo=" + enterid.Text);
        // (e.Row.FindControl("anchortaglink") as HyperLink).NavigateUrl = "ApplicantIncentiveDtls.aspx?EntrpId=" + enterid.Text.Trim() + "&Sts=" + status;

    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           
            HyperLink Link1 = (e.Row.FindControl("hSLCNumber") as HyperLink);
            // HyperLink enterid = (HyperLink)grdDetails.FindControl("hSLCNumber");
            if (Request.QueryString[0] != null && Request.QueryString[0].ToString() == "4")
            {
                Link1.NavigateUrl = "IncentiveWiseSLClist.aspx?SLCNo=" + DataBinder.Eval(e.Row.DataItem, "SLCNumberonly");
            }
            else if (Request.QueryString[0] != null && Request.QueryString[0].ToString() == "5")
            {
                Link1.NavigateUrl = "IncentiveProceedingsStep1.aspx?SLCNo=" + DataBinder.Eval(e.Row.DataItem, "SLCNumberonly");
            }
            Link1.Target = "_blank";
        }
    }

   
}