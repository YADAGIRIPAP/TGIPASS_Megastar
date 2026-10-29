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

public partial class UI_TSiPASS_ProformaApplicantPowerCostSubsidy : System.Web.UI.Page
{
    General Gen = new General();
    string incentiveid = "";
    string DIPCFlag = "";
    DataSet dsDIPC = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

        //------------------------------ for testing
        //incentiveid = "1096";    
        //DataSet dsnew = new DataSet();
        //dsnew = Gen.GetSLCDetails(incentiveid, "3");
        //fillSLCDetails(dsnew);
        //------------------------------

        if (Request.QueryString.Count > 0 && Request.QueryString["incentiveid"] != null)
        {
            // string userid = Session["uid"].ToString();
            incentiveid = Request.QueryString["incentiveid"].ToString();

            DataSet dsnew = new DataSet();
            dsnew = Gen.GetSLCDetails(incentiveid, "3");
            fillSLCDetails(dsnew);
            lblIncentiVeID.Text = incentiveid;

            DataSet dsname = new DataSet();
            dsname = Gen.GetIncentiveOfficerNamesForAll(incentiveid, "3", "0", "", "INTIMATION");
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
        //  }
    }

    public void fillSLCDetails(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DIPCFlag = ds.Tables[0].Rows[0]["DIPCFlag"].ToString();
        }
        if (ds != null && ds.Tables.Count > 2 && ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
        {
            if (ds.Tables[2].Rows[0]["GMclaimedfinyear"].ToString() != null && ds.Tables[2].Rows[0]["GMclaimedfinyear"].ToString() != "")
            {
                lbl1stOR2ndHalfYearFinYearFromTo.Text = ds.Tables[2].Rows[0]["GMclaimedfinyear"].ToString();
                lblfinyearsub.Text = ds.Tables[2].Rows[0]["GMclaimedfinyear"].ToString();
            }
        }
        if (DIPCFlag == "Y")
        {
            lblcoidipc.Text = "DISTRICT INDUSTRIES CENTER :: ";
            lblSLCText.Text = "DIPC Number";
            //lbldesignation.Text = "DIC";

            if (Request.QueryString.Count > 1)
            {
                //if (Request.QueryString["Scheme"] != null)
                //{
                //    lblTIdeaTPrideIIPP1.Text = Request.QueryString["Scheme"].ToString();
                //    lblTIdeaTPrideIIPP2.Text = Request.QueryString["Scheme"].ToString();
                //    lblTIdeaTPrideIIPP3.Text = Request.QueryString["Scheme"].ToString();

                //    if (lblTIdeaTPrideIIPP1.Text.Contains("IDEA") || lblTIdeaTPrideIIPP1.Text.Contains("Pride"))
                //    {
                //        lblScheme_GO_Details.Text = "G.O.Ms.No. 28, Industries & Commerce (IP) Department, dated: 29/11/2014 read with G.O.Ms No. 77, Industries & Commerce (IP & INF) Department, dt: 09/10/2015.";
                //    }
                //    else if (lblTIdeaTPrideIIPP1.Text.Contains("IIPP 2010-15"))
                //    {
                //        lblScheme_GO_Details.Text = "G.O.Ms.No. 61, Industries & Commerce (IP) Department, dated: 29/06/2010 read with G.O.Ms No. 42, Industries & Commerce (IP ) Department, dt: 05/05/2011.";
                //    }
                //    else if (lblTIdeaTPrideIIPP1.Text.Contains("IIPP 2005-10"))
                //    {
                //        lblScheme_GO_Details.Text = "G.O.Ms.No. 178, Industries & Commerce (IP) Department, dated: 21/06/2005 read with G.O.Ms No. 327, Industries & Commerce (IP ) Department, dt: 13/12/2005.";
                //    }
                //}
                if (Request.QueryString["DIPCNumer"] != null)
                {
                    lblSLCNo.Text = Request.QueryString["DIPCNumer"].ToString();
                }
            }

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
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
                    lblLetterDatemngr.Text = ds.Tables[0].Rows[0]["Gmrecommdate"].ToString();
                }
            }

            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows[0]["EnterpreunerDtls"].ToString() != null && ds.Tables[1].Rows[0]["EnterpreunerDtls"].ToString() != "")
                {
                    lblEnterpreneurDetails1.Text = ds.Tables[1].Rows[0]["EnterpreunerDtls"].ToString();
                    lblEnterpreneurDetails2.Text = ds.Tables[1].Rows[0]["EnterpreunerDtls"].ToString();
                }

                if (ds.Tables[1].Rows[0]["District_Name"].ToString() != null && ds.Tables[1].Rows[0]["District_Name"].ToString() != "")
                {
                    lblDistrict.Text = ds.Tables[1].Rows[0]["District_Name"].ToString().ToUpper();
                    lblDistrict1.Text = ds.Tables[1].Rows[0]["District_Name"].ToString().ToUpper();
                    // lblDistrict2.Text = ds.Tables[1].Rows[0]["District_Name"].ToString().ToUpper();
                    lbladdress.Text = "DISTRICT INDUSTRIES CENTER - " + ds.Tables[1].Rows[0]["District_Name"].ToString().ToUpper();
                }

                if (ds.Tables[1].Rows[0]["applicationno"].ToString() != "" && ds.Tables[1].Rows[0]["applicationno"].ToString() != null)
                {
                    lblLetterNo.Text = "DIPC/" + ds.Tables[1].Rows[0]["applicationno"].ToString();
                    lblLetterNomngr.Text = "DIPC/" + ds.Tables[1].Rows[0]["applicationno"].ToString();// +"/GMREC-PT";
                }
                if (ds.Tables[1].Rows[0]["ProjectScheme"].ToString() != "" && ds.Tables[1].Rows[0]["ProjectScheme"].ToString() != null)
                {
                    string strscheme = "";
                    strscheme = ds.Tables[1].Rows[0]["ProjectScheme"].ToString();

                    if (strscheme == "TIDEA" || strscheme == "TPRIDE" || strscheme == "T-PRIDE")
                    {
                        if (ds.Tables[1].Rows[0]["TIDEAflag"].ToString() != "" && ds.Tables[1].Rows[0]["TIDEAflag"].ToString() != null)
                        {
                            if (ds.Tables[1].Rows[0]["TIDEAflag"].ToString() == "Y")
                            {

                                lblTIdeaTPrideIIPP1.Text = "T-IDEA";
                                lblTIdeaTPrideIIPP2.Text = "T-IDEA";
                                lblTIdeaTPrideIIPP3.Text = "T-IDEA";
                            }
                        }
                        if (ds.Tables[1].Rows[0]["TSCPflag"].ToString() != "" && ds.Tables[1].Rows[0]["TSCPflag"].ToString() != null)
                        {

                            if (ds.Tables[1].Rows[0]["TSCPflag"].ToString() == "Y")
                            {
                                lblTIdeaTPrideIIPP1.Text = "T-PRIDE(SCSDF)";////"T-PRIDE(TSCP)";T-Pride(SCSDF) CHANGED ON 01/02/2022
                                lblTIdeaTPrideIIPP2.Text = "T-PRIDE(SCSDF)";
                                lblTIdeaTPrideIIPP3.Text = "T-PRIDE(SCSDF)";

                            }
                        }
                        if (ds.Tables[1].Rows[0]["TSPflag"].ToString() != "" && ds.Tables[1].Rows[0]["TSPflag"].ToString() != null)
                        {
                            if (ds.Tables[0].Rows[0]["TSPflag"].ToString() == "Y")
                            {
                                lblTIdeaTPrideIIPP1.Text = "T-PRIDE(STSDF)";////"T-PRIDE(TSP)";T-Pride(STSDF) CHANGED ON 01/02/2022
                                lblTIdeaTPrideIIPP2.Text = "T-PRIDE(STSDF)";
                                lblTIdeaTPrideIIPP3.Text = "T-PRIDE(STSDF)";

                            }
                        }
                    }
                    else if (strscheme == "IIPP 2005-10" || strscheme == "IIPP 2010-15")
                    {
                        lblTIdeaTPrideIIPP1.Text = strscheme;
                        lblTIdeaTPrideIIPP2.Text = strscheme;
                        lblTIdeaTPrideIIPP3.Text = strscheme;
                    }

                    if (lblTIdeaTPrideIIPP1.Text.Contains("IDEA"))
                    {
                        lbltideano.Visible = true;
                        lblyeras2.Text = lblyeras1.Text = "six (6)";
                        lblScheme_GO_Details.Text = "G.O.Ms.No. 28, Industries & Commerce (IP) Department, dated: 29/11/2014 read with G.O.Ms No. 77, Industries & Commerce (IP & INF) Department, dt: 09/10/2015.";
                    }
                    else if (lblTIdeaTPrideIIPP1.Text.Contains("PRIDE"))
                    {
                        lbltideano.Visible = true;
                        lblyeras2.Text = lblyeras1.Text = "six (6)";
                        lblScheme_GO_Details.Text = "G.O.Ms.No. 29, Industries & Commerce (IP) Department, dated: 29/11/2014 read with G.O.Ms No. 78, Industries & Commerce (IP & INF) Department, dt: 09/10/2015.";

                    }
                    else if (lblTIdeaTPrideIIPP1.Text.Contains("IIPP 2010-15"))
                    {
                        lbltideano.Visible = true;
                        lblyeras2.Text = lblyeras1.Text = "six (6)";
                        lblScheme_GO_Details.Text = "G.O.Ms.No. 61, Industries & Commerce (IP) Department, dated: 29/06/2010 read with G.O.Ms No. 42, Industries & Commerce (IP ) Department, dt: 05/05/2011.";
                    }
                    else if (lblTIdeaTPrideIIPP1.Text.Contains("IIPP 2005-10"))
                    {
                        lbltideano.Visible = true;
                        lblyeras2.Text = lblyeras1.Text = "six (6)";
                        lblScheme_GO_Details.Text = "G.O.Ms.No. 178, Industries & Commerce (IP) Department, dated: 21/06/2005 read with G.O.Ms No. 327, Industries & Commerce (IP ) Department, dt: 13/12/2005.";
                    }
                    else if (lblTIdeaTPrideIIPP1.Text.Contains("MSME"))
                    {
                        lbltideano.Visible = false;

                        lblyeras2.Text = lblyeras1.Text = "three (3)";
                        lblScheme_GO_Details.Text = "G.O.Ms.No. 16, Industries & Commerce (FP&MSME) Department, Dated: 18/09/2024 read with G.O.Ms No. 06, Industries & Commerce (FP&MSME) Department, Dated:23/03/2026.";
                    }
                }
            }

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[3].Rows.Count > 0)
            {
                {
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
            }
        }
        else
        {
            lblcoidipc.Text = "COMMISSIONERATE OF INDUSTRIES :: ";
            lblDistrict1.Text = "HYDERABAD";
            lblSLCText.Text = "SLC Number ";
            //lbldesignation.Text = "Additional Director";
            //lblDistrict2.Text = "<br/>" + "O/o. Commissioner of Industries";
            lbladdress.Text = "Chirag Ali Lane, Abids, Hyderabad – 500 001, Phone No.040-23441600 ";

            if (Request.QueryString.Count > 1)
            {
                //if (Request.QueryString["Scheme"] != null)
                //{
                //    lblTIdeaTPrideIIPP1.Text = Request.QueryString["Scheme"].ToString();
                //    lblTIdeaTPrideIIPP2.Text = Request.QueryString["Scheme"].ToString();
                //    lblTIdeaTPrideIIPP3.Text = Request.QueryString["Scheme"].ToString();

                //    if (lblTIdeaTPrideIIPP1.Text.Contains("IDEA") || lblTIdeaTPrideIIPP1.Text.Contains("Pride"))
                //    {
                //        lblScheme_GO_Details.Text = "G.O.Ms.No. 28, Industries & Commerce (IP) Department, dated: 29/11/2014 read with G.O.Ms No. 77, Industries & Commerce (IP & INF) Department, dt: 09/10/2015.";
                //    }
                //    else if (lblTIdeaTPrideIIPP1.Text.Contains("IIPP 2010-15"))
                //    {
                //        lblScheme_GO_Details.Text = "G.O.Ms.No. 61, Industries & Commerce (IP) Department, dated: 29/06/2010 read with G.O.Ms No. 42, Industries & Commerce (IP ) Department, dt: 05/05/2011.";
                //    }
                //    else if (lblTIdeaTPrideIIPP1.Text.Contains("IIPP 2005-10"))
                //    {
                //        lblScheme_GO_Details.Text = "G.O.Ms.No. 178, Industries & Commerce (IP) Department, dated: 21/06/2005 read with G.O.Ms No. 327, Industries & Commerce (IP ) Department, dt: 13/12/2005.";
                //    }
                //}
                if (Request.QueryString["DIPCNumer"] != null)
                {
                    lblSLCNo.Text = Request.QueryString["DIPCNumer"].ToString();
                }
            }

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SLCNumber"].ToString() != null && ds.Tables[0].Rows[0]["SLCNumber"].ToString() != "")
                {
                    lblSLCNo.Text = ds.Tables[0].Rows[0]["SLCNumber"].ToString();
                    //if (Convert.ToInt32(ds.Tables[0].Rows[0]["SLCNumber"].ToString()) >= 37)
                    //{
                    //   // addlDire.Visible = true;
                    //    lblAddlDir_Name.Visible = true;
                    //    lblAddlDir_Name.Text = "RAJKUMAR OHATKER";
                    //}
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
                    lblLetterDatemngr.Text = ds.Tables[0].Rows[0]["Gmrecommdate"].ToString();
                }
            }

            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows[0]["applicationno"].ToString() != "" && ds.Tables[1].Rows[0]["applicationno"].ToString() != null)
                {
                    lblLetterNo.Text = "COI/" + ds.Tables[1].Rows[0]["applicationno"].ToString();
                    lblLetterNomngr.Text = "COI/" + ds.Tables[1].Rows[0]["applicationno"].ToString() + "/GMREC-PT";
                }

                if (ds.Tables[1].Rows[0]["EnterpreunerDtls"].ToString() != null && ds.Tables[1].Rows[0]["EnterpreunerDtls"].ToString() != "")
                {
                    lblEnterpreneurDetails1.Text = ds.Tables[1].Rows[0]["EnterpreunerDtls"].ToString();
                    lblEnterpreneurDetails2.Text = ds.Tables[1].Rows[0]["EnterpreunerDtls"].ToString();
                }

                if (ds.Tables[1].Rows[0]["District_Name"].ToString() != null && ds.Tables[1].Rows[0]["District_Name"].ToString() != "")
                {
                    lblDistrict.Text = ds.Tables[1].Rows[0]["District_Name"].ToString().ToUpper();
                    // lblDistrict1.Text = ds.Tables[1].Rows[0]["District_Name"].ToString().ToUpper();
                }

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[3].Rows.Count > 0)
                {
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
                //if (ds != null && ds.Tables.Count > 2 && ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                //{
                //    if (ds.Tables[2].Rows[0]["FinYear"].ToString() != null && ds.Tables[2].Rows[0]["FinYear"].ToString() != "")
                //    {
                //        lbl1stOR2ndHalfYearFinYearFromTo.Text = ds.Tables[2].Rows[0]["FinYear"].ToString();   // "2nd Half Year of 2016-17";    // need to Clarify
                //    }
                //}

                if (ds.Tables[1].Rows[0]["ProjectScheme"].ToString() != "" && ds.Tables[1].Rows[0]["ProjectScheme"].ToString() != null)
                {
                    string strscheme = "";
                    strscheme = ds.Tables[1].Rows[0]["ProjectScheme"].ToString();

                    if (strscheme == "TIDEA" || strscheme == "TPRIDE" || strscheme == "T-PRIDE")
                    {
                        if (ds.Tables[1].Rows[0]["TIDEAflag"].ToString() != "" && ds.Tables[1].Rows[0]["TIDEAflag"].ToString() != null)
                        {
                            if (ds.Tables[1].Rows[0]["TIDEAflag"].ToString() == "Y")
                            {

                                lblTIdeaTPrideIIPP1.Text = "T-IDEA";
                                lblTIdeaTPrideIIPP2.Text = "T-IDEA";
                                lblTIdeaTPrideIIPP3.Text = "T-IDEA";
                            }
                        }
                        if (ds.Tables[1].Rows[0]["TSCPflag"].ToString() != "" && ds.Tables[1].Rows[0]["TSCPflag"].ToString() != null)
                        {

                            if (ds.Tables[1].Rows[0]["TSCPflag"].ToString() == "Y")
                            {
                                lblTIdeaTPrideIIPP1.Text = "T-PRIDE(SCSDF)";////"T-PRIDE(TSCP)";T-Pride(SCSDF) CHANGED ON 01/02/2022
                                lblTIdeaTPrideIIPP2.Text = "T-PRIDE(SCSDF)";
                                lblTIdeaTPrideIIPP3.Text = "T-PRIDE(SCSDF)";

                            }
                        }
                        if (ds.Tables[1].Rows[0]["TSPflag"].ToString() != "" && ds.Tables[1].Rows[0]["TSPflag"].ToString() != null)
                        {
                            if (ds.Tables[1].Rows[0]["TSPflag"].ToString() == "Y")
                            {
                                lblTIdeaTPrideIIPP1.Text = "T-PRIDE(STSDF)";////"T-PRIDE(TSP)";T-Pride(STSDF) CHANGED ON 01/02/2022
                                lblTIdeaTPrideIIPP2.Text = "T-PRIDE(STSDF)";
                                lblTIdeaTPrideIIPP3.Text = "T-PRIDE(STSDF)";

                            }
                        }
                    }
                    else if (strscheme == "IIPP 2005-10" || strscheme == "IIPP 2010-15")
                    {
                        lblTIdeaTPrideIIPP1.Text = strscheme;
                        lblTIdeaTPrideIIPP2.Text = strscheme;
                        lblTIdeaTPrideIIPP3.Text = strscheme;
                    }

                    if (lblTIdeaTPrideIIPP1.Text.Contains("IDEA")  )
                    {
                        lbltideano.Visible = true;
                        lblyeras2.Text = lblyeras1.Text = "six (6)";
                        lblScheme_GO_Details.Text = "G.O.Ms.No. 28, Industries & Commerce (IP) Department, dated: 29/11/2014 read with G.O.Ms No. 77, Industries & Commerce (IP & INF) Department, dt: 09/10/2015.";
                    }
                        else if(lblTIdeaTPrideIIPP1.Text.Contains("PRIDE")){
                        lbltideano.Visible = true;
                        lblyeras2.Text = lblyeras1.Text = "six (6)";
                        lblScheme_GO_Details.Text = "G.O.Ms.No. 29, Industries & Commerce (IP) Department, dated: 29/11/2014 read with G.O.Ms No. 78, Industries & Commerce (IP & INF) Department, dt: 09/10/2015.";
                        
                        }
                    else if (lblTIdeaTPrideIIPP1.Text.Contains("IIPP 2010-15"))
                    {
                        lbltideano.Visible = true;
                        lblyeras2.Text = lblyeras1.Text = "six (6)";
                        lblScheme_GO_Details.Text = "G.O.Ms.No. 61, Industries & Commerce (IP) Department, dated: 29/06/2010 read with G.O.Ms No. 42, Industries & Commerce (IP ) Department, dt: 05/05/2011.";
                    }
                    else if (lblTIdeaTPrideIIPP1.Text.Contains("IIPP 2005-10"))
                    {
                        lbltideano.Visible = true;
                        lblyeras2.Text = lblyeras1.Text = "six (6)";
                        lblScheme_GO_Details.Text = "G.O.Ms.No. 178, Industries & Commerce (IP) Department, dated: 21/06/2005 read with G.O.Ms No. 327, Industries & Commerce (IP ) Department, dt: 13/12/2005.";
                    }
                    else if (lblTIdeaTPrideIIPP1.Text.Contains("MSME"))
                    {
                        lbltideano.Visible = false;

                        lblyeras2.Text = lblyeras1.Text = "three (3)";
                        lblScheme_GO_Details.Text = "G.O.Ms.No. 16, Industries & Commerce (FP&MSME) Department, Dated: 18/09/2024 read with G.O.Ms No. 06, Industries & Commerce (FP&MSME) Department, Dated:23/03/2026.";
                    }
                }
            }
        }
    }
}
