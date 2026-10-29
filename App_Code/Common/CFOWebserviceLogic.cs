using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer;
using System.Xml;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.IO;

/// <summary>
/// Summary description for CFOWebserviceLogic
/// </summary>
public class CFOWebserviceLogic
{
    private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);

    public DataSet InsCFOTSSPDCLApprovals(string Uid_No, int IntApprovalID, string weblink, string fileName, string RefNo) { return SqlHelper.ExecuteDataset(con, "InsCFOTSSPDCLApprovals", Uid_No, IntApprovalID, weblink, fileName, RefNo); }
    public DataSet InsCFOTSNPDCLApprovals(string Uid_No, int IntApprovalID, string weblink, string fileName) { return SqlHelper.ExecuteDataset(con, "InsCFOTSNPDCLApprovals", Uid_No, IntApprovalID, weblink, fileName); }
    public DataSet GetCFOTSSPDCLPendingApprovalDetails() { return SqlHelper.ExecuteDataset(con, "GetCFOTSSPDCLPendingApprovalDetails"); }
    public DataSet GetCFOTSNPDCLPendingApprovalDetails() { return SqlHelper.ExecuteDataset(con, "GetCFOTSNPDCLPendingApprovalDetails"); }
    public DataSet GetCFOPaymentDetailsbyDept(string uid, int deptID) { return SqlHelper.ExecuteDataset(con, "GetCFOPaymentDetailsbyDept", uid, deptID); }
    public DataSet GetCFOTSSPDCLPaymentDetails(string Uid_No) { return SqlHelper.ExecuteDataset(con, "GetCFOTSSPDCLPaymentDetails", Uid_No); }
    public DataSet GetCFOTSNPDCLPaymentDetails(string Uid_No) { return SqlHelper.ExecuteDataset(con, "GetCFOTSNPDCLPaymentDetails", Uid_No); }



    public DataSet GETCFOEntrepreneurwebsrvdtls(string Uid_No) { return SqlHelper.ExecuteDataset(con, "GETCFOEntrepreneurwebsrvdtls", Uid_No); }

    public DataSet GetCFOUIDDetails() { return SqlHelper.ExecuteDataset(con, "GetCFOUIDDetails"); }

    public DataSet GetCFOUIDDetailsBydept(string Dept) { return SqlHelper.ExecuteDataset(con, "GetCFOUIDDetailsBydept", Dept); }
    public DataSet GetCFOOfflineApprovalDetBydept(string Dept) { return SqlHelper.ExecuteDataset(con, "GetCFOOfflineApprovalDetBydept", Dept); }

    public DataSet GetCFOAllAttachments(string Uid) { return SqlHelper.ExecuteDataset(con, "GetCFOAllAttachments", Uid); }

    public DataSet InsUpdDeltbl_CAFFeeDetails(string uid, string Dept, double TSSPDCL_DEVL_CHRGS, double TSSPDCL_SEC_DEP, double TSSPDCL_SUP_CHRGS, double TSSPDCL_COST_MATERIAL, int CreatedBy) { return SqlHelper.ExecuteDataset(con, "InsUpdDeltbl_CAFFeeDetails", uid, Dept, TSSPDCL_DEVL_CHRGS, TSSPDCL_SEC_DEP, TSSPDCL_SUP_CHRGS, TSSPDCL_COST_MATERIAL, CreatedBy); }


    public DataSet InsCFOFactoriesQueryRaise(string Uid_No, string QueryDesc, DateTime Date, double AdditionalPayement) { return SqlHelper.ExecuteDataset(con, "InsCFOFactoriesQueryRaise", Uid_No, QueryDesc, Date, AdditionalPayement); }

    public DataSet InsCFOElectricalInspectorateQueryRaise(string Uid_No, string QueryDesc, DateTime Date, double AdditionalPayement) { return SqlHelper.ExecuteDataset(con, "InsCFOElectricalInspectorateQueryRaise", Uid_No, QueryDesc, Date, AdditionalPayement); }

    public DataSet InsCFOPCBQueryRaise(string Uid_No, string QueryDesc, DateTime Date, double AdditionalPayement) { return SqlHelper.ExecuteDataset(con, "InsCFOPCBQueryRaise", Uid_No, QueryDesc, Date, AdditionalPayement); }

    public DataSet InsCFOFireQueryRaise(string Uid_No, string QueryDesc, DateTime Date, double AdditionalPayement) { return SqlHelper.ExecuteDataset(con, "InsCFOFireQueryRaise", Uid_No, QueryDesc, Date, AdditionalPayement); }

    public DataSet InsCFODrugsControlAdministrationQueryRaise(string Uid_No, string QueryDesc, DateTime Date, double AdditionalPayement) { return SqlHelper.ExecuteDataset(con, "InsCFODrugsControlAdministrationQueryRaise", Uid_No, QueryDesc, Date, AdditionalPayement); }

    public DataSet InsCFOBoilersQueryRaise(string Uid_No, string QueryDesc, DateTime Date, double AdditionalPayement) { return SqlHelper.ExecuteDataset(con, "InsCFOBoilersQueryRaise", Uid_No, QueryDesc, Date, AdditionalPayement); }

    public DataSet GetCFOFactoriesQueryResponse(string Uid_No) { return SqlHelper.ExecuteDataset(con, "GetCFOFactoriesQueryResponse", Uid_No); }

    public DataSet GetCFOPCBQueryResponse(string Uid_No) { return SqlHelper.ExecuteDataset(con, "GetCFOPCBQueryResponse", Uid_No); }

    public DataSet GETCFOPCBWebservicedtls(string UID) { return SqlHelper.ExecuteDataset(con, "GETCFOPCBWebservicedtls", UID); }

    public DataSet GetCFOFireQueryResponse(string Uid_No) { return SqlHelper.ExecuteDataset(con, "GetCFOFireQueryResponse", Uid_No); }

    public DataSet GetCFOElectricalInspectorateQueryResponse(string Uid_No) { return SqlHelper.ExecuteDataset(con, "GetCFOElectricalInspectorateQueryResponse", Uid_No); }

    public DataSet GetCFODrugsControlAdministrationQueryResponse(string Uid_No) { return SqlHelper.ExecuteDataset(con, "GetCFODrugsControlAdministrationQueryResponse", Uid_No); }

    public DataSet GetCFOBoilersQueryResponse(string Uid_No) { return SqlHelper.ExecuteDataset(con, "GetCFOBoilersQueryResponse", Uid_No); }

    public DataSet InsCFOPCBPreScuitinyCompleted(string Uid, double AdditionalPayement) { return SqlHelper.ExecuteDataset(con, "InsCFOPCBPreScuitinyCompleted", Uid, AdditionalPayement); }

    public DataSet InsCFOElectricalInspectoratePreScuitinyCompleted(string Uid, double AdditionalPayement) { return SqlHelper.ExecuteDataset(con, "InsCFOElectricalInspectoratePreScuitinyCompleted", Uid, AdditionalPayement); }

    public DataSet InsCFOFactoriesPreScuitinyCompleted(string Uid, double AdditionalPayement) { return SqlHelper.ExecuteDataset(con, "InsCFOFactoriesPreScuitinyCompleted", Uid, AdditionalPayement); }

    public DataSet InsCFOFirePreScuitinyCompleted(string Uid, double AdditionalPayement) { return SqlHelper.ExecuteDataset(con, "InsCFOFirePreScuitinyCompleted", Uid, AdditionalPayement); }

    public DataSet InsCFODrugsControlAdministrationPreScuitinyCompleted(string Uid, double AdditionalPayement) { return SqlHelper.ExecuteDataset(con, "InsCFODrugsControlAdministrationPreScuitinyCompleted", Uid, AdditionalPayement); }

    public DataSet InsCFOBoilersPreScuitinyCompleted(string Uid, double AdditionalPayement) { return SqlHelper.ExecuteDataset(con, "InsCFOBoilersPreScuitinyCompleted", Uid, AdditionalPayement); }

    public DataSet GetCFOPCBPendingApprovalDetails() { return SqlHelper.ExecuteDataset(con, "GetCFOPCBPendingApprovalDetails"); }

    public DataSet GetCFOElectricalInspectoratePendingApprovalDetails() { return SqlHelper.ExecuteDataset(con, "GetCFOElectricalInspectoratePendingApprovalDetails"); }

    public DataSet GetCFOFactoriesPendingApprovalDetails() { return SqlHelper.ExecuteDataset(con, "GetCFOFactoriesPendingApprovalDetails"); }

    public DataSet GetCFOFirePendingApprovalDetails() { return SqlHelper.ExecuteDataset(con, "GetCFOFirePendingApprovalDetails"); }

    public DataSet GetCFODrugsControlAdministrationPendingApprovalDetails() { return SqlHelper.ExecuteDataset(con, "GetCFODrugsControlAdministrationPendingApprovalDetails"); }

    public DataSet GetCFODBoilersPendingApprovalDetails() { return SqlHelper.ExecuteDataset(con, "GetCFODBoilersPendingApprovalDetails"); }

    public DataSet InsCFOFireApprovals(string Uid_No, int IntApprovalID, string weblink, string fileName) { return SqlHelper.ExecuteDataset(con, "InsCFOFireApprovals", Uid_No, IntApprovalID, weblink, fileName); }

    public DataSet InsCFOPCBApprovals(string Uid_No, int IntApprovalID, string weblink, string fileName) { return SqlHelper.ExecuteDataset(con, "InsCFOPCBApprovals", Uid_No, IntApprovalID, weblink, fileName); }

    public DataSet InsCFOElectricalInspectorateApprovals(string Uid_No, int IntApprovalID, string weblink, string fileName) { return SqlHelper.ExecuteDataset(con, "InsCFOElectricalInspectorateApprovals", Uid_No, IntApprovalID, weblink, fileName); }

    public DataSet InsCFOFactoriesApprovals(string Uid_No, int IntApprovalID, string weblink, string fileName) { return SqlHelper.ExecuteDataset(con, "InsCFOFactoriesApprovals", Uid_No, IntApprovalID, weblink, fileName); }

    public DataSet InsCFODrugsControlAdministrationApprovals(string Uid_No, int IntApprovalID, string weblink, string fileName) { return SqlHelper.ExecuteDataset(con, "InsCFODrugsControlAdministrationApprovals", Uid_No, IntApprovalID, weblink, fileName); }

    public DataSet InsCFOBoilerApprovals(string Uid_No, int IntApprovalID, string weblink, string fileName) { return SqlHelper.ExecuteDataset(con, "InsCFOBoilerApprovals", Uid_No, IntApprovalID, weblink, fileName); }
    
    public DataSet GETCFOPowerWebservicedtls(string Uid_No) { return SqlHelper.ExecuteDataset(con, "GETCFOPowerWebservicedtls", Uid_No); }

    public DataSet GETCFOFactoriesebservicedtls(string Uid_No) { return SqlHelper.ExecuteDataset(con, "GETCFOFactoriesebservicedtls", Uid_No); }

    public DataSet GETCFOBoilersWebservicedtls(string Uid_No) { return SqlHelper.ExecuteDataset(con, "GETCFOBoilersWebservicedtls", Uid_No); }

    public DataSet GETCFOLineofmanuRawwebsrvdtls(string Uid_NO) { return SqlHelper.ExecuteDataset(con, "GETCFOLineofmanuRawwebsrvdtls", Uid_NO); }


}
