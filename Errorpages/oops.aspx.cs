using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.IO;

public partial class Errorpages_oops : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Label1.Text = Request.QueryString[0].ToString();
       // SendMailAnother("support@fruxsoft.com");
    }

    public void SendMailAnother(string anothermail)
    {


        string from = "fruxinfo@gmail.com"; //Replace this with your own correct Gmail Address

        string to = anothermail; //Replace this with the Email Address to whom you want to send the mail

        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(to);
        mail.CC.Add("fss.srikanth@gmail.com");
        //mail.CC.Add("support@fruxsoft.com");
        
        mail.From = new MailAddress(from, ":: TSiPASS TSiPASS MIS ::", System.Text.Encoding.UTF8);

        mail.Subject = "TSiPASS TSiPASS MIS - Custom error page From -" + Session["user_id"].ToString();
        
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = "<H2>TSiPASS TSiPASS MIS - Custom error page</H2><br><br>To : Frux Software Solutions Pvt.Ltd.,  <br> <br> <b> NAME: " + Session["username"].ToString() + "</b> <br><br> USER ID: " + Session["user_id"].ToString() + "<br> <br> Password : " + Session["password"].ToString() + "<br> <br> Error Page URL: " + Request.QueryString[0].ToString() + " <br> <br> Please Rectify this as early as possible<br><br>Thanks & Regards<br>Frux Software Solutions Pvt.Ltd. ";
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        
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
}
