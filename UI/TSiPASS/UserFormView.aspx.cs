using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;


public partial class UI_TSIPASS_UserFormView : System.Web.UI.Page
{


    DataSet GDS = new DataSet();
    General Gen = new General();
    public static DataSet GDs { get; set; }
    CommonBL Common = new CommonBL();


    public int Applicationid { get; set; }


    protected void Page_Load(object sender, EventArgs e)
    {

        Applicationid = Convert.ToInt32(Request.QueryString["AppId"].ToString());
        int uid = Convert.ToInt32(Session["uid"]);

        if (!IsPostBack)
        {

            tsiicdetailsdata(uid, Applicationid);
            bindata();


        }


    }


    public DataSet tsiicdetailsdata(int createdby, int applicationid)
    {
        try
        {
            SqlParameter[] p = new SqlParameter[] {
                    new SqlParameter("@createdby",SqlDbType.Int),
                  new SqlParameter("@Appid",SqlDbType.Int),
                };
            p[0].Value = Convert.ToInt32(Session["uid"]);
            p[1].Value = Applicationid;

            GDs = Gen.GenericFillDs("USP_GET_TSIICabsractDETAILS", p);
            GDs.Tables[0].TableName = "tsiicplotallotmentmain";
            GDs.Tables[1].TableName = "tsiicplotallotmentdetails";
            GDs.Tables[2].TableName = "tsiicapplicantdetails";
            GDs.Tables[3].TableName = "Tsiicattachments";
            GDs.Tables[4].TableName = "addlpromotordetails";
            GDs.Tables[5].TableName = "Proposedproduct";
            GDs.Tables[6].TableName = "Materialmanufacturing";




            return GDs;
        }
        catch (Exception ex)
        {
            throw ex;
            //LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, HttpContext.Current.Session["uid"].ToString());
        }
    }



    public void bindata()
    {


        DataTable dt = new DataTable();
        dt = (DataTable)GDs.Tables[3];


        if (GDs.Tables[0].Rows.Count > 0)
        {

            lblApplicationNo.InnerText = GDs.Tables[0].Rows[0]["ApplicationId"].ToString();

            lblAppliedRm.InnerText = GDs.Tables[0].Rows[0]["DistrictName"].ToString();

            if (GDs.Tables[0].Rows[0]["IndustrialParkNAMECGG"].ToString() != "" && GDs.Tables[0].Rows[0]["IndustrialParkNAMECGG"].ToString() != null &&
               GDs.Tables[0].Rows[0]["IndustrialParkNAMECGG"].ToString() != "Select")
            {
                lblUnitType.InnerText = GDs.Tables[0].Rows[0]["IndustrialParkNAMECGG"].ToString();
            }
            else
            {
                lblUnitType.InnerText = GDs.Tables[0].Rows[0]["IndustrialParkId"].ToString();
            }
            Span31.InnerText = GDs.Tables[0].Rows[0]["ApplicationFilledDate"].ToString();
        }

        if (GDs.Tables[1].Rows.Count > 0)
        {

            if (GDs.Tables[1].Rows.Count > 0)
            {
                string str = "";
                for (int i = 0; i < GDs.Tables[1].Rows.Count; i++)
                {
                    str += GDs.Tables[1].Rows[i]["PlotNo"].ToString() + ",";
                }
                lblApplicantName.InnerText = str.Substring(0, str.Length - 1);
            }


            lblEmNo.InnerText = GDs.Tables[8].Rows[0]["PlotTotalamount"].ToString();

            lblLineofActivity.InnerText = GDs.Tables[1].Rows[0]["plotdescription"].ToString();
        }

        if (GDs.Tables[2].Rows.Count > 0)
        {
            lblUnitname.InnerText = lblfirmname.InnerText = GDs.Tables[2].Rows[0]["NameOftheFirm_Applicant"].ToString();
            lbldoorno.InnerText = GDs.Tables[2].Rows[0]["Door_No_RegOffice"].ToString();
            lblstreet1.InnerText = GDs.Tables[2].Rows[0]["Street_1_RegOffice"].ToString();
            lblstreet2.InnerText = GDs.Tables[2].Rows[0]["Street_2_RegOffice"].ToString();


            lblstate.InnerText = GDs.Tables[2].Rows[0]["stateName"].ToString();


            lblindusshed.InnerText = GDs.Tables[2].Rows[0]["Industrialshedarea"].ToString();
            lblvillage.InnerText = GDs.Tables[2].Rows[0]["villageregoffice"].ToString();
            lbldistrict.InnerText = GDs.Tables[2].Rows[0]["Distidregoffice"].ToString();

            lblmandal.InnerText = GDs.Tables[2].Rows[0]["mandalregoffice"].ToString();

            lblpincode.InnerText = GDs.Tables[2].Rows[0]["Pincode_RegOffice"].ToString();
            lblregoffice.InnerText = GDs.Tables[2].Rows[0]["Category_RegOffice"].ToString();

            //ddlYearofEstablishment.Text = GDs.Tables[2].Rows[0]["YearofEstablishment_Firmregistration"].ToString();

            //ddlYearofCommencement.Text = GDs.Tables[2].Rows[0]["YearofCommencement_Firmregistration"].ToString();

            //txtfirmregno.Text = GDs.Tables[2].Rows[0]["RegistrationNo_Firmregistration"].ToString();


            lblsurname.InnerText = GDs.Tables[2].Rows[0]["Surname_Cont_info"].ToString();

            lblfirstname.InnerText = GDs.Tables[2].Rows[0]["FirstName_Cont_info"].ToString();

            lblmobileno.InnerText = GDs.Tables[2].Rows[0]["MobileNo_Cont_info"].ToString();
            lbltelphone.InnerText = GDs.Tables[2].Rows[0]["TelephonoNo1_RegOffice"].ToString();
            lbltelphone1.InnerText = GDs.Tables[2].Rows[0]["TelephonoNo2_RegOffice"].ToString();

            lblTypeOfApplication.InnerText = GDs.Tables[2].Rows[0]["Industrialshedarea"].ToString();
            lblcontactdoor.InnerText = GDs.Tables[2].Rows[0]["Door_No_Cont_info"].ToString();
            lblfaxno.InnerText = GDs.Tables[2].Rows[0]["FaxNo1_RegOffice"].ToString();
            lblfaxnos.InnerText = GDs.Tables[2].Rows[0]["FaxNo2_RegOffice"].ToString();
            lblcontactstate.InnerText = GDs.Tables[2].Rows[0]["statecontactinfo"].ToString();


            lblcontactdist.InnerText = GDs.Tables[2].Rows[0]["Distidcontactinfo"].ToString();

            lblcontactmandal.InnerText = GDs.Tables[2].Rows[0]["mandalcontinfo"].ToString();

            lblvillagecontact.InnerText = GDs.Tables[2].Rows[0]["villagecontinfo"].ToString();


            lblcontactstreet1.InnerText = GDs.Tables[2].Rows[0]["Street_1_Cont_info"].ToString();


            lblcontactstreet.InnerText = GDs.Tables[2].Rows[0]["Street_2_Cont_info"].ToString();
            lbldoornocom.InnerText = GDs.Tables[2].Rows[0]["Door_No_CommAddr"].ToString();
            lblcomstreet2.InnerText = GDs.Tables[2].Rows[0]["Street_2_CommAddr"].ToString();

            lblcomstreet1.InnerText = GDs.Tables[2].Rows[0]["Street_1_CommAddr"].ToString();
            //  txtPrvplotNo.Text = GDs.Tables[2].Rows[0]["PlotNo"].ToString();

            lbltypeorganistaion.InnerText = GDs.Tables[2].Rows[0]["TypeofOrganization_RegOfficesss"].ToString();
            Span13.InnerText = GDs.Tables[2].Rows[0]["GovtDeptName_RegOffice"].ToString();



            lblcomstate.InnerText = GDs.Tables[2].Rows[0]["StateCommAddr"].ToString();

            Span14.InnerText = GDs.Tables[2].Rows[0]["malephase1"].ToString();
            Span26.InnerText = GDs.Tables[2].Rows[0]["malephase2"].ToString();
            Span27.InnerText = GDs.Tables[2].Rows[0]["malephase3"].ToString();
            Span28.InnerText = GDs.Tables[2].Rows[0]["femalephase1"].ToString();
            Span29.InnerText = GDs.Tables[2].Rows[0]["femalephase2"].ToString();
            Span30.InnerText = GDs.Tables[2].Rows[0]["femalephase3"].ToString();





            lblcomdist.InnerText = GDs.Tables[2].Rows[0]["DistidCommAddr"].ToString();

            lblcommandal.InnerText = GDs.Tables[2].Rows[0]["mandalcommaddr"].ToString();

            lblcomvilage.InnerText = GDs.Tables[2].Rows[0]["villagecommaddr"].ToString();
            lblcompincode.InnerText = GDs.Tables[2].Rows[0]["Pincode_CommAddr"].ToString();

            //TextBox49.Text = GDs.Tables[2].Rows[0]["Pincode_CommAddr"].ToString();
            lblcomtelephone1.InnerText = GDs.Tables[2].Rows[0]["TelephonoNo1_CommAddr"].ToString();

            lblcomtelephone2.InnerText = GDs.Tables[2].Rows[0]["TelephonoNo2_CommAddr"].ToString();

            lblfaxno1.InnerText = GDs.Tables[2].Rows[0]["FaxNo1_CommAddr"].ToString();
            lblfaxno2.InnerText = GDs.Tables[2].Rows[0]["FaxNo2_CommAddr"].ToString();


            Span1.InnerText = GDs.Tables[2].Rows[0]["Domestic"].ToString();
            Span2.InnerText = GDs.Tables[2].Rows[0]["Foreigns"].ToString();
            Span3.InnerText = GDs.Tables[2].Rows[0]["TotalEquity"].ToString();
            Span4.InnerText = GDs.Tables[2].Rows[0]["EquityName"].ToString();
            Span5.InnerText = GDs.Tables[2].Rows[0]["Amount"].ToString();
            Span7.InnerText = GDs.Tables[2].Rows[0]["TotalEquitdebit"].ToString();


            Span6.InnerText = GDs.Tables[2].Rows[0]["Foreigninvestment"].ToString();
            Span11.InnerText = GDs.Tables[2].Rows[0]["Foreigninvestmentdates"].ToString();
            Span8.InnerText = GDs.Tables[2].Rows[0]["IEM"].ToString();
            Span12.InnerText = GDs.Tables[2].Rows[0]["IEMDates"].ToString();
            Span9.InnerText = GDs.Tables[2].Rows[0]["LOI"].ToString();
            Span15.InnerText = GDs.Tables[2].Rows[0]["LOIdates"].ToString();
            Span10.InnerText = GDs.Tables[2].Rows[0]["EOUNo"].ToString();
            Span17.InnerText = GDs.Tables[2].Rows[0]["EOUdates"].ToString();


            lblhouse.InnerText = GDs.Tables[2].Rows[0]["House_Prv_flot"].ToString();
            lblplotno1.InnerText = GDs.Tables[2].Rows[0]["PlotNo_Prv_flot"].ToString();

            lblshop.InnerText = GDs.Tables[2].Rows[0]["Shop_Prv_flot"].ToString();
            lblshedname.InnerText = GDs.Tables[2].Rows[0]["ShedName_Prv_flot"].ToString();
            lblotherdetails.InnerText = GDs.Tables[2].Rows[0]["OtherDetails_Prv_flot"].ToString();
            lblstatusallloted.InnerText = GDs.Tables[2].Rows[0]["StatusAllotted_Lease_Name_Prv_flot"].ToString();
            //verifyFirmvo.categoryOfAllotment = GDs.Tables[2].Rows[0]["TypeofOrganization_RegOffice"].ToString();


            lblregisterringquthority.InnerText = GDs.Tables[2].Rows[0]["RegisteringAuthority_Firmregistration"].ToString();
            lblregistrationno.InnerText = GDs.Tables[2].Rows[0]["RegistrationNo_Firmregistration"].ToString();
            lblYearestablishment.InnerText = GDs.Tables[2].Rows[0]["YearofEstablishment_Firmregistration"].ToString();
            lblyearcommencement.InnerText = GDs.Tables[2].Rows[0]["YearofCommencement_Firmregistration"].ToString();


            lblemailcontact.InnerText = GDs.Tables[2].Rows[0]["Email_Cont_info"].ToString();

            lblprojeccategory.InnerText = GDs.Tables[2].Rows[0]["typeofprojectscategory"].ToString();
            lblprojectname.InnerText = GDs.Tables[2].Rows[0]["ProjectName_Description_General_Info"].ToString();

            if (GDs.Tables[2].Rows[0]["ProjectStatus_General_Info"].ToString() == "1")
            {
                lblprojectstatus.InnerText = "New";
            }
            else if (GDs.Tables[2].Rows[0]["ProjectStatus_General_Info"].ToString() == "2")
            {
                lblprojectstatus.InnerText = "Expansion";
            }
            else
            {
                lblprojectstatus.InnerText = "Diversification";

            }

            if (GDs.Tables[2].Rows[0]["TypeofVenture_General_Info"].ToString() == "1")
            {

                lbltypeventure.InnerText = "Manufacturing";
            }
            else
            {
                lbltypeventure.InnerText = "Service";
            }

            lblprojeccategory1.InnerText = GDs.Tables[02].Rows[0]["projectother"].ToString();
            lblprojeccategory2.InnerText = GDs.Tables[2].Rows[0]["ProjectCategory3_General_Info"].ToString();

            lblexpectedcommercial.InnerText = GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infos"].ToString();
            lblexpecteddateconstruction.InnerText = GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infos"].ToString();

            lblexpecteddatetrialoperation.InnerText = GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infos"].ToString();

            lblexpectedcommercialphase2.InnerText = GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infophase2s"].ToString();
            lblexpecteddateconstructionphase2.InnerText = GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infophase2s"].ToString();

            lblexpecteddatetrialoperationphase2.InnerText = GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infophase2s"].ToString();

            lblexpectedcommercialphase3.InnerText = GDs.Tables[2].Rows[0]["DtCommencement_Commercial_Operations_General_Infophase3s"].ToString();
            lblexpecteddateconstructionphase3.InnerText = GDs.Tables[2].Rows[0]["Expected_Dt_Commencement_Construction_General_Infophase3s"].ToString();

            lblexpecteddatetrialoperationphase3.InnerText = GDs.Tables[2].Rows[0]["Expected_Dt_Trial_Operations_General_Infophase3s"].ToString();

            lblland.InnerText = GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhs"].ToString();
            lblbuildings.InnerText = GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhs"].ToString();
            lblcontingencies.InnerText = GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhs"].ToString();
            lblauxilaryequipment.InnerText = GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhs"].ToString();
            lblindigenous.InnerText = GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhs"].ToString();
            lblimported.InnerText = GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhs"].ToString();
            lblworkcaptail.InnerText = GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhs"].ToString();
            lblpremlinary.InnerText = GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhs"].ToString();
            lblmiscfixed.InnerText = GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhs"].ToString();
            lbltotals.InnerText = GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhs"].ToString();

            lbllandphase2.InnerText = GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhsphase2"].ToString();
            lblbuildingsphase2.InnerText = GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhsphase2"].ToString();
            lblcontingenciesphase2.InnerText = GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhsphase2"].ToString();
            lblauxilaryequipmentphase2.InnerText = GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhsphase2"].ToString();
            lblindigenousphase2.InnerText = GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhsphase2"].ToString();
            lblimportedphase2.InnerText = GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhsphase2"].ToString();
            lblworkcaptailphase2.InnerText = GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhsphase2"].ToString();
            lblpremlinaryphase2.InnerText = GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhsphase2"].ToString();
            lblmiscfixedphase2.InnerText = GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhsphase2"].ToString();
            lbltotalsphase2.InnerText = GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhsphase2"].ToString();


            lbllandphase3.InnerText = GDs.Tables[2].Rows[0]["Land_Project_Cost_Lakhsphase3"].ToString();
            lblbuildingsphase3.InnerText = GDs.Tables[2].Rows[0]["Buildings_Project_Cost_Lakhsphase3"].ToString();
            lblcontingenciesphase3.InnerText = GDs.Tables[2].Rows[0]["Contingencies_Project_Cost_Lakhsphase3"].ToString();
            lblauxilaryequipmentphase3.InnerText = GDs.Tables[2].Rows[0]["AuxiliaryEquipment_Project_Cost_Lakhsphase3"].ToString();
            lblindigenousphase3.InnerText = GDs.Tables[2].Rows[0]["Indigenous_Project_Cost_Lakhsphase3"].ToString();
            lblimportedphase3.InnerText = GDs.Tables[2].Rows[0]["Imported_Project_Cost_Lakhsphase3"].ToString();
            lblworkcaptailphase3.InnerText = GDs.Tables[2].Rows[0]["WorkCapitalMargin_Project_Cost_Lakhsphase3"].ToString();
            lblpremlinaryphase3.InnerText = GDs.Tables[2].Rows[0]["PreliminaryExp_Project_Cost_Lakhsphase3"].ToString();
            lblmiscfixedphase3.InnerText = GDs.Tables[2].Rows[0]["Misc_FixedAssets_Project_Cost_Lakhsphase3"].ToString();
            lbltotalsphase3.InnerText = GDs.Tables[2].Rows[0]["Total_Project_Cost_Lakhsphase3"].ToString();

            lblmaxnoworkers.InnerText = GDs.Tables[2].Rows[0]["Workers_factory_emp"].ToString();
            lblskilled.InnerText = GDs.Tables[2].Rows[0]["Skilled_Emp"].ToString();
            lblsupervisory.InnerText = GDs.Tables[2].Rows[0]["Supervisory_Emp"].ToString();
            lbltotalworkers.InnerText = GDs.Tables[2].Rows[0]["Total_Emp"].ToString();
            lblmanagerial.InnerText = GDs.Tables[2].Rows[0]["Managerial_Emp"].ToString();
            lblunskilled.InnerText = GDs.Tables[2].Rows[0]["Unskilled_Emp"].ToString();

            lblskilledphase2.InnerText = GDs.Tables[2].Rows[0]["Skilled_Empphase2"].ToString();
            lblsupervisoryphase2.InnerText = GDs.Tables[2].Rows[0]["Supervisory_Empphase2"].ToString();
            lbltotalworkersphase2.InnerText = GDs.Tables[2].Rows[0]["Total_Empphase2"].ToString();
            lblmanagerialphase2.InnerText = GDs.Tables[2].Rows[0]["Managerial_Empphase2"].ToString();
            lblunskilledphase2.InnerText = GDs.Tables[2].Rows[0]["Unskilled_Empphase2"].ToString();

            lblskilledphase3.InnerText = GDs.Tables[2].Rows[0]["Skilled_Empphase3"].ToString();
            lblsupervisoryphase3.InnerText = GDs.Tables[2].Rows[0]["Supervisory_Empphase3"].ToString();
            lbltotalworkersphase3.InnerText = GDs.Tables[2].Rows[0]["Total_Empphase3"].ToString();
            lblmanagerialphase3.InnerText = GDs.Tables[2].Rows[0]["Managerial_Empphase3"].ToString();
            lblunskilledphase3.InnerText = GDs.Tables[2].Rows[0]["Unskilled_Empphase3"].ToString();

            lbladmininistration.InnerText = GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequired"].ToString();
            lblroad.InnerText = GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequired"].ToString();
            lblplantfactory.InnerText = GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequired"].ToString();
            lblstorageandwarehousing.InnerText = GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequired"].ToString();
            lbltotal.InnerText = GDs.Tables[2].Rows[0]["Total_LandRequired"].ToString();
            lblopenarea.InnerText = GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequired"].ToString();

            lbladmininistrationphase2.InnerText = GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequiredphase2"].ToString();
            lblroadphase2.InnerText = GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequiredphase2"].ToString();
            lblplantfactoryphase2.InnerText = GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequiredphase2"].ToString();
            lblstorageandwarehousingphase2.InnerText = GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequiredphase2"].ToString();
            lbltotalphase2.InnerText = GDs.Tables[2].Rows[0]["Total_LandRequiredphase2"].ToString();
            lblopenareaphase2.InnerText = GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequiredphase2"].ToString();


            lbladmininistrationphase3.InnerText = GDs.Tables[2].Rows[0]["AdministrationBuildings_LandRequiredphase3"].ToString();
            lblroadphase3.InnerText = GDs.Tables[2].Rows[0]["RoadsWaterstorage_LandRequiredphase3"].ToString();
            lblplantfactoryphase3.InnerText = GDs.Tables[2].Rows[0]["PlantFactoryBuildings_LandRequiredphase3"].ToString();
            lblstorageandwarehousingphase3.InnerText = GDs.Tables[2].Rows[0]["StorageWarehousing_LandRequiredphase3"].ToString();
            lbltotalphase3.InnerText = GDs.Tables[2].Rows[0]["Total_LandRequiredphase3"].ToString();
            lblopenareaphase3.InnerText = GDs.Tables[2].Rows[0]["OpenAreasGreenBelt_LandRequiredphase3"].ToString();



            lblrequirepowersupply.InnerText = GDs.Tables[2].Rows[0]["Req_PowerSupply_KV"].ToString();
            lblppowerreqirement.InnerText = GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVA"].ToString();
            lblvoltagerating.InnerText = GDs.Tables[2].Rows[0]["VoltageRating_HT"].ToString();
            lblloadfactor.InnerText = GDs.Tables[2].Rows[0]["Loadfactor"].ToString();
            lblconnectedlaod.InnerText = GDs.Tables[2].Rows[0]["Connectedload_KW"].ToString();
            lblcontractedmax.InnerText = GDs.Tables[2].Rows[0]["ContractedMaxDem_KVA"].ToString();

            lblcontructionphasedate.InnerText = GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplys"].ToString();
            lblcommercialproductiondate.InnerText = GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupplys"].ToString();

            lblcontructionphasedatephase2.InnerText = GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplyphase2s"].ToString();
            lblcommercialproductiondatephase2.InnerText = GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupplyphase2s"].ToString();
            lblcontructionphasedatephase3.InnerText = GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplyphase3s"].ToString();
            lblcommercialproductiondatephase3.InnerText = GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupplyphase3s"].ToString();


            lblrequirepowersupplyphase2.InnerText = GDs.Tables[2].Rows[0]["Req_PowerSupply_KVphase2"].ToString();
            lblppowerreqirementphase2.InnerText = GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVAphase2"].ToString();
            lblvoltageratingphase2.InnerText = GDs.Tables[2].Rows[0]["VoltageRating_HTphase2"].ToString();
            lblloadfactorphase2.InnerText = GDs.Tables[2].Rows[0]["Loadfactorphase2"].ToString();
            lblconnectedlaodphase2.InnerText = GDs.Tables[2].Rows[0]["Connectedload_KWphase2"].ToString();
            lblcontractedmaxphase2.InnerText = GDs.Tables[2].Rows[0]["ContractedMaxDem_KVAphase2"].ToString();



            lblrequirepowersupplyphase3.InnerText = GDs.Tables[2].Rows[0]["Req_PowerSupply_KVphase3"].ToString();
            lblppowerreqirementphase3.InnerText = GDs.Tables[2].Rows[0]["TSTRANSCO_Energy_KVAphase3"].ToString();
            lblvoltageratingphase3.InnerText = GDs.Tables[2].Rows[0]["VoltageRating_HTphase3"].ToString();
            lblloadfactorphase3.InnerText = GDs.Tables[2].Rows[0]["Loadfactorphase3"].ToString();
            lblconnectedlaodphase3.InnerText = GDs.Tables[2].Rows[0]["Connectedload_KWphase3"].ToString();
            lblcontractedmaxphase3.InnerText = GDs.Tables[2].Rows[0]["ContractedMaxDem_KVAphase3"].ToString();



            lblcontructionphasedate.InnerText = GDs.Tables[2].Rows[0]["Dt_Construction_PowerSupplys"].ToString();
            lblcommercialproductiondate.InnerText = GDs.Tables[2].Rows[0]["Dt_Commercial_PowerSupplys"].ToString();


            lbltelephonecontact.InnerText = GDs.Tables[2].Rows[0]["TelephonoNo1_Cont_info"].ToString();
            lbltelephonecontact1.InnerText = GDs.Tables[2].Rows[0]["TelephonoNo2_Cont_info"].ToString();
            lblpincodecontact.InnerText = GDs.Tables[2].Rows[0]["Pincode_Cont_info"].ToString();
            lblcontactfaxno.InnerText = GDs.Tables[2].Rows[0]["FaxNo1_Cont_info"].ToString();



            lbldomestic1.InnerText = GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReq"].ToString();

            lblpermanentdomesticphase2.InnerText = GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReqphase2"].ToString();
            lblpermanentdomesticphase3.InnerText = GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReqphase3"].ToString();

            lbldomestic1phase2.InnerText = GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReqphase2"].ToString();
            lbldomestic1phase3.InnerText = GDs.Tables[2].Rows[0]["Domestic_Temp_WaterReqphase3"].ToString();

            lblpermanentdomestic.InnerText = GDs.Tables[2].Rows[0]["Domestic_Perm_WaterReq"].ToString();

            Industrialtempphase2.InnerText = GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase2"].ToString();
            Industrialtempphase3.InnerText = GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReqphase3"].ToString();
            Industrialtemp.InnerText = GDs.Tables[2].Rows[0]["Industrial_Temp_WaterReq"].ToString();
            lblpermindustrial.InnerText = GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReq"].ToString();
            lblpermindustrialphase2.InnerText = GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReqphase2"].ToString();
            lblpermindustrialphase3.InnerText = GDs.Tables[2].Rows[0]["Industrial_Perm_WaterReqphase3"].ToString();


            lblcontactfaxno1.InnerText = GDs.Tables[2].Rows[0]["FaxNo2_Cont_info"].ToString();


            lblpanno.InnerText = GDs.Tables[2].Rows[0]["PanNumber_Financial_Info"].ToString();
            lblanyotherinformaion.InnerText = GDs.Tables[2].Rows[0]["Anyother_Financial_Info"].ToString();
            lblassets.InnerText = GDs.Tables[2].Rows[0]["Assets_Financial_Inlakhs"].ToString();
            lblotherassets.InnerText = GDs.Tables[2].Rows[0]["OtherAssets_Financial_Inlakhs"].ToString();
            lblliabiliites.InnerText = GDs.Tables[2].Rows[0]["Liabilities_Financial_Inlakhs"].ToString();
            lbldetailsimmovable.InnerText = GDs.Tables[2].Rows[0]["Immovable_Assets_Land_Building_Financial"].ToString();
            lblproposedproject.InnerText = GDs.Tables[2].Rows[0]["ProposedProject_Financial"].ToString();
            txtprovidedetails.Text = GDs.Tables[2].Rows[0]["processtechnology"].ToString();
            rdIaLa_Lst.SelectedValue = GDs.Tables[2].Rows[0]["technicalcollabration"].ToString();

            if (rdIaLa_Lst.SelectedValue == "Y")
            {
                TextBox1.Enabled = true;
            }
            else
            {

                TextBox1.Enabled = false;
            }

            RadioButtonList1.SelectedValue = GDs.Tables[2].Rows[0]["highpressurevessel"].ToString();

            if (RadioButtonList1.SelectedValue == "Y")
            {
                txtvessel.Enabled = true;
            }
            else

            {
                txtvessel.Enabled = false;
            }
            txtvessel.Text = GDs.Tables[2].Rows[0]["noofvessels"].ToString();

            Span20.InnerText = GDs.Tables[2].Rows[0]["Effluentsphase1"].ToString();

            Span21.InnerText = GDs.Tables[2].Rows[0]["Effluentsphase2"].ToString();

            Span22.InnerText = GDs.Tables[2].Rows[0]["Effluentsphase3"].ToString();

            Span23.InnerText = GDs.Tables[2].Rows[0]["SoildWastephase1"].ToString();
            Span24.InnerText = GDs.Tables[2].Rows[0]["SoildWastephase2"].ToString();
            Span25.InnerText = GDs.Tables[2].Rows[0]["SoildWastephase3"].ToString();
            txtdesceff.Text = GDs.Tables[2].Rows[0]["Descriptioneffulents"].ToString();
            TextBox1.Text = GDs.Tables[2].Rows[0]["providedetails"].ToString();
            TextBox2.Text = GDs.Tables[2].Rows[0]["processtechnologysteam"].ToString();

            Span16.InnerText = GDs.Tables[2].Rows[0]["tstranscosupply"].ToString();
            Span18.InnerText = GDs.Tables[2].Rows[0]["owngeneration"].ToString();

            Span19.InnerText = GDs.Tables[2].Rows[0]["DGset"].ToString();


            StringBuilder tbody = new StringBuilder();
            //tbody.Clear();
            foreach (DataRow item in dt.Rows)
            {

                string filepathnew = item["linkview"].ToString();// LINKNEW .Tables[0].Rows[i][0].ToString();
                string encpassword = Gen.Encrypt(filepathnew, "SYSTIME");
                tbody.Append("<tr>");
                tbody.Append("<td class='col-md-8'>" + item["AttachmentDisplayTitle"].ToString() + "</td>");
                //tbody.Append("<td><a href='/" + item["FilePath"].ToString() + "' target='_blank'>View</a></td>");
                tbody.Append("<td><a href='CS.aspx?filepathnew=" + encpassword + "' target='_blank' style='color:#FF6600;'>View</a></td>");
                tbody.Append("</tr>");




            }
            if (GDs.Tables[9].Rows.Count > 0)
            {
                string filepathnew = GDs.Tables[9].Rows[0]["linkview"].ToString();// LINKNEW .Tables[0].Rows[i][0].ToString();
                string encpassword = Gen.Encrypt(filepathnew, "SYSTIME");
                ImagePreview.ImageUrl = "CS.aspx?filepathnew=" + encpassword;

            }


            tbodyAttachments.InnerHtml = tbody.ToString();
        }



        if (GDs.Tables[4].Rows.Count > 0)
        {

            Addlpromotordetails.DataSource = GDs.Tables[4];
            Addlpromotordetails.DataBind();


        }
        if (GDs.Tables[5].Rows.Count > 0)
        {

            GridView1.DataSource = GDs.Tables[5];
            GridView1.DataBind();




        }

        if (GDs.Tables[6].Rows.Count > 0)
        {

            rawmaterialconsumption.DataSource = GDs.Tables[6];
            rawmaterialconsumption.DataBind();




        }

        if (GDs.Tables[7].Rows.Count > 0)
        {

            GridView2.DataSource = GDs.Tables[7];
            GridView2.DataBind();




        }

    }





}







