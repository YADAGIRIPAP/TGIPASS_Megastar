using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class UI_TSiPASS_ReleaseModuleUnitWiseGMDipc : System.Web.UI.Page
{
    General gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // string Slcno = Request.QueryString[0].ToString();
            string Cast = Request.QueryString[0].ToString();
            string Investmentid = Request.QueryString[1].ToString();
            string subinctypeid = Request.QueryString[2].ToString();
            string checkAgreeemnt = Request.QueryString["Agreement"].ToString();
            h1heading.InnerHtml = Cast + " Category";

            DataSet ds = new DataSet();

            //
            SqlParameter[] pp = new SqlParameter[] {
                new SqlParameter("@IncentiveTypID",SqlDbType.VarChar),
                new SqlParameter("@Cast",SqlDbType.VarChar),
                  new SqlParameter("@DistID",SqlDbType.VarChar),
                new SqlParameter("@SubIncTypeId",SqlDbType.VarChar),
                 new SqlParameter("@code",SqlDbType.VarChar)
            };

            pp[0].Value = Investmentid;
            pp[1].Value = Cast;
            pp[2].Value = Session["DistrictID"].ToString().Trim();
            pp[3].Value = subinctypeid;
            pp[4].Value = checkAgreeemnt;

            ds = gen.GenericFillDs("USP_GET_UNIT_INCENTIVEWISE_GM_DIPC_Backup181020", pp);




           // ds = gen.getReleaseProceedingsGM(Cast, Investmentid, Session["DistrictID"].ToString().Trim(), subinctypeid);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                tdinvestments.InnerHtml = "--> " + ds.Tables[1].Rows[0]["IncentiveName"].ToString();
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;

            string lblMstIncentiveId = ((Label)grdDetails.Rows[indexing].FindControl("lblIncentiveID")).Text;
            string EnterperIncentiveID = ((Label)grdDetails.Rows[indexing].FindControl("lblEnterperIncentiveID")).Text;
            string Sactionnumber = ((Label)grdDetails.Rows[indexing].FindControl("lblSLCNumernor")).Text;

            Response.Redirect("ReleaseProceedingFinalGmDIPC.aspx?Sactionnumber=" + Sactionnumber + "&EnterperIncentiveID=" + EnterperIncentiveID + "&MstIncentiveId=" + lblMstIncentiveId + "&SubIncTypeId=" + Request.QueryString[2].ToString() + "&Agreement=" + Request.QueryString["Agreement"].ToString());
        }
        catch (Exception ex)
        {

        }
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label enterid = (e.Row.FindControl("lblEnterperIncentiveID") as Label);
            Label MstIncentiveId = (e.Row.FindControl("lblIncentiveID") as Label);

            Button Button1new = (e.Row.FindControl("Button1") as Button);
            if (Session["DummyLogin"].ToString() == "Y")
            {
                Button1new.Visible = false;
            }
            if (Request.QueryString["Agreement"].ToString() == "R")
            {
                Button1new.Visible = true;
            }
            if (Request.QueryString["Agreement"].ToString() == "A")
            {
                Button1new.Visible = false;
            }
            if (MstIncentiveId.Text == "6")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantInvestmentSubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            }
            if (MstIncentiveId.Text == "1")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantPavalaVaddiSubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            }
            if (MstIncentiveId.Text == "3")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantPowerCostSubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            }
            if (MstIncentiveId.Text == "5")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantSalesTaxSubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            }
            if (MstIncentiveId.Text == "9")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantStampDutySubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            }
            if (MstIncentiveId.Text == "4")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantCleanerProductionSubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            }
            if (MstIncentiveId.Text == "7")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantIIDFSubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            }
            if (MstIncentiveId.Text == "8")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantskillupgradationSubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            }
            if (MstIncentiveId.Text == "10")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantSeedCapitalSubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            }
            if (MstIncentiveId.Text == "11")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantQualityCertificationSubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            }
            if (MstIncentiveId.Text == "12")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantAdvanceSubsidyforSCSTSubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            }
        }
    }
}