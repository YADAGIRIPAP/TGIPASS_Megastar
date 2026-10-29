using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using System.Data;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

/// <summary>
/// Summary description for Cls_JSONFormat
/// </summary>
public class Cls_JSONFormat
{
    public Cls_JSONFormat()
    {

      
    }

    public static DataTable ToDataTable<T>(IList<T> data)
    {
        PropertyDescriptorCollection properties =
            TypeDescriptor.GetProperties(typeof(T));
        DataTable table = new DataTable();
        foreach (PropertyDescriptor prop in properties)
            table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
        foreach (T item in data)
        {
            DataRow row = table.NewRow();
            foreach (PropertyDescriptor prop in properties)
                row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
            table.Rows.Add(row);
        }
        return table;
    }


    #region JSONserialize and DeSerialization
    /// <summary>
    /// JSON Serialization
    /// </summary>
    public static string JsonSerializer<T>(T t)
    {
        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
        MemoryStream ms = new MemoryStream();
        ser.WriteObject(ms, t);
        string jsonString = Encoding.UTF8.GetString(ms.ToArray());
        ms.Close();
        return jsonString;
    }

    public static T JsonDeserialize<T>(string jsonString)
    {
        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
        MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
        T obj = (T)ser.ReadObject(ms);
        return obj;
    }
    #endregion JSONDeserialize

    #region PostRequestByJSON
    //-------------------------------------------------------------------------------------------------------------------
    //Method Name                   :   PostRequestByJSON
    //Method Description			:	This method is used to pass the request to API and get the Response
    //Author						:	Rajesh T
    //Creation Date         		:	04 Aprl 2019
    //Modified Date         		:	
    //--------------------------------------------------------------------------------------------------------------------
    /// <summary>
    /// <c>PostRequestByJSON : </c> This method is used to pass the request to API and get the Response
    /// </summary>
    /// <param name="url">url of the API</param>
    /// <param name="postData">Input request string.</param>
    /// <returns>string</returns>// It returns the string 
    public static string PostRequestByAPI(string url, string postData)
    {
        string ret = string.Empty;

        StreamWriter requestWriter;
        byte[] byteArray = Encoding.UTF8.GetBytes(postData);
        var webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
        if (webRequest != null)
        {
            webRequest.Method = "POST";
            webRequest.ServicePoint.Expect100Continue = false;
            webRequest.Timeout = 300000;//byteArray.Length;

            webRequest.ContentType = "application/json;charset=utf-8";
            //POST the data.
            using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                requestWriter.Write(postData);
            }
        }

        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
        Stream resStream = resp.GetResponseStream();
        StreamReader reader = new StreamReader(resStream);
        ret = reader.ReadToEnd();

        return ret;
    }
    #endregion PostRequestByJSON

    #region GetRequestByAPI
    //-------------------------------------------------------------------------------------------------------------------
    //Method Name                   :   GetRequestByAPI
    //Method Description			:	This method is used to pass the request to API and get the Response
    //Author						:	Rajesh T
    //Creation Date         		:	04 Aprl 2019
    //Modified Date         		:	
    //--------------------------------------------------------------------------------------------------------------------
    /// <summary>
    /// <c>GetRequestByAPI : </c> This method is used to pass the request to API and get the Response
    /// </summary>
    /// <param name="url">url of the API</param>
    /// <returns>string</returns>// It returns the string 
    public static string GetRequestByAPI(string url)
    {
        string responseString = string.Empty;
        //ServicePointManager.Expect100Continue = true;
        //// WebClient client = new WebClient();
        //System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

        //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
        //                                       | SecurityProtocolType.Tls11
        //                                       | SecurityProtocolType.Tls12
        //                                       | SecurityProtocolType.Ssl3;
        var request = (HttpWebRequest)WebRequest.Create(url);
        var response = (HttpWebResponse)request.GetResponse();
        using (var stream = response.GetResponseStream())
        {
            using (var reader = new StreamReader(stream))
            {
                responseString = reader.ReadToEnd();
            }
        }
        return responseString;
    }
    #endregion PostRequestByJSON

    public class SerializeDeserialize<T>
    {

        StringBuilder sbData;
        StringWriter swWriter;
        XmlDocument xDoc;
        XmlNodeReader xNodeReader;
        XmlSerializer xmlSerializer;

        public SerializeDeserialize()

        {

            sbData = new StringBuilder();

        }

        public string SerializeData(T data)

        {

            XmlSerializer employeeSerializer = new XmlSerializer(typeof(T));

            swWriter = new StringWriter(sbData);

            employeeSerializer.Serialize(swWriter, data);

            return sbData.ToString();

        }



        public T DeserializeData(string dataXML)

        {

            xDoc = new XmlDocument();

            xDoc.LoadXml(dataXML);

            xNodeReader = new XmlNodeReader(xDoc.DocumentElement);

            xmlSerializer = new XmlSerializer(typeof(T));

            var employeeData = xmlSerializer.Deserialize(xNodeReader);

            T deserializedEmployee = (T)employeeData;

            return deserializedEmployee;

        }

    }

    #region NSWS webapi
    public static string PostRequestByHeaderKEYIDSECERTAPI(string RegisterURL, string postData, string access_id, string access_secret, string APIKEY)
    {
        string ret = string.Empty;
        var client = new HttpClient();
        //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("access-id", access_id);
        //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("access-secret", access_secret);
        //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("api-key", LicensePushAPIapikey);
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        HttpContent content = new StringContent(postData);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        content.Headers.Add("access-id", access_id);
        content.Headers.Add("access-secret", access_secret);
        content.Headers.Add("api-key", APIKEY);
        var response = client.PostAsync(RegisterURL, content);
        var mystring = response.GetAwaiter().GetResult();
        using (content = mystring.Content)
        {
            var json1 = content.ReadAsStringAsync();
            ret = json1.Result;
        }
        return ret;
    }

    #endregion

    #region
    
   

    #endregion

}