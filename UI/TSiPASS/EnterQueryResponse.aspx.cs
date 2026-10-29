using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using BusinessLogic;

public partial class UI_TSiPASS_EnterQueryResponse : System.Web.UI.Page
{
    General Gen = new General();
    comFunctions cmf = new comFunctions();
    comFunctions obcmf = new comFunctions();
    Fetch objFetch = new Fetch();

    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string incentiveid = "";
        if (Request.QueryString.Count > 0 && Request.QueryString[0].ToString() != null && Request.QueryString[0].ToString() != "")
        {
            incentiveid = Request.QueryString[0].ToString();
        }
        //ds = Gen.GetQueryDetailsdept(Session["uid"].ToString(),"","","ALL","");
        ds = Gen.GetQueryDetailsdept(Session["uid"].ToString(), incentiveid, "", "ALL", "");
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
            }
            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                lblquerydays.Text = Convert.ToString(ds.Tables[1].Rows[0]["querydays"]);
            }
        }
        catch (Exception ex)
        {

        }

    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label enterid = (e.Row.FindControl("lblIncentiveID") as Label);
            Label MstIncentiveId = (e.Row.FindControl("lblMstIncentiveId") as Label);
            Label lblJdOrGMflag = (e.Row.FindControl("lblJdOrGMflag") as Label);

            (e.Row.FindControl("anchortaglink") as HyperLink).NavigateUrl = "frmResptoIncQry.aspx?EntrpId=" + enterid.Text.Trim() + "&Inctypeid=" + MstIncentiveId.Text + "&JdOrGMflag=" + lblJdOrGMflag.Text;
        }
    }
}