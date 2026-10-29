using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Mail;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Text;
using System.Threading;
using System.Security.Cryptography;

public partial class UI_TSiPASS_IpassPrintReceiptFilmShooting : System.Web.UI.Page
{

    #region "Global Variables"
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
    WebClient wc = new WebClient();
    comFunctions obcmf = new comFunctions();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
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
                    ds = BillPaymentReceipt(TranRefNo);

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        txtasmtno.Text = ds.Tables[0].Rows[0]["Reference"].ToString();
                        txtrcptno.Text = TranRefNo;
                        txtrcptdt.Text = System.DateTime.Now.ToString();
                        txtname.Text = ds.Tables[0].Rows[0]["IndustryName"].ToString();
                        txtaddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                        lblMobileNumber.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                        txtEmailId.Text = ds.Tables[0].Rows[0]["Emailid"].ToString();
                        txttotal.Text = Convert.ToDecimal(amount).ToString("#,##0") + " /-";
                        string message = "Thank you for making the Payment of Rs." + txttotal.Text + " for this UID " + txtasmtno.Text + " of TxnID " + TranRefNo + "- TSIPass";
                        if (lblMobileNumber.Text != "")
                        {
                            try
                            {
                                obcmf.SendSingleSMSnew(lblMobileNumber.Text, message, "1007856775026438504");
                               // SendSingleSMS(lblMobileNumber.Text, message);
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (txtEmailId.Text != "")
                        {


                            try
                            {
                                string messageMail = " Thank you for making the Payment of Rs. " + txttotal.Text + " ( " + lblnum2wrds.Text + " ) for the UID : " + txtasmtno.Text + ". Please find the attached payment receipt. ";
                                messageMail = messageMail + "Please check the status of your application in Track your application available in your login.";
                                messageMail = messageMail + "Further communication regarding your application from the dept’s will be sent to you through Mail & SMS. For any queries call 040-23441636.";
                                GeneratePdf(txtEmailId.Text, messageMail);
                            }
                            catch (Exception ex)
                            {

                            }
                        }

                        try
                        {
                            // Webservices(txtasmtno.Text);
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
            //mail.From = new MailAddress("tsipass.telangana@gmail.com", "tsipass@2016");
            //mail.From = new MailAddress("tsipass.telangana@gmail.com", "zwcq vlxk gyor lpeg");
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
            SqlCommand cmd1 = new SqlCommand("GetBilldeskReceipt_FilmShooting", conn);
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
        Response.Redirect("FilmShootingUserDashboardList.aspx");
    }
    public void Webservices(string UIDNO)
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        try
        {

            if (!IsPostBack)
            {
                ds = GetDepartmentonuidFilmshooting(UIDNO);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dt = ds.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string intApprovalID = dt.Rows[i]["intApprovalid"].ToString();
                    }
                }
                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    DataTable dtadd = new DataTable();
                    dtadd = ds.Tables[1];
                    for (int i = 0; i < dtadd.Rows.Count; i++)
                    {
                        string deptid = dtadd.Rows[i]["intApprovalid"].ToString();
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
        }
        catch (Exception ex)
        {
            // lblmsg.Text = ex.Message;
            //  lblmsg.Visible = true;
        }

    }

    public DataSet GetDepartmentonuidFilmshooting(string uidno)
    {
        try
        {
            SqlConnection conn = new SqlConnection(constring);
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("USP_GET_DEPARTMENTS_UID_Filmshooting", conn);
            cmd1.CommandType = CommandType.StoredProcedure;
            if (uidno.Trim() != "" || uidno.Trim() != null)
            {
                cmd1.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = uidno.ToString();
            }
            else
            {
                cmd1.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = null;
            }
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