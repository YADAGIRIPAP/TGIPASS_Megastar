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
using System.Threading;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

public partial class UI_TSiPASS_IpassPrintReceiptCFO : System.Web.UI.Page
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
    comFunctions obcmf = new comFunctions();
    General gen = new General();
    WebClient wc = new WebClient();

    BoilerService.TSBoilerServiceImplService Boiler = new BoilerService.TSBoilerServiceImplService();
    LabourCFOService.TSLabourServiceImplService labourserviceCfo = new LabourCFOService.TSLabourServiceImplService();
    // LabourService.TSLabourServiceImplService labourservice = new LabourService.TSLabourServiceImplService();
    FireServiceCFO.Service1 firecfo = new FireServiceCFO.Service1();
    FactoryServiceCFO.TSFactoryServiceImplService factorycfo = new FactoryServiceCFO.TSFactoryServiceImplService();
    CEIGCFOService.ApplicationServiceImplService ceigcfo = new CEIGCFOService.ApplicationServiceImplService();
   
    TSIICService.tsipass tsiicservice = new TSIICService.tsipass();
    TSIICService.ApplicationFormResponse responcetsiic = new TSIICService.ApplicationFormResponse();
    #endregion
    #region "Page_Load"
    protected void Page_Load(object sender, EventArgs e)
    {

        //Session["Amount"] = "002.52";
        //Session["RefNo"] = "CIT";
        //Session["TranRefNo"] = "JPMP5417043317";
        try
        {
            //Webservices("SML020000816545CFO");
           // return;
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
                        // txttotal.Text = amount;

                        txttotal.Text = Convert.ToDecimal(amount).ToString("#,##0") + " /-";

                        //string message = "Thank you for payment  Rs." + amount + " for this UID " + txtasmtno.Text + " of TxnID " + TranRefNo + "-TSIPass";

                        string message = "Thank you for making the Payment of Rs." + txttotal.Text + " for this UID " + txtasmtno.Text + " of TxnID " + TranRefNo + "- TSIPass";
                        if (lblMobileNumber.Text != "")
                        {
                            try
                            {
                                obcmf.SendSingleSMSnew(lblMobileNumber.Text, message, "1007856775026438504");
                               //SendSingleSMS(lblMobileNumber.Text, message);
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (txtEmailId.Text != "")
                        {
                            //var sb = new StringBuilder();
                            //Receipt.RenderControl(new HtmlTextWriter(new StringWriter(sb)));

                            //string s = sb.ToString();


                            ////StringWriter stringWriter = new StringWriter();
                            ////HtmlTextWriter htmlTextWriterw = new HtmlTextWriter(stringWriter);
                            ////Receipt.RenderControl(htmlTextWriterw);
                            //s = s.Replace("px", "");

                            //s = s.Replace("<img src=\"../../Resource/Images/telanganalogo.png\" height=\"60\" width=\"60\" />", "");

                            //StringReader stringReader = new StringReader(s.ToString());
                            //Document pdfDoc = new Document(PageSize.A4, 30f, 25f, 15f, 0.2f);
                            //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                            //MemoryStream memoryStream = new MemoryStream();
                            //PdfWriter.GetInstance(pdfDoc, memoryStream);
                            //pdfDoc.Open();
                            //htmlparser.Parse(stringReader);
                            //pdfDoc.Close();
                            //byte[] bytes = memoryStream.ToArray();
                            //memoryStream.Close();
                            //try
                            //{
                            //    SendingEmailWithAttachment(txtEmailId.Text, message, bytes);
                            //}
                            //catch (Exception ex)
                            //{

                            //}

                            try
                            {
                                //SendingEmailWithAttachment(txtEmailId.Text, message, bytes);
                                string messageMail = " Thank you for making the Payment of Rs. " + txttotal.Text + " ( " + lblnum2wrds.Text + " ) for the UID : " + txtasmtno.Text + ". Please find the attached payment receipt. ";
                                messageMail = messageMail + "Please check the status of your application in Track your application available in your login.";
                                messageMail = messageMail + "Further communication regarding your application from the dept’s will be sent to you through Mail & SMS. For any queries call 040-23441636.";
                                GeneratePdf(txtEmailId.Text, messageMail);
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        //ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<Script>window.open('EncloserList.aspx','popUpWindow','height=600,width=850,status=no,toolbar=no,menubar=no,location=no');</Script>", false);
                       // ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<Script>window.open('DepartmentServiceCFO.aspx?UIDNO=" + txtasmtno.Text + "','popUpWindow','height=0,width=1,status=no,toolbar=no,menubar=no,location=no');</Script>", false);

                        try
                        {
                           Webservices(txtasmtno.Text);
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
            //System.Net.NetworkCredential cred = new System.Net.NetworkCredential("tsipass.telangana@gmail.com", "tsipass@2016");
            //System.Net.NetworkCredential cred = new System.Net.NetworkCredential("tsipass.telangana@gmail.com", "zwcq vlxk gyor lpeg");
            System.Net.NetworkCredential cred = new System.Net.NetworkCredential("tsipass.telangana@gmail.com", "fqeq nive azke giwb");
            mail.To.Add(receiverMailId);
           // mail.From = new MailAddress("tsipass.telangana@gmail.com", "tsipass@2016");
           // mail.From = new MailAddress("tsipass.telangana@gmail.com", "zwcq vlxk gyor lpeg");
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
    //#region "Sending SMS to Specified Mobile Number"
    ///// <summary>
    ///// Method for Sending SMS to Specified Mobile Number
    ///// </summary>
    ///// <returns>string</returns>       
    //private string SendSingleSMS(String mobileNo, String message)
    //{
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
    //            "&content=" + HttpUtility.UrlEncode("Payment Conformation from TSIPASS:" + message) +
    //            "&mobileno=" + HttpUtility.UrlEncode(mobileNo) +
    //            "&senderid=" + HttpUtility.UrlEncode(senderid);

    //        byte[] byteArray = Encoding.ASCII.GetBytes(query);
    //        request.ContentType = "application/x-www-form-urlencoded";
    //        request.ContentLength = byteArray.Length;
    //        dataStream = request.GetRequestStream();
    //        dataStream.Write(byteArray, 0, byteArray.Length);
    //        dataStream.Close();
    //        WebResponse response = request.GetResponse();
    //        String Status = ((HttpWebResponse)response).StatusDescription;
    //        dataStream = response.GetResponseStream();
    //        StreamReader reader = new StreamReader(dataStream);
    //        responseFromServer = reader.ReadToEnd();
    //        reader.Close();
    //        dataStream.Close();
    //        response.Close();

    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.Message);

    //    }
    //    responseFromServer = responseFromServer.Replace("\r\n", string.Empty);
    //    return responseFromServer.Trim();
    //    // return "402,1,0";
    //}
    //#endregion

    public String SendSingleSMS(String mobileNo, String message)
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
    private DataSet BillPaymentReceipt(string TranRefNo)
    {
        try
        {
            SqlConnection conn = new SqlConnection(constring);
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("[GetBilldeskReceipt_CFO]", conn);
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
    public void Webservices(string UIDNO )
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
                // string UIDNO = "SML018004917311CFO"; //"SML018004917311CFO";// "LRG005000817440CFO";//"SML00500064419";//"SML00500064419";
                ds = gen.GetDepartmentonuidCFO(UIDNO);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dt = ds.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string deptid = dt.Rows[i]["intApprovalid"].ToString();
                        if (deptid == "67")
                        {
                            DataSet dsdept = new DataSet();
                            dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);
                            //string UIDNO = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                            {
                                BoilerService.regOfSteamPipeline steamvo = new BoilerService.regOfSteamPipeline();
                                steamvo.applicationId = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
                                steamvo.boiler_rating = dsdept.Tables[0].Rows[0]["Boiler_ration"].ToString();
                                steamvo.boiler_used_for = dsdept.Tables[0].Rows[0]["Boiler_User_for"].ToString();
                                steamvo.created_by = Convert.ToInt32(dsdept.Tables[0].Rows[0]["created_by"].ToString());
                                steamvo.district = dsdept.Tables[0].Rows[0]["Prop_intDistrictid"].ToString();
                                steamvo.door_survey_no = dsdept.Tables[0].Rows[0]["SurveyNo"].ToString();
                                steamvo.emailId = dsdept.Tables[0].Rows[0]["Email"].ToString();
                                steamvo.enterpreneur_id = Convert.ToInt32(dsdept.Tables[0].Rows[0]["intCFEEnterpid"].ToString());
                                steamvo.erector_class = dsdept.Tables[0].Rows[0]["ErectorClass"].ToString();
                                //steamvo.erector_license_copy = dsdept.Tables[0].Rows[0][""].ToString();
                                steamvo.erector_name = dsdept.Tables[0].Rows[0]["Name_of_Erector"].ToString();
                                steamvo.industryName = dsdept.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();
                                steamvo.length_spl_above = dsdept.Tables[0].Rows[0]["Tot_Lenght_Steam_PipeLine_Above"].ToString();
                                steamvo.length_spl_upto = dsdept.Tables[0].Rows[0]["Tot_Lenght_Steam_PipeLine_Upto"].ToString();
                                steamvo.locality = dsdept.Tables[0].Rows[0]["Name_Gramapachayat"].ToString();
                                steamvo.makersNo = dsdept.Tables[0].Rows[0]["Reg_No_Boiler"].ToString();
                                steamvo.mandal = dsdept.Tables[0].Rows[0]["Prop_intMandalid"].ToString();
                                steamvo.max_pressure = dsdept.Tables[0].Rows[0]["Allowed_Max_Presure"].ToString();
                                steamvo.mobileNo = dsdept.Tables[0].Rows[0]["MobileNumber"].ToString();
                                steamvo.noOf_vessels_connected = dsdept.Tables[0].Rows[0]["NumberofVesselsconnected"].ToString();
                                steamvo.pincode = dsdept.Tables[0].Rows[0]["Land_Pincode"].ToString();
                                steamvo.quessionaire_id = Convert.ToInt32(dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString());
                                steamvo.registrationNo = dsdept.Tables[0].Rows[0]["Reg_No_Boiler"].ToString();
                                //steamvo.requiredDocumentsSPL = dsdept.Tables[0].Rows[0][""].ToString();
                                steamvo.spl_total_length = dsdept.Tables[0].Rows[0]["Tot_Lenght_Steam_PipeLine"].ToString();
                                //steamvo.splLayoutDrawingDocuments = dsdept.Tables[0].Rows[0][""].ToString();
                                steamvo.state = dsdept.Tables[0].Rows[0]["State_Erector"].ToString();
                                steamvo.system_ip = "0:0:0:0";//dsdept.Tables[0].Rows[0][""].ToString();
                                steamvo.user_serial_no = Convert.ToInt32(dsdept.Tables[0].Rows[0]["user_serial_no"].ToString());
                                steamvo.village = dsdept.Tables[0].Rows[0]["Prop_intVillageid"].ToString();

                                //BoilerServiceTest.splLayoutDrawingDocuments spldoc = new BoilerServiceTest.splLayoutDrawingDocuments();
                                BoilerService.splLayoutDrawingDocuments[] spldoc = null;
                                BoilerService.requiredDocumentsSPL[] reqdoc = null;
                                DataSet dsBoiler = new DataSet();
                                dsBoiler = gen.getattachmentdetailsonuidCFO(UIDNO, deptid, "");
                                string attcvalueshmwssb = dsBoiler.GetXml();
                                if (dsBoiler != null && dsBoiler.Tables.Count > 0 && dsBoiler.Tables[0].Rows.Count > 0)
                                {
                                    ///Registration Deed////

                                    if (dsBoiler.Tables[0].Rows.Count > 0)
                                    {
                                        DataTable spldocdocuments = new DataTable();
                                        spldocdocuments = dsBoiler.Tables[0];
                                        spldoc = new BoilerService.splLayoutDrawingDocuments[spldocdocuments.Rows.Count];

                                        for (int n = 0; n < spldocdocuments.Rows.Count; n++)
                                        {
                                            BoilerService.splLayoutDrawingDocuments spldocvo = new BoilerService.splLayoutDrawingDocuments();
                                            spldocvo.documentName = spldocdocuments.Rows[n]["FileName"].ToString();
                                            spldocvo.documentPath = spldocdocuments.Rows[n]["Filepath"].ToString();
                                            spldoc[n] = spldocvo;
                                        }
                                        steamvo.splLayoutDrawingDocuments = spldoc;

                                    }
                                    if (dsBoiler.Tables[1].Rows.Count > 0)
                                    {
                                        DataTable reqdocdocuments = new DataTable();
                                        reqdocdocuments = dsBoiler.Tables[1];
                                        reqdoc = new BoilerService.requiredDocumentsSPL[reqdocdocuments.Rows.Count];

                                        for (int n = 0; n < reqdocdocuments.Rows.Count; n++)
                                        {
                                            BoilerService.requiredDocumentsSPL reqdocvo = new BoilerService.requiredDocumentsSPL();
                                            reqdocvo.documentName = reqdocdocuments.Rows[n]["FileName"].ToString();
                                            reqdocvo.documentPath = reqdocdocuments.Rows[n]["Filepath"].ToString();
                                            reqdoc[n] = reqdocvo;
                                        }
                                        steamvo.requiredDocumentsSPL = reqdoc;
                                    }
                                    if (dsBoiler.Tables[2].Rows.Count > 0)
                                    {
                                        steamvo.erector_license_copy = dsBoiler.Tables[2].Rows[0]["Filepath"].ToString();
                                    }
                                }
                                string boilerout = Boiler.registrationofSteamPipeLine(steamvo);
                                if (boilerout == "SUCCESS")
                                {

                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", boilerout, "Y");
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "A", boilerout, "N");
                                    //int k = gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["intDeptid"].ToString(), dsdept.Tables[0].Rows[0]["quessionaire_id"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                                    int k = gen.InsertDeptDateTracingCFO(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                                }
                                else
                                {
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", boilerout, "N");
                                }
                            }
                        }

                        if (deptid == "68")
                        {
                            string intApprovalid = dt.Rows[i]["intApprovalid"].ToString();
                            string intQuessionaireid = dt.Rows[i]["intQuessionaireid"].ToString();
                            string intDeptid = dt.Rows[i]["intDeptid"].ToString();

                            DataSet dsdept = new DataSet();
                            dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);
                            //string UIDNO = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                            {
                                string filepath = dsdept.Tables[0].Rows[0]["queryRespDocPath"].ToString();
                                //string remarks = dsdept.Tables[0].Rows[0]["queryRespText"].ToString();
                                //BoilerQueryResponseServiceTest.TSBoilerServiceImplService Boiler = new BoilerQueryResponseServiceTest.TSBoilerServiceImplService();
                                //BoilerQueryResponseServiceTest.planQR boilervo = new BoilerQueryResponseServiceTest.planQR();
                                //FireServiceCFO.Service1 fireservicecfo = new FireServiceCFO.Service1();
                                //FactoryQueryResponseServiceCFO.TSFactoryServiceImplService factoryquery = new FactoryQueryResponseServiceCFO.TSFactoryServiceImplService();

                                BoilerService.TSBoilerServiceImplService boilererection = new BoilerService.TSBoilerServiceImplService();
                                BoilerService.steampipelineErrectionCompletion boilererectionvo = new BoilerService.steampipelineErrectionCompletion();


                                //if (intApprovalid == "27")//BOILERS
                                //{
                                ////boilererectionvo.
                                boilererectionvo.applicationId = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
                                boilererectionvo.enterpreneur_id = Convert.ToInt32(dsdept.Tables[0].Rows[0]["entrepreneurId"].ToString());
                                boilererectionvo.system_ip = "0.0.0.0";
                                boilererectionvo.userID = Convert.ToInt32(dsdept.Tables[0].Rows[0]["userID"].ToString());
                                boilererectionvo.quessionaire_id = Convert.ToInt32(dsdept.Tables[0].Rows[0]["questionniareId"].ToString());

                                BoilerService.errectiondocuments[] lst = null;
                                if (dsdept.Tables[0].Rows.Count > 0)
                                {
                                    DataTable dtraw = new DataTable();
                                    dtraw = dsdept.Tables[0];
                                    lst = new BoilerService.errectiondocuments[dtraw.Rows.Count];

                                    for (int k = 0; k < dtraw.Rows.Count; k++)
                                    {
                                        BoilerService.errectiondocuments boilererrectiondocumentsvo = new BoilerService.errectiondocuments();
                                        boilererrectiondocumentsvo.documentName = dtraw.Rows[k]["queryRespDocName"].ToString();
                                        boilererrectiondocumentsvo.documentPath = dtraw.Rows[k]["queryRespDocPath"].ToString();
                                        lst[k] = boilererrectiondocumentsvo;
                                        //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                                        //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                                    }
                                }
                                boilererectionvo.errdocuments = lst;
                                // boilererectionvo.steamtestrequestdocument = lst;
                                //boilererectionvo.errdocuments = lst;
                                string boilerout = boilererection.insertIntoSPLErrectionCompletionReport(boilererectionvo);
                                if (boilerout == "SUCCESS")
                                {
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "C", boilerout, "Y");
                                    try
                                    {
                                        int k = gen.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, UIDNO, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFO", intApprovalid);
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                                else
                                {
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "C", boilerout, "N");
                                }
                            }
                        }

                        if (deptid == "14")
                        {
                            DataSet dsdept = new DataSet();

                            dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);

                            string cafUniqueNo = dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                            string transactionId = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                            string amount = dsdept.Tables[0].Rows[0]["Approval_Fee"].ToString();
                            string bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                            string transactionStatus = "S";
                            string paymentType = "NB";
                            string indApplication = dsdept.Tables[0].Rows[0]["NICApplicationno"].ToString();
                            string additionalPayment = "F";
                            string QUESTIONNAIREID = dsdept.Tables[0].Rows[0]["QUESTIONNAIREID"].ToString(); 
                            //string WEBSERVICE_URL = "http://164.100.163.19/TLWSC/updateFee?cafUniqueNo=" + cafUniqueNo + "&indApplicationNo=" + indApplication + "&transactionId=" + transactionId + "&amount=" + amount + "&bankName=" + bankName + "&transactionStatus=" + transactionStatus + "&paymentType=" + paymentType + "&additionalPayment=" + additionalPayment + "";


                            string WEBSERVICE_URL = "https://tsocmms.nic.in/TLWS/updateFee?cafUniqueNo=" + cafUniqueNo + "&transactionId=" + transactionId + "&amount=" + amount + "&bankName=" + bankName + "&transactionStatus=" + transactionStatus + "&paymentType=" + paymentType + "&indApplicationNo=" + indApplication + "&additionalPayment=" + additionalPayment + "";


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
                                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", jsonResponse, "Y");
                                                int k = gen.InsertDeptDateTracingCFO("1", QUESTIONNAIREID, UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", "14");
                                            }
                                            else
                                            {
                                                //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", jsonResponse, "N");
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
                        if (deptid == "16")
                        {
                            ServicePointManager.Expect100Continue = true;
                            ServicePointManager.SecurityProtocol = //SecurityProtocolType.Tls12;
                            SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                            CEIGCFOService.installationApplication ceifvo = new CEIGCFOService.installationApplication();
                            CEIGCFOService.installationApplication ceifvocfo = new CEIGCFOService.installationApplication();
                            CEIGCFOService.inspectionAbSwitchList[] abSwitchList = null;
                            CEIGCFOService.inspectionCircuitBreakerList[] circuitBreakerList = null;
                            CEIGCFOService.inspectionLoadPartList[] equipmentList = null;
                            CEIGCFOService.inspectionGeneratorsList[] generatorsList = null;
                            CEIGCFOService.inspectionLightningArrestorList[] lightningArrestorList = null;
                            CEIGCFOService.inspectionPrecommissionList[] precommissionList = null;
                            CEIGCFOService.inspectionTransformerCertList[] transformerCertList = null;
                            CEIGCFOService.inspectionTransmissionLinesList[] transmissionLinesList = null;

                            DataSet dsdept = new DataSet();
                            dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);
                            string valueshmwssb = dsdept.GetXml();
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                            {
                                //ceifvocfo.abSwitchList = "";
                                ceifvocfo.amount = Convert.ToDouble(dsdept.Tables[0].Rows[0]["Online_Amount"].ToString());
                                ceifvocfo.bank = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                //ceifvocfo.circuitBreakerList = "";
                                ceifvocfo.entrepreneurID = dsdept.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                                //ceifvocfo.equipmentList = "";
                                //ceifvocfo.generatorsList = "";
                                //ceifvocfo.lightningArrestorList = "";
                                //ceifvocfo.load_certificate = dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                                ceifvocfo.payment_date = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                //ceifvocfo.precommissionList = "";
                                ceifvocfo.questionaireID = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                                ceifvocfo.transaction_id = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                ceifvocfo.transaction_ref = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                //ceifvocfo.transformerCertList = "";
                                //ceifvocfo.transmissionLinesList = "";
                                ceifvocfo.UID = dsdept.Tables[0].Rows[0]["UID_No"].ToString();
                                ceifvocfo.fileNumber = dsdept.Tables[0].Rows[0]["filenumber"].ToString();


                                DataTable dtinspectionAbSwitchList = new DataTable();
                                dtinspectionAbSwitchList = dsdept.Tables[1];
                                abSwitchList = new CEIGCFOService.inspectionAbSwitchList[dtinspectionAbSwitchList.Rows.Count];

                                for (int n = 0; n < dtinspectionAbSwitchList.Rows.Count; n++)
                                {
                                    CEIGCFOService.inspectionAbSwitchList inspectionAbSwitchListvo = new CEIGCFOService.inspectionAbSwitchList();
                                    inspectionAbSwitchListvo.capacity = dtinspectionAbSwitchList.Rows[n]["CapacityA"].ToString();
                                    inspectionAbSwitchListvo.location = dtinspectionAbSwitchList.Rows[n]["Location"].ToString();
                                    inspectionAbSwitchListvo.switch_cert = dtinspectionAbSwitchList.Rows[n]["TestUpload"].ToString();
                                    inspectionAbSwitchListvo.switch_make = dtinspectionAbSwitchList.Rows[n]["Make"].ToString();
                                    inspectionAbSwitchListvo.switch_slno = dtinspectionAbSwitchList.Rows[n]["SerialNo"].ToString();
                                    inspectionAbSwitchListvo.voltage = dtinspectionAbSwitchList.Rows[n]["VoltageV"].ToString();
                                    inspectionAbSwitchListvo.with_or_without = dtinspectionAbSwitchList.Rows[n]["WithorWithoutEarthSwitch"].ToString();
                                    abSwitchList[n] = inspectionAbSwitchListvo;
                                }
                                ceifvocfo.abSwitchList = abSwitchList;
                                //}
                            }

                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[2].Rows.Count > 0)
                            {
                                DataTable dtcircuitBreakerList = new DataTable();
                                dtcircuitBreakerList = dsdept.Tables[2];
                                circuitBreakerList = new CEIGCFOService.inspectionCircuitBreakerList[dtcircuitBreakerList.Rows.Count];

                                for (int n = 0; n < dtcircuitBreakerList.Rows.Count; n++)
                                {
                                    CEIGCFOService.inspectionCircuitBreakerList circuitBreakerListvo = new CEIGCFOService.inspectionCircuitBreakerList();
                                    circuitBreakerListvo.capacity = dtcircuitBreakerList.Rows[n]["CapacityA"].ToString();
                                    circuitBreakerListvo.cb_serial_no = dtcircuitBreakerList.Rows[n]["CBSerialNo"].ToString();
                                    circuitBreakerListvo.certificate_path = dtcircuitBreakerList.Rows[n]["TestCertificateUpload"].ToString();
                                    circuitBreakerListvo.isc_ka = dtcircuitBreakerList.Rows[n]["ISCKA"].ToString();
                                    circuitBreakerListvo.location_name = dtcircuitBreakerList.Rows[n]["Location"].ToString();
                                    circuitBreakerListvo.make = dtcircuitBreakerList.Rows[n]["Make"].ToString();
                                    circuitBreakerList[n] = circuitBreakerListvo;
                                }
                                ceifvocfo.circuitBreakerList = circuitBreakerList;
                                //}
                            }

                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[3].Rows.Count > 0)
                            {
                                DataTable dtequipmentList = new DataTable();
                                dtequipmentList = dsdept.Tables[3];
                                equipmentList = new CEIGCFOService.inspectionLoadPartList[dtequipmentList.Rows.Count];

                                for (int n = 0; n < dtequipmentList.Rows.Count; n++)
                                {
                                    CEIGCFOService.inspectionLoadPartList equipmentListvo = new CEIGCFOService.inspectionLoadPartList();
                                    equipmentListvo.capacity_hp = dtequipmentList.Rows[n]["CapacityinHP"].ToString();
                                    equipmentListvo.capacity_kw = dtequipmentList.Rows[n]["CapacityinKV"].ToString();
                                    equipmentListvo.certificate_path = dtequipmentList.Rows[n]["LoadUpload"].ToString();
                                    equipmentListvo.equipment_name = dtequipmentList.Rows[n]["EquipmentName"].ToString();
                                    equipmentListvo.make = dtequipmentList.Rows[n]["Make"].ToString();
                                    equipmentListvo.serial_no = dtequipmentList.Rows[n]["SerialNo"].ToString();

                                    equipmentList[n] = equipmentListvo;
                                }
                                ceifvocfo.equipmentList = equipmentList;
                                //}
                            }
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[4].Rows.Count > 0)
                            {
                                DataTable dtgeneratorsList = new DataTable();
                                dtgeneratorsList = dsdept.Tables[4];
                                generatorsList = new CEIGCFOService.inspectionGeneratorsList[dtgeneratorsList.Rows.Count];

                                for (int n = 0; n < dtgeneratorsList.Rows.Count; n++)
                                {
                                    CEIGCFOService.inspectionGeneratorsList generatorsListvo = new CEIGCFOService.inspectionGeneratorsList();
                                    generatorsListvo.fuel_source = dtgeneratorsList.Rows[n]["FuelSource"].ToString();
                                    generatorsListvo.fuel_type = dtgeneratorsList.Rows[n]["FuelType"].ToString();
                                    generatorsListvo.generator_capacity = dtgeneratorsList.Rows[n]["CapacityA"].ToString();
                                    generatorsListvo.generator_cert = dtgeneratorsList.Rows[n]["FuelTestUpload"].ToString();
                                    generatorsListvo.generator_location = dtgeneratorsList.Rows[n]["Location"].ToString();
                                    generatorsListvo.generator_make = dtgeneratorsList.Rows[n]["Make"].ToString();
                                    generatorsListvo.generator_slno = dtgeneratorsList.Rows[n]["SerialNo"].ToString();
                                    generatorsListvo.heat_rate = dtgeneratorsList.Rows[n]["HeatRateDetails"].ToString();
                                    generatorsListvo.mercury = dtgeneratorsList.Rows[n]["Mercury"].ToString();
                                    generatorsListvo.sox_no_emission = dtgeneratorsList.Rows[n]["SoxNoxEmission"].ToString();
                                    generatorsList[n] = generatorsListvo;
                                }
                                ceifvocfo.generatorsList = generatorsList;
                                //}
                            }
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[5].Rows.Count > 0)
                            {
                                DataTable dtlightningArrestorList = new DataTable();
                                dtlightningArrestorList = dsdept.Tables[5];
                                lightningArrestorList = new CEIGCFOService.inspectionLightningArrestorList[dtlightningArrestorList.Rows.Count];

                                for (int n = 0; n < dtlightningArrestorList.Rows.Count; n++)
                                {
                                    CEIGCFOService.inspectionLightningArrestorList lightningArrestorListvo = new CEIGCFOService.inspectionLightningArrestorList();
                                    lightningArrestorListvo.arrestor_capacity = dtlightningArrestorList.Rows[n]["CapacityA"].ToString();
                                    lightningArrestorListvo.arrestor_cert = dtlightningArrestorList.Rows[n]["TestUpload"].ToString();
                                    lightningArrestorListvo.arrestor_location = dtlightningArrestorList.Rows[n]["Location"].ToString();
                                    lightningArrestorListvo.arrestor_make = dtlightningArrestorList.Rows[n]["Make"].ToString();
                                    lightningArrestorListvo.arrestor_slno = dtlightningArrestorList.Rows[n]["SerialNo"].ToString();
                                    lightningArrestorListvo.arrestor_voltage = dtlightningArrestorList.Rows[n]["VoltageV"].ToString();
                                    lightningArrestorList[n] = lightningArrestorListvo;
                                }
                                ceifvocfo.lightningArrestorList = lightningArrestorList;
                                //}
                            }
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[6].Rows.Count > 0)
                            {
                                DataTable dtprecommissionList = new DataTable();
                                dtprecommissionList = dsdept.Tables[6];
                                precommissionList = new CEIGCFOService.inspectionPrecommissionList[dtprecommissionList.Rows.Count];

                                for (int n = 0; n < dtprecommissionList.Rows.Count; n++)
                                {
                                    CEIGCFOService.inspectionPrecommissionList precommissionListvo = new CEIGCFOService.inspectionPrecommissionList();
                                    precommissionListvo.equipment = dtprecommissionList.Rows[n]["Equipment"].ToString();
                                    precommissionListvo.equipment_desc = dtprecommissionList.Rows[n]["Description"].ToString();
                                    precommissionListvo.generator_cert = dtprecommissionList.Rows[n]["CommissioningUpload"].ToString();
                                    precommissionList[n] = precommissionListvo;
                                }
                                ceifvocfo.precommissionList = precommissionList;
                                //}
                            }
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[7].Rows.Count > 0)
                            {
                                DataTable dttransformerCertList = new DataTable();
                                dttransformerCertList = dsdept.Tables[7];
                                transformerCertList = new CEIGCFOService.inspectionTransformerCertList[dttransformerCertList.Rows.Count];

                                for (int n = 0; n < dttransformerCertList.Rows.Count; n++)
                                {
                                    CEIGCFOService.inspectionTransformerCertList transformerCertListvo = new CEIGCFOService.inspectionTransformerCertList();
                                    transformerCertListvo.transformer_capacity = dttransformerCertList.Rows[n]["Capacity"].ToString();
                                    transformerCertListvo.transformer_cert_path = dttransformerCertList.Rows[n]["TransformerTestUpload"].ToString();
                                    transformerCertListvo.transformer_make = dttransformerCertList.Rows[n]["Make"].ToString();
                                    transformerCertListvo.transformer_name = dttransformerCertList.Rows[n]["Transformer"].ToString();
                                    transformerCertListvo.transformer_oil_path = dttransformerCertList.Rows[n]["OilTestUpload"].ToString();
                                    transformerCertListvo.transformer_slno = dttransformerCertList.Rows[n]["SerialNo"].ToString();
                                    transformerCertListvo.transformer_type_id = Convert.ToDouble("0.1");// Convert.ToDouble(dttransformerCertList.Rows[n]["TypeofTransformer"].ToString());
                                    transformerCertListvo.transformer_voltage = dttransformerCertList.Rows[n]["VoltageHVLV"].ToString();
                                    transformerCertList[n] = transformerCertListvo;
                                }
                                ceifvocfo.transformerCertList = transformerCertList;
                                //}
                            }
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[8].Rows.Count > 0)
                            {
                                DataTable dttransmissionLinesList = new DataTable();
                                dttransmissionLinesList = dsdept.Tables[8];
                                transmissionLinesList = new CEIGCFOService.inspectionTransmissionLinesList[dttransmissionLinesList.Rows.Count];

                                for (int n = 0; n < dttransmissionLinesList.Rows.Count; n++)
                                {
                                    CEIGCFOService.inspectionTransmissionLinesList transmissionLinesListvo = new CEIGCFOService.inspectionTransmissionLinesList();
                                    transmissionLinesListvo.transmission_cert = dttransmissionLinesList.Rows[n]["TransmissionUpload"].ToString();
                                    transmissionLinesListvo.transmission_desc = dttransmissionLinesList.Rows[n]["Description"].ToString();
                                    transmissionLinesList[n] = transmissionLinesListvo;
                                }
                                ceifvocfo.transmissionLinesList = transmissionLinesList;
                                //}
                            }

                            DataSet dsBoiler = new DataSet();
                            dsBoiler = gen.getattachmentdetailsonuidCFO(UIDNO, "16", "");
                            string attcvalueshmwssb = dsBoiler.GetXml();
                            if (dsBoiler != null && dsBoiler.Tables.Count > 0 && dsBoiler.Tables[0].Rows.Count > 0)
                            {
                                ceifvocfo.work_comm_repi_path = dsBoiler.Tables[0].Rows[0]["Filepath"].ToString();
                                ceifvocfo.work_comm_repii_path = dsBoiler.Tables[0].Rows[0]["Filepath"].ToString();
                                ceifvocfo.work_comp_rep_path = dsBoiler.Tables[0].Rows[0]["Filepath"].ToString();
                            }

                            string ceigout = ceigcfo.insertIntoInstallationApplication(ceifvocfo); //ceig.in(ceifvo);
                            if (ceigout == "SUCCESS")
                            {

                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", ceigout, "Y");
                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "A", ceigout, "N");
                                //int k = gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["intDeptid"].ToString(), dsdept.Tables[0].Rows[0]["quessionaire_id"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                                int k = gen.InsertDeptDateTracingCFO(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                            }
                            else
                            {
                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", ceigout, "N");
                            }

                        }

                        if (deptid == "27") // Boilers
                        {
                            try
                            {
                                //BoilerService.plan boilervo = new BoilerService.plan();
                                BoilerService.plan boilervo = new BoilerService.plan();
                                DataSet dsdept = new DataSet();
                                string valueshmwssb = "";
                                string outputhmwssb = "";
                                string outpayhmwssb = "";
                                dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);
                                valueshmwssb = dsdept.GetXml();
                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                                {

                                    boilervo.amount_tobe_paid = dsdept.Tables[0].Rows[0]["amount_tobe_paid"].ToString();
                                    boilervo.application_stage = Convert.ToInt32(dsdept.Tables[0].Rows[0]["application_stage"].ToString());
                                    //boilervo.application_type = dsdept.Tables[0].Rows[0]["application_type"].ToString();
                                    boilervo.applicationId = dsdept.Tables[0].Rows[0]["applicationId"].ToString();
                                    //boilervo.assigned_to_officer_id = Convert.ToInt16(dsdept.Tables[0].Rows[0]["assigned_to_officer_id"].ToString());
                                    boilervo.bankAmount = dsdept.Tables[0].Rows[0]["bankAmount"].ToString();
                                    boilervo.bankDate = dsdept.Tables[0].Rows[0]["bankDate"].ToString();
                                    boilervo.bankName = dsdept.Tables[0].Rows[0]["bankName"].ToString();
                                    boilervo.bankstatus = dsdept.Tables[0].Rows[0]["bankstatus"].ToString();
                                    boilervo.banktransid = dsdept.Tables[0].Rows[0]["banktransid"].ToString();
                                    boilervo.boiler_maker_name = dsdept.Tables[0].Rows[0]["boiler_maker_name"].ToString();
                                    boilervo.boiler_maker_no = dsdept.Tables[0].Rows[0]["boiler_maker_no"].ToString();
                                    boilervo.boiler_rating = dsdept.Tables[0].Rows[0]["boiler_rating"].ToString();
                                    boilervo.boiler_used_for = dsdept.Tables[0].Rows[0]["boiler_used_for"].ToString();
                                    boilervo.challanNo = dsdept.Tables[0].Rows[0]["challanNo"].ToString();
                                    boilervo.component_person_details = dsdept.Tables[0].Rows[0]["component_person_details"].ToString();
                                    boilervo.courier_date = dsdept.Tables[0].Rows[0]["courier_date"].ToString();
                                    boilervo.courier_number = dsdept.Tables[0].Rows[0]["courier_number"].ToString();
                                    boilervo.created_by = Convert.ToInt32(dsdept.Tables[0].Rows[0]["created_by"].ToString());
                                    boilervo.ddocode = dsdept.Tables[0].Rows[0]["ddocode"].ToString();
                                    boilervo.district = dsdept.Tables[0].Rows[0]["district"].ToString();
                                    boilervo.door_no = dsdept.Tables[0].Rows[0]["door_no"].ToString();
                                    boilervo.e_district = dsdept.Tables[0].Rows[0]["e_district"].ToString();
                                    boilervo.e_door_no = dsdept.Tables[0].Rows[0]["e_door_no"].ToString();
                                    boilervo.e_email = dsdept.Tables[0].Rows[0]["e_email"].ToString();
                                    boilervo.e_licence_copy_filepath = dsdept.Tables[0].Rows[0]["e_licence_copy_filepath"].ToString();
                                    boilervo.e_locality = dsdept.Tables[0].Rows[0]["e_locality"].ToString();
                                    boilervo.e_mandal = dsdept.Tables[0].Rows[0]["e_mandal"].ToString();
                                    boilervo.e_mobile_no = dsdept.Tables[0].Rows[0]["e_mobile_no"].ToString();
                                    boilervo.e_pincode = dsdept.Tables[0].Rows[0]["e_pincode"].ToString();
                                    boilervo.e_state = dsdept.Tables[0].Rows[0]["e_state"].ToString();
                                    boilervo.e_village = dsdept.Tables[0].Rows[0]["e_village"].ToString();
                                    boilervo.enterpreneur_id = Convert.ToInt32(dsdept.Tables[0].Rows[0]["enterpreneur_id"].ToString());
                                    boilervo.erector_class = dsdept.Tables[0].Rows[0]["erector_class"].ToString();
                                    boilervo.erector_name = dsdept.Tables[0].Rows[0]["erector_name"].ToString();
                                    boilervo.hoa = dsdept.Tables[0].Rows[0]["hoa"].ToString();
                                    //boilervo.inspection_officer = Convert.ToInt16(dsdept.Tables[0].Rows[0]["inspection_officer"].ToString());
                                    boilervo.inspector_authority_flag = Convert.ToInt32(dsdept.Tables[0].Rows[0]["inspector_authority_flag"].ToString());
                                    //boilervo.inspector_designation = dsdept.Tables[0].Rows[0]["inspector_designation"].ToString();
                                    boilervo.locality = dsdept.Tables[0].Rows[0]["locality"].ToString();
                                    boilervo.mandal = dsdept.Tables[0].Rows[0]["mandal"].ToString();
                                    boilervo.max_evaporation = dsdept.Tables[0].Rows[0]["max_evaporation"].ToString();
                                    boilervo.max_pressure = dsdept.Tables[0].Rows[0]["max_pressure"].ToString();
                                    boilervo.owner_contact_no = dsdept.Tables[0].Rows[0]["owner_contact_no"].ToString();
                                    boilervo.owner_email = dsdept.Tables[0].Rows[0]["owner_email"].ToString();
                                    boilervo.owner_name = dsdept.Tables[0].Rows[0]["owner_name"].ToString();
                                    boilervo.payment_status = "NA";
                                    boilervo.pincode = dsdept.Tables[0].Rows[0]["pincode"].ToString();
                                    boilervo.place = dsdept.Tables[0].Rows[0]["place"].ToString();
                                    boilervo.present_status_id = Convert.ToInt32(dsdept.Tables[0].Rows[0]["present_status_id"].ToString());
                                    boilervo.quessionaire_id = Convert.ToInt32(dsdept.Tables[0].Rows[0]["quessionaire_id"].ToString());
                                    boilervo.remittersname = dsdept.Tables[0].Rows[0]["remittersname"].ToString();
                                    boilervo.required_documents = dsdept.Tables[0].Rows[0]["required_documents"].ToString();
                                    boilervo.system_ip = dsdept.Tables[0].Rows[0]["system_ip"].ToString();
                                    boilervo.trydate = dsdept.Tables[0].Rows[0]["trydate"].ToString();
                                    boilervo.type_of_boiler = dsdept.Tables[0].Rows[0]["type_of_boiler"].ToString();
                                    boilervo.upload_form5 = dsdept.Tables[0].Rows[0]["upload_form5"].ToString();
                                    boilervo.user_serial_no = Convert.ToInt32(dsdept.Tables[0].Rows[0]["user_serial_no"].ToString());
                                    boilervo.village = dsdept.Tables[0].Rows[0]["village"].ToString();
                                    boilervo.year = dsdept.Tables[0].Rows[0]["year"].ToString();

                                    //BoilerService.anexuredocuments[] anexuredocuments = null;
                                    //BoilerService.cbbdocuments[] cbbdocument = null;
                                    //BoilerService.designdocuments[] designdocument = null;
                                    //BoilerService.formdocuments[] form = null;
                                    //BoilerService.otherdocuments[] Otherdoc = null;


                                    BoilerService.anexuredocuments[] anexuredocuments = null;
                                    BoilerService.cbbdocuments[] cbbdocument = null;
                                    BoilerService.designdocuments[] designdocument = null;
                                    BoilerService.formdocuments[] form = null;
                                    BoilerService.otherdocuments[] Otherdoc = null;

                                    DataSet dsBoiler = new DataSet();
                                    dsBoiler = gen.getattachmentdetailsonuidCFO(UIDNO, deptid, "");
                                    string attcvalueshmwssb = dsBoiler.GetXml();
                                    if (dsBoiler != null && dsBoiler.Tables.Count > 0 && dsBoiler.Tables[0].Rows.Count > 0)
                                    {
                                        ///Registration Deed////

                                        if (dsBoiler.Tables[0].Rows.Count > 0)
                                        {
                                            DataTable dtotherdocuments = new DataTable();
                                            dtotherdocuments = dsBoiler.Tables[0];
                                            Otherdoc = new BoilerService.otherdocuments[dtotherdocuments.Rows.Count];

                                            for (int n = 0; n < dtotherdocuments.Rows.Count; n++)
                                            {
                                                BoilerService.otherdocuments otherdocvo = new BoilerService.otherdocuments();
                                                otherdocvo.documentName = dtotherdocuments.Rows[n]["FileName"].ToString();
                                                otherdocvo.documentPath = dtotherdocuments.Rows[n]["Filepath"].ToString();
                                                Otherdoc[n] = otherdocvo;
                                            }
                                            boilervo.otherdocuments = Otherdoc;

                                        }
                                        if (dsBoiler.Tables[1].Rows.Count > 0)
                                        {
                                            DataTable dtcbbdocuments = new DataTable();
                                            dtcbbdocuments = dsBoiler.Tables[1];
                                            cbbdocument = new BoilerService.cbbdocuments[dtcbbdocuments.Rows.Count];

                                            for (int n = 0; n < dtcbbdocuments.Rows.Count; n++)
                                            {
                                                BoilerService.cbbdocuments cbbvo = new BoilerService.cbbdocuments();
                                                cbbvo.documentName = dtcbbdocuments.Rows[n]["FileName"].ToString();
                                                cbbvo.documentPath = dtcbbdocuments.Rows[n]["Filepath"].ToString();
                                                cbbdocument[n] = cbbvo;
                                            }
                                            boilervo.cbbdocuments = cbbdocument;
                                        }
                                        if (dsBoiler.Tables[2].Rows.Count > 0)
                                        {
                                            DataTable dtdesigndocuments = new DataTable();
                                            dtdesigndocuments = dsBoiler.Tables[2];
                                            designdocument = new BoilerService.designdocuments[dtdesigndocuments.Rows.Count];

                                            for (int n = 0; n < dtdesigndocuments.Rows.Count; n++)
                                            {
                                                BoilerService.designdocuments designvo = new BoilerService.designdocuments();
                                                designvo.documentName = dtdesigndocuments.Rows[n]["FileName"].ToString();
                                                designvo.documentPath = dtdesigndocuments.Rows[n]["Filepath"].ToString();
                                                designdocument[n] = designvo;
                                            }
                                            boilervo.designdocuments = designdocument;
                                        }
                                        if (dsBoiler.Tables[3].Rows.Count > 0)
                                        {
                                            DataTable dtformdocuments = new DataTable();
                                            dtformdocuments = dsBoiler.Tables[3];
                                            form = new BoilerService.formdocuments[dtformdocuments.Rows.Count];

                                            for (int n = 0; n < dtformdocuments.Rows.Count; n++)
                                            {
                                                BoilerService.formdocuments formvo = new BoilerService.formdocuments();
                                                formvo.documentName = dtformdocuments.Rows[n]["FileName"].ToString();
                                                formvo.documentPath = dtformdocuments.Rows[n]["Filepath"].ToString();
                                                form[n] = formvo;
                                            }
                                            boilervo.formdocuments = form;
                                        }

                                        if (dsBoiler.Tables[4].Rows.Count > 0)
                                        {
                                            DataTable dtanexuredocuments = new DataTable();
                                            dtanexuredocuments = dsBoiler.Tables[4];
                                            anexuredocuments = new BoilerService.anexuredocuments[dtanexuredocuments.Rows.Count];

                                            for (int n = 0; n < dtanexuredocuments.Rows.Count; n++)
                                            {
                                                BoilerService.anexuredocuments annexurevo = new BoilerService.anexuredocuments();
                                                annexurevo.documentName = dtanexuredocuments.Rows[n]["FileName"].ToString();
                                                annexurevo.documentPath = dtanexuredocuments.Rows[n]["Filepath"].ToString();
                                                anexuredocuments[n] = annexurevo;
                                            }
                                            boilervo.anexuredocuments = anexuredocuments;
                                        }
                                    }

                                    string boilerout = Boiler.registrationofBoilers(boilervo);//SUCCESS
                                    if (boilerout == "SUCCESS")
                                    {

                                        gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", boilerout, "Y");
                                        gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "A", boilerout, "N");
                                        //int k = gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["intDeptid"].ToString(), dsdept.Tables[0].Rows[0]["quessionaire_id"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                                        int k = gen.InsertDeptDateTracingCFO(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                                    }
                                    else
                                    {
                                        gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", boilerout, "N");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                        }


                        if (deptid == "18")// FIRE
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
                                dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);
                                valuefire = dsdept.GetXml();
                                string output = firecfo.InsertApplicantFireDetails_CFO(valuefire);
                                string[] split = output.Split('-');
                                string applid = split[1];
                                dsfire = gen.getfiremeanofescapedetailsonuidCFO(UIDNO, applid);
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
                                    outescapre = firecfo.StoreMeansOfEscape_CFO(fireescape);
                                }
                                DataSet dsfire1 = new DataSet();
                                dsfire1 = gen.getfiremeanofescapedetailsonuidCFO(UIDNO, applid);
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
                                    outapplicant = firecfo.StoreFloorwiseApplicantDtls_CFO(fireapplicant);
                                }
                                DataSet dsfire2 = new DataSet();
                                dsfire2 = gen.getfiremeanofescapedetailsonuidCFO(UIDNO, applid);
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
                                    outapplicant1 = firecfo.StoreFireFightingInstallations_CFO(firefight);
                                }

                                DataSet dsdeptattachmentsfire = new DataSet();
                                dsdeptattachmentsfire = gen.getattachmentdetailsonuidCFO(UIDNO, deptid, applid);
                                fireattachments = dsdeptattachmentsfire.GetXml();
                                outputfire = firecfo.StoreUploadDocuments_CFO(fireattachments);
                                //StringReader str1 = new StringReader(outputfire);
                                //DataSet dsout1 = new DataSet();
                                //dsout1.ReadXml(str1);
                                if (split[0] == "Success" && outescapre == "Success" && outapplicant == "Success" && outapplicant1 == "Success" && outputfire == "Success")
                                {
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "A", outapplicant, "Y");
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", outapplicant, "Y");
                                    int k = gen.InsertDeptDateTracingCFO(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["QuestionnaireId"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                                }
                                else
                                {
                                    string outputerror = split[0].ToString() + ',' + outescapre + ',' + outapplicant + ',' + outapplicant1 + ',' + outputfire;
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", outputerror, "N");
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                        if (deptid == "52")// if (deptid == "48")  // shops and establishment
                        {
                            try
                            {
                                DataSet dsdept = new DataSet();
                                DataSet dsdeptattachments = new DataSet();
                                dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);

                                LabourCFOService.act labouract = new LabourCFOService.act();
                                LabourCFOService.actsResponse labourout = new LabourCFOService.actsResponse();

                                LabourCFOService.shopsEstRegistrations shopactobjnew = new LabourCFOService.shopsEstRegistrations();


                                //LabourCFOService.buildingotherconstructions labour = new LabourCFOService.buildingotherconstructions();
                                //LabourCFOService.actsResponse labourout = new LabourCFOService.actsResponse();
                                //LabourCFOService.contractLabourPrincipalEmployer contractvo = new LabourCFOService.contractLabourPrincipalEmployer();
                                //LabourCFOService.ismwPrincipalEmployer migrateemployer = new LabourCFOService.ismwPrincipalEmployer();

                                string actids = "";
                                string actid = "";
                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                                {
                                    actids = dsdept.Tables[0].Rows[0]["LabourAct_Id"].ToString();
                                    string[] split = actids.Split(',');
                                    if (actids.Contains("1"))//The Buildings & Other Construction Workers Act
                                    {
                                        // labouract.buildingRegistrationActSelected = true;
                                        labouract.shopRegistrationActSelected = true;
                                        shopactobjnew.actID = "SEFN";//dsdept.Tables[0].Rows[0]["actID"].ToString();
                                        shopactobjnew.bank_code = dsdept.Tables[0].Rows[0]["bank_code"].ToString();
                                        shopactobjnew.bank_ref_number = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                        shopactobjnew.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                        shopactobjnew.cin = dsdept.Tables[0].Rows[0]["cin"].ToString();
                                        shopactobjnew.compound_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["compound_fee"].ToString());
                                        shopactobjnew.date_commencement = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                                        shopactobjnew.date_completion = dsdept.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();
                                        shopactobjnew.entrepreneur_id = dsdept.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                                        //  shopactobjnew.establishment_full_name = dsdept.Tables[0].Rows[0]["Form1_Estb_Name"].ToString();
                                        shopactobjnew.establishment_name = dsdept.Tables[0].Rows[0]["NAME"].ToString();
                                        //   shopactobjnew.establishment_permanent_district = dsdept.Tables[0].Rows[0]["Form1_2_Per_District"].ToString();
                                        //   shopactobjnew.establishment_permanent_door = dsdept.Tables[0].Rows[0]["Form1_2_Per_DoorNo"].ToString();
                                        //  shopactobjnew.establishment_permanent_mandal = dsdept.Tables[0].Rows[0]["Form1_2_Per_Mandal"].ToString();
                                        //   shopactobjnew.establishment_permanent_pincode = dsdept.Tables[0].Rows[0]["Form1_2_Per_PinCode"].ToString();
                                        //   shopactobjnew.establishment_permanent_village = dsdept.Tables[0].Rows[0]["Form1_2_Per_Village"].ToString();
                                        shopactobjnew.establishment_postal_district = dsdept.Tables[0].Rows[0]["Form1_Estd_District"].ToString();
                                        shopactobjnew.establishment_postal_door = dsdept.Tables[0].Rows[0]["Form1_Estd_DoorNo"].ToString();
                                        shopactobjnew.establishment_postal_locality = dsdept.Tables[0].Rows[0]["Form1_Estd_Locality"].ToString();
                                        shopactobjnew.establishment_postal_mandal = dsdept.Tables[0].Rows[0]["Form1_Estd_Mandal"].ToString();
                                        shopactobjnew.establishment_postal_pincode = dsdept.Tables[0].Rows[0]["Form1_Estd_PinCode"].ToString();
                                        shopactobjnew.establishment_postal_village = dsdept.Tables[0].Rows[0]["Form1_Estd_Village"].ToString();
                                        shopactobjnew.manager_agent_designation = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Designation"].ToString();
                                        shopactobjnew.manager_agent_district = dsdept.Tables[0].Rows[0]["Form1_1_Manager_District"].ToString();
                                        shopactobjnew.manager_agent_door = dsdept.Tables[0].Rows[0]["Form1_1_Manager_DoorNo"].ToString();
                                        shopactobjnew.manager_agent_email = dsdept.Tables[0].Rows[0]["Form1_Manager_EMail"].ToString();
                                        shopactobjnew.manager_agent_fathername = dsdept.Tables[0].Rows[0]["Form1_1_Manager_FatherName"].ToString();
                                        shopactobjnew.manager_agent_mandal = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Mandal"].ToString();
                                        shopactobjnew.manager_agent_mobile = dsdept.Tables[0].Rows[0]["Form1_Manager_MobileNo"].ToString();
                                        shopactobjnew.manager_agent_name = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Name"].ToString();
                                        shopactobjnew.manager_agent_street = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Locality"].ToString();
                                        shopactobjnew.manager_agent_village = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Village"].ToString();
                                        shopactobjnew.max_employees_aday = dsdept.Tables[0].Rows[0]["Form1_2_MaxWorkers"].ToString();
                                        shopactobjnew.nature_work = dsdept.Tables[0].Rows[0]["Form1_Nature_of_Business"].ToString();
                                        // shopactobjnew.other_attachments_1 = "";//dsdept.Tables[0].Columns["other_attachments_1"].ToString();
                                        // shopactobjnew.other_attachments_2 = "";// dsdept.Tables[0].Columns["other_attachments_2"].ToString();
                                        shopactobjnew.payment_mode = dsdept.Tables[0].Rows[0]["payment_mode"].ToString();
                                        shopactobjnew.paymentFlag = dsdept.Tables[0].Rows[0]["paymentFlag"].ToString();
                                        shopactobjnew.penality_percentage = Convert.ToInt32(dsdept.Tables[0].Rows[0]["penality_percentage"].ToString());
                                        shopactobjnew.penality_years = Convert.ToInt32(dsdept.Tables[0].Rows[0]["penality_years"].ToString());
                                        shopactobjnew.projectSubmitDate = dsdept.Tables[0].Rows[0]["projectSubmitDate"].ToString();
                                        shopactobjnew.questionnaire_id = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                                        shopactobjnew.registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                                        shopactobjnew.registration_years = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_years"].ToString());
                                        shopactobjnew.stageID = dsdept.Tables[0].Rows[0]["stageID"].ToString();
                                        shopactobjnew.total_amount_payable = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString());
                                        shopactobjnew.total_penality_amount = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_penality_amount"].ToString());
                                        shopactobjnew.total_registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_registration_fee"].ToString());
                                        shopactobjnew.totalAmount = dsdept.Tables[0].Rows[0]["totalAmount"].ToString();
                                        shopactobjnew.transaction_for = dsdept.Tables[0].Rows[0]["transaction_for"].ToString();
                                        shopactobjnew.transaction_id = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                        shopactobjnew.transactionNumber = dsdept.Tables[0].Rows[0]["transactionNumber"].ToString();
                                        shopactobjnew.transaction_status = "Y";
                                        shopactobjnew.transactionDate = dsdept.Tables[0].Rows[0]["transactionDate"].ToString();
                                        //labour.tsipassApplicationID = dsdept.Tables[0].Rows[0]["tsipassApplicationID"].ToString();
                                        shopactobjnew.type_of_application = dsdept.Tables[0].Rows[0]["type_of_application"].ToString();
                                        shopactobjnew.uID = dsdept.Tables[0].Rows[0]["UID_NO"].ToString();
                                        shopactobjnew.unpaid_balance_welfare = Convert.ToInt32(dsdept.Tables[0].Rows[0]["unpaid_balance_welfare"].ToString());
                                        shopactobjnew.valid_from_date = dsdept.Tables[0].Rows[0]["valid_from_date"].ToString();
                                        shopactobjnew.valid_to_date = dsdept.Tables[0].Rows[0]["valid_to_date"].ToString();
                                        shopactobjnew.establishment_category = dsdept.Tables[0].Rows[0]["Form1_1_Estb_Category"].ToString();
                                        shopactobjnew.establishment_classification = dsdept.Tables[0].Rows[0]["Form1_1_Estb_Classification"].ToString();
                                        shopactobjnew.male_adults = dsdept.Tables[0].Rows[0]["Form1_1_Employees_Above18_Male"].ToString();
                                        shopactobjnew.male_young = dsdept.Tables[0].Rows[0]["Form1_1_Employees_14_18_Male"].ToString();
                                        shopactobjnew.female_adults = dsdept.Tables[0].Rows[0]["Form1_1_Employees_Above18_Female"].ToString();
                                        shopactobjnew.female_young = dsdept.Tables[0].Rows[0]["Form1_1_Employees_14_18_Female"].ToString();
                                        shopactobjnew.total_adults = dsdept.Tables[0].Rows[0]["total_adults"].ToString();
                                        shopactobjnew.total_young = dsdept.Tables[0].Rows[0]["total_young"].ToString();
                                        shopactobjnew.employer_age = dsdept.Tables[0].Rows[0]["Form1_Employer_Age"].ToString();
                                        shopactobjnew.employer_designation = dsdept.Tables[0].Rows[0]["Form1_Employer_Designation"].ToString();
                                        shopactobjnew.employer_email = dsdept.Tables[0].Rows[0]["Form1_Employer_EmailID"].ToString();
                                        shopactobjnew.employer_fathername = dsdept.Tables[0].Rows[0]["Form1_Empolyer_FatherName"].ToString();
                                        shopactobjnew.employer_mobile = dsdept.Tables[0].Rows[0]["Form1_Employer_MobileNo"].ToString();
                                        shopactobjnew.employer_name = dsdept.Tables[0].Rows[0]["Form1_Employer_Name"].ToString();
                                        shopactobjnew.employer_permanent_locality = dsdept.Tables[0].Rows[0]["Form1_Employer_Locality"].ToString();
                                        shopactobjnew.employer_permanent_pincode = "";// dsdept.Tables[0].Rows[0]["Form1_Employer_District"].ToString();


                                        shopactobjnew.employer_permanent_district = dsdept.Tables[0].Rows[0]["Form1_Employer_District"].ToString();
                                        shopactobjnew.employer_permanent_door = dsdept.Tables[0].Rows[0]["Form1_Employer_DoorNo"].ToString();
                                        shopactobjnew.employer_permanent_village = dsdept.Tables[0].Rows[0]["Form1_Employer_Village"].ToString();
                                        shopactobjnew.employer_permanent_mandal = dsdept.Tables[0].Rows[0]["Form1_Employer_Mandal"].ToString();
                                        if (dsdept.Tables[0].Rows[0]["oldRegistrationYears2016"].ToString() != "")
                                        {
                                            shopactobjnew.oldRegistrationYears2016 = Convert.ToInt32(dsdept.Tables[0].Rows[0]["oldRegistrationYears2016"].ToString());
                                        }
                                        if (dsdept.Tables[0].Rows[0]["oldRegistrationAmount2016"].ToString() != "")
                                        {
                                            shopactobjnew.oldRegistrationAmount2016 = Convert.ToInt32(dsdept.Tables[0].Rows[0]["oldRegistrationAmount2016"].ToString());
                                        }
                                        if (dsdept.Tables[0].Rows[0]["newPenalityAmount2017"].ToString() != "")
                                        {
                                            shopactobjnew.newPenalityAmount2017 = Convert.ToInt32(dsdept.Tables[0].Rows[0]["newPenalityAmount2017"].ToString());
                                        }
                                        if (dsdept.Tables[0].Rows[0]["newPenalityYears2017"].ToString() != "")
                                        {
                                            shopactobjnew.newPenalityYears2017 = Convert.ToInt32(dsdept.Tables[0].Rows[0]["newPenalityYears2017"].ToString());
                                        }
                                        shopactobjnew.newRegistrationAmount2017 = Convert.ToInt32(dsdept.Tables[0].Rows[0]["newRegistrationAmount2017"].ToString());
                                        shopactobjnew.newRegistrationYears2017 = Convert.ToInt32(dsdept.Tables[0].Rows[0]["newRegistrationYears2017"].ToString());

                                        shopactobjnew.pan_proof = dsdept.Tables[0].Rows[0]["AADHAR"].ToString();
                                        shopactobjnew.employees_proof = dsdept.Tables[0].Rows[0]["IDProofEmployer"].ToString();
                                        shopactobjnew.address_proof = dsdept.Tables[0].Rows[0]["LandDeedFORM"].ToString();

                                        shopactobjnew.passport_pic_proof = dsdept.Tables[0].Rows[0]["PassportSizePhoto"].ToString();
                                        shopactobjnew.rental_sale_deed = dsdept.Tables[0].Rows[0]["RentalSaleDeed"].ToString();
                                        //shopactobjnew.certificate_incorporation_proof = dsdept.Tables[0].Rows[0]["AADHAR"].ToString();
                                        shopactobjnew.memorandum_proof = dsdept.Tables[0].Rows[0]["MemorandumofArticle"].ToString();
                                        shopactobjnew.id_proof = dsdept.Tables[0].Rows[0]["IDProofEmployer"].ToString();

                                        //                                       
                                        //shopactobjnew.authorise_letter_proof = dsdept.Tables[0].Rows[0]["REGISTER"].ToString();



                                        string managerexists = "";
                                        if (dsdept.Tables[0].Rows[0]["Form1_1_Manager_Agent_Flag"] != null && dsdept.Tables[0].Rows[0]["Form1_1_Manager_Agent_Flag"].ToString() != "")
                                        {
                                            if (dsdept.Tables[0].Rows[0]["Form1_1_Manager_Agent_Flag"].ToString() == "N")
                                            {
                                                managerexists = "NO";
                                            }
                                            else
                                            {
                                                managerexists = "YES";
                                            }
                                        }
                                        shopactobjnew.manager_exists = managerexists;
                                        shopactobjnew.total_adults = dsdept.Tables[0].Rows[0]["total_adults"].ToString();
                                        shopactobjnew.total_young = dsdept.Tables[0].Rows[0]["total_young"].ToString();

                                        //  labouract.buildingRegistrationActData = labour;

                                        LabourCFOService.shopActsWorkPlaceMultiData[] shopactobj = null;

                                        if (dsdept.Tables[1].Rows.Count > 0)
                                        {
                                            DataTable dtraw = new DataTable();
                                            dtraw = dsdept.Tables[1];
                                            shopactobj = new LabourCFOService.shopActsWorkPlaceMultiData[dtraw.Rows.Count];

                                            for (int k = 0; k < dtraw.Rows.Count; k++)
                                            {
                                                LabourCFOService.shopActsWorkPlaceMultiData workplacevo = new LabourCFOService.shopActsWorkPlaceMultiData();
                                                workplacevo.workPlacedoorNo = dtraw.Rows[k]["Door_No"].ToString();
                                                workplacevo.workPlacelocality = dtraw.Rows[k]["Locality"].ToString();
                                                workplacevo.workPlaceType = dtraw.Rows[k]["Work_Place"].ToString();
                                                shopactobj[k] = workplacevo;
                                            }
                                            shopactobjnew.workPlaceDetails = shopactobj;
                                        }

                                        LabourCFOService.shopActsEmployeesMultiData[] shopactobj1 = null;
                                        if (dsdept.Tables[2].Rows.Count > 0)
                                        {
                                            DataTable dtraw2 = new DataTable();
                                            dtraw2 = dsdept.Tables[2];
                                            shopactobj1 = new LabourCFOService.shopActsEmployeesMultiData[dtraw2.Rows.Count];

                                            for (int k = 0; k < dtraw2.Rows.Count; k++)
                                            {
                                                LabourCFOService.shopActsEmployeesMultiData workplacevo1 = new LabourCFOService.shopActsEmployeesMultiData();
                                                workplacevo1.employeeGender = dtraw2.Rows[k]["Gender"].ToString();
                                                workplacevo1.employeeName = dtraw2.Rows[k]["Name"].ToString();
                                                workplacevo1.employeeOccupation = dtraw2.Rows[k]["Occupation"].ToString();
                                                shopactobj1[k] = workplacevo1;
                                            }
                                            shopactobjnew.employeesDetails = shopactobj1;
                                        }


                                        LabourCFOService.shopActsFamilyMultiData[] shopactobj3 = null;

                                        if (dsdept.Tables[3].Rows.Count > 0)
                                        {
                                            DataTable dtraw3 = new DataTable();
                                            dtraw3 = dsdept.Tables[3];
                                            shopactobj3 = new LabourCFOService.shopActsFamilyMultiData[dtraw3.Rows.Count];

                                            for (int k = 0; k < dtraw3.Rows.Count; k++)
                                            {
                                                LabourCFOService.shopActsFamilyMultiData workplacevo3 = new LabourCFOService.shopActsFamilyMultiData();
                                                workplacevo3.familyMemberAdultYoung = dtraw3.Rows[k]["Adult_Flag"].ToString();
                                                workplacevo3.familyMemberGender = dtraw3.Rows[k]["Gender"].ToString();
                                                workplacevo3.familyMemberRelationship = dtraw3.Rows[k]["RelationShip"].ToString();
                                                workplacevo3.familyMemeberName = dtraw3.Rows[k]["Name"].ToString();
                                                shopactobj3[k] = workplacevo3;
                                            }
                                            shopactobjnew.familyDetails = shopactobj3;
                                        }
                                        DataSet dsfactroy = new DataSet();
                                        dsfactroy = gen.getattachmentdetailsonuidCFO(UIDNO, deptid, "");

                                        if (dsfactroy != null)
                                        {
                                            ///Registration Deed////

                                            if (dsfactroy.Tables[0].Rows.Count > 0)
                                            {
                                                shopactobjnew.telugu_board_proof = dsfactroy.Tables[0].Rows[0]["Filepath"].ToString();
                                            }
                                            if (dsfactroy.Tables[1].Rows.Count > 0)
                                            {
                                                shopactobjnew.pan_proof = dsfactroy.Tables[1].Rows[0]["Filepath"].ToString();
                                            }
                                            if (dsfactroy.Tables[2].Rows.Count > 0)
                                            {
                                                shopactobjnew.id_proof = dsfactroy.Tables[2].Rows[0]["Filepath"].ToString();
                                            }
                                            if (dsfactroy.Tables[3].Rows.Count > 0)
                                            {
                                                shopactobjnew.address_proof = dsfactroy.Tables[3].Rows[0]["Filepath"].ToString();
                                            }
                                            if (dsfactroy.Tables[4].Rows.Count > 0)
                                            {
                                                shopactobjnew.passport_pic_proof = dsfactroy.Tables[4].Rows[0]["Filepath"].ToString();
                                            }
                                            if (dsfactroy.Tables[5].Rows.Count > 0)
                                            {
                                                shopactobjnew.memorandum_proof = dsfactroy.Tables[5].Rows[0]["Filepath"].ToString();
                                            }
                                            if (dsfactroy.Tables[6].Rows.Count > 0)
                                            {
                                                shopactobjnew.rental_sale_deed = dsfactroy.Tables[6].Rows[0]["Filepath"].ToString();
                                                //shopactobjnew.certificate_incorporation_proof
                                            }
                                        }
                                        labouract.shopRegistrationActData = shopactobjnew;
                                        labourout = labourserviceCfo.actSelected(labouract);

                                        // labourout = labourserviceCfo.actSelected(labouract);
                                        if (labourout.status == "SUCCESS")
                                        {
                                            LabourShopCertificate.TSLabourServiceImplService certificate = new LabourShopCertificate.TSLabourServiceImplService();
                                            string output = certificate.certificateUpdation(UIDNO);
                                            string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                            gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", labouroutmsg, "Y");
                                            //int k = gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                                            int k = gen.InsertDeptDateTracingCFO(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                                        }
                                        else
                                        {
                                            string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                            gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "N", labourouterrormsg, "N");
                                        }
                                    }

                                }
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                        if (deptid == "50") // contract labour
                        {
                            try
                            {
                                DataSet dsdept = new DataSet();
                                DataSet dsdeptattachments = new DataSet();
                                dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);

                                LabourCFOService.act labouract = new LabourCFOService.act();
                                LabourCFOService.buildingotherconstructions labour = new LabourCFOService.buildingotherconstructions();
                                LabourCFOService.actsResponse labourout = new LabourCFOService.actsResponse();
                                LabourCFOService.contractLabourPrincipalEmployer contractvo = new LabourCFOService.contractLabourPrincipalEmployer();
                                LabourCFOService.ismwPrincipalEmployer migrateemployer = new LabourCFOService.ismwPrincipalEmployer();



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
                                        contractvo.entrepreneur_id = dsdept.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
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
                                        contractvo.questionnaire_id = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
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

                                        LabourCFOService.contractLabourPrincipalEmployerMultiData[] contractmulti = null;

                                        //contractvo.contractorParticulars[] lstitem = null;
                                        ContractorDetails co = new ContractorDetails();
                                        //FactoryService.rawMaterial[] lst = null;
                                        if (dsdept.Tables[1].Rows.Count > 0)
                                        {
                                            DataTable dtraw = new DataTable();
                                            dtraw = dsdept.Tables[1];
                                            contractmulti = new LabourCFOService.contractLabourPrincipalEmployerMultiData[dtraw.Rows.Count];

                                            for (int k = 0; k < dtraw.Rows.Count; k++)
                                            {
                                                //FactoryService.rawMaterial BBB = new FactoryService.rawMaterial();
                                                LabourCFOService.contractLabourPrincipalEmployerMultiData coc = new LabourCFOService.contractLabourPrincipalEmployerMultiData();
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
                                        labourout = labourserviceCfo.actSelected(labouract);

                                        if (labourout.status == "SUCCESS")
                                        {
                                            string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                            gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", labouroutmsg, "Y");
                                            int k = gen.InsertDeptDateTracingCFO(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                                        }
                                        else
                                        {
                                            string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                            gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "N", labourouterrormsg, "N");
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                        if (deptid == "51")
                        {
                            try
                            {
                                DataSet dsdept = new DataSet();
                                DataSet dsdeptattachments = new DataSet();
                                dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);

                                LabourCFOService.act labouract = new LabourCFOService.act();
                                LabourCFOService.buildingotherconstructions labour = new LabourCFOService.buildingotherconstructions();
                                LabourCFOService.actsResponse labourout = new LabourCFOService.actsResponse();
                                LabourCFOService.contractLabourPrincipalEmployer contractvo = new LabourCFOService.contractLabourPrincipalEmployer();
                                LabourCFOService.ismwPrincipalEmployer migrateemployer = new LabourCFOService.ismwPrincipalEmployer();

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
                                        migrateemployer.entrepreneur_id = dsdept.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
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
                                        migrateemployer.questionnaire_id = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
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

                                        LabourCFOService.ismwPrincipalEmployerMultiData[] migrantvo = null;
                                        ContractorDetails co = new ContractorDetails();
                                        //FactoryService.rawMaterial[] lst = null;
                                        if (dsdept.Tables[1].Rows.Count > 0)
                                        {
                                            DataTable dtraw = new DataTable();
                                            dtraw = dsdept.Tables[1];
                                            migrantvo = new LabourCFOService.ismwPrincipalEmployerMultiData[dtraw.Rows.Count];

                                            for (int k = 0; k < dtraw.Rows.Count; k++)
                                            {
                                                //FactoryService.rawMaterial BBB = new FactoryService.rawMaterial();
                                                LabourCFOService.ismwPrincipalEmployerMultiData coc = new LabourCFOService.ismwPrincipalEmployerMultiData();
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
                                        labourout = labourserviceCfo.actSelected(labouract);
                                        if (labourout.status == "SUCCESS")
                                        {
                                            string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                            gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", labouroutmsg, "Y");
                                            int k = gen.InsertDeptDateTracingCFO(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                                        }
                                        else
                                        {
                                            string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                            gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "N", labourouterrormsg, "N");
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (deptid == "15")//FACTORIES
                        {

                            FactoryServiceCFO.grantLicense factoryvo = new FactoryServiceCFO.grantLicense();

                            string outputfactory = "";
                            string valuefactory = "";
                            DataSet dsdept = new DataSet();
                            dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);
                            valuefactory = dsdept.GetXml();
                            //outputfactory = factory.insertIntoPlanApproval(factoryvo);


                            factoryvo.amountToBePaid = dsdept.Tables[0].Rows[0]["Approval_Fee"].ToString();
                            factoryvo.applicationID = dsdept.Tables[0].Rows[0]["UID_No"].ToString();
                            factoryvo.applicationStageID = dsdept.Tables[0].Rows[0]["intstageid"].ToString();
                            factoryvo.applicationStatus = "Pre-Scuitiny Pending"; //dsdept.Tables[0].Columns[""].ToString();
                            factoryvo.applicationSubmittedDate = dsdept.Tables[0].Rows[0]["UID_NOGenerateDate"].ToString();

                            //factoryvo.bankAmount = dsdept.Tables[0].Rows[0]["Online_Amount"].ToString();
                            //factoryvo.bankDate = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                            //factoryvo.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                            //factoryvo.challanNumber = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                            factoryvo.communicationAddress = dsdept.Tables[0].Rows[0]["communicationAddress"].ToString();
                            factoryvo.entrepreneurID = dsdept.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                            factoryvo.factoryDistrictID = dsdept.Tables[0].Rows[0]["Prop_intDistrictid"].ToString();
                            factoryvo.factoryDoorNumber = dsdept.Tables[0].Rows[0]["Door_No"].ToString();
                            factoryvo.factoryLocality = dsdept.Tables[0].Rows[0]["StreetName"].ToString();
                            factoryvo.factoryMandalID = dsdept.Tables[0].Rows[0]["Prop_intMandalid"].ToString();
                            factoryvo.factoryName = dsdept.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();
                            factoryvo.factoryOccupationDateByOccupier = dsdept.Tables[0].Rows[0]["Date_Occupation"].ToString();// 
                            factoryvo.factoryPinCode = dsdept.Tables[0].Rows[0]["Land_Pincode"].ToString();
                            factoryvo.factoryType = dsdept.Tables[0].Rows[0]["TypeofFactory"].ToString();
                            factoryvo.factoryVillageID = dsdept.Tables[0].Rows[0]["Prop_intVillageid"].ToString();
                            factoryvo.horsePowerToBeInstalledRegular = dsdept.Tables[0].Rows[0]["RegularHp"].ToString(); //dsdept.Tables[0].Rows[0][""].ToString();
                            factoryvo.horsePowerToBeInstalledRegularUnits = "HP";
                            factoryvo.horsePowerToBeInstalledStandby = dsdept.Tables[0].Rows[0]["StandbyHp"].ToString(); //dsdept.Tables[0].Rows[0][""].ToString();
                            factoryvo.horsePowerToBeInstalledStandbyUnits = "HP";
                            factoryvo.managerDistrict = dsdept.Tables[0].Rows[0]["Mangr_District"].ToString();
                            factoryvo.managerDoorNo = dsdept.Tables[0].Rows[0]["Mangr_DoorNo"].ToString();
                            factoryvo.managerFullName = dsdept.Tables[0].Rows[0]["Mangr_Full_Name"].ToString();
                            factoryvo.managerLocality = dsdept.Tables[0].Rows[0]["Mangr_Locality"].ToString();
                            factoryvo.managerMailId = dsdept.Tables[0].Rows[0]["Mangr_EmailId"].ToString();
                            factoryvo.managerMandal = dsdept.Tables[0].Rows[0]["Mangr_Mandal"].ToString();
                            factoryvo.managerMobileNumber = dsdept.Tables[0].Rows[0]["Mangr_MobileNo"].ToString();
                            factoryvo.managerPinCode = dsdept.Tables[0].Rows[0]["Mangr_PinCode"].ToString();
                            factoryvo.managerVillage = dsdept.Tables[0].Rows[0]["Mangr_Village"].ToString();
                            factoryvo.natureOfManufacturingProcessMain = dsdept.Tables[0].Rows[0]["MAIN"].ToString();// dsdept.Tables[0].Rows[0][""].ToString();
                            factoryvo.natureOfManufacturingProcessSecondary = dsdept.Tables[0].Rows[0]["SECONDARYITEM"].ToString();// dsdept.Tables[0].Rows[0][""].ToString();
                            factoryvo.noOfyearsSelectedToPayLicenceFee = dsdept.Tables[0].Rows[0]["LicenseYear"].ToString();
                            factoryvo.occupierDistrict = dsdept.Tables[0].Rows[0]["Occupier_District"].ToString();
                            factoryvo.occupierDoorNo = dsdept.Tables[0].Rows[0]["Occupier_DoorNo"].ToString();
                            factoryvo.occupierFullName = dsdept.Tables[0].Rows[0]["Occupier_Full_Name"].ToString();
                            factoryvo.occupierLocality = dsdept.Tables[0].Rows[0]["Occupier_Locality"].ToString();
                            factoryvo.occupierMailId = dsdept.Tables[0].Rows[0]["Occupier_EmailId"].ToString();
                            factoryvo.occupierMandal = dsdept.Tables[0].Rows[0]["Occupier_Mandal"].ToString();
                            factoryvo.occupierMobileNumber = dsdept.Tables[0].Rows[0]["Occupier_MobileNo"].ToString();
                            factoryvo.occupierOtherStatePostalAddress = "NA";//dsdept.Tables[0].Rows[0][""].ToString();
                            factoryvo.occupierPinCode = dsdept.Tables[0].Rows[0]["Occupier_PinCode"].ToString();
                            factoryvo.occupierPositionInFactory = "NA";//dsdept.Tables[0].Rows[0][""].ToString();
                            factoryvo.occupierState = "36";//dsdept.Tables[0].Rows[0][""].ToString();
                            factoryvo.occupierVillage = dsdept.Tables[0].Rows[0]["Occupier_Village"].ToString();
                            factoryvo.ownerDistrict = dsdept.Tables[0].Rows[0]["Owner_District"].ToString();
                            factoryvo.ownerDoorNo = dsdept.Tables[0].Rows[0]["Owner_DoorNo"].ToString();
                            factoryvo.ownerFullName = dsdept.Tables[0].Rows[0]["Owner_Full_Name"].ToString();
                            factoryvo.ownerLocality = dsdept.Tables[0].Rows[0]["Owner_Locality"].ToString();
                            factoryvo.ownerMailId = dsdept.Tables[0].Rows[0]["Owner_EmailId"].ToString();
                            factoryvo.ownerMandal = dsdept.Tables[0].Rows[0]["Owner_Mandal"].ToString();
                            factoryvo.ownerMobileNumber = dsdept.Tables[0].Rows[0]["Owner_MobileNo"].ToString();
                            factoryvo.ownerOtherStatePostalAddress = "NA";//dsdept.Tables[0].Rows[0][""].ToString();
                            factoryvo.ownerPinCode = dsdept.Tables[0].Rows[0]["Owner_PinCode"].ToString();
                            factoryvo.ownerState = "36";//dsdept.Tables[0].Rows[0][""].ToString();
                            factoryvo.ownerVillage = dsdept.Tables[0].Rows[0]["Owner_Village"].ToString();
                            factoryvo.paidAmount = dsdept.Tables[0].Rows[0]["Approval_Fee"].ToString();
                            factoryvo.paymentStatus = dsdept.Tables[0].Rows[0]["IsPayment"].ToString();
                            factoryvo.plansReferenceApprovedByChiefInspectorIfApplicable = dsdept.Tables[0].Rows[0]["Plans_Chief_Inspector_RefNo"].ToString();//Plans_Chief_Inspector_RefNo
                            factoryvo.questionaireID = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                            factoryvo.systemIP = "0.0.0.0";// dsdept.Tables[0].Columns[""].ToString();
                            factoryvo.userID = dsdept.Tables[0].Rows[0]["CREATEDBY"].ToString();
                            factoryvo.userMailID = dsdept.Tables[0].Rows[0]["Email"].ToString();
                            factoryvo.userMobileNumber = dsdept.Tables[0].Rows[0]["MobileNumber"].ToString();
                            factoryvo.workersToBeEmployedAdolescentsFemale = dsdept.Tables[0].Rows[0]["Adolescents_Female"].ToString();
                            factoryvo.workersToBeEmployedAdolescentsMale = dsdept.Tables[0].Rows[0]["Adolescents_Male"].ToString();
                            factoryvo.workersToBeEmployedAdultsFemale = dsdept.Tables[0].Rows[0]["AdultFemale"].ToString();
                            factoryvo.workersToBeEmployedAdultsMale = dsdept.Tables[0].Rows[0]["AdultMale"].ToString();
                            factoryvo.workersToBeEmployedChildrenFemale = dsdept.Tables[0].Rows[0]["Children_Female"].ToString();
                            factoryvo.workersToBeEmployedChildrenMale = dsdept.Tables[0].Rows[0]["Children_Male"].ToString();

                            factoryvo.workersToBeEmployedAdolescentsTrans = dsdept.Tables[0].Rows[0]["AdolescentsTRANS"].ToString();
                            factoryvo.workersToBeEmployedAdultsTrans = dsdept.Tables[0].Rows[0]["AdultTRANS"].ToString();
                            factoryvo.workersToBeEmployedChildrenTrans = dsdept.Tables[0].Rows[0]["Children_TRANS"].ToString();

                            FactoryServiceCFO.aadharCardOrPanCard[] factoryaadhar = null;
                            FactoryServiceCFO.plansReferenceApprovedByDirectorOfFactories[] factoryrefapproved = null;
                            FactoryServiceCFO.latestListOfPartnersOrDirectors[] factorypartner = null;
                            FactoryServiceCFO.partnershipDeed[] factorypartnershipdeed = null;
                            FactoryServiceCFO.passPortSizePhotographWithSignature[] factoryphotosign = null;
                            FactoryServiceCFO.registeredSaleDeedOrLeaseDeed[] factoryregisteredsaledeed = null;

                            FactoryServiceCFO.factoryOccupierAndManagerPhotoIDProof[] factoryoccupierIdPrrof = null;
                            FactoryServiceCFO.inCaseChangeOfDirectorsFormNo32[] factorydirector = null;
                            FactoryServiceCFO.proposedInventoriesOfChemicalsUsed[] factoryinventories = null;
                            FactoryServiceCFO.machinery[] factmachineries = null;
                            FactoryServiceCFO.workersList[] factworkersList = null;
                            FactoryServiceCFO.selfComplianceChecklist[] factselfComplianceChecklist = null;

                            DataSet dsfactroy = new DataSet();
                            dsfactroy = gen.getattachmentdetailsonuidCFO(UIDNO, deptid, "");

                            if (dsfactroy != null && dsfactroy.Tables.Count > 0 && dsfactroy.Tables[0].Rows.Count > 0)
                            {
                                ///Registration Deed////

                                if (dsfactroy.Tables[0].Rows.Count > 0)
                                {
                                    DataTable dtfactoryaadhar = new DataTable();
                                    dtfactoryaadhar = dsfactroy.Tables[0];
                                    factoryaadhar = new FactoryServiceCFO.aadharCardOrPanCard[dtfactoryaadhar.Rows.Count];

                                    for (int n = 0; n < dtfactoryaadhar.Rows.Count; n++)
                                    {
                                        FactoryServiceCFO.aadharCardOrPanCard factoryaadharvo = new FactoryServiceCFO.aadharCardOrPanCard();
                                        factoryaadharvo.documentName = dtfactoryaadhar.Rows[n]["FileName"].ToString();
                                        factoryaadharvo.documentPath = dtfactoryaadhar.Rows[n]["Filepath"].ToString();
                                        factoryaadhar[n] = factoryaadharvo;
                                    }
                                }
                                if (dsfactroy.Tables[1].Rows.Count > 0)
                                {
                                    DataTable dtfactoryrefapproved = new DataTable();
                                    dtfactoryrefapproved = dsfactroy.Tables[1];
                                    factoryrefapproved = new FactoryServiceCFO.plansReferenceApprovedByDirectorOfFactories[dtfactoryrefapproved.Rows.Count];

                                    for (int o = 0; o < dtfactoryrefapproved.Rows.Count; o++)
                                    {
                                        FactoryServiceCFO.plansReferenceApprovedByDirectorOfFactories factoryrefapprovedvo = new FactoryServiceCFO.plansReferenceApprovedByDirectorOfFactories();
                                        factoryrefapprovedvo.documentName = dtfactoryrefapproved.Rows[o]["FileName"].ToString();
                                        factoryrefapprovedvo.documentPath = dtfactoryrefapproved.Rows[o]["Filepath"].ToString();
                                        factoryrefapproved[o] = factoryrefapprovedvo;
                                    }
                                }
                                if (dsfactroy.Tables[2].Rows.Count > 0)
                                {
                                    DataTable dtfactorypartner = new DataTable();
                                    dtfactorypartner = dsfactroy.Tables[2];
                                    factorypartner = new FactoryServiceCFO.latestListOfPartnersOrDirectors[dtfactorypartner.Rows.Count];

                                    for (int p = 0; p < dtfactorypartner.Rows.Count; p++)
                                    {
                                        FactoryServiceCFO.latestListOfPartnersOrDirectors factorypartnervo = new FactoryServiceCFO.latestListOfPartnersOrDirectors();
                                        factorypartnervo.documentName = dtfactorypartner.Rows[p]["FileName"].ToString();
                                        factorypartnervo.documentPath = dtfactorypartner.Rows[p]["Filepath"].ToString();
                                        factorypartner[p] = factorypartnervo;
                                    }
                                }
                                if (dsfactroy.Tables[3].Rows.Count > 0)
                                {
                                    DataTable dtfactorypartnershipdeed = new DataTable();
                                    dtfactorypartnershipdeed = dsfactroy.Tables[3];
                                    factorypartnershipdeed = new FactoryServiceCFO.partnershipDeed[dtfactorypartnershipdeed.Rows.Count];

                                    for (int n = 0; n < dtfactorypartnershipdeed.Rows.Count; n++)
                                    {
                                        FactoryServiceCFO.partnershipDeed factorypartnershipdeedvo = new FactoryServiceCFO.partnershipDeed();
                                        factorypartnershipdeedvo.documentName = dtfactorypartnershipdeed.Rows[n]["FileName"].ToString();
                                        factorypartnershipdeedvo.documentPath = dtfactorypartnershipdeed.Rows[n]["Filepath"].ToString();
                                        factorypartnershipdeed[n] = factorypartnershipdeedvo;
                                    }
                                }
                                if (dsfactroy.Tables[4].Rows.Count > 0)
                                {
                                    DataTable dtfactoryphotosign = new DataTable();
                                    dtfactoryphotosign = dsfactroy.Tables[4];
                                    factoryphotosign = new FactoryServiceCFO.passPortSizePhotographWithSignature[dtfactoryphotosign.Rows.Count];

                                    for (int n = 0; n < dtfactoryphotosign.Rows.Count; n++)
                                    {
                                        FactoryServiceCFO.passPortSizePhotographWithSignature factoryphotosignvo = new FactoryServiceCFO.passPortSizePhotographWithSignature();
                                        factoryphotosignvo.documentName = dtfactoryphotosign.Rows[n]["FileName"].ToString();
                                        factoryphotosignvo.documentPath = dtfactoryphotosign.Rows[n]["Filepath"].ToString();
                                        factoryphotosign[n] = factoryphotosignvo;
                                    }
                                }
                                if (dsfactroy.Tables[5].Rows.Count > 0)
                                {
                                    DataTable dtfactoryregisteredsaledeed = new DataTable();
                                    dtfactoryregisteredsaledeed = dsfactroy.Tables[5];
                                    factoryregisteredsaledeed = new FactoryServiceCFO.registeredSaleDeedOrLeaseDeed[dtfactoryregisteredsaledeed.Rows.Count];

                                    for (int n = 0; n < dtfactoryregisteredsaledeed.Rows.Count; n++)
                                    {
                                        FactoryServiceCFO.registeredSaleDeedOrLeaseDeed factoryregisteredsaledeedvo = new FactoryServiceCFO.registeredSaleDeedOrLeaseDeed();
                                        factoryregisteredsaledeedvo.documentName = dtfactoryregisteredsaledeed.Rows[n]["FileName"].ToString();
                                        factoryregisteredsaledeedvo.documentPath = dtfactoryregisteredsaledeed.Rows[n]["Filepath"].ToString();
                                        factoryregisteredsaledeed[n] = factoryregisteredsaledeedvo;
                                    }
                                }
                                if (dsfactroy.Tables[8].Rows.Count > 0)
                                {
                                    DataTable dtmachinery = new DataTable();
                                    dtmachinery = dsfactroy.Tables[8];
                                    factmachineries = new FactoryServiceCFO.machinery[dtmachinery.Rows.Count];

                                    for (int n = 0; n < dtmachinery.Rows.Count; n++)
                                    {
                                        FactoryServiceCFO.machinery factoryrmachineryvo = new FactoryServiceCFO.machinery();
                                        factoryrmachineryvo.documentName = dtmachinery.Rows[n]["FileName"].ToString();
                                        factoryrmachineryvo.documentPath = dtmachinery.Rows[n]["Filepath"].ToString();
                                        factmachineries[n] = factoryrmachineryvo;
                                    }
                                }

                                if (dsfactroy.Tables[9].Rows.Count > 0)
                                {
                                    DataTable dtselfcompchklist = new DataTable();
                                    dtselfcompchklist = dsfactroy.Tables[9];
                                    factselfComplianceChecklist = new FactoryServiceCFO.selfComplianceChecklist[dtselfcompchklist.Rows.Count];

                                    for (int n = 0; n < dtselfcompchklist.Rows.Count; n++)
                                    {
                                        FactoryServiceCFO.selfComplianceChecklist factselfComplianceChecklistvo = new FactoryServiceCFO.selfComplianceChecklist();
                                        factselfComplianceChecklistvo.documentName = dtselfcompchklist.Rows[n]["FileName"].ToString();
                                        factselfComplianceChecklistvo.documentPath = dtselfcompchklist.Rows[n]["Filepath"].ToString();
                                        factselfComplianceChecklist[n] = factselfComplianceChecklistvo;
                                    }
                                }

                                if (dsfactroy.Tables[10].Rows.Count > 0)
                                {
                                    DataTable dtworkerslist = new DataTable();
                                    dtworkerslist = dsfactroy.Tables[10];
                                    factworkersList = new FactoryServiceCFO.workersList[dtworkerslist.Rows.Count];

                                    for (int n = 0; n < dtworkerslist.Rows.Count; n++)
                                    {
                                        FactoryServiceCFO.workersList factworkersListvo = new FactoryServiceCFO.workersList();
                                        factworkersListvo.documentName = dtworkerslist.Rows[n]["FileName"].ToString();
                                        factworkersListvo.documentPath = dtworkerslist.Rows[n]["Filepath"].ToString();
                                        factworkersList[n] = factworkersListvo;
                                    }
                                }
                            }


                            factoryvo.aadharCardOrPanCardAttachments = factoryaadhar;
                            factoryvo.plansReferenceApprovedByDirectorOfFactoriesAttachments = factoryrefapproved;
                            factoryvo.latestListOfPartnersOrDirectorsAttachments = factorypartner;
                            factoryvo.partnershipDeedAttachments = factorypartnershipdeed;
                            factoryvo.passPortSizePhotographWithSignatureAttachments = factoryphotosign;
                            factoryvo.registeredSaleDeedOrLeaseDeedAttachments = factoryregisteredsaledeed;
                            factoryvo.factoryOccupierAndManagerPhotoIDProofAttachments = factoryoccupierIdPrrof;
                            factoryvo.inCaseChangeOfDirectorsFormNo32Attachments = factorydirector;
                            factoryvo.proposedInventoriesOfChemicalsUsedAttachments = factoryinventories;

                            factoryvo.machineryAttachments = factmachineries;
                            factoryvo.selfComplianceChecklistAttachments = factselfComplianceChecklist;
                            factoryvo.workersListAttachments = factworkersList;

                            string OUTPUT = factorycfo.insertIntoGrantLicense(factoryvo);

                            if (OUTPUT == "SUCCESS")
                            {

                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", OUTPUT, "Y");
                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "A", OUTPUT, "Y");
                                int k = gen.InsertDeptDateTracingCFO(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                            }
                            else
                            {
                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", OUTPUT, "N");
                            }
                        }
                    }
                }
                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    DataTable dtadd = new DataTable();
                    dtadd = ds.Tables[1];
                    for (int i = 0; i < dtadd.Rows.Count; i++)
                    {
                        TSIICService.ApplicationFormResponse tsiicapplication = new TSIICService.ApplicationFormResponse();
                        string deptid = dtadd.Rows[i]["intApprovalid"].ToString();
                        string intQuessionairecfoid = dtadd.Rows[i]["intQuessionaireid"].ToString();
                        string intcfoenterpid = dtadd.Rows[i]["intCFOEnterpid"].ToString();
                        string INTDEPDID = dtadd.Rows[i]["intDeptid"].ToString();
                        if (deptid == "14")
                        {
                            DataSet dsdept = new DataSet();

                            dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);
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

                                //string WEBSERVICE_URL = "http://164.100.163.19/TLWSC/updateFee?cafUniqueNo=" + cafUniqueNo + "&indApplicationNo=" + indApplication + "&transactionId=" + transactionId + "&amount=" + amount + "&bankName=" + bankName + "&transactionStatus=" + transactionStatus + "&paymentType=" + paymentType + "&additionalPayment=" + additionalPayment + "";

                                string WEBSERVICE_URL1 = "https://tsocmms.nic.in/TLWS/updateCl?cafUniqueNo=" + cafUniqueNo + "&indApplicationNo=" + indApplication + "&remark=" + "AdditionalAmountSubmitted" + "&urlSingle=" + "";

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


                                string WEBSERVICE_URL = "https://tsocmms.nic.in/TLWS/updateFee?cafUniqueNo=" + cafUniqueNo + "&transactionId=" + transactionId + "&amount=" + amount + "&bankName=" + bankName + "&transactionStatus=" + transactionStatus + "&paymentType=" + paymentType + "&indApplicationNo=" + indApplication + "&additionalPayment=" + additionalPayment + "";


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
                                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", jsonResponse, "Y");
                                                }
                                                else
                                                {
                                                    //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", jsonResponse, "N");
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
                        if (deptid == "16")
                        {
                            try
                            {
                                string outputfactory = "";
                                string valuefactory = "";
                                DataSet dsdept = new DataSet();
                                dsdept = gen.getAdditionalPaymentDetailsCFO(UIDNO, deptid);
                                valuefactory = dsdept.GetXml();
                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                                {
                                    CEIGCFOService.payment ceigpaymentvo = new CEIGCFOService.payment();
                                    ceigpaymentvo.amount = Convert.ToDouble(dsdept.Tables[0].Rows[0]["Online_Amount"].ToString());
                                    ceigpaymentvo.bank = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                    ceigpaymentvo.payment_date = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                    ceigpaymentvo.tx_ref = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                    //ceigpaymentvo.applicationID = dsdept.Tables[0].Rows[0]["Created_by"].ToString();
                                    //ceigpaymentvo.bank_id = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                    //ceigpaymentvo.branch_name = "";
                                    //ceigpaymentvo.challan_copy = "";
                                    //ceigpaymentvo.challan_date = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                    //ceigpaymentvo.challan_no = dsdept.Tables[0].Rows[0]["challano"].ToString();
                                    ceigpaymentvo.entrepreneurID = dsdept.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                                    //ceigpaymentvo.payment_type = dsdept.Tables[0].Rows[0]["paymentmode"].ToString();
                                    ceigpaymentvo.questionaireID = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                                    ceigpaymentvo.reply_document = "";
                                    ceigpaymentvo.reply_remarks = "";
                                    // ceigpaymentvo.system_ip = "1.1.1.1"; ;
                                    ceigpaymentvo.tx_id = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                    ceigpaymentvo.UID = dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                    string outceigpayment = ceigcfo.updateInstallationPayment(ceigpaymentvo);

                                    if (outceigpayment == "SUCCESS")
                                    {

                                        gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", outceigpayment, "Y");

                                    }
                                    else
                                    {
                                        gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", outceigpayment, "N");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (deptid == "15") //FACTORY
                        {
                            try
                            {
                                ServicePointManager.Expect100Continue = true;
                                ServicePointManager.SecurityProtocol = //SecurityProtocolType.Tls12;
                                SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                                string outputfactory = "";
                                string valuefactory = "";
                                DataSet dsdept = new DataSet();
                                dsdept = gen.getAdditionalPaymentDetailsCFO(UIDNO, deptid);
                                valuefactory = dsdept.GetXml();
                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                                {
                                    FactoryServiceCFO.grantLicenseAdditionalPayment factorycfovo = new FactoryServiceCFO.grantLicenseAdditionalPayment();
                                    factorycfovo.applicationID = dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                    factorycfovo.bankAmount = dsdept.Tables[0].Rows[0]["Online_Amount"].ToString();
                                    factorycfovo.bankDate = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                    factorycfovo.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                    factorycfovo.challanNumber = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                    factorycfovo.paymentStatus = dsdept.Tables[0].Rows[0]["PaymentFlag"].ToString();
                                    factorycfovo.systemIP = "0.0.0.0";//dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                    factorycfovo.userID = dsdept.Tables[0].Rows[0]["Created_by"].ToString();
                                    if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[1].Rows.Count > 0)
                                    {
                                        factorycfovo.harithanidhibankamount = dsdept.Tables[1].Rows[0]["Online_Amount"].ToString();
                                        factorycfovo.harithanidhibankdate = dsdept.Tables[1].Rows[0]["TransactionDate"].ToString();
                                        factorycfovo.harithanidhibankname = dsdept.Tables[1].Rows[0]["BankName"].ToString();
                                        factorycfovo.harithanidhibankstatus = dsdept.Tables[1].Rows[0]["PaymentFlag"].ToString();
                                        factorycfovo.harithanidhichallanno = dsdept.Tables[1].Rows[0]["TransactionNO"].ToString();
                                    }
                                    else
                                    {
                                        factorycfovo.harithanidhibankstatus = "N";
                                        factorycfovo.harithanidhibankamount = "0";
                                    }
                                    //string outfactory = factorycfo.insertIntoGrantLicenseAdditionalPayment(factorycfovo);

                                    //if (outfactory == "SUCCESS")
                                    //{

                                    //    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", outfactory, "Y");

                                    //}
                                    //else
                                    //{
                                    //    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", outfactory, "N");
                                    //}
                                    var response = factorycfo.insertIntoGrantLicenseAdditionalPayment(factorycfovo);
                                    string allottedOfficer = response.allottedOfficer;
                                    string applicationId = response.applicationId;
                                    string certificatePath = response.certificatePath;
                                    string entrepreneurId = response.entrepreneurId;
                                    string questionaireId = response.questionaireId;
                                    string registrationNo = response.registrationNo;
                                    string remarks = response.remarks;
                                    string result = response.result;   // SUCCESS / FAIL
                                    string status = response.status;
                                    string remarkswithallotedofficerandapplicationid = "";
                                    remarkswithallotedofficerandapplicationid = "alloted officer: " + allottedOfficer + " , " + "factories application id: " + applicationId + " , " + "Remarks: " + remarks + " , " + "Status: " + status;
                                    if (result == "SUCCESS")
                                    {

                                        gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", result, "Y");
                                        if (status == "Approval Issued" && remarks == "Auto Generation")
                                        {
                                            DepartmentApprovalSystem obj = new DepartmentApprovalSystem();
                                            obj.DepartmentApprovalProcessAndCertificateUploadCFO(intQuessionairecfoid, intcfoenterpid, deptid, INTDEPDID, "13", UIDNO + ".pdf", certificatePath, remarkswithallotedofficerandapplicationid, registrationNo, "");
                                        }
                                    }
                                    else
                                    {
                                        gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", result, "N");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (deptid == "18")/// FIRE
                        {
                            try
                            {
                                DataSet dsdept = new DataSet();
                                dsdept = gen.getAdditionalPaymentDetailsCFO(UIDNO, deptid);
                                string UIDNo = dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                string amount = dsdept.Tables[0].Rows[0]["Online_Amount"].ToString();
                                string date = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                string bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                string challanNumber = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                string paymentStatus = dsdept.Tables[0].Rows[0]["PaymentFlag"].ToString();
                                string systemIP = "0.0.0.0";//dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                //string userID = dsdept.Tables[0].Rows[0]["Created_by"].ToString();

                                string outputfire = firecfo.PaymentDetails_CFO(UIDNo, challanNumber, date, bankName, amount);

                                if (outputfire == "Success")
                                {
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", outputfire, "Y");
                                }
                                else
                                {
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", outputfire, "N");
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (deptid == "67") //BOILER
                        {
                            try
                            {
                                string outputfactory = "";
                                string valuefactory = "";
                                DataSet dsdept = new DataSet();
                                dsdept = gen.getAdditionalPaymentDetailsCFO(UIDNO, deptid);
                                valuefactory = dsdept.GetXml();
                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                                {
                                    BoilerService.splRegPayment Boilerpaymentvo = new BoilerService.splRegPayment();
                                    Boilerpaymentvo.applicationID = dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                    Boilerpaymentvo.bankAmount = dsdept.Tables[0].Rows[0]["Online_Amount"].ToString();
                                    Boilerpaymentvo.bankDate = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                    Boilerpaymentvo.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                    Boilerpaymentvo.bankstatus = dsdept.Tables[0].Rows[0]["PaymentFlag"].ToString();
                                    Boilerpaymentvo.banktransid = "NA";
                                    Boilerpaymentvo.challanNumber = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                    Boilerpaymentvo.ddocode = "NA";
                                    //Boilerpaymentvo.department_transaction_id = "NA";
                                    Boilerpaymentvo.hoa = "NA";
                                    Boilerpaymentvo.remittersname = "NA";
                                    Boilerpaymentvo.systemIP = "0:0:0:0";
                                    Boilerpaymentvo.trydate = "NA";
                                    Boilerpaymentvo.userID = dsdept.Tables[0].Rows[0]["Created_by"].ToString();

                                    string OutBoiler = Boiler.insertIntoSPLRegPayment(Boilerpaymentvo);
                                    if (OutBoiler == "SUCCESS")
                                    {
                                        gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", OutBoiler, "Y");
                                    }
                                    else
                                    {
                                        gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", OutBoiler, "N");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (deptid == "27") //BOILER
                        {
                            try
                            {
                                string outputfactory = "";
                                string valuefactory = "";
                                DataSet dsdept = new DataSet();
                                dsdept = gen.getAdditionalPaymentDetailsCFO(UIDNO, deptid);
                                valuefactory = dsdept.GetXml();
                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                                {
                                    BoilerService.planAdditionalPayment Boilerpaymentvo = new BoilerService.planAdditionalPayment();
                                    Boilerpaymentvo.applicationID = dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                    Boilerpaymentvo.bankAmount = dsdept.Tables[0].Rows[0]["Online_Amount"].ToString();
                                    Boilerpaymentvo.bankDate = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                    Boilerpaymentvo.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                    Boilerpaymentvo.bankstatus = dsdept.Tables[0].Rows[0]["PaymentFlag"].ToString();
                                    Boilerpaymentvo.banktransid = "NA";
                                    Boilerpaymentvo.challanNumber = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                    Boilerpaymentvo.ddocode = "NA";
                                    Boilerpaymentvo.department_transaction_id = "NA";
                                    Boilerpaymentvo.hoa = "NA";
                                    Boilerpaymentvo.remittersname = "NA";
                                    Boilerpaymentvo.systemIP = "0:0:0:0";
                                    Boilerpaymentvo.trydate = "NA";
                                    Boilerpaymentvo.userID = dsdept.Tables[0].Rows[0]["Created_by"].ToString();

                                    if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[1].Rows.Count > 0)
                                    {
                                        Boilerpaymentvo.harithaNidhiAmount = Convert.ToDouble(dsdept.Tables[1].Rows[0]["Online_Amount"].ToString());
                                        Boilerpaymentvo.harithaNidhibankStatus = dsdept.Tables[1].Rows[0]["PaymentFlag"].ToString();
                                        Boilerpaymentvo.harithaNidhibanktransid = dsdept.Tables[1].Rows[0]["TransactionNO"].ToString();
                                        Boilerpaymentvo.harithaNidhiddocode = "NA";// dsdept.Tables[1].Rows[0]["TransactionDate"].ToString();
                                        Boilerpaymentvo.harithaNidhihoa = "NA";// dsdept.Tables[1].Rows[0]["TransactionDate"].ToString();
                                        Boilerpaymentvo.harithaNidhiremittersname = dsdept.Tables[1].Rows[0]["BankName"].ToString();
                                        Boilerpaymentvo.harithaNidhitrydate = dsdept.Tables[1].Rows[0]["TransactionDate"].ToString();
                                    }

                                    string OutBoiler = Boiler.insertIntoPlanApprovalAdditionalPayment(Boilerpaymentvo);
                                    if (OutBoiler == "SUCCESS")
                                    {
                                        gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", OutBoiler, "Y");
                                    }
                                    else
                                    {
                                        gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", OutBoiler, "N");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (deptid == "74") // TSIIC ADDITIONAL PAYMENT
                        {
                            try
                            {
                                DataSet dsdept = new DataSet();
                                dsdept = gen.getAdditionalPaymentDetailsCFO(UIDNO, deptid);
                                string dtcppayment = dsdept.GetXml();
                                tsiicapplication = tsiicservice.DCPayment(dtcppayment, "$$08@213");

                                if (tsiicapplication.ResponseStatus != 0 && tsiicapplication.ResponseStatus != 0)
                                {
                                    //string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", tsiicapplication.FileNo, "Y");
                                    //int k = gen.InsertDeptDateTracing(deptid, dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE");
                                }
                                else
                                {
                                    //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", tsiicapplication.ErrorMessage, "N");
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
            // lblmsg.Text = ex.Message;
            //  lblmsg.Visible = true;
        }

    }

    public void GeneratePdf(string Email, string Message)
    {
        DataSet ds = new DataSet();

        Document document = new Document(PageSize.A4, 20f, 20f, 20f, 50f);
        Font NormalFont = FontFactory.GetFont("trebuchet ms", 12, Font.NORMAL, Color.BLACK);

        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
        {
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

            Phrase phrase = null;
            PdfPCell cell = null;
            PdfPTable table = null;
            PdfPTable tablenew = null;
            Color color = null;
            PdfPTable tablenewinner = null;
            document.Open();
            writer.PageEvent = new Footer();
            //Header Table
            PdfContentByte contentBytenew = writer.DirectContent;
            table = new PdfPTable(3);
            table.TotalWidth = document.PageSize.Width - 60f;
            table.SetWidths(new float[] { 0.1f, 0.8f, 0.1f });
            table.LockedWidth = true;


            cell = ImageCell("~/images/ipasslogopsr.png", 20f, PdfPCell.ALIGN_LEFT);
            cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            table.AddCell(cell);


            phrase = new Phrase();
            phrase.Add(new Chunk("Telangana State Industrial Project Approval\n\n", FontFactory.GetFont("trebuchet ms", 13, Font.BOLD, Color.BLACK)));
            phrase.Add(new Chunk("&	Self- Certification System (TS-iPASS)\n\n", FontFactory.GetFont("trebuchet ms", 13, Font.BOLD, Color.BLACK)));
            phrase.Add(new Chunk("government of telangana".ToUpper(), FontFactory.GetFont("trebuchet ms", 11, Font.BOLD, Color.BLACK)));

            cell = PhraseCell(phrase, PdfPCell.ALIGN_CENTER);
            cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            // cell.PaddingBottom = 30f;
            table.AddCell(cell);

            cell = ImageCell("~/images/logoTG.gif", 20f, PdfPCell.ALIGN_RIGHT);
            cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            table.AddCell(cell);

            //------------------------------------------------------------------------------------------------------------------------------------------------------
            string strDuration = "";
            string FromdateforDB = "", TodateforDB = "", monthName = "", monthName1 = "";
            string FromdateforDB1 = "", TodateforDB1 = "";
            int monthday1 = 0, monthday2 = 0;
            //  txtFromDate = Session["FromdateforDB"].ToString();

            //------------------------------------------------------------------------------------------------------------------------------------------------------
            phrase = new Phrase();
            phrase.Add(new Chunk("Online Payment Receipt\n\n", FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
            cell.VerticalAlignment = PdfCell.ALIGN_CENTER;
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            cell.Colspan = 3;
            cell.PaddingTop = 20f;
            cell.PaddingBottom = 0f;
            table.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk("Dated :" + DateTime.Now.ToString("dd/MM/yyyy"), FontFactory.GetFont("trebuchet ms", 12, Font.NORMAL, Color.BLACK)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = PdfCell.ALIGN_RIGHT;
            cell.Colspan = 3;
            cell.PaddingTop = 10f;
            cell.PaddingBottom = 20f;
            table.AddCell(cell);

            document.Add(table);

            color = new Color(6, 170, 26);
            DrawLineMiddleline(writer, 2f, document.Top - 70f, document.PageSize.Width - 2f, document.Top - 70f, color);
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------




            //---------------------------------------------------------------------------------------------------------------------------------------------------------------
            int CountColumns = 0;

            CountColumns = 8;

            tablenew = new PdfPTable(CountColumns);
            tablenew.SetWidths(new float[] { 3f, 20f, 2f, 22f, 3f, 20f, 2f, 28f });

            tablenew.TotalWidth = document.PageSize.Width - 60f;

            tablenew.LockedWidth = true;
            tablenew.SpacingBefore = 5f;
            tablenew.HorizontalAlignment = Element.ALIGN_MIDDLE;

            string cellText = "";

            cell = Allcelltext(Server.HtmlDecode("1."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            cell.MinimumHeight = 40f;
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("UID Number"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(txtasmtno.Text), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("2."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Unit Name"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(txtname.Text), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------
            cell = Allcelltext(Server.HtmlDecode("3."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            cell.MinimumHeight = 40f;
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Transaction No"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(txtrcptno.Text), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("4."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Transaction Date"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(txtrcptdt.Text), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------

            cell = Allcelltext(Server.HtmlDecode("5."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            cell.MinimumHeight = 40f;
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Communication Address"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(txtaddress.Text.Trim()), cell, 5, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------
            cell = Allcelltext(Server.HtmlDecode("6."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            cell.MinimumHeight = 40f;
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Mobile Number"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(lblMobileNumber.Text), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("7."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Email Id"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(txtEmailId.Text), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA")));
            tablenew.AddCell(cell);
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------
            cell = Allcelltext(Server.HtmlDecode("8."), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            cell.MinimumHeight = 40f;
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode("Amount Paid(Rs)"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(":"), cell, 1, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);

            cell = Allcelltext(Server.HtmlDecode(txttotal.Text.Trim() + " ( " + lblnum2wrds.Text + " )"), cell, 5, new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5")));
            tablenew.AddCell(cell);
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------


            cellText = Server.HtmlDecode("Note:- Print this payment receipt for further reference.");

            phrase = new Phrase();
            phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.BOLD, Color.BLACK)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.PaddingBottom = 5;
            cell.PaddingTop = 30;
            cell.Colspan = 8;
            tablenew.AddCell(cell);


            //tablenewinner = new PdfPTable(1);
            //tablenewinner.TotalWidth = document.PageSize.Width - 60f;


            //cell = new PdfPCell(tablenew);  // inner table adding to this
            //cell.BorderWidthRight = 0.5f;
            //cell.BorderWidthLeft = 0.5f;
            //cell.BorderWidthTop = 0.5f;
            //cell.BorderWidthBottom = 0.5f;
            //cell.BorderColorBottom = Color.BLACK;
            //cell.BorderColorTop = Color.BLACK;
            //cell.BorderColorLeft = Color.BLACK;
            //cell.BorderColorRight = Color.BLACK;
            //cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            //tablenewinner.AddCell(cell);



            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------

            contentBytenew.SetColorStroke(color);
            contentBytenew.Circle(document.PageSize.Width - 23f, document.PageSize.Bottom + 23f, 10f);
            contentBytenew.Stroke();
            ColumnText.ShowTextAligned(contentBytenew, Element.ALIGN_RIGHT, new Phrase((writer.PageNumber).ToString(), FontFactory.GetFont("Trebuchet MS", 12, Font.BOLD, Color.BLACK)), document.PageSize.Width - 20f, document.PageSize.Bottom + 20f, 2);

            document.Add(tablenew);
            document.Close();
            byte[] bytes = memoryStream.ToArray();
            try
            {
                SendingEmailWithAttachment(Email, Message, bytes);
            }
            catch (Exception ex)
            {

            }
            try
            {
                // memoryStream.Close();
                // Response.Clear();
                // Response.ContentType = "application/pdf";
                // //Response.AddHeader("Content-Disposition", "attachment; filename=DepartmentwiseCFE.pdf");
                // //Response.ContentType = "application/pdf";


                // //Response.ContentType = "application/vnd.ms-excel";
                // //Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
                // //Response.ContentType = "application/vnd.ms-excel";

                // Response.Buffer = true;
                // Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //// Response.BinaryWrite(bytes);
                // Response.Close();
                // Response.End();


                //memoryStream.Close();
                //Response.Clear();
                //Response.ContentType = "text/HTML";
                //Response.Close();
                //Response.End();

            }
            catch (Exception ex)
            {

            }
        }
    }

    public partial class Footer : PdfPageEventHelper
    {
        //new Color(127, 127, 127)
        public override void OnEndPage(PdfWriter writer, Document doc)
        {
            Paragraph footer = new Paragraph(char.ConvertFromUtf32(169).ToString() + " Industry Chasing Cell.  Government of Telangana.", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD, Color.BLACK));
            footer.Alignment = Element.ALIGN_LEFT;
            PdfPTable footerTbl = new PdfPTable(1);
            footerTbl.TotalWidth = 500f;
            footerTbl.HorizontalAlignment = Element.ALIGN_LEFT;
            PdfPCell cell = new PdfPCell(footer);
            cell.Border = 0;
            cell.PaddingLeft = 10;
            footerTbl.AddCell(cell);
            footerTbl.WriteSelectedRows(0, -1, 30, 40, writer.DirectContent);
        }
    }
    private static void DrawLine(PdfWriter writer, float x1, float y1, float x2, float y2, Color color)
    {
        PdfContentByte contentByte = writer.DirectContent;
        contentByte.SetColorStroke(color);
        contentByte.MoveTo(x1, y1);
        contentByte.LineTo(x2, y2);
        contentByte.SetLineWidth(1f);
        contentByte.Stroke();
    }
    private static void DrawLineMiddleline(PdfWriter writer, float x1, float y1, float x2, float y2, Color color)
    {
        PdfContentByte contentByte = writer.DirectContent;
        contentByte.SetColorStroke(color);
        contentByte.MoveTo(x1, y1);
        contentByte.LineTo(x2, y2);
        contentByte.SetLineWidth(2f);
        contentByte.Stroke();
    }
    private static PdfPCell PhraseCell(Phrase phrase, int align)
    {
        PdfPCell cell = new PdfPCell(phrase);
        cell.BorderColor = Color.WHITE;
        cell.VerticalAlignment = PdfCell.ALIGN_TOP;
        cell.HorizontalAlignment = align;
        cell.PaddingBottom = 2f;
        cell.PaddingTop = 0f;
        //cell.MinimumHeight = 60f;
        return cell;
    }
    private static PdfPCell PhraseCellnew(Phrase phrase, int align)
    {
        PdfPCell cell = new PdfPCell(phrase);
        cell.BorderColor = Color.WHITE;
        cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
        cell.HorizontalAlignment = align;
        //cell.PaddingBottom = 5f;
        //cell.PaddingTop = 5f;
        cell.BorderWidthRight = 0.5f;
        cell.BorderWidthLeft = 0.5f;
        cell.BorderWidthTop = 0.5f;
        cell.BorderWidthBottom = 0.5f;
        cell.BorderColorBottom = Color.BLACK;
        cell.BorderColorTop = Color.BLACK;
        cell.BorderColorLeft = Color.BLACK;
        cell.BorderColorRight = Color.BLACK;
        cell.MinimumHeight = 30f;

        return cell;
    }
    private static PdfPCell Allcelltext(string Text, PdfPCell cell, int Colspanno, Color BackColor)
    {
        Phrase phrase = null;
        string cellText = Text;
        phrase = new Phrase();
        phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 10, Font.NORMAL, Color.BLACK)));
        cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
        cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        // cell.BackgroundColor = new Color(grdDetails.HeaderStyle.BackColor);
        cell.PaddingBottom = 5;
        cell.BackgroundColor = BackColor;
        cell.Colspan = Colspanno;
        return cell;
    }
    private static PdfPCell ImageCell(string path, float scale, int align)
    {
        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));
        image.ScalePercent(scale);
        PdfPCell cell = new PdfPCell(image);
        cell.BorderColor = Color.WHITE;
        cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
        cell.HorizontalAlignment = align;
        cell.PaddingBottom = 0f;
        cell.PaddingTop = 0f;
        return cell;
    }
}