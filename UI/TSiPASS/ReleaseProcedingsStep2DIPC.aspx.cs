using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Text;
using System.Net;

using System.Threading;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using AjaxControlToolkit;
using Microsoft.SqlServer.Server;

public partial class UI_TSiPASS_ReleaseProcedingsStep2DIPC : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DB.DB con = new DB.DB();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pageloadgetmethod();
        }
    }

    public void pageloadgetmethod()
    {
        // string Slcno = Request.QueryString[0].ToString();
        string Cast = Request.QueryString[0].ToString();
        string Investmentid = Request.QueryString[1].ToString();
        string GoAllotedAmount = Request.QueryString[2].ToString();
        string locDate = Request.QueryString[7].ToString();  //nikhil
        h1heading.InnerHtml = Cast + " Category";

        DataSet ds = new DataSet();
        //ds = Gen.getReleaseProceedingsStep2DIPC(Cast, Investmentid, GoAllotedAmount);
        ds = Gen.getReleaseProceedingsStep2DIPC(Cast, Investmentid, GoAllotedAmount, locDate);  //nikhil
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            tdinvestments.InnerHtml = "--> " + ds.Tables[0].Rows[0]["IncentiveName"].ToString();
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();

            lblremaingAmount.Text = ds.Tables[1].Rows[0]["RemainingAmount"].ToString();
        }

    }

    public string MsgMobile(string email, string Applicationno, string ApplicantName)
    {
        string returnVal="";
        try
        {

            //////mobile message purpose
            string msgMobile = "Dear,'" + ApplicantName + "' Application no '" + Applicationno + "' Please download this agreement format https://ipass.telangana.gov.in/docs/ReleaseAttachments/T_PRIDE_2015-19_AGR_BOND.pdf and upload the filled up copy(on stamp paper). Assignment letter (on non stamp paper). Only after you submit these documents online, GM-DIC will conduct field inspection to release incentives. Thank you, Commissioner of Industries.";
            string msgMobile1 = "Dear,'" + ApplicantName + "' Application no '" + Applicationno + "' Please visit https://ipass.telangana.gov.in and login to submit details towards further release of sanctioned incentives. Thank you, Commissioner of Industries.";

            string bodyMobile = msgMobile;
            string bodyMobile2 = msgMobile1;
            //string testforSMS1 = SendSingleSMSnew(email, bodyMobile2);
            //string testforSMS2 = SendSingleSMSnew(email, bodyMobile);
            //returnVal = (testforSMS1);
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
        return returnVal;
    }

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

    public int ReleaseProcedingDipcAction(List<ReleasingProceedings> rpd)
    {

        var RESULT = 0;

        foreach (ReleasingProceedings rp in rpd)
        {
            SqlParameter[] pp = new SqlParameter[] {
                new SqlParameter("@intApplicationid",SqlDbType.VarChar),
                new SqlParameter("@lblMstIncentiveId",SqlDbType.VarChar),
                new SqlParameter("@AllotedAmount",SqlDbType.VarChar),
                new SqlParameter("@DIPCNo",SqlDbType.VarChar),
                new SqlParameter("@Gono",SqlDbType.VarChar),
                new SqlParameter("@Godate",SqlDbType.VarChar),
                new SqlParameter("@Locno",SqlDbType.VarChar),
                new SqlParameter("@Locdate",SqlDbType.VarChar),
                new SqlParameter("@Modified_by",SqlDbType.VarChar),
                new SqlParameter("@Valid",SqlDbType.VarChar),
                new SqlParameter("@ReleaseProcedingNo",SqlDbType.VarChar),
                new SqlParameter("@ReleaseProcedingDate",SqlDbType.VarChar),
                new SqlParameter("@RemaningAmt",SqlDbType.VarChar),
                new SqlParameter("@GoReleaseAmt",SqlDbType.VarChar),
                new SqlParameter("@Caste",SqlDbType.VarChar),
                new SqlParameter("@SubIncTypeId",SqlDbType.VarChar)
            };

            pp[0].Value = rp.EnterperIncentiveID;
            pp[1].Value = rp.MstIncentiveId;
            pp[2].Value = rp.AllotedAmount;
            pp[3].Value = rp.SLCNo;
            pp[4].Value = rp.Gono;
            pp[5].Value = rp.Godate;
            pp[6].Value = rp.Locno;
            pp[7].Value = rp.Locdate;
            pp[8].Value = rp.CreatedByid;
            pp[9].Value = "0";
            pp[9].Direction = ParameterDirection.Output;
            pp[10].Value = rp.ReleaseProcedingNo;
            pp[11].Value = rp.ReleaseProcedingDate;
            pp[12].Value = rp.RemaningAmt;
            pp[13].Value = rp.GoReleaseAmt;
            pp[14].Value = rp.Caste;
            pp[15].Value = rp.SubIncTypeId;

            Gen.GenericExecuteNonQuery("USP_INSERT_RELEASE_PROCEEDINGS_step2_DIPC", pp);
            RESULT = Convert.ToInt32(pp[9].Value);
        }
        return RESULT;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        List<ReleasingProceedings> lstincentives = new List<ReleasingProceedings>();
        foreach (GridViewRow gvrow in grdDetails.Rows)
        {
            ReleasingProceedings frmvo = new ReleasingProceedings();
            string lblMstIncentiveId = ((Label)gvrow.FindControl("lblMstIncentiveId")).Text;
            string lblIncentiveID = ((Label)gvrow.FindControl("lblIncentiveID")).Text;
            string lblAllotedAmount = ((Label)gvrow.FindControl("lblAllotedAmount")).Text;
            string lblSLCNumer = ((Label)gvrow.FindControl("lblSLCNumer")).Text;

            frmvo.EnterperIncentiveID = lblIncentiveID;
            frmvo.MstIncentiveId = lblMstIncentiveId;
            frmvo.CreatedByid = Session["uid"].ToString();
            frmvo.AllotedAmount = lblAllotedAmount;
            frmvo.SLCNo = lblSLCNumer;

            string txtGoNo = Session["txtGoNo"].ToString();
            string txtGodate = Session["txtGodate"].ToString();
            string txtLocno = Session["txtLocno"].ToString();
            string txtLocdate = Session["txtLocdate"].ToString();

            string[] godatett = txtGodate.Split('/');
            string[] locdate = txtLocdate.Split('/');
            string[] releaseProDate = txtRelProDate.Text.Split('/');

            frmvo.Godate = godatett[2] + "/" + godatett[1] + "/" + godatett[0];
            frmvo.Locdate = locdate[2] + "/" + locdate[1] + "/" + locdate[0];
            frmvo.Gono = txtGoNo;
            frmvo.Locno = txtLocno;
            frmvo.ReleaseProcedingNo = txtRelProNo.Text.Trim();
            frmvo.ReleaseProcedingDate = releaseProDate[2] + "/" + releaseProDate[1] + "/" + releaseProDate[0];
            frmvo.Caste = Request.QueryString[0].ToString();
            frmvo.SubIncTypeId = Request.QueryString[3].ToString();
            frmvo.RemaningAmt = lblremaingAmount.Text;
            frmvo.GoReleaseAmt = Request.QueryString[2].ToString();

            lstincentives.Add(frmvo);
        }

        //int valid = gen.InsertFinalProceedingsStep2DIPC(lstincentives);

        int valid = ReleaseProcedingDipcAction(lstincentives);

        if (valid == 1)
        {
            //lblmsg.Text = "<font color='green'>Application Submitted Successfully..!</font>";
            //success.Visible = true;
            //Failure.Visible = false;
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Application Submitted Successfully');", true);

            string message = "alert('amount alloted Successfully')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            Button3.Enabled = false;
            foreach (GridViewRow gvrow1 in grdDetails.Rows)
            {
                string mobileNumber = ((Label)gvrow1.FindControl("lblUnitMObileNo")).Text;
                string Applicationno = ((Label)gvrow1.FindControl("lblApplicationno")).Text;
                string ApplicantName = ((Label)gvrow1.FindControl("lblApplicantName")).Text;
                string incentiveNo = ((Label)gvrow1.FindControl("lblIncentiveID")).Text;
                string Mstid = ((Label)gvrow1.FindControl("lblMstIncentiveId")).Text;

                if (mobileNumber != "NA" && mobileNumber != "1234567890")
                {
                    string checkingVal = MsgMobile(mobileNumber, Applicationno, ApplicantName);
                    if (checkingVal.Contains("402"))
                    {
                        SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
                        osqlConnection.Open();
                        SqlCommand cmd = new SqlCommand("USP_releaseDocSMS_dipc", osqlConnection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@mstid", Mstid);
                        cmd.Parameters.AddWithValue("@incid", incentiveNo);
                        cmd.ExecuteNonQuery();
                        osqlConnection.Close();
                    }
                }
            }
        }
        //lblmsg.Text = "<font color='green'>Saved Successfully..!</font>";
        //success.Visible = true;
        //Failure.Visible = false;
    }
    protected void bntUpload_Click(object sender, EventArgs e)
    {

        string newPath = "";
        string sFileDir = Server.MapPath("~\\DIPCReleaseProcedingIncentiveAttachments");
        General t1 = new General();
        BusinessLogic.DML objDml = new BusinessLogic.DML();

        string MstIncentiveId = "";
        string IncentiveID = "";
        string SLCNumer = string.Empty;
        string dipcdate = "";

        FileUpload fup = null;
        fup = fucReleaseProCopy;

        if (fucReleaseProCopy.HasFile)
        {
            if ((fucReleaseProCopy.PostedFile != null) && (fucReleaseProCopy.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(fucReleaseProCopy.PostedFile.FileName);
                try
                {
                    string[] fileType = fucReleaseProCopy.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        foreach (GridViewRow gvrow in grdDetails.Rows)
                        {
                            SLCNumer = ((Label)gvrow.FindControl("lblSLCNumer")).Text;
                            dipcdate = ((Label)gvrow.FindControl("lbldipcdate")).Text;
                            string[] rd1 = null;

                            if (dipcdate.ToString() != "")
                            {
                                rd1 = dipcdate.ToString().Split('/');
                                dipcdate = rd1[0].ToString() + rd1[1].ToString() + rd1[2].ToString();

                            }
                            //newPath = System.IO.Path.Combine(sFileDir, SLCNumer);
                            newPath = System.IO.Path.Combine(sFileDir, dipcdate);

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            //int count = dir.GetFiles().Length;
                            //if (count == 0)

                            fucReleaseProCopy.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }

                        //else
                        //{
                        //    if (count == 1)
                        //    {
                        //        string[] Files = Directory.GetFiles(newPath);
                        //        foreach (string file in Files)
                        //        {
                        //            File.Delete(file);
                        //        }
                        //        fucReleaseProCopy.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        //    }
                        //}

                        foreach (GridViewRow gvrow in grdDetails.Rows)
                        {
                            MstIncentiveId = ((Label)gvrow.FindControl("lblMstIncentiveId")).Text;
                            IncentiveID = ((Label)gvrow.FindControl("lblIncentiveID")).Text;
                            //SLCNumer = ((Label)gvrow.FindControl("lblSLCNumer")).Text;
                            //  SLCNumer = ((Label)gvrow.FindControl("lblSLCNumer")).Text;
                            SLCNumer = "0";  // added on 11.03.2018 for offline DLC release // need to uncomment for online DLC releases
                            //newPath = System.IO.Path.Combine(sFileDir, SLCNumer);
                            dipcdate = ((Label)gvrow.FindControl("lbldipcdate")).Text;
                            string[] rd1 = null;
                            if (dipcdate.ToString() != "")
                            {
                                rd1 = dipcdate.ToString().Split('/');
                                dipcdate = rd1[0].ToString() + rd1[1].ToString() + rd1[2].ToString();

                            }
                            newPath = System.IO.Path.Combine(sFileDir, dipcdate);


                            if (MstIncentiveId != "" && IncentiveID != "" && SLCNumer != "")
                            {
                                objDml.InsUpdCOI_Incentive_Attachments(3, Convert.ToInt32(IncentiveID), Convert.ToInt32(MstIncentiveId), Convert.ToInt32(SLCNumer), sFileName, newPath, Convert.ToInt32(Session["uid"].ToString()));
                            }
                        }
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        txtFucRpc.Text = "1";
                        lnkReleaseCopy.Text = fucReleaseProCopy.FileName;
                        lnkReleaseCopy.NavigateUrl = newPath + "\\" + sFileName;

                        success.Visible = true;
                        Failure.Visible = false;

                        string message1 = "alert(Release Proceding Copy Added Successfully.)";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message1, true);
                        return;
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }
                }
                catch (Exception)//in case of an error
                {
                    DeleteFile(newPath + "\\" + sFileName);
                    txtFucRpc.Text = "0";
                }
            }
        }
        else
        {
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            txtFucRpc.Text = "0";
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
    protected void chkIsSpecialUnit_CheckedChanged(object sender, EventArgs e)
    {
        if (chkIsSpecialUnit.Checked == true)
        {
            grdDetails.DataSource = null;
            grdDetails.DataBind();

            tblmain.Visible = false;
            tblspecialcasesSearch.Visible = true;

            ddlDist.Items.Clear();
            ddlSLCNo.Items.Clear();
            txtUnitName.Text = "";
            lblremaingAmount2.Text = Request.QueryString[2].ToString();
            ViewState["SelectedRecords"] = null;

            BindDistricts(ddlDist);

            //gvData2.DataSource = null;
            // gvData2.DataBind();
            trRemainingAmount2.Visible = true;

        }
        else
        {
            pageloadgetmethod();
            tblmain.Visible = true;
            tblspecialcasesSearch.Visible = false;
            tblselectedcases.Visible = false;
            ViewState["SelectedRecords"] = null;
            lblremaingAmount2.Text = "";
            trRemainingAmount2.Visible = false;

        }
    }
    private void BindDistricts(DropDownList ddlDistrict)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlDistrict.Items.Clear();
            //  dsd = Gen.GetDistrictsForOldSanctionedIncentives();
            dsd = Gen.GetDistrictsWithoutHYD();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlDistrict.DataSource = dsd.Tables[0];
                ddlDistrict.DataValueField = "District_Id";
                ddlDistrict.DataTextField = "District_Name";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlDistrict.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }
    private void BindDIPCDtae(DropDownList ddlSLCNo)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlSLCNo.Items.Clear();
            string Cast2 = Request.QueryString[0].ToString();
            string Investmentid2 = Request.QueryString[1].ToString();

            //dsd = Gen.GetIncentivesDIPCdateList(Cast2, Investmentid2, ddlDist.SelectedValue);
            dsd = GetIncentivesDIPCdateList(Cast2, Investmentid2, ddlDist.SelectedValue);

            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlSLCNo.DataSource = dsd.Tables[0];
                ddlSLCNo.DataValueField = "dipcdate";
                ddlSLCNo.DataTextField = "dipcdate";
                ddlSLCNo.DataBind();
                ddlSLCNo.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlSLCNo.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }
    protected void btnGet_Click(object sender, EventArgs e)
    {
        int valid = 0;
        lblmsg0.Text = "";
        ViewState["UIDNO"] = null;
        Session["UIDNO"] = null;
        Failure.Visible = false;

        string Cast = Request.QueryString[0].ToString();
        string Investmentid = Request.QueryString[1].ToString();
        string GoAllotedAmount = Request.QueryString[2].ToString();

        if (txtUnitName.Text.Trim() == "")
        {
            lblmsg0.Text += "Please enter Unit Name" + "<br/>";
            valid = 1;
        }
        if (ddlDist.SelectedItem.Text == "--Select--")
        {
            lblmsg0.Text += "Please Select District" + "<br/>";
            valid = 1;
        }
        if (ddlSLCNo.SelectedItem.Text == "--Select--")
        {
            lblmsg0.Text += "Please Select SLC No" + "<br/>";
            valid = 1;
        }

        if (valid == 0)
        {
            string dipcdate = "";
            dipcdate = ddlSLCNo.SelectedValue;
            //string dipcdatenew[]= split(''dipcdate);
            string[] rd1 = null;
            string ConvertedDt1 = "";
            rd1 = dipcdate.Split('/');
            ConvertedDt1 = rd1[1].ToString() + "/" + rd1[0].ToString() + "/" + rd1[2].ToString();

            DataSet dsd = new DataSet();
            //dsd = Gen.GetIncentives_Release_Proceedings_UnitName_searchDIPC(ddlSLCNo.SelectedValue, ddlDist.SelectedValue, txtUnitName.Text.Trim(), Investmentid, Cast);
            //dsd = GetIncentives_Release_Proceedings_UnitName_searchDIPC(ddlSLCNo.SelectedValue, ddlDist.SelectedValue, txtUnitName.Text.Trim(), Investmentid, Cast);
            dsd = GetIncentives_Release_Proceedings_UnitName_searchDIPC(ConvertedDt1, ddlDist.SelectedValue, txtUnitName.Text.Trim(), Investmentid, Cast);
            if (dsd != null && dsd.Tables.Count > 0)
            {
                if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
                {
                    gvData2.DataSource = dsd.Tables[0];
                    gvData2.DataBind();
                    tr1.Visible = true;
                    tblspecialcasesSearch.Visible = true;
                    trsearchresult.Visible = true;
                }
                else
                {
                    gvData2.DataSource = null;
                    gvData2.DataBind();
                    Failure.Visible = true;
                    lblmsg0.Text = "No Details Found ";
                    tr1.Visible = false;
                    tblspecialcasesSearch.Visible = true;
                    trsearchresult.Visible = false;

                }

            }
            else
            {
                gvData2.DataSource = null;
                gvData2.DataBind();
                grdDetails.DataSource = null;
                grdDetails.DataBind();
                Failure.Visible = true;
                lblmsg0.Text = "No Details Found ";
                tr1.Visible = false;
                tblspecialcasesSearch.Visible = true;
                trsearchresult.Visible = false;
            }
            // Failure.Visible = false;
        }
        else
        {
            Failure.Visible = true;
            gvData2.DataSource = null;
            gvData2.DataBind();
            grdDetails.DataSource = null;
            grdDetails.DataBind();
            Failure.Visible = true;

            tr1.Visible = false;
            tblspecialcasesSearch.Visible = true;
            trsearchresult.Visible = false;
        }
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if ((e.Row.RowType == DataControlRowType.DataRow))
            {
                HiddenField hdsSanctionSLNOOld = (HiddenField)e.Row.Cells[0].FindControl("hdfSanctionSlNo");
                hdsSanctionSLNOOld.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SanctionSlNo")).Trim();

                HiddenField hdfUIDOld = (HiddenField)e.Row.Cells[0].FindControl("hdfUID");
                hdfUIDOld.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UIDNo")).Trim();

                HiddenField hdfincentiveId = (HiddenField)e.Row.Cells[0].FindControl("hdfIncentiveID");
                hdfincentiveId.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IncentiveId")).Trim();

                string UnitName = "", District = "", Scheme = "", SanctionedAmount = "", SanctionedDate = "", FinYear = "", SLCNumber = "", IncentiveId = "";

                UnitName = e.Row.Cells[1].Text;
                District = e.Row.Cells[2].Text;
                Scheme = e.Row.Cells[3].Text;
                SanctionedAmount = e.Row.Cells[4].Text;
                SanctionedDate = e.Row.Cells[5].Text;
                FinYear = e.Row.Cells[6].Text;
                SLCNumber = e.Row.Cells[7].Text;
                IncentiveId = hdfincentiveId.Value;
                string UIDNo = "";
                if (ViewState["UIDNO"] != null && ViewState["UIDNO"].ToString() != "")
                {
                    UIDNo = ViewState["UIDNO"].ToString();
                }
                (e.Row.FindControl("anchortaglinkView") as HyperLink).Visible = true;
                (e.Row.FindControl("anchortaglinkView") as HyperLink).NavigateUrl = "DIPCSanctionedDtlsEntryScreenNew.aspx?SanctionSLNo=" + hdsSanctionSLNOOld.Value + "&UnitName=" + UnitName + "&District=" + District + "&Scheme=" + Scheme + "&SanctionedAmount=" + SanctionedAmount + "&SanctionedDate=" + SanctionedDate + "&FinYear=" + FinYear + "&SLCNumber=" + SLCNumber + "&IncentiveId=" + IncentiveId + "&UIDNo=" + UIDNo;
                //DIPCSanctionedDtlsEntryScreenNew


            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }
    protected void ChckedChanged(object sender, EventArgs e)
    {
        GetData();
        // SetData();
        BindSecondaryGrid();
    }
    private void GetSelectedRows()
    {
        for (int i = 0; i < gvData2.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)gvData2.Rows[i].Cells[0].FindControl("chkSameUnit");
            if (chk.Checked)
            {
                HiddenField hdfUIDOld = (HiddenField)gvData2.Rows[i].Cells[0].FindControl("hdfUID");
                string UID = hdfUIDOld.Value;
                ViewState["UIDNO"] = UID;
                Session["UIDNO"] = UID;
                //string UID=gvData2.Rows[i][].tos
            }
            else
            {
                ViewState["UIDNO"] = null;
                Session["UIDNO"] = null;
                // dt = RemoveRow(gvEmpInfo.Rows[i], dt);
            }
        }
    }
    protected void gvData2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if ((e.Row.RowType == DataControlRowType.DataRow))
            {
                Label enterid = (e.Row.FindControl("lblIncentiveID") as Label);
                Label MstIncentiveId = (e.Row.FindControl("lblMstIncentiveId") as Label);

            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }
    private DataTable CreateDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("NameofUnit");
        dt.Columns.Add("Address");
        dt.Columns.Add("DCP");
        dt.Columns.Add("IncentiveName");
        dt.Columns.Add("SanctionedAmount", typeof(decimal));
        dt.Columns.Add("SanctionedDate");
        dt.Columns.Add("AllotedAmount", typeof(decimal));
        dt.Columns.Add("MstIncentiveId");
        dt.Columns.Add("EnterperIncentiveID");
        //dt.Columns.Add("SLCNumer");
        dt.Columns.Add("dipcnumer");
        dt.Columns.Add("UnitMObileNo");
        dt.Columns.Add("Applicationno");
        dt.Columns.Add("ApplicantName");

        dt.AcceptChanges();
        return dt;

    }

    int AddStatus = 0;
    int RemoveStatus = 0;

    private void GetData()
    {
        DataTable dt;
        if (ViewState["SelectedRecords"] != null)
            dt = (DataTable)ViewState["SelectedRecords"];
        else
            dt = CreateDataTable();
        // CheckBox chkAll = (CheckBox)gvData2.HeaderRow.Cells[0].FindControl("chkAll");
        for (int i = 0; i < gvData2.Rows.Count; i++)
        {
            //if (chkAll.Checked)
            //{
            //    dt = AddRow(gvData2.Rows[i], dt);
            //}
            //else
            //{
            decimal enterid = Convert.ToDecimal(gvData2.Rows[i].Cells[5].Text.ToString());
            CheckBox chk = (CheckBox)gvData2.Rows[i]
                            .Cells[0].FindControl("chkSameUnit");
            if (chk.Checked)
            {
                decimal GORelAmt = Convert.ToDecimal(Request.QueryString[2].ToString());
                if (lblremaingAmount2.Text == "")
                {
                    lblremaingAmount2.Text = GORelAmt.ToString();
                }
                decimal SanAmt = enterid;

                // if (Convert.ToDecimal(lblremaingAmount2.Text) >= SanAmt)
                //  {
                dt = AddRow(gvData2.Rows[i], dt);
                if (AddStatus == 1)
                {
                    if (lblremaingAmount2.Text != "")
                    {
                        lblremaingAmount2.Text = (Convert.ToDecimal(lblremaingAmount2.Text) - enterid).ToString();
                    }
                }
                //}
                //else
                //{
                //    chk.Checked = false;
                //    Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Sanctioned Amount for this unit is higher than G.O. release amount');", true);

                //}

            }
            else
            {
                dt = RemoveRow(gvData2.Rows[i], dt);
                if (RemoveStatus == 1)
                {
                    if (lblremaingAmount2.Text != "")
                    {
                        lblremaingAmount2.Text = (Convert.ToDecimal(lblremaingAmount2.Text) + enterid).ToString();
                    }
                }
            }
            // }
        }
        ViewState["SelectedRecords"] = dt;
    }
    private DataTable AddRow(GridViewRow gvRow, DataTable dt)
    {

        Label enterid = (gvRow.FindControl("lblIncentiveID") as Label);
        Label lblAllotedAmount = (gvRow.FindControl("lblAllotedAmount") as Label);
        Label lblMstIncentiveId = (gvRow.FindControl("lblMstIncentiveId") as Label);
        Label lblIncentiveID = (gvRow.FindControl("lblIncentiveID") as Label);
        Label lblSLCNumer = (gvRow.FindControl("lblSLCNumer") as Label);
        Label lblUnitMObileNo = (gvRow.FindControl("lblUnitMObileNo") as Label);
        Label lblApplicationno = (gvRow.FindControl("lblApplicationno") as Label);
        Label lblApplicantName = (gvRow.FindControl("lblApplicantName") as Label);

        DataRow[] dr = dt.Select("EnterperIncentiveID = '" + enterid.Text + "'");
        if (dr.Length <= 0)
        {
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1]["NameofUnit"] = gvRow.Cells[2].Text;
            dt.Rows[dt.Rows.Count - 1]["Address"] = gvRow.Cells[3].Text;
            dt.Rows[dt.Rows.Count - 1]["DCP"] = gvRow.Cells[4].Text;

            dt.Rows[dt.Rows.Count - 1]["SanctionedAmount"] = gvRow.Cells[5].Text;
            dt.Rows[dt.Rows.Count - 1]["SanctionedDate"] = gvRow.Cells[6].Text;

            // dt.Rows[dt.Rows.Count - 1]["AllotedAmount"] = lblAllotedAmount.Text;
            dt.Rows[dt.Rows.Count - 1]["AllotedAmount"] = gvRow.Cells[5].Text;


            dt.Rows[dt.Rows.Count - 1]["MstIncentiveId"] = lblMstIncentiveId.Text;
            dt.Rows[dt.Rows.Count - 1]["EnterperIncentiveID"] = lblIncentiveID.Text;
            //dt.Rows[dt.Rows.Count - 1]["SLCNumer"] = lblSLCNumer.Text;
            dt.Rows[dt.Rows.Count - 1]["dipcnumer"] = lblSLCNumer.Text;
            dt.Rows[dt.Rows.Count - 1]["UnitMObileNo"] = lblUnitMObileNo.Text;
            dt.Rows[dt.Rows.Count - 1]["Applicationno"] = lblApplicationno.Text;
            dt.Rows[dt.Rows.Count - 1]["ApplicantName"] = lblApplicantName.Text;

            dt.AcceptChanges();
            AddStatus = 1;
        }
        else
        {
            AddStatus = 0;
        }

        return dt;
    }
    private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
    {
        Label enterid = (gvRow.FindControl("lblIncentiveID") as Label);
        DataRow[] dr = dt.Select("EnterperIncentiveID = '" + enterid.Text + "'");
        if (dr.Length > 0)
        {
            dt.Rows.Remove(dr[0]);
            dt.AcceptChanges();
            RemoveStatus = 1;
        }
        else
        {
            RemoveStatus = 0;
        }
        return dt;
    }
    private void BindSecondaryGrid()
    {
        DataTable dt = (DataTable)ViewState["SelectedRecords"];

        if (dt.Rows.Count > 0)
        {
            btnNext.Visible = true;
            GridView1.DataSource = dt;
            GridView1.DataBind();
            tr2.Visible = true;
            tblselectedcases.Visible = true;
            btnNext.Visible = true;
            trprint.Visible = true;
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            btnNext.Visible = false;
            tr2.Visible = false;
            tblselectedcases.Visible = false;
            btnNext.Visible = false;
            trprint.Visible = false;

        }
    }
    private void SetData()
    {
        CheckBox chkAll = (CheckBox)gvData2.HeaderRow.Cells[0].FindControl("chkAll");
        chkAll.Checked = true;
        if (ViewState["SelectedRecords"] != null)
        {
            DataTable dt = (DataTable)ViewState["SelectedRecords"];
            for (int i = 0; i < gvData2.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gvData2.Rows[i].Cells[0].FindControl("chk");
                if (chk != null)
                {
                    DataRow[] dr = dt.Select("CustomerID = '" + gvData2.Rows[i].Cells[1].Text + "'");
                    chk.Checked = dr.Length > 0;
                    if (!chk.Checked)
                    {
                        chkAll.Checked = false;
                    }
                }
            }
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        decimal goRelaseAmt = Convert.ToDecimal(Request.QueryString[2].ToString());
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //decimal enterid = Convert.ToDecimal(e.Row.Cells[4].Text.ToString());
            //lblremaingAmount2.Text =  (Convert.ToDecimal(lblremaingAmount2.Text) - enterid).ToString();
        }

        //    lblremaingAmount2.Text = (Convert.ToDecimal(lblremaingAmount2.Text) - SanAmt).ToString();

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        Label lblIncentiveID = GridView1.Rows[e.RowIndex].FindControl("Label3") as Label;
        decimal enterid = Convert.ToDecimal(GridView1.Rows[e.RowIndex].Cells[4].Text.ToString());
        DataTable dt = (DataTable)ViewState["SelectedRecords"];

        DataRow[] dr = dt.Select("EnterperIncentiveID = '" + lblIncentiveID.Text + "'");
        if (dr.Length > 0)
        {
            dt.Rows.Remove(dr[0]);
            dt.AcceptChanges();
            ViewState["SelectedRecords"] = dt;
            uncheck(lblIncentiveID.Text);
            if (lblremaingAmount2.Text != "")
            {
                lblremaingAmount2.Text = (Convert.ToDecimal(lblremaingAmount2.Text) + enterid).ToString();
            }
        }

        BindSecondaryGrid();
    }
    public void uncheck(string str)
    {
        for (int i = 0; i < gvData2.Rows.Count; i++)
        {
            Label lblIncentiveID = gvData2.Rows[i].Cells[0].FindControl("lblIncentiveID") as Label;
            CheckBox chk = (CheckBox)gvData2.Rows[i].Cells[0].FindControl("chkSameUnit");
            if (lblIncentiveID.Text == str)
            {
                if (chk.Checked)
                {
                    chk.Checked = false;
                }
            }
        }

    }

    protected void btnNext_Click(object sender, EventArgs e)
    {

        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();

        dt1 = ViewState["SelectedRecords"] as DataTable;

        //string Cast = Request.QueryString[0].ToString();
        //string Investmentid = Request.QueryString[1].ToString();
        //string GoAllotedAmount = string.Format("{0:C0}", lblremaingAmount2.Text);
        string SubIncType = Request.QueryString[3].ToString();

        string Cast = Request.QueryString[0].ToString();
        string Investmentid = Request.QueryString[1].ToString();
        string GoAllotedAmount = string.Format("{0:C0}", lblremaingAmount2.Text); //Request.QueryString[2].ToString(); COMMENTED BY MADHURI ON 28/08/2019 FOR GETTING REMAINING AMOUNT CORRECLTY
        //string locDate = Request.QueryString[8].ToString();
        string locDate = Request.QueryString[7].ToString();  //changed - 29.10.2018.. Error
        // string Sectorname = Request.QueryString["Sector"].ToString();

        h1heading.InnerHtml = Cast + " Category";
        DataSet ds = new DataSet();
        //ds = Gen.getReleaseProceedingsStep2DIPC(Cast, Investmentid, GoAllotedAmount);   // Gen.getReleaseProceedingsStep2dipc(Cast, Investmentid, GoAllotedAmount, SubIncType, Sectorname);
        ds = Gen.getReleaseProceedingsStep2DIPC(Cast, Investmentid, GoAllotedAmount, locDate);  //nikhil
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            dt2 = ds.Tables[0];
            string incentivename = ds.Tables[0].Rows[0][3].ToString();

            foreach (DataRow row in dt1.Rows)
            {
                row["IncentiveName"] = incentivename;
            }
            dt1.AcceptChanges();

            if (chkIsSpecialUnit.Checked == false) //changed 29.10.2018 - Added line
                dt1.Merge(dt2, true, MissingSchemaAction.Ignore);

            tdinvestments.InnerHtml = "--> " + ds.Tables[0].Rows[0]["IncentiveName"].ToString();
            grdDetails.DataSource = dt1;
            grdDetails.DataBind();

            lblremaingAmount.Text = ds.Tables[1].Rows[0]["RemainingAmount"].ToString();

            dt1.Clear();
            dt2.Clear();
            tblmain.Visible = true;
            tblspecialcasesSearch.Visible = false;
            tblselectedcases.Visible = true;
            trRemainingAmount2.Visible = false;

            chkIsSpecialUnit.Enabled = false;
            //11 
            foreach (GridViewRow row in GridView1.Rows)
            {
                row.FindControl("anchortaglinkDelete").Visible = false;
            }
            btnNext.Visible = false;
            trsearchresult.Visible = false;
            tr1.Visible = false;
        }
        else if (chkIsSpecialUnit.Checked == true)
        {
            // dt2 = ds.Tables[0];
            // string incentivename = ds.Tables[0].Rows[0][3].ToString();
            string incentivename = "";
            ds = GetIncentiveNamebyId(Request.QueryString[1].ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                incentivename = ds.Tables[0].Rows[0]["IncentiveName"].ToString();

            }
            foreach (DataRow row in dt1.Rows)
            {
                row["IncentiveName"] = incentivename;
            }
            dt1.AcceptChanges();

            // dt1.Merge(dt2, true, MissingSchemaAction.Ignore);

            tdinvestments.InnerHtml = "--> " + ds.Tables[0].Rows[0]["IncentiveName"].ToString();
            grdDetails.DataSource = dt1;
            grdDetails.DataBind();

            lblremaingAmount.Text = lblremaingAmount2.Text;

            dt1.Clear();
            //  dt2.Clear();
            tblmain.Visible = true;
            tblspecialcasesSearch.Visible = false;
            tblselectedcases.Visible = true;
            trRemainingAmount2.Visible = false;

            chkIsSpecialUnit.Enabled = false;
            //11 
            foreach (GridViewRow row in GridView1.Rows)
            {
                row.FindControl("anchortaglinkDelete").Visible = false;
            }
            btnNext.Visible = false;
            trsearchresult.Visible = false;
            tr1.Visible = false;

        }
    }

    public DataSet GetIncentiveNamebyId(string IncentiveID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_IncentiveName_by_ID", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = IncentiveID;
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





    protected void ddlDist_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDIPCDtae(ddlSLCNo);
    }

    public DataSet GetIncentivesDIPCdateList(string caste, string IncentiveTypID, string distid)
    {


        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_Incentives_DIPCdate_LIST", con.GetConnection);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@caste", SqlDbType.VarChar).Value = caste;
            da.SelectCommand.Parameters.Add("@IncentiveTypID", SqlDbType.VarChar).Value = @IncentiveTypID;
            da.SelectCommand.Parameters.Add("@distid", SqlDbType.VarChar).Value = distid;
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

    public DataSet GetIncentives_Release_Proceedings_UnitName_searchDIPC(String dipcdate, String Dist, String UnitName, String Investmentid, String Cast)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[USP_GetIncentives_Release_Proceedings_UnitName_searchDIPC]", con.GetConnection);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@dipcdate", SqlDbType.VarChar).Value = dipcdate;
            da.SelectCommand.Parameters.Add("@Distid", SqlDbType.VarChar).Value = Dist;
            da.SelectCommand.Parameters.Add("@UnitName", SqlDbType.VarChar).Value = UnitName;
            da.SelectCommand.Parameters.Add("@Incentivetype", SqlDbType.VarChar).Value = Investmentid;
            da.SelectCommand.Parameters.Add("@Cast", SqlDbType.VarChar).Value = Cast;

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

    //public static String DMYToMDY(String input)
    //{
    //    return Regex.Replace(input,
    //    @"\b(?<day>\d{1,2})/(?<month>\d{1,2})/(?<year>\d{2,4})\b",
    //    "${month}/${day}/${year}");
    //}


}