using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Configuration;

public partial class UI_TSiPASS_frmPANAPINew : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            
            PanInquiryService objPanInquiryService = new PanInquiryService();
            //objPanInquiryService.GetPanInquiryResponseAsync(null);
            objPanInquiryService.GetPanInquiryResponseAsync(null);
        }
        catch(Exception ex)
        {
            //GetPANRequest(ex.Message);
        }
        
    }
    public class PanInquiryService
    {


        //public PanInquiryService(HttpClient httpClient, string certificatePath, string certificatePassword)
        //{
        //    //_httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

        //    // Load the certificate from the .pfx file
        //    //certificatePath = @"D:\TS-iPASSFinal\UI\TSiPASS\signer.pfx";
        //    //certificatePassword = "emudhra";

        //    //_certificate = new X509Certificate2(certificatePath, certificatePassword, X509KeyStorageFlags.Exportable);
        //}
       

        public async Task<string> GetPanInquiryResponseAsync(List<PanInquiryRequestData> inputData )
        {
            try
            {
                HttpClient _httpClient = new HttpClient();

                // string filePath = System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
                //string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                //string certificatePath = Path.Combine(documentsPath, "Signer.pfx"); // System.IO.Path.Combine(filePath, @"D:\PANSign\Signer.pfx");

                //string certificatePassword = "emudhra";
                //string certificatePath = @"D:\TS-iPASSFinal\PANSign\signer.pfx";
                //X509Certificate2 _certificate = new X509Certificate2(certificatePath, certificatePassword);

                string oath = Convert.ToString(ConfigurationManager.AppSettings["PANCertificatename"]);
                string password = Convert.ToString(ConfigurationManager.AppSettings["PANFXPassword"]);
                X509Certificate2 _certificate = new X509Certificate2(oath, password);
               
               // Construct the request body
               List <PanInquiryRequestData> inputData1 = new List<PanInquiryRequestData>();
                inputData1.Add(new PanInquiryRequestData
                {
                    pan = "AADCS0823M",
                    name = "SURYALATA SPINNING MILLS LIMITED",
                    fathername = "",
                    dob = "23-05-1983"
                });

                var requestBody = new
                {
                    inputData1
                }; 
                // Serialize the request body to JSON
                var jsonRequestBody = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
                GetPANRequest("Madhuri test 1");
                // Create a ContentInfo object
                ContentInfo contentInfo = new ContentInfo(Encoding.UTF8.GetBytes(jsonRequestBody));
                GetPANRequest("Madhuri test 2");
                GetPANRequest(jsonRequestBody);
                GetPANRequest("Madhuri test 3");
                // Create a signed message
                SignedCms signedCms = new SignedCms(contentInfo, true);
                GetPANRequest("Madhuri test 4");
                // Create a signer
                CmsSigner signer = new CmsSigner(_certificate);
                GetPANRequest("Madhuri test 5");
                //GetPANRequest(_certificate.ToString());
                GetPANRequest("Madhuri test 5A");
                // Compute the signature
                signedCms.ComputeSignature(signer);
                GetPANRequest("Madhuri test 6");
                // Encode the signed message
                byte[] signatureBytes = signedCms.Encode();
                GetPANRequest("Madhuri test 7");
                // Convert the signature to base64 string
                string signature = Convert.ToBase64String(signatureBytes);
                GetPANRequest("Madhuri test 8");
                // Create the HTTP request message
                var request = new HttpRequestMessage(HttpMethod.Post, "https://121.240.36.237/TIN/PanInquiryAPIBackEnd");
                request.Content = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");

                // Add headers
                //DateTime currentDateTime = DateTime.Now;
                // Format the date and time as required
                string formattedDateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"); //currentDateTime.ToString("YYYY-MM-DDThh:mm:ss");
                GetPANRequest("Request_time - " + formattedDateTime);
                string Transactional_id = formattedDateTime.Replace("-", "");
                request.Headers.Add("User_ID", "V0024301");
                request.Headers.Add("Records_count", "1");
                request.Headers.Add("Request_time", formattedDateTime);
                request.Headers.Add("Transaction_ID", "V0024301 "+ ":" + DateTime.Now.ToString("yyyyMMddHHmmss").ToString()); //+ Transactional_id);
                request.Headers.Add("Version", "4");
                request.Headers.Add("Signature", signature);

                try
                {
                    var jsonRequestBody1 = Newtonsoft.Json.JsonConvert.SerializeObject(request);
                    GetPANRequest(jsonRequestBody1.ToString());
                }
                catch (Exception ex)
                {

                }
                // Send the request and get the response

                var response = await _httpClient.SendAsync(request);
                try
                {
                    GetPANResponse(response.ToString());
                }
                catch (Exception ex)
                {

                }
                // Ensure the response is successful
                response.EnsureSuccessStatusCode();

                // Read and return the response content
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                GetPANRequest(ex.Message);
            }
            return null;
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
    }

    public class PanInquiryRequestData
    {
        public string pan { get; set; }
        public string name { get; set; }
        public string fathername { get; set; }
        public string dob { get; set; }
    }


}