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
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Mail;
//using TSIPassBE;
//using TSIPassBL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Text;

public partial class UI_TSiPASS_AcknowledgmentEntrPrintBMW : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string constring = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ToString();
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
    BoilerService.TSBoilerServiceImplService BoilerRenewalservice = new BoilerService.TSBoilerServiceImplService();

    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet dsnew = new DataSet();
        if (Request.QueryString[0].ToString() != "")
            dsnew = BindReceipt(Request.QueryString[0].ToString());

        if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
        {
            lbluidno.Text = dsnew.Tables[0].Rows[0]["UIDNo"].ToString();
            lblunitname.Text = dsnew.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();
            lbladdress.Text = dsnew.Tables[0].Rows[0]["Village_Name"].ToString();
            lblvillage.Text = dsnew.Tables[0].Rows[0]["Manda_lName"].ToString();
            lblmandal.Text = dsnew.Tables[0].Rows[0]["District_Name"].ToString();
            lblnum2wrds.Text = dsnew.Tables[0].Rows[0]["date"].ToString();
            if (dsnew != null && dsnew.Tables.Count > 1 && dsnew.Tables[1].Rows.Count > 0)
            {
                gvdata.DataSource = dsnew.Tables[1];
                gvdata.DataBind();
                foreach (GridViewRow row in gvdata.Rows)
                {
                    //foreach (TableCell cell in row.Cells)
                    //{
                    row.Cells[2].Attributes.CssStyle["text-align"] = "Right";
                    row.Cells[2].Attributes.CssStyle["Width"] = "100px";
                    //}
                }
                try
                {
                    //Webserviceren(lbluidno.Text);
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                Response.Redirect("HomeDashboard.aspx");
            }
        }
        else
        {
            Response.Redirect("HomeDashboard.aspx");
        }
    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        try
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=PaymentReceipt.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlTextWriterw = new HtmlTextWriter(stringWriter);
            Receipt.RenderControl(htmlTextWriterw);
            StringReader stringReader = new StringReader(stringWriter.ToString());
            Document pdfDoc = new Document(PageSize.A4, 30f, 25f, 15f, 0.2f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            //iTextSharp.text.Image gifghmc1 = iTextSharp.text.Image.GetInstance(Server.MapPath("images/tsSmalllogo.png"));
            //gifghmc1.Alignment = iTextSharp.text.Image.ALIGN_MIDDLE;
            //gifghmc1.ScaleToFit(80, 80);
            //gifghmc1.Alignment = iTextSharp.text.Image.UNDERLYING;
            //gifghmc1.SetAbsolutePosition(260, 600);
            //pdfDoc.Add(gifghmc1);
            htmlparser.Parse(stringReader);
            pdfDoc.Close();
        }
        catch
        {

        }
    }
    protected void btnclose_Click(object sender, EventArgs e)
    {
        Response.Redirect(" ~/UI/TSiPASS/HomeDashboard.aspx");
    }
    private DataSet BindReceipt(string TranRefNo)
    {
        try
        {
            SqlConnection conn = new SqlConnection(constring);
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("USP_GET_ACKNOWLEDGEMENT_BMW", conn);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@intEntid", TranRefNo);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            da1.Fill(ds);
            conn.Close();
            return ds;

        }
        catch (Exception ex)
        {

        }
        return null;
    }

    public void Webserviceren(string UIDNO)
    {
        //DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataSet dsdept = new DataSet();
        try
        {
            //if (Session["objUsrDtl"] != null)
            //{
            if (!IsPostBack)
            {
                DataSet ds = new DataSet();
                ds = gen.GetDepartmentonuidREN(UIDNO);
                if (ds != null && ds.Tables.Count > 1 && ds.Tables[0].Rows.Count > 0)
                {
                    dt = ds.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string deptid = dt.Rows[i]["intApprovalid"].ToString();
                        if (deptid == "53")
                        {
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

                                boilerrenvo.details_of_repairs_path = "";
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

                StringBuilder sbScript = new StringBuilder();
                string sScript;
                sbScript.Append("<script>");
                sbScript.Append(" window.close();");
                sbScript.Append("</script>");

                sScript = sbScript.ToString();

                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", sScript, false);
            }
            // }
        }
        catch (Exception ex)
        {
            //  lblmsg.Text = ex.Message;
            //lblmsg.Visible = true;
        }
    }
}