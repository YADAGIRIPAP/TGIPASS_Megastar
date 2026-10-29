using System;
using System.Collections;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using BusinessLogic;
using System.Xml;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ServiceModel.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Text.RegularExpressions;
using Formatting = Newtonsoft.Json.Formatting;

/// <summary>
/// Summary description for OpenDataPolicyWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class OpenDataPolicyWebService : System.Web.Services.WebService
{
    public OpenDataPolicyWebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    //[WebMethod]
    //public string HelloWorld()
    //{
    //    return "Hello World";
    //}

    Cls_opendatapolicy obj_data = new Cls_opendatapolicy();
    WebClient wc = new WebClient();
    DB.DB con = new DB.DB();


    //[WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public void SFMReport(string fromdate, string todate)
    //{
    //    Cls_opendatapolicy obj = new Cls_opendatapolicy();

    //    DataSet Ds_Sfm = obj_data.DBgetTSiPASSDataset(fromdate,todate);

    //    DataTable ddatatablee = new DataTable();

    //    ddatatablee.Columns.Add("StateName");
    //    ddatatablee.Columns.Add("CenterName");
    //    ddatatablee.Columns.Add("Centertype");
    //    ddatatablee.Columns.Add("AdmissionAmount");
    //    ddatatablee.Columns.Add("InstallmentFee");
    //    ddatatablee.Columns.Add("ExaminationFee");
    //    ddatatablee.Columns.Add("fineother");
    //    ddatatablee.Columns.Add("TotalCentreRevenue");
    //    ddatatablee.Columns.Add("F-TECshare");
    //    ddatatablee.Columns.Add("F-TECRevenue");


    //    if (Ds_Sfm.Tables[0].Rows.Count > 0)
    //    {
    //        for (int i = 0; i < Ds_Sfm.Tables[0].Rows.Count; i++)
    //        {
    //            DataRow dr_sfm = ddatatablee.NewRow();

    //            string StateName = Convert.ToString(Ds_Sfm.Tables[0].Rows[i]["StateName"]);
    //            string CenterName = Convert.ToString(Ds_Sfm.Tables[0].Rows[i]["CenterName"]);
    //            string Centertype = Convert.ToString(Ds_Sfm.Tables[0].Rows[i]["Category"]);
    //            int AdmissionAmount = Convert.ToInt32(Ds_Sfm.Tables[0].Rows[i]["AdmissionAmount"]);
    //            int InstalmentFee = Convert.ToInt32(Ds_Sfm.Tables[0].Rows[i]["InstalmentFee"]);
    //            int ExaminationFee = Convert.ToInt32(Ds_Sfm.Tables[0].Rows[i]["ExaminationFee"]);
    //            int fineother = Convert.ToInt32(Ds_Sfm.Tables[0].Rows[i]["fineother"]);
    //            int TotalCentreRevenue = Convert.ToInt32(AdmissionAmount + InstalmentFee + fineother + ExaminationFee);
    //            int CompanySharePercentage = Convert.ToInt32(Ds_Sfm.Tables[0].Rows[i]["CompanySharePercentage"]);
    //            decimal centershare = Convert.ToDecimal(TotalCentreRevenue / 100) * CompanySharePercentage;

    //            dr_sfm["StateName"] = StateName;
    //            dr_sfm["CenterName"] = CenterName;
    //            dr_sfm["Centertype"] = Centertype;
    //            dr_sfm["AdmissionAmount"] = AdmissionAmount;
    //            dr_sfm["InstallmentFee"] = InstalmentFee;
    //            dr_sfm["ExaminationFee"] = ExaminationFee;
    //            dr_sfm["fineother"] = fineother;
    //            dr_sfm["TotalCentreRevenue"] = TotalCentreRevenue;
    //            dr_sfm["F-TECshare"] = CompanySharePercentage;
    //            dr_sfm["F-TECRevenue"] = centershare;
    //            ddatatablee.Rows.Add(dr_sfm);
    //        }
    //    }

    //    string retJSONs = JsonConvert.SerializeObject(ddatatablee, Formatting.Indented,
    //           new JsonSerializerSettings
    //           {
    //               ReferenceLoopHandling = ReferenceLoopHandling.Ignore
    //           });
    //    Context.Response.Write(retJSONs);
    //}

    /// <summary>
    /// TSiPASS Dataset
    /// </summary>
    /// <param name="fromdate"></param>
    /// <param name="todate"></param>
    /// <returns></returns>
    [WebMethod]
    public XmlElement GetTsipassDatasetResponse(string fromdate, string todate) { return returnXmlElement(obj_data.DBgetTSiPASSDataset(fromdate,todate)); }

    /// <summary>
    /// TSiPASS Dataset
    /// </summary>
    /// <param name="fromdate"></param>
    /// <param name="todate"></param>
    /// <returns></returns>
    //MSME Dataset(Industrial Catalog)
    [WebMethod]
    public XmlElement GetTsipassMSMEDatasetResponse(string fromdate, string todate) { return returnXmlElement(obj_data.DBgetTSiPASSMSMEDataset(fromdate, todate)); }

    /// <summary>
    /// TSiPASS Dataset
    /// </summary>
    /// <param name="fromdate"></param>
    /// <param name="todate"></param>
    /// <returns></returns>
    //Incentives (Also Please provide details of Incentive Name Details)
    [WebMethod]
    public XmlElement GetTsipassIncentivesDatasetResponse(string fromdate, string todate) { return returnXmlElement(obj_data.DBGetTsipassIncentivesDataset(fromdate, todate)); }

    /// <summary>
    /// TSiPASS Dataset
    /// </summary>
    /// <param name="fromdate"></param>
    /// <param name="todate"></param>
    /// <returns></returns>
    //Incentives Claim Approval Reports
    [WebMethod]
    public XmlElement GetTsipassIncentivesClaimApprovalReportsDatasetResponse(string fromdate, string todate) { return returnXmlElement(obj_data.DBGetTsipassIncentivesClaimApprovalReports(fromdate, todate)); }

    /// <summary>
    /// Raw Material Dataset
    /// </summary>
    /// <param name="fromdate"></param>
    /// <param name="todate"></param>
    /// <returns></returns>
    //Raw Material
    [WebMethod]
    public XmlElement GettsipassRawMaterialDatasetResponse(string fromdate, string todate) { return returnXmlElement(obj_data.DBGettsipassRawMaterial(fromdate, todate)); }

    public XmlElement returnXmlElement(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            XmlDataDocument xmldata = new XmlDataDocument(ds);
            XmlElement xmlElement = xmldata.DocumentElement;
            return xmlElement;
        }
        else
        {
            //DataSet ds1 = new DataSet("EmptyTable");
            DataTable dt = new DataTable();
            dt.Columns.Add("ErrorMessage", typeof(string));
            dt.Rows.Add("No Data Found ");
            ds.Tables.Add(dt);
            XmlDataDocument xmldata = new XmlDataDocument(ds);
            return (xmldata.DocumentElement);
        }
    }

  

}
