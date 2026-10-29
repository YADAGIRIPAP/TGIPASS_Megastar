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
using System.Diagnostics;
using System.Text.RegularExpressions;

public partial class UI_TSiPASS_frmSocietyRegistrationDetails : System.Web.UI.Page
{
    InputsSocial objInputs = new InputsSocial();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
        }

        if (!IsPostBack)
        {
            if (Session["User_Code"].ToString() == "3" || Session["User_Code"].ToString() == "7" || Session["User_Code"].ToString() == "1" || Session["User_Code"].ToString() == "267"
                 || Session["User_Code"].ToString() == "268" || Session["User_Code"].ToString() == "403")
            {
            }
            else
            {
                Response.Redirect("../../IpassLogin.aspx");
            }
        }
    }

    //protected void rdbSociety_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}
    private void SocietyRegistrationNameChange()
    {
        try
        {
            string responseJson = "";
            //string FromdateforDB = "", TodateforDB = "";
            if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
            {
                objInputs.fromDate = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("yyyy-MM-dd"));
                objInputs.toDate = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("yyyy-MM-dd"));

                var JsonDetails = JsonConvert.SerializeObject(objInputs);
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)48 | (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                string apiUrl = "https://ts.meeseva.telangana.gov.in/ssdgigrsdept/EODBSocietyNameChange.htm";
                var webRequest = System.Net.WebRequest.Create(apiUrl);
                if (webRequest != null)
                {
                    //     webRequest.Headers.Add("token", "bd16b347e586f05339f830b3a85d8aefa8da92c1");
                    //webRequest.Headers =  "bd16b347e586f05339f830b3a85d8aefa8da92c1";
                    webRequest.Method = "POST";
                    webRequest.Timeout = 20000;
                    webRequest.ContentType = "application/json";

                    // Convert JSON string to byte array
                    byte[] byteArray = Encoding.UTF8.GetBytes(JsonDetails);

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
                                responseJson = reader.ReadToEnd();
                                ApiResponseSocial objApiSocietyRegistrationNameChangeData = JsonConvert.DeserializeObject<ApiResponseSocial>(responseJson);

                                if (objApiSocietyRegistrationNameChangeData.ResponseCode == "000" && objApiSocietyRegistrationNameChangeData.ResponseMsg == "SUCCESS")
                                {
                                    var jsonObject = JObject.Parse(responseJson);
                                    var data = jsonObject["data"];
                                    SocietyApiResponse(data.ToString());
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
                                    trsocietynamechange.Visible = true;
                                    grdsocietynamechange.DataSource = table;
                                    grdsocietynamechange.DataBind();
                                    foreach (GridViewRow gvrow in grdsocietynamechange.Rows)
                                    {

                                    }
                                    SocietyNameChangeData responseData = JsonConvert.DeserializeObject<SocietyNameChangeData>(responseJson);
                                    if (responseData != null)
                                    {

                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogErrorFile.LogData(ex.ToString());
                    }
                    if (responseJson.Contains("Error occured"))
                    {
                        lblmsg0.Text = "Please enter Correct CIN Number";
                        Failure.Visible = true;
                        return;
                    }
                    else
                    {

                    }
                    LogErrorFile.LogData("2");
                    LogErrorFile.LogData(responseJson);
                }
            }

        }
        catch (Exception ex)
        {
            SocietyApiResponse(ex.ToString());
            LogErrorFile.LogData(ex.ToString());
        }
    }
    private void SocietyAddressChange()
    {
        try
        {
            string responseJson = "";
            if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
            {
                objInputs.fromDate = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("yyyy-MM-dd"));
                objInputs.toDate = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("yyyy-MM-dd"));

                //string apiUrl = "http://182.79.115.45:8280/cin/service/integration/1.0.0?CIN=U01100AP2018PTC107442";
                var JsonDetails = JsonConvert.SerializeObject(objInputs);
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)48 | (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                string apiUrl = "https://ts.meeseva.telangana.gov.in/ssdgigrsdept/EODBSocietyAddressChange.htm";
                var webRequest = System.Net.WebRequest.Create(apiUrl);
                if (webRequest != null)
                {
                    webRequest.Method = "POST";
                    webRequest.Timeout = 20000;
                    webRequest.ContentType = "application/json";
                    byte[] byteArray = Encoding.UTF8.GetBytes(JsonDetails);
                    webRequest.ContentLength = byteArray.Length;
                    using (Stream dataStream = webRequest.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                    }

                    try
                    {
                        using (WebResponse response = webRequest.GetResponse())
                        {
                            using (Stream responseStream = response.GetResponseStream())
                            {
                                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                                responseJson = reader.ReadToEnd();
                                ApiResponseSocial objApiResponseSocietyAddressChangeData = JsonConvert.DeserializeObject<ApiResponseSocial>(responseJson);

                                if (objApiResponseSocietyAddressChangeData.ResponseCode == "000" && objApiResponseSocietyAddressChangeData.ResponseMsg == "SUCCESS")
                                {
                                    var jsonObject = JObject.Parse(responseJson);
                                    var data = jsonObject["data"];
                                    SocietyApiResponse(data.ToString());
                                    DataTable table = new DataTable();
                                    var firstItem = data.FirstOrDefault();
                                    if (firstItem != null)
                                    {
                                        foreach (JProperty property in firstItem.Children<JProperty>())
                                        {
                                            table.Columns.Add(property.Name, typeof(string));
                                        }
                                    }
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

                                    grdsocietyAddresschange.DataSource = table;
                                    grdsocietyAddresschange.DataBind();
                                    foreach (GridViewRow gvrow in grdsocietyAddresschange.Rows)
                                    {

                                    }
                                    SocietyNameChangeData responseData = JsonConvert.DeserializeObject<SocietyNameChangeData>(responseJson);
                                    if (responseData != null)
                                    {

                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogErrorFile.LogData(ex.ToString());
                    }
                    if (responseJson.Contains("Error occured"))
                    {
                        lblmsg0.Text = "Please enter Correct CIN Number";
                        Failure.Visible = true;
                        return;
                    }
                    else
                    {

                    }

                    LogErrorFile.LogData("2");
                    LogErrorFile.LogData(responseJson);
                }
            }

        }
        catch (Exception ex)
        {
            SocietyApiResponse(ex.ToString());
            LogErrorFile.LogData(ex.ToString());
        }
    }
    private void SocietyDisslotion()
    {
        try
        {
            string responseJson = "";
            if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
            {
                objInputs.fromDate = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("yyyy-MM-dd"));
                objInputs.toDate = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("yyyy-MM-dd"));
                var JsonDetails = JsonConvert.SerializeObject(objInputs);
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)48 | (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                string apiUrl = "https://ts.meeseva.telangana.gov.in/ssdgigrsdept/EODBSocietyDissolution.htm";
                var webRequest = System.Net.WebRequest.Create(apiUrl);
                if (webRequest != null)
                {
                    webRequest.Method = "POST";
                    webRequest.Timeout = 20000;
                    webRequest.ContentType = "application/json";

                    byte[] byteArray = Encoding.UTF8.GetBytes(JsonDetails);
                    webRequest.ContentLength = byteArray.Length;
                    using (Stream dataStream = webRequest.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                    }

                    try
                    {
                        using (WebResponse response = webRequest.GetResponse())
                        {
                            using (Stream responseStream = response.GetResponseStream())
                            {
                                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                                responseJson = reader.ReadToEnd();
                                ApiResponseSocial objApiResponseSocietyDisslotionData = JsonConvert.DeserializeObject<ApiResponseSocial>(responseJson);

                                if (objApiResponseSocietyDisslotionData.ResponseCode == "000" && objApiResponseSocietyDisslotionData.ResponseMsg == "SUCCESS")
                                {
                                    var jsonObject = JObject.Parse(responseJson);
                                    var data = jsonObject["data"];
                                    SocietyApiResponse(data.ToString());
                                    DataTable table = new DataTable();
                                    var firstItem = data.FirstOrDefault();
                                    if (firstItem != null)
                                    {
                                        foreach (JProperty property in firstItem.Children<JProperty>())
                                        {
                                            table.Columns.Add(property.Name, typeof(string));
                                        }
                                    }
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
                                    grdsocietydisslotion.DataSource = table;
                                    grdsocietydisslotion.DataBind();
                                    foreach (GridViewRow gvrow in grdsocietydisslotion.Rows)
                                    {

                                    }
                                    SocietyNameChangeData responseData = JsonConvert.DeserializeObject<SocietyNameChangeData>(responseJson);
                                    if (responseData != null)
                                    {

                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogErrorFile.LogData(ex.ToString());
                    }
                    if (responseJson.Contains("Error occured"))
                    {
                        lblmsg0.Text = "Please enter Correct CIN Number";
                        Failure.Visible = true;
                        return;
                    }
                    else
                    {

                    }
                    LogErrorFile.LogData("2");
                    LogErrorFile.LogData(responseJson);
                }
            }

        }
        catch (Exception ex)
        {
            SocietyApiResponse(ex.ToString());
            LogErrorFile.LogData(ex.ToString());
        }
    }
    private void SocietyPartnerChange()
    {
        try
        {
            string responseJson = "";
            if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
            {
                objInputs.fromDate = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("yyyy-MM-dd"));
                objInputs.toDate = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("yyyy-MM-dd"));
                var JsonDetails = JsonConvert.SerializeObject(objInputs);
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)48 | (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                string apiUrl = "https://ts.meeseva.telangana.gov.in/ssdgigrsdept/EODBSocietyPartnerChange.htm";
                var webRequest = System.Net.WebRequest.Create(apiUrl);
                if (webRequest != null)
                {
                    webRequest.Method = "POST";
                    webRequest.Timeout = 20000;
                    webRequest.ContentType = "application/json";

                    byte[] byteArray = Encoding.UTF8.GetBytes(JsonDetails);
                    webRequest.ContentLength = byteArray.Length;
                    using (Stream dataStream = webRequest.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                    }

                    try
                    {
                        using (WebResponse response = webRequest.GetResponse())
                        {
                            using (Stream responseStream = response.GetResponseStream())
                            {
                                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                                responseJson = reader.ReadToEnd();
                                ApiResponseSocial objApiResponseSocietyPartnerChangeData = JsonConvert.DeserializeObject<ApiResponseSocial>(responseJson);

                                if (objApiResponseSocietyPartnerChangeData.ResponseCode == "000" && objApiResponseSocietyPartnerChangeData.ResponseMsg == "SUCCESS")
                                {
                                    /*var jsonObject = JObject.Parse(responseJson);
                                    var data = jsonObject["data"];
                                    SocietyApiResponse(data.ToString());
                                    DataTable table = new DataTable();
                                    var firstItem = data.FirstOrDefault();
                                    if (firstItem != null)
                                    {
                                        foreach (JProperty property in firstItem.Children<JProperty>())
                                        {
                                            table.Columns.Add(property.Name, typeof(string));
                                        }
                                    }
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
                                    grdsocietyPartnerchange.DataSource = table;
                                    grdsocietyPartnerchange.DataBind();
                                    foreach (GridViewRow gvrow in grdsocietyPartnerchange.Rows)
                                    {

                                    }
                                    SocietyNameChangeData responseData = JsonConvert.DeserializeObject<SocietyNameChangeData>(responseJson);
                                    
                                    if (responseData != null)
                                    {
                                        
                                    }*/

                                    var jsonObject = JObject.Parse(responseJson);
                                    var data = jsonObject["data"];
                                    SocietyApiResponse(data.ToString());
                                    DataTable table = new DataTable();

                                    table.Columns.Add("SocietyName", typeof(string));
                                    table.Columns.Add("SocietyRegistrationNo", typeof(string));
                                    table.Columns.Add("SocietyRegistrationYear", typeof(string));
                                    table.Columns.Add("ApplicationNo", typeof(string));
                                    table.Columns.Add("RegistrationDist", typeof(string));
                                    table.Columns.Add("ExistingPartners", typeof(string));
                                    table.Columns.Add("OutgoingPartners", typeof(string));
                                    table.Columns.Add("IncomingPartners", typeof(string));

                                    foreach (var item in data)
                                    {
                                        DataRow row = table.NewRow();
                                        row["SocietyName"] = item["societyName"].ToString();
                                        row["SocietyRegistrationNo"] = item["societyRegistrationNo"].ToString();
                                        row["SocietyRegistrationYear"] = item["societyRegistrationYear"].ToString();
                                        row["ApplicationNo"] = item["applicationNo"].ToString();
                                        row["RegistrationDist"] = item["registrationDist"].ToString();
                                        /* Converting Partners Data with "," to Respective Partner Type against the Row */
                                        var partnerDetails = item["partnerDetails"];
                                        row["ExistingPartners"] = string.Join(", ", partnerDetails["existingPartner"] ?? new JArray());
                                        row["OutgoingPartners"] = string.Join(", ", partnerDetails["outgoingPartner"] ?? new JArray());
                                        row["IncomingPartners"] = string.Join(", ", partnerDetails["incomingPartner"] ?? new JArray());

                                        table.Rows.Add(row);
                                    }
                                    grdsocietyPartnerchange.DataSource = table;
                                    grdsocietyPartnerchange.DataBind();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogErrorFile.LogData(ex.ToString());
                    }
                    if (responseJson.Contains("Error occured"))
                    {
                        lblmsg0.Text = "Please enter Correct CIN Number";
                        Failure.Visible = true;
                        return;
                    }
                    else
                    {

                    }

                    LogErrorFile.LogData("2");
                    LogErrorFile.LogData(responseJson);
                }
            }

        }
        catch (Exception ex)
        {
            SocietyApiResponse(ex.ToString());
            LogErrorFile.LogData(ex.ToString());
        }
    }
    public void SocietyApiResponse(string Responce)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_INS_SOCIETYREGISTATIONRESPONSE", con.GetConnection);
            da.SelectCommand.Parameters.Add("@responce", SqlDbType.VarChar).Value = Responce.ToString();
            da.SelectCommand.Parameters.Add("@Online", SqlDbType.VarChar).Value = "Online";
            da.SelectCommand.Parameters.Add("@Module", SqlDbType.VarChar).Value = rdbSociety.SelectedValue.Trim();
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

    protected void grdsocietynamechange_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView gridView = sender as GridView;
        if (e.CommandName == "Action")
        {
            try
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gridView.Rows[rowIndex];
                string AppNo = (row.FindControl("lblapplicationNo") as Label).Text;
                InputsDoc objInputs = new InputsDoc();

                try
                {
                    string responseJson = "";
                    objInputs.applicationNo = AppNo;
                    var JsonDetails = JsonConvert.SerializeObject(objInputs);
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)48 | (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                    string apiUrl = "https://ts.meeseva.telangana.gov.in/ssdgigrsdept/EODBCertificate.htm";
                    var webRequest = System.Net.WebRequest.Create(apiUrl);
                    if (webRequest != null)
                    {
                        webRequest.Method = "POST";
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";

                        byte[] byteArray = Encoding.UTF8.GetBytes(JsonDetails);
                        webRequest.ContentLength = byteArray.Length;
                        using (Stream dataStream = webRequest.GetRequestStream())
                        {
                            dataStream.Write(byteArray, 0, byteArray.Length);
                        }

                        try
                        {
                            string sFileDir = ConfigurationManager.AppSettings["IGRSFilePath"];

                            using (WebResponse response = webRequest.GetResponse())
                            {
                                using (Stream responseStream = response.GetResponseStream())
                                {
                                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                                    responseJson = reader.ReadToEnd();
                                    var responsepdf = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResponse>(responseJson);

                                    //string base64Data = ExtractDataFromJson(responseJson);
                                    //base64Data = CleanBase64String(base64Data);
                                    if (responsepdf.responseCode == "000" && responsepdf.responseMsg == "SUCCESS")
                                    {
                                        try
                                        {
                                            // Decode Base64 string to byte array
                                            byte[] pdfBytes = Convert.FromBase64String(responsepdf.data);
                                            using (MemoryStream ms = new MemoryStream(pdfBytes))
                                            { // Create a temporary file path
                                              // string tempPdfFile = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".pdf");

                                                string newPath = System.IO.Path.Combine(sFileDir, objInputs.applicationNo);

                                                if (!Directory.Exists(newPath))
                                                    System.IO.Directory.CreateDirectory(newPath);
                                                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                                                int count = dir.GetFiles().Length;
                                                string tempPdfFile;
                                                tempPdfFile = Path.Combine(newPath, objInputs.applicationNo + ".pdf");
                                                if (count == 0)
                                                {
                                                    File.WriteAllBytes(tempPdfFile, ms.ToArray());
                                                    //fupDPR.PostedFile.SaveAs(newPath + "\\" + objInputs.applicationNo);
                                                }
                                                else
                                                {
                                                    if (count == 1)
                                                    {
                                                        string[] Files = Directory.GetFiles(newPath);

                                                        foreach (string file in Files)
                                                        {
                                                            File.Delete(file);
                                                        }
                                                        tempPdfFile = Path.Combine(newPath, objInputs.applicationNo + ".pdf");
                                                    }
                                                }

                                                // Save the byte data to a temporary PDF file
                                                File.WriteAllBytes(tempPdfFile, ms.ToArray());

                                                // Open the PDF from memory
                                              //  Process.Start(tempPdfFile);

                                                // Optionally, clean up the temporary file after opening
                                                // Wait for the process to close and then delete the temporary file
                                                Process process = new Process();
                                                process.StartInfo.FileName = tempPdfFile;
                                                process.EnableRaisingEvents = true;
                                                process.Exited += (processSender, processEventArgs) => // Renamed lambda parameters
                                                {
                                                    //File.Delete(tempPdfFile); // Delete the temporary file once the process is closed
                                                };
                                                // process.Start();
                                                //Process.Start(tempPdfFile);
                                                string filepathnew = tempPdfFile.Replace(@"\", @"/");
                                                Response.Redirect("viewpdf.aspx?filepathnew=" + filepathnew);
                                            }
                                            // Use MemoryStream to open the PDF without saving it to disk
                                            //using (MemoryStream ms = new MemoryStream(pdfBytes))
                                            //{
                                            //    // Create a temporary file path
                                            //    string tempPdfFile = Path.Combine(Path.GetTempPath(), objInputs.applicationNo+"tempfile.pdf");

                                            //    // Save the byte data to a temporary PDF file
                                            //    File.WriteAllBytes(tempPdfFile, ms.ToArray());

                                            //    // Open the PDF from memory
                                            //    Process.Start(tempPdfFile);

                                            //    // Optionally, clean up the temporary file after opening
                                            //    // File.Delete(tempPdfFile);
                                            //}
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("Error handling the PDF: " + ex.Message);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("API response unsuccessful: " + responsepdf.responseMsg);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            LogErrorFile.LogData(ex.ToString());
                        }
                        if (responseJson.Contains("Error occured"))
                        {
                            lblmsg0.Text = "Please enter Correct CIN Number";
                            Failure.Visible = true;
                            return;
                        }
                        else
                        {

                        }

                        LogErrorFile.LogData("2");
                        LogErrorFile.LogData(responseJson);
                    }

                }
                catch (Exception ex)
                {
                    SocietyApiResponse(ex.ToString());
                    LogErrorFile.LogData(ex.ToString());
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
    public string ExtractDataFromJson(string jsonResponse)
    {
        var match = Regex.Match(jsonResponse, "\"data\":\"(.*?)\"");
        return match.Success ? match.Groups[1].Value : null;
    }

    public string CleanBase64String(string input)
    {
        return input
            .Replace("\\n", "")
            .Replace("\\u003c", "<")
            .Replace("\\u003e", ">")
            .Replace("%PDF-", "");
    }


    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (rdbSociety.SelectedValue == "Name")
        {
            trsocietynamechange.Visible = true;
            trsocietyAddresschange.Visible = false;
            trsocietydisslotion.Visible = false;
            trsocietyPartnerchange.Visible = false;
            SocietyRegistrationNameChange();
        }
        else if (rdbSociety.SelectedValue == "Address")
        {
            SocietyAddressChange();
            trsocietynamechange.Visible = false;
            trsocietyAddresschange.Visible = true;
            trsocietydisslotion.Visible = false;
            trsocietyPartnerchange.Visible = false;
        }
        else if (rdbSociety.SelectedValue == "Dissolution")
        {
            SocietyDisslotion();
            trsocietynamechange.Visible = false;
            trsocietyAddresschange.Visible = false;
            trsocietydisslotion.Visible = true;
            trsocietyPartnerchange.Visible = false;
        }
        else if (rdbSociety.SelectedValue == "PartnerChange")
        {
            SocietyPartnerChange();
            trsocietynamechange.Visible = false;
            trsocietyAddresschange.Visible = false;
            trsocietydisslotion.Visible = false;
            trsocietyPartnerchange.Visible = true;
        }
    }
}
public class InputsSocial
{
    public string fromDate { get; set; }
    public string toDate { get; set; }
}
public class InputsDoc
{
    public string applicationNo { get; set; }
}
public class SocietyNameChangeData
{
    public string SocietyRegistrationNo { get; set; }
    public string SocietyRegistrationYear { get; set; }
    public string SocietyPreviousName { get; set; }
    public string SocietyNewName { get; set; }
    public string ApprovedBy { get; set; }
    public string ApprovedDate { get; set; }
    public string ApplicationNo { get; set; }
    public string RegistrationDist { get; set; }
}

public class ApiResponseSocial
{
    public string ResponseCode { get; set; }
    public string ResponseMsg { get; set; }
    public List<SocietyNameChangeData> Data { get; set; }
}
public class ApiResponse
{
    public string responseCode { get; set; }
    public string responseMsg { get; set; }
    public string data { get; set; }
}



