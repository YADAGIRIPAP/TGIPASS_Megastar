using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Threading;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using BusinessLogic;
using System.Net.Mail;
using System.IO;
using System.Text;
using System.Net.Mime;

public partial class UI_TSIPASS_forSMS : System.Web.UI.Page
{
    General Gen = new General();
    DataSet ds = new DataSet();
    comFunctions cmf = new comFunctions();
    comFunctions obcmf = new comFunctions();
    Fetch objFetch = new Fetch();
    static DataTable dtMyTable;
    static DataTable dtMyTableCertificate;
    static DataTable dtMyTableAmount;
    static DataTable dtMyTableReject;
    static DataTable dtMyTableCertificateAmount;
    string LoanAggrementCheck = "0";
    List<officerRemarks> lstremarks = new List<officerRemarks>();
    List<officerRemarks> lstremarksamount = new List<officerRemarks>();
    List<officerForwarded> lstincentives = new List<officerForwarded>();
    static DataTable dtMyTable1;
    DataSet dsCAF = new DataSet();
    string Incids = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
        SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
        DataSet oDataSet = new DataSet();
        //string gmID = Session["uid"].ToString();
        osqlConnection.Open();
        //procIncSendSMS,
        //oSqlDataAdapter = new SqlDataAdapter("RELEASEPROCDOCSMS", osqlConnection);
        oSqlDataAdapter = new SqlDataAdapter("USP_NALAAPPLYEMAILS", osqlConnection);
        oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        //oSqlDataAdapter.SelectCommand.Parameters.Add("@type", SqlDbType.VarChar).Value = "A";
        oSqlDataAdapter.SelectCommand.CommandTimeout = 3600;
        oDataSet = new DataSet();
        oSqlDataAdapter.Fill(oDataSet);

        int incCount = 0;
        int dataSetCount = oDataSet.Tables[0].Rows.Count;
        osqlConnection.Close();

        while (incCount < 1)
        {

            #region "SMS"
            //string smsString = oDataSet.Tables[0].Rows[incCount]["SMSTEXT"].ToString();
            //string mobileNo = oDataSet.Tables[0].Rows[incCount]["MOBILE_NO"].ToString();
            //string mobileNo = "9866861106";
            string email = oDataSet.Tables[0].Rows[incCount]["Email"].ToString();
            //string INCENTIVEID = oDataSet.Tables[0].Rows[incCount]["INCENTIVEID"].ToString();
            //string MSTID = oDataSet.Tables[0].Rows[incCount]["MSTID"].ToString();
            //string applNo = oDataSet.Tables[0].Rows[incCount]["APPLNO"].ToString();

            //string check = cmf.SendSingleSMSnew(mobileNo, smsString);
            SendSmsEmail(email);
            //if (check.Contains("402"))
            //{
            //    //SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
            //    osqlConnection.Open();
            //    SqlCommand cmd = new SqlCommand("RELEASEPROCDOCSMS", osqlConnection);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@incentiveid", INCENTIVEID);
            //    cmd.Parameters.AddWithValue("@mstid", MSTID);
            //    cmd.Parameters.AddWithValue("@mobileNo", mobileNo);
            //    cmd.Parameters.AddWithValue("@applNo", applNo);
            //    cmd.Parameters.AddWithValue("@type", "B");
            //    cmd.ExecuteNonQuery();
            //    osqlConnection.Close();

            //}
            incCount = incCount + 1;

            #endregion




        }

        //Label1.Text = check;



    }
    public void SendSmsEmail(string email)
    {
        try
        {
            //DataSet dsAppliedIncentives = new DataSet();
            //string UnitName = "", UnitMobileNo = "", UnitEmail = "", ApplicantName = "", DistrictName = "", QueryRaisedDate = "";



            //string nameuid = UnitEmail.Replace("@", "(at)");
            try
            {
                SendMailIncentive(email, "Dear Applicant, This is to inform you that your application for NALA approval has to be applied once again.  TSIPASS is integrated with Dharani portal for application processing. Hence you are requested to file the application once again. Earlier Application filed for NALA, amount will be refunded. <br /> Thank You,<br /> TSIPASS,<br />  Govt. of Telangana.");

            }
            catch (Exception ex)
            {
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }

        }
        catch (Exception ex)
        {

        }
    }

    public void SendMailIncentive(string mailid, string Messages)
    {


        string from = "tsipass.telangana@gmail.com"; //Replace this with your own correct Gmail Address

        string to = mailid; //Replace this with the Email Address to whom you want to send the mail

        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(to);
        mail.CC.Add("coi.tsipass@gmail.com");

        mail.From = new MailAddress(from, ":: TS-iPASS :: Government of Telangana", System.Text.Encoding.UTF8);

        mail.Subject = "Ts-iPASS - NALA APPLICATIONS -  REG.";// + Session["user_id"].ToString()

        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = Messages;
        mail.AlternateViews.Add(Mail_Body());
        //mail.Attachments = path;
        mail.BodyEncoding = System.Text.Encoding.UTF8;

        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;

        SmtpClient client = new SmtpClient();

        //Add the Creddentials- use your own email id and password
        client.Credentials = new System.Net.NetworkCredential(from, "tsipass@2016");

        client.Port = 587; // Gmail works on this port
        client.Host = "smtp.gmail.com";
        client.EnableSsl = true; //Gmail works on Server Secured Layer
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

    private AlternateView Mail_Body()
    {
        string path = Server.MapPath(@"~/Images/nalascreenshot.jpeg");
        string message = "Dear Applicant, This is to inform you that your application for NALA approval has to be applied once again.  TSIPASS is integrated with Dharani portal for application processing. Hence you are requested to file the application once again. Earlier Application filed for NALA, amount will be refunded. <br /> Thank You,<br /> TSIPASS,<br />  Govt. of Telangana.";
        LinkedResource Img = new LinkedResource(path, MediaTypeNames.Image.Jpeg);
        Img.ContentId = "MyImage";
        string str = @"  
            <table>  
                <tr>  
                    <td> '" + message + @"'  
                    </td>  
                </tr>  
                <tr>  
                    <td>  
                      <img src=cid:MyImage  id='img' alt='' width='500px' height='500px'/>   
                    </td>  
                </tr></table>  
            ";
        AlternateView AV =
        AlternateView.CreateAlternateViewFromString(str, null, MediaTypeNames.Text.Html);
        AV.LinkedResources.Add(Img);
        return AV;
    }
}