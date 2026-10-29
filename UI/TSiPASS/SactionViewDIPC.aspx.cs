using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLogic;
using System.IO;

public partial class UI_TSiPASS_SactionViewDIPC : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    General Gen = new General();

    comFunctions obcmf = new comFunctions();
    Fetch objFetch = new Fetch();
    string paths = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
        }
        if (!IsPostBack)
        {


            txtslcno.Attributes.Add("onKeyPress", "javascript:return ValidateNumberWithoutSpaceAdhar(event);");
            txtslcno.Attributes.Add("onKeyPress", "javascript:return ValidateNumberWithoutSpaceAdhar(event);");
            txtslcno.Attributes.Add("onKeyPress", "javascript:return ValidateNumberWithoutSpaceAdhar(event);");





            string Cast = Request.QueryString[0].ToString();
            string Investmentid = Request.QueryString[1].ToString();
            h1heading.InnerHtml = Cast + " Category";
            // txtsvcdate.Text = Request.QueryString[2].ToString();

            string status = "1";
            // string distid = Session["DistrictID"].ToString().Trim();

            string dateslc = Request.QueryString[2].ToString();
            txtslcnodate.Text = Request.QueryString[3].ToString();
            DataSet ds = new DataSet();


            string[] datett = txtslcnodate.Text.Trim().Split('/');
            dateslc = datett[2] + "/" + datett[1] + "/" + datett[0];
            string Status = Request.QueryString["Status"].ToString();
            ds = Gen.getReleaseProceedingsAssignDIPCDATENOUpdated(Cast, Investmentid, dateslc, Session["DistrictID"].ToString().Trim(), Status);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvdetailsnew.DataSource = ds.Tables[0];
                gvdetailsnew.DataBind();
                btnSubmit.Visible = true;

                tdinvestments.InnerHtml = "--> " + ds.Tables[1].Rows[0]["IncentiveName"].ToString();
                ViewState["IncentiveType"] = "";
                ViewState["IncentiveType"] = ds.Tables[1].Rows[0]["IncentiveName"].ToString();
            }
            else
            {
                btnSubmit.Visible = false;
            }


            //DataSet dsnew = new DataSet();
            //dsnew = Gen.getincentiveslcfinallistNewFinalsaction("2", "6", "2");
            //if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
            //{
            //    gvdetailsfinalproforma.DataSource = dsnew.Tables[0];
            //    gvdetailsfinalproforma.DataBind();
            //}

            //if (!IsPostBack)
            //{
            //    fetchIncentivedet();
            //}
        }
        if (Session["DummyLogin"] != null)
        {
            if (Session["DummyLogin"].ToString() == "Y")
            {
                btnSubmit.Visible = false;
            }
        }
    }
    protected void GetDepartment()
    {

    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        fetchIncentivedet();
    }

    protected void fetchIncentivedet()
    {
        DataSet ds = new DataSet();

        ds = Gen.fetchIncentivedetIPONewIncTypeAddlDirector(Session["uid"].ToString(), "3", "", "");
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvdetailsnew.DataSource = ds.Tables[0];
            gvdetailsnew.DataBind();
            btnSubmit.Visible = true;
        }
        else
        {
            btnSubmit.Visible = false;
        }
    }
    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
        //ExportToExcel();
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtslcnodate.Text.Trim() == null || txtslcnodate.Text.Trim() == "")
        {
            string message = "alert('Please Enter DIPC Date')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        if (txtslcno.Text.Trim().TrimStart() == null || txtslcno.Text.Trim().TrimStart() == "")
        {
            string message = "alert('Please Enter DIPC Number')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        int valid = 0;
        foreach (GridViewRow gvrow in gvdetailsnew.Rows)
        {
            CheckBox chkcheck = ((CheckBox)gvrow.FindControl("chkRow"));
            if (chkcheck.Checked == true)
            {
                officerRemarks fromvo = new officerRemarks();
                int rowIndex = gvrow.RowIndex;

                fromvo.EnterperIncentiveID = ((Label)gvrow.FindControl("lblEnterperIncentiveID")).Text.ToString();
                fromvo.MstIncentiveId = ((Label)gvrow.FindControl("lblIncentiveID")).Text.ToString();
                string ApproveStatus = ((RadioButtonList)gvrow.FindControl("rbtnLstApprove")).SelectedValue;
                string rejectedRemarks = ((TextBox)gvrow.FindControl("txtIncQueryFnl2")).Text.Trim();
                string SactionnedAmount = ((TextBox)gvrow.FindControl("txtsactionnedAmount")).Text.Trim();
                string Role_Code = Session["Role_Code"].ToString().Trim().TrimStart();
                if (ApproveStatus == "Y")
                {
                    fromvo.status = "File in full shape";
                    fromvo.Remarks = SactionnedAmount;
                }
                if (ApproveStatus == "N")
                {
                    fromvo.status = "Reject";
                    fromvo.Remarks = rejectedRemarks;
                }
                if (ApproveStatus == "H")
                {
                    fromvo.status = "Hold Application";
                    fromvo.Remarks = rejectedRemarks;
                }

                string[] datett = txtslcnodate.Text.Trim().Split('/');
                fromvo.Slcdate = datett[2] + "/" + datett[1] + "/" + datett[0];
                fromvo.SLCNO = txtslcno.Text.Trim();

                fromvo.CreatedByid = Session["uid"].ToString();
                fromvo.Designation = Role_Code.Trim();
                //return;

                valid = Gen.InsertincentiveDIPCBulkinsert(fromvo, "POSTSLC");

                if (valid == 1)
                {
                    SendSmsEmail(fromvo.EnterperIncentiveID, fromvo.MstIncentiveId, ApproveStatus);
                }
            }
        }

        if (valid == 1)
        {
            btnSubmit.Enabled = false;
            string message = "alert('Selected DIPC Proceedings Updated Successfully')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            string Investmentid = Request.QueryString[1].ToString();
            string[] datett = txtslcnodate.Text.Trim().Split('/');
            string Slcdatenew = datett[2] + "/" + datett[1] + "/" + datett[0];
            DataSet dsnew = new DataSet();
            //dsnew = Gen.getincentiveDIPCfinallistNewFinalsaction(txtslcno.Text.Trim(), Investmentid, Slcdatenew);
            //if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
            //{
            //    gvdetailsfinalproforma.DataSource = dsnew.Tables[0];
            //    gvdetailsfinalproforma.DataBind();
            //}
        }
    }
    protected void gvdetailsfinalproforma_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label enterid = (e.Row.FindControl("lblIncentiveID") as Label);
            Label MstIncentiveId = (e.Row.FindControl("lblMstIncentiveId") as Label);
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
    protected void rbtnLstApprove_SelectedIndexChanged(object sender, EventArgs e)
    {
        RadioButtonList ddlDeptnameFnl2 = (RadioButtonList)sender;

        GridViewRow row = (GridViewRow)ddlDeptnameFnl2.NamingContainer;
        TextBox txtIncQuery = (TextBox)row.FindControl("txtIncQueryFnl2");
        if (ddlDeptnameFnl2.SelectedValue == "Y")
        {
            txtIncQuery.Visible = false;
        }
        else
        {
            txtIncQuery.Visible = true;
        }
    }


    public void SendSmsEmail(string incentiveid, string masterincentiveid, string ApproveStatus)
    {
        string useridnew = Session["uid"].ToString();
        string IncentveID = incentiveid;
        DataSet dsAppliedIncentives = new DataSet();
        string UnitName = "", UnitMobileNo = "", UnitEmail = "", ApplicantName = "", ApplicationDate = "", DistrictName = ""; string applicationno = "";
        string incentivetype = ""; string sanctionedamount = ""; string SLCdate = "";

        DataSet dscaste = GetIntimationLetterDtls(incentiveid, masterincentiveid, useridnew);

        if (dscaste != null && dscaste.Tables.Count > 1 && dscaste.Tables[0].Rows.Count > 0 && dscaste.Tables[2].Rows.Count > 0)
        {

            UnitName = dscaste.Tables[0].Rows[0]["UnitName"].ToString();
            if (!UnitName.ToUpper().ToString().Contains("M/S"))
            {
                UnitName = "M/s " + UnitName.ToString();
            }
            ApplicantName = dscaste.Tables[2].Rows[0]["ApplciantName"].ToString();
            // UnitEmail = "krishna.cheripally@gmail.com";  
            UnitEmail = dscaste.Tables[2].Rows[0]["UnitEmail"].ToString();
            // UnitMobileNo = "9966889972";  
            UnitMobileNo = dscaste.Tables[2].Rows[0]["UnitMObileNo"].ToString();
            ApplicationDate = dscaste.Tables[0].Rows[0]["DOA"].ToString();
            DistrictName = dscaste.Tables[0].Rows[0]["District"].ToString();

            applicationno = dscaste.Tables[0].Rows[0]["ApplicationNo"].ToString();
            incentivetype = ViewState["IncentiveType"].ToString();
            sanctionedamount = dscaste.Tables[0].Rows[0]["sanctionedamount"].ToString();
            SLCdate = dscaste.Tables[0].Rows[0]["SLCDateNew"].ToString();
        }

        System.Text.StringBuilder strMandt = new System.Text.StringBuilder();
        string nameuid = UnitEmail.Replace("@", "(at)");

        try
        {
            if (ApproveStatus.Trim().TrimStart() == "Y")
            {
                cmf.SendMailIncentive(UnitEmail, "Dear " + UnitName + ", your claim application for " + incentivetype + " filed vide reference no: " + applicationno + " has been approved by DLC for an amount of rupees " + sanctionedamount + " in its meeting held on " + SLCdate + ". Intimation letter can be downloaded from your login" + " <br /> Thank You, GM, DIC -" + DistrictName + ",<br />  Govt. of Telangana.");
                //cmf.SendMailIncentive(UnitEmail, "Dear " + UnitName + ", your claim application for " + incentivetype + " filed vide reference no: " + applicationno + " has been approved by SLC for an amount of rupees " + sanctionedamount + " in its meeting held on " + SLCdate + ". Intimation letter can be downloaded from your login" + " <br /> Thank You, Commisionerate of Industries " + "<br />  Govt. of Telangana.");
            }
            else if (ApproveStatus.Trim().TrimStart() == "R")
            {
                cmf.SendMailIncentive(UnitEmail, "Dear " + UnitName + ", your claim application for " + incentivetype + " filed vide reference no: " + applicationno + " has been Rejected by DLC, in its meeting held on " + SLCdate + "." + " <br /> Thank You, GM, DIC -" + DistrictName + ",<br />  Govt. of Telangana.");
            }
            else if (ApproveStatus.Trim().TrimStart() == "H")
            {
                cmf.SendMailIncentive(UnitEmail, "Dear " + UnitName + ", your claim application for " + incentivetype + " filed vide reference no: " + applicationno + " has been abeyanced by DLC, in its meeting held on " + SLCdate + "." + " <br /> Thank You, GM, DIC -" + DistrictName + ",<br />  Govt. of Telangana.");
            }

        }
        catch (Exception ex)
        {

        }
        try
        {
            if (ApproveStatus.Trim().TrimStart() == "Y")
            {
                cmf.SendSingleSMS(UnitMobileNo, "Dear " + UnitName + ", your claim application for " + incentivetype + " filed vide reference no: " + applicationno + " has been approved by DLC for an amount of rupees " + sanctionedamount + " in its meeting held on " + SLCdate + ". Intimation letter can be downloaded from your login." + '\n' + "Thank You, GM, DIC -" + DistrictName + '\n' + " Govt. of Telangana.");
            }
            // cmf.SendSingleSMS(UnitMobileNo, "Dear " + UnitName + ", your claim application for " + incentivetype + " filed vide reference no: " + applicationno + " has been approved by SLC for an amount of rupees " + sanctionedamount + " in its meeting held on " + SLCdate + ". Intimation letter can be downloaded from your login." + '\n' + "Thank You, Commisionerate of Industries " + '\n' + " Govt. of Telangana.");
        }
        catch (Exception ex)
        {

        }
    }


    public DataSet GetIntimationLetterDtls(string incentiveID, string masterincentiveid, string userid)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_INTIMATIONLETTER_DTLS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (incentiveID.ToString() != "" || incentiveID.ToString() != null)
            {
                da.SelectCommand.Parameters.Add("@incentveID", SqlDbType.VarChar).Value = incentiveID;
                da.SelectCommand.Parameters.Add("@MasterIncentiveType", SqlDbType.VarChar).Value = masterincentiveid;
                da.SelectCommand.Parameters.Add("@userid", SqlDbType.VarChar).Value = userid;
                da.SelectCommand.Parameters.Add("@isDLC", SqlDbType.VarChar).Value = "Y";
            }

            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }

    }

    protected void gvdetailsnew_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string Status = Request.QueryString["Status"].ToString();
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txtIncQueryFnl2 = (e.Row.FindControl("txtIncQueryFnl2") as TextBox);
            RadioButtonList RadioButtonListgv = (e.Row.FindControl("rbtnLstApprove") as RadioButtonList);
            if (Status.TrimStart().Trim() == "4")
            {
                txtIncQueryFnl2.Visible = true;
                RadioButtonListgv.SelectedValue = "H";
            }
            else
            {
                txtIncQueryFnl2.Visible = false;
            }
        }
    }
}