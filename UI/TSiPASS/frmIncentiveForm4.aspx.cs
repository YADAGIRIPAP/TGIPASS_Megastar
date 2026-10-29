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

public partial class UI_TSiPASS_frmIncentiveForm4 : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    PCBClass objPCB = new PCBClass();
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DB.DB con = new DB.DB();
    DataTable myDtNewPowerdr = new DataTable();
    DataTable myDtNewEnergydr = new DataTable();

    static DataTable dtEnergy1;
    static DataTable dtEnergy2;

    //string incentiveId = "7000";   // Have to get from session

    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["uid"] != null)
            {
                if (Session["incentivedata"] != null)
                {
                    //Session["EntprIncentive"] = incentiveId;   // Have to get from session
                    //int IncentiveId = Convert.ToInt32(Session["EntprIncentive"].ToString());   // Incentive Id from session

                    string userid = Session["uid"].ToString();
                    string IncentveID = Session["EntprIncentive"].ToString();
                    DataSet dscaste = new DataSet();
                    dscaste = Gen.GetIncentivesCaste(userid, IncentveID);

                    ds = (DataSet)Session["incentivedata"];
                    string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
                    DataRow[] drs = ds.Tables[0].Select("IncentiveID = " + 1);  //Pavalla vaddi
                    if (drs.Length > 0)
                    {

                    }
                    else
                    {
                        if (Request.QueryString[0].ToString() == "N")
                        {
                            Response.Redirect("frmIncentiveForm5.aspx?next=" + "N");
                        }
                        else
                        {
                            Response.Redirect("frmIncentiveForm3.aspx?Previous=" + "P");
                        }
                    }
                    if (dscaste.Tables[0].Rows[0]["Scheme"].ToString() == "TIDEA")
                    {
                        lblscheme.Text = "TIDEA, 2014";
                    }
                    else if (dscaste.Tables[0].Rows[0]["Scheme"].ToString() == "TFAP")
                    {
                        lblscheme.Text = "TFAP, 2022";
                    }
                    else if (dscaste.Tables[0].Rows[0]["Scheme"].ToString() == "IIPP SCHEME 2005-10")
                    {
                        lblscheme.Text = "IIPP Scheme 2005 - 2010";
                    }
                    else if (dscaste.Tables[0].Rows[0]["Scheme"].ToString() == "IIPP SCHEME 2010-15")
                    {
                        lblscheme.Text = "IIPP Scheme 2010 - 2015";
                    }
                    string caste = dscaste.Tables[0].Rows[0]["caste"].ToString();
                    string TSCPflag = dscaste.Tables[0].Rows[0]["TSCPflag"].ToString();
                    string TSPflag = dscaste.Tables[0].Rows[0]["TSPflag"].ToString();
                    string TIDEAflag = dscaste.Tables[0].Rows[0]["TIDEAflag"].ToString();


                    if (lblscheme.Text == "TIDEA, 2014")
                    {
                        //  if (caste == "3" || caste == "4")   //SC, ST
                        if (TSCPflag == "Y" || TSPflag == "Y")
                        {
                            lblheadTPRIDE.Visible = true;
                            lblheadTIDEA.Visible = false;
                            lblheadTPRIDE.Text = "<center>" + "ANNEXURE: IX" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF PAVALA VADDI UNDER T-PRIDE </center></u></b></span>" + "<center>(TELANGANA STATE PROGRAM FOR RAPID INCUBATION OF DALIT ENTREPRENEURS INCENTIVE SCHEME)</center>" + "<center>(G.O.Ms.No.29 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                            lblheadTPRIDE.ForeColor = System.Drawing.Color.White;
                            lblheadTIDEA.Visible = false;

                        }
                        else if (TIDEAflag == "Y")
                        {
                            lblheadTIDEA.Visible = true;

                            lblheadTIDEA.Text = "<center>" + "ANNEXURE: IX" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF PAVALA VADDI UNDER T - IDEA </center></u></b></span>" + "<center>(TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR ADVANCEMENT) INCENTIVE SCHEME 2014 </center>" + "<center>(G.O.Ms.No.28 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                            lblheadTIDEA.ForeColor = System.Drawing.Color.White;
                            lblheadTPRIDE.Visible = false;
                        }
                    }
                    
                    else
                    {
                        lblheadTIDEA.Visible = true;

                        lblheadTIDEA.Text = "<center>" + "ANNEXURE: IX" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF PAVALA VADDI  UNDER " + lblscheme.Text + "</center></u></b></span>" + "<center>(TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR ADVANCEMENT) INCENTIVE SCHEME 2014 </center>" + "<center>(G.O.Ms.No.28 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";
                         
                        lblheadTIDEA.ForeColor = System.Drawing.Color.White;
                        lblheadTPRIDE.Visible = false;
                    }


                    BindFinancialYears(ddlFinYearEnergy, "10", IncentveID);
                    DataSet dsdisable = new DataSet();
                    dsdisable = Gen.GETINCENTIVESCAFDATA(userid, IncentveID);
                    if (dsdisable.Tables.Count > 0 && dsdisable.Tables[6].Rows.Count > 0)
                    {
                        string applicationStatus = "";
                        applicationStatus = dsdisable.Tables[6].Rows[0]["intStatusid"].ToString();
                        if (applicationStatus != "")
                        {
                            if (Convert.ToInt32(applicationStatus) >= 2)  //3  changed on 17.11.2017 
                            {
                                ResetFormControl(this);
                            }
                        }
                        hdnMSMEApplied.Value = dsdisable.Tables[6].Rows[0]["MSME_Applied"].ToString();//Applied under MSME policy
                        if (hdnMSMEApplied.Value == "Y")
                        {
                            lblMSMEPolicy.Visible = true;
                            lblheadTIDEA.Visible = false;
                            lblheadTPRIDE.Visible = false;
                            trMSME1.Visible = true;
                        }
                    }

                }


                dtEnergy1 = EnergyDt();
                Session["Energy"] = dtEnergy1;

                //gvInterestDCP.DataSource = BindInterestFromDCPGrid();
                //gvInterestDCP.DataBind();

            }
            if (!IsPostBack)
            {
                FillDetails();
            }
        }
    }

    private void FillDetails()
    {
        DataSet ds = new DataSet();
        int IncentiveId = Convert.ToInt32(Session["EntprIncentive"].ToString());

        ds = Gen.GetFormIVIncentives(IncentiveId);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            BtnSave1.Enabled = false;
            BtnDelete.Enabled = true;

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ViewState["dtDCP"] = ds.Tables[0];
                gvenergyview.DataSource = ds.Tables[0];
                gvenergyview.DataBind();

                trenergy1.Visible = false;
                trenergy2.Visible = false;
                trenergyview.Visible = true;
                gvenergyview.Visible = true;
            }
            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                DataTable table = ds.Tables[1];
                string sen, sen1, sen2, sennew;

                foreach (DataRow dr in table.Rows)
                {
                    string AttcahmentId = dr["AttachmentId"].ToString();

                    sen2 = dr["FilePath"].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    sennew = dr["LINKNEW"].ToString(); // LINKNEW
                    string encpassword = Gen.Encrypt(sennew, "SYSTIME");

                    //if (AttcahmentId == "58")
                    if (AttcahmentId == "36")
                    {
                        //HyperLink1.NavigateUrl = sen;
                        HyperLink1.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink1.Text = dr["FileNm"].ToString();
                        Label2.Text = dr["FileNm"].ToString();
                    }
                    //if (AttcahmentId == "59")
                    if (AttcahmentId == "48")
                    {
                       // HyperLink2.NavigateUrl = sen;
                        HyperLink2.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink2.Text = dr["FileNm"].ToString();
                        Label3.Text = dr["FileNm"].ToString();
                    }
                    //if (AttcahmentId == "64")
                    //{
                    //    HyperLink2.NavigateUrl = sen;
                    //    HyperLink2.Text = dr["link"].ToString();
                    //    Label2.Text = dr["FileNm"].ToString();
                    //}

                    if (AttcahmentId == "3001")
                    {
                       // HyperLink3.NavigateUrl = sen;
                        HyperLink3.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink3.Text = dr["FileNm"].ToString();
                        Label5.Text = dr["FileNm"].ToString();
                    }
                    if (AttcahmentId == "907")
                    {
                        hplLoanstmt.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        hplLoanstmt.Text = dr["FileNm"].ToString();
                        lblLoanstmt.Text = dr["FileNm"].ToString();
                    }
                }
            }
        }
    }
    private DataTable BindInterestFromDCPGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("FinancialYear");
        dt.Columns.Add("IntrestPaid");
        dt.Columns.Add("RateofIntrest");
        dt.Columns.Add("IntrestPenaltyPaid");
        dt.Columns.Add("Eligible");
        dt.Columns.Add("AmountClaimed");

        for (int i = 0; i < 10; i++)
        {
            DataRow dr = dt.NewRow();
            dr[0] = "";
            dr[1] = "";
            dr[2] = "";
            dr[3] = "";
            dr[4] = "";
            dt.Rows.Add(dr);
        }

        return dt;
    }
    protected void gvInterestDCP_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gvr = e.Row;

                DataTable dt = (DataTable)ViewState["dtDCP"];
                DropDownList ddlFinYear = (DropDownList)gvr.FindControl("ddlFinYear");
                BindFinancialYears(ddlFinYear, 10, Session["EntprIncentive"].ToString());

                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        TextBox txtInterest = (TextBox)gvr.FindControl("txtInterest");
                        TextBox txtRateofInterest = (TextBox)gvr.FindControl("txtRateofInterest");
                        TextBox txtExPenaltyInterestPaid = (TextBox)gvr.FindControl("txtExPenaltyInterestPaid");
                        TextBox txtEligible = (TextBox)gvr.FindControl("txtEligible");
                        TextBox txtAmountClaimed = (TextBox)gvr.FindControl("txtAmountClaimed");

                        txtInterest.Text = dt.Rows[e.Row.RowIndex]["IntrestPaid"].ToString();
                        txtRateofInterest.Text = dt.Rows[e.Row.RowIndex]["RateofIntrest"].ToString();
                        txtExPenaltyInterestPaid.Text = dt.Rows[e.Row.RowIndex]["IntrestPenaltyPaid"].ToString();
                        txtEligible.Text = dt.Rows[e.Row.RowIndex]["Eligible"].ToString();
                        txtAmountClaimed.Text = dt.Rows[e.Row.RowIndex]["AmountClaimed"].ToString();
                        ddlFinYear.SelectedValue = dt.Rows[e.Row.RowIndex]["FinancialYear"].ToString();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }
    protected void BtnDelete0_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmIncentiveForm3.aspx?Previous=" + "P");
    }
    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        int start = 0;
        if (HyperLink1.Text == "" || HyperLink1.Text == null)
        {
            lblmsg0.Text = "Please Uppload the documents";
            Failure.Visible = true;
            FileUpload2.Focus();
            start = 1;
        }
        if (HyperLink2.Text == "" || HyperLink2.Text == null)
        {
            lblmsg0.Text = "Please Uppload the documents";
            Failure.Visible = true;
            FileUpload3.Focus();
            start = 1;
        }
        if (HyperLink3.Text == "" || HyperLink3.Text == null)
        {
            lblmsg0.Text = "Please Uppload the documents";
            Failure.Visible = true;
            FileUpload4.Focus();
            start = 1;
        }
        if (start == 0)
        {
            DataSet ds = new DataSet();
            ds = (DataSet)Session["incentivedata"];
            string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
            UpdateAnnexureflag(IncentiveId, "1", "Y", "");

            Response.Redirect("frmIncentiveForm5.aspx?next=" + "N");
        }

    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        //List<FormIV> lstForm4 = new List<FormIV>();


        //foreach (GridViewRow gvr in gvInterestDCP.Rows)
        //{
        //    FormIV form4Vo = new FormIV();

        //    DropDownList ddlFinYear = (DropDownList)gvr.FindControl("ddlFinYear");
        //    TextBox txtInterest = (TextBox)gvr.FindControl("txtInterest");
        //    TextBox txtRateofInterest = (TextBox)gvr.FindControl("txtRateofInterest");
        //    TextBox txtExPenaltyInterestPaid = (TextBox)gvr.FindControl("txtExPenaltyInterestPaid");
        //    TextBox txtEligible = (TextBox)gvr.FindControl("txtEligible");
        //    TextBox txtAmountClaimed = (TextBox)gvr.FindControl("txtAmountClaimed");

        //    form4Vo.FinancialYear = ddlFinYear.SelectedValue;
        //    form4Vo.IntrestPaid = txtInterest.Text;
        //    form4Vo.RateofIntrest = txtRateofInterest.Text;

        //    form4Vo.IntrestPenaltyPaid = txtExPenaltyInterestPaid.Text;
        //    form4Vo.Eligible = txtEligible.Text;
        //    form4Vo.AmountClaimed = txtAmountClaimed.Text;
        //    lstForm4.Add(form4Vo);
        //}
        //string Created_By = Session["uid"].ToString();

        //int valid = 1;
        //valid = Gen.InsertFormIVIncentives(Created_By, IncentiveId, lstForm4);
        //if (valid == 0)
        //{
        //    lblmsg.Text = "Added Successfully..!";
        //    success.Visible = true;
        //    Failure.Visible = false;
        //}

        int start = 0;
        int valid = 0;

        try
        {
            if (hdnMSMEApplied.Value == "Y" && (hplLoanstmt.Text == "" || hplLoanstmt.Text == null))
            {
                lblmsg0.Text = "Please Upload Term loan account statement duly covering the loan repayment details of claim period";
                Failure.Visible = true;
                fupLoanstmt.Focus();
                start = 1; return;
            }
            if (gvEnergy.Visible == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please enter Intrest Details and click on Add button');", true);
                return;
            }
            //if (lblFileName.Text == "" || lblFileName.Text == null)
            //{
            //    lblmsg0.Text = "Please Uppload the documents";
            //    Failure.Visible = true;
            //    FileUpload1.Focus();
            //    start = 1;
            //}
            if (HyperLink1.Text == "" || HyperLink1.Text == null)
            {
                lblmsg0.Text = "Please Uppload the documents";
                Failure.Visible = true;
                FileUpload2.Focus();
                start = 1;
            }
            if (HyperLink2.Text == "" || HyperLink2.Text == null)
            {
                lblmsg0.Text = "Please Uppload the documents";
                Failure.Visible = true;
                FileUpload3.Focus();
                start = 1;
            }
            if (HyperLink3.Text == "" || HyperLink3.Text == null)
            {
                lblmsg0.Text = "Please Uppload the documents";
                Failure.Visible = true;
                FileUpload4.Focus();
                start = 1;
            }
            
            if (start == 0)
            {
                valid = SaveEnergy();
                DataSet ds = new DataSet();
                ds = (DataSet)Session["incentivedata"];
                string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
                UpdateAnnexureflag(IncentiveId, "1", "Y", "");
                if (valid == 1)
                {
                    //lblmsg.Text = "Submitted Successfully";
                    //success.Visible = true;

                    string message = "alert('Pavala Vaddi Reimbursement Submitted Successfully')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    BtnSave1.Enabled = false;
                    BtnDelete.Enabled = true;
                    Failure.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
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
    private void BindFinancialYears(DropDownList ddlFinYear, int Count, string incentiveid)
    {
        DataSet dsYears = new DataSet();
        dsYears = Gen.GetFinancialYearIncentives("10", incentiveid);
        if (dsYears != null && dsYears.Tables.Count > 0 && dsYears.Tables[0].Rows.Count > 0)
        {
            ddlFinYear.DataSource = dsYears.Tables[0];
            ddlFinYear.DataTextField = "FinancialYear";
            ddlFinYear.DataValueField = "SlNo";
            ddlFinYear.DataBind();
        }
        ddlFinYear.Items.Insert(0, "--Select--");

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FileUpload2.HasFile)
        {
            string incentiveid = Session["EntprIncentive"].ToString();

            if ((FileUpload2.PostedFile != null) && (FileUpload2.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload2.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload2.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\58");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\36");
                       // string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\1\\36");
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\1\\36";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload2.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        //t1.InsertIncentiveAttachment(incentiveid, "58", sFileName, serverpath, CrtdUser);
                        t1.InsertIncentiveAttachment(incentiveid, "NA", "36", sFileName, serverpath, CrtdUser);

                        HyperLink1.Text = sFileName;
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
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FileUpload3.HasFile)
        {
            string incentiveid = Session["EntprIncentive"].ToString();

            if ((FileUpload3.PostedFile != null) && (FileUpload3.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload3.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload3.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\59");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\1\\48");
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\1\\48";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload3.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();


                        string Path = serverpath;
                        string FileName = sFileName;


                        //t1.InsertIncentiveAttachment(incentiveid, "59", sFileName, serverpath, CrtdUser);
                        t1.InsertIncentiveAttachment(incentiveid, "NA", "48", sFileName, serverpath, CrtdUser);

                        HyperLink2.Text = sFileName;

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
    }
    protected void BtnSave3_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FileUpload1.HasFile)
        {
            string incentiveid = Session["EntprIncentive"].ToString();

            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {

                string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\1\\64");
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\1\\64";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload1.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;

                        t1.InsertIncentiveAttachment(incentiveid, "NA", "64", sFileName, serverpath, CrtdUser);

                        lblFileName.Text = sFileName;

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
    }

    private void BindFinancialYears(DropDownList ddl, string Count, string incentiveid)
    {
        DataSet dsYears = new DataSet();
        dsYears = Gen.GetFinancialYearIncentives(Count, incentiveid);
        if (dsYears != null && dsYears.Tables.Count > 0 && dsYears.Tables[0].Rows.Count > 0)
        {
            ddl.DataSource = dsYears.Tables[0];
            ddl.DataTextField = "FinancialYear";
            ddl.DataValueField = "SlNo";
            ddl.DataBind();
        }
        ddl.Items.Insert(0, "--Select--");

    }
    private void AddDataToTableEnergy(string FinancialYearId, string FinancialYear, string InterestpaidonTermLoan, string Rateofinterest, string Interestpaidexcludingpenalinterest, string EligibleMax, string Amountclaimed, string IncentiveId, string Fin1stOr2ndHalfYear, DataTable myTable)
    {
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtEnergy2 = new DataTable("Energy2");

            Row["new"] = "0";
            Row["FinancialYearId"] = FinancialYearId;
            Row["FinancialYear"] = FinancialYear;
            Row["InterestpaidonTermLoan"] = InterestpaidonTermLoan;
            Row["Rateofinterest"] = Rateofinterest;
            Row["Interestpaidexcludingpenalinterest"] = Interestpaidexcludingpenalinterest;
            Row["EligibleMax"] = EligibleMax;
            Row["Amountclaimed"] = Amountclaimed;
            Row["Created_by"] = Session["uid"].ToString().Trim();
            Row["IncentiveId"] = IncentiveId;
            Row["Fin1stOr2ndHalfYear"] = Fin1stOr2ndHalfYear;

            Row["intLineofActivityMid"] = "0";

            myTable.Rows.Add(Row);
        }
        catch (Exception ee)
        {
            throw ee;
        }
    }
    protected DataTable EnergyDt()
    {
        dtEnergy1 = new DataTable("Energy");

        dtEnergy1.Columns.Add("new", typeof(string));
        dtEnergy1.Columns.Add("FinancialYearId", typeof(string));
        dtEnergy1.Columns.Add("FinancialYear", typeof(string));
        dtEnergy1.Columns.Add("InterestpaidonTermLoan", typeof(string));
        dtEnergy1.Columns.Add("Rateofinterest", typeof(string));
        dtEnergy1.Columns.Add("Interestpaidexcludingpenalinterest", typeof(string));
        dtEnergy1.Columns.Add("EligibleMax", typeof(string));
        dtEnergy1.Columns.Add("Amountclaimed", typeof(string));
        dtEnergy1.Columns.Add("Created_by", typeof(string));
        dtEnergy1.Columns.Add("IncentiveId", typeof(string));
        dtEnergy1.Columns.Add("Fin1stOr2ndHalfYear", typeof(string));

        dtEnergy1.Columns.Add("intLineofActivityMid", typeof(string));

        return dtEnergy1;
    }
    protected void btnEnergyAdd_Click(object sender, EventArgs e)
    {
        int valid = 0;
        try
        {
            if (ddlFinYearEnergy.SelectedItem.Text == "--Select--")
            {
                lblmsg0.Text = "Please Select Financial Year" + "<br/>";
                Failure.Visible = true;
                btnEnergyAdd.Focus();
                ddlFinYearEnergy.Focus();
                valid = 1;
            }
            if (ddlFin1stOr2ndHalfyear.SelectedItem.Text == "--Select--")
            {
                lblmsg0.Text = "Please Select 1st or 2nd Half of Financial Year" + "<br/>";
                Failure.Visible = true;
                btnEnergyAdd.Focus();
                ddlFin1stOr2ndHalfyear.Focus();
                valid = 1;
            }
            if (txtInterestpaidonTermLoan.Text == "" || txtInterestpaidonTermLoan.Text == null)
            {
                lblmsg0.Text = "Interest paid on Term Loan on half yearly basis Cannot be blank" + "<br/>";
                Failure.Visible = true;
                btnEnergyAdd.Focus();
                txtInterestpaidonTermLoan.Focus();
                valid = 1;
            }
            if (txtRateofinterest.Text == "" || txtRateofinterest.Text == null)
            {
                lblmsg0.Text = "Rate of interest % Cannot be blank" + "<br/>";
                Failure.Visible = true;
                btnEnergyAdd.Focus();
                txtRateofinterest.Focus();
                valid = 1;
            }
            if (txtInterestpaidexcludingpenal.Text == "" || txtInterestpaidexcludingpenal.Text == null)
            {
                lblmsg0.Text = "Interest paid (in Rs.) excluding penal interest Cannot be blank" + "<br/>";
                Failure.Visible = true;
                btnEnergyAdd.Focus();
                txtInterestpaidexcludingpenal.Focus();
                valid = 1;
            }
            if (txtEligiblemax.Text == "" || txtEligiblemax.Text == null)
            {
                lblmsg0.Text = "Eligible % (Max 9%) Cannot be blank" + "<br/>";
                Failure.Visible = true;
                btnEnergyAdd.Focus();
                txtEligiblemax.Focus();
                valid = 1;
            }
            if (txtAmountClaimed.Text == "" || txtAmountClaimed.Text == null)
            {
                lblmsg0.Text = "Amount claimed (in Rs.) Cannot be blank" + "<br/>";
                Failure.Visible = true;
                btnEnergyAdd.Focus();
                txtAmountClaimed.Focus();
                valid = 1;
            }
            //sowjanya
            DataSet dss = new DataSet();           
            if (Convert.ToString(Session["uid"]) != "48696")
            {
                dss = getappliedlistPavalaVaddi();
                if (dss.Tables[0].Rows.Count > 0)
                {
                    lblmsg0.Text = "You have already applied for financial year" + ddlFinYearEnergy.SelectedItem.Text + "for the" + ddlFin1stOr2ndHalfyear.SelectedItem.Text + " Half";
                    Failure.Visible = true;
                    valid = 1;
                    return;
                }
            }
            //sowjanya

            if (valid == 0)
            {
                AddDataToTableEnergy(ddlFinYearEnergy.SelectedValue, ddlFinYearEnergy.SelectedItem.Text, txtInterestpaidonTermLoan.Text, txtRateofinterest.Text, txtInterestpaidexcludingpenal.Text, txtEligiblemax.Text, txtAmountClaimed.Text, "", ddlFin1stOr2ndHalfyear.SelectedValue, (DataTable)Session["Energy"]);

                this.gvEnergy.DataSource = ((DataTable)Session["Energy"]).DefaultView;
                this.gvEnergy.DataBind();

                ddlFinYearEnergy.SelectedValue = "--Select--";
                ddlFin1stOr2ndHalfyear.SelectedValue = "--Select--";
                txtInterestpaidonTermLoan.Text = "";
                txtRateofinterest.Text = "";
                txtInterestpaidexcludingpenal.Text = "";
                txtEligiblemax.Text = "";
                txtAmountClaimed.Text = "";

                gvEnergy.Visible = true;
                lblmsg0.Text = "";
                Failure.Visible = false;
            }
        }
        catch (Exception ee)
        {
            throw ee;
        }
    }

    public DataSet getappliedlistPavalaVaddi()
    {
        DataSet ds = new DataSet();

        con.OpenConnection();
        SqlDataAdapter da = new SqlDataAdapter("USP_GET_FINANCIALYEARS_PVApplied", con.GetConnection);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.Add("@created_by", SqlDbType.VarChar).Value = Convert.ToString(Session["uid"]);
        da.SelectCommand.Parameters.Add("@finyear", SqlDbType.VarChar).Value = ddlFinYearEnergy.SelectedValue;
        da.SelectCommand.Parameters.Add("@fstorsecndhalf", SqlDbType.VarChar).Value = ddlFin1stOr2ndHalfyear.SelectedValue;

        da.Fill(ds);
        con.CloseConnection();

        return ds;
    }
    protected void gvEnergy_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvEnergy_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = new DataTable();
        try
        {
            if (Session["Energy"] != null)
            {
                dt = (DataTable)Session["Energy"];
                if (dt.Rows.Count > 0)
                {
                    ((DataTable)Session["Energy"]).Rows.RemoveAt(e.RowIndex);

                    this.gvEnergy.DataSource = ((DataTable)Session["Energy"]).DefaultView;
                    this.gvEnergy.DataBind();
                }
                else
                {
                    this.gvEnergy.DataSource = null;
                    this.gvEnergy.DataBind();
                }
            }
            else
            {
                this.gvEnergy.DataSource = null;
                this.gvEnergy.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private int SaveEnergy()
    {
        int value = 0;
        try
        {
            ds = (DataSet)Session["incentivedata"];
            string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
            if (((DataTable)Session["Energy"]).Rows.Count > 0)
            {
                GetNewEnergytoInsertdr();
                value = Gen.bulkInsertPV(myDtNewEnergydr, IncentiveId);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return value;
    }

    protected void GetNewEnergytoInsertdr()
    {
        myDtNewEnergydr = (DataTable)Session["Energy"];
        DataView dvdr = new DataView(myDtNewEnergydr);
        myDtNewEnergydr = dvdr.ToTable();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FileUpload4.HasFile)
        {
            string incentiveid = Session["EntprIncentive"].ToString();

            if ((FileUpload4.PostedFile != null) && (FileUpload4.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload4.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload4.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\9052");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\1\\3001");
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\1\\3001";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload4.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();


                        string Path = serverpath;
                        string FileName = sFileName;


                        //t1.InsertIncentiveAttachment(incentiveid, "9052", sFileName, serverpath, CrtdUser);
                        t1.InsertIncentiveAttachment(incentiveid, "NA", "3001", sFileName, serverpath, CrtdUser);

                        HyperLink3.Text = sFileName;
                        HyperLink3.Visible = true;

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
    }
    protected void ddlFin1stOr2ndHalfyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlFin1stOr2ndHalfyear.SelectedValue == "1")
        //{
        //    trFin1stHalfYear.Visible = true;
        //    trFin2ndHalfYear.Visible = false;
        //}
        //else if (ddlFin1stOr2ndHalfyear.SelectedValue == "2")
        //{
        //    trFin1stHalfYear.Visible = false;
        //    trFin2ndHalfYear.Visible = true;
        //}
        //else 
        //{
        //    trFin1stHalfYear.Visible = true;
        //    trFin2ndHalfYear.Visible = true;
        //}

    }

    public int UpdateAnnexureflag(string EnterperIncentiveID, string MstIncentiveId, string flag, string output)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "USP_UPD_ANNEXUREFLA_INCENTIVE";

        if (EnterperIncentiveID == "" || EnterperIncentiveID == null)
            com.Parameters.Add("@EnterperIncentiveID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@EnterperIncentiveID", SqlDbType.VarChar).Value = EnterperIncentiveID.Trim();

        if (MstIncentiveId == "" || MstIncentiveId == null)
            com.Parameters.Add("@MstIncentiveId", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@MstIncentiveId", SqlDbType.VarChar).Value = MstIncentiveId.Trim();

        if (flag == "" || flag == null)
            com.Parameters.Add("@FILEDFLAG", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@FILEDFLAG", SqlDbType.VarChar).Value = flag.Trim();

        if (output == "" || output == null)
            com.Parameters.Add("@OUTPUT", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@OUTPUT", SqlDbType.VarChar).Value = output.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }

    public void ResetFormControl(Control parent)
    {
        try
        {
            foreach (Control c in parent.Controls)
            {
                if (c.Controls.Count > 0)
                {
                    ResetFormControl(c);
                }
                else
                {
                    switch (c.GetType().ToString())
                    {
                        case "System.Web.UI.WebControls.TextBox":
                            ((TextBox)c).ReadOnly = true;
                            break;

                        case "System.Web.UI.WebControls.DropDownList":

                            if (((DropDownList)c).Items.Count > 0)
                            {
                                ((DropDownList)c).Enabled = false;
                            }
                            break;
                        case "System.Web.UI.WebControls.FileUpload":
                            ((FileUpload)c).Enabled = false;
                            break;
                        case "System.Web.UI.WebControls.RadioButtonList":
                            ((RadioButtonList)c).Enabled = false;
                            break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void btnLoanstmt_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (fupLoanstmt.HasFile)
        {
            string incentiveid = Session["EntprIncentive"].ToString();

            if ((fupLoanstmt.PostedFile != null) && (fupLoanstmt.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(fupLoanstmt.PostedFile.FileName);
                try
                {
                    string[] fileType = fupLoanstmt.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\9052");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\1\\3001");
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\1\\907";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        fupLoanstmt.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();


                        string Path = serverpath;
                        string FileName = sFileName;


                        //t1.InsertIncentiveAttachment(incentiveid, "9052", sFileName, serverpath, CrtdUser);
                        t1.InsertIncentiveAttachment(incentiveid, "NA", "907", sFileName, serverpath, CrtdUser);

                        hplLoanstmt.Text = sFileName;
                        hplLoanstmt.Visible = true;

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
    }
}