using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

public partial class UI_TSiPASS_IPORptStampDutySubsidyDraft : System.Web.UI.Page
{
    IncentiveVosIncetForms objvoA = new IncentiveVosIncetForms();
    General Gen = new General();
    BusinessLogic.DML objDml = new BusinessLogic.DML();
    DataSet ds = new DataSet();

    string IncentiveId = "";
    string MstIncentiveId = "";
    string createdby = "";
    string subsidytype = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //IncentiveId = "12345";
            //createdby = "5050";
            //MstIncentiveId = "9";

            if (Session["uid"] != null)
            {
                createdby = Session["uid"].ToString();
                if (Request.QueryString[0] != null)
                {
                    IncentiveId = Request.QueryString[0];
                }
                if (Request.QueryString[0] != null)
                {
                    MstIncentiveId = Request.QueryString[1];
                }
                DataSet ds = new DataSet();
                ds = Gen.GetIPORecommendationOfficerDetailsStampDuty(IncentiveId, MstIncentiveId, createdby);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["UnitName"].ToString() != null)
                    {
                        lblunitname.Text = ds.Tables[0].Rows[0]["UnitName"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["ApplciantName"].ToString() != null)
                    {
                        lblapplicantname.Text = ds.Tables[0].Rows[0]["ApplciantName"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["applicationno"].ToString() != null)
                    {
                        lblapplicantno.Text = ds.Tables[0].Rows[0]["applicationno"].ToString();
                    }
                    lblsubsidytype.Text = ds.Tables[0].Rows[0]["IncentiveName"].ToString();
                    if (ds.Tables[0].Rows[0]["LandPurchaseExemption"].ToString() != null && ds.Tables[0].Rows[0]["LandPurchaseExemption"].ToString() != "")
                    {
                        lblexemptiononland.Text = "Rs." + ds.Tables[0].Rows[0]["LandPurchaseExemption"].ToString();
                        lblexemptiononlandYesNo.Visible = false;
                    }
                    else
                    {
                        lblexemptiononlandYesNo.Text = "No";
                        lblexemptiononlandYesNo.Visible = true;
                    }
                    if (ds.Tables[0].Rows[0]["StampDutyOrTransferDuty"].ToString() != null)
                    {
                        txtstampduty.Text = "Rs." + ds.Tables[0].Rows[0]["StampDutyOrTransferDuty"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["MortgageAndHypothecationsDuty"].ToString() != null)
                    {
                        txtMortgageDuty.Text = "Rs." + ds.Tables[0].Rows[0]["MortgageAndHypothecationsDuty"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["LandConversionCharges"].ToString() != null)
                    {
                        txtLandConversionCharges.Text = "Rs." + ds.Tables[0].Rows[0]["LandConversionCharges"].ToString();
                    }

                    if (ds.Tables[0].Rows[0]["IsDlcOrSlc"].ToString() != null)
                    {
                        lblslcdlc.Text = ds.Tables[0].Rows[0]["IsDlcOrSlc"].ToString();
                    }

                    if (ds.Tables[0].Rows[0]["LandPurcasedCost"].ToString() != null)
                    {
                        txtLandCost.Text = "Rs." + ds.Tables[0].Rows[0]["LandPurcasedCost"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["Remarks"].ToString() != null)
                    {
                        lblremarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["EmpName"].ToString() != null)
                    {
                        lblName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString() + "</br>" + ds.Tables[0].Rows[0]["Designation"].ToString() + "</br>" + ds.Tables[0].Rows[0]["Dist"].ToString();
                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        //string caste = ds.Tables[0].Rows[0]["caste"].ToString();
                        if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() == "Y") //   if (caste == "3" || caste == "4")   //SC, ST
                        {
                            lblheadTPRIDE.Text = "<center>T-PRIDE (TSCP)</center>";
                            lblSchemesCheck.Text = "T-PRIDE";
                        }
                        else if (ds.Tables[0].Rows[0]["TSPflag"].ToString() == "Y")
                        {
                            lblheadTPRIDE.Text = "<center>T-PRIDE (TSP)</center>";
                            lblSchemesCheck.Text = "T-PRIDE";

                        }
                        else if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() == "Y")
                        {
                            lblheadTPRIDE.Text = "<center>T-IDEA</center>";
                            lblSchemesCheck.Text = "T-IDEA";

                        }

                    }
                    if (ds.Tables[0].Rows[0]["MSME_Applied"].ToString() == "Y")
                    {

                        lblheadTPRIDE.Text = lblheadTPRIDE.Text.Replace("T-PRIDE", "MSME-2024 ").Replace("T-IDEA", "MSME-2024 ");
                        lblSchemesCheck.Text = lblSchemesCheck.Text.Replace("T-PRIDE", "MSME-2024 ").Replace("T-IDEA", "MSME-2024 ");


                    }

                    if (ds.Tables[0].Rows[0]["claimedfinyear"].ToString() != null && ds.Tables[0].Rows[0]["claimedfinyear"].ToString() != "")
                    {
                        lblclaimedfinyeardtls.Text = ds.Tables[0].Rows[0]["claimedfinyear"].ToString();
                        trfinyear.Visible = true;
                    }
                    else
                    {
                        trfinyear.Visible = false;
                    }
                }

                if (MstIncentiveId == "14")
                {
                    TrStampduty1.Visible = true;
                    TrStampduty2.Visible = false;
                    TrStampduty3.Visible = false;
                    TrStampduty4.Visible = false;
                    tdTrStampduty1.InnerText = "5.";
                    tdTrStampduty5.InnerText = "6.";
                    tdTrStampduty6.InnerText = "7.";
                    tdTrStampduty7.InnerText = "8.";
                    

                    txtMortgageDuty.Text = "0";
                    txtLandConversionCharges.Text = "0";
                    txtLandCost.Text = "0";
                }
                else if (MstIncentiveId == "15")
                {
                    TrStampduty1.Visible = false;
                    TrStampduty2.Visible = true;
                    TrStampduty3.Visible = false;
                    TrStampduty4.Visible = false;
                    tdTrStampduty2.InnerText = "5.";
                    tdTrStampduty5.InnerText = "6.";
                    tdTrStampduty6.InnerText = "7.";
                    tdTrStampduty7.InnerText = "8.";

                    txtstampduty.Text = "0";
                    txtLandConversionCharges.Text = "0";
                    txtLandCost.Text = "0";
                }
                else if (MstIncentiveId == "16")
                {
                    TrStampduty1.Visible = false;
                    TrStampduty2.Visible = false;
                    TrStampduty3.Visible = true;
                    TrStampduty4.Visible = false;
                    tdTrStampduty3.InnerText = "5.";
                    tdTrStampduty5.InnerText = "6.";
                    tdTrStampduty6.InnerText = "7.";
                    tdTrStampduty7.InnerText = "8.";
                   

                    txtstampduty.Text = "0";
                    txtMortgageDuty.Text = "0";
                    txtLandCost.Text = "0";
                }
                else if (MstIncentiveId == "17")
                {
                    TrStampduty1.Visible = false;
                    TrStampduty2.Visible = false;
                    TrStampduty3.Visible = false;
                    TrStampduty4.Visible = true;
                    tdTrStampduty4.InnerText = "5.";
                    tdTrStampduty5.InnerText = "6.";
                    tdTrStampduty6.InnerText = "7.";
                    tdTrStampduty7.InnerText = "8";
                    

                    txtstampduty.Text = "0";
                    txtMortgageDuty.Text = "0";
                    txtLandConversionCharges.Text = "0";
                }
                else
                {
                    TrStampduty1.Visible = true;
                    TrStampduty2.Visible = true;
                    TrStampduty3.Visible = true;
                    TrStampduty4.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            lblerrormsg.Text = ex.Message;
        }
    }
}