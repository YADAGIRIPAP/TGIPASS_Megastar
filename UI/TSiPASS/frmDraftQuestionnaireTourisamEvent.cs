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


public partial class TSTBDCReg1 : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    int hp;
    DB.DB con = new DB.DB();
    decimal TotalFee = Convert.ToDecimal("0");

    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (Session.Count <= 0)
        {
            Response.Redirect("../../frmUserLogin.aspx");
        }
        //if (Session.Count <= 0)
        //{
        //    Response.Redirect("~/Index.aspx");

        //}

        //lblHeading.Text = Request.QueryString[1].ToString().Trim();
        if (!IsPostBack)
        {
            BindWorktimingsFrom();
            BindWorktimingsTo();
            BindPerformancetimingsFrom();
            BindPerformancetimingsTo();
            BindTypeOfEvents();
            BindFabricationMaterial();
            
            BindDistricts();
            BindCompanyDistricts();
            BindCategoryForVehicleStandBy();
            filldetails();
        }

    }
    public void BindWorktimingsFrom()
    {
        DataSet dsworkfrom = new DataSet();
        dsworkfrom = GetWorkingFrom();
        if (dsworkfrom.Tables[0].Rows.Count > 0)
        {
            ddlworktimingsfrom.DataSource = dsworkfrom.Tables[0];
            ddlworktimingsfrom.DataTextField = "TIME";
            ddlworktimingsfrom.DataValueField = "TIME_ID";
            ddlworktimingsfrom.DataBind();

            ddlworktimingsfrom.Items.Insert(0, new ListItem("Select", "0"));

        }
    }
    public DataSet GetWorkingFrom()
    {
        DataSet Dsnew = new DataSet();

        Dsnew = Gen.GenericFillDs("GETTIMINGS");
        return Dsnew;
    }
    public void BindWorktimingsTo()
    {
        DataSet dsworkto = new DataSet();
        dsworkto = GetWorkingTo();
        if (dsworkto.Tables[0].Rows.Count > 0)
        {
            ddlworktimingsto.DataSource = dsworkto.Tables[0];
            ddlworktimingsto.DataTextField = "TIME";
            ddlworktimingsto.DataValueField = "TIME_ID";
            ddlworktimingsto.DataBind();

            ddlworktimingsto.Items.Insert(0, new ListItem("Select", "0"));

        }
    }
    public DataSet GetWorkingTo()
    {
        DataSet Dsnew = new DataSet();

        Dsnew = Gen.GenericFillDs("GETTIMINGS");
        return Dsnew;
    }

    public void BindPerformancetimingsFrom()
    {
        DataSet dsperformancefrom = new DataSet();
        dsperformancefrom = GetPerformanceFrom();
        if (dsperformancefrom.Tables[0].Rows.Count > 0)
        {
            ddlperformancetimingsfrom.DataSource = dsperformancefrom.Tables[0];
            ddlperformancetimingsfrom.DataTextField = "TIME";
            ddlperformancetimingsfrom.DataValueField = "TIME_ID";
            ddlperformancetimingsfrom.DataBind();

            ddlperformancetimingsfrom.Items.Insert(0, new ListItem("Select", "0"));

        }
    }
    public DataSet GetPerformanceFrom()
    {
        DataSet Dsnew = new DataSet();

        Dsnew = Gen.GenericFillDs("GETTIMINGS");
        return Dsnew;
    }
    public void BindPerformancetimingsTo()
    {
        DataSet dsperformanceto = new DataSet();
        dsperformanceto = GetPerformanceTo();
        if (dsperformanceto.Tables[0].Rows.Count > 0)
        {
            ddlperformancetimingsto.DataSource = dsperformanceto.Tables[0];
            ddlperformancetimingsto.DataTextField = "TIME";
            ddlperformancetimingsto.DataValueField = "TIME_ID";
            ddlperformancetimingsto.DataBind();

            ddlperformancetimingsto.Items.Insert(0, new ListItem("Select", "0"));

        }
    }
    public DataSet GetPerformanceTo()
    {
        DataSet Dsnew = new DataSet();

        Dsnew = Gen.GenericFillDs("GETTIMINGS");
        return Dsnew;
    }
    public void BindTypeOfEvents()
    {
        DataSet dsTypes = new DataSet();
        dsTypes = Gen.GetTourismEventsTypeOfEventsMaster();
        if (dsTypes.Tables[0].Rows.Count > 0)
        {
            ddlTypeofEvent.DataSource = dsTypes.Tables[0];
            ddlTypeofEvent.DataTextField = "TypeOfEvent";
            ddlTypeofEvent.DataValueField = "TypeOfEvent_ID";
            ddlTypeofEvent.DataBind();

            ddlTypeofEvent.Items.Insert(0, new ListItem("Select", "0"));

        }
    }

    public void BindFabricationMaterial()
    {
        DataSet dsFab = new DataSet();
        dsFab = Gen.GetTourismEventsFabricationMaterialMaster();
        if (dsFab.Tables[0].Rows.Count > 0)
        {
            ddlFabrication.DataSource = dsFab.Tables[0];
            ddlFabrication.DataTextField = "FabricationMaterial_Name";
            ddlFabrication.DataValueField = "Fabrication_ID";
            ddlFabrication.DataBind();

            ddlFabrication.Items.Insert(0, new ListItem("Select", "0"));

        }
    }
    public void BindCategoryForVehicleStandBy()
    {
        DataSet dsland = new DataSet();
        dsland = GetCategoryForVehicleStandBy();
        if (dsland.Tables[0].Rows.Count > 0)
        {
            ddlcategoryvehiclestandby.DataSource = dsland.Tables[0];
            ddlcategoryvehiclestandby.DataTextField = "Category ";
            ddlcategoryvehiclestandby.DataValueField = "id";
            ddlcategoryvehiclestandby.DataBind();

            ddlcategoryvehiclestandby.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }
    public DataSet GetCategoryForVehicleStandBy()
    {
        DataSet Dsnew = new DataSet();

        Dsnew = Gen.GenericFillDs("GetVehicleStandByCategory");
        return Dsnew;
    }
    protected void ddlTypeofEvent_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ddlstructureType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlstructureType.SelectedValue == "4")
        {
            rbtStandbyFireService.Enabled = false;
            rbtStandbyFireService.SelectedValue = "Y";
            rbtStandbyFireService_SelectedIndexChanged(sender, e);
        }
        else
        {
            rbtStandbyFireService.Enabled = true;
            //rbtStandbyFireService.SelectedValue = "Y";
        }

    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {

    }
    public string ValidateControls()
    {
        int slno = 1;
        string ErrorMsg = "";

        if (ddlTypeofEvent.SelectedValue == "0" || ddlTypeofEvent.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Event Type\\n";
            slno = slno + 1;
        }
        if (rbtClassificationofEvent.SelectedValue == "" || rbtClassificationofEvent.SelectedItem.Text == "NULL")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Classification of Event \\n";
            slno = slno + 1;
        }
        if (txtNameofTheApplicant.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Applicant Name \\n";
            slno = slno + 1;
        }
        if (txtFatherName.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Father Name \\n";
            slno = slno + 1;
        }
        //if (txtAadharNumber.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Aadhar number \\n";
        //    slno = slno + 1;
        //}
        //if (txtPanNumber.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter PAN number \\n";
        //    slno = slno + 1;
        //}
        if (txtAddressWithContact.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter address \\n";
            slno = slno + 1;
        }
        if (txtMobileNumberApplicant.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Applicant Mobile number \\n";
            slno = slno + 1;
        }
        if (txtEmailID.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Applicant mail id \\n";
            slno = slno + 1;
        }
        if (txtNameAddEventManagement.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter  Name of the event management company \\n";
            slno = slno + 1;
        }
        if (txtcompanyaddress.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Company address \\n";
            slno = slno + 1;
        }
        if (txtGSTNumber.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter GST number \\n";
            slno = slno + 1;
        }
        if (txtNameLocPerformance.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Name and location of the place where the performance is to be held \\n";
            slno = slno + 1;
        }
        if (txtarea.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Location Area \\n";
            slno = slno + 1;
        }
        if (ddlstructureType.SelectedValue == "0" || ddlstructureType.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select type of structure planned \\n";
            slno = slno + 1;
        }
        if (txtNoofStalls.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter no of stalls \\n";
            slno = slno + 1;
        }
        if (txtSize.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter stall size \\n";
            slno = slno + 1;
        }

        if (ddlFabrication.SelectedValue == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Type of fabrication material used \\n";
            slno = slno + 1;
        }

        if (rbtclearspace.SelectedValue == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Whether there is proposed to be a clear space of 3 mts. on all sides of the structure and the adjacent buildings or other structures \\n";
            slno = slno + 1;
        }
        if (rbtTemporaryStructure.SelectedValue == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Whether the temporary structure is intended to be constructed near an electric Substation, railway line, chimney or furnace and if so the distance from the same \\n";
            slno = slno + 1;
        }

        if (txtStartDate.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter  Starting Date \\n";
            slno = slno + 1;
        }
        if (txtEndDate.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Ending date \\n";
            slno = slno + 1;
        }
        if (ddlworktimingsfrom.SelectedValue == "0"||ddlworktimingsfrom.SelectedValue=="Select")
        {
            ErrorMsg = ErrorMsg + slno + ". Please select working start time \\n";
            slno = slno + 1;
        }
        if (ddlworktimingsto.SelectedValue == "0" || ddlworktimingsto.SelectedValue == "Select")
        {
            ErrorMsg = ErrorMsg + slno + ". Please select  working end time \\n";
            slno = slno + 1;
        }
        if (ddlperformancetimingsfrom.SelectedValue == "0" || ddlperformancetimingsfrom.SelectedValue == "Select")
        {
            ErrorMsg = ErrorMsg + slno + ". Please select performance starting time \\n";
            slno = slno + 1;
        }
        if (ddlperformancetimingsto.SelectedValue == "0" || ddlperformancetimingsto.SelectedValue == "Select")
        {
            ErrorMsg = ErrorMsg + slno + ". Please select performance end time \\n";
            slno = slno + 1;
        }
        if (ddlExpectedstrength.SelectedValue == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Expected strength of audience \\n";
            slno = slno + 1;
        }
        if (txtProductRelated.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter product related stalls count  \\n";
            slno = slno + 1;
        }
        if (txtFoodBeverages.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter food and beverages related stalls count \\n";
            slno = slno + 1;
        }
        if (txtGamesEntertainment.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter games and entertainment related stalls count \\n";
            slno = slno + 1;
        }
        if (txtOthers.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter other stalls count \\n";
            slno = slno + 1;
        }
        if (rbtFreeEntryInvitation.SelectedValue == "" || rbtFreeEntryInvitation.SelectedItem.Text == "NULL")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Free entry for all based on invitations \\n";
            slno = slno + 1;
        }
        if (rbtFreeEntryWithoutInvitation.SelectedValue == "" || rbtFreeEntryWithoutInvitation.SelectedItem.Text == "NULL")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Free entry without invitations \\n";
            slno = slno + 1;
        }
        if (rbtTicketShow.SelectedValue == "" || rbtTicketShow.SelectedItem.Text == "NULL")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select ticketshow details \\n";
            slno = slno + 1;
        }
        if (rbtTicketShow.SelectedValue == "Y")
        {
            if (txtAdultTicket.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter each adult ticket cost \\n";
                slno = slno + 1;
            }
            if (txtChildrensTicket.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter each Children Ticket(More than 5years below 12 years)\\n";
                slno = slno + 1;
            }
        }
        if (txtNoOfTicketCounters.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please total no of ticket counters \\n";
            slno = slno + 1;
        }
        if (rbtAnyVIP.SelectedValue == "" || rbtAnyVIP.SelectedItem.Text == "NULL")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select any VIP  expected   \\n";
            slno = slno + 1;
        }
        if (rbtAnyVIP.SelectedValue == "Y" && txtAnyVIP.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Expected VIP details \\n";
            slno = slno + 1;
        }
        if (rbtAnyForeigner.SelectedValue == "" || rbtAnyForeigner.SelectedItem.Text == "NULL")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select any foreigner  expected   \\n";
            slno = slno + 1;
        }
        if (rbtAnyForeigner.SelectedValue == "Y" && txtAnyForeigner.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Expected foreigner details \\n";
            slno = slno + 1;
        }

        if (txtParkingSpace.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Space in Sq. Meters made available for parking at the venue. \\n";
            slno = slno + 1;
        }
        if (txtNoOfSecurityAndVolunteers.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter No. of volunteers /security guards proposed to be deployed for vehicle checking along with equipments \\n";
            slno = slno + 1;
        }
        if (rbtPoliceNOC.SelectedValue == "" || rbtPoliceNOC.SelectedItem.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Whether required Police NOC \\n";
            slno = slno + 1;
        }

        if (txtProposedNoOfCCTV.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Proposed No. of CCTV’s. \\n";
            slno = slno + 1;
        }
        if (txtProposedNoOfDFMD.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Proposed No. of DFMD’s and their location. \\n";
            slno = slno + 1;
        }
        if (txtNoOfSecurityAndVolunteers.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Proposed No. of secrity guards and volunteers. \\n";
            slno = slno + 1;
        }
        if (txtNoOfExitsWithWidth.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter no of exits planned. \\n";
            slno = slno + 1;
        }
        if (txtExitsWidth.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter width in feet. \\n";
            slno = slno + 1;
        }
        if (txtWidthOfGangways.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter no of no of gangways planned. \\n";
            slno = slno + 1;
        }
        if (txtGangWaysWidth.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter gangways width. \\n";
            slno = slno + 1;
        }
        if (txtCO2Cylinders.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter no of Co2 type cylinders. \\n";
            slno = slno + 1;
        }
        if (txtFoamCylinders.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter no of foam cylinders. \\n";
            slno = slno + 1;
        }
        if (txtNoOfBuckets.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter no of  buckets. \\n";
            slno = slno + 1;
        }
        if (txtNoOfWaterStorageTanks.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter no of  water storage tanks. \\n";
            slno = slno + 1;
        }
        if (txtNoOfSandBags.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter no of  sand bags. \\n";
            slno = slno + 1;
        }
        if (rbtStandbyFireService.SelectedValue == "" || rbtSatndbyAmbulanceFacility.SelectedItem.Text == "NULL")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Whether standby fire service is required. \\n";
            slno = slno + 1;
        }
        if (rbtStandbyFireService.SelectedValue == "Y")
        {
            if (ddlcategoryvehiclestandby.SelectedValue == "0" || ddlcategoryvehiclestandby.SelectedValue == "Select" || ddlcategoryvehiclestandby.SelectedValue == "--Select--")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select  VehicleStandByCategory. \\n";
                slno = slno + 1;
            }
        }
        if (rbtFirstAidFacility.SelectedValue == "" || rbtFirstAidFacility.SelectedItem.Text == "NULL")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select is there any need of first aid facility. \\n";
            slno = slno + 1;
        }
        if (rbtMedicalAttender.SelectedValue == "" || rbtSatndbyAmbulanceFacility.SelectedItem.Text == "NULL")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select is there any need of medical attender or doctor. \\n";
            slno = slno + 1;
        }
        if (rbtSatndbyAmbulanceFacility.SelectedValue == "" || rbtSatndbyAmbulanceFacility.SelectedItem.Text == "NULL")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select is there any need of stand by ambulance facility. \\n";
            slno = slno + 1;
        }
        if (ddldistrict.SelectedValue == "0" || ddldistrict.SelectedValue == "--Select--" || ddldistrict.SelectedValue == "--Mandal--" || ddldistrict.SelectedValue == "Select")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select district. \\n";
            slno = slno + 1;
        }
        if (ddlmandal.SelectedValue == "0" || ddlmandal.SelectedValue == "--Select--" || ddlmandal.SelectedValue == "--Mandal--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select mandal. \\n";
            slno = slno + 1;
        }

        if (ddlvillage.SelectedValue == "0" || ddlvillage.SelectedValue == "--Select--" || ddlvillage.SelectedValue == "--Village--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select village. \\n";
            slno = slno + 1;
        }
        if (txtpincode.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter pincode. \\n";
            slno = slno + 1;
        }
        if (ddlcompanydistrict.SelectedValue == "0" || ddlcompanydistrict.SelectedValue == "--Select--" || ddlcompanydistrict.SelectedValue == "--Mandal--" || ddlcompanydistrict.SelectedValue == "Select")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select company located district. \\n";
            slno = slno + 1;
        }
        if (ddlcompanymandal.SelectedValue == "0" || ddlcompanymandal.SelectedValue == "--Select--" || ddlcompanymandal.SelectedValue == "--Mandal--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select company located mandal. \\n";
            slno = slno + 1;
        }
        if (ddlcompanyvillage.SelectedValue == "0" || ddlcompanyvillage.SelectedValue == "--Select--" || ddlcompanyvillage.SelectedValue == "--Village--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select company located village. \\n";
            slno = slno + 1;
        }
        if (txtcompanypincode.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter pincode of company located area. \\n";
            slno = slno + 1;
        }
        return ErrorMsg;
    }

    public string ValidateFileUploads()
    {
        int slno = 1;
        string ErrorMsg = "";
        //if (lblfupFabricationMaterialDoc.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please upload Fabrication Material Plan. \\n";
        //    slno = slno + 1;
        //}
        if (lblProofofAddress.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Proof of addres. \\n";
            slno = slno + 1;
        }
        if (lblPandCard.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload PAN card of applicant. \\n";
            slno = slno + 1;
        }
        //if (lblRelevantCopy.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please upload Relevant copy of plans. \\n";
        //    slno = slno + 1;
        //}
        if (lblPartnershipDeed.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Partnership deed/ Articles and Memorandum of Association of Company. \\n";
            slno = slno + 1;
        }
        if (lblEnclosetraffic.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Enclose traffic / security/ fire safety plan/ location plan/ approach plan. \\n";
            slno = slno + 1;
        }
        if (lblfupLayoutoftheevent.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload  Layout of the event. \\n";
            slno = slno + 1;
        }
        if (lblSelfCertification.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Self Certification. \\n";
            slno = slno + 1;
        }
        if (ddlcategoryvehiclestandby.SelectedValue == "4")
        {
            if (lblloandocuments.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please upload loanDocments. \\n";
                slno = slno + 1;
            }
        }
        return ErrorMsg;
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        string errormsg = ValidateControls();
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        try
        {
            string AdharCardno = "";
            if (txtadhar1.Text.Trim() != "" && txtadhar2.Text.Trim() != "" && txtadhar3.Text.Trim() != "")
            {
                AdharCardno = txtadhar1.Text.Trim() + txtadhar2.Text.Trim() + txtadhar3.Text.Trim();
            }
            Response objResp = new Response();

            DraftQuestionnaireTourismPerformanceLicense obj = new DraftQuestionnaireTourismPerformanceLicense();

            obj.TypeofEvent = ddlTypeofEvent.SelectedItem.Text.ToString();
            obj.TypeofEventValue = ddlTypeofEvent.SelectedValue;
            obj.structureTypeValue = ddlstructureType.SelectedValue;
            obj.FabricationValue = ddlFabrication.SelectedValue;
            obj.ExpectedstrengthValue = ddlExpectedstrength.SelectedValue;

            obj.ClassificationofEvent_Value = rbtClassificationofEvent.SelectedValue;
            obj.EventManagement_Address = txtcompanyaddress.Text.Trim();
            obj.VIP_Visited = rbtAnyVIP.SelectedValue;
            obj.VIP_Visited_Name = txtAnyVIP.Text.Trim();
            obj.Foreigner_Expected = rbtAnyForeigner.SelectedValue;
            obj.Foreigner_Expected_Remarks = txtAnyForeigner.Text.Trim();
            obj.Exits_Width = txtExitsWidth.Text.Trim();
            obj.NOofGangways = txtWidthOfGangways.Text.Trim();// textbox name wrong txtWidthOfGangways
            obj.Police_NOC = rbtPoliceNOC.SelectedValue;
            obj.Location_Width = txtarea.Text.Trim();


            obj.ClassificationofEvent = rbtClassificationofEvent.SelectedItem.Text.ToString();
            obj.NameofTheApplicant = txtNameofTheApplicant.Text.ToString();
            obj.FatherName = txtFatherName.Text.ToString();
            obj.AadharNumber = AdharCardno;
            obj.PanNumber = txtPanNumber.Text.ToString();
            obj.AddressWithContact = txtAddressWithContact.Text.ToString();
            obj.NameAddEventManagement = txtNameAddEventManagement.Text.ToString();
            obj.GSTNumber = txtGSTNumber.Text.ToString();
            obj.NameLocPerformance = txtNameLocPerformance.Text.ToString();
            obj.structureType = ddlstructureType.SelectedItem.Text.ToString();
            obj.NoofStalls = txtNoofStalls.Text.ToString();
            obj.Size = txtSize.Text.ToString();
            obj.Fabrication = ddlFabrication.SelectedItem.Text.ToString();
            obj.clearspace = rbtclearspace.SelectedValue;
            obj.TemporaryStructure = rbtTemporaryStructure.SelectedValue;
            obj.WorkingtimingsFrm = ddlworktimingsfrom.SelectedValue;
            obj.WorkingtimingsTo = ddlworktimingsto.SelectedValue;
            obj.Performancetimingsfrm = ddlperformancetimingsfrom.SelectedValue;
            obj.PerformancetimingsTo = ddlperformancetimingsto.SelectedValue;
            obj.StartDate = Convert.ToDateTime(txtStartDate.Text.ToString());
            obj.EndDate = Convert.ToDateTime(txtEndDate.Text.ToString());
            obj.Expectedstrength = ddlExpectedstrength.SelectedItem.Text.ToString();
            obj.ProductRelated = txtProductRelated.Text.ToString();
            obj.FoodBeverages = txtFoodBeverages.Text.ToString();
            obj.GamesEntertainment = txtGamesEntertainment.Text.ToString();
            obj.Others = txtOthers.Text.ToString();
            obj.FreeEntryInvitation = rbtFreeEntryInvitation.SelectedValue;
            obj.FreeEntryWithoutInvitation = rbtFreeEntryWithoutInvitation.SelectedValue;
            obj.TicketShow = rbtTicketShow.SelectedValue;
            obj.TicketShowDetails = txtTicketShowDetails.Text.ToString();
            obj.AdultTicket = txtAdultTicket.Text.ToString();
            obj.ChildrensTicket = txtChildrensTicket.Text.ToString();
            obj.NoOfTicketCounters = txtNoOfTicketCounters.Text.ToString();
            obj.ParkingSpace = txtParkingSpace.Text.ToString();
            obj.NoOfSecurityVehicleChecking = txtNoOfSecurityVehicleChecking.Text.ToString();
            obj.SecurityArrangements = txtSecurityArrangements.Text.ToString();
            obj.ProposedNoOfCCTV = txtProposedNoOfCCTV.Text.ToString();
            obj.ProposedNoOfDFMD = txtProposedNoOfDFMD.Text.ToString();
            obj.NoOfSecurityAndVolunteers = txtNoOfSecurityAndVolunteers.Text.ToString();
            obj.MobileNoApplicant = txtMobileNumberApplicant.Text.ToString();
            obj.Email = txtEmailID.Text.ToString();
            obj.NoOfExitsWithWidth = txtNoOfExitsWithWidth.Text.ToString();
            obj.WidthOfGangways = txtGangWaysWidth.Text.ToString();
            obj.CO2Cylinders = txtCO2Cylinders.Text.ToString();
            obj.FoamCylinders = txtFoamCylinders.Text.ToString();
            obj.NoOfBuckets = txtNoOfBuckets.Text.ToString();
            obj.NoOfWaterStorageTanks = txtNoOfWaterStorageTanks.Text.ToString();
            obj.NoOfSandBags = txtNoOfSandBags.Text.ToString();
            obj.StandbyFireService = rbtStandbyFireService.SelectedValue;
            obj.FirstAidFacility = rbtFirstAidFacility.SelectedValue;
            obj.MedicalAttender = rbtMedicalAttender.SelectedValue;
            obj.SatndbyAmbulanceFacility = rbtSatndbyAmbulanceFacility.SelectedValue;

            obj.District = ddldistrict.SelectedValue;
            obj.Mandal = ddlmandal.SelectedValue;
            obj.Village = ddlvillage.SelectedValue;
            obj.Pincode = txtpincode.Text.ToString();

            obj.CompanyDistrict = ddlcompanydistrict.SelectedValue;
            obj.CompanyMandal = ddlcompanymandal.SelectedValue;
            obj.CompanyVillage = ddlcompanyvillage.SelectedValue;
            obj.CompanyPincode = txtcompanypincode.Text.ToString();

            obj.VehicleStandByCategoryMaster = ddlcategoryvehiclestandby.SelectedValue;

            obj.CreatedBy = Convert.ToInt32(Session["uid"]);
            obj.FileUploadPaths = GetFiles();
            int TourismEventID = 0;
            objResp = Gen.InsertDraftQuestionnaireTourismPerformanceLicense(obj, out TourismEventID);
            Session["Applid"] = TourismEventID;
            if (objResp.ResponseVal == true)
            {
                hdnTransactionNumber.Value = TourismEventID.ToString();
                Response.Write("Submitted Successfully.....");
                // BtnSave.Enabled = false;
                BtnClear.Enabled = false;
                btnPayment.Enabled = true;
                trUploads.Visible = true;
                if (ddlcategoryvehiclestandby.SelectedValue == "4")
                {
                    trloandocuuments.Visible = true;
                }
                else
                {
                    trloandocuuments.Visible = false;
                }
                btnPayment.Visible = true;
                BindFees();


            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }

    }
    void FillAttachmentsDetails(DataSet ds)
    {

        if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
        {
            int c = ds.Tables[1].Rows.Count;
            string sen, sen1, sen2;
            int i = 0;

            while (i < c)
            {
                sen2 = ds.Tables[1].Rows[i][0].ToString();
                sen1 = sen2.Replace(@"\", @"/");

                //  sen = sen1.Replace(@"C:/TSiPASS/Attachments/1192/", "~/");//"C:/TSiPASS/Attachments/1192/B1Form\CateogryofRegistration.jpg"
                //sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/Attachments")), "~/");
                if (sen1.ToUpper().Contains("SELF")) //SelfCertification
                {
                    // sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/TOURISMEVENT")), "~/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("SELF"))
                    {
                        HyperLinkSelfCertification.Visible = true;
                        HyperLinkSelfCertification.Text = ds.Tables[1].Rows[i][1].ToString();
                        HyperLinkSelfCertification.NavigateUrl = sen;
                        lblSelfCertification.Text = ds.Tables[1].Rows[i][1].ToString();
                    }
                }
                else if (sen1.ToUpper().Contains("ADDRESS")) //SelfCertification
                {
                    // sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/TOURISMEVENT")), "~/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("ADDRESS"))
                    {
                        HyperLinkProofofAddress.Visible = true;
                        HyperLinkProofofAddress.Text = ds.Tables[1].Rows[i][1].ToString();
                        HyperLinkProofofAddress.NavigateUrl = sen;
                        lblProofofAddress.Text = ds.Tables[1].Rows[i][1].ToString();
                    }
                }
                if (sen1.ToUpper().Contains("PAN")) //SelfCertification
                {
                    //sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/TOURISMEVENT")), "~/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("PAN"))
                    {
                        HyperLinkPanCard.Visible = true;
                        HyperLinkPanCard.Text = ds.Tables[1].Rows[i][1].ToString();
                        HyperLinkPanCard.NavigateUrl = sen;
                        lblPandCard.Text = ds.Tables[1].Rows[i][1].ToString();
                    }
                }
                if (sen1.ToUpper().Contains("RELEVANT")) //SelfCertification
                {
                    //sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/TOURISMEVENT")), "~/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("RELEVANT"))
                    {
                        HyperLinkRelevantcopy.Visible = true;
                        HyperLinkRelevantcopy.Text = ds.Tables[1].Rows[i][1].ToString();
                        HyperLinkRelevantcopy.NavigateUrl = sen;
                        lblRelevantCopy.Text = ds.Tables[1].Rows[i][1].ToString();
                    }
                }

                if (sen1.ToUpper().Contains("PARTNER")) //SelfCertification
                {
                    //sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/TOURISMEVENT")), "~/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("PARTNER"))
                    {
                        HyperLinkPartnershipDeed.Visible = true;
                        HyperLinkPartnershipDeed.Text = ds.Tables[1].Rows[i][1].ToString();
                        HyperLinkPartnershipDeed.NavigateUrl = sen;
                        lblPartnershipDeed.Text = ds.Tables[1].Rows[i][1].ToString();
                    }
                }

                if (sen1.ToUpper().Contains("TRAFFIC")) //SelfCertification
                {
                    // sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/TOURISMEVENT")), "~/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("TRAFFIC"))
                    {
                        HyperLinkEnclosetraffic.Visible = true;
                        HyperLinkEnclosetraffic.Text = ds.Tables[1].Rows[i][1].ToString();
                        HyperLinkEnclosetraffic.NavigateUrl = sen;
                        lblEnclosetraffic.Text= ds.Tables[1].Rows[i][1].ToString();

                    }
                }

                if (sen1.ToUpper().Contains("LAYOUT")) //SelfCertification
                {
                    // sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/TOURISMEVENT")), "~/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("LAYOUT"))
                    {
                        HyperLinkfupLayoutoftheevent.Visible = true;
                        HyperLinkfupLayoutoftheevent.Text = ds.Tables[1].Rows[i][1].ToString();
                        HyperLinkfupLayoutoftheevent.NavigateUrl = sen;
                        lblfupLayoutoftheevent.Text = ds.Tables[1].Rows[i][1].ToString();
                    }
                }
                if (sen1.ToUpper().Contains("FABRICATION"))
                {
                    // sen = sen1.ToUpper().Replace(sen1.Substring(0, sen1.ToUpper().IndexOf(@"/TOURISMEVENT")), "~/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("FABRICATION"))
                    {
                        HyperLinkfupFabricationMaterialDoc.Visible = true;
                        HyperLinkfupFabricationMaterialDoc.Text = ds.Tables[1].Rows[i][1].ToString();
                        HyperLinkfupFabricationMaterialDoc.NavigateUrl = sen;
                        lblfupFabricationMaterialDoc.Text = ds.Tables[1].Rows[i][1].ToString();
                    }
                }
                if (sen1.ToUpper().Contains("LOANDOCUMENTS"))
                {
                    // sen = sen1.ToUpper().Replace(sen1.Substring(0, sen1.ToUpper().IndexOf(@"/TOURISMEVENT")), "~/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("LOANDOCUMENTS"))
                    {
                        Hyperloandocuments.Visible = true;
                        Hyperloandocuments.Text = ds.Tables[1].Rows[i][1].ToString();
                        Hyperloandocuments.NavigateUrl = sen;
                        lblloandocuments.Text = ds.Tables[1].Rows[i][1].ToString();
                    }
                }
                i++;
            }

        }

    }
    public void BindFees()
    {
        //    try
        //    {
        //        DataSet dsv = new DataSet();
        //        dsv = null;

        //        //   DataSet dsTourism = new DataSet();
        //        dsv = Gen.GetShowApprovalandFees_TourismEvent("108");
        //        //  dsv.Tables[0].Merge(dsTourism.Tables[0]);

        //        DataSet dsPolice = new DataSet();
        //        if (rbtPoliceNOC.SelectedValue == "Y")
        //        {
        //            dsPolice = Gen.GetShowApprovalandFees_TourismEvent("107");
        //            dsv.Tables[0].Merge(dsPolice.Tables[0]);
        //        }

        //        DataSet dsFire = new DataSet();
        //        if (rbtStandbyFireService.SelectedValue == "Y")
        //        {
        //            dsFire = Gen.GetShowApprovalandFees_TourismEvent("106");
        //            dsv.Tables[0].Merge(dsFire.Tables[0]);
        //        }

        //        if (dsv.Tables[0].Rows.Count > 0)
        //        {
        //            grdDetails.DataSource = dsv.Tables[0];
        //            grdDetails.DataBind();

        //            // gvitems.DataSource= dsv.Tables[0];
        //            // gvitems.DataBind();
        //            dvfeedetails.Visible = true;
        //        }
        //        else
        //        {
        //            grdDetails.DataSource = null;
        //            grdDetails.DataBind();
        //            dvfeedetails.Visible = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        //    }

    }
    public DataTable GetFiles()
    {
        DataTable dt = new DataTable();

        dt.TableName = "FileUploadPaths";


        dt.Columns.Add("FileType");
        dt.Columns.Add("FilePath");
        dt.Columns.Add("UploadFileName");
        dt.Columns.Add("DocumentName");
        if (!string.IsNullOrWhiteSpace(HyperLinkProofofAddress.NavigateUrl))
        {
            // !string.IsNullOrWhiteSpace(btnDeleteSitePlan.CommandArgument)
            DataRow dr = dt.NewRow();
            dr["FileType"] = hdnProofofAddressType.Value.ToString();
            dr["UploadFileName"] = hdnFileNameProofofAddress.Value.ToString();
            dr["FilePath"] = HyperLinkProofofAddress.NavigateUrl.Trim();
            dr["DocumentName"] = "Proof of Address";
            dt.Rows.Add(dr);
        }
        if (!string.IsNullOrWhiteSpace(HyperLinkPanCard.NavigateUrl))
        {
            // !string.IsNullOrWhiteSpace(btnDeleteSitePlan.CommandArgument)
            DataRow dr = dt.NewRow();
            dr["FileType"] = hdnPanCard.Value.ToString();
            dr["UploadFileName"] = hdnPanCardFilename.Value.ToString();
            dr["FilePath"] = HyperLinkPanCard.NavigateUrl.Trim();
            dr["DocumentName"] = "Pan Card";
            dt.Rows.Add(dr);
        }
        if (!string.IsNullOrWhiteSpace(HyperLinkPartnershipDeed.NavigateUrl))
        {
            // !string.IsNullOrWhiteSpace(btnDeleteSitePlan.CommandArgument)
            DataRow dr = dt.NewRow();
            dr["FileType"] = hdnPartnershipDeed.Value.ToString();
            dr["UploadFileName"] = hdnPartnershipDeedFileName.Value.ToString();
            dr["FilePath"] = HyperLinkPartnershipDeed.NavigateUrl.Trim();
            dr["DocumentName"] = "Partnership Deed";
            dt.Rows.Add(dr);
        }
        if (!string.IsNullOrWhiteSpace(HyperLinkEnclosetraffic.NavigateUrl))
        {
            // !string.IsNullOrWhiteSpace(btnDeleteSitePlan.CommandArgument)
            DataRow dr = dt.NewRow();
            dr["FileType"] = hdnEnclosetraffic.Value.ToString();
            dr["UploadFileName"] = hdnEnclosetrafficFileName.Value.ToString();
            dr["FilePath"] = HyperLinkEnclosetraffic.NavigateUrl.Trim();
            dr["DocumentName"] = "Enclose traffic";
            dt.Rows.Add(dr);
        }
        if (!string.IsNullOrWhiteSpace(HyperLinkSelfCertification.NavigateUrl))
        {
            // !string.IsNullOrWhiteSpace(btnDeleteSitePlan.CommandArgument)
            DataRow dr = dt.NewRow();
            dr["FileType"] = hdnSelfCertification.Value.ToString();
            dr["UploadFileName"] = hdnSelfCertificationFilename.Value.ToString();
            dr["FilePath"] = HyperLinkSelfCertification.NavigateUrl.Trim();
            dr["DocumentName"] = "Self Certification";
            dt.Rows.Add(dr);
        }
        if (!string.IsNullOrWhiteSpace(HyperLinkRelevantcopy.NavigateUrl))
        {
            // !string.IsNullOrWhiteSpace(btnDeleteSitePlan.CommandArgument)
            DataRow dr = dt.NewRow();
            dr["FileType"] = hdnRelevantCopy.Value.ToString();
            dr["UploadFileName"] = hdnRelevantCopyFileName.Value.ToString();
            dr["FilePath"] = HyperLinkRelevantcopy.NavigateUrl.Trim();
            dr["DocumentName"] = "Relevant copy";
            dt.Rows.Add(dr);
        }
        if (!string.IsNullOrWhiteSpace(HyperLinkfupFabricationMaterialDoc.NavigateUrl))
        {
            // !string.IsNullOrWhiteSpace(btnDeleteSitePlan.CommandArgument)
            DataRow dr = dt.NewRow();
            dr["FileType"] = hdnfabricationmaterialdoc.Value.ToString();
            dr["UploadFileName"] = hdnfabricationmaterialdocfilename.Value.ToString();
            dr["FilePath"] = HyperLinkfupFabricationMaterialDoc.NavigateUrl.Trim();
            dr["DocumentName"] = "Fabrication material";
            dt.Rows.Add(dr);
        }
        if (!string.IsNullOrWhiteSpace(HyperLinkfupLayoutoftheevent.NavigateUrl))
        {
            // !string.IsNullOrWhiteSpace(btnDeleteSitePlan.CommandArgument)
            DataRow dr = dt.NewRow();
            dr["FileType"] = hdnlayoutevent.Value.ToString();
            dr["UploadFileName"] = hdnlayouteventfilename.Value.ToString();
            dr["FilePath"] = HyperLinkfupLayoutoftheevent.NavigateUrl.Trim();
            dr["DocumentName"] = "Layot of Event";
            dt.Rows.Add(dr);
        }
        if (!string.IsNullOrWhiteSpace(Hyperloandocuments.NavigateUrl))
        {
            // !string.IsNullOrWhiteSpace(btnDeleteSitePlan.CommandArgument)
            DataRow dr = dt.NewRow();
            dr["FileType"] = hdnloandocument.Value.ToString();
            dr["UploadFileName"] = hdnloandocumentfilename.Value.ToString();
            dr["FilePath"] = Hyperloandocuments.NavigateUrl.Trim();
            dr["DocumentName"] = "LoanDocuments";
            dt.Rows.Add(dr);
        }
        if (dt.Rows.Count == 0)
        {
            //DataRow dr = dt.NewRow();
            //dr["Module_Id"] = "-";
            //dt.Rows.Add(dr);
            dt = null;
        }

        return dt;
    }
    protected void btnSelfCertification_Click(object sender, EventArgs e)
    {
        string newPath = "";
        // string sFileDir = @"D:\TS-iPASSFinal\Attachments";
        //  string SubFolder = @"\TOURISMEVENT\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        string SubFolder = @"\TOURISMEVENT\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        General.FileResult objfileResult = new General.FileResult();

        string[] extensions = { ".pdf", ".jpg", ".jpeg" };
        objfileResult = Gen.SaveFile(fupSelfCertification, SubFolder, "SelfCertification");

        if (objfileResult.Result == true)
        {
            lblSelfCertification.Text = objfileResult.FileName;
            hdnSelfCertification.Value = objfileResult.FileType;
            hdnSelfCertificationFilename.Value = objfileResult.FileName;
            fupSelfCertification.Visible = false;
            btnSelfCertification.Visible = false;
            BtnSave.Focus();
            int result = 0;
            result = SaveAttachments(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "SelfCertification", Session["uid"].ToString());
            if (result > 0)
            {
                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                HyperLinkSelfCertification.Visible = true;
                HyperLinkSelfCertification.Text = objfileResult.FileName; 
                success.Visible = true;
                Failure.Visible = false;
            }
            else
            {
                lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                success.Visible = false;
                Failure.Visible = true;
            }

        }
        else
        {

            HyperLinkSelfCertification.NavigateUrl = objfileResult.FilePath;
            lblSelfCertification.Text = objfileResult.Message;
        }
    }

    //private int SaveAttachments(string v1, string v2, string v3, string v4, string v5, string sFileName, string newPath, string v6, string v7, string v8)
    //{
    //    SqlCommand cmdFiles = new SqlCommand("usp_Insert_TourismEvent_attachments", con.GetConnection);
    //    cmdFiles.CommandType = CommandType.StoredProcedure;

    //    cmdFiles.Parameters.AddWithValue("@TourismEvent_ID", Convert.ToInt32(valid));
    //    cmdFiles.Parameters.AddWithValue("@FileType", Convert.ToString(obj.FileUploadPaths.Rows[i]["FileType"].ToString()));
    //    cmdFiles.Parameters.AddWithValue("@FilePath", Convert.ToString(obj.FileUploadPaths.Rows[i]["FilePath"].ToString()));
    //    cmdFiles.Parameters.AddWithValue("@FileName", Convert.ToString(obj.FileUploadPaths.Rows[i]["UploadFileName"].ToString()));
    //    cmdFiles.Parameters.AddWithValue("@FileDescription", Convert.ToString(obj.FileUploadPaths.Rows[i]["DocumentName"].ToString()));
    //    cmdFiles.Parameters.AddWithValue("@Created_by", Convert.ToInt32(obj.CreatedBy));
    //    cmdFiles.ExecuteNonQuery();
    //}
    public int SaveAttachments(string intTourismId, string FileType, string FilePath, string FileName, string FileDescription, string Created_by)
    {
        int n = 0;
        try
        {

            con.OpenConnection();

            SqlCommand cmdFiles = new SqlCommand("usp_Insert_TourismEvent_attachments", con.GetConnection);
            cmdFiles.CommandType = CommandType.StoredProcedure;

            cmdFiles.Parameters.AddWithValue("@TourismEvent_ID", Convert.ToInt32(intTourismId));
            cmdFiles.Parameters.AddWithValue("@FileType", FileType);
            cmdFiles.Parameters.AddWithValue("@FilePath", FilePath);
            cmdFiles.Parameters.AddWithValue("@FileName", FileName);
            cmdFiles.Parameters.AddWithValue("@FileDescription", FileDescription);
            cmdFiles.Parameters.AddWithValue("@Created_by", Created_by);
            n = cmdFiles.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            con.CloseConnection();
            throw ex;

        }
        finally
        {

            con.CloseConnection();

        }
        return n;
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


    protected void btnEnclosetraffic_Click(object sender, EventArgs e)
    {
        string SubFolder = @"\TOURISMEVENT\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        General.FileResult objfileResult = new General.FileResult();

        string[] extensions = { ".pdf", ".jpg", ".jpeg" };
        objfileResult = Gen.SaveFile(fupEnclosetraffic, SubFolder, "Enclosetraffic");

        if (objfileResult.Result == true)
        {
            //HyperLinkEnclosetraffic.Visible = true;
            //HyperLinkEnclosetraffic.NavigateUrl = objfileResult.FilePath;
            HyperLinkEnclosetraffic.Text = objfileResult.FileName;
            lblEnclosetraffic.Text = objfileResult.FileName;
            hdnEnclosetraffic.Value = objfileResult.FileType;
            hdnEnclosetrafficFileName.Value = objfileResult.FileName;

            fupEnclosetraffic.Visible = false;
            btnEnclosetraffic.Visible = false;
            int result = 0;
            result = SaveAttachments(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "Enclosetraffic", Session["uid"].ToString());
            if (result > 0)
            {
                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                HyperLinkEnclosetraffic.Visible = true;
                HyperLinkEnclosetraffic.Text = objfileResult.FileName;
                BtnSave.Focus();
                success.Visible = true;
                Failure.Visible = false;
            }
            else
            {
                lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                success.Visible = false;
                Failure.Visible = true;
            }
        }
        else
        {

            HyperLinkEnclosetraffic.NavigateUrl = objfileResult.FilePath;
            lblEnclosetraffic.Text = objfileResult.Message;
        }
    }

    protected void btnPartnershipDeed_Click(object sender, EventArgs e)
    {
        string SubFolder = @"\TOURISMEVENT\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        General.FileResult objfileResult = new General.FileResult();

        string[] extensions = { ".pdf", ".jpg", ".jpeg" };
        objfileResult = Gen.SaveFile(fupPartnershipDeed, SubFolder, "PartnershipDeed");

        if (objfileResult.Result == true)
        {
            //HyperLinkPartnershipDeed.Visible = true;
            //HyperLinkPartnershipDeed.NavigateUrl = objfileResult.FilePath;
            HyperLinkPartnershipDeed.Text = objfileResult.FileName;
            lblPartnershipDeed.Text = objfileResult.FileName;
            hdnPartnershipDeed.Value = objfileResult.FileType;
            hdnPartnershipDeedFileName.Value = objfileResult.FileName;
            fupPartnershipDeed.Visible = false;
            btnPartnershipDeed.Visible = false;
            BtnSave.Focus();
            int result = 0;
            result = SaveAttachments(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "PartnershipDeed", Session["uid"].ToString());
            if (result > 0)
            {
                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>"; 
                success.Visible = true;
                Failure.Visible = false;
               
            }
            else
            {
                lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                success.Visible = false;
                Failure.Visible = true;
            }
        }
        else
        {

            HyperLinkPartnershipDeed.NavigateUrl = objfileResult.FilePath;
            lblPartnershipDeed.Text = objfileResult.Message;
        }
    }

    protected void btnRelevantCopy_Click(object sender, EventArgs e)
    {
        // string sFileDir = @"D:\TS-iPASSFinal\Attachments";
        string SubFolder = @"\TOURISMEVENT\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        General.FileResult objfileResult = new General.FileResult();

        string[] extensions = { ".pdf", ".jpg", ".jpeg" };
        objfileResult = Gen.SaveFile(fupRelevantCopy, SubFolder, "RelevantCopy");

        if (objfileResult.Result == true)
        {
            //HyperLinkRelevantcopy.Visible = true;
            //HyperLinkRelevantcopy.NavigateUrl = objfileResult.FilePath;
            HyperLinkRelevantcopy.Text = objfileResult.FileName;
            lblRelevantCopy.Text = objfileResult.FileName;
            hdnRelevantCopy.Value = objfileResult.FileType;
            hdnRelevantCopyFileName.Value = objfileResult.FileName;
            fupRelevantCopy.Visible = false;
            btnRelevantCopy.Visible = false;
            BtnSave.Focus();
            int result = 0;
            result = SaveAttachments(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "RelevantCopy", Session["uid"].ToString());
            if (result > 0)
            {
                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                success.Visible = true;
                Failure.Visible = false;
            }
            else
            {
                lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                success.Visible = false;
                Failure.Visible = true;
            }
        }
        else
        {

            HyperLinkRelevantcopy.NavigateUrl = objfileResult.FilePath;
            lblRelevantCopy.Text = objfileResult.Message;
        }
    }

    protected void btnPancard_Click(object sender, EventArgs e)
    {

        // string sFileDir = @"D:\TS-iPASSFinal\Attachments";
        string SubFolder = @"\TOURISMEVENT\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        General.FileResult objfileResult = new General.FileResult();

        string[] extensions = { ".pdf", ".jpg", ".jpeg" };
        objfileResult = Gen.SaveFile(fupPanCard, SubFolder, "PanCard");

        if (objfileResult.Result == true)
        {
            //HyperLinkPanCard.Visible = true;
            //HyperLinkPanCard.NavigateUrl = objfileResult.FilePath;
            HyperLinkPanCard.Text= objfileResult.FileName;
            lblPandCard.Text = objfileResult.FileName;
            hdnPanCard.Value = objfileResult.FileType;
            hdnPanCardFilename.Value = objfileResult.FileName;
            fupPanCard.Visible = false;
            btnPancard.Visible = false;
            BtnSave.Focus();
            int result = 0;
            result = SaveAttachments(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "PanCard", Session["uid"].ToString());
            if (result > 0)
            {
                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                success.Visible = true;
                Failure.Visible = false;
            }
            else
            {
                lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                success.Visible = false;
                Failure.Visible = true;
            }
        }
        else
        {

            HyperLinkPanCard.NavigateUrl = objfileResult.FilePath;
            lblPandCard.Text = objfileResult.Message;
        }
    }

    protected void btnProofofAddress_Click(object sender, EventArgs e)
    {
        string newPath = "";
        // string sFileDir = @"D:\TS-iPASSFinal\Attachments";
        string SubFolder = @"\TOURISMEVENT\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        General.FileResult objfileResult = new General.FileResult();

        string[] extensions = { ".pdf", ".jpg", ".jpeg" };
        objfileResult = Gen.SaveFile(fupProofofAddress, SubFolder, "ProofOfAddress");

        if (objfileResult.Result == true)
        {
            //HyperLinkProofofAddress.Visible = true;
            //HyperLinkProofofAddress.NavigateUrl = objfileResult.FilePath;
            HyperLinkProofofAddress.Text = objfileResult.FileName;
            lblProofofAddress.Text = objfileResult.FileName;
            hdnProofofAddressType.Value = objfileResult.FileType;
            hdnFileNameProofofAddress.Value = objfileResult.FileName;
            fupProofofAddress.Visible = false;
            btnProofofAddress.Visible = false;
            BtnSave.Focus();
            int result = 0;
            result = SaveAttachments(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "ProofOfAddress", Session["uid"].ToString());
            if (result > 0)
            {
                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                success.Visible = true;
                Failure.Visible = false;
            }
            else
            {
                lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                success.Visible = false;
                Failure.Visible = true;
            }
        }
        else
        {

            HyperLinkProofofAddress.NavigateUrl = objfileResult.FilePath;
            lblProofofAddress.Text = objfileResult.Message;
        }
    }



    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        string errormsg = ValidateFileUploads();
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        try
        {
            string AdharCardno = "";
            if (txtadhar1.Text.Trim() != "" && txtadhar2.Text.Trim() != "" && txtadhar3.Text.Trim() != "")
            {
                AdharCardno = txtadhar1.Text.Trim() + txtadhar2.Text.Trim() + txtadhar3.Text.Trim();
            }
            Response objResp = new Response();

            DraftQuestionnaireTourismPerformanceLicense obj = new DraftQuestionnaireTourismPerformanceLicense();

            obj.TypeofEvent = ddlTypeofEvent.SelectedItem.Text.ToString();
            obj.TypeofEventValue = ddlTypeofEvent.SelectedValue;
            obj.structureTypeValue = ddlstructureType.SelectedValue;
            obj.FabricationValue = ddlFabrication.SelectedValue;
            obj.ExpectedstrengthValue = ddlExpectedstrength.SelectedValue;

            obj.ClassificationofEvent_Value = rbtClassificationofEvent.SelectedValue;
            obj.EventManagement_Address = txtcompanyaddress.Text.Trim();
            obj.VIP_Visited = rbtAnyVIP.SelectedValue;
            obj.VIP_Visited_Name = txtAnyVIP.Text.Trim();
            obj.Foreigner_Expected = rbtAnyForeigner.SelectedValue;
            obj.Foreigner_Expected_Remarks = txtAnyForeigner.Text.Trim();
            obj.Exits_Width = txtExitsWidth.Text.Trim();
            obj.NOofGangways = txtWidthOfGangways.Text.Trim();// textbox name wrong txtWidthOfGangways
            obj.Police_NOC = rbtPoliceNOC.SelectedValue;
            obj.Location_Width = txtarea.Text.Trim();


            obj.ClassificationofEvent = rbtClassificationofEvent.SelectedItem.Text.ToString();
            obj.NameofTheApplicant = txtNameofTheApplicant.Text.ToString();
            obj.FatherName = txtFatherName.Text.ToString();
            obj.AadharNumber = AdharCardno;
            obj.PanNumber = txtPanNumber.Text.ToString();
            obj.AddressWithContact = txtAddressWithContact.Text.ToString();
            obj.NameAddEventManagement = txtNameAddEventManagement.Text.ToString();
            obj.GSTNumber = txtGSTNumber.Text.ToString();
            obj.NameLocPerformance = txtNameLocPerformance.Text.ToString();
            obj.structureType = ddlstructureType.SelectedItem.Text.ToString();
            obj.NoofStalls = txtNoofStalls.Text.ToString();
            obj.Size = txtSize.Text.ToString();
            obj.Fabrication = ddlFabrication.SelectedItem.Text.ToString();
            obj.clearspace = rbtclearspace.SelectedValue;
            obj.TemporaryStructure = rbtTemporaryStructure.SelectedValue;
            obj.WorkingtimingsFrm = ddlworktimingsfrom.SelectedValue;
            obj.WorkingtimingsTo = ddlworktimingsto.SelectedValue;
            obj.Performancetimingsfrm = ddlperformancetimingsfrom.SelectedValue;
            obj.PerformancetimingsTo = ddlperformancetimingsto.SelectedValue;
            obj.StartDate = Convert.ToDateTime(txtStartDate.Text.ToString());
            obj.EndDate = Convert.ToDateTime(txtEndDate.Text.ToString());
            obj.Expectedstrength = ddlExpectedstrength.SelectedItem.Text.ToString();
            obj.ProductRelated = txtProductRelated.Text.ToString();
            obj.FoodBeverages = txtFoodBeverages.Text.ToString();
            obj.GamesEntertainment = txtGamesEntertainment.Text.ToString();
            obj.Others = txtOthers.Text.ToString();
            obj.FreeEntryInvitation = rbtFreeEntryInvitation.SelectedValue;
            obj.FreeEntryWithoutInvitation = rbtFreeEntryWithoutInvitation.SelectedValue;
            obj.TicketShow = rbtTicketShow.SelectedValue;
            obj.TicketShowDetails = txtTicketShowDetails.Text.ToString();
            obj.AdultTicket = txtAdultTicket.Text.ToString();
            obj.ChildrensTicket = txtChildrensTicket.Text.ToString();
            obj.NoOfTicketCounters = txtNoOfTicketCounters.Text.ToString();
            obj.ParkingSpace = txtParkingSpace.Text.ToString();
            obj.NoOfSecurityVehicleChecking = txtNoOfSecurityVehicleChecking.Text.ToString();
            obj.SecurityArrangements = txtSecurityArrangements.Text.ToString();
            obj.ProposedNoOfCCTV = txtProposedNoOfCCTV.Text.ToString();
            obj.ProposedNoOfDFMD = txtProposedNoOfDFMD.Text.ToString();
            obj.NoOfSecurityAndVolunteers = txtNoOfSecurityAndVolunteers.Text.ToString();
            obj.MobileNoApplicant = txtMobileNumberApplicant.Text.ToString();
            obj.Email = txtEmailID.Text.ToString();
            obj.NoOfExitsWithWidth = txtNoOfExitsWithWidth.Text.ToString();
            obj.WidthOfGangways = txtGangWaysWidth.Text.ToString();
            obj.CO2Cylinders = txtCO2Cylinders.Text.ToString();
            obj.FoamCylinders = txtFoamCylinders.Text.ToString();
            obj.NoOfBuckets = txtNoOfBuckets.Text.ToString();
            obj.NoOfWaterStorageTanks = txtNoOfWaterStorageTanks.Text.ToString();
            obj.NoOfSandBags = txtNoOfSandBags.Text.ToString();
            obj.StandbyFireService = rbtStandbyFireService.SelectedValue;
            obj.FirstAidFacility = rbtFirstAidFacility.SelectedValue;
            obj.MedicalAttender = rbtMedicalAttender.SelectedValue;
            obj.SatndbyAmbulanceFacility = rbtSatndbyAmbulanceFacility.SelectedValue;

            obj.District = ddldistrict.SelectedValue;
            obj.Mandal = ddlmandal.SelectedValue;
            obj.Village = ddlvillage.SelectedValue;
            obj.Pincode = txtpincode.Text.ToString();

            obj.CompanyDistrict = ddlcompanydistrict.SelectedValue;
            obj.CompanyMandal = ddlcompanymandal.SelectedValue;
            obj.CompanyVillage = ddlcompanyvillage.SelectedValue;
            obj.CompanyPincode = txtcompanypincode.Text.ToString();

            obj.VehicleStandByCategoryMaster = ddlcategoryvehiclestandby.SelectedValue;

            obj.CreatedBy = Convert.ToInt32(Session["uid"]);
            obj.FileUploadPaths = GetFiles();
            int TourismEventID = 0;
            objResp = Gen.InsertDraftQuestionnaireTourismPerformanceLicense(obj, out TourismEventID);
            Session["Applid"] = TourismEventID;
            if (objResp.ResponseVal == true)
            {
                hdnTransactionNumber.Value = TourismEventID.ToString();
                Response.Write("Submitted Successfully.....");
                // BtnSave.Enabled = false;
                BtnClear.Enabled = false;
                btnPayment.Enabled = true;
                trUploads.Visible = true;
                if (ddlcategoryvehiclestandby.SelectedValue == "4")
                {
                    trloandocuuments.Visible = true;
                }
                else
                {
                    trloandocuuments.Visible = false;
                }
                btnPayment.Visible = true;
                BindFees();


            }
            if (hdnTransactionNumber.Value.ToString().Trim() == "" || hdnTransactionNumber.Value.Trim() == "0")
            {
                Response.Redirect("frmDraftQuestionnaireTourisamEvent.aspx");
            }
            else
            {
                Response.Redirect("frmPaymentTourismEvent.aspx?intApplicationId=" + Session["Applid"].ToString());                
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void btnfupFabricationMaterialDoc_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            // string sFileDir = @"D:\TS-iPASSFinal\Attachments";
            string SubFolder = @"\TOURISMEVENT\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
            General.FileResult objfileResult = new General.FileResult();

            string[] extensions = { ".pdf", ".jpg", ".jpeg" };
            objfileResult = Gen.SaveFile(fupFabricationMaterialDoc, SubFolder, "FabricationMaterialDoc");

            if (objfileResult.Result == true)
            {
                //HyperLinkfupFabricationMaterialDoc.Visible = true;
                //HyperLinkfupFabricationMaterialDoc.NavigateUrl = objfileResult.FilePath;
                // lblfupFabricationMaterialDoc.Visible = true;
                HyperLinkfupFabricationMaterialDoc.Text= objfileResult.FileName;
                lblfupFabricationMaterialDoc.Text = objfileResult.FileName;
                hdnfabricationmaterialdoc.Value = objfileResult.FileType;
                hdnfabricationmaterialdocfilename.Value = objfileResult.FileName;
                fupFabricationMaterialDoc.Visible = false;
                btnfupFabricationMaterialDoc.Visible = false;
                BtnSave.Focus();
                int result = 0;
                result = SaveAttachments(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "FabricationMaterialDoc", Session["uid"].ToString());
                if (result > 0)
                {
                    lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                    HyperLinkfupFabricationMaterialDoc.Visible = true;
                    HyperLinkfupFabricationMaterialDoc.Text = objfileResult.FileName;

                    success.Visible = true;
                    Failure.Visible = false;
                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                }
            }
            else
            {

                HyperLinkfupFabricationMaterialDoc.NavigateUrl = objfileResult.FilePath;
                lblfupFabricationMaterialDoc.Text = objfileResult.Message;
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    //protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    //{

    //    try
    //    {
    //        if ((e.Row.RowType == DataControlRowType.DataRow))
    //        {
    //            decimal TotalFee1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fees"));
    //            TotalFee = TotalFee + TotalFee1;

    //            Session["Amount"] = TotalFee;

    //            HiddenField HdfApprovalid = (HiddenField)e.Row.Cells[0].FindControl("HdfApprovalid");
    //            HdfApprovalid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ApprovalId")).Trim();

    //            HiddenField HdfQueid = (HiddenField)e.Row.Cells[0].FindControl("HdfQueid");
    //            HdfQueid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Dept_Id")).Trim();

    //            e.Row.Cells[3].Text = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fees")).ToString("#,##0");

    //            HiddenField HdfAmount = (HiddenField)e.Row.Cells[0].FindControl("HdfAmount");
    //            HdfAmount.Value = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fees")).ToString("#,##0");
    //        }
    //        if ((e.Row.RowType == DataControlRowType.Footer))
    //        {
    //            e.Row.Cells[2].Text = "Total Fee";
    //            e.Row.Cells[3].Text = TotalFee.ToString("#,##0");


    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        // lblmsg0.Text = ex.Message;
    //        // Failure.Visible = true;
    //        // success.Visible = false;
    //        Response.Write(ex);
    //        LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
    //    }
    //}

    protected void rbtTicketShow_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtTicketShow.SelectedValue.ToString() == "Y")
        {
            divTicketEach.Visible = true;
            divChildrenTicketEach.Visible = true;
        }
        else
        {
            divTicketEach.Visible = false;
            divChildrenTicketEach.Visible = false;
        }
    }

    protected void rbtAnyVIP_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtAnyVIP.SelectedValue.ToString() == "Y")
        {
            divAnyVIP.Visible = true;
        }
        else
        {
            divAnyVIP.Visible = false;
        }
    }

    protected void rbtAnyForeigner_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtAnyForeigner.SelectedValue.ToString() == "Y")
        {
            divAnyForeigner.Visible = true;
        }
        else
        {
            divAnyForeigner.Visible = false;
        }
    }

    protected void rbtTemporaryStructure_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtTemporaryStructure.SelectedValue.ToString() == "Y")
        {
            divTemporarySturucture.Visible = true;
        }
        else
        {
            divTemporarySturucture.Visible = false;
        }
    }

    protected void btnfupLayoutoftheevent_Click(object sender, EventArgs e)
    {
        string newPath = "";
        // string sFileDir = @"D:\TS-iPASSFinal\Attachments";
        string SubFolder = @"\TOURISMEVENT\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        General.FileResult objfileResult = new General.FileResult();

        string[] extensions = { ".pdf", ".jpg", ".jpeg" };
        objfileResult = Gen.SaveFile(fupLayoutoftheevent, SubFolder, "LayoutofEvent");

        if (objfileResult.Result == true)
        {

            //HyperLinkfupLayoutoftheevent.Visible = true;
            //HyperLinkfupLayoutoftheevent.NavigateUrl = objfileResult.FilePath;
            lblfupLayoutoftheevent.Text = objfileResult.FileName;
            hdnlayoutevent.Value = objfileResult.FileType;
            hdnlayouteventfilename.Value = objfileResult.FileName;
            fupLayoutoftheevent.Visible = false;
            btnfupLayoutoftheevent.Visible = false;
            BtnSave.Focus();
            int result = 0;
            result = SaveAttachments(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "Layoutoftheevent", Session["uid"].ToString());
            if (result > 0)
            {
                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                HyperLinkfupLayoutoftheevent.Visible = true;
                HyperLinkfupLayoutoftheevent.Text = objfileResult.FileName;

                success.Visible = true;
                Failure.Visible = false;
            }
            else
            {
                lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                success.Visible = false;
                Failure.Visible = true;
            }

        }
        else
        {

            HyperLinkfupLayoutoftheevent.NavigateUrl = objfileResult.FilePath;
            lblfupLayoutoftheevent.Text = objfileResult.Message;
        }
    }

    public void filldetails()
    {
        int CreatedBy = Convert.ToInt32(Session["uid"]);
        DataSet ds = Gen.GetperformlicensebyTourismPerformanceLicenseID(CreatedBy);
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                string App_Status= Convert.ToString(ds.Tables[0].Rows[0]["App_Status"]);
                if (App_Status == "2")
                {
                    btnPayment.Visible = true;
                    trUploads.Visible = true;
                    Session["Applid"] = Convert.ToString(ds.Tables[0].Rows[0]["TourismPerformanceLicenseID"]);
                    hdnTransactionNumber.Value = Convert.ToString(ds.Tables[0].Rows[0]["TourismPerformanceLicenseID"]);
                    ddlTypeofEvent.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["TypeofEventValue"]);
                    rbtClassificationofEvent.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ClassificationofEvent_Value"]);
                    txtNameofTheApplicant.Text = Convert.ToString(ds.Tables[0].Rows[0]["NameofTheApplicant"]);
                    txtFatherName.Text = Convert.ToString(ds.Tables[0].Rows[0]["FatherName"]);
                    rbtPoliceNOC.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Police_NOC"]);
                    //lbl_aadhaarcard.Text = Convert.ToString(ds.Tables[0].Rows[0]["AadharNumber"]);
                    txtPanNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["PanNumber"]);
                    txtcompanyaddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["EventManagement_Address"]);
                    txtAddressWithContact.Text = Convert.ToString(ds.Tables[0].Rows[0]["AddressWithContact"]);
                    txtNameAddEventManagement.Text = Convert.ToString(ds.Tables[0].Rows[0]["NameAddEventManagement"]);
                    txtGSTNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["GSTNumber"]);
                    txtNameLocPerformance.Text = Convert.ToString(ds.Tables[0].Rows[0]["NameLocPerformance"]);
                    ddlstructureType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["structureTypeValue"]);
                    txtNoofStalls.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoofStalls"]);
                    txtSize.Text = Convert.ToString(ds.Tables[0].Rows[0]["Size"]);
                    ddlFabrication.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["FabricationValue"]);
                    rbtclearspace.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["clearspace"]);
                    rbtTemporaryStructure.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["TemporaryStructure"]);
                    ddlworktimingsfrom.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["WorkingtimingsFrm"]);
                    ddlworktimingsto.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["WorkingtimingsTo"]);
                    ddlperformancetimingsfrom.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Performancetimingsfrm"]);
                    ddlperformancetimingsto.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PerformancetimingsTo"]);
                    txtStartDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["StartDate"]);
                    txtEndDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["EndDate"]);
                    ddlExpectedstrength.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ExpectedstrengthValue"]);
                    txtProductRelated.Text = Convert.ToString(ds.Tables[0].Rows[0]["ProductRelated"]);
                    txtFoodBeverages.Text = Convert.ToString(ds.Tables[0].Rows[0]["FoodBeverages"]);
                    txtGamesEntertainment.Text = Convert.ToString(ds.Tables[0].Rows[0]["GamesEntertainment"]);
                    txtOthers.Text = Convert.ToString(ds.Tables[0].Rows[0]["Others"]);
                    rbtFreeEntryInvitation.Text = Convert.ToString(ds.Tables[0].Rows[0]["FreeEntryInvitation"]);
                    rbtFreeEntryWithoutInvitation.Text = Convert.ToString(ds.Tables[0].Rows[0]["FreeEntryWithoutInvitation"]);
                    rbtTicketShow.Text = Convert.ToString(ds.Tables[0].Rows[0]["TicketShow"]);
                    txtAdultTicket.Text = Convert.ToString(ds.Tables[0].Rows[0]["AdultTicket"]);
                    txtChildrensTicket.Text = Convert.ToString(ds.Tables[0].Rows[0]["ChildrensTicket"]);
                    txtNoOfTicketCounters.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoOfTicketCounters"]);
                    txtParkingSpace.Text = Convert.ToString(ds.Tables[0].Rows[0]["ParkingSpace"]);
                    txtSecurityArrangements.Text = Convert.ToString(ds.Tables[0].Rows[0]["SecurityArrangements"]);
                    txtProposedNoOfCCTV.Text = Convert.ToString(ds.Tables[0].Rows[0]["ProposedNoOfCCTV"]);
                    txtProposedNoOfDFMD.Text = Convert.ToString(ds.Tables[0].Rows[0]["ProposedNoOfDFMD"]);
                    txtNoOfSecurityAndVolunteers.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoOfSecurityAndVolunteers"]);
                    txtNoOfExitsWithWidth.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoOfExitsWithWidth"]);
                    txtWidthOfGangways.Text = Convert.ToString(ds.Tables[0].Rows[0]["NOofGangways"]);//NOofGangways
                    txtCO2Cylinders.Text = Convert.ToString(ds.Tables[0].Rows[0]["CO2Cylinders"]);
                    txtFoamCylinders.Text = Convert.ToString(ds.Tables[0].Rows[0]["FoamCylinders"]);
                    txtNoOfBuckets.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoOfBuckets"]);
                    txtNoOfWaterStorageTanks.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoOfWaterStorageTanks"]);
                    txtNoOfSandBags.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoOfSandBags"]);
                    rbtStandbyFireService.Text = Convert.ToString(ds.Tables[0].Rows[0]["StandbyFireService"]);

                    if (ds.Tables[0].Rows[0]["StandbyFireService"].ToString() == "Y")
                    {
                        trCategoryForVehicleStandBy.Visible = true;
                        ddlcategoryvehiclestandby.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["VehicleStandByCategory"]);
                        trloandocuuments.Visible = true;
                    }

                    rbtFirstAidFacility.Text = Convert.ToString(ds.Tables[0].Rows[0]["FirstAidFacility"]);
                    rbtMedicalAttender.Text = Convert.ToString(ds.Tables[0].Rows[0]["MedicalAttender"]);
                    rbtSatndbyAmbulanceFacility.Text = Convert.ToString(ds.Tables[0].Rows[0]["SatndbyAmbulanceFacility"]);
                    txtNoOfSecurityVehicleChecking.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoOfSecurityVehicleChecking"]);
                    txtTicketShowDetails.Text = Convert.ToString(ds.Tables[0].Rows[0]["TicketShowDetails"]);

                    rbtAnyVIP.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["VIP_Visited"]);
                    if(ds.Tables[0].Rows[0]["VIP_Visited"].ToString()=="Y")
                    {
                        divAnyVIP.Visible = true;
                        txtAnyVIP.Text = Convert.ToString(ds.Tables[0].Rows[0]["VIP_Visited_Name"]);
                    }
                    else
                    {
                        divAnyVIP.Visible = false;
                    }
                    
                    rbtAnyForeigner.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Foreigner_Expected"]);
                    if (ds.Tables[0].Rows[0]["Foreigner_Expected"].ToString() == "Y")
                    {
                        divAnyForeigner.Visible = true;
                        txtAnyForeigner.Text = Convert.ToString(ds.Tables[0].Rows[0]["Foreigner_Expected_Remarks"]);
                    }
                    else
                    {
                        divAnyForeigner.Visible = false;
                    }
                        txtMobileNumberApplicant.Text = Convert.ToString(ds.Tables[0].Rows[0]["MobileNumber"]);
                    txtEmailID.Text = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                    txtarea.Text = Convert.ToString(ds.Tables[0].Rows[0]["Location_Width"]);
                    txtExitsWidth.Text = Convert.ToString(ds.Tables[0].Rows[0]["Exits_Width"]);
                    txtGangWaysWidth.Text = Convert.ToString(ds.Tables[0].Rows[0]["WidthOfGangways"]);

                    ddldistrict.SelectedValue= Convert.ToString(ds.Tables[0].Rows[0]["District"]);
                    ddldistrict_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlmandal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Mandal"]);
                    ddlmandal_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlvillage.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Taluk"]);
                    txtpincode.Text= Convert.ToString(ds.Tables[0].Rows[0]["PINCODE"]);

                    ddlcompanydistrict.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["District_comp"]);
                    ddlcompanydistrict_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlcompanymandal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Mandal_comp"]);
                    ddlcompanymandal_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlcompanyvillage.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Village_comp"]);
                    txtcompanypincode.Text= Convert.ToString(ds.Tables[0].Rows[0]["PINCODE_comp"]);
  

                      
                    //Convert.ToString(ds.Tables[0].Rows[0]["UID_no"]);
                    //Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                    //Convert.ToString(ds.Tables[0].Rows[0]["MobileNumber"]);

                    //Convert.ToString(ds.Tables[0].Rows[0]["App_Status"]);
                    //Convert.ToString(ds.Tables[0].Rows[0]["PaymentDate"]);
                    //Convert.ToString(ds.Tables[0].Rows[0]["Mandal"]);
                    //Convert.ToString(ds.Tables[0].Rows[0]["Taluk"]);
                    //Convert.ToString(ds.Tables[0].Rows[0]["District"]);
                    //Convert.ToString(ds.Tables[0].Rows[0]["CreatedDate"]);
                    //Convert.ToString(ds.Tables[0].Rows[0]["CreatedBy"]);
                    if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {
                        FillAttachmentsDetails(ds);
                    }
                }

            }
        }
        //DataSet dsattachments = new DataSet();

        //try
        //{
        //    ds = Gen.getTraineeDetails(hdfID.Value.ToString());

        //    dsattachments = Gen.ViewTourismEventAttachmetsData(ID);

        //    if (dsattachments.Tables[0].Rows.Count > 0)
        //    {
        //        int c = dsattachments.Tables[0].Rows.Count;
        //        string sen, sen1, sen2, senPlanB;
        //        int i = 0;


        //        DataTable dt1 = new DataTable();
        //        dt1.Columns.Add("link");
        //        dt1.Columns.Add("FileName");

        //        DataTable dt2 = new DataTable();
        //        dt2.Columns.Add("link");
        //        dt2.Columns.Add("FileName");

        //        while (i < c)
        //        {
        //            sen2 = dsattachments.Tables[0].Rows[i][0].ToString();
        //            sen1 = sen2.Replace(@"\", @"/");
        //            sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

        //            if (sen.Contains("SelfCertification"))
        //            {
        //                lblFileName.NavigateUrl = sen;
        //                lblFileName.Text = dsattachments.Tables[0].Rows[i][1].ToString();
        //                Label444.Text = dsattachments.Tables[0].Rows[i][1].ToString();

        //            }

        //            if (sen.Contains("Enclosetraffic"))
        //            {
        //                Label1.NavigateUrl = sen;
        //                Label1.Text = dsattachments.Tables[0].Rows[i][1].ToString();
        //                Label445.Text = dsattachments.Tables[0].Rows[i][1].ToString();

        //            }

        //            if (sen.Contains("PartnershipDeed"))
        //            {
        //                Label2.NavigateUrl = sen;
        //                Label2.Text = dsattachments.Tables[0].Rows[i][1].ToString();
        //                Label446.Text = dsattachments.Tables[0].Rows[i][1].ToString();

        //            }




        //            if (sen.Contains("RelevantCopy"))
        //            {
        //                lblFileName0.NavigateUrl = sen;
        //                lblFileName0.Text = dsattachments.Tables[0].Rows[i][1].ToString();
        //                Label449.Text = dsattachments.Tables[0].Rows[i][1].ToString();

        //            }

        //            if (sen.Contains("PanCard"))
        //            {
        //                Label438.NavigateUrl = sen;
        //                Label438.Text = dsattachments.Tables[0].Rows[i][1].ToString();
        //                Label450.Text = dsattachments.Tables[0].Rows[i][1].ToString();

        //            }

        //            if (sen.Contains("ProofOfAddress"))
        //            {
        //                Label440.NavigateUrl = sen;
        //                Label440.Text = dsattachments.Tables[0].Rows[i][1].ToString();
        //                Label451.Text = dsattachments.Tables[0].Rows[i][1].ToString();

        //            }



        //            if (sen.Contains("FabricationMaterialDoc"))
        //            {
        //                Label453.NavigateUrl = sen;
        //                Label453.Text = dsattachments.Tables[0].Rows[i][1].ToString();
        //                Label454.Text = dsattachments.Tables[0].Rows[i][1].ToString();

        //            }

        //            if (sen.Contains("LayoutofEvent"))
        //            {

        //                HyperLink1.NavigateUrl = sen;
        //                HyperLink1.Text = dsattachments.Tables[0].Rows[i][1].ToString();
        //                Label8.Text = dsattachments.Tables[0].Rows[i][1].ToString();


        //            }

        //            i++;
        //        }

        //    }


        //}
        //catch (Exception ex)
        //{
        //    lblmsg0.Text = "Internal error has occured. Please try after some time";
        //    lblmsg0.Text = ex.Message;
        //    Failure.Visible = true;
        //}
        //finally
        //{

        //}

    }

    public void BindDistricts()
    {
        //DataSet dsTypes = new DataSet();
        //dsTypes = Gen.GetDistricts();
        Cls_MasterofTsipass obj_newdistrictwargnal = new Cls_MasterofTsipass();
        DataSet dsTypes = new DataSet();
        dsTypes = obj_newdistrictwargnal.GetallDistrictswithoutWarangal(Convert.ToString(Session["uid"]), "TE");
        if (dsTypes.Tables[0].Rows.Count > 0)
        {
            ddldistrict.DataSource = dsTypes.Tables[0];
            ddldistrict.DataTextField = "District_Name";
            ddldistrict.DataValueField = "District_Id";
            ddldistrict.DataBind();

            ddldistrict.Items.Insert(0, new ListItem("Select", "0"));

        }
    }
    public void BindCompanyDistricts()
    {
        //DataSet dsTypes = new DataSet();
        //dsTypes = Gen.GetDistricts();
        Cls_MasterofTsipass obj_newdistrictwargnal = new Cls_MasterofTsipass();
        DataSet dsTypes = new DataSet();
        dsTypes = obj_newdistrictwargnal.GetallDistrictswithoutWarangal(Convert.ToString(Session["uid"]), "TE");
        if (dsTypes.Tables[0].Rows.Count > 0)
        {
            ddlcompanydistrict.DataSource = dsTypes.Tables[0];
            ddlcompanydistrict.DataTextField = "District_Name";
            ddlcompanydistrict.DataValueField = "District_Id";
            ddlcompanydistrict.DataBind();

            ddlcompanydistrict.Items.Insert(0, new ListItem("Select", "0"));

        }
    }
    
    protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddldistrict.SelectedIndex == 0)
            {
                ddlmandal.Items.Clear();
                ddlmandal.Items.Insert(0, "--Mandal--");
                //   ChkWater_reg_from.Items.Clear();
                // ChkWater_reg_from.Items.Insert(0, new ListItem("New Bore well", "New Bore well"));
                //ChkWater_reg_from.Items.Insert(1, new ListItem("HMWS & SB", "HMWS & SB"));
                //ChkWater_reg_from.Items.Insert(2, new ListItem("Rivers/Canals", "Rivers/Canals"));
            }
            else
            {
                ddlmandal.Items.Clear();
                DataSet dsm = new DataSet();
                dsm = Gen.GetMandals(ddldistrict.SelectedValue);
                if (dsm.Tables[0].Rows.Count > 0)
                {
                    ddlmandal.DataSource = dsm.Tables[0];
                    ddlmandal.DataValueField = "Mandal_Id";
                    ddlmandal.DataTextField = "Manda_lName";
                    ddlmandal.DataBind();
                    ddlmandal.Items.Insert(0, "--Mandal--");
                }
                else
                {
                    ddlmandal.Items.Clear();
                    ddlmandal.Items.Insert(0, "--Mandal--");
                }



            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void ddlmandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlmandal.SelectedIndex == 0)
            {

                ddlvillage.Items.Clear();
                ddlvillage.Items.Insert(0, "--Village--");
            }
            else
            {
                ddlvillage.Items.Clear();
                DataSet dsv = new DataSet();
                dsv = Gen.GetVillages(ddlmandal.SelectedValue);
                if (dsv.Tables[0].Rows.Count > 0)
                {
                    ddlvillage.DataSource = dsv.Tables[0];
                    ddlvillage.DataValueField = "Village_Id";
                    ddlvillage.DataTextField = "Village_Name";
                    ddlvillage.DataBind();
                    ddlvillage.Items.Insert(0, "--Village--");
                }
                else
                {
                    ddlvillage.Items.Clear();
                    ddlvillage.Items.Insert(0, "--Village--");
                }
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void ddlcompanydistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlcompanydistrict.SelectedIndex == 0)
            {
                ddlcompanymandal.Items.Clear();
                ddlcompanymandal.Items.Insert(0, "--Mandal--");
                //   ChkWater_reg_from.Items.Clear();
                // ChkWater_reg_from.Items.Insert(0, new ListItem("New Bore well", "New Bore well"));
                //ChkWater_reg_from.Items.Insert(1, new ListItem("HMWS & SB", "HMWS & SB"));
                //ChkWater_reg_from.Items.Insert(2, new ListItem("Rivers/Canals", "Rivers/Canals"));
            }
            else
            {
                ddlcompanymandal.Items.Clear();
                DataSet dsm = new DataSet();
                dsm = Gen.GetMandals(ddlcompanydistrict.SelectedValue);
                if (dsm.Tables[0].Rows.Count > 0)
                {
                    ddlcompanymandal.DataSource = dsm.Tables[0];
                    ddlcompanymandal.DataValueField = "Mandal_Id";
                    ddlcompanymandal.DataTextField = "Manda_lName";
                    ddlcompanymandal.DataBind();
                    ddlcompanymandal.Items.Insert(0, "--Mandal--");
                }
                else
                {
                    ddlcompanymandal.Items.Clear();
                    ddlcompanymandal.Items.Insert(0, "--Mandal--");
                }



            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void ddlcompanymandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlcompanymandal.SelectedIndex == 0)
            {

                ddlcompanyvillage.Items.Clear();
                ddlcompanyvillage.Items.Insert(0, "--Village--");
            }
            else
            {
                ddlcompanyvillage.Items.Clear();
                DataSet dsv = new DataSet();
                dsv = Gen.GetVillages(ddlcompanymandal.SelectedValue);
                if (dsv.Tables[0].Rows.Count > 0)
                {
                    ddlcompanyvillage.DataSource = dsv.Tables[0];
                    ddlcompanyvillage.DataValueField = "Village_Id";
                    ddlcompanyvillage.DataTextField = "Village_Name";
                    ddlcompanyvillage.DataBind();
                    ddlcompanyvillage.Items.Insert(0, "--Village--");
                }
                else
                {
                    ddlcompanyvillage.Items.Clear();
                    ddlcompanyvillage.Items.Insert(0, "--Village--");
                }
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void rbtStandbyFireService_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtStandbyFireService.SelectedValue == "Y")
        {
            trCategoryForVehicleStandBy.Visible = true;
        }
        else
        {
            ddlcategoryvehiclestandby.ClearSelection();
            trCategoryForVehicleStandBy.Visible = false;
            trloandocuuments.Visible = false;
        }
    }

    protected void btnloandocuments_Click(object sender, EventArgs e)
    {
        string newPath = "";
        // string sFileDir = @"D:\TS-iPASSFinal\Attachments";
        string SubFolder = @"\TOURISMEVENT\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        General.FileResult objfileResult = new General.FileResult();

        string[] extensions = { ".pdf", ".jpg", ".jpeg" };
        objfileResult = Gen.SaveFile(fuploandocuments, SubFolder, "LoanDocuments");

        if (objfileResult.Result == true)
        {

            //HyperLinkfupLayoutoftheevent.Visible = true;
            //HyperLinkfupLayoutoftheevent.NavigateUrl = objfileResult.FilePath;
            lblloandocuments.Text = objfileResult.FileName;
            hdnloandocument.Value = objfileResult.FileType;
            hdnloandocumentfilename.Value = objfileResult.FileName;
            fuploandocuments.Visible = false;
            btnloandocuments.Visible = false;
            BtnSave.Focus();
            int result = 0;
            result = SaveAttachments(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "LoanDocuments", Session["uid"].ToString());
            if (result > 0)
            {
                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                Hyperloandocuments.Visible = true;
                Hyperloandocuments.Text = objfileResult.FileName;

                success.Visible = true;
                Failure.Visible = false;
            }
            else
            {
                lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                success.Visible = false;
                Failure.Visible = true;
            }

        }
        else
        {

            Hyperloandocuments.NavigateUrl = objfileResult.FilePath;
            lblloandocuments.Text = objfileResult.Message;
        }
    }
    protected void ddlcategoryvehiclestandby_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlcategoryvehiclestandby.SelectedValue == "4" && trUploads.Visible == true)
        {
            trloandocuuments.Visible = true;
        }
        else
        {
            trloandocuuments.Visible = false;
        }
    }

    public int SaveAttachments(string intTourismId, string FileType, string FilePath, string FileName, string FileDescription, string Created_by, string deptid, string approvalid)
    {
        int n = 0;
        try
        {

            con.OpenConnection();

            SqlCommand cmdFiles = new SqlCommand("usp_Insert_TourismEvent_attachments", con.GetConnection);
            cmdFiles.CommandType = CommandType.StoredProcedure;

            cmdFiles.Parameters.AddWithValue("@TourismEvent_ID", Convert.ToInt32(intTourismId));
            cmdFiles.Parameters.AddWithValue("@FileType", FileType);
            cmdFiles.Parameters.AddWithValue("@FilePath", FilePath);
            cmdFiles.Parameters.AddWithValue("@FileName", FileName);
            cmdFiles.Parameters.AddWithValue("@FileDescription", FileDescription);
            cmdFiles.Parameters.AddWithValue("@Created_by", Created_by);
            cmdFiles.Parameters.AddWithValue("@DEPTID", deptid);
            cmdFiles.Parameters.AddWithValue("@APPROVALID", approvalid);
            n = cmdFiles.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            con.CloseConnection();
            throw ex;

        }
        finally
        {

            con.CloseConnection();

        }
        return n;
    }
}
