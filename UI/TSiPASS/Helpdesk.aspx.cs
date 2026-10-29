
//************************** This interface is created by Ravi for helpdesk ******************************
// ***********************************  Date  :  14-05-2012  *********************************
/// Software Engineer: R.Ravichandra
/// Created By R.Ravi Chandra on 14-05-2012 at 12.20PM For Inserting Help Desk -, StoredProcedure name:sp_Instfeedback.
/// 
/// 
/// 



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
using System.Xml.Linq;
using System.Web.Configuration;
using System.Threading;
using System.ComponentModel;
using System.Text;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
//using System.Runtime.InteropServices;


public partial class Helpdesk : System.Web.UI.Page
{
    #region Declaration
    General clsGeneral = new General();
    comFunctions fssFunctions = new comFunctions();
    General cmn = new General();
    /// <summary>
    ///Begin  Created By Ravi Chandra on 14-05-2012 at 12.20PM For Help Desk Declaration 
    /// </summary>
    string mobPIA = String.Empty;
    /// <summary>
    ///End  Created By Ravi Chandra on 14-05-2012 at 12.20PM For Help Desk Declaration
    /// </summary>
    string piaid = String.Empty;
    string trCode = String.Empty;
    string mppia = String.Empty;
    DataSet ds;
    byte[] scanUpload = new byte[36871];
    //string scanUploadFileName = "";
    byte[] letterUpload = new byte[36871];
    //string letterUploadFileName = "";



    /// <summary>
    /// Creaeted By Srikanth Regarding Generation Number:
    /// 
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// 
    string generateid;
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            //Response.Redirect("../../frmUserLogin.aspx");if (Label57.Text == "")
            Response.Redirect("~/Index.aspx");
        }

     
        try
        {
            //Begin Created By Srikanth on 18-5-2012 
            this.BtnSave.Attributes.Add("onclick", DisableTheButton(this.Page, this.BtnSave, "group"));
            //Begin Created By Srikanth on 18-5-2012 
            if (Session.Count > 0)
            {

                if ((Session["userlevel"].ToString().Trim() == "1" && Session["user_type"].ToString().Trim() == "Adm") || Session["userlevel"].ToString().Trim() == "10" || Session["userlevel"].ToString().Trim() == "Help" || Session["user_type"].ToString().Trim() == "Help")
                {
                    //nameRow.Visible = false;
                    unitnameRow.Visible = false;
                    uidnumberRow.Visible = false;

                    nameRow.Visible = false;
                    lbluidNo.Visible = false;
                    Label2.Visible = false;
                    Label1.Visible = false;
                    lblUnitname.Visible = false;
                    Label58.Text = Session["username"].ToString().Trim();
                  //  userNamesRiw.Visible = true;

                }

                string text = Session["user_type"].ToString();
                // Modified by Srikanth on 30-08-2012 for Help Desk Registration to MORD Team
                if (Session["user_type"].ToString().Trim() == "Head")
                {
                    Label57.Text = Session["usernameAppl"].ToString().Trim();


                    DataSet ds = cmn.GetPiaName(Session["User_Code"].ToString());
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Label57.Text = ds.Tables[0].Rows[0]["usernameAppl"].ToString();

                        //Label58.Text = ds.Tables[0].Rows[0]["piaIncharge"].ToString();
                        Label58.Text = "Cap Foundation";
                        if (Label57.Text == "")
                            Label57.Text = Label58.Text;

                    }
                }

                else if (Session["user_type"].ToString().Trim() == "MORD")
                {
                    Label57.Text = Session["usernameAppl"].ToString().Trim();

                    Label58.Text = Session["username"].ToString().Trim();
                    if (Label57.Text == "")
                        Label57.Text = Label58.Text;

                    else
                    {
                        Label57.Text = Session["usernameAppl"].ToString().Trim();

                        Label58.Text = Session["username"].ToString().Trim();
                        if (Label57.Text == "")
                            Label57.Text = Label58.Text;
                    }
                    // Modified by Srikanth on 30-08-2012 for Help Desk Registration to MORD Team
                }
                else if (Session["user_type"].ToString().Trim() == "Train")
                {
                    Label57.Text = Session["usernameAppl"].ToString().Trim();

                    Label58.Text = Session["username"].ToString().Trim();
                    if (Label57.Text == "")
                        Label57.Text = Label58.Text;


                    // Modified by Srikanth on 30-08-2012 for Help Desk Registration to MORD Team
                }
                else
                {
                    Label57.Text = Session["usernameAppl"].ToString().Trim();

                    Label58.Text = Session["username"].ToString().Trim();
                    if (Label57.Text == "")
                        Label57.Text = Label58.Text;

                }

                if (txtupload.PostedFile != null && txtupload.PostedFile.ContentLength > 0)
                    UploadFile();

                if (!IsPostBack)
                {
                    if (Session["uid"].ToString() == "1238")
                    {
                        txtemail.Text = "kcsbabu@yahoo.com";

                    }

                    Session["letterUpload"] = letterUpload;
                    Session["letterUploadFileName"] = "";

                    //Session["scanUpload"] = scanUpload;
                    //Session["scanUploadFileName"] = "";
                    cmn.getfeedback(ddlfeedback);

                    try
                    {
                        DataSet dscheck = new DataSet();
                        General Gen = new General();
                        dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
                        if (dscheck != null && dscheck.Tables.Count > 0 && dscheck.Tables[2].Rows.Count > 0)
                        {
                            lbluidNo.Text = dscheck.Tables[2].Rows[0]["UID_No"].ToString();
                            if (lbluidNo.Text.ToString() == "")
                                lbluidNo.Text = "Not available";
                            lblUnitname.Text = dscheck.Tables[0].Rows[0]["nameofunit"].ToString();
                        }
                        else
                        {
                            DataSet ds = new DataSet();
                            ds = Gen.GetShowQuestionariesCFOnew(Session["uid"].ToString().Trim());
                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                lbluidNo.Text = ds.Tables[2].Rows[0]["UID_No"].ToString();
                                if (lbluidNo.Text.ToString() == "")
                                    lbluidNo.Text = "Not available";
                                lblUnitname.Text = ds.Tables[0].Rows[0]["nameofunit"].ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }


                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    #endregion


    #region Button Disable By Srikanth on 17-5-2012
    public string DisableTheButton(Control pge, Control btn, string vldGroup)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("if (typeof(Page_ClientValidate) == 'function') {");
        if (vldGroup.Trim() == "")
        {
            sb.Append("if (Page_ClientValidate() == false) { return false; }} ");

        }
        else
        {
            sb.Append("if (Page_ClientValidate('" + vldGroup + "') == false) { return false; }} ");

        }
        sb.Append("this.value = 'Please wait...';");
        sb.Append("this.disabled = true;");
        sb.Append(pge.Page.GetPostBackEventReference(btn));
        sb.Append(";");
        return sb.ToString();
    }


    #endregion

    private void UploadFile()
    {

        Session["letterUploadFileName"] = System.IO.Path.GetFileName(txtupload.PostedFile.FileName);


        string targetPath = "";
        Random r = new Random();
        //string sFileDir = Server.MapPath("~\\Helpdesk");
        string sFileDir = ConfigurationManager.AppSettings["HelpdeskfilePath"];
        General t1 = new General();
        if (txtupload.HasFile)
        {
            if ((txtupload.PostedFile != null) && (txtupload.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(txtupload.PostedFile.FileName);
                try
                {
                    string[] fileType = txtupload.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC"
                        || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" ||
                        fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" ||
                        fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" ||
                        fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG"|| fileType[i - 1].ToUpper().Trim() =="DWG")
                    {
                        //Create a new subfolder under the current active folder

                        int num = r.Next();

                        targetPath = System.IO.Path.Combine(sFileDir, Session["uid"]
                               + "/" + num + "");

                        if (!Directory.Exists(targetPath))

                            System.IO.Directory.CreateDirectory(targetPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(targetPath);

                        txtupload.PostedFile.SaveAs(targetPath + "\\" + sFileName);
                        lblScanLetter.Text = Session["letterUploadFileName"].ToString().Trim();
                        int count = dir.GetFiles().Length;

                        Session["newPath"] = targetPath;
                        if (count == 1)
                            txtupload.PostedFile.SaveAs(targetPath + "\\" + sFileName);
                        else
                        {
                            if (count == 2)
                            {
                                string[] Files = Directory.GetFiles(targetPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                txtupload.PostedFile.SaveAs(targetPath + "\\" + sFileName);
                            }
                        }
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

                    Exception ex;
                    DeleteFile(targetPath + "\\" + sFileName);
                }
            }
        }
        else
        {
            lblmsg0.Text = "An Error Occured. Please Try Again!";
            success.Visible = false;
            Failure.Visible = true;

        }
    }

    //#region Upload File
    //[DllImport(@"urlmon.dll", CharSet = CharSet.Auto)]
    //private extern static System.UInt32 FindMimeFromData(System.UInt32 pBC,
    //[MarshalAs(UnmanagedType.LPStr)] System.String pwzUrl,
    //[MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer,
    //System.UInt32 cbSize, [MarshalAs(UnmanagedType.LPStr)] System.String pwzMimeProposed,
    //System.UInt32 dwMimeFlags,
    //out System.UInt32 ppwzMimeOut,
    //System.UInt32 dwReserverd);
    //private void UploadFile()
    //{
    //    HttpPostedFile file = txtupload.PostedFile;
    //    byte[] document = new byte[file.ContentLength];
    //    file.InputStream.Read(document, 0, file.ContentLength);
    //    System.UInt32 mimetype;
    //    FindMimeFromData(0, null, document, 256, null, 0, out mimetype, 0);
    //    System.IntPtr mimeTypePtr = new IntPtr(mimetype);
    //    string mime = Marshal.PtrToStringUni(mimeTypePtr);
    //    Marshal.FreeCoTaskMem(mimeTypePtr);

    //    if (mime == "application/pdf" || mime == "image/gif" || mime == "application/msword" || mime == "image/jpeg" || mime == "image/gif" || mime == "image/png" || mime == "application/vnd.ms-excel" || mime == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" || mime == "application/zip" || mime == "application/x-rar-compressed" || mime == "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
    //    {
    //        Session["letterUploadFileName"] = System.IO.Path.GetFileName(txtupload.PostedFile.FileName);
    //        try
    //        {
    //            string[] fileType = txtupload.PostedFile.FileName.Split('.');
    //            int letterI = fileType.Length;
    //            Session["letterUpload"] = new byte[txtupload.PostedFile.ContentLength];
    //            if (fileType[letterI - 1].ToUpper().Trim() == "PDF" || fileType[letterI - 1].ToUpper().Trim() == "DOC" || fileType[letterI - 1].ToUpper().Trim() == "JPG" || fileType[letterI - 1].ToUpper().Trim() == "GIF" || fileType[letterI - 1].ToUpper().Trim() == "JPEG" || fileType[letterI - 1].ToUpper().Trim() == "XLS" || fileType[letterI - 1].ToUpper().Trim() == "XLSX" || fileType[letterI - 1].ToUpper().Trim() == "DOCX" || fileType[letterI - 1].ToUpper().Trim() == "PNG" || fileType[letterI - 1].ToUpper().Trim() == "RAR" || fileType[letterI - 1].ToUpper().Trim() == "ZIP")
    //            {
    //                //   letterUpload = new byte[fupLetter.PostedFile.ContentLength];

    //                // Session["letterUpload"] = new byte[fupLetter.PostedFile.ContentLength];
    //                HttpPostedFile Image = txtupload.PostedFile;
    //                Image.InputStream.Read((byte[])Session["letterUpload"], 0, (int)txtupload.PostedFile.ContentLength);
    //                lblScanLetter.Text = Session["letterUploadFileName"].ToString().Trim();

    //            }


    //        }
    //        catch (Exception ex)
    //        {

    //            lblmsg0.Text = "An Error Occured. Please Try Again!" + ex.Message;
    //            success.Visible = false;
    //            Failure.Visible = true;

    //        }

    //        finally
    //        {

    //        }
    //    }
    //    else
    //    {
    //        //  file is Invalid  
    //        lblmsg0.Text = " This is not a valid File. Please Upload Valid file";
    //        success.Visible = false;
    //        Failure.Visible = true;


    //    }
    //}
    //#endregion

    #region Resetfromcontrol
    public void Resetfromcontrol(Control parent)
    {
        try
        {
            foreach (Control c in parent.Controls)
            {
                if (c.Controls.Count > 0)
                {
                    Resetfromcontrol(c);
                }
                else
                {
                    switch (c.GetType().ToString())
                    {
                        case "System.Web.UI.WebControls.TextBox":
                            ((TextBox)c).Text = "";
                            break;

                    }
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    #endregion

    #region OnPreRender
    protected override void OnPreRender(EventArgs e)
    {
        try
        {
            base.OnPreRender(e);

            StringBuilder javaScript = new StringBuilder();
            javaScript.Append("\n<script language=JavaScript>\n");
            javaScript.Append("window.history.forward(1);\n");
            javaScript.Append("</script>\n");

            Page.RegisterClientScriptBlock("HistoryScript", javaScript.ToString());
        }
        catch (Exception ex)
        {
        }
    }
    #endregion

    #region Btnclear

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("Helpdesk.aspx");
    }
    #endregion

    #region Clear
    public void clear()
    {
        ddlfeedback.SelectedValue = "--Select--";
        txtsubjet.Text = "";
        lblScanLetter.Text = "";
    }
    #endregion

    #region BtnSave
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {


            //Response.Redirect("HomeRefresh.aspx");


            string intPIAid = "";
            if (Session["user_type"].ToString().Trim() == "MORD")
            {

                intPIAid = Session["uid"].ToString().Trim();
            }
            else
            {
                intPIAid = Session["user_code"].ToString().Trim();
            }
            int i = 1;
            int ij = 0;
            int ji = 0;
            string hdCode = clsGeneral.getHelpDeskID(intPIAid).ToString();
            string newhdCode;


            int number;

            if (hdCode == "")
            {
                newhdCode = Label57.Text.Trim() + "-001";
            }
            else
            {

                generateid = hdCode.ToString();
                string extract = "";
                extract = hdCode.ToString();

                if (extract.Contains("-") == true)
                {

                    string[] words = generateid.Split('-');
                    if (words[words.Length - 1].Length > 3)
                        generateid = words[words.Length - 1].Trim();
                    else
                        generateid = extract.Substring(extract.Length - 3);
                }
                else
                {
                    generateid = generateid + 1;
                }
                if (generateid != "")
                {
                    number = Convert.ToInt32(generateid.Trim()) + 1;


                    if (number.ToString().Length == 1)
                    {
                        generateid = "00" + number;
                    }
                    else if (number.ToString().Length == 2)
                    {
                        generateid = "0" + number;
                    }
                    else
                    {
                        generateid = number.ToString();
                    }

                }
                newhdCode = Label57.Text.Trim() + "-" + generateid;
            }



            if (lblScanLetter.Text == "")
            {
                Session["newPath"] = "";
                Session["letterUploadFileName"] = "";
            }



            string hd_Username = Label58.Text;
            string intfb_id = ddlfeedback.SelectedValue.ToString();
            string hd_desc = txtsubjet.Text.ToString();
            string Created_by = Session["User_id"].ToString();

            //int returnValue = cmn.insertFeedBack(intPIAid, hd_Username, intfb_id, hd_desc, Session["letterUploadFileName"].ToString().Trim(), (byte[])(Session["letterUpload"]), Session["user_type"].ToString(), Session["uid"].ToString(), newhdCode, txtemail.Text.Trim(), getclientIP());

            int returnValue = cmn.insertFeedBackNew(intPIAid, hd_Username, intfb_id, hd_desc, null, null,
                            Session["user_type"].ToString(), Session["uid"].ToString(), newhdCode, txtemail.Text.Trim(),
                             getclientIP(), Session["newPath"].ToString(), Session["letterUploadFileName"].ToString());
            if (returnValue == -1)
            {
                string mesg1 = "Successfully Registered - Ref. No : " + newhdCode.Trim();
                //lblresult.Text = "Successfully Registered - Ref. No : " + newhdCode.Trim();
                //Session.Remove("letterUploadFileName");
                //Session.Remove("letterUpload");

                //  SendMail(newhdCode);
                //   SendMailKishore(newhdCode);
                //  SendMailSekhar(newhdCode);

                // SendMailSri(newhdCode);
                if (txtemail.Text != "")
                    SendMailAnother(newhdCode, txtemail.Text.Trim());

                // SendMailAnother(newhdCode, "mahajansahil13@gmail.com");
                // SendMailAnother(newhdCode, "hmmudbasgr@gmail.com");
                //  SendMailAnother(newhdCode, "fss.srikanth@gmail.com");
                Response.Redirect("FrmHDResultNewHelp.aspx?Msg=" + mesg1);

                Session.Remove("letterUploadFileName");
                Session.Remove("letterUpload");
                //Response.Redirect("FrmResult.aspx?Msg=" + mesg1);


                //  ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mesg1 + "');", true);
                Resetfromcontrol(this);

                //lblresult.Text = "You succefully Entered the HelpDesk ";
                clear();

            }
            else
            {
                string mesg1 = "Contact admistrator";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mesg1 + "');", true);
            }
        }

        catch (Exception ex)
        {

        }
        finally
        {
        }


    }

    

    #region Mail Sendings Created By Srikanth

    public void SendMail(string numbers)
    {


        string from = "fruxinfo@gmail.com"; //Replace this with your own correct Gmail Address

        string to = "support@fruxsoft.com"; //Replace this with the Email Address to whom you want to send the mail

        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(to);
        //MailAddress copy = new MailAddress("bbkishores.gmail.com");
        mail.CC.Add("bbkishores@gmail.com");

        //  mail.CC.Add("bbkishores.gmail.com");
        ////mail.CC.Add("mahajansahil13@gmail.com");
        ////mail.CC.Add("hmmudbasgr@gmail.com");
        mail.From = new MailAddress(from, ":: TS-ipass MIS ::", System.Text.Encoding.UTF8);
        if (Session["user_type"].ToString().Trim() == "MORD")
        {
            mail.Subject = "CAP Foundation  - Help Desk Registration from  -" + Label57.Text;
        }
        else
        {
            mail.Subject = "CAP Foundation  - Help Desk Registration From " + Label57.Text;
        }
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = "<H2>TS-ipass MIS - Help Desk Registration</H2><br><br>To : Commissionerate of Industries,TS-iPASS Cell.,  <br> <br> <b> NAME: " + Label57.Text + "</b> <br><br> USER NAME: " + Label58.Text + "<br> Feed Back Type: " + ddlfeedback.SelectedItem.Text + " <br> <br> Our  Comments : " + txtsubjet.Text + " <br><br> Help Desk Our Reference Number is <b>" + numbers + "</b> <br> Please Rectify this as early as possible<br>";
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        object a = (byte[])Session["File1"];
        mail.Attachments.Add(new Attachment(new MemoryStream((byte[])Session["letterUpload"]), Session["letterUploadFileName"].ToString()));
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;

        SmtpClient client = new SmtpClient();
        //Add the Creddentials- use your own email id and password

        client.Credentials = new System.Net.NetworkCredential(from, "frux@2013");

        client.Port = 587; // Gmail works on this port


        client.Host = "smtp.gmail.com";


        client.EnableSsl = true; //Gmail works on Server Secured Layer
        try
        {
            client.Send(mail);
            //Session.Remove("letterUpload");
            //Session.Remove("letterUploadFileName");
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

    public void SendMailKishore(string numbers)
    {


        string from = "fruxinfo@gmail.com"; //Replace this with your own correct Gmail Address

        string to = "bbkishores@gmail.com"; //Replace this with the Email Address to whom you want to send the mail

        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(to);
        mail.From = new MailAddress(from, ":: TS-ipass MIS ::", System.Text.Encoding.UTF8);
        if (Session["user_type"].ToString().Trim() == "MORD")
        {
            mail.Subject = "CAP Foundation  - Help Desk Registration From HMMU Team -" + Label57.Text;
        }
        else
        {
            mail.Subject = "CAP Foundation  - Help Desk Registration From " + Label57.Text;
        }
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = "<H2>TS-ipass MIS - Help Desk Registration</H2><br><br>To : Commissionerate of Industries,TS-iPASS Cell.,  <br> <br> <b> NAME: " + Label57.Text + "</b> <br><br> USER NAME: " + Label58.Text + "<br> Feed Back Type: " + ddlfeedback.SelectedItem.Text + " <br> <br> Our  Comments : " + txtsubjet.Text + " <br><br> Help Desk Our Reference Number is <b>" + numbers + "</b> <br> Please Rectify this as early as possible<br>";
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        object a = (byte[])Session["File2"];
        mail.Attachments.Add(new Attachment(new MemoryStream((byte[])Session["letterUpload"]), Session["letterUploadFileName"].ToString()));
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;

        SmtpClient client = new SmtpClient();
        //Add the Creddentials- use your own email id and password

        client.Credentials = new System.Net.NetworkCredential(from, "frux@2013");

        client.Port = 587; // Gmail works on this port
        client.Host = "smtp.gmail.com";
        client.EnableSsl = true; //Gmail works on Server Secured Layer
        try
        {
            client.Send(mail);
            //Session.Remove("letterUpload");
            //Session.Remove("letterUploadFileName");
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

    public void SendMailSekhar(string numbers)
    {


        string from = "fruxinfo@gmail.com"; //Replace this with your own correct Gmail Address

        string to = "fss.sekhar@gmail.com"; //Replace this with the Email Address to whom you want to send the mail

        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(to);
        mail.From = new MailAddress(from, ":: TS-ipass MIS ::", System.Text.Encoding.UTF8);
        if (Session["user_type"].ToString().Trim() == "MORD")
        {
            mail.Subject = "CAP Foundation  - Help Desk Registration From " + Label57.Text;
        }
        else
        {
            mail.Subject = "CAP Foundation  - Help Desk Registration From " + Label57.Text;
        }
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = "<H2>TS-ipass MIS - Help Desk Registration</H2><br><br>To : Commissionerate of Industries,TS-iPASS Cell.,  <br> <br> <b> PIA NAME: " + Label57.Text + "</b> <br><br> USER NAME: " + Label58.Text + "<br> Feed Back Type: " + ddlfeedback.SelectedItem.Text + " <br> <br> Our  Comments : " + txtsubjet.Text + " <br><br> Help Desk Our Reference Number is <b>" + numbers + "</b> <br> Please Rectify this as early as possible<br>";
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        object a = (byte[])Session["File3"];
        mail.Attachments.Add(new Attachment(new MemoryStream((byte[])Session["letterUpload"]), Session["letterUploadFileName"].ToString()));
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;

        SmtpClient client = new SmtpClient();
        //Add the Creddentials- use your own email id and password

        client.Credentials = new System.Net.NetworkCredential(from, "frux@2013");

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


    public void SendMailSri(string numbers)
    {


        string from = "fruxinfo@gmail.com"; //Replace this with your own correct Gmail Address

        string to = "fss.srikanth@gmail.com"; //Replace this with the Email Address to whom you want to send the mail

        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        //mail.To.Add(to);
        mail.From = new MailAddress(from, ":: TS-ipass MIS ::", System.Text.Encoding.UTF8);
        if (Session["user_type"].ToString().Trim() == "MORD")
        {
            mail.Subject = "CAP Foundation  - Help Desk Registration From " + Label57.Text;
        }
        else
        {
            mail.Subject = "CAP Foundation  - Help Desk Registration From " + Label57.Text;
        }
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = "<H2>TS-ipass MIS - Help Desk Registration</H2><br><br>To : Commissionerate of Industries,TS-iPASS Cell.,  <br> <br> <b> PIA NAME: " + Label57.Text + "</b> <br><br> USER NAME: " + Label58.Text + "<br> Feed Back Type: " + ddlfeedback.SelectedItem.Text + " <br> <br> Our  Comments : " + txtsubjet.Text + " <br><br> Help Desk Our Reference Number is <b>" + numbers + "</b> <br> Please Rectify this as early as possible<br>";
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        object a = (byte[])Session["File4"];
        mail.Attachments.Add(new Attachment(new MemoryStream((byte[])Session["letterUpload"]), Session["letterUploadFileName"].ToString()));
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;

        SmtpClient client = new SmtpClient();
        //Add the Creddentials- use your own email id and password

        client.Credentials = new System.Net.NetworkCredential(from, "frux@2013");

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

    public void SendMailAnother(string numbers, string anothermail)
    {


        string from = "tsipass.telangana@gmail.com"; //Replace this with your own correct Gmail Address

        string to = anothermail; //Replace this with the Email Address to whom you want to send the mail

        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(to);
        mail.CC.Add("kcsbabu@yahoo.com");
        //mail.Bcc.Add("nikhil.hyd21@gmail.com");

        //mail.CC.Add("madhuri.capfoundation@gmail.com");
        //  mail.CC.Add("bbkishores@gmail.com");
        mail.From = new MailAddress(from, ":: TSiPASS TSiPASS MIS ::", System.Text.Encoding.UTF8);
        if (Session["user_type"].ToString().Trim() == "MORD")
        {
            mail.Subject = "TSiPASS TSiPASS  - MIS Help Desk Registration From " + Label57.Text;
        }
        else
        {
            mail.Subject = "TSiPASS TSiPASS  - MIS Help Desk Registration From " + Label57.Text;
        }
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = "<H2>TSiPASS TSiPASS MIS Help Desk Registration</H2><br><br>To : Commissionerate of Industries,TS-iPASS Cell.,  <br> <br> <b> NAME: " + Label57.Text + "</b> <br><br> USER NAME: " + Label58.Text + "<br> Feed Back Type: " + ddlfeedback.SelectedItem.Text + " <br> <br> Our  Comments : " + txtsubjet.Text + " <br><br> Help Desk Our Reference Number is <b>" + numbers + "</b> <br> Please Rectify this as early as possible<br><br><b>Thank you for your Helpdesk Registration.</b>";
        //<br/><br/><span style='color:Red; font-size:medium'>  <b> Your Helpdesk will be redressed within 24 hours. In case of any delay kindly contact to Toll Free No: 7306-600-600.</b></span></br><br><br> <b>Thanking You</b>
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        object a = (byte[])Session["File5"];
        mail.Attachments.Add(new Attachment(new MemoryStream((byte[])Session["letterUpload"]), Session["letterUploadFileName"].ToString()));
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;

        SmtpClient client = new SmtpClient();
        //Add the Creddentials- use your own email id and password

        client.Credentials = new System.Net.NetworkCredential(from, "lrefskmlxnoowqtc");// "tsipass@2016");
       // client.Credentials = new System.Net.NetworkCredential(from, "tsipass@2016");

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

    #endregion

    #endregion

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

    //   public static string getMACAddress()
    //   {
    //       string MAC = "";
    //string MyDomainPrefix = @"CONTOSO\\"; //replace CONTOSO with your network domain  
    //    string currentUserLoginName = Request.LogonUserIdentity.Name.Replace("https://ipass.telangana.gov.in/", string.Empty); // Get the current Windows authenticated user  
    //    string myCommandToRun = "/c nbtstat -a " + Request.UserHostName + @" >> " + AppDomain.CurrentDomain.BaseDirectory +   
    //currentUserLoginName + ".txt";  
    //    //Execute the command  
    //    System.Diagnostics.Process process = new System.Diagnostics.Process();  
    //    process.StartInfo.CreateNoWindow = true;  
    //    process.StartInfo.FileName = "cmd.exe";  
    //    process.StartInfo.Arguments = myCommandToRun;  
    //    process.Start();  
    //    process.WaitForExit();  
    //    //Start parsing the file created on disk  
    //    StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + currentUserLoginName + ".txt");  
    //    string MyLine = null;  
    //    MyLine = sr.ReadToEnd();  
    //    string[] MyStrings = MyLine.Trim().Split('\n'); //Array of strings from text file split by the return char  
    //    foreach (string item in MyStrings)  
    //    {  
    //        if (item.Trim().Contains("MAC Address"))  
    //        {  
    //            //Get the MAC Address  
    //           MAC =item.ToString().Remove(0,item.IndexOf('=')+1).Trim();  
    //        }  
    //    }
    //   }
}
