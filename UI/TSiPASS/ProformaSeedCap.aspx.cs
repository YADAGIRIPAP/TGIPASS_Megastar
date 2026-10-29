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

public partial class UI_TSiPASS_ProformaSeedCap : System.Web.UI.Page
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
            string incentiveid = "";
            incentiveid = Request.QueryString["incentiveid"].ToString();
           // incentiveid = "1110";

            DataSet ds2 = new DataSet();
            ds2 = Gen.GetBasicUnitDetails_Proforma_letters(incentiveid, "10");
            binddatanew(ds2);

            }           

        }

    }



    public void binddatanew(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["unitdistrict"].ToString() != null && ds.Tables[0].Rows[0]["unitdistrict"].ToString() != string.Empty)
            {
                lblDistrict.Text = ds.Tables[0].Rows[0]["unitdistrict"].ToString();
            }
            if (ds.Tables[0].Rows[0]["applicationno"].ToString() != null && ds.Tables[0].Rows[0]["applicationno"].ToString() != string.Empty)
            {
                lblLetterNo.Text = "COI/" + ds.Tables[0].Rows[0]["applicationno"].ToString();
            }
            if (ds.Tables[0].Rows[0]["todaydate"].ToString() != null && ds.Tables[0].Rows[0]["todaydate"].ToString() != "") // need to Clarify
            {
                lblLetterDate.Text = ds.Tables[0].Rows[0]["todaydate"].ToString();
            }

            if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() != "" && ds.Tables[0].Rows[0]["TIDEAflag"].ToString() != null)
            {
                if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() == "Y")
                {
                    lblTIdeaTPride1.Text = "T-IDEA";
                    lblTIdeaTPride2.Text = "T-IDEA";
                    lblTIdeaTPride3.Text = "T-IDEA";
                }
            }
            if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() != "" && ds.Tables[0].Rows[0]["TSCPflag"].ToString() != null)
            {

                if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() == "Y")
                {
                    lblTIdeaTPride1.Text = "T-PRIDE(TSCP)";
                    lblTIdeaTPride2.Text = "T-PRIDE(TSCP)";
                    lblTIdeaTPride3.Text = "T-PRIDE(TSCP)";
                }
            }
            if (ds.Tables[0].Rows[0]["TSPflag"].ToString() != "" && ds.Tables[0].Rows[0]["TSPflag"].ToString() != null)
            {
                if (ds.Tables[0].Rows[0]["TSPflag"].ToString() == "Y")
                {
                    lblTIdeaTPride1.Text = "T-PRIDE(TSP)";
                    lblTIdeaTPride2.Text = "T-PRIDE(TSP)";
                    lblTIdeaTPride3.Text = "T-PRIDE(TSP)";
                }
            }

            if (ds.Tables[0].Rows[0]["UnitDtls"].ToString() != null && ds.Tables[0].Rows[0]["UnitDtls"].ToString() != "")
            {
                lblEnterpreneurDetails1.Text = ds.Tables[0].Rows[0]["UnitDtls"].ToString();
                lblEnterpreneurDetails2.Text = ds.Tables[0].Rows[0]["UnitDtls"].ToString();
            }
            if (ds.Tables[0].Rows[0]["IncentveID"].ToString() != null && ds.Tables[0].Rows[0]["IncentveID"].ToString() != "")
            {
                lblRefApplicationNo.Text = "COI/" + ds.Tables[0].Rows[0]["IncentveID"].ToString();
            }
            if (ds.Tables[0].Rows[0]["ApplicationDate"].ToString() != null && ds.Tables[0].Rows[0]["ApplicationDate"].ToString() != "")
            {
                lblRefApplnDate.Text = ds.Tables[0].Rows[0]["ApplicationDate"].ToString();
            }
            if (ds.Tables[0].Rows[0]["DCPNew"].ToString() != null && ds.Tables[0].Rows[0]["DCPNew"].ToString() != "")
            {
                lblDCP.Text = ds.Tables[0].Rows[0]["DCPNew"].ToString();
            }


            if (ds.Tables[0].Rows[0]["UdyogAadharType"].ToString() != null && ds.Tables[0].Rows[0]["UdyogAadharType"].ToString() != "") // need to Clarify
            {
                string udyognotype = ds.Tables[0].Rows[0]["UdyogAadharType"].ToString();
                //if (udyognotype == "1")
                //{
                if (ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != null && ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != "") // need to Clarify
                {
                    lbludyogaadharno.Text = ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString() != null && ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString() != "") // need to Clarify
                {
                    lblUdyogAadhaardate.Text = ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString();
                }
                // }
            }
            if (ds.Tables[0].Rows[0]["TinNO"].ToString() != null && ds.Tables[0].Rows[0]["TinNO"].ToString() != "") // need to Clarify
            {
              //  lblTinno.Text = ds.Tables[0].Rows[0]["TinNO"].ToString();
            }

        }

        //  Tables[1] 
        if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
        {
            if (ds.Tables[1].Rows[0]["InpectedDate"].ToString() != null && ds.Tables[1].Rows[0]["InpectedDate"].ToString() != "")
            {
                lblinspecteddt.Text = ds.Tables[1].Rows[0]["InpectedDate"].ToString();
            }

        }

        //  Tables[2] 
        if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
        {
            //if (ds.Tables[2].Rows[0]["FinancialYearNew"].ToString() != null && ds.Tables[2].Rows[0]["FinancialYearNew"].ToString() != "")
            //{
                //lblFinancialYear2.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();
                //lblFinancialYear3.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();
                //lblFinancialYear4.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();
            //}
            lblFinancialYear2.Text = "2016-17";
            lblFinancialYear3.Text = "2016-17";
            lblFinancialYear4.Text = "2016-17";

            if (ds.Tables[2].Rows[0]["Amountclaimed"].ToString() != null && ds.Tables[2].Rows[0]["Amountclaimed"].ToString() != "")
            {
                lblSTAmountPaid.Text = ds.Tables[2].Rows[0]["Amountclaimed"].ToString();
                lblSTAmountPaid1.Text = ds.Tables[2].Rows[0]["Amountclaimed"].ToString();
                //lblSTAmountPaid3.Text = ds.Tables[2].Rows[0]["Amountclaimed"].ToString();

                //int AmountPaid = Convert.ToInt32(Convert.ToDouble(lblSTAmountPaid3.Text.ToString()));
                //lblSanctionedAmtDesc.Text = Gen.NumberToWord(AmountPaid);
            }


            // need to clarify
            lbl1st2nd1.Text = "2nd";
            lbl1st2nd2.Text = "2nd";
            lbl1st2nd3.Text = "2nd";

        }

        if (ds != null && ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
        {

            if (ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString() != null && ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString() != "")
            {
                lblSTAmountPaid3.Text = ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString(); ;

                int AmountPaid = Convert.ToInt32(Convert.ToDouble(lblSTAmountPaid3.Text.ToString()));
                lblSanctionedAmtDesc.Text = Gen.NumberToWord(AmountPaid);

            }
        }

    }



}