using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class UI_TSiPASS_TourismEventPrint : System.Web.UI.Page
{
    int TourismPerformanceLicenseID = 0;
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("../../frmUserLogin.aspx");
        }
        
        if (!IsPostBack)
        {
            if (Request.QueryString["TourismEventId"] != null && Request.QueryString["TourismEventId"].ToString() != "")
            {

                TourismPerformanceLicenseID = Convert.ToInt16(Request.QueryString["TourismEventId"]);
            }
            if (Request.QueryString["intApplid"] != null && Request.QueryString["intApplid"].ToString() != "")
            {
                TourismPerformanceLicenseID = Convert.ToInt16(Request.QueryString["intApplid"]);
            }
            if (TourismPerformanceLicenseID == 0)
            {
                int CreatedBy = Convert.ToInt32(Session["uid"]);
                DataSet dsTourismData = Gen.GetperformlicensebyTourismPerformanceLicenseID(CreatedBy);
                if (dsTourismData!=null && dsTourismData.Tables.Count > 0)
                {
                    if (dsTourismData.Tables[0].Rows.Count > 0)
                    {
                        Session["Applid"] = Convert.ToString(dsTourismData.Tables[0].Rows[0]["TourismPerformanceLicenseID"]);
                        TourismPerformanceLicenseID = Convert.ToInt32(dsTourismData.Tables[0].Rows[0]["TourismPerformanceLicenseID"]);
                    }
                }
            }
        }
        DataSet ds = Gen.GetperformlicensebyTourismPerformanceLicenseIDforprint(TourismPerformanceLicenseID);
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {


                Convert.ToString(ds.Tables[0].Rows[0]["TourismPerformanceLicenseID"]);
                lbl_typeofevent.Text = Convert.ToString(ds.Tables[0].Rows[0]["TypeofEvent"]);
                lbl_classevent.Text = Convert.ToString(ds.Tables[0].Rows[0]["ClassificationofEvent"]);
                lbl_nameofapplicant.Text = Convert.ToString(ds.Tables[0].Rows[0]["NameofTheApplicant"]);
                lbl_fathername.Text = Convert.ToString(ds.Tables[0].Rows[0]["FatherName"]);
                //lbl_aadhaarcard.Text = Convert.ToString(ds.Tables[0].Rows[0]["AadharNumber"]);
                lbl_pancard.Text = Convert.ToString(ds.Tables[0].Rows[0]["PanNumber"]);
                lbl_addressofapp.Text = Convert.ToString(ds.Tables[0].Rows[0]["AddressWithContact_total"]);
                lbl_nameofcompany.Text = Convert.ToString(ds.Tables[0].Rows[0]["NameAddEventManagement"]);
                lbl_gstno.Text = Convert.ToString(ds.Tables[0].Rows[0]["GSTNumber"]);
                lbl_namelocplac.Text = Convert.ToString(ds.Tables[0].Rows[0]["NameLocPerformance"]);
                lbl_structplan.Text = Convert.ToString(ds.Tables[0].Rows[0]["structureType"]);
                lbl_noofstalls.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoofStalls"]);
                lbl_sizesqmts.Text = Convert.ToString(ds.Tables[0].Rows[0]["Size"]);
                lbl_fabraction.Text = Convert.ToString(ds.Tables[0].Rows[0]["Fabrication"]);
                //lbl_clearspace.Text = Convert.ToString(ds.Tables[0].Rows[0]["clearspace"]);
                if (ds.Tables[0].Rows[0]["clearspace"].ToString() == "Y")
                {
                    lbl_clearspace.Text = "YES";
                }
                else
                {
                    lbl_clearspace.Text = "NO";
                }
                // lbl_tempstruct.Text = Convert.ToString(ds.Tables[0].Rows[0]["TemporaryStructure"]);
                if (ds.Tables[0].Rows[0]["TemporaryStructure"].ToString() == "Y")
                {
                    lbl_tempstruct.Text = "YES";

                }
                else
                {
                    lbl_tempstruct.Text = "NO";
                }
                lbl_workingtimings.Text = Convert.ToString(ds.Tables[0].Rows[0]["WorkingtimingsFrm"]) + "TO" + Convert.ToString(ds.Tables[0].Rows[0]["WorkingtimingsTo"]);
                lbl_pubilcpertimings.Text = Convert.ToString(ds.Tables[0].Rows[0]["Performancetimingsfrm"]) + "TO" + Convert.ToString(ds.Tables[0].Rows[0]["PerformancetimingsTo"]);
                lbl_startingdate.Text = Convert.ToString(ds.Tables[0].Rows[0]["StartDate"]);
                lbl_endingdate.Text = Convert.ToString(ds.Tables[0].Rows[0]["EndDate"]);
                lbl_expecstreaudience.Text = Convert.ToString(ds.Tables[0].Rows[0]["Expectedstrength"]);
                lbl_prodrelated.Text = Convert.ToString(ds.Tables[0].Rows[0]["ProductRelated"]);
                lbl_foodbeveages.Text = Convert.ToString(ds.Tables[0].Rows[0]["FoodBeverages"]);
                lbl_gamesenter.Text = Convert.ToString(ds.Tables[0].Rows[0]["GamesEntertainment"]);
                lbl_otherspec.Text = Convert.ToString(ds.Tables[0].Rows[0]["Others"]);
                //lbl_freeallinvat.Text = Convert.ToString(ds.Tables[0].Rows[0]["FreeEntryInvitation"]);
                if (ds.Tables[0].Rows[0]["FreeEntryInvitation"].ToString() == "Y")
                {
                    lbl_freeallinvat.Text = "YES";
                }
                else
                {
                    lbl_freeallinvat.Text = "NO";
                }
                // lbl_freefreewithoutinvations.Text = Convert.ToString(ds.Tables[0].Rows[0]["FreeEntryWithoutInvitation"]);
                if (ds.Tables[0].Rows[0]["FreeEntryWithoutInvitation"].ToString() == "Y")
                {
                    lbl_freefreewithoutinvations.Text = "YES";
                }
                else
                {
                    lbl_freefreewithoutinvations.Text = "NO";
                }
                // lbl_ticketshow.Text = Convert.ToString(ds.Tables[0].Rows[0]["TicketShow"]);
                if (ds.Tables[0].Rows[0]["TicketShow"].ToString() == "Y")
                {
                    lbl_ticketshow.Text = "YES";
                    lbl_adultticket.Text = Convert.ToString(ds.Tables[0].Rows[0]["AdultTicket"]);
                    lbl_childticket.Text = Convert.ToString(ds.Tables[0].Rows[0]["ChildrensTicket"]);
                }
                else
                {
                    lbl_ticketshow.Text = "NO";
                }

                lbl_totticketcounters.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoOfTicketCounters"]);
                lbl_parkingspace.Text = Convert.ToString(ds.Tables[0].Rows[0]["ParkingSpace"]);
                lbl_secarrange.Text = Convert.ToString(ds.Tables[0].Rows[0]["SecurityArrangements"]);
                lbl_pronofcctvs.Text = Convert.ToString(ds.Tables[0].Rows[0]["ProposedNoOfCCTV"]);
                lbl_pronoDFMDs.Text = Convert.ToString(ds.Tables[0].Rows[0]["ProposedNoOfDFMD"]);
                lbl_prosecguarvol.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoOfSecurityAndVolunteers"]);
                lbl_noofexistsplanwid.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoOfExitsWithWidth"]);
                lbl_nowidthgangways.Text = Convert.ToString(ds.Tables[0].Rows[0]["WidthOfGangways"]);
                lbl_noofco2typecylinders.Text = Convert.ToString(ds.Tables[0].Rows[0]["CO2Cylinders"]);
                lbl_nooffoamcylinders.Text = Convert.ToString(ds.Tables[0].Rows[0]["FoamCylinders"]);
                lbl_nofbuckets.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoOfBuckets"]);
                lbl_noofwaterstorage.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoOfWaterStorageTanks"]);
                lbl_noofsandbags.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoOfSandBags"]);
                //lbl_standbyfireservice.Text = Convert.ToString(ds.Tables[0].Rows[0]["StandbyFireService"]);
                if (ds.Tables[0].Rows[0]["StandbyFireService"].ToString() == "Y")
                {
                    lbl_standbyfireservice.Text = "YES";
                }
                else
                {
                    lbl_standbyfireservice.Text = "NO";
                }
                //lbl_firstaidfacil.Text = Convert.ToString(ds.Tables[0].Rows[0]["FirstAidFacility"]);
                if (ds.Tables[0].Rows[0]["FirstAidFacility"].ToString() == "Y")
                {
                    lbl_firstaidfacil.Text = "YES";
                }
                else
                {
                    lbl_firstaidfacil.Text = "NO";
                }
                    //  lbl_medicalattend.Text = Convert.ToString(ds.Tables[0].Rows[0]["MedicalAttender"]);
                    if (ds.Tables[0].Rows[0]["MedicalAttender"].ToString() == "Y")
                    {
                        lbl_medicalattend.Text = "YES";
                    }
                    else
                    {
                        lbl_medicalattend.Text = "NO";
                    }
                    // lbl_standbyambulance.Text = Convert.ToString(ds.Tables[0].Rows[0]["SatndbyAmbulanceFacility"]);
                    if (ds.Tables[0].Rows[0]["SatndbyAmbulanceFacility"].ToString() == "Y")
                    {
                        lbl_standbyambulance.Text = "YES";
                    }
                    else
                    {
                        lbl_standbyambulance.Text = "NO";
                    }
                    lbl_noofvolunt.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoOfSecurityVehicleChecking"]);
                    lbl_yesdetails.Text = Convert.ToString(ds.Tables[0].Rows[0]["TicketShowDetails"]);
                    lbl_locationarea.Text = Convert.ToString(ds.Tables[0].Rows[0]["Location_Width"]);
                    lbl_eventmanagementcompaddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["EventManagement_Address_total"]);
                    if (ds.Tables[0].Rows[0]["VIP_Visited"].ToString() == "Y")
                    {
                        lbl_anyvip.Text = "YES";
                        lbl_vipname.Text = Convert.ToString(ds.Tables[0].Rows[0]["VIP_Visited_Name"]);

                    }
                    else
                    {
                        lbl_anyvip.Text = "NO";
                    }
                    if (ds.Tables[0].Rows[0]["Foreigner_Expected"].ToString() == "Y")
                    {
                        lbl_anyforeigner.Text = "YES";
                        lbl_foreignername.Text = Convert.ToString(ds.Tables[0].Rows[0]["Foreigner_Expected_Remarks"]);

                    }
                    else
                    {
                        lbl_anyforeigner.Text = "NO";
                    }
                    lbl_exitswidth.Text = Convert.ToString(ds.Tables[0].Rows[0]["Exits_Width"]);
                    lbl_noofgateways.Text = Convert.ToString(ds.Tables[0].Rows[0]["NOofGangways"]);
                    lbl_policenoc.Text = Convert.ToString(ds.Tables[0].Rows[0]["Police_NOC"]);
                    if(ds.Tables[0].Rows[0]["Police_NOC"].ToString()=="Y")
                    {
                    lbl_policenoc.Text = "YES";
                    }
                    else
                    {
                    lbl_policenoc.Text = "NO";
                    }

                    //lbl_totalplanedstalls
                    //    lbl_duartion

                    Convert.ToString(ds.Tables[0].Rows[0]["UID_no"]);
                    Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                    Convert.ToString(ds.Tables[0].Rows[0]["MobileNumber"]);

                    Convert.ToString(ds.Tables[0].Rows[0]["App_Status"]);
                    Convert.ToString(ds.Tables[0].Rows[0]["PaymentDate"]);
                    Convert.ToString(ds.Tables[0].Rows[0]["Mandal"]);
                    Convert.ToString(ds.Tables[0].Rows[0]["Taluk"]);
                    Convert.ToString(ds.Tables[0].Rows[0]["District"]);
                    Convert.ToString(ds.Tables[0].Rows[0]["CreatedDate"]);
                    Convert.ToString(ds.Tables[0].Rows[0]["CreatedBy"]);

                }
            }
        }
    }
