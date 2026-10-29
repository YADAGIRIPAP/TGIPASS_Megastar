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

public partial class UI_TSiPASS_ProformaApplicantAPMC : System.Web.UI.Page
{
    General Gen = new General();
    string incentiveid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session.Count <= 0)
        //{
        //    Response.Redirect("../../frmUserLogin.aspx");
        //}

        //if (Session["uid"] != null)
        //{
        //---------------------- for testing
        //incentiveid = "1096";    
        //DataSet dsnew = new DataSet();
        //dsnew = Gen.GetSLCDetails(incentiveid, "3");
        //fillSLCDetails(dsnew);
        //----------------------

        if (Request.QueryString.Count > 0 && Request.QueryString["incentiveid"] != null)
        {
            // string userid = Session["uid"].ToString();
            incentiveid = Request.QueryString["incentiveid"].ToString();

            DataSet dsnew = new DataSet();
            dsnew = Gen.GetSLCDetails(incentiveid, "21");
            fillSLCDetails(dsnew);
            lblIncentiVeID.Text = incentiveid;

            DataSet dsname = new DataSet();
            dsname = Gen.GetIncentiveOfficerNamesForAll(incentiveid, "21", "0", "", "INTIMATION");
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
                        lblAddlDir_Name.Text = dsname.Tables[0].Rows[0]["GMNamerecom"].ToString() + "<br/>" + dsname.Tables[0].Rows[0]["Designation"].ToString() + "<br/>" + "O/o. Commissioner of Industries";


                        //lblAddlDir_Name.Text = dsname.Tables[0].Rows[0]["GMNamerecom"].ToString() + "<br/>" + "Additional Director" + "<br/>" + "O/o. Commissioner of Industries";
                    }
                }
            }
        }
        // }
    }
    public void fillSLCDetails(DataSet ds)
    {
        string DIPCFlag = "";
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DIPCFlag = ds.Tables[0].Rows[0]["DIPCFlag"].ToString();
        }
        if (ds != null && ds.Tables.Count > 2 && ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
        {
            if (ds.Tables[2].Rows[0]["GMclaimedfinyear"].ToString() != null && ds.Tables[2].Rows[0]["GMclaimedfinyear"].ToString() != "")
            {
                lbl1stOR2ndHalfYearFinYearFromTo.Text = ds.Tables[2].Rows[0]["GMclaimedfinyear"].ToString();   // "2nd Half Year of 2016-17";    // need to Clarify
                lblfinyearsub.Text = ds.Tables[2].Rows[0]["GMclaimedfinyear"].ToString();
            }
        }
        if (DIPCFlag == "Y")
        {
            lblCoiDipcHead.Text = "DISTRICT INDUSTRIES CENTER";
            lblSLCText.Text = "DIPC Number";
            if (ds.Tables[1].Rows[0]["District_Name"].ToString() != null && ds.Tables[1].Rows[0]["District_Name"].ToString() != "")
            {
                lblCoiDipcDist.Text = ds.Tables[1].Rows[0]["District_Name"].ToString().ToUpper();
            }
            //lbldesignation.Text = "DIC";
            if (ds.Tables[1].Rows[0]["applicationno"].ToString() != "" && ds.Tables[1].Rows[0]["applicationno"].ToString() != null)
            {
                lblLetterNo.Text = "DIPC/" + ds.Tables[1].Rows[0]["applicationno"].ToString();
                lblLetterNomngr.Text = "DIPC/" + ds.Tables[1].Rows[0]["applicationno"].ToString();
            }
            if (Request.QueryString["DIPCNumer"] != null)
            {
                lblSLCNo.Text = Request.QueryString["DIPCNumer"].ToString();
            }
        }
        else
        {
            lblCoiDipcHead.Text = "COMMISSIONERATE OF INDUSTRIES";
            lblCoiDipcDist.Text = "HYDERABAD";
            lblSLCText.Text = "SLC Number ";
            //lbldesignation.Text = "Additional Director";
            //lblDistrict2.Text = "<br/>" + "O/o. Commissioner of Industries";

            if (ds.Tables[1].Rows[0]["applicationno"].ToString() != "" && ds.Tables[1].Rows[0]["applicationno"].ToString() != null)
            {
                lblLetterNo.Text = "COI/" + ds.Tables[1].Rows[0]["applicationno"].ToString();
                lblLetterNomngr.Text = "COI/" + ds.Tables[1].Rows[0]["applicationno"].ToString();
            }
        }
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (Request.QueryString["incentiveid"].ToString() == "4477" || Request.QueryString["incentiveid"].ToString() == "4000" || Request.QueryString["incentiveid"].ToString() == "4654")
            {
                lblspecialtext.Visible = true;
            }
            else
            {
                lblspecialtext.Visible = false;
            }

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
            if (ds.Tables[0].Rows[0]["Gmrecommdate"].ToString() != null && ds.Tables[0].Rows[0]["Gmrecommdate"].ToString() != "")
            {
                lblLetterDatemngr.Text = ds.Tables[0].Rows[0]["Gmrecommdate"].ToString();
            }
            if (ds != null && ds.Tables.Count > 2 && ds.Tables[3] != null && ds.Tables[3].Rows.Count > 0)
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

        DateTime DCPBaseDate = Convert.ToDateTime("2014/11/29");  //("29-11-2014");

        if (ds != null && ds.Tables.Count > 1 && ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
        {
            //if (ds.Tables[1].Rows[0]["DCP"].ToString() != "" && ds.Tables[1].Rows[0]["DCP"].ToString() != null)
            //{
            //    DateTime DCP1 = Convert.ToDateTime(ds.Tables[1].Rows[0]["DCP"].ToString());
            //    if (DCP1 > DCPBaseDate)
            //    {
            //        lblTIdeaTPrideIIPP1.Text = "T-IDEA";
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
                //if (DIPCFlag == "Y")
                //{
                //    lblDistrict2.Text = ds.Tables[1].Rows[0]["District_Name"].ToString().ToUpper();
                //}
            }


        }

        if (Request.QueryString["Scheme"] != null)
        {
            string scheme = "";
            scheme = Request.QueryString["Scheme"].ToString();

            lblTIdeaTPrideIIPP1.Text = "TFAP";
            lblTIdeaTPrideIIPP2.Text = "TFAP";
            lblTIdeaTPrideIIPP3.Text = "TFAP";

            if (scheme.Contains("TFAP"))
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
            

        }

    }
}