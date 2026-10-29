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
using System.Globalization;

public partial class UI_TSiPASS_ProformaInvestmentSubsidy : System.Web.UI.Page
{

    General Gen = new General();
    int delete = 0;
    comFunctions cmf = new comFunctions();
    string inctiveID = "";

    DataSet dsCAF = new DataSet();
    string ApplClm = "";
    string consUnit = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("../../frmUserLogin.aspx");
        }
        string IncIDfrData = Request.QueryString["EntrpId"].ToString();
        DataSet ds = new DataSet();
        //ds = Gen.GetIncentiveDeptDetails(IncIDfrData);
        //FillDetails(ds);

        //DataSet dsInsp = new DataSet();

        //dsInsp = Gen.GetIncentiveDeptDetails_InspReprt(IncIDfrData);


        if (Request.QueryString["EntrpId"] != null)
        {
            string userid = Session["uid"].ToString();
            string IncentiveId = Request.QueryString["EntrpId"].ToString();
            DataSet dsnew = new DataSet();
            //dsnew = Gen.GetIncentivesISdata(IncentiveId, "6");
            //FilldataIS(dsnew);

            DataSet dsname = new DataSet();
            // dsname = Gen.GetIPORecommendationOfficerDetailsDIC(IncentiveId, "6", "");
            dsname = Gen.GetIncentiveOfficerNamesForAll(IncentiveId, "6", userid, "", "RECOMMENDATION");
            if (dsname.Tables.Count > 0 && dsname.Tables[0].Rows.Count > 0)
            {
                if (dsname.Tables[0].Rows[0]["IPODetails"].ToString() != null)
                {
                    lblDICName.Text = dsname.Tables[0].Rows[0]["IPODetails"].ToString(); //+ "</br>" + dsname.Tables[0].Rows[0]["Designation"].ToString() + "</br>" + dsname.Tables[0].Rows[0]["Dist"].ToString();
                    lblInspectedOfficer.Text = dsname.Tables[0].Rows[0]["IPODetails"].ToString();
                }
                if (dsname.Tables[0].Rows[0]["GMNamerecom"].ToString() != null)
                {
                    lblGMname.Text = dsname.Tables[0].Rows[0]["GMNamerecom"].ToString();
                    lblDICName.Text = dsname.Tables[0].Rows[0]["GMNamerecom"].ToString() + " GM DIC-" + dsname.Tables[0].Rows[0]["WorkingDistrict"].ToString();
                }
            }

            DataSet ds2 = new DataSet();
            // ds2 = Gen.GetBasicUnitDetails_Proforma_letters(IncIDfrData, "6");
            ds2 = Gen.GetBasicUnitDetails_Proforma_lettersPSR(IncIDfrData, "6");
            filldatanew(ds2);
        }
    }

    public void filldatanew(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
        {
            lblletterFrom.Text = ds.Tables[1].Rows[0]["Unitdistrict"].ToString();
            lblLetterNo.Text = "COI/" + ds.Tables[1].Rows[0]["Applicationno"].ToString() + "/GMREC-IS";
            lblLetterDate.Text = ds.Tables[1].Rows[0]["RecommendedDate"].ToString();
            lblEnterpreneurDetails.Text = ds.Tables[1].Rows[0]["UnitDtls"].ToString();
            lblEnterpreneurDetails2.Text = ds.Tables[1].Rows[0]["UnitDtls"].ToString();

            lblRefApplicationNo.Text = ds.Tables[1].Rows[0]["applicationno"].ToString();
            lblRefApplnDate.Text = ds.Tables[1].Rows[0]["ApplicationDate"].ToString();
            lblClaimApplicationDate.Text = ds.Tables[1].Rows[0]["ApplicationDate"].ToString();

            lbldist3.Text = "DIC-" + ds.Tables[1].Rows[0]["unitdistrict"].ToString();
            lblDCP.Text = ds.Tables[1].Rows[0]["DCPNew"].ToString();
            lblLineofActivity.Text = ds.Tables[1].Rows[0]["LOADTLS"].ToString();
            lblInspectedDate.Text = ds.Tables[1].Rows[0]["InpectedDate"].ToString();


            int AmountPaid = Convert.ToInt32(Convert.ToDouble(ds.Tables[1].Rows[0]["GM_Rcon_Amount"].ToString()));
            lbleligibleamount.Text = NumberToCurrency(Convert.ToInt32(Convert.ToDouble(ds.Tables[1].Rows[0]["GM_Rcon_Amount"].ToString())));
            lblAMount.Text = NumberToCurrency(Convert.ToInt32(Convert.ToDouble(ds.Tables[1].Rows[0]["GM_Rcon_Amount"].ToString())));
            lblApplcationDate.Text = NumberToText(AmountPaid) + " Rupees Only.";

            //string stringtest;
            //stringtest = ;
            DateTime stringtest_Date = new DateTime();
            DateTime date1 = DateTime.Parse("04/03/2020");
            stringtest_Date = Convert.ToDateTime(ds.Tables[1].Rows[0]["RecommendedDate"].ToString()).Date;
            //string testStringDate;
            //testStringDate = (Convert.ToDateTime(ds.Tables[1].Rows[0]["ApplicationDate"].ToString()).Date).ToString("dd/MM/yyyy");


            //string stringtest1 = stringtest.ToString("dd/mm/yyyy");

            if (stringtest_Date >= date1)
            {
                divVerify.Visible = true;
            }

            lblRemarks.Text = ds.Tables[1].Rows[0]["GMRecommendedRemarks"].ToString();
            if (lblRemarks.Text.Trim() != "")
            {
                trRemarks.Visible = true;
            }

            if (ds.Tables[1].Rows[0]["sector"].ToString() == "1" && ds.Tables[1].Rows[0]["isVehicleIncentive"].ToString() == "1")
            {
                lblUnitOrVeh.Text = "vehicle";
                lblUnitOrVeh2.Text = "vehicle";
                //lblUnitOrVeh2.Text = ds.Tables[1].Rows[0]["LOADTLS"].ToString();
                lblUnitOrVeh3.Text = "vehicle";
                lblUdyogNoOrVehNO.Text = "Vehicle Number";
                lblUdyogAadhaarNoDate.Text = ds.Tables[1].Rows[0]["VehicleNumber"].ToString();
            }
            else
            {
                lblUnitOrVeh.Text = "Unit";
                lblUnitOrVeh2.Text = "Unit";
                lblUnitOrVeh3.Text = "Unit";
                lblUdyogNoOrVehNO.Text = ds.Tables[1].Rows[0]["UdyogAadhartype"].ToString();

                lblUdyogAadhaarNoDate.Text = ds.Tables[1].Rows[0]["EMiUdyogAadhar"].ToString();
            }

            if (ds.Tables[1].Rows[0]["Scheme"].ToString() != "" && ds.Tables[1].Rows[0]["Scheme"].ToString() != null)
            {
                string strscheme = "";
                strscheme = ds.Tables[1].Rows[0]["Scheme"].ToString();

                if (strscheme == "TIDEA" || strscheme == "TPRIDE" || strscheme == "T-PRIDE" || strscheme == "TFAP")
                {
                    if (ds.Tables[1].Rows[0]["TIDEAflag"].ToString() != "" && ds.Tables[1].Rows[0]["TIDEAflag"].ToString() != null)
                    {
                        if (ds.Tables[1].Rows[0]["TIDEAflag"].ToString() == "Y")
                        {
                            Tideaorpride.Text = "T-IDEA";
                            lblTIdeaTPride.Text = "T-IDEA";
                            lblTIdeaTPride2.Text = "T-IDEA";
                            lblTIdeaTPride3.Text = "T-IDEA";
                            lblloanotlist.Text = "not";
                            lblineligible.Text = "ineligible";
                        }
                    }
                    if (ds.Tables[1].Rows[0]["TSCPflag"].ToString() != "" && ds.Tables[1].Rows[0]["TSCPflag"].ToString() != null)
                    {

                        if (ds.Tables[1].Rows[0]["TSCPflag"].ToString() == "Y")
                        {
                            Tideaorpride.Text = "T-PRIDE(TSCP)";
                            lblTIdeaTPride.Text = "T-PRIDE(TSCP)";
                            lblTIdeaTPride2.Text = "T-PRIDE(TSCP)";
                            lblTIdeaTPride3.Text = "T-PRIDE(TSCP)";
                            lblloanotlist.Text = "";
                            lblineligible.Text = "eligible";
                        }
                    }
                    if (ds.Tables[1].Rows[0]["TSPflag"].ToString() != "" && ds.Tables[1].Rows[0]["TSPflag"].ToString() != null)
                    {
                        if (ds.Tables[1].Rows[0]["TSPflag"].ToString() == "Y")
                        {
                            Tideaorpride.Text = "T-PRIDE(TSP)";
                            lblTIdeaTPride.Text = "T-PRIDE(TSP)";
                            lblTIdeaTPride2.Text = "T-PRIDE(TSP)";
                            lblTIdeaTPride3.Text = "T-PRIDE(TSP)";
                            lblloanotlist.Text = "";
                            lblineligible.Text = "eligible";
                        }
                    }
                    if (ds.Tables[1].Rows[0]["IsDifferentlyAbled"].ToString() != null && ds.Tables[1].Rows[0]["IsDifferentlyAbled"].ToString() != string.Empty)
                    {
                        if (ds.Tables[1].Rows[0]["IsDifferentlyAbled"].ToString() == "Y")   // SC
                        {
                            Tideaorpride.Text = "T-PRIDE(PHC)";
                            lblTIdeaTPride.Text = "T-PRIDE(PHC)";
                            lblTIdeaTPride2.Text = "T-PRIDE(PHC)";
                            lblTIdeaTPride3.Text = "T-PRIDE(PHC)";
                            lblloanotlist.Text = "";
                            lblineligible.Text = "eligible";
                        }
                    }
                }
                else if (strscheme == "IIPP 2005-10" || strscheme == "IIPP 2010-15")
                {
                    Tideaorpride.Text = strscheme;
                    lblTIdeaTPride.Text = strscheme;
                    lblTIdeaTPride2.Text = strscheme;
                    lblTIdeaTPride3.Text = strscheme;
                    lblloanotlist.Text = "";
                    lblineligible.Text = "eligible";
                }
                if(ds.Tables[1].Rows[0]["MSME_Applied"].ToString()=="Y")
                {
                    Tideaorpride.Text = Tideaorpride.Text.Replace("T-PRIDE", "MSME-2024 ").Replace("T-IDEA", "MSME-2024 ");
                    lblTIdeaTPride.Text = lblTIdeaTPride.Text.Replace("T-PRIDE", "MSME-2024 ").Replace("T-IDEA", "MSME-2024 ");
                    lblTIdeaTPride2.Text = lblTIdeaTPride2.Text.Replace("T-PRIDE", "MSME-2024 ").Replace("T-IDEA", "MSME-2024 ");
                    lblTIdeaTPride3.Text = lblTIdeaTPride3.Text.Replace("T-PRIDE", "MSME-2024 ").Replace("T-IDEA", "MSME-2024 ");

                }


            }

            FillDetails(ds);
            FilldataIS(ds);
        }
    }

    public string FillDetails(DataSet ds)
    {
        string IncentID = "";

        if (ds != null)
        {
            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                IncentID = ds.Tables[1].Rows[0]["IncentveID"].ToString();
                if (ds.Tables[1].Rows[0]["Scheme"].ToString() != null && ds.Tables[1].Rows[0]["Scheme"].ToString() != string.Empty)
                {
                    string strscheme = ds.Tables[1].Rows[0]["Scheme"].ToString();
                    string caste = "";
                    ViewState["caste"] = "";

                    if (ds.Tables[1].Rows[0]["IsDifferentlyAbled"].ToString() != null && ds.Tables[1].Rows[0]["IsDifferentlyAbled"].ToString() != string.Empty)
                    {
                        if (ds.Tables[1].Rows[0]["IsDifferentlyAbled"].ToString() == "Y")   // SC
                        {
                            string allwomen = "";
                            caste = "PHC";
                            ViewState["caste"] = "";
                            ViewState["caste"] = caste;
                            if (ds.Tables[1].Rows[0]["isAllWomen"].ToString() != null && ds.Tables[1].Rows[0]["isAllWomen"].ToString() != string.Empty)
                            {
                                if (ds.Tables[1].Rows[0]["isAllWomen"].ToString() == "Y")
                                {
                                    allwomen = "Y";
                                }
                            }

                            if (allwomen == "Y")
                            {
                                lblpercentage.Text = "45%";
                                lblpercentage2.Text = "45";
                            }
                            else
                            {
                                lblpercentage.Text = "35%";
                                lblpercentage2.Text = "35";
                            }
                        }
                        else if (strscheme.Contains("IDEA"))
                        {
                            if (ds.Tables[1].Rows[0]["sector"].ToString() != null && ds.Tables[1].Rows[0]["sector"].ToString() != string.Empty)
                            {
                                if (ds.Tables[1].Rows[0]["sector"].ToString() == "1")
                                {
                                    string str1 = "";
                                    str1 = "T-Pride";   // need to clarify    TSCP, TSP

                                    string allwomen = "";
                                    if (ds.Tables[1].Rows[0]["isAllWomen"].ToString() != null && ds.Tables[1].Rows[0]["isAllWomen"].ToString() != string.Empty)
                                    {
                                        if (ds.Tables[1].Rows[0]["isAllWomen"].ToString() == "Y")
                                        {
                                            allwomen = "Y";
                                        }
                                    }

                                    if (ds.Tables[1].Rows[0]["TSCPflag"].ToString() != null && ds.Tables[1].Rows[0]["TSCPflag"].ToString() != string.Empty)
                                    {
                                        if (ds.Tables[1].Rows[0]["TSCPflag"].ToString() == "Y")   // SC
                                        {
                                            caste = "SC";
                                            ViewState["caste"] = "";
                                            ViewState["caste"] = caste;
                                            if (allwomen == "Y")
                                            {
                                                lblpercentage.Text = "45%";
                                                lblpercentage2.Text = "45";
                                            }
                                            else
                                            {
                                                lblpercentage.Text = "35%";
                                                lblpercentage2.Text = "35";
                                            }
                                        }

                                    }
                                    else if (ds.Tables[1].Rows[0]["TSPflag"].ToString() != null && ds.Tables[1].Rows[0]["TSPflag"].ToString() != string.Empty)
                                    {
                                        if (ds.Tables[1].Rows[0]["TSPflag"].ToString() == "Y")   // ST
                                        {
                                            //  str1 = "T-Pride(TSP)";
                                            caste = "ST";
                                            ViewState["caste"] = "";
                                            ViewState["caste"] = caste;
                                            if (allwomen == "Y")
                                            {
                                                lblpercentage.Text = "45%";
                                                lblpercentage2.Text = "45";
                                            }
                                            else
                                            {
                                                lblpercentage.Text = "35%";
                                                lblpercentage2.Text = "35";
                                            }
                                        }
                                    }
                                    else if (ds.Tables[1].Rows[0]["TIDEAflag"].ToString() != null && ds.Tables[1].Rows[0]["TIDEAflag"].ToString() != string.Empty)
                                    {
                                        if (ds.Tables[1].Rows[0]["TIDEAflag"].ToString() == "Y")   // General
                                        {
                                            //  str1 = "T-Pride(TSP)";
                                            caste = "GEN";
                                            ViewState["caste"] = "";
                                            ViewState["caste"] = caste;
                                            if (allwomen == "Y")
                                            {
                                                lblpercentage.Text = "25%";
                                                lblpercentage2.Text = "25";
                                            }
                                            else
                                            {
                                                lblpercentage.Text = "15%";
                                                lblpercentage2.Text = "15";
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    lblpercentage.Text = "15%";
                                    lblpercentage2.Text = "15";
                                }
                            }
                        }
                        else
                        {
                            lblpercentage.Text = "15%";
                            lblpercentage2.Text = "15";
                        }
                    }
                }
                return IncentID;
            }
            return IncentID;
        }
        return IncentID;
    }


    public void FilldataIS(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
        {
            if (ds.Tables[1].Rows[0]["totCstCmptdLandNew"].ToString() != null && ds.Tables[1].Rows[0]["totCstCmptdLandNew"].ToString() != string.Empty)
            {
                lblLandCost.Text = NumberToCurrency(Convert.ToInt32(Convert.ToDouble(ds.Tables[1].Rows[0]["totCstCmptdLandNew"].ToString())));
            }
            else lblLandCost.Text = "0";
            if (ds.Tables[1].Rows[0]["TotCstCmptdBldgNew"].ToString() != null && ds.Tables[1].Rows[0]["TotCstCmptdBldgNew"].ToString() != string.Empty)
            {
                lblBuildingCost.Text = NumberToCurrency(Convert.ToInt32(Convert.ToDouble(ds.Tables[1].Rows[0]["TotCstCmptdBldgNew"].ToString())));
            }
            else lblBuildingCost.Text = "0";
            if (ds.Tables[1].Rows[0]["TotCstCmptdPlntMachNew"].ToString() != null && ds.Tables[1].Rows[0]["TotCstCmptdPlntMachNew"].ToString() != string.Empty)
            {
                lblPlantMachCost.Text = NumberToCurrency(Convert.ToInt64(Convert.ToDouble(ds.Tables[1].Rows[0]["TotCstCmptdPlntMachNew"].ToString())));
                //lblPlantMachCost.Text =  ds.Tables[1].Rows[0]["TotCstCmptdPlntMachNew"].ToString(); //commented on 24.12.2019

                if (Request.QueryString["EntrpId"].ToString() == "4338")   // need to clarify
                {
                    lblPlantMachCost.Text = NumberToCurrency(Convert.ToInt64(Convert.ToDouble(ds.Tables[1].Rows[0]["Total2ndHandMachNew"].ToString())));
                }
            }
            else lblPlantMachCost.Text = "0";

            decimal totalval = 0;
            if (Request.QueryString["EntrpId"].ToString() == "4338")
            {




                //decimal totCstCmptdLandNew_new = Convert.ToInt64(Convert.ToInt64(ds.Tables[1].Rows[0]["totCstCmptdLandNew"].ToString()));
                //decimal TotCstCmptdBldgNew_new = Convert.ToInt64(Convert.ToInt64(ds.Tables[1].Rows[0]["TotCstCmptdBldgNew"].ToString()));
                //decimal TotCstCmptdBldgNew_news = Convert.ToInt64(Convert.ToInt64(ds.Tables[1].Rows[0]["Total2ndHandMachNew"].ToString()));
                //totalval = totCstCmptdLandNew_new + TotCstCmptdBldgNew_new + TotCstCmptdBldgNew_news;



                decimal totCstCmptdLandNew_new, TotCstCmptdBldgNew_new, TotCstCmptdBldgNew_news;
                if (ds.Tables[1].Rows[0]["totCstCmptdLandNew"].ToString() != "")
                    totCstCmptdLandNew_new = Convert.ToDecimal(ds.Tables[1].Rows[0]["totCstCmptdLandNew"].ToString());
                else if (ds.Tables[1].Rows[0]["totCstCmptdLandNew"].ToString() == "")
                    totCstCmptdLandNew_new = 0;
                if (ds.Tables[1].Rows[0]["TotCstCmptdBldgNew"].ToString() != "")
                    TotCstCmptdBldgNew_new = Convert.ToDecimal(ds.Tables[1].Rows[0]["TotCstCmptdBldgNew"].ToString());
                else if (ds.Tables[1].Rows[0]["TotCstCmptdBldgNew"].ToString() == "")
                    TotCstCmptdBldgNew_new = 0;
                if (ds.Tables[1].Rows[0]["Total2ndHandMachNew"].ToString() != "")
                    TotCstCmptdBldgNew_news = Convert.ToDecimal(ds.Tables[1].Rows[0]["Total2ndHandMachNew"].ToString());
                else if (ds.Tables[1].Rows[0]["Total2ndHandMachNew"].ToString() == "")
                    TotCstCmptdBldgNew_news = 0;

                //totalval = Convert.ToDecimal(Convert.ToDouble(ds.Tables[1].Rows[0]["totCstCmptdLandNew"].ToString())) +
                //           Convert.ToDecimal(Convert.ToDouble(ds.Tables[1].Rows[0]["TotCstCmptdBldgNew"].ToString())) +
                //           Convert.ToDecimal(Convert.ToDouble(ds.Tables[1].Rows[0]["Total2ndHandMachNew"].ToString()));


            }
            else
            {
                if (ds.Tables[1].Rows[0]["TotCstCmptdPlntMachNew"].ToString() != "")
                    lblPlantMachCost.Text = NumberToCurrencys(Convert.ToInt64(Convert.ToDouble(ds.Tables[1].Rows[0]["TotCstCmptdPlntMachNew"].ToString())));

                if (ds.Tables[1].Rows[0]["TotCstCmptdPlntMachNew"].ToString() == "")
                {

                    ds.Tables[1].Rows[0]["TotCstCmptdPlntMachNew"] = "0";
                }

                //totalval = Convert.ToDecimal(Convert.ToDouble(ds.Tables[1].Rows[0]["totCstCmptdLandNew"].ToString())) +
                //   Convert.ToDecimal(Convert.ToDouble(ds.Tables[1].Rows[0]["TotCstCmptdBldgNew"].ToString())) +
                //   Convert.ToDecimal(Convert.ToDouble(ds.Tables[1].Rows[  0]["TotCstCmptdPlntMachNew"].ToString()));

                decimal totCstCmptdLandNewr_new1=0, TotCstCmptdBldgNewr_new2=0, TotCstCmptdBldgNewr_ne3=0;
                if (ds.Tables[1].Rows[0]["totCstCmptdLandNew"].ToString() != "")
                    totCstCmptdLandNewr_new1 = Convert.ToDecimal(ds.Tables[1].Rows[0]["totCstCmptdLandNew"].ToString());
                if (ds.Tables[1].Rows[0]["totCstCmptdLandNew"].ToString() == "")
                    totCstCmptdLandNewr_new1 = 0;
                if (ds.Tables[1].Rows[0]["TotCstCmptdBldgNew"].ToString() != "")
                    TotCstCmptdBldgNewr_new2 = Convert.ToDecimal(ds.Tables[1].Rows[0]["TotCstCmptdBldgNew"].ToString());
                if (ds.Tables[1].Rows[0]["TotCstCmptdBldgNew"].ToString() == "")
                    TotCstCmptdBldgNewr_new2 = 0;
                if (ds.Tables[1].Rows[0]["TotCstCmptdPlntMachNew"].ToString() != "")
                    TotCstCmptdBldgNewr_ne3 = Convert.ToDecimal(ds.Tables[1].Rows[0]["TotCstCmptdPlntMachNew"].ToString());
                if (ds.Tables[1].Rows[0]["TotCstCmptdPlntMachNew"].ToString() == "")
                    TotCstCmptdBldgNewr_ne3 = 0;

                totalval = totCstCmptdLandNewr_new1 + TotCstCmptdBldgNewr_new2 + TotCstCmptdBldgNewr_ne3;

                //TotCstCmptdBldgNew_new2 = Convert.ToDecimal(ds.Tables[1].Rows[0]["TotCstCmptdBldgNew"].ToString());
                //TotCstCmptdBldgNew_ne3 =  Convert.ToDecimal(ds.Tables[1].Rows[0]["TotCstCmptdPlntMachNew"].ToString());

            }
            //lblTotal.Text = NumberToCurrencys(Convert.ToInt64(totalval.ToString()));
            //lblComputedCost.Text = NumberToCurrencys(Convert.ToInt64(totalval.ToString()));

            lblTotal.Text = NumberToCurrencys(Convert.ToDecimal(totalval.ToString()));
            lblComputedCost.Text = NumberToCurrencys(Convert.ToDecimal(totalval.ToString()));  //changed..

            decimal computedcost2 = (totalval * Convert.ToDecimal(lblpercentage2.Text)) / 100;
            string caste2 = "";
            caste2 = ViewState["caste"].ToString();
            if (caste2 == "SC" || caste2 == "ST" || caste2 == "PHC")
            {
                if (computedcost2 > 7500000)
                {
                    computedcost2 = 7500000;
                }
            }
            else if (caste2 == "GEN")
            {
                if (computedcost2 > 2000000)
                {
                    computedcost2 = 2000000;
                }
            }
            lblComputedCost2.Text = NumberToCurrencys(Convert.ToInt64(computedcost2));
        }
    }

    #region "Number To Text"
    public string NumberToText(int number)
    {
        if (number == 0) return "Zero";
        int[] num = new int[4];
        int first = 0;
        int u, h, t;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        if (number < 0)
        {
            sb.Append("Minus ");
            number = -number;
        }
        string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };
        string[] words1 = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };
        string[] words2 = { "Twenty ", "Thirty ", "Fourty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };
        string[] words3 = { "Thousand ", "Lakh ", "Crore " };
        num[0] = number % 1000; // units
        num[1] = number / 1000;
        num[2] = number / 100000;
        num[1] = num[1] - 100 * num[2]; // thousands
        num[3] = number / 10000000; // crores
        num[2] = num[2] - 100 * num[3]; // lakhs
        for (int i = 3; i > 0; i--)
        {
            if (num[i] != 0)
            {
                first = i;
                break;
            }
        }
        for (int i = first; i >= 0; i--)
        {
            if (num[i] == 0) continue;
            u = num[i] % 10; // ones
            t = num[i] / 10;
            h = num[i] / 100; // hundreds
            t = t - 10 * h; // tens
            if (h > 0) sb.Append(words0[h] + "Hundred ");
            if (u > 0 || t > 0)
            {
                //if (h > 0 || i == 0) sb.Append("and ");
                if (t == 0)
                    sb.Append(words0[u]);
                else if (t == 1)
                    sb.Append(words1[u]);
                else
                    sb.Append(words2[t - 2] + words0[u]);
            }
            if (i != 0) sb.Append(words3[i - 1]);
        }


        // TextBox2.Text = "Rupees " + sb.ToString().TrimEnd() + " Only";
        return sb.ToString().TrimEnd();
    }
    #endregion

    #region "Number to Currency Format"

    public string NumberToCurrency(object Number)
    {
        return string.Format(new CultureInfo("en-IN"), "{0:C}", Number).Remove(0, 2).Trim();
    }

    public string NumberToCurrencys(decimal Number)
    {
        return string.Format(new CultureInfo("en-IN"), "{0:C}", Number).Remove(0, 2).Trim();
    }

    #endregion



}