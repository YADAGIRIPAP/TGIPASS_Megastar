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
        if (Session.Count < 1)
        {
            Response.Redirect("~/TSHome.aspx");
        }
        //DataSet dscheck = new DataSet();
        //dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
        //if (dscheck.Tables[0].Rows.Count > 0)
        //{
        //    Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
        //}
        //else
        //{
        //    Session["Applid"] = "0";
        //}

        //if (Session["Applid"].ToString().Trim() == "" || Session["Applid"].ToString().Trim() == "0")
        //    {
        //        Response.Redirect("frmQuesstionniareReg.aspx");
        //    }


        //if (Session["Applid"].ToString() != "" || Session["Applid"].ToString() != "0")
        //{
        //    DataSet dsnew = new DataSet();

        //    dsnew = clsGeneral.GetCFEEnterprenuerDetailsNew(ComplaintNo);

        //    if ( dsnew !=null &&   dsnew.Tables[0].Rows.Count > 0)
        //    {
        //        ComplaintNo = dsnew.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
        //        FillGrid();

        //    }
        //}
        if (Request.QueryString.Count > 0)
        {
            if (Request.QueryString[0].ToString() != "")
            {
                ComplaintNo = Request.QueryString[0].ToString();
                FillGrid();
            }
        }
    }
    public void FillGrid()
    {

        ds = clsGeneral.GetCFEEnterprenuerDetailsNew(Request.QueryString[0].ToString().Trim());

        if (ds.Tables[0].Rows.Count != 0)
        {



            lblUidNo.Text = ds.Tables[0].Rows[0]["UID_No"].ToString();
            lblNameOfUndertaker.Text = ds.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();

            lblNameOfPromoter.Text = ds.Tables[0].Rows[0]["NameofthePromoter"].ToString();
            lblSonOf.Text = ds.Tables[0].Rows[0]["SoWo"].ToString();
            lblCastes.Text = ds.Tables[0].Rows[0]["Castes"].ToString();
            lblDoorNo.Text = ds.Tables[0].Rows[0]["Door_No"].ToString();
            lblStreetName.Text = ds.Tables[0].Rows[0]["StreetName"].ToString();
            if (ds.Tables[0].Rows[0]["villid"].ToString().Trim() != "")
            {
                lblvillage.Text = ds.Tables[0].Rows[0]["VillName1"].ToString();
            }
            else
            {
                lblvillage.Text = ds.Tables[0].Rows[0]["VillName"].ToString();
            }
            if (ds.Tables[0].Rows[0]["distid"].ToString().Trim() != "")
            {
                lblDistrict.Text = ds.Tables[0].Rows[0]["dname"].ToString();
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
                lblMandal.Text = ds.Tables[0].Rows[0]["MdlName"].ToString();
            }
            else
            {
                lblMandal.Text = ds.Tables[0].Rows[0]["MName"].ToString();

            }

            lblTelephone.Text = ds.Tables[0].Rows[0]["TelephoneNumber"].ToString();
            //lblProposalFor.Text = ds.Tables[0].Rows[0]["ProposalFor"].ToString();
            //lblLandCost.Text = ds.Tables[0].Rows[0]["Land_Value"].ToString();
            //lblBuldingCost.Text = ds.Tables[0].Rows[0]["Building_value"].ToString();
            //lblPlantCost.Text = ds.Tables[0].Rows[0]["plant_value"].ToString();

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

                lblBuildingApproval.Text = ds.Tables[3].Rows[0]["intBuildingApproval"].ToString();

                //lblProposedLocation.Text = ds.Tables[3].Rows[0]["LocationName"].ToString();
                lblProposedLocation.Text = ds.Tables[3].Rows[0]["District_Name"].ToString();

                lblSurveyNo.Text = ds.Tables[3].Rows[0]["SurveyNo"].ToString();

                lblvillage0.Text = ds.Tables[3].Rows[0]["Village_Name"].ToString();

                lblDistrict0.Text = ds.Tables[3].Rows[0]["District_Name"].ToString();
                lblEmail0.Text = ds.Tables[3].Rows[0]["Land_Email"].ToString();
                lblNameofGp.Text = ds.Tables[3].Rows[0]["Name_Gramapachayat"].ToString();

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
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                lblMaxDemand.Text = ds.Tables[4].Rows[0]["Cont_Demand_Max"].ToString();
                //lblConnectedLoad.Text = ((int.Parse(ds.Tables[4].Rows[0]["Connect_Load_A"].ToString())) + (int.Parse(ds.Tables[4].Rows[0]["Connect_Load_B"].ToString()))).ToString();
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
                divPower.Visible = true;
                divPower1.Visible = true;
                divPower2.Visible = true;
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                lblWaterSupplyDate.Text = ds.Tables[5].Rows[0]["Suply_From"].ToString();
                // lblWaterRequirement.Text = ds.Tables[5].Rows[0]["Portable_Date"].ToString();
                lblDrinkingwater.Text = ds.Tables[5].Rows[0]["Drink_Water"].ToString();
                lblProcessingWater.Text = ds.Tables[5].Rows[0]["Water_Processing"].ToString();
                lblSourseOfWater.Text = ds.Tables[5].Rows[0]["SourceWater"].ToString();
                lblRequirementOfWaterInKLPerDay.Text = ds.Tables[5].Rows[0]["Requirement_Water"].ToString();
                lblConsumptiveWater.Text = ds.Tables[5].Rows[0]["Quant_Water_Consumptive"].ToString();
                lblNonConsumptiveWater.Text = ds.Tables[5].Rows[0]["Quant_Water_NonConsumptive"].ToString();
                divWater.Visible = true;
            }

            if (ds.Tables[6].Rows.Count > 0)
            {
                if (ds.Tables[6].Rows[0]["Downloadlink"].ToString() != null && ds.Tables[6].Rows[0]["Downloadlink"].ToString() != "")
                {
                    pcbnew.Visible = true;
                    hylinkpcb.Visible = true;
                    hylinkpcb.NavigateUrl = ds.Tables[6].Rows[0]["Downloadlink"].ToString();
                    divPCBwater.Visible = false;
                    divPCBAIR.Visible = false;
                    divPCBAIR1.Visible = false;
                    divPCBGEN.Visible = false;
                }
                else
                {
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
                    lblGeneratorRequred.Text = ds.Tables[6].Rows[0]["PCB_IsPrjRequired"].ToString();

                    divPCBwater.Visible = true;
                    divPCBAIR.Visible = true;
                    divPCBAIR1.Visible = true;
                    divPCBGEN.Visible = true;
                }
            }

            if (ds.Tables[8].Rows.Count > 0)
            {
                lblHeightOfBulding.Text = ds.Tables[8].Rows[0]["Hight_Building"].ToString();
                lblHeightOfEachFloor.Text = ds.Tables[8].Rows[0]["Hight_EachFloor"].ToString();
                lblInternaiStaircase.Text = ds.Tables[8].Rows[0]["Inter_Stairs"].ToString();
                lblExternalStairCase.Text = ds.Tables[8].Rows[0]["Exernal_Stairs"].ToString();
                lblWidthOfStairCase.Text = ds.Tables[8].Rows[0]["Width_Stairs"].ToString();
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
                divFire.Visible = true;
                divTransformer.Visible = true;

            }





            // GridView2.DataSource = ds.Tables[1];
            // GridView2.DataBind();
            if (ds.Tables[1].Rows.Count > 0)
            {

                //lblErrMsg.Text = "<font color=red><b>Record Not Found</b></font>";
                GridView1.DataSource = ds.Tables[1];
                GridView1.DataBind();
                divLine.Visible = true;

            }
            if (ds.Tables[2].Rows.Count > 0)
            {

                //lblErrMsg.Text = "<font color=red><b>Record Not Found</b></font>";
                GridView2.DataSource = ds.Tables[2];
                GridView2.DataBind();
                divRAW.Visible = true;

            }
            if (ds.Tables[7].Rows.Count > 0)
            {

                //lblErrMsg.Text = "<font color=red><b>Record Not Found</b></font>";
                GridView3.DataSource = ds.Tables[7];
                GridView3.DataBind();
                divSolid.Visible = true;
            }
            if (ds.Tables[9].Rows.Count > 0)
            {

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
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    if (e.Row.Cells[4].Text == "NotAvailablenow" || e.Row.Cells[4].Text == "")
        //        GridView1.Columns[4].Visible = false;
        //    else
        //        GridView1.Columns[4].Visible = true;
        //}

    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    if (e.Row.Cells[4].Text == "NotAvailablenow" || e.Row.Cells[4].Text == "")
        //        GridView2.Columns[4].Visible = false;
        //    else
        //        GridView2.Columns[4].Visible = true;
        //}

    }
}
