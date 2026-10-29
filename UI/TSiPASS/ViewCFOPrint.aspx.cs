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

        if (Session.Count == 0)
        {
            // Response.Redirect("frmUserLogin.aspx");
        }

        //if (!IsPostBack)
        //{




        //    DataSet dscheck1 = new DataSet();
        //    dscheck1 = clsGeneral.GetShowQuestionariesCFO(Session["uid"].ToString().Trim());
        //    if (dscheck1.Tables[0].Rows.Count > 0)
        //    {
        //        Session["ApplidA"] = dscheck1.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
        //    }
        //    else
        //    {
        //        Session["ApplidA"] = "0";
        //    }

        //    if (Session["ApplidA"].ToString().Trim() == "" || Session["ApplidA"].ToString().Trim() == "0")
        //    {
        //        Response.Redirect("frmQuesstionniareRegCFO.aspx");
        //    }


        //    if (Session["ApplidA"].ToString() != "" || Session["ApplidA"].ToString() != "0")
        //    {
        //        DataSet dsnew = new DataSet();

        //        dsnew = clsGeneral.GetEnterPreneurdatabyQueCFO(Session["ApplidA"].ToString());

        //        if (dsnew != null && dsnew.Tables[0].Rows.Count > 0)
        //        {
        //            ComplaintNo = dsnew.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
        //            FillGrid();

        //        }
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

        ds = clsGeneral.GetCFOEnterprenuerDetailsNew(ComplaintNo);

        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count != 0)
            {



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
                else
                {
                    lblvillage.Text = ds.Tables[0].Rows[0]["VillName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["intDistrictid"].ToString().Trim() != "")
                {
                    lblDistrict.Text = ds.Tables[0].Rows[0]["District_Name"].ToString();
                }
                else
                {
                    lblDistrict.Text = ds.Tables[0].Rows[0]["distname"].ToString();
                }

                lblMobileNo.Text = ds.Tables[0].Rows[0]["MobileNumber"].ToString();
                lblEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();

                lblState.Text = ds.Tables[0].Rows[0]["State_Name"].ToString();
                lblPincode.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
                if (ds.Tables[0].Rows[0]["intMandalid"].ToString().Trim() != "")
                {
                    lblMandal.Text = ds.Tables[0].Rows[0]["Manda_lName"].ToString();
                }
                else
                {
                    lblMandal.Text = ds.Tables[0].Rows[0]["MName"].ToString();

                }

                lblTelephone.Text = ds.Tables[0].Rows[0]["TelephoneNumber"].ToString();
                lblOrganisation.Text = ds.Tables[0].Rows[0]["Org_Type"].ToString();
                lblFax.Text = ds.Tables[0].Rows[0]["Fax"].ToString();
                //  lblBuldingCost.Text = ds.Tables[0].Rows[0]["Building_value"].ToString();
                //  lblPlantCost.Text = ds.Tables[0].Rows[0]["plant_value"].ToString();



                lblMaleAbout18.Text = ds.Tables[0].Rows[0]["AdultMale"].ToString();
                lblFemaleAbove18.Text = ds.Tables[0].Rows[0]["AdultFemale"].ToString();
                lblMale15to18.Text = ds.Tables[0].Rows[0]["Adolescents_Male"].ToString();

                lblFemale15to18.Text = ds.Tables[0].Rows[0]["Adolescents_Female"].ToString();
                lblMale14to15.Text = ds.Tables[0].Rows[0]["Children_Male"].ToString();
                lblFemale14to15.Text = ds.Tables[0].Rows[0]["Children_Female"].ToString();



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

                lblProposedLocation.Text = ds.Tables[3].Rows[0]["Prop_Location"].ToString();

                lblSurveyNo.Text = ds.Tables[3].Rows[0]["Survey_No"].ToString();

                lblvillage0.Text = ds.Tables[3].Rows[0]["Village_Name"].ToString();

                lblDistrict0.Text = ds.Tables[3].Rows[0]["District_Name"].ToString();
                lblDateOfProduction.Text = ds.Tables[3].Rows[0]["Date_Comm_Production"].ToString();
                //  lblProposedLocationOfFactory.Text = ds.Tables[3].Rows[0]["Prop_Location"].ToString();

                lblMandal0.Text = ds.Tables[3].Rows[0]["Manda_lName"].ToString();
                lblPincode0.Text = ds.Tables[3].Rows[0]["Pincode"].ToString();

                lblTelephone0.Text = ds.Tables[3].Rows[0]["Telephonce_No"].ToString();
                lblExtentofSightArea.Text = ds.Tables[3].Rows[0]["Extent"].ToString();
                lblStreetName.Text = ds.Tables[3].Rows[0]["Street_Name"].ToString();

                lblTPhone.Text = ds.Tables[3].Rows[0]["Nearest_Tel_No"].ToString();
                lblTypeOfConnectedLoad.Text = ds.Tables[3].Rows[0]["Type_of_connect_Load"].ToString();







            }
            if (ds.Tables.Count > 4 && ds.Tables[4].Rows.Count > 0)
            {



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
                lblregularhp.Text = ds.Tables[4].Rows[0]["RegularHp"].ToString();
                lblstandyhp.Text = ds.Tables[4].Rows[0]["StandbyHp"].ToString();
                lbllicenseYear.Text = ds.Tables[4].Rows[0]["LicenseYear"].ToString();

            }


            if (ds.Tables.Count > 5 && ds.Tables[5].Rows.Count > 0)
            {
                trboiler.Visible = true;
                if (ds.Tables[5].Rows[0]["Date_Inpec_Desirable"].ToString().Trim() != "")
                {
                    lblBoilerRegDate.Text = Convert.ToDateTime(ds.Tables[5].Rows[0]["Date_Inpec_Desirable"]).ToString("dd-MM-yyyy");
                }

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
                trboiler.Visible = false;
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
}
