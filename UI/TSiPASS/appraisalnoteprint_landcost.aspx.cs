using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Data.SqlClient;

public partial class UI_TSiPASS_appraisalnoteprint_landcost : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    ArrayList arListApplNo = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        arListApplNo = (ArrayList)Session["applicationNo"];
        getDetails();   
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
            da = new SqlDataAdapter("USP_GETDETAILSFORSECTION_Appraisal_IS_New1_TEST", osqlConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.SelectCommand.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = Item;
            da.SelectCommand.Parameters.Add("@mstincentiveid", SqlDbType.VarChar).Value = "17";
            da.Fill(ds);

            getLOAData(ds);

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
                    //tideaTr.Visible = true;
                }


                #region DYNAMIC PRINT

                sbPrint.Append("<center>");
                sbPrint.Append("<img src = 'telanganalogo.png' width = '75px' height = '75px' />");
                sbPrint.Append("</center>");
                sbPrint.Append("</div> ");

                if (ds.Tables[0].Rows[0]["lblTideaTpride"].ToString() == "Y")
                {
                    sbPrint.Append("<table  align='center' style='width: 650px;' border='0' cellpadding='0px' cellspacing='0px'>height: 15px");
                    sbPrint.Append("<tr><td class='heading' colspan='4' style='text-align: center; font-size: 10pt'><b>Telangana State Program for Rapid Incubation of Dalit Entrepreneurs - G.O M.S. NO 29, Industries &<br/>Commerce (IP & INF) Department,&nbsp;<br /></td></tr>");

                }
                else if (ds.Tables[0].Rows[0]["lblTideaTpride"].ToString() == "N")
                {
                    sbPrint.Append("<table  align='center' style='width: 650px;' border='0' cellpadding='0px' cellspacing='0px'>");
                    sbPrint.Append("<tr><td class='heading' colspan='4' style='text-align: center; font-size: 10pt'><b>T-PRIDE -" + ds.Tables[0].Rows[0]["CASTENAME"].ToString() + "- G.O M.S. NO 29, Industries &amp; Commerce (IP &amp; INF) Department,<br /> Dated : 29/11/2014</td></tr>");

                }

                //sbPrint.Append("<table  align='center' style='width: 650px;' border='0' cellpadding='0px' cellspacing='0px'>");
                //sbPrint.Append("<tr><td class='heading' colspan='4' style='text-align: center; font-size: 10pt'><b>Telangana State Program for Rapid Incubation of Dalit Entrepreneurs - G.O M.S. NO 29, Industries &<br/>Commerce (IP & INF) Department,&nbsp;<br /></td></tr>");
                sbPrint.Append("<tr><td class='heading' colspan='4' style='text-align: center'>Dated : 29/11/2014</td></tr>");
                //


                sbPrint.Append("<tr><td class='heading' colspan='4' style='text-align: center'><u>Appraisal Note</u></td></tr>");
                sbPrint.Append("<tr><td class='heading' colspan='4' style='text-align: center'>Sanction of Investment Subsidy</td></tr>");

                sbPrint.Append("<tr><td class='heading' colspan='4' style='text-align: center'></td></tr>");
                sbPrint.Append("<tr ><td><table cellpadding='0px' cellspacing='0px' style='width: 100%;'><td style='height: 10px; width: 0px;' class='addressing' valign='top' align='left'> </td><td style='height: 15px; width: 700px;' class='addressing' valign='top' align='left'>&nbsp;Application no</td>&nbsp;<td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'> </td>&nbsp;<td style='height: 15px;width: 500px;' class='addressing' valign='top' align='left'> " + ds.Tables[0].Rows[0]["lblApplicationno"].ToString() + " &nbsp;</td></tr>");
                sbPrint.Append("<tr><td style='height: 15px; width: 0px;' class='addressing' valign='top' align='left'>1</td><td style='height: 15px; width: 700px;' class='addressing' valign='top' align='left'> Name of Industrial Concern</td><td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'> </td>&nbsp;<td style='height: 15px;width: 1000px;' class='addressing'  valign='top' align='left'>" + "<b>" + ds.Tables[0].Rows[0]["txtunitnames"].ToString() + "</b>" + "</td></tr>");
                sbPrint.Append("<tr><td style='height: 15px; width: 0px;' class='addressing' valign='top' align='left'>2</td><td style='height: 15px;' width: 700px;' class='addressing' valign='top' align='left'> Location of the Industrial concern</td><td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'></td><td style='height: 15px;' class='addressing' valign='top' align='left'>" + ds.Tables[0].Rows[0]["txtLocofUnit"].ToString() + "</td></tr>");
                sbPrint.Append("<tr><td style='height: 15px; width: 0px;' class='addressing' valign='top' align='left'>3</td><td style='height: 15px;' width: 700px;' class='addressing' valign='top' align='left'> Name of Promoter</td><td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'></td><td style='height: 15px;' class='addressing' valign='top' align='left'> " + ds.Tables[0].Rows[0]["ApplciantName"].ToString() + "</td></tr>");
                sbPrint.Append("<tr><td style='height: 15px; width: 0px;' class='addressing' valign='top' align='left'>4</td><td style='height: 15px;' width: 700px;' class='addressing' valign='top' align='left'> Constitution of the Industrial Concern &nbsp;</td><td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'></td><td style='height: 15px;' class='addressing' valign='top' align='left'> " + ds.Tables[0].Rows[0]["ddlOrddlorgtypes"].ToString() + "</td></tr>");
                sbPrint.Append("<tr><td style='height: 15px; width: 0px;' class='addressing' valign='top' align='left'>5</td><td style='height: 15px;' width: 700px;' class='addressing' valign='top' align='left'> Social Status<br />&nbsp;(Original Certificate to be enclosed)</td><td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'></td><td style='height: 15px;' class='addressing' valign='top' align='left'>" + ds.Tables[0].Rows[0]["CASTE"].ToString() + "</td></tr>");
                sbPrint.Append("<tr><td style='height: 15px; width: 0px;' class='addressing' valign='top' align='left'>6</td><td style='height: 15px;' width: 700px;' class='addressing' valign='top' align='left'> Share of SC/ST/Women Enterpreneur</td><td style='height: 15px;' class='addressing' valign='top' align='left'></td><td style='height: 15px;' class='addressing' valign='top' align='left'>" + ds.Tables[0].Rows[0]["ApplciantName"].ToString() + "</td></tr>");
                sbPrint.Append("<tr><td style='height: 15px; width: 0px;' class='addressing' valign='top' align='left'>7</td><td style='height: 15px;' width: 700px;' class='addressing' valign='top' align='left'> PMT SSI Registration. No. & Date&nbsp;<br />&nbsp;held a conductor's licence issued by</td><td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'></td><td style='height: 15px;' class='addressing' valign='top' align='left'>" + ds.Tables[0].Rows[0]["txtPersonIndustry"].ToString() + "</td></tr>");
                sbPrint.Append("<tr><td style='height: 15px; width: 0px;' class='addressing' valign='top' align='left'>8</td><td style='height: 15px;' width: 700px;' class='addressing' valign='top' align='left'> New/Expansion/Diversification Unit</td><td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'></td><td style='height: 15px;' class='addressing' valign='top' align='left'>" + ds.Tables[0].Rows[0]["IdsustryStatus"].ToString() + " </td></tr>");
                sbPrint.Append("<tr><td style='height: 15px; width: 0px;' class='addressing' valign='top' align='left'>9</td><td style='height: 15px;' width: 700px;' class='addressing' valign='top' align='left'> Date of commencement of production<br />&nbsp;</td><td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'></td><td style='height: 15px;' class='addressing' valign='top' align='left'>" + ds.Tables[0].Rows[0]["txtDCP_unit"].ToString() + "</td></tr>");
                sbPrint.Append("<tr><td style='height: 15px; width: 0px;' class='addressing' valign='top' align='left'>10</td><td style='height: 15px;' width: 700px;' class='addressing' valign='top' align='left'> Date of filing of claim application in DIC&nbsp&nbsp;</td><td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'></td><td style='height: 15px;' class='addressing' valign='top' align='left'>" + ds.Tables[0].Rows[0]["txtDateOfapplnFile"].ToString() + "</td></tr>");
                sbPrint.Append("<tr><td style='height: 15px; width: 0px;' class='addressing' valign='top' align='left'>11</td><td style='height: 15px;' width: 700px;' class='addressing' valign='top' align='left'> Name of Financing Institution in case of Aided Units&nbsp;</td><td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'></td><td style='height: 15px;' class='addressing' valign='top' align='left'>" + ds.Tables[0].Rows[0]["txtNameofFinIns"].ToString() + "</td></tr>");

                //sbPrint.Append("<tr><td colspan='4' style='height: 15px;'></td></tr></table>"); align='center'
                sbPrint.Append("<tr><td></td><td></td></tr></table></td></tr></table>");


                //Venkat

                sbPrint.Append("<table  align='center' style='width: 650px;' border='0' cellpadding='0px' cellspacing='0px'>");
                sbPrint.Append("<tr ><td><table cellpadding='0px' cellspacing='0px' style='width: 100%;'><td style='height: 10px; width: 0px;' class='addressing' valign='top' align='left'> </td><td style='height: 15px; width: 700px;' class='addressing' valign='top' align='left'><b>Fixed Capital Investment</b></td>&nbsp;<td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'> </td>&nbsp;<td style='height: 15px;width: 200px;' class='addressing' valign='top' align='right'><b>(In Rupees)</b> </td></tr>");
                sbPrint.Append("</table></td></tr></table>");

                sbPrint.Append("<table cellpadding='0px' cellspacing='0px' style='width: 80%;' >");

                sbPrint.Append("<tr><td style='height: 15px;text-align: left; font-size: 12pt; width:350px' class='addressing' valign='top'></td><td style='height: 15px;text-align: left; font-size: 12pt'>Details of Fixed Assets</td><td style='height: 15px;text-align: left; font-size: 12pt'><b>As per Approved<br/> project cost</b></td><td style='height: 15px;text-align: left; font-size: 12pt'><b>As per GM Recommendation</b></td><td style='height: 15px;text-align: left; font-size: 12pt'><b>Computed as per Guidelines</b></td><td style='height: 15px;text-align: left; font-size: 12pt'><b>Reasons for variation between GM Recommended value  and computed value</b></td></tr>");

                sbPrint.Append("<tr><td style='height: 15px;text-align: left; font-size: 12pt; width:0px'></td><td style='height: 15px;text-align: left; font-size: 12pt'>a. Land-Purchased</td><td style='height: 15px;text-align: left; font-size: 12pt'>" + ds.Tables[0].Rows[0]["txtLandcostCompc"].ToString() + "</td><td style='height: 15px;text-align: right; font-size: 12pt'>" + ds.Tables[0].Rows[0]["TextBox56"].ToString() + "</td><td style='height: 15px;text-align: left; font-size: 15pt'></td><td style='height: 15px;text-align: left; font-size: 12pt'></td></tr>");
                sbPrint.Append("<tr><td style='height: 15px;text-align: left; font-size: 12pt; width:0px'></td><td style='height: 15px;text-align: left; font-size: 12pt'>b. Building-Constructed</td><td style='height: 15px;text-align: left; font-size: 12pt'>" + ds.Tables[0].Rows[0]["txtBuilding2"].ToString() + "</td><td style='height: 15px;text-align: right; font-size: 12pt'>" + ds.Tables[0].Rows[0]["TextBox57"].ToString() + "</td><td style='height: 15px;text-align: left; font-size: 15pt'></td><td style='height: 15px;text-align: left; font-size: 12pt'></td></tr>");
                sbPrint.Append("<tr><td style='height: 15px;text-align: left; font-size: 12pt; width:0px'></td><td style='height: 15px;text-align: left; font-size: 12pt'>c. Plant & M/C</td><td style='height: 15px;text-align: left; font-size: 12pt'>" + ds.Tables[0].Rows[0]["TextBox30"].ToString() + "</td><td style='height: 15px;text-align: right; font-size: 12pt'>" + ds.Tables[0].Rows[0]["TextBox58"].ToString() + "</td><td style='height: 15px;text-align: left; font-size: 15pt'>" + ds.Tables[0].Rows[0]["TextBox58"].ToString() + "</td><td style='height: 15px;text-align: left; font-size: 12pt'></td></tr>");
                sbPrint.Append("<tr><td style='height: 15px;text-align: left; font-size: 12pt; width:0px'></td><td style='height: 15px;text-align: left; font-size: 12pt'>d.Tech.Knows -how feasibility study & turn key charges</td><td style='height: 15px;text-align: left; font-size: 12pt'>" + ds.Tables[0].Rows[0]["TextBox32"].ToString() + "</td><td style='height: 15px;text-align: right; font-size: 15pt'></td><td style='height: 15px;text-align: left; font-size: 15pt'></td><td style='height: 15px;text-align: left; font-size: 15pt'></td></tr>");
                sbPrint.Append("<tr><td style='height: 15px;text-align: left; font-size: 12pt; width:0px'></td><td style='height: 15px;text-align: left; font-size: 12pt'>e.Vehicles</td><td style='height: 15px;text-align: left; font-size: 12pt'>" + ds.Tables[0].Rows[0]["txtErec2"].ToString() + "</td><td style='height: 15px;text-align: right; font-size: 12pt'></td><td style='height: 15px;text-align: left; font-size: 15pt'></td><td style='height: 15px;text-align: left; font-size: 12pt'></td></tr>");
                sbPrint.Append("<tr><td style='height: 15px;text-align: left; font-size: 12pt; width:0px'></td><td style='height: 15px;text-align: left; font-size: 12pt'>f.Other eligible</td><td style='height: 15px;text-align: left; font-size: 12pt'>" + ds.Tables[0].Rows[0]["txtTFS2"].ToString() + "</td><td style='height: 15px;text-align: right; font-size: 12pt'></td><td style='height: 15px;text-align: left; font-size: 15pt'></td><td style='height: 15px;text-align: left; font-size: 12pt'></td></tr>");
                sbPrint.Append("<tr><td style='height:10px;text-align: left; font-size: 12pt; width:0px'></td><td style='height: 15px;text-align: left; font-size: 12pt'><b>Total</b></td><td style='height: 15px;text-align: left; font-size: 12pt'></td><td style='height: 15px;text-align: right; font-size: 12pt'></td><td style='height: 15px;text-align: left; font-size: 15pt'></td><td style='height: 15px;text-align: left; font-size: 12pt'></td></tr>");
                sbPrint.Append("</table>");


                sbPrint.Append("<table  align='center' style='width: 650px;' border='0' cellpadding='0px' cellspacing='0px'>");
                sbPrint.Append("<tr ><td><table cellpadding='0px' cellspacing='0px' style='width: 100%;'><td style='height: 10px; width: 0px;' class='addressing' valign='top' align='left'> </td><td style='height: 15px; width: 700px;' class='addressing' valign='top' align='left'><u><b>Line of Activity</b></td>&nbsp;<td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'> </td>&nbsp;<td style='height: 15px;width: 500px;' class='addressing' valign='top' align='left'> </td></tr>");
                sbPrint.Append("</table></td></tr></table>");

                sbPrint.Append("<table cellpadding='0px' border='2px' cellspacing='0px' style='width: 75%;' align='right'>");
                sbPrint.Append("<tr align='center'><th class='heading' style='font-size: 12pt;'>Sl.No</th><th class='heading' style='font-size: 12pt'>Line Of Activity</th><th class='heading' style='font-size: 12pt'>Installed Capacity</th><th class='heading' style='font-size: 12pt'>Unit</th><th class='heading' style='font-size: 12pt'>Value (in Rs.)</th></tr>");


                for (int tbl1 = 0; tbl1 < ds.Tables[1].Rows.Count; tbl1++)
                {
                    sbPrint.Append("<tr>");
                    sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt;'>" + (tbl1 + 1).ToString().Trim() + "</td>");
                    sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + ds.Tables[1].Rows[tbl1]["Column1"].ToString().Trim() + "</td>");
                    sbPrint.Append("<td style='height: 15px;text-align: right; font-size: 12pt'>" + ds.Tables[1].Rows[tbl1]["Column3"].ToString().Trim() + "</td>");
                    sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 15pt'>" + ds.Tables[1].Rows[tbl1]["Column2"].ToString().Trim() + "</td>");
                    sbPrint.Append("<td style='height: 15px;text-align: left; font-size: 12pt'>" + ds.Tables[1].Rows[tbl1]["Column4"].ToString().Trim() + "</td>");
                    sbPrint.Append("</tr>");
                }

                //sbPrint.Append("<tr><td style='height: 15px;text-align: left; font-size: 12pt;width:350px'></td><td style='height: 15px;text-align: left; font-size: 12pt'></td><td style='height: 15px;text-align: right; font-size: 12pt'></td><td style='height: 15px;text-align: left; font-size: 15pt'></td><td style='height: 15px;text-align: left; font-size: 12pt'></td></tr>");
                sbPrint.Append("</table>");
                // sbPrint.Append("<table style='page-break-after: always'></table>");//MALL
                sbPrint.Append("<table  align='center' style='width: 650px;' border='0' cellpadding='0px' cellspacing='0px'>");
                sbPrint.Append("<tr ><td><table cellpadding='0px' cellspacing='0px' style='width: 100%;'><td style='height: 10px; width: 0px;' class='addressing' valign='top' align='left'> </td><td style='height: 10px; width: 700px;' class='addressing' valign='top' align='left'><u><b>12 ELIGIBLE INCENTIVES </b></u></b></td>&nbsp;<td style='height: 10px; width: 2px;' class='addressing' valign='top' align='left'> </td>&nbsp;<td style='height: 10px;width: 500px;' class='addressing' valign='top' align='left'> </td></tr>");
                sbPrint.Append("</table></td></tr></table>");
                sbPrint.Append("<table  align='center' style='width: 650px;' border='0' cellpadding='0px' cellspacing='0px'>");
                sbPrint.Append("<tr ><td><table cellpadding='0px' cellspacing='0px' style='width: 100%;'><td style='height: 10px; width: 0px;' class='addressing' valign='top' align='left'> </td><td style='height: 15px; width: 900px;' class='addressing' valign='top' align='left'>&nbsp; &nbsp; &nbsp; &nbsp; a) Schemetype</td><td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'> </td>&nbsp;<td style='height: 15px;width: 500px;' class='addressing' valign='top' align='left'>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; " + ds.Tables[0].Rows[0]["LANDPURCHASE"].ToString() + " &nbsp;</td></tr>");
                sbPrint.Append("<tr><td style='height: 15px; width: 0px;' class='addressing' valign='top' align='left'></td><td style='height: 15px; width: 700px;' class='addressing' valign='top' align='left'>&nbsp; &nbsp; &nbsp; &nbsp; b) Application Type</td><td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'> </td>&nbsp;<td style='height: 15px;width: 1000px;' class='addressing'  valign='top' align='left'> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;" + ds.Tables[0].Rows[0]["LANDVALUE"].ToString() + "</td></tr>");
                sbPrint.Append("<tr><td style='height: 15px; width: 0px;' class='addressing' valign='top' align='left'></td><td style='height: 15px; width: 700px;' class='addressing' valign='top' align='left'>&nbsp; &nbsp; &nbsp; &nbsp; c) Production </td><td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'> </td>&nbsp;<td style='height: 15px;width: 1000px;' class='addressing'  valign='top' align='left'> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;" + ds.Tables[0].Rows[0]["BuildingPlinth"].ToString() + "</td></tr>");
                sbPrint.Append("<tr><td style='height: 15px; width: 0px;' class='addressing' valign='top' align='left'></td><td style='height: 15px; width: 700px;' class='addressing' valign='top' align='left'>&nbsp; &nbsp; &nbsp; &nbsp; d) Tax Paid(SGST)</td><td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'> </td>&nbsp;<td style='height: 15px;width: 1000px;' class='addressing'  valign='top' align='left'> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;" + ds.Tables[0].Rows[0]["Proportionatearea"].ToString() + "</td></tr>");
                sbPrint.Append("<tr><td style='height: 15px; width: 0px;' class='addressing' valign='top' align='left'></td><td style='height: 15px;' width: 700px;' class='addressing' valign='top' align='left'>&nbsp; &nbsp; &nbsp; &nbsp; e) Base Production</td><td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'></td><td style='height: 15px;' class='addressing' valign='top' align='left'> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;" + ds.Tables[0].Rows[0]["GMValue"].ToString() + "</td></tr>");
                sbPrint.Append("<tr><td style='height: 15px; width: 0px;' class='addressing' valign='top' align='left'></td><td style='height: 15px;' width: 700px;' class='addressing' valign='top' align='left'>&nbsp; &nbsp; &nbsp; &nbsp; f) Eligible Production Qty over and  &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp; above base production</td><td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'></td><td style='height: 15px;' class='addressing' valign='top' align='left'> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;" + ds.Tables[0].Rows[0]["TotalBuildingPlinth_CALCULATED"].ToString() + "</td></tr>");
                sbPrint.Append("<tr><td style='height: 15px; width: 0px;' class='addressing' valign='top' align='left'></td><td style='height: 15px;' width: 700px;' class='addressing' valign='top' align='left'>&nbsp; &nbsp; &nbsp; &nbsp; g) Proportionate SGST value on eligible  &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp; production</td><td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'></td><td style='height: 15px;' class='addressing' valign='top' align='left'> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;" + ds.Tables[0].Rows[0]["FINALELIGIBLELANDCOST"].ToString() + "</td></tr>");
                sbPrint.Append("<tr><td style='height: 15px; width: 0px;' class='addressing' valign='top' align='left'></td><td style='height: 15px;' width: 700px;' class='addressing' valign='top' align='left'>&nbsp; &nbsp; &nbsp; &nbsp; h) Application Type</td><td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'></td><td style='height: 15px;' class='addressing' valign='top' align='left'> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;" + ds.Tables[0].Rows[0]["ELIGIBLETYPE"].ToString() + "</td></tr>");
                sbPrint.Append("<tr><td style='height: 15px; width: 0px;' class='addressing' valign='top' align='left'></td><td style='height: 15px;' width: 700px;' class='addressing' valign='top' align='left'>&nbsp; &nbsp; &nbsp; &nbsp; i) Remarks</td><td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'></td><td style='height: 15px;' class='addressing' valign='top' align='left'> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;" + ds.Tables[0].Rows[0]["Remarks"].ToString() + "</td></tr>");
                
                //sbPrint.Append("<tr><td colspan='4' style='height: 15px;'></td></tr></table>"); align='center'
                sbPrint.Append("</table></td></tr></table>");

                sbPrint.Append("<table  align='center' style='width: 650px;' border='0' cellpadding='0px' cellspacing='0px'>");
                sbPrint.Append("<tr ><td><table cellpadding='0px' cellspacing='0px' style='width: 100%;'><td style='height: 10px; width: 0px;' class='addressing' valign='top' align='left'> </td><td style='height: 10px; width: 900px;' class='addressing' valign='top' align='left'><b>CONDITIONS TO BE FULFILLED BY THE UNIT </b></b></td>&nbsp;<td style='height: 10px; width: 2px;' class='addressing' valign='top' align='left'> </td>&nbsp;<td style='height: 10px;width: 500px;' class='addressing' valign='top' align='left'> </td></tr>");
                sbPrint.Append("</table></td></tr></table>");

                sbPrint.Append("<table  align='center' style='width: 650px;' border='0' cellpadding='0px' cellspacing='0px'>");

                sbPrint.Append("<tr ><td><table cellpadding='0px' cellspacing='0px' style='width: 100%;'><td style='height: 10px; width: 0px;' class='addressing' valign='top' align='left'> </td><td style='height: 15px; width: 900px;' class='addressing' valign='top' align='left'>&nbsp; &nbsp; &nbsp; &nbsp; <b>14.REMARKS<b/></td><td style='height: 15px; width: 2px;' class='addressing' valign='top' align='left'> </td>&nbsp;<td style='height: 15px;width: 100%;' class='addressing' valign='top' align='left'>The GM,DIC -Sircilla District has recommended the claim application along with all required documents / certificates as per the Guidelines.The unit has submitted the claim application within the stipulated period in the office of the GM, DIC, as such there is no delay in submitting the claim application and the line of activity is eligible of Investment subsidy under " + "<b>" + ds.Tables[0].Rows[0]["Scheme"].ToString() + "-" + ds.Tables[0].Rows[0]["CASTENAME"].ToString() + "</b>" + " </td></tr>");
                //sbPrint.Append("<tr><td colspan='4' style='height: 15px;'></td></tr></table>"); align='center'
                sbPrint.Append("</table></td></tr></table>");




            }

            divDynPrint.InnerHtml = sbPrint.ToString();

            #endregion


        }
        //}
    }
}