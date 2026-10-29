using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Web.UI.WebControls;
using System.Linq;

public partial class UI_TSiPASS_CinSave : System.Web.UI.Page
{
    string accessToken = "";
    //string url = "http://182.79.115.45:8280/";
    //string url = "http://182.79.115.52:8280/";
    string url = "https://apim.mca.gov.in:8243/";
    DB.DB con = new DB.DB();
    List<CinDataDetails> listCinDataDetails = new List<CinDataDetails>();
    List<DinDataDetails> listDinDataDetails = new List<DinDataDetails>();
    List<DINAdditionalDetail> listDINAdditionalDetail = new List<DINAdditionalDetail>();
    DataTable Dintable = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Call methods to make API requests
            string cin = "ACA-3666";// "U45202TG2020PTC144407";
            CallUATTokenCIN();
            CallCINService(cin);
            CallDINService(cin); 
        }
    }

    private void CallUATTokenCIN()
    {
        try
        {
            //string clientId = "your_client_id";
            // string clientSecret = "your_client_secret";
            string apiUrl = url + "token";

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
            string apiUrl = url + "cin/service/integration/1.0.0?CIN=" + cin;
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
                    return;
                }
                else
                {
                    // Parse the JSON response
                    var jsonObject = JObject.Parse(result);
                    var data = jsonObject["data"];
                    //GetCINResponse(data.ToString());
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
                    // Handle response as needed
                    LogErrorFile.LogData("2");
                    LogErrorFile.LogData(result);
                }
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
            string apiUrl = url + "din/service/integration/1.0.0?CIN=" + cin;

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
                    return;
                }
                else
                {
                    // Parse the JSON response
                    var jsonObject = JObject.Parse(result);
                    var data = jsonObject["data"];
                    //GetCINResponse(data.ToString());
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
                    // Handle response as needed
                    LogErrorFile.LogData("2");
                    LogErrorFile.LogData(result);
                    int gvrcnt = grdcindata2.Rows.Count;
                    string Dinno;
                    for (int i = 0; i < gvrcnt; i++)
                    {
                        GridViewRow gvr = grdcindata2.Rows[i];
                        Label dinLabel = (Label)gvr.FindControl("DINlabel");
                        if (dinLabel != null)
                        {
                            Dinno = dinLabel.Text;
                            GetCINResponse("Dino " + Dinno);
                            CallDINDetailsService(Dinno);
                            
                        }
                        grddindetails.DataSource = Dintable;
                        grddindetails.DataBind();
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

    private void CallDINDetailsService(string cin)
    {
        try
        {
            string apiUrl = url + "dindetails/service/integration/1.0.0?DIN=" + cin;

            using (var client = new HttpClient())
            {
                // Set Authorization header if needed
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                var response = client.GetAsync(apiUrl).Result;

                var result = response.Content.ReadAsStringAsync().Result;
                GetCINResponse("CallDINDetailsService " + result);
                if (result.Contains("Error occured"))
                {
                    lblmsg0.Text = "Please enter Correct CIN Number";
                    Failure.Visible = true;
                    return;
                }
                else
                {
                    // Parse the JSON response
                    var jsonObject = JObject.Parse(result);
                    var data = jsonObject["data"];
                    GetCINResponse(data.ToString());
                    //DataTable table = new DataTable();

                    // Assuming all JSON objects have the same structure, use the first object to define columns
                    var firstItem = data.FirstOrDefault();
                    if (firstItem != null)
                    {
                        foreach (JProperty property in firstItem.Children<JProperty>())
                        {
                            Dintable.Columns.Add(property.Name, typeof(string));
                        }
                    }

                    // Add rows to the DataTable
                    foreach (var item in data)
                    {
                        DataRow row = Dintable.NewRow();
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
                        Dintable.Rows.Add(row);
                    }
                }
                LogErrorFile.LogData("4");
                LogErrorFile.LogData(result);
                // Handle response as needed
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
                //GetCINResponse("InsertCinDB");
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

                if (cinedata.profitLoss == null || cinedata.profitLoss == string.Empty)
                    cmd.Parameters.Add("@profitLoss", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@profitLoss", SqlDbType.VarChar).Value = cinedata.profitLoss;

                if (cinedata.turnover == null || cinedata.turnover == string.Empty)
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

    public void DirectorsDataReg(List<DinDataDetails> DinDataDetails)
    {
        con.OpenConnection();// dbu.openCon();
        SqlCommand cmd = new SqlCommand("Sp_InsertCINDirectorsData", con.GetConnection);
        cmd.CommandType = CommandType.StoredProcedure;
        int value = 0;
        cmd.Connection = con.GetConnection;
        try
        {
            foreach (DinDataDetails DirectorsData in listDinDataDetails)
            {
                if (DirectorsData.CIN == null)
                    cmd.Parameters.Add("@CIN", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@CIN", SqlDbType.VarChar).Value = DirectorsData.CIN.Trim();

                if (DirectorsData.CompanyName == null)
                    cmd.Parameters.Add("@companyName", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@companyName", SqlDbType.VarChar).Value = DirectorsData.CompanyName.Trim();

                if (DirectorsData.FirstName == null)
                    cmd.Parameters.Add("@firstName", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@firstName", SqlDbType.VarChar).Value = DirectorsData.FirstName.Trim();

                if (DirectorsData.MiddleName == null)
                    cmd.Parameters.Add("@middleName", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@middleName", SqlDbType.VarChar).Value = DirectorsData.MiddleName.Trim();

                if (DirectorsData.LastName == null)
                    cmd.Parameters.Add("@lastName", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@lastName", SqlDbType.VarChar).Value = DirectorsData.LastName.Trim();

                if (DirectorsData.DIN == null)
                    cmd.Parameters.Add("@DIN", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@DIN", SqlDbType.VarChar).Value = DirectorsData.DIN.Trim();

                if (DirectorsData.DOB == null)
                    cmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = DBNull.Value;
                else
                    //cmd.Parameters.Add("@DOB", SqlDbType.VarChar).Value = DirectorsData.DOB.Trim();
                    cmd.Parameters.Add("@DOB", SqlDbType.Date).Value = DirectorsData.DOB.Trim();

                if (DirectorsData.FatherFirstName == null)
                    cmd.Parameters.Add("@fatherFirstName", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@fatherFirstName", SqlDbType.VarChar).Value = DirectorsData.FatherFirstName.Trim();

                if (DirectorsData.FatherMidName == null)
                    cmd.Parameters.Add("@fatherMidName", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@fatherMidName", SqlDbType.VarChar).Value = DirectorsData.FatherMidName.Trim();

                if (DirectorsData.FatherLastName == null)
                    cmd.Parameters.Add("@fatherLastName", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@fatherLastName", SqlDbType.VarChar).Value = DirectorsData.FatherLastName.Trim();

                if (DirectorsData.DINStatus == null)
                    cmd.Parameters.Add("@DINStatus", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@DINStatus", SqlDbType.VarChar).Value = DirectorsData.DINStatus.Trim();

                if (DirectorsData.AssociationStatus == null)
                    cmd.Parameters.Add("@associationStatus", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@associationStatus", SqlDbType.VarChar).Value = DirectorsData.AssociationStatus.Trim();


                cmd.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = "15584";


                cmd.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DirectorsData.Created_by;

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

    public void CINDINReg(List<DINAdditionalDetail> DINAdditionalDetail)
    {
        con.OpenConnection();// dbu.openCon();
        SqlCommand cmd = new SqlCommand("sp_InsertCINandDINData", con.GetConnection);
        cmd.CommandType = CommandType.StoredProcedure;
        int value = 0;
        cmd.Connection = con.GetConnection;

        try
        {
            foreach (DINAdditionalDetail CinDindata in listDINAdditionalDetail)
            {
                if (CinDindata.CIN == null)
                    cmd.Parameters.Add("@CIN", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@CIN", SqlDbType.VarChar).Value = CinDindata.CIN.Trim();

                if (CinDindata.DIN == null)
                    cmd.Parameters.Add("@DIN", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@DIN", SqlDbType.VarChar).Value = CinDindata.DIN.Trim();

                if (CinDindata.FirstName == null)
                    cmd.Parameters.Add("@firstName", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@firstName", SqlDbType.VarChar).Value = CinDindata.FirstName.Trim();

                if (CinDindata.MiddleName == null)
                    cmd.Parameters.Add("@middleName", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@middleName", SqlDbType.VarChar).Value = CinDindata.MiddleName.Trim();

                if (CinDindata.LastName == null)
                    cmd.Parameters.Add("@lastName", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@lastName", SqlDbType.VarChar).Value = CinDindata.LastName.Trim();


                if (CinDindata.DOB == null)
                    cmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = DBNull.Value;
                else
                    //cmd.Parameters.Add("@DOB", SqlDbType.VarChar).Value = CinDindata.DOB.Trim();
                    cmd.Parameters.Add("@DOB", SqlDbType.Date).Value = CinDindata.DOB.Trim();


                if (CinDindata.FatherFirstName == null)
                    cmd.Parameters.Add("@fatherFirstName", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@fatherFirstName", SqlDbType.VarChar).Value = CinDindata.FatherFirstName.Trim();

                if (CinDindata.FatherMiddleName == null)
                    cmd.Parameters.Add("@fatherMidName", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@fatherMidName", SqlDbType.VarChar).Value = CinDindata.FatherMiddleName.Trim();

                if (CinDindata.FatherLastName == null)
                    cmd.Parameters.Add("@fatherLastName", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@fatherLastName", SqlDbType.VarChar).Value = CinDindata.FatherLastName.Trim();

                if (CinDindata.DINStatus == null)
                    cmd.Parameters.Add("@DINStatus", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@DINStatus", SqlDbType.VarChar).Value = CinDindata.DINStatus.Trim();


                cmd.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = "15584";


                cmd.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = "48167";

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
            //  return 0;
        }
        finally
        {
            cmd.Dispose();
            con.CloseConnection();
        }
    }

    protected void grdcindata1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Label CINLabel = (Label)e.Row.FindControl("CINLabel");
            //if (CINLabel != null)
            //{
            //    string cinValue = CINLabel.Text; // CIN value from Label
            //    // You can process CIN value here
            //}

            CinDataDetails objCinDataDetails = new CinDataDetails();
            Label CIN = (Label)e.Row.FindControl("CINLabel");
            Label companyName = (Label)e.Row.FindControl("companyNameLabel");
            Label incorporationDate = (Label)e.Row.FindControl("incorporationDateLabel");
            Label companyStatus = (Label)e.Row.FindControl("companyStatusLabel");
            Label ROCName = (Label)e.Row.FindControl("ROCNameLabel");
            Label addressType = (Label)e.Row.FindControl("addressTypeLabel");
            Label addressLine1 = (Label)e.Row.FindControl("addressLine1Label");
            Label addressLine2 = (Label)e.Row.FindControl("addressLine2Label");
            Label area = (Label)e.Row.FindControl("areaLabel");
            Label city = (Label)e.Row.FindControl("cityLabel");
            Label district = (Label)e.Row.FindControl("districtLabel");
            Label pincode = (Label)e.Row.FindControl("pincodeLabel");
            Label state = (Label)e.Row.FindControl("stateLabel");
            Label country = (Label)e.Row.FindControl("countryLabel");
            Label emailAddress = (Label)e.Row.FindControl("emailAddressLabel");
            Label contactNumber = (Label)e.Row.FindControl("contactNumberLabel");
            Label financialYear = (Label)e.Row.FindControl("financialYearLabel");
            Label profitLoss = (Label)e.Row.FindControl("profitLossLabel");
            Label turnover = (Label)e.Row.FindControl("turnoverLabel");
            Label financialRange = (Label)e.Row.FindControl("financialRangeLabel");
            Label isAuditStatusApplicable = (Label)e.Row.FindControl("isAuditStatusApplicableLabel");
            Label auditStatus = (Label)e.Row.FindControl("auditStatusLabel");
            Label type = (Label)e.Row.FindControl("typeLabel");

            //GetCINResponse("InsertCinDB");
            if (CIN != null)
            {
                objCinDataDetails.CIN = CIN.Text.Trim();
            }
            objCinDataDetails.companyName = companyName.Text.Trim();
            if (incorporationDate != null)
            {
                objCinDataDetails.incorporationDate = incorporationDate.Text.Trim();
            }
            if (companyStatus != null)
            {
                objCinDataDetails.companyStatus = companyStatus.Text.Trim();
            }
            if (ROCName != null)
            {
                objCinDataDetails.ROCName = ROCName.Text.Trim();
            }
            if (addressType != null)
            {
                objCinDataDetails.addressType = addressType.Text.Trim();
            }
            if (addressLine1 != null)
            {
                objCinDataDetails.addressLine1 = addressLine1.Text.Trim();
            }
            if (addressLine2 != null)
            {
                objCinDataDetails.addressLine2 = addressLine2.Text.Trim();
            }
            if (area != null)
            {
                objCinDataDetails.area = area.Text.Trim();
            }
            if (city != null)
            {
                objCinDataDetails.city = city.Text.Trim();
            }
            if (district != null)
            {
                objCinDataDetails.district = district.Text.Trim();
            }
            if (pincode != null)
            {
                objCinDataDetails.pincode = pincode.Text.Trim();
            }
            if (state != null)
            {
                objCinDataDetails.state = state.Text.Trim();
            }
            if (country != null)
            {
                objCinDataDetails.country = country.Text.Trim();
            }
            if (emailAddress != null)
            {
                objCinDataDetails.emailAddress = emailAddress.Text.Trim();
            }
            if (contactNumber != null)
            {
                objCinDataDetails.contactNumber = contactNumber.Text.Trim();
            }
            if (financialYear != null)
            {
                objCinDataDetails.financialYear = financialYear.Text.Trim();
            }
            if (profitLoss != null)
            {
                objCinDataDetails.profitLoss = profitLoss.Text.Trim();
            }
            if (turnover != null)
            {
                objCinDataDetails.turnover = turnover.Text.Trim();
            }
            if (financialRange != null)
            {
                objCinDataDetails.financialRange = financialRange.Text.Trim();
            }
            if (isAuditStatusApplicable != null)
            {
                objCinDataDetails.isAuditStatusApplicable = isAuditStatusApplicable.Text.Trim();
            }
            if (auditStatus != null)
            {
                objCinDataDetails.auditStatus = auditStatus.Text.Trim();
            }
            if (type != null)
            {
                objCinDataDetails.type = type.Text.Trim();
            }

            objCinDataDetails.Created_by = (Session["uid"].ToString().Trim());
            //GetCINResponse("InsertCinDB1");
            listCinDataDetails.Add(objCinDataDetails);
        }
    }

    protected void grdcindata2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Label CINLabel = (Label)e.Row.FindControl("CINLabel");
            //if (CINLabel != null)
            //{
            //    string cinValue = CINLabel.Text; // CIN value from Label
            //    // You can process CIN value here
            //}

            DinDataDetails objDinDataDetails = new DinDataDetails();
            Label CIN = (Label)e.Row.FindControl("CINLabel");
            Label companyName = (Label)e.Row.FindControl("companyNamelabel");
            Label FirstName = (Label)e.Row.FindControl("FirstNamelabel");
            Label MiddleName = (Label)e.Row.FindControl("MiddleNamelabel");
            Label LastName = (Label)e.Row.FindControl("LastNamelabel");
            Label DIN = (Label)e.Row.FindControl("DINlabel");
            Label DOB = (Label)e.Row.FindControl("DOBlabel");
            Label FatherFirstName = (Label)e.Row.FindControl("FatherFirstNamelabel");
            Label FatherMidName = (Label)e.Row.FindControl("FatherMidNamelabel");
            Label FatherLastName = (Label)e.Row.FindControl("FatherLastNamelabel");
            Label DINStatus = (Label)e.Row.FindControl("DINStatuslabel");
            Label AssociationStatus = (Label)e.Row.FindControl("AssociationStatuslabel");

            //GetCINResponse("InsertCinDB");
            if (CIN != null)
            {
                objDinDataDetails.CIN = CIN.Text.Trim();
            }
            objDinDataDetails.CompanyName = companyName.Text.Trim();
            if (FirstName != null)
            {
                objDinDataDetails.FirstName = FirstName.Text.Trim();
            }
            if (MiddleName != null)
            {
                objDinDataDetails.MiddleName = MiddleName.Text.Trim();
            }
            if (LastName != null)
            {
                objDinDataDetails.LastName = LastName.Text.Trim();
            }
            if (DIN != null)
            {
                objDinDataDetails.DIN = DIN.Text.Trim();
            }
            if (DOB != null)
            {
                objDinDataDetails.DOB = DOB.Text.Trim();
            }
            if (FatherFirstName != null)
            {
                objDinDataDetails.FatherFirstName = FatherFirstName.Text.Trim();
            }
            if (FatherMidName != null)
            {
                objDinDataDetails.FatherMidName = FatherMidName.Text.Trim();
            }
            if (FatherLastName != null)
            {
                objDinDataDetails.FatherLastName = FatherLastName.Text.Trim();
            }
            if (DINStatus != null)
            {
                objDinDataDetails.DINStatus = DINStatus.Text.Trim();
            }
            if (AssociationStatus != null)
            {
                objDinDataDetails.AssociationStatus = AssociationStatus.Text.Trim();
            }

            objDinDataDetails.Created_by = (Session["uid"].ToString().Trim());
            //GetCINResponse("InsertCinDB1");
            listDinDataDetails.Add(objDinDataDetails);
        }

    }

    protected void grddindetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DINAdditionalDetail objDINAdditionalDetail = new DINAdditionalDetail();
            Label FirstName = (Label)e.Row.FindControl("FirstNamelabel");
            Label MiddleName = (Label)e.Row.FindControl("MiddleNamelabel");
            Label LastName = (Label)e.Row.FindControl("LastNamelabel");
            Label DOB = (Label)e.Row.FindControl("DOBlabel");
            Label FatherFirstName = (Label)e.Row.FindControl("FatherFirstNamelabel");
            Label FatherMidName = (Label)e.Row.FindControl("FatherMidNamelabel");
            Label FatherLastName = (Label)e.Row.FindControl("FatherLastNamelabel");
            Label DINStatus = (Label)e.Row.FindControl("DINStatuslabel");

            if (FirstName != null)
            {
                objDINAdditionalDetail.FirstName = FirstName.Text.Trim();
            }
            if (MiddleName != null)
            {
                objDINAdditionalDetail.MiddleName = MiddleName.Text.Trim();
            }
            if (LastName != null)
            {
                objDINAdditionalDetail.LastName = LastName.Text.Trim();
            }
            if (DOB != null)
            {
                objDINAdditionalDetail.DOB = DOB.Text.Trim();
            }
            if (FatherFirstName != null)
            {
                objDINAdditionalDetail.FatherFirstName = FatherFirstName.Text.Trim();
            }
            if (FatherMidName != null)
            {
                objDINAdditionalDetail.FatherMiddleName = FatherMidName.Text.Trim();
            }
            if (FatherLastName != null)
            {
                objDINAdditionalDetail.FatherLastName = FatherLastName.Text.Trim();
            }
            if (DINStatus != null)
            {
                objDINAdditionalDetail.DINStatus = DINStatus.Text.Trim();
            }

            objDINAdditionalDetail.Created_by = (Session["uid"].ToString().Trim());
            //GetCINResponse("InsertCinDB1");
            listDINAdditionalDetail.Add(objDINAdditionalDetail);
        }
    }
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
    public string Created_by { get; set; }
}

public class DINResponseData
{
    public string Message { get; set; }
    public List<DinDataDetails> Data { get; set; }
}

public class DINAdditionalDetail
{
    public string CIN { get; set; }
    public string DIN { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string DOB { get; set; }
    public string FatherFirstName { get; set; }
    public string FatherMiddleName { get; set; }
    public string FatherLastName { get; set; }
    public string DINStatus { get; set; }
    public string Created_by { get; set; }
}

public class DINDetailsResponse
{
    public string Message { get; set; }
    public List<DINAdditionalDetail> Data { get; set; }
}