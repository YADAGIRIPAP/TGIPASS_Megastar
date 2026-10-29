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
using System.Web.Services;
using System.Web.Services.Protocols;
using BusinessLogic;
using System.Xml;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public partial class UI_TSiPASS_Departmentservice_Buildnow : System.Web.UI.Page
{
    General gen = new General();
    DB.DB con = new DB.DB();

    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        try
        {
            string currentDateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            //  DateTimeOffset.ParseExact(currentDateTime.ToString(), "yyyy-MM-dd'T'HH:mm:sszzz",                                                       System.Globalization.CultureInfo.InvariantCulture);
            //hmwssb.TsIpassQueryAndUploadDocuments()
            //if (Session["objUsrDtl"] != null)TypeOfIncentivesNew frmIncentiveForm4//USP_UPD_OldOnlineOrderNo_BILLDESC
            //{
            if (!IsPostBack)
            {
                //string UIDNO = Request.QueryString["UIDNO"].ToString();Cm$@1234
                string UIDNO = "LRG0060012140685";// "LRG02400397795";// "SML031001720991";//"MEG006001613948";// "MIC020001312293";// "MIC013005511787";// "SML004054411625";//"MEG02000064425";//"SML00500064419";//"SML00500064419";


                ds = gen.GetDepartmentonuid(UIDNO);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dt = ds.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string deptid = dt.Rows[i]["intApprovalid"].ToString();
                        if (deptid == "38")
                        {
                            string jsonData = "";
                            DataSet dsghmcbuildnow = new DataSet();
                            dsghmcbuildnow = getdepartmentdetailsonuid(UIDNO, deptid);

                            if (dsghmcbuildnow != null && dsghmcbuildnow.Tables.Count > 0 && dsghmcbuildnow.Tables[0].Rows.Count > 0)
                            {
                                DataRow dr = dsghmcbuildnow.Tables[0].Rows[0];

                                var request = new Build_nowRequest
                                {
                                    scrutiny_key = dsghmcbuildnow.Tables[0].Rows[0]["Scrutiny_Key"].ToString(),
                                    application_id = dsghmcbuildnow.Tables[0].Rows[0]["Application_ID"].ToString(),
                                    name_of_the_industry = dsghmcbuildnow.Tables[0].Rows[0]["nameofunit"].ToString(),
                                    proposal_for = dsghmcbuildnow.Tables[0].Rows[0]["ProposalFor"].ToString(),
                                    type_of_factory = dsghmcbuildnow.Tables[0].Rows[0]["FactoryType"].ToString(),
                                    category = dsghmcbuildnow.Tables[0].Rows[0]["PolCategory"].ToString(),

                                    site_address = new BuildnowSiteAddress
                                    {
                                        district_id = dsghmcbuildnow.Tables[0].Rows[0]["districtId"].ToString(),
                                        mandal_id = (dsghmcbuildnow.Tables[0].Rows[0]["mandalId"].ToString()),
                                        village_id = (dsghmcbuildnow.Tables[0].Rows[0]["villageId"].ToString()),
                                        street_name = dsghmcbuildnow.Tables[0].Rows[0]["StreetName"].ToString(),
                                        survey_no = dsghmcbuildnow.Tables[0].Rows[0]["SurveyNo"].ToString(),
                                        pin_code = (dsghmcbuildnow.Tables[0].Rows[0]["Land_Pincode"].ToString()),
                                        organization_type = dsghmcbuildnow.Tables[0].Rows[0]["organization_type"].ToString(),
                                        organization_name_id = (dsghmcbuildnow.Tables[0].Rows[0]["organization_name_id"].ToString()),
                                        gram_panchayat_uda_name = dsghmcbuildnow.Tables[0].Rows[0]["Name_Gramapachayat"].ToString()
                                    },

                                    correspondence_address = new BuildnowCorrespondenceAddress
                                    {
                                        district_id = (dsghmcbuildnow.Tables[0].Rows[0]["CorrDistrictId"].ToString()),
                                        mandal_id = (dsghmcbuildnow.Tables[0].Rows[0]["CorrMandalId"].ToString()),
                                        village_id = (dsghmcbuildnow.Tables[0].Rows[0]["CorrVillageId"].ToString()),
                                        street_name = (dsghmcbuildnow.Tables[0].Rows[0]["CorrStreetName"].ToString()),
                                        door_no_or_plot_no = (dsghmcbuildnow.Tables[0].Rows[0]["Door_No"].ToString()),
                                        pin_code = (dsghmcbuildnow.Tables[0].Rows[0]["pincode"].ToString())
                                    },

                                    owner_details = new BuildnowOwnerDetails
                                    {
                                        name_of_the_promoter = (dsghmcbuildnow.Tables[0].Rows[0]["NameofthePromoter"].ToString()),
                                        son_or_wife_of = (dsghmcbuildnow.Tables[0].Rows[0]["SoWo"].ToString()),
                                        mobile_number = (dsghmcbuildnow.Tables[0].Rows[0]["MobileNumber"].ToString()),
                                        email_id = (dsghmcbuildnow.Tables[0].Rows[0]["Email"].ToString()),
                                        caste = (dsghmcbuildnow.Tables[0].Rows[0]["caste"].ToString()),
                                        is_differently_abled = (dsghmcbuildnow.Tables[0].Rows[0]["diffabled"].ToString()),
                                        is_women_entrepreneur = (dsghmcbuildnow.Tables[0].Rows[0]["is_women_entrepreneur"].ToString()),
                                        is_minority = (dsghmcbuildnow.Tables[0].Rows[0]["is_minority"].ToString())
                                    },

                                    land_details = new BuildnowLandDetails
                                    {
                                        land_extent_in_sq_mts = (dsghmcbuildnow.Tables[0].Rows[0]["Tot_Extent"].ToString()),
                                        proposed_use_area_in_sq_mts = (dsghmcbuildnow.Tables[0].Rows[0]["Land_ProposedArea"].ToString()),
                                        type_of_approach_road_id = (dsghmcbuildnow.Tables[0].Rows[0]["TypeofApprochid"].ToString()),
                                        location_falls_under = (dsghmcbuildnow.Tables[0].Rows[0]["Locationcomesunder"].ToString()),
                                        land_use_as_per_master_plan_id = (dsghmcbuildnow.Tables[0].Rows[0]["LandUseMasterPlanId"].ToString())
                                    },

                                    proposed_details = new BuildnowProposedDetails
                                    {
                                        total_investment_amount_in_inr = (dsghmcbuildnow.Tables[0].Rows[0]["TotalInvestment"].ToString()),
                                        total_plant_and_machinery_cost_in_inr = (dsghmcbuildnow.Tables[0].Rows[0]["PlantMachineryCost"].ToString())
                                    }
                                    //scrutiny_key = "05dca13a-489e-4b6d-8725-ff8e6e7668cf",
                                    //application_id = "001068/HMDA/00322/SWBP/GTK/2025",
                                    //name_of_the_industry = "TEST_INDUSTRY",
                                    //proposal_for = "New",
                                    //type_of_factory = "Hazardous",
                                    //category = "Orange",

                                    //site_address = new BuildnowSiteAddress
                                    //{
                                    //    district_id = "5",
                                    //    mandal_id = "189",
                                    //    village_id = "5239",
                                    //    street_name = "Test Street",
                                    //    survey_no = "23/T",
                                    //    pin_code = "500055",
                                    //    organization_type = "Municipality",
                                    //    organization_name_id = "23",
                                    //    gram_panchayat_uda_name = "KUDA"
                                    //},

                                    //correspondence_address = new BuildnowCorrespondenceAddress
                                    //{
                                    //    district_id = "5",
                                    //    mandal_id = "189",
                                    //    village_id = "5239",
                                    //    street_name = "Test 2 Street",
                                    //    door_no_or_plot_no = "34-233",
                                    //    pin_code = "500055"
                                    //},

                                    //owner_details = new BuildnowOwnerDetails
                                    //{
                                    //    name_of_the_promoter = "Smt Radha",
                                    //    son_or_wife_of = "Sri Krishna",
                                    //    mobile_number = "9999999999",
                                    //    email_id = "test@test.com",
                                    //    caste = "OBC",
                                    //    is_differently_abled = "No",
                                    //    is_women_entrepreneur = "No",
                                    //    is_minority = "No"
                                    //},

                                    //land_details = new BuildnowLandDetails
                                    //{
                                    //    land_extent_in_sq_mts = "23456.23",
                                    //    proposed_use_area_in_sq_mts = "15000.35",
                                    //    type_of_approach_road_id = "2",
                                    //    location_falls_under = "GHMC",
                                    //    land_use_as_per_master_plan_id = "4"
                                    //},

                                    //proposed_details = new BuildnowProposedDetails
                                    //{
                                    //    total_investment_amount_in_inr = "234343354.89",
                                    //    total_plant_and_machinery_cost_in_inr = "3433433.90"
                                    //}
                                };

                                // Fetch documents from another DataSet (example)
                                DataSet dsDocs = getattachmentdetailsonuid(UIDNO, deptid, "");
                                var docs = new List<BuildnowDocument>();

                                //if (dsDocs != null && dsDocs.Tables.Count > 0)
                                //{
                                //    foreach (DataRow d in dsDocs.Tables[0].Rows)
                                //    {
                                //        docs.Add(new BuildnowDocument
                                //        {
                                //            id = "1",
                                //            name = "Registration Deed",
                                //            url = "https://tg-build-now-uat-media-static.s3.amazonaws.com/uat/media/pipeline_item/5e564c7b-a051-4762-8611-59235615725a/documents/GHMC_INSTANT_APPROVAL_BPO/Provisional_Building_Permit_Order"
                                //        });
                                //    }
                                //}
                                if (dsDocs != null && dsDocs.Tables.Count > 0)
                                {
                                    foreach (DataTable table in dsDocs.Tables)
                                    {
                                        foreach (DataRow d in table.Rows)
                                        {
                                            docs.Add(new BuildnowDocument
                                            {
                                                id = Convert.ToString(d["DocId"]),
                                                name = Convert.ToString(d["DocName"]),
                                                url = Convert.ToString(d["Filepath"])
                                            });
                                        }
                                    }
                                }
                                //var docs = new List<BuildnowDocument>();
                                //docs.Add(new BuildnowDocument
                                //{
                                //    id = "1",
                                //    name = "Registration Deed",
                                //    url = "https://tg-build-now-uat-media-static.s3.amazonaws.com/uat/media/pipeline_item/5e564c7b-a051-4762-8611-59235615725a/documents/GHMC_INSTANT_APPROVAL_BPO/Provisional_Building_Permit_Order"
                                //});

                                //docs.Add(new BuildnowDocument
                                //{
                                //    id = "2",
                                //    name = "Process Flow Chart",
                                //    url = "https://tg-build-now-uat-media-static.s3.amazonaws.com/uat/media/pipeline_item/5e564c7b-a051-4762-8611-59235615725a/documents/GHMC_INSTANT_APPROVAL_BPO/Provisional_Building_Permit_Order"
                                //});
                                request.documents = docs;

                                // Convert to JSON
                                jsonData = JsonConvert.SerializeObject(request);
                                // Console.WriteLine(jsonData);
                            }
                            ServicePointManager.Expect100Continue = true;
                            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                            string url = "https://uat-apis.buildnow.floww.ai/api/bps_integrations/ipass/application_details/v1/";

                            // string jsonData = JsonConvert.SerializeObject(request);

                            // 3. Send request with API Key in header
                            string apiKey = "VUOApTUxK045LVELPgvRWMKEaeAVKxW1wrr8a844";  // provided API key

                            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                            webRequest.Method = "POST";
                            webRequest.Timeout = 200000;
                            webRequest.ContentType = "application/json";

                            // If API requires header like `Authorization: Bearer {apikey}`:
                            // webRequest.Headers["Authorization"] = "Bearer " + apiKey;

                            // If API requires header like `x-api-key: {apikey}` (common in AWS / API Gateway):
                            webRequest.Headers["x-api-key"] = apiKey;

                            // Write JSON into request body
                            byte[] byteArray = Encoding.UTF8.GetBytes(jsonData);
                            webRequest.ContentLength = byteArray.Length;

                            using (Stream dataStream = webRequest.GetRequestStream())
                            {
                                dataStream.Write(byteArray, 0, byteArray.Length);
                            }

                            try
                            {
                                using (WebResponse response = webRequest.GetResponse())
                                using (Stream responseStream = response.GetResponseStream())
                                using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8))
                                {
                                    string responseJson = reader.ReadToEnd();
                                    System.Diagnostics.Debug.WriteLine("Service Response: " + responseJson);

                                    string script = string.Format("alert('Success: {0}');", responseJson.Replace("'", "\\'"));

                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "SuccessAlert", script, true);
                                }
                            }
                            catch (WebException ex)
                            {
                                // 👇 This will print the real error message from server
                                if (ex.Response != null)
                                {
                                    using (var stream = ex.Response.GetResponseStream())
                                    using (var reader = new StreamReader(stream))
                                    {
                                        string errorResponse = reader.ReadToEnd();
                                        System.Diagnostics.Debug.WriteLine("Service Response: " + errorResponse);

                                        string script = string.Format("alert('failure test: {0}');", errorResponse.Replace("'", "\\'"));

                                        Page.ClientScript.RegisterStartupScript(this.GetType(), "failureAlert", script, true);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("WebException: " + ex.Message);
                                }
                            }
                        }
                    }
                }
            }
        }

        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.Visible = true;
        }
    }
    public DataSet getdepartmentdetailsonuid(string uidno, string deptid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GETDETAILS_DEPARTMENT_SERVICE_BUILDNOWHMDA", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (uidno.Trim() != "" || uidno.Trim() != null)
            {
                da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = uidno.ToString();
            }
            else
            {
                da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = null;
            }
            if (deptid.Trim() != "" || deptid.Trim() != null)
            {
                da.SelectCommand.Parameters.Add("@DEPARTMENTID", SqlDbType.VarChar).Value = deptid.ToString();
            }
            else
            {
                da.SelectCommand.Parameters.Add("@DEPARTMENTID", SqlDbType.VarChar).Value = null;
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
    public DataSet getattachmentdetailsonuid(string uidno, string deptid, string applid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_ATTACHMENTS_UID_BUILDNOWHMDA", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (uidno.Trim() != "" || uidno.Trim() != null)
            {
                da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = uidno.ToString();
            }
            else
            {
                da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = null;
            }
            if (deptid.Trim() != "" || deptid.Trim() != null)
            {
                da.SelectCommand.Parameters.Add("@DEPARTMENTID", SqlDbType.VarChar).Value = deptid.ToString();
            }
            else
            {
                da.SelectCommand.Parameters.Add("@DEPARTMENTID", SqlDbType.VarChar).Value = null;
            }
            if (applid.Trim() != "" || applid.Trim() != null)
            {
                da.SelectCommand.Parameters.Add("@APPLID", SqlDbType.VarChar).Value = applid.ToString();
            }
            else
            {
                da.SelectCommand.Parameters.Add("@APPLID", SqlDbType.VarChar).Value = null;
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


}
public class BuildnowSiteAddress
{
    public string district_id { get; set; }
    public string mandal_id { get; set; }
    public string village_id { get; set; }
    public string street_name { get; set; }
    public string survey_no { get; set; }
    public string pin_code { get; set; }
    public string organization_type { get; set; }
    public string organization_name_id { get; set; }
    public string gram_panchayat_uda_name { get; set; }
}

public class BuildnowCorrespondenceAddress
{
    public string district_id { get; set; }
    public string mandal_id { get; set; }
    public string village_id { get; set; }
    public string street_name { get; set; }
    public string door_no_or_plot_no { get; set; }
    public string pin_code { get; set; }
}

public class BuildnowOwnerDetails
{
    public string name_of_the_promoter { get; set; }
    public string son_or_wife_of { get; set; }
    public string mobile_number { get; set; }
    public string email_id { get; set; }
    public string caste { get; set; }
    public string is_differently_abled { get; set; }
    public string is_women_entrepreneur { get; set; }
    public string is_minority { get; set; }
}

public class BuildnowLandDetails
{
    public string land_extent_in_sq_mts { get; set; }
    public string proposed_use_area_in_sq_mts { get; set; }
    public string type_of_approach_road_id { get; set; }
    public string location_falls_under { get; set; }
    public string land_use_as_per_master_plan_id { get; set; }
}

public class BuildnowProposedDetails
{
    public string total_investment_amount_in_inr { get; set; }
    public string total_plant_and_machinery_cost_in_inr { get; set; }
}

public class BuildnowDocument
{
    public string id { get; set; }
    public string name { get; set; }
    public string url { get; set; }
}

public class Build_nowRequest
{
    public string scrutiny_key { get; set; }
    public string application_id { get; set; }
    public string name_of_the_industry { get; set; }
    public string proposal_for { get; set; }
    public string type_of_factory { get; set; }
    public string category { get; set; }
    public BuildnowSiteAddress site_address { get; set; }
    public BuildnowCorrespondenceAddress correspondence_address { get; set; }
    public BuildnowOwnerDetails owner_details { get; set; }
    public BuildnowLandDetails land_details { get; set; }
    public BuildnowProposedDetails proposed_details { get; set; }
    public List<BuildnowDocument> documents { get; set; }
}