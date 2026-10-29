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
//designing and developed by suresh as on 12-1-2016
//Purpose : To Add TST Details
//Tables used : td_TstTeamDet
//Stored procedures Used : sp_getStates,sp_getCounties,sp_getPayams,getTSTbyID,deleteTST,insrtTST,sp_Designations


public partial class CheckPOITD : System.Web.UI.Page
{
    #region OTP Chars  //variables for OTP -> Nikhil.

    char[] charArr = "0123456789".ToCharArray();
    string strOTPMobile = string.Empty;
    string strOTPMail = string.Empty;
    string finalOTPMail = "";
    string finalOTPMobile = "";
    Random oRandom = new Random();
    int noOfChar = 6;

    #endregion
    General Gen = new General();
    byte[] Photo = new byte[1];
    string PhotoFileName = "";
    comFunctions cmf = new comFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                //Button1.Visible = false; //added on 25.09.19 otp not working
                txtname2.Enabled = true;
                //OTPTR.Visible = false;

                OTPTR.Visible = true;
                Button1.Visible = true;


                ViewState["captcha"] = "";
                //FillCapctha();
                txtadhar1.Attributes.Add("onKeyPress", "javascript:return ValidateNumberWithoutSpaceAdhar(event);");
                txtadhar2.Attributes.Add("onKeyPress", "javascript:return ValidateNumberWithoutSpaceAdhar(event);");
                txtadhar3.Attributes.Add("onKeyPress", "javascript:return ValidateNumberWithoutSpaceAdhar(event);");

                txtadhar1.Attributes.Add("onKeyUp", "javascript:return Adharcontrol(event,this,'" + txtadhar1.ClientID + "','" + txtadhar2.ClientID + "','" + txtadhar3.ClientID + "');");
                txtadhar2.Attributes.Add("onKeyUp", "javascript:return Adharcontrol(event,this,'" + txtadhar1.ClientID + "','" + txtadhar2.ClientID + "','" + txtadhar3.ClientID + "');");

                txtname2.Attributes.Add("onKeyPress", "javascript:return AlphanumericOnlyJs(event);");
                txtcontact.Attributes.Add("onKeyPress", "javascript:return inputOnlyNumbers(event);");
                BtnSave1.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    //void FillCapctha()
    //{
    //    try
    //    {
    //        ViewState["captcha"] = "";

    //        Random random = new Random();
    //        string combination = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghjkmnpqrstuvwxyz";
    //        StringBuilder captcha = new StringBuilder();

    //        for (int i = 0; i < 6; i++)
    //            captcha.Append(combination[random.Next(combination.Length)]);
    //        ViewState["captcha"] = captcha.ToString();
    //        imgCaptcha.ImageUrl = "CaptchaHandler.ashx?query=" + captcha.ToString();
    //    }
    //    catch (Exception ex)
    //    {
    //        lblmsg0.Text = "Internal error has occured. Please try after some time";
    //        lblmsg0.Text = ex.Message;
    //        Failure.Visible = true;
    //    }
    //}

    //protected void btnRefresh_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        txtCaptcha.Text = "";
    //        FillCapctha();
    //    }
    //    catch (Exception ex)
    //    {
    //        //lblmsg0.Text = "Internal error has occured. Please try after some time";
    //        lblmsg0.Text = ex.Message;
    //        Failure.Visible = true;
    //    }
    ////}
    //protected void getdistricts()
    //{
    //    DataSet dsnew = new DataSet();

    //    dsnew = Gen.GetDistricts();
    //    ddlministry.DataSource = dsnew.Tables[0];
    //    ddlministry.DataTextField = "District_Name";
    //    ddlministry.DataValueField = "District_Id";
    //    ddlministry.DataBind();
    //    ddlministry.Items.Insert(0, "--Select--");
    //}

    //void UploadImage()
    //{

    //    //PhotoFilename = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
    //    Session["PhotoFileName"] = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);

    //    try
    //    {
    //        string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
    //        int letterI = fileType.Length;
    //        //Photo = new byte[FileUpload1.PostedFile.ContentLength];

    //        //    Session["Photo"] = new byte[FileUpload1.PostedFile.ContentLength];

    //        if (
    //            fileType[letterI - 1].ToUpper().Trim() == "PNG" ||
    //            fileType[letterI - 1].ToUpper().Trim() == "JPG" ||
    //            fileType[letterI - 1].ToUpper().Trim() == "GIF" ||
    //            fileType[letterI - 1].ToUpper().Trim() == "JPEG")
    //        {
    //            //Photo = new byte[FileUpload1.PostedFile.ContentLength];

    //            Session["Photo"] = new byte[FileUpload1.PostedFile.ContentLength];
    //            HttpPostedFile Image = FileUpload1.PostedFile;
    //            //Image.InputStream.Read(Photo, 0, (int)FileUpload1.PostedFile.ContentLength);
    //            //lblFileName.Text = PhotoFilename;
    //            //  ObjectToByteArray(Session["Photo"]);
    //            Image.InputStream.Read((byte[])Session["Photo"], 0, (int)FileUpload1.PostedFile.ContentLength);
    //            lblFileName.Text = Session["PhotoFileName"].ToString();

    //            //   Session["Photo"] = Photo;
    //            //   Session["PhotoFileName"] = PhotoFilename;

    //            Image1.ImageUrl = "ScanImage.aspx";



    //        }
    //        else
    //        {
    //            lblmsg.Text = "Image format should be JPG or JPEG or GIF or PNG";

    //        }

    //    }
    //    catch (Exception ex)
    //    {

    //        lblmsg.Text = "An Error Occured. Please Try Again!" + ex.Message;

    //    }

    //    finally
    //    {

    //    }


    //    FileUpload1.Focus();

    //}
    //void FillDetails()
    //{
    //    hdfFlagID.Value = "1";
    //    DataSet ds = new DataSet();


    //    ds = Gen.getTSTbyID(hdfID.Value.ToString());

    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        ddlministry.SelectedValue = ddlministry.Items.FindByValue(ds.Tables[0].Rows[0]["Ministry"].ToString()).Value;
    //        txtname.Text = ds.Tables[0].Rows[0]["TstName"].ToString();
    //        ddlstate.SelectedValue = ddlstate.Items.FindByValue(ds.Tables[0].Rows[0]["intStateid"].ToString()).Value;
    //        getcounties();
    //        ddlCounties.SelectedValue = ddlCounties.Items.FindByValue(ds.Tables[0].Rows[0]["intCountieid"].ToString()).Value;
    //        getPayams();
    //        ddlpayams.SelectedValue = ddlpayams.Items.FindByValue(ds.Tables[0].Rows[0]["intPayamid"].ToString()).Value;
    //        txtaddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
    //        txtemail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
    //        txtcontact.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();

    //        ddltype.SelectedValue = ds.Tables[0].Rows[0]["Type"].ToString();
    //        Gen.Getdesignations(ddldesignation, ddltype.SelectedValue);
    //        if (ds.Tables[0].Rows[0]["intDesgid"].ToString()!="")
    //        ddldesignation.SelectedValue = ddldesignation.Items.FindByValue(ds.Tables[0].Rows[0]["intDesgid"].ToString()).Value;
    //        ddlstatus.SelectedValue = ddlstate.Items.FindByValue(ds.Tables[0].Rows[0]["Status"].ToString()).Value;

    //        txtuser.Text = ds.Tables[1].Rows[0]["User_id"].ToString();
    //        txtuser.Enabled = false;
    //        txtpass.Enabled = false;
    //        txtpass.TextMode = TextBoxMode.SingleLine;
    //        txtpass.Text = "*****"; //ds.Tables[2].Rows[0]["Password"].ToString();

    //        if (ds.Tables[2].Rows.Count > 0)
    //        {
    //            if (ds.Tables[2].Rows[0]["PhotoFileName"].ToString() != "" && ds.Tables[2].Rows[0]["PhotoFileName"] != null)
    //            {
    //                lblFileName.Text = ds.Tables[2].Rows[0]["PhotoFileName"].ToString();

    //                Image1.ImageUrl = "viewAttachemnt.aspx?id=" + Convert.ToString(hdfID.Value.ToString()).Trim() + "&Type=TST Photo";


    //                if (ds.Tables[2].Rows[0]["Photo"].ToString().Trim() != "")
    //                {
    //                    Photo = (byte[])ds.Tables[2].Rows[0]["Photo"];
    //                    Session["Photo"] = Photo;
    //                    Session["PhotoFileName"] = ds.Tables[2].Rows[0]["PhotoFileName"].ToString();
    //                }

    //            }
    //            else
    //            {
    //                lblFileName.Text = "";
    //            }
    //        }

    //    }
    //}    
    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            success.Visible = false;
            lblmsg.Text = "";
            //if (txtOTPVerify.Enabled == false && txtOTPVerify.Text.Trim() == "")
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Verify Your mobile No !!.');", true);
            //    return;
            //}
            //if (imgid.Visible == false)
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter valid OTP received on your mobile no !!.');", true);
            //    return;
            //}
            //if (ViewState["captcha"].ToString() != txtCaptcha.Text.Trim().TrimStart())
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid Captcha Code !!.');", true);
            //    FillCapctha();
            //    txtCaptcha.Text = "";
            //    return;
            //}
            if (txtemail.Text.ToString() != "" && txtcontact.Text.ToString() != "")
            {
                string Text = Gen.checkMobile(txtcontact.Text.ToString(), txtemail.Text.ToString());
                if (Text == "1")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Email id or Mobile No already exists!!. Pl re- enter a new Email id and Mobile no');", true);
                    txtemail.Text = "";
                    txtcontact.Text = "";
                }
            }
            if (ValidatePassword(txtname2.Text.Trim()))
            {

                lblmsg0.Text = "User name should not contain special character";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            if (txtcontact.Text.Contains("-"))
            {
                txtcontact.Text = "";
                //lblmsg0.Text = "<font color=red> User ID already Exists, Please specify another User ID </font>";

                success.Visible = false;
                Failure.Visible = true;

                return;
            }

            DataSet dsUser = new DataSet();
            dsUser = Gen.CheckUserid1(txtname2.Text.Trim());
            if (dsUser.Tables[0].Rows.Count > 0)
            {
                txtname2.Text = "";
                lblmsg0.Text = "<font color=red> User ID already Exists, Please specify another User ID </font>";

                success.Visible = false;
                Failure.Visible = true;

                return;
            }
            UserRegistrationVo userregistrationvoobj = new UserRegistrationVo();
            try
            {
                // OTPGenerationMail();
            }
            catch (Exception ex)
            {

            }
            string AdharCardno = "";
            if (txtadhar1.Text.Trim() != "" && txtadhar2.Text.Trim() != "" && txtadhar3.Text.Trim() != "")
            {
                AdharCardno = txtadhar1.Text.Trim() + txtadhar2.Text.Trim() + txtadhar3.Text.Trim();
            }
            string password = "";
            password = Gen.Encrypt("TSIPASS123", "SYSTIME");
            userregistrationvoobj.Firstname = txtfirstname.Text;
            userregistrationvoobj.Lastname = txtLastname.Text;
            userregistrationvoobj.Email = txtemail.Text;
            userregistrationvoobj.Address = txtaddress.Text;
            //  userregistrationvoobj.Location = ddlministry.SelectedValue.ToString();
            userregistrationvoobj.PANcardno = txtcontact0.Text;
            userregistrationvoobj.MobileNo = txtcontact.Text;
            userregistrationvoobj.username = txtname2.Text;
            userregistrationvoobj.AadharNo = AdharCardno;
            userregistrationvoobj.Password = password;
            userregistrationvoobj.OTPMail = finalOTPMail;
            userregistrationvoobj.OTPMsg = "";
            userregistrationvoobj.Pwdflag = "Y";

            int i = Gen.addnewuserregistration(userregistrationvoobj);

            if (i != 999)
            {
                string msgs = "Dear " + txtfirstname.Text + " " + txtLastname.Text + "\r\n" + "you are successfully registered." + "\r\n" + "User Id : " + txtname2.Text + "\r\n" + " Password : " + "TSIPASS123" + "\r\n";
                msgs = msgs + "\r\n" + "\r\n" + "Thanks and Regards ," + "\r\n" + "Commissionerate of Industries,TG-iPASS Cell";

                string body = msgs;
                try
                {
                    SendMailAnother(txtemail.Text);
                }
                catch (Exception ex)
                {

                }
                try
                {
                    //cmf.SendSingleSMS(txtcontact.Text, body);
                }
                catch (Exception ex)
                {

                }
                clear();

                //Response.Redirect("FrmHDResultNew.aspx?Msg=Please click on the Verification link which has been sent to your mail id to complete the registration process.");
                General clsGeneral = new General();
                string encpassword = clsGeneral.Encrypt("TSIPASS123", "SYSTIME");
                DataSet ds = clsGeneral.ValidateLoginNew(userregistrationvoobj.username, "TSIPASS123", encpassword);//,Dept
                DataView dv = ds.Tables[0].DefaultView;
                DataSet dsnew = new DataSet();

                dsnew = clsGeneral.UpdateCFOUID();

                if (dv.Table.Rows.Count > 0)
                {
                    Session["uid"] = dv.Table.Rows[0]["intUserid"].ToString();
                    Session["username"] = dv.Table.Rows[0]["User_name"].ToString();
                    Session["user_id"] = dv.Table.Rows[0]["User_id"].ToString();
                    Session["password"] = dv.Table.Rows[0]["password"].ToString();
                    Session["userlevel"] = dv.Table.Rows[0]["User_level"].ToString();
                    Session["user_type"] = dv.Table.Rows[0]["User_type"].ToString();
                    Session["Type"] = dv.Table.Rows[0]["Fromname"].ToString();
                    Session["MobileNumber"] = dv.Table.Rows[0]["MobileNumber"].ToString();
                    Session["Email"] = dv.Table.Rows[0]["EmailE"].ToString();

                    Session["DistrictID"] = dv.Table.Rows[0]["DistrictID"].ToString();
                    Session["User_Code"] = dv.Table.Rows[0]["User_code"].ToString();
                    Session["Visibleflag"] = dv.Table.Rows[0]["Visibleflag"].ToString();
                    Session["DummyLogin"] = dv.Table.Rows[0]["DummyLogin"].ToString();

                    string Defaultpasswordflag = dv.Table.Rows[0]["DefaultPwd"].ToString();
                    if (Session["userlevel"].ToString().Trim() == "20" || Session["userlevel"].ToString().Trim() == "24")
                    {
                        if (Defaultpasswordflag.Trim() == "Y")
                        {
                            Response.Redirect("frmChangePassword.aspx");
                        }
                        Response.Redirect("UI/TSiPASS/Home.aspx");
                    }
                    else
                        if (Defaultpasswordflag.Trim() == "Y")
                    {
                        Response.Redirect("frmChangePassword.aspx");
                    }
                    if (Session["userlevel"].ToString().Trim() == "13")
                    {
                        //Response.Redirect("UI/TSiPASS/Dashboard.aspx");
                        Response.Redirect("HomeDashboard.aspx");
                    }
                    else if (Session["userlevel"].ToString().Trim() == "25")
                    {
                        Response.Redirect("Home.aspx");
                    }
                    else if (Session["userlevel"].ToString().Trim() == "12")
                    {
                        Response.Redirect("frmApprovelDocument.aspx");
                    }
                    else if (Session["userlevel"].ToString().Trim() == "10")
                    {

                        if (Session["uid"].ToString().Trim() == "1030")
                        {

                            Response.Redirect("HomeIndusDashboard.aspx");
                        }
                        else
                        {
                            if ((Convert.ToInt32(Session["User_Code"].ToString()) >= 74 && Convert.ToInt32(Session["User_Code"].ToString()) <= 141) || Session["User_Code"].ToString() == "143" || Session["User_Code"].ToString() == "144" || Session["User_Code"].ToString() == "145" || Session["User_Code"].ToString() == "146" || Session["User_Code"].ToString() == "147" || Session["User_Code"].ToString() == "148" || Session["User_Code"].ToString() == "149" || Session["User_Code"].ToString() == "150")
                            {
                                Response.Redirect("frmIPOIncentiveDashboard.aspx");
                            }
                            else
                            {
                                //Response.Redirect("UI/TSiPASS/frmDepartementDashboardNew.aspx");
                                Response.Redirect("HomeDeptDashboard.aspx");
                            }


                            //Response.Redirect("UI/TSiPASS/frmDepartementDashboardNew.aspx");
                            //  Response.Redirect("UI/TSiPASS/HomeDeptDashboard.aspx");

                        }

                        //Response.Redirect("UI/TSiPASS/frmDepartementDashboardNew.aspx");
                        //Response.Redirect("UI/TSiPASS/HomeDeptDashboard.aspx");

                    }
                    else
                    {
                        if (Session["user_id"].ToString().Trim().ToLower() == "commissioner" || Session["user_id"].ToString().Trim().ToLower() == "kcsbabu" || Session["uid"].ToString() == "3377" || Session["uid"].ToString() == "3378")
                        {
                            Response.Redirect("HomeCommDashboard.aspx");
                        }
                        else if (Session["uid"].ToString().Trim() == "1622")
                        {

                            Response.Redirect("Home.aspx");

                        }
                        else
                        {
                            Response.Redirect("ReportsDashboard.aspx");
                        }
                    }
                }
                //Response.Redirect("");
                lblmsg.Text = "Added Successfully..!";
                success.Visible = true;
                Failure.Visible = false;
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }


        //System.Threading.Thread.Sleep(5000);

        //if (BtnSave1.Text == "Save")
        //{

        //    DataSet dsUser = new DataSet();
        //    dsUser = Gen.CheckUserid(txtuser.Text.Trim());
        //    //
        //    if (dsUser.Tables[0].Rows.Count > 0)
        //    {
        //        lblmsg.Text = "<font color=red> User ID already Exists, Please specify another User ID </font>";
        //        txtuser.Text = "";
        //        txtpass.Text = "";
        //        return;
        //        // txtRetypePassword.Text = "";
        //    }

        //    int i = Gen.insrtTST("0", Session["uid"].ToString(),txtuser.Text.ToString(),txtpass.Text.ToString());
        //    if (i != 999)
        //    {
        //        int j = Gen.InsrtUpdAttachment(i.ToString(), (byte[])(Session["Photo"]), Session["PhotoFileName"].ToString().Trim(), "TST Photo", Session["uid"].ToString());


        //        //string msgs = "Dear " + txtname.Text + "<br><br> you are successfully registered TS-iPass Govenrnment of Telengana Public works Online Management System.<br><br> User Id : " + txtuser.Text + "<br><br> Password : " + txtpass.Text + "<br>";
        //        //msgs = msgs + "<br><br><br>Thanks and Regards ,<br> Commissionerate of Industries,TS-iPASS Cell" ;

        //        //string body = msgs;
        //        SendMailAnother(txtemail.Text);


        //        lblmsg.Text = "Added Successfully..!";
        //        success.Visible = true;
        //        Failure.Visible = false;
        //        //clear();
        //    }
        //    else
        //    {
        //        lblmsg0.Text = "Already Exist. ";
        //        success.Visible = false;
        //        Failure.Visible = true;
        //    }
        //}
        //else
        //{
        //    int i = Gen.insrtTST(hdfID.Value, Session["uid"].ToString(), txtuser.Text.ToString(), txtpass.Text.ToString());

        //    if (i != 999)
        //    {
        //        int j = Gen.InsrtUpdAttachment(hdfID.Value, (byte[])(Session["Photo"]), Session["PhotoFileName"].ToString().Trim(), "TST Photo", Session["uid"].ToString());
        //        lblmsg.Text = "Updated Successfully..!";
        //        success.Visible = true;
        //        Failure.Visible = false;
        //        clear();
        //    }
        //    else
        //    {
        //        lblmsg0.Text = "Already Exist. ";
        //        success.Visible = false;
        //        Failure.Visible = true;
        //        //lblmsg.Text = "Added Successfully..!";
        //    }
        //}
    }

    public bool ValidatePassword(string strpass)
    {
        bool bValid = false;
        // string strnumeric = "0123456789";
        //string strchar = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        //string strSpl = "@#=!$%^&*()";
        string strSpl = "~`^&%(){}[]+=-|<>/?";
        int i;
        //for (i = 0; i < strpass.Length; i++)
        //{
        //    if (strchar.IndexOf((strpass.Substring(i, 1))) > -1)
        //    {
        //        bValid = true;
        //        break;
        //    }
        //}
        //if (bValid == false)
        //{
        //    return bValid;
        //}
        //bValid = false;
        //for (i = 0; i < strpass.Length; i++)
        //{
        //    if (strnumeric.IndexOf((strpass.Substring(i, 1))) > -1)
        //    {
        //        bValid = true;
        //        break;
        //    }
        //}
        //if (bValid == false)
        //{
        //    return bValid;
        //}
        //bValid = false;
        for (i = 0; i < strpass.Length; i++)
        {
            if (strSpl.IndexOf((strpass.Substring(i, 1))) > -1)
            {
                bValid = true;
                break;
            }
        }
        if (bValid == false)
        {
            return bValid;
        }
        return bValid;
    }

    void clear()
    {

        txtfirstname.Text = "";
        txtLastname.Text = "";
        txtemail.Text = "";
        // ddlministry.SelectedIndex = 0;
        txtaddress.Text = "";

        txtcontact.Text = "";
        txtcontact0.Text = "";
        txtname2.Text = "";
        txtpasswordnew.Text = "";
        txtcomparepwd.Text = "";
        // txtAadharno.Text = "";
        txtadhar1.Text = "";
        txtadhar2.Text = "";
        txtadhar3.Text = "";

    }
    //void clear()
    //{
    //    Image1.ImageUrl = "~/Resource/Images/not-available.jpg";
    //    lblFileName.Text = "";
    //    BtnSave1.Text = "Save";
    //    BtnDelete.Visible = false;
    //    txtpass.TextMode = TextBoxMode.Password;
    //    ddlministry.SelectedIndex = 0;
    //    //ddlministry.Items.Insert(0, "--Select--");
    //    txtname.Text = "";
    //    ddlstate.SelectedIndex = 0;


    //    ddlCounties.SelectedIndex = 0;


    //    ddlpayams.SelectedIndex = 0;
    //    txtaddress.Text = "";

    //    txtemail.Text = "";
    //    txtcontact.Text = "";
    //    ddltype.SelectedIndex = 0;

    //    ddldesignation.SelectedIndex = 0;

    //    ddlstatus.SelectedIndex = 0;
    //    txtuser.Text="";
    //    txtpass.Text = "";
    //    txtuser.Enabled = true;
    //    txtpass.Enabled = true;



    //}
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddnewuserRegistration.aspx");
    }

    protected void BtnClear0_Click(object sender, EventArgs e)
    {

        //int i = Gen.deleteTST(hdfID.Value);

        //if (i == 1)
        //{fsc
        //    lblmsg.Text = "Deleted Successfully.";
        //    success.Visible = true;
        //    Failure.Visible = false;
        //    clear();
        //}
        //else if (i == 3)
        //{
        //    lblmsg0.Text = "Not Possible.";
        //    success.Visible = false;
        //    Failure.Visible = true;
        //    clear();
        //}
        //else
        //{
        //    lblmsg0.Text = "Please contact to Administrator.";
        //    success.Visible = false;
        //    Failure.Visible = true;
        //    clear();
        //}

    }
    //protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    getcounties();
    //}
    //void getcounties()
    //{
    //    ddlCounties.Items.Clear();
    //    ddlpayams.Items.Clear();
    //    if (ddlstate.SelectedIndex != 0)
    //    {
    //        Gen.getCounties(ddlCounties, ddlstate.SelectedValue);
    //    }
    //    else
    //    {
    //        ddlCounties.Items.Insert(0, "--Select--");
    //        ddlpayams.Items.Insert(0, "--Select--");

    //    }
    //}
    //protected void ddlCounties_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    getPayams();
    //}
    //void getPayams()
    //{
    //    ddlpayams.Items.Clear();
    //    if (ddlCounties.SelectedIndex != 0)
    //    {
    //        Gen.getPayams(ddlpayams, ddlCounties.SelectedValue);
    //    }
    //    else
    //    {
    //        ddlpayams.Items.Insert(0, "--Select--");
    //    }
    //}
    //protected void ddlState_SelectedIndexChanged1(object sender, EventArgs e)
    //{

    //}
    //protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    Getdesignations();
    //}
    //void Getdesignations()
    //{

    //    if (ddltype.SelectedIndex != 0)
    //    {
    //        Gen.Getdesignations(ddldesignation, ddltype.SelectedValue);
    //    }
    //    else
    //    {
    //        ddldesignation.Items.Insert(0, "--Select--");


    //    }
    //}



    public void SendMailAnother(string anothermail)
    {

        try
        {
            string from = "tsipass.telangana@gmail.com"; //Replace this with your own correct Gmail Address

            string to = anothermail; //Replace this with the Email Address to whom you want to send the mail

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(to);
            //mail.CC.Add("kcsbabu@gmail.com");
            mail.CC.Add("coi.tsipass@gmail.com");
            //mail.CC.Add("support@fruxsoft.com");

            mail.From = new MailAddress(from, ":: TSiPASS ::", System.Text.Encoding.UTF8);

            mail.Subject = "Enterprenuer -Login Credentials -";// + Session["user_id"].ToString()

            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = "Dear " + txtfirstname.Text + " " + txtLastname.Text + "<br><br>  <H2>TSiPASS MIS  - Login Credentials</H2><br> Welcome to TS-iPASS. <br/> Dear <b> NAME: " + txtfirstname.Text + " " + txtLastname.Text + "</b>,<br/> Please use the following credentials to Login. <br><br> USER ID: " + txtname2.Text + "<br> <br> Password :TSIPASS123 <br> <br> URL:  <a href='https://ipass.telangana.gov.in' target='_blank' > TSiPASS </a> <br> <br> Please Login by clicking the above link.<br><br>Regards<br>TSiPASS MIS";
            mail.BodyEncoding = System.Text.Encoding.UTF8;

            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            SmtpClient client = new SmtpClient();
            //Add the Creddentials- use your own email id and password

            // client.Credentials = new System.Net.NetworkCredential(from, "lrefskmlxnoowqtc");// "tsipass@2016");
            // client.Credentials = new System.Net.NetworkCredential(from, "zwcq vlxk gyor lpeg");
            client.Credentials = new System.Net.NetworkCredential(from, "fqeq nive azke giwb");


            client.Port = 587; // Gmail works on this port
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true; //Gmail works on Server Secured Layer
            try
            {
                client.Send(mail);
                //Session.Remove("File");
                //Session.Remove("FileName");
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
            } // end try
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void BtnSave2_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidatePassword(txtname2.Text.Trim()))
            {

                lblmsg0.Text = "User name should not contain special character";
                success.Visible = false;
                Failure.Visible = true;

                return;
            }
            DataSet dsUser = new DataSet();
            dsUser = Gen.CheckUserid1(txtname2.Text.Trim());
            //
            if (dsUser.Tables[0].Rows.Count > 0)
            {
                txtname2.Text = "";
                lblmsg0.Text = "<font color=red> User ID already Exists, Please specify another User ID </font>";

                success.Visible = false;
                Failure.Visible = true;
                //return;
                // txtRetypePassword.Text = "";
            }
            else
            {
                lblmsg.Text = "<font color=green> User ID Available </font>";

                success.Visible = true;
                Failure.Visible = false;
                BtnSave1.Visible = true;
                BtnSave1.Enabled = true;

                // Button1.Visible = true;
                // txtOTPVerify.Visible = true;
                //  txtOTPVerify.Enabled = true;

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    //public void sendOTPMail(string anothermail, string OTP)   //done by nikhil ... 03.04.17
    //{

    //    try
    //    {
    //        string from = "nikhil.tsipass@gmail.com"; //Replace this with your own correct Gmail Address

    //        string to = anothermail; //Replace this with the Email Address to whom you want to send the mail

    //        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
    //        mail.To.Add(to);
    //        //mail.CC.Add("kcsbabu@gmail.com");
    //        // mail.CC.Add("mahendar.ellandula27@gmail.com");
    //        //  mail.CC.Add("kcsbabu@gmail.com");

    //        mail.From = new MailAddress(from, ":: TSiPASS ::", System.Text.Encoding.UTF8);

    //        mail.Subject = "TSIPASS - OTP Verification -";// + Session["user_id"].ToString()

    //        mail.SubjectEncoding = System.Text.Encoding.UTF8;

    //        //mail.Body = "Dear " + txtfirstname.Text + " " + txtLastname.Text + "<br><br>  <H2>TSiPASS MIS  - Login Credentials</H2><br> Welcome to TS-iPASS. <br/> Dear <b> NAME: " + txtfirstname.Text + " " + txtLastname.Text + "</b>,<br/> Please use the following credentials to Login. <br><br> USER ID: " + txtname2.Text + "<br> <br> Password : " + txtpasswordnew.Text + "<br> <br> URL : <a href='http://120.138.9.236/IpassHome.aspx?OTP= " + OTP + "&Uid=" + txtname2.Text + "'> Click here for OTP Verification </a> <br> <br> Please Login by clicking the above link.<br><br>Thanks & Regards<br>Commissionerate of Industries, TS-iPASS Cell, Govt of Telangana, HYD";
    //        mail.Body = "Dear " + txtfirstname.Text + " " + txtLastname.Text + "<br><br>  <H2>TSiPASS MIS  - OTP Verification</H2><br> Welcome to TS-iPASS. <br/> Dear <b> NAME: " + txtfirstname.Text + " " + txtLastname.Text + "</b>,<br> URL : <a href='http://localhost:12850/TSIPASS/IpassHome.aspx?OTP= " + OTP + "&Uid=" + txtname2.Text + "'> Click here for OTP Verification </a> <br> <br> Please Login by clicking the above link.<br><br>Thanks & Regards<br>Commissionerate of Industries, TS-iPASS Cell, Govt of Telangana, HYD";
    //        // mail.Body = "Dear " + txtfirstname.Text + " " + txtLastname.Text + "<br><br>  <H2>TSiPASS MIS  - Login Credentials</H2><br> Welcome to TS-iPASS. <br/> Dear <b> NAME: " + txtfirstname.Text + " " + txtLastname.Text + "</b>,<br/> Please use the following credentials to Login. <br><br> USER ID: " + txtname2.Text + "<br> <br> Password : " + txtpasswordnew.Text + "<br> <br> URL:  <a href='https://ipass.telangana.gov.in' target='_blank' > TSiPASS </a> <br> <br> Please Login by clicking the above link.<br><br>Thanks & Regards<br>Commissionerate of Industries, TS-iPASS Cell, Govt of Telangana, HYD";


    //        mail.BodyEncoding = System.Text.Encoding.UTF8;


    //        mail.IsBodyHtml = true;
    //        mail.Priority = MailPriority.High;

    //        SmtpClient client = new SmtpClient();

    //        client.Credentials = new System.Net.NetworkCredential(from, "qwerty1!");

    //        client.Port = 587; // Gmail works on this port
    //        client.Host = "smtp.gmail.com";
    //        client.EnableSsl = true; //Gmail works on Server Secured Layer
    //        try
    //        {
    //            client.Send(mail);

    //        }
    //        catch (Exception ex)
    //        {
    //            Exception ex2 = ex;
    //            string errorMessage = string.Empty;
    //            while (ex2 != null)
    //            {
    //                errorMessage += ex2.ToString();
    //                ex2 = ex2.InnerException;
    //            }
    //            HttpContext.Current.Response.Write(errorMessage);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        //lblmsg0.Text = "Internal error has occured. Please try after some time";
    //        lblmsg0.Text = ex.Message;
    //        Failure.Visible = true;
    //    }
    //}

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
            mail.Body = "Dear " + txtfirstname.Text + " " + txtLastname.Text + "<br><br>  <H2>TSiPASS MIS  - OTP Verification</H2><br> Welcome to TS-iPASS. <br/> Dear <b> NAME: " + txtfirstname.Text + " " + txtLastname.Text + "</b>,<br> Your otp is " + OTP + " </a> <br> <br> Please enter OTP for verification.<br><br>Thanks & Regards<br>Commissionerate of Industries, TS-iPASS Cell, Govt of Telangana";
            // mail.Body = "Dear " + txtfirstname.Text + " " + txtLastname.Text + "<br><br>  <H2>TSiPASS MIS  - Login Credentials</H2><br> Welcome to TS-iPASS. <br/> Dear <b> NAME: " + txtfirstname.Text + " " + txtLastname.Text + "</b>,<br/> Please use the following credentials to Login. <br><br> USER ID: " + txtname2.Text + "<br> <br> Password : " + txtpasswordnew.Text + "<br> <br> URL:  <a href='https://ipass.telangana.gov.in' target='_blank' > TSiPASS </a> <br> <br> Please Login by clicking the above 

            mail.BodyEncoding = System.Text.Encoding.UTF8;


            mail.IsBodyHtml = false;
            mail.Priority = MailPriority.High;

            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            // NetworkCredential Credentials = new NetworkCredential(from, "tsipass@2016");
            // NetworkCredential Credentials = new NetworkCredential(from, "zwcq vlxk gyor lpeg");
             NetworkCredential Credentials = new NetworkCredential(from, "fqeq nive azke giwb");

            //client.Credentials = new System.Net.NetworkCredential(from, "tsipass@2016");
            client.EnableSsl = true;
            client.Credentials = Credentials;
            // Gmail works on this port
            //client.Send(mail);

            //Gmail works on Server Secured Layer
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

    public void OTPMobile(string email)
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
            string msgMobile = "Dear " + txtfirstname.Text + " " + txtLastname.Text + "\r\n" + "" + "Your OTP is : '" + finalOTPMobile + "'" + "\r\n" + "Please confirm to register";
            msgMobile = msgMobile + "\r\n" + "\r\n" + "Regards ," + "\r\n" + "Commissionerate of Industries," + "\n" + "TS-iPASS Cell.";

            string bodyMobile = msgMobile;
            string resopnse = SendSingleSMSnew(txtcontact.Text, bodyMobile, "1007055554890143840");
            if (resopnse.Contains("402"))
            {
                //HDFmsgOTP.Value = strOTPMobile;
                ViewState["OTP"] = strOTPMobile; Button1.Visible = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('An OTP has been sent to your Mobile Number and email id. Please enter it to verify.');", true);
                txtOTPVerify.Enabled = true;
                
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Failed to send OTP to your Mobile Number. Please try again.');", true);
            }

            // Button1.Text = "Click Here To Register";

            //HDFmsgOTP.Value = strOTPMobile;   //stored otp message value here.
            //Button1.Visible = false;
            //imgid.Visible = true;
            //BtnSave_Click(null, null);
            //OTPGenerationMail(txtemail.Text, strOTPMobile);
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    //public void OTPGenerationMail()  //done by nikhil ... 03.04.17
    //{
    //    try
    //    {
    //        for (int cnt = 0; cnt < noOfChar; cnt++)
    //        {
    //            int OTPNo = oRandom.Next(1, charArr.Length);
    //            if (!strOTPMail.Contains(charArr.GetValue(OTPNo).ToString()))
    //            {
    //                strOTPMail += charArr.GetValue(OTPNo);
    //            }
    //        }
    //        finalOTPMail = strOTPMail;
    //        sendOTPMail(txtemail.Text, finalOTPMail);
    //    }
    //    catch (Exception ex)
    //    {
    //        //lblmsg0.Text = "Internal error has occured. Please try after some time";
    //        lblmsg0.Text = ex.Message;
    //        Failure.Visible = true;
    //    }
    //}

    public void OTPGenerationMail(string email, string otp)  //done by nikhil ... 03.04.17
    {
        try
        {

            sendOTPMail(email, otp);
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        try
        {
            if (txtemail.Text.ToString() != "" && txtcontact.Text.ToString() != "")
            {
                string Text = Gen.checkMobile(txtcontact.Text.ToString(), txtemail.Text.ToString());
                if (Text == "1")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Email id or Mobile No already exists!!. Pl re- enter a new Email id and Mobile no');", true);
                    txtemail.Text = "";
                    txtcontact.Text = "";
                }

                else if (Text == "2")
                {
                    //OTPMobile();
                    OTPMobile(txtcontact.Text.ToString());
                    //An OTP has been sent to your mobile no. Please enter it to verify.
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('An OTP has been sent to your mobile no. Please enter it to verify.');", true);
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('An OTP has been sent to your Mobile Number. Please enter it to verify.');", true);
                   // txtOTPVerify.Enabled = true;
                }

            }
        }
        catch
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error!!. Pl try again.');", true);

        }

    }

    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    txtOTPVerify.Enabled = true;
    //    try
    //    {
    //        OTPMobile();
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('An OTP has been sent to your mobile no. Please enter it to verify.');", true);
    //}


    protected void txtOTPVerify_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtOTPVerify.Text == Convert.ToString(ViewState["OTP"]))// HDFmsgOTP.Value.ToString())
            {
                // BtnSave_Click(sender, e);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('OTP Verification Successful. Please proceed for registration.');", true);
                BtnSave2.Enabled = true;
                Button1.Enabled = false;               
                Button1.Visible = false;

                txtOTPVerify.Enabled = false;
                imgid.Visible = true;
                txtname2.Focus();
                txtfirstname.Enabled = false;
                txtLastname.Enabled = false;
                txtcontact0.Enabled = false;
                txtadhar1.Enabled = false;
                txtadhar2.Enabled = false;
                txtadhar3.Enabled = false;
                txtaddress.Enabled = false;
                txtemail.Enabled = false;
                txtcontact.Enabled = false;
                ViewState.Remove("OTP");
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

    //public string SendSingleSMSnew(String mobileNo, String message)
    //{

    //    //String username = "cgg-tipass";
    //    //String password = "tip@$$@2016";
    //    //String senderid = "TiPASS";

    //    String username = "TSIPASS";
    //    String password = "kcsb@786";
    //    String senderid = "TSIPAS";

    //    HttpWebRequest request;


    //    string responseFromServer = "";
    //    try
    //    {
    //        request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequest");
    //        request.ProtocolVersion = HttpVersion.Version10;
    //        //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
    //        ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
    //        request.Method = "POST";
    //        String smsservicetype = "singlemsg"; //For single message.
    //        String query = "username=" + HttpUtility.UrlEncode(username) +
    //            "&password=" + HttpUtility.UrlEncode(password) +
    //            "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +
    //            "&content=" + HttpUtility.UrlEncode("TS-iPASS:" + message) +
    //            "&mobileno=" + HttpUtility.UrlEncode(mobileNo) +
    //            "&senderid=" + HttpUtility.UrlEncode(senderid);

    //        byte[] byteArray = Encoding.ASCII.GetBytes(query);
    //        request.ContentType = "application/x-www-form-urlencoded";
    //        request.ContentLength = byteArray.Length;
    //        Stream dataStream = request.GetRequestStream();
    //        dataStream.Write(byteArray, 0, byteArray.Length);
    //        dataStream.Close();
    //        WebResponse response = request.GetResponse();
    //        String Status = ((HttpWebResponse)response).StatusDescription;
    //        dataStream = response.GetResponseStream();
    //        StreamReader reader = new StreamReader(dataStream);
    //        responseFromServer = reader.ReadToEnd();
    //        reader.Close();
    //        response.Close();
    //        dataStream.Close();
    //        //  request.KeepAlive = false;
    //    }
    //    catch (Exception ex)
    //    {
    //        //lblmsg0.Text = "Internal error has occured. Please try after some time";
    //        lblmsg0.Text = ex.Message;
    //        Failure.Visible = true;
    //    }
    //    responseFromServer = responseFromServer.Replace("\r\n", string.Empty);
    //    return responseFromServer.Trim();
    //    // return "402,1,0";

    //}

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
				LogErrorFile.LogData("cdac_start");
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequestDLT");
            request.ProtocolVersion = HttpVersion.Version10;
            request.KeepAlive = true;
            request.ServicePoint.ConnectionLimit = 10;
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            String encryptedPassword = encryptedPasswod(password);
	 	    LogErrorFile.LogData("cdac_enc");	

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
		LogErrorFile.LogData("cdac_stream");	
            dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

	    LogErrorFile.LogData("cdac1");

            response = request.GetResponse();
            String status = ((HttpWebResponse)response).StatusDescription;
            dataStream = response.GetResponseStream();
            reader = new StreamReader(dataStream);

            String responseFromServer = reader.ReadToEnd();

	    LogErrorFile.LogData(responseFromServer);

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
}
