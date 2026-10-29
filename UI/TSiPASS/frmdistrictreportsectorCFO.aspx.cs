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

public partial class UI_TSiPASS_frmdistrictreportsectorCFO : System.Web.UI.Page
{
    General Gen = new General();
    int valid = 0;
    string FromdateforDB = "", TodateforDB = "";

    decimal StoneCrushing, FlyAshBricks, Others, ThermalPowerPlant, PlasticandRubber,
        AerospaceandDefence, ElectronicProducts, RD, Engineering, DEFENCEEQUIPMENT, Printing, Textiles,
        ITBuildings, RenewableEnergy, ColdStorages, Automobile, Leather, FoodProcessing,
        Beverages, ITSERVICES, Fertlizers, PharmaceuticalsandChemicals, TOTALUNITS, TotalEmployeement, TotalInvestment;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {
            BindDistricts();
            txtFromDate.Text = "01-03-2020";
            DateTime today = DateTime.Today;
            txtTodate.Text = today.ToString("dd-MM-yyyy");
            if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
            {
                ddlProp_intDistrictid.SelectedValue = Session["DistrictID"].ToString().Trim();
                ddlProp_intDistrictid.Enabled = false;
            }
            else
            {
                ddlProp_intDistrictid.SelectedIndex = 0;
            }
            BindFinancialYears(ddlFinancialYear);
            fillgrid();
        }
    }

    public void BindDistricts()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlProp_intDistrictid.Items.Clear();
            dsd = Gen.GetDistrictsWithoutHYD();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlProp_intDistrictid.DataSource = dsd.Tables[0];
                ddlProp_intDistrictid.DataValueField = "District_Id";
                ddlProp_intDistrictid.DataTextField = "District_Name";
                ddlProp_intDistrictid.DataBind();
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("--All--", "%");
                ddlProp_intDistrictid.Items.Insert(0, li);
            }
            else
            {
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("--All--", "%");
                ddlProp_intDistrictid.Items.Insert(0, li);
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }

    public void fillgrid()
    {
        DataSet dsnew = new DataSet();
        string ReleaseProceedingNo = "";
        if (txtFromDate.Text == "" || txtFromDate.Text == null)
        {
            lblmsg0.Text = "Please Enter From Date <br/>";
            valid = 1;
        }
        if (txtTodate.Text == "" || txtTodate.Text == null)
        {
            lblmsg0.Text += "Please Enter To Date <br/>";
            valid = 1;
        }
        if (valid == 0)
        {
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        }
        dsnew = GetDistrictWisePollutionCategory(FromdateforDB, TodateforDB, ddlProp_intDistrictid.SelectedValue, ddlFinancialYear.SelectedValue);

        if (dsnew.Tables[0].Rows.Count > 0)
        {

            grdDetails.DataSource = dsnew.Tables[0];
            grdDetails.DataBind();

        }
        else
        {

            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {


    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            decimal StoneCrushing1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "GraniteandStoneCrushing"));
            StoneCrushing = StoneCrushing1 + StoneCrushing;

            decimal FlyAshBricks1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CementCementConcreteProductsFlyAshBricks"));
            FlyAshBricks = FlyAshBricks1 + FlyAshBricks;

            decimal Others1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Others"));
            Others = Others1 + Others;

            decimal ThermalPowerPlant1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ThermalPowerPlant"));
            ThermalPowerPlant = ThermalPowerPlant1 + ThermalPowerPlant;

            decimal PlasticandRubber1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PlasticandRubber"));
            PlasticandRubber = PlasticandRubber1 + PlasticandRubber;

            decimal AerospaceandDefence1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "AerospaceandDefence"));
            AerospaceandDefence = AerospaceandDefence1 + AerospaceandDefence;

            decimal ElectronicProducts1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ElectricalandElectronicProducts"));
            ElectronicProducts = ElectronicProducts1 + ElectronicProducts;

            decimal RD1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "RD"));
            RD = RD1 + RD;

            decimal Engineering1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Engineering"));
            Engineering = Engineering1 + Engineering;

            decimal DEFENCEEQUIPMENT1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "DEFENCEEQUIPMENT"));
            DEFENCEEQUIPMENT = DEFENCEEQUIPMENT1 + DEFENCEEQUIPMENT;

            decimal Printing1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PaperandPrinting"));
            Printing = Printing1 + Printing;

            decimal Textiles1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Textiles"));
            Textiles = Textiles1 + Textiles;

            decimal ITBuildings1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "RealEstateIndustrialParksandITBuildings"));
            ITBuildings = ITBuildings1 + ITBuildings;

            decimal RenewableEnergy1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SolarandOtherRenewableEnergy"));
            RenewableEnergy = RenewableEnergy1 + RenewableEnergy;

            decimal ColdStorages1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "AgrobasedinclColdStorages"));
            ColdStorages = ColdStorages1 + ColdStorages;

            decimal Automobile1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Automobile"));
            Automobile = Automobile1 + Automobile;

            decimal Leather1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "WoodandLeather"));
            Leather = Leather1 + Leather;

            decimal FoodProcessing1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "FoodProcessing"));
            FoodProcessing = FoodProcessing1 + FoodProcessing;
            decimal Beverages1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Beverages"));
            Beverages = Beverages1 + Beverages;
            decimal ITSERVICES1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ITSERVICES"));
            ITSERVICES = ITSERVICES1 + ITSERVICES;
            decimal Fertlizers1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "FertlizersOrganicandInorganicPesticidesInsecticidesandOtherRelated"));
            Fertlizers = Fertlizers1 + Fertlizers;
            decimal Pharmaceuticals1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PharmaceuticalsandChemicals"));
            PharmaceuticalsandChemicals = Pharmaceuticals1 + PharmaceuticalsandChemicals;

            decimal TOTALUNITS1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TOTALUNITS"));
            TOTALUNITS = TOTALUNITS1 + TOTALUNITS;

            decimal TotalEmployeement1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalEmployeement"));
            TotalEmployeement = TotalEmployeement1 + TotalEmployeement;

            decimal TotalInvestment1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "InvestmentCr"));
            TotalInvestment = TotalInvestment1 + TotalInvestment;

            string district = DataBinder.Eval(e.Row.DataItem, "DISTRICTNAME").ToString();


            HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
            if (h1.Text != "0")
            {
                h1.NavigateUrl = "frmDistrictReportSectorDRILLDOWNCFO.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&polcategory=" + "Granite and Stone Crushing" + "&district=" + district;
            }
            HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
            if (h2.Text != "0")
            {
                h2.NavigateUrl = "frmDistrictReportSectorDRILLDOWNCFO.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&polcategory=" + "Cement, Cement & Concrete Products, Fly Ash Bricks" + "&district=" + district;
            }

            HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
            if (h3.Text != "0")
            {
                h3.NavigateUrl = "frmDistrictReportSectorDRILLDOWNCFO.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&polcategory=" + "Others" + "&district=" + district;
            }

            HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
            if (h4.Text != "0")
            {
                h4.NavigateUrl = "frmDistrictReportSectorDRILLDOWNCFO.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&polcategory=" + "Thermal Power Plant" + "&district=" + district;
            }

            HyperLink h5 = (HyperLink)e.Row.Cells[6].Controls[0];
            if (h5.Text != "0")
            {
                h5.NavigateUrl = "frmDistrictReportSectorDRILLDOWNCFO.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&polcategory=" + "Plastic and Rubber" + "&district=" + district;
            }
            HyperLink h6 = (HyperLink)e.Row.Cells[7].Controls[0];
            if (h6.Text != "0")
            {
                h6.NavigateUrl = "frmDistrictReportSectorDRILLDOWNCFO.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&polcategory=" + "Aerospace and Defence" + "&district=" + district;
            }
            HyperLink h7 = (HyperLink)e.Row.Cells[8].Controls[0];
            if (h7.Text != "0")
            {
                h7.NavigateUrl = "frmDistrictReportSectorDRILLDOWNCFO.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&polcategory=" + "Electrical and Electronic Products" + "&district=" + district;
            }
            HyperLink h8 = (HyperLink)e.Row.Cells[9].Controls[0];
            if (h8.Text != "0")
            {
                h8.NavigateUrl = "frmDistrictReportSectorDRILLDOWNCFO.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&polcategory=" + "R&D" + "&district=" + district;
            }
            HyperLink h9 = (HyperLink)e.Row.Cells[10].Controls[0];
            if (h9.Text != "0")
            {
                h9.NavigateUrl = "frmDistrictReportSectorDRILLDOWNCFO.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&polcategory=" + "Engineering" + "&district=" + district;
            }
            HyperLink h10 = (HyperLink)e.Row.Cells[11].Controls[0];
            if (h10.Text != "0")
            {
                h10.NavigateUrl = "frmDistrictReportSectorDRILLDOWNCFO.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&polcategory=" + "DEFENCE EQUIPMENT" + "&district=" + district;
            }
            HyperLink h11 = (HyperLink)e.Row.Cells[12].Controls[0];
            if (h11.Text != "0")
            {
                h11.NavigateUrl = "frmDistrictReportSectorDRILLDOWNCFO.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&polcategory=" + "Paper and Printing" + "&district=" + district;
            }
            HyperLink h12 = (HyperLink)e.Row.Cells[13].Controls[0];
            if (h12.Text != "0")
            {
                h12.NavigateUrl = "frmDistrictReportSectorDRILLDOWNCFO.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&polcategory=" + "Textiles" + "&district=" + district;
            }
            HyperLink h13 = (HyperLink)e.Row.Cells[14].Controls[0];
            if (h13.Text != "0")
            {
                h13.NavigateUrl = "frmDistrictReportSectorDRILLDOWNCFO.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&polcategory=" + "Real Estate,Industrial Parks and IT Buildings" + "&district=" + district;
            }
            HyperLink h14 = (HyperLink)e.Row.Cells[15].Controls[0];
            if (h14.Text != "0")
            {
                h14.NavigateUrl = "frmDistrictReportSectorDRILLDOWNCFO.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&polcategory=" + "Solar and Other Renewable Energy" + "&district=" + district;
            }
            HyperLink h15 = (HyperLink)e.Row.Cells[16].Controls[0];
            if (h15.Text != "0")
            {
                h15.NavigateUrl = "frmDistrictReportSectorDRILLDOWNCFO.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&polcategory=" + "Agro based incl Cold Storages" + "&district=" + district;
            }
            HyperLink h16 = (HyperLink)e.Row.Cells[17].Controls[0];
            if (h16.Text != "0")
            {
                h16.NavigateUrl = "frmDistrictReportSectorDRILLDOWNCFO.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&polcategory=" + "Automobile" + "&district=" + district;
            }
            HyperLink h17 = (HyperLink)e.Row.Cells[18].Controls[0];
            if (h17.Text != "0")
            {
                h17.NavigateUrl = "frmDistrictReportSectorDRILLDOWNCFO.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&polcategory=" + "Wood and Leather" + "&district=" + district;
            }
            HyperLink h18 = (HyperLink)e.Row.Cells[19].Controls[0];
            if (h18.Text != "0")
            {
                h18.NavigateUrl = "frmDistrictReportSectorDRILLDOWNCFO.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&polcategory=" + "Food Processing" + "&district=" + district;
            }
            HyperLink h19 = (HyperLink)e.Row.Cells[20].Controls[0];
            if (h19.Text != "0")
            {
                h19.NavigateUrl = "frmDistrictReportSectorDRILLDOWNCFO.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&polcategory=" + "Beverages" + "&district=" + district;
            }
            HyperLink h20 = (HyperLink)e.Row.Cells[21].Controls[0];
            if (h20.Text != "0")
            {
                h20.NavigateUrl = "frmDistrictReportSectorDRILLDOWNCFO.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&polcategory=" + "IT SERVICES" + "&district=" + district;
            }
            HyperLink h21 = (HyperLink)e.Row.Cells[22].Controls[0];
            if (h21.Text != "0")
            {

                h21.NavigateUrl = "frmDistrictReportSectorDRILLDOWNCFO.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&polcategory=" + "Fertlizers Organic and Inorganic,Pesticides,Insecticides, and Other Related" + "&district=" + district;
            }
            HyperLink h22 = (HyperLink)e.Row.Cells[23].Controls[0];
            if (h22.Text != "0")
            {
                h22.NavigateUrl = "frmDistrictReportSectorDRILLDOWNCFO.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&polcategory=" + "Pharmaceuticals and Chemicals" + "&district=" + district;
            }
            HyperLink h23 = (HyperLink)e.Row.Cells[24].Controls[0];
            if (h23.Text != "0")
            {
                h23.NavigateUrl = "frmDistrictReportSectorDRILLDOWNCFO.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&polcategory=" + "TOTALUNITS" + "&district=" + district;
            }

            HyperLink h25 = (HyperLink)e.Row.Cells[25].Controls[0];
            if (h25.Text != "0")
            {
                h25.NavigateUrl = "frmDistrictReportSectorDRILLDOWNCFO.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&polcategory=" + "TOTALUNITS" + "&district=" + district;
            }

            HyperLink h26 = (HyperLink)e.Row.Cells[26].Controls[0];
            if (h26.Text != "0")
            {
                h26.NavigateUrl = "frmDistrictReportSectorDRILLDOWNCFO.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&polcategory=" + "TOTALUNITS" + "&district=" + district;
            }


        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {



            e.Row.Cells[1].Text = "Total";
            e.Row.Cells[2].Text = StoneCrushing.ToString();
            e.Row.Cells[3].Text = FlyAshBricks.ToString();
            e.Row.Cells[4].Text = Others.ToString();
            e.Row.Cells[5].Text = ThermalPowerPlant.ToString();
            e.Row.Cells[6].Text = PlasticandRubber.ToString();
            e.Row.Cells[7].Text = AerospaceandDefence.ToString();
            e.Row.Cells[8].Text = ElectronicProducts.ToString();
            e.Row.Cells[9].Text = RD.ToString();
            e.Row.Cells[10].Text = Engineering.ToString();
            e.Row.Cells[11].Text = DEFENCEEQUIPMENT.ToString();
            e.Row.Cells[12].Text = Printing.ToString();
            e.Row.Cells[13].Text = Textiles.ToString();
            e.Row.Cells[14].Text = ITBuildings.ToString();
            e.Row.Cells[15].Text = RenewableEnergy.ToString();
            e.Row.Cells[16].Text = ColdStorages.ToString();
            e.Row.Cells[17].Text = Automobile.ToString();
            e.Row.Cells[18].Text = Leather.ToString();
            e.Row.Cells[19].Text = FoodProcessing.ToString();
            e.Row.Cells[20].Text = Beverages.ToString();
            e.Row.Cells[21].Text = ITSERVICES.ToString();
            e.Row.Cells[22].Text = Fertlizers.ToString();
            e.Row.Cells[23].Text = PharmaceuticalsandChemicals.ToString();
            e.Row.Cells[24].Text = TOTALUNITS.ToString();
            e.Row.Cells[25].Text = TotalEmployeement.ToString();
            e.Row.Cells[26].Text = TotalInvestment.ToString();



        }
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }


    protected void BtnSave2_Click(object sender, EventArgs e)
    {
        ExportToExcel();

    }

    protected void ExportToExcel()
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            string FileName = lblHeading.Text;
            FileName = FileName.Replace(" ", "");
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                grdDetails.RenderControl(hw);

                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='6'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='6'></td></td></tr></table>";
                HttpContext.Current.Response.Write(headerTable);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        catch (Exception e)
        {

        }
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

                    grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                    grdDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.FooterStyle.ForeColor = System.Drawing.Color.Black;
                    grdDetails.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();


                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename= SectorReport.pdf");
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

    protected void BtnSave1_Click(object sender, EventArgs e)
    {

        int valid = 0;
        lblmsg0.Text = "";
        Failure.Visible = false;

        if (txtFromDate.Text == "" || txtFromDate.Text == null)
        {
            lblmsg0.Text = "Please Enter From Date <br/>";
            valid = 1;
        }
        if (txtTodate.Text == "" || txtTodate.Text == null)
        {
            lblmsg0.Text += "Please Enter To Date <br/>";
            valid = 1;
        }

        if (valid == 0)
        {
            fillgrid();
        }
        else
        {
            Failure.Visible = true;
        }
    }

    public DataSet GetDistrictWisePollutionCategory(string fromdate, string todate, string districtid, string financialcd)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
             new SqlParameter("@FromDate",SqlDbType.VarChar),
                new SqlParameter("@ToDate",SqlDbType.VarChar),
               new SqlParameter("@DISTRICTID",SqlDbType.VarChar),
               new SqlParameter("@FinancialYearCd",SqlDbType.VarChar),

           };
        pp[0].Value = fromdate;
        pp[1].Value = todate;
        pp[2].Value = districtid;
        pp[3].Value = financialcd;

        //Dsnew = Gen.GenericFillDs("USP_GET_DISTRICTREPORT_SECTOR", pp);
        Dsnew = Gen.GenericFillDs("USP_GET_DISTRICTREPORT_SECTOR_CFO", pp);
        return Dsnew;
    }

    public void BindFinancialYears(DropDownList ddlFinYear)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlFinYear.Items.Clear();
            dsd = Gen.GetFinancialYearsForReports();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlFinYear.DataSource = dsd.Tables[0];
                ddlFinYear.DataValueField = "SlNo";
                ddlFinYear.DataTextField = "FinancialYear";
                ddlFinYear.DataBind();

            }


            ddlFinYear.Items.Insert(0, "--Select--");

        }
        catch (Exception ex)
        {
        }
    }
}