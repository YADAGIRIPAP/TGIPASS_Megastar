using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_AppraisalNote_PV : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    //ArrayList arListApplNo = new ArrayList();
    ArrayList arListApplNo = null;
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //string applicationNo;
            //applicationNo = "185121";
            //arListApplNo.Add(applicationNo);

            //applicationNo = "206514";
            //arListApplNo.Add(applicationNo);

            //applicationNo = "251213";
            //arListApplNo.Add(applicationNo);

            //applicationNo = "211221";
            //arListApplNo.Add(applicationNo);

            //applicationNo = "241947";
            //arListApplNo.Add(applicationNo);


            arListApplNo = (ArrayList)Session["applicationNo"];

            getDetails();
        }
        catch (Exception ex)
        { throw ex; }

    }
    public void getLOAData(DataSet ds1)
    {

        //gvInstalledCap.DataSource = ds1.Tables[1];
        //gvInstalledCap.DataBind();
    }
    private void fildetails()
    {
        foreach (string Item in arListApplNo)
        {
        }
    }
    public void getDetails()
    {
        int j = 0;
        StringBuilder sbPrint = new StringBuilder();

        int count = 0;
        foreach (string Item in arListApplNo)
        {
            //string IncentiveId = "87701";// Request.QueryString["incid"].ToString();
            //string MasterIncentiveId = "6";// Request.QueryString["mstid"].ToString();
            SqlConnection osqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
            osqlConnection.Open();
            SqlDataAdapter da;
            da = new SqlDataAdapter("USP_GETDETAILSFORSECTION_Appraisal_IS_New1", osqlConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.SelectCommand.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = Item;
            da.SelectCommand.Parameters.Add("@mstincentiveid", SqlDbType.VarChar).Value = "1";
            da.Fill(ds);

            getLOAData(ds);
            DataSet ds2 = new DataSet();
            ds2 = Gen.GetBasicUnitDetails_Proforma_lettersPSR(Item, "1");
            DataSet dsgrid = DB_apprasialnote2pallavaddi(Item, "");

            if (ds.Tables[0].Rows.Count > 0)//[lblLand_ProjectCost]   
            {
                if (ds.Tables[0].Rows[0]["lblTideaTpride"].ToString() == "Y")
                {
                    //tprideTr.Visible = true;
                    //tideaTr.Visible = false;
                }
                else if (ds.Tables[0].Rows[0]["lblTideaTpride"].ToString() == "N")
                {
                    ////    tprideTr.Visible = true;
                    ////    tideaTr.Visible = false;
                    //tprideTr.Visible = false;
                    //tideaTr.Visible = true height:2050px;
                }

                #region DYNAMIC PRINT
                sbPrint.Append("<table style = ' width:100%; border:1px solid black;' >");
                sbPrint.Append("<tr><td>");
                sbPrint.Append("<center>");
                sbPrint.Append("<img src = 'viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/telanganalogo.png' width = '75px' height = '75px' />");
                sbPrint.Append("</center>");
                // sbPrint.Append("</div> ");

                if (ds.Tables[0].Rows[0]["lblTideaTpride"].ToString() == "Y")
                {
                    sbPrint.Append("<table  align='center' style='width: 100%;' border='0px' cellpadding='0px' cellspacing='0px'>");
                    sbPrint.Append("<tr><td class='heading' colspan='4' style='text-align: center; font-size: 10pt'><b>Telangana State Industrial Development and Entrepreneur Advancement - G.O M.S. NO 29, Industries &<br/>Commerce (IP & INF) Department, Dated : 29/11/2014 &nbsp;<br /></td></tr>");

                }
                else if (ds.Tables[0].Rows[0]["lblTideaTpride"].ToString() == "N")
                {
                    sbPrint.Append("<table  align='center' style='width: 100%;;' border='0px' cellpadding='0px' cellspacing='0px'>");
                    sbPrint.Append("<tr><td class='heading' colspan='4' style='text-align: center; font-size: 10pt'><b>T-PRIDE -" + ds.Tables[0].Rows[0]["CASTENAME"].ToString() + "- G.O M.S. NO 29, Industries &amp; Commerce (IP &amp; INF) Department, Dated:29/11/2014</td></tr>");

                }
                sbPrint.Append("<tr><td class='heading' colspan='4' style='text-align: center'><u><b>Appraisal Note - Sanction of Investment Subsidy</b></u></td></tr>");

                sbPrint.Append("<tr><td class='heading' colspan='4' style='text-align: center'></td></tr>");
                sbPrint.Append("<tr ><td>" +
                    "<table cellpadding='0px' cellspacing='0px' style='width: 100%;'>" +
                    "<tr><td style='height: 10px; width: 0px;' class='addressing' valign='top' align='left'> </td><td style='height: 15px; width: 700px;' class='addressing' valign='top' align='left'>Application no</td>&nbsp;<td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'> </td>&nbsp;<td style='height: 15px;width: 500px;' class='addressing' valign='top' align='left'> " + ds.Tables[0].Rows[0]["lblApplicationno"].ToString() + " &nbsp;</td></tr>");
                sbPrint.Append("<tr><td style='height: 15px; width: 0px;' class='addressing' valign='top' align='left'>1.</td><td style='height: 15px;' width: 700px;' class='addressing' valign='top' align='left'> Name of Industrial Concern</td><td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'> </td>&nbsp;<td style='height: 15px;width: 1000px;' class='addressing'  valign='top' align='left'>" + "<b>" + ds.Tables[0].Rows[0]["txtunitnames"].ToString() + "</b>" + "</td></tr>");
                sbPrint.Append("<tr><td style='height: 15px; width: 0px;' class='addressing' valign='top' align='left'>2.</td><td style='height: 15px;' width: 700px;' class='addressing' valign='top' align='left'> Location of the Industrial concern</td><td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'></td><td style='height: 15px;' class='addressing' valign='top' align='left'>" + ds.Tables[0].Rows[0]["txtLocofUnit"].ToString() + "</td></tr>");
                sbPrint.Append("<tr><td style='height: 15px; width: 0px;' class='addressing' valign='top' align='left'>3.</td><td style='height: 15px;' width: 700px;' class='addressing' valign='top' align='left'> Name of Promoter</td><td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'></td><td style='height: 15px;' class='addressing' valign='top' align='left'> " + ds.Tables[0].Rows[0]["ApplciantName"].ToString() + "</td></tr>");
                sbPrint.Append("<tr><td style='height: 15px; width: 0px;' class='addressing' valign='top' align='left'>4.</td><td style='height: 15px;' width: 700px;' class='addressing' valign='top' align='left'> Constitution of the Industrial Concern &nbsp;</td><td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'></td><td style='height: 15px;' class='addressing' valign='top' align='left'> " + ds.Tables[0].Rows[0]["ddlOrddlorgtypes"].ToString() + "</td></tr>");
                sbPrint.Append("<tr><td style='height: 15px; width: 0px;' class='addressing' valign='top' align='left'>5.</td><td style='height: 15px;' width: 700px;' class='addressing' valign='top' align='left'> Social Status(Original Certificate to be enclosed)</td><td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'></td><td style='height: 15px;' class='addressing' valign='top' align='left'>" + ds.Tables[0].Rows[0]["CASTE"].ToString() + "</td></tr>");
                sbPrint.Append("<tr><td style='height: 15px; width: 0px;' class='addressing' valign='top' align='left'>6.</td><td style='height: 15px;' width: 700px;' class='addressing' valign='top' align='left'> Share of SC/ST/Women Enterpreneur</td><td style='height: 15px;' class='addressing' valign='top' align='left'></td><td style='height: 15px;' class='addressing' valign='top' align='left'>" + ds.Tables[0].Rows[0]["ApplciantName"].ToString() + "</td></tr>");
                sbPrint.Append("<tr><td style='height: 15px; width: 0px;' class='addressing' valign='top' align='left'>7.</td><td style='height: 15px;' width: 700px;' class='addressing' valign='top' align='left'> PMT SSI Registration. No. & Date&nbsp;<br />&nbsp;held a conductor's licence issued by</td><td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'></td><td style='height: 15px;' class='addressing' valign='top' align='left'>" + ds.Tables[0].Rows[0]["txtPersonIndustry"].ToString() + "</td></tr>");
                sbPrint.Append("<tr><td style='height: 15px; width: 0px;' class='addressing' valign='top' align='left'>8.</td><td style='height: 15px;' width: 700px;' class='addressing' valign='top' align='left'> New/Expansion/Diversification Unit</td><td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'></td><td style='height: 15px;' class='addressing' valign='top' align='left'>" + ds.Tables[0].Rows[0]["IdsustryStatus"].ToString() + " </td></tr>");
                sbPrint.Append("<tr><td style='height: 15px; width: 0px;' class='addressing' valign='top' align='left'>9.</td><td style='height: 15px;' width: 700px;' class='addressing' valign='top' align='left'> Date of commencement of production<br />&nbsp;</td><td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'></td><td style='height: 15px;' class='addressing' valign='top' align='left'>" + ds.Tables[0].Rows[0]["txtDCP_unit"].ToString() + "</td></tr>");
                sbPrint.Append("<tr><td style='height: 15px; width: 0px;' class='addressing' valign='top' align='left'>10.</td><td style='height: 15px;' width: 700px;' class='addressing' valign='top' align='left'> Date of filing of claim application in DIC&nbsp&nbsp;</td><td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'></td><td style='height: 15px;' class='addressing' valign='top' align='left'>" + ds.Tables[0].Rows[0]["txtDateOfapplnFile"].ToString() + "</td></tr>");
                sbPrint.Append("<tr><td style='height: 15px; width: 0px;' class='addressing' valign='top' align='left'>11.</td><td style='height: 15px;' width: 700px;' class='addressing' valign='top' align='left'> Name of Financing Institution in case of Aided Units&nbsp;</td><td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'></td><td style='height: 15px;' class='addressing' valign='top' align='left'>" + ds.Tables[0].Rows[0]["txtNameofFinIns"].ToString() + "</td></tr>");
                sbPrint.Append("<tr><td style='height: 15px; width: 0px;' class='addressing' valign='top' align='left'>12.</td><td style='height: 15px;' width: 700px;' class='addressing' valign='top' align='left'> Claim Period &nbsp;</td><td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'></td><td style='height: 15px;' class='addressing' valign='top' align='left'>" + ds2.Tables[1].Rows[0]["GMclaimedfinyear"].ToString() + "</td></tr>");

                sbPrint.Append("<tr><td style='height: 15px; width: 0px;' class='addressing' valign='top' align='left'>13.</td><td style='height: 15px;' width: 700px;' class='addressing' valign='top' align='left'> Confirmed by GM &nbsp;</td><td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'></td><td style='height: 15px;' class='addressing' valign='top' align='left'>" + ds.Tables[0].Rows[0]["DetailsGm"].ToString() + "</td></tr>");

                sbPrint.Append("</table></td></tr></table>");
                // Line of ACtivity block start
                sbPrint.Append("<table  align='left' style='width: 650px;' border='0' cellpadding='0px' cellspacing='0px'>");
                sbPrint.Append("<tr ><td><table cellpadding='0px' cellspacing='0px' style='width: 80%;'><td style='height: 10px; width: 0px;' class='addressing' valign='top' align='left'> </td><td style='width: 500px;' class='addressing' valign='top' align='left'><u><b>Line of Activity</b></td>&nbsp;<td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'> </td>&nbsp;<td style='height: 15px;width: 500px;' class='addressing' valign='top' align='left'> </td></tr>");
                sbPrint.Append("</table></td></tr></table>");
                sbPrint.Append("<table cellpadding='0px' border='2px' cellspacing='0px' style='width: 80%;' align='left'>");
                sbPrint.Append("<tr align='center'><th class='heading' style='font-size: 12pt;'>Sl.No</th><th class='heading' style='font-size: 12pt'>Line Of Activity</th><th class='heading' style='font-size: 12pt'>Installed Capacity</th><th class='heading' style='font-size: 12pt'>Unit</th><th class='heading' style='font-size: 12pt'>Value (in Rs.)</th></tr>");
                for (int tbl1 = 0; tbl1 < ds.Tables[1].Rows.Count; tbl1++)
                {
                    sbPrint.Append("<tr>");
                    sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt;'>" + (tbl1 + 1).ToString().Trim() + "</td>");
                    sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + ds.Tables[1].Rows[tbl1]["Column1"].ToString().Trim() + "</td>");
                    sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + ds.Tables[1].Rows[tbl1]["Column3"].ToString().Trim() + "</td>");
                    sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 15pt'>" + ds.Tables[1].Rows[tbl1]["Column2"].ToString().Trim() + "</td>");
                    sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + ds.Tables[1].Rows[tbl1]["Column4"].ToString().Trim() + "</td>");
                    sbPrint.Append("</tr>");
                }
                sbPrint.Append("</table>");
                //  -------end of Line of ACtivity block 
                // Fixed Capital Investment Block
                sbPrint.Append("<table  align='left' style='width: 100%;' border='0' cellpadding='0px' cellspacing='0px'>");
                sbPrint.Append("<tr ><td><table cellpadding='0px'  cellspacing='0px' style='width: 100%;'><td style='height: 10px; width: 0px;' class='addressing' valign='top' align='left'> </td><td style='height: 15px; width: 700px;' class='addressing' valign='top' align='left'><b>Fixed Capital Investment (In Rupees)</b></td>&nbsp;<td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'> </td>&nbsp;<td style='height: 15px;width: 200px;' class='addressing' valign='top' align='right'> </td></tr>");
                sbPrint.Append("</table></td></tr></table>");
                sbPrint.Append("<table cellpadding='0px' cellspacing='0px' border='2px' style='width: 80%;' >");
                sbPrint.Append("<tr><td style='height: 15px;text-align: left; font-size: 12pt; ' class='addressing' valign='top'></td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'>Details of Fixed Assets</td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'><b>As per Approved<br/> project cost</b></td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'><b>As per GM Recommendation</b></td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'><b>Computed as per Guidelines</b></td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'><b>Reasons for variation between GM Recommended value  and computed value</b></td></tr>");
                sbPrint.Append("<tr><td style='height: 15px;text-align: left; font-size: 12pt; '>a.</td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'>Land-Purchased</td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'>" + ds.Tables[0].Rows[0]["txtLandcostCompc"].ToString() + "</td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'>" + ds.Tables[0].Rows[0]["TextBox56"].ToString() + "</td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'></td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'></td></tr>");
                sbPrint.Append("<tr><td style='height: 15px;text-align: left; font-size: 12pt; '>b.</td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'>Building-Constructed</td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'>" + ds.Tables[0].Rows[0]["txtBuilding2"].ToString() + "</td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'>" + ds.Tables[0].Rows[0]["TextBox57"].ToString() + "</td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'></td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'></td></tr>");
                sbPrint.Append("<tr><td style='height: 15px;text-align: left; font-size: 12pt; '>c.</td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'>Plant & M/C</td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'>" + ds.Tables[0].Rows[0]["TextBox30"].ToString() + "</td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'>" + ds.Tables[0].Rows[0]["TextBox58"].ToString() + "</td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'>" + ds.Tables[0].Rows[0]["TextBox58"].ToString() + "</td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'></td></tr>");
                sbPrint.Append("<tr><td style='height: 15px;text-align: left; font-size: 12pt; '>d.</td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'>Tech.Knows -how feasibility study & turn key charges</td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'>" + ds.Tables[0].Rows[0]["TextBox32"].ToString() + "</td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'></td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'></td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'></td></tr>");
                sbPrint.Append("<tr><td style='height: 15px;text-align: left; font-size: 12pt; '>e.</td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'>Vehicles</td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'>" + ds.Tables[0].Rows[0]["txtErec2"].ToString() + "</td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'></td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'></td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'></td></tr>");
                sbPrint.Append("<tr><td style='height: 15px;text-align: left; font-size: 12pt; '>f.</td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'>Other eligible</td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'>" + ds.Tables[0].Rows[0]["txtTFS2"].ToString() + "</td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'></td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'></td>" +
                    "<td style='height: 15px;text-align: left; font-size: 12pt'></td></tr>");
                //sbPrint.Append("<tr><td style='height:10px;text-align: left; font-size: 12pt; '></td><td style='height: 15px;text-align: left; font-size: 12pt'><b>Total</b></td><td style='height: 15px;text-align: left; font-size: 12pt'></td><td style='height: 15px;text-align: right; font-size: 12pt'></td><td style='height: 15px;text-align: left; font-size: 15pt'></td><td style='height: 15px;text-align: left; font-size: 12pt'></td></tr>");
                sbPrint.Append("</table>");
                // end of  Fixed Capital Investment Block

                // Eligible Incentives block
                sbPrint.Append("<table  align='left' style='width: 650px;' border='0' cellpadding='0px' cellspacing='0px'>");
                sbPrint.Append("<tr ><td><table cellpadding='0px' cellspacing='0px' style='width: 80%;'><td style='height: 10px; width: 0px;' class='addressing' valign='top' align='left'> </td><td style='width: 700px;' class='addressing' valign='top' align='left'><u><b>Eligible Incentives</b></td>&nbsp;<td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'> </td>&nbsp;<td style='height: 15px;width: 500px;' class='addressing' valign='top' align='left'> </td></tr>");
                sbPrint.Append("</table></td></tr></table>");
                sbPrint.Append("<table cellpadding='0px' border='2px' cellspacing='0px' style='width: 80%;' align='left'>");
                sbPrint.Append("<tr align='center'><th class='heading' style='font-size: 12pt;'><b>Sl.No</b></th><th class='heading' style='font-size: 12pt'><b>Claim Period</b></th><th class='heading' style='font-size: 12pt'><b>No of Loans Applied for this Claim</b></th></tr>");
                if (dsgrid.Tables[3].Rows.Count > 0)
                {
                    for (int tbl1 = 0; tbl1 < dsgrid.Tables[3].Rows.Count; tbl1++)
                    {
                        sbPrint.Append("<tr>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt;'>" + (tbl1 + 1).ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[3].Rows[tbl1]["ClaimPeriodName"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[3].Rows[tbl1]["LoanCount"].ToString().Trim() + "</td>");
                        sbPrint.Append("</tr>");
                    }
                }
                sbPrint.Append("</table>");
                //  -------end of Eligible Incentives block

                // Claim Details block
                if (dsgrid.Tables[4].Rows.Count > 0)
                {
                    for (int tbl1 = 0; tbl1 < dsgrid.Tables[4].Rows.Count; tbl1++)
                    {
                        if (tbl1 > 0)
                        {
                            sbPrint.Append("<table align='left' style='width: 1200px;' border='0px' cellpadding='0px' cellspacing='0px'><tr><td>-------------------------------------------------------------------------------------------------------------------------------------------------------</td></tr></table>");
                        }
                        sbPrint.Append("<table  align='left' style='width: 650px;' border='0px' cellpadding='0px' cellspacing='0px'>");
                        sbPrint.Append("<tr ><td><table cellpadding='0px' cellspacing='0px' style='width: 100%;'><td style='height: 10px; width: 0px;' class='addressing' valign='top' align='left'> </td><td style='width: 700px;' class='addressing' valign='top' align='left'><u><b>Claim Details</b></td>&nbsp;<td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'> </td>&nbsp;<td style='height: 15px;width: 500px;' class='addressing' valign='top' align='left'> </td></tr>");
                        sbPrint.Append("</table></td></tr></table>");
                        sbPrint.Append("<table cellpadding='0px' border='0px' cellspacing='0px' style='width: 90%;' align='left'>");

                        sbPrint.Append("<tr>");
                        sbPrint.Append("<td>Claim Period:</td><td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["ClaimPeriodName"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td>Loan Number</td><td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["LoanNumber"].ToString().Trim() + "</td>");
                        sbPrint.Append("</tr>");

                        sbPrint.Append("<tr>");
                        sbPrint.Append("<td>Date of Commencement of activity:</td><td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["dcpdate"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td>Loan installment start Date</td><td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["loaninstallmentstartdate"].ToString().Trim() + "</td>");
                        sbPrint.Append("</tr>");

                        sbPrint.Append("<tr>");
                        sbPrint.Append("<td>otal Term Loan Availed(In Rs.):</td><td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["tottermloanavil"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td>Period of installment</td><td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["Periodofinstallmentname"].ToString().Trim() + "</td>");
                        sbPrint.Append("</tr>");

                        sbPrint.Append("<tr>");
                        sbPrint.Append("<td>No of installments</td><td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["Noofinstallmentforloan"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td>Installment amount</td><td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["Installmentamountforloan"].ToString().Trim() + "</td>");
                        sbPrint.Append("</tr>");

                        sbPrint.Append("<tr>");
                        sbPrint.Append("<td>No of installments completed:</td><td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["NoofinstallmentcompletedfortheloanFY"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td>PrincipalAmount become DUE before this HALFYEAR</td><td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["principalamountdueforhalfyrFY"].ToString().Trim() + "</td>");
                        sbPrint.Append("</tr>");

                        sbPrint.Append("<tr><td colspan='4' >");
                        sbPrint.Append("<table cellpadding='0px' border='1px' cellspacing='0px' style='width: 100%;' align='left'><tr>");

                        sbPrint.Append("<th>Sl.No.</th><th style='height: 15px;text-align: left; font-size: 12pt'>Period of Claim</th>");
                        sbPrint.Append("<th>Principal amount due</th><th style='height: 15px;text-align: left; font-size: 12pt'>No of Installment</th>");
                        sbPrint.Append("<th>Rate of Interest</th><th style='height: 15px;text-align: left; font-size: 12pt'>Interest due</th>");
                        sbPrint.Append("<th>Unit Holder Contribution</th><th style='height: 15px;text-align: left; font-size: 12pt'>Eligible Rate of interest</th>");
                        sbPrint.Append("<th style='height: 15px;text-align: left; font-size: 12pt'>Eligible Interest Amount</th></tr>");


                        sbPrint.Append("<tr>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt;'>1</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["PeriodofClaimMonth1Name"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["PrincipalamountdueMonth1"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["NoofInstallmentMonth1"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["rateofinterestMonth1"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["interestamountMonth1"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["unitholdercontMonth1"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["eligiblerateofintersetMonth1"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["eligibleinterestamountMonth1"].ToString().Trim() + "</td>");
                        sbPrint.Append("</tr>");

                        sbPrint.Append("<tr>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt;'>2</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["PeriodofClaimMonth2Name"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["PrincipalamountdueMonth2"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["NoofInstallmentMonth2"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["rateofinterestMonth2"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["interestamountMonth2"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["unitholdercontMonth2"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["eligiblerateofintersetMonth2"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["eligibleinterestamountMonth2"].ToString().Trim() + "</td>");
                        sbPrint.Append("</tr>");

                        sbPrint.Append("<tr>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt;'>3</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["PeriodofClaimMonth3Name"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["PrincipalamountdueMonth3"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["NoofInstallmentMonth3"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["rateofinterestMonth3"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["interestamountMonth3"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["unitholdercontMonth3"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["eligiblerateofintersetMonth3"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["eligibleinterestamountMonth3"].ToString().Trim() + "</td>");
                        sbPrint.Append("</tr>");

                        sbPrint.Append("<tr>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt;'>4</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["PeriodofClaimMonth4Name"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["PrincipalamountdueMonth4"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["NoofInstallmentMonth4"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["rateofinterestMonth4"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["interestamountMonth4"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["unitholdercontMonth4"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["eligiblerateofintersetMonth4"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["eligibleinterestamountMonth4"].ToString().Trim() + "</td>");
                        sbPrint.Append("</tr>");

                        sbPrint.Append("<tr>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt;'>5</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["PeriodofClaimMonth5Name"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["PrincipalamountdueMonth5"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["NoofInstallmentMonth5"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["rateofinterestMonth5"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["interestamountMonth5"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["unitholdercontMonth5"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["eligiblerateofintersetMonth5"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["eligibleinterestamountMonth5"].ToString().Trim() + "</td>");
                        sbPrint.Append("</tr>");

                        sbPrint.Append("<tr>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt;'>6</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["PeriodofClaimMonth6Name"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["PrincipalamountdueMonth6"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["NoofInstallmentMonth6"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["rateofinterestMonth6"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["interestamountMonth6"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["unitholdercontMonth6"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["eligiblerateofintersetMonth6"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["eligibleinterestamountMonth6"].ToString().Trim() + "</td>");
                        sbPrint.Append("</tr>");

                        sbPrint.Append("<tr>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt;'></td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'></td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'></td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'></td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>Total Interest Amount:</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["totmonthsinterestamountMonth"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'></td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>Total Eligible Interest Amount:</td>");
                        sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["totmonthseligibleinterestamount"].ToString().Trim() + "</td>");
                        sbPrint.Append("</tr>");

                        sbPrint.Append("</table>");
                        sbPrint.Append("<td></tr>");

                        sbPrint.Append("<tr>");
                        sbPrint.Append("<td>Eligible period in months</td><td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["eligibleperiodinmonths"].ToString().Trim() + "</td>");
                        sbPrint.Append("</tr>");

                        sbPrint.Append("<tr>");
                        sbPrint.Append("<td>Insert amount to be paid as per calculations</td><td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["CPL_interestamountpaidaspercal"].ToString().Trim() + "</td>");
                        sbPrint.Append("</tr>");

                        sbPrint.Append("<tr>");
                        sbPrint.Append("<td>Actual interest amount paid</td><td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["CPL_actualinterestamountpaid"].ToString().Trim() + "</td>");
                        sbPrint.Append("</tr>");

                        sbPrint.Append("<tr>");
                        sbPrint.Append("<td>Rate of Interest</td><td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["Rateofinterestforloan"].ToString().Trim() + "</td>");
                        sbPrint.Append("<td>E Eligible rate of reimbursement</td><td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["Eligibleratereimbursementforlaon"].ToString().Trim() + "</td>");
                        sbPrint.Append("</tr>");

                        sbPrint.Append("<tr>");
                        sbPrint.Append("<td>Considered Amount for Interest</td><td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["CPL_Conamountforcalintreimberest"].ToString().Trim() + "</td>");
                        sbPrint.Append("</tr>");

                        sbPrint.Append("<tr>");
                        sbPrint.Append("<td>Interst reimbursement calculated</td><td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["CPL_interestreimbersementcal"].ToString().Trim() + "</td>");
                        sbPrint.Append("</tr>");

                        sbPrint.Append("<tr>");
                        sbPrint.Append("<td>Eligible Type</td><td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["CPL_ELIGIBLETYPEName"].ToString().Trim() + "</td>");
                        sbPrint.Append("</tr>");

                        sbPrint.Append("<tr>");
                        sbPrint.Append("<td>Interst reimbursement(After selecting the eglible Type)</td><td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["CPL_interestreimbersementcal_finaleligibletype"].ToString().Trim() + "</td>");
                        sbPrint.Append("</tr>");

                        sbPrint.Append("<tr>");
                        sbPrint.Append("<td>GM recommended amount</td><td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["CPL_gmrecommendedamount"].ToString().Trim() + "</td>");
                        sbPrint.Append("</tr>");

                        sbPrint.Append("<tr>");
                        sbPrint.Append("<td>Eligible amount</td><td style='height: 15px;text-align: left; font-size: 12pt'>" + dsgrid.Tables[4].Rows[tbl1]["CPL_FINALELIGIBLEAMOUNT"].ToString().Trim() + "</td>");
                        sbPrint.Append("</tr>");
                    }
                }
                sbPrint.Append("</table>");
                //  -------end of Eligible Incentives block

                //sbPrint.Append("<table  align='left' style='width:100%;' border='0' cellpadding='0px' cellspacing='0px'>");
                //sbPrint.Append("<tr ><td style='height: 10px; width: 0px;' class='addressing' valign='top' align='left'><u><b>Eligible Incentives</b></u></b></td>" +
                //    "<td style='height: 10px; width: 0px;' class='addressing' valign='top' align='left'> </td>" +
                //    "<td style='height: 10px; width: 00px;' class='addressing' valign='top' align='left'></td>" +
                //    "<td style='height: 10px;width: 0px;' class='addressing' valign='top' align='left'> </td></tr>");
                //sbPrint.Append("</td></tr>");
                //sbPrint.Append("</tr></table>");
                sbPrint.Append("<table  align='left' style='width: 100%;' border='0' cellpadding='0px' cellspacing='0px'>");
                //sbPrint.Append("<tr ><td style='height: 10px; ' class='addressing' valign='top' align='left'><b>Conditions to be fullfilled by the unit </b></td>" +
                //    "<td style='height: 10px; ' class='addressing' valign='top' align='left'></b></td>" +
                //    "&nbsp;<td style='height: 10px; width: 2px;' class='addressing' valign='top' align='left'> </td>&nbsp;" +
                //    "<td style='height: 10px;' class='addressing' valign='top' align='left'> </td></tr>");
                //sbPrint.Append("</table>");

                //sbPrint.Append("<table  align='left' style='width: 100%;' border='0' cellpadding='0px' cellspacing='0px'>");

                //sbPrint.Append("<tr ><td  style='height: 10px;width: 100%; ' class='addressing' valign='top' align='left'><b>REMARKS: <b/>" +
                //    "The GM, DIC - Sircilla District has recommended the claim application along with all required " +
                //    "documents / certificates as per the Guidelines.The unit has submitted the claim application within " +
                //    "the stipulated period in the office of the GM, DIC, as such there is no delay in submitting the " +
                //    "claim application and the line of activity is eligible of Investment subsidy under" +
                //    ds.Tables[0].Rows[0]["Scheme"].ToString() + "-" + ds.Tables[0].Rows[0]["CASTENAME"].ToString() +
                //    "</td></tr>");
                //sbPrint.Append("<tr><td colspan='4' style='height: 15px;'></td></tr></table>"); align='center'
                sbPrint.Append("</table></td></tr></table>");
                sbPrint.Append("<tr><td>");
                sbPrint.Append("</ table >");
                sbPrint.Append("<div style='page-break-after: always;'></div>");

            }

            divDynPrint.InnerHtml = sbPrint.ToString();

            #endregion


        }
        //}

    }
    public DataSet DB_apprasialnote2pallavaddi(string IncentiveId, string CLAIMPERIOD_Grid)
    {
        try
        {
            SqlConnection osqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
            osqlConnection.Open();
            SqlDataAdapter da;
            da = new SqlDataAdapter("pv_apprasialnote2pallavaddi", osqlConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            if (IncentiveId.Trim() == "" || IncentiveId.Trim() == null)
                da.SelectCommand.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = IncentiveId.ToString();
            if (CLAIMPERIOD_Grid.Trim() == "" || CLAIMPERIOD_Grid.Trim() == null)
                da.SelectCommand.Parameters.Add("@CLAIMPERIOD_Grid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@CLAIMPERIOD_Grid", SqlDbType.VarChar).Value = CLAIMPERIOD_Grid.ToString();


            da.Fill(ds);
            return ds;



        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
        }
    }
}