using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Default2 : System.Web.UI.Page
{
    General clsGeneral = new General();
    DataSet ds = new DataSet();
    General Gen = new General();
    String ComplaintNo = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session.Count == 0)
            {
                // Response.Redirect("frmUserLogin.aspx");
                Response.Redirect("~/Index.aspx");
            }

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
            //commented by madhuri///
            //if (Session["Applid"].ToString().Trim() == "" || Session["Applid"].ToString().Trim() == "0")
            //{
            //    Response.Redirect("frmQuesstionniareReg.aspx");
            //}


            if (Session["Applid"].ToString() != "" || Session["Applid"].ToString() != "0")
            {
                DataSet dsnew = new DataSet();

                dsnew = clsGeneral.GetEnterPreneurdatabyQue(Session["Applid"].ToString());

                if (dsnew != null && dsnew.Tables[0].Rows.Count > 0)
                {
                    ComplaintNo = dsnew.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                    FillGrid();

                }
            }
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString[0].ToString() != "")
                {
                    ComplaintNo = Request.QueryString[0].ToString();
                    FillGrid();
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            // lbl.Text = ex.Message;
            //Failure.Visible = true;
        }
    }
    public void FillGrid()
    {
        try
        {

            ds = clsGeneral.GetCFEEnterprenuerDetailsNew(ComplaintNo);

            if (ds.Tables[0].Rows.Count != 0)
            {
                string TourismFlag = ds.Tables[0].Rows[0]["TourismFlag"].ToString().Trim();
                if (TourismFlag == "Y")
                {
                   // divHotel.Visible = true;
                    DIVlogo.Visible = false;
                    lblannexure.Visible = true;
                    LBLGO.Visible = true;
                    lblTEXT.Visible = true;
                //    string OwnedLease = ds.Tables[0].Rows[0]["OwnedLease"].ToString().Trim();
                //    if (OwnedLease == "O")
                //        lblTourismLandis.Text = "Owned";
                //    else if (OwnedLease == "L")
                //        lblTourismLandis.Text = "Leased";

                //    lblRooms.Text = ds.Tables[0].Rows[0]["NoofRooms"].ToString().Trim();
                //    lblOutlets.Text = ds.Tables[0].Rows[0]["Outlets"].ToString().Trim();
                //    lblBanquets.Text = ds.Tables[0].Rows[0]["Banquets"].ToString().Trim();
                //    string PoliceNOC = ds.Tables[0].Rows[0]["PoliceNOCFlag"].ToString().Trim();
                //    string PoliceParkingCond = ds.Tables[0].Rows[0]["ParkingCondition_Flag"].ToString().Trim();
                //    string PoliceStorageConstructionCond = ds.Tables[0].Rows[0]["StorageConstruction_Flag"].ToString().Trim();
                //    string excavationWorks = ds.Tables[0].Rows[0]["Excavation_Flag"].ToString().Trim();

                //    if (PoliceNOC == "Y")
                //    {
                //        lblPoliceNOC.Text = "YES";
                //        if (PoliceParkingCond == "Y")
                //        {
                //            lblPoliceParkingCond.Text = "YES";
                //        }
                //        else
                //        {
                //            lblPoliceParkingCond.Text = "NO";
                //        }
                //        if (PoliceStorageConstructionCond == "Y")
                //        {
                //            lblPoliceStorageConstructionCond.Text = "YES";
                //        }
                //        else
                //        {
                //            lblPoliceStorageConstructionCond.Text = "NO";
                //        }
                //        trPoliceParkingCond.Visible = true;
                //        trPoliceStorageConstructionCond.Visible = true;
                //    }
                //    else
                //    {
                //        lblPoliceNOC.Text = "NO";
                //    }
                //    if (excavationWorks == "Y")
                //    {
                //        lblexcavationWorks.Text = "YES";
                //    }
                //    else
                //    {
                //        lblexcavationWorks.Text = "NO";
                //    }

                }
                //else
                //{
                //    divHotel.Visible = false;
                //    trPoliceParkingCond.Visible = false;
                //    trPoliceStorageConstructionCond.Visible = false;
                //    DIVlogo.Visible = true;
                //    lblannexure.Visible = false;
                //    LBLGO.Visible = false;
                //    lblTEXT.Visible = false;
                //}

                string datecheck1 = Convert.ToDateTime(ds.Tables[0].Rows[0]["Created_dt"].ToString()).ToShortDateString();

                if (Convert.ToDateTime(datecheck1) >= Convert.ToDateTime("18-May-23"))
                {
                    lblipass.Text = "TG-iPASS COMMON APPLICATION FORM";
                }
                else 
                {
                    lblipass.Text = "TS-iPASS COMMON APPLICATION FORM";
                }


                string datecheck = Convert.ToDateTime(ds.Tables[0].Rows[0]["Created_dt"].ToString()).ToShortDateString();

                if (Convert.ToDateTime(datecheck) >= Convert.ToDateTime("05-Sep-20") && ds.Tables[0].Rows[0]["ProposalFor"].ToString() != "New")
                {
                    trTurnover1.Visible = true;
                }
                else if (Convert.ToDateTime(datecheck) >= Convert.ToDateTime("05-Sep-20") && ds.Tables[0].Rows[0]["ProposalFor"].ToString() == "New")
                {
                    trTurnover.Visible = true;
                }
                lblUidNo.Text = ds.Tables[0].Rows[0]["UID_No"].ToString();
                lblNameOfUndertaker.Text = ds.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();

                lblNameOfPromoter.Text = ds.Tables[0].Rows[0]["NameofthePromoter"].ToString();
                lblSonOf.Text = ds.Tables[0].Rows[0]["SoWo"].ToString();

                lblDoorNo.Text = ds.Tables[0].Rows[0]["Door_No"].ToString();
                lblStreetName.Text = ds.Tables[0].Rows[0]["StreetName"].ToString();
                if (ds.Tables[0].Rows[0]["villid"].ToString().Trim() != "")
                {
                    lblvillage.Text = ds.Tables[0].Rows[0]["VillName1"].ToString();
                    //lblvillage.Text = ds.Tables[0].Rows[0]["Village_Name"].ToString();
                }
                else
                {
                    lblvillage.Text = ds.Tables[0].Rows[0]["VillName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["distid"].ToString().Trim() != "")
                {

                    lblDistrict.Text = ds.Tables[0].Rows[0]["dname"].ToString();

                    //lblDistrict.Text = ds.Tables[0].Rows[0]["District_Name"].ToString(); --nk
                }
                else
                {
                    lblDistrict.Text = ds.Tables[0].Rows[0]["distname"].ToString();
                }

                lblMobileNo.Text = ds.Tables[0].Rows[0]["MobileNumber"].ToString();
                lblEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();

                lblState.Text = ds.Tables[0].Rows[0]["State_Name"].ToString();
                lblPincode.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
                if (ds.Tables[0].Rows[0]["mandid"].ToString().Trim() != "")
                {
                    //lblMandal.Text = ds.Tables[0].Rows[0]["Manda_lName"].ToString();
                    //MdlName
                    lblMandal.Text = ds.Tables[0].Rows[0]["MdlName"].ToString();

                }
                else
                {
                    lblMandal.Text = ds.Tables[0].Rows[0]["MName"].ToString();

                }

                lblTelephone.Text = ds.Tables[0].Rows[0]["TelephoneNumber"].ToString();
                if (ds.Tables[0].Rows[0]["ProposalFor"].ToString() != "" && ds.Tables[0].Rows[0]["ProposalFor"].ToString() != null)
                {
                    if (ds.Tables[0].Rows[0]["ProposalFor"].ToString() != "New")
                    {
                        trproporalexisting.Visible = true;
                        TRPROPOSALNEW.Visible = false;
                        if (ds.Tables[0].Rows[0]["annualTurnover_act"] != null)
                            lblturnOver.Text = ds.Tables[0].Rows[0]["annualTurnover_act"].ToString();

                        if (ds.Tables[0].Rows[0]["annualTurnover_Exp_act"] != null)
                            lblTurnoverExp.Text = ds.Tables[0].Rows[0]["annualTurnover_Exp_act"].ToString();

                        lblProposalFor.Text = ds.Tables[0].Rows[0]["ProposalFor"].ToString();
                        lblLandCost.Text = ds.Tables[0].Rows[0]["Land_Value"].ToString();
                        lblBuldingCost.Text = ds.Tables[0].Rows[0]["Building_value"].ToString();
                        lblPlantCost.Text = ds.Tables[0].Rows[0]["plant_value"].ToString();

                        if (lblLandCost.Text.Trim().TrimStart() == "")
                        {
                            lblLandCost.Text = "0";
                        }
                        if (lblBuldingCost.Text.Trim().TrimStart() == "")
                        {
                            lblBuldingCost.Text = "0";
                        }
                        if (lblPlantCost.Text.Trim().TrimStart() == "")
                        {
                            lblPlantCost.Text = "0";
                        }
                        lblTotExistingInvest.Text = Convert.ToString(Convert.ToDouble(lblLandCost.Text.Trim().TrimStart()) + Convert.ToDouble(lblBuldingCost.Text.Trim().TrimStart()) + Convert.ToDouble(lblPlantCost.Text.Trim().TrimStart()));

                        lblExpInvestLandValue.Text = ds.Tables[0].Rows[0]["Val_LandExpansion"].ToString();
                        lblExpInvestBuildingValue.Text = ds.Tables[0].Rows[0]["Val_BuildExpansion"].ToString();
                        lblExpInvestPlantlValue.Text = ds.Tables[0].Rows[0]["Val_PlantExpansion"].ToString();

                        if (lblExpInvestLandValue.Text.Trim().TrimStart() == "")
                        {
                            lblExpInvestLandValue.Text = "0";
                        }
                        if (lblExpInvestBuildingValue.Text.Trim().TrimStart() == "")
                        {
                            lblExpInvestBuildingValue.Text = "0";
                        }
                        if (lblExpInvestPlantlValue.Text.Trim().TrimStart() == "")
                        {
                            lblExpInvestPlantlValue.Text = "0";
                        }
                        lblTotalLandValue.Text = Convert.ToString(Convert.ToDouble(lblExpInvestLandValue.Text.Trim().TrimStart()) + Convert.ToDouble(lblLandCost.Text.Trim().TrimStart()));
                        lblTotalBuilding.Text = Convert.ToString(Convert.ToDouble(lblExpInvestBuildingValue.Text.Trim().TrimStart()) + Convert.ToDouble(lblBuldingCost.Text.Trim().TrimStart()));
                        lblToalPlantValue.Text = Convert.ToString(Convert.ToDouble(lblExpInvestPlantlValue.Text.Trim().TrimStart()) + Convert.ToDouble(lblPlantCost.Text.Trim().TrimStart()));

                        lblExpInvestTotalValue.Text = Convert.ToString(Convert.ToDouble(lblExpInvestLandValue.Text.Trim().TrimStart()) + Convert.ToDouble(lblExpInvestBuildingValue.Text.Trim().TrimStart()) + Convert.ToDouble(lblExpInvestPlantlValue.Text.Trim().TrimStart()));
                        lblTotalInvestment.Text = Convert.ToString(Convert.ToDouble(lblTotExistingInvest.Text.Trim().TrimStart()) + Convert.ToDouble(lblExpInvestTotalValue.Text.Trim().TrimStart()));
                    }
                    else
                    {
                        trproporalexisting.Visible = false;
                        lblNewTurnover.Text = "";
                        TRPROPOSALNEW.Visible = true;
                        if (ds.Tables[0].Rows[0]["annualTurnover_act"] != null)
                            lblNewTurnover.Text = ds.Tables[0].Rows[0]["annualTurnover_act"].ToString();

                        lblproposal.Text = ds.Tables[0].Rows[0]["ProposalFor"].ToString();
                        lblland.Text = ds.Tables[0].Rows[0]["Land_Value"].ToString();
                        lblbuilding.Text = ds.Tables[0].Rows[0]["Building_value"].ToString();
                        lblplant.Text = ds.Tables[0].Rows[0]["plant_value"].ToString();
                        lblturnOver.Text = ds.Tables[0].Rows[0]["plant_value"].ToString();

                        if (lblland.Text.Trim().TrimStart() == "")
                        {
                            lblland.Text = "0";
                        }
                        if (lblbuilding.Text.Trim().TrimStart() == "")
                        {
                            lblbuilding.Text = "0";
                        }
                        if (lblplant.Text.Trim().TrimStart() == "")
                        {
                            lblplant.Text = "0";
                        }
                        lbltotal.Text = Convert.ToString(Convert.ToDouble(lblland.Text.Trim().TrimStart()) + Convert.ToDouble(lblbuilding.Text.Trim().TrimStart()) + Convert.ToDouble(lblplant.Text.Trim().TrimStart()));

                    }
                }
                lblLineofActiivity.Text = ds.Tables[0].Rows[0]["LineofActivity_Name"].ToString(); //lavanya

                lblCastes.Text = ds.Tables[0].Rows[0]["Castes"].ToString();
                lbldiffabled.Text = ds.Tables[0].Rows[0]["diffabled"].ToString();
                LBLWOMENENT.Text = ds.Tables[0].Rows[0]["WOMEN_ENT"].ToString();
                LBLMINORITY.Text = ds.Tables[0].Rows[0]["IS_Minority"].ToString();
                LBLCATOFREG.Text = ds.Tables[0].Rows[0]["cat_of_reg"].ToString();
                LBLREGNO.Text = ds.Tables[0].Rows[0]["Reg_No"].ToString();

                LBLREGDATE.Text = ds.Tables[0].Rows[0]["Registration_date"].ToString();
                LBLTYPEOFFACTORY.Text = ds.Tables[0].Rows[0]["TYPE_OF_FACTORY"].ToString();


                lblMaleDirect.Text = ds.Tables[0].Rows[0]["DirectMale"].ToString();
                lblFemaleDirect.Text = ds.Tables[0].Rows[0]["DirectFemale"].ToString();
                lblMaleIndirect.Text = ds.Tables[0].Rows[0]["InDirectMale"].ToString();

                lblFemaleIndirect.Text = ds.Tables[0].Rows[0]["InDirectFemale"].ToString();
                lblMaleTotal.Text = ((int.Parse(ds.Tables[0].Rows[0]["DirectMale"].ToString())) + (int.Parse(ds.Tables[0].Rows[0]["InDirectMale"].ToString()))).ToString();
                lblFemaleTotal.Text = ((int.Parse(ds.Tables[0].Rows[0]["DirectFemale"].ToString())) + (int.Parse(ds.Tables[0].Rows[0]["InDirectFemale"].ToString()))).ToString();



                lblRegistration.Text = ds.Tables[0].Rows[0]["Reg_No"].ToString();
                //Convert.ToDateTime(ds.Tables[0].Rows[0]["Reg_Date"]).ToString("dd-MM-yyyy")
                if (ds.Tables[0].Rows[0]["Reg_Date"].ToString() != "")
                {
                    lblDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Reg_Date"]).ToString("dd-MM-yyyy");
                }

                if (ds.Tables[3].Rows.Count > 0)
                {
                    //lblProposedLocation.Text = ds.Tables[3].Rows[0]["ProposedLocationdata"].ToString();
                    lblBuildingApproval.Text = ds.Tables[3].Rows[0]["intBuildingApproval"].ToString();
                    lblbuildingheight_new.Text = ds.Tables[3].Rows[0]["Hight_Building"].ToString();
                    lblProposedLocation.Text = ds.Tables[3].Rows[0]["District_Name"].ToString();

                    lblSurveyNo.Text = ds.Tables[3].Rows[0]["SurveyNo"].ToString();

                    lblvillage0.Text = ds.Tables[3].Rows[0]["Village_Name"].ToString();

                    lblDistrict0.Text = ds.Tables[3].Rows[0]["District_Name"].ToString();
                    lblEmail0.Text = ds.Tables[3].Rows[0]["Land_Email"].ToString();
                    if (ds.Tables[3].Rows[0]["LocationFalls"].ToString() != "IALA (TSIIC)")
                    {
                        lblNameofGp.Text = ds.Tables[3].Rows[0]["Name_Gramapachayat"].ToString();
                    }
                    else
                    {
                        lblNameofGp.Text = ds.Tables[3].Rows[0]["LocationName"].ToString();
                    }

                    lblMandal0.Text = ds.Tables[3].Rows[0]["Manda_lName"].ToString();
                    lblPincode0.Text = ds.Tables[3].Rows[0]["Land_Pincode"].ToString();

                    lblTelephone0.Text = ds.Tables[3].Rows[0]["Land_TelephoneNumber"].ToString();
                    lblExtentofSightArea.Text = ds.Tables[3].Rows[0]["Land_TotExtent"].ToString();
                    lblProposedArea.Text = ds.Tables[3].Rows[0]["Land_ProposedArea"].ToString();

                    lblBultupArea.Text = ds.Tables[3].Rows[0]["Land_BuiltupArea"].ToString();
                    lbWidthToRoad.Text = ds.Tables[3].Rows[0]["Land_Existingwidth"].ToString();

                    lblTypeofRoad.Text = ds.Tables[3].Rows[0]["TypeofApprochid"].ToString();
                    lblLandComesUnder.Text = ds.Tables[3].Rows[0]["LocationFalls"].ToString();
                    lblCaseType.Text = ds.Tables[3].Rows[0]["IndustryProduct"].ToString();

                    lblCategoryOfIndustry.Text = ds.Tables[3].Rows[0]["Categoryid"].ToString();
                    LBLTYPEOFBUILDING.Text = ds.Tables[3].Rows[0]["Type_ofbuilding"].ToString();
                    LBLISLANPARTOF.Text = ds.Tables[3].Rows[0]["islandpart"].ToString();
                    if(ds.Tables[3].Rows[0]["landaspermasterplan"].ToString()=="8")
                    {
                        lbllanusemastrplantext.Text = "Land Use as per Master Plan Other";
                    }
                    
                    LBLLANDUSEMASTERPLAN.Text = ds.Tables[3].Rows[0]["landuse_masterplan"].ToString();

                    if (ds.Tables[3].Rows[0]["Affectedroadwinding"].ToString() == "Y")
                    {

                        LBLAFFECTEDROADWIDENING.Text = "Extend of affected area in sq.mts : " + Convert.ToString(ds.Tables[3].Rows[0]["Affectedroad_winding"]);
                    }
                    else
                    {
                        LBLAFFECTEDROADWIDENING.Text = "NO";
                    }
                    lbllandconversionto.Text = ds.Tables[3].Rows[0]["Land_conversionto"].ToString();
                }

                if (ds.Tables[4].Rows.Count > 0)
                {

                    lblMaxDemand.Text = ds.Tables[4].Rows[0]["Cont_Demand_Max"].ToString();
                    // lblConnectedLoad.Text = ((int.Parse(ds.Tables[4].Rows[0]["Connect_Load_A"].ToString())) + (int.Parse(ds.Tables[4].Rows[0]["Connect_Load_B"].ToString()))).ToString();
                    lblConnectedLoad.Text = ds.Tables[4].Rows[0]["Connect_Load_A"].ToString() + "/" + ds.Tables[4].Rows[0]["Connect_Load_B"].ToString().ToString();
                    lblTransformerCapacity.Text = ds.Tables[4].Rows[0]["Aggrigate_Capcity"].ToString();
                    lblRequiredVoltage.Text = ds.Tables[4].Rows[0]["Req_Voltage"].ToString();

                    lblOtherServiceExisting.Text = ds.Tables[4].Rows[0]["Otherservice"].ToString();
                    lblHoursPerDay.Text = ds.Tables[4].Rows[0]["Power_PerDay"].ToString();
                    lblHoursPerMonth.Text = ds.Tables[4].Rows[0]["Power_PerMonth"].ToString();
                    if (ds.Tables[4].Rows[0]["Trail_Production"].ToString().Trim() != "")
                    {
                        lblTrailProduction.Text = Convert.ToDateTime(ds.Tables[4].Rows[0]["Trail_Production"]).ToString("dd-MM-yyyy");
                    }
                    if (ds.Tables[4].Rows[0]["Portable_Date"].ToString().Trim() != "")
                    {
                        lblPowerSupplyPerDate.Text = Convert.ToDateTime(ds.Tables[4].Rows[0]["Portable_Date"]).ToString("dd-MM-yyyy");
                    }
                }
                if (ds.Tables[5].Rows.Count > 0)
                {
                    lblWaterSupplyDate.Text = ds.Tables[5].Rows[0]["Suply_From"].ToString();
                    if (lblWaterSupplyDate.Text.Trim() == "")
                    {
                        if (ds.Tables[5].Rows[0]["Water_reg_from1"].ToString().Trim() != "")
                        {
                            lblWaterSupplyDate.Text = ds.Tables[5].Rows[0]["Water_reg_from1"].ToString().Trim();
                        }
                        if (ds.Tables[5].Rows[0]["Water_reg_from2"].ToString().Trim() != "")
                        {
                            if (lblWaterSupplyDate.Text.Trim() != "")
                                lblWaterSupplyDate.Text = lblWaterSupplyDate.Text + ", " + ds.Tables[5].Rows[0]["Water_reg_from2"].ToString().Trim();
                            else
                                lblWaterSupplyDate.Text = ds.Tables[5].Rows[0]["Water_reg_from2"].ToString().Trim();
                        }
                        if (ds.Tables[5].Rows[0]["Water_reg_from3"].ToString().Trim() != "")
                        {
                            if (lblWaterSupplyDate.Text.Trim() != "")
                                lblWaterSupplyDate.Text = lblWaterSupplyDate.Text + ", " + ds.Tables[5].Rows[0]["Water_reg_from3"].ToString().Trim();
                            else
                                lblWaterSupplyDate.Text = ds.Tables[5].Rows[0]["Water_reg_from3"].ToString().Trim();

                            //sowjanya
                            trIrrigation1.Visible = true;
                            trIrrigation2.Visible = true;

                            lblIntakeCordinates.Text = ds.Tables[5].Rows[0]["Irrg_IntakePointCordnats"].ToString().Trim();
                            lblStorageCordinates.Text = ds.Tables[5].Rows[0]["Irrg_StoragePointCordnats"].ToString().Trim();
                            lblMinWaterReq.Text = ds.Tables[5].Rows[0]["Irrg_MinWaterReqPerAnnum"].ToString().Trim();
                            lblMaxWaterReq.Text = ds.Tables[5].Rows[0]["Irrg_MaxWaterReqPerAnnum"].ToString().Trim();
                            //sowjanya
                        }
                    }
                    // lblWaterRequirement.Text = ds.Tables[5].Rows[0]["Portable_Date"].ToString();
                    lblDrinkingwater.Text = ds.Tables[5].Rows[0]["Drink_Water"].ToString();
                    lblProcessingWater.Text = ds.Tables[5].Rows[0]["Water_Processing"].ToString();
                    lblSourseOfWater.Text = ds.Tables[5].Rows[0]["SourceWater"].ToString();

                    lblRequirementOfWaterInKLPerDay.Text = ds.Tables[5].Rows[0]["Requirement_Water"].ToString();
                    lblConsumptiveWater.Text = ds.Tables[5].Rows[0]["Quant_Water_Consumptive"].ToString();
                    lblNonConsumptiveWater.Text = ds.Tables[5].Rows[0]["Quant_Water_NonConsumptive"].ToString();
                }

                if (ds.Tables[16].Rows[0]["MISSIONBHAGFLAG"].ToString() == "Mission Bh" && ds.Tables[16].Rows[0]["MISSIONBHAGQTY"].ToString() != "" && lblSourseOfWater.Text == "")
                {
                    trMissionBhagiratha.Visible = true;
                    if (lblWaterSupplyDate.Text == "New Bore well"&&lblWaterSupplyDate.Text !=""&&lblWaterSupplyDate.Text !=null)
                    {
                        lblWaterSupplyDate.Text = "RWS - MISSION BHAGIRATHA & New Bore well ";
                        lblSourseOfWater.Text = lblWaterSupplyDate.Text;
                    }
                    else
                    {
                        lblWaterSupplyDate.Text = "RWS - MISSION BHAGIRATHA";
                        lblSourseOfWater.Text = lblWaterSupplyDate.Text;
                    }
                   // lblSourseOfWater.Text = "RWS - MISSION BHAGIRATHA"; lblWaterSupplyDate.Text = "RWS - MISSION BHAGIRATHA";
                    lblMissionQty.Text = ds.Tables[16].Rows[0]["MISSIONBHAGQTY"].ToString();  //added on 25.01.2020
                }

                if (ds.Tables[6].Rows.Count > 0)
                {
                    if (ds.Tables[6].Rows[0]["Downloadlink"].ToString() != null && ds.Tables[6].Rows[0]["Downloadlink"].ToString() != "")
                    {
                        pcbnew.Visible = true;
                        hylinkpcb.Visible = true;
                        hylinkpcb.NavigateUrl = ds.Tables[6].Rows[0]["Downloadlink"].ToString();
                    }
                    else
                    {
                        if (ds.Tables[6].Rows[0]["PCB_Water"].ToString() != null && ds.Tables[6].Rows[0]["PCB_Water"].ToString() != "")
                        {
                            pcbnew.Visible = false;
                            trpcb.Visible = true;
                            trpcb1.Visible = true;
                            trpcb2.Visible = true;
                            trpcb3.Visible = true;
                            lblProcess.Text = ds.Tables[6].Rows[0]["PCB_Water"].ToString();
                            lblWashings.Text = ds.Tables[6].Rows[0]["PCB_Washing"].ToString();
                            lblBoilerBlowDown.Text = ds.Tables[6].Rows[0]["PCB_BoilerBlowDown"].ToString();
                            lblCoolingTowerBleed.Text = ds.Tables[6].Rows[0]["PCB_CollingTower"].ToString();
                            lblDomestic.Text = ds.Tables[6].Rows[0]["PCB_Domastic"].ToString();
                            lblTotalWasteWater.Text = ds.Tables[6].Rows[0]["PCB_Total"].ToString();



                            lblCapacityOfDGSet.Text = ds.Tables[6].Rows[0]["PCB_AP_Capcity"].ToString();
                            lblFuelConsumptionPerDay.Text = ds.Tables[6].Rows[0]["PCB_FuelConsumption"].ToString();
                            lblFuelStorageDetails.Text = ds.Tables[6].Rows[0]["PCB_FuelStorge"].ToString();
                            lblStackHeight.Text = ds.Tables[6].Rows[0]["PCB_StackHight"].ToString();
                            lblAirPolutionControlEquipement.Text = ds.Tables[6].Rows[0]["PCB_AirPolution_Equipment"].ToString();
                            lblEmissionCharacteristtics.Text = ds.Tables[6].Rows[0]["PCB_EmiCharcter"].ToString();
                            lblQuwntityOfEmission.Text = ds.Tables[6].Rows[0]["PCB_Qunt_Emission"].ToString();
                            lblControlSystem.Text = ds.Tables[6].Rows[0]["PCB_ControlEqu"].ToString();
                            if (ds.Tables[6].Rows[0]["PCB_IsPrjRequired"].ToString() == "1")
                            {
                                lblGeneratorRequred.Text = "Yes";
                            }
                            else
                            {
                                lblGeneratorRequred.Text = "NO";
                            }
                        }
                    }
                }
                else
                {
                    trpcb.Visible = false;
                    trpcb1.Visible = false;
                    trpcb2.Visible = false;
                    trpcb3.Visible = false;
                }

                if (ds.Tables[8].Rows.Count > 0)
                {
                    trfire.Visible = true;
                    trfire1.Visible = true;
                    lblHeightOfBulding.Text = ds.Tables[8].Rows[0]["Hight_Building"].ToString();
                    lblHeightOfEachFloor.Text = ds.Tables[8].Rows[0]["Hight_EachFloor"].ToString();
                    lblInternaiStaircase.Text = ds.Tables[8].Rows[0]["Inter_Stairs"].ToString();
                    lblExternalStairCase.Text = ds.Tables[8].Rows[0]["Exernal_Stairs"].ToString();
                    lblWidthOfStairCase.Text = ds.Tables[8].Rows[0]["Width_Stairs"].ToString();
                    lblWidthOfStairCase15.Text = ds.Tables[8].Rows[0]["Width_Stairs1"].ToString();
                    lblNoOfExits.Text = ds.Tables[8].Rows[0]["NoofExits"].ToString();
                    lblWidthOfEachExists.Text = ds.Tables[8].Rows[0]["Width_eachExit"].ToString();
                    lblSpaceInEast.Text = ds.Tables[8].Rows[0]["Fire_East"].ToString();
                    lblSpaceInWest.Text = ds.Tables[8].Rows[0]["Fire_West"].ToString();
                    lblSpaceInNorth.Text = ds.Tables[8].Rows[0]["Fire_North"].ToString();
                    lblSpaceInSouth.Text = ds.Tables[8].Rows[0]["Fire_South"].ToString();
                    lblLevelOfGround.Text = ds.Tables[8].Rows[0]["Levelground"].ToString();
                    lblFireDetectionSystem.Text = ds.Tables[8].Rows[0]["Fire_Detection"].ToString();
                    lblFireAlarmSystem.Text = ds.Tables[8].Rows[0]["Fire_Alaram"].ToString();
                    lblSprinkler.Text = ds.Tables[8].Rows[0]["Sprinkler"].ToString();
                    lblFoam.Text = ds.Tables[8].Rows[0]["Foam"].ToString();
                    lblCO2.Text = ds.Tables[8].Rows[0]["CO2"].ToString();
                    lblDCP.Text = ds.Tables[8].Rows[0]["DCP"].ToString();
                    lblFireServiceInlet.Text = ds.Tables[8].Rows[0]["Fire_Service_Inlet"].ToString();
                    lblUnderGrounDtank.Text = ds.Tables[8].Rows[0]["Under_ground"].ToString();
                    lblNoOfCouryYard.Text = ds.Tables[8].Rows[0]["Court_yard_hydrants"].ToString();
                    lblFirePumpElectricity.Text = ds.Tables[8].Rows[0]["Fire_pumps_Electrical_15"].ToString();
                    lblDiesel.Text = ds.Tables[8].Rows[0]["Fire_pumps_Diesel"].ToString();
                    lblCO7.Text = ds.Tables[8].Rows[0]["Fire_pumps_Electrical_30"].ToString();
                    lblTrolly.Text = ds.Tables[8].Rows[0]["Trolley_45"].ToString();
                    lblFencing.Text = ds.Tables[8].Rows[0]["Fencing"].ToString();
                    lblSoakPit.Text = ds.Tables[8].Rows[0]["SoakPit"].ToString();
                    lbllighteningProtectin.Text = ds.Tables[8].Rows[0]["Lightning_Prot"].ToString();
                    lblControlRoom.Text = ds.Tables[8].Rows[0]["Cont_Room"].ToString();
                    lblHydralicPlatform.Text = ds.Tables[8].Rows[0]["Hydraulic_Platform"].ToString();
                }
                else
                {
                    trfire.Visible = false;
                    trfire1.Visible = false;
                }
                if (ds.Tables[9].Rows.Count > 0)
                {
                    trlabour.Visible = true;
                    lblMangerName.Text = ds.Tables[9].Rows[0]["Form1_1_Manager_Name"].ToString();
                    lblFatherName.Text = ds.Tables[9].Rows[0]["Form1_1_Manager_FatherName"].ToString();
                    lblAddressofManger.Text = ds.Tables[9].Rows[0]["MGRADDRESS"].ToString();
                    lblnatureofwork.Text = ds.Tables[9].Rows[0]["Form1_Nature_of_Business"].ToString();
                    lblEstimatedComm.Text = ds.Tables[9].Rows[0]["Form1_1_DateofCommencement"].ToString();
                    lblMaximumWorkers.Text = ds.Tables[9].Rows[0]["Form1_2_MaxWorkers"].ToString();
                    lblconstructiondate.Text = ds.Tables[9].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();
                    lblDesignation.Text = ds.Tables[9].Rows[0]["Form1_1_Manager_Designation"].ToString();

                    lblDirName.Text = ds.Tables[9].Rows[0]["Form1_4_Dir_FullName"].ToString();
                    lblDirDoorNo.Text = ds.Tables[9].Rows[0]["Form1_4_Dir_DoorNo"].ToString();
                    lblDirDistrict.Text = ds.Tables[9].Rows[0]["Form1_4_Dir_District"].ToString();
                    lblDirMandal.Text = ds.Tables[9].Rows[0]["Form1_4_Dir_Mandal"].ToString();
                    lblDirVillage.Text = ds.Tables[9].Rows[0]["Form1_4_Dir_Village"].ToString();

                    lblPriName.Text = ds.Tables[9].Rows[0]["Form1_Employer_Name"].ToString();
                    lblPriPGName.Text = ds.Tables[9].Rows[0]["Form1_Empolyer_FatherName"].ToString();
                    lblPriDesgn.Text = ds.Tables[9].Rows[0]["Form1_Employer_Designation"].ToString();

                    lblPriAge.Text = ds.Tables[9].Rows[0]["Form1_Employer_Age"].ToString();
                    lblPriMobileNo.Text = ds.Tables[9].Rows[0]["Form1_Employer_MobileNo"].ToString();
                    lblPriEmail.Text = ds.Tables[9].Rows[0]["Form1_Employer_EmailID"].ToString();
                    lblPriAddress.Text = ds.Tables[9].Rows[0]["EMPADDRESS"].ToString();
                    lblCategory.Text = ds.Tables[9].Rows[0]["Form1_1_Estb_Category"].ToString();

                }
                else
                {
                    trlabour.Visible = false;
                }
                if (ds.Tables[10].Rows.Count > 0)
                {
                    gvContractor.DataSource = ds.Tables[10];
                    gvContractor.DataBind();
                }

                if (ds.Tables[11].Rows.Count > 0)
                {
                    trforest.Visible = true;
                    lblNorth.Text = ds.Tables[11].Rows[0]["Forest_North"].ToString();
                    lblSouth.Text = ds.Tables[11].Rows[0]["Forest_South"].ToString();
                    lblEast.Text = ds.Tables[11].Rows[0]["Forest_East"].ToString();
                    lblWest.Text = ds.Tables[11].Rows[0]["Forest_West"].ToString();
                }
                if (ds.Tables[12].Rows.Count > 0)
                {
                    gvForestCertificate.DataSource = ds.Tables[12];
                    gvForestCertificate.DataBind();
                }
                // GridView2.DataSource = ds.Tables[1];
                // GridView2.DataBind();
                if (ds.Tables[1].Rows.Count > 0)
                {

                    //lblErrMsg.Text = "<font color=red><b>Record Not Found</b></font>";
                    GridView1.DataSource = ds.Tables[1];
                    GridView1.DataBind();

                }
                if (ds.Tables[2].Rows.Count > 0)
                {

                    //lblErrMsg.Text = "<font color=red><b>Record Not Found</b></font>";
                    GridView2.DataSource = ds.Tables[2];
                    GridView2.DataBind();

                }
                if (ds.Tables[7].Rows.Count > 0)
                {

                    //lblErrMsg.Text = "<font color=red><b>Record Not Found</b></font>";
                    GridView3.DataSource = ds.Tables[7];
                    GridView3.DataBind();

                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            // lbl.Text = ex.Message;
            //Failure.Visible = true;
        }
    }
}
