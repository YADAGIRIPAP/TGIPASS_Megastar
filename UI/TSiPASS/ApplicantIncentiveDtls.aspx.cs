using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Threading;
using System.Security.Cryptography;
using Org.BouncyCastle.Asn1.Ocsp;


public partial class UI_TSiPASS_ApplicantIncentiveDtls : System.Web.UI.Page
{
    General Gen = new General();
    DataSet ds = new DataSet();
    DataSet odds = new DataSet();
    comFunctions cmf = new comFunctions();
    comFunctions obcmf = new comFunctions();
    Fetch objFetch = new Fetch();
    static DataTable dtMyTable;
    static DataTable dtMyTableCertificate;
    static DataTable dtMyTableAmount;
    static DataTable dtMyTableReject;
    static DataTable dtMyTableCertificateAmount;
    string LoanAggrementCheck = "0";
    string casteGenderGmUpdate = "0";
    List<officerRemarks> lstremarksad = new List<officerRemarks>();
    List<officerRemarks> lstremarks = new List<officerRemarks>();
    List<officerRemarks> lstremarksamount = new List<officerRemarks>();
    List<officerForwarded> lstincentives = new List<officerForwarded>();
    static DataTable dtMyTable1;
    DataSet dsCAF = new DataSet();
    DataSet dsCAF_Rej = new DataSet();
    string Incids = "";
    string districtid = "";
    string ISDIFFABLED = "";
    string ISTIDEAFLAG = "";
    string TSPFLAG = "";
    string ISDIFFABLES = "";
    DB.DB con = new DB.DB();
    #region OTP Chars  //variables for OTP -> Nikhil.
    char[] charArr = "0123456789".ToCharArray();
    string strOTPMobile = string.Empty;
    string strOTPMail = string.Empty;
    string finalOTPMail = "";
    string finalOTPMobile = "";
    Random oRandom = new Random();
    int noOfChar = 6;
    DataSet odsRejection;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["DummyLogin"] != null)
            {
                if (Session["DummyLogin"].ToString() == "Y")
                {
                    string QUERY_STRING = Request.ServerVariables.Get("QUERY_STRING").ToString();
                    Response.Redirect("ApplicantIncentiveDtlsDraftView.aspx?" + QUERY_STRING);
                }
            }
            if (Session["uid"] != null)
            {
                MaintainScrollPositionOnPostBack = true;
                Page.Form.Attributes.Add("enctype", "multipart/form-data");
                try
                {
                    if (Request.QueryString.ToString().Contains("IncIds"))
                    {
                        Incids = Request.QueryString["IncIds"].ToString();
                    }
                    else
                    {
                        Incids = null;
                    }

                    if (!IsPostBack)
                    {
                        string Applicantinid = "";
                        string Status = "";
                        string SentFrom = "";
                        if (!IsPostBack)
                        {

                            dtMyTableCertificate = createtablecrtificate();
                            Session["CertificateTb2"] = dtMyTableCertificate;
                            dtMyTableCertificateAmount = createtablecrtificateAmount();
                            Session["CertificateTbAmount"] = dtMyTableCertificateAmount;
                            dtMyTableReject = createtablerejection();
                            Session["CertificateTbReject"] = dtMyTableReject;
                            DataSet dsjdReject = new DataSet();
                            dsjdReject = Gen.getJDRejectedList(Request.QueryString[0].ToString(), Incids);
                            GVJDRejectedCases.DataSource = null;
                            GVJDRejectedCases.DataBind();
                            if (dsjdReject != null && dsjdReject.Tables.Count > 0 && dsjdReject.Tables[0].Rows.Count > 0)
                            {
                                GVJDRejectedCases.DataSource = dsjdReject.Tables[0];
                                GVJDRejectedCases.DataBind();
                                Div24.Visible = true;
                            }
                            else
                            {
                                Div24.Visible = false;
                            }
                            DataSet dsaddlscGM = new DataSet();
                            dsaddlscGM = GetAddlSSCData_REPORT(Request.QueryString[0].ToString(), Status, SentFrom, "AD", Incids);
                            if (dsaddlscGM != null && dsaddlscGM.Tables.Count > 0 && dsaddlscGM.Tables[0].Rows.Count > 0)
                            {
                                DivSSCgm.Visible = true;
                                trDivSSCgm.Visible = true;
                                trDivSSCgm1.Visible = true;
                                //trqueryDtls.Visible = true;
                                //trQueryletter.Visible = true; // commented by shankar on 21-01-2019
                                //trsendresponcetocoi.Visible = true;
                                gvsscinspectionGM.DataSource = dsaddlscGM.Tables[0];
                                gvsscinspectionGM.DataBind();


                                //HySSCinsp.NavigateUrl = dsaddlsc.Tables[0].Rows[0]["SSCREPORT"].ToString();


                            }
                            DataSet dsjdreturned = new DataSet();
                            dsjdreturned = getJDreturnedList(Request.QueryString[0].ToString(), Incids);
                            gvJDreturnedDtls.DataSource = null;
                            gvJDreturnedDtls.DataBind();
                            if (dsjdreturned != null && dsjdreturned.Tables.Count > 0 && dsjdreturned.Tables[0].Rows.Count > 0)
                            {
                                gvJDreturnedDtls.DataSource = dsjdreturned.Tables[0];
                                gvJDreturnedDtls.DataBind();
                                Div55.Visible = true;
                            }
                            else
                            {
                                Div55.Visible = false;
                            }
                            DataSet dsSVCDEPTreturned = new DataSet();
                            dsSVCDEPTreturned = getSVCDEPTreturnedList(Request.QueryString[0].ToString(), Incids);
                            grdSVCreturneddetails.DataSource = null;
                            grdSVCreturneddetails.DataBind();
                            if (dsSVCDEPTreturned != null && dsSVCDEPTreturned.Tables.Count > 0 && dsSVCDEPTreturned.Tables[0].Rows.Count > 0)
                            {
                                grdSVCreturneddetails.DataSource = dsSVCDEPTreturned.Tables[0];
                                grdSVCreturneddetails.DataBind();
                                DIVSVCDEPTRETURNEDAPPLICATIONS.Visible = true;
                            }
                            else
                            {
                                DIVSVCDEPTRETURNEDAPPLICATIONS.Visible = false;
                            }
                            DataSet dsSVCDEPTAPPROVED = new DataSet();
                            dsSVCDEPTAPPROVED = getSVCDEPAPPROVEDList(Request.QueryString[0].ToString(), Incids);
                            GRDSVCAPPROVED.DataSource = null;
                            GRDSVCAPPROVED.DataBind();
                            if (dsSVCDEPTAPPROVED != null && dsSVCDEPTAPPROVED.Tables.Count > 0 && dsSVCDEPTAPPROVED.Tables[0].Rows.Count > 0)
                            {
                                GRDSVCAPPROVED.DataSource = dsSVCDEPTAPPROVED.Tables[0];
                                GRDSVCAPPROVED.DataBind();
                                DIVSVCAPPROVEDHEAD.Visible = true;
                            }
                            else
                            {
                                DIVSVCAPPROVEDHEAD.Visible = false;
                            }
                            DataSet dsCOMMISSIONERreturned = new DataSet();
                            dsCOMMISSIONERreturned = getCOMMISSIONERreturnedList(Request.QueryString[0].ToString(), Incids);
                            grdcommissionerreturned.DataSource = null;
                            grdcommissionerreturned.DataBind();
                            if (dsCOMMISSIONERreturned != null && dsCOMMISSIONERreturned.Tables.Count > 0 && dsCOMMISSIONERreturned.Tables[0].Rows.Count > 0)
                            {
                                grdcommissionerreturned.DataSource = dsCOMMISSIONERreturned.Tables[0];
                                grdcommissionerreturned.DataBind();
                                DIVCOMMRET.Visible = true;
                            }
                            else
                            {
                                DIVCOMMRET.Visible = false;
                            }
                            DataSet dsCOMMISSIONERAPPROVED = new DataSet();
                            dsCOMMISSIONERAPPROVED = getCOMMISSIONERAPPROVEDList(Request.QueryString[0].ToString(), Incids);
                            grdcommissionerapproved.DataSource = null;
                            grdcommissionerapproved.DataBind();
                            if (dsCOMMISSIONERAPPROVED != null && dsCOMMISSIONERAPPROVED.Tables.Count > 0 && dsCOMMISSIONERAPPROVED.Tables[0].Rows.Count > 0)
                            {
                                grdcommissionerapproved.DataSource = dsCOMMISSIONERAPPROVED.Tables[0];
                                grdcommissionerapproved.DataBind();
                                DIVAPPROVED_COMMISIONER1.Visible = true;
                            }
                            else
                            {
                                DIVAPPROVED_COMMISIONER1.Visible = false;
                            }
                            DataSet dsaddlreturned = new DataSet();
                            dsaddlreturned = getaddlreturnedList(Request.QueryString[0].ToString(), Incids);
                            gvADDLreturnedDtls.DataSource = null;
                            gvADDLreturnedDtls.DataBind();
                            if (dsaddlreturned != null && dsaddlreturned.Tables.Count > 0 && dsaddlreturned.Tables[0].Rows.Count > 0)
                            {
                                gvADDLreturnedDtls.DataSource = dsaddlreturned.Tables[0];
                                gvADDLreturnedDtls.DataBind();
                                Div58.Visible = true;
                            }
                            else
                            {
                                Div58.Visible = false;
                            }

                            DataSet dsjdAbeyance = new DataSet();
                            dsjdAbeyance = Gen.getJDAbeyancedList(Request.QueryString[0].ToString(), Incids);
                            gvJDAbeyancedDtls.DataSource = null;
                            gvJDAbeyancedDtls.DataBind();
                            if (dsjdAbeyance != null && dsjdAbeyance.Tables.Count > 0 && dsjdAbeyance.Tables[0].Rows.Count > 0)
                            {
                                gvJDAbeyancedDtls.DataSource = dsjdAbeyance.Tables[0];
                                gvJDAbeyancedDtls.DataBind();
                                Div28.Visible = true;
                            }
                            else
                            {
                                Div28.Visible = false;
                            }
                            DataSet dsjdSSC = new DataSet();
                            dsjdSSC = getJDSSCList(Request.QueryString[0].ToString(), Incids);
                            gvJDSSCDtls.DataSource = null;
                            gvJDSSCDtls.DataBind();
                            if (dsjdSSC != null && dsjdSSC.Tables.Count > 0 && dsjdSSC.Tables[0].Rows.Count > 0)
                            {
                                gvJDSSCDtls.DataSource = dsjdSSC.Tables[0];
                                gvJDSSCDtls.DataBind();
                                Div40.Visible = true;

                            }
                            else
                            {
                                Div40.Visible = false;

                            }
                            if (dsjdSSC != null && dsjdSSC.Tables.Count > 1 && dsjdSSC.Tables[1].Rows.Count > 0)
                            {
                                Div51.Visible = true;
                                // DivGMReturned.Visible = true;
                                trFMrollback.Visible = true;
                                gvRollbackGM.DataSource = dsjdSSC.Tables[1];
                                gvRollbackGM.DataBind();
                            }

                        }
                        string Role_Code = Session["Role_Code"].ToString().Trim().TrimStart();
                        Applicantinid = Request.QueryString[0].ToString();
                        Status = Request.QueryString[1].ToString();
                        if (Request.QueryString.ToString().Contains("IncIds"))
                        {
                            Incids = Request.QueryString["IncIds"].ToString();
                        }
                        Session["querystring"] = "EntrpId=" + Applicantinid + "&Sts=" + Status;
                        SentFrom = Session["User_Code"].ToString();
                        string Userid = "";
                        string DisignationLoad = "";
                        string usercode = "";
                        if (Role_Code == "COI-AD" || Role_Code == "COI-DD" || Role_Code == "COI-SUPDT")
                        {
                            Userid = "3377";
                        }
                        else
                        {
                            Userid = Session["uid"].ToString();
                        }

                        DataSet dsoldapps = new DataSet();
                        dsoldapps = Gen.GetOldIncetiveDetailsApplications(Applicantinid, Status, Userid, Userid);
                        if (dsoldapps != null && dsoldapps.Tables.Count > 0 && dsoldapps.Tables[0].Rows.Count > 0)
                        {
                            Gvoldapplications.DataSource = dsoldapps.Tables[0];
                            Gvoldapplications.DataBind();
                            oldapps.Visible = true;
                        }
                        else
                        {
                            oldapps.Visible = false;
                        }
                        if (Request.QueryString[1].ToString() == "91")
                        {
                            Role_Code = "AR";
                            trinspectionname1.Visible = false;
                            Failure.Visible = false;
                            Div21.Visible = true;
                        }
                        ds = Gen.GetIncetiveDetailsdept(Applicantinid, Status, Userid, Userid, Incids);
                        try
                        {
                            divCommonAppli.Visible = true;
                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                if (ds.Tables[0].Rows[0]["LoanAggrementAcNo"].ToString() != null && ds.Tables[0].Rows[0]["GM_LoanAggrementAcNo_Verify"].ToString() != "")
                                {
                                    txtLoanAgreement.Text = ds.Tables[0].Rows[0]["GM_LoanAggrementAcNo"].ToString();
                                    if (ds.Tables[0].Rows[0]["GM_LoanAggrementAcNo_Verify"].ToString() != "Y")
                                    {
                                        lblLoanAggrement.Visible = true;
                                        lblLoanAggrement.Text = "Please verify the Loan/Aggrement Number";
                                    }
                                    //if (ds.Tables[0].Rows[0]["GM_LoanAggrementAcNo_Verify"].ToString() == "Y")
                                    if (ds.Tables[0].Rows[0]["GM_LoanAggrementAcNo_Verify"].ToString() == "Y" && ds.Tables[0].Rows[0]["LoanAggrementAcNo"].ToString() != "")
                                    {
                                        chckLoanAggrement.Checked = true;
                                        lblLoanAggrement.Visible = false;
                                        chckLoanAggrement.Enabled = true;
                                        //txtLoanAgreement.Enabled = false;
                                        txtLoanAgreement.Enabled = true;
                                        txtLoanAgreement.Text = ds.Tables[0].Rows[0]["LoanAggrementAcNo"].ToString();
                                        LoanAggrementCheck = "1";
                                    }

                                }
                                else if (ds.Tables[0].Rows[0]["LoanAggrementAcNo"].ToString() == "")
                                {
                                    txtLoanAgreement.Text = "Not Available";
                                    lblLoanAggrement.Visible = true;
                                    lblLoanAggrement.Text = "Please enter Loan/Aggrement Number and verify";
                                }
                                if (ds.Tables[0].Rows[0]["ApplliedDate"].ToString() != null && ds.Tables[0].Rows[0]["ApplliedDate"].ToString() != "")
                                {
                                    lblapplicationdate.Text = ds.Tables[0].Rows[0]["ApplliedDate"].ToString();
                                }
                                if (ds.Tables[0].Rows[0]["applicationno"].ToString() != null && ds.Tables[0].Rows[0]["applicationno"].ToString() != "")
                                {
                                    lblApplicationNo.Text = ds.Tables[0].Rows[0]["applicationno"].ToString();
                                }
                                if (ds.Tables[0].Rows[0]["SectorNew"].ToString() != null && ds.Tables[0].Rows[0]["SectorNew"].ToString() != "")
                                {
                                    lblsector.Text = ds.Tables[0].Rows[0]["SectorNew"].ToString();
                                }
                                if (ds.Tables[0].Rows[0]["VehicleNumber"].ToString() != null && ds.Tables[0].Rows[0]["VehicleNumber"].ToString() != "")
                                {
                                    lblvehno.Text = ds.Tables[0].Rows[0]["VehicleNumber"].ToString();
                                }
                                else
                                {
                                    lblvehno.Text = "";
                                    lblisvehicle.Text = "";
                                }
                                txtudyogAadharNo.Text = ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
                                txtUnitname.Text = ds.Tables[0].Rows[0]["UnitName"].ToString();
                                txtApplicantName.Text = ds.Tables[0].Rows[0]["ApplciantName"].ToString();
                                txtPanNumber.Text = ds.Tables[0].Rows[0]["PanNo"].ToString();
                                txtTinNumber.Text = ds.Tables[0].Rows[0]["TinNO"].ToString();
                                ddlCategory.Text = ds.Tables[0].Rows[0]["Category"].ToString();
                                ddltypeofOrg.Text = ds.Tables[0].Rows[0]["OrgType2"].ToString();
                                ddlindustryStatus.Text = ds.Tables[0].Rows[0]["IdsustryStatus"].ToString();

                                txtDateofCommencement.Text = ds.Tables[0].Rows[0]["DCP"].ToString();
                                rblCaste.Text = ds.Tables[0].Rows[0]["Caste"].ToString();
                                rblCaste.Text = ds.Tables[0].Rows[0]["SocialStatus"].ToString();
                                if (ds.Tables[0].Rows[0]["IsDifferentlyAbled"].ToString() != "")
                                    if (ds.Tables[0].Rows[0]["IsDifferentlyAbled"].ToString() == "Y")
                                        lblPhc.Text = "YES";
                                    else
                                        lblPhc.Text = "NO";
                                ddldistrictunit.Text = ds.Tables[0].Rows[0]["UnitDistName"].ToString();
                                ddlUnitMandal.Text = ds.Tables[0].Rows[0]["UNITMANDAL"].ToString();
                                ddlVillageunit.Text = ds.Tables[0].Rows[0]["UNITVILLAGE"].ToString(); ;
                                txtunitaddhno.Text = ds.Tables[0].Rows[0]["UnitHNO"].ToString();
                                txtstreetunit.Text = ds.Tables[0].Rows[0]["UnitStreet"].ToString();
                                txtunitmobileno.Text = ds.Tables[0].Rows[0]["UnitMObileNo"].ToString();
                                txtunitemailid.Text = ds.Tables[0].Rows[0]["UnitEmail"].ToString();
                                ddldistrictoffc.Text = ds.Tables[0].Rows[0]["OFFCDISTNAME"].ToString();
                                ddloffcmandal.Text = ds.Tables[0].Rows[0]["OFFCMANDAL"].ToString();
                                ddlvilloffc.Text = ds.Tables[0].Rows[0]["OFFCVILLAGE"].ToString();
                                txtoffaddhnno.Text = ds.Tables[0].Rows[0]["OffcHNO"].ToString();
                                txtstreetoffice.Text = ds.Tables[0].Rows[0]["OffcStreet"].ToString();
                                txtOffcMobileNO.Text = ds.Tables[0].Rows[0]["OffcMobileNO"].ToString();
                                txtOffcEmail.Text = ds.Tables[0].Rows[0]["OffcEmail"].ToString();
                                HyperLink2.NavigateUrl = "frmInspRepDrft.aspx?EntrpId=" + ds.Tables[0].Rows[0]["IncentveID"].ToString();
                                anchortaglink.NavigateUrl = "frmInspRepDrft.aspx?EntrpId=" + ds.Tables[0].Rows[0]["IncentveID"].ToString();
                                ViewState["IncentveID"] = ds.Tables[0].Rows[0]["IncentveID"].ToString();
                                if (Request.QueryString[1].ToString() != "91")
                                    Officers(ds.Tables[0].Rows[0]["District_Id"].ToString());
                                DataSet dsIOQuery = new DataSet();
                                odsRejection = new DataSet();
                                if (Request.QueryString[1].ToString() == "91")
                                {
                                    SqlConnection osqlconn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString); ;
                                    osqlconn.Open();
                                    SqlDataAdapter da;
                                    try
                                    {
                                        da = new SqlDataAdapter("[FetchIncentives_CAF_DEPT_Rejection]", osqlconn);
                                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                                        da.SelectCommand.Parameters.Add("@IncentiveID", SqlDbType.VarChar).Value = Request.QueryString["EntrpId"].ToString();
                                        da.Fill(odsRejection);//FillDetailsabc(odsRejection);
                                    }
                                    catch (Exception ex)
                                    {
                                        throw ex;
                                    }
                                    finally
                                    {
                                        osqlconn.Close();
                                    }
                                }

                                dsIOQuery = Gen.GetIOQueryHistory(Applicantinid, Role_Code, Incids);
                                GVIOQueryStatus.DataSource = null;
                                GVIOQueryStatus.DataBind();
                                if (dsIOQuery != null && dsIOQuery.Tables.Count > 0 && dsIOQuery.Tables[0].Rows.Count > 0)
                                {
                                    GVIOQueryStatus.DataSource = dsIOQuery.Tables[0];
                                    GVIOQueryStatus.DataBind();
                                    //trqueryDtls1IO.Visible = true;
                                    Div21.Visible = true;
                                }


                                else
                                {
                                    //trqueryDtls1IO.Visible = false;
                                    Div21.Visible = false;
                                }
                                divCommonAppli.Visible = true;

                            }
                            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                            {
                                if (ds.Tables[1].Rows[0]["MstIncentiveId"].ToString() != null && ds.Tables[1].Rows[0]["MstIncentiveId"].ToString() != "")
                                {
                                    ViewState["MstIncentiveId"] = ds.Tables[1].Rows[0]["MstIncentiveId"].ToString();
                                }
                            }
                            else if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                            {
                                if (ds.Tables[2].Rows[0]["MstIncentiveId"].ToString() != null && ds.Tables[2].Rows[0]["MstIncentiveId"].ToString() != "")
                                {
                                    ViewState["MstIncentiveId"] = ds.Tables[2].Rows[0]["MstIncentiveId"].ToString();
                                }
                            }
                            if (Role_Code == "GM" || Request.QueryString[1].ToString() == "91")
                            {
                                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                                {
                                    /// CODE ADDED BY MADHURI ON 18/03/2021 DELAY REASON FROM GM////

                                    if (Role_Code == "GM")
                                    {
                                        if (Status == "3")
                                        {
                                            DataSet dsgmdelay = Checkgmdelayreason(Applicantinid, Status, Userid, Userid, Incids);
                                            if (dsgmdelay != null && dsgmdelay.Tables.Count > 0 && dsgmdelay.Tables[0].Rows.Count > 0)
                                            {
                                                if (dsgmdelay.Tables[0].Rows[0]["STATUS"].ToString() != null && dsgmdelay.Tables[0].Rows[0]["STATUS"].ToString() != "Y")
                                                {
                                                    trgmdelayexplaination.Visible = true;
                                                    trgmdelayexplainationbutton.Visible = true;
                                                    trYettobeassign2.Visible = false;
                                                    Button6.Visible = false;
                                                    trgmdelayclose.Visible = false;
                                                    //GrdGMDelayexplaination.DataSource = ds.Tables[1];   // incentive which are not assigned
                                                    //GrdGMDelayexplaination.DataBind();
                                                    // bindGMGridsDelay("0");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            trgmdelayexplaination.Visible = false;
                                            trgmdelayexplainationbutton.Visible = false;
                                            trgmdelayclose.Visible = true;
                                            // trYettobeassign2.Visible = true;
                                        }
                                    }

                                    /// END OF ADDED CODE BY MADHURI ON 18/03/2021//

                                    DisignationLoad = ds.Tables[1].Rows[0]["DesignationLoad"].ToString();
                                    ViewState["DisignationLoad"] = DisignationLoad;

                                    grdDetails.DataSource = ds.Tables[1];   // incentive which are not assigned
                                    grdDetails.DataBind();

                                    if (grdDetails.Rows.Count < 1)
                                    {
                                        Button6.Visible = false;
                                    }
                                }
                                else
                                {
                                    if (grdDetails.Rows.Count < 1)
                                    {
                                        Button6.Visible = false;
                                    }
                                }
                                if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                                {
                                    trAssignedInspectingOfficerincentives.Visible = true;
                                    gvassigncompleted.DataSource = ds.Tables[2];   // incentive which are assigned
                                    gvassigncompleted.DataBind();
                                    string inspectionofficer = ds.Tables[2].Rows[0]["InspectionAssignTo"].ToString();
                                    ddlDeptname.SelectedValue = inspectionofficer;
                                    ddlDeptname.Enabled = false;
                                    if (inspectionofficer == Session["uid"].ToString())
                                    {
                                        Role_Code = "IPO";
                                    }
                                }

                                if (ds != null && ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
                                {
                                    for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
                                    {
                                        foreach (GridViewRow gvrow in grdDetails.Rows)
                                        {
                                            string MstIncentiveId = ds.Tables[3].Rows[i]["MstIncentiveId"].ToString();
                                            Label lblMstIncentiveId = (Label)gvrow.FindControl("lblMstIncentiveId");
                                            if (lblMstIncentiveId.Text.Trim() == MstIncentiveId)
                                            {
                                                RadioButtonList ddlofficernew = (RadioButtonList)gvrow.FindControl("rdbyesno");
                                                ddlofficernew.SelectedValue = "N";
                                                ddlofficernew.Enabled = false;
                                            }
                                        }
                                    }

                                    GridView2.DataSource = ds.Tables[3];
                                    GridView2.DataBind();
                                    trgmtoenterquery.Visible = true;
                                    hplink.NavigateUrl = "ProformaQueryRaiseShortFallLetterGMtoApplicant.aspx?incentiveid=" + Applicantinid;
                                }
                                if (ds != null && ds.Tables.Count > 5 && ds.Tables[5].Rows.Count > 0)
                                {
                                    trgmrejectedapplications.Visible = true;
                                    gvrejectedapplicationsbygm.DataSource = ds.Tables[5];
                                    gvrejectedapplicationsbygm.DataBind();
                                }
                                else
                                {
                                    trgmrejectedapplications.Visible = false;
                                    gvrejectedapplicationsbygm.DataSource = null;
                                    gvrejectedapplicationsbygm.DataBind();
                                }

                                DataSet daquerie = new DataSet();
                                if (Request.QueryString[1].ToString() != "91")
                                    daquerie = Gen.GetIncetiveDetailsdeptOfficerRemarksGM(Applicantinid, Status, SentFrom, "AD", Incids);
                                if (daquerie != null && daquerie.Tables.Count > 0 && daquerie.Tables[0].Rows.Count > 0)
                                {
                                    trqueryDtls1.Visible = true;
                                    trqueryDtls.Visible = true;
                                    //trQueryletter.Visible = true; // commented by shankar on 21-01-2019
                                    //trsendresponcetocoi.Visible = true;
                                    gvquerygm.DataSource = daquerie.Tables[0];
                                    gvquerygm.DataBind();

                                    GridView5.DataSource = daquerie.Tables[1];
                                    GridView5.DataBind();

                                    HyperLink4.NavigateUrl = "ProformaQueryRaiseShortFallLetter.aspx?incentiveid=" + ds.Tables[0].Rows[0]["IncentveID"].ToString();

                                    if (Role_Code == "JD")
                                    {
                                        HyperLink5.NavigateUrl = "ProformaQueryRaiseShortFallLetter.aspx?incentiveid=" + ds.Tables[0].Rows[0]["IncentveID"].ToString();
                                        tr16.Visible = true;
                                        tr15.Visible = true;
                                        Div31.Visible = true;
                                    }
                                }
                                else
                                {
                                    trqueryDtls1.Visible = false;
                                    trqueryDtls.Visible = false;
                                    //  trsendresponcetocoi.Visible = false;
                                    trQueryletter.Visible = false;
                                }
                                if (ds != null && ds.Tables.Count > 4 && ds.Tables[4].Rows.Count > 0)
                                {
                                    BindingGmRecommendedIncentives(ds.Tables[4]);
                                }
                                if (gvinspectionOfficer.Rows.Count < 1)
                                {
                                    trinspectionname1.Visible = false;
                                    trInspectionReport4.Visible = false;
                                }

                                // added by chh on 17.10.2017
                                DataSet daquerieIO = new DataSet();
                                if (Request.QueryString[1].ToString() != "91")
                                    daquerieIO = Gen.GetIncetiveDetailsdeptOfficerRemarksGMbyIO(Applicantinid, Status, SentFrom, "AD", Incids);
                                if (daquerieIO != null && daquerieIO.Tables.Count > 0 && daquerieIO.Tables[0].Rows.Count > 0)
                                {
                                    trqueryDtlsIO.Visible = true;
                                    trqueryDtls1IO.Visible = true;
                                    //trQueryletterIO.Visible = true; // commented by shankar on 21-01-2019
                                    //trsendresponcetocoi.Visible = true;
                                    gvquerygmtbyIO.DataSource = daquerieIO.Tables[0];
                                    gvquerygmtbyIO.DataBind();

                                    //int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
                                    //Label lblIOQuerySts = (Label)gvquerygmtbyIO.Rows[indexing].FindControl("lblIoQuerySts");
                                    //if (lblIOQuerySts.Text == "1")
                                    //{
                                    //    Button btnIOqueryfwdtoApplicant = (Button)gvquerygmtbyIO.Rows[indexing].FindControl("btnsendcoiIO");
                                    //    btnIOqueryfwdtoApplicant.Enabled = false;

                                    //    Button btnIOQueryResponsebyGMtoIO = (Button)gvquerygmtbyIO.Rows[indexing].FindControl("btnsendIOQuerybyGM");
                                    //    btnIOQueryResponsebyGMtoIO.Enabled = false;
                                    //}
                                    //else
                                    //{
                                    //    Button btnIOqueryfwdtoApplicant = (Button)gvquerygmtbyIO.Rows[indexing].FindControl("btnsendcoiIO");
                                    //    btnIOqueryfwdtoApplicant.Enabled = true;

                                    //    Button btnIOQueryResponsebyGMtoIO = (Button)gvquerygmtbyIO.Rows[indexing].FindControl("btnsendIOQuerybyGM");
                                    //    btnIOQueryResponsebyGMtoIO.Enabled = true;
                                    //}
                                    //  HyperLink4.NavigateUrl = "ProformaQueryRaiseShortFallLetter.aspx?incentiveid=" + ds.Tables[0].Rows[0]["IncentveID"].ToString();
                                    HyperLink1.NavigateUrl = "QueryRaiseShortFallLetterinspectortoApplicantApproval.aspx?incentiveid=" + Applicantinid + "&MstIncentiveId=00";
                                }
                                else
                                {
                                    trqueryDtlsIO.Visible = false;
                                    trqueryDtls1IO.Visible = false;
                                    //  trsendresponcetocoi.Visible = false;
                                    trQueryletterIO.Visible = false;
                                }
                                // added on 10.01.2018  for COI query response showing to GM
                                //DataSet daqueriegm = new DataSet();
                                //daqueriegm = Gen.GetIncetiveDetailsdeptOfficerRemarks(Applicantinid, Status, "3377", "JD", "");

                                //if (daqueriegm != null && daqueriegm.Tables.Count > 1 && daqueriegm.Tables[1].Rows.Count > 0)
                                //{
                                //    Div2.Visible = true;
                                //    gvresponcegmgv.DataSource = daqueriegm.Tables[1];
                                //    gvresponcegmgv.DataBind();
                                //    tr1gmresponce.Visible = true;
                                //    tr1gmresponce2.Visible = true;

                                //    trjdqueryletter.Visible = false;
                                //    HyperLinktrjdqueryletter.NavigateUrl = "ProformaQueryRaiseShortFallLetter.aspx?incentiveid=" + Applicantinid;
                                //}


                                DataSet daquerieall = new DataSet();
                                if (Request.QueryString[1].ToString() != "91")
                                    daquerieall = Gen.GetIncetiveDetailsdeptOfficerRemarks(Applicantinid, Status, SentFrom, "ADDL", "ALL", Incids);
                                if (daquerieall != null && daquerieall.Tables.Count > 12 && daquerieall.Tables[12].Rows.Count > 0)
                                {

                                    gvrejctedslc.DataSource = daquerieall.Tables[12];
                                    gvrejctedslc.DataBind();
                                    Div16.Visible = true;
                                    tr10.Visible = true;
                                }
                                if (daquerieall != null && daquerieall.Tables.Count > 11 && daquerieall.Tables[11].Rows.Count > 0)
                                {
                                    gvrejectedaddlsvc.DataSource = daquerieall.Tables[11];
                                    gvrejectedaddlsvc.DataBind();
                                    Div13.Visible = true;
                                    tr9.Visible = true;
                                }
                                if (daquerieall != null && daquerieall.Tables.Count > 9 && daquerieall.Tables[9].Rows.Count > 0)
                                {
                                    gvadditionalRejected.DataSource = daquerieall.Tables[9];
                                    gvadditionalRejected.DataBind();
                                    Div2.Visible = true;
                                    tr11.Visible = true;
                                }
                                if (daquerieall != null && daquerieall.Tables.Count > 10 && daquerieall.Tables[10].Rows.Count > 0)
                                {
                                    tr8.Visible = true;
                                    gvaddlabeyanced.DataSource = daquerieall.Tables[10];
                                    gvaddlabeyanced.DataBind();
                                    Div2.Visible = true;
                                }
                                // DIPC Binding approved and rejected
                                if (daquerieall != null && daquerieall.Tables.Count > 14 && daquerieall.Tables[14].Rows.Count > 0)
                                {
                                    GridView11.DataSource = daquerieall.Tables[14];
                                    GridView11.DataBind();
                                    Div33.Visible = true;
                                }
                                if (daquerieall != null && daquerieall.Tables.Count > 15 && daquerieall.Tables[15].Rows.Count > 0)
                                {
                                    GridView12.DataSource = daquerieall.Tables[15];
                                    GridView12.DataBind();
                                    Div33.Visible = true;
                                    tr17.Visible = true;
                                }
                                // end
                                if (daquerieall != null && daquerieall.Tables.Count > 2 && daquerieall.Tables[2].Rows.Count > 0)
                                {
                                    spanaddljdstatusbar.InnerHtml = "Status of Application at Additional Director";
                                    if (daquerieall != null && daquerieall.Tables.Count > 0 && daquerieall.Tables[0].Rows.Count > 0)
                                    {
                                        Div13.Visible = true;
                                        gvpresvc.DataSource = daquerieall.Tables[0]; ;
                                        gvpresvc.DataBind();
                                    }

                                    if (daquerieall != null && daquerieall.Tables.Count > 1 && daquerieall.Tables[1].Rows.Count > 0)
                                    {
                                        Div16.Visible = true;
                                        gvpostsvc.DataSource = daquerieall.Tables[1];
                                        gvpostsvc.DataBind();
                                    }

                                    if (daquerieall != null && daquerieall.Tables.Count > 2 && daquerieall.Tables[2].Rows.Count > 0)
                                    {
                                        Div7.Visible = true;
                                        gvreconbyjdjd.DataSource = daquerieall.Tables[2];
                                        gvreconbyjdjd.DataBind();
                                        tr14.Visible = true;
                                    }
                                    if (daquerieall != null && daquerieall.Tables.Count > 13 && daquerieall.Tables[13].Rows.Count > 0)
                                    {
                                        Div7.Visible = true;
                                        GridView6.DataSource = daquerieall.Tables[13];
                                        GridView6.DataBind();
                                        tr12.Visible = true;
                                        tr13.Visible = true;
                                        HyperLink3.NavigateUrl = "ProformaQueryRaiseShortFallLetter.aspx?incentiveid=" + Applicantinid;
                                    }
                                    if (daquerieall != null && daquerieall.Tables.Count > 3 && daquerieall.Tables[3].Rows.Count > 0)
                                    {
                                        Div7.Visible = true;
                                        jdqueryhistory.DataSource = daquerieall.Tables[3];
                                        jdqueryhistory.DataBind();
                                        tr7.Visible = true;
                                    }
                                    if (daquerieall != null && daquerieall.Tables.Count > 4 && daquerieall.Tables[4].Rows.Count > 0)
                                    {
                                        tradditionalforwared.InnerHtml = "Forwarded to SVC";
                                        Div2.Visible = true;
                                        trProcessedApplications.Visible = true;
                                        gvProcessedApplications.DataSource = daquerieall.Tables[4];
                                        gvProcessedApplications.DataBind();
                                    }

                                    if (daquerieall != null && daquerieall.Tables.Count > 5 && daquerieall.Tables[5].Rows.Count > 0)
                                    {
                                        Div2.Visible = true;
                                        gvpendingapplications.DataSource = daquerieall.Tables[5];
                                        gvpendingapplications.DataBind();
                                        trPendingApplications.Visible = true;

                                        //trjdqueryletter.Visible = true; // commented by shankar on 21-01-2019
                                        //HyperLinktrjdqueryletter.NavigateUrl = "ProformaQueryRaiseShortFallLetter.aspx?incentiveid=" + Applicantinid;
                                        if (daquerie.Tables[5].Rows[0]["status"].ToString() != "SSC")// added by madhuri on 17/12/2021
                                        { HyperLinktrjdqueryletter.NavigateUrl = "ProformaQueryRaiseShortFallLetter.aspx?incentiveid=" + Applicantinid; }
                                        else
                                        {
                                            trjdqueryletter.Visible = false;
                                        }
                                    }
                                    if (daquerieall != null && daquerieall.Tables.Count > 6 && daquerieall.Tables[6].Rows.Count > 0)
                                    {
                                        Div2.Visible = true;

                                        gvresponcegmgv.DataSource = daquerieall.Tables[6];
                                        gvresponcegmgv.DataBind();
                                        tr1gmresponce.Visible = true;
                                        tr1gmresponce2.Visible = true;
                                    }
                                }

                            }
                            if (Role_Code.Trim() == "IPO" || Role_Code.Trim() == "AD" || Role_Code.Trim() == "DD")
                            {



                                DisignationLoad = Role_Code.Trim();
                                ViewState["DisignationLoad"] = DisignationLoad;
                                //  trYettobeassign.Visible = false;
                                trYettobeassign2.Visible = false;
                                divgm.Visible = false;
                                //trbuttoninspection.Visible = false;
                                //trInspectionReport.Visible = false;
                                //  trInspectionReportNEW.Visible = false;
                                trInspectionReport2.Visible = false;
                                //trInspectionReport3.Visible = false;
                                trInspectionReport4.Visible = false;
                                trRemarks1.Visible = false;
                                //  trRemarks2.Visible = false;
                                trgmhistory.Visible = true;
                                trinspectionname1.Visible = false;
                                // tripo.Visible = true;
                                tripo1.Visible = true;
                                // tripoinsp1button.Visible = true;
                                divgm.Visible = false;
                                // trSubmitinspectionReport.Visible = true;
                                gvdicinspection.DataSource = ds.Tables[1];
                                gvdicinspection.DataBind();
                                //if (gvdicinspection.Rows.Count > 0)
                                //{
                                //    tripoinsp1button.Visible = true;
                                //    tripoinsp1button0.Visible = true;
                                //}
                                Span1.InnerHtml = "Assigned by GM-DIC(" + ds.Tables[0].Rows[0]["UnitDistName"].ToString() + ")";
                                // txtinspectiondate.Text = ds.Tables[1].Rows[0]["TobeinspectedDate"].ToString();

                                //DataSet dsinspection = new DataSet();
                                //dsinspection = Gen.GetIncentiveDeptDetails(ViewState["IncentveID"].ToString());
                                //FillDetails(dsinspection);

                                //DataSet dsnewre = new DataSet();
                                //dsnewre = Gen.GetIncetiveDetailsdeptAttachementsIpo(Applicantinid);
                                //if (dsnewre != null && dsnewre.Tables.Count > 0 && dsnewre.Tables[0].Rows.Count > 0)
                                //{
                                //    GridView3att.DataSource = dsnewre.Tables[0];
                                //    GridView3att.DataBind();
                                //}
                                if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                                {
                                    if (Request.QueryString["Sts"].ToString() == "8" || Request.QueryString["Sts"].ToString() == "9"
                                        || Request.QueryString["Sts"].ToString() == "121" || Request.QueryString["Sts"].ToString() == "6"
                                        || Request.QueryString["Sts"].ToString() == "7" || Request.QueryString["Sts"].ToString() == "10")
                                    {
                                        trUpdateInspectionReport.Visible = true;
                                        trUpdateInspectionReport1.Visible = true;
                                    }
                                    else
                                    {
                                        trUpdateInspectionReport.Visible = false;
                                        trUpdateInspectionReport1.Visible = false;
                                    }



                                    gvinspectionReport.DataSource = ds.Tables[2];
                                    gvinspectionReport.DataBind();
                                    lblGMRollbackIORemarks.Text = "";
                                    for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                                    {
                                        lblGMRollbackIORemarks.Visible = true;

                                        if (ds.Tables[2].Rows[i]["GMRemarks"].ToString() != "")
                                        {
                                            lblGMRollbackIORemarks.Text = lblGMRollbackIORemarks.Text + "For " + ds.Tables[2].Rows[i]["IncentiveName"].ToString() + " GM Rollback Remarks are: " + ds.Tables[2].Rows[i]["GMRemarks"].ToString() + "<br/>";
                                        }
                                    }
                                }
                                if (Request.QueryString["Sts"].ToString() == "5" || Request.QueryString["Sts"].ToString() == "4")
                                {
                                    trmattachments.Visible = true;
                                    trmattachments_grid.Visible = true;
                                    //trmattachments_submitbuttom.Visible = true;
                                    DataSet dsstageid = new DataSet();
                                    dsstageid = GetStageID(Applicantinid, ViewState["MstIncentiveId"].ToString());
                                    gvadrecommended.DataSource = null;
                                    gvadrecommended.DataBind();
                                    if (dsstageid != null && dsstageid.Tables.Count > 0)
                                    {
                                        if (dsstageid.Tables[0].Rows.Count > 0)
                                        {
                                            if (dsstageid.Tables[0].Rows[0]["intStageid"].ToString() == "3")
                                            {
                                                trmattachments_submitbuttom.Visible = true;

                                            }
                                            else
                                            {
                                                trmattachments_submitbuttom.Visible = false;

                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    trmattachments.Visible = false;
                                    trmattachments_grid.Visible = false;
                                    trmattachments_submitbuttom.Visible = false;
                                }
                            }
                            if (Role_Code == "JD" || Role_Code == "COI-AD" || Role_Code == "COI-DD" || Role_Code == "COI-SUPDT" || Role_Code == "ADDL")
                            {

                                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                                {
                                    if (Incids != null && Incids != "")
                                    {
                                        int result;
                                        DataTable dt = FilterDataTableBasedOnIncentiveIds(ds, Incids, 1, "IncentiveID", out result);
                                        ds.Tables.Add(dt);
                                    }
                                }

                                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                                {
                                    BindingGmRecommendedIncentives(ds.Tables[1]);
                                }
                                if (Role_Code == "COI-AD" || Role_Code == "COI-DD" || Role_Code == "COI-SUPDT")
                                {
                                    GridView8.Visible = false;
                                    tr18.Visible = true;
                                }
                                else
                                {
                                    tr18.Visible = false;
                                }
                                divnewattachemts.Visible = true;
                                divlastattachemntold.Visible = false;
                                trYettobeassign2.Visible = false;
                                divgm.Visible = false;
                                trinspectionname.InnerHtml = "Recommended by GM-DIC(" + ds.Tables[0].Rows[0]["UnitDistName"].ToString() + ")";
                                spanaddljdstatusbar.InnerHtml = "Status of Applications at JD";
                                //  trInspectionReportNEW.Visible = true;
                                trInspectionReport2.Visible = true;
                                trInspectionReport4.Visible = false;
                                if (Role_Code == "JD")
                                {
                                    //if (Request.QueryString["Sts"].ToString() != "" && Request.QueryString["Sts"].ToString() != "600"
                                    //    && Request.QueryString["Sts"].ToString() != "601" && Request.QueryString["Sts"].ToString() != "606"
                                    //    && Request.QueryString["Sts"].ToString() != "603"
                                    //    && Request.QueryString["Sts"].ToString() != "604" && Request.QueryString["Sts"].ToString() != "605")
                                    //{
                                    //    trRemarks1.Visible = false;

                                    //}
                                    //else
                                    //{
                                    trRemarks1.Visible = true;
                                    CheckBoxList1.Items[5].Text = "Return to AD/DD";


                                    //}
                                }
                                // Button4.Visible = true;

                                ////ADDED BY NIKHIL 13072021 /////
                                if (Role_Code != "COI-AD")
                                {
                                    //trRemarks1.Visible = true;
                                    trRemarks_adlevel.Visible = false;

                                }
                                if (Role_Code == "COI-AD")
                                {
                                    if (Request.QueryString["Sts"].ToString() != "" && Request.QueryString["Sts"].ToString() != "100"
                                        && Request.QueryString["Sts"].ToString() != "101" && Request.QueryString["Sts"].ToString() != "102"
                                        && Request.QueryString["Sts"].ToString() != "103"
                                        && Request.QueryString["Sts"].ToString() != "104" && Request.QueryString["Sts"].ToString() != "105")
                                    {
                                        trRemarks1.Visible = false;
                                        trRemarks_adlevel.Visible = true;
                                    }
                                    else
                                    {
                                        // trRemarks1.Visible = true;
                                        trRemarks_adlevel.Visible = false;
                                    }

                                }

                                if (Request.QueryString[1].ToString() == "222")  //ad level query
                                {
                                    DataSet oDataSet_AD = new DataSet();
                                    SqlConnection osqlconn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString); ;
                                    osqlconn.Open();
                                    SqlDataAdapter da;
                                    try
                                    {
                                        da = new SqlDataAdapter("USP_GETINCENTIVEQUERY_ADLEVEL", osqlconn);
                                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                                        da.SelectCommand.Parameters.Add("@IncentiveID", SqlDbType.VarChar).Value = Request.QueryString["EntrpId"].ToString();
                                        da.Fill(oDataSet_AD);//FillDetailsabc(odsRejection);

                                        if (oDataSet_AD.Tables[0].Rows.Count >= 1)
                                        {
                                            trRemarks_adlevel.Visible = true;
                                            trfullshap_AdRemakrs.Visible = true;
                                            gvQueries_ADLevel.DataSource = oDataSet_AD.Tables[0];
                                            gvQueries_ADLevel.DataBind();

                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        throw ex;
                                    }
                                    finally
                                    {
                                        osqlconn.Close();
                                    }
                                }
                                if (Role_Code == "JD" || Role_Code == "COI-AD" || Role_Code == "ADDL" || Role_Code == "COI-SUPDT")
                                {
                                    DataSet DSDISTISPH = new DataSet();
                                    DSDISTISPH = GETDISTSCHEMEANDISPHDATA(Applicantinid);
                                    if (DSDISTISPH != null && DSDISTISPH.Tables.Count > 0)

                                    {
                                        districtid = (DSDISTISPH.Tables[0].Rows[0]["unitdist"].ToString());
                                        ISDIFFABLED = (DSDISTISPH.Tables[0].Rows[0]["IsDifferentlyAbled"].ToString());
                                        ISTIDEAFLAG = (DSDISTISPH.Tables[0].Rows[0]["TIDEAflag"].ToString());
                                        TSPFLAG = (DSDISTISPH.Tables[0].Rows[0]["TSPflag"].ToString());

                                    }
                                    DataSet dsADQuery = new DataSet();
                                    dsADQuery = GetADQueryHistory(Applicantinid, Role_Code, Incids);
                                    //GVIOQueryStatus.DataSource = null;
                                    //GVIOQueryStatus.DataBind();
                                    if (dsADQuery != null && dsADQuery.Tables.Count > 0 && dsADQuery.Tables[0].Rows.Count > 0)
                                    {
                                        //if (dsADQuery.Tables[0].Rows.Count > 0)
                                        //{
                                        //    GVADQueryStatus.DataSource = dsADQuery.Tables[0];
                                        //    GVADQueryStatus.DataBind();
                                        //    //trqueryDtls1IO.Visible = true;
                                        //    DivAD21.Visible = true;
                                        //}
                                        //else
                                        //{
                                        //    //trqueryDtls1IO.Visible = false;
                                        //    DivAD21.Visible = false;
                                        //}
                                        string datecheckad = Convert.ToDateTime(dsADQuery.Tables[0].Rows[0]["Query Raised Date"].ToString()).ToShortDateString();
                                        if ((districtid == "1" || districtid == "22" || districtid == "19" || districtid == "11" ||
districtid == "5" || districtid == "20" || districtid == "28" || districtid == "23" ||
districtid == "26" || districtid == "3" || districtid == "14" || districtid == "10" ||
districtid == "17" || districtid == "16" || districtid == "2" || districtid == "19")
 && ISDIFFABLED != "Y" && ISTIDEAFLAG == "Y")
                                        {
                                            if (Convert.ToDateTime(datecheckad) >= Convert.ToDateTime("16-September-24") && Convert.ToDateTime(datecheckad) < Convert.ToDateTime("07-January-25"))
                                            {
                                                DivAD21.Visible = false;
                                            }
                                            else
                                            {
                                                GVADQueryStatus.DataSource = dsADQuery.Tables[0];
                                                GVADQueryStatus.DataBind();
                                                //trqueryDtls1IO.Visible = true;
                                                DivAD21.Visible = true;
                                            }
                                        }
                                        else
                                        {
                                            GVADQueryStatus.DataSource = dsADQuery.Tables[0];
                                            GVADQueryStatus.DataBind();
                                            //trqueryDtls1IO.Visible = true;
                                            DivAD21.Visible = true;
                                        }



                                    }
                                    if (dsADQuery != null && dsADQuery.Tables.Count > 1 && dsADQuery.Tables[1].Rows.Count > 0)
                                    {
                                        gvclerkquery.DataSource = dsADQuery.Tables[1];
                                        gvclerkquery.DataBind();
                                        //trqueryDtls1IO.Visible = true;
                                        Divclerkquery.Visible = true;
                                    }
                                    if (dsADQuery != null && dsADQuery.Tables.Count > 2 && dsADQuery.Tables[2].Rows.Count > 0)
                                    {
                                        gvsupdtquery.DataSource = dsADQuery.Tables[2];
                                        gvsupdtquery.DataBind();
                                        //trqueryDtls1IO.Visible = true;
                                        Divsupdtquery.Visible = true;
                                    }
                                    if (dsADQuery != null && dsADQuery.Tables.Count > 3 && dsADQuery.Tables[3].Rows.Count > 0)
                                    {
                                        gvDDQuery.DataSource = dsADQuery.Tables[3];
                                        gvDDQuery.DataBind();
                                        //trqueryDtls1IO.Visible = true;
                                        DivDDQuery.Visible = true;
                                    }
                                    DataSet dsADrec = new DataSet();
                                    dsADrec = GetIncetiveDetailsdeptAD(Applicantinid, Status, Userid, Userid, Incids);
                                    gvadrecommended.DataSource = null;
                                    gvadrecommended.DataBind();
                                    if (dsADrec != null && dsADrec.Tables.Count > 0 && dsADrec.Tables[0].Rows.Count > 0)
                                    {
                                        //gvadrecommended.DataSource = dsADrec.Tables[0];
                                        //gvadrecommended.DataBind();
                                        //trqueryDtls1IO.Visible = true;
                                        if ((districtid == "1" || districtid == "22" || districtid == "19" || districtid == "11" ||
districtid == "5" || districtid == "20" || districtid == "28" || districtid == "23" ||
districtid == "26" || districtid == "3" || districtid == "14" || districtid == "10" ||
districtid == "17" || districtid == "16" || districtid == "2" || districtid == "19")
                                           && ISDIFFABLED != "Y" && ISTIDEAFLAG == "Y")
                                        {
                                            string datecheckad = Convert.ToDateTime(dsADrec.Tables[0].Rows[0]["RECOMMENDED_DATE"].ToString()).ToShortDateString();

                                            if (Convert.ToDateTime(datecheckad) >= Convert.ToDateTime("16-September-24") && Convert.ToDateTime(datecheckad) < Convert.ToDateTime("07-January-25"))
                                            {
                                                DivADR21.Visible = false;
                                            }
                                            else
                                            {
                                                DivADR21.Visible = true;
                                                BindingADRecommendedIncentives(dsADrec.Tables[0]);
                                            }
                                        }
                                        else
                                        {
                                            if (dsADrec.Tables[0].Rows.Count > 0)
                                            {
                                                DivADR21.Visible = true;
                                                BindingADRecommendedIncentives(dsADrec.Tables[0]);
                                            }
                                            else
                                            {
                                                //trqueryDtls1IO.Visible = false;
                                                DivADR21.Visible = false;
                                            }
                                        }

                                    }

                                    if (dsADrec != null && dsADrec.Tables.Count > 1 && dsADrec.Tables[1].Rows.Count > 0)
                                    {
                                        Divclerkr.Visible = true;
                                        BindingClerkRecommendedIncentives(dsADrec.Tables[1]);
                                    }
                                    else
                                    {
                                        Divclerkr.Visible = false;
                                    }
                                    if (dsADrec != null && dsADrec.Tables.Count > 2 && dsADrec.Tables[2].Rows.Count > 0)
                                    {
                                        //DivSuprdntr.Visible = true;
                                        //BindingSupdtRecommendedIncentives(dsADrec.Tables[2]);
                                        //string datecheck1 = Convert.ToDateTime(dsADrec.Tables[2].Rows[0]["RECOMMENDED_DATE"].ToString()).ToShortDateString();
                                        //if (Session["uid"].ToString() != "32953")
                                        //{
                                        //    DivSuprdntr.Visible = true;
                                        //    BindingSupdtRecommendedIncentives(dsADrec.Tables[2]);
                                        //}
                                        //else
                                        //{
                                        //    //if (Convert.ToDateTime(datecheck1) >= Convert.ToDateTime("01-June-24") && Convert.ToDateTime(datecheck1) < Convert.ToDateTime("15-June-24"))
                                        //    if ((Convert.ToDateTime(datecheck1) >= Convert.ToDateTime("01-June-24") && Convert.ToDateTime(datecheck1) < Convert.ToDateTime("15-June-24"))
                                        //        || (Convert.ToDateTime(datecheck1) >= Convert.ToDateTime("24-July-24") && Convert.ToDateTime(datecheck1) < Convert.ToDateTime("31-August-24")))
                                        //    {
                                        //        DivSuprdntr.Visible = false;
                                        //        BindingSupdtRecommendedIncentives(dsADrec.Tables[2]);
                                        //    }
                                        //    else
                                        //    {
                                        //        DivSuprdntr.Visible = true;
                                        //        BindingSupdtRecommendedIncentives(dsADrec.Tables[2]);
                                        //    }
                                        //}
                                        string datecheck1 = Convert.ToDateTime(dsADrec.Tables[2].Rows[0]["RECOMMENDED_DATE"].ToString()).ToShortDateString();



                                        //1,22,19,11,5,20,28,23,26,3,14,10,17,16,2,19
                                        if ((districtid == "1" || districtid == "22" || districtid == "19" || districtid == "11" ||
                                            districtid == "5" || districtid == "20" || districtid == "28" || districtid == "23" ||
                                            districtid == "26" || districtid == "3" || districtid == "14" || districtid == "10" ||
                                            districtid == "17" || districtid == "16" || districtid == "2" || districtid == "19")
                                            && ISDIFFABLED != "Y" && ISTIDEAFLAG == "Y")
                                        {
                                            if ((Convert.ToDateTime(datecheck1) >= Convert.ToDateTime("01-June-24") && Convert.ToDateTime(datecheck1) < Convert.ToDateTime("15-June-24"))
                                                || (Convert.ToDateTime(datecheck1) >= Convert.ToDateTime("24-July-24") && Convert.ToDateTime(datecheck1) < Convert.ToDateTime("30-August-24")))
                                            {
                                                DivSuprdntr.Visible = false;
                                                BindingSupdtRecommendedIncentives(dsADrec.Tables[2]);
                                            }
                                            else
                                            {
                                                DivSuprdntr.Visible = true;
                                                BindingSupdtRecommendedIncentives(dsADrec.Tables[2]);
                                            }
                                        }
                                        else
                                        {
                                            DivSuprdntr.Visible = true;
                                            BindingSupdtRecommendedIncentives(dsADrec.Tables[2]);
                                        }
                                    }
                                    else
                                    {
                                        DivSuprdntr.Visible = false;
                                    }
                                    if (dsADrec != null && dsADrec.Tables.Count > 3 && dsADrec.Tables[3].Rows.Count > 0)
                                    {
                                        string datecheck1FORDD = Convert.ToDateTime(dsADrec.Tables[3].Rows[0]["RECOMMENDED_DATE"].ToString()).ToShortDateString();

                                        if (((districtid == "1" || districtid == "22" || districtid == "19" || districtid == "11" ||
                                            districtid == "5" || districtid == "20" || districtid == "28" || districtid == "23" ||
                                            districtid == "26" || districtid == "3" || districtid == "14" || districtid == "10" ||
                                            districtid == "17" || districtid == "16" || districtid == "2" || districtid == "19")
                                            && ISDIFFABLED != "Y" && ISTIDEAFLAG == "Y") || TSPFLAG == "Y" || ISDIFFABLED == "Y")
                                        {
                                            //if (Convert.ToDateTime(datecheck1FORDD) >= Convert.ToDateTime("01-November-25") && Convert.ToDateTime(datecheck1FORDD) < Convert.ToDateTime("30-November-25")  )
                                            //{
                                            //    DivDDrcr.Visible = false;
                                            //    BindingDDRecommendedIncentives(dsADrec.Tables[3]);
                                            //}
                                            //else
                                            //{
                                            DivDDrcr.Visible = true;
                                            BindingDDRecommendedIncentives(dsADrec.Tables[3]);
                                            //}
                                        }
                                        else
                                        {
                                            DivDDrcr.Visible = true;
                                            BindingDDRecommendedIncentives(dsADrec.Tables[3]);
                                        }


                                        //DivDDrcr.Visible = true;
                                        //BindingDDRecommendedIncentives(dsADrec.Tables[3]);
                                    }
                                    else
                                    {
                                        DivDDrcr.Visible = false;
                                    }


                                    //DataSet dsADrec = new DataSet();
                                    //dsADrec = GetIncetiveDetailsdeptAD(Applicantinid, Status, Userid, Userid, Incids);
                                    //gvadrecommended.DataSource = null;
                                    //gvadrecommended.DataBind();
                                    //if (dsADrec != null && dsADrec.Tables.Count > 0 && dsADrec.Tables[0].Rows.Count > 0)
                                    //{
                                    //    //if (dsADrec.Tables[0].Rows.Count > 0)
                                    //    //{
                                    //    //    DivADR21.Visible = true;
                                    //    //    BindingADRecommendedIncentives(dsADrec.Tables[0]);
                                    //    //}
                                    //    //else
                                    //    //{
                                    //    //    //trqueryDtls1IO.Visible = false;
                                    //    //    DivADR21.Visible = false;
                                    //    //}
                                    //    string datecheckad = Convert.ToDateTime(dsADrec.Tables[0].Rows[0]["RECOMMENDED_DATE"].ToString()).ToShortDateString();

                                    //    if (Convert.ToDateTime(datecheckad) >= Convert.ToDateTime("16-September-24") && Convert.ToDateTime(datecheckad) < Convert.ToDateTime("31-January-25"))
                                    //    {
                                    //        DivADR21.Visible = false;
                                    //    }
                                    //    else
                                    //    {
                                    //        DivADR21.Visible = true;
                                    //        BindingADRecommendedIncentives(dsADrec.Tables[0]);
                                    //    }
                                    //    if (dsADrec.Tables[1].Rows.Count > 0)
                                    //    {
                                    //        Divclerkr.Visible = true;
                                    //        BindingClerkRecommendedIncentives(dsADrec.Tables[1]);
                                    //    }
                                    //    else
                                    //    {
                                    //        Divclerkr.Visible = false;
                                    //    }
                                    //    if (dsADrec.Tables[2].Rows.Count > 0)
                                    //    {
                                    //        //string datecheck1 = Convert.ToDateTime(dsADrec.Tables[2].Rows[0]["RECOMMENDED_DATE"].ToString()).ToShortDateString();

                                    //        //if (Session["uid"].ToString() == "32952")
                                    //        //{
                                    //        //    DivSuprdntr.Visible = true;
                                    //        //    BindingSupdtRecommendedIncentives(dsADrec.Tables[2]);
                                    //        //}
                                    //        //else
                                    //        //{
                                    //        //    if (Convert.ToDateTime(datecheck1) >= Convert.ToDateTime("01-June-24"))
                                    //        //    {
                                    //        //        DivSuprdntr.Visible = false;
                                    //        //        BindingSupdtRecommendedIncentives(dsADrec.Tables[2]);
                                    //        //    }
                                    //        //    else
                                    //        //    {
                                    //        //        DivSuprdntr.Visible = true;
                                    //        //        BindingSupdtRecommendedIncentives(dsADrec.Tables[2]);
                                    //        //    }
                                    //        //}
                                    //        ////DivSuprdntr.Visible = true;
                                    //        ////BindingSupdtRecommendedIncentives(dsADrec.Tables[2]);
                                    //        string datecheck1 = Convert.ToDateTime(dsADrec.Tables[2].Rows[0]["RECOMMENDED_DATE"].ToString()).ToShortDateString();

                                    //        DataSet DSDISTISPH = new DataSet();
                                    //        DSDISTISPH = GETDISTSCHEMEANDISPHDATA(Applicantinid);

                                    //        if (DSDISTISPH != null && DSDISTISPH.Tables.Count > 0)

                                    //        {
                                    //            districtid = (DSDISTISPH.Tables[0].Rows[0]["unitdist"].ToString());
                                    //            ISDIFFABLED = (DSDISTISPH.Tables[0].Rows[0]["IsDifferentlyAbled"].ToString());
                                    //            ISTIDEAFLAG = (DSDISTISPH.Tables[0].Rows[0]["TIDEAflag"].ToString());

                                    //        }
                                    //        //1,22,19,11,5,20,28,23,26,3,14,10,17,16,2,19
                                    //        if ((districtid == "1" || districtid == "22" || districtid == "19" || districtid == "11" ||
                                    //            districtid == "5" || districtid == "20" || districtid == "28" || districtid == "23" ||
                                    //            districtid == "26" || districtid == "3" || districtid == "14" || districtid == "10" ||
                                    //            districtid == "17" || districtid == "16" || districtid == "2" || districtid == "19")
                                    //            && ISDIFFABLED != "Y" && ISTIDEAFLAG == "Y")
                                    //        {
                                    //            if ((Convert.ToDateTime(datecheck1) >= Convert.ToDateTime("01-June-24") && Convert.ToDateTime(datecheck1) < Convert.ToDateTime("15-June-24"))
                                    //                || (Convert.ToDateTime(datecheck1) >= Convert.ToDateTime("24-July-24") && Convert.ToDateTime(datecheck1) < Convert.ToDateTime("30-August-24")))
                                    //            {
                                    //                DivSuprdntr.Visible = false;
                                    //                BindingSupdtRecommendedIncentives(dsADrec.Tables[2]);
                                    //            }
                                    //            else
                                    //            {
                                    //                DivSuprdntr.Visible = true;
                                    //                BindingSupdtRecommendedIncentives(dsADrec.Tables[2]);
                                    //            }
                                    //        }
                                    //        else
                                    //        {
                                    //            DivSuprdntr.Visible = true;
                                    //            BindingSupdtRecommendedIncentives(dsADrec.Tables[2]);
                                    //        }
                                    //    }
                                    //    else
                                    //    {
                                    //        DivSuprdntr.Visible = false;
                                    //    }
                                    //    if (dsADrec.Tables[3].Rows.Count > 0)
                                    //    {
                                    //        DivDDrcr.Visible = true;
                                    //        BindingDDRecommendedIncentives(dsADrec.Tables[3]);
                                    //    }
                                    //    else
                                    //    {
                                    //        DivDDrcr.Visible = false;
                                    //    }

                                    //}


                                    //else
                                    //{
                                    //    //trqueryDtls1IO.Visible = false;
                                    //    DivADR21.Visible = false;
                                    //    Divclerkr.Visible = false;
                                    //    DivSuprdntr.Visible = false;
                                    //    DivDDrcr.Visible = false;
                                    //}

                                }

                                ///END OF ADDED CODE NIKHIL 

                                DataSet dsince = new DataSet();
                                dsince = Gen.GetIncetiveDropDownList(Applicantinid, "JD", "JD", Incids);
                                if (dsince != null && dsince.Tables.Count > 0 && dsince.Tables["Table"].Rows.Count > 0)
                                {
                                    if (Incids != null && Incids != "")
                                    {
                                        int result;
                                        DataTable dt = FilterDataTableBasedOnIncentiveIds(dsince, Incids, 0, "MstIncentiveId", out result);
                                        dsince.Tables.Add(dt);
                                    }
                                    //COMMNENTED CODE ON 13/07/2021//
                                    //ddlstaire.DataSource = dsince.Tables["Table"];
                                    //ddlstaire.DataValueField = "MstIncentiveId";
                                    //ddlstaire.DataTextField = "IncentiveName";
                                    //ddlstaire.DataBind();
                                    /// END OF COMMENTED CODE ON 13/07/2021//
                                    /// 
                                    ////ADDED BY NIKHIL 13072021 /////
                                    if (Role_Code != "COI-AD")
                                    {
                                        ddlstaire.DataSource = dsince.Tables["Table"];
                                        ddlstaire.DataValueField = "MstIncentiveId";
                                        ddlstaire.DataTextField = "IncentiveName";
                                        ddlstaire.DataBind();
                                    }
                                    if (Role_Code == "COI-AD")
                                    {
                                        ddlTypeofinc_adlevel.DataSource = dsince.Tables["Table"];
                                        ddlTypeofinc_adlevel.DataValueField = "MstIncentiveId";
                                        ddlTypeofinc_adlevel.DataTextField = "IncentiveName";
                                        ddlTypeofinc_adlevel.DataBind();
                                    }
                                    ///END OF ADDED CODE NIKHIL 

                                }
                                Button3.Text = "Recommended to Additional Director/Generate Query Letter";

                                //---------------------------------------------additional Query-------------------------------------------------------

                                DataSet daquerieadd = new DataSet();
                                daquerieadd = Gen.GetIncetiveDetailsdeptOfficerRemarksGM(Applicantinid, Status, SentFrom, "AD", Incids);
                                if (daquerieadd != null && daquerieadd.Tables.Count > 2 && daquerieadd.Tables[2].Rows.Count > 0)
                                {

                                    GridView8.DataSource = daquerieadd.Tables[2];
                                    GridView8.DataBind();

                                    GridView13.DataSource = daquerieadd.Tables[2];
                                    GridView13.DataBind();

                                    HyperLink5.NavigateUrl = "ProformaQueryRaiseShortFallLetter.aspx?incentiveid=" + ds.Tables[0].Rows[0]["IncentveID"].ToString();
                                    tr16.Visible = true;
                                    tr15.Visible = true;
                                    Div31.Visible = true;
                                }

                                if (daquerieadd != null && daquerieadd.Tables.Count > 3 && daquerieadd.Tables[3].Rows.Count > 0)
                                {
                                    GridView9.DataSource = daquerieadd.Tables[3];
                                    GridView9.DataBind();
                                    Div31.Visible = true;
                                    trgmqueriesapplicant.Visible = true;
                                }
                                else
                                {
                                    trgmqueriesapplicant.Visible = false;
                                }

                                if (daquerieadd != null && daquerieadd.Tables.Count > 4 && daquerieadd.Tables[4].Rows.Count > 0)
                                {
                                    GridView10.DataSource = daquerieadd.Tables[4];
                                    GridView10.DataBind();
                                    Div31.Visible = true;
                                    trjdreplytoaddl.Visible = true;
                                }
                                else
                                {
                                    trjdreplytoaddl.Visible = false;
                                }





                                //---------------------------------------

                                System.Web.UI.WebControls.ListItem LI = new System.Web.UI.WebControls.ListItem("Select", "0");
                                ddlstaire.Items.Insert(0, LI);

                                DataSet daquerieall = new DataSet();
                                daquerieall = Gen.GetIncetiveDetailsdeptOfficerRemarks(Applicantinid, Status, SentFrom, "ADDL", "ALL", Incids);
                                if (daquerieall != null && daquerieall.Tables.Count > 12 && daquerieall.Tables[12].Rows.Count > 0)
                                {
                                    gvrejctedslc.DataSource = daquerieall.Tables[12];
                                    gvrejctedslc.DataBind();
                                    Div16.Visible = true;
                                    tr10.Visible = true;
                                }
                                if (daquerieall != null && daquerieall.Tables.Count > 11 && daquerieall.Tables[11].Rows.Count > 0)
                                {
                                    gvrejectedaddlsvc.DataSource = daquerieall.Tables[11];
                                    gvrejectedaddlsvc.DataBind();
                                    Div13.Visible = true;
                                    tr9.Visible = true;
                                }
                                if (daquerieall != null && daquerieall.Tables.Count > 9 && daquerieall.Tables[9].Rows.Count > 0)
                                {
                                    gvadditionalRejected.DataSource = daquerieall.Tables[9];
                                    gvadditionalRejected.DataBind();
                                    Div2.Visible = true;
                                    tr11.Visible = true;
                                }
                                if (daquerieall != null && daquerieall.Tables.Count > 10 && daquerieall.Tables[10].Rows.Count > 0)
                                {
                                    tr8.Visible = true;
                                    gvaddlabeyanced.DataSource = daquerieall.Tables[10];
                                    gvaddlabeyanced.DataBind();
                                    Div2.Visible = true;
                                }
                                if (daquerieall != null && daquerieall.Tables.Count > 2 && daquerieall.Tables[2].Rows.Count > 0)
                                {
                                    spanaddljdstatusbar.InnerHtml = "Recommended by Additional Director";
                                    if (daquerieall != null && daquerieall.Tables.Count > 0 && daquerieall.Tables[0].Rows.Count > 0)
                                    {
                                        Div13.Visible = true;
                                        gvpresvc.DataSource = daquerieall.Tables[0]; ;
                                        gvpresvc.DataBind();
                                    }
                                    if (daquerieall != null && daquerieall.Tables.Count > 1 && daquerieall.Tables[1].Rows.Count > 0)
                                    {
                                        Div16.Visible = true;
                                        gvpostsvc.DataSource = daquerieall.Tables[1];
                                        gvpostsvc.DataBind();
                                    }

                                    if (daquerieall != null && daquerieall.Tables.Count > 2 && daquerieall.Tables[2].Rows.Count > 0)
                                    {
                                        Div7.Visible = true;
                                        gvreconbyjdjd.DataSource = daquerieall.Tables[2];
                                        gvreconbyjdjd.DataBind();
                                        tr14.Visible = true;
                                    }
                                    if (daquerieall != null && daquerieall.Tables.Count > 13 && daquerieall.Tables[13].Rows.Count > 0)
                                    {
                                        Div7.Visible = true;
                                        GridView6.DataSource = daquerieall.Tables[13];
                                        GridView6.DataBind();
                                        tr12.Visible = true;
                                        tr13.Visible = true;
                                        HyperLink3.NavigateUrl = "ProformaQueryRaiseShortFallLetter.aspx?incentiveid=" + Applicantinid;
                                    }


                                    if (daquerieall != null && daquerieall.Tables.Count > 3 && daquerieall.Tables[3].Rows.Count > 0)
                                    {
                                        Div7.Visible = true;
                                        jdqueryhistory.DataSource = daquerieall.Tables[3];
                                        jdqueryhistory.DataBind();
                                        tr7.Visible = true;
                                    }
                                    if (daquerieall != null && daquerieall.Tables.Count > 4 && daquerieall.Tables[4].Rows.Count > 0)
                                    {
                                        tradditionalforwared.InnerHtml = "Forwarded to SVC";
                                        Div2.Visible = true;
                                        trProcessedApplications.Visible = true;
                                        gvProcessedApplications.DataSource = daquerieall.Tables[4];
                                        gvProcessedApplications.DataBind();
                                    }

                                    if (daquerieall != null && daquerieall.Tables.Count > 5 && daquerieall.Tables[5].Rows.Count > 0)
                                    {
                                        Div2.Visible = true;
                                        gvpendingapplications.DataSource = daquerieall.Tables[5];
                                        gvpendingapplications.DataBind();
                                        trPendingApplications.Visible = true;

                                        //trjdqueryletter.Visible = true; // commented by shankar on 21-01-2019
                                        //HyperLinktrjdqueryletter.NavigateUrl = "ProformaQueryRaiseShortFallLetter.aspx?incentiveid=" + Applicantinid;
                                        if (daquerieall.Tables[5].Rows[0]["status"].ToString() != "SSC")// aDDED BY MADHURI ON 17/12/2021
                                        { HyperLinktrjdqueryletter.NavigateUrl = "ProformaQueryRaiseShortFallLetter.aspx?incentiveid=" + Applicantinid; }
                                        else
                                        {
                                            trjdqueryletter.Visible = false;
                                        }
                                    }
                                    if (daquerieall != null && daquerieall.Tables.Count > 6 && daquerieall.Tables[6].Rows.Count > 0)
                                    {
                                        Div2.Visible = true;
                                        gvresponcegmgv.DataSource = daquerieall.Tables[6];
                                        gvresponcegmgv.DataBind();
                                        tr1gmresponce.Visible = true;
                                        tr1gmresponce2.Visible = true;
                                    }
                                }
                                else
                                {
                                    DataSet daquerie = new DataSet();
                                    daquerie = Gen.GetIncetiveDetailsdeptOfficerRemarks(Applicantinid, Status, SentFrom, "JD", "", Incids);

                                    if (daquerie != null && daquerie.Tables.Count > 0 && daquerie.Tables["Table"].Rows.Count > 0)
                                    {
                                        Div2.Visible = true;
                                        string ids = "0";
                                        if (Incids != null && Incids != "")
                                        {
                                            int result;
                                            DataTable dt = FilterDataTableBasedOnIncentiveIds(daquerie, Incids, 0, "MstIncentiveId", out result);
                                            daquerie.Tables.Add(dt);
                                            ids = (result == 1) ? Incids : "0";
                                        }

                                        gvpendingapplications.DataSource = daquerie.Tables["Table"];
                                        gvpendingapplications.DataBind();
                                        trPendingApplications.Visible = true;

                                        // trjdqueryletter.Visible = true; // commented by shankar on 21-01-2019

                                        if (daquerie.Tables[0].Rows[0]["status"].ToString() != "SSC")
                                        { HyperLinktrjdqueryletter.NavigateUrl = "ProformaQueryRaiseShortFallLetter.aspx?incentiveid=" + Applicantinid + "&IncIds=" + ids; }
                                        else
                                        {
                                            trjdqueryletter.Visible = false;
                                        }
                                    }

                                    if (daquerie != null && daquerie.Tables.Count > 1 && daquerie.Tables["Table1"].Rows.Count > 0)
                                    {
                                        Div2.Visible = true;
                                        gvresponcegmgv.DataSource = daquerie.Tables["Table1"];
                                        gvresponcegmgv.DataBind();
                                        tr1gmresponce.Visible = true;
                                        tr1gmresponce2.Visible = true;
                                    }

                                    if (daquerie != null && daquerie.Tables.Count > 2 && daquerie.Tables["Table2"].Rows.Count > 0)
                                    {
                                        Div2.Visible = true;
                                        trProcessedApplications.Visible = true;
                                        gvProcessedApplications.DataSource = daquerie.Tables["Table2"];
                                        gvProcessedApplications.DataBind();
                                    }
                                }
                            }
                            if (Role_Code == "ADDL")
                            {
                                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                                {
                                    BindingGmRecommendedIncentives(ds.Tables[1]);
                                }
                                DataSet dsince = new DataSet();
                                dsince = Gen.GetIncetiveDropDownList(Applicantinid, "ADDL", Request.QueryString["SVCStatus"].ToString(), Incids);
                                if (dsince != null && dsince.Tables.Count > 0 && dsince.Tables[0].Rows.Count > 0)
                                {
                                    ddlstaire.DataSource = dsince.Tables[0];
                                    ddlstaire.DataValueField = "MstIncentiveId";
                                    ddlstaire.DataTextField = "IncentiveName";
                                    ddlstaire.DataBind();
                                }

                                System.Web.UI.WebControls.ListItem LIadd = new System.Web.UI.WebControls.ListItem("Select", "0");
                                ddlstaire.Items.Insert(0, LIadd);

                                divnewattachemts.Visible = true;
                                divlastattachemntold.Visible = false;
                                Button3.Text = "Refer to SVC";


                                trYettobeassign2.Visible = false;
                                divgm.Visible = false;
                                trinspectionname.InnerHtml = "Recommended by GM-DIC(" + ds.Tables[0].Rows[0]["UnitDistName"].ToString() + ")";
                                spanaddljdstatusbar.InnerHtml = "Recommended by Additional Director";// "Status of Application at Additional Director";
                                trInspectionReport2.Visible = true;
                                trInspectionReport4.Visible = false;
                                trRemarks1.Visible = true;

                                if (Request.QueryString["SVCStatus"] != null && Request.QueryString["SVCStatus"].ToString() == "POSTSVC")
                                {
                                    CheckBoxList1.Items[0].Text = "Sanction Amount";
                                    CheckBoxList1.Items[1].Text = "Reject";
                                    // trpostsvc.Visible = true;
                                    tradditional.Visible = false;
                                    Button3.Text = "Intimate SVC Date";

                                }
                                if (Request.QueryString["SVCStatus"] != null && Request.QueryString["SVCStatus"].ToString() == "POSTSLC")
                                {
                                    CheckBoxList1.Items[0].Text = "Sanction Amount";
                                    CheckBoxList1.Items[1].Text = "Reject";
                                    Label6.Text = "Sanctioned Amount";
                                    // trpostsvc.Visible = false;
                                    tradditional.Visible = true;
                                    Button3.Text = "Submit Application";
                                }

                                trfullshap.Visible = false;
                                gvremarks.Visible = false;

                                string SVCStatus = "";
                                if (Request.QueryString["SVCStatus"] != null)
                                {
                                    SVCStatus = Request.QueryString["SVCStatus"].ToString();
                                }

                                DataSet daquerie = new DataSet();
                                DataSet daquerieall = new DataSet();
                                // daquerie = Gen.GetIncetiveDetailsdeptOfficerRemarks(Applicantinid, Status, SentFrom, "JD", "");

                                daquerieall = Gen.GetIncetiveDetailsdeptOfficerRemarks(Applicantinid, Status, SentFrom, "ADDL", "ALL", Incids);

                                if (daquerieall != null && daquerieall.Tables.Count > 12 && daquerieall.Tables[12].Rows.Count > 0)
                                {
                                    gvrejctedslc.DataSource = daquerieall.Tables[12];
                                    gvrejctedslc.DataBind();
                                    Div16.Visible = true;
                                    tr10.Visible = true;
                                }
                                if (daquerieall != null && daquerieall.Tables.Count > 11 && daquerieall.Tables[11].Rows.Count > 0)
                                {
                                    gvrejectedaddlsvc.DataSource = daquerieall.Tables[11];
                                    gvrejectedaddlsvc.DataBind();
                                    Div13.Visible = true;
                                    tr9.Visible = true;
                                }
                                if (daquerieall != null && daquerieall.Tables.Count > 9 && daquerieall.Tables[9].Rows.Count > 0)
                                {
                                    gvadditionalRejected.DataSource = daquerieall.Tables[9];
                                    gvadditionalRejected.DataBind();
                                    Div2.Visible = true;
                                    tr11.Visible = true;
                                }
                                if (daquerieall != null && daquerieall.Tables.Count > 10 && daquerieall.Tables[10].Rows.Count > 0)
                                {
                                    tr8.Visible = true;
                                    gvaddlabeyanced.DataSource = daquerieall.Tables[10];
                                    gvaddlabeyanced.DataBind();
                                    Div2.Visible = true;
                                }

                                if (daquerieall != null && daquerieall.Tables.Count > 0 && daquerieall.Tables[0].Rows.Count > 0)
                                {
                                    Div13.Visible = true;
                                    gvpresvc.DataSource = daquerieall;
                                    gvpresvc.DataBind();
                                    if (daquerieall != null && daquerieall.Tables.Count > 1 && daquerieall.Tables[1].Rows.Count > 0)
                                    {
                                        Div16.Visible = true;
                                        gvpostsvc.DataSource = daquerieall.Tables[1];
                                        gvpostsvc.DataBind();
                                    }

                                    if (daquerieall != null && daquerieall.Tables.Count > 2 && daquerieall.Tables[2].Rows.Count > 0)
                                    {
                                        Div7.Visible = true;
                                        gvreconbyjdjd.DataSource = daquerieall.Tables[2];
                                        gvreconbyjdjd.DataBind();
                                        tr14.Visible = true;
                                    }
                                    if (daquerieall != null && daquerieall.Tables.Count > 13 && daquerieall.Tables[13].Rows.Count > 0)
                                    {
                                        Div7.Visible = true;
                                        GridView6.DataSource = daquerieall.Tables[13];
                                        GridView6.DataBind();
                                        tr12.Visible = true;
                                        tr13.Visible = true;
                                        HyperLink3.NavigateUrl = "ProformaQueryRaiseShortFallLetter.aspx?incentiveid=" + Applicantinid;
                                    }
                                    if (daquerieall != null && daquerieall.Tables.Count > 3 && daquerieall.Tables[3].Rows.Count > 0)
                                    {
                                        Div7.Visible = true;
                                        jdqueryhistory.DataSource = daquerieall.Tables[3];
                                        jdqueryhistory.DataBind();
                                        tr7.Visible = true;
                                    }
                                    if (daquerieall != null && daquerieall.Tables.Count > 4 && daquerieall.Tables[4].Rows.Count > 0)
                                    {
                                        tradditionalforwared.InnerHtml = "Forwarded to SVC";
                                        Div2.Visible = true;
                                        trProcessedApplications.Visible = true;
                                        gvProcessedApplications.DataSource = daquerieall.Tables[4];
                                        gvProcessedApplications.DataBind();
                                    }

                                    if (daquerieall != null && daquerieall.Tables.Count > 5 && daquerieall.Tables[5].Rows.Count > 0)
                                    {
                                        Div2.Visible = true;
                                        gvpendingapplications.DataSource = daquerieall.Tables[5];
                                        gvpendingapplications.DataBind();
                                        trPendingApplications.Visible = true;

                                        // trjdqueryletter.Visible = true; // commented by shankar on 21-01-2019
                                        //HyperLinktrjdqueryletter.NavigateUrl = "ProformaQueryRaiseShortFallLetter.aspx?incentiveid=" + Applicantinid;
                                        if (daquerieall.Tables[5].Rows[0]["status"].ToString() != "SSC")// added by madhuri on 17/12/2021
                                        { HyperLinktrjdqueryletter.NavigateUrl = "ProformaQueryRaiseShortFallLetter.aspx?incentiveid=" + Applicantinid; }
                                        else
                                        {
                                            trjdqueryletter.Visible = false;
                                        }
                                    }
                                    if (daquerieall != null && daquerieall.Tables.Count > 6 && daquerieall.Tables[6].Rows.Count > 0)
                                    {
                                        Div2.Visible = true;

                                        gvresponcegmgv.DataSource = daquerieall.Tables[6];
                                        gvresponcegmgv.DataBind();
                                        tr1gmresponce.Visible = true;
                                        tr1gmresponce2.Visible = true;
                                    }
                                }
                                else
                                {
                                    daquerie = Gen.GetIncetiveDetailsdeptOfficerRemarks(Applicantinid, Status, SentFrom, "ADDL", SVCStatus, Incids);

                                    if (daquerie != null && daquerie.Tables.Count > 0 && daquerie.Tables[0].Rows.Count > 0)
                                    {
                                        Div2.Visible = true;
                                        gvpendingapplications.DataSource = daquerie.Tables[0];
                                        gvpendingapplications.DataBind();
                                        trPendingApplications.Visible = true;

                                        //trjdqueryletter.Visible = true; // commented by shankar on 21-01-2019
                                        //HyperLinktrjdqueryletter.NavigateUrl = "ProformaQueryRaiseShortFallLetter.aspx?incentiveid=" + Applicantinid;
                                        if (daquerie.Tables[0].Rows[0]["status"].ToString() != "SSC")// added by madhuri on 17/12/2021
                                        { HyperLinktrjdqueryletter.NavigateUrl = "ProformaQueryRaiseShortFallLetter.aspx?incentiveid=" + Applicantinid; }
                                        else
                                        {
                                            trjdqueryletter.Visible = false;
                                        }
                                    }

                                    if (daquerie != null && daquerie.Tables.Count > 1 && daquerie.Tables[1].Rows.Count > 0)
                                    {
                                        Div2.Visible = true;
                                        gvresponcegmgv.DataSource = daquerie.Tables[1];
                                        gvresponcegmgv.DataBind();
                                        tr1gmresponce.Visible = true;
                                        tr1gmresponce2.Visible = true;
                                    }

                                    if (daquerie != null && daquerie.Tables.Count > 2 && daquerie.Tables[2].Rows.Count > 0)
                                    {
                                        tradditionalforwared.InnerHtml = "Forwarded to SVC";
                                        Div2.Visible = true;
                                        trProcessedApplications.Visible = true;
                                        gvProcessedApplications.DataSource = daquerie.Tables[2];
                                        gvProcessedApplications.DataBind();
                                    }
                                    if (daquerie != null && daquerie.Tables.Count > 3 && daquerie.Tables[3].Rows.Count > 0)
                                    {
                                        Div7.Visible = true;
                                        gvreconbyjdjd.DataSource = daquerie.Tables[3];
                                        gvreconbyjdjd.DataBind();
                                        tr14.Visible = true;
                                    }
                                    if (daquerie != null && daquerie.Tables.Count > 5 && daquerie.Tables[5].Rows.Count > 0)
                                    {
                                        Div7.Visible = true;
                                        GridView6.DataSource = daquerieall.Tables[13];
                                        GridView6.DataBind();
                                        tr12.Visible = true;
                                        tr13.Visible = true;
                                        HyperLink3.NavigateUrl = "ProformaQueryRaiseShortFallLetter.aspx?incentiveid=" + Applicantinid;
                                    }
                                    if (daquerieall != null && daquerieall.Tables.Count > 6 && daquerieall.Tables[6].Rows.Count > 0)
                                    {
                                        Div2.Visible = true;
                                        gvresponcegmgv.DataSource = daquerieall.Tables[6];
                                        gvresponcegmgv.DataBind();
                                        tr1gmresponce.Visible = true;
                                        tr1gmresponce2.Visible = true;
                                    }
                                    if (daquerie != null && daquerie.Tables.Count > 4 && daquerie.Tables[4].Rows.Count > 0)
                                    {
                                        if (SVCStatus == "PRESVC")
                                        {
                                            jdqueryhistory.DataSource = daquerie.Tables[4];
                                            jdqueryhistory.DataBind();
                                            tr7.Visible = true;
                                        }
                                        else
                                        {
                                            Div13.Visible = true;
                                            gvpresvc.DataSource = daquerie.Tables[4];
                                            gvpresvc.DataBind();
                                        }
                                    }
                                    //if (daquerie != null && daquerie.Tables.Count > 5 && daquerie.Tables[5].Rows.Count > 0)
                                    //{
                                    //    Div16.Visible = true;
                                    //    gvpostsvc.DataSource = daquerie.Tables[5];
                                    //    gvpostsvc.DataBind();
                                    //}

                                    if (DisignationLoad == "ADDL")
                                    {
                                        trfullshap.Visible = false;
                                        gvremarks.Visible = false;
                                    }
                                }
                                ////// ADDED BY MADHURI ON 18/08/2021/////
                                if (Role_Code == "ADDL")
                                {

                                    DataSet dsADQuery = new DataSet();
                                    dsADQuery = GetADQueryHistory(Applicantinid, Role_Code, Incids);
                                    //GVIOQueryStatus.DataSource = null;
                                    //GVIOQueryStatus.DataBind();
                                    if (dsADQuery != null && dsADQuery.Tables.Count > 0 && dsADQuery.Tables[0].Rows.Count > 0)
                                    {
                                        GVADQueryStatus.DataSource = dsADQuery.Tables[0];
                                        GVADQueryStatus.DataBind();
                                        //trqueryDtls1IO.Visible = true;
                                        DivAD21.Visible = true;

                                    }


                                    else
                                    {
                                        //trqueryDtls1IO.Visible = false;
                                        DivAD21.Visible = false;
                                    }

                                    DataSet dsADrec = new DataSet();
                                    dsADrec = GetIncetiveDetailsdeptAD(Applicantinid, Status, Userid, Userid, Incids);
                                    gvadrecommended.DataSource = null;
                                    gvadrecommended.DataBind();
                                    if (dsADrec != null && dsADrec.Tables.Count > 0 && dsADrec.Tables[0].Rows.Count > 0)
                                    {
                                        //gvadrecommended.DataSource = dsADrec.Tables[0];
                                        //gvadrecommended.DataBind();
                                        //trqueryDtls1IO.Visible = true;
                                        DivADR21.Visible = true;
                                        BindingADRecommendedIncentives(dsADrec.Tables[0]);
                                        //if (Role_Code == "COI-AD")
                                        //{
                                        //    trRemarks_adlevel.Visible = false;
                                        //}
                                    }


                                    else
                                    {
                                        //trqueryDtls1IO.Visible = false;
                                        DivADR21.Visible = false;
                                    }

                                }
                                /// ADDED BY MADHURI ON 18/08/2021
                            }
                        }
                        catch (Exception ex)
                        {
                            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
                        }
                        DataSet dsnewre = new DataSet();
                        dsnewre = Gen.GetIncetiveDetailsdeptAttachementsIpo(Applicantinid, Convert.ToString(ViewState["MstIncentiveId"]));

                        if (dsnewre != null && dsnewre.Tables.Count > 0 && dsnewre.Tables[0].Rows.Count > 0)
                        {
                            GridView3att.DataSource = dsnewre.Tables[0];
                            GridView3att.DataBind();
                        }
                        //DataSet dscoutsidecheckslip = new DataSet();
                        //dscoutsidecheckslip = GETQUERYRESPONSEATTACHMENTSOUTSIDECHECKSLIP(Applicantinid, ViewState["MstIncentiveId"].ToString());

                        //if (dscoutsidecheckslip != null && dscoutsidecheckslip.Tables.Count > 0 && dscoutsidecheckslip.Tables[0].Rows.Count > 0)
                        //{
                        //    trqueryresponseattachmentsoutsidecheckslip.Visible = true;
                        //    gridviewresponseattachmentsoutsidecheckslip.DataSource = dscoutsidecheckslip.Tables[0];
                        //    gridviewresponseattachmentsoutsidecheckslip.DataBind();
                        //}

                        DataSet dsIPOREP = new DataSet();
                        dsIPOREP = GetInspectionreportData(Applicantinid, Incids);
                        if (dsIPOREP != null && dsIPOREP.Tables.Count > 0 && dsIPOREP.Tables[0].Rows.Count > 0)
                        {
                            if (dsIPOREP.Tables[0].Rows[0]["caste_IR"].ToString() != "" && dsIPOREP.Tables[0].Rows[0]["caste_IR"].ToString() != null)
                            {
                                rdbCaste.SelectedValue = dsIPOREP.Tables[0].Rows[0]["caste_IR"].ToString();
                                rdbCaste.Enabled = true;
                            }
                            if (dsIPOREP.Tables[0].Rows[0]["gender_IR"].ToString() != "" && dsIPOREP.Tables[0].Rows[0]["gender_IR"].ToString() != null)
                            {
                                rdbGender.SelectedValue = dsIPOREP.Tables[0].Rows[0]["gender_IR"].ToString();
                                rdbGender.Enabled = true;
                            }
                            if (dsIPOREP.Tables[0].Rows[0]["caste_IR"].ToString() != "" && dsIPOREP.Tables[0].Rows[0]["caste_IR"].ToString() != null)
                            {
                                rdbCategory.SelectedValue = dsIPOREP.Tables[0].Rows[0]["category_IR"].ToString();
                                rdbCategory.Enabled = true;
                            }
                            if (dsIPOREP.Tables[0].Rows[0]["enterprise_IR"].ToString() != "" && dsIPOREP.Tables[0].Rows[0]["enterprise_IR"].ToString() != null)
                            {
                                rdbEnterprise.SelectedValue = dsIPOREP.Tables[0].Rows[0]["enterprise_IR"].ToString();
                                rdbEnterprise.Enabled = true;
                            }
                            if (dsIPOREP.Tables[0].Rows[0]["sector_IR"].ToString() != "" && dsIPOREP.Tables[0].Rows[0]["sector_IR"].ToString() != null)
                            {
                                rdbSector.SelectedValue = dsIPOREP.Tables[0].Rows[0]["sector_IR"].ToString();
                                rdbSector.Enabled = true;
                                ViewState["casteGenderGmUpdate"] = "Y";
                                if (dsIPOREP.Tables[0].Rows[0]["sector_IR"].ToString() != "" || dsIPOREP.Tables[0].Rows[0]["sector_IR"] != null)
                                {


                                    rdbSector_SelectedIndexChanged(this, EventArgs.Empty);
                                    rdbSector.Enabled = true;
                                }
                            }
                            if (dsIPOREP.Tables[0].Rows[0]["serviceType_IR"].ToString() != "" && dsIPOREP.Tables[0].Rows[0]["serviceType_IR"].ToString() != null)
                            {
                                rdbServiceType.SelectedValue = dsIPOREP.Tables[0].Rows[0]["serviceType_IR"].ToString();
                                rdbServiceType.Enabled = true;
                                if (dsIPOREP.Tables[0].Rows[0]["serviceType_IR"].ToString() != "" || dsIPOREP.Tables[0].Rows[0]["serviceType_IR"] != null)
                                {
                                    rdbServiceType_SelectedIndexChanged(this, EventArgs.Empty);
                                    rdbServiceType.Enabled = true;
                                }
                            }
                            if (dsIPOREP.Tables[0].Rows[0]["transportNonTrans_IR"].ToString() != "" && dsIPOREP.Tables[0].Rows[0]["transportNonTrans_IR"].ToString() != null)
                            {
                                rdbTransportNonTrans.SelectedValue = dsIPOREP.Tables[0].Rows[0]["transportNonTrans_IR"].ToString();
                                rdbTransportNonTrans.Enabled = true;
                            }
                        }


                        DataSet dsnew = new DataSet();
                        dsnew = Gen.GetIncetiveDetailsdeptQUERY(Applicantinid, Incids);
                        if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                        {
                            gvquery.DataSource = dsnew.Tables[0];
                            gvquery.DataBind();
                            gvquery.Visible = true;
                            Spangmdicquery.InnerHtml = "GM-DIC(" + ds.Tables[0].Rows[0]["UnitDistName"].ToString() + ") - Query History";
                        }
                        if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[1].Rows.Count > 0)
                        {
                            grdOfficerChangeHistory.DataSource = dsnew.Tables[1];
                            grdOfficerChangeHistory.DataBind();
                            grdOfficerChangeHistory.Visible = true;
                            trOfficerChangeHistory.Visible = true;

                            grdOfficerChangeHistoryIPO.DataSource = dsnew.Tables[1];
                            grdOfficerChangeHistoryIPO.DataBind();
                            grdOfficerChangeHistoryIPO.Visible = true;
                            trOfficerChangeHistoryIPO.Visible = true;
                        }
                        if (gvquery.Rows.Count < 1)
                        {
                            trgmhistory.Visible = false;
                        }
                        DataSet dsnew1 = new DataSet();
                        dsnew1 = Gen.GetIncetiveDetailsdeptAttachements(Applicantinid);
                        if (dsnew1 != null && dsnew1.Tables.Count > 0 && dsnew1.Tables[0].Rows.Count > 0)
                        {
                            gvSubsidy.DataSource = dsnew1.Tables[0];
                            gvSubsidy.DataBind();

                            gvfinalgrid.DataSource = dsnew1.Tables[0];
                            gvfinalgrid.DataBind();

                            if (dsnew1 != null && dsnew1.Tables.Count > 1 && dsnew1.Tables[1].Rows.Count > 0)
                            {
                                trQueryResponceAttachments.Visible = true;
                                gvqquryresponceattachment.DataSource = dsnew1.Tables[1];
                                gvqquryresponceattachment.DataBind();

                                trattachemntslastgrid.Visible = true;
                                gvlastattachments.DataSource = dsnew1.Tables[1];
                                gvlastattachments.DataBind();
                            }
                        }
                        if (dsnew1 != null && dsnew1.Tables.Count > 4 && dsnew1.Tables[4].Rows.Count > 0)
                        {
                            trsscattachment.Visible = true;
                            gvsscreport.DataSource = dsnew1.Tables[4];
                            gvsscreport.DataBind();

                            trsscattachment1.Visible = true;
                            gvsscreport1.DataSource = dsnew1.Tables[4];
                            gvsscreport1.DataBind();
                        }
                        else
                        {
                            trsscattachment1.Visible = false;
                        }
                        if (dsnew1 != null && dsnew1.Tables.Count > 2 && dsnew1.Tables[2].Rows.Count > 0)
                        {
                            gvsupportingdocshead.Visible = true;
                            gvsupportingdocs.DataSource = dsnew1.Tables[2];
                            gvsupportingdocs.DataBind();

                            Inspectionhead2.Visible = true;
                            hvInspection.DataSource = dsnew1.Tables[2];
                            hvInspection.DataBind();
                        }
                        else
                        {
                            gvsupportingdocshead.Visible = false;
                        }

                        if (dsnew1 != null && dsnew1.Tables.Count > 3 && dsnew1.Tables[3].Rows.Count > 0)
                        {
                            divnewattachemts.Visible = true;
                            tr19.Visible = true;
                            GridView14.DataSource = dsnew1.Tables[3];
                            GridView14.DataBind();
                        }
                        else
                        {
                            tr19.Visible = false;
                        }

                        if (Session["uid"].ToString() != "21345")
                        {
                            DataSet dsaddlsc = new DataSet();
                            dsaddlsc = GetAddlSSCData(Request.QueryString[0].ToString(), Status, SentFrom, "AD", Incids);
                            if (dsaddlsc != null && dsaddlsc.Tables.Count > 0 && dsaddlsc.Tables[0].Rows.Count > 0)
                            {
                                Div49.Visible = true;
                                traddlssc.Visible = true;
                                //trqueryDtls.Visible = true;
                                //trQueryletter.Visible = true; // commented by shankar on 21-01-2019
                                //trsendresponcetocoi.Visible = true;
                                gvsscinspection.DataSource = dsaddlsc.Tables[0];
                                gvsscinspection.DataBind();


                                //HySSCinsp.NavigateUrl = dsaddlsc.Tables[0].Rows[0]["SSCREPORT"].ToString();

                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    //throw ex;
                    Response.Write(ex);
                    LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
                }

                string userid = "";

                if (Session["Role_Code"].ToString() == "COI-AD" || Session["Role_Code"].ToString() == "COI-DD" || Session["Role_Code"].ToString() == "COI-SUPDT")
                {
                    userid = "3377";
                }
                else
                {
                    userid = Session["uid"].ToString();
                }
                if (Session["uid"] != null)
                {
                    string uname = Session["username"].ToString();
                    // 
                    string incentiveID;
                    if (Session["EntprIncentive"] != null)
                    {

                        incentiveID = Session["EntprIncentive"].ToString();
                    }
                    else
                    {
                        incentiveID = Request.QueryString["EntrpId"].ToString();
                    }

                    //dsCAF = Gen.GetAllIncentives(Session["uid"].ToString().Trim());      
                    if (Request.QueryString[1].ToString() != "91")
                    {
                        dsCAF = Gen.GetAllIncentivesDeptView(incentiveID);
                        string IncentiveId = dsCAF.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
                        if (IncentiveId != null)
                        {
                            if (!IsPostBack)
                            {
                                string useridnew = "";

                                if (Session["Role_Code"].ToString() == "COI-AD" || Session["Role_Code"].ToString() == "COI-DD" || Session["Role_Code"].ToString() == "COI-SUPDT")
                                {
                                    useridnew = "3377";
                                }
                                else
                                {
                                    useridnew = Session["uid"].ToString();
                                }

                                string IncentveID = incentiveID;
                                DataSet dscaste = new DataSet();
                                dscaste = Gen.GetIncentivesCaste(useridnew, IncentveID);
                                if (dscaste != null && dscaste.Tables.Count > 0 && dscaste.Tables[0].Rows.Count > 0)
                                {
                                    string MSMEApplied = Convert.ToString(dscaste.Tables[0].Rows[0]["MSME_Applied"]);
                                    hdnMSMEApplied.Value= Convert.ToString(dscaste.Tables[0].Rows[0]["MSME_Applied"]);
                                    hdnIsDifferentlyAbled.Value = Convert.ToString(dscaste.Tables[0].Rows[0]["IsDifferentlyAbled"]);
                                    hdnCaste.Value = Convert.ToString(dscaste.Tables[0].Rows[0]["caste"]);
                                    hdnScheme.Value = Convert.ToString(dscaste.Tables[0].Rows[0]["Scheme"]);
                                    string msmepolicy = "";
                                    if (MSMEApplied == "Y")
                                        msmepolicy = "MSME - 2024";
                                    if (dscaste.Tables[0].Rows[0]["IsDifferentlyAbled"].ToString() != "")
                                        if (dscaste.Tables[0].Rows[0]["IsDifferentlyAbled"].ToString() == "Y")
                                        {
                                            lblheadTPRIDE.Text = "T-PRIDE(PHC)";  //ADDED..
                                            lblMsmeHdng.Text = "SC/ST/PwD";
                                        }

                                        else if (dscaste.Tables[0].Rows[0]["Scheme"].ToString() != "" && dscaste.Tables[0].Rows[0]["Scheme"].ToString() != null)
                                        {
                                            lblheadTPRIDE.Text = "TIDEA, 2014";

                                            if (dscaste.Tables[0].Rows[0]["TSCPflag"].ToString() == "Y") //   if (caste == "3" || caste == "4")   //SC, ST
                                            {
                                                lblheadTPRIDE.Visible = true;

                                                lblheadTPRIDE.Text = "T-PRIDE ";
                                                lblMsmeHdng.Text = "SC/ST/PwD";
                                                //lblheadTPRIDE.ForeColor = System.Drawing.Color.White;
                                            }
                                            else if (dscaste.Tables[0].Rows[0]["TSPflag"].ToString() == "Y")
                                            {
                                                lblheadTPRIDE.Visible = true;

                                                lblheadTPRIDE.Text = "T-PRIDE ";
                                                lblMsmeHdng.Text = "SC/ST/PwD";
                                            }
                                            //else if (dscaste.Tables[0].Rows[0]["TIDEAflag"].ToString() == "Y")
                                            //{
                                            //    lblheadTPRIDE.Visible = true;

                                            //    lblheadTPRIDE.Text = "T-IDEA";
                                            //}
                                            else if (dscaste.Tables[0].Rows[0]["TIDEAflag"].ToString() == "Y" && dscaste.Tables[0].Rows[0]["IDFOODPROCESSING"].ToString() != "Y")
                                            {
                                                lblheadTPRIDE.Visible = true;

                                                lblheadTPRIDE.Text = "T-IDEA";
                                                lblMsmeHdng.Text = "General";
                                            }
                                            else if (dscaste.Tables[0].Rows[0]["TIDEAflag"].ToString() == "Y" && dscaste.Tables[0].Rows[0]["IDFOODPROCESSING"].ToString() == "Y")
                                            {
                                                lblheadTPRIDE.Visible = true;

                                                lblheadTPRIDE.Text = "TFAP";
                                            }

                                        }
                                        else if (dscaste.Tables[0].Rows[0]["Scheme"].ToString() == "TFAP")
                                        {
                                            lblheadTPRIDE.Visible = true;

                                            lblheadTPRIDE.Text = "TFAP";
                                        }
                                        else if (dscaste.Tables[0].Rows[0]["Scheme"].ToString() == "IIPP SCHEME 2005-10")
                                        {
                                            lblheadTPRIDE.Text = "IIPP Scheme 2005 - 2010";
                                        }
                                        else if (dscaste.Tables[0].Rows[0]["Scheme"].ToString() == "IIPP SCHEME 2010-15")
                                        {
                                            lblheadTPRIDE.Text = "IIPP Scheme 2010 - 2015";   // IIPP 2010-15
                                        }
                                    lblheadTPRIDE.Text = lblheadTPRIDE.Text + msmepolicy;
                                    if (MSMEApplied == "Y")
                                    {
                                        lblheadTPRIDE.Visible = false;
                                        lblMsmeHdng.Text = msmepolicy;
                                       // lblMsmeHdng.Text = msmepolicy + " (" + lblMsmeHdng.Text+" Category) ";
                                        lblMsmeHdng.Visible = true;
                                    }
                                    string caste = dscaste.Tables[0].Rows[0]["caste"].ToString();

                                    if (dscaste.Tables[0].Rows[0]["IdsustryStatus"].ToString() == "2" || dscaste.Tables[0].Rows[0]["IdsustryStatus"].ToString() == "3")
                                    {
                                        trexpansion.Visible = true;
                                        trexpansionhead.Visible = true;
                                        tblpower.Visible = true;

                                        tr1.Visible = false;
                                        tr3.Visible = true;
                                    }
                                    else
                                    {
                                        trexpansion.Visible = false;
                                        trexpansionhead.Visible = false;
                                        tblpower.Visible = false;

                                        tr1.Visible = true;
                                        tr3.Visible = false;
                                    }
                                }

                                if (Request.QueryString[1].ToString() != "91")
                                    ds = Gen.GetIncentiveDeptDetails(IncentiveId);
                                if (Request.QueryString[1].ToString() != "91")//check here
                                    FillDetailsabc(ds);


                                if (Request.QueryString[1].ToString() != "91")
                                {
                                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                    {
                                        if (dsCAF != null && dsCAF.Tables.Count > 0 && dsCAF.Tables[0].Rows.Count > 0)
                                        {
                                            BindForms(dsCAF, IncentiveId);
                                        }
                                    }
                                }


                            }
                        }
                        else
                        {
                            if (!IsPostBack)
                            {
                                ds = Gen.GetIncentiveDeptDetailsCreatedBy(userid);
                                string IncentID = FillDetailsabc(ds);

                                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                {
                                    if (dsCAF != null && dsCAF.Tables.Count > 0 && dsCAF.Tables[0].Rows.Count > 0)
                                    {
                                        BindForms(dsCAF, IncentID);
                                    }
                                }
                            }
                        }
                    }

                    else if (Request.QueryString[1].ToString() == "91")
                    {
                        string incentiveID_Rej = Request.QueryString["EntrpId"].ToString();
                        SqlConnection osqlconn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString); ;
                        osqlconn.Open();

                        SqlDataAdapter da;
                        DataSet ds = new DataSet();
                        try
                        {
                            da = new SqlDataAdapter("[FetchIncentives_CAF_DEPT_Rejection]", osqlconn);
                            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand.Parameters.Add("@IncentiveID", SqlDbType.VarChar).Value = incentiveID_Rej;
                            da.Fill(dsCAF_Rej);

                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        finally
                        {
                            osqlconn.Close();
                        }
                        string IncentiveId = dsCAF_Rej.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
                        if (IncentiveId != null)
                        {
                            string useridnew = "";
                            if (Session["Role_Code"].ToString() == "COI-AD" || Session["Role_Code"].ToString() == "COI-DD" || Session["Role_Code"].ToString() == "COI-SUPDT")
                            {
                                useridnew = "3377";
                            }
                            else
                            {
                                useridnew = Session["uid"].ToString();
                            }
                            DataSet dscaste = new DataSet();
                            dscaste = Gen.GetIncentivesCaste(useridnew, IncentiveId);
                            if (dscaste != null && dscaste.Tables.Count > 0 && dscaste.Tables[0].Rows.Count > 0)
                            {
                                string MSMEApplied = Convert.ToString(dscaste.Tables[0].Rows[0]["MSME_Applied"]);
                                string msmepolicy = "";
                                if (MSMEApplied == "Y")
                                    msmepolicy = "MSME - 2024";
                                if (dscaste.Tables[0].Rows[0]["IsDifferentlyAbled"].ToString() != "")
                                    if (dscaste.Tables[0].Rows[0]["IsDifferentlyAbled"].ToString() == "Y")
                                        lblheadTPRIDE.Text = "T-PRIDE(PHC)";  //ADDED..

                                    else if (dscaste.Tables[0].Rows[0]["Scheme"].ToString() == "TIDEA")
                                    {
                                        lblheadTPRIDE.Text = "TIDEA, 2014";

                                        if (dscaste.Tables[0].Rows[0]["TSCPflag"].ToString() == "Y") //   if (caste == "3" || caste == "4")   //SC, ST
                                        {
                                            lblheadTPRIDE.Visible = true;

                                            lblheadTPRIDE.Text = "T-PRIDE ";
                                            //lblheadTPRIDE.ForeColor = System.Drawing.Color.White;
                                        }
                                        else if (dscaste.Tables[0].Rows[0]["TSPflag"].ToString() == "Y")
                                        {
                                            lblheadTPRIDE.Visible = true;

                                            lblheadTPRIDE.Text = "T-PRIDE ";
                                        }
                                        else if (dscaste.Tables[0].Rows[0]["TIDEAflag"].ToString() == "Y")
                                        {
                                            lblheadTPRIDE.Visible = true;

                                            lblheadTPRIDE.Text = "T-IDEA";
                                        }

                                    }
                                    else if (dscaste.Tables[0].Rows[0]["Scheme"].ToString() == "IIPP SCHEME 2005-10")
                                    {
                                        lblheadTPRIDE.Text = "IIPP Scheme 2005 - 2010";
                                    }
                                    else if (dscaste.Tables[0].Rows[0]["Scheme"].ToString() == "IIPP SCHEME 2010-15")
                                    {
                                        lblheadTPRIDE.Text = "IIPP Scheme 2010 - 2015";   // IIPP 2010-15
                                    }
                                lblheadTPRIDE.Text = lblheadTPRIDE.Text + msmepolicy;
                                if (MSMEApplied == "Y")
                                {
                                    lblheadTPRIDE.Visible = false;
                                    lblMsmeHdng.Text = msmepolicy;
                                    // lblMsmeHdng.Text = msmepolicy + " (" + lblMsmeHdng.Text+" Category) ";
                                    lblMsmeHdng.Visible = true;
                                }
                                string caste = dscaste.Tables[0].Rows[0]["caste"].ToString();

                                if (dscaste.Tables[0].Rows[0]["IdsustryStatus"].ToString() == "2" || dscaste.Tables[0].Rows[0]["IdsustryStatus"].ToString() == "3")
                                {
                                    trexpansion.Visible = true;
                                    trexpansionhead.Visible = true;
                                    tblpower.Visible = true;

                                    tr1.Visible = false;
                                    tr3.Visible = true;
                                }
                                else
                                {
                                    trexpansion.Visible = false;
                                    trexpansionhead.Visible = false;
                                    tblpower.Visible = false;

                                    tr1.Visible = true;
                                    tr3.Visible = false;
                                }
                            }
                            SqlConnection osqlconn1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString); ;
                            osqlconn1.Open();
                            SqlDataAdapter da1;
                            DataSet dss1 = new DataSet();
                            try
                            {
                                da1 = new SqlDataAdapter("USP_GET_DEPT_INCENTIVE_DATA_Rejected", osqlconn1);
                                da1.SelectCommand.CommandType = CommandType.StoredProcedure;

                                if (incentiveID.ToString() != "" || incentiveID.ToString() != null)
                                {
                                    // da.SelectCommand.Parameters.Add("intUserID", SqlDbType.VarChar).Value = userid;
                                    da1.SelectCommand.Parameters.Add("@incentiveID", SqlDbType.VarChar).Value = IncentiveId;
                                }

                                da1.Fill(dss1);
                                divgm.Visible = false;

                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                osqlconn1.Close();
                            }
                            FillDetailsabc(dss1);
                            if (Request.QueryString[1].ToString() == "91")
                            {
                                if (dss1 != null && dss1.Tables.Count > 0 && dss1.Tables[0].Rows.Count > 0)
                                {
                                    if (dsCAF_Rej != null && dsCAF_Rej.Tables.Count > 0 && dsCAF_Rej.Tables[0].Rows.Count > 0)
                                    {
                                        BindForms(dsCAF_Rej, IncentiveId);
                                    }
                                }
                            }
                            if (Request.QueryString[1].ToString() == "91")
                            {
                                if (odds != null && odds.Tables.Count > 0 && odds.Tables[0].Rows.Count > 0)
                                {
                                    if (dsCAF_Rej != null && dsCAF_Rej.Tables.Count > 0 && dsCAF_Rej.Tables[0].Rows.Count > 0)
                                    {
                                        BindForms(dsCAF_Rej, IncentiveId);
                                    }
                                }
                            }

                        }

                        else
                        {
                            if (!IsPostBack)
                            {

                                ds = Gen.GetIncentiveDeptDetailsCreatedBy(userid);
                                string IncentID = FillDetailsabc(ds);
                                if (Request.QueryString[1].ToString() == "91")
                                    FillDetailsabc(odsRejection);

                                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                {
                                    if (dsCAF != null && dsCAF.Tables.Count > 0 && dsCAF.Tables[0].Rows.Count > 0)
                                    {
                                        BindForms(dsCAF, IncentID);
                                    }
                                }
                            }
                        }
                    }



                }
            }
            else
            {
                // Response.Redirect("~/IpassLogin.aspx");
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            // Response.Redirect("~/IpassLogin.aspx");
        }
    }

    public DataTable FilterDataTableBasedOnIncentiveIds(DataSet ds, string Incids, int index, string SearchText, out int result)
    {
        string table = (index == 0) ? "Table" : (index == 1) ? "Table1" : (index == 2) ? "Table2" : (index == 3) ? "Table3" : "";
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        dt = ds.Tables[table];
        dt1 = ds.Tables[table].Clone();//IncentiveID
        DataRow[] dw = dt.Select("" + SearchText + " in (" + Incids + ")");
        ds.Tables.Remove(table);
        dt1.Rows.Clear();
        foreach (DataRow dr in dw)
        {
            dt1.ImportRow(dr);
        }
        if (dt1.Rows.Count > 0)
        {
            dt2 = dt1;
            result = 1;
        }
        else
        {
            dt2 = dt;
            result = 0;
        }
        return dt2;
    }

    public void BindingGmRecommendedIncentives(DataTable ds)
    {
        try
        {
            if (ds != null && ds.Rows.Count > 0)
            {
                gvinspectionOfficer.DataSource = ds;
                gvinspectionOfficer.DataBind();
                //   gvinspectionOfficer.Columns[11].Visible = false;

                gvinspectionOfficer.Columns[10].Visible = true;

                if (gvinspectionOfficer.Rows.Count < 1)
                {

                    trinspectionname1.Visible = false;
                    //trInspectionReport3.Visible = false;
                    trInspectionReport4.Visible = false;
                }
                else
                {
                    // trInspectionReportNEW.Visible = true;
                }
                int rejectedcount = 0;
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    //TextBox txtinspectiondate = (TextBox)grdDetails.Rows[i].FindControl("txtinspectiondate");
                    DropDownList ddlapprove = (DropDownList)gvinspectionOfficer.Rows[i].FindControl("ddlapprove");
                    if (Session["Role_Code"].ToString() == "GM")// Session["DistrictID"].ToString() == "24" && -- Removed condition as per JD sir enable this option for all districts.
                    {
                        ddlapprove.Items.Add(new ListItem("Rollback to IO", "4"));
                    }
                    ddlapprove.SelectedValue = ds.Rows[i]["GMStatusid"].ToString();
                    TextBox txtIncQueryFnl2 = (TextBox)gvinspectionOfficer.Rows[i].FindControl("txtIncQueryFnl2");
                    Label enterid = (Label)gvinspectionOfficer.Rows[i].FindControl("lblIncentiveID");
                    Label lblMstIncentiveId = (Label)gvinspectionOfficer.Rows[i].FindControl("lblMstIncentiveId");
                    FileUpload FileUploadgminspectionnew = (FileUpload)gvinspectionOfficer.Rows[i].FindControl("FileUploadgminspection");
                    if (ddlapprove.SelectedValue == "1")
                    {
                        txtIncQueryFnl2.Visible = true;
                        // ddlapprove_SelectedIndexChanged(sender, e);
                        txtIncQueryFnl2.Text = ds.Rows[i]["QueryDescription"].ToString();
                        ddlapprove.Enabled = false;
                        Button Button1 = (Button)gvinspectionOfficer.Rows[i].FindControl("Button1");
                        Button Button2 = (Button)gvinspectionOfficer.Rows[i].FindControl("Button2");

                        Button2.Visible = false;
                        Button1.Visible = false;

                        Label lblcois = (Label)gvinspectionOfficer.Rows[i].FindControl("lblcois");
                        lblcois.Visible = true;
                        FileUploadgminspectionnew.Visible = false;
                        lblcois.Text = "Query Submitted";

                        // gvinspectionOfficer.Columns[11].Visible = false;
                        (gvinspectionOfficer.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).ForeColor = System.Drawing.Color.Red;
                        (gvinspectionOfficer.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).Text = "Query Letter";
                        (gvinspectionOfficer.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaQueryRaiseShortFallLetterGMtoApplicantApproval.aspx?incentiveid=" + enterid.Text.Trim() + "&MstIncentiveId=" + lblMstIncentiveId.Text.Trim();
                    }
                    else
                    {
                        txtIncQueryFnl2.Visible = false;
                    }


                    if (ddlapprove.SelectedValue == "2")
                    {
                        ddlapprove.Enabled = false;
                    }
                    if (ddlapprove.SelectedValue == "4")
                    {
                        ddlapprove.Enabled = false;
                        Button Button1 = (Button)gvinspectionOfficer.Rows[i].FindControl("Button1");
                        Button Button2 = (Button)gvinspectionOfficer.Rows[i].FindControl("Button2");
                        ddlapprove.Enabled = false;
                        Button1.Enabled = true;
                        Button1.Text = "Rollback to IO";
                        Button1.Visible = true;
                        Button2.Visible = false;
                    }
                    if (ddlapprove.SelectedValue == "0")
                    {
                        (gvinspectionOfficer.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).Visible = false;
                    }
                    if (ds.Rows[i]["GMApprovalSentTo"].ToString() != "" && ds.Rows[i]["GMStatusid"].ToString() == "2")
                    {

                        if (lblMstIncentiveId.Text == "6")
                        {
                            (gvinspectionOfficer.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaInvestmentSubsidy.aspx?EntrpId=" + enterid.Text.Trim();
                        }
                        if (lblMstIncentiveId.Text == "1")
                        {
                            (gvinspectionOfficer.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaPavalavaddi.aspx?incentiveid=" + enterid.Text.Trim();
                        }
                        if (lblMstIncentiveId.Text == "3")
                        {
                            (gvinspectionOfficer.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaPowerTariff.aspx?incentiveid=" + enterid.Text.Trim();
                        }
                        if (lblMstIncentiveId.Text == "5")
                        {
                            (gvinspectionOfficer.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaSalesTax.aspx?incentiveid=" + enterid.Text.Trim();
                        }

                        (gvinspectionOfficer.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).ForeColor = System.Drawing.Color.Green;
                        (gvinspectionOfficer.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).Text = "Recommendation Letter";

                        Button btnsubmit = (Button)gvinspectionOfficer.Rows[i].FindControl("Button1");
                        btnsubmit.Visible = false;
                        Button btnButton2 = (Button)gvinspectionOfficer.Rows[i].FindControl("Button2");
                        btnButton2.Visible = false;
                        Label lblcois = (Label)gvinspectionOfficer.Rows[i].FindControl("lblcois");
                        FileUpload FileUploadgminspection = (FileUpload)gvinspectionOfficer.Rows[i].FindControl("FileUploadgminspection");
                        Button btnuploadgmletter = (Button)gvinspectionOfficer.Rows[i].FindControl("btngmrecommendeddocument");

                        lblcois.Visible = true;
                        if (ds.Rows[i]["DIPCFlag"].ToString().Trim() == "Y")
                        {
                            lblcois.Text = "Sent to DIPC";
                            ddlapplicationto.SelectedValue = "2";
                            //object sender;
                            EventArgs e = new EventArgs();
                            ddlapplicationto_SelectedIndexChanged(this, e);
                            ddlapplicationto.Enabled = false;
                            btnButton2.Visible = false;
                            FileUploadgminspection.Visible = false;
                            btnuploadgmletter.Visible = false;
                            (gvinspectionOfficer.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).Enabled = false;
                            (gvinspectionOfficer.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).Visible = false;
                        }
                        else
                        {
                            lblcois.Text = "Sent to COI";
                            ddlapplicationto.SelectedValue = "1";
                            ddlapplicationto.Enabled = false;
                            FileUploadgminspection.Visible = false;
                            btnuploadgmletter.Visible = false;
                            (gvinspectionOfficer.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).Enabled = true;
                            (gvinspectionOfficer.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).Visible = true;
                        }
                        // gvinspectionOfficer.Columns[11].Visible = true;
                    }
                    else if (ds.Rows[i]["GMStatus"].ToString() == "Rejected" && ds.Rows[i]["GMStatusid"].ToString() == "3")
                    {
                        rejectedcount = rejectedcount + 1;
                        Label lblcois = (Label)gvinspectionOfficer.Rows[i].FindControl("lblcois");
                        FileUpload FileUploadgminspection = (FileUpload)gvinspectionOfficer.Rows[i].FindControl("FileUploadgminspection");
                        lblcois.Visible = true;
                        lblcois.Text = "Rejected";
                        ddlapprove.Enabled = false;
                        ddlapplicationto.SelectedValue = "0";
                        ddlapplicationto.Enabled = false;
                        FileUploadgminspection.Visible = false;
                        EventArgs e = new EventArgs();
                        ddlapplicationto_SelectedIndexChanged(this, e);  // shankartest


                        txtIncQueryFnl2.Visible = true;
                        txtIncQueryFnl2.Text = ds.Rows[i]["GMRemarks"].ToString();
                        Button Button1 = (Button)gvinspectionOfficer.Rows[i].FindControl("Button1");
                        Button Button2 = (Button)gvinspectionOfficer.Rows[i].FindControl("Button2");
                        Button2.Visible = false;
                        Button1.Visible = false;
                        (gvinspectionOfficer.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).Visible = false;
                        if (ds.Rows.Count == rejectedcount)
                        {
                            gvinspectionOfficer.Columns[12].Visible = false;
                            gvinspectionOfficer.Columns[10].Visible = false;
                            gvinspectionOfficer.Columns[9].Visible = false;
                        }
                    }

                    //if (ds.Rows[i]["DIPCFlag"].ToString() == "Y")
                    //{
                    //    CheckBoxList1.Items[0].Text = "Sanction Amount";
                    //    CheckBoxList1.Items[1].Text = "Reject";
                    //    Label6.Text = "Sanctioned Amount";
                    //    // trpostsvc.Visible = false;
                    //    tradditional.Visible = true;
                    //    Button3.Text = "Submit Application";
                    //    trRemarks1.Visible = true;
                    //    DataSet dsince = new DataSet();
                    //    dsince = Gen.GetIncetiveDropDownList(ViewState["IncentveID"].ToString(), "DIPC", "DIPC");
                    //    if (dsince != null && dsince.Tables.Count > 0 && dsince.Tables[0].Rows.Count > 0)
                    //    {
                    //        ddlstaire.DataSource = dsince.Tables[0];
                    //        ddlstaire.DataValueField = "MstIncentiveId";
                    //        ddlstaire.DataTextField = "IncentiveName";
                    //        ddlstaire.DataBind();
                    //    }

                    //    System.Web.UI.WebControls.ListItem LI = new System.Web.UI.WebControls.ListItem("Select", "0");
                    //    ddlstaire.Items.Insert(0, LI);

                    //    tdslcno.InnerHtml = "DLC No";
                    //    tdslcndate.InnerHtml = "DLC Date";

                    //    ViewState["DIPCFlag"] = "Y";
                    //}
                }
            }
            if (gvinspectionOfficer.Rows.Count < 1)
            {
                trinspectionname1.Visible = false;
                trInspectionReport4.Visible = false;
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    public void Officers(string DistID)
    {
        try
        {
            DataSet dsnew = new DataSet();

            dsnew = Gen.GetDepartmentINcentiveNew(DistID);//distid    DistID
            ddlDeptname.DataSource = dsnew.Tables[0];
            ddlDeptname.DataTextField = "Dept_Name";
            ddlDeptname.DataValueField = "Dept_Id";
            ddlDeptname.DataBind();
            ddlDeptname.Items.Insert(0, "--Select--");
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{

        //    DropDownList ddlDeptname = (e.Row.FindControl("ddlDeptname") as DropDownList);

        //    DataSet dsnew = new DataSet();

        //    dsnew = Gen.GetDepartmentINcentiveNew(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistID")).Trim());//distid    DistID
        //    ddlDeptname.DataSource = dsnew.Tables[0];
        //    ddlDeptname.DataTextField = "Dept_Name";
        //    ddlDeptname.DataValueField = "Dept_Id";
        //    ddlDeptname.DataBind();
        //    ddlDeptname.Items.Insert(0, "--Select--");
        //    // ddlDeptname.Items.Insert(1, "Raise Query");

        //    //Label enterid = (e.Row.FindControl("lblIncentiveID") as Label);
        //    //Label MstIncentiveId = (e.Row.FindControl("lblMstIncentiveId") as Label);
        //    //(e.Row.FindControl("anchortaglink") as HyperLink).NavigateUrl = "InspectionRprt.aspx?EntrpId=" + enterid.Text.Trim() + "&Inctypeid=" + MstIncentiveId.Text;
        //}
    }
    protected void ddlDeptname_SelectedIndexChanged1(object sender, EventArgs e)
    {
        try
        {

            DropDownList ddlDeptnameFnl = (DropDownList)sender;

            GridViewRow row = (GridViewRow)ddlDeptnameFnl.NamingContainer;
            TextBox txtIncQuery = (TextBox)row.FindControl("txtIncQueryFnl");
            DropDownList ddlDeptname = (DropDownList)row.FindControl("ddlDeptname");

            if (ddlDeptnameFnl.SelectedValue == "Raise Query")
            {
                txtIncQuery.Visible = true;
                ddlDeptname.Visible = false;
                txtIncQuery.Focus();
            }
            else if (ddlDeptnameFnl.SelectedValue == "1")
            {
                txtIncQuery.Visible = false;
                ddlDeptname.Visible = true;
                ddlDeptnameFnl.Focus();
            }
            else
            {
                txtIncQuery.Visible = false;
                ddlDeptname.Visible = false;

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        try
        {
            Button ddlDeptnameFnl = (Button)sender;

            GridViewRow gvrow = (GridViewRow)ddlDeptnameFnl.NamingContainer;
            Button btnSave = (Button)gvrow.FindControl("BtnSave1");
            string intApplicationidnew = "";
            string StatusApp = Request.QueryString[1].ToString();
            int returnValuenew = 0;
            //foreach (GridViewRow gvrow in grdDetails.Rows)
            //{
            string intApplicationid, Deptname, Modified_by, EMiUdyogAadhar, SentFrom, Status, MstIncentiveId, txtIncQuery, txtinspectiondate, Deptname1new;

            intApplicationid = ((Label)gvrow.FindControl("lblIncentiveID")).Text.ToString();
            intApplicationidnew = intApplicationid;
            MstIncentiveId = ((Label)gvrow.FindControl("lblMstIncentiveId")).Text.ToString();
            Deptname = ((DropDownList)gvrow.FindControl("ddlDeptname")).SelectedValue.ToString();
            Deptname1new = ((DropDownList)gvrow.FindControl("ddlassignQuery")).SelectedValue.ToString();
            txtIncQuery = ((TextBox)gvrow.FindControl("txtIncQueryFnl")).Text.ToString();
            Label lblmsgQuery = ((Label)gvrow.FindControl("lblmsgQuery"));
            // txtinspectiondate = ((TextBox)gvrow.FindControl("txtinspectiondate")).Text.ToString();
            EMiUdyogAadhar = txtudyogAadharNo.Text;
            Modified_by = Session["uid"].ToString();
            SentFrom = Session["User_Code"].ToString();
            Status = "3";
            if (ViewState["DisignationLoad"].ToString().Trim() == "GM")
            {
                if (txtIncQuery != "" && Deptname1new == "Raise Query")
                {
                    int incRtrVal = Gen.insertInctveQueryResponsedataNew(intApplicationid, txtIncQuery, Session["User_Code"].ToString(), MstIncentiveId, getclientIP());

                    // added on 27.07.2017                   
                    for (int i = 0; i < gvquerygm.Rows.Count; i++)
                    {
                        string IncentiveName = "";
                        IncentiveName = gvquerygm.Rows[i].Cells[1].Text;
                        SendSmsEmail(txtIncQuery, IncentiveName);
                    }
                }
                else
                {
                    // lblIncentiveID
                    //int returnValue = Gen.UpdateInspectorNameNewIncTypeNew(intApplicationid, Deptname, Modified_by, EMiUdyogAadhar, SentFrom, Status, MstIncentiveId, getclientIP());
                    int returnValue = Gen.UpdateInspectorNameNewIncTypeNew(intApplicationid, Deptname, Modified_by, EMiUdyogAadhar, SentFrom, Status, MstIncentiveId, getclientIP(), "");
                    returnValuenew = returnValue;
                }
            }
            lblmsgQuery.Text = "Inspection Assigned";

            btnSave.Visible = false;
            //lblmsg.Text = "<font color='green'>File Assigned to inspecting officer Successfully..!</font>";
            //success.Visible = true;
            //Failure.Visible = false;
            //  Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('File Assigned to inspecting officer Successfully');", true);

            string message = "alert('File Assigned to inspecting officer Successfully')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            //  }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void btnsubmitqueryins_Click(object sender, EventArgs e)
    {
        try
        {
            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            string lblMstIncentiveId = ((Label)gvinspectionReport.Rows[indexing].FindControl("lblMstIncentiveId")).Text;
            string lblIncentiveID = ((Label)gvinspectionReport.Rows[indexing].FindControl("lblIncentiveID")).Text;
            string txtIncQueryFnl2 = ((TextBox)gvinspectionReport.Rows[indexing].FindControl("txtIncQueryFnl2ins")).Text;
            DropDownList ddlapprove = (DropDownList)gvinspectionReport.Rows[indexing].FindControl("ddlinspector");
            HyperLink anchortagIPOCertificate = (HyperLink)gvinspectionReport.Rows[indexing].FindControl("anchortagIPOCertificate");
            HyperLink anchortaglinkView = (HyperLink)gvinspectionReport.Rows[indexing].FindControl("anchortaglinkView");
            anchortagIPOCertificate.ForeColor = System.Drawing.Color.Red;
            anchortagIPOCertificate.Visible = true;
            anchortaglinkView.Visible = false;

            int incRtrVal = Gen.InsertIOqueryDtls(lblIncentiveID, txtIncQueryFnl2, Session["uid"].ToString(), lblMstIncentiveId, getclientIP(), "");
            anchortagIPOCertificate.NavigateUrl = "QueryRaiseShortFallLetterinspectortoApplicantApproval.aspx?incentiveid=" + lblIncentiveID + "&MstIncentiveId=" + lblMstIncentiveId;
            try
            {
                string IncentiveName = gvinspectionReport.Rows[indexing].Cells[1].Text;
                // SendSmsEmail(txtIncQueryFnl2, IncentiveName); // commented on 10.01.2018 
            }
            catch (Exception ex)
            {
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
            string message = "alert('Query Submitted Successfully')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void ddlinspector_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlDeptnameFnl2 = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlDeptnameFnl2.NamingContainer;
            TextBox txtIncQuery = (TextBox)row.FindControl("txtIncQueryFnl2ins");
            Button Button1 = (Button)row.FindControl("btnsubmitqueryins");
            if (ddlDeptnameFnl2.SelectedValue == "2")
            {
                (row.FindControl("anchortaglink") as HyperLink).Visible = false;
                txtIncQuery.Visible = true;
                Button1.Visible = true;
                txtIncQuery.Focus();
            }
            else
            {
                (row.FindControl("anchortaglink") as HyperLink).Visible = true;
                txtIncQuery.Visible = false;
                Button1.Visible = false;
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
        //btnsubmitqueryins_Click
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;

            // added by chh           
            string txtGMRecommendedRemarks = "";
            if (Button1.Text == "Send to COI" || gvinspectionOfficer.Columns[10].Visible == true)
            {
                if (gvinspectionOfficer.Columns[10].Visible == true)
                {
                    txtGMRecommendedRemarks = ((TextBox)gvinspectionOfficer.Rows[indexing].FindControl("txtGMRecommendedRemarks")).Text;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('GM Recommended Remarks cannot be empty');", true);
                    return;
                }
            }

            string lblMstIncentiveId = ((Label)gvinspectionOfficer.Rows[indexing].FindControl("lblMstIncentiveId")).Text;
            string lblIncentiveID = ((Label)gvinspectionOfficer.Rows[indexing].FindControl("lblIncentiveID")).Text;
            string txtIncQueryFnl2 = ((TextBox)gvinspectionOfficer.Rows[indexing].FindControl("txtIncQueryFnl2")).Text;
            string txtrecomandedamount = ((TextBox)gvinspectionOfficer.Rows[indexing].FindControl("txtrecomandedamount")).Text;
            DropDownList ddlapprove = (DropDownList)gvinspectionOfficer.Rows[indexing].FindControl("ddlapprove");
            if (ddlapprove.SelectedValue == "2" || ddlapprove.SelectedValue == "3")
            {
                if (rdbSector.SelectedIndex == 1)
                {
                    int statusapp = Gen.GMCertificateInsertUploadNew(lblIncentiveID, Session["uid"].ToString(), "", ddlapprove.SelectedValue, txtIncQueryFnl2, lblMstIncentiveId, txtrecomandedamount, getclientIP(), txtGMRecommendedRemarks, txtLoanAgreement.Text.ToString(), "", rdbCaste.SelectedValue.ToString(), rdbGender.SelectedValue.ToString(), rdbCategory.SelectedValue.ToString(), rdbEnterprise.SelectedValue.ToString(), rdbSector.SelectedValue.ToString(), "", "", Convert.ToString(rbtISINSLCORNOT.SelectedValue));
                }
                else if (rdbSector.SelectedIndex == 0)
                {
                    int statusapp = Gen.GMCertificateInsertUploadNew(lblIncentiveID, Session["uid"].ToString(), "", ddlapprove.SelectedValue, txtIncQueryFnl2, lblMstIncentiveId, txtrecomandedamount, getclientIP(), txtGMRecommendedRemarks, txtLoanAgreement.Text.ToString(), "", rdbCaste.SelectedValue.ToString(), rdbGender.SelectedValue.ToString(), rdbCategory.SelectedValue.ToString(), rdbEnterprise.SelectedValue.ToString(), rdbSector.SelectedValue.ToString(), rdbServiceType.SelectedValue.ToString(), rdbTransportNonTrans.SelectedValue.ToString(), Convert.ToString(rbtISINSLCORNOT.SelectedValue));

                }

            }
            else if (ddlapprove.SelectedValue == "1")
            {
                //int incRtrVal = Gen.insertInctveQueryResponsedataNewatApproval(lblIncentiveID, txtIncQueryFnl2, Session["uid"].ToString(), lblMstIncentiveId, getclientIP(), rdbCaste.SelectedValue.ToString(), rdbGender.SelectedValue.ToString(), rdbCategory.SelectedValue.ToString(), rdbEnterprise.SelectedValue.ToString(), rdbSector.SelectedValue.ToString());
                int incRtrVal = Gen.insertInctveQueryResponsedataNewatApproval(lblIncentiveID, txtIncQueryFnl2, Session["uid"].ToString(), lblMstIncentiveId, getclientIP(), rdbCaste.SelectedValue.ToString(), rdbGender.SelectedValue.ToString(), rdbCategory.SelectedValue.ToString(), rdbEnterprise.SelectedValue.ToString(), rdbSector.SelectedValue.ToString(), Convert.ToString(rbtISINSLCORNOT.SelectedValue));
                try
                {
                    string IncentiveName = gvinspectionOfficer.Rows[indexing].Cells[1].Text;
                    SendSmsEmail(txtIncQueryFnl2, IncentiveName);
                }
                catch (Exception ex)
                {
                    LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
                }
            }

            if (ddlapprove.SelectedValue == "4")
            {

                //if (txtIncQueryFnl2 != "")
                //{

                //    int statusapp = Gen.GMCertificateInsertUploadNew(lblIncentiveID, Session["uid"].ToString(), "", ddlapprove.SelectedValue, txtIncQueryFnl2, lblMstIncentiveId, "0", getclientIP(), "Rollbacked to IO", "", "", "", "", "", "", "", "", "");
                //}
                //else if (txtIncQueryFnl2 == "")
                //{
                //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('GM Rollback Remarks cannot be empty');", true);
                //    return;

                //}
                if (txtIncQueryFnl2.Trim() == "" || txtIncQueryFnl2.Trim() == null || string.IsNullOrWhiteSpace(txtIncQueryFnl2))

                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('GM Rollback Remarks cannot be empty');", true);
                    return;
                }
                else
                {

                    int statusapp = Gen.GMCertificateInsertUploadNew(lblIncentiveID, Session["uid"].ToString(), "", ddlapprove.SelectedValue, txtIncQueryFnl2, lblMstIncentiveId, "0", getclientIP(), "Rollbacked to IO", "", "", "", "", "", "", "", "", "", Convert.ToString(rbtISINSLCORNOT.SelectedValue));
                }


            }

            Button btnsubmit = (Button)gvinspectionOfficer.Rows[indexing].FindControl("Button1");
            btnsubmit.Visible = false;
            Button btnButton2 = (Button)gvinspectionOfficer.Rows[indexing].FindControl("Button2");
            btnButton2.Visible = false;
            Label lblcois = (Label)gvinspectionOfficer.Rows[indexing].FindControl("lblcois");
            lblcois.Visible = true;
            if (ddlapprove.SelectedValue != "4")
            {
                lblcois.Text = "Sent to COI";
            }
            else if (ddlapprove.SelectedValue == "4")
            {
                lblcois.Text = "Rollbacked to IO";
            }

            // added newly on 20.07.2017
            Button ddlDeptnameFnl2 = (Button)sender;
            GridViewRow row = (GridViewRow)ddlDeptnameFnl2.NamingContainer;
            if (ddlapprove.SelectedValue != "4")
            {
                (row.FindControl("anchortagGMCertificate") as HyperLink).ForeColor = System.Drawing.Color.Green;
                (row.FindControl("anchortagGMCertificate") as HyperLink).Text = "Recommendation Letter";
                (row.FindControl("anchortagGMCertificate") as HyperLink).Visible = true;
            }
            if (btnsubmit.Text == "Submit Query")  // ppppp
            {
                lblcois.Text = "Query Raised";
                (row.FindControl("anchortagGMCertificate") as HyperLink).ForeColor = System.Drawing.Color.Red;
                (row.FindControl("anchortagGMCertificate") as HyperLink).Text = "Query Letter";
                (row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaQueryRaiseShortFallLetterGMtoApplicantApproval.aspx?incentiveid=" + lblIncentiveID + "&MstIncentiveId=" + lblMstIncentiveId;
            }
            else if (btnsubmit.Text == "Reject")  // ppppp
            {
                lblcois.Text = "Rejected";
            }

            //-----------------------------------------------------------------------------------attachmentupoad-------------------------------------------------------
            //try
            //{
            //    FileUpload FileUpload1 = (FileUpload)gvinspectionOfficer.Rows[indexing].FindControl("FileUploadgminspection");

            //    string newPath = "";

            //    General t1 = new General();
            //    if (FileUpload1.HasFile)
            //    {
            //        string incentiveid = lblIncentiveID;

            //        if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            //        {
            //            string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
            //            try
            //            {
            //                string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
            //                int i = fileType.Length;
            //                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
            //                {
            //                    //string serverpath = Server.MapPath("~\\AttachmentforGMIcentive\\" + incentiveid.ToString() + "\\GMInspectionreport" + lblMstIncentiveId);  // incentiveid2
            //                    string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + "AttachmentforGMIcentive\\" + incentiveid.ToString() + "\\GMInspectionreport" + lblMstIncentiveId;
            //                    if (!Directory.Exists(serverpath))
            //                        Directory.CreateDirectory(serverpath);

            //                    FileUpload1.PostedFile.SaveAs(serverpath + "\\" + sFileName);
            //                    string CrtdUser = Session["uid"].ToString();

            //                    string Path = serverpath;
            //                    string FileName = sFileName;
            //                    ViewState["AttachmentName"] = sFileName;
            //                    ViewState["pathAttachment"] = serverpath;

            //                    t1.InsertIncentiveAttachmentQueryResponse(incentiveid, incentiveid + lblMstIncentiveId, sFileName, serverpath, CrtdUser, lblMstIncentiveId, getclientIP());
            //                }
            //                else
            //                {

            //                }
            //            }
            //            catch (Exception ex)//in case of an error
            //            {
            //                DeleteFile(newPath + "\\" + sFileName);
            //                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            //}
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void btngmrecommendeddocument_Click(object sender, EventArgs e)
    {
        try
        {

            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;

            // added by chh           


            string lblMstIncentiveId = ((Label)gvinspectionOfficer.Rows[indexing].FindControl("lblMstIncentiveId")).Text;
            string lblIncentiveID = ((Label)gvinspectionOfficer.Rows[indexing].FindControl("lblIncentiveID")).Text;
            FileUpload FileUpload1 = (FileUpload)gvinspectionOfficer.Rows[indexing].FindControl("FileUploadgminspection");

            Label LBLGMATTACHMENT = ((Label)gvinspectionOfficer.Rows[indexing].FindControl("LBLGMATTACHMENT"));


            string newPath = "";

            General t1 = new General();
            if (FileUpload1.HasFile)
            {
                string incentiveid = lblIncentiveID;

                if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //string serverpath = Server.MapPath("~\\AttachmentforGMIcentive\\" + incentiveid.ToString() + "\\GMInspectionreport" + lblMstIncentiveId);  // incentiveid2
                            string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + "AttachmentforGMIcentive\\" + incentiveid.ToString() + "\\GMInspectionreport" + lblMstIncentiveId;
                            if (!Directory.Exists(serverpath))
                                Directory.CreateDirectory(serverpath);

                            FileUpload1.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                            string CrtdUser = Session["uid"].ToString();

                            string Path = serverpath;
                            string FileName = sFileName;
                            ViewState["AttachmentName"] = sFileName;
                            ViewState["pathAttachment"] = serverpath;

                            t1.InsertIncentiveAttachmentQueryResponse(incentiveid, incentiveid + lblMstIncentiveId, sFileName, serverpath, CrtdUser, lblMstIncentiveId, getclientIP());
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            LBLGMATTACHMENT.Visible = true;
                            LBLGMATTACHMENT.Text = FileUpload1.FileName;



                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }
                    }
                    catch (Exception ex)//in case of an error
                    {
                        DeleteFile(newPath + "\\" + sFileName);
                        LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            string lblMstIncentiveId = ((Label)gvinspectionOfficer.Rows[indexing].FindControl("lblMstIncentiveId")).Text;
            string lblIncentiveID = ((Label)gvinspectionOfficer.Rows[indexing].FindControl("lblIncentiveID")).Text;
            DropDownList ddlapprove = (DropDownList)gvinspectionOfficer.Rows[indexing].FindControl("ddlapprove");
            string txtrecomandedamount = ((TextBox)gvinspectionOfficer.Rows[indexing].FindControl("txtrecomandedamount")).Text;
            if (ddlapprove.SelectedValue == "2" || ddlapprove.SelectedValue == "3")
            {
                int statusapp = Gen.GMCertificateInsertUploadNewDIPC(lblIncentiveID, Session["uid"].ToString(), Session["uid"].ToString(), ddlapprove.SelectedValue, ddlapprove.SelectedValue, 
                    lblMstIncentiveId, txtrecomandedamount, getclientIP(), "", rdbCaste.SelectedValue.ToString(), rdbGender.SelectedValue.ToString(), rdbCategory.SelectedValue.ToString(), rdbEnterprise.SelectedValue.ToString(), rdbSector.SelectedValue.ToString(),
                        rdbServiceType.SelectedValue.ToString(), rdbTransportNonTrans.SelectedValue.ToString(), Convert.ToString(rbtISINSLCORNOT.SelectedValue));
            }
            //else if (ddlapprove.SelectedValue == "1")
            //{
            //    int statusapp = Gen.GMCertificateInsertUploadNew(lblIncentiveID, Session["uid"].ToString(), "", ddlapprove.SelectedValue, ddlapprove.SelectedValue, lblMstIncentiveId, txtrecomandedamount);
            //}
            Button btnsubmit = (Button)gvinspectionOfficer.Rows[indexing].FindControl("Button1");
            btnsubmit.Visible = false;
            Button btnButton2 = (Button)gvinspectionOfficer.Rows[indexing].FindControl("Button2");
            btnButton2.Visible = false;
            Label lblcois = (Label)gvinspectionOfficer.Rows[indexing].FindControl("lblcois");
            lblcois.Visible = true;
            lblcois.Text = "Sent to DIPC";

            Button ddlDeptnameFnl2 = (Button)sender;
            GridViewRow row = (GridViewRow)ddlDeptnameFnl2.NamingContainer;
            (row.FindControl("anchortagGMCertificate") as HyperLink).ForeColor = System.Drawing.Color.Green;
            (row.FindControl("anchortagGMCertificate") as HyperLink).Text = "Recommendation Letter";
            (row.FindControl("anchortagGMCertificate") as HyperLink).Visible = true;

            //-----------------------------------------------------------------------------------attachmentupoad-------------------------------------------------------
            //try
            //{
            //    FileUpload FileUpload1 = (FileUpload)gvinspectionOfficer.Rows[indexing].FindControl("FileUploadgminspection");

            //    string newPath = "";

            //    General t1 = new General();
            //    if (FileUpload1.HasFile)
            //    {

            //        string incentiveid = lblIncentiveID;

            //        if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            //        {
            //            string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
            //            try
            //            {
            //                string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
            //                int i = fileType.Length;
            //                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
            //                {
            //                    string serverpath = Server.MapPath("~\\AttachmentforGMIcentive\\" + incentiveid.ToString() + "\\GMInspectionreport" + lblMstIncentiveId);  // incentiveid2
            //                    if (!Directory.Exists(serverpath))
            //                        Directory.CreateDirectory(serverpath);

            //                    FileUpload1.PostedFile.SaveAs(serverpath + "\\" + sFileName);
            //                    string CrtdUser = Session["uid"].ToString();

            //                    string Path = serverpath;
            //                    string FileName = sFileName;
            //                    ViewState["AttachmentName"] = sFileName;
            //                    ViewState["pathAttachment"] = serverpath;

            //                    t1.InsertIncentiveAttachmentQueryResponse(incentiveid, incentiveid + lblMstIncentiveId, sFileName, serverpath, CrtdUser, lblMstIncentiveId, getclientIP());
            //                }
            //                else
            //                {

            //                }
            //            }
            //            catch (Exception ex)//in case of an error
            //            {
            //                DeleteFile(newPath + "\\" + sFileName);
            //                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //    lblmsg0.Text = ex.Message;
            //    Failure.Visible = true;
            //    LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            //}
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }


    protected void ddlapprove_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlDeptnameFnl2 = (DropDownList)sender;

            GridViewRow row = (GridViewRow)ddlDeptnameFnl2.NamingContainer;
            TextBox txtIncQuery = (TextBox)row.FindControl("txtIncQueryFnl2");
            Label enterid = (Label)row.FindControl("lblIncentiveID");
            Label lblMstIncentiveId = (Label)row.FindControl("lblMstIncentiveId");
            TextBox txtrecomandedamount = (TextBox)row.FindControl("txtrecomandedamount");

            Button Button1 = (Button)row.FindControl("Button1");
            Button Button2 = (Button)row.FindControl("Button2");
            Button Button3otp = (Button)row.FindControl("btnotp");
            decimal n;

            //var stringNumber = "123";
            decimal numericValue;
            bool isNumber = false;

            if (ddlDeptnameFnl2.SelectedValue != "")
            {
                if (ddlapplicationto.SelectedValue == "0")
                {
                    ddlDeptnameFnl2.SelectedValue = "0";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please select Forward Application to');", true);
                    return;
                    //lblmsg0.Text = "Please select Forward Application to";
                    //Failure.Visible = true;
                    //return;
                    //LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
                }
            }

            if (ddlDeptnameFnl2.SelectedValue == "1")
            {
                txtIncQuery.Visible = true;
                Button1.Visible = true;
                txtIncQuery.Focus();
                Button1.Text = "Submit Query";
                Button1.Enabled = true;
                Button2.Visible = false;
                txtrecomandedamount.Enabled = false;
                //txtGMRecommendedRemarks.Enabled = false;
                gvinspectionOfficer.Columns[10].Visible = false;
                //gvinspectionOfficer.Columns[11].Visible = false;
                (row.FindControl("anchortagGMCertificate") as HyperLink).ForeColor = System.Drawing.Color.Red;
                (row.FindControl("anchortagGMCertificate") as HyperLink).Text = "Query Letter";
                (row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaQueryRaiseShortFallLetterGMtoApplicantApproval.aspx?incentiveid=" + enterid.Text.Trim() + "&MstIncentiveId=" + lblMstIncentiveId.Text.Trim();
            }
            else if (ddlDeptnameFnl2.SelectedValue == "3")
            {
                txtIncQuery.Visible = true;
                Button1.Visible = true;
                txtIncQuery.Focus();
                Button1.Text = "Reject";
                Button1.Enabled = true;
                Button2.Visible = false;
                txtrecomandedamount.Enabled = false;
                gvinspectionOfficer.Columns[10].Visible = false;
            }
            else if (ddlDeptnameFnl2.SelectedValue == "4")
            {
                //txtIncQuery.Visible = true;
                Button1.Visible = true;
                txtIncQuery.Visible = true;
                txtIncQuery.Enabled = true;
                Button1.Text = "Rollback to IO";
                Button1.Enabled = true;
                Button2.Visible = false;
                txtrecomandedamount.Enabled = false;
                gvinspectionOfficer.Columns[10].Visible = false;
            }
            else
            {
                txtrecomandedamount.Enabled = true;
                gvinspectionOfficer.Columns[10].Visible = true;
                txtIncQuery.Visible = false;
                ddlDeptnameFnl2.Focus();

                // added on 11.10.2017
                if (ddlapplicationto.SelectedValue == "1")
                {
                    //Button1.Visible = true;
                    //Button2.Visible = false;
                    //Button3otp.Visible = true;
                    isNumber = decimal.TryParse(txtrecomandedamount.Text, out numericValue);

                    //bool isNumeric = decimal.TryParse(txtrecomandedamount.Text, out n);
                    if (isNumber == true && txtrecomandedamount.Text != "")
                    {

                        Button3otp.Visible = true;
                        Button1.Visible = true;
                        Button2.Visible = false;
                    }
                    else if (txtrecomandedamount.Text != "" && isNumber == false)
                    {
                        string message1 = "alert('Please enter only decimal values for recommended amount!')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message1, true);
                        txtrecomandedamount.Text = "";
                        txtrecomandedamount.Focus();
                        return;
                    }
                }
                else if (isNumber == true && ddlapplicationto.SelectedValue == "2")
                {
                    Button2.Visible = true;
                    Button1.Visible = false;
                    // troptpbutton.Visible = true;
                    Button3otp.Visible = false;
                }


                if (isNumber == true && Button1.Visible == true)
                {
                    Button1.Text = "Send to COI";
                    Button1.Enabled = false;
                }
                //else
                //{
                //    Button2.Visible = true;
                //}

                // 

                if (ddlDeptnameFnl2.SelectedValue == "2")
                {
                    //  gvinspectionOfficer.Columns[11].Visible = true;
                }
                else
                {
                    //gvinspectionOfficer.Columns[11].Visible = false;
                }
                if (lblMstIncentiveId.Text == "6")
                {
                    (row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaInvestmentSubsidy.aspx?EntrpId=" + enterid.Text.Trim();
                }
                if (lblMstIncentiveId.Text == "1")
                {
                    (row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaPavalavaddi.aspx?incentiveid=" + enterid.Text.Trim();
                }
                if (lblMstIncentiveId.Text == "3")
                {
                    (row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaPowerTariff.aspx?incentiveid=" + enterid.Text.Trim();
                }
                if (lblMstIncentiveId.Text == "5")
                {
                    (row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaSalesTax.aspx?incentiveid=" + enterid.Text.Trim();
                }

                (row.FindControl("anchortagGMCertificate") as HyperLink).ForeColor = System.Drawing.Color.Green;
                (row.FindControl("anchortagGMCertificate") as HyperLink).Text = "Recommendation Letter";
            }
            ScriptManager.GetCurrent(this).RegisterPostBackControl(Button1);
            ScriptManager.GetCurrent(this).RegisterPostBackControl(Button2);
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void BtnAddremarks_Click(object sender, EventArgs e)
    {
        string Role_Code = Session["Role_Code"].ToString().Trim().TrimStart();
        gvremarks.Visible = true;
        try
        {

            //modified by chinna
            string message = "";
            if (CheckBoxList1.SelectedValue == "")
            {
                message = "Please Select Status";
            }
            if (ddlstaire.SelectedValue == "0")
            {
                message = "Please Select Type of Incentive";
            }
            if (ddlstaire.SelectedValue == "0" && CheckBoxList1.SelectedValue == "")
            {
                message = "Please Select Type of Incentive \\nPlease Select Status";
            }
            if (CheckBoxList1.SelectedValue == "1")
            {
                if (ddlstaire.SelectedValue == "0" && txtRecommendedAmount.Text.Trim() == "")
                {
                    message = "Please Select Type of Incentive \\nPlease Enter Recommended Amount";
                }
                else if (txtRecommendedAmount.Text.Trim() == "")
                {
                    message = "Please Enter Recommended Amount";
                }
            }
            if (CheckBoxList1.SelectedValue == "2")
            {
                if (ddlstaire.SelectedValue == "0" && txtincentiveremarks.Text.Trim() == "")
                {
                    message = "Please Select Type of Incentive \\nPlease Enter Query";
                }
                else if (txtincentiveremarks.Text.Trim() == "")
                {
                    message = "Please Enter Query";
                }
            }
            if (CheckBoxList1.SelectedValue == "3")
            {
                if (ddlstaire.SelectedValue == "0" && txtRejectreason.Text.Trim() == "")
                {
                    message = "Please Select Type of Incentive \\nPlease Enter Reject Reason";
                }
                else if (txtRejectreason.Text.Trim() == "")
                {
                    message = "Please Enter Reject Reason";
                }
            }

            // added on 11.01.2018 by chh
            if (CheckBoxList1.SelectedValue == "4")
            {
                if (ddlstaire.SelectedValue == "0" && txtRejectreason.Text.Trim() == "")
                {
                    message = "Please Select Type of Incentive \\nPlease Enter Reject Reason";
                }
                else if (txtRejectreason.Text.Trim() == "")
                {
                    message = "Please Enter Application Hold Reason";
                }
            }
            if (CheckBoxList1.SelectedValue == "5")
            {
                if (Role_Code == "ADDL")
                {
                    if (trsscinspectiondate.Visible == true)
                    {
                        if (txtsscinspectiondate.Text.Trim() == "")
                        {
                            message = "Please Select SSC Inspection Date";
                        }

                    }
                }
            }
            if (CheckBoxList1.SelectedValue == "8")
            {
                if (Role_Code == "ADDL")
                {
                    if (trsscreport.Visible == true)
                    {
                        if (txtincentiveremarks.Text.Trim() == "")
                        {
                            message = "Please Enter SSC Completion Remarks";
                        }
                        if (lblFileNamesscreport.Text.Trim() == "")
                        {
                            message = "Please Upload SSC Inspection Report";
                        }
                    }
                }
            }
            if (message != "")
            {
                string message1 = "alert('" + message + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message1, true);
                return;
            }
            string incentiveremarks = "";
            if (CheckBoxList1.SelectedValue == "1")
            {
                incentiveremarks = txtRecommendedAmount.Text;
            }
            else if (CheckBoxList1.SelectedValue == "2" || CheckBoxList1.SelectedValue == "5" || CheckBoxList1.SelectedValue == "6" || CheckBoxList1.SelectedValue == "8")
            {
                incentiveremarks = txtincentiveremarks.Text;
            }
            else if (CheckBoxList1.SelectedValue == "7")
            {
                incentiveremarks = txtincentiveremarks.Text;
                AddDataToTableCeertificate(ddlstaire.SelectedItem.Text, incentiveremarks, Session["username"].ToString(), System.DateTime.Now.ToString("dd/MM/yyyy"), ddlstaire.SelectedValue, ViewState["IncentveID"].ToString(), Session["uid"].ToString(), (DataTable)Session["CertificateTb2"]);
                this.gvremarks.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                this.gvremarks.DataBind();
                trfullshap.Visible = true;
                ddlstaire.Items.Remove(ddlstaire.Items.FindByValue(ddlstaire.SelectedValue));
                if (ddlstaire.Items.Count >= 1)
                {
                    Button3.Text = "Raise Query to GM";
                    CheckBoxList1.Enabled = false;
                    BtnAddremarks.Visible = false;
                }
            }
            if (CheckBoxList1.SelectedValue == "2" || CheckBoxList1.SelectedValue == "5" || CheckBoxList1.SelectedValue == "6" || CheckBoxList1.SelectedValue == "7" || CheckBoxList1.SelectedValue == "8")   // Query
            {
                if (CheckBoxList1.SelectedValue == "5")
                {
                    AddDataToTableCeertificate(ddlstaire.SelectedItem.Text, incentiveremarks, Session["username"].ToString(), System.DateTime.Now.ToString("dd/MM/yyyy"), ddlstaire.SelectedValue, ViewState["IncentveID"].ToString(), Session["uid"].ToString(), (DataTable)Session["CertificateTb2"]);
                    this.gvremarks.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                    this.gvremarks.DataBind();
                    if ((DataTable)Session["CertificateTb2"] != null)
                    {
                        dtMyTableCertificate.Clear();
                        Session["CertificateTb2"] = dtMyTableCertificate;
                    }
                    trfullshap.Visible = true;
                    ddlstaire.Items.Remove(ddlstaire.Items.FindByValue(ddlstaire.SelectedValue));
                    if (ddlstaire.Items.Count >= 1)
                    {
                        Button3.Text = "Refer to SSC Inspection";
                        CheckBoxList1.Enabled = false;
                        BtnAddremarks.Visible = false;
                    }

                    if (Role_Code.Trim() == "ADDL")
                    {
                        trsscinspectiondate.Visible = true;

                    }
                    else
                    {
                        trsscinspectiondate.Visible = false;
                    }
                }
                else if (CheckBoxList1.SelectedValue == "8")
                {
                    AddDataToTableCeertificate(ddlstaire.SelectedItem.Text, incentiveremarks, Session["username"].ToString(), System.DateTime.Now.ToString("dd/MM/yyyy"), ddlstaire.SelectedValue, ViewState["IncentveID"].ToString(), Session["uid"].ToString(), (DataTable)Session["CertificateTb2"]);
                    this.gvremarks.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                    this.gvremarks.DataBind();
                    if ((DataTable)Session["CertificateTb2"] != null)
                    {
                        dtMyTableCertificate.Clear();
                        Session["CertificateTb2"] = dtMyTableCertificate;
                    }
                    trfullshap.Visible = true;
                    ddlstaire.Items.Remove(ddlstaire.Items.FindByValue(ddlstaire.SelectedValue));
                    if (ddlstaire.Items.Count >= 1)
                    {
                        Button3.Text = "SSC Inspection Completed";
                        CheckBoxList1.Enabled = false;
                        BtnAddremarks.Visible = false;
                    }

                    //if (Role_Code.Trim() == "ADDL")
                    //{
                    //    trsscinspectiondate.Visible = true;

                    //}
                    //else
                    //{
                    //    trsscinspectiondate.Visible = false;
                    //}
                }
                else if (CheckBoxList1.SelectedValue == "6")
                {
                    AddDataToTableCeertificate(ddlstaire.SelectedItem.Text, incentiveremarks, Session["username"].ToString(), System.DateTime.Now.ToString("dd/MM/yyyy"), ddlstaire.SelectedValue, ViewState["IncentveID"].ToString(), Session["uid"].ToString(), (DataTable)Session["CertificateTb2"]);
                    this.gvremarks.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                    this.gvremarks.DataBind();
                    if ((DataTable)Session["CertificateTb2"] != null)
                    {
                        dtMyTableCertificate.Clear();
                        Session["CertificateTb2"] = dtMyTableCertificate;
                    }
                    trfullshap.Visible = true;
                    ddlstaire.Items.Remove(ddlstaire.Items.FindByValue(ddlstaire.SelectedValue));
                    if (ddlstaire.Items.Count >= 1)
                    {
                        //if (Role_Code.Trim() == "JD")
                        //{
                        //    Button3.Text = "Return to DD/AD";
                        //}
                        //else if (Role_Code.Trim() == "ADDL")
                        //{
                        //    Button3.Text = "Return to JD";
                        //}
                        if (Role_Code.Trim() == "ADDL")
                        {
                            Button3.Text = "Return to JD";

                        }
                        if (Role_Code.Trim() == "JD")
                        {
                            Button3.Text = "Return to DD/AD";
                        }


                        CheckBoxList1.Enabled = false;
                        BtnAddremarks.Visible = false;
                    }

                }
                else if (CheckBoxList1.SelectedValue == "2")
                {
                    AddDataToTableCeertificate(ddlstaire.SelectedItem.Text, incentiveremarks, Session["username"].ToString(), System.DateTime.Now.ToString("dd/MM/yyyy"), ddlstaire.SelectedValue, ViewState["IncentveID"].ToString(), Session["uid"].ToString(), (DataTable)Session["CertificateTb2"]);
                    this.gvremarks.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                    this.gvremarks.DataBind();
                    if ((DataTable)Session["CertificateTb2"] != null)
                    {
                        dtMyTableCertificate.Clear();
                        Session["CertificateTb2"] = dtMyTableCertificate;
                    }
                    trfullshap.Visible = true;
                    ddlstaire.Items.Remove(ddlstaire.Items.FindByValue(ddlstaire.SelectedValue));
                    if (ddlstaire.Items.Count >= 1)
                    {
                        Button3.Text = "Raise Query";
                        CheckBoxList1.Enabled = false;
                        BtnAddremarks.Visible = false;
                    }
                }

            }
            else if (CheckBoxList1.SelectedValue == "3")    // Reject
            {
                AddDataToTablereject(ddlstaire.SelectedItem.Text, txtRejectreason.Text, Session["username"].ToString(), DateTime.Now.ToString("dd/MM/yyyy"), ddlstaire.SelectedValue, ViewState["IncentveID"].ToString(), Session["uid"].ToString(), (DataTable)Session["CertificateTbReject"]);
                this.gvRejected.DataSource = ((DataTable)Session["CertificateTbReject"]).DefaultView;
                this.gvRejected.DataBind();
                if ((DataTable)Session["CertificateTbReject"] != null)
                {
                    dtMyTableReject.Clear();
                    Session["CertificateTbReject"] = dtMyTableReject;
                }
                trrejectedtls.Visible = true;
                ddlstaire.Items.Remove(ddlstaire.Items.FindByValue(ddlstaire.SelectedValue));
                Button3.Text = "Reject Appication";
                if (ddlstaire.Items.Count == 1)
                {
                    CheckBoxList1.Enabled = false;
                    BtnAddremarks.Visible = false;
                }
            }

            else if (CheckBoxList1.SelectedValue == "4")    // Application Hold
            {
                AddDataToTablereject(ddlstaire.SelectedItem.Text, txtRejectreason.Text, Session["username"].ToString(), DateTime.Now.ToString("dd/MM/yyyy"), ddlstaire.SelectedValue, ViewState["IncentveID"].ToString(), Session["uid"].ToString(), (DataTable)Session["CertificateTbReject"]);
                this.gvHoldApplications.DataSource = ((DataTable)Session["CertificateTbReject"]).DefaultView;
                this.gvHoldApplications.DataBind();
                if ((DataTable)Session["CertificateTbReject"] != null)
                {
                    dtMyTableReject.Clear();
                    Session["CertificateTbReject"] = dtMyTableReject;
                }
                tr5.Visible = true;
                ddlstaire.Items.Remove(ddlstaire.Items.FindByValue(ddlstaire.SelectedValue));
                Button3.Text = "Send Application to Abeyance Stage";
                if (ddlstaire.Items.Count == 1)
                {
                    CheckBoxList1.Enabled = false;
                    BtnAddremarks.Visible = false;
                }
            }
            else
            {                                               //full in shape
                //AddDataToTableCeertificateAmount(ddlstaire.SelectedItem.Text, incentiveremarks, Session["username"].ToString(), System.DateTime.Now.ToString("dd/MM/yyyy"), ddlstaire.SelectedValue, ViewState["IncentveID"].ToString(), Session["uid"].ToString(), (DataTable)Session["CertificateTbAmount"]);
                if (Role_Code == "ADDL")
                {
                    GridView3.Columns[4].HeaderText = "Recomended By Addl Director";
                    AddDataToTableCeertificateAmount(ddlstaire.SelectedItem.Text, incentiveremarks, "As Proposed by JD(II)", System.DateTime.Now.ToString("dd/MM/yyyy"), ddlstaire.SelectedValue, ViewState["IncentveID"].ToString(), Session["uid"].ToString(), (DataTable)Session["CertificateTbAmount"]);
                }
                else
                {
                    AddDataToTableCeertificateAmount(ddlstaire.SelectedItem.Text, incentiveremarks, Session["username"].ToString(), System.DateTime.Now.ToString("dd/MM/yyyy"), ddlstaire.SelectedValue, ViewState["IncentveID"].ToString(), Session["uid"].ToString(), (DataTable)Session["CertificateTbAmount"]);
                }
                this.GridView3.DataSource = ((DataTable)Session["CertificateTbAmount"]).DefaultView;
                this.GridView3.DataBind();
                trnotinfullshap.Visible = true;
                // ddlstaire.Items.Remove(ddlstaire.SelectedValue);
                if (Role_Code.Trim() == "JD")
                {
                    if (GridView3.Rows.Count > 0)   //&& (txtLandJD.Text != "" && txtBuildingJD.Text != "" && txtPnMJD.Text != "")
                    {

                        ddlstaire.Items.Remove(ddlstaire.Items.FindByValue(ddlstaire.SelectedValue));
                        if (ddlstaire.Items.Count == 1)
                        {
                            CheckBoxList1.Enabled = false;
                            BtnAddremarks.Visible = false;
                        }
                    }

                }
                else
                    ddlstaire.Items.Remove(ddlstaire.Items.FindByValue(ddlstaire.SelectedValue));
                //ddlstaire.Items.Remove(ddlstaire.Items.FindByValue(ddlstaire.SelectedValue));
            }



            lblmsg.Text = "";
            ddlstaire.SelectedValue = "0";
            txtincentiveremarks.Text = "";
            txtRecommendedAmount.Text = "";
            CheckBoxList1.SelectedIndex = -1;

            foreach (GridViewRow rown in gvremarks.Rows)
            {
                string name = ((Label)rown.FindControl("lblCreatedByid")).Text.ToString();
                if (Session["uid"].ToString() != name)
                {
                    DataControlFieldCell editable = (DataControlFieldCell)rown.Controls[1];
                    editable.Enabled = false;
                }
            }

            //added by chinna

            trquery.Visible = false;
            trReject.Visible = false;
            trRecommendAmount.Visible = false;

        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
        gvremarks.Visible = true;
        Button3.Visible = true;
    }
    private void AddDataToTableCeertificate(string Incentive, string Remarks, string CreatedBy, string CreatedDate, string MstIncentiveId, string EnterperIncentiveID, string CreatedByid, DataTable myTable)
    {//totStartDate, string totEndDate, string totSummary,
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtMyTable = new DataTable("CertificateTb2");
            Row["Incentive"] = Incentive;
            //Row["status"] = status;
            Row["Remarks"] = Remarks;
            Row["CreatedBy"] = CreatedBy;
            Row["CreatedDate"] = CreatedDate;
            Row["MstIncentiveId"] = MstIncentiveId;
            Row["EnterperIncentiveID"] = EnterperIncentiveID;
            Row["CreatedByid"] = CreatedByid;
            Row["id"] = "0";
            myTable.Rows.Add(Row);
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }



    protected DataTable createtablecrtificate()
    {
        dtMyTable = new DataTable("CertificateTb2");

        // dtMyTable.Columns.Add("new", typeof(string));
        dtMyTable.Columns.Add("Incentive", typeof(string));
        //dtMyTable.Columns.Add("status", typeof(string));
        dtMyTable.Columns.Add("Remarks", typeof(string));
        dtMyTable.Columns.Add("CreatedBy", typeof(string));
        dtMyTable.Columns.Add("CreatedDate", typeof(string));
        dtMyTable.Columns.Add("MstIncentiveId", typeof(string));
        dtMyTable.Columns.Add("EnterperIncentiveID", typeof(string));
        dtMyTable.Columns.Add("CreatedByid", typeof(string));
        dtMyTable.Columns.Add("id", typeof(string));

        return dtMyTable;
    }

    private void AddDataToTablereject(string Incentive, string rejectMsg, string rejectedBy, string CreatedDate, string MstIncentiveId, string EnterperIncentiveID, string CreatedByid, DataTable myTable)
    {//totStartDate, string totEndDate, string totSummary,
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtMyTable = new DataTable("rejectTable");
            Row["Incentive"] = Incentive;
            //Row["status"] = status;
            Row["RejectMsg"] = rejectMsg;
            Row["RejectedBy"] = rejectedBy;
            Row["CreatedDate"] = CreatedDate;
            Row["MstIncentiveId"] = MstIncentiveId;
            Row["EnterperIncentiveID"] = EnterperIncentiveID;
            Row["CreatedByid"] = CreatedByid;
            Row["id"] = "0";
            myTable.Rows.Add(Row);
        }
        catch (Exception ee)
        {
            //  ((DataTable)Session["myDatatable"]).Rows.Clear();
            //  Response.Redirect("~/EmpFacility.aspx");
            LogErrorFile.LogerrorDB(ee, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected DataTable createtablerejection()
    {
        dtMyTable = new DataTable("rejectTable");

        // dtMyTable.Columns.Add("new", typeof(string));
        dtMyTable.Columns.Add("Incentive", typeof(string));
        //dtMyTable.Columns.Add("status", typeof(string));
        dtMyTable.Columns.Add("RejectMsg", typeof(string));
        dtMyTable.Columns.Add("RejectedBy", typeof(string));
        dtMyTable.Columns.Add("CreatedDate", typeof(string));
        dtMyTable.Columns.Add("MstIncentiveId", typeof(string));
        dtMyTable.Columns.Add("EnterperIncentiveID", typeof(string));
        dtMyTable.Columns.Add("CreatedByid", typeof(string));
        dtMyTable.Columns.Add("id", typeof(string));

        return dtMyTable;
    }



    private void AddDataToTableCeertificateAmount(string Incentive, string Remarks, string CreatedBy, string CreatedDate, string MstIncentiveId, string EnterperIncentiveID, string CreatedByid, DataTable myTableAmount)
    {//totStartDate, string totEndDate, string totSummary,
        try
        {
            DataRow Row;
            Row = myTableAmount.NewRow();

            dtMyTableAmount = new DataTable("CertificateTbAmount");
            Row["Incentive"] = Incentive;
            //Row["status"] = status;
            Row["RecomendedAmount"] = Remarks;
            Row["CreatedBy"] = CreatedBy;
            Row["CreatedDate"] = CreatedDate;
            Row["MstIncentiveId"] = MstIncentiveId;
            Row["EnterperIncentiveID"] = EnterperIncentiveID;
            Row["CreatedByid"] = CreatedByid;
            Row["id"] = "0";
            myTableAmount.Rows.Add(Row);
        }
        catch (Exception ee)
        {
            //  ((DataTable)Session["myDatatable"]).Rows.Clear();
            //  Response.Redirect("~/EmpFacility.aspx");
            LogErrorFile.LogerrorDB(ee, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected DataTable createtablecrtificateAmount()
    {
        dtMyTableAmount = new DataTable("CertificateTbAmount");

        // dtMyTable.Columns.Add("new", typeof(string));
        dtMyTableAmount.Columns.Add("Incentive", typeof(string));
        //dtMyTable.Columns.Add("status", typeof(string));
        dtMyTableAmount.Columns.Add("RecomendedAmount", typeof(string));
        dtMyTableAmount.Columns.Add("CreatedBy", typeof(string));
        dtMyTableAmount.Columns.Add("CreatedDate", typeof(string));
        dtMyTableAmount.Columns.Add("MstIncentiveId", typeof(string));
        dtMyTableAmount.Columns.Add("EnterperIncentiveID", typeof(string));
        dtMyTableAmount.Columns.Add("CreatedByid", typeof(string));
        dtMyTableAmount.Columns.Add("id", typeof(string));

        return dtMyTableAmount;
    }

    protected void gvremarks_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int rowww = e.RowIndex;
            string idnew = ((Label)gvremarks.Rows[e.RowIndex].FindControl("lblid")).Text.ToString().Trim();
            string IncentiveName = gvremarks.Rows[e.RowIndex].Cells[2].Text;
            string lblMstIncentiveId = ((Label)gvremarks.Rows[e.RowIndex].FindControl("lblMstIncentiveId")).Text.ToString().Trim();

            ListItem li = new ListItem();
            li.Text = IncentiveName;
            li.Value = lblMstIncentiveId;

            ddlstaire.Items.Add(li);

            if (idnew != "0" && idnew != "")
            {
                int validremaeks = Gen.deleteGroupSavingDataincentive(idnew);

            }
            if (gvremarks.Rows.Count == 1)
            {
                trfullshap.Visible = false;
                Button3.Visible = false;
            }
            ((DataTable)Session["CertificateTb2"]).Rows.RemoveAt(e.RowIndex);
            this.gvremarks.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
            this.gvremarks.DataBind();
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Please enter correct data";// ex.ToString();
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());

        }
        finally
        {

        }
    }

    protected void gvRejected_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int rowww = e.RowIndex;
            string idnew = ((Label)gvRejected.Rows[e.RowIndex].FindControl("lblid")).Text.ToString().Trim();
            string IncentiveName = gvRejected.Rows[e.RowIndex].Cells[2].Text;
            string lblMstIncentiveId = ((Label)gvRejected.Rows[e.RowIndex].FindControl("lblMstIncentiveId")).Text.ToString().Trim();

            ListItem li = new ListItem();
            li.Text = IncentiveName;
            li.Value = lblMstIncentiveId;

            ddlstaire.Items.Add(li);

            if (idnew != "0" && idnew != "")
            {
                int validremaeks = Gen.deleteGroupSavingDataincentive(idnew);

            }
            if (gvRejected.Rows.Count == 1)
            {
                trReject.Visible = false;
                Button3.Visible = false;
                trrejectedtls.Visible = false;
            }
            ((DataTable)Session["CertificateTbReject"]).Rows.RemoveAt(e.RowIndex);
            this.gvRejected.DataSource = ((DataTable)Session["CertificateTbReject"]).DefaultView;
            this.gvRejected.DataBind();
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Please enter correct data";// ex.ToString();
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
        finally
        {

        }
    }



    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            string status = "";
            string rejectremarks = "";
            string rejectIncentive = "";
            lstremarks.Clear();
            string IncentiveID = "";
            string Role_Code = Session["Role_Code"].ToString().Trim().TrimStart();
            foreach (GridViewRow gvrow in gvremarks.Rows)
            {
                //lstremarks.Clear();
                officerRemarks fromvo = new officerRemarks();
                int rowIndex = gvrow.RowIndex;
                fromvo.EnterperIncentiveID = ((Label)gvrow.FindControl("lblIncentiveID")).Text.ToString();

                fromvo.MstIncentiveId = ((Label)gvrow.FindControl("lblMstIncentiveId")).Text.ToString();
                fromvo.id = ((Label)gvrow.FindControl("lblid")).Text.ToString();
                if (Button3.Text == "Refer to SSC Inspection")
                {
                    fromvo.status = "SSC";
                    Button4.Visible = false;
                    if (Role_Code == "ADDL")
                    {
                        string txtsscinspection = txtsscinspectiondate.Text.Trim();
                        DateTime date1 = DateTime.Now;
                        System.Text.StringBuilder strMandt = new System.Text.StringBuilder();
                        string[] datessc = null;
                        if (txtsscinspection.Contains('/'))
                        {
                            datessc = txtsscinspection.Split('/');


                            try
                            {
                                date1 = cmf.convertDateIndia(datessc[2] + "/" + datessc[1] + "/" + datessc[0]);
                                fromvo.SSCdate = datessc[2] + "/" + datessc[1] + "/" + datessc[0];// txtsscinspection.Text;
                            }
                            catch (Exception ex)
                            {
                                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
                                return;
                            }
                        }
                        else
                        {
                            string message = "alert('Please Select Valid Date from Calender')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                            return;
                        }

                    }
                }
                else if (Button3.Text == "SSC Inspection Completed")
                {
                    if (Role_Code == "ADDL")
                    {
                        fromvo.status = "SSC REPORT";
                        Button4.Visible = false;
                    }
                }
                else if (Button3.Text == "Return to DD/AD" || Button3.Text == "Return to JD")
                {
                    if (Role_Code == "JD")
                    {
                        fromvo.status = "Return";
                    }
                    else if (Role_Code == "ADDL")
                    {
                        fromvo.status = "Return";
                    }
                }
                else if (Button3.Text == "Raise Query to GM")
                {
                    fromvo.status = "QueryGM";
                    Button4.Visible = true;
                }
                else
                {
                    fromvo.status = "Query";
                    Button4.Visible = true;
                }

                fromvo.Remarks = HttpUtility.HtmlDecode(gvremarks.Rows[rowIndex].Cells[3].Text);
                fromvo.CreatedByid = ((Label)gvrow.FindControl("lblCreatedByid")).Text.ToString();
                fromvo.Designation = Role_Code.Trim();
                fromvo.id = ((Label)gvrow.FindControl("lblid")).Text.ToString();
                lstremarks.Add(fromvo);
            }


            foreach (GridViewRow gvrow in gvRejected.Rows)
            {
                officerRemarks fromvo = new officerRemarks();
                int rowIndex = gvrow.RowIndex;
                fromvo.EnterperIncentiveID = ((Label)gvrow.FindControl("lblIncentiveID")).Text.ToString();

                fromvo.MstIncentiveId = ((Label)gvrow.FindControl("lblMstIncentiveId")).Text.ToString();
                fromvo.id = ((Label)gvrow.FindControl("lblid")).Text.ToString();
                fromvo.status = "Reject";
                fromvo.Remarks = HttpUtility.HtmlDecode(gvRejected.Rows[rowIndex].Cells[3].Text);
                fromvo.CreatedByid = ((Label)gvrow.FindControl("lblCreatedByid")).Text.ToString();
                fromvo.Designation = Role_Code.Trim();
                fromvo.id = ((Label)gvrow.FindControl("lblid")).Text.ToString();

                lstremarks.Add(fromvo);
                status = "Reject";
            }

            // added by chh on 11.01.2018 for application hold stage by COI

            foreach (GridViewRow gvrow in gvHoldApplications.Rows)
            {
                officerRemarks fromvo = new officerRemarks();
                int rowIndex = gvrow.RowIndex;
                fromvo.EnterperIncentiveID = ((Label)gvrow.FindControl("Label16")).Text.ToString();

                fromvo.MstIncentiveId = ((Label)gvrow.FindControl("Label15")).Text.ToString();
                fromvo.id = ((Label)gvrow.FindControl("Label18")).Text.ToString();
                fromvo.status = "Hold Application";
                fromvo.Remarks = HttpUtility.HtmlDecode(gvHoldApplications.Rows[rowIndex].Cells[3].Text);
                fromvo.CreatedByid = ((Label)gvrow.FindControl("Label17")).Text.ToString();
                fromvo.Designation = Role_Code.Trim();
                fromvo.id = ((Label)gvrow.FindControl("Label18")).Text.ToString();

                lstremarks.Add(fromvo);
                status = "Hold Application";
            }

            foreach (GridViewRow gvrow in GridView3.Rows)
            {
                officerRemarks fromvo = new officerRemarks();
                int rowIndex = gvrow.RowIndex;
                fromvo.EnterperIncentiveID = ((Label)gvrow.FindControl("lblIncentiveID")).Text.ToString();
                fromvo.MstIncentiveId = ((Label)gvrow.FindControl("lblMstIncentiveId")).Text.ToString();
                fromvo.id = ((Label)gvrow.FindControl("lblid")).Text.ToString();
                fromvo.status = "File in full shape";
                fromvo.Remarks = HttpUtility.HtmlDecode(GridView3.Rows[rowIndex].Cells[3].Text);
                fromvo.CreatedByid = ((Label)gvrow.FindControl("lblCreatedByid")).Text.ToString();
                fromvo.id = ((Label)gvrow.FindControl("lblid")).Text.ToString();


                fromvo.Designation = Role_Code.Trim();
                if (tradditional.Visible == true)
                {
                    string[] datett = txtslcnodate.Text.Trim().Split('/');
                    fromvo.Slcdate = datett[2] + "/" + datett[1] + "/" + datett[0];
                    fromvo.SLCNO = txtslcno.Text.Trim();
                }
                lstremarks.Add(fromvo);

            }


            foreach (GridViewRow gvrow in gvinspectionOfficer.Rows)
            {
                officerForwarded frmvo = new officerForwarded();
                string lblMstIncentiveId = ((Label)gvrow.FindControl("lblMstIncentiveId")).Text;
                string lblIncentiveID = ((Label)gvrow.FindControl("lblIncentiveID")).Text;
                IncentiveID = lblIncentiveID;
                frmvo.EnterperIncentiveID = lblIncentiveID;
                frmvo.MstIncentiveId = lblMstIncentiveId;
                frmvo.CreatedByid = Session["uid"].ToString();
                frmvo.ApplicationFrom = Session["uid"].ToString();
                if (tradditional.Visible == true)
                {
                    string[] datett = txtslcnodate.Text.Trim().Split('/');
                    frmvo.Slcdate = datett[2] + "/" + datett[1] + "/" + datett[0];
                    frmvo.SLCNO = txtslcno.Text.Trim();
                }
                //else if (trpostsvc.Visible == true)
                //{
                //    string[] datett = txtsvcdate.Text.Trim().Split('/');
                //    frmvo.SVCdate = datett[2] + "/" + datett[1] + "/" + datett[0];
                //}
                lstincentives.Add(frmvo);
            }

            int valid = 0;

            //if (ViewState["DisignationLoad"].ToString() == "SA")
            //{
            //    valid = Gen.InsertincentiveOfficerComments(lstremarks, lstincentives);
            //}
            //else if (ViewState["DisignationLoad"].ToString() == "SUP")
            //{
            //    valid = Gen.InsertincentiveOfficerCommentsSUP(lstremarks, lstincentives);
            //}
            //else if (ViewState["DisignationLoad"].ToString() == "ADD")
            //{
            //    valid = Gen.InsertincentiveOfficerCommentsAD(lstremarks, lstincentives);
            //}
            //else if (ViewState["DisignationLoad"].ToString() == "DD")
            //{
            //    valid = Gen.InsertincentiveOfficerCommentsDD(lstremarks, lstincentives);
            //}
            if (Role_Code.Trim() == "JD")
            {


                if (GridView3.Rows.Count > 0 && (txtLandJD.Text == "" || txtBuildingJD.Text == "" || txtPnMJD.Text == "0" || txtPnMJD.Text == "") && lblsector.Text == "Manufacture" && ddlstaire.SelectedItem.Value.ToString() == "6" && trLandBuidlingMachinery.Visible == true)
                {
                    string message;
                    message = "alert('Please mention Land,Building, Plant and Machinery Values')";

                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    GridView3.DataSource = null;
                    GridView3.DataBind();
                    trnotinfullshap.Visible = false;
                    trRecommendAmount.Visible = true;
                    Button3.Visible = false;
                    return;
                }

                else if (GridView3.Rows.Count > 0 && (txtLandJD.Text != "" && txtBuildingJD.Text != "" && txtPnMJD.Text != "0") && (lblsector.Text == "Manufacture" && ddlstaire.SelectedItem.Value.ToString() == "6"))
                {
                    valid = Gen.InsertincentiveOfficerCommentsjD(lstremarks, lstincentives, getclientIP(), txtLandJD.Text, txtBuildingJD.Text, txtPnMJD.Text, "");
                }
                else
                    valid = Gen.InsertincentiveOfficerCommentsjD(lstremarks, lstincentives, getclientIP(), txtLandJD.Text, txtBuildingJD.Text, txtPnMJD.Text, "");

                // added on 18.05.2018 

                if (valid == 1)
                {
                    foreach (GridViewRow gvrow in gvremarks.Rows)
                    {
                        officerRemarks fromvo = new officerRemarks();
                        int rowIndex = gvrow.RowIndex;

                        fromvo.Remarks = HttpUtility.HtmlDecode(gvremarks.Rows[rowIndex].Cells[3].Text);
                        fromvo.Incentive = HttpUtility.HtmlDecode(gvremarks.Rows[rowIndex].Cells[2].Text);
                        if (Button3.Text != "Refer to SSC Inspection" && Button3.Text != "Return to DD/AD" && Button3.Text != "Return to JD")
                        {

                            try
                            {
                                SendSmsEmail(fromvo.Remarks, fromvo.Incentive);
                            }
                            catch (Exception ex)
                            {
                                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
                            }

                        }

                    }
                }

            }
            else if (Role_Code.Trim() == "ADDL")
            {
                //if (Request.QueryString["SVCStatus"].ToString() == "PRESVC")
                //{
                //    valid = Gen.InsertincentiveOfficerCommentsAdditional(lstremarks, lstincentives);
                //}
                if (Request.QueryString["SVCStatus"].ToString() == "PRESVC")  // send to post SVC
                {
                    valid = Gen.InsertincentiveOfficerCommentsAdditionalPOSTSVC(lstremarks, lstincentives, "PRESVC", getclientIP());
                }
                else if (Request.QueryString["SVCStatus"].ToString() == "POSTSVC")   // send to POST SLC
                {
                    valid = Gen.InsertincentiveOfficerCommentsAdditionalPOSTSLC(lstremarks, lstincentives, "POSTSVC", getclientIP());
                }
                else if (Request.QueryString["SVCStatus"].ToString() == "POSTSLC")   // send to POST SLC
                {
                    valid = Gen.InsertincentiveOfficerCommentsAdditionalPOSTSLCFinal(lstremarks, lstincentives, "POSTSLC", getclientIP());
                    string[] datett = txtslcnodate.Text.Trim().Split('/');
                    string Slcdate = datett[2] + "/" + datett[1] + "/" + datett[0];

                    DataSet dsnew = new DataSet();
                    dsnew = Gen.getincentiveslcfinallistNew(txtslcno.Text.Trim(), IncentiveID, Slcdate);
                    if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                    {
                        gvdetailsfinalproforma.DataSource = dsnew.Tables[0];
                        gvdetailsfinalproforma.DataBind();
                        btnfinalsubmit.Visible = true;
                    }
                }
                //string incentiveid = ViewState["IncentveID"].ToString();
                //Response.Redirect("ProformaIntimationLetter.aspx?incentiveid=" + incentiveid);
            }
            else if (ViewState["DIPCFlag"].ToString().Trim() == "Y")   // send to POST DLC
            {
                valid = Gen.InsertincentiveOfficerCommentsAdditionalPOSTSLCFinal(lstremarks, lstincentives, "DIPC", getclientIP());
                string[] datett = txtslcnodate.Text.Trim().Split('/');
                string Slcdate = datett[2] + "/" + datett[1] + "/" + datett[0];

                DataSet dsnew = new DataSet();
                dsnew = Gen.getincentiveslcfinallistNew(txtslcno.Text.Trim(), IncentiveID, Slcdate);
                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    gvdetailsfinalproforma.DataSource = dsnew.Tables[0];
                    gvdetailsfinalproforma.DataBind();
                    btnfinalsubmit.Visible = true;
                }
            }
            if (valid == 1)
            {
                //lblmsg.Text = "<font color='green'>Application Submitted Successfully..!</font>";
                //success.Visible = true;
                //Failure.Visible = false;
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Application Submitted Successfully');", true);
                string message = "";
                if (status == "Reject")
                {
                    message = "alert('Application Rejected Successfully')";
                }
                else if (status == "Query")
                {
                    message = "alert('Query Raised Successfully')";
                }
                else if (status == "QueryGM")
                {
                    message = "alert('GM Query Raised Successfully')";
                }
                else
                {
                    message = "alert('Application Submitted Successfully')";
                }
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                // BtnAddremarks.Visible = false;
                trReject.Visible = false;
                trrejectedtls.Visible = false;
                gvRejected.Visible = false;
                gvRejected.DataSource = null;
                Button3.Visible = false;
                if (status == "Reject")
                {
                    foreach (GridViewRow gvrow in gvRejected.Rows)
                    {
                        int rowIndex = gvrow.RowIndex;
                        rejectremarks = HttpUtility.HtmlDecode(gvRejected.Rows[rowIndex].Cells[3].Text);
                        rejectIncentive = HttpUtility.HtmlDecode(gvRejected.Rows[rowIndex].Cells[2].Text);
                        SendRejectSmsEmail(rejectremarks, rejectIncentive, "JD");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        try
        {
            string MstIncentiveid = "";
            foreach (GridViewRow gvrow in gvinspectionOfficer.Rows)
            {
                officerForwarded frmvo = new officerForwarded();
                string lblMstIncentiveId = ((Label)gvrow.FindControl("lblMstIncentiveId")).Text;
                string lblIncentiveID = ((Label)gvrow.FindControl("lblIncentiveID")).Text;

                frmvo.EnterperIncentiveID = lblIncentiveID;
                frmvo.MstIncentiveId = lblMstIncentiveId;

                if (MstIncentiveid == "")
                {
                    MstIncentiveid = frmvo.MstIncentiveId;
                }
                else
                {
                    MstIncentiveid = MstIncentiveid + "," + frmvo.MstIncentiveId;
                }

                frmvo.CreatedByid = Session["uid"].ToString();
                frmvo.ApplicationFrom = Session["User_Code"].ToString();
                lstincentives.Add(frmvo);
            }
            Session["lstincentives"] = lstincentives;
            if (Session["uid"].ToString() == "3377")
            {
                Response.Redirect("ProformaQueryRaiseShortFallLetter.aspx?incentiveid=" + ViewState["IncentveID"].ToString() + "&IncIds=" + MstIncentiveid);
            }
            else if (Session["uid"].ToString() == "21345")
            {
                Response.Redirect("ProformaQueryRaiseShortFallLetterAddl.aspx?incentiveid=" + ViewState["IncentveID"].ToString() + "&IncIds=" + MstIncentiveid);
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void btnupdatestatus_Click(object sender, EventArgs e)
    {
        try
        {
            string intApplicationid, Deptname, Modified_by, EMiUdyogAadhar, SentFrom, Status, MstIncentiveId, txtIncQuery, txtinspectiondatekk;

            string intApplicationidnew = "";
            string StatusApp = Request.QueryString[1].ToString();
            int returnValuenew = 0;
            txtinspectiondatekk = txtinspectiondate.Text.Trim();
            DateTime date1 = DateTime.Now;
            System.Text.StringBuilder strMandt = new System.Text.StringBuilder();
            string[] dateinsp = null;
            if (txtinspectiondatekk.Contains('/'))
            {
                dateinsp = txtinspectiondatekk.Split('/');


                try
                {
                    date1 = cmf.convertDateIndia(dateinsp[2] + "/" + dateinsp[1] + "/" + dateinsp[0]);
                }
                catch (Exception ex)
                {
                    LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
                    return;
                }
            }
            else
            {
                string message = "alert('Please Select Valid Date from Calender')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }

            foreach (GridViewRow gvrow in gvdicinspection.Rows)
            {

                intApplicationid = ((Label)gvrow.FindControl("lblIncentiveID")).Text.ToString();
                intApplicationidnew = intApplicationid;
                MstIncentiveId = ((Label)gvrow.FindControl("lblMstIncentiveId")).Text.ToString();

                //txtIncQuery = ((TextBox)gvrow.FindControl("txtIncQueryFnl")).Text.ToString();
                // txtinspectiondate = ((TextBox)gvrow.FindControl("txtinspectiondate")).Text.ToString();
                EMiUdyogAadhar = txtudyogAadharNo.Text;
                Modified_by = Session["uid"].ToString();
                SentFrom = Session["User_Code"].ToString();
                Status = "3";
                string deptIPOName = Session["username"].ToString();
                string deptIPOMoileNO = Session["MobileNumber"].ToString();
                DataSet dsdt = new DataSet();
                dsdt = Gen.GetDepartmentUserDeails(Session["username"].ToString());
                if (dsdt != null && dsdt.Tables.Count > 0 && dsdt.Tables[0].Rows.Count > 0)
                {
                    deptIPOName = dsdt.Tables[0].Rows[0]["empnsme"].ToString();
                    deptIPOMoileNO = dsdt.Tables[0].Rows[0]["Mobile"].ToString();
                }

                if (ViewState["DisignationLoad"].ToString().Trim() == "IPO" || ViewState["DisignationLoad"].ToString().Trim() == "AD" || ViewState["DisignationLoad"].ToString().Trim() == "DD")
                {

                    int returnValue = Gen.UpdateInspectionDateNewIncTypeNew(intApplicationid, dateinsp[2] + "/" + dateinsp[1] + "/" + dateinsp[0], Session["uid"].ToString(), MstIncentiveId, getclientIP());
                    returnValuenew = returnValue;
                    if (returnValuenew != 999)
                    {
                        dsdt = Gen.GetDepartmentUserDeails(Session["username"].ToString());

                        DataTable dtMandt = objFetch.FetchIncentiveMandatoryDocuments(Convert.ToInt32(intApplicationid));


                        for (int i = 0; i < dtMandt.Rows.Count - 1; i++) strMandt.Append(dtMandt.Rows[i]["AttachmentName"].ToString() + "<br />");


                    }
                    else
                    {
                        //Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Failed..');", true);

                        //lblresult.Text = "Date is Not Updated";
                        return;
                    }
                }

                //lblmsg.Text = "<font color='green'>Inspection Date Assigned Successfully..!</font>";
                //success.Visible = true;
                //Failure.Visible = false;
                //lblmsg.Focus();
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Inspection Date Assigned Successfully');", true);
                try
                {
                    //cmf.SendMailIncentive(txtunitemailid.Text, "Dear " + txtApplicantName.Text + "  :<br/><br/>Incentive Inspection Due Diligence for :<br /><br/><b> Incentive inspection is scheduled on Dated:" + date1.ToString("dd-MMMM-yyyy") + ". </b><br/><br/>Please Ensure that you are carrrying all the original Mandatory documents with you on " + date1.ToString("dd-MMMM-yyyy") + ".<br/><br /> <b>Mandatory Documents List</b> <br /> " + strMandt.ToString() + ",and your assigned officer is" + deptIPOName + "and contact numer is" + deptIPOMoileNO + "<br /><br />  Thank You,<br />  Govt. of Telangana.");
                    //  cmf.SendMailIncentive(txtunitemailid.Text, "Dear " + txtUnitname1.Text + (" bearing application no:" + lblApplicationNo.Text) + "  : <br/><br/>Incentive Inspection Due Diligence for :<br /><br/><b> Incentive inspection is scheduled on Dated:" + date1.ToString("dd-MMMM-yyyy") + ". </b><br/><br/>Please Ensure that you are carrrying all the original Mandatory documents with you on " + date1.ToString("dd-MMMM-yyyy") + ".<br/><br /> <b>Mandatory Documents List</b> <br /> " + strMandt.ToString() + ",and your assigned officer is " + deptIPOName + " and contact numer is " + deptIPOMoileNO + "<br /><br />  Thank You,<br />  Govt. of Telangana.");

                }
                catch (Exception ex)
                {
                    LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
                }
                try
                {
                    string nameuid = txtunitemailid.Text.Replace("@", "(at)");
                    //cmf.SendSingleSMS(txtunitmobileno.Text, "Dear " + txtApplicantName.Text + ", Incentive Inspection is scheduled on " + date1.ToString("dd-MMMM-yyyy") + ", and your assigned IPO is " + deptIPOName + " and contact numer is " + deptIPOMoileNO + ". Please make available with your mandatory documents,the detailed inforamtion send to " + nameuid + ". Thank You, Govt. of Telangana.");
                    if (lblvehno.Text == "")
                    {

                        //cmf.SendSingleSMSnew(txtunitmobileno.Text, "Dear Sir, Incentive Inspection is scheduled for your application (" + lblApplicationNo.Text.ToString() + ") on " + date1.ToString("dd-MMMM-yyyy") + ", and your assigned Inspecting Officer is " + deptIPOName + " and contact number is " + deptIPOMoileNO + ". Please make available mandatory documents at the Unit Location. Thank You, GM, DIC " + ddldistrictunit.Text + " Govt. of Telangana.", "100709214599452954");
                        cmf.SendSingleSMSnew(txtunitmobileno.Text, "Dear Sir, Incentive Inspection is scheduled for your application (" + lblApplicationNo.Text.ToString() + ") on " + date1.ToString("dd-MMMM-yyyy") + ", and your assigned Inspecting Officer is " + deptIPOName + " and contact number is " + deptIPOMoileNO + ". Please make available mandatory documents at the Unit Location. Thank You, GM, DIC " + ddldistrictunit.Text + " Govt. of Telangana.", "1007092145994529547");
                        ddlinspectionorquery.Enabled = false;
                        btnSubmit.Enabled = false;
                        string message = "alert('Inspection Date Assigned Successfully')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                    if (lblvehno.Text != "")  //for vehicle
                    {
                        //string mobile = txtunitmobileno.Text.ToString().Trim();
                        //string dates = date1.ToString("dd-MMMM-yyyy");
                        //string test = "Inspection scheduled on " + dates + " and Officer is " + deptIPOName + " and contact no is " + deptIPOMoileNO + ".Please bring vehicle to DIC -" + ddldistrictunit.Text + ".GM,DIC-" + ddldistrictunit.Text;
                        ////cmf.SendSingleSMSnew(txtunitmobileno.Text, test, "100709214599452954");

                        ////SendSingleSMSnew(mobile, test, "1007718233671294577");
                        //string returns = SendSingleSMSneww(mobile, test);
                        //txtunitmobileno.Text = "ok";
                        //string message = "alert('Inspection Date Assigned Successfullys')";
                        //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        //cmf.SendSingleSMSnew(txtunitmobileno.Text, "Dear Sir, Incentive Inspection is scheduled for your application (" + lblApplicationNo.Text.ToString() + ") on " + date1.ToString("dd-MMMM-yyyy") + ", and your assigned Inspecting Officer is " + deptIPOName + " and contact number is " + deptIPOMoileNO + ". Please bring your vehicle to  DIC -" + ddldistrictunit.Text + "Thank You, GM, DIC " + ddldistrictunit.Text + " Govt. of Telangana.", "1007878969704519195");
                        cmf.SendSingleSMSnew(txtunitmobileno.Text, "TS-iPASS:Dear Sir, Incentive Inspection is scheduled for your application (" + lblApplicationNo.Text.ToString() + ") on " + date1.ToString("dd-MMMM-yyyy") + ", and your assigned Inspecting Officer is " + deptIPOName + " and contact number is " + deptIPOMoileNO + ".Please bring your vehicle to  DIC - " + ddldistrictunit.Text + " Thank You, GM, DIC " + ddldistrictunit.Text + " Govt.of Telangana.", "1007878969704519195");
                    }

                }
                catch (Exception ex)
                {
                    LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
                }

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void ChckedChanged(object sender, EventArgs e)
    {
        GetSelectedRows();
    }

    private void GetSelectedRows()
    {
        //CheckBox chkCheck=(CheckBox) grdDetails.
    }
    //protected void Button5_Click(object sender, EventArgs e)
    //{

    //    Response.Redirect("InspectionReport.aspx?incentiveid=" + ViewState["IncentveID"].ToString());
    //}
    protected void btnsendcoi_Click(object sender, EventArgs e)
    {
        try
        {
            lstremarks.Clear();
            //foreach (GridViewRow gvrow in gvquerygm.Rows)
            //{
            officerRemarks fromvo = new officerRemarks();
            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            // int rowIndex = gvrow.RowIndex;

            fromvo.EnterperIncentiveID = ((Label)gvquerygm.Rows[indexing].FindControl("lblIncentiveID")).Text.ToString();
            fromvo.MstIncentiveId = ((Label)gvquerygm.Rows[indexing].FindControl("lblMstIncentiveId")).Text.ToString();
            fromvo.id = ((Label)gvquerygm.Rows[indexing].FindControl("lblid")).Text.ToString();
            fromvo.Remarks = "";
            fromvo.CreatedByid = Session["uid"].ToString();
            fromvo.id = ((Label)gvquerygm.Rows[indexing].FindControl("lblid")).Text.ToString();
            string txtIncQueryFnl5 = ((TextBox)gvquerygm.Rows[indexing].FindControl("txtIncQueryFnl5")).Text;
            fromvo.Responce = txtIncQueryFnl5;
            if (txtIncQueryFnl5.Trim().TrimStart() == "")
            {
                string messagenew = "alert('Kindly Enter Remarks')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", messagenew, true);
                return;
            }
            lstremarks.Add(fromvo);
            // }
            int valid = Gen.InsertincentiveOfficerCommentsGMResponce(lstremarks, getclientIP());
            //lblmsg.Text = "<font color='green'>Response Submitted Successfully..!</font>";
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Response Submitted Successfully');", true);
            //success.Visible = true;
            //Failure.Visible = false;
            try
            {
                FileUpload FileUpload1 = (FileUpload)gvquerygm.Rows[indexing].FindControl("FileUploadquery");

                string newPath = "";

                General t1 = new General();
                if (FileUpload1.HasFile)
                {
                    string incentiveid = fromvo.EnterperIncentiveID;

                    if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
                    {
                        string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                        try
                        {
                            string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                            int i = fileType.Length;
                            if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                            {
                                string serverpath = Server.MapPath("~\\ResponseAttachmentforIcentive\\" + incentiveid.ToString() + "\\IOQuery" + fromvo.MstIncentiveId);  // incentiveid2
                                if (!Directory.Exists(serverpath))
                                    Directory.CreateDirectory(serverpath);

                                FileUpload1.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                                string CrtdUser = Session["uid"].ToString();

                                string Path = serverpath;
                                string FileName = sFileName;
                                ViewState["AttachmentName"] = sFileName;
                                ViewState["pathAttachment"] = serverpath;

                                t1.InsertIncentiveAttachmentQueryResponse(incentiveid, incentiveid + fromvo.MstIncentiveId, sFileName, serverpath, CrtdUser, fromvo.MstIncentiveId, getclientIP());
                            }
                            else
                            {

                            }
                        }
                        catch (Exception ex)//in case of an error
                        {
                            DeleteFile(newPath + "\\" + sFileName);
                            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //lblmsg0.Text = "Internal error has occured. Please try after some time";
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
        string message = "alert('Response Submitted Successfully')";
        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
    }
    protected void btnsendcoissc_Click(object sender, EventArgs e)
    {
        try
        {
            lstremarks.Clear();
            //foreach (GridViewRow gvrow in gvquerygm.Rows)
            //{
            officerRemarks fromvo = new officerRemarks();
            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            // int rowIndex = gvrow.RowIndex;

            fromvo.EnterperIncentiveID = ((Label)gvsscinspection.Rows[indexing].FindControl("lblIncentiveIDssc")).Text.ToString();
            fromvo.MstIncentiveId = ((Label)gvsscinspection.Rows[indexing].FindControl("lblMstIncentiveIdssc")).Text.ToString();
            fromvo.id = ((Label)gvsscinspection.Rows[indexing].FindControl("lblidssc")).Text.ToString();
            fromvo.Remarks = "";
            fromvo.CreatedByid = Session["uid"].ToString();
            fromvo.id = ((Label)gvsscinspection.Rows[indexing].FindControl("lblidssc")).Text.ToString();
            string txtIncQueryFnl5 = ((TextBox)gvsscinspection.Rows[indexing].FindControl("txtIncQueryFnl5ssc")).Text;
            fromvo.Responce = txtIncQueryFnl5;
            if (txtIncQueryFnl5.Trim().TrimStart() == "")
            {
                string messagenew = "alert('Kindly Enter Remarks')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", messagenew, true);
                return;
            }
            lstremarks.Add(fromvo);
            // }
            int valid = InsertincentiveOfficerCommentsGMResponce_SSCREPORT(lstremarks, getclientIP());
            //lblmsg.Text = "<font color='green'>Response Submitted Successfully..!</font>";
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Response Submitted Successfully');", true);
            //success.Visible = true;
            //Failure.Visible = false;
            try
            {
                FileUpload FileUpload1 = (FileUpload)gvsscinspection.Rows[indexing].FindControl("FileUploadquery");

                string newPath = "";

                General t1 = new General();
                if (FileUpload1.HasFile)
                {
                    string incentiveid = fromvo.EnterperIncentiveID;

                    if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
                    {
                        string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                        try
                        {
                            string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                            int i = fileType.Length;
                            if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                            {
                                string serverpath = Server.MapPath("~\\ResponseAttachmentforIcentive\\" + incentiveid.ToString() + "\\IOQuery" + fromvo.MstIncentiveId);  // incentiveid2
                                if (!Directory.Exists(serverpath))
                                    Directory.CreateDirectory(serverpath);

                                FileUpload1.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                                string CrtdUser = Session["uid"].ToString();

                                string Path = serverpath;
                                string FileName = sFileName;
                                ViewState["AttachmentName"] = sFileName;
                                ViewState["pathAttachment"] = serverpath;

                                t1.InsertIncentiveAttachmentQueryResponse(incentiveid, incentiveid + fromvo.MstIncentiveId, sFileName, serverpath, CrtdUser, fromvo.MstIncentiveId, getclientIP());
                            }
                            else
                            {

                            }
                        }
                        catch (Exception ex)//in case of an error
                        {
                            DeleteFile(newPath + "\\" + sFileName);
                            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //lblmsg0.Text = "Internal error has occured. Please try after some time";
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
        string message = "alert('Response Submitted Successfully')";
        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
    }
    public int InsertincentiveOfficerCommentsGMResponce_SSCREPORT(List<officerRemarks> Ramarks, string IPAddress)
    {
        int valid = 0;

        foreach (officerRemarks Ramarksvo in Ramarks)
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("USP_INSERT_OfficerRemarks_Responce_SSCREPORT", con.GetConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@EnterperIncentiveID", Convert.ToString(Ramarksvo.EnterperIncentiveID));
                cmd.Parameters.AddWithValue("@MstIncentiveId", Convert.ToString(Ramarksvo.MstIncentiveId));
                cmd.Parameters.AddWithValue("@Remarks", Convert.ToString(Ramarksvo.Remarks));
                cmd.Parameters.AddWithValue("@CreatedByid", Convert.ToString(Ramarksvo.CreatedByid));
                cmd.Parameters.AddWithValue("@id", Convert.ToString(Ramarksvo.id));
                cmd.Parameters.AddWithValue("@GmResponce", Convert.ToString(Ramarksvo.Responce));
                cmd.Parameters.AddWithValue("@IPAddress", SqlDbType.VarChar).Value = IPAddress.Trim();
                cmd.Parameters.Add("@Valid", SqlDbType.Int, 500);
                cmd.Parameters["@Valid"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                valid = (Int32)cmd.Parameters["@Valid"].Value;
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                con.CloseConnection();
            }
        }

        return valid;
    }


    public void DeleteFile(string strFileName)
    {
        if (strFileName.Trim().Length > 0)
        {
            FileInfo fi = new FileInfo(strFileName);
            if (fi.Exists)
            {
                fi.Delete();
            }
        }
    }

    protected void btnsendcoiadd_Click(object sender, EventArgs e)
    {
        try
        {
            lstremarks.Clear();
            //foreach (GridViewRow gvrow in gvquerygm.Rows)
            //{
            officerRemarks fromvo = new officerRemarks();
            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            // int rowIndex = gvrow.RowIndex;

            fromvo.EnterperIncentiveID = ((Label)GridView8.Rows[indexing].FindControl("lblIncentiveID")).Text.ToString();
            fromvo.MstIncentiveId = ((Label)GridView8.Rows[indexing].FindControl("lblMstIncentiveId")).Text.ToString();
            fromvo.id = ((Label)GridView8.Rows[indexing].FindControl("lblid")).Text.ToString();
            fromvo.Remarks = "";
            fromvo.CreatedByid = Session["uid"].ToString();
            fromvo.id = ((Label)GridView8.Rows[indexing].FindControl("lblid")).Text.ToString();
            string txtIncQueryFnl5 = ((TextBox)GridView8.Rows[indexing].FindControl("txtIncQueryFnl5")).Text;
            fromvo.Responce = txtIncQueryFnl5;
            if (txtIncQueryFnl5.Trim().TrimStart() == "")
            {
                string messagenew = "alert('Kindly Enter Remarks')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", messagenew, true);
                return;
            }
            lstremarks.Add(fromvo);
            // }
            int valid = Gen.InsertincentiveOfficerCommentsJDResponceAdd(lstremarks, getclientIP());
            //lblmsg.Text = "<font color='green'>Response Submitted Successfully..!</font>";
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Response Submitted Successfully');", true);
            //success.Visible = true;
            //Failure.Visible = false;
            try
            {
                FileUpload FileUpload1 = (FileUpload)gvquerygm.Rows[indexing].FindControl("FileUploadquery");

                string newPath = "";

                General t1 = new General();
                if (FileUpload1.HasFile)
                {
                    string incentiveid = fromvo.EnterperIncentiveID;

                    if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
                    {
                        string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                        try
                        {
                            string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                            int i = fileType.Length;
                            if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                            {
                                string serverpath = Server.MapPath("~\\ResponseAttachmentforIcentive\\" + incentiveid.ToString() + "\\jdaddlQuery" + fromvo.MstIncentiveId);  // incentiveid2
                                if (!Directory.Exists(serverpath))
                                    Directory.CreateDirectory(serverpath);

                                FileUpload1.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                                string CrtdUser = Session["uid"].ToString();

                                string Path = serverpath;
                                string FileName = sFileName;
                                ViewState["AttachmentName"] = sFileName;
                                ViewState["pathAttachment"] = serverpath;

                                t1.InsertIncentiveAttachmentQueryResponse(incentiveid, incentiveid + fromvo.MstIncentiveId, sFileName, serverpath, CrtdUser, fromvo.MstIncentiveId, getclientIP());
                            }
                            else
                            {

                            }
                        }
                        catch (Exception ex)//in case of an error
                        {
                            DeleteFile(newPath + "\\" + sFileName);
                            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //lblmsg0.Text = "Internal error has occured. Please try after some time";
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
        string message = "alert('Response Submitted Successfully')";
        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
    }
    public static string getclientIP()
    {
        string result = string.Empty;
        string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (!string.IsNullOrEmpty(ip))
        {
            string[] ipRange = ip.Split(',');
            int le = ipRange.Length - 1;
            result = ipRange[0];
        }
        else
        {
            result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        return result;
    }
    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //if ((DataTable)Session["CertificateTb2"] != null)
            //{
            //    Session["CertificateTb2"] = null;
            //}
            string Role_Code = Session["Role_Code"].ToString().Trim().TrimStart();
            if (CheckBoxList1.SelectedValue == "1")
            {
                trquery.Visible = false;
                trRecommendAmount.Visible = true;
                trReject.Visible = false;
                trsscinspectiondate.Visible = false;
                //if (ViewState["DisignationLoad"].ToString() == "SA")
                //{
                // gvreconbyjdjd

                if (Role_Code.Trim() == "JD")
                {
                    if (Role_Code.Trim() == "JD" && ddlstaire.SelectedIndex.ToString() == "1" && ddlstaire.SelectedItem.Value.ToString() == "6")
                    {
                        if (lblsector.Text == "Manufacture")
                        {
                            trLandBuidlingMachinery.Visible = true;
                            txtLandJD.Enabled = true;
                            txtBuildingJD.Enabled = true;
                            txtPnMJD.Enabled = true;
                        }
                    }

                    if (gvDDrcrecommended.Rows.Count > 0)
                    {
                        foreach (GridViewRow gvrow in gvDDrcrecommended.Rows)
                        {
                            int rowIndex = gvrow.RowIndex;
                            string EnterperIncentiveID = ((Label)gvrow.FindControl("lblMstIncentiveId")).Text.ToString();
                            string txtrecomandedamountnew = ((TextBox)gvrow.FindControl("txtrecomandedamount")).Text.ToString();
                            if (ddlstaire.SelectedValue == EnterperIncentiveID)
                            {
                                txtRecommendedAmount.Text = txtrecomandedamountnew;
                            }
                        }
                    }
                    else if (gvadrecommended.Rows.Count > 0)
                    {
                        foreach (GridViewRow gvrow in gvadrecommended.Rows)
                        {
                            int rowIndex = gvrow.RowIndex;
                            string EnterperIncentiveID = ((Label)gvrow.FindControl("lblMstIncentiveId")).Text.ToString();
                            string txtrecomandedamountnew = ((TextBox)gvrow.FindControl("txtrecomandedamount")).Text.ToString();
                            if (ddlstaire.SelectedValue == EnterperIncentiveID)
                            {
                                txtRecommendedAmount.Text = txtrecomandedamountnew;
                            }
                        }
                    }

                    else
                    {
                        foreach (GridViewRow gvrow in gvinspectionOfficer.Rows)
                        {
                            int rowIndex = gvrow.RowIndex;
                            string EnterperIncentiveID = ((Label)gvrow.FindControl("lblMstIncentiveId")).Text.ToString();
                            string txtrecomandedamountnew = ((TextBox)gvrow.FindControl("txtrecomandedamount")).Text.ToString();
                            if (ddlstaire.SelectedValue == EnterperIncentiveID)
                            {
                                txtRecommendedAmount.Text = txtrecomandedamountnew;
                            }
                        }
                    }

                }
                if (Role_Code.Trim() == "ADDL")
                {

                    trLandBuidlingMachinery.Visible = false;
                    txtLandJD.Enabled = false;
                    txtBuildingJD.Enabled = false;
                    txtPnMJD.Enabled = false;

                    string SVCStatus = "";
                    if (Request.QueryString["SVCStatus"] != null)
                    {
                        SVCStatus = Request.QueryString["SVCStatus"].ToString();
                    }
                    if (SVCStatus == "PRESVC")
                    {
                        foreach (GridViewRow gvrow in gvreconbyjdjd.Rows)
                        {
                            int rowIndex = gvrow.RowIndex;
                            string EnterperIncentiveID = ((Label)gvrow.FindControl("lblMstIncentiveId")).Text.ToString();
                            string txtrecomandedamountnew = gvrow.Cells[2].Text;
                            if (ddlstaire.SelectedValue == EnterperIncentiveID)
                            {
                                txtRecommendedAmount.Text = txtrecomandedamountnew;
                            }
                        }
                    }
                    if (SVCStatus == "POSTSVC")
                    {
                        foreach (GridViewRow gvrow in gvpresvc.Rows)
                        {
                            int rowIndex = gvrow.RowIndex;
                            string EnterperIncentiveID = ((Label)gvrow.FindControl("lblMstIncentiveId")).Text.ToString();
                            string txtrecomandedamountnew = gvrow.Cells[2].Text;
                            if (ddlstaire.SelectedValue == EnterperIncentiveID)
                            {
                                txtRecommendedAmount.Text = txtrecomandedamountnew;
                            }
                        }
                    }
                    if (SVCStatus == "POSTSLC")
                    {
                        foreach (GridViewRow gvrow in gvpostsvc.Rows)
                        {
                            int rowIndex = gvrow.RowIndex;
                            string EnterperIncentiveID = ((Label)gvrow.FindControl("Label10")).Text.ToString();
                            string txtrecomandedamountnew = gvrow.Cells[2].Text;
                            if (ddlstaire.SelectedValue == EnterperIncentiveID)
                            {
                                txtRecommendedAmount.Text = txtrecomandedamountnew;
                            }
                        }
                    }

                }
                //}
                //else if (ViewState["DisignationLoad"].ToString() == "SA")
                //{ 

                //}
            }
            else if (CheckBoxList1.SelectedValue == "2" || CheckBoxList1.SelectedValue == "5" || CheckBoxList1.SelectedValue == "6" || CheckBoxList1.SelectedValue == "8")
            {

                trquery.Visible = true;
                trRecommendAmount.Visible = false;
                trReject.Visible = false;
                trLandBuidlingMachinery.Visible = false;
                txtLandJD.Enabled = false;
                txtBuildingJD.Enabled = false;
                txtPnMJD.Enabled = false;

                if (CheckBoxList1.SelectedValue == "2")
                {
                    if (gvDDQuery.Rows.Count > 0)
                    {
                        foreach (GridViewRow gvrow in gvDDQuery.Rows)
                        {
                            int rowIndex = gvrow.RowIndex;
                            string EnterperIncentiveID = ((Label)gvrow.FindControl("Label27")).Text.ToString();
                            string txtrecomandedamountnew = ((Label)gvrow.FindControl("Label28")).Text.ToString();
                            string status = ((Label)gvrow.FindControl("Label29")).Text.ToString();

                            if (ddlstaire.SelectedItem.Text == EnterperIncentiveID)
                            {
                                if (rowIndex == 0)
                                {
                                    if (status == "Query")
                                    {
                                        txtincentiveremarks.Text = txtrecomandedamountnew;
                                    }
                                }


                            }
                        }
                    }
                    else if (GVADQueryStatus.Rows.Count > 0)
                    {
                        foreach (GridViewRow gvrow in GVADQueryStatus.Rows)
                        {
                            int rowIndex = gvrow.RowIndex;
                            string EnterperIncentiveID = ((Label)gvrow.FindControl("Label23")).Text.ToString();
                            string txtrecomandedamountnew = ((Label)gvrow.FindControl("Label25")).Text.ToString();
                            string status = ((Label)gvrow.FindControl("Label26")).Text.ToString();

                            if (ddlstaire.SelectedItem.Text == EnterperIncentiveID)
                            {
                                if (rowIndex == 0)
                                {
                                    if (status == "Query")
                                    {
                                        txtincentiveremarks.Text = txtrecomandedamountnew;
                                    }
                                }


                            }
                        }
                    }
                }
                if (CheckBoxList1.SelectedValue == "5")
                {
                    if (Role_Code.Trim() == "JD")
                    {
                        Label2.Text = "SSC Inspection Remarks";
                    }

                    if (Role_Code.Trim() == "ADDL")
                    {
                        trquery.Visible = false;
                        trsscinspectiondate.Visible = true;
                    }
                    else
                    {
                        trsscinspectiondate.Visible = false;
                    }
                }
                else if (CheckBoxList1.SelectedValue == "6")
                {
                    if (Role_Code.Trim() == "JD")
                    {
                        Label2.Text = "Return Reason";
                    }
                }
                else
                {
                    trsscinspectiondate.Visible = false;
                }
                if (CheckBoxList1.SelectedValue == "8")
                {
                    if (Request.QueryString["Sts"].ToString() == "23")
                    {
                        if (Role_Code.Trim() == "JD")
                        {
                            //Label2.Text = "SSC Inspection Remarks";
                        }

                        if (Role_Code.Trim() == "ADDL")
                        {
                            trquery.Visible = true;
                            Label2.Text = "SSC Completion Remarks";
                            trsscreport.Visible = true;
                            trsscinspectiondate.Visible = false;
                        }
                        else
                        {
                            trsscreport.Visible = false;
                        }
                    }
                }

            }

            else if (CheckBoxList1.SelectedValue == "7")
            {
                trquery.Visible = true;
                trRecommendAmount.Visible = false;
                trReject.Visible = false;
                trLandBuidlingMachinery.Visible = false;
                txtLandJD.Enabled = false;
                txtBuildingJD.Enabled = false;
                txtPnMJD.Enabled = false;


                if (gvDDrcrecommended.Rows.Count > 0)
                {
                    foreach (GridViewRow gvrow in gvDDrcrecommended.Rows)
                    {
                        int rowIndex = gvrow.RowIndex;
                        string EnterperIncentiveID = ((Label)gvrow.FindControl("Label27")).Text.ToString();
                        string txtrecomandedamountnew = ((Label)gvrow.FindControl("Label28")).Text.ToString();
                        string status = ((Label)gvrow.FindControl("Label29")).Text.ToString();

                        if (ddlstaire.SelectedItem.Text == EnterperIncentiveID)
                        {
                            if (rowIndex == 0)
                            {
                                if (status == "Query")
                                {
                                    txtincentiveremarks.Text = txtrecomandedamountnew;
                                }
                            }


                        }
                    }
                }
                else if (GVADQueryStatus.Rows.Count > 0)
                {
                    foreach (GridViewRow gvrow in GVADQueryStatus.Rows)
                    {
                        int rowIndex = gvrow.RowIndex;
                        string EnterperIncentiveID = ((Label)gvrow.FindControl("Label23")).Text.ToString();
                        string txtrecomandedamountnew = ((Label)gvrow.FindControl("Label25")).Text.ToString();
                        string status = ((Label)gvrow.FindControl("Label26")).Text.ToString();

                        if (ddlstaire.SelectedItem.Text == EnterperIncentiveID)
                        {
                            if (rowIndex == 0)
                            {
                                if (status == "Query")
                                {
                                    txtincentiveremarks.Text = txtrecomandedamountnew;
                                }
                            }


                        }
                    }
                }
            }



            else if (CheckBoxList1.SelectedValue == "3")
            {
                trsscinspectiondate.Visible = false;
                trquery.Visible = false;
                trRecommendAmount.Visible = false;
                trReject.Visible = true;
                txtRejectreason.Text = "";
                trLandBuidlingMachinery.Visible = false;
                txtLandJD.Enabled = false;
                txtBuildingJD.Enabled = false;
                txtPnMJD.Enabled = false;
            }

            // added on 11.01.2018 for application hold by COI 
            else if (CheckBoxList1.SelectedValue == "4")
            {
                trsscinspectiondate.Visible = false;
                Label14.Text = "Abeyance Remarks";
                trquery.Visible = false;
                trRecommendAmount.Visible = false;
                trReject.Visible = true;
                txtRejectreason.Text = "";
            }


            // collapsegmqueryhistorynew.Attributes.Add("class", "panel-collapse in");



            // collapsegmqueryhistorynew.Attributes.Add("class", "panel-collapse in");
            CheckBoxList1.Focus();
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        try
        {
            Button6.Visible = false;



            //  Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Inspection Report Submitted Sucessfully');", true);
            DataTable tblfullshap = new DataTable();
            tblfullshap.Columns.Add("IncentiveName", typeof(string));
            tblfullshap.Columns.Add("MstIncentiveId", typeof(string));
            tblfullshap.Columns.Add("EnterperIncentiveID", typeof(string));
            // tblfullshap.Columns.Add("FullShape", typeof(string));

            DataTable tblNotfullshap = new DataTable();
            tblNotfullshap.Columns.Add("IncentiveName", typeof(string));
            tblNotfullshap.Columns.Add("MstIncentiveId", typeof(string));
            tblNotfullshap.Columns.Add("EnterperIncentiveID", typeof(string));
            tblNotfullshap.Columns.Add("Query", typeof(string));

            DataTable tblRejected = new DataTable();
            tblRejected.Columns.Add("IncentiveName", typeof(string));
            tblRejected.Columns.Add("MstIncentiveId", typeof(string));
            tblRejected.Columns.Add("EnterperIncentiveID", typeof(string));
            tblRejected.Columns.Add("RejectedReason", typeof(string));




            int selectedcount = 0;
            foreach (GridViewRow gvrow in grdDetails.Rows)
            {
                int rowIndex = gvrow.RowIndex;
                string EnterperIncentiveID = ((Label)gvrow.FindControl("lblIncentiveID")).Text.ToString();
                string IncentiveName = gvrow.Cells[1].Text;
                string MstIncentiveId = ((Label)gvrow.FindControl("lblMstIncentiveId")).Text.ToString();
                string FullShape = ((RadioButtonList)gvrow.FindControl("rdbyesno")).SelectedValue;
                RadioButtonList ControlFullShape = ((RadioButtonList)gvrow.FindControl("rdbyesno"));

                if (FullShape == "Y")
                {
                    DataRow Row;
                    Row = tblfullshap.NewRow();
                    Row["IncentiveName"] = IncentiveName;
                    Row["EnterperIncentiveID"] = EnterperIncentiveID;
                    Row["MstIncentiveId"] = MstIncentiveId;
                    tblfullshap.Rows.Add(Row);
                    selectedcount = selectedcount + 1;
                }
                else if (FullShape == "N" && ControlFullShape.Enabled == true)
                {
                    DataRow Row;
                    Row = tblNotfullshap.NewRow();
                    Row["IncentiveName"] = IncentiveName;
                    Row["EnterperIncentiveID"] = EnterperIncentiveID;
                    Row["MstIncentiveId"] = MstIncentiveId;
                    Row["Query"] = "";
                    tblNotfullshap.Rows.Add(Row);
                    selectedcount = selectedcount + 1;
                }
                else if (FullShape == "R" && ControlFullShape.Enabled == true)
                {
                    DataRow Row;
                    Row = tblRejected.NewRow();
                    Row["IncentiveName"] = IncentiveName;
                    Row["EnterperIncentiveID"] = EnterperIncentiveID;
                    Row["MstIncentiveId"] = MstIncentiveId;
                    Row["RejectedReason"] = "";
                    tblRejected.Rows.Add(Row);
                    selectedcount = selectedcount + 1;
                }
                else if (ControlFullShape.Enabled == false && FullShape == "N")
                {
                    selectedcount = selectedcount + 1;
                }
            }
            if (grdDetails.Rows.Count != selectedcount)
            {
                string message = "alert('Kindly Check whether the incentive full shape or not')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                //lblmsg0.Text = "<font color='red'>Kindly Check whether the incentive full shap or not</font>";
                //success.Visible = false;
                //Failure.Visible = true;
                //lblmsg0.Focus();
                return;
            }

            GridView1.DataSource = tblfullshap;
            GridView1.DataBind();

            GridView2.DataSource = tblNotfullshap;
            GridView2.DataBind();

            GridView4.DataSource = tblRejected;
            GridView4.DataBind();

            trddlDeptname.Visible = false;
            trSubmitQuery.Visible = false;
            trGmReject.Visible = false;

            if (GridView1.Rows.Count > 0)
            {
                GridView1.Visible = true;
                trddlDeptname.Visible = true;
                //tr_verifyDiv.Visible = true; commented by madhuri on 01/10/2022
                tr_verifyDiv.Visible = false;
                chkverifyallDoc0_CheckedChanged(sender, e);
            }
            if (GridView2.Rows.Count > 0)
            {
                GridView2.Visible = true;
                trSubmitQuery.Visible = true;
            }
            if (GridView4.Rows.Count > 0)
            {
                GridView4.Visible = true;
                trGmReject.Visible = true;
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void btnsaveinspectingofficer_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlDeptname.SelectedItem.Value != "--Select--")
            {
                int returnValuenew = 0;
                foreach (GridViewRow gvrow in GridView1.Rows)
                {
                    string intApplicationid, Deptname, Modified_by, EMiUdyogAadhar, SentFrom, Status, MstIncentiveId, txtIncQuery, txtinspectiondate, Deptname1new;
                    intApplicationid = ((Label)gvrow.FindControl("lblIncentiveID")).Text.ToString();
                    MstIncentiveId = ((Label)gvrow.FindControl("lblMstIncentiveId")).Text.ToString();
                    Deptname = ddlDeptname.SelectedValue.ToString();
                    EMiUdyogAadhar = txtudyogAadharNo.Text;
                    Modified_by = Session["uid"].ToString();
                    SentFrom = Session["User_Code"].ToString();

                    Status = "3";
                    if (ViewState["DisignationLoad"].ToString().Trim() == "GM")
                    {
                        //int returnValue = Gen.UpdateInspectorNameNewIncTypeNew(intApplicationid, Deptname, Modified_by, EMiUdyogAadhar, SentFrom, Status, MstIncentiveId, getclientIP());
                        int returnValue = Gen.UpdateInspectorNameNewIncTypeNew(intApplicationid, Deptname, Modified_by, EMiUdyogAadhar, SentFrom, Status, MstIncentiveId, getclientIP(), ViewState["checkVerifyinsp"].ToString());
                        returnValuenew = returnValue;
                        bindGMGrids(MstIncentiveId);
                        GridView1.Visible = false;
                        trddlDeptname.Visible = false;
                    }
                    //lblmsg.Text = "<font color='green'>File Assigned to inspecting officer Successfully..!</font>";
                    //success.Visible = true;
                    //Failure.Visible = false;
                    lblmsg.Focus();
                    //  Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('File Assigned to inspecting officer Successfully');", true);
                    string message = "alert('File Assigned to inspecting officer Successfully')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            else
            {
                string message = "alert('Please Select Assigned to inspecting officer')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }





        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        try
        {
            int errorCount = 0;

            foreach (GridViewRow gvrow in GridView2.Rows)
            {
                string txtIncQuery = ((TextBox)gvrow.FindControl("txtIncQueryFnl")).Text.ToString();
                if (txtIncQuery.Trim() == "") { errorCount = errorCount + 1; }
            }

            if (errorCount == 0)
            {

                string Incentiveslist = "";
                string intApplicationidtop = "";
                int countno = 1;
                foreach (GridViewRow gvrow in GridView2.Rows)
                {
                    string intApplicationid, Deptname, Modified_by, EMiUdyogAadhar, SentFrom, Status, MstIncentiveId, txtIncQuery, txtinspectiondate, Deptname1new;

                    intApplicationid = ((Label)gvrow.FindControl("lblIncentiveID")).Text.ToString();
                    intApplicationidtop = intApplicationid;
                    MstIncentiveId = ((Label)gvrow.FindControl("lblMstIncentiveId")).Text.ToString();
                    txtIncQuery = ((TextBox)gvrow.FindControl("txtIncQueryFnl")).Text.ToString();
                    Modified_by = Session["uid"].ToString();
                    SentFrom = Session["User_Code"].ToString();
                    Status = "3";

                    if (ViewState["DisignationLoad"].ToString().Trim() == "GM")
                    {
                        int incRtrVal = Gen.insertInctveQueryResponsedataNew(intApplicationid, txtIncQuery, Modified_by, MstIncentiveId, getclientIP());

                        bindGMGrids("0");
                        Button7.Visible = false;
                        string IncentiveName = gvrow.Cells[1].Text;
                        try
                        {
                            SendSmsEmail(txtIncQuery, IncentiveName);
                        }
                        catch (Exception ex)
                        {
                            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
                        }
                    }
                }

                string message = "alert('Query Submitted Successfully')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                trgmtoenterquery.Visible = true;
                hplink.NavigateUrl = "ProformaQueryRaiseShortFallLetterGMtoApplicant.aspx?incentiveid=" + intApplicationidtop;

            }
            else
            {
                string message = "alert('Please Enter Query')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

            }




        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    public void SendSmsEmail(string querydesc, string incentivename)
    {
        try
        {
            DataSet dsAppliedIncentives = new DataSet();
            string UnitName = "", UnitMobileNo = "", UnitEmail = "", ApplicantName = "", DistrictName = "", QueryRaisedDate = "";

            UnitName = txtUnitname1.Text;
            ApplicantName = txtApplicantName1.Text;
            UnitEmail = txtunitemailid1.Text;
            UnitMobileNo = txtunitmobileno1.Text;
            DistrictName = ddldistrictunit1.Text;
            QueryRaisedDate = DateTime.Now.ToString("dd/MM/yyyy");

            string nameuid = UnitEmail.Replace("@", "(at)");
            try
            {
                string querydays = ". If you fail to furnish the information within 45 Days from the date of query raise the application will be rejected.";
                if(hdnMSMEApplied.Value=="Y" && hdnScheme.Value!= "TFAP")
                {
                    if((hdnCaste.Value=="1" || hdnCaste.Value == "2" || hdnCaste.Value == "5") && hdnIsDifferentlyAbled.Value!="Y" )//general, OBC, minority and Not PHC
                    {
                        querydays = ". If you fail to furnish the information within 90 Days from the date of query raise the application will be rejected.";
                    }
                    if (hdnCaste.Value == "3" || hdnCaste.Value == "4" || hdnIsDifferentlyAbled.Value == "Y") //SC, ST, PHC
                    {
                        querydays = ". Please respond to the query.";
                    }
                }
                if (Session["Role_Code"].ToString() == "JD")
                {
                    cmf.SendMailIncentive(UnitEmail, "Dear " + UnitName + ", Query is raised for Your incentives application on " + QueryRaisedDate + ", and Query raised incentives : " + incentivename + ", and query description is  " + querydesc + querydays+ " <br /> Thank You, JD-INCENTIVES, COI,<br />   Govt. of Telangana.");

                }
                else
                {
                    cmf.SendMailIncentive(UnitEmail, "Dear " + UnitName + ", Query is raised for Your incentives application on " + QueryRaisedDate + ", and Query raised incentives : " + incentivename + ", and query description is  " + querydesc + querydays+" <br /> Thank You, GM, DIC -" + DistrictName + ",<br />  Govt. of Telangana.");

                }
                // cmf.SendMailIncentive(UnitEmail, "Dear " + UnitName + ", Query is raised for Your incentives application on " + QueryRaisedDate + ", and Query raised incentives : " + incentivename + ", and query description is  " + querydesc + ". If you fail to furnish the information within 45 Days from the date of query raise the application will be rejected. <br /> Thank You, GM, DIC -" + DistrictName + ",<br />  Govt. of Telangana.");

            }
            catch (Exception ex)
            {
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
            try
            {
                cmf.SendSingleSMSnew(UnitMobileNo, "Dear " + UnitName + ", Query is raised for Your incentives application on " + QueryRaisedDate + ", and Query raised incentives : " + incentivename + ",If you fail to furnish the information within 45 Days from the date of query raise the application will be rejected. A detail mail is sent to " + nameuid + "," + '\n' + "Thank You," + '\n' + "GM, DIC -" + DistrictName + "," + '\n' + "Govt. of Telangana.", "1007693722296639652");

            }
            catch (Exception ex)
            {
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    public string FillDetailsabc(DataSet ds)
    {
        string IncentID = "";
        try
        {
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    divCommonAppli.Visible = true;
                    IncentID = ds.Tables[0].Rows[0]["IncentveID"].ToString();

                    txtudyogAadharNo1.Text = ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
                    txtUnitname1.Text = ds.Tables[0].Rows[0]["UnitName"].ToString();
                    txtApplicantName1.Text = ds.Tables[0].Rows[0]["ApplciantName"].ToString();
                    txtPanNumber1.Text = ds.Tables[0].Rows[0]["PanNo"].ToString();
                    txtTinNumber1.Text = ds.Tables[0].Rows[0]["TinNO"].ToString();

                    ddlCategory1.Text = ds.Tables[0].Rows[0]["Category"].ToString();
                    ddltypeofOrg1.Text = ds.Tables[0].Rows[0]["OrgType2"].ToString();

                    ddlindustryStatus1.Text = ds.Tables[0].Rows[0]["IdsustryStatus"].ToString();
                    if (ddlindustryStatus1.Text == "Expansion")
                    {
                        TRINDUSEXPANTYPE.Visible = true;
                        lblindusexpantype.Text = ds.Tables[0].Rows[0]["IndustryExpanType"].ToString();
                    }

                    txtDateofCommencement1.Text = ds.Tables[0].Rows[0]["DCP"].ToString();
                    lblSpinningMill.Text = ds.Tables[0].Rows[0]["isSpinningFlag"].ToString();

                    rblCaste1.Text = ds.Tables[0].Rows[0]["Caste"].ToString();
                    rblCaste1.Text = ds.Tables[0].Rows[0]["SocialStatus"].ToString();

                    ddldistrictunit1.Text = ds.Tables[0].Rows[0]["UnitDistName"].ToString();
                    ddlUnitMandal1.Text = ds.Tables[0].Rows[0]["UNITMANDAL"].ToString();
                    ddlVillageunit1.Text = ds.Tables[0].Rows[0]["UNITVILLAGE"].ToString(); ;
                    txtunitaddhno1.Text = ds.Tables[0].Rows[0]["UnitHNO"].ToString();
                    txtstreetunit1.Text = ds.Tables[0].Rows[0]["UnitStreet"].ToString();
                    txtunitmobileno1.Text = ds.Tables[0].Rows[0]["UnitMObileNo"].ToString();
                    txtunitemailid1.Text = ds.Tables[0].Rows[0]["UnitEmail"].ToString();

                    ddldistrictoffc1.Text = ds.Tables[0].Rows[0]["OFFCDISTNAME"].ToString();
                    ddloffcmandal1.Text = ds.Tables[0].Rows[0]["OFFCMANDAL"].ToString();
                    ddlvilloffc1.Text = ds.Tables[0].Rows[0]["OFFCVILLAGE"].ToString();
                    txtoffaddhnno1.Text = ds.Tables[0].Rows[0]["OffcHNO"].ToString();
                    txtstreetoffice1.Text = ds.Tables[0].Rows[0]["OffcStreet"].ToString();
                    txtOffcMobileNO1.Text = ds.Tables[0].Rows[0]["OffcMobileNO"].ToString();
                    txtOffcEmail1.Text = ds.Tables[0].Rows[0]["OffcEmail"].ToString();

                    if (ds.Tables[0].Rows[0]["casteGenderGmUpdate"] != null)
                    {
                        if (ds.Tables[0].Rows[0]["casteGenderGmUpdate"].ToString() == "Y")
                        {
                            rdbCaste.SelectedValue = ds.Tables[0].Rows[0]["caste_GM"].ToString();
                            rdbGender.SelectedValue = ds.Tables[0].Rows[0]["gender_GM"].ToString();
                            rdbCategory.SelectedValue = ds.Tables[0].Rows[0]["category_GM"].ToString();
                            rdbEnterprise.SelectedValue = ds.Tables[0].Rows[0]["enterprise_GM"].ToString();
                            rdbSector.SelectedValue = ds.Tables[0].Rows[0]["sector_GM"].ToString();
                            rdbCaste.Enabled = false;
                            rdbCaste.CssClass = "disabled-control";
                            rdbGender.Enabled = false;
                            rdbGender.CssClass = "disabled-control";
                            rdbCategory.Enabled = false;
                            rdbCategory.CssClass = "disabled-control";
                            rdbEnterprise.Enabled = false;
                            rdbEnterprise.CssClass = "disabled-control";
                            rdbSector.Enabled = false;
                            rdbSector.CssClass = "disabled-control";
                            casteGenderGmUpdate = "Y";
                            ViewState["casteGenderGmUpdate"] = casteGenderGmUpdate;

                        }
                    }


                    gvLOA.DataSource = null;
                    gvLOA.DataBind();
                    gvLOA.DataSource = ds.Tables[1];
                    gvLOA.DataBind();
                    HDNINDUSTRYSTATUS.Value = ds.Tables[0].Rows[0]["IdsustryStatus1"].ToString();

                    if (ds.Tables[0].Rows[0]["IdsustryStatus1"].ToString() == "1")
                    {
                        tr1.Visible = true;
                        tr3.Visible = false;
                        txtlandexistingNew.Text = ds.Tables[0].Rows[0]["ExistEnterpriseLand"].ToString();
                        txtbuildingexistingNew.Text = ds.Tables[0].Rows[0]["ExistEnterpriseBuilding"].ToString();
                        txtplantexistingNew.Text = ds.Tables[0].Rows[0]["ExistEnterprisePlantMachinery"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["IdsustryStatus1"].ToString() == "2" || ds.Tables[0].Rows[0]["IdsustryStatus1"].ToString() == "3")
                    {
                        tr3.Visible = true;
                        tr1.Visible = false;

                        txteeploa.Text = ds.Tables[0].Rows[0]["ExistingEnterpriseLOA"].ToString();
                        txteepinscap.Text = ds.Tables[0].Rows[0]["ExistingInstalledCapacityinEnter"].ToString();
                        ddleepinscap.Text = ds.Tables[0].Rows[0]["eepinscapUnit"].ToString();
                        txteeppercentage.Text = ds.Tables[0].Rows[0]["ExistingPercentageincreaseunderExpansionORDiversification"].ToString();
                        txtedploa.Text = ds.Tables[0].Rows[0]["ExpansionDiversificationLOA"].ToString();
                        txtedpinscap.Text = ds.Tables[0].Rows[0]["ExpanORDiversInstalledCapacityinEnter"].ToString();
                        ddledpinscap.Text = ds.Tables[0].Rows[0]["edpinscapUnit"].ToString();
                        txtedppercentage.Text = ds.Tables[0].Rows[0]["ExpanORDiversPercentIncreaseunderExpansionORDiversification"].ToString();

                        txtlandexisting.Text = ds.Tables[0].Rows[0]["ExistEnterpriseLand"].ToString();
                        txtlandexpandiver.Text = ds.Tables[0].Rows[0]["ExpansionDiversificationLand"].ToString();
                        txtlandpercentage.Text = ds.Tables[0].Rows[0]["LandFixedCapitalInvestPercentage"].ToString();

                        txtbuildingexisting.Text = ds.Tables[0].Rows[0]["ExistEnterpriseBuilding"].ToString();
                        txtbuildingexpandiver.Text = ds.Tables[0].Rows[0]["ExpDiversBuilding"].ToString();
                        txtbuildingpercentage.Text = ds.Tables[0].Rows[0]["BuildingFixedCapitalInvestPercentage"].ToString();

                        txtplantexisting.Text = ds.Tables[0].Rows[0]["ExistEnterprisePlantMachinery"].ToString();
                        txtplantexpandiver.Text = ds.Tables[0].Rows[0]["ExpDiversPlantMachinery"].ToString();
                        txtplantpercentage.Text = ds.Tables[0].Rows[0]["PlantMachFixedCapitalInvestPercentage"].ToString();
                    }
                    // grid view code binding  // for directors/ proprietors
                    GridViewdirectors.DataSource = null;
                    GridViewdirectors.DataBind();
                    GridViewdirectors.DataSource = ds.Tables[2];
                    GridViewdirectors.DataBind();

                    ddlPowerStatus.Text = ds.Tables[0].Rows[0]["PowerType"].ToString();

                    if (ddlPowerStatus.Text == "New Industry")
                    {
                        //trpower1.Visible = true;
                        //trpower2.Visible = false;
                        txtNewPowerReleaseDate.Text = ds.Tables[0].Rows[0]["PowerReleaseDate"].ToString();
                        txtNewContractedLoad.Text = ds.Tables[0].Rows[0]["NewConnectedLoad"].ToString();
                        txtNewConnectedLoad.Text = ds.Tables[0].Rows[0]["NewContractedLoad"].ToString();
                        txtServiceConnectionNumberNew.Text = ds.Tables[0].Rows[0]["ServiceConnectionNO"].ToString();
                    }
                    if (ddlPowerStatus.Text == "Expansion/Diversification")
                    {
                        //trpower1.Visible = false;
                        //trpower2.Visible = true;
                        lblexistingpower.Text = "Existing Enterprise production details";
                        lblexpandiverpower.Text = "Expansion / Diversification details";

                        txtExistPowerReleaseDate.Text = ds.Tables[0].Rows[0]["ExistingPowerReleaseDate"].ToString();
                        txtExistContractedLoad.Text = ds.Tables[0].Rows[0]["ExistingContractedLoad"].ToString();
                        txtExistConnectedLoad.Text = ds.Tables[0].Rows[0]["ExistingConnectedLoad"].ToString();
                        txtServiceConnectionNumberExist.Text = ds.Tables[0].Rows[0]["ExistingServiceConnectionNO"].ToString();
                        txtExpanPowerReleaseDate.Text = ds.Tables[0].Rows[0]["ExpanDiverPowerReleaseDate"].ToString();
                        txtExpanContractedLoad.Text = ds.Tables[0].Rows[0]["ExpanDiverContractedLoad"].ToString();
                        txtExpanConnectedLoad.Text = ds.Tables[0].Rows[0]["ExpanDiverConnectedLoad"].ToString();
                        txtServiceConnectionNumberExpan.Text = ds.Tables[0].Rows[0]["ExpanDiverServiceConnectionNO"].ToString();
                    }

                    txtstaffMale.Text = ds.Tables[0].Rows[0]["ManagementStaffMale"].ToString();
                    txtStaffFemale.Text = ds.Tables[0].Rows[0]["ManagementStaffFemale"].ToString();
                    txtSuprMale.Text = ds.Tables[0].Rows[0]["SupervisoryMale"].ToString();
                    txtSuperFemale.Text = ds.Tables[0].Rows[0]["SupervisoryFemale"].ToString();
                    txtSkilledWorkersMale.Text = ds.Tables[0].Rows[0]["SkilledWorkersFemale"].ToString();
                    txtSkilledWorkersFemale.Text = ds.Tables[0].Rows[0]["SkilledWorkersFemale"].ToString();
                    txtSemiSkilledWorkersMale.Text = ds.Tables[0].Rows[0]["SkilledWorkersFemale"].ToString();
                    txtSemiSkilledWorkersFemale.Text = ds.Tables[0].Rows[0]["SkilledWorkersFemale"].ToString();

                    //txtprjfinance.Text = ds.Tables[0].Rows[0]["ProjectFinance"].ToString();
                    txtTermloan.Text = ds.Tables[0].Rows[0]["TermLoanApplDate"].ToString();
                    txtnmofinstitution.Text = ds.Tables[0].Rows[0]["InstitutionName"].ToString();
                    txtsactionedloan.Text = ds.Tables[0].Rows[0]["TermLoanSancRefNo"].ToString();
                    txtdatesanctioned.Text = ds.Tables[0].Rows[0]["TermLoanApplDate"].ToString();

                    // Name of Assets binding

                    if (ds != null && ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
                    {
                        if (ds.Tables[3].Rows[0]["LandApprovedProjectCost"].ToString() != "")
                            txtLand2.Text = ds.Tables[3].Rows[0]["LandApprovedProjectCost"].ToString();
                        else
                            txtLand2.Text = "0.00";
                        if (ds.Tables[3].Rows[0]["LandLoanSactioned"].ToString() != "")
                            txtLand3.Text = ds.Tables[3].Rows[0]["LandLoanSactioned"].ToString();
                        else
                            txtLand3.Text = "0.00";
                        if (ds.Tables[3].Rows[0]["LandPromotersEquity"].ToString() != "")
                            txtLand4.Text = ds.Tables[3].Rows[0]["LandPromotersEquity"].ToString();
                        else
                            txtLand4.Text = "0.00";
                        if (ds.Tables[3].Rows[0]["LandLoanAmountReleased"].ToString() != "")
                            txtLand5.Text = ds.Tables[3].Rows[0]["LandLoanAmountReleased"].ToString();
                        else
                            txtLand5.Text = "0.00";
                        if (ds.Tables[3].Rows[0]["LandAssetsValuebyFinInstitution"].ToString() != "")
                            txtLand6.Text = ds.Tables[3].Rows[0]["LandAssetsValuebyFinInstitution"].ToString();
                        else
                            txtLand6.Text = "0.00";
                        if (ds.Tables[3].Rows[0]["LandAssetsValuebyCA"].ToString() != "")
                            txtLand7.Text = ds.Tables[3].Rows[0]["LandAssetsValuebyCA"].ToString();
                        else
                            txtLand7.Text = "0.00";


                        if (ds.Tables[3].Rows[0]["BuildingApprovedProjectCost"].ToString() != "")
                            txtBuilding2.Text = ds.Tables[3].Rows[0]["BuildingApprovedProjectCost"].ToString();
                        else
                            txtBuilding2.Text = "0.00";
                        if (ds.Tables[3].Rows[0]["BuildingLoanSactioned"].ToString() != "")
                            txtBuilding3.Text = ds.Tables[3].Rows[0]["BuildingLoanSactioned"].ToString();
                        else
                            txtBuilding3.Text = "0.00";
                        if (ds.Tables[3].Rows[0]["BuildingPromotersEquity"].ToString() != "")
                            txtBuilding4.Text = ds.Tables[3].Rows[0]["BuildingPromotersEquity"].ToString();
                        else
                            txtBuilding4.Text = "0.00";
                        if (ds.Tables[3].Rows[0]["BuildingLoanAmountReleased"].ToString() != "")
                            txtBuilding5.Text = ds.Tables[3].Rows[0]["BuildingLoanAmountReleased"].ToString();
                        else
                            txtBuilding5.Text = "0.00";
                        if (ds.Tables[3].Rows[0]["BuildingAssetsValuebyFinInstitution"].ToString() != "")
                            txtBuilding6.Text = ds.Tables[3].Rows[0]["BuildingAssetsValuebyFinInstitution"].ToString();
                        else
                            txtBuilding6.Text = "0.00";
                        if (ds.Tables[3].Rows[0]["BuildingAssetsValuebyCA"].ToString() != "")
                            txtBuilding7.Text = ds.Tables[3].Rows[0]["BuildingAssetsValuebyCA"].ToString();
                        else
                            txtBuilding7.Text = "0.00";


                        if (ds.Tables[3].Rows[0]["PlantMachineryApprovedProjectCost"].ToString() != "")
                            txtPM2.Text = ds.Tables[3].Rows[0]["PlantMachineryApprovedProjectCost"].ToString();
                        else
                            txtPM2.Text = "0.00";
                        if (ds.Tables[3].Rows[0]["PlantMachineryLoanSactioned"].ToString() != "")
                            txtPM3.Text = ds.Tables[3].Rows[0]["PlantMachineryLoanSactioned"].ToString();
                        else
                            txtPM3.Text = "0.00";
                        if (ds.Tables[3].Rows[0]["PlantMachineryPromotersEquity"].ToString() != "")
                            txtPM4.Text = ds.Tables[3].Rows[0]["PlantMachineryPromotersEquity"].ToString();
                        else
                            txtPM4.Text = "0.00";
                        if (ds.Tables[3].Rows[0]["PlantMachineryLoanAmountReleased"].ToString() != "")
                            txtPM5.Text = ds.Tables[3].Rows[0]["PlantMachineryLoanAmountReleased"].ToString();
                        else
                            txtPM5.Text = "0.00";
                        if (ds.Tables[3].Rows[0]["PlantMachineryAssetsValuebyFinInstitution"].ToString() != "")
                            txtPM6.Text = ds.Tables[3].Rows[0]["PlantMachineryAssetsValuebyFinInstitution"].ToString();
                        else
                            txtPM6.Text = "0.00";
                        if (ds.Tables[3].Rows[0]["PlantMachineryAssetsValuebyCA"].ToString() != "")
                            txtPM7.Text = ds.Tables[3].Rows[0]["PlantMachineryAssetsValuebyCA"].ToString();
                        else
                            txtPM7.Text = "0.00";

                        if (ds.Tables[3].Rows[0]["MachineryContingenciesApprovedProjectCost"].ToString() != "")
                            txtMCont2.Text = ds.Tables[3].Rows[0]["MachineryContingenciesApprovedProjectCost"].ToString();
                        else
                            txtMCont2.Text = "0.00";
                        if (ds.Tables[3].Rows[0]["MachineryContingenciesLoanSactioned"].ToString() != "")
                            txtMCont3.Text = ds.Tables[3].Rows[0]["MachineryContingenciesLoanSactioned"].ToString();
                        else
                            txtMCont3.Text = "0.00";
                        if (ds.Tables[3].Rows[0]["MachineryContingenciesPromotersEquity"].ToString() != "")
                            txtMCont4.Text = ds.Tables[3].Rows[0]["MachineryContingenciesPromotersEquity"].ToString();
                        else
                            txtMCont4.Text = "0.00";
                        if (ds.Tables[3].Rows[0]["MachineryContingenciesLoanAmountReleased"].ToString() != "")
                            txtMCont5.Text = ds.Tables[3].Rows[0]["MachineryContingenciesLoanAmountReleased"].ToString();
                        else
                            txtMCont5.Text = "0.00";
                        if (ds.Tables[3].Rows[0]["MachineryContingenciesAssetsValuebyFinInstitution"].ToString() != "")
                            txtMCont6.Text = ds.Tables[3].Rows[0]["MachineryContingenciesAssetsValuebyFinInstitution"].ToString();
                        else
                            txtMCont6.Text = "0.00";
                        if (ds.Tables[3].Rows[0]["MachineryContingenciesAssetsValuebyCA"].ToString() != "")
                            txtMCont7.Text = ds.Tables[3].Rows[0]["MachineryContingenciesAssetsValuebyCA"].ToString();
                        else
                            txtMCont7.Text = "0.00";


                        txtErec2.Text = ds.Tables[3].Rows[0]["ErectionApprovedProjectCost"].ToString();
                        txtErec3.Text = ds.Tables[3].Rows[0]["ErectionLoanSactioned"].ToString();
                        txtErec4.Text = ds.Tables[3].Rows[0]["ErectionPromotersEquity"].ToString();
                        txtErec5.Text = ds.Tables[3].Rows[0]["ErectionLoanAmountReleased"].ToString();
                        txtErec6.Text = ds.Tables[3].Rows[0]["ErectionAssetsValuebyFinInstitution"].ToString();
                        txtErec7.Text = ds.Tables[3].Rows[0]["ErectionAssetsValuebyCA"].ToString();

                        txtTFS2.Text = ds.Tables[3].Rows[0]["TechnicalfeasibilityApprovedProjectCost"].ToString();
                        txtTFS3.Text = ds.Tables[3].Rows[0]["TechnicalfeasibilityLoanSactioned"].ToString();
                        txtTFS4.Text = ds.Tables[3].Rows[0]["TechnicalfeasibilityPromotersEquity"].ToString();
                        txtTFS5.Text = ds.Tables[3].Rows[0]["TechnicalfeasibilityLoanAmountReleased"].ToString();
                        txtTFS6.Text = ds.Tables[3].Rows[0]["TechnicalfeasibilityAssetsValuebyFinInstitution"].ToString();
                        txtTFS7.Text = ds.Tables[3].Rows[0]["TechnicalfeasibilityAssetsValuebyCA"].ToString();

                        txtWC2.Text = ds.Tables[3].Rows[0]["WorkingCapitalApprovedProjectCost"].ToString();
                        txtWC3.Text = ds.Tables[3].Rows[0]["WorkingCapitalLoanSactioned"].ToString();
                        txtWC4.Text = ds.Tables[3].Rows[0]["WorkingCapitalPromotersEquity"].ToString();
                        txtWC5.Text = ds.Tables[3].Rows[0]["WorkingCapitalLoanAmountReleased"].ToString();
                        txtWC6.Text = ds.Tables[3].Rows[0]["WorkingCapitalAssetsValuebyFinInstitution"].ToString();
                        txtWC7.Text = ds.Tables[3].Rows[0]["WorkingCapitalAssetsValuebyCA"].ToString();
                    }

                    txtsecondhndmachine.Text = ds.Tables[0].Rows[0]["SecondHandMachVal"].ToString();
                    txtnewmachine.Text = ds.Tables[0].Rows[0]["NewMachVal"].ToString();
                    txtTotalvalue12.Text = ds.Tables[0].Rows[0]["Newand2ndlMachTotVal"].ToString();
                    txtpercentage12.Text = ds.Tables[0].Rows[0]["PercentageSHMValinTotMachVal"].ToString();
                    txtmachinepucr.Text = ds.Tables[0].Rows[0]["MachValPrchasedfromAPIDCorAPSFCBank"].ToString();
                    txttotal25.Text = ds.Tables[0].Rows[0]["TotalMachVal"].ToString();


                    txtAvldSubsidyScheme.Text = ds.Tables[0].Rows[0]["TotalSubsidyAlreadyAvailedScheme"].ToString();
                    txtAvldSubsidyAmt.Text = ds.Tables[0].Rows[0]["TotalSubsidyAlreadyAvailedAmount"].ToString();
                    txtSchemeEligible.Text = "";
                    txtAppldInvestSubsidy.Text = ds.Tables[0].Rows[0]["InvestimentSubsidy"].ToString();
                    txtAppldAddlAmtWomen.Text = ds.Tables[0].Rows[0]["AdditionalInvSubsidyForWomen"].ToString();
                    //txtAppldAddlAmtSCST.Text = ds.Tables[0].Rows[0]["AdditionalInvSubsidyForSCORST"].ToString();
                    //  txtAppldAddlAmtScheduldAreas.Text = ds.Tables[0].Rows[0]["AdditionalInvSubsidyForWomenInScheduledAreas"].ToString();
                    txtAppldTotInvestSubsidy.Text = ds.Tables[0].Rows[0]["TotalAppliedIncetives"].ToString();


                    if (ds.Tables[0].Rows[0]["AvailedSubsidyEarlier"].ToString() == "Y")
                    {
                        // ddlsubsidy.Text = "Yes";
                    }
                    else if (ds.Tables[0].Rows[0]["AvailedSubsidyEarlier"].ToString() == "N")
                    {
                        // ddlsubsidy.Text = "No";
                    }

                    //ddlBank.Text = ds.Tables[4].Rows[0]["BankName"].ToString();
                    //txtAccNumber.Text = ds.Tables[4].Rows[0]["AccNo"].ToString();
                    //txtBranchName.Text = ds.Tables[4].Rows[0]["BranchName"].ToString();
                    //txtIfscCode.Text = ds.Tables[4].Rows[0]["IFSCCode"].ToString();
                    //ddlPower.Text = ds.Tables[4].Rows[0]["WhetherPower"].ToString();

                    txtvatno.Text = ds.Tables[0].Rows[0]["VATNo"].ToString();
                    txtcstno.Text = ds.Tables[0].Rows[0]["CSTNo"].ToString();
                    txtCSTRegDate.Text = ds.Tables[0].Rows[0]["CSTRegDate"].ToString();
                    txtCSTRegAuthority.Text = ds.Tables[0].Rows[0]["CSTRegAuthority"].ToString();
                    txtCSTRegAuthAddress.Text = ds.Tables[0].Rows[0]["CSTRegAuthAddress"].ToString();
                    lblEMPartNo.Text = ds.Tables[0].Rows[0]["EMPartNo"].ToString();

                    return IncentID;
                }

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
        return IncentID;
    }

    public void BindForms(DataSet ds, string incentiveID)
    {

        try
        {
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        string MasterIncentiveId = ds.Tables[0].Rows[i]["IncentiveID"].ToString();

                        if (MasterIncentiveId == "6")  //IS
                        {
                            DataSet ds6 = new DataSet();
                            ds6 = Gen.GetIncentivesISdata(incentiveID, "6");
                            FilldataIS(ds6);
                            divInvestmenSubsidy.Visible = true;
                        }

                        if (MasterIncentiveId == "9") //STAMP DUTY
                        {
                            DataSet ds9 = new DataSet();
                            ds9 = Gen.GetIncentivesStampDutydata(incentiveID);
                            FilldataStampDuty(ds9);
                            divStampDuty.Visible = true;
                        }

                        if (MasterIncentiveId == "3")  // pOWER
                        {
                            DataSet ds3 = new DataSet();
                            ds3 = Gen.GetFormIIIIncentives(Convert.ToInt32(incentiveID));
                            FillDetailsPower(ds3);
                            divPowerCost.Visible = true;
                        }

                        if (MasterIncentiveId == "1")  // PV
                        {
                            DataSet ds1 = new DataSet();
                            ds1 = Gen.GetFormIVIncentives(Convert.ToInt32(incentiveID));
                            FillDetailsPavalaVaddi(ds1);
                            divPavalaVaddi.Visible = true;
                        }

                        if (MasterIncentiveId == "5")  // SALES TAX
                        {
                            DataSet ds5 = new DataSet();
                            ds5 = Gen.GetFormVIncentives(Convert.ToInt32(incentiveID));
                            FillDetailsSalesTax(ds5);
                            divSalesTax.Visible = true;
                        }

                        if (MasterIncentiveId == "11")  // qc
                        {
                            DataSet ds11 = new DataSet();
                            ds11 = Gen.GetIncentivesfrom4data(incentiveID);
                            FillDetailsQualityCertification(ds11);
                            divQualityCertification.Visible = true;
                        }

                        if (MasterIncentiveId == "10")  // seed cap
                        {

                        }

                        if (MasterIncentiveId == "4")
                        {
                            DataSet ds4 = new DataSet();
                            ds4 = Gen.GetIncentivesfrom8data(incentiveID);
                            FillDetailsCleanerProduction(ds4);
                            divCleanerProduction.Visible = true;

                        }

                        if (MasterIncentiveId == "8")
                        {
                            DataSet ds8 = new DataSet();
                            ds8 = Gen.GetIncentivesfrom9data(incentiveID);
                            FillDetailsSkillUpgradation(ds8);
                            divSkillupgradation.Visible = true;

                        }

                        if (MasterIncentiveId == "7")
                        {
                            DataSet ds7 = new DataSet();
                            ds7 = Gen.GetIncentivesIIDFunddata(incentiveID);
                            FilldataIIDFund(ds7);

                        }
                        if (MasterIncentiveId == "12")
                        {
                            DataSet ds12 = new DataSet();
                            ds12 = Gen.GetIncentivesAdvSubsidySCST(incentiveID);
                            FilldataSCSCT(ds12);
                            divSCAndST.Visible = true;
                        }
                        else if (MasterIncentiveId == "14") // Newly Added By shankar
                        {
                            DataSet ds9 = new DataSet();
                            ds9 = Gen.GetIncentivesStampDutydata1(incentiveID);
                            FilldataStampDuty1(ds9);
                            divStampDuty1.Visible = true;
                        }
                        else if (MasterIncentiveId == "15") // Newly Added By shankar
                        {
                            DataSet ds9 = new DataSet();
                            ds9 = Gen.GetIncentivesStampDutydata2(incentiveID);
                            FilldataStampDuty2(ds9);
                            divStampDuty2.Visible = true;
                        }
                        else if (MasterIncentiveId == "16") // Newly Added By shankar
                        {
                            DataSet ds9 = new DataSet();
                            ds9 = Gen.GetIncentivesStampDutydata3(incentiveID);
                            FilldataStampDuty3(ds9);
                            divStampDuty3.Visible = true;
                        }
                        else if (MasterIncentiveId == "17") // Newly Added By shankar
                        {
                            DataSet ds9 = new DataSet();
                            ds9 = Gen.GetIncentivesStampDutydata4(incentiveID);
                            FilldataStampDuty4(ds9);
                            divStampDuty4.Visible = true;
                        }
                        else if (MasterIncentiveId == "18")  // COAL
                        {
                            DataSet ds1 = new DataSet();
                            ds1 = GetCOALWOODIncentives(Convert.ToInt32(incentiveID), "18");
                            FillDataCoal(ds1);
                            DIVCOAL.Visible = true;
                        }
                        else if (MasterIncentiveId == "19")  // WOOD
                        {
                            DataSet ds1 = new DataSet();
                            ds1 = GetCOALWOODIncentives(Convert.ToInt32(incentiveID), "19");
                            FillDataWood(ds1);
                            DIVWOOD.Visible = true;
                        }
                        else if (MasterIncentiveId == "20")  // Transport Subsidy
                        {
                            DataSet ds1 = new DataSet();
                            ds1 = GetTransportSubsidy(Convert.ToInt32(incentiveID), "20");
                            FillDataTransportSubsidy(ds1);
                            DIVTRANSPORTDUTY.Visible = true;
                        }
                        else if (MasterIncentiveId == "22")//CAPITAL SUBSIDY
                        {
                            DataSet DS21 = new DataSet();
                            DS21 = GetIncentivesCAPITALSUBSIDY(incentiveID);
                            FilldataCAPITALSUBSIDY(DS21);
                            DIVCAPITALSUBSIDY.Visible = true;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    public DataSet GetIncentivesCAPITALSUBSIDY(string IncentiveID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[USP_GET_INCENTIVES_CAPITALSUBSIDY]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@IncentiveID", SqlDbType.VarChar).Value = IncentiveID;
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

    private void FilldataCAPITALSUBSIDY(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            lblfinancialyear_CS.Text = ds.Tables[0].Rows[0]["FinancialYear"].ToString();
            lblfIirstorsecondhalfyear_CS.Text = ds.Tables[0].Rows[0]["FIRSTORSECONDHALFYEAR"].ToString();
            lblinvestment_cs.Text = ds.Tables[0].Rows[0]["INVESTMENT_FINYEAR"].ToString();



        }
        else
        {

        }
    }
    public DataSet GetCOALWOODIncentives(int incentiveid, string MASTERINCENTIVEID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_COALANDWOODINCENTIVES_PRINT", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@IncentiveId", SqlDbType.Int).Value = incentiveid;
            da.SelectCommand.Parameters.Add("@MASTERINCENTIVEID", SqlDbType.Int).Value = MASTERINCENTIVEID;
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
    private void FillDataCoal(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtFinancialYear.Text = ds.Tables[0].Rows[0]["FinancialYear"].ToString();
            txt1st2ndHalfYear.Text = ds.Tables[0].Rows[0]["FirstorSecondHalf"].ToString();
            txtCoalQuan.Text = ds.Tables[0].Rows[0]["Quantity_Coal"].ToString();
            txtUnitOfMeasure.Text = ds.Tables[0].Rows[0]["UnitMeasurement_coal"].ToString();
            txtamntPaid.Text = ds.Tables[0].Rows[0]["AmountPaid"].ToString();
            txtAmntClaimed.Text = ds.Tables[0].Rows[0]["Amountclaimed"].ToString();
            if (txt1st2ndHalfYear.Text == "(First Half Year)")
            {
                TRFIRSTHALFYEAR_COAL.Visible = true;
                txt1stHlfyramntpaid.Text = ds.Tables[0].Rows[0]["FirstHalfyearAmountPaid"].ToString();
                txt1stHlfyramntclaimed.Text = ds.Tables[0].Rows[0]["FirstHalfyearAmountclaimed"].ToString();
                TRSECONDHALFYEAR_COAL.Visible = false;
            }
            if (txt1st2ndHalfYear.Text == "(Second Half Year)")
            {
                TRFIRSTHALFYEAR_COAL.Visible = false;
                TRSECONDHALFYEAR_COAL.Visible = true;
                txt2ndHlfyramntpaid.Text = ds.Tables[0].Rows[0]["SecondHalfyearAmountPaid"].ToString();
                txt2ndHlfyramntclaimed.Text = ds.Tables[0].Rows[0]["SecondHalfyearAmountclaimed"].ToString();

            }
            txtQuantity.Text = ds.Tables[0].Rows[0]["Quantity_IPG"].ToString();
            txtUnitOfMeasurem.Text = ds.Tables[0].Rows[0]["Unitmeasurement_IPG"].ToString();
            txtPaperQuan.Text = ds.Tables[0].Rows[0]["Quantity_paper"].ToString();
            txtPaperUnitOfMeasurem.Text = ds.Tables[0].Rows[0]["UnitMeasurement_paper"].ToString();
        }
    }

    private void FillDataWood(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtFinancialYearWood.Text = ds.Tables[0].Rows[0]["Financialyear"].ToString();
            txt1st2ndHlfYearWood.Text = ds.Tables[0].Rows[0]["FirstorSecondHalf"].ToString();
            txt1st2ndQuarter.Text = ds.Tables[0].Rows[0]["FirstorsecondQuarter"].ToString();
            if (txt1st2ndHlfYearWood.Text == "1" && txt1st2ndQuarter.Text == "1")
            {
                TRFIRSTHALFYEARFIRSTQUARTER_WOOD.Visible = true;
                txt1sthlfyr1stquaamntpaid.Text = ds.Tables[0].Rows[0]["FirstHalfyear1stquarterAmountPaid"].ToString();
                txt1sthlfyr1stquaamntclaimed.Text = ds.Tables[0].Rows[0]["FirstHalfyear1stquarterAmountclaimed"].ToString();
                TRFIRSTHALFYEARSECONDQUARTER_WOOD.Visible = false;
                TRSECONDHALFYEARFIRSTQUARTER_WOOD.Visible = false;
                TRSECONDHALFYEARSECONDQUARTER_WOOD.Visible = false;
            }
            if (txt1st2ndHlfYearWood.Text == "1" && txt1st2ndQuarter.Text == "2")
            {
                TRFIRSTHALFYEARFIRSTQUARTER_WOOD.Visible = false;
                TRFIRSTHALFYEARSECONDQUARTER_WOOD.Visible = true;
                txt1sthlfyr2ndquaamntpaid.Text = ds.Tables[0].Rows[0]["FirstHalfyear2ndquarterAmountPaid"].ToString();
                txt1sthlfyr2ndquaamntclaimed.Text = ds.Tables[0].Rows[0]["FirstHalfyear2ndquarterAmountclaimed"].ToString();
                TRSECONDHALFYEARFIRSTQUARTER_WOOD.Visible = false;
                TRSECONDHALFYEARSECONDQUARTER_WOOD.Visible = false;
            }
            if (txt1st2ndHlfYearWood.Text == "2" && txt1st2ndQuarter.Text == "1")
            {
                TRFIRSTHALFYEARFIRSTQUARTER_WOOD.Visible = false;
                TRFIRSTHALFYEARSECONDQUARTER_WOOD.Visible = false;
                TRSECONDHALFYEARFIRSTQUARTER_WOOD.Visible = true;
                txt2ndhlfyr1stquaamntpaid.Text = ds.Tables[0].Rows[0]["SecondHalfyear1stquarterAmountPaid"].ToString();
                txt2ndhlfyr1stquaamntclaimed.Text = ds.Tables[0].Rows[0]["SecondHalfyear1stquarterAmountclaimed"].ToString();
                TRSECONDHALFYEARSECONDQUARTER_WOOD.Visible = false;
            }
            if (txt1st2ndHlfYearWood.Text == "2" && txt1st2ndQuarter.Text == "2")
            {
                TRFIRSTHALFYEARFIRSTQUARTER_WOOD.Visible = false;
                TRFIRSTHALFYEARSECONDQUARTER_WOOD.Visible = false;
                TRSECONDHALFYEARFIRSTQUARTER_WOOD.Visible = false;
                TRSECONDHALFYEARSECONDQUARTER_WOOD.Visible = true;
                txt2ndhlfyr2ndquaamntpaid.Text = ds.Tables[0].Rows[0]["SecondHalfyear2ndquarterAmountPaid"].ToString();
                txt2ndhlfyr2ndquaamntclaimed.Text = ds.Tables[0].Rows[0]["SecondHalfyear2ndquarterAmountclaimed"].ToString();
            }
            txtYesNo.Text = ds.Tables[0].Rows[0]["ISPREVIOUSLYWOODSANCTIONED"].ToString();
            if (txtYesNo.Text == "Y")
            {
                TDSANCTIONEDCLAIMSA.Visible = true;
                TDSANCTIONEDCLAIMSB.Visible = true;
                txtSanctionedYear.Text = ds.Tables[0].Rows[0]["NOOFQUARTERSPREVIOUSLYSANCTIONED"].ToString();
                if (txtSanctionedYear.Text == "1")
                {
                    TRFIRSTQUARTER.Visible = true;
                    txt1stQuaQuan.Text = ds.Tables[0].Rows[0]["FIRSTQUARTERQTY"].ToString();
                    TRSECONDQUARTER.Visible = false;
                    TRTHIRDQUARTER.Visible = false;
                }
                if (txtSanctionedYear.Text == "2")
                {
                    TRFIRSTQUARTER.Visible = true;
                    txt1stQuaQuan.Text = ds.Tables[0].Rows[0]["FIRSTQUARTERQTY"].ToString();
                    TRSECONDQUARTER.Visible = true;
                    txt1stQuaQuan.Text = ds.Tables[0].Rows[0]["SECONDQUARTERQTY"].ToString();
                    TRTHIRDQUARTER.Visible = false;
                }
                if (txtSanctionedYear.Text == "3")
                {
                    TRFIRSTQUARTER.Visible = true;
                    txt1stQuaQuan.Text = ds.Tables[0].Rows[0]["FIRSTQUARTERQTY"].ToString();
                    TRSECONDQUARTER.Visible = true;
                    txt1stQuaQuan.Text = ds.Tables[0].Rows[0]["SECONDQUARTERQTY"].ToString();
                    TRTHIRDQUARTER.Visible = true;
                    txt1stQuaQuan.Text = ds.Tables[0].Rows[0]["THIRDQUARTERQTY"].ToString();
                }
            }

            else
            {
                TDSANCTIONEDCLAIMSA.Visible = false;
                TDSANCTIONEDCLAIMSB.Visible = false;
            }

            txtAdmtQuan.Text = ds.Tables[0].Rows[0]["Quantity_WOOD"].ToString();
            txtUnitOfMeasWood.Text = ds.Tables[0].Rows[0]["UnitMeasurement_WOOD"].ToString();

            txtAmntPaidWd.Text = ds.Tables[0].Rows[0]["AmountPaid"].ToString();
            txtAmntClaimedWd.Text = ds.Tables[0].Rows[0]["Amountclaimed"].ToString();
            txtQuantityP.Text = ds.Tables[0].Rows[0]["Quantity_paper"].ToString();
            txtUnitOfMeasurement.Text = ds.Tables[0].Rows[0]["UnitMeasurement_paper"].ToString();

        }
    }
    public DataSet GetTransportSubsidy(int incentiveid, string MASTERINCENTIVEID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_TRASNPORTSUBSIDYINCENTIVES_PRINT", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@IncentiveId", SqlDbType.Int).Value = incentiveid;
            da.SelectCommand.Parameters.Add("@MASTERINCENTIVEID", SqlDbType.Int).Value = MASTERINCENTIVEID;
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
    private void FillDataTransportSubsidy(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["THIRDPARTYAGENCY"].ToString() == "Y")
                {
                    lblthirdparty.Text = "Third Party Agency";
                    tdnameofthirdpartyagencty.Visible = true;
                    tdnameofthirdpartyagencty1.Visible = true;
                    lblnameofthirdpartagancy.Visible = true;

                    lblnameofthirdpartagancy.Text = ds.Tables[0].Rows[0]["Nameofthirdpartagency"].ToString();

                }
                if (ds.Tables[0].Rows[0]["TRAIN"].ToString() == "Y")
                {
                    lbltrain.Text = "Train";

                }
                if (ds.Tables[0].Rows[0]["OWNTRANSPORTATION"].ToString() == "Y")
                {
                    lblowntransport.Text = "Own Transport";

                }

                if (ds.Tables[0].Rows[0]["WAYBILL"].ToString() == "Y")
                {
                    lblwaybill.Text = "Way Bill";

                }
                if (ds.Tables[0].Rows[0]["FUELBILL"].ToString() == "Y")
                {
                    lblfuelbill.Text = "Fuel Bill";

                }
                if (ds.Tables[0].Rows[0]["FREIGHTCHARGES"].ToString() == "Y")
                {
                    lblfreightcharges.Text = "Freight Charges";

                }

                lbltotalamountofexpenditure.Text = ds.Tables[0].Rows[0]["Totalamountofexpenditure"].ToString();
                lblamountofsubsidyclaimed.Text = ds.Tables[0].Rows[0]["Amountofsubsidyclaimed"].ToString();
                lbltotalamountalreadysanctioned.Text = ds.Tables[0].Rows[0]["Alreadysanctionedamount"].ToString();
                lblfinancialyear.Text = ds.Tables[0].Rows[0]["FinancialYear"].ToString();
                lblfirstorsecondhalf.Text = ds.Tables[0].Rows[0]["firstorsecondhalf"].ToString();

            }
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
            {

                gvcomponentdetails.DataSource = ds.Tables[1];
                gvcomponentdetails.DataBind();

            }
        }


    }
    // bind forms methods
    private void FilldataIS(DataSet ds)
    {
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtAppldAddlAmtWomen.Text = ds.Tables[0].Rows[0]["AppldAddlAmtWomen"].ToString();
                txtAppldInvestSubsidy.Text = ds.Tables[0].Rows[0]["AppldInvestSubsidy"].ToString();
                txtAppldTotInvestSubsidy.Text = ds.Tables[0].Rows[0]["AppldTotInvestSubsidy"].ToString();
                txtAvldSubsidyAmt.Text = ds.Tables[0].Rows[0]["AvldSubsidyAmt"].ToString();
                txtAvldSubsidyScheme.Text = ds.Tables[0].Rows[0]["AvldSubsidyScheme"].ToString();
                txtSchemeEligible.Text = ds.Tables[0].Rows[0]["SchemeEligible"].ToString();

                #region fileuploadbinding IS
                //if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                //{
                //    int c = ds.Tables[1].Rows.Count;
                //    string sen, sen1, sen2;
                //    int i = 0;

                //    while (i < c)
                //    {
                //        sen2 = ds.Tables[1].Rows[i][0].ToString();
                //        sen1 = sen2.Replace(@"\", @"/");
                //        sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

                //        if (sen.Contains("62"))
                //        {
                //            lblUpload1.NavigateUrl = sen;
                //            lblUpload1.Text = ds.Tables[1].Rows[i][1].ToString();
                //            lblAttachedFileName1.Text = ds.Tables[1].Rows[i][1].ToString();
                //            //HyperLink1.NavigateUrl = sen;
                //            //HyperLink1.Text = 
                //        }
                //        if (sen.Contains("63"))
                //        {
                //            lblUpload2.NavigateUrl = sen;
                //            lblUpload2.Text = ds.Tables[1].Rows[i][1].ToString();
                //            lblAttachedFileName2.Text = ds.Tables[1].Rows[i][1].ToString();
                //            //HyperLink1.NavigateUrl = sen;
                //            //HyperLink1.Text = 
                //        }
                //        i++;
                //    }
                //}
                #endregion

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    private void FilldataStampDuty(DataSet ds)
    {
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtAreaRegdSaledeed.Text = ds.Tables[0].Rows[0]["AreaRegdSaledeed"].ToString();
                txtPlnthAreaBuild.Text = ds.Tables[0].Rows[0]["PlnthAreaBuild"].ToString();
                txtFivePlnthAreaBuild.Text = ds.Tables[0].Rows[0]["FivePlnthAreaBuild"].ToString();
                txtAreaReqdAppraisal.Text = ds.Tables[0].Rows[0]["AreaReqdAppraisal"].ToString();
                txtAreaReqdTSPCB.Text = ds.Tables[0].Rows[0]["AreaReqdTSPCB"].ToString();
                txtNatureofTrans.Text = ds.Tables[0].Rows[0]["NatureofTrans"].ToString();

                txtSubRegOffc.Text = ds.Tables[0].Rows[0]["SubRegOffc"].ToString();
                txtRegdDeedNo.Text = ds.Tables[0].Rows[0]["RegdDeedNo"].ToString();
                txtRegDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["RegnDate"].ToString()).ToString("dd/MM/yyyy");
                txtStampTranfrDutyAP.Text = ds.Tables[0].Rows[0]["StampTranfrDutyAP"].ToString();
                txtMortgageHypothDutyAP.Text = ds.Tables[0].Rows[0]["MortgageHypothDutyAP"].ToString();
                txtLandConvrChrgAP.Text = ds.Tables[0].Rows[0]["LandConvrChrgAP"].ToString();

                txtLandCostIeIdaIpAP.Text = ds.Tables[0].Rows[0]["LandCostIeIdaIpAP"].ToString();
                txtStampTranfrDutyAC.Text = ds.Tables[0].Rows[0]["StampTranfrDutyAC"].ToString();
                txtMortgageHypothDutyAC.Text = ds.Tables[0].Rows[0]["MortgageHypothDutyAC"].ToString();
                txtLandConvrChrgAC.Text = ds.Tables[0].Rows[0]["LandConvrChrgAC"].ToString();
                txtLandCostIeIdaIpAC.Text = ds.Tables[0].Rows[0]["LandCostIeIdaIpAC"].ToString();

                #region fileuploadbinding StampDuty
                //if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                //{
                //    int c = ds.Tables[1].Rows.Count;
                //    string sen, sen1, sen2;
                //    int i = 0;

                //    while (i < c)
                //    {
                //        sen2 = ds.Tables[1].Rows[i][0].ToString();
                //        sen1 = sen2.Replace(@"\", @"/");
                //        sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

                //        if (sen.Contains("60"))
                //        {
                //            lblupload1.NavigateUrl = sen;
                //            lblupload1.Text = ds.Tables[1].Rows[i][1].ToString();
                //            lblAttachedFileName1.Text = ds.Tables[1].Rows[i][1].ToString();
                //            //HyperLink1.NavigateUrl = sen;
                //            //HyperLink1.Text = 
                //        }
                //        if (sen.Contains("61"))
                //        {
                //            lblUpload2.NavigateUrl = sen;
                //            lblUpload2.Text = ds.Tables[1].Rows[i][1].ToString();
                //            lblAttachedFileName2.Text = ds.Tables[1].Rows[i][1].ToString();
                //            //HyperLink1.NavigateUrl = sen;
                //            //HyperLink1.Text = 
                //        }
                //        i++;
                //    }
                //}
                #endregion

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    private void FillDetailsPower(DataSet ds)
    {
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtClaimedAmount.Text = ds.Tables[0].Rows[0]["AmountClaimed"].ToString();
                if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    ViewState["dtPowerIncentives"] = ds.Tables[1];
                    gvPowerIncentives.DataSource = ds.Tables[1];
                    gvPowerIncentives.DataBind();
                }
                if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                {
                    ViewState["dtEnergy"] = ds.Tables[2];
                    gvEnergy.DataSource = ds.Tables[2];
                    gvEnergy.DataBind();
                }

                #region FileUploading Power
                //if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
                //{
                //    DataTable table = ds.Tables[3];
                //    string sen, sen1, sen2;

                //    foreach (DataRow dr in table.Rows)
                //    {
                //        string AttcahmentId = dr["AttachmentId"].ToString();
                //        sen2 = dr["link"].ToString();
                //        sen1 = sen2.Replace(@"\", @"/");
                //        sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

                //        if (AttcahmentId == "49")
                //        {
                //            lblFileName.NavigateUrl = sen;
                //            lblFileName.Text = dr["FileNm"].ToString();
                //            Label444.Text = dr["FileNm"].ToString();
                //        }
                //        if (AttcahmentId == "50")
                //        {
                //            HyperLink1.NavigateUrl = sen;
                //            HyperLink1.Text = dr["FileNm"].ToString();
                //            Label4.Text = dr["FileNm"].ToString();
                //        }
                //        if (AttcahmentId == "51")
                //        {
                //            HyperLink2.NavigateUrl = sen;
                //            HyperLink2.Text = dr["FileNm"].ToString();
                //            Label5.Text = dr["FileNm"].ToString();
                //        }
                //        if (AttcahmentId == "52")
                //        {
                //            HyperLink3.NavigateUrl = sen;
                //            HyperLink3.Text = dr["FileNm"].ToString();
                //            Label6.Text = dr["FileNm"].ToString();
                //        }
                //        if (AttcahmentId == "53")
                //        {
                //            HyperLink4.NavigateUrl = sen;
                //            HyperLink4.Text = dr["FileNm"].ToString();
                //            Label7.Text = dr["FileNm"].ToString();
                //        }
                //        if (AttcahmentId == "54")
                //        {
                //            HyperLink5.NavigateUrl = sen;
                //            HyperLink5.Text = dr["FileNm"].ToString();
                //            Label7.Text = dr["FileNm"].ToString();
                //        }
                //    }

                //}
                #endregion
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    private void FillDetailsPavalaVaddi(DataSet ds)
    {
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["dtDCP"] = ds.Tables[0];
                    gvInterestDCP.DataSource = ds.Tables[0];
                    gvInterestDCP.DataBind();
                }

                #region  FileUploading Pavala Vaddi
                //if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                //{
                //    DataTable table = ds.Tables[1];
                //    string sen, sen1, sen2;

                //    foreach (DataRow dr in table.Rows)
                //    {
                //        string AttcahmentId = dr["AttachmentId"].ToString();

                //        sen2 = dr["FilePath"].ToString();
                //        sen1 = sen2.Replace(@"\", @"/");
                //        sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

                //        if (AttcahmentId == "58")
                //        {
                //            lblFileName.NavigateUrl = sen;
                //            lblFileName.Text = dr["FileNm"].ToString();
                //            Label444.Text = dr["FileNm"].ToString();
                //        }
                //        if (AttcahmentId == "59")
                //        {
                //            HyperLink1.Text = sen;
                //            HyperLink1.Text = dr["FileNm"].ToString();
                //            Label2.Text = dr["FileNm"].ToString();
                //        }
                //        if (AttcahmentId == "64")
                //        {
                //            HyperLink2.Text = sen;
                //            HyperLink2.Text = dr["link"].ToString();
                //            Label2.Text = dr["FileNm"].ToString();
                //        }
                //    }
                //}
                #endregion
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }

    }

    private void FillDetailsSalesTax(DataSet ds)
    {
        try
        {
            if (ds != null && ds.Tables.Count > 0)  //  && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["dtProductiondtls"] = ds.Tables[0];
                    gvProductiondtls.DataSource = ds.Tables[0];
                    gvProductiondtls.DataBind();
                }
                if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    ViewState["dtSalesTax"] = ds.Tables[1];
                    gvSalesTax.DataSource = ds.Tables[1];
                    gvSalesTax.DataBind();
                }

                #region  File Uploading Sales Tax
                //if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                //{
                //    DataTable table = ds.Tables[2];
                //    string sen, sen1, sen2;

                //    foreach (DataRow dr in table.Rows)
                //    {
                //        string AttcahmentId = dr["AttachmentId"].ToString();

                //        sen2 = dr["FilePath"].ToString();
                //        sen1 = sen2.Replace(@"\", @"/");
                //        sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

                //        if (AttcahmentId == "55")
                //        {
                //            lblFileName.NavigateUrl = sen;
                //            lblFileName.Text = dr["FileNm"].ToString();
                //            Label444.Text = dr["FileNm"].ToString();
                //        }
                //        if (AttcahmentId == "57")
                //        {
                //            HyperLink1.NavigateUrl = sen;
                //            HyperLink1.Text = dr["FileNm"].ToString();
                //            Label4.Text = dr["FileNm"].ToString();
                //        }
                //        if (AttcahmentId == "58")
                //        {
                //            HyperLink2.NavigateUrl = sen;
                //            HyperLink2.Text = dr["FileNm"].ToString();
                //            Label5.Text = dr["FileNm"].ToString();
                //        }
                //    }
                //}
                #endregion

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    private void FillDetailsQualityCertification(DataSet ds)
    {
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtagencyName.Text = ds.Tables[0].Rows[0]["Nameofagency"].ToString();
                txtCertificatNumber.Text = ds.Tables[0].Rows[0]["CertificateNumber"].ToString();
                txtDateofIssue.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DateofIssue"].ToString()).ToString("dd/MM/yyyy");
                txtPeriodofValidity.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["periodofvalidity"].ToString()).ToString("dd/MM/yyyy");
                txtAmountspentinacquiringthecertification.Text = ds.Tables[0].Rows[0]["Amountspentinacquiringthecertification"].ToString();
                txtFromCentralGovernment.Text = ds.Tables[0].Rows[0]["FromCentralGovernment"].ToString();
                txtFromStateGovernment.Text = ds.Tables[0].Rows[0]["FromStateGovernment"].ToString();
                txtFinancingInstitution.Text = ds.Tables[0].Rows[0]["Fromfinancinginstitution"].ToString();

                ddlstate.Text = ds.Tables[0].Rows[0]["intStateid"].ToString();

                if (ds.Tables[0].Rows[0]["intStateid"].ToString() == "31")
                {
                    ddlDistrict.Text = ds.Tables[0].Rows[0]["intDistrictid"].ToString();
                    ddlmandal.Text = ds.Tables[0].Rows[0]["intMandalid"].ToString();
                    ddlvillage.Text = ds.Tables[0].Rows[0]["intVillageid"].ToString();
                }
                else
                {
                    ddlDistrict.Text = ds.Tables[0].Rows[0]["DistrictName"].ToString();
                    ddlmandal.Text = ds.Tables[0].Rows[0]["Mandalname"].ToString();
                    ddlvillage.Text = ds.Tables[0].Rows[0]["VillageName"].ToString();
                }

                txtdoorno.Text = ds.Tables[0].Rows[0]["Door_No"].ToString();
                txtpincode.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
            }

            #region File Uploading Quality Certification
            //if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            //{
            //    DataTable table = ds.Tables[1];
            //    string sen, sen1, sen2;

            //    foreach (DataRow dr in table.Rows)
            //    {
            //        string AttcahmentId = dr["AttachmentId"].ToString();
            //        sen2 = dr["link"].ToString();
            //        sen1 = sen2.Replace(@"\", @"/");
            //        sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

            //        if (AttcahmentId == "9014")
            //        {
            //            Label453.NavigateUrl = sen;
            //            Label453.Text = dr["FileNm"].ToString();
            //            Label454.Text = dr["FileNm"].ToString();
            //        }
            //        if (AttcahmentId == "9015")
            //        {
            //            HyperLink1.NavigateUrl = sen;
            //            HyperLink1.Text = dr["FileNm"].ToString();
            //            Label8.Text = dr["FileNm"].ToString();
            //        }
            //        if (AttcahmentId == "9016")
            //        {
            //            HyperLink3.NavigateUrl = sen;
            //            HyperLink3.Text = dr["FileNm"].ToString();
            //            Label14.Text = dr["FileNm"].ToString();
            //        }
            //    }
            //}
            #endregion
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    private void FillDetailsCleanerProduction(DataSet ds)
    {
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvCertificate.DataSource = ds.Tables[0];
                gvCertificate.DataBind();
                txtsubsidyclaimed.Text = ds.Tables[0].Rows[0]["subsidyclaimed"].ToString();
            }

            #region  File Uploading Cleaner Production
            //if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            //{
            //    DataTable table = ds.Tables[1];
            //    string sen, sen1, sen2;

            //    foreach (DataRow dr in table.Rows)
            //    {
            //        string AttcahmentId = dr["AttachmentId"].ToString();
            //        sen2 = dr["link"].ToString();
            //        sen1 = sen2.Replace(@"\", @"/");
            //        sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

            //        if (AttcahmentId == "9022")
            //        {
            //            Label453.NavigateUrl = sen;
            //            Label453.Text = dr["FileNm"].ToString();
            //            Label454.Text = dr["FileNm"].ToString();
            //        }
            //        if (AttcahmentId == "9023")
            //        {
            //            HyperLink1.NavigateUrl = sen;
            //            HyperLink1.Text = dr["FileNm"].ToString();
            //            Label8.Text = dr["FileNm"].ToString();
            //        }
            //        if (AttcahmentId == "9024")
            //        {
            //            HyperLink3.NavigateUrl = sen;
            //            HyperLink3.Text = dr["FileNm"].ToString();
            //            Label14.Text = dr["FileNm"].ToString();
            //        }
            //    }
            //}
            #endregion
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    private void FillDetailsSkillUpgradation(DataSet ds)
    {
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtagencyName.Text = ds.Tables[0].Rows[0]["Nameofthetraininginstitute"].ToString();
                txtNameoftheskilldevelopmentprogramme.Text = ds.Tables[0].Rows[0]["Nameoftheskilldevelopmentprogramme"].ToString();
                txtNumberskilledemployees.Text = ds.Tables[0].Rows[0]["Numberskilledemployees"].ToString();
                txtExpenditureincurredfortrainingprogramme.Text = ds.Tables[0].Rows[0]["Expenditureincurredtrainingprogramme"].ToString();
                txtAmountclaimedinRs.Text = ds.Tables[0].Rows[0]["Amountclaimed"].ToString();
                txtDurationoftraining.Text = ds.Tables[0].Rows[0]["Durationoftraining"].ToString();
            }

            #region File Uploading Skill Upgradation
            //if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            //{
            //    DataTable table = ds.Tables[1];
            //    string sen, sen1, sen2;

            //    foreach (DataRow dr in table.Rows)
            //    {
            //        string AttcahmentId = dr["AttachmentId"].ToString();
            //        sen2 = dr["link"].ToString();
            //        sen1 = sen2.Replace(@"\", @"/");
            //        sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

            //        if (AttcahmentId == "9018")
            //        {
            //            Label453.NavigateUrl = sen;
            //            Label453.Text = dr["FileNm"].ToString();
            //            Label454.Text = dr["FileNm"].ToString();
            //        }
            //        if (AttcahmentId == "9019")
            //        {
            //            HyperLink1.NavigateUrl = sen;
            //            HyperLink1.Text = dr["FileNm"].ToString();
            //            Label8.Text = dr["FileNm"].ToString();
            //        }
            //        if (AttcahmentId == "9020")
            //        {
            //            HyperLink3.NavigateUrl = sen;
            //            HyperLink3.Text = dr["FileNm"].ToString();
            //            Label14.Text = dr["FileNm"].ToString();
            //        }
            //    }
            //}
            #endregion
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    private void FilldataIIDFund(DataSet ds)
    {
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtUnitLocatedinIndustArea.Text = ds.Tables[0].Rows[0]["UnitLocatedinIndustArea"].ToString();
                txtJustLocation.Text = ds.Tables[0].Rows[0]["JustLocation"].ToString();
                txtFinanceSource.Text = ds.Tables[0].Rows[0]["FinanceSource"].ToString();
                txtReqdInfraFacilities.Text = ds.Tables[0].Rows[0]["ReqdInfraFacilities"].ToString();
                txtProposedInfraCritical.Text = ds.Tables[0].Rows[0]["ProposedInfraCritical"].ToString();

                txtEstimatesInfra.Text = ds.Tables[0].Rows[0]["EstimatesInfra"].ToString();
                txtCAName.Text = ds.Tables[0].Rows[0]["CAName"].ToString();
                txtProjDuration.Text = ds.Tables[0].Rows[0]["ProjDuration"].ToString();
                txtMaintanCostAnnum.Text = ds.Tables[0].Rows[0]["MaintanCostAnnum"].ToString();
                txtAmtClaimed.Text = ds.Tables[0].Rows[0]["AmtClaimed"].ToString();

                #region File Uploading IIDF
                //if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                //{
                //    int c = ds.Tables[1].Rows.Count;
                //    string sen, sen1, sen2;
                //    int i = 0;

                //    while (i < c)
                //    {
                //        sen2 = ds.Tables[1].Rows[i][0].ToString();
                //        sen1 = sen2.Replace(@"\", @"/");
                //        sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

                //        if (sen.Contains("66"))
                //        {
                //            lblUpload1.NavigateUrl = sen;
                //            lblUpload1.Text = ds.Tables[1].Rows[i][1].ToString();
                //            lblAttachedFileName1.Text = ds.Tables[1].Rows[i][1].ToString();
                //            //HyperLink1.NavigateUrl = sen;
                //            //HyperLink1.Text = 
                //        }
                //        i++;
                //    }
                //}
                #endregion

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    private void FilldataSCSCT(DataSet ds)
    {
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtTotalEquity.Text = ds.Tables[0].Rows[0]["TotalEquity"].ToString();
                txtOwnCapital.Text = ds.Tables[0].Rows[0]["OwnCapital"].ToString();
                txtBorrowed.Text = ds.Tables[0].Rows[0]["Borrowed"].ToString();
                txtAdvSubClaimed.Text = ds.Tables[0].Rows[0]["AdvSubClaimed"].ToString();

                #region File Uploading Advanced Subsidy for SC/ST
                //if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                //{
                //    int c = ds.Tables[1].Rows.Count;
                //    string sen, sen1, sen2;
                //    int i = 0;

                //    while (i < c)
                //    {
                //        sen2 = ds.Tables[1].Rows[i][0].ToString();
                //        sen1 = sen2.Replace(@"\", @"/");
                //        sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

                //        if (sen.Contains("80"))
                //        {
                //            lblupload1.NavigateUrl = sen;
                //            lblupload1.Text = ds.Tables[1].Rows[i][1].ToString();
                //            lblAttachedFileName1.Text = ds.Tables[1].Rows[i][1].ToString();
                //            //HyperLink1.NavigateUrl = sen;
                //            //HyperLink1.Text = 
                //        }
                //        if (sen.Contains("81"))
                //        {
                //            lblupload2.NavigateUrl = sen;
                //            lblupload2.Text = ds.Tables[1].Rows[i][1].ToString();
                //            lblAttachedFileName2.Text = ds.Tables[1].Rows[i][1].ToString();
                //            //HyperLink1.NavigateUrl = sen;
                //            //HyperLink1.Text = 
                //        }
                //        if (sen.Contains("82"))
                //        {
                //            lblupload3.NavigateUrl = sen;
                //            lblupload3.Text = ds.Tables[1].Rows[i][1].ToString();
                //            lblAttachedFileName3.Text = ds.Tables[1].Rows[i][1].ToString();
                //            //HyperLink1.NavigateUrl = sen;
                //            //HyperLink1.Text = 
                //        }
                //        if (sen.Contains("83"))
                //        {
                //            lblupload4.NavigateUrl = sen;
                //            lblupload4.Text = ds.Tables[1].Rows[i][1].ToString();
                //            lblAttachedFileName4.Text = ds.Tables[1].Rows[i][1].ToString();
                //            //HyperLink1.NavigateUrl = sen;
                //            //HyperLink1.Text = 
                //        }
                //        i++;
                //    }
                //}
                #endregion

            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    private void FilldataStampDuty1(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtAreaRegdSaledeed1.Text = ds.Tables[0].Rows[0]["AreaRegdSaledeed"].ToString();
            txtPlnthAreaBuild1.Text = ds.Tables[0].Rows[0]["PlnthAreaBuild"].ToString();
            txtFivePlnthAreaBuild1.Text = ds.Tables[0].Rows[0]["FivePlnthAreaBuild"].ToString();
            txtAreaReqdAppraisal1.Text = ds.Tables[0].Rows[0]["AreaReqdAppraisal"].ToString();
            txtAreaReqdTSPCB1.Text = ds.Tables[0].Rows[0]["AreaReqdTSPCB"].ToString();
            txtNatureofTrans1.Text = ds.Tables[0].Rows[0]["NatureofTrans"].ToString();

            txtSubRegOffc1.Text = ds.Tables[0].Rows[0]["SubRegOffc"].ToString();
            txtRegdDeedNo1.Text = ds.Tables[0].Rows[0]["RegdDeedNo"].ToString();
            txtRegDate1.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["RegnDate"].ToString()).ToString("dd/MM/yyyy");
            txtStampTranfrDutyAP1.Text = ds.Tables[0].Rows[0]["StampTranfrDutyAP"].ToString();

            //txtMortgageHypothDutyAP1.Text = ds.Tables[0].Rows[0]["MortgageHypothDutyAP"].ToString();
            //txtLandConvrChrgAP1.Text = ds.Tables[0].Rows[0]["LandConvrChrgAP"].ToString();

            // txtLandCostIeIdaIpAP1.Text = ds.Tables[0].Rows[0]["LandCostIeIdaIpAP"].ToString();
            txtStampTranfrDutyAC1.Text = ds.Tables[0].Rows[0]["StampTranfrDutyAC"].ToString();
            //txtMortgageHypothDutyAC1.Text = ds.Tables[0].Rows[0]["MortgageHypothDutyAC"].ToString();
            //txtLandConvrChrgAC1.Text = ds.Tables[0].Rows[0]["LandConvrChrgAC"].ToString();
            //txtLandCostIeIdaIpAC1.Text = ds.Tables[0].Rows[0]["LandCostIeIdaIpAC"].ToString();
        }
    }
    private void FilldataStampDuty2(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtAreaRegdSaledeed2.Text = ds.Tables[0].Rows[0]["AreaRegdSaledeed"].ToString();
            txtPlnthAreaBuild2.Text = ds.Tables[0].Rows[0]["PlnthAreaBuild"].ToString();
            txtFivePlnthAreaBuild2.Text = ds.Tables[0].Rows[0]["FivePlnthAreaBuild"].ToString();
            txtAreaReqdAppraisal2.Text = ds.Tables[0].Rows[0]["AreaReqdAppraisal"].ToString();
            txtAreaReqdTSPCB2.Text = ds.Tables[0].Rows[0]["AreaReqdTSPCB"].ToString();
            txtNatureofTrans2.Text = ds.Tables[0].Rows[0]["NatureofTrans"].ToString();
            txtSubRegOffc2.Text = ds.Tables[0].Rows[0]["SubRegOffc"].ToString();
            txtRegdDeedNo2.Text = ds.Tables[0].Rows[0]["RegdDeedNo"].ToString();
            txtRegDate2.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["RegnDate"].ToString()).ToString("dd/MM/yyyy");
            txtMortgageHypothDutyAP2.Text = ds.Tables[0].Rows[0]["MortgageHypothDutyAP"].ToString();
            txtMortgageHypothDutyAC2.Text = ds.Tables[0].Rows[0]["MortgageHypothDutyAC"].ToString();
        }

    }
    private void FilldataStampDuty3(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtAreaRegdSaledeed3.Text = ds.Tables[0].Rows[0]["AreaRegdSaledeed"].ToString();
            txtPlnthAreaBuild3.Text = ds.Tables[0].Rows[0]["PlnthAreaBuild"].ToString();
            txtFivePlnthAreaBuild3.Text = ds.Tables[0].Rows[0]["FivePlnthAreaBuild"].ToString();
            txtAreaReqdAppraisal3.Text = ds.Tables[0].Rows[0]["AreaReqdAppraisal"].ToString();
            txtAreaReqdTSPCB3.Text = ds.Tables[0].Rows[0]["AreaReqdTSPCB"].ToString();
            txtNatureofTrans3.Text = ds.Tables[0].Rows[0]["NatureofTrans"].ToString();

            txtSubRegOffc3.Text = ds.Tables[0].Rows[0]["SubRegOffc"].ToString();
            txtRegdDeedNo3.Text = ds.Tables[0].Rows[0]["RegdDeedNo"].ToString();
            txtRegDate3.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["RegnDate"].ToString()).ToString("dd/MM/yyyy");
            txtLandConvrChrgAP3.Text = ds.Tables[0].Rows[0]["LandConvrChrgAP"].ToString();
            txtLandConvrChrgAC3.Text = ds.Tables[0].Rows[0]["LandConvrChrgAC"].ToString();
        }
    }
    private void FilldataStampDuty4(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtAreaRegdSaledeed4.Text = ds.Tables[0].Rows[0]["AreaRegdSaledeed"].ToString();
            txtPlnthAreaBuild4.Text = ds.Tables[0].Rows[0]["PlnthAreaBuild"].ToString();
            txtFivePlnthAreaBuild4.Text = ds.Tables[0].Rows[0]["FivePlnthAreaBuild"].ToString();
            txtAreaReqdAppraisal4.Text = ds.Tables[0].Rows[0]["AreaReqdAppraisal"].ToString();
            txtAreaReqdTSPCB4.Text = ds.Tables[0].Rows[0]["AreaReqdTSPCB"].ToString();
            txtNatureofTrans4.Text = ds.Tables[0].Rows[0]["NatureofTrans"].ToString();
            txtSubRegOffc4.Text = ds.Tables[0].Rows[0]["SubRegOffc"].ToString();
            txtRegdDeedNo4.Text = ds.Tables[0].Rows[0]["RegdDeedNo"].ToString();
            txtRegDate4.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["RegnDate"].ToString()).ToString("dd/MM/yyyy");
            txtLandCostIeIdaIpAP4.Text = ds.Tables[0].Rows[0]["LandCostIeIdaIpAP"].ToString();
            txtLandCostIeIdaIpAC4.Text = ds.Tables[0].Rows[0]["LandCostIeIdaIpAC"].ToString();
        }

    }
    protected void BtnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmIncentiveCAFDetails.aspx");
    }
    protected void BtnPrevious_Click(object sender, EventArgs e)
    {

    }

    //protected void lbtAttachments_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        GridViewRow gr = (((LinkButton)sender).Parent.Parent as GridViewRow);
    //        obcmf.FillGrid(objFetch.FetchIncetiveUploadsViewNewINCType(Convert.ToInt32((gr.FindControl("lblEntrpId") as Label).Text), 0), gvAttachments, false);
    //    }
    //    catch (Exception ex) { Errors.ErrorLog(ex); }
    //}

    //protected void lbtVwatt_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        GridViewRow gr = (((LinkButton)sender).Parent.Parent as GridViewRow);
    //        obcmf.FillGrid(objFetch.FetchIncetiveUploadsViewNewINCType(Convert.ToInt32((gr.FindControl("lblEntrpId") as Label).Text),
    //                                                            Convert.ToInt32((gr.FindControl("lblEntrpId") as Label).ToolTip)),
    //                        gvAttachments, false);
    //        //tblAttachments.Visible = true;
    //    }
    //    catch (Exception ex) { Errors.ErrorLog(ex); }
    //}
    protected void btnPrint_Click(object sender, EventArgs e)
    {

    }
    protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int rowww = e.RowIndex;
            string idnew = ((Label)GridView3.Rows[e.RowIndex].FindControl("lblid")).Text.ToString().Trim();

            string IncentiveName = GridView3.Rows[e.RowIndex].Cells[2].Text;
            string lblMstIncentiveId = ((Label)GridView3.Rows[e.RowIndex].FindControl("lblMstIncentiveId")).Text.ToString().Trim();
            ListItem li = new ListItem();
            li.Text = IncentiveName;
            li.Value = lblMstIncentiveId;

            ddlstaire.Items.Add(li);

            if (idnew != "0" && idnew != "")
            {
                int validremaeks = Gen.deleteGroupSavingDataincentive(idnew);


            }
            if (GridView3.Rows.Count == 1)
            {
                trnotinfullshap.Visible = false;
                Button3.Visible = false;
            }

            ((DataTable)Session["CertificateTbAmount"]).Rows.RemoveAt(e.RowIndex);
            this.GridView3.DataSource = ((DataTable)Session["CertificateTbAmount"]).DefaultView;
            this.GridView3.DataBind();
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Please enter correct data";// ex.ToString();
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());

        }
        finally
        {

        }
    }
    protected void gvinspectionOfficer_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnUploadcoi = e.Row.FindControl("Button1") as Button;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(btnUploadcoi);

                Button btnUploaddipc = e.Row.FindControl("Button2") as Button;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(btnUploaddipc);

                DropDownList ddlstatus = (e.Row.FindControl("ddlapprove") as DropDownList);
                FileUpload jdFileupload = (e.Row.FindControl("FileUploadgminspection") as FileUpload);  //test
                Label enterid = (e.Row.FindControl("lblIncentiveID") as Label);
                Label MstIncentiveId = (e.Row.FindControl("lblMstIncentiveId") as Label);

                string Role_Code = Session["Role_Code"].ToString().Trim().TrimStart();
                if (Role_Code == "JD")
                {
                    jdFileupload.Visible = false;
                }

                if (Role_Code == "GM" && ddlstatus.SelectedValue != "3")
                {
                    (e.Row.FindControl("HyperIncentiveName") as HyperLink).Visible = true;
                    (e.Row.FindControl("lblIncentiveNameDis") as Label).Visible = false;
                    (e.Row.FindControl("HyperIncentiveName") as HyperLink).NavigateUrl = "frmIncentiveGmedit.aspx?EntrpId=" + enterid.Text.Trim() + "&MstId=" + MstIncentiveId.Text;
                }
                else
                {
                    (e.Row.FindControl("HyperIncentiveName") as HyperLink).Visible = false;
                    (e.Row.FindControl("lblIncentiveNameDis") as Label).Visible = true;
                }

                //if (MstIncentiveId.Text == "6")
                //{
                //    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaInvestmentSubsidy.aspx?EntrpId=" + enterid.Text.Trim();
                //}
                //if (MstIncentiveId.Text == "1")
                //{
                //    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaPavalavaddi.aspx?incentiveid=" + enterid.Text.Trim();
                //}
                //if (MstIncentiveId.Text == "3")
                //{
                //    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaPowerTariff.aspx?incentiveid=" + enterid.Text.Trim();
                //}
                //if (MstIncentiveId.Text == "5")
                //{
                //    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaSalesTax.aspx?incentiveid=" + enterid.Text.Trim();
                //}

                if (MstIncentiveId.Text == "6")  // investment subsidy
                {
                    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaInvestmentSubsidy.aspx?EntrpId=" + enterid.Text.Trim();
                }
                if (MstIncentiveId.Text == "1") // pavala vaddi
                {
                    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaPavalavaddi.aspx?incentiveid=" + enterid.Text.Trim();
                }
                if (MstIncentiveId.Text == "3") // power
                {
                    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaPowerTariff.aspx?incentiveid=" + enterid.Text.Trim();
                }
                if (MstIncentiveId.Text == "5")  // sales tax
                {
                    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaSalesTax.aspx?incentiveid=" + enterid.Text.Trim();
                }
                if (MstIncentiveId.Text == "9" || MstIncentiveId.Text.ToString() == "14" || MstIncentiveId.Text.ToString() == "15" || MstIncentiveId.Text.ToString() == "16" || MstIncentiveId.Text.ToString() == "17")   // stamp duty
                {
                    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaStampDuty.aspx?incentiveid=" + enterid.Text.Trim() + "&MstIncentiveId=" + MstIncentiveId.Text;
                }
                if (MstIncentiveId.Text == "10")   // seed cap
                {
                    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaSeedCap.aspx?incentiveid=" + enterid.Text.Trim();
                }
                if (MstIncentiveId.Text == "11")   // quality certification
                {
                    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaQualityCertification.aspx?incentiveid=" + enterid.Text.Trim();
                }
                if (MstIncentiveId.Text == "4")   // cleaner production
                {
                    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaCleanerProduction.aspx?incentiveid=" + enterid.Text.Trim();
                }
                if (MstIncentiveId.Text == "8")   // skill upgradation
                {
                    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaSkillUpgradation.aspx?incentiveid=" + enterid.Text.Trim();
                }
                if (MstIncentiveId.Text == "7")   // IIDF
                {
                    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaIIDFFundaspx.aspx?incentiveid=" + enterid.Text.Trim();
                }
                if (MstIncentiveId.Text == "12")   // advanced subsidy
                {
                    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaAdvancedSubsidyforSCST.aspx?incentiveid=" + enterid.Text.Trim();
                }
                if (MstIncentiveId.Text == "22")   // capital subsidy
                {
                    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaCapitalSubsidy.aspx?incentiveid=" + enterid.Text.Trim();
                }

                if (ddlstatus.SelectedValue == "1")
                {
                    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).ForeColor = System.Drawing.Color.Red;
                    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).Text = "Query Letter";
                    (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaQueryRaiseShortFallLetterGMtoApplicantApproval.aspx?incentiveid=" + enterid.Text.Trim() + "&MstIncentiveId=" + MstIncentiveId.Text.Trim();

                    // hplink.NavigateUrl = "ProformaQueryRaiseShortFallLetterGMtoApplicant.aspx?incentiveid=" + intApplicationidtop;
                }
                else if (ddlstatus.SelectedValue == "2")
                {

                }
                else if (ddlstatus.SelectedValue == "3")
                {

                }


                HiddenField hdnStageID = (e.Row.FindControl("hdfStatusId") as HiddenField);
                if (MstIncentiveId.Text.ToString() == "6")
                {
                    //  (e.Row.FindControl("anchortaglink") as HyperLink).NavigateUrl = "InspectionReport.aspx?EntrpId=" + enterid.Text.Trim() + "&Inctypeid=" + MstIncentiveId.Text;
                    //
                    if (hdnStageID != null && Convert.ToInt32(hdnStageID.Value) >= 5)
                    {

                        (e.Row.FindControl("anchortaglinkView") as HyperLink).Visible = true;
                        //(e.Row.FindControl("anchortaglinkView") as HyperLink).NavigateUrl = "frmInspRepDrft.aspx?EntrpId=" + enterid.Text.Trim() + "&Inctypeid=" + MstIncentiveId.Text;
                        (e.Row.FindControl("anchortaglinkView") as HyperLink).NavigateUrl = "InspectionReportNew.aspx?EntrpId=" + enterid.Text.Trim() + "&Inctypeid=" + MstIncentiveId.Text;
                    }
                    else
                    {
                        (e.Row.FindControl("anchortaglinkView") as HyperLink).Visible = false;
                    }
                }
                else if (MstIncentiveId.Text.ToString() == "9" || MstIncentiveId.Text.ToString() == "14" || MstIncentiveId.Text.ToString() == "15" || MstIncentiveId.Text.ToString() == "16" || MstIncentiveId.Text.ToString() == "17")
                {
                    // (e.Row.FindControl("anchortaglink") as HyperLink).NavigateUrl = "IPORptStampDutySubsidy.aspx?EntrpId=" + enterid.Text.Trim() + "&Inctypeid=" + MstIncentiveId.Text;
                    if (hdnStageID != null && Convert.ToInt32(hdnStageID.Value) >= 5)
                    {
                        (e.Row.FindControl("anchortaglinkView") as HyperLink).Visible = true;
                        (e.Row.FindControl("anchortaglinkView") as HyperLink).NavigateUrl = "IPORptStampDutySubsidyDraft.aspx?EntrpId=" + enterid.Text.Trim() + "&Inctypeid=" + MstIncentiveId.Text;
                    }
                    else
                    {
                        (e.Row.FindControl("anchortaglinkView") as HyperLink).Visible = false;
                    }
                }
                else
                {
                    // (e.Row.FindControl("anchortaglink") as HyperLink).NavigateUrl = "IPORptCommon.aspx?EntrpId=" + enterid.Text.Trim() + "&Inctypeid=" + MstIncentiveId.Text;
                    if (hdnStageID != null && Convert.ToInt32(hdnStageID.Value) >= 5)
                    {
                        (e.Row.FindControl("anchortaglinkView") as HyperLink).Visible = true;
                        (e.Row.FindControl("anchortaglinkView") as HyperLink).NavigateUrl = "IPORptCommonDraft.aspx?EntrpId=" + enterid.Text.Trim() + "&Inctypeid=" + MstIncentiveId.Text;
                    }
                    else
                    {
                        (e.Row.FindControl("anchortaglinkView") as HyperLink).Visible = false;
                    }
                }

                // added for Inspection not required cases
                Label txtinspectiondate = (e.Row.FindControl("txtinspectiondate") as Label);
                if (txtinspectiondate.Text == "")
                {
                    HyperLink anchortaglinkView = (e.Row.FindControl("anchortaglinkView") as HyperLink);
                    anchortaglinkView.Visible = false;
                    txtinspectiondate.Text = "Inspection Not Required";
                }

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void gvdetailsfinalproforma_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void btnfinalsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow gvrow in gvdetailsfinalproforma.Rows)
            {
                officerForwarded frmvo = new officerForwarded();
                string lblMstIncentiveId = ((Label)gvrow.FindControl("lblMstIncentiveId")).Text;
                string lblIncentiveID = ((Label)gvrow.FindControl("lblIncentiveID")).Text;
                frmvo.EnterperIncentiveID = lblIncentiveID;
                frmvo.MstIncentiveId = lblMstIncentiveId;
                frmvo.CreatedByid = Session["uid"].ToString();
                frmvo.ApplicationFrom = Session["User_Code"].ToString();
                string[] datett = txtslcnodate.Text.Trim().Split('/');
                frmvo.Slcdate = datett[2] + "/" + datett[1] + "/" + datett[0];
                frmvo.SLCNO = txtslcno.Text.Trim();
                lstincentives.Add(frmvo);
            }

            int valid = Gen.InsertFinalProceedings(lstincentives, getclientIP());
            //lblmsg.Text = "<font color='green'>Sactionned Successfully</font>";
            //success.Visible = true;
            //Failure.Visible = false;
            // Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Sactionned Successfully');", true);

            string message = "alert('Sanctioned Successfully')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void gvinspectionReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    Label enterid = (e.Row.FindControl("lblIncentiveID") as Label);
            //    Label MstIncentiveId = (e.Row.FindControl("lblMstIncentiveId") as Label);
            //    if (MstIncentiveId.Text.ToString() == "6")
            //    {
            //        (e.Row.FindControl("anchortaglink") as HyperLink).NavigateUrl = "InspectionReport.aspx?EntrpId=" + enterid.Text.Trim() + "&Inctypeid=" + MstIncentiveId.Text;
            //    }
            //}
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label enterid = (e.Row.FindControl("lblIncentiveID") as Label);
                Label MstIncentiveId = (e.Row.FindControl("lblMstIncentiveId") as Label);
                HiddenField hdnStageID = (e.Row.FindControl("hdfStatusId") as HiddenField);
                DropDownList ddlinspector = (e.Row.FindControl("ddlinspector") as DropDownList);
                Label lblReportStatus = (e.Row.FindControl("lblreportStatusID") as Label);
                if (lblReportStatus.Text.Trim() == "Q")
                {
                    ddlinspector.SelectedValue = "2";
                    ddlinspector.Enabled = false;
                    (e.Row.FindControl("anchortagIPOCertificate") as HyperLink).Visible = true;
                    (e.Row.FindControl("anchortagIPOCertificate") as HyperLink).NavigateUrl = "QueryRaiseShortFallLetterinspectortoApplicantApproval.aspx?incentiveid=" + enterid.Text.Trim() + "&MstIncentiveId=" + MstIncentiveId.Text;
                    (e.Row.FindControl("anchortaglink") as HyperLink).Visible = false;

                }

                if (MstIncentiveId.Text.ToString() == "6")
                {
                    // (e.Row.FindControl("anchortaglink") as HyperLink).NavigateUrl = "InspectionReport.aspx?EntrpId=" + enterid.Text.Trim() + "&Inctypeid=" + MstIncentiveId.Text;
                    (e.Row.FindControl("anchortaglink") as HyperLink).NavigateUrl = "InspectionReportNew.aspx?EntrpId=" + enterid.Text.Trim() + "&Inctypeid=" + MstIncentiveId.Text;

                    //
                    if (hdnStageID != null && Convert.ToInt32(hdnStageID.Value) >= 5 && Convert.ToInt32(hdnStageID.Value) != 67)
                    {
                        (e.Row.FindControl("anchortaglinkView") as HyperLink).Visible = true;
                        //(e.Row.FindControl("anchortaglinkView") as HyperLink).NavigateUrl = "frmInspRepDrft.aspx?EntrpId=" + enterid.Text.Trim() + "&Inctypeid=" + MstIncentiveId.Text;
                        (e.Row.FindControl("anchortaglinkView") as HyperLink).NavigateUrl = "InspectionReportNew.aspx?EntrpId=" + enterid.Text.Trim() + "&Inctypeid=" + MstIncentiveId.Text;
                        ddlinspector.SelectedValue = "1";
                        ddlinspector.Enabled = false;
                    }
                    else
                    {
                        (e.Row.FindControl("anchortaglinkView") as HyperLink).Visible = false;
                    }
                }
                else if (MstIncentiveId.Text.ToString() == "9" || MstIncentiveId.Text.ToString() == "14" || MstIncentiveId.Text.ToString() == "15" || MstIncentiveId.Text.ToString() == "16" || MstIncentiveId.Text.ToString() == "17")
                {
                    (e.Row.FindControl("anchortaglink") as HyperLink).NavigateUrl = "IPORptStampDutySubsidy.aspx?EntrpId=" + enterid.Text.Trim() + "&Inctypeid=" + MstIncentiveId.Text;
                    if (hdnStageID != null && Convert.ToInt32(hdnStageID.Value) >= 5 && Convert.ToInt32(hdnStageID.Value) != 67)
                    {
                        (e.Row.FindControl("anchortaglinkView") as HyperLink).Visible = true;
                        (e.Row.FindControl("anchortaglinkView") as HyperLink).NavigateUrl = "IPORptStampDutySubsidyDraft.aspx?EntrpId=" + enterid.Text.Trim() + "&Inctypeid=" + MstIncentiveId.Text;
                        ddlinspector.SelectedValue = "1";
                        ddlinspector.Enabled = false;
                    }
                    else
                    {
                        (e.Row.FindControl("anchortaglinkView") as HyperLink).Visible = false;
                    }
                }
                else
                {
                    (e.Row.FindControl("anchortaglink") as HyperLink).NavigateUrl = "IPORptCommon.aspx?EntrpId=" + enterid.Text.Trim() + "&Inctypeid=" + MstIncentiveId.Text;
                    if (hdnStageID != null && Convert.ToInt32(hdnStageID.Value) >= 5 && Convert.ToInt32(hdnStageID.Value) != 67)
                    {
                        (e.Row.FindControl("anchortaglinkView") as HyperLink).Visible = true;
                        (e.Row.FindControl("anchortaglinkView") as HyperLink).NavigateUrl = "IPORptCommonDraft.aspx?EntrpId=" + enterid.Text.Trim() + "&Inctypeid=" + MstIncentiveId.Text;
                        ddlinspector.SelectedValue = "1";
                        ddlinspector.Enabled = false;
                    }
                    else
                    {
                        (e.Row.FindControl("anchortaglinkView") as HyperLink).Visible = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void gvinspectionReport_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void gvqquryresponceattachment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = (e.Row.FindControl("lbl") as Label);
                HyperLink HyperLinkSubsidy = (e.Row.FindControl("HyperLinkSubsidy") as HyperLink);
                if (lbl.Text != "")
                {
                    string filepathnew = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LINKNEW"));
                    if (filepathnew != "")
                    {
                        string encpassword = Gen.Encrypt(filepathnew, "SYSTIME");
                        HyperLinkSubsidy.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    }
                    else
                    {
                        HyperLinkSubsidy.Visible = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void gvsupportingdocs_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = (e.Row.FindControl("lbl") as Label);
                HyperLink HyperLinkSubsidy = (e.Row.FindControl("HyperLinkSubsidy") as HyperLink);
                if (lbl.Text != "")
                {
                    string filepathnew = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LINKNEW"));
                    if (filepathnew != "")
                    {
                        string encpassword = Gen.Encrypt(filepathnew, "SYSTIME");
                        HyperLinkSubsidy.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    }
                    else
                    {
                        HyperLinkSubsidy.Visible = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void gvsscreport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = (e.Row.FindControl("Label67") as Label);
                HyperLink HyperLinkSubsidy = (e.Row.FindControl("HyperLink6") as HyperLink);
                if (lbl.Text != "")
                {
                    string filepathnew = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LINKNEW"));
                    if (filepathnew != "")
                    {
                        string encpassword = Gen.Encrypt(filepathnew, "SYSTIME");
                        HyperLinkSubsidy.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    }
                    else
                    {
                        HyperLinkSubsidy.Visible = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void gvsscreport1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = (e.Row.FindControl("Label30") as Label);
                HyperLink HyperLinkSubsidy = (e.Row.FindControl("HyperLink7") as HyperLink);
                if (lbl.Text != "")
                {
                    string filepathnew = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LINKNEW"));
                    if (filepathnew != "")
                    {
                        string encpassword = Gen.Encrypt(filepathnew, "SYSTIME");
                        HyperLinkSubsidy.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    }
                    else
                    {
                        HyperLinkSubsidy.Visible = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void gvlastattachments_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = (e.Row.FindControl("lbl") as Label);
                HyperLink HyperLinkSubsidy = (e.Row.FindControl("HyperLinkSubsidy") as HyperLink);
                if (lbl.Text != "")
                {
                    string filepathnew = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LINKNEW"));
                    if (filepathnew != "")
                    {
                        string encpassword = Gen.Encrypt(filepathnew, "SYSTIME");
                        HyperLinkSubsidy.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    }
                    else
                    {
                        HyperLinkSubsidy.Visible = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void hvInspection_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = (e.Row.FindControl("lbl") as Label);
                HyperLink HyperLinkSubsidy = (e.Row.FindControl("HyperLinkSubsidy") as HyperLink);
                if (lbl.Text != "")
                {
                    string filepathnew = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LINKNEW"));
                    if (filepathnew != "")
                    {
                        string encpassword = Gen.Encrypt(filepathnew, "SYSTIME");
                        HyperLinkSubsidy.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    }
                    else
                    {
                        HyperLinkSubsidy.Visible = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void GridView14_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = (e.Row.FindControl("lbl") as Label);
                HyperLink HyperLinkSubsidy = (e.Row.FindControl("HyperLinkSubsidy") as HyperLink);
                if (lbl.Text != "")
                {
                    string filepathnew = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LINKNEW"));
                    if (filepathnew != "")
                    {
                        string encpassword = Gen.Encrypt(filepathnew, "SYSTIME");
                        HyperLinkSubsidy.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    }
                    else
                    {
                        HyperLinkSubsidy.Visible = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void gvSubsidy_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = (e.Row.FindControl("lbl") as Label);
                HyperLink HyperLinkSubsidy = (e.Row.FindControl("HyperLinkSubsidy") as HyperLink);
                if (lbl.Text != "")
                {
                    string filepathnew = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LINKNEW"));
                    if (filepathnew != "")
                    {
                        string encpassword = Gen.Encrypt(filepathnew, "SYSTIME");
                        HyperLinkSubsidy.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    }
                    else
                    {
                        HyperLinkSubsidy.Visible = false;
                    }
                }
                //Label enterid = (e.Row.FindControl("lblverified") as Label);
                if (lbl.Text == "")
                {
                    e.Row.Cells[1].ColumnSpan = 2;
                    e.Row.Cells.RemoveAt(2);
                    HyperLinkSubsidy.Visible = false;
                    e.Row.Font.Bold = true;
                }
                //if (enterid.Text.ToString() == "")
                //{
                //    HyperLinkSubsidy.Visible = false;
                //}
                if (lbl.Text == "")
                {
                    e.Row.Cells[1].ColumnSpan = 2;
                    e.Row.Cells.RemoveAt(2);
                    HyperLinkSubsidy.Visible = false;
                    e.Row.Font.Bold = true;
                }
                if (lbl.Text != "")
                {
                    e.Row.Cells[2].ColumnSpan = 2;
                    e.Row.Cells.RemoveAt(1);
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void gvfinalgrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lbl = (e.Row.FindControl("lbl") as Label);
                HyperLink HyperLinkSubsidy = (e.Row.FindControl("HyperLinkSubsidy") as HyperLink);
                if (lbl.Text != "")
                {
                    string filepathnew = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LINKNEW"));
                    if (filepathnew != "")
                    {
                        string encpassword = Gen.Encrypt(filepathnew, "SYSTIME");
                        HyperLinkSubsidy.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    }
                    else
                    {
                        HyperLinkSubsidy.Visible = false;
                    }
                }
                Label enterid = (e.Row.FindControl("lblverified") as Label);
                //Label lbl = (e.Row.FindControl("lbl") as Label);
                //HyperLink HyperLinkSubsidy = (e.Row.FindControl("HyperLinkSubsidy") as HyperLink);
                if (enterid.Text.ToString() == "NO")
                {
                    enterid.ForeColor = System.Drawing.Color.Red;
                    enterid.Style.Add("Font-Bold", "true");
                }
                if (enterid.Text.ToString() == "")
                {
                    HyperLinkSubsidy.Visible = false;
                }
                if (lbl.Text == "")
                {
                    e.Row.Cells[1].ColumnSpan = 2;
                    e.Row.Cells.RemoveAt(2);
                    HyperLinkSubsidy.Visible = false;
                    e.Row.Font.Bold = true;
                }
                if (lbl.Text != "")
                {
                    e.Row.Cells[2].ColumnSpan = 2;
                    e.Row.Cells.RemoveAt(1);
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void rdbyesno_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridView1.Visible = false;
            trddlDeptname.Visible = false;
            GridView2.Visible = false;
            trSubmitQuery.Visible = false;
            GridView4.Visible = false;
            trGmReject.Visible = false;
            Button6.Visible = true;



            //int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            //string lblMstIncentiveId = ((Label)grdDetails.Rows[indexing].FindControl("lblMstIncentiveId")).Text;
            //RadioButtonList li = ((RadioButtonList)grdDetails.Rows[indexing].FindControl("rdbyesno"));
            //if (lblMstIncentiveId == "6" && li.SelectedValue == "N")
            //{
            //    GridView1.Visible = false;
            //    trddlDeptname.Visible = false;
            //    foreach (GridViewRow gvrowg in grdDetails.Rows)
            //    {
            //        RadioButtonList ControlFullShapev = ((RadioButtonList)gvrowg.FindControl("rdbyesno"));
            //        string MstIncentiveIds = ((Label)gvrowg.FindControl("lblMstIncentiveId")).Text.ToString();
            //        if (MstIncentiveIds != "6")
            //        {
            //            ControlFullShapev.SelectedValue = "N";
            //            ControlFullShapev.Enabled = false;
            //        }
            //    }
            //}
            //if (lblMstIncentiveId == "6" && li.SelectedValue == "Y")
            //{
            //    GridView2.Visible = false;
            //    trSubmitQuery.Visible = false;
            //    foreach (GridViewRow gvrowg in grdDetails.Rows)
            //    {
            //        RadioButtonList ControlFullShapev = ((RadioButtonList)gvrowg.FindControl("rdbyesno"));
            //        string MstIncentiveIds = ((Label)gvrowg.FindControl("lblMstIncentiveId")).Text.ToString();
            //        if (MstIncentiveIds != "6")
            //        {
            //            ControlFullShapev.SelectedIndex = -1;
            //            ControlFullShapev.Enabled = true;
            //        }
            //    }
            //}
            //if (lblMstIncentiveId == "6" && li.SelectedValue == "R")
            //{
            //    GridView2.Visible = false;
            //    trSubmitQuery.Visible = false;
            //    GridView1.Visible = false;
            //    trddlDeptname.Visible = false;
            //    //foreach (GridViewRow gvrowg in grdDetails.Rows)
            //    //{
            //    //    RadioButtonList ControlFullShapev = ((RadioButtonList)gvrowg.FindControl("rdbyesno"));
            //    //    string MstIncentiveIds = ((Label)gvrowg.FindControl("lblMstIncentiveId")).Text.ToString();
            //    //    if (MstIncentiveIds != "6")
            //    //    {
            //    //        ControlFullShapev.SelectedValue = "N";
            //    //        ControlFullShapev.Enabled = false;
            //    //    }
            //    //}
            //}
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void ddlapplicationto_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (LoanAggrementCheck == "0" || txtLoanAgreement.Text == "Not Available")
            {
                if (txtLoanAgreement.Text == "Not Available" || txtLoanAgreement.Text == "")
                {
                    string messagenew = "alert('Please verify the Loan/Agreement Account no')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", messagenew, true);
                    ddlapplicationto.SelectedValue = "0";
                    txtLoanAgreement.Focus();
                    return;
                }
                if (LoanAggrementCheck == "0" && chckLoanAggrement.Checked == false && chckLoanAggrement.Enabled == true)
                {
                    string messagenew = "alert('Please verify the Loan/Agreement Account no')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", messagenew, true);
                    ddlapplicationto.SelectedValue = "0";
                    txtLoanAgreement.Focus();
                    return;
                }

            }
            if (ViewState["casteGenderGmUpdate"] == null)
            {
                if (casteGenderGmUpdate != "Y")
                {
                    string messagenew = "alert('Please enter all the above details')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", messagenew, true);
                    ddlapplicationto.SelectedValue = "0";
                    return;
                }
            }
            if (casteGenderGmUpdate != "Y" && ViewState["casteGenderGmUpdate"] == null)
            {
                string messagenew = "alert('Please enter all the above details')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", messagenew, true);
                ddlapplicationto.SelectedValue = "0";
                return;
            }
            if (casteGenderGmUpdate != "Y" && ViewState["casteGenderGmUpdate"] == null)
            {

            }
            if (rbtISINSLCORNOT.SelectedValue != "Y" && rbtISINSLCORNOT.SelectedValue != "N")
            {
                string messagenew = "alert('Please select whether the investment subsidy was sanctioned by the SLC or recommended to the COI.')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", messagenew, true);
                ddlapplicationto.SelectedValue = "0";
                return;
            }
            if (HDNINDUSTRYSTATUS.Value == "1" && hdnMSMEApplied.Value == "Y")
            {
                if (rbtISINSLCORNOT.SelectedValue != "Y" && HDNISSANCTIONEDINSLCORNOT.Value != "Y")
                {
                    if ((rdbCaste.SelectedValue == "SC" || rdbCaste.SelectedValue == "ST" || rdbCaste.SelectedValue == "PHC")
                        && rdbSector.SelectedValue == "Service" && rdbServiceType.SelectedValue == "STNT")
                    {
                        if ((Convert.ToDecimal(txtbuildingexistingNew.Text) + Convert.ToDecimal(txtplantexistingNew.Text)) >= 5000000 && ddlapplicationto.SelectedValue != "1")
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Sir/Madam, As Building value and plan & machinery value exceeds 50,00,000, this application comes under SLC. Please check and select it as SLC');", true);
                            ddlapplicationto.ClearSelection();
                            return;
                        }
                        else if ((Convert.ToDecimal(txtbuildingexistingNew.Text) + Convert.ToDecimal(txtplantexistingNew.Text)) < 5000000 && ddlapplicationto.SelectedValue != "2")
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Sir/Madam, As Building value and plan & machinery valu below 50,00,000, this application comes under DIPC. Please check and select it as DIPC');", true);
                            ddlapplicationto.ClearSelection();
                            return;
                        }
                        else
                        {
                            // ddlapplicationto.Enabled = false;
                            rbtISINSLCORNOT.Enabled = false;
                            rdbCaste.Enabled = false;
                            rdbGender.Enabled = false;
                            rdbCategory.Enabled = false;
                            rdbEnterprise.Enabled = false;
                            rdbSector.Enabled = false;
                        }

                    }
                    else
                    {
                        if (Convert.ToDecimal(txtplantexistingNew.Text) >= 5000000 && ddlapplicationto.SelectedValue != "1")
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Sir/Madam, As plan and machinery value exceeds 50,00,000, this application comes under SLC. Please check and select it as SLC');", true);
                            ddlapplicationto.ClearSelection();
                            return;
                        }
                        else if (Convert.ToDecimal(txtplantexistingNew.Text) < 5000000 && ddlapplicationto.SelectedValue != "2")
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Sir/Madam, As plan and machinery value below 50,00,000, this application comes under DIPC. Please check and select it as DIPC');", true);
                            ddlapplicationto.ClearSelection();
                            return;
                        }
                        else
                        {
                           // ddlapplicationto.Enabled = false;
                            rbtISINSLCORNOT.Enabled = false;
                            rdbCaste.Enabled = false;
                            rdbGender.Enabled = false;
                            rdbCategory.Enabled = false;
                            rdbEnterprise.Enabled = false;
                            rdbSector.Enabled = false;
                        }
                    }
                }
                else
                {
                    ddlapplicationto.SelectedValue = "1";
                    ddlapplicationto.Enabled = false;
                    rbtISINSLCORNOT.Enabled = false;
                    rdbCaste.Enabled = false;
                    rdbGender.Enabled = false;
                    rdbCategory.Enabled = false;
                    rdbEnterprise.Enabled = false;
                    rdbSector.Enabled = false;
                    
                }


            }
            if ((HDNINDUSTRYSTATUS.Value == "2" || HDNINDUSTRYSTATUS.Value == "3") && hdnMSMEApplied.Value == "Y")
            {
                if (rbtISINSLCORNOT.SelectedValue != "Y" && HDNISSANCTIONEDINSLCORNOT.Value != "Y")
                {
                    if ((rdbCaste.SelectedValue == "SC" || rdbCaste.SelectedValue == "ST" || rdbCaste.SelectedValue == "PHC")
                        && rdbSector.SelectedValue == "Service" && rdbServiceType.SelectedValue == "STNT")
                    {
                        if (((Convert.ToDecimal(txtplantexisting.Text) + Convert.ToDecimal(txtplantexpandiver.Text) + Convert.ToDecimal(txtbuildingexisting.Text) + Convert.ToDecimal(txtbuildingexpandiver.Text)) >= 5000000) && ddlapplicationto.SelectedValue != "1")
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Sir/Madam, As Building value and plan & machinery valu exceeds 50,00,000, this application comes under SLC. Please check and select it as SLC');", true);
                            ddlapplicationto.ClearSelection();
                            return;
                        }
                        else if (((Convert.ToDecimal(txtplantexisting.Text) + Convert.ToDecimal(txtplantexpandiver.Text) + Convert.ToDecimal(txtbuildingexisting.Text) + Convert.ToDecimal(txtbuildingexpandiver.Text)) < 5000000) && ddlapplicationto.SelectedValue != "2")
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Sir/Madam, As Building value and plan & machinery valu below 50,00,000, this application comes under DIPC. Please check and select it as DIPC');", true);
                            ddlapplicationto.ClearSelection();
                            return;
                        }
                        else
                        {
                            // ddlapplicationto.Enabled = false;
                            rbtISINSLCORNOT.Enabled = false;
                            rdbCaste.Enabled = false;
                            rdbGender.Enabled = false;
                            rdbCategory.Enabled = false;
                            rdbEnterprise.Enabled = false;
                            rdbSector.Enabled = false;
                        }
                    }
                    else
                    {
                        if (((Convert.ToDecimal(txtplantexisting.Text) + Convert.ToDecimal(txtplantexpandiver.Text)) >= 5000000) && ddlapplicationto.SelectedValue != "1")
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Sir/Madam, As plan and machinery value exceeds 50,00,000, this application comes under SLC. Please check and select it as SLC');", true);
                            ddlapplicationto.ClearSelection();
                            return;
                        }
                        else if (((Convert.ToDecimal(txtplantexisting.Text) + Convert.ToDecimal(txtplantexpandiver.Text)) < 5000000) && ddlapplicationto.SelectedValue != "2")
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Sir/Madam, As plan and machinery value below 50,00,000, this application comes under DIPC. Please check and select it as DIPC');", true);
                            ddlapplicationto.ClearSelection();
                            return;
                        }
                        else
                        {
                           // ddlapplicationto.Enabled = false;
                            rbtISINSLCORNOT.Enabled = false;
                            rdbCaste.Enabled = false;
                            rdbGender.Enabled = false;
                            rdbCategory.Enabled = false;
                            rdbEnterprise.Enabled = false;
                            rdbSector.Enabled = false;
                        }

                    }
                }
                else
                {
                    ddlapplicationto.SelectedValue = "1";
                    ddlapplicationto.Enabled = false;
                    rbtISINSLCORNOT.Enabled = false;
                    rdbCaste.Enabled = false;
                    rdbGender.Enabled = false;
                    rdbCategory.Enabled = false;
                    rdbEnterprise.Enabled = false;
                    rdbSector.Enabled = false;
                }

            }
            //if (HDNINDUSTRYSTATUS.Value == "1" && hdnMSMEApplied.Value == "Y")
            //{

            //    if (Convert.ToDecimal(txtplantexistingNew.Text) >= 5000000 && ddlapplicationto.SelectedValue != "1")
            //    {
            //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Sir/Madam, As plan and machinery value exceeds 50,00,000, this application comes under SLC. Please check and select it as SLC');", true);
            //        ddlapplicationto.ClearSelection();
            //        return;


            //    }
            //    else if (Convert.ToDecimal(txtplantexistingNew.Text) < 5000000 && ddlapplicationto.SelectedValue != "2")
            //    {
            //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Sir/Madam, As plan and machinery value below 50,00,000, this application comes under DIPC. Please check and select it as DIPC');", true);
            //        ddlapplicationto.ClearSelection();
            //        return;


            //    }
            //}
            //if ((HDNINDUSTRYSTATUS.Value == "2" || HDNINDUSTRYSTATUS.Value == "3") && hdnMSMEApplied.Value == "Y")
            //{


            //    if (((Convert.ToDecimal(txtplantexisting.Text) + Convert.ToDecimal(txtplantexpandiver.Text)) >= 5000000) && ddlapplicationto.SelectedValue != "1")
            //    {
            //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Sir/Madam, As plan and machinery value exceeds 50,00,000, this application comes under SLC. Please check and select it as SLC');", true);
            //        ddlapplicationto.ClearSelection();
            //        return;

            //    }
            //    else if (((Convert.ToDecimal(txtplantexisting.Text) + Convert.ToDecimal(txtplantexpandiver.Text)) < 5000000) && ddlapplicationto.SelectedValue != "2")
            //    {
            //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Sir/Madam, As plan and machinery value below 50,00,000, this application comes under DIPC. Please check and select it as DIPC');", true);
            //        ddlapplicationto.ClearSelection();
            //        return;

            //    }



            //}
            //if (HDNINDUSTRYSTATUS.Value == "1" && hdnMSMEApplied.Value == "Y")
            //{
            //    if (rbtISINSLCORNOT.SelectedValue != "Y" && HDNISSANCTIONEDINSLCORNOT.Value != "Y")
            //    {
            //        if ((rdbCaste.SelectedValue == "SC" || rdbCaste.SelectedValue == "ST" || rdbCaste.SelectedValue == "PHC")
            //            && rdbSector.SelectedValue == "Service" && rdbServiceType.SelectedValue == "STNT")
            //        {
            //            if ((Convert.ToDecimal(txtbuildingexistingNew.Text) + Convert.ToDecimal(txtplantexistingNew.Text)) >= 5000000 && ddlapplicationto.SelectedValue != "1")
            //            {
            //                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Sir/Madam, As Building value and plan & machinery value exceeds 50,00,000, this application comes under SLC. Please check and select it as SLC');", true);
            //                ddlapplicationto.ClearSelection();
            //                return;
            //            }
            //            else if ((Convert.ToDecimal(txtbuildingexistingNew.Text) + Convert.ToDecimal(txtplantexistingNew.Text)) < 5000000 && ddlapplicationto.SelectedValue != "2")
            //            {
            //                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Sir/Madam, As Building value and plan & machinery valu below 50,00,000, this application comes under DIPC. Please check and select it as DIPC');", true);
            //                ddlapplicationto.ClearSelection();
            //                return;
            //            }
            //        }
            //        else
            //        {
            //            if (Convert.ToDecimal(txtplantexistingNew.Text) >= 5000000 && ddlapplicationto.SelectedValue != "1")
            //            {
            //                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Sir/Madam, As plan and machinery value exceeds 50,00,000, this application comes under SLC. Please check and select it as SLC');", true);
            //                ddlapplicationto.ClearSelection();
            //                return;
            //            }
            //            else if (Convert.ToDecimal(txtplantexistingNew.Text) < 5000000 && ddlapplicationto.SelectedValue != "2")
            //            {
            //                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Sir/Madam, As plan and machinery value below 50,00,000, this application comes under DIPC. Please check and select it as DIPC');", true);
            //                ddlapplicationto.ClearSelection();
            //                return;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        ddlapplicationto.SelectedValue = "1";
            //        ddlapplicationto.Enabled = false;
            //        rbtISINSLCORNOT.Enabled = false;
            //        txtincentiveapplicationnumber.Enabled = false;
            //    }


            //}
            //if ((HDNINDUSTRYSTATUS.Value == "2" || HDNINDUSTRYSTATUS.Value == "3") && hdnMSMEApplied.Value == "Y")
            //{
            //    if (rbtISINSLCORNOT.SelectedValue != "Y" && HDNISSANCTIONEDINSLCORNOT.Value != "Y")
            //    {
            //        if ((rdbCaste.SelectedValue == "SC" || rdbCaste.SelectedValue == "ST" || rdbCaste.SelectedValue == "PHC")
            //            && rdbSector.SelectedValue == "Service" && rdbServiceType.SelectedValue == "STNT")
            //        {
            //            if (((Convert.ToDecimal(txtplantexisting.Text) + Convert.ToDecimal(txtplantexpandiver.Text) + Convert.ToDecimal(txtbuildingexisting.Text) + Convert.ToDecimal(txtbuildingexpandiver.Text)) >= 5000000) && ddlapplicationto.SelectedValue != "1")
            //            {
            //                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Sir/Madam, As Building value and plan & machinery valu exceeds 50,00,000, this application comes under SLC. Please check and select it as SLC');", true);
            //                ddlapplicationto.ClearSelection();
            //                return;
            //            }
            //            else if (((Convert.ToDecimal(txtplantexisting.Text) + Convert.ToDecimal(txtplantexpandiver.Text) + Convert.ToDecimal(txtbuildingexisting.Text) + Convert.ToDecimal(txtbuildingexpandiver.Text)) < 5000000) && ddlapplicationto.SelectedValue != "2")
            //            {
            //                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Sir/Madam, As Building value and plan & machinery valu below 50,00,000, this application comes under DIPC. Please check and select it as DIPC');", true);
            //                ddlapplicationto.ClearSelection();
            //                return;
            //            }
            //        }
            //        else
            //        {
            //            if (((Convert.ToDecimal(txtplantexisting.Text) + Convert.ToDecimal(txtplantexpandiver.Text)) >= 5000000) && ddlapplicationto.SelectedValue != "1")
            //            {
            //                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Sir/Madam, As plan and machinery value exceeds 50,00,000, this application comes under SLC. Please check and select it as SLC');", true);
            //                ddlapplicationto.ClearSelection();
            //                return;
            //            }
            //            else if (((Convert.ToDecimal(txtplantexisting.Text) + Convert.ToDecimal(txtplantexpandiver.Text)) < 5000000) && ddlapplicationto.SelectedValue != "2")
            //            {
            //                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Sir/Madam, As plan and machinery value below 50,00,000, this application comes under DIPC. Please check and select it as DIPC');", true);
            //                ddlapplicationto.ClearSelection();
            //                return;
            //            }

            //        }
            //    }
            //    else
            //    {
            //        ddlapplicationto.SelectedValue = "1";
            //        ddlapplicationto.Enabled = false;
            //        rbtISINSLCORNOT.Enabled = false;
            //        txtincentiveapplicationnumber.Enabled = false;

            //    }

            //}
            if (LoanAggrementCheck == "1" && casteGenderGmUpdate == "Y")
            {


                if (ddlapplicationto.SelectedValue != "0")
                {
                    foreach (GridViewRow gvrowg in gvinspectionOfficer.Rows)
                    {
                        Button Button1 = ((Button)gvrowg.FindControl("Button1"));
                        Button Button2 = ((Button)gvrowg.FindControl("Button2"));
                        DropDownList ddlapprove = (DropDownList)gvrowg.FindControl("ddlapprove");
                        Button Buttonotp = ((Button)gvrowg.FindControl("btnotp"));

                        if (ddlapplicationto.SelectedValue == "1")
                        {
                            if (ddlapprove.SelectedValue != "1")
                            {
                                Button1.Visible = true;
                                Button2.Visible = false;
                                // gvinspectionOfficer.Columns[11].Visible = true;
                                gvinspectionOfficer.Columns[12].Visible = true;
                                ScriptManager.GetCurrent(this).RegisterPostBackControl(Button1);
                            }
                        }
                        else if (ddlapplicationto.SelectedValue == "2")
                        {
                            if (ddlapprove.SelectedValue == "3")
                            {
                                Button1.Visible = true;
                                Button2.Visible = false;
                                // gvinspectionOfficer.Columns[11].Visible = true;
                                gvinspectionOfficer.Columns[12].Visible = true;
                                ScriptManager.GetCurrent(this).RegisterPostBackControl(Button1);
                            }
                            else if (ddlapprove.SelectedValue != "1")
                            {
                                Button1.Visible = false;
                                Button2.Visible = true;
                                // gvinspectionOfficer.Columns[11].Visible = false;
                                gvinspectionOfficer.Columns[12].Visible = false;
                                ScriptManager.GetCurrent(this).RegisterPostBackControl(Button2);
                            }
                        }
                    }
                }
                else
                {
                    foreach (GridViewRow gvrowg in gvinspectionOfficer.Rows)
                    {
                        Button Button1 = ((Button)gvrowg.FindControl("Button1"));
                        Button Button2 = ((Button)gvrowg.FindControl("Button2"));
                        Button1.Visible = false;
                        Button2.Visible = false;
                    }
                }
            }

        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    //adde newly
    protected void lnkapplntotalprint_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "window.open('../../UI/Tsipass/CompleteApplicationForm.aspx?EntrpId=" + Request.QueryString[0].ToString() + "','null','height=500,width=800,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');", true);
        //Response.Redirect("../../UI/TSiPASS/IncentivesAnnexures/AnnexInvestSubsidyS.aspx");
    }

    protected void gvquerygm_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //if (e.Row.RowState.Equals(DataControlRowState.Edit))
                //{
                string forQueryFlag = "";
                TextBox txtIncQueryFnl5 = e.Row.FindControl("txtIncQueryFnl5") as TextBox;


                Button btnUpload = e.Row.FindControl("btnsendcoi") as Button;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(btnUpload);
                // }

                Button btncoigmraisequery = e.Row.FindControl("btncoigmraisequery") as Button;

                Label ResponceApps = e.Row.FindControl("lblenterresp") as Label;
                if (ResponceApps.Text.Trim() == "")
                {
                    btncoigmraisequery.Visible = false;
                }

                string gmquerystatus = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GMstatus"));
                //if (gmquerystatus == "GMQUERYRAISED") --changed
                if (gmquerystatus == "GMQUERYRAISED" && ResponceApps.Text.ToString() != "")   //added newly..
                {
                    //btncoigmraisequery.Visible = false;
                    btncoigmraisequery.Visible = true;  //changed
                    //btnUpload.Visible = false;  --changed
                    btnUpload.Visible = true;
                }
                if (gmquerystatus == "" && ResponceApps.Text.ToString() == "") //added newly..
                {
                    btncoigmraisequery.Visible = false;
                    //btnUpload.Visible = false;
                    btnUpload.Enabled = false;
                    btnUpload.Text = "Query not responded";
                }
                if (txtIncQueryFnl5.Text == "QueryGM")
                {
                    forQueryFlag = "Y";
                    txtIncQueryFnl5.Text = "";
                    btnUpload.Enabled = true;
                    btnUpload.Visible = true;
                    btncoigmraisequery.Visible = false;
                    btnUpload.Text = "Send Response to COI";


                }
                Label lblQueryCreatedBy = e.Row.FindControl("lblQueryCreatedBy") as Label;
                HyperLink hpquerylinkcoi = e.Row.FindControl("hpquerylinkcoi") as HyperLink;
                if (lblQueryCreatedBy.Text.Trim() == "3377")
                {
                    hpquerylinkcoi.NavigateUrl = "ProformaQueryRaiseShortFallLetter.aspx?incentiveid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EnterperIncentiveID")) + "&IncIds=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MstIncentiveId"));
                }
                else if (lblQueryCreatedBy.Text.Trim() == "21345")
                {
                    hpquerylinkcoi.NavigateUrl = "ProformaQueryRaiseShortFallLetterAddl.aspx?incentiveid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EnterperIncentiveID")) + "&IncIds=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MstIncentiveId"));
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    //protected void gvquerygmtbyIO_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        //if (e.Row.RowState.Equals(DataControlRowState.Edit))
    //        //{
    //        Button btnUpload = e.Row.FindControl("btnsendcoiIO") as Button;
    //        ScriptManager.GetCurrent(this).RegisterPostBackControl(btnUpload);

    //        Button btnUpload2 = e.Row.FindControl("btnsendIOQuerybyGM") as Button;
    //        ScriptManager.GetCurrent(this).RegisterPostBackControl(btnUpload2);
    //        // }
    //    }
    //}
    protected void gvquerygmtbyIO_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //if (e.Row.RowState.Equals(DataControlRowState.Edit))
                //{
                Button btnUpload = e.Row.FindControl("btnsendcoiIO") as Button;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(btnUpload);

                Button btnUpload2 = e.Row.FindControl("btnsendIOQuerybyGM") as Button;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(btnUpload2);


                int indexing = e.Row.RowIndex;
                Label lblIOQuerySts = (e.Row.FindControl("lblIoQuerySts") as Label);
                // lblIOQuerySts = (Label)gvquerygmtbyIO.Rows[indexing].FindControl("lblIoQuerySts");
                if (lblIOQuerySts.Text == "1")
                {
                    Button btnIOqueryfwdtoApplicant = (e.Row.FindControl("btnsendcoiIO") as Button); //(Button)gvquerygmtbyIO.Rows[indexing].FindControl("btnsendcoiIO");
                    btnIOqueryfwdtoApplicant.Enabled = false;

                    Button btnIOQueryResponsebyGMtoIO = (e.Row.FindControl("btnsendIOQuerybyGM") as Button); // (Button)gvquerygmtbyIO.Rows[indexing].FindControl("btnsendIOQuerybyGM");
                    btnIOQueryResponsebyGMtoIO.Enabled = false;
                }
                else if (lblIOQuerySts.Text == "2")  // added newly by chhh on 05.12.2017
                {
                    Button btnIOqueryfwdtoApplicant = (e.Row.FindControl("btnsendcoiIO") as Button); //(Button)gvquerygmtbyIO.Rows[indexing].FindControl("btnsendcoiIO");
                    btnIOqueryfwdtoApplicant.Enabled = true;

                    Button btnIOQueryResponsebyGMtoIO = (e.Row.FindControl("btnsendIOQuerybyGM") as Button); // (Button)gvquerygmtbyIO.Rows[indexing].FindControl("btnsendIOQuerybyGM");
                    btnIOQueryResponsebyGMtoIO.Enabled = false;
                }
                else
                {
                    Button btnIOqueryfwdtoApplicant = (e.Row.FindControl("btnsendcoiIO") as Button); //(Button)gvquerygmtbyIO.Rows[indexing].FindControl("btnsendcoiIO");
                    btnIOqueryfwdtoApplicant.Enabled = true;

                    Button btnIOQueryResponsebyGMtoIO = (e.Row.FindControl("btnsendIOQuerybyGM") as Button); // (Button)gvquerygmtbyIO.Rows[indexing].FindControl("btnsendIOQuerybyGM");
                    btnIOQueryResponsebyGMtoIO.Enabled = true;

                    //Button btnIOqueryfwdtoApplicant = (Button)gvquerygmtbyIO.Rows[indexing].FindControl("btnsendcoiIO");
                    //btnIOqueryfwdtoApplicant.Enabled = true;

                    //Button btnIOQueryResponsebyGMtoIO = (Button)gvquerygmtbyIO.Rows[indexing].FindControl("btnsendIOQuerybyGM");
                    //btnIOQueryResponsebyGMtoIO.Enabled = true;
                }
                // }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    // added by chh  on 17.10.2017
    protected void btnsendcoiIO_Click(object sender, EventArgs e)
    {
        try
        {
            lstremarks.Clear();
            //foreach (GridViewRow gvrow in gvquerygm.Rows)
            //{
            officerRemarks fromvo = new officerRemarks();
            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            // int rowIndex = gvrow.RowIndex;

            fromvo.EnterperIncentiveID = ((Label)gvquerygmtbyIO.Rows[indexing].FindControl("lblIncentiveID")).Text.ToString();
            fromvo.MstIncentiveId = ((Label)gvquerygmtbyIO.Rows[indexing].FindControl("lblMstIncentiveId")).Text.ToString();
            fromvo.id = ((Label)gvquerygmtbyIO.Rows[indexing].FindControl("lblid")).Text.ToString();
            fromvo.Remarks = "";
            fromvo.CreatedByid = Session["uid"].ToString();
            fromvo.id = ((Label)gvquerygmtbyIO.Rows[indexing].FindControl("lblid")).Text.ToString();

            string txtIncQueryFnl5 = ((TextBox)gvquerygmtbyIO.Rows[indexing].FindControl("txtIncQueryFnl5")).Text;

            fromvo.Responce = txtIncQueryFnl5;
            if (txtIncQueryFnl5.Trim().TrimStart() == "")
            {
                string messagenew = "alert('Kindly Enter Remarks')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", messagenew, true);
                return;
            }
            lstremarks.Add(fromvo);
            // }
            int valid = Gen.InsertincentiveOfficerCommentsGMResponcetoIO(lstremarks, getclientIP());
            //lblmsg.Text = "<font color='green'>Response Submitted Successfully..!</font>";
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Response Submitted Successfully');", true);
            //success.Visible = true;
            //Failure.Visible = false;
            try
            {
                FileUpload FileUpload1 = (FileUpload)gvquerygmtbyIO.Rows[indexing].FindControl("FileUploadquery");

                string newPath = "";

                General t1 = new General();
                if (FileUpload1.HasFile)
                {
                    string incentiveid = fromvo.EnterperIncentiveID;

                    if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
                    {
                        string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                        try
                        {
                            string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                            int i = fileType.Length;
                            if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                            {
                                string serverpath = Server.MapPath("~\\ResponseAttachmentforIcentive\\" + incentiveid.ToString() + "\\COIQuery" + fromvo.MstIncentiveId);  // incentiveid2
                                if (!Directory.Exists(serverpath))
                                    Directory.CreateDirectory(serverpath);

                                FileUpload1.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                                string CrtdUser = Session["uid"].ToString();

                                string Path = serverpath;
                                string FileName = sFileName;
                                ViewState["AttachmentName"] = sFileName;
                                ViewState["pathAttachment"] = serverpath;
                                string Attachmentidnew = incentiveid + fromvo.MstIncentiveId + DateTime.Now.Minute + DateTime.Now.Second;

                                t1.InsertIncentiveAttachmentQueryResponse(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, fromvo.MstIncentiveId, getclientIP());
                            }
                            else
                            {

                            }
                        }
                        catch (Exception ex)//in case of an error
                        {
                            DeleteFile(newPath + "\\" + sFileName);
                            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
            string message = "alert('Response Forwarded to Inspecting Officer Successfully')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    //added by chhh on 18.10.2017 forward IO query to applicant by GM
    protected void btnsendIOQuerybyGM_Click(object sender, EventArgs e)
    {

        try
        {
            string Incentiveslist = "";
            string intApplicationidtop = "";
            int countno = 1;
            foreach (GridViewRow gvrow in gvquerygmtbyIO.Rows)
            {
                string intApplicationid, Deptname, Modified_by, EMiUdyogAadhar, SentFrom, Status, MstIncentiveId, txtIncQuery, txtinspectiondate, Deptname1new;

                intApplicationid = ((Label)gvrow.FindControl("lblIncentiveID")).Text.ToString();
                intApplicationidtop = intApplicationid;
                MstIncentiveId = ((Label)gvrow.FindControl("lblMstIncentiveId")).Text.ToString();

                //  txtIncQuery = ((TextBox)gvrow.FindControl("txtIncQueryFnl5")).Text.ToString();
                // Remarks
                // txtIncQuery = ((Label)gvrow.FindControl("lblRemarks")).Text.ToString(); COMMENTED BY MADHURI ON 23/11/2024 TO SEND ADDITIONAL QUERY REMARKS IF ANY ADDED
                txtIncQuery = ((TextBox)gvrow.FindControl("txtIncQueryFnl5")).Text.ToString();
                if (txtIncQuery.Trim().TrimStart().TrimEnd() == "" || txtIncQuery.Trim().TrimStart().TrimEnd() == null)
                {
                    txtIncQuery = ((Label)gvrow.FindControl("lblRemarks")).Text.ToString();
                }
                Modified_by = Session["uid"].ToString();
                SentFrom = Session["User_Code"].ToString();
                Status = "3";

                // if (ViewState["DisignationLoad"].ToString().Trim() == "GM")  commented on 21.10.2017
                if (Session["Role_Code"].ToString().Trim().TrimStart() == "GM")
                {
                    int incRtrVal = Gen.insertInctveQueryResponsedataNewIOQuery(intApplicationid, txtIncQuery, Modified_by, MstIncentiveId, getclientIP());

                    string IncentiveName = gvrow.Cells[1].Text;
                    try
                    {
                        SendSmsEmail(txtIncQuery, IncentiveName);
                    }
                    catch (Exception ex)
                    {
                        LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
                    }
                }
            }

            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            Button btnIOqueryfwdtoApplicant = (Button)gvquerygmtbyIO.Rows[indexing].FindControl("btnsendcoiIO");
            btnIOqueryfwdtoApplicant.Enabled = false;

            Button btnIOQueryResponsebyGMtoIO = (Button)gvquerygmtbyIO.Rows[indexing].FindControl("btnsendIOQuerybyGM");
            btnIOQueryResponsebyGMtoIO.Enabled = false;

            string message = "alert('Query Forwarded to Applicant Successfully')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);



            trgmtoenterquery.Visible = true;
            hplink.NavigateUrl = "ProformaQueryRaiseShortFallLetterGMtoApplicant.aspx?incentiveid=" + intApplicationidtop;
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    //public DataSet getJDRejectedList(string incentiveid, string mstincentiveid)
    //{
    //    con.OpenConnection();
    //    SqlDataAdapter da;
    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        da = new SqlDataAdapter("USP_GET_JD_REJECTED_DTLS", con.GetConnection);
    //        da.SelectCommand.CommandType = CommandType.StoredProcedure;

    //            da.SelectCommand.Parameters.Add("@INCENTIVEID", SqlDbType.VarChar).Value = incentiveid.ToString();          
    //        if (incentiveid != null && incentiveid != null)
    //        {
    //            da.SelectCommand.Parameters.Add("@MSTINCENTVEID", SqlDbType.VarChar).Value = mstincentiveid.ToString();
    //        }
    //        else {
    //            da.SelectCommand.Parameters.Add("@MSTINCENTVEID", SqlDbType.VarChar).Value = null;
    //        }
    //        da.Fill(ds);
    //        return ds;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        con.CloseConnection();
    //    }
    //}



    // added by chh on 11.01.2018
    protected void gvHoldApplications_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int rowww = e.RowIndex;
            string idnew = ((Label)gvHoldApplications.Rows[e.RowIndex].FindControl("lblid")).Text.ToString().Trim();
            string IncentiveName = gvHoldApplications.Rows[e.RowIndex].Cells[2].Text;
            string lblMstIncentiveId = ((Label)gvHoldApplications.Rows[e.RowIndex].FindControl("lblMstIncentiveId")).Text.ToString().Trim();

            ListItem li = new ListItem();
            li.Text = IncentiveName;
            li.Value = lblMstIncentiveId;

            ddlstaire.Items.Add(li);

            if (idnew != "0" && idnew != "")
            {
                int validremaeks = Gen.deleteGroupSavingDataincentive(idnew);

            }
            if (gvHoldApplications.Rows.Count == 1)
            {
                trReject.Visible = false;
                Button3.Visible = false;
                trrejectedtls.Visible = false;
            }
            ((DataTable)Session["CertificateTbReject"]).Rows.RemoveAt(e.RowIndex);
            this.gvHoldApplications.DataSource = ((DataTable)Session["CertificateTbReject"]).DefaultView;
            this.gvHoldApplications.DataBind();
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Please enter correct data";// ex.ToString();
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());

        }
        finally
        {

        }
    }


    protected void btnGmReject_Click(object sender, EventArgs e)
    {
        try
        {
            int errorcount = 0;
            foreach (GridViewRow gvrow in GridView4.Rows)
            {
                string txtIncQuery = ((TextBox)gvrow.FindControl("txtIncQueryFnl")).Text.ToString();
                if (txtIncQuery.Trim() == "") { errorcount = errorcount + 1; }
            }

            if (errorcount == 0)
            {
                string Incentiveslist = "";
                string intApplicationidtop = "";
                int countno = 1;
                foreach (GridViewRow gvrow in GridView4.Rows)
                {
                    string intApplicationid, Deptname, Modified_by, EMiUdyogAadhar, SentFrom, Status, MstIncentiveId, txtIncQuery, txtinspectiondate, Deptname1new;

                    intApplicationid = ((Label)gvrow.FindControl("lblIncentiveID")).Text.ToString();
                    intApplicationidtop = intApplicationid;
                    MstIncentiveId = ((Label)gvrow.FindControl("lblMstIncentiveId")).Text.ToString();
                    txtIncQuery = ((TextBox)gvrow.FindControl("txtIncQueryFnl")).Text.ToString();
                    Modified_by = Session["uid"].ToString();
                    SentFrom = Session["User_Code"].ToString();

                    if (ViewState["DisignationLoad"].ToString().Trim() == "GM")
                    {
                        int incRtrVal = Gen.insertRejectIncentives(intApplicationid, txtIncQuery, Modified_by, MstIncentiveId, getclientIP());
                        bindGMGrids("0");
                        btnGmReject.Visible = false;
                        string IncentiveName = gvrow.Cells[1].Text;
                        try
                        {
                            SendRejectSmsEmail(txtIncQuery, IncentiveName, "GM");
                        }
                        catch (Exception ex)
                        {
                            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
                        }
                    }
                }

                string message = "alert('Rejected Successfully')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                trGmReject.Visible = false;
            }
            else
            {
                string message = "alert('Please Enter Reject Reason')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }




        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }


    public void bindGMGrids(string id)
    {

        try
        {
            //Gm Grids

            string Applicantinid = Request.QueryString[0].ToString();
            string Status = Request.QueryString[1].ToString();
            string Userid = Session["uid"].ToString();

            ds = Gen.GetIncetiveDetailsdept(Applicantinid, Status, Userid, Userid, null);


            if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
            {

                for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                {
                    foreach (GridViewRow gvrow in grdDetails.Rows)
                    {
                        if (id != "0")
                        {
                            string MstIncentiveId = id;
                            Label lblMstIncentiveId = (Label)gvrow.FindControl("lblMstIncentiveId");
                            if (lblMstIncentiveId.Text.Trim() == MstIncentiveId)
                            {
                                RadioButtonList ddlofficernew = (RadioButtonList)gvrow.FindControl("rdbyesno");
                                ddlofficernew.SelectedValue = "Y";
                                ddlofficernew.Enabled = false;
                            }
                        }
                    }
                }


                trAssignedInspectingOfficerincentives.Visible = true;
                gvassigncompleted.DataSource = ds.Tables[2];   // incentive which are assigned
                gvassigncompleted.DataBind();
                string inspectionofficer = ds.Tables[2].Rows[0]["InspectionAssignTo"].ToString();
                ddlDeptname.SelectedValue = inspectionofficer;
                ddlDeptname.Enabled = false;

            }

            if (ds != null && ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
                {
                    foreach (GridViewRow gvrow in grdDetails.Rows)
                    {
                        string MstIncentiveId = ds.Tables[3].Rows[i]["MstIncentiveId"].ToString();
                        Label lblMstIncentiveId = (Label)gvrow.FindControl("lblMstIncentiveId");
                        if (lblMstIncentiveId.Text.Trim() == MstIncentiveId)
                        {
                            RadioButtonList ddlofficernew = (RadioButtonList)gvrow.FindControl("rdbyesno");
                            ddlofficernew.SelectedValue = "N";
                            ddlofficernew.Enabled = false;
                        }
                    }
                }

                GridView2.DataSource = ds.Tables[3];
                GridView2.DataBind();
                trgmtoenterquery.Visible = true;
                hplink.NavigateUrl = "ProformaQueryRaiseShortFallLetterGMtoApplicant.aspx?incentiveid=" + Applicantinid;
            }


            if (ds != null && ds.Tables.Count > 5 && ds.Tables[5].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[5].Rows.Count; i++)
                {
                    foreach (GridViewRow gvrow in grdDetails.Rows)
                    {
                        string MstIncentiveId = ds.Tables[5].Rows[i]["MstIncentiveId"].ToString();
                        Label lblMstIncentiveId = (Label)gvrow.FindControl("lblMstIncentiveId");
                        if (lblMstIncentiveId.Text.Trim() == MstIncentiveId)
                        {
                            RadioButtonList ddlofficernew = (RadioButtonList)gvrow.FindControl("rdbyesno");
                            ddlofficernew.SelectedValue = "R";
                            ddlofficernew.Enabled = false;
                        }
                    }
                }
                GridView4.DataSource = ds.Tables[5];
                GridView4.DataBind();
                btnGmReject.Visible = false;
            }
            Button6.Visible = false;
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }



    public void SendRejectSmsEmail(string querydesc, string incentivename, string Role)
    {
        try
        {
            DataSet dsAppliedIncentives = new DataSet();
            string UnitName = "", UnitMobileNo = "", UnitEmail = "", ApplicantName = "", DistrictName = "", QueryRaisedDate = "";

            UnitName = txtUnitname1.Text;
            ApplicantName = txtApplicantName1.Text;
            UnitEmail = txtunitemailid1.Text;
            UnitMobileNo = txtunitmobileno1.Text;
            DistrictName = ddldistrictunit1.Text;
            QueryRaisedDate = DateTime.Now.ToString("dd/MM/yyyy");



            string nameuid = UnitEmail.Replace("@", "(at)");
            try
            {
                if (Role == "GM")
                {
                    cmf.SendMailIncentive(UnitEmail, "Dear " + UnitName + ", Your incentive  application rejected on " + QueryRaisedDate + ", and Rejected incentive : " + incentivename + ", and rejected description is  " + querydesc + ", <br /> Thank You, GM, DIC -" + DistrictName + ",<br />  Govt. of Telangana.");
                }
                else if (Role == "JD")
                {
                    cmf.SendMailIncentive(UnitEmail, "Dear " + UnitName + ", Your incentive  application rejected on " + QueryRaisedDate + ", and Rejected incentive : " + incentivename + ", and rejected description is  " + querydesc + ", <br /> Thank You, JD-INCENTIVES, COI,<br />  Govt. of Telangana.");
                }
            }
            catch (Exception ex)
            {
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
            try
            {
                if (Role == "GM")
                {
                    //cmf.SendSingleSMS(UnitMobileNo, "Dear " + UnitName + ", Your incentive  application rejected on " + QueryRaisedDate + ", and Rejected incentive : " + incentivename + ",  a detail mail is sent to " + nameuid + "," + '\n' + "Thank You," + '\n' + "GM, DIC -" + DistrictName + "," + '\n' + "Govt. of Telangana.");
                }
                else if (Role == "JD")
                {
                    //cmf.SendSingleSMS(UnitMobileNo, "Dear " + UnitName + ", Your incentive  application rejected on " + QueryRaisedDate + ", and Rejected incentive : " + incentivename + ", a detail mail is sent to " + nameuid + "," + '\n' + "Thank You," + '\n' + "JD-INCENTIVES, COI," + '\n' + "Govt. of Telangana.");
                }
            }
            catch (Exception ex)
            {
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void btncoigmraisequery_Click(object sender, EventArgs e)
    {
        try
        {
            lstremarks.Clear();

            officerRemarks fromvo = new officerRemarks();
            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;

            fromvo.EnterperIncentiveID = ((Label)gvquerygm.Rows[indexing].FindControl("lblIncentiveID")).Text.ToString();
            fromvo.MstIncentiveId = ((Label)gvquerygm.Rows[indexing].FindControl("lblMstIncentiveId")).Text.ToString();
            fromvo.id = ((Label)gvquerygm.Rows[indexing].FindControl("lblid")).Text.ToString();
            fromvo.Remarks = "";
            fromvo.CreatedByid = Session["uid"].ToString();
            fromvo.id = ((Label)gvquerygm.Rows[indexing].FindControl("lblid")).Text.ToString();
            string txtIncQueryFnl5 = ((TextBox)gvquerygm.Rows[indexing].FindControl("txtIncQueryFnl5")).Text;
            fromvo.Responce = txtIncQueryFnl5;
            if (txtIncQueryFnl5.Trim().TrimStart() == "")
            {
                string messagenew = "alert('Kindly Enter the Remarks')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", messagenew, true);
                return;
            }
            lstremarks.Add(fromvo);
            // }
            int valid = Gen.InsertincentiveOfficerCommentsGMQuery(lstremarks, getclientIP());

            Button btnsubmit = ((Button)gvquerygm.Rows[indexing].FindControl("btncoigmraisequery"));
            Button btnsubmitcoi = ((Button)gvquerygm.Rows[indexing].FindControl("btnsendcoi"));
            btnsubmit.Enabled = false;
            btnsubmitcoi.Enabled = false;
            string messagenew1 = "alert('Query Submited Successfully')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", messagenew1, true);
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }


    protected void Gvoldapplications_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblIncentiveID = (e.Row.FindControl("lblIncentiveID") as Label);
                // (e.Row.FindControl("anchortaglinkOldapplication") as HyperLink).NavigateUrl = "ApplicantIncentiveDetailsView.aspx?EntrpId=" + lblIncentiveID.Text + "&Role=1";
                (e.Row.FindControl("anchortaglinkOldapplication") as HyperLink).NavigateUrl = "ApplicantIncentiveDtlsDraftView.aspx?EntrpId=" + lblIncentiveID.Text + "&Role=1";
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void gvpostsvc_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label enterid = (e.Row.FindControl("Label11") as Label);
            Label MstIncentiveId = (e.Row.FindControl("Label10") as Label);

            Label lblScheme = (e.Row.FindControl("lblScheme") as Label);
            Label lblDIPCNumer = (e.Row.FindControl("lblDIPCNumer") as Label);
            Label lblOfflineFlag = (e.Row.FindControl("lblOfflineFlag") as Label);
            Label lbloffiline = (e.Row.FindControl("lbloffiline") as Label);


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
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantStampDutySubsidy.aspx?incentiveid=" + enterid.Text.Trim() + "&Scheme=" + lblScheme.Text.Trim() + "&DIPCNumer=" + lblDIPCNumer.Text.Trim();
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

            if (lblDIPCNumer.Text.Trim() == "")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).Visible = false;
                lbloffiline.Visible = true;
                lbloffiline.Text = "Pending";
            }
            else
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).Visible = true;
                lbloffiline.Visible = false;
                lbloffiline.Text = "";
            }

            //string ssss = DataBinder.Eval(e.Row.DataItem, "RecommendedAmount").ToString();
            //if (ssss != null && ssss != "")
            //{
            //    decimal Recommended1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "RecommendedAmount"));
            //    Recommended = Recommended1 + Recommended;
            //}
            //string bbbb = DataBinder.Eval(e.Row.DataItem, "SanctionedAmount").ToString();
            //if (bbbb != null && bbbb != "")
            //{
            //    decimal Sanctioned1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SanctionedAmount"));
            //    Sanctioned = Sanctioned1 + Sanctioned;
            //}
        }
        //if (e.Row.RowType == DataControlRowType.Footer)
        //{
        //    e.Row.Cells[3].Text = "Total";
        //    e.Row.Cells[4].Text = Recommended.ToString();
        //    e.Row.Cells[5].Text = Sanctioned.ToString();

        //    //e.Row.Font.Bold = true;
        //}
    }

    protected void GridView8_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnUpload = e.Row.FindControl("btnsendcoiadd") as Button;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(btnUpload);
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void gvpendingapplications_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lblQueryCreatedBy = e.Row.FindControl("lblCreatedByid") as Label;  // CreatedByid
        Label Appstatus = e.Row.FindControl("lblstatus") as Label;
        HyperLink hpquerylinkcoi = e.Row.FindControl("hpquerylinkcoi") as HyperLink;
        //if (lblQueryCreatedBy.Text.Trim() == "3377")

        if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CreatedByid")) == "3377")
        {
            if (Appstatus.Text != "SSC")
            {
                hpquerylinkcoi.NavigateUrl = "ProformaQueryRaiseShortFallLetter.aspx?incentiveid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EnterperIncentiveID")) + "&IncIds=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MstIncentiveId"));
            }
            else
            {
                hpquerylinkcoi.Visible = false;
                hpquerylinkcoi.Text = "";
            }
        }

        else if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CreatedByid")) == "21345")
        {
            hpquerylinkcoi.NavigateUrl = "ProformaQueryRaiseShortFallLetterAddl.aspx?incentiveid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EnterperIncentiveID")) + "&IncIds=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MstIncentiveId"));
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
                //int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
                ////string txtrecomandedamount = gvinspectionOfficer.Rows[0].Cells[7].Text.Trim();
                //string txtrecomandedamount = ((TextBox)gvinspectionOfficer.Rows[indexing].FindControl("txtrecomandedamount")).Text;
                //TextBox txtOTPVerify = ((TextBox)gvinspectionOfficer.Rows[indexing].FindControl("txtOTPVerify"));

                string UnitName = txtUnitname1.Text;
                string msgMobile = "Dear " + dsdept.Tables[0].Rows[0]["Emp_Name"].ToString() + "\r\n" + "" + "Your OTP is : '" + finalOTPMobile + "'" + "\r\n" + "Please Confirm the Recommended Amount and details are correct before sending to COI for unit name " + UnitName + gvinspectionOfficer.Rows[0].Cells[1].Text.Trim();
                msgMobile = msgMobile + "\r\n" + "\r\n" + "\r\n" + "Commissionerate of Industries," + "\n" + "TS-iPASS .";

                string bodyMobile = msgMobile;
                SendSingleSMSnew(dsdept.Tables[0].Rows[0]["MobileNumber"].ToString(), bodyMobile, "1007718233671294577");
                //SendSingleSMSnew("9618445500", bodyMobile);
                // Button1.Text = "Click Here To Register";
                HDFmsgOTP.Value = strOTPMobile;
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


            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            //string txtrecomandedamount = gvinspectionOfficer.Rows[0].Cells[7].Text.Trim();
            string txtrecomandedamount = ((TextBox)gvinspectionOfficer.Rows[indexing].FindControl("txtrecomandedamount")).Text;
            TextBox txtOTPVerify = ((TextBox)gvinspectionOfficer.Rows[indexing].FindControl("txtOTPVerify"));
            Button Button1 = ((Button)gvinspectionOfficer.Rows[indexing].FindControl("Button1"));
            Button Button2 = ((Button)gvinspectionOfficer.Rows[indexing].FindControl("Button2"));
            Button Button3otp = ((Button)gvinspectionOfficer.Rows[indexing].FindControl("btnotp"));// (Button)row.FindControl("btnotp");
            // HiddenField HDFmsgOTP = ((HiddenField)gvinspectionOfficer.Rows[indexing].FindControl("HDFmsgOTP"));

            if (txtOTPVerify.Text == HDFmsgOTP.Value.ToString())
            {
                // Button1_Click(sender, e);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('OTP Verification Successful. Please proceed further.');", true);
                Button1.Enabled = true;
                Button3otp.Enabled = false;
                //BtnSave1.Visible = false;

                //Button1.Enabled = false;
                txtOTPVerify.Enabled = false;
                if (ddlapplicationto.SelectedIndex == 1)
                {
                    Button1.Enabled = true;
                    Button2.Enabled = false;
                }
                //Button1.Enabled = true;

            }
            else
            {
                Button1.Enabled = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter valid OTP received on your mobile no !!.');", true);
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    public String SendSingleSMSneww(String mobileNo, String message)
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

            //client.Credentials = new System.Net.NetworkCredential(from, "tsipass@2016");
            //client.Credentials = new System.Net.NetworkCredential(from, "zwcq vlxk gyor lpeg");
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
                //Exception ex2 = ex;
                //string errorMessage = string.Empty;
                //while (ex2 != null)
                //{
                //    errorMessage += ex2.ToString();
                //    ex2 = ex2.InnerException;
                //}
                //HttpContext.Current.Response.Write(errorMessage);
            }
        }
        catch (Exception ex)
        {
            ////lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
        }
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
    protected void btnotp_Click(object sender, EventArgs e)
    {
        //txtOTPVerify.Enabled = true;
        try
        {
            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            //string txtrecomandedamount = gvinspectionOfficer.Rows[0].Cells[7].Text.Trim();
            string txtrecomandedamount = ((TextBox)gvinspectionOfficer.Rows[indexing].FindControl("txtrecomandedamount")).Text;
            TextBox txtOTPVerify = ((TextBox)gvinspectionOfficer.Rows[indexing].FindControl("txtOTPVerify"));
            string IncentiveName = ((Label)gvinspectionOfficer.Rows[indexing].FindControl("lblIncentiveNameDis")).Text;// gvinspectionOfficer.Rows[indexing].Cells[1].Text;
            if (IncentiveName == "Sales TAX(VAT/GST/SGST) Reimbursement")
            {
                IncentiveName = "Sales TAX(GST/SGST) Reimbursement";
            }
            if (IncentiveName == "Reimbursement of stamp Duty/Transfer Duty/Mortgage/Land Conversion/Land Cost" || IncentiveName == "Reimbursement of stamp Duty/Transfer Duty")
            {
                IncentiveName = "Reimbursement of stampDuty/TransferDuty";
            }
            if (IncentiveName == "Reimbursement of all expenses incurred for Quality Certification/Patent Registration")
            {
                IncentiveName = "Reimbursement of Quality Certification";
            }
            //TextBox txtrecomandedamount = (TextBox)row.FindControl("txtOTPVerify");
            if (txtrecomandedamount != "")
            {
                DataSet ds = new DataSet();
                ds = GetGMMobileNumber(Session["uid"].ToString());
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    //OTPMobile();
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
                        HDFmsgOTP.Value = strOTPMobile;
                        //////mobile message purpose
                        DataSet dsdept = new DataSet();
                        dsdept = GetGMMobileNumber(Session["uid"].ToString());
                        if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                        {

                            string UnitName = txtUnitname1.Text;
                            if (UnitName.Length > 30)
                                UnitName = UnitName.Substring(0, 29);
                            if (UnitName == "CRONUS PHARMA SPECIALITIES INDIA PRIVATE LIMITED")
                            {
                                UnitName = "CRONUS PHARMA SPECIALITIES INDIA PVT LTD";
                            }
                            if (UnitName == "DCM SHRIRAM LTD-FENESTA  BUILDING SYSTEMS DIVISION")
                            {
                                UnitName = "DCM SHRIRAM LTD";

                            }
                            if (UnitName == "PRATYUSHA ENGINEERING INDUSTRIES EXPANSION")
                            {
                                UnitName = "PRATYUSHA ENGINEERING INDUSTRIES EXP";
                            }
                            if (UnitName == "INDIGO PRE ENGINEERED BUILDINGS PRIVATE LIMITED")
                            {
                                UnitName = "INDIGO PRE ENGINEERED BUILDINGS PVT LTD";
                            }
                            if (UnitName == "VIBRANT CONSTRUCTION EQUIPMENTS PRIVATE LIMITED")
                            {
                                UnitName = "VIBRANT CONSTRUCTION EQUIPMENTS PVT LTD";
                            }
                            if (UnitName == "M/S. PADIGELA SRAVANTHI EXPANSION – II")
                            {
                                UnitName = "PADIGELA SRAVANTHI EXPANSION-2";
                            }

                            if (UnitName == "M/S. PADIGELA SRAVANTHI EXPANSION – I")
                            {
                                UnitName = "PADIGELA SRAVANTHI EXPANSION-I";
                            }
                            if (IncentiveName.Contains("/"))
                            {
                                IncentiveName = IncentiveName.Replace("/", " ");
                            }
                            string msgMobile = "Dear " + dsdept.Tables[0].Rows[0]["Emp_Name"].ToString() + "\r\n" + "" + "Your OTP is : '" + finalOTPMobile + "'" + "\r\n" + "Please Confirm the Recommended Amount " + txtrecomandedamount + " and details before sending to COI for unit name " + UnitName + " - " + IncentiveName + " (" + lblApplicationNo.Text + ")";
                            msgMobile = msgMobile + "\r\n" + "\r\n" + "\r\n" + "Commissionerate of Industries," + "\n" + "TS-iPASS .";

                            string bodyMobile = msgMobile;
                            SendSingleSMSnew(dsdept.Tables[0].Rows[0]["MobileNumber"].ToString(), bodyMobile, "1007718233671294577");
                            sendOTPMail(dsdept.Tables[0].Rows[0]["EmailId"].ToString(), bodyMobile);
                            //string test = dsdept.Tables[0].Rows[0]["EmailId"].ToString();
                            string message = "alert('An OTP is sent to your mobile & email.Pl enter it to verify')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                            txtOTPVerify.Visible = true;
                            txtOTPVerify.Enabled = true;

                            return;


                            //ScriptManager.RegisterStartupScript
                            //(this, this.GetType(), "alert", "alert('An OTP has been sent to your email id : '" + test + "'. Please enter it to verify.');", true);
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('An OTP has been sent to your email id: '" + dsdept.Tables[0].Rows[0]["EmailId"].ToString() + "'. Please enter it to verify.');", true);
                            //SendSingleSMSnew("9618445500", bodyMobile);
                            // Button1.Text = "Click Here To Register";
                            HDFmsgOTP.Value = strOTPMobile;
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
                    txtOTPVerify.Visible = true;
                    txtOTPVerify.Enabled = true;
                }
            }
            else
            {
                string messagenew1 = "alert('Please enter the Recommended Amount')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", messagenew1, true);
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

    protected void chckLoanAggrement_CheckedChanged(object sender, EventArgs e)
    {
        if (chckLoanAggrement.Checked == true && txtLoanAgreement.Text != "")
        {
            LoanAggrementCheck = "1";
            lblLoanAggrement.Visible = false;
        }
        if (txtLoanAgreement.Text != "" && txtLoanAgreement.Text != "Not Available")
        {
            chckLoanAggrement.Enabled = false;
            LoanAggrementCheck = "1";
            txtLoanAgreement.Enabled = false;
        }
    }

    protected void txtLoanAgreement_TextChanged(object sender, EventArgs e)
    {

    }

    protected void chkverifyallDoc0_CheckedChanged(object sender, EventArgs e)
    {
        if (chkverifyallDoc0.Checked == true)
        {
            btnsaveinspectingofficer.Visible = true;
            ddlDeptname.Visible = true;
            ViewState["checkVerifyinsp"] = "Verified";
            trddlDeptname.Visible = true;
        }
        if (chkverifyallDoc0.Checked != true)
        {
            trddlDeptname.Visible = false;
            btnsaveinspectingofficer.Visible = false;
            ddlDeptname.Visible = false;
            ViewState["checkVerifyinsp"] = "Not Verified";
        }
    }

    protected void ddlstaire_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lblsector.Text == "Manufacture" && ddlstaire.SelectedItem.Value.ToString() == "6"
            && CheckBoxList1.SelectedIndex.ToString() == "0")
        {
            trLandBuidlingMachinery.Visible = true;
            txtLandJD.Enabled = true;
            txtBuildingJD.Enabled = true;
            txtPnMJD.Enabled = true;
        }
        else if (lblsector.Text == "Manufacture" && ddlstaire.SelectedItem.Value.ToString() != "6" && CheckBoxList1.SelectedIndex.ToString() == "0")
        {
            trLandBuidlingMachinery.Visible = false;
            txtLandJD.Enabled = false;
            txtBuildingJD.Enabled = false;
            txtPnMJD.Enabled = false;
        }
        else
        {
            trLandBuidlingMachinery.Visible = false;
            txtLandJD.Enabled = false;
            txtBuildingJD.Enabled = false;
            txtPnMJD.Enabled = false;
        }
        if (Session["uid"].ToString() == "21345")
        {
            if (rdbCaste.SelectedValue != "")
            {
                if (rdbCaste.SelectedValue == "General")
                {
                    if (rdbCategory.SelectedValue == "Medium" || rdbCategory.SelectedValue == "Large" || rdbCategory.SelectedValue == "Mega")
                    {
                        Button3.Text = "Refer to Director";
                    }
                    else if (ddlstaire.SelectedValue == "6")
                    {
                        Button3.Text = "Refer to Director";
                    }
                    else
                    {
                        Button3.Text = "Refer to SVC";
                    }
                }
            }
            else
            {
                Button3.Text = "Refer to SVC";
            }
        }
    }

    protected void btngmdelpayexplaination_Click(object sender, EventArgs e)
    {
        try
        {
            int errorCount = 0;
            // string txtgmdelayexplaination = "";
            string Role_Code = Session["Role_Code"].ToString().Trim().TrimStart();
            string Applicantinid = Request.QueryString[0].ToString();
            //Status = Request.QueryString[1].ToString();
            //if (Request.QueryString.ToString().Contains("IncIds"))
            //{
            //    Incids = Request.QueryString["IncIds"].ToString();
            //}
            //Session["querystring"] = "EntrpId=" + Applicantinid + "&Sts=" + Status;
            //SentFrom = Session["User_Code"].ToString();

            //foreach (GridViewRow gvrow in GrdGMDelayexplaination.Rows)
            //{
            // txtgmdelayexplaination =txtgmdelayexplaination ((TextBox)gvrow.FindControl("txtgmdelayexplaination")).Text.ToString();
            if (txtgmdelayexplaination.Text.Trim() == "") { errorCount = errorCount + 1; }
            //}

            if (errorCount == 0)
            {

                string Incentiveslist = "";
                string intApplicationidtop = "";
                int countno = 1;
                //foreach (GridViewRow gvrow in GrdGMDelayexplaination.Rows)
                //{
                officerRemarks fromvo = new officerRemarks();
                //int rowIndex = gvrow.RowIndex;
                fromvo.EnterperIncentiveID = Applicantinid;// ((Label)gvrow.FindControl("lblIncentiveID")).Text.ToString();

                fromvo.MstIncentiveId = "";// ((Label)gvrow.FindControl("lblMstIncentiveId")).Text.ToString();
                fromvo.id = "";// ((Label)gvrow.FindControl("lblid")).Text.ToString();
                fromvo.status = "GMDELAYREASON";
                fromvo.Responce = txtgmdelayexplaination.Text.Trim();// ((TextBox)gvrow.FindControl("txtgmdelayexplaination")).Text.ToString();// HttpUtility.HtmlDecode(GrdGMDelayexplaination.Rows[rowIndex].Cells[3].Text);
                fromvo.CreatedByid = Session["uid"].ToString(); //((Label)gvrow.FindControl("lblCreatedByid")).Text.ToString();
                fromvo.Designation = "GM";
                //fromvo.id = ((Label)gvrow.FindControl("lblid")).Text.ToString();


                lstremarks.Add(fromvo);
                int valid = InsertincentiveOfficerCommentsGMDelayreason(lstremarks, getclientIP());


                //}

                //string message = "alert('Delay reason Submited Successfully')";
                //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                trYettobeassign2.Visible = true;
                Button6.Visible = true;
                btngmdelpayexplaination.Enabled = false;
                trgmdelayclose.Visible = true;
                //txtgmdelayexplaination.Enabled = false;
                //trgmtoenterquery.Visible = true;
                //hplink.NavigateUrl = "ProformaQueryRaiseShortFallLetterGMtoApplicant.aspx?incentiveid=" + intApplicationidtop;

            }
            else
            {
                string message = "alert('Please Enter all reason for delay')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

            }




        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }




    }

    public int InsertincentiveOfficerCommentsGMDelayreason(List<officerRemarks> Ramarks, string IPAddress)
    {
        int valid = 0;
        DB.DB con = new DB.DB();

        foreach (officerRemarks Ramarksvo in Ramarks)
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("USP_INSERT_IncentiveOfficerRemarks_GMDELAYREASON", con.GetConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@EnterperIncentiveID", Convert.ToString(Ramarksvo.EnterperIncentiveID));
                cmd.Parameters.AddWithValue("@MstIncentiveId", Convert.ToString(Ramarksvo.MstIncentiveId));
                cmd.Parameters.AddWithValue("@Remarks", Convert.ToString(Ramarksvo.Remarks));
                cmd.Parameters.AddWithValue("@CreatedByid", Convert.ToString(Ramarksvo.CreatedByid));
                //cmd.Parameters.AddWithValue("@id", Convert.ToString(Ramarksvo.id));
                cmd.Parameters.AddWithValue("@GmResponce", Convert.ToString(Ramarksvo.Responce));
                cmd.Parameters.AddWithValue("@IPAddress", SqlDbType.VarChar).Value = IPAddress.Trim();
                cmd.Parameters.Add("@Valid", SqlDbType.Int, 500);
                cmd.Parameters["@Valid"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                valid = (Int32)cmd.Parameters["@Valid"].Value;
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                con.CloseConnection();
            }
        }

        return valid;
    }

    public DataSet Checkgmdelayreason(string incentiveID, string ApplicationLevel, string SentFrom, string Userid, string Incids)
    {
        DB.DB con = new DB.DB();

        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            // da = new SqlDataAdapter("[FETCHINC_DETAILS_ID]", con.GetConnection);
            da = new SqlDataAdapter("[USP_CHECK_GMDELAYREASON_STATUS]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (incentiveID.ToString() != "" || incentiveID.ToString() != null)
            {
                // da.SelectCommand.Parameters.Add("intUserID", SqlDbType.VarChar).Value = userid;
                da.SelectCommand.Parameters.Add("@IncentveID", SqlDbType.VarChar).Value = incentiveID;
                da.SelectCommand.Parameters.Add("@ApplicationLevel", SqlDbType.VarChar).Value = ApplicationLevel;
                da.SelectCommand.Parameters.Add("@SentFrom", SqlDbType.VarChar).Value = SentFrom;
                da.SelectCommand.Parameters.Add("@Userid", SqlDbType.VarChar).Value = Userid;
                da.SelectCommand.Parameters.Add("@MSTINCENTVEID", SqlDbType.VarChar).Value = Incids;
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

    /// <summary>
    /// //added by nikhil on 13/07/2021///
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddQueryAdLevel_Click(object sender, EventArgs e)
    {
        string Role_Code = Session["Role_Code"].ToString().Trim().TrimStart();
        gvQueries_ADLevel.Visible = true;
        try
        {

            //modified by chinna
            string message = "";
            if (rblStatus_adlevel.SelectedValue == "")
            {
                message = "Please Select Status";
            }
            if (ddlTypeofinc_adlevel.SelectedValue == "0")
            {
                message = "Please Select Type of Incentive";
            }
            if (ddlTypeofinc_adlevel.SelectedValue == "0" && rblStatus_adlevel.SelectedValue == "")
            {
                message = "Please Select Type of Incentive \\nPlease Select Status";
            }
            if (rblStatus_adlevel.SelectedValue == "1")
            {
                if (ddlTypeofinc_adlevel.SelectedValue == "0")
                {
                    message = "Please Select Type of Incentive";
                }
            }
            if (rblStatus_adlevel.SelectedValue == "2")
            {
                if (ddlTypeofinc_adlevel.SelectedValue == "0" && txtAdlevelQuery.Text.Trim() == "")
                {
                    message = "Please Select Type of Incentive \\nPlease Enter Query";
                }
                else if (txtAdlevelQuery.Text.Trim() == "")
                {
                    message = "Please Enter Query";
                }
            }



            if (message != "")
            {
                string message1 = "alert('" + message + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message1, true);
                return;
            }
            string incentiveremarks = "";
            if (rblStatus_adlevel.SelectedValue == "1")
            {
                if (ddlTypeofinc_adlevel.SelectedValue != "6")
                {
                    incentiveremarks = txtadrecomamount.Text;
                }
                else
                {
                    incentiveremarks = "";
                }
                btnSubmitAppraisal.Visible = true;
                btnQueryAdLevel.Visible = false;
            }
            else if (rblStatus_adlevel.SelectedValue == "2")
            {
                incentiveremarks = txtAdlevelQuery.Text;
                btnSubmitAppraisal.Visible = false;
                btnQueryAdLevel.Visible = true;
            }

            if (rblStatus_adlevel.SelectedValue == "2")    // Query
            {

                AddDataToTableCeertificate(ddlTypeofinc_adlevel.SelectedItem.Text, incentiveremarks, Session["username"].ToString(), System.DateTime.Now.ToString("dd/MM/yyyy"), ddlTypeofinc_adlevel.SelectedValue, ViewState["IncentveID"].ToString(), Session["uid"].ToString(), (DataTable)Session["CertificateTb2"]);
                this.gvQueries_ADLevel.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                this.gvQueries_ADLevel.DataBind();
                trfullshap_AdRemakrs.Visible = true;
                ddlTypeofinc_adlevel.Items.Remove(ddlTypeofinc_adlevel.Items.FindByValue(ddlTypeofinc_adlevel.SelectedValue));
                if (ddlTypeofinc_adlevel.Items.Count == 1)
                {
                    rblStatus_adlevel.Enabled = false;
                    btnAddQueryAdLevel.Visible = false;
                }
            }



            else
            {                                               //full in shape
                AddDataToTableCeertificateAmount(ddlTypeofinc_adlevel.SelectedItem.Text, incentiveremarks, Session["username"].ToString(), System.DateTime.Now.ToString("dd/MM/yyyy"), ddlTypeofinc_adlevel.SelectedValue, ViewState["IncentveID"].ToString(), Session["uid"].ToString(), (DataTable)Session["CertificateTbAmount"]);
                this.GridView16.DataSource = ((DataTable)Session["CertificateTbAmount"]).DefaultView;
                this.GridView16.DataBind();
                tr26.Visible = true;

                // ddlstaire.Items.Remove(ddlstaire.SelectedValue);
                if (Role_Code.Trim() == "COI-AD")
                {
                    if (GridView16.Rows.Count > 0)   //&& (txtLandJD.Text != "" && txtBuildingJD.Text != "" && txtPnMJD.Text != "")
                    {

                        ddlTypeofinc_adlevel.Items.Remove(ddlTypeofinc_adlevel.Items.FindByValue(ddlTypeofinc_adlevel.SelectedValue));
                        if (ddlTypeofinc_adlevel.Items.Count == 1)
                        {
                            rblStatus_adlevel.Enabled = false;
                            btnAddQueryAdLevel.Visible = false;
                        }
                    }

                }
                else
                    ddlTypeofinc_adlevel.Items.Remove(ddlTypeofinc_adlevel.Items.FindByValue(ddlTypeofinc_adlevel.SelectedValue));
                //ddlstaire.Items.Remove(ddlstaire.Items.FindByValue(ddlstaire.SelectedValue));
            }



            lblmsg.Text = "";
            ddlTypeofinc_adlevel.SelectedValue = "0";
            txtAdlevelQuery.Text = "";

            rblStatus_adlevel.SelectedIndex = -1;
            foreach (GridViewRow rown in gvQueries_ADLevel.Rows)
            {
                string name = Session["uid"].ToString();
                if (Session["uid"].ToString() != name)
                {
                    DataControlFieldCell editable = (DataControlFieldCell)rown.Controls[1];
                    editable.Enabled = false;
                }
            }

            //added by chinna

            trQuery_adlevel.Visible = false;

        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
        gvQueries_ADLevel.Visible = true;

    }

    protected void btnSubmitAppraisal_Click(object sender, EventArgs e)
    {
        lstremarksad.Clear();
        int valid = 0;
        //string IncentiveID = "";
        //DataTable oDataSet;
        //oDataSet = new DataTable();
        //oDataSet = (DataTable)gvQueries_ADLevel.DataSource;
        string Role_Code = Session["Role_Code"].ToString().Trim().TrimStart();

        foreach (GridViewRow gvrow in GridView16.Rows)
        {

            officerRemarks fromvo = new officerRemarks();
            int rowIndex = gvrow.RowIndex;
            fromvo.EnterperIncentiveID = ((Label)gvrow.FindControl("Label58")).Text.ToString();

            fromvo.MstIncentiveId = ((Label)gvrow.FindControl("Label57")).Text.ToString();
            fromvo.id = ((Label)gvrow.FindControl("Label60")).Text.ToString();
            fromvo.status = "Recomm";
            fromvo.Remarks = HttpUtility.HtmlDecode(GridView16.Rows[rowIndex].Cells[3].Text);
            fromvo.CreatedByid = ((Label)gvrow.FindControl("Label59")).Text.ToString();
            fromvo.Designation = Role_Code.Trim();



            lstremarksad.Add(fromvo);

            Button4.Visible = true;
        }

        foreach (GridViewRow gvrow in GridView16.Rows)
        {
            officerForwarded frmvo = new officerForwarded();
            string lblMstIncentiveId = ((Label)gvrow.FindControl("Label57")).Text;
            string lblIncentiveID = ((Label)gvrow.FindControl("Label58")).Text;
            //IncentiveID = lblIncentiveID;
            frmvo.EnterperIncentiveID = lblIncentiveID;
            frmvo.MstIncentiveId = lblMstIncentiveId;
            frmvo.CreatedByid = Session["uid"].ToString();
            frmvo.ApplicationFrom = Session["uid"].ToString();
            if (tradditional.Visible == true)
            {
                string[] datett = txtslcnodate.Text.Trim().Split('/');
                frmvo.Slcdate = datett[2] + "/" + datett[1] + "/" + datett[0];
                frmvo.SLCNO = txtslcno.Text.Trim();
            }

            lstincentives.Add(frmvo);
            if (Role_Code.Trim() == "COI-AD")
            {
                if (frmvo.MstIncentiveId == "6")
                {
                    Response.Redirect("apparaisalnote_isform1.aspx?incentiveid=" + ViewState["IncentveID"].ToString() + "&MstIncentiveId=" + frmvo.MstIncentiveId);
                }
                else
                {
                    valid = InsertincentiveOfficerCommentsAD(lstremarksad, lstincentives, getclientIP());
                }
            }
        }

        //int valid = 0;




    }

    protected void rblStatus_adlevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblStatus_adlevel.SelectedValue == "2")
            {

                trQuery_adlevel.Visible = true;
            }

            else
            {
                trQuery_adlevel.Visible = false;
                if (ddlTypeofinc_adlevel.SelectedValue != "6")
                {
                    tradrecommendamount.Visible = true;
                }
                else
                {
                    tradrecommendamount.Visible = false;
                }
            }

        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void gvQueries_ADLevel_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int rowww = e.RowIndex;
            string idnew = ((Label)gvQueries_ADLevel.Rows[e.RowIndex].FindControl("Label56")).Text.ToString().Trim();
            string IncentiveName = gvQueries_ADLevel.Rows[e.RowIndex].Cells[2].Text;
            string lblMstIncentiveId = ((Label)gvQueries_ADLevel.Rows[e.RowIndex].FindControl("Label53")).Text.ToString().Trim();

            ListItem li = new ListItem();
            li.Text = IncentiveName;
            li.Value = lblMstIncentiveId;

            ddlTypeofinc_adlevel.Items.Add(li);

            if (idnew != "0" && idnew != "")
            {
                int validremaeks = Gen.deleteGroupSavingDataincentive(idnew);

            }
            if (gvQueries_ADLevel.Rows.Count == 1)
            {
                trfullshap_AdRemakrs.Visible = false;
                btnSubmitAppraisal.Visible = false;
            }
            ((DataTable)Session["CertificateTb2"]).Rows.RemoveAt(e.RowIndex);
            this.gvQueries_ADLevel.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
            this.gvQueries_ADLevel.DataBind();
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Please enter correct data";// ex.ToString();
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());

        }
        finally
        {

        }
    }

    protected void gvQueries_ADLevel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (Request.QueryString[1].ToString() == "222")
            {
                e.Row.Cells[1].Visible = false;
            }
        }
        if (e.Row.RowType == DataControlRowType.Header)
        {
            if (Request.QueryString[1].ToString() == "222")
            {
                e.Row.Cells[1].Visible = false;
            }
        }
    }

    protected void GridView16_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int rowww = e.RowIndex;
            string idnew = ((Label)GridView16.Rows[e.RowIndex].FindControl("lblid")).Text.ToString().Trim();

            string IncentiveName = GridView16.Rows[e.RowIndex].Cells[2].Text;
            string lblMstIncentiveId = ((Label)GridView16.Rows[e.RowIndex].FindControl("lblMstIncentiveId")).Text.ToString().Trim();
            ListItem li = new ListItem();
            li.Text = IncentiveName;
            li.Value = lblMstIncentiveId;

            ddlstaire.Items.Add(li);

            if (idnew != "0" && idnew != "")
            {
                int validremaeks = Gen.deleteGroupSavingDataincentive(idnew);


            }
            if (GridView16.Rows.Count == 1)
            {
                trnotinfullshap.Visible = false;
                Button3.Visible = false;
            }

            ((DataTable)Session["CertificateTbAmount"]).Rows.RemoveAt(e.RowIndex);
            this.GridView16.DataSource = ((DataTable)Session["CertificateTbAmount"]).DefaultView;
            this.GridView16.DataBind();
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Please enter correct data";// ex.ToString();
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());

        }
        finally
        {

        }
    }


    protected void btnQueryAdLevel_Click(object sender, EventArgs e)
    {
        try
        {
            string status = "";
            string rejectremarks = "";
            string rejectIncentive = "";
            lstremarks.Clear();
            string IncentiveID = "";
            DataTable oDataSet;
            oDataSet = new DataTable();
            oDataSet = (DataTable)gvQueries_ADLevel.DataSource;
            string Role_Code = Session["Role_Code"].ToString().Trim().TrimStart();

            if (oDataSet == null)
            {
                this.gvQueries_ADLevel.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                this.gvQueries_ADLevel.DataBind();
            }



            foreach (GridViewRow gvrow in gvQueries_ADLevel.Rows)
            {

                officerRemarks fromvo = new officerRemarks();
                int rowIndex = gvrow.RowIndex;
                fromvo.EnterperIncentiveID = ((Label)gvrow.FindControl("Label54")).Text.ToString();

                fromvo.MstIncentiveId = ((Label)gvrow.FindControl("Label53")).Text.ToString();
                fromvo.id = ((Label)gvrow.FindControl("Label56")).Text.ToString();
                fromvo.status = "Query";
                fromvo.Remarks = HttpUtility.HtmlDecode(gvQueries_ADLevel.Rows[rowIndex].Cells[3].Text);
                fromvo.CreatedByid = ((Label)gvrow.FindControl("Label55")).Text.ToString();
                fromvo.Designation = Role_Code.Trim();



                lstremarks.Add(fromvo);

                Button4.Visible = true;
            }



            foreach (GridViewRow gvrow in gvinspectionOfficer.Rows)
            {
                officerForwarded frmvo = new officerForwarded();
                string lblMstIncentiveId = ((Label)gvrow.FindControl("lblMstIncentiveId")).Text;
                string lblIncentiveID = ((Label)gvrow.FindControl("lblIncentiveID")).Text;
                IncentiveID = lblIncentiveID;
                frmvo.EnterperIncentiveID = lblIncentiveID;
                frmvo.MstIncentiveId = lblMstIncentiveId;
                frmvo.CreatedByid = Session["uid"].ToString();
                frmvo.ApplicationFrom = Session["uid"].ToString();
                if (tradditional.Visible == true)
                {
                    string[] datett = txtslcnodate.Text.Trim().Split('/');
                    frmvo.Slcdate = datett[2] + "/" + datett[1] + "/" + datett[0];
                    frmvo.SLCNO = txtslcno.Text.Trim();
                }

                lstincentives.Add(frmvo);
            }

            int valid = 0;


            if (Role_Code.Trim() == "COI-AD")
            {
                valid = InsertincentiveOfficerCommentsAD(lstremarks, lstincentives, getclientIP());
                if (valid == 1)
                {
                    //lblmsg.Text = "<font color='green'>Application Submitted Successfully..!</font>";
                    //success.Visible = true;
                    //Failure.Visible = false;
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Application Submitted Successfully');", true);
                    string message = "";
                    if (status == "Reject")
                    {
                        message = "alert('Application Rejected Successfully')";
                    }
                    else
                    {
                        message = "alert('Query raised Successfully')";
                    }
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                    btnQueryAdLevel.Enabled = false;

                }
            }


        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    //// end of added code on 13/07/2021////
    protected void gvADOfficer_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    public int InsertincentiveOfficerCommentsAD(List<officerRemarks> Ramarks, List<officerForwarded> lstincentives, string IPAddress)
    {
        int valid = 0;

        foreach (officerRemarks Ramarksvo in Ramarks)
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("[USP_INSERT_OfficerRemarks_AD]", con.GetConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@EnterperIncentiveID", Convert.ToString(Ramarksvo.EnterperIncentiveID));
                cmd.Parameters.AddWithValue("@MstIncentiveId", Convert.ToString(Ramarksvo.MstIncentiveId));
                cmd.Parameters.AddWithValue("@Remarks", Convert.ToString(Ramarksvo.Remarks));
                cmd.Parameters.AddWithValue("@status", Convert.ToString(Ramarksvo.status));
                cmd.Parameters.AddWithValue("@CreatedByid", Convert.ToString(Ramarksvo.CreatedByid));
                cmd.Parameters.AddWithValue("@id", Convert.ToString(Ramarksvo.id));
                cmd.Parameters.AddWithValue("@Designation", Convert.ToString(Ramarksvo.Designation));
                cmd.Parameters.AddWithValue("@IPAddress", SqlDbType.VarChar).Value = IPAddress.Trim();
                cmd.Parameters.AddWithValue("@AD_RECON_AMOUNT", Convert.ToString(Ramarksvo.Remarks));
                cmd.Parameters.Add("@Valid", SqlDbType.Int, 500);
                cmd.Parameters["@Valid"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                valid = (Int32)cmd.Parameters["@Valid"].Value;
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                con.CloseConnection();
            }
        }

        return valid;
    }

    // AD Query History
    public DataSet GetADQueryHistory(string IncentiveID, string RoleCode, string Incids)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            //da = new SqlDataAdapter("USP_GET_IOQuery_History", con.GetConnection);
            da = new SqlDataAdapter("USP_GET_ADQuery_History_TEST", con.GetConnection);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (IncentiveID == null)
            {
                da.SelectCommand.Parameters.Add("@IncentiveID", SqlDbType.VarChar).Value = null;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@IncentiveID", SqlDbType.VarChar).Value = IncentiveID.ToString();
            }
            da.SelectCommand.Parameters.Add("@RoleCode", SqlDbType.VarChar).Value = RoleCode.ToString();
            da.SelectCommand.Parameters.Add("@MSTINCENTVEID", SqlDbType.VarChar).Value = Incids;
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
    protected void gvadrecommended_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void BindingADRecommendedIncentives(DataTable ds)
    {
        try
        {
            if (ds != null && ds.Rows.Count > 0)
            {
                gvadrecommended.DataSource = ds;
                gvadrecommended.DataBind();
                //   gvinspectionOfficer.Columns[11].Visible = false;

                //gvadrecommended.Columns[10].Visible = true;

                //if (gvadrecommended.Rows.Count < 1)
                //{

                //    trinspectionname1.Visible = false;
                //    //trInspectionReport3.Visible = false;
                //    trInspectionReport4.Visible = false;
                //}
                //else
                //{
                //    // trInspectionReportNEW.Visible = true;
                //}
                int rejectedcount = 0;
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    //TextBox txtinspectiondate = (TextBox)grdDetails.Rows[i].FindControl("txtinspectiondate");
                    //DropDownList ddlapprove = (DropDownList)gvadrecommended.Rows[i].FindControl("ddlapprove");
                    //ddlapprove.SelectedValue = ds.Rows[i]["GMStatusid"].ToString();
                    //TextBox txtIncQueryFnl2 = (TextBox)gvadrecommended.Rows[i].FindControl("txtIncQueryFnl2");
                    Label enterid = (Label)gvadrecommended.Rows[i].FindControl("lblIncentiveID");
                    Label lblMstIncentiveId = (Label)gvadrecommended.Rows[i].FindControl("lblMstIncentiveId");
                    //FileUpload FileUploadgminspectionnew = (FileUpload)gvadrecommended.Rows[i].FindControl("FileUploadgminspection");

                    //if (ds.Rows[i]["GMApprovalSentTo"].ToString() != "" && ds.Rows[i]["GMStatusid"].ToString() == "2")
                    //{

                    if (lblMstIncentiveId.Text == "6")
                    {
                        (gvadrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + lblMstIncentiveId.Text.Trim(); ;
                    }
                    //if (lblMstIncentiveId.Text == "1")
                    //{
                    //    (gvadrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaPavalavaddi.aspx?incentiveid=" + enterid.Text.Trim();
                    //}
                    //if (lblMstIncentiveId.Text == "3")
                    //{
                    //    (gvadrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaPowerTariff.aspx?incentiveid=" + enterid.Text.Trim();
                    //}
                    //if (lblMstIncentiveId.Text == "5")
                    //{
                    //    (gvadrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaSalesTax.aspx?incentiveid=" + enterid.Text.Trim();
                    //}

                    (gvadrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).ForeColor = System.Drawing.Color.Green;
                    (gvadrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).Text = "Appraisal Note";

                    //Button btnsubmit = (Button)gvadrecommended.Rows[i].FindControl("Button1");
                    //btnsubmit.Visible = false;
                    //Button btnButton2 = (Button)gvadrecommended.Rows[i].FindControl("Button2");
                    //btnButton2.Visible = false;
                    //Label lblcois = (Label)gvadrecommended.Rows[i].FindControl("lblcois");
                    //FileUpload FileUploadgminspection = (FileUpload)gvadrecommended.Rows[i].FindControl("FileUploadgminspection");

                    //lblcois.Visible = true;



                    //}
                    //else if (ds.Rows[i]["GMStatus"].ToString() == "Rejected" && ds.Rows[i]["GMStatusid"].ToString() == "3")
                    //{
                    //    rejectedcount = rejectedcount + 1;
                    //    Label lblcois = (Label)gvadrecommended.Rows[i].FindControl("lblcois");
                    //    FileUpload FileUploadgminspection = (FileUpload)gvadrecommended.Rows[i].FindControl("FileUploadgminspection");
                    //    lblcois.Visible = true;
                    //    lblcois.Text = "Rejected";
                    //    ddlapprove.Enabled = false;
                    //    ddlapplicationto.SelectedValue = "0";
                    //    ddlapplicationto.Enabled = false;
                    //    FileUploadgminspection.Visible = false;
                    //    EventArgs e = new EventArgs();
                    //    ddlapplicationto_SelectedIndexChanged(this, e);  // shankartest


                    //    txtIncQueryFnl2.Visible = true;
                    //    txtIncQueryFnl2.Text = ds.Rows[i]["GMRemarks"].ToString();
                    //    Button Button1 = (Button)gvadrecommended.Rows[i].FindControl("Button1");
                    //    Button Button2 = (Button)gvadrecommended.Rows[i].FindControl("Button2");
                    //    Button2.Visible = false;
                    //    Button1.Visible = false;
                    //    (gvadrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).Visible = false;
                    //    if (ds.Rows.Count == rejectedcount)
                    //    {
                    //        gvadrecommended.Columns[12].Visible = false;
                    //        gvadrecommended.Columns[10].Visible = false;
                    //        gvadrecommended.Columns[9].Visible = false;
                    //    }
                    //}

                }
            }
            if (gvadrecommended.Rows.Count < 1)
            {
                trinspectionname1.Visible = false;
                trInspectionReport4.Visible = false;
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    public DataSet GetStageID(string incentiveID, string Incids)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {

            da = new SqlDataAdapter("[SP_GETSTAGEID]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (incentiveID.ToString() != "" || incentiveID.ToString() != null)
            {
                // da.SelectCommand.Parameters.Add("intUserID", SqlDbType.VarChar).Value = userid;
                da.SelectCommand.Parameters.Add("@IncentveID", SqlDbType.VarChar).Value = incentiveID;
                da.SelectCommand.Parameters.Add("@MSTINCENTVEID", SqlDbType.VarChar).Value = Incids;
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

    // frmIncentiveDeptView.aspx method
    public DataSet GetIncetiveDetailsdeptAD(string incentiveID, string ApplicationLevel, string SentFrom, string Userid, string Incids)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            // da = new SqlDataAdapter("[FETCHINC_DETAILS_ID]", con.GetConnection);
            da = new SqlDataAdapter("[FETCHINC_DETAILS_ID_NEW_AD]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (incentiveID.ToString() != "" || incentiveID.ToString() != null)
            {
                // da.SelectCommand.Parameters.Add("intUserID", SqlDbType.VarChar).Value = userid;
                da.SelectCommand.Parameters.Add("@IncentveID", SqlDbType.VarChar).Value = incentiveID;
                da.SelectCommand.Parameters.Add("@ApplicationLevel", SqlDbType.VarChar).Value = ApplicationLevel;
                da.SelectCommand.Parameters.Add("@SentFrom", SqlDbType.VarChar).Value = SentFrom;
                da.SelectCommand.Parameters.Add("@Userid", SqlDbType.VarChar).Value = Userid;
                da.SelectCommand.Parameters.Add("@MSTINCENTVEID", SqlDbType.VarChar).Value = Incids;
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

    public DataSet GETDISTSCHEMEANDISPHDATA(string incentiveID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[SP_GETDISTSCHEMEANDISPHDATA]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (incentiveID.ToString() != "" || incentiveID.ToString() != null)
            {
                da.SelectCommand.Parameters.Add("INCENTIVEID", SqlDbType.VarChar).Value = incentiveID;

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

    protected void gvclerkrecommended_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void gvSuprdntrecommended_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void gvDDrcrecommended_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    public void BindingClerkRecommendedIncentives(DataTable ds)
    {
        try
        {
            if (ds != null && ds.Rows.Count > 0)
            {
                gvclerkrecommended.DataSource = ds;
                gvclerkrecommended.DataBind();
                //   gvinspectionOfficer.Columns[11].Visible = false;

                //gvadrecommended.Columns[10].Visible = true;

                //if (gvadrecommended.Rows.Count < 1)
                //{

                //    trinspectionname1.Visible = false;
                //    //trInspectionReport3.Visible = false;
                //    trInspectionReport4.Visible = false;
                //}
                //else
                //{
                //    // trInspectionReportNEW.Visible = true;
                //}
                int rejectedcount = 0;
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    //TextBox txtinspectiondate = (TextBox)grdDetails.Rows[i].FindControl("txtinspectiondate");
                    //DropDownList ddlapprove = (DropDownList)gvadrecommended.Rows[i].FindControl("ddlapprove");
                    //ddlapprove.SelectedValue = ds.Rows[i]["GMStatusid"].ToString();
                    //TextBox txtIncQueryFnl2 = (TextBox)gvadrecommended.Rows[i].FindControl("txtIncQueryFnl2");
                    Label enterid = (Label)gvclerkrecommended.Rows[i].FindControl("lblIncentiveID");
                    Label lblMstIncentiveId = (Label)gvclerkrecommended.Rows[i].FindControl("lblMstIncentiveId");
                    //FileUpload FileUploadgminspectionnew = (FileUpload)gvadrecommended.Rows[i].FindControl("FileUploadgminspection");

                    //if (ds.Rows[i]["GMApprovalSentTo"].ToString() != "" && ds.Rows[i]["GMStatusid"].ToString() == "2")
                    //{
                    Label lblIncentiveNameDis = (Label)gvclerkrecommended.Rows[i].FindControl("lblIncentiveNameDis");

                    Label lblclerkRECOMMENDEDDATE = (Label)gvclerkrecommended.Rows[i].FindControl("lblclerkRECOMMENDED_DATE");

                    Label LBLOLDORNEW = (Label)gvclerkrecommended.Rows[i].FindControl("LBLOLDORNEW");

                    if (LBLOLDORNEW.Text == "LATEST")
                    {
                        if (Convert.ToDateTime(lblclerkRECOMMENDEDDATE.Text).Date >= Convert.ToDateTime("19/01/2022").Date)
                        {
                            if (lblMstIncentiveId.Text == "1")
                            {
                                (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + lblMstIncentiveId.Text.Trim(); ;
                            }
                        }
                        if (lblMstIncentiveId.Text == "6")
                        {
                            (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + lblMstIncentiveId.Text.Trim(); ;
                        }
                        if (lblMstIncentiveId.Text == "5")
                        {
                            (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + lblMstIncentiveId.Text.Trim(); ;
                        }
                        if (lblMstIncentiveId.Text == "11")
                        {
                            (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + lblMstIncentiveId.Text.Trim(); ;
                        }
                        if (lblMstIncentiveId.Text == "14")
                        {
                            (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + lblMstIncentiveId.Text.Trim(); ;
                        }
                        if (lblMstIncentiveId.Text == "15")
                        {
                            (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + lblMstIncentiveId.Text.Trim(); ;
                        }
                        if (lblMstIncentiveId.Text == "16")
                        {
                            (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + lblMstIncentiveId.Text.Trim(); ;
                        }
                        if (lblMstIncentiveId.Text == "17")
                        {
                            (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + lblMstIncentiveId.Text.Trim(); ;
                        }
                        if (lblMstIncentiveId.Text == "18")
                        {
                            (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + lblMstIncentiveId.Text.Trim(); ;
                        }
                        if (lblMstIncentiveId.Text == "19")
                        {
                            (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + lblMstIncentiveId.Text.Trim(); ;
                        }
                        if (lblMstIncentiveId.Text == "20")
                        {
                            (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + lblMstIncentiveId.Text.Trim(); ;
                        }
                        if (lblMstIncentiveId.Text == "3")
                        {
                            (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + lblMstIncentiveId.Text.Trim(); ;
                        }
                        if (lblMstIncentiveId.Text == "8")
                        {
                            (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + lblMstIncentiveId.Text.Trim(); ;
                        }
                        if (lblMstIncentiveId.Text == "7")
                        {
                            (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + lblMstIncentiveId.Text.Trim(); ;
                        }
                        if (lblMstIncentiveId.Text == "22")
                        {
                            (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + lblMstIncentiveId.Text.Trim(); ;
                        }
                        //if (lblMstIncentiveId.Text == "1")
                        //{
                        //    (gvadrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaPavalavaddi.aspx?incentiveid=" + enterid.Text.Trim();
                        //}
                        //if (lblMstIncentiveId.Text == "3")
                        //{
                        //    (gvadrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaPowerTariff.aspx?incentiveid=" + enterid.Text.Trim();
                        //}
                        //if (lblMstIncentiveId.Text == "5")
                        //{
                        //    (gvadrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaSalesTax.aspx?incentiveid=" + enterid.Text.Trim();
                        //}
                        if (lblMstIncentiveId.Text == "9")
                        {
                            if (enterid.Text == "66420" || enterid.Text == "71515" || enterid.Text == "70553" || enterid.Text == "56155" || enterid.Text == "77623" || enterid.Text == "60488" || enterid.Text == "77946" || enterid.Text == "95174" || enterid.Text == "108372" || enterid.Text == "73439" || enterid.Text == "102246" || enterid.Text == "72466" || enterid.Text == "67353" || enterid.Text == "110440")
                            {
                                string msttid;
                                if (lblIncentiveNameDis.Text == "Investment Subsidy")
                                {
                                    msttid = "6";
                                    (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + msttid.Trim(); ;
                                }
                                if (lblIncentiveNameDis.Text == "Reimbursement of stamp Duty/Transfer Duty/Mortgage/Land Conversion/Land Cost")
                                {
                                    msttid = "14";
                                    (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + msttid.Trim(); ;
                                }
                                if (lblIncentiveNameDis.Text == "Reimbursement of Land Conversion")
                                {
                                    msttid = "16";
                                    (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + msttid.Trim(); ;
                                }
                                if (lblIncentiveNameDis.Text == "Reimbursement of Land Cost")
                                {
                                    msttid = "17";
                                    (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + msttid.Trim(); ;
                                }


                            }
                        }
                                        (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).Text = "Appraisal Note";
                        (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).ForeColor = System.Drawing.Color.Green;
                    }
                    if (LBLOLDORNEW.Text == "OLD")
                    {
                        //if (Convert.ToDateTime(lblclerkRECOMMENDEDDATE.Text).Date >= Convert.ToDateTime("19/01/2022").Date)
                        //{
                        if (lblMstIncentiveId.Text == "1")
                        {
                            (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2_OLD.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + lblMstIncentiveId.Text.Trim(); ;
                        }
                        //}
                        if (lblMstIncentiveId.Text == "6")
                        {
                            (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2_OLD.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + lblMstIncentiveId.Text.Trim(); ;
                        }
                        if (lblMstIncentiveId.Text == "5")
                        {
                            (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2_OLD.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + lblMstIncentiveId.Text.Trim(); ;
                        }
                        if (lblMstIncentiveId.Text == "11")
                        {
                            (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2_OLD.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + lblMstIncentiveId.Text.Trim(); ;
                        }
                        if (lblMstIncentiveId.Text == "14")
                        {
                            (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2_OLD.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + lblMstIncentiveId.Text.Trim(); ;
                        }
                        if (lblMstIncentiveId.Text == "15")
                        {
                            (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2_OLD.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + lblMstIncentiveId.Text.Trim(); ;
                        }
                        if (lblMstIncentiveId.Text == "16")
                        {
                            (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2_OLD.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + lblMstIncentiveId.Text.Trim(); ;
                        }
                        if (lblMstIncentiveId.Text == "17")
                        {
                            (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2_OLD.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + lblMstIncentiveId.Text.Trim(); ;
                        }
                        if (lblMstIncentiveId.Text == "18")
                        {
                            (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2_OLD.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + lblMstIncentiveId.Text.Trim(); ;
                        }
                        if (lblMstIncentiveId.Text == "19")
                        {
                            (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2_OLD.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + lblMstIncentiveId.Text.Trim(); ;
                        }
                        if (lblMstIncentiveId.Text == "20")
                        {
                            (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2_OLD.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + lblMstIncentiveId.Text.Trim(); ;
                        }
                        if (lblMstIncentiveId.Text == "3")
                        {
                            (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2_OLD.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + lblMstIncentiveId.Text.Trim(); ;
                        }
                        //if (lblMstIncentiveId.Text == "8")
                        //{
                        //    (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2_OLD.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + lblMstIncentiveId.Text.Trim(); ;
                        //}
                        //if (lblMstIncentiveId.Text == "7")
                        //{
                        //    (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2_OLD.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + lblMstIncentiveId.Text.Trim(); ;
                        //}
                        if (lblMstIncentiveId.Text == "9")
                        {
                            if (enterid.Text == "66420" || enterid.Text == "71515" || enterid.Text == "70553" || enterid.Text == "56155" || enterid.Text == "77623" || enterid.Text == "60488" || enterid.Text == "77946" || enterid.Text == "95174" || enterid.Text == "108372" || enterid.Text == "73439" || enterid.Text == "102246" || enterid.Text == "72466" || enterid.Text == "67353" || enterid.Text == "110440")
                            {
                                string msttid;
                                if (lblIncentiveNameDis.Text == "Investment Subsidy")
                                {
                                    msttid = "6";
                                    (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2_OLD.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + msttid.Trim(); ;
                                }
                                if (lblIncentiveNameDis.Text == "Reimbursement of stamp Duty/Transfer Duty/Mortgage/Land Conversion/Land Cost")
                                {
                                    msttid = "14";
                                    (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2_OLD.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + msttid.Trim(); ;
                                }
                                if (lblIncentiveNameDis.Text == "Reimbursement of Land Conversion")
                                {
                                    msttid = "16";
                                    (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2_OLD.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + msttid.Trim(); ;
                                }
                                if (lblIncentiveNameDis.Text == "Reimbursement of Land Cost")
                                {
                                    msttid = "17";
                                    (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2_OLD.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + msttid.Trim(); ;
                                }
                            }
                        }
                              (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).Text = "OLD Appraisal Note";
                        (gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).ForeColor = System.Drawing.Color.Red;

                    }


                    //(gvclerkrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).Text = "Appraisal Note";



                }
            }
            if (gvclerkrecommended.Rows.Count < 1)
            {
                trinspectionname1.Visible = false;
                trInspectionReport4.Visible = false;
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    public void BindingSupdtRecommendedIncentives(DataTable ds)
    {
        try
        {
            if (ds != null && ds.Rows.Count > 0)
            {
                gvSuprdntrecommended.DataSource = ds;
                gvSuprdntrecommended.DataBind();
                //   gvinspectionOfficer.Columns[11].Visible = false;

                //gvadrecommended.Columns[10].Visible = true;

                //if (gvadrecommended.Rows.Count < 1)
                //{

                //    trinspectionname1.Visible = false;
                //    //trInspectionReport3.Visible = false;
                //    trInspectionReport4.Visible = false;
                //}
                //else
                //{
                //    // trInspectionReportNEW.Visible = true;
                //}
                int rejectedcount = 0;
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    //TextBox txtinspectiondate = (TextBox)grdDetails.Rows[i].FindControl("txtinspectiondate");
                    //DropDownList ddlapprove = (DropDownList)gvadrecommended.Rows[i].FindControl("ddlapprove");
                    //ddlapprove.SelectedValue = ds.Rows[i]["GMStatusid"].ToString();
                    //TextBox txtIncQueryFnl2 = (TextBox)gvadrecommended.Rows[i].FindControl("txtIncQueryFnl2");
                    Label enterid = (Label)gvSuprdntrecommended.Rows[i].FindControl("lblIncentiveID");
                    Label lblMstIncentiveId = (Label)gvSuprdntrecommended.Rows[i].FindControl("lblMstIncentiveId");
                    //FileUpload FileUploadgminspectionnew = (FileUpload)gvadrecommended.Rows[i].FindControl("FileUploadgminspection");

                    //if (ds.Rows[i]["GMApprovalSentTo"].ToString() != "" && ds.Rows[i]["GMStatusid"].ToString() == "2")
                    //{

                    if (lblMstIncentiveId.Text == "6")
                    {
                        (gvSuprdntrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + lblMstIncentiveId.Text.Trim(); ;
                    }
                    //if (lblMstIncentiveId.Text == "1")
                    //{
                    //    (gvadrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaPavalavaddi.aspx?incentiveid=" + enterid.Text.Trim();
                    //}
                    //if (lblMstIncentiveId.Text == "3")
                    //{
                    //    (gvadrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaPowerTariff.aspx?incentiveid=" + enterid.Text.Trim();
                    //}
                    //if (lblMstIncentiveId.Text == "5")
                    //{
                    //    (gvadrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaSalesTax.aspx?incentiveid=" + enterid.Text.Trim();
                    //}

                    (gvSuprdntrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).ForeColor = System.Drawing.Color.Green;
                    (gvSuprdntrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).Text = "Appraisal Note";

                    //Button btnsubmit = (Button)gvadrecommended.Rows[i].FindControl("Button1");
                    //btnsubmit.Visible = false;
                    //Button btnButton2 = (Button)gvadrecommended.Rows[i].FindControl("Button2");
                    //btnButton2.Visible = false;
                    //Label lblcois = (Label)gvadrecommended.Rows[i].FindControl("lblcois");
                    //FileUpload FileUploadgminspection = (FileUpload)gvadrecommended.Rows[i].FindControl("FileUploadgminspection");

                    //lblcois.Visible = true;



                    //}
                    //else if (ds.Rows[i]["GMStatus"].ToString() == "Rejected" && ds.Rows[i]["GMStatusid"].ToString() == "3")
                    //{
                    //    rejectedcount = rejectedcount + 1;
                    //    Label lblcois = (Label)gvadrecommended.Rows[i].FindControl("lblcois");
                    //    FileUpload FileUploadgminspection = (FileUpload)gvadrecommended.Rows[i].FindControl("FileUploadgminspection");
                    //    lblcois.Visible = true;
                    //    lblcois.Text = "Rejected";
                    //    ddlapprove.Enabled = false;
                    //    ddlapplicationto.SelectedValue = "0";
                    //    ddlapplicationto.Enabled = false;
                    //    FileUploadgminspection.Visible = false;
                    //    EventArgs e = new EventArgs();
                    //    ddlapplicationto_SelectedIndexChanged(this, e);  // shankartest


                    //    txtIncQueryFnl2.Visible = true;
                    //    txtIncQueryFnl2.Text = ds.Rows[i]["GMRemarks"].ToString();
                    //    Button Button1 = (Button)gvadrecommended.Rows[i].FindControl("Button1");
                    //    Button Button2 = (Button)gvadrecommended.Rows[i].FindControl("Button2");
                    //    Button2.Visible = false;
                    //    Button1.Visible = false;
                    //    (gvadrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).Visible = false;
                    //    if (ds.Rows.Count == rejectedcount)
                    //    {
                    //        gvadrecommended.Columns[12].Visible = false;
                    //        gvadrecommended.Columns[10].Visible = false;
                    //        gvadrecommended.Columns[9].Visible = false;
                    //    }
                    //}

                }
            }
            if (gvSuprdntrecommended.Rows.Count < 1)
            {
                trinspectionname1.Visible = false;
                trInspectionReport4.Visible = false;
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    public void BindingDDRecommendedIncentives(DataTable ds)
    {
        try
        {
            if (ds != null && ds.Rows.Count > 0)
            {
                gvDDrcrecommended.DataSource = ds;
                gvDDrcrecommended.DataBind();
                //   gvinspectionOfficer.Columns[11].Visible = false;

                //gvadrecommended.Columns[10].Visible = true;

                //if (gvadrecommended.Rows.Count < 1)
                //{

                //    trinspectionname1.Visible = false;
                //    //trInspectionReport3.Visible = false;
                //    trInspectionReport4.Visible = false;
                //}
                //else
                //{
                //    // trInspectionReportNEW.Visible = true;
                //}
                int rejectedcount = 0;
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    //TextBox txtinspectiondate = (TextBox)grdDetails.Rows[i].FindControl("txtinspectiondate");
                    //DropDownList ddlapprove = (DropDownList)gvadrecommended.Rows[i].FindControl("ddlapprove");
                    //ddlapprove.SelectedValue = ds.Rows[i]["GMStatusid"].ToString();
                    //TextBox txtIncQueryFnl2 = (TextBox)gvadrecommended.Rows[i].FindControl("txtIncQueryFnl2");
                    Label enterid = (Label)gvDDrcrecommended.Rows[i].FindControl("lblIncentiveID");
                    Label lblMstIncentiveId = (Label)gvDDrcrecommended.Rows[i].FindControl("lblMstIncentiveId");
                    //FileUpload FileUploadgminspectionnew = (FileUpload)gvadrecommended.Rows[i].FindControl("FileUploadgminspection");

                    //if (ds.Rows[i]["GMApprovalSentTo"].ToString() != "" && ds.Rows[i]["GMStatusid"].ToString() == "2")
                    //{

                    if (lblMstIncentiveId.Text == "6")
                    {
                        (gvDDrcrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "appraisalNote2.aspx?incid=" + enterid.Text.Trim() + "&mstid=" + lblMstIncentiveId.Text.Trim(); ;
                    }
                    //if (lblMstIncentiveId.Text == "1")
                    //{
                    //    (gvadrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaPavalavaddi.aspx?incentiveid=" + enterid.Text.Trim();
                    //}
                    //if (lblMstIncentiveId.Text == "3")
                    //{
                    //    (gvadrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaPowerTariff.aspx?incentiveid=" + enterid.Text.Trim();
                    //}
                    //if (lblMstIncentiveId.Text == "5")
                    //{
                    //    (gvadrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaSalesTax.aspx?incentiveid=" + enterid.Text.Trim();
                    //}

                    (gvDDrcrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).ForeColor = System.Drawing.Color.Green;
                    (gvDDrcrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).Text = "Appraisal Note";

                    //Button btnsubmit = (Button)gvadrecommended.Rows[i].FindControl("Button1");
                    //btnsubmit.Visible = false;
                    //Button btnButton2 = (Button)gvadrecommended.Rows[i].FindControl("Button2");
                    //btnButton2.Visible = false;
                    //Label lblcois = (Label)gvadrecommended.Rows[i].FindControl("lblcois");
                    //FileUpload FileUploadgminspection = (FileUpload)gvadrecommended.Rows[i].FindControl("FileUploadgminspection");

                    //lblcois.Visible = true;



                    //}
                    //else if (ds.Rows[i]["GMStatus"].ToString() == "Rejected" && ds.Rows[i]["GMStatusid"].ToString() == "3")
                    //{
                    //    rejectedcount = rejectedcount + 1;
                    //    Label lblcois = (Label)gvadrecommended.Rows[i].FindControl("lblcois");
                    //    FileUpload FileUploadgminspection = (FileUpload)gvadrecommended.Rows[i].FindControl("FileUploadgminspection");
                    //    lblcois.Visible = true;
                    //    lblcois.Text = "Rejected";
                    //    ddlapprove.Enabled = false;
                    //    ddlapplicationto.SelectedValue = "0";
                    //    ddlapplicationto.Enabled = false;
                    //    FileUploadgminspection.Visible = false;
                    //    EventArgs e = new EventArgs();
                    //    ddlapplicationto_SelectedIndexChanged(this, e);  // shankartest


                    //    txtIncQueryFnl2.Visible = true;
                    //    txtIncQueryFnl2.Text = ds.Rows[i]["GMRemarks"].ToString();
                    //    Button Button1 = (Button)gvadrecommended.Rows[i].FindControl("Button1");
                    //    Button Button2 = (Button)gvadrecommended.Rows[i].FindControl("Button2");
                    //    Button2.Visible = false;
                    //    Button1.Visible = false;
                    //    (gvadrecommended.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).Visible = false;
                    //    if (ds.Rows.Count == rejectedcount)
                    //    {
                    //        gvadrecommended.Columns[12].Visible = false;
                    //        gvadrecommended.Columns[10].Visible = false;
                    //        gvadrecommended.Columns[9].Visible = false;
                    //    }
                    //}

                }
            }
            if (gvDDrcrecommended.Rows.Count < 1)
            {
                trinspectionname1.Visible = false;
                trInspectionReport4.Visible = false;
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    public DataSet getJDSSCList(string incentiveid, string mstincentiveid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_JD_SSC_DTLS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@INCENTIVEID", SqlDbType.VarChar).Value = incentiveid.ToString();
            if (mstincentiveid != null && mstincentiveid != null)
            {
                da.SelectCommand.Parameters.Add("@MSTINCENTVEID", SqlDbType.VarChar).Value = mstincentiveid.ToString();
            }
            else
            {
                da.SelectCommand.Parameters.Add("@MSTINCENTVEID", SqlDbType.VarChar).Value = null;
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


    protected void rdbCaste_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbCaste.SelectedIndex == 0 || rdbCaste.SelectedIndex == 1 || rdbCaste.SelectedIndex == 2 || rdbCaste.SelectedIndex == 3)
        {
            rdbCaste.Enabled = false;
            rdbGender.Enabled = true;

        }
    }
    protected void rdbGender_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbGender.SelectedIndex == 0 || rdbGender.SelectedIndex == 1)
        {
            rdbGender.Enabled = false;
            rdbCategory.Enabled = true;

        }
    }
    protected void rdbCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbCategory.SelectedIndex == 0 || rdbCategory.SelectedIndex == 1 || rdbCategory.SelectedIndex == 2 || rdbCategory.SelectedIndex == 3 || rdbCategory.SelectedIndex == 4)
        {
            rdbCategory.Enabled = false;
            rdbEnterprise.Enabled = true;

        }
    }
    protected void rdbEnterprise_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbEnterprise.SelectedIndex == 0 || rdbEnterprise.SelectedIndex == 1)
        {
            rdbEnterprise.Enabled = false;
            rdbSector.Enabled = true;

        }
    }
    protected void rdbSector_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbSector.SelectedIndex == 0 || rdbSector.SelectedIndex == 1)
        {
            rdbSector.Enabled = false;
            if (rdbSector.SelectedIndex != 0)
            {
                casteGenderGmUpdate = "Y";
                ViewState["casteGenderGmUpdate"] = casteGenderGmUpdate;
            }
            else
            {
                trServiceType.Visible = true;
                rdbServiceType.Enabled = true;
            }

            //trForwardApplicationTo.Visible = true;
            //trForwardGMGrid.Visible = true;
            //trFowardNote.Visible = true;

        }
    }
    protected void txtrecomandedamount_TextChanged(object sender, EventArgs e)
    {
        string test;
        test = "";
        decimal n;

        //var stringNumber = "123";
        int numericValue;
        bool isNumber = false;
        TextBox txtrecomandedamount = (TextBox)sender;

        GridViewRow row = (GridViewRow)txtrecomandedamount.NamingContainer;
        TextBox txtIncQuery = (TextBox)row.FindControl("txtIncQueryFnl2");
        Label enterid = (Label)row.FindControl("lblIncentiveID");
        Label lblMstIncentiveId = (Label)row.FindControl("lblMstIncentiveId");


        Button Button1 = (Button)row.FindControl("Button1");
        Button Button2 = (Button)row.FindControl("Button2");
        Button Button3otp = (Button)row.FindControl("btnotp");
        isNumber = int.TryParse(txtrecomandedamount.Text, out numericValue);
        string test111 = numericValue.ToString();
        //bool isNumeric = decimal.TryParse(txtrecomandedamount.Text, out n);
        if (isNumber == true && txtrecomandedamount.Text != "")
        {


            if (ddlapplicationto.SelectedIndex == 1)
            {
                Button1.Visible = true;
                Button2.Visible = false;
                Button3otp.Visible = true;
            }
            else if (ddlapplicationto.SelectedIndex == 2)
            {
                Button1.Visible = false;
                Button2.Visible = true;
            }
        }
        else if (txtrecomandedamount.Text != "" && isNumber == false)
        {
            string message1 = "alert('Please enter only decimal values for recommended amount!')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message1, true);
            txtrecomandedamount.Text = "";
            txtrecomandedamount.Focus();
            return;
        }
    }

    protected void rdbTransportNonTrans_SelectedIndexChanged(object sender, EventArgs e)
    {
        rdbTransportNonTrans.Enabled = false;
        casteGenderGmUpdate = "Y";
        ViewState["casteGenderGmUpdate"] = casteGenderGmUpdate;
    }

    protected void rdbServiceType_SelectedIndexChanged(object sender, EventArgs e)
    {
        rdbServiceType.Enabled = false;
        rdbTransportNonTrans.Enabled = true;
        trTransNonTrans.Visible = true;
        rdbTransportNonTrans.Visible = true;
    }

    public DataSet GetInspectionreportData(string incentiveID, string Incids)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            // da = new SqlDataAdapter("[FETCHINC_DETAILS_ID]", con.GetConnection);
            da = new SqlDataAdapter("[USP_GET_DATA_INSPECTIONREPORT]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (incentiveID.ToString() != "" || incentiveID.ToString() != null)
            {
                // da.SelectCommand.Parameters.Add("intUserID", SqlDbType.VarChar).Value = userid;
                da.SelectCommand.Parameters.Add("@IncentveID", SqlDbType.VarChar).Value = incentiveID;
                da.SelectCommand.Parameters.Add("@MSTINCENTVEID", SqlDbType.VarChar).Value = Incids;
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
    protected void ddlraisequery_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (ddlraisequery.SelectedValue == "2")
            {
                TRSUBMITQUERY_BEFOREINSPECCTIONDATE.Visible = true;
                DataSet DSQUERYDESC = new DataSet();
                DSQUERYDESC = GETQUERYRAISEDATTACHMENTSNAMES(ViewState["IncentveID"].ToString(), hdnattachmentids.Value);
                if (DSQUERYDESC != null && DSQUERYDESC.Tables.Count > 0 && DSQUERYDESC.Tables[0].Rows.Count > 0)
                {
                    txtquerydescriptionbeforeinspectiondate.Text = DSQUERYDESC.Tables[0].Rows[0]["QUERYRDESCRIPTION"].ToString();
                }
                else
                {
                    txtquerydescriptionbeforeinspectiondate.Text = "";
                }
            }
            else
            {

                TRSUBMITQUERY_BEFOREINSPECCTIONDATE.Visible = false;
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }

    }
    public DataSet GETQUERYRAISEDATTACHMENTSNAMES(string incentiveID, string ATTACHMENTIDS)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GETQUERYRAISEDATTACHMENTSNAMES", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (ATTACHMENTIDS.ToString() != "" || ATTACHMENTIDS.ToString() != null)
            {
                da.SelectCommand.Parameters.Add("@IncentveID", SqlDbType.VarChar).Value = incentiveID;
                da.SelectCommand.Parameters.Add("@ATTACHMENTIDS", SqlDbType.VarChar).Value = ATTACHMENTIDS;
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
    protected void btnsubmitquerybeforeinspectiondate_Click(object sender, EventArgs e)
    {
        try
        {

            //int incRtrVal = Gen.InsertIOqueryDtls(Request.QueryString[0].ToString(), txtquerydescriptionbeforeinspectiondate.Text, Session["uid"].ToString(), ViewState["MstIncentiveId"].ToString(), getclientIP(), hdnattachmentids.Value);
            //if (incRtrVal > 0)
            //{
            //    string message = "alert('Query Submitted Successfully')";
            //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

            //}
            string intApplicationid, Modified_by, EMiUdyogAadhar, SentFrom, Status, MstIncentiveId, txtIncQuery, txtinspectiondatekk;

            string intApplicationidnew = "";
            string StatusApp = Request.QueryString[1].ToString();
            foreach (GridViewRow gvrow in gvdicinspection.Rows)
            {

                intApplicationid = ((Label)gvrow.FindControl("lblIncentiveID")).Text.ToString();
                intApplicationidnew = intApplicationid;
                MstIncentiveId = ((Label)gvrow.FindControl("lblMstIncentiveId")).Text.ToString();

                //txtIncQuery = ((TextBox)gvrow.FindControl("txtIncQueryFnl")).Text.ToString();
                // txtinspectiondate = ((TextBox)gvrow.FindControl("txtinspectiondate")).Text.ToString();
                EMiUdyogAadhar = txtudyogAadharNo.Text;
                Modified_by = Session["uid"].ToString();
                SentFrom = Session["User_Code"].ToString();
                Status = "3";
                string deptIPOName = Session["username"].ToString();
                string deptIPOMoileNO = Session["MobileNumber"].ToString();
                DataSet dsdt = new DataSet();
                dsdt = Gen.GetDepartmentUserDeails(Session["username"].ToString());
                if (dsdt != null && dsdt.Tables.Count > 0 && dsdt.Tables[0].Rows.Count > 0)
                {
                    deptIPOName = dsdt.Tables[0].Rows[0]["empnsme"].ToString();
                    deptIPOMoileNO = dsdt.Tables[0].Rows[0]["Mobile"].ToString();
                }

                if (ViewState["DisignationLoad"].ToString().Trim() == "IPO" || ViewState["DisignationLoad"].ToString().Trim() == "AD" || ViewState["DisignationLoad"].ToString().Trim() == "DD")
                {

                    int incRtrVal = Gen.InsertIOqueryDtls(Request.QueryString[0].ToString(), txtquerydescriptionbeforeinspectiondate.Text, Session["uid"].ToString(), MstIncentiveId.ToString(), getclientIP(), hdnattachmentids.Value);
                    if (incRtrVal > 0)
                    {
                        string message = "alert('Query Submitted Successfully')";
                        btnsubmitquerybeforeinspectiondate.Enabled = false;
                        ddlinspectionorquery.Enabled = false;
                        btnSubmit.Enabled = false;
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                    }

                    else
                    {

                        return;
                    }
                }



            }

        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }

    }

    protected void ddlinspectionorquery_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlinspectionorquery.SelectedValue == "1")
        {
            tripoinsp1button0.Visible = true;
            tripoinsp1button.Visible = true;
            trraisequery.Visible = false;
            TRSUBMITQUERY_BEFOREINSPECCTIONDATE.Visible = false;
        }
        if (ddlinspectionorquery.SelectedValue == "2")
        {
            tripoinsp1button0.Visible = false;
            tripoinsp1button.Visible = false;
            TRSUBMITQUERY_BEFOREINSPECCTIONDATE.Visible = true;

        }
    }
    public DataSet GETQUERYRESPONSEATTACHMENTSOUTSIDECHECKSLIP(string incentiveID, string MstIncentiveId)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[USP_GET_QUERYRESPONSEATTACHMENTSOUTSIDECHECKSLIP]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (incentiveID.ToString() != "" || incentiveID.ToString() != null)
            {
                // da.SelectCommand.Parameters.Add("intUserID", SqlDbType.VarChar).Value = userid;
                da.SelectCommand.Parameters.Add("@IncentveID", SqlDbType.VarChar).Value = incentiveID;
                da.SelectCommand.Parameters.Add("@MstIncentiveId", SqlDbType.VarChar).Value = MstIncentiveId;
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

    protected void gridviewresponseattachmentsoutsidecheckslip_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = (e.Row.FindControl("lbl") as Label);
                HyperLink HyperLinkSubsidy = (e.Row.FindControl("HyperLinkSubsidy") as HyperLink);


            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int valid = 0;
        int rowCount = GridView3att.Rows.Count;
        int rowCountinc = 0;

        try
        {



            while (rowCountinc < rowCount)  //added newly on 25.02.2020.
            {

                Label lbltext = (Label)GridView3att.Rows[rowCountinc].FindControl("lbl");
                string text = lbltext.Text.ToString();
                // CheckBox chkverified = (CheckBox)GridView3att.Rows[rowCountinc].FindControl("chkverified");
                RadioButtonList rbtverified = (RadioButtonList)GridView3att.Rows[rowCountinc].FindControl("rbtverified");
                if ((rbtverified.SelectedValue == "" || rbtverified.SelectedValue == null || rbtverified.SelectedValue == "") && rbtverified.Visible == true)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please verify all the attachments');", true);
                    return;
                }
                rowCountinc = rowCountinc + 1;
            }

            if (valid == 0)
            {


                foreach (GridViewRow gvrow in GridView3att.Rows)
                {
                    string attid = ((Label)gvrow.FindControl("lblatchid")).Text.ToString();
                    //CheckBox chkverified = ((CheckBox)gvrow.FindControl("chkverified"));
                    RadioButtonList rbtverified = ((RadioButtonList)gvrow.FindControl("rbtverified"));


                    if (rbtverified.Visible == true && (rbtverified.SelectedValue == "Y" || rbtverified.SelectedValue == "N") && attid != "0" && attid != "")
                    {
                        int valid1 = Gen.UpdateverifyInctveattachment(ViewState["IncentveID"].ToString(), attid, Session["uid"].ToString(), rbtverified.SelectedValue);
                    }

                }
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Attachments Verified Successfully');", true);


            }

        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();

        }
        DataSet dsADrec = new DataSet();
        dsADrec = GETNOTVERIFIEDATTACHMENTIDS(ViewState["IncentveID"].ToString());
        if (dsADrec != null && dsADrec.Tables.Count > 0 && dsADrec.Tables[0].Rows.Count > 0)
        {

            if (dsADrec.Tables[0].Rows[0]["ATTACHMENTID"].ToString() == null || dsADrec.Tables[0].Rows[0]["ATTACHMENTID"].ToString() == "")
            {
                trinspectionorraisequery.Visible = true;
                //tripoinsp1button0.Visible = true;
                //tripoinsp1button.Visible = true;
                //trraisequery.Visible = true;
            }
            else
            {
                hdnattachmentids.Value = dsADrec.Tables[0].Rows[0]["ATTACHMENTID"].ToString();
                tripoinsp1button0.Visible = false;
                tripoinsp1button.Visible = false;
                trraisequery.Visible = true;


            }
        }
    }

    public DataSet GETNOTVERIFIEDATTACHMENTIDS(string incentiveID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            // da = new SqlDataAdapter("[FETCHINC_DETAILS_ID]", con.GetConnection);
            da = new SqlDataAdapter("[GETNOTVERIFIEDATTACHMENTIDS]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (incentiveID.ToString() != "" || incentiveID.ToString() != null)
            {
                // da.SelectCommand.Parameters.Add("intUserID", SqlDbType.VarChar).Value = userid;
                da.SelectCommand.Parameters.Add("@INCENTIVEID", SqlDbType.VarChar).Value = incentiveID;

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
    protected void GridView3att_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = (e.Row.FindControl("lbl") as Label);
                HyperLink HyperLinkSubsidy = (e.Row.FindControl("HyperLinkSubsidy") as HyperLink);
                //CheckBox chkverified = (e.Row.FindControl("chkverified") as CheckBox);
                RadioButtonList rbtverified = (e.Row.FindControl("rbtverified") as RadioButtonList);
                Label lblVerifiednew = (e.Row.FindControl("lblVerified") as Label);
                if (lbl.Text != "")
                {
                    string filepathnew = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LINKNEW"));
                    if (filepathnew != "")
                    {
                        string encpassword = Gen.Encrypt(filepathnew, "SYSTIME");
                        HyperLinkSubsidy.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    }
                    else
                    {
                        HyperLinkSubsidy.Visible = false;
                    }
                }
                if (lbl.Text == "")
                {
                    HyperLinkSubsidy.Visible = false;
                    e.Row.Font.Bold = true;
                    rbtverified.Visible = false;
                }
                if (HyperLinkSubsidy.NavigateUrl == "")
                {
                    HyperLinkSubsidy.Visible = false;
                    rbtverified.Visible = false;
                }
                if (lblVerifiednew.Text == "YES" && rbtverified.Visible == true)
                {

                    rbtverified.SelectedValue = "Y";
                    rbtverified.Enabled = false;
                }
                if (lblVerifiednew.Text == "WRONG" && rbtverified.Visible == true)
                {

                    rbtverified.SelectedValue = "N";
                    rbtverified.Enabled = false;
                }

            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
        }
    }

    protected void BtnSave3_Click(object sender, EventArgs e)
    {
        //int valid = 0;
        Failure.Visible = false;
        string newPath = "";
        General t1 = new General();

        if (FileUploadsscreport.HasFile)
        {
            string incentiveid = ViewState["IncentveID"].ToString();

            if ((FileUploadsscreport.PostedFile != null) && (FileUploadsscreport.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUploadsscreport.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUploadsscreport.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\197");

                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUploadsscreport.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();
                        string Path = serverpath;
                        string FileName = sFileName;

                        t1.InsertIncentiveAttachment(incentiveid, "0", "197", sFileName, serverpath, CrtdUser);

                        lblFileNamesscreport.Text = sFileName;
                        string Pathnew = serverpath + "\\" + sFileName;
                        lblFileNamesscreport.Text = Pathnew.ToString().Replace("\\", "/");
                        lblFileNamesscreport.NavigateUrl = lblFileNamesscreport.Text;
                        FileUploadsscreport.Focus();

                        //FileInfo fi = new FileInfo(newPath + "\\" + sFileName);
                        //if (fi.Exists)//if file exists delete it
                        //{
                        //fi.Delete();
                        //}
                        //else
                        //{
                        //}
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Invalid Format Uploaded');", true);
                        FileUploadsscreport.Focus();
                        return;
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
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Select a file To Upload..!');", true);
            FileUploadsscreport.Focus();
            return;
        }
    }

    public DataSet getJDreturnedList(string incentiveid, string mstincentiveid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_JD_RETURNED_DTLS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@INCENTIVEID", SqlDbType.VarChar).Value = incentiveid.ToString();
            if (mstincentiveid != null && mstincentiveid != null)
            {
                da.SelectCommand.Parameters.Add("@MSTINCENTVEID", SqlDbType.VarChar).Value = mstincentiveid.ToString();
            }
            else
            {
                da.SelectCommand.Parameters.Add("@MSTINCENTVEID", SqlDbType.VarChar).Value = null;
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
    public DataSet getSVCDEPTreturnedList(string incentiveid, string mstincentiveid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_SVCDEPT_RETURNED_DTLS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@INCENTIVEID", SqlDbType.VarChar).Value = incentiveid.ToString();
            if (mstincentiveid != null && mstincentiveid != null)
            {
                da.SelectCommand.Parameters.Add("@MSTINCENTVEID", SqlDbType.VarChar).Value = mstincentiveid.ToString();
            }
            else
            {
                da.SelectCommand.Parameters.Add("@MSTINCENTVEID", SqlDbType.VarChar).Value = null;
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
    public DataSet getSVCDEPAPPROVEDList(string incentiveid, string mstincentiveid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_SVCDEPT_APPROVED_DTLS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@INCENTIVEID", SqlDbType.VarChar).Value = incentiveid.ToString();
            if (mstincentiveid != null && mstincentiveid != null)
            {
                da.SelectCommand.Parameters.Add("@MSTINCENTVEID", SqlDbType.VarChar).Value = mstincentiveid.ToString();
            }
            else
            {
                da.SelectCommand.Parameters.Add("@MSTINCENTVEID", SqlDbType.VarChar).Value = null;
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
    public DataSet getCOMMISSIONERreturnedList(string incentiveid, string mstincentiveid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_COMMISSIONER_RETURNED_DTLS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@INCENTIVEID", SqlDbType.VarChar).Value = incentiveid.ToString();
            if (mstincentiveid != null && mstincentiveid != null)
            {
                da.SelectCommand.Parameters.Add("@MSTINCENTVEID", SqlDbType.VarChar).Value = mstincentiveid.ToString();
            }
            else
            {
                da.SelectCommand.Parameters.Add("@MSTINCENTVEID", SqlDbType.VarChar).Value = null;
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
    public DataSet getCOMMISSIONERAPPROVEDList(string incentiveid, string mstincentiveid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_COMMISSIONER_APPROVED_DTLS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@INCENTIVEID", SqlDbType.VarChar).Value = incentiveid.ToString();
            if (mstincentiveid != null && mstincentiveid != null)
            {
                da.SelectCommand.Parameters.Add("@MSTINCENTVEID", SqlDbType.VarChar).Value = mstincentiveid.ToString();
            }
            else
            {
                da.SelectCommand.Parameters.Add("@MSTINCENTVEID", SqlDbType.VarChar).Value = null;
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
    public DataSet getaddlreturnedList(string incentiveid, string mstincentiveid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_ADDL_RETURNED_DTLS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@INCENTIVEID", SqlDbType.VarChar).Value = incentiveid.ToString();
            if (mstincentiveid != null && mstincentiveid != null)
            {
                da.SelectCommand.Parameters.Add("@MSTINCENTVEID", SqlDbType.VarChar).Value = mstincentiveid.ToString();
            }
            else
            {
                da.SelectCommand.Parameters.Add("@MSTINCENTVEID", SqlDbType.VarChar).Value = null;
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

    public DataSet GetAddlSSCData(string incentiveID, string ApplicationLevel, string SentFrom, string TypeDashboard, string Incids)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[USP_GET_ADDL_SSC_DTLS]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (incentiveID.ToString() != "" || incentiveID.ToString() != null)
            {
                // da.SelectCommand.Parameters.Add("intUserID", SqlDbType.VarChar).Value = userid;
                da.SelectCommand.Parameters.Add("@IncentveID", SqlDbType.VarChar).Value = incentiveID;
                da.SelectCommand.Parameters.Add("@ApplicationLevel", SqlDbType.VarChar).Value = ApplicationLevel;
                da.SelectCommand.Parameters.Add("@SentFrom", SqlDbType.VarChar).Value = SentFrom;
                da.SelectCommand.Parameters.Add("@TypeDashboard", SqlDbType.VarChar).Value = TypeDashboard;
                da.SelectCommand.Parameters.Add("@MSTINCENTVEID", SqlDbType.VarChar).Value = Incids;
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

    protected void gvsscinspection_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //if (e.Row.RowState.Equals(DataControlRowState.Edit))
                //{
                HyperLink hpquerylinkcoissc = (e.Row.FindControl("hpquerylinkcoissc") as HyperLink);
                string filepathnew = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LINKNEW"));
                if (filepathnew != "")
                {
                    string encpassword = Gen.Encrypt(filepathnew, "SYSTIME");
                    hpquerylinkcoissc.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                }
                else
                {
                    hpquerylinkcoissc.Visible = false;
                }
                Button btnUpload = e.Row.FindControl("btnsendcoissc") as Button;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(btnUpload);
                // }

                Button btncoigmraisequery = e.Row.FindControl("btncoigmraisequeryssc") as Button;
                Label ResponceApps = e.Row.FindControl("lblenterrespssc") as Label;
                if (ResponceApps.Text.Trim() == "")
                {
                    //btncoigmraisequery.Visible = false;
                }

                string gmquerystatus = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Responce"));
                //if (gmquerystatus == "GMQUERYRAISED") --changed
                if (gmquerystatus == "SSC REPORT" && ResponceApps.Text.ToString() != "")   //added newly..
                {
                    //btncoigmraisequery.Visible = false;
                    //btncoigmraisequery.Visible = true;  //changed
                    //btnUpload.Visible = false;  --changed
                    btnUpload.Visible = true;
                    btnUpload.Enabled = true;
                }
                if (gmquerystatus == "" && ResponceApps.Text.ToString() == "") //added newly..
                {
                    //btncoigmraisequery.Visible = false;
                    btnUpload.Visible = false;
                    btnUpload.Enabled = false;
                    btnUpload.Text = "Query not responded";
                }
                Label lblQueryCreatedBy = e.Row.FindControl("lblQueryCreatedByssc") as Label;
                Label lblsscreport = e.Row.FindControl("SSCREPORT") as Label;
                //HyperLink HySSCinsp = e.Row.FindControl("hpquerylinkcoissc") as HyperLink;

                //HySSCinsp.NavigateUrl = lblsscreport.Text;


            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    public DataSet GetAddlSSCData_REPORT(string incentiveID, string ApplicationLevel, string SentFrom, string TypeDashboard, string Incids)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[USP_GET_ADDL_SSC_DTLS_REPORT]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (incentiveID.ToString() != "" || incentiveID.ToString() != null)
            {
                // da.SelectCommand.Parameters.Add("intUserID", SqlDbType.VarChar).Value = userid;
                da.SelectCommand.Parameters.Add("@IncentveID", SqlDbType.VarChar).Value = incentiveID;
                da.SelectCommand.Parameters.Add("@ApplicationLevel", SqlDbType.VarChar).Value = ApplicationLevel;
                da.SelectCommand.Parameters.Add("@SentFrom", SqlDbType.VarChar).Value = SentFrom;
                da.SelectCommand.Parameters.Add("@TypeDashboard", SqlDbType.VarChar).Value = TypeDashboard;
                da.SelectCommand.Parameters.Add("@MSTINCENTVEID", SqlDbType.VarChar).Value = Incids;
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
    protected void rbtISINSLCORNOT_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlapplicationto.ClearSelection();
        ddlapplicationto.Enabled = true;
        DataSet DSISDATA = new DataSet();
        if (rbtISINSLCORNOT.SelectedValue == "Y")
        {


            DSISDATA = GETSANCTIONEDDAT_IS(Convert.ToString(Request.QueryString[0]));
            if (DSISDATA != null && DSISDATA.Tables.Count > 0 && DSISDATA.Tables[0].Rows.Count > 0)
            {
                HDNISSANCTIONEDINSLCORNOT.Value = "Y";
                rbtISINSLCORNOT.SelectedValue = "Y";
                ddlapplicationto.SelectedValue = "1";
                ddlapplicationto.Enabled = false;
                rdbCaste.Enabled = false;
                rdbGender.Enabled = false;
                rdbCategory.Enabled = false;
                rdbEnterprise.Enabled = false;
                rdbSector.Enabled = false;
            }
            else
            {
                HDNISSANCTIONEDINSLCORNOT.Value = "N";
                rbtISINSLCORNOT.SelectedValue = "N";
                ddlapplicationto.ClearSelection();
                ddlapplicationto.Enabled = true;
                rdbCaste.Enabled = true;
                rdbGender.Enabled = true;
                rdbCategory.Enabled = true;
                rdbEnterprise.Enabled = true;
                rdbSector.Enabled = true;
            }
        }
        else
        {
            HDNISSANCTIONEDINSLCORNOT.Value = "N";
            rbtISINSLCORNOT.SelectedValue = "N";
            ddlapplicationto.ClearSelection();
            ddlapplicationto.Enabled = true;
            rdbCaste.Enabled = true;
            rdbGender.Enabled = true;
            rdbCategory.Enabled = true;
            rdbEnterprise.Enabled = true;
            rdbSector.Enabled = true;
        }

    }

    public DataSet GETSANCTIONEDDAT_IS(string incentiveID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[USP_GET_IS_SANCTIONEDORNOT]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (incentiveID.ToString() != "" || incentiveID.ToString() != null)
            {
                da.SelectCommand.Parameters.Add("@IncentveID", SqlDbType.VarChar).Value = incentiveID;
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


}