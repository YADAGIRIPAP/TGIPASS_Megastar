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
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Globalization;
using System.Text;

//created by suresh as on 13-1-2016 
//tables is td_BDCDet,tbl_Users
//procedures CheckUserid,insrtBDC,deleteBDC,getBDCbyID
public partial class TSTBDCReg1 : System.Web.UI.Page
{
    decimal district11, district12, district13, district14, state11, state12, state13, state14;
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    string FromdateforDB, TodateforDB;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["user"] != null && Session["user"] != "")
        //{ }
        //else
        //{
        //    Response.Redirect("/Account/Login.aspx?link=" + System.Web.HttpContext.Current.Request.Url.PathAndQuery);
        //}
        DataSet ds = new DataSet();
        if (Session["userlevel"].ToString() == "1")
        {
            lblHeading.Text = "COMMISSIONER'S DASH BOARD";
            lblHeading2.Text = "COMMISSIONER'S DASH BOARD";
        }
        else
        {
            lblHeading.Text = "COLLECTOR'S DASH BOARD";
            lblHeading2.Text = "COLLECTOR'S DASH BOARD";
        }
        if (!IsPostBack)
        {
            ds = Gen.DistrictWiseReport(ddlFinancialYear.SelectedValue.ToString().Trim());
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }


    }


    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {



    }
    void clear()
    {




    }


    protected void BtnClear0_Click(object sender, EventArgs e)
    {


    }
    void FillDetails()
    {


    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {

    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    void getcounties()
    {

    }
    protected void ddlCounties_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    void getPayams()
    {

    }
    protected void ddlState_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void ddlCounties_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void BtnSave2_Click(object sender, EventArgs e)
    {

        try
        {



        }
        catch (Exception ex)
        {
            // lblmsg.Text = ex.ToString();
        }
        finally
        {

        }

    }



    protected void ddlProp_intDistrictid_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal district1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "District Level"));
            district11 = district1 + district11;

            decimal state1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "State Level"));
            state11 = state1 + state11;


            decimal district2 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "District Level1"));
            district12 = district2 + district12;


            decimal state2 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "State Level1"));
            state12 = state2 + state12;

            decimal district3 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "District Level2"));
            district13 = district3 + district13;

            decimal state3 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "State Level2"));
            state13 = state3 + state13;

            decimal district4 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "District Level Rejected"));
            district14 = district4 + district14;

            decimal state4 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "State Level Rejected"));
            state14 = state4 + state14;

            HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
            h1.Target = "_blank";
            h1.NavigateUrl = "CommissionerDashboardDrilldown.aspx?Stage=1&District=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim();

            HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
            h2.Target = "_blank";
            h2.NavigateUrl = "CommissionerDashboardDrilldown.aspx?Stage=2&District=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim();

            HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
            h3.Target = "_blank";
            h3.NavigateUrl = "CommissionerDashboardDrilldown.aspx?Stage=3&District=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim();

            HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
            h4.Target = "_blank";
            h4.NavigateUrl = "CommissionerDashboardDrilldown.aspx?Stage=4&District=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim();

            HyperLink h5 = (HyperLink)e.Row.Cells[6].Controls[0];
            h5.Target = "_blank";
            h5.NavigateUrl = "CommissionerDashboardDrilldown.aspx?Stage=5&District=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim();

            HyperLink h6 = (HyperLink)e.Row.Cells[7].Controls[0];
            h6.Target = "_blank";
            h6.NavigateUrl = "CommissionerApproval.aspx?Stage=6&District=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim();

            HyperLink h7 = (HyperLink)e.Row.Cells[8].Controls[0];
            h7.Target = "_blank";
            h7.NavigateUrl = "CommissionerDashboardDrilldown.aspx?Stage=7&District=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim();

            HyperLink h8 = (HyperLink)e.Row.Cells[9].Controls[0];
            h8.Target = "_blank";
            h8.NavigateUrl = "CommissionerDashboardDrilldown.aspx?Stage=8&District=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim();
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {

            e.Row.Cells[1].Text = "Total";
            e.Row.Cells[2].Text = district11.ToString();
            e.Row.Cells[3].Text = state11.ToString();
            e.Row.Cells[4].Text = district12.ToString();
            e.Row.Cells[5].Text = state12.ToString();
            e.Row.Cells[6].Text = district13.ToString();
            e.Row.Cells[7].Text = state13.ToString();
            e.Row.Cells[8].Text = district14.ToString();
            e.Row.Cells[9].Text = state14.ToString();
        }

    }
    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            TableCell HeaderCell = new TableCell();
            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 2;
            HeaderCell.RowSpan = 0;
            HeaderCell.Font.Bold = true;
            HeaderCell.Text = "";
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 2;
            HeaderCell.RowSpan = 0;
            HeaderCell.Font.Bold = true;
            HeaderCell.Text = "Pre-scrutiny Stage";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderGridRow.Cells.Add(HeaderCell);
            grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);

            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 2;
            HeaderCell.RowSpan = 0;
            HeaderCell.Font.Bold = true;
            HeaderCell.Text = "Payment / Approval Stage";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderGridRow.Cells.Add(HeaderCell);
            grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);

            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 2;
            HeaderCell.RowSpan = 0;
            HeaderCell.Font.Bold = true;
            HeaderCell.Text = "Approved Stage";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderGridRow.Cells.Add(HeaderCell);
            grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);

            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 2;
            HeaderCell.RowSpan = 0;
            HeaderCell.Font.Bold = true;
            HeaderCell.Text = "Rejected Stage";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderGridRow.Cells.Add(HeaderCell);
            grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);
        }
    }

    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        //Response.ContentType = "application/pdf";
        //Response.AddHeader("content-disposition", "attachment;filename=R6.1Panel.pdf");
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);

        //StringWriter stringWriter = new StringWriter();
        //HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
        //divPrint.RenderControl(htmlTextWriter);

        //StringReader stringReader = new StringReader(stringWriter.ToString());
        //Document Doc = new Document(PageSize.A4, 100f, 100f, 100f, 0f);
        //HTMLWorker htmlparser = new HTMLWorker(Doc);
        //PdfWriter.GetInstance(Doc, Response.OutputStream);

        //Doc.Open();
        //htmlparser.Parse(stringReader);
        //Doc.Close();
        //Response.Write(Doc);
        //Response.End();
        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                grdDetails.AllowPaging = false;

                this.fillgrid();

                grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                grdDetails.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                grdDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
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
                Response.AddHeader("content-disposition", "attachment;filename=TS-iPASS District Wise" + ".pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.Flush();
                Response.End();
            }
        }
    }
    public void fillgrid()
    {
        DataSet ds = new DataSet();
        ds = Gen.DistrictWiseReport(ddlFinancialYear.SelectedValue.ToString().Trim());
        grdDetails.DataSource = ds.Tables[0];
        grdDetails.DataBind();
    }

    protected void ddlFinancialYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dsd = new DataSet();
        dsd = Gen.GetFinancialYearsFromTodate(ddlFinancialYear.SelectedValue);

        if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
        {

            string Fromdate, Todate;
            Fromdate = dsd.Tables[0].Rows[0]["FromDate"].ToString();
            Todate = dsd.Tables[0].Rows[0]["ToDate"].ToString();

            //FromdateforDB = Convert.ToString(DateTime.ParseExact(Fromdate, "dd/MM/yyyy", null).ToString("MM-dd-yyyy"));
            //TodateforDB = Convert.ToString(DateTime.ParseExact(Todate, "dd/MM/yyyy", null).ToString("MM-dd-yyyy"));

            FromdateforDB = Convert.ToString(DateTime.ParseExact(Fromdate, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(Todate, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));

            ViewState["FromdateforDB"] = FromdateforDB;
            ViewState["TodateforDB"] = TodateforDB;



        }

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

                //  string Fromdate, Todate;
                //Fromdate =  dsd.Tables[0].Rows[0]["FromDate"].ToString();
                //Todate= dsd.Tables[0].Rows[0]["ToDate"].ToString();

                //  FromdateforDB = Convert.ToString(DateTime.ParseExact(Fromdate, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                //  TodateforDB = Convert.ToString(DateTime.ParseExact(Todate, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));

                ddlFinYear.DataSource = dsd.Tables[0];
                ddlFinYear.DataValueField = "SlNo";
                ddlFinYear.DataTextField = "FinancialYear";
                ddlFinYear.DataBind();
                //if (Session["Role_Code"] != null && Session["Role_Code"].ToString() != "" && Session["Role_Code"].ToString() == "COMM")
                //{
                //    AddAll(ddlFinYear);
                //}
            }


            ddlFinYear.Items.Insert(0, "--Select--");

        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }
    protected void rbtnlstInputType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtnlstInputType.SelectedValue == "N")
        {
            //trBetweenDates.Visible = true;
            trFinYears.Visible = false;
            // ClearFields();
        }
        else
        {
            //trBetweenDates.Visible = false;
            trFinYears.Visible = true;
            BindFinancialYears(ddlFinancialYear);
            //ClearFields();
        }
    }
}
