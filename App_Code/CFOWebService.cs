using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.IO;


/// <summary>
/// Summary description for CFOWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class CFOWebService : System.Web.Services.WebService {

    CFOWebserviceLogic objFetch = new CFOWebserviceLogic();
    public CFOWebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    [WebMethod]
    public XmlElement GETCFOEntrepreneurwebsrvdtls(string Uid_No) { return returnXmlElement(objFetch.GETCFOEntrepreneurwebsrvdtls(Uid_No)); }

    [WebMethod]
    public XmlElement InsCFOTSSPDCLApprovals(string Uid_No, int IntApprovalID, string weblink, string fileName, string RefNo) { return returnXmlElement(objFetch.InsCFOTSSPDCLApprovals(Uid_No, IntApprovalID, weblink, fileName, RefNo)); }

    [WebMethod]
    public XmlElement InsCFOTSNPDCLApprovals(string Uid_No, int IntApprovalID, string weblink, string fileName) { return returnXmlElement(objFetch.InsCFOTSNPDCLApprovals(Uid_No, IntApprovalID, weblink, fileName)); }
    [WebMethod]
    public XmlElement GetCFOTSSPDCLPendingApprovalDetails() { return returnXmlElement(objFetch.GetCFOTSSPDCLPendingApprovalDetails()); }
    [WebMethod]
    public XmlElement GetCFOTSNPDCLPendingApprovalDetails() { return returnXmlElement(objFetch.GetCFOTSNPDCLPendingApprovalDetails()); }
    [WebMethod]
    public XmlElement GetCFOPaymentDetailsbyDept(string uid, int deptID) { return returnXmlElement(objFetch.GetCFOPaymentDetailsbyDept(uid, deptID)); }
    [WebMethod]
    public XmlElement GetCFOTSSPDCLPaymentDetails(string Uid_No) { return returnXmlElement(objFetch.GetCFOTSSPDCLPaymentDetails(Uid_No)); }
    [WebMethod]
    public XmlElement GetCFOTSNPDCLPaymentDetails(string Uid_No) { return returnXmlElement(objFetch.GetCFOTSNPDCLPaymentDetails(Uid_No)); }

    [WebMethod]
    public XmlElement GetCFOUIDDetails() { return returnXmlElement(objFetch.GetCFOUIDDetails()); }

    [WebMethod]
    public XmlElement GetCFOUIDDetailsBydept(string Dept) { return returnXmlElement(objFetch.GetCFOUIDDetailsBydept(Dept)); }


    [WebMethod]
    public XmlElement GetCFOOfflineApprovalDetailsBydept(string Dept) { return returnXmlElement(objFetch.GetCFOOfflineApprovalDetBydept(Dept)); }

    [WebMethod]
    public XmlElement GetCFOAllAttachments(string Uid) { return returnXmlElement(objFetch.GetCFOAllAttachments(Uid)); }

    [WebMethod]
    public XmlElement InsertTSSPDCLPaymentDetails(double TSSPDCL_DEVL_CHRGS, double TSSPDCL_SEC_DEP, double TSSPDCL_SUP_CHRGS, double TSSPDCL_COST_MATERIAL, string uid)
    { return returnXmlElement(objFetch.InsUpdDeltbl_CAFFeeDetails(uid, "8", TSSPDCL_DEVL_CHRGS, TSSPDCL_SEC_DEP, TSSPDCL_SUP_CHRGS, TSSPDCL_COST_MATERIAL, 0)); }

    [WebMethod]
    public XmlElement InsertTSNPDCLPaymentDetails(double Develop_CHRGS, double SEC_DEP, double Ser_CHRGS, double RegFee, string uid)
    { return returnXmlElement(objFetch.InsUpdDeltbl_CAFFeeDetails(uid, "7", Develop_CHRGS, SEC_DEP, Ser_CHRGS, RegFee, 0)); }


    [WebMethod]
    public XmlElement InsCFOFactoriesQueryRaise(string Uid_No, string QueryDesc, DateTime Date, double AdditionalPayement) { return returnXmlElement(objFetch.InsCFOFactoriesQueryRaise(Uid_No, QueryDesc, Date, AdditionalPayement)); }

    [WebMethod]
    public XmlElement InsCFOElectricalInspectorateQueryRaise(string Uid_No, string QueryDesc, DateTime Date, double AdditionalPayement) { return returnXmlElement(objFetch.InsCFOElectricalInspectorateQueryRaise(Uid_No, QueryDesc, Date, AdditionalPayement)); }

    [WebMethod]
    public XmlElement InsCFOPCBQueryRaise(string Uid_No, string QueryDesc, DateTime Date, double AdditionalPayement) { return returnXmlElement(objFetch.InsCFOPCBQueryRaise(Uid_No, QueryDesc, Date, AdditionalPayement)); }

    [WebMethod]
    public XmlElement InsCFOFireQueryRaise(string Uid_No, string QueryDesc, DateTime Date, double AdditionalPayement) { return returnXmlElement(objFetch.InsCFOFireQueryRaise(Uid_No, QueryDesc, Date, AdditionalPayement)); }

    [WebMethod]
    public XmlElement InsCFODrugsControlAdministrationQueryRaise(string Uid_No, string QueryDesc, DateTime Date, double AdditionalPayement) { return returnXmlElement(objFetch.InsCFODrugsControlAdministrationQueryRaise(Uid_No, QueryDesc, Date, AdditionalPayement)); }

    [WebMethod]
    public XmlElement InsCFOBoilersQueryRaise(string Uid_No, string QueryDesc, DateTime Date, double AdditionalPayement) { return returnXmlElement(objFetch.InsCFOBoilersQueryRaise(Uid_No, QueryDesc, Date, AdditionalPayement)); }

    [WebMethod]
    public XmlElement GetCFOFactoriesQueryResponse(string Uid_No) { return returnXmlElement(objFetch.GetCFOFactoriesQueryResponse(Uid_No)); }

    [WebMethod]
    public XmlElement GetCFOPCBQueryResponse(string Uid_No) { return returnXmlElement(objFetch.GetCFOPCBQueryResponse(Uid_No)); }

    [WebMethod]
    public XmlElement GetCFOFireQueryResponse(string Uid_No) { return returnXmlElement(objFetch.GetCFOFireQueryResponse(Uid_No)); }

    [WebMethod]
    public XmlElement GetCFOElectricalInspectorateQueryResponse(string Uid_No) { return returnXmlElement(objFetch.GetCFOElectricalInspectorateQueryResponse(Uid_No)); }

    [WebMethod]
    public XmlElement GetCFODrugsControlAdministrationQueryResponse(string Uid_No) { return returnXmlElement(objFetch.GetCFODrugsControlAdministrationQueryResponse(Uid_No)); }

    [WebMethod]
    public XmlElement GetCFOBoilersQueryResponse(string Uid_No) { return returnXmlElement(objFetch.GetCFOBoilersQueryResponse(Uid_No)); }

    [WebMethod]
    public XmlElement InsCFOPCBPreScuitinyCompleted(string Uid, double AdditionalPayement) { return returnXmlElement(objFetch.InsCFOPCBPreScuitinyCompleted(Uid, AdditionalPayement)); }

    [WebMethod]
    public XmlElement InsCFOElectricalInspectoratePreScuitinyCompleted(string Uid, double AdditionalPayement) { return returnXmlElement(objFetch.InsCFOElectricalInspectoratePreScuitinyCompleted(Uid, AdditionalPayement)); }

    [WebMethod]
    public XmlElement InsCFOFactoriesPreScuitinyCompleted(string Uid, double AdditionalPayement) { return returnXmlElement(objFetch.InsCFOFactoriesPreScuitinyCompleted(Uid, AdditionalPayement)); }

    [WebMethod]
    public XmlElement InsCFOFirePreScuitinyCompleted(string Uid, double AdditionalPayement) { return returnXmlElement(objFetch.InsCFOFirePreScuitinyCompleted(Uid, AdditionalPayement)); }

    [WebMethod]
    public XmlElement InsCFODrugsControlAdministrationPreScuitinyCompleted(string Uid, double AdditionalPayement) { return returnXmlElement(objFetch.InsCFODrugsControlAdministrationPreScuitinyCompleted(Uid, AdditionalPayement)); }

    [WebMethod]
    public XmlElement InsCFOBoilersPreScuitinyCompleted(string Uid, double AdditionalPayement) { return returnXmlElement(objFetch.InsCFOBoilersPreScuitinyCompleted(Uid, AdditionalPayement)); }

    [WebMethod]
    public XmlElement GetCFOPCBPendingApprovalDetails() { return returnXmlElement(objFetch.GetCFOPCBPendingApprovalDetails()); }

    [WebMethod]
    public XmlElement GetCFOElectricalInspectoratePendingApprovalDetails() { return returnXmlElement(objFetch.GetCFOElectricalInspectoratePendingApprovalDetails()); }

    [WebMethod]
    public XmlElement GetCFOFactoriesPendingApprovalDetails() { return returnXmlElement(objFetch.GetCFOFactoriesPendingApprovalDetails()); }

    [WebMethod]
    public XmlElement GetCFOFirePendingApprovalDetails() { return returnXmlElement(objFetch.GetCFOFirePendingApprovalDetails()); }

    [WebMethod]
    public XmlElement GetCFODrugsControlAdministrationPendingApprovalDetails() { return returnXmlElement(objFetch.GetCFODrugsControlAdministrationPendingApprovalDetails()); }

    [WebMethod]
    public XmlElement GetCFODBoilersPendingApprovalDetails() { return returnXmlElement(objFetch.GetCFODBoilersPendingApprovalDetails()); }

    [WebMethod]
    public XmlElement InsCFOFireApprovals(string Uid_No, int IntApprovalID, string weblink, string fileName)
    { return returnXmlElement_Approval(objFetch.InsCFOFireApprovals(Uid_No, IntApprovalID, weblink, fileName)); }

    [WebMethod]
    public XmlElement InsCFOPCBApprovals(string Uid_No, int IntApprovalID, string weblink, string fileName)
    { return returnXmlElement_Approval(objFetch.InsCFOPCBApprovals(Uid_No, IntApprovalID, weblink, fileName)); }

    [WebMethod]
    public XmlElement InsCFOElectricalInspectorateApprovals(string Uid_No, int IntApprovalID, string weblink, string fileName)
    { return returnXmlElement_Approval(objFetch.InsCFOElectricalInspectorateApprovals(Uid_No, IntApprovalID, weblink, fileName)); }

    [WebMethod]
    public XmlElement InsCFOFactoriesApprovals(string Uid_No, int IntApprovalID, string weblink, string fileName)
    { return returnXmlElement_Approval(objFetch.InsCFOFactoriesApprovals(Uid_No, IntApprovalID, weblink, fileName)); }

    [WebMethod]
    public XmlElement InsCFODrugsControlAdministrationApprovals(string Uid_No, int IntApprovalID, string weblink, string fileName)
    { return returnXmlElement_Approval(objFetch.InsCFODrugsControlAdministrationApprovals(Uid_No, IntApprovalID, weblink, fileName)); }

    [WebMethod]
    public XmlElement InsCFOBoilerApprovals(string Uid_No, int IntApprovalID, string weblink, string fileName)
    { return returnXmlElement_Approval(objFetch.InsCFOBoilerApprovals(Uid_No, IntApprovalID, weblink, fileName)); }

    [WebMethod]
    public XmlElement GETCFOPCBWebservicedtls(string UID) { return returnXmlElement(objFetch.GETCFOPCBWebservicedtls(UID)); }

    [WebMethod]
    public XmlElement GETCFOPowerWebservicedtls(string Uid_No) { return returnXmlElement(objFetch.GETCFOPowerWebservicedtls(Uid_No)); }

    [WebMethod]
    public XmlElement GETCFOFactoriesWebservicedtls(string Uid_No) { return returnXmlElement(objFetch.GETCFOFactoriesebservicedtls(Uid_No)); }

    [WebMethod]
    public XmlElement GETCFOBoilersWebservicedtls(string Uid_No) { return returnXmlElement(objFetch.GETCFOBoilersWebservicedtls(Uid_No)); }

    [WebMethod]
    public XmlElement GETCFOLineofmanuRawwebsrvdtls(string Uid_NO) { return returnXmlElement(objFetch.GETCFOLineofmanuRawwebsrvdtls(Uid_NO)); }

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

    public XmlElement returnXmlElement_Approval(DataSet ds)
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
            dt.Rows.Add("Either Specified file cannot be downloaded / No Data found");
            ds.Tables.Add(dt);
            XmlDataDocument xmldata = new XmlDataDocument(ds);
            return (xmldata.DocumentElement);
        }
    }
}

