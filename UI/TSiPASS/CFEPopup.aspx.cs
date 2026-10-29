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
            //if (Session.Count <= 0)
            //{
            //    Response.Redirect("../../Index.aspx");
            //}
            DataSet dscheck = new DataSet();
            dscheck = Gen.GetShowQuestionariesbyUIDPOP(Request.QueryString[0].ToString().Trim());


            if (dscheck.Tables[0].Rows.Count > 0)
            {
                Response.Redirect("ApplicationTrakerDetailed.aspx?ID=" + dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim());
                Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
            }
            else
            {
                Session["Applid"] = "0";
            }

            if (Session["Applid"].ToString().Trim() == "" || Session["Applid"].ToString().Trim() == "0")
            {
                //Response.Redirect("frmQuesstionniareReg.aspx");
            }


            if (Session["Applid"].ToString() != "" || Session["Applid"].ToString() != "0")
            {
                DataSet dsnew = new DataSet();

                dsnew = clsGeneral.GetEnterPreneurdatabyQue(Session["Applid"].ToString());

                if (dsnew != null && dsnew.Tables[0].Rows.Count > 0)
                {
                    ComplaintNo = dsnew.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                    FillGrid();

                    DataSet ds = new DataSet();
                    ds = Gen.GetQuestionereisPopup(Session["Applid"].ToString());
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdDetails.DataSource = ds.Tables[1];
                        grdDetails.DataBind();
                    }
                }
            }
            //if (Request.QueryString.Count > 0)
            //{
            //    if (Request.QueryString[0].ToString() != "")
            //    {
            //        ComplaintNo = Request.QueryString[0].ToString();
            //        FillGrid();
            //    }
            //}
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            // lbl.Text = ex.Message;
            // Failure.Visible = true;
        }
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (e.Row.Cells[5].Text == "Red")
                {
                    e.Row.Cells[5].BackColor = System.Drawing.Color.Red;
                    e.Row.Cells[5].Text = "";
                }
                else if (e.Row.Cells[5].Text == "Green")
                {
                    e.Row.Cells[5].BackColor = System.Drawing.Color.Green;
                    e.Row.Cells[5].Text = "";
                }
                else
                {
                    e.Row.Cells[5].BackColor = System.Drawing.Color.Green;
                    e.Row.Cells[5].Text = "";
                }

                if (e.Row.Cells[7].Text == "Red")
                {
                    e.Row.Cells[7].BackColor = System.Drawing.Color.Red;
                    e.Row.Cells[7].Text = "";
                }
                else if (e.Row.Cells[7].Text == "Green")
                {
                    e.Row.Cells[7].BackColor = System.Drawing.Color.Green;
                    e.Row.Cells[7].Text = "";
                }
                else
                {
                    e.Row.Cells[7].BackColor = System.Drawing.Color.White;
                    e.Row.Cells[7].Text = "";
                }

                if (e.Row.Cells[8].Text == "Red")
                {
                    e.Row.Cells[8].BackColor = System.Drawing.Color.Red;
                    e.Row.Cells[8].Text = "";
                }
                else if (e.Row.Cells[8].Text == "Green")
                {
                    e.Row.Cells[8].BackColor = System.Drawing.Color.Green;
                    e.Row.Cells[8].Text = "";
                }
                else
                {
                    //   e.Row.Cells[6].BackColor = System.Drawing.Color.Green;
                    e.Row.Cells[8].Text = "";
                }

                if (e.Row.Cells[9].Text == "Pre-Scrutiny Stage" || e.Row.Cells[9].Text == "Approval Stage")
                {
                    e.Row.Cells[9].BackColor = System.Drawing.Color.Red;
                }
                else
                {
                    //   e.Row.Cells[6].BackColor = System.Drawing.Color.Green;
                    e.Row.Cells[9].Text = "";
                }



                if (e.Row.Cells[3].Text == "Yes" || e.Row.Cells[4].Text == "No")
                {

                    e.Row.Cells[5].BackColor = System.Drawing.Color.White;
                    e.Row.Cells[5].Text = "";
                    e.Row.Cells[6].BackColor = System.Drawing.Color.White;
                    e.Row.Cells[6].Text = "";

                    // e.Row.Cells[3].BackColor = System.Drawing.Color.Navy;

                    if (e.Row.Cells[3].Text == "Yes")
                    {
                        e.Row.Cells[8].BackColor = System.Drawing.Color.Green;
                        e.Row.Cells[8].Text = "";

                        e.Row.Cells[3].BackColor = System.Drawing.Color.Orange;
                        e.Row.Cells[3].Text = "";
                    }
                    else
                    {

                        if (e.Row.Cells[4].Text == "No")
                        {
                            //e.Row.Cells[8].BackColor = System.Drawing.Color.White;
                            //e.Row.Cells[8].Text = "";
                            //e.Row.Cells[7].BackColor = System.Drawing.Color.White;
                            //e.Row.Cells[7].Text = "";
                        }
                    }

                }

                //   e.Row.Cells[3].Text = "";

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblmsg0.Text = ex.Message;
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




                lblUidNo.Text = ds.Tables[0].Rows[0]["UID_No"].ToString();
                lblNameOfUndertaker.Text = ds.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();

                lblNameOfPromoter.Text = ds.Tables[0].Rows[0]["NameofthePromoter"].ToString();
                lblSonOf.Text = ds.Tables[0].Rows[0]["SoWo"].ToString();

                //lblDoorNo.Text = ds.Tables[0].Rows[0]["Door_No"].ToString();
                //lblStreetName.Text = ds.Tables[0].Rows[0]["StreetName"].ToString();
                //if (ds.Tables[0].Rows[0]["villid"].ToString().Trim()!= "")
                //{
                //    lblvillage.Text = ds.Tables[0].Rows[0]["Village_Name"].ToString();
                //}
                //else
                //{
                //    lblvillage.Text = ds.Tables[0].Rows[0]["VillName"].ToString();
                //}
                if (ds.Tables[0].Rows[0]["distid"].ToString().Trim() != "")
                {
                    lblDistrict0.Text = ds.Tables[0].Rows[0]["Addressofunit"].ToString();
                }
                else
                {
                    lblDistrict0.Text = ds.Tables[0].Rows[0]["distname"].ToString();
                }

                lblMobileNo.Text = ds.Tables[0].Rows[0]["MobileNumber"].ToString();
                lblEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();

                //lblState.Text = ds.Tables[0].Rows[0]["State_Name"].ToString();
                //lblPincode.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
                //if (ds.Tables[0].Rows[0]["mandid"].ToString().Trim()!= "")
                //{
                //    lblMandal.Text = ds.Tables[0].Rows[0]["Manda_lName"].ToString();
                //}
                //else
                //{
                //    lblMandal.Text = ds.Tables[0].Rows[0]["MName"].ToString();

                //}

                lblTelephone.Text = ds.Tables[0].Rows[0]["TelephoneNumber"].ToString();
                //lblProposalFor.Text = ds.Tables[0].Rows[0]["ProposalFor"].ToString();
                //lblLandCost.Text = ds.Tables[0].Rows[0]["Land_Value"].ToString();
                //lblBuldingCost.Text = ds.Tables[0].Rows[0]["Building_value"].ToString();
                //lblPlantCost.Text = ds.Tables[0].Rows[0]["plant_value"].ToString();



                //lblMaleDirect.Text = ds.Tables[0].Rows[0]["DirectMale"].ToString();
                //lblFemaleDirect.Text = ds.Tables[0].Rows[0]["DirectFemale"].ToString();
                //lblMaleIndirect.Text = ds.Tables[0].Rows[0]["InDirectMale"].ToString();

                //lblFemaleIndirect.Text = ds.Tables[0].Rows[0]["InDirectFemale"].ToString();
                //lblMaleTotal.Text = ((int.Parse(ds.Tables[0].Rows[0]["DirectMale"].ToString())) + (int.Parse(ds.Tables[0].Rows[0]["InDirectMale"].ToString()))).ToString();
                //lblFemaleTotal.Text = ((int.Parse(ds.Tables[0].Rows[0]["DirectFemale"].ToString())) + (int.Parse(ds.Tables[0].Rows[0]["InDirectFemale"].ToString()))).ToString();



                //lblRegistration.Text = ds.Tables[0].Rows[0]["Reg_No"].ToString();
                //Convert.ToDateTime(ds.Tables[0].Rows[0]["Reg_Date"]).ToString("dd-MM-yyyy")
                //if(ds.Tables[0].Rows[0]["Reg_Date"].ToString()!="")
                //{
                ////lblDate.Text =    Convert.ToDateTime(ds.Tables[0].Rows[0]["Reg_Date"]).ToString("dd-MM-yyyy");
                //}

                //if (ds.Tables[3].Rows.Count > 0)
                //{
                //lblProposedLocation.Text = ds.Tables[3].Rows[0]["ProposedLocationdata"].ToString();

                //lblSurveyNo.Text = ds.Tables[3].Rows[0]["SurveyNo"].ToString();

                //lblvillage0.Text = ds.Tables[3].Rows[0]["Village_Name"].ToString();

                //lblDistrict0.Text = ds.Tables[3].Rows[0]["District_Name"].ToString();
                //lblEmail0.Text = ds.Tables[3].Rows[0]["Land_Email"].ToString();
                //lblNameofGp.Text = ds.Tables[3].Rows[0]["Name_Gramapachayat"].ToString();

                //lblMandal0.Text = ds.Tables[3].Rows[0]["Manda_lName"].ToString();
                //lblPincode0.Text = ds.Tables[3].Rows[0]["Land_Pincode"].ToString();

                //lblTelephone0.Text = ds.Tables[3].Rows[0]["Land_TelephoneNumber"].ToString();
                //lblExtentofSightArea.Text = ds.Tables[3].Rows[0]["Land_TotExtent"].ToString();
                //lblProposedArea.Text = ds.Tables[3].Rows[0]["Land_ProposedArea"].ToString();

                //lblBultupArea.Text = ds.Tables[3].Rows[0]["Land_BuiltupArea"].ToString();
                //lbWidthToRoad.Text = ds.Tables[3].Rows[0]["Land_Existingwidth"].ToString();

                //lblTypeofRoad.Text = ds.Tables[3].Rows[0]["TypeofApprochid"].ToString();
                //lblLandComesUnder.Text = ds.Tables[3].Rows[0]["LocationFalls"].ToString();
                //lblCaseType.Text = ds.Tables[3].Rows[0]["IndustryProduct"].ToString();
                //lblCategoryOfIndustry.Text = ds.Tables[3].Rows[0]["Categoryid"].ToString();
                //}

                //if (ds.Tables[4].Rows.Count > 0)
                //{

                //    //lblMaxDemand.Text = ds.Tables[4].Rows[0]["Cont_Demand_Max"].ToString();
                //    //lblConnectedLoad.Text = ((int.Parse(ds.Tables[4].Rows[0]["Connect_Load_A"].ToString())) + (int.Parse(ds.Tables[4].Rows[0]["Connect_Load_B"].ToString()))).ToString();
                //    //lblTransformerCapacity.Text = ds.Tables[4].Rows[0]["Aggrigate_Capcity"].ToString();
                //    //lblRequiredVoltage.Text = ds.Tables[4].Rows[0]["Req_Voltage"].ToString();

                //    //lblOtherServiceExisting.Text = ds.Tables[4].Rows[0]["Otherservice"].ToString();
                //    //lblHoursPerDay.Text = ds.Tables[4].Rows[0]["Power_PerDay"].ToString();
                //    //lblHoursPerMonth.Text = ds.Tables[4].Rows[0]["Power_PerMonth"].ToString();
                //    //if (ds.Tables[4].Rows[0]["Trail_Production"].ToString().Trim() != "")
                //    //{
                //    //    lblTrailProduction.Text = Convert.ToDateTime(ds.Tables[4].Rows[0]["Trail_Production"]).ToString("dd-MM-yyyy");
                //    //}
                //    //if (ds.Tables[4].Rows[0]["Portable_Date"].ToString().Trim() != "")
                //    //{
                //    //    lblPowerSupplyPerDate.Text = Convert.ToDateTime(ds.Tables[4].Rows[0]["Portable_Date"]).ToString("dd-MM-yyyy");
                //    }
                //}
                //if (ds.Tables[5].Rows.Count > 0)
                //{
                //    //lblWaterSupplyDate.Text = ds.Tables[5].Rows[0]["Suply_From"].ToString();
                //    //// lblWaterRequirement.Text = ds.Tables[5].Rows[0]["Portable_Date"].ToString();
                //    //lblDrinkingwater.Text = ds.Tables[5].Rows[0]["Drink_Water"].ToString();
                //    //lblProcessingWater.Text = ds.Tables[5].Rows[0]["Water_Processing"].ToString();
                //    //lblSourseOfWater.Text = ds.Tables[5].Rows[0]["SourceWater"].ToString();
                //    //lblRequirementOfWaterInKLPerDay.Text = ds.Tables[5].Rows[0]["Requirement_Water"].ToString();
                //    //lblConsumptiveWater.Text = ds.Tables[5].Rows[0]["Quant_Water_Consumptive"].ToString();
                //    //lblNonConsumptiveWater.Text = ds.Tables[5].Rows[0]["Quant_Water_NonConsumptive"].ToString();
                //}

                //if (ds.Tables[6].Rows.Count > 0)
                //{
                //    lblProcess.Text = ds.Tables[6].Rows[0]["PCB_Water"].ToString();
                //    lblWashings.Text = ds.Tables[6].Rows[0]["PCB_Washing"].ToString();
                //    lblBoilerBlowDown.Text = ds.Tables[6].Rows[0]["PCB_BoilerBlowDown"].ToString();
                //    lblCoolingTowerBleed.Text = ds.Tables[6].Rows[0]["PCB_CollingTower"].ToString();
                //    lblDomestic.Text = ds.Tables[6].Rows[0]["PCB_Domastic"].ToString();
                //    lblTotalWasteWater.Text = ds.Tables[6].Rows[0]["PCB_Total"].ToString();



                //    lblCapacityOfDGSet.Text = ds.Tables[6].Rows[0]["PCB_AP_Capcity"].ToString();
                //    lblFuelConsumptionPerDay.Text = ds.Tables[6].Rows[0]["PCB_FuelConsumption"].ToString();
                //    lblFuelStorageDetails.Text = ds.Tables[6].Rows[0]["PCB_FuelStorge"].ToString();
                //    lblStackHeight.Text = ds.Tables[6].Rows[0]["PCB_StackHight"].ToString();
                //    lblAirPolutionControlEquipement.Text = ds.Tables[6].Rows[0]["PCB_AirPolution_Equipment"].ToString();
                //    lblEmissionCharacteristtics.Text = ds.Tables[6].Rows[0]["PCB_EmiCharcter"].ToString();
                //    lblQuwntityOfEmission.Text = ds.Tables[6].Rows[0]["PCB_Qunt_Emission"].ToString();
                //    lblControlSystem.Text = ds.Tables[6].Rows[0]["PCB_ControlEqu"].ToString();
                //    lblGeneratorRequred.Text = ds.Tables[6].Rows[0]["PCB_IsPrjRequired"].ToString();
                //}

                //if (ds.Tables[8].Rows.Count > 0)
                //{
                //    lblHeightOfBulding.Text = ds.Tables[8].Rows[0]["Hight_Building"].ToString();
                //    lblHeightOfEachFloor.Text = ds.Tables[8].Rows[0]["Hight_EachFloor"].ToString();
                //    lblInternaiStaircase.Text = ds.Tables[8].Rows[0]["Inter_Stairs"].ToString();
                //    lblExternalStairCase.Text = ds.Tables[8].Rows[0]["Exernal_Stairs"].ToString();
                //    lblWidthOfStairCase.Text = ds.Tables[8].Rows[0]["Width_Stairs"].ToString();
                //    lblNoOfExits.Text = ds.Tables[8].Rows[0]["NoofExits"].ToString();
                //    lblWidthOfEachExists.Text = ds.Tables[8].Rows[0]["Width_eachExit"].ToString();
                //    lblSpaceInEast.Text = ds.Tables[8].Rows[0]["Fire_East"].ToString();
                //    lblSpaceInWest.Text = ds.Tables[8].Rows[0]["Fire_West"].ToString();
                //    lblSpaceInNorth.Text = ds.Tables[8].Rows[0]["Fire_North"].ToString();
                //    lblSpaceInSouth.Text = ds.Tables[8].Rows[0]["Fire_South"].ToString();
                //    lblLevelOfGround.Text = ds.Tables[8].Rows[0]["Levelground"].ToString();
                //    lblFireDetectionSystem.Text = ds.Tables[8].Rows[0]["Fire_Detection"].ToString();
                //    lblFireAlarmSystem.Text = ds.Tables[8].Rows[0]["Fire_Alaram"].ToString();
                //    lblSprinkler.Text = ds.Tables[8].Rows[0]["Sprinkler"].ToString();
                //    lblFoam.Text = ds.Tables[8].Rows[0]["Foam"].ToString();
                //    lblCO2.Text = ds.Tables[8].Rows[0]["CO2"].ToString();
                //    lblDCP.Text = ds.Tables[8].Rows[0]["DCP"].ToString();
                //    lblFireServiceInlet.Text = ds.Tables[8].Rows[0]["Fire_Service_Inlet"].ToString();
                //    lblUnderGrounDtank.Text = ds.Tables[8].Rows[0]["Under_ground"].ToString();
                //    lblNoOfCouryYard.Text = ds.Tables[8].Rows[0]["Court_yard_hydrants"].ToString();
                //    lblFirePumpElectricity.Text = ds.Tables[8].Rows[0]["Fire_pumps_Electrical_15"].ToString();
                //    lblDiesel.Text = ds.Tables[8].Rows[0]["Fire_pumps_Diesel"].ToString();
                //    lblCO7.Text = ds.Tables[8].Rows[0]["Fire_pumps_Electrical_30"].ToString();
                //    lblTrolly.Text = ds.Tables[8].Rows[0]["Trolley_45"].ToString();
                //    lblFencing.Text = ds.Tables[8].Rows[0]["Fencing"].ToString();
                //    lblSoakPit.Text = ds.Tables[8].Rows[0]["SoakPit"].ToString();
                //    lbllighteningProtectin.Text = ds.Tables[8].Rows[0]["Lightning_Prot"].ToString();
                //    lblControlRoom.Text = ds.Tables[8].Rows[0]["Cont_Room"].ToString();
                //    lblHydralicPlatform.Text = ds.Tables[8].Rows[0]["Hydraulic_Platform"].ToString();
                //}





                //// GridView2.DataSource = ds.Tables[1];
                //// GridView2.DataBind();
                //if (ds.Tables[1].Rows.Count > 0)
                //{

                //    //lblErrMsg.Text = "<font color=red><b>Record Not Found</b></font>";
                //    GridView1.DataSource = ds.Tables[1];
                //    GridView1.DataBind();

                //}
                //if (ds.Tables[2].Rows.Count > 0)
                //{

                //    //lblErrMsg.Text = "<font color=red><b>Record Not Found</b></font>";
                //    GridView2.DataSource = ds.Tables[2];
                //    GridView2.DataBind();

                //}
                //if (ds.Tables[7].Rows.Count > 0)
                //{

                //    //lblErrMsg.Text = "<font color=red><b>Record Not Found</b></font>";
                //    GridView3.DataSource = ds.Tables[7];
                //    GridView3.DataBind();

                //}
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
        }
    }
}
