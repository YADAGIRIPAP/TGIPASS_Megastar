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

public partial class UI_TSiPASS_frmIndustryLoan : System.Web.UI.Page
{
    string test1;
    General Gen = new General();
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
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
        if (Session["uid"] != null)
        {

        }
        else
        {
            Response.Redirect("~/tshome.aspx");
        }
        if (!IsPostBack)
        {
            string test = "0";

            BindBankNames();
            BindDistricts();
            Bindtypeofloans();
            rbtTSIPASS_SelectedIndexChanged(sender, e);
        }
        txtadhar1.Attributes.Add("onKeyPress", "javascript:return ValidateNumberWithoutSpaceAdhar(event);");
        txtadhar2.Attributes.Add("onKeyPress", "javascript:return ValidateNumberWithoutSpaceAdhar(event);");
        txtadhar3.Attributes.Add("onKeyPress", "javascript:return ValidateNumberWithoutSpaceAdhar(event);");
        txtcontact.Attributes.Add("onKeyPress", "javascript:return inputOnlyNumbers(event);");
        txtLoanAmount.Attributes.Add("onKeyPress", "javascript:return inputOnlyNumbers(event);");
    }
    public void BindDistricts()
    {
        try
        {
            General gen = new General();
            DataSet dsd = new DataSet();
            ddl_disticts.Items.Clear();
            dsd = gen.GetDistrictsWithoutHYD();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddl_disticts.DataSource = dsd.Tables[0];
                ddl_disticts.DataValueField = "District_Id";
                ddl_disticts.DataTextField = "District_Name";
                ddl_disticts.DataBind();
                ddl_disticts.Items.Insert(0, "--SELECT--");
            }
            else
            {
                ddl_disticts.Items.Insert(0, "--SELECT--");
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            //LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["testUID"].ToString());
        }
    }

    public void Bindtypeofloans()
    {
        try
        {
            General gen = new General();
            DataSet dsd = new DataSet();
            ddl_disticts.Items.Clear();
            dsd = GetTypeofLoans();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddltypeofloan.DataSource = dsd.Tables[0];
                ddltypeofloan.DataValueField = "Loan_Id";
                ddltypeofloan.DataTextField = "Loan_Name";
                ddltypeofloan.DataBind();
                ddltypeofloan.Items.Insert(0, "--SELECT--");
            }
            else
            {
                ddltypeofloan.Items.Insert(0, "--SELECT--");
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            //LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["testUID"].ToString());
        }
    }
    public void BindBankNames()
    {
        try
        {
            General gen = new General();
            DataSet dsd = new DataSet();
            ddl_banknames.Items.Clear();
            dsd = gen.GetBridgeBankDetails();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {

                ddl_banknames.DataSource = dsd.Tables[0];
                ddl_banknames.DataValueField = "BANKID";
                ddl_banknames.DataTextField = "BANKNAME";
                ddl_banknames.DataBind();
                ddl_banknames.Items.Insert(0, "--SELECT--");
            }
            else
            {
                ddl_banknames.Items.Insert(0, "--SELECT--");
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }
    public void Bindbranchname()
    {
        try
        {
            if (ddl_disticts.SelectedIndex == 0)
            {

                ddl_branchnames.Items.Clear();
                // ddlVillageunit.Items.Insert(0, "--Village--");
                AddSelect(ddl_branchnames);
            }
            else
            {
                ddl_branchnames.Items.Clear();
                DataSet dsv = new DataSet();
                dsv = Gen.GetBranchesByBankDistrictId(ddl_disticts.SelectedValue, ddl_banknames.SelectedValue);
                if (dsv.Tables[0].Rows.Count > 0)
                {
                    ddl_branchnames.DataSource = dsv.Tables[0];
                    ddl_branchnames.DataValueField = "IFSCCODE";
                    ddl_branchnames.DataTextField = "BranchName";
                    ddl_branchnames.DataBind();
                    AddSelect(ddl_branchnames);
                    //  ddlVillageunit.Items.Insert(0, "--Village--");
                }
                else
                {
                    ddl_branchnames.Items.Clear();
                    // ddlVillageunit.Items.Insert(0, "--Village--");
                    AddSelect(ddl_branchnames);
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }

    protected void rbtTSIPASS_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearAllControls();
        BindDistricts();
        BindBankNames();
        Bindbranchname();

        success.Visible = false;
        Failure.Visible = false;
        if (rbtTSIPASS.SelectedValue == "1")
        {
            tbl.Visible = true;
            // rbtTSIPASS.Enabled = false;
        }
        else
        {
            tbl.Visible = false;
        }
    }

    protected void ddl_banknames_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Bindbranchname(ddl_banknames.SelectedValue.ToString().ToUpper());
        if (ddl_banknames.SelectedIndex == 0)
        {
            ddl_banknames.Items.Clear();
            // ddlUnitMandal.Items.Insert(0, "--Mandal--");
            AddSelect(ddl_disticts);
        }
        else
        {
            ddl_disticts.Items.Clear();
            DataSet dsm = new DataSet();


            dsm = Gen.GetBankIdByDistricts(ddl_banknames.SelectedValue);
            if (dsm.Tables[0].Rows.Count > 0)
            {
                ddl_disticts.DataSource = dsm.Tables[0];
                ddl_disticts.DataValueField = "DistrictId";
                ddl_disticts.DataTextField = "DistrictName";
                ddl_disticts.DataBind();
                // ddlUnitMandal.Items.Insert(0, "--Mandal--");
                AddSelect(ddl_disticts);
            }
            else
            {
                ddl_disticts.Items.Clear();
                //ddlUnitMandal.Items.Insert(0, "--Mandal--");
                AddSelect(ddl_disticts);
            }
        }
    }

    public string ValidateControl()
    {
        int slno = 1;
        string ErrorMsg = "";

        if (txtEntrepreneur.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Name of the Entrepreneur\\n";
            slno = slno + 1;
        }

        //if (txt_Name_of_unit.Text.TrimStart().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Name of the Unit.\\n";
        //    slno = slno + 1;
        //}

        if (txtadhar1.Text.TrimStart().Trim() == "" || txtadhar2.Text.TrimStart().Trim() == "" || txtadhar3.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Aadhaar Number\\n";
            slno = slno + 1;
        }

        if (txtcontact.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Mobile Number\\n";
            slno = slno + 1;
        }

        if (ddltypeofloan.SelectedValue == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Type of Loan\\n";
            slno = slno + 1;
        }

        if (ddl_banknames.SelectedValue == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Bank Name \\n";
            slno = slno + 1;
        }

        if (ddl_branchnames.SelectedValue == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Branch Name \\n";
            slno = slno + 1;
        }

        if (ddl_disticts.SelectedValue == "--SELECT--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select District \\n";
            slno = slno + 1;
        }
        if (ddlmandal.SelectedValue == "--SELECT--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Mandal\\n";
            slno = slno + 1;
        }

        if (txtLoanDate.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Loan Application Date \\n";
            slno = slno + 1;
        }
        if (txtLoanAmount.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Loan Amount\\n";
            slno = slno + 1;
        }
        return ErrorMsg;
    }
    protected void BtnSave1_Click(object sender, EventArgs e)
    {

        string errormsg = ValidateControl();
        if (errormsg.Trim().TrimStart() == "")
        {
            string AdharCardno = "";
            if (txtadhar1.Text.Trim() != "" && txtadhar2.Text.Trim() != "" && txtadhar3.Text.Trim() != "")
            {
                AdharCardno = txtadhar1.Text.Trim() + txtadhar2.Text.Trim() + txtadhar3.Text.Trim();
            }

            TSLOANINDUSTRY objloan = new TSLOANINDUSTRY();
            objloan.Name_of_unit = txt_Name_of_unit.Text;
            objloan.aadhar_number = AdharCardno;
            objloan.mobile_numnber = txtcontact.Text;
            objloan.district = ddl_disticts.SelectedValue.ToString();
            objloan.bank_name = ddl_banknames.SelectedValue.ToString();
            objloan.branch_name = ddl_branchnames.SelectedValue.ToString();
            if (txtLoanDate.Text == "" || txtLoanDate.Text == null)
            {
                objloan.loan_application_date = null;
            }
            else
            {
                string[] ConvertedDt11 = txtLoanDate.Text.Split('/');
                objloan.loan_application_date = ConvertedDt11[2].ToString() + "/" + ConvertedDt11[1].ToString() + "/" + ConvertedDt11[0].ToString();
            }
            // objloan.loan_application_date = txtLoanDate.Text;
            objloan.created_by = Session["uid"].ToString();
            objloan.Loan_Amount = txtLoanAmount.Text.Trim();
            objloan.LoanNumber = txtloannumber.Text.Trim();
            objloan.OTP = txtOTPVerify.Text;
            objloan.Name_of_Enterprenur = txtEntrepreneur.Text.Trim();
            objloan.Mandal = ddlmandal.SelectedValue.ToString();
            General gen = new General();
            int i = gen.InsertLoanDetails(objloan);
            if (i == 1)
            {
                success.Visible = true;
                Failure.Visible = false;
                lblmsg.Text = "DETAILS SAVED SUCESSFULLY!";
                BtnSave1.Enabled = false;
            }
            else
            {
                Failure.Visible = true;
                success.Visible = false;
                lblmsg0.Text = "DETAILS ARE ALREADY UPDATED!";
            }

        }
        else
        {
            Failure.Visible = true;
            lblmsg0.Visible = true;
            lblmsg0.Text = errormsg;

        }
    }
    public void ClearAllControls()
    {
        txt_Name_of_unit.Text = "";
        txtadhar1.Text = "";
        txtadhar2.Text = "";
        txtadhar3.Text = "";
        txtcontact.Text = "";
        txtLoanDate.Text = "";

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

    protected void txtOTPVerify_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtOTPVerify.Text == HDFmsgOTP.Value.ToString())
            {
                // BtnSave_Click(sender, e);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('OTP Verification Successful. Please proceed.');", true);
                BtnSave1.Enabled = true;
                Button1.Enabled = false;
                // BtnSave1.Enabled = true;
                // BtnSave1.Visible = false;
                Button1.Visible = false;

                txtOTPVerify.Enabled = false;
                imgid.Visible = true;
                txtcontact.Enabled = false;
                //txtname2.Focus();
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter valid OTP received on your mobile no !!.');", true);
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }

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

    protected void Button1_Click(object sender, EventArgs e)
    {
        txtOTPVerify.Enabled = true;

        try
        {
            if (txtcontact.Text.ToString() != "")
            {
                if (txtcontact.Text.Length == 10)
                {
                    OTPMobile();
                    //An OTP has been sent to your mobile no. Please enter it to verify.
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('An OTP has been sent to your mobile no. Please enter it to verify.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Email id or Mobile No already exists!!. Pl re- enter a new Email id and Mobile no');", true);
                    txtcontact.Text = "";
                }

            }
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
            string msgMobile = "Dear " + txtEntrepreneur.Text + " " + "\r\n" + "" + "Your OTP is : '" + finalOTPMobile + "'" + "\r\n" + "Please confirm";
            msgMobile = msgMobile + "\r\n" + "\r\n" + "Regards ," + "\r\n" + "Commissionerate of Industries," + "\n" + "TS-iPASS Cell.";

            string bodyMobile = msgMobile;
            //SendSingleSMSnew(txtcontact.Text, bodyMobile);
            // Button1.Text = "Click Here To Register";
            HDFmsgOTP.Value = strOTPMobile;   //stored otp message value here.
            //Button1.Visible = false;
            //imgid.Visible = true;
            //BtnSave_Click(null, null);
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
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
    protected void BtnClear_Click(object sender, EventArgs e)
    {

    }

    protected void ddl_disticts_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (ddl_disticts.SelectedIndex == 0)
            {
                ddlmandal.Items.Clear();
                ddlmandal.Items.Insert(0, "--Mandal--");
            }
            else
            {

                ddlmandal.Items.Clear();
                DataSet dsm = new DataSet();
                dsm = Gen.GetMandals(ddl_disticts.SelectedValue);
                if (dsm.Tables[0].Rows.Count > 0)
                {
                    ddlmandal.DataSource = dsm.Tables[0];
                    ddlmandal.DataValueField = "Mandal_Id";
                    ddlmandal.DataTextField = "Manda_lName";
                    ddlmandal.DataBind();
                    ddlmandal.Items.Insert(0, "--Mandal--");
                }
                else
                {
                    ddlmandal.Items.Clear();
                    ddlmandal.Items.Insert(0, "--Mandal--");
                }
                Bindbranchname();
            }

        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    public void AddSelect(DropDownList ddl)
    {
        try
        {
            ListItem li = new ListItem();
            li.Text = "--Select--";
            li.Value = "0";
            ddl.Items.Insert(0, li);
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }

    public DataSet GetTypeofLoans()
    {
        SqlDataAdapter da;
        osqlConnection.Open();
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_TYPEOFLOAN", osqlConnection);
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
            osqlConnection.Close();
        }
    }
}