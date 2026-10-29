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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CFOWebServices
/// </summary>

public class CFOWebServices
{
    #region Global Variables
    WebserviceVO webvo = new WebserviceVO();

    General gen = new General();
    WebClient wc = new WebClient();

    //BoilerService.TSBoilerServiceImplService Boiler = new BoilerService.TSBoilerServiceImplService();
    //BoilerServiceTest.TSBoilerServiceImplService Boiler = new BoilerServiceTest.TSBoilerServiceImplService();
    LabourCFOService.TSLabourServiceImplService labourserviceCfo = new LabourCFOService.TSLabourServiceImplService();
    // LabourService.TSLabourServiceImplService labourservice = new LabourService.TSLabourServiceImplService();
    
    FireServiceCFO.Service1 firecfo = new FireServiceCFO.Service1();
    FactoryServiceCFO.TSFactoryServiceImplService factorycfo = new FactoryServiceCFO.TSFactoryServiceImplService();
    CEIGService.InstallationAppServiceImplService ceifcfo = new CEIGService.InstallationAppServiceImplService();
    //BoilerQueryResponseService.TSBoilerServiceImplService BoilerQuery = new BoilerQueryResponseService.TSBoilerServiceImplService();
    //BoilerQueryResponseService.planQR boilervo = new BoilerQueryResponseService.planQR();
    BoilerQueryResponseService.TSBoilerServiceImplService BoilerQuery = new BoilerQueryResponseService.TSBoilerServiceImplService();
    BoilerQueryResponseService.planQR boilervo = new BoilerQueryResponseService.planQR();
    FireServiceCFO.Service1 fireservicecfo = new FireServiceCFO.Service1();
    FactoryQueryResponseServiceCFO.TSFactoryServiceImplService factoryquery = new FactoryQueryResponseServiceCFO.TSFactoryServiceImplService();
    //CEIGService.InstallationAppServiceImplService ceifcfo = new CEIGService.InstallationAppServiceImplService();
    //CEIGService.querReply ceigqueryvo = new CEIGService.querReply();
    LabourQueryResponseCFO.TSLabourServiceImplService labourqueryserviceCfo = new LabourQueryResponseCFO.TSLabourServiceImplService();
    BoilerService.TSBoilerServiceImplService Boiler = new BoilerService.TSBoilerServiceImplService();
    CEIGCFOService.ApplicationServiceImplService ceigcfo = new CEIGCFOService.ApplicationServiceImplService();
    CEIGCFOService.queryReply ceigqueryvo = new CEIGCFOService.queryReply();
    TSIICService.tsipass tsiicservice = new TSIICService.tsipass();
    TSIICService.ApplicationFormResponse responcetsiic = new TSIICService.ApplicationFormResponse();
    HMDAService.tsipass hmdaservice = new HMDAService.tsipass();
    HMDAService.ApplicationFormResponse responce = new HMDAService.ApplicationFormResponse();
    #endregion

    public CFOWebServices()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void webservicecfo(string UIDNO)
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        try
        {
            //if (Session["objUsrDtl"] != null)
            //{
            //if (!IsPostBack)
            //{
            //string UIDNO = Request.QueryString["UIDNO"].ToString();
            // UIDNO = "LRG020000822208CFO";// "S0ur@bh@@!@#";// "MED005000318511CFO"; //"SML018004917311CFO";// "LRG005000817440CFO";//"SML00500064419";//"SML00500064419";
            ds = gen.GetDepartmentonuidCFO(UIDNO);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string deptid = dt.Rows[i]["intApprovalid"].ToString();
                    if (deptid == "73")
                    {
                        DataSet dsdept = new DataSet();
                        dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);
                        string valueshmwssb = dsdept.GetXml();

                        HMDAService.SanctionBuildingDetailsResponse[] sList = null; //new List<HMDAServiceTest.SanctionBuildingDetailsResponse>();
                        HMDAService.SanctionBuildingDetailsResponse SBel = new HMDAService.SanctionBuildingDetailsResponse();
                        responce.ProposalDetailsResponse = new HMDAService.ProposalDetailsResponse();
                        responce.FileNo = dsdept.Tables[0].Rows[0]["HMDAFileNo"].ToString();
                        responce.DepartmentId = Convert.ToInt32("11");
                        responce.ProposalDetailsResponse.Occupancy_Applied_for = HMDAService.enOccupancyApplied.Full;
                        responce.ProposalDetailsResponse.RegistrationNo = dsdept.Tables[0].Rows[0]["ArchitectLicenseno"].ToString();
                        responce.ProposalDetailsResponse.Work_Commenced_Date = DateTime.Now;
                        responce.ProposalDetailsResponse.Work_Completion_Date = DateTime.Now;
                        responce.ProposalDetailsResponse.Duedate_for_completion_of_the_building = DateTime.Now;
                        responce.TS_Client = (HMDAService.enCorporation.HMDA);
                        if (dsdept.Tables[1].Rows.Count > 0)
                        {
                            DataTable SanctionBuildingDetails = new DataTable();
                            SanctionBuildingDetails = dsdept.Tables[1];
                            sList = new HMDAService.SanctionBuildingDetailsResponse[SanctionBuildingDetails.Rows.Count];

                            for (int n = 0; n < SanctionBuildingDetails.Rows.Count; n++)
                            {
                                HMDAService.SanctionBuildingDetailsResponse sanctionvo = new HMDAService.SanctionBuildingDetailsResponse();
                                sanctionvo.BuildingId = Convert.ToInt64(SanctionBuildingDetails.Rows[n]["BuildingID"].ToString());
                                sanctionvo.BuildingName = SanctionBuildingDetails.Rows[n]["BuildingName"].ToString();
                                if (SanctionBuildingDetails.Rows[n]["PlotNo"].ToString() != "")
                                {
                                    sanctionvo.PlotId = Convert.ToInt64(SanctionBuildingDetails.Rows[n]["PlotNo"].ToString());
                                }
                                sList[n] = sanctionvo;
                            }
                            //steamvo.requiredDocumentsSPL = reqdoc;
                            responce.SanctionBuildingList = sList;
                        }//016022/I1/U6/HMDA/05102018

                        responce = hmdaservice.ApplyforOccupancy(responce, "$$08@213");//020460/GHT/I1/OC/U6/HMDA/02032019;//020461/SKP/I1/OC/U6/HMDA/07032019
                        DataSet dsdeptattachmentsHMDA = new DataSet();
                        dsdeptattachmentsHMDA = gen.getattachmentdetailsonuidCFO(UIDNO, deptid, responce.FileNo);
                        string hmdaattachments = dsdeptattachmentsHMDA.GetXml();
                        responce = hmdaservice.SaveDocumentDataUsingXML(hmdaattachments, "$$08@213");//000838/I1/U6/HMDA/20072017


                        if (responce.FileNo != "" && responce.FileNo != null)
                        {
                            //string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                            gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", responce.FileNo, "Y");
                            int k = gen.InsertDeptDateTracingCFO("11", dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFo", deptid);
                        }
                        else
                        {
                            //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                            gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", responce.ErrorMessage, "N");
                        }

                    }


                    if (deptid == "74")
                    {
                        DataSet dsdept = new DataSet();
                        dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);
                        string valuetsiic = dsdept.GetXml();

                        TSIICService.SanctionBuildingDetailsResponse[] sList = null; //new List<HMDAServiceTest.SanctionBuildingDetailsResponse>();
                        TSIICService.SanctionBuildingDetailsResponse SBel = new TSIICService.SanctionBuildingDetailsResponse();
                        responcetsiic.ProposalDetailsResponse = new TSIICService.ProposalDetailsResponse();
                        responcetsiic.FileNo = dsdept.Tables[0].Rows[0]["HMDAFileNo"].ToString();
                        responcetsiic.DepartmentId = Convert.ToInt32("3");
                        responcetsiic.ProposalDetailsResponse.Occupancy_Applied_for = TSIICService.enOccupancyApplied.Full;
                        responcetsiic.ProposalDetailsResponse.RegistrationNo = dsdept.Tables[0].Rows[0]["ArchitectLicenseno"].ToString();
                        responcetsiic.ProposalDetailsResponse.Work_Commenced_Date = DateTime.Now;
                        responcetsiic.ProposalDetailsResponse.Work_Completion_Date = DateTime.Now;
                        responcetsiic.ProposalDetailsResponse.Duedate_for_completion_of_the_building = DateTime.Now;
                        responcetsiic.TS_Client = (TSIICService.enCorporation.HMDA);

                        if (dsdept.Tables[1].Rows.Count > 0)
                        {
                            DataTable SanctionBuildingDetails = new DataTable();
                            SanctionBuildingDetails = dsdept.Tables[1];
                            sList = new TSIICService.SanctionBuildingDetailsResponse[SanctionBuildingDetails.Rows.Count];

                            for (int n = 0; n < SanctionBuildingDetails.Rows.Count; n++)
                            {
                                TSIICService.SanctionBuildingDetailsResponse sanctionvo = new TSIICService.SanctionBuildingDetailsResponse();
                                sanctionvo.BuildingId = Convert.ToInt64(SanctionBuildingDetails.Rows[n]["BuildingID"].ToString());
                                sanctionvo.BuildingName = SanctionBuildingDetails.Rows[n]["BuildingName"].ToString();
                                if (SanctionBuildingDetails.Rows[n]["PlotNo"].ToString() != "")
                                {
                                    sanctionvo.PlotId = Convert.ToInt64(SanctionBuildingDetails.Rows[n]["PlotNo"].ToString());
                                }
                                sList[n] = sanctionvo;
                            }
                            //steamvo.requiredDocumentsSPL = reqdoc;
                            responcetsiic.SanctionBuildingList = sList;
                        }//016022/I1/U6/HMDA/05102018

                        responcetsiic = tsiicservice.ApplyforOccupancy(responcetsiic, "$$08@213");//020460/GHT/I1/OC/U6/HMDA/02032019;//020461/SKP/I1/OC/U6/HMDA/07032019
                        if (responcetsiic.Error.ToString().ToLower().Contains("file submitted"))
                        {
                            DataSet dsdeptattachmentsHMDA = new DataSet();
                        dsdeptattachmentsHMDA = gen.getattachmentdetailsonuidCFO(UIDNO, deptid, responcetsiic.FileNo);
                        string tsiicattachments = dsdeptattachmentsHMDA.GetXml();
                        tsiicattachments = tsiicattachments.Replace("&amp;", "&");
                        responcetsiic = tsiicservice.SaveDocumentDataUsingXML(tsiicattachments, "$$08@213");//000838/I1/U6/HMDA/20072017


                        if (responcetsiic.FileNo != "" && responcetsiic.FileNo != null && responcetsiic.Error == "File Attached successfully")
                        {
                            //string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                            gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", responcetsiic.FileNo, "Y");
                            int k = gen.InsertDeptDateTracingCFO("11", dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFo", deptid);
                        }
                        else
                        {
                            //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                            gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", responcetsiic.ErrorMessage, "N");
                        }
                        }

                    }
                    if (deptid == "67")
                    {
                        DataSet dsdept = new DataSet();
                        dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);
                        string valueshmwssb = dsdept.GetXml();
                        //string UIDNO = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
                        if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                        {
                            BoilerService.regOfSteamPipeline steamvo = new BoilerService.regOfSteamPipeline();
                            steamvo.applicationId = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
                            steamvo.boiler_rating = dsdept.Tables[0].Rows[0]["Boiler_ration"].ToString();
                            steamvo.boiler_used_for = dsdept.Tables[0].Rows[0]["Boiler_User_for"].ToString();
                            steamvo.created_by = Convert.ToInt32(dsdept.Tables[0].Rows[0]["created_by"].ToString());
                            steamvo.district = dsdept.Tables[0].Rows[0]["Prop_intDistrictid"].ToString();
                            steamvo.door_survey_no = dsdept.Tables[0].Rows[0]["SurveyNo"].ToString();
                            steamvo.emailId = dsdept.Tables[0].Rows[0]["Email"].ToString();
                            steamvo.enterpreneur_id = Convert.ToInt32(dsdept.Tables[0].Rows[0]["intCFEEnterpid"].ToString());
                            steamvo.erector_class = dsdept.Tables[0].Rows[0]["ErectorClass"].ToString();
                            //steamvo.erector_license_copy = dsdept.Tables[0].Rows[0][""].ToString();
                            steamvo.erector_name = dsdept.Tables[0].Rows[0]["Name_of_Erector"].ToString();
                            steamvo.industryName = dsdept.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();
                            steamvo.length_spl_above = dsdept.Tables[0].Rows[0]["Tot_Lenght_Steam_PipeLine_Above"].ToString();
                            steamvo.length_spl_upto = dsdept.Tables[0].Rows[0]["Tot_Lenght_Steam_PipeLine_Upto"].ToString();
                            steamvo.locality = dsdept.Tables[0].Rows[0]["Name_Gramapachayat"].ToString();
                            steamvo.makersNo = dsdept.Tables[0].Rows[0]["Reg_No_Boiler"].ToString();
                            steamvo.mandal = dsdept.Tables[0].Rows[0]["Prop_intMandalid"].ToString();
                            steamvo.max_pressure = dsdept.Tables[0].Rows[0]["Allowed_Max_Presure"].ToString();
                            steamvo.mobileNo = dsdept.Tables[0].Rows[0]["MobileNumber"].ToString();
                            steamvo.noOf_vessels_connected = dsdept.Tables[0].Rows[0]["NumberofVesselsconnected"].ToString();
                            steamvo.pincode = dsdept.Tables[0].Rows[0]["Land_Pincode"].ToString();
                            steamvo.quessionaire_id = Convert.ToInt32(dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString());
                            steamvo.registrationNo = dsdept.Tables[0].Rows[0]["Reg_No_Boiler"].ToString();
                            //steamvo.requiredDocumentsSPL = dsdept.Tables[0].Rows[0][""].ToString();
                            steamvo.spl_total_length = dsdept.Tables[0].Rows[0]["Tot_Lenght_Steam_PipeLine"].ToString();
                            //steamvo.splLayoutDrawingDocuments = dsdept.Tables[0].Rows[0][""].ToString();
                            steamvo.state = dsdept.Tables[0].Rows[0]["State_Erector"].ToString();
                            steamvo.system_ip = "0:0:0:0";//dsdept.Tables[0].Rows[0][""].ToString();
                            steamvo.user_serial_no = Convert.ToInt32(dsdept.Tables[0].Rows[0]["user_serial_no"].ToString());
                            steamvo.village = dsdept.Tables[0].Rows[0]["Prop_intVillageid"].ToString();

                            //BoilerServiceTest.splLayoutDrawingDocuments spldoc = new BoilerServiceTest.splLayoutDrawingDocuments();
                            BoilerService.splLayoutDrawingDocuments[] spldoc = null;
                            BoilerService.requiredDocumentsSPL[] reqdoc = null;
                            DataSet dsBoiler = new DataSet();
                            dsBoiler = gen.getattachmentdetailsonuidCFO(UIDNO, deptid, "");
                            string attcvalueshmwssb = dsBoiler.GetXml();
                            if (dsBoiler != null && dsBoiler.Tables.Count > 0 && dsBoiler.Tables[0].Rows.Count > 0)
                            {
                                ///Registration Deed////

                                if (dsBoiler.Tables[0].Rows.Count > 0)
                                {
                                    DataTable spldocdocuments = new DataTable();
                                    spldocdocuments = dsBoiler.Tables[0];
                                    spldoc = new BoilerService.splLayoutDrawingDocuments[spldocdocuments.Rows.Count];

                                    for (int n = 0; n < spldocdocuments.Rows.Count; n++)
                                    {
                                        BoilerService.splLayoutDrawingDocuments spldocvo = new BoilerService.splLayoutDrawingDocuments();
                                        spldocvo.documentName = spldocdocuments.Rows[n]["FileName"].ToString();
                                        spldocvo.documentPath = spldocdocuments.Rows[n]["Filepath"].ToString();
                                        spldoc[n] = spldocvo;
                                    }
                                    steamvo.splLayoutDrawingDocuments = spldoc;

                                }
                                if (dsBoiler.Tables[1].Rows.Count > 0)
                                {
                                    DataTable reqdocdocuments = new DataTable();
                                    reqdocdocuments = dsBoiler.Tables[1];
                                    reqdoc = new BoilerService.requiredDocumentsSPL[reqdocdocuments.Rows.Count];

                                    for (int n = 0; n < reqdocdocuments.Rows.Count; n++)
                                    {
                                        BoilerService.requiredDocumentsSPL reqdocvo = new BoilerService.requiredDocumentsSPL();
                                        reqdocvo.documentName = reqdocdocuments.Rows[n]["FileName"].ToString();
                                        reqdocvo.documentPath = reqdocdocuments.Rows[n]["Filepath"].ToString();
                                        reqdoc[n] = reqdocvo;
                                    }
                                    steamvo.requiredDocumentsSPL = reqdoc;
                                }
                                if (dsBoiler.Tables[2].Rows.Count > 0)
                                {
                                    steamvo.erector_license_copy = dsBoiler.Tables[2].Rows[0]["Filepath"].ToString();
                                }
                            }
                            string boilerout = Boiler.registrationofSteamPipeLine(steamvo);
                            if (boilerout == "SUCCESS")
                            {

                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", boilerout, "Y");
                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "A", boilerout, "N");
                                //int k = gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["intDeptid"].ToString(), dsdept.Tables[0].Rows[0]["quessionaire_id"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                                int k = gen.InsertDeptDateTracingCFO(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                            }
                            else
                            {
                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", boilerout, "N");
                            }
                        }
                    }

                    if (deptid == "68")
                    {
                        string intApprovalid = dt.Rows[i]["intApprovalid"].ToString();
                        string intQuessionaireid = dt.Rows[i]["intQuessionaireid"].ToString();
                        string intDeptid = dt.Rows[i]["intDeptid"].ToString();

                        DataSet dsdept = new DataSet();
                        dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);
                        //string UIDNO = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
                        if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                        {
                            string filepath = dsdept.Tables[0].Rows[0]["queryRespDocPath"].ToString();
                            //string remarks = dsdept.Tables[0].Rows[0]["queryRespText"].ToString();
                            //BoilerQueryResponseServiceTest.TSBoilerServiceImplService Boiler = new BoilerQueryResponseServiceTest.TSBoilerServiceImplService();
                            //BoilerQueryResponseServiceTest.planQR boilervo = new BoilerQueryResponseServiceTest.planQR();
                            //FireServiceCFO.Service1 fireservicecfo = new FireServiceCFO.Service1();
                            //FactoryQueryResponseServiceCFO.TSFactoryServiceImplService factoryquery = new FactoryQueryResponseServiceCFO.TSFactoryServiceImplService();

                            BoilerService.TSBoilerServiceImplService boilererection = new BoilerService.TSBoilerServiceImplService();
                            BoilerService.steampipelineErrectionCompletion boilererectionvo = new BoilerService.steampipelineErrectionCompletion();


                            //if (intApprovalid == "27")//BOILERS
                            //{
                            ////boilererectionvo.
                            boilererectionvo.applicationId = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
                            boilererectionvo.enterpreneur_id = Convert.ToInt32(dsdept.Tables[0].Rows[0]["entrepreneurId"].ToString());
                            boilererectionvo.system_ip = "0.0.0.0";
                            boilererectionvo.userID = Convert.ToInt32(dsdept.Tables[0].Rows[0]["userID"].ToString());
                            boilererectionvo.quessionaire_id = Convert.ToInt32(dsdept.Tables[0].Rows[0]["questionniareId"].ToString());

                            BoilerService.errectiondocuments[] lst = null;
                            if (dsdept.Tables[0].Rows.Count > 0)
                            {
                                DataTable dtraw = new DataTable();
                                dtraw = dsdept.Tables[0];
                                lst = new BoilerService.errectiondocuments[dtraw.Rows.Count];

                                for (int k = 0; k < dtraw.Rows.Count; k++)
                                {
                                    BoilerService.errectiondocuments boilererrectiondocumentsvo = new BoilerService.errectiondocuments();
                                    boilererrectiondocumentsvo.documentName = dtraw.Rows[k]["queryRespDocName"].ToString();
                                    boilererrectiondocumentsvo.documentPath = dtraw.Rows[k]["queryRespDocPath"].ToString();
                                    lst[k] = boilererrectiondocumentsvo;
                                    //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                                    //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                                }
                            }
                            boilererectionvo.errdocuments = lst;
                            // boilererectionvo.steamtestrequestdocument = lst;
                            //boilererectionvo.errdocuments = lst;
                            string boilerout = boilererection.insertIntoSPLErrectionCompletionReport(boilererectionvo);
                            if (boilerout == "SUCCESS")
                            {
                                gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "C", boilerout, "Y");
                                try
                                {
                                    int k = gen.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, UIDNO, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFO", intApprovalid);
                                }
                                catch (Exception ex)
                                {

                                }
                            }
                            else
                            {
                                gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "C", boilerout, "N");
                            }
                        }
                    }

                    if (deptid == "64")
                    {
                        string intApprovalid = dt.Rows[i]["intApprovalid"].ToString();
                        string intQuessionaireid = dt.Rows[i]["intQuessionaireid"].ToString();
                        string intDeptid = dt.Rows[i]["intDeptid"].ToString();

                        DataSet dsdept = new DataSet();
                        dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);
                        //string UIDNO = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
                        if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                        {
                            string filepath = dsdept.Tables[0].Rows[0]["queryRespDocPath"].ToString();
                            //string remarks = dsdept.Tables[0].Rows[0]["queryRespText"].ToString();
                            //BoilerQueryResponseServiceTest.TSBoilerServiceImplService Boiler = new BoilerQueryResponseServiceTest.TSBoilerServiceImplService();
                            // BoilerQueryResponseServiceTest.planQR boilervo = new BoilerQueryResponseServiceTest.planQR();
                            FireServiceCFO.Service1 fireservicecfo = new FireServiceCFO.Service1();
                            FactoryQueryResponseServiceCFO.TSFactoryServiceImplService factoryquery = new FactoryQueryResponseServiceCFO.TSFactoryServiceImplService();

                            BoilerService.TSBoilerServiceImplService boilererection = new BoilerService.TSBoilerServiceImplService();
                            BoilerService.requestForSteamTest boilererectionvo = new BoilerService.requestForSteamTest();


                            //if (intApprovalid == "27")//BOILERS
                            //{
                            boilererectionvo.applicationId = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
                            boilererectionvo.enterpreneur_id = Convert.ToInt32(dsdept.Tables[0].Rows[0]["entrepreneurId"].ToString());
                            boilererectionvo.system_ip = "0.0.0.0";
                            boilererectionvo.userID = dsdept.Tables[0].Rows[0]["userID"].ToString();
                            boilererectionvo.quessionaire_id = Convert.ToInt32(dsdept.Tables[0].Rows[0]["questionniareId"].ToString());

                            BoilerService.steamtestrequestdocument[] lst = null;
                            if (dsdept.Tables[0].Rows.Count > 0)
                            {
                                DataTable dtraw = new DataTable();
                                dtraw = dsdept.Tables[0];
                                lst = new BoilerService.steamtestrequestdocument[dtraw.Rows.Count];

                                for (int k = 0; k < dtraw.Rows.Count; k++)
                                {
                                    BoilerService.steamtestrequestdocument boilererrectiondocumentsvo = new BoilerService.steamtestrequestdocument();
                                    boilererrectiondocumentsvo.documentName = dtraw.Rows[k]["queryRespDocName"].ToString();
                                    boilererrectiondocumentsvo.documentPath = dtraw.Rows[k]["queryRespDocPath"].ToString();
                                    lst[k] = boilererrectiondocumentsvo;
                                    //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                                    //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                                }
                            }
                            boilererectionvo.steamtestrequestdocument = lst;
                            //boilererectionvo.errdocuments = lst;
                            string boilerout = boilererection.insertIntoRequestforSteamTest(boilererectionvo);
                            if (boilerout == "SUCCESS")
                            {
                                gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "C", boilerout, "Y");
                                try
                                {
                                    int k = gen.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", intApprovalid);
                                }
                                catch (Exception ex)
                                {

                                }
                            }
                            else
                            {
                                gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "C", boilerout, "N");
                            }
                        }
                    }

                    if (deptid == "63")
                    {
                        string intApprovalid = dt.Rows[i]["intApprovalid"].ToString();
                        string intQuessionaireid = dt.Rows[i]["intQuessionaireid"].ToString();
                        string intDeptid = dt.Rows[i]["intDeptid"].ToString();

                        DataSet dsdept = new DataSet();
                        dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);
                        //string UIDNO = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
                        if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                        {
                            string filepath = dsdept.Tables[0].Rows[0]["queryRespDocPath"].ToString();
                            //string remarks = dsdept.Tables[0].Rows[0]["queryRespText"].ToString();
                            //BoilerQueryResponseServiceTest.TSBoilerServiceImplService Boiler = new BoilerQueryResponseServiceTest.TSBoilerServiceImplService();
                            //BoilerQueryResponseServiceTest.planQR boilervo = new BoilerQueryResponseServiceTest.planQR();
                            FireServiceCFO.Service1 fireservicecfo = new FireServiceCFO.Service1();
                            FactoryQueryResponseServiceCFO.TSFactoryServiceImplService factoryquery = new FactoryQueryResponseServiceCFO.TSFactoryServiceImplService();

                            BoilerService.TSBoilerServiceImplService boilererection = new BoilerService.TSBoilerServiceImplService();
                            BoilerService.errectionCompletion boilererectionvo = new BoilerService.errectionCompletion();


                            //if (intApprovalid == "27")//BOILERS
                            //{
                            boilererectionvo.applicationId = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
                            boilererectionvo.enterpreneur_id = Convert.ToInt32(dsdept.Tables[0].Rows[0]["entrepreneurId"].ToString());
                            boilererectionvo.system_ip = "0.0.0.0";
                            boilererectionvo.userID = dsdept.Tables[0].Rows[0]["userID"].ToString();

                            BoilerService.errectiondocuments[] lst = null;
                            if (dsdept.Tables[0].Rows.Count > 0)
                            {
                                DataTable dtraw = new DataTable();
                                dtraw = dsdept.Tables[0];
                                lst = new BoilerService.errectiondocuments[dtraw.Rows.Count];

                                for (int k = 0; k < dtraw.Rows.Count; k++)
                                {
                                    BoilerService.errectiondocuments boilererrectiondocumentsvo = new BoilerService.errectiondocuments();
                                    boilererrectiondocumentsvo.documentName = dtraw.Rows[k]["queryRespDocName"].ToString();
                                    boilererrectiondocumentsvo.documentPath = dtraw.Rows[k]["queryRespDocPath"].ToString();
                                    lst[k] = boilererrectiondocumentsvo;
                                    //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                                    //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                                }
                            }
                            boilererectionvo.errdocuments = lst;
                            string boilerout = boilererection.insertIntoErrectionCompletionReport(boilererectionvo);
                            if (boilerout == "SUCCESS")
                            {
                                gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "C", boilerout, "Y");
                                try
                                {
                                    int k = gen.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", intApprovalid);
                                }
                                catch (Exception ex)
                                {

                                }
                            }
                            else
                            {
                                gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "C", boilerout, "N");
                            }
                        }
                    }


                    if (deptid == "14")
                    {
                        DataSet dsdept = new DataSet();

                        dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);
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
                            string QUESTIONNAIREID = dsdept.Tables[0].Rows[0]["QUESTIONNAIREID"].ToString();

                            //string WEBSERVICE_URL = "http://164.100.163.19/TLWSC/updateFee?cafUniqueNo=" + cafUniqueNo + "&indApplicationNo=" + indApplication + "&transactionId=" + transactionId + "&amount=" + amount + "&bankName=" + bankName + "&transactionStatus=" + transactionStatus + "&paymentType=" + paymentType + "&additionalPayment=" + additionalPayment + "";


                            string WEBSERVICE_URL = "https://tsocmms.nic.in/TLWS/updateFee?cafUniqueNo=" + cafUniqueNo + "&transactionId=" + transactionId + "&amount=" + amount + "&bankName=" + bankName + "&transactionStatus=" + transactionStatus + "&paymentType=" + paymentType + "&indApplicationNo=" + indApplication + "&additionalPayment=" + additionalPayment + "";


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
                                            if (jsonResponse.Contains("Fee submitted successfully"))
                                            {
                                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", jsonResponse, "Y");
                                                int k = gen.InsertDeptDateTracingCFO("1", QUESTIONNAIREID, UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", "14");
                                            }
                                            else
                                            {
                                                //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", jsonResponse, "N");
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
                    if (deptid == "16")
                    {
                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = //SecurityProtocolType.Tls12;
                        SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                        CEIGCFOService.installationApplication ceifvo = new CEIGCFOService.installationApplication();
                        CEIGCFOService.installationApplication ceifvocfo = new CEIGCFOService.installationApplication();
                        CEIGCFOService.inspectionAbSwitchList[] abSwitchList = null;
                        CEIGCFOService.inspectionCircuitBreakerList[] circuitBreakerList = null;
                        CEIGCFOService.inspectionLoadPartList[] equipmentList = null;
                        CEIGCFOService.inspectionGeneratorsList[] generatorsList = null;
                        CEIGCFOService.inspectionLightningArrestorList[] lightningArrestorList = null;
                        CEIGCFOService.inspectionPrecommissionList[] precommissionList = null;
                        CEIGCFOService.inspectionTransformerCertList[] transformerCertList = null;
                        CEIGCFOService.inspectionTransmissionLinesList[] transmissionLinesList = null;

                        DataSet dsdept = new DataSet();
                        dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);
                        string valueshmwssb = dsdept.GetXml();
                        if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                        {
                            //ceifvocfo.abSwitchList = "";
                            ceifvocfo.amount = Convert.ToDouble(dsdept.Tables[0].Rows[0]["Online_Amount"].ToString());
                            ceifvocfo.bank = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                            //ceifvocfo.circuitBreakerList = "";
                            ceifvocfo.entrepreneurID = dsdept.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                            //ceifvocfo.equipmentList = "";
                            //ceifvocfo.generatorsList = "";
                            //ceifvocfo.lightningArrestorList = "";
                            //ceifvocfo.load_certificate = dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                            ceifvocfo.payment_date = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                            //ceifvocfo.precommissionList = "";
                            ceifvocfo.questionaireID = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                            ceifvocfo.transaction_id = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                            ceifvocfo.transaction_ref = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                            //ceifvocfo.transformerCertList = "";
                            //ceifvocfo.transmissionLinesList = "";
                            ceifvocfo.UID = dsdept.Tables[0].Rows[0]["UID_No"].ToString();
                            ceifvocfo.fileNumber = dsdept.Tables[0].Rows[0]["filenumber"].ToString();


                            DataTable dtinspectionAbSwitchList = new DataTable();
                            dtinspectionAbSwitchList = dsdept.Tables[1];
                            abSwitchList = new CEIGCFOService.inspectionAbSwitchList[dtinspectionAbSwitchList.Rows.Count];

                            for (int n = 0; n < dtinspectionAbSwitchList.Rows.Count; n++)
                            {
                                CEIGCFOService.inspectionAbSwitchList inspectionAbSwitchListvo = new CEIGCFOService.inspectionAbSwitchList();
                                inspectionAbSwitchListvo.capacity = dtinspectionAbSwitchList.Rows[n]["CapacityA"].ToString();
                                inspectionAbSwitchListvo.location = dtinspectionAbSwitchList.Rows[n]["Location"].ToString();
                                inspectionAbSwitchListvo.switch_cert = dtinspectionAbSwitchList.Rows[n]["TestUpload"].ToString();
                                inspectionAbSwitchListvo.switch_make = dtinspectionAbSwitchList.Rows[n]["Make"].ToString();
                                inspectionAbSwitchListvo.switch_slno = dtinspectionAbSwitchList.Rows[n]["SerialNo"].ToString();
                                inspectionAbSwitchListvo.voltage = dtinspectionAbSwitchList.Rows[n]["VoltageV"].ToString();
                                inspectionAbSwitchListvo.with_or_without = dtinspectionAbSwitchList.Rows[n]["WithorWithoutEarthSwitch"].ToString();
                                abSwitchList[n] = inspectionAbSwitchListvo;
                            }
                            ceifvocfo.abSwitchList = abSwitchList;
                            //}
                        }

                        if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[2].Rows.Count > 0)
                        {
                            DataTable dtcircuitBreakerList = new DataTable();
                            dtcircuitBreakerList = dsdept.Tables[2];
                            circuitBreakerList = new CEIGCFOService.inspectionCircuitBreakerList[dtcircuitBreakerList.Rows.Count];

                            for (int n = 0; n < dtcircuitBreakerList.Rows.Count; n++)
                            {
                                CEIGCFOService.inspectionCircuitBreakerList circuitBreakerListvo = new CEIGCFOService.inspectionCircuitBreakerList();
                                circuitBreakerListvo.capacity = dtcircuitBreakerList.Rows[n]["CapacityA"].ToString();
                                circuitBreakerListvo.cb_serial_no = dtcircuitBreakerList.Rows[n]["CBSerialNo"].ToString();
                                circuitBreakerListvo.certificate_path = dtcircuitBreakerList.Rows[n]["TestCertificateUpload"].ToString();
                                circuitBreakerListvo.isc_ka = dtcircuitBreakerList.Rows[n]["ISCKA"].ToString();
                                circuitBreakerListvo.location_name = dtcircuitBreakerList.Rows[n]["Location"].ToString();
                                circuitBreakerListvo.make = dtcircuitBreakerList.Rows[n]["Make"].ToString();
                                circuitBreakerList[n] = circuitBreakerListvo;
                            }
                            ceifvocfo.circuitBreakerList = circuitBreakerList;
                            //}
                        }

                        if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[3].Rows.Count > 0)
                        {
                            DataTable dtequipmentList = new DataTable();
                            dtequipmentList = dsdept.Tables[3];
                            equipmentList = new CEIGCFOService.inspectionLoadPartList[dtequipmentList.Rows.Count];

                            for (int n = 0; n < dtequipmentList.Rows.Count; n++)
                            {
                                CEIGCFOService.inspectionLoadPartList equipmentListvo = new CEIGCFOService.inspectionLoadPartList();
                                equipmentListvo.capacity_hp = dtequipmentList.Rows[n]["CapacityinHP"].ToString();
                                equipmentListvo.capacity_kw = dtequipmentList.Rows[n]["CapacityinKV"].ToString();
                                equipmentListvo.certificate_path = dtequipmentList.Rows[n]["LoadUpload"].ToString();
                                equipmentListvo.equipment_name = dtequipmentList.Rows[n]["EquipmentName"].ToString();
                                equipmentListvo.make = dtequipmentList.Rows[n]["Make"].ToString();
                                equipmentListvo.serial_no = dtequipmentList.Rows[n]["SerialNo"].ToString();

                                equipmentList[n] = equipmentListvo;
                            }
                            ceifvocfo.equipmentList = equipmentList;
                            //}
                        }
                        if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[4].Rows.Count > 0)
                        {
                            DataTable dtgeneratorsList = new DataTable();
                            dtgeneratorsList = dsdept.Tables[4];
                            generatorsList = new CEIGCFOService.inspectionGeneratorsList[dtgeneratorsList.Rows.Count];

                            for (int n = 0; n < dtgeneratorsList.Rows.Count; n++)
                            {
                                CEIGCFOService.inspectionGeneratorsList generatorsListvo = new CEIGCFOService.inspectionGeneratorsList();
                                generatorsListvo.fuel_source = dtgeneratorsList.Rows[n]["FuelSource"].ToString();
                                generatorsListvo.fuel_type = dtgeneratorsList.Rows[n]["FuelType"].ToString();
                                generatorsListvo.generator_capacity = dtgeneratorsList.Rows[n]["CapacityA"].ToString();
                                generatorsListvo.generator_cert = dtgeneratorsList.Rows[n]["FuelTestUpload"].ToString();
                                generatorsListvo.generator_location = dtgeneratorsList.Rows[n]["Location"].ToString();
                                generatorsListvo.generator_make = dtgeneratorsList.Rows[n]["Make"].ToString();
                                generatorsListvo.generator_slno = dtgeneratorsList.Rows[n]["SerialNo"].ToString();
                                generatorsListvo.heat_rate = dtgeneratorsList.Rows[n]["HeatRateDetails"].ToString();
                                generatorsListvo.mercury = dtgeneratorsList.Rows[n]["Mercury"].ToString();
                                generatorsListvo.sox_no_emission = dtgeneratorsList.Rows[n]["SoxNoxEmission"].ToString();
                                generatorsList[n] = generatorsListvo;
                            }
                            ceifvocfo.generatorsList = generatorsList;
                            //}
                        }
                        if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[5].Rows.Count > 0)
                        {
                            DataTable dtlightningArrestorList = new DataTable();
                            dtlightningArrestorList = dsdept.Tables[5];
                            lightningArrestorList = new CEIGCFOService.inspectionLightningArrestorList[dtlightningArrestorList.Rows.Count];

                            for (int n = 0; n < dtlightningArrestorList.Rows.Count; n++)
                            {
                                CEIGCFOService.inspectionLightningArrestorList lightningArrestorListvo = new CEIGCFOService.inspectionLightningArrestorList();
                                lightningArrestorListvo.arrestor_capacity = dtlightningArrestorList.Rows[n]["CapacityA"].ToString();
                                lightningArrestorListvo.arrestor_cert = dtlightningArrestorList.Rows[n]["TestUpload"].ToString();
                                lightningArrestorListvo.arrestor_location = dtlightningArrestorList.Rows[n]["Location"].ToString();
                                lightningArrestorListvo.arrestor_make = dtlightningArrestorList.Rows[n]["Make"].ToString();
                                lightningArrestorListvo.arrestor_slno = dtlightningArrestorList.Rows[n]["SerialNo"].ToString();
                                lightningArrestorListvo.arrestor_voltage = dtlightningArrestorList.Rows[n]["VoltageV"].ToString();
                                lightningArrestorList[n] = lightningArrestorListvo;
                            }
                            ceifvocfo.lightningArrestorList = lightningArrestorList;
                            //}
                        }
                        if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[6].Rows.Count > 0)
                        {
                            DataTable dtprecommissionList = new DataTable();
                            dtprecommissionList = dsdept.Tables[6];
                            precommissionList = new CEIGCFOService.inspectionPrecommissionList[dtprecommissionList.Rows.Count];

                            for (int n = 0; n < dtprecommissionList.Rows.Count; n++)
                            {
                                CEIGCFOService.inspectionPrecommissionList precommissionListvo = new CEIGCFOService.inspectionPrecommissionList();
                                precommissionListvo.equipment = dtprecommissionList.Rows[n]["Equipment"].ToString();
                                precommissionListvo.equipment_desc = dtprecommissionList.Rows[n]["Description"].ToString();
                                precommissionListvo.generator_cert = dtprecommissionList.Rows[n]["CommissioningUpload"].ToString();
                                precommissionList[n] = precommissionListvo;
                            }
                            ceifvocfo.precommissionList = precommissionList;
                            //}
                        }
                        if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[7].Rows.Count > 0)
                        {
                            DataTable dttransformerCertList = new DataTable();
                            dttransformerCertList = dsdept.Tables[7];
                            transformerCertList = new CEIGCFOService.inspectionTransformerCertList[dttransformerCertList.Rows.Count];

                            for (int n = 0; n < dttransformerCertList.Rows.Count; n++)
                            {
                                CEIGCFOService.inspectionTransformerCertList transformerCertListvo = new CEIGCFOService.inspectionTransformerCertList();
                                transformerCertListvo.transformer_capacity = dttransformerCertList.Rows[n]["Capacity"].ToString();
                                transformerCertListvo.transformer_cert_path = dttransformerCertList.Rows[n]["TransformerTestUpload"].ToString();
                                transformerCertListvo.transformer_make = dttransformerCertList.Rows[n]["Make"].ToString();
                                transformerCertListvo.transformer_name = dttransformerCertList.Rows[n]["Transformer"].ToString();
                                transformerCertListvo.transformer_oil_path = dttransformerCertList.Rows[n]["OilTestUpload"].ToString();
                                transformerCertListvo.transformer_slno = dttransformerCertList.Rows[n]["SerialNo"].ToString();
                                transformerCertListvo.transformer_type_id = Convert.ToDouble("0.1");// Convert.ToDouble(dttransformerCertList.Rows[n]["TypeofTransformer"].ToString());
                                transformerCertListvo.transformer_voltage = dttransformerCertList.Rows[n]["VoltageHVLV"].ToString();
                                transformerCertList[n] = transformerCertListvo;
                            }
                            ceifvocfo.transformerCertList = transformerCertList;
                            //}
                        }
                        if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[8].Rows.Count > 0)
                        {
                            DataTable dttransmissionLinesList = new DataTable();
                            dttransmissionLinesList = dsdept.Tables[8];
                            transmissionLinesList = new CEIGCFOService.inspectionTransmissionLinesList[dttransmissionLinesList.Rows.Count];

                            for (int n = 0; n < dttransmissionLinesList.Rows.Count; n++)
                            {
                                CEIGCFOService.inspectionTransmissionLinesList transmissionLinesListvo = new CEIGCFOService.inspectionTransmissionLinesList();
                                transmissionLinesListvo.transmission_cert = dttransmissionLinesList.Rows[n]["TransmissionUpload"].ToString();
                                transmissionLinesListvo.transmission_desc = dttransmissionLinesList.Rows[n]["Description"].ToString();
                                transmissionLinesList[n] = transmissionLinesListvo;
                            }
                            ceifvocfo.transmissionLinesList = transmissionLinesList;
                            //}
                        }

                        DataSet dsBoiler = new DataSet();
                        dsBoiler = gen.getattachmentdetailsonuidCFO(UIDNO, "16", "");
                        string attcvalueshmwssb = dsBoiler.GetXml();
                        if (dsBoiler != null && dsBoiler.Tables.Count > 0 && dsBoiler.Tables[0].Rows.Count > 0)
                        {
                            ceifvocfo.work_comm_repi_path = dsBoiler.Tables[0].Rows[0]["Filepath"].ToString();
                            ceifvocfo.work_comm_repii_path = dsBoiler.Tables[0].Rows[0]["Filepath"].ToString();
                            ceifvocfo.work_comp_rep_path = dsBoiler.Tables[0].Rows[0]["Filepath"].ToString();
                        }

                        string ceigout = ceigcfo.insertIntoInstallationApplication(ceifvocfo); //ceig.in(ceifvo);
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
                    if (deptid == "27") // Boilers
                    {
                        try
                        {
                            //BoilerService.plan boilervo = new BoilerService.plan();
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
                                boilervo.application_stage = Convert.ToInt32(dsdept.Tables[0].Rows[0]["application_stage"].ToString());
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
                                boilervo.created_by = Convert.ToInt32(dsdept.Tables[0].Rows[0]["created_by"].ToString());
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
                                boilervo.enterpreneur_id = Convert.ToInt32(dsdept.Tables[0].Rows[0]["enterpreneur_id"].ToString());
                                boilervo.erector_class = dsdept.Tables[0].Rows[0]["erector_class"].ToString();
                                boilervo.erector_name = dsdept.Tables[0].Rows[0]["erector_name"].ToString();
                                boilervo.hoa = dsdept.Tables[0].Rows[0]["hoa"].ToString();
                                //boilervo.inspection_officer = Convert.ToInt16(dsdept.Tables[0].Rows[0]["inspection_officer"].ToString());
                                boilervo.inspector_authority_flag = Convert.ToInt32(dsdept.Tables[0].Rows[0]["inspector_authority_flag"].ToString());
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
                                boilervo.present_status_id = Convert.ToInt32(dsdept.Tables[0].Rows[0]["present_status_id"].ToString());
                                boilervo.quessionaire_id = Convert.ToInt32(dsdept.Tables[0].Rows[0]["quessionaire_id"].ToString());
                                boilervo.remittersname = dsdept.Tables[0].Rows[0]["remittersname"].ToString();
                                boilervo.required_documents = dsdept.Tables[0].Rows[0]["required_documents"].ToString();
                                boilervo.system_ip = dsdept.Tables[0].Rows[0]["system_ip"].ToString();
                                boilervo.trydate = dsdept.Tables[0].Rows[0]["trydate"].ToString();
                                boilervo.type_of_boiler = dsdept.Tables[0].Rows[0]["type_of_boiler"].ToString();
                                boilervo.upload_form5 = dsdept.Tables[0].Rows[0]["upload_form5"].ToString();
                                boilervo.user_serial_no = Convert.ToInt32(dsdept.Tables[0].Rows[0]["user_serial_no"].ToString());
                                boilervo.village = dsdept.Tables[0].Rows[0]["village"].ToString();
                                boilervo.year = dsdept.Tables[0].Rows[0]["year"].ToString();

                                //BoilerService.anexuredocuments[] anexuredocuments = null;
                                //BoilerService.cbbdocuments[] cbbdocument = null;
                                //BoilerService.designdocuments[] designdocument = null;
                                //BoilerService.formdocuments[] form = null;
                                //BoilerService.otherdocuments[] Otherdoc = null;


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
                                    int k = gen.InsertDeptDateTracingCFO(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
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
                            ServicePointManager.Expect100Continue = true;
                            ServicePointManager.SecurityProtocol = //SecurityProtocolType.Tls12;
                            SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
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
                                //int k = gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["QuestionnaireId"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                                int k = gen.InsertDeptDateTracingCFO(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
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
                                    shopactobjnew.address_proof = "";
                                    shopactobjnew.authorise_letter_proof = "";
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
                                    DataSet dsdeptattachmentslabour = new DataSet();
                                    dsdeptattachmentslabour = gen.getattachmentdetailsonuidCFO(UIDNO, "52", "");
                                    if (dsdeptattachmentslabour != null && dsdeptattachmentslabour.Tables.Count > 0 && dsdeptattachmentslabour.Tables[0].Rows.Count > 0)
                                    {
                                        ///PAN CARD////

                                        if (dsdeptattachmentslabour.Tables[0].Rows.Count > 0)
                                        {
                                            shopactobjnew.employees_proof = dsdeptattachmentslabour.Tables[0].Rows[0]["Filepath"].ToString();
                                        }
                                        if (dsdeptattachmentslabour.Tables[1].Rows.Count > 0)
                                        {
                                            shopactobjnew.address_proof = dsdeptattachmentslabour.Tables[1].Rows[0]["Filepath"].ToString();
                                        }
                                        if (dsdeptattachmentslabour.Tables[2].Rows.Count > 0)
                                        {
                                            shopactobjnew.authorise_letter_proof = dsdeptattachmentslabour.Tables[2].Rows[0]["Filepath"].ToString();
                                        }
                                        if (dsdeptattachmentslabour.Tables[3].Rows.Count > 0)
                                        {
                                            shopactobjnew.certificate_incorporation_proof = dsdeptattachmentslabour.Tables[3].Rows[0]["Filepath"].ToString();
                                        }
                                    }

                                    labouract.shopRegistrationActData = shopactobjnew;
                                    labourout = labourserviceCfo.actSelected(labouract);

                                    // labourout = labourserviceCfo.actSelected(labouract);
                                    if (labourout.status == "SUCCESS")
                                    {
                                        string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                        gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", labouroutmsg, "Y");
                                        //int k = gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
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
                                        //int k = gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
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
                                        //int k = gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
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

                    if (deptid == "74") // TSIIC ADDITIO    NAL PAYMENT
                    {
                        try
                        {
                            DataSet dsdept = new DataSet();
                            dsdept = gen.getAdditionalPaymentDetailsCFO(UIDNO, deptid);
                            string dtcppayment = dsdept.GetXml();
                            responcetsiic = tsiicservice.DCPayment(dtcppayment, "$$08@213");

                            if (responcetsiic.ResponseStatus != 0 && responcetsiic.ResponseStatus != 0)
                            {
                                //string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", responcetsiic.FileNo, "Y");
                                //int k = gen.InsertDeptDateTracing(deptid, dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE");
                            }
                            else
                            {
                                //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", responcetsiic.ErrorMessage, "N");
                            }

                        }
                        catch (Exception ex)
                        {

                        }

                    }

                    if (deptid == "14")
                    {
                        DataSet dsdept = new DataSet();

                        dsdept = gen.getAdditionalPaymentDetailsCFO(UIDNO, deptid);
                        if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                        {
                            string cafUniqueNo = dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                            string transactionId = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                            string amount = dsdept.Tables[0].Rows[0]["Approval_Fee"].ToString();
                            string bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                            string transactionStatus = "S";
                            string paymentType = "NB";
                            string indApplication = dsdept.Tables[0].Rows[0]["NICApplicationno"].ToString();
                            string additionalPayment = "T";

                            //string WEBSERVICE_URL = "http://164.100.163.19/TLWSC/updateFee?cafUniqueNo=" + cafUniqueNo + "&indApplicationNo=" + indApplication + "&transactionId=" + transactionId + "&amount=" + amount + "&bankName=" + bankName + "&transactionStatus=" + transactionStatus + "&paymentType=" + paymentType + "&additionalPayment=" + additionalPayment + "";

                            string WEBSERVICE_URL1 = "https://tsocmms.nic.in/TLWS/updateCl?cafUniqueNo=" + cafUniqueNo + "&indApplicationNo=" + indApplication + "&remark=" + "AdditionalAmountSubmitted" + "&urlSingle=" + "";

                            try
                            {
                                var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL1);
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
                                            if (jsonResponse.Contains("submitted successfully"))
                                            {
                                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", jsonResponse, "Y");
                                            }
                                            else
                                            {
                                                //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", jsonResponse, "N");
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                System.Diagnostics.Debug.WriteLine(ex.ToString());
                            }


                            string WEBSERVICE_URL = "https://tsocmms.nic.in/TLWS/updateFee?cafUniqueNo=" + cafUniqueNo + "&transactionId=" + transactionId + "&amount=" + amount + "&bankName=" + bankName + "&transactionStatus=" + transactionStatus + "&paymentType=" + paymentType + "&indApplicationNo=" + indApplication + "&additionalPayment=" + additionalPayment + "";


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
                                            if (jsonResponse.Contains("Fee submitted successfully"))
                                            {
                                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", jsonResponse, "Y");
                                            }
                                            else
                                            {
                                                //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", jsonResponse, "Y");
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
                    if (deptid == "16")
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
                                CEIGCFOService.payment ceigpaymentvo = new CEIGCFOService.payment();
                                ceigpaymentvo.amount = Convert.ToDouble(dsdept.Tables[0].Rows[0]["Online_Amount"].ToString());
                                ceigpaymentvo.bank = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                ceigpaymentvo.payment_date = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                ceigpaymentvo.tx_ref = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                //ceigpaymentvo.applicationID = dsdept.Tables[0].Rows[0]["Created_by"].ToString();
                                //ceigpaymentvo.bank_id = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                //ceigpaymentvo.branch_name = "";
                                //ceigpaymentvo.challan_copy = "";
                                //ceigpaymentvo.challan_date = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                //ceigpaymentvo.challan_no = dsdept.Tables[0].Rows[0]["challano"].ToString();
                                ceigpaymentvo.entrepreneurID = dsdept.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                                //ceigpaymentvo.payment_type = dsdept.Tables[0].Rows[0]["paymentmode"].ToString();
                                ceigpaymentvo.questionaireID = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                                ceigpaymentvo.reply_document = "";
                                ceigpaymentvo.reply_remarks = "";
                                // ceigpaymentvo.system_ip = "1.1.1.1"; ;
                                ceigpaymentvo.tx_id = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                ceigpaymentvo.UID = dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                string outceigpayment = ceigcfo.updateInstallationPayment(ceigpaymentvo);

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
                            ServicePointManager.Expect100Continue = true;
                            ServicePointManager.SecurityProtocol = //SecurityProtocolType.Tls12;
                            SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
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
                    if (deptid == "67") //BOILER
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
                                BoilerService.splRegPayment Boilerpaymentvo = new BoilerService.splRegPayment();
                                Boilerpaymentvo.applicationID = dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                Boilerpaymentvo.bankAmount = dsdept.Tables[0].Rows[0]["Online_Amount"].ToString();
                                Boilerpaymentvo.bankDate = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                Boilerpaymentvo.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                Boilerpaymentvo.bankstatus = dsdept.Tables[0].Rows[0]["PaymentFlag"].ToString();
                                Boilerpaymentvo.banktransid = "NA";
                                Boilerpaymentvo.challanNumber = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                Boilerpaymentvo.ddocode = "NA";
                                //Boilerpaymentvo.department_transaction_id = "NA";
                                Boilerpaymentvo.hoa = "NA";
                                Boilerpaymentvo.remittersname = "NA";
                                Boilerpaymentvo.systemIP = "0:0:0:0";
                                Boilerpaymentvo.trydate = "NA";
                                Boilerpaymentvo.userID = dsdept.Tables[0].Rows[0]["Created_by"].ToString();

                                string OutBoiler = Boiler.insertIntoSPLRegPayment(Boilerpaymentvo);
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

                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[1].Rows.Count > 0)
                                {
                                    Boilerpaymentvo.harithaNidhiAmount = Convert.ToDouble(dsdept.Tables[1].Rows[0]["Online_Amount"].ToString());
                                    Boilerpaymentvo.harithaNidhibankStatus = dsdept.Tables[1].Rows[0]["PaymentFlag"].ToString();
                                    Boilerpaymentvo.harithaNidhibanktransid = dsdept.Tables[1].Rows[0]["TransactionNO"].ToString();
                                    Boilerpaymentvo.harithaNidhiddocode = "NA";// dsdept.Tables[1].Rows[0]["TransactionDate"].ToString();
                                    Boilerpaymentvo.harithaNidhihoa = "NA";// dsdept.Tables[1].Rows[0]["TransactionDate"].ToString();
                                    Boilerpaymentvo.harithaNidhiremittersname = dsdept.Tables[1].Rows[0]["BankName"].ToString();
                                    Boilerpaymentvo.harithaNidhitrydate = dsdept.Tables[1].Rows[0]["TransactionDate"].ToString();
                                }

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
            if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
            {
                //DataSet ds = new DataSet();
                //DataTable dt = new DataTable();
                if (ds.Tables[2].Rows.Count > 0)
                {
                    dt = ds.Tables[2];
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string deptid = dt.Rows[i]["intApprovalid"].ToString();
                    if (deptid == "74")
                    {
                        string TSIICValue = "";
                        DataSet dsdept = new DataSet();
                        dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);

                        TSIICValue = dsdept.GetXml();
                        TSIICService.SanctionBuildingDetailsResponse[] sList = null; //new List<HMDAServiceTest.SanctionBuildingDetailsResponse>();
                        TSIICService.SanctionBuildingDetailsResponse SBel = new TSIICService.SanctionBuildingDetailsResponse();
                        responcetsiic.ProposalDetailsResponse = new TSIICService.ProposalDetailsResponse();
                        responcetsiic.FileNo = dsdept.Tables[0].Rows[0]["HMDAFileNo"].ToString();
                        responcetsiic.DepartmentId = Convert.ToInt32("3");
                        responcetsiic.ProposalDetailsResponse.Occupancy_Applied_for = TSIICService.enOccupancyApplied.Full;
                        responcetsiic.ProposalDetailsResponse.RegistrationNo = dsdept.Tables[0].Rows[0]["ArchitectLicenseno"].ToString();
                        responcetsiic.ProposalDetailsResponse.Work_Commenced_Date = DateTime.Now;
                        responcetsiic.ProposalDetailsResponse.Work_Completion_Date = DateTime.Now;
                        responcetsiic.ProposalDetailsResponse.Duedate_for_completion_of_the_building = DateTime.Now;
                        responcetsiic.TS_Client = (TSIICService.enCorporation.HMDA);

                        if (dsdept.Tables[1].Rows.Count > 0)
                        {
                            DataTable SanctionBuildingDetails = new DataTable();
                            SanctionBuildingDetails = dsdept.Tables[1];
                            sList = new TSIICService.SanctionBuildingDetailsResponse[SanctionBuildingDetails.Rows.Count];

                            for (int n = 0; n < SanctionBuildingDetails.Rows.Count; n++)
                            {
                                TSIICService.SanctionBuildingDetailsResponse sanctionvo = new TSIICService.SanctionBuildingDetailsResponse();
                                sanctionvo.BuildingId = Convert.ToInt64(SanctionBuildingDetails.Rows[n]["BuildingID"].ToString());
                                sanctionvo.BuildingName = SanctionBuildingDetails.Rows[n]["BuildingName"].ToString();
                                if (SanctionBuildingDetails.Rows[n]["PlotNo"].ToString() != "")
                                {
                                    sanctionvo.PlotId = Convert.ToInt64(SanctionBuildingDetails.Rows[n]["PlotNo"].ToString());
                                }
                                sList[n] = sanctionvo;
                            }
                            //steamvo.requiredDocumentsSPL = reqdoc;
                            responcetsiic.SanctionBuildingList = sList;
                        }//016022/I1/U6/HMDA/05102018

                        responcetsiic = tsiicservice.ResubmitOccupancy(responcetsiic, "$$08@213");//020460/GHT/I1/OC/U6/HMDA/02032019;//020461/SKP/I1/OC/U6/HMDA/07032019
                        DataSet dsdeptattachmentsHMDA = new DataSet();
                        dsdeptattachmentsHMDA = gen.getattachmentdetailsonuidCFO(UIDNO, deptid, responcetsiic.FileNo);
                        string tsiicattachments = dsdeptattachmentsHMDA.GetXml();
                        responcetsiic = tsiicservice.SaveDocumentDataUsingXML(tsiicattachments, "$$08@213");//000838/I1/U6/HMDA/20072017


                        if (responcetsiic.FileNo != "" && responcetsiic.FileNo != null)
                        {
                            gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "R", responcetsiic.FileNo, "Y");
                            int k = gen.InsertDeptDateTracingCFO("3", dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                        }
                        else
                        {
                            gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "R", responcetsiic.ErrorMessage, "N");
                        }

                    }
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
                            dsfactroy = gen.getattachmentdetailsonuidCFO(UIDNO, deptid, "");

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

                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "R", OUTPUT, "Y");
                                //Gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "A", OUTPUT, "Y");
                                int k = gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                            }
                            else
                            {
                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "R", OUTPUT, "N");
                            }
                        }
                        catch (Exception ex)
                        {


                        }
                    }

                    //if (deptid == "18")// FIRE
                    //{
                    //    try
                    //    {
                    //        ServicePointManager.Expect100Continue = true;
                    //        ServicePointManager.SecurityProtocol = //SecurityProtocolType.Tls12;
                    //        SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                    //        string valuefire = "";
                    //        string outputfire = "";
                    //        string fireattachments = "";
                    //        string outapplicant = "";
                    //        string outapplicant1 = "";
                    //        string outescapre = "";
                    //        DataSet dsdept = new DataSet();
                    //        DataSet dsfire = new DataSet();
                    //        DataSet dsfireescape = new DataSet();
                    //        DataSet dsdeptattachments = new DataSet();
                    //        dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);
                    //        valuefire = dsdept.GetXml();
                    //        string UID_No = dsdept.Tables[0].Rows[0]["UID_No"].ToString();
                    //        string EntrepreneurId = dsdept.Tables[0].Rows[0]["EntrepreneurId"].ToString();
                    //        string AppealDescription = dsdept.Tables[0].Rows[0]["AppealDescription"].ToString();
                    //        string AppealDocPath = dsdept.Tables[0].Rows[0]["AppealDocPath"].ToString();

                    //        string output = firecfo.Appealed(UID_No, EntrepreneurId, AppealDescription, AppealDocPath);  //fire.InsertApplicantFireDetails(valuefire);
                    //        //string[] split = output.Split('-');
                    //        //string applid = split[1];
                    //        //dsfire = gen.getfiremeanofescapedetailsonuid(UIDNO, applid);
                    //        //if (dsfire != null && dsfire.Tables.Count > 0 && dsfire.Tables[0].Rows.Count > 0)
                    //        //{
                    //        //    DataTable dtfire = new DataTable();
                    //        //    DataTable dtfirenew = new DataTable();
                    //        //    dtfire = dsfire.Tables[1];
                    //        //    dtfirenew = dsfire.Tables[2];
                    //        //    dsfire.Tables.Remove(dtfire);
                    //        //    dsfire.Tables.Remove(dtfirenew);
                    //        //    string fireescape = "";
                    //        //    fireescape = dsfire.GetXml();
                    //        //    outescapre = fire.StoreMeansOfEscape(fireescape);
                    //        //}
                    //        //DataSet dsfire1 = new DataSet();
                    //        //dsfire1 = gen.getfiremeanofescapedetailsonuid(UIDNO, applid);
                    //        //if (dsfire1 != null && dsfire1.Tables.Count > 0 && dsfire1.Tables[0].Rows.Count > 0)
                    //        //{
                    //        //    DataTable dtfire1 = new DataTable();
                    //        //    DataTable dtfire1new = new DataTable();
                    //        //    dtfire1 = dsfire1.Tables[0];
                    //        //    dtfire1new = dsfire1.Tables[2];
                    //        //    dsfire1.Tables.Remove(dtfire1);
                    //        //    dsfire1.Tables.Remove(dtfire1new);

                    //        //    string fireapplicant = "";
                    //        //    fireapplicant = dsfire1.GetXml();
                    //        //    outapplicant = fire.StoreFloorwiseApplicantDtls(fireapplicant);
                    //        //}
                    //        //DataSet dsfire2 = new DataSet();
                    //        //dsfire2 = gen.getfiremeanofescapedetailsonuid(UIDNO, applid);
                    //        //if (dsfire2 != null && dsfire2.Tables.Count > 0 && dsfire2.Tables[0].Rows.Count > 0)
                    //        //{
                    //        //    DataTable dtfire2 = new DataTable();
                    //        //    DataTable dtfire2new = new DataTable();
                    //        //    dtfire2 = dsfire2.Tables[1];
                    //        //    dtfire2new = dsfire2.Tables[0];
                    //        //    dsfire2.Tables.Remove(dtfire2);
                    //        //    dsfire2.Tables.Remove(dtfire2new);

                    //        //    string firefight = "";
                    //        //    firefight = dsfire2.GetXml();
                    //        //    outapplicant1 = fire.StoreFireFightingInstallations(firefight);
                    //        //}

                    //        //DataSet dsdeptattachmentsfire = new DataSet();
                    //        //dsdeptattachmentsfire = gen.getattachmentdetailsonuid(UIDNO, deptid, applid);
                    //        //fireattachments = dsdeptattachmentsfire.GetXml();
                    //        //outputfire = fire.StoreUploadDocuments(fireattachments);
                    //        ////StringReader str1 = new StringReader(outputfire);
                    //        ////DataSet dsout1 = new DataSet();
                    //        ////dsout1.ReadXml(str1);
                    //        if (output == "Success")
                    //        {
                    //            gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "R", output, "Y");
                    //            //Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "A", OUTPUT, "Y");
                    //            int k = gen.InsertDeptDateTracingCFO(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                    //        }
                    //        else
                    //        {
                    //            gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "R", output, "N");
                    //        }
                    //    }
                    //    catch (Exception ex)
                    //    {

                    //    }
                    //}
                }
            }
            if (ds != null && ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
            {
                dt = ds.Tables[3];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataSet dsdept = new DataSet();
                    string intApprovalid = dt.Rows[i]["intApprovalid"].ToString();
                    string intQuessionaireid = dt.Rows[i]["intQuessionaireid"].ToString();
                    string intDeptid = dt.Rows[i]["intDeptid"].ToString();


                    dsdept = gen.GetQueryStatusByTransactionIDCFOResponse(intQuessionaireid, intApprovalid);
                    //string UIDNO = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
                    string filepath = dsdept.Tables[0].Rows[0]["queryRespDocPath"].ToString();
                    string remarks = dsdept.Tables[0].Rows[0]["queryRespText"].ToString();
                    string npdclqueryresponse = "", nicapplno = "", questionnaireid = "";
                    string filepath1 = dsdept.Tables[0].Rows[0]["queryRespDocPath1"].ToString();
                    if (intApprovalid == "14")
                    {
                        nicapplno = dsdept.Tables[0].Rows[0]["NICApplicationno"].ToString();
                        questionnaireid = dsdept.Tables[0].Rows[0]["questionniareId"].ToString();
                    }
                    if (intApprovalid == "16")
                    {
                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = //SecurityProtocolType.Tls12;
                        SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

                        //ceigqueryvo.applicationID = dsdept.Tables[0].Rows[0]["Created_by"].ToString();
                        ceigqueryvo.entrepreneurID = dsdept.Tables[0].Rows[0]["entrepreneurId"].ToString();
                        ceigqueryvo.questionaireID = dsdept.Tables[0].Rows[0]["questionniareId"].ToString();
                        //ceigqueryvo.registration_id = Convert.ToInt32(dsdept.Tables[0].Rows[0]["intQueryTrnsid"].ToString());
                        ceigqueryvo.reply_doc_path = dsdept.Tables[0].Rows[0]["CEIGqueryRespDocName"].ToString();
                        ceigqueryvo.reply_description = dsdept.Tables[0].Rows[0]["queryRespText"].ToString();
                        // ceigqueryvo.system_ip = "1.1.1.1";
                        ceigqueryvo.UID = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
                        string output = ceigcfo.updateInstallationQueryReply(ceigqueryvo);
                        if (output == "SUCCESS")
                        {
                            gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "Q", output, "Y");
                            try
                            {
                                int k = gen.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, ds.Tables[0].Rows[0]["UID_No"].ToString().Trim(), null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFO", intApprovalid);
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        else
                        {
                            gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "Q", output, "N");
                        }
                        //SUCCESS
                    }
                    if (intApprovalid == "14")//PCB Query Response
                    {

                        try
                        {

                            //string WEBSERVICE_URL = "http://164.100.163.19/TLWSC/updateCl?cafUniqueNo=" + questionnaireid + "&indApplicationNo=" + nicapplno + "&remark=" + remarks + "&urlSingle=" + filepath;
                            string WEBSERVICE_URL = "https://tsocmms.nic.in/TLWS/updateCl?cafUniqueNo=" + questionnaireid + "&indApplicationNo=" + nicapplno + "&remark=" + remarks + "&urlSingle=" + filepath;
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
                                                gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "Q", jsonResponse, "Y");
                                                try
                                                {
                                                    int k = gen.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, ds.Tables[0].Rows[0]["UID_No"].ToString().Trim(), null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFO", intApprovalid);
                                                }
                                                catch (Exception ex)
                                                {

                                                }
                                            }
                                            else
                                            {
                                                gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "Q", jsonResponse, "N");
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
                                factoryqueryvo.documentPath = dtraw.Rows[k]["queryRespDocPath"].ToString();
                                lst[k] = factoryqueryvo;
                                //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                                //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                            }
                            queryvo.queryResponseAttachments = lst;
                        }

                        string queryout = factoryquery.insertIntoGrantLicenseQueryResponse(queryvo);
                        if (queryout == "SUCCESS")
                        {
                            gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "Q", queryout, "Y");
                            int k = gen.InsertDeptDateTracing(intDeptid, intQuessionaireid, ds.Tables[0].Rows[0]["UID_No"].ToString().Trim(), null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFO", intApprovalid);
                        }
                        else
                        {
                            gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "Q", queryout, "N");
                        }

                    }
                    else if (intApprovalid == "18") //FIRE
                    {
                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = //SecurityProtocolType.Tls12;
                        SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                        string OUTPUT = fireservicecfo.StoreQueryResponse_CFO(UIDNO, filepath1, remarks);
                        if (OUTPUT == "Success")
                        {
                            gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "Q", OUTPUT, "Y");
                            int k = gen.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, UIDNO, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFO", intApprovalid);
                        }
                        else
                        {
                            gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", OUTPUT, "N");
                        }
                    }
                    else if (intApprovalid == "64")//BOILERS
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
                                //if (dtraw.Rows[k]["queryRespDocName"].ToString() != "NA")
                                //{
                                //    boilerattachmentvo.documentName = dtraw.Rows[k]["queryRespDocName"].ToString();
                                //}
                                //else
                                //{
                                //    boilerattachmentvo.documentName = "";
                                //}
                                //if (dtraw.Rows[k]["queryRespDocPath"].ToString() != "NA")
                                //{
                                //    boilerattachmentvo.documentPath = dtraw.Rows[k]["queryRespDocPath"].ToString();
                                //}
                                //else
                                //{
                                //    boilerattachmentvo.documentPath = "";
                                //}
                                lst[k] = boilerattachmentvo;
                                //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                                //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                            }
                        }
                        boilervo.queryResponseAttachments = lst;
                        string boilerout = BoilerQuery.insertIntoPlanApprovalQueryResponse(boilervo);
                        if (boilerout == "SUCCESS")
                        {
                            gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "Q", boilerout, "Y");
                            int k = gen.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, UIDNO, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFO", intApprovalid);
                        }
                        else
                        {
                            gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "Q", boilerout, "N");
                        }
                    }
                    else if (intApprovalid == "63")//BOILERS
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
                                //if (dtraw.Rows[k]["queryRespDocName"].ToString() != "NA")
                                //{
                                //    boilerattachmentvo.documentName = dtraw.Rows[k]["queryRespDocName"].ToString();
                                //}
                                //else
                                //{
                                //    boilerattachmentvo.documentName = "";
                                //}
                                //if (dtraw.Rows[k]["queryRespDocPath"].ToString() != "NA")
                                //{
                                //    boilerattachmentvo.documentPath = dtraw.Rows[k]["queryRespDocPath"].ToString();
                                //}
                                //else
                                //{
                                //    boilerattachmentvo.documentPath = "";
                                //}
                                lst[k] = boilerattachmentvo;
                                //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                                //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                            }
                        }
                        boilervo.queryResponseAttachments = lst;
                        string boilerout = BoilerQuery.insertIntoPlanApprovalQueryResponse(boilervo);
                        if (boilerout == "SUCCESS")
                        {
                            gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "Q", boilerout, "Y");
                            int k = gen.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, UIDNO, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFO", intApprovalid);
                        }
                        else
                        {
                            gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "Q", boilerout, "N");
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
                                //if (dtraw.Rows[k]["queryRespDocName"].ToString() != "NA")
                                //{
                                //    boilerattachmentvo.documentName = dtraw.Rows[k]["queryRespDocName"].ToString();
                                //}
                                //else
                                //{
                                //    boilerattachmentvo.documentName = "";
                                //}
                                //if (dtraw.Rows[k]["queryRespDocPath"].ToString() != "NA")
                                //{
                                //    boilerattachmentvo.documentPath = dtraw.Rows[k]["queryRespDocPath"].ToString();
                                //}
                                //else
                                //{
                                //    boilerattachmentvo.documentPath = "";
                                //}
                                lst[k] = boilerattachmentvo;
                                //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                                //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                            }
                        }
                        boilervo.queryResponseAttachments = lst;
                        string boilerout = BoilerQuery.insertIntoPlanApprovalQueryResponse(boilervo);
                        if (boilerout == "SUCCESS")
                        {
                            gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "Q", boilerout, "Y");
                            int k = gen.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, UIDNO, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFO", intApprovalid);
                        }
                        else
                        {
                            gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "Q", boilerout, "N");
                        }
                    }
                    else if (intApprovalid == "67")//BOILERS
                    {
                        BoilerService.steamPipelineQR boilerattachmentvo = new BoilerService.steamPipelineQR();

                        boilerattachmentvo.applicationID = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
                        boilerattachmentvo.entrepreneurRemarks = dsdept.Tables[0].Rows[0]["queryRespText"].ToString(); ;
                        boilerattachmentvo.systemIP = "0.0.0.0";
                        boilerattachmentvo.userID = Convert.ToInt32(dsdept.Tables[0].Rows[0]["Created_by"].ToString());
                        //BoilerQueryResponseServiceTest.queryResponseAttachment[] lst = null;
                        BoilerService.queryResponseAttachment[] lst = null;
                        if (dsdept.Tables[0].Rows.Count > 0)
                        {
                            DataTable dtraw = new DataTable();
                            dtraw = dsdept.Tables[0];
                            lst = new BoilerService.queryResponseAttachment[dtraw.Rows.Count];

                            for (int k = 0; k < dtraw.Rows.Count; k++)
                            {

                                BoilerService.queryResponseAttachment boilervo = new BoilerService.queryResponseAttachment();
                                boilervo.documentName = dtraw.Rows[k]["queryRespDocName"].ToString();
                                boilervo.documentPath = dtraw.Rows[k]["queryRespDocPath"].ToString();
                                //if (dtraw.Rows[k]["queryRespDocName"].ToString() != "NA")
                                //{
                                //    boilerattachmentvo.documentName = dtraw.Rows[k]["queryRespDocName"].ToString();
                                //}
                                //else
                                //{
                                //    boilerattachmentvo.documentName = "";
                                //}
                                //if (dtraw.Rows[k]["queryRespDocPath"].ToString() != "NA")
                                //{
                                //    boilerattachmentvo.documentPath = dtraw.Rows[k]["queryRespDocPath"].ToString();
                                //}
                                //else
                                //{
                                //    boilerattachmentvo.documentPath = "";
                                //}
                                lst[k] = boilervo;
                            }
                        }
                        boilerattachmentvo.queryResponseAttachments = lst;
                        string boilerout = Boiler.insertIntoSPLQueryresponse(boilerattachmentvo);
                        if (boilerout == "SUCCESS")
                        {
                            gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "Q", boilerout, "Y");
                            int k = gen.InsertDeptDateTracing(intDeptid, intQuessionaireid, UIDNO, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFO", intApprovalid);
                        }
                        else
                        {
                            gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "Q", boilerout, "N");
                        }
                    }
                    else if (intApprovalid == "68")//BOILERS
                    {
                        BoilerService.steamPipelineQR boilerattachmentvo = new BoilerService.steamPipelineQR();

                        boilerattachmentvo.applicationID = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
                        boilerattachmentvo.entrepreneurRemarks = dsdept.Tables[0].Rows[0]["queryRespText"].ToString(); ;
                        boilerattachmentvo.systemIP = "0.0.0.0";
                        boilerattachmentvo.userID = Convert.ToInt32(dsdept.Tables[0].Rows[0]["Created_by"].ToString());
                        //BoilerQueryResponseServiceTest.queryResponseAttachment[] lst = null;
                        BoilerService.queryResponseAttachment[] lst = null;
                        if (dsdept.Tables[0].Rows.Count > 0)
                        {
                            DataTable dtraw = new DataTable();
                            dtraw = dsdept.Tables[0];
                            lst = new BoilerService.queryResponseAttachment[dtraw.Rows.Count];

                            for (int k = 0; k < dtraw.Rows.Count; k++)
                            {

                                BoilerService.queryResponseAttachment boilervo = new BoilerService.queryResponseAttachment();
                                boilervo.documentName = dtraw.Rows[k]["queryRespDocName"].ToString();
                                boilervo.documentPath = dtraw.Rows[k]["queryRespDocPath"].ToString();
                                //if (dtraw.Rows[k]["queryRespDocName"].ToString() != "NA")
                                //{
                                //    boilerattachmentvo.documentName = dtraw.Rows[k]["queryRespDocName"].ToString();
                                //}
                                //else
                                //{
                                //    boilerattachmentvo.documentName = "";
                                //}
                                //if (dtraw.Rows[k]["queryRespDocPath"].ToString() != "NA")
                                //{
                                //    boilerattachmentvo.documentPath = dtraw.Rows[k]["queryRespDocPath"].ToString();
                                //}
                                //else
                                //{
                                //    boilerattachmentvo.documentPath = "";
                                //}
                                lst[k] = boilervo;
                            }
                        }
                        boilerattachmentvo.queryResponseAttachments = lst;
                        string boilerout = Boiler.insertIntoSPLQueryresponse(boilerattachmentvo);
                        if (boilerout == "SUCCESS")
                        {
                            gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "Q", boilerout, "Y");
                            int k = gen.InsertDeptDateTracing(intDeptid, intQuessionaireid, UIDNO, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFO", intApprovalid);
                        }
                        else
                        {
                            gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "Q", boilerout, "N");
                        }
                    }
                    else if (intApprovalid == "52")// if (deptid == "48")  // shops and establishment
                    {
                        //DataSet dsdept = new DataSet();
                        try
                        {
                            DataSet dsdeptattachments = new DataSet();
                            dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, intApprovalid);

                            LabourQueryResponseCFO.act labouract = new LabourQueryResponseCFO.act();
                            LabourQueryResponseCFO.actsResponse labourout = new LabourQueryResponseCFO.actsResponse();

                            LabourQueryResponseCFO.shopsEstRegistrations shopactobjnew = new LabourQueryResponseCFO.shopsEstRegistrations();


                            //LabourCFOService.buildingotherconstructions labour = new LabourCFOService.buildingotherconstructions();
                            //LabourCFOService.actsResponse labourout = new LabourCFOService.actsResponse();
                            //LabourCFOService.contractLabourPrincipalEmployer contractvo = new LabourCFOService.contractLabourPrincipalEmployer();
                            //LabourCFOService.ismwPrincipalEmployer migrateemployer = new LabourCFOService.ismwPrincipalEmployer();

                            string actids = "";
                            string actid = "";
                            actids = dsdept.Tables[0].Rows[0]["LabourAct_Id"].ToString();
                            string[] split = actids.Split(',');
                            if (actids.Contains("1"))//The Buildings & Other Construction Workers Act
                            {
                                //// labouract.buildingRegistrationActSelected = true;
                                //labouract.shopRegistrationActSelected = true;
                                //shopactobjnew.actID = "SEF";//dsdept.Tables[0].Rows[0]["actID"].ToString();
                                ////shopactobjnew.bank_code = dsdept.Tables[0].Rows[0]["bank_code"].ToString();
                                ////shopactobjnew.bank_ref_number = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                ////shopactobjnew.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                ////shopactobjnew.cin = dsdept.Tables[0].Rows[0]["cin"].ToString();
                                ////shopactobjnew.compound_fee = 0;// dsdept.Tables[0].Columns[""].ToString();
                                //shopactobjnew.date_commencement = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                                ////shopactobjnew.date_completion = dsdept.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();
                                ////shopactobjnew.entrepreneur_id = dsdept.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                                ////  shopactobjnew.establishment_full_name = dsdept.Tables[0].Rows[0]["Form1_Estb_Name"].ToString();
                                //shopactobjnew.establishment_name = dsdept.Tables[0].Rows[0]["NAME"].ToString();
                                ////   shopactobjnew.establishment_permanent_district = dsdept.Tables[0].Rows[0]["Form1_2_Per_District"].ToString();
                                ////   shopactobjnew.establishment_permanent_door = dsdept.Tables[0].Rows[0]["Form1_2_Per_DoorNo"].ToString();
                                ////  shopactobjnew.establishment_permanent_mandal = dsdept.Tables[0].Rows[0]["Form1_2_Per_Mandal"].ToString();
                                ////   shopactobjnew.establishment_permanent_pincode = dsdept.Tables[0].Rows[0]["Form1_2_Per_PinCode"].ToString();
                                ////   shopactobjnew.establishment_permanent_village = dsdept.Tables[0].Rows[0]["Form1_2_Per_Village"].ToString();
                                //shopactobjnew.establishment_postal_district = dsdept.Tables[0].Rows[0]["Form1_Estd_District"].ToString();
                                //shopactobjnew.establishment_postal_door = dsdept.Tables[0].Rows[0]["Form1_Estd_DoorNo"].ToString();
                                //shopactobjnew.establishment_postal_locality = dsdept.Tables[0].Rows[0]["Form1_Estd_Locality"].ToString();
                                //shopactobjnew.establishment_postal_mandal = dsdept.Tables[0].Rows[0]["Form1_Estd_Mandal"].ToString();
                                //shopactobjnew.establishment_postal_pincode = dsdept.Tables[0].Rows[0]["Form1_Estd_PinCode"].ToString();
                                //shopactobjnew.establishment_postal_village = dsdept.Tables[0].Rows[0]["Form1_Estd_Village"].ToString();
                                //shopactobjnew.manager_agent_designation = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Designation"].ToString();
                                //shopactobjnew.manager_agent_district = dsdept.Tables[0].Rows[0]["Form1_1_Manager_District"].ToString();
                                //shopactobjnew.manager_agent_door = dsdept.Tables[0].Rows[0]["Form1_1_Manager_DoorNo"].ToString();
                                //shopactobjnew.manager_agent_email = dsdept.Tables[0].Rows[0]["Form1_Manager_EMail"].ToString();
                                //shopactobjnew.manager_agent_fathername = dsdept.Tables[0].Rows[0]["Form1_1_Manager_FatherName"].ToString();
                                //shopactobjnew.manager_agent_mandal = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Mandal"].ToString();
                                //shopactobjnew.manager_agent_mobile = dsdept.Tables[0].Rows[0]["Form1_Manager_MobileNo"].ToString();
                                //shopactobjnew.manager_agent_name = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Name"].ToString();
                                //shopactobjnew.manager_agent_street = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Locality"].ToString();
                                //shopactobjnew.manager_agent_village = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Village"].ToString();
                                //// shopactobjnew.max_employees_aday = dsdept.Tables[0].Rows[0]["Form1_2_MaxWorkers"].ToString();
                                //shopactobjnew.nature_work = dsdept.Tables[0].Rows[0]["Form1_Nature_of_Business"].ToString();
                                //// shopactobjnew.other_attachments_1 = "";//dsdept.Tables[0].Columns["other_attachments_1"].ToString();
                                //// shopactobjnew.other_attachments_2 = "";// dsdept.Tables[0].Columns["other_attachments_2"].ToString();
                                ////shopactobjnew.payment_mode = dsdept.Tables[0].Rows[0]["payment_mode"].ToString();
                                ////shopactobjnew.paymentFlag = dsdept.Tables[0].Rows[0]["paymentFlag"].ToString();
                                ////shopactobjnew.penality_percentage = Convert.ToInt32(dsdept.Tables[0].Rows[0]["penality_percentage"].ToString());
                                ////shopactobjnew.penality_years = Convert.ToInt32(dsdept.Tables[0].Rows[0]["penality_years"].ToString());
                                //shopactobjnew.projectSubmitDate = dsdept.Tables[0].Rows[0]["projectSubmitDate"].ToString();
                                ////shopactobjnew.questionnaire_id = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                                ////shopactobjnew.registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                                ////shopactobjnew.registration_years = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_years"].ToString());
                                //shopactobjnew.stageID = dsdept.Tables[0].Rows[0]["stageID"].ToString();
                                ////shopactobjnew.total_amount_payable = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString());
                                ////shopactobjnew.total_penality_amount = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_penality_amount"].ToString());
                                ////shopactobjnew.total_registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_registration_fee"].ToString());
                                ////shopactobjnew.totalAmount = dsdept.Tables[0].Rows[0]["totalAmount"].ToString();
                                ////shopactobjnew.transaction_for = dsdept.Tables[0].Rows[0]["transaction_for"].ToString();
                                ////shopactobjnew.transaction_id = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                ////shopactobjnew.transaction_status = "Y";
                                ////shopactobjnew.transactionDate = dsdept.Tables[0].Rows[0]["transactionDate"].ToString();
                                ////labour.tsipassApplicationID = dsdept.Tables[0].Rows[0]["tsipassApplicationID"].ToString();
                                ////shopactobjnew.type_of_application = dsdept.Tables[0].Rows[0]["type_of_application"].ToString();
                                //shopactobjnew.uID = dsdept.Tables[0].Rows[0]["UID_NO"].ToString();
                                //// shopactobjnew.unpaid_balance_welfare = Convert.ToInt32(dsdept.Tables[0].Rows[0]["unpaid_balance_welfare"].ToString());
                                //// shopactobjnew.valid_from_date = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                                //// shopactobjnew.valid_to_date = dsdept.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();
                                //shopactobjnew.establishment_category = "1";
                                //shopactobjnew.establishment_classification = "1";

                                ////  labouract.buildingRegistrationActData = labour;

                                //LabourQueryResponseCFO.shopActsWorkPlaceMultiData[] shopactobj = null;

                                //if (dsdept.Tables[1].Rows.Count > 0)
                                //{
                                //    DataTable dtraw = new DataTable();
                                //    dtraw = dsdept.Tables[1];
                                //    shopactobj = new LabourQueryResponseCFO.shopActsWorkPlaceMultiData[dtraw.Rows.Count];

                                //    for (int k = 0; k < dtraw.Rows.Count; k++)
                                //    {
                                //        LabourQueryResponseCFO.shopActsWorkPlaceMultiData workplacevo = new LabourQueryResponseCFO.shopActsWorkPlaceMultiData();
                                //        workplacevo.workPlacedoorNo = dtraw.Rows[k]["Door_No"].ToString();
                                //        workplacevo.workPlacelocality = dtraw.Rows[k]["Locality"].ToString();
                                //        workplacevo.workPlaceType = dtraw.Rows[k]["Work_Place"].ToString();
                                //        shopactobj[k] = workplacevo;
                                //    }
                                //    shopactobjnew.workPlaceDetails = shopactobj;
                                //}

                                //LabourQueryResponseCFO.shopActsEmployeesMultiData[] shopactobj1 = null;
                                //if (dsdept.Tables[2].Rows.Count > 0)
                                //{
                                //    DataTable dtraw2 = new DataTable();
                                //    dtraw2 = dsdept.Tables[2];
                                //    shopactobj1 = new LabourQueryResponseCFO.shopActsEmployeesMultiData[dtraw2.Rows.Count];

                                //    for (int k = 0; k < dtraw2.Rows.Count; k++)
                                //    {
                                //        LabourQueryResponseCFO.shopActsEmployeesMultiData workplacevo1 = new LabourQueryResponseCFO.shopActsEmployeesMultiData();
                                //        workplacevo1.employeeGender = dtraw2.Rows[k]["Gender"].ToString();
                                //        workplacevo1.employeeName = dtraw2.Rows[k]["Name"].ToString();
                                //        workplacevo1.employeeOccupation = dtraw2.Rows[k]["Occupation"].ToString();
                                //        shopactobj1[k] = workplacevo1;
                                //    }
                                //    shopactobjnew.employeesDetails = shopactobj1;
                                //}


                                //LabourQueryResponseCFO.shopActsFamilyMultiData[] shopactobj3 = null;

                                //if (dsdept.Tables[3].Rows.Count > 0)
                                //{
                                //    DataTable dtraw3 = new DataTable();
                                //    dtraw3 = dsdept.Tables[3];
                                //    shopactobj3 = new LabourQueryResponseCFO.shopActsFamilyMultiData[dtraw3.Rows.Count];

                                //    for (int k = 0; k < dtraw3.Rows.Count; k++)
                                //    {
                                //        LabourQueryResponseCFO.shopActsFamilyMultiData workplacevo3 = new LabourQueryResponseCFO.shopActsFamilyMultiData();
                                //        workplacevo3.familyMemberAdultYoung = dtraw3.Rows[k]["Adult_Flag"].ToString();
                                //        workplacevo3.familyMemberGender = dtraw3.Rows[k]["Gender"].ToString();
                                //        workplacevo3.familyMemberRelationship = dtraw3.Rows[k]["RelationShip"].ToString();
                                //        workplacevo3.familyMemeberName = dtraw3.Rows[k]["Name"].ToString();
                                //        shopactobj3[k] = workplacevo3;
                                //    }
                                //    shopactobjnew.familyDetails = shopactobj3;
                                //}
                                //labouract.shopRegistrationActData = shopactobjnew;
                                //labourout = labourqueryserviceCfo.actSelected(labouract);

                                labouract.shopRegistrationActSelected = true;
                                shopactobjnew.address_proof = "";
                                shopactobjnew.authorise_letter_proof = "";
                                shopactobjnew.actID = "SEF";//dsdept.Tables[0].Rows[0]["actID"].ToString();
                                //shopactobjnew.bank_code = dsdept.Tables[0].Rows[0]["bank_code"].ToString();
                                //shopactobjnew.bank_ref_number = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                //shopactobjnew.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                //shopactobjnew.cin = dsdept.Tables[0].Rows[0]["cin"].ToString();
                                //shopactobjnew.compound_fee = 0;// dsdept.Tables[0].Columns[""].ToString();                                        
                                shopactobjnew.date_commencement = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                                //shopactobjnew.date_completion = dsdept.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();
                                //shopactobjnew.entrepreneur_id = dsdept.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
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
                                // shopactobjnew.max_employees_aday = dsdept.Tables[0].Rows[0]["Form1_2_MaxWorkers"].ToString();
                                shopactobjnew.nature_work = dsdept.Tables[0].Rows[0]["Form1_Nature_of_Business"].ToString();
                                // shopactobjnew.other_attachments_1 = "";//dsdept.Tables[0].Columns["other_attachments_1"].ToString();
                                // shopactobjnew.other_attachments_2 = "";// dsdept.Tables[0].Columns["other_attachments_2"].ToString();
                                //shopactobjnew.payment_mode = dsdept.Tables[0].Rows[0]["payment_mode"].ToString();
                                //shopactobjnew.paymentFlag = dsdept.Tables[0].Rows[0]["paymentFlag"].ToString();
                                //shopactobjnew.penality_percentage = Convert.ToInt32(dsdept.Tables[0].Rows[0]["penality_percentage"].ToString());
                                //shopactobjnew.penality_years = Convert.ToInt32(dsdept.Tables[0].Rows[0]["penality_years"].ToString());
                                shopactobjnew.projectSubmitDate = dsdept.Tables[0].Rows[0]["projectSubmitDate"].ToString();
                                //shopactobjnew.questionnaire_id = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                                //shopactobjnew.registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                                //shopactobjnew.registration_years = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_years"].ToString());
                                shopactobjnew.stageID = dsdept.Tables[0].Rows[0]["stageID"].ToString();
                                //shopactobjnew.total_amount_payable = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString());
                                //shopactobjnew.total_penality_amount = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_penality_amount"].ToString());
                                //shopactobjnew.total_registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_registration_fee"].ToString());
                                //shopactobjnew.totalAmount = dsdept.Tables[0].Rows[0]["totalAmount"].ToString();
                                //shopactobjnew.transaction_for = dsdept.Tables[0].Rows[0]["transaction_for"].ToString();
                                //shopactobjnew.transaction_id = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                //shopactobjnew.transaction_status = "Y";
                                //shopactobjnew.transactionDate = dsdept.Tables[0].Rows[0]["transactionDate"].ToString();
                                ////labour.tsipassApplicationID = dsdept.Tables[0].Rows[0]["tsipassApplicationID"].ToString();
                                //shopactobjnew.type_of_application = dsdept.Tables[0].Rows[0]["type_of_application"].ToString();
                                shopactobjnew.uID = dsdept.Tables[0].Rows[0]["UID_NO"].ToString();
                                //shopactobjnew.unpaid_balance_welfare = Convert.ToInt32(dsdept.Tables[0].Rows[0]["unpaid_balance_welfare"].ToString());
                                //shopactobjnew.valid_from_date = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                                //shopactobjnew.valid_to_date = dsdept.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();
                                shopactobjnew.establishment_category = "1";
                                shopactobjnew.establishment_classification = "1";
                                //shopactobjnew.male_adults = dsdept.Tables[0].Rows[0]["Form1_1_Employees_Above18_Male"].ToString();
                                //shopactobjnew.male_young = dsdept.Tables[0].Rows[0]["Form1_1_Employees_14_18_Male"].ToString();
                                //shopactobjnew.female_adults = dsdept.Tables[0].Rows[0]["Form1_1_Employees_Above18_Female"].ToString();
                                //shopactobjnew.female_young = dsdept.Tables[0].Rows[0]["Form1_1_Employees_14_18_Female"].ToString();

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
                                //shopactobjnew.total_adults = dsdept.Tables[0].Rows[0]["total_adults"].ToString();
                                //shopactobjnew.total_young = dsdept.Tables[0].Rows[0]["total_young"].ToString();

                                //  labouract.buildingRegistrationActData = labour;

                                LabourQueryResponseCFO.shopActsWorkPlaceMultiData[] shopactobj = null;

                                if (dsdept.Tables[1].Rows.Count > 0)
                                {
                                    DataTable dtraw = new DataTable();
                                    dtraw = dsdept.Tables[1];
                                    shopactobj = new LabourQueryResponseCFO.shopActsWorkPlaceMultiData[dtraw.Rows.Count];

                                    for (int k = 0; k < dtraw.Rows.Count; k++)
                                    {
                                        LabourQueryResponseCFO.shopActsWorkPlaceMultiData workplacevo = new LabourQueryResponseCFO.shopActsWorkPlaceMultiData();
                                        workplacevo.workPlacedoorNo = dtraw.Rows[k]["Door_No"].ToString();
                                        workplacevo.workPlacelocality = dtraw.Rows[k]["Locality"].ToString();
                                        workplacevo.workPlaceType = dtraw.Rows[k]["Work_Place"].ToString();
                                        shopactobj[k] = workplacevo;
                                    }
                                    shopactobjnew.workPlaceDetails = shopactobj;
                                }

                                LabourQueryResponseCFO.shopActsEmployeesMultiData[] shopactobj1 = null;
                                if (dsdept.Tables[2].Rows.Count > 0)
                                {
                                    DataTable dtraw2 = new DataTable();
                                    dtraw2 = dsdept.Tables[2];
                                    shopactobj1 = new LabourQueryResponseCFO.shopActsEmployeesMultiData[dtraw2.Rows.Count];

                                    for (int k = 0; k < dtraw2.Rows.Count; k++)
                                    {
                                        LabourQueryResponseCFO.shopActsEmployeesMultiData workplacevo1 = new LabourQueryResponseCFO.shopActsEmployeesMultiData();
                                        workplacevo1.employeeGender = dtraw2.Rows[k]["Gender"].ToString();
                                        workplacevo1.employeeName = dtraw2.Rows[k]["Name"].ToString();
                                        workplacevo1.employeeOccupation = dtraw2.Rows[k]["Occupation"].ToString();
                                        shopactobj1[k] = workplacevo1;
                                    }
                                    shopactobjnew.employeesDetails = shopactobj1;
                                }


                                LabourQueryResponseCFO.shopActsFamilyMultiData[] shopactobj3 = null;

                                if (dsdept.Tables[3].Rows.Count > 0)
                                {
                                    DataTable dtraw3 = new DataTable();
                                    dtraw3 = dsdept.Tables[3];
                                    shopactobj3 = new LabourQueryResponseCFO.shopActsFamilyMultiData[dtraw3.Rows.Count];

                                    for (int k = 0; k < dtraw3.Rows.Count; k++)
                                    {
                                        LabourQueryResponseCFO.shopActsFamilyMultiData workplacevo3 = new LabourQueryResponseCFO.shopActsFamilyMultiData();
                                        workplacevo3.familyMemberAdultYoung = dtraw3.Rows[k]["Adult_Flag"].ToString();
                                        workplacevo3.familyMemberGender = dtraw3.Rows[k]["Gender"].ToString();
                                        workplacevo3.familyMemberRelationship = dtraw3.Rows[k]["RelationShip"].ToString();
                                        workplacevo3.familyMemeberName = dtraw3.Rows[k]["Name"].ToString();
                                        shopactobj3[k] = workplacevo3;
                                    }
                                    shopactobjnew.familyDetails = shopactobj3;
                                }
                                DataSet dsdeptattachmentslabour = new DataSet();
                                dsdeptattachmentslabour = gen.getattachmentdetailsonuidCFO(UIDNO, "52", "");
                                if (dsdeptattachmentslabour != null && dsdeptattachmentslabour.Tables.Count > 0 && dsdeptattachmentslabour.Tables[0].Rows.Count > 0)
                                {
                                    ///PAN CARD////

                                    if (dsdeptattachmentslabour.Tables[0].Rows.Count > 0)
                                    {
                                        shopactobjnew.employees_proof = dsdeptattachmentslabour.Tables[0].Rows[0]["Filepath"].ToString();
                                    }
                                    if (dsdeptattachmentslabour.Tables[1].Rows.Count > 0)
                                    {
                                        shopactobjnew.address_proof = dsdeptattachmentslabour.Tables[1].Rows[0]["Filepath"].ToString();
                                    }
                                    if (dsdeptattachmentslabour.Tables[2].Rows.Count > 0)
                                    {
                                        shopactobjnew.authorise_letter_proof = dsdeptattachmentslabour.Tables[2].Rows[0]["Filepath"].ToString();
                                    }
                                    if (dsdeptattachmentslabour.Tables[3].Rows.Count > 0)
                                    {
                                        shopactobjnew.certificate_incorporation_proof = dsdeptattachmentslabour.Tables[3].Rows[0]["Filepath"].ToString();
                                    }
                                }

                                labouract.shopRegistrationActData = shopactobjnew;
                                labourout = labourqueryserviceCfo.actSelected(labouract);


                                // labourout = labourserviceCfo.actSelected(labouract);
                                if (labourout.status == "SUCCESS")
                                {
                                    string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "Q", labouroutmsg, "Y");
                                    int k = gen.InsertDeptDateTracing(intDeptid, intQuessionaireid, UIDNO, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFO", intApprovalid);
                                }
                                else
                                {
                                    string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "Q", labourouterrormsg, "Y");
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    else if (intApprovalid == "50") // contract labour
                    {
                        //DataSet dsdept = new DataSet();
                        try
                        {
                            DataSet dsdeptattachments = new DataSet();
                            dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, intApprovalid);

                            LabourQueryResponseCFO.act labouract = new LabourQueryResponseCFO.act();
                            // LabourQueryResponseCFO.buildingotherconstructions labour = new LabourQueryResponseCFO.buildingotherconstructions();
                            LabourQueryResponseCFO.actsResponse labourout = new LabourQueryResponseCFO.actsResponse();
                            LabourQueryResponseCFO.contractLabourPrincipalEmployer contractvo = new LabourQueryResponseCFO.contractLabourPrincipalEmployer();
                            LabourQueryResponseCFO.ismwPrincipalEmployer migrateemployer = new LabourQueryResponseCFO.ismwPrincipalEmployer();



                            string actids = "";
                            string actid = "";
                            actids = dsdept.Tables[0].Rows[0]["LabourAct_Id"].ToString();
                            string[] split = actids.Split(',');
                            if (actids.Contains("3"))//The Contract Labour Act (Principal Employer)
                            {

                                labouract.contractLabourPrincipalEmplyerActSelected = true;
                                contractvo.actID = "CPF";
                                //contractvo.bank_code = dsdept.Tables[0].Rows[0]["bank_code"].ToString();
                                //contractvo.bank_ref_number = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                //contractvo.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                //contractvo.cin = dsdept.Tables[0].Rows[0]["cin"].ToString();
                                //contractvo.compound_fee = 0;
                                contractvo.employees_attachement = "";//dsdept.Tables[0].Rows[0][""].ToString();
                                // contractvo.entrepreneur_id = dsdept.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
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
                                //  contractvo.max_employees_aday = dsdept.Tables[0].Rows[0]["Form1_2_MaxWorkers"].ToString();
                                contractvo.nature_work = dsdept.Tables[0].Rows[0]["Form1_Nature_of_Business"].ToString();
                                contractvo.other_attachments_1 = "";
                                contractvo.other_attachments_2 = "";
                                //contractvo.payment_mode = dsdept.Tables[0].Rows[0]["payment_mode"].ToString();
                                //contractvo.paymentFlag = dsdept.Tables[0].Rows[0]["paymentFlag"].ToString();
                                //contractvo.penality_percentage = 0;//Convert.ToInt32(dsdept.Tables[0].Rows[0]["penality_percentage"].ToString());
                                //contractvo.penality_years = 0;//Convert.ToInt32(dsdept.Tables[0].Rows[0]["penality_years"].ToString());
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
                                //contractvo.questionnaire_id = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                                //contractvo.registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                                //contractvo.registration_years = 0;
                                contractvo.stageID = dsdept.Tables[0].Rows[0]["intStageid"].ToString();
                                //contractvo.total_amount_payable = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString());
                                //contractvo.total_penality_amount = 0;
                                //contractvo.total_registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                                //contractvo.totalAmount = dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString();
                                //contractvo.transaction_for = dsdept.Tables[0].Rows[0]["transaction_for"].ToString();
                                //contractvo.transaction_id = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                //contractvo.transaction_status = "Y";//dsdept.Tables[0].Rows[0][""].ToString();
                                //contractvo.transactionDate = dsdept.Tables[0].Rows[0]["transactionDate"].ToString();
                                //contractvo.transactionNumber = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                //contractvo.tsipassApplicationID = dsdept.Tables[0].Rows[0][""].ToString();
                                //contractvo.type_of_application = dsdept.Tables[0].Rows[0]["type_of_application"].ToString();
                                contractvo.uID = dsdept.Tables[0].Rows[0]["UID_NO"].ToString();
                                //contractvo.unpaid_balance_welfare = Convert.ToInt32(dsdept.Tables[0].Rows[0]["unpaid_balance_welfare"].ToString());
                                //contractvo.valid_from_date = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                                //contractvo.valid_to_date = dsdept.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();

                                LabourQueryResponseCFO.contractLabourPrincipalEmployerMultiData[] contractmulti = null;

                                //contractvo.contractorParticulars[] lstitem = null;
                                ContractorDetails co = new ContractorDetails();
                                //FactoryService.rawMaterial[] lst = null;
                                if (dsdept.Tables[1].Rows.Count > 0)
                                {
                                    DataTable dtraw = new DataTable();
                                    dtraw = dsdept.Tables[1];
                                    contractmulti = new LabourQueryResponseCFO.contractLabourPrincipalEmployerMultiData[dtraw.Rows.Count];

                                    for (int k = 0; k < dtraw.Rows.Count; k++)
                                    {
                                        //FactoryService.rawMaterial BBB = new FactoryService.rawMaterial();
                                        LabourQueryResponseCFO.contractLabourPrincipalEmployerMultiData coc = new LabourQueryResponseCFO.contractLabourPrincipalEmployerMultiData();
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
                                labourout = labourqueryserviceCfo.actSelected(labouract);

                                if (labourout.status == "SUCCESS")
                                {
                                    string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                    //  gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", labouroutmsg, "Y");
                                    //string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "Q", labouroutmsg, "Y");
                                    int k = gen.InsertDeptDateTracing(intDeptid, intQuessionaireid, UIDNO, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFO", intApprovalid);
                                }
                                else
                                {
                                    string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "Q", labourouterrormsg, "N");
                                    // gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "N", labourouterrormsg, "N");
                                    // updatequerystringcfo(Request.QueryString["Queryid"].ToString());
                                }
                            }

                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    else if (intApprovalid == "51")
                    {
                        //DataSet dsdept = new DataSet();
                        try
                        {
                            DataSet dsdeptattachments = new DataSet();
                            dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, intApprovalid);

                            LabourQueryResponseCFO.act labouract = new LabourQueryResponseCFO.act();
                            //LabourQueryResponseCFO.buildingotherconstructions labour = new LabourQueryResponseCFO.buildingotherconstructions();
                            LabourQueryResponseCFO.actsResponse labourout = new LabourQueryResponseCFO.actsResponse();
                            LabourQueryResponseCFO.contractLabourPrincipalEmployer contractvo = new LabourQueryResponseCFO.contractLabourPrincipalEmployer();
                            LabourQueryResponseCFO.ismwPrincipalEmployer migrateemployer = new LabourQueryResponseCFO.ismwPrincipalEmployer();

                            string actids = "";
                            string actid = "";
                            actids = dsdept.Tables[0].Rows[0]["LabourAct_Id"].ToString();
                            string[] split = actids.Split(',');

                            if (actids.Contains("4"))//Principal Employer Registration Under InterState Migrant Workman Act
                            {
                                labouract.interstateMigrantPrincipalEmplyerActSelected = true;
                                migrateemployer.actID = "ISMWPEF";
                                //migrateemployer.bank_code = dsdept.Tables[0].Rows[0]["bank_code"].ToString();
                                //migrateemployer.bank_ref_number = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                //migrateemployer.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                //migrateemployer.cin = dsdept.Tables[0].Rows[0]["cin"].ToString();
                                //migrateemployer.compound_fee = 0;
                                migrateemployer.director_district = dsdept.Tables[0].Rows[0]["Form1_4_Dir_District"].ToString();
                                migrateemployer.director_door = dsdept.Tables[0].Rows[0]["Form1_4_Dir_DoorNo"].ToString();
                                migrateemployer.director_mandal = dsdept.Tables[0].Rows[0]["Form1_4_Dir_Mandal"].ToString();
                                migrateemployer.director_name = dsdept.Tables[0].Rows[0]["Form1_4_Dir_FullName"].ToString();
                                migrateemployer.director_village = dsdept.Tables[0].Rows[0]["Form1_4_Dir_Village"].ToString();
                                migrateemployer.employees_attachement = "";
                                // migrateemployer.entrepreneur_id = dsdept.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
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
                                // migrateemployer.max_employees_aday = dsdept.Tables[0].Rows[0]["Form1_2_MaxWorkers"].ToString();
                                migrateemployer.nature_work = dsdept.Tables[0].Rows[0]["Form1_Nature_of_Business"].ToString();
                                migrateemployer.other_attachments_1 = "";
                                migrateemployer.other_attachments_2 = "";
                                //migrateemployer.payment_mode = dsdept.Tables[0].Rows[0]["payment_mode"].ToString();
                                //migrateemployer.paymentFlag = dsdept.Tables[0].Rows[0]["paymentFlag"].ToString();
                                //migrateemployer.penality_percentage = 0;
                                //migrateemployer.penality_years = 0;
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
                                //migrateemployer.questionnaire_id = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                                //migrateemployer.registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                                //migrateemployer.registration_years = 0;
                                migrateemployer.stageID = dsdept.Tables[0].Rows[0]["intStageid"].ToString();
                                //migrateemployer.total_amount_payable = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString());
                                //migrateemployer.total_penality_amount = 0;
                                //migrateemployer.total_registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                                //migrateemployer.totalAmount = dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString();
                                //migrateemployer.transaction_for = dsdept.Tables[0].Rows[0]["transaction_for"].ToString();
                                //migrateemployer.transaction_id = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                //migrateemployer.transaction_status = "Y";
                                //migrateemployer.transactionDate = dsdept.Tables[0].Rows[0]["transactionDate"].ToString();
                                //migrateemployer.transactionNumber = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                //migrateemployer.type_of_application = dsdept.Tables[0].Rows[0]["type_of_application"].ToString();
                                migrateemployer.uID = dsdept.Tables[0].Rows[0]["UID_NO"].ToString();
                                //migrateemployer.unpaid_balance_welfare = Convert.ToInt32(dsdept.Tables[0].Rows[0]["unpaid_balance_welfare"].ToString());
                                //migrateemployer.valid_from_date = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                                //migrateemployer.valid_to_date = dsdept.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();

                                //LabourQueryResponseCFO.ismwPrincipalEmployerMultiData[] migrantvo = null;
                                //ContractorDetails co = new ContractorDetails();
                                ////FactoryService.rawMaterial[] lst = null;
                                //if (dsdept.Tables[1].Rows.Count > 0)
                                //{
                                //    DataTable dtraw = new DataTable();
                                //    dtraw = dsdept.Tables[1];
                                //    migrantvo = new LabourQueryResponseCFO.ismwPrincipalEmployerMultiData[dtraw.Rows.Count];

                                //    for (int k = 0; k < dtraw.Rows.Count; k++)
                                //    {
                                //        //FactoryService.rawMaterial BBB = new FactoryService.rawMaterial();
                                //        LabourQueryResponseCFO.ismwPrincipalEmployerMultiData coc = new LabourQueryResponseCFO.ismwPrincipalEmployerMultiData();
                                //        coc.contractorAddress = dtraw.Rows[k]["Contractor_Address"].ToString();
                                //        coc.commencementDate = dtraw.Rows[k]["Contractor_Est_Commence_Dt"].ToString();
                                //        coc.terminationDate = dtraw.Rows[k]["Contractor_Est_Compltd_Dt"].ToString();
                                //        //coc.m = dtraw.Rows[k]["Contractor_MobileNo"].ToString();
                                //        coc.contractorName = dtraw.Rows[k]["Contractor_Name"].ToString();
                                //        coc.maxcontractLabour = dtraw.Rows[k]["Contractor_MaxWorkers"].ToString();
                                //        coc.natureOfWork = dtraw.Rows[k]["Contractor_Work_Nature"].ToString();
                                //        coc.manufacturingDeptDetails = dtraw.Rows[k]["Contractor_ManufacturingDepts"].ToString();
                                //        coc.mobileNo = dtraw.Rows[k]["Contractor_MobileNo"].ToString();
                                //        migrantvo[k] = coc;
                                //        //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                                //        //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                                //    }
                                //    migrateemployer.contractorParticulars = migrantvo;
                                //    //rawvo.materialDescr
                                //}
                                labouract.interstateMigrantPrincipalEmplyerActData = migrateemployer;
                                labourout = labourqueryserviceCfo.actSelected(labouract);
                                if (labourout.status == "SUCCESS")
                                {
                                    string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                    //  gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", labouroutmsg, "Y");
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "Q", labouroutmsg, "Y");
                                    int k = gen.InsertDeptDateTracing(intDeptid, intQuessionaireid, UIDNO, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFO", intApprovalid);
                                }
                                else
                                {
                                    string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "Q", labourouterrormsg, "Y");
                                    // gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "N", labourouterrormsg, "N");
                                    // updatequerystringcfo(Request.QueryString["Queryid"].ToString());
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }
            if (ds != null && ds.Tables.Count > 3 && ds.Tables[4].Rows.Count > 0)
            {
                dt = ds.Tables[4];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = //SecurityProtocolType.Tls12;
                    SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

                    string intApprovalid = dt.Rows[i]["intApprovalid"].ToString();
                    string intQuessionaireid = dt.Rows[i]["intQuessionaireid"].ToString();
                    string intDeptid = dt.Rows[i]["intDeptid"].ToString();
                    DataSet dsdept = new DataSet();
                    dsdept = gen.GetQueryStatusByTransactionIDCFOCEIG(intQuessionaireid);

                    if (intApprovalid == "16")
                    {
                        //ceigqueryvo.applicationID = dsdept.Tables[0].Rows[0]["Created_by"].ToString();
                        ceigqueryvo.entrepreneurID = dsdept.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                        ceigqueryvo.questionaireID = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                        //ceigqueryvo.registration_id = Convert.ToInt32(dsdept.Tables[0].Rows[0]["intQueryTrnsid"].ToString());
                        ceigqueryvo.reply_doc_path = dsdept.Tables[0].Rows[0]["ComplainceReport"].ToString();
                        ceigqueryvo.reply_description = dsdept.Tables[0].Rows[0]["CeigComplainceResponse"].ToString();
                        // ceigqueryvo.system_ip = "1.1.1.1";
                        ceigqueryvo.UID = dsdept.Tables[0].Rows[0]["UID_No"].ToString();
                        string output = ceigcfo.updateInstallationCompliance(ceigqueryvo);
                        if (output == "SUCCESS")
                        {
                            gen.UpdateDepartwebserviceflagCFO(ceigqueryvo.UID, intApprovalid, "CR", output, "Y");
                            try
                            {
                                //int k = Gen.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, ds.Tables[0].Rows[0]["UID_No"].ToString().Trim(), null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFO", intApprovalid);
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        else
                        {
                            gen.UpdateDepartwebserviceflagCFO(ceigqueryvo.UID, intApprovalid, "CR", output, "N");
                        }
                        //SUCCESS
                    }
                }
            }
            StringBuilder sbScript = new StringBuilder();
            string sScript;
            sbScript.Append("<script>");
            sbScript.Append(" window.close();");
            sbScript.Append("</script>");
            sScript = sbScript.ToString();
            //ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", sScript, false);
        }
        // }


        catch (Exception ex)
        {
            //lblmsg.Text = ex.Message;
            //lblmsg.Visible = true;
        }
    }


}