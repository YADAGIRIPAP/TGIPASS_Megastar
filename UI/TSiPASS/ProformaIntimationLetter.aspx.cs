using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class UI_TSiPASS_ProformaIntimationLetter : System.Web.UI.Page
{
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["uid"] != null)
            {
                //if (Request.QueryString.Count > 0 && Request.QueryString["incentiveid"] != null)
                //{
                    string userid = Session["uid"].ToString();
                    string incentiveid = "";
                    //incentiveid = Request.QueryString["incentiveid"].ToString();
                    incentiveid = "1096";
                    DataSet ds = new DataSet();
                    //ds = Gen.GetBasicUnitDetails(incentiveid);
                    ds = Gen.GetSLCDetails(incentiveid, "3");  // for power sanctioned amount                     
                    binddata(ds);

               // }

            }
        }
    }

    public void binddata(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["SLCNumber"].ToString() != null || ds.Tables[0].Rows[0]["SLCNumber"].ToString() != "")
            {
                lblSLCNo.Text = ds.Tables[0].Rows[0]["SLCNumber"].ToString();
            }
            if (ds.Tables[0].Rows[0]["SLCDateNew"].ToString() != null || ds.Tables[0].Rows[0]["SLCDateNew"].ToString() != "")
            {
                lblSLCDate.Text = ds.Tables[0].Rows[0]["SLCDateNew"].ToString();
            }

            if (ds.Tables[0].Rows[0]["SLCAmount"].ToString() != null || ds.Tables[0].Rows[0]["SLCAmount"].ToString() != "")
            {
                lblSanctionedPowerCost.Text = ds.Tables[0].Rows[0]["SLCAmount"].ToString();
                //int SLCAmount = Convert.ToInt16(lblSanctionedPowerCost.Text.ToString());
                //lblSanctionedAmtDesc.Text = Gen.NumberToWord(SLCAmount);

            }

        }
        if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
        {
            if (ds.Tables[1].Rows[0]["TIDEAflag"].ToString() != "" || ds.Tables[1].Rows[0]["TIDEAflag"].ToString() != null)
            {
                if (ds.Tables[1].Rows[0]["TIDEAflag"].ToString() == "Y")
                {
                    lblTIdeaTPride.Text = "T-IDEA";
                    lblTIdeaTPride2.Text = "T-IDEA";
                    lblTIdeaTPride3.Text = "T-IDEA";
                }
            }
            if (ds.Tables[1].Rows[0]["TSCPflag"].ToString() != "" || ds.Tables[1].Rows[0]["TSCPflag"].ToString() != null)
            {

                if (ds.Tables[1].Rows[0]["TSCPflag"].ToString() == "Y")
                {
                    lblTIdeaTPride.Text = "T-PRIDE";
                    lblTIdeaTPride2.Text = "T-PRIDE";
                    lblTIdeaTPride3.Text = "T-PRIDE";
                }
            }
            if (ds.Tables[1].Rows[0]["TSPflag"].ToString() != "" || ds.Tables[1].Rows[0]["TSPflag"].ToString() != null)
            {
                if (ds.Tables[1].Rows[0]["TSPflag"].ToString() == "Y")
                {
                    lblTIdeaTPride.Text = "T-PRIDE";
                    lblTIdeaTPride2.Text = "T-PRIDE";
                    lblTIdeaTPride3.Text = "T-PRIDE";
                }
            }


            if (ds.Tables[1].Rows[0]["EMiUdyogAadhar"].ToString() != "" || ds.Tables[1].Rows[0]["EMiUdyogAadhar"].ToString() != null)
            {

                lblLetterNo.Text = "COI/" + ds.Tables[1].Rows[0]["EMiUdyogAadhar"].ToString();
            }
            if (ds.Tables[1].Rows[0]["todaydate"].ToString() != null || ds.Tables[1].Rows[0]["todaydate"].ToString() != "")
            {
                lblLetterDate.Text = ds.Tables[1].Rows[0]["todaydate"].ToString();
            }

            if (ds.Tables[1].Rows[0]["ApplicationDate"].ToString() != "" || ds.Tables[1].Rows[0]["ApplicationDate"].ToString() != null)
            {

                lblRefLetterDated.Text = ds.Tables[1].Rows[0]["ApplicationDate"].ToString();
            }
            if (ds.Tables[1].Rows[0]["EMiUdyogAadhar"].ToString() != "" || ds.Tables[1].Rows[0]["EMiUdyogAadhar"].ToString() != null)
            {

                lblRefLetterNo.Text = "COI/" + ds.Tables[1].Rows[0]["EMiUdyogAadhar"].ToString() + ds.Tables[1].Rows[0]["IncentveID"].ToString();
            }


            if (ds.Tables[1].Rows[0]["District_Name"].ToString() != null || ds.Tables[1].Rows[0]["District_Name"].ToString() != "")
            {
                lbldist2.Text = ds.Tables[1].Rows[0]["District_Name"].ToString();

            }

            if (ds.Tables[1].Rows[0]["EnterPreunerDtls"].ToString() != null || ds.Tables[1].Rows[0]["EnterPreunerDtls"].ToString() != "")
            {
                lblEnterpreneurDetails.Text = ds.Tables[1].Rows[0]["EnterPreunerDtls"].ToString();
                lblEnterpreneurDetails3.Text = ds.Tables[1].Rows[0]["EnterPreunerDtls"].ToString();
            }
        }

        if (ds != null && ds.Tables.Count > 2 && ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
        {
            if (ds.Tables[2].Rows[0]["FinYear"].ToString() != null || ds.Tables[2].Rows[0]["FinYear"].ToString() != "")
            {
                lbl1st2ndhallfyear.Text = "2nd";              

                lblFinancialYear.Text =  ds.Tables[2].Rows[0]["FinYear"].ToString();    // need to Clarify

            }
        }

        //// bind query details grid
        //string incentiveid = "";
        //incentiveid = Request.QueryString["incentiveid"].ToString();
        //DataSet dsnew = new DataSet();
        //dsnew = Gen.GetBasicinspectionRPRTDTLS(incentiveid);
        //if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
        //{
        //    if (dsnew.Tables[0].Rows[0]["TotInvSubsidy"].ToString() != null || dsnew.Tables[0].Rows[0]["TotInvSubsidy"].ToString() != "")
        //    {
        //        lblcapitalSubsidyReleased.Text = dsnew.Tables[0].Rows[0]["TotInvSubsidy"].ToString();
        //    }

        //}



    }




}





