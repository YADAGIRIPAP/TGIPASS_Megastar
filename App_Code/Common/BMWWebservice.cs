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
using System.Xml;
using System.Threading;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

/// <summary>
/// Summary description for BMWWebservice
/// </summary>
public class BMWWebservice
{
    General gen = new General();
    BMWClass objbmw = new BMWClass();
    DB.DB con = new DB.DB();
    public BMWWebservice()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void webserviceBMW(string UIDNO)
    {
        DataSet dsdept = new DataSet();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds = objbmw.GetDepartmentonuidBMW(UIDNO);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string deptid = dt.Rows[i]["intApprovalid"].ToString();

                if (deptid == "166")
                {
                    dsdept = objbmw.getdepartmentdetailsonuidBMW(UIDNO, deptid);
                    if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                    {
                        string cafUniqueNo = dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                        string transactionId = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                        string amount = dsdept.Tables[0].Rows[0]["Approval_Fee"].ToString();
                        string bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                        string transactionStatus = "S";
                        string paymentType = "NB";
                        string indApplication = dsdept.Tables[0].Rows[0]["NICApplicationno"].ToString();
                        string additionalPayment = "F";
                        string HCEID = dsdept.Tables[0].Rows[0]["HCEID"].ToString();
                        //string WEBSERVICE_URL = "http://164.100.163.19/TSPCB/industryRegMaster/updateFeeBmw?cafUniqueNo=" + cafUniqueNo + "&transactionId=" + transactionId + "&amount=" + amount + "&bankName=" + bankName + "&transactionStatus=" + transactionStatus + "&paymentType=" + paymentType + "&indApplicationNo=" + indApplication + "&additionalPayment=" + additionalPayment + "";
                        string WEBSERVICE_URL = "https://tsocmms.nic.in/TLNPCB/industryRegMaster/updateFeeBmw?cafUniqueNo=" + cafUniqueNo + "&transactionId=" + transactionId + "&amount=" + amount + "&bankName=" + bankName + "&transactionStatus=" + transactionStatus + "&paymentType=" + paymentType + "&indApplicationNo=" + indApplication + "&additionalPayment=" + additionalPayment + "";


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
                                        if (jsonResponse.Contains("Payment Status Updated SuccessFully"))//Fee submitted successfully"))
                                        {
                                            objbmw.UpdateDepartwebserviceflagBMW(UIDNO, deptid, "C", jsonResponse, "Y");
                                            int k = gen.InsertDeptDateTracingBMW("1", dsdept.Tables[0].Rows[0]["HCEID"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "BMW", "166");
                                        }
                                        else
                                        {
                                            //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                            objbmw.UpdateDepartwebserviceflagBMW(UIDNO, deptid, "C", jsonResponse, "N");
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
                }
            }
        }
    }

}