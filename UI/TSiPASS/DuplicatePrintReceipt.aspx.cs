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

public partial class InterfaceNetBanking_PrintReceipt : System.Web.UI.Page
{
    General Gen = new General();
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
    #endregion    
    #region "Page_Load"
    protected void Page_Load(object sender, EventArgs e)
    {
            
          try
          {
            if (!Page.IsPostBack)
            {

                if (Request.QueryString.Count > 0)
                {
                    string Transno = Request.QueryString[0].ToString();

                    DataSet ds = new DataSet();
                    ds = Gen.GetReferencenumberbydata(Request.QueryString[0].ToString());

                    if (ds.Tables[0].Rows.Count > 0)
                        {

                            Session["Amount"] = ds.Tables[2].Rows[0]["Amt"].ToString().Trim();
                            Session["RefNo"] = ds.Tables[0].Rows[0]["OnlineOrderNo"].ToString().Trim();
                            Session["TranRefNo"] = ds.Tables[0].Rows[0]["OnlineOrderNo"].ToString().Trim();


                    }
                    else if(ds.Tables[1].Rows.Count>0)
                    {
                        Session["Amount"] = ds.Tables[3].Rows[0]["Amt"].ToString().Trim();
                        Session["RefNo"] = ds.Tables[1].Rows[0]["OnlineOrderNo"].ToString().Trim();
                        Session["TranRefNo"] = ds.Tables[1].Rows[0]["OnlineOrderNo"].ToString().Trim();
                    }
                    
                    else
                    {


                    }


                }


               
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
                        if(RefNO.Contains("IC"))
                        {
                            lblPaidat.Text = "ICICI PG";
                            ds = ICICIPaymentReceipt(TranRefNo);
                        }
                        else
                        {
                            lblPaidat.Text = "SBI PG";
                            ds = SBIPaymentReceipt(TranRefNo);
                        }
                      
                        if(ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
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
                            txttotal.Text = amount;



                            string message = "Thank you for payment  Rs." + amount + " for this UID " + txtasmtno.Text + " of TxnID " + TranRefNo + "-TSIPass";
                            if (lblMobileNumber.Text != "")
                            {
                               //SendSingleSMS(lblMobileNumber.Text, message);
                            }
                            //StringWriter stringWriter = new StringWriter();
                            //HtmlTextWriter htmlTextWriterw = new HtmlTextWriter(stringWriter);
                            //Receipt.RenderControl(htmlTextWriterw);
                            //StringReader stringReader = new StringReader(stringWriter.ToString());
                            //Document pdfDoc = new Document(PageSize.A4, 30f, 25f, 15f, 0.2f);
                            //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                            //MemoryStream memoryStream = new MemoryStream();
                            //PdfWriter.GetInstance(pdfDoc, memoryStream);
                            //pdfDoc.Open();
                            ////iTextSharp.text.Image gifghmc1 = iTextSharp.text.Image.GetInstance(Server.MapPath("images/telanganalogo.png"));//Server.MapPath("images/ghmclogo.png"));
                            ////gifghmc1.Alignment = iTextSharp.text.Image.ALIGN_MIDDLE;
                            ////gifghmc1.ScaleToFit(80, 80);
                            ////gifghmc1.Alignment = iTextSharp.text.Image.UNDERLYING;
                            ////gifghmc1.SetAbsolutePosition(260, 600);
                            ////pdfDoc.Add(gifghmc1);
                            //htmlparser.Parse(stringReader);
                            //pdfDoc.Close();
                            //byte[] bytes = memoryStream.ToArray();
                            if(txtEmailId.Text != "")
                            {
                               // SendingEmailWithAttachment(txtEmailId.Text, message, bytes);
                            }
                            if (RefNO == "SBI")
                            {

                                string today = DateTime.Today.ToString("yyyyMMdd");
                                string seq = "";
                                SqlConnection con = new SqlConnection(constring);
                                SqlCommand cmd = new SqlCommand();
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = "[GETPAYMENT_DISBURS_DETAILS]";
                                cmd.Parameters.AddWithValue("@OrderNo", TranRefNo);
                                cmd.Connection = con;
                                if (con.State == ConnectionState.Closed)
                                {
                                    con.Open();
                                }
                                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                                DataSet ds1 = new DataSet();
                                da1.Fill(ds1);

                                if (ds1.Tables[0].Rows.Count > 0 && ds1.Tables[1].Rows.Count > 0 && ds1.Tables[2].Rows[0][0].ToString() == "YES")
                                {
                                    //SqlConnection con = new SqlConnection(scon);
                                    SqlCommand cmd1 = new SqlCommand();
                                    cmd1.CommandType = CommandType.StoredProcedure;
                                    cmd1.CommandText = "GET_SEQUECENUMBER";
                                    cmd1.Parameters.AddWithValue("@CurrentDate", today);
                                    cmd1.Connection = con;
                                    if (con.State == ConnectionState.Closed)
                                    {
                                        con.Open();
                                    }
                                    SqlDataAdapter da2 = new SqlDataAdapter(cmd1);
                                    DataSet ds2 = new DataSet();
                                    da2.Fill(ds2);
                                    if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
                                    {
                                        seq = ds2.Tables[0].Rows[0][0].ToString();
                                    }

                                    string directoryPath = Server.MapPath("~/SBISFTPFILES/" + today + "/");//, txtFolderName.Text.Trim()));
                                    if (!Directory.Exists(directoryPath))
                                    {
                                        Directory.CreateDirectory(directoryPath);
                                    }

                                    string sFileName = string.Format("COMINDS3{0}.{1}", DateTime.Today.ToString("ddMMyy"), seq);//.ToString("D4"));

                                    string strPath = Server.MapPath("~/SBISFTPFILES/" + today + "/" + sFileName + ".txt");

                                    FileStream fs = null;
                                    if (!File.Exists(strPath))
                                    {
                                        using (fs = File.Create(strPath))
                                        {

                                        }
                                    }
                                    if (File.Exists(strPath))
                                    {
                                        using (StreamWriter sw = new StreamWriter(strPath))
                                        {
                                            sw.Write("\n");
                                            for (int i = 0; i < ds1.Tables[1].Rows.Count; i++)
                                            {
                                                sw.Write("INTR" + "^" + "FTR No" + "^" + "62420251354^SBHY0020263^" + ds1.Tables[1].Rows[i]["BenefMobileno"].ToString() + "^" + ds1.Tables[1].Rows[i]["Online_Amount"].ToString() + "^" + ds1.Tables[1].Rows[i]["BenefAccno"].ToString() + "^" + ds1.Tables[1].Rows[i]["BenefName"].ToString() + "^" + ds1.Tables[1].Rows[i]["BenefAddress"].ToString() + "^" + ds1.Tables[1].Rows[i]["BenefBankname"].ToString() + "^" + ds1.Tables[1].Rows[i]["IFSC_CODE"].ToString() + "^P^" + ds1.Tables[0].Rows[0]["Transaction_Date"].ToString() + "^" + ds1.Tables[0].Rows[0]["Bank_RefNo"].ToString() + "^" + ds1.Tables[0].Rows[0]["Remarks"].ToString() + "^" + ds1.Tables[1].Rows[i]["BeneficiaryMailID"].ToString() + "^" + "^" + "^" + "\n");
                                            }
                                            sw.Write("\n");
                                            sw.Write("T^^" + ds1.Tables[1].Rows.Count.ToString() + "^^^^" + ds1.Tables[0].Rows[0]["Paid_Amt"].ToString() + "^^^^^^^^^^^^^^^" + "\n");

                                        }

                                    }
                                }

                            }

                            else
                            {
                                string today = DateTime.Today.ToString("yyyyMMdd");
                                string seq = "";
                                SqlConnection con = new SqlConnection(constring);
                                SqlCommand cmd = new SqlCommand();
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = "[GETPAYMENT_DISBURS_DETAILSICICI]";
                                cmd.Parameters.AddWithValue("@OrderNo", TranRefNo);
                                cmd.Connection = con;
                                if (con.State == ConnectionState.Closed)
                                {
                                    con.Open();
                                }
                                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                                DataSet ds1 = new DataSet();
                                da1.Fill(ds1);

                                if (ds1.Tables[0].Rows.Count > 0 && ds1.Tables[1].Rows.Count > 0 && ds1.Tables[2].Rows[0][0].ToString() == "YES")
                                {
                                    //SqlConnection con = new SqlConnection(scon);
                                    SqlCommand cmd1 = new SqlCommand();
                                    cmd1.CommandType = CommandType.StoredProcedure;
                                    cmd1.CommandText = "GET_SEQUECENUMBER";
                                    cmd1.Parameters.AddWithValue("@CurrentDate", today);
                                    cmd1.Connection = con;
                                    if (con.State == ConnectionState.Closed)
                                    {
                                        con.Open();
                                    }
                                    SqlDataAdapter da2 = new SqlDataAdapter(cmd1);
                                    DataSet ds2 = new DataSet();
                                    da2.Fill(ds2);
                                    if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
                                    {
                                        seq = ds2.Tables[0].Rows[0][0].ToString();
                                    }

                                    string directoryPath = Server.MapPath("~/ICICISFTPFILES/" + today + "/");//, txtFolderName.Text.Trim()));
                                    if (!Directory.Exists(directoryPath))
                                    {
                                        Directory.CreateDirectory(directoryPath);
                                    }

                                    string sFileName = string.Format("COMINDS3{0}.{1}", DateTime.Today.ToString("ddMMyy"), seq);//.ToString("D4"));

                                    string strPath = Server.MapPath("~/SBISFTPFILES/" + today + "/" + sFileName + ".txt");

                                    FileStream fs = null;
                                    if (!File.Exists(strPath))
                                    {
                                        using (fs = File.Create(strPath))
                                        {

                                        }
                                    }
                                    if (File.Exists(strPath))
                                    {
                                        using (StreamWriter sw = new StreamWriter(strPath))
                                        {
                                            sw.Write("\n");
                                            for (int i = 0; i < ds1.Tables[1].Rows.Count; i++)
                                            {
                                                sw.Write("INTR" + "^" + "FTR No" + "^" + "62420251354^SBHY0020263^" + ds1.Tables[1].Rows[i]["BenefMobileno"].ToString() + "^" + ds1.Tables[1].Rows[i]["Online_Amount"].ToString() + "^" + ds1.Tables[1].Rows[i]["BenefAccno"].ToString() + "^" + ds1.Tables[1].Rows[i]["BenefName"].ToString() + "^" + ds1.Tables[1].Rows[i]["BenefAddress"].ToString() + "^" + ds1.Tables[1].Rows[i]["BenefBankname"].ToString() + "^" + ds1.Tables[1].Rows[i]["IFSC_CODE"].ToString() + "^P^" + ds1.Tables[0].Rows[0]["Transaction_Date"].ToString() + "^" + ds1.Tables[0].Rows[0]["Bank_RefNo"].ToString() + "^" + ds1.Tables[0].Rows[0]["Remarks"].ToString() + "^" + ds1.Tables[1].Rows[i]["BeneficiaryMailID"].ToString() + "^" + "^" + "^" + "\n");
                                            }
                                            sw.Write("\n");
                                            sw.Write("T^^" + ds1.Tables[1].Rows.Count.ToString() + "^^^^" + ds1.Tables[0].Rows[0]["Paid_Amt"].ToString() + "^^^^^^^^^^^^^^^" + "\n");

                                        }

                                    }
                                }

                            }
                        }
                        else
                        {

                        }
                }
            }
        }
        catch(Exception ex)
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
            System.Net.NetworkCredential cred = new System.Net.NetworkCredential("fss.srikanth@gmail.com", "fruxsri@1986");
            mail.To.Add(receiverMailId);
            mail.From = new MailAddress("fss.srikanth@gmail.com", "fruxsri@1986");
            mail.Subject = "Information from e-Telangana State Indistries";
            mail.Body = "Dear User,<p>" + Message + "</p> <p>Regards,</p> TSIPASS.";
            mail.ReplyTo = new System.Net.Mail.MailAddress("fss.srikanth@gmail.com");
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
    private DataSet ICICIPaymentReceipt(string TranRefNo)
    {         
         try
          {
            SqlConnection conn = new SqlConnection(constring);
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("GetICICIReceipt", conn);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@OrderNo", TranRefNo);           
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            da1.Fill(ds);
            conn.Close();
            return ds;
         }
          catch(Exception ex)
          {
          }

          return null;
    }
    private DataSet SBIPaymentReceipt(string TranRefNo)
    {
        try
        {
            SqlConnection conn = new SqlConnection(constring);
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("GetICICIReceipt", conn);
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
}
