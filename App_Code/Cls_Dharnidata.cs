using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Reflection;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Summary description for Cls_Dharnidata
/// </summary>
public class Cls_Dharnidata
{
    string strConnectionString = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;

    //public Cls_Dharnidata()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //
    //}

    public DataTable DB_cfe_dharanistageid(string intuserid, string intQuessionaireid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataTable ds = new DataTable();
        try
        {
            con.Open();
            da = new SqlDataAdapter("cfe_dharanistageid", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = intuserid;
            da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid;
            da.Fill(ds);
            return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
        }
    }

    public string getappliantdharanistatusbyuserid(string intuserid, string intQuessionaireid, string CreatedIP)
    {
        string responsedata = string.Empty;
       
        DharaniResponse oREResponse = new DharaniResponse();
        try
        {
            responsedata = "0";
            string secretKey = ConfigurationManager.AppSettings["DharanisecretKey"].ToString();

            Dharanirequest FlimshootingObjectvo = new Dharanirequest();
            FlimshootingObjectvo.userid = Convert.ToString(intuserid);
            FlimshootingObjectvo.saltkey = Convert.ToString(intQuessionaireid);
            string source = Convert.ToString(intQuessionaireid) + secretKey;

            //FlimshootingObjectvo.userid = "1197";
            //FlimshootingObjectvo.saltkey = "1038";
            //string source = "1038" + secretKey;
            using (SHA1 sha1Hash = SHA1.Create())
            {
                //From String to byte array
                byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
                byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
                string hashCode = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                FlimshootingObjectvo.hashcode = hashCode;
                //  Console.WriteLine("The SHA1 hash of " + source + " is: " + hash);
            }

            //FlimshootingObjectvo.userid = "12345";
            //FlimshootingObjectvo.saltkey = "637109790414002498";
            //FlimshootingObjectvo.hashcode = "b241fc34dcee0ccae65e6488c8c8602bd05a9a06";
            string dharaniserver=ConfigurationManager.AppSettings["DharaniIsserver"].ToString();
            //string RegisterURL = "https://14.99.115.179:9095/tsipass/getstatus";
            string RegisterURL = "";
            if (dharaniserver=="1")
            {
                RegisterURL = ConfigurationManager.AppSettings["Dharanistatuswebapi"].ToString();
            }
            else
            {
                RegisterURL = ConfigurationManager.AppSettings["Dharanistatuswebapi_test"].ToString();
            }
           

            
            var client = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            var json = JsonConvert.SerializeObject(FlimshootingObjectvo);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = client.PostAsync(RegisterURL, content);
            var mystring = response.GetAwaiter().GetResult();
            using (content = mystring.Content)
            {
                var json1 = content.ReadAsStringAsync();
                //LogDataDharani(json1, logfilename);
                oREResponse = JsonConvert.DeserializeObject<DharaniResponse>(json1.Result);
               // LogDataDharani(oREResponse, logfilename);
                dharaniresponse secrowdata = new dharaniresponse();
                if (oREResponse != null)
                {
                    secrowdata.message = oREResponse.message;
                    if (oREResponse.message.ToUpper() == "SUCCESS")
                    {
                        if (oREResponse.result != null)
                        {
                            //secrowdata.result = oREResponse.result;
                            secrowdata.ResultCount = Convert.ToString(oREResponse.result.Count);
                            if (oREResponse.result.Count > 0)
                            {
                                var finalstatuslist = "";
                                //Result d = (Result)oREResponse.result;
                                List<Result> obj_subres = oREResponse.result;
                                foreach (var r in obj_subres)
                                {
                                    secrowdata.applicationnumber = r.applicationnumber;
                                    secrowdata.transactiondate = r.transactiondate;
                                    secrowdata.statusid = r.statusid;
                                    secrowdata.statusdescription = r.statusdescription;
                                    secrowdata.actionid = r.actionid;
                                    secrowdata.actiondescription = r.actiondescription;
                                    secrowdata.finalStatus = r.finalStatus;
                                    secrowdata.pdfinbase64string = r.pdf;

                                    string logfilename = r.finalStatus.Trim().TrimStart().TrimEnd() + "_" + r.applicationnumber + "_" + intQuessionaireid + "_" + intuserid;
                                    LogDataDharani(r.pdf, logfilename);


                                    finalstatuslist = finalstatuslist + ";" + secrowdata.finalStatus;

                                    if (r.pdf != null)
                                    {
                                        string pdfname = "Dharani" + FlimshootingObjectvo.userid + secrowdata.applicationnumber + secrowdata.actionid + DateTime.Now.ToString("dd") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("yyyy");
                                        //System.IO.File.WriteAllBytes(@"D:\Applications\TSIPASS\Attachments\testdharani.pdf", Convert.FromBase64String(r.pdf));
                                        //D:\TS-iPASSFinal\Attachments
                                        System.IO.File.WriteAllBytes(@"D:\TS-iPASSFinal\Attachments\" + pdfname + ".pdf", Convert.FromBase64String(r.pdf));
                                        secrowdata.PDFPath = "~/Attachments/" + pdfname + ".pdf";
                                        secrowdata.PDFNAME = pdfname + ".pdf";
                                    }
                                    // secrowdata.PDFPath = r.fileName;
                                    secrowdata.CreatedBy = Convert.ToString(intuserid);
                                    //secrowdata.CreatedIP = Request.ServerVariables["Remote_Addr"];
                                    secrowdata.CreatedIP = CreatedIP;
                                    //secrowdata.intQuessionaireid = FlimshootingObjectvo.saltkey;
                                    secrowdata.intQuessionaireid = Convert.ToString(intQuessionaireid);
                                    InsertdharaniLandrequriment(secrowdata);
                                    responsedata = "1";
                                }
                            }
                        }
                    }
                }
            }
            return responsedata;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public static void LogDataDharani(string strData, string ApplicationID)
    {
        string filename = ApplicationID + "-" + DateTime.Now.ToString("dd") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("yyyy");

        string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
        message += Environment.NewLine;
        message += "-----------------------------------------------------------";
        message += Environment.NewLine;
        message += string.Format("Message: {0}", strData);

        message += Environment.NewLine;
        message += "-----------------------------------------------------------";
        message += Environment.NewLine;
        string path = System.Web.HttpContext.Current.Server.MapPath("~/DharaniPDF/" + filename + ".txt");
        using (StreamWriter writer = new StreamWriter(path, true))
        {
            writer.WriteLine(message);
            writer.Close();
        }
    }

    //public DharaniResponse getappliantdharanistatusbyuserid(string intuserid,string intQuessionaireid, string CreatedIP)
    //{
    //    DharaniResponse oREResponse = new DharaniResponse();
    //    try
    //    {
    //        string secretKey = ConfigurationManager.AppSettings["DharanisecretKey"].ToString();

    //        Dharanirequest FlimshootingObjectvo = new Dharanirequest();
    //        //FlimshootingObjectvo.userid = Convert.ToString(Session["uid"]);
    //        //FlimshootingObjectvo.saltkey = Convert.ToString(Session["Applid"]);
    //        //string source = Convert.ToString(Session["Applid"]) +secretKey;

    //        FlimshootingObjectvo.userid = "1197";
    //        FlimshootingObjectvo.saltkey = "1038";
    //        string source = "1038" + secretKey;
    //        using (SHA1 sha1Hash = SHA1.Create())
    //        {
    //            //From String to byte array
    //            byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
    //            byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
    //            string hashCode = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
    //            FlimshootingObjectvo.hashcode = hashCode;
    //            //  Console.WriteLine("The SHA1 hash of " + source + " is: " + hash);
    //        }

    //        //FlimshootingObjectvo.userid = "12345";
    //        //FlimshootingObjectvo.saltkey = "637109790414002498";
    //        //FlimshootingObjectvo.hashcode = "b241fc34dcee0ccae65e6488c8c8602bd05a9a06";

    //        string RegisterURL = "https://14.99.115.179:9095/tsipass/getstatus";
    //        var client = new HttpClient();
    //        ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
    //        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
    //        var json = JsonConvert.SerializeObject(FlimshootingObjectvo);
    //        HttpContent content = new StringContent(json);
    //        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
    //        var response = client.PostAsync(RegisterURL, content);
    //        var mystring = response.GetAwaiter().GetResult();
    //        using (content = mystring.Content)
    //        {
    //            var json1 = content.ReadAsStringAsync();
    //            oREResponse = JsonConvert.DeserializeObject<DharaniResponse>(json1.Result);
    //            dharaniresponse secrowdata = new dharaniresponse();
    //            if (oREResponse != null)
    //            {
    //                secrowdata.message = oREResponse.message;
    //                if (oREResponse.message.ToUpper() == "SUCCESS")
    //                {
    //                    if (oREResponse.result != null)
    //                    {
    //                        //secrowdata.result = oREResponse.result;
    //                        secrowdata.ResultCount = Convert.ToString(oREResponse.result.Count);
    //                        if (oREResponse.result.Count > 0)
    //                        {
    //                            var finalstatuslist = "";
    //                            //Result d = (Result)oREResponse.result;
    //                            List<Result> obj_subres = oREResponse.result;
    //                            foreach (var r in obj_subres)
    //                            {
    //                                secrowdata.applicationnumber = r.applicationnumber;
    //                                secrowdata.transactiondate = r.transactiondate;
    //                                secrowdata.statusid = r.statusid;
    //                                secrowdata.statusdescription = r.statusdescription;
    //                                secrowdata.actionid = r.actionid;
    //                                secrowdata.actiondescription = r.actiondescription;
    //                                secrowdata.finalStatus = r.finalStatus;
    //                                secrowdata.pdfinbase64string = r.pdf;

    //                                finalstatuslist = finalstatuslist + ";" + secrowdata.finalStatus;

    //                                if (r.pdf != null)
    //                                {
    //                                    string pdfname = "Dharani" + FlimshootingObjectvo.userid + secrowdata.applicationnumber + secrowdata.actionid;
    //                                    //System.IO.File.WriteAllBytes(@"D:\Applications\TSIPASS\Attachments\testdharani.pdf", Convert.FromBase64String(r.pdf));
    //                                    System.IO.File.WriteAllBytes(@"D:\Applications\TSIPASS\Attachments\" + pdfname + ".pdf", Convert.FromBase64String(r.pdf));
    //                                    secrowdata.PDFPath = "~/Attachments/" + pdfname + ".pdf";
    //                                    secrowdata.PDFNAME = pdfname + ".pdf";
    //                                }
    //                                // secrowdata.PDFPath = r.fileName;
    //                                secrowdata.CreatedBy = Convert.ToString(intuserid);
    //                                //secrowdata.CreatedIP = Request.ServerVariables["Remote_Addr"];
    //                                secrowdata.CreatedIP = CreatedIP;
    //                                //secrowdata.intQuessionaireid = FlimshootingObjectvo.saltkey;
    //                                secrowdata.intQuessionaireid = Convert.ToString(intQuessionaireid);
    //                                InsertdharaniLandrequriment(secrowdata);
    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //        return oREResponse;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}


    public class dharaniresponse
    {
        public string DharaniresID { get; set; }
        public string message { get; set; }
        public string result { get; set; }
        public string ResultCount { get; set; }
        public string applicationnumber { get; set; }
        public string transactiondate { get; set; }
        public string statusid { get; set; }
        public string statusdescription { get; set; }
        public string actionid { get; set; }
        public string actiondescription { get; set; }
        public string pdfinbase64string { get; set; }
        public string PDFPath { get; set; }
        public string CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedIP { get; set; }
        public string intQuessionaireid { get; set; }
        public string PDFNAME { get; set; }
        public string finalStatus { get; set; }

    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Result
    {
        public string applicationnumber { get; set; }
        public string transactiondate { get; set; }
        public string statusid { get; set; }
        public string statusdescription { get; set; }
        public string actionid { get; set; }
        public string actiondescription { get; set; }
        public string pdf { get; set; }
        public string finalStatus { get; set; }
    }
    public class DharaniResponse
    {
        public string message { get; set; }
        public List<Result> result { get; set; }
        public string status { get; set; }
    }
    public class Dharanirequest
    {
        public string userid { get; set; }
        public string hashcode { get; set; }
        public string saltkey { get; set; }
    }

    public bool InsertdharaniLandrequriment(dharaniresponse objdata)
    {
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        bool retValue = false;
        try
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmdpacd = new SqlCommand("cfe_dharaniresponse", connection);
            cmdpacd.CommandType = CommandType.StoredProcedure;
            cmdpacd.Transaction = transaction;
            if (objdata.message == "" || objdata.message == null)
                cmdpacd.Parameters.AddWithValue("@message", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@message", SqlDbType.VarChar).Value = objdata.message.Trim();

            if (objdata.result == "" || objdata.result == null)
                cmdpacd.Parameters.AddWithValue("@result", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@result", SqlDbType.VarChar).Value = objdata.result.Trim();

            if (objdata.ResultCount == "" || objdata.ResultCount == null)
                cmdpacd.Parameters.AddWithValue("@ResultCount", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@ResultCount", SqlDbType.VarChar).Value = objdata.ResultCount.Trim();

            if (objdata.applicationnumber == "" || objdata.applicationnumber == null)
                cmdpacd.Parameters.AddWithValue("@applicationnumber", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@applicationnumber", SqlDbType.VarChar).Value = objdata.applicationnumber;

            if (objdata.transactiondate == "" || objdata.transactiondate == null)
                cmdpacd.Parameters.AddWithValue("@transactiondate", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@transactiondate", SqlDbType.VarChar).Value = objdata.transactiondate.Trim();

            if (objdata.statusid == "" || objdata.statusid == null)
                cmdpacd.Parameters.AddWithValue("@statusid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@statusid", SqlDbType.VarChar).Value = objdata.statusid.Trim();
            if (objdata.statusdescription == "" || objdata.statusdescription == null)
                cmdpacd.Parameters.AddWithValue("@statusdescription", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@statusdescription", SqlDbType.VarChar).Value = objdata.statusdescription.Trim();
            if (objdata.actionid == "" || objdata.actionid == null)
                cmdpacd.Parameters.AddWithValue("@actionid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@actionid", SqlDbType.VarChar).Value = objdata.actionid.Trim();
            if (objdata.actiondescription == "" || objdata.actiondescription == null)
                cmdpacd.Parameters.AddWithValue("@actiondescription", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@actiondescription", SqlDbType.VarChar).Value = objdata.actiondescription.Trim();
            if (objdata.pdfinbase64string == "" || objdata.pdfinbase64string == null)
                cmdpacd.Parameters.AddWithValue("@pdfinbase64string", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@pdfinbase64string", SqlDbType.VarChar).Value = objdata.pdfinbase64string.Trim();
            if (objdata.PDFPath == "" || objdata.PDFPath == null)
                cmdpacd.Parameters.AddWithValue("@PDFPath", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@PDFPath", SqlDbType.VarChar).Value = objdata.PDFPath.Trim();

            if (objdata.CreatedBy == "" || objdata.CreatedBy == null)
                cmdpacd.Parameters.AddWithValue("@CreatedBy", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@CreatedBy", SqlDbType.VarChar).Value = objdata.CreatedBy.Trim();
            if (objdata.CreatedIP == "" || objdata.CreatedIP == null)
                cmdpacd.Parameters.AddWithValue("@CreatedIP", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@CreatedIP", SqlDbType.VarChar).Value = objdata.CreatedIP.Trim();


            if (objdata.intQuessionaireid == "" || objdata.intQuessionaireid == null)
                cmdpacd.Parameters.AddWithValue("@intQuessionaireid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@intQuessionaireid", SqlDbType.VarChar).Value = objdata.intQuessionaireid.Trim();

            if (objdata.PDFNAME == "" || objdata.PDFNAME == null)
                cmdpacd.Parameters.AddWithValue("@PDFNAME", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@PDFNAME", SqlDbType.VarChar).Value = objdata.PDFNAME.Trim();

            if (objdata.finalStatus == "" || objdata.finalStatus == null)
                cmdpacd.Parameters.AddWithValue("@finalStatus", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@finalStatus", SqlDbType.VarChar).Value = objdata.finalStatus.Trim();

            cmdpacd.ExecuteNonQuery();
            retValue = true;
            //retValue = cmdpacd.ExecuteNonQuery();
            transaction.Commit();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
        return retValue;
    }




    public bool insertredirectdharaniusercfe(string UserID)
    {
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        bool retValue = false;
        try
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmdpacd = new SqlCommand("dharani_insertredirectuser", connection);
            cmdpacd.CommandType = CommandType.StoredProcedure;
            cmdpacd.Transaction = transaction;
            if (UserID == "" || UserID == null)
                cmdpacd.Parameters.AddWithValue("@UserID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@UserID", SqlDbType.VarChar).Value = UserID.Trim();
            cmdpacd.ExecuteNonQuery();
            retValue = true;
            //retValue = cmdpacd.ExecuteNonQuery();
            transaction.Commit();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
        return retValue;
    }

    public DataTable DB_statusdisabledformrocount(string intQuessionaireid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataTable ds = new DataTable();
        try
        {
            con.Open();
            da = new SqlDataAdapter("dharani_statusdisabledformrocount", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid;
            da.Fill(ds);
            return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
        }
    }

}