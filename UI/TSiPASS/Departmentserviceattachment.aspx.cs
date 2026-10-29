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
[WebService(Namespace = "http://tempuri.org/")]

[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public partial class UI_TSiPASS_Departmentserviceattachment : System.Web.UI.Page
{



    WebserviceVO webvo = new WebserviceVO();

    General gen = new General();
    WebClient wc = new WebClient();
    TSNPDCLService.TsipassWsService tsnpdcl = new TSNPDCLService.TsipassWsService();
    TSSPDCLService.TSSPDCLIPassService tsspdcl = new TSSPDCLService.TSSPDCLIPassService();
    FactoryService.TSFactoryServiceImplService factory = new FactoryService.TSFactoryServiceImplService();
    FireService.Service1 fire = new FireService.Service1();
    //BoilerService.TSBoilerServiceImplService boiler = new BoilerService.TSBoilerServiceImplService();
    LabourService.TSLabourServiceImplService labourservice = new LabourService.TSLabourServiceImplService();
    //LabourTest.TSLabourServiceImplService labourservice = new LabourTest.TSLabourServiceImplService();
    NALAService.MeeSevaWebService nalaservice = new NALAService.MeeSevaWebService();
    HMWSSBService.TSiPASSNewConnectionUC hmwssb = new HMWSSBService.TSiPASSNewConnectionUC();
    HMDAService.tsipass hmdaservice = new HMDAService.tsipass();
    HMDAService.ApplicationFormResponse hmdapplication = new HMDAService.ApplicationFormResponse();
    TSIICService.tsipass tsiicservice = new TSIICService.tsipass();
    TSIICService.ApplicationFormResponse tsiicapplication = new TSIICService.ApplicationFormResponse();
    //DB.DB con = new DB.DB();
    FactoryServiceQueryResponse.TSFactoryServiceImplService factoryquery = new FactoryServiceQueryResponse.TSFactoryServiceImplService();
    FactoryServiceQueryResponse.planQR queryvo = new FactoryServiceQueryResponse.planQR();
    FireService.Service1 fireservice = new FireService.Service1();

    protected void Page_Load(object sender, EventArgs e)
    {


    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtuidno.Text != "" && txtFileNO.Text != "" && txtApprovalID.Text != "")
        {
            string UIDNO = txtuidno.Text;
            string deptid = txtApprovalID.Text;
            string hmdapplicationFileNo = txtFileNO.Text;
            try
            {

                //if (deptid == "35")
                //{
                //    DataSet dsdeptattachmentsHMDA = new DataSet();
                //    dsdeptattachmentsHMDA = gen.getattachmentdetailsonuid(UIDNO, deptid, hmdapplicationFileNo);// "000825 /I1/U6/HMDA/10072017");//000841/I1/U6/HMDA/23072017//000842/I1/U6/HMDA/23072017

                //    //Kindly contact to administrator regarding add work flow.
                //    string hmdaattachments = dsdeptattachmentsHMDA.GetXml();
                //    hmdaattachments = hmdaattachments.Replace("&amp;", "&");
                //    hmdapplication = hmdaservice.SaveDocumentDataUsingXML(hmdaattachments, "$$08@213");//000838/I1/U6/HMDA/20072017

                //    if (hmdapplication.Error.Contains("successfully"))
                //    {
                //        lblmsg.Text = hmdapplication.Error;
                //        success.Visible = true;
                //    }
                //    else
                //    {
                //        lblmsg0.Text = hmdapplication.Error;
                //        Failure.Visible = true;
                //    }
                //    //if (hmdapplication.FileNo != "" && hmdapplication.FileNo != null)
                //    //{
                //    //    gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", hmdapplication.FileNo, "Y");
                //    //    //int k = gen.InsertDeptDateTracing("11", "17819", UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                //    //}
                //}
                if (deptid == "31")
                {

                    DataSet dsdeptattachmentsTSIIC = new DataSet();
                    dsdeptattachmentsTSIIC = gen.getattachmentdetailsonuid(UIDNO, deptid, hmdapplicationFileNo);
                    //Kindly contact to administrator regarding add work flow.
                    string tsiicattachments = dsdeptattachmentsTSIIC.GetXml();
                    //tsiicattachments = tsiicattachments.Replace("&amp;", "&");
                    tsiicapplication = tsiicservice.SaveDocumentDataUsingXML(tsiicattachments, "$$08@213");
                    //if (tsiicapplication.FileNo != "" && tsiicapplication.FileNo != null)
                    //{
                    //    gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", tsiicapplication.FileNo, "Y");
                    //}
                    if (tsiicapplication.Error.Contains("successfully"))
                    {
                        lblmsg.Text = tsiicapplication.Error + ". For Application ID: " + UIDNO + ". For File No: " + hmdapplicationFileNo + ". For Approval ID: " + deptid;
                        success.Visible = true;
                        txtuidno.Text = "";
                        txtApprovalID.Text = "";
                        txtFileNO.Text = "";
                    }
                    else
                    {
                        lblmsg0.Text = tsiicapplication.Error;
                        Failure.Visible = true;
                    }
                }
                if (deptid == "74")
                {

                    DataSet dsdeptattachmentsTSIIC = new DataSet();
                    dsdeptattachmentsTSIIC = gen.getattachmentdetailsonuidCFO(UIDNO, deptid, hmdapplicationFileNo);
                    //Kindly contact to administrator regarding add work flow.
                    string tsiicattachments = dsdeptattachmentsTSIIC.GetXml();
                    string tsiicattachments1 = tsiicattachments.Replace("&amp;", "&");
                    tsiicapplication = tsiicservice.SaveDocumentDataUsingXML(tsiicattachments, "$$08@213");
                    if (tsiicapplication.Error.Contains("successfully"))
                    {
                        lblmsg.Text = tsiicapplication.Error + ". For Application ID: " + UIDNO + ". For File No: " + hmdapplicationFileNo + ". For Approval ID: " + deptid;
                        success.Visible = true;
                        txtuidno.Text = "";
                        txtApprovalID.Text = "";
                        txtFileNO.Text = "";
                    }
                    else
                    {
                        lblmsg0.Text = tsiicapplication.Error;
                        Failure.Visible = true;
                    }
                    //if (tsiicapplication.FileNo != "" && tsiicapplication.FileNo != null)
                    //{
                    //    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", tsiicapplication.FileNo, "Y");
                    //    //int k = gen.InsertDeptDateTracingCFO("3", "83709", UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFo", "74");
                    //}
                }
                //if (deptid == "35")
                //{
                //    try
                //    {

                //        DataSet dsdepthmda = new DataSet();
                //        dsdepthmda = gen.GetQueryStatusByTransactionIDResponse("15004", "35");
                //        string hmda = dsdepthmda.GetXml();
                //        hmdapplication = hmdaservice.reSubmission(hmda, "$$08@213");
                //        //if (hmdapplication.ResponseStatus.ToString() == "1")
                //        //{
                //        //    gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", hmdapplication.ErrorMessage, "Y");
                //        //    int k = gen.InsertDeptDateTracing(intDeptid, intQuessionaireid, UIDNO, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFE", intApprovalid);
                //        //}
                //        //else
                //        //{
                //        //    gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", hmdapplication.ErrorMessage, "N");
                //        //}
                //    }
                //    catch (Exception ex)
                //    {

                //    }


                //    // "000825 /I1/U6/HMDA/10072017");//000841/I1/U6/HMDA/23072017//000842/I1/U6/HMDA/23072017

                //    //Kindly contact to administrator regarding add work flow.
                //    //DataSet dsdeptattachmentsHMDA = new DataSet();
                //    //dsdeptattachmentsHMDA = gen.getattachmentdetailsonuid(UIDNO, deptid, hmdapplicationFileNo);
                //    //string hmdaattachments = dsdeptattachmentsHMDA.GetXml();
                //    //hmdapplication = hmdaservice.SaveDocumentDataUsingXML(hmdaattachments, "$$08@213");//000838/I1/U6/HMDA/20072017
                //}

                //}
            }
            catch (Exception ex)
            {

            }
        }
        else
        {
            lblmsg0.Text = "Plase enter all details";
            Failure.Visible = true;
        }
    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        txtApprovalID.Text = "";
        txtuidno.Text = "";
        txtFileNO.Text = "";

    }
}