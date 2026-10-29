using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_PANVerification : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    string url = Convert.ToString(ConfigurationManager.AppSettings["PANURLLIVE"]);
    string password = Convert.ToString(ConfigurationManager.AppSettings["PANFXPasswordLIVE"]);
    string certificate = Convert.ToString(ConfigurationManager.AppSettings["PANCertificatenameLIVE"]);
    string userid = Convert.ToString(ConfigurationManager.AppSettings["PANUseridLIVE"]);
    PANVO panvo = new PANVO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] != null)
        { }
        else
        {
            Response.Redirect("~/IpassLogin.aspx");
        }
    }
    protected void rblPanCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblPanCategory.SelectedValue == "Individual")
            {
                lblName.Text = "Name as per PAN";
                lblDate.Text = "Date of Birth as per PAN";
            }
            else
            {
                lblName.Text = "Company Name as per PAN";
                lblDate.Text = "Date of Incorporation as per PAN";
            }
        }
        catch (Exception ex)
        {
            // Handle exception (e.g., log the error)
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
          
            if (Session["uid"] != null)
            {
                bool isEmailSent, isSMSsent, isPANValid;
                string msg = Validations();
                if (msg == "")
                {
                    isEmailSent = SendMailAnother(txtEmail.Text);
                    //isEmailSent = true;
                    if (isEmailSent)
                    {
                         //isSMSsent = OTPMobile();
                         isPANValid = verifyPANDetails();
                        isSMSsent = true;
                        //isPANValid = true;
                        if (!isPANValid)
                        {
                            Console.Write(Convert.ToString(isPANValid));
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('PAN details are not valid.');", true);
                            return;
                        }
                        else
                        {
                            if (isSMSsent)
                            {
                                tblbase.Visible = false;
                                tblverify.Visible = true;
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('An OTP has been sent to your Mobile Number and email id. Please enter those to verify.');", true);
                            }
                            else
                            {
                                tblbase.Visible = true;
                                tblverify.Visible = false;
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error occured while sending SMS OTP.');", true);
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error occured while sending email OTP or Invalid email ID.');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');", true);
                }
            }
            else
            {
                Response.Redirect("~/IpassLogin.aspx");
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    public string Validations()
    {
        string msg = "";
        if (txtEmail.Text == "")
        {
            msg += "Please Enter Email ID \\n";
        }
        if (txtMobileNo.Text == "")
        {
            msg += "Please Enter Mobile No \\n";
        }
        if (rblPanCategory.SelectedIndex == -1)
        {
            msg += "Please Select PAN Category \\n";
        }
        if (txtPANNumber.Text == "")
        {
            msg += "Please Enter PAN Number \\n";
        }
        if (txtDate.Text == "")
        {
            if (rblPanCategory.SelectedValue == "Individual")
                msg += "Please Enter Date of Birth as per PAN \\n";
            else
                msg += "Please Enter Date of Incorporation as per PAN \\n";
        }
        if (txtNamePerPAN.Text == "")
        {
            if (rblPanCategory.SelectedValue == "Individual")
                msg += "Please Enter Name as per PAN \\n";
            else
                msg += "Please Enter Company Name as per PAN \\n";
        }
        return msg;
    }
    public bool OTPMobile()
    {
        bool isSMSsent = false;
        try
        {
            Random random = new Random();
            string combination = "ABCDEFGHJKLMNPQRSTUVWXYZabdfghjkmnpqrstuvwxyz123456789";
            StringBuilder SecretKey = new StringBuilder();
            for (int i = 0; i < 6; i++)
                SecretKey.Append(combination[random.Next(combination.Length)]);
            ViewState["SMSOTPKey"] = SecretKey.ToString();
            //////mobile message purpose
            string msgMobile = "Dear " + Convert.ToString(Session["username"]) + " " + ", " + "\r\n" + "" + "Your OTP is : '" + SecretKey.ToString() + "'" + "\r\n" + "Please confirm to register";
            msgMobile = msgMobile + "\r\n" + "\r\n" + "Regards ," + "\r\n" + "Commissionerate of Industries," + "\n" + "TS-iPASS Cell.";

            string bodyMobile = msgMobile;
            string resopnse = SendSingleSMSnew(txtMobileNo.Text, bodyMobile, "1007055554890143840");
            if (resopnse.Contains("402"))
            {
                isSMSsent = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('An OTP has been sent to your Mobile Number and email id. Please enter it to verify.');", true);
            }
            else
            {
                isSMSsent = false;
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
        return isSMSsent;
    }
    public string SendSingleSMSnew(string mobileNo, string message, string templID)
    {
        String username = "TSIPASS";
        String password = "kcsb@786";
        String senderid = "TSIPAS";
        String secureKey = "e8750728-53e8-4f29-9bc9-9f06975accb0";
        //Latest Generated Secure Key

        Stream dataStream;
        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequestDLT");
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
            "&key=" + HttpUtility.UrlEncode(NewsecureKey.Trim()) +
            "&templateid=" + HttpUtility.UrlEncode(templID.Trim());


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
    protected string encryptedPasswod(string password)
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
    protected string hashGenerator(string Username, string sender_id, string message, string secure_key)
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

    public bool SendMailAnother(string anothermail)
    {
        bool isEmailSent = false;
        try
        {

            Random random = new Random();
            string combination = "ABCDEFGHJKLMNPQRSTUVWXYZabdfghjkmnpqrstuvwxyz123456789";
            StringBuilder EmailOTPKey = new StringBuilder();
            for (int i = 0; i < 8; i++)
                EmailOTPKey.Append(combination[random.Next(combination.Length)]);
            ViewState["EmailOTPKey"] = EmailOTPKey.ToString();

            string from = "tsipass.telangana@gmail.com"; //Replace this with your own correct Gmail Address

            string to = anothermail; //Replace this with the Email Address to whom you want to send the mail

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(to);
            mail.From = new MailAddress(from, ":: TSiPASS ::", System.Text.Encoding.UTF8);

            mail.Subject = "OTP to Update User Details -";// + Session["user_id"].ToString()

            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = "Dear Sir/Madam" + "<br><br> " + "Please use this code: " + Convert.ToString(ViewState["EmailOTPKey"]) + " to update the details.<br><br>  " +
                 "Regards<br>TGiPASS";
            mail.BodyEncoding = System.Text.Encoding.UTF8;

            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            SmtpClient client = new SmtpClient();
            //Add the Creddentials- use your own email id and password

            client.Credentials = new System.Net.NetworkCredential(from, "fqeq nive azke giwb");// "tsipass@2016");

            client.Port = 587; // Gmail works on this port
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true; //Gmail works on Server Secured Layer


            try
            {
                client.Send(mail);
                isEmailSent = true;
            }
            catch (Exception ex)
            {
                isEmailSent = false;
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
                //HttpContext.Current.Response.Write(errorMessage);
                HttpContext.Current.Response.Write("Error Occured while sending E-mail");
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            } // end try
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());

        }
        return isEmailSent;
    }


    public bool verifyPANDetails()
    {
        bool IsValidPAN = false;
        string panvalid, responseCode, outputData;
        panvo.pan = txtPANNumber.Text;
        panvo.name = txtNamePerPAN.Text;
        panvo.fathername = "";
        panvo.dob = txtDate.Text;
        string JsonFrimDetails = JsonConvert.SerializeObject(panvo);
        ServicePointManager.SecurityProtocol = (SecurityProtocolType)48 | (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://121.240.36.237/TIN/PanInquiryAPIBackEnd");//("https://121.240.36.237/TIN/PanInquiryAPIBackEnd");//

        try
        {
            if (request != null)
            {
                request.Method = "POST";
                request.Timeout = 20000;
                request.ContentType = "application/json";
                request.Headers["User_ID"] = "V0066906";
                request.Headers["Records_count"] = "1";
                DateTime currentDateTime = DateTime.Now;
                string formattedDateTime = currentDateTime.ToString("yyyy-MM-ddTHH:mm:ss");
                request.Headers["Request_time"] = formattedDateTime;
                request.Headers["Transaction_ID"] = "V0066906:1234567890ABcdefGHIJH";
                request.Headers["Version"] = "4";
                string inputdata = "inputData:[" + JsonFrimDetails + "]";
                // Convert JSON string to byte array
                // byte[] byteArray = Encoding.UTF8.GetBytes(JsonFrimDetails);
                byte[] byteArray = Encoding.UTF8.GetBytes(inputdata);
                GetPANRequest(inputdata);
                request.ContentLength = byteArray.Length;

                // Write JSON data to request body
                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }
                try
                {
                    GetPANRequest(formattedDateTime + " req- " + JsonFrimDetails);
                }
                catch (Exception ex)
                {

                }
                try
                {
                    // Get response
                    using (WebResponse response = request.GetResponse())
                    {
                        // Read response
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                            string responseJson = reader.ReadToEnd();//{"connectionid":"241834332402090001","status":"success"}
                            try
                            {
                                JObject jsonpanvalid = JObject.Parse(responseJson);
                                responseCode = Convert.ToString(jsonpanvalid["response_Code"]);
                                JArray outputArray = jsonpanvalid["outputData"] as JArray;
                                outputData = Convert.ToString(jsonpanvalid["outputData"]);
                                string panStatus = null;
                                if (outputArray != null && outputArray.Count > 0)
                                {
                                    panStatus = (string)outputArray[0]["pan_status"];
                                }
                                //string panStatus = Convert.ToString(jsonpanvalid["outputData"][0]["pan_status"]);
                                if (responseCode == "1" && panStatus == "E") //Valid PAN refere frmPANApi.aspx page
                                {
                                    IsValidPAN = true;
                                }
                                GetPANResponse("Madhuri" + responseJson);
                            }
                            catch (Exception ex)
                            {

                            }
                            Console.WriteLine("status: " + responseJson);
                            if (responseJson.Contains("success"))
                            {

                            }
                        }
                    }
                }
                catch (WebException ex)
                {
                    // Handle exception
                    if (ex.Response != null)
                    {
                        using (WebResponse errorResponse = ex.Response)
                        {
                            using (Stream errorStream = errorResponse.GetResponseStream())
                            {
                                StreamReader reader = new StreamReader(errorStream, Encoding.GetEncoding("utf-8"));
                                string errorText = reader.ReadToEnd();
                                GetPANResponse(errorText);
                                Console.WriteLine("Error response: " + errorText);
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            GetPANResponse(ex.Message);
            System.Diagnostics.Debug.WriteLine(ex.ToString());
        }
        return IsValidPAN;
    }
    public void GetPANRequest(string Responce)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_INS_PANREQUEST", con.GetConnection);
            da.SelectCommand.Parameters.Add("@responce", SqlDbType.VarChar).Value = Responce.ToString();
            da.SelectCommand.Parameters.Add("@Online", SqlDbType.VarChar).Value = "Online";

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(ds);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
    }
    public void GetPANResponse(string Responce)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_INS_PANRESPONSE", con.GetConnection);
            da.SelectCommand.Parameters.Add("@responce", SqlDbType.VarChar).Value = Responce.ToString();
            da.SelectCommand.Parameters.Add("@Online", SqlDbType.VarChar).Value = "Online";

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(ds);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
    }
    public class PANVO
    {
        //  string Name { get; set; }
        public string pan { get; set; }
        public string name { get; set; }
        public string fathername { get; set; }
        public string dob { get; set; }
        public string signature { get; set; }
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (txtEmailOtp.Text.Trim() == Convert.ToString(ViewState["EmailOTPKey"]) &&
            txtMobileOtp.Text.Trim() == Convert.ToString(ViewState["SMSOTPKey"]))
        {
            int valid = 0;
            con.OpenConnection();
            SqlCommand da = new SqlCommand("SP_UPDATE_PAN_EMAIL_MOBILE", con.GetConnection);
            da.CommandType = CommandType.StoredProcedure;
            try
            {
                DateTime parsedDate = DateTime.ParseExact(txtDate.Text, "dd-MM-yyyy", null);
                string formattedDate = parsedDate.ToString("yyyy-MM-dd");
                da.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = Convert.ToString(Session["uid"]);
                da.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = txtMobileNo.Text.Trim();
                da.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text.Trim();
                da.Parameters.Add("@PANCategory", SqlDbType.VarChar).Value = rblPanCategory.SelectedValue.Trim();
                da.Parameters.Add("@PANno", SqlDbType.VarChar).Value = txtPANNumber.Text.Trim();
                da.Parameters.Add("@NameasperPAN", SqlDbType.VarChar).Value = txtNamePerPAN.Text.Trim();
                da.Parameters.Add("@DOBorDOI", SqlDbType.VarChar).Value = formattedDate.Trim();
                da.Parameters.Add("@Valid", SqlDbType.Int, 500);
                da.Parameters["@Valid"].Direction = ParameterDirection.Output;
                da.ExecuteNonQuery();
                valid = (Int32)da.Parameters["@Valid"].Value;
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
            finally
            {
                con.CloseConnection();
            }
        }

    }
}