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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Text;

public partial class UI_TSiPASS_IpassPrintReceiptDrillingRigsBorewells : System.Web.UI.Page
{
    #region "Global Variables" 
    DataSet ds = new DataSet();
    string constring = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ToString();
    public string sEmail;
    static String username = "TSIPASS";
    static String password = "kcsb@786";
    static String senderid = "TSIPAS";

    HttpWebRequest request;
    static Stream dataStream;
    string responseFromServer = "";

    WebserviceVO webvo = new WebserviceVO();

    General gen = new General();
    WebClient wc = new WebClient();
    #endregion


    #region "Page_Load"

    protected void Page_Load(object sender, EventArgs e)
    {
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

                        string message = "Thank you for payment  Rs." + amount + " for this UID " + txtasmtno.Text + " of TxnID " + TranRefNo + "-TSIPass";
                        if (lblMobileNumber.Text != "")
                        {
                            try
                            {
                                SendSingleSMS(lblMobileNumber.Text, message);
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
                        // ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<Script>window.open('DepartmentServiceCFO.aspx?UIDNO=" + txtasmtno.Text + "','popUpWindow','height=0,width=1,status=no,toolbar=no,menubar=no,location=no');</Script>", false);

                        //try
                        //{
                        //    WebservicePlot(Convert.ToInt32(ds.Tables[0].Rows[0]["Created_by"].ToString()), Convert.ToInt32(ds.Tables[0].Rows[0]["ApplicationId"].ToString()));
                        //    //Webservices(txtasmtno.Text);
                        //}
                        //catch (Exception ex)
                        //{

                        //}
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
           // System.Net.NetworkCredential cred = new System.Net.NetworkCredential("tsipass.telangana@gmail.com", "zwcq vlxk gyor lpeg");
            System.Net.NetworkCredential cred = new System.Net.NetworkCredential("tsipass.telangana@gmail.com", "fqeq nive azke giwb");
            mail.To.Add(receiverMailId);
            //mail.From = new MailAddress("tsipass.telangana@gmail.com", "tsipass@2016");
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
            SqlCommand cmd1 = new SqlCommand("GetBilldeskReceipt_DrillingRigs", conn);
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
        Response.Redirect("HomeDashboard.aspx");
    }
}