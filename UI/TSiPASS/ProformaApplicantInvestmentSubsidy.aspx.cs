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

public partial class UI_TSiPASS_ProformaApplicantInvestmentSubsidy : System.Web.UI.Page
{
    General Gen = new General();
    comFunctions cmf = new comFunctions();

    DataSet dsCAF = new DataSet();
    string incentiveid = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count > 0 && Request.QueryString["incentiveid"] != null)
        {
            incentiveid = Request.QueryString["incentiveid"].ToString();

            DataSet dsnew = new DataSet();
            dsnew = Gen.GetSLCDetails(incentiveid, "6");
            fillSLCDetails(dsnew);
            lblIncentiVeID.Text = incentiveid;


            DataSet dsname = new DataSet();
            dsname = Gen.GetIncentiveOfficerNamesForAll(incentiveid, "6", "0", "", "INTIMATION");
            if (dsname.Tables.Count > 0 && dsname.Tables[0].Rows.Count > 0)
            {
                string DIPCFlag = dsname.Tables[0].Rows[0]["DIPCFlag"].ToString();
                if (dsname.Tables[0].Rows[0]["GMNamerecom"].ToString() != null)
                {
                    if (DIPCFlag == "Y")
                    {
                        lblletterFromADorGM.Text = dsname.Tables[0].Rows[0]["GMNamerecom"].ToString();
                        lblAddlDir_Name.Text = dsname.Tables[0].Rows[0]["Designation"].ToString() + "<br/>" + "DIC" + "-" + dsname.Tables[0].Rows[0]["WorkingDistrict"].ToString();
                    }
                    else
                    {
                        lblletterFromADorGM.Text = dsname.Tables[0].Rows[0]["GMNamerecom"].ToString();
                        //lblAddlDir_Name.Text = "Additional Director" + "<br/>" + "O/o. Commissioner of Industries";
                        lblAddlDir_Name.Text = dsname.Tables[0].Rows[0]["Designation"].ToString() + "<br/>" + "O/o. Commissioner of Industries";


                    }
                }
            }
        }
    }
    public void fillSLCDetails(DataSet ds)
    {
        string DipcCoiFlag = "";

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            if (ds.Tables[0].Rows[0]["DIPCFlag"].ToString() != null && ds.Tables[0].Rows[0]["DIPCFlag"].ToString() != "")
            {
                DipcCoiFlag = ds.Tables[0].Rows[0]["DIPCFlag"].ToString();
            }

            if (ds.Tables[0].Rows[0]["SLCNumber"].ToString() != null && ds.Tables[0].Rows[0]["SLCNumber"].ToString() != "")
            {
                lblSLCNo.Text = ds.Tables[0].Rows[0]["SLCNumber"].ToString();
            }
            if (ds.Tables[0].Rows[0]["SLCDateNew"].ToString() != null && ds.Tables[0].Rows[0]["SLCDateNew"].ToString() != "")
            {
                lblSLCDate.Text = ds.Tables[0].Rows[0]["SLCDateNew"].ToString();
            }
            if (ds.Tables[0].Rows[0]["todaydate"].ToString() != null && ds.Tables[0].Rows[0]["todaydate"].ToString() != "")
            {
                lblLetterDate.Text = ds.Tables[0].Rows[0]["todaydate"].ToString();
            }
            if (ds.Tables[0].Rows[0]["Gmrecommdate"].ToString() != null && ds.Tables[0].Rows[0]["Gmrecommdate"].ToString() != "")
            {
                lblRefLetterDate.Text = ds.Tables[0].Rows[0]["Gmrecommdate"].ToString();
            }
            if (ds.Tables[3].Rows[0]["valueamount"].ToString() != null && ds.Tables[3].Rows[0]["valueamount"].ToString() != "")
            {
                lblSanctionedAmount.Text = ds.Tables[3].Rows[0]["valueamount"].ToString();
                // int SLCAmount = Convert.ToInt32(lblSanctionedAmount.Text.ToString());
                // lblSanctionedAmtDesc.Text = Gen.NumberToWord(SLCAmount);

                string[] no;
                int Number;
                if (lblSanctionedAmount.Text.Contains("."))
                {
                    no = lblSanctionedAmount.Text.Split('.');
                    Number = Convert.ToInt32(no[0]);
                }
                else
                {
                    Number = Convert.ToInt32(lblSanctionedAmount.Text);
                }
                lblSanctionedAmtDesc.Text = "Rupees " + Gen.NumberToWord(Number) + " Only.";
            }
            //if (ds.Tables[0].Rows[0]["FinYear"].ToString() != null || ds.Tables[0].Rows[0]["FinYear"].ToString() != "")
            //{
            //    lbl1stOR2ndHalfYearFinYearFromTo.Text = ds.Tables[0].Rows[0]["FinYear"].ToString();
            //}


            // added on 04.09.2018 for special case
            if (Request.QueryString.Count > 0 && Request.QueryString["incentiveid"] != null)
            {
                // string userid = Session["uid"].ToString();
                incentiveid = Request.QueryString["incentiveid"].ToString();
                if (incentiveid.ToString() == "11998")
                {
                    tr11998.Visible = true;
                    lbltr11998A.Text = "Subject to condition:";
                    lbltr11998B.Text = " GHMC permission with approved plans for the leased premises";
                }
                if (incentiveid.ToString() == "28688")
                {
                    lblExtraCond.Visible = true;
                    lblExtraCond.Text = "Subject to Condition submission of Registered Saledeed.";
                }

            }
        }

        //if (Request.QueryString.Count > 0)
        //{
        //if (Request.QueryString["Scheme"] != null)
        //{
        string scheme = "";
        scheme = Request.QueryString["Scheme"].ToString();

        lblTIdeaTPrideIIPP1.Text = scheme.ToUpper();
        lblTIdeaTPrideIIPP2.Text = scheme.ToUpper();
        lblTIdeaTPrideIIPP3.Text = scheme.ToUpper();



        if (scheme.ToUpper().Contains("IDEA"))
        {
            lbltideano.Visible = true;
            lblyeras2.Text = lblyeras1.Text = "six (6)";

            lblScheme_GO_Details.Text = "G.O.Ms.No. 28, Industries & Commerce (IP) Department, dated: 29/11/2014 read with G.O.Ms No. 77, Industries & Commerce (IP & INF) Department, dt: 09/10/2015.";
        }
        else if (scheme.ToUpper().Contains("PRIDE"))
        {
            lbltideano.Visible = true;
            lblyeras2.Text = lblyeras1.Text = "six (6)";
            lblScheme_GO_Details.Text = "G.O.Ms.No. 29, Industries & Commerce (IP) Department, dated: 29/11/2014 read with G.O.Ms No. 78, Industries & Commerce (IP & INF) Department, dt: 09/10/2015.";
        }
        else if (scheme.Contains("IIPP 2010-15"))
        {
            lbltideano.Visible = true;
            lblyeras2.Text = lblyeras1.Text = "six (6)";
            lblScheme_GO_Details.Text = "G.O.Ms.No. 61, Industries & Commerce (IP) Department, dated: 29/06/2010 read with G.O.Ms No. 42, Industries & Commerce (IP ) Department, dt: 05/05/2011.";
        }
        else if (scheme.Contains("IIPP 2005-10"))
        {
            lbltideano.Visible = true;
            lblyeras2.Text = lblyeras1.Text = "six (6)";
            lblScheme_GO_Details.Text = "G.O.Ms.No. 178, Industries & Commerce (IP) Department, dated: 21/06/2005 read with G.O.Ms No. 327, Industries & Commerce (IP ) Department, dt: 13/12/2005.";
        }
        else if (scheme.Contains("TFAP"))
        {
            lbltideano.Visible = false;

            lblyeras2.Text = lblyeras1.Text = "three (6)";
            lblScheme_GO_Details.Text = "G.O.Ms.No. 18, Industries & Commerce (FP&MSME) Department, Dated: 07/08/2021;";
        }
        else if (scheme.Contains("MSME"))
        {
            lbltideano.Visible = false;

            lblyeras2.Text = lblyeras1.Text = "three (3)";
            lblScheme_GO_Details.Text = "G.O.Ms.No. 16, Industries & Commerce (FP&MSME) Department, Dated: 18/09/2024 read with G.O.Ms No. 06, Industries & Commerce (FP&MSME) Department, Dated:23/03/2026.";
        }
        // }

        decimal totCstCmptdLandNewr_new1 = 0, TotCstCmptdBldgNewr_new2 = 0, TotCstCmptdplantNewr_ne3 = 0;
        if (ds.Tables[1].Rows[0]["MACHINERY"].ToString() != null && ds.Tables[1].Rows[0]["MACHINERY"].ToString() != "")
        {
            if (ds.Tables[1].Rows[0]["LAND"].ToString() != null && ds.Tables[1].Rows[0]["LAND"].ToString() != "")
            {
                lblLandCost.Text = ds.Tables[1].Rows[0]["LAND"].ToString();
                totCstCmptdLandNewr_new1 = Convert.ToDecimal(ds.Tables[1].Rows[0]["LAND"].ToString());
            }
            else
            {
                totCstCmptdLandNewr_new1 = 0;

            }
            if (ds.Tables[1].Rows[0]["BUILDING"].ToString() != null && ds.Tables[1].Rows[0]["BUILDING"].ToString() != "")
            {
                lblBuildingCost.Text = ds.Tables[1].Rows[0]["BUILDING"].ToString();
                TotCstCmptdBldgNewr_new2 = Convert.ToDecimal(ds.Tables[1].Rows[0]["BUILDING"].ToString());
            }
            else
            {
                TotCstCmptdBldgNewr_new2 = 0;
            }
            if (ds.Tables[1].Rows[0]["MACHINERY"].ToString() != null && ds.Tables[1].Rows[0]["MACHINERY"].ToString() != "")
            {
                lblPlantMachCost.Text = ds.Tables[1].Rows[0]["MACHINERY"].ToString();
                TotCstCmptdplantNewr_ne3 = Convert.ToDecimal(ds.Tables[1].Rows[0]["MACHINERY"].ToString());
            }
            else
            {
                TotCstCmptdplantNewr_ne3 = 0;

            }
            lblTotal.Text = Convert.ToDecimal(totCstCmptdLandNewr_new1 + TotCstCmptdBldgNewr_new2 + TotCstCmptdplantNewr_ne3).ToString();
        }
        else
        {
            approved1.Visible = false;
            approved2.Visible = false;
        }
        if (ds.Tables[1].Rows[0]["APPLICATIONDATE"].ToString() != null && ds.Tables[1].Rows[0]["APPLICATIONDATE"].ToString() != "")
        {
            //lblRefLetterDate.Text = ds.Tables[1].Rows[0]["APPLICATIONDATE"].ToString();
        }

        if (ds.Tables[1].Rows[0]["EnterpreunerDtls"].ToString() != null && ds.Tables[1].Rows[0]["EnterpreunerDtls"].ToString() != "")
        {
            lblEnterpreneurDetails1.Text = ds.Tables[1].Rows[0]["EnterpreunerDtls"].ToString();
            lblEnterpreneurDetails2.Text = ds.Tables[1].Rows[0]["EnterpreunerDtls"].ToString();
            //if(incentiveid.ToString() == "133371")
            //{
            //    divWelspun.Visible = true;
            //}
        }

        if (ds.Tables[1].Rows[0]["District_Name"].ToString() != null && ds.Tables[1].Rows[0]["District_Name"].ToString() != "")
        {
            lblDistrict.Text = ds.Tables[1].Rows[0]["District_Name"].ToString();
            lblDistrict1.Text = ds.Tables[1].Rows[0]["District_Name"].ToString();
        }

        if (DipcCoiFlag == "Y")
        {
            lblCoiDipcHead.Text = "DISTRICT INDUSTRIES CENTER";
            lblSLCorDIPC.Text = "DIPC";

            if (ds.Tables[1].Rows[0]["District_Name"].ToString() != null && ds.Tables[1].Rows[0]["District_Name"].ToString() != "")
            {
                lblCoiDipcDist.Text = ds.Tables[1].Rows[0]["District_Name"].ToString().ToUpper();
            }
            lblRefLetterNo.Text = "DIPC/" + ds.Tables[1].Rows[0]["applicationno"].ToString();//Request.QueryString["incentiveid"].ToString();

            //if (ds.Tables[1].Rows[0]["EMiUdyogAadhar"].ToString() != "" && ds.Tables[1].Rows[0]["EMiUdyogAadhar"].ToString() != null)
            //{
            //    lblLetterNo.Text = "DIPC/" + ds.Tables[1].Rows[0]["EMiUdyogAadhar"].ToString();
            //}
            if (ds.Tables[1].Rows[0]["applicationno"].ToString() != "" && ds.Tables[1].Rows[0]["applicationno"].ToString() != null)
            {
                lblLetterNo.Text = "DIPC/" + ds.Tables[1].Rows[0]["applicationno"].ToString();
                //lblLetterNomngr.Text = "DIPC/" + ds.Tables[1].Rows[0]["applicationno"].ToString() + "/GMREC-IS";
            }
            // lblletterFromADorGM.Text = "DIC" + "-" + lblCoiDipcDist.Text;
            lblFooter.Visible = false;
            lblFooter.Text = "DISTRICT INDUSTRIES CENTER-" + lblCoiDipcDist.Text + " website: http://www.industries.telangana.gov.in";

            if (ds.Tables[1].Rows[0]["MeetingNumber"].ToString() != null && ds.Tables[1].Rows[0]["MeetingNumber"].ToString() != "")
            {
                lblSLCNo.Text = ds.Tables[1].Rows[0]["MeetingNumber"].ToString();
            }
        }
        else
        {
            lblSLCorDIPC.Text = "SLC";
            lblRefLetterNo.Text = "COI/" + ds.Tables[1].Rows[0]["applicationno"].ToString(); //Request.QueryString["incentiveid"].ToString();

            //if (ds.Tables[1].Rows[0]["EMiUdyogAadhar"].ToString() != "" && ds.Tables[1].Rows[0]["EMiUdyogAadhar"].ToString() != null)
            //{
            //    lblLetterNo.Text = "COI/" + ds.Tables[1].Rows[0]["EMiUdyogAadhar"].ToString();
            //}
            if (ds.Tables[1].Rows[0]["applicationno"].ToString() != "" && ds.Tables[1].Rows[0]["applicationno"].ToString() != null)
            {
                lblLetterNo.Text = "COI/" + ds.Tables[1].Rows[0]["applicationno"].ToString();
                //lblLetterNomngr.Text = "COI/" + ds.Tables[1].Rows[0]["applicationno"].ToString() + "/GMREC-IS";
            }
            //lblletterFromADorGM.Text = "Additional Director" + "<br/>" + "O/o. Commissioner of Industries";
            //if (Convert.ToInt32(lblSLCNo.Text.ToString()) > 36)
            //{
            //    //lblletterFromADorGM // lblAddlDir_Name.Text = "RAJKUMAR OHATKER";   //Rajkumar Ohatker  //lblAddlDir_Name  WIP..
            //    lblAddlDir_Name.Visible = true;
            //    lblletterFromADorGM.Text = "RAJKUMAR OHATKER";
            //    lblAddlDir_Name.Text = "Additional Director" + "<br/>" + "O/o. Commissioner of Industries";
            //}
            //else
            //{
            //    lblletterFromADorGM.Visible = false;
            //    lblAddlDir_Name.Visible = true;
            //    lblAddlDir_Name.Text = "Additional Director" + "<br/>" + "O/o. Commissioner of Industries";
            //}
        }

        if (ds != null && ds.Tables.Count > 2 && ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
        {
            //if (ds.Tables[2].Rows[0]["FinYear"].ToString() != null && ds.Tables[2].Rows[0]["FinYear"].ToString() != "")
            //{
            //    lbl1stOR2ndHalfYearFinYearFromTo.Text = "2nd Half Year of 2016-17";  // need to Clarify
            //}
        }
        // }
    }
}