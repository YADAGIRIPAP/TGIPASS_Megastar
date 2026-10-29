using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class UI_TSiPASS_ReleaseModuleUnitWiseGM : System.Web.UI.Page
{
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    General gen = new General();
    string code = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            string checkAgreeemnt = Request.QueryString["Agreement"].ToString();

            string Cast1 = Request.QueryString[0].ToString();
            string Investmentid1 = Request.QueryString[1].ToString();
            string subinctypeid1 = Request.QueryString[2].ToString();
            h1heading.InnerHtml = Cast1 + " Category";
            osqlConnection.Open();
            SqlDataAdapter osqlDataAdapter = new SqlDataAdapter();
            DataSet oDataSet = new DataSet();
            osqlDataAdapter = new SqlDataAdapter("USP_GET_UNIT_INCENTIVEWISE_GM_Backup181020", osqlConnection);
            osqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            osqlDataAdapter.SelectCommand.Parameters.Add("@IncentiveTypID", SqlDbType.VarChar).Value = Investmentid1;
            osqlDataAdapter.SelectCommand.Parameters.Add("@Cast", SqlDbType.VarChar).Value = Cast1;
            osqlDataAdapter.SelectCommand.Parameters.Add("@DistID", SqlDbType.VarChar).Value = Session["DistrictID"].ToString().Trim();
            osqlDataAdapter.SelectCommand.Parameters.Add("@SubIncTypeId", SqlDbType.VarChar).Value = subinctypeid1;
            osqlDataAdapter.SelectCommand.Parameters.Add("@code", SqlDbType.VarChar).Value = checkAgreeemnt;
            osqlDataAdapter.Fill(oDataSet);
            grdDetails.DataSource = oDataSet.Tables[0];
            grdDetails.DataBind();
            osqlConnection.Close();

        }
    }

    //else if (checkAgreeemnt == "N")
    //{
    //    // string Slcno = Request.QueryString[0].ToString();
    //    string Cast = Request.QueryString[0].ToString();
    //    string Investmentid = Request.QueryString[1].ToString();
    //    string subinctypeid = Request.QueryString[2].ToString();
    //    h1heading.InnerHtml = Cast + " Category";

    //    DataSet ds = new DataSet();
    //    ds = gen.getReleaseProceedingsGM(Cast, Investmentid, Session["DistrictID"].ToString().Trim(), subinctypeid);
    //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
    //    {
    //        tdinvestments.InnerHtml = "--> " + ds.Tables[1].Rows[0]["IncentiveName"].ToString();
    //        grdDetails.DataSource = ds.Tables[0];
    //        grdDetails.DataBind();
    //    }
    //}




    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string Agreement = "";
            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;

            string lblMstIncentiveId = ((Label)grdDetails.Rows[indexing].FindControl("lblIncentiveID")).Text;
            string EnterperIncentiveID = ((Label)grdDetails.Rows[indexing].FindControl("lblEnterperIncentiveID")).Text;
            string Sactionnumber = ((Label)grdDetails.Rows[indexing].FindControl("lblSLCNumernor")).Text;
            if (Request.QueryString["Agreement"].ToString() == "R")
            {
                Agreement = "R";
            }
            Response.Redirect("ReleaseProceedingFinalGm.aspx?Sactionnumber=" + Sactionnumber + "&EnterperIncentiveID=" + EnterperIncentiveID + "&MstIncentiveId=" + lblMstIncentiveId + "&SubIncTypeId=" + Request.QueryString[2].ToString() + "&Agreement=" + Request.QueryString["Agreement"].ToString());
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