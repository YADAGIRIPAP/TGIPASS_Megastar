using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Xml;
public partial class UI_TSiPASS_frmCFEAppealedListIndus : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    string rstages = "0";
    FactoryService.TSFactoryServiceImplService factory = new FactoryService.TSFactoryServiceImplService();
    TSNPDCLService.TsipassWsService tsnpdcl = new TSNPDCLService.TsipassWsService();
    TSIICService.tsipass tsiicservice = new TSIICService.tsipass();
    TSIICService.ApplicationFormResponse tsiicapplication = new TSIICService.ApplicationFormResponse();
    HMDAService.tsipass hmdaservice = new HMDAService.tsipass();
    HMDAService.ApplicationFormResponse hmdapplication = new HMDAService.ApplicationFormResponse();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }

        if (!IsPostBack)
        {
            //DataSet dsd = new DataSet();
            //dsd = Gen.GetDistrictsWithoutHYD();
            //ddldistrict.DataSource = dsd.Tables[0];
            //ddldistrict.DataValueField = "District_Id";
            //ddldistrict.DataTextField = "District_Name";
            //ddldistrict.DataBind();
            //ddldistrict.Items.Insert(0, "--Select--");
            //GetDetails();
            DataSet ds = new DataSet();
            ds = GetShowAppealedFiles(Request.QueryString[0].ToString().Trim());

            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
            //BtnReject.OnClientClick = "return RejectValidate();";
        }
        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {

        }
    }


    public void GetDetails()
    {

        DataSet dsn = new DataSet();
        //Response.Write(Session["User_Code"].ToString().Trim()  +  "_" +  rstages.ToString().Trim() + "-" + Session["DistrictID"].ToString().Trim());
        //return;
        dsn = GetShowAppealedFiles(Request.QueryString[0].ToString().Trim());
        if (dsn.Tables[0].Rows.Count > 0)
        {

            grdDetails.DataSource = dsn.Tables[0];
            grdDetails.DataBind();




        }
        else
        {
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }



    }
    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        GetDetails();

    }
    void clear()
    {



    }
    //public void GetDetailsSearch()
    //{
    //    if (Request.QueryString.Count > 0)
    //    {
    //        rstages = Request.QueryString[0].ToString().Trim();
    //        DataSet dsn = new DataSet();
    //        //Response.Write(Session["User_Code"].ToString().Trim()  +  "_" +  rstages.ToString().Trim() + "-" + Session["DistrictID"].ToString().Trim());
    //        //return;
    //        dsn = Gen.GetShowDepartmentFilesIndusSearchCFE(Session["User_Code"].ToString().Trim(), rstages.ToString().Trim(), Session["DistrictID"].ToString().Trim(), TxtnameofUnit.Text, TxtnameofUnit0.Text, ddldistrict.SelectedValue.ToString(), ddldistrict0.SelectedValue.ToString());
    //        if (dsn.Tables[0].Rows.Count > 0)
    //        {
    //            grdDetails.DataSource = dsn.Tables[0];
    //            grdDetails.DataBind();
    //        }
    //        else
    //        {
    //            grdDetails.DataSource = null;
    //            grdDetails.DataBind();
    //        }
    //    }
    //    if (Request.QueryString.Count > 0)
    //    {
    //        if (Request.QueryString[0].ToString().Trim() == "5" || Request.QueryString[0].ToString().Trim() == "6")
    //        {
    //        }
    //        else
    //        {
    //            // grdDetails.Columns[10].Visible = false;
    //            //grdDetails.Columns[11].Visible = false;
    //            grdDetails.Columns[11].Visible = false;
    //            grdDetails.Columns[12].Visible = false;
    //        }
    //    }
    //    else
    //    {
    //        //grdDetails.Columns[10].Visible = false;
    //        //grdDetails.Columns[11].Visible = false;
    //        grdDetails.Columns[11].Visible = false;
    //        grdDetails.Columns[12].Visible = false;
    //    }
    //}
    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        //GetDetailsSearch();

    }
    void FillDetails()
    {


    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {

    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    void getcounties()
    {

    }
    protected void ddlCounties_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    void getPayams()
    {

    }
    protected void ddlState_SelectedIndexChanged1(object sender, EventArgs e)
    {
    }
    protected void ddlCounties_SelectedIndexChanged1(object sender, EventArgs e)
    {
    }
    protected void BtnSave2_Click(object sender, EventArgs e)
    {

        try
        {

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
        finally
        {
        }

    }
    private void fillTrademappingGriddr(DataTable tmpTabledr, string MemType, string authorised, string designation, string gender, string mobile, string email2, string Created_by)
    {

    }

    protected void BtnClear0_Click1(object sender, EventArgs e)
    {

    }
    protected void gvpractical0_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GetNewRectoInsertdr()
    {

    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink h1 = (HyperLink)e.Row.Cells[12].Controls[0];
            HyperLink h2 = (HyperLink)e.Row.Cells[13].Controls[0];
            HyperLink h3 = (HyperLink)e.Row.Cells[14].Controls[0];

            string intUid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();
            LinkButton btn = (LinkButton)e.Row.FindControl("LinkButton1");
            btn.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();
            btn.OnClientClick = "javascript:return Popup('" + intUid + "')";
            h1.Target = "_blank";
            h1.NavigateUrl = "ViewCFEPrint.aspx?intApplid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
            h2.Target = "_blank";
            h2.NavigateUrl = "frmViewAttachmentDetails.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
            h3.Target = "_blank";
            h3.NavigateUrl = "frmQurieResponseStatus.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
            HiddenField hdfApplID = (HiddenField)e.Row.Cells[18].FindControl("hdfApplID");
            hdfApplID.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim();
            HiddenField hdfGroundedNo = (HiddenField)e.Row.Cells[18].FindControl("hdfGroundedNo");
            hdfGroundedNo.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
            HiddenField hdfGroundedNo0 = (HiddenField)e.Row.Cells[18].FindControl("hdfGroundedNo0");
            hdfGroundedNo0.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim();
            HiddenField hdfGroundedNo1 = (HiddenField)e.Row.Cells[18].FindControl("hdfGroundedNo1");
            hdfGroundedNo1.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intApprovalid")).Trim();

        }
    }

    protected void BtnSave_Click1(object sender, EventArgs e)
    {
        Button BtnSave = (Button)sender;
        GridViewRow row = (GridViewRow)BtnSave.NamingContainer;
        HiddenField hdfApplID = (HiddenField)row.FindControl("hdfApplID");
        DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
        TextBox txtPromotor = (TextBox)row.FindControl("txtPromotor");
        TextBox txtAmount = (TextBox)row.FindControl("txtAmount");
        HyperLink h1 = (HyperLink)row.FindControl("h1");
        HyperLink h2 = (HyperLink)row.FindControl("h2");
        HyperLink h3 = (HyperLink)row.FindControl("h3");

        HiddenField hdfGroundedNo = (HiddenField)row.FindControl("hdfGroundedNo");
        HiddenField hdfGroundedNo0 = (HiddenField)row.FindControl("hdfGroundedNo0");
        HiddenField hdfGroundedNo1 = (HiddenField)row.FindControl("hdfGroundedNo1");
        HiddenField hdfGroundedNo2 = (HiddenField)row.FindControl("hdfGroundedNo2");
        HiddenField hdfGroundedNo3 = (HiddenField)row.FindControl("hdfGroundedNo3");

        LinkButton lnkuidno = (LinkButton)row.FindControl("LinkButton1");

        //HiddenField hdfApplID = (HiddenField)e.Row.Cells[10].FindControl("hdfApplID");
        //hdfApplID.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim();
        ////HiddenField hdfGroundedNo0 = (HiddenField)e.Row.Cells[11].FindControl("hdfGroundedNo0");
        ////hdfGroundedNo0.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim();
        ////HiddenField hdfGroundedNo1 = (HiddenField)e.Row.Cells[11].FindControl("hdfGroundedNo1");
        ////hdfGroundedNo1.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intApprovalid")).Trim();
        int j = Gen.UpdatetAppealApprovalnew(hdfGroundedNo.Value, "Revoked", Session["uid"].ToString(), "16", hdfGroundedNo0.Value, hdfGroundedNo1.Value);

        DataSet dsMail = new DataSet();
        dsMail = Gen.GetShowEmailidandMobileNumber(hdfApplID.Value);
        if (dsMail.Tables[0].Rows.Count > 0)
        {
            cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> Industries Dept has Revoked your application. Thank You."); //+ Session["user_id"].ToString() +
        }
        if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
        {
            cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : Industries Dept has Revoked your application. Thank You.");
            //  cmf.SendSingleSMS("9247492919", "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
            //}

            if (j > 0)
            {
                success.Visible = true;
                Failure.Visible = false;
                lblmsg.Text = "Successfully Updated";
            }
            else
            {
                success.Visible = false;
                Failure.Visible = true;
                lblmsg.Text = "Failed..";
            }
            GetDetails();
            //else if (ddlStatus.SelectedValue.ToString() == "--Select--")
            //{
            //    Failure.Visible = true;
            //    success.Visible = false;
            //    lblmsg.Text = "Please Select Status";

            //}

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            //string UIDNO = Request.QueryString["UIDNO"].ToString();
            //string UIDNO = "LRG00600335772";//"MEG02000064425";//"SML00500064419";//"SML00500064419";
            string UIDNO = lnkuidno.Text;// "MEG01500315533 ";//
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
                    if (deptid == "35")//HMDA
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

                            hmdapplication = hmdaservice.create(valueshmda, "$$08@213");//000844/I1/U6/HMDA/25072017
                            //Kindly contact to Administrator regarding post mapping configuration for revenue department.
                            DataSet dsdeptattachmentsHMDA = new DataSet();
                            dsdeptattachmentsHMDA = Gen.getattachmentdetailsonuid(UIDNO, deptid, hmdapplication.FileNo);// "000825 /I1/U6/HMDA/10072017");//000841/I1/U6/HMDA/23072017//000842/I1/U6/HMDA/23072017

                            //Kindly contact to administrator regarding add work flow.
                            string hmdaattachments = dsdeptattachmentsHMDA.GetXml();
                            hmdapplication = hmdaservice.SaveDocumentDataUsingXML(hmdaattachments, "$$08@213");//000838/I1/U6/HMDA/20072017


                            if (hmdapplication.FileNo != "" && hmdapplication.FileNo != null)
                            {
                                //string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "R", hmdapplication.FileNo, "Y");
                                int k = Gen.InsertDeptDateTracing("11", dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                            }
                            else
                            {
                                //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "R", hmdapplication.ErrorMessage, "N");
                            }
                        }
                    }
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
                                FactoryService.additionalAttachment[] AdditionalAttachment = null;
                                FactoryService.appealAttachment[] AppealAttachment = null;

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
                                    if (dsfactroy.Tables[6].Rows.Count > 0)
                                    {
                                        DataTable dtAdditionalAttachment = new DataTable();
                                        dtAdditionalAttachment = dsfactroy.Tables[6];
                                        AdditionalAttachment = new FactoryService.additionalAttachment[dtAdditionalAttachment.Rows.Count];

                                        for (int n = 0; n < dtAdditionalAttachment.Rows.Count; n++)
                                        {
                                            FactoryService.additionalAttachment AdditionalAttachmentvo = new FactoryService.additionalAttachment();
                                            AdditionalAttachmentvo.documentName = dtAdditionalAttachment.Rows[n]["FileName"].ToString();
                                            AdditionalAttachmentvo.documentPath = dtAdditionalAttachment.Rows[n]["Filepath"].ToString();
                                            AdditionalAttachment[n] = AdditionalAttachmentvo;
                                        }
                                    }
                                    if (dsfactroy.Tables[7].Rows.Count > 0)
                                    {
                                        DataTable dtAppealAttachment = new DataTable();
                                        dtAppealAttachment = dsfactroy.Tables[7];
                                        AppealAttachment = new FactoryService.appealAttachment[dtAppealAttachment.Rows.Count];

                                        for (int n = 0; n < dtAppealAttachment.Rows.Count; n++)
                                        {
                                            FactoryService.appealAttachment AppealAttachmentvo = new FactoryService.appealAttachment();
                                            AppealAttachmentvo.documentName = dtAppealAttachment.Rows[n]["FileName"].ToString();
                                            AppealAttachmentvo.documentPath = dtAppealAttachment.Rows[n]["Filepath"].ToString();
                                            AppealAttachment[n] = AppealAttachmentvo;
                                        }
                                    }
                                }
                                factoryvo.saleLeaseDeeds = registrationdeed;
                                factoryvo.sitePlans = siteplan;
                                factoryvo.buildingPlans = buildingplan;
                                factoryvo.partnershipDeeds = partnershipdeed;
                                factoryvo.processFlowCharts = flowchat;
                                factoryvo.panAadharCards = panaadhar;
                                factoryvo.additionalAttachments = AdditionalAttachment;
                                factoryvo.appealAttachments = AppealAttachment;

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

    protected void BtnReject_Click(object sender, EventArgs e)
    {
        Button BtnReject = (Button)sender;
        GridViewRow row = (GridViewRow)BtnReject.NamingContainer;
        TextBox TxtRemarks = (TextBox)row.FindControl("TxtReject");
        if (!TxtRemarks.Visible)
            TxtRemarks.Visible = true;

        if ((TxtRemarks.Visible) && (TxtRemarks.Text != ""))
        {
            //ScriptManager.RegisterStartupScript(this, GetType(), "RejectValidate", "RejectValidate();", true);
            //return;
        }
        else
        {
            //Response.Write("<script>alert('Please enter remarks');</script>");
            ScriptManager.RegisterStartupScript(this, GetType(), "RejectValidate1", "RejectValidate1();", true);
            TxtRemarks.Focus();
            return;
        }


        HiddenField hdfApplID = (HiddenField)row.FindControl("hdfApplID");
        DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
        TextBox txtPromotor = (TextBox)row.FindControl("txtPromotor");
        TextBox txtAmount = (TextBox)row.FindControl("txtAmount");
        HyperLink h1 = (HyperLink)row.FindControl("h1");
        HyperLink h2 = (HyperLink)row.FindControl("h2");
        HyperLink h3 = (HyperLink)row.FindControl("h3");

        HiddenField hdfGroundedNo = (HiddenField)row.FindControl("hdfGroundedNo");
        HiddenField hdfGroundedNo0 = (HiddenField)row.FindControl("hdfGroundedNo0");
        HiddenField hdfGroundedNo1 = (HiddenField)row.FindControl("hdfGroundedNo1");
        HiddenField hdfGroundedNo2 = (HiddenField)row.FindControl("hdfGroundedNo2");
        HiddenField hdfGroundedNo3 = (HiddenField)row.FindControl("hdfGroundedNo3");
        LinkButton lnkuidno = (LinkButton)row.FindControl("LinkButton1");
        int j = Gen.UpdatetAppealApprovalnewCOIReject(hdfGroundedNo.Value, "Rejected", Session["uid"].ToString(), "16", hdfGroundedNo0.Value, hdfGroundedNo1.Value, TxtRemarks.Text.Trim(), getclientIP());

        DataSet dsMail = new DataSet();
        dsMail = Gen.GetShowEmailidandMobileNumber(hdfApplID.Value);
        if (dsMail.Tables[0].Rows.Count > 0)
        {
            try
            {
                //cmf.SendMailTSiPASS("anandsharmavaranasi@gmail.com", "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> Industries Dept has Rejected your application with Remarks:- " + TxtRemarks.Text.Trim() + " . Thank You.");
                cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> Industries Dept has Rejected your application with Remarks " + TxtRemarks.Text.Trim() + " . Thank You."); //+ Session["user_id"].ToString() +
            }
            catch (Exception ee)
            {
                throw;
            }
        }
        if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
        {
            try
            {
                //cmf.SendSingleSMS("8500602468", "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : Industries Dept has Rejected your application with Remarks:- " + TxtRemarks.Text.Trim() + ". Thank You.");
                cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : Industries Dept has Rejected your application with Remarks " + TxtRemarks.Text.Trim() + ". Thank You.");
            }
            catch (Exception ee)
            {
                throw;
            }
            if (j > 0)
            {
                success.Visible = true;
                Failure.Visible = false;
                lblmsg.Text = "Successfully Updated";
            }
            else
            {
                success.Visible = false;
                Failure.Visible = true;
                lblmsg.Text = "Failed..";
            }
            //GetDetails();
            #region comment
            //DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            //string UIDNO = lnkuidno.Text;// "MEG01500315533 ";//
            //ds = Gen.GetDepartmentonuid(UIDNO);

            //if (ds != null)
            //{
            //    if (ds.Tables[2].Rows.Count > 0)
            //    {
            //        dt = ds.Tables[2];
            //    }
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        string deptid = dt.Rows[i]["intApprovalid"].ToString();
            //        if (deptid == "35")//HMDA
            //        {
            //            DataSet dsdept = new DataSet();
            //            string valueshmda = "";
            //            string outputhmda = "";
            //            string outpayhmda = "";
            //            dsdept = Gen.getdepartmentdetailsonuid(UIDNO, deptid);
            //            valueshmda = dsdept.GetXml();
            //            XmlDocument doc = new XmlDocument();
            //            doc.LoadXml(valueshmda);
            //            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
            //            {
            //                hmdapplication = hmdaservice.create(valueshmda, "$$08@213");//000844/I1/U6/HMDA/25072017
            //                DataSet dsdeptattachmentsHMDA = new DataSet();
            //                dsdeptattachmentsHMDA = Gen.getattachmentdetailsonuid(UIDNO, deptid, hmdapplication.FileNo);// "000825 /I1/U6/HMDA/10072017");//000841/I1/U6/HMDA/23072017//000842/I1/U6/HMDA/23072017

            //                string hmdaattachments = dsdeptattachmentsHMDA.GetXml();
            //                hmdapplication = hmdaservice.SaveDocumentDataUsingXML(hmdaattachments, "$$08@213");//000838/I1/U6/HMDA/20072017


            //                if (hmdapplication.FileNo != "" && hmdapplication.FileNo != null)
            //                {
            //                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "R", hmdapplication.FileNo, "Y");
            //                    int k = Gen.InsertDeptDateTracing("11", dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
            //                }
            //                else
            //                {
            //                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "R", hmdapplication.ErrorMessage, "N");
            //                }
            //            }
            //        }
            //        if (deptid == "31")//TSIIC APPEAL
            //        {
            //            DataSet dsdept = new DataSet();
            //            string valueshmda = "";
            //            string outputhmda = "";
            //            string outpayhmda = "";
            //            dsdept = Gen.getdepartmentdetailsonuid(UIDNO, deptid);
            //            valueshmda = dsdept.GetXml();
            //            XmlDocument doc = new XmlDocument();
            //            doc.LoadXml(valueshmda);
            //            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
            //            {
            //                tsiicapplication = tsiicservice.create(valueshmda, "$$08@213");//000844/I1/U6/HMDA/25072017

            //                DataSet dsdeptattachmentsTSIIC = new DataSet();
            //                dsdeptattachmentsTSIIC = Gen.getattachmentdetailsonuid(UIDNO, deptid, tsiicapplication.FileNo);
            //                string tsiicattachments = dsdeptattachmentsTSIIC.GetXml();
            //                tsiicapplication = tsiicservice.SaveDocumentDataUsingXML(tsiicattachments, "$$08@213");//000838/I1/U6/HMDA/20072017//
            //                if (tsiicapplication.FileNo != "" && tsiicapplication.FileNo != null)
            //                {
            //                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "R", tsiicapplication.FileNo, "Y");
            //                    int k =  Gen.InsertDeptDateTracing("3", dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
            //                }
            //                else
            //                {
            //                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "R", tsiicapplication.ErrorMessage, "N");
            //                }
            //            }
            //        }
            //        if (deptid == "4")//NPDCL
            //        {
            //            try
            //            {
            //                string valueNPDCL = "";
            //                string outputnpdcl = "";
            //                string npdclattachments = "";
            //                DataSet dsdept = new DataSet();
            //                DataSet dsdeptattachments = new DataSet();
            //                dsdept = Gen.getdepartmentdetailsonuid(UIDNO, deptid);
            //                valueNPDCL = dsdept.GetXml();
            //                outputnpdcl = tsnpdcl.insertAppealAgainstRejects(valueNPDCL);// tsnpdcl.insertTsipassUidDetaisls(valueNPDCL);
            //                StringReader str = new StringReader(outputnpdcl);
            //                DataSet dsout = new DataSet();
            //                dsout.ReadXml(str);
            //                if (dsout != null && dsout.Tables.Count > 0 && dsout.Tables[0].Rows.Count > 0)
            //                {
            //                    if (dsout.Tables[0].Columns.Contains("status"))
            //                    {
            //                        if (dsout.Tables[0].Rows[0]["status"].ToString() == "S")
            //                        {
            //                            string npdclout = dsout.Tables[0].Rows[0]["status"].ToString();
            //                            Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "R", npdclout, "Y");
            //                        }
            //                        else
            //                        {
            //                            string npdclouterror = dsout.Tables[0].Rows[0]["status"].ToString();
            //                            Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "R", npdclouterror, "N");
            //                        }
            //                    }
            //                }
            //            }
            //            catch (Exception ex)
            //            {

            //            }
            //        }
            //        if (deptid == "21" || deptid == "5" || deptid == "44")//FACTORIES
            //        {
            //            try
            //            {
            //                FactoryService.rawMaterial rawvo = new FactoryService.rawMaterial();
            //                FactoryService.UpdateAppealAgainstRejection factoryvo = new FactoryService.UpdateAppealAgainstRejection();

            //                string outputfactory = "";
            //                string valuefactory = "";
            //                DataSet dsdept = new DataSet();
            //                dsdept = Gen.getdepartmentdetailsonuid(UIDNO, deptid);
            //                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
            //                {
            //                    valuefactory = dsdept.GetXml();
            //                    factoryvo.amountToBePaid = dsdept.Tables[0].Rows[0]["Approval_Fee"].ToString();
            //                    factoryvo.applicationID = dsdept.Tables[0].Rows[0]["UID_No"].ToString();
            //                    factoryvo.applicationStageID = dsdept.Tables[0].Rows[0]["intstageid"].ToString();
            //                    factoryvo.applicationStatus = "Pre-Scuitiny Pending"; //dsdept.Tables[0].Columns[""].ToString();

            //                    factoryvo.applicationSubmittedDate = dsdept.Tables[0].Rows[0]["UID_NOGenerateDate"].ToString();
            //                    factoryvo.bankAmount = dsdept.Tables[0].Rows[0]["Online_Amount"].ToString();
            //                    factoryvo.bankDate = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
            //                    factoryvo.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
            //                    factoryvo.challanNumber = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
            //                    factoryvo.communicationAddress = dsdept.Tables[0].Rows[0]["communicationAddress"].ToString();
            //                    factoryvo.entrepreneurID = dsdept.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
            //                    factoryvo.factoryDistrictID = dsdept.Tables[0].Rows[0]["Land_intDistrictid"].ToString();
            //                    factoryvo.factoryLocality = dsdept.Tables[0].Rows[0]["Name_Gramapachayat"].ToString();
            //                    factoryvo.factoryDoorNumber = dsdept.Tables[0].Rows[0]["SurveyNo"].ToString();
            //                    factoryvo.factoryMandalID = dsdept.Tables[0].Rows[0]["Land_intMandalid"].ToString();
            //                    factoryvo.factoryName = dsdept.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();
            //                    factoryvo.factoryPinCode = dsdept.Tables[0].Rows[0]["Land_Pincode"].ToString();
            //                    factoryvo.factoryVillageID = dsdept.Tables[0].Rows[0]["Land_intVillageid"].ToString();
            //                    factoryvo.hazardousNature = dsdept.Tables[0].Rows[0]["TypeofFactory"].ToString();
            //                    factoryvo.installedHP = dsdept.Tables[0].Rows[0]["Connect_Load_B"].ToString();
            //                    factoryvo.mailID = dsdept.Tables[0].Rows[0]["Land_Email"].ToString();
            //                    factoryvo.mobileNumber = dsdept.Tables[0].Rows[0]["MobileNumber"].ToString();
            //                    factoryvo.paymentStatus = dsdept.Tables[0].Rows[0]["PaymentFlag"].ToString();
            //                    factoryvo.planReferenceNumber = "NA";//dsdept.Tables[0].Columns[""].ToString();
            //                    factoryvo.planType = dsdept.Tables[0].Rows[0]["ProposalFor"].ToString();
            //                    factoryvo.questionaireID = dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString();
            //                    factoryvo.ssiType = "0";// dsdept.Tables[0].Columns[""].ToString();
            //                    factoryvo.systemIP = "0.0.0.0";// dsdept.Tables[0].Columns[""].ToString();
            //                    factoryvo.userID = dsdept.Tables[0].Rows[0]["CREATEDBY"].ToString();
            //                    factoryvo.workersToBeEmployedMen = dsdept.Tables[0].Rows[0]["DirectMale"].ToString();
            //                    factoryvo.workersToBeEmployedWomen = dsdept.Tables[0].Rows[0]["DirectFemale"].ToString();

            //                    FactoryService.rawMaterial[] lst = null;
            //                    if (dsdept.Tables[1].Rows.Count > 0)
            //                    {
            //                        DataTable dtraw = new DataTable();
            //                        dtraw = dsdept.Tables[1];
            //                        lst = new FactoryService.rawMaterial[dtraw.Rows.Count];

            //                        for (int k = 0; k < dtraw.Rows.Count; k++)
            //                        {
            //                            FactoryService.rawMaterial BBB = new FactoryService.rawMaterial();
            //                            BBB.materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
            //                            lst[k] = BBB;
            //                        }
            //                    }

            //                    factoryvo.rawMaterials = lst;

            //                    FactoryService.productsOutput[] product = null;
            //                    if (dsdept.Tables[1].Rows.Count > 0)
            //                    {
            //                        DataTable dtproduct = new DataTable();
            //                        dtproduct = dsdept.Tables[2];
            //                        product = new FactoryService.productsOutput[dtproduct.Rows.Count];

            //                        for (int m = 0; m < dtproduct.Rows.Count; m++)
            //                        {
            //                            FactoryService.productsOutput productvo = new FactoryService.productsOutput();
            //                            productvo.product = dtproduct.Rows[m]["Manf_ItemName"].ToString();
            //                            productvo.output = dtproduct.Rows[m]["OUTPUT"].ToString();
            //                            product[m] = productvo;
            //                        }
            //                    }

            //                    factoryvo.productsOutputs = product;

            //                    FactoryService.saleLeaseDeed[] registrationdeed = null;
            //                    FactoryService.sitePlan[] siteplan = null;
            //                    FactoryService.buildingPlan[] buildingplan = null;
            //                    FactoryService.partnershipDeed[] partnershipdeed = null;
            //                    FactoryService.processFlowChart[] flowchat = null;
            //                    FactoryService.panAadharCard[] panaadhar = null;
            //                    FactoryService.additionalAttachment[] AdditionalAttachment = null;
            //                    FactoryService.appealAttachment[] AppealAttachment = null;



            //                    DataSet dsfactroy = new DataSet();
            //                    dsfactroy = Gen.getattachmentdetailsonuid(UIDNO, deptid, "");

            //                    if (dsfactroy != null && dsfactroy.Tables.Count > 0 && dsfactroy.Tables[0].Rows.Count > 0)
            //                    {

            //                        if (dsfactroy.Tables[0].Rows.Count > 0)
            //                        {
            //                            DataTable dtregistrationdeed = new DataTable();
            //                            dtregistrationdeed = dsfactroy.Tables[0];
            //                            registrationdeed = new FactoryService.saleLeaseDeed[dtregistrationdeed.Rows.Count];

            //                            for (int n = 0; n < dtregistrationdeed.Rows.Count; n++)
            //                            {
            //                                FactoryService.saleLeaseDeed registrationdeedvo = new FactoryService.saleLeaseDeed();
            //                                registrationdeedvo.documentName = dtregistrationdeed.Rows[n]["FileName"].ToString();
            //                                registrationdeedvo.documentPath = dtregistrationdeed.Rows[n]["Filepath"].ToString();
            //                                registrationdeed[n] = registrationdeedvo;
            //                            }
            //                        }
            //                        if (dsfactroy.Tables[1].Rows.Count > 0)
            //                        {
            //                            DataTable dtsiteplan = new DataTable();
            //                            dtsiteplan = dsfactroy.Tables[1];
            //                            siteplan = new FactoryService.sitePlan[dtsiteplan.Rows.Count];

            //                            for (int o = 0; o < dtsiteplan.Rows.Count; o++)
            //                            {
            //                                FactoryService.sitePlan siteplanvo = new FactoryService.sitePlan();
            //                                siteplanvo.documentName = dtsiteplan.Rows[o]["FileName"].ToString();
            //                                siteplanvo.documentPath = dtsiteplan.Rows[o]["Filepath"].ToString();
            //                                siteplan[o] = siteplanvo;
            //                            }
            //                        }
            //                        if (dsfactroy.Tables[2].Rows.Count > 0)
            //                        {
            //                            DataTable dtbuildingplan = new DataTable();
            //                            dtbuildingplan = dsfactroy.Tables[2];
            //                            buildingplan = new FactoryService.buildingPlan[dtbuildingplan.Rows.Count];

            //                            for (int p = 0; p < dtbuildingplan.Rows.Count; p++)
            //                            {
            //                                FactoryService.buildingPlan buildingplanvo = new FactoryService.buildingPlan();
            //                                buildingplanvo.documentName = dtbuildingplan.Rows[p]["FileName"].ToString();
            //                                buildingplanvo.documentPath = dtbuildingplan.Rows[p]["Filepath"].ToString();
            //                                buildingplan[p] = buildingplanvo;
            //                            }
            //                        }
            //                        if (dsfactroy.Tables[3].Rows.Count > 0)
            //                        {
            //                            DataTable dtpartnershipdeed = new DataTable();
            //                            dtpartnershipdeed = dsfactroy.Tables[3];
            //                            partnershipdeed = new FactoryService.partnershipDeed[dtpartnershipdeed.Rows.Count];

            //                            for (int n = 0; n < dtpartnershipdeed.Rows.Count; n++)
            //                            {
            //                                FactoryService.partnershipDeed partnershipdeedvo = new FactoryService.partnershipDeed();
            //                                partnershipdeedvo.documentName = dtpartnershipdeed.Rows[n]["FileName"].ToString();
            //                                partnershipdeedvo.documentPath = dtpartnershipdeed.Rows[n]["Filepath"].ToString();
            //                                partnershipdeed[n] = partnershipdeedvo;
            //                            }
            //                        }
            //                        if (dsfactroy.Tables[4].Rows.Count > 0)
            //                        {
            //                            DataTable dtflowchat = new DataTable();
            //                            dtflowchat = dsfactroy.Tables[4];
            //                            flowchat = new FactoryService.processFlowChart[dtflowchat.Rows.Count];

            //                            for (int n = 0; n < dtflowchat.Rows.Count; n++)
            //                            {
            //                                FactoryService.processFlowChart flowchatvo = new FactoryService.processFlowChart();
            //                                flowchatvo.documentName = dtflowchat.Rows[n]["FileName"].ToString();
            //                                flowchatvo.documentPath = dtflowchat.Rows[n]["Filepath"].ToString();
            //                                flowchat[n] = flowchatvo;
            //                            }
            //                        }
            //                        if (dsfactroy.Tables[5].Rows.Count > 0)
            //                        {
            //                            DataTable dtpanaadhar = new DataTable();
            //                            dtpanaadhar = dsfactroy.Tables[5];
            //                            panaadhar = new FactoryService.panAadharCard[dtpanaadhar.Rows.Count];

            //                            for (int n = 0; n < dtpanaadhar.Rows.Count; n++)
            //                            {
            //                                FactoryService.panAadharCard panaadharvo = new FactoryService.panAadharCard();
            //                                panaadharvo.documentName = dtpanaadhar.Rows[n]["FileName"].ToString();
            //                                panaadharvo.documentPath = dtpanaadhar.Rows[n]["Filepath"].ToString();
            //                                panaadhar[n] = panaadharvo;
            //                            }
            //                        }
            //                        if (dsfactroy.Tables[6].Rows.Count > 0)
            //                        {
            //                            DataTable dtAdditionalAttachment = new DataTable();
            //                            dtAdditionalAttachment = dsfactroy.Tables[6];
            //                            AdditionalAttachment = new FactoryService.additionalAttachment[dtAdditionalAttachment.Rows.Count];

            //                            for (int n = 0; n < dtAdditionalAttachment.Rows.Count; n++)
            //                            {
            //                                FactoryService.additionalAttachment AdditionalAttachmentvo = new FactoryService.additionalAttachment();
            //                                AdditionalAttachmentvo.documentName = dtAdditionalAttachment.Rows[n]["FileName"].ToString();
            //                                AdditionalAttachmentvo.documentPath = dtAdditionalAttachment.Rows[n]["Filepath"].ToString();
            //                                AdditionalAttachment[n] = AdditionalAttachmentvo;
            //                            }
            //                        }
            //                        if (dsfactroy.Tables[7].Rows.Count > 0)
            //                        {
            //                            DataTable dtAppealAttachment = new DataTable();
            //                            dtAppealAttachment = dsfactroy.Tables[7];
            //                            AppealAttachment = new FactoryService.appealAttachment[dtAppealAttachment.Rows.Count];

            //                            for (int n = 0; n < dtAppealAttachment.Rows.Count; n++)
            //                            {
            //                                FactoryService.appealAttachment AppealAttachmentvo = new FactoryService.appealAttachment();
            //                                AppealAttachmentvo.documentName = dtAppealAttachment.Rows[n]["FileName"].ToString();
            //                                AppealAttachmentvo.documentPath = dtAppealAttachment.Rows[n]["Filepath"].ToString();
            //                                AppealAttachment[n] = AppealAttachmentvo;
            //                            }
            //                        }
            //                    }
            //                    factoryvo.saleLeaseDeeds = registrationdeed;
            //                    factoryvo.sitePlans = siteplan;
            //                    factoryvo.buildingPlans = buildingplan;
            //                    factoryvo.partnershipDeeds = partnershipdeed;
            //                    factoryvo.processFlowCharts = flowchat;
            //                    factoryvo.panAadharCards = panaadhar;
            //                    factoryvo.additionalAttachments = AdditionalAttachment;
            //                    factoryvo.appealAttachments = AppealAttachment;

            //                    string OUTPUT = factory.updateAppealAgainstRejection(factoryvo);
            //                    if (OUTPUT == "SUCCESS")
            //                    {
            //                        Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "R", OUTPUT, "Y");
            //                        int k =  Gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
            //                    }
            //                    else
            //                    {
            //                        Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "R", OUTPUT, "N");
            //                    }
            //                }
            //            }
            //            catch (Exception ex)
            //            {

            //            }
            //        }
            //    }
            //}
            #endregion
        }

        ScriptManager.RegisterStartupScript(this, GetType(), "RejectValidate2", "RejectValidate2();", true);
        TxtRemarks.Text = "";
        TxtRemarks.Visible = false;
        GetDetails();







        ////HiddenField hdfApplID = (HiddenField)e.Row.Cells[10].FindControl("hdfApplID");
        ////hdfApplID.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim();
        //////HiddenField hdfGroundedNo0 = (HiddenField)e.Row.Cells[11].FindControl("hdfGroundedNo0");
        //////hdfGroundedNo0.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim();
        //////HiddenField hdfGroundedNo1 = (HiddenField)e.Row.Cells[11].FindControl("hdfGroundedNo1");
        //////hdfGroundedNo1.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intApprovalid")).Trim();



    }

    public static string getclientIP()
    {
        string result = string.Empty;
        string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (!string.IsNullOrEmpty(ip))
        {
            string[] ipRange = ip.Split(',');
            int le = ipRange.Length - 1;
            result = ipRange[0];
        }
        else
        {
            result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        return result;
    }

    public DataSet GetShowAppealedFiles(string uidno)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetShowAppealedFiles_uidno", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure; 

            if (uidno.Trim() == "" || uidno.Trim() == null)
                da.SelectCommand.Parameters.Add("@uidno", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@uidno", SqlDbType.VarChar).Value = uidno.ToString();


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
