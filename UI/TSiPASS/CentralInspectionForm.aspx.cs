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
using System.Net.Mail;
using System.Text;
using System.Net;
using System.Threading;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

public partial class UI_TSiPASS_CentralInspectionForm : System.Web.UI.Page
{

    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    byte[] SelfCert;
    string SelfCertFileName = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            Response.Redirect("../../Index.aspx");
        }

        if (!IsPostBack)
        {

            // ddlDepartment.DataValueField = newds.Tables[0].Rows[0]["Department"].ToString().Trim();

            success.Visible = false;
            Failure.Visible = false;
            GetDepartment();
            getdistricts();

            #region commenting by sridhar

            if (Session["userlevel"].ToString().Trim() == "10")
            {
                ddlDepartment.SelectedValue = ddlDepartment.Items.FindByValue(Session["User_Code"].ToString().Trim()).Value;
                ddlDepartment.Enabled = false;
            }
            else
            {
                Response.Redirect("../../Index.aspx");
            }
            //else
            //{
            //    DataSet newds = new DataSet();
            //    newds = Gen.GetDepartmentForInspection(Session["User_Code"].ToString().Trim());
            //    ddlDepartment.SelectedValue = ddlDepartment.Items.FindByValue(newds.Tables[0].Rows[0]["intDeptid"].ToString().Trim()).Value;
            //    ddlDepartment.Enabled = false;
            //    txtDesignation.Text = newds.Tables[0].Rows[0]["Inspect_Designation"].ToString().Trim();
            //    txtDesignation.Enabled = false;
            //}

            #endregion

        }


    }
    protected void GetDepartment()
    {
        DataSet dsd = new DataSet();

        dsd = Gen.GetDepartmentFullName();
        ddlDepartment.DataSource = dsd.Tables[0];
        ddlDepartment.DataValueField = "Dept_Id";
        ddlDepartment.DataTextField = "Dept_Full_Name";
        ddlDepartment.DataBind();
        ddlDepartment.Items.Insert(0, "--Select--");
    }

    protected void getdistricts()
    {
        DataSet dsnew = new DataSet();

        dsnew = Gen.GetDistricts();
        ddldistrict.DataSource = dsnew.Tables[0];
        ddldistrict.DataTextField = "District_Name";
        ddldistrict.DataValueField = "District_Id";
        ddldistrict.DataBind();
        ddldistrict.Items.Insert(0, "--Select--");
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddldistrict.SelectedIndex == 0)
        {
            ddlMandal.Items.Clear();
            ddlMandal.Items.Insert(0, "--Select--");

        }
        else
        {
            ddlMandal.Items.Clear();
            DataSet dsm = new DataSet();
            dsm = Gen.GetMandals(ddldistrict.SelectedValue);
            if (dsm.Tables[0].Rows.Count > 0)
            {
                ddlMandal.DataSource = dsm.Tables[0];
                ddlMandal.DataValueField = "Mandal_Id";
                ddlMandal.DataTextField = "Manda_lName";
                ddlMandal.DataBind();
                ddlMandal.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlMandal.Items.Clear();
                ddlMandal.Items.Insert(0, "--Select--");
            }
        }
    }
    protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMandal.SelectedIndex == 0)
        {

            ddlVillage.Items.Clear();
            ddlVillage.Items.Insert(0, "--Select--");
        }
        else
        {
            ddlVillage.Items.Clear();
            DataSet dsv = new DataSet();
            dsv = Gen.GetVillages(ddlMandal.SelectedValue);
            if (dsv.Tables[0].Rows.Count > 0)
            {
                ddlVillage.DataSource = dsv.Tables[0];
                ddlVillage.DataValueField = "Village_Id";
                ddlVillage.DataTextField = "Village_Name";
                ddlVillage.DataBind();
                ddlVillage.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlVillage.Items.Clear();
                ddlVillage.Items.Insert(0, "--Select--");
            }


        }
    }

    //protected void ddltypofinspection_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddltypofinspection.SelectedIndex == 4)
    //    {
    //        trOthers.Visible = true;
    //    }
    //    else
    //    {
    //        trOthers.Visible = false;
    //    }
    //}


    protected void BtnClear_Click(object sender, EventArgs e)
    {
        //ddlDepartment.SelectedIndex = 0;
        ddldistrict.SelectedIndex = 0;
        ddlMandal.SelectedIndex = -1;
        ddlVillage.SelectedIndex = -1;
        txtAadhaar.Text = "";
        txtdateofinspection.Text = "";
        txtDesignation.Text = "";
        txtNameofUnit.Text = "";
        txtother.Text = "";
        txtPrmoterEmail.Text = "";
        txtPromotermobile.Text = "";
        txtTypofunit.Text = "";
        txtUID.Text = "";
        txtPromoterName.Text = "";
        txtInspnSub_Name.Text = "";
        txtInspnSubMobileNo.Text = "";
        txtInspnSubEMail.Text = "";
        //Response.Redirect("~/InspectionForm.aspx", false);

    }

    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        try
        {
            if (lblFileLink1.Text == "")
            {
                success.Visible = false;
                Failure.Visible = true;
                lblmsg0.Text = "Please Upload at least one Document";
            }
            else
            {
                int s = Gen.insertCentralInspectionDetails(txtNameofUnit.Text,
                    ddldistrict.SelectedItem.Text,
                    ddlMandal.SelectedItem.Text,
                    ddlVillage.SelectedItem.Text,
                    txtDesignation.Text,
                    txtdateofinspection.Text,
                    txtdateofinspection.Text,
                    HdLink1.Value,
                    ddlDepartment.SelectedItem.Text,
                    ddltypofinspection.SelectedItem.Text,
                    txtdateofinspection.Text,
                    Session["uid"].ToString().Trim(),
                    txtdateofinspection.Text,
                    Session["uid"].ToString().Trim(),
                    txtdateofinspection.Text,
                    ddltypofinspection.SelectedValue,
                    ddlVillage.SelectedItem.Text,
                    HdLink2.Value,
                    HdLink3.Value,
                    HdLink4.Value,
                    
                    txtPromotermobile.Text, txtPrmoterEmail.Text, txtPromoterName.Text, txtInspnSub_Name.Text, txtInspnSubEMail.Text, txtInspnSubMobileNo.Text
                    );
                Session["Applid"] = s.ToString();

                if (s >= 0)
                {
                    if (txtInspnSubMobileNo.Text == txtPromotermobile.Text)
                    {
                        OTPAfterSubmissionApplcnForInspectionOffcr();
                    }
                    else
                    {
                        OTPAfterSubmissionApplcnForInspectionOffcr();
                        OTPAfterSubmissionApplcnForPromoter();
                    }



                    success.Visible = true;
                    Failure.Visible = false;
                    lblmsg.Text = "Inspection Details -  Succesfully Submitted";
                    txtUID.Text = "";
                    txtPromotermobile.Text = "";
                    txtPrmoterEmail.Text = "";
                    txtNameofUnit.Text = "";
                    txtDesignation.Text = "";
                    txtdateofinspection.Text = "";
                    ddlDepartment.SelectedIndex = 0;
                    ddldistrict.SelectedIndex = 0;
                    ddlMandal.SelectedIndex = 0;
                    ddltypofinspection.SelectedIndex = 0;
                    txtTypofunit.Text = "";
                    ddlVillage.SelectedIndex = 0;
                    lblFileLink1.Text = "";
                    lblFileLink2.Text = "";
                    lblFileLink3.Text = "";
                    lblFileLink4.Text = "";
                    txtAadhaar.Text = "";
                    txtother.Text = "";
                    txtother.Visible = false;
                    txtPromoterName.Text = "";
                    txtInspnSub_Name.Text = "";
                    txtInspnSubMobileNo.Text = "";
                    txtInspnSubEMail.Text = "";
                    string message = "alert('Inspection Detils Submitted Successfully')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
                else
                {
                    success.Visible = false;
                    Failure.Visible = true;
                    lblmsg0.Text = "Inspection Details - Submition Failed";
                }
            }

        }

        catch (Exception ex)
        {


        }
        finally
        {
        }
    }

    protected void BtnUpload1_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\Inspection");

        General t1 = new General();
        if ((FileUpload5.PostedFile != null) && (FileUpload5.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload5.PostedFile.FileName);
            try
            {
                string[] fileType = FileUpload5.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    //newPath = System.IO.Path.Combine(sFileDir, sFileDir + "\\" + Session["uid"].ToString().Trim() + "_" + DateTime.Now.ToString("ddMMMyyyyhhmmss"));
                    newPath = sFileDir + "\\" + Session["uid"].ToString().Trim() + "_" + DateTime.Now.ToString("ddMMMyyyyhhmmss");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))
                        System.IO.Directory.CreateDirectory(newPath);
                    try
                    {
                        FileUpload5.PostedFile.SaveAs(newPath + "\\" + sFileName);

                        lblfileUpload1.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lblFileLink1.Text = FileUpload5.FileName;
                        success.Visible = true;
                        Failure.Visible = false;

                        string str = newPath.Replace(Server.MapPath(""), "https://ipass.telangana.gov.in");
                        HdLink1.Value = newPath + "\\" + sFileName;
                    }
                    catch
                    {
                        lblfileUpload1.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }

                }
                else
                {
                    lblfileUpload1.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                }
            }
            catch (Exception)
            {
                DeleteFile(newPath + "\\" + sFileName);
            }
        }
    }
    protected void BtnUpload2_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\Inspection");

        General t1 = new General();
        if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
            try
            {
                string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = sFileDir + "\\" + Session["uid"].ToString().Trim() + "_" + DateTime.Now.ToString("ddMMMyyyyhhmmss");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))
                        System.IO.Directory.CreateDirectory(newPath);
                    try
                    {
                        FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);

                        lblfileUpload2.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lblFileLink2.Text = FileUpload1.FileName;
                        success.Visible = true;
                        Failure.Visible = false;

                        string str = newPath.Replace(Server.MapPath(""), "https://ipass.telangana.gov.in");
                        HdLink2.Value = newPath + "\\" + sFileName;
                    }
                    catch
                    {
                        lblfileUpload2.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }

                }
                else
                {
                    lblfileUpload2.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                }
            }
            catch (Exception)
            {
                DeleteFile(newPath + "\\" + sFileName);
            }
        }
    }
    protected void BtnUpload3_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\Inspection");

        General t1 = new General();
        if ((FileUpload2.PostedFile != null) && (FileUpload2.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload2.PostedFile.FileName);
            try
            {
                string[] fileType = FileUpload2.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = sFileDir + "\\" + Session["uid"].ToString().Trim() + "_" + DateTime.Now.ToString("ddMMMyyyyhhmmss");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))
                        System.IO.Directory.CreateDirectory(newPath);
                    try
                    {
                        FileUpload2.PostedFile.SaveAs(newPath + "\\" + sFileName);

                        lblfileUpload3.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lblFileLink3.Text = FileUpload2.FileName;
                        success.Visible = true;
                        Failure.Visible = false;

                        string str = newPath.Replace(Server.MapPath(""), "https://ipass.telangana.gov.in");
                        HdLink3.Value = newPath + "\\" + sFileName;
                    }
                    catch
                    {
                        lblfileUpload3.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }

                }
                else
                {
                    lblfileUpload3.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                }
            }
            catch (Exception)
            {
                DeleteFile(newPath + "\\" + sFileName);
            }
        }
    }
    protected void BtnUpload4_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\Inspection");

        General t1 = new General();
        if ((FileUpload3.PostedFile != null) && (FileUpload3.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload3.PostedFile.FileName);
            try
            {
                string[] fileType = FileUpload3.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = sFileDir + "\\" + Session["uid"].ToString().Trim() + "_" + DateTime.Now.ToString("ddMMMyyyyhhmmss");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))
                        System.IO.Directory.CreateDirectory(newPath);
                    try
                    {
                        FileUpload3.PostedFile.SaveAs(newPath + "\\" + sFileName);

                        lblfileUpload4.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lblFileLink4.Text = FileUpload3.FileName;
                        success.Visible = true;
                        Failure.Visible = false;

                        string str = newPath.Replace(Server.MapPath(""), "https://ipass.telangana.gov.in");
                        HdLink4.Value = newPath + "\\" + sFileName;
                    }
                    catch
                    {
                        lblfileUpload4.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }

                }
                else
                {
                    lblfileUpload4.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                }
            }
            catch (Exception)
            {
                DeleteFile(newPath + "\\" + sFileName);
            }
        }
    }

    private void DeleteFile(string strFileName)
    {
        if (strFileName.Trim().Length > 0)
        {
            FileInfo fi = new FileInfo(strFileName);
            if (fi.Exists)//if file exists delete it
            {
                fi.Delete();
            }
        }
    }


    #region OTP Generation

    private void OTPAfterSubmissionApplcnForPromoter()
    {
        String Email = "", /*UserID = ""*/ MobileNo = "";
        Email = txtPrmoterEmail.Text;
        MobileNo = txtPromotermobile.Text;


        string msgs = "Dear applecant " + " " + "\r\n" + " your Inspection Details Submitted Successfully." + "\r\n";
        msgs = msgs + "Thanks and Regards," + "\r\n" + "Commissionerate of Industries,TS-iPASS Cell";

        string body = msgs;
        string from = "tsipass.telangana@gmail.com"; //Replace this with your own correct Gmail Address

        string to = Email; //Replace this with the Email Address to whom you want to send the mail

        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(to);
        //mail.CC.Add("kcsbabu@gmail.com");
        //mail.CC.Add("coi.tsipass@gmail.com");
        //mail.CC.Add("support@fruxsoft.com");

        mail.From = new MailAddress(from, ":: TSiPASS ::", System.Text.Encoding.UTF8);

        mail.Subject = "Applicant -Login Credentials -";// + Session["user_id"].ToString()

        mail.SubjectEncoding = System.Text.Encoding.UTF8;  //ds.Tables[0].Rows[0]["Password"].ToString()
        mail.Body = "Dear  applicant " + " " + "<br><br>  <H2>Your Inspection Details Uploaded Successfully </H2> "+ "< br >.< br >< br >  TSiPASS MIS";
            mail.BodyEncoding = System.Text.Encoding.UTF8;

        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;

        SmtpClient client = new SmtpClient();
        //Add the Creddentials- use your own email id and password

       // client.Credentials = new System.Net.NetworkCredential(from, "tsipass@2016");
        client.Credentials = new System.Net.NetworkCredential(from, "zwcq vlxk gyor lpeg");

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
        //SendSingleSMSnew(MobileNo, body);


        lblmsg.Text = "Login Credentials sent to Registerd E-Mail And Registerd Mobile No ";
        Failure.Visible = false;
        success.Visible = true;
        Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "AnotherFunction();", true);
    }

    private void OTPAfterSubmissionApplcnForInspectionOffcr()
    {
        String Email = "", /*UserID = ""*/ MobileNo = "";
        Email = txtInspnSubEMail.Text;
        MobileNo = txtInspnSubMobileNo.Text;

        string msg1 =   " your Login Credentials." + "\r\n" + " User Id : " + Email + "\r\n" + "Password : " + MobileNo + "\r\n";
        string msgs = "Dear  "+ txtNameofUnit.Text + " " + "\r\n"+" Inspection Details Submitted Successfully." + "\r\n";
          msgs = msgs + msg1+ "Thanks and Regards," + "\r\n" + "Commissionerate of Industries,TS-iPASS Cell";

            string body = msgs;
            string from = "tsipass.telangana@gmail.com"; //Replace this with your own correct Gmail Address

            string to = Email; //Replace this with the Email Address to whom you want to send the mail

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(to);
            //mail.CC.Add("kcsbabu@gmail.com");
            //mail.CC.Add("coi.tsipass@gmail.com");
            //mail.CC.Add("support@fruxsoft.com");

            mail.From = new MailAddress(from, ":: TSiPASS ::", System.Text.Encoding.UTF8);

            mail.Subject = "Login Credentials -";// + Session["user_id"].ToString()

            mail.SubjectEncoding = System.Text.Encoding.UTF8;  //ds.Tables[0].Rows[0]["Password"].ToString()
        mail.Body = "Dear  Officer " + msgs+ " " + "<br><br> <H2>TSiPASS MIS  - Login Credentials</H2><br> Welcome to TS-iPASS. <br/> Dear <b> " + " " + "</b>,<br/> Please use the following credentials to Login. <br><br> UserId: " + Email + "<br> <br> Password : " + MobileNo + "<br> <br> URL:  <a href='http://industries.telangana.gov.in' target='_blank' > TSiPASS </a> <br> <br> Please Login by clicking the above link.<br><br>Regards<br>TSiPASS MIS";
        
        mail.BodyEncoding = System.Text.Encoding.UTF8;

            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            SmtpClient client = new SmtpClient();
            //Add the Creddentials- use your own email id and password

            //client.Credentials = new System.Net.NetworkCredential(from, "tsipass@2016");
            client.Credentials = new System.Net.NetworkCredential(from, "zwcq vlxk gyor lpeg");
        

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
            //SendSingleSMSnew(MobileNo, body);


            lblmsg.Text = "Login Credentials sent to Registerd E-Mail And Registerd Mobile No ";
            Failure.Visible = false;
            success.Visible = true;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "AnotherFunction();", true);
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






    #endregion



    protected void sameasAbove_CheckedChanged(object sender, EventArgs e)
    {

        if (sameasAbove.Checked == true)
        {
            txtInspnSubEMail.Text = txtPrmoterEmail.Text;
            txtInspnSubMobileNo.Text = txtPromotermobile.Text;
            txtInspnSub_Name.Text = txtPromoterName.Text;
        }
        else
        {
            txtInspnSubEMail.Text = "";
            txtInspnSubMobileNo.Text = "";
            txtInspnSub_Name.Text = "";
        }
    }
}