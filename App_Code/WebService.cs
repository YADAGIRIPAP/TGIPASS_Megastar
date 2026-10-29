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

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class WebService : System.Web.Services.WebService {

    BusinessLogic.Fetch objFetch = new BusinessLogic.Fetch();
    DML obj = new DML();
    WebClient wc = new WebClient();
    DB.DB con = new DB.DB();

    [WebMethod]
    public XmlElement GetTSNPDCLQueryResponse(string Uid_No) { return returnXmlElement(objFetch.GetTSNPDCLQueryResponse(Uid_No)); }

    [WebMethod]
    public XmlElement GetTSSPDCLQueryResponse(string Uid_No) { return returnXmlElement(objFetch.GetTSSPDCLQueryResponse(Uid_No)); }

    [WebMethod]
    public XmlElement InsPCBApprovals(string Uid_No, int IntApprovalID, string weblink, string fileName) { return returnXmlElement(obj.InsPCBApprovals(Uid_No, IntApprovalID, weblink, fileName)); }

    [WebMethod]
    public XmlElement InsPCBPreScuitinyCompleted(string Uid_No, double AdditionalPayement) { return returnXmlElement(obj.InsPCBPreScuitinyCompleted(Uid_No, AdditionalPayement)); }

    [WebMethod]
    public XmlElement GetPCBQueryResponse(string Uid_No) { return returnXmlElement(objFetch.GetPCBQueryResponse(Uid_No)); }

    [WebMethod]
    public XmlElement InsTSNPDCLQueryRaise(string Uid_No, string Remarks, DateTime Date, double AdditionalPayement) { return returnXmlElement(obj.InsTSNPDCLQueryRaise(Uid_No, Remarks, Date, AdditionalPayement)); }


    [WebMethod]
    public XmlElement InsertTSSPDCLDetails(string TSSPDCL_NAMEOFSUBSTN, string TSSPDCL_EXIS_PTR_CAPACITY, string TSSPDCL_MD_REACHED, string TSSPDCL_PROLOAD_PTR, string TSSPDCL_TOT_PTR, string TSSPDCL_FROMFEEDER, string TSSPDCL_PRESLOAD_FEEDER, string TSSPDCL_NOWPROP_FEEDER, string TSSPDCL_TOT_FEEDER, string TSSPDCL_DEDI_FEEDER, string TSSPDCL_FROM_TSTRANSCO, DateTime TSSPDCL_TF_ISSUEDATE, string TSSPDCL_DESIGN_ISSUEOFFICER, string TSSPDCL_ADE_OPERATION, string TSSPDCL_DE_OPERATION, string TSSPDCL_SE_OPERATION, string TSSPDCL_HT_NO, string TSSPDCL_MOBILE_NO, string UID) { return returnXmlElement(obj.InsUpdDelTSSPDCL(TSSPDCL_NAMEOFSUBSTN, TSSPDCL_EXIS_PTR_CAPACITY, TSSPDCL_MD_REACHED, TSSPDCL_PROLOAD_PTR, TSSPDCL_TOT_PTR, TSSPDCL_FROMFEEDER, TSSPDCL_PRESLOAD_FEEDER, TSSPDCL_NOWPROP_FEEDER, TSSPDCL_TOT_FEEDER, TSSPDCL_DEDI_FEEDER, TSSPDCL_FROM_TSTRANSCO, TSSPDCL_TF_ISSUEDATE, TSSPDCL_DESIGN_ISSUEOFFICER, TSSPDCL_ADE_OPERATION, TSSPDCL_DE_OPERATION, TSSPDCL_SE_OPERATION, TSSPDCL_HT_NO, TSSPDCL_MOBILE_NO, UID)); }

    [WebMethod]
    public XmlElement InsUpdDelTSNPDCL_FeasibilityReport(string TSNPDCL_NAMEOFSUBSTN, string TSNPDCL_FEEDER, DateTime TSNPDCL_TF_ISSUEDATE, string TSNPDCL_DESIGN_ISSUEOFFICER, string TSNPDCL_ADE_OPERATION, string TSNPDCL_DE_OPERATION, string TSNPDCL_SE_OPERATION, string TSNPDCL_MOBILE_NO, string TSNPCL_Feasible_NonFeasible, string ReasonForNonFeasible, string UID, string Feasibility_document, string Feasibility_Load) { return returnXmlElement(obj.InsUpdDelTSNPDCL_FeasibilityReport(TSNPDCL_NAMEOFSUBSTN, TSNPDCL_FEEDER, TSNPDCL_TF_ISSUEDATE, TSNPDCL_DESIGN_ISSUEOFFICER, TSNPDCL_ADE_OPERATION, TSNPDCL_DE_OPERATION, TSNPDCL_SE_OPERATION, TSNPDCL_MOBILE_NO, TSNPCL_Feasible_NonFeasible, ReasonForNonFeasible, UID, Feasibility_document, Feasibility_Load)); }

    public WebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

   [WebMethod]
    public XmlElement GetUIDDetails() { return returnXmlElement(objFetch.GetUIDDetails()); }

    [WebMethod]
    public XmlElement EntrepreneurDetails(string Uid_No) { return returnXmlElement(objFetch.GETEntrepreneurwebsrvdtls(Uid_No)); }

    [WebMethod]
    public XmlElement LineofmanufactureandRawDetails(string Uid_NO) { return returnXmlElement(objFetch.GETLineofmanuRawwebsrvdtls(Uid_NO)); }

    [WebMethod]
    public XmlElement GetLandDetails(string Uid_No) { return returnXmlElement(objFetch.GETLandWebservicedtls(Uid_No)); }

    [WebMethod]
    public XmlElement GetPowerDetails(string Uid_No) { return returnXmlElement(objFetch.GETPowerWebservicedtls(Uid_No)); }

    [WebMethod]
    public XmlElement GetWaterDetails(string Uid_No) { return returnXmlElement(objFetch.GETWaterWebservicedtls(Uid_No)); }

    [WebMethod]
    public XmlElement GetFireDetails(string Uid_No) { return returnXmlElement(objFetch.GETFIREWebservicedtls(Uid_No)); }

    [WebMethod]
    public XmlElement GetAttachments(string uid) { return returnXmlElement(objFetch.tsipass_get_attachments_TSPDCL_uid(uid)); }

    [WebMethod]
    public XmlElement GetUIDTSSPDCLDetails() { return returnXmlElement(objFetch.GetUIDTSSPDCLDetails()); }

    [WebMethod]
    public XmlElement GetUIDTSNPDCLDetails() { return returnXmlElement(objFetch.GetUIDTSNPDCLDetails()); }

    [WebMethod]
    public XmlElement GetTSSPDCLDetails(string UID) { return returnXmlElement(objFetch.GetTSSPDCLDetails(UID)); }

    [WebMethod]
    public XmlElement GetForestDetails(string Uid) { return returnXmlElement(objFetch.GETForestWebservicedtls(Uid)); }

    [WebMethod]
    public XmlElement GetUIDDetailsBydept(string Dept) { return returnXmlElement(objFetch.GetUIDDetailsBydept(Dept)); }


    [WebMethod]
    public XmlElement GetOfflineApprovalDetailsBydept(string Dept) { return returnXmlElement(objFetch.GetOfflineApprovalDetBydept(Dept)); }


    [WebMethod]
    public XmlElement InsForestQueryRaise(string Uid_No, string QueryDesc, DateTime Date, double AdditionalPayement) { return returnXmlElement(obj.InsForestQueryRaise(Uid_No, QueryDesc, Date, AdditionalPayement)); }

    [WebMethod]
    public XmlElement InsHMDAQueryRaise(string Uid_No, string QueryDesc, DateTime Date, double AdditionalPayement) { return returnXmlElement(obj.InsHMDAQueryRaise(Uid_No, QueryDesc, Date, AdditionalPayement)); }

    [WebMethod]
    public XmlElement InsFactoriesQueryRaise(string Uid_No, string QueryDesc, DateTime Date, double AdditionalPayement) { return returnXmlElement(obj.InsFactoriesQueryRaise(Uid_No, QueryDesc, Date, AdditionalPayement)); }

    [WebMethod]
    public XmlElement InsPCBQueryRaise(string Uid_No, string QueryDesc, DateTime Date, double AdditionalPayment) { return returnXmlElement(obj.InsPCBQueryRaise(Uid_No, QueryDesc, Date, AdditionalPayment)); }

    [WebMethod]
    public XmlElement InsFirePreScuitinyCompleted(string Uid_No, double AdditionalPayement) { return returnXmlElement(obj.InsFirePreScuitinyCompleted(Uid_No, AdditionalPayement)); }

    [WebMethod]
    public XmlElement InsForestPreScuitinyCompleted(string Uid_No, double AdditionalPayement) { return returnXmlElement(obj.InsForestPreScuitinyCompleted(Uid_No, AdditionalPayement)); }

    [WebMethod]
    public XmlElement InsFactoriesPreScuitinyCompleted(string Uid, double AdditionalPayement) { return returnXmlElement(obj.InsFactoriesPreScuitinyCompleted(Uid, AdditionalPayement)); }

	[WebMethod]
    public XmlElement InsFireQueryRaise(string Uid_No, string Remarks, DateTime Date, double AdditionalPayement) { return returnXmlElement(obj.InsFireQueryRaise(Uid_No, Remarks, Date, AdditionalPayement)); }

    [WebMethod]
    public XmlElement GetFireQueryResponse(string Uid_No) { return returnXmlElement(objFetch.GetFireQueryResponse(Uid_No)); }

    [WebMethod]
    public XmlElement GetForestQueryResponse(string Uid_No) { return returnXmlElement(objFetch.GetForestQueryResponse(Uid_No)); }

    [WebMethod]
    public XmlElement GETPCBDetails(string UID) { return returnXmlElement(objFetch.GETPCBWebservicedtls(UID)); }

    [WebMethod]
    public XmlElement GetFactoriesQueryResponse(string Uid_No) { return returnXmlElement(objFetch.GetFactoriesQueryResponse(Uid_No)); }

    [WebMethod]
    public XmlElement GetAllAttachments(string Uid) { return returnXmlElement(objFetch.GetAllAttachments(Uid)); }

    [WebMethod]
    public XmlElement GetFirePaymentDetails(string Uid_No) { return returnXmlElement(objFetch.GetFirePaymentDetails(Uid_No)); }

    [WebMethod]
    public XmlElement GetFirePaymentDetailsbyDate(string Dates) { return returnXmlElement(objFetch.GetFirePaymentDetailsbyDate(Dates)); }

    [WebMethod]
    public XmlElement GetForestPaymentDetails(string Uid_No) { return returnXmlElement(objFetch.GetForestPaymentDetails(Uid_No)); }

    [WebMethod]
    public XmlElement GetFactoriesPaymentDetails(string Uid_No) { return returnXmlElement(objFetch.GetFactoriesPaymentDetails(Uid_No)); }

    [WebMethod]
    public XmlElement GetTSSPDCLPaymentDetails(string Uid_No) { return returnXmlElement(objFetch.GetTSSPDCLPaymentDetails(Uid_No)); }

    [WebMethod]
    public XmlElement GetTSNPDCLPaymentDetails(string Uid_No) { return returnXmlElement(objFetch.GetTSNPDCLPaymentDetails(Uid_No)); }

    [WebMethod]
    public XmlElement GetPCBPaymentDetails(string Uid_No) { return returnXmlElement(objFetch.GetPCBPaymentDetails(Uid_No)); }

    [WebMethod]
    public XmlElement GetPCBPendingApprovalDetails() { return returnXmlElement(objFetch.GetPCBPendingApprovalDetails()); }

    [WebMethod]
    public XmlElement GetTSNPDCLPendingApprovalDetails() { return returnXmlElement(objFetch.GetTSNPDCLPendingApprovalDetails()); }

    [WebMethod]
    public XmlElement GetTSSPDCLPendingApprovalDetails() { return returnXmlElement(objFetch.GetTSSPDCLPendingApprovalDetails()); }

    [WebMethod]
    public XmlElement GetFactoriesPendingApprovalDetails() { return returnXmlElement(objFetch.GetFactoriesPendingApprovalDetails()); }

    [WebMethod]
    public XmlElement GetForestpendingApprovalDetails() { return returnXmlElement(objFetch.GetForestpendingApprovalDetails()); }

    [WebMethod]
    public XmlElement GetFirependingApprovalDetails() { return returnXmlElement(objFetch.GetFirependingApprovalDetails()); }

    //[WebMethod]
    //public XmlElement InsFactoriesApprovals(string Uid_No, int IntApprovalID, string weblink, string fileName)
    //{ return (returnXmlElement((downloadfile(weblink,fileName))?obj.InsFactoriesApprovals(Uid_No, IntApprovalID, weblink, fileName):null));}

    [WebMethod]
    public int InsFactoriesApprovals(string Uid_No, int IntApprovalID, string weblink, string fileName)
    {
       // DataSet das = new DataSet("EmptyDataset");
        obj.InsFactoriesApprovals(Uid_No, IntApprovalID, weblink, fileName);
        return 1;
    }

    [WebMethod]
    public XmlElement InsFireApprovals(string Uid_No, int IntApprovalID, string weblink, string fileName)
    {
        DataSet das = new DataSet("EmptyDataset");
        das = obj.InsFireApprovals(Uid_No, IntApprovalID, weblink, fileName);
        return returnXmlElement_Approval(das);
    }

    [WebMethod]
    public XmlElement InsFireRejection(string Uid_No, int IntApprovalID, string weblink, string fileName)
    {
        DataSet das = new DataSet("EmptyDataset");
        das = obj.InsFireRejection(Uid_No, IntApprovalID, weblink, fileName);
        return returnXmlElement_Approval(das);
    }

    [WebMethod]
    public XmlElement InsTSNPDCLPreScuitinyCompleted(string Uid, double AdditionalPayement) { return returnXmlElement(obj.InsTSNPDCLPreScuitinyCompleted(Uid, AdditionalPayement)); }

    [WebMethod]
    public XmlElement InsTSSPDCLPreScuitinyCompleted(string Uid, double AdditionalPayement) { return returnXmlElement(obj.InsTSSPDCLPreScuitinyCompleted(Uid, AdditionalPayement)); }

    //[WebMethod]
    //public XmlElement InsertPaymentDetails(double Develop_CHRGS, double SEC_DEP, double Ser_CHRGS, double RegFee, string uid, string deptid, string AdditionalPaymentRaiseddate, string DemandNoticeFilepath)
    //{ 
    //    //return returnXmlElement(objFetch.InsUpdDeltbl_CAFFeeDetails(uid, deptid, Develop_CHRGS, SEC_DEP, Ser_CHRGS, RegFee, 0, AdditionalPaymentRaiseddate, DemandNoticeFilepath));
    //    DataSet das = new DataSet("EmptyDataset");
    //    das = objFetch.InsUpdDeltbl_CAFFeeDetails(uid, deptid, Develop_CHRGS, SEC_DEP, Ser_CHRGS, RegFee, 0, AdditionalPaymentRaiseddate, DemandNoticeFilepath);  

    //    DataSet dscer = new DataSet();
    //    DataSet dsuidno = new DataSet();
    //    string intQuessionaireid = "";
    //    string intCFEEnterpid = "";
    //    string intApprovalid = "";
    //    string Modified_by = "";
    //    dsuidno = GetDepartmentonuid(uid);
    //    if (dsuidno != null && dsuidno.Tables.Count > 0 && dsuidno.Tables[0].Rows.Count > 0)
    //    {
    //        intQuessionaireid = dsuidno.Tables[0].Rows[0]["intQuessionaireid"].ToString();
    //        intCFEEnterpid = dsuidno.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
    //    }

    //    dscer = GetStatusforCertificate(intQuessionaireid);

    //    if (dscer.Tables[0].Rows.Count > 0)
    //    {
    //        int result = 0;
    //        if (deptid == "7")
    //        {
    //            intApprovalid = "4";
    //            Modified_by = "1027";
    //        }
    //        else if (deptid == "8")
    //        {
    //            intApprovalid = "25";
    //            Modified_by = "1028";
    //        }
    //       // result = UpdCommissionerApprovalNew(intCFEEnterpid, deptid, intApprovalid, "15", Modified_by, intQuessionaireid);
    //    }
    //    return returnXmlElement(das);
    //}

    [WebMethod]
    public XmlElement InsertPaymentDetails(double Develop_CHRGS, double SEC_DEP, double Ser_CHRGS, double RegFee, string uid, string deptid, string AdditionalPaymentRaiseddate, string DemandNoticeFilepath
       , string RegistrationNo, string AccountNumber, string IFSCCode, string BankName, string StatusCode, string StatusDescription,
string PaymentDureDate, string TypeofWork, string DTRSdAmount, string Total_Fee)
    {
        //int result = 0;
        string lblmsg = "";
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add("ErrorCode");
        dt.Columns.Add("ErrorDescription");

        int valid = 0;
        if (deptid == "7")
        {
            if (Total_Fee == "" || Total_Fee == null)
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Please Enter Total Amount";
                dt.Rows.Add(dr);
                valid = 1;
            }
        }
        //return returnXmlElement(objFetch.InsUpdDeltbl_CAFFeeDetails(uid, deptid, Develop_CHRGS, SEC_DEP, Ser_CHRGS, RegFee, 0, AdditionalPaymentRaiseddate, DemandNoticeFilepath));
        DataSet das = new DataSet("EmptyDataset");
        if (valid == 0)
        {
            das = objFetch.InsUpdDeltbl_CAFFeeDetails(uid, deptid, Develop_CHRGS, SEC_DEP, Ser_CHRGS, RegFee, 0, AdditionalPaymentRaiseddate, DemandNoticeFilepath, RegistrationNo, AccountNumber, IFSCCode, BankName, StatusCode, StatusDescription, PaymentDureDate, TypeofWork, DTRSdAmount, Total_Fee);
        }


        DataSet dscer = new DataSet();
        DataSet dsuidno = new DataSet();
        string intQuessionaireid = "";
        string intCFEEnterpid = "";
        string intApprovalid = "";
        string Modified_by = "";
        dsuidno = GetDepartmentonuid(uid);
        if (dsuidno != null && dsuidno.Tables.Count > 0 && dsuidno.Tables[0].Rows.Count > 0)
        {
            intQuessionaireid = dsuidno.Tables[0].Rows[0]["intQuessionaireid"].ToString();
            intCFEEnterpid = dsuidno.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
        }

        dscer = GetStatusforCertificate(intQuessionaireid);

        if (dscer.Tables[0].Rows.Count > 0)
        {
            int result = 0;
            if (deptid == "7")
            {
                intApprovalid = "4";
                Modified_by = "1027";
            }
            else if (deptid == "8")
            {
                intApprovalid = "25";
                Modified_by = "1028";
            }
           // result = UpdCommissionerApprovalNew(intCFEEnterpid, deptid, intApprovalid, "15", Modified_by, intQuessionaireid);
        }
        return returnXmlElement(das);
    }

    public bool downloadfile(string weblink, string uid)
    {
        try
        {
            DataSet ds = objFetch.FetchEnterprenuerDetails(uid);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Columns.Contains("intCFEEnterpid"))
            {
                string path = Server.MapPath("") + "\\Attachments\\" + ds.Tables[0].Rows[0]["intCFEEnterpid"].ToString() + "\\ApprovalDocument";
                string[] targetfileName = weblink.Replace(@"\", "/").Split('/');
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                wc.DownloadFile(weblink, path + "\\" + targetfileName[targetfileName.Length - 1]);
                return true;
            }
            else { return false; }
        }
        catch (Exception) { return false; }
    }

    public XmlElement returnXmlElement(DataSet ds)
    {
        if (ds != null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count > 0)
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

    public DataSet GetDepartmentonuid(string uidno)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_ENTERID_UIDNO", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (uidno.Trim() != "" || uidno.Trim() != null)
            {
                da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = uidno.ToString();
            }
            else
            {
                da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = null;
            }
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

    public DataSet GetStatusforCertificate(string intQuessionaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[GetStatusforCertificate_Websrv]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.ToString();

            da.Fill(ds);
            return ds;

        }
        catch (Exception ex)
        {
            return null;
        }
        finally
        {
            con.CloseConnection();
        }
    }

    public int UpdCommissionerApprovalNew(string intCFEEnterpid, string intDeptid, string intApprovalid, string intStageid, string Created_by, string intQid)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[UpdCommissionerApprovalNew_websrv]";

        if (intCFEEnterpid == "" || intCFEEnterpid == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (intDeptid == "" || intDeptid == null)
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();

        if (intApprovalid == "" || intApprovalid == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();

        if (intStageid == "" || intStageid == null)
            com.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = intStageid.Trim();

        if (Created_by == "" || Created_by == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (intQid == "" || intQid == null)
            com.Parameters.Add("@intQid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intQid", SqlDbType.VarChar).Value = intQid.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }
}

