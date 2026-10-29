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

public partial class UI_TSiPASS_DepartmentserviceRen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FactoryRenewalService.TSFactoryServiceImplService factoryren = new FactoryRenewalService.TSFactoryServiceImplService();
        BoilerService.TSBoilerServiceImplService BoilerRenewalservice = new BoilerService.TSBoilerServiceImplService();
        Drug.TSIPass_Eodb objdrug = new Drug.TSIPass_Eodb();
        TSIPASSWEBSERVICE.DepartmentApprovalSystem tsipassobj = new TSIPASSWEBSERVICE.DepartmentApprovalSystem();
        FireServiceCFO.Service1 fireren = new FireServiceCFO.Service1();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        General gen = new General();
        DataSet dsdept = new DataSet();
        //DataSet ds = new DataSet();     Vdk#$bvfeBFdSd4c$
        string UIDNO = "SML0040037121719REN";
        // string deptidpcb = "53";
        //if (deptidpcb == "53")
        //{
        ds = gen.GetDepartmentonuidREN(UIDNO);
        if (ds != null && ds.Tables.Count > 1 && ds.Tables[0].Rows.Count > 0)
        {
            dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string deptid = dt.Rows[i]["intApprovalid"].ToString();
                if (deptid == "136") // Drug RENEWAL
                {
                    try
                    {
                        
                    }
                    catch (Exception ex)
                    {
                    }
                }
                if (deptid == "101")// FIRE
                {
                    try
                    {
                        string valuefire = "";
                        string outputfire = "";
                        string fireattachments = "";
                        string outapplicant = "";
                        string outapplicant1 = "";
                        string outescapre = "";
                        // DataSet dsdept = new DataSet();
                        DataSet dsfire = new DataSet();
                        DataSet dsfireescape = new DataSet();
                        DataSet dsdeptattachments = new DataSet();
                        dsdept = gen.getdepartmentdetailsonuidREN(UIDNO, deptid);
                        valuefire = dsdept.GetXml();
                        string output = fireren.InsertApplicantFireDetails_RENEWAL(valuefire);
                        string[] split = output.Split('-');
                        string applid = split[1];
                        dsfire = gen.getfiremeanofescapedetailsonuidREN(UIDNO, applid);
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
                            outescapre = fireren.StoreMeansOfEscape_CFO(fireescape);
                        }
                        DataSet dsfire1 = new DataSet();
                        dsfire1 = gen.getfiremeanofescapedetailsonuidREN(UIDNO, applid);
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
                            outapplicant = fireren.StoreFloorwiseApplicantDtls_CFO(fireapplicant);
                        }
                        DataSet dsfire2 = new DataSet();
                        dsfire2 = gen.getfiremeanofescapedetailsonuidREN(UIDNO, applid);
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
                            outapplicant1 = fireren.StoreFireFightingInstallations_CFO(firefight);
                        }

                        DataSet dsdeptattachmentsfire = new DataSet();
                        dsdeptattachmentsfire = gen.getattachmentdetailsonuidREN(UIDNO, deptid, applid);
                        fireattachments = dsdeptattachmentsfire.GetXml();
                        outputfire = fireren.StoreUploadDocuments_CFO(fireattachments);
                        //StringReader str1 = new StringReader(outputfire);
                        //DataSet dsout1 = new DataSet();
                        //dsout1.ReadXml(str1);
                        if (split[0] == "Success" && outescapre == "Success" && outapplicant == "Success" && outapplicant1 == "Success" && outputfire == "Success")
                        {
                            gen.UpdateDepartwebserviceflagREN(UIDNO, deptid, "A", outapplicant, "Y");
                            gen.UpdateDepartwebserviceflagREN(UIDNO, deptid, "C", outapplicant, "Y");
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

                if (deptid == "104") // Boilers
                {
                    try
                    {
                        //BoilerService.plan boilervo = new BoilerService.plan();
                        BoilerService.renewalManufacturer boilervo = new BoilerService.renewalManufacturer();
                        // DataSet dsdept = new DataSet();
                        string valueshmwssb = "";
                        string outputhmwssb = "";
                        string outpayhmwssb = "";
                        //dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);
                        dsdept = gen.getdepartmentdetailsonuidREN(UIDNO, deptid);
                        valueshmwssb = dsdept.GetXml();
                        if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                        {
                            //boilervo.amount_tobe_paid = "";
                            //boilervo.areaofWorkshop = "";
                            //boilervo.bankAmount = "";
                            //boilervo.bankDate = "";
                            //boilervo.bankName = "";

                            boilervo.amount_tobe_paid = dsdept.Tables[0].Rows[0]["amount_tobe_paid"].ToString();
                            boilervo.bankAmount = dsdept.Tables[0].Rows[0]["bankAmount"].ToString();
                            boilervo.bankDate = dsdept.Tables[0].Rows[0]["bankDate"].ToString();
                            boilervo.bankName = dsdept.Tables[0].Rows[0]["bankName"].ToString();
                            boilervo.bankstatus = dsdept.Tables[0].Rows[0]["bankstatus"].ToString();
                            boilervo.banktransid = dsdept.Tables[0].Rows[0]["banktransid"].ToString();
                            boilervo.challanNo = dsdept.Tables[0].Rows[0]["challanNo"].ToString();
                            boilervo.ddocode = dsdept.Tables[0].Rows[0]["ddocode"].ToString();
                            boilervo.enterpreneur_id = Convert.ToInt32(dsdept.Tables[0].Rows[0]["enterpreneur_id"].ToString());
                            boilervo.hoa = dsdept.Tables[0].Rows[0]["hoa"].ToString();
                            boilervo.quessionaire_id = Convert.ToInt32(dsdept.Tables[0].Rows[0]["quessionaire_id"].ToString());
                            //
                            boilervo.districtId = dsdept.Tables[0].Rows[0]["district"].ToString();
                            boilervo.mandalId = dsdept.Tables[0].Rows[0]["mandal"].ToString();
                            boilervo.villageId = dsdept.Tables[0].Rows[0]["village"].ToString();

                            boilervo.detailedTechnical = "na";
                            boilervo.detailedMachinery = "na";
                            boilervo.detailedTesting = "na";
                            boilervo.locality = dsdept.Tables[0].Rows[0]["e_locality"].ToString();
                            boilervo.payment_status = dsdept.Tables[0].Rows[0]["payment_status"].ToString();
                            boilervo.pincode = dsdept.Tables[0].Rows[0]["e_pincode"].ToString();


                            boilervo.remittersname = dsdept.Tables[0].Rows[0]["remittersname"].ToString();
                            boilervo.system_ip = dsdept.Tables[0].Rows[0]["system_ip"].ToString();
                            boilervo.trydate = dsdept.Tables[0].Rows[0]["trydate"].ToString();
                            //
                            boilervo.user_serial_no = Convert.ToInt32(dsdept.Tables[0].Rows[0]["user_serial_no"].ToString());
                            boilervo.villageId = dsdept.Tables[0].Rows[0]["village"].ToString();


                            boilervo.firmapplicationId = dsdept.Tables[0].Rows[0]["applicationId"].ToString();
                            boilervo.firmName = dsdept.Tables[0].Rows[0]["owner_name"].ToString();

                            boilervo.yearofestablishment = "2019";// dsdept.Tables[0].Rows[0]["Establishment_Year"].ToString();
                            boilervo.firmFullResponsiblity = dsdept.Tables[0].Rows[0]["firmtoAcceptResponsibility"].ToString();
                            boilervo.firmInternalQuality = dsdept.Tables[0].Rows[0]["firmQualitycontrolsystem"].ToString();
                            boilervo.firmjobConformity = dsdept.Tables[0].Rows[0]["Firmtoexecutejob"].ToString();

                            boilervo.firmSupplyMaterials = dsdept.Tables[0].Rows[0]["firmtosupplymaterials"].ToString();

                            boilervo.equipmentType = dsdept.Tables[0].Rows[0]["Eqipment_Type"].ToString();
                            boilervo.areaofWorkshop = dsdept.Tables[0].Rows[0]["WorkShop_Area"].ToString();
                            boilervo.manufacturerMobileNo = dsdept.Tables[0].Rows[0]["e_mobile_no"].ToString();
                            boilervo.manufacturerEmailId = dsdept.Tables[0].Rows[0]["e_email"].ToString();
                            boilervo.weldersEmployed = "na";// dsdept.Tables[0].Rows[0]["e_email"].ToString();
                            boilervo.prvRegRenCertificate = dsdept.Tables[0].Rows[0]["e_email"].ToString();
                            boilervo.plotNo = dsdept.Tables[0].Rows[0]["e_door_no"].ToString();

                            BoilersCFE.anexuredocuments[] anexuredocuments = null;
                            BoilersCFE.cbbdocuments[] cbbdocument = null;
                            BoilersCFE.designdocuments[] designdocument = null;
                            BoilersCFE.formdocuments[] form = null;
                            BoilerService.testinglistdocuments[] Otherdoc = null;
                            BoilerService.machinerylistdocuments[] machdocument = null;
                            BoilerService.technicallistdocuments[] techdocuments = null;
                            BoilerService.welderslistdocuments[] welderslistdocments = null;


                            DataSet dsBoiler = new DataSet();
                            dsBoiler = gen.getattachmentdetailsonuidREN(UIDNO, deptid, "");
                            string attcvalueshmwssb = dsBoiler.GetXml();
                            if (dsBoiler != null && dsBoiler.Tables.Count > 0 && dsBoiler.Tables[0].Rows.Count > 0)
                            {
                                ///Registration Deed////

                                if (dsBoiler.Tables[0].Rows.Count > 0)
                                {
                                    DataTable dtotherdocuments = new DataTable();
                                    dtotherdocuments = dsBoiler.Tables[0];
                                    Otherdoc = new BoilerService.testinglistdocuments[dtotherdocuments.Rows.Count];

                                    for (int n = 0; n < dtotherdocuments.Rows.Count; n++)
                                    {
                                        BoilerService.testinglistdocuments otherdocvo = new BoilerService.testinglistdocuments();
                                        otherdocvo.testingdocumentName = dtotherdocuments.Rows[n]["FileName"].ToString();
                                        otherdocvo.testingdocumentPath = dtotherdocuments.Rows[n]["Filepath"].ToString();
                                        Otherdoc[n] = otherdocvo;
                                    }
                                    boilervo.testinglistdocuments = Otherdoc;

                                }
                                if (dsBoiler.Tables[0].Rows.Count > 0)
                                {
                                    DataTable dtmachinarydocuments = new DataTable();
                                    dtmachinarydocuments = dsBoiler.Tables[1];
                                    machdocument = new BoilerService.machinerylistdocuments[dtmachinarydocuments.Rows.Count];

                                    for (int n = 0; n < dtmachinarydocuments.Rows.Count; n++)
                                    {
                                        BoilerService.machinerylistdocuments machvo = new BoilerService.machinerylistdocuments();
                                        machvo.machinerydocumentName = dtmachinarydocuments.Rows[n]["FileName"].ToString();
                                        machvo.machinerydocumentPath = dtmachinarydocuments.Rows[n]["Filepath"].ToString();
                                        machdocument[n] = machvo;
                                    }
                                    boilervo.machinerylistdocuments = machdocument;

                                }
                                if (dsBoiler.Tables[0].Rows.Count > 0)
                                {
                                    DataTable dttechdocments = new DataTable();
                                    dttechdocments = dsBoiler.Tables[2];
                                    techdocuments = new BoilerService.technicallistdocuments[dttechdocments.Rows.Count];

                                    for (int n = 0; n < dttechdocments.Rows.Count; n++)
                                    {
                                        BoilerService.technicallistdocuments techvo = new BoilerService.technicallistdocuments();
                                        techvo.technicaldocumentName = dttechdocments.Rows[n]["FileName"].ToString();
                                        techvo.technicaldocumentPath = dttechdocments.Rows[n]["Filepath"].ToString();
                                        techdocuments[n] = techvo;
                                    }
                                    boilervo.technicallistdocuments = techdocuments;

                                }
                                if (dsBoiler.Tables[0].Rows.Count > 0)
                                {
                                    DataTable dtwelderslistdocments = new DataTable();
                                    dtwelderslistdocments = dsBoiler.Tables[3];
                                    welderslistdocments = new BoilerService.welderslistdocuments[dtwelderslistdocments.Rows.Count];

                                    for (int n = 0; n < dtwelderslistdocments.Rows.Count; n++)
                                    {
                                        BoilerService.welderslistdocuments weldervo = new BoilerService.welderslistdocuments();
                                        weldervo.weldersdocumentName = dtwelderslistdocments.Rows[n]["FileName"].ToString();
                                        weldervo.weldersdocumentPath = dtwelderslistdocments.Rows[n]["Filepath"].ToString();
                                        welderslistdocments[n] = weldervo;
                                    }
                                    boilervo.welderslistdocuments = welderslistdocments;

                                }


                                //if (dsBoiler.Tables[1].Rows.Count > 0)
                                //{
                                //    DataTable dtcbbdocuments = new DataTable();
                                //    dtcbbdocuments = dsBoiler.Tables[1];
                                //    cbbdocument = new BoilersCFE.cbbdocuments[dtcbbdocuments.Rows.Count];

                                //    for (int n = 0; n < dtcbbdocuments.Rows.Count; n++)
                                //    {
                                //        BoilersCFE.cbbdocuments cbbvo = new BoilersCFE.cbbdocuments();
                                //        cbbvo.documentName = dtcbbdocuments.Rows[n]["FileName"].ToString();
                                //        cbbvo.documentPath = dtcbbdocuments.Rows[n]["Filepath"].ToString();
                                //        cbbdocument[n] = cbbvo;
                                //    }
                                //    boilervo.cbbdocuments = cbbdocument;
                                //}
                                //if (dsBoiler.Tables[2].Rows.Count > 0)
                                //{
                                //    DataTable dtdesigndocuments = new DataTable();
                                //    dtdesigndocuments = dsBoiler.Tables[2];
                                //    designdocument = new BoilersCFE.designdocuments[dtdesigndocuments.Rows.Count];

                                //    for (int n = 0; n < dtdesigndocuments.Rows.Count; n++)
                                //    {
                                //        BoilerService.designdocuments designvo = new BoilerService.designdocuments();
                                //        designvo.documentName = dtdesigndocuments.Rows[n]["FileName"].ToString();
                                //        designvo.documentPath = dtdesigndocuments.Rows[n]["Filepath"].ToString();
                                //        designdocument[n] = designvo;
                                //    }
                                //    boilervo.designdocuments = designdocument;
                                //}
                                //if (dsBoiler.Tables[3].Rows.Count > 0)
                                //{
                                //    DataTable dtformdocuments = new DataTable();
                                //    dtformdocuments = dsBoiler.Tables[3];
                                //    form = new BoilersCFE.formdocuments[dtformdocuments.Rows.Count];

                                //    for (int n = 0; n < dtformdocuments.Rows.Count; n++)
                                //    {
                                //        BoilersCFE.formdocuments formvo = new BoilersCFE.formdocuments();
                                //        formvo.documentName = dtformdocuments.Rows[n]["FileName"].ToString();
                                //        formvo.documentPath = dtformdocuments.Rows[n]["Filepath"].ToString();
                                //        form[n] = formvo;
                                //    }
                                //    boilervo.formdocuments = form;
                                //}

                                //if (dsBoiler.Tables[4].Rows.Count > 0)
                                //{
                                //    DataTable dtanexuredocuments = new DataTable();
                                //    dtanexuredocuments = dsBoiler.Tables[4];
                                //    anexuredocuments = new BoilersCFE.anexuredocuments[dtanexuredocuments.Rows.Count];

                                //    for (int n = 0; n < dtanexuredocuments.Rows.Count; n++)
                                //    {
                                //        BoilersCFE.anexuredocuments annexurevo = new BoilersCFE.anexuredocuments();
                                //        annexurevo.documentName = dtanexuredocuments.Rows[n]["FileName"].ToString();
                                //        annexurevo.documentPath = dtanexuredocuments.Rows[n]["Filepath"].ToString();
                                //        anexuredocuments[n] = annexurevo;
                                //    }
                                //    boilervo.anexuredocuments = anexuredocuments;
                                //}
                            }



                            string boilerout = BoilerRenewalservice.renewalBoilerManufacturer(boilervo);//SUCCESS
                            if (boilerout == "SUCCESS")
                            {

                                gen.UpdateDepartwebserviceflagREN(UIDNO, deptid, "C", boilerout, "Y");
                                gen.UpdateDepartwebserviceflagREN(UIDNO, deptid, "A", boilerout, "N");
                                //int k = gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["intDeptid"].ToString(), dsdept.Tables[0].Rows[0]["quessionaire_id"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                                int k = gen.InsertDeptDateTracingREN("56", dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "REN", deptid);
                            }
                            else
                            {
                                gen.UpdateDepartwebserviceflagREN(UIDNO, deptid, "C", boilerout, "N");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
                if (deptid == "53")
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                    dsdept = gen.getdepartmentdetailsonuidREN(UIDNO, deptid);
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
                                            gen.UpdateDepartwebserviceflagREN(UIDNO, deptid, "C", jsonResponse, "Y");
                                            //int k = gen.InsertDeptDateTracing("20", dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", "20");
                                        }
                                        else
                                        {
                                            //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                            gen.UpdateDepartwebserviceflagREN(UIDNO, deptid, "C", jsonResponse, "N");
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
                if (deptid == "55")
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

                    BoilerService.renewalDetails boilerrenvo = new BoilerService.renewalDetails();
                    //string deptid = dt.Rows[i]["intApprovalid"].ToString();
                    dsdept = gen.getdepartmentdetailsonuidREN(UIDNO, deptid);
                    string boilerdata = dsdept.GetXml();
                    if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                    {
                        boilerrenvo.amount_tobe_paid = dsdept.Tables[0].Rows[0]["amount_tobe_paid"].ToString();
                        // boilerrenvo.anexuredocuments = dsdept.Tables[0].Rows[0]["anexuredocuments"].ToString();
                        boilerrenvo.application_stage = Convert.ToInt32(dsdept.Tables[0].Rows[0]["application_stage"].ToString());
                        boilerrenvo.applicationId = dsdept.Tables[0].Rows[0]["applicationId"].ToString();
                        boilerrenvo.bankAmount = dsdept.Tables[0].Rows[0]["bankAmount"].ToString();
                        boilerrenvo.bankDate = dsdept.Tables[0].Rows[0]["bankDate"].ToString();
                        boilerrenvo.bankName = dsdept.Tables[0].Rows[0]["bankName"].ToString();
                        boilerrenvo.bankstatus = dsdept.Tables[0].Rows[0]["bankstatus"].ToString();
                        boilerrenvo.banktransid = dsdept.Tables[0].Rows[0]["banktransid"].ToString();
                        boilerrenvo.boiler_376 = dsdept.Tables[0].Rows[0]["boiler_376"].ToString();
                        
                        boilerrenvo.boiler_maker_name = dsdept.Tables[0].Rows[0]["boiler_maker_name"].ToString();
                        boilerrenvo.boiler_maker_no = dsdept.Tables[0].Rows[0]["boiler_maker_no"].ToString();
                        boilerrenvo.boiler_rating = dsdept.Tables[0].Rows[0]["boiler_rating"].ToString();
                        boilerrenvo.boiler_used_for = dsdept.Tables[0].Rows[0]["boiler_used_for"].ToString();
                        // boilerrenvo.cbbdocuments = dsdept.Tables[0].Rows[0]["cbbdocuments"].ToString();
                        boilerrenvo.challanNo = dsdept.Tables[0].Rows[0]["challanNo"].ToString();
                        boilerrenvo.class_of_repairer = dsdept.Tables[0].Rows[0]["class_of_repairer"].ToString();
                        boilerrenvo.competent_person = dsdept.Tables[0].Rows[0]["competent_person"].ToString();
                        //boilerrenvo.component_person_details = dsdept.Tables[0].Rows[0]["component_person_details"].ToString();
                        boilerrenvo.created_by = Convert.ToInt32(dsdept.Tables[0].Rows[0]["created_by"].ToString());
                        boilerrenvo.ddocode = dsdept.Tables[0].Rows[0]["ddocode"].ToString();
                        // boilerrenvo.designdocuments = dsdept.Tables[0].Rows[0]["designdocuments"].ToString();
                        boilerrenvo.details_of_repairs = dsdept.Tables[0].Rows[0]["details_of_repairs"].ToString();
                        boilerrenvo.details_of_repairs_path = dsdept.Tables[0].Rows[0]["details_of_repairs_path"].ToString();
                        boilerrenvo.district = dsdept.Tables[0].Rows[0]["district"].ToString();
                        boilerrenvo.door_no = dsdept.Tables[0].Rows[0]["door_no"].ToString();
                        boilerrenvo.enterpreneur_id = Convert.ToInt32(dsdept.Tables[0].Rows[0]["enterpreneur_id"].ToString());
                        boilerrenvo.exemption_boilers = dsdept.Tables[0].Rows[0]["exemption_boilers"].ToString();
                        boilerrenvo.exemption_document = dsdept.Tables[0].Rows[0]["exemption_document"].ToString();
                        boilerrenvo.expire_pre_cer_date = dsdept.Tables[0].Rows[0]["expire_pre_cer_date"].ToString();
                        boilerrenvo.fee = dsdept.Tables[0].Rows[0]["fee"].ToString();
                        // boilerrenvo.formdocuments = dsdept.Tables[0].Rows[0]["formdocuments"].ToString();
                        boilerrenvo.hoa = dsdept.Tables[0].Rows[0]["hoa"].ToString();
                        boilerrenvo.inspection_letter = dsdept.Tables[0].Rows[0]["inspection_letter"].ToString();
                        boilerrenvo.inspection_required = dsdept.Tables[0].Rows[0]["inspection_required"].ToString();
                        boilerrenvo.inspector_authority_flag = Convert.ToInt32(dsdept.Tables[0].Rows[0]["inspector_authority_flag"].ToString());
                        boilerrenvo.length_pipeline = dsdept.Tables[0].Rows[0]["length_pipeline"].ToString();
                        boilerrenvo.locality = dsdept.Tables[0].Rows[0]["locality"].ToString();
                        boilerrenvo.mandal = dsdept.Tables[0].Rows[0]["mandal"].ToString();
                        boilerrenvo.max_evaporation = dsdept.Tables[0].Rows[0]["max_evaporation"].ToString();
                        boilerrenvo.max_pressure = dsdept.Tables[0].Rows[0]["max_pressure"].ToString();
                        boilerrenvo.modeofpayment = dsdept.Tables[0].Rows[0]["modeofpayment"].ToString();
                        boilerrenvo.name_of_repairer = dsdept.Tables[0].Rows[0]["name_of_repairer"].ToString();

                        boilerrenvo.owner_contact_no = dsdept.Tables[0].Rows[0]["owner_contact_no"].ToString();
                        boilerrenvo.owner_email = dsdept.Tables[0].Rows[0]["owner_email"].ToString();
                        boilerrenvo.owner_name = dsdept.Tables[0].Rows[0]["owner_name"].ToString();
                        boilerrenvo.payment_status = dsdept.Tables[0].Rows[0]["payment_status"].ToString();
                        boilerrenvo.pincode = dsdept.Tables[0].Rows[0]["pincode"].ToString();
                        boilerrenvo.quessionaire_id = Convert.ToInt32(dsdept.Tables[0].Rows[0]["quessionaire_id"].ToString());
                        boilerrenvo.registration_of_steampipe_line = dsdept.Tables[0].Rows[0]["registration_of_steampipe_line"].ToString();
                        boilerrenvo.remarks = dsdept.Tables[0].Rows[0]["remarks"].ToString();
                        boilerrenvo.remittersname = dsdept.Tables[0].Rows[0]["remittersname"].ToString();
                        boilerrenvo.repairs = dsdept.Tables[0].Rows[0]["repairs"].ToString();
                        boilerrenvo.required_documents = dsdept.Tables[0].Rows[0]["required_documents"].ToString();
                        boilerrenvo.supporting_documents = dsdept.Tables[0].Rows[0]["supporting_documents"].ToString();
                        boilerrenvo.system_ip = dsdept.Tables[0].Rows[0]["system_ip"].ToString();
                        boilerrenvo.trydate = dsdept.Tables[0].Rows[0]["trydate"].ToString();
                        boilerrenvo.type_of_boiler = dsdept.Tables[0].Rows[0]["type_of_boiler"].ToString();
                        boilerrenvo.upload_form5 = dsdept.Tables[0].Rows[0]["upload_form5"].ToString();
                        boilerrenvo.user_serial_no = Convert.ToInt32(dsdept.Tables[0].Rows[0]["user_serial_no"].ToString());
                        boilerrenvo.village = dsdept.Tables[0].Rows[0]["village"].ToString();
                        boilerrenvo.thirdparty_authority = dsdept.Tables[0].Rows[0]["Thirdparttype"].ToString();
                        boilerrenvo.supporting_documents = dsdept.Tables[0].Rows[0]["supporting_documents"].ToString();
                        boilerrenvo.details_of_repairs_path = "";

                        if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[1].Rows.Count > 0)
                        {
                            boilerrenvo.harithaNidhiAmount = Convert.ToInt32(dsdept.Tables[1].Rows[0]["Online_Amount"].ToString());
                            boilerrenvo.harithaNidhitrydate = dsdept.Tables[1].Rows[0]["TransactionDate"].ToString();
                            boilerrenvo.harithaNidhiremittersname = dsdept.Tables[1].Rows[0]["BankName"].ToString();
                            boilerrenvo.harithaNidhibankStatus = dsdept.Tables[1].Rows[0]["PaymentFlag"].ToString();
                            boilerrenvo.harithaNidhibanktransid = dsdept.Tables[1].Rows[0]["TransactionNO"].ToString();
                            boilerrenvo.harithaNidhiAmount = Convert.ToDouble(dsdept.Tables[1].Rows[0]["Online_Amount"].ToString());
                        }

                        //BoilerServiceTest.otherdocuments[] othdoc = null;
                        //BoilerService.otherdocuments othdocvo = new BoilerService.otherdocuments();
                        //othdocvo.documentName = dsdept.Tables[0].Rows[0]["AttachmentFilename"].ToString();
                        //othdocvo.documentPath = dsdept.Tables[0].Rows[0]["otherdocuments"].ToString();
                        BoilerService.anexuredocuments[] anexuredocuments = null;
                        BoilerService.cbbdocuments[] cbbdocument = null;
                        BoilerService.formdocuments[] form = null;
                        BoilerService.otherdocuments[] Otherdoc = null;
                        BoilerService.designdocuments[] boedocuments = null;


                        DataSet dsBoiler = new DataSet();
                        dsBoiler = gen.getattachmentdetailsonuidREN(UIDNO, deptid, "");
                        string attcvalueshmwssb = dsBoiler.GetXml();
                        if (dsBoiler != null)
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
                                boilerrenvo.otherdocuments = Otherdoc;

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
                                boilerrenvo.cbbdocuments = cbbdocument;
                            }

                            if (dsBoiler.Tables[2].Rows.Count > 0)
                            {
                                DataTable dtformdocuments = new DataTable();
                                dtformdocuments = dsBoiler.Tables[2];
                                form = new BoilerService.formdocuments[dtformdocuments.Rows.Count];

                                for (int n = 0; n < dtformdocuments.Rows.Count; n++)
                                {
                                    BoilerService.formdocuments formvo = new BoilerService.formdocuments();
                                    formvo.documentName = dtformdocuments.Rows[n]["FileName"].ToString();
                                    formvo.documentPath = dtformdocuments.Rows[n]["Filepath"].ToString();
                                    form[n] = formvo;
                                }
                                boilerrenvo.formdocuments = form;
                            }

                            if (dsBoiler.Tables[3].Rows.Count > 0)
                            {
                                DataTable dtanexuredocuments = new DataTable();
                                dtanexuredocuments = dsBoiler.Tables[3];
                                anexuredocuments = new BoilerService.anexuredocuments[dtanexuredocuments.Rows.Count];

                                for (int n = 0; n < dtanexuredocuments.Rows.Count; n++)
                                {
                                    BoilerService.anexuredocuments annexurevo = new BoilerService.anexuredocuments();
                                    annexurevo.documentName = dtanexuredocuments.Rows[n]["FileName"].ToString();
                                    annexurevo.documentPath = dtanexuredocuments.Rows[n]["Filepath"].ToString();
                                    anexuredocuments[n] = annexurevo;
                                }
                                boilerrenvo.anexuredocuments = anexuredocuments;
                            }
                            if (dsBoiler.Tables[4].Rows.Count > 0)
                            {
                                DataTable dtrepairerdocuments = new DataTable();
                                dtrepairerdocuments = dsBoiler.Tables[4];
                                //anexuredocuments = new BoilerServiceTest.repai [dtanexuredocuments.Rows.Count];

                                //for (int n = 0; n < dtanexuredocuments.Rows.Count; n++)
                                //{
                                //    BoilerServiceTest.anexuredocuments annexurevo = new BoilerServiceTest.anexuredocuments();
                                //    annexurevo.documentName = dtanexuredocuments.Rows[n]["FileName"].ToString();
                                //    annexurevo.documentPath = dtanexuredocuments.Rows[n]["Filepath"].ToString();
                                //    anexuredocuments[n] = annexurevo;
                                //}
                                boilerrenvo.details_of_repairs_path = dtrepairerdocuments.Rows[0]["Filepath"].ToString();
                            }
                            if (dsBoiler.Tables[5].Rows.Count > 0)
                            {
                                DataTable dtboecertificationdocuments = new DataTable();
                                dtboecertificationdocuments = dsBoiler.Tables[5];
                                boedocuments = new BoilerService.designdocuments[dtboecertificationdocuments.Rows.Count];

                                for (int n = 0; n < dtboecertificationdocuments.Rows.Count; n++)
                                {
                                    BoilerService.designdocuments boecertificationvo = new BoilerService.designdocuments();
                                    boecertificationvo.documentName = dtboecertificationdocuments.Rows[n]["FileName"].ToString();
                                    boecertificationvo.documentPath = dtboecertificationdocuments.Rows[n]["Filepath"].ToString();
                                    boedocuments[n] = boecertificationvo;
                                }
                                boilerrenvo.boedocuments = boedocuments;
                            }
                            if (dsBoiler.Tables[6].Rows.Count > 0)
                            {
                                DataTable dtboecertificationdocuments = new DataTable();
                                dtboecertificationdocuments = dsBoiler.Tables[6];
                                boedocuments = new BoilerService.designdocuments[dtboecertificationdocuments.Rows.Count];

                                for (int n = 0; n < dtboecertificationdocuments.Rows.Count; n++)
                                {
                                    BoilerService.designdocuments boecertificationvo = new BoilerService.designdocuments();
                                    boecertificationvo.documentName = dtboecertificationdocuments.Rows[n]["FileName"].ToString();
                                    boecertificationvo.documentPath = dtboecertificationdocuments.Rows[n]["Filepath"].ToString();
                                    boedocuments[n] = boecertificationvo;
                                }
                                boilerrenvo.boequalificationdocs = boedocuments;
                            }
                            
                        }
                        string output = BoilerRenewalservice.renewalofBoilers(boilerrenvo);
                        if (output == "SUCCESS")
                        {
                            gen.UpdateDepartwebserviceflagREN(UIDNO, deptid, "C", output, "Y");
                            int k = gen.InsertDeptDateTracingREN("56", dsdept.Tables[0].Rows[0]["quessionaire_id"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "REN", deptid);
                        }
                    }

                }
                if (deptid == "54")
                {
                    
                    FactoryRenewalService.factoryAnnualLicenseFee factoryvo = new FactoryRenewalService.factoryAnnualLicenseFee();
                    FactoryRenewalService.approvedCertificateDetailsResponse factoryoutput = new FactoryRenewalService.approvedCertificateDetailsResponse();
                    dsdept = gen.getdepartmentdetailsonuidREN(UIDNO, deptid);
                    string ptxml = dsdept.GetXml();
                    if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                    {
                        //string cafUniqueNo = dsdept.Tables[0].Rows[0][""].ToString();
                        factoryvo.adjustmentOnAnnualLicenseFee = dsdept.Tables[0].Rows[0]["adjustmentOnAnnualLicenseFee"].ToString();
                        factoryvo.annualLicenseFee = dsdept.Tables[0].Rows[0]["annualLicenseFee"].ToString();
                        factoryvo.annualLicenseFeePayable = dsdept.Tables[0].Rows[0]["annualLicenseFeePayable"].ToString();
                        factoryvo.applicantEMailID = dsdept.Tables[0].Rows[0]["applicantEMailID"].ToString();
                        factoryvo.applicantMobileNumber = dsdept.Tables[0].Rows[0]["applicantMobileNumber"].ToString();
                        factoryvo.applicationID = dsdept.Tables[0].Rows[0]["applicationID"].ToString();
                        factoryvo.applicationSubmittedDate = dsdept.Tables[0].Rows[0]["applicationSubmittedDate"].ToString();
                        factoryvo.arrearsAmount = dsdept.Tables[0].Rows[0]["arrearsAmount"].ToString();
                        factoryvo.bankName = dsdept.Tables[0].Rows[0]["bankName"].ToString();
                        factoryvo.carryForwardAdjustmentFee = dsdept.Tables[0].Rows[0]["carryForwardAdjustmentFee"].ToString();
                        factoryvo.entrepreneurID = dsdept.Tables[0].Rows[0]["entrepreneurID"].ToString();
                        factoryvo.factoryAddress = dsdept.Tables[0].Rows[0]["factoryAddress"].ToString();
                        factoryvo.factoryCircleID = dsdept.Tables[0].Rows[0]["factoryCircleID"].ToString();
                        factoryvo.factoryCircleName = dsdept.Tables[0].Rows[0]["factoryCircleName"].ToString();
                        factoryvo.factoryHP = dsdept.Tables[0].Rows[0]["factoryHP"].ToString();
                        factoryvo.factoryLicenseNumber = dsdept.Tables[0].Rows[0]["factoryLicenseNumber"].ToString();
                        factoryvo.factoryName = dsdept.Tables[0].Rows[0]["factoryName"].ToString();
                        factoryvo.factoryNumberOfEmployees = dsdept.Tables[0].Rows[0]["factoryNumberOfEmployees"].ToString();
                        factoryvo.factoryRegistrationNumber = dsdept.Tables[0].Rows[0]["factoryRegistrationNumber"].ToString();
                        factoryvo.interestOnAnnualLicenseFee = dsdept.Tables[0].Rows[0]["interestOnAnnualLicenseFee"].ToString();
                        factoryvo.interestOnArrearsAmount = dsdept.Tables[0].Rows[0]["interestOnArrearsAmount"].ToString();
                        factoryvo.isAdjustmentOnAnnualLicenseFeeAvailable = "TRUE";// dsdept.Tables[0].Rows[0]["isAdjustmentOnAnnualLicenseFeeAvailable"].ToString();
                        factoryvo.isZeroAmountPayableAfterAdjustment = "FALSE";// dsdept.Tables[0].Rows[0]["isZeroAmountPayableAfterAdjustment"].ToString();
                        //factoryvo.is
                        factoryvo.licenseValidFrom = Convert.ToString(DateTime.ParseExact(dsdept.Tables[0].Rows[0]["licenseValidFrom"].ToString(), "dd-MM-yyyy", null).ToString("dd-MMM-yyyy")).ToUpper();// dsdept.Tables[0].Rows[0]["licenseValidFrom"].ToString();
                        //factoryvo.licenseValidUpto = Convert.ToString(dsdept.Tables[0].Rows[0]["licenseValidUpto"]).ToString("dd-MMM-YYYY"); //"31-DEC-2020";// 
                        factoryvo.licenseValidUpto =  Convert.ToString(DateTime.ParseExact(dsdept.Tables[0].Rows[0]["licenseValidUpto"].ToString(), "dd-MM-yyyy", null).ToString("dd-MMM-yyyy")).ToUpper();
                        factoryvo.paymentAmount = dsdept.Tables[0].Rows[0]["paymentAmount"].ToString();
                        factoryvo.paymentDate = dsdept.Tables[0].Rows[0]["paymentDate"].ToString();
                        factoryvo.paymentStatus = dsdept.Tables[0].Rows[0]["paymentStatus"].ToString();
                        factoryvo.questionaireID = dsdept.Tables[0].Rows[0]["questionaireID"].ToString();
                        factoryvo.resultantNoOfPayableYears = dsdept.Tables[0].Rows[0]["resultantNoOfPayableYears"].ToString();
                        factoryvo.selectedCalendarYear = dsdept.Tables[0].Rows[0]["selectedCalendarYear"].ToString();
                        factoryvo.selectedNumberOfLicenseYears = dsdept.Tables[0].Rows[0]["selectedNumberOfLicenseYears"].ToString();
                        factoryvo.systemIP = dsdept.Tables[0].Rows[0]["systemIP"].ToString();
                        factoryvo.totalFee = dsdept.Tables[0].Rows[0]["totalFee"].ToString();
                        factoryvo.transactionNumber = dsdept.Tables[0].Rows[0]["transactionNumber"].ToString();
                        factoryvo.userID = dsdept.Tables[0].Rows[0]["userID"].ToString();
                        if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[1].Rows.Count > 0)
                        {
                            factoryvo.harithaNidhiAmount = Convert.ToInt32(dsdept.Tables[1].Rows[0]["Online_Amount"].ToString());
                            factoryvo.harithaPaymentDate = dsdept.Tables[1].Rows[0]["TransactionDate"].ToString();
                            factoryvo.harithaBankName = dsdept.Tables[1].Rows[0]["BankName"].ToString();
                            factoryvo.harithaPaymentStatus = dsdept.Tables[1].Rows[0]["PaymentFlag"].ToString();
                            factoryvo.harithaTransactionNumber = dsdept.Tables[1].Rows[0]["TransactionNO"].ToString();
                            factoryvo.harithaPaymentAmount = dsdept.Tables[1].Rows[0]["Online_Amount"].ToString();
                        }

                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                        factoryoutput = factoryren.insertFactoryAnnualLicenseFeeDetails(factoryvo);
                        if (factoryoutput.status == "SUCCESS")
                        {
                            FactoryRenewalService.approvedCertificateDetailsResponse renoutput = new FactoryRenewalService.approvedCertificateDetailsResponse();
                            FactoryRenewalService.approvedCertificateDetails vo = new FactoryRenewalService.approvedCertificateDetails();
                            FactoryRenewalService.approvedCertificateDetails[] vooutput=null;
                            vooutput = factoryoutput.approvedCertificateDetails;
                             int factorycount =vooutput.Length;
                             for (int m = 0; m < factorycount; m++)
                             {
                                 vo = factoryoutput.approvedCertificateDetails[m];
                                 tsipassobj.DepartmentApprovalProcessAndCertificateUploadREN(dsdept.Tables[0].Rows[0]["questionaireID"].ToString(),
                                     dsdept.Tables[0].Rows[0]["entrepreneurID"].ToString(), "54", "9", "13", vo.documentName, vo.documentPath, "Approval",
                                     vo.documentName, "");
                             }
                           
                            gen.UpdateDepartwebserviceflagREN(UIDNO, deptid, "C", "SUCCESS", "Y");
                            int k = gen.InsertDeptDateTracingREN("9", dsdept.Tables[0].Rows[0]["questionaireID"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "REN", deptid);

                        }

                    }
                }

            }
        }
        if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
        {
            DataTable dtadd = new DataTable();
            dtadd = ds.Tables[1];
            for (int j = 0; j < dtadd.Rows.Count; j++)
            {
                string deptid1 = dtadd.Rows[j]["intApprovalid"].ToString();
                if (deptid1 == "53")
                {
                    //DataSet dsdept = new DataSet();

                    dsdept = gen.getAdditionalPaymentDetailsREN(UIDNO, deptid1);
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

                        string WEBSERVICE_URL1 = "http://tsocmms.nic.in/TLWS/updateCl?cafUniqueNo=" + cafUniqueNo + "&indApplicationNo=" + indApplication + "&remark=" + "AdditionalAmountSubmitted" + "&urlSingle=" + "";

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
                                            gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid1, "AP", jsonResponse, "Y");
                                        }
                                        else
                                        {
                                            //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                            gen.UpdateDepartwebserviceflagREN(UIDNO, deptid1, "AP", jsonResponse, "N");
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(ex.ToString());
                        }


                        string WEBSERVICE_URL = "http://tsocmms.nic.in/TLWS/updateFee?cafUniqueNo=" + cafUniqueNo + "&transactionId=" + transactionId + "&amount=" + amount + "&bankName=" + bankName + "&transactionStatus=" + transactionStatus + "&paymentType=" + paymentType + "&indApplicationNo=" + indApplication + "&additionalPayment=" + additionalPayment + "";


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
                                            gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid1, "AP", jsonResponse, "Y");
                                        }
                                        else
                                        {
                                            //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                            gen.UpdateDepartwebserviceflagREN(UIDNO, deptid1, "AP", jsonResponse, "Y");
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
                if (deptid1 == "55")
                {
                    dsdept = gen.getAdditionalPaymentDetailsREN(UIDNO, deptid1);
                    if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                    {
                        BoilerService.renewalAdditionalPayment renewaladditionalvo = new BoilerService.renewalAdditionalPayment();
                        renewaladditionalvo.applicationID = dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                        renewaladditionalvo.bankAmount = dsdept.Tables[0].Rows[0]["Online_Amount"].ToString();
                        renewaladditionalvo.bankDate = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                        renewaladditionalvo.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                        renewaladditionalvo.bankstatus = dsdept.Tables[0].Rows[0]["IsActive"].ToString();
                        renewaladditionalvo.banktransid = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                        //renewaladditionalvo.boilerrating = "50";// dsdept.Tables[0].Rows[0]["boilerrating"].ToString();
                        renewaladditionalvo.challanNumber = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                        renewaladditionalvo.ddocode = dsdept.Tables[0].Rows[0]["ddocode"].ToString();
                        renewaladditionalvo.department_transaction_id = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                        renewaladditionalvo.entrepreneurRemarks = dsdept.Tables[0].Rows[0]["entrepreneurRemarks"].ToString();
                        renewaladditionalvo.hoa = dsdept.Tables[0].Rows[0]["hoa"].ToString();
                        renewaladditionalvo.remittersname = dsdept.Tables[0].Rows[0]["remittersname"].ToString();
                        //renewaladditionalvo.steampipelinelength = "0";// dsdept.Tables[0].Rows[0]["steampipelinelength"].ToString();
                        renewaladditionalvo.systemIP = "0000";// dsdept.Tables[0].Rows[0][""].ToString();
                        renewaladditionalvo.trydate = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                        renewaladditionalvo.userID = dsdept.Tables[0].Rows[0]["Created_by"].ToString();

                        string paymentoutput = BoilerRenewalservice.insertIntoRenewalAdditionalPayment(renewaladditionalvo);
                        if (paymentoutput == "SUCCESS")
                        {
                            gen.UpdateDepartwebserviceflagREN(UIDNO, "55", "AP", paymentoutput, "Y");
                        }
                    }
                }
            }

        }

        if (ds != null && ds.Tables.Count > 1 && ds.Tables[2].Rows.Count > 0)
        {
            DataTable dtadd = new DataTable();
            dtadd = ds.Tables[2];
            for (int i = 0; i < dtadd.Rows.Count; i++)
            {
                string deptid = dtadd.Rows[i]["intApprovalid"].ToString();
                string intquestionnaireid = dtadd.Rows[i]["intQuessionaireid"].ToString();
                if (deptid == "104")
                {
                    try
                    {
                        BoilerService.manufacturerRenewalResponseDetails boilerrenqueryvo = new BoilerService.manufacturerRenewalResponseDetails();
                        DataSet dsdeptquery = new DataSet();
                        dsdeptquery = gen.GetQueryStatusByTransactionIDRenewalResponse(intquestionnaireid, "104");

                        boilerrenqueryvo.applicationID = dsdeptquery.Tables[0].Rows[0]["UID_No"].ToString();
                        boilerrenqueryvo.entrepreneurRemarks = dsdeptquery.Tables[0].Rows[0]["QueryRespondRemarks"].ToString();
                        boilerrenqueryvo.systemIP = "0:0:0:0";
                        boilerrenqueryvo.userID = dsdeptquery.Tables[0].Rows[0]["Created_by"].ToString();
                        BoilerService.queryResponseAttachment[] lst = null;
                        BoilerService.queryResponseAttachment boilerqueryvo = new BoilerService.queryResponseAttachment();
                        if (dsdeptquery.Tables[1].Rows.Count > 0)
                        {
                            DataTable dtraw = new DataTable();
                            dtraw = dsdeptquery.Tables[1];
                            lst = new BoilerService.queryResponseAttachment[dtraw.Rows.Count];
                            if (dsdeptquery.Tables[1].Rows.Count > 0)
                            {
                                for (int k = 0; k < dtraw.Rows.Count; k++)
                                {

                                    boilerqueryvo.documentName = dtraw.Rows[k]["FileName"].ToString();
                                    boilerqueryvo.documentPath = dtraw.Rows[k]["link"].ToString();
                                    lst[k] = boilerqueryvo;
                                    //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                                    //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                                }
                            }
                            else
                            {
                                boilerqueryvo.documentName = "NA";
                                boilerqueryvo.documentPath = "NA";
                            }
                            boilerrenqueryvo.queryResponseAttachments = lst;
                        }

                        string queryresponse = BoilerRenewalservice.manufacturerRenewalQueryResponse(boilerrenqueryvo);
                        if (queryresponse == "SUCCESS")
                        {
                            gen.UpdateDepartwebserviceflagREN(UIDNO, "104", "Q", queryresponse, "Y");
                            int k = gen.InsertDeptDateTracingREN("56", dsdept.Tables[0].Rows[0]["questionaireID"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "REN", "104");
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
                if (deptid == "55")
                {
                    try
                    {
                        BoilerService.renewalResponseDetails boilerrenqueryvo = new BoilerService.renewalResponseDetails();
                        DataSet dsdeptquery = new DataSet();
                        dsdeptquery = gen.GetQueryStatusByTransactionIDRenewalResponse(intquestionnaireid, "55");

                        boilerrenqueryvo.applicationID = dsdeptquery.Tables[0].Rows[0]["UID_No"].ToString();
                        boilerrenqueryvo.entrepreneurRemarks = dsdeptquery.Tables[0].Rows[0]["QueryRespondRemarks"].ToString();
                        boilerrenqueryvo.systemIP = "0:0:0:0";
                        boilerrenqueryvo.userID = dsdeptquery.Tables[0].Rows[0]["Created_by"].ToString();
                        BoilerService.queryResponseAttachment[] lst = null;
                        BoilerService.queryResponseAttachment boilerqueryvo = new BoilerService.queryResponseAttachment();
                        if (dsdeptquery.Tables[1].Rows.Count > 0)
                        {
                            DataTable dtraw = new DataTable();
                            dtraw = dsdeptquery.Tables[1];
                            lst = new BoilerService.queryResponseAttachment[dtraw.Rows.Count];
                            if (dsdeptquery.Tables[1].Rows.Count > 0)
                            {
                                for (int k = 0; k < dtraw.Rows.Count; k++)
                                {

                                    boilerqueryvo.documentName = dtraw.Rows[k]["FileName"].ToString();
                                    boilerqueryvo.documentPath = dtraw.Rows[k]["link"].ToString();
                                    lst[k] = boilerqueryvo;
                                    //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                                    //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                                }
                            }
                            else
                            {
                                boilerqueryvo.documentName = "NA";
                                boilerqueryvo.documentPath = "NA";
                            }
                            boilerrenqueryvo.queryResponseAttachments = lst;
                        }

                        string queryresponse = BoilerRenewalservice.renewalQueryResponse(boilerrenqueryvo);
                        if (queryresponse == "SUCCESS")
                        {
                            gen.UpdateDepartwebserviceflagREN(UIDNO, "55", "Q", queryresponse, "Y");
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
                 if (deptid == "101") //FIRE
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = //SecurityProtocolType.Tls12;
                    SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                    DataSet dsdeptquery = new DataSet();
                    dsdeptquery = gen.GetQueryStatusByTransactionIDRenewalResponse(intquestionnaireid, "101");
                    string filepath = dsdeptquery.Tables[0].Rows[0]["queryRespDocPath"].ToString();
                    string remarks = dsdeptquery.Tables[0].Rows[0]["QueryRespondRemarks"].ToString();
                    string filepath1 = dsdeptquery.Tables[0].Rows[0]["queryRespDocPath"].ToString();

                    string OUTPUT = fireren.StoreQueryResponse_CFO(UIDNO, filepath1, remarks);
                    if (OUTPUT == "Success")
                    {
                        gen.UpdateDepartwebserviceflagREN(UIDNO, "101", "Q", OUTPUT, "Y");

                    }
                    else
                    {
                        gen.UpdateDepartwebserviceflagREN(UIDNO, "101", "Q", OUTPUT, "N");

                    }
                }

            }
        }
        if (ds != null && ds.Tables.Count > 1 && ds.Tables[3].Rows.Count > 0)
        {
            DataTable dtadd = new DataTable();
            dtadd = ds.Tables[3];
            for (int i = 0; i < dtadd.Rows.Count; i++)
            {
                string deptid = dtadd.Rows[i]["intApprovalid"].ToString();
                string intquestionnaireid = dtadd.Rows[i]["intQuessionaireid"].ToString();

                BoilerService.renewalRequestforReschduleinspection BoilerReschdulevo = new BoilerService.renewalRequestforReschduleinspection();
                // BoilerServiceTest.renewalReschduleSteamTest BoilerReschdulevo = new BoilerServiceTest.renewalReschduleSteamTest();
                DataSet dsdeptquery = new DataSet();
                dsdeptquery = gen.getEnterprenuerRenewalBoilerdashboarddrilldown(intquestionnaireid, "", intquestionnaireid, "");
                BoilerReschdulevo.application_id = dsdeptquery.Tables[0].Rows[0]["UID_No"].ToString();
                BoilerReschdulevo.reschdule_hydraulicdate = dsdeptquery.Tables[0].Rows[0]["ReschduleHydraulicTestdate"].ToString();
                BoilerReschdulevo.reschdule_inspectiondate = dsdeptquery.Tables[0].Rows[0]["Reschduleinspectiondate"].ToString();
                //BoilerReschdulevo.uploadreschduledocuments="";
                BoilerReschdulevo.systemIP = "000";
                BoilerReschdulevo.userID = dsdeptquery.Tables[0].Rows[0]["Created_by"].ToString();

                BoilerService.queryResponseAttachment[] lst = null;
                BoilerService.queryResponseAttachment boilerqueryvo = new BoilerService.queryResponseAttachment();
                if (dsdeptquery.Tables[2].Rows.Count > 0)
                {
                    DataTable dtraw = new DataTable();
                    dtraw = dsdeptquery.Tables[2];
                    lst = new BoilerService.queryResponseAttachment[dtraw.Rows.Count];
                    if (dsdeptquery.Tables[2].Rows.Count > 0)
                    {
                        for (int k = 0; k < dtraw.Rows.Count; k++)
                        {

                            boilerqueryvo.documentName = dtraw.Rows[k]["FileName"].ToString();
                            boilerqueryvo.documentPath = dtraw.Rows[k]["link"].ToString();
                            lst[k] = boilerqueryvo;
                            //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                            //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                        }
                    }
                    else
                    {
                        boilerqueryvo.documentName = "NA";
                        boilerqueryvo.documentPath = "NA";
                    }
                    BoilerReschdulevo.uploadreschduledocuments = lst;
                }

                string boilerreschdule = BoilerRenewalservice.renewalReschduleInspectionNotice(BoilerReschdulevo);
                if (boilerreschdule == "SUCCESS")
                {
                    gen.UpdateDepartwebserviceflagREN(BoilerReschdulevo.application_id, "55", "RE", boilerreschdule, "Y");
                }
                else
                {
                    gen.UpdateDepartwebserviceflagREN(BoilerReschdulevo.application_id, "55", "RE", boilerreschdule, "N");
                }
            }
        }
        if (ds != null && ds.Tables.Count > 1 && ds.Tables[4].Rows.Count > 0)// upload reparirer details
        {
            DataTable dtadd = new DataTable();
            dtadd = ds.Tables[4];
            for (int i = 0; i < dtadd.Rows.Count; i++)
            {
                string deptid = dtadd.Rows[i]["intApprovalid"].ToString();
                string intquestionnaireid = dtadd.Rows[i]["intQuessionaireid"].ToString();
                BoilerService.renewalRepairsDetails renewalrepairervo = new BoilerService.renewalRepairsDetails();
                DataSet dsdeptquery = new DataSet();
                dsdeptquery = gen.getEnterprenuerRenewalBoilerdashboarddrilldown(intquestionnaireid, "", intquestionnaireid, "");


                renewalrepairervo.applicationID = dsdeptquery.Tables[0].Rows[0]["UID_No"].ToString();//dsdeptquery.Tables[0].Rows[0]["UID_No"].ToString();
                renewalrepairervo.entrepreneurRemarks = "NA";
                renewalrepairervo.systemIP = "00000";
                renewalrepairervo.userID = intquestionnaireid; //dsdeptquery.Tables[0].Rows[0]["Created_by"].ToString();

                //boilerrepairervo.queryResponseAttachments
                BoilerService.queryResponseAttachment[] lst = null;
                BoilerService.queryResponseAttachment boilerqueryvo = new BoilerService.queryResponseAttachment();
                if (dsdeptquery.Tables[3].Rows.Count > 0)
                {
                    DataTable dtraw = new DataTable();
                    dtraw = dsdeptquery.Tables[3];
                    lst = new BoilerService.queryResponseAttachment[dtraw.Rows.Count];
                    if (dsdeptquery.Tables[3].Rows.Count > 0)
                    {
                        for (int k = 0; k < dtraw.Rows.Count; k++)
                        {

                            boilerqueryvo.documentName = dtraw.Rows[k]["FileName"].ToString();
                            boilerqueryvo.documentPath = dtraw.Rows[k]["link"].ToString();
                            lst[k] = boilerqueryvo;
                            //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                            //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                        }
                    }
                    else
                    {
                        boilerqueryvo.documentName = "NA";
                        boilerqueryvo.documentPath = "NA";
                    }
                    renewalrepairervo.queryResponseAttachments = lst;
                    string renewalrepaireroutpu = BoilerRenewalservice.renewalRepairerDetails(renewalrepairervo);
                    if (renewalrepaireroutpu == "SUCCESS")
                    {
                        gen.UpdateDepartwebserviceflagREN(dsdeptquery.Tables[0].Rows[0]["UID_No"].ToString(), "55", "UR", renewalrepaireroutpu, "Y");
                    }
                    else
                    {
                        gen.UpdateDepartwebserviceflagREN(dsdeptquery.Tables[0].Rows[0]["UID_No"].ToString(), "55", "UR", renewalrepaireroutpu, "N");
                    }

                }
            }
        }
        if (ds != null && ds.Tables.Count > 1 && ds.Tables[5].Rows.Count > 0)// upload Completion report repairer
        {
            DataTable dtadd = new DataTable();
            dtadd = ds.Tables[5];
            for (int i = 0; i < dtadd.Rows.Count; i++)
            {
                string deptid = dtadd.Rows[i]["intApprovalid"].ToString();
                string intquestionnaireid = dtadd.Rows[i]["intQuessionaireid"].ToString();
                DataSet dsdeptquery = new DataSet();
                dsdeptquery = gen.getEnterprenuerRenewalBoilerdashboarddrilldown(intquestionnaireid, "", intquestionnaireid, "");

                // BoilerServiceTest.renewalInspectionRelatedDocs
                BoilerService.renewalRepairsCompletionDetails boilerrCompletionvo = new BoilerService.renewalRepairsCompletionDetails();
                boilerrCompletionvo.applicationID = dsdeptquery.Tables[0].Rows[0]["UID_No"].ToString();
                boilerrCompletionvo.entrepreneurRemarks = "NA";
                boilerrCompletionvo.systemIP = "0000";
                boilerrCompletionvo.userID = intquestionnaireid;// "";
                //boilerrepairervo.queryResponseAttachments
                BoilerService.queryResponseAttachment[] lst = null;
                BoilerService.queryResponseAttachment boilerqueryvo = new BoilerService.queryResponseAttachment();
                if (dsdeptquery.Tables[4].Rows.Count > 0)
                {
                    DataTable dtraw = new DataTable();
                    dtraw = dsdeptquery.Tables[4];
                    lst = new BoilerService.queryResponseAttachment[dtraw.Rows.Count];
                    if (dsdeptquery.Tables[4].Rows.Count > 0)
                    {
                        for (int k = 0; k < dtraw.Rows.Count; k++)
                        {

                            boilerqueryvo.documentName = dtraw.Rows[k]["FileName"].ToString();
                            boilerqueryvo.documentPath = dtraw.Rows[k]["link"].ToString();
                            lst[k] = boilerqueryvo;
                            //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                            //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                        }
                    }
                    else
                    {
                        boilerqueryvo.documentName = "NA";
                        boilerqueryvo.documentPath = "NA";
                    }
                    boilerrCompletionvo.queryResponseAttachments = lst;
                    string completionoutput = BoilerRenewalservice.renewalRepairsCompletion(boilerrCompletionvo);
                    if (completionoutput == "SUCCESS")
                    {
                        gen.UpdateDepartwebserviceflagREN(dsdeptquery.Tables[0].Rows[0]["UID_No"].ToString(), "55", "UC", completionoutput, "Y");
                    }
                    else
                    {
                        gen.UpdateDepartwebserviceflagREN(dsdeptquery.Tables[0].Rows[0]["UID_No"].ToString(), "55", "UC", completionoutput, "N");
                    }
                }
            }
        }

        if (ds != null && ds.Tables.Count > 1 && ds.Tables[7].Rows.Count > 0)// Thirdparty  Inspection reports
        {
            DataTable dtadd = new DataTable();
            dtadd = ds.Tables[7];
            for (int i = 0; i < dtadd.Rows.Count; i++)
            {
                string deptid = dtadd.Rows[i]["intApprovalid"].ToString();
                string intquestionnaireid = dtadd.Rows[i]["intQuessionaireid"].ToString();
                DataSet dsdeptquery = new DataSet();
                dsdeptquery = gen.getEnterprenuerRenewalBoilerdashboarddrilldown(intquestionnaireid, "", intquestionnaireid, "");

                // BoilerServiceTest.renewalInspectionRelatedDocs
                BoilerService.renewalInspectionRelatedDocs boilerrelateddocvo = new BoilerService.renewalInspectionRelatedDocs();
                boilerrelateddocvo.applicationID = dsdeptquery.Tables[0].Rows[0]["UID_No"].ToString();
                //boilerrelateddocvo.inspectionRelatedDocs = "NA";
                // boilerrelateddocvo.inspectionRelaventDocs = "NA";
                // boilerrelateddocvo.uploadformvDocs = "NA";
                boilerrelateddocvo.systemIP = "0000";
                boilerrelateddocvo.userID = intquestionnaireid;// "";
                //boilerrepairervo.queryResponseAttachments
                BoilerService.queryResponseAttachment[] lst = null;
                BoilerService.queryResponseAttachment boilerqueryvo = new BoilerService.queryResponseAttachment();
                if (dsdeptquery.Tables[5].Rows.Count > 0)
                {
                    DataTable dtraw = new DataTable();
                    dtraw = dsdeptquery.Tables[5];
                    lst = new BoilerService.queryResponseAttachment[dtraw.Rows.Count];
                    if (dsdeptquery.Tables[5].Rows.Count > 0)
                    {
                        for (int k = 0; k < dtraw.Rows.Count; k++)
                        {

                            boilerqueryvo.documentName = dtraw.Rows[k]["FileName"].ToString();
                            boilerqueryvo.documentPath = dtraw.Rows[k]["link"].ToString();
                            lst[k] = boilerqueryvo;
                            //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                            //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                        }
                    }
                    else
                    {
                        boilerqueryvo.documentName = "NA";
                        boilerqueryvo.documentPath = "NA";
                    }
                    boilerrelateddocvo.inspectionRelatedDocs = lst;

                    if (dsdeptquery.Tables[6].Rows.Count > 0)
                    {
                        for (int k = 0; k < dtraw.Rows.Count; k++)
                        {

                            boilerqueryvo.documentName = dtraw.Rows[k]["FileName"].ToString();
                            boilerqueryvo.documentPath = dtraw.Rows[k]["link"].ToString();
                            lst[k] = boilerqueryvo;
                            //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                            //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                        }
                    }
                    else
                    {
                        boilerqueryvo.documentName = "NA";
                        boilerqueryvo.documentPath = "NA";
                    }
                    boilerrelateddocvo.inspectionRelaventDocs = lst;

                    if (dsdeptquery.Tables[7].Rows.Count > 0)
                    {
                        for (int k = 0; k < dtraw.Rows.Count; k++)
                        {

                            boilerqueryvo.documentName = dtraw.Rows[k]["FileName"].ToString();
                            boilerqueryvo.documentPath = dtraw.Rows[k]["link"].ToString();
                            lst[k] = boilerqueryvo;
                            //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                            //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                        }
                    }
                    else
                    {
                        boilerqueryvo.documentName = "NA";
                        boilerqueryvo.documentPath = "NA";
                    }
                    boilerrelateddocvo.uploadformvDocs = lst;

                    string completionoutput = BoilerRenewalservice.insertRenewalInspectionRelatedDocs(boilerrelateddocvo);
                    if (completionoutput == "SUCCESS")
                    {
                        gen.UpdateDepartwebserviceflagREN(dsdeptquery.Tables[0].Rows[0]["UID_No"].ToString(), "55", "TR", completionoutput, "Y");
                    }
                    else
                    {
                        gen.UpdateDepartwebserviceflagREN(dsdeptquery.Tables[0].Rows[0]["UID_No"].ToString(), "55", "TR", completionoutput, "N");
                    }
                }
            }
        }
    }

    
}