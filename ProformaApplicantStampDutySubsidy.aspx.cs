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

public partial class UI_TSiPASS_ProformaApplicantStampDutySubsidy : System.Web.UI.Page
{
    General Gen = new General();
    string incentiveid = "", Mstincentiveid="";
    string DIPCFlag = "";
    DataSet dsDIPC = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        //incentiveid = "1096";    // for testing
            //DataSet dsnew = new DataSet();
            //dsnew = Gen.GetSLCDetails(incentiveid, "9");
            //fillSLCDetails(dsnew);

            if (Request.QueryString.Count > 0 && Request.QueryString["incentiveid"] != null)
            {
               // string userid = Session["uid"].ToString();
                incentiveid = Request.QueryString["incentiveid"].ToString();
                Mstincentiveid = Request.QueryString["MstIncentiveId"].ToString();

                DataSet dsnew = new DataSet();
                dsnew = Gen.GetSLCDetails(incentiveid, Mstincentiveid);
                fillSLCDetails(dsnew);
                lblIncentiVeID.Text = incentiveid;
                DataSet dsname = new DataSet();
                dsname = Gen.GetIncentiveOfficerNamesForAll(incentiveid, Mstincentiveid, "0", "", "INTIMATION");
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
                            lblAddlDir_Name.Text = dsname.Tables[0].Rows[0]["GMNamerecom"].ToString() + "<br/>" + "Additional Director" + "<br/>" + "O/o. Commissioner of Industries";
                        }
                    }
                }
            }
       // }
    }
    public void fillSLCDetails(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DIPCFlag = ds.Tables[0].Rows[0]["DIPCFlag"].ToString();
        }


        if (DIPCFlag == "Y")
        {
            //lblcoidipc.Text = "DISTRICT INDUSTRIES CENTER";
            lblSLCText.Text = "DIPC Number";
            // lbldesignation.Text = "DIC";

            lblcoidipc.Text = "DISTRICT INDUSTRIES CENTER";

            if (ds.Tables[1].Rows[0]["MeetingNumber"].ToString() != null && ds.Tables[1].Rows[0]["MeetingNumber"].ToString() != "")
            {
                lblSLCNo.Text = ds.Tables[1].Rows[0]["MeetingNumber"].ToString();
            }
            lbladdress.Visible = false;
            lbladdress.Text = "DISTRICT INDUSTRIES CENTER-" + ds.Tables[1].Rows[0]["District_Name"].ToString().ToUpper() + " website: http://www.industries.telangana.gov.in";

            if (ds.Tables[1].Rows[0]["applicationno"].ToString() != "" && ds.Tables[1].Rows[0]["applicationno"].ToString() != null)
            {
                lblLetterNo.Text = "DIPC/" + ds.Tables[1].Rows[0]["applicationno"].ToString();
                //lblLRNo.Text = "DIPC/" + ds.Tables[1].Rows[0]["applicationno"].ToString();
                //lblSLCorDIPC.Text = "DIPC";
            }

            if (Request.QueryString.Count > 1)
            {
                if (Request.QueryString["Scheme"] != null)
                {
                    lblTIdeaTPrideIIPP1.Text = Request.QueryString["Scheme"].ToString();
                    lblTIdeaTPrideIIPP2.Text = Request.QueryString["Scheme"].ToString();
                    lblTIdeaTPrideIIPP3.Text = Request.QueryString["Scheme"].ToString();

                    if (lblTIdeaTPrideIIPP1.Text.Contains("IDEA") || lblTIdeaTPrideIIPP1.Text.Contains("Pride"))
                    {
                        lblScheme_GO_Details.Text = "G.O.Ms.No. 28, Industries & Commerce (IP) Department, dated: 29/11/2014 read with G.O.Ms No. 77, Industries & Commerce (IP & INF) Department, dt: 09/10/2015.";
                    }
                    else if (lblTIdeaTPrideIIPP1.Text.Contains("IIPP 2010-15"))
                    {
                        lblScheme_GO_Details.Text = "G.O.Ms.No. 61, Industries & Commerce (IP) Department, dated: 29/06/2010 read with G.O.Ms No. 42, Industries & Commerce (IP ) Department, dt: 05/05/2011.";
                    }
                    else if (lblTIdeaTPrideIIPP1.Text.Contains("IIPP 2005-10"))
                    {
                        lblScheme_GO_Details.Text = "G.O.Ms.No. 178, Industries & Commerce (IP) Department, dated: 21/06/2005 read with G.O.Ms No. 327, Industries & Commerce (IP ) Department, dt: 13/12/2005.";
                    }
                }
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
                }               

                //if (ds != null && ds.Tables.Count > 2 && ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                //{
                //    if (ds.Tables[2].Rows[0]["FinYear"].ToString() != null && ds.Tables[2].Rows[0]["FinYear"].ToString() != "")
                //    {
                //        lbl1stOR2ndHalfYearFinYearFromTo.Text = "2nd Half Year of 2016-17";                    // need to Clarify
                //    }
                //}
            }
            if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
            {
                if (ds.Tables[2].Rows[0]["StampTranfrDutyAP"].ToString() != null && ds.Tables[2].Rows[0]["StampTranfrDutyAP"].ToString() != "")
                {
                    //lblStampDutyorMgage.Text = "Reimbursement of Stamp Duty/Transfer Duty/Land Conversion/Land Cost";
                    if (Mstincentiveid == "9")
                    {
                        lblStampDutyorMgage.Text = "Reimbursement of Stamp Duty/Transfer Duty/Mortgage Duty/Land Conversion/Land Cost";
                    }
                    else if (Mstincentiveid == "14")
                    {
                        lblStampDutyorMgage.Text = "Reimbursement of Stamp Duty/Transfer Duty";
                    }
                    else if (Mstincentiveid == "15")
                    {
                        lblStampDutyorMgage.Text = "Reimbursement of Mortgage Duty";
                    }
                    else if (Mstincentiveid == "16")
                    {
                        lblStampDutyorMgage.Text = "Reimbursement of Land Conversion";
                    }
                    else if (Mstincentiveid == "17")
                    {
                        lblStampDutyorMgage.Text = "Reimbursement of Land Cost";
                    }

                    
                    lblStampDutyAmount.Text = ds.Tables[2].Rows[0]["StampTranfrDutyAP"].ToString();
                    int StampDutyamt = Convert.ToInt32(lblStampDutyAmount.Text.ToString());
                    lblStampDutyAmountDesc.Text = "Rupees " + Gen.NumberToWord(StampDutyamt) + " Only.";
                }
                if (ds.Tables[2].Rows[0]["MortgageHypothDutyAP"].ToString() != null && ds.Tables[2].Rows[0]["MortgageHypothDutyAP"].ToString() != "")
                {
                    // lblStampDutyorMgage.Text = "Mortgage Duty";
                    lblStampDutyAmount.Text = ds.Tables[2].Rows[0]["MortgageHypothDutyAP"].ToString();
                    int MortgageAmt = Convert.ToInt32(lblStampDutyAmount.Text.ToString());
                    lblStampDutyAmountDesc.Text = "Rupees " + Gen.NumberToWord(MortgageAmt) + " Only.";
                }

                if (ds != null && ds.Tables.Count > 2 && ds.Tables[3].Rows.Count > 0)
                {
                    if (ds.Tables[3].Rows[0]["valueamount"].ToString() != null && ds.Tables[3].Rows[0]["valueamount"].ToString() != "")
                    {
                        //  lblStampDutyorMgage.Text = "Stamp Duty";
                        lblStampDutyAmount.Text = ds.Tables[3].Rows[0]["valueamount"].ToString();
                        int StampDutyamt = Convert.ToInt32(Convert.ToDouble(lblStampDutyAmount.Text.ToString()));
                        lblStampDutyAmountDesc.Text = "Rupees " + Gen.NumberToWord(StampDutyamt) + " Only.";
                    }
                }
            }
            //if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
            //{
            //    if (ds.Tables[2].Rows[0]["StampTranfrDutyAP"].ToString() != null && ds.Tables[2].Rows[0]["StampTranfrDutyAP"].ToString() != "")
            //    {
            //        lblStampDutyorMgage.Text = "Stamp Duty";
            //        lblStampDutyAmount.Text = ds.Tables[2].Rows[0]["StampTranfrDutyAP"].ToString();
            //        int StampDutyamt = Convert.ToInt32(lblStampDutyAmount.Text.ToString());
            //        lblStampDutyAmountDesc.Text = Gen.NumberToWord(StampDutyamt);
            //    }
                
            //}

            // commented on 09.02.2018
            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            //    if (ds.Tables[0].Rows[0]["GM_Rcon_Amount"].ToString() != null && ds.Tables[0].Rows[0]["GM_Rcon_Amount"].ToString() != "")
            //    {
            //        lblStampDutyorMgage.Text = "Stamp Duty";
            //        lblStampDutyAmount.Text = ds.Tables[0].Rows[0]["GM_Rcon_Amount"].ToString();
            //        int StampDutyamt = Convert.ToInt32( Convert.ToDouble(lblStampDutyAmount.Text.ToString()));
            //        lblStampDutyAmountDesc.Text = Gen.NumberToWord(StampDutyamt);
            //    }

            //}


            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[3].Rows.Count > 0)
            //{
            //    {
            //        if (ds.Tables[3].Rows[0]["valueamount"].ToString() != null && ds.Tables[3].Rows[0]["valueamount"].ToString() != "")
            //        {
            //            lblStampDutyAmount.Text = ds.Tables[3].Rows[0]["valueamount"].ToString();

            //            string[] no;
            //            int Number;
            //            if (lblStampDutyAmount.Text.Contains("."))
            //            {
            //                no = lblStampDutyAmount.Text.Split('.');
            //                Number = Convert.ToInt32(no[0]);
            //            }
            //            else
            //            {
            //                Number = Convert.ToInt32(lblStampDutyAmount.Text);
            //            }

            //            lblStampDutyAmountDesc.Text = Gen.NumberToWord(Number) + " Rupees Only.";
            //        }
            //    }
            //}
        }
        else
        {
            lblcoidipc.Text = "COMMISSIONERATE OF INDUSTRIES";
            lblDistrict1.Text = "HYDERABAD";
            lblSLCText.Text = "SLC Number ";
            //lbldesignation.Text = "Additional Director";
            //lblDistrict2.Text = "<br/>" + "O/o. Commissioner of Industries";
            lbladdress.Text = "Chirag Ali Lane, Abids, Hyderabad – 500 001, Phone No.040-23441600 ";

            if (Request.QueryString.Count > 1)
            {
                if (Request.QueryString["Scheme"] != null)
                {
                    lblTIdeaTPrideIIPP1.Text = Request.QueryString["Scheme"].ToString();
                    lblTIdeaTPrideIIPP2.Text = Request.QueryString["Scheme"].ToString();
                    lblTIdeaTPrideIIPP3.Text = Request.QueryString["Scheme"].ToString();

                    if (lblTIdeaTPrideIIPP1.Text.Contains("IDEA") || lblTIdeaTPrideIIPP1.Text.Contains("Pride"))
                    {
                        lblScheme_GO_Details.Text = "G.O.Ms.No. 28, Industries & Commerce (IP) Department, dated: 29/11/2014 read with G.O.Ms No. 77, Industries & Commerce (IP & INF) Department, dt: 09/10/2015.";
                    }
                    else if (lblTIdeaTPrideIIPP1.Text.Contains("IIPP 2010-15"))
                    {
                        lblScheme_GO_Details.Text = "G.O.Ms.No. 61, Industries & Commerce (IP) Department, dated: 29/06/2010 read with G.O.Ms No. 42, Industries & Commerce (IP ) Department, dt: 05/05/2011.";
                    }
                    else if (lblTIdeaTPrideIIPP1.Text.Contains("IIPP 2005-10"))
                    {
                        lblScheme_GO_Details.Text = "G.O.Ms.No. 178, Industries & Commerce (IP) Department, dated: 21/06/2005 read with G.O.Ms No. 327, Industries & Commerce (IP ) Department, dt: 13/12/2005.";
                    }
                }
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
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["SLCNumber"].ToString()) >= 37)
                    {
                        addlDire.Visible = true;
                        lblAddlDir_Name.Visible = true;
                        lblAddlDir_Name.Text = "RAJKUMAR OHATKER";
                    }
                }
                if (ds.Tables[0].Rows[0]["SLCDateNew"].ToString() != null && ds.Tables[0].Rows[0]["SLCDateNew"].ToString() != "")
                {
                    lblSLCDate.Text = ds.Tables[0].Rows[0]["SLCDateNew"].ToString();
                }

                if (ds.Tables[0].Rows[0]["todaydate"].ToString() != null && ds.Tables[0].Rows[0]["todaydate"].ToString() != "")
                {
                    lblLetterDate.Text = ds.Tables[0].Rows[0]["todaydate"].ToString();
                }
            }

            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows[0]["applicationno"].ToString() != "" && ds.Tables[1].Rows[0]["applicationno"].ToString() != null)
                {
                    lblLetterNo.Text = "COI/" + ds.Tables[1].Rows[0]["applicationno"].ToString();
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

                //if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                //{
                //    if (ds.Tables[2].Rows[0]["StampTranfrDutyAP"].ToString() != null && ds.Tables[2].Rows[0]["StampTranfrDutyAP"].ToString() != "")
                //    {
                //        //lblStampDutyorMgage.Text = "Stamp Duty";
                //        //lblStampDutyorMgage.Text = "Reimbursement of stamp Duty/Transfer Duty/Mortgage/Land Conversion/Land Cost";
                //        if (Mstincentiveid == "9")
                //        {
                //            lblStampDutyorMgage.Text = "Reimbursement of Stamp Duty/Transfer Duty/Mortgage Duty/Land Conversion/Land Cost";
                //        }
                //        else if (Mstincentiveid == "14")
                //        {
                //            lblStampDutyorMgage.Text = "Reimbursement of Stamp Duty/Transfer Duty";
                //        }
                //        else if (Mstincentiveid == "15")
                //        {
                //            lblStampDutyorMgage.Text = "Reimbursement of Mortgage Duty";
                //        }
                //        else if (Mstincentiveid == "16")
                //        {
                //            lblStampDutyorMgage.Text = "Reimbursement of Land Conversion";
                //        }
                //        else if (Mstincentiveid == "17")
                //        {
                //            lblStampDutyorMgage.Text = "Reimbursement of Land Cost";
                //        }

                //        lblStampDutyAmount.Text = ds.Tables[2].Rows[0]["StampTranfrDutyAP"].ToString();
                //        int StampDutyamt = Convert.ToInt32(lblStampDutyAmount.Text.ToString());
                //        lblStampDutyAmountDesc.Text = "Rupees " +Gen.NumberToWord(StampDutyamt)+ " Only.";
                //    }
                //if (ds.Tables[2].Rows[0]["MortgageHypothDutyAP"].ToString() != null && ds.Tables[2].Rows[0]["MortgageHypothDutyAP"].ToString() != "")
                //{
                //    lblStampDutyorMgage.Text = "Mortgage Duty";
                //    lblStampDutyAmount.Text = ds.Tables[2].Rows[0]["MortgageHypothDutyAP"].ToString();
                //    int MortgageAmt = Convert.ToInt32(lblStampDutyAmount.Text.ToString());
                //    lblStampDutyAmountDesc.Text = "Rupees " +Gen.NumberToWord(MortgageAmt)+ " Only.";
                //}
                if (ds != null && ds.Tables.Count >= 2)

                //if (ds != null && ds.Tables.Count > 2 && ds.Tables[3].Rows.Count > 0)
                {
                    if (ds.Tables[2].Rows[0]["valueamount"].ToString() != null && ds.Tables[2].Rows[0]["valueamount"].ToString() != "")
                    {
                        //  lblStampDutyorMgage.Text = "Stamp Duty";
                        // lblStampDutyorMgage.Text = "Reimbursement of stamp Duty/Transfer Duty/Mortgage/Land Conversion/Land Cost";
                        if (Mstincentiveid == "9")
                        {
                            lblStampDutyorMgage.Text = "Reimbursement of Stamp Duty/Transfer Duty/Mortgage Duty/Land Conversion/Land Cost";
                        }
                        else if (Mstincentiveid == "14")
                        {
                            lblStampDutyorMgage.Text = "Reimbursement of Stamp Duty/Transfer Duty";
                        }
                        else if (Mstincentiveid == "15")
                        {
                            lblStampDutyorMgage.Text = "Reimbursement of Mortgage Duty";
                        }
                        else if (Mstincentiveid == "16")
                        {
                            lblStampDutyorMgage.Text = "Reimbursement of Land Conversion";
                        }
                        else if (Mstincentiveid == "17")
                        {
                            lblStampDutyorMgage.Text = "Reimbursement of Land Cost";
                        }
                        lblStampDutyAmount.Text = ds.Tables[2].Rows[0]["valueamount"].ToString();
                        int StampDutyamt = Convert.ToInt32(Convert.ToDouble(lblStampDutyAmount.Text.ToString()));
                        lblStampDutyAmountDesc.Text = Gen.NumberToWord(StampDutyamt);
                    }

                }

            }

                    //if (ds != null && ds.Tables.Count > 2 && ds.Tables[3].Rows.Count > 0)
            if (ds != null && ds.Tables.Count >= 2)
            {
                if (ds.Tables[2].Rows[0]["valueamount"].ToString() != null && ds.Tables[2].Rows[0]["valueamount"].ToString() != "")
                {
                    //lblStampDutyorMgage.Text = "Stamp Duty";
                    //lblStampDutyorMgage.Text = "Reimbursement of stamp Duty/Transfer Duty/Mortgage/Land Conversion/Land Cost";
                    if (Mstincentiveid == "9")
                    {
                        lblStampDutyorMgage.Text = "Reimbursement of Stamp Duty/Transfer Duty/Mortgage Duty/Land Conversion/Land Cost";
                    }
                    else if (Mstincentiveid == "14")
                    {
                        lblStampDutyorMgage.Text = "Reimbursement of Stamp Duty/Transfer Duty";
                    }
                    else if (Mstincentiveid == "15")
                    {
                        lblStampDutyorMgage.Text = "Reimbursement of Mortgage Duty";
                    }
                    else if (Mstincentiveid == "16")
                    {
                        lblStampDutyorMgage.Text = "Reimbursement of Land Conversion";
                    }
                    else if (Mstincentiveid == "17")
                    {
                        lblStampDutyorMgage.Text = "Reimbursement of Land Cost";
                    }
                    lblStampDutyAmount.Text = ds.Tables[2].Rows[0]["valueamount"].ToString();
                    int StampDutyamt = Convert.ToInt32(Convert.ToDouble(lblStampDutyAmount.Text.ToString()));
                    lblStampDutyAmountDesc.Text = "Rupees " + Gen.NumberToWord(StampDutyamt) + " Only.";
                }

            }
                
                //if (ds != null && ds.Tables.Count > 0 && ds.Tables[3].Rows.Count > 0)
                //{
                //    if (ds.Tables[3].Rows[0]["valueamount"].ToString() != null && ds.Tables[3].Rows[0]["valueamount"].ToString() != "")
                //    {
                //        lblStampDutyAmount.Text = ds.Tables[3].Rows[0]["valueamount"].ToString();

                //        string[] no;
                //        int Number;
                //        if (lblStampDutyAmount.Text.Contains("."))
                //        {
                //            no = lblStampDutyAmount.Text.Split('.');
                //            Number = Convert.ToInt32(no[0]);
                //        }
                //        else
                //        {
                //            Number = Convert.ToInt32(lblStampDutyAmount.Text);
                //        }

                //        lblStampDutyAmountDesc.Text = Gen.NumberToWord(Number) + " Rupees Only.";
                //    }
                //}

                //if (ds.Tables[1].Rows[0]["BankDtls"].ToString() != null && ds.Tables[1].Rows[0]["BankDtls"].ToString() != "")
                //{
                //   lblBankDtls.Text = ds.Tables[1].Rows[0]["BankDtls"].ToString();
                //}

                //if (ds != null && ds.Tables.Count > 2 && ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                //{
                //    if (ds.Tables[2].Rows[0]["FinYear"].ToString() != null && ds.Tables[2].Rows[0]["FinYear"].ToString() != "")
                //    {
                //        lbl1stOR2ndHalfYearFinYearFromTo.Text = "2nd Half Year of 2016-17";                    // need to Clarify
                //    }
                //}
            }
        }
        #region
        //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //{
        //    if (ds.Tables[0].Rows[0]["SLCNumber"].ToString() != null && ds.Tables[0].Rows[0]["SLCNumber"].ToString() != "")
        //    {
        //        lblSLCNo.Text = ds.Tables[0].Rows[0]["SLCNumber"].ToString();
        //    }
        //    if (ds.Tables[0].Rows[0]["SLCDateNew"].ToString() != null && ds.Tables[0].Rows[0]["SLCDateNew"].ToString() != "")
        //    {
        //        lblSLCDate.Text = ds.Tables[0].Rows[0]["SLCDateNew"].ToString();
        //    }
        //}
        //if (ds.Tables[3].Rows[0]["valueamount"].ToString() != null && ds.Tables[3].Rows[0]["valueamount"].ToString() != "")
        //{
        //    lblStampDutyAmount.Text = ds.Tables[3].Rows[0]["valueamount"].ToString();
        //    // int SLCAmount = Convert.ToInt32(lblSanctionedAmount.Text.ToString());
        //    // lblSanctionedAmtDesc.Text = Gen.NumberToWord(SLCAmount);

        //    string[] no;
        //    int Number;
        //    if (lblStampDutyAmount.Text.Contains("."))
        //    {
        //        no = lblStampDutyAmount.Text.Split('.');
        //        Number = Convert.ToInt32(no[0]);
        //    }
        //    else
        //    {
        //        Number = Convert.ToInt32(lblStampDutyAmount.Text);
        //    }

        //    lblStampDutyAmountDesc.Text = Gen.NumberToWord(Number) + " Rupees Only.";
        //}
        //DateTime DCPBaseDate = Convert.ToDateTime("2014/11/29");  //("29-11-2014");

        //if (ds != null && ds.Tables.Count > 1 && ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
        //{
        //    if (ds.Tables[1].Rows[0]["DCP"].ToString() != "" && ds.Tables[1].Rows[0]["DCP"].ToString() != null)
        //    {
        //        DateTime DCP1 = Convert.ToDateTime(ds.Tables[1].Rows[0]["DCP"].ToString());
        //        if (DCP1 > DCPBaseDate)
        //        {
        //            lblTIdeaTPrideIIPP1.Text = "T-IDEA";
        //            lblTIdeaTPrideIIPP2.Text = "T-IDEA";
        //            lblTIdeaTPrideIIPP3.Text = "T-IDEA";
        //        }
        //        else
        //        {
        //            lblTIdeaTPrideIIPP1.Text = "IIPP 2010-2015";
        //            lblTIdeaTPrideIIPP2.Text = "IIPP 2010-2015";
        //            lblTIdeaTPrideIIPP3.Text = "IIPP 2010-2015";
        //        }
        //    }

        //    if (ds.Tables[1].Rows[0]["EMiUdyogAadhar"].ToString() != "" && ds.Tables[1].Rows[0]["EMiUdyogAadhar"].ToString() != null)
        //    {

        //        lblLetterNo.Text = "COI/" + ds.Tables[1].Rows[0]["EMiUdyogAadhar"].ToString();
        //    }

        //    if (ds.Tables[1].Rows[0]["todaydate"].ToString() != null && ds.Tables[1].Rows[0]["todaydate"].ToString() != "")
        //    {
        //        lblLetterDate.Text = ds.Tables[1].Rows[0]["todaydate"].ToString();
        //    }

        //    //if (ds.Tables[1].Rows[0]["APPLICATIONDATE"].ToString() != null && ds.Tables[1].Rows[0]["APPLICATIONDATE"].ToString() != "")
        //    //{
        //    //    lblRefApplnDate.Text = ds.Tables[1].Rows[0]["APPLICATIONDATE"].ToString();
        //    //}
        //    //lblRefApplicationNo.Text = "COI/" + Request.QueryString["incentiveid"].ToString();

        //    if (ds.Tables[1].Rows[0]["EnterpreunerDtls"].ToString() != null && ds.Tables[1].Rows[0]["EnterpreunerDtls"].ToString() != "")
        //    {
        //        lblEnterpreneurDetails1.Text = ds.Tables[1].Rows[0]["EnterpreunerDtls"].ToString();
        //        lblEnterpreneurDetails2.Text = ds.Tables[1].Rows[0]["EnterpreunerDtls"].ToString();
        //    }

        //    if (ds.Tables[1].Rows[0]["District_Name"].ToString() != null && ds.Tables[1].Rows[0]["District_Name"].ToString() != "")
        //    {
        //        lblDistrict.Text = ds.Tables[1].Rows[0]["District_Name"].ToString();
        //        lblDistrict1.Text = ds.Tables[1].Rows[0]["District_Name"].ToString();
        //    }

        //    if (ds.Tables[1].Rows[0]["BankDtls"].ToString() != null && ds.Tables[1].Rows[0]["BankDtls"].ToString() != "")
        //    {
        //        lblBankDtls.Text = ds.Tables[1].Rows[0]["BankDtls"].ToString();
        //    }
        //}

        //if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
        //{
        //    if (ds.Tables[2].Rows[0]["StampTranfrDutyAP"].ToString() != null && ds.Tables[2].Rows[0]["StampTranfrDutyAP"].ToString() != "")
        //    {
        //        lblStampDutyAmount.Text = ds.Tables[2].Rows[0]["StampTranfrDutyAP"].ToString();
        //        int StampDutyamt = Convert.ToInt32(lblStampDutyAmount.Text.ToString());
        //        lblStampDutyAmountDesc.Text = Gen.NumberToWord(StampDutyamt);
        //    }
        //    if (ds.Tables[2].Rows[0]["MortgageHypothDutyAP"].ToString() != null && ds.Tables[2].Rows[0]["MortgageHypothDutyAP"].ToString() != "")
        //    {
        //        lblMortgageAmount.Text = ds.Tables[2].Rows[0]["MortgageHypothDutyAP"].ToString();
        //        int MortgageAmt = Convert.ToInt32(lblMortgageAmount.Text.ToString());
        //        lblMortgageAmountDesc.Text = Gen.NumberToWord(MortgageAmt);
        //    }
        //}
    }
    #endregion
