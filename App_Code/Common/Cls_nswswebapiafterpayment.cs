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

/// <summary>
/// Summary description for Cls_nswswebapiafterpayment
/// </summary>
public class Cls_nswswebapiafterpayment
{
    string strConnectionString = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;

  
    public bool DB_samplepaymentupdatecfe(string intUserid)
    {
        bool output = true;
        SqlConnection con = new SqlConnection(strConnectionString);
        try
        {
            SqlCommand cmdsrc1 = new SqlCommand("nsws_samplepaymentupdatecfe", con);
            if (Convert.ToString(intUserid) == "" || Convert.ToString(intUserid) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@intUserid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@intUserid", Convert.ToString(intUserid));
            }
            cmdsrc1.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmdsrc1.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            output = false;
        }

        return output;
    }


    public DataSet DB_insertnswscafdatacfedata(string intUserid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("nsws_datatocfeques", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@intUserid", SqlDbType.VarChar).Value = intUserid;
            da.SelectCommand.CommandTimeout = 3600;
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


    #region after payment send licensce to web api
    public DataTable DB_getdataapprovaldepartmenttopushliecensebyUIDNO(string UIDNO, string CategoryType)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataTable ds = new DataTable();
        try
        {
            con.Open();
            da = new SqlDataAdapter("nsws_getdapprovaldeptstoopushliecenseafterpaymentbyUIDNO", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = UIDNO;
            da.SelectCommand.Parameters.Add("@CategoryType", SqlDbType.VarChar).Value = CategoryType;
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
    public string sendapprovalsdeptafterpaymenttonswsAPI(string UIDNO, string CategoryType)
    {
        string responsedata = string.Empty;
        try
        {
            DataTable dt_approvalaftpayment = DB_getdataapprovaldepartmenttopushliecensebyUIDNO(UIDNO, CategoryType);
            if (dt_approvalaftpayment.Rows.Count > 0)
            {
                //  access_id: MIN_TEST_0
                //  access_secret:MintesT@1234
                //    License Push API Min1@PLD11
                //string RegisterURL = "https://uat-nsws-mnstrportal.investindia.gov.in/nsws_license/pushLincenceDetails";
                string access_id = ""; string access_secret = ""; string APIKEY = ""; string RegisterURL = "";

                if (Convert.ToString(ConfigurationManager.AppSettings["NSWSIsserver"]) == "1")
                {
                    access_id = Convert.ToString(ConfigurationManager.AppSettings["NSWSaccessid"]);
                    access_secret = Convert.ToString(ConfigurationManager.AppSettings["NSWSaccess_secret"]);
                    APIKEY = Convert.ToString(ConfigurationManager.AppSettings["NswsPushLicenseafterpaymentAPIKEY"]);
                    RegisterURL = Convert.ToString(ConfigurationManager.AppSettings["NswsPushLicenseafterpaymentAPI"]);
                }
                else
                {
                    if (Convert.ToString(ConfigurationManager.AppSettings["NSWSIsserverPPE"]) == "1")
                    {
                        access_id = Convert.ToString(ConfigurationManager.AppSettings["PPE_NSWSaccessid"]);
                        access_secret = Convert.ToString(ConfigurationManager.AppSettings["PPE_NSWSaccess_secret"]);
                        APIKEY = Convert.ToString(ConfigurationManager.AppSettings["PPE_NswsPushLicenseafterpaymentAPIKEY"]);
                        RegisterURL = Convert.ToString(ConfigurationManager.AppSettings["PPE_NswsPushLicenseafterpaymentAPI"]);
                    }
                    else
                    {
                        access_id = Convert.ToString(ConfigurationManager.AppSettings["testNSWSaccessid"]);
                        access_secret = Convert.ToString(ConfigurationManager.AppSettings["testNSWSaccess_secret"]);
                        APIKEY = Convert.ToString(ConfigurationManager.AppSettings["testNswsPushLicenseafterpaymentAPIKEY"]);
                        RegisterURL = Convert.ToString(ConfigurationManager.AppSettings["testNswsPushLicenseafterpaymentAPI"]);
                    }
                }


                List<requestnswspushlicesesafterpayment> studentList = new List<requestnswspushlicesesafterpayment>();
                for (int i = 0; i < dt_approvalaftpayment.Rows.Count; i++)
                {
                    requestnswspushlicesesafterpayment listofapprovals = new requestnswspushlicesesafterpayment();
                    listofapprovals.licenseId = Convert.ToString(dt_approvalaftpayment.Rows[i]["licenseId"]);
                    listofapprovals.licenseVer = Convert.ToString(dt_approvalaftpayment.Rows[i]["licenseVer"]);
                    listofapprovals.swsId = Convert.ToString(dt_approvalaftpayment.Rows[i]["swsId"]);
                    listofapprovals.investorReqId = Convert.ToString(dt_approvalaftpayment.Rows[i]["investorReqId"]);
                    listofapprovals.licenseReqDate = Convert.ToString(dt_approvalaftpayment.Rows[i]["licenseReqDate"]);
                    listofapprovals.ministeryId = Convert.ToString(dt_approvalaftpayment.Rows[i]["ministeryId"]);
                    listofapprovals.departmentId = Convert.ToString(dt_approvalaftpayment.Rows[i]["departmentId"]);
                    studentList.Add(listofapprovals);
                }

                var postData = JsonConvert.SerializeObject(studentList);
                responsedata = Cls_JSONFormat.PostRequestByHeaderKEYIDSECERTAPI(RegisterURL, postData, access_id, access_secret, APIKEY);

                // PostRequestByHeaderKEYIDSECERTAPI(string RegisterURL, string postData, string access_id, string access_secret, string APIKEY)

                DB_insertresponseofredircturldata(UIDNO, CategoryType, "Y", responsedata);
                responsenswspushlicensenswsafterpayment oREResponse = new responsenswspushlicensenswsafterpayment();
                oREResponse = JsonConvert.DeserializeObject<responsenswspushlicensenswsafterpayment>(responsedata);
            }
            return responsedata;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public class responsenswspushlicensenswsafterpayment
    {
        public string status { get; set; }
        public string message { get; set; }
        public LicenseReqid licenseReqid { get; set; }

    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class LicenseReqid
    {
        public List<string> duplicateId { get; set; }
        public List<object> savedId { get; set; }
    }
    public class requestnswspushlicesesafterpayment
    {
        public string licenseId { get; set; }
        public string licenseVer { get; set; }
        public string swsId { get; set; }
        public string investorReqId { get; set; }
        public string licenseReqDate { get; set; }
        public string ministeryId { get; set; }
        public string departmentId { get; set; }


        //Array List
        // License id (Preconfigured Approval/License Id for each License/Approval),
        //License version(License Version),
        //SWS investor id(Unique identifier for each investor registered in NSWS),
        //Investor Req id/CAF id(Customer Application Form Id),
        //License request date(Date and time on which Approval/License has been applied in Unix Epoch format),
        //State id(Predefined id specific to each State),
        //Department id(Predefined Id for each Department in each State)}


        //        "status": "409",
        //"message": "IDs in duplicate list could not be saved as its already present",
        //"licenseReqid": {
        //    "duplicateId": [
        //        "SW8577172400-S009_D005_A0001-1612426700678",
        //        "SW8577172400-S009_D013_A0004-1612426700677",
        //        "SW8577172400-S009_D009_A0001-1612426700677"
        //    ],
        //    "savedId": []
    }
    public bool DB_insertresponseofredircturldata(string UIDNO, string CategoryType, string NSWSrespFLG, string NSWSresponse)
    {
        bool output = true;
        SqlConnection con = new SqlConnection(strConnectionString);
        try
        {
            SqlCommand cmdsrc1 = new SqlCommand("nsws_insertresponseafterafterpaymentbyUIDNO", con);
            if (Convert.ToString(UIDNO) == "" || Convert.ToString(UIDNO) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@UIDNO", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@UIDNO", Convert.ToString(UIDNO));
            }
            if (Convert.ToString(CategoryType) == "" || Convert.ToString(CategoryType) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@CategoryType", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@CategoryType", Convert.ToString(CategoryType));
            }
            if (Convert.ToString(NSWSresponse) == "" || Convert.ToString(NSWSresponse) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@NSWSresponse", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@NSWSresponse", Convert.ToString(NSWSresponse));
            }
            if (Convert.ToString(NSWSrespFLG) == "" || Convert.ToString(NSWSrespFLG) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@NSWSrespFLG", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@NSWSrespFLG", Convert.ToString(NSWSrespFLG));
            }

            cmdsrc1.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmdsrc1.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            output = false;
        }

        return output;
    }

    #endregion

    #region after payment send licensce status update as recivced to web api

    public DataSet DB_getlicensesStatusafterpaymentbyUIDNO(string UIDNO, string CategoryType)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("nsws_getlicensesStatusafterpaymentbyUIDNO", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = UIDNO;
            da.SelectCommand.Parameters.Add("@CategoryType", SqlDbType.VarChar).Value = CategoryType;
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
    public string getlicencesstatusupdateafterpayment(string UIDNO, string CategoryType)
    {
        string strjsonresponse = string.Empty;
        try
        {
            DataSet dt_data = DB_getlicensesStatusafterpaymentbyUIDNO(UIDNO, CategoryType);
            if (dt_data.Tables.Count > 0)
            {
                if (dt_data.Tables[0].Rows.Count > 0)
                {
                    DataTable dt_department = dt_data.Tables[0];
                    if (dt_data.Tables.Count > 1)
                    {
                        if (dt_data.Tables[1].Rows.Count > 0)
                        {
                            DataTable dt_approvals = dt_data.Tables[1];
                            for (int j = 0; j < dt_department.Rows.Count; j++)
                            {
                                requestofpushlicesestatusnsws obj_nswsdept = new requestofpushlicesestatusnsws();
                                obj_nswsdept.departmentId = Convert.ToString(dt_department.Rows[j]["departmentId"]);
                                obj_nswsdept.ministryStateId = Convert.ToString(dt_department.Rows[j]["ministryStateId"]);

                                List<licenseStastusList> approvalstatusIlist = new List<licenseStastusList>();
                                for (int i = 0; i < dt_approvals.Rows.Count; i++)
                                {
                                    licenseStastusList liststatusapprovalsdata = new licenseStastusList();

                                    if (Convert.ToString(dt_department.Rows[j]["departmentId"]) == Convert.ToString(dt_approvals.Rows[i]["departmentId"]))
                                    {
                                        liststatusapprovalsdata.licenseReqNum = Convert.ToString(dt_approvals.Rows[i]["licenseReqNum"]);
                                        liststatusapprovalsdata.licenseStatus = Convert.ToString(dt_approvals.Rows[i]["licenseStatus"]);
                                        approvalstatusIlist.Add(liststatusapprovalsdata);
                                    }
                                }

                                obj_nswsdept.licenseStastusList = approvalstatusIlist;

                                strjsonresponse = Callnswswebapiforlicenscestatusupdate(obj_nswsdept);
                                responseofpushliensestatusnsws res_approvalstatus = new responseofpushliensestatusnsws();
                                res_approvalstatus = JsonConvert.DeserializeObject<responseofpushliensestatusnsws>(strjsonresponse);
                                updateresponselicensesStatusafterpaymentbyUIDNO(UIDNO, CategoryType, "1", strjsonresponse, obj_nswsdept.departmentId);
                            }
                        }
                    }
                }
            }
            return strjsonresponse;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public string Callnswswebapiforlicenscestatusupdate(requestofpushlicesestatusnsws reqdepartment)
    {
        string responsedata = string.Empty;
        try
        {
            //  access_id: MIN_TEST_0
            //  access_secret:MintesT@1234
            //    License Push API Min1@PLS07

            //string access_id = "MIN_TEST_0";
            //string access_secret = "MintesT@1234";
            //string LicensePushAPIapikey = "Min1@PLS07";
            //string RegisterURL = "https://uat-nsws-mnstrportal.investindia.gov.in/nsws_license/postLicenseStatus";

            string access_id = ""; string access_secret = ""; string APIKEY = ""; string RegisterURL = "";
            if (Convert.ToString(ConfigurationManager.AppSettings["NSWSIsserver"]) == "1")
            {
                access_id = Convert.ToString(ConfigurationManager.AppSettings["NSWSaccessid"]);
                access_secret = Convert.ToString(ConfigurationManager.AppSettings["NSWSaccess_secret"]);
                APIKEY = Convert.ToString(ConfigurationManager.AppSettings["NswsLicenseStatusAPIKEY"]);
                RegisterURL = Convert.ToString(ConfigurationManager.AppSettings["NswsLicenseStatusAPI"]);
            }
            else
            {
                if (Convert.ToString(ConfigurationManager.AppSettings["NSWSIsserverPPE"]) == "1")
                {
                    access_id = Convert.ToString(ConfigurationManager.AppSettings["PPE_NSWSaccessid"]);
                    access_secret = Convert.ToString(ConfigurationManager.AppSettings["PPE_NSWSaccess_secret"]);
                    APIKEY = Convert.ToString(ConfigurationManager.AppSettings["PPE_NswsLicenseStatusAPIKEY"]);
                    RegisterURL = Convert.ToString(ConfigurationManager.AppSettings["PPE_NswsLicenseStatusAPI"]);
                }
                else
                {
                    access_id = Convert.ToString(ConfigurationManager.AppSettings["testNSWSaccessid"]);
                    access_secret = Convert.ToString(ConfigurationManager.AppSettings["testNSWSaccess_secret"]);
                    APIKEY = Convert.ToString(ConfigurationManager.AppSettings["testNswsLicenseStatusAPIKEY"]);
                    RegisterURL = Convert.ToString(ConfigurationManager.AppSettings["testNswsLicenseStatusAPI"]);
                }
            }
            LogErrorFile.LogData(Convert.ToString(RegisterURL));

            var postData = JsonConvert.SerializeObject(reqdepartment);
            LogErrorFile.LogData(Convert.ToString(postData));
            responsedata = Cls_JSONFormat.PostRequestByHeaderKEYIDSECERTAPI(RegisterURL, postData, access_id, access_secret, APIKEY);
            // PostRequestByHeaderKEYIDSECERTAPI(string RegisterURL, string postData, string access_id, string access_secret, string APIKEY)
            LogErrorFile.LogData(Convert.ToString(responsedata));
            return responsedata;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public class requestofpushlicesestatusnsws
    {
        public string departmentId { get; set; }
        public string ministryStateId { get; set; }
        public IList<licenseStastusList> licenseStastusList { get; set; }
    }
    public class licenseStastusList
    {

        public string licenseReqNum { get; set; }
        public string licenseStatus { get; set; }

        //            Department identification attribute(deptmentId)
        //State identification attribute(ministryStateId)
        //Array List
        //            {
        //{ licenseReqNum: SWS_ID - License_ID - RequestDateTime, License Status }
        //{ licenseReqNum: SWS_ID - License_ID - RequestDateTime, License Status }
        //            }

        //            {
        //"departmentId":"S009_D006",
        //"ministryStateId":"29",
        //"licenseStastusList":[
        //  {
        //   "licenseReqNum":"SW8577172400-S009_D006_A0001-1622623995",
        //   "licenseStatus":"I"
        //  }
        // ]
        //}

    }
    public class responseofpushliensestatusnsws
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<string> response { get; set; }
    }
    public bool updateresponselicensesStatusafterpaymentbyUIDNO(string UIDNO, string CategoryType, string NSWSrespFLG, string NSWSresponse, string DeptID)
    {
        bool output = true;
        SqlConnection con = new SqlConnection(strConnectionString);
        try
        {
            SqlCommand cmdsrc1 = new SqlCommand("nsws_updateresponselicensesStatusafterpaymentbyUIDNO", con);
            if (Convert.ToString(UIDNO) == "" || Convert.ToString(UIDNO) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@UIDNO", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@UIDNO", Convert.ToString(UIDNO));
            }
            if (Convert.ToString(CategoryType) == "" || Convert.ToString(CategoryType) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@CategoryType", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@CategoryType", Convert.ToString(CategoryType));
            }
            if (Convert.ToString(DeptID) == "" || Convert.ToString(DeptID) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@DeptID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@DeptID", Convert.ToString(DeptID));
            }
            if (Convert.ToString(NSWSresponse) == "" || Convert.ToString(NSWSresponse) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@Response", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@Response", Convert.ToString(NSWSresponse));
            }
            if (Convert.ToString(NSWSrespFLG) == "" || Convert.ToString(NSWSrespFLG) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@ResponseFLG", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@ResponseFLG", Convert.ToString(NSWSrespFLG));
            }

            cmdsrc1.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmdsrc1.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            output = false;
        }

        return output;
    }

    #endregion

    #region call query raised
    public DataSet DB_getqueryraiseforreqbyDeptIDApprovalID(string ApplicationID, string DeptID, string ApprovalID, string CategoryType)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("nsws_getqueryraiseforreqbyDeptIDApprovalIDs", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Convert.ToString(ApplicationID) == "" || Convert.ToString(ApplicationID) == null)
            {
                da.SelectCommand.Parameters.AddWithValue("@ApplicationID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@ApplicationID", SqlDbType.VarChar).Value = ApplicationID;
            }
            if (Convert.ToString(DeptID) == "" || Convert.ToString(DeptID) == null)
            {
                da.SelectCommand.Parameters.AddWithValue("@DeptID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@DeptID", SqlDbType.VarChar).Value = DeptID;
            }
            if (Convert.ToString(ApprovalID) == "" || Convert.ToString(ApprovalID) == null)
            {
                da.SelectCommand.Parameters.AddWithValue("@ApprovalID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@ApprovalID", SqlDbType.VarChar).Value = ApprovalID;
            }
            if (Convert.ToString(CategoryType) == "" || Convert.ToString(CategoryType) == null)
            {
                da.SelectCommand.Parameters.AddWithValue("@CategoryType", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                da.SelectCommand.Parameters.AddWithValue("@CategoryType", Convert.ToString(CategoryType));
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
            con.Close();
        }
    }
    public string callwebapitosendqueryraiseddata(string ApplicationID, string DeptID, string ApprovalID, string CategoryType)
    {
        string responsedata = string.Empty;
        try
        {
            DataSet dt_data = DB_getqueryraiseforreqbyDeptIDApprovalID(ApplicationID, DeptID, ApprovalID, CategoryType);
            if (dt_data.Tables.Count > 0)
            {
                if (dt_data.Tables.Count >= 1)
                {
                    if (dt_data.Tables[0].Rows.Count > 0)
                    {
                        requestqueryraised reqdepartment = new requestqueryraised();
                        reqdepartment.ministryId = Convert.ToString(dt_data.Tables[0].Rows[0]["ministryId"]);
                        reqdepartment.departmentId = Convert.ToString(dt_data.Tables[0].Rows[0]["departmentId"]);
                        List<LicenseIdentificationAttribute> querylistList = new List<LicenseIdentificationAttribute>();
                        LicenseIdentificationAttribute querydata = new LicenseIdentificationAttribute();
                        querydata.licenseReqId = Convert.ToString(dt_data.Tables[0].Rows[0]["licenseReqId"]);
                        querydata.queryDesc = Convert.ToString(dt_data.Tables[0].Rows[0]["queryDesc"]);
                        querydata.queryType = Convert.ToString(dt_data.Tables[0].Rows[0]["queryType"]);
                        querylistList.Add(querydata);
                        reqdepartment.licenseIdentificationAttribute = querylistList;

                        //string access_id = "MIN_TEST_0";
                        //string access_secret = "MintesT@1234";
                        //string LicensePushAPIapikey = "Min1@PLQ09 ";
                        //string RegisterURL = "https://uat-nsws-mnstrportal.investindia.gov.in/nsws_clarification/postLicenseQuery";

                        string access_id = ""; string access_secret = ""; string APIKEY = ""; string RegisterURL = "";
                        if (Convert.ToString(ConfigurationManager.AppSettings["NSWSIsserver"]) == "1")
                        {
                            access_id = Convert.ToString(ConfigurationManager.AppSettings["NSWSaccessid"]);
                            access_secret = Convert.ToString(ConfigurationManager.AppSettings["NSWSaccess_secret"]);
                            APIKEY = Convert.ToString(ConfigurationManager.AppSettings["NswsRaiseClarificationLicenseRequestAPIKEY"]);
                            RegisterURL = Convert.ToString(ConfigurationManager.AppSettings["NswsRaiseClarificationLicenseRequestAPI"]);
                        }
                        else
                        {
                            if (Convert.ToString(ConfigurationManager.AppSettings["NSWSIsserverPPE"]) == "1")
                            {
                                access_id = Convert.ToString(ConfigurationManager.AppSettings["PPE_NSWSaccessid"]);
                                access_secret = Convert.ToString(ConfigurationManager.AppSettings["PPE_NSWSaccess_secret"]);
                                APIKEY = Convert.ToString(ConfigurationManager.AppSettings["PPE_NswsRaiseClarificationLicenseRequestAPIKEY"]);
                                RegisterURL = Convert.ToString(ConfigurationManager.AppSettings["PPE_NswsRaiseClarificationLicenseRequestAPI"]);
                            }
                            else
                            {
                                access_id = Convert.ToString(ConfigurationManager.AppSettings["testNSWSaccessid"]);
                                access_secret = Convert.ToString(ConfigurationManager.AppSettings["testNSWSaccess_secret"]);
                                APIKEY = Convert.ToString(ConfigurationManager.AppSettings["testNswsRaiseClarificationLicenseRequestAPIKEY"]);
                                RegisterURL = Convert.ToString(ConfigurationManager.AppSettings["testNswsRaiseClarificationLicenseRequestAPI"]);
                            }
                        }


                        var postData = JsonConvert.SerializeObject(reqdepartment);
                        responsedata = Cls_JSONFormat.PostRequestByHeaderKEYIDSECERTAPI(RegisterURL, postData, access_id, access_secret, APIKEY);

                        // PostRequestByHeaderKEYIDSECERTAPI(string RegisterURL, string postData, string access_id, string access_secret, string APIKEY)

                        DB_updatequeryraisebyDeptIDApprovalID(ApplicationID, CategoryType, "1", responsedata, DeptID, ApprovalID);

                        responsequeryraised oREResponse = new responsequeryraised();
                        oREResponse = JsonConvert.DeserializeObject<responsequeryraised>(responsedata);
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

    public class responsequeryraised
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<string> response { get; set; }
    }
    public class requestqueryraised
    {
        public string ministryId { get; set; }
        public string departmentId { get; set; }
        public List<LicenseIdentificationAttribute> licenseIdentificationAttribute { get; set; }
    }
    public class LicenseIdentificationAttribute
    {
        public string licenseReqId { get; set; }
        public string queryDesc { get; set; }
        public string queryType { get; set; }
    }

    public bool DB_updatequeryraisebyDeptIDApprovalID(string ApplicationID, string CategoryType, string NSWSrespFLG, string NSWSresponse, string DeptID, string ApprovalID)
    {
        bool output = true;
        SqlConnection con = new SqlConnection(strConnectionString);
        try
        {
            SqlCommand cmdsrc1 = new SqlCommand("nsws_updatequeryraisebyDeptIDApprovalID", con);
            if (Convert.ToString(ApplicationID) == "" || Convert.ToString(ApplicationID) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@ApplicationID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@ApplicationID", Convert.ToString(ApplicationID));
            }
            if (Convert.ToString(CategoryType) == "" || Convert.ToString(CategoryType) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@CategoryType", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@CategoryType", Convert.ToString(CategoryType));
            }
            if (Convert.ToString(DeptID) == "" || Convert.ToString(DeptID) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@DeptID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@DeptID", Convert.ToString(DeptID));
            }
            if (Convert.ToString(NSWSresponse) == "" || Convert.ToString(NSWSresponse) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@Response", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@Response", Convert.ToString(NSWSresponse));
            }
            if (Convert.ToString(NSWSrespFLG) == "" || Convert.ToString(NSWSrespFLG) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@ResponseFLG", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@ResponseFLG", Convert.ToString(NSWSrespFLG));
            }
            if (Convert.ToString(ApprovalID) == "" || Convert.ToString(ApprovalID) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@ApprovalID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@ApprovalID", Convert.ToString(ApprovalID));
            }

            cmdsrc1.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmdsrc1.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            output = false;
        }

        return output;
    }

    public DataSet DB_getlicensesStatusafterqueryraise(string ApplicationID, string DeptID, string ApprovalID, string CategoryType)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("nsws_getlicensesStatusafterqueryraise", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Convert.ToString(ApplicationID) == "" || Convert.ToString(ApplicationID) == null)
            {
                da.SelectCommand.Parameters.AddWithValue("@ApplicationID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@ApplicationID", SqlDbType.VarChar).Value = ApplicationID;
            }
            if (Convert.ToString(DeptID) == "" || Convert.ToString(DeptID) == null)
            {
                da.SelectCommand.Parameters.AddWithValue("@DeptID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@DeptID", SqlDbType.VarChar).Value = DeptID;
            }
            if (Convert.ToString(ApprovalID) == "" || Convert.ToString(ApprovalID) == null)
            {
                da.SelectCommand.Parameters.AddWithValue("@ApprovalID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@ApprovalID", SqlDbType.VarChar).Value = ApprovalID;
            }
            if (Convert.ToString(CategoryType) == "" || Convert.ToString(CategoryType) == null)
            {
                da.SelectCommand.Parameters.AddWithValue("@CategoryType", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                da.SelectCommand.Parameters.AddWithValue("@CategoryType", Convert.ToString(CategoryType));
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
            con.Close();
        }
    }

    public string getlicencesstatusafterqueryraise(string ApplicationID, string DeptID, string ApprovalID, string CategoryType)
    {
        string strjsonresponse = string.Empty;
        try
        {
            DataSet dt_data = DB_getlicensesStatusafterqueryraise(ApplicationID, DeptID, ApprovalID, CategoryType);
            if (dt_data.Tables.Count > 0)
            {
                if (dt_data.Tables[0].Rows.Count > 0)
                {
                    DataTable dt_department = dt_data.Tables[0];
                    if (dt_data.Tables.Count > 1)
                    {
                        if (dt_data.Tables[1].Rows.Count > 0)
                        {
                            DataTable dt_approvals = dt_data.Tables[1];
                            for (int j = 0; j < dt_department.Rows.Count; j++)
                            {
                                requestofpushlicesestatusnsws obj_nswsdept = new requestofpushlicesestatusnsws();
                                obj_nswsdept.departmentId = Convert.ToString(dt_department.Rows[j]["departmentId"]);
                                obj_nswsdept.ministryStateId = Convert.ToString(dt_department.Rows[j]["ministryStateId"]);

                                List<licenseStastusList> approvalstatusIlist = new List<licenseStastusList>();
                                for (int i = 0; i < dt_approvals.Rows.Count; i++)
                                {
                                    licenseStastusList liststatusapprovalsdata = new licenseStastusList();

                                    if (Convert.ToString(dt_department.Rows[j]["departmentId"]) == Convert.ToString(dt_approvals.Rows[i]["departmentId"]))
                                    {
                                        liststatusapprovalsdata.licenseReqNum = Convert.ToString(dt_approvals.Rows[i]["licenseReqNum"]);
                                        liststatusapprovalsdata.licenseStatus = Convert.ToString(dt_approvals.Rows[i]["licenseStatus"]);
                                        approvalstatusIlist.Add(liststatusapprovalsdata);
                                    }
                                }

                                obj_nswsdept.licenseStastusList = approvalstatusIlist;

                                strjsonresponse = Callnswswebapiforlicenscestatusupdate(obj_nswsdept);
                                responseofpushliensestatusnsws res_approvalstatus = new responseofpushliensestatusnsws();
                                res_approvalstatus = JsonConvert.DeserializeObject<responseofpushliensestatusnsws>(strjsonresponse);
                                updateresponselicensesStatusafterqueryraise(ApplicationID, CategoryType, "1", strjsonresponse, DeptID, ApprovalID);
                            }
                        }
                    }
                }
            }
            return strjsonresponse;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public bool updateresponselicensesStatusafterqueryraise(string ApplicationID, string CategoryType, string NSWSrespFLG, string NSWSresponse, string DeptID, string ApprovalID)
    {
        bool output = true;
        SqlConnection con = new SqlConnection(strConnectionString);
        try
        {
            SqlCommand cmdsrc1 = new SqlCommand("nsws_updateresponselicensesStatusafterqueryraise", con);
            if (Convert.ToString(ApplicationID) == "" || Convert.ToString(ApplicationID) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@ApplicationID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.Add("@ApplicationID", SqlDbType.VarChar).Value = ApplicationID;
            }
            if (Convert.ToString(CategoryType) == "" || Convert.ToString(CategoryType) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@CategoryType", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@CategoryType", Convert.ToString(CategoryType));
            }
            if (Convert.ToString(DeptID) == "" || Convert.ToString(DeptID) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@DeptID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@DeptID", Convert.ToString(DeptID));
            }
            if (Convert.ToString(NSWSresponse) == "" || Convert.ToString(NSWSresponse) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@Response", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@Response", Convert.ToString(NSWSresponse));
            }
            if (Convert.ToString(NSWSrespFLG) == "" || Convert.ToString(NSWSrespFLG) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@ResponseFLG", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@ResponseFLG", Convert.ToString(NSWSrespFLG));
            }
            if (Convert.ToString(ApprovalID) == "" || Convert.ToString(ApprovalID) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@ApprovalID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@ApprovalID", Convert.ToString(ApprovalID));
            }

            cmdsrc1.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmdsrc1.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            output = false;
        }

        return output;
    }

    #endregion

    #region queryresponse and get response file

    public DataSet DB_insertnswscafdatacfedatabyuserid(string intUserid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("nsws_getqueryresponsereqdata_byuserid", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Userid", SqlDbType.VarChar).Value = intUserid;
            da.SelectCommand.CommandTimeout = 3600;
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


    public string callwebapitoqueryresponsedatabyuserid(string intUserid)
    {
        string responsedata = string.Empty;

        try
        {
            DataSet dt_data = DB_insertnswscafdatacfedatabyuserid(intUserid);
            if (dt_data.Tables.Count > 0)
            {
                if (dt_data.Tables.Count >= 1)
                {
                    if (dt_data.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dt_data.Tables[0].Rows.Count; i++)
                        {
                            requestqueryresponse reqqyerresdept = new requestqueryresponse();
                            reqqyerresdept.ministryId = Convert.ToString(dt_data.Tables[0].Rows[i]["ministryId"]);
                            reqqyerresdept.departmentId = Convert.ToString(dt_data.Tables[0].Rows[i]["departmentId"]);

                            //tsipassids
                            string ApplicationID = Convert.ToString(dt_data.Tables[0].Rows[i]["ApplicationID"]);
                            string DeptID = Convert.ToString(dt_data.Tables[0].Rows[i]["intDeptid"]);
                            string ApprovalID = Convert.ToString(dt_data.Tables[0].Rows[i]["intApprovalid"]);
                            string CategoryType = Convert.ToString(dt_data.Tables[0].Rows[i]["CategoryType"]);
                            string SWS_ID = Convert.ToString(dt_data.Tables[0].Rows[i]["SWS_ID"]);


                            //string access_id = "MIN_TEST_0";
                            //string access_secret = "MintesT@1234";
                            //string LicensePushAPIapikey = "Min1@GQR10";
                            //string RegisterURL = "https://uat-nsws-mnstrportal.investindia.gov.in/nsws_clarification/getqueryResponse";

                            string access_id = ""; string access_secret = ""; string APIKEY = ""; string RegisterURL = "";
                            if (Convert.ToString(ConfigurationManager.AppSettings["NSWSIsserver"]) == "1")
                            {
                                access_id = Convert.ToString(ConfigurationManager.AppSettings["NSWSaccessid"]);
                                access_secret = Convert.ToString(ConfigurationManager.AppSettings["NSWSaccess_secret"]);
                                APIKEY = Convert.ToString(ConfigurationManager.AppSettings["NswsPullClarificationResponseAPIKEY"]);
                                RegisterURL = Convert.ToString(ConfigurationManager.AppSettings["NswsPullClarificationResponseAPI"]);
                            }
                            else
                            {
                                if (Convert.ToString(ConfigurationManager.AppSettings["NSWSIsserverPPE"]) == "1")
                                {
                                    access_id = Convert.ToString(ConfigurationManager.AppSettings["PPE_NSWSaccessid"]);
                                    access_secret = Convert.ToString(ConfigurationManager.AppSettings["PPE_NSWSaccess_secret"]);
                                    APIKEY = Convert.ToString(ConfigurationManager.AppSettings["PPE_NswsPullClarificationResponseAPIKEY"]);
                                    RegisterURL = Convert.ToString(ConfigurationManager.AppSettings["PPE_NswsPullClarificationResponseAPI"]);
                                }
                                else
                                {
                                    access_id = Convert.ToString(ConfigurationManager.AppSettings["testNSWSaccessid"]);
                                    access_secret = Convert.ToString(ConfigurationManager.AppSettings["testNSWSaccess_secret"]);
                                    APIKEY = Convert.ToString(ConfigurationManager.AppSettings["testNswsPullClarificationResponseAPIKEY"]);
                                    RegisterURL = Convert.ToString(ConfigurationManager.AppSettings["testNswsPullClarificationResponseAPI"]);
                                }
                            }

                            var postData = JsonConvert.SerializeObject(reqqyerresdept);
                            responsedata = Cls_JSONFormat.PostRequestByHeaderKEYIDSECERTAPI(RegisterURL, postData, access_id, access_secret, APIKEY);

                            // PostRequestByHeaderKEYIDSECERTAPI(string RegisterURL, string postData, string access_id, string access_secret, string APIKEY)

                            JObject jobj = JsonConvert.DeserializeObject<dynamic>(responsedata);
                            string status = jobj.Value<string>("status");
                            if (status == "200" || status == "OK")
                            {
                                responsenswsqueryresponse oREResponse = new responsenswsqueryresponse();
                                oREResponse = JsonConvert.DeserializeObject<responsenswsqueryresponse>(responsedata);
                                if (oREResponse.response != null)
                                {
                                    if (oREResponse.response.Count > 0)
                                    {
                                        List<Response> obj_subres = oREResponse.response;
                                        foreach (var r in obj_subres)
                                        {
                                            Response secrowdata = new Response();
                                            secrowdata.queryId = r.queryId;
                                            secrowdata.queryResp = r.queryResp;
                                            secrowdata.licenseReqId = r.licenseReqId;
                                            secrowdata.contentId = r.contentId;
                                            //insert data according by application
                                            string combindedqueryResp = string.Join(",", secrowdata.queryResp);
                                            string combindedcontentId = string.Join(",", secrowdata.contentId);

                                            string[] arg = new string[4];
                                            arg = secrowdata.queryId.Split('-');
                                            if (Convert.ToString(arg[0]) == SWS_ID)
                                            {
                                                bool updatequerrespose = DB_updatequeryresponseofeachappl(ApplicationID, CategoryType, "1", responsedata, DeptID, ApprovalID,
                                                 secrowdata.queryId, combindedqueryResp, secrowdata.licenseReqId, combindedcontentId);
                                                if (updatequerrespose == true)
                                                {
                                                    if (r.contentId != null)
                                                    {
                                                        if (r.contentId.Count > 0)
                                                        {
                                                            callwebapitoqueryresponsegetfiledata(ApplicationID, CategoryType, DeptID, ApprovalID, r.contentId, SWS_ID);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        getlicencesstatusupdated(ApplicationID, DeptID, ApprovalID, CategoryType, "queryresponded");
                                                    }

                                                }
                                            }

                                        }
                                    }
                                }
                            }
                            else
                            {
                                responsenswsqueryresponsefailedcase oREResponsefail = new responsenswsqueryresponsefailedcase();
                                // oREResponsefail = JsonConvert.DeserializeObject<responsenswsqueryresponsefailedcase>(responsedata);
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

    public DataSet DB_insertnswscafdatacfedatabydeptid(string Deptid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("nsws_getqueryresponsereqdata_bydeptid", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Deptid", SqlDbType.VarChar).Value = Deptid;
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


    public string callwebapitoqueryresponsedatabydeptid(string Deptid)
    {
        string responsedata = string.Empty;

        try
        {
            DataSet dt_data = DB_insertnswscafdatacfedatabydeptid(Deptid);
            if (dt_data.Tables.Count > 0)
            {
                if (dt_data.Tables.Count >= 1)
                {
                    if (dt_data.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dt_data.Tables[0].Rows.Count; i++)
                        {
                            requestqueryresponse reqqyerresdept = new requestqueryresponse();
                            reqqyerresdept.ministryId = Convert.ToString(dt_data.Tables[0].Rows[i]["ministryId"]);
                            reqqyerresdept.departmentId = Convert.ToString(dt_data.Tables[0].Rows[i]["departmentId"]);

                            //tsipassids
                            string ApplicationID = Convert.ToString(dt_data.Tables[0].Rows[i]["ApplicationID"]);
                            string DeptID = Convert.ToString(dt_data.Tables[0].Rows[i]["intDeptid"]);
                            string ApprovalID = Convert.ToString(dt_data.Tables[0].Rows[i]["intApprovalid"]);
                            string CategoryType = Convert.ToString(dt_data.Tables[0].Rows[i]["CategoryType"]);
                            string SWS_ID = Convert.ToString(dt_data.Tables[0].Rows[i]["SWS_ID"]);


                            //string access_id = "MIN_TEST_0";
                            //string access_secret = "MintesT@1234";
                            //string LicensePushAPIapikey = "Min1@GQR10";
                            //string RegisterURL = "https://uat-nsws-mnstrportal.investindia.gov.in/nsws_clarification/getqueryResponse";

                            string access_id = ""; string access_secret = ""; string APIKEY = ""; string RegisterURL = "";
                            if (Convert.ToString(ConfigurationManager.AppSettings["NSWSIsserver"]) == "1")
                            {
                                access_id = Convert.ToString(ConfigurationManager.AppSettings["NSWSaccessid"]);
                                access_secret = Convert.ToString(ConfigurationManager.AppSettings["NSWSaccess_secret"]);
                                APIKEY = Convert.ToString(ConfigurationManager.AppSettings["NswsPullClarificationResponseAPIKEY"]);
                                RegisterURL = Convert.ToString(ConfigurationManager.AppSettings["NswsPullClarificationResponseAPI"]);
                            }
                            else
                            {
                                if (Convert.ToString(ConfigurationManager.AppSettings["NSWSIsserverPPE"]) == "1")
                                {
                                    access_id = Convert.ToString(ConfigurationManager.AppSettings["PPE_NSWSaccessid"]);
                                    access_secret = Convert.ToString(ConfigurationManager.AppSettings["PPE_NSWSaccess_secret"]);
                                    APIKEY = Convert.ToString(ConfigurationManager.AppSettings["PPE_NswsPullClarificationResponseAPIKEY"]);
                                    RegisterURL = Convert.ToString(ConfigurationManager.AppSettings["PPE_NswsPullClarificationResponseAPI"]);
                                }
                                else
                                {
                                    access_id = Convert.ToString(ConfigurationManager.AppSettings["testNSWSaccessid"]);
                                    access_secret = Convert.ToString(ConfigurationManager.AppSettings["testNSWSaccess_secret"]);
                                    APIKEY = Convert.ToString(ConfigurationManager.AppSettings["testNswsPullClarificationResponseAPIKEY"]);
                                    RegisterURL = Convert.ToString(ConfigurationManager.AppSettings["testNswsPullClarificationResponseAPI"]);
                                }

                            }

                            var postData = JsonConvert.SerializeObject(reqqyerresdept);
                            responsedata = Cls_JSONFormat.PostRequestByHeaderKEYIDSECERTAPI(RegisterURL, postData, access_id, access_secret, APIKEY);

                            // PostRequestByHeaderKEYIDSECERTAPI(string RegisterURL, string postData, string access_id, string access_secret, string APIKEY)

                            JObject jobj = JsonConvert.DeserializeObject<dynamic>(responsedata);
                            string status = jobj.Value<string>("status");
                            if (status == "200" || status == "OK")
                            {
                                responsenswsqueryresponse oREResponse = new responsenswsqueryresponse();
                                oREResponse = JsonConvert.DeserializeObject<responsenswsqueryresponse>(responsedata);
                                if (oREResponse.response != null)
                                {
                                    if (oREResponse.response.Count > 0)
                                    {
                                        List<Response> obj_subres = oREResponse.response;
                                        foreach (var r in obj_subres)
                                        {
                                            Response secrowdata = new Response();
                                            secrowdata.queryId = r.queryId;
                                            secrowdata.queryResp = r.queryResp;
                                            secrowdata.licenseReqId = r.licenseReqId;
                                            secrowdata.contentId = r.contentId;
                                            //insert data according by application
                                            string combindedqueryResp = string.Join(",", secrowdata.queryResp);
                                            string combindedcontentId = string.Join(",", secrowdata.contentId);

                                            string[] arg = new string[4];
                                            arg = secrowdata.queryId.Split('-');
                                            if (Convert.ToString(arg[0]) == SWS_ID)
                                            {
                                                bool updatequerrespose = DB_updatequeryresponseofeachappl(ApplicationID, CategoryType, "1", responsedata, DeptID, ApprovalID,
                                                 secrowdata.queryId, combindedqueryResp, secrowdata.licenseReqId, combindedcontentId);
                                                if (updatequerrespose == true)
                                                {
                                                    if (r.contentId != null)
                                                    {
                                                        if (r.contentId.Count > 0)
                                                        {
                                                            callwebapitoqueryresponsegetfiledata(ApplicationID, CategoryType, DeptID, ApprovalID, r.contentId, SWS_ID);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        getlicencesstatusupdated(ApplicationID, DeptID, ApprovalID, CategoryType, "queryresponded");
                                                    }

                                                }
                                            }

                                        }
                                    }
                                }
                            }
                            else
                            {
                                responsenswsqueryresponsefailedcase oREResponsefail = new responsenswsqueryresponsefailedcase();
                                // oREResponsefail = JsonConvert.DeserializeObject<responsenswsqueryresponsefailedcase>(responsedata);
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



    public DataSet DB_getqueryresponsereqdata()
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("nsws_getqueryresponsereqdata", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
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
    public class requestqueryresponse
    {
        public string ministryId { get; set; }
        public string departmentId { get; set; }
        //public List<LicenseIdentificationAttribute> licenseIdentificationAttribute { get; set; }
        //            State identification attribute
        //Department identification attribute
        //License identification attribute License_ID(optional)
        //SWS_ID-License_ID-clarification_ID(optional)
        //Sample json :
        //{
        // "ministryId": "MIN001",
        // "departmentId": "DEP001"
        //}

    }
    public string callwebapitoqueryresponsedata()
    {
        string responsedata = string.Empty;

        try
        {
            DataSet dt_data = DB_getqueryresponsereqdata();
            if (dt_data.Tables.Count > 0)
            {
                if (dt_data.Tables.Count >= 1)
                {
                    if (dt_data.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dt_data.Tables[0].Rows.Count; i++)
                        {
                            requestqueryresponse reqqyerresdept = new requestqueryresponse();
                            reqqyerresdept.ministryId = Convert.ToString(dt_data.Tables[0].Rows[i]["ministryId"]);
                            reqqyerresdept.departmentId = Convert.ToString(dt_data.Tables[0].Rows[i]["departmentId"]);

                            //tsipassids
                            string ApplicationID = Convert.ToString(dt_data.Tables[0].Rows[i]["ApplicationID"]);
                            string DeptID = Convert.ToString(dt_data.Tables[0].Rows[i]["intDeptid"]);
                            string ApprovalID = Convert.ToString(dt_data.Tables[0].Rows[i]["intApprovalid"]);
                            string CategoryType = Convert.ToString(dt_data.Tables[0].Rows[i]["CategoryType"]);
                            string SWS_ID = Convert.ToString(dt_data.Tables[0].Rows[i]["SWS_ID"]);
                            //string access_id = "MIN_TEST_0";
                            //string access_secret = "MintesT@1234";
                            //string LicensePushAPIapikey = "Min1@GQR10";
                            //string RegisterURL = "https://uat-nsws-mnstrportal.investindia.gov.in/nsws_clarification/getqueryResponse";

                            string access_id = ""; string access_secret = ""; string APIKEY = ""; string RegisterURL = "";
                            if (Convert.ToString(ConfigurationManager.AppSettings["NSWSIsserver"]) == "1")
                            {
                                access_id = Convert.ToString(ConfigurationManager.AppSettings["NSWSaccessid"]);
                                access_secret = Convert.ToString(ConfigurationManager.AppSettings["NSWSaccess_secret"]);
                                APIKEY = Convert.ToString(ConfigurationManager.AppSettings["NswsPullClarificationResponseAPIKEY"]);
                                RegisterURL = Convert.ToString(ConfigurationManager.AppSettings["NswsPullClarificationResponseAPI"]);
                            }
                            else
                            {
                                if (Convert.ToString(ConfigurationManager.AppSettings["NSWSIsserverPPE"]) == "1")
                                {
                                    access_id = Convert.ToString(ConfigurationManager.AppSettings["PPE_NSWSaccessid"]);
                                    access_secret = Convert.ToString(ConfigurationManager.AppSettings["PPE_NSWSaccess_secret"]);
                                    APIKEY = Convert.ToString(ConfigurationManager.AppSettings["PPE_NswsPullClarificationResponseAPIKEY"]);
                                    RegisterURL = Convert.ToString(ConfigurationManager.AppSettings["PPE_NswsPullClarificationResponseAPI"]);
                                }
                                else
                                {
                                    access_id = Convert.ToString(ConfigurationManager.AppSettings["testNSWSaccessid"]);
                                    access_secret = Convert.ToString(ConfigurationManager.AppSettings["testNSWSaccess_secret"]);
                                    APIKEY = Convert.ToString(ConfigurationManager.AppSettings["testNswsPullClarificationResponseAPIKEY"]);
                                    RegisterURL = Convert.ToString(ConfigurationManager.AppSettings["testNswsPullClarificationResponseAPI"]);
                                }
                            }

                            var postData = JsonConvert.SerializeObject(reqqyerresdept);
                            responsedata = Cls_JSONFormat.PostRequestByHeaderKEYIDSECERTAPI(RegisterURL, postData, access_id, access_secret, APIKEY);

                            // PostRequestByHeaderKEYIDSECERTAPI(string RegisterURL, string postData, string access_id, string access_secret, string APIKEY)

                            JObject jobj = JsonConvert.DeserializeObject<dynamic>(responsedata);
                            string status = jobj.Value<string>("status");
                            if (status == "200" || status == "OK")
                            {
                                responsenswsqueryresponse oREResponse = new responsenswsqueryresponse();
                                oREResponse = JsonConvert.DeserializeObject<responsenswsqueryresponse>(responsedata);
                                if (oREResponse.response != null)
                                {
                                    if (oREResponse.response.Count > 0)
                                    {
                                        List<Response> obj_subres = oREResponse.response;
                                        foreach (var r in obj_subres)
                                        {
                                            Response secrowdata = new Response();
                                            secrowdata.queryId = r.queryId;
                                            secrowdata.queryResp = r.queryResp;
                                            secrowdata.licenseReqId = r.licenseReqId;
                                            secrowdata.contentId = r.contentId;
                                            //insert data according by application
                                            string combindedqueryResp = string.Join(",", secrowdata.queryResp);
                                            string combindedcontentId = string.Join(",", secrowdata.contentId);

                                            string[] arg = new string[4];
                                            arg = secrowdata.queryId.Split('-');
                                            if (Convert.ToString(arg[0]) == SWS_ID)
                                            {
                                                bool updatequerrespose = DB_updatequeryresponseofeachappl(ApplicationID, CategoryType, "1", responsedata, DeptID, ApprovalID,
                                                 secrowdata.queryId, combindedqueryResp, secrowdata.licenseReqId, combindedcontentId);
                                                if (updatequerrespose == true)
                                                {
                                                    if (r.contentId != null)
                                                    {
                                                        if (r.contentId.Count > 0)
                                                        {
                                                            callwebapitoqueryresponsegetfiledata(ApplicationID, CategoryType, DeptID, ApprovalID, r.contentId, SWS_ID);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        getlicencesstatusupdated(ApplicationID, DeptID, ApprovalID, CategoryType, "queryresponded");
                                                    }


                                                }
                                            }

                                        }
                                    }
                                }
                            }
                            else
                            {
                                responsenswsqueryresponsefailedcase oREResponsefail = new responsenswsqueryresponsefailedcase();
                                // oREResponsefail = JsonConvert.DeserializeObject<responsenswsqueryresponsefailedcase>(responsedata);
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
    public bool DB_updatequeryresponseofeachappl(string ApplicationID, string CategoryType, string NSWSrespFLG,
        string NSWSresponse, string DeptID, string ApprovalID, string NSWSqueryId, string NSWSqueryResp, string NSWSlicenseReqId, string NSWScontentId)
    {
        bool output = true;
        SqlConnection con = new SqlConnection(strConnectionString);
        try
        {
            SqlCommand cmdsrc1 = new SqlCommand("nsws_updatequeryresponsebyapplDeptIDApprovalID", con);
            if (Convert.ToString(ApplicationID) == "" || Convert.ToString(ApplicationID) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@ApplicationID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@ApplicationID", Convert.ToString(ApplicationID));
            }
            if (Convert.ToString(CategoryType) == "" || Convert.ToString(CategoryType) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@CategoryType", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@CategoryType", Convert.ToString(CategoryType));
            }
            if (Convert.ToString(DeptID) == "" || Convert.ToString(DeptID) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@DeptID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@DeptID", Convert.ToString(DeptID));
            }
            if (Convert.ToString(ApprovalID) == "" || Convert.ToString(ApprovalID) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@ApprovalID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@ApprovalID", Convert.ToString(ApprovalID));
            }
            if (Convert.ToString(NSWSresponse) == "" || Convert.ToString(NSWSresponse) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@Response", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@Response", Convert.ToString(NSWSresponse));
            }
            if (Convert.ToString(NSWSrespFLG) == "" || Convert.ToString(NSWSrespFLG) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@ResponseFLG", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@ResponseFLG", Convert.ToString(NSWSrespFLG));
            }
            if (Convert.ToString(NSWSqueryId) == "" || Convert.ToString(NSWSqueryId) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@NSWSqueryId", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@NSWSqueryId", Convert.ToString(NSWSqueryId));
            }
            if (Convert.ToString(NSWSqueryResp) == "" || Convert.ToString(NSWSqueryResp) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@NSWSqueryResp", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@NSWSqueryResp", Convert.ToString(NSWSqueryResp));
            }
            if (Convert.ToString(NSWSlicenseReqId) == "" || Convert.ToString(NSWSlicenseReqId) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@NSWSlicenseReqId", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@NSWSlicenseReqId", Convert.ToString(NSWSlicenseReqId));
            }
            if (Convert.ToString(NSWScontentId) == "" || Convert.ToString(NSWScontentId) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@NSWScontentId", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@NSWScontentId", Convert.ToString(NSWScontentId));
            }

            cmdsrc1.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmdsrc1.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            output = false;
        }

        return output;
    }
    public class responsenswsqueryresponsefailedcase
    {
        public string status { get; set; }
        public List<string> message { get; set; }
        //public string response { get; set; }
        public List<Response> queryresdata { get; set; }
        //response

        //"status": "200",
        //"message": "Success",
        //"response": [
        //    {
        //        "queryId": "ID7001010101-M001_D001_A001-16124267006775",
        //        "queryResp": "Response1",
        //        "licenseReqId": "ID7001010101- M001_D001_A001-16124267006765"
        //    }]

    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Response
    {
        public string queryId { get; set; }
        public List<string> queryResp { get; set; }
        public string licenseReqId { get; set; }
        public List<string> contentId { get; set; }
    }
    public class responsenswsqueryresponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<Response> response { get; set; }
    }
    public class requestpulldocumetapi
    {
        public List<string> contentId { get; set; }
        //public string contentId { get; set; }
        //{"contentId" : ["swsId-documentId-version"]}
    }
    public string callwebapitoqueryresponsegetfiledata(string ApplicationID, string CategoryType, string DeptID, string ApprovalID, List<string> Contentdata, string NSWSSWSID)
    {
        string responsedata = string.Empty;
        try
        {
            requestpulldocumetapi reqqyerresdept = new requestpulldocumetapi();
            List<string> contentId = new List<string>();
            contentId = Contentdata.ToList();
            reqqyerresdept.contentId = contentId;

            //string access_id = "MIN_TEST_0";
            //string access_secret = "MintesT@1234";
            //string LicensePushAPIapikey = "Min1@GD03";
            //string RegisterURL = "https://uat-nsws-mnstrportal.investindia.gov.in/nsws_document/getDocument";

            string access_id = ""; string access_secret = ""; string APIKEY = ""; string RegisterURL = "";
            if (Convert.ToString(ConfigurationManager.AppSettings["NSWSIsserver"]) == "1")
            {
                access_id = Convert.ToString(ConfigurationManager.AppSettings["NSWSaccessid"]);
                access_secret = Convert.ToString(ConfigurationManager.AppSettings["NSWSaccess_secret"]);
                APIKEY = Convert.ToString(ConfigurationManager.AppSettings["NswsPullDocumentAPIKEY"]);
                RegisterURL = Convert.ToString(ConfigurationManager.AppSettings["NswsPullDocumentAPI"]);
            }
            else
            {
                if (Convert.ToString(ConfigurationManager.AppSettings["NSWSIsserverPPE"]) == "1")
                {
                    access_id = Convert.ToString(ConfigurationManager.AppSettings["PPE_NSWSaccessid"]);
                    access_secret = Convert.ToString(ConfigurationManager.AppSettings["PPE_NSWSaccess_secret"]);
                    APIKEY = Convert.ToString(ConfigurationManager.AppSettings["PPE_NswsPullDocumentAPIKEY"]);
                    RegisterURL = Convert.ToString(ConfigurationManager.AppSettings["PPE_NswsPullDocumentAPI"]);
                }
                else
                {
                    access_id = Convert.ToString(ConfigurationManager.AppSettings["testNSWSaccessid"]);
                    access_secret = Convert.ToString(ConfigurationManager.AppSettings["testNSWSaccess_secret"]);
                    APIKEY = Convert.ToString(ConfigurationManager.AppSettings["testNswsPullDocumentAPIKEY"]);
                    RegisterURL = Convert.ToString(ConfigurationManager.AppSettings["testNswsPullDocumentAPI"]);
                }
            }

            var postData = JsonConvert.SerializeObject(reqqyerresdept);
            responsedata = Cls_JSONFormat.PostRequestByHeaderKEYIDSECERTAPI(RegisterURL, postData, access_id, access_secret, APIKEY);

            // PostRequestByHeaderKEYIDSECERTAPI(string RegisterURL, string postData, string access_id, string access_secret, string APIKEY)


            cls_nswsfilepullparmeters.Responseofpullfileapi oREResponse = new cls_nswsfilepullparmeters.Responseofpullfileapi();
            oREResponse = JsonConvert.DeserializeObject<cls_nswsfilepullparmeters.Responseofpullfileapi>(responsedata);
            if (oREResponse.status == "200" || oREResponse.status == "OK")
            {
                if (oREResponse.response != null)
                {
                    if (oREResponse.response.Count > 0)
                    {
                        List<cls_nswsfilepullparmeters.Response> obj_subres = oREResponse.response;
                        foreach (var r in obj_subres)
                        {
                            cls_nswsfilepullparmeters.Response secrowdata = new cls_nswsfilepullparmeters.Response();
                            secrowdata.fileName = r.fileName;
                            secrowdata.fileResponse = r.fileResponse;
                            //Convert Base64 Encoded string to Byte Array.
                            //byte[] imageBytes = Convert.FromBase64String(secrowdata.fileResponse);
                            //string filePath = HttpContext.Current.Server.MapPath("~/NSWSFiles/"+ CategoryType+"/" + Path.GetFileName(secrowdata.fileName));
                            //File.WriteAllBytes(filePath, imageBytes);

                            string Typeofdoc = "Queryres";
                            byte[] array = Convert.FromBase64String(secrowdata.fileResponse);
                            string filename = r.fileName;

                            string path = "@" + Convert.ToString(ConfigurationManager.AppSettings["NSWSFileuploadurlpath"]) + CategoryType + "\\" + ApplicationID + "\\" + Typeofdoc + "\\";
                            //string path = @"~\NSWSFiles\" + CategoryType + "\\" + ApplicationID + "\\" + Typeofdoc + "\\";
                            if (!Directory.Exists(HttpContext.Current.Server.MapPath(path)))
                            {
                                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(path));
                            }
                            string test = path + filename;
                            String filepath = HttpContext.Current.Server.MapPath(path + filename);
                            File.WriteAllBytes(filepath, array);
                            string imagepath = path + filename;
                            cls_nswsfilepullparmeters.resinsertnswsfile obj_filepar = new cls_nswsfilepullparmeters.resinsertnswsfile();
                            obj_filepar.fileTitle = Convert.ToString(secrowdata.fileName);
                            string[] fileType = secrowdata.fileName.Split('.');
                            int ilen = fileType.Length;
                            obj_filepar.contentType = Convert.ToString(fileType[ilen - 1]).Trim();
                            obj_filepar.swsId = Convert.ToString(NSWSSWSID);
                            obj_filepar.tsipassAppID = Convert.ToString(ApplicationID);
                            obj_filepar.CategoryType = Convert.ToString(CategoryType);
                            obj_filepar.intDeptID = Convert.ToString(DeptID);
                            obj_filepar.intApprovalID = Convert.ToString(ApprovalID);
                            obj_filepar.NSWSContentID = string.Join(",", reqqyerresdept.contentId);
                            obj_filepar.responsedata = Convert.ToString(responsedata);
                            obj_filepar.filepath = Convert.ToString(imagepath);
                            //DB_insertnswsfiletoinsertdata(obj_filepar);

                            bool queryresponded = DB_insertnswsfiletoinsertdata(obj_filepar);
                            if (queryresponded == true)
                            {
                                getlicencesstatusupdated(ApplicationID, DeptID, ApprovalID, CategoryType, "queryresponded");
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

    //public bool DB_insertnswsfiletoinsertdata(string documentId,string fileTitle,string contentType,string uploadedDate,
    //    string approvalId,string swsId,string investorReqId,string mnstryDprtmntId,string version,string latestVersion,
    //    string md5Hash, string  tsipassAppID, string CategoryType, string intDeptID, string intApprovalID, string NSWSContentID,
    //    string responsedata, string filepath)
    public bool DB_insertnswsfiletoinsertdata(cls_nswsfilepullparmeters.resinsertnswsfile obj_filepar)
    {
        bool output = true;
        SqlConnection con = new SqlConnection(strConnectionString);
        try
        {
            SqlCommand cmdsrc1 = new SqlCommand("nsws_insertnswsfiletoinsertdata", con);
            if (Convert.ToString(obj_filepar.documentId) == "" || Convert.ToString(obj_filepar.documentId) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@documentId", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@documentId", Convert.ToString(obj_filepar.documentId));
            }
            if (Convert.ToString(obj_filepar.fileTitle) == "" || Convert.ToString(obj_filepar.fileTitle) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@fileTitle", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@fileTitle", Convert.ToString(obj_filepar.fileTitle));
            }
            if (Convert.ToString(obj_filepar.contentType) == "" || Convert.ToString(obj_filepar.contentType) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@contentType", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@contentType", Convert.ToString(obj_filepar.contentType));
            }

            if (Convert.ToString(obj_filepar.uploadedDate) == "" || Convert.ToString(obj_filepar.uploadedDate) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@uploadedDate", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@uploadedDate", Convert.ToString(obj_filepar.uploadedDate));
            }
            if (Convert.ToString(obj_filepar.approvalId) == "" || Convert.ToString(obj_filepar.approvalId) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@approvalId", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@approvalId", Convert.ToString(obj_filepar.approvalId));
            }
            if (Convert.ToString(obj_filepar.swsId) == "" || Convert.ToString(obj_filepar.swsId) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@swsId", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@swsId", Convert.ToString(obj_filepar.swsId));
            }

            if (Convert.ToString(obj_filepar.investorReqId) == "" || Convert.ToString(obj_filepar.investorReqId) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@investorReqId", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@investorReqId", Convert.ToString(obj_filepar.investorReqId));
            }
            if (Convert.ToString(obj_filepar.mnstryDprtmntId) == "" || Convert.ToString(obj_filepar.mnstryDprtmntId) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@mnstryDprtmntId", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@mnstryDprtmntId", Convert.ToString(obj_filepar.mnstryDprtmntId));
            }
            if (Convert.ToString(obj_filepar.version) == "" || Convert.ToString(obj_filepar.version) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@version", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@version", Convert.ToString(obj_filepar.version));
            }


            if (Convert.ToString(obj_filepar.latestVersion) == "" || Convert.ToString(obj_filepar.latestVersion) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@latestVersion", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@latestVersion", Convert.ToString(obj_filepar.latestVersion));
            }
            if (Convert.ToString(obj_filepar.md5Hash) == "" || Convert.ToString(obj_filepar.md5Hash) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@md5Hash", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@md5Hash", Convert.ToString(obj_filepar.md5Hash));
            }
            if (Convert.ToString(obj_filepar.tsipassAppID) == "" || Convert.ToString(obj_filepar.tsipassAppID) == null)
            {
                cmdsrc1.Parameters.AddWithValue("tsipassAppID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@tsipassAppID", Convert.ToString(obj_filepar.tsipassAppID));
            }

            if (Convert.ToString(obj_filepar.CategoryType) == "" || Convert.ToString(obj_filepar.CategoryType) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@CategoryType", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@CategoryType", Convert.ToString(obj_filepar.CategoryType));
            }
            if (Convert.ToString(obj_filepar.intDeptID) == "" || Convert.ToString(obj_filepar.intDeptID) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@intDeptID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@intDeptID", Convert.ToString(obj_filepar.intDeptID));
            }
            if (Convert.ToString(obj_filepar.intApprovalID) == "" || Convert.ToString(obj_filepar.intApprovalID) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@intApprovalID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@intApprovalID", Convert.ToString(obj_filepar.intApprovalID));
            }

            if (Convert.ToString(obj_filepar.NSWSContentID) == "" || Convert.ToString(obj_filepar.NSWSContentID) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@NSWScontentId", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@NSWSContentID", Convert.ToString(obj_filepar.NSWSContentID));
            }

            if (Convert.ToString(obj_filepar.responsedata) == "" || Convert.ToString(obj_filepar.responsedata) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@responsedata", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@responsedata", Convert.ToString(obj_filepar.responsedata));
            }
            if (Convert.ToString(obj_filepar.filepath) == "" || Convert.ToString(obj_filepar.filepath) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@filepath", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@filepath", Convert.ToString(obj_filepar.filepath));
            }



            cmdsrc1.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmdsrc1.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            output = false;
        }

        return output;
    }



    #endregion

    #region rejectedstatusupdate
    public string getlicencesstatusupdated(string ApplicationID, string DeptID, string ApprovalID, string CategoryType, string StatusType)
    {
        string strjsonresponse = string.Empty;
        try
        {
            DataSet dt_data = new DataSet();
            if (StatusType.ToLower() == "query")
            {
                dt_data = DB_getlicensesStatusafterqueryraise(ApplicationID, DeptID, ApprovalID, CategoryType);
            }
            else if (StatusType.ToLower() == "rejected")
            {
                dt_data = DB_getlicensesStatusafterqueryraise(ApplicationID, DeptID, ApprovalID, CategoryType);
            }
            else if (StatusType.ToLower() == "approved")
            {
                dt_data = DB_getlicensesStatusafterqueryraise(ApplicationID, DeptID, ApprovalID, CategoryType);
            }
            else if (StatusType.ToLower() == "queryresponded")
            {
                dt_data = DB_getlicensesStatusafterqueryraise(ApplicationID, DeptID, ApprovalID, CategoryType);
            }

            if (dt_data.Tables.Count > 0)
            {
                LogErrorFile.LogData("StatusType:" + Convert.ToString(dt_data.Tables.Count));
                if (dt_data.Tables[0].Rows.Count > 0)
                {
                    DataTable dt_department = dt_data.Tables[0];
                    if (dt_data.Tables.Count > 1)
                    {
                        if (dt_data.Tables[1].Rows.Count > 0)
                        {
                            DataTable dt_approvals = dt_data.Tables[1];
                            for (int j = 0; j < dt_department.Rows.Count; j++)
                            {
                                requestofpushlicesestatusnsws obj_nswsdept = new requestofpushlicesestatusnsws();
                                obj_nswsdept.departmentId = Convert.ToString(dt_department.Rows[j]["departmentId"]);
                                obj_nswsdept.ministryStateId = Convert.ToString(dt_department.Rows[j]["ministryStateId"]);

                                List<licenseStastusList> approvalstatusIlist = new List<licenseStastusList>();
                                for (int i = 0; i < dt_approvals.Rows.Count; i++)
                                {
                                    licenseStastusList liststatusapprovalsdata = new licenseStastusList();

                                    if (Convert.ToString(dt_department.Rows[j]["departmentId"]) == Convert.ToString(dt_approvals.Rows[i]["departmentId"]))
                                    {
                                        liststatusapprovalsdata.licenseReqNum = Convert.ToString(dt_approvals.Rows[i]["licenseReqNum"]);
                                        liststatusapprovalsdata.licenseStatus = Convert.ToString(dt_approvals.Rows[i]["licenseStatus"]);
                                        approvalstatusIlist.Add(liststatusapprovalsdata);
                                    }
                                }

                                obj_nswsdept.licenseStastusList = approvalstatusIlist;

                                strjsonresponse = Callnswswebapiforlicenscestatusupdate(obj_nswsdept);
                                responseofpushliensestatusnsws res_approvalstatus = new responseofpushliensestatusnsws();
                                res_approvalstatus = JsonConvert.DeserializeObject<responseofpushliensestatusnsws>(strjsonresponse);
                                if (StatusType.ToLower() == "query")
                                {
                                    updateresponselicensesStatusafterqueryraise(ApplicationID, CategoryType, "1", strjsonresponse, DeptID, ApprovalID);
                                }
                                else if (StatusType.ToLower() == "rejected")
                                {
                                    updateresponselicensesStatusrejected(ApplicationID, CategoryType, "1", strjsonresponse, DeptID, ApprovalID);
                                }
                                else if (StatusType.ToLower() == "approved")
                                {
                                    updateresponselicensesStatusApproved(ApplicationID, CategoryType, "1", strjsonresponse, DeptID, ApprovalID);
                                }
                                else if (StatusType.ToLower() == "queryresponded")
                                {
                                    updateresponselicensesStatusqueryrespoded(ApplicationID, CategoryType, "1", strjsonresponse, DeptID, ApprovalID);
                                }
                            }
                        }
                    }
                }
            }
            return strjsonresponse;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool updateresponselicensesStatusrejected(string ApplicationID, string CategoryType, string NSWSrespFLG, string NSWSresponse, string DeptID, string ApprovalID)
    {
        bool output = true;
        SqlConnection con = new SqlConnection(strConnectionString);
        try
        {
            SqlCommand cmdsrc1 = new SqlCommand("nsws_updateresponselicensesStatusrejected", con);
            if (Convert.ToString(ApplicationID) == "" || Convert.ToString(ApplicationID) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@ApplicationID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.Add("@ApplicationID", SqlDbType.VarChar).Value = ApplicationID;
            }
            if (Convert.ToString(CategoryType) == "" || Convert.ToString(CategoryType) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@CategoryType", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@CategoryType", Convert.ToString(CategoryType));
            }
            if (Convert.ToString(DeptID) == "" || Convert.ToString(DeptID) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@DeptID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@DeptID", Convert.ToString(DeptID));
            }
            if (Convert.ToString(NSWSresponse) == "" || Convert.ToString(NSWSresponse) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@Response", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@Response", Convert.ToString(NSWSresponse));
            }
            if (Convert.ToString(NSWSrespFLG) == "" || Convert.ToString(NSWSrespFLG) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@ResponseFLG", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@ResponseFLG", Convert.ToString(NSWSrespFLG));
            }
            if (Convert.ToString(ApprovalID) == "" || Convert.ToString(ApprovalID) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@ApprovalID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@ApprovalID", Convert.ToString(ApprovalID));
            }

            cmdsrc1.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmdsrc1.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            output = false;
        }

        return output;
    }
    public bool updateresponselicensesStatusApproved(string ApplicationID, string CategoryType, string NSWSrespFLG, string NSWSresponse, string DeptID, string ApprovalID)
    {
        bool output = true;
        SqlConnection con = new SqlConnection(strConnectionString);
        try
        {
            SqlCommand cmdsrc1 = new SqlCommand("nsws_updateresponselicensesStatusapproved", con);
            if (Convert.ToString(ApplicationID) == "" || Convert.ToString(ApplicationID) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@ApplicationID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.Add("@ApplicationID", SqlDbType.VarChar).Value = ApplicationID;
            }
            if (Convert.ToString(CategoryType) == "" || Convert.ToString(CategoryType) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@CategoryType", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@CategoryType", Convert.ToString(CategoryType));
            }
            if (Convert.ToString(DeptID) == "" || Convert.ToString(DeptID) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@DeptID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@DeptID", Convert.ToString(DeptID));
            }
            if (Convert.ToString(NSWSresponse) == "" || Convert.ToString(NSWSresponse) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@Response", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@Response", Convert.ToString(NSWSresponse));
            }
            if (Convert.ToString(NSWSrespFLG) == "" || Convert.ToString(NSWSrespFLG) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@ResponseFLG", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@ResponseFLG", Convert.ToString(NSWSrespFLG));
            }
            if (Convert.ToString(ApprovalID) == "" || Convert.ToString(ApprovalID) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@ApprovalID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@ApprovalID", Convert.ToString(ApprovalID));
            }

            cmdsrc1.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmdsrc1.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            output = false;
        }

        return output;
    }


    public bool updateresponselicensesStatusqueryrespoded(string ApplicationID, string CategoryType, string NSWSrespFLG, string NSWSresponse, string DeptID, string ApprovalID)
    {
        bool output = true;
        SqlConnection con = new SqlConnection(strConnectionString);
        try
        {
            SqlCommand cmdsrc1 = new SqlCommand("nsws_updateresponselicensesStatusqueryrespoded", con);
            if (Convert.ToString(ApplicationID) == "" || Convert.ToString(ApplicationID) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@ApplicationID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.Add("@ApplicationID", SqlDbType.VarChar).Value = ApplicationID;
            }
            if (Convert.ToString(CategoryType) == "" || Convert.ToString(CategoryType) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@CategoryType", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@CategoryType", Convert.ToString(CategoryType));
            }
            if (Convert.ToString(DeptID) == "" || Convert.ToString(DeptID) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@DeptID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@DeptID", Convert.ToString(DeptID));
            }
            if (Convert.ToString(NSWSresponse) == "" || Convert.ToString(NSWSresponse) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@Response", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@Response", Convert.ToString(NSWSresponse));
            }
            if (Convert.ToString(NSWSrespFLG) == "" || Convert.ToString(NSWSrespFLG) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@ResponseFLG", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@ResponseFLG", Convert.ToString(NSWSrespFLG));
            }
            if (Convert.ToString(ApprovalID) == "" || Convert.ToString(ApprovalID) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@ApprovalID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@ApprovalID", Convert.ToString(ApprovalID));
            }

            cmdsrc1.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmdsrc1.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            output = false;
        }

        return output;
    }



    #endregion


    #region getdocument

    public DataSet DB_getnswsfile(string intuserid, string intQuessionaireid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("nsws_getnswsfile", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Convert.ToString(intQuessionaireid) == "" || Convert.ToString(intQuessionaireid) == null)
            {
                da.SelectCommand.Parameters.AddWithValue("@intQuessionaireid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid;
            }
            if (Convert.ToString(intuserid) == "" || Convert.ToString(intuserid) == null)
            {
                da.SelectCommand.Parameters.AddWithValue("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = intuserid;
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
            con.Close();
        }
    }

    public DataSet DB_getfetchFileMetadataSwsId(string intuserid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("nsws_getfetchFileMetadataSwsId", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Convert.ToString(intuserid) == "" || Convert.ToString(intuserid) == null)
            {
                da.SelectCommand.Parameters.AddWithValue("@intuserid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@intuserid", SqlDbType.VarChar).Value = intuserid;
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
            con.Close();
        }
    }


    public string callwebapitogetfetchFileMetadataSwsId(string intuserid, string CategoryType)
    {
        string responsedata = string.Empty;
        try
        {

            DataSet dt_data = DB_getfetchFileMetadataSwsId(intuserid);
            if (dt_data.Tables.Count > 0)
            {
                if (dt_data.Tables.Count >= 1)
                {
                    if (dt_data.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dt_data.Tables[0].Rows.Count; i++)
                        {
                            requestSWSIDgetdocAttribute reqqyerresdept = new requestSWSIDgetdocAttribute();
                            reqqyerresdept.swsId = Convert.ToString(dt_data.Tables[0].Rows[i]["SWS_ID"]);
                            string intCFEEnterpid = Convert.ToString(dt_data.Tables[0].Rows[i]["intCFEEnterpid"]);
                            //string access_id = "MIN_TEST_0";
                            //string access_secret = "MintesT@1234";
                            //string LicensePushAPIapikey = "Min1@GD03";
                            //string RegisterURL = "https://uat-nsws-mnstrportal.investindia.gov.in/nsws_document/fetchFileMetadataSwsId";

                            string access_id = ""; string access_secret = ""; string APIKEY = ""; string RegisterURL = "";
                            if (Convert.ToString(ConfigurationManager.AppSettings["NSWSIsserver"]) == "1")
                            {
                                access_id = Convert.ToString(ConfigurationManager.AppSettings["NSWSaccessid"]);
                                access_secret = Convert.ToString(ConfigurationManager.AppSettings["NSWSaccess_secret"]);
                                APIKEY = Convert.ToString(ConfigurationManager.AppSettings["NswsGetDocumentRepositoryAPIKEY"]);
                                RegisterURL = Convert.ToString(ConfigurationManager.AppSettings["NswsGetDocumentRepositoryAPI"]);
                            }
                            else
                            {
                                if (Convert.ToString(ConfigurationManager.AppSettings["NSWSIsserverPPE"]) == "1")
                                {
                                    access_id = Convert.ToString(ConfigurationManager.AppSettings["PPE_NSWSaccessid"]);
                                    access_secret = Convert.ToString(ConfigurationManager.AppSettings["PPE_NSWSaccess_secret"]);
                                    APIKEY = Convert.ToString(ConfigurationManager.AppSettings["PPE_NswsGetDocumentRepositoryAPIKEY"]);
                                    RegisterURL = Convert.ToString(ConfigurationManager.AppSettings["PPE_NswsGetDocumentRepositoryAPI"]);
                                }
                                else
                                {
                                    access_id = Convert.ToString(ConfigurationManager.AppSettings["testNSWSaccessid"]);
                                    access_secret = Convert.ToString(ConfigurationManager.AppSettings["testNSWSaccess_secret"]);
                                    APIKEY = Convert.ToString(ConfigurationManager.AppSettings["testNswsGetDocumentRepositoryAPIKEY"]);
                                    RegisterURL = Convert.ToString(ConfigurationManager.AppSettings["testNswsGetDocumentRepositoryAPI"]);
                                }
                            }

                            var postData = JsonConvert.SerializeObject(reqqyerresdept);
                            responsedata = Cls_JSONFormat.PostRequestByHeaderKEYIDSECERTAPI(RegisterURL, postData, access_id, access_secret, APIKEY);

                            // PostRequestByHeaderKEYIDSECERTAPI(string RegisterURL, string postData, string access_id, string access_secret, string APIKEY)
                            Cls_nswsgetlistdocuments.Responseofpulllistdocapi oREResponse = new Cls_nswsgetlistdocuments.Responseofpulllistdocapi();
                            oREResponse = JsonConvert.DeserializeObject<Cls_nswsgetlistdocuments.Responseofpulllistdocapi>(responsedata);
                            if (oREResponse.status == "200" || oREResponse.status == "OK")
                            {
                                if (oREResponse.response != null)
                                {
                                    if (oREResponse.response.Count > 0)
                                    {
                                        List<Cls_nswsgetlistdocuments.Response> obj_subres = oREResponse.response;
                                        foreach (var r in obj_subres)
                                        {
                                            Cls_nswsgetlistdocuments.Response secrowdata = new Cls_nswsgetlistdocuments.Response();
                                            secrowdata.documentId = r.documentId;
                                            secrowdata.fileTitle = r.fileTitle;
                                            secrowdata.contentType = r.contentType;
                                            secrowdata.uploadedDate = r.uploadedDate;
                                            secrowdata.approvalId = r.approvalId;
                                            secrowdata.swsId = r.swsId;
                                            secrowdata.investorReqId = r.investorReqId;
                                            secrowdata.mnstryDprtmntId = r.mnstryDprtmntId;
                                            secrowdata.version = r.version;
                                            secrowdata.latestVersion = r.latestVersion;
                                            secrowdata.md5Hash = r.md5Hash;
                                            string imagepath = "";
                                            if (!string.IsNullOrEmpty(secrowdata.md5Hash))
                                            {
                                                string path = "@" + Convert.ToString(ConfigurationManager.AppSettings["NSWSFileuploadurlpath"]) + CategoryType + "\\" + intuserid + "\\";

                                                byte[] array = Convert.FromBase64String(r.md5Hash);
                                                string filename = r.fileTitle;

                                                //string path = @"~\NSWSFiles\" + CategoryType + "\\" + ApplicationID + "\\" + Typeofdoc + "\\";
                                                if (!Directory.Exists(HttpContext.Current.Server.MapPath(path)))
                                                {
                                                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(path));
                                                }
                                                string test = path + filename;
                                                String filepath = HttpContext.Current.Server.MapPath(path + filename);
                                                File.WriteAllBytes(filepath, array);
                                                imagepath = path + filename;
                                            }

                                            cls_nswsfilepullparmeters.resinsertnswsfile obj_filepar = new cls_nswsfilepullparmeters.resinsertnswsfile();

                                            obj_filepar.documentId = Convert.ToString(secrowdata.documentId);
                                            obj_filepar.fileTitle = Convert.ToString(secrowdata.fileTitle);
                                            obj_filepar.contentType = Convert.ToString(secrowdata.contentType);
                                            obj_filepar.uploadedDate = Convert.ToString(secrowdata.uploadedDate);
                                            obj_filepar.approvalId = Convert.ToString(secrowdata.approvalId);
                                            obj_filepar.swsId = Convert.ToString(secrowdata.swsId);
                                            obj_filepar.investorReqId = Convert.ToString(secrowdata.investorReqId);
                                            obj_filepar.mnstryDprtmntId = Convert.ToString(secrowdata.mnstryDprtmntId);
                                            obj_filepar.version = Convert.ToString(secrowdata.version);
                                            obj_filepar.latestVersion = Convert.ToString(secrowdata.latestVersion);
                                            obj_filepar.md5Hash = Convert.ToString(secrowdata.md5Hash);
                                            obj_filepar.tsipassAppID = Convert.ToString(intCFEEnterpid);
                                            obj_filepar.CategoryType = Convert.ToString(CategoryType);
                                            obj_filepar.responsedata = Convert.ToString(responsedata);
                                            obj_filepar.filepath = Convert.ToString(imagepath);
                                            bool queryresponded = DB_insertnswsfiletoinsertdata(obj_filepar);
                                        }
                                    }
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

    public class requestSWSIDgetdocAttribute
    {
        public string swsId { get; set; }
    }



    //public List<Responsenswsgetdocumetlistresponse> responsegetdocumetlistresponse { get; set; }
    //public class Responsenswsgetdocumetlistresponse
    //{
    //    public string documentId { get; set; }
    //    public string fileTitle { get; set; }
    //    public string contentType { get; set; }
    //    public string uploadedDate { get; set; }
    //    public string approvalId { get; set; }
    //    public string swsId { get; set; }
    //    public string investorReqId { get; set; }
    //    public string mnstryDprtmntId { get; set; }
    //    public string version { get; set; }
    //    public string latestVersion { get; set; }
    //    public string md5Hash { get; set; }

    //}

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 


    #endregion


    #region send/pull tsipass document

    public bool updateapprovalnswsfilebydeptid(string ApplicationID, string CategoryType, string DeptID, string ApprovalID, string NSWSContentidapprovalid,
      string NSWSContentidapprovalidresponse, string NSWSContentidapprovalidrequest)
    {
        bool output = true;
        SqlConnection con = new SqlConnection(strConnectionString);
        try
        {

            SqlCommand cmdsrc1 = new SqlCommand("nsws_updateapprovalnswsfilebydeptid", con);
            if (Convert.ToString(ApplicationID) == "" || Convert.ToString(ApplicationID) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@tsipassAppID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.Add("@tsipassAppID", SqlDbType.VarChar).Value = ApplicationID;
            }
            if (Convert.ToString(CategoryType) == "" || Convert.ToString(CategoryType) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@CategoryType", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@CategoryType", Convert.ToString(CategoryType));
            }
            if (Convert.ToString(DeptID) == "" || Convert.ToString(DeptID) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@intDeptID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@intDeptID", Convert.ToString(DeptID));
            }
            if (Convert.ToString(ApprovalID) == "" || Convert.ToString(ApprovalID) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@intApprovalID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@intApprovalID", Convert.ToString(ApprovalID));
            }

            if (Convert.ToString(NSWSContentidapprovalid) == "" || Convert.ToString(NSWSContentidapprovalid) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@NSWSContentidapprovalid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@NSWSContentidapprovalid", Convert.ToString(NSWSContentidapprovalid));
            }
            if (Convert.ToString(NSWSContentidapprovalidresponse) == "" || Convert.ToString(NSWSContentidapprovalidresponse) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@NSWSContentidapprovalidresponse", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@NSWSContentidapprovalidresponse", Convert.ToString(NSWSContentidapprovalidresponse));
            }
            if (Convert.ToString(NSWSContentidapprovalidrequest) == "" || Convert.ToString(NSWSContentidapprovalidrequest) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@NSWSContentidapprovalidrequest", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@NSWSContentidapprovalidrequest", Convert.ToString(NSWSContentidapprovalidrequest));
            }

            cmdsrc1.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmdsrc1.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            output = false;
        }

        return output;
    }



    #endregion

    #region send approve or reject doc to nsws

    //public DataSet DB_getapprovalrequestfiedata()
    //{
    //    SqlConnection con = new SqlConnection(strConnectionString);
    //    SqlDataAdapter da;
    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        con.Open();
    //        da = new SqlDataAdapter("nsws_getapprovalrequestfiedata", con);
    //        da.SelectCommand.CommandType = CommandType.StoredProcedure;
    //        da.Fill(ds);
    //        return ds;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        con.Close();
    //    }
    //}

    public DataSet DB_allgetapprovalrequestfiedata()
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("nsws_getapprovalrequestfiedata", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
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

    public DataSet DB_getapprovalrequestfiedatabyids(string ApplicationID, string DeptID, string ApprovalID, string CategoryType)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("nsws_getapprovalrequestfiedatabyids", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Convert.ToString(ApplicationID) == "" || Convert.ToString(ApplicationID) == null)
            {
                da.SelectCommand.Parameters.AddWithValue("@ApplicationID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@ApplicationID", SqlDbType.VarChar).Value = ApplicationID;
            }
            if (Convert.ToString(DeptID) == "" || Convert.ToString(DeptID) == null)
            {
                da.SelectCommand.Parameters.AddWithValue("@DeptID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@DeptID", SqlDbType.VarChar).Value = DeptID;
            }
            if (Convert.ToString(ApprovalID) == "" || Convert.ToString(ApprovalID) == null)
            {
                da.SelectCommand.Parameters.AddWithValue("@ApprovalID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@ApprovalID", SqlDbType.VarChar).Value = ApprovalID;
            }
            if (Convert.ToString(CategoryType) == "" || Convert.ToString(CategoryType) == null)
            {
                da.SelectCommand.Parameters.AddWithValue("@CategoryType", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                da.SelectCommand.Parameters.AddWithValue("@CategoryType", Convert.ToString(CategoryType));
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
            con.Close();
        }
    }
    public string getapprovalrequestfiedatabyids(string ApplicationID, string DeptID, string ApprovalID, string CategoryType)
    {
        string responsedata = string.Empty;
        try
        {
            DataSet dt_data = new DataSet();
            dt_data = DB_getapprovalrequestfiedatabyids(ApplicationID, DeptID, ApprovalID, CategoryType);
            LogErrorFile.LogData(Convert.ToString(dt_data.Tables.Count));
            if (dt_data.Tables.Count > 0)
            {
                if (dt_data.Tables[0].Rows.Count > 0)
                {
                    for (int j = 0; j < dt_data.Tables[0].Rows.Count; j++)
                    {

                        requestJsonnswspushlicensecwithurl obj_nswsdept = new requestJsonnswspushlicensecwithurl();
                        obj_nswsdept.documentId = Convert.ToString(dt_data.Tables[0].Rows[j]["documentId"]);
                        obj_nswsdept.documentName = Convert.ToString(dt_data.Tables[0].Rows[j]["documentName"]);
                        obj_nswsdept.approvalId = Convert.ToString(dt_data.Tables[0].Rows[j]["licenseReqId"]);
                        obj_nswsdept.swsId = Convert.ToString(dt_data.Tables[0].Rows[j]["SWS_ID"]);
                        obj_nswsdept.investorReqId = Convert.ToString(dt_data.Tables[0].Rows[j]["investorReqId"]);
                        obj_nswsdept.mnstryDprtmntId = Convert.ToString(dt_data.Tables[0].Rows[j]["mnstryDprtmntId"]);
                        string fullFilePath = Convert.ToString(dt_data.Tables[0].Rows[j]["filepath"]);
                        obj_nswsdept.inputFileURL = Convert.ToString(dt_data.Tables[0].Rows[j]["filepath"]);
                        obj_nswsdept.fileName = Convert.ToString(dt_data.Tables[0].Rows[j]["fileName"]);

                        //  access_id: M_TTN001
                        //  access_secret:TtnTest@1234
                        //    License Push API Min1@GLSD12

                        //string access_id = "M_TTN001";
                        //string access_secret = "TtnTest@1234";
                        //string LicensePushAPIapikey = "Min1@GLSD12";
                        //string RegisterURL = "https://uat-nsws-mnstrportal.investindia.gov.in/nsws_document/pushDocumentWithURL";

                        string access_id = ""; string access_secret = ""; string APIKEY = ""; string RegisterURL = "";
                        if (Convert.ToString(ConfigurationManager.AppSettings["NSWSIsserver"]) == "1")
                        {
                            access_id = Convert.ToString(ConfigurationManager.AppSettings["NSWSaccessidpushurl"]);
                            access_secret = Convert.ToString(ConfigurationManager.AppSettings["NSWSaccess_secretpushurl"]);
                            APIKEY = Convert.ToString(ConfigurationManager.AppSettings["NswsPushLicenseafterpaymentAPIKEYpushurl"]);
                            RegisterURL = Convert.ToString(ConfigurationManager.AppSettings["NswspushDocumentWithURL"]);
                        }
                        else
                        {
                            if (Convert.ToString(ConfigurationManager.AppSettings["NSWSIsserverPPE"]) == "1")
                            {
                                access_id = Convert.ToString(ConfigurationManager.AppSettings["PPE_NSWSaccessidpushurl"]);
                                access_secret = Convert.ToString(ConfigurationManager.AppSettings["PPE_NSWSaccess_secretpushurl"]);
                                APIKEY = Convert.ToString(ConfigurationManager.AppSettings["PPE_NswsPushLicenseafterpaymentAPIKEYpushurl"]);
                                RegisterURL = Convert.ToString(ConfigurationManager.AppSettings["PPE_NswspushDocumentWithURL"]);
                            }
                            else
                            {
                                access_id = Convert.ToString(ConfigurationManager.AppSettings["testNSWSaccessidpushurl"]);
                                access_secret = Convert.ToString(ConfigurationManager.AppSettings["testNSWSaccess_secretpushurl"]);
                                APIKEY = Convert.ToString(ConfigurationManager.AppSettings["testNswsPushLicenseafterpaymentAPIKEYpushurl"]);
                                RegisterURL = Convert.ToString(ConfigurationManager.AppSettings["testNswspushDocumentWithURL"]);
                            }
                        }
                        var postData = JsonConvert.SerializeObject(obj_nswsdept);
                        LogErrorFile.LogData(Convert.ToString(postData));
                        string alldataforlog = Convert.ToString(RegisterURL) + "data" + Convert.ToString(postData) + "accessid" + Convert.ToString(access_id) + "accesssecert" + Convert.ToString(access_secret) + "apikey" + Convert.ToString(APIKEY);
                        LogErrorFile.LogData(alldataforlog);
                        //LogErrorFile.LogData(Convert.ToString(RegisterURL) + "data" + Convert.ToString(postData) + "accessid" + Convert.ToString(access_id) + "accesssecert" + +Convert.ToString(access_secret)+"apikey" + Convert.ToString(APIKEY));
                        responsedata = Cls_JSONFormat.PostRequestByHeaderKEYIDSECERTAPI(RegisterURL, postData, access_id, access_secret, APIKEY);
                        // PostRequestByHeaderKEYIDSECERTAPI(string RegisterURL, string postData, string access_id, string access_secret, string APIKEY)
                        LogErrorFile.LogData(Convert.ToString(responsedata));
                        responseJsonnswspushlicensecwithurl res_approvalstatus = new responseJsonnswspushlicensecwithurl();
                        res_approvalstatus = JsonConvert.DeserializeObject<responseJsonnswspushlicensecwithurl>(responsedata);

                        updateresponsepushapprovalfiledata(ApplicationID, CategoryType, "1", responsedata, DeptID, ApprovalID, res_approvalstatus.contentId, obj_nswsdept.documentId);


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

    public bool updateresponsepushapprovalfiledata(string ApplicationID, string CategoryType, string NSWSrespFLG, string NSWSresponse, string DeptID, string ApprovalID, string contentId, string Documentid)
    {
        bool output = true;
        SqlConnection con = new SqlConnection(strConnectionString);
        try
        {
            SqlCommand cmdsrc1 = new SqlCommand("nsws_updateresponsepushapprovalfiledatabyids", con);
            if (Convert.ToString(ApplicationID) == "" || Convert.ToString(ApplicationID) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@ApplicationID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.Add("@ApplicationID", SqlDbType.VarChar).Value = ApplicationID;
            }
            if (Convert.ToString(CategoryType) == "" || Convert.ToString(CategoryType) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@CategoryType", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@CategoryType", Convert.ToString(CategoryType));
            }
            if (Convert.ToString(DeptID) == "" || Convert.ToString(DeptID) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@DeptID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@DeptID", Convert.ToString(DeptID));
            }
            if (Convert.ToString(NSWSresponse) == "" || Convert.ToString(NSWSresponse) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@Response", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@Response", Convert.ToString(NSWSresponse));
            }
            if (Convert.ToString(NSWSrespFLG) == "" || Convert.ToString(NSWSrespFLG) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@ResponseFLG", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@ResponseFLG", Convert.ToString(NSWSrespFLG));
            }
            if (Convert.ToString(ApprovalID) == "" || Convert.ToString(ApprovalID) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@ApprovalID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@ApprovalID", Convert.ToString(ApprovalID));
            }

            if (Convert.ToString(contentId) == "" || Convert.ToString(contentId) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@contentId", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@contentId", Convert.ToString(contentId));
            }
            if (Convert.ToString(Documentid) == "" || Convert.ToString(Documentid) == null)
            {
                cmdsrc1.Parameters.AddWithValue("@Documentid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdsrc1.Parameters.AddWithValue("@Documentid", Convert.ToString(Documentid));
            }

            cmdsrc1.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmdsrc1.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            output = false;
        }

        return output;
    }

    public class requestJsonnswspushlicensecwithurl
    {
        public string documentId { get; set; }
        public string documentName { get; set; }
        public string approvalId { get; set; }
        public string swsId { get; set; }
        public string investorReqId { get; set; }
        public string mnstryDprtmntId { get; set; }
        public string inputFileURL { get; set; }
        public string fileName { get; set; }
    }

    public class responseJsonnswspushlicensecwithurl
    {
        public string contentId { get; set; }
    }

    #endregion
}