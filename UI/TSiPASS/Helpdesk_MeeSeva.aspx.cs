
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

public partial class Helpdesk : System.Web.UI.Page
{
    #region Declaration
    General clsGeneral = new General();
    comFunctions fssFunctions = new comFunctions();
    General cmn = new General();
    string mobPIA = String.Empty;
    string piaid = String.Empty;
    string trCode = String.Empty;
    string mppia = String.Empty;
    DataSet ds;
    byte[] scanUpload = new byte[36871];
    byte[] letterUpload = new byte[36871];
       
    string generateid;
    #endregion
    comFunctions objcmf = new comFunctions();

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            Response.Redirect("https://ipass.telangana.gov.in", false);
        }
        try
        {            
            this.BtnSave.Attributes.Add("onclick", DisableTheButton(this.Page, this.BtnSave, "group"));
            
            if (Session.Count > 0)
            {
                Label57.Text = Session["StrMeesevaUserId"].ToString();
                Label58.Text = Session["StrMeesevaUserId"].ToString();              
            }

            if (txtupload.PostedFile != null && txtupload.PostedFile.ContentLength > 0)
                UploadFile();

            if (!IsPostBack)
            {

                Session["letterUpload"] = letterUpload;
                Session["letterUploadFileName"] = "";
                cmn.getfeedback(ddlfeedback);
            }
        }
        catch (Exception ex)
        {
            Errors.ErrorLog(ex);
        }
    }
    #endregion

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
        
    private void UploadFile()
    {

        Session["letterUploadFileName"] = System.IO.Path.GetFileName(txtupload.PostedFile.FileName);


        try
        {
            string[] fileType = txtupload.PostedFile.FileName.Split('.');
            int letterI = fileType.Length;
            Session["letterUpload"] = new byte[txtupload.PostedFile.ContentLength];
            if (fileType[letterI - 1].ToUpper().Trim() == "PDF" || fileType[letterI - 1].ToUpper().Trim() == "DOC" || fileType[letterI - 1].ToUpper().Trim() == "JPG" || fileType[letterI - 1].ToUpper().Trim() == "GIF" || fileType[letterI - 1].ToUpper().Trim() == "JPEG" || fileType[letterI - 1].ToUpper().Trim() == "XLS" || fileType[letterI - 1].ToUpper().Trim() == "XLSX" || fileType[letterI - 1].ToUpper().Trim() == "DOCX" || fileType[letterI - 1].ToUpper().Trim() == "PNG")
            {
                HttpPostedFile Image = txtupload.PostedFile;
                Image.InputStream.Read((byte[])Session["letterUpload"], 0, (int)txtupload.PostedFile.ContentLength);
                lblScanLetter.Text = Session["letterUploadFileName"].ToString().Trim();

            }

        }
        catch (Exception ex)
        {
            lblmsg0.Text = "An Error Occured. Please Try Again!" + ex.Message;
            Errors.ErrorLog(ex);
            success.Visible = false;
            Failure.Visible = true;

        }

        finally
        {

        }
    }
    
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
        objcmf.ClearControls(this.Page);
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
            string hdCode = clsGeneral.getHelpDeskID("1000").ToString();
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
            
            string hd_Username = Label58.Text;
            string intfb_id = ddlfeedback.SelectedValue.ToString();

            string hd_desc = txtsubjet.Text.ToString();

            int returnValue = cmn.insertFeedBack("0", hd_Username, intfb_id, hd_desc, Session["letterUploadFileName"].ToString().Trim(), (byte[])(Session["letterUpload"]), "MeeSeva", "0", newhdCode, txtemail.Text.Trim(), ""); //fix by CMS by passing string IPaddress
            if (returnValue == -1)
            {
                string mesg1 = "Successfully Registered - Ref. No : " + newhdCode.Trim();
                
                if (txtemail.Text != "")
                    SendMailAnother(newhdCode, txtemail.Text.Trim());

                Session.Remove("letterUploadFileName");
                Session.Remove("letterUpload");

                Response.Redirect("FrmHDResultNewHelp_MeeSeva.aspx?Msg=" + mesg1);                
                Resetfromcontrol(this);
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
            Errors.ErrorLog(ex);
        }
        finally
        {
        }


    }

 
    public void SendMailAnother(string numbers, string anothermail)
    {
        string from = "fruxinfo@gmail.com"; //Replace this with your own correct Gmail Address

        string to = anothermail; //Replace this with the Email Address to whom you want to send the mail

        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(to);
        mail.CC.Add("support@fruxsoft.com");
        
        mail.From = new MailAddress(from, ":: TSiPASS TSiPASS MIS ::", System.Text.Encoding.UTF8);
        mail.Subject = "TSiPASS - Incentive Help Desk Registration From " + Label57.Text;
        
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = "<H2>TSiPASS TSiPASS MIS Help Desk Registration</H2><br><br>To : Commissionerate of Industries,TS-iPASS Cell.,  <br> <br> <b> NAME: " + Label57.Text + "</b> <br><br> USER NAME: " + Label58.Text + "<br> Feed Back Type: " + ddlfeedback.SelectedItem.Text + " <br> <br> Our  Comments : " + txtsubjet.Text + " <br><br> Help Desk Our Reference Number is <b>" + numbers + "</b> <br> Please Rectify this as early as possible<br>";
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        object a = (byte[])Session["File5"];
        mail.Attachments.Add(new Attachment(new MemoryStream((byte[])Session["letterUpload"]), Session["letterUploadFileName"].ToString()));
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;

        SmtpClient client = new SmtpClient();
        
        client.Credentials = new System.Net.NetworkCredential(from, "frux@2013");

        client.Port = 587; // Gmail works on this port
        client.Host = "smtp.gmail.com";
        client.EnableSsl = true; //Gmail works on Server Secured Layer
        try
        {
            client.Send(mail);
            }
        catch (Exception ex)
        {
            Errors.ErrorLog(ex);
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
}
