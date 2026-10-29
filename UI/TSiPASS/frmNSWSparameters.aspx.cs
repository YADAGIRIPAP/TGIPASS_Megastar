using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Configuration;
using System.Security.Cryptography.Pkcs;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Text;

public partial class UI_TSiPASS_frmNSWSparameters : System.Web.UI.Page
{
    string url = "https://ipass.telangana.gov.in/auth/realms/test-nsws/protocol/openid-connect/";
    string accessToken = "";
    DB.DB con = new DB.DB();
    General gen = new General();

    NSWSKeylcoakAttributes objNSWSKeylcoakAttributes = new NSWSKeylcoakAttributes();
    List<CinDataDetails> listCinDataDetails = new List<CinDataDetails>();
    string POSTALSTATE;
    string POSTALDISTRICT;
    string POSTALMANDAL;
    string POSTALVILLAGE;
    string cinaccessToken = "";
    //string url = "http://182.79.115.45:8280/";
    //string url = "http://182.79.115.52:8280/";
    string cinurl = "https://apim.mca.gov.in:8243/";
    comFunctions cmf = new comFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //string userName = Session["username"].ToString();//"SWARNALAMI";
            //string password = Session["password_decrypt"].ToString(); //"Swarnalami@1";

            //string clientId = "token-session";
            //string clientSecret = "DTrdUwO5fEfg3uXS4wb7x4NnvZf5ZW4Q"; // production secret key
            //string domainURL = "https://ipass.telangana.gov.in/auth";
            //string apiUrl = "http://120.138.9.236/NSWSUserCheckAPI/api/TSIPASS/ValidateLogin";
            //string apiUserId = "NSWS_User";
            //string apiUserPassword = "NSWS_User";
            //string realmName = "test-nsws";
            //CreateUser(clientId, clientSecret, userName, password, domainURL, apiUrl, apiUserId, apiUserPassword, realmName);
            BindConstitutionunit();
            ddlcountry_regaddr.SelectedValue = "1";
            Bindcountries_REG();
            //ddlpostalcountry.SelectedValue = "1";

            Bindcountries_POS();
            getstates_reg();
            ddlstate_regaddr.SelectedValue = "31";
            getstates_pos();
            //ddlpostalstate.SelectedValue = "31";

            getdistricts_reg();

            getdistricts_pos();
            FillDetails();
            txtpanno_TextChanged(sender, e);
        }
    }
    void FillDetails()
    {

        DataSet ds = new DataSet();
        try
        {

            DataSet dsemp = new DataSet();

            dsemp = getUnitClosedDet(Session["username"].ToString());

            if (dsemp.Tables[0].Rows.Count > 0 && dsemp.Tables.Count > 0)
            {

                txtfullname.Text = dsemp.Tables[0].Rows[0]["fullname"].ToString();
                txtfullname.Enabled = false;
                txtemail.Text = dsemp.Tables[0].Rows[0]["email"].ToString();
                txtmobilenumber.Text = dsemp.Tables[0].Rows[0]["mobileNumber"].ToString();
                ddlentitytype.SelectedValue = dsemp.Tables[0].Rows[0]["entityType"].ToString();
                txtpan.Text = dsemp.Tables[0].Rows[0]["Pan"].ToString();
                txtpanno.Text = txtpan.Text;
                txtpanno.Enabled = false;
                string text = txtpanno.Text;
                if (text.Length >= 4)
                {
                    string fourthCharacter = text[3].ToString().ToUpper(); // Index 3 is the 4th character
                    if (fourthCharacter == "P")
                    {
                        ddlentitytype.SelectedItem.Text = "Sole Proprietor";
                        cintr.Visible = false;
                    }
                    else if (fourthCharacter == "C")
                    {
                        cintr.Visible = true;
                        ddlentitytype.SelectedItem.Text = "Incorporated Company";
                    }
                    else if (fourthCharacter == "F")
                    {
                        cintr.Visible = true;
                        ddlentitytype.SelectedItem.Text = "Limited Liability Partnership";
                        //cintr.Visible = true;
                    }
                    else if (fourthCharacter == "T")
                    {
                        ddlentitytype.SelectedItem.Text = "Trust";
                        cintr.Visible = false;
                    }
                }
                txtunitname.Text = dsemp.Tables[0].Rows[0]["companyName"].ToString();
                txtFromDate.Text = Convert.ToDateTime(dsemp.Tables[0].Rows[0]["DATEOFBIRTH"]).ToString("dd-MM-yyyy");
                ddlcountry_regaddr.SelectedValue = "1";
                ddlstate_regaddr.SelectedValue = "31";
                ddldistrict_regaddr.SelectedValue = dsemp.Tables[0].Rows[0]["Land_intDistrictid"].ToString();
                ddldistrict_regaddr_SelectedIndexChanged(this, EventArgs.Empty);
                ddlmandal_regaddr.SelectedValue = dsemp.Tables[0].Rows[0]["Land_intMandalid"].ToString();
                ddlmandal_regaddr_SelectedIndexChanged(this, EventArgs.Empty);

                ddlvillage_regaddr.SelectedValue = dsemp.Tables[0].Rows[0]["Land_intVillageid"].ToString();
                txtsyno_regaddr.Text = dsemp.Tables[0].Rows[0]["synos"].ToString();
                txtcity_regaddr.Text = dsemp.Tables[0].Rows[0]["Name_Gramapachayat"].ToString();
                txtpincode_regaddr.Text = dsemp.Tables[0].Rows[0]["Land_Pincode"].ToString();


                ddlpostalcountry.SelectedValue = "1";
                ddlpostalstate.SelectedValue = "31";
                ddlpostaldistrict.SelectedValue = dsemp.Tables[0].Rows[0]["intDistrictid"].ToString();
                ddlpostaldistrict_SelectedIndexChanged(this, EventArgs.Empty);

                ddlpostalmandal.SelectedValue = dsemp.Tables[0].Rows[0]["intMandalid"].ToString();
                ddlpostalmandal_SelectedIndexChanged(this, EventArgs.Empty);

                ddlpostalvillage.SelectedValue = dsemp.Tables[0].Rows[0]["intVillageid"].ToString();
                txtpostalpincode.Text = dsemp.Tables[0].Rows[0]["Pincode"].ToString();
                txtsyno_postaladdr.Text = dsemp.Tables[0].Rows[0]["Door_No"].ToString();
                txtpostalcity.Text = dsemp.Tables[0].Rows[0]["StreetName"].ToString();

                txtcinnumber.Text = dsemp.Tables[0].Rows[0]["cin"].ToString();
                txtnameofunit.Text = dsemp.Tables[0].Rows[0]["nameofunit"].ToString();
                txtcompanyname.Text = dsemp.Tables[0].Rows[0]["companyName"].ToString();
                //txtllpin.Text = dsemp.Tables[0].Rows[0]["llpin"].ToString();
                if (dsemp.Tables[0].Rows[0]["llpin"].ToString() != "" && dsemp.Tables[0].Rows[0]["llpin"].ToString() != null)
                {
                    txtcinnumber.Text = dsemp.Tables[0].Rows[0]["llpin"].ToString();
                }
                ResetFormControl(this);
                nsws.Visible = true;
                btnSearch.Visible = false;
            }
            else
            {
                nsws.Visible = false;
                //BTNSAVE.Visible = true;
            }
            if (dsemp.Tables[1].Rows.Count > 0 && dsemp.Tables.Count > 0)
            {
                grdcindata1.DataSource = dsemp.Tables[1];
                grdcindata1.DataBind();
                grdcindata1.Visible = true;
            }
            if (dsemp.Tables[2].Rows.Count > 0 && dsemp.Tables.Count > 0)
            {
                grdcindata2.DataSource = dsemp.Tables[2];
                grdcindata2.DataBind();
                grdcindata2.Visible = true;
            }


        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
        finally
        {

        }

    }

    public void ResetFormControl(Control parent)
    {
        foreach (Control c in parent.Controls)
        {
            if (c.Controls.Count > 0)
            {
                ResetFormControl(c);
            }
            else
            {
                switch (c.GetType().ToString())
                {
                    //case "System.Web.UI.WebControls.TextBox":
                    //    ((TextBox)c).ReadOnly = true;
                    //    break;
                    case "System.Web.UI.WebControls.TextBox":
                        ((TextBox)c).Enabled = false;
                        break;
                    case "System.Web.UI.WebControls.DropDownList":

                        if (((DropDownList)c).Items.Count > 0)
                        {
                            ((DropDownList)c).Enabled = false;
                        }
                        break;
                    case "System.Web.UI.WebControls.FileUpload":
                        ((FileUpload)c).Enabled = false;
                        break;
                    case "System.Web.UI.WebControls.RadioButtonList":
                        ((RadioButtonList)c).Enabled = false;
                        break;
                }
            }
        }
    }
    public DataSet getUnitClosedDet(string createdby)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("Sp_NSWSparameters_test", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (createdby.Trim() == "" || createdby.Trim() == null || createdby.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@createdby", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@createdby", SqlDbType.VarChar).Value = createdby.ToString();




            da.Fill(ds);
            return ds;


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
    protected void btnclick_Click(object sender, EventArgs e)
    {
        BTNSAVE_Click(sender, e);        
        LogErrorFile.LogData("btnsave");
        CallUATToken();
        LogErrorFile.LogData("UATToken");
        string token = accessToken;
        LogErrorFile.LogData(token);

        Callsession();
        LogErrorFile.LogData("Seesioncreation");
        objNSWSKeylcoakAttributes = GetNSWSKeycloakData(Session["username"].ToString());
        var data = new
        {
            email = objNSWSKeylcoakAttributes.email.Trim(),
            entityType = objNSWSKeylcoakAttributes.entityType,
            pan = objNSWSKeylcoakAttributes.pan,
            cin = objNSWSKeylcoakAttributes.cin,
            companyName = objNSWSKeylcoakAttributes.companyName,
            llpin = objNSWSKeylcoakAttributes.llpin
        };

        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = //SecurityProtocolType.Tls12;
        SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

        //U67190TN2014PTC055555 var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://dev-nsws.investindia.gov.in/auth/realms/madhyam/userOrg/redirect/user/telangana?clientId=portal-dev");
        //var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://dev-nsws.investindia.gov.in/auth/realms/madhyam/userOrg/redirect/user/telanganaTest?clientId=portal-dev");
        var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://www.nsws.gov.in/auth/realms/madhyam/userOrg/redirect/user/telangana?clientId=portal-prod");
        //(HttpWebRequest)WebRequest.Create("https://www.ppe.nsws.gov.in/auth/realms/madhyam/userOrg/redirect/user/telangana?clientId=portal-ppe");PPE
        //("http://dev-nsws.investindia.gov.in/realms/madhyam/userOrg/redirect/user/telangana?clientId=portal-dev");
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Method = "POST";

        //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        //{
        //    string json = "{\"email\":\"mudavathmallesh966@gmail.com\"," +
        //                  "\"entityType\":\"3\"," +
        //                  "\"pan\":\"AHBPV4068M\"," +
        //                   "\"cin\":\"\"," +
        //                   "\"companyName\":\"M/s R.S.R  SHEDS\"}";

        //    streamWriter.Write(json);
        //}
        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
            string json = JsonConvert.SerializeObject(data);
            streamWriter.Write(json);
            LogErrorFile.LogData("jsonRequest" + json);
        }
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
            string url = httpResponse.ResponseUri.ToString();
            LogErrorFile.LogData("jsonResponse" + url);
            Response.Redirect(url);
        }
    }
    public NSWSKeylcoakAttributes GetNSWSKeycloakData(string username)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[Sp_NSWSparameters]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (username.ToString() != "" || username.ToString() != null)
            {
                // da.SelectCommand.Parameters.Add("intUserID", SqlDbType.VarChar).Value = userid;
                da.SelectCommand.Parameters.Add("@createdby", SqlDbType.VarChar).Value = username;
            }

            da.Fill(ds);
            // return ds;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                objNSWSKeylcoakAttributes.cin = ds.Tables[0].Rows[0]["cin"].ToString();
                //RootObject data = new RootObject();

                // Fill in sample data
                //data.cinDto = new CinDto
                //{
                //    cin = ds.Tables[1].Rows[0]["CIN"].ToString(),
                //    companyName = ds.Tables[1].Rows[0]["companyName"].ToString(),
                //    companyStatus = ds.Tables[1].Rows[0]["companyStatus"].ToString(),
                //    email = ds.Tables[1].Rows[0]["emailAddress"].ToString(),
                //    financialAuditStatus = ds.Tables[1].Rows[0][""].ToString(),
                //    financialDetails = new List<FinancialDetail>
                //    {
                //        new FinancialDetail
                //        {
                //            profitLoss = ds.Tables[1].Rows[0][""].ToString(),
                //            turnOver = ds.Tables[1].Rows[0][""].ToString(),
                //            year = ds.Tables[1].Rows[0][""].ToString(),
                //        }
                //    },
                //    incorpdate = ds.Tables[1].Rows[0][""].ToString(),
                //    registeredAddress = ds.Tables[1].Rows[0][""].ToString(),
                //    rocCode = ds.Tables[1].Rows[0][""].ToString(),
                //};

                //data.directorDetailDtos = new List<DirectorDetailDto>
                //{
                //    new DirectorDetailDto
                //    {
                //        directorDetails = new DirectorDetails
                //        {
                //            contactNumber = ds.Tables[1].Rows[0][""].ToString(),
                //            din = ds.Tables[1].Rows[0][""].ToString(),
                //            name = ds.Tables[1].Rows[0][""].ToString(),
                //        },
                //        dinDetail = new DinDetail
                //        {
                //            dinName =ds.Tables[1].Rows[0][""].ToString(),
                //            dinStatus = ds.Tables[1].Rows[0][""].ToString(),
                //            dob =ds.Tables[1].Rows[0][""].ToString(),
                //            fatherName =ds.Tables[1].Rows[0][""].ToString()
                //        }
                //    }
                //};

                //// Convert object to JSON
                //string json = Newtonsoft.Json.JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);


                //            data.cinDto = new CinDto
                //            {
                //                cin = "L72200KA1999PLC025564",
                //                companyName = "MINDTREE LIMITED",
                //                companyStatus = "Active",
                //                email = "Subhodh.Shetty@mindtree.com",
                //                financialAuditStatus = "YES",
                //                financialDetails = new List<FinancialDetail>
                //    {
                //        new FinancialDetail
                //        {
                //            profitLoss = "11103000000.00",
                //            turnOver = "79678000000.00",
                //            year = "2021"
                //        }
                //    },
                //                incorpdate = "05/08/1999",
                //                registeredAddress = "Global Village,RVCE Post, Mysore Road BANGALORE KA 560059 IN",
                //                rocCode = "RoC-Bangalore"
                //            };

                //            data.directorDetailDtos = new List<DirectorDetailDto>
                //{
                //    new DirectorDetailDto
                //    {
                //        directorDetails = new DirectorDetails
                //        {
                //            contactNumber = "",
                //            din = "0000190097",
                //            name = "APURVA PUROHIT"
                //        },
                //        dinDetail = new DinDetail
                //        {
                //            dinName = "APURVA PUROHIT",
                //            dinStatus = "Approved",
                //            dob = "03-10-1966",
                //            fatherName = "YOGI KANWAR"
                //        }
                //    }
                //};
                //            string json = Newtonsoft.Json.JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
                //            objNSWSKeylcoakAttributes.cinData = json;
                objNSWSKeylcoakAttributes.cinData = "";
                objNSWSKeylcoakAttributes.companyName = ds.Tables[0].Rows[0]["companyName"].ToString();
                objNSWSKeylcoakAttributes.email = ds.Tables[0].Rows[0]["email"].ToString();
                objNSWSKeylcoakAttributes.entityType = ds.Tables[0].Rows[0]["entityType"].ToString();
                objNSWSKeylcoakAttributes.fullName = ds.Tables[0].Rows[0]["fullname"].ToString();
                objNSWSKeylcoakAttributes.llpin = ds.Tables[0].Rows[0]["llpin"].ToString();
                objNSWSKeylcoakAttributes.mobileNumber = ds.Tables[0].Rows[0]["mobileNumber"].ToString();
                objNSWSKeylcoakAttributes.pan = ds.Tables[0].Rows[0]["Pan"].ToString();
                objNSWSKeylcoakAttributes.postalAddress1 = ds.Tables[0].Rows[0]["postalAddress1"].ToString();
                objNSWSKeylcoakAttributes.postalAddress2 = ds.Tables[0].Rows[0]["postalAddress2"].ToString();
                objNSWSKeylcoakAttributes.postalCity = ds.Tables[0].Rows[0]["postalCity"].ToString();
                objNSWSKeylcoakAttributes.postalCountry = ds.Tables[0].Rows[0]["postalCountry"].ToString();
                objNSWSKeylcoakAttributes.postalPincode = ds.Tables[0].Rows[0]["postalPincode"].ToString();
                objNSWSKeylcoakAttributes.postalState = ds.Tables[0].Rows[0]["postalState"].ToString();
                objNSWSKeylcoakAttributes.regAddress1 = ds.Tables[0].Rows[0]["regAddress1"].ToString();
                objNSWSKeylcoakAttributes.regAddress2 = ds.Tables[0].Rows[0]["regAddress2"].ToString();
                objNSWSKeylcoakAttributes.regCity = ds.Tables[0].Rows[0]["regCity"].ToString();
                objNSWSKeylcoakAttributes.regCountry = ds.Tables[0].Rows[0]["regCountry"].ToString();
                objNSWSKeylcoakAttributes.regPincode = ds.Tables[0].Rows[0]["regPincode"].ToString();
                objNSWSKeylcoakAttributes.regState = ds.Tables[0].Rows[0]["regState"].ToString();


            }
            return objNSWSKeylcoakAttributes;
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
    private void CallUATToken()
    {
        try
        {
            //string clientId = "your_client_id";
            // string clientSecret = "your_client_secret";
            string apiUrl = url + "token";

            using (var client = new HttpClient())
            {
                //var collection = new List<KeyValuePair<string, string>>();
                //collection.Add(new("client_id", "userpri-client"));
                //collection.Add(new("client_secret", "WpyXnvLMdG0amzfPCFxlK1S33DqWQYEw"));
                //collection.Add(new("grant_type", "password"));
                //collection.Add(new("username", "testpolice"));
                //collection.Add(new("password", "TSIPASS123"));
                //var content = new FormUrlEncodedContent(collection); 9shj3Uk4gtRyXJ7OzeSclQsSoXBnCNQL
                //request.Content = content; zDl3Er12C3vLvdU2LA4kBaPxuSIYQJO2

                var postData = new List<KeyValuePair<string, string>>();
                //postData.Add(new KeyValuePair<string, string>("client_id", "userpri-client"));
                postData.Add(new KeyValuePair<string, string>("client_id", "token-session"));
                postData.Add(new KeyValuePair<string, string>("client_secret", "DTrdUwO5fEfg3uXS4wb7x4NnvZf5ZW4Q"));
                postData.Add(new KeyValuePair<string, string>("grant_type", "password"));
                postData.Add(new KeyValuePair<string, string>("username", Session["username"].ToString()));
               // postData.Add(new KeyValuePair<string, string>("password", Session["password_decrypt"].ToString()));
                postData.Add(new KeyValuePair<string, string>
                    ("password", gen.Decrypt(Session["password"].ToString(), "SYSTIME").Trim()));

                                var content = new FormUrlEncodedContent(postData);
                LogErrorFile.LogData(content.ToString());
                var response = client.PostAsync(apiUrl, content).Result;
                LogErrorFile.LogData(response.ToString());
                var result = response.Content.ReadAsStringAsync().Result;
                dynamic json = JsonConvert.DeserializeObject(result);
                LogErrorFile.LogData(result.ToString());
                accessToken = json.access_token;
                LogErrorFile.LogData("1");
                LogErrorFile.LogData(accessToken);
                // Store or use the access token as needed
            }
        }
        catch (Exception ex)
        {
            // GetCINResponse(ex.ToString());
            LogErrorFile.LogData("errortoken" + ex.ToString());
        }
    }

    private void Callsession()
    {
        //string apiUrl = "http://103.154.75.191:8080/realms/TSIPASS_NSWS/browser-session/init?publicClient=newTest"; // Replace this with your API endpoint URL
        //string apiUrl = "https://ipass.telangana.gov.in/auth/realms/TSIPASS_NSWS/browser-session/init?publicClient=newTest"; // Replace this with your API endpoint URL
        string apiUrl = "https://ipass.telangana.gov.in/auth/realms/test-nsws/browser-session/init?publicClient=open-session";
        string bearerToken = accessToken; // Replace this with your bearer token

        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Method = "GET"; // Set HTTP method (GET, POST, etc.)

            // Set bearer token in the Authorization header
            request.Headers["Authorization"] = "Bearer " + bearerToken;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream dataStream = response.GetResponseStream())
                {
                    var cookies = response.Headers.GetValues("Set-Cookie");
                    //// Process each cookie if needed
                    //foreach (var cookie in cookies)
                    //{
                    //    setcookies(cookie);
                    //}
                    string[] setCookieValues = response.Headers.GetValues("Set-Cookie");

                    // Loop through each value in the setCookieValues array
                    foreach (string setCookieValue in setCookieValues)
                    {
                        // Parse the Set-Cookie value to extract cookie name and value
                        string[] parts = setCookieValue.Split(';');
                        string cookieKeyValue = parts[0];
                        string[] keyValue = cookieKeyValue.Split('=');
                        string cookieName = keyValue[0];
                        string cookieValue = keyValue[1];

                        // Check if the cookie already exists
                        if (Request.Cookies[cookieName] != null)
                        {
                            // If the cookie exists, update its value
                            HttpCookie existingCookie = Request.Cookies[cookieName];
                            existingCookie.Value = cookieValue;

                            // Optionally, update other properties such as expiration date
                            existingCookie.Expires = DateTime.Now.AddDays(1);

                            // Add the updated cookie back to the response
                            Response.Cookies.Add(existingCookie);
                        }
                        else
                        {
                            // If the cookie doesn't exist, create a new one
                            HttpCookie newCookie = new HttpCookie(cookieName);
                            newCookie.Value = cookieValue;

                            // Optionally, set other properties such as expiration date
                            newCookie.Expires = DateTime.Now.AddDays(1);

                            // Add the new cookie to the response
                            Response.Cookies.Add(newCookie);
                        }
                    }
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    Console.WriteLine("Response:");
                    Console.WriteLine(responseFromServer);
                    LogErrorFile.LogData("responseFromServer");

                    LogErrorFile.LogData(responseFromServer);
                }
            }
        }
        catch (WebException ex)
        {
            // Handle web exceptions
            if (ex.Response != null)
            {
                using (WebResponse errorResponse = ex.Response)
                {
                    using (Stream dataStream = errorResponse.GetResponseStream())
                    {

                        StreamReader reader = new StreamReader(dataStream);
                        string errorFromServer = reader.ReadToEnd();
                        LogErrorFile.LogData("Success" + errorFromServer);
                    }
                }
            }
            else
            {
                LogErrorFile.LogData("errortoken" + ex.ToString());
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogData("errortoken" + ex.ToString());
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string FromdateforDB = "", TodateforDB = "";
        DateTime parsedDate = DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null);

        // Format the DateTime object to the desired format
        string formattedDate = parsedDate.ToString("dd/MM/yyyy");
        formattedDate = formattedDate.Replace(@"-", "/");
        string valid = ValidatePan(txtpanno.Text.Trim(), txtunitname.Text.Trim(), formattedDate);
        lblpanstatus.Text = valid;
        if (lblpanstatus.Text.Trim() == "E")
        {

            string text = txtpanno.Text;
            if (text.Length >= 4)
            {
                string fourthCharacter = text[3].ToString().ToUpper(); // Index 3 is the 4th character
                if (fourthCharacter == "C")
                {
                    ddlentitytype.SelectedItem.Text = "Incorporated Company";
                    cintr.Visible = true;
                    if (txtcinnumber.Text != "")
                    {
                        txtcinnumber_TextChanged(sender, e);
                    }
                }
                else if (fourthCharacter == "F")
                {
                    ddlentitytype.SelectedItem.Text = "Limited Liability Partnership";
                    cintr.Visible = true;
                    if (txtcinnumber.Text != "")
                    {
                        txtcinnumber_TextChanged(sender, e);
                    }
                }
                else
                {
                    nsws.Visible = true;
                    cintr.Visible = false;
                    lblmsg0.Visible = false;
                    Failure.Visible = false;
                }
            }
        }
        else
        {
            lblmsg0.Visible = true;
            lblmsg0.Text = "Please enter Correct PAN Details";
            Failure.Visible = true;
            nsws.Visible = false;
        }
    }
    static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        // Implement your certificate validation logic here
        // For example, you might check the certificate issuer, validity period, etc.
        // Return true if the certificate is considered valid, false otherwise

        // For simplicity, always return true (accept all certificates)
        return true;
    }
    public static byte[] Sign(byte[] data, X509Certificate2 certificate)
    {
        if (data == null)
            throw new ArgumentException("data");
        if (certificate == null)
            throw new ArgumentException("certificate");

        ContentInfo content = new ContentInfo(data);
        SignedCms signedcms = new SignedCms(content, false);
        CmsSigner signer = new CmsSigner(SubjectIdentifierType.IssuerAndSerialNumber, certificate);
        signedcms.ComputeSignature(signer);
        return signedcms.Encode();
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
    public string ValidatePan(string panno, string name, string DOB)
    {
        string valid = "";
        try
        {
            //string url = Convert.ToString(ConfigurationManager.AppSettings["PANURL"]);
            //string password = Convert.ToString(ConfigurationManager.AppSettings["PANFXPassword"]);
            //string certificate = Convert.ToString(ConfigurationManager.AppSettings["PANCertificatename"]);
            //string userid = Convert.ToString(ConfigurationManager.AppSettings["PANUserid"]);

            string url = Convert.ToString(ConfigurationManager.AppSettings["PANURLLIVE"]);
            string password = Convert.ToString(ConfigurationManager.AppSettings["PANFXPasswordLIVE"]);
            string certificate = Convert.ToString(ConfigurationManager.AppSettings["PANCertificatenameLIVE"]);
            string userid = Convert.ToString(ConfigurationManager.AppSettings["PANUseridLIVE"]);

            //string pan = panno;
            //string name = name;
            //string fathername = "";
            //string dob = DOB; //"22/05/1984";
            string record_count = "1";
            try
            {

                GetPANRequest("url: " + url + " passowrd: " + password + " certificatepath: " + certificate + " userid: " + userid);
            }
            catch (Exception ex)
            {

            }
            PanInquiryRequestData inputdatum = new PanInquiryRequestData();
            List<PanInquiryRequestData> input = new List<PanInquiryRequestData>();

            var Mypanbody = (dynamic)null;
            inputdatum.pan = panno;
            inputdatum.name = name;
            inputdatum.fathername = "";
            inputdatum.dob = DOB;
            input.Add(inputdatum);
            Mypanbody = JsonConvert.SerializeObject(input);
            try
            {

                GetPANRequest("Mypanbody" + Mypanbody);
            }
            catch (Exception ex)
            {

            }
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            try
            {

                GetPANRequest("Madhuri" + Mypanbody);
            }
            catch (Exception ex)
            {

            }
            // X509Certificate2 m = new X509Certificate2(certificate, password);
            var m = new X509Certificate2(certificate, password, X509KeyStorageFlags.MachineKeySet);
            try
            {

                GetPANRequest("Madhuri1" + Mypanbody);
            }
            catch (Exception ex)
            {

            }
            GetPANRequest("Byte" + "certificate " + certificate + "password" + password + Mypanbody);
            byte[] bytes = encoding.GetBytes(Mypanbody);
            try
            {
                GetPANRequest("Byte"+"certificate "+certificate+ "password"+ password + Mypanbody);
            }
            catch (Exception ex)
            {

            }
            byte[] sig = Sign(bytes, m);
            String sigi = Convert.ToBase64String(sig);
            hdnPanSignature.Value = sigi;

            try
            {
                GetPANRequest("sig" + sig);
                //GetPANRequest("sigi" + hdnPanSignature.Value);
                GetPANRequest("sigi" + hdnPanSignature.Value);
            }
            catch (Exception ex)
            {

            }

            //HttpWebRequest myrequest = (HttpWebRequest)WebRequest.Create(url);

            DateTime currentDateTime = DateTime.Now;
            string formattedDateTime = currentDateTime.ToString("yyyy-MM-ddTHH:mm:ss");
            formattedDateTime = formattedDateTime.Replace(@"/", "-");
            string Transactional_id = formattedDateTime.Replace("-", "");
            //myrequest.Headers.Add("User_ID", userid);
            //myrequest.Headers.Add("Records_count", record_count);
            //myrequest.Headers.Add("Request_time", formattedDateTime);
            //myrequest.Headers.Add("Transaction_ID", userid + ":" + Transactional_id);
            //myrequest.Headers.Add("Version", "4");
            //myrequest.ContentType = "application / json";
            //myrequest.Method = "POST";

            PanRx ip = new PanRx();
            ip.inputData = input;
            ip.signature = sigi;

            string json = new JavaScriptSerializer().Serialize(ip);
            try
            {

                GetPANRequest("SignData"+json);
            }
            catch (Exception ex)
            {

            }
            using (WebClient wc = new WebClient())
            {
                // ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(true);
                ServicePointManager.ServerCertificateValidationCallback += ValidateServerCertificate;
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | (SecurityProtocolType)(0xc00) | SecurityProtocolType.Ssl3;
                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                wc.Headers.Add("User_ID", userid);
                wc.Headers.Add("Records_count", record_count);
                wc.Headers.Add("Request_time", formattedDateTime);
                wc.Headers.Add("Transaction_ID", userid + ":" + Transactional_id);
                wc.Headers.Add("Version", "4");

                var output = wc.UploadString(url, json);
                GetPANResponse(output);
                LogErrorFile.LogData(Convert.ToString("PAN Status:" + output));

                RootOutput root = JsonConvert.DeserializeObject<RootOutput>(output);

                // Access the pan_status from the first element in the OutputData list
                //if (root != null && root.OutputData != null && root.OutputData.Count > 0)
                //{
                //    if (root.OutputData[0].Pan_status == "E" &&
                //      root.OutputData[1].Name == "Y" && root.OutputData[3].Dob == "Y")
                //    {
                //        valid = "E";
                //        GetPANResponse(valid);
                //    }
                //    Console.WriteLine("PAN Status: " + valid);
                //}
                foreach (var item in root.OutputData)
                {
                    LogErrorFile.LogData(Convert.ToString("PAN Status:"+ item.Pan_status));
                    if (item.Pan_status == "E" && item.Name == "Y" && item.Dob == "Y")
                    {
                        valid = "E";
                        GetPANResponse(valid);
                    }
                    else
                    {
                        valid = "N";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            GetPANResponse(ex.Message);
        }
        return valid;
    }
    protected void BTNSAVE_Click(object sender, EventArgs e)
    {

        if (ddlpostalcountry.SelectedValue == "1")
        {
            if (ddlpostalstate.SelectedValue == "31")
            {
                POSTALSTATE = ddlpostalstate.SelectedItem.Text.Trim();
                POSTALDISTRICT = ddlpostaldistrict.SelectedItem.Text.Trim();
                POSTALMANDAL = ddlpostalmandal.SelectedItem.Text.Trim();
                POSTALVILLAGE = ddlpostalvillage.SelectedItem.Text.Trim();
            }
            else
            {
                POSTALDISTRICT = txtpostaldistrict.Text.Trim();
                POSTALMANDAL = txtpostalmandal.Text.Trim();
                POSTALVILLAGE = txtpostalvillage.Text.Trim();
            }
        }
        else
        {
            POSTALSTATE = txtpostalstate.Text.Trim();
            POSTALDISTRICT = txtpostaldistrict.Text.Trim();
            POSTALMANDAL = txtpostalmandal.Text.Trim();
            POSTALVILLAGE = txtpostalvillage.Text.Trim();
        }
        string cinno = "", llpno = "";
        string text = txtpanno.Text;
        if (text.Length >= 4)
        {
            string fourthCharacter = text[3].ToString().ToUpper(); // Index 3 is the 4th character
            if (fourthCharacter == "P")
            {
                ddlentitytype.SelectedItem.Text = "Sole Proprietor";
                cintr.Visible = false;
            }
            else if (fourthCharacter == "C")
            {
                cintr.Visible = true;
                ddlentitytype.SelectedItem.Text = "Incorporated Company";
                cinno = txtcinnumber.Text.Trim();
            }
            else if (fourthCharacter == "F")
            {
                cintr.Visible = true;
                ddlentitytype.SelectedItem.Text = "Limited Liability Partnership";
                llpno = txtcinnumber.Text.Trim();
                //cintr.Visible = true;
            }
            else if (fourthCharacter == "T")
            {
                ddlentitytype.SelectedItem.Text = "Trust";
                cintr.Visible = false;
            }
        }
        DataSet ds = new DataSet();
        ds = InsertNSWSParameters(txtfullname.Text.Trim(), txtemail.Text.Trim(),
            txtmobilenumber.Text.Trim(), ddlentitytype.SelectedValue.Trim(),
            txtpan.Text.Trim(), ddlcountry_regaddr.SelectedItem.Text.Trim(),
            ddlstate_regaddr.SelectedItem.Text.Trim(), ddldistrict_regaddr.SelectedItem.Text.Trim(),
            ddlmandal_regaddr.SelectedItem.Text.Trim(), ddlvillage_regaddr.SelectedItem.Text.Trim(),
            txtsyno_regaddr.Text.Trim(), txtpincode_regaddr.Text.Trim(), txtcity_regaddr.Text.Trim(),
            cinno.Trim(), txtnameofunit.Text.Trim(), txtunitname.Text.Trim(), llpno.Trim(),

            ddlpostalcountry.SelectedItem.Text.Trim(),
            POSTALSTATE, POSTALDISTRICT,
            POSTALMANDAL, POSTALVILLAGE,
            txtsyno_postaladdr.Text.Trim(), txtpostalpincode.Text.Trim(), txtpostalcity.Text.Trim(),
            txtFromDate.Text.Trim(), Session["uid"].ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {
            string userName = Session["username"].ToString();//"SWARNALAMI";
            string password = Session["password_decrypt"].ToString(); //"Swarnalami@1";

            string clientId = "token-session";
            string clientSecret = "DTrdUwO5fEfg3uXS4wb7x4NnvZf5ZW4Q"; // production secret key
            string domainURL = "https://ipass.telangana.gov.in/auth";
            string apiUrl = "http://120.138.9.236/NSWSUserCheckAPI/api/TSIPASS/ValidateLogin";
            string apiUserId = "NSWS_User";
            string apiUserPassword = "NSWS_User";
            string realmName = "test-nsws";
            CreateUser(clientId, clientSecret, userName, password, domainURL, apiUrl, apiUserId, apiUserPassword, realmName);

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
            //BtnSave.Enabled = false;
            return;
        }
    }
    public DataSet InsertNSWSParameters(string txtfullname, string txtemail, string txtmobilenumber, string ddlentitytype,
           string txtpan, string ddlcountry_regaddr, string ddlstate_regaddr, string ddldistrict_regaddr,
           string ddlmandal_regaddr, string ddlvillage_regaddr, string txtsyno_regaddr, string txtpincode_regaddr, string txtcity_regaddr,
           string txtcinnumber, string txtnameofunit, string txtcompanyname, string txtllpin, string ddlpostalcountry,
           string ddlpostalstate, string ddlpostaldistrict, string ddlpostalmandal, string ddlpostalvillage,
           string txtsyno_postaladdr, string txtpostalpincode, string txtpostalcity, string txtFromDate, string createdby)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_INSERTNSWSPARAMETERS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@fullname", SqlDbType.VarChar).Value = txtfullname.ToString();
            da.SelectCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = txtemail.ToString();
            da.SelectCommand.Parameters.Add("@mobileNumber", SqlDbType.VarChar).Value = txtmobilenumber.ToString();
            da.SelectCommand.Parameters.Add("@entityType", SqlDbType.VarChar).Value = ddlentitytype.ToString();
            da.SelectCommand.Parameters.Add("@Pan", SqlDbType.VarChar).Value = txtpan.ToString();
            da.SelectCommand.Parameters.Add("@country_reg", SqlDbType.VarChar).Value = ddlcountry_regaddr.ToString();
            da.SelectCommand.Parameters.Add("@state_reg", SqlDbType.VarChar).Value = ddlstate_regaddr.ToString();
            da.SelectCommand.Parameters.Add("@district_reg", SqlDbType.VarChar).Value = ddldistrict_regaddr.ToString();
            da.SelectCommand.Parameters.Add("@mandal_reg", SqlDbType.VarChar).Value = ddlmandal_regaddr.ToString();
            da.SelectCommand.Parameters.Add("@village_reg", SqlDbType.VarChar).Value = ddlvillage_regaddr.ToString();
            da.SelectCommand.Parameters.Add("@regCity", SqlDbType.VarChar).Value = txtcity_regaddr.ToString();
            da.SelectCommand.Parameters.Add("@regPincode", SqlDbType.VarChar).Value = txtpincode_regaddr.ToString();
            da.SelectCommand.Parameters.Add("@regaddsyno", SqlDbType.VarChar).Value = txtsyno_regaddr.ToString();
            da.SelectCommand.Parameters.Add("@country_postal", SqlDbType.VarChar).Value = ddlpostalcountry.ToString();
            da.SelectCommand.Parameters.Add("@state_postal", SqlDbType.VarChar).Value = ddlpostalstate.ToString();
            da.SelectCommand.Parameters.Add("@district_postal", SqlDbType.VarChar).Value = ddlpostaldistrict.ToString();
            da.SelectCommand.Parameters.Add("@mandal_postal", SqlDbType.VarChar).Value = ddlpostalmandal.ToString();
            da.SelectCommand.Parameters.Add("@village_postal", SqlDbType.VarChar).Value = ddlpostalvillage.ToString();
            da.SelectCommand.Parameters.Add("@postalPincode", SqlDbType.VarChar).Value = txtpostalpincode.ToString();
            da.SelectCommand.Parameters.Add("@postalCity", SqlDbType.VarChar).Value = txtpostalcity.ToString();
            da.SelectCommand.Parameters.Add("@postaladdsyno", SqlDbType.VarChar).Value = txtsyno_postaladdr.ToString();
            da.SelectCommand.Parameters.Add("@cin", SqlDbType.VarChar).Value = txtcinnumber.ToString();
            da.SelectCommand.Parameters.Add("@nameofunit", SqlDbType.VarChar).Value = txtnameofunit.ToString();
            da.SelectCommand.Parameters.Add("@companyName", SqlDbType.VarChar).Value = txtcompanyname.ToString();
            da.SelectCommand.Parameters.Add("@llpin", SqlDbType.VarChar).Value = txtllpin.ToString();
            if (txtFromDate.ToString().Trim() == "" || txtFromDate.ToString().Trim() == null || txtFromDate.ToString().Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@DATEOFBIRTH", SqlDbType.DateTime).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@DATEOFBIRTH", SqlDbType.DateTime).Value = cmf.convertDateIndia(txtFromDate.Trim());
            //da.SelectCommand.Parameters.Add("@DATEOFBIRTH", SqlDbType.VarChar).Value =Convert.ToDateTime( txtFromDate.ToString());
            da.SelectCommand.Parameters.Add("@CREATED_BY", SqlDbType.VarChar).Value = Convert.ToInt32(createdby);




            da.Fill(ds);
            return ds;


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


    protected void ddldistrict_regaddr_SelectedIndexChanged(object sender, EventArgs e)
    {

        DataSet ds = new DataSet();
        ds = getmandals_REGADD(ddldistrict_regaddr.SelectedValue);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlmandal_regaddr.DataSource = ds.Tables[0];
            ddlmandal_regaddr.DataTextField = "Manda_lName";
            ddlmandal_regaddr.DataValueField = "Mandal_Id";
            ddlmandal_regaddr.DataBind();
            ddlmandal_regaddr.Items.Insert(0, "--Select--");

        }



    }
    protected void ddlpostaldistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds = getmandals_POSTALADD(ddlpostaldistrict.SelectedValue);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlpostalmandal.DataSource = ds.Tables[0];
            ddlpostalmandal.DataTextField = "Manda_lName";
            ddlpostalmandal.DataValueField = "Mandal_Id";
            ddlpostalmandal.DataBind();
            ddlpostalmandal.Items.Insert(0, "--Select--");
        }
    }
    public DataSet getmandals_REGADD(string districtid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GETMANDALS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (districtid.Trim() == "" || districtid.Trim() == null)
                da.SelectCommand.Parameters.Add("@districtid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@districtid", SqlDbType.VarChar).Value = districtid.ToString();

            da.Fill(ds);
            return ds;


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
    public DataSet getmandals_POSTALADD(string districtid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GETMANDALS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (districtid.Trim() == "" || districtid.Trim() == null)
                da.SelectCommand.Parameters.Add("@districtid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@districtid", SqlDbType.VarChar).Value = districtid.ToString();

            da.Fill(ds);
            return ds;


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
    protected void ddlmandal_regaddr_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds = GETVILLAGES_REGADD(ddlmandal_regaddr.SelectedValue);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlvillage_regaddr.DataSource = ds.Tables[0];
            ddlvillage_regaddr.DataTextField = "Village_Name";
            ddlvillage_regaddr.DataValueField = "Village_Id";
            ddlvillage_regaddr.DataBind();
            ddlvillage_regaddr.Items.Insert(0, "--Select--");
        }
    }
    protected void ddlpostalmandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds = GETVILLAGES_POSADD(ddlpostalmandal.SelectedValue);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlpostalvillage.DataSource = ds.Tables[0];
            ddlpostalvillage.DataTextField = "Village_Name";
            ddlpostalvillage.DataValueField = "Village_Id";
            ddlpostalvillage.DataBind();
            ddlpostalvillage.Items.Insert(0, "--Select--");
        }
    }
    public DataSet GETVILLAGES_REGADD(string MANDALID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GETVILLAGES", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (MANDALID.Trim() == "" || MANDALID.Trim() == null)
                da.SelectCommand.Parameters.Add("@MANDALID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@MANDALID", SqlDbType.VarChar).Value = MANDALID.ToString();
            da.Fill(ds);
            return ds;


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
    public DataSet GETVILLAGES_POSADD(string MANDALID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GETVILLAGES", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (MANDALID.Trim() == "" || MANDALID.Trim() == null)
                da.SelectCommand.Parameters.Add("@MANDALID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@MANDALID", SqlDbType.VarChar).Value = MANDALID.ToString();
            da.Fill(ds);
            return ds;


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
    protected void ddlpostalcountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlpostalstate.ClearSelection();
        ddlpostaldistrict.ClearSelection();
        ddlpostalmandal.ClearSelection();
        ddlpostalvillage.ClearSelection();
        txtpostalstate.Text = "";
        txtpostaldistrict.Text = "";
        txtpostalmandal.Text = "";
        txtpostalvillage.Text = "";
        if (ddlpostalcountry.SelectedValue == "1")
        {
            ddlpostalstate.ClearSelection();
            ddlpostaldistrict.ClearSelection();
            ddlpostalmandal.ClearSelection();
            ddlpostalvillage.ClearSelection();

            ddlpostalstate.Visible = true;
            ddlpostaldistrict.Visible = true;
            ddlpostalmandal.Visible = true;
            ddlpostalvillage.Visible = true;

            txtpostalstate.Visible = false;
            txtpostaldistrict.Visible = false;
            txtpostalmandal.Visible = false;
            txtpostalvillage.Visible = false;
        }
        else
        {
            txtpostalstate.Text = "";
            txtpostaldistrict.Text = "";
            txtpostalmandal.Text = "";
            txtpostalvillage.Text = "";

            ddlpostalstate.Visible = false;
            ddlpostaldistrict.Visible = false;
            ddlpostalmandal.Visible = false;
            ddlpostalvillage.Visible = false;

            txtpostalstate.Visible = true;
            txtpostaldistrict.Visible = true;
            txtpostalmandal.Visible = true;
            txtpostalvillage.Visible = true;
        }
    }
    protected void ddlpostalstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlpostaldistrict.ClearSelection();
        ddlpostalmandal.ClearSelection();
        ddlpostalvillage.ClearSelection();
        txtpostaldistrict.Text = "";
        txtpostalmandal.Text = "";
        txtpostalvillage.Text = "";
        if (ddlpostalstate.SelectedValue == "31")
        {
            ddlpostaldistrict.ClearSelection();
            ddlpostalmandal.ClearSelection();
            ddlpostalvillage.ClearSelection();

            ddlpostaldistrict.Visible = true;
            ddlpostalmandal.Visible = true;
            ddlpostalvillage.Visible = true;


            txtpostaldistrict.Visible = false;
            txtpostalmandal.Visible = false;
            txtpostalvillage.Visible = false;
        }
        else
        {
            txtpostaldistrict.Text = "";
            txtpostalmandal.Text = "";
            txtpostalvillage.Text = "";
            ddlpostaldistrict.Visible = false;
            ddlpostalmandal.Visible = false;
            ddlpostalvillage.Visible = false;


            txtpostaldistrict.Visible = true;
            txtpostalmandal.Visible = true;
            txtpostalvillage.Visible = true;
        }
    }
    public void BindConstitutionunit()
    {
        try
        {
            ddlentitytype.Items.Clear();
            DataSet dsConstofunit = new DataSet();
            dsConstofunit = GetConstitutionunit();
            if (dsConstofunit != null && dsConstofunit.Tables.Count > 0 && dsConstofunit.Tables[0].Rows.Count > 0)
            {
                ddlentitytype.DataSource = dsConstofunit.Tables[0];
                ddlentitytype.DataTextField = "Nsws_Entity_Type_Name";
                ddlentitytype.DataValueField = "Nsws_Entity_Type";
                ddlentitytype.DataBind();
                AddSelect(ddlentitytype);
            }
            else
            {
                ddlentitytype.Items.Clear();
                AddSelect(ddlentitytype);
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    public DataSet GetConstitutionunit()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GETCONSTITUTIONUNIT_NSWS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(ds);
            return ds;
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
    public void Bindcountries_REG()
    {
        try
        {
            ddlcountry_regaddr.Items.Clear();
            DataSet DSREGCOUNTRY = new DataSet();
            DSREGCOUNTRY = Getcountries_REGADD();
            if (DSREGCOUNTRY != null && DSREGCOUNTRY.Tables.Count > 0 && DSREGCOUNTRY.Tables[0].Rows.Count > 0)
            {
                ddlcountry_regaddr.DataSource = DSREGCOUNTRY.Tables[0];
                ddlcountry_regaddr.DataTextField = "CountryName";
                ddlcountry_regaddr.DataValueField = "Countryid";
                ddlcountry_regaddr.DataBind();
                AddSelect(ddlcountry_regaddr);
            }
            else
            {
                ddlcountry_regaddr.Items.Clear();
                AddSelect(ddlcountry_regaddr);
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    public void Bindcountries_POS()
    {
        try
        {
            ddlpostalcountry.Items.Clear();
            DataSet DSPOSTCOUN = new DataSet();
            DSPOSTCOUN = Getcountries_POSADD();
            if (DSPOSTCOUN != null && DSPOSTCOUN.Tables.Count > 0 && DSPOSTCOUN.Tables[0].Rows.Count > 0)
            {
                ddlpostalcountry.DataSource = DSPOSTCOUN.Tables[0];
                ddlpostalcountry.DataTextField = "CountryName";
                ddlpostalcountry.DataValueField = "Countryid";
                ddlpostalcountry.DataBind();
                AddSelect(ddlpostalcountry);
            }
            else
            {
                ddlpostalcountry.Items.Clear();
                AddSelect(ddlpostalcountry);
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    public DataSet Getcountries_REGADD()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GETCOUNTRIES", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(ds);
            return ds;
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
    public DataSet Getcountries_POSADD()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GETCOUNTRIES", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(ds);
            return ds;
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
    void getstates_reg()
    {
        DataSet ds = new DataSet();
        ds = getstates_REGADD();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlstate_regaddr.DataSource = ds.Tables[0];
            ddlstate_regaddr.DataTextField = "State_Name";
            ddlstate_regaddr.DataValueField = "State_id";
            ddlstate_regaddr.DataBind();
            ddlstate_regaddr.Items.Insert(0, "--Select--");
        }

    }
    void getstates_pos()
    {
        DataSet ds = new DataSet();
        ds = getstates_POSADD();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlpostalstate.DataSource = ds.Tables[0];
            ddlpostalstate.DataTextField = "State_Name";
            ddlpostalstate.DataValueField = "State_id";
            ddlpostalstate.DataBind();
            ddlpostalstate.Items.Insert(0, "--Select--");
        }

    }
    public DataSet getstates_REGADD()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("getstates", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            da.Fill(ds);
            return ds;


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
    public DataSet getstates_POSADD()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("getstates", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            da.Fill(ds);
            return ds;


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
    void getdistricts_reg()
    {
        DataSet ds = new DataSet();
        ds = getdistricts_REGADD();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddldistrict_regaddr.DataSource = ds.Tables[0];
            ddldistrict_regaddr.DataTextField = "District_Name";
            ddldistrict_regaddr.DataValueField = "District_Id";
            ddldistrict_regaddr.DataBind();
            ddldistrict_regaddr.Items.Insert(0, "--Select--");
        }

    }
    void getdistricts_pos()
    {
        DataSet ds = new DataSet();
        ds = getdistricts_POSADD();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlpostaldistrict.DataSource = ds.Tables[0];
            ddlpostaldistrict.DataTextField = "District_Name";
            ddlpostaldistrict.DataValueField = "District_Id";
            ddlpostaldistrict.DataBind();
            ddlpostaldistrict.Items.Insert(0, "--Select--");

        }
    }
    public DataSet getdistricts_REGADD()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GETDISTRICTS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            da.Fill(ds);
            return ds;


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
    public DataSet getdistricts_POSADD()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GETDISTRICTS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            da.Fill(ds);
            return ds;


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
    public void AddSelect(DropDownList ddl)
    {
        try
        {
            ListItem li = new ListItem();
            li.Text = "--Select--";
            li.Value = "0";
            ddl.Items.Insert(0, li);
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }
    protected void txtpanno_TextChanged(object sender, EventArgs e)
    {
        string text = txtpanno.Text;
        if (text.Length >= 4)
        {
            string fourthCharacter = text[3].ToString().ToUpper(); // Index 3 is the 4th character
            if (fourthCharacter == "P")
            {
                ddlentitytype.SelectedItem.Text = "Sole Proprietor";
                cintr.Visible = false;
            }
            else if (fourthCharacter == "C")
            {
                ddlentitytype.SelectedItem.Text = "Incorporated Company";
            }
            else if (fourthCharacter == "F")
            {
                ddlentitytype.SelectedItem.Text = "Limited Liability Partnership";
                //cintr.Visible = true;
            }
            else if (fourthCharacter == "T")
            {
                ddlentitytype.SelectedItem.Text = "Trust";
                cintr.Visible = false;
            }
        }
    }
    protected void txtcinnumber_TextChanged(object sender, EventArgs e)
    {
        try
        {
            CallUATTokenCIN();
            CallCINService(txtcinnumber.Text);
            CallDINService(txtcinnumber.Text);

        }
        catch (Exception ex)
        {

        }

    }
    private void CallUATTokenCIN()
    {
        try
        {
            //string clientId = "your_client_id";
            // string clientSecret = "your_client_secret";
            string apiUrl = cinurl + "token";

            using (var client = new HttpClient())
            {
                //string credentials = clientId + ":" + clientSecret;
                //byte[] credentialsBytes = Encoding.ASCII.GetBytes(credentials);
                //string base64Credentials = Convert.ToBase64String(credentialsBytes);
                // string base64Credentials = "ME4wUDBtQm1NdGVGcTNZX1c5cjdZRkxQZWswYTpwQmVWd3hzTjdJWnVfcEdKUzk1MFZoUmxjQVlh";
                string base64Credentials = "N0ZHUFV1cUZBX0NTSGF3V29sZVBmTlB2aXh3YTp5N2tfbXFOMlJtUFdBZ3J1R0Rwc0l0bW4yS0lh";

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                var postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("grant_type", "password"));
                postData.Add(new KeyValuePair<string, string>("username", "admin"));
                postData.Add(new KeyValuePair<string, string>("password", "admin"));

                var content = new FormUrlEncodedContent(postData);
                LogErrorFile.LogData(content.ToString());
                var response = client.PostAsync(apiUrl, content).Result;
                LogErrorFile.LogData(response.ToString());
                var result = response.Content.ReadAsStringAsync().Result;
                dynamic json = JsonConvert.DeserializeObject(result);
                LogErrorFile.LogData(result.ToString());
                accessToken = json.access_token;
                LogErrorFile.LogData("1");
                LogErrorFile.LogData(accessToken);
                // Store or use the access token as needed
            }
        }
        catch (Exception ex)
        {
            GetCINResponse(ex.ToString());
            LogErrorFile.LogData("errortoken" + ex.ToString());
        }
    }
    private void CallCINService(string cin)
    {
        try
        {
            //string apiUrl = "http://182.79.115.45:8280/cin/service/integration/1.0.0?CIN=U01100AP2018PTC107442";
            string apiUrl = cinurl + "cin/service/integration/1.0.0?CIN=" + cin;
            using (var client = new HttpClient())
            {
                // Set Authorization header if needed
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                var response = client.GetAsync(apiUrl).Result;

                var result = response.Content.ReadAsStringAsync().Result;
                GetCINResponse("CallCINService " + result);
                if (result.Contains("Error occured"))
                {
                    lblmsg0.Text = "Please enter Correct CIN Number";
                    Failure.Visible = true;
                    nsws.Visible = false;
                    return;
                }
                else
                {
                    // Parse the JSON response
                    var jsonObject = JObject.Parse(result);
                    var data = jsonObject["data"];
                    GetCINResponse(data.ToString());
                    DataTable table = new DataTable();

                    // Assuming all JSON objects have the same structure, use the first object to define columns
                    var firstItem = data.FirstOrDefault();
                    if (firstItem != null)
                    {
                        foreach (JProperty property in firstItem.Children<JProperty>())
                        {
                            table.Columns.Add(property.Name, typeof(string));
                        }
                    }

                    // Add rows to the DataTable
                    foreach (var item in data)
                    {
                        DataRow row = table.NewRow();
                        foreach (JProperty property in item.Children<JProperty>())
                        {
                            if (property.Value != null)
                            {
                                row[property.Name] = property.Value.ToString();
                            }
                            else
                            {
                                row[property.Name] = string.Empty;
                            }
                        }
                        table.Rows.Add(row);
                    }

                    // Bind the DataTable to the DataGridView
                    grdcindata1.DataSource = table;
                    grdcindata1.DataBind();
                    foreach (GridViewRow gvrow in grdcindata1.Rows)
                    {
                        //GetCINResponse("InsertCin");
                        //CinDataDetails objCinDataDetails = new CinDataDetails();
                        //TextBox CIN = (TextBox)gvrow.FindControl("CIN");
                        //TextBox companyName = (TextBox)gvrow.FindControl("companyName");
                        //TextBox incorporationDate = (TextBox)gvrow.FindControl("incorporationDate");
                        //TextBox companyStatus = (TextBox)gvrow.FindControl("companyStatus");
                        //TextBox ROCName = (TextBox)gvrow.FindControl("ROCName");
                        //TextBox addressType = (TextBox)gvrow.FindControl("addressType");
                        //TextBox addressLine1 = (TextBox)gvrow.FindControl("addressLine1");
                        //TextBox addressLine2 = (TextBox)gvrow.FindControl("addressLine2");
                        //TextBox area = (TextBox)gvrow.FindControl("area");
                        //TextBox city = (TextBox)gvrow.FindControl("city");
                        //TextBox district = (TextBox)gvrow.FindControl("district");
                        //TextBox pincode = (TextBox)gvrow.FindControl("pincode");
                        //TextBox state = (TextBox)gvrow.FindControl("state");
                        //TextBox country = (TextBox)gvrow.FindControl("country");
                        //TextBox emailAddress = (TextBox)gvrow.FindControl("emailAddress");
                        //TextBox contactNumber = (TextBox)gvrow.FindControl("contactNumber");
                        //TextBox financialYear = (TextBox)gvrow.FindControl("financialYear");
                        //TextBox profitLoss = (TextBox)gvrow.FindControl("profitLoss");
                        //TextBox turnover = (TextBox)gvrow.FindControl("turnover");
                        //TextBox financialRange = (TextBox)gvrow.FindControl("financialRange");
                        //TextBox isAuditStatusApplicable = (TextBox)gvrow.FindControl("isAuditStatusApplicable");
                        //TextBox auditStatus = (TextBox)gvrow.FindControl("auditStatus");
                        //TextBox type = (TextBox)gvrow.FindControl("type");

                        //GetCINResponse("InsertCinDB");
                        //objCinDataDetails.CIN = CIN.Text.Trim();

                        //objCinDataDetails.companyName = companyName.Text.Trim();
                        //if (incorporationDate.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.incorporationDate = incorporationDate.Text.Trim();
                        //}
                        //if (companyStatus.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.companyStatus = companyStatus.Text.Trim();
                        //}
                        //if (ROCName.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.ROCName = ROCName.Text.Trim();
                        //}
                        //if (addressType.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.addressType = addressType.Text.Trim();
                        //}
                        //if (addressLine1.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.addressLine1 = addressLine1.Text.Trim();
                        //}
                        //if (addressLine2.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.addressLine2 = addressLine2.Text.Trim();
                        //}
                        //if (area.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.area = area.Text.Trim();
                        //}
                        //if (city.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.city = city.Text.Trim();
                        //}
                        //if (district.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.district = district.Text.Trim();
                        //}
                        //if (pincode.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.pincode = pincode.Text.Trim();
                        //}
                        //if (state.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.state = state.Text.Trim();
                        //}
                        //if (country.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.country = country.Text.Trim();
                        //}
                        //if (emailAddress.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.emailAddress = emailAddress.Text.Trim();
                        //}
                        //if (contactNumber.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.contactNumber = contactNumber.Text.Trim();
                        //}
                        //if (financialYear.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.financialYear = financialYear.Text.Trim();
                        //}
                        //if (profitLoss.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.profitLoss = profitLoss.Text.Trim();
                        //}
                        //if (turnover.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.turnover = turnover.Text.Trim();
                        //}
                        //if (financialRange.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.financialRange = financialRange.Text.Trim();
                        //}
                        //if (isAuditStatusApplicable.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.isAuditStatusApplicable = isAuditStatusApplicable.Text.Trim();
                        //}
                        //if (auditStatus.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.auditStatus = auditStatus.Text.Trim();
                        //}
                        //if (type.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.type = type.Text.Trim();
                        //}
                        //objCinDataDetails.Created_by = (Session["uid"].ToString().Trim());
                        //GetCINResponse("InsertCinDB1");
                        //listCinDataDetails.Add(objCinDataDetails);
                    }
                    // cinedataReg(listCinDataDetails);
                    CINResponseData responseData = JsonConvert.DeserializeObject<CINResponseData>(result);
                    if (responseData != null && responseData.Data != null && responseData.Data.Count > 0)
                    {
                        GetCINResponse(responseData.Message);
                        Failure.Visible = false;
                        if (responseData.Message == "Data fetched Successfully")
                        {
                            nsws.Visible = true;

                        }
                        //CinDataDetails cinedata = responseData.Data[0];                     
                    }
                }
                // Handle response as needed
                LogErrorFile.LogData("2");
                LogErrorFile.LogData(result);
            }

        }
        catch (Exception ex)
        {
            GetCINResponse(ex.ToString());
            LogErrorFile.LogData(ex.ToString());
        }
    }
    private void CallDINService(string cin)
    {
        try
        {
            string apiUrl = cinurl + "din/service/integration/1.0.0?CIN=" + cin;

            using (var client = new HttpClient())
            {
                // Set Authorization header if needed
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                var response = client.GetAsync(apiUrl).Result;

                var result = response.Content.ReadAsStringAsync().Result;
                GetCINResponse("CallDINService " + result);
                if (result.Contains("Error occured"))
                {
                    lblmsg0.Text = "Please enter Correct CIN Number";
                    Failure.Visible = true;
                    nsws.Visible = false;
                    return;
                }
                else
                {
                    // Parse the JSON response
                    var jsonObject = JObject.Parse(result);
                    var data = jsonObject["data"];
                    GetCINResponse(data.ToString());
                    DataTable table = new DataTable();

                    // Assuming all JSON objects have the same structure, use the first object to define columns
                    var firstItem = data.FirstOrDefault();
                    if (firstItem != null)
                    {
                        foreach (JProperty property in firstItem.Children<JProperty>())
                        {
                            table.Columns.Add(property.Name, typeof(string));
                        }
                    }

                    // Add rows to the DataTable
                    foreach (var item in data)
                    {
                        DataRow row = table.NewRow();
                        foreach (JProperty property in item.Children<JProperty>())
                        {
                            if (property.Value != null)
                            {
                                row[property.Name] = property.Value.ToString();
                            }
                            else
                            {
                                row[property.Name] = string.Empty;
                            }
                        }
                        table.Rows.Add(row);
                    }

                    // Bind the DataTable to the DataGridView
                    grdcindata2.DataSource = table;
                    grdcindata2.DataBind();
                    foreach (GridViewRow gvrow in grdcindata2.Rows)
                    {
                        //GetCINResponse("InsertCin");
                        //CinDataDetails objCinDataDetails = new CinDataDetails();
                        //TextBox CIN = (TextBox)gvrow.FindControl("CIN");
                        //TextBox companyName = (TextBox)gvrow.FindControl("companyName");
                        //TextBox incorporationDate = (TextBox)gvrow.FindControl("incorporationDate");
                        //TextBox companyStatus = (TextBox)gvrow.FindControl("companyStatus");
                        //TextBox ROCName = (TextBox)gvrow.FindControl("ROCName");
                        //TextBox addressType = (TextBox)gvrow.FindControl("addressType");
                        //TextBox addressLine1 = (TextBox)gvrow.FindControl("addressLine1");
                        //TextBox addressLine2 = (TextBox)gvrow.FindControl("addressLine2");
                        //TextBox area = (TextBox)gvrow.FindControl("area");
                        //TextBox city = (TextBox)gvrow.FindControl("city");
                        //TextBox district = (TextBox)gvrow.FindControl("district");
                        //TextBox pincode = (TextBox)gvrow.FindControl("pincode");
                        //TextBox state = (TextBox)gvrow.FindControl("state");
                        //TextBox country = (TextBox)gvrow.FindControl("country");
                        //TextBox emailAddress = (TextBox)gvrow.FindControl("emailAddress");
                        //TextBox contactNumber = (TextBox)gvrow.FindControl("contactNumber");
                        //TextBox financialYear = (TextBox)gvrow.FindControl("financialYear");
                        //TextBox profitLoss = (TextBox)gvrow.FindControl("profitLoss");
                        //TextBox turnover = (TextBox)gvrow.FindControl("turnover");
                        //TextBox financialRange = (TextBox)gvrow.FindControl("financialRange");
                        //TextBox isAuditStatusApplicable = (TextBox)gvrow.FindControl("isAuditStatusApplicable");
                        //TextBox auditStatus = (TextBox)gvrow.FindControl("auditStatus");
                        //TextBox type = (TextBox)gvrow.FindControl("type");

                        //GetCINResponse("InsertCinDB");
                        //objCinDataDetails.CIN = CIN.Text.Trim();

                        //objCinDataDetails.companyName = companyName.Text.Trim();
                        //if (incorporationDate.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.incorporationDate = incorporationDate.Text.Trim();
                        //}
                        //if (companyStatus.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.companyStatus = companyStatus.Text.Trim();
                        //}
                        //if (ROCName.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.ROCName = ROCName.Text.Trim();
                        //}
                        //if (addressType.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.addressType = addressType.Text.Trim();
                        //}
                        //if (addressLine1.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.addressLine1 = addressLine1.Text.Trim();
                        //}
                        //if (addressLine2.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.addressLine2 = addressLine2.Text.Trim();
                        //}
                        //if (area.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.area = area.Text.Trim();
                        //}
                        //if (city.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.city = city.Text.Trim();
                        //}
                        //if (district.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.district = district.Text.Trim();
                        //}
                        //if (pincode.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.pincode = pincode.Text.Trim();
                        //}
                        //if (state.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.state = state.Text.Trim();
                        //}
                        //if (country.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.country = country.Text.Trim();
                        //}
                        //if (emailAddress.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.emailAddress = emailAddress.Text.Trim();
                        //}
                        //if (contactNumber.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.contactNumber = contactNumber.Text.Trim();
                        //}
                        //if (financialYear.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.financialYear = financialYear.Text.Trim();
                        //}
                        //if (profitLoss.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.profitLoss = profitLoss.Text.Trim();
                        //}
                        //if (turnover.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.turnover = turnover.Text.Trim();
                        //}
                        //if (financialRange.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.financialRange = financialRange.Text.Trim();
                        //}
                        //if (isAuditStatusApplicable.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.isAuditStatusApplicable = isAuditStatusApplicable.Text.Trim();
                        //}
                        //if (auditStatus.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.auditStatus = auditStatus.Text.Trim();
                        //}
                        //if (type.Text.Trim() != "")
                        //{
                        //    objCinDataDetails.type = type.Text.Trim();
                        //}
                        //objCinDataDetails.Created_by = (Session["uid"].ToString().Trim());
                        //GetCINResponse("InsertCinDB1");
                        //listCinDataDetails.Add(objCinDataDetails);
                    }
                    // cinedataReg(listCinDataDetails);
                    DINResponseData responseData = JsonConvert.DeserializeObject<DINResponseData>(result);
                    if (responseData != null && responseData.Data != null && responseData.Data.Count > 0)
                    {
                        GetCINResponse(responseData.Message);
                        Failure.Visible = false;
                        if (responseData.Message == "Data fetched Successfully")
                        {
                            nsws.Visible = true;

                        }
                        //CinDataDetails cinedata = responseData.Data[0];                     
                    }
                }
                // Handle response as needed
                LogErrorFile.LogData("3");
                LogErrorFile.LogData(result);
            }
        }
        catch (Exception ex)
        {
            GetCINResponse(ex.ToString());
            LogErrorFile.LogData(ex.ToString());
        }
    }
    public void GetCINRequest(string Responce)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_INS_CINREQUEST", con.GetConnection);
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
    public void GetCINResponse(string Responce)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_INS_CINRESPONSE", con.GetConnection);
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
    public void cinedataReg(List<CinDataDetails> CinDataDetails)
    {
        con.OpenConnection();// dbu.openCon();
        SqlCommand cmd = new SqlCommand("Sp_InsertCINdata", con.GetConnection);
        cmd.CommandType = CommandType.StoredProcedure;
        int value = 0;
        cmd.Connection = con.GetConnection;
        try
        {
            foreach (CinDataDetails cinedata in listCinDataDetails)
            {
                GetCINResponse("InsertCinDB");
                if (Convert.ToString(cinedata.CIN.Trim()) == "" || Convert.ToString(cinedata.CIN.Trim()) == null)
                    cmd.Parameters.Add("@CIN", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@CIN", SqlDbType.VarChar).Value = cinedata.CIN.Trim();

                if (Convert.ToString(cinedata.companyName.Trim()) == "" || Convert.ToString(cinedata.companyName.Trim()) == null)
                    cmd.Parameters.Add("@companyName", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@companyName", SqlDbType.VarChar).Value = cinedata.companyName.Trim();

                if (Convert.ToString(cinedata.incorporationDate.Trim()) == "" || Convert.ToString(cinedata.incorporationDate.Trim()) == null)
                    cmd.Parameters.Add("@incorporationDate", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@incorporationDate", SqlDbType.VarChar).Value = cinedata.incorporationDate.Trim();

                if (Convert.ToString(cinedata.companyStatus.Trim()) == "" || Convert.ToString(cinedata.companyStatus.Trim()) == null)
                    cmd.Parameters.Add("@companyStatus", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@companyStatus", SqlDbType.VarChar).Value = cinedata.companyStatus.Trim();

                if (Convert.ToString(cinedata.ROCName.Trim()) == "" || Convert.ToString(cinedata.ROCName.Trim()) == null)
                    cmd.Parameters.Add("@ROCName", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@ROCName", SqlDbType.VarChar).Value = cinedata.ROCName.Trim();

                if (cinedata.addressType == null)
                    cmd.Parameters.Add("@addressType", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@addressType", SqlDbType.VarChar).Value = cinedata.addressType;

                if (cinedata.addressLine1 == null)
                    cmd.Parameters.Add("@addressLine1", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@addressLine1", SqlDbType.VarChar).Value = cinedata.addressLine1;

                if (cinedata.addressLine2 == null)
                    cmd.Parameters.Add("@addressLine2", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@addressLine2", SqlDbType.VarChar).Value = cinedata.addressLine2;
                //  cmd.Parameters.Add("@addressLine2", SqlDbType.VarChar).Value = ConvertToDbValue(cinedata.addressLine2);


                if (cinedata.area == null)
                    cmd.Parameters.Add("@area", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@area", SqlDbType.VarChar).Value = cinedata.area;

                if (cinedata.city == null)
                    cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = cinedata.city.Trim();

                if (cinedata.district == null)
                    cmd.Parameters.Add("@district", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@district", SqlDbType.VarChar).Value = cinedata.district.Trim();

                if (cinedata.pincode == null)
                    cmd.Parameters.Add("@pincode", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@pincode", SqlDbType.VarChar).Value = cinedata.pincode.Trim();

                if (cinedata.state == null)
                    cmd.Parameters.Add("@state", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@state", SqlDbType.VarChar).Value = cinedata.state.Trim();

                if (cinedata.country == null)
                    cmd.Parameters.Add("@country", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@country", SqlDbType.VarChar).Value = cinedata.country.Trim();

                if (cinedata.emailAddress == null)
                    cmd.Parameters.Add("@emailAddress", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@emailAddress", SqlDbType.VarChar).Value = cinedata.emailAddress.Trim();

                if (cinedata.contactNumber == null)
                    cmd.Parameters.Add("@contactNumber", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@contactNumber", SqlDbType.VarChar).Value = cinedata.contactNumber.Trim();

                if (cinedata.financialYear == null)
                    cmd.Parameters.Add("@financialYear", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@financialYear", SqlDbType.VarChar).Value = cinedata.financialYear;

                if (cinedata.profitLoss == null)
                    cmd.Parameters.Add("@profitLoss", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@profitLoss", SqlDbType.VarChar).Value = cinedata.profitLoss;

                if (cinedata.turnover == null /*|| cinedata.turnover==""*/)
                    cmd.Parameters.Add("@turnover", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@turnover", SqlDbType.VarChar).Value = cinedata.turnover;

                if (cinedata.financialRange == null)
                    cmd.Parameters.Add("@financialRange", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@financialRange", SqlDbType.VarChar).Value = cinedata.financialRange;

                if (cinedata.isAuditStatusApplicable == null)
                    cmd.Parameters.Add("@isAuditStatusApplicable", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@isAuditStatusApplicable", SqlDbType.VarChar).Value = cinedata.isAuditStatusApplicable.Trim();

                if (cinedata.auditStatus == null)
                    cmd.Parameters.Add("@auditStatus", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@auditStatus", SqlDbType.VarChar).Value = cinedata.auditStatus;

                if (cinedata.type.ToString() == null)
                    cmd.Parameters.Add("@type", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@type", SqlDbType.VarChar).Value = cinedata.type.Trim();


                cmd.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = "15584";


                cmd.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = cinedata.Created_by;

                string val = cmd.ExecuteScalar().ToString();
                if (val != string.Empty)
                    value = Int32.Parse(val);
                //con.CloseConnection();
                // return value;
            }

        }
        catch (Exception ex)
        {
            throw ex;
            // return 0;
        }
        finally
        {
            cmd.Dispose();
            con.CloseConnection();
        }
    }

    /////////////////key cloak///////////////
    public static void CreateUser(string client_id, string client_secret, string userName, string password, string domainURL, string apiUrl, string apiUserId, string apiUserPassword, string realmName)
    {
        try
        {
            //var requestContent = new
            //{
            //    UserName = userName,
            //    Password = password,
            //    ApiUserId = apiUserId,
            //    ApiUserPassword = apiUserPassword
            //}; 

            string requestContent = "Username=" + userName + "&Password=" + password;
            // string requestBody = JsonConvert.SerializeObject(requestContent);
            var webRequest = System.Net.WebRequest.Create(apiUrl);
            if (webRequest != null)
            {
                //     webRequest.Headers.Add("token", "bd16b347e586f05339f830b3a85d8aefa8da92c1");
                //webRequest.Headers =  "bd16b347e586f05339f830b3a85d8aefa8da92c1";
                webRequest.Method = "POST";
                webRequest.Timeout = 20000;
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(string.Format("{0}:{1}", "NSWS_User", "NSWS_User"))));


                // Convert JSON string to byte array
                //byte[] byteArray = Encoding.UTF8.GetBytes(requestContent);
                byte[] byteArray = Encoding.UTF8.GetBytes(requestContent);
                // Set content length
                webRequest.ContentLength = byteArray.Length;

                // Write JSON data to request body
                using (Stream dataStream = webRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }

                try
                {
                    // Get response
                    using (WebResponse response = webRequest.GetResponse())
                    {
                        // Read response
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                            string responseJson = reader.ReadToEnd();//{"connectionid":"241834332402090001","status":"success"}
                                                                     //Console.WriteLine("status: " + responseJson);
                                                                     //if (responseJson.Contains("success"))
                                                                     //{
                                                                     //}
                            JObject json = JObject.Parse(responseJson);
                            string email = json["email"].ToString();
                            Console.WriteLine("email :: " + email);
                            string cinData = json["cinData"].ToString();
                            Console.WriteLine("cinData length :: " + cinData.Length);
                            Console.WriteLine("cinData :: " + cinData);
                            LogErrorFile.LogData("cinData :: " + cinData);
                            if (cinData.Length > 0)
                            {
                                string cinDataBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(cinData));
                                json["cinData"] = cinDataBase64;
                            }

                            string token = GenerateToken(client_id, client_secret, domainURL, realmName);
                            CreateUserWithToken(token, json, domainURL, userName, password);
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
                                Console.WriteLine("Error response: " + errorText);
                            }
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

    public static string GenerateToken(string client_id, string client_secret, string domainURL, string realmName)
    {
        Console.WriteLine("inside generateToken");

        string url = domainURL + "/realms/" + realmName + "/protocol/openid-connect/token";

        var formParams = new Dictionary<string, string>
        {
            { "client_id", client_id },
            { "client_secret", client_secret },
            { "grant_type", "client_credentials" }
        };

        string requestBodyString = string.Join("&", formParams.Select(kv => kv.Key + "=" + WebUtility.UrlEncode(kv.Value)));

        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        request.Timeout = 20000;
        using (var requestStream = new StreamWriter(request.GetRequestStream()))
        {
            requestStream.Write(requestBodyString);
        }

        var response = (HttpWebResponse)request.GetResponse();
        using (var responseStream = new StreamReader(response.GetResponseStream()))
        {
            string responseBody = responseStream.ReadToEnd();
            Console.WriteLine("Response Body:");
            Console.WriteLine(responseBody);
            LogErrorFile.LogData(responseBody);
            JObject json = JObject.Parse(responseBody);
            string access_token = json["access_token"].ToString();
            Console.WriteLine("access_token :: " + access_token);
            LogErrorFile.LogData("access_token :: " + access_token);
            return access_token;
        }
    }

    public static string CreateUserWithToken(string token, JObject json, string domainURL, string userName, string password)
    {
        Console.WriteLine("inside createUserWithToken");

        string url = domainURL + "/admin/realms/test-nsws/users";

        string email = json["email"].ToString();
        Console.WriteLine("email :: " + email);

        var userPayload = new
        {
            enabled = true,
            username = userName,
            email = email,
            firstName = "abc",
            lastName = "def",
            credentials = new[]
            {
                new { type = "password", value = password, temporary = false }
            },
            requiredActions = new string[] { },
            attributes = json
        };

        string jsonBody = JsonConvert.SerializeObject(userPayload);
        Console.WriteLine("jsonBody :: " + jsonBody);
        LogErrorFile.LogData("jsonBody :: " + jsonBody);
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        request.ContentType = "application/json";
        request.Headers["Authorization"] = "Bearer " + token;
        request.Timeout = 20000;
        using (var requestStream = new StreamWriter(request.GetRequestStream()))
        {
            requestStream.Write(jsonBody);
        }

        var response = (HttpWebResponse)request.GetResponse();
        using (var responseStream = new StreamReader(response.GetResponseStream()))
        {
            string responseBody = responseStream.ReadToEnd();

            Console.WriteLine("Response Code: " + (int)response.StatusCode);
            Console.WriteLine("Response: " + responseBody);
            LogErrorFile.LogData("Response: " + responseBody);
            return responseBody;
        }
    }

  
    ///end/////////////

}
public static class TelanganaUserDetailsApi
{
    public static JObject ApiIntegration(string userName, string password, string apiUrl, string apiUserId, string apiUserPassword)
    {

        var requestContent = new
        {
            UserName = userName,
            Password = password,
            ApiUserId = apiUserId,
            ApiUserPassword = apiUserPassword
        };

        string requestBody = JsonConvert.SerializeObject(requestContent);
        LogErrorFile.LogData("ApiIntegration Request" + requestBody);
        var request = (HttpWebRequest)WebRequest.Create(apiUrl);
        request.Method = "POST";
        request.ContentType = "application/json";
        request.Timeout = 10000; // Set timeout to 10 seconds

        LogErrorFile.LogData("ApiIntegration Request" + "1");
        try
        {
            using (var requestStream = new StreamWriter(request.GetRequestStream()))
            {
                requestStream.Write(requestBody);
                LogErrorFile.LogData("ApiIntegration Request" + requestBody);
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogData(ex.ToString());
        }
        LogErrorFile.LogData("ApiIntegration Request" + "2");
        var response = (HttpWebResponse)request.GetResponse();
        using (var responseStream = new StreamReader(response.GetResponseStream()))
        {
            string responseBody = responseStream.ReadToEnd();
            LogErrorFile.LogData("ApiIntegration" + responseBody);
            return JObject.Parse(responseBody);

        }


    }
}
public class NSWSKeylcoakAttributes
{
    public string fullName { get; set; }
    public string email { get; set; }
    public string mobileNumber { get; set; }
    public string entityType { get; set; }
    public string pan { get; set; }
    public string regAddress1 { get; set; }
    public string regAddress2 { get; set; }
    public string regCountry { get; set; }
    public string regState { get; set; }
    public string regCity { get; set; }
    public string regPincode { get; set; }
    public string postalAddress1 { get; set; }
    public string postalAddress2 { get; set; }
    public string postalCountry { get; set; }
    public string postalState { get; set; }
    public string postalCity { get; set; }
    public string postalPincode { get; set; }
    public string cin { get; set; }
    public string llpin { get; set; }
    public string cinData { get; set; }
    public string companyName { get; set; }
}

public class PanInquiryRequestData
{
    public string pan { get; set; }
    public string name { get; set; }
    public string fathername { get; set; }
    public string dob { get; set; }
}

public class PanRx
{
    public List<PanInquiryRequestData> inputData { get; set; }
    public string signature { get; set; }
}

public class OutputData
{
    public string Pan { get; set; }
    public string Pan_status { get; set; }
    public string Name { get; set; }
    public string Fathername { get; set; }
    public string Dob { get; set; }
    public string Seeding_status { get; set; }
}

public class RootOutput
{
    public string Response_Code { get; set; }
    public List<OutputData> OutputData { get; set; }
}
public class CinDataDetails
{
    public string CIN
    {
        get;
        set;
    }
    public string companyName
    {
        get;
        set;
    }
    public string incorporationDate
    {
        get;
        set;
    }
    public string companyStatus
    {
        get;
        set;
    }
    public string ROCName
    {
        get;
        set;
    }
    public string addressType
    {
        get;
        set;
    }
    public string addressLine1
    {
        get;
        set;
    }
    public string addressLine2
    {
        get;
        set;
    }
    public string area
    {
        get;
        set;
    }
    public string city
    {
        get;
        set;
    }
    public string district
    {
        get;
        set;
    }
    public string pincode
    {
        get;
        set;
    }
    public string state
    {
        get;
        set;
    }
    public string country
    {
        get;
        set;
    }
    public string emailAddress
    {
        get;
        set;
    }
    public string contactNumber
    {
        get;
        set;
    }
    public string financialYear
    {
        get;
        set;
    }
    public string profitLoss
    {
        get;
        set;
    }
    public string turnover
    {
        get;
        set;
    }
    public string financialRange
    {
        get;
        set;
    }
    public string isAuditStatusApplicable
    {
        get;
        set;
    }
    public string auditStatus
    {
        get;
        set;
    }
    public string type
    {
        get;
        set;
    }
    public string Created_by
    {
        get;
        set;
    }

}
public class CINResponseData
{
    public string Message { get; set; }
    public List<CinDataDetails> Data { get; set; }
}
public class DinDataDetails
{
    public string CIN { get; set; }
    public string CompanyName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string DIN { get; set; }
    public string DOB { get; set; }
    public string FatherFirstName { get; set; }
    public string FatherMidName { get; set; }
    public string FatherLastName { get; set; }
    public string DINStatus { get; set; }
    public string AssociationStatus { get; set; }
}

public class DINResponseData
{
    public string Message { get; set; }
    public List<DinDataDetails> Data { get; set; }
}