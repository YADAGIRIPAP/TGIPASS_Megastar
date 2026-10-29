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
using System.Drawing;


public partial class UI_TSiPASS_ProformaWood : System.Web.UI.Page
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
                // incentiveid = "1098";

                DataSet ds2 = new DataSet();
                ds2 = Gen.GetBasicUnitDetails_Proforma_lettersPSR(incentiveid, "19");
                binddatanew(ds2);

                DataSet dsname = new DataSet();
                //dsname = Gen.GetIPORecommendationOfficerDetailsDIC(incentiveid, "5", "");
                //if (dsname.Tables.Count > 0 && dsname.Tables[0].Rows.Count > 0)
                //{
                //    if (dsname.Tables[0].Rows[0]["GMNamerecom"].ToString() != null)
                //    {
                //        lblName.Text = dsname.Tables[0].Rows[0]["GMNamerecom"].ToString() + "</br>" + dsname.Tables[0].Rows[0]["GMDesignation"].ToString() + "</br>" + dsname.Tables[0].Rows[0]["GMDist"].ToString();
                //    }
                //}

                dsname = Gen.GetIncentiveOfficerNamesForAll(incentiveid, "19", userid, "", "RECOMMENDATION");
                if (dsname.Tables.Count > 0 && dsname.Tables[0].Rows.Count > 0)
                {
                    if (dsname.Tables[0].Rows[0]["IPODetails"].ToString() != null)
                    {
                        lblInspectedOfficer.Text = dsname.Tables[0].Rows[0]["IPODetails"].ToString();
                    }
                    if (dsname.Tables[0].Rows[0]["GMNamerecom"].ToString() != null)
                    {
                        lblGMname.Text = dsname.Tables[0].Rows[0]["GMNamerecom"].ToString();
                        lblDICName.Text = dsname.Tables[0].Rows[0]["GMNamerecom"].ToString();
                    }
                }
            }
        }
    }
    public void binddatanew(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
        {
            lblDistrict.Text = ds.Tables[1].Rows[0]["Unitdistrict"].ToString();
            lblLetterNo.Text = "COI/" + ds.Tables[1].Rows[0]["Applicationno"].ToString() + "/GMREC-ST";
            lblLetterDate.Text = ds.Tables[1].Rows[0]["RecommendedDate"].ToString();
            lblEnterpreneurDetails1.Text = ds.Tables[1].Rows[0]["UnitDtls"].ToString();
            lblEnterpreneurDetails2.Text = ds.Tables[1].Rows[0]["UnitDtls"].ToString();
            lblRefApplicationNo.Text = ds.Tables[1].Rows[0]["applicationno"].ToString();
            lblRefApplnDate.Text = ds.Tables[1].Rows[0]["ApplicationDate"].ToString();
            lbldist3.Text = "DIC-" + ds.Tables[1].Rows[0]["unitdistrict"].ToString();
            lbldist2.Text = ds.Tables[1].Rows[0]["unitdistrict"].ToString();

            if (ds.Tables[1].Rows[0]["Scheme"].ToString() != "" && ds.Tables[1].Rows[0]["Scheme"].ToString() != null)
            {
                string strscheme = "";
                strscheme = ds.Tables[1].Rows[0]["Scheme"].ToString();

                if (strscheme == "TIDEA" || strscheme == "TPRIDE" || strscheme == "T-PRIDE")
                {
                    if (ds.Tables[1].Rows[0]["TIDEAflag"].ToString() != "" && ds.Tables[1].Rows[0]["TIDEAflag"].ToString() != null)
                    {
                        if (ds.Tables[1].Rows[0]["TIDEAflag"].ToString() == "Y")
                        {
                            lblTIdeaTPride1.Text = "T-IDEA";
                            lblTIdeaTPride2.Text = "T-IDEA";
                            lblIIPPScheme4.Text = "T-IDEA";
                            Tideaorpride.Text = "T-IDEA";
                            lblIIPPScheme3.Text = "T-IDEA";
                        }
                    }
                    if (ds.Tables[1].Rows[0]["TSCPflag"].ToString() != "" && ds.Tables[1].Rows[0]["TSCPflag"].ToString() != null)
                    {

                        if (ds.Tables[1].Rows[0]["TSCPflag"].ToString() == "Y")
                        {
                            lblTIdeaTPride1.Text = "T-PRIDE(TSCP)";
                            lblTIdeaTPride2.Text = "T-PRIDE(TSCP)";
                            lblIIPPScheme4.Text = "T-PRIDE(TSCP)";
                            Tideaorpride.Text = "T-PRIDE(TSCP)";
                            lblIIPPScheme3.Text = "T-PRIDE(TSCP)";
                        }
                    }
                    if (ds.Tables[1].Rows[0]["TSPflag"].ToString() != "" && ds.Tables[1].Rows[0]["TSPflag"].ToString() != null)
                    {
                        if (ds.Tables[0].Rows[0]["TSPflag"].ToString() == "Y")
                        {
                            lblTIdeaTPride1.Text = "T-PRIDE(TSP)";
                            lblTIdeaTPride2.Text = "T-PRIDE(TSP)";
                            lblIIPPScheme4.Text = "T-PRIDE(TSP)";
                            Tideaorpride.Text = "T-PRIDE(TSP)";
                            lblIIPPScheme3.Text = "T-PRIDE(TSP)";
                        }
                    }

                    //1	Micro
                    //2	Small
                    //3	Medium
                    //4	Large
                    //5	Mega

                    if (ds.Tables[1].Rows[0]["Category"].ToString() == "1" || ds.Tables[1].Rows[0]["Category"].ToString() == "2")
                    {
                        lblpercentage.Text = "100%";
                        lblpercentagenew.Text = "100%";
                    }
                    else if (ds.Tables[1].Rows[0]["Category"].ToString() == "3")
                    {
                        lblpercentage.Text = "75%";
                        lblpercentagenew.Text = "75%";
                    }
                    else if (ds.Tables[1].Rows[0]["Category"].ToString() == "4" || ds.Tables[1].Rows[0]["Category"].ToString() == "5")
                    {
                        lblpercentage.Text = "50%";
                        lblpercentagenew.Text = "50%";
                    }
                }
                else if (strscheme == "IIPP 2005-10" || strscheme == "IIPP 2010-15")
                {
                    lblTIdeaTPride1.Text = strscheme;
                    lblTIdeaTPride2.Text = strscheme;
                    lblIIPPScheme4.Text = strscheme;
                    Tideaorpride.Text = strscheme;
                    lblIIPPScheme3.Text = strscheme;
                    //1	Micro
                    //2	Small
                    //3	Medium
                    //4	Large
                    //5	Mega

                    if (ds.Tables[1].Rows[0]["Category"].ToString() == "1")
                    {
                        lblpercentage.Text = "100%";
                        lblpercentagenew.Text = "100%";
                    }
                    else if (ds.Tables[1].Rows[0]["Category"].ToString() == "2")
                    {
                        lblpercentage.Text = "50%";
                        lblpercentagenew.Text = "50%";
                    }
                    else if (ds.Tables[1].Rows[0]["Category"].ToString() == "3" || ds.Tables[1].Rows[0]["Category"].ToString() == "4" || ds.Tables[1].Rows[0]["Category"].ToString() == "5")
                    {
                        lblpercentage.Text = "25%";
                        lblpercentagenew.Text = "25%";
                    }
                }
            }
            lblFinancialYear1.Text = ds.Tables[1].Rows[0]["GMclaimedfinyear"].ToString();
            lblFinancialYear5.Text = ds.Tables[1].Rows[0]["GMclaimedfinyear"].ToString();
            lblFinancialYear2.Text = ds.Tables[1].Rows[0]["GMclaimedfinyear"].ToString();
            lblFinancialYear3.Text = ds.Tables[1].Rows[0]["GMclaimedfinyear"].ToString();
            lblFinancialYear6.Text = ds.Tables[1].Rows[0]["GMclaimedfinyear"].ToString();

            lblinspecteddt.Text = ds.Tables[1].Rows[0]["InpectedDate"].ToString();
            lbludyogaadharType.Text = ds.Tables[1].Rows[0]["UdyogAadhartype"].ToString();
            lbludyogaadharno.Text = ds.Tables[1].Rows[0]["EMiUdyogAadhar"].ToString();
            lblUdyogAadhaardate.Text = ds.Tables[1].Rows[0]["UdyogAadhaarRegdDateNew"].ToString();
            lblloa.Text = ds.Tables[1].Rows[0]["LOADTLS"].ToString();
            lblDCP.Text = ds.Tables[1].Rows[0]["DCPNew"].ToString();
            //lblTinno.Text = ds.Tables[1].Rows[0]["TinNO"].ToString();
            int AmountPaid = Convert.ToInt32(Convert.ToDouble(ds.Tables[1].Rows[0]["GM_Rcon_Amount"].ToString()));
            lblSTAmountPaid1.Text = NumberToCurrency(Convert.ToInt32(Convert.ToDouble((ds.Tables[1].Rows[0]["GM_Rcon_Amount"].ToString())))) + " (" + Gen.NumberToWord(AmountPaid) + " Rupees Only)";
            lblSTAmountPaid3.Text = NumberToCurrency(Convert.ToInt32(Convert.ToDouble((ds.Tables[1].Rows[0]["GM_Rcon_Amount"].ToString()))));
            lblSanctionedAmtDesc.Text = Gen.NumberToWord(AmountPaid);
            lblRemarks.Text = ds.Tables[1].Rows[0]["GMRecommendedRemarks"].ToString();
            if (lblRemarks.Text.Trim() != "")
            {
                trRemarks.Visible = true;
            }

            int UnitClaimedAmount = Convert.ToInt32(Convert.ToDouble(ds.Tables[1].Rows[0]["UnitClaimedAmount"].ToString()));
            lblSTAmountPaid.Text = NumberToCurrency(Convert.ToInt32(Convert.ToDouble((ds.Tables[1].Rows[0]["UnitClaimedAmount"].ToString())))) + " (" + Gen.NumberToWord(UnitClaimedAmount) + " Rupees Only)";


            // lblSTAmountPaid.Text = NumberToCurrency(Convert.ToInt64(ds.Tables[0].Rows[0]["FinalTotalAmountPaid"]));

            //1	Micro
            //2	Small
            //3	Medium
            //4	Large
            //5	Mega

            //if (ds.Tables[0].Rows[0]["Category"].ToString() != null && ds.Tables[0].Rows[0]["Category"].ToString() != "")
            //{
            //    if (ds.Tables[0].Rows[0]["Category"].ToString() == "4")
            //    {
            //        if (ds.Tables[0].Rows[0]["scheme"].ToString() != null && ds.Tables[0].Rows[0]["scheme"].ToString() != "")
            //        {
            //            string unitcategory = ds.Tables[0].Rows[0]["scheme"].ToString();
            //            if (unitcategory.Contains("IIPP"))
            //            {
            //                lblpercentage.Text = "25%";
            //                lblpercentagenew.Text = "25%";
            //            }
            //            else if (unitcategory.Contains("IDEA"))
            //            {
            //                lblpercentage.Text = "50%";
            //                lblpercentagenew.Text = "50%";
            //            }
            //        }
            //    }
            //    else
            //    {
            //        lblpercentage.Text = "100%";
            //        lblpercentagenew.Text = "100%";
            //    }
            //}
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

    #endregion
}