using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_frmOccupencyCertificateTSIIC : System.Web.UI.Page
{
    General Gen = new General();
    //HMDAServiceTest.tsipass HMDAObj = new HMDAServiceTest.tsipass();

    //HMDAServiceTest.ApplicationFormResponse hmdapplicationresponse = new HMDAServiceTest.ApplicationFormResponse();
    //TSIICServiceTest.ApplicationFormResponse TSIICapplicationresponse = new TSIICServiceTest.ApplicationFormResponse();
    //TSIICServiceTest.tsipass TSIICObj = new TSIICServiceTest.tsipass();
    TSIICService.ApplicationFormResponse TSIICapplicationresponse = new TSIICService.ApplicationFormResponse();
    TSIICService.tsipass TSIICObj = new TSIICService.tsipass();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    SanctionBuildingDetails SactionBuildingTsipassvo = new SanctionBuildingDetails();
    DataSet dsMyPower = new DataSet();
    DataTable dtMyPower;
    List<SanctionBuildingDetails> lstSanctionBuildingDetails = new List<SanctionBuildingDetails>();
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] == null)
        {
            Response.Redirect("~/tshome.aspx");
        }
        try
        {
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnSavecompletedbuildingplan);
            ScriptManager.GetCurrent(this).RegisterPostBackControl(btnPhotographsofconstructed);
            ScriptManager.GetCurrent(this).RegisterPostBackControl(btnLandvaluecertificate);
            ScriptManager.GetCurrent(this).RegisterPostBackControl(btnBuildingCompletionArchitect);
            ScriptManager.GetCurrent(this).RegisterPostBackControl(btnregisteredgiftdeed);
            ScriptManager.GetCurrent(this).RegisterPostBackControl(btngovernmentordercopy);
            ScriptManager.GetCurrent(this).RegisterPostBackControl(btnEngineercompletioncertificate);
            ScriptManager.GetCurrent(this).RegisterPostBackControl(btnFinalFireNoc);
            if (!IsPostBack)
            {
                DataSet dscheck = new DataSet();
                dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
                if (dscheck.Tables[0].Rows.Count > 0)
                {
                    Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
                }
                else
                {
                    Session["Applid"] = "0";
                }
                DataSet dscheck1 = new DataSet();
                dscheck1 = Gen.GetShowQuestionariesCFO(Session["uid"].ToString().Trim());
                if (dscheck1.Tables[0].Rows.Count > 0)
                {
                    Session["ApplidA"] = dscheck1.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
                }
                else
                {
                    Session["ApplidA"] = "0";
                }
            }
            if (!IsPostBack)
            {
                BindDistricts();
                DataSet dsnew = new DataSet();
                dsnew = Gen.getdataofidentityCFONew(Session["ApplidA"].ToString(), "3");
                if (dsnew.Tables[0].Rows.Count > 0)
                {
                    DataSet dsbp = new DataSet();
                    dsbp = Gen.GetBuildingPErmissionNumber(Session["uid"].ToString(), "", "");
                    if (dsbp != null && dsbp.Tables.Count > 0 && dsbp.Tables[0].Rows.Count > 0)
                    {
                        if (dsbp.Tables[0].Rows[0]["Filenumber"].ToString() != null)
                        {
                            txtfileNo.Text = dsbp.Tables[0].Rows[0]["Filenumber"].ToString();
                            //btngetdata_Click(sender, e);
                            Filldetails();
                        }
                    }
                    DataSet dsDATA = new DataSet();
                    dsDATA = GethmdaocDATA(Session["ApplidA"].ToString(), "74");
                }
                else
                {
                    if (Request.QueryString[1].ToString() == "N")
                    {

                        Response.Redirect("frmOccupencyCertificateHMDA.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");

                    }

                    else
                    {

                        Response.Redirect("frmFiredetailsCFO.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");

                    }
                }
                //-------------------------------------------------------------------------------

                //MainView.ActiveViewIndex = 0;
               
                RbtsDPMScheck_SelectedIndexChanged(sender, e);

                txtFront.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                txtRear.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                txtSide1.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                txtSide2.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                txtSiteArea.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                txtRoadAffectedArea.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                txtNetArea.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                txtTotLot.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                txtbuildingHeight.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                txtNoofRWHPs.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                txtBuildingProposedBuilding.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                txtBuildingUse.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                txtBuildingSubUse.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void RbtsDPMScheck_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RbtsDPMScheck.SelectedValue == "Y")
        {
            //CLear();
            // txtfileNo.Text = "";
            trmaindtlstab1.Visible = false;
            btngetdata.Visible = true;
            txtWorkCommencedDate.Enabled = true;
            txtWorkCompletionDate.Enabled = true;
            txtDueDateforCompletionofBuilding.Enabled = true;
            txtOccupancyAppliedFor.Enabled = true;
            //ddlUnitDIst.Enabled = false;
           // ddlUnitMandal.Enabled = false;
            //ddlVillageunit.Enabled = false;
           // txtofficezone.Enabled = false;
           // txtPlotNo.Enabled = false;
           // txtSurveyNo.Enabled = false;
            txtProceedingIssuedOnDate.Enabled = false;
            txtProceedingIssuedBy.Enabled = false;
            txtFront.Enabled = false;
            txtRear.Enabled = false;
            txtSide1.Enabled = false;
            txtSide2.Enabled = false;
            txtSiteArea.Enabled = false;
            txtRoadAffectedArea.Enabled = false;
            txtNetArea.Enabled = false;
            txtTotLot.Enabled = false;
            txtbuildingHeight.Enabled = false;
            txtNoofRWHPs.Enabled = false;
            txtnooftrees.Enabled = false;
            txtBuildingProposedBuilding.Enabled = false;
            txtBuildingUse.Enabled = false;
            txtBuildingSubUse.Enabled = false;
            txtNoofFloors.Enabled = false;
            txtTechnicalName.Enabled = false;
            txtTechnicalEmailId.Enabled = false;
            txtTechnicalMobileNo.Enabled = false;
            txtOwnerName.Enabled = false;
            txttxtOwnerEmailId.Enabled = false;
            txtMobileNo.Enabled = false;
        }
        else
        {
            CLear();
            trmaindtlstab1.Visible = true;
            btngetdata.Visible = false;
            txtWorkCommencedDate.Enabled = true;
            txtWorkCompletionDate.Enabled = true;
            txtDueDateforCompletionofBuilding.Enabled = true;
            txtOccupancyAppliedFor.Enabled = true;
            ddlUnitDIst.Enabled = true;
            ddlUnitMandal.Enabled = true;
            ddlVillageunit.Enabled = true;
            txtofficezone.Enabled = true;
            txtPlotNo.Enabled = true;
            txtSurveyNo.Enabled = true;
            txtProceedingIssuedOnDate.Enabled = true;
            txtProceedingIssuedBy.Enabled = true;
            txtFront.Enabled = true;
            txtRear.Enabled = true;
            txtSide1.Enabled = true;
            txtSide2.Enabled = true;
            txtSiteArea.Enabled = true;
            txtRoadAffectedArea.Enabled = true;
            txtNetArea.Enabled = true;
            txtTotLot.Enabled = true;
            txtbuildingHeight.Enabled = true;
            txtNoofRWHPs.Enabled = true;
            txtnooftrees.Enabled = true;
            txtBuildingProposedBuilding.Enabled = true;
            txtBuildingUse.Enabled = true;
            txtBuildingSubUse.Enabled = true;
            txtNoofFloors.Enabled = true;
            txtTechnicalName.Enabled = true;
            txtTechnicalEmailId.Enabled = true;
            txtTechnicalMobileNo.Enabled = true;
            txtOwnerName.Enabled = true;
            txttxtOwnerEmailId.Enabled = true;
            txtMobileNo.Enabled = true;
        }
    }
    public void CLear()
    {
        txtWorkCommencedDate.Text = "";
        txtWorkCompletionDate.Text = "";
        txtDueDateforCompletionofBuilding.Text = "";
        txtOccupancyAppliedFor.Text = "";
        ddlUnitDIst.SelectedValue = "0";
        ddlUnitMandal.SelectedValue = "0";
        ddlVillageunit.SelectedValue = "0";
        txtofficezone.Text = "";
        txtPlotNo.Text = "";
        txtSurveyNo.Text = "";
        txtProceedingIssuedOnDate.Text = "";
        txtProceedingIssuedBy.Text = "";
        txtFront.Text = "";
        txtRear.Text = "";
        txtSide1.Text = "";
        txtSide2.Text = "";
        txtSiteArea.Text = "";
        txtRoadAffectedArea.Text = "";
        txtNetArea.Text = "";
        txtTotLot.Text = "";
        txtbuildingHeight.Text = "";
        txtNoofRWHPs.Text = "";
        txtnooftrees.Text = "";
        txtBuildingProposedBuilding.Text = "";
        txtBuildingUse.Text = "";
        txtBuildingSubUse.Text = "";
        txtNoofFloors.Text = "";
        txtTechnicalName.Text = "";
        txtTechnicalEmailId.Text = "";
        txtTechnicalMobileNo.Text = "";
        txtOwnerName.Text = "";
        txttxtOwnerEmailId.Text = "";
        txtMobileNo.Text = "";
    }
    protected void btntab1next_Click(object sender, EventArgs e)
    {
        try
        {
            string errormsg = ValidateControls("1");
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            else
            {
                AssignValuestoVosFromcontrols("1");
                Response.Redirect("frmOccupencyCertificateHMDA.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
            }

            //Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Application Submitted Sucessfully');" + "window.location='IncentivesCheckSlip.aspx';", true);
            //Response.Redirect("IncentivesCheckSlip.aspx");
        }
        catch (Exception ex)
        { Errors.ErrorLog(ex); }


    }
    public string ValidateControls(string Step)
    {
        int slno = 1;
        string ErrorMsg = "";
        //if (Step == "1")
        // {
        if (txtfileNo.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter File Number\\n";
            slno = slno + 1;
        }
        if (txtWorkCommencedDate.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Work Commenced Date\\n";
            slno = slno + 1;
        }
        if (txtWorkCompletionDate.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Work Completion Date\\n";
            slno = slno + 1;
        }
        if (txtDueDateforCompletionofBuilding.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Due Date for Completion of Building\\n";
            slno = slno + 1;
        }
        if (txtOccupancyAppliedFor.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Occupancy Applied For\\n";
            slno = slno + 1;
        }
        if (hplcompletedbuildingplan.Text.TrimStart().TrimEnd() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Upload Copy of completed building plan as per physical ground position\\n";
            slno = slno + 1;
        }
        if (hplPhotographsofconstructed.Text.TrimStart().TrimEnd() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Upload Photographs of constructed building showing setbacks on four sides, elevation and roof level\\n";
            slno = slno + 1;
        }
        if (hplLandvaluecertificate.Text.TrimStart().TrimEnd() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Upload Land value certificate issued by the revenue department\\n";
            slno = slno + 1;
        }
        if (hplBuildingCompletionArchitect.Text.TrimStart().TrimEnd() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Upload Building Completion notice by Architect / Structural Engineer duly signed by the owner, builder(if any), Architech & Sructural Engineer\\n";
            slno = slno + 1;
        }
        if (ddlUnitDIst.SelectedItem.Text == "--Select--" || ddlUnitDIst.SelectedValue == "0" || ddlUnitMandal.SelectedItem.Text == "--Select--" || ddlUnitMandal.SelectedValue == "0" ||
           ddlVillageunit.SelectedItem.Text == "--Select--" || ddlVillageunit.SelectedValue == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". You are entering wrong file number. Please enter ocrrect file number\\n";
            slno = slno + 1;
        }
        //if (ddlUnitDIst.SelectedValue == "0")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Select District Under Unit Address\\n";
        //    slno = slno + 1;
        //}
        //if (ddlUnitMandal.SelectedValue == "0")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Select Mandal Under Unit Address\\n";
        //    slno = slno + 1;
        //}
        //if (ddlVillageunit.SelectedValue == "0")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Select Village Under Unit Address\\n";
        //    slno = slno + 1;
        //}
        ////if (ddlOfficeZone.SelectedValue == "0")
        ////{
        ////    ErrorMsg = ErrorMsg + slno + ". Please select Office Zone\\n";
        ////    slno = slno + 1;
        ////}
        //if (txtPlotNo.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Plot No\\n";
        //    slno = slno + 1;
        //}
        //if (txtSurveyNo.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Survey No\\n";
        //    slno = slno + 1;
        //}
        //if (txtProceedingIssuedOnDate.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Proceeding Issued On Date\\n";
        //    slno = slno + 1;
        //}
        //if (txtProceedingIssuedBy.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Proceeding Issued By\\n";
        //    slno = slno + 1;
        //}
        //if (txtFront.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Set Backs Front\\n";
        //    slno = slno + 1;
        //}
        //if (txtRear.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Set Backs Rear\\n";
        //    slno = slno + 1;
        //}
        //if (txtSide1.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Set Backs Side 1\\n";
        //    slno = slno + 1;
        //}
        //if (txtSide2.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Set Backs Side 2\\n";
        //    slno = slno + 1;
        //}
        //if (txtSiteArea.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Site Area(m2)\\n";
        //    slno = slno + 1;
        //}
        //if (txtRoadAffectedArea.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Road Affected Area(m2)\\n";
        //    slno = slno + 1;
        //}
        //if (txtNetArea.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Net Area(m2)\\n";
        //    slno = slno + 1;
        //}
        //if (txtTotLot.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Tot-Lot(m2)\\n";
        //    slno = slno + 1;
        //}
        //if (txtbuildingHeight.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Height(m)\\n";
        //    slno = slno + 1;
        //}
        //if (txtNoofRWHPs.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter No of RWHPs\\n";
        //    slno = slno + 1;
        //}
        //if (txtnooftrees.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter No. Of Trees\\n";
        //    slno = slno + 1;
        //}
        //if (txtBuildingProposedBuilding.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Building Proposed Building - Height(M)\\n";
        //    slno = slno + 1;
        //}
        //if (txtBuildingUse.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Building Use\\n";
        //    slno = slno + 1;
        //}
        //if (txtBuildingSubUse.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Building SubUse\\n";
        //    slno = slno + 1;
        //}
        //if (txtNoofFloors.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter No of Floors\\n";
        //    slno = slno + 1;
        //}
        //if (txtTechnicalName.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Technical Person Name\\n";
        //    slno = slno + 1;
        //}
        //if (txtTechnicalEmailId.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Technical Person Email ID\\n";
        //    slno = slno + 1;
        //}
        //if (txtTechnicalMobileNo.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Technical Person Mobile Number\\n";
        //    slno = slno + 1;
        //}
        //if (txtOwnerName.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Owner Name\\n";
        //    slno = slno + 1;
        //}
        //if (txttxtOwnerEmailId.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Owner Email ID\\n";
        //    slno = slno + 1;
        //}
        //if (txtMobileNo.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Owner Mobile Number\\n";
        //    slno = slno + 1;
        //}
        //}
        //else if (Step == "2")
        //{

        //if (lblregisteredgiftdeed.Text.TrimStart().TrimEnd() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Upload Copy of the registered gift deed handling over the road affected area to the local body\\n";
        //    slno = slno + 1;
        //}
        //if (lblgovernmentordercopy.Text.TrimStart().TrimEnd() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Upload State / Central government order copy on the fee waiver\\n";
        //    slno = slno + 1;
        //}
        //if (lblEngineercompletioncertificate.Text.TrimStart().TrimEnd() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Upload Architect / Structural Engineer completion certificate\\n";
        //    slno = slno + 1;
        //}
        //if (lblFinalFireNoc.Text.TrimStart().TrimEnd() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Upload Final Fire Noc\\n";
        //    slno = slno + 1;
        //}
        //}
        return ErrorMsg;
    }

    public void AssignValuestoVosFromcontrols(string step)
    {
        try
        {
            HmdaOcVos objvo = new HmdaOcVos();
            objvo.AppsLevel = step;
            objvo.User_Id = Session["uid"].ToString();
            //if (step == "1")
            //{
            objvo.OnlineOffline = RbtsDPMScheck.SelectedValue;
            objvo.HMDAFileNo = txtfileNo.Text.TrimStart().TrimEnd();
            if (txtWorkCommencedDate.Text.Trim().TrimStart() != "")
            {
                string[] ConvertedDt11 = txtWorkCommencedDate.Text.Split('-');
                objvo.WorkCommencedDate = ConvertedDt11[2].ToString() + "/" + ConvertedDt11[1].ToString() + "/" + ConvertedDt11[0].ToString();
            }
            if (txtWorkCompletionDate.Text.Trim().TrimStart() != "")
            {
                string[] ConvertedDt11 = txtWorkCompletionDate.Text.Split('-');
                objvo.WorkCompletionDate = ConvertedDt11[2].ToString() + "/" + ConvertedDt11[1].ToString() + "/" + ConvertedDt11[0].ToString();
            }
            if (txtDueDateforCompletionofBuilding.Text.Trim().TrimStart() != "")
            {
                string[] ConvertedDt11 = txtDueDateforCompletionofBuilding.Text.Split('-');
                objvo.DueDateforCompletionofBuilding = ConvertedDt11[2].ToString() + "/" + ConvertedDt11[1].ToString() + "/" + ConvertedDt11[0].ToString();
            }

            objvo.OccupancyAppliedFor = txtOccupancyAppliedFor.Text.Trim().TrimStart();
            objvo.UnitDIst = ddlUnitDIst.SelectedValue;
            objvo.UnitMandal = ddlUnitMandal.SelectedValue;
            objvo.Villageunit = ddlVillageunit.SelectedValue;
            objvo.OfficeZone = txtofficezone.Text;
            objvo.PlotNo = txtPlotNo.Text.Trim().TrimStart();
            objvo.SurveyNo = txtSurveyNo.Text.Trim().TrimStart();
            //if (txtProceedingIssuedOnDate.Text.Trim().TrimStart() != "")
            //{
            //    string[] date = txtProceedingIssuedOnDate.Text.Split(' ');
            //    string[] newdate = date[0].ToString().Split('/');

            //    //string[] ConvertedDt11 = txtProceedingIssuedOnDate.Text.Split('/');
            //    //string[] ConvertedDt12=ConvertedDt11.
            //    objvo.ProceedingIssuedOnDate = newdate[2].ToString() + "/" + newdate[0].ToString() + "/" + newdate[1].ToString();
            //}

            //objvo.ProceedingIssuedBy = txtProceedingIssuedBy.Text.Trim().TrimStart();
            //objvo.Front = txtFront.Text.Trim().TrimStart();
            //objvo.Rear = txtRear.Text.Trim().TrimStart();
            //objvo.Side1 = txtSide1.Text.Trim().TrimStart();
            //objvo.Side2 = txtSide2.Text.Trim().TrimStart();
            //objvo.SiteArea = txtSiteArea.Text.Trim().TrimStart();
            //objvo.RoadAffectedArea = txtRoadAffectedArea.Text.Trim().TrimStart();
            //objvo.NetArea = txtNetArea.Text.Trim().TrimStart();
            //objvo.TotLot = txtTotLot.Text.Trim().TrimStart();
            //objvo.buildingHeight = txtbuildingHeight.Text.Trim().TrimStart();
            //objvo.NoofRWHPs = txtNoofRWHPs.Text.Trim().TrimStart();
            //objvo.nooftrees = txtnooftrees.Text.Trim().TrimStart();
            //objvo.BuildingProposedBuilding = txtBuildingProposedBuilding.Text.Trim().TrimStart();
            //objvo.BuildingUse = txtBuildingUse.Text.Trim().TrimStart();
            //objvo.BuildingSubUse = txtBuildingSubUse.Text.Trim().TrimStart();
            //objvo.NoofFloors = txtNoofFloors.Text.Trim().TrimStart();
            //objvo.TechnicalName = txtTechnicalName.Text.Trim().TrimStart();
            //objvo.TechnicalEmailId = txtTechnicalEmailId.Text.Trim().TrimStart();
            //objvo.TechnicalMobileNo = txtTechnicalMobileNo.Text.Trim().TrimStart();
            //objvo.OwnerName = txtOwnerName.Text.Trim().TrimStart();
            //objvo.txtOwnerEmailId = txttxtOwnerEmailId.Text.Trim().TrimStart();
            //objvo.MobileNo = txtMobileNo.Text.Trim().TrimStart();

            objvo.intQuessionaireCFOid = Session["ApplidA"].ToString();
            objvo.ApprovalID = "74";
            objvo.DeptID = "3";
            try
            {
                string ApplicationNumber = "";
                string Validstatus = InsertHmdaOcCommonData(objvo, out ApplicationNumber);
                if (Validstatus != null && Validstatus != "" && Validstatus != "0" && Validstatus == "1")
                {
                    objvo.HmdaOcID = Validstatus;
                    Session["HmdaOcID"] = objvo.HmdaOcID;
                    Session["HmdaOcIDApplicationNumber"] = ApplicationNumber;
                    Tab1.Attributes.Add("class", "");
                    Tab2.Attributes.Add("class", "active");
                    //MainView.ActiveViewIndex = 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //}
            //else if (step == "2")
            //{
            //    objvo.OnlineOffline = RbtsDPMScheck.SelectedValue;
            //    objvo.HMDAFileNo = txtfileNo.Text.TrimStart().TrimEnd();
            //    if (txtWorkCommencedDate.Text.Trim().TrimStart() != "")
            //    {
            //        string[] ConvertedDt11 = txtWorkCommencedDate.Text.Split('/');
            //        objvo.WorkCommencedDate = ConvertedDt11[2].ToString() + "/" + ConvertedDt11[1].ToString() + "/" + ConvertedDt11[0].ToString();
            //    }
            //    if (txtWorkCompletionDate.Text.Trim().TrimStart() != "")
            //    {
            //        string[] ConvertedDt11 = txtWorkCompletionDate.Text.Split('/');
            //        objvo.WorkCompletionDate = ConvertedDt11[2].ToString() + "/" + ConvertedDt11[1].ToString() + "/" + ConvertedDt11[0].ToString();
            //    }
            //    if (txtDueDateforCompletionofBuilding.Text.Trim().TrimStart() != "")
            //    {
            //        string[] ConvertedDt11 = txtDueDateforCompletionofBuilding.Text.Split('/');
            //        objvo.DueDateforCompletionofBuilding = ConvertedDt11[2].ToString() + "/" + ConvertedDt11[1].ToString() + "/" + ConvertedDt11[0].ToString();
            //    }

            //    objvo.OccupancyAppliedFor = txtOccupancyAppliedFor.Text.Trim().TrimStart();
            //    objvo.UnitDIst = ddlUnitDIst.SelectedValue;
            //    objvo.UnitMandal = ddlUnitMandal.SelectedValue;
            //    objvo.Villageunit = ddlVillageunit.SelectedValue;
            //    objvo.OfficeZone = txtofficezone.Text;
            //    objvo.PlotNo = txtPlotNo.Text.Trim().TrimStart();
            //    objvo.SurveyNo = txtSurveyNo.Text.Trim().TrimStart();
            //    if (txtProceedingIssuedOnDate.Text.Trim().TrimStart() != "")
            //    {
            //        string[] ConvertedDt11 = txtProceedingIssuedOnDate.Text.Split('/');
            //        objvo.ProceedingIssuedOnDate = ConvertedDt11[2].ToString() + "/" + ConvertedDt11[1].ToString() + "/" + ConvertedDt11[0].ToString();
            //    }

            //    objvo.ProceedingIssuedBy = txtProceedingIssuedBy.Text.Trim().TrimStart();
            //    objvo.Front = txtFront.Text.Trim().TrimStart();
            //    objvo.Rear = txtRear.Text.Trim().TrimStart();
            //    objvo.Side1 = txtSide1.Text.Trim().TrimStart();
            //    objvo.Side2 = txtSide2.Text.Trim().TrimStart();
            //    objvo.SiteArea = txtSiteArea.Text.Trim().TrimStart();
            //    objvo.RoadAffectedArea = txtRoadAffectedArea.Text.Trim().TrimStart();
            //    objvo.NetArea = txtNetArea.Text.Trim().TrimStart();
            //    objvo.TotLot = txtTotLot.Text.Trim().TrimStart();
            //    objvo.buildingHeight = txtbuildingHeight.Text.Trim().TrimStart();
            //    objvo.NoofRWHPs = txtNoofRWHPs.Text.Trim().TrimStart();
            //    objvo.nooftrees = txtnooftrees.Text.Trim().TrimStart();
            //    objvo.BuildingProposedBuilding = txtBuildingProposedBuilding.Text.Trim().TrimStart();
            //    objvo.BuildingUse = txtBuildingUse.Text.Trim().TrimStart();
            //    objvo.BuildingSubUse = txtBuildingSubUse.Text.Trim().TrimStart();
            //    objvo.NoofFloors = txtNoofFloors.Text.Trim().TrimStart();
            //    objvo.TechnicalName = txtTechnicalName.Text.Trim().TrimStart();
            //    objvo.TechnicalEmailId = txtTechnicalEmailId.Text.Trim().TrimStart();
            //    objvo.TechnicalMobileNo = txtTechnicalMobileNo.Text.Trim().TrimStart();
            //    objvo.OwnerName = txtOwnerName.Text.Trim().TrimStart();
            //    objvo.txtOwnerEmailId = txttxtOwnerEmailId.Text.Trim().TrimStart();
            //    objvo.MobileNo = txtMobileNo.Text.Trim().TrimStart();

            //    objvo.intQuessionaireCFOid = Session["ApplidA"].ToString();
            //    objvo.ApprovalID = "73";
            //    objvo.DeptID = "11";
            //    try
            //    {
            //        string ApplicationNumber = "";
            //        string Validstatus = "";// InsertHmdaOcCommonData(objvo, out ApplicationNumber);
            //        if (Validstatus != null && Validstatus != "" && Validstatus != "0" && Validstatus == "1")
            //        {
            //            objvo.HmdaOcID = Validstatus;
            //            Session["HmdaOcID"] = objvo.HmdaOcID;
            //            Session["HmdaOcIDApplicationNumber"] = ApplicationNumber;
            //            Tab1.Attributes.Add("class", "");
            //            Tab2.Attributes.Add("class", "active");
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //}


        }
        catch (Exception ex)
        {
            throw ex;
        }


    }

    public void Binddata(DataSet ds)
    {

        RbtsDPMScheck.SelectedValue = ds.Tables[0].Rows[0]["OnlineOffline"].ToString();
        txtfileNo.Text = ds.Tables[0].Rows[0]["HMDAFileNo"].ToString();
        txtWorkCommencedDate.Text = ds.Tables[0].Rows[0]["WorkCommencedDate"].ToString();
        txtWorkCompletionDate.Text = ds.Tables[0].Rows[0]["WorkCompletionDate"].ToString();
        txtDueDateforCompletionofBuilding.Text = ds.Tables[0].Rows[0]["DueDateforCompletionofBuilding"].ToString();

        txtOccupancyAppliedFor.Text = ds.Tables[0].Rows[0]["OccupancyAppliedFor"].ToString();
        ddlUnitDIst.SelectedValue = ds.Tables[0].Rows[0]["UnitDIst"].ToString();
        ddlUnitMandal.SelectedValue = ds.Tables[0].Rows[0]["UnitMandal"].ToString();
        ddlVillageunit.SelectedValue = ds.Tables[0].Rows[0]["Villageunit"].ToString();
        txtofficezone.Text = ds.Tables[0].Rows[0]["OfficeZone"].ToString();
        txtPlotNo.Text = ds.Tables[0].Rows[0]["PlotNo"].ToString();
        txtSurveyNo.Text = ds.Tables[0].Rows[0]["SurveyNo"].ToString();
        txtProceedingIssuedOnDate.Text = ds.Tables[0].Rows[0]["ProceedingIssuedOnDate"].ToString();

        txtProceedingIssuedBy.Text = ds.Tables[0].Rows[0]["ProceedingIssuedBy"].ToString();
        txtFront.Text = ds.Tables[0].Rows[0]["Front"].ToString();
        txtRear.Text = ds.Tables[0].Rows[0]["Rear"].ToString();
        txtSide1.Text = ds.Tables[0].Rows[0]["Side1"].ToString();
        txtSide2.Text = ds.Tables[0].Rows[0]["Side2"].ToString();
        txtSiteArea.Text = ds.Tables[0].Rows[0]["SiteArea"].ToString();
        txtRoadAffectedArea.Text = ds.Tables[0].Rows[0]["RoadAffectedArea"].ToString();
        txtNetArea.Text = ds.Tables[0].Rows[0]["NetArea"].ToString();
        txtTotLot.Text = ds.Tables[0].Rows[0]["TotLot"].ToString();
        txtbuildingHeight.Text = ds.Tables[0].Rows[0]["buildingHeight"].ToString();
        txtNoofRWHPs.Text = ds.Tables[0].Rows[0]["NoofRWHPs"].ToString();
        txtnooftrees.Text = ds.Tables[0].Rows[0]["nooftrees"].ToString();
        txtBuildingProposedBuilding.Text = ds.Tables[0].Rows[0]["BuildingProposedBuilding"].ToString();
        txtBuildingUse.Text = ds.Tables[0].Rows[0]["BuildingUse"].ToString();
        txtBuildingSubUse.Text = ds.Tables[0].Rows[0]["BuildingSubUse"].ToString();
        txtNoofFloors.Text = ds.Tables[0].Rows[0]["NoofFloors"].ToString();
        txtTechnicalName.Text = ds.Tables[0].Rows[0]["TechnicalName"].ToString();
        txtTechnicalEmailId.Text = ds.Tables[0].Rows[0]["TechnicalEmailId"].ToString();
        txtTechnicalMobileNo.Text = ds.Tables[0].Rows[0]["TechnicalMobileNo"].ToString();
        txtOwnerName.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
        txttxtOwnerEmailId.Text = ds.Tables[0].Rows[0]["txtOwnerEmailId"].ToString();
        txtMobileNo.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
    }

    public string InsertHmdaOcCommonData(HmdaOcVos objvo1, out string ApplicationNumber)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        string valid = "";
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();
        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "USP_INSERT_HMDAOC_DATA";
            com.Transaction = transaction;
            com.Connection = connection;
            com.Parameters.AddWithValue("@HmdaOcID", objvo1.HmdaOcID);
            com.Parameters.AddWithValue("@HMDAFileNo", objvo1.HMDAFileNo);
            com.Parameters.AddWithValue("@AppsLevel", objvo1.AppsLevel);
            com.Parameters.AddWithValue("@User_Id", objvo1.User_Id);
            com.Parameters.AddWithValue("@WorkCommencedDate", objvo1.WorkCommencedDate);
            com.Parameters.AddWithValue("@WorkCompletionDate", objvo1.WorkCompletionDate);
            com.Parameters.AddWithValue("@DueDateforCompletionofBuilding", objvo1.DueDateforCompletionofBuilding);
            com.Parameters.AddWithValue("@OccupancyAppliedFor", objvo1.OccupancyAppliedFor);
            com.Parameters.AddWithValue("@UnitDIst", objvo1.UnitDIst);
            com.Parameters.AddWithValue("@UnitMandal", objvo1.UnitMandal);
            com.Parameters.AddWithValue("@Villageunit", objvo1.Villageunit);
            com.Parameters.AddWithValue("@OfficeZone", objvo1.OfficeZone);
            com.Parameters.AddWithValue("@PlotNo", objvo1.PlotNo);
            com.Parameters.AddWithValue("@SurveyNo", objvo1.SurveyNo);
            com.Parameters.AddWithValue("@ProceedingIssuedOnDate", objvo1.ProceedingIssuedOnDate);
            com.Parameters.AddWithValue("@ProceedingIssuedBy", objvo1.ProceedingIssuedBy);
            com.Parameters.AddWithValue("@Front", objvo1.Front);
            com.Parameters.AddWithValue("@Rear", objvo1.Rear);
            com.Parameters.AddWithValue("@Side1", objvo1.Side1);
            com.Parameters.AddWithValue("@Side2", objvo1.Side2);
            com.Parameters.AddWithValue("@SiteArea", objvo1.SiteArea);
            com.Parameters.AddWithValue("@RoadAffectedArea", objvo1.RoadAffectedArea);
            com.Parameters.AddWithValue("@NetArea", objvo1.NetArea);
            com.Parameters.AddWithValue("@TotLot", objvo1.TotLot);
            com.Parameters.AddWithValue("@buildingHeight", objvo1.buildingHeight);
            com.Parameters.AddWithValue("@NoofRWHPs", objvo1.NoofRWHPs);
            com.Parameters.AddWithValue("@nooftrees", objvo1.nooftrees);
            com.Parameters.AddWithValue("@BuildingProposedBuilding", objvo1.BuildingProposedBuilding);
            com.Parameters.AddWithValue("@BuildingUse", objvo1.BuildingUse);
            com.Parameters.AddWithValue("@BuildingSubUse", objvo1.BuildingSubUse);
            com.Parameters.AddWithValue("@NoofFloors", objvo1.NoofFloors);
            com.Parameters.AddWithValue("@TechnicalName", objvo1.TechnicalName);
            com.Parameters.AddWithValue("@TechnicalEmailId", objvo1.TechnicalEmailId);
            com.Parameters.AddWithValue("@TechnicalMobileNo", objvo1.TechnicalMobileNo);
            com.Parameters.AddWithValue("@OwnerName", objvo1.OwnerName);
            com.Parameters.AddWithValue("@txtOwnerEmailId", objvo1.txtOwnerEmailId);
            com.Parameters.AddWithValue("@MobileNo", objvo1.MobileNo);

            com.Parameters.AddWithValue("@intQuessionaireCFOid", objvo1.intQuessionaireCFOid);
            com.Parameters.AddWithValue("@ApprovalID", objvo1.ApprovalID);
            com.Parameters.AddWithValue("@DeptID", objvo1.DeptID);
            com.Parameters.AddWithValue("@OnlineOffline", objvo1.OnlineOffline);

            com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
            com.Parameters["@Valid"].Direction = ParameterDirection.Output;

            com.Parameters.Add("@TSipassApplicationNo", SqlDbType.VarChar, 500);
            com.Parameters["@TSipassApplicationNo"].Direction = ParameterDirection.Output;

            com.ExecuteNonQuery();

            valid = com.Parameters["@Valid"].Value.ToString();
            ApplicationNumber = com.Parameters["@Valid"].Value.ToString();
            transaction.Commit();
            connection.Close();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw ex;
        }
        finally
        {
            connection.Close();
            connection.Dispose();
        }
        return valid;
    }

    protected void btngetdata_Click(object sender, EventArgs e)
    {

        TSIICService.ProposalDetailsResponse tsiicproposaldetailsvo = new TSIICService.ProposalDetailsResponse();
        TSIICService.SanctionBuildingDetailsResponse[] tsiicsanctiondetailsvo = null;
        HmdaOcVos hmdvo = new HmdaOcVos();
        try
        {
            if (txtfileNo.Text.Trim().ToUpper().Contains("IIC/"))
            {
                if (txtfileNo.Text.Trim() != "")
                {
                    TSIICapplicationresponse = TSIICObj.getDetailsforOccupancy(3, txtfileNo.Text.Trim(), "$$08@213");
                    if (TSIICapplicationresponse.ResponseStatus == 1)
                    {
                        DataSet dslocationdetails = new DataSet();

                        dslocationdetails = getdepartmentdetailsonuid(Session["uid"].ToString());
                        if (dslocationdetails.Tables.Count > 0)
                        {
                            ddlUnitDIst.SelectedValue = dslocationdetails.Tables[0].Rows[0]["Land_intDistrictid"].ToString();
                            ddldistrictunit_SelectedIndexChanged(sender, e);
                            ddlUnitMandal.SelectedValue = dslocationdetails.Tables[0].Rows[0]["Land_intMandalid"].ToString();
                            ddlUnitMandal_SelectedIndexChanged(sender, e);
                            ddlVillageunit.SelectedValue = dslocationdetails.Tables[0].Rows[0]["Land_intVillageid"].ToString();

                        }
                        //trmaindtlstab1.Visible = true;
                        tsiicproposaldetailsvo = TSIICapplicationresponse.ProposalDetailsResponse;
                        tsiicsanctiondetailsvo = TSIICapplicationresponse.SanctionBuildingList;
                        //hmdasanctiondetailsvo.GetValue
                        TSIICService.SanctionBuildingDetailsResponse sactionvo = new TSIICService.SanctionBuildingDetailsResponse();
                        lstSanctionBuildingDetails.Clear();
                        int tsiicbuildingcount = tsiicsanctiondetailsvo.Length;
                        for (int b = 0; b < tsiicbuildingcount; b++)
                        {
                            SanctionBuildingDetails SactionBuildingTsipassvo = new SanctionBuildingDetails();
                            sactionvo = tsiicsanctiondetailsvo[b];
                            SactionBuildingTsipassvo.Buildingid = Convert.ToString(sactionvo.BuildingId);
                            SactionBuildingTsipassvo.BuildingName = sactionvo.BuildingName;
                            SactionBuildingTsipassvo.intQuessionaireCFOid = Session["ApplidA"].ToString();
                            if (sactionvo.PlotId != 0)
                            {
                                SactionBuildingTsipassvo.PlotNo = Convert.ToString(sactionvo.PlotId);
                            }
                            SactionBuildingTsipassvo.CreatedBy = Session["uid"].ToString();
                            SactionBuildingTsipassvo.intCFOEnterid = Session["uid"].ToString();
                            lstSanctionBuildingDetails.Add(SactionBuildingTsipassvo);
                        }
                        hmdvo.intQuessionaireCFOid = Session["ApplidA"].ToString();
                        //int output = insetHMDABuildingDetails(lstSanctionBuildingDetails);
                        int output = Gen.insertbuildinglist(lstSanctionBuildingDetails, hmdvo);
                        txtMobileNo.Text = TSIICapplicationresponse.MobileNo;
                        txtOwnerName.Text = TSIICapplicationresponse.Name;

                        //string penalty = hmdapplicationresponse.PenaltyAmount;
                        //string totalamount = hmdapplicationresponse.TotalAmount;

                        txtProceedingIssuedOnDate.Text = tsiicproposaldetailsvo.Building_Permit_Date;
                        // hmdaproposaldetailsvo.Building_Permit_No;
                        // ddlUnitDIst.SelectedValue = "30";// tsiicproposaldetailsvo.District;
                        txtPlotNo.Text = tsiicproposaldetailsvo.Plot_No;
                        txtSurveyNo.Text = tsiicproposaldetailsvo.Survey_No;
                        // hmdaproposaldetailsvo.Tot_Lot_Area;
                        //ddldistrictunit_SelectedIndexChanged(sender, e);
                        //ddlUnitMandal.SelectedValue = "618";// tsiicproposaldetailsvo.Mandal;
                        //ddlUnitMandal_SelectedIndexChanged(sender, e);
                       // ddlVillageunit.SelectedValue = tsiicproposaldetailsvo.Village;
                        //   hmdaproposaldetailsvo.Ward_No;
                        txtofficezone.Text = tsiicproposaldetailsvo.Zone;

                        txtTechnicalEmailId.Text = tsiicproposaldetailsvo.Email;
                        // hmdaproposaldetailsvo.Locality;
                        // hmdaproposaldetailsvo.Location_Type;

                        txtTechnicalMobileNo.Text = tsiicproposaldetailsvo.MobileNo;
                        txtNoofFloors.Text = tsiicproposaldetailsvo.No_of_Building;
                        //hmdaproposaldetailsvo.Occupancy_Applied_for;
                        txtOwnerName.Text = tsiicproposaldetailsvo.Owner_Name;
                        // hmdaproposaldetailsvo.Parking_Space_Provisions;
                        txtPlotNo.Text = tsiicproposaldetailsvo.Plot_No;
                        txtBuildingProposedBuilding.Text = tsiicproposaldetailsvo.Proposed_Plot_Area;
                        txtBuildingSubUse.Text = tsiicproposaldetailsvo.Proposed_Use;
                        // hmdaproposaldetailsvo.Road_Street;
                        txtRoadAffectedArea.Text = tsiicproposaldetailsvo.Road_Widening;
                        txtRear.Text = tsiicproposaldetailsvo.RWH_Pits;

                        // hmdapplicationresponse.UniqueID;
                    }

                    //hmdapplicationresponse.
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter Correct Building Permission File No')", true);
                //BtnSave.Enabled = false;
                txtfileNo.Text = "";
                return;
            }
        }
        catch (Exception ex)
        {
        }
    }
    public DataSet getdepartmentdetailsonuid(string createdby)
    {

        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_GETTSIICLOCATIONDETAILS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (createdby.Trim() == "" || createdby.Trim() == null || createdby.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@createdby", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@createdby", SqlDbType.VarChar).Value = createdby.ToString();

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
    //protected void btngetdata_Click(object sender, EventArgs e)
    //{

    //    HMDAServiceTest.ProposalDetailsResponse hmdaproposaldetailsvo = new HMDAServiceTest.ProposalDetailsResponse();
    //    HMDAServiceTest.SanctionBuildingDetailsResponse[] hmdasanctiondetailsvo = null;
    //    HmdaOcVos hmdvo = new HmdaOcVos();
    //    try
    //    {
    //        if (txtfileNo.Text.Trim() != "")
    //        {
    //            hmdapplicationresponse = HMDAObj.getDetailsforOccupancy(11, txtfileNo.Text.Trim(), "$$08@213");
    //            if (hmdapplicationresponse.ResponseStatus == 1)
    //            {
    //                //trmaindtlstab1.Visible = true;
    //                hmdaproposaldetailsvo = hmdapplicationresponse.ProposalDetailsResponse;
    //                hmdasanctiondetailsvo = hmdapplicationresponse.SanctionBuildingList;
    //                //hmdasanctiondetailsvo.GetValue
    //                HMDAServiceTest.SanctionBuildingDetailsResponse sactionvo = new HMDAServiceTest.SanctionBuildingDetailsResponse();
    //                lstSanctionBuildingDetails.Clear();
    //                int hmdabuildingcount = hmdasanctiondetailsvo.Length;
    //                for (int b = 0; b < hmdabuildingcount; b++)
    //                {
    //                    sactionvo = hmdasanctiondetailsvo[b];
    //                    SactionBuildingTsipassvo.Buildingid = Convert.ToString(sactionvo.BuildingId);
    //                    SactionBuildingTsipassvo.BuildingName = sactionvo.BuildingName;
    //                    SactionBuildingTsipassvo.intQuessionaireCFOid = Session["ApplidA"].ToString();
    //                    if (sactionvo.PlotId != 0)
    //                    {
    //                        SactionBuildingTsipassvo.PlotNo = Convert.ToString(sactionvo.PlotId);
    //                    }
    //                    SactionBuildingTsipassvo.CreatedBy = Session["uid"].ToString();
    //                    SactionBuildingTsipassvo.intCFOEnterid = Session["uid"].ToString();
    //                    lstSanctionBuildingDetails.Add(SactionBuildingTsipassvo);
    //                }
    //                hmdvo.intQuessionaireCFOid = Session["ApplidA"].ToString();
    //                //int output = insetHMDABuildingDetails(lstSanctionBuildingDetails);
    //                int output = Gen.insertbuildinglist(lstSanctionBuildingDetails, hmdvo);
    //                txtMobileNo.Text = hmdapplicationresponse.MobileNo;
    //                txtOwnerName.Text = hmdapplicationresponse.Name;

    //                //string penalty = hmdapplicationresponse.PenaltyAmount;
    //                //string totalamount = hmdapplicationresponse.TotalAmount;
    //                txtProceedingIssuedOnDate.Text = hmdaproposaldetailsvo.Building_Permit_Date;
    //                // hmdaproposaldetailsvo.Building_Permit_No;
    //                ddlUnitDIst.SelectedValue = hmdaproposaldetailsvo.District;
    //                txtPlotNo.Text = hmdaproposaldetailsvo.Plot_No;
    //                txtSurveyNo.Text = hmdaproposaldetailsvo.Survey_No;
    //                // hmdaproposaldetailsvo.Tot_Lot_Area;
    //                ddldistrictunit_SelectedIndexChanged(sender, e);
    //                ddlUnitMandal.SelectedValue = hmdaproposaldetailsvo.Mandal;
    //                ddlUnitMandal_SelectedIndexChanged(sender, e);
    //                ddlVillageunit.SelectedValue = hmdaproposaldetailsvo.Village;
    //                //   hmdaproposaldetailsvo.Ward_No;
    //                txtofficezone.Text = hmdaproposaldetailsvo.Zone;

    //                txtTechnicalEmailId.Text = hmdaproposaldetailsvo.Email;
    //                // hmdaproposaldetailsvo.Locality;
    //                // hmdaproposaldetailsvo.Location_Type;

    //                txtTechnicalMobileNo.Text = hmdaproposaldetailsvo.MobileNo;
    //                txtNoofFloors.Text = hmdaproposaldetailsvo.No_of_Building;
    //                //hmdaproposaldetailsvo.Occupancy_Applied_for;
    //                txtOwnerName.Text = hmdaproposaldetailsvo.Owner_Name;
    //                // hmdaproposaldetailsvo.Parking_Space_Provisions;
    //                txtPlotNo.Text = hmdaproposaldetailsvo.Plot_No;
    //                txtBuildingProposedBuilding.Text = hmdaproposaldetailsvo.Proposed_Plot_Area;
    //                txtBuildingSubUse.Text = hmdaproposaldetailsvo.Proposed_Use;
    //                // hmdaproposaldetailsvo.Road_Street;
    //                txtRoadAffectedArea.Text = hmdaproposaldetailsvo.Road_Widening;
    //                txtRear.Text = hmdaproposaldetailsvo.RWH_Pits;

    //                // hmdapplicationresponse.UniqueID;
    //            }

    //            //hmdapplicationresponse.
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}


    protected void BtnSave3_Click(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
    protected void btntab6previous_Click(object sender, EventArgs e)
    {
        Tab1.Attributes.Add("class", "active");
        Tab2.Attributes.Add("class", "");
        //MainView.ActiveViewIndex = 0;
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string errormsg = ValidateControls("2");
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            else
            {
                AssignValuestoVosFromcontrols("1");
                lblmsg.Text = "<font color='green'>Occupancy Details Saved Successfully..!</font>";
                success.Visible = true;
                Failure.Visible = false;
                //Response.Redirect("frmCAFPowerDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
            }


        }
        catch (Exception ex)
        {
            Errors.ErrorLog(ex);
        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmOccupencyCertificateTSIIC.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
    }

    protected void BtnDelete0_Click(object sender, EventArgs e)
    {

        string errormsg = ValidateControls("2");
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        else
        {
            AssignValuestoVosFromcontrols("1");
            Response.Redirect("frmFiredetailsCFO.aspx.aspx?intApplicationId=" + Session["uid"].ToString() + "&Previous=" + "P");
            //Response.Redirect("frmCAFPowerDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
        }

    }

    public void AddSelect(DropDownList ddl)
    {
        try
        {
            ListItem li = new ListItem();
            li.Text = "--Select--";
            li.Value = "0";
            ddl.Items.Insert(0, li);
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
            //success.Visible = false;
        }
    }
    public void BindDistricts()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlUnitDIst.Items.Clear();
            dsd = Gen.GetDistrictsWithoutHYD();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlUnitDIst.DataSource = dsd.Tables[0];
                ddlUnitDIst.DataValueField = "District_Id";
                ddlUnitDIst.DataTextField = "District_Name";
                ddlUnitDIst.DataBind();
                AddSelect(ddlUnitDIst);
            }
            else
            {
                AddSelect(ddlUnitDIst);
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void ddldistrictunit_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlUnitDIst.SelectedValue == "0")
            {
                ddlUnitMandal.Items.Clear();
                AddSelect(ddlUnitMandal);
                ddlVillageunit.Items.Clear();
                AddSelect(ddlVillageunit);
            }
            else
            {
                ddlUnitMandal.Items.Clear();
                ddlVillageunit.Items.Clear();
                DataSet dsm = new DataSet();
                dsm = Gen.GetMandals(ddlUnitDIst.SelectedValue);
                if (dsm.Tables[0].Rows.Count > 0)
                {
                    ddlUnitMandal.DataSource = dsm.Tables[0];
                    ddlUnitMandal.DataValueField = "Mandal_Id";
                    ddlUnitMandal.DataTextField = "Manda_lName";
                    ddlUnitMandal.DataBind();
                    ddlUnitMandal.Items.Insert(0, "--Mandal--");
                }
                else
                {
                    ddlUnitMandal.Items.Clear();
                    AddSelect(ddlUnitMandal);
                    AddSelect(ddlVillageunit);
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void ddlUnitMandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (ddlUnitMandal.SelectedIndex == 0)
            {
                ddlVillageunit.Items.Clear();
                AddSelect(ddlVillageunit);
            }
            else
            {
                ddlVillageunit.Items.Clear();
                DataSet dsv = new DataSet();
                dsv = Gen.GetVillages(ddlUnitMandal.SelectedValue);
                if (dsv.Tables[0].Rows.Count > 0)
                {
                    ddlVillageunit.DataSource = dsv.Tables[0];
                    ddlVillageunit.DataValueField = "Village_Id";
                    ddlVillageunit.DataTextField = "Village_Name";
                    ddlVillageunit.DataBind();
                    AddSelect(ddlVillageunit);
                }
                else
                {
                    ddlVillageunit.Items.Clear();
                    AddSelect(ddlVillageunit);
                }

            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void BtnSavecompletedbuildingplan_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];
            string errormsg = "";
            General t1 = new General();
            if (FileUploadcompletedbuildingplan.HasFile)
            {
                if ((FileUploadcompletedbuildingplan.PostedFile != null) && (FileUploadcompletedbuildingplan.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(FileUploadcompletedbuildingplan.PostedFile.FileName);
                    try
                    {

                        string[] fileType = FileUploadcompletedbuildingplan.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\HMDAOCCertificateCompletedbuildingplan");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUploadcompletedbuildingplan.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUploadcompletedbuildingplan.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;

                            result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "HMDAOCCertificateCompletedbuildingplan");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                // lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                // lblFileNameErector.Text = FileUploadErector.FileName;
                                lblcompletedbuildingplan.Text = FileUploadcompletedbuildingplan.FileName;
                                lblcompletedbuildingplan.Visible = true;
                                //success.Visible = true;
                                //Failure.Visible = false;
                                Filldetails();

                                errormsg = "<font color='green'>Attachment Successfully Added..!</font>";
                                if (errormsg.Trim().TrimStart() != "")
                                {
                                    string message = "alert('" + errormsg + "')";
                                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                                    lblmsg0.Text = "";
                                    Failure.Visible = false;

                                    lblmsg.Text = errormsg;
                                    success.Visible = true;
                                }
                            }
                            else
                            {
                                errormsg = "<font color='red'>Attachment Added Failed..!</font>";
                                if (errormsg.Trim().TrimStart() != "")
                                {
                                    string message = "alert('" + errormsg + "')";
                                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                                    lblmsg0.Text = errormsg;
                                    Failure.Visible = true;
                                    success.Visible = false;
                                }

                                // lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            }
                        }
                        else
                        {
                            errormsg = "<font color='red'>Please Upload PDF files only..!</font>";
                            if (errormsg.Trim().TrimStart() != "")
                            {
                                string message = "alert('" + errormsg + "')";
                                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                                lblmsg0.Text = errormsg;
                                Failure.Visible = true;
                                success.Visible = false;
                            }

                            // lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";

                        }

                    }
                    catch (Exception)//in case of an error
                    {
                        DeleteFile(newPath + "\\" + sFileName);
                    }
                }
            }
            else
            {
                errormsg = "<font color='red'>Please Select a file To Upload..!</font>";
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                    lblmsg0.Text = errormsg;
                    Failure.Visible = true;
                    success.Visible = false;
                }

                // lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";

            }
        }
        catch (Exception ex)
        {
            string errormsg = "";
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            errormsg = ex.Message;
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                lblmsg0.Text = errormsg;
                Failure.Visible = true;
                success.Visible = false;
            }

        }
    }

    public void DeleteFile(string strFileName)
    {//Delete file from the server
        if (strFileName.Trim().Length > 0)
        {
            FileInfo fi = new FileInfo(strFileName);
            if (fi.Exists)//if file exists delete it
            {
                fi.Delete();
            }
        }
    }

    protected void btnPhotographsofconstructed_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];
            string errormsg = "";
            General t1 = new General();
            if (FileUploadPhotographsofconstructed.HasFile)
            {
                if ((FileUploadPhotographsofconstructed.PostedFile != null) && (FileUploadPhotographsofconstructed.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(FileUploadPhotographsofconstructed.PostedFile.FileName);
                    try
                    {

                        string[] fileType = FileUploadPhotographsofconstructed.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\HMDAOCCertificatePhotographsconstructedbuilding");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUploadPhotographsofconstructed.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUploadPhotographsofconstructed.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;

                            result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "HMDAOCCertificatePhotographsconstructedbuilding");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                // lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                // lblFileNameErector.Text = FileUploadErector.FileName;
                                lblPhotographsofconstructed.Text = FileUploadPhotographsofconstructed.FileName;
                                lblPhotographsofconstructed.Visible = true;
                                //success.Visible = true;
                                //Failure.Visible = false;
                                Filldetails();

                                errormsg = "<font color='green'>Attachment Successfully Added..!</font>";
                                if (errormsg.Trim().TrimStart() != "")
                                {
                                    string message = "alert('" + errormsg + "')";
                                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                                    lblmsg0.Text = "";
                                    Failure.Visible = false;

                                    lblmsg.Text = errormsg;
                                    success.Visible = true;
                                }
                            }
                            else
                            {
                                errormsg = "<font color='red'>Attachment Added Failed..!</font>";
                                if (errormsg.Trim().TrimStart() != "")
                                {
                                    string message = "alert('" + errormsg + "')";
                                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                                    lblmsg0.Text = errormsg;
                                    Failure.Visible = true;
                                    success.Visible = false;
                                }

                                // lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            }
                        }
                        else
                        {
                            errormsg = "<font color='red'>Please Upload PDF files only..!</font>";
                            if (errormsg.Trim().TrimStart() != "")
                            {
                                string message = "alert('" + errormsg + "')";
                                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                                lblmsg0.Text = errormsg;
                                Failure.Visible = true;
                                success.Visible = false;
                            }

                            // lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";

                        }

                    }
                    catch (Exception)//in case of an error
                    {
                        DeleteFile(newPath + "\\" + sFileName);
                    }
                }
            }
            else
            {
                errormsg = "<font color='red'>Please Select a file To Upload..!</font>";
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                    lblmsg0.Text = errormsg;
                    Failure.Visible = true;
                    success.Visible = false;
                }

                // lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";

            }
        }
        catch (Exception ex)
        {
            string errormsg = "";
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            errormsg = ex.Message;
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                lblmsg0.Text = errormsg;
                Failure.Visible = true;
                success.Visible = false;
            }

        }
    }

    protected void btnLandvaluecertificate_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];
            string errormsg = "";
            General t1 = new General();
            if (FileUploadLandvaluecertificate.HasFile)
            {
                if ((FileUploadLandvaluecertificate.PostedFile != null) && (FileUploadLandvaluecertificate.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(FileUploadLandvaluecertificate.PostedFile.FileName);
                    try
                    {

                        string[] fileType = FileUploadLandvaluecertificate.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\HMDAOCCertificateLandvaluecertificate");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUploadLandvaluecertificate.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUploadLandvaluecertificate.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;

                            result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "HMDAOCCertificateLandvaluecertificate");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                // lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                // lblFileNameErector.Text = FileUploadErector.FileName;
                                lblLandvaluecertificate.Text = FileUploadLandvaluecertificate.FileName;
                                lblLandvaluecertificate.Visible = true;
                                Filldetails();
                                //success.Visible = true;
                                //Failure.Visible = false;

                                errormsg = "<font color='green'>Attachment Successfully Added..!</font>";
                                if (errormsg.Trim().TrimStart() != "")
                                {
                                    string message = "alert('" + errormsg + "')";
                                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                                    lblmsg0.Text = "";
                                    Failure.Visible = false;

                                    lblmsg.Text = errormsg;
                                    success.Visible = true;
                                }
                            }
                            else
                            {
                                errormsg = "<font color='red'>Attachment Added Failed..!</font>";
                                if (errormsg.Trim().TrimStart() != "")
                                {
                                    string message = "alert('" + errormsg + "')";
                                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                                    lblmsg0.Text = errormsg;
                                    Failure.Visible = true;
                                    success.Visible = false;
                                }

                                // lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            }
                        }
                        else
                        {
                            errormsg = "<font color='red'>Please Upload PDF files only..!</font>";
                            if (errormsg.Trim().TrimStart() != "")
                            {
                                string message = "alert('" + errormsg + "')";
                                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                                lblmsg0.Text = errormsg;
                                Failure.Visible = true;
                                success.Visible = false;
                            }

                            // lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";

                        }

                    }
                    catch (Exception)//in case of an error
                    {
                        DeleteFile(newPath + "\\" + sFileName);
                    }
                }
            }
            else
            {
                errormsg = "<font color='red'>Please Select a file To Upload..!</font>";
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                    lblmsg0.Text = errormsg;
                    Failure.Visible = true;
                    success.Visible = false;
                }

                // lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";

            }
        }
        catch (Exception ex)
        {
            string errormsg = "";
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            errormsg = ex.Message;
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                lblmsg0.Text = errormsg;
                Failure.Visible = true;
                success.Visible = false;
            }

        }
    }

    protected void btnBuildingCompletionArchitect_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\CFOAttachments");
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];
            string errormsg = "";
            General t1 = new General();
            if (FileUploadBuildingCompletionArchitect.HasFile)
            {
                if ((FileUploadBuildingCompletionArchitect.PostedFile != null) && (FileUploadBuildingCompletionArchitect.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(FileUploadBuildingCompletionArchitect.PostedFile.FileName);
                    try
                    {

                        string[] fileType = FileUploadBuildingCompletionArchitect.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\HMDAOCCertificateBuildingCompletionNotice");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUploadBuildingCompletionArchitect.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUploadBuildingCompletionArchitect.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;

                            result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "HMDAOCCertificateBuildingCompletionNotice");

                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                // lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                // lblFileNameErector.Text = FileUploadErector.FileName;
                                lblBuildingCompletionArchitect.Text = FileUploadBuildingCompletionArchitect.FileName;
                                lblBuildingCompletionArchitect.Visible = true;
                                //success.Visible = true;
                                //Failure.Visible = false;
                                Filldetails();

                                errormsg = "<font color='green'>Attachment Successfully Added..!</font>";
                                if (errormsg.Trim().TrimStart() != "")
                                {
                                    string message = "alert('" + errormsg + "')";
                                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                                    lblmsg0.Text = "";
                                    Failure.Visible = false;

                                    lblmsg.Text = errormsg;
                                    success.Visible = true;
                                }
                            }
                            else
                            {
                                errormsg = "<font color='red'>Attachment Added Failed..!</font>";
                                if (errormsg.Trim().TrimStart() != "")
                                {
                                    string message = "alert('" + errormsg + "')";
                                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                                    lblmsg0.Text = errormsg;
                                    Failure.Visible = true;
                                    success.Visible = false;
                                }

                                // lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            }
                        }
                        else
                        {
                            errormsg = "<font color='red'>Please Upload PDF files only..!</font>";
                            if (errormsg.Trim().TrimStart() != "")
                            {
                                string message = "alert('" + errormsg + "')";
                                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                                lblmsg0.Text = errormsg;
                                Failure.Visible = true;
                                success.Visible = false;
                            }

                            // lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";

                        }

                    }
                    catch (Exception)//in case of an error
                    {
                        DeleteFile(newPath + "\\" + sFileName);
                    }
                }
            }
            else
            {
                errormsg = "<font color='red'>Please Select a file To Upload..!</font>";
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                    lblmsg0.Text = errormsg;
                    Failure.Visible = true;
                    success.Visible = false;
                }

                // lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";

            }
        }
        catch (Exception ex)
        {
            string errormsg = "";
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            errormsg = ex.Message;
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                lblmsg0.Text = errormsg;
                Failure.Visible = true;
                success.Visible = false;
            }

        }
    }

    protected void btnregisteredgiftdeed_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];
            string errormsg = "";
            General t1 = new General();
            if (FileUploadregisteredgiftdeed.HasFile)
            {
                if ((FileUploadregisteredgiftdeed.PostedFile != null) && (FileUploadregisteredgiftdeed.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(FileUploadregisteredgiftdeed.PostedFile.FileName);
                    try
                    {

                        string[] fileType = FileUploadregisteredgiftdeed.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\HMDAOCCertificateRegisteredgiftdeed");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUploadregisteredgiftdeed.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUploadregisteredgiftdeed.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;

                            result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "HMDAOCCertificateRegisteredgiftdeed");

                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                // lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                // lblFileNameErector.Text = FileUploadErector.FileName;
                                lblregisteredgiftdeed.Text = FileUploadregisteredgiftdeed.FileName;
                                lblregisteredgiftdeed.Visible = true;
                                //success.Visible = true;
                                //Failure.Visible = false;

                                errormsg = "<font color='green'>Attachment Successfully Added..!</font>";
                                if (errormsg.Trim().TrimStart() != "")
                                {
                                    string message = "alert('" + errormsg + "')";
                                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                                    lblmsg0.Text = "";
                                    Failure.Visible = false;

                                    lblmsg.Text = errormsg;
                                    success.Visible = true;
                                }
                            }
                            else
                            {
                                errormsg = "<font color='red'>Attachment Added Failed..!</font>";
                                if (errormsg.Trim().TrimStart() != "")
                                {
                                    string message = "alert('" + errormsg + "')";
                                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                                    lblmsg0.Text = errormsg;
                                    Failure.Visible = true;
                                    success.Visible = false;
                                }

                                // lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            }
                        }
                        else
                        {
                            errormsg = "<font color='red'>Please Upload PDF files only..!</font>";
                            if (errormsg.Trim().TrimStart() != "")
                            {
                                string message = "alert('" + errormsg + "')";
                                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                                lblmsg0.Text = errormsg;
                                Failure.Visible = true;
                                success.Visible = false;
                            }

                            // lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";

                        }

                    }
                    catch (Exception)//in case of an error
                    {
                        DeleteFile(newPath + "\\" + sFileName);
                    }
                }
            }
            else
            {
                errormsg = "<font color='red'>Please Select a file To Upload..!</font>";
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                    lblmsg0.Text = errormsg;
                    Failure.Visible = true;
                    success.Visible = false;
                }

                // lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";

            }
        }
        catch (Exception ex)
        {
            string errormsg = "";
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            errormsg = ex.Message;
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                lblmsg0.Text = errormsg;
                Failure.Visible = true;
                success.Visible = false;
            }

        }
    }

    protected void btngovernmentordercopy_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];
            string errormsg = "";
            General t1 = new General();
            if (FileUploadgovernmentordercopy.HasFile)
            {
                if ((FileUploadgovernmentordercopy.PostedFile != null) && (FileUploadgovernmentordercopy.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(FileUploadgovernmentordercopy.PostedFile.FileName);
                    try
                    {

                        string[] fileType = FileUploadgovernmentordercopy.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\HMDAOCCertificateStateCentralgovernmentordercopy");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUploadgovernmentordercopy.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUploadgovernmentordercopy.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;

                            result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "HMDAOCCertificateStateCentralgovernmentordercopy");

                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                // lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                // lblFileNameErector.Text = FileUploadErector.FileName;
                                lblgovernmentordercopy.Text = FileUploadgovernmentordercopy.FileName;
                                lblgovernmentordercopy.Visible = true;
                                //success.Visible = true;
                                //Failure.Visible = false;

                                errormsg = "<font color='green'>Attachment Successfully Added..!</font>";
                                if (errormsg.Trim().TrimStart() != "")
                                {
                                    string message = "alert('" + errormsg + "')";
                                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                                    lblmsg0.Text = "";
                                    Failure.Visible = false;

                                    lblmsg.Text = errormsg;
                                    success.Visible = true;
                                }
                            }
                            else
                            {
                                errormsg = "<font color='red'>Attachment Added Failed..!</font>";
                                if (errormsg.Trim().TrimStart() != "")
                                {
                                    string message = "alert('" + errormsg + "')";
                                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                                    lblmsg0.Text = errormsg;
                                    Failure.Visible = true;
                                    success.Visible = false;
                                }

                                // lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            }
                        }
                        else
                        {
                            errormsg = "<font color='red'>Please Upload PDF files only..!</font>";
                            if (errormsg.Trim().TrimStart() != "")
                            {
                                string message = "alert('" + errormsg + "')";
                                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                                lblmsg0.Text = errormsg;
                                Failure.Visible = true;
                                success.Visible = false;
                            }

                            // lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";

                        }

                    }
                    catch (Exception)//in case of an error
                    {
                        DeleteFile(newPath + "\\" + sFileName);
                    }
                }
            }
            else
            {
                errormsg = "<font color='red'>Please Select a file To Upload..!</font>";
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                    lblmsg0.Text = errormsg;
                    Failure.Visible = true;
                    success.Visible = false;
                }

                // lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";

            }
        }
        catch (Exception ex)
        {
            string errormsg = "";
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            errormsg = ex.Message;
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                lblmsg0.Text = errormsg;
                Failure.Visible = true;
                success.Visible = false;
            }

        }
    }

    protected void btnEngineercompletioncertificate_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];
            string errormsg = "";
            General t1 = new General();
            if (FileUploadEngineercompletioncertificate.HasFile)
            {
                if ((FileUploadEngineercompletioncertificate.PostedFile != null) && (FileUploadEngineercompletioncertificate.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(FileUploadEngineercompletioncertificate.PostedFile.FileName);
                    try
                    {

                        string[] fileType = FileUploadEngineercompletioncertificate.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\HMDAOCCertificateArchitectStructuralEngineerCompletion");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUploadEngineercompletioncertificate.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUploadEngineercompletioncertificate.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;

                            result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "HMDAOCCertificateArchitectStructuralEngineerCompletion");

                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                // lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                // lblFileNameErector.Text = FileUploadErector.FileName;
                                lblEngineercompletioncertificate.Text = FileUploadEngineercompletioncertificate.FileName;
                                lblEngineercompletioncertificate.Visible = true;
                                //success.Visible = true;
                                //Failure.Visible = false;

                                errormsg = "<font color='green'>Attachment Successfully Added..!</font>";
                                if (errormsg.Trim().TrimStart() != "")
                                {
                                    string message = "alert('" + errormsg + "')";
                                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                                    lblmsg0.Text = "";
                                    Failure.Visible = false;

                                    lblmsg.Text = errormsg;
                                    success.Visible = true;
                                }
                            }
                            else
                            {
                                errormsg = "<font color='red'>Attachment Added Failed..!</font>";
                                if (errormsg.Trim().TrimStart() != "")
                                {
                                    string message = "alert('" + errormsg + "')";
                                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                                    lblmsg0.Text = errormsg;
                                    Failure.Visible = true;
                                    success.Visible = false;
                                }

                                // lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            }
                        }
                        else
                        {
                            errormsg = "<font color='red'>Please Upload PDF files only..!</font>";
                            if (errormsg.Trim().TrimStart() != "")
                            {
                                string message = "alert('" + errormsg + "')";
                                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                                lblmsg0.Text = errormsg;
                                Failure.Visible = true;
                                success.Visible = false;
                            }

                            // lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";

                        }

                    }
                    catch (Exception)//in case of an error
                    {
                        DeleteFile(newPath + "\\" + sFileName);
                    }
                }
            }
            else
            {
                errormsg = "<font color='red'>Please Select a file To Upload..!</font>";
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                    lblmsg0.Text = errormsg;
                    Failure.Visible = true;
                    success.Visible = false;
                }

                // lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";

            }
        }
        catch (Exception ex)
        {
            string errormsg = "";
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            errormsg = ex.Message;
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                lblmsg0.Text = errormsg;
                Failure.Visible = true;
                success.Visible = false;
            }

        }
    }

    protected void btnFinalFireNoc_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];
            string errormsg = "";
            General t1 = new General();
            if (fileuploadFinalFireNoc.HasFile)
            {
                if ((fileuploadFinalFireNoc.PostedFile != null) && (fileuploadFinalFireNoc.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fileuploadFinalFireNoc.PostedFile.FileName);
                    try
                    {

                        string[] fileType = fileuploadFinalFireNoc.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\HMDAOCCertificateFinalFireNoc");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fileuploadFinalFireNoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fileuploadFinalFireNoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;

                            result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "HMDAOCCertificateFinalFireNoc");

                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                // lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                // lblFileNameErector.Text = FileUploadErector.FileName;
                                lblFinalFireNoc.Text = fileuploadFinalFireNoc.FileName;
                                lblFinalFireNoc.Visible = true;
                                //success.Visible = true;
                                //Failure.Visible = false;

                                errormsg = "<font color='green'>Attachment Successfully Added..!</font>";
                                if (errormsg.Trim().TrimStart() != "")
                                {
                                    string message = "alert('" + errormsg + "')";
                                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                                    lblmsg0.Text = "";
                                    Failure.Visible = false;

                                    lblmsg.Text = errormsg;
                                    success.Visible = true;
                                }
                            }
                            else
                            {
                                errormsg = "<font color='red'>Attachment Added Failed..!</font>";
                                if (errormsg.Trim().TrimStart() != "")
                                {
                                    string message = "alert('" + errormsg + "')";
                                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                                    lblmsg0.Text = errormsg;
                                    Failure.Visible = true;
                                    success.Visible = false;
                                }

                                // lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            }
                        }
                        else
                        {
                            errormsg = "<font color='red'>Please Upload PDF files only..!</font>";
                            if (errormsg.Trim().TrimStart() != "")
                            {
                                string message = "alert('" + errormsg + "')";
                                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                                lblmsg0.Text = errormsg;
                                Failure.Visible = true;
                                success.Visible = false;
                            }

                            // lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";

                        }

                    }
                    catch (Exception)//in case of an error
                    {
                        DeleteFile(newPath + "\\" + sFileName);
                    }
                }
            }
            else
            {
                errormsg = "<font color='red'>Please Select a file To Upload..!</font>";
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                    lblmsg0.Text = errormsg;
                    Failure.Visible = true;
                    success.Visible = false;
                }

                // lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";

            }
        }
        catch (Exception ex)
        {
            string errormsg = "";
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            errormsg = ex.Message;
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                lblmsg0.Text = errormsg;
                Failure.Visible = true;
                success.Visible = false;
            }

        }
    }


    public DataSet GethmdaocDATA(string intQuerid, string ApprovalID)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@intQuessionaireCFOid",SqlDbType.VarChar),
               new SqlParameter("@ApprovalID",SqlDbType.VarChar)
           };
        pp[0].Value = intQuerid;
        pp[1].Value = ApprovalID;
        Dsnew = Gen.GenericFillDs("USP_GET_OCDTLS", pp);
        return Dsnew;
    }

    public int insetHMDABuildingDetails(List<SanctionBuildingDetails> lstSanctionBuildingDetails)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        //string valid = "";
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        SqlConnection connectiondel = new SqlConnection(str);
        SqlTransaction transactiondel = null;
        connection.Open();
        transaction = connection.BeginTransaction();
        connectiondel.Open();
        transactiondel = connectiondel.BeginTransaction();
        int valid = 0;
        //con.OpenConnection();
        //SqlCommand cmd = null;
        SqlCommand com = new SqlCommand();
        SqlCommand cmdDelPromoterdetails = new SqlCommand();

        com.Transaction = transaction;
        com.Connection = connection;
        cmdDelPromoterdetails.Transaction = transactiondel;
        cmdDelPromoterdetails.Connection = connectiondel;
        try
        {
            //SqlCommand com = new SqlCommand("[USP_DEL_SactionBuildingDetails]", connection);
            cmdDelPromoterdetails.CommandType = CommandType.StoredProcedure;
            cmdDelPromoterdetails.CommandText = "USP_DEL_SactionBuildingDetails";
            cmdDelPromoterdetails.Transaction = transaction;
            cmdDelPromoterdetails.Connection = connection;
            cmdDelPromoterdetails.Parameters.AddWithValue("@QuessionaireidCFO", SqlDbType.Int).Value = Session["ApplidA"].ToString(); //objProfftaxtpromdetails.QuestionnaireId;
            cmdDelPromoterdetails.ExecuteNonQuery();
            transactiondel.Commit();
            //connectiondel.Close();

            foreach (SanctionBuildingDetails sanctionvo in lstSanctionBuildingDetails)
            {

                com.CommandText = "USP_INSERT_HMDA_OC_BuildingDetails";
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@CFOEnterpid", Session["uid"].ToString());
                com.Parameters.AddWithValue("@QuessionaireidCFO", Session["ApplidA"].ToString());
                com.Parameters.AddWithValue("@BuildingID", Convert.ToString(sanctionvo.Buildingid));
                com.Parameters.AddWithValue("@BuildingName", Convert.ToString(sanctionvo.BuildingName));
                com.Parameters.AddWithValue("@PlotNo", Convert.ToString(sanctionvo.PlotNo));
                com.Parameters.AddWithValue("@Created_By", sanctionvo.CreatedBy);
                com.Parameters.Add("@Valid", SqlDbType.Int, 500);
                com.Parameters["@Valid"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();
                valid = (Int32)com.Parameters["@Valid"].Value;
                //connection.Close();
            }
            transaction.Commit();
        }
        catch (Exception ex)
        {
            transactiondel.Rollback();
            transaction.Rollback();

            throw ex;
        }
        finally
        {
            connectiondel.Close();
            connectiondel.Dispose();
            connection.Close();
            connection.Dispose();
        }
        return valid;
    }
    void Filldetails()
    {
        try
        {

            DataSet dsattachments = new DataSet();
            dsattachments = Gen.ViewAttachmentCFO(Session["uid"].ToString());

            if (dsattachments.Tables[0].Rows.Count > 0)
            {
                int c = dsattachments.Tables[0].Rows.Count;
                string sen, sen1, sen2;
                int i = 0;

                while (i < c)
                {
                    sen2 = dsattachments.Tables[0].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    //  sen = sen1.Replace(@"C:/TSiPASS/Attachments/1192/", "~/");//"C:/TSiPASS/Attachments/1192/B1Form\CateogryofRegistration.jpg"
                    string filepathnew = dsattachments.Tables[0].Rows[i]["linkview"].ToString();// LINKNEW .Tables[0].Rows[i][0].ToString();
                    string encpassword = Gen.Encrypt(filepathnew, "SYSTIME");
                    if (sen1.Contains("CFOAttachments"))
                    {
                        sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/CFOAttachments")), "~/");
                        if (sen.Contains("HMDAOCCertificateCompletedbuildingplan"))
                        {
                            hplcompletedbuildingplan.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            hplcompletedbuildingplan.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                            hplcompletedbuildingplan.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                        }
                        if (sen.Contains("HMDAOCCertificatePhotographsconstructedbuilding"))
                        {
                            hplPhotographsofconstructed.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            hplPhotographsofconstructed.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                            hplPhotographsofconstructed.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                        }
                        if (sen.Contains("HMDAOCCertificateLandvaluecertificate"))
                        {
                            hplLandvaluecertificate.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            hplLandvaluecertificate.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                            hplLandvaluecertificate.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                        }
                        if (sen.Contains("HMDAOCCertificateBuildingCompletionNotice"))
                        {
                            hplBuildingCompletionArchitect.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            hplBuildingCompletionArchitect.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                            hplBuildingCompletionArchitect.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                        }
                        if (sen.Contains("HMDAOCCertificateRegisteredgiftdeed"))
                        {
                            hplregisteredgiftdeed.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            hplregisteredgiftdeed.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                            hplregisteredgiftdeed.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                        }
                        if (sen.Contains("HMDAOCCertificateStateCentralgovernmentordercopy"))
                        {
                            hplgovernmentordercopy.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            hplgovernmentordercopy.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                            hplgovernmentordercopy.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                        }
                        if (sen.Contains("HMDAOCCertificateArchitectStructuralEngineerCompletion"))
                        {
                            hplEngineercompletioncertificate.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            hplEngineercompletioncertificate.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                            hplEngineercompletioncertificate.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                        }
                        if (sen.Contains("HMDAOCCertificateFinalFireNoc"))
                        {
                            hplFinalFireNoc.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            hplFinalFireNoc.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                            hplFinalFireNoc.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                        }
                    }
                    i++;
                }
            }
            DataSet DSOCDATA = new DataSet();
            DSOCDATA = RetrievehmdaocDATA(Session["ApplidA"].ToString(), "74");

            if (DSOCDATA.Tables[0].Rows.Count > 0)
            {
                RbtsDPMScheck.SelectedValue = DSOCDATA.Tables[0].Rows[0]["OnlineOffline"].ToString();
                txtfileNo.Text = DSOCDATA.Tables[0].Rows[0]["HMDAFileNo"].ToString();
                txtWorkCommencedDate.Text = DSOCDATA.Tables[0].Rows[0]["WorkCommencedDate"].ToString();
                txtWorkCompletionDate.Text = DSOCDATA.Tables[0].Rows[0]["WorkCompletionDate"].ToString();
                txtDueDateforCompletionofBuilding.Text = DSOCDATA.Tables[0].Rows[0]["DueDateforCompletionofBuilding"].ToString();

                txtOccupancyAppliedFor.Text = DSOCDATA.Tables[0].Rows[0]["OccupancyAppliedFor"].ToString();
                ddlUnitDIst.SelectedValue = DSOCDATA.Tables[0].Rows[0]["UnitDIst"].ToString();
                ddldistrictunit_SelectedIndexChanged(this, EventArgs.Empty);
                ddlUnitMandal.SelectedValue = DSOCDATA.Tables[0].Rows[0]["UnitMandal"].ToString();
                ddlUnitMandal_SelectedIndexChanged(this, EventArgs.Empty);
                ddlVillageunit.SelectedValue = DSOCDATA.Tables[0].Rows[0]["Villageunit"].ToString();
                txtofficezone.Text = DSOCDATA.Tables[0].Rows[0]["OfficeZone"].ToString();
                txtPlotNo.Text = DSOCDATA.Tables[0].Rows[0]["PlotNo"].ToString();
                txtSurveyNo.Text = DSOCDATA.Tables[0].Rows[0]["SurveyNo"].ToString();

            }
            TSIICService.ProposalDetailsResponse tsiicproposaldetailsvo = new TSIICService.ProposalDetailsResponse();
            TSIICService.SanctionBuildingDetailsResponse[] tsiicsanctiondetailsvo = null;
            HmdaOcVos hmdvo = new HmdaOcVos();
            try
            {
                if (txtfileNo.Text.Trim() != "")
                {
                    TSIICapplicationresponse = TSIICObj.getDetailsforOccupancy(3, txtfileNo.Text.Trim(), "$$08@213");
                    if (TSIICapplicationresponse.ResponseStatus == 1)
                    {
                        tsiicproposaldetailsvo = TSIICapplicationresponse.ProposalDetailsResponse;
                        tsiicsanctiondetailsvo = TSIICapplicationresponse.SanctionBuildingList;
                        //hmdasanctiondetailsvo.GetValue
                        TSIICService.SanctionBuildingDetailsResponse sactionvo = new TSIICService.SanctionBuildingDetailsResponse();
                        lstSanctionBuildingDetails.Clear();
                        int tsiicbuildingcount = tsiicsanctiondetailsvo.Length;
                        for (int b = 0; b < tsiicbuildingcount; b++)
                        {
                            SanctionBuildingDetails SactionBuildingTsipassvo = new SanctionBuildingDetails();
                            sactionvo = tsiicsanctiondetailsvo[b];
                            SactionBuildingTsipassvo.Buildingid = Convert.ToString(sactionvo.BuildingId);
                            SactionBuildingTsipassvo.BuildingName = sactionvo.BuildingName;
                            SactionBuildingTsipassvo.intQuessionaireCFOid = Session["ApplidA"].ToString();
                            if (sactionvo.PlotId != 0)
                            {
                                SactionBuildingTsipassvo.PlotNo = Convert.ToString(sactionvo.PlotId);
                            }
                            SactionBuildingTsipassvo.CreatedBy = Session["uid"].ToString();
                            SactionBuildingTsipassvo.intCFOEnterid = Session["uid"].ToString();
                            lstSanctionBuildingDetails.Add(SactionBuildingTsipassvo);
                        }
                        hmdvo.intQuessionaireCFOid = Session["ApplidA"].ToString();
                        int output = Gen.insertbuildinglist(lstSanctionBuildingDetails, hmdvo);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        catch (Exception ex)
        {
        }
    }
    public DataSet RetrievehmdaocDATA(string intQuerid, string ApprovalID)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@intQuessionaireCFOid",SqlDbType.VarChar),
               new SqlParameter("@ApprovalID",SqlDbType.VarChar)
           };
        pp[0].Value = intQuerid;
        pp[1].Value = ApprovalID;
        Dsnew = Gen.GenericFillDs("USP_RETRIEVE_OCDTLS", pp);
        return Dsnew;
    }
}