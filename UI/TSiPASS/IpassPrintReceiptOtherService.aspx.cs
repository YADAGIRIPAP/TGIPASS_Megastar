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
using System.Net;
using System.Net.Security;
using System.Net.Mail;
//using TSIPassBE;
//using TSIPassBL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Text;
using System.Xml;
using System.Threading;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;


public partial class UI_TSiPASS_IpassPrintReceiptOtherService : System.Web.UI.Page
{
    #region "Global Variables"
    //PaymentDetailsBL objBL = new PaymentDetailsBL();
    //PaymentDetailsBE objBE = new PaymentDetailsBE();
    DataSet ds = new DataSet();
    string constring = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ToString();
    public string sEmail;
    //SMsHttpPostClient objSms = new SMsHttpPostClient();
    //static String username = "cgg-tipass";
    //static String password = "tip@$$@2016";
    //static String senderid = "TiPASS";

    static String username = "TSIPASS";
    static String password = "kcsb@786";
    static String senderid = "TSIPAS";

    HttpWebRequest request;
    static Stream dataStream;
    string responseFromServer = "";

    WebserviceVO webvo = new WebserviceVO();
    General Gen = new General();

    General gen = new General();
    WebClient wc = new WebClient();
    TSNPDCLService.TsipassWsService tsnpdcl = new TSNPDCLService.TsipassWsService();
    TSSPDCLService.TSSPDCLIPassService tsspdcl = new TSSPDCLService.TSSPDCLIPassService();
    FactoryService.TSFactoryServiceImplService factory = new FactoryService.TSFactoryServiceImplService();
    FireService.Service1 fire = new FireService.Service1();
    //BoilerService.TSBoilerServiceImplService boiler = new BoilerService.TSBoilerServiceImplService();
    LabourService.TSLabourServiceImplService labourservice = new LabourService.TSLabourServiceImplService();
    NALAService.MeeSevaWebService nalaservice = new NALAService.MeeSevaWebService();
    HMWSSBService.TSiPASSNewConnectionUC hmwssb = new HMWSSBService.TSiPASSNewConnectionUC();
    HMDAService.tsipass hmdaservice = new HMDAService.tsipass();
    HMDAService.ApplicationFormResponse hmdapplication = new HMDAService.ApplicationFormResponse();
    TSIICService.tsipass tsiicservice = new TSIICService.tsipass();
    TSIICService.ApplicationFormResponse tsiicapplication = new TSIICService.ApplicationFormResponse();

    #endregion
    #region "Page_Load"

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


    private void OTPAfterSubmissionApplcn()
    {
        String Email = "", /*UserID = ""*/ MobileNo = "";
        Email = txtEmailId.Text;
        MobileNo = lblMobileNumber.Text;


        DataSet ds = Gen.ValidateForgotReformsPassword(Email, MobileNo);//,Dept
        if (ds.Tables[0].Rows.Count > 0)
        {
            string userpasword = ds.Tables[0].Rows[0]["Password"].ToString();
            if (ds.Tables[0].Rows[0]["PwdEncryflag"].ToString().Trim() == "Y")
            {
                userpasword = Gen.Decrypt(userpasword, "SYSTIME");
            }
            string msgs = "Dear applecant " + " " + "\r\n" + " your Login Credentials." + "\r\n" + " User Id : " + ds.Tables[0].Rows[0]["UserId"].ToString() + "\r\n" + "Password : " + userpasword + "\r\n";
            msgs = msgs + "Thanks and Regards," + "\r\n" + "Commissionerate of Industries,TS-iPASS Cell";

            string body = msgs;
            string from = "tsipass.telangana@gmail.com"; //Replace this with your own correct Gmail Address

            string to = ds.Tables[0].Rows[0]["UserId"].ToString(); //Replace this with the Email Address to whom you want to send the mail

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(to);
            //mail.CC.Add("kcsbabu@gmail.com");
            //mail.CC.Add("coi.tsipass@gmail.com");
            //mail.CC.Add("support@fruxsoft.com");

            mail.From = new MailAddress(from, ":: TSiPASS ::", System.Text.Encoding.UTF8);

            mail.Subject = "Applicant -Login Credentials -";// + Session["user_id"].ToString()

            mail.SubjectEncoding = System.Text.Encoding.UTF8;  //ds.Tables[0].Rows[0]["Password"].ToString()
            mail.Body = "Dear  applicant " + " " + "<br><br>  <H2>TSiPASS MIS  - Login Credentials</H2><br> Welcome to TS-iPASS. <br/> Dear <b> " + " " + "</b>,<br/> Please use the following credentials to Login. <br><br> USER ID: " + ds.Tables[0].Rows[0]["UserId"].ToString() + "<br> <br> Password : " + userpasword + "<br> <br> URL:  <a href='http://industries.telangana.gov.in' target='_blank' > TSiPASS </a> <br> <br> Please Login by clicking the above link.<br><br>Regards<br>TSiPASS MIS";
            mail.BodyEncoding = System.Text.Encoding.UTF8;

            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            SmtpClient client = new SmtpClient();
            //Add the Creddentials- use your own email id and password

            //client.Credentials = new System.Net.NetworkCredential(from, "tsipass@2016");
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
            //SendSingleSMSnew(MobileNo, body);


            //lblmsg.Text = "Login Credentials sent to Registerd E-Mail And Registerd Mobile No ";
            //Failure.Visible = false;
            //success.Visible = true;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "AnotherFunction();", true);
        }
        else
        {
            //lblmsg0.Text = "Please Enter Registerd E-Mail and Mobile and User Name";
            //Failure.Visible = true;
            //success.Visible = false;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "AnotherFunction();", true);
        }


    }
    protected void Page_Load(object sender, EventArgs e)
    {

        //Session["Amount"] = "002520.235";
        //Session["RefNo"] = "CIT";
        //Session["TranRefNo"] = "JHMP5431889613";
        try
        {
            if (!Page.IsPostBack)
            {
                if (Session["Amount"] != null && Session["RefNo"] != null)
                {
                    string amount = Session["Amount"].ToString();
                    string RefNO = Session["RefNo"].ToString();
                    string TranRefNo = Session["TranRefNo"].ToString();
                    string[] no;
                    int Number;
                    if (amount.Contains("."))
                    {
                        no = amount.Split('.');
                        Number = Convert.ToInt32(no[0]);
                    }
                    else
                    {
                        Number = Convert.ToInt32(amount);
                    }


                    lblnum2wrds.Text = NumberToText(Number) + " Rupees Only.";

                    // lblPaidat.Text = RefNO + " PG";  //"SBI PG";
                    ds = BillPaymentReceipt(TranRefNo);


                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        txtasmtno.Text = ds.Tables[0].Rows[0]["Reference"].ToString();
                        txtrcptno.Text = TranRefNo;
                        txtrcptdt.Text = System.DateTime.Now.ToString();
                        txtname.Text = ds.Tables[0].Rows[0]["IndustryName"].ToString();
                        txtaddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                        lblMobileNumber.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                        //  lblMobileNumber.Text = "7702542727";
                        txtEmailId.Text = ds.Tables[0].Rows[0]["Emailid"].ToString();

                        // txtEmailId.Text = "kmrias@gmail.com";

                        txttotal.Text = Convert.ToDecimal(amount).ToString("#,##0") + " /-";



                        string message = "Thank you for payment  Rs." + amount + " for this UID " + txtasmtno.Text + " of TxnID " + TranRefNo + "-TSIPass";
                        if (lblMobileNumber.Text != "")
                        {
                            try
                            {
                                //SendSingleSMSnew(lblMobileNumber.Text, message);
                                OTPAfterSubmissionApplcn();

                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (txtEmailId.Text != "")
                        {
                            var sb = new StringBuilder();
                            Receipt.RenderControl(new HtmlTextWriter(new StringWriter(sb)));

                            string s = sb.ToString();


                            //StringWriter stringWriter = new StringWriter();
                            //HtmlTextWriter htmlTextWriterw = new HtmlTextWriter(stringWriter);
                            //Receipt.RenderControl(htmlTextWriterw);
                            s = s.Replace("px", "");

                            s = s.Replace("<img src=\"../../Resource/Images/telanganalogo.png\" height=\"60\" width=\"60\" />", "");

                            StringReader stringReader = new StringReader(s.ToString());
                            Document pdfDoc = new Document(PageSize.A4, 30f, 25f, 15f, 0.2f);
                            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                            MemoryStream memoryStream = new MemoryStream();
                            PdfWriter.GetInstance(pdfDoc, memoryStream);
                            pdfDoc.Open();
                            htmlparser.Parse(stringReader);
                            pdfDoc.Close();
                            byte[] bytes = memoryStream.ToArray();
                            memoryStream.Close();
                            try
                            {
                                SendingEmailWithAttachment(txtEmailId.Text, message, bytes);
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        //ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<Script>window.open('EncloserList.aspx','popUpWindow','height=600,width=850,status=no,toolbar=no,menubar=no,location=no');</Script>", false);
                        // ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<Script>window.open('DepartmentService.aspx?UIDNO=" + txtasmtno.Text + "','popUpWindow','height=0,width=1,status=no,toolbar=no,menubar=no,location=no');</Script>", false);
                        try
                        {
                            #region commenting (Not using web services)
                            //webservice(txtasmtno.Text);
                            #endregion
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    else
                    {

                    }
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
    #endregion
    #region "Number To Text"
    public string NumberToText(int number)
    {
        if (number == 0) return "Zero";
        int[] num = new int[4];
        int first = 0;
        int u, h, t;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        if (number < 0)
        {
            sb.Append("Minus ");
            number = -number;
        }
        string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };
        string[] words1 = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };
        string[] words2 = { "Twenty ", "Thirty ", "Fourty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };
        string[] words3 = { "Thousand ", "Lakh ", "Crore " };
        num[0] = number % 1000; // units
        num[1] = number / 1000;
        num[2] = number / 100000;
        num[1] = num[1] - 100 * num[2]; // thousands
        num[3] = number / 10000000; // crores
        num[2] = num[2] - 100 * num[3]; // lakhs
        for (int i = 3; i > 0; i--)
        {
            if (num[i] != 0)
            {
                first = i;
                break;
            }
        }
        for (int i = first; i >= 0; i--)
        {
            if (num[i] == 0) continue;
            u = num[i] % 10; // ones
            t = num[i] / 10;
            h = num[i] / 100; // hundreds
            t = t - 10 * h; // tens
            if (h > 0) sb.Append(words0[h] + "Hundred ");
            if (u > 0 || t > 0)
            {
                //if (h > 0 || i == 0) sb.Append("and ");
                if (t == 0)
                    sb.Append(words0[u]);
                else if (t == 1)
                    sb.Append(words1[u]);
                else
                    sb.Append(words2[t - 2] + words0[u]);
            }
            if (i != 0) sb.Append(words3[i - 1]);
        }


        // TextBox2.Text = "Rupees " + sb.ToString().TrimEnd() + " Only";
        return sb.ToString().TrimEnd();
    }
    #endregion
    #region "btnprint_Click"
    protected void btnprint_Click(object sender, EventArgs e)
    {
        try
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=PaymentReceipt.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlTextWriterw = new HtmlTextWriter(stringWriter);
            Receipt.RenderControl(htmlTextWriterw);
            StringReader stringReader = new StringReader(stringWriter.ToString());
            Document pdfDoc = new Document(PageSize.A4, 30f, 25f, 15f, 0.2f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            //iTextSharp.text.Image gifghmc1 = iTextSharp.text.Image.GetInstance(Server.MapPath("images/tsSmalllogo.png"));
            //gifghmc1.Alignment = iTextSharp.text.Image.ALIGN_MIDDLE;
            //gifghmc1.ScaleToFit(80, 80);
            //gifghmc1.Alignment = iTextSharp.text.Image.UNDERLYING;
            //gifghmc1.SetAbsolutePosition(260, 600);
            //pdfDoc.Add(gifghmc1);
            htmlparser.Parse(stringReader);
            pdfDoc.Close();
        }
        catch
        {

        }
    }
    #endregion
    #region "VerifyRenderingInServerForm"
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    #endregion
    #region "SendingEmailWithAttachment"
    /// <summary>
    ///  Method for sending mail message 
    /// </summary>
    /// <returns> string</returns>
    private string SendingEmailWithAttachment(string receiverMailId, string Message, byte[] bytes)
    {
        try
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
           // System.Net.NetworkCredential cred = new System.Net.NetworkCredential("tsipass.telangana@gmail.com", "tsipass@2016");
           // System.Net.NetworkCredential cred = new System.Net.NetworkCredential("tsipass.telangana@gmail.com", "zwcq vlxk gyor lpeg");
            System.Net.NetworkCredential cred = new System.Net.NetworkCredential("tsipass.telangana@gmail.com", "fqeq nive azke giwb");
            mail.To.Add(receiverMailId);
           // mail.From = new MailAddress("tsipass.telangana@gmail.com", "tsipass@2016");
            mail.From = new MailAddress("tsipass.telangana@gmail.com", "fqeq nive azke giwb");
            mail.Subject = "Information from e-Telangana State Indistries";
            mail.Body = "Dear User,<p>" + Message + "</p> <p>Regards,</p> TSIPASS.";
            mail.ReplyTo = new System.Net.Mail.MailAddress("tsipass.telangana@gmail.com");
            mail.IsBodyHtml = true;

            Attachment mailAttachmnet;
            mail.Attachments.Add(new Attachment(new MemoryStream(bytes), "Receipt.pdf"));
            //ObjMailMessage.Bcc.Add("me2@mail-address.com");
            mail.Priority = MailPriority.High;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com");
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = cred;
            smtp.Port = 587;
            smtp.Send(mail);
            return "Sent";

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    #endregion
    #region "Sending SMS to Specified Mobile Number"
    /// <summary>
    /// Method for Sending SMS to Specified Mobile Number
    /// </summary>
    /// <returns>string</returns>       
    private string SendSingleSMS(String mobileNo, String message)
    {
        try
        {
            request = (HttpWebRequest)WebRequest.Create("http://msdgweb.mgov.gov.in/esms/sendsmsrequest");
            request.ProtocolVersion = HttpVersion.Version10;
            //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
            ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
            request.Method = "POST";
            String smsservicetype = "singlemsg"; //For single message.
            String query = "username=" + HttpUtility.UrlEncode(username) +
                "&password=" + HttpUtility.UrlEncode(password) +
                "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +
                "&content=" + HttpUtility.UrlEncode("Payment Conformation from TSIPASS:" + message) +
                "&mobileno=" + HttpUtility.UrlEncode(mobileNo) +
                "&senderid=" + HttpUtility.UrlEncode(senderid);

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
            responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);

        }
        responseFromServer = responseFromServer.Replace("\r\n", string.Empty);
        return responseFromServer.Trim();
        // return "402,1,0";
    }
    #endregion
    private DataSet BillPaymentReceipt(string TranRefNo)
    {
        try
        {
            SqlConnection conn = new SqlConnection(constring);
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("GetBilldeskReceipt_OtherServices", conn);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@OrderNo", TranRefNo);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            da1.Fill(ds);
            conn.Close();
            return ds;

        }
        catch (Exception ex)
        {
        }

        return null;
    }
    protected void btnclose_Click(object sender, EventArgs e)
    {
        Response.Redirect("Dashboard.aspx");
    }

    public void webservice(string UIDNO)
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        try
        {
            //if (Session["objUsrDtl"] != null)
            //{
            if (!IsPostBack)
            {
                // string UIDNO = Request.QueryString["UIDNO"].ToString();
                // UIDNO = "MEG01000354445";//"MEG02000064425";//"SML00500064419";//"SML00500064419";
                ds = gen.GetDepartmentonuid(UIDNO);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dt = ds.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string deptid = dt.Rows[i]["intApprovalid"].ToString();
                        if (deptid == "71")
                        {
                            //http://125.18.179.58:8080/WaterFeasibility/IALAsavewaterdetails.do?aadhaarnumber=222222222207&ulb_code=1116&dist_id=1&fathername=ser&fathersurname=fds&mobilenumber=9999999999&name=Test&surname=Test&industryname=IALATest&quantityofwater=10&quessionaireid=12345&entrepreneurid=2131&uid=test123;

                            DataSet dsdept = new DataSet();

                            dsdept = gen.getdepartmentdetailsonuid(UIDNO, deptid);
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                            {
                                string token = "bd16b347e586f05339f830b3a85d8aefa8da92c1";
                                int districtId = Convert.ToInt16(dsdept.Tables[0].Rows[0]["districtId"].ToString());
                                string districtName = dsdept.Tables[0].Rows[0]["districtName"].ToString();
                                int constituencyId = Convert.ToInt16(dsdept.Tables[0].Rows[0]["constituencyId"].ToString());
                                string constituencyName = dsdept.Tables[0].Rows[0]["constituencyName"].ToString();
                                int mandalId = Convert.ToInt16(dsdept.Tables[0].Rows[0]["mandalId"].ToString());
                                string mandalName = dsdept.Tables[0].Rows[0]["mandalName"].ToString();
                                string panchayatId = dsdept.Tables[0].Rows[0]["panchayatId"].ToString();
                                int segmentId = Convert.ToInt16(dsdept.Tables[0].Rows[0]["segmentId"].ToString());
                                string Landmark = dsdept.Tables[0].Rows[0]["Landmark"].ToString();
                                string institutionName = dsdept.Tables[0].Rows[0]["institutionName"].ToString();
                                string institutionPrimaryType = dsdept.Tables[0].Rows[0]["institutionPrimaryType"].ToString();
                                string institutionSecondaryType = dsdept.Tables[0].Rows[0]["institutionPrimaryType"].ToString();
                                int requiredQty = Convert.ToInt16(dsdept.Tables[0].Rows[0]["requiredQty"].ToString());
                                string purpose = dsdept.Tables[0].Rows[0]["purpose"].ToString();
                                string contactName = dsdept.Tables[0].Rows[0]["contactName"].ToString();
                                string contactPhone = dsdept.Tables[0].Rows[0]["contactPhone"].ToString();
                                string contactEmail = dsdept.Tables[0].Rows[0]["contactEmail"].ToString();
                                string document = dsdept.Tables[0].Rows[0]["document"].ToString();
                                string quessionaireid = dsdept.Tables[0].Rows[0]["quessionaireid"].ToString();
                                string entrepreneurid = dsdept.Tables[0].Rows[0]["entrepreneurid"].ToString();
                                string uid = dsdept.Tables[0].Rows[0]["uid"].ToString();

                                //string WEBSERVICE_URL = "http://125.18.179.58:8080/WaterFeasibility/IALAsavewaterdetails.do?aadhaarnumber=" + aadhaarnumber + "&ulb_code=" + ulb_code + "&dist_id=" + dist_id + "&fathername=" + fathername + "&fathersurname=" + fathersurname + "&mobilenumber=" + mobilenumber + "&name=" + name + "&surname=" + surname + "&industryname=" + industryname + "&quantityofwater=" + quantityofwater + " &quessionaireid=" + quessionaireid + "&entrepreneurid=" + entrepreneurid + "&uid=" + uid + ""; Test url
                                //string WEBSERVICE_URL = "http://mb.adeptogeoit.com/api/v1/connection-request?districtId=" + districtId + "&districtName=" + districtName +
                                //    "&constituencyId=" + constituencyId + "&constituencyName=" + constituencyName + "&mandalId=" + mandalId + "&mandalName=" + mandalName +
                                //    "&panchayatId=" + panchayatId + "&segmentId=" + segmentId + "&landmark=" + Landmark +
                                //   "&institutionName=" + institutionName + "&institutionPrimaryType=" + institutionPrimaryType + "&institutionSecondaryType=" + institutionSecondaryType +
                                //   "&requiredQty=" + requiredQty + "&purpose=" + purpose + "&contactName=" + contactName + "&contactPhone=" + contactPhone + "&contactEmail=" + contactEmail + "&documentFilePath=" + document +
                                //   " &quessionaireid=" + quessionaireid + "&entrepreneurid=" + entrepreneurid + "&integratedRecordId=" + uid + ""; //test url


                                string WEBSERVICE_URL = "http://missionbhagiratha.telangana.gov.in/mb-online/api/v1/connection-request?districtId=" + districtId + "&districtName=" + districtName +
                                    "&constituencyId=" + constituencyId + "&constituencyName=" + constituencyName + "&mandalId=" + mandalId + "&mandalName=" + mandalName +
                                    "&panchayatId=" + panchayatId + "&segmentId=" + segmentId + "&landmark=" + Landmark +
                                   "&institutionName=" + institutionName + "&institutionPrimaryType=" + institutionPrimaryType + "&institutionSecondaryType=" + institutionSecondaryType +
                                   "&requiredQty=" + requiredQty + "&purpose=" + purpose + "&contactName=" + contactName + "&contactPhone=" + contactPhone + "&contactEmail=" + contactEmail + "&documentFilePath=" + document +
                                   " &quessionaireid=" + quessionaireid + "&entrepreneurid=" + entrepreneurid + "&integratedRecordId=" + uid + "";

                                //http://missionbhagiratha.telangana.gov.in/mb-online/

                                //string jsonData = "{\"cafUniqueNo\" : \""+cafUniqueNo+"\", \"transactionId\":\""+transactionId+"\" , \"amount\":\""+amount+"\" , \"bankName\":\""+bankName+"\" , \"transactionStatus\":\"S\" , \"paymentType\":\"NB\"}";
                                //string jsonData = "cafUniqueNo" : \"" + cafUniqueNo + "\", \"transactionId\":\"" + transactionId + "\" , \"amount\":\"" + amount + "\" , \"bankName\":\"" + bankName + "\" , \"transactionStatus\":\"S\" , \"paymentType\":\"NB\"}";
                                try
                                {
                                    var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
                                    if (webRequest != null)
                                    {
                                        webRequest.Headers.Add("token", "bd16b347e586f05339f830b3a85d8aefa8da92c1");
                                        //webRequest.Headers =  "bd16b347e586f05339f830b3a85d8aefa8da92c1";
                                        webRequest.Method = "POST";
                                        webRequest.Timeout = 20000;
                                        webRequest.ContentType = "application/x-www-form-urlencoded";

                                        //using (System.IO.Stream s = webRequest.GetRequestStream())
                                        //{
                                        //    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(s))
                                        //        sw.Write(jsonData);
                                        //}

                                        using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                                        {
                                            using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                                            {
                                                var jsonResponse = sr.ReadToEnd();
                                                System.Diagnostics.Debug.WriteLine(String.Format("Response: {0}", jsonResponse));
                                                if (jsonResponse.Contains("Operation executed successfully"))
                                                {
                                                    //{"result":"201903180002","response":"SUCCESS","responseMessage":"Operation executed successfully","status":200}
                                                    gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", jsonResponse, "Y");
                                                    int k = gen.InsertDeptDateTracing("71", quessionaireid, UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", "71");
                                                }
                                                else
                                                {
                                                    //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                                    gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", jsonResponse, "N");
                                                }
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                                }

                            }
                        }
                        if (deptid == "20")//PCB
                        {
                            DataSet dsdept = new DataSet();

                            dsdept = gen.getdepartmentdetailsonuid(UIDNO, deptid);
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                            {
                                string cafUniqueNo = dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                                string transactionId = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                string amount = dsdept.Tables[0].Rows[0]["Approval_Fee"].ToString();
                                string bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                string transactionStatus = "S";
                                string paymentType = "NB";
                                string indApplication = dsdept.Tables[0].Rows[0]["NICApplicationno"].ToString();
                                string additionalPayment = "F";

                                string WEBSERVICE_URL = "http://tsocmms.nic.in/TLWS/updateFee?cafUniqueNo=" + cafUniqueNo + "&transactionId=" + transactionId + "&amount=" + amount + "&bankName=" + bankName + "&transactionStatus=" + transactionStatus + "&paymentType=" + paymentType + "&indApplicationNo=" + indApplication + "&additionalPayment=" + additionalPayment + "";


                                //string jsonData = "{\"cafUniqueNo\" : \""+cafUniqueNo+"\", \"transactionId\":\""+transactionId+"\" , \"amount\":\""+amount+"\" , \"bankName\":\""+bankName+"\" , \"transactionStatus\":\"S\" , \"paymentType\":\"NB\"}";
                                //string jsonData = "cafUniqueNo" : \"" + cafUniqueNo + "\", \"transactionId\":\"" + transactionId + "\" , \"amount\":\"" + amount + "\" , \"bankName\":\"" + bankName + "\" , \"transactionStatus\":\"S\" , \"paymentType\":\"NB\"}";
                                try
                                {
                                    var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
                                    if (webRequest != null)
                                    {
                                        webRequest.Method = "GET";
                                        webRequest.Timeout = 20000;
                                        webRequest.ContentType = "application/x-www-form-urlencoded";

                                        //using (System.IO.Stream s = webRequest.GetRequestStream())
                                        //{
                                        //    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(s))
                                        //        sw.Write(jsonData);
                                        //}

                                        using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                                        {
                                            using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                                            {
                                                var jsonResponse = sr.ReadToEnd();
                                                System.Diagnostics.Debug.WriteLine(String.Format("Response: {0}", jsonResponse));
                                                if (jsonResponse.Contains("Fee submitted successfully"))
                                                {
                                                    gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", jsonResponse, "Y");
                                                    int k = gen.InsertDeptDateTracing("20", dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", "20");
                                                }
                                                else
                                                {
                                                    //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                                    gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", jsonResponse, "N");
                                                }
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                                }

                            }

                        }
                        if (deptid == "31")//TSIIC
                        {
                            DataSet dsdept = new DataSet();
                            string valueshmda = "";
                            string outputhmda = "";
                            string outpayhmda = "";
                            dsdept = gen.getdepartmentdetailsonuid(UIDNO, deptid);
                            valueshmda = dsdept.GetXml();
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(valueshmda);
                            //string jsonText = JsonConvert.SerializeXmlNode(doc); // To convert JSON text contained in string json into an XML node XmlDocument doc = JsonConvert.DeserializeXmlNode(json);
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                            {
                                //hmdapplication.
                                //System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

                                tsiicapplication = tsiicservice.create(valueshmda, "$$08@213");//000844/I1/U6/HMDA/25072017

                                DataSet dsdeptattachmentsTSIIC = new DataSet();
                                dsdeptattachmentsTSIIC = gen.getattachmentdetailsonuid(UIDNO, deptid, tsiicapplication.FileNo);
                                //Kindly contact to administrator regarding add work flow.
                                string tsiicattachments = dsdeptattachmentsTSIIC.GetXml();
                                tsiicapplication = tsiicservice.SaveDocumentDataUsingXML(tsiicattachments, "$$08@213");//000838/I1/U6/HMDA/20072017//
                                if (tsiicapplication.FileNo != "" && tsiicapplication.FileNo != null)
                                {
                                    //string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                    gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", tsiicapplication.FileNo, "Y");
                                    int k = gen.InsertDeptDateTracing("3", dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                                }
                                else
                                {
                                    //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                    gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", tsiicapplication.ErrorMessage, "N");
                                }
                            }
                        }
                        if (deptid == "35")//HMDA
                        {
                            DataSet dsdept = new DataSet();
                            string valueshmda = "";
                            string outputhmda = "";
                            string outpayhmda = "";
                            dsdept = gen.getdepartmentdetailsonuid(UIDNO, deptid);
                            valueshmda = dsdept.GetXml();
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(valueshmda);
                            //string jsonText = JsonConvert.SerializeXmlNode(doc); // To convert JSON text contained in string json into an XML node XmlDocument doc = JsonConvert.DeserializeXmlNode(json);
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                            {
                                //hmdapplication.
                                //System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

                                hmdapplication = hmdaservice.create(valueshmda, "$$08@213");//000844/I1/U6/HMDA/25072017
                                //Kindly contact to Administrator regarding post mapping configuration for revenue department.
                                DataSet dsdeptattachmentsHMDA = new DataSet();
                                dsdeptattachmentsHMDA = gen.getattachmentdetailsonuid(UIDNO, deptid, hmdapplication.FileNo);// "000825 /I1/U6/HMDA/10072017");//000841/I1/U6/HMDA/23072017//000842/I1/U6/HMDA/23072017

                                //Kindly contact to administrator regarding add work flow.
                                string hmdaattachments = dsdeptattachmentsHMDA.GetXml();
                                hmdapplication = hmdaservice.SaveDocumentDataUsingXML(hmdaattachments, "$$08@213");//000838/I1/U6/HMDA/20072017


                                if (hmdapplication.FileNo != "" && hmdapplication.FileNo != null)
                                {
                                    //string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                    gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", hmdapplication.FileNo, "Y");
                                    int k = gen.InsertDeptDateTracing("11", dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                                }
                                else
                                {
                                    //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                    gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", hmdapplication.ErrorMessage, "N");
                                }
                            }
                        }
                        if (deptid == "10") //HMWSSB
                        {
                            try
                            {
                                DataSet dsdept = new DataSet();
                                string valueshmwssb = "";
                                string outputhmwssb = "";
                                string outpayhmwssb = "";
                                dsdept = gen.getdepartmentdetailsonuid(UIDNO, deptid);
                                valueshmwssb = dsdept.GetXml();
                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                                {
                                    webvo.UID_No = dsdept.Tables[0].Rows[0]["UID_NO"].ToString();
                                    webvo.intQuessionaireid = Convert.ToInt16(dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString());
                                    webvo.intEnterpreneurid = Convert.ToInt16(dsdept.Tables[0].Rows[0]["intCFEEnterpid"].ToString());
                                    webvo.NameofthePromoter = dsdept.Tables[0].Rows[0]["NameofthePromoter"].ToString();
                                    webvo.Door_No = dsdept.Tables[0].Rows[0]["DOOR_NO"].ToString();
                                    webvo.STREET = dsdept.Tables[0].Rows[0]["StreetName"].ToString();
                                    webvo.AreaName = dsdept.Tables[0].Rows[0]["AREANAME"].ToString();
                                    webvo.Pincode = dsdept.Tables[0].Rows[0]["PINCODE"].ToString();
                                    webvo.TelephoneNumber = dsdept.Tables[0].Rows[0]["TELEPHONENUMBER"].ToString();
                                    webvo.MobileNumber = dsdept.Tables[0].Rows[0]["MOBILENUMBER"].ToString();
                                    webvo.Email = dsdept.Tables[0].Rows[0]["EMAIL"].ToString();
                                    webvo.saleDeedPlotAreaInSqMts = Convert.ToDecimal(dsdept.Tables[0].Rows[0]["Built_up_Area"].ToString());
                                    webvo.saleDeedPlotAreaInSqYards = Convert.ToDecimal(dsdept.Tables[0].Rows[0]["SQUAREYARD"].ToString());
                                    webvo.totalPlinthArea = Convert.ToDecimal(dsdept.Tables[0].Rows[0]["Tot_Extent"].ToString());
                                    webvo.Amount = Convert.ToDecimal(dsdept.Tables[0].Rows[0]["Approval_Fee"].ToString());
                                    webvo.Paymentflag = dsdept.Tables[0].Rows[0]["PaymentFlag"].ToString();
                                    webvo.Bankname = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                    webvo.Transactionno = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                    webvo.TransactionDate = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                    int receiptno = 0;
                                    bool recepit;

                                    outputhmwssb = hmwssb.SubmitApplication(webvo.UID_No, webvo.intQuessionaireid, true, webvo.intEnterpreneurid, true, webvo.NameofthePromoter, webvo.Door_No, webvo.STREET,
                                        webvo.AreaName, webvo.Pincode, webvo.TelephoneNumber, webvo.MobileNumber, webvo.Email, webvo.saleDeedPlotAreaInSqMts, true,
                                      webvo.saleDeedPlotAreaInSqYards, true, webvo.totalPlinthArea, true);
                                    hmwssb.PostCollectionChargesReceipt(webvo.intQuessionaireid, true, webvo.UID_No, webvo.intEnterpreneurid, true, webvo.Amount, true, webvo.Paymentflag, webvo.Bankname,
                                        webvo.Transactionno, webvo.TransactionDate, out receiptno, out recepit);
                                    if (receiptno != 0 && recepit == true)
                                    {
                                        gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", Convert.ToString(receiptno), "Y");
                                        int k = gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["intDeptid"].ToString(), webvo.intQuessionaireid.ToString(), webvo.UID_No, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                                    }
                                    else
                                    {
                                        gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", Convert.ToString(receiptno), "N");
                                    }
                                    //hmwssb.PostCollectionChargesReceipt()
                                    //hmwssb.SubmitApplication("uidno", "Fnam", "Houseno", "Street", "Area", "Mobile", "saleDeedPlotAreaInSqMts", "saleDeedPlotAreaInSqMtsSpecified",
                                    //   "saleDeedPlotAreaInSqYards", "saleDeedPlotAreaInSqYardsSpecified", "totalPlinthArea", "totalPlinthAreaSpecified");
                                    //ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<Script>window.open('HSRPService.aspx?Office=" + ((UserDetail)Session["objUsrDtl"]).OfficeCode + "&Date=" + DateTime.Today.ToString("dd/MM/yyyy") + "','null','height=350,width=500,status=no,toolbar=no,menubar=no,location=no');</Script>", false);
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }

                        if (deptid == "34")
                        {
                            try
                            {
                                DataSet dsdept = new DataSet();
                                DataSet dsdeptattachments = new DataSet();
                                dsdept = gen.getdepartmentdetailsonuid(UIDNO, deptid);
                                string valuenala = dsdept.GetXml();
                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                                {
                                    webvo.UserId = dsdept.Tables[0].Rows[0]["UserId"].ToString();
                                    webvo.Password = dsdept.Tables[0].Rows[0]["Password"].ToString();
                                    webvo.LogindID = dsdept.Tables[0].Rows[0]["LogindID"].ToString();
                                    webvo.ServiceID = dsdept.Tables[0].Rows[0]["ServiceID"].ToString();
                                    webvo.AddressFlag = dsdept.Tables[0].Rows[0]["AddressFlag"].ToString();
                                    webvo.UIDNumber = dsdept.Tables[0].Rows[0]["UIDNumber"].ToString();
                                    webvo.ApplicantName = dsdept.Tables[0].Rows[0]["ApplicantName"].ToString();
                                    webvo.Relation = dsdept.Tables[0].Rows[0]["Relation"].ToString();
                                    webvo.FatherName = dsdept.Tables[0].Rows[0]["FatherName"].ToString();
                                    webvo.Gender = dsdept.Tables[0].Rows[0]["Gender"].ToString();
                                    webvo.DateOfBirth = dsdept.Tables[0].Rows[0]["DateOfBirth"].ToString();
                                    webvo.PermanentDoorNo = dsdept.Tables[0].Rows[0]["PermanentDoorNo"].ToString();
                                    webvo.PermanentLocality = dsdept.Tables[0].Rows[0]["PermanentLocality"].ToString();
                                    webvo.PermanentDistrict = dsdept.Tables[0].Rows[0]["PermanentDistrict"].ToString();
                                    webvo.PermanentMandal = dsdept.Tables[0].Rows[0]["PermanentMandal"].ToString();
                                    webvo.PermanentVillage = dsdept.Tables[0].Rows[0]["PermanentVillage"].ToString();
                                    webvo.PermanentPincode = dsdept.Tables[0].Rows[0]["PermanentPincode"].ToString();
                                    webvo.PostalDoorNo = dsdept.Tables[0].Rows[0]["PostalDoorNo"].ToString();
                                    webvo.PostalLocality = dsdept.Tables[0].Rows[0]["PostalLocality"].ToString();
                                    webvo.StateId = dsdept.Tables[0].Rows[0]["StateId"].ToString();
                                    webvo.PostalDistrict = dsdept.Tables[0].Rows[0]["PostalDistrict"].ToString();
                                    webvo.PostalMandal = dsdept.Tables[0].Rows[0]["PostalMandal"].ToString();
                                    webvo.PostalVillage = dsdept.Tables[0].Rows[0]["PostalVillage"].ToString();
                                    webvo.PostalPincode = dsdept.Tables[0].Rows[0]["PostalPincode"].ToString();
                                    webvo.MobileNo = dsdept.Tables[0].Rows[0]["MobileNo"].ToString();
                                    webvo.PhoneNo = dsdept.Tables[0].Rows[0]["PhoneNo"].ToString();
                                    webvo.EmailID = dsdept.Tables[0].Rows[0]["EmailID"].ToString();
                                    webvo.Remarks = dsdept.Tables[0].Rows[0]["Remarks"].ToString();
                                    webvo.RationCardNo = dsdept.Tables[0].Rows[0]["RationCardNo"].ToString();
                                    webvo.AadhaarNo = dsdept.Tables[0].Rows[0]["AadhaarNo"].ToString();
                                    webvo.DeliveryType = dsdept.Tables[0].Rows[0]["DeliveryType"].ToString();
                                    webvo.Doc_District = dsdept.Tables[0].Rows[0]["Doc_District"].ToString();
                                    webvo.Doc_Mandal = dsdept.Tables[0].Rows[0]["Doc_Mandal"].ToString();
                                    webvo.Doc_Village = dsdept.Tables[0].Rows[0]["Doc_Village"].ToString();
                                    webvo.Purpose = dsdept.Tables[0].Rows[0]["Purpose"].ToString();
                                    webvo.ServiceCharge = dsdept.Tables[0].Rows[0]["ServiceCharge"].ToString();
                                    webvo.UserCharge = dsdept.Tables[0].Rows[0]["UserCharge"].ToString();
                                    webvo.PostalCharge = dsdept.Tables[0].Rows[0]["PostalCharge"].ToString();
                                    webvo.TotalAmount = dsdept.Tables[0].Rows[0]["TotalAmount"].ToString();
                                    webvo.GridDetails = dsdept.Tables[0].Rows[0]["GridDetails"].ToString();
                                    webvo.QuestionaireId = dsdept.Tables[0].Rows[0]["QuestionaireId"].ToString();
                                    webvo.EntrepreneurId = dsdept.Tables[0].Rows[0]["EntrepreneurId"].ToString();
                                    DataSet dsdeptattachmentsfire = new DataSet();
                                    dsdeptattachmentsfire = gen.getattachmentdetailsonuid(UIDNO, deptid, "");
                                    if (dsdeptattachmentsfire != null && dsdeptattachmentsfire.Tables.Count > 0 && dsdeptattachmentsfire.Tables[0].Rows.Count > 0)
                                    {
                                        if (dsdeptattachmentsfire.Tables[0].Rows[0]["Description"] == "Self Certification Form")
                                        {
                                            webvo.certificateform = dsdeptattachmentsfire.Tables[0].Rows[0]["Filepath"].ToString();
                                        }
                                        if (dsdeptattachmentsfire.Tables[1].Rows.Count > 0)
                                        {
                                            if (dsdeptattachmentsfire.Tables[1].Rows[0]["Description"] == "Registration Deed")
                                            {
                                                webvo.landrelated = dsdeptattachmentsfire.Tables[1].Rows[0]["Filepath"].ToString();
                                            }
                                        }
                                        if (dsdeptattachmentsfire.Tables[2].Rows.Count > 0)
                                        {
                                            if (dsdeptattachmentsfire.Tables[2].Rows[0]["Description"] == "PAN / AADHAAR")
                                            {
                                                webvo.idproof = dsdeptattachmentsfire.Tables[2].Rows[0]["Filepath"].ToString();
                                            }
                                        }
                                        if (dsdeptattachmentsfire.Tables[3].Rows.Count > 0)
                                        {
                                            if (dsdeptattachmentsfire.Tables[3].Rows[0]["Description"] == "Combined site plan")
                                            {
                                                webvo.docapplicationform = dsdeptattachmentsfire.Tables[3].Rows[0]["Filepath"].ToString();
                                            }
                                        }

                                    }
                                    string outputnala = nalaservice.GetLandConversionTransactionNo(webvo.UserId, webvo.Password, webvo.LogindID, webvo.ServiceID, webvo.AddressFlag, webvo.UIDNumber, webvo.ApplicantName,
          webvo.Relation, webvo.FatherName, webvo.Gender, webvo.DateOfBirth, webvo.PermanentDoorNo, webvo.PermanentLocality, webvo.PermanentDistrict, webvo.PermanentMandal, webvo.PermanentVillage,
          webvo.PermanentPincode, webvo.PostalDoorNo, webvo.PostalLocality, webvo.StateId, webvo.PostalDistrict, webvo.PostalMandal, webvo.PostalVillage, webvo.PostalPincode, webvo.MobileNo,
          webvo.PhoneNo, webvo.EmailID, webvo.Remarks, webvo.RationCardNo, webvo.AadhaarNo, webvo.DeliveryType, webvo.Doc_District, webvo.Doc_Mandal, webvo.Doc_Village, webvo.Purpose,
          webvo.ServiceCharge, webvo.UserCharge, webvo.PostalCharge, webvo.TotalAmount, webvo.GridDetails, webvo.QuestionaireId, webvo.EntrepreneurId, webvo.docapplicationform, webvo.landrelated, webvo.certificateform, webvo.idproof);
                                    StringReader str = new StringReader(outputnala);
                                    DataSet dsout = new DataSet();
                                    dsout.ReadXml(str);
                                    if (dsout != null && dsout.Tables.Count > 0 && dsout.Tables[0].Rows.Count > 0)
                                    {
                                        if (dsout.Tables[0].Columns.Contains("ResponseCode"))
                                        {
                                            if (dsout.Tables[0].Rows[0]["ResponseCode"].ToString() == "100")
                                            {
                                                string cclaout = dsout.Tables[0].Rows[0]["ResponseCode"].ToString() + ',' + dsout.Tables[0].Rows[0]["ResponseDesc"].ToString();
                                                gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", cclaout, "Y");
                                                int k = gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["intDeptid"].ToString(), webvo.QuestionaireId.ToString(), webvo.UIDNumber, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                                            }
                                            else
                                            {
                                                string cclaouterror = dsout.Tables[0].Rows[0]["ResponseCode"].ToString() + ',' + dsout.Tables[0].Rows[0]["ResponseDesc"].ToString();
                                                gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", cclaouterror, "N");
                                            }
                                        }
                                    }

                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (deptid == "47")
                        {
                            try
                            {
                                DataSet dsdept = new DataSet();
                                DataSet dsdeptattachments = new DataSet();
                                dsdept = gen.getdepartmentdetailsonuid(UIDNO, deptid);
                                LabourService.act labouract = new LabourService.act();
                                LabourService.actsResponse labourout = new LabourService.actsResponse();
                                LabourService.contractLabourPrincipalEmployer contractvo = new LabourService.contractLabourPrincipalEmployer();
                                LabourService.buildingotherconstructions labour = new LabourService.buildingotherconstructions();
                                LabourService.ismwPrincipalEmployer migrateemployer = new LabourService.ismwPrincipalEmployer();

                                string actids = "";
                                string actid = "";
                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                                {
                                    actids = dsdept.Tables[0].Rows[0]["LabourAct_Id"].ToString();

                                    string[] split = actids.Split(',');
                                    if (actids.Contains("2"))//The Buildings & Other Construction Workers Act
                                    {
                                        labouract.buildingRegistrationActSelected = true;
                                        labour.actID = dsdept.Tables[0].Rows[0]["actID"].ToString();
                                        labour.bank_code = dsdept.Tables[0].Rows[0]["bank_code"].ToString();
                                        labour.bank_ref_number = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                        labour.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                        labour.cin = dsdept.Tables[0].Rows[0]["cin"].ToString();
                                        labour.compound_fee = 0;// dsdept.Tables[0].Columns[""].ToString();
                                        labour.date_commencement = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                                        labour.date_completion = dsdept.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();
                                        labour.entrepreneur_id = dsdept.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                                        labour.establishment_full_name = dsdept.Tables[0].Rows[0]["Form1_Estb_Name"].ToString();
                                        labour.establishment_name = dsdept.Tables[0].Rows[0]["NAME"].ToString();
                                        labour.establishment_permanent_district = dsdept.Tables[0].Rows[0]["Form1_2_Per_District"].ToString();
                                        labour.establishment_permanent_door = dsdept.Tables[0].Rows[0]["Form1_2_Per_DoorNo"].ToString();
                                        labour.establishment_permanent_mandal = dsdept.Tables[0].Rows[0]["Form1_2_Per_Mandal"].ToString();
                                        labour.establishment_permanent_pincode = dsdept.Tables[0].Rows[0]["Form1_2_Per_PinCode"].ToString();
                                        labour.establishment_permanent_village = dsdept.Tables[0].Rows[0]["Form1_2_Per_Village"].ToString();
                                        labour.establishment_postal_district = dsdept.Tables[0].Rows[0]["Form1_Estd_District"].ToString();
                                        labour.establishment_postal_door = dsdept.Tables[0].Rows[0]["Form1_Estd_DoorNo"].ToString();
                                        labour.establishment_postal_locality = dsdept.Tables[0].Rows[0]["Form1_Estd_Locality"].ToString();
                                        labour.establishment_postal_mandal = dsdept.Tables[0].Rows[0]["Form1_Estd_Mandal"].ToString();
                                        labour.establishment_postal_pincode = dsdept.Tables[0].Rows[0]["Form1_Estd_PinCode"].ToString();
                                        labour.establishment_postal_village = dsdept.Tables[0].Rows[0]["Form1_Estd_Village"].ToString();
                                        labour.manager_agent_designation = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Designation"].ToString();
                                        labour.manager_agent_district = dsdept.Tables[0].Rows[0]["Form1_1_Manager_District"].ToString();
                                        labour.manager_agent_door = dsdept.Tables[0].Rows[0]["Form1_1_Manager_DoorNo"].ToString();
                                        labour.manager_agent_email = dsdept.Tables[0].Rows[0]["Form1_Manager_EMail"].ToString();
                                        labour.manager_agent_fathername = dsdept.Tables[0].Rows[0]["Form1_1_Manager_FatherName"].ToString();
                                        labour.manager_agent_mandal = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Mandal"].ToString();
                                        labour.manager_agent_mobile = dsdept.Tables[0].Rows[0]["Form1_Manager_MobileNo"].ToString();
                                        labour.manager_agent_name = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Name"].ToString();
                                        labour.manager_agent_street = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Locality"].ToString();
                                        labour.manager_agent_village = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Village"].ToString();
                                        labour.max_employees_aday = dsdept.Tables[0].Rows[0]["Form1_2_MaxWorkers"].ToString();
                                        labour.nature_work = dsdept.Tables[0].Rows[0]["Form1_Nature_of_Business"].ToString();
                                        labour.other_attachments_1 = "";//dsdept.Tables[0].Columns["other_attachments_1"].ToString();
                                        labour.other_attachments_2 = "";// dsdept.Tables[0].Columns["other_attachments_2"].ToString();
                                        labour.payment_mode = dsdept.Tables[0].Rows[0]["payment_mode"].ToString();
                                        labour.paymentFlag = dsdept.Tables[0].Rows[0]["paymentFlag"].ToString();
                                        labour.penality_percentage = Convert.ToInt32(dsdept.Tables[0].Rows[0]["penality_percentage"].ToString());
                                        labour.penality_years = Convert.ToInt32(dsdept.Tables[0].Rows[0]["penality_years"].ToString());
                                        labour.projectSubmitDate = dsdept.Tables[0].Rows[0]["projectSubmitDate"].ToString();
                                        labour.questionnaire_id = dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                                        labour.registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                                        labour.registration_years = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_years"].ToString());
                                        labour.stageID = dsdept.Tables[0].Rows[0]["stageID"].ToString();
                                        labour.total_amount_payable = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString());
                                        labour.total_penality_amount = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_penality_amount"].ToString());
                                        labour.total_registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_registration_fee"].ToString());
                                        labour.totalAmount = dsdept.Tables[0].Rows[0]["totalAmount"].ToString();
                                        labour.transaction_for = dsdept.Tables[0].Rows[0]["transaction_for"].ToString();
                                        labour.transaction_id = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                        labour.transaction_status = "Y";
                                        labour.transactionDate = dsdept.Tables[0].Rows[0]["transactionDate"].ToString();
                                        //labour.tsipassApplicationID = dsdept.Tables[0].Rows[0]["tsipassApplicationID"].ToString();
                                        labour.type_of_application = dsdept.Tables[0].Rows[0]["type_of_application"].ToString();
                                        labour.uID = dsdept.Tables[0].Rows[0]["UID_NO"].ToString();
                                        labour.unpaid_balance_welfare = Convert.ToInt32(dsdept.Tables[0].Rows[0]["unpaid_balance_welfare"].ToString());
                                        labour.valid_from_date = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                                        labour.valid_to_date = dsdept.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();
                                        labouract.buildingRegistrationActData = labour;

                                        labourout = labourservice.actSelected(labouract);
                                        if (labourout.status == "SUCCESS")
                                        {
                                            string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                            gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", labouroutmsg, "Y");
                                            int k = gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), labour.uID, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                                        }
                                        else
                                        {
                                            string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                            gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", labourouterrormsg, "N");
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (deptid == "48")
                        {
                            try
                            {
                                DataSet dsdept = new DataSet();
                                DataSet dsdeptattachments = new DataSet();
                                dsdept = gen.getdepartmentdetailsonuid(UIDNO, deptid);
                                LabourService.act labouract = new LabourService.act();
                                LabourService.actsResponse labourout = new LabourService.actsResponse();
                                LabourService.contractLabourPrincipalEmployer contractvo = new LabourService.contractLabourPrincipalEmployer();
                                LabourService.buildingotherconstructions labour = new LabourService.buildingotherconstructions();
                                LabourService.ismwPrincipalEmployer migrateemployer = new LabourService.ismwPrincipalEmployer();



                                string actids = "";
                                string actid = "";
                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                                {
                                    actids = dsdept.Tables[0].Rows[0]["LabourAct_Id"].ToString();
                                    string[] split = actids.Split(',');
                                    if (actids.Contains("3"))//The Contract Labour Act (Principal Employer)
                                    {

                                        labouract.contractLabourPrincipalEmplyerActSelected = true;
                                        contractvo.actID = "CPF";
                                        contractvo.bank_code = dsdept.Tables[0].Rows[0]["bank_code"].ToString();
                                        contractvo.bank_ref_number = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                        contractvo.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                        contractvo.cin = dsdept.Tables[0].Rows[0]["cin"].ToString();
                                        contractvo.compound_fee = 0;
                                        contractvo.employees_attachement = "";//dsdept.Tables[0].Rows[0][""].ToString();
                                        contractvo.entrepreneur_id = dsdept.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                                        contractvo.establishment_category = dsdept.Tables[0].Rows[0]["Form1_1_Estb_Category"].ToString();
                                        contractvo.establishment_category_others = dsdept.Tables[0].Rows[0]["Form1_1_Estb_Classification"].ToString();
                                        contractvo.establishment_name = dsdept.Tables[0].Rows[0]["Form1_Estb_Name"].ToString();
                                        contractvo.establishment_postal_district = dsdept.Tables[0].Rows[0]["Form1_Estd_District"].ToString();
                                        contractvo.establishment_postal_door = dsdept.Tables[0].Rows[0]["Form1_Estd_DoorNo"].ToString();
                                        contractvo.establishment_postal_locality = dsdept.Tables[0].Rows[0]["Form1_Estd_Locality"].ToString();
                                        contractvo.establishment_postal_mandal = dsdept.Tables[0].Rows[0]["Form1_Estd_Mandal"].ToString();
                                        contractvo.establishment_postal_village = dsdept.Tables[0].Rows[0]["Form1_Estd_Village"].ToString();
                                        contractvo.manager_agent_district = dsdept.Tables[0].Rows[0]["Form1_1_Manager_District"].ToString();
                                        contractvo.manager_agent_door = dsdept.Tables[0].Rows[0]["Form1_1_Manager_DoorNo"].ToString();
                                        contractvo.manager_agent_mandal = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Mandal"].ToString();
                                        contractvo.manager_agent_name = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Name"].ToString();
                                        contractvo.manager_agent_village = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Village"].ToString();
                                        contractvo.max_employees_aday = dsdept.Tables[0].Rows[0]["Form1_2_MaxWorkers"].ToString();
                                        contractvo.nature_work = dsdept.Tables[0].Rows[0]["Form1_Nature_of_Business"].ToString();
                                        contractvo.other_attachments_1 = "";
                                        contractvo.other_attachments_2 = "";
                                        contractvo.payment_mode = dsdept.Tables[0].Rows[0]["payment_mode"].ToString();
                                        contractvo.paymentFlag = dsdept.Tables[0].Rows[0]["paymentFlag"].ToString();
                                        contractvo.penality_percentage = 0;//Convert.ToInt32(dsdept.Tables[0].Rows[0]["penality_percentage"].ToString());
                                        contractvo.penality_years = 0;//Convert.ToInt32(dsdept.Tables[0].Rows[0]["penality_years"].ToString());
                                        //contractvo.previous_registered_act = dsdept.Tables[0].Rows[0][""].ToString();
                                        //contractvo.previous_registration_certificate = dsdept.Tables[0].Rows[0][""].ToString();
                                        //contractvo.previous_registration_no = dsdept.Tables[0].Rows[0][""].ToString();
                                        contractvo.principal_employer_district = dsdept.Tables[0].Rows[0]["Form1_Employer_District"].ToString();
                                        contractvo.principal_employer_door = dsdept.Tables[0].Rows[0]["Form1_Employer_DoorNo"].ToString();
                                        contractvo.principal_employer_email = dsdept.Tables[0].Rows[0]["Form1_Employer_EmailID"].ToString();
                                        contractvo.principal_employer_fathername = dsdept.Tables[0].Rows[0]["Form1_Empolyer_FatherName"].ToString();
                                        contractvo.principal_employer_mandal = dsdept.Tables[0].Rows[0]["Form1_Employer_Mandal"].ToString();
                                        contractvo.principal_employer_mobile = dsdept.Tables[0].Rows[0]["Form1_Employer_MobileNo"].ToString();
                                        contractvo.principal_employer_name = dsdept.Tables[0].Rows[0]["Form1_Employer_Name"].ToString();
                                        contractvo.principal_employer_village = dsdept.Tables[0].Rows[0]["Form1_Employer_Village"].ToString();
                                        contractvo.projectSubmitDate = dsdept.Tables[0].Rows[0]["projectSubmitDate"].ToString();
                                        contractvo.questionnaire_id = dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                                        contractvo.registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                                        contractvo.registration_years = 0;
                                        contractvo.stageID = dsdept.Tables[0].Rows[0]["intStageid"].ToString();
                                        contractvo.total_amount_payable = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString());
                                        contractvo.total_penality_amount = 0;
                                        contractvo.total_registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                                        contractvo.totalAmount = dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString();
                                        contractvo.transaction_for = dsdept.Tables[0].Rows[0]["transaction_for"].ToString();
                                        contractvo.transaction_id = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                        contractvo.transaction_status = "Y";//dsdept.Tables[0].Rows[0][""].ToString();
                                        contractvo.transactionDate = dsdept.Tables[0].Rows[0]["transactionDate"].ToString();
                                        contractvo.transactionNumber = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                        //contractvo.tsipassApplicationID = dsdept.Tables[0].Rows[0][""].ToString();
                                        contractvo.type_of_application = dsdept.Tables[0].Rows[0]["type_of_application"].ToString();
                                        contractvo.uID = dsdept.Tables[0].Rows[0]["UID_NO"].ToString();
                                        contractvo.unpaid_balance_welfare = Convert.ToInt32(dsdept.Tables[0].Rows[0]["unpaid_balance_welfare"].ToString());
                                        contractvo.valid_from_date = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                                        contractvo.valid_to_date = dsdept.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();

                                        LabourService.contractLabourPrincipalEmployerMultiData[] contractmulti = null;

                                        //contractvo.contractorParticulars[] lstitem = null;
                                        ContractorDetails co = new ContractorDetails();
                                        //FactoryService.rawMaterial[] lst = null;
                                        if (dsdept.Tables[1].Rows.Count > 0)
                                        {
                                            DataTable dtraw = new DataTable();
                                            dtraw = dsdept.Tables[1];
                                            contractmulti = new LabourService.contractLabourPrincipalEmployerMultiData[dtraw.Rows.Count];

                                            for (int k = 0; k < dtraw.Rows.Count; k++)
                                            {
                                                //FactoryService.rawMaterial BBB = new FactoryService.rawMaterial();
                                                LabourService.contractLabourPrincipalEmployerMultiData coc = new LabourService.contractLabourPrincipalEmployerMultiData();
                                                coc.contractorAddress = dtraw.Rows[k]["Contractor_Address"].ToString();
                                                coc.commencementDate = dtraw.Rows[k]["Contractor_Est_Commence_Dt"].ToString();
                                                coc.terminationDate = dtraw.Rows[k]["Contractor_Est_Compltd_Dt"].ToString();
                                                //coc.m = dtraw.Rows[k]["Contractor_MobileNo"].ToString();
                                                coc.contractorName = dtraw.Rows[k]["Contractor_Name"].ToString();
                                                coc.maxcontractLabour = dtraw.Rows[k]["Contractor_MaxWorkers"].ToString();
                                                coc.natureOfWork = dtraw.Rows[k]["Contractor_Work_Nature"].ToString();
                                                coc.manufacturingDeptDetails = dtraw.Rows[k]["Contractor_ManufacturingDepts"].ToString();
                                                contractmulti[k] = coc;
                                                //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                                                //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                                            }
                                            contractvo.contractorParticulars = contractmulti;
                                            //rawvo.materialDescr
                                        }

                                        labouract.contractLabourPrincipalEmplyerActData = contractvo;
                                        labourout = labourservice.actSelected(labouract);
                                        if (labourout.status == "SUCCESS")
                                        {
                                            string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                            gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", labouroutmsg, "Y");
                                            int k = gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), contractvo.uID, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                                        }
                                        else
                                        {
                                            string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                            gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", labourouterrormsg, "N");
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (deptid == "49")
                        {
                            try
                            {
                                DataSet dsdept = new DataSet();
                                DataSet dsdeptattachments = new DataSet();
                                dsdept = gen.getdepartmentdetailsonuid(UIDNO, deptid);
                                LabourService.act labouract = new LabourService.act();
                                LabourService.actsResponse labourout = new LabourService.actsResponse();
                                LabourService.contractLabourPrincipalEmployer contractvo = new LabourService.contractLabourPrincipalEmployer();
                                LabourService.buildingotherconstructions labour = new LabourService.buildingotherconstructions();
                                LabourService.ismwPrincipalEmployer migrateemployer = new LabourService.ismwPrincipalEmployer();

                                string actids = "";
                                string actid = "";
                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                                {
                                    actids = dsdept.Tables[0].Rows[0]["LabourAct_Id"].ToString();
                                    string[] split = actids.Split(',');

                                    if (actids.Contains("4"))//Principal Employer Registration Under InterState Migrant Workman Act
                                    {
                                        labouract.interstateMigrantPrincipalEmplyerActSelected = true;
                                        migrateemployer.actID = "ISMWPEF";
                                        migrateemployer.bank_code = dsdept.Tables[0].Rows[0]["bank_code"].ToString();
                                        migrateemployer.bank_ref_number = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                        migrateemployer.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                        migrateemployer.cin = dsdept.Tables[0].Rows[0]["cin"].ToString();
                                        migrateemployer.compound_fee = 0;
                                        migrateemployer.director_district = dsdept.Tables[0].Rows[0]["Form1_4_Dir_District"].ToString();
                                        migrateemployer.director_door = dsdept.Tables[0].Rows[0]["Form1_4_Dir_DoorNo"].ToString();
                                        migrateemployer.director_mandal = dsdept.Tables[0].Rows[0]["Form1_4_Dir_Mandal"].ToString();
                                        migrateemployer.director_name = dsdept.Tables[0].Rows[0]["Form1_4_Dir_FullName"].ToString();
                                        migrateemployer.director_village = dsdept.Tables[0].Rows[0]["Form1_4_Dir_Village"].ToString();
                                        migrateemployer.employees_attachement = "";
                                        migrateemployer.entrepreneur_id = dsdept.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                                        migrateemployer.establishment_category = dsdept.Tables[0].Rows[0]["Form1_1_Estb_Category"].ToString();
                                        migrateemployer.establishment_category_others = dsdept.Tables[0].Rows[0]["Form1_1_Estb_Classification"].ToString();
                                        migrateemployer.establishment_name = dsdept.Tables[0].Rows[0]["Form1_Estb_Name"].ToString();
                                        migrateemployer.establishment_postal_district = dsdept.Tables[0].Rows[0]["Form1_Estd_District"].ToString();
                                        migrateemployer.establishment_postal_door = dsdept.Tables[0].Rows[0]["Form1_Estd_DoorNo"].ToString();
                                        migrateemployer.establishment_postal_locality = dsdept.Tables[0].Rows[0]["Form1_Estd_Locality"].ToString();
                                        migrateemployer.establishment_postal_mandal = dsdept.Tables[0].Rows[0]["Form1_Estd_Mandal"].ToString();
                                        migrateemployer.establishment_postal_village = dsdept.Tables[0].Rows[0]["Form1_Estd_Village"].ToString();
                                        migrateemployer.ipass_status_id = dsdept.Tables[0].Rows[0]["intStageid"].ToString();
                                        migrateemployer.manager_agent_district = dsdept.Tables[0].Rows[0]["Form1_1_Manager_District"].ToString();
                                        migrateemployer.manager_agent_door = dsdept.Tables[0].Rows[0]["Form1_1_Manager_DoorNo"].ToString();
                                        migrateemployer.manager_agent_mandal = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Mandal"].ToString();
                                        migrateemployer.manager_agent_name = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Name"].ToString();
                                        migrateemployer.manager_agent_village = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Village"].ToString();
                                        migrateemployer.max_employees_aday = dsdept.Tables[0].Rows[0]["Form1_2_MaxWorkers"].ToString();
                                        migrateemployer.nature_work = dsdept.Tables[0].Rows[0]["Form1_Nature_of_Business"].ToString();
                                        migrateemployer.other_attachments_1 = "";
                                        migrateemployer.other_attachments_2 = "";
                                        migrateemployer.payment_mode = dsdept.Tables[0].Rows[0]["payment_mode"].ToString();
                                        migrateemployer.paymentFlag = dsdept.Tables[0].Rows[0]["paymentFlag"].ToString();
                                        migrateemployer.penality_percentage = 0;
                                        migrateemployer.penality_years = 0;
                                        migrateemployer.previous_registered_act = "";
                                        migrateemployer.previous_registration_certificate = "";
                                        migrateemployer.previous_registration_no = "";
                                        migrateemployer.principal_employer_district = dsdept.Tables[0].Rows[0]["Form1_Employer_District"].ToString();
                                        migrateemployer.principal_employer_door = dsdept.Tables[0].Rows[0]["Form1_Employer_DoorNo"].ToString();
                                        migrateemployer.principal_employer_email = dsdept.Tables[0].Rows[0]["Form1_Employer_EmailID"].ToString();
                                        migrateemployer.principal_employer_fathername = dsdept.Tables[0].Rows[0]["Form1_Empolyer_FatherName"].ToString();
                                        migrateemployer.principal_employer_mandal = dsdept.Tables[0].Rows[0]["Form1_Employer_Mandal"].ToString();
                                        migrateemployer.principal_employer_mobile = dsdept.Tables[0].Rows[0]["Form1_Employer_MobileNo"].ToString();
                                        migrateemployer.principal_employer_name = dsdept.Tables[0].Rows[0]["Form1_Employer_Name"].ToString();
                                        migrateemployer.principal_employer_village = dsdept.Tables[0].Rows[0]["Form1_Employer_Village"].ToString();
                                        migrateemployer.projectSubmitDate = dsdept.Tables[0].Rows[0]["projectSubmitDate"].ToString();
                                        migrateemployer.questionnaire_id = dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                                        migrateemployer.registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                                        migrateemployer.registration_years = 0;
                                        migrateemployer.stageID = dsdept.Tables[0].Rows[0]["intStageid"].ToString();
                                        migrateemployer.total_amount_payable = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString());
                                        migrateemployer.total_penality_amount = 0;
                                        migrateemployer.total_registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                                        migrateemployer.totalAmount = dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString();
                                        migrateemployer.transaction_for = dsdept.Tables[0].Rows[0]["transaction_for"].ToString();
                                        migrateemployer.transaction_id = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                        migrateemployer.transaction_status = "Y";
                                        migrateemployer.transactionDate = dsdept.Tables[0].Rows[0]["transactionDate"].ToString();
                                        migrateemployer.transactionNumber = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                        migrateemployer.type_of_application = dsdept.Tables[0].Rows[0]["type_of_application"].ToString();
                                        migrateemployer.uID = dsdept.Tables[0].Rows[0]["UID_NO"].ToString();
                                        migrateemployer.unpaid_balance_welfare = Convert.ToInt32(dsdept.Tables[0].Rows[0]["unpaid_balance_welfare"].ToString());
                                        migrateemployer.valid_from_date = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                                        migrateemployer.valid_to_date = dsdept.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();

                                        LabourService.ismwPrincipalEmployerMultiData[] migrantvo = null;
                                        ContractorDetails co = new ContractorDetails();
                                        //FactoryService.rawMaterial[] lst = null;
                                        if (dsdept.Tables[1].Rows.Count > 0)
                                        {
                                            DataTable dtraw = new DataTable();
                                            dtraw = dsdept.Tables[1];
                                            migrantvo = new LabourService.ismwPrincipalEmployerMultiData[dtraw.Rows.Count];

                                            for (int k = 0; k < dtraw.Rows.Count; k++)
                                            {
                                                //FactoryService.rawMaterial BBB = new FactoryService.rawMaterial();
                                                LabourService.ismwPrincipalEmployerMultiData coc = new LabourService.ismwPrincipalEmployerMultiData();
                                                coc.contractorAddress = dtraw.Rows[k]["Contractor_Address"].ToString();
                                                coc.commencementDate = dtraw.Rows[k]["Contractor_Est_Commence_Dt"].ToString();
                                                coc.terminationDate = dtraw.Rows[k]["Contractor_Est_Compltd_Dt"].ToString();
                                                //coc.m = dtraw.Rows[k]["Contractor_MobileNo"].ToString();
                                                coc.contractorName = dtraw.Rows[k]["Contractor_Name"].ToString();
                                                coc.maxcontractLabour = dtraw.Rows[k]["Contractor_MaxWorkers"].ToString();
                                                coc.natureOfWork = dtraw.Rows[k]["Contractor_Work_Nature"].ToString();
                                                coc.manufacturingDeptDetails = dtraw.Rows[k]["Contractor_ManufacturingDepts"].ToString();
                                                coc.mobileNo = dtraw.Rows[k]["Contractor_MobileNo"].ToString();
                                                migrantvo[k] = coc;
                                                //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                                                //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                                            }
                                            migrateemployer.contractorParticulars = migrantvo;
                                            //rawvo.materialDescr
                                        }

                                        labouract.interstateMigrantPrincipalEmplyerActData = migrateemployer;
                                        labourout = labourservice.actSelected(labouract);
                                        if (labourout.status == "SUCCESS")
                                        {
                                            string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                            gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", labouroutmsg, "Y");
                                            int k = gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), migrateemployer.uID, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                                        }
                                        else
                                        {
                                            string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                            gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", labourouterrormsg, "N");
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (deptid == "8")// FIRE
                        {
                            try
                            {
                                string valuefire = "";
                                string outputfire = "";
                                string fireattachments = "";
                                string outapplicant = "";
                                string outapplicant1 = "";
                                string outescapre = "";
                                DataSet dsdept = new DataSet();
                                DataSet dsfire = new DataSet();
                                DataSet dsfireescape = new DataSet();
                                DataSet dsdeptattachments = new DataSet();
                                dsdept = gen.getdepartmentdetailsonuid(UIDNO, deptid);
                                valuefire = dsdept.GetXml();
                                string output = fire.InsertApplicantFireDetails(valuefire);
                                string[] split = output.Split('-');
                                string applid = split[1];
                                dsfire = gen.getfiremeanofescapedetailsonuid(UIDNO, applid);
                                if (dsfire != null && dsfire.Tables.Count > 0 && dsfire.Tables[0].Rows.Count > 0)
                                {
                                    DataTable dtfire = new DataTable();
                                    DataTable dtfirenew = new DataTable();
                                    dtfire = dsfire.Tables[1];
                                    dtfirenew = dsfire.Tables[2];
                                    dsfire.Tables.Remove(dtfire);
                                    dsfire.Tables.Remove(dtfirenew);
                                    string fireescape = "";
                                    fireescape = dsfire.GetXml();
                                    outescapre = fire.StoreMeansOfEscape(fireescape);
                                }
                                DataSet dsfire1 = new DataSet();
                                dsfire1 = gen.getfiremeanofescapedetailsonuid(UIDNO, applid);
                                if (dsfire1 != null && dsfire1.Tables.Count > 0 && dsfire1.Tables[0].Rows.Count > 0)
                                {
                                    DataTable dtfire1 = new DataTable();
                                    DataTable dtfire1new = new DataTable();
                                    dtfire1 = dsfire1.Tables[0];
                                    dtfire1new = dsfire1.Tables[2];
                                    dsfire1.Tables.Remove(dtfire1);
                                    dsfire1.Tables.Remove(dtfire1new);

                                    string fireapplicant = "";
                                    fireapplicant = dsfire1.GetXml();
                                    outapplicant = fire.StoreFloorwiseApplicantDtls(fireapplicant);
                                }
                                DataSet dsfire2 = new DataSet();
                                dsfire2 = gen.getfiremeanofescapedetailsonuid(UIDNO, applid);
                                if (dsfire2 != null && dsfire2.Tables.Count > 0 && dsfire2.Tables[0].Rows.Count > 0)
                                {
                                    DataTable dtfire2 = new DataTable();
                                    DataTable dtfire2new = new DataTable();
                                    dtfire2 = dsfire2.Tables[1];
                                    dtfire2new = dsfire2.Tables[0];
                                    dsfire2.Tables.Remove(dtfire2);
                                    dsfire2.Tables.Remove(dtfire2new);

                                    string firefight = "";
                                    firefight = dsfire2.GetXml();
                                    outapplicant1 = fire.StoreFireFightingInstallations(firefight);
                                }

                                DataSet dsdeptattachmentsfire = new DataSet();
                                dsdeptattachmentsfire = gen.getattachmentdetailsonuid(UIDNO, deptid, applid);
                                fireattachments = dsdeptattachmentsfire.GetXml();
                                outputfire = fire.StoreUploadDocuments(fireattachments);
                                //StringReader str1 = new StringReader(outputfire);
                                //DataSet dsout1 = new DataSet();
                                //dsout1.ReadXml(str1);
                                if (split[0] == "Success" && outescapre == "Success" && outapplicant == "Success" && outapplicant1 == "Success" && outputfire == "Success")
                                {
                                    gen.UpdateDepartwebserviceflag(UIDNO, deptid, "A", outapplicant, "Y");
                                    gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", outapplicant, "Y");
                                    int k = gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["QuestionnaireId"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                                }
                                else
                                {
                                    string outputerror = split[0].ToString() + ',' + outescapre + ',' + outapplicant + ',' + outapplicant1 + ',' + outputfire;
                                    gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", outputerror, "N");
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (deptid == "4" || deptid == "41")//NPDCL
                        {
                            try
                            {
                                string valueNPDCL = "";
                                string outputnpdcl = "";
                                string npdclattachments = "";
                                DataSet dsdept = new DataSet();
                                DataSet dsdeptattachments = new DataSet();
                                dsdept = gen.getdepartmentdetailsonuid(UIDNO, deptid);
                                valueNPDCL = dsdept.GetXml();
                                outputnpdcl = tsnpdcl.insertTsipassUidDetaisls(valueNPDCL);
                                StringReader str = new StringReader(outputnpdcl);
                                DataSet dsout = new DataSet();
                                dsout.ReadXml(str);
                                if (dsout != null && dsout.Tables.Count > 0 && dsout.Tables[0].Rows.Count > 0)
                                {
                                    if (dsout.Tables[0].Columns.Contains("status"))
                                    {
                                        if (dsout.Tables[0].Rows[0]["status"].ToString() == "S")
                                        {
                                            string npdclout = dsout.Tables[0].Rows[0]["status"].ToString();
                                            gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", npdclout, "Y");
                                        }
                                        else
                                        {
                                            string npdclouterror = dsout.Tables[0].Rows[0]["status"].ToString();
                                            gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", npdclouterror, "Y");
                                        }
                                    }
                                }
                                dsdeptattachments = gen.getattachmentdetailsonuid(UIDNO, deptid, "");
                                npdclattachments = dsdeptattachments.GetXml();
                                outputnpdcl = tsnpdcl.insertAllAttachments(npdclattachments);
                                StringReader str1 = new StringReader(outputnpdcl);
                                DataSet dsout1 = new DataSet();
                                dsout1.ReadXml(str1);
                                if (dsout1 != null && dsout1.Tables.Count > 0 && dsout1.Tables[0].Rows.Count > 0)
                                {
                                    if (dsout1.Tables[0].Columns.Contains("status"))
                                    {
                                        if (dsout1.Tables[0].Rows[0]["status"].ToString() == "S")
                                        {
                                            string npdclsattachment = dsout1.Tables[0].Rows[0]["status"].ToString();
                                            gen.UpdateDepartwebserviceflag(UIDNO, deptid, "A", npdclsattachment, "Y");
                                            int k = gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["deptId"].ToString(), dsdept.Tables[0].Rows[0]["questionniareId"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                                        }
                                        else
                                        {
                                            string npdclsattachmenterror = dsout1.Tables[0].Rows[0]["status"].ToString();
                                            gen.UpdateDepartwebserviceflag(UIDNO, deptid, "A", npdclsattachmenterror, "N");
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (deptid == "25") // SPDCL
                        {
                            try
                            {
                                DataSet dsdept = new DataSet();
                                string valuesPDCL = "";
                                string outputspdcl = "";
                                dsdept = gen.getdepartmentdetailsonuid(UIDNO, deptid);
                                valuesPDCL = dsdept.GetXml();
                                outputspdcl = tsspdcl.setPowerRegistration(valuesPDCL);
                                StringReader str = new StringReader(outputspdcl);
                                DataSet dsout = new DataSet();
                                dsout.ReadXml(str);
                                if (dsout != null && dsout.Tables.Count > 0 && dsout.Tables[0].Rows.Count > 0)
                                {
                                    if (dsout.Tables[0].Columns.Contains("RESULT"))
                                    {
                                        if (dsout.Tables[0].Rows[0]["RESULT"].ToString() == "Success")
                                        {
                                            string spdcloutmsg = dsout.Tables[0].Rows[0]["RESULT"].ToString();
                                            gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", spdcloutmsg, "Y");
                                            int k = gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                                        }
                                        else
                                        {
                                            string spdcloutmsgerror = dsout.Tables[0].Rows[0]["RESULT"].ToString();
                                            gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", spdcloutmsgerror, "N");
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }


                        if (deptid == "21" || deptid == "5")//FACTORIES
                        {
                            try
                            {
                                FactoryService.plan factoryvo = new FactoryService.plan();
                                FactoryService.rawMaterial rawvo = new FactoryService.rawMaterial();


                                string outputfactory = "";
                                string valuefactory = "";
                                DataSet dsdept = new DataSet();
                                dsdept = gen.getdepartmentdetailsonuid(UIDNO, deptid);
                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                                {
                                    valuefactory = dsdept.GetXml();
                                    //outputfactory = factory.insertIntoPlanApproval(factoryvo);
                                    factoryvo.amountToBePaid = dsdept.Tables[0].Rows[0]["Approval_Fee"].ToString();
                                    factoryvo.applicationID = dsdept.Tables[0].Rows[0]["UID_No"].ToString();
                                    factoryvo.applicationStageID = dsdept.Tables[0].Rows[0]["intstageid"].ToString();
                                    factoryvo.applicationStatus = "Pre-Scuitiny Pending"; //dsdept.Tables[0].Columns[""].ToString();
                                    factoryvo.applicationSubmittedDate = dsdept.Tables[0].Rows[0]["UID_NOGenerateDate"].ToString();
                                    factoryvo.bankAmount = dsdept.Tables[0].Rows[0]["Online_Amount"].ToString();
                                    factoryvo.bankDate = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                    factoryvo.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                    factoryvo.challanNumber = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                    factoryvo.communicationAddress = dsdept.Tables[0].Rows[0]["communicationAddress"].ToString();
                                    factoryvo.entrepreneurID = dsdept.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                                    factoryvo.factoryDistrictID = dsdept.Tables[0].Rows[0]["Land_intDistrictid"].ToString();
                                    factoryvo.factoryLocality = dsdept.Tables[0].Rows[0]["Name_Gramapachayat"].ToString();
                                    factoryvo.factoryDoorNumber = dsdept.Tables[0].Rows[0]["SurveyNo"].ToString();
                                    factoryvo.factoryMandalID = dsdept.Tables[0].Rows[0]["Land_intMandalid"].ToString();
                                    factoryvo.factoryName = dsdept.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();
                                    factoryvo.factoryPinCode = dsdept.Tables[0].Rows[0]["Land_Pincode"].ToString();
                                    factoryvo.factoryVillageID = dsdept.Tables[0].Rows[0]["Land_intVillageid"].ToString();
                                    factoryvo.hazardousNature = dsdept.Tables[0].Rows[0]["TypeofFactory"].ToString();
                                    factoryvo.installedHP = dsdept.Tables[0].Rows[0]["Connect_Load_B"].ToString();
                                    factoryvo.mailID = dsdept.Tables[0].Rows[0]["Land_Email"].ToString();
                                    factoryvo.mobileNumber = dsdept.Tables[0].Rows[0]["MobileNumber"].ToString();
                                    factoryvo.paymentStatus = dsdept.Tables[0].Rows[0]["PaymentFlag"].ToString();
                                    factoryvo.planReferenceNumber = "NA";//dsdept.Tables[0].Columns[""].ToString();
                                    factoryvo.planType = dsdept.Tables[0].Rows[0]["ProposalFor"].ToString();
                                    factoryvo.questionaireID = dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                                    factoryvo.ssiType = "0";// dsdept.Tables[0].Columns[""].ToString();
                                    factoryvo.systemIP = "0.0.0.0";// dsdept.Tables[0].Columns[""].ToString();
                                    factoryvo.userID = dsdept.Tables[0].Rows[0]["CREATEDBY"].ToString();
                                    factoryvo.workersToBeEmployedMen = dsdept.Tables[0].Rows[0]["DirectMale"].ToString();
                                    factoryvo.workersToBeEmployedWomen = dsdept.Tables[0].Rows[0]["DirectFemale"].ToString();

                                    FactoryService.rawMaterial[] lst = null;
                                    if (dsdept.Tables[1].Rows.Count > 0)
                                    {
                                        DataTable dtraw = new DataTable();
                                        dtraw = dsdept.Tables[1];
                                        lst = new FactoryService.rawMaterial[dtraw.Rows.Count];

                                        for (int k = 0; k < dtraw.Rows.Count; k++)
                                        {
                                            FactoryService.rawMaterial BBB = new FactoryService.rawMaterial();
                                            BBB.materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                                            lst[k] = BBB;
                                            //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                                            //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                                        }
                                        //rawvo.materialDescr
                                    }

                                    factoryvo.rawMaterials = lst;

                                    FactoryService.productsOutput[] product = null;
                                    if (dsdept.Tables[1].Rows.Count > 0)
                                    {
                                        DataTable dtproduct = new DataTable();
                                        dtproduct = dsdept.Tables[2];
                                        product = new FactoryService.productsOutput[dtproduct.Rows.Count];

                                        for (int m = 0; m < dtproduct.Rows.Count; m++)
                                        {
                                            FactoryService.productsOutput productvo = new FactoryService.productsOutput();
                                            productvo.product = dtproduct.Rows[m]["Manf_ItemName"].ToString();
                                            productvo.output = dtproduct.Rows[m]["OUTPUT"].ToString();
                                            product[m] = productvo;
                                        }
                                    }

                                    factoryvo.productsOutputs = product;

                                    FactoryService.saleLeaseDeed[] registrationdeed = null;
                                    FactoryService.sitePlan[] siteplan = null;
                                    FactoryService.buildingPlan[] buildingplan = null;
                                    FactoryService.partnershipDeed[] partnershipdeed = null;
                                    FactoryService.processFlowChart[] flowchat = null;
                                    FactoryService.panAadharCard[] panaadhar = null;
                                    //factory.insertIntoPlanApprovalCompleted factoryoutput = new FactoryService.insertIntoPlanApprovalCompletedEventHandler();


                                    DataSet dsfactroy = new DataSet();
                                    dsfactroy = gen.getattachmentdetailsonuid(UIDNO, deptid, "");

                                    if (dsfactroy != null && dsfactroy.Tables.Count > 0 && dsfactroy.Tables[0].Rows.Count > 0)
                                    {
                                        ///Registration Deed////

                                        if (dsfactroy.Tables[0].Rows.Count > 0)
                                        {
                                            DataTable dtregistrationdeed = new DataTable();
                                            dtregistrationdeed = dsfactroy.Tables[0];
                                            registrationdeed = new FactoryService.saleLeaseDeed[dtregistrationdeed.Rows.Count];

                                            for (int n = 0; n < dtregistrationdeed.Rows.Count; n++)
                                            {
                                                FactoryService.saleLeaseDeed registrationdeedvo = new FactoryService.saleLeaseDeed();
                                                registrationdeedvo.documentName = dtregistrationdeed.Rows[n]["FileName"].ToString();
                                                registrationdeedvo.documentPath = dtregistrationdeed.Rows[n]["Filepath"].ToString();
                                                registrationdeed[n] = registrationdeedvo;
                                            }
                                        }
                                        if (dsfactroy.Tables[1].Rows.Count > 0)
                                        {
                                            DataTable dtsiteplan = new DataTable();
                                            dtsiteplan = dsfactroy.Tables[1];
                                            siteplan = new FactoryService.sitePlan[dtsiteplan.Rows.Count];

                                            for (int o = 0; o < dtsiteplan.Rows.Count; o++)
                                            {
                                                FactoryService.sitePlan siteplanvo = new FactoryService.sitePlan();
                                                siteplanvo.documentName = dtsiteplan.Rows[o]["FileName"].ToString();
                                                siteplanvo.documentPath = dtsiteplan.Rows[o]["Filepath"].ToString();
                                                siteplan[o] = siteplanvo;
                                            }
                                        }
                                        if (dsfactroy.Tables[2].Rows.Count > 0)
                                        {
                                            DataTable dtbuildingplan = new DataTable();
                                            dtbuildingplan = dsfactroy.Tables[2];
                                            buildingplan = new FactoryService.buildingPlan[dtbuildingplan.Rows.Count];

                                            for (int p = 0; p < dtbuildingplan.Rows.Count; p++)
                                            {
                                                FactoryService.buildingPlan buildingplanvo = new FactoryService.buildingPlan();
                                                buildingplanvo.documentName = dtbuildingplan.Rows[p]["FileName"].ToString();
                                                buildingplanvo.documentPath = dtbuildingplan.Rows[p]["Filepath"].ToString();
                                                buildingplan[p] = buildingplanvo;
                                            }
                                        }
                                        if (dsfactroy.Tables[3].Rows.Count > 0)
                                        {
                                            DataTable dtpartnershipdeed = new DataTable();
                                            dtpartnershipdeed = dsfactroy.Tables[3];
                                            partnershipdeed = new FactoryService.partnershipDeed[dtpartnershipdeed.Rows.Count];

                                            for (int n = 0; n < dtpartnershipdeed.Rows.Count; n++)
                                            {
                                                FactoryService.partnershipDeed partnershipdeedvo = new FactoryService.partnershipDeed();
                                                partnershipdeedvo.documentName = dtpartnershipdeed.Rows[n]["FileName"].ToString();
                                                partnershipdeedvo.documentPath = dtpartnershipdeed.Rows[n]["Filepath"].ToString();
                                                partnershipdeed[n] = partnershipdeedvo;
                                            }
                                        }
                                        if (dsfactroy.Tables[4].Rows.Count > 0)
                                        {
                                            DataTable dtflowchat = new DataTable();
                                            dtflowchat = dsfactroy.Tables[4];
                                            flowchat = new FactoryService.processFlowChart[dtflowchat.Rows.Count];

                                            for (int n = 0; n < dtflowchat.Rows.Count; n++)
                                            {
                                                FactoryService.processFlowChart flowchatvo = new FactoryService.processFlowChart();
                                                flowchatvo.documentName = dtflowchat.Rows[n]["FileName"].ToString();
                                                flowchatvo.documentPath = dtflowchat.Rows[n]["Filepath"].ToString();
                                                flowchat[n] = flowchatvo;
                                            }
                                        }
                                        if (dsfactroy.Tables[5].Rows.Count > 0)
                                        {
                                            DataTable dtpanaadhar = new DataTable();
                                            dtpanaadhar = dsfactroy.Tables[5];
                                            panaadhar = new FactoryService.panAadharCard[dtpanaadhar.Rows.Count];

                                            for (int n = 0; n < dtpanaadhar.Rows.Count; n++)
                                            {
                                                FactoryService.panAadharCard panaadharvo = new FactoryService.panAadharCard();
                                                panaadharvo.documentName = dtpanaadhar.Rows[n]["FileName"].ToString();
                                                panaadharvo.documentPath = dtpanaadhar.Rows[n]["Filepath"].ToString();
                                                panaadhar[n] = panaadharvo;
                                            }
                                        }
                                    }
                                    factoryvo.saleLeaseDeeds = registrationdeed;
                                    factoryvo.sitePlans = siteplan;
                                    factoryvo.buildingPlans = buildingplan;
                                    factoryvo.partnershipDeeds = partnershipdeed;
                                    factoryvo.processFlowCharts = flowchat;
                                    factoryvo.panAadharCards = panaadhar;

                                    string OUTPUT = factory.insertIntoPlanApproval(factoryvo);
                                    // factory.insertIntoPlanApprovalCompleted 
                                    //factory.insertIntoPlanApproval(factoryvo);
                                    // factory.insertIntoPlanApprovalCompleted = factory.insertIntoPlanApproval(factoryvo);
                                    //factory.insertIntoPlanApprovalCompleted = factory.insertIntoPlanApproval(factoryvo);
                                    if (OUTPUT == "SUCCESS")
                                    {

                                        gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", OUTPUT, "Y");
                                        gen.UpdateDepartwebserviceflag(UIDNO, deptid, "A", OUTPUT, "Y");
                                        int k = gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                                    }
                                    else
                                    {
                                        gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", OUTPUT, "N");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }

                    }


                }
                // additional Payment Dtls
                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    DataTable dtadd = new DataTable();
                    dtadd = ds.Tables[1];
                    for (int i = 0; i < dtadd.Rows.Count; i++)
                    {
                        string deptid = dtadd.Rows[i]["intApprovalid"].ToString();
                        if (deptid == "20")//PCB Additional Amount
                        {
                            DataSet dsdept = new DataSet();

                            dsdept = gen.getdepartmentdetailsonuid(UIDNO, deptid);
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                            {
                                string cafUniqueNo = dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                                string transactionId = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                string amount = dsdept.Tables[0].Rows[0]["Approval_Fee"].ToString();
                                string bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                string transactionStatus = "S";
                                string paymentType = "NB";
                                string indApplication = dsdept.Tables[0].Rows[0]["NICApplicationno"].ToString();
                                string additionalPayment = "T";


                                string WEBSERVICE_URL1 = "http://tsocmms.nic.in/TLWS/updateCl?cafUniqueNo=" + cafUniqueNo + "&indApplicationNo=" + indApplication + "&remark=" + "AdditionalAmountSubmitted" + "&urlSingle=" + "";

                                try
                                {
                                    var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL1);
                                    if (webRequest != null)
                                    {
                                        webRequest.Method = "GET";
                                        webRequest.Timeout = 20000;
                                        webRequest.ContentType = "application/x-www-form-urlencoded";

                                        //using (System.IO.Stream s = webRequest.GetRequestStream())
                                        //{
                                        //    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(s))
                                        //        sw.Write(jsonData);
                                        //}

                                        using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                                        {
                                            using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                                            {
                                                var jsonResponse = sr.ReadToEnd();
                                                System.Diagnostics.Debug.WriteLine(String.Format("Response: {0}", jsonResponse));
                                                if (jsonResponse.Contains("submitted successfully"))
                                                {
                                                    //gen.UpdateDepartwebserviceflag(UIDNO, deptid, "AP", jsonResponse, "Y");
                                                }
                                                else
                                                {
                                                    //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                                    //gen.UpdateDepartwebserviceflag(UIDNO, deptid, "AP", jsonResponse, "N");
                                                }
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                                }


                                string WEBSERVICE_URL = "http://tsocmms.nic.in/TLWS/updateFee?cafUniqueNo=" + cafUniqueNo + "&transactionId=" + transactionId + "&amount=" + amount + "&bankName=" + bankName + "&transactionStatus=" + transactionStatus + "&paymentType=" + paymentType + "&indApplicationNo=" + indApplication + "&additionalPayment=" + additionalPayment + "";


                                //string jsonData = "{\"cafUniqueNo\" : \""+cafUniqueNo+"\", \"transactionId\":\""+transactionId+"\" , \"amount\":\""+amount+"\" , \"bankName\":\""+bankName+"\" , \"transactionStatus\":\"S\" , \"paymentType\":\"NB\"}";
                                //string jsonData = "cafUniqueNo" : \"" + cafUniqueNo + "\", \"transactionId\":\"" + transactionId + "\" , \"amount\":\"" + amount + "\" , \"bankName\":\"" + bankName + "\" , \"transactionStatus\":\"S\" , \"paymentType\":\"NB\"}";
                                try
                                {
                                    var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
                                    if (webRequest != null)
                                    {
                                        webRequest.Method = "GET";
                                        webRequest.Timeout = 20000;
                                        webRequest.ContentType = "application/x-www-form-urlencoded";

                                        //using (System.IO.Stream s = webRequest.GetRequestStream())
                                        //{
                                        //    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(s))
                                        //        sw.Write(jsonData);
                                        //}

                                        using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                                        {
                                            using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                                            {
                                                var jsonResponse = sr.ReadToEnd();
                                                System.Diagnostics.Debug.WriteLine(String.Format("Response: {0}", jsonResponse));
                                                if (jsonResponse.Contains("Fee submitted successfully"))
                                                {
                                                    gen.UpdateDepartwebserviceflag(UIDNO, deptid, "AP", jsonResponse, "Y");
                                                }
                                                else
                                                {
                                                    //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                                    //gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", jsonResponse, "N");
                                                    gen.UpdateDepartwebserviceflag(UIDNO, deptid, "AP", jsonResponse, "N");
                                                }
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                                }

                            }

                        }
                        if (deptid == "21" || deptid == "5") //FACTORY
                        {
                            try
                            {
                                string outputfactory = "";
                                string valuefactory = "";
                                DataSet dsdept = new DataSet();
                                dsdept = gen.getAdditionalPaymentDetails(UIDNO, deptid);
                                valuefactory = dsdept.GetXml();
                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                                {
                                    FactoryService.planAdditionalPayment factoryvo = new FactoryService.planAdditionalPayment();
                                    factoryvo.applicationID = dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                    factoryvo.bankAmount = dsdept.Tables[0].Rows[0]["Online_Amount"].ToString();
                                    factoryvo.bankDate = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                    factoryvo.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                    factoryvo.challanNumber = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                    factoryvo.paymentStatus = dsdept.Tables[0].Rows[0]["PaymentFlag"].ToString();
                                    factoryvo.systemIP = "0.0.0.0";//dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                    factoryvo.userID = dsdept.Tables[0].Rows[0]["Created_by"].ToString();
                                    string outfactory = factory.insertIntoPlanApprovalAdditionalPayment(factoryvo);

                                    if (outfactory == "SUCCESS")
                                    {

                                        gen.UpdateDepartwebserviceflag(UIDNO, deptid, "AP", outfactory, "Y");

                                    }
                                    else
                                    {
                                        gen.UpdateDepartwebserviceflag(UIDNO, deptid, "AP", outfactory, "N");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (deptid == "8")
                        {
                            try
                            {
                                DataSet dsdept = new DataSet();
                                dsdept = gen.getAdditionalPaymentDetails(UIDNO, deptid);
                                string UIDNo = dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                string amount = dsdept.Tables[0].Rows[0]["Online_Amount"].ToString();
                                string date = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                string bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                string challanNumber = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                string paymentStatus = dsdept.Tables[0].Rows[0]["PaymentFlag"].ToString();
                                string systemIP = "0.0.0.0";//dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                //string userID = dsdept.Tables[0].Rows[0]["Created_by"].ToString();

                                string outputfire = fire.PaymentDetails(UIDNo, challanNumber, date, bankName, amount);

                                if (outputfire == "Success")
                                {
                                    gen.UpdateDepartwebserviceflag(UIDNO, deptid, "AP", outputfire, "Y");
                                }
                                else
                                {
                                    gen.UpdateDepartwebserviceflag(UIDNO, deptid, "AP", outputfire, "N");
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (deptid == "4")
                        {
                            try
                            {
                                DataSet dsdept = new DataSet();
                                dsdept = gen.getAdditionalPaymentDetails(UIDNO, deptid);
                                string npdcl = dsdept.GetXml();

                                string npdclout = tsnpdcl.insertTsipassOnlinePayments(npdcl);
                                StringReader str = new StringReader(npdclout);
                                DataSet dsout = new DataSet();
                                dsout.ReadXml(str);
                                if (dsout != null && dsout.Tables.Count > 0 && dsout.Tables[0].Rows.Count > 0)
                                {
                                    if (dsout.Tables[0].Columns.Contains("status"))
                                    {
                                        if (dsout.Tables[0].Rows[0]["status"].ToString() == "S")
                                        {
                                            string npdcloutflag = dsout.Tables[0].Rows[0]["status"].ToString();
                                            gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", npdclout, "Y");
                                        }
                                        else
                                        {
                                            string npdclouterror = dsout.Tables[0].Rows[0]["status"].ToString();
                                            gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", npdclouterror, "Y");
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (deptid == "25") // SPDCL
                        {
                            try
                            {
                                DataSet dsdept = new DataSet();
                                string valuesPDCL = "";
                                string outputspdcl = "";
                                dsdept = gen.getAdditionalPaymentDetails(UIDNO, deptid);
                                valuesPDCL = dsdept.GetXml();
                                string UIDNo = dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                double amount = Convert.ToDouble(dsdept.Tables[0].Rows[0]["Online_Amount"].ToString());
                                string date = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                string bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                string challanNumber = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                string paymentStatus = dsdept.Tables[0].Rows[0]["PaymentFlag"].ToString();
                                string systemIP = "0.0.0.0";//dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                outputspdcl = tsspdcl.setPayment(UIDNo, amount, true, bankName, challanNumber, date);
                                StringReader strSPDCL = new StringReader(outputspdcl);
                                DataSet dsoutSPDCL = new DataSet();
                                dsoutSPDCL.ReadXml(strSPDCL);
                                if (dsoutSPDCL != null && dsoutSPDCL.Tables.Count > 0 && dsoutSPDCL.Tables[0].Rows.Count > 0)
                                {
                                    if (dsoutSPDCL.Tables[0].Columns.Contains("RESULT"))
                                    {
                                        if (dsoutSPDCL.Tables[0].Rows[0]["RESULT"].ToString() == "Success")
                                        {
                                            string spdcloutmsg = dsoutSPDCL.Tables[0].Rows[0]["RESULT"].ToString();
                                            gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", spdcloutmsg, "Y");
                                        }
                                        else
                                        {
                                            string spdcloutmsgerror = dsoutSPDCL.Tables[0].Rows[0]["RESULT"].ToString();
                                            gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", spdcloutmsgerror, "N");
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    }
                }
                StringBuilder sbScript = new StringBuilder();
                string sScript;
                sbScript.Append("<script>");
                sbScript.Append(" window.close();");
                sbScript.Append("</script>");

                sScript = sbScript.ToString();

                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", sScript, false);
            }
            // }
        }
        catch (Exception ex)
        {
            //  lblmsg.Text = ex.Message;
            //lblmsg.Visible = true;
        }
    }
}