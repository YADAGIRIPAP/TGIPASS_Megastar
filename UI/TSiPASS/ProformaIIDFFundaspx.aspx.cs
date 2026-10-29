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

public partial class UI_TSiPASS_ProformaIIDFFundaspx : System.Web.UI.Page
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


                //DataSet ds = new DataSet();
                //ds = Gen.GetIncentiveDeptDetails(incentiveid);
                //FillDetails(ds);

                DataSet ds2 = new DataSet();
                ds2 = Gen.GetBasicUnitDetails_Proforma_lettersPSR(incentiveid, "7"); // -- IIDF
                binddatanew(ds2);

                DataSet dsname = new DataSet();
                //dsname = Gen.GetIPORecommendationOfficerDetailsDIC(incentiveid, "7", "");  // -- IIDF
                //if (dsname.Tables.Count > 0 && dsname.Tables[0].Rows.Count > 0)
                //{
                //    if (dsname.Tables[0].Rows[0]["GMNamerecom"].ToString() != null)
                //    {
                //        lblDICName.Text = dsname.Tables[0].Rows[0]["GMNamerecom"].ToString(); // + "</br>" + dsname.Tables[0].Rows[0]["Designation"].ToString() + "</br>" + dsname.Tables[0].Rows[0]["Dist"].ToString();
                //        lblGMname.Text = dsname.Tables[0].Rows[0]["GMNamerecom"].ToString();
                //    }
                //}
                dsname = Gen.GetIncentiveOfficerNamesForAll(incentiveid, "7", userid, "", "RECOMMENDATION");
                if (dsname.Tables.Count > 0 && dsname.Tables[0].Rows.Count > 0)
                {
                    if (dsname.Tables[0].Rows[0]["GMNamerecom"].ToString() != null)
                    {
                        lblGMname.Text = dsname.Tables[0].Rows[0]["GMNamerecom"].ToString();
                        lblDICName.Text = dsname.Tables[0].Rows[0]["GMNamerecom"].ToString(); // + "</br>" + dsname.Tables[0].Rows[0]["Designation"].ToString() + "</br>" + dsname.Tables[0].Rows[0]["Dist"].ToString();
                    }
                    if (dsname.Tables[0].Rows[0]["IPODetails"].ToString() != null)
                    {
                        lblInspectedOfficer.Text = dsname.Tables[0].Rows[0]["IPODetails"].ToString();
                    }
                }
            }
        }
    }

    public void binddatanew(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
        {
            lbldist1.Text = ds.Tables[1].Rows[0]["Unitdistrict"].ToString();
            lblLetterNo.Text = "COI/" + ds.Tables[1].Rows[0]["Applicationno"].ToString() + "/GMREC-IIDF";
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

                if (strscheme == "TIDEA" || strscheme == "TPRIDE" || strscheme == "T-PRIDE" || strscheme == "TFAP")
                {
                    if (ds.Tables[1].Rows[0]["TIDEAflag"].ToString() != "" && ds.Tables[1].Rows[0]["TIDEAflag"].ToString() != null)
                    {
                        if (ds.Tables[1].Rows[0]["TIDEAflag"].ToString() == "Y")
                        {
                            lblTIdeaTPride1.Text = "T-IDEA";
                            lblTIdeaTPride2.Text = "T-IDEA";
                            lblTIdeaTPride3.Text = "T-IDEA";
                            Tideaorpride.Text = "T-IDEA";
                        }
                    }
                    if (ds.Tables[1].Rows[0]["TSCPflag"].ToString() != "" && ds.Tables[1].Rows[0]["TSCPflag"].ToString() != null)
                    {

                        if (ds.Tables[1].Rows[0]["TSCPflag"].ToString() == "Y")
                        {
                            lblTIdeaTPride1.Text = "T-PRIDE(TSCP)";
                            lblTIdeaTPride2.Text = "T-PRIDE(TSCP)";
                            lblTIdeaTPride3.Text = "T-PRIDE(TSCP)";
                            Tideaorpride.Text = "T-PRIDE(TSCP)";
                        }
                    }
                    if (ds.Tables[1].Rows[0]["TSPflag"].ToString() != "" && ds.Tables[1].Rows[0]["TSPflag"].ToString() != null)
                    {
                        if (ds.Tables[1].Rows[0]["TSPflag"].ToString() == "Y")
                        {
                            lblTIdeaTPride1.Text = "T-PRIDE(TSP)";
                            lblTIdeaTPride2.Text = "T-PRIDE(TSP)";
                            lblTIdeaTPride3.Text = "T-PRIDE(TSP)";
                            Tideaorpride.Text = "T-PRIDE(TSP)";
                        }
                    }
                    if (ds.Tables[1].Rows[0]["IsDifferentlyAbled"].ToString() != null && ds.Tables[1].Rows[0]["IsDifferentlyAbled"].ToString() != string.Empty)
                    {
                        if (ds.Tables[1].Rows[0]["IsDifferentlyAbled"].ToString() == "Y")   // SC
                        {
                            lblTIdeaTPride1.Text = "T-PRIDE(PHC)";
                            lblTIdeaTPride2.Text = "T-PRIDE(PHC)";
                            lblTIdeaTPride3.Text = "T-PRIDE(PHC)";
                            Tideaorpride.Text = "T-PRIDE(PHC)";
                        }
                    }
                }
                else if (strscheme == "IIPP 2005-10" || strscheme == "IIPP 2010-15")
                {
                    lblTIdeaTPride1.Text = strscheme;
                    lblTIdeaTPride2.Text = strscheme;
                    lblTIdeaTPride3.Text = strscheme;
                    Tideaorpride.Text = strscheme;
                }
                if (ds.Tables[1].Rows[0]["MSME_Applied"].ToString() == "Y")
                {
                    Tideaorpride.Text = Tideaorpride.Text.Replace("T-PRIDE", "MSME-2024 ").Replace("T-IDEA", "MSME-2024 ");
                    lblTIdeaTPride1.Text = lblTIdeaTPride1.Text.Replace("T-PRIDE", "MSME-2024 ").Replace("T-IDEA", "MSME-2024 ");
                    lblTIdeaTPride2.Text = lblTIdeaTPride2.Text.Replace("T-PRIDE", "MSME-2024 ").Replace("T-IDEA", "MSME-2024 ");
                    lblTIdeaTPride3.Text = lblTIdeaTPride3.Text.Replace("T-PRIDE", "MSME-2024 ").Replace("T-IDEA", "MSME-2024 ");

                }
            }

            lblinspecteddt.Text = ds.Tables[1].Rows[0]["InpectedDate"].ToString();
            lbludyogaadharType.Text = ds.Tables[1].Rows[0]["UdyogAadhartype"].ToString();
            lbludyogaadharno.Text = ds.Tables[1].Rows[0]["EMiUdyogAadhar"].ToString();
            lblUdyogAadhaardate.Text = ds.Tables[1].Rows[0]["UdyogAadhaarRegdDateNew"].ToString();
            lblloa.Text = ds.Tables[1].Rows[0]["LOADTLS"].ToString();
            lblDCP.Text = ds.Tables[1].Rows[0]["DCPNew"].ToString();

            int AmountPaid = Convert.ToInt32(Convert.ToDouble(ds.Tables[1].Rows[0]["GM_Rcon_Amount"].ToString()));
            lblSTAmountPaid1.Text = NumberToCurrency(Convert.ToInt32(Convert.ToDouble((ds.Tables[1].Rows[0]["GM_Rcon_Amount"].ToString())))) + " (" + Gen.NumberToWord(AmountPaid) + " Rupees Only)";
            lblSTAmountPaid3.Text = NumberToCurrency(Convert.ToInt32(Convert.ToDouble((ds.Tables[1].Rows[0]["GM_Rcon_Amount"].ToString()))));
            lblSanctionedAmtDesc.Text = Gen.NumberToWord(AmountPaid);
            lblRemarks.Text = ds.Tables[1].Rows[0]["GMRecommendedRemarks"].ToString();
            if (lblRemarks.Text.Trim() != "")
            {
                trRemarks.Visible = true;
            }
            lblSTAmountPaid.Text = ds.Tables[0].Rows[0]["AmtClaimed"].ToString();
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

    public void FillDetails(DataSet ds)
    {
        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows[0]["LineofActivity"].ToString() != "" && ds.Tables[1].Rows[0]["LineofActivity"].ToString() != null)
                {
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        lblloa.Text = ds.Tables[1].Rows[i]["LineofActivity"].ToString() + ", ";
                    }
                }
            }
        }
    }
}