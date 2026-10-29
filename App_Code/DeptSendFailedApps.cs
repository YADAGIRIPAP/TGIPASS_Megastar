using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Text;
using System.Web.Security;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Configuration;
using System.Xml; 
/// <summary>
/// Summary description for DeptSendFailedApps
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class DeptSendFailedApps : System.Web.Services.WebService
{
    DB.DB con = new DB.DB();
    DataSet ds;
    DataTable dt;
    SqlDataAdapter myDataAdapter;
    comFunctions cmf = new comFunctions();
    General genogj = new General();
    General Gen = new General();
    CFEWebServices sendata = new CFEWebServices();

    HttpWebRequest request;
    static Stream dataStream;
    string responseFromServer = "";

    WebserviceVO webvo = new WebserviceVO();

    General gen = new General();
    WebClient wc = new WebClient();
    TSNPDCLService.TsipassWsService tsnpdcl = new TSNPDCLService.TsipassWsService();
    TSSPDCLService.TSSPDCLIPassService tsspdcl = new TSSPDCLService.TSSPDCLIPassService();
    FactoryService.TSFactoryServiceImplService factory = new FactoryService.TSFactoryServiceImplService();
    FireService.Service1 fire = new FireService.Service1();
    //BoilerService.TSBoilerServiceImplService boiler = new BoilerService.TSBoilerServiceImplService();
    LabourService.TSLabourServiceImplService labourservice = new LabourService.TSLabourServiceImplService();
    NALAService.MeeSevaWebService nalaservice = new NALAService.MeeSevaWebService();
    HMWSSBService.TSiPASSNewConnectionUC hmwssb = new HMWSSBService.TSiPASSNewConnectionUC();
    HMDAService.tsipass hmdaservice = new HMDAService.tsipass();
    HMDAService.ApplicationFormResponse hmdapplication = new HMDAService.ApplicationFormResponse();
    TSIICService.tsipass tsiicservice = new TSIICService.tsipass();
    TSIICService.ApplicationFormResponse tsiicapplication = new TSIICService.ApplicationFormResponse();

    // CFO
    BoilerService.TSBoilerServiceImplService Boiler = new BoilerService.TSBoilerServiceImplService();
    LabourCFOService.TSLabourServiceImplService labourserviceCfo = new LabourCFOService.TSLabourServiceImplService();
    // LabourService.TSLabourServiceImplService labourservice = new LabourService.TSLabourServiceImplService();
    FireServiceCFO.Service1 firecfo = new FireServiceCFO.Service1();
    FactoryServiceCFO.TSFactoryServiceImplService factorycfo = new FactoryServiceCFO.TSFactoryServiceImplService();
    CEIGService.InstallationAppServiceImplService ceifcfo = new CEIGService.InstallationAppServiceImplService();

    paymentresponseVOs paymentresponseVOsobj = null;
    public DeptSendFailedApps()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    [WebMethod]
    public void FailedAppswebservice(string UIDNO)
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        try
        {
            sendata.webservicecfe(UIDNO);
        }
        catch (Exception ex)
        {

        }
    }
    [WebMethod]
    public void FailedAppswebservicecfo(string UIDNO)
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        try
        {
            //if (Session["objUsrDtl"] != null)
            //{

            // string UIDNO = Request.QueryString["UIDNO"].ToString();
            // string UIDNO = "SML018004917311CFO"; //"SML018004917311CFO";// "LRG005000817440CFO";//"SML00500064419";//"SML00500064419";
            ds = gen.GetDepartmentonuidCFO(UIDNO);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string deptid = dt.Rows[i]["intApprovalid"].ToString();

                    if (deptid == "16")
                    {
                        CEIGService.installationApplication ceifvo = new CEIGService.installationApplication();
                        DataSet dsdept = new DataSet();
                        string valueshmwssb = "";
                        string outputhmwssb = "";
                        string outpayhmwssb = "";
                        dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);
                        valueshmwssb = dsdept.GetXml();
                        if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                        {

                            ceifvo.aadhar_number = dsdept.Tables[0].Rows[0]["AadharNo"].ToString();
                            ceifvo.applicationID = dsdept.Tables[0].Rows[0]["intCFOPowerid"].ToString();
                            ceifvo.UID = dsdept.Tables[0].Rows[0]["UID_No"].ToString();
                            ceifvo.atc = dsdept.Tables[0].Rows[0]["ATC"].ToString();
                            //ceifvo.checkListUploads = "";
                            ceifvo.cli_already_installed = dsdept.Tables[0].Rows[0]["Cont_Demand_Max_Already"].ToString();
                            ceifvo.cli_proposed = dsdept.Tables[0].Rows[0]["Cont_Demand_Max_Proposed"].ToString();
                            ceifvo.cmd_already_installed = dsdept.Tables[0].Rows[0]["Connect_Load_A"].ToString();
                            ceifvo.cmd_proposed = dsdept.Tables[0].Rows[0]["Connect_Load_B"].ToString();
                            ceifvo.customer_remarks = "";//dsdept.Tables[0].Rows[0][""].ToString();
                            ceifvo.district_id = dsdept.Tables[0].Rows[0]["intDistrictid"].ToString();
                            ceifvo.email_id = dsdept.Tables[0].Rows[0]["Email"].ToString();
                            ceifvo.entrepreneurID = dsdept.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                            ceifvo.file_number = "";// dsdept.Tables[0].Rows[0][""].ToString();
                            ceifvo.first_name = dsdept.Tables[0].Rows[0]["NameofthePromoter"].ToString();
                            ceifvo.hno = dsdept.Tables[0].Rows[0]["Survey_No"].ToString();
                            ceifvo.industry_district_id = dsdept.Tables[0].Rows[0]["Prop_intDistrictid"].ToString();
                            ceifvo.industry_hno = dsdept.Tables[0].Rows[0]["Door_No"].ToString();
                            ceifvo.industry_mandal_id = dsdept.Tables[0].Rows[0]["Prop_intMandalid"].ToString();
                            ceifvo.industry_pincode = dsdept.Tables[0].Rows[0]["Pincode"].ToString();
                            ceifvo.industry_plot_no = dsdept.Tables[0].Rows[0]["PLOTNO"].ToString();
                            ceifvo.industry_street_name = dsdept.Tables[0].Rows[0]["StreetName"].ToString();
                            ceifvo.industry_sy_no = dsdept.Tables[0].Rows[0]["Survey_No"].ToString();
                            ceifvo.industry_village_id = dsdept.Tables[0].Rows[0]["Prop_intVillageid"].ToString();
                            ceifvo.last_name = dsdept.Tables[0].Rows[0]["NameofthePromoter"].ToString();
                            ceifvo.loction_district_id = dsdept.Tables[0].Rows[0]["intDistrictid"].ToString();
                            ceifvo.mandal_id = dsdept.Tables[0].Rows[0]["intMandalid"].ToString();
                            ceifvo.mobile_no = dsdept.Tables[0].Rows[0]["MobileNumber"].ToString();
                            ceifvo.name_of_industry = dsdept.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();
                            ceifvo.name_of_promoter = dsdept.Tables[0].Rows[0]["NameofthePromoter"].ToString();
                            ceifvo.pan_number = dsdept.Tables[0].Rows[0]["PANcardno"].ToString();
                            ceifvo.pincode = dsdept.Tables[0].Rows[0]["Pincode"].ToString();
                            ceifvo.plant_slno = dsdept.Tables[0].Rows[0]["Plant_slno"].ToString();
                            ceifvo.plot_no = dsdept.Tables[0].Rows[0]["DOOR_nO"].ToString();
                            ceifvo.proposal_for = dsdept.Tables[0].Rows[0]["ProposalForQue"].ToString();
                            ceifvo.questionaireID = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                            ceifvo.regulation_slno = dsdept.Tables[0].Rows[0]["Regulation_type"].ToString();
                            ceifvo.so_do_wo = dsdept.Tables[0].Rows[0]["NameofthePromoter"].ToString();
                            ceifvo.street_name = dsdept.Tables[0].Rows[0]["Street_Name"].ToString();
                            ceifvo.sy_no = "123";// dsdept.Tables[0].Rows[0][""].ToString();
                            ceifvo.system_ip = "1.1.1.1"; ;// dsdept.Tables[0].Rows[0][""].ToString();                                
                            ceifvo.type_of_industry = "35";//dsdept.Tables[0].Rows[0]["TypeofFactory"].ToString();
                            ceifvo.type_of_industry_others = "";// dsdept.Tables[0].Rows[0][""].ToString();                              
                            ceifvo.user_name = dsdept.Tables[0].Rows[0]["User_name"].ToString();
                            ceifvo.password = dsdept.Tables[0].Rows[0]["password"].ToString();
                            ceifvo.village_id = dsdept.Tables[0].Rows[0]["Village_Name"].ToString();
                            ceifvo.voltage_slno = dsdept.Tables[0].Rows[0]["Voltage_Slno"].ToString();
                            DataSet dsBoiler = new DataSet();
                            CEIGService.checkListUploads[] Uploaddocuments = null;
                            dsBoiler = gen.getattachmentdetailsonuidCFO(UIDNO, "16", "");
                            string attcvalueshmwssb = dsBoiler.GetXml();
                            if (dsBoiler != null && dsBoiler.Tables.Count > 0)
                            {

                                ///Registration Deed////

                                //if (dsBoiler.Tables[0].Rows.Count > 0)
                                //{
                                DataTable dtceigdocuments = new DataTable();
                                dtceigdocuments = dsBoiler.Tables[0];
                                Uploaddocuments = new CEIGService.checkListUploads[dtceigdocuments.Rows.Count];

                                for (int n = 0; n < dtceigdocuments.Rows.Count; n++)
                                {
                                    CEIGService.checkListUploads uploadvo = new CEIGService.checkListUploads();
                                    uploadvo.documentName = dtceigdocuments.Rows[n]["FileName"].ToString();
                                    uploadvo.documentPath = dtceigdocuments.Rows[n]["Filepath"].ToString();
                                    uploadvo.documentId = Convert.ToInt32(dtceigdocuments.Rows[n]["Documentid"].ToString());
                                    Uploaddocuments[n] = uploadvo;
                                }
                                ceifvo.checkListUploads = Uploaddocuments;
                                //}
                            }
                            string ceigout = ceifcfo.insertIntoInstallationApproval(ceifvo);
                            if (ceigout == "SUCCESS")
                            {
                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", ceigout, "Y");
                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "A", ceigout, "N");
                                //int k = gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["intDeptid"].ToString(), dsdept.Tables[0].Rows[0]["quessionaire_id"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                                int k = gen.InsertDeptDateTracingCFO(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                            }
                            else
                            {
                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", ceigout, "N");
                            }
                        }
                    }

                    if (deptid == "27") // Boilers
                    {
                        try
                        {
                            BoilerService.plan boilervo = new BoilerService.plan();

                            DataSet dsdept = new DataSet();
                            string valueshmwssb = "";
                            string outputhmwssb = "";
                            string outpayhmwssb = "";
                            dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);
                            valueshmwssb = dsdept.GetXml();
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                            {

                                boilervo.amount_tobe_paid = dsdept.Tables[0].Rows[0]["amount_tobe_paid"].ToString();
                                boilervo.application_stage = Convert.ToInt16(dsdept.Tables[0].Rows[0]["application_stage"].ToString());
                                //boilervo.application_type = dsdept.Tables[0].Rows[0]["application_type"].ToString();
                                boilervo.applicationId = dsdept.Tables[0].Rows[0]["applicationId"].ToString();
                                //boilervo.assigned_to_officer_id = Convert.ToInt16(dsdept.Tables[0].Rows[0]["assigned_to_officer_id"].ToString());
                                boilervo.bankAmount = dsdept.Tables[0].Rows[0]["bankAmount"].ToString();
                                boilervo.bankDate = dsdept.Tables[0].Rows[0]["bankDate"].ToString();
                                boilervo.bankName = dsdept.Tables[0].Rows[0]["bankName"].ToString();
                                boilervo.bankstatus = dsdept.Tables[0].Rows[0]["bankstatus"].ToString();
                                boilervo.banktransid = dsdept.Tables[0].Rows[0]["banktransid"].ToString();
                                boilervo.boiler_maker_name = dsdept.Tables[0].Rows[0]["boiler_maker_name"].ToString();
                                boilervo.boiler_maker_no = dsdept.Tables[0].Rows[0]["boiler_maker_no"].ToString();
                                boilervo.boiler_rating = dsdept.Tables[0].Rows[0]["boiler_rating"].ToString();
                                boilervo.boiler_used_for = dsdept.Tables[0].Rows[0]["boiler_used_for"].ToString();
                                boilervo.challanNo = dsdept.Tables[0].Rows[0]["challanNo"].ToString();
                                boilervo.component_person_details = dsdept.Tables[0].Rows[0]["component_person_details"].ToString();
                                boilervo.courier_date = dsdept.Tables[0].Rows[0]["courier_date"].ToString();
                                boilervo.courier_number = dsdept.Tables[0].Rows[0]["courier_number"].ToString();
                                boilervo.created_by = Convert.ToInt16(dsdept.Tables[0].Rows[0]["created_by"].ToString());
                                boilervo.ddocode = dsdept.Tables[0].Rows[0]["ddocode"].ToString();
                                boilervo.district = dsdept.Tables[0].Rows[0]["district"].ToString();
                                boilervo.door_no = dsdept.Tables[0].Rows[0]["door_no"].ToString();
                                boilervo.e_district = dsdept.Tables[0].Rows[0]["e_district"].ToString();
                                boilervo.e_door_no = dsdept.Tables[0].Rows[0]["e_door_no"].ToString();
                                boilervo.e_email = dsdept.Tables[0].Rows[0]["e_email"].ToString();
                                boilervo.e_licence_copy_filepath = dsdept.Tables[0].Rows[0]["e_licence_copy_filepath"].ToString();
                                boilervo.e_locality = dsdept.Tables[0].Rows[0]["e_locality"].ToString();
                                boilervo.e_mandal = dsdept.Tables[0].Rows[0]["e_mandal"].ToString();
                                boilervo.e_mobile_no = dsdept.Tables[0].Rows[0]["e_mobile_no"].ToString();
                                boilervo.e_pincode = dsdept.Tables[0].Rows[0]["e_pincode"].ToString();
                                boilervo.e_state = dsdept.Tables[0].Rows[0]["e_state"].ToString();
                                boilervo.e_village = dsdept.Tables[0].Rows[0]["e_village"].ToString();
                                boilervo.enterpreneur_id = Convert.ToInt16(dsdept.Tables[0].Rows[0]["enterpreneur_id"].ToString());
                                boilervo.erector_class = dsdept.Tables[0].Rows[0]["erector_class"].ToString();
                                boilervo.erector_name = dsdept.Tables[0].Rows[0]["erector_name"].ToString();
                                boilervo.hoa = dsdept.Tables[0].Rows[0]["hoa"].ToString();
                                //boilervo.inspection_officer = Convert.ToInt16(dsdept.Tables[0].Rows[0]["inspection_officer"].ToString());
                                boilervo.inspector_authority_flag = Convert.ToInt16(dsdept.Tables[0].Rows[0]["inspector_authority_flag"].ToString());
                                //boilervo.inspector_designation = dsdept.Tables[0].Rows[0]["inspector_designation"].ToString();
                                boilervo.locality = dsdept.Tables[0].Rows[0]["locality"].ToString();
                                boilervo.mandal = dsdept.Tables[0].Rows[0]["mandal"].ToString();
                                boilervo.max_evaporation = dsdept.Tables[0].Rows[0]["max_evaporation"].ToString();
                                boilervo.max_pressure = dsdept.Tables[0].Rows[0]["max_pressure"].ToString();
                                boilervo.owner_contact_no = dsdept.Tables[0].Rows[0]["owner_contact_no"].ToString();
                                boilervo.owner_email = dsdept.Tables[0].Rows[0]["owner_email"].ToString();
                                boilervo.owner_name = dsdept.Tables[0].Rows[0]["owner_name"].ToString();
                                boilervo.payment_status = "NA";
                                boilervo.pincode = dsdept.Tables[0].Rows[0]["pincode"].ToString();
                                boilervo.place = dsdept.Tables[0].Rows[0]["place"].ToString();
                                boilervo.present_status_id = Convert.ToInt16(dsdept.Tables[0].Rows[0]["present_status_id"].ToString());
                                boilervo.quessionaire_id = Convert.ToInt16(dsdept.Tables[0].Rows[0]["quessionaire_id"].ToString());
                                boilervo.remittersname = dsdept.Tables[0].Rows[0]["remittersname"].ToString();
                                boilervo.required_documents = dsdept.Tables[0].Rows[0]["required_documents"].ToString();
                                boilervo.system_ip = dsdept.Tables[0].Rows[0]["system_ip"].ToString();
                                boilervo.trydate = dsdept.Tables[0].Rows[0]["trydate"].ToString();
                                boilervo.type_of_boiler = dsdept.Tables[0].Rows[0]["type_of_boiler"].ToString();
                                boilervo.upload_form5 = dsdept.Tables[0].Rows[0]["upload_form5"].ToString();
                                boilervo.user_serial_no = Convert.ToInt16(dsdept.Tables[0].Rows[0]["user_serial_no"].ToString());
                                boilervo.village = dsdept.Tables[0].Rows[0]["village"].ToString();
                                boilervo.year = dsdept.Tables[0].Rows[0]["year"].ToString();

                                BoilerService.anexuredocuments[] anexuredocuments = null;
                                BoilerService.cbbdocuments[] cbbdocument = null;
                                BoilerService.designdocuments[] designdocument = null;
                                BoilerService.formdocuments[] form = null;
                                BoilerService.otherdocuments[] Otherdoc = null;

                                DataSet dsBoiler = new DataSet();
                                dsBoiler = gen.getattachmentdetailsonuidCFO(UIDNO, deptid, "");
                                string attcvalueshmwssb = dsBoiler.GetXml();
                                if (dsBoiler != null && dsBoiler.Tables.Count > 0 && dsBoiler.Tables[0].Rows.Count > 0)
                                {
                                    ///Registration Deed////

                                    if (dsBoiler.Tables[0].Rows.Count > 0)
                                    {
                                        DataTable dtotherdocuments = new DataTable();
                                        dtotherdocuments = dsBoiler.Tables[0];
                                        Otherdoc = new BoilerService.otherdocuments[dtotherdocuments.Rows.Count];

                                        for (int n = 0; n < dtotherdocuments.Rows.Count; n++)
                                        {
                                            BoilerService.otherdocuments otherdocvo = new BoilerService.otherdocuments();
                                            otherdocvo.documentName = dtotherdocuments.Rows[n]["FileName"].ToString();
                                            otherdocvo.documentPath = dtotherdocuments.Rows[n]["Filepath"].ToString();
                                            Otherdoc[n] = otherdocvo;
                                        }
                                        boilervo.otherdocuments = Otherdoc;

                                    }
                                    if (dsBoiler.Tables[1].Rows.Count > 0)
                                    {
                                        DataTable dtcbbdocuments = new DataTable();
                                        dtcbbdocuments = dsBoiler.Tables[1];
                                        cbbdocument = new BoilerService.cbbdocuments[dtcbbdocuments.Rows.Count];

                                        for (int n = 0; n < dtcbbdocuments.Rows.Count; n++)
                                        {
                                            BoilerService.cbbdocuments cbbvo = new BoilerService.cbbdocuments();
                                            cbbvo.documentName = dtcbbdocuments.Rows[n]["FileName"].ToString();
                                            cbbvo.documentPath = dtcbbdocuments.Rows[n]["Filepath"].ToString();
                                            cbbdocument[n] = cbbvo;
                                        }
                                        boilervo.cbbdocuments = cbbdocument;
                                    }
                                    if (dsBoiler.Tables[2].Rows.Count > 0)
                                    {
                                        DataTable dtdesigndocuments = new DataTable();
                                        dtdesigndocuments = dsBoiler.Tables[2];
                                        designdocument = new BoilerService.designdocuments[dtdesigndocuments.Rows.Count];

                                        for (int n = 0; n < dtdesigndocuments.Rows.Count; n++)
                                        {
                                            BoilerService.designdocuments designvo = new BoilerService.designdocuments();
                                            designvo.documentName = dtdesigndocuments.Rows[n]["FileName"].ToString();
                                            designvo.documentPath = dtdesigndocuments.Rows[n]["Filepath"].ToString();
                                            designdocument[n] = designvo;
                                        }
                                        boilervo.designdocuments = designdocument;
                                    }
                                    if (dsBoiler.Tables[3].Rows.Count > 0)
                                    {
                                        DataTable dtformdocuments = new DataTable();
                                        dtformdocuments = dsBoiler.Tables[3];
                                        form = new BoilerService.formdocuments[dtformdocuments.Rows.Count];

                                        for (int n = 0; n < dtformdocuments.Rows.Count; n++)
                                        {
                                            BoilerService.formdocuments formvo = new BoilerService.formdocuments();
                                            formvo.documentName = dtformdocuments.Rows[n]["FileName"].ToString();
                                            formvo.documentPath = dtformdocuments.Rows[n]["Filepath"].ToString();
                                            form[n] = formvo;
                                        }
                                        boilervo.formdocuments = form;
                                    }

                                    if (dsBoiler.Tables[4].Rows.Count > 0)
                                    {
                                        DataTable dtanexuredocuments = new DataTable();
                                        dtanexuredocuments = dsBoiler.Tables[4];
                                        anexuredocuments = new BoilerService.anexuredocuments[dtanexuredocuments.Rows.Count];

                                        for (int n = 0; n < dtanexuredocuments.Rows.Count; n++)
                                        {
                                            BoilerService.anexuredocuments annexurevo = new BoilerService.anexuredocuments();
                                            annexurevo.documentName = dtanexuredocuments.Rows[n]["FileName"].ToString();
                                            annexurevo.documentPath = dtanexuredocuments.Rows[n]["Filepath"].ToString();
                                            anexuredocuments[n] = annexurevo;
                                        }
                                        boilervo.anexuredocuments = anexuredocuments;
                                    }
                                }

                                string boilerout = Boiler.registrationofBoilers(boilervo);//SUCCESS
                                if (boilerout == "SUCCESS")
                                {

                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", boilerout, "Y");
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "A", boilerout, "N");
                                    //int k = gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["intDeptid"].ToString(), dsdept.Tables[0].Rows[0]["quessionaire_id"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                                    int k = gen.InsertDeptDateTracingCFO(dsdept.Tables[0].Rows[0]["intDeptid"].ToString(), dsdept.Tables[0].Rows[0]["quessionaire_id"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                                }
                                else
                                {
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", boilerout, "N");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }

                    if (deptid == "18")// FIRE
                    {
                        try
                        {
                            string valuefire = "";
                            string outputfire = "";
                            string fireattachments = "";
                            string outapplicant = "";
                            string outapplicant1 = "";
                            string outescapre = "";
                            DataSet dsdept = new DataSet();
                            DataSet dsfire = new DataSet();
                            DataSet dsfireescape = new DataSet();
                            DataSet dsdeptattachments = new DataSet();
                            dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);
                            valuefire = dsdept.GetXml();
                            string output = firecfo.InsertApplicantFireDetails_CFO(valuefire);
                            string[] split = output.Split('-');
                            string applid = split[1];
                            dsfire = gen.getfiremeanofescapedetailsonuidCFO(UIDNO, applid);
                            if (dsfire != null && dsfire.Tables.Count > 0 && dsfire.Tables[0].Rows.Count > 0)
                            {
                                DataTable dtfire = new DataTable();
                                DataTable dtfirenew = new DataTable();
                                dtfire = dsfire.Tables[1];
                                dtfirenew = dsfire.Tables[2];
                                dsfire.Tables.Remove(dtfire);
                                dsfire.Tables.Remove(dtfirenew);
                                string fireescape = "";
                                fireescape = dsfire.GetXml();
                                outescapre = firecfo.StoreMeansOfEscape_CFO(fireescape);
                            }
                            DataSet dsfire1 = new DataSet();
                            dsfire1 = gen.getfiremeanofescapedetailsonuidCFO(UIDNO, applid);
                            if (dsfire1 != null && dsfire1.Tables.Count > 0 && dsfire1.Tables[0].Rows.Count > 0)
                            {
                                DataTable dtfire1 = new DataTable();
                                DataTable dtfire1new = new DataTable();
                                dtfire1 = dsfire1.Tables[0];
                                dtfire1new = dsfire1.Tables[2];
                                dsfire1.Tables.Remove(dtfire1);
                                dsfire1.Tables.Remove(dtfire1new);

                                string fireapplicant = "";
                                fireapplicant = dsfire1.GetXml();
                                outapplicant = firecfo.StoreFloorwiseApplicantDtls_CFO(fireapplicant);
                            }
                            DataSet dsfire2 = new DataSet();
                            dsfire2 = gen.getfiremeanofescapedetailsonuidCFO(UIDNO, applid);
                            if (dsfire2 != null && dsfire2.Tables.Count > 0 && dsfire2.Tables[0].Rows.Count > 0)
                            {
                                DataTable dtfire2 = new DataTable();
                                DataTable dtfire2new = new DataTable();
                                dtfire2 = dsfire2.Tables[1];
                                dtfire2new = dsfire2.Tables[0];
                                dsfire2.Tables.Remove(dtfire2);
                                dsfire2.Tables.Remove(dtfire2new);

                                string firefight = "";
                                firefight = dsfire2.GetXml();
                                outapplicant1 = firecfo.StoreFireFightingInstallations_CFO(firefight);
                            }

                            DataSet dsdeptattachmentsfire = new DataSet();
                            dsdeptattachmentsfire = gen.getattachmentdetailsonuidCFO(UIDNO, deptid, applid);
                            fireattachments = dsdeptattachmentsfire.GetXml();
                            outputfire = firecfo.StoreUploadDocuments_CFO(fireattachments);
                            //StringReader str1 = new StringReader(outputfire);
                            //DataSet dsout1 = new DataSet();
                            //dsout1.ReadXml(str1);
                            if (split[0] == "Success" && outescapre == "Success" && outapplicant == "Success" && outapplicant1 == "Success" && outputfire == "Success")
                            {
                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "A", outapplicant, "Y");
                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", outapplicant, "Y");
                                int k = gen.InsertDeptDateTracingCFO(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["QuestionnaireId"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                            }
                            else
                            {
                                string outputerror = split[0].ToString() + ',' + outescapre + ',' + outapplicant + ',' + outapplicant1 + ',' + outputfire;
                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", outputerror, "N");
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    if (deptid == "52")// if (deptid == "48")  // shops and establishment
                    {
                        try
                        {
                            DataSet dsdept = new DataSet();
                            DataSet dsdeptattachments = new DataSet();
                            dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);

                            LabourCFOService.act labouract = new LabourCFOService.act();
                            LabourCFOService.actsResponse labourout = new LabourCFOService.actsResponse();

                            LabourCFOService.shopsEstRegistrations shopactobjnew = new LabourCFOService.shopsEstRegistrations();


                            //LabourCFOService.buildingotherconstructions labour = new LabourCFOService.buildingotherconstructions();
                            //LabourCFOService.actsResponse labourout = new LabourCFOService.actsResponse();
                            //LabourCFOService.contractLabourPrincipalEmployer contractvo = new LabourCFOService.contractLabourPrincipalEmployer();
                            //LabourCFOService.ismwPrincipalEmployer migrateemployer = new LabourCFOService.ismwPrincipalEmployer();

                            string actids = "";
                            string actid = "";
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                            {
                                actids = dsdept.Tables[0].Rows[0]["LabourAct_Id"].ToString();
                                string[] split = actids.Split(',');
                                if (actids.Contains("1"))//The Buildings & Other Construction Workers Act
                                {
                                    // labouract.buildingRegistrationActSelected = true;
                                    labouract.shopRegistrationActSelected = true;
                                    shopactobjnew.actID = "SEF";//dsdept.Tables[0].Rows[0]["actID"].ToString();
                                    shopactobjnew.bank_code = dsdept.Tables[0].Rows[0]["bank_code"].ToString();
                                    shopactobjnew.bank_ref_number = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                    shopactobjnew.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                    shopactobjnew.cin = dsdept.Tables[0].Rows[0]["cin"].ToString();
                                    shopactobjnew.compound_fee = 0;// dsdept.Tables[0].Columns[""].ToString();
                                    shopactobjnew.date_commencement = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                                    shopactobjnew.date_completion = dsdept.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();
                                    shopactobjnew.entrepreneur_id = dsdept.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                                    //  shopactobjnew.establishment_full_name = dsdept.Tables[0].Rows[0]["Form1_Estb_Name"].ToString();
                                    shopactobjnew.establishment_name = dsdept.Tables[0].Rows[0]["NAME"].ToString();
                                    //   shopactobjnew.establishment_permanent_district = dsdept.Tables[0].Rows[0]["Form1_2_Per_District"].ToString();
                                    //   shopactobjnew.establishment_permanent_door = dsdept.Tables[0].Rows[0]["Form1_2_Per_DoorNo"].ToString();
                                    //  shopactobjnew.establishment_permanent_mandal = dsdept.Tables[0].Rows[0]["Form1_2_Per_Mandal"].ToString();
                                    //   shopactobjnew.establishment_permanent_pincode = dsdept.Tables[0].Rows[0]["Form1_2_Per_PinCode"].ToString();
                                    //   shopactobjnew.establishment_permanent_village = dsdept.Tables[0].Rows[0]["Form1_2_Per_Village"].ToString();
                                    shopactobjnew.establishment_postal_district = dsdept.Tables[0].Rows[0]["Form1_Estd_District"].ToString();
                                    shopactobjnew.establishment_postal_door = dsdept.Tables[0].Rows[0]["Form1_Estd_DoorNo"].ToString();
                                    shopactobjnew.establishment_postal_locality = dsdept.Tables[0].Rows[0]["Form1_Estd_Locality"].ToString();
                                    shopactobjnew.establishment_postal_mandal = dsdept.Tables[0].Rows[0]["Form1_Estd_Mandal"].ToString();
                                    shopactobjnew.establishment_postal_pincode = dsdept.Tables[0].Rows[0]["Form1_Estd_PinCode"].ToString();
                                    shopactobjnew.establishment_postal_village = dsdept.Tables[0].Rows[0]["Form1_Estd_Village"].ToString();
                                    shopactobjnew.manager_agent_designation = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Designation"].ToString();
                                    shopactobjnew.manager_agent_district = dsdept.Tables[0].Rows[0]["Form1_1_Manager_District"].ToString();
                                    shopactobjnew.manager_agent_door = dsdept.Tables[0].Rows[0]["Form1_1_Manager_DoorNo"].ToString();
                                    shopactobjnew.manager_agent_email = dsdept.Tables[0].Rows[0]["Form1_Manager_EMail"].ToString();
                                    shopactobjnew.manager_agent_fathername = dsdept.Tables[0].Rows[0]["Form1_1_Manager_FatherName"].ToString();
                                    shopactobjnew.manager_agent_mandal = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Mandal"].ToString();
                                    shopactobjnew.manager_agent_mobile = dsdept.Tables[0].Rows[0]["Form1_Manager_MobileNo"].ToString();
                                    shopactobjnew.manager_agent_name = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Name"].ToString();
                                    shopactobjnew.manager_agent_street = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Locality"].ToString();
                                    shopactobjnew.manager_agent_village = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Village"].ToString();
                                    shopactobjnew.max_employees_aday = dsdept.Tables[0].Rows[0]["Form1_2_MaxWorkers"].ToString();
                                    shopactobjnew.nature_work = dsdept.Tables[0].Rows[0]["Form1_Nature_of_Business"].ToString();
                                    // shopactobjnew.other_attachments_1 = "";//dsdept.Tables[0].Columns["other_attachments_1"].ToString();
                                    // shopactobjnew.other_attachments_2 = "";// dsdept.Tables[0].Columns["other_attachments_2"].ToString();
                                    shopactobjnew.payment_mode = dsdept.Tables[0].Rows[0]["payment_mode"].ToString();
                                    shopactobjnew.paymentFlag = dsdept.Tables[0].Rows[0]["paymentFlag"].ToString();
                                    shopactobjnew.penality_percentage = Convert.ToInt32(dsdept.Tables[0].Rows[0]["penality_percentage"].ToString());
                                    shopactobjnew.penality_years = Convert.ToInt32(dsdept.Tables[0].Rows[0]["penality_years"].ToString());
                                    shopactobjnew.projectSubmitDate = dsdept.Tables[0].Rows[0]["projectSubmitDate"].ToString();
                                    shopactobjnew.questionnaire_id = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                                    shopactobjnew.registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                                    shopactobjnew.registration_years = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_years"].ToString());
                                    shopactobjnew.stageID = dsdept.Tables[0].Rows[0]["stageID"].ToString();
                                    shopactobjnew.total_amount_payable = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString());
                                    shopactobjnew.total_penality_amount = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_penality_amount"].ToString());
                                    shopactobjnew.total_registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_registration_fee"].ToString());
                                    shopactobjnew.totalAmount = dsdept.Tables[0].Rows[0]["totalAmount"].ToString();
                                    shopactobjnew.transaction_for = dsdept.Tables[0].Rows[0]["transaction_for"].ToString();
                                    shopactobjnew.transaction_id = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                    shopactobjnew.transaction_status = "Y";
                                    shopactobjnew.transactionDate = dsdept.Tables[0].Rows[0]["transactionDate"].ToString();
                                    //labour.tsipassApplicationID = dsdept.Tables[0].Rows[0]["tsipassApplicationID"].ToString();
                                    shopactobjnew.type_of_application = dsdept.Tables[0].Rows[0]["type_of_application"].ToString();
                                    shopactobjnew.uID = dsdept.Tables[0].Rows[0]["UID_NO"].ToString();
                                    shopactobjnew.unpaid_balance_welfare = Convert.ToInt32(dsdept.Tables[0].Rows[0]["unpaid_balance_welfare"].ToString());
                                    shopactobjnew.valid_from_date = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                                    shopactobjnew.valid_to_date = dsdept.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();
                                    shopactobjnew.establishment_category = "1";
                                    shopactobjnew.establishment_classification = "1";
                                    shopactobjnew.male_adults = dsdept.Tables[0].Rows[0]["Form1_1_Employees_Above18_Male"].ToString();
                                    shopactobjnew.male_young = dsdept.Tables[0].Rows[0]["Form1_1_Employees_14_18_Male"].ToString();
                                    shopactobjnew.female_adults = dsdept.Tables[0].Rows[0]["Form1_1_Employees_Above18_Female"].ToString();
                                    shopactobjnew.female_young = dsdept.Tables[0].Rows[0]["Form1_1_Employees_14_18_Female"].ToString();
                                    shopactobjnew.employees_proof = "";
                                    shopactobjnew.address_proof = "";
                                    shopactobjnew.authorise_letter_proof = "";
                                    shopactobjnew.certificate_incorporation_proof = "";
                                    shopactobjnew.employer_age = dsdept.Tables[0].Rows[0]["Form1_Employer_Age"].ToString();
                                    shopactobjnew.employer_designation = dsdept.Tables[0].Rows[0]["Form1_Employer_Designation"].ToString();
                                    shopactobjnew.employer_email = dsdept.Tables[0].Rows[0]["Form1_Employer_EmailID"].ToString();
                                    shopactobjnew.employer_fathername = dsdept.Tables[0].Rows[0]["Form1_Empolyer_FatherName"].ToString();
                                    shopactobjnew.employer_mobile = dsdept.Tables[0].Rows[0]["Form1_Employer_MobileNo"].ToString();
                                    shopactobjnew.employer_name = dsdept.Tables[0].Rows[0]["Form1_Employer_Name"].ToString();
                                    shopactobjnew.employer_permanent_locality = dsdept.Tables[0].Rows[0]["Form1_Employer_Locality"].ToString();
                                    shopactobjnew.employer_permanent_pincode = "";// dsdept.Tables[0].Rows[0]["Form1_Employer_District"].ToString();

                                    shopactobjnew.employer_permanent_district = dsdept.Tables[0].Rows[0]["Form1_Employer_District"].ToString();
                                    shopactobjnew.employer_permanent_door = dsdept.Tables[0].Rows[0]["Form1_Employer_DoorNo"].ToString();
                                    shopactobjnew.employer_permanent_village = dsdept.Tables[0].Rows[0]["Form1_Employer_Village"].ToString();
                                    shopactobjnew.employer_permanent_mandal = dsdept.Tables[0].Rows[0]["Form1_Employer_Mandal"].ToString();
                                    string managerexists = "";
                                    if (dsdept.Tables[0].Rows[0]["Form1_1_Manager_Agent_Flag"] != null && dsdept.Tables[0].Rows[0]["Form1_1_Manager_Agent_Flag"].ToString() != "")
                                    {
                                        if (dsdept.Tables[0].Rows[0]["Form1_1_Manager_Agent_Flag"].ToString() == "N")
                                        {
                                            managerexists = "NO";
                                        }
                                        else
                                        {
                                            managerexists = "YES";
                                        }
                                    }
                                    shopactobjnew.manager_exists = managerexists;
                                    shopactobjnew.total_adults = dsdept.Tables[0].Rows[0]["total_adults"].ToString();
                                    shopactobjnew.total_young = dsdept.Tables[0].Rows[0]["total_young"].ToString();
                                    //  labouract.buildingRegistrationActData = labour;

                                    LabourCFOService.shopActsWorkPlaceMultiData[] shopactobj = null;

                                    if (dsdept.Tables[1].Rows.Count > 0)
                                    {
                                        DataTable dtraw = new DataTable();
                                        dtraw = dsdept.Tables[1];
                                        shopactobj = new LabourCFOService.shopActsWorkPlaceMultiData[dtraw.Rows.Count];

                                        for (int k = 0; k < dtraw.Rows.Count; k++)
                                        {
                                            LabourCFOService.shopActsWorkPlaceMultiData workplacevo = new LabourCFOService.shopActsWorkPlaceMultiData();
                                            workplacevo.workPlacedoorNo = dtraw.Rows[k]["Door_No"].ToString();
                                            workplacevo.workPlacelocality = dtraw.Rows[k]["Locality"].ToString();
                                            workplacevo.workPlaceType = dtraw.Rows[k]["Work_Place"].ToString();
                                            shopactobj[k] = workplacevo;
                                        }
                                        shopactobjnew.workPlaceDetails = shopactobj;
                                    }

                                    LabourCFOService.shopActsEmployeesMultiData[] shopactobj1 = null;
                                    if (dsdept.Tables[2].Rows.Count > 0)
                                    {
                                        DataTable dtraw2 = new DataTable();
                                        dtraw2 = dsdept.Tables[2];
                                        shopactobj1 = new LabourCFOService.shopActsEmployeesMultiData[dtraw2.Rows.Count];

                                        for (int k = 0; k < dtraw2.Rows.Count; k++)
                                        {
                                            LabourCFOService.shopActsEmployeesMultiData workplacevo1 = new LabourCFOService.shopActsEmployeesMultiData();
                                            workplacevo1.employeeGender = dtraw2.Rows[k]["Gender"].ToString();
                                            workplacevo1.employeeName = dtraw2.Rows[k]["Name"].ToString();
                                            workplacevo1.employeeOccupation = dtraw2.Rows[k]["Occupation"].ToString();
                                            shopactobj1[k] = workplacevo1;
                                        }
                                        shopactobjnew.employeesDetails = shopactobj1;
                                    }


                                    LabourCFOService.shopActsFamilyMultiData[] shopactobj3 = null;

                                    if (dsdept.Tables[3].Rows.Count > 0)
                                    {
                                        DataTable dtraw3 = new DataTable();
                                        dtraw3 = dsdept.Tables[3];
                                        shopactobj3 = new LabourCFOService.shopActsFamilyMultiData[dtraw3.Rows.Count];

                                        for (int k = 0; k < dtraw3.Rows.Count; k++)
                                        {
                                            LabourCFOService.shopActsFamilyMultiData workplacevo3 = new LabourCFOService.shopActsFamilyMultiData();
                                            workplacevo3.familyMemberAdultYoung = dtraw3.Rows[k]["Adult_Flag"].ToString();
                                            workplacevo3.familyMemberGender = dtraw3.Rows[k]["Gender"].ToString();
                                            workplacevo3.familyMemberRelationship = dtraw3.Rows[k]["RelationShip"].ToString();
                                            workplacevo3.familyMemeberName = dtraw3.Rows[k]["Name"].ToString();
                                            shopactobj3[k] = workplacevo3;
                                        }
                                        shopactobjnew.familyDetails = shopactobj3;
                                    }
                                    labouract.shopRegistrationActData = shopactobjnew;
                                    labourout = labourserviceCfo.actSelected(labouract);

                                    // labourout = labourserviceCfo.actSelected(labouract);
                                    if (labourout.status == "SUCCESS")
                                    {
                                        string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                        gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", labouroutmsg, "Y");
                                        int k = gen.InsertDeptDateTracingCFO(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                                    }
                                    else
                                    {
                                        string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                        gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "N", labourouterrormsg, "N");
                                    }
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    if (deptid == "50") // contract labour
                    {
                        try
                        {
                            DataSet dsdept = new DataSet();
                            DataSet dsdeptattachments = new DataSet();
                            dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);

                            LabourCFOService.act labouract = new LabourCFOService.act();
                            LabourCFOService.buildingotherconstructions labour = new LabourCFOService.buildingotherconstructions();
                            LabourCFOService.actsResponse labourout = new LabourCFOService.actsResponse();
                            LabourCFOService.contractLabourPrincipalEmployer contractvo = new LabourCFOService.contractLabourPrincipalEmployer();
                            LabourCFOService.ismwPrincipalEmployer migrateemployer = new LabourCFOService.ismwPrincipalEmployer();



                            string actids = "";
                            string actid = "";
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                            {
                                actids = dsdept.Tables[0].Rows[0]["LabourAct_Id"].ToString();
                                string[] split = actids.Split(',');
                                if (actids.Contains("3"))//The Contract Labour Act (Principal Employer)
                                {

                                    labouract.contractLabourPrincipalEmplyerActSelected = true;
                                    contractvo.actID = "CPF";
                                    contractvo.bank_code = dsdept.Tables[0].Rows[0]["bank_code"].ToString();
                                    contractvo.bank_ref_number = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                    contractvo.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                    contractvo.cin = dsdept.Tables[0].Rows[0]["cin"].ToString();
                                    contractvo.compound_fee = 0;
                                    contractvo.employees_attachement = "";//dsdept.Tables[0].Rows[0][""].ToString();
                                    contractvo.entrepreneur_id = dsdept.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                                    contractvo.establishment_category = dsdept.Tables[0].Rows[0]["Form1_1_Estb_Category"].ToString();
                                    contractvo.establishment_category_others = dsdept.Tables[0].Rows[0]["Form1_1_Estb_Classification"].ToString();
                                    contractvo.establishment_name = dsdept.Tables[0].Rows[0]["Form1_Estb_Name"].ToString();
                                    contractvo.establishment_postal_district = dsdept.Tables[0].Rows[0]["Form1_Estd_District"].ToString();
                                    contractvo.establishment_postal_door = dsdept.Tables[0].Rows[0]["Form1_Estd_DoorNo"].ToString();
                                    contractvo.establishment_postal_locality = dsdept.Tables[0].Rows[0]["Form1_Estd_Locality"].ToString();
                                    contractvo.establishment_postal_mandal = dsdept.Tables[0].Rows[0]["Form1_Estd_Mandal"].ToString();
                                    contractvo.establishment_postal_village = dsdept.Tables[0].Rows[0]["Form1_Estd_Village"].ToString();
                                    contractvo.manager_agent_district = dsdept.Tables[0].Rows[0]["Form1_1_Manager_District"].ToString();
                                    contractvo.manager_agent_door = dsdept.Tables[0].Rows[0]["Form1_1_Manager_DoorNo"].ToString();
                                    contractvo.manager_agent_mandal = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Mandal"].ToString();
                                    contractvo.manager_agent_name = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Name"].ToString();
                                    contractvo.manager_agent_village = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Village"].ToString();
                                    contractvo.max_employees_aday = dsdept.Tables[0].Rows[0]["Form1_2_MaxWorkers"].ToString();
                                    contractvo.nature_work = dsdept.Tables[0].Rows[0]["Form1_Nature_of_Business"].ToString();
                                    contractvo.other_attachments_1 = "";
                                    contractvo.other_attachments_2 = "";
                                    contractvo.payment_mode = dsdept.Tables[0].Rows[0]["payment_mode"].ToString();
                                    contractvo.paymentFlag = dsdept.Tables[0].Rows[0]["paymentFlag"].ToString();
                                    contractvo.penality_percentage = 0;//Convert.ToInt32(dsdept.Tables[0].Rows[0]["penality_percentage"].ToString());
                                    contractvo.penality_years = 0;//Convert.ToInt32(dsdept.Tables[0].Rows[0]["penality_years"].ToString());
                                    //contractvo.previous_registered_act = dsdept.Tables[0].Rows[0][""].ToString();
                                    //contractvo.previous_registration_certificate = dsdept.Tables[0].Rows[0][""].ToString();
                                    //contractvo.previous_registration_no = dsdept.Tables[0].Rows[0][""].ToString();
                                    contractvo.principal_employer_district = dsdept.Tables[0].Rows[0]["Form1_Employer_District"].ToString();
                                    contractvo.principal_employer_door = dsdept.Tables[0].Rows[0]["Form1_Employer_DoorNo"].ToString();
                                    contractvo.principal_employer_email = dsdept.Tables[0].Rows[0]["Form1_Employer_EmailID"].ToString();
                                    contractvo.principal_employer_fathername = dsdept.Tables[0].Rows[0]["Form1_Empolyer_FatherName"].ToString();
                                    contractvo.principal_employer_mandal = dsdept.Tables[0].Rows[0]["Form1_Employer_Mandal"].ToString();
                                    contractvo.principal_employer_mobile = dsdept.Tables[0].Rows[0]["Form1_Employer_MobileNo"].ToString();
                                    contractvo.principal_employer_name = dsdept.Tables[0].Rows[0]["Form1_Employer_Name"].ToString();
                                    contractvo.principal_employer_village = dsdept.Tables[0].Rows[0]["Form1_Employer_Village"].ToString();
                                    contractvo.projectSubmitDate = dsdept.Tables[0].Rows[0]["projectSubmitDate"].ToString();
                                    contractvo.questionnaire_id = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                                    contractvo.registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                                    contractvo.registration_years = 0;
                                    contractvo.stageID = dsdept.Tables[0].Rows[0]["intStageid"].ToString();
                                    contractvo.total_amount_payable = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString());
                                    contractvo.total_penality_amount = 0;
                                    contractvo.total_registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                                    contractvo.totalAmount = dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString();
                                    contractvo.transaction_for = dsdept.Tables[0].Rows[0]["transaction_for"].ToString();
                                    contractvo.transaction_id = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                    contractvo.transaction_status = "Y";//dsdept.Tables[0].Rows[0][""].ToString();
                                    contractvo.transactionDate = dsdept.Tables[0].Rows[0]["transactionDate"].ToString();
                                    contractvo.transactionNumber = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                    //contractvo.tsipassApplicationID = dsdept.Tables[0].Rows[0][""].ToString();
                                    contractvo.type_of_application = dsdept.Tables[0].Rows[0]["type_of_application"].ToString();
                                    contractvo.uID = dsdept.Tables[0].Rows[0]["UID_NO"].ToString();
                                    contractvo.unpaid_balance_welfare = Convert.ToInt32(dsdept.Tables[0].Rows[0]["unpaid_balance_welfare"].ToString());
                                    contractvo.valid_from_date = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                                    contractvo.valid_to_date = dsdept.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();

                                    LabourCFOService.contractLabourPrincipalEmployerMultiData[] contractmulti = null;

                                    //contractvo.contractorParticulars[] lstitem = null;
                                    ContractorDetails co = new ContractorDetails();
                                    //FactoryService.rawMaterial[] lst = null;
                                    if (dsdept.Tables[1].Rows.Count > 0)
                                    {
                                        DataTable dtraw = new DataTable();
                                        dtraw = dsdept.Tables[1];
                                        contractmulti = new LabourCFOService.contractLabourPrincipalEmployerMultiData[dtraw.Rows.Count];

                                        for (int k = 0; k < dtraw.Rows.Count; k++)
                                        {
                                            //FactoryService.rawMaterial BBB = new FactoryService.rawMaterial();
                                            LabourCFOService.contractLabourPrincipalEmployerMultiData coc = new LabourCFOService.contractLabourPrincipalEmployerMultiData();
                                            coc.contractorAddress = dtraw.Rows[k]["Contractor_Address"].ToString();
                                            coc.commencementDate = dtraw.Rows[k]["Contractor_Est_Commence_Dt"].ToString();
                                            coc.terminationDate = dtraw.Rows[k]["Contractor_Est_Compltd_Dt"].ToString();
                                            //coc.m = dtraw.Rows[k]["Contractor_MobileNo"].ToString();
                                            coc.contractorName = dtraw.Rows[k]["Contractor_Name"].ToString();
                                            coc.maxcontractLabour = dtraw.Rows[k]["Contractor_MaxWorkers"].ToString();
                                            coc.natureOfWork = dtraw.Rows[k]["Contractor_Work_Nature"].ToString();
                                            coc.manufacturingDeptDetails = dtraw.Rows[k]["Contractor_ManufacturingDepts"].ToString();
                                            contractmulti[k] = coc;
                                            //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                                            //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                                        }
                                        contractvo.contractorParticulars = contractmulti;
                                        //rawvo.materialDescr
                                    }

                                    labouract.contractLabourPrincipalEmplyerActData = contractvo;
                                    labourout = labourserviceCfo.actSelected(labouract);

                                    if (labourout.status == "SUCCESS")
                                    {
                                        string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                        gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", labouroutmsg, "Y");
                                        int k = gen.InsertDeptDateTracingCFO(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                                    }
                                    else
                                    {
                                        string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                        gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "N", labourouterrormsg, "N");
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    if (deptid == "51")
                    {
                        try
                        {
                            DataSet dsdept = new DataSet();
                            DataSet dsdeptattachments = new DataSet();
                            dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);

                            LabourCFOService.act labouract = new LabourCFOService.act();
                            LabourCFOService.buildingotherconstructions labour = new LabourCFOService.buildingotherconstructions();
                            LabourCFOService.actsResponse labourout = new LabourCFOService.actsResponse();
                            LabourCFOService.contractLabourPrincipalEmployer contractvo = new LabourCFOService.contractLabourPrincipalEmployer();
                            LabourCFOService.ismwPrincipalEmployer migrateemployer = new LabourCFOService.ismwPrincipalEmployer();

                            string actids = "";
                            string actid = "";
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                            {
                                actids = dsdept.Tables[0].Rows[0]["LabourAct_Id"].ToString();
                                string[] split = actids.Split(',');

                                if (actids.Contains("4"))//Principal Employer Registration Under InterState Migrant Workman Act
                                {
                                    labouract.interstateMigrantPrincipalEmplyerActSelected = true;
                                    migrateemployer.actID = "ISMWPEF";
                                    migrateemployer.bank_code = dsdept.Tables[0].Rows[0]["bank_code"].ToString();
                                    migrateemployer.bank_ref_number = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                    migrateemployer.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                    migrateemployer.cin = dsdept.Tables[0].Rows[0]["cin"].ToString();
                                    migrateemployer.compound_fee = 0;
                                    migrateemployer.director_district = dsdept.Tables[0].Rows[0]["Form1_4_Dir_District"].ToString();
                                    migrateemployer.director_door = dsdept.Tables[0].Rows[0]["Form1_4_Dir_DoorNo"].ToString();
                                    migrateemployer.director_mandal = dsdept.Tables[0].Rows[0]["Form1_4_Dir_Mandal"].ToString();
                                    migrateemployer.director_name = dsdept.Tables[0].Rows[0]["Form1_4_Dir_FullName"].ToString();
                                    migrateemployer.director_village = dsdept.Tables[0].Rows[0]["Form1_4_Dir_Village"].ToString();
                                    migrateemployer.employees_attachement = "";
                                    migrateemployer.entrepreneur_id = dsdept.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                                    migrateemployer.establishment_category = dsdept.Tables[0].Rows[0]["Form1_1_Estb_Category"].ToString();
                                    migrateemployer.establishment_category_others = dsdept.Tables[0].Rows[0]["Form1_1_Estb_Classification"].ToString();
                                    migrateemployer.establishment_name = dsdept.Tables[0].Rows[0]["Form1_Estb_Name"].ToString();
                                    migrateemployer.establishment_postal_district = dsdept.Tables[0].Rows[0]["Form1_Estd_District"].ToString();
                                    migrateemployer.establishment_postal_door = dsdept.Tables[0].Rows[0]["Form1_Estd_DoorNo"].ToString();
                                    migrateemployer.establishment_postal_locality = dsdept.Tables[0].Rows[0]["Form1_Estd_Locality"].ToString();
                                    migrateemployer.establishment_postal_mandal = dsdept.Tables[0].Rows[0]["Form1_Estd_Mandal"].ToString();
                                    migrateemployer.establishment_postal_village = dsdept.Tables[0].Rows[0]["Form1_Estd_Village"].ToString();
                                    migrateemployer.ipass_status_id = dsdept.Tables[0].Rows[0]["intStageid"].ToString();
                                    migrateemployer.manager_agent_district = dsdept.Tables[0].Rows[0]["Form1_1_Manager_District"].ToString();
                                    migrateemployer.manager_agent_door = dsdept.Tables[0].Rows[0]["Form1_1_Manager_DoorNo"].ToString();
                                    migrateemployer.manager_agent_mandal = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Mandal"].ToString();
                                    migrateemployer.manager_agent_name = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Name"].ToString();
                                    migrateemployer.manager_agent_village = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Village"].ToString();
                                    migrateemployer.max_employees_aday = dsdept.Tables[0].Rows[0]["Form1_2_MaxWorkers"].ToString();
                                    migrateemployer.nature_work = dsdept.Tables[0].Rows[0]["Form1_Nature_of_Business"].ToString();
                                    migrateemployer.other_attachments_1 = "";
                                    migrateemployer.other_attachments_2 = "";
                                    migrateemployer.payment_mode = dsdept.Tables[0].Rows[0]["payment_mode"].ToString();
                                    migrateemployer.paymentFlag = dsdept.Tables[0].Rows[0]["paymentFlag"].ToString();
                                    migrateemployer.penality_percentage = 0;
                                    migrateemployer.penality_years = 0;
                                    migrateemployer.previous_registered_act = "";
                                    migrateemployer.previous_registration_certificate = "";
                                    migrateemployer.previous_registration_no = "";
                                    migrateemployer.principal_employer_district = dsdept.Tables[0].Rows[0]["Form1_Employer_District"].ToString();
                                    migrateemployer.principal_employer_door = dsdept.Tables[0].Rows[0]["Form1_Employer_DoorNo"].ToString();
                                    migrateemployer.principal_employer_email = dsdept.Tables[0].Rows[0]["Form1_Employer_EmailID"].ToString();
                                    migrateemployer.principal_employer_fathername = dsdept.Tables[0].Rows[0]["Form1_Empolyer_FatherName"].ToString();
                                    migrateemployer.principal_employer_mandal = dsdept.Tables[0].Rows[0]["Form1_Employer_Mandal"].ToString();
                                    migrateemployer.principal_employer_mobile = dsdept.Tables[0].Rows[0]["Form1_Employer_MobileNo"].ToString();
                                    migrateemployer.principal_employer_name = dsdept.Tables[0].Rows[0]["Form1_Employer_Name"].ToString();
                                    migrateemployer.principal_employer_village = dsdept.Tables[0].Rows[0]["Form1_Employer_Village"].ToString();
                                    migrateemployer.projectSubmitDate = dsdept.Tables[0].Rows[0]["projectSubmitDate"].ToString();
                                    migrateemployer.questionnaire_id = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                                    migrateemployer.registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                                    migrateemployer.registration_years = 0;
                                    migrateemployer.stageID = dsdept.Tables[0].Rows[0]["intStageid"].ToString();
                                    migrateemployer.total_amount_payable = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString());
                                    migrateemployer.total_penality_amount = 0;
                                    migrateemployer.total_registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                                    migrateemployer.totalAmount = dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString();
                                    migrateemployer.transaction_for = dsdept.Tables[0].Rows[0]["transaction_for"].ToString();
                                    migrateemployer.transaction_id = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                    migrateemployer.transaction_status = "Y";
                                    migrateemployer.transactionDate = dsdept.Tables[0].Rows[0]["transactionDate"].ToString();
                                    migrateemployer.transactionNumber = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                    migrateemployer.type_of_application = dsdept.Tables[0].Rows[0]["type_of_application"].ToString();
                                    migrateemployer.uID = dsdept.Tables[0].Rows[0]["UID_NO"].ToString();
                                    migrateemployer.unpaid_balance_welfare = Convert.ToInt32(dsdept.Tables[0].Rows[0]["unpaid_balance_welfare"].ToString());
                                    migrateemployer.valid_from_date = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                                    migrateemployer.valid_to_date = dsdept.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();

                                    LabourCFOService.ismwPrincipalEmployerMultiData[] migrantvo = null;
                                    ContractorDetails co = new ContractorDetails();
                                    //FactoryService.rawMaterial[] lst = null;
                                    if (dsdept.Tables[1].Rows.Count > 0)
                                    {
                                        DataTable dtraw = new DataTable();
                                        dtraw = dsdept.Tables[1];
                                        migrantvo = new LabourCFOService.ismwPrincipalEmployerMultiData[dtraw.Rows.Count];

                                        for (int k = 0; k < dtraw.Rows.Count; k++)
                                        {
                                            //FactoryService.rawMaterial BBB = new FactoryService.rawMaterial();
                                            LabourCFOService.ismwPrincipalEmployerMultiData coc = new LabourCFOService.ismwPrincipalEmployerMultiData();
                                            coc.contractorAddress = dtraw.Rows[k]["Contractor_Address"].ToString();
                                            coc.commencementDate = dtraw.Rows[k]["Contractor_Est_Commence_Dt"].ToString();
                                            coc.terminationDate = dtraw.Rows[k]["Contractor_Est_Compltd_Dt"].ToString();
                                            //coc.m = dtraw.Rows[k]["Contractor_MobileNo"].ToString();
                                            coc.contractorName = dtraw.Rows[k]["Contractor_Name"].ToString();
                                            coc.maxcontractLabour = dtraw.Rows[k]["Contractor_MaxWorkers"].ToString();
                                            coc.natureOfWork = dtraw.Rows[k]["Contractor_Work_Nature"].ToString();
                                            coc.manufacturingDeptDetails = dtraw.Rows[k]["Contractor_ManufacturingDepts"].ToString();
                                            coc.mobileNo = dtraw.Rows[k]["Contractor_MobileNo"].ToString();
                                            migrantvo[k] = coc;
                                            //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                                            //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                                        }
                                        migrateemployer.contractorParticulars = migrantvo;
                                        //rawvo.materialDescr
                                    }
                                    labouract.interstateMigrantPrincipalEmplyerActData = migrateemployer;
                                    labourout = labourserviceCfo.actSelected(labouract);
                                    if (labourout.status == "SUCCESS")
                                    {
                                        string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                        gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", labouroutmsg, "Y");
                                        int k = gen.InsertDeptDateTracingCFO(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                                    }
                                    else
                                    {
                                        string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                        gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "N", labourouterrormsg, "N");
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    if (deptid == "15")//FACTORIES
                    {

                        FactoryServiceCFO.grantLicense factoryvo = new FactoryServiceCFO.grantLicense();

                        string outputfactory = "";
                        string valuefactory = "";
                        DataSet dsdept = new DataSet();
                        dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);
                        valuefactory = dsdept.GetXml();
                        //outputfactory = factory.insertIntoPlanApproval(factoryvo);


                        factoryvo.amountToBePaid = dsdept.Tables[0].Rows[0]["Approval_Fee"].ToString();
                        factoryvo.applicationID = dsdept.Tables[0].Rows[0]["UID_No"].ToString();
                        factoryvo.applicationStageID = dsdept.Tables[0].Rows[0]["intstageid"].ToString();
                        factoryvo.applicationStatus = "Pre-Scuitiny Pending"; //dsdept.Tables[0].Columns[""].ToString();
                        factoryvo.applicationSubmittedDate = dsdept.Tables[0].Rows[0]["UID_NOGenerateDate"].ToString();

                        //factoryvo.bankAmount = dsdept.Tables[0].Rows[0]["Online_Amount"].ToString();
                        //factoryvo.bankDate = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                        //factoryvo.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                        //factoryvo.challanNumber = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                        factoryvo.communicationAddress = dsdept.Tables[0].Rows[0]["communicationAddress"].ToString();
                        factoryvo.entrepreneurID = dsdept.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                        factoryvo.factoryDistrictID = dsdept.Tables[0].Rows[0]["Prop_intDistrictid"].ToString();
                        factoryvo.factoryDoorNumber = dsdept.Tables[0].Rows[0]["Door_No"].ToString();
                        factoryvo.factoryLocality = dsdept.Tables[0].Rows[0]["StreetName"].ToString();
                        factoryvo.factoryMandalID = dsdept.Tables[0].Rows[0]["Prop_intMandalid"].ToString();
                        factoryvo.factoryName = dsdept.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();
                        factoryvo.factoryOccupationDateByOccupier = dsdept.Tables[0].Rows[0]["Date_Occupation"].ToString();// 
                        factoryvo.factoryPinCode = dsdept.Tables[0].Rows[0]["Land_Pincode"].ToString();
                        factoryvo.factoryType = dsdept.Tables[0].Rows[0]["TypeofFactory"].ToString();
                        factoryvo.factoryVillageID = dsdept.Tables[0].Rows[0]["Prop_intVillageid"].ToString();
                        factoryvo.horsePowerToBeInstalledRegular = dsdept.Tables[0].Rows[0]["RegularHp"].ToString(); //dsdept.Tables[0].Rows[0][""].ToString();
                        factoryvo.horsePowerToBeInstalledRegularUnits = "HP";
                        factoryvo.horsePowerToBeInstalledStandby = dsdept.Tables[0].Rows[0]["StandbyHp"].ToString(); //dsdept.Tables[0].Rows[0][""].ToString();
                        factoryvo.horsePowerToBeInstalledStandbyUnits = "HP";
                        factoryvo.managerDistrict = dsdept.Tables[0].Rows[0]["Mangr_District"].ToString();
                        factoryvo.managerDoorNo = dsdept.Tables[0].Rows[0]["Mangr_DoorNo"].ToString();
                        factoryvo.managerFullName = dsdept.Tables[0].Rows[0]["Mangr_Full_Name"].ToString();
                        factoryvo.managerLocality = dsdept.Tables[0].Rows[0]["Mangr_Locality"].ToString();
                        factoryvo.managerMailId = dsdept.Tables[0].Rows[0]["Mangr_EmailId"].ToString();
                        factoryvo.managerMandal = dsdept.Tables[0].Rows[0]["Mangr_Mandal"].ToString();
                        factoryvo.managerMobileNumber = dsdept.Tables[0].Rows[0]["Mangr_MobileNo"].ToString();
                        factoryvo.managerPinCode = dsdept.Tables[0].Rows[0]["Mangr_PinCode"].ToString();
                        factoryvo.managerVillage = dsdept.Tables[0].Rows[0]["Mangr_Village"].ToString();
                        factoryvo.natureOfManufacturingProcessMain = dsdept.Tables[0].Rows[0]["MAIN"].ToString();// dsdept.Tables[0].Rows[0][""].ToString();
                        factoryvo.natureOfManufacturingProcessSecondary = dsdept.Tables[0].Rows[0]["SECONDARYITEM"].ToString();// dsdept.Tables[0].Rows[0][""].ToString();
                        factoryvo.noOfyearsSelectedToPayLicenceFee = dsdept.Tables[0].Rows[0]["LicenseYear"].ToString();
                        factoryvo.occupierDistrict = dsdept.Tables[0].Rows[0]["Occupier_District"].ToString();
                        factoryvo.occupierDoorNo = dsdept.Tables[0].Rows[0]["Occupier_DoorNo"].ToString();
                        factoryvo.occupierFullName = dsdept.Tables[0].Rows[0]["Occupier_Full_Name"].ToString();
                        factoryvo.occupierLocality = dsdept.Tables[0].Rows[0]["Occupier_Locality"].ToString();
                        factoryvo.occupierMailId = dsdept.Tables[0].Rows[0]["Occupier_EmailId"].ToString();
                        factoryvo.occupierMandal = dsdept.Tables[0].Rows[0]["Occupier_Mandal"].ToString();
                        factoryvo.occupierMobileNumber = dsdept.Tables[0].Rows[0]["Occupier_MobileNo"].ToString();
                        factoryvo.occupierOtherStatePostalAddress = "NA";//dsdept.Tables[0].Rows[0][""].ToString();
                        factoryvo.occupierPinCode = dsdept.Tables[0].Rows[0]["Occupier_PinCode"].ToString();
                        factoryvo.occupierPositionInFactory = "NA";//dsdept.Tables[0].Rows[0][""].ToString();
                        factoryvo.occupierState = "36";//dsdept.Tables[0].Rows[0][""].ToString();
                        factoryvo.occupierVillage = dsdept.Tables[0].Rows[0]["Occupier_Village"].ToString();
                        factoryvo.ownerDistrict = dsdept.Tables[0].Rows[0]["Owner_District"].ToString();
                        factoryvo.ownerDoorNo = dsdept.Tables[0].Rows[0]["Owner_DoorNo"].ToString();
                        factoryvo.ownerFullName = dsdept.Tables[0].Rows[0]["Owner_Full_Name"].ToString();
                        factoryvo.ownerLocality = dsdept.Tables[0].Rows[0]["Owner_Locality"].ToString();
                        factoryvo.ownerMailId = dsdept.Tables[0].Rows[0]["Owner_EmailId"].ToString();
                        factoryvo.ownerMandal = dsdept.Tables[0].Rows[0]["Owner_Mandal"].ToString();
                        factoryvo.ownerMobileNumber = dsdept.Tables[0].Rows[0]["Owner_MobileNo"].ToString();
                        factoryvo.ownerOtherStatePostalAddress = "NA";//dsdept.Tables[0].Rows[0][""].ToString();
                        factoryvo.ownerPinCode = dsdept.Tables[0].Rows[0]["Owner_PinCode"].ToString();
                        factoryvo.ownerState = "36";//dsdept.Tables[0].Rows[0][""].ToString();
                        factoryvo.ownerVillage = dsdept.Tables[0].Rows[0]["Owner_Village"].ToString();
                        factoryvo.paidAmount = dsdept.Tables[0].Rows[0]["Approval_Fee"].ToString();
                        factoryvo.paymentStatus = dsdept.Tables[0].Rows[0]["IsPayment"].ToString();
                        factoryvo.plansReferenceApprovedByChiefInspectorIfApplicable = dsdept.Tables[0].Rows[0]["Plans_Chief_Inspector_RefNo"].ToString();//Plans_Chief_Inspector_RefNo
                        factoryvo.questionaireID = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                        factoryvo.systemIP = "0.0.0.0";// dsdept.Tables[0].Columns[""].ToString();
                        factoryvo.userID = dsdept.Tables[0].Rows[0]["CREATEDBY"].ToString();
                        factoryvo.userMailID = dsdept.Tables[0].Rows[0]["Email"].ToString();
                        factoryvo.userMobileNumber = dsdept.Tables[0].Rows[0]["MobileNumber"].ToString();
                        factoryvo.workersToBeEmployedAdolescentsFemale = dsdept.Tables[0].Rows[0]["Adolescents_Female"].ToString();
                        factoryvo.workersToBeEmployedAdolescentsMale = dsdept.Tables[0].Rows[0]["Adolescents_Male"].ToString();
                        factoryvo.workersToBeEmployedAdultsFemale = dsdept.Tables[0].Rows[0]["AdultFemale"].ToString();
                        factoryvo.workersToBeEmployedAdultsMale = dsdept.Tables[0].Rows[0]["AdultMale"].ToString();
                        factoryvo.workersToBeEmployedChildrenFemale = dsdept.Tables[0].Rows[0]["Children_Female"].ToString();
                        factoryvo.workersToBeEmployedChildrenMale = dsdept.Tables[0].Rows[0]["Children_Male"].ToString();

                        factoryvo.workersToBeEmployedAdolescentsTrans = dsdept.Tables[0].Rows[0]["AdolescentsTRANS"].ToString();
                        factoryvo.workersToBeEmployedAdultsTrans = dsdept.Tables[0].Rows[0]["AdultTRANS"].ToString();
                        factoryvo.workersToBeEmployedChildrenTrans = dsdept.Tables[0].Rows[0]["Children_TRANS"].ToString();

                        FactoryServiceCFO.aadharCardOrPanCard[] factoryaadhar = null;
                        FactoryServiceCFO.plansReferenceApprovedByDirectorOfFactories[] factoryrefapproved = null;
                        FactoryServiceCFO.latestListOfPartnersOrDirectors[] factorypartner = null;
                        FactoryServiceCFO.partnershipDeed[] factorypartnershipdeed = null;
                        FactoryServiceCFO.passPortSizePhotographWithSignature[] factoryphotosign = null;
                        FactoryServiceCFO.registeredSaleDeedOrLeaseDeed[] factoryregisteredsaledeed = null;

                        FactoryServiceCFO.factoryOccupierAndManagerPhotoIDProof[] factoryoccupierIdPrrof = null;
                        FactoryServiceCFO.inCaseChangeOfDirectorsFormNo32[] factorydirector = null;
                        FactoryServiceCFO.proposedInventoriesOfChemicalsUsed[] factoryinventories = null;

                        FactoryServiceCFO.machinery[] factmachineries = null;
                        FactoryServiceCFO.workersList[] factworkersList = null;
                        FactoryServiceCFO.selfComplianceChecklist[] factselfComplianceChecklist = null;

                        DataSet dsfactroy = new DataSet();
                        dsfactroy = gen.getattachmentdetailsonuidCFO(UIDNO, deptid, "");

                        if (dsfactroy != null && dsfactroy.Tables.Count > 0 && dsfactroy.Tables[0].Rows.Count > 0)
                        {
                            ///Registration Deed////

                            if (dsfactroy.Tables[0].Rows.Count > 0)
                            {
                                DataTable dtfactoryaadhar = new DataTable();
                                dtfactoryaadhar = dsfactroy.Tables[0];
                                factoryaadhar = new FactoryServiceCFO.aadharCardOrPanCard[dtfactoryaadhar.Rows.Count];

                                for (int n = 0; n < dtfactoryaadhar.Rows.Count; n++)
                                {
                                    FactoryServiceCFO.aadharCardOrPanCard factoryaadharvo = new FactoryServiceCFO.aadharCardOrPanCard();
                                    factoryaadharvo.documentName = dtfactoryaadhar.Rows[n]["FileName"].ToString();
                                    factoryaadharvo.documentPath = dtfactoryaadhar.Rows[n]["Filepath"].ToString();
                                    factoryaadhar[n] = factoryaadharvo;
                                }
                            }
                            if (dsfactroy.Tables[1].Rows.Count > 0)
                            {
                                DataTable dtfactoryrefapproved = new DataTable();
                                dtfactoryrefapproved = dsfactroy.Tables[1];
                                factoryrefapproved = new FactoryServiceCFO.plansReferenceApprovedByDirectorOfFactories[dtfactoryrefapproved.Rows.Count];

                                for (int o = 0; o < dtfactoryrefapproved.Rows.Count; o++)
                                {
                                    FactoryServiceCFO.plansReferenceApprovedByDirectorOfFactories factoryrefapprovedvo = new FactoryServiceCFO.plansReferenceApprovedByDirectorOfFactories();
                                    factoryrefapprovedvo.documentName = dtfactoryrefapproved.Rows[o]["FileName"].ToString();
                                    factoryrefapprovedvo.documentPath = dtfactoryrefapproved.Rows[o]["Filepath"].ToString();
                                    factoryrefapproved[o] = factoryrefapprovedvo;
                                }
                            }
                            if (dsfactroy.Tables[2].Rows.Count > 0)
                            {
                                DataTable dtfactorypartner = new DataTable();
                                dtfactorypartner = dsfactroy.Tables[2];
                                factorypartner = new FactoryServiceCFO.latestListOfPartnersOrDirectors[dtfactorypartner.Rows.Count];

                                for (int p = 0; p < dtfactorypartner.Rows.Count; p++)
                                {
                                    FactoryServiceCFO.latestListOfPartnersOrDirectors factorypartnervo = new FactoryServiceCFO.latestListOfPartnersOrDirectors();
                                    factorypartnervo.documentName = dtfactorypartner.Rows[p]["FileName"].ToString();
                                    factorypartnervo.documentPath = dtfactorypartner.Rows[p]["Filepath"].ToString();
                                    factorypartner[p] = factorypartnervo;
                                }
                            }
                            if (dsfactroy.Tables[3].Rows.Count > 0)
                            {
                                DataTable dtfactorypartnershipdeed = new DataTable();
                                dtfactorypartnershipdeed = dsfactroy.Tables[3];
                                factorypartnershipdeed = new FactoryServiceCFO.partnershipDeed[dtfactorypartnershipdeed.Rows.Count];

                                for (int n = 0; n < dtfactorypartnershipdeed.Rows.Count; n++)
                                {
                                    FactoryServiceCFO.partnershipDeed factorypartnershipdeedvo = new FactoryServiceCFO.partnershipDeed();
                                    factorypartnershipdeedvo.documentName = dtfactorypartnershipdeed.Rows[n]["FileName"].ToString();
                                    factorypartnershipdeedvo.documentPath = dtfactorypartnershipdeed.Rows[n]["Filepath"].ToString();
                                    factorypartnershipdeed[n] = factorypartnershipdeedvo;
                                }
                            }
                            if (dsfactroy.Tables[4].Rows.Count > 0)
                            {
                                DataTable dtfactoryphotosign = new DataTable();
                                dtfactoryphotosign = dsfactroy.Tables[4];
                                factoryphotosign = new FactoryServiceCFO.passPortSizePhotographWithSignature[dtfactoryphotosign.Rows.Count];

                                for (int n = 0; n < dtfactoryphotosign.Rows.Count; n++)
                                {
                                    FactoryServiceCFO.passPortSizePhotographWithSignature factoryphotosignvo = new FactoryServiceCFO.passPortSizePhotographWithSignature();
                                    factoryphotosignvo.documentName = dtfactoryphotosign.Rows[n]["FileName"].ToString();
                                    factoryphotosignvo.documentPath = dtfactoryphotosign.Rows[n]["Filepath"].ToString();
                                    factoryphotosign[n] = factoryphotosignvo;
                                }
                            }
                            if (dsfactroy.Tables[5].Rows.Count > 0)
                            {
                                DataTable dtfactoryregisteredsaledeed = new DataTable();
                                dtfactoryregisteredsaledeed = dsfactroy.Tables[5];
                                factoryregisteredsaledeed = new FactoryServiceCFO.registeredSaleDeedOrLeaseDeed[dtfactoryregisteredsaledeed.Rows.Count];

                                for (int n = 0; n < dtfactoryregisteredsaledeed.Rows.Count; n++)
                                {
                                    FactoryServiceCFO.registeredSaleDeedOrLeaseDeed factoryregisteredsaledeedvo = new FactoryServiceCFO.registeredSaleDeedOrLeaseDeed();
                                    factoryregisteredsaledeedvo.documentName = dtfactoryregisteredsaledeed.Rows[n]["FileName"].ToString();
                                    factoryregisteredsaledeedvo.documentPath = dtfactoryregisteredsaledeed.Rows[n]["Filepath"].ToString();
                                    factoryregisteredsaledeed[n] = factoryregisteredsaledeedvo;
                                }
                            }
                            if (dsfactroy.Tables[8].Rows.Count > 0)
                            {
                                DataTable dtmachinery = new DataTable();
                                dtmachinery = dsfactroy.Tables[8];
                                factmachineries = new FactoryServiceCFO.machinery[dtmachinery.Rows.Count];

                                for (int n = 0; n < dtmachinery.Rows.Count; n++)
                                {
                                    FactoryServiceCFO.machinery factoryrmachineryvo = new FactoryServiceCFO.machinery();
                                    factoryrmachineryvo.documentName = dtmachinery.Rows[n]["FileName"].ToString();
                                    factoryrmachineryvo.documentPath = dtmachinery.Rows[n]["Filepath"].ToString();
                                    factmachineries[n] = factoryrmachineryvo;
                                }
                            }

                            if (dsfactroy.Tables[9].Rows.Count > 0)
                            {
                                DataTable dtselfcompchklist = new DataTable();
                                dtselfcompchklist = dsfactroy.Tables[9];
                                factselfComplianceChecklist = new FactoryServiceCFO.selfComplianceChecklist[dtselfcompchklist.Rows.Count];

                                for (int n = 0; n < dtselfcompchklist.Rows.Count; n++)
                                {
                                    FactoryServiceCFO.selfComplianceChecklist factselfComplianceChecklistvo = new FactoryServiceCFO.selfComplianceChecklist();
                                    factselfComplianceChecklistvo.documentName = dtselfcompchklist.Rows[n]["FileName"].ToString();
                                    factselfComplianceChecklistvo.documentPath = dtselfcompchklist.Rows[n]["Filepath"].ToString();
                                    factselfComplianceChecklist[n] = factselfComplianceChecklistvo;
                                }
                            }

                            if (dsfactroy.Tables[10].Rows.Count > 0)
                            {
                                DataTable dtworkerslist = new DataTable();
                                dtworkerslist = dsfactroy.Tables[10];
                                factworkersList = new FactoryServiceCFO.workersList[dtworkerslist.Rows.Count];

                                for (int n = 0; n < dtworkerslist.Rows.Count; n++)
                                {
                                    FactoryServiceCFO.workersList factworkersListvo = new FactoryServiceCFO.workersList();
                                    factworkersListvo.documentName = dtworkerslist.Rows[n]["FileName"].ToString();
                                    factworkersListvo.documentPath = dtworkerslist.Rows[n]["Filepath"].ToString();
                                    factworkersList[n] = factworkersListvo;
                                }
                            }
                        }


                        factoryvo.aadharCardOrPanCardAttachments = factoryaadhar;
                        factoryvo.plansReferenceApprovedByDirectorOfFactoriesAttachments = factoryrefapproved;
                        factoryvo.latestListOfPartnersOrDirectorsAttachments = factorypartner;
                        factoryvo.partnershipDeedAttachments = factorypartnershipdeed;
                        factoryvo.passPortSizePhotographWithSignatureAttachments = factoryphotosign;
                        factoryvo.registeredSaleDeedOrLeaseDeedAttachments = factoryregisteredsaledeed;
                        factoryvo.factoryOccupierAndManagerPhotoIDProofAttachments = factoryoccupierIdPrrof;
                        factoryvo.inCaseChangeOfDirectorsFormNo32Attachments = factorydirector;
                        factoryvo.proposedInventoriesOfChemicalsUsedAttachments = factoryinventories;

                        factoryvo.machineryAttachments = factmachineries;
                        factoryvo.selfComplianceChecklistAttachments = factselfComplianceChecklist;
                        factoryvo.workersListAttachments = factworkersList;


                        string OUTPUT = factorycfo.insertIntoGrantLicense(factoryvo);

                        if (OUTPUT == "SUCCESS")
                        {

                            gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", OUTPUT, "Y");
                            gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "A", OUTPUT, "Y");
                            int k = gen.InsertDeptDateTracingCFO(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                        }
                        else
                        {
                            gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", OUTPUT, "N");
                        }
                    }
                }
            }
            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                DataTable dtadd = new DataTable();
                dtadd = ds.Tables[1];
                for (int i = 0; i < dtadd.Rows.Count; i++)
                {
                    string deptid = dtadd.Rows[i]["intApprovalid"].ToString();
                    string intQuessionairecfoid = dtadd.Rows[i]["intQuessionaireid"].ToString();
                    string intcfoenterpid = dtadd.Rows[i]["intCFOEnterpid"].ToString();
                    string INTDEPDID = dtadd.Rows[i]["intDeptid"].ToString();
                    if (deptid == "16")
                    {
                        try
                        {
                            string outputfactory = "";
                            string valuefactory = "";
                            DataSet dsdept = new DataSet();
                            dsdept = gen.getAdditionalPaymentDetailsCFO(UIDNO, deptid);
                            valuefactory = dsdept.GetXml();
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                            {
                                CEIGService.payment ceigpaymentvo = new CEIGService.payment();
                                ceigpaymentvo.amount = Convert.ToDouble(dsdept.Tables[0].Rows[0]["Online_Amount"].ToString());
                                //ceigpaymentvo.applicationID = dsdept.Tables[0].Rows[0]["Created_by"].ToString();
                                ceigpaymentvo.bank_id = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                ceigpaymentvo.branch_name = "";
                                ceigpaymentvo.challan_copy = "";
                                ceigpaymentvo.challan_date = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                ceigpaymentvo.challan_no = dsdept.Tables[0].Rows[0]["challano"].ToString();
                                ceigpaymentvo.entrepreneurID = dsdept.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                                ceigpaymentvo.payment_type = dsdept.Tables[0].Rows[0]["paymentmode"].ToString();
                                ceigpaymentvo.questionaireID = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                                ceigpaymentvo.reply_document = "";
                                ceigpaymentvo.reply_remarks = "";
                                ceigpaymentvo.system_ip = "1.1.1.1"; ;
                                ceigpaymentvo.tx_id = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                ceigpaymentvo.UID = dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                string outceigpayment = ceifcfo.updatePayment(ceigpaymentvo);

                                if (outceigpayment == "SUCCESS")
                                {

                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", outceigpayment, "Y");

                                }
                                else
                                {
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", outceigpayment, "N");
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    if (deptid == "15") //FACTORY
                    {
                        try
                        {
                            ServicePointManager.Expect100Continue = true;
                            ServicePointManager.SecurityProtocol = //SecurityProtocolType.Tls12;
                            SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                            string outputfactory = "";
                            string valuefactory = "";
                            DataSet dsdept = new DataSet();
                            dsdept = gen.getAdditionalPaymentDetailsCFO(UIDNO, deptid);
                            valuefactory = dsdept.GetXml();
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                            {
                                FactoryServiceCFO.grantLicenseAdditionalPayment factorycfovo = new FactoryServiceCFO.grantLicenseAdditionalPayment();
                                factorycfovo.applicationID = dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                factorycfovo.bankAmount = dsdept.Tables[0].Rows[0]["Online_Amount"].ToString();
                                factorycfovo.bankDate = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                factorycfovo.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                factorycfovo.challanNumber = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                factorycfovo.paymentStatus = dsdept.Tables[0].Rows[0]["PaymentFlag"].ToString();
                                factorycfovo.systemIP = "0.0.0.0";//dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                factorycfovo.userID = dsdept.Tables[0].Rows[0]["Created_by"].ToString();

                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[1].Rows.Count > 0)
                                {
                                    factorycfovo.harithanidhibankamount = dsdept.Tables[1].Rows[0]["Online_Amount"].ToString();
                                    factorycfovo.harithanidhibankdate = dsdept.Tables[1].Rows[0]["TransactionDate"].ToString();
                                    factorycfovo.harithanidhibankname = dsdept.Tables[1].Rows[0]["BankName"].ToString();
                                    factorycfovo.harithanidhibankstatus = dsdept.Tables[1].Rows[0]["PaymentFlag"].ToString();
                                    factorycfovo.harithanidhichallanno = dsdept.Tables[1].Rows[0]["TransactionNO"].ToString();
                                }
                                else
                                {
                                    factorycfovo.harithanidhibankstatus = "N";
                                    factorycfovo.harithanidhibankamount = "0";
                                }

                                //string outfactory = factorycfo.insertIntoGrantLicenseAdditionalPayment(factorycfovo);

                                //if (outfactory == "SUCCESS")
                                //{

                                //    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", outfactory, "Y");

                                //}
                                //else
                                //{
                                //    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", outfactory, "N");
                                //}
                                var response = factorycfo.insertIntoGrantLicenseAdditionalPayment(factorycfovo);
                                string allottedOfficer = response.allottedOfficer;
                                string applicationId = response.applicationId;
                                string certificatePath = response.certificatePath;
                                string entrepreneurId = response.entrepreneurId;
                                string questionaireId = response.questionaireId;
                                string registrationNo = response.registrationNo;
                                string remarks = response.remarks;
                                string result = response.result;   // SUCCESS / FAIL
                                string status = response.status;
                                string remarkswithallotedofficerandapplicationid = "";
                                remarkswithallotedofficerandapplicationid = "alloted officer: " + allottedOfficer + " , " + "factories application id: " + applicationId + " , " + "Remarks: " + remarks + " , " + "Status: " + status;
                                if (result == "SUCCESS")
                                {

                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", result, "Y");
                                    if (status == "Approval Issued" && remarks == "Auto Generation")
                                    {
                                        DepartmentApprovalSystem obj = new DepartmentApprovalSystem();
                                        obj.DepartmentApprovalProcessAndCertificateUploadCFO(intQuessionairecfoid, intcfoenterpid, deptid, INTDEPDID, "13", UIDNO + ".pdf", certificatePath, remarkswithallotedofficerandapplicationid, registrationNo, "");
                                    }
                                }
                                else
                                {
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", result, "N");
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    if (deptid == "18")/// FIRE
                    {
                        try
                        {
                            DataSet dsdept = new DataSet();
                            dsdept = gen.getAdditionalPaymentDetailsCFO(UIDNO, deptid);
                            string UIDNo = dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                            string amount = dsdept.Tables[0].Rows[0]["Online_Amount"].ToString();
                            string date = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                            string bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                            string challanNumber = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                            string paymentStatus = dsdept.Tables[0].Rows[0]["PaymentFlag"].ToString();
                            string systemIP = "0.0.0.0";//dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                            //string userID = dsdept.Tables[0].Rows[0]["Created_by"].ToString();

                            string outputfire = firecfo.PaymentDetails_CFO(UIDNo, challanNumber, date, bankName, amount);

                            if (outputfire == "Success")
                            {
                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", outputfire, "Y");
                            }
                            else
                            {
                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", outputfire, "N");
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    if (deptid == "27") //BOILER
                    {
                        try
                        {
                            string outputfactory = "";
                            string valuefactory = "";
                            DataSet dsdept = new DataSet();
                            dsdept = gen.getAdditionalPaymentDetailsCFO(UIDNO, deptid);
                            valuefactory = dsdept.GetXml();
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                            {
                                BoilerService.planAdditionalPayment Boilerpaymentvo = new BoilerService.planAdditionalPayment();
                                Boilerpaymentvo.applicationID = dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                Boilerpaymentvo.bankAmount = dsdept.Tables[0].Rows[0]["Online_Amount"].ToString();
                                Boilerpaymentvo.bankDate = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                Boilerpaymentvo.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                Boilerpaymentvo.bankstatus = dsdept.Tables[0].Rows[0]["PaymentFlag"].ToString();
                                Boilerpaymentvo.banktransid = "NA";
                                Boilerpaymentvo.challanNumber = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                Boilerpaymentvo.ddocode = "NA";
                                Boilerpaymentvo.department_transaction_id = "NA";
                                Boilerpaymentvo.hoa = "NA";
                                Boilerpaymentvo.remittersname = "NA";
                                Boilerpaymentvo.systemIP = "0:0:0:0";
                                Boilerpaymentvo.trydate = "NA";
                                Boilerpaymentvo.userID = dsdept.Tables[0].Rows[0]["Created_by"].ToString();

                                string OutBoiler = Boiler.insertIntoPlanApprovalAdditionalPayment(Boilerpaymentvo);
                                if (OutBoiler == "SUCCESS")
                                {
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", OutBoiler, "Y");
                                }
                                else
                                {
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", OutBoiler, "N");
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }
            // }
        }
        catch (Exception ex)
        {
            // lblmsg.Text = ex.Message;
            //  lblmsg.Visible = true;
        }

    }
    //[WebMethod]
    //public string TestServie(string name)
    //{
    //    WhatsAppApi.WhatsApp wa = new WhatsAppApi.WhatsApp("9014886811", "", "Shankar",false, false);


    //    GetTESTVALUES();
    //    return "Hello " + name;
    //}
    [WebMethod]
    public void FailedAppswebserviceQueryResponce(string intQuessionaireid, string intApprovalid, string intDeptid)
    {
        //ResetFormControl(this);
        DataSet dsMail = new DataSet();
        TSNPDCLService.TsipassWsService tsnpdcl = new TSNPDCLService.TsipassWsService();
        TSSPDCLService.TSSPDCLIPassService tsspdcl = new TSSPDCLService.TSSPDCLIPassService();
        FireService.Service1 fireservice = new FireService.Service1();
        //FactoryService.TSFactoryServiceImplService factory = new FactoryService.TSFactoryServiceImplService();
        FactoryServiceQueryResponse.TSFactoryServiceImplService factoryquery = new FactoryServiceQueryResponse.TSFactoryServiceImplService();
        FactoryServiceQueryResponse.planQR queryvo = new FactoryServiceQueryResponse.planQR();
        HMDAService.tsipass hmdaservice = new HMDAService.tsipass();
        HMDAService.ApplicationFormResponse hmdapplication = new HMDAService.ApplicationFormResponse();
        TSIICService.tsipass tsiicservice = new TSIICService.tsipass();
        TSIICService.ApplicationFormResponse tsiicapplication = new TSIICService.ApplicationFormResponse();

        string npdclqueryresponse = "", nicapplno="",questionnaireid="";
        DataSet dsdept = new DataSet();
        dsdept = Gen.GetQueryStatusByTransactionIDResponse(intQuessionaireid, intApprovalid);
        string UIDNO = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
        string filepath = dsdept.Tables[0].Rows[0]["queryRespDocPath"].ToString();
        string remarks = dsdept.Tables[0].Rows[0]["queryRespText"].ToString();
        if (intApprovalid == "20")
        {
            nicapplno = dsdept.Tables[0].Rows[0]["NICApplicationno"].ToString();
            questionnaireid = dsdept.Tables[0].Rows[0]["questionniareId"].ToString();
        }
        if (intApprovalid == "4" || intApprovalid == "41")//NPDCL
        {
            try
            {
                npdclqueryresponse = dsdept.GetXml();
                string npdclqueryresponseout = tsnpdcl.insertQueryResponse(npdclqueryresponse);
                StringReader str1 = new StringReader(npdclqueryresponseout);
                DataSet dsout1 = new DataSet();
                dsout1.ReadXml(str1);
                if (dsout1 != null && dsout1.Tables.Count > 0 && dsout1.Tables[0].Rows.Count > 0)
                {
                    if (dsout1.Tables[0].Columns.Contains("status"))
                    {
                        if (dsout1.Tables[0].Rows[0]["status"].ToString() == "S")
                        {
                            string npdclsattachment = dsout1.Tables[0].Rows[0]["status"].ToString();
                            Gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", npdclsattachment, "Y");
                            int k = Gen.InsertDeptDateTracing(intDeptid, intQuessionaireid, ds.Tables[0].Rows[0]["UID_No"].ToString().Trim(), null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFE", intApprovalid);
                        }
                        else
                        {
                            string npdclsattachmenterror = dsout1.Tables[0].Rows[0]["status"].ToString();
                            Gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", npdclsattachmenterror, "N");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }
        else if (intApprovalid == "8") //FIRE
        {
            try
            {
                string OUTPUT = fireservice.StoreQueryResponse(UIDNO, filepath, remarks);
                if (OUTPUT == "Success")
                {
                    Gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", OUTPUT, "Y");
                    int k = Gen.InsertDeptDateTracing(intDeptid, intQuessionaireid, ds.Tables[0].Rows[0]["UID_No"].ToString().Trim(), null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFE", intApprovalid);
                }
                else
                {
                    Gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", OUTPUT, "N");
                }
            }
            catch (Exception ex)
            {

            }
        }
        else if (intApprovalid == "25") //SPDCL
        {
            try
            {
                npdclqueryresponse = dsdept.GetXml();
                string Outtsspdcl = tsspdcl.setQueryResponse(npdclqueryresponse);
                if (Outtsspdcl == "Success")
                {
                    Gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", Outtsspdcl, "Y");
                    int k = Gen.InsertDeptDateTracing(intDeptid, intQuessionaireid, ds.Tables[0].Rows[0]["UID_No"].ToString().Trim(), null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFE", intApprovalid);
                }
                else
                {
                    Gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", Outtsspdcl, "N");
                }
            }
            catch (Exception ex)
            {

            }
        }
        else if (intApprovalid == "21" || intApprovalid == "5" || intApprovalid == "44")//FACTORIES
        {
            try
            {
                queryvo.applicationID = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
                queryvo.entrepreneurRemarks = dsdept.Tables[0].Rows[0]["queryRespText"].ToString();
                queryvo.systemIP = "0.0.0.0";
                queryvo.userID = dsdept.Tables[0].Rows[0]["userID"].ToString();

                FactoryServiceQueryResponse.queryResponseAttachment[] lst = null;
                if (dsdept.Tables[0].Rows.Count > 0)
                {
                    DataTable dtraw = new DataTable();
                    dtraw = dsdept.Tables[0];
                    lst = new FactoryServiceQueryResponse.queryResponseAttachment[dtraw.Rows.Count];

                    for (int k = 0; k < dtraw.Rows.Count; k++)
                    {
                        FactoryServiceQueryResponse.queryResponseAttachment factoryqueryvo = new FactoryServiceQueryResponse.queryResponseAttachment();
                        factoryqueryvo.documentName = dtraw.Rows[k]["queryRespDocName"].ToString();
                        factoryqueryvo.documentPath = dtraw.Rows[k]["queryRespDocPath1"].ToString();
                        lst[k] = factoryqueryvo;
                        //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                        //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                    }
                    queryvo.queryResponseAttachments = lst;
                }

                string queryout = factoryquery.insertIntoPlanApprovalQueryResponse(queryvo);
                if (queryout == "SUCCESS")
                {
                    Gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", queryout, "Y");
                    int k = Gen.InsertDeptDateTracing(intDeptid, intQuessionaireid, ds.Tables[0].Rows[0]["UID_No"].ToString().Trim(), null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFE", intApprovalid);
                }
                else
                {
                    Gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", queryout, "N");
                }
            }
            catch (Exception ex)
            {

            }
        }
        else if (intApprovalid == "31")
        {
            //DataSet dsdept = new DataSet();
            //dsdept = Gen.GetQueryStatusByTransactionIDResponse("1065", "35");
            //string UIDNO = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
            //string filepath = dsdept.Tables[0].Rows[0]["queryRespDocPath"].ToString();
            //string remarks = dsdept.Tables[0].Rows[0]["queryRespText"].ToString();
            DataSet dsdepthmda = new DataSet();
            dsdepthmda = Gen.GetQueryStatusByTransactionIDResponse(intQuessionaireid, intApprovalid);
            string tsiic = dsdepthmda.GetXml();
            tsiicapplication = tsiicservice.reSubmission(tsiic, "$$08@213");
            if (tsiicapplication.ResponseStatus.ToString() == "1")
            {
                Gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", tsiicapplication.ErrorMessage, "Y");
                int k = Gen.InsertDeptDateTracing(intDeptid, intQuessionaireid, UIDNO, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFE", intApprovalid);
            }
            else
            {
                Gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", tsiicapplication.ErrorMessage, "N");
            }
        }
        else if (intApprovalid == "35")
        {
            //DataSet dsdept = new DataSet();
            //dsdept = Gen.GetQueryStatusByTransactionIDResponse("1065", "35");
            //string UIDNO = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
            //string filepath = dsdept.Tables[0].Rows[0]["queryRespDocPath"].ToString();
            //string remarks = dsdept.Tables[0].Rows[0]["queryRespText"].ToString();
            DataSet dsdepthmda = new DataSet();
            dsdepthmda = Gen.GetQueryStatusByTransactionIDResponse(intQuessionaireid, intApprovalid);
            string hmda = dsdepthmda.GetXml();
            hmdapplication = hmdaservice.reSubmission(hmda, "$$08@213");
            if (hmdapplication.ResponseStatus.ToString() == "1")
            {
                Gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", hmdapplication.ErrorMessage, "Y");
                int k = Gen.InsertDeptDateTracing(intDeptid, intQuessionaireid, UIDNO, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFE", intApprovalid);
            }
            else
            {
                Gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", hmdapplication.ErrorMessage, "N");
            }
        }
        else if (intApprovalid == "20")
        {

            try
            {

                //string WEBSERVICE_URL = "http://164.100.163.19/TLWSC/updateCl?cafUniqueNo=" + questionnaireid + "&indApplicationNo=" + nicapplno + "&remark=" + remarks + "&urlSingle=" + filepath;
                string WEBSERVICE_URL = "http://tsocmms.nic.in/TLWS/updateCl?cafUniqueNo=" + questionnaireid + "&indApplicationNo=" + nicapplno + "&remark=" + remarks + "&urlSingle=" + filepath;
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
                                if (jsonResponse.Contains("Clarification submitted successfully"))
                                {
                                    Gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", jsonResponse, "Y");
                                    int k = Gen.InsertDeptDateTracing("1", questionnaireid, UIDNO, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFE", "20");
                                }
                                else
                                {
                                    Gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", jsonResponse, "N");
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
            catch (Exception ex)
            {

            }
        }
        //else
        //{
        //    int k = Gen.InsertDeptDateTracing(intDeptid, intQuessionaireid, ds.Tables[0].Rows[0]["UID_No"].ToString().Trim(), null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFE", intApprovalid);
        //}
        ////fireservice.BeginStoreQueryResponse(
        //dsMail = Gen.GetShowEmailidandMobileNumber(intQuessionaireid);

        //if (dsMail.Tables[0].Rows.Count > 0)
        //{

        //    cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") :<br/><br/> <b> Response to query has been submitted successfully.Further details will be communicated. Thank You.");
        //}
        //if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
        //{
        //    //cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") :<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in TS-iPASS. Thank You.");
        //    cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") : Response to query has been submitted successfully.Further details will be communicated. Thank You.");
        //}
    }
    [WebMethod]
    public void FailedAppswebserviceQueryResponcecfo(string intQuessionaireid, string intApprovalid, string intDeptid)
    {
        //ResetFormControl(this);
        DataSet dsdept = new DataSet();
        dsdept = Gen.GetQueryStatusByTransactionIDCFOResponse(intQuessionaireid, intApprovalid);
        string UIDNO = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
        string filepath = dsdept.Tables[0].Rows[0]["queryRespDocPath"].ToString();
        string remarks = dsdept.Tables[0].Rows[0]["queryRespText"].ToString();
        BoilerQueryResponseService.TSBoilerServiceImplService Boiler = new BoilerQueryResponseService.TSBoilerServiceImplService();
        BoilerQueryResponseService.planQR boilervo = new BoilerQueryResponseService.planQR();
        FireServiceCFO.Service1 fireservicecfo = new FireServiceCFO.Service1();
        FactoryQueryResponseServiceCFO.TSFactoryServiceImplService factoryquery = new FactoryQueryResponseServiceCFO.TSFactoryServiceImplService();
        CEIGService.InstallationAppServiceImplService ceifcfo = new CEIGService.InstallationAppServiceImplService();
        CEIGService.querReply ceigqueryvo = new CEIGService.querReply();

        if (intApprovalid == "16")
        {
            ceigqueryvo.applicationID = dsdept.Tables[0].Rows[0]["Created_by"].ToString();
            ceigqueryvo.entrepreneurID = dsdept.Tables[0].Rows[0]["entrepreneurId"].ToString();
            ceigqueryvo.questionaireID = dsdept.Tables[0].Rows[0]["questionniareId"].ToString();
            //ceigqueryvo.registration_id = Convert.ToInt32(dsdept.Tables[0].Rows[0]["intQueryTrnsid"].ToString());
            ceigqueryvo.reply_document = dsdept.Tables[0].Rows[0]["CEIGqueryRespDocName"].ToString();
            ceigqueryvo.reply_remarks = dsdept.Tables[0].Rows[0]["queryRespText"].ToString();
            ceigqueryvo.system_ip = "1.1.1.1";
            ceigqueryvo.UID = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
            string output = ceifcfo.updateQueryReply(ceigqueryvo);
            if (output == "SUCCESS")
            {
                Gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "Q", output, "Y");
                try
                {
                    int k = Gen.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, ds.Tables[0].Rows[0]["UID_No"].ToString().Trim(), null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFO", intApprovalid);
                }
                catch (Exception ex)
                {

                }
            }
            //SUCCESS
        }

        if (intApprovalid == "15")//FACTORIES
        {
            FactoryQueryResponseServiceCFO.grantLicenseQR queryvo = new FactoryQueryResponseServiceCFO.grantLicenseQR();
            FactoryQueryResponseServiceCFO.queryResponseAttachment factoryattachment = new FactoryQueryResponseServiceCFO.queryResponseAttachment();


            queryvo.applicationID = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
            queryvo.entrepreneurRemarks = dsdept.Tables[0].Rows[0]["queryRespText"].ToString();
            queryvo.systemIP = "0.0.0.0";
            queryvo.userID = dsdept.Tables[0].Rows[0]["userID"].ToString();

            FactoryQueryResponseServiceCFO.queryResponseAttachment[] lst = null;
            if (dsdept.Tables[0].Rows.Count > 0)
            {
                DataTable dtraw = new DataTable();
                dtraw = dsdept.Tables[0];
                lst = new FactoryQueryResponseServiceCFO.queryResponseAttachment[dtraw.Rows.Count];

                for (int k = 0; k < dtraw.Rows.Count; k++)
                {
                    FactoryQueryResponseServiceCFO.queryResponseAttachment factoryqueryvo = new FactoryQueryResponseServiceCFO.queryResponseAttachment();
                    factoryqueryvo.documentName = dtraw.Rows[k]["queryRespDocName"].ToString();
                    factoryqueryvo.documentPath = dtraw.Rows[k]["queryRespDocPath1"].ToString();
                    lst[k] = factoryqueryvo;
                    //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                    //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                }
                queryvo.queryResponseAttachments = lst;
            }

            string queryout = factoryquery.insertIntoGrantLicenseQueryResponse(queryvo);
            if (queryout == "SUCCESS")
            {
                Gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "Q", queryout, "Y");
                try
                {
                    int k = Gen.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, ds.Tables[0].Rows[0]["UID_No"].ToString().Trim(), null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFO", intApprovalid);
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                Gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "Q", queryout, "N");
            }

        }
        else if (intApprovalid == "18") //FIRE
        {
            string OUTPUT = fireservicecfo.StoreQueryResponse_CFO(UIDNO, filepath, remarks);
            if (OUTPUT == "Success")
            {
                Gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", OUTPUT, "Y");
                try
                {
                    int k = Gen.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, ds.Tables[0].Rows[0]["UID_No"].ToString().Trim(), null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFO", intApprovalid);
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                Gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", OUTPUT, "N");
            }
        }
        else if (intApprovalid == "27")//BOILERS
        {
            boilervo.applicationID = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
            boilervo.entrepreneurRemarks = dsdept.Tables[0].Rows[0]["queryRespText"].ToString(); ;
            boilervo.systemIP = "0.0.0.0";
            boilervo.userID = dsdept.Tables[0].Rows[0]["userID"].ToString();
            BoilerQueryResponseService.queryResponseAttachment[] lst = null;
            if (dsdept.Tables[0].Rows.Count > 0)
            {
                DataTable dtraw = new DataTable();
                dtraw = dsdept.Tables[0];
                lst = new BoilerQueryResponseService.queryResponseAttachment[dtraw.Rows.Count];

                for (int k = 0; k < dtraw.Rows.Count; k++)
                {
                    BoilerQueryResponseService.queryResponseAttachment boilerattachmentvo = new BoilerQueryResponseService.queryResponseAttachment();
                    boilerattachmentvo.documentName = dtraw.Rows[k]["queryRespDocName"].ToString();
                    boilerattachmentvo.documentPath = dtraw.Rows[k]["queryRespDocPath"].ToString();
                    lst[k] = boilerattachmentvo;
                    //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                    //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                }
            }
            boilervo.queryResponseAttachments = lst;
            string boilerout = Boiler.insertIntoPlanApprovalQueryResponse(boilervo);
            if (boilerout == "SUCCESS")
            {
                Gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "Q", boilerout, "Y");
                try
                {
                    int k = Gen.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, ds.Tables[0].Rows[0]["UID_No"].ToString().Trim(), null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFO", intApprovalid);
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                Gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "Q", boilerout, "N");
            }
        }
        //else
        //{
        //    try
        //    {
        //        int k = Gen.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, ds.Tables[0].Rows[0]["UID_No"].ToString().Trim(), null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFO", intApprovalid);
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
        //DataSet dsMail = new DataSet();
        //dsMail = Gen.GetShowEmailidandMobileNumberCFO(intQuessionaireid);

        //if (dsMail.Tables[0].Rows.Count > 0)
        //{

        //    cmf.SendMailTSiPASSCFO(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") :<br/><br/> <b> Response to query has been submitted successfully.Further details will be communicated. Thank You.");
        //}
        //if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
        //{
        //    //cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") :<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in TS-iPASS. Thank You.");
        //    cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") : Response to query has been submitted successfully.Further details will be communicated. Thank You.");
        //}
        ////Response.Redirect("frmLINEOFMANUFACTURE.aspx?intApplicationId=" + hdfID.Value);
        //lblmsg.Text = "<font color='green'>Query Details Added Successfully..!</font>";
        //success.Visible = true;
        //Failure.Visible = false;
        //Response.Redirect("DashboardNewCFO.aspx");
        //this.Clear();
        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
        //fillNews(userid);
    }
    [WebMethod]
    public void callbilldeskpage(string onlineordernoInput)
    {
        try
        {
            string FromdateforDB = "", TodateforDB = "";

            //FromdateforDB = Convert.ToString(DateTime.ParseExact('', "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            //TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));


            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = Gen.GetBillDeskNotUpdateReport(FromdateforDB, TodateforDB, onlineordernoInput);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                paymentresponseVOsobj = new paymentresponseVOs();
                dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string onlineorderno = dt.Rows[i]["OnlineOrderNo"].ToString();
                    string Appltype = dt.Rows[i]["ApplType"].ToString();
                    var st = "data";
                    String commonkey = "alAQ2hHZXsvr";
                    String data = "0122|COITS|" + onlineorderno + "|" + DateTime.Now.ToString("yyyyMMddHHmmss") + "";
                    String hash = String.Empty;
                    hash = GetHMACSHA256(data, commonkey);
                    hash = hash.ToUpper();
                    String msg = data + "|" + hash;
                    //Response.Write(msg);

                    //Response.Write("<br/><br/>");

                    string WEBSERVICE_URL = "https://www.billdesk.com/pgidsk/PGIQueryController?msg=" + msg + "";
                    try
                    {
                        var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
                        if (webRequest != null)
                        {
                            webRequest.Method = "POST";
                            webRequest.Timeout = 20000;
                            webRequest.ContentType = "application/x-www-form-urlencoded";

                            using (System.IO.Stream s = webRequest.GetRequestStream())
                            {
                                //using (System.IO.StreamWriter sw = new System.IO.StreamWriter(s))
                                System.IO.StreamWriter sw = new System.IO.StreamWriter(s);
                                //sw.Write(jsonData);
                            }

                            using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                            {
                                using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                                {
                                    var jsonResponse = sr.ReadToEnd();
                                  
                                    string BilldeskResponse = jsonResponse;

                                    GetTESTVALUES(BilldeskResponse);



                                    // string BilldeskResponse = msg;
                                    string[] values = BilldeskResponse.Split('|');
                                    paymentresponseVOsobj.AuthStatus_14 = values[15];
                                    if (paymentresponseVOsobj.AuthStatus_14 == "0300")
                                    {
                                        paymentresponseVOsobj.MerchantID_0 = values[1];
                                        paymentresponseVOsobj.CustomerID_1 = values[18];   // UID Number
                                        paymentresponseVOsobj.TxnReferenceNo_2 = values[3];
                                        paymentresponseVOsobj.BankReferenceNo_3 = values[4];
                                        paymentresponseVOsobj.TxnAmount_4 = values[5];
                                        paymentresponseVOsobj.BankID_5 = values[6];
                                        paymentresponseVOsobj.BIN_6 = values[7];
                                        paymentresponseVOsobj.TxnType_7 = values[8];
                                        paymentresponseVOsobj.CurrencyName_8 = values[9];
                                        paymentresponseVOsobj.ItemCode_9 = values[10];
                                        paymentresponseVOsobj.SecurityType_10 = values[11];
                                        paymentresponseVOsobj.SecurityID_11 = values[12];
                                        paymentresponseVOsobj.SecurityPassword_12 = values[13];
                                        string[] date = values[14].Split(' ');
                                        string[] newdate = date[0].ToString().Split('-');
                                        paymentresponseVOsobj.TxnDate_13 = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString() + " " + date[1].ToString();
                                        paymentresponseVOsobj.AuthStatus_14 = values[15];
                                        paymentresponseVOsobj.SettlementType_15 = values[16];
                                        paymentresponseVOsobj.AdditionalInfo1_16 = values[17];   // Questionaireid
                                        paymentresponseVOsobj.AdditionalInfo2_17 = values[2];    // TSipassOrderNumber
                                        paymentresponseVOsobj.AdditionalInfo3_18 = values[19];   // ApplicationType
                                        paymentresponseVOsobj.AdditionalInfo4_19 = values[20];   // Departmentdetails
                                        paymentresponseVOsobj.AdditionalInfo5_20 = values[21];   //  AddtionalPayment flag
                                        //paymentresponseVOsobj.AdditionalInfo5_20 = dt.Rows[i]["AddtionalPaymentflg"].ToString();
                                        paymentresponseVOsobj.AdditionalInfo6_21 = values[22];
                                        paymentresponseVOsobj.AdditionalInfo7_22 = values[23];
                                        paymentresponseVOsobj.ErrorStatus_23 = values[24];
                                        paymentresponseVOsobj.ErrorDescription_24 = values[25];
                                        paymentresponseVOsobj.CheckSum_25 = values[32];
                                        paymentresponseVOsobj.Createdby = "00001";


                                        //“0300”   Success                                           Successful Transaction
                                        //“0399”   Invalid Authentication at Bank                    Cancel Transaction
                                        //“NA”     Invalid Input in the Request Message              Cancel Transaction
                                        //“0002”   BillDesk is waiting for Response from Bank        Cancel Transaction
                                        //“0001”   Error at BillDesk                                 Cancel Transaction

                                        if (paymentresponseVOsobj.AdditionalInfo4_19 == "NODEPT")
                                        {
                                            DataSet dspaydtls = new DataSet();
                                            if (paymentresponseVOsobj.AdditionalInfo5_20 == "Y")
                                            {
                                                if (Appltype == "CFE")
                                                {
                                                    dspaydtls = Gen.GetEnterprinerpaymentDtls(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, paymentresponseVOsobj.AdditionalInfo5_20);
                                                }
                                                if (Appltype == "CFO")
                                                {
                                                    dspaydtls = Gen.GetEnterprinerpaymentDtlsCfo(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, paymentresponseVOsobj.AdditionalInfo5_20);
                                                }

                                                //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                                                if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                                                {
                                                    paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                                                }
                                            }
                                            else
                                            {
                                                if (Appltype == "CFE")
                                                {
                                                    dspaydtls = Gen.GetEnterprinerpaymentDtls(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, "");
                                                }
                                                if (Appltype == "CFO")
                                                {
                                                    dspaydtls = Gen.GetEnterprinerpaymentDtlsCfo(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, "");
                                                }
                                                //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                                                if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                                                {
                                                    paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                                                }
                                            }
                                        }
                                        if (paymentresponseVOsobj.AdditionalInfo5_20 == "NA")
                                        {
                                            paymentresponseVOsobj.AdditionalInfo5_20 = "";
                                        }
                                        List<paymendepartwisetresponseVOs> paymendepartwisetresponseVOsobj = new List<paymendepartwisetresponseVOs>();
                                        string[] deptvalues = paymentresponseVOsobj.AdditionalInfo4_19.Split('&');
                                        for (int k = 0; k < deptvalues.Length; k++)
                                        {
                                            string[] deptwisevalues = deptvalues[k].Split('#');
                                            paymendepartwisetresponseVOs payment = new paymendepartwisetresponseVOs();
                                            payment.Questionnaireid = deptwisevalues[0].ToString();
                                            payment.intEnterprenerid = deptwisevalues[1].ToString();
                                            payment.Departmentid = deptwisevalues[2].ToString();
                                            payment.CustomerID_1 = deptwisevalues[3].ToString();
                                            payment.DeptAmount = deptwisevalues[4].ToString();
                                            payment.intApprovalid = deptwisevalues[5].ToString();
                                            payment.TxnDate_13 = paymentresponseVOsobj.TxnDate_13;
                                            payment.TxnReferenceNo_2 = paymentresponseVOsobj.TxnReferenceNo_2;
                                            payment.BankReferenceNo_3 = paymentresponseVOsobj.BankReferenceNo_3;
                                            payment.TxnAmount_4 = paymentresponseVOsobj.TxnAmount_4;
                                            payment.BankID_5 = paymentresponseVOsobj.BankID_5;
                                            payment.Createdby = paymentresponseVOsobj.Createdby;
                                            payment.AdditionalPaymentFlag = paymentresponseVOsobj.AdditionalInfo5_20;
                                            paymendepartwisetresponseVOsobj.Add(payment);
                                        }
                                        if (paymentresponseVOsobj.AuthStatus_14 == "0300")
                                        {
                                            if (Appltype == "CFE")
                                            {
                                                int valid = InsertUpdatepaymentdtls(paymentresponseVOsobj, paymendepartwisetresponseVOsobj);
                                                if (valid == 1)
                                                {
                                                    //  LogErrorToText1("Payment done successfully,Reference number: " + paymentresponseVOsobj.TxnReferenceNo_2);

                                                    Session["Amount"] = paymentresponseVOsobj.TxnAmount_4;
                                                    Session["RefNo"] = paymentresponseVOsobj.BankID_5;
                                                    Session["TranRefNo"] = paymentresponseVOsobj.TxnReferenceNo_2;
                                                    
                                                    sendata.webservicecfe(paymentresponseVOsobj.CustomerID_1);
                                                }
                                            }
                                            if (Appltype == "CFO")
                                            {
                                                int valid = InsertUpdatepaymentdtlscfo(paymentresponseVOsobj, paymendepartwisetresponseVOsobj);
                                                if (valid == 1)
                                                {
                                                    //  LogErrorToText1("Payment done successfully,Reference number: " + paymentresponseVOsobj.TxnReferenceNo_2);

                                                    Session["Amount"] = paymentresponseVOsobj.TxnAmount_4;
                                                    Session["RefNo"] = paymentresponseVOsobj.BankID_5;
                                                    Session["TranRefNo"] = paymentresponseVOsobj.TxnReferenceNo_2;

                                                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Done Successfully');" + "window.location='IpassPrintReceiptCFO.aspx';", true);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            UpdateOldtransactiondetails(onlineorderno);

                                            // LogErrorToText1("Payment failed at bank values: " + respActualValues);
                                            // Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Failed at Bank due to " + paymentresponseVOsobj.ErrorDescription_24 + "');" + "window.location='HomeDashboard.aspx';", true);
                                            // Response.Redirect("HomeDashboard.aspx");
                                        }
                                    }
                                    else
                                    {
                                        UpdateOldtransactiondetails(onlineorderno);

                                        // LogErrorToText1("Payment failed at bank values: " + respActualValues);
                                        // Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Failed at Bank due to " + paymentresponseVOsobj.ErrorDescription_24 + "');" + "window.location='HomeDashboard.aspx';", true);
                                        // Response.Redirect("HomeDashboard.aspx");
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.ToString());
                        callbilldeskpageclose();
                    }


                }
            }
        }
        catch (Exception ex)
        {
            callbilldeskpageclose();
        }
        callbilldeskpageclose();
    }
    public string GetHMACSHA256(string text, string key)
    {
        UTF8Encoding encoder = new UTF8Encoding();

        byte[] hashValue;
        byte[] keybyt = encoder.GetBytes(key);
        byte[] message = encoder.GetBytes(text);

        HMACSHA256 hashString = new HMACSHA256(keybyt);
        string hex = "";

        hashValue = hashString.ComputeHash(message);
        foreach (byte x in hashValue)
        {
            hex += String.Format("{0:x2}", x);
        }
        return hex;
    }
    public int InsertUpdatepaymentdtls(paymentresponseVOs paymentresponseVOsobj, List<paymendepartwisetresponseVOs> paymendepartwisetresponseVOsobj)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        int valid = 0;
        int itemidout = 0;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction trans = null;

        connection.Open();
        trans = connection.BeginTransaction();
        SqlCommand command = new SqlCommand("[USP_UPDATE_Builldesc_PaymentDtls]", connection);
        command.CommandType = CommandType.StoredProcedure;
        SqlCommand command1 = null;

        try
        {
            command.Parameters.AddWithValue("@CustomerID_1", paymentresponseVOsobj.CustomerID_1);
            command.Parameters.AddWithValue("@TxnReferenceNo_2", paymentresponseVOsobj.TxnReferenceNo_2);
            command.Parameters.AddWithValue("@BankReferenceNo_3", paymentresponseVOsobj.BankReferenceNo_3);
            command.Parameters.AddWithValue("@TxnAmount_4", paymentresponseVOsobj.TxnAmount_4);
            command.Parameters.AddWithValue("@BankID_5", paymentresponseVOsobj.BankID_5);
            command.Parameters.AddWithValue("@BIN_6", paymentresponseVOsobj.BIN_6);
            command.Parameters.AddWithValue("@TxnType_7", paymentresponseVOsobj.TxnType_7);
            command.Parameters.AddWithValue("@CurrencyName_8", paymentresponseVOsobj.CurrencyName_8);
            command.Parameters.AddWithValue("@ItemCode_9", paymentresponseVOsobj.ItemCode_9);
            command.Parameters.AddWithValue("@SecurityType_10", paymentresponseVOsobj.SecurityType_10);
            command.Parameters.AddWithValue("@SecurityID_11", paymentresponseVOsobj.SecurityID_11);
            command.Parameters.AddWithValue("@SecurityPassword_12", paymentresponseVOsobj.SecurityPassword_12);
            command.Parameters.AddWithValue("@TxnDate_13", paymentresponseVOsobj.TxnDate_13);
            command.Parameters.AddWithValue("@AuthStatus_14", paymentresponseVOsobj.AuthStatus_14);
            command.Parameters.AddWithValue("@SettlementType_15", paymentresponseVOsobj.SettlementType_15);
            command.Parameters.AddWithValue("@AdditionalInfo1_16", paymentresponseVOsobj.AdditionalInfo1_16);
            command.Parameters.AddWithValue("@AdditionalInfo2_17", paymentresponseVOsobj.AdditionalInfo2_17);
            command.Parameters.AddWithValue("@AdditionalInfo3_18", paymentresponseVOsobj.AdditionalInfo3_18);
            command.Parameters.AddWithValue("@AdditionalInfo4_19", paymentresponseVOsobj.AdditionalInfo4_19);
            command.Parameters.AddWithValue("@AdditionalInfo5_20", paymentresponseVOsobj.AdditionalInfo5_20);
            command.Parameters.AddWithValue("@AdditionalInfo6_21", paymentresponseVOsobj.AdditionalInfo6_21);
            command.Parameters.AddWithValue("@AdditionalInfo7_22", paymentresponseVOsobj.AdditionalInfo7_22);
            command.Parameters.AddWithValue("@ErrorStatus_23", paymentresponseVOsobj.ErrorStatus_23);
            command.Parameters.AddWithValue("@ErrorDescription_24", paymentresponseVOsobj.ErrorDescription_24);
            command.Parameters.AddWithValue("@Created_by", paymentresponseVOsobj.Createdby);
            command.Parameters.Add("@VALID", SqlDbType.Int, 500);
            command.Parameters["@VALID"].Direction = ParameterDirection.Output;

            command.Transaction = trans;
            command.ExecuteNonQuery();
            valid = (Int32)command.Parameters["@VALID"].Value;

            if (valid == 1)
            {
                foreach (paymendepartwisetresponseVOs ffvo in paymendepartwisetresponseVOsobj)
                {
                    command1 = new SqlCommand("[USP_UPDATE_DEPTWISE_Builldesc_PaymentDtls]", connection);
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.Parameters.AddWithValue("@intQuessionaireid", ffvo.Questionnaireid);
                    command1.Parameters.AddWithValue("@intApprovalid", ffvo.intApprovalid);
                    command1.Parameters.AddWithValue("@intDeptid", ffvo.Departmentid);
                    command1.Parameters.AddWithValue("@TSIPASSUID", ffvo.CustomerID_1);
                    command1.Parameters.AddWithValue("@TxnDate_13", ffvo.TxnDate_13);
                    command1.Parameters.AddWithValue("@TxnReferenceNo_2", ffvo.TxnReferenceNo_2);
                    command1.Parameters.AddWithValue("@BankReferenceNo_3", ffvo.BankReferenceNo_3);
                    command1.Parameters.AddWithValue("@Deptamont", ffvo.DeptAmount);
                    command1.Parameters.AddWithValue("@TxnAmount_4", ffvo.TxnAmount_4);
                    command1.Parameters.AddWithValue("@BankID_5", ffvo.BankID_5);
                    command1.Parameters.AddWithValue("@AdditionalPaymentflg", ffvo.AdditionalPaymentFlag);
                    command1.Parameters.AddWithValue("@Created_by", ffvo.Createdby);
                    command1.Parameters.Add("@VALID", SqlDbType.Int, 500);
                    command1.Parameters["@VALID"].Direction = ParameterDirection.Output;
                    command1.Transaction = trans;
                    command1.ExecuteNonQuery();
                    valid = (Int32)command1.Parameters["@VALID"].Value;
                }
            }
            trans.Commit();
            connection.Close();

        }

        catch (Exception ex)
        {
            trans.Rollback();

            throw ex;
        }
        finally
        {
            command.Dispose();
            connection.Close();
            connection.Dispose();
            //command1.Dispose();
        }
        return valid;
    }
    public int InsertUpdatepaymentdtlscfo(paymentresponseVOs paymentresponseVOsobj, List<paymendepartwisetresponseVOs> paymendepartwisetresponseVOsobj)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        int valid = 0;
        int itemidout = 0;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction trans = null;

        connection.Open();
        trans = connection.BeginTransaction();
        SqlCommand command = new SqlCommand("[USP_UPDATE_Builldesc_PaymentDtls_CFO]", connection);
        command.CommandType = CommandType.StoredProcedure;
        SqlCommand command1 = null;

        try
        {
            command.Parameters.AddWithValue("@CustomerID_1", paymentresponseVOsobj.CustomerID_1);
            command.Parameters.AddWithValue("@TxnReferenceNo_2", paymentresponseVOsobj.TxnReferenceNo_2);
            command.Parameters.AddWithValue("@BankReferenceNo_3", paymentresponseVOsobj.BankReferenceNo_3);
            command.Parameters.AddWithValue("@TxnAmount_4", paymentresponseVOsobj.TxnAmount_4);
            command.Parameters.AddWithValue("@BankID_5", paymentresponseVOsobj.BankID_5);
            command.Parameters.AddWithValue("@BIN_6", paymentresponseVOsobj.BIN_6);
            command.Parameters.AddWithValue("@TxnType_7", paymentresponseVOsobj.TxnType_7);
            command.Parameters.AddWithValue("@CurrencyName_8", paymentresponseVOsobj.CurrencyName_8);
            command.Parameters.AddWithValue("@ItemCode_9", paymentresponseVOsobj.ItemCode_9);
            command.Parameters.AddWithValue("@SecurityType_10", paymentresponseVOsobj.SecurityType_10);
            command.Parameters.AddWithValue("@SecurityID_11", paymentresponseVOsobj.SecurityID_11);
            command.Parameters.AddWithValue("@SecurityPassword_12", paymentresponseVOsobj.SecurityPassword_12);
            command.Parameters.AddWithValue("@TxnDate_13", paymentresponseVOsobj.TxnDate_13);
            command.Parameters.AddWithValue("@AuthStatus_14", paymentresponseVOsobj.AuthStatus_14);
            command.Parameters.AddWithValue("@SettlementType_15", paymentresponseVOsobj.SettlementType_15);
            command.Parameters.AddWithValue("@AdditionalInfo1_16", paymentresponseVOsobj.AdditionalInfo1_16);
            command.Parameters.AddWithValue("@AdditionalInfo2_17", paymentresponseVOsobj.AdditionalInfo2_17);
            command.Parameters.AddWithValue("@AdditionalInfo3_18", paymentresponseVOsobj.AdditionalInfo3_18);
            command.Parameters.AddWithValue("@AdditionalInfo4_19", paymentresponseVOsobj.AdditionalInfo4_19);
            command.Parameters.AddWithValue("@AdditionalInfo5_20", paymentresponseVOsobj.AdditionalInfo5_20);
            command.Parameters.AddWithValue("@AdditionalInfo6_21", paymentresponseVOsobj.AdditionalInfo6_21);
            command.Parameters.AddWithValue("@AdditionalInfo7_22", paymentresponseVOsobj.AdditionalInfo7_22);
            command.Parameters.AddWithValue("@ErrorStatus_23", paymentresponseVOsobj.ErrorStatus_23);
            command.Parameters.AddWithValue("@ErrorDescription_24", paymentresponseVOsobj.ErrorDescription_24);
            command.Parameters.AddWithValue("@Created_by", paymentresponseVOsobj.Createdby);
            command.Parameters.Add("@VALID", SqlDbType.Int, 500);
            command.Parameters["@VALID"].Direction = ParameterDirection.Output;

            command.Transaction = trans;
            command.ExecuteNonQuery();
            valid = (Int32)command.Parameters["@VALID"].Value;

            if (valid == 1)
            {
                foreach (paymendepartwisetresponseVOs ffvo in paymendepartwisetresponseVOsobj)
                {
                    command1 = new SqlCommand("[USP_UPDATE_DEPTWISE_Builldesc_PaymentDtls_CFO]", connection);
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.Parameters.AddWithValue("@intQuessionaireid", ffvo.Questionnaireid);
                    command1.Parameters.AddWithValue("@intApprovalid", ffvo.intApprovalid);
                    command1.Parameters.AddWithValue("@intDeptid", ffvo.Departmentid);
                    command1.Parameters.AddWithValue("@TSIPASSUID", ffvo.CustomerID_1);
                    command1.Parameters.AddWithValue("@TxnDate_13", ffvo.TxnDate_13);
                    command1.Parameters.AddWithValue("@TxnReferenceNo_2", ffvo.TxnReferenceNo_2);
                    command1.Parameters.AddWithValue("@BankReferenceNo_3", ffvo.BankReferenceNo_3);
                    command1.Parameters.AddWithValue("@Deptamont", ffvo.DeptAmount);
                    command1.Parameters.AddWithValue("@TxnAmount_4", ffvo.TxnAmount_4);
                    command1.Parameters.AddWithValue("@BankID_5", ffvo.BankID_5);
                    command1.Parameters.AddWithValue("@AdditionalPaymentflg", ffvo.AdditionalPaymentFlag);
                    command1.Parameters.AddWithValue("@Created_by", ffvo.Createdby);
                    command1.Parameters.Add("@VALID", SqlDbType.Int, 500);
                    command1.Parameters["@VALID"].Direction = ParameterDirection.Output;
                    command1.Transaction = trans;
                    command1.ExecuteNonQuery();
                    valid = (Int32)command1.Parameters["@VALID"].Value;
                }
            }
            trans.Commit();
            connection.Close();

        }

        catch (Exception ex)
        {
            trans.Rollback();

            throw ex;
        }
        finally
        {
            command.Dispose();
            connection.Close();
            connection.Dispose();
            //command1.Dispose();
        }
        return valid;
    }
    public void GetTESTVALUES(string Responce)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_TEST_WEBSERVISE", con.GetConnection);
            da.SelectCommand.Parameters.Add("@responce", SqlDbType.VarChar).Value = Responce.ToString();

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(ds);
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
    public void callbilldeskpageclose()
    {
        // System.Web.HttpContext.Current.Response.Write("<script>self.close();</script>");
    }
    [WebMethod]
    public void CallWebserviceFromRTA()
    {
        try
        {
            callbilldeskpage("ALL");
        }
        catch (Exception ex)
        {

        }
        try
        {
            DataSet ds = new DataSet();
            ds = GetCFEVALUES();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)  // CFE VALUES
            {
                int totalCOUNT = 0;
                string UIDNOWEB = "";
                string STEGID = "";
                string INTAPPROVALID = "";
                string INTQUESTIONNAIREID = "";
                string INTDEPTID = "";

                totalCOUNT = ds.Tables[0].Rows.Count;
                for (int i = 0; i < totalCOUNT; i++)
                {
                    UIDNOWEB = ds.Tables[0].Rows[i]["UIDNO"].ToString();
                    STEGID = ds.Tables[0].Rows[i]["INTSTAGEID"].ToString();
                    INTAPPROVALID = ds.Tables[0].Rows[i]["INTAPPROVALID"].ToString();
                    INTQUESTIONNAIREID = ds.Tables[0].Rows[i]["INTQUESTIONNAIREID"].ToString();
                    INTDEPTID = ds.Tables[0].Rows[i]["INTDEPTID"].ToString();
                    if (STEGID == "4")
                    {
                        try
                        {
                            FailedAppswebservice(UIDNOWEB);
                        }
                        catch (Exception ex1)
                        {

                        }
                    }
                    else if (STEGID == "9")
                    {
                        try
                        {
                            FailedAppswebserviceQueryResponce(INTQUESTIONNAIREID, INTAPPROVALID, INTDEPTID);
                        }
                        catch (Exception ex2)
                        {

                        }
                    }
                }
            }
            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)  // CFE
            {
                int totalCOUNT = 0;
                string UIDNOWEB = "";
                string STEGID = "";
                string INTAPPROVALID = "";
                string INTQUESTIONNAIREID = "";
                string INTDEPTID = "";

                totalCOUNT = ds.Tables[1].Rows.Count;
                for (int i = 0; i < totalCOUNT; i++)
                {
                    UIDNOWEB = ds.Tables[1].Rows[i]["UIDNO"].ToString();
                    STEGID = ds.Tables[1].Rows[i]["INTSTAGEID"].ToString();
                    INTAPPROVALID = ds.Tables[1].Rows[i]["INTAPPROVALID"].ToString();
                    INTQUESTIONNAIREID = ds.Tables[1].Rows[i]["INTQUESTIONNAIREID"].ToString();
                    INTDEPTID = ds.Tables[1].Rows[i]["INTDEPTID"].ToString();
                    if (STEGID == "4")
                    {
                        try
                        {
                            FailedAppswebservicecfo(UIDNOWEB);
                        }
                        catch (Exception ex1)
                        {

                        }
                    }
                    else if (STEGID == "9")
                    {
                        try
                        {
                            FailedAppswebserviceQueryResponcecfo(INTQUESTIONNAIREID, INTAPPROVALID, INTDEPTID);
                        }
                        catch (Exception ex2)
                        {

                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
    }
    public DataSet GetCFEVALUES()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_FAILESAPPS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(ds);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
        return ds;
    }

    public void UpdateOldtransactiondetails(string TSipassOrderNumber)
    {
        string OldTSipassOrderNumber = "";
        string NewTSipassOrderNumber = "";
        string UidNo = "";
        string PaymentStatus = "";
        DataSet ds = new DataSet();
        ds = Getchildandparentdata(TSipassOrderNumber);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            int totalrowscount = ds.Tables[0].Rows.Count;
            for (int i = 0; i < totalrowscount; i++)
            {
                OldTSipassOrderNumber = "";
                NewTSipassOrderNumber = "";
                UidNo = "";
                PaymentStatus = "";

                OldTSipassOrderNumber = ds.Tables[0].Rows[i]["OldOnlineOrderNo"].ToString();
                NewTSipassOrderNumber = ds.Tables[0].Rows[i]["OnlineOrderNo"].ToString();
                UidNo = ds.Tables[0].Rows[i]["UIDNO"].ToString();

                PaymentStatus = Cehckstatuspayment(OldTSipassOrderNumber);
                if (PaymentStatus == "0300")
                {
                    UpdateNewpaymentidwitholdpaymentid(OldTSipassOrderNumber, NewTSipassOrderNumber, UidNo);
                    callbilldeskpage(OldTSipassOrderNumber);
                    return;
                }
            }
        }
    }
    public string Cehckstatuspayment(string TSipassOrderNumber)
    {
        string PaymentStatus = "";

        string onlineorderno = TSipassOrderNumber;
        var st = "data";
        String commonkey = "alAQ2hHZXsvr";
        String data = "0122|COITS|" + onlineorderno + "|" + DateTime.Now.ToString("yyyyMMddHHmmss") + "";
        String hash = String.Empty;
        hash = GetHMACSHA256(data, commonkey);
        hash = hash.ToUpper();
        String msg = data + "|" + hash;


        string WEBSERVICE_URL = "https://www.billdesk.com/pgidsk/PGIQueryController?msg=" + msg + "";
        try
        {
            var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
            if (webRequest != null)
            {
                webRequest.Method = "POST";
                webRequest.Timeout = 20000;
                webRequest.ContentType = "application/x-www-form-urlencoded";

                using (System.IO.Stream s = webRequest.GetRequestStream())
                {
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(s);
                }
                using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                    {
                        var jsonResponse = sr.ReadToEnd();
                        string BilldeskResponse = jsonResponse;
                        // GetTESTVALUES(BilldeskResponse);
                        // string BilldeskResponse = msg;
                        string[] values = BilldeskResponse.Split('|');
                        PaymentStatus = values[15];
                        if (PaymentStatus == "0300")
                        {

                        }
                        else
                        {

                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {

        }
        return PaymentStatus;
    }
    public DataSet Getchildandparentdata(string TSipassOrderNumber)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@OnlineOrderNo",SqlDbType.VarChar),
           };
        pp[0].Value = TSipassOrderNumber;
        Dsnew = gen.GenericFillDs("USP_GET_OLDTRANSACTIONS_UPDATE", pp);
        return Dsnew;
    }
    public int UpdateNewpaymentidwitholdpaymentid(string oldTSipassOrderNumber, string NewTSipassOrderNumber, string UidNO)
    {
        SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@oldTSipassOrderNumber",SqlDbType.VarChar),
               new SqlParameter("@NewTSipassOrderNumber",SqlDbType.VarChar),
               new SqlParameter("@UidNO",SqlDbType.VarChar),
               new SqlParameter("@Outresponse",SqlDbType.VarChar)
           };
        pp[0].Value = oldTSipassOrderNumber;
        pp[1].Value = NewTSipassOrderNumber;
        pp[2].Value = UidNO;
        pp[3].Value = "0";
        pp[3].Direction = ParameterDirection.Output;

        int valid = 0;
        valid = gen.GenericExecuteNonQuery("USP_UPD_OldOnlineOrderNo_BILLDESC", pp);
        return valid;
    }

    [WebMethod]
    public void UpdateAppealAttachemetnsCFE()
    {
        string UIDNO = "";
        DataSet dsallappealApplications = new DataSet();
        dsallappealApplications = GetAppealApplications("CFE");
        for (int d = 0; d < dsallappealApplications.Tables[0].Rows.Count; d++)
        {
            UIDNO = dsallappealApplications.Tables[0].Rows[d]["UIDNO"].ToString();
            ds = Gen.GetDepartmentonuid(UIDNO);
            if (ds != null)
            {
                if (ds.Tables[2].Rows.Count > 0)
                {
                    dt = ds.Tables[2];
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string deptid = dt.Rows[i]["intApprovalid"].ToString();
                    if (deptid == "31")//TSIIC APPEAL
                    {
                        DataSet dsdept = new DataSet();
                        string valueshmda = "";
                        string outputhmda = "";
                        string outpayhmda = "";
                        dsdept = Gen.getdepartmentdetailsonuid(UIDNO, deptid);
                        valueshmda = dsdept.GetXml();
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(valueshmda);
                        //string jsonText = JsonConvert.SerializeXmlNode(doc); // To convert JSON text contained in string json into an XML node XmlDocument doc = JsonConvert.DeserializeXmlNode(json);
                        if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                        {
                            //hmdapplication.
                            //System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

                            tsiicapplication = tsiicservice.create(valueshmda, "$$08@213");//000844/I1/U6/HMDA/25072017

                            DataSet dsdeptattachmentsTSIIC = new DataSet();
                            dsdeptattachmentsTSIIC = Gen.getattachmentdetailsonuid(UIDNO, deptid, tsiicapplication.FileNo);
                            //Kindly contact to administrator regarding add work flow.
                            string tsiicattachments = dsdeptattachmentsTSIIC.GetXml();
                            tsiicapplication = tsiicservice.SaveDocumentDataUsingXML(tsiicattachments, "$$08@213");//000838/I1/U6/HMDA/20072017//
                            if (tsiicapplication.FileNo != "" && tsiicapplication.FileNo != null)
                            {
                                //string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "R", tsiicapplication.FileNo, "Y");
                                int k = Gen.InsertDeptDateTracing("3", dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                            }
                            else
                            {
                                //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "R", tsiicapplication.ErrorMessage, "N");
                            }
                        }
                    }
                    if (deptid == "4")//NPDCL
                    {
                        try
                        {
                            string valueNPDCL = "";
                            string outputnpdcl = "";
                            string npdclattachments = "";
                            DataSet dsdept = new DataSet();
                            DataSet dsdeptattachments = new DataSet();
                            dsdept = Gen.getdepartmentdetailsonuid(UIDNO, deptid);
                            valueNPDCL = dsdept.GetXml();
                            outputnpdcl = tsnpdcl.insertAppealAgainstRejects(valueNPDCL);// tsnpdcl.insertTsipassUidDetaisls(valueNPDCL);
                            StringReader str = new StringReader(outputnpdcl);
                            DataSet dsout = new DataSet();
                            dsout.ReadXml(str);
                            if (dsout != null && dsout.Tables.Count > 0 && dsout.Tables[0].Rows.Count > 0)
                            {
                                if (dsout.Tables[0].Columns.Contains("status"))
                                {
                                    if (dsout.Tables[0].Rows[0]["status"].ToString() == "S")
                                    {
                                        string npdclout = dsout.Tables[0].Rows[0]["status"].ToString();
                                        Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "R", npdclout, "Y");
                                    }
                                    else
                                    {
                                        string npdclouterror = dsout.Tables[0].Rows[0]["status"].ToString();
                                        Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "R", npdclouterror, "N");
                                    }
                                }
                            }
                            //dsdeptattachments = Gen.getattachmentdetailsonuid(UIDNO, deptid, "");
                            //npdclattachments = dsdeptattachments.GetXml();
                            //outputnpdcl = tsnpdcl.insertAllAttachments(npdclattachments);
                            //StringReader str1 = new StringReader(outputnpdcl);
                            //DataSet dsout1 = new DataSet();
                            //dsout1.ReadXml(str1);
                            //if (dsout1 != null && dsout1.Tables.Count > 0 && dsout1.Tables[0].Rows.Count > 0)
                            //{
                            //    if (dsout1.Tables[0].Columns.Contains("status"))
                            //    {
                            //        if (dsout1.Tables[0].Rows[0]["status"].ToString() == "S")
                            //        {
                            //            string npdclsattachment = dsout1.Tables[0].Rows[0]["status"].ToString();
                            //            Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "R", npdclsattachment, "Y");
                            //            int k = Gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["deptId"].ToString(), dsdept.Tables[0].Rows[0]["questionniareId"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                            //        }
                            //        else
                            //        {
                            //            string npdclsattachmenterror = dsout1.Tables[0].Rows[0]["status"].ToString();
                            //            Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "R", npdclsattachmenterror, "N");
                            //        }
                            //    }
                            //}
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    if (deptid == "21" || deptid == "5" || deptid == "44")//FACTORIES
                    {
                        try
                        {
                            //FactoryService.plan factoryvo = new FactoryService.plan();
                            FactoryService.rawMaterial rawvo = new FactoryService.rawMaterial();
                            FactoryService.UpdateAppealAgainstRejection factoryvo = new FactoryService.UpdateAppealAgainstRejection();

                            string outputfactory = "";
                            string valuefactory = "";
                            DataSet dsdept = new DataSet();
                            dsdept = Gen.getdepartmentdetailsonuid(UIDNO, deptid);
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                            {
                                valuefactory = dsdept.GetXml();
                                //outputfactory = factory.insertIntoPlanApproval(factoryvo);
                                factoryvo.amountToBePaid = dsdept.Tables[0].Rows[0]["Approval_Fee"].ToString();
                                factoryvo.applicationID = dsdept.Tables[0].Rows[0]["UID_No"].ToString();
                                factoryvo.applicationStageID = dsdept.Tables[0].Rows[0]["intstageid"].ToString();
                                factoryvo.applicationStatus = "Pre-Scuitiny Pending"; //dsdept.Tables[0].Columns[""].ToString();

                                factoryvo.applicationSubmittedDate = dsdept.Tables[0].Rows[0]["UID_NOGenerateDate"].ToString();
                                factoryvo.bankAmount = dsdept.Tables[0].Rows[0]["Online_Amount"].ToString();
                                factoryvo.bankDate = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                factoryvo.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                factoryvo.challanNumber = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                factoryvo.communicationAddress = dsdept.Tables[0].Rows[0]["communicationAddress"].ToString();
                                factoryvo.entrepreneurID = dsdept.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                                factoryvo.factoryDistrictID = dsdept.Tables[0].Rows[0]["Land_intDistrictid"].ToString();
                                factoryvo.factoryLocality = dsdept.Tables[0].Rows[0]["Name_Gramapachayat"].ToString();
                                factoryvo.factoryDoorNumber = dsdept.Tables[0].Rows[0]["SurveyNo"].ToString();
                                factoryvo.factoryMandalID = dsdept.Tables[0].Rows[0]["Land_intMandalid"].ToString();
                                factoryvo.factoryName = dsdept.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();
                                factoryvo.factoryPinCode = dsdept.Tables[0].Rows[0]["Land_Pincode"].ToString();
                                factoryvo.factoryVillageID = dsdept.Tables[0].Rows[0]["Land_intVillageid"].ToString();
                                factoryvo.hazardousNature = dsdept.Tables[0].Rows[0]["TypeofFactory"].ToString();
                                factoryvo.installedHP = dsdept.Tables[0].Rows[0]["Connect_Load_B"].ToString();
                                factoryvo.mailID = dsdept.Tables[0].Rows[0]["Land_Email"].ToString();
                                factoryvo.mobileNumber = dsdept.Tables[0].Rows[0]["MobileNumber"].ToString();
                                factoryvo.paymentStatus = dsdept.Tables[0].Rows[0]["PaymentFlag"].ToString();
                                factoryvo.planReferenceNumber = "NA";//dsdept.Tables[0].Columns[""].ToString();
                                factoryvo.planType = dsdept.Tables[0].Rows[0]["ProposalFor"].ToString();
                                factoryvo.questionaireID = dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                                factoryvo.ssiType = "0";// dsdept.Tables[0].Columns[""].ToString();
                                factoryvo.systemIP = "0.0.0.0";// dsdept.Tables[0].Columns[""].ToString();
                                factoryvo.userID = dsdept.Tables[0].Rows[0]["CREATEDBY"].ToString();
                                factoryvo.workersToBeEmployedMen = dsdept.Tables[0].Rows[0]["DirectMale"].ToString();
                                factoryvo.workersToBeEmployedWomen = dsdept.Tables[0].Rows[0]["DirectFemale"].ToString();

                                FactoryService.rawMaterial[] lst = null;
                                if (dsdept.Tables[1].Rows.Count > 0)
                                {
                                    DataTable dtraw = new DataTable();
                                    dtraw = dsdept.Tables[1];
                                    lst = new FactoryService.rawMaterial[dtraw.Rows.Count];

                                    for (int k = 0; k < dtraw.Rows.Count; k++)
                                    {
                                        FactoryService.rawMaterial BBB = new FactoryService.rawMaterial();
                                        BBB.materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                                        lst[k] = BBB;
                                        //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                                        //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                                    }
                                    //rawvo.materialDescr
                                }

                                factoryvo.rawMaterials = lst;

                                FactoryService.productsOutput[] product = null;
                                if (dsdept.Tables[1].Rows.Count > 0)
                                {
                                    DataTable dtproduct = new DataTable();
                                    dtproduct = dsdept.Tables[2];
                                    product = new FactoryService.productsOutput[dtproduct.Rows.Count];

                                    for (int m = 0; m < dtproduct.Rows.Count; m++)
                                    {
                                        FactoryService.productsOutput productvo = new FactoryService.productsOutput();
                                        productvo.product = dtproduct.Rows[m]["Manf_ItemName"].ToString();
                                        productvo.output = dtproduct.Rows[m]["OUTPUT"].ToString();
                                        product[m] = productvo;
                                    }
                                }

                                factoryvo.productsOutputs = product;

                                FactoryService.saleLeaseDeed[] registrationdeed = null;
                                FactoryService.sitePlan[] siteplan = null;
                                FactoryService.buildingPlan[] buildingplan = null;
                                FactoryService.partnershipDeed[] partnershipdeed = null;
                                FactoryService.processFlowChart[] flowchat = null;
                                FactoryService.panAadharCard[] panaadhar = null;
                                //factory.insertIntoPlanApprovalCompleted factoryoutput = new FactoryService.insertIntoPlanApprovalCompletedEventHandler();


                                DataSet dsfactroy = new DataSet();
                                dsfactroy = Gen.getattachmentdetailsonuid(UIDNO, deptid, "");

                                if (dsfactroy != null && dsfactroy.Tables.Count > 0 && dsfactroy.Tables[0].Rows.Count > 0)
                                {
                                    ///Registration Deed////

                                    if (dsfactroy.Tables[0].Rows.Count > 0)
                                    {
                                        DataTable dtregistrationdeed = new DataTable();
                                        dtregistrationdeed = dsfactroy.Tables[0];
                                        registrationdeed = new FactoryService.saleLeaseDeed[dtregistrationdeed.Rows.Count];

                                        for (int n = 0; n < dtregistrationdeed.Rows.Count; n++)
                                        {
                                            FactoryService.saleLeaseDeed registrationdeedvo = new FactoryService.saleLeaseDeed();
                                            registrationdeedvo.documentName = dtregistrationdeed.Rows[n]["FileName"].ToString();
                                            registrationdeedvo.documentPath = dtregistrationdeed.Rows[n]["Filepath"].ToString();
                                            registrationdeed[n] = registrationdeedvo;
                                        }
                                    }
                                    if (dsfactroy.Tables[1].Rows.Count > 0)
                                    {
                                        DataTable dtsiteplan = new DataTable();
                                        dtsiteplan = dsfactroy.Tables[1];
                                        siteplan = new FactoryService.sitePlan[dtsiteplan.Rows.Count];

                                        for (int o = 0; o < dtsiteplan.Rows.Count; o++)
                                        {
                                            FactoryService.sitePlan siteplanvo = new FactoryService.sitePlan();
                                            siteplanvo.documentName = dtsiteplan.Rows[o]["FileName"].ToString();
                                            siteplanvo.documentPath = dtsiteplan.Rows[o]["Filepath"].ToString();
                                            siteplan[o] = siteplanvo;
                                        }
                                    }
                                    if (dsfactroy.Tables[2].Rows.Count > 0)
                                    {
                                        DataTable dtbuildingplan = new DataTable();
                                        dtbuildingplan = dsfactroy.Tables[2];
                                        buildingplan = new FactoryService.buildingPlan[dtbuildingplan.Rows.Count];

                                        for (int p = 0; p < dtbuildingplan.Rows.Count; p++)
                                        {
                                            FactoryService.buildingPlan buildingplanvo = new FactoryService.buildingPlan();
                                            buildingplanvo.documentName = dtbuildingplan.Rows[p]["FileName"].ToString();
                                            buildingplanvo.documentPath = dtbuildingplan.Rows[p]["Filepath"].ToString();
                                            buildingplan[p] = buildingplanvo;
                                        }
                                    }
                                    if (dsfactroy.Tables[3].Rows.Count > 0)
                                    {
                                        DataTable dtpartnershipdeed = new DataTable();
                                        dtpartnershipdeed = dsfactroy.Tables[3];
                                        partnershipdeed = new FactoryService.partnershipDeed[dtpartnershipdeed.Rows.Count];

                                        for (int n = 0; n < dtpartnershipdeed.Rows.Count; n++)
                                        {
                                            FactoryService.partnershipDeed partnershipdeedvo = new FactoryService.partnershipDeed();
                                            partnershipdeedvo.documentName = dtpartnershipdeed.Rows[n]["FileName"].ToString();
                                            partnershipdeedvo.documentPath = dtpartnershipdeed.Rows[n]["Filepath"].ToString();
                                            partnershipdeed[n] = partnershipdeedvo;
                                        }
                                    }
                                    if (dsfactroy.Tables[4].Rows.Count > 0)
                                    {
                                        DataTable dtflowchat = new DataTable();
                                        dtflowchat = dsfactroy.Tables[4];
                                        flowchat = new FactoryService.processFlowChart[dtflowchat.Rows.Count];

                                        for (int n = 0; n < dtflowchat.Rows.Count; n++)
                                        {
                                            FactoryService.processFlowChart flowchatvo = new FactoryService.processFlowChart();
                                            flowchatvo.documentName = dtflowchat.Rows[n]["FileName"].ToString();
                                            flowchatvo.documentPath = dtflowchat.Rows[n]["Filepath"].ToString();
                                            flowchat[n] = flowchatvo;
                                        }
                                    }
                                    if (dsfactroy.Tables[5].Rows.Count > 0)
                                    {
                                        DataTable dtpanaadhar = new DataTable();
                                        dtpanaadhar = dsfactroy.Tables[5];
                                        panaadhar = new FactoryService.panAadharCard[dtpanaadhar.Rows.Count];

                                        for (int n = 0; n < dtpanaadhar.Rows.Count; n++)
                                        {
                                            FactoryService.panAadharCard panaadharvo = new FactoryService.panAadharCard();
                                            panaadharvo.documentName = dtpanaadhar.Rows[n]["FileName"].ToString();
                                            panaadharvo.documentPath = dtpanaadhar.Rows[n]["Filepath"].ToString();
                                            panaadhar[n] = panaadharvo;
                                        }
                                    }
                                }
                                factoryvo.saleLeaseDeeds = registrationdeed;
                                factoryvo.sitePlans = siteplan;
                                factoryvo.buildingPlans = buildingplan;
                                factoryvo.partnershipDeeds = partnershipdeed;
                                factoryvo.processFlowCharts = flowchat;
                                factoryvo.panAadharCards = panaadhar;

                                string OUTPUT = factory.updateAppealAgainstRejection(factoryvo);
                                // factory.insertIntoPlanApprovalCompleted 
                                //factory.insertIntoPlanApproval(factoryvo);
                                // factory.insertIntoPlanApprovalCompleted = factory.insertIntoPlanApproval(factoryvo);
                                //factory.insertIntoPlanApprovalCompleted = factory.insertIntoPlanApproval(factoryvo);
                                if (OUTPUT == "SUCCESS")
                                {
                                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "R", OUTPUT, "Y");
                                    //Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "A", OUTPUT, "Y");
                                    int k = Gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                                }
                                else
                                {
                                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "R", OUTPUT, "N");
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }
        }
    }

    [WebMethod]
    public void UpdateAppealApplicationsCFO()
    {
        string UIDNO = "";
        DataSet dsallappealApplications = new DataSet();
        dsallappealApplications = GetAppealApplications("CFO");
        for (int d = 0; d < dsallappealApplications.Tables[0].Rows.Count; d++)
        {
            UIDNO = dsallappealApplications.Tables[0].Rows[d]["UIDNO"].ToString();

            ds = Gen.GetDepartmentonuidCFO(UIDNO);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[2].Rows.Count > 0)
                {
                    dt = ds.Tables[2];
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string deptid = dt.Rows[i]["intApprovalid"].ToString();

                    if (deptid == "15")//FACTORIES
                    {
                        try
                        {
                            //FactoryServiceCFO.grantLicense factoryvo = new FactoryServiceCFO.grantLicense();
                            //FactoryServiceCFO.rawMaterial rawvo = new FactoryService.rawMaterial();
                            FactoryServiceCFO.UpdateAppealAgainstRejectionCFO factoryvo = new FactoryServiceCFO.UpdateAppealAgainstRejectionCFO();

                            string outputfactory = "";
                            string valuefactory = "";
                            DataSet dsdept = new DataSet();
                            dsdept = Gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);
                            valuefactory = dsdept.GetXml();
                            //outputfactory = factory.insertIntoPlanApproval(factoryvo);


                            factoryvo.amountToBePaid = dsdept.Tables[0].Rows[0]["Approval_Fee"].ToString();
                            factoryvo.applicationID = dsdept.Tables[0].Rows[0]["UID_No"].ToString();
                            factoryvo.applicationStageID = dsdept.Tables[0].Rows[0]["intstageid"].ToString();
                            factoryvo.applicationStatus = "Pre-Scuitiny Pending"; //dsdept.Tables[0].Columns[""].ToString();
                            factoryvo.applicationSubmittedDate = dsdept.Tables[0].Rows[0]["UID_NOGenerateDate"].ToString();

                            //factoryvo.bankAmount = dsdept.Tables[0].Rows[0]["Online_Amount"].ToString();
                            //factoryvo.bankDate = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                            //factoryvo.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                            //factoryvo.challanNumber = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                            factoryvo.communicationAddress = dsdept.Tables[0].Rows[0]["communicationAddress"].ToString();
                            factoryvo.entrepreneurID = dsdept.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                            factoryvo.factoryDistrictID = dsdept.Tables[0].Rows[0]["Prop_intDistrictid"].ToString();
                            factoryvo.factoryDoorNumber = dsdept.Tables[0].Rows[0]["Door_No"].ToString();
                            factoryvo.factoryLocality = dsdept.Tables[0].Rows[0]["StreetName"].ToString();
                            factoryvo.factoryMandalID = dsdept.Tables[0].Rows[0]["Prop_intMandalid"].ToString();
                            factoryvo.factoryName = dsdept.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();
                            factoryvo.factoryOccupationDateByOccupier = dsdept.Tables[0].Rows[0]["Date_Occupation"].ToString();// 
                            factoryvo.factoryPinCode = dsdept.Tables[0].Rows[0]["Land_Pincode"].ToString();
                            factoryvo.factoryType = dsdept.Tables[0].Rows[0]["TypeofFactory"].ToString();
                            factoryvo.factoryVillageID = dsdept.Tables[0].Rows[0]["Prop_intVillageid"].ToString();
                            factoryvo.horsePowerToBeInstalledRegular = dsdept.Tables[0].Rows[0]["RegularHp"].ToString(); //dsdept.Tables[0].Rows[0][""].ToString();
                            factoryvo.horsePowerToBeInstalledRegularUnits = "HP";
                            factoryvo.horsePowerToBeInstalledStandby = dsdept.Tables[0].Rows[0]["StandbyHp"].ToString(); //dsdept.Tables[0].Rows[0][""].ToString();
                            factoryvo.horsePowerToBeInstalledStandbyUnits = "HP";
                            factoryvo.managerDistrict = dsdept.Tables[0].Rows[0]["Mangr_District"].ToString();
                            factoryvo.managerDoorNo = dsdept.Tables[0].Rows[0]["Mangr_DoorNo"].ToString();
                            factoryvo.managerFullName = dsdept.Tables[0].Rows[0]["Mangr_Full_Name"].ToString();
                            factoryvo.managerLocality = dsdept.Tables[0].Rows[0]["Mangr_Locality"].ToString();
                            factoryvo.managerMailId = dsdept.Tables[0].Rows[0]["Mangr_EmailId"].ToString();
                            factoryvo.managerMandal = dsdept.Tables[0].Rows[0]["Mangr_Mandal"].ToString();
                            factoryvo.managerMobileNumber = dsdept.Tables[0].Rows[0]["Mangr_MobileNo"].ToString();
                            factoryvo.managerPinCode = dsdept.Tables[0].Rows[0]["Mangr_PinCode"].ToString();
                            factoryvo.managerVillage = dsdept.Tables[0].Rows[0]["Mangr_Village"].ToString();
                            factoryvo.natureOfManufacturingProcessMain = dsdept.Tables[0].Rows[0]["MAIN"].ToString();// dsdept.Tables[0].Rows[0][""].ToString();
                            factoryvo.natureOfManufacturingProcessSecondary = dsdept.Tables[0].Rows[0]["SECONDARYITEM"].ToString();// dsdept.Tables[0].Rows[0][""].ToString();
                            factoryvo.noOfyearsSelectedToPayLicenceFee = dsdept.Tables[0].Rows[0]["LicenseYear"].ToString();
                            factoryvo.occupierDistrict = dsdept.Tables[0].Rows[0]["Occupier_District"].ToString();
                            factoryvo.occupierDoorNo = dsdept.Tables[0].Rows[0]["Occupier_DoorNo"].ToString();
                            factoryvo.occupierFullName = dsdept.Tables[0].Rows[0]["Occupier_Full_Name"].ToString();
                            factoryvo.occupierLocality = dsdept.Tables[0].Rows[0]["Occupier_Locality"].ToString();
                            factoryvo.occupierMailId = dsdept.Tables[0].Rows[0]["Occupier_EmailId"].ToString();
                            factoryvo.occupierMandal = dsdept.Tables[0].Rows[0]["Occupier_Mandal"].ToString();
                            factoryvo.occupierMobileNumber = dsdept.Tables[0].Rows[0]["Occupier_MobileNo"].ToString();
                            factoryvo.occupierOtherStatePostalAddress = "NA";//dsdept.Tables[0].Rows[0][""].ToString();
                            factoryvo.occupierPinCode = dsdept.Tables[0].Rows[0]["Occupier_PinCode"].ToString();
                            factoryvo.occupierPositionInFactory = "NA";//dsdept.Tables[0].Rows[0][""].ToString();
                            factoryvo.occupierState = "36";//dsdept.Tables[0].Rows[0][""].ToString();
                            factoryvo.occupierVillage = dsdept.Tables[0].Rows[0]["Occupier_Village"].ToString();
                            factoryvo.ownerDistrict = dsdept.Tables[0].Rows[0]["Owner_District"].ToString();
                            factoryvo.ownerDoorNo = dsdept.Tables[0].Rows[0]["Owner_DoorNo"].ToString();
                            factoryvo.ownerFullName = dsdept.Tables[0].Rows[0]["Owner_Full_Name"].ToString();
                            factoryvo.ownerLocality = dsdept.Tables[0].Rows[0]["Owner_Locality"].ToString();
                            factoryvo.ownerMailId = dsdept.Tables[0].Rows[0]["Owner_EmailId"].ToString();
                            factoryvo.ownerMandal = dsdept.Tables[0].Rows[0]["Owner_Mandal"].ToString();
                            factoryvo.ownerMobileNumber = dsdept.Tables[0].Rows[0]["Owner_MobileNo"].ToString();
                            factoryvo.ownerOtherStatePostalAddress = "NA";//dsdept.Tables[0].Rows[0][""].ToString();
                            factoryvo.ownerPinCode = dsdept.Tables[0].Rows[0]["Owner_PinCode"].ToString();
                            factoryvo.ownerState = "36";//dsdept.Tables[0].Rows[0][""].ToString();
                            factoryvo.ownerVillage = dsdept.Tables[0].Rows[0]["Owner_Village"].ToString();
                            factoryvo.paidAmount = dsdept.Tables[0].Rows[0]["Approval_Fee"].ToString();
                            factoryvo.paymentStatus = dsdept.Tables[0].Rows[0]["IsPayment"].ToString();
                            factoryvo.plansReferenceApprovedByChiefInspectorIfApplicable = dsdept.Tables[0].Rows[0]["Plans_Chief_Inspector_RefNo"].ToString();//Plans_Chief_Inspector_RefNo
                            factoryvo.questionaireID = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                            factoryvo.systemIP = "0.0.0.0";// dsdept.Tables[0].Columns[""].ToString();
                            factoryvo.userID = dsdept.Tables[0].Rows[0]["CREATEDBY"].ToString();
                            factoryvo.userMailID = dsdept.Tables[0].Rows[0]["Email"].ToString();
                            factoryvo.userMobileNumber = dsdept.Tables[0].Rows[0]["MobileNumber"].ToString();
                            factoryvo.workersToBeEmployedAdolescentsFemale = dsdept.Tables[0].Rows[0]["Adolescents_Female"].ToString();
                            factoryvo.workersToBeEmployedAdolescentsMale = dsdept.Tables[0].Rows[0]["Adolescents_Male"].ToString();
                            factoryvo.workersToBeEmployedAdultsFemale = dsdept.Tables[0].Rows[0]["AdultFemale"].ToString();
                            factoryvo.workersToBeEmployedAdultsMale = dsdept.Tables[0].Rows[0]["AdultMale"].ToString();
                            factoryvo.workersToBeEmployedChildrenFemale = dsdept.Tables[0].Rows[0]["Children_Female"].ToString();
                            factoryvo.workersToBeEmployedChildrenMale = dsdept.Tables[0].Rows[0]["Children_Male"].ToString();
                            factoryvo.isOldApplication = "Yes";

                            factoryvo.workersToBeEmployedAdolescentsTrans = dsdept.Tables[0].Rows[0]["AdolescentsTRANS"].ToString();
                            factoryvo.workersToBeEmployedAdultsTrans = dsdept.Tables[0].Rows[0]["AdultTRANS"].ToString();
                            factoryvo.workersToBeEmployedChildrenTrans = dsdept.Tables[0].Rows[0]["Children_TRANS"].ToString();

                            FactoryServiceCFO.aadharCardOrPanCard[] factoryaadhar = null;
                            FactoryServiceCFO.plansReferenceApprovedByDirectorOfFactories[] factoryrefapproved = null;
                            FactoryServiceCFO.latestListOfPartnersOrDirectors[] factorypartner = null;
                            FactoryServiceCFO.partnershipDeed[] factorypartnershipdeed = null;
                            FactoryServiceCFO.passPortSizePhotographWithSignature[] factoryphotosign = null;
                            FactoryServiceCFO.registeredSaleDeedOrLeaseDeed[] factoryregisteredsaledeed = null;

                            FactoryServiceCFO.factoryOccupierAndManagerPhotoIDProof[] factoryoccupierIdPrrof = null;
                            FactoryServiceCFO.inCaseChangeOfDirectorsFormNo32[] factorydirector = null;
                            FactoryServiceCFO.proposedInventoriesOfChemicalsUsed[] factoryinventories = null;

                            FactoryServiceCFO.machinery[] factmachineries = null;
                            FactoryServiceCFO.workersList[] factworkersList = null;
                            FactoryServiceCFO.selfComplianceChecklist[] factselfComplianceChecklist = null;

                            DataSet dsfactroy = new DataSet();
                            dsfactroy = Gen.getattachmentdetailsonuidCFO(UIDNO, deptid, "");

                            if (dsfactroy != null && dsfactroy.Tables.Count > 0)
                            {
                                ///Registration Deed////

                                if (dsfactroy.Tables[0].Rows.Count > 0)
                                {
                                    DataTable dtfactoryaadhar = new DataTable();
                                    dtfactoryaadhar = dsfactroy.Tables[0];
                                    factoryaadhar = new FactoryServiceCFO.aadharCardOrPanCard[dtfactoryaadhar.Rows.Count];

                                    for (int n = 0; n < dtfactoryaadhar.Rows.Count; n++)
                                    {
                                        FactoryServiceCFO.aadharCardOrPanCard factoryaadharvo = new FactoryServiceCFO.aadharCardOrPanCard();
                                        factoryaadharvo.documentName = dtfactoryaadhar.Rows[n]["FileName"].ToString();
                                        factoryaadharvo.documentPath = dtfactoryaadhar.Rows[n]["Filepath"].ToString();
                                        factoryaadhar[n] = factoryaadharvo;
                                    }
                                }
                                if (dsfactroy.Tables[1].Rows.Count > 0)
                                {
                                    DataTable dtfactoryrefapproved = new DataTable();
                                    dtfactoryrefapproved = dsfactroy.Tables[1];
                                    factoryrefapproved = new FactoryServiceCFO.plansReferenceApprovedByDirectorOfFactories[dtfactoryrefapproved.Rows.Count];

                                    for (int o = 0; o < dtfactoryrefapproved.Rows.Count; o++)
                                    {
                                        FactoryServiceCFO.plansReferenceApprovedByDirectorOfFactories factoryrefapprovedvo = new FactoryServiceCFO.plansReferenceApprovedByDirectorOfFactories();
                                        factoryrefapprovedvo.documentName = dtfactoryrefapproved.Rows[o]["FileName"].ToString();
                                        factoryrefapprovedvo.documentPath = dtfactoryrefapproved.Rows[o]["Filepath"].ToString();
                                        factoryrefapproved[o] = factoryrefapprovedvo;
                                    }
                                }
                                if (dsfactroy.Tables[2].Rows.Count > 0)
                                {
                                    DataTable dtfactorypartner = new DataTable();
                                    dtfactorypartner = dsfactroy.Tables[2];
                                    factorypartner = new FactoryServiceCFO.latestListOfPartnersOrDirectors[dtfactorypartner.Rows.Count];

                                    for (int p = 0; p < dtfactorypartner.Rows.Count; p++)
                                    {
                                        FactoryServiceCFO.latestListOfPartnersOrDirectors factorypartnervo = new FactoryServiceCFO.latestListOfPartnersOrDirectors();
                                        factorypartnervo.documentName = dtfactorypartner.Rows[p]["FileName"].ToString();
                                        factorypartnervo.documentPath = dtfactorypartner.Rows[p]["Filepath"].ToString();
                                        factorypartner[p] = factorypartnervo;
                                    }
                                }
                                if (dsfactroy.Tables[3].Rows.Count > 0)
                                {
                                    DataTable dtfactorypartnershipdeed = new DataTable();
                                    dtfactorypartnershipdeed = dsfactroy.Tables[3];
                                    factorypartnershipdeed = new FactoryServiceCFO.partnershipDeed[dtfactorypartnershipdeed.Rows.Count];

                                    for (int n = 0; n < dtfactorypartnershipdeed.Rows.Count; n++)
                                    {
                                        FactoryServiceCFO.partnershipDeed factorypartnershipdeedvo = new FactoryServiceCFO.partnershipDeed();
                                        factorypartnershipdeedvo.documentName = dtfactorypartnershipdeed.Rows[n]["FileName"].ToString();
                                        factorypartnershipdeedvo.documentPath = dtfactorypartnershipdeed.Rows[n]["Filepath"].ToString();
                                        factorypartnershipdeed[n] = factorypartnershipdeedvo;
                                    }
                                }
                                if (dsfactroy.Tables[4].Rows.Count > 0)
                                {
                                    DataTable dtfactoryphotosign = new DataTable();
                                    dtfactoryphotosign = dsfactroy.Tables[4];
                                    factoryphotosign = new FactoryServiceCFO.passPortSizePhotographWithSignature[dtfactoryphotosign.Rows.Count];

                                    for (int n = 0; n < dtfactoryphotosign.Rows.Count; n++)
                                    {
                                        FactoryServiceCFO.passPortSizePhotographWithSignature factoryphotosignvo = new FactoryServiceCFO.passPortSizePhotographWithSignature();
                                        factoryphotosignvo.documentName = dtfactoryphotosign.Rows[n]["FileName"].ToString();
                                        factoryphotosignvo.documentPath = dtfactoryphotosign.Rows[n]["Filepath"].ToString();
                                        factoryphotosign[n] = factoryphotosignvo;
                                    }
                                }
                                if (dsfactroy.Tables[5].Rows.Count > 0)
                                {
                                    DataTable dtfactoryregisteredsaledeed = new DataTable();
                                    dtfactoryregisteredsaledeed = dsfactroy.Tables[5];
                                    factoryregisteredsaledeed = new FactoryServiceCFO.registeredSaleDeedOrLeaseDeed[dtfactoryregisteredsaledeed.Rows.Count];

                                    for (int n = 0; n < dtfactoryregisteredsaledeed.Rows.Count; n++)
                                    {
                                        FactoryServiceCFO.registeredSaleDeedOrLeaseDeed factoryregisteredsaledeedvo = new FactoryServiceCFO.registeredSaleDeedOrLeaseDeed();
                                        factoryregisteredsaledeedvo.documentName = dtfactoryregisteredsaledeed.Rows[n]["FileName"].ToString();
                                        factoryregisteredsaledeedvo.documentPath = dtfactoryregisteredsaledeed.Rows[n]["Filepath"].ToString();
                                        factoryregisteredsaledeed[n] = factoryregisteredsaledeedvo;
                                    }
                                }
                                if (dsfactroy.Tables[8].Rows.Count > 0)
                                {
                                    DataTable dtmachinery = new DataTable();
                                    dtmachinery = dsfactroy.Tables[8];
                                    factmachineries = new FactoryServiceCFO.machinery[dtmachinery.Rows.Count];

                                    for (int n = 0; n < dtmachinery.Rows.Count; n++)
                                    {
                                        FactoryServiceCFO.machinery factoryrmachineryvo = new FactoryServiceCFO.machinery();
                                        factoryrmachineryvo.documentName = dtmachinery.Rows[n]["FileName"].ToString();
                                        factoryrmachineryvo.documentPath = dtmachinery.Rows[n]["Filepath"].ToString();
                                        factmachineries[n] = factoryrmachineryvo;
                                    }
                                }

                                if (dsfactroy.Tables[9].Rows.Count > 0)
                                {
                                    DataTable dtselfcompchklist = new DataTable();
                                    dtselfcompchklist = dsfactroy.Tables[9];
                                    factselfComplianceChecklist = new FactoryServiceCFO.selfComplianceChecklist[dtselfcompchklist.Rows.Count];

                                    for (int n = 0; n < dtselfcompchklist.Rows.Count; n++)
                                    {
                                        FactoryServiceCFO.selfComplianceChecklist factselfComplianceChecklistvo = new FactoryServiceCFO.selfComplianceChecklist();
                                        factselfComplianceChecklistvo.documentName = dtselfcompchklist.Rows[n]["FileName"].ToString();
                                        factselfComplianceChecklistvo.documentPath = dtselfcompchklist.Rows[n]["Filepath"].ToString();
                                        factselfComplianceChecklist[n] = factselfComplianceChecklistvo;
                                    }
                                }

                                if (dsfactroy.Tables[10].Rows.Count > 0)
                                {
                                    DataTable dtworkerslist = new DataTable();
                                    dtworkerslist = dsfactroy.Tables[10];
                                    factworkersList = new FactoryServiceCFO.workersList[dtworkerslist.Rows.Count];

                                    for (int n = 0; n < dtworkerslist.Rows.Count; n++)
                                    {
                                        FactoryServiceCFO.workersList factworkersListvo = new FactoryServiceCFO.workersList();
                                        factworkersListvo.documentName = dtworkerslist.Rows[n]["FileName"].ToString();
                                        factworkersListvo.documentPath = dtworkerslist.Rows[n]["Filepath"].ToString();
                                        factworkersList[n] = factworkersListvo;
                                    }
                                }
                            }


                            factoryvo.aadharCardOrPanCardAttachments = factoryaadhar;
                            factoryvo.plansReferenceApprovedByDirectorOfFactoriesAttachments = factoryrefapproved;
                            factoryvo.latestListOfPartnersOrDirectorsAttachments = factorypartner;
                            factoryvo.partnershipDeedAttachments = factorypartnershipdeed;
                            factoryvo.passPortSizePhotographWithSignatureAttachments = factoryphotosign;
                            factoryvo.registeredSaleDeedOrLeaseDeedAttachments = factoryregisteredsaledeed;
                            factoryvo.factoryOccupierAndManagerPhotoIDProofAttachments = factoryoccupierIdPrrof;
                            factoryvo.inCaseChangeOfDirectorsFormNo32Attachments = factorydirector;
                            factoryvo.proposedInventoriesOfChemicalsUsedAttachments = factoryinventories;

                            factoryvo.machineryAttachments = factmachineries;
                            factoryvo.selfComplianceChecklistAttachments = factselfComplianceChecklist;
                            factoryvo.workersListAttachments = factworkersList;

                            string OUTPUT = factorycfo.updateAppealAgainstRejectionCFO(factoryvo);

                            if (OUTPUT == "SUCCESS")
                            {

                                Gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "R", OUTPUT, "Y");
                                //Gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "A", OUTPUT, "Y");
                                int k = Gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                            }
                            else
                            {
                                Gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "R", OUTPUT, "N");
                            }
                        }
                        catch (Exception ex)
                        {


                        }
                    }
                }
            }
        }

    }
    public DataSet GetAppealApplications(string Appstype)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@APPTYPE",SqlDbType.VarChar),
           };
        pp[0].Value = Appstype;
        Dsnew = gen.GenericFillDs("USP_GET_ALLAPPEALAPPLICATIONS", pp);
        return Dsnew;
    }
    
}
