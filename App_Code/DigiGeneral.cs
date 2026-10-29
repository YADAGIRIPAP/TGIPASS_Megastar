using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.ServiceModel.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

/// <summary>
/// Summary description for DigiGeneral
/// </summary>
namespace DigiGeneral
{
    public static class DigiGeneral
    {
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


    }

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

}