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

public partial class UI_TSiPASS_ProformaApplicantPavalaVaddiSubsidy : System.Web.UI.Page
{
    General Gen = new General();
    string incentiveid = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count > 0 && Request.QueryString["incentiveid"] != null)
        {
            //string userid = Session["uid"].ToString();
            incentiveid = Request.QueryString["incentiveid"].ToString();

            DataSet dsnew = new DataSet();
            dsnew = Gen.GetSLCDetails(incentiveid, "1");
            fillSLCDetails(dsnew);
            lblIncentiVeID.Text = incentiveid;
        }
        GM_id.Visible = false;

        DataSet dsname = new DataSet();
        dsname = Gen.GetIncentiveOfficerNamesForAll(incentiveid, "1", "0", "", "INTIMATION");
        if (dsname.Tables.Count > 0 && dsname.Tables[0].Rows.Count > 0)
        {
            string DIPCFlag = dsname.Tables[0].Rows[0]["DIPCFlag"].ToString();
            if (dsname.Tables[0].Rows[0]["GMNamerecom"].ToString() != null)
            {
                if (DIPCFlag == "Y")
                {
                    lblAddlDir_Name.Text = dsname.Tables[0].Rows[0]["GMNamerecom"].ToString() + "<br/>" + dsname.Tables[0].Rows[0]["Designation"].ToString() + "<br/>" + "DIC" + "-" + dsname.Tables[0].Rows[0]["WorkingDistrict"].ToString();
                }
                else
                {
                    //lblAddlDir_Name.Text = dsname.Tables[0].Rows[0]["GMNamerecom"].ToString() + "<br/>" + "Additional Director" + "<br/>" + "O/o. Commissioner of Industries";
                    lblAddlDir_Name.Text = dsname.Tables[0].Rows[0]["GMNamerecom"].ToString() + "<br/>" + dsname.Tables[0].Rows[0]["Designation"].ToString() + "<br/>" + "O/o. Commissioner of Industries";
                }
            }
        }
        //}
    }

    public void fillSLCDetails(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            string DipcCoiFlag = "";
            if (ds.Tables[0].Rows[0]["DIPCFlag"].ToString() != null && ds.Tables[0].Rows[0]["DIPCFlag"].ToString() != "")
            {
                DipcCoiFlag = ds.Tables[0].Rows[0]["DIPCFlag"].ToString();
            }
            

            if (ds.Tables[0].Rows[0]["todaydate"].ToString() != null && ds.Tables[0].Rows[0]["todaydate"].ToString() != "")
            {
                lblLetterDate.Text = ds.Tables[0].Rows[0]["todaydate"].ToString();
            }

            if (ds.Tables[0].Rows[0]["Gmrecommdate"].ToString() != null && ds.Tables[0].Rows[0]["Gmrecommdate"].ToString() != "")
            {
                lblLrDate.Text = ds.Tables[0].Rows[0]["Gmrecommdate"].ToString();
            }

            if (DipcCoiFlag == "Y")
            {
                lblCoiDipcHead.Text = "DISTRICT INDUSTRIES CENTER";
                if (ds.Tables[1].Rows[0]["District_Name"].ToString() != null && ds.Tables[1].Rows[0]["District_Name"].ToString() != "")
                {
                    lblCoiDipcDist.Text = ds.Tables[1].Rows[0]["District_Name"].ToString().ToUpper();
                }
                if (ds.Tables[1].Rows[0]["MeetingNumber"].ToString() != null && ds.Tables[1].Rows[0]["MeetingNumber"].ToString() != "")
                {
                    lblSLCNo.Text = ds.Tables[1].Rows[0]["MeetingNumber"].ToString();
                }
                lblFooter.Visible = false;
                lblFooter.Text = "DISTRICT INDUSTRIES CENTER-" + lblCoiDipcDist.Text + " website: http://www.industries.telangana.gov.in";

                if (ds.Tables[1].Rows[0]["applicationno"].ToString() != "" && ds.Tables[1].Rows[0]["applicationno"].ToString() != null)
                {
                    lblLetterNo.Text = "DIPC/" + ds.Tables[1].Rows[0]["applicationno"].ToString();
                    lblLRNo.Text = "DIPC/" + ds.Tables[1].Rows[0]["applicationno"].ToString();
                    lblSLCorDIPC.Text = "DIPC";
                }
            }
            else
            {
                if (ds.Tables[0].Rows[0]["SLCNumber"].ToString() != null && ds.Tables[0].Rows[0]["SLCNumber"].ToString() != "")
                {
                    lblSLCNo.Text = ds.Tables[0].Rows[0]["SLCNumber"].ToString();
                }
                if (ds.Tables[1].Rows[0]["applicationno"].ToString() != "" && ds.Tables[1].Rows[0]["applicationno"].ToString() != null)
                {
                    lblLetterNo.Text = "COI/" + ds.Tables[1].Rows[0]["applicationno"].ToString();
                    lblLRNo.Text = "COI/" + ds.Tables[1].Rows[0]["applicationno"].ToString();
                    lblSLCorDIPC.Text = "SLC";
                }
            }
           
            if (ds.Tables[0].Rows[0]["SLCDateNew"].ToString() != null && ds.Tables[0].Rows[0]["SLCDateNew"].ToString() != "")
            {
                lblSLCDate.Text = ds.Tables[0].Rows[0]["SLCDateNew"].ToString();
            }

            if (ds.Tables[3].Rows[0]["valueamount"].ToString() != null && ds.Tables[3].Rows[0]["valueamount"].ToString() != "")
            {
                lblSanctionedAmount.Text = ds.Tables[3].Rows[0]["valueamount"].ToString();
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
        }

        //DateTime DCPBaseDate = Convert.ToDateTime("2014/11/29");  //("29-11-2014");

        if (ds != null && ds.Tables.Count > 1 && ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
        {
            //if (ds.Tables[1].Rows[0]["DCP"].ToString() != "" && ds.Tables[1].Rows[0]["DCP"].ToString() != null)
            //{
            //    DateTime DCP1 = Convert.ToDateTime(ds.Tables[1].Rows[0]["DCP"].ToString());
            //    if (DCP1 > DCPBaseDate)
            //    {
            //        // lblTIdeaTPrideIIPP1.Text = "T-IDEA"; CHANGED ON 10.01.2019

            //        lblTIdeaTPrideIIPP1.Text = ds.Tables[1].Rows[0]["SCHEME"].ToString();
            //        lblTIdeaTPrideIIPP2.Text = "T-IDEA";
            //        lblTIdeaTPrideIIPP3.Text = "T-IDEA";
            //    }
            //    else
            //    {
            //        lblTIdeaTPrideIIPP1.Text = "IIPP 2010-2015";
            //        lblTIdeaTPrideIIPP2.Text = "IIPP 2010-2015";
            //        lblTIdeaTPrideIIPP3.Text = "IIPP 2010-2015";
            //    }
            //}




            //if (ds.Tables[1].Rows[0]["EMiUdyogAadhar"].ToString() != "" && ds.Tables[1].Rows[0]["EMiUdyogAadhar"].ToString() != null)
            //{
            //    lblLetterNo.Text = "COI/" + ds.Tables[1].Rows[0]["EMiUdyogAadhar"].ToString();
            //    //lblLRNo.Text = "COI/" + ds.Tables[1].Rows[0]["EMiUdyogAadhar"].ToString();
            //}

            if (ds.Tables[1].Rows[0]["todaydate"].ToString() != null && ds.Tables[1].Rows[0]["todaydate"].ToString() != "")
            {
                lblLetterDate.Text = ds.Tables[1].Rows[0]["todaydate"].ToString();
                //lblLrDate.Text = ds.Tables[1].Rows[0]["todaydate"].ToString();
            }

            //if (ds.Tables[1].Rows[0]["APPLICATIONDATE"].ToString() != null && ds.Tables[1].Rows[0]["APPLICATIONDATE"].ToString() != "")
            //{
            //    lblRefApplnDate.Text = ds.Tables[1].Rows[0]["APPLICATIONDATE"].ToString();
            //}
            //lblRefApplicationNo.Text = "COI/" + Request.QueryString["incentiveid"].ToString();

            if (ds.Tables[1].Rows[0]["EnterpreunerDtls"].ToString() != null && ds.Tables[1].Rows[0]["EnterpreunerDtls"].ToString() != "")
            {
                lblEnterpreneurDetails1.Text = ds.Tables[1].Rows[0]["EnterpreunerDtls"].ToString();
                lblEnterpreneurDetails2.Text = ds.Tables[1].Rows[0]["EnterpreunerDtls"].ToString();
                //if (incentiveid.ToString() == "133371")
                //{
                //    divWelspun.Visible = true;
                //}
            }

            if (ds.Tables[1].Rows[0]["District_Name"].ToString() != null && ds.Tables[1].Rows[0]["District_Name"].ToString() != "")
            {
                lblDistrict.Text = ds.Tables[1].Rows[0]["District_Name"].ToString();
                lblDistrict1.Text = ds.Tables[1].Rows[0]["District_Name"].ToString();
            }

            if (ds.Tables[1].Rows[0]["BankDtls"].ToString() != null && ds.Tables[1].Rows[0]["BankDtls"].ToString() != "")
            {
                lblBankDtls.Text = ds.Tables[1].Rows[0]["BankDtls"].ToString();
            }

            if (ds != null && ds.Tables.Count > 2 && ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
            {
                if (ds.Tables[2].Rows[0]["FinYear"].ToString() != null && ds.Tables[2].Rows[0]["FinYear"].ToString() != "")
                {
                    lbl1stOR2ndHalfYearFinYearFromTo.Text = ds.Tables[2].Rows[0]["FinYear"].ToString();   // need to Clarify
                }
            }

            if (Request.QueryString["Scheme"] != null)
            {
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
                else if (scheme.Contains("MSME"))
                {
                    lbltideano.Visible = false;

                    lblyeras2.Text = lblyeras1.Text = "three (3)";
                    lblScheme_GO_Details.Text = "G.O.Ms.No. 16, Industries & Commerce (FP&MSME) Department, Dated: 18/09/2024 read with G.O.Ms No. 06, Industries & Commerce (FP&MSME) Department, Dated:23/03/2026.";
                }
            }

        }
    }
}