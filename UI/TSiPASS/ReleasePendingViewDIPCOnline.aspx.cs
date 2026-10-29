using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class UI_TSIPASS_ReleasePendingViewDIPCOnline : System.Web.UI.Page
{
    General gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // string Slcno = Request.QueryString[0].ToString();
            string Cast = Request.QueryString[0].ToString();
            string Investmentid = Request.QueryString[1].ToString();
            string SubIncId = Request.QueryString[2].ToString();
            // string Status = Request.QueryString["Status"].ToString();
            h1heading.InnerHtml = Cast + " Category";

            string APPMODE = Request.QueryString["APPMODE"].ToString();
            string APPSTATUS = Request.QueryString["APPSTATUS"].ToString();
            string TIMELINES = Request.QueryString["TIMELINES"].ToString();
            string DIPCNumber = Request.QueryString["DIPCNumber"].ToString();

            string AllApplicationstatus = "";

            if (Request.QueryString["ALLAPPSTATUS"] != null && Request.QueryString["ALLAPPSTATUS"].ToString() == "ALL")
            {
                AllApplicationstatus = "ALL";
            }

            string Distid = "";
            if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
            {
                Distid = Session["DistrictID"].ToString().Trim();
            }

            DataSet ds = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
                new SqlParameter("@IncentiveTypID",SqlDbType.VarChar),
                new SqlParameter("@Cast",SqlDbType.VarChar),
                new SqlParameter("@SubIncId",SqlDbType.VarChar),
                new SqlParameter("@APPMODE",SqlDbType.VarChar),
                new SqlParameter("@APPSTATUS",SqlDbType.VarChar),
                new SqlParameter("@DISTCODE",SqlDbType.VarChar),
                new SqlParameter("@TIMELINES",SqlDbType.VarChar),
                 new SqlParameter("@DIPCNumer",SqlDbType.VarChar),
                 new SqlParameter("@AllApplication", SqlDbType.VarChar)
            };

            pp[0].Value = Investmentid;
            pp[1].Value = Cast;
            pp[2].Value = SubIncId;
            pp[3].Value = APPMODE;
            pp[4].Value = APPSTATUS;
            pp[5].Value = Distid;
            pp[6].Value = TIMELINES;
            pp[7].Value = DIPCNumber;
            pp[8].Value = AllApplicationstatus;
            ds = gen.GenericFillDs("USP_GET_UNIT_INCENTIVEWISE_DIPC_NEW_ONLINEAPPS", pp);


            //ds = gen.getReleaseProceedingsDIPC(Cast, Investmentid, Session["DistrictID"].ToString().Trim());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                tdinvestments.InnerHtml = "--> " + ds.Tables[1].Rows[0]["IncentiveName"].ToString();
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
                btnprint.Visible = true;
            }
            else
            {
                btnprint.Visible = false;
            }
        }
    }



    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label enterid = (e.Row.FindControl("lblEnterperIncentiveID") as Label);
            Label MstIncentiveId = (e.Row.FindControl("lblIncentiveID") as Label);

            Label lblScheme = (e.Row.FindControl("lblScheme") as Label);
            Label lblDIPCNumer = (e.Row.FindControl("lblDIPCNumer") as Label);

            Label lblOfflineFlag = (e.Row.FindControl("lblOfflineFlag") as Label);
            Label lbloffiline = (e.Row.FindControl("lbloffiline") as Label);

            string APPSTATUS = Request.QueryString["APPSTATUS"].ToString();

            if (APPSTATUS != "3")
            {
                if (lblOfflineFlag.Text.Trim() == "Y")
                {
                    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).Visible = false;
                    lbloffiline.Visible = true;
                    lbloffiline.Text = "Offiline data";
                }
                else
                {
                    if (lblDIPCNumer.Text.Trim() != "")
                    {
                        (e.Row.FindControl("anchortagGMCertificate") as HyperLink).Visible = true;
                        lbloffiline.Visible = false;
                        lbloffiline.Text = "";
                    }
                    else
                    {
                        (e.Row.FindControl("anchortagGMCertificate") as HyperLink).Visible = false;
                        lbloffiline.Visible = false;
                        lbloffiline.Text = "";
                    }
                }
            }
            else
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).Visible = false;
                lbloffiline.Visible = true;
                //lbloffiline.Text = "Rejected";

                lbloffiline.Text = "<b>Rejected </b>-- </br>" + DataBinder.Eval(e.Row.DataItem, "Rejectedremarks").ToString();
            }

            if (MstIncentiveId.Text == "6")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantInvestmentSubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
            }
            if (MstIncentiveId.Text == "1")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantPavalaVaddiSubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
            }
            if (MstIncentiveId.Text == "3")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantPowerCostSubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
            }
            if (MstIncentiveId.Text == "5")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantSalesTaxSubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
            }
            if (MstIncentiveId.Text == "9")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantStampDutySubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim() + "&MstIncentiveId=" + MstIncentiveId.Text;
            }
            if (MstIncentiveId.Text == "4")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantCleanerProductionSubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
            }
            if (MstIncentiveId.Text == "7")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantIIDFSubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
            }
            if (MstIncentiveId.Text == "8")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantskillupgradationSubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
            }
            if (MstIncentiveId.Text == "10")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantSeedCapitalSubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
            }
            if (MstIncentiveId.Text == "11")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantQualityCertificationSubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
            }
            if (MstIncentiveId.Text == "12")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantAdvanceSubsidyforSCSTSubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
            }
        }
    }
}