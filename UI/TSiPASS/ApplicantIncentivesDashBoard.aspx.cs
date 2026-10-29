using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class UI_TSiPASS_ApplicantIncentivesDashBoard : System.Web.UI.Page
{
    General Gen = new General();
    string dist = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("~/Index.aspx");
            }

            if (!IsPostBack)
            {
                // Response.Redirect("~/ui/tsipass/ApplicantIncentivesHistory.aspx");

                if (Request.QueryString[0].ToString() != "" && Request.QueryString[0].ToString() != null)
                {
                    FillDetails();
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            // lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
        }

    }

    void FillDetails()
    {
        try
        {
            DataSet ds = new DataSet();

            //if (Request.QueryString[0].ToString() != "" && Request.QueryString[0].ToString() != null)
            //{
            ds = Gen.GetApplicantIncentiveDashBoardNEW(Session["uid"].ToString().Trim(), Request.QueryString[0].ToString());
            //}
            //else
            //{
            // ds = Gen.GetApplicantIncentiveDashBoard(Session["uid"].ToString().Trim());
            // }
            // ds = Gen.GetApplicantIncentiveDashBoard(Session["uid"].ToString().Trim());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (Request.QueryString[1].ToString() != null && Request.QueryString[1].ToString() != "")
                {
                    lblApplnNo.Text = Request.QueryString[1].ToString();
                }
                if (Request.QueryString[2].ToString() != null && Request.QueryString[2].ToString() != "")
                {
                    lblApplnDate.Text = Request.QueryString[2].ToString();
                }


                lblApplied.Text = ds.Tables[0].Rows[0]["Applied"].ToString();
                lblQueryRaised.Text = ds.Tables[0].Rows[0]["QueryRaised"].ToString();
                lblQueryResponded.Text = ds.Tables[0].Rows[0]["QueryResponded"].ToString();
                lblInspectionScheduled.Text = ds.Tables[0].Rows[0]["InspectionScheduled"].ToString();
                lblInspectionReportUploaded.Text = ds.Tables[0].Rows[0]["InspectionReportUploaded"].ToString();
                lblInspectionReportNotUploaded.Text = ds.Tables[0].Rows[0]["InspectionReportNotUploaded"].ToString();
                lblRecommendedtoDIPC.Text = ds.Tables[0].Rows[0]["RecommendedtoDIPC"].ToString();

                lblRecommendedtoCOI.Text = ds.Tables[0].Rows[0]["RecommendedtoCOI"].ToString();
                lblSanctioned.Text = ds.Tables[0].Rows[0]["Sanctioned"].ToString();
                lblReleased.Text = ds.Tables[0].Rows[0]["Released"].ToString();

                lnkAwaitingQueryResponse.Text = ds.Tables[0].Rows[0]["QueryRaised"].ToString() + "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ";

                if (lblQueryRaised.Text != "0")
                {
                    hylnkQuery.NavigateUrl = "EnterQueryResponse.aspx?incentid=" + Request.QueryString[0].ToString() + "";
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            // lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
        }
    }


    protected void lnkAwaitingQueryResponse_Click(object sender, EventArgs e)
    {
        Response.Redirect("EnterQueryResponse.aspx?incentid=" + Request.QueryString[0].ToString());
    }

}