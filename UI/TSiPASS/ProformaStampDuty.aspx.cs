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


public partial class UI_TSiPASS_ProformaStampDuty : System.Web.UI.Page
{
    General Gen = new General();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("../../frmUserLogin.aspx");
        }

        if (Session["uid"] != null)
        {

            if (Request.QueryString.Count > 0 && Request.QueryString["incentiveid"] != null)
            {
                string userid = Session["uid"].ToString();
                string incentiveid = "", Mstincentiveid = "";
                incentiveid = Request.QueryString["incentiveid"].ToString();
                Mstincentiveid = Request.QueryString["MstIncentiveId"].ToString();
                //incentiveid = "1098";

                if (Mstincentiveid == "14")
                {
                    Label1.Text = "Stamp Duty/Transfer Duty";
                    Label3.Text = "Stamp Duty/Transfer Duty";
                    Label4.Text = "Stamp Duty/Transfer Duty";
                    Label5.Text = "Stamp Duty/Transfer Duty";
                    Label6.Text = "Stamp Duty/Transfer Duty";
                    Label7.Text = "Stamp Duty/Transfer Duty";
                }
                else if (Mstincentiveid == "15")
                {
                    Label1.Text = "Mortgage Duty";
                    Label3.Text = "Mortgage Duty";
                    Label4.Text = "Mortgage Duty";
                    Label5.Text = "Mortgage Duty";
                    Label6.Text = "Mortgage Duty";
                    Label7.Text = "Mortgage Duty";
                }
                else if (Mstincentiveid == "16")
                {
                    Label1.Text = "Land Conversion Charges";
                    Label3.Text = "Land Conversion Charges";
                    Label4.Text = "Land Conversion Charges";
                    Label5.Text = "Land Conversion Charges";
                    Label6.Text = "Land Conversion Charges";
                    Label7.Text = "Land Conversion Charges";
                }
                else if (Mstincentiveid == "17")
                {
                    Label1.Text = "Land Cost Purchased in IE/IDA/IP’s";
                    Label3.Text = "Land Cost Purchased in IE/IDA/IP’s";
                    Label4.Text = "Land Cost Purchased in IE/IDA/IP’s";
                    Label5.Text = "Land Cost Purchased in IE/IDA/IP’s";
                    Label6.Text = "Land Cost";
                    Label7.Text = "Land Cost Purchased in IE/IDA/IP’s";
                }
                else
                {
                    Label1.Text = "Stamp Duty/Transfer Duty / Mortgage Duty / Land Conversion Charges / Land Cost Purchased in IE/IDA/IP’s";
                    Label3.Text = "Stamp Duty/Transfer Duty / Mortgage Duty / Land Conversion Charges / Land Cost Purchased in IE/IDA/IP’s";
                    Label4.Text = "Stamp Duty/Transfer Duty / Mortgage Duty / Land Conversion Charges / Land Cost Purchased in IE/IDA/IP’s";
                    Label5.Text = "Stamp Duty/Transfer Duty / Mortgage Duty / Land Conversion Charges / Land Cost Purchased in IE/IDA/IP’s";
                    Label6.Text = "Stamp Duty/Transfer Duty / Mortgage Duty / Land Conversion Charges / Land Cost";
                    Label7.Text = "Stamp Duty/Transfer Duty / Mortgage Duty / Land Conversion Charges / Land Cost Purchased in IE/IDA/IP’s";
                }

                DataSet ds2 = new DataSet();
                ds2 = Gen.GetBasicUnitDetails_Proforma_letters(incentiveid, Mstincentiveid);
                binddatanew(ds2);
                DataSet dsname = new DataSet();
                //dsname = Gen.GetIPORecommendationOfficerDetailsDIC(incentiveid, Mstincentiveid, "");
                //if (dsname.Tables.Count > 0 && dsname.Tables[0].Rows.Count > 0)
                //{
                //    if (dsname.Tables[0].Rows[0]["GMNamerecom"].ToString() != null)
                //    {
                //        lblName.Text = dsname.Tables[0].Rows[0]["GMNamerecom"].ToString() + "</br>" + dsname.Tables[0].Rows[0]["GMDesignation"].ToString() + "</br>" + dsname.Tables[0].Rows[0]["Dist"].ToString();
                //    }
                //}

                dsname = Gen.GetIncentiveOfficerNamesForAll(incentiveid, Mstincentiveid, userid, "", "RECOMMENDATION");
                if (dsname.Tables.Count > 0 && dsname.Tables[0].Rows.Count > 0)
                {
                    if (dsname.Tables[0].Rows[0]["GMNamerecom"].ToString() != null)
                    {
                        lblName.Text = dsname.Tables[0].Rows[0]["GMNamerecom"].ToString() + "</br>" + dsname.Tables[0].Rows[0]["Designation"].ToString() + "</br>" + " GM DIC-" + dsname.Tables[0].Rows[0]["WorkingDistrict"].ToString();
                    }
                }
            }

        }

    }



    public void binddatanew(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["LineofActivity"].ToString() != null || ds.Tables[0].Rows[0]["LineofActivity"].ToString() != string.Empty)
            {
                lblloa.Text = ds.Tables[0].Rows[0]["LineofActivity"].ToString();
            }
            if (ds.Tables[0].Rows[0]["unitdistrict"].ToString() != null || ds.Tables[0].Rows[0]["unitdistrict"].ToString() != string.Empty)
            {
                lblDistrict.Text = ds.Tables[0].Rows[0]["unitdistrict"].ToString();
            }
            if (ds.Tables[0].Rows[0]["applicationno"].ToString() != null || ds.Tables[0].Rows[0]["applicationno"].ToString() != string.Empty)
            {
                lblLetterNo.Text = "COI/" + ds.Tables[0].Rows[0]["applicationno"].ToString();
            }
            if (ds.Tables[0].Rows[0]["todaydate"].ToString() != null || ds.Tables[0].Rows[0]["todaydate"].ToString() != "") // need to Clarify
            {
                lblLetterDate.Text = ds.Tables[0].Rows[0]["RecommendedDate"].ToString();  //changed from today date to RecommendedDate
            }

            if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() != "" || ds.Tables[0].Rows[0]["TIDEAflag"].ToString() != null)
            {
                if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() == "Y")
                {
                    lblTIdeaTPride1.Text = "T-IDEA";
                    lblTIdeaTPride2.Text = "T-IDEA";
                    lblTIdeaTPride3.Text = "T-IDEA";
                }
            }
            if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() != "" || ds.Tables[0].Rows[0]["TSCPflag"].ToString() != null)
            {

                if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() == "Y")
                {
                    lblTIdeaTPride1.Text = "T-PRIDE(TSCP)";
                    lblTIdeaTPride2.Text = "T-PRIDE(TSCP)";
                    lblTIdeaTPride3.Text = "T-PRIDE(TSCP)";
                }
            }
            if (ds.Tables[0].Rows[0]["TSPflag"].ToString() != "" || ds.Tables[0].Rows[0]["TSPflag"].ToString() != null)
            {
                if (ds.Tables[0].Rows[0]["TSPflag"].ToString() == "Y")
                {
                    lblTIdeaTPride1.Text = "T-PRIDE(TSP)";
                    lblTIdeaTPride2.Text = "T-PRIDE(TSP)";
                    lblTIdeaTPride3.Text = "T-PRIDE(TSP)";
                }
            }
            if (ds.Tables[0].Rows[0]["scheme"].ToString() != "" || ds.Tables[0].Rows[0]["scheme"].ToString() != null)
            {
                if (ds.Tables[0].Rows[0]["IDFOODPROCESSING"].ToString() == "Y")
                {
                    lblTIdeaTPride1.Text = "TFAP";
                    lblTIdeaTPride2.Text = "TFAP";
                    lblTIdeaTPride3.Text = "TFAP";
                }
            }
            if (ds.Tables[0].Rows[0]["MSME_Applied"].ToString() == "Y")
            {
                
                lblTIdeaTPride1.Text = lblTIdeaTPride1.Text.Replace("T-PRIDE", "MSME-2024 ").Replace("T-IDEA", "MSME-2024 ");
                lblTIdeaTPride2.Text = lblTIdeaTPride2.Text.Replace("T-PRIDE", "MSME-2024 ").Replace("T-IDEA", "MSME-2024 ");
                lblTIdeaTPride3.Text = lblTIdeaTPride3.Text.Replace("T-PRIDE", "MSME-2024 ").Replace("T-IDEA", "MSME-2024 ");

            }

            if (ds.Tables[0].Rows[0]["UnitDtls"].ToString() != null || ds.Tables[0].Rows[0]["UnitDtls"].ToString() != "")
            {
                lblEnterpreneurDetails1.Text = ds.Tables[0].Rows[0]["UnitDtls"].ToString();
                lblEnterpreneurDetails2.Text = ds.Tables[0].Rows[0]["UnitDtls"].ToString();
            }
            if (ds.Tables[0].Rows[0]["IncentveID"].ToString() != null || ds.Tables[0].Rows[0]["IncentveID"].ToString() != "")
            {
                lblRefApplicationNo.Text = "COI/" + ds.Tables[0].Rows[0]["IncentveID"].ToString();
            }
            if (ds.Tables[0].Rows[0]["ApplicationDate"].ToString() != null || ds.Tables[0].Rows[0]["ApplicationDate"].ToString() != "")
            {
                lblRefApplnDate.Text = ds.Tables[0].Rows[0]["ApplicationDate"].ToString();
            }
            if (ds.Tables[0].Rows[0]["DCPNew"].ToString() != null || ds.Tables[0].Rows[0]["DCPNew"].ToString() != "")
            {
                lblDCP.Text = ds.Tables[0].Rows[0]["DCPNew"].ToString();
            }
            
            if (ds.Tables[0].Rows[0]["UdyogAadharType"].ToString() != null || ds.Tables[0].Rows[0]["UdyogAadharType"].ToString() != "") // need to Clarify
            {
                string udyognotype = ds.Tables[0].Rows[0]["UdyogAadharType"].ToString();
                //if (udyognotype == "1")
                //{
                if (ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != null || ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != "") // need to Clarify
                {
                    lbludyogaadharno.Text = ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString() != null || ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString() != "") // need to Clarify
                {
                    lblUdyogAadhaardate.Text = ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString();
                }

                // }
            }
            if (ds.Tables[0].Rows[0]["TinNO"].ToString() != null || ds.Tables[0].Rows[0]["TinNO"].ToString() != "") // need to Clarify
            {
                //lblTinno.Text = ds.Tables[0].Rows[0]["TinNO"].ToString();
            }

        }

        //  Tables[1] 
        if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
        {
            if (ds.Tables[1].Rows[0]["InpectedDate"].ToString() != null || ds.Tables[1].Rows[0]["InpectedDate"].ToString() != "")
            {
                lblinspecteddt.Text = ds.Tables[1].Rows[0]["InpectedDate"].ToString();
            }
           
        }

        //  Tables[2] 
        if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
        {
            //if (ds.Tables[2].Rows[0]["FinancialYearNew"].ToString() != null && ds.Tables[2].Rows[0]["FinancialYearNew"].ToString() != "")
            //{
            //    lblFinancialYear2.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();
            //    lblFinancialYear3.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();
            //    lblFinancialYear4.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();

            //}
            lblFinancialYear2.Text = "2016-17";
            lblFinancialYear3.Text = "2016-17";
            lblFinancialYear4.Text = "2016-17";

            if (ds.Tables[2].Rows[0]["StampTranfrDutyAP"].ToString() != null || ds.Tables[2].Rows[0]["StampTranfrDutyAP"].ToString() != "")
            {
                if (ds.Tables[2].Rows[0]["FinalTotalAmountPaid"].ToString() != null && ds.Tables[2].Rows[0]["FinalTotalAmountPaid"].ToString() != "")
                {
                    lblSTAmountPaid.Text = ds.Tables[2].Rows[0]["FinalTotalAmountPaid"].ToString();
                }
                //if (ds.Tables[2].Rows[0]["StampTranfrDutyAP"].ToString() != null && ds.Tables[2].Rows[0]["StampTranfrDutyAP"].ToString() != "")
                //{
                //    lblStampTransferDutyPaid.Text = ds.Tables[2].Rows[0]["StampTranfrDutyAP"].ToString();
                //    trStamptransferDuty.Visible = true;

                //    lblSTAmountPaid.Text = ds.Tables[2].Rows[0]["StampTranfrDutyAP"].ToString();

                //    lblSTAmountPaid3.Text = ds.Tables[2].Rows[0]["StampTranfrDutyAP"].ToString();               // for testing only
                //    int AmountPaid = Convert.ToInt32(Convert.ToDouble(lblSTAmountPaid.Text.ToString()));
                //    lblSanctionedAmtDesc.Text = Gen.NumberToWord(AmountPaid);
                //}
                //if (ds.Tables[2].Rows[0]["MortgageHypothDutyAP"].ToString() != null && ds.Tables[2].Rows[0]["MortgageHypothDutyAP"].ToString() != "")
                //{
                //    lblMortgageDutyPaid.Text = ds.Tables[2].Rows[0]["MortgageHypothDutyAP"].ToString();
                //    trMortgageDutyPaid.Visible = true;
                //}
                //if (ds.Tables[2].Rows[0]["LandConvrChrgAP"].ToString() != null && ds.Tables[2].Rows[0]["LandConvrChrgAP"].ToString() != "")
                //{
                //    lblLandConversionCharges.Text = ds.Tables[2].Rows[0]["LandConvrChrgAP"].ToString();
                //    trLandConversionCharges.Visible = true;
                //}
                //if (ds.Tables[2].Rows[0]["LandCostIeIdaIpAP"].ToString() != null && ds.Tables[2].Rows[0]["LandCostIeIdaIpAP"].ToString() != "")
                //{
                //    lblLandConversionCharges.Text = ds.Tables[2].Rows[0]["LandCostIeIdaIpAP"].ToString();
                //    trLandConversionCharges.Visible = false;
                //}


            }


            // need to clarify
            lbl1st2nd1.Text = "2nd";
            lbl1st2nd2.Text = "2nd";
            lbl1st2nd3.Text = "2nd";

        }

        // Tables[3]
        if (ds != null && ds.Tables.Count > 2 && ds.Tables[3].Rows.Count > 0)
        {
            if (ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString() != null && ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString() != "")
            {
                lblFinalStampduty.Text = ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString();
                lblSTAmountPaid3.Text = ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString();

                int AmountPaid = Convert.ToInt32(Convert.ToDouble(lblSTAmountPaid3.Text.ToString()));
                lblSanctionedAmtDesc.Text = Gen.NumberToWord(AmountPaid);
            }
        }
        
    }
}