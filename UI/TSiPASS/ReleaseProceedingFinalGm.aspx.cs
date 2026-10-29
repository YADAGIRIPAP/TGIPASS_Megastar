using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using BusinessLogic;

public partial class UI_TSiPASS_ReleaseProceedingFinalGm : System.Web.UI.Page
{
    DB.DB con = new DB.DB();

    General gen = new General();
    comFunctions cmf = new comFunctions();
    Fetch objFetch = new Fetch();
    string linkfile = "";
    DataSet dsa;

    #region OTP Chars  //variables for OTP -> Nikhil.
    char[] charArr = "0123456789".ToCharArray();
    string strOTPMobile = string.Empty;
    string strOTPMail = string.Empty;
    string finalOTPMail = "";
    string finalOTPMobile = "";
    Random oRandom = new Random();
    int noOfChar = 6;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);

            if (Session["DummyLogin"] != null)
            {
                if (Session["DummyLogin"].ToString() == "Y")
                {
                    Button6.Visible = false;
                }
            }
            if (Session["code"] == null)
            {
                string Slcno = Request.QueryString[0].ToString();
                //string Cast = Request.QueryString[1].ToString();
                string EnterperIncentiveID = Request.QueryString[1].ToString();
                string MstIncentiveId = Request.QueryString[2].ToString();
                string subinctypeid = Request.QueryString[3].ToString();

                string Agreement = Request.QueryString[4].ToString();

                // h1heading.InnerHtml = Cast + " Category";
                if (Agreement != null && Agreement != "")
                {
                    if (Agreement == "R")
                    {
                        ddlworkingstatus.Items.RemoveAt(4);
                        ddlworkingstatus.Items.RemoveAt(1);
                        
                        //ddlworkingstatus.SelectedValue = "2";
                        //ddlworkingstatus.Enabled = false;
                        //ddlworkingstatus_SelectedIndexChanged(sender, e);
                    }
                    else
                    {
                        if(Agreement!="O")
                        {
                           // ddlworkingstatus.Items.RemoveAt(3);
                        }
                        

                    }

                }

                //add abeyance code here.

                //if(Agreement != "R"|| Agreement == "" || Agreement == null|| Agreement == "A")
                if (Agreement == "" || Agreement == null || Agreement == "A" || Agreement == "Y" || Agreement == "N" || Agreement == "R" || Agreement == "O")  //O
                {
                    DataSet ds = new DataSet();
                    ds = gen.getReleaseProceedingsGMFinal(Slcno, EnterperIncentiveID, MstIncentiveId, Session["DistrictID"].ToString().Trim(), subinctypeid);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        linkfile = ds.Tables[0].Rows[0]["LinkFile"].ToString();
                        tdinvestments.InnerHtml = "--> " + ds.Tables[2].Rows[0]["IncentiveName"].ToString();
                        grdDetails.DataSource = ds.Tables[0];
                        grdDetails.DataBind();
                        cmf.BindCtlto(true, ddlBank, objFetch.FetchBankMst(), 1, 0, false);
                    }

                    if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {
                        lblbankname.Text = ds.Tables[1].Rows[0]["BankNamedesc"].ToString();
                        lblBranchName.Text = ds.Tables[1].Rows[0]["BranchNames"].ToString();
                        lblAccountNumber.Text = ds.Tables[1].Rows[0]["AccNo"].ToString();
                        lblaccounttype.Text = ds.Tables[1].Rows[0]["AccountTypeName"].ToString();
                        lblIFSC.Text = ds.Tables[1].Rows[0]["IFSCCode"].ToString();
                        if (ds.Tables[1].Rows[0]["LoanAggrementAcNo"].ToString() != "")
                        {
                            lblLoanAggrementAcNo.Text = ds.Tables[1].Rows[0]["LoanAggrementAcNo"].ToString();
                        }
                        else
                            lblLoanAggrementAcNo.Text = "Not Available";
                        ViewState["bankid"] = ds.Tables[1].Rows[0]["Bankid"].ToString();
                        ViewState["Accounttype"] = ds.Tables[1].Rows[0]["Accounttype"].ToString();
                    }
                    else
                    {
                        RadioButtonList1.SelectedValue = "2";
                        RadioButtonList1.Enabled = false;
                        RadioButtonList1_SelectedIndexChanged(sender, e);
                    }
                    DataSet dsROLLBACKED = new DataSet();
                    dsROLLBACKED = getReleaseProceedingsGMFinal_ROLLBACKED(EnterperIncentiveID, MstIncentiveId, Session["DistrictID"].ToString().Trim(), subinctypeid);
                    if (dsROLLBACKED != null && dsROLLBACKED.Tables.Count > 0 && dsROLLBACKED.Tables[0].Rows.Count > 0)
                    {
                        trrollbackeddata.Visible = true;
                        trrollbackedgrid.Visible = true;
                        grdlapseddata.DataSource = dsROLLBACKED.Tables[0];
                        grdlapseddata.DataBind();
                    }
                    else
                    {
                        trrollbackeddata.Visible = false;
                        trrollbackedgrid.Visible = false;
                        grdlapseddata.DataSource = null;
                        grdlapseddata.DataBind();
                    }
                }




            }

            //else if (Session["code"].ToString() == "AgreemntBond")
            //{
            //DataSet ds = new DataSet();
            //DataSet ods = new DataSet();
            //SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
            //if (Request.QueryString["code"] != null)

            DataSet oDataSet = new DataSet();
            SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
            //if (Request.QueryString["code"] != null)



            oSqlDataAdapter = new SqlDataAdapter("sp_GetattachmentAgreement_testing", osqlConnection);
            oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            oSqlDataAdapter.SelectCommand.Parameters.Add("@incId", SqlDbType.VarChar).Value = Request.QueryString[1].ToString();
            oSqlDataAdapter.SelectCommand.Parameters.Add("@mstid", SqlDbType.VarChar).Value = Request.QueryString[2].ToString();

            //oSqlDataAdapter.SelectCommand.Parameters.Add("@code", SqlDbType.VarChar).Value = code;
            oSqlDataAdapter.Fill(oDataSet);
            //oDataSet = gen.GetAgreementAttachmetsData(Request.QueryString[1].ToString());
            string sen, sen1, sen2, senPlanB, sennew;
            int c = oDataSet.Tables[0].Rows.Count;
            int i = 0;

            if (oDataSet.Tables[0].Rows.Count >= 1)
            {
                trAssignmentLetter.Visible = true;
                trAgreementBondCopy.Visible = true;
                trAgreementBondAttachments.Visible = true;
                while (i < c)
                {
                    senPlanB = oDataSet.Tables[0].Rows[i][1].ToString();
                    sen2 = oDataSet.Tables[0].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    sennew = oDataSet.Tables[0].Rows[i]["LINKNEW"].ToString();
                    string encpassword = gen.Encrypt(sennew, "SYSTIME");

                    if (sen.Contains("AgreementBond"))
                    {
                        lblFileName2.Visible = true;
                        //lblFileName2.NavigateUrl = sen;
                        lblFileName2.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        lblFileName2.Text = "Agreement Bond Copy";

                    }
                    if (sen.Contains("AssignmentLetter"))
                    {
                        lnkAssignmentLetter.Visible = true;
                        //lnkAssignmentLetter.NavigateUrl = sen;
                        lnkAssignmentLetter.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        lnkAssignmentLetter.Text = "Assignment Letter";

                    }

                    i++;
                }
            }
            //string Slcno = Request.QueryString[0].ToString();
            ////string Cast = Request.QueryString[1].ToString();
            //string EnterperIncentiveID = Request.QueryString[1].ToString();
            //string MstIncentiveId = Request.QueryString[2].ToString();
            //string subinctypeid = Request.QueryString[3].ToString();
            //// h1heading.InnerHtml = Cast + " Category";

            //DataSet ds = new DataSet();
            //ds = gen.getReleaseProceedingsGMFinal(Slcno, EnterperIncentiveID, MstIncentiveId, Session["DistrictID"].ToString().Trim(), subinctypeid);
            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            //    linkfile = ds.Tables[0].Rows[0]["LinkFile"].ToString();
            //    tdinvestments.InnerHtml = "--> " + ds.Tables[2].Rows[0]["IncentiveName"].ToString();
            //    grdDetails.DataSource = ds.Tables[0];
            //    grdDetails.DataBind();
            //    cmf.BindCtlto(true, ddlBank, objFetch.FetchBankMst(), 1, 0, false);
            //}

            //if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            //{
            //    lblbankname.Text = ds.Tables[1].Rows[0]["BankNamedesc"].ToString();
            //    lblBranchName.Text = ds.Tables[1].Rows[0]["BranchNames"].ToString();
            //    lblAccountNumber.Text = ds.Tables[1].Rows[0]["AccNo"].ToString();
            //    lblaccounttype.Text = ds.Tables[1].Rows[0]["AccountTypeName"].ToString();
            //    lblIFSC.Text = ds.Tables[1].Rows[0]["IFSCCode"].ToString();
            //    if (ds.Tables[1].Rows[0]["LoanAggrementAcNo"].ToString() != "")
            //    {
            //        lblLoanAggrementAcNo.Text = ds.Tables[1].Rows[0]["LoanAggrementAcNo"].ToString();
            //    }
            //    else
            //        lblLoanAggrementAcNo.Text = "Not Available";
            //    ViewState["bankid"] = ds.Tables[1].Rows[0]["Bankid"].ToString();
            //    ViewState["Accounttype"] = ds.Tables[1].Rows[0]["Accounttype"].ToString();
            //}
            //else
            //{
            //    RadioButtonList1.SelectedValue = "2";
            //    RadioButtonList1.Enabled = false;
            //    RadioButtonList1_SelectedIndexChanged(sender, e);
            //}

        }



    }
    public DataSet getReleaseProceedingsGMFinal_ROLLBACKED(string EnterperIncentiveID, string MstIncentiveId, string DistID, string SubIncTypeId)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            // da = new SqlDataAdapter("USP_GET_UNIT_INCENTIVEWISE_GM_FINAL_test", con.GetConnection);
            da = new SqlDataAdapter("USP_GET_UNIT_INCENTIVEWISE_GM_FINAL_LAPSED_ROLLBACKED", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@EnterperIncentiveID", SqlDbType.VarChar).Value = EnterperIncentiveID;
            da.SelectCommand.Parameters.Add("@MstIncentiveId", SqlDbType.VarChar).Value = MstIncentiveId;
            da.SelectCommand.Parameters.Add("@DistID", SqlDbType.VarChar).Value = DistID;
            da.SelectCommand.Parameters.Add("@SubIncTypeId", SqlDbType.VarChar).Value = SubIncTypeId;
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

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (linkfile == "")
        {
            grdDetails.Columns[14].Visible = false;
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label enterid = (e.Row.FindControl("lblEnterperIncentiveID") as Label);
            Label MstIncentiveId = (e.Row.FindControl("lblIncentiveID") as Label);
            string filepathnew = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LINKNEW"));
            string encpassword = gen.Encrypt(filepathnew, "SYSTIME");
            HyperLink h1 = (HyperLink)e.Row.FindControl("lnkFile");
            h1.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
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
    protected void Button6_Click(object sender, EventArgs e)
    {
        int i = 0;
        if (ddlworkingstatus.SelectedValue != "2" && ddlworkingstatus.SelectedValue != "3")
        {
            if (ddlworkingstatus.SelectedItem.Text.ToUpper() != "--SELECT--" && ddlBank.SelectedItem.Text.ToUpper() != "--SELECT--" && ddlaccounttype.SelectedItem.Text.ToUpper() != "--SELECT--")
            {
                if (ddlworkingstatus.SelectedValue != "2" && ddlworkingstatus.SelectedValue != "3")
                {
                    if ((txtBranchName.Text.Trim() != null && txtBranchName.Text.Trim() != "") && (txtAccNumber.Text.Trim() != null && txtAccNumber.Text.Trim() != "") && (txtIfscCode.Text.Trim() != null && txtIfscCode.Text.Trim() != ""))
                    {
                        i = 1;
                    }
                    else
                    {
                        i = 0;
                        lblmsg0.Text = "";
                        lblmsg0.Text = "Please enter all fields, all fields are mandatory";
                        lblmsg0.Visible = true;
                        Failure.Visible = true;
                        return;
                    }
                }
                else
                {
                    i = 1;
                }
            }
            else
            {
                i = 0;
                lblmsg0.Text = "";
                lblmsg0.Text = "Please enter all fields, all fields are mandatory";
                lblmsg0.Visible = true;
                Failure.Visible = true;
                return;
            }
        }
        else if (ddlworkingstatus.SelectedValue == "2")
        {
            if (txtremarks.Text.Trim() != null && txtremarks.Text.Trim() != "")
            {
                i = 1;
            }
            else
            {
                i = 0;
                lblmsg0.Text = "";
                lblmsg0.Text = "Please enter Remarks";
                lblmsg0.Visible = true;
                Failure.Visible = true;
                return;
            }

        }
        else if (ddlworkingstatus.SelectedValue == "3")
        {
            if (txtremarks.Text.Trim() != null && txtremarks.Text.Trim() != "")
            {
                i = 1;
            }
            else
            {
                i = 0;
                lblmsg0.Text = "";
                lblmsg0.Text = "Please enter Remarks";
                lblmsg0.Visible = true;
                Failure.Visible = true;
                return;
            }

        }
        if (i == 1)
        {
            if (ddlworkingstatus.SelectedValue == "2")
            {

                GmfinalProceedings gmfinalproceedings = new GmfinalProceedings();
                gmfinalproceedings.EnterperIncentiveID = ((Label)grdDetails.Rows[0].FindControl("lblEnterperIncentiveID")).Text;
                gmfinalproceedings.MstIncentiveId = ((Label)grdDetails.Rows[0].FindControl("lblIncentiveID")).Text;
                gmfinalproceedings.SLCNumer = ((Label)grdDetails.Rows[0].FindControl("lblSLCNumernor")).Text;
                gmfinalproceedings.WorkingStatus = ddlworkingstatus.SelectedItem.Text;
                gmfinalproceedings.Newbankname = "0";
                gmfinalproceedings.NewBranchname = "0";
                gmfinalproceedings.NewIFSCcode = "0";
                gmfinalproceedings.AccountNumber = "0";
                gmfinalproceedings.NewAccountType = "0";
                gmfinalproceedings.Remarks = txtremarks.Text;
                gmfinalproceedings.AccNoConfirmationFlg = "0";
                gmfinalproceedings.LoanAggrementAccountNo = "0";
                gmfinalproceedings.CreatedByid = Session["uid"].ToString();

                gmfinalproceedings.SubIncTypeId = Request.QueryString[3].ToString();
                int valid = gen.InsertGmfinalProceedingsGm(gmfinalproceedings);

                string message = "alert('Working Status Updated Successfully')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                Button6.Enabled = false;
                //Response.Redirect("IncentiveWiseListGM.aspx");
                //lblmsg.Text = "<font color='green'>Working Status Updated Successfully..!</font>";
                //success.Visible = true;
                //Failure.Visible = false;
            }
            else if (ddlworkingstatus.SelectedValue == "3")
            {

                GmfinalProceedings gmfinalproceedings = new GmfinalProceedings();
                gmfinalproceedings.EnterperIncentiveID = ((Label)grdDetails.Rows[0].FindControl("lblEnterperIncentiveID")).Text;
                gmfinalproceedings.MstIncentiveId = ((Label)grdDetails.Rows[0].FindControl("lblIncentiveID")).Text;
                gmfinalproceedings.SLCNumer = ((Label)grdDetails.Rows[0].FindControl("lblSLCNumernor")).Text;
                gmfinalproceedings.WorkingStatus = ddlworkingstatus.SelectedItem.Text;
                gmfinalproceedings.Newbankname = "0";
                gmfinalproceedings.NewBranchname = "0";
                gmfinalproceedings.NewIFSCcode = "0";
                gmfinalproceedings.AccountNumber = "0";
                gmfinalproceedings.NewAccountType = "0";
                gmfinalproceedings.Remarks = txtremarks.Text;
                gmfinalproceedings.AccNoConfirmationFlg = "0";
                gmfinalproceedings.LoanAggrementAccountNo = "0";
                gmfinalproceedings.CreatedByid = Session["uid"].ToString();

                gmfinalproceedings.SubIncTypeId = Request.QueryString[3].ToString();
                int valid = gen.InsertGmfinalProceedingsGm(gmfinalproceedings);

                string message = "alert('Working Status Updated to Abeyance Successfully')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                Button6.Enabled = false;
                //lblmsg.Text = "<font color='green'>Working Status Updated Successfully..!</font>";
                //success.Visible = true;
                //Failure.Visible = false;
            }
            else if (txtLoanAggrementAcNo.Text != "" && ddlworkingstatus.SelectedValue != "2" && ddlworkingstatus.SelectedValue != "3")
            {
                GmfinalProceedings gmfinalproceedings = new GmfinalProceedings();
                gmfinalproceedings.EnterperIncentiveID = ((Label)grdDetails.Rows[0].FindControl("lblEnterperIncentiveID")).Text;
                gmfinalproceedings.MstIncentiveId = ((Label)grdDetails.Rows[0].FindControl("lblIncentiveID")).Text;
                gmfinalproceedings.SLCNumer = ((Label)grdDetails.Rows[0].FindControl("lblSLCNumernor")).Text;
                gmfinalproceedings.WorkingStatus = ddlworkingstatus.SelectedItem.Text;
                gmfinalproceedings.Newbankname = ddlBank.SelectedItem.Text;
                gmfinalproceedings.NewBranchname = txtBranchName.Text;
                gmfinalproceedings.NewIFSCcode = txtIfscCode.Text;
                gmfinalproceedings.AccountNumber = txtAccNumber.Text;
                gmfinalproceedings.NewAccountType = ddlaccounttype.SelectedItem.Text;
                gmfinalproceedings.Remarks = txtremarks.Text;
                gmfinalproceedings.AccNoConfirmationFlg = RadioButtonList1.SelectedValue;
                gmfinalproceedings.LoanAggrementAccountNo = txtLoanAggrementAcNo.Text.ToString();
                gmfinalproceedings.CreatedByid = Session["uid"].ToString();

                gmfinalproceedings.SubIncTypeId = Request.QueryString[3].ToString();
                int valid = gen.InsertGmfinalProceedingsGm(gmfinalproceedings);

                string message = "alert('Working Status Updated Successfully')";
                Button6.Enabled = false;
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                //Response.Redirect("IncentiveWiseListGM.aspx");
            }
            else if (txtLoanAggrementAcNo.Text == "" && ddlworkingstatus.SelectedValue != "2" && ddlworkingstatus.SelectedValue != "3")
            {
                string message = "alert('Please enter Loan/Aggrement Account Number !')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }
            //lblmsg.Text = "<font color='green'>Working Status Updated Successfully..!</font>";
            //success.Visible = true;
            //Failure.Visible = false;
        }
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "1")
        {
            ddlBank.SelectedValue = ViewState["bankid"].ToString();
            txtBranchName.Text = lblBranchName.Text;
            txtAccNumber.Text = lblAccountNumber.Text;
            txtIfscCode.Text = lblIFSC.Text;
            ddlaccounttype.SelectedValue = ViewState["Accounttype"].ToString();

            ddlBank.Enabled = false;
            txtBranchName.Enabled = false;
            txtAccNumber.Enabled = false;
            txtIfscCode.Enabled = false;
            ddlaccounttype.Enabled = false;

        }
        else
        {
            ddlBank.Enabled = true;
            txtBranchName.Enabled = true;
            txtAccNumber.Enabled = true;
            txtIfscCode.Enabled = true;
            ddlaccounttype.Enabled = true;

            ddlBank.SelectedIndex = 0;
            txtBranchName.Text = "";
            txtAccNumber.Text = "";
            txtIfscCode.Text = "";
            ddlaccounttype.SelectedIndex = 0;
        }
    }

    protected void BtnSave3_Click(object sender, EventArgs e)
    {
        PCBClass objPCB = new PCBClass();
        comFunctions cmf = new comFunctions();
        General Gen = new General();

        string newPath = "";

        General t1 = new General();
        if (FileUpload1.HasFile)
        {
            string incentiveid = ((Label)grdDetails.Rows[0].FindControl("lblEnterperIncentiveID")).Text;// Session["EntprIncentive"].ToString();
            string masterincentiveid = ((Label)grdDetails.Rows[0].FindControl("lblIncentiveID")).Text;
            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\49");  // incentiveid2
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + "\\UCUpload" + "\\" + incentiveid.ToString() + "\\" + masterincentiveid.ToString());
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + "UCUpload" + "\\" + incentiveid.ToString() + "\\" + masterincentiveid.ToString();
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload1.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        //t1.InsertIncentiveAttachment(incentiveid, "100018", sFileName, serverpath, CrtdUser);
                        t1.InsertIncentiveAttachmentInspReports(incentiveid, "100018", sFileName, serverpath, CrtdUser, masterincentiveid.ToString(), "UCUpload");

                        lblFileName.NavigateUrl = serverpath + sFileName;
                        lblFileName.Text = sFileName;
                        lblFileName.Visible = true;
                        success.Visible = true;
                        lblmsg.Text = "File uploaded successfully.Please verify the OTP and click on submit button for submission";
                        Failure.Visible = false;
                        troptpbutton.Visible = true;
                        if (Session["DistrictID"] != null && Session["DistrictID"].ToString() != "" && Session["DistrictID"].ToString() != "0" && (Session["DistrictID"].ToString() == "7" || Session["DistrictID"].ToString() == "33"))
                        {
                            Button6.Enabled = false;
                        }
                        else
                        {
                            Button6.Enabled = true;
                        }
                    }
                    else
                    {
                        success.Visible = false;
                        Failure.Visible = true;
                    }

                }
                catch (Exception)//in case of an error
                {
                    DeleteFile(newPath + "\\" + sFileName);
                }
            }
        }
        else
        {
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
        }
    }

    public void DeleteFile(string strFileName)
    {//Delete file from the server
        if (strFileName.Trim().Length > 0)
        {
            FileInfo fi = new FileInfo(strFileName);
            if (fi.Exists)//if file exists delete it
            {
                fi.Delete();
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        txtOTPVerify.Enabled = true;
        try
        {
            if (lblFileName.Text != "")
            {
                DataSet ds = new DataSet();
                ds = GetGMMobileNumber(Session["uid"].ToString());
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    OTPMobile();
                    trotp.Visible = true;
                }
            }
            //if (txtemail.Text.ToString() != "" && txtcontact.Text.ToString() != "")
            //{
            //    string Text = Gen.checkMobile(txtcontact.Text.ToString(), txtemail.Text.ToString());
            //    if (Text == "1")
            //    {
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Email id or Mobile No already exists!!. Pl re- enter a new Email id and Mobile no');", true);
            //        txtemail.Text = "";
            //        txtcontact.Text = "";
            //    }

            //    else if (Text == "2")
            //    {
            //        OTPMobile();
            //        //An OTP has been sent to your mobile no. Please enter it to verify.
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('An OTP has been sent to your mobile no. Please enter it to verify.');", true);
            //    }

            //}
        }
        catch
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error!!. Pl try again.');", true);

        }
    }

    public void OTPMobile()
    {
        try
        {
            for (int cnt = 0; cnt < noOfChar; cnt++)
            {
                int OTPNo = oRandom.Next(1, charArr.Length);
                if (!strOTPMobile.Contains(charArr.GetValue(OTPNo).ToString()))
                {
                    strOTPMobile += charArr.GetValue(OTPNo);
                }
                else
                {
                    cnt--;
                }
            }
            finalOTPMobile = strOTPMobile;
            //////mobile message purpose
            DataSet dsdept = new DataSet();
            dsdept = GetGMMobileNumber(Session["uid"].ToString());
            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
            {
                string msgMobile = "Dear " + dsdept.Tables[0].Rows[0]["Emp_Name"].ToString() + "\r\n" + "" + "Your OTP is : '" + finalOTPMobile + "'" + "\r\n" + "Please Confirm the Bank A/C details and supporting document uploaded is Correct for sending UC of " + grdDetails.Rows[0].Cells[1].Text.Trim() + tdinvestments.InnerHtml;
                msgMobile = msgMobile + "\r\n" + "\r\n" + "\r\n" + "Commissionerate of Industries," + "\n" + "TS-iPASS .";

                string bodyMobile = msgMobile;
                SendSingleSMSnew(dsdept.Tables[0].Rows[0]["MobileNumber"].ToString(), bodyMobile, "1007716472066176462");

                sendOTPMail(dsdept.Tables[0].Rows[0]["EmailId"].ToString(), bodyMobile);
                string message = "alert('An OTP is sent to your your mobile no & email.Pl enter it to verify')";
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", message, true);


                // SendSingleSMSnew("9618445500", bodyMobile);
                // Button1.Text = "Click Here To Register";
                HDFmsgOTP.Value = strOTPMobile;   //stored otp message value here.
                //Button1.Visible = false;
                //imgid.Visible = true;
                //BtnSave_Click(null, null);
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void txtOTPVerify_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtOTPVerify.Enabled = false;

            if (Session["DistrictID"] != null && Session["DistrictID"].ToString() != "" && Session["DistrictID"].ToString() != "0" && (Session["DistrictID"].ToString() == "7" || Session["DistrictID"].ToString() == "33"))
            {
                Button6.Enabled = false;
                if (txtOTPVerify.Text == HDFmsgOTP.Value.ToString())
                {
                    // BtnSave_Click(sender, e);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('OTP Verification Successful. Please proceed further.');", true);
                    // BtnSave1.Enabled = true;
                    // BtnSave1.Visible = false;
                    // Button1.Enabled = false;
                    txtOTPVerify.Enabled = false;
                    Button6.Enabled = true;
                }
                else
                {
                    Button6.Enabled = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter valid OTP received on your mobile no !!.');", true);
                }
            }
            else
            {
                Button6.Enabled = true;
            }
           
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    public void sendOTPMail(string anothermail, string OTP)   //done by nikhil ... 03.04.17
    {

        try
        {
            string from = "tsipass.telangana@gmail.com"; //Replace this with your own correct Gmail Address

            string to = anothermail; //Replace this with the Email Address to whom you want to send the mail

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(to);
            //mail.CC.Add("kcsbabu@gmail.com");
            // mail.CC.Add("mahendar.ellandula27@gmail.com");
            //  mail.CC.Add("kcsbabu@gmail.com");

            mail.From = new MailAddress(from, ":: TSiPASS ::", System.Text.Encoding.UTF8);

            mail.Subject = "TSIPASS - OTP Verification -";// + Session["user_id"].ToString()

            mail.SubjectEncoding = System.Text.Encoding.UTF8;

            //mail.Body = "Dear " + txtfirstname.Text + " " + txtLastname.Text + "<br><br>  <H2>TSiPASS MIS  - Login Credentials</H2><br> Welcome to TS-iPASS. <br/> Dear <b> NAME: " + txtfirstname.Text + " " + txtLastname.Text + "</b>,<br/> Please use the following credentials to Login. <br><br> USER ID: " + txtname2.Text + "<br> <br> Password : " + txtpasswordnew.Text + "<br> <br> URL : <a href='http://120.138.9.236/IpassHome.aspx?OTP= " + OTP + "&Uid=" + txtname2.Text + "'> Click here for OTP Verification </a> <br> <br> Please Login by clicking the above link.<br><br>Thanks & Regards<br>Commissionerate of Industries, TS-iPASS Cell, Govt of Telangana, HYD";
            //mail.Body = "Dear " + txtfirstname.Text + " " + txtLastname.Text + "<br><br>  <H2>TSiPASS MIS  - OTP Verification</H2><br> Welcome to TS-iPASS. <br/> Dear <b> NAME: " + txtfirstname.Text + " " + txtLastname.Text + "</b>,<br> URL : <a href='http://localhost:12850/TSIPASS/IpassHome.aspx?OTP= " + OTP + "&Uid=" + txtname2.Text + "'> Click here for OTP Verification </a> <br> <br> Please Login by clicking the above link.<br><br>Thanks & Regards<br>Commissionerate of Industries, TS-iPASS Cell, Govt of Telangana, HYD";
            //// mail.Body = "Dear " + txtfirstname.Text + " " + txtLastname.Text + "<br><br>  <H2>TSiPASS MIS  - Login Credentials</H2><br> Welcome to TS-iPASS. <br/> Dear <b> NAME: " + txtfirstname.Text + " " + txtLastname.Text + "</b>,<br/> Please use the following credentials to Login. <br><br> USER ID: " + txtname2.Text + "<br> <br> Password : " + txtpasswordnew.Text + "<br> <br> URL:  <a href='https://ipass.telangana.gov.in' target='_blank' > TSiPASS </a> <br> <br> Please Login by clicking the above link.<br><br>Thanks & Regards<br>Commissionerate of Industries, TS-iPASS Cell, Govt of Telangana, HYD";
            mail.Body = OTP;

            mail.BodyEncoding = System.Text.Encoding.UTF8;


            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            SmtpClient client = new SmtpClient();

            //client.Credentials = new System.Net.NetworkCredential(from, "lrefskmlxnoowqtc");
           // client.Credentials = new System.Net.NetworkCredential(from, "zwcq vlxk gyor lpeg");
            client.Credentials = new System.Net.NetworkCredential(from, "fqeq nive azke giwb");


            client.Port = 587; // Gmail works on this port
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true; //Gmail works on Server Secured Layer
            try
            {
                client.Send(mail);

            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
                HttpContext.Current.Response.Write(errorMessage);
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    public String SendSingleSMSnew(String mobileNo, String message)
    {
        String username = "TSIPASS";
        String password = "kcsb@786";
        String senderid = "TSIPAS";
        String secureKey = "e8750728-53e8-4f29-9bc9-9f06975accb0";
        //Latest Generated Secure Key

        Stream dataStream;
        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequest");
        request.ProtocolVersion = HttpVersion.Version10;
        request.KeepAlive = false;
        request.ServicePoint.ConnectionLimit = 1;
        //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
        ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
        request.Method = "POST";
        //System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
        //System.Net.ServicePointManager.CertificatePolicy= new 
        String encryptedPassword = encryptedPasswod(password);
        String NewsecureKey = hashGenerator(username.Trim(), senderid.Trim(), message.Trim(), secureKey.Trim());
        String smsservicetype = "singlemsg"; //For single message.
        String query = "username=" + HttpUtility.UrlEncode(username.Trim()) +
            "&password=" + HttpUtility.UrlEncode(encryptedPassword) +
            "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +
            "&content=" + HttpUtility.UrlEncode(message.Trim()) +
            "&mobileno=" + HttpUtility.UrlEncode(mobileNo) +
            "&senderid=" + HttpUtility.UrlEncode(senderid.Trim()) +
            "&key=" + HttpUtility.UrlEncode(NewsecureKey.Trim());
        byte[] byteArray = Encoding.ASCII.GetBytes(query);
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = byteArray.Length;
        dataStream = request.GetRequestStream();
        dataStream.Write(byteArray, 0, byteArray.Length);
        dataStream.Close();
        WebResponse response = request.GetResponse();
        String Status = ((HttpWebResponse)response).StatusDescription;
        dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        String responseFromServer = reader.ReadToEnd();
        reader.Close();
        dataStream.Close();
        response.Close();
        return responseFromServer;
    }

    protected String encryptedPasswod(String password)
    {
        byte[] encPwd = Encoding.UTF8.GetBytes(password);
        //static byte[] pwd = new byte[encPwd.Length];
        HashAlgorithm sha1 = HashAlgorithm.Create("SHA1");
        byte[] pp = sha1.ComputeHash(encPwd);
        // static string result = System.Text.Encoding.UTF8.GetString(pp);
        StringBuilder sb = new StringBuilder();
        foreach (byte b in pp)
        {
            sb.Append(b.ToString("x2"));
        }
        return sb.ToString();
    }

    /// <summary>

    /// Method to Generate hash code 

    /// </summary>

    /// <param name="secure_key">your last generated Secure_key

    protected String hashGenerator(String Username, String sender_id, String message, String secure_key)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Username).Append(sender_id).Append(message).Append(secure_key);
        byte[] genkey = Encoding.UTF8.GetBytes(sb.ToString());
        //static byte[] pwd = new byte[encPwd.Length];
        HashAlgorithm sha1 = HashAlgorithm.Create("SHA512");
        byte[] sec_key = sha1.ComputeHash(genkey);
        StringBuilder sb1 = new StringBuilder();
        for (int i = 0; i < sec_key.Length; i++)
        {
            sb1.Append(sec_key[i].ToString("x2"));
        }
        return sb1.ToString();
    }

    public DataSet GetGMMobileNumber(string userid)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_GMMOBILENUMBER", con.GetConnection);
            da.SelectCommand.Parameters.Add("@USERID", SqlDbType.VarChar).Value = userid.ToString();
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
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

    protected void ddlworkingstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlworkingstatus.SelectedValue == "2" || ddlworkingstatus.SelectedValue == "3")
        {
            //Button6.Enabled = true;

            Button6.Enabled = true;
            trBankDetails1.Visible = false;
            trBankDetails2.Visible = false;
            trBankDetails3.Visible = false;
            tdROLL1.Visible = false;
            tdROLL2.Visible = false;
            tdROLL3.Visible = false;
            txtremarks.Text = "";
        }
        else
        {
            trBankDetails1.Visible = true;
            trBankDetails2.Visible = true;
            trBankDetails3.Visible = true;
            troptpbutton.Visible = false;
            if (trrollbackeddata.Visible == true && trrollbackedgrid.Visible == true)
            {
                if (ddlworkingstatus.SelectedValue == "1")
                {
                    tdROLL1.Visible = true;
                    tdROLL2.Visible = true;
                    tdROLL3.Visible = true;
                    RadioButtonList1.Enabled = false;
                }
                else
                {
                    tdROLL1.Visible = false;
                    tdROLL2.Visible = false;
                    tdROLL3.Visible = false;
                }
            }

        }
    }
    protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlBank.SelectedValue.ToString() == "195")
        {
            trNBFC.Visible = true;

        }
        else
        {
            trNBFC.Visible = false;
        }

    }
    public String SendSingleSMSnew(String mobileNo, String message, string templID)
    {
        String username = "TSIPASS";
        String password = "kcsb@786";
        String senderid = "TSIPAS";
        String secureKey = "e8750728-53e8-4f29-9bc9-9f06975accb0";

        Stream dataStream = null;
        StreamReader reader = null;
        WebResponse response = null;
        try
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequestDLT");
            request.ProtocolVersion = HttpVersion.Version10;
            request.KeepAlive = true;
            request.ServicePoint.ConnectionLimit = 10;
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            String encryptedPassword = encryptedPasswod(password);
            String newSecureKey = hashGenerator(username.Trim(), senderid.Trim(), message.Trim(), secureKey.Trim());
            String smsservicetype = "singlemsg";

            String query = "username=" + HttpUtility.UrlEncode(username.Trim()) +
                           "&password=" + HttpUtility.UrlEncode(encryptedPassword) +
                           "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +
                           "&content=" + HttpUtility.UrlEncode(message.Trim()) +
                           "&mobileno=" + HttpUtility.UrlEncode(mobileNo) +
                           "&senderid=" + HttpUtility.UrlEncode(senderid.Trim()) +
                           "&key=" + HttpUtility.UrlEncode(newSecureKey.Trim()) +
                           "&templateid=" + HttpUtility.UrlEncode(templID.Trim());

            byte[] byteArray = Encoding.ASCII.GetBytes(query);
            request.ContentLength = byteArray.Length;

            dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            response = request.GetResponse();
            String status = ((HttpWebResponse)response).StatusDescription;
            dataStream = response.GetResponseStream();
            reader = new StreamReader(dataStream);

            String responseFromServer = reader.ReadToEnd();

            return responseFromServer;
        }
        catch (WebException webEx)
        {
            return "Error: " + webEx.Message;
        }
        catch (Exception ex)
        {
            return "Error: " + ex.Message;
        }
        finally
        {
            if (reader != null) reader.Close();
            if (dataStream != null) dataStream.Close();
            if (response != null) response.Close();
        }
    }
    public String SendSingleSMSnewold(String mobileNo, String message, string templID)
    {
        String username = "TSIPASS";
        String password = "kcsb@786";
        String senderid = "TSIPAS";
        String secureKey = "e8750728-53e8-4f29-9bc9-9f06975accb0";
        //Latest Generated Secure Key

        Stream dataStream;
        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequestDLT");
        request.ProtocolVersion = HttpVersion.Version10;
        request.KeepAlive = false;
        request.ServicePoint.ConnectionLimit = 1;
        //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
        ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
        request.Method = "POST";
        //System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
        //System.Net.ServicePointManager.CertificatePolicy= new 
        String encryptedPassword = encryptedPasswod(password);
        String NewsecureKey = hashGenerator(username.Trim(), senderid.Trim(), message.Trim(), secureKey.Trim());
        String smsservicetype = "singlemsg"; //For single message.
        String query = "username=" + HttpUtility.UrlEncode(username.Trim()) +
            "&password=" + HttpUtility.UrlEncode(encryptedPassword) +
            "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +
            "&content=" + HttpUtility.UrlEncode(message.Trim()) +
            "&mobileno=" + HttpUtility.UrlEncode(mobileNo) +
            "&senderid=" + HttpUtility.UrlEncode(senderid.Trim()) +
            "&key=" + HttpUtility.UrlEncode(NewsecureKey.Trim()) +
            "&templateid=" + HttpUtility.UrlEncode(templID.Trim());


        byte[] byteArray = Encoding.ASCII.GetBytes(query);
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = byteArray.Length;
        dataStream = request.GetRequestStream();
        dataStream.Write(byteArray, 0, byteArray.Length);
        dataStream.Close();
        WebResponse response = request.GetResponse();
        String Status = ((HttpWebResponse)response).StatusDescription;
        dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        String responseFromServer = reader.ReadToEnd();
        reader.Close();
        dataStream.Close();
        response.Close();
        return responseFromServer;
    }
    protected void RBTYESORNO_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RBTYESORNO.SelectedValue == "Y")
        {
            DataSet ds = new DataSet();
            ds = GETWORKINGSTATUSDETAILS(Request.QueryString[1].ToString(), Request.QueryString[2].ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlBank.SelectedItem.Text = ds.Tables[0].Rows[0]["NewBankName"].ToString();
                txtBranchName.Text = ds.Tables[0].Rows[0]["NewBranchName"].ToString();
                txtAccNumber.Text = ds.Tables[0].Rows[0]["NewAccNo"].ToString();
                txtIfscCode.Text = ds.Tables[0].Rows[0]["NewIFSCCode"].ToString();
                ddlaccounttype.SelectedItem.Text = ds.Tables[0].Rows[0]["NewAccountType"].ToString();
                txtremarks.Text = ds.Tables[0].Rows[0]["BankAccountRemarks"].ToString();
                if (ds.Tables[0].Rows[0]["LoanAggrementAcNo"].ToString() == null || ds.Tables[0].Rows[0]["LoanAggrementAcNo"].ToString() == "")
                {
                    txtLoanAggrementAcNo.Enabled = true;
                    txtLoanAggrementAcNo.Text = "";
                }
                else
                {
                    txtLoanAggrementAcNo.Text = ds.Tables[0].Rows[0]["LoanAggrementAcNo"].ToString();
                }
                ddlBank.Enabled = false;
                txtBranchName.Enabled = false;
                txtAccNumber.Enabled = false;
                txtIfscCode.Enabled = false;
                ddlaccounttype.Enabled = false;
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
                {
                    Button6.Enabled = true;
                    int c = ds.Tables[1].Rows.Count;
                    string sen, sen1, sen2, sennew;
                    int i = 0;

                    while (i < c)
                    {
                        sen2 = ds.Tables[1].Rows[i][0].ToString();
                        sen1 = sen2.Replace(@"\", @"/");
                        sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                        sennew = ds.Tables[1].Rows[i]["LINKNEW"].ToString();// LINKNEW
                        string encpassword = gen.Encrypt(sennew, "SYSTIME");

                        if (sen.Contains("UCUpload"))
                        {
                            lblFileName.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            lblFileName.Visible = true;
                            lblFileName.Text = ds.Tables[1].Rows[i][1].ToString();
                            Label444.Text = ds.Tables[1].Rows[i][1].ToString();

                        }

                        i++;
                    }
                }

            }
            else
            {
                ddlBank.Enabled = true;
                txtBranchName.Enabled = true;
                txtAccNumber.Enabled = true;
                txtIfscCode.Enabled = true;
                ddlaccounttype.Enabled = true;

                ddlBank.SelectedIndex = 0;
                txtBranchName.Text = "";
                txtAccNumber.Text = "";
                txtIfscCode.Text = "";
                ddlaccounttype.SelectedIndex = 0;
            }
        }
        else
        {
            ddlBank.Enabled = true;
            txtBranchName.Enabled = true;
            txtAccNumber.Enabled = true;
            txtIfscCode.Enabled = true;
            ddlaccounttype.Enabled = true;

            ddlBank.SelectedIndex = 0;
            txtBranchName.Text = "";
            txtAccNumber.Text = "";
            txtIfscCode.Text = "";
            ddlaccounttype.SelectedIndex = 0;
        }
    }
    public DataSet GETWORKINGSTATUSDETAILS(string ENTERPINCID, string MSTINCID)
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter myDataAdapter;
            myDataAdapter = new SqlDataAdapter("SP_GETWORKINGSTATUSDETAILS", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (ENTERPINCID.Trim() == "" || ENTERPINCID.Trim() == null || ENTERPINCID.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ENTERPINCID", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ENTERPINCID", SqlDbType.VarChar).Value = ENTERPINCID;
            }

            if (MSTINCID.Trim() == "" || MSTINCID.Trim() == null || MSTINCID.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@MSTINCID", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@MSTINCID", SqlDbType.VarChar).Value = MSTINCID;
            }


            dsa = new System.Data.DataSet();
            myDataAdapter.Fill(dsa);
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;
        }
        finally
        {
            con.CloseConnection();

        }
        return dsa;
    }
    protected void ddlBank_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (ddlworkingstatus.SelectedValue == "0")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please select Working Status.');", true);
            ddlworkingstatus.Focus();
            ddlBank.ClearSelection();
        }
        if (trrollbackeddata.Visible == true && trrollbackedgrid.Visible == true && ddlworkingstatus.SelectedValue == "1")
        {
            if (RBTYESORNO.SelectedValue != "Y" && RBTYESORNO.SelectedValue != "N")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please select weather you want to continue with above rollbacked working status details.');", true);
                RBTYESORNO.Focus();
                ddlBank.ClearSelection();

            }

        }
    }
    protected void grdlapseddata_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink HyperLinkSubsidy = (e.Row.FindControl("HyperLinkSubsidy") as HyperLink);
            string filepathnew = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LINKNEW"));
            if (filepathnew != "")
            {
                string encpassword = gen.Encrypt(filepathnew, "SYSTIME");
                HyperLinkSubsidy.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
            }
            else
            {
                HyperLinkSubsidy.Visible = false;
            }
        }
    }
}