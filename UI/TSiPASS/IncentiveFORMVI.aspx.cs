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

public partial class UI_TSiPASS_IncentiveFORMVI : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    DB.DB con = new DB.DB();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["incentivedata"] != null)
            {
                string userid = Session["uid"].ToString();
                string IncentveID = Session["EntprIncentive"].ToString();
                DataSet dscaste = new DataSet();
                dscaste = Gen.GetIncentivesCaste(userid, IncentveID);

                DataSet ds = new DataSet();
                ds = (DataSet)Session["incentivedata"];
                DataRow[] drs = ds.Tables[0].Select("IncentiveID = " + 11);  // Reimbursement of all expenses incurred for Quality Certification/Patent Registration
                if (drs.Length > 0)
                {
                    txtFromCentralGovernment.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtFromStateGovernment.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtFinancingInstitution.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtAmountspentinacquiringthecertification.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtPincode.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    getstates();
                    // string IncentveID = Session["EntprIncentive"].ToString();
                    DataSet dsnew = new DataSet();

                    dsnew = Gen.GetIncentivesfrom4data(IncentveID);
                    Filldata(dsnew);
                }
                else
                {
                    if (Request.QueryString[0].ToString() == "N")
                    {
                        Response.Redirect("SeedCap.aspx?next=" + "N");
                    }
                    else
                    {
                        Response.Redirect("frmIncentiveForm5.aspx?Previous=" + "P");
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
                        lblheadTPRIDE.Text = "<center>" + "ANNEXURE: XII" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF ACQUIRING QUALITY CERTIFICATION COST UNDER T-PRIDE </center></u></b></span>" + "<center>(TELANGANA STATE PROGRAM FOR RAPID INCUBATION OF DALIT ENTREPRENEURS INCENTIVE SCHEME)</center>" + "<center>(G.O.Ms.No.29 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                        lblheadTPRIDE.ForeColor = System.Drawing.Color.White;
                        lblheadTIDEA.Visible = false;

                    }
                    else if (TIDEAflag == "Y")
                    {
                        lblheadTIDEA.Visible = true;

                        lblheadTIDEA.Text = "<center>" + "ANNEXURE: XII" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF ACQUIRING QUALITY CERTIFICATION COST UNDER T - IDEA </center></u></b></span>" + "<center>(TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR ADVANCEMENT) INCENTIVE SCHEME 2014 </center>" + "<center>(G.O.Ms.No.28 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                        lblheadTIDEA.ForeColor = System.Drawing.Color.White;
                        lblheadTPRIDE.Visible = false;
                    }
                }
                
                else
                {
                    lblheadTIDEA.Visible = true;

                    lblheadTIDEA.Text = "<center>" + "ANNEXURE: XII" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF ACQUIRING QUALITY CERTIFICATION COST UNDER " + lblscheme.Text + "</center></u></b></span>" + "<center>(TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR ADVANCEMENT) INCENTIVE SCHEME 2014 </center>" + "<center>(G.O.Ms.No.28 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                    lblheadTIDEA.ForeColor = System.Drawing.Color.White;
                    lblheadTPRIDE.Visible = false;
                }

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
                        trMSME1.Visible = true;
                        lblMSMEPolicy.Visible = true;
                        lblheadTIDEA.Visible = false;
                        lblheadTPRIDE.Visible = false;
                    }
                }


            }
        }
    }
    void Filldata(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            BtnDelete.Enabled = true;
            //
            // BtnSave1.Enabled = true;
            BtnSave1.Enabled = false;

            txtagencyName.Text = ds.Tables[0].Rows[0]["Nameofagency"].ToString();
            txtCertificatNumber.Text = ds.Tables[0].Rows[0]["CertificateNumber"].ToString();
            txtDateofIssue.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DateofIssue"].ToString()).ToString("dd/MM/yyyy");
            txtPeriodofValidity.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["periodofvalidity"].ToString()).ToString("dd/MM/yyyy");
            txtItems.Text = ds.Tables[0].Rows[0]["ManfItems"].ToString();
            txtAmountspentinacquiringthecertification.Text = ds.Tables[0].Rows[0]["Amountspentinacquiringthecertification"].ToString();
            txtFromCentralGovernment.Text = ds.Tables[0].Rows[0]["FromCentralGovernment"].ToString();
            txtFromStateGovernment.Text = ds.Tables[0].Rows[0]["FromStateGovernment"].ToString();
            txtFinancingInstitution.Text = ds.Tables[0].Rows[0]["Fromfinancinginstitution"].ToString();
            ddlstate.SelectedValue = ds.Tables[0].Rows[0]["intStateid"].ToString();
            ddlstate_SelectedIndexChanged(this, EventArgs.Empty);
            if (ds.Tables[0].Rows[0]["intStateid"].ToString() == "31")
            {
                ddldistrict.SelectedValue = ds.Tables[0].Rows[0]["intDistrictid"].ToString();
                ddldistrict_SelectedIndexChanged(this, EventArgs.Empty);
                ddlMandal.SelectedValue = ds.Tables[0].Rows[0]["intMandalid"].ToString();
                ddlMandal_SelectedIndexChanged(this, EventArgs.Empty);
                ddlvillage.SelectedValue = ds.Tables[0].Rows[0]["intVillageid"].ToString();
            }
            else
            {
                txtDistrict.Text = ds.Tables[0].Rows[0]["DistrictName"].ToString();
                txtMandal.Text = ds.Tables[0].Rows[0]["Mandalname"].ToString();
                txtVillage.Text = ds.Tables[0].Rows[0]["VillageName"].ToString();
            }

            txtDoorNo.Text = ds.Tables[0].Rows[0]["Door_No"].ToString();
            txtPincode.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
        }
        if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
        {
            DataTable table = ds.Tables[1];
            string sen, sen1, sen2, sennew;

            foreach (DataRow dr in table.Rows)
            {
                string AttcahmentId = dr["AttachmentId"].ToString();
                sen2 = dr["link"].ToString();
                sen1 = sen2.Replace(@"\", @"/");
                sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                sennew = dr["LINKNEW"].ToString(); // LINKNEW
                string encpassword = Gen.Encrypt(sennew, "SYSTIME");
                //if (AttcahmentId == "9014")
                if (AttcahmentId == "31")
                {
                    //Label453.NavigateUrl = sen;
                    Label453.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    Label453.Text = dr["FileNm"].ToString();
                    Label454.Text = dr["FileNm"].ToString();
                }
                if (AttcahmentId == "50")
                {
                    //HyperLink1.NavigateUrl = sen;
                    HyperLink1.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink1.Text = dr["FileNm"].ToString();
                    Label8.Text = dr["FileNm"].ToString();
                }
                if (AttcahmentId == "32")                //if (AttcahmentId == "9016")
                {
                    //HyperLink3.NavigateUrl = sen;
                    HyperLink3.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink3.Text = dr["FileNm"].ToString();
                    Label14.Text = dr["FileNm"].ToString();
                }
            }
        }
        if (Label453.Text == "" || HyperLink1.Text.Trim() == "" || HyperLink3.Text.Trim() == "")
        {
            BtnSave1.Enabled = true;
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (hdnMSMEApplied.Value == "Y" && txtItems.Text.Trim() == "")
        {
            Failure.Visible = true;
            lblmsg0.Text = "Please add Enter Items of Manufacture.";
            return;

        }
        if (Label453.Text == "" || HyperLink1.Text.Trim() == "" || HyperLink3.Text.Trim() == "")
        {
            Failure.Visible = true;
            lblmsg0.Text = "Please upload Mandatory Document(s).";
        }
        else
        {
            string[] rd1 = null;
            string ConvertedDt1 = "";

            if (txtDateofIssue.Text != "")
            {
                rd1 = txtDateofIssue.Text.Split('/');
                ConvertedDt1 = rd1[1].ToString() + "/" + rd1[0].ToString() + "/" + rd1[2].ToString();
            }

            string[] rd2 = null;
            string ConvertedDt2 = "";

            if (txtPeriodofValidity.Text != "")
            {
                rd2 = txtPeriodofValidity.Text.Split('/');
                ConvertedDt2 = rd2[1].ToString() + "/" + rd2[0].ToString() + "/" + rd2[2].ToString();
            }
         


            formVIVo formvoobj = new formVIVo();
            // formvoobj.Enterpid = "1111";
            // formvoobj.Quessionaireid = "1222";
            if (Request.QueryString[0] != null)
            {
                formvoobj.IncentiveID = Session["EntprIncentive"].ToString();
                formvoobj.agencyName = txtagencyName.Text.Trim().TrimStart();
                formvoobj.CertificateNumber = txtCertificatNumber.Text.Trim().TrimStart();

                //formvoobj.DateofIssue = txtDateofIssue.Text.Trim().TrimStart();
                //formvoobj.periodofvalidity = txtPeriodofValidity.Text.Trim().TrimStart();

                formvoobj.DateofIssue = ConvertedDt1.ToString();
                formvoobj.periodofvalidity = ConvertedDt2.ToString(); 


                formvoobj.Amountspentinacquiringthecertification = txtAmountspentinacquiringthecertification.Text.Trim().TrimStart();
                formvoobj.FromCentralGovernment = txtFromCentralGovernment.Text.Trim().TrimStart();
                formvoobj.FromStateGovernment = txtFromStateGovernment.Text.Trim().TrimStart();
                formvoobj.Fromfinancinginstitution = txtFinancingInstitution.Text.Trim().TrimStart();
                formvoobj.Created_By = Session["uid"].ToString().Trim();

                formvoobj.State = ddlstate.SelectedValue;
                if (formvoobj.State == "31")
                {
                    formvoobj.Dist = ddldistrict.SelectedValue;
                    formvoobj.Mandal = ddlMandal.SelectedValue;
                    formvoobj.Village = ddlvillage.SelectedValue;
                }
                else
                {
                    formvoobj.Dist = txtDistrict.Text.Trim().TrimStart();
                    formvoobj.Mandal = txtMandal.Text.Trim().TrimStart();
                    formvoobj.Village = txtVillage.Text.Trim().TrimStart();
                }
                formvoobj.DoorNo = txtDoorNo.Text.Trim().TrimStart();
                formvoobj.Pincode = txtPincode.Text.Trim().TrimStart();
                formvoobj.Manf_Items = txtItems.Text.Trim();
                int VALID = Gen.InsertFormVivalues(formvoobj);
                UpdateAnnexureflag(formvoobj.IncentiveID, "11", "Y", "");
                if (VALID == 1)
                {
                    //success.Visible = true;
                    //lblmsg.Text = "Data Saved Sucessfully";

                    string message = "alert('Quality Certification Reimbursement Application Submitted Successfully')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    BtnDelete.Enabled = true;
                    BtnSave1.Enabled = false;
                }
            }
        }
    }
    protected void BtnDelete0_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmIncentiveForm5.aspx?Previous=" + "P");
    }
    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        if (hdnMSMEApplied.Value == "Y" && txtItems.Text.Trim() == "")
        {
            Failure.Visible = true;
            lblmsg0.Text = "Please add Enter Items of Manufacture.";
            return;

        }
        if (Label453.Text == "" || HyperLink1.Text.Trim() == "" || HyperLink3.Text.Trim() == "")
        {
            Failure.Visible = true;
            lblmsg0.Text = "Please upload Mandatory Document(s).";
        }
        else
        {
            DataSet ds = new DataSet();
            ds = (DataSet)Session["incentivedata"];
            string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
            UpdateAnnexureflag(IncentiveId, "11", "Y", "");

            Response.Redirect("SeedCap.aspx?next=" + "N");
        }

    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {

    }
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlstate.SelectedValue.ToString() != "--Select--")
        {
            // getdistricts();

            if (ddlstate.SelectedValue.ToString() == "31")
            {
                getdistricts();

                dist.Visible = false;
                mandal.Visible = false;
                Vill.Visible = false;

                dist1.Visible = true;
                mandal1.Visible = true;
                vill1.Visible = true;
            }
            else
            {
                dist.Visible = true;
                mandal.Visible = true;
                Vill.Visible = true;

                dist1.Visible = false;
                mandal1.Visible = false;
                vill1.Visible = false;
            }
        }
        else
        {
            ddldistrict.Items.Clear();
            ddldistrict.Items.Insert(0, "--Select--");
        }
    }
    protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddldistrict.SelectedValue.ToString() != "--Select--")
        {
            getMandals();
        }
        else
        {

        }
    }
    protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlMandal.SelectedValue.ToString() != "--Select--")
        {
            getVillages();

        }
        else
        {
            ddlvillage.Items.Clear();
            ddlvillage.Items.Insert(0, "--Select--");

        }
    }

    void getstates()
    {
        DataSet ds = new DataSet();
        ds = Gen.getStates();

        ddlstate.DataSource = ds.Tables[0];
        ddlstate.DataTextField = "State_Name";
        ddlstate.DataValueField = "State_id";
        ddlstate.DataBind();
        ddlstate.Items.Insert(0, "--Select--");


    }

    protected void getdistricts()
    {
        DataSet dsnew = new DataSet();

        dsnew = Gen.GetDistrictsbystate(ddlstate.SelectedValue.ToString());
        ddldistrict.DataSource = dsnew.Tables[0];
        ddldistrict.DataTextField = "District_Name";
        ddldistrict.DataValueField = "District_Id";
        ddldistrict.DataBind();
        ddldistrict.Items.Insert(0, "--Select--");

    }

    void getMandals()
    {

        DataSet dsnew = new DataSet();

        dsnew = Gen.Getmandalsbydistrict(ddldistrict.SelectedValue.ToString());
        ddlMandal.DataSource = dsnew.Tables[0];
        ddlMandal.DataTextField = "Manda_lName";
        ddlMandal.DataValueField = "Mandal_Id";
        ddlMandal.DataBind();
        ddlMandal.Items.Insert(0, "--Select--");


    }

    void getVillages()
    {

        DataSet dsnew = new DataSet();

        dsnew = Gen.GetVillagebymandal(ddlMandal.SelectedValue.ToString());
        ddlvillage.DataSource = dsnew.Tables[0];
        ddlvillage.DataTextField = "Village_Name";
        ddlvillage.DataValueField = "Village_Id";
        ddlvillage.DataBind();
        ddlvillage.Items.Insert(0, "--Select--");


    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FileUpload10.HasFile)
        {
            string incentiveid = Session["EntprIncentive"].ToString();

            if ((FileUpload10.PostedFile != null) && (FileUpload10.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload10.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload10.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\9014");  // incentiveid2
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\31");  // incentiveid2
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\11\\31");  // incentiveid2
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\11\\31";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload10.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        //t1.InsertIncentiveAttachment(incentiveid, "9014", sFileName, serverpath, CrtdUser);
                        t1.InsertIncentiveAttachment(incentiveid, "NA", "31", sFileName, serverpath, CrtdUser);
                        Label453.Text = FileUpload10.FileName;
                        Label454.Text = sFileName;
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
    protected void Button9_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FileUpload11.HasFile)
        {
            string incentiveid = Session["EntprIncentive"].ToString();

            if ((FileUpload11.PostedFile != null) && (FileUpload11.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload11.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload11.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\9015");  // incentiveid2
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\50");  // incentiveid2
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\11\\50");  // incentiveid2
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\11\\50";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload11.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        t1.InsertIncentiveAttachment(incentiveid, "NA", "50", sFileName, serverpath, CrtdUser);
                        HyperLink1.Text = FileUpload11.FileName;
                        Label8.Text = sFileName;
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
    }
    protected void Button11_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FileUpload13.HasFile)
        {
            string incentiveid = Session["EntprIncentive"].ToString();

            if ((FileUpload13.PostedFile != null) && (FileUpload13.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload13.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload13.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\9016");  // incentiveid2
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\32");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\11\\32");
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\11\\32";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload13.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        //t1.InsertIncentiveAttachment(incentiveid, "9016", sFileName, serverpath, CrtdUser);
                        t1.InsertIncentiveAttachment(incentiveid, "NA", "32", sFileName, serverpath, CrtdUser);
                        HyperLink3.Text = FileUpload13.FileName;
                        Label14.Text = sFileName;
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
    }
    protected void txtPeriodofValidity_TextChanged(object sender, EventArgs e)
    {

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
}