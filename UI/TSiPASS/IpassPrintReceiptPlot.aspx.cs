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

public partial class UI_TSiPASS_IpassPrintReceiptPlot : System.Web.UI.Page
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

    General gen = new General();
    WebClient wc = new WebClient();

    BoilerService.TSBoilerServiceImplService Boiler = new BoilerService.TSBoilerServiceImplService();
    LabourCFOService.TSLabourServiceImplService labourserviceCfo = new LabourCFOService.TSLabourServiceImplService();
    // LabourService.TSLabourServiceImplService labourservice = new LabourService.TSLabourServiceImplService();
    FireServiceCFO.Service1 firecfo = new FireServiceCFO.Service1();
    FactoryServiceCFO.TSFactoryServiceImplService factorycfo = new FactoryServiceCFO.TSFactoryServiceImplService();
    CEIGService.InstallationAppServiceImplService ceifcfo = new CEIGService.InstallationAppServiceImplService();

    //TSIICLAND.LandAllotmentService landservice = new TSIICLAND.LandAllotmentService();

    //TSIICLAND.Plot plotvo = new TSIICLAND.Plot();
    //TSIICLAND.VerifyFirmDetails verifyFirmvo = new TSIICLAND.VerifyFirmDetails();
    //TSIICLAND.PromoterDetails promoterDetailsvo = new TSIICLAND.PromoterDetails();
    //TSIICLAND.Landline landlinevo = new TSIICLAND.Landline();
    //TSIICLAND.Address addressvo = new TSIICLAND.Address();
    //TSIICLAND.Mobile mobilevo = new TSIICLAND.Mobile();
    ////TSIICLAND.
    //TSIICLAND.Address Commaddressvo = new TSIICLAND.Address();
    //TSIICLAND.CommunicationAddress CommcommunicationAddressvo = new TSIICLAND.CommunicationAddress();
    //TSIICLAND.CommunicationAddress ContactcommunicationAddressvo = new TSIICLAND.CommunicationAddress();
    //TSIICLAND.CommunicationAddress communicationAddressvo = new TSIICLAND.CommunicationAddress();
    //TSIICLAND.FirmDetails firmDetailsvo = new TSIICLAND.FirmDetails();
    //TSIICLAND.FirmRegistrationDetails firmRegistrationDetailsvo = new TSIICLAND.FirmRegistrationDetails();
    //TSIICLAND.Address Contactaddressvo = new TSIICLAND.Address();
    //TSIICLAND.ProjectGeneral projectGeneralvo = new TSIICLAND.ProjectGeneral();
    //TSIICLAND.ProjectFinancial projectFinancialvo = new TSIICLAND.ProjectFinancial();
    //TSIICLAND.ProjectEmployment projectEmploymentvo = new TSIICLAND.ProjectEmployment();
    //TSIICLAND.ProjectMaterialManufacturing projectMaterialManufacturingvo = new TSIICLAND.ProjectMaterialManufacturing();
    //TSIICLAND.ProjectPlantMachinery projectPlantMachineryvo = new TSIICLAND.ProjectPlantMachinery();
    //TSIICLAND.Land landvo = new TSIICLAND.Land();
    //TSIICLAND.CodeDesc codeDescvo = new TSIICLAND.CodeDesc();
    //TSIICLAND.Electricity electricityvo = new TSIICLAND.Electricity();
    //TSIICLAND.Water watervo = new TSIICLAND.Water();
    //TSIICLAND.Effluents effluentsvo = new TSIICLAND.Effluents();
    //TSIICLAND.PaymentDetails paymentDetailsvo = new TSIICLAND.PaymentDetails();
    //TSIICLAND.DocumentCheckList documentCheckListvo = new TSIICLAND.DocumentCheckList();

    //TSIICLAND.Product gsvg = new TSIICLAND.Product();
    //TSIICLAND.PromoterFinancialInformation promoterFinancialInformationvo = new TSIICLAND.PromoterFinancialInformation();
    //TSIICLAND.DateHolder comdate = new TSIICLAND.DateHolder();
    //TSIICLAND.User registraionvo = new TSIICLAND.User();
    //TSIICLAND.PersonName personvo = new TSIICLAND.PersonName();
    //TSIICLAND.Product productvo = new TSIICLAND.Product();
    //TSIICLAND.DateHolder datevo = new TSIICLAND.DateHolder();

    TSIICLANDCGG.LandAllotmentService landservice = new TSIICLANDCGG.LandAllotmentService();
    //TSIICLAND.LandAllotmentService landservice = new TSIICLAND.LandAllotmentService();
    TSIICLANDCGG.Plot plotvo = new TSIICLANDCGG.Plot();
    TSIICLANDCGG.VerifyFirmDetails verifyFirmvo = new TSIICLANDCGG.VerifyFirmDetails();
    TSIICLANDCGG.PromoterDetails promoterDetailsvo = new TSIICLANDCGG.PromoterDetails();
    TSIICLANDCGG.Landline landlinevo = new TSIICLANDCGG.Landline();

    TSIICLANDCGG.Mobile mobilevo = new TSIICLANDCGG.Mobile();
    //TSIICLAND.


    TSIICLANDCGG.Address addressvo = new TSIICLANDCGG.Address();
    TSIICLANDCGG.CommunicationAddress communicationAddressvo = new TSIICLANDCGG.CommunicationAddress();

    TSIICLANDCGG.Address Commaddressvo = new TSIICLANDCGG.Address();
    TSIICLANDCGG.CommunicationAddress CommcommunicationAddressvo = new TSIICLANDCGG.CommunicationAddress();

    TSIICLANDCGG.Address Contactaddressvo = new TSIICLANDCGG.Address();
    TSIICLANDCGG.CommunicationAddress ContactcommunicationAddressvo = new TSIICLANDCGG.CommunicationAddress();


    TSIICLANDCGG.FirmDetails firmDetailsvo = new TSIICLANDCGG.FirmDetails();
    TSIICLANDCGG.FirmRegistrationDetails firmRegistrationDetailsvo = new TSIICLANDCGG.FirmRegistrationDetails();

    TSIICLANDCGG.ProjectGeneral projectGeneralvo = new TSIICLANDCGG.ProjectGeneral();
    TSIICLANDCGG.ProjectFinancial projectFinancialvo = new TSIICLANDCGG.ProjectFinancial();
    TSIICLANDCGG.ProjectEmployment projectEmploymentvo = new TSIICLANDCGG.ProjectEmployment();
    TSIICLANDCGG.ProjectMaterialManufacturing projectMaterialManufacturingvo = new TSIICLANDCGG.ProjectMaterialManufacturing();
    TSIICLANDCGG.ProjectPlantMachinery projectPlantMachineryvo = new TSIICLANDCGG.ProjectPlantMachinery();
    TSIICLANDCGG.Land landvo = new TSIICLANDCGG.Land();
    TSIICLANDCGG.CodeDesc codeDescvo = new TSIICLANDCGG.CodeDesc();
    TSIICLANDCGG.Electricity electricityvo = new TSIICLANDCGG.Electricity();
    TSIICLANDCGG.Water watervo = new TSIICLANDCGG.Water();
    TSIICLANDCGG.Effluents effluentsvo = new TSIICLANDCGG.Effluents();
    TSIICLANDCGG.PaymentDetails paymentDetailsvo = new TSIICLANDCGG.PaymentDetails();
    TSIICLANDCGG.DocumentCheckList documentCheckListvo = new TSIICLANDCGG.DocumentCheckList();

    TSIICLANDCGG.Product gsvg = new TSIICLANDCGG.Product();
    TSIICLANDCGG.PromoterFinancialInformation promoterFinancialInformationvo = new TSIICLANDCGG.PromoterFinancialInformation();
    TSIICLANDCGG.DateHolder comdate = new TSIICLANDCGG.DateHolder();
    TSIICLANDCGG.User registraionvo = new TSIICLANDCGG.User();
    TSIICLANDCGG.PersonName personvo = new TSIICLANDCGG.PersonName();
    TSIICLANDCGG.Product productvo = new TSIICLANDCGG.Product();
    TSIICLANDCGG.DateHolder datevo = new TSIICLANDCGG.DateHolder();

    DataSet GDS = new DataSet();
    public DataSet GDs { get; set; }
    comFunctions obcmf = new comFunctions();
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

                        string message = "Thank you for payment  Rs." + amount + " for this UID " + txtasmtno.Text + " of TxnID " + TranRefNo + "-TSIPass";
                        if (lblMobileNumber.Text != "")
                        {
                            try
                            {
                                //SendSingleSMS(lblMobileNumber.Text, message);
                                obcmf.SendSingleSMSnew(lblMobileNumber.Text, message, "1007856775026438504");
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
        try
        {
            WebservicePlot(Convert.ToInt32(ds.Tables[0].Rows[0]["Created_by"].ToString()), Convert.ToInt32(ds.Tables[0].Rows[0]["ApplicationId"].ToString()));
            //Webservices(txtasmtno.Text);
        }
        catch (Exception ex)
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
           // mail.From = new MailAddress("tsipass.telangana@gmail.com", "tsipass@2016");
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
            SqlCommand cmd1 = new SqlCommand("[GetBilldeskReceipt_PLOT]", conn);
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

    public void WebservicePlot(int createdby, int applicationid)
    {
        try
        {
            tsiicdetailsdata(createdby, applicationid);
            bindata(createdby, applicationid);
            StringBuilder sbScript = new StringBuilder();
            string sScript;
            sbScript.Append("<script>");
            sbScript.Append(" window.close();");
            sbScript.Append("</script>");
            sScript = sbScript.ToString();
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", sScript, false);
        }
        catch (Exception ex)
        {
        }
    }

    public DataSet tsiicdetailsdata(int createdby, int applicationid)
    {
        try
        {
            SqlParameter[] p = new SqlParameter[] {
                    new SqlParameter("@createdby",SqlDbType.Int),
                  new SqlParameter("@Appid",SqlDbType.Int),
                };
            p[0].Value = createdby;
            p[1].Value = applicationid;

            // XmlDocument doc = new XmlDocument(); USP_GET_RM_ABSTRACTDETAILS

            GDs = gen.GenericFillDs("USP_GET_TSIICDETAILS", p);


            GDs.Tables[0].TableName = "tsiicplotallotmentmain";
            GDs.Tables[1].TableName = "tsiicplotallotmentdetails";
            GDs.Tables[2].TableName = "tsiicapplicantdetails";
            GDs.Tables[3].TableName = "TSIICAttachments";
            GDs.Tables[4].TableName = "AdditionalPromoterdetails";
            GDs.Tables[5].TableName = "UserRegisterationDetails";
            GDs.Tables[6].TableName = "PaymentDetails";
            GDs.Tables[7].TableName = "ProductDetails";
            GDs.Tables[8].TableName = "RawmaterialDetails";
            GDs.Tables[9].TableName = "PlantMachineryDetails";
            GDs.Tables[10].TableName = "PlotpaymentDetails";

            return GDs;
        }
        catch (Exception ex)
        {
            throw ex;
            //LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, HttpContext.Current.Session["uid"].ToString());
        }
    }

    public void bindataold(int createdby, int applicationid)
    {


        if (GDs.Tables[0].Rows.Count > 0)
        {

            plotvo.district = GDs.Tables[0].Rows[0]["DistrictName"].ToString();
            plotvo.emd = 0;
            plotvo.industrialPark = GDs.Tables[0].Rows[0]["IndustrialParkId"].ToString();
        }

        if (GDs.Tables[1].Rows.Count > 0)
        {
            string str = "";
            for (int i = 0; i < GDs.Tables[1].Rows.Count; i++)
            {
                str += GDs.Tables[1].Rows[i]["PLOTNO"].ToString() + ",";
            }

            plotvo.plotNo = str.Substring(0, str.Length - 1);
           // plotvo.price = Convert.ToDouble(GDs.Tables[1].Rows[0]["Price"]);
            plotvo.totalArea = Convert.ToDouble(GDs.Tables[1].Rows[0]["PlotTotalArea"]);
            plotvo.amount = Convert.ToDouble(GDs.Tables[1].Rows[0]["Price"]);
            plotvo.area = Convert.ToDouble(GDs.Tables[1].Rows[0]["PlotTotalArea"]);
            plotvo.amountSpecified = true;
            plotvo.areaSpecified = true;
            plotvo.emdSpecified = true;
            plotvo.gstSpecified = true;
            //plotvo.priceSpecified = true;
            plotvo.processFeeSpecified = true;
            plotvo.totalAreaSpecified = true;
            plotvo.totalEmdSpecified = true;
            plotvo.totalPriceSpecified = true;

        }

        if (GDs.Tables[2].Rows.Count > 0)
        {
            verifyFirmvo.alloteeName = GDs.Tables[2].Rows[0]["NameOftheFirm_Applicant"].ToString();

            paymentDetailsvo.clientName = GDs.Tables[2].Rows[0]["NameOftheFirm_Applicant"].ToString();

            verifyFirmvo.applicantName = GDs.Tables[2].Rows[0]["NameOftheFirm_Applicant"].ToString();
            verifyFirmvo.catDesc = GDs.Tables[2].Rows[0]["GovtDeptName_RegOffice"].ToString();
            TSIICLANDCGG.CodeDesc categorycodeDescvo = new TSIICLANDCGG.CodeDesc();
            categorycodeDescvo.code = GDs.Tables[2].Rows[0]["Category_RegOffice"].ToString();
            categorycodeDescvo.desc = GDs.Tables[2].Rows[0]["Category_RegOffice"].ToString();
            verifyFirmvo.categoryOfAllotment = categorycodeDescvo;
            addressvo.city = "";// GDs.Tables[2].Rows[0][""].ToString();
            addressvo.country = "INDIA";// GDs.Tables[2].Rows[0][""].ToString();
            addressvo.district = GDs.Tables[2].Rows[0]["Distid_regoffices"].ToString();
            addressvo.doorNo = GDs.Tables[2].Rows[0]["Door_No_RegOffice"].ToString();
            addressvo.mandal = GDs.Tables[2].Rows[0]["mandal_regoffices"].ToString();
            addressvo.pincode = GDs.Tables[2].Rows[0]["Pincode_RegOffice"].ToString();

            TSIICLANDCGG.CodeDesc statestnames = new TSIICLANDCGG.CodeDesc();
            statestnames.code = GDs.Tables[2].Rows[0]["stateNames"].ToString();
            statestnames.desc = GDs.Tables[2].Rows[0]["stateNames"].ToString();
            addressvo.state = statestnames;


            addressvo.streetNo1 = GDs.Tables[2].Rows[0]["Street_1_RegOffice"].ToString();
            addressvo.streetNo2 = GDs.Tables[2].Rows[0]["Street_2_RegOffice"].ToString();
            addressvo.village = GDs.Tables[2].Rows[0]["village_regoffices"].ToString();

            communicationAddressvo.address = addressvo;


            TSIICLANDCGG.Landline comphone = new TSIICLANDCGG.Landline();
            comphone.areaCode = GDs.Tables[2].Rows[0]["TelephonoNo1_RegOffice"].ToString();
            comphone.formattedPhone = "";///GDs.Tables[2].Rows[0]["FaxNo2_RegOffice"].ToString();
            comphone.number = GDs.Tables[2].Rows[0]["TelephonoNo2_RegOffice"].ToString();// GDs.Tables[2].Rows[0]["FaxNo1_RegOffice"].ToString();
            comphone.phone = "";
            comphone.valid = true;
            comphone.validSpecified = true;
            communicationAddressvo.phoneNum = comphone;



            TSIICLANDCGG.Landline faxno = new TSIICLANDCGG.Landline();
            faxno.areaCode = GDs.Tables[2].Rows[0]["FaxNo1_RegOffice"].ToString();
            faxno.formattedPhone = "";///GDs.Tables[2].Rows[0]["FaxNo2_RegOffice"].ToString();
            faxno.number = GDs.Tables[2].Rows[0]["FaxNo2_RegOffice"].ToString();// GDs.Tables[2].Rows[0]["FaxNo1_RegOffice"].ToString();
            faxno.phone = "";
            faxno.valid = true;
            faxno.validSpecified = true;
            communicationAddressvo.faxNum = faxno;

            verifyFirmvo.commFaxCode = GDs.Tables[2].Rows[0]["FaxNo1_RegOffice"].ToString();
            verifyFirmvo.commFaxNumber = GDs.Tables[2].Rows[0]["FaxNo2_RegOffice"].ToString();
            verifyFirmvo.commPhoneCode = GDs.Tables[2].Rows[0]["TelephonoNo1_RegOffice"].ToString();
            verifyFirmvo.commPhoneNumber = GDs.Tables[2].Rows[0]["TelephonoNo2_RegOffice"].ToString();

            firmDetailsvo.communicationAddress = communicationAddressvo;
            firmRegistrationDetailsvo.regstrAuthority = GDs.Tables[2].Rows[0]["RegisteringAuthority_Firmregistration"].ToString();
            firmRegistrationDetailsvo.regstrNumber = GDs.Tables[2].Rows[0]["GSTNumber"].ToString();
            firmRegistrationDetailsvo.yrOfCommence = Convert.ToInt64(GDs.Tables[2].Rows[0]["YearofCommencement_Firmregistration"].ToString());
            firmRegistrationDetailsvo.yrOfCommenceSpecified = true;
            firmRegistrationDetailsvo.yrOfEstbl = Convert.ToInt64(GDs.Tables[2].Rows[0]["YearofEstablishment_Firmregistration"].ToString());
            firmRegistrationDetailsvo.yrOfEstblSpecified = true;

            firmDetailsvo.firmRegistrationDetails = firmRegistrationDetailsvo;
            firmDetailsvo.userId = Convert.ToInt64(GDs.Tables[2].Rows[0]["Modified_by"].ToString());
            firmDetailsvo.userIdSpecified = true;
            verifyFirmvo.firmDetails = firmDetailsvo;
            verifyFirmvo.houseNo = GDs.Tables[2].Rows[0]["House_Prv_flot"].ToString();

            TSIICLANDCGG.CodeDesc orgtype = new TSIICLANDCGG.CodeDesc();
            orgtype.code = GDs.Tables[2].Rows[0]["TypeofOrganization_RegOfficesss"].ToString();
            orgtype.desc = GDs.Tables[2].Rows[0]["TypeofOrganization_RegOfficesss"].ToString();
            verifyFirmvo.orgType = orgtype;
            Commaddressvo.city = "";// GDs.Tables[2].Rows[0][""].ToString();
            Commaddressvo.country = "INDIA";// GDs.Tables[2].Rows[0][""].ToString();
            Commaddressvo.district = GDs.Tables[2].Rows[0]["Distid_CommAddrs"].ToString();
            Commaddressvo.doorNo = GDs.Tables[2].Rows[0]["Door_No_CommAddr"].ToString();
            Commaddressvo.mandal = GDs.Tables[2].Rows[0]["mandal_commaddrs"].ToString();
            Commaddressvo.pincode = GDs.Tables[2].Rows[0]["Pincode_CommAddr"].ToString();
            //CommcodeDescvo.code = GDs.Tables[2].Rows[0]["statecommaddrs"].ToString();
            // CommcodeDescvo.desc = GDs.Tables[2].Rows[0]["statecommaddrs"].ToString();
            Commaddressvo.state = codeDescvo;


            Commaddressvo.streetNo1 = GDs.Tables[2].Rows[0]["Street_1_CommAddr"].ToString();
            Commaddressvo.streetNo2 = GDs.Tables[2].Rows[0]["Street_2_CommAddr"].ToString();
            Commaddressvo.village = GDs.Tables[2].Rows[0]["Village_CommAddrs"].ToString();
            CommcommunicationAddressvo.address = Commaddressvo;


            TSIICLANDCGG.Landline comtelephone = new TSIICLANDCGG.Landline();

            TSIICLANDCGG.Landline comfaxno = new TSIICLANDCGG.Landline();
            //comtelephone.areaCode = GDs.Tables[2].Rows[0]["TelephonoNo1_CommAddr"].ToString();// GDs.Tables[2].Rows[0][""].ToString();
            landlinevo.formattedPhone = "";
            //comtelephone.number = GDs.Tables[2].Rows[0]["TelephonoNo2_CommAddr"].ToString(); //GDs.Tables[2].Rows[0]["FaxNo1_CommAddr"].ToString();
            landlinevo.phone = "";
            landlinevo.valid = true;
            landlinevo.validSpecified = true;
            communicationAddressvo.phoneNum = comtelephone;
            comfaxno.areaCode = GDs.Tables[2].Rows[0]["FaxNo1_CommAddr"].ToString();// GDs.Tables[2].Rows[0][""].ToString();
            landlinevo.formattedPhone = "";
            comfaxno.number = GDs.Tables[2].Rows[0]["FaxNo2_CommAddr"].ToString(); //GDs.Tables[2].Rows[0]["FaxNo1_CommAddr"].ToString();
            landlinevo.phone = "";
            landlinevo.valid = true;
            landlinevo.validSpecified = true;

            verifyFirmvo.otherCommFaxCode = GDs.Tables[2].Rows[0]["FaxNo1_CommAddr"].ToString();
            verifyFirmvo.otherCommFaxNumber = GDs.Tables[2].Rows[0]["FaxNo2_CommAddr"].ToString();
            verifyFirmvo.otherCommPhoneCode = GDs.Tables[2].Rows[0]["TelephonoNo1_CommAddr"].ToString();
            verifyFirmvo.otherCommPhoneNumber = GDs.Tables[2].Rows[0]["TelephonoNo2_CommAddr"].ToString();



            verifyFirmvo.otherCommunicationAddress = CommcommunicationAddressvo;
            verifyFirmvo.others = GDs.Tables[2].Rows[0]["OtherDetails_Prv_flot"].ToString();
            verifyFirmvo.plotNo = GDs.Tables[2].Rows[0]["PlotNo_Prv_flot"].ToString();
            verifyFirmvo.shedName = GDs.Tables[2].Rows[0]["ShedName_Prv_flot"].ToString();
            verifyFirmvo.shopNo = GDs.Tables[2].Rows[0]["Shop_Prv_flot"].ToString();

            ///promoter details///

            Contactaddressvo.city = "";// GDs.Tables[2].Rows[0][""].ToString();
            Contactaddressvo.country = "";// GDs.Tables[2].Rows[0][""].ToString();
            Contactaddressvo.district = GDs.Tables[2].Rows[0]["Distidcontactinfo"].ToString();
            Contactaddressvo.doorNo = GDs.Tables[2].Rows[0]["Door_No_Cont_info"].ToString();
            Contactaddressvo.mandal = GDs.Tables[2].Rows[0]["mandalcontinfo"].ToString();
            Contactaddressvo.pincode = GDs.Tables[2].Rows[0]["Pincode_Cont_info"].ToString();
            codeDescvo.code = GDs.Tables[2].Rows[0]["statecontinfos"].ToString();
            codeDescvo.desc = GDs.Tables[2].Rows[0]["statecontinfos"].ToString(); // GDs.Tables[2].Rows[0][""].ToString();
            Contactaddressvo.state = codeDescvo;
            Contactaddressvo.streetNo1 = GDs.Tables[2].Rows[0]["Street_1_Cont_info"].ToString();
            Contactaddressvo.streetNo2 = GDs.Tables[2].Rows[0]["Street_2_Cont_info"].ToString();
            Contactaddressvo.village = GDs.Tables[2].Rows[0]["villagecontinfo"].ToString();
            ContactcommunicationAddressvo.address = Contactaddressvo;

            TSIICLANDCGG.Landline contfax = new TSIICLANDCGG.Landline();
            contfax.areaCode = GDs.Tables[2].Rows[0]["FaxNo1_Cont_info"].ToString();
            landlinevo.formattedPhone = "";
            contfax.number = GDs.Tables[2].Rows[0]["MobileNo_Cont_info"].ToString();
            //landlinevo.phone =GDs.Tables[2].Rows[0]["TelephonoNo1_Cont_info"].ToString();
            landlinevo.valid = true;
            landlinevo.validSpecified = true;
            communicationAddressvo.faxNum = landlinevo;
            landlinevo.areaCode = GDs.Tables[2].Rows[0]["FaxNo2_Cont_info"].ToString();
            landlinevo.formattedPhone = "";
            //landlinevo.number = GDs.Tables[2].Rows[0]["TelephonoNo2_Cont_info"].ToString();
            landlinevo.phone = GDs.Tables[2].Rows[0]["TelephonoNo1_Cont_info"].ToString();
            landlinevo.valid = true;
            landlinevo.validSpecified = true;
            communicationAddressvo.phoneNum = landlinevo;

            promoterDetailsvo.commFaxCode = GDs.Tables[2].Rows[0]["FaxNo1_Cont_info"].ToString();
            promoterDetailsvo.commFaxNumber = GDs.Tables[2].Rows[0]["FaxNo2_Cont_info"].ToString();
            promoterDetailsvo.commPhoneCode = GDs.Tables[2].Rows[0]["TelephonoNo1_Cont_info"].ToString();
            promoterDetailsvo.commPhoneNumber = GDs.Tables[2].Rows[0]["TelephonoNo2_Cont_info"].ToString();
            promoterDetailsvo.cellNumber = GDs.Tables[2].Rows[0]["MobileNo_Cont_info"].ToString();

            promoterDetailsvo.communicationAddress = ContactcommunicationAddressvo;
            promoterDetailsvo.emailId = GDs.Tables[2].Rows[0]["Email_Cont_info"].ToString();
            mobilevo.areaCode = "";// GDs.Tables[2].Rows[0][""].ToString();
            mobilevo.formattedPhone = "";
            mobilevo.number = GDs.Tables[2].Rows[0]["MobileNo_Cont_info"].ToString();
            mobilevo.phone = GDs.Tables[2].Rows[0]["MobileNo_Cont_info"].ToString();
            mobilevo.valid = true;
            mobilevo.validSpecified = true;
            promoterDetailsvo.mobile = mobilevo;
            personvo.firstName = GDs.Tables[2].Rows[0]["FirstName_Cont_info"].ToString();
            personvo.surname = GDs.Tables[2].Rows[0]["Surname_Cont_info"].ToString();
            promoterDetailsvo.personName = personvo;
            promoterFinancialInformationvo.detlsImvableAssests = GDs.Tables[2].Rows[0]["Immovable_Assets_Land_Building_Financial"].ToString();
            promoterFinancialInformationvo.funcResponsibilities = GDs.Tables[2].Rows[0]["ProposedProject_Financial"].ToString();
            promoterFinancialInformationvo.otherAssests = Convert.ToDouble(GDs.Tables[2].Rows[0]["OtherAssets_Financial_Inlakhs"].ToString());
            promoterFinancialInformationvo.otherAssestsSpecified = true;
            promoterFinancialInformationvo.otherInfo = GDs.Tables[2].Rows[0]["Anyother_Financial_Info"].ToString();
            promoterFinancialInformationvo.panNo = GDs.Tables[2].Rows[0]["PanNumber_Financial_Info"].ToString();
            promoterFinancialInformationvo.personalAsset = Convert.ToDouble(GDs.Tables[2].Rows[0]["Assets_Financial_Inlakhs"].ToString());
            promoterFinancialInformationvo.personalAssetSpecified = true;
            promoterFinancialInformationvo.personalLiability = Convert.ToDouble(GDs.Tables[2].Rows[0]["Liabilities_Financial_Inlakhs"].ToString());
            promoterFinancialInformationvo.personalLiabilitySpecified = true;
            promoterDetailsvo.promoterFinancialInformation = promoterFinancialInformationvo;
            promoterDetailsvo.promoterId = 0;// GDs.Tables[2].Rows[0][""].ToString();
            promoterDetailsvo.promoterIdSpecified = true;
            promoterDetailsvo.userId = Convert.ToInt64(GDs.Tables[2].Rows[0]["Modified_by"].ToString());
            promoterDetailsvo.userIdSpecified = true;

            TSIICLANDCGG.Product[] product = null;
            projectGeneralvo.byProductList = product;
            if (GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infos"].ToString() != "" && GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infos"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infos"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');
                // paymentresponseVOsobj.TxnDate_13 = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();// +" " + date[1].ToString();
                TSIICLANDCGG.DateHolder datevocomme = new TSIICLANDCGG.DateHolder();
                datevocomme.day = newdate[0].ToString();
                datevocomme.displayDate = "";
                datevocomme.empty = true;
                datevocomme.emptySpecified = true;
                datevocomme.month = newdate[1].ToString();
                datevocomme.sqlDateStr = "";
                datevocomme.valid = true;
                datevocomme.validSpecified = true;
                datevocomme.year = newdate[2].ToString();

                projectGeneralvo.commOperationPhase1 = datevocomme;
            }

            if (GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infophase2"].ToString() != "" && GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infophase2"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infophase2"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');
                // paymentresponseVOsobj.TxnDate_13 = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();// +" " + date[1].ToString();
                TSIICLANDCGG.DateHolder datevocommercial = new TSIICLANDCGG.DateHolder();

                datevocommercial.day = newdate[0].ToString();
                datevocommercial.displayDate = "";
                datevocommercial.empty = true;
                datevocommercial.emptySpecified = true;
                datevocommercial.month = newdate[1].ToString();
                datevocommercial.sqlDateStr = "";
                datevocommercial.valid = true;
                datevocommercial.validSpecified = true;
                datevocommercial.year = newdate[2].ToString();
                projectGeneralvo.commOperationPhase2 = datevocommercial;
            }
            if (GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infophase3"].ToString() != "" && GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infophase3"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infophase3"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');
                TSIICLANDCGG.DateHolder datevocommercialphase2 = new TSIICLANDCGG.DateHolder();
                // paymentresponseVOsobj.TxnDate_13 = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();// +" " + date[1].ToString();

                datevocommercialphase2.day = newdate[0].ToString();
                datevocommercialphase2.displayDate = "";
                datevocommercialphase2.empty = true;
                datevocommercialphase2.emptySpecified = true;
                datevocommercialphase2.month = newdate[1].ToString();
                datevocommercialphase2.sqlDateStr = "";
                datevocommercialphase2.valid = true;
                datevocommercialphase2.validSpecified = true;
                datevocommercialphase2.year = newdate[2].ToString();
                projectGeneralvo.commOperationPhase3 = datevocommercialphase2;
            }
            if (GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infos"].ToString() != "" && GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infos"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infos"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');

                TSIICLANDCGG.DateHolder datevoconstruction = new TSIICLANDCGG.DateHolder();

                datevoconstruction.day = newdate[0].ToString();
                datevoconstruction.displayDate = "";
                datevoconstruction.empty = true;
                datevoconstruction.emptySpecified = true;
                datevoconstruction.month = newdate[1].ToString();
                datevoconstruction.sqlDateStr = "";
                datevoconstruction.valid = true;
                datevoconstruction.validSpecified = true;
                datevoconstruction.year = newdate[2].ToString();

                projectGeneralvo.constructionPhase1 = datevoconstruction;
            }
            if (GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infophase2"].ToString() != "" && GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infophase2"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infophase2"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');

                TSIICLANDCGG.DateHolder datevoconstructionphase2 = new TSIICLANDCGG.DateHolder();
                datevoconstructionphase2.day = newdate[0].ToString();
                datevoconstructionphase2.displayDate = "";
                datevoconstructionphase2.empty = true;
                datevoconstructionphase2.emptySpecified = true;
                datevoconstructionphase2.month = newdate[1].ToString();
                datevoconstructionphase2.sqlDateStr = "";
                datevoconstructionphase2.valid = true;
                datevoconstructionphase2.validSpecified = true;
                datevoconstructionphase2.year = newdate[2].ToString();
                projectGeneralvo.constructionPhase2 = datevoconstructionphase2;
            }

            if (GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infophase3"].ToString() != "" && GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infophase3"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infophase3"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');


                TSIICLANDCGG.DateHolder datevoconstructionphase3 = new TSIICLANDCGG.DateHolder();
                datevoconstructionphase3.day = newdate[0].ToString();
                datevoconstructionphase3.displayDate = "";
                datevoconstructionphase3.empty = true;
                datevoconstructionphase3.emptySpecified = true;
                datevoconstructionphase3.month = newdate[1].ToString();
                datevoconstructionphase3.sqlDateStr = "";
                datevoconstructionphase3.valid = true;
                datevoconstructionphase3.validSpecified = true;
                datevoconstructionphase3.year = newdate[2].ToString();
                projectGeneralvo.constructionPhase3 = datevoconstructionphase3;
            }
            projectGeneralvo.projCategory = GDs.Tables[2].Rows[0]["typeofprojectscategory"].ToString();
            projectGeneralvo.projCatgryOther = GDs.Tables[2].Rows[0]["projectother"].ToString();
            projectGeneralvo.projCatgryOtherValue = GDs.Tables[2].Rows[0]["ProjectCategory3_General_Info"].ToString();
            projectGeneralvo.projDesc = GDs.Tables[2].Rows[0]["ProjectName_Description_General_Info"].ToString();
            projectGeneralvo.projectId = 0;
            projectGeneralvo.projectIdSpecified = true;
            projectGeneralvo.projStatus = GDs.Tables[2].Rows[0]["typeofprojectstatus"].ToString();
            TSIICLANDCGG.Product[] productprosposed = null;
            if (GDs.Tables[7].Rows.Count > 0)
            {
                DataTable dtraw = new DataTable();
                dtraw = GDs.Tables[7];
                productprosposed = new TSIICLANDCGG.Product[dtraw.Rows.Count];

                for (int k = 0; k < dtraw.Rows.Count; k++)
                {
                    TSIICLANDCGG.Product Productvo = new TSIICLANDCGG.Product();
                    Productvo.code = dtraw.Rows[k]["Itemcode"].ToString();
                    Productvo.expectedOutput = 0.00; //dtraw.Rows[k][""].ToString();
                    Productvo.expectedOutputSpecified = true;

                    if (dtraw.Rows[k]["Installedcapacity"].ToString() == "")
                    {


                        Productvo.installedCapacity = 0;

                    }
                    else
                    {
                        Productvo.installedCapacity = Convert.ToDouble(dtraw.Rows[k]["Installedcapacity"]);
                    }

                    Productvo.installedCapacitySpecified = true;
                    Productvo.measurement = dtraw.Rows[k]["Unitmeasurement"].ToString();
                    Productvo.name = dtraw.Rows[k]["Product"].ToString();
                    Productvo.productId = 0;
                    Productvo.productIdSpecified = false;
                    productprosposed[k] = Productvo;
                    //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                    //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                }
                projectGeneralvo.propProductList = productprosposed;
            }
            projectGeneralvo.propProductList = productprosposed;

            if (GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infos"].ToString() != "" && GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infos"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infos"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');


                TSIICLANDCGG.DateHolder datevotrialperation = new TSIICLANDCGG.DateHolder();
                datevotrialperation.day = newdate[0].ToString();
                datevotrialperation.displayDate = "";
                datevotrialperation.empty = true;
                datevotrialperation.emptySpecified = true;
                datevotrialperation.month = newdate[1].ToString();
                datevotrialperation.sqlDateStr = "";
                datevotrialperation.valid = true;
                datevotrialperation.validSpecified = true;
                datevotrialperation.year = newdate[2].ToString();
                projectGeneralvo.trailOperationPhase1 = datevotrialperation;
            }
            if (GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infophase2"].ToString() != "" && GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infophase2"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infophase2"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');

                TSIICLANDCGG.DateHolder datevotrialperationphase2 = new TSIICLANDCGG.DateHolder();
                datevotrialperationphase2.day = newdate[0].ToString();
                datevotrialperationphase2.displayDate = "";
                datevotrialperationphase2.empty = true;
                datevotrialperationphase2.emptySpecified = true;
                datevotrialperationphase2.month = newdate[1].ToString();
                datevotrialperationphase2.sqlDateStr = "";
                datevotrialperationphase2.valid = true;
                datevotrialperationphase2.validSpecified = true;
                datevotrialperationphase2.year = newdate[2].ToString();
                projectGeneralvo.trailOperationPhase2 = datevotrialperationphase2;
            }

            if (GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infophase3"].ToString() != "" && GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infophase3"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infophase3"].ToString().Split(' ');


                TSIICLANDCGG.DateHolder datevotrialperationphase3 = new TSIICLANDCGG.DateHolder();
                string[] newdate = date[0].ToString().Split('-');
                datevotrialperationphase3.day = newdate[0].ToString();
                datevotrialperationphase3.displayDate = "";
                datevotrialperationphase3.empty = true;
                datevotrialperationphase3.emptySpecified = true;
                datevotrialperationphase3.month = newdate[1].ToString();
                datevotrialperationphase3.sqlDateStr = "";
                datevotrialperationphase3.valid = true;
                datevotrialperationphase3.validSpecified = true;
                datevotrialperationphase3.year = newdate[2].ToString();
                projectGeneralvo.trailOperationPhase3 = datevotrialperationphase3;
            }
            projectGeneralvo.ventureType1 = GDs.Tables[2].Rows[0]["Typeofventure"].ToString();
            projectGeneralvo.ventureType2 = "";
            if (GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhs"].ToString() != "")
            {
                projectFinancialvo.auxillaryEquipPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhs"].ToString());
            }
            projectFinancialvo.auxillaryEquipPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhsphase2"].ToString() != "")
            {
                projectFinancialvo.auxillaryEquipPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhsphase2"].ToString());
            }
            projectFinancialvo.auxillaryEquipPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhsphase3"].ToString() != "")
            {
                projectFinancialvo.auxillaryEquipPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhsphase3"].ToString());
            }
            projectFinancialvo.auxillaryEquipPhase3Specified = true;
            projectFinancialvo.auxillaryId = 0;
            projectFinancialvo.auxillaryIdSpecified = true;
            projectFinancialvo.buildingId = 0;
            projectFinancialvo.buildingIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhs"].ToString() != "")
            {
                projectFinancialvo.buildingsPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhs"].ToString());
            }
            projectFinancialvo.buildingsPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhsphase2"].ToString() != "")
            {
                projectFinancialvo.buildingsPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhsphase2"].ToString());
            }
            projectFinancialvo.buildingsPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhsphase3"].ToString() != "")
            {
                projectFinancialvo.buildingsPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhsphase3"].ToString());
            }
            projectFinancialvo.buildingsPhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhs"].ToString() != "")
            {
                projectFinancialvo.contingenciesPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhs"].ToString());
            }
            projectFinancialvo.contingenciesPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhsphase2"].ToString() != "")
            {
                projectFinancialvo.contingenciesPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhsphase2"].ToString());
            }
            projectFinancialvo.contingenciesPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhsphase3"].ToString() != "")
            {
                projectFinancialvo.contingenciesPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhsphase3"].ToString());
            }
            projectFinancialvo.contingenciesPhase3Specified = true;
            projectFinancialvo.contingeniousId = 0;
            projectFinancialvo.contingeniousIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Amount"].ToString() != null && GDs.Tables[2].Rows[0]["Amount"].ToString() != "")
            {
                projectFinancialvo.debtAmount = Convert.ToDouble(GDs.Tables[2].Rows[0]["Amount"].ToString());
            }
            projectFinancialvo.debtAmountSpecified = true;
            projectFinancialvo.debtName = GDs.Tables[2].Rows[0]["EquityName"].ToString();
            if (GDs.Tables[2].Rows[0]["EOUdate"].ToString() != "" && GDs.Tables[2].Rows[0]["EOUdate"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["EOUdate"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');

                TSIICLANDCGG.DateHolder equdate = new TSIICLANDCGG.DateHolder();
                equdate.day = newdate[0].ToString();
                equdate.displayDate = "";
                equdate.empty = true;
                equdate.emptySpecified = true;
                equdate.month = newdate[1].ToString();
                equdate.sqlDateStr = "";
                equdate.valid = true;
                equdate.validSpecified = true;
                equdate.year = newdate[2].ToString();
                projectFinancialvo.eouDate = equdate;
            }
            projectFinancialvo.eouNo = GDs.Tables[2].Rows[0]["EOUNo"].ToString();
            if (GDs.Tables[2].Rows[0]["Domestic"].ToString() != null && GDs.Tables[2].Rows[0]["Domestic"].ToString() != "")
            {
                projectFinancialvo.equityDomestic = Convert.ToDouble(GDs.Tables[2].Rows[0]["Domestic"].ToString());
            }
            projectFinancialvo.equityDomesticSpecified = true;
            if (GDs.Tables[2].Rows[0]["Foreigns"].ToString() != null && GDs.Tables[2].Rows[0]["Foreigns"].ToString() != "")
            {
                projectFinancialvo.equityForiegn = Convert.ToDouble(GDs.Tables[2].Rows[0]["Foreigns"].ToString());
            }
            projectFinancialvo.equityForiegnSpecified = true;

            if (GDs.Tables[2].Rows[0]["Foreigninvestmentdate"].ToString() != "" && GDs.Tables[2].Rows[0]["Foreigninvestmentdate"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Foreigninvestmentdate"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');

                TSIICLANDCGG.DateHolder foreigndate = new TSIICLANDCGG.DateHolder();
                foreigndate.day = newdate[0].ToString();
                foreigndate.displayDate = "";
                foreigndate.empty = true;
                foreigndate.emptySpecified = true;
                foreigndate.month = newdate[1].ToString();
                foreigndate.sqlDateStr = "";
                foreigndate.valid = true;
                foreigndate.validSpecified = true;
                foreigndate.year = newdate[2].ToString();
                projectFinancialvo.fipbRbiApprDate = foreigndate;
            }

            projectFinancialvo.fipbRbiApprNo = GDs.Tables[2].Rows[0]["Foreigninvestment"].ToString();
            if (GDs.Tables[2].Rows[0]["IEMdate"].ToString() != "" && GDs.Tables[2].Rows[0]["IEMdate"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["IEMdate"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');

                TSIICLANDCGG.DateHolder Iemdate = new TSIICLANDCGG.DateHolder();
                Iemdate.day = newdate[0].ToString();
                Iemdate.displayDate = "";
                Iemdate.empty = true;
                Iemdate.emptySpecified = true;
                Iemdate.month = newdate[1].ToString();
                Iemdate.sqlDateStr = "";
                Iemdate.valid = true;
                Iemdate.validSpecified = true;
                Iemdate.year = newdate[2].ToString();
                projectFinancialvo.iemDate = Iemdate;
            }
            projectFinancialvo.iemNo = GDs.Tables[2].Rows[0]["IEM"].ToString();
            if (GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhs"].ToString() != "")
            {
                projectFinancialvo.indigeneousPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhs"].ToString());
            }
            projectFinancialvo.indigeneousPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhsphase2"].ToString() != "")
            {
                projectFinancialvo.indigeneousPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhsphase2"].ToString());
            }
            projectFinancialvo.indigeneousPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhsphase3"].ToString() != "")
            {
                projectFinancialvo.indigeneousPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhsphase3"].ToString());
            }
            projectFinancialvo.indigeneousPhase3Specified = true;
            projectFinancialvo.indigeniousId = 0;
            projectFinancialvo.indigeniousIdSpecified = true;
            projectFinancialvo.landId = 0;
            projectFinancialvo.landIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhs"].ToString() != "")
            {
                projectFinancialvo.landPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhs"].ToString());
            }
            projectFinancialvo.landPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhsphase2"].ToString() != "")
            {
                projectFinancialvo.landPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhsphase2"].ToString());
            }
            projectFinancialvo.landPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhsphase3"].ToString() != "")
            {
                projectFinancialvo.landPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhsphase3"].ToString());
            }
            projectFinancialvo.landPhase3Specified = true;

            if (GDs.Tables[2].Rows[0]["LOIdate"].ToString() != "" && GDs.Tables[2].Rows[0]["LOIdate"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["LOIdate"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');

                TSIICLANDCGG.DateHolder loidate = new TSIICLANDCGG.DateHolder();
                loidate.day = newdate[0].ToString();
                loidate.displayDate = "";
                loidate.empty = true;
                loidate.emptySpecified = true;
                loidate.month = newdate[1].ToString();
                loidate.sqlDateStr = "";
                loidate.valid = true;
                loidate.validSpecified = true;
                loidate.year = newdate[2].ToString();
                projectFinancialvo.loiDate = loidate;
            }
            projectFinancialvo.loiNo = GDs.Tables[2].Rows[0]["LOI"].ToString();
            projectFinancialvo.machineryImportedId = 0;
            projectFinancialvo.machineryImportedIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhs"].ToString() != "")
            {
                projectFinancialvo.machineryImportedPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhs"].ToString());
            }
            projectFinancialvo.machineryImportedPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhsphase2"].ToString() != "")
            {
                projectFinancialvo.machineryImportedPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhsphase2"].ToString());
            }
            projectFinancialvo.machineryImportedPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhsphase3"].ToString() != "")
            {
                projectFinancialvo.machineryImportedPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhsphase3"].ToString());
            }
            projectFinancialvo.machineryImportedPhase3Specified = true;
            projectFinancialvo.miscFixedId = 0;
            projectFinancialvo.miscFixedIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhs"].ToString() != "")
            {
                projectFinancialvo.miscFxdAssestsPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhs"].ToString());
            }
            projectFinancialvo.miscFxdAssestsPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhsphase2"].ToString() != "")
            {
                projectFinancialvo.miscFxdAssestsPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhsphase2"].ToString());
            }
            projectFinancialvo.miscFxdAssestsPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhsphase3"].ToString() != "")
            {
                projectFinancialvo.miscFxdAssestsPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhsphase3"].ToString());
            }
            projectFinancialvo.miscFxdAssestsPhase3Specified = true;
            projectFinancialvo.preliminaryId = 0;
            projectFinancialvo.preliminaryIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhs"].ToString() != "")
            {
                projectFinancialvo.preliminaryPreOperativePhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhs"].ToString());
            }
            projectFinancialvo.preliminaryPreOperativePhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhsphase2"].ToString() != "")
            {
                projectFinancialvo.preliminaryPreOperativePhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhsphase2"].ToString());
            }
            projectFinancialvo.preliminaryPreOperativePhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhsphase3"].ToString() != "")
            {
                projectFinancialvo.preliminaryPreOperativePhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhsphase3"].ToString());
            }
            projectFinancialvo.preliminaryPreOperativePhase3Specified = true;
            projectFinancialvo.projectId = 0;
            projectFinancialvo.projectIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["TotalEquitdebit"].ToString() != null && GDs.Tables[2].Rows[0]["TotalEquitdebit"].ToString() != "")
            {
                projectFinancialvo.totalEqtyDebt = Convert.ToDouble(GDs.Tables[2].Rows[0]["TotalEquitdebit"].ToString());
            }
            projectFinancialvo.totalEqtyDebtSpecified = true;
            if (GDs.Tables[2].Rows[0]["TotalEquity"].ToString() != null && GDs.Tables[2].Rows[0]["TotalEquity"].ToString() != "")
            {
                projectFinancialvo.totalEquity = Convert.ToDouble(GDs.Tables[2].Rows[0]["TotalEquity"].ToString());
            }
            projectFinancialvo.totalEquitySpecified = true;
            if (GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhs"].ToString() != "")
            {
                projectFinancialvo.totalPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhs"].ToString());
            }
            projectFinancialvo.totalPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhsphase2"].ToString() != "")
            {
                projectFinancialvo.totalPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhsphase2"].ToString());
            }
            projectFinancialvo.totalPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhsphase3"].ToString() != "")
            {
                projectFinancialvo.totalPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhsphase3"].ToString());
            }
            projectFinancialvo.totalPhase3Specified = true;
            projectFinancialvo.workCapitalId = 0;
            projectFinancialvo.workCapitalIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhs"].ToString() != "")
            {
                projectFinancialvo.workCptlMarginPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhs"].ToString());
            }
            projectFinancialvo.workCptlMarginPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhsphase2"].ToString() != "")
            {
                projectFinancialvo.workCptlMarginPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhsphase2"].ToString());
            }
            projectFinancialvo.workCptlMarginPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhsphase3"].ToString() != "")
            {
                projectFinancialvo.workCptlMarginPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhsphase3"].ToString());
            }
            projectFinancialvo.workCptlMarginPhase3Specified = true;





            if (GDs.Tables[2].Rows[0]["femalephase1"].ToString() != null && GDs.Tables[2].Rows[0]["femalephase1"].ToString() != "")
            {
                projectEmploymentvo.femalePhase1 = Convert.ToInt64(GDs.Tables[2].Rows[0]["femalephase1"].ToString());
            }
            projectEmploymentvo.femalePhase1Specified = true;


            if (GDs.Tables[2].Rows[0]["femalephase2"].ToString() != null && GDs.Tables[2].Rows[0]["femalephase2"].ToString() != "")
            {
                projectEmploymentvo.femalePhase2 = Convert.ToInt64(GDs.Tables[2].Rows[0]["femalephase2"].ToString());
            }
            projectEmploymentvo.femalePhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["femalephase3"].ToString() != null && GDs.Tables[2].Rows[0]["femalephase3"].ToString() != "")
            {
                projectEmploymentvo.femalePhase3 = Convert.ToInt64(GDs.Tables[2].Rows[0]["femalephase3"].ToString());
            }
            projectEmploymentvo.femalePhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["malephase1"].ToString() != null && GDs.Tables[2].Rows[0]["malephase1"].ToString() != "")
            {
                projectEmploymentvo.malePhase1 = Convert.ToInt64(GDs.Tables[2].Rows[0]["malephase1"].ToString());
            }
            projectEmploymentvo.malePhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["malephase2"].ToString() != null && GDs.Tables[2].Rows[0]["malephase2"].ToString() != "")
            {
                projectEmploymentvo.malePhase2 = Convert.ToInt64(GDs.Tables[2].Rows[0]["malephase2"].ToString());
            }
            projectEmploymentvo.malePhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["malephase3"].ToString() != null && GDs.Tables[2].Rows[0]["malephase3"].ToString() != "")
            {
                projectEmploymentvo.malePhase3 = Convert.ToInt64(GDs.Tables[2].Rows[0]["malephase3"].ToString());
            }
            projectEmploymentvo.malePhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["Managerial_Emp"].ToString() != null && GDs.Tables[2].Rows[0]["Managerial_Emp"].ToString() != "")
            {
                projectEmploymentvo.managerialPhase1 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Managerial_Emp"].ToString());
            }
            projectEmploymentvo.managerialPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Managerial_Empphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Managerial_Empphase2"].ToString() != "")
            {
                projectEmploymentvo.managerialPhase2 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Managerial_Empphase2"].ToString());
            }
            projectEmploymentvo.managerialPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Managerial_Empphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Managerial_Empphase3"].ToString() != "")
            {
                projectEmploymentvo.managerialPhase3 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Managerial_Empphase3"].ToString());
            }
            projectEmploymentvo.managerialPhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["Workers_factory_emp"].ToString() != null && GDs.Tables[2].Rows[0]["Workers_factory_emp"].ToString() != "")
            {
                projectEmploymentvo.maxNoWorkers = Convert.ToInt64(GDs.Tables[2].Rows[0]["Workers_factory_emp"].ToString());
            }
            projectEmploymentvo.maxNoWorkersSpecified = true;
            projectEmploymentvo.projectId = 0;
            projectEmploymentvo.projectIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Skilled_Emp"].ToString() != null && GDs.Tables[2].Rows[0]["Skilled_Emp"].ToString() != "")
            {
                projectEmploymentvo.skilledPhase1 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Skilled_Emp"].ToString());
            }
            projectEmploymentvo.skilledPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Skilled_Empphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Skilled_Empphase2"].ToString() != "")
            {
                projectEmploymentvo.skilledPhase2 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Skilled_Empphase2"].ToString());
            }
            projectEmploymentvo.skilledPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Skilled_Empphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Skilled_Empphase3"].ToString() != "")
            {
                projectEmploymentvo.skilledPhase3 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Skilled_Empphase3"].ToString());
            }
            projectEmploymentvo.skilledPhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["Supervisory_Emp"].ToString() != null && GDs.Tables[2].Rows[0]["Supervisory_Emp"].ToString() != "")
            {
                projectEmploymentvo.supervisoryPhase1 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Supervisory_Emp"].ToString());
            }
            projectEmploymentvo.supervisoryPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Supervisory_Empphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Supervisory_Empphase2"].ToString() != "")
            {
                projectEmploymentvo.supervisoryPhase2 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Supervisory_Empphase2"].ToString());
            }
            projectEmploymentvo.supervisoryPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Supervisory_Empphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Supervisory_Empphase3"].ToString() != "")
            {
                projectEmploymentvo.supervisoryPhase3 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Supervisory_Empphase3"].ToString());
            }
            projectEmploymentvo.supervisoryPhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["Total_Emp"].ToString() != null && GDs.Tables[2].Rows[0]["Total_Emp"].ToString() != "")
            {
                projectEmploymentvo.totalPhase1 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Total_Emp"].ToString());
            }
            projectEmploymentvo.totalPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Total_Empphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Total_Empphase2"].ToString() != "")
            {
                projectEmploymentvo.totalPhase2 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Total_Empphase2"].ToString());
            }
            projectEmploymentvo.totalPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Total_Empphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Total_Empphase3"].ToString() != "")
            {
                projectEmploymentvo.totalPhase3 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Total_Empphase3"].ToString());
            }
            projectEmploymentvo.totalPhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["Unskilled_Emp"].ToString() != null && GDs.Tables[2].Rows[0]["Unskilled_Emp"].ToString() != "")
            {
                projectEmploymentvo.unSkilledPhase1 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Unskilled_Emp"].ToString());
            }
            projectEmploymentvo.unSkilledPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Unskilled_Empphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Unskilled_Empphase2"].ToString() != "")
            {
                projectEmploymentvo.unSkilledPhase2 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Unskilled_Empphase2"].ToString());
            }
            projectEmploymentvo.unSkilledPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Unskilled_Empphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Unskilled_Empphase3"].ToString() != "")
            {
                projectEmploymentvo.unSkilledPhase3 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Unskilled_Empphase3"].ToString());
            }
            projectEmploymentvo.unSkilledPhase3Specified = true;


            projectMaterialManufacturingvo.descProcessTech = GDs.Tables[2].Rows[0]["providedetails"].ToString();

            projectMaterialManufacturingvo.processTechnology = GDs.Tables[2].Rows[0]["processtechnology"].ToString();
            projectMaterialManufacturingvo.projectId = 0;
            projectMaterialManufacturingvo.projectIdSpecified = true;
            projectMaterialManufacturingvo.projectmatManf = "";
            TSIICLANDCGG.RawMaterial[] rawmaterial = null;
            if (GDs.Tables[8].Rows.Count > 0)
            {
                DataTable dtraw = new DataTable();
                dtraw = GDs.Tables[8];
                rawmaterial = new TSIICLANDCGG.RawMaterial[dtraw.Rows.Count];

                for (int k = 0; k < dtraw.Rows.Count; k++)
                {
                    TSIICLANDCGG.RawMaterial rawmaterialvo = new TSIICLANDCGG.RawMaterial();


                    if (dtraw.Rows[k]["DailyConsumption"].ToString() == "")
                    {
                        rawmaterialvo.dailyConsumption = 0;
                    }
                    else
                    {

                        rawmaterialvo.dailyConsumption = Convert.ToDouble(dtraw.Rows[k]["DailyConsumption"].ToString());
                    }


                    rawmaterialvo.dailyConsumptionSpecified = true;
                    rawmaterialvo.itemCode = dtraw.Rows[k]["Itemcode"].ToString();
                    rawmaterialvo.itemDescription = dtraw.Rows[k]["Descriptionitem"].ToString();
                    rawmaterialvo.rawMaterialId = 0;
                    // Convert.ToInt64(dtraw.Rows[k]["queryRespDocName"].ToString());
                    rawmaterialvo.rawMaterialIdSpecified = true;
                    rawmaterialvo.unitOfMeasure = dtraw.Rows[k]["unitmeasurement"].ToString();
                    rawmaterial[k] = rawmaterialvo;
                }
                projectMaterialManufacturingvo.rawMaterialList = rawmaterial;
            }

            projectMaterialManufacturingvo.rawMaterialList = rawmaterial;
            projectMaterialManufacturingvo.techCollaborationDetails = GDs.Tables[2].Rows[0]["technicalcollabration"].ToString();
            projectMaterialManufacturingvo.technicalCollaboration = true;
            projectMaterialManufacturingvo.technicalCollaborationSpecified = true;

            if (GDs.Tables[2].Rows[0]["noofvessels"] != null && GDs.Tables[2].Rows[0]["noofvessels"]
                .ToString() != "")
            {
                projectPlantMachineryvo.highPressureLevel = Convert.ToInt64(GDs.Tables[2].Rows[0]
                    ["noofvessels"].ToString());
            }
            projectPlantMachineryvo.highPressureLevelSpecified = true;

            TSIICLANDCGG.MachineryCapacity[] machinery = null;
            if (GDs.Tables[9].Rows.Count > 0)
            {
                DataTable dtraw = new DataTable();
                dtraw = GDs.Tables[9];
                machinery = new TSIICLANDCGG.MachineryCapacity[dtraw.Rows.Count];

                for (int k = 0; k < dtraw.Rows.Count; k++)
                {
                    TSIICLANDCGG.MachineryCapacity MachineryCapacityvo = new TSIICLANDCGG.MachineryCapacity();

                    if (dtraw.Rows[k]["capacitykw"].ToString() == "")
                    {
                        MachineryCapacityvo.plantCapacity = 0;

                    }
                    else
                    {
                        MachineryCapacityvo.plantCapacity = Convert.ToDouble(dtraw.Rows[k]["capacitykw"]);

                    }

                    MachineryCapacityvo.plantCapacitySpecified = true;
                    MachineryCapacityvo.plantDescription = dtraw.Rows[k]["descplantmachinery"].ToString();
                    MachineryCapacityvo.plantMachineryId = 0;
                    MachineryCapacityvo.plantMachineryIdSpecified = true;
                    MachineryCapacityvo.costofmachinery = dtraw.Rows[k]["cost"].ToString();
                    MachineryCapacityvo.numberofmachineries = dtraw.Rows[k]["Quantity"].ToString();





                    machinery[k] = MachineryCapacityvo;
                }
            }
            projectPlantMachineryvo.machineryCapacties = machinery;





            projectPlantMachineryvo.projectId = 0;
            projectPlantMachineryvo.projectIdSpecified = true;

            landvo.adminBuildingId = 0;
            landvo.adminBuildingIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequired"].ToString() != null && GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequired"].ToString() != "")
            {
                landvo.adminBuildingPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequired"].ToString());
            }
            landvo.adminBuildingPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequiredphase2"].ToString() != null && GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequiredphase2"].ToString() != "")
            {
                landvo.adminBuildingPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequiredphase2"].ToString());
            }
            landvo.adminBuildingPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequiredphase3"].ToString() != null && GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequiredphase3"].ToString() != "")
            {
                landvo.adminBuildingPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequiredphase3"].ToString());
            }
            landvo.adminBuildingPhase3Specified = true;
            landvo.estimatedarea = 0.00;// Convert.ToDouble(GDs.Tables[2].Rows[0][""].ToString());
            landvo.estimatedareaSpecified = true;
            landvo.indusShed = Convert.ToDouble(GDs.Tables[1].Rows[0]["Area_in_Sq_Mtrs"].ToString());
            landvo.indusShedSpecified = true;
            landvo.landId = 0;
            landvo.landIdSpecified = true;
            landvo.openAreaId = 0;
            landvo.openAreaIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequired"].ToString() != null && GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequired"].ToString() != "")
            {
                landvo.openAreaPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequired"].ToString());
            }
            landvo.openAreaPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequiredphase2"].ToString() != null && GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequiredphase2"].ToString() != "")
            {
                landvo.openAreaPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequiredphase2"].ToString());
            }
            landvo.openAreaPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequiredphase3"].ToString() != null && GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequiredphase3"].ToString() != "")
            {
                landvo.openAreaPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequiredphase3"].ToString());
            }
            landvo.openAreaPhase3Specified = true;
            landvo.plantFactoryBuildingId = 0;
            landvo.plantFactoryBuildingIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequired"].ToString() != null && GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequired"].ToString() != "")
            {
                landvo.plantFactoryPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequired"].ToString());
            }
            landvo.plantFactoryPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequiredphase2"].ToString() != null && GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequiredphase2"].ToString() != "")
            {
                landvo.plantFactoryPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequiredphase2"].ToString());
            }
            landvo.plantFactoryPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequiredphase3"].ToString() != null && GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequiredphase3"].ToString() != "")
            {
                landvo.plantFactoryPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequiredphase3"].ToString());
            }
            landvo.plantFactoryPhase3Specified = true;
            landvo.remarks = "";
            if (GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequired"].ToString() != null && GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequired"].ToString() != "")
            {
                landvo.roadWaterPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequired"].ToString());
            }
            landvo.roadWaterPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequiredphase2"].ToString() != null && GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequiredphase2"].ToString() != "")
            {
                landvo.roadWaterPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequiredphase2"].ToString());
            }
            landvo.roadWaterPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequiredphase3"].ToString() != null && GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequiredphase3"].ToString() != "")
            {
                landvo.roadWaterPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequiredphase3"].ToString());
            }
            landvo.roadWaterPhase3Specified = true;
            landvo.roadWtrStrgId = 0;
            landvo.roadWtrStrgIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequired"].ToString() != null && GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequired"].ToString() != "")
            {
                landvo.storageWaterPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequired"].ToString());
            }
            landvo.storageWaterPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequiredphase2"].ToString() != null && GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequiredphase2"].ToString() != "")
            {
                landvo.storageWaterPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequiredphase2"].ToString());
            }
            landvo.storageWaterPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequiredphase3"].ToString() != null && GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequiredphase3"].ToString() != "")
            {
                landvo.storageWaterPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequiredphase3"].ToString());
            }
            landvo.storageWaterPhase3Specified = true;
            landvo.storageWtrHosueId = 0;
            landvo.storageWtrHosueIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Total_LandRequired"].ToString() != null && GDs.Tables[2].Rows[0]["Total_LandRequired"].ToString() != "")
            {
                landvo.totalPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Total_LandRequired"].ToString());
            }
            landvo.totalPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Total_LandRequiredphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Total_LandRequiredphase2"].ToString() != "")
            {
                landvo.totalPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Total_LandRequiredphase2"].ToString());
            }
            landvo.totalPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Total_LandRequiredphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Total_LandRequiredphase3"].ToString() != "")
            {
                landvo.totalPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Total_LandRequiredphase3"].ToString());
            }
            landvo.totalPhase3Specified = true;

            if (GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupply"].ToString() != "" && GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupply"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupply"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');
                TSIICLANDCGG.DateHolder commmercialpowersupply = new TSIICLANDCGG.DateHolder();

                commmercialpowersupply.day = newdate[0].ToString();
                commmercialpowersupply.displayDate = "";
                commmercialpowersupply.empty = true;
                commmercialpowersupply.emptySpecified = true;
                commmercialpowersupply.month = newdate[1].ToString();
                commmercialpowersupply.sqlDateStr = "";
                commmercialpowersupply.valid = true;
                commmercialpowersupply.validSpecified = true;
                commmercialpowersupply.year = newdate[2].ToString();
                electricityvo.commercialPhase1 = commmercialpowersupply;
            }
            if (GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupplyphase2"].ToString() != "" && GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupplyphase2"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupplyphase2"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');

                TSIICLANDCGG.DateHolder commmercialpowersupplyphase2 = new TSIICLANDCGG.DateHolder();
                commmercialpowersupplyphase2.day = newdate[0].ToString();
                commmercialpowersupplyphase2.displayDate = "";
                commmercialpowersupplyphase2.empty = true;
                commmercialpowersupplyphase2.emptySpecified = true;
                commmercialpowersupplyphase2.month = newdate[1].ToString();
                commmercialpowersupplyphase2.sqlDateStr = "";
                commmercialpowersupplyphase2.valid = true;
                commmercialpowersupplyphase2.validSpecified = true;
                commmercialpowersupplyphase2.year = newdate[2].ToString();
                electricityvo.commercialPhase2 = commmercialpowersupplyphase2;
            }
            if (GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupplyphase3"].ToString() != "" && GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupplyphase3"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupplyphase3"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');

                TSIICLANDCGG.DateHolder commmercialpowersupplyphase3 = new TSIICLANDCGG.DateHolder();
                commmercialpowersupplyphase3.day = newdate[0].ToString();
                commmercialpowersupplyphase3.displayDate = "";
                commmercialpowersupplyphase3.empty = true;
                commmercialpowersupplyphase3.emptySpecified = true;
                commmercialpowersupplyphase3.month = newdate[1].ToString();
                commmercialpowersupplyphase3.sqlDateStr = "";
                commmercialpowersupplyphase3.valid = true;
                commmercialpowersupplyphase3.validSpecified = true;
                commmercialpowersupplyphase3.year = newdate[2].ToString();
                electricityvo.commercialPhase3 = commmercialpowersupplyphase3;
            }
            if (GDs.Tables[2].Rows[0]["Connectedload_KW"].ToString() != null && GDs.Tables[2].Rows[0]["Connectedload_KW"].ToString() != "")
            {
                electricityvo.connectedLoadPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Connectedload_KW"].ToString());
            }
            electricityvo.connectedLoadPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Connectedload_KWphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Connectedload_KWphase2"].ToString() != "")
            {
                electricityvo.connectedLoadPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Connectedload_KWphase2"].ToString());
            }
            electricityvo.connectedLoadPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Connectedload_KWphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Connectedload_KWphase3"].ToString() != "")
            {
                electricityvo.connectedLoadPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Connectedload_KWphase3"].ToString());
            }
            electricityvo.connectedLoadPhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplys"].ToString() != "" && GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplys"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplys"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');



                TSIICLANDCGG.DateHolder constructionpowersupply = new TSIICLANDCGG.DateHolder();


                constructionpowersupply.day = newdate[0].ToString();
                constructionpowersupply.displayDate = "";
                constructionpowersupply.empty = true;
                constructionpowersupply.emptySpecified = true;
                constructionpowersupply.month = newdate[1].ToString();
                constructionpowersupply.sqlDateStr = "";
                constructionpowersupply.valid = true;
                constructionpowersupply.validSpecified = true;
                constructionpowersupply.year = newdate[2].ToString();
                electricityvo.constructionPhase1 = constructionpowersupply;
            }
            if (GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplyphase2"].ToString() != "" && GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplyphase2"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplyphase2"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');


                TSIICLANDCGG.DateHolder constructionpowersupply2 = new TSIICLANDCGG.DateHolder();
                constructionpowersupply2.day = newdate[0].ToString();
                constructionpowersupply2.day = "";
                constructionpowersupply2.displayDate = "";
                constructionpowersupply2.empty = true;
                constructionpowersupply2.emptySpecified = true;
                constructionpowersupply2.month = newdate[1].ToString();
                constructionpowersupply2.sqlDateStr = "";
                constructionpowersupply2.valid = true;
                constructionpowersupply2.validSpecified = true;
                constructionpowersupply2.year = newdate[2].ToString();
                electricityvo.constructionPhase2 = constructionpowersupply2;
            }
            if (GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplyphase3"].ToString() != "" && GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplyphase3"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplyphase3"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');

                TSIICLANDCGG.DateHolder constructionpowersupply3 = new TSIICLANDCGG.DateHolder();

                constructionpowersupply3.day = newdate[0].ToString();

                constructionpowersupply3.displayDate = "";
                constructionpowersupply3.empty = true;
                constructionpowersupply3.emptySpecified = true;
                constructionpowersupply3.month = newdate[1].ToString();
                constructionpowersupply3.sqlDateStr = "";
                constructionpowersupply3.valid = true;
                constructionpowersupply3.validSpecified = true;
                constructionpowersupply3.year = newdate[2].ToString();
                electricityvo.constructionPhase3 = constructionpowersupply3;
            }
            if (GDs.Tables[2].Rows[0]["ContractedMaxDem_KVA"].ToString() != null && GDs.Tables[2].Rows[0]["ContractedMaxDem_KVA"].ToString() != "")
            {
                electricityvo.contractDemandPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["ContractedMaxDem_KVA"].ToString());
            }
            electricityvo.contractDemandPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["ContractedMaxDem_KVAphase2"].ToString() != null && GDs.Tables[2].Rows[0]["ContractedMaxDem_KVAphase2"].ToString() != "")
            {
                electricityvo.contractDemandPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["ContractedMaxDem_KVAphase2"].ToString());
            }
            electricityvo.contractDemandPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["ContractedMaxDem_KVAphase3"].ToString() != null && GDs.Tables[2].Rows[0]["ContractedMaxDem_KVAphase3"].ToString() != "")
            {
                electricityvo.contractDemandPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["ContractedMaxDem_KVAphase3"].ToString());
            }
            electricityvo.contractDemandPhase3Specified = true;
            electricityvo.energySrcDGSet = GDs.Tables[2].Rows[0]["DGset"].ToString();
            electricityvo.energySrcGeneration = GDs.Tables[2].Rows[0]["owngeneration"].ToString();
            electricityvo.energySrcSupply = GDs.Tables[2].Rows[0]["TStranscosupply"].ToString();
            electricityvo.landId = 0;
            electricityvo.landIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Loadfactor"].ToString() != null && GDs.Tables[2].Rows[0]["Loadfactor"].ToString() != "")
            {
                electricityvo.loadFactorPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Loadfactor"].ToString());
            }
            electricityvo.loadFactorPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Loadfactorphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Loadfactorphase2"].ToString() != "")
            {
                electricityvo.loadFactorPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Loadfactorphase2"].ToString());
            }
            electricityvo.loadFactorPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Loadfactorphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Loadfactorphase3"].ToString() != "")
            {
                electricityvo.loadFactorPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Loadfactorphase3"].ToString());
            }
            electricityvo.loadFactorPhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVA"].ToString() != null && GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVA"].ToString() != "")
            {
                electricityvo.powerRequirementPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVA"].ToString());
            }
            electricityvo.powerRequirementPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVAphase2"].ToString() != null && GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVAphase2"].ToString() != "")
            {
                electricityvo.powerRequirementPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVAphase2"].ToString());
            }
            electricityvo.powerRequirementPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVAphase3"].ToString() != null && GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVAphase3"].ToString() != "")
            {
                electricityvo.powerRequirementPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVAphase3"].ToString());
            }
            electricityvo.powerRequirementPhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["Req_PowerSupply_KV"].ToString() != null && GDs.Tables[2].Rows[0]["Req_PowerSupply_KV"].ToString() != "")
            {
                electricityvo.powerSupplyPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Req_PowerSupply_KV"].ToString());
            }
            electricityvo.powerSupplyPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Req_PowerSupply_KVphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Req_PowerSupply_KVphase2"].ToString() != "")
            {
                electricityvo.powerSupplyPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Req_PowerSupply_KVphase2"].ToString());
            }
            electricityvo.powerSupplyPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Req_PowerSupply_KVphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Req_PowerSupply_KVphase3"].ToString() != "")
            {
                electricityvo.powerSupplyPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Req_PowerSupply_KVphase3"].ToString());
            }
            electricityvo.powerSupplyPhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["VoltageRating_HT"].ToString() != null && GDs.Tables[2].Rows[0]["VoltageRating_HT"].ToString() != "")
            {
                electricityvo.voltageRatingPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["VoltageRating_HT"].ToString());
            }
            electricityvo.voltageRatingPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["VoltageRating_HTphase2"].ToString() != null && GDs.Tables[2].Rows[0]["VoltageRating_HTphase2"].ToString() != "")
            {
                electricityvo.voltageRatingPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["VoltageRating_HTphase2"].ToString());
            }
            electricityvo.voltageRatingPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["VoltageRating_HTphase3"].ToString() != null && GDs.Tables[2].Rows[0]["VoltageRating_HTphase3"].ToString() != "")
            {
                electricityvo.voltageRatingPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["VoltageRating_HTphase3"].ToString());
            }
            electricityvo.voltageRatingPhase3Specified = true;

            watervo.landId = 0;
            watervo.landIdSpecified = true;
            watervo.permtDomesticId = 0;
            watervo.permtDomesticIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReq"].ToString() != null && GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReq"].ToString() != "")
            {
                watervo.permtDomesticPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReq"].ToString());
            }
            watervo.permtDomesticPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReqphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReqphase2"].ToString() != "")
            {
                watervo.permtDomesticPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReqphase2"].ToString());
            }
            watervo.permtDomesticPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReqphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReqphase3"].ToString() != "")
            {
                watervo.permtDomesticPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReqphase3"].ToString());
            }
            watervo.permtDomesticPhase3Specified = true;
            watervo.permtIndustrialId = 0;
            watervo.permtIndustrialIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReq"].ToString() != null && GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReq"].ToString() != "")
            {
                watervo.permtIndustrialPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReq"].ToString());
            }
            watervo.permtIndustrialPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReqphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReqphase2"].ToString() != "")
            {
                watervo.permtIndustrialPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReqphase2"].ToString());
            }
            watervo.permtIndustrialPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReqphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReqphase3"].ToString() != "")
            {
                watervo.permtIndustrialPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReqphase3"].ToString());
            }
            watervo.permtIndustrialPhase3Specified = true;
            watervo.tempDomesticId = 0;
            watervo.tempDomesticIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReq"].ToString() != null && GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReq"].ToString() != "")
            {
                watervo.tempDomesticPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReq"].ToString());
            }
            watervo.tempDomesticPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReqphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReqphase2"].ToString() != "")
            {
                watervo.tempDomesticPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReqphase2"].ToString());
            }
            watervo.tempDomesticPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReqphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReqphase3"].ToString() != "")
            {
                watervo.tempDomesticPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReqphase3"].ToString());
            }
            watervo.tempDomesticPhase3Specified = true;
            watervo.tempIndustrialId = 0;
            watervo.tempIndustrialIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase2"].ToString() != "")
            {
                watervo.tempIndustrialPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReq"].ToString());
            }
            watervo.tempIndustrialPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase2"].ToString() != "")
            {
                watervo.tempIndustrialPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase2"].ToString());
            }
            watervo.tempIndustrialPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase3"].ToString() != "")
            {
                watervo.tempIndustrialPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase3"].ToString());
            }
            watervo.tempIndustrialPhase3Specified = true;

            effluentsvo.disposalSystem = GDs.Tables[2].Rows[0]["Descriptioneffulents"].ToString();
            effluentsvo.landId = 0;
            effluentsvo.landIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Effluentsphase1"].ToString() == "NIL" || GDs.Tables[2].Rows[0]["Effluentsphase1"].ToString() == "")
            {
                effluentsvo.quantityPhase1 = 0;
            }
            else
            {
                effluentsvo.quantityPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Effluentsphase1"].ToString());
            }
            effluentsvo.quantityPhase1Specified = true;


            if (GDs.Tables[2].Rows[0]["Effluentsphase2"].ToString() == null || GDs.Tables[2].Rows[0]["Effluentsphase2"].ToString() == "")
            {
                effluentsvo.quantityPhase2 = 0;
            }
            else
            {

                effluentsvo.quantityPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Effluentsphase2"].ToString());
            }
            effluentsvo.quantityPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Effluentsphase3"].ToString() == null || GDs.Tables[2].Rows[0]["Effluentsphase3"].ToString() == "")
            {
                effluentsvo.quantityPhase3 = 0;
            }
            else
            {

                effluentsvo.quantityPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Effluentsphase3"].ToString());
            }
            effluentsvo.quantityPhase3Specified = true;
            effluentsvo.typeDescription = GDs.Tables[2].Rows[0]["Descriptioneffulents"].ToString();
            if (GDs.Tables[2].Rows[0]["Soildwastephase1"].ToString() != null && GDs.Tables[2].Rows[0]["Soildwastephase1"].ToString() != "")
            {
                effluentsvo.wastagePhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Soildwastephase1"].ToString());
            }
            effluentsvo.wastagePhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Soildwastephase2"].ToString() != null && GDs.Tables[2].Rows[0]["Soildwastephase2"].ToString() != "")
            {
                effluentsvo.wastagePhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Soildwastephase2"].ToString());
            }
            effluentsvo.wastagePhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Soildwastephase3"].ToString() != null && GDs.Tables[2].Rows[0]["Soildwastephase3"].ToString() != "")
            {
                effluentsvo.wastagePhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Soildwastephase3"].ToString());
            }
            effluentsvo.wastagePhase3Specified = true;

        }

        if (GDs.Tables[3].Rows.Count > 0)
        {
            DataTable dtceigdocuments = new DataTable();
            dtceigdocuments = GDs.Tables[3];
            for (int n = 0; n < dtceigdocuments.Rows.Count; n++)
            {
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "1")
                {
                    documentCheckListvo.detailedProject = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }

                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "2")
                {
                    documentCheckListvo.enterpreneurMemorandum = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }
                //documentCheckListvo.
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "3")
                {
                    documentCheckListvo.partnerShipDeed = dtceigdocuments.Rows[n]["Filepath"].ToString();// GDs.Tables[3].Rows[0]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "4")
                {
                    documentCheckListvo.shareHolderDetails = dtceigdocuments.Rows[n]["Filepath"].ToString();// GDs.Tables[3].Rows[0]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "5")
                {
                    documentCheckListvo.plantLayout = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "6")
                {
                    documentCheckListvo.casteCertificate = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "7")
                {
                    documentCheckListvo.addressProof = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "8")
                {
                    documentCheckListvo.panCard = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "9")
                {
                    documentCheckListvo.photoGraph = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "10")
                {
                    documentCheckListvo.financeCertificate = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "11")
                {
                    documentCheckListvo.paymentReceipt = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "12")
                {
                    documentCheckListvo.gstCertificate = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "13")
                {
                    documentCheckListvo.otherDocument = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "16")
                {
                    documentCheckListvo.cancelledCheck = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "14")
                {
                    projectFinancialvo.workingSheet = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "15")
                {

                    projectMaterialManufacturingvo.fileName = dtceigdocuments.Rows[n]["Filepath"].ToString();

                }
                else
                {

                    projectMaterialManufacturingvo.fileName = GDs.Tables[2].Rows[0]["filepath"].ToString();
                }
               


            }
        }


        TSIICLANDCGG.AdditionalPromoter[] additionalPromotervo = null;// new TSIICLANDCGG.AdditionalPromoter();

        //new TSIICLANDCGG.AdditionalPromoter();
        if (GDs.Tables[4].Rows.Count > 0)
        {
            TSIICLANDCGG.AdditionalPromoter[] AdditionalPromotervo = null;
            DataTable dtraw = new DataTable();
            dtraw = GDs.Tables[4];
            AdditionalPromotervo = new TSIICLANDCGG.AdditionalPromoter[dtraw.Rows.Count];

            for (int k = 0; k < dtraw.Rows.Count; k++)
            {
                //FactoryService.rawMaterial BBB = new FactoryService.rawMaterial();
                TSIICLANDCGG.AdditionalPromoter coc = new TSIICLANDCGG.AdditionalPromoter();
                coc.additionalPromoterId = 0;// Convert.ToInt32(dtraw.Rows[k]["0"]);
                coc.additionalPromoterIdSpecified = false;// Convert.ToBoolean(dtraw.Rows[k]["false"]);
                if (dtraw.Rows[k]["Experience"].ToString() != null && dtraw.Rows[k]["Experience"].ToString() != "")
                {
                    coc.experience = Convert.ToDouble(dtraw.Rows[k]["Experience"].ToString());
                }
                coc.experienceSpecified = true;
                coc.name = dtraw.Rows[k]["Name"].ToString();
                coc.netWorthSpecified = true;
                //coc.m = dtraw.Rows[k]["Contractor_MobileNo"].ToString();
                coc.netWorth = Convert.ToInt32(dtraw.Rows[k]["Networth"]);
                coc.qualification = dtraw.Rows[k]["Qualification"].ToString();
                coc.contactNo = dtraw.Rows[k]["ContactNo"].ToString();
                coc.address = dtraw.Rows[k]["Address"].ToString();
                AdditionalPromotervo[k] = coc;
                //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
            }
            additionalPromotervo = AdditionalPromotervo;

        }
        if (GDs.Tables[5].Rows.Count > 0)
        {

            registraionvo.companyAddress = "";
            registraionvo.companyAreaCode = "";
            registraionvo.companyName = "";
            registraionvo.companyPhone = "";
            registraionvo.emailId = GDs.Tables[5].Rows[0]["Email"].ToString();
            registraionvo.firstName = GDs.Tables[5].Rows[0]["Firstname"].ToString();
            registraionvo.ipassRegistrationId = Convert.ToInt64(GDs.Tables[5].Rows[0]["INTUSERID"].ToString());
            registraionvo.ipassRegistrationIdSpecified = true;
            registraionvo.mobile = GDs.Tables[5].Rows[0]["MobileNo"].ToString();
            registraionvo.password = "";
            registraionvo.surname = GDs.Tables[5].Rows[0]["Lastname"].ToString();
        }
        if (GDs.Tables[6].Rows.Count > 0)
        {

            //paymentDetailsvo.area = "61169.00";
            paymentDetailsvo.bankReferenceNumber = GDs.Tables[6].Rows[0]["TransactionNO"].ToString();


            paymentDetailsvo.customerReferenceNumber = GDs.Tables[6].Rows[0]["UIDNO"].ToString();
            paymentDetailsvo.dateAndTime = "";
            paymentDetailsvo.emd = "";
            paymentDetailsvo.gstNumber = GDs.Tables[2].Rows[0]["GSTNumber"].ToString();
            paymentDetailsvo.gstRegesterd = "";
            paymentDetailsvo.industrialPark = "";
            paymentDetailsvo.landCost = Convert.ToDouble(GDs.Tables[6].Rows[0]["Online_Amount"].ToString());
            paymentDetailsvo.landCostSpecified = true;
            paymentDetailsvo.paidAmount = Convert.ToDouble(GDs.Tables[6].Rows[0]["Online_Amount"].ToString());
            paymentDetailsvo.paidAmountSpecified = true;
            paymentDetailsvo.paymentMode = "Online";
            //paymentDetailsvo.processFee = "";
            paymentDetailsvo.referenceId = GDs.Tables[6].Rows[0]["OnlineOrderNo"].ToString();
            paymentDetailsvo.remarks = "";
            //paymentDetailsvo.sgst = "";
            paymentDetailsvo.statusCode = "";
            paymentDetailsvo.transactionNumber = GDs.Tables[6].Rows[0]["TransactionNO"].ToString();
            paymentDetailsvo.dateAndTime = GDs.Tables[6].Rows[0]["Transactiondatetime"].ToString();
        }

        if (GDs.Tables[10].Rows.Count > 0)
        {
            paymentDetailsvo.area = GDs.Tables[10].Rows[0]["PlotTotalArea"].ToString();
            paymentDetailsvo.cgst = GDs.Tables[10].Rows[0]["CGST"].ToString();
            paymentDetailsvo.sgst = GDs.Tables[10].Rows[0]["SGST"].ToString();
            paymentDetailsvo.processFee = GDs.Tables[10].Rows[0]["ProcessFee"].ToString();
            paymentDetailsvo.emd = GDs.Tables[10].Rows[0]["TotalEmd"].ToString();

        }

        if (GDs.Tables[2].Rows.Count > 0)
        {

            paymentDetailsvo.account_branch = GDs.Tables[2].Rows[0]["BranchName"].ToString();
            paymentDetailsvo.account_ifsc = GDs.Tables[2].Rows[0]["Ifsccode"].ToString();
            paymentDetailsvo.account_name = GDs.Tables[2].Rows[0]["AccountHolderName"].ToString();
            paymentDetailsvo.account_no = GDs.Tables[2].Rows[0]["AccountNo"].ToString();
            paymentDetailsvo.account_type = GDs.Tables[2].Rows[0]["TypeofAccount"].ToString();
            paymentDetailsvo.bank_name = GDs.Tables[2].Rows[0]["BankName"].ToString();
        }
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = //SecurityProtocolType.Tls12;
        SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
        string useroutput = landservice.registerUser(registraionvo);
        string output = landservice.saveApplicationDetails(plotvo, createdby, applicationid, verifyFirmvo, promoterDetailsvo, additionalPromotervo, projectGeneralvo, projectFinancialvo,
              projectEmploymentvo, projectMaterialManufacturingvo, projectPlantMachineryvo, landvo, electricityvo, watervo, effluentsvo, paymentDetailsvo, documentCheckListvo);
        if (output == "Applications details are saved successfully....")
        {
            gen.UpdateDepartwebserviceflagtsiic(Convert.ToString(applicationid), "406", "C", "Y", output);

        }
        else
        {
            gen.UpdateDepartwebserviceflagtsiic(Convert.ToString(applicationid), "406", "C", "N", output);
        }


    }

    public void bindata(int createdby, int applicationid)
    {
        string valueshmwssb = GDs.GetXml();

        if (GDs.Tables[0].Rows.Count > 0)
        {

            plotvo.district = GDs.Tables[0].Rows[0]["DistrictIdCGG"].ToString(); // GDs.Tables[0].Rows[0]["DistrictName"].ToString();
            plotvo.emd = 0;
            plotvo.industrialPark = GDs.Tables[0].Rows[0]["IndustrialParkIdCGG"].ToString();

        }

        if (GDs.Tables[1].Rows.Count > 0)
        {
            string str = "";
            string area = "";
            string Plotdatanew = "";
            for (int i = 0; i < GDs.Tables[1].Rows.Count; i++)
            {
                str += GDs.Tables[1].Rows[i]["PlotnoID"].ToString() + ",";
                Plotdatanew += GDs.Tables[1].Rows[i]["PLOTDATA"].ToString() + "$";
            }

            plotvo.plotNo = str.Substring(0, str.Length - 1);
            plotvo.plotData = Plotdatanew.Substring(0, Plotdatanew.Length - 1);// GDs.Tables[1].Rows[0]["PLOTDATA"].ToString();
            //plotvo.plotNo = GDs.Tables[1].Rows[0]["PlotID"].ToString();
            plotvo.price = GDs.Tables[1].Rows[0]["Persqmtsprice"].ToString();// Convert.ToDouble(GDs.Tables[1].Rows[0]["Price"]);

            //for (int i = 0; i < GDs.Tables[1].Rows.Count; i++)
            //{
            //    str += GDs.Tables[1].Rows[i]["PlotnoID"].ToString() + ",";
            //}

            //plotvo.plotNo = str.Substring(0, str.Length - 1);
            //plotvo.plotData = GDs.Tables[1].Rows[0]["PLOTDATA"].ToString();
            ////plotvo.plotNo = GDs.Tables[1].Rows[0]["PlotnoID"].ToString();
            //plotvo.price = GDs.Tables[1].Rows[0]["Persqmtsprice"].ToString();// Convert.ToDouble(GDs.Tables[1].Rows[0]["Price"]);
            plotvo.totalArea = Convert.ToDouble(GDs.Tables[1].Rows[0]["PlotTotalArea"]);
            plotvo.amount = Convert.ToDouble(GDs.Tables[1].Rows[0]["Price"]);
            plotvo.area = Convert.ToDouble(GDs.Tables[1].Rows[0]["Area_in_Sq_Mtrs"]);
            plotvo.amountSpecified = true;
            plotvo.areaSpecified = true;
            plotvo.emdSpecified = true;
            plotvo.gstSpecified = true;
            //plotvo.priceSpecified = true;
            plotvo.processFeeSpecified = true;
            plotvo.totalAreaSpecified = true;
            plotvo.totalEmdSpecified = true;
            plotvo.totalPriceSpecified = true;

        }

        if (GDs.Tables[2].Rows.Count > 0)
        {
            verifyFirmvo.alloteeName = GDs.Tables[2].Rows[0]["NameOftheFirm_Applicant"].ToString();

            paymentDetailsvo.clientName = GDs.Tables[2].Rows[0]["NameOftheFirm_Applicant"].ToString();

            verifyFirmvo.applicantName = GDs.Tables[2].Rows[0]["NameOftheFirm_Applicant"].ToString();
            verifyFirmvo.catDesc = GDs.Tables[2].Rows[0]["GovtDeptName_RegOffice"].ToString();
            TSIICLANDCGG.CodeDesc categorycodeDescvo = new TSIICLANDCGG.CodeDesc();
            categorycodeDescvo.code = GDs.Tables[2].Rows[0]["Category_RegOffice"].ToString();
            categorycodeDescvo.desc = GDs.Tables[2].Rows[0]["Category_RegOffice"].ToString();
            verifyFirmvo.categoryOfAllotment = categorycodeDescvo;
            addressvo.city = "";// GDs.Tables[2].Rows[0][""].ToString();
            addressvo.country = "";// GDs.Tables[2].Rows[0][""].ToString();
            addressvo.district = GDs.Tables[2].Rows[0]["Distid_regoffice"].ToString();
            addressvo.doorNo = GDs.Tables[2].Rows[0]["Door_No_RegOffice"].ToString();
            addressvo.mandal = GDs.Tables[2].Rows[0]["mandal_regoffice"].ToString();
            addressvo.pincode = GDs.Tables[2].Rows[0]["Pincode_RegOffice"].ToString();

            TSIICLANDCGG.CodeDesc statestnames = new TSIICLANDCGG.CodeDesc();
            statestnames.code = GDs.Tables[2].Rows[0]["stateNames"].ToString();
            statestnames.desc = GDs.Tables[2].Rows[0]["stateNames"].ToString();
            addressvo.state = statestnames;


            addressvo.streetNo1 = GDs.Tables[2].Rows[0]["Street_1_RegOffice"].ToString();
            addressvo.streetNo2 = GDs.Tables[2].Rows[0]["Street_2_RegOffice"].ToString();
            addressvo.village = GDs.Tables[2].Rows[0]["village_regoffice"].ToString();

            communicationAddressvo.address = addressvo;


            TSIICLANDCGG.Landline comphone = new TSIICLANDCGG.Landline();
            comphone.areaCode = GDs.Tables[2].Rows[0]["TelephonoNo1_RegOffice"].ToString();
            comphone.formattedPhone = "";///GDs.Tables[2].Rows[0]["FaxNo2_RegOffice"].ToString();
            comphone.number = GDs.Tables[2].Rows[0]["TelephonoNo2_RegOffice"].ToString();// GDs.Tables[2].Rows[0]["FaxNo1_RegOffice"].ToString();
            comphone.phone = "";
            comphone.valid = true;
            comphone.validSpecified = true;
            communicationAddressvo.phoneNum = comphone;



            TSIICLANDCGG.Landline faxno = new TSIICLANDCGG.Landline();
            faxno.areaCode = GDs.Tables[2].Rows[0]["FaxNo1_RegOffice"].ToString();
            faxno.formattedPhone = "";///GDs.Tables[2].Rows[0]["FaxNo2_RegOffice"].ToString();
            faxno.number = GDs.Tables[2].Rows[0]["FaxNo2_RegOffice"].ToString();// GDs.Tables[2].Rows[0]["FaxNo1_RegOffice"].ToString();
            faxno.phone = "";
            faxno.valid = true;
            faxno.validSpecified = true;
            communicationAddressvo.faxNum = faxno;

            verifyFirmvo.commFaxCode = GDs.Tables[2].Rows[0]["FaxNo1_RegOffice"].ToString();
            verifyFirmvo.commFaxNumber = GDs.Tables[2].Rows[0]["FaxNo2_RegOffice"].ToString();
            verifyFirmvo.commPhoneCode = GDs.Tables[2].Rows[0]["TelephonoNo1_RegOffice"].ToString();
            verifyFirmvo.commPhoneNumber = GDs.Tables[2].Rows[0]["TelephonoNo2_RegOffice"].ToString();

            firmDetailsvo.communicationAddress = communicationAddressvo;
            firmRegistrationDetailsvo.regstrAuthority = GDs.Tables[2].Rows[0]["RegisteringAuthority_Firmregistration"].ToString();
            firmRegistrationDetailsvo.regstrNumber = GDs.Tables[2].Rows[0]["RegistrationNo_Firmregistration"].ToString();
            firmRegistrationDetailsvo.yrOfCommence = Convert.ToInt64(GDs.Tables[2].Rows[0]["YearofCommencement_Firmregistration"].ToString());
            firmRegistrationDetailsvo.yrOfCommenceSpecified = true;
            firmRegistrationDetailsvo.yrOfEstbl = Convert.ToInt64(GDs.Tables[2].Rows[0]["YearofEstablishment_Firmregistration"].ToString());
            firmRegistrationDetailsvo.yrOfEstblSpecified = true;

            firmDetailsvo.firmRegistrationDetails = firmRegistrationDetailsvo;
            firmDetailsvo.userId = Convert.ToInt64(GDs.Tables[2].Rows[0]["Modified_by"].ToString());
            firmDetailsvo.userIdSpecified = true;
            verifyFirmvo.firmDetails = firmDetailsvo;
            verifyFirmvo.houseNo = GDs.Tables[2].Rows[0]["House_Prv_flot"].ToString();

            TSIICLANDCGG.CodeDesc orgtype = new TSIICLANDCGG.CodeDesc();
            orgtype.code = GDs.Tables[2].Rows[0]["TypeofOrganization_RegOfficesss"].ToString();
            orgtype.desc = GDs.Tables[2].Rows[0]["TypeofOrganization_RegOfficesss"].ToString();
            verifyFirmvo.orgType = orgtype;
            Commaddressvo.city = "";// GDs.Tables[2].Rows[0][""].ToString();
            Commaddressvo.country = "";// GDs.Tables[2].Rows[0][""].ToString();
            Commaddressvo.district = GDs.Tables[2].Rows[0]["Distid_CommAddrs"].ToString();
            Commaddressvo.doorNo = GDs.Tables[2].Rows[0]["Door_No_CommAddr"].ToString();
            Commaddressvo.mandal = GDs.Tables[2].Rows[0]["mandal_commaddrs"].ToString();
            Commaddressvo.pincode = GDs.Tables[2].Rows[0]["Pincode_CommAddr"].ToString();
            //CommcodeDescvo.code = GDs.Tables[2].Rows[0]["statecommaddrs"].ToString();
            // CommcodeDescvo.desc = GDs.Tables[2].Rows[0]["statecommaddrs"].ToString();
            Commaddressvo.state = codeDescvo;


            Commaddressvo.streetNo1 = GDs.Tables[2].Rows[0]["Street_1_CommAddr"].ToString();
            Commaddressvo.streetNo2 = GDs.Tables[2].Rows[0]["Street_2_CommAddr"].ToString();
            Commaddressvo.village = GDs.Tables[2].Rows[0]["Village_CommAddrs"].ToString();
            CommcommunicationAddressvo.address = Commaddressvo;


            TSIICLANDCGG.Landline comtelephone = new TSIICLANDCGG.Landline();

            TSIICLANDCGG.Landline comfaxno = new TSIICLANDCGG.Landline();
            //comtelephone.areaCode = GDs.Tables[2].Rows[0]["TelephonoNo1_CommAddr"].ToString();// GDs.Tables[2].Rows[0][""].ToString();
            landlinevo.formattedPhone = "";
            //comtelephone.number = GDs.Tables[2].Rows[0]["TelephonoNo2_CommAddr"].ToString(); //GDs.Tables[2].Rows[0]["FaxNo1_CommAddr"].ToString();
            landlinevo.phone = "";
            landlinevo.valid = true;
            landlinevo.validSpecified = true;
            communicationAddressvo.phoneNum = comtelephone;
            comfaxno.areaCode = GDs.Tables[2].Rows[0]["FaxNo1_CommAddr"].ToString();// GDs.Tables[2].Rows[0][""].ToString();
            landlinevo.formattedPhone = "";
            comfaxno.number = GDs.Tables[2].Rows[0]["FaxNo2_CommAddr"].ToString(); //GDs.Tables[2].Rows[0]["FaxNo1_CommAddr"].ToString();
            landlinevo.phone = "";
            landlinevo.valid = true;
            landlinevo.validSpecified = true;

            verifyFirmvo.otherCommFaxCode = GDs.Tables[2].Rows[0]["FaxNo1_CommAddr"].ToString();
            verifyFirmvo.otherCommFaxNumber = GDs.Tables[2].Rows[0]["FaxNo2_CommAddr"].ToString();
            verifyFirmvo.otherCommPhoneCode = GDs.Tables[2].Rows[0]["TelephonoNo1_CommAddr"].ToString();
            verifyFirmvo.otherCommPhoneNumber = GDs.Tables[2].Rows[0]["TelephonoNo2_CommAddr"].ToString();



            verifyFirmvo.otherCommunicationAddress = CommcommunicationAddressvo;
            verifyFirmvo.others = GDs.Tables[2].Rows[0]["OtherDetails_Prv_flot"].ToString();
            verifyFirmvo.plotNo = GDs.Tables[2].Rows[0]["PlotNo_Prv_flot"].ToString();
            verifyFirmvo.shedName = GDs.Tables[2].Rows[0]["ShedName_Prv_flot"].ToString();
            verifyFirmvo.shopNo = GDs.Tables[2].Rows[0]["Shop_Prv_flot"].ToString();

            ///promoter details///

            Contactaddressvo.city = "";// GDs.Tables[2].Rows[0][""].ToString();
            Contactaddressvo.country = "";// GDs.Tables[2].Rows[0][""].ToString();
            Contactaddressvo.district = GDs.Tables[2].Rows[0]["Distidcontactinfo"].ToString();
            Contactaddressvo.doorNo = GDs.Tables[2].Rows[0]["Door_No_Cont_info"].ToString();
            Contactaddressvo.mandal = GDs.Tables[2].Rows[0]["mandalcontinfo"].ToString();
            Contactaddressvo.pincode = GDs.Tables[2].Rows[0]["Pincode_Cont_info"].ToString();
            codeDescvo.code = GDs.Tables[2].Rows[0]["statecontinfos"].ToString();
            codeDescvo.desc = GDs.Tables[2].Rows[0]["statecontinfos"].ToString(); // GDs.Tables[2].Rows[0][""].ToString();
            Contactaddressvo.state = codeDescvo;
            Contactaddressvo.streetNo1 = GDs.Tables[2].Rows[0]["Street_1_Cont_info"].ToString();
            Contactaddressvo.streetNo2 = GDs.Tables[2].Rows[0]["Street_2_Cont_info"].ToString();
            Contactaddressvo.village = GDs.Tables[2].Rows[0]["villagecontinfo"].ToString();
            ContactcommunicationAddressvo.address = Contactaddressvo;

            TSIICLANDCGG.Landline contfax = new TSIICLANDCGG.Landline();
            contfax.areaCode = GDs.Tables[2].Rows[0]["FaxNo1_Cont_info"].ToString();
            landlinevo.formattedPhone = "";
            contfax.number = GDs.Tables[2].Rows[0]["MobileNo_Cont_info"].ToString();
            //landlinevo.phone =GDs.Tables[2].Rows[0]["TelephonoNo1_Cont_info"].ToString();
            landlinevo.valid = true;
            landlinevo.validSpecified = true;
            communicationAddressvo.faxNum = landlinevo;
            landlinevo.areaCode = GDs.Tables[2].Rows[0]["FaxNo2_Cont_info"].ToString();
            landlinevo.formattedPhone = "";
            //landlinevo.number = GDs.Tables[2].Rows[0]["TelephonoNo2_Cont_info"].ToString();
            landlinevo.phone = GDs.Tables[2].Rows[0]["TelephonoNo1_Cont_info"].ToString();
            landlinevo.valid = true;
            landlinevo.validSpecified = true;
            communicationAddressvo.phoneNum = landlinevo;

            promoterDetailsvo.commFaxCode = GDs.Tables[2].Rows[0]["FaxNo1_Cont_info"].ToString();
            promoterDetailsvo.commFaxNumber = GDs.Tables[2].Rows[0]["FaxNo2_Cont_info"].ToString();
            promoterDetailsvo.commPhoneCode = GDs.Tables[2].Rows[0]["TelephonoNo1_Cont_info"].ToString();
            promoterDetailsvo.commPhoneNumber = GDs.Tables[2].Rows[0]["TelephonoNo2_Cont_info"].ToString();
            promoterDetailsvo.cellNumber = GDs.Tables[2].Rows[0]["MobileNo_Cont_info"].ToString();

            promoterDetailsvo.communicationAddress = ContactcommunicationAddressvo;
            promoterDetailsvo.emailId = GDs.Tables[2].Rows[0]["Email_Cont_info"].ToString();
            mobilevo.areaCode = "";// GDs.Tables[2].Rows[0][""].ToString();
            mobilevo.formattedPhone = "";
            mobilevo.number = GDs.Tables[2].Rows[0]["MobileNo_Cont_info"].ToString();
            mobilevo.phone = GDs.Tables[2].Rows[0]["MobileNo_Cont_info"].ToString();
            mobilevo.valid = true;
            mobilevo.validSpecified = true;
            promoterDetailsvo.mobile = mobilevo;
            personvo.firstName = GDs.Tables[2].Rows[0]["FirstName_Cont_info"].ToString();
            personvo.surname = GDs.Tables[2].Rows[0]["Surname_Cont_info"].ToString();
            promoterDetailsvo.personName = personvo;
            promoterFinancialInformationvo.detlsImvableAssests = GDs.Tables[2].Rows[0]["Immovable_Assets_Land_Building_Financial"].ToString();
            promoterFinancialInformationvo.funcResponsibilities = GDs.Tables[2].Rows[0]["ProposedProject_Financial"].ToString();
            promoterFinancialInformationvo.otherAssests = Convert.ToDouble(GDs.Tables[2].Rows[0]["OtherAssets_Financial_Inlakhs"].ToString());
            promoterFinancialInformationvo.otherAssestsSpecified = true;
            promoterFinancialInformationvo.otherInfo = GDs.Tables[2].Rows[0]["Anyother_Financial_Info"].ToString();
            promoterFinancialInformationvo.panNo = GDs.Tables[2].Rows[0]["PanNumber_Financial_Info"].ToString();
            promoterFinancialInformationvo.personalAsset = Convert.ToDouble(GDs.Tables[2].Rows[0]["Assets_Financial_Inlakhs"].ToString());
            promoterFinancialInformationvo.personalAssetSpecified = true;
            promoterFinancialInformationvo.personalLiability = Convert.ToDouble(GDs.Tables[2].Rows[0]["Liabilities_Financial_Inlakhs"].ToString());
            promoterFinancialInformationvo.personalLiabilitySpecified = true;
            promoterDetailsvo.promoterFinancialInformation = promoterFinancialInformationvo;
            promoterDetailsvo.promoterId = 0;// GDs.Tables[2].Rows[0][""].ToString();
            promoterDetailsvo.promoterIdSpecified = true;
            promoterDetailsvo.userId = Convert.ToInt64(GDs.Tables[2].Rows[0]["Modified_by"].ToString());
            promoterDetailsvo.userIdSpecified = true;

            TSIICLANDCGG.Product[] product = null;
            projectGeneralvo.byProductList = product;
            if (GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infos"].ToString() != "" && GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infos"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infos"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');
                // paymentresponseVOsobj.TxnDate_13 = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();// +" " + date[1].ToString();
                TSIICLANDCGG.DateHolder datevocomme = new TSIICLANDCGG.DateHolder();
                datevocomme.day = newdate[0].ToString();
                datevocomme.displayDate = "";
                datevocomme.empty = true;
                datevocomme.emptySpecified = true;
                datevocomme.month = newdate[1].ToString();
                datevocomme.sqlDateStr = "";
                datevocomme.valid = true;
                datevocomme.validSpecified = true;
                datevocomme.year = newdate[2].ToString();

                projectGeneralvo.commOperationPhase1 = datevocomme;
            }

            if (GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infophase2"].ToString() != "" && GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infophase2"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infophase2"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');
                // paymentresponseVOsobj.TxnDate_13 = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();// +" " + date[1].ToString();
                TSIICLANDCGG.DateHolder datevocommercial = new TSIICLANDCGG.DateHolder();

                datevocommercial.day = newdate[0].ToString();
                datevocommercial.displayDate = "";
                datevocommercial.empty = true;
                datevocommercial.emptySpecified = true;
                datevocommercial.month = newdate[1].ToString();
                datevocommercial.sqlDateStr = "";
                datevocommercial.valid = true;
                datevocommercial.validSpecified = true;
                datevocommercial.year = newdate[2].ToString();
                projectGeneralvo.commOperationPhase2 = datevocommercial;
            }
            if (GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infophase3"].ToString() != "" && GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infophase3"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infophase3"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');
                TSIICLANDCGG.DateHolder datevocommercialphase2 = new TSIICLANDCGG.DateHolder();
                // paymentresponseVOsobj.TxnDate_13 = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();// +" " + date[1].ToString();

                datevocommercialphase2.day = newdate[0].ToString();
                datevocommercialphase2.displayDate = "";
                datevocommercialphase2.empty = true;
                datevocommercialphase2.emptySpecified = true;
                datevocommercialphase2.month = newdate[1].ToString();
                datevocommercialphase2.sqlDateStr = "";
                datevocommercialphase2.valid = true;
                datevocommercialphase2.validSpecified = true;
                datevocommercialphase2.year = newdate[2].ToString();
                projectGeneralvo.commOperationPhase3 = datevocommercialphase2;
            }
            if (GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infos"].ToString() != "" && GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infos"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infos"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');

                TSIICLANDCGG.DateHolder datevoconstruction = new TSIICLANDCGG.DateHolder();

                datevoconstruction.day = newdate[0].ToString();
                datevoconstruction.displayDate = "";
                datevoconstruction.empty = true;
                datevoconstruction.emptySpecified = true;
                datevoconstruction.month = newdate[1].ToString();
                datevoconstruction.sqlDateStr = "";
                datevoconstruction.valid = true;
                datevoconstruction.validSpecified = true;
                datevoconstruction.year = newdate[2].ToString();

                projectGeneralvo.constructionPhase1 = datevoconstruction;
            }
            if (GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infophase2"].ToString() != "" && GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infophase2"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infophase2"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');

                TSIICLANDCGG.DateHolder datevoconstructionphase2 = new TSIICLANDCGG.DateHolder();
                datevoconstructionphase2.day = newdate[0].ToString();
                datevoconstructionphase2.displayDate = "";
                datevoconstructionphase2.empty = true;
                datevoconstructionphase2.emptySpecified = true;
                datevoconstructionphase2.month = newdate[1].ToString();
                datevoconstructionphase2.sqlDateStr = "";
                datevoconstructionphase2.valid = true;
                datevoconstructionphase2.validSpecified = true;
                datevoconstructionphase2.year = newdate[2].ToString();
                projectGeneralvo.constructionPhase2 = datevoconstructionphase2;
            }

            if (GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infophase3"].ToString() != "" && GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infophase3"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infophase3"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');


                TSIICLANDCGG.DateHolder datevoconstructionphase3 = new TSIICLANDCGG.DateHolder();
                datevoconstructionphase3.day = newdate[0].ToString();
                datevoconstructionphase3.displayDate = "";
                datevoconstructionphase3.empty = true;
                datevoconstructionphase3.emptySpecified = true;
                datevoconstructionphase3.month = newdate[1].ToString();
                datevoconstructionphase3.sqlDateStr = "";
                datevoconstructionphase3.valid = true;
                datevoconstructionphase3.validSpecified = true;
                datevoconstructionphase3.year = newdate[2].ToString();
                projectGeneralvo.constructionPhase3 = datevoconstructionphase3;
            }
            projectGeneralvo.projCategory = GDs.Tables[2].Rows[0]["typeofprojectscategory"].ToString();
            projectGeneralvo.projCatgryOther = GDs.Tables[2].Rows[0]["projectother"].ToString();
            projectGeneralvo.projCatgryOtherValue = GDs.Tables[2].Rows[0]["ProjectCategory3_General_Info"].ToString();
            projectGeneralvo.projDesc = GDs.Tables[2].Rows[0]["ProjectName_Description_General_Info"].ToString();
            projectGeneralvo.projectId = 0;
            projectGeneralvo.projectIdSpecified = true;
            projectGeneralvo.projStatus = GDs.Tables[2].Rows[0]["typeofprojectstatus"].ToString();
            TSIICLANDCGG.Product[] productprosposed = null;
            if (GDs.Tables[7].Rows.Count > 0)
            {
                DataTable dtraw = new DataTable();
                dtraw = GDs.Tables[7];
                productprosposed = new TSIICLANDCGG.Product[dtraw.Rows.Count];

                for (int k = 0; k < dtraw.Rows.Count; k++)
                {
                    TSIICLANDCGG.Product Productvo = new TSIICLANDCGG.Product();
                    Productvo.code = dtraw.Rows[k]["Itemcode"].ToString();
                    Productvo.expectedOutput = 0.00; //dtraw.Rows[k][""].ToString();
                    Productvo.expectedOutputSpecified = true;

                    if (dtraw.Rows[k]["Installedcapacity"].ToString() == "")
                    {


                        Productvo.installedCapacity = 0;

                    }
                    else
                    {
                        Productvo.installedCapacity = Convert.ToDouble(dtraw.Rows[k]["Installedcapacity"]);
                    }

                    Productvo.installedCapacitySpecified = true;
                    Productvo.measurement = dtraw.Rows[k]["Unitmeasurement"].ToString();
                    Productvo.name = dtraw.Rows[k]["Product"].ToString();
                    Productvo.productId = 0;
                    Productvo.productIdSpecified = false;
                    productprosposed[k] = Productvo;
                    //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                    //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                }
                projectGeneralvo.propProductList = productprosposed;
            }
            projectGeneralvo.propProductList = productprosposed;

            if (GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infos"].ToString() != "" && GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infos"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infos"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');


                TSIICLANDCGG.DateHolder datevotrialperation = new TSIICLANDCGG.DateHolder();
                datevotrialperation.day = newdate[0].ToString();
                datevotrialperation.displayDate = "";
                datevotrialperation.empty = true;
                datevotrialperation.emptySpecified = true;
                datevotrialperation.month = newdate[1].ToString();
                datevotrialperation.sqlDateStr = "";
                datevotrialperation.valid = true;
                datevotrialperation.validSpecified = true;
                datevotrialperation.year = newdate[2].ToString();
                projectGeneralvo.trailOperationPhase1 = datevotrialperation;
            }
            if (GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infophase2"].ToString() != "" && GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infophase2"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infophase2"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');

                TSIICLANDCGG.DateHolder datevotrialperationphase2 = new TSIICLANDCGG.DateHolder();
                datevotrialperationphase2.day = newdate[0].ToString();
                datevotrialperationphase2.displayDate = "";
                datevotrialperationphase2.empty = true;
                datevotrialperationphase2.emptySpecified = true;
                datevotrialperationphase2.month = newdate[1].ToString();
                datevotrialperationphase2.sqlDateStr = "";
                datevotrialperationphase2.valid = true;
                datevotrialperationphase2.validSpecified = true;
                datevotrialperationphase2.year = newdate[2].ToString();
                projectGeneralvo.trailOperationPhase2 = datevotrialperationphase2;
            }

            if (GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infophase3"].ToString() != "" && GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infophase3"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infophase3"].ToString().Split(' ');


                TSIICLANDCGG.DateHolder datevotrialperationphase3 = new TSIICLANDCGG.DateHolder();
                string[] newdate = date[0].ToString().Split('-');
                datevotrialperationphase3.day = newdate[0].ToString();
                datevotrialperationphase3.displayDate = "";
                datevotrialperationphase3.empty = true;
                datevotrialperationphase3.emptySpecified = true;
                datevotrialperationphase3.month = newdate[1].ToString();
                datevotrialperationphase3.sqlDateStr = "";
                datevotrialperationphase3.valid = true;
                datevotrialperationphase3.validSpecified = true;
                datevotrialperationphase3.year = newdate[2].ToString();
                projectGeneralvo.trailOperationPhase3 = datevotrialperationphase3;
            }
            projectGeneralvo.ventureType1 = GDs.Tables[2].Rows[0]["Typeofventure"].ToString();
            projectGeneralvo.ventureType2 = "";
            if (GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhs"].ToString() != "")
            {
                projectFinancialvo.auxillaryEquipPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhs"].ToString());
            }
            projectFinancialvo.auxillaryEquipPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhsphase2"].ToString() != "")
            {
                projectFinancialvo.auxillaryEquipPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhsphase2"].ToString());
            }
            projectFinancialvo.auxillaryEquipPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhsphase3"].ToString() != "")
            {
                projectFinancialvo.auxillaryEquipPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhsphase3"].ToString());
            }
            projectFinancialvo.auxillaryEquipPhase3Specified = true;
            projectFinancialvo.auxillaryId = 0;
            projectFinancialvo.auxillaryIdSpecified = true;
            projectFinancialvo.buildingId = 0;
            projectFinancialvo.buildingIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhs"].ToString() != "")
            {
                projectFinancialvo.buildingsPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhs"].ToString());
            }
            projectFinancialvo.buildingsPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhsphase2"].ToString() != "")
            {
                projectFinancialvo.buildingsPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhsphase2"].ToString());
            }
            projectFinancialvo.buildingsPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhsphase3"].ToString() != "")
            {
                projectFinancialvo.buildingsPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhsphase3"].ToString());
            }
            projectFinancialvo.buildingsPhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhs"].ToString() != "")
            {
                projectFinancialvo.contingenciesPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhs"].ToString());
            }
            projectFinancialvo.contingenciesPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhsphase2"].ToString() != "")
            {
                projectFinancialvo.contingenciesPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhsphase2"].ToString());
            }
            projectFinancialvo.contingenciesPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhsphase3"].ToString() != "")
            {
                projectFinancialvo.contingenciesPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhsphase3"].ToString());
            }
            projectFinancialvo.contingenciesPhase3Specified = true;
            projectFinancialvo.contingeniousId = 0;
            projectFinancialvo.contingeniousIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Amount"].ToString() != null && GDs.Tables[2].Rows[0]["Amount"].ToString() != "")
            {
                projectFinancialvo.debtAmount = Convert.ToDouble(GDs.Tables[2].Rows[0]["Amount"].ToString());
            }
            projectFinancialvo.debtAmountSpecified = true;
            projectFinancialvo.debtName = GDs.Tables[2].Rows[0]["EquityName"].ToString();
            if (GDs.Tables[2].Rows[0]["EOUdate"].ToString() != "" && GDs.Tables[2].Rows[0]["EOUdate"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["EOUdate"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');

                TSIICLANDCGG.DateHolder equdate = new TSIICLANDCGG.DateHolder();
                equdate.day = newdate[0].ToString();
                equdate.displayDate = "";
                equdate.empty = true;
                equdate.emptySpecified = true;
                equdate.month = newdate[1].ToString();
                equdate.sqlDateStr = "";
                equdate.valid = true;
                equdate.validSpecified = true;
                equdate.year = newdate[2].ToString();
                projectFinancialvo.eouDate = equdate;
            }
            projectFinancialvo.eouNo = GDs.Tables[2].Rows[0]["EOUNo"].ToString();
            if (GDs.Tables[2].Rows[0]["Domestic"].ToString() != null && GDs.Tables[2].Rows[0]["Domestic"].ToString() != "")
            {
                projectFinancialvo.equityDomestic = Convert.ToDouble(GDs.Tables[2].Rows[0]["Domestic"].ToString());
            }
            projectFinancialvo.equityDomesticSpecified = true;
            if (GDs.Tables[2].Rows[0]["Foreigns"].ToString() != null && GDs.Tables[2].Rows[0]["Foreigns"].ToString() != "")
            {
                projectFinancialvo.equityForiegn = Convert.ToDouble(GDs.Tables[2].Rows[0]["Foreigns"].ToString());
            }
            projectFinancialvo.equityForiegnSpecified = true;

            if (GDs.Tables[2].Rows[0]["Foreigninvestmentdate"].ToString() != "" && GDs.Tables[2].Rows[0]["Foreigninvestmentdate"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Foreigninvestmentdate"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');

                TSIICLANDCGG.DateHolder foreigndate = new TSIICLANDCGG.DateHolder();
                foreigndate.day = newdate[0].ToString();
                foreigndate.displayDate = "";
                foreigndate.empty = true;
                foreigndate.emptySpecified = true;
                foreigndate.month = newdate[1].ToString();
                foreigndate.sqlDateStr = "";
                foreigndate.valid = true;
                foreigndate.validSpecified = true;
                foreigndate.year = newdate[2].ToString();
                projectFinancialvo.fipbRbiApprDate = foreigndate;
            }

            projectFinancialvo.fipbRbiApprNo = GDs.Tables[2].Rows[0]["Foreigninvestment"].ToString();
            if (GDs.Tables[2].Rows[0]["IEMdate"].ToString() != "" && GDs.Tables[2].Rows[0]["IEMdate"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["IEMdate"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');

                TSIICLANDCGG.DateHolder Iemdate = new TSIICLANDCGG.DateHolder();
                Iemdate.day = newdate[0].ToString();
                Iemdate.displayDate = "";
                Iemdate.empty = true;
                Iemdate.emptySpecified = true;
                Iemdate.month = newdate[1].ToString();
                Iemdate.sqlDateStr = "";
                Iemdate.valid = true;
                Iemdate.validSpecified = true;
                Iemdate.year = newdate[2].ToString();
                projectFinancialvo.iemDate = Iemdate;
            }
            projectFinancialvo.iemNo = GDs.Tables[2].Rows[0]["IEM"].ToString();
            if (GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhs"].ToString() != "")
            {
                projectFinancialvo.indigeneousPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhs"].ToString());
            }
            projectFinancialvo.indigeneousPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhsphase2"].ToString() != "")
            {
                projectFinancialvo.indigeneousPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhsphase2"].ToString());
            }
            projectFinancialvo.indigeneousPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhsphase3"].ToString() != "")
            {
                projectFinancialvo.indigeneousPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhsphase3"].ToString());
            }
            projectFinancialvo.indigeneousPhase3Specified = true;
            projectFinancialvo.indigeniousId = 0;
            projectFinancialvo.indigeniousIdSpecified = true;
            projectFinancialvo.landId = 0;
            projectFinancialvo.landIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhs"].ToString() != "")
            {
                projectFinancialvo.landPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhs"].ToString());
            }
            projectFinancialvo.landPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhsphase2"].ToString() != "")
            {
                projectFinancialvo.landPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhsphase2"].ToString());
            }
            projectFinancialvo.landPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhsphase3"].ToString() != "")
            {
                projectFinancialvo.landPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhsphase3"].ToString());
            }
            projectFinancialvo.landPhase3Specified = true;

            if (GDs.Tables[2].Rows[0]["LOIdate"].ToString() != "" && GDs.Tables[2].Rows[0]["LOIdate"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["LOIdate"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');

                TSIICLANDCGG.DateHolder loidate = new TSIICLANDCGG.DateHolder();
                loidate.day = newdate[0].ToString();
                loidate.displayDate = "";
                loidate.empty = true;
                loidate.emptySpecified = true;
                loidate.month = newdate[1].ToString();
                loidate.sqlDateStr = "";
                loidate.valid = true;
                loidate.validSpecified = true;
                loidate.year = newdate[2].ToString();
                projectFinancialvo.loiDate = loidate;
            }
            projectFinancialvo.loiNo = GDs.Tables[2].Rows[0]["LOI"].ToString();
            projectFinancialvo.machineryImportedId = 0;
            projectFinancialvo.machineryImportedIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhs"].ToString() != "")
            {
                projectFinancialvo.machineryImportedPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhs"].ToString());
            }
            projectFinancialvo.machineryImportedPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhsphase2"].ToString() != "")
            {
                projectFinancialvo.machineryImportedPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhsphase2"].ToString());
            }
            projectFinancialvo.machineryImportedPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhsphase3"].ToString() != "")
            {
                projectFinancialvo.machineryImportedPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhsphase3"].ToString());
            }
            projectFinancialvo.machineryImportedPhase3Specified = true;
            projectFinancialvo.miscFixedId = 0;
            projectFinancialvo.miscFixedIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhs"].ToString() != "")
            {
                projectFinancialvo.miscFxdAssestsPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhs"].ToString());
            }
            projectFinancialvo.miscFxdAssestsPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhsphase2"].ToString() != "")
            {
                projectFinancialvo.miscFxdAssestsPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhsphase2"].ToString());
            }
            projectFinancialvo.miscFxdAssestsPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhsphase3"].ToString() != "")
            {
                projectFinancialvo.miscFxdAssestsPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhsphase3"].ToString());
            }
            projectFinancialvo.miscFxdAssestsPhase3Specified = true;
            projectFinancialvo.preliminaryId = 0;
            projectFinancialvo.preliminaryIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhs"].ToString() != "")
            {
                projectFinancialvo.preliminaryPreOperativePhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhs"].ToString());
            }
            projectFinancialvo.preliminaryPreOperativePhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhsphase2"].ToString() != "")
            {
                projectFinancialvo.preliminaryPreOperativePhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhsphase2"].ToString());
            }
            projectFinancialvo.preliminaryPreOperativePhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhsphase3"].ToString() != "")
            {
                projectFinancialvo.preliminaryPreOperativePhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhsphase3"].ToString());
            }
            projectFinancialvo.preliminaryPreOperativePhase3Specified = true;
            projectFinancialvo.projectId = 0;
            projectFinancialvo.projectIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["TotalEquitdebit"].ToString() != null && GDs.Tables[2].Rows[0]["TotalEquitdebit"].ToString() != "")
            {
                projectFinancialvo.totalEqtyDebt = Convert.ToDouble(GDs.Tables[2].Rows[0]["TotalEquitdebit"].ToString());
            }
            projectFinancialvo.totalEqtyDebtSpecified = true;
            if (GDs.Tables[2].Rows[0]["TotalEquity"].ToString() != null && GDs.Tables[2].Rows[0]["TotalEquity"].ToString() != "")
            {
                projectFinancialvo.totalEquity = Convert.ToDouble(GDs.Tables[2].Rows[0]["TotalEquity"].ToString());
            }
            projectFinancialvo.totalEquitySpecified = true;
            if (GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhs"].ToString() != "")
            {
                projectFinancialvo.totalPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhs"].ToString());
            }
            projectFinancialvo.totalPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhsphase2"].ToString() != "")
            {
                projectFinancialvo.totalPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhsphase2"].ToString());
            }
            projectFinancialvo.totalPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhsphase3"].ToString() != "")
            {
                projectFinancialvo.totalPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhsphase3"].ToString());
            }
            projectFinancialvo.totalPhase3Specified = true;
            projectFinancialvo.workCapitalId = 0;
            projectFinancialvo.workCapitalIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhs"].ToString() != null && GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhs"].ToString() != "")
            {
                projectFinancialvo.workCptlMarginPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhs"].ToString());
            }
            projectFinancialvo.workCptlMarginPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhsphase2"].ToString() != "")
            {
                projectFinancialvo.workCptlMarginPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhsphase2"].ToString());
            }
            projectFinancialvo.workCptlMarginPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhsphase3"].ToString() != "")
            {
                projectFinancialvo.workCptlMarginPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhsphase3"].ToString());
            }
            projectFinancialvo.workCptlMarginPhase3Specified = true;

            if (GDs.Tables[2].Rows[0]["femalephase1"].ToString() != null && GDs.Tables[2].Rows[0]["femalephase1"].ToString() != "")
            {
                projectEmploymentvo.femalePhase1 = Convert.ToInt64(GDs.Tables[2].Rows[0]["femalephase1"].ToString());
            }
            projectEmploymentvo.femalePhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["femalephase2"].ToString() != null && GDs.Tables[2].Rows[0]["femalephase2"].ToString() != "")
            {
                projectEmploymentvo.femalePhase2 = Convert.ToInt64(GDs.Tables[2].Rows[0]["femalephase2"].ToString());
            }
            projectEmploymentvo.femalePhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["femalephase3"].ToString() != null && GDs.Tables[2].Rows[0]["femalephase3"].ToString() != "")
            {
                projectEmploymentvo.femalePhase3 = Convert.ToInt64(GDs.Tables[2].Rows[0]["femalephase3"].ToString());
            }
            projectEmploymentvo.femalePhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["malephase1"].ToString() != null && GDs.Tables[2].Rows[0]["malephase1"].ToString() != "")
            {
                projectEmploymentvo.malePhase1 = Convert.ToInt64(GDs.Tables[2].Rows[0]["malephase1"].ToString());
            }
            projectEmploymentvo.malePhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["malephase2"].ToString() != null && GDs.Tables[2].Rows[0]["malephase2"].ToString() != "")
            {
                projectEmploymentvo.malePhase2 = Convert.ToInt64(GDs.Tables[2].Rows[0]["malephase2"].ToString());
            }
            projectEmploymentvo.malePhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["malephase3"].ToString() != null && GDs.Tables[2].Rows[0]["malephase3"].ToString() != "")
            {
                projectEmploymentvo.malePhase3 = Convert.ToInt64(GDs.Tables[2].Rows[0]["malephase3"].ToString());
            }
            projectEmploymentvo.malePhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["Managerial_Emp"].ToString() != null && GDs.Tables[2].Rows[0]["Managerial_Emp"].ToString() != "")
            {
                projectEmploymentvo.managerialPhase1 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Managerial_Emp"].ToString());
            }
            projectEmploymentvo.managerialPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Managerial_Empphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Managerial_Empphase2"].ToString() != "")
            {
                projectEmploymentvo.managerialPhase2 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Managerial_Empphase2"].ToString());
            }
            projectEmploymentvo.managerialPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Managerial_Empphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Managerial_Empphase3"].ToString() != "")
            {
                projectEmploymentvo.managerialPhase3 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Managerial_Empphase3"].ToString());
            }
            projectEmploymentvo.managerialPhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["Workers_factory_emp"].ToString() != null && GDs.Tables[2].Rows[0]["Workers_factory_emp"].ToString() != "")
            {
                projectEmploymentvo.maxNoWorkers = Convert.ToInt64(GDs.Tables[2].Rows[0]["Workers_factory_emp"].ToString());
            }
            projectEmploymentvo.maxNoWorkersSpecified = true;
            projectEmploymentvo.projectId = 0;
            projectEmploymentvo.projectIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Skilled_Emp"].ToString() != null && GDs.Tables[2].Rows[0]["Skilled_Emp"].ToString() != "")
            {
                projectEmploymentvo.skilledPhase1 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Skilled_Emp"].ToString());
            }
            projectEmploymentvo.skilledPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Skilled_Empphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Skilled_Empphase2"].ToString() != "")
            {
                projectEmploymentvo.skilledPhase2 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Skilled_Empphase2"].ToString());
            }
            projectEmploymentvo.skilledPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Skilled_Empphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Skilled_Empphase3"].ToString() != "")
            {
                projectEmploymentvo.skilledPhase3 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Skilled_Empphase3"].ToString());
            }
            projectEmploymentvo.skilledPhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["Supervisory_Emp"].ToString() != null && GDs.Tables[2].Rows[0]["Supervisory_Emp"].ToString() != "")
            {
                projectEmploymentvo.supervisoryPhase1 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Supervisory_Emp"].ToString());
            }
            projectEmploymentvo.supervisoryPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Supervisory_Empphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Supervisory_Empphase2"].ToString() != "")
            {
                projectEmploymentvo.supervisoryPhase2 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Supervisory_Empphase2"].ToString());
            }
            projectEmploymentvo.supervisoryPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Supervisory_Empphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Supervisory_Empphase3"].ToString() != "")
            {
                projectEmploymentvo.supervisoryPhase3 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Supervisory_Empphase3"].ToString());
            }
            projectEmploymentvo.supervisoryPhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["Total_Emp"].ToString() != null && GDs.Tables[2].Rows[0]["Total_Emp"].ToString() != "")
            {
                projectEmploymentvo.totalPhase1 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Total_Emp"].ToString());
            }
            projectEmploymentvo.totalPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Total_Empphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Total_Empphase2"].ToString() != "")
            {
                projectEmploymentvo.totalPhase2 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Total_Empphase2"].ToString());
            }
            projectEmploymentvo.totalPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Total_Empphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Total_Empphase3"].ToString() != "")
            {
                projectEmploymentvo.totalPhase3 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Total_Empphase3"].ToString());
            }
            projectEmploymentvo.totalPhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["Unskilled_Emp"].ToString() != null && GDs.Tables[2].Rows[0]["Unskilled_Emp"].ToString() != "")
            {
                projectEmploymentvo.unSkilledPhase1 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Unskilled_Emp"].ToString());
            }
            projectEmploymentvo.unSkilledPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Unskilled_Empphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Unskilled_Empphase2"].ToString() != "")
            {
                projectEmploymentvo.unSkilledPhase2 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Unskilled_Empphase2"].ToString());
            }
            projectEmploymentvo.unSkilledPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Unskilled_Empphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Unskilled_Empphase3"].ToString() != "")
            {
                projectEmploymentvo.unSkilledPhase3 = Convert.ToInt64(GDs.Tables[2].Rows[0]["Unskilled_Empphase3"].ToString());
            }
            projectEmploymentvo.unSkilledPhase3Specified = true;


            projectMaterialManufacturingvo.descProcessTech = GDs.Tables[2].Rows[0]["providedetails"].ToString();
            projectMaterialManufacturingvo.fileName = GDs.Tables[2].Rows[0]["filepath"].ToString();
            projectMaterialManufacturingvo.processTechnology = GDs.Tables[2].Rows[0]["processtechnology"].ToString();
            projectMaterialManufacturingvo.projectId = 0;
            projectMaterialManufacturingvo.projectIdSpecified = true;
            projectMaterialManufacturingvo.projectmatManf = "";
            TSIICLANDCGG.RawMaterial[] rawmaterial = null;
            if (GDs.Tables[8].Rows.Count > 0)
            {
                DataTable dtraw = new DataTable();
                dtraw = GDs.Tables[8];
                rawmaterial = new TSIICLANDCGG.RawMaterial[dtraw.Rows.Count];

                for (int k = 0; k < dtraw.Rows.Count; k++)
                {
                    TSIICLANDCGG.RawMaterial rawmaterialvo = new TSIICLANDCGG.RawMaterial();

                    rawmaterialvo.dailyConsumption = Convert.ToDouble(dtraw.Rows[k]["DailyConsumption"].ToString());
                    rawmaterialvo.dailyConsumptionSpecified = true;
                    rawmaterialvo.itemCode = dtraw.Rows[k]["Itemcode"].ToString();
                    rawmaterialvo.itemDescription = dtraw.Rows[k]["Descriptionitem"].ToString();
                    rawmaterialvo.rawMaterialId = 0;// Convert.ToInt64(dtraw.Rows[k]["queryRespDocName"].ToString());
                    rawmaterialvo.rawMaterialIdSpecified = true;
                    rawmaterialvo.unitOfMeasure = dtraw.Rows[k]["unitmeasurement"].ToString();
                    rawmaterial[k] = rawmaterialvo;
                }
                projectMaterialManufacturingvo.rawMaterialList = rawmaterial;
            }

            projectMaterialManufacturingvo.rawMaterialList = rawmaterial;
            projectMaterialManufacturingvo.techCollaborationDetails = GDs.Tables[2].Rows[0]["technicalcollabration"].ToString();
            projectMaterialManufacturingvo.technicalCollaboration = true;
            projectMaterialManufacturingvo.technicalCollaborationSpecified = true;
            if (GDs.Tables[2].Rows[0]["noofvessels"] != null && GDs.Tables[2].Rows[0]["noofvessels"].ToString() != "")
            {
                projectPlantMachineryvo.highPressureLevel = Convert.ToInt64(GDs.Tables[2].Rows[0]["noofvessels"].ToString());
            }
            projectPlantMachineryvo.highPressureLevelSpecified = true;

            TSIICLANDCGG.MachineryCapacity[] machinery = null;
            if (GDs.Tables[9].Rows.Count > 0)
            {
                DataTable dtraw = new DataTable();
                dtraw = GDs.Tables[9];
                machinery = new TSIICLANDCGG.MachineryCapacity[dtraw.Rows.Count];

                for (int k = 0; k < dtraw.Rows.Count; k++)
                {
                    TSIICLANDCGG.MachineryCapacity MachineryCapacityvo = new TSIICLANDCGG.MachineryCapacity();
                    MachineryCapacityvo.plantCapacity = Convert.ToDouble(dtraw.Rows[k]["capacitykw"].ToString());
                    MachineryCapacityvo.plantCapacitySpecified = true;
                    MachineryCapacityvo.plantDescription = dtraw.Rows[k]["descplantmachinery"].ToString();
                    MachineryCapacityvo.plantMachineryId = 0;
                    MachineryCapacityvo.plantMachineryIdSpecified = true;
                    machinery[k] = MachineryCapacityvo;
                }
            }
            projectPlantMachineryvo.machineryCapacties = machinery;

            projectPlantMachineryvo.projectId = 0;
            projectPlantMachineryvo.projectIdSpecified = true;

            landvo.adminBuildingId = 0;
            landvo.adminBuildingIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequired"].ToString() != null && GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequired"].ToString() != "")
            {
                landvo.adminBuildingPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequired"].ToString());
            }
            landvo.adminBuildingPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequiredphase2"].ToString() != null && GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequiredphase2"].ToString() != "")
            {
                landvo.adminBuildingPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequiredphase2"].ToString());
            }
            landvo.adminBuildingPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequiredphase3"].ToString() != null && GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequiredphase3"].ToString() != "")
            {
                landvo.adminBuildingPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequiredphase3"].ToString());
            }
            landvo.adminBuildingPhase3Specified = true;
            landvo.estimatedarea = 0.00;// Convert.ToDouble(GDs.Tables[2].Rows[0][""].ToString());
            landvo.estimatedareaSpecified = true;
            landvo.indusShed = Convert.ToDouble(GDs.Tables[1].Rows[0]["Area_in_Sq_Mtrs"].ToString());
            landvo.indusShedSpecified = true;
            landvo.landId = 0;
            landvo.landIdSpecified = true;
            landvo.openAreaId = 0;
            landvo.openAreaIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequired"].ToString() != null && GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequired"].ToString() != "")
            {
                landvo.openAreaPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequired"].ToString());
            }
            landvo.openAreaPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequiredphase2"].ToString() != null && GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequiredphase2"].ToString() != "")
            {
                landvo.openAreaPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequiredphase2"].ToString());
            }
            landvo.openAreaPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequiredphase3"].ToString() != null && GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequiredphase3"].ToString() != "")
            {
                landvo.openAreaPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequiredphase3"].ToString());
            }
            landvo.openAreaPhase3Specified = true;
            landvo.plantFactoryBuildingId = 0;
            landvo.plantFactoryBuildingIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequired"].ToString() != null && GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequired"].ToString() != "")
            {
                landvo.plantFactoryPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequired"].ToString());
            }
            landvo.plantFactoryPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequiredphase2"].ToString() != null && GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequiredphase2"].ToString() != "")
            {
                landvo.plantFactoryPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequiredphase2"].ToString());
            }
            landvo.plantFactoryPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequiredphase3"].ToString() != null && GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequiredphase3"].ToString() != "")
            {
                landvo.plantFactoryPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequiredphase3"].ToString());
            }
            landvo.plantFactoryPhase3Specified = true;
            landvo.remarks = "";
            if (GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequired"].ToString() != null && GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequired"].ToString() != "")
            {
                landvo.roadWaterPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequired"].ToString());
            }
            landvo.roadWaterPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequiredphase2"].ToString() != null && GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequiredphase2"].ToString() != "")
            {
                landvo.roadWaterPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequiredphase2"].ToString());
            }
            landvo.roadWaterPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequiredphase3"].ToString() != null && GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequiredphase3"].ToString() != "")
            {
                landvo.roadWaterPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequiredphase3"].ToString());
            }
            landvo.roadWaterPhase3Specified = true;
            landvo.roadWtrStrgId = 0;
            landvo.roadWtrStrgIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequired"].ToString() != null && GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequired"].ToString() != "")
            {
                landvo.storageWaterPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequired"].ToString());
            }
            landvo.storageWaterPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequiredphase2"].ToString() != null && GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequiredphase2"].ToString() != "")
            {
                landvo.storageWaterPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequiredphase2"].ToString());
            }
            landvo.storageWaterPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequiredphase3"].ToString() != null && GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequiredphase3"].ToString() != "")
            {
                landvo.storageWaterPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequiredphase3"].ToString());
            }
            landvo.storageWaterPhase3Specified = true;
            landvo.storageWtrHosueId = 0;
            landvo.storageWtrHosueIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Total_LandRequired"].ToString() != null && GDs.Tables[2].Rows[0]["Total_LandRequired"].ToString() != "")
            {
                landvo.totalPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Total_LandRequired"].ToString());
            }
            landvo.totalPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Total_LandRequiredphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Total_LandRequiredphase2"].ToString() != "")
            {
                landvo.totalPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Total_LandRequiredphase2"].ToString());
            }
            landvo.totalPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Total_LandRequiredphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Total_LandRequiredphase3"].ToString() != "")
            {
                landvo.totalPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Total_LandRequiredphase3"].ToString());
            }
            landvo.totalPhase3Specified = true;

            if (GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupply"].ToString() != "" && GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupply"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupply"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');
                TSIICLANDCGG.DateHolder commmercialpowersupply = new TSIICLANDCGG.DateHolder();

                commmercialpowersupply.day = newdate[0].ToString();
                commmercialpowersupply.displayDate = "";
                commmercialpowersupply.empty = true;
                commmercialpowersupply.emptySpecified = true;
                commmercialpowersupply.month = newdate[1].ToString();
                commmercialpowersupply.sqlDateStr = "";
                commmercialpowersupply.valid = true;
                commmercialpowersupply.validSpecified = true;
                commmercialpowersupply.year = newdate[2].ToString();
                electricityvo.commercialPhase1 = commmercialpowersupply;
            }
            if (GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupplyphase2"].ToString() != "" && GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupplyphase2"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupplyphase2"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');

                TSIICLANDCGG.DateHolder commmercialpowersupplyphase2 = new TSIICLANDCGG.DateHolder();
                commmercialpowersupplyphase2.day = newdate[0].ToString();
                commmercialpowersupplyphase2.displayDate = "";
                commmercialpowersupplyphase2.empty = true;
                commmercialpowersupplyphase2.emptySpecified = true;
                commmercialpowersupplyphase2.month = newdate[1].ToString();
                commmercialpowersupplyphase2.sqlDateStr = "";
                commmercialpowersupplyphase2.valid = true;
                commmercialpowersupplyphase2.validSpecified = true;
                commmercialpowersupplyphase2.year = newdate[2].ToString();
                electricityvo.commercialPhase2 = commmercialpowersupplyphase2;
            }
            if (GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupplyphase3"].ToString() != "" && GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupplyphase3"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupplyphase3"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');

                TSIICLANDCGG.DateHolder commmercialpowersupplyphase3 = new TSIICLANDCGG.DateHolder();
                commmercialpowersupplyphase3.day = newdate[0].ToString();
                commmercialpowersupplyphase3.displayDate = "";
                commmercialpowersupplyphase3.empty = true;
                commmercialpowersupplyphase3.emptySpecified = true;
                commmercialpowersupplyphase3.month = newdate[1].ToString();
                commmercialpowersupplyphase3.sqlDateStr = "";
                commmercialpowersupplyphase3.valid = true;
                commmercialpowersupplyphase3.validSpecified = true;
                commmercialpowersupplyphase3.year = newdate[2].ToString();
                electricityvo.commercialPhase3 = commmercialpowersupplyphase3;
            }
            if (GDs.Tables[2].Rows[0]["Connectedload_KW"].ToString() != null && GDs.Tables[2].Rows[0]["Connectedload_KW"].ToString() != "")
            {
                electricityvo.connectedLoadPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Connectedload_KW"].ToString());
            }
            electricityvo.connectedLoadPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Connectedload_KWphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Connectedload_KWphase2"].ToString() != "")
            {
                electricityvo.connectedLoadPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Connectedload_KWphase2"].ToString());
            }
            electricityvo.connectedLoadPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Connectedload_KWphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Connectedload_KWphase3"].ToString() != "")
            {
                electricityvo.connectedLoadPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Connectedload_KWphase3"].ToString());
            }
            electricityvo.connectedLoadPhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplys"].ToString() != "" && GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplys"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplys"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');



                TSIICLANDCGG.DateHolder constructionpowersupply = new TSIICLANDCGG.DateHolder();


                constructionpowersupply.day = newdate[0].ToString();
                constructionpowersupply.displayDate = "";
                constructionpowersupply.empty = true;
                constructionpowersupply.emptySpecified = true;
                constructionpowersupply.month = newdate[1].ToString();
                constructionpowersupply.sqlDateStr = "";
                constructionpowersupply.valid = true;
                constructionpowersupply.validSpecified = true;
                constructionpowersupply.year = newdate[2].ToString();
                electricityvo.constructionPhase1 = constructionpowersupply;
            }
            if (GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplyphase2"].ToString() != "" && GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplyphase2"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplyphase2"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');


                TSIICLANDCGG.DateHolder constructionpowersupply2 = new TSIICLANDCGG.DateHolder();
                constructionpowersupply2.day = newdate[0].ToString();
                constructionpowersupply2.day = "";
                constructionpowersupply2.displayDate = "";
                constructionpowersupply2.empty = true;
                constructionpowersupply2.emptySpecified = true;
                constructionpowersupply2.month = newdate[1].ToString();
                constructionpowersupply2.sqlDateStr = "";
                constructionpowersupply2.valid = true;
                constructionpowersupply2.validSpecified = true;
                constructionpowersupply2.year = newdate[2].ToString();
                electricityvo.constructionPhase2 = constructionpowersupply2;
            }
            if (GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplyphase3"].ToString() != "" && GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplyphase3"].ToString() != null)
            {
                string[] date = GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplyphase3"].ToString().Split(' ');
                string[] newdate = date[0].ToString().Split('-');

                TSIICLANDCGG.DateHolder constructionpowersupply3 = new TSIICLANDCGG.DateHolder();

                constructionpowersupply3.day = newdate[0].ToString();

                constructionpowersupply3.displayDate = "";
                constructionpowersupply3.empty = true;
                constructionpowersupply3.emptySpecified = true;
                constructionpowersupply3.month = newdate[1].ToString();
                constructionpowersupply3.sqlDateStr = "";
                constructionpowersupply3.valid = true;
                constructionpowersupply3.validSpecified = true;
                constructionpowersupply3.year = newdate[2].ToString();
                electricityvo.constructionPhase3 = constructionpowersupply3;
            }
            if (GDs.Tables[2].Rows[0]["ContractedMaxDem_KVA"].ToString() != null && GDs.Tables[2].Rows[0]["ContractedMaxDem_KVA"].ToString() != "")
            {
                electricityvo.contractDemandPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["ContractedMaxDem_KVA"].ToString());
            }
            electricityvo.contractDemandPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["ContractedMaxDem_KVAphase2"].ToString() != null && GDs.Tables[2].Rows[0]["ContractedMaxDem_KVAphase2"].ToString() != "")
            {
                electricityvo.contractDemandPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["ContractedMaxDem_KVAphase2"].ToString());
            }
            electricityvo.contractDemandPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["ContractedMaxDem_KVAphase3"].ToString() != null && GDs.Tables[2].Rows[0]["ContractedMaxDem_KVAphase3"].ToString() != "")
            {
                electricityvo.contractDemandPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["ContractedMaxDem_KVAphase3"].ToString());
            }
            electricityvo.contractDemandPhase3Specified = true;
            electricityvo.energySrcDGSet = GDs.Tables[2].Rows[0]["DGset"].ToString();
            electricityvo.energySrcGeneration = GDs.Tables[2].Rows[0]["owngeneration"].ToString();
            electricityvo.energySrcSupply = GDs.Tables[2].Rows[0]["TStranscosupply"].ToString();
            electricityvo.landId = 0;
            electricityvo.landIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Loadfactor"].ToString() != null && GDs.Tables[2].Rows[0]["Loadfactor"].ToString() != "")
            {
                electricityvo.loadFactorPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Loadfactor"].ToString());
            }
            electricityvo.loadFactorPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Loadfactorphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Loadfactorphase2"].ToString() != "")
            {
                electricityvo.loadFactorPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Loadfactorphase2"].ToString());
            }
            electricityvo.loadFactorPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Loadfactorphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Loadfactorphase3"].ToString() != "")
            {
                electricityvo.loadFactorPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Loadfactorphase3"].ToString());
            }
            electricityvo.loadFactorPhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVA"].ToString() != null && GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVA"].ToString() != "")
            {
                electricityvo.powerRequirementPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVA"].ToString());
            }
            electricityvo.powerRequirementPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVAphase2"].ToString() != null && GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVAphase2"].ToString() != "")
            {
                electricityvo.powerRequirementPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVAphase2"].ToString());
            }
            electricityvo.powerRequirementPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVAphase3"].ToString() != null && GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVAphase3"].ToString() != "")
            {
                electricityvo.powerRequirementPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVAphase3"].ToString());
            }
            electricityvo.powerRequirementPhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["Req_PowerSupply_KV"].ToString() != null && GDs.Tables[2].Rows[0]["Req_PowerSupply_KV"].ToString() != "")
            {
                electricityvo.powerSupplyPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Req_PowerSupply_KV"].ToString());
            }
            electricityvo.powerSupplyPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Req_PowerSupply_KVphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Req_PowerSupply_KVphase2"].ToString() != "")
            {
                electricityvo.powerSupplyPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Req_PowerSupply_KVphase2"].ToString());
            }
            electricityvo.powerSupplyPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Req_PowerSupply_KVphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Req_PowerSupply_KVphase3"].ToString() != "")
            {
                electricityvo.powerSupplyPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Req_PowerSupply_KVphase3"].ToString());
            }
            electricityvo.powerSupplyPhase3Specified = true;
            if (GDs.Tables[2].Rows[0]["VoltageRating_HT"].ToString() != null && GDs.Tables[2].Rows[0]["VoltageRating_HT"].ToString() != "")
            {
                electricityvo.voltageRatingPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["VoltageRating_HT"].ToString());
            }
            electricityvo.voltageRatingPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["VoltageRating_HTphase2"].ToString() != null && GDs.Tables[2].Rows[0]["VoltageRating_HTphase2"].ToString() != "")
            {
                electricityvo.voltageRatingPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["VoltageRating_HTphase2"].ToString());
            }
            electricityvo.voltageRatingPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["VoltageRating_HTphase3"].ToString() != null && GDs.Tables[2].Rows[0]["VoltageRating_HTphase3"].ToString() != "")
            {
                electricityvo.voltageRatingPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["VoltageRating_HTphase3"].ToString());
            }
            electricityvo.voltageRatingPhase3Specified = true;

            watervo.landId = 0;
            watervo.landIdSpecified = true;
            watervo.permtDomesticId = 0;
            watervo.permtDomesticIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReq"].ToString() != null && GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReq"].ToString() != "")
            {
                watervo.permtDomesticPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReq"].ToString());
            }
            watervo.permtDomesticPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReqphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReqphase2"].ToString() != "")
            {
                watervo.permtDomesticPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReqphase2"].ToString());
            }
            watervo.permtDomesticPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReqphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReqphase3"].ToString() != "")
            {
                watervo.permtDomesticPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReqphase3"].ToString());
            }
            watervo.permtDomesticPhase3Specified = true;
            watervo.permtIndustrialId = 0;
            watervo.permtIndustrialIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReq"].ToString() != null && GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReq"].ToString() != "")
            {
                watervo.permtIndustrialPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReq"].ToString());
            }
            watervo.permtIndustrialPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReqphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReqphase2"].ToString() != "")
            {
                watervo.permtIndustrialPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReqphase2"].ToString());
            }
            watervo.permtIndustrialPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReqphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReqphase3"].ToString() != "")
            {
                watervo.permtIndustrialPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReqphase3"].ToString());
            }
            watervo.permtIndustrialPhase3Specified = true;
            watervo.tempDomesticId = 0;
            watervo.tempDomesticIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReq"].ToString() != null && GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReq"].ToString() != "")
            {
                watervo.tempDomesticPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReq"].ToString());
            }
            watervo.tempDomesticPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReqphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReqphase2"].ToString() != "")
            {
                watervo.tempDomesticPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReqphase2"].ToString());
            }
            watervo.tempDomesticPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReqphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReqphase3"].ToString() != "")
            {
                watervo.tempDomesticPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReqphase3"].ToString());
            }
            watervo.tempDomesticPhase3Specified = true;
            watervo.tempIndustrialId = 0;
            watervo.tempIndustrialIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase2"].ToString() != "")
            {
                watervo.tempIndustrialPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReq"].ToString());
            }
            watervo.tempIndustrialPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase2"].ToString() != "")
            {
                watervo.tempIndustrialPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase2"].ToString());
            }
            watervo.tempIndustrialPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase3"].ToString() != "")
            {
                watervo.tempIndustrialPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase3"].ToString());
            }
            watervo.tempIndustrialPhase3Specified = true;

            effluentsvo.disposalSystem = GDs.Tables[2].Rows[0]["Descriptioneffulents"].ToString();
            effluentsvo.landId = 0;
            effluentsvo.landIdSpecified = true;
            if (GDs.Tables[2].Rows[0]["Effluentsphase1"].ToString() != null && GDs.Tables[2].Rows[0]["Effluentsphase1"].ToString() != "")
            {
                effluentsvo.quantityPhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Effluentsphase1"].ToString());
            }
            effluentsvo.quantityPhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Effluentsphase2"].ToString() != null && GDs.Tables[2].Rows[0]["Effluentsphase2"].ToString() != "")
            {
                effluentsvo.quantityPhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Effluentsphase2"].ToString());
            }
            effluentsvo.quantityPhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Effluentsphase3"].ToString() != null && GDs.Tables[2].Rows[0]["Effluentsphase3"].ToString() != "")
            {
                effluentsvo.quantityPhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Effluentsphase3"].ToString());
            }
            effluentsvo.quantityPhase3Specified = true;
            effluentsvo.typeDescription = GDs.Tables[2].Rows[0]["Descriptioneffulents"].ToString();
            if (GDs.Tables[2].Rows[0]["Soildwastephase1"].ToString() != null && GDs.Tables[2].Rows[0]["Soildwastephase1"].ToString() != "")
            {
                effluentsvo.wastagePhase1 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Soildwastephase1"].ToString());
            }
            effluentsvo.wastagePhase1Specified = true;
            if (GDs.Tables[2].Rows[0]["Soildwastephase2"].ToString() != null && GDs.Tables[2].Rows[0]["Soildwastephase2"].ToString() != "")
            {
                effluentsvo.wastagePhase2 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Soildwastephase2"].ToString());
            }
            effluentsvo.wastagePhase2Specified = true;
            if (GDs.Tables[2].Rows[0]["Soildwastephase3"].ToString() != null && GDs.Tables[2].Rows[0]["Soildwastephase3"].ToString() != "")
            {
                effluentsvo.wastagePhase3 = Convert.ToDouble(GDs.Tables[2].Rows[0]["Soildwastephase3"].ToString());
            }
            effluentsvo.wastagePhase3Specified = true;

        }

        if (GDs.Tables[3].Rows.Count > 0)
        {
            DataTable dtceigdocuments = new DataTable();
            dtceigdocuments = GDs.Tables[3];
            for (int n = 0; n < dtceigdocuments.Rows.Count; n++)
            {
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "1")
                {
                    documentCheckListvo.detailedProject = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }

                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "2")
                {
                    documentCheckListvo.enterpreneurMemorandum = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }
                //documentCheckListvo.
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "3")
                {
                    documentCheckListvo.partnerShipDeed = dtceigdocuments.Rows[n]["Filepath"].ToString();// GDs.Tables[3].Rows[0]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "4")
                {
                    documentCheckListvo.shareHolderDetails = dtceigdocuments.Rows[n]["Filepath"].ToString();// GDs.Tables[3].Rows[0]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "5")
                {
                    documentCheckListvo.plantLayout = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "6")
                {
                    documentCheckListvo.casteCertificate = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "7")
                {
                    documentCheckListvo.addressProof = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "8")
                {
                    documentCheckListvo.panCard = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "9")
                {
                    documentCheckListvo.photoGraph = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "10")
                {
                    documentCheckListvo.financeCertificate = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "11")
                {
                    documentCheckListvo.paymentReceipt = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "12")
                {
                    documentCheckListvo.gstCertificate = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "13")
                {
                    documentCheckListvo.otherDocument = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }
                if (dtceigdocuments.Rows[n]["attachmentid"].ToString() == "16")
                {
                    documentCheckListvo.cancelledCheck = dtceigdocuments.Rows[n]["Filepath"].ToString();
                }

            }
        }


        TSIICLANDCGG.AdditionalPromoter[] additionalPromotervo = null;// new TSIICLANDCGG.AdditionalPromoter();

        //new TSIICLANDCGG.AdditionalPromoter();
        if (GDs.Tables[4].Rows.Count > 0)
        {
            TSIICLANDCGG.AdditionalPromoter[] AdditionalPromotervo = null;
            DataTable dtraw = new DataTable();
            dtraw = GDs.Tables[4];
            AdditionalPromotervo = new TSIICLANDCGG.AdditionalPromoter[dtraw.Rows.Count];

            for (int k = 0; k < dtraw.Rows.Count; k++)
            {
                //FactoryService.rawMaterial BBB = new FactoryService.rawMaterial();
                TSIICLANDCGG.AdditionalPromoter coc = new TSIICLANDCGG.AdditionalPromoter();
                coc.additionalPromoterId = 0;// Convert.ToInt32(dtraw.Rows[k]["0"]);
                coc.additionalPromoterIdSpecified = false;// Convert.ToBoolean(dtraw.Rows[k]["false"]);
                if (dtraw.Rows[k]["Experience"].ToString() != null && dtraw.Rows[k]["Experience"].ToString() != "")
                {
                    coc.experience = Convert.ToDouble(dtraw.Rows[k]["Experience"].ToString());
                }
                coc.experienceSpecified = true;
                coc.name = dtraw.Rows[k]["Name"].ToString();
                coc.netWorthSpecified = true;
                //coc.m = dtraw.Rows[k]["Contractor_MobileNo"].ToString();
                coc.netWorth = Convert.ToInt32(dtraw.Rows[k]["Networth"]);
                coc.qualification = dtraw.Rows[k]["Qualification"].ToString();
                coc.contactNo = dtraw.Rows[k]["ContactNo"].ToString();
                coc.address = dtraw.Rows[k]["Address"].ToString();
                AdditionalPromotervo[k] = coc;
                //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
            }
            additionalPromotervo = AdditionalPromotervo;

        }
        if (GDs.Tables[5].Rows.Count > 0)
        {

            registraionvo.companyAddress = "";
            registraionvo.companyAreaCode = "";
            registraionvo.companyName = "";
            registraionvo.companyPhone = "";
            registraionvo.emailId = GDs.Tables[5].Rows[0]["Email"].ToString();
            registraionvo.firstName = GDs.Tables[5].Rows[0]["Firstname"].ToString();
            registraionvo.ipassRegistrationId = Convert.ToInt64(GDs.Tables[5].Rows[0]["INTUSERID"].ToString());
            registraionvo.ipassRegistrationIdSpecified = true;
            registraionvo.mobile = GDs.Tables[5].Rows[0]["MobileNo"].ToString();
            registraionvo.password = "";
            registraionvo.surname = GDs.Tables[5].Rows[0]["Lastname"].ToString();
        }
        if (GDs.Tables[6].Rows.Count > 0)
        {

            //paymentDetailsvo.area = "61169.00";
            paymentDetailsvo.bankReferenceNumber = GDs.Tables[6].Rows[0]["TransactionNO"].ToString();


            paymentDetailsvo.customerReferenceNumber = GDs.Tables[6].Rows[0]["UIDNO"].ToString();
            paymentDetailsvo.dateAndTime = "";
            paymentDetailsvo.emd = "";
            paymentDetailsvo.gstNumber = "";
            paymentDetailsvo.gstRegesterd = "";
            paymentDetailsvo.industrialPark = "";
            paymentDetailsvo.landCost = Convert.ToDouble(GDs.Tables[6].Rows[0]["Online_Amount"].ToString());
            paymentDetailsvo.landCostSpecified = true;
            paymentDetailsvo.paidAmount = Convert.ToDouble(GDs.Tables[6].Rows[0]["Online_Amount"].ToString());
            paymentDetailsvo.paidAmountSpecified = true;
            paymentDetailsvo.paymentMode = "Online";
            //paymentDetailsvo.processFee = "";
            paymentDetailsvo.referenceId = GDs.Tables[6].Rows[0]["OnlineOrderNo"].ToString();
            paymentDetailsvo.remarks = "";
            //paymentDetailsvo.sgst = "";
            paymentDetailsvo.statusCode = "";
            paymentDetailsvo.transactionNumber = GDs.Tables[6].Rows[0]["TransactionNO"].ToString();
            paymentDetailsvo.dateAndTime = GDs.Tables[6].Rows[0]["Transactiondatetime"].ToString();
            paymentDetailsvo.account_branch = GDs.Tables[6].Rows[0]["account_branch"].ToString();
            paymentDetailsvo.account_ifsc = GDs.Tables[6].Rows[0]["account_ifsc"].ToString();
            paymentDetailsvo.account_name = GDs.Tables[6].Rows[0]["account_name"].ToString();
            paymentDetailsvo.account_no = GDs.Tables[6].Rows[0]["account_no"].ToString();
            paymentDetailsvo.account_type = GDs.Tables[6].Rows[0]["account_type"].ToString();
        }

        if (GDs.Tables[10].Rows.Count > 0)
        {
            paymentDetailsvo.area = GDs.Tables[10].Rows[0]["PlotTotalArea"].ToString();
            paymentDetailsvo.cgst = GDs.Tables[10].Rows[0]["CGST"].ToString();
            paymentDetailsvo.sgst = GDs.Tables[10].Rows[0]["SGST"].ToString();
            paymentDetailsvo.processFee = GDs.Tables[10].Rows[0]["ProcessFee"].ToString();
            paymentDetailsvo.emd = GDs.Tables[10].Rows[0]["TotalEmd"].ToString();
        }
        if (GDs.Tables[12].Rows.Count > 0)
        {
            plotvo.totalArea = Convert.ToDouble(GDs.Tables[12].Rows[0]["PlotTotalArea"]);
        }
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = //SecurityProtocolType.Tls12;
        SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
        string useroutput = landservice.registerUser(registraionvo);
        string output = landservice.saveApplicationDetails(plotvo, Convert.ToInt32(createdby), applicationid, verifyFirmvo, promoterDetailsvo, additionalPromotervo, projectGeneralvo, projectFinancialvo,
              projectEmploymentvo, projectMaterialManufacturingvo, projectPlantMachineryvo, landvo, electricityvo, watervo, effluentsvo, paymentDetailsvo, documentCheckListvo);
        if (output == "Applications details are saved successfully....")
        {
            gen.UpdateDepartwebserviceflagtsiic(Convert.ToString(applicationid), "3", "C", "Y", output);

        }
        else
        {
            gen.UpdateDepartwebserviceflagtsiic(Convert.ToString(applicationid), "3", "C", "N", output);
        }

    }

    public void Webservices(string UIDNO)
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

                            //string WEBSERVICE_URL = "http://164.100.163.19/TLWSC/updateFee?cafUniqueNo=" + cafUniqueNo + "&indApplicationNo=" + indApplication + "&transactionId=" + transactionId + "&amount=" + amount + "&bankName=" + bankName + "&transactionStatus=" + transactionStatus + "&paymentType=" + paymentType + "&additionalPayment=" + additionalPayment + "";


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
                                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", jsonResponse, "Y");
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
                            CEIGService.installationApplication ceifvo = new CEIGService.installationApplication();
                            DataSet dsdept = new DataSet();
                            string valueshmwssb = "";
                            string outputhmwssb = "";
                            string outpayhmwssb = "";
                            dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);
                            valueshmwssb = dsdept.GetXml();
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                            {

                                ceifvo.aadhar_number = dsdept.Tables[0].Rows[0]["AadharNo"].ToString();
                                ceifvo.applicationID = dsdept.Tables[0].Rows[0]["intCFOPowerid"].ToString();
                                ceifvo.UID = dsdept.Tables[0].Rows[0]["UID_No"].ToString();
                                ceifvo.atc = dsdept.Tables[0].Rows[0]["ATC"].ToString();
                                //ceifvo.checkListUploads = "";
                                ceifvo.cli_already_installed = dsdept.Tables[0].Rows[0]["Cont_Demand_Max_Already"].ToString();
                                ceifvo.cli_proposed = dsdept.Tables[0].Rows[0]["Cont_Demand_Max_Proposed"].ToString();
                                ceifvo.cmd_already_installed = dsdept.Tables[0].Rows[0]["Connect_Load_A"].ToString();
                                ceifvo.cmd_proposed = dsdept.Tables[0].Rows[0]["Connect_Load_B"].ToString();
                                ceifvo.customer_remarks = "";//dsdept.Tables[0].Rows[0][""].ToString();
                                ceifvo.district_id = dsdept.Tables[0].Rows[0]["intDistrictid"].ToString();
                                ceifvo.email_id = dsdept.Tables[0].Rows[0]["Email"].ToString();
                                ceifvo.entrepreneurID = dsdept.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                                ceifvo.file_number = "";// dsdept.Tables[0].Rows[0][""].ToString();
                                ceifvo.first_name = dsdept.Tables[0].Rows[0]["NameofthePromoter"].ToString();
                                ceifvo.hno = dsdept.Tables[0].Rows[0]["Survey_No"].ToString();
                                ceifvo.industry_district_id = dsdept.Tables[0].Rows[0]["Prop_intDistrictid"].ToString();
                                ceifvo.industry_hno = dsdept.Tables[0].Rows[0]["Door_No"].ToString();
                                ceifvo.industry_mandal_id = dsdept.Tables[0].Rows[0]["Prop_intMandalid"].ToString();
                                ceifvo.industry_pincode = dsdept.Tables[0].Rows[0]["Pincode"].ToString();
                                ceifvo.industry_plot_no = dsdept.Tables[0].Rows[0]["PLOTNO"].ToString();
                                ceifvo.industry_street_name = dsdept.Tables[0].Rows[0]["StreetName"].ToString();
                                ceifvo.industry_sy_no = dsdept.Tables[0].Rows[0]["Survey_No"].ToString();
                                ceifvo.industry_village_id = dsdept.Tables[0].Rows[0]["Prop_intVillageid"].ToString();
                                ceifvo.last_name = dsdept.Tables[0].Rows[0]["NameofthePromoter"].ToString();
                                ceifvo.loction_district_id = dsdept.Tables[0].Rows[0]["intDistrictid"].ToString();
                                ceifvo.mandal_id = dsdept.Tables[0].Rows[0]["intMandalid"].ToString();
                                ceifvo.mobile_no = dsdept.Tables[0].Rows[0]["MobileNumber"].ToString();
                                ceifvo.name_of_industry = dsdept.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();
                                ceifvo.name_of_promoter = dsdept.Tables[0].Rows[0]["NameofthePromoter"].ToString();
                                ceifvo.pan_number = dsdept.Tables[0].Rows[0]["PANcardno"].ToString();
                                ceifvo.pincode = dsdept.Tables[0].Rows[0]["Pincode"].ToString();
                                ceifvo.plant_slno = dsdept.Tables[0].Rows[0]["Plant_slno"].ToString();
                                ceifvo.plot_no = dsdept.Tables[0].Rows[0]["DOOR_nO"].ToString();
                                ceifvo.proposal_for = dsdept.Tables[0].Rows[0]["ProposalForQue"].ToString();
                                ceifvo.questionaireID = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                                ceifvo.regulation_slno = dsdept.Tables[0].Rows[0]["Regulation_type"].ToString();
                                ceifvo.so_do_wo = dsdept.Tables[0].Rows[0]["NameofthePromoter"].ToString();
                                ceifvo.street_name = dsdept.Tables[0].Rows[0]["Street_Name"].ToString();
                                ceifvo.sy_no = "123";// dsdept.Tables[0].Rows[0][""].ToString();
                                ceifvo.system_ip = "1.1.1.1"; ;// dsdept.Tables[0].Rows[0][""].ToString();                                
                                ceifvo.type_of_industry = "35";//dsdept.Tables[0].Rows[0]["TypeofFactory"].ToString();
                                ceifvo.type_of_industry_others = "";// dsdept.Tables[0].Rows[0][""].ToString();                              
                                ceifvo.user_name = dsdept.Tables[0].Rows[0]["User_name"].ToString();
                                ceifvo.password = dsdept.Tables[0].Rows[0]["password"].ToString();
                                ceifvo.village_id = dsdept.Tables[0].Rows[0]["Village_Name"].ToString();
                                ceifvo.voltage_slno = dsdept.Tables[0].Rows[0]["Voltage_Slno"].ToString();
                                DataSet dsBoiler = new DataSet();
                                CEIGService.checkListUploads[] Uploaddocuments = null;
                                dsBoiler = gen.getattachmentdetailsonuidCFO(UIDNO, "16", "");
                                string attcvalueshmwssb = dsBoiler.GetXml();
                                if (dsBoiler != null && dsBoiler.Tables.Count > 0)
                                {

                                    ///Registration Deed////

                                    //if (dsBoiler.Tables[0].Rows.Count > 0)
                                    //{
                                    DataTable dtceigdocuments = new DataTable();
                                    dtceigdocuments = dsBoiler.Tables[0];
                                    Uploaddocuments = new CEIGService.checkListUploads[dtceigdocuments.Rows.Count];

                                    for (int n = 0; n < dtceigdocuments.Rows.Count; n++)
                                    {
                                        CEIGService.checkListUploads uploadvo = new CEIGService.checkListUploads();
                                        uploadvo.documentName = dtceigdocuments.Rows[n]["FileName"].ToString();
                                        uploadvo.documentPath = dtceigdocuments.Rows[n]["Filepath"].ToString();
                                        uploadvo.documentId = Convert.ToInt32(dtceigdocuments.Rows[n]["Documentid"].ToString());
                                        Uploaddocuments[n] = uploadvo;
                                    }
                                    ceifvo.checkListUploads = Uploaddocuments;
                                    //}
                                }
                                string ceigout = ceifcfo.insertIntoInstallationApproval(ceifvo);
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
                        }

                        if (deptid == "27") // Boilers
                        {
                            try
                            {
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
                                    boilervo.application_stage = Convert.ToInt16(dsdept.Tables[0].Rows[0]["application_stage"].ToString());
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
                                    boilervo.created_by = Convert.ToInt16(dsdept.Tables[0].Rows[0]["created_by"].ToString());
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
                                    boilervo.enterpreneur_id = Convert.ToInt16(dsdept.Tables[0].Rows[0]["enterpreneur_id"].ToString());
                                    boilervo.erector_class = dsdept.Tables[0].Rows[0]["erector_class"].ToString();
                                    boilervo.erector_name = dsdept.Tables[0].Rows[0]["erector_name"].ToString();
                                    boilervo.hoa = dsdept.Tables[0].Rows[0]["hoa"].ToString();
                                    //boilervo.inspection_officer = Convert.ToInt16(dsdept.Tables[0].Rows[0]["inspection_officer"].ToString());
                                    boilervo.inspector_authority_flag = Convert.ToInt16(dsdept.Tables[0].Rows[0]["inspector_authority_flag"].ToString());
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
                                    boilervo.present_status_id = Convert.ToInt16(dsdept.Tables[0].Rows[0]["present_status_id"].ToString());
                                    boilervo.quessionaire_id = Convert.ToInt16(dsdept.Tables[0].Rows[0]["quessionaire_id"].ToString());
                                    boilervo.remittersname = dsdept.Tables[0].Rows[0]["remittersname"].ToString();
                                    boilervo.required_documents = dsdept.Tables[0].Rows[0]["required_documents"].ToString();
                                    boilervo.system_ip = dsdept.Tables[0].Rows[0]["system_ip"].ToString();
                                    boilervo.trydate = dsdept.Tables[0].Rows[0]["trydate"].ToString();
                                    boilervo.type_of_boiler = dsdept.Tables[0].Rows[0]["type_of_boiler"].ToString();
                                    boilervo.upload_form5 = dsdept.Tables[0].Rows[0]["upload_form5"].ToString();
                                    boilervo.user_serial_no = Convert.ToInt16(dsdept.Tables[0].Rows[0]["user_serial_no"].ToString());
                                    boilervo.village = dsdept.Tables[0].Rows[0]["village"].ToString();
                                    boilervo.year = dsdept.Tables[0].Rows[0]["year"].ToString();

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
                                        int k = gen.InsertDeptDateTracingCFO(dsdept.Tables[0].Rows[0]["intDeptid"].ToString(), dsdept.Tables[0].Rows[0]["quessionaire_id"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
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
                                        shopactobjnew.actID = "SEF";//dsdept.Tables[0].Rows[0]["actID"].ToString();
                                        shopactobjnew.bank_code = dsdept.Tables[0].Rows[0]["bank_code"].ToString();
                                        shopactobjnew.bank_ref_number = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                        shopactobjnew.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                        shopactobjnew.cin = dsdept.Tables[0].Rows[0]["cin"].ToString();
                                        shopactobjnew.compound_fee = 0;// dsdept.Tables[0].Columns[""].ToString();
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
                                        shopactobjnew.transaction_status = "Y";
                                        shopactobjnew.transactionDate = dsdept.Tables[0].Rows[0]["transactionDate"].ToString();
                                        //labour.tsipassApplicationID = dsdept.Tables[0].Rows[0]["tsipassApplicationID"].ToString();
                                        shopactobjnew.type_of_application = dsdept.Tables[0].Rows[0]["type_of_application"].ToString();
                                        shopactobjnew.uID = dsdept.Tables[0].Rows[0]["UID_NO"].ToString();
                                        shopactobjnew.unpaid_balance_welfare = Convert.ToInt32(dsdept.Tables[0].Rows[0]["unpaid_balance_welfare"].ToString());
                                        shopactobjnew.valid_from_date = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                                        shopactobjnew.valid_to_date = dsdept.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();
                                        shopactobjnew.establishment_category = "1";
                                        shopactobjnew.establishment_classification = "1";
                                        shopactobjnew.male_adults = dsdept.Tables[0].Rows[0]["Form1_1_Employees_Above18_Male"].ToString();
                                        shopactobjnew.male_young = dsdept.Tables[0].Rows[0]["Form1_1_Employees_14_18_Male"].ToString();
                                        shopactobjnew.female_adults = dsdept.Tables[0].Rows[0]["Form1_1_Employees_Above18_Female"].ToString();
                                        shopactobjnew.female_young = dsdept.Tables[0].Rows[0]["Form1_1_Employees_14_18_Female"].ToString();
                                        shopactobjnew.employees_proof = "";
                                        shopactobjnew.address_proof = "";
                                        shopactobjnew.authorise_letter_proof = "";
                                        shopactobjnew.certificate_incorporation_proof = "";
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
                                        labouract.shopRegistrationActData = shopactobjnew;
                                        labourout = labourserviceCfo.actSelected(labouract);

                                        // labourout = labourserviceCfo.actSelected(labouract);
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
                        string deptid = dtadd.Rows[i]["intApprovalid"].ToString();
                        string intQuessionairecfoid = dtadd.Rows[i]["intQuessionaireid"].ToString();
                        string intcfoenterpid = dtadd.Rows[i]["intCFOEnterpid"].ToString();
                        string INTDEPDID = dtadd.Rows[i]["intDeptid"].ToString();
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
                            string additionalPayment = "T";

                            //string WEBSERVICE_URL = "http://164.100.163.19/TLWSC/updateFee?cafUniqueNo=" + cafUniqueNo + "&indApplicationNo=" + indApplication + "&transactionId=" + transactionId + "&amount=" + amount + "&bankName=" + bankName + "&transactionStatus=" + transactionStatus + "&paymentType=" + paymentType + "&additionalPayment=" + additionalPayment + "";

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
                                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", jsonResponse, "Y");
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
                            try
                            {
                                string outputfactory = "";
                                string valuefactory = "";
                                DataSet dsdept = new DataSet();
                                dsdept = gen.getAdditionalPaymentDetailsCFO(UIDNO, deptid);
                                valuefactory = dsdept.GetXml();
                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                                {
                                    CEIGService.payment ceigpaymentvo = new CEIGService.payment();
                                    ceigpaymentvo.amount = Convert.ToDouble(dsdept.Tables[0].Rows[0]["Online_Amount"].ToString());
                                    //ceigpaymentvo.applicationID = dsdept.Tables[0].Rows[0]["Created_by"].ToString();
                                    ceigpaymentvo.bank_id = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                    ceigpaymentvo.branch_name = "";
                                    ceigpaymentvo.challan_copy = "";
                                    ceigpaymentvo.challan_date = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                    ceigpaymentvo.challan_no = dsdept.Tables[0].Rows[0]["challano"].ToString();
                                    ceigpaymentvo.entrepreneurID = dsdept.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                                    ceigpaymentvo.payment_type = dsdept.Tables[0].Rows[0]["paymentmode"].ToString();
                                    ceigpaymentvo.questionaireID = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                                    ceigpaymentvo.reply_document = "";
                                    ceigpaymentvo.reply_remarks = "";
                                    ceigpaymentvo.system_ip = "1.1.1.1"; ;
                                    ceigpaymentvo.tx_id = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                    ceigpaymentvo.UID = dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                    string outceigpayment = ceifcfo.updatePayment(ceigpaymentvo);

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
}