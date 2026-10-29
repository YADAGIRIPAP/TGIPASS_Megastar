using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_ReleasePendingViewALLCategory_TTAP : System.Web.UI.Page
{
    General gen = new General();
    decimal Recommended, Sanctioned;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // string Slcno = Request.QueryString[0].ToString();
            string Cast = Request.QueryString[0].ToString();
            string SubIncId = Request.QueryString[1].ToString();
            if(Cast == "1")
            {
                h1heading.InnerHtml = "General Category";
            }
            if (Cast == "2")
            {
                h1heading.InnerHtml = "OBC Category";
            }

            string Fromdate = Request.QueryString["Fromdate"].ToString();
            string Todate = Request.QueryString["Todate"].ToString();

            hplback.NavigateUrl = "~/UI/TSiPASS/IncentiveWiselistALLCategory_TTAP.aspx?Fromdate=" + Fromdate + "&todate=" + Todate ;

            DataSet ds = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
                new SqlParameter("@Cast",SqlDbType.VarChar),
                new SqlParameter("@SubIncId",SqlDbType.VarChar),
                new SqlParameter("@Fromdate",SqlDbType.VarChar),
                new SqlParameter("@Todate",SqlDbType.VarChar)
            };

            pp[0].Value = Cast;
            pp[1].Value = SubIncId;
            pp[2].Value = Fromdate;
            pp[3].Value = Todate;
  


            ds = gen.GenericFillDs("USP_ADRTGSDASHBOARD_DRILLDOWN_UNITWISE_RELEASEPENDING_TTAP_TGIPASS", pp);

            //ds = gen.getReleaseProceedings(Cast, Investmentid);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                tdinvestments.InnerHtml = "--> " + ds.Tables[1].Rows[0]["IncentiveName"].ToString();
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
            }
        }
    }

    //protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        Label enterid = (e.Row.FindControl("lblEnterperIncentiveID") as Label);
    //        Label MstIncentiveId = (e.Row.FindControl("lblIncentiveID") as Label);

    //        Label lblScheme = (e.Row.FindControl("lblScheme") as Label);
    //        Label lblDIPCNumer = (e.Row.FindControl("lblDIPCNumer") as Label);
    //        Label lblOfflineFlag = (e.Row.FindControl("lblOfflineFlag") as Label);
    //        Label lbloffiline = (e.Row.FindControl("lbloffiline") as Label);


    //        if (MstIncentiveId.Text == "6")
    //        {
    //            (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantInvestmentSubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
    //        }
    //        if (MstIncentiveId.Text == "1")
    //        {
    //            (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantPavalaVaddiSubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
    //        }
    //        if (MstIncentiveId.Text == "3")
    //        {
    //            (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantPowerCostSubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
    //        }
    //        if (MstIncentiveId.Text == "5")
    //        {
    //            (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantSalesTaxSubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
    //        }
    //        //if (MstIncentiveId.Text == "9")
    //        //{
    //        //    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantStampDutySubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
    //        //}
    //        if (MstIncentiveId.Text == "9" || MstIncentiveId.Text == "14" || MstIncentiveId.Text == "15" || MstIncentiveId.Text == "16" || MstIncentiveId.Text == "17")
    //        {
    //            (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantStampDutySubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim() + "&MstIncentiveId=" + MstIncentiveId.Text;
    //        }
    //        if (MstIncentiveId.Text == "4")
    //        {
    //            (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantCleanerProductionSubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
    //        }
    //        if (MstIncentiveId.Text == "7")
    //        {
    //            (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantIIDFSubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
    //        }
    //        if (MstIncentiveId.Text == "8")
    //        {
    //            (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantskillupgradationSubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
    //        }
    //        if (MstIncentiveId.Text == "10")
    //        {
    //            (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantSeedCapitalSubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
    //        }
    //        if (MstIncentiveId.Text == "11")
    //        {
    //            (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantQualityCertificationSubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
    //        }
    //        if (MstIncentiveId.Text == "12")
    //        {
    //            (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantAdvanceSubsidyforSCSTSubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
    //        }

    //        if (lblOfflineFlag.Text.Trim() == "Y")
    //        {
    //            (e.Row.FindControl("anchortagGMCertificate") as HyperLink).Visible = false;
    //            lbloffiline.Visible = true;
    //            lbloffiline.Text = "Offiline data";
    //        }
    //        else
    //        {
    //            (e.Row.FindControl("anchortagGMCertificate") as HyperLink).Visible = true;
    //            lbloffiline.Visible = false;
    //            lbloffiline.Text = "";
    //        }
    //        string ssss = DataBinder.Eval(e.Row.DataItem, "RecommendedAmount").ToString();
    //        if (ssss != null && ssss != "")
    //        {
    //            decimal Recommended1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "RecommendedAmount"));
    //            Recommended = Recommended1 + Recommended;
    //        }
    //        string bbbb = DataBinder.Eval(e.Row.DataItem, "SanctionedAmount").ToString();
    //        if (bbbb != null && bbbb != "")
    //        {
    //            decimal Sanctioned1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SanctionedAmount"));
    //            Sanctioned = Sanctioned1 + Sanctioned;
    //        }
    //    }
    //    if (e.Row.RowType == DataControlRowType.Footer)
    //    {
    //        e.Row.Cells[3].Text = "Total";
    //        e.Row.Cells[4].Text = Recommended.ToString();
    //        e.Row.Cells[5].Text = Sanctioned.ToString();

    //        //e.Row.Font.Bold = true;
    //    }
    //}
}