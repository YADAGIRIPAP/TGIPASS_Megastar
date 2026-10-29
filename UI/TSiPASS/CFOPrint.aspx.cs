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

            if (!IsPostBack)
            {

                if (Request.QueryString.Count > 0)
                {

                    if (Request.QueryString[0].ToString() != "")
                    {
                        ComplaintNo = Request.QueryString[0].ToString();
                        FillGrid();
                    }
                }

                else
                {
                    DataSet dscheck1 = new DataSet();
                    dscheck1 = clsGeneral.GetShowQuestionariesCFO(Session["uid"].ToString().Trim());
                    if (dscheck1.Tables[0].Rows.Count > 0)
                    {
                        Session["ApplidA"] = dscheck1.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
                    }
                    else
                    {
                        Session["ApplidA"] = "0";
                    }

                    //if (Session["ApplidA"].ToString().Trim() == "" || Session["ApplidA"].ToString().Trim() == "0")
                    //{
                    //    Response.Redirect("frmQuesstionniareRegCFO.aspx");
                    //}


                    if (Session["ApplidA"].ToString() != "" || Session["ApplidA"].ToString() != "0")
                    {
                        DataSet dsnew = new DataSet();

                        dsnew = clsGeneral.GetEnterPreneurdatabyQueCFO(Session["ApplidA"].ToString());

                        if (dsnew != null && dsnew.Tables[0].Rows.Count > 0)
                        {
                            ComplaintNo = dsnew.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                            FillGrid();

                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            // lblmsg.Text = ex.Message;
            //Failure.Visible = true;
        }
    }
    public void FillGrid()
    {
        try
        {
            ds = clsGeneral.GetCFOEnterprenuerDetailsNew(ComplaintNo);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count != 0)
                {
                    tdpcbcategory.InnerHtml = ds.Tables[0].Rows[0]["Pol_Category"].ToString();
                    lblUidNo.Text = ds.Tables[0].Rows[0]["UID_No"].ToString();
                    lblNameOfUndertaker.Text = ds.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();

                    lblNameOfPromoter.Text = ds.Tables[0].Rows[0]["NameofthePromoter"].ToString();
                    lblSonOf.Text = ds.Tables[0].Rows[0]["SoWo"].ToString();

                    lblDoorNo.Text = ds.Tables[0].Rows[0]["Door_No"].ToString();
                    lblStreetName.Text = ds.Tables[0].Rows[0]["StreetName"].ToString();
                    if (ds.Tables[0].Rows[0]["intVillageid"].ToString().Trim() != "")
                    {
                        lblvillage.Text = ds.Tables[0].Rows[0]["Village_Name"].ToString();
                    }
                    //else
                    //{
                    //    lblvillage.Text = ds.Tables[0].Rows[0]["VillName"].ToString();
                    //}
                    if (ds.Tables[0].Rows[0]["intDistrictid"].ToString().Trim() != "")
                    {
                        lblDistrict.Text = ds.Tables[0].Rows[0]["District_Name"].ToString();
                    }
                    //else
                    //{
                    //    lblDistrict.Text = ds.Tables[0].Rows[0]["distname"].ToString();
                    //}

                    lblMobileNo.Text = ds.Tables[0].Rows[0]["MobileNumber"].ToString();
                    lblRegistrationCategory.Text = ds.Tables[0].Rows[0]["Category_Of_Registration"].ToString();
                    lblEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();

                    lblState.Text = ds.Tables[0].Rows[0]["State_Name"].ToString();
                    lblPincode.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
                    if (ds.Tables[0].Rows[0]["intMandalid"].ToString().Trim() != "")
                    {
                        lblMandal.Text = ds.Tables[0].Rows[0]["Manda_lName"].ToString();
                    }
                    //else
                    //{
                    //    lblMandal.Text = ds.Tables[0].Rows[0]["MName"].ToString();

                    //}

                    lblTelephone.Text = ds.Tables[0].Rows[0]["TelephoneNumber"].ToString();
                    lblOrganisation.Text = ds.Tables[0].Rows[0]["Org_Type"].ToString();
                    lblFax.Text = ds.Tables[0].Rows[0]["Fax"].ToString();
                    //  lblBuldingCost.Text = ds.Tables[0].Rows[0]["Building_value"].ToString();
                    //  lblPlantCost.Text = ds.Tables[0].Rows[0]["plant_value"].ToString();



                    lblMaleAbout18.Text = ds.Tables[0].Rows[0]["AdultMale"].ToString();
                    lblFemaleAbove18.Text = ds.Tables[0].Rows[0]["AdultFemale"].ToString();
                    lblMale15to18.Text = ds.Tables[0].Rows[0]["Adolescents_Male"].ToString();

                    lblBuildingheight.Text = ds.Tables[0].Rows[0]["Hight_Build"].ToString();
                    lblBuiltupArea.Text = ds.Tables[0].Rows[0]["Built_up_Area"].ToString();

                    lblFemale15to18.Text = ds.Tables[0].Rows[0]["Adolescents_Female"].ToString();
                    lblMale14to15.Text = ds.Tables[0].Rows[0]["Children_Male"].ToString();
                    lblFemale14to15.Text = ds.Tables[0].Rows[0]["Children_Female"].ToString();
                    // added by lavanya
                    lblEntAge.Text = ds.Tables[0].Rows[0]["Age"].ToString();
                    lblEntOccupation.Text = ds.Tables[0].Rows[0]["Occupation"].ToString();
                    lblLandMark.Text = ds.Tables[0].Rows[0]["Land_Mark"].ToString();
                    lblDifferentlyABles.Text = ds.Tables[0].Rows[0]["diffabled"].ToString(); // ,,
                    lblWomenEnterpren.Text = ds.Tables[0].Rows[0]["WomenEnterprenuer"].ToString();
                    lblMinority.Text = ds.Tables[0].Rows[0]["Minority"].ToString();
                    // end by lavanya 

                    lblRegistration.Text = ds.Tables[0].Rows[0]["Reg_No"].ToString();
                    //Convert.ToDateTime(ds.Tables[0].Rows[0]["Reg_Date"]).ToString("dd-MM-yyyy")
                    if (ds.Tables[0].Rows[0]["Reg_ExpDate"].ToString() != "")
                    {
                        lblExpiryDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Reg_Date"]).ToString("dd-MM-yyyy");
                    }
                    if (ds.Tables[0].Rows[0]["Reg_Date"].ToString() != "")
                    {
                        lblRegistrationDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Reg_Date"]).ToString("dd-MM-yyyy");
                    }
                    lblTypeOfProject.Text = ds.Tables[0].Rows[0]["TypeofFactoryA"].ToString();

                    if (ds.Tables[0].Rows[0]["ProposalFor"].ToString() != "" && ds.Tables[0].Rows[0]["ProposalFor"].ToString() != null)
                    {
                        if (ds.Tables[0].Rows[0]["ProposalFor"].ToString() != "New")
                        {
                            trproposalexisting.Visible = true;
                            trproposalNew.Visible = false;
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
                            trproposalexisting.Visible = false;
                            trproposalNew.Visible = true;
                            lblproposalnew.Text = ds.Tables[0].Rows[0]["ProposalFor"].ToString();
                            lblland.Text = ds.Tables[0].Rows[0]["Land_Value"].ToString();
                            lblbuilding.Text = ds.Tables[0].Rows[0]["Building_value"].ToString();
                            lblplant.Text = ds.Tables[0].Rows[0]["plant_value"].ToString();

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
                            lbltotalvalue.Text = Convert.ToString(Convert.ToDouble(lblland.Text.Trim().TrimStart()) + Convert.ToDouble(lblbuilding.Text.Trim().TrimStart()) + Convert.ToDouble(lblplant.Text.Trim().TrimStart()));

                            //lblExpInvestLandValue.Text = ds.Tables[0].Rows[0]["Val_LandExpansion"].ToString();
                            //lblExpInvestBuildingValue.Text = ds.Tables[0].Rows[0]["Val_BuildExpansion"].ToString();
                            //lblExpInvestPlantlValue.Text = ds.Tables[0].Rows[0]["Val_PlantExpansion"].ToString();

                            //if (lblExpInvestLandValue.Text.Trim().TrimStart() == "")
                            //{
                            //    lblExpInvestLandValue.Text = "0";
                            //}
                            //if (lblExpInvestBuildingValue.Text.Trim().TrimStart() == "")
                            //{
                            //    lblExpInvestBuildingValue.Text = "0";
                            //}
                            //if (lblExpInvestPlantlValue.Text.Trim().TrimStart() == "")
                            //{
                            //    lblExpInvestPlantlValue.Text = "0";
                            //}
                            //lblTotalLandValue.Text = Convert.ToString(Convert.ToDouble(lblExpInvestLandValue.Text.Trim().TrimStart()) + Convert.ToDouble(lblLandCost.Text.Trim().TrimStart()));
                            //lblTotalBuilding.Text = Convert.ToString(Convert.ToDouble(lblExpInvestBuildingValue.Text.Trim().TrimStart()) + Convert.ToDouble(lblBuldingCost.Text.Trim().TrimStart()));
                            //lblToalPlantValue.Text = Convert.ToString(Convert.ToDouble(lblExpInvestPlantlValue.Text.Trim().TrimStart()) + Convert.ToDouble(lblPlantCost.Text.Trim().TrimStart()));

                            //lblExpInvestTotalValue.Text = Convert.ToString(Convert.ToDouble(lblExpInvestLandValue.Text.Trim().TrimStart()) + Convert.ToDouble(lblExpInvestBuildingValue.Text.Trim().TrimStart()) + Convert.ToDouble(lblExpInvestPlantlValue.Text.Trim().TrimStart()));
                            //lblTotalInvestment.Text = Convert.ToString(Convert.ToDouble(lblTotExistingInvest.Text.Trim().TrimStart()) + Convert.ToDouble(lblExpInvestTotalValue.Text.Trim().TrimStart()));
                        }
                    }


                    lblSurveyNo.Text = ds.Tables[0].Rows[0]["SurveyNo"].ToString();
                    lblvillage0.Text = ds.Tables[0].Rows[0]["LOCATIONVILLAGE"].ToString();
                    lblMandal0.Text = ds.Tables[0].Rows[0]["LOCATIONMANDAL"].ToString();
                    lblPincode0.Text = ds.Tables[0].Rows[0]["Land_Pincode"].ToString();

                    lblDistrict0.Text = ds.Tables[0].Rows[0]["LOCATIONDISTRICT"].ToString();
                    lblProposedArea.Text = ds.Tables[0].Rows[0]["Name_Gramapachayat"].ToString();



                }
                if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
                {


                    lblAlreadyInstalled.Text = ds.Tables[3].Rows[0]["Cont_Demand_Max_Already"].ToString();

                    lblProposed.Text = ds.Tables[3].Rows[0]["Cont_Demand_Max_Proposed"].ToString();
                    lblTotal.Text = ds.Tables[3].Rows[0]["Cont_Demand_Max_Total"].ToString();
                    lblAlreadyInstalledFW.Text = ds.Tables[3].Rows[0]["Connect_Load_A"].ToString();
                    // lblAlreadyInstalledHP.Text=ds.Tables[3].Rows[0]["LocationName"].ToString();
                    lblProposedKW.Text = ds.Tables[3].Rows[0]["Connect_Load_B"].ToString();
                    //lblProposedHP.Text=ds.Tables[3].Rows[0]["LocationName"].ToString();
                    lblTotalKW.Text = ds.Tables[3].Rows[0]["Connect_Load_C"].ToString();
                    // lblTotalHP.Text=ds.Tables[3].Rows[0]["LocationName"].ToString();
                    lblTelephone0.Text = ds.Tables[3].Rows[0]["Telephonce_No"].ToString();
                    lblProposedLocation.Text = ds.Tables[3].Rows[0]["Prop_Location"].ToString();


                    lblDateOfProduction.Text = ds.Tables[3].Rows[0]["Date_Comm_Production"].ToString();
                    //  lblProposedLocationOfFactory.Text = ds.Tables[3].Rows[0]["Prop_Location"].ToString();


                    lblExtentofSightArea.Text = ds.Tables[3].Rows[0]["Extent"].ToString();
                   // lblStreetName.Text = ds.Tables[3].Rows[0]["Street_Name"].ToString();

                    lblTPhone.Text = ds.Tables[3].Rows[0]["Nearest_Tel_No"].ToString();
                    lblTypeOfConnectedLoad.Text = ds.Tables[3].Rows[0]["Type_of_connect_Load"].ToString();

                }
                if (ds.Tables.Count > 4 && ds.Tables[4].Rows.Count > 0)
                {


                    trfactory.Visible = true;
                    trPetroleumpremises.Visible = true;
                    trPetroleumproposed.Visible = true;
                    trPetroleumstored.Visible = true;
                    trfactoryhorse.Visible = true;

                    lblNatureOfProcess.Text = ds.Tables[4].Rows[0]["Nature_Manfacture"].ToString();
                    //lblNameAddress.Text = ((int.Parse(ds.Tables[4].Rows[0]["FullN_Res_Address"].ToString())) + (int.Parse(ds.Tables[4].Rows[0]["Connect_Load_B"].ToString()))).ToString();
                    lblReferanceNo.Text = ds.Tables[4].Rows[0]["Plans_Chief_Inspector_RefNo"].ToString();
                    lblNameAddressOfOccupier.Text = ds.Tables[4].Rows[0]["FullN_Res_Address"].ToString();
                    lblNameAddress.Text = ds.Tables[4].Rows[0]["FullN_Addres_LocalLadFund"].ToString();
                    lblNameAddressOfOwner.Text = ds.Tables[4].Rows[0]["FullN_Addres_Owner"].ToString();
                    //lblHoursPerDay.Text = ds.Tables[4].Rows[0]["Power_PerDay"].ToString();
                    //lblHoursPerMonth.Text = ds.Tables[4].Rows[0]["Power_PerMonth"].ToString();
                    if (ds.Tables[4].Rows[0]["Plans_Chief_Inspector_RefDt"].ToString().Trim() != "")
                    {
                        lblReferanceDate.Text = Convert.ToDateTime(ds.Tables[4].Rows[0]["Plans_Chief_Inspector_RefDt"]).ToString("dd-MM-yyyy");
                    }
                    if (ds.Tables[4].Rows[0]["Date_Occupation"].ToString().Trim() != "")
                    {
                        lblDateOfOccupation.Text = Convert.ToDateTime(ds.Tables[4].Rows[0]["Date_Occupation"]).ToString("dd-MM-yyyy");
                    }

                    lblStoredDistrict.Text = ds.Tables[4].Rows[0]["District_Name"].ToString();
                    lblNearPoliceStation.Text = ds.Tables[4].Rows[0]["Petrolium_PoliceStation"].ToString();
                    lblStoredVillage.Text = ds.Tables[4].Rows[0]["Village_Name"].ToString();
                    lblRailwayStation.Text = ds.Tables[4].Rows[0]["Nearest_RailwayStation"].ToString();
                    lblPetroleumClassAAbove1000.Text = ds.Tables[4].Rows[0]["InBulk_ClassA"].ToString();
                    lblPetroleumClassA.Text = ds.Tables[4].Rows[0]["NotinBulk_ClassA"].ToString();
                    lblPetroleumClassBAbove1000.Text = ds.Tables[4].Rows[0]["InBulk_ClassB"].ToString();
                    lblPetroleumClassB.Text = ds.Tables[4].Rows[0]["NotinBulk_ClassB"].ToString();
                    lblPetroleumClassCAbove1000.Text = ds.Tables[4].Rows[0]["InBulk_CalssC"].ToString();
                    lblPetroleumClassC.Text = ds.Tables[4].Rows[0]["NotinBulk_ClassC"].ToString();
                    lblPetroleumTotalAbove1000.Text = ds.Tables[4].Rows[0]["InBulk_Total"].ToString();
                    lblPetroleumClassTotal.Text = ds.Tables[4].Rows[0]["NotinBulk_ClassTotal"].ToString();
                    lblPetroleumClassA.Text = ds.Tables[4].Rows[0]["Total_Class_A"].ToString();
                    lblPetroleumClassB.Text = ds.Tables[4].Rows[0]["Total_Class_B"].ToString();
                    lblPetroleumClassC.Text = ds.Tables[4].Rows[0]["Total_Class_C"].ToString();
                    lblPetroleumClassTotal.Text = ds.Tables[4].Rows[0]["Total_Totals"].ToString();




                    lblPetroleumClassAAbove1001.Text = ds.Tables[4].Rows[0]["Stored_InBulk_ClassA"].ToString();
                    lblPetroleumClassA0.Text = ds.Tables[4].Rows[0]["Stored_NotinBulk_ClassA"].ToString();
                    lblPetroleumClassBAbove1001.Text = ds.Tables[4].Rows[0]["Stored_InBulk_ClassB"].ToString();
                    lblPetroleumClassB0.Text = ds.Tables[4].Rows[0]["Stored_NotinBulk_ClassB"].ToString();
                    lblPetroleumClassCAbove1001.Text = ds.Tables[4].Rows[0]["Stored_InBulk_CalssC"].ToString();
                    lblPetroleumClassC0.Text = ds.Tables[4].Rows[0]["Stored_NotinBulk_ClassC"].ToString();
                    lblPetroleumTotalAbove1001.Text = ds.Tables[4].Rows[0]["Stored_InBulk_Total"].ToString();
                    lblPetroleumClassTotal0.Text = ds.Tables[4].Rows[0]["Stored_NotinBulk_ClassTotal"].ToString();
                    lblPetroleumClassA0.Text = ds.Tables[4].Rows[0]["Stored_Total_Class_A"].ToString();
                    lblPetroleumClassB0.Text = ds.Tables[4].Rows[0]["Stored_Total_Class_B"].ToString();
                    lblPetroleumClassC0.Text = ds.Tables[4].Rows[0]["Stored_Total_Class_C"].ToString();
                    lblPetroleumClassTotal0.Text = ds.Tables[4].Rows[0]["Stored_Total_Totals"].ToString();
                    lblSalesTax.Text = ds.Tables[4].Rows[0]["SalesTaxDetails"].ToString();
                    lblExplosiveLicnce.Text = ds.Tables[4].Rows[0]["Exploside_LicenseDetails"].ToString();

                    //lblHPRegular.Text = ds.Tables[4].Rows[0]["RegularHp"].ToString(); //lavanya
                    //lblHPStandBy.Text = ds.Tables[4].Rows[0]["StandbyHp"].ToString();
                    lblregularhp.Text = ds.Tables[4].Rows[0]["RegularHp"].ToString();
                    lblstandyhp.Text = ds.Tables[4].Rows[0]["StandbyHp"].ToString();
                    lbllicenseYear.Text = ds.Tables[4].Rows[0]["LicenseYear"].ToString();
                    // end by lavanya 

                }
                else
                {
                    trfactory.Visible = false;
                    trPetroleumpremises.Visible = false;
                    trPetroleumproposed.Visible = false;
                    trPetroleumstored.Visible = false;
                    trfactoryhorse.Visible = false;
                }

                if (ds.Tables.Count > 5 && ds.Tables[5].Rows.Count > 0)
                {
                    trBoiler.Visible = true;
                    //if (ds.Tables[5].Rows[0]["Date_Inpec_Desirable"].ToString().Trim() != "")
                    //{
                    //    lblBoilerRegDate.Text = Convert.ToDateTime(ds.Tables[5].Rows[0]["Date_Inpec_Desirable"]).ToString("dd-MM-yyyy");
                    //}
                    lblBoilerRegDate.Text = ds.Tables[5].Rows[0]["Reg_No_Boiler"].ToString();

                    lblBoilerAge.Text = ds.Tables[5].Rows[0]["Desc_Boiler_Age"].ToString();
                    lblNameOfAget.Text = ds.Tables[5].Rows[0]["Name_Owner"].ToString();
                    lblBoilerMaker.Text = ds.Tables[5].Rows[0]["Makers_name"].ToString();
                    lblBoilerLocation.Text = ds.Tables[5].Rows[0]["Location"].ToString();
                    // lblBoilerMakerNo.Text = ds.Tables[5].Rows[0]["Quant_Water_NonConsumptive"].ToString();

                    if (ds.Tables[5].Rows[0]["Date_Inpec_Desirable"].ToString().Trim() != "")
                    {
                        lblDateOfInspection.Text = Convert.ToDateTime(ds.Tables[5].Rows[0]["Date_Inpec_Desirable"]).ToString("dd-MM-yyyy");
                    }

                    lblTypeOfBoiler.Text = ds.Tables[5].Rows[0]["Type_Boiler"].ToString();

                    lblPlaceOfManuf.Text = ds.Tables[5].Rows[0]["Place_Manfacture"].ToString();
                    lblYeayOfManufature.Text = ds.Tables[5].Rows[0]["Year_Manfacture"].ToString();
                    lblBoilerUsedFor.Text = ds.Tables[5].Rows[0]["Boiler_User_for"].ToString();
                    lblMaxPressur.Text = ds.Tables[5].Rows[0]["Allowed_Max_Presure"].ToString();
                    lblBoilerRating.Text = ds.Tables[5].Rows[0]["Boiler_ration"].ToString();
                    lblEconomiserMake.Text = ds.Tables[5].Rows[0]["Econ_Maker_Number"].ToString();
                    lblMaxEvaporation.Text = ds.Tables[5].Rows[0]["Max_Conti_Evapron"].ToString();

                    lblErectorClass.Text = ds.Tables[5].Rows[0]["Class_Erector"].ToString();
                    lblErectorName.Text = ds.Tables[5].Rows[0]["Name_of_Erector"].ToString();
                    lblErectorState.Text = ds.Tables[5].Rows[0]["State_Erector"].ToString();
                    lblPressurOfEconomiser.Text = ds.Tables[5].Rows[0]["Max_Presure_Econ"].ToString();
                    lbllengthOfSteamPipeline.Text = ds.Tables[5].Rows[0]["Tot_Lenght_Steam_PipeLine"].ToString();
                }
                else
                {
                    trBoiler.Visible = false;
                }

                // GridView2.DataSource = ds.Tables[1];
                // GridView2.DataBind();
                if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {

                    //lblErrMsg.Text = "<font color=red><b>Record Not Found</b></font>";
                    GridView1.DataSource = ds.Tables[1];
                    GridView1.DataBind();

                }
                if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                {

                    //lblErrMsg.Text = "<font color=red><b>Record Not Found</b></font>";
                    GridView2.DataSource = ds.Tables[2];
                    GridView2.DataBind();

                }
                if (ds.Tables.Count > 5 && ds.Tables[6].Rows.Count > 0)
                {
                    trLabour.Visible = true;
                    lblMangerName.Text = ds.Tables[6].Rows[0]["Form1_1_Manager_Name"].ToString();
                    lblFatherName.Text = ds.Tables[6].Rows[0]["Form1_1_Manager_FatherName"].ToString();
                    lblAddressofManger.Text = ds.Tables[6].Rows[0]["MGRADDRESS"].ToString();
                    lblnatureofwork.Text = ds.Tables[6].Rows[0]["Form1_Nature_of_Business"].ToString();
                    lblEstimatedComm.Text = ds.Tables[6].Rows[0]["Form1_1_DateofCommencement"].ToString();
                    lblMaximumWorkers.Text = ds.Tables[6].Rows[0]["Form1_2_MaxWorkers"].ToString();
                    lblconstructiondate.Text = ds.Tables[6].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();
                    lblDesignation.Text = ds.Tables[6].Rows[0]["Form1_1_Manager_Designation"].ToString();

                    lblMgrAge.Text = ds.Tables[6].Rows[0]["Form1_Employer_Age"].ToString();
                    lblMgrMobile.Text = ds.Tables[6].Rows[0]["Form1_Employer_MobileNo"].ToString();
                    lblMgrEmail.Text = ds.Tables[6].Rows[0]["Form1_Employer_EmailID"].ToString();

                    lblEmpDoorNo.Text = ds.Tables[6].Rows[0]["Form1_Employer_DoorNo"].ToString();
                    lblEmpLocality.Text = ds.Tables[6].Rows[0]["Form1_Employer_Locality"].ToString();
                    lblEmpDistrict.Text = ds.Tables[6].Rows[0]["Form1_Employer_District"].ToString();
                    lblEmpMandal.Text = ds.Tables[6].Rows[0]["Form1_Employer_Mandal"].ToString();
                    lblEmpVillage.Text = ds.Tables[6].Rows[0]["Form1_Employer_Village"].ToString();
                    lblDirName.Text = ds.Tables[6].Rows[0]["Form1_4_Dir_FullName"].ToString();
                    lblDirDoorNo.Text = ds.Tables[6].Rows[0]["Form1_4_Dir_DoorNo"].ToString();
                    lblDirDistrict.Text = ds.Tables[6].Rows[0]["Form1_4_Dir_District"].ToString();
                    lblDirMandal.Text = ds.Tables[6].Rows[0]["Form1_4_Dir_Mandal"].ToString();
                    lblDirVillage.Text = ds.Tables[6].Rows[0]["Form1_4_Dir_Village"].ToString();

                    txtAbove18Male.Text = ds.Tables[6].Rows[0]["Form1_1_Employees_Above18_Male"].ToString();
                    txtBelow18Male.Text = ds.Tables[6].Rows[0]["Form1_1_Employees_14_18_Male"].ToString();
                    txtAbove18Female.Text = ds.Tables[6].Rows[0]["Form1_1_Employees_Above18_Female"].ToString();
                    txtBelow18FeMale.Text = ds.Tables[6].Rows[0]["Form1_1_Employees_14_18_Female"].ToString();
                    lblClassification.Text = ds.Tables[6].Rows[0]["Form1_1_Estb_Classification"].ToString();
                    lblCategory.Text = ds.Tables[6].Rows[0]["Form1_1_Estb_Category"].ToString();


                }
                else
                {
                    trLabour.Visible = false;
                }
                if (ds.Tables.Count > 6 && ds.Tables[7].Rows.Count > 0)
                {
                    trLabour.Visible = true;
                    gvGodown.DataSource = ds.Tables[7];
                    gvGodown.DataBind();
                }

                if (ds.Tables.Count > 7 && ds.Tables[8].Rows.Count > 0)
                {
                    trLabour.Visible = true;
                    gvFamily.DataSource = ds.Tables[8];
                    gvFamily.DataBind();
                }

                if (ds.Tables.Count > 8 && ds.Tables[9].Rows.Count > 0)
                {
                    trLabour.Visible = true;
                    gvEmpDtls.DataSource = ds.Tables[9];
                    gvEmpDtls.DataBind();
                }

                if (ds.Tables.Count > 9 && ds.Tables[10].Rows.Count > 0)
                {
                    trLabour.Visible = true;
                    gvContractor.DataSource = ds.Tables[10];
                    gvContractor.DataBind();
                }
                if (ds.Tables.Count > 10 && ds.Tables[11].Rows.Count > 0)
                {
                    //Registration_cd
                    trLegal.Visible = true;
                    lblLegalRegas.Text = ds.Tables[11].Rows[0]["Registration_cd"].ToString();
                    lblDateofPacking.Text = ds.Tables[11].Rows[0]["DateofCommencement"].ToString();
                    lblTradeLic.Text = ds.Tables[11].Rows[0]["Premises_TradeLicense"].ToString();
                    lblLabel.Text = ds.Tables[11].Rows[0]["Label_details"].ToString();
                    lblTinNo.Text = ds.Tables[11].Rows[0]["Tin_Number"].ToString();
                    //lblLegalRegas.Text = ds.Tables[11].Rows[0][""].ToString();
                    //lblLegalRegas.Text = ds.Tables[11].Rows[0][""].ToString();
                    //lblLegalRegas.Text = ds.Tables[11].Rows[0][""].ToString();
                }
                else
                {
                    trLegal.Visible = false;
                }
                if (ds.Tables.Count > 12 && ds.Tables[12].Rows.Count > 0)
                {
                    gvBrand.DataSource = ds.Tables[12];
                    gvBrand.DataBind();
                }
                if (ds.Tables.Count > 13 && ds.Tables[13].Rows.Count > 0)
                {
                    gvCommodity.DataSource = ds.Tables[13];
                    gvCommodity.DataBind();
                }

                if (ds.Tables.Count > 14 && ds.Tables[14].Rows.Count > 0)
                {
                    trDrug.Visible = true;
                    gvDrugDir.DataSource = ds.Tables[14];
                    gvDrugDir.DataBind();
                }
                else
                {
                    trDrug.Visible = false;
                }
                if (ds.Tables.Count > 15 && ds.Tables[15].Rows.Count > 0)
                {
                    gvDrugProducts.DataSource = ds.Tables[15];
                    gvDrugProducts.DataBind();
                }
                if (ds.Tables.Count > 16 && ds.Tables[16].Rows.Count > 0)
                {
                    gvTechStaff.DataSource = ds.Tables[16];
                    gvTechStaff.DataBind();
                }

                if (ds.Tables.Count > 17 && ds.Tables[17].Rows.Count > 0)
                {
                    gvLegalProp.DataSource = ds.Tables[17];
                    gvLegalProp.DataBind();
                }
                if (ds.Tables[18].Rows.Count > 0)
                {
                    if (ds.Tables[18].Rows[0]["Downloadlink"].ToString() != null && ds.Tables[18].Rows[0]["Downloadlink"].ToString() != "")
                    {
                        pcbnew.Visible = true;
                        hylinkpcb.Visible = true;
                        hylinkpcb.NavigateUrl = ds.Tables[18].Rows[0]["Downloadlink"].ToString();
                    }
                }
                else
                {
                    pcbnew.Visible = false;
                }
                //if (ds.Tables[7].Rows.Count > 0)
                //{

                //    //lblErrMsg.Text = "<font color=red><b>Record Not Found</b></font>";
                //    GridView3.DataSource = ds.Tables[7];
                //    GridView3.DataBind();

                //}
            }

            //}
            else
            {

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //  lblmsg0.Text = ex.Message;
            //  Failure.Visible = true;
        }
    }
}
