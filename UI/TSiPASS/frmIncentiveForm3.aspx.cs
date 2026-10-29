using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;


public partial class UI_TSiPASS_frmIncentiveForm3 : System.Web.UI.Page
{
    static DataTable dt = new DataTable();
    DB.DB con = new DB.DB();

    static DataTable myDtNewPowerdr = new DataTable();
    static DataTable myDtNewEnergydr = new DataTable();

    static DataTable dtPower1;
    static DataTable dtPower2;

    static DataTable dtEnergy1;
    static DataTable dtEnergy2;
    string createdby;
    string IndustryStatus;
    // string incentiveId = "6000";   // Have to get from session
    // DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        PCBClass objPCB = new PCBClass();
        comFunctions cmf = new comFunctions();
        General Gen = new General();

        if (!IsPostBack)
        {
            if (Session["uid"] != null)
            {
                //if (Session["incentivedata"] != null)
                //{
                string userid = Session["uid"].ToString();
                createdby = Session["uid"].ToString();
                if (createdby == "201109")
                {
                    TRELECTRICITYDUTY.Visible = true;
                }
                else
                {
                    TRELECTRICITYDUTY.Visible = false;
                }
                // Session["EntprIncentive"] = "1000";  // for testing only

                string IncentveID = Session["EntprIncentive"].ToString();
                DataSet dscaste = new DataSet();
                dscaste = Gen.GetIncentivesCaste(userid, IncentveID);
                 IndustryStatus = dscaste.Tables[0].Rows[0]["IdsustryStatus"].ToString();
                if (IndustryStatus == "2" || IndustryStatus == "3")
                {
                    tblExpansionDivers.Visible = true;
                    trExpanDiversPower.Visible = true;
                    TRExistingHP.Visible = true;
                    TRNewHP.Visible = true;
                    TRNewPowerDate.Visible = true;
                }
                else
                {
                    tblExpansionDivers.Visible = false;
                    trExpanDiversPower.Visible = false;
                    TRExistingHP.Visible = false;
                    TRNewHP.Visible = false;
                    TRNewPowerDate.Visible = false;
                }
              
                DataSet ds = new DataSet();
                ds = (DataSet)Session["incentivedata"];
                string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
                DataRow[] drs = ds.Tables[0].Select("IncentiveID = " + 3);  //Power Cost Reimbursement
                if (drs.Length > 0)
                {

                }
                else
                {
                    if (Request.QueryString[0].ToString() == "N")
                    {
                        Response.Redirect("frmIncentiveForm4.aspx?next=" + "N");
                    }
                    else
                    {
                        //Response.Redirect("StampDutyAnnex.aspx?Previous=" + "P");
                        Response.Redirect("StampDutyTransferdutyAnnex4.aspx?Previous=" + "P");
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
                    if (TSCPflag == "Y" || TSPflag=="Y")
                    {
                        lblheadTPRIDE.Visible = true;
                        lblheadTIDEA.Visible = false;
                        lblheadTPRIDE.Text = "<center>" + "ANNEXURE: VII" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF POWER TARIFF UNDER T-PRIDE </center></u></b></span>" + "<center>(TELANGANA STATE PROGRAM FOR RAPID INCUBATION OF DALIT ENTREPRENEURS INCENTIVE SCHEME)</center>" + "<center>(G.O.Ms.No.29 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                        lblheadTPRIDE.ForeColor = System.Drawing.Color.White;
                        lblheadTIDEA.Visible = false;

                    }
                    else if (TIDEAflag == "Y" )
                    {
                        lblheadTIDEA.Visible = true;

                        lblheadTIDEA.Text = "<center>" + "ANNEXURE: VII" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF POWER TARIFF UNDER T - IDEA </center></u></b></span>" + "<center>(TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR ADVANCEMENT) INCENTIVE SCHEME 2014 </center>" + "<center>(G.O.Ms.No.28 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                        lblheadTIDEA.ForeColor = System.Drawing.Color.White;
                        lblheadTPRIDE.Visible = false;
                    }
                }
                
                else  
                {
                    lblheadTIDEA.Visible = true;

                    lblheadTIDEA.Text = "<center>" + "ANNEXURE: VII" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF POWER TARIFF UNDER " + lblscheme.Text + "</center></u></b></span>" + "<center>(TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR ADVANCEMENT) INCENTIVE SCHEME </center>" + "<center>(G.O.Ms.No.28 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                    lblheadTIDEA.ForeColor = System.Drawing.Color.White;
                    lblheadTPRIDE.Visible = false;
                }
                // }

                BindFinancialYears(ddlFinYearPower, "3", Session["EntprIncentive"].ToString());
                BindFinancialYears(ddlFinYearEnergy, "10", Session["EntprIncentive"].ToString());

                dtPower1 = PowerDt();
                Session["Power"] = dtPower1;

                dtEnergy1 = EnergyDt();
                Session["Energy"] = dtEnergy1;

                //gvPowerIncentives.DataSource = BindPowerIncentivesGrid();
                //gvPowerIncentives.DataBind();

                //gvEnergy.DataSource = BindEnergyIncentivesGrid();
                //gvEnergy.DataBind();
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
                        trMSME1hps.Visible = true;
                        trMSME2DiscomCert.Visible = true;
                        lblSelcertificate.Visible = false;
                    }

                   
                }
            }

            FillDetails();

            
        }
    }
    private void FillDetails()
    {
        PCBClass objPCB = new PCBClass();
        comFunctions cmf = new comFunctions();
        General Gen = new General();

        DataSet ds = new DataSet();
        //EntprIncentive
        int IncentiveId = Convert.ToInt32(Session["EntprIncentive"].ToString());

        ds = Gen.GetFormIIIIncentives(IncentiveId);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            BtnSave.Enabled = false;
            BtnDelete.Enabled = true;

            txtClaimedAmount.Text = ds.Tables[0].Rows[0]["AmountClaimed"].ToString();
            txtClaimedAmount.Enabled = false;
            txtExistingHP.Text = ds.Tables[0].Rows[0]["ExistingPower_HP"].ToString();
            txtNewHP.Text = ds.Tables[0].Rows[0]["Newpower_HP"].ToString();
            if (Convert.ToString(ds.Tables[0].Rows[0]["Newpowerdate"]) != "")
            {
                txtNewPowerDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Newpowerdate"]).ToString("dd-MM-yyyy");
            }
            if (createdby == "201109")
            {
                TRELECTRICITYDUTY.Visible = true;
                txtelectricitydutyunitsconsumed.Text = ds.Tables[0].Rows[0]["Electricitydutyunits"].ToString();
                txtelectricitydutyunitsconsumed.Enabled = false;
                txtelectricitydutyamount.Text = ds.Tables[0].Rows[0]["Electricitydutyamount"].ToString();
                txtelectricitydutyamount.Enabled = false;
            }
            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                ViewState["dtPowerIncentives"] = ds.Tables[1];
                gvpowerview.DataSource = ds.Tables[1];
                gvpowerview.DataBind();
                trpower1.Visible = false;
                trpower2.Visible = false;
                trpowerview.Visible = true;
                gvpowerview.Visible = true;
            }
            if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
            {
                ViewState["dtEnergy"] = ds.Tables[2];
                gvenergyview.DataSource = ds.Tables[2];
                gvenergyview.DataBind();

                trEnergy1.Visible = false;
                trEnergy2.Visible = false;
                trenergyview.Visible = true;
                gvenergyview.Visible = true;
            }
            if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
            {
                DataTable table = ds.Tables[3];
                string sen, sen1, sen2, sennew;

                foreach (DataRow dr in table.Rows)
                {
                    string AttcahmentId = dr["AttachmentId"].ToString();
                    sen2 = dr["link"].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    sennew = dr["LINKNEW"].ToString(); // LINKNEW
                    string encpassword = Gen.Encrypt(sennew, "SYSTIME");


                    if (AttcahmentId == "49")
                    {
                        //lblFileName.NavigateUrl = sen;
                        lblFileName.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        lblFileName.Text = dr["FileNm"].ToString();
                        Label444.Text = dr["FileNm"].ToString();
                        lblFileName.Visible = true;
                    }
                    if (AttcahmentId == "7")
                    {
                        // HyperLink1.NavigateUrl = sen;
                        HyperLink1.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink1.Text = dr["FileNm"].ToString();
                        Label4.Text = dr["FileNm"].ToString();
                        HyperLink1.Visible = true;
                    }
                    //if (AttcahmentId == "51")
                    if (AttcahmentId == "6")
                    {
                        //HyperLink2.NavigateUrl = sen;
                       // HyperLink2.NavigateUrl = sen;
                        HyperLink2.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink2.Text = dr["FileNm"].ToString();
                        Label5.Text = dr["FileNm"].ToString();
                        HyperLink2.Visible = true;//lavanya
                        //Label5.Visible = true;
                    }
                    if (AttcahmentId == "52")
                    //  if (AttcahmentId == "6b")
                    {
                        //HyperLink3.NavigateUrl = sen;
                        HyperLink3.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink3.Text = dr["FileNm"].ToString();
                        Label6.Text = dr["FileNm"].ToString();
                        HyperLink3.Visible = true;
                    }
                    //if (AttcahmentId == "53")
                    if (AttcahmentId == "5")
                    {
                        //HyperLink4.NavigateUrl = sen;
                        HyperLink4.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink4.Text = dr["FileNm"].ToString();
                        Label7.Text = dr["FileNm"].ToString();
                        HyperLink4.Visible = true;
                    }
                    //if (AttcahmentId == "54")
                    if (AttcahmentId == "1")
                    {
                        //HyperLink5.NavigateUrl = sen;
                        HyperLink5.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink5.Text = dr["FileNm"].ToString();
                        Label7.Text = dr["FileNm"].ToString();
                        HyperLink5.Visible = true;
                    }
                    if (AttcahmentId == "905")
                    {
                        //HyperLink5.NavigateUrl = sen;
                        hplDiscomCert.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        hplDiscomCert.Text = dr["FileNm"].ToString();
                        lblDiscomCert.Text = dr["FileNm"].ToString();
                        hplDiscomCert.Visible = true;
                    }
                }
            }
        }
    }
    private DataTable BindEnergyIncentivesGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("FinancialYear");
        dt.Columns.Add("F_UnitsConsumed");
        dt.Columns.Add("F_Amount");
        dt.Columns.Add("S_UnitsConsumed");
        dt.Columns.Add("S_Amount");
        for (int i = 0; i < 5; i++)
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
    private DataTable BindPowerIncentivesGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("FinancialYear");
        dt.Columns.Add("UnitsConsumed");
        dt.Columns.Add("Amount");
        for (int i = 0; i < 3; i++)
        {
            DataRow dr = dt.NewRow();
            dr[0] = "";
            dr[1] = "";
            dr[2] = "";

            dt.Rows.Add(dr);
        }

        return dt;
    }
    private void BindFinancialYears(DropDownList ddl, string Count, string incentiveid)
    {
        PCBClass objPCB = new PCBClass();
        comFunctions cmf = new comFunctions();
        General Gen = new General();
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
    protected void BtnDelete0_Click(object sender, EventArgs e)
    {
        //Response.Redirect("StampDutyAnnex.aspx?Previous=" + "P");
        Response.Redirect("StampDutyTransferdutyAnnex4.aspx?Previous=" + "P");
    }
    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        int start = 0;
        int valid = 0;
        int out2 = 0;
        General Gen = new General();



            if (string.IsNullOrEmpty(HyperLink4.Text) && lblSelcertificate.Visible == true)
            {
                start = 1;
                Failure.Visible = true;
                lblmsg0.Text = "Please upload Mandatory Document(s).";
                BtnSave.Enabled = true;
            }


        if (HyperLink2.Text == string.Empty || HyperLink3.Text == string.Empty || HyperLink5.Text == string.Empty)
        {
            start = 1;
            Failure.Visible = true;
            lblmsg0.Text = "Please upload Mandatory Document(s).";
            BtnSave.Enabled = true;
        }
        else
        {
            if (trExpanDiversPower.Visible == true)
            {
                if (HyperLink1.Text == string.Empty)
                {
                    start = 1;
                    Failure.Visible = true;
                    lblmsg0.Text = "Please upload Mandatory Document(s).";
                    BtnSave.Enabled = true;
                }
            }

        }
        if (start == 0)
        {
            DataSet ds = new DataSet();
            ds = (DataSet)Session["incentivedata"];
            string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
            int valid1 = Gen.InsertFormIIIIncentivesNew(Session["uid"].ToString(), Convert.ToInt32(IncentiveId), txtClaimedAmount.Text, txtelectricitydutyunitsconsumed.Text, txtelectricitydutyamount.Text);
            if (valid1 == 1)
            {
                valid = SavePower();
                //if (valid == 1)
                //{
                out2 = SaveEnergy();
                //}
                //if (out2 == 1)
                //{
                //lblmsg.Text = "Submitted Successfully";
                //success.Visible = true;

                string message = "alert('Power Reimbursement Submitted Successfully')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                BtnSave.Enabled = false;
                BtnDelete.Enabled = true;
                Response.Redirect("frmIncentiveForm4.aspx?next=" + "N");


                ////}
            }

        }
        if (start == 0)
        {
            DataSet ds = new DataSet();
            ds = (DataSet)Session["incentivedata"];
            string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
            int valid1 = Gen.InsertFormIIIIncentivesNew(Session["uid"].ToString(), Convert.ToInt32(IncentiveId), txtClaimedAmount.Text, txtelectricitydutyunitsconsumed.Text, txtelectricitydutyamount.Text);
            if (valid1 == 1)
            {
                //valid = SavePower();
                ////if (valid == 1)
                ////{
                //out2 = SaveEnergy();
            }
            UpdateAnnexureflag(IncentiveId, "3", "Y", "");

            Response.Redirect("frmIncentiveForm4.aspx?next=" + "N");
        }
        
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmIncentiveForm3.aspx");
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
    protected void BtnSave3_Click(object sender, EventArgs e)
    {
        PCBClass objPCB = new PCBClass();
        comFunctions cmf = new comFunctions();
        General Gen = new General();

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
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\49");  // incentiveid2
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\3\\49";
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\3\\49"); 
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload1.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        t1.InsertIncentiveAttachment(incentiveid,"NA", "49", sFileName, serverpath, CrtdUser);

                        lblFileName.Text = sFileName;
                        lblFileName.Visible = true;
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
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        PCBClass objPCB = new PCBClass();
        comFunctions cmf = new comFunctions();
        General Gen = new General();

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
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\7");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\3\\7");
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\3\\7";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload2.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;

                        //t1.InsertIncentiveAttachment(incentiveid, "50", sFileName, serverpath, CrtdUser);
                        t1.InsertIncentiveAttachment(incentiveid,"NA", "7", sFileName, serverpath, CrtdUser);

                        HyperLink1.Text = sFileName;
                        HyperLink1.Visible = true;
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
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        PCBClass objPCB = new PCBClass();
        comFunctions cmf = new comFunctions();
        General Gen = new General();

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
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\51");
                      //  string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\6");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\3\\6");
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\3\\6";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload3.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        //t1.InsertIncentiveAttachment(incentiveid, "51", sFileName, serverpath, CrtdUser);
                        t1.InsertIncentiveAttachment(incentiveid,"NA", "6", sFileName, serverpath, CrtdUser);

                        HyperLink2.Text = sFileName;
                        HyperLink2.Visible = true;
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
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        PCBClass objPCB = new PCBClass();
        comFunctions cmf = new comFunctions();
        General Gen = new General();

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
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\52");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\3\\52");
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\3\\52";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload4.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        t1.InsertIncentiveAttachment(incentiveid,"NA", "52", sFileName, serverpath, CrtdUser);
                        //t1.InsertIncentiveAttachment(incentiveid, "6b", sFileName, serverpath, CrtdUser);

                        HyperLink3.Text = sFileName;
                        HyperLink3.Visible = true;
                        success.Visible = true;
                        Failure.Visible = false;
                    }
                    else
                    {
                        success.Visible = false;
                        Failure.Visible = true;
                    }

                }
                catch (Exception ex)//in case of an error
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
    protected void Button4_Click(object sender, EventArgs e)
    {
        PCBClass objPCB = new PCBClass();
        comFunctions cmf = new comFunctions();
        General Gen = new General();

        string newPath = "";

        General t1 = new General();
        if (FileUpload5.HasFile)
        {
            string incentiveid = Session["EntprIncentive"].ToString();

            if ((FileUpload5.PostedFile != null) && (FileUpload5.PostedFile.ContentLength > 0))
            {

                string sFileName = System.IO.Path.GetFileName(FileUpload5.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUpload5.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\53");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\5");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\3\\5");
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\3\\5";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload5.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        //t1.InsertIncentiveAttachment(incentiveid, "53", sFileName, serverpath, CrtdUser);
                        t1.InsertIncentiveAttachment(incentiveid,"NA", "5", sFileName, serverpath, CrtdUser);

                        HyperLink4.Text = sFileName;
                        HyperLink4.Visible = true;
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
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FileUpload6.HasFile)
        {
            string incentiveid = Session["EntprIncentive"].ToString();

            if ((FileUpload6.PostedFile != null) && (FileUpload6.PostedFile.ContentLength > 0))
            {

                string sFileName = System.IO.Path.GetFileName(FileUpload6.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUpload6.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\54");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\3\\1");
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\3\\1";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload6.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        //t1.InsertIncentiveAttachment(incentiveid, "54", sFileName, serverpath, CrtdUser);
                        t1.InsertIncentiveAttachment(incentiveid,"NA", "1", sFileName, serverpath, CrtdUser);

                        HyperLink5.Text = sFileName;
                        HyperLink5.Visible = true;
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
    }

    private void AddDataToTablePower(string FinancialYearId, string FinancialYear, string UnitsConsumed, string AmountPaid, string IncentiveId, DataTable myTable)
    {
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtPower2 = new DataTable("Power1");

            Row["new"] = "0";
            Row["FinancialYearId"] = FinancialYearId;
            Row["FinancialYear"] = FinancialYear;
            Row["UnitsConsumed"] = UnitsConsumed;
            Row["AmountPaid"] = AmountPaid;
            Row["Created_by"] = Session["uid"].ToString().Trim();
            Row["IncentiveId"] = IncentiveId;

            Row["intLineofActivityMid"] = "0";

            myTable.Rows.Add(Row);
        }
        catch (Exception ee)
        {
            throw ee;
        }
    }
    protected DataTable PowerDt()
    {
        dtPower1 = new DataTable("Power2");

        dtPower1.Columns.Add("new", typeof(string));
        dtPower1.Columns.Add("FinancialYearId", typeof(string));
        dtPower1.Columns.Add("FinancialYear", typeof(string));
        dtPower1.Columns.Add("UnitsConsumed", typeof(string));
        dtPower1.Columns.Add("AmountPaid", typeof(string));
        dtPower1.Columns.Add("Created_by", typeof(string));
        dtPower1.Columns.Add("IncentiveId", typeof(string));

        dtPower1.Columns.Add("intLineofActivityMid", typeof(string));

        return dtPower1;
    }
    private void AddDataToTableEnergy(string FinancialYearId, string FinancialYear, string frstUnitsConsumed, string frstAmountPaid, string secondUnitsConsumed, string secondAmountPaid, string IncentiveId, string Fin1stOr2ndHalfYear, DataTable myTable)
    {
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtEnergy2 = new DataTable("Energy2");

            Row["new"] = "0";
            Row["FinancialYearId"] = FinancialYearId;
            Row["FinancialYear"] = FinancialYear;
            Row["1stUnitsConsumed"] = frstUnitsConsumed;
            Row["1stAmountPaid"] = frstAmountPaid;
            Row["2ndUnitsConsumed"] = secondUnitsConsumed;
            Row["2ndAmountPaid"] = secondAmountPaid;
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

        dtPower1 = new DataTable("Energy");

        dtPower1.Columns.Add("new", typeof(string));
        dtPower1.Columns.Add("FinancialYearId", typeof(string));
        dtPower1.Columns.Add("FinancialYear", typeof(string));
        dtPower1.Columns.Add("1stUnitsConsumed", typeof(string));
        dtPower1.Columns.Add("1stAmountPaid", typeof(string));
        dtPower1.Columns.Add("2ndUnitsConsumed", typeof(string));
        dtPower1.Columns.Add("2ndAmountPaid", typeof(string));
        dtPower1.Columns.Add("Created_by", typeof(string));
        dtPower1.Columns.Add("IncentiveId", typeof(string));
        dtPower1.Columns.Add("Fin1stOr2ndHalfYear", typeof(string));

        dtPower1.Columns.Add("intLineofActivityMid", typeof(string));

        return dtPower1;
    }
    protected void btnPowerAdd_Click(object sender, EventArgs e)
    {
        PCBClass objPCB = new PCBClass();
        comFunctions cmf = new comFunctions();
        General Gen = new General();

        int valid = 0;
        try
        {
            if (ddlFinYearPower.SelectedItem.Text == "--Select--")
            {
                lblmsg0.Text = "Please Select Financial Year" + "<br/>";
                Failure.Visible = true;
                ddlFinYearPower.Focus();
                valid = 1;
            }
            if (txtAmountPaid.Text == "" || txtAmountPaid.Text == null)
            {
                lblmsg0.Text = "Amount Paid (in Rs) Cannot be blank" + "<br/>";
                Failure.Visible = true;
                txtAmountPaid.Focus();
                valid = 1;
            }
            if (txtUnitsConsumed.Text == "" || txtUnitsConsumed.Text == null)
            {
                lblmsg0.Text = "Units Consumed Cannot be blank" + "<br/>";
                Failure.Visible = true;
                txtUnitsConsumed.Focus();
                valid = 1;
            }
            //sowjanya
            //DataSet dss = new DataSet();
            //dss = getappliedlistPower();
            //if (dss.Tables[0].Rows.Count > 0)
            //{
            //    lblmsg0.Text = "You have already applied for financial year " + ddlFinYearPower.SelectedItem.Text + ".";
            //    Failure.Visible = true;
            //    valid = 1;
            //    return;
            //}
            //sowjanya

            if (valid == 0)
            {
                AddDataToTablePower(ddlFinYearPower.SelectedValue, ddlFinYearPower.SelectedItem.Text, txtUnitsConsumed.Text, txtAmountPaid.Text, "", (DataTable)Session["Power"]);

                this.gvpower.DataSource = ((DataTable)Session["Power"]).DefaultView;
                this.gvpower.DataBind();
                ddlFinYearPower.SelectedValue = "--Select--";
                txtUnitsConsumed.Text = "";
                txtAmountPaid.Text = "";

                gvpower.Visible = true;
                lblmsg0.Text = "";
                Failure.Visible = false;
            }
        }
        catch (Exception ee)
        {
            throw ee;
        }
    }


    protected void gvpower_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvpower_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = new DataTable();
        try
        {
            if (Session["Power"] != null)
            {
                dt = (DataTable)Session["Power"];
                if (dt.Rows.Count > 0)
                {
                    ((DataTable)Session["Power"]).Rows.RemoveAt(e.RowIndex);

                    this.gvpower.DataSource = ((DataTable)Session["Power"]).DefaultView;
                    this.gvpower.DataBind();
                }
                else
                {
                    this.gvpower.DataSource = null;
                    this.gvpower.DataBind();
                }
            }
            else
            {
                this.gvpower.DataSource = null;
                this.gvpower.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
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
            if (trFin1stHalfYear.Visible == true)
            {
                if (txt1stHalfAmountPaid.Text == "" || txt1stHalfAmountPaid.Text == null)
                {
                    lblmsg0.Text = "1st Half Year Amount Paid (in Rs) Cannot be blank" + "<br/>";
                    Failure.Visible = true;
                    btnEnergyAdd.Focus();
                    txt1stHalfAmountPaid.Focus();
                    valid = 1;
                }

                if (txt1stHalfUnitConsumed.Text == "" || txt1stHalfUnitConsumed.Text == null)
                {
                    lblmsg0.Text = "1st Half Year Units Consumed Cannot be blank" + "<br/>";
                    Failure.Visible = true;
                    btnEnergyAdd.Focus();
                    txt1stHalfUnitConsumed.Focus();
                    valid = 1;
                }
            }

            if (trenergyview.Visible == true)
            {
                if (txt2ndHalfAmountPaid.Text == "" || txt2ndHalfAmountPaid.Text == null)
                {
                    lblmsg0.Text = "2nd Half Year Amount Paid (in Rs) Cannot be blank" + "<br/>";
                    Failure.Visible = true;
                    btnEnergyAdd.Focus();
                    txt2ndHalfAmountPaid.Focus();
                    valid = 1;
                }
                if (txt2ndHalfUnitConsumed.Text == "" || txt2ndHalfUnitConsumed.Text == null)
                {
                    lblmsg0.Text = "2nd Half Year Units Consumed Cannot be blank" + "<br/>";
                    Failure.Visible = true;
                    btnEnergyAdd.Focus();
                    txt2ndHalfUnitConsumed.Focus();
                    valid = 1;
                }
            }
            //sowjanya
            DataSet dss = new DataSet();

            if (Convert.ToString(Session["uid"]) != "48696" && Convert.ToString(Session["uid"]) != "6184" && Convert.ToString(Session["uid"]) != "312020")
            {
                dss = getappliedlistEnergy();
                if (dss.Tables[0].Rows.Count > 0)
                {
                    lblmsg0.Text = "You have already applied for financial year " + ddlFinYearEnergy.SelectedItem.Text + " for the" + ddlFin1stOr2ndHalfyear.SelectedItem.Text + " Half";
                    Failure.Visible = true;
                    valid = 1;
                    return;
                }
            }
            //sowjanya
            if (valid == 0)
            {
                if (trFin1stHalfYear.Visible == true)
                {
                    txt2ndHalfUnitConsumed.Text = "0";
                    txt2ndHalfAmountPaid.Text = "0";
                }
                else if (trFin2ndHalfYear.Visible == true)
                {
                    txt1stHalfUnitConsumed.Text = "0";
                    txt1stHalfAmountPaid.Text = "0";
                }
                AddDataToTableEnergy(ddlFinYearEnergy.SelectedValue, ddlFinYearEnergy.SelectedItem.Text, txt1stHalfUnitConsumed.Text, txt1stHalfAmountPaid.Text, txt2ndHalfUnitConsumed.Text, txt2ndHalfAmountPaid.Text, "", ddlFin1stOr2ndHalfyear.SelectedValue, (DataTable)Session["Energy"]);

                this.gvEnergy.DataSource = ((DataTable)Session["Energy"]).DefaultView;
                this.gvEnergy.DataBind();

                ddlFinYearEnergy.SelectedValue = "--Select--";
                ddlFin1stOr2ndHalfyear.SelectedValue = "--Select--";
                txt1stHalfAmountPaid.Text = "";
                txt1stHalfUnitConsumed.Text = "";
                txt2ndHalfAmountPaid.Text = "";
                txt2ndHalfUnitConsumed.Text = "";

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

    public DataSet getappliedlistEnergy()
    {
        DataSet ds = new DataSet();

        con.OpenConnection();
        SqlDataAdapter da = new SqlDataAdapter("USP_GET_FINANCIALYEARS_Applied", con.GetConnection);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.Add("@created_by", SqlDbType.VarChar).Value = Convert.ToString(Session["uid"]);
        da.SelectCommand.Parameters.Add("@finyear", SqlDbType.VarChar).Value = ddlFinYearEnergy.SelectedValue;
        da.SelectCommand.Parameters.Add("@fstorsecndhalf", SqlDbType.VarChar).Value = ddlFin1stOr2ndHalfyear.SelectedValue;

        da.Fill(ds);
        con.CloseConnection();

        return ds;
    }
    public DataSet getappliedlistPower()
    {
        DataSet ds = new DataSet();

        con.OpenConnection();
        SqlDataAdapter da = new SqlDataAdapter("USP_GET_FINANCIALYEARS_PowerApplied", con.GetConnection);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.Add("@created_by", SqlDbType.VarChar).Value = Convert.ToString(Session["uid"]);
        da.SelectCommand.Parameters.Add("@finyear", SqlDbType.VarChar).Value = ddlFinYearPower.SelectedValue;
        da.SelectCommand.Parameters.Add("@fstorsecndhalf", SqlDbType.VarChar).Value = "0";

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
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        PCBClass objPCB = new PCBClass();
        comFunctions cmf = new comFunctions();
        General Gen = new General();
        //string Created_By = Session["uid"].ToString();

        //string amountClaimed = txtClaimedAmount.Text.Trim();

        //Gen.InsertFormIIIIncentivesNew(Created_By, Convert.ToInt32(incentiveId), amountClaimed);

        int start = 0;
        int valid = 0;
        int out2 = 0;
        try
        {
            //msme validations
            string errormsg = "";
            if (trMSME1hps.Visible == true && (IndustryStatus == "2" || IndustryStatus == "3"))
            {
                if (txtExistingHP.Text.Trim() == "")
                {
                    errormsg = errormsg + "Please Enter Exisitng Power Connection in Hp \\n";
                    start = 1;
                }
                if (txtNewHP.Text.Trim() == "")
                {
                    errormsg = errormsg + "Please Enter New Power Connection in Hp \\n";
                    start = 1;
                }
                if (txtNewPowerDate.Text.Trim() == "")
                {
                    errormsg = errormsg + "Please Enter New Power Connection in Hp \\n";
                    start = 1;
                }
            }
            if (trMSME2DiscomCert.Visible == true)
            {
                if (hplDiscomCert.Text.Trim() == "")
                {
                    errormsg = errormsg + "Please Upload Power release certificate issued by DISCOM \\n";
                    start = 1;
                }
            }


            if (string.IsNullOrEmpty(HyperLink4.Text) && lblSelcertificate.Visible == true)
            {
                start = 1;
                    Failure.Visible = true;
                    lblmsg0.Text = "Please upload Mandatory Document(s).";
                    BtnSave.Enabled = true;
                }

            //msme validations
            if (tblExpansionDivers.Visible == true)
            {
                if (gvpower.Visible == false)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please enter Power Details and click on Add button');", true);
                    return;
                }
            }
            if (gvEnergy.Visible == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please enter Energy Details and click on Add button');", true);
                return;
            }
            if (txtClaimedAmount.Text == "" || txtClaimedAmount.Text == null)
            {
                lblmsg0.Text = "Please Enter Amount Claimed";
                Failure.Visible = true;
                txtClaimedAmount.Focus();
                start = 1;
            }
            if (createdby == "201109")
            {
                if (txtelectricitydutyunitsconsumed.Text == "" || txtelectricitydutyunitsconsumed.Text == null)
                {
                    lblmsg0.Text = "Please Enter Electricity Duty Units Consumed";
                    Failure.Visible = true;
                    txtelectricitydutyunitsconsumed.Focus();
                    start = 1;
                }
            }
            if ( HyperLink2.Text == string.Empty || HyperLink3.Text == string.Empty ||   HyperLink5.Text == string.Empty)
            {
                start = 1;
                Failure.Visible = true;
                lblmsg0.Text = "Please upload Mandatory Document(s).";
                BtnSave.Enabled = true;
            }
            else
            {
                if (trExpanDiversPower.Visible == true)
                {
                    if (HyperLink1.Text == string.Empty)
                    {
                        start = 1;
                        Failure.Visible = true;
                        lblmsg0.Text = "Please upload Mandatory Document(s).";
                        BtnSave.Enabled = true;
                    }
                }              
                
            }
            if (start == 0)
            {
                DataSet ds = new DataSet();
                ds = (DataSet)Session["incentivedata"];
                string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
                //int valid1 = Gen.InsertFormIIIIncentivesNew(Session["uid"].ToString(), Convert.ToInt32(IncentiveId), txtClaimedAmount.Text, txtelectricitydutyunitsconsumed.Text, txtelectricitydutyamount.Text);
                int valid1 = Gen.InsertFormIIIIncentivesNew(Session["uid"].ToString(), Convert.ToInt32(IncentiveId), txtClaimedAmount.Text,
                   txtelectricitydutyunitsconsumed.Text, txtelectricitydutyamount.Text, txtExistingHP.Text.Trim(), txtNewHP.Text.Trim(), txtNewPowerDate.Text.Trim());

                UpdateAnnexureflag(IncentiveId, "3", "Y", "");
                if (valid1 == 1)
                {
                    valid = SavePower();
                    //if (valid == 1)
                    //{
                    out2 = SaveEnergy();
                    //}
                    //if (out2 == 1)
                    //{
                    //lblmsg.Text = "Submitted Successfully";
                    //success.Visible = true;

                    string message = "alert('Power Reimbursement Submitted Successfully')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    BtnSave.Enabled = false;
                    BtnDelete.Enabled = true;


                    ////}
                }

            }
            else
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void GetNewPowertoInsertdr()
    {
        myDtNewPowerdr = (DataTable)Session["Power"];
        DataView dvdr = new DataView(myDtNewPowerdr);
        myDtNewPowerdr = dvdr.ToTable();
    }
    protected void GetNewEnergytoInsertdr()
    {
        myDtNewEnergydr = (DataTable)Session["Energy"];
        DataView dvdr = new DataView(myDtNewEnergydr);
        myDtNewEnergydr = dvdr.ToTable();
    }
    private int SavePower()
    {
        PCBClass objPCB = new PCBClass();
        comFunctions cmf = new comFunctions();
        General Gen = new General();
        int value = 0;

        try
        {
            DataSet ds = new DataSet();
            ds = (DataSet)Session["incentivedata"];
            string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
            if (((DataTable)Session["Power"]).Rows.Count > 0)
            {
                GetNewPowertoInsertdr();
                value = Gen.bulkInsertPower(myDtNewPowerdr, IncentiveId);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return value;
    }
    private int SaveEnergy()
    {
        int value = 0;
        try
        {
            PCBClass objPCB = new PCBClass();
            comFunctions cmf = new comFunctions();
            General Gen = new General();

            DataSet ds = new DataSet();
            ds = (DataSet)Session["incentivedata"];
            string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
            if (((DataTable)Session["Energy"]).Rows.Count > 0)
            {
                GetNewEnergytoInsertdr();
                value = Gen.bulkInsertEnergy(myDtNewEnergydr, IncentiveId);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return value;
    }
    #region
    //protected void gvPowerIncentives_RowCommand(object sender, GridViewCommandEventArgs e)
    //{

    //}
    //protected void gvPowerIncentives_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            GridViewRow gvr = e.Row;

    //            DataTable dt = (DataTable)ViewState["dtPowerIncentives"];
    //            DropDownList ddlFinYear = (DropDownList)gvr.FindControl("ddlFinYear");
    //            BindFinancialYears(ddlFinYear, "3");

    //            if (dt != null)
    //            {
    //                if (e.Row.RowIndex < dt.Rows.Count)
    //                {
    //                    TextBox txtUnitsConsumed = (TextBox)gvr.FindControl("txtUnitsConsumed");
    //                    TextBox txtAmountPaid = (TextBox)gvr.FindControl("txtAmountPaid");
    //                    txtUnitsConsumed.Text = dt.Rows[e.Row.RowIndex]["UnitsConsumed"].ToString();
    //                    txtAmountPaid.Text = dt.Rows[e.Row.RowIndex]["Amount"].ToString();
    //                    ddlFinYear.SelectedValue = dt.Rows[e.Row.RowIndex]["FinancialYear"].ToString();
    //                }
    //            }
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        lblmsg.Text = ex.Message;
    //        lblmsg.CssClass = "errormsg"; Failure.Visible = true;
    //    }
    //}

    //protected void gvEnergy_RowCommand(object sender, GridViewCommandEventArgs e)
    //{

    //}
    //protected void gvEnergy_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        //if (e.Row.RowType == DataControlRowType.Header)
    //        //{
    //        //    SortedList createcells2 = new SortedList();
    //        //    createcells2.Add("0", "<b> </b>, 1, 1");
    //        //    createcells2.Add("1", "<b></b>,1,1");
    //        //    createcells2.Add("2", "<b>1st half year</b>,2,1");
    //        //    createcells2.Add("3", "<b>2nd half year</b>,2,1");

    //        //    getmymultiheader(e, createcells2);
    //        //}

    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            GridViewRow gvr = e.Row;

    //            DataTable dt = (DataTable)ViewState["dtEnergy"];
    //            DropDownList ddlFinYear = (DropDownList)gvr.FindControl("ddlFinYear");
    //            BindFinancialYears(ddlFinYear, "5");

    //            if (dt != null)
    //            {
    //                if (e.Row.RowIndex < dt.Rows.Count)
    //                {
    //                    TextBox txtUnitsConsumed = (TextBox)gvr.FindControl("txtUnitsConsumed");
    //                    TextBox txtAmountPaid = (TextBox)gvr.FindControl("txtAmountPaid");
    //                    TextBox txt2ndUnitsConsumed = (TextBox)gvr.FindControl("txt2ndUnitsConsumed");
    //                    TextBox txt2ndAmountPaid = (TextBox)gvr.FindControl("txt2ndAmountPaid");

    //                    txtUnitsConsumed.Text = dt.Rows[e.Row.RowIndex]["F_UnitsConsumed"].ToString();
    //                    txtAmountPaid.Text = dt.Rows[e.Row.RowIndex]["F_Amount"].ToString();
    //                    txt2ndUnitsConsumed.Text = dt.Rows[e.Row.RowIndex]["S_UnitsConsumed"].ToString();
    //                    txt2ndAmountPaid.Text = dt.Rows[e.Row.RowIndex]["S_Amount"].ToString();

    //                    ddlFinYear.SelectedValue = dt.Rows[e.Row.RowIndex]["FinancialYear"].ToString();
    //                }
    //            }
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        lblmsg.Text = ex.Message;
    //        lblmsg.CssClass = "errormsg"; Failure.Visible = true;
    //    }
    //}
    //protected void BtnSave_Click(object sender, EventArgs e)
    //{
    //List<FormIIIPower> lstPower = new List<FormIIIPower>();
    //int IncentiveId = Convert.ToInt32(Session["EntprIncentive"].ToString());

    //foreach (GridViewRow gvr in gvPowerIncentives.Rows)
    //{
    //    FormIIIPower POWERvO = new FormIIIPower();

    //    DropDownList ddlFinYear = (DropDownList)gvr.FindControl("ddlFinYear");
    //    TextBox txtUnitsConsumed = (TextBox)gvr.FindControl("txtUnitsConsumed");
    //    TextBox txtAmountPaid = (TextBox)gvr.FindControl("txtAmountPaid");

    //    POWERvO.FinancialYear = ddlFinYear.SelectedValue;
    //    POWERvO.UnitsConsumed = txtUnitsConsumed.Text;
    //    POWERvO.Amount = txtAmountPaid.Text;

    //    lstPower.Add(POWERvO);
    //}
    //List<FormIIIEnergy> lstEnergy = new List<FormIIIEnergy>();

    //foreach (GridViewRow gvr in gvEnergy.Rows)
    //{
    //    FormIIIEnergy EnergyVo = new FormIIIEnergy();
    //    DropDownList ddlFinYear = (DropDownList)gvr.FindControl("ddlFinYear");
    //    TextBox txtUnitsConsumed = (TextBox)gvr.FindControl("txtUnitsConsumed");
    //    TextBox txtAmountPaid = (TextBox)gvr.FindControl("txtAmountPaid");
    //    TextBox txt2ndUnitsConsumed = (TextBox)gvr.FindControl("txt2ndUnitsConsumed");
    //    TextBox txt2ndAmountPaid = (TextBox)gvr.FindControl("txt2ndAmountPaid");

    //    EnergyVo.FinancialYear = ddlFinYear.SelectedValue;
    //    EnergyVo.F_UnitsConsumed = txtUnitsConsumed.Text;
    //    EnergyVo.F_Amount = txtAmountPaid.Text;
    //    EnergyVo.S_UnitsConsumed = txt2ndUnitsConsumed.Text;
    //    EnergyVo.S_Amount = txt2ndAmountPaid.Text;

    //    lstEnergy.Add(EnergyVo);
    //}
    //string Created_By = Session["uid"].ToString();

    //string amountClaimed = txtClaimedAmount.Text.Trim();
    //int valid = 1;
    //valid = Gen.InsertFormIIIIncentives(Created_By, IncentiveId, amountClaimed, lstPower, lstEnergy);
    //if (valid == 0)
    //{
    //    lblmsg.Text = "Added Successfully..!";
    //    success.Visible = true;
    //    Failure.Visible = false;
    //}
    //}
    //private void getmymultiheader(GridViewRowEventArgs e, SortedList createcells2)
    //{
    //    if (e.Row.RowType == DataControlRowType.Header)
    //    {
    //        GridViewRow row;
    //        IDictionaryEnumerator enumCels = createcells2.GetEnumerator();
    //        row = new GridViewRow(-1, -1, DataControlRowType.Header, DataControlRowState.Normal);
    //        while (enumCels.MoveNext())
    //        {
    //            string[] cont = enumCels.Value.ToString().Split(Convert.ToChar(","));
    //            TableCell Cell;
    //            Cell = new TableCell();
    //            Cell.RowSpan = Convert.ToInt16(cont[2].ToString());
    //            Cell.ColumnSpan = Convert.ToInt16(cont[1].ToString());
    //            Cell.Controls.Add(new LiteralControl(cont[0].ToString()));
    //            Cell.HorizontalAlign = HorizontalAlign.Center;
    //            Cell.ForeColor = System.Drawing.Color.White;
    //            row.Cells.Add(Cell);
    //        }
    //        e.Row.Parent.Controls.AddAt(0, row);
    //    }
    //}
    #endregion
    protected void ddlFin1stOr2ndHalfyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFin1stOr2ndHalfyear.SelectedValue == "1")
        {
            trFin1stHalfYear.Visible = true;
            trFin2ndHalfYear.Visible = false;
        }
        else if (ddlFin1stOr2ndHalfyear.SelectedValue == "2")
        {
            trFin1stHalfYear.Visible = false;
            trFin2ndHalfYear.Visible = true;
        }
        else
        {
            trFin1stHalfYear.Visible = true;
            trFin2ndHalfYear.Visible = true;
        }


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
    protected void txtelectricitydutyunitsconsumed_TextChanged(object sender, EventArgs e)
    {
        if (txtelectricitydutyunitsconsumed.Text == null || txtelectricitydutyunitsconsumed.Text == "")
        {
            txtelectricitydutyunitsconsumed.Text = "0";
        }
        if (Convert.ToDecimal(txtelectricitydutyunitsconsumed.Text) <= 0 || txtelectricitydutyunitsconsumed.Text == null || txtelectricitydutyunitsconsumed.Text == "")
        {
            txtelectricitydutyunitsconsumed.Text = "";
            txtelectricitydutyunitsconsumed.Focus();
            txtelectricitydutyamount.Text = "";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please enter Electricity Duty units Details');", true);
            return;
        }
        else
        {
            txtelectricitydutyamount.Text = (Convert.ToDecimal(txtelectricitydutyunitsconsumed.Text) * Convert.ToDecimal(0.06)).ToString();
        }
    }
    protected void btnDiscomCert_Click(object sender, EventArgs e)
    {
        try
        {
            PCBClass objPCB = new PCBClass();
            comFunctions cmf = new comFunctions();
            General Gen = new General();

            string newPath = "";

            General t1 = new General();

            if (fupDiscomCert.HasFile)
            {
                string incentiveid = Session["EntprIncentive"].ToString();

                if ((fupDiscomCert.PostedFile != null) && (fupDiscomCert.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(fupDiscomCert.PostedFile.FileName);
                    try
                    {
                        string[] fileType = fupDiscomCert.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\3\\905";
                            if (!Directory.Exists(serverpath))
                                Directory.CreateDirectory(serverpath);

                            fupDiscomCert.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                            string CrtdUser = Session["uid"].ToString();

                            string Path = serverpath;
                            string FileName = sFileName;

                            t1.InsertIncentiveAttachment(incentiveid, "NA", "905", sFileName, serverpath, CrtdUser);

                            hplDiscomCert.Text = sFileName;
                            hplDiscomCert.Visible = true;
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
        }
        catch (Exception ex)
        { }

    }
}