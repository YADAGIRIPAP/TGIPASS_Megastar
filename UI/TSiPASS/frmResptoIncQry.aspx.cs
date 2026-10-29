using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Reflection.Emit;
using Org.BouncyCastle.Crypto.Tls;


//done by nikhil - for incentives query response for applicant, design file - frmResptoIncQry.aspx
public partial class UI_TSiPASS_frmResptoIncQry : System.Web.UI.Page
{

    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    byte[] SelfCert;
    string SelfCertFileName = "";
    static DataTable dtMyTableCertificate;
    string AttachmentFilepath = "", AttachmentFileName = "";
    static DataTable dtMyTable;
    string intEnterpreniourApprovalid = "", intQuessionaireid = "", intCFEEnterpid = "", intDeptid = "", intApprovalid = "", QueryRaiseDate = "", QueryDescription = "", QueryStatus = "", Created_by = "", Created_dt = "";
    string queryid = "";
    int slno;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["EntrpId"] != null)
            {
                dtMyTableCertificate = createtablecrtificate();
                Session["CertificateTb2"] = dtMyTableCertificate;
                //Session["uid"] = Request.QueryString["EntrpId"].ToString();
                //txtdiscription.Visible = false;
                //lblDesc.Visible = true;
                //lblDesc.Text = txtdiscription.Text;
                //FileUpload1.Visible = false;
                //lblQryStatusResp.Visible = true;
                fillGrdDet();
            }
        }
    }

    public void fillGrdDet()
    {
        string JdOrGMflag = "";
        if (Request.QueryString["JdOrGMflag"] != null)
        {
            JdOrGMflag = Request.QueryString["JdOrGMflag"].ToString();
        }

        DataSet ds = new DataSet();
        if (JdOrGMflag == "JD")
        {
            hplLEtter.Visible = true;
            string testss = Request.QueryString["EntrpId"].ToString();
            string testsss = Request.QueryString["Inctypeid"].ToString();
            hplLEtter.NavigateUrl = "ProformaQueryRaiseShortFallLetter.aspx?" +
                "incentiveid=" + Request.QueryString["EntrpId"].ToString() + "&IncIds=" + Request.QueryString["Inctypeid"].ToString() + "";
            hplLEtter.Text = "Query Letter";
        }
        if (JdOrGMflag == "GM")
        {
            hplLEtter.Visible = true;
            string testss = Request.QueryString["EntrpId"].ToString();
            string testsss = Request.QueryString["Inctypeid"].ToString();

            hplLEtter.NavigateUrl = "ProformaQueryRaiseShortFallLetterGMtoApplicant.aspx?" +
                "incentiveid=" + Request.QueryString["EntrpId"].ToString() + "&IncIds=" + Request.QueryString["Inctypeid"].ToString() + "";
            hplLEtter.Text = "Query Letter";
        }
        if (JdOrGMflag == "IPO")
        {
            hplLEtter.Visible = true;
            string testss = Request.QueryString["EntrpId"].ToString();
            string testsss = Request.QueryString["Inctypeid"].ToString();

            hplLEtter.NavigateUrl = "QueryRaiseShortFallLetterinspectortoApplicantApproval.aspx?" +
                "incentiveid=" + Request.QueryString["EntrpId"].ToString() + "&MstIncentiveId=" + Request.QueryString["Inctypeid"].ToString() + "";
            hplLEtter.Text = "Query Letter";
        }

        if (JdOrGMflag == "GM")
        {
            hplLEtter.Visible = true;
            string testss = Request.QueryString["EntrpId"].ToString();
            string testsss = Request.QueryString["Inctypeid"].ToString();

            hplLEtter.NavigateUrl = "ProformaQueryRaiseShortFallLetterGMtoApplicant.aspx?" +
                "incentiveid=" + Request.QueryString["EntrpId"].ToString() + "&IncIds=" + Request.QueryString["Inctypeid"].ToString() + "";
            hplLEtter.Text = "Query Letter";
        }
        //https://ipass.telangana.gov.in/UI/TSiPASS/ProformaQueryRaiseShortFallLetterAddl.aspx?incentiveid=16681&IncIds=6
        ds = Gen.GetQueryDetailsdept("", Request.QueryString["EntrpId"].ToString(), Request.QueryString["Inctypeid"].ToString(), "S", JdOrGMflag);
        if (ds.Tables[0].Rows.Count > 0)
        {

            Label447.Text = ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
            Label448.Text = ds.Tables[0].Rows[0]["UnitName"].ToString();
            Label449.Text = ds.Tables[0].Rows[0]["Sector"].ToString().Trim();
            Label450.Text = ds.Tables[0].Rows[0]["Scheme"].ToString().Trim();
            Label451.Text = ds.Tables[0].Rows[0]["IncentiveName"].ToString().Trim();
            Label452.Text = ds.Tables[0].Rows[0]["DICName"].ToString().Trim();
            Label453.Text = ds.Tables[0].Rows[0]["queryRsdDate"].ToString().Trim();
            Label454.Text = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();

            hdfFlagID0.Value = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
            hdfFlagID1.Value = ds.Tables[0].Rows[0]["MstIncentiveId"].ToString();
            if (JdOrGMflag == "IPO")
            {

                if (ds.Tables[0].Rows[0]["queryattchmentids"].ToString() != null && ds.Tables[0].Rows[0]["queryattchmentids"].ToString() != "")
                {
                    HDNQUERYRAISEDIDS.Value = ds.Tables[0].Rows[0]["queryattchmentids"].ToString();
                    string[] split = ds.Tables[0].Rows[0]["queryattchmentids"].ToString().Split(',');
                    for (int i = 0; i < split.Length; i++)
                    {
                        TRRESPONSEATTACHMENT.Visible = false;
                        if (split[i].ToString().TrimStart().Trim() == "13")//registration deed
                        {
                            TRID13.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "15")// process flow
                        {
                            TRID15.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "101")//PAN / AADHAAR
                        {
                            TRID101.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "227")
                        {
                            TRID227.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "1")
                        {
                            TRID1.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "4")
                        {
                            TRID4.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "5")
                        {
                            TRID5.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "6")
                        {
                            TRID6.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "7")
                        {
                            TRID7.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "19")
                        {
                            TRID19.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "31")
                        {
                            TRID31.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "32")
                        {
                            TRID32.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "36")
                        {
                            TRID36.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "44")
                        {
                            TRID44.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "48")
                        {
                            TRID48.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "1001")
                        {
                            TRID1001.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "102")
                        {
                            TRID102.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "103")
                        {
                            TRID103.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "104")
                        {
                            TRID104.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "105")
                        {
                            TRID105.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "106")
                        {
                            TRID106.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "201")
                        {
                            TRID201.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "202")
                        {
                            TRID202.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "203")
                        {
                            TRID203.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "204")
                        {
                            TRID204.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "205")
                        {
                            TRID205.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "206")
                        {
                            TRID206.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "207")
                        {
                            TRID207.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "208")
                        {
                            TRID208.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "209")
                        {
                            TRID209.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "210")
                        {
                            TRID210.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "211")
                        {
                            TRID211.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "212")
                        {
                            TRID212.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "213")
                        {
                            TRID213.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "214")
                        {
                            TRID214.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "215")
                        {
                            TRID215.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "216")
                        {
                            TRID216.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "217")
                        {
                            TRID217.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "218")
                        {
                            TRID218.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "219")
                        {
                            TRID219.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "220")
                        {
                            TRID220.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "223")
                        {
                            TRID223.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "224")
                        {
                            TRID224.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "225")
                        {
                            TRID225.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "226")
                        {
                            TRID226.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "9053")
                        {
                            TRID9053.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "3001")
                        {
                            TRID3001.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "52")
                        {
                            TRID52.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "228")
                        {
                            TRID228.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "100010")
                        {
                            TRID100010.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "100011")
                        {
                            TRID100011.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "100012")
                        {
                            TRID100012.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "100013")
                        {
                            TRID100013.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "100014")
                        {
                            TRID100014.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "100015")
                        {
                            TRID100015.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "100016")
                        {
                            TRID100016.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "100017")
                        {
                            TRID100017.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "100019")
                        {
                            TRID100019.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "100020")
                        {
                            TRID100020.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "100021")
                        {
                            TRID100021.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "100022")
                        {
                            TRID100022.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "100023")
                        {
                            TRID100023.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "181")
                        {
                            TRID181.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "182")
                        {
                            TRID182.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "183")
                        {
                            TRID183.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "184")
                        {
                            TRID184.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "185")
                        {
                            TRID185.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "191")
                        {
                            TRID191.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "192")
                        {
                            TRID192.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "193")
                        {
                            TRID193.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "194")
                        {
                            TRID194.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "195")
                        {
                            TRID195.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "196")
                        {
                            TRID196.Visible = true;
                        }
                        if (split[i].ToString().TrimStart().Trim() == "100050")
                        {
                            TRDEETATTACHMENT100050.Visible = true;
                        }

                    }

                }
                else
                {
                    TRRESPONSEATTACHMENT.Visible = true;

                }
            }
            else
            {
                TRRESPONSEATTACHMENT.Visible = true;

            }


        }
        if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
        {
            lblquerydays.Text = Convert.ToString(ds.Tables[1].Rows[0]["querydays"]);
        }
    }


    void FillDetails()
    {
        DataSet ds = new DataSet();

        try
        {

            string userCreadted_by = Session["uid"].ToString().Trim();
            DataSet ds1 = new DataSet();
            ds1 = Gen.GetAllIncentives(userCreadted_by);

            ds = Gen.GetRespondQueryStatusfrIncentive(userCreadted_by);
            //[Label451]

            Label451.Text = "";

            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                Label451.Text = ds1.Tables[0].Rows[i]["IncentiveName"] + "," + Label451.Text;
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                Label447.Text = ds.Tables[0].Rows[0]["Udyog Adhaar"].ToString().Trim();
                Label448.Text = ds.Tables[0].Rows[0]["UnitName"].ToString().Trim();
                Label449.Text = ds.Tables[0].Rows[0]["Sector"].ToString().Trim();
                Label450.Text = ds.Tables[0].Rows[0]["Scheme"].ToString().Trim();
                //  Label451.Text = ds.Tables[0].Rows[0]["DepartmentName"].ToString().Trim();
                Label452.Text = ds.Tables[0].Rows[0]["DICName"].ToString().Trim();
                Label453.Text = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                Label454.Text = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();

            }
        }

        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();

        }
        finally
        {

        }


    }
    public string ValidateFileUploads()
    {
        slno = 1;
        string ErrorMsg = "";
        //if (txtdiscription.Text == "" || txtdiscription.Text == string.Empty || txtdiscription.Text ==null|| ((Label1.Text == "" || Label1.Text == string.Empty)&& TRRESPONSEATTACHMENT.Visible))
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please enter query description and upload response attachments. \\n";
        //    slno = slno + 1;
        //}

        if (txtdiscription.Text.Trim().TrimStart().TrimEnd() == "" || txtdiscription.Text.Trim().TrimStart().TrimEnd() == string.Empty || txtdiscription.Text.Trim().TrimStart().TrimEnd() == "\r\n")//|| txtIncQueryFnl2.Trim().TrimStart().TrimEnd() == "" removed by madhuri on 03/12/2024
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter query description . \\n";
            slno = slno + 1;
        }
        if (TRRESPONSEATTACHMENT.Visible == true && (gvCertificate.Rows.Count==0))
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload response attachment(s). \\n";
            slno = slno + 1;
        }

        if (lblid13.Text == "" && TRID13.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Civil Engineers certificate by civil Engineer of the financial Institution/Chartered Engineer. \\n";
            slno = slno + 1;
        }

        if (LBLID15.Text == "" && TRID15.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Statements of accounts in respect of Aided Enterprises. \\n";
            slno = slno + 1;
        }
        if (LBLID101.Text == "" && TRID101.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload List of Plant, Machinery and Equipment purchased and installed in the prescribed form with attested copies of bills and payment proof in respect of self financed Enterprises/industries. \\n";
            slno = slno + 1;
        }
        if (LBLID227.Text == "" && TRID227.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Photo of the Applicant along with the Equipment  in Respect of Mobile Units. \\n";
            slno = slno + 1;
        }
        if (LBLID1.Text == "" && TRID1.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Valid CFO/Acknowledgement from GM DIC concerned on pollution angle. \\n";
            slno = slno + 1;
        }
        if (LBLID4.Text == "" && TRID4.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Term Loan Certificate from Financial Institute. \\n";
            slno = slno + 1;
        }
        if (LBLID5.Text == "" && TRID5.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Self Certification. \\n";
            slno = slno + 1;
        }
        if (LBLID6.Text == "" && TRID6.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Power Bills and Payment Proof/Receipts. \\n";
            slno = slno + 1;
        }
        if (LBLID7.Text == "" && TRID7.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload CA Certificate showing Power Utilisation particulars for the last 3 Years. \\n";
            slno = slno + 1;
        }
        if (LBLID19.Text == "" && TRID19.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Copy of the Project Report and its approval report. \\n";
            slno = slno + 1;
        }
        if (LBLID31.Text == "" && TRID31.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Certificate of Functional Status issued by GM DIC at the time of acquiring ISO-9000/ISO-14001/HACCP-Certificate. \\n";
            slno = slno + 1;
        }
        if (LBLID32.Text == "" && TRID32.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Bills,Vouchers and proof of payment in support of Expenditure incurred for Certification. \\n";
            slno = slno + 1;
        }
        if (LBLID36.Text == "" && TRID36.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Certificate from Financial Institute in the prescribed Proforma. \\n";
            slno = slno + 1;
        }
        if (LBLID44.Text == "" && TRID44.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Form-A issued by CT Department. \\n";
            slno = slno + 1;
        }
        if (LBLID48.Text == "" && TRID48.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Copy of valid CFO if applicable. \\n";
            slno = slno + 1;
        }
        if (LBLID1001.Text == "" && TRID1001.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Certificate from the financing institution concerned showing term loan released and the value of assets acquired as on prior to filing of claim/within 6 months from the date of commencement of commercial production whichever is earlier together with other details and machinery statement as a statement of account in the form prescribed with attested copies of bills in case of institutionally financed Enterprises/industries. \\n";
            slno = slno + 1;
        }
        if (LBLID102.Text == "" && TRID102.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Caste Certificates issued by Tahsildar/MRO concerned in case of SC/ST Entrepreneur. \\n";
            slno = slno + 1;
        }
        if (LBLID103.Text == "" && TRID103.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Aadhar of the Entrepreneur. \\n";
            slno = slno + 1;
        }
        if (LBLID104.Text == "" && TRID104.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload PAN Card of the Entrepreneur. \\n";
            slno = slno + 1;
        }
        if (LBLID105.Text == "" && TRID105.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Certificate from the Chartered Accountant and percentage of holding of equity in the company by each partner/director. \\n";
            slno = slno + 1;
        }
        if (LBLID106.Text == "" && TRID106.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Regd. Partnership Deed/Articles of Association and Memorandum of Association in case of Private Limited and Limited companies along with incorporation certificate / Bye-laws in case of Indl. Cooperative along with Registration Certificate. \\n";
            slno = slno + 1;
        }
        if (LBLID201.Text == "" && TRID201.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Approval of Director of Factories. \\n";
            slno = slno + 1;
        }
        if (LBLID202.Text == "" && TRID202.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Boilers Certificate. \\n";
            slno = slno + 1;
        }
        if (LBLID203.Text == "" && TRID203.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Approval of Director of Town and Country Planning/UDA. \\n";
            slno = slno + 1;
        }
        if (LBLID204.Text == "" && TRID204.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Regular building plans approval of Municipality or Gram Panchayat. \\n";
            slno = slno + 1;
        }
        if (LBLID205.Text == "" && TRID205.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Consent for Operation from TSPCB/Acknowledgement from the General Manager, DIC concerned. \\n";
            slno = slno + 1;
        }
        if (LBLID206.Text == "" && TRID206.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Power release Certificate from TSTRANSCO/DISCOM. \\n";
            slno = slno + 1;
        }
        if (LBLID207.Text == "" && TRID207.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Environmental clearance. \\n";
            slno = slno + 1;
        }
        if (LBLID208.Text == "" && TRID208.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Other statutory approvals (specify). \\n";
            slno = slno + 1;
        }
        if (LBLID209.Text == "" && TRID209.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload EM Part I full set/IEM/IL. \\n";
            slno = slno + 1;
        }
        if (LBLID210.Text == "" && TRID210.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Udyog Aadhar. \\n";
            slno = slno + 1;
        }
        if (LBLID211.Text == "" && TRID211.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Project Report. \\n";
            slno = slno + 1;
        }
        if (LBLID212.Text == "" && TRID212.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Term loan sanction letters. \\n";
            slno = slno + 1;
        }
        if (LBLID213.Text == "" && TRID213.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Board Resolution authorizing to sign and file claim etc, in case of Pvt Ltd, Companies, Cooperatives and similar authorization in respect of partnership firms. \\n";
            slno = slno + 1;
        }
        if (LBLID214.Text == "" && TRID214.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Registered land Sale deed/Premises Lease deed. \\n";
            slno = slno + 1;
        }
        if (LBLID215.Text == "" && TRID215.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload CA and CE Certificate regarding 2nd hand plant and machinery. \\n";
            slno = slno + 1;
        }
        if (LBLID216.Text == "" && TRID216.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload CE Certificate for Self fabricated machinery. \\n";
            slno = slno + 1;
        }
        if (LBLID217.Text == "" && TRID217.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload BIS Certificate. \\n";
            slno = slno + 1;
        }
        if (LBLID218.Text == "" && TRID218.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Drug License. \\n";
            slno = slno + 1;
        }
        if (LBLID219.Text == "" && TRID219.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Explosive License. \\n";
            slno = slno + 1;
        }
        if (LBLID220.Text == "" && TRID220.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload VAT/CST/SGST Certificate. \\n";
            slno = slno + 1;
        }
        if (LBLID223.Text == "" && TRID223.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Production particulars for the last 3 years as per fixed capital investment and Line of Activity of the application duly certified by CA for the 1st time of the claim, if it is expansion/diversification project. \\n";
            slno = slno + 1;
        }
        if (LBLID224.Text == "" && TRID224.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload RTA Certificate. \\n";
            slno = slno + 1;
        }
        if (LBLID225.Text == "" && TRID225.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload PH Certificate. \\n";
            slno = slno + 1;
        }
        if (LBLID226.Text == "" && TRID226.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Undertaking and Finance Certificate Prescrbed Format. \\n";
            slno = slno + 1;
        }
        if (LBLID9053.Text == "" && TRID9053.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload CA Certificate as per Prescribed format. \\n";
            slno = slno + 1;
        }
        if (LBLID3001.Text == "" && TRID3001.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload CA. certificate of Pavala Vaddi. \\n";
            slno = slno + 1;
        }
        if (LBLID52.Text == "" && TRID52.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Attested copy of receipts from DISCOM. \\n";
            slno = slno + 1;
        }
        if (LBLID228.Text == "" && TRID228.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload First Sale Bill. \\n";
            slno = slno + 1;
        }
        if (LBLID100010.Text == "" && TRID100010.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Registered Land Sale deed/Lease Deed/Transfer deed/Land Conversion document(STAMPDUTY/TRANSFERDUTY). \\n";
            slno = slno + 1;
        }
        if (LBLID100011.Text == "" && TRID100011.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Payment Proof(STAMPDUTY/TRANSFERDUTY). \\n";
            slno = slno + 1;
        }
        if (LBLID100012.Text == "" && TRID100012.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Registered Land Sale deed/Lease Deed/Transfer deed/Land Conversion document(Mortgage Duty). \\n";
            slno = slno + 1;
        }
        if (LBLID100013.Text == "" && TRID100013.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Payment Proof(Mortgage Duty). \\n";
            slno = slno + 1;
        }
        if (LBLID100014.Text == "" && TRID100014.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Registered Land Sale deed/Lease Deed/Transfer deed/Land Conversion document(Land Conversion). \\n";
            slno = slno + 1;
        }
        if (LBLID100015.Text == "" && TRID100015.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Payment Proof(Land Conversion). \\n";
            slno = slno + 1;
        }
        if (LBLID100016.Text == "" && TRID100016.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Registered Land Sale deed/Lease Deed/Transfer deed/Land Conversion document(Land Cost). \\n";
            slno = slno + 1;
        }
        if (LBLID100017.Text == "" && TRID100017.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Payment Proof(Land Cost). \\n";
            slno = slno + 1;
        }
        if (LBLID100019.Text == "" && TRID100019.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload UNDERTAKING ON CO BORROWER/CO APPLICANT/CO OBLIGANT. \\n";
            slno = slno + 1;
        }
        if (LBLID100020.Text == "" && TRID100020.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Loan Account Statement. \\n";
            slno = slno + 1;
        }
        if (LBLID100021.Text == "" && TRID100021.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Caste certificate of co borrower. \\n";
            slno = slno + 1;
        }
        if (LBLID100022.Text == "" && TRID100022.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Factory License. \\n";
            slno = slno + 1;
        }
        if (LBLID100023.Text == "" && TRID100023.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload TMC and Star Rating. \\n";
            slno = slno + 1;
        }
        if (LBLID181.Text == "" && TRID181.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload SCCL CERTIFICATE/INVOICE. \\n";
            slno = slno + 1;
        }
        if (LBLID182.Text == "" && TRID182.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Way Bridge Documents/CA Certificate. \\n";
            slno = slno + 1;
        }
        if (LBLID183.Text == "" && TRID183.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Proof of Payment Receipts/Bank Statements(COAL). \\n";
            slno = slno + 1;
        }
        if (LBLID184.Text == "" && TRID184.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload CA Certificate(for Internal Power Generation/for Paper Production). \\n";
            slno = slno + 1;
        }
        if (LBLID185.Text == "" && TRID185.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Attested copy of Valid CFO(COAL). \\n";
            slno = slno + 1;
        }
        if (LBLID191.Text == "" && TRID191.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload TSFDC Certificate/Invoice. \\n";
            slno = slno + 1;
        }
        if (LBLID192.Text == "" && TRID192.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload CA certificate/Invoice. \\n";
            slno = slno + 1;
        }
        if (LBLID193.Text == "" && TRID193.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Proof of Payment Receipts/Bank Statements(WOOD). \\n";
            slno = slno + 1;
        }
        if (LBLID194.Text == "" && TRID194.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload CA Certificate for Paper Production. \\n";
            slno = slno + 1;
        }
        if (LBLID195.Text == "" && TRID195.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload CA Certificate for ADMT Quantity for wood Purchased. \\n";
            slno = slno + 1;
        }
        if (LBLID196.Text == "" && TRID196.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Attested copy of Valid CFO(WOOD). \\n";
            slno = slno + 1;
        }
        if (LBLDEET.Text == "" && LBLDEET.Visible)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload DEET Registration Acknowledgement. \\n";
            slno = slno + 1;
        }





        return ErrorMsg;
    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        DataSet dsMail;
        int valid = 0;
        if (ViewState["pathAttachment"] == null)
            ViewState["pathAttachment"] = "";
        if (ViewState["AttachmentName"] == null)
            ViewState["AttachmentName"] = "";
        try
        {
            //string errormsg = "";
            //if ((txtdiscription.Text == "" && txtdiscription.Text == string.Empty))
            //{
            //    lblmsg0.Text = "Please Enter Query Response ";
            //    errormsg = "Please Enter Query Response ";
            //    Failure.Visible = true;
            //    valid = 1;
            //    txtdiscription.Focus();
            //}
            //if (TRRESPONSEATTACHMENT.Visible == true && Label1.Text == "")
            //{
            //    lblmsg0.Text = "Please Upload Response Attachment ";
            //    errormsg = errormsg + "Please Upload Response Attachment ";
            //    Failure.Visible = true;
            //    valid = 1;
            //    txtdiscription.Focus();
            //}
            string errormsg =  ValidateFileUploads();
            if (errormsg.Trim().TrimStart() != "")
            {
                valid = 1;
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }

            if (valid == 0)
            {
                int result = 0;
                string queryresopnedesc = txtdiscription.Text.Trim();
                string JdOrGMflag = "";
                if (Request.QueryString["JdOrGMflag"] != null)
                {
                    JdOrGMflag = Request.QueryString["JdOrGMflag"].ToString();
                }
                //string incID, string QueryAttachmentFileName, string QueryAttachmentFilePath, string QueryRespondRemarks, string IPAddress, string Created_by

                result = Gen.InsrtQryRespDtlsFrIncQueryResponse(hdfFlagID0.Value, ViewState["AttachmentName"].ToString(), ViewState["pathAttachment"].ToString(), queryresopnedesc, getclientIP(), Session["uid"].ToString().Trim(), hdfFlagID1.Value, JdOrGMflag);
                //  public int InsrtQryRespDtlsFrIncQueryResponse(string incID, string QueryAttachmentFileName, string QueryAttachmentFilePath, string QueryRespondRemarks, string IPAddress, string Created_by, string MstIncentiveId)
                if (result == 1)
                {
                    dsMail = Gen.GetShowEmailidandMobileNumberforIncentive(Session["uid"].ToString().Trim());

                    if (dsMail.Tables[0].Rows.Count > 0)
                    {

                        //   cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["applcntName"].ToString().Trim() + " <br/><br/> <b> Response to query has been submitted successfully.Further details will be communicated. Thank You.");
                    }
                    // if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                    // {

                    // cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["applcntName"].ToString().Trim() + " - (" + Label447.Text + ") : Response to query has been submitted successfully.Further details will be communicated. Thank You.");
                    //  }


                    lblmsg.Text = "<font color='green'>Query Details Submitted Successfully..!</font>";
                    success.Visible = true;
                    BtnDelete.Visible = false;
                    Failure.Visible = false;
                    // Response.Redirect("DashBoard.aspx");

                }
                else
                {
                    lblmsg.Text = "<font color='red'>Submission Failed..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    //  Response.Redirect("DashBoard.aspx");
                }
            }
        }


        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();

        }
        finally
        {

        }
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        string newPath = "";
        gvCertificate.Visible = true;

        General t1 = new General();
        if (FileUpload1.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string ext = Path.GetExtension(sFileName);
                        string sFileNameonly = Path.GetFileNameWithoutExtension(sFileName);
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;

                        sFileName = sFileNameonly + Attachmentidnew + ext;
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);
                        //string serverpath =   (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload1.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Pathnew = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        // string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "0", Attachmentidnew);
                        string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
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

        gvCertificate.Visible = true;
    }
    protected void gvCertificate_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {

            ((DataTable)Session["CertificateTb2"]).Rows.RemoveAt(e.RowIndex);

            this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
            this.gvCertificate.DataBind();
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Please enter correct data";// ex.ToString();

        }
        finally
        {

        }
    }
    private void AddDataToTableCeertificate(string Filename, string filepath, DataTable myTable)
    {//totStartDate, string totEndDate, string totSummary,
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtMyTable = new DataTable("CertificateTb2");
            Row["FileName"] = Filename;
            Row["filepath"] = filepath;
            myTable.Rows.Add(Row);
        }
        catch (Exception ex)
        {
            //  ((DataTable)Session["myDatatable"]).Rows.Clear();
            //  Response.Redirect("~/EmpFacility.aspx");
        }
    }
    protected DataTable createtablecrtificate()
    {
        dtMyTable = new DataTable("CertificateTb2");

        // dtMyTable.Columns.Add("new", typeof(string));
        dtMyTable.Columns.Add("FileName", typeof(string));
        dtMyTable.Columns.Add("filepath", typeof(string));
        return dtMyTable;
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
    protected void btnatchid13_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (fupid13.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((fupid13.PostedFile != null) && (fupid13.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(fupid13.PostedFile.FileName);
                try
                {
                    string[] fileType = fupid13.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        fupid13.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "13", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        lblid13.Visible = true;
                        lblid13.Text = fupid13.FileName;
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

    protected void BTNID15_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID15.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID15.PostedFile != null) && (FUPID15.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID15.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID15.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID15.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "15", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID15.Visible = true;
                        LBLID15.Text = FUPID15.FileName;
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

    protected void BTNID101_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID101.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID101.PostedFile != null) && (FUPID101.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID101.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID101.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID101.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "101", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID101.Visible = true;

                        LBLID101.Text = FUPID101.FileName;
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

    protected void BTNID227_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID227.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID227.PostedFile != null) && (FUPID227.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID227.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID227.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID227.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "227", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID227.Visible = true;
                        LBLID227.Text = FUPID227.FileName;
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

    protected void BTNID1_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID1.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID1.PostedFile != null) && (FUPID1.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID1.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID1.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID1.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "1", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID1.Visible = true;
                        LBLID1.Text = FUPID1.FileName;
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

    protected void BTNID4_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID4.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID4.PostedFile != null) && (FUPID4.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID4.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID4.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID4.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "4", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID4.Visible = true;
                        LBLID4.Text = FUPID4.FileName;
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

    protected void BTNID5_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID5.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID5.PostedFile != null) && (FUPID5.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID5.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID5.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID5.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "5", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID5.Visible = true;
                        LBLID5.Text = FUPID5.FileName;
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

    protected void BTNID6_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID6.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID6.PostedFile != null) && (FUPID6.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID6.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID6.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID6.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "6", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID6.Visible = true;
                        LBLID6.Text = FUPID6.FileName;
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

    protected void BTNID7_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID7.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID7.PostedFile != null) && (FUPID7.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID7.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID7.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID7.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "7", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID7.Visible = true;
                        LBLID7.Text = FUPID7.FileName;
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

    protected void BTNID19_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID19.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID19.PostedFile != null) && (FUPID19.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID19.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID19.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID19.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "19", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID19.Visible = true;
                        LBLID19.Text = FUPID19.FileName;
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

    protected void BTNID31_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID31.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID31.PostedFile != null) && (FUPID31.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID31.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID31.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID31.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "31", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID31.Visible = true;
                        LBLID31.Text = FUPID31.FileName;
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

    protected void BTNID32_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID32.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID32.PostedFile != null) && (FUPID32.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID32.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID32.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID32.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "32", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID32.Visible = true;
                        LBLID32.Text = FUPID32.FileName;
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

    protected void BTNID36_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID36.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID36.PostedFile != null) && (FUPID36.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID36.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID36.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID36.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "36", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID36.Visible = true;
                        LBLID36.Text = FUPID36.FileName;
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

    protected void BTNID44_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID44.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID44.PostedFile != null) && (FUPID44.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID44.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID44.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID44.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "44", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID44.Visible = true;
                        LBLID44.Text = FUPID44.FileName;
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

    protected void BTNID48_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID48.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID48.PostedFile != null) && (FUPID48.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID48.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID48.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID48.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "48", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID48.Visible = true;
                        LBLID48.Text = FUPID48.FileName;
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

    protected void BTNID1001_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID1001.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID1001.PostedFile != null) && (FUPID1001.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID1001.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID1001.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID1001.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "1001", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID1001.Visible = true;
                        LBLID1001.Text = FUPID1001.FileName;
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

    protected void BTNID102_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID102.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID102.PostedFile != null) && (FUPID102.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID102.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID102.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID102.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "102", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID102.Visible = true;
                        LBLID102.Text = FUPID102.FileName;
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

    protected void BTNID103_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID103.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID103.PostedFile != null) && (FUPID103.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID103.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID103.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID103.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "103", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID103.Visible = true;
                        LBLID103.Text = FUPID103.FileName;
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

    protected void BTNID104_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID104.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID104.PostedFile != null) && (FUPID104.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID104.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID104.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID104.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "104", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID104.Visible = true;
                        LBLID104.Text = FUPID104.FileName;
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

    protected void BTNID105_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID105.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID105.PostedFile != null) && (FUPID105.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID105.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID105.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID105.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "105", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID105.Visible = true;
                        LBLID105.Text = FUPID105.FileName;
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

    protected void BTNID106_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID106.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID106.PostedFile != null) && (FUPID106.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID106.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID106.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID106.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "106", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID106.Visible = true;
                        LBLID106.Text = FUPID106.FileName;
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

    protected void BTNID201_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID201.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID201.PostedFile != null) && (FUPID201.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID201.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID201.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID201.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "201", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID201.Visible = true;
                        LBLID201.Text = FUPID201.FileName;
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

    protected void BTNID202_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID202.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID202.PostedFile != null) && (FUPID202.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID202.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID202.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID202.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "202", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID202.Visible = true;
                        LBLID202.Text = FUPID202.FileName;
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

    protected void BTNID203_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID203.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID203.PostedFile != null) && (FUPID203.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID203.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID203.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID203.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "203", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID203.Visible = true;
                        LBLID203.Text = FUPID203.FileName;
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

    protected void BTNID204_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID204.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID204.PostedFile != null) && (FUPID204.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID204.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID204.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID204.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "204", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID204.Visible = true;
                        LBLID204.Text = FUPID204.FileName;
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

    protected void BTNID205_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID205.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID205.PostedFile != null) && (FUPID205.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID205.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID205.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID205.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "205", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID205.Visible = true;
                        LBLID205.Text = FUPID205.FileName;
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

    protected void BTNID206_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID206.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID206.PostedFile != null) && (FUPID206.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID206.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID206.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID206.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "206", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID206.Visible = true;
                        LBLID206.Text = FUPID206.FileName;
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

    protected void BTNID207_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID207.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID207.PostedFile != null) && (FUPID207.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID207.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID207.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID207.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "207", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID207.Visible = true;
                        LBLID207.Text = FUPID207.FileName;
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

    protected void BTNID208_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID208.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID208.PostedFile != null) && (FUPID208.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID208.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID208.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID208.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "208", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID208.Visible = true;
                        LBLID208.Text = FUPID208.FileName;
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

    protected void BTNID209_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID209.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID209.PostedFile != null) && (FUPID209.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID209.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID209.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID209.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "209", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID209.Visible = true;
                        LBLID209.Text = FUPID209.FileName;
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

    protected void BTNID210_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID210.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID210.PostedFile != null) && (FUPID210.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID210.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID210.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID210.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "210", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID210.Visible = true;
                        LBLID210.Text = FUPID210.FileName;
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

    protected void BTNID211_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID211.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID211.PostedFile != null) && (FUPID211.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID211.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID211.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID211.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "211", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID211.Visible = true;
                        LBLID211.Text = FUPID211.FileName;
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

    protected void BTNID212_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID212.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID212.PostedFile != null) && (FUPID212.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID212.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID212.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID212.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "212", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID212.Visible = true;
                        LBLID212.Text = FUPID212.FileName;
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

    protected void BTNID213_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID213.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID213.PostedFile != null) && (FUPID213.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID213.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID213.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID213.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "213", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID213.Visible = true;
                        LBLID213.Text = FUPID213.FileName;
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

    protected void BTNID214_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID214.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID214.PostedFile != null) && (FUPID214.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID214.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID214.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID214.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "214", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID214.Visible = true;
                        LBLID214.Text = FUPID214.FileName;
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

    protected void BTNID215_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID215.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID215.PostedFile != null) && (FUPID215.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID215.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID215.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID215.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "215", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID215.Visible = true;
                        LBLID215.Text = FUPID215.FileName;
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

    protected void BTNID216_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID216.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID216.PostedFile != null) && (FUPID216.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID216.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID216.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID216.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "216", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID216.Visible = true;
                        LBLID216.Text = FUPID216.FileName;
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

    protected void BTNID217_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID217.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID217.PostedFile != null) && (FUPID217.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID217.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID217.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID217.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "217", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID217.Visible = true;
                        LBLID217.Text = FUPID217.FileName;
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

    protected void BTNID218_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID218.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID218.PostedFile != null) && (FUPID218.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID218.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID218.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID218.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "218", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID218.Visible = true;
                        LBLID218.Text = FUPID218.FileName;
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

    protected void BTNID219_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID219.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID219.PostedFile != null) && (FUPID219.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID219.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID219.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID219.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "219", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID219.Visible = true;
                        LBLID219.Text = FUPID219.FileName;
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

    protected void BTNID220_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID220.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID220.PostedFile != null) && (FUPID220.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID220.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID220.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID220.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "220", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID220.Visible = true;
                        LBLID220.Text = FUPID220.FileName;
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

    protected void BTNID223_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID223.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID223.PostedFile != null) && (FUPID223.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID223.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID223.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID223.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "223", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID223.Visible = true;
                        LBLID223.Text = FUPID223.FileName;
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

    protected void BTNID224_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID224.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID224.PostedFile != null) && (FUPID224.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID224.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID224.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID224.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "224", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID224.Visible = true;
                        LBLID224.Text = FUPID224.FileName;
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

    protected void BTNID225_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID225.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID225.PostedFile != null) && (FUPID225.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID225.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID225.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID225.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "225", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID225.Visible = true;
                        LBLID225.Text = FUPID225.FileName;
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

    protected void BTNID226_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID226.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID226.PostedFile != null) && (FUPID226.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID226.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID226.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID226.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "226", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID226.Visible = true;
                        LBLID226.Text = FUPID226.FileName;
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

    protected void BTNID9053_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID9053.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID9053.PostedFile != null) && (FUPID9053.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID9053.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID9053.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID9053.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "9053", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID9053.Visible = true;
                        LBLID9053.Text = FUPID9053.FileName;
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

    protected void BTNID3001_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID3001.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID3001.PostedFile != null) && (FUPID3001.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID3001.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID3001.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID3001.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "3001", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID3001.Visible = true;
                        LBLID3001.Text = FUPID3001.FileName;
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

    protected void BTNID52_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID52.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID52.PostedFile != null) && (FUPID52.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID52.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID52.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID52.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "52", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID52.Visible = true;
                        LBLID52.Text = FUPID52.FileName;
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

    protected void BTNID228_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID228.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID228.PostedFile != null) && (FUPID228.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID228.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID228.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID228.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "228", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID228.Visible = true;
                        LBLID228.Text = FUPID228.FileName;
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

    protected void BTNID100010_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID100010.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID100010.PostedFile != null) && (FUPID100010.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID100010.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID100010.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID100010.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "100010", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID100010.Visible = true;
                        LBLID100010.Text = FUPID100010.FileName;
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

    protected void BTNID100011_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID100011.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID100011.PostedFile != null) && (FUPID100011.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID100011.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID100011.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID100011.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "100011", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID100011.Visible = true;
                        LBLID100011.Text = FUPID100011.FileName;
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

    protected void BTNID100012_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID100012.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID100012.PostedFile != null) && (FUPID100012.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID100012.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID100012.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID100012.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "100012", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID100012.Visible = true;
                        LBLID100012.Text = FUPID100012.FileName;
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

    protected void BTNID100013_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID100013.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID100013.PostedFile != null) && (FUPID100013.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID100013.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID100013.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID100013.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "100013", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID100013.Visible = true;
                        LBLID100013.Text = FUPID100013.FileName;
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

    protected void BTNID100014_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID100014.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID100014.PostedFile != null) && (FUPID100014.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID100014.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID100014.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID100014.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "100014", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID100014.Visible = true;
                        LBLID100014.Text = FUPID100014.FileName;
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

    protected void BTNID100015_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID100015.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID100015.PostedFile != null) && (FUPID100015.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID100015.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID100015.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID100015.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "100015", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID100015.Visible = true;
                        LBLID100015.Text = FUPID100015.FileName;
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

    protected void BTNID100016_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID100016.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID100016.PostedFile != null) && (FUPID100016.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID100016.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID100016.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID100016.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "100016", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID100016.Visible = true;
                        LBLID100016.Text = FUPID100016.FileName;
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

    protected void BTNID100017_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID100017.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID100017.PostedFile != null) && (FUPID100017.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID100017.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID100017.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID100017.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "100017", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID100017.Visible = true;
                        LBLID100017.Text = FUPID100017.FileName;
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

    protected void BTNID100019_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID100019.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID100019.PostedFile != null) && (FUPID100019.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID100019.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID100019.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID100019.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "100019", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID100019.Visible = true;
                        LBLID100019.Text = FUPID100019.FileName;
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

    protected void BTNID100020_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID100020.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID100020.PostedFile != null) && (FUPID100020.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID100020.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID100020.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID100020.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "100020", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID100020.Visible = true;
                        LBLID100020.Text = FUPID100020.FileName;
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

    protected void BTNID100021_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID100021.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID100021.PostedFile != null) && (FUPID100021.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID100021.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID100021.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID100021.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "100021", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID100021.Visible = true;
                        LBLID100021.Text = FUPID100021.FileName;
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

    protected void BTNID100022_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID100022.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID100022.PostedFile != null) && (FUPID100022.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID100022.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID100022.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID100022.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "100022", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID100022.Visible = true;
                        LBLID100022.Text = FUPID100022.FileName;
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

    protected void BTNID100023_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID100023.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID100023.PostedFile != null) && (FUPID100023.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID100023.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID100023.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID100023.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "100023", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID100023.Visible = true;
                        LBLID100023.Text = FUPID100023.FileName;
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

    protected void BTNID181_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID181.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID181.PostedFile != null) && (FUPID181.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID181.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID181.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID181.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "181", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID181.Visible = true;
                        LBLID181.Text = FUPID181.FileName;
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

    protected void BTNID182_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID182.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID182.PostedFile != null) && (FUPID182.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID182.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID182.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID182.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "182", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID182.Visible = true;
                        LBLID182.Text = FUPID182.FileName;
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

    protected void BTNID183_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID183.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID183.PostedFile != null) && (FUPID183.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID183.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID183.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID183.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "183", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID183.Visible = true;
                        LBLID183.Text = FUPID183.FileName;
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

    protected void BTNID184_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID184.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID184.PostedFile != null) && (FUPID184.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID184.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID184.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID184.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "184", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID184.Visible = true;
                        LBLID184.Text = FUPID184.FileName;
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

    protected void BTNID185_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID185.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID185.PostedFile != null) && (FUPID185.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID185.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID185.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID185.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "185", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID185.Visible = true;
                        LBLID185.Text = FUPID185.FileName;
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

    protected void BTNID191_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID191.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID191.PostedFile != null) && (FUPID191.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID191.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID191.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID191.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "191", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID191.Visible = true;
                        LBLID191.Text = FUPID191.FileName;
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

    protected void BTNID192_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID192.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID192.PostedFile != null) && (FUPID192.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID192.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID192.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID192.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "192", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID192.Visible = true;
                        LBLID192.Text = FUPID192.FileName;
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

    protected void BTNID193_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID193.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID193.PostedFile != null) && (FUPID193.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID193.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID193.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID193.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "193", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID193.Visible = true;
                        LBLID193.Text = FUPID193.FileName;
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

    protected void BTNID194_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID194.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID194.PostedFile != null) && (FUPID194.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID194.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID194.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID194.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "194", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID194.Visible = true;
                        LBLID194.Text = FUPID194.FileName;
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

    protected void BTNID195_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID195.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID195.PostedFile != null) && (FUPID195.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID195.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID195.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID195.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "195", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID195.Visible = true;
                        LBLID195.Text = FUPID195.FileName;
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

    protected void BTNID196_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPID196.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPID196.PostedFile != null) && (FUPID196.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPID196.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPID196.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPID196.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "196", Attachmentidnew);
                        //string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        //AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        //this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLID196.Visible = true;
                        LBLID196.Text = FUPID196.FileName;
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
    protected void BTNDEET_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FUPDEET.HasFile)
        {
            string incentiveid = hdfFlagID0.Value;

            if ((FUPDEET.PostedFile != null) && (FUPDEET.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FUPDEET.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPDEET.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = (ConfigurationManager.AppSettings["INCfilePath"] + "ResponseAttachmentforIcentive" + "\\" + incentiveid.ToString() + "\\" + hdfFlagID1.Value);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPDEET.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentQueryResponsenew(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, hdfFlagID1.Value, "100050", Attachmentidnew);
                        lblmsg.Text = "";
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                        LBLDEET.Visible = true;
                        LBLDEET.Text = FUPDEET.FileName;
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

}
