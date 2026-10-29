using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Text;

using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Data.SqlClient;

public partial class UI_TSIPASS_comRepDrill_dist : System.Web.UI.Page
{
   decimal Nounits;
    string querystrg;
    decimal Nounits_deptTOTAL = 0;
    decimal NounitsAdilabad_1 = 0; decimal NounitsAsifabad_11 = 0; decimal NounitsBhadradriKothagudem_17 = 0;
    decimal NounitsBhupalpally_12 = 0; decimal NounitsGadwal_13 = 0; decimal NounitsHyderabad_5 = 0; decimal NounitsJagtial_14 = 0;
    decimal NounitsJangaon_15=0;decimal NounitsKamareddy_16 = 0; decimal NounitsKarimnagar_3 = 0; decimal Khammam_10 = 0;
    decimal NounitsMahabubabad_18 = 0;decimal NounitsMahbubnagar_7 = 0; decimal NounitsMancherial_19 = 0; decimal NounitsMedak_4 = 0;
    decimal Medchal_20 = 0; decimal NounitsMulugu_32 = 0; decimal NounitsNagarkurnool_21 = 0;decimal NounitsNalgonda_8 = 0;
    decimal Narayanpet_33 = 0;decimal NounitsNirmal_22 = 0;decimal NounitsNizamabad_2 = 0; decimal NounitsPeddapalli_23 = 0;
    decimal Rangareddy_6=0;decimal NounitsSangareddy_24 = 0;decimal NounitsSiddipet_25 = 0;decimal NounitsSircilla_26 = 0;
    decimal Suryapet_27 = 0;decimal NounitsVikarabad_28 = 0;decimal NounitsWanaparthy_29 = 0; decimal NounitsWarangal_Rural_9=0;
    decimal Warangal_Urban_30 = 0;decimal NounitsYadadri_31 = 0;
    string FromdateforDB = "", TodateforDB = "", fromdate = "", todate = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            querystrg = Request.QueryString["CODE"].ToString();
            ViewState["querystrg"] = querystrg.ToString();

            lblheadingtext.Text = querystrg;
            Label1.Text = "Report as on date " + DateTime.Now;

            if (querystrg == "CFE" || querystrg == "CFO")
            {
                trtype.Visible = true;
            }
            else
            {
                trtype.Visible = false;
            }

            if (Request.QueryString["fromdate"] != null && Request.QueryString["fromdate"] != "" && Request.QueryString["todate"] != null && Request.QueryString["todate"] != "")
            {
                //string FromdateforDB = "", TodateforDB = "", fromdate = "", todate = "";

                fromdate = Request.QueryString["fromdate"].ToString().Trim();
                todate = Request.QueryString["todate"].ToString().Trim();



                bindGridData(fromdate, todate, ddltype.SelectedValue);


            }

        }

    }


    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string testing = e.Row.Cells[1].Text.ToString();

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal Nounits1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "pendencyCount"));
            Nounits = Nounits1 + Nounits;

            HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
            //h1.NavigateUrl = "comReportDrill_drilldown.aspx?CODE=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictName")).Trim();
            h1.NavigateUrl = "comReportDrill_drilldown.aspx?Dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictName")).Trim() + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=" + ddltype.SelectedValue;

        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total";

            HyperLink nounitstotal = new HyperLink();
            nounitstotal.ForeColor = System.Drawing.Color.White;
            nounitstotal.NavigateUrl = "comReportDrill_drilldownTotal.aspx?Dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictName")).Trim() + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate;
            nounitstotal.Text = Nounits.ToString();
            e.Row.Cells[2].Text = Nounits.ToString();
            e.Row.Cells[2].Controls.Add(nounitstotal);



        }
    }
    public void bindGridData(string FromdateforDB, string TodateforDB, string type)
    {
        SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
        SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
        DataSet oDataSet = new DataSet();
        osqlConnection.Open();
        oSqlDataAdapter = new SqlDataAdapter("coi_pendencyDistWise", osqlConnection);


        oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        oSqlDataAdapter.SelectCommand.Parameters.Add("@CODE", SqlDbType.VarChar).Value = querystrg.ToString();
        oSqlDataAdapter.SelectCommand.Parameters.Add("@FROMDATE", SqlDbType.VarChar).Value = FromdateforDB.ToString();
        oSqlDataAdapter.SelectCommand.Parameters.Add("@TODATE", SqlDbType.VarChar).Value = TodateforDB.ToString();
        oSqlDataAdapter.SelectCommand.Parameters.Add("@APPLTYPE", SqlDbType.VarChar).Value = ddltype.SelectedValue;
        oSqlDataAdapter.SelectCommand.CommandTimeout = 0;
        oDataSet = new DataSet();
        oSqlDataAdapter.Fill(oDataSet);
        grdDetails.DataSource = oDataSet.Tables[0];
        grdDetails.DataBind();
        trdept.Visible = false;
        div_Print.Visible = true;
    }

    public void bindGridDataNew(string FromdateforDB, string TodateforDB, string type)
    {
        SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
        SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
        DataSet oDataSet = new DataSet();
        osqlConnection.Open();
        oSqlDataAdapter = new SqlDataAdapter("coi_pendencyDistWise_Departmentwise", osqlConnection);


        oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        oSqlDataAdapter.SelectCommand.Parameters.Add("@CODE", SqlDbType.VarChar).Value = querystrg.ToString();
        oSqlDataAdapter.SelectCommand.Parameters.Add("@FROMDATE", SqlDbType.VarChar).Value = FromdateforDB.ToString();
        oSqlDataAdapter.SelectCommand.Parameters.Add("@TODATE", SqlDbType.VarChar).Value = TodateforDB.ToString();
        oSqlDataAdapter.SelectCommand.Parameters.Add("@APPLTYPE", SqlDbType.VarChar).Value = ddltype.SelectedValue;
        oSqlDataAdapter.SelectCommand.CommandTimeout = 0;
        oDataSet = new DataSet();
        oSqlDataAdapter.Fill(oDataSet);
        grddept.DataSource = oDataSet.Tables[0];
        grddept.DataBind();
        trdept.Visible = true;
        div_Print.Visible = false;
    }

    protected void BtnSave2_Click(object sender, EventArgs e)
    {
        ExportGridToExcel();

    }
    private void ExportGridToExcel()
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "Vithal" + DateTime.Now + ".xls";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        grdDetails.GridLines = GridLines.Both;
        grdDetails.HeaderStyle.Font.Bold = true;
        grdDetails.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.End();

    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void PrintPdf()
    {
        try
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    //To Export all pages
                    //trLogo.Visible = true;

                    //this.FillGridDetails();

                    //grdDetails.RenderControl(hw);
                    //StringReader sr = new StringReader(sw.ToString());
                    //Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    //pdfDoc.Open();
                    //htmlparser.Parse(sr);
                    //pdfDoc.Close();
                    grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                    grdDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.FooterStyle.ForeColor = System.Drawing.Color.Black;

                    // grdExport.Columns[1].Visible = false;
                    grdDetails.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();


                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename= R2-1-STATUS-OF-PRESCRUTINY-DEPARTMENT-WISE.pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.Flush();
                    Response.End();
                }
            }
        }
        catch (Exception e)
        {

        }
    }

    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        PrintPdf();
    }
    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            querystrg = Request.QueryString["CODE"].ToString();
            ViewState["querystrg"] = querystrg.ToString();

            lblheadingtext.Text = querystrg;
            Label1.Text = "Report as on date " + DateTime.Now;


            if (Request.QueryString["fromdate"] != null && Request.QueryString["fromdate"] != "" && Request.QueryString["todate"] != null && Request.QueryString["todate"] != "")
            {
                //string FromdateforDB = "", TodateforDB = "", fromdate = "", todate = "";

                fromdate = Request.QueryString["fromdate"].ToString().Trim();
                todate = Request.QueryString["todate"].ToString().Trim();


                if (ddltype.SelectedValue == "District")
                {
                    bindGridData(fromdate, todate, ddltype.SelectedValue);
                }
                else
                {
                    bindGridDataNew(fromdate, todate, ddltype.SelectedValue);
                }


            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void grddept_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        #region
        string testing = e.Row.Cells[1].Text.ToString();
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string DepartmentID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ParticularsID"));
         
            decimal Nounits_deptTOTAL_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TOTAL"));
            Nounits_deptTOTAL = Nounits_deptTOTAL_row + Nounits_deptTOTAL;
            HyperLink hyp_Nounits_deptTOTAL = (HyperLink)e.Row.Cells[3].Controls[0];
            hyp_Nounits_deptTOTAL.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=" + ddltype.SelectedValue;

            decimal NounitsAdilabad_1_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Adilabad-1"));
            NounitsAdilabad_1 = NounitsAdilabad_1_row + NounitsAdilabad_1;
            HyperLink hyp_NounitsAdilabad_1 = (HyperLink)e.Row.Cells[4].Controls[0];
            hyp_NounitsAdilabad_1.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=1" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=";

            decimal NounitsAsifabad_11_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Asifabad-11"));
            NounitsAsifabad_11 = NounitsAsifabad_11_row + NounitsAsifabad_11;
            HyperLink hyp_NounitsAsifabad_11 = (HyperLink)e.Row.Cells[5].Controls[0];
            hyp_NounitsAsifabad_11.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=11" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=";

            decimal NounitsBhadradriKothagudem_17_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Bhadradri Kothagudem-17"));
            NounitsBhadradriKothagudem_17 = NounitsBhadradriKothagudem_17_row + NounitsBhadradriKothagudem_17;
            HyperLink hyp_NounitsBhadradriKothagudem_17 = (HyperLink)e.Row.Cells[6].Controls[0];
            hyp_NounitsBhadradriKothagudem_17.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=17" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=";

            decimal NounitsBhupalpally_12_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Bhupalpally-12"));
            NounitsBhupalpally_12 = NounitsBhupalpally_12_row + NounitsBhupalpally_12;
            HyperLink hyp_NounitsBhupalpally_12 = (HyperLink)e.Row.Cells[7].Controls[0];
            hyp_NounitsBhupalpally_12.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=12" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype="; 

            decimal NounitsGadwal_13_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Gadwal-13"));
            NounitsGadwal_13 = NounitsGadwal_13_row + NounitsGadwal_13;
            HyperLink hyp_NounitsGadwal_13 = (HyperLink)e.Row.Cells[8].Controls[0];
            hyp_NounitsGadwal_13.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=13" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=";

            decimal NounitsHyderabad_5_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Hyderabad-5"));
            NounitsHyderabad_5 = NounitsHyderabad_5_row + NounitsHyderabad_5;
            HyperLink hyp_NounitsHyderabad_5 = (HyperLink)e.Row.Cells[9].Controls[0];
            hyp_NounitsHyderabad_5.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=5" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=";

            decimal NounitsJagtial_14_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jagtial-14"));
            NounitsJagtial_14 = NounitsJagtial_14_row + NounitsJagtial_14;
            HyperLink hyp_NounitsJagtial_14 = (HyperLink)e.Row.Cells[10].Controls[0];
            hyp_NounitsJagtial_14.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=14" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=";

            decimal NounitsJangaon_15_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Jangaon-15"));
            NounitsJangaon_15 = NounitsJangaon_15_row + NounitsJangaon_15;
            HyperLink hyp_NounitsJangaon_15 = (HyperLink)e.Row.Cells[11].Controls[0];
            hyp_NounitsJangaon_15.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=15" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=";

            decimal NounitsKamareddy_16_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Kamareddy-16"));
            NounitsKamareddy_16 = NounitsKamareddy_16_row + NounitsKamareddy_16;
            HyperLink hyp_NounitsKamareddy_16 = (HyperLink)e.Row.Cells[12].Controls[0];
            hyp_NounitsKamareddy_16.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=16" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=";

            decimal NounitsKarimnagar_3_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Karimnagar-3"));
            NounitsKarimnagar_3 = NounitsKarimnagar_3_row + NounitsKarimnagar_3;
            HyperLink hyp_NounitsKarimnagar_3 = (HyperLink)e.Row.Cells[13].Controls[0];
            hyp_NounitsKarimnagar_3.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=3" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=";

            decimal Khammam_10_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Khammam-10"));
            Khammam_10 = Khammam_10_row + Khammam_10;
            HyperLink hyp_Khammam_10 = (HyperLink)e.Row.Cells[14].Controls[0];
            hyp_Khammam_10.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=10" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=";

            decimal NounitsMahabubabad_18_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Mahabubabad-18"));
            NounitsMahabubabad_18 = NounitsMahabubabad_18_row + NounitsMahabubabad_18;
            HyperLink hyp_NounitsMahabubabad_18 = (HyperLink)e.Row.Cells[15].Controls[0];
            hyp_NounitsMahabubabad_18.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=18" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=";

            decimal NounitsMahbubnagar_7_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Mahbubnagar-7"));
            NounitsMahbubnagar_7 = NounitsMahbubnagar_7_row + NounitsMahbubnagar_7;
            HyperLink hyp_NounitsMahbubnagar_7 = (HyperLink)e.Row.Cells[16].Controls[0];
            hyp_NounitsMahbubnagar_7.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=7" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=";

            decimal NounitsMancherial_19_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Mancherial-19"));
            NounitsMancherial_19 = NounitsMancherial_19_row + NounitsMancherial_19;
            HyperLink hyp_NounitsMancherial_19 = (HyperLink)e.Row.Cells[17].Controls[0];
            hyp_NounitsMancherial_19.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=19" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=";

            decimal NounitsMedak_4_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Medak-4"));
            NounitsMedak_4 = NounitsMedak_4_row + NounitsMedak_4;
            HyperLink hyp_NounitsMedak_4 = (HyperLink)e.Row.Cells[18].Controls[0];
            hyp_NounitsMedak_4.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=4" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=";

            decimal Medchal_20_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Medchal-20"));
            Medchal_20 = Medchal_20_row + Medchal_20;
            HyperLink hyp_Medchal_20 = (HyperLink)e.Row.Cells[19].Controls[0];
            hyp_Medchal_20.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=20" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=";

            decimal NounitsMulugu_32_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Mulugu-32"));
            NounitsMulugu_32 = NounitsMulugu_32_row + NounitsMulugu_32;
            HyperLink hyp_NounitsMulugu_32 = (HyperLink)e.Row.Cells[20].Controls[0];
            hyp_NounitsMulugu_32.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=32" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=";

            decimal NounitsNagarkurnool_21_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Nagarkurnool-21"));
            NounitsNagarkurnool_21 = NounitsNagarkurnool_21_row + NounitsNagarkurnool_21;
            HyperLink hyp_NounitsNagarkurnool_21 = (HyperLink)e.Row.Cells[21].Controls[0];
            hyp_NounitsNagarkurnool_21.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=21" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=";
            
            decimal NounitsNalgonda_8_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Nalgonda-8"));
            NounitsNalgonda_8 = NounitsNalgonda_8_row + NounitsNalgonda_8;
            HyperLink hyp_NounitsNalgonda_8 = (HyperLink)e.Row.Cells[22].Controls[0];
            hyp_NounitsNalgonda_8.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=8" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=";

            decimal Narayanpet_33_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Narayanpet-33"));
            Narayanpet_33 = Narayanpet_33_row + Narayanpet_33;
            HyperLink hyp_Narayanpet_33 = (HyperLink)e.Row.Cells[23].Controls[0];
            hyp_Narayanpet_33.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=33" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=";

            decimal NounitsNirmal_22_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Nirmal-22"));
            NounitsNirmal_22 = NounitsNirmal_22_row + NounitsNirmal_22;
            HyperLink hyp_NounitsNirmal_22 = (HyperLink)e.Row.Cells[24].Controls[0];
            hyp_NounitsNirmal_22.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=22" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=";

            decimal NounitsNizamabad_2_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Nizamabad-2"));
            NounitsNizamabad_2 = NounitsNizamabad_2_row + NounitsNizamabad_2;
            HyperLink hyp_NounitsNizamabad_2 = (HyperLink)e.Row.Cells[25].Controls[0];
            hyp_NounitsNizamabad_2.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=2" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=";

            decimal NounitsPeddapalli_23_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Peddapalli-23"));
            NounitsPeddapalli_23 = NounitsPeddapalli_23_row + NounitsPeddapalli_23;
            HyperLink hyp_NounitsPeddapalli_23 = (HyperLink)e.Row.Cells[26].Controls[0];
            hyp_NounitsPeddapalli_23.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=23" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=";

            decimal Rangareddy_6_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Rangareddy-6"));
            Rangareddy_6 = Rangareddy_6_row + Rangareddy_6;
            HyperLink hyp_Rangareddy_6 = (HyperLink)e.Row.Cells[27].Controls[0];
            hyp_Rangareddy_6.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=6" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=";

            decimal NounitsSangareddy_24_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Sangareddy-24"));
            NounitsSangareddy_24 = NounitsSangareddy_24_row + NounitsSangareddy_24;
            HyperLink hyp_NounitsSangareddy_24 = (HyperLink)e.Row.Cells[28].Controls[0];
            hyp_NounitsSangareddy_24.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=24" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=";

            decimal NounitsSiddipet_25_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Siddipet-25"));
            NounitsSiddipet_25 = NounitsSiddipet_25_row + NounitsSiddipet_25;
            HyperLink hyp_NounitsSiddipet_25 = (HyperLink)e.Row.Cells[29].Controls[0];
            hyp_NounitsSiddipet_25.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=25" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=";

            decimal NounitsSircilla_26_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Sircilla-26"));
            NounitsSircilla_26 = NounitsSircilla_26_row + NounitsSircilla_26;
            HyperLink hyp_NounitsSircilla_26 = (HyperLink)e.Row.Cells[30].Controls[0];
            hyp_NounitsSircilla_26.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=26" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=";

            decimal Suryapet_27_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Suryapet-27"));
            Suryapet_27 = Suryapet_27_row + Suryapet_27;
            HyperLink hyp_Suryapet_27 = (HyperLink)e.Row.Cells[31].Controls[0];
            hyp_Suryapet_27.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=27" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=";

            decimal NounitsVikarabad_28_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Vikarabad-28"));
            NounitsVikarabad_28 = NounitsVikarabad_28_row + NounitsVikarabad_28;
            HyperLink hyp_NounitsVikarabad_28 = (HyperLink)e.Row.Cells[32].Controls[0];
            hyp_NounitsVikarabad_28.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=28" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=";

            decimal NounitsWanaparthy_29_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Wanaparthy-29"));
            NounitsWanaparthy_29 = NounitsWanaparthy_29_row + NounitsWanaparthy_29;
            HyperLink hyp_NounitsWanaparthy_29 = (HyperLink)e.Row.Cells[33].Controls[0];
            hyp_NounitsWanaparthy_29.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=29" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=";

            decimal NounitsWarangal_Rural_9_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Warangal - Rural-9"));
            NounitsWarangal_Rural_9 = NounitsWarangal_Rural_9_row + NounitsWarangal_Rural_9;
            HyperLink hyp_NounitsWarangal_Rural_9 = (HyperLink)e.Row.Cells[34].Controls[0];
            hyp_NounitsWarangal_Rural_9.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=9" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=";

            decimal Warangal_Urban_30_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Warangal - Urban-30"));
            Warangal_Urban_30 = Warangal_Urban_30_row + Warangal_Urban_30;
            HyperLink hyp_Warangal_Urban_30 = (HyperLink)e.Row.Cells[35].Controls[0];
            hyp_Warangal_Urban_30.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=30" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=";

            decimal NounitsYadadri_31_row = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Yadadri-31"));
            NounitsYadadri_31 = NounitsYadadri_31_row + NounitsYadadri_31;
            HyperLink hyp_NounitsYadadri_31 = (HyperLink)e.Row.Cells[36].Controls[0];
            hyp_NounitsYadadri_31.NavigateUrl = "comReportDrill_drilldown_Department.aspx?DepartmentID=" + DepartmentID + "&Dist=31" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=";

        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
          
            e.Row.Cells[1].Text = "Total";
            //HyperLink nounitstotal = new HyperLink();
            //nounitstotal.ForeColor = System.Drawing.Color.White;
            //nounitstotal.NavigateUrl = "comReportDrill_drilldownTotal.aspx?Dist=" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate;
            //nounitstotal.Text = Nounits.ToString();
            //e.Row.Cells[2].Text = Nounits.ToString();
            //e.Row.Cells[2].Controls.Add(nounitstotal);

            HyperLink hypnounitstotal_fotdeptTOTAL = new HyperLink();
            hypnounitstotal_fotdeptTOTAL.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fotdeptTOTAL.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate;
            hypnounitstotal_fotdeptTOTAL.Text = Nounits_deptTOTAL.ToString();
            e.Row.Cells[3].Text = Nounits_deptTOTAL.ToString();
            e.Row.Cells[3].Controls.Add(hypnounitstotal_fotdeptTOTAL);
 
            HyperLink hypnounitstotal_fot_Adilabad_1 = new HyperLink();
            hypnounitstotal_fot_Adilabad_1.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fot_Adilabad_1.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=1" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District";
            hypnounitstotal_fot_Adilabad_1.Text = NounitsAdilabad_1.ToString();
            e.Row.Cells[4].Text = NounitsAdilabad_1.ToString();
            e.Row.Cells[4].Controls.Add(hypnounitstotal_fot_Adilabad_1);
            
            HyperLink hypnounitstotal_fot_Asifabad_11 = new HyperLink();
            hypnounitstotal_fot_Asifabad_11.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fot_Asifabad_11.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=11" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District";
            hypnounitstotal_fot_Asifabad_11.Text = NounitsAsifabad_11.ToString();
            e.Row.Cells[5].Text = NounitsAsifabad_11.ToString();
            e.Row.Cells[5].Controls.Add(hypnounitstotal_fot_Asifabad_11);
            
            HyperLink hypnounitstotal_fotBhadradriKothagudem_17 = new HyperLink();
            hypnounitstotal_fotBhadradriKothagudem_17.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fotBhadradriKothagudem_17.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=17" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District";
            hypnounitstotal_fotBhadradriKothagudem_17.Text = NounitsBhadradriKothagudem_17.ToString();
            e.Row.Cells[6].Text = NounitsBhadradriKothagudem_17.ToString();
            e.Row.Cells[6].Controls.Add(hypnounitstotal_fotBhadradriKothagudem_17);
          
            HyperLink hypnounitstotal_fotBhupalpally_12 = new HyperLink();
            hypnounitstotal_fotBhupalpally_12.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fotBhupalpally_12.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=12" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District";
            hypnounitstotal_fotBhupalpally_12.Text = NounitsBhupalpally_12.ToString();
            e.Row.Cells[7].Text = NounitsBhupalpally_12.ToString();
            e.Row.Cells[7].Controls.Add(hypnounitstotal_fotBhupalpally_12);
           
            HyperLink hypnounitstotal_fotNounitsGadwal_13 = new HyperLink();
            hypnounitstotal_fotNounitsGadwal_13.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fotNounitsGadwal_13.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=13" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District";
            hypnounitstotal_fotNounitsGadwal_13.Text = NounitsGadwal_13.ToString();
            e.Row.Cells[8].Text = NounitsGadwal_13.ToString();
            e.Row.Cells[8].Controls.Add(hypnounitstotal_fotNounitsGadwal_13);
           
            HyperLink hypnounitstotal_fotHyderabad_5 = new HyperLink();
            hypnounitstotal_fotHyderabad_5.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fotHyderabad_5.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=5" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District";
            hypnounitstotal_fotHyderabad_5.Text = NounitsHyderabad_5.ToString();
            e.Row.Cells[9].Text = NounitsHyderabad_5.ToString();
            e.Row.Cells[9].Controls.Add(hypnounitstotal_fotHyderabad_5);
 
            HyperLink hypnounitstotal_fotJagtial_14 = new HyperLink();
            hypnounitstotal_fotJagtial_14.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fotJagtial_14.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=14" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District";
            hypnounitstotal_fotJagtial_14.Text = NounitsJagtial_14.ToString();
            e.Row.Cells[10].Text = NounitsJagtial_14.ToString();
            e.Row.Cells[10].Controls.Add(hypnounitstotal_fotJagtial_14);
           
            HyperLink hypnounitstotal_fotJangaon_15 = new HyperLink();
            hypnounitstotal_fotJangaon_15.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fotJangaon_15.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=15" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District";
            hypnounitstotal_fotJangaon_15.Text = NounitsJangaon_15.ToString();
            e.Row.Cells[11].Text = NounitsJangaon_15.ToString();
            e.Row.Cells[11].Controls.Add(hypnounitstotal_fotJangaon_15);
            
            HyperLink hypnounitstotal_fotKamareddy_16 = new HyperLink();
            hypnounitstotal_fotKamareddy_16.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fotKamareddy_16.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=16" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District";
            hypnounitstotal_fotKamareddy_16.Text = NounitsKamareddy_16.ToString();
            e.Row.Cells[12].Text = NounitsKamareddy_16.ToString();
            e.Row.Cells[12].Controls.Add(hypnounitstotal_fotKamareddy_16);

            HyperLink hypnounitstotal_fotKarimnagar_3 = new HyperLink();
            hypnounitstotal_fotKarimnagar_3.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fotKarimnagar_3.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=3" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District";
            hypnounitstotal_fotKarimnagar_3.Text = NounitsKarimnagar_3.ToString();
            e.Row.Cells[13].Text = NounitsKarimnagar_3.ToString();
            e.Row.Cells[13].Controls.Add(hypnounitstotal_fotKarimnagar_3);
         
            HyperLink hypnounitstotal_fotKhammam_10 = new HyperLink();
            hypnounitstotal_fotKhammam_10.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fotKhammam_10.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=10" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District";
            hypnounitstotal_fotKhammam_10.Text = Khammam_10.ToString();
            e.Row.Cells[14].Text = Khammam_10.ToString();
            e.Row.Cells[14].Controls.Add(hypnounitstotal_fotKhammam_10);
      
            HyperLink hypnounitstotal_fotMahabubabad_18 = new HyperLink();
            hypnounitstotal_fotMahabubabad_18.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fotMahabubabad_18.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=18" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District";
            hypnounitstotal_fotMahabubabad_18.Text = NounitsMahabubabad_18.ToString();
            e.Row.Cells[15].Text = NounitsMahabubabad_18.ToString();
            e.Row.Cells[15].Controls.Add(hypnounitstotal_fotMahabubabad_18);

            HyperLink hypnounitstotal_fotMahbubnagar_7 = new HyperLink();
            hypnounitstotal_fotMahbubnagar_7.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fotMahbubnagar_7.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=7" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District";
            hypnounitstotal_fotMahbubnagar_7.Text = NounitsMahbubnagar_7.ToString();
            e.Row.Cells[16].Text = NounitsMahbubnagar_7.ToString();
            e.Row.Cells[16].Controls.Add(hypnounitstotal_fotMahbubnagar_7);

            HyperLink hypnounitstotal_fotMancherial_19 = new HyperLink();
            hypnounitstotal_fotMancherial_19.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fotMancherial_19.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=19" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District";
            hypnounitstotal_fotMancherial_19.Text = NounitsMancherial_19.ToString();
            e.Row.Cells[17].Text = NounitsMancherial_19.ToString();
            e.Row.Cells[17].Controls.Add(hypnounitstotal_fotMancherial_19);
           
            HyperLink hypnounitstotal_fotMedak_4 = new HyperLink();
            hypnounitstotal_fotMedak_4.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fotMedak_4.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=4" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District";
            hypnounitstotal_fotMedak_4.Text = NounitsMedak_4.ToString();
            e.Row.Cells[18].Text = NounitsMedak_4.ToString();
            e.Row.Cells[18].Controls.Add(hypnounitstotal_fotMedak_4);

            HyperLink hypnounitstotal_fotMedchal_20 = new HyperLink();
            hypnounitstotal_fotMedchal_20.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fotMedchal_20.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=20" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District";
            hypnounitstotal_fotMedchal_20.Text = Medchal_20.ToString();
            e.Row.Cells[19].Text = Medchal_20.ToString();
            e.Row.Cells[19].Controls.Add(hypnounitstotal_fotMedchal_20);

            HyperLink hypnounitstotal_fotMulugu_32 = new HyperLink();
            hypnounitstotal_fotMulugu_32.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fotMulugu_32.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=32" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District";
            hypnounitstotal_fotMulugu_32.Text = NounitsMulugu_32.ToString();
            e.Row.Cells[20].Text = NounitsMulugu_32.ToString();
            e.Row.Cells[20].Controls.Add(hypnounitstotal_fotMulugu_32);
           
            HyperLink hypnounitstotal_fotNagarkurnool_21 = new HyperLink();
            hypnounitstotal_fotNagarkurnool_21.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fotNagarkurnool_21.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=21" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District";
            hypnounitstotal_fotNagarkurnool_21.Text = NounitsNagarkurnool_21.ToString();
            e.Row.Cells[21].Text = NounitsNagarkurnool_21.ToString();
            e.Row.Cells[21].Controls.Add(hypnounitstotal_fotNagarkurnool_21);
           
            HyperLink hypnounitstotal_fotNalgonda_8 = new HyperLink();
            hypnounitstotal_fotNalgonda_8.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fotNalgonda_8.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=8" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District";
            hypnounitstotal_fotNalgonda_8.Text = NounitsNalgonda_8.ToString();
            e.Row.Cells[22].Text = NounitsNalgonda_8.ToString();
            e.Row.Cells[22].Controls.Add(hypnounitstotal_fotNalgonda_8);

            HyperLink hypnounitstotal_fotNarayanpet_33 = new HyperLink();
            hypnounitstotal_fotNarayanpet_33.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fotNarayanpet_33.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=33" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District"; 
            hypnounitstotal_fotNarayanpet_33.Text = Narayanpet_33.ToString();
            e.Row.Cells[23].Text = Narayanpet_33.ToString();
            e.Row.Cells[23].Controls.Add(hypnounitstotal_fotNarayanpet_33);

            HyperLink hypnounitstotal_fotNirmal_22 = new HyperLink();
            hypnounitstotal_fotNirmal_22.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fotNirmal_22.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=22" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District";
            hypnounitstotal_fotNirmal_22.Text = NounitsNirmal_22.ToString();
            e.Row.Cells[24].Text = NounitsNirmal_22.ToString();
            e.Row.Cells[24].Controls.Add(hypnounitstotal_fotNirmal_22);

            HyperLink hypnounitstotal_fotNizamabad_2 = new HyperLink();
            hypnounitstotal_fotNizamabad_2.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fotNizamabad_2.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=2" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District"; 
            hypnounitstotal_fotNizamabad_2.Text = NounitsNizamabad_2.ToString();
            e.Row.Cells[25].Text = NounitsNizamabad_2.ToString();
            e.Row.Cells[25].Controls.Add(hypnounitstotal_fotNizamabad_2);
           
            HyperLink hypnounitstotal_fotPeddapalli_23 = new HyperLink();
            hypnounitstotal_fotPeddapalli_23.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fotPeddapalli_23.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=23" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District"; 
            hypnounitstotal_fotPeddapalli_23.Text = NounitsPeddapalli_23.ToString();
            e.Row.Cells[26].Text = NounitsPeddapalli_23.ToString();
            e.Row.Cells[26].Controls.Add(hypnounitstotal_fotPeddapalli_23);

            HyperLink hypnounitstotal_fotRangareddy_6 = new HyperLink();
            hypnounitstotal_fotRangareddy_6.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fotRangareddy_6.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=6" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District"; 
            hypnounitstotal_fotRangareddy_6.Text = Rangareddy_6.ToString();
            e.Row.Cells[27].Text = Rangareddy_6.ToString();
            e.Row.Cells[27].Controls.Add(hypnounitstotal_fotRangareddy_6);

            HyperLink hypnounitstotal_fotSangareddy_24 = new HyperLink();
            hypnounitstotal_fotSangareddy_24.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fotSangareddy_24.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=24" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District";
            hypnounitstotal_fotSangareddy_24.Text = NounitsSangareddy_24.ToString();
            e.Row.Cells[28].Text = NounitsSangareddy_24.ToString();
            e.Row.Cells[28].Controls.Add(hypnounitstotal_fotSangareddy_24);

            HyperLink hypnounitstotal_fotSiddipet_25 = new HyperLink();
            hypnounitstotal_fotSiddipet_25.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fotSiddipet_25.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=25" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District";
            hypnounitstotal_fotSiddipet_25.Text = NounitsSiddipet_25.ToString();
            e.Row.Cells[29].Text = NounitsSiddipet_25.ToString();
            e.Row.Cells[29].Controls.Add(hypnounitstotal_fotSiddipet_25);

            HyperLink hypnounitstotal_fotSircilla_26 = new HyperLink();
            hypnounitstotal_fotSircilla_26.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fotSircilla_26.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=26" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District";
            hypnounitstotal_fotSircilla_26.Text = NounitsSircilla_26.ToString();
            e.Row.Cells[30].Text = NounitsSircilla_26.ToString();
            e.Row.Cells[30].Controls.Add(hypnounitstotal_fotSircilla_26);

            HyperLink hypnounitstotal_fotSuryapet_27 = new HyperLink();
            hypnounitstotal_fotSuryapet_27.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fotSuryapet_27.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=27" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District";
            hypnounitstotal_fotSuryapet_27.Text = Suryapet_27.ToString();
            e.Row.Cells[31].Text = Suryapet_27.ToString();
            e.Row.Cells[31].Controls.Add(hypnounitstotal_fotSuryapet_27);

            HyperLink hypnounitstotal_fotVikarabad_28 = new HyperLink();
            hypnounitstotal_fotVikarabad_28.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fotVikarabad_28.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=28" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District";
            hypnounitstotal_fotVikarabad_28.Text = NounitsVikarabad_28.ToString();
            e.Row.Cells[32].Text = NounitsVikarabad_28.ToString();
            e.Row.Cells[32].Controls.Add(hypnounitstotal_fotVikarabad_28);

            HyperLink hypnounitstotal_fotWanaparthy_29 = new HyperLink();
            hypnounitstotal_fotWanaparthy_29.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fotWanaparthy_29.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=29" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District";
            hypnounitstotal_fotWanaparthy_29.Text = NounitsWanaparthy_29.ToString();
            e.Row.Cells[33].Text = NounitsWanaparthy_29.ToString();
            e.Row.Cells[33].Controls.Add(hypnounitstotal_fotWanaparthy_29);

            HyperLink hypnounitstotal_fotWarangal_Rural_9 = new HyperLink();
            hypnounitstotal_fotWarangal_Rural_9.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fotWarangal_Rural_9.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=9" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District";
            hypnounitstotal_fotWarangal_Rural_9.Text = NounitsWarangal_Rural_9.ToString();
            e.Row.Cells[34].Text = NounitsWarangal_Rural_9.ToString();
            e.Row.Cells[34].Controls.Add(hypnounitstotal_fotWarangal_Rural_9);
           
            HyperLink hypnounitstotal_fotWarangal_Urban_30 = new HyperLink();
            hypnounitstotal_fotWarangal_Urban_30.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fotWarangal_Urban_30.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=30" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District";
            hypnounitstotal_fotWarangal_Urban_30.Text = Warangal_Urban_30.ToString();
            e.Row.Cells[35].Text = Warangal_Urban_30.ToString();
            e.Row.Cells[35].Controls.Add(hypnounitstotal_fotWarangal_Urban_30);
            
            HyperLink hypnounitstotal_fotYadadri_31 = new HyperLink();
            hypnounitstotal_fotYadadri_31.ForeColor = System.Drawing.Color.White;
            hypnounitstotal_fotYadadri_31.NavigateUrl = "comReportDrill_drilldown_Department.aspx?Dist=31" + "&Code=" + ViewState["querystrg"].ToString() + "&fromdate=" + fromdate + "&todate=" + todate + "&appltype=District";
            hypnounitstotal_fotYadadri_31.Text = NounitsYadadri_31.ToString();
            e.Row.Cells[36].Text = NounitsYadadri_31.ToString();
            e.Row.Cells[36].Controls.Add(hypnounitstotal_fotYadadri_31);
           

        }
        #endregion
    }
}