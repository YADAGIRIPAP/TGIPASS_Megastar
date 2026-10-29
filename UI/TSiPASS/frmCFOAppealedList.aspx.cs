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
using System.Net;
using System.Net.Http;
//created by suresh as on 13-1-2016 
//tables is td_BDCDet,tbl_Users
//procedures CheckUserid,insrtBDC,deleteBDC,getBDCbyID
public partial class TSTBDCReg1 : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    string rstages = "0";
    FactoryServiceCFO.TSFactoryServiceImplService factorycfo = new FactoryServiceCFO.TSFactoryServiceImplService();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
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
            GetDetails();

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
        dsn = Gen.GetShowAppealedFilesCFO();
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
            h1.NavigateUrl = "ViewCFOPrint.aspx?intApplid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFOEnterpid")).Trim();
            h2.Target = "_blank";
            h2.NavigateUrl = "frmViewAttachmentDetailsCFO.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFOEnterpid")).Trim();
            h3.Target = "_blank";
            h3.NavigateUrl = "frmQurieResponseStatusCFO.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFOEnterpid")).Trim();
            HiddenField hdfApplID = (HiddenField)e.Row.Cells[18].FindControl("hdfApplID");
            hdfApplID.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireCFOid")).Trim();
            HiddenField hdfGroundedNo = (HiddenField)e.Row.Cells[18].FindControl("hdfGroundedNo");
            hdfGroundedNo.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFOEnterpid")).Trim();
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
        int j = Gen.UpdatetAppealApprovalnewCFO(hdfGroundedNo.Value, "Revoked", Session["uid"].ToString(), "16", hdfGroundedNo0.Value, hdfGroundedNo1.Value);

        DataSet dsMail = new DataSet();
        dsMail = Gen.GetShowEmailidandMobileNumber(hdfApplID.Value);
        if (dsMail.Tables[0].Rows.Count > 0)
        {
            //cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + Session["user_id"].ToString() + "  has Revoked your application. Thank You.");
            cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> Industries Department  has Revoked your application. Thank You.");
        }
        if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
        {
            //cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + Session["user_id"].ToString() + "  has Revoked your application. Thank You.");
            cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : Industries Department  has Revoked your application. Thank You.");
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
            string UIDNO = lnkuidno.Text;// "MEG01500315533 ";//
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
                    string intQuessionairecfoid = dt.Rows[i]["intQuessionaireid"].ToString();
                    string intcfoenterpid = dt.Rows[i]["intCFOEnterpid"].ToString();
                    string INTDEPDID = dt.Rows[i]["intDeptid"].ToString();

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
                                int k = Gen.InsertDeptDateTracingCFO(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);

                                try
                                {
                                    ServicePointManager.Expect100Continue = true;
                                    ServicePointManager.SecurityProtocol = //SecurityProtocolType.Tls12;
                                    SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                                    string outputfactory1 = "";
                                    string valuefactory1 = "";
                                    DataSet dsdept1 = new DataSet();
                                    dsdept1 = Gen.getAdditionalPaymentDetailsCFO(UIDNO, deptid);
                                    valuefactory = dsdept.GetXml();
                                    if (dsdept1 != null && dsdept1.Tables.Count > 0 && dsdept1.Tables[0].Rows.Count > 0)
                                    {
                                        FactoryServiceCFO.grantLicenseAdditionalPayment factorycfovo = new FactoryServiceCFO.grantLicenseAdditionalPayment();
                                        factorycfovo.applicationID = dsdept1.Tables[0].Rows[0]["UIDNO"].ToString();
                                        factorycfovo.bankAmount = dsdept1.Tables[0].Rows[0]["Online_Amount"].ToString();
                                        factorycfovo.bankDate = dsdept1.Tables[0].Rows[0]["TransactionDate"].ToString();
                                        factorycfovo.bankName = dsdept1.Tables[0].Rows[0]["BankName"].ToString();
                                        factorycfovo.challanNumber = dsdept1.Tables[0].Rows[0]["TransactionNO"].ToString();
                                        factorycfovo.paymentStatus = dsdept1.Tables[0].Rows[0]["PaymentFlag"].ToString();
                                        factorycfovo.systemIP = "0.0.0.0";//dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                        factorycfovo.userID = dsdept1.Tables[0].Rows[0]["Created_by"].ToString();

                                        if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[1].Rows.Count > 0)
                                        {
                                            factorycfovo.harithanidhibankamount = dsdept.Tables[1].Rows[0]["Online_Amount"].ToString();
                                            factorycfovo.harithanidhibankdate = dsdept.Tables[1].Rows[0]["TransactionDate"].ToString();
                                            factorycfovo.harithanidhibankname = dsdept.Tables[1].Rows[0]["BankName"].ToString();
                                            factorycfovo.harithanidhibankstatus = dsdept.Tables[1].Rows[0]["PaymentFlag"].ToString();
                                            factorycfovo.harithanidhichallanno = dsdept.Tables[1].Rows[0]["TransactionNO"].ToString();
                                        }
                                        //string outfactory1 = factorycfo.insertIntoGrantLicenseAdditionalPayment(factorycfovo);

                                        //if (outfactory1 == "SUCCESS")
                                        //{

                                        //    Gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", outfactory1, "Y");

                                        //}
                                        //else
                                        //{
                                        //    Gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", outfactory1, "N");
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

                                            Gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", result, "Y");
                                            if (status == "Approval Issued" && remarks == "Auto Generation")
                                            {
                                                DepartmentApprovalSystem obj = new DepartmentApprovalSystem();
                                                obj.DepartmentApprovalProcessAndCertificateUploadCFO(intQuessionairecfoid, intcfoenterpid, deptid, INTDEPDID, "13", UIDNO + ".pdf", certificatePath, remarkswithallotedofficerandapplicationid, registrationNo, "");
                                            }
                                        }
                                        else
                                        {
                                            Gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", result, "N");
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {

                                }
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

        int j = Gen.UpdatetAppealApprovalnewCFOCOIReject(hdfGroundedNo.Value, "Rejected", Session["uid"].ToString(), "16", hdfGroundedNo0.Value, hdfGroundedNo1.Value, TxtRemarks.Text.Trim(), getclientIP());

        DataSet dsMail = new DataSet();
        dsMail = Gen.GetShowEmailidandMobileNumber(hdfApplID.Value);
        if (dsMail.Tables[0].Rows.Count > 0)
        {
            cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + Session["user_id"].ToString() + "   </b> Industries Dept has Rejected your application with Remarks " + TxtRemarks.Text.Trim() + " . Thank You.");
        }
        if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
        {
            cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + Session["user_id"].ToString() + "  : Industries Dept has Rejected your application with Remarks " + TxtRemarks.Text.Trim() + ". Thank You.");
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
        }
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

}