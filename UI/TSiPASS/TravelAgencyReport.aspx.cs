using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_TravelAgencyReport : System.Web.UI.Page
{
    General Gen = new General();
    int TRAVEL_AGENCY_COUNT,TOUR_OPERATOR_COUNT;
    decimal TRAVEL_AGENCY_AMOUNT, TOUR_OPERATOR_AMOUNT;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("../../Index.aspx");
        }

        if (!IsPostBack)
        {
            txtFromDate.Text = "01-01-2020";
            DateTime today = DateTime.Today;
            txtTodate.Text = today.ToString("dd-MM-yyyy");
            btnData_Click(sender, e);
        }
    }
    public void BindData()
    {
        try
        {
            DataSet ds = new DataSet();
            string Fromdate = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            string Todate = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            ds = Gen.GetTravelAgencyAbstract(Session["uid"].ToString(), Fromdate, Todate);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvTravel.DataSource = ds.Tables[0];
                gvTravel.DataBind();
            }
            else
            {
                gvTravel.DataSource = null;
                gvTravel.DataBind();
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void gvTravel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            string FD = txtFromDate.Text;
            string TD = txtTodate.Text;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblDistId = (Label)e.Row.FindControl("lblDistId");
                HyperLink hypTRAVEL_AGENCY_COUNT = (HyperLink)e.Row.FindControl("hypTRAVEL_AGENCY_COUNT");
                HyperLink hypTRAVEL_AGENCY_AMOUNT = (HyperLink)e.Row.FindControl("hypTRAVEL_AGENCY_AMOUNT");
                HyperLink hypTOUR_OPERATOR_COUNT = (HyperLink)e.Row.FindControl("hypTOUR_OPERATOR_COUNT");
                HyperLink hypTOUR_OPERATOR_AMOUNT = (HyperLink)e.Row.FindControl("hypTOUR_OPERATOR_AMOUNT");

                int TRAVEL_AGENCY_COUNT1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TRAVEL_AGENCY_COUNT"));
                TRAVEL_AGENCY_COUNT = TRAVEL_AGENCY_COUNT1 + TRAVEL_AGENCY_COUNT;

                int TOUR_OPERATOR_COUNT1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TOUR_OPERATOR_COUNT"));
                TOUR_OPERATOR_COUNT = TOUR_OPERATOR_COUNT + TOUR_OPERATOR_COUNT1;

                decimal TRAVEL_AGENCY_AMOUNT1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TRAVEL_AGENCY_AMOUNT"));
                TRAVEL_AGENCY_AMOUNT = TRAVEL_AGENCY_AMOUNT + TRAVEL_AGENCY_AMOUNT1;

                decimal TOUR_OPERATOR_AMOUNT1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TOUR_OPERATOR_AMOUNT"));
                TOUR_OPERATOR_AMOUNT = TOUR_OPERATOR_AMOUNT + TOUR_OPERATOR_AMOUNT1;

                string Dist = lblDistId.Text.ToString();

                hypTRAVEL_AGENCY_COUNT.NavigateUrl = "TravelAgencyDtldReport.aspx?Dist=" + Dist + "&fdt=" + FD + "&tdt=" + TD + "&Type=1";
                hypTRAVEL_AGENCY_AMOUNT.NavigateUrl = "TravelAgencyDtldReport.aspx?Dist=" + Dist + "&fdt=" + FD + "&tdt=" + TD + "&Type=1";
                hypTOUR_OPERATOR_COUNT.NavigateUrl = "TravelAgencyDtldReport.aspx?Dist=" + Dist + "&fdt=" + FD + "&tdt=" + TD + "&Type=2";
                hypTOUR_OPERATOR_AMOUNT.NavigateUrl = "TravelAgencyDtldReport.aspx?Dist=" + Dist + "&fdt=" + FD + "&tdt=" + TD + "&Type=2";


            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "Total ";
                e.Row.Cells[2].Text = TRAVEL_AGENCY_COUNT.ToString();
                e.Row.Cells[3].Text = TRAVEL_AGENCY_AMOUNT.ToString();
                e.Row.Cells[4].Text = TOUR_OPERATOR_COUNT.ToString();
                e.Row.Cells[5].Text = TOUR_OPERATOR_AMOUNT.ToString();
                e.Row.Cells[1].Style.Add("text-align", "right");

                HyperLink h1 = new HyperLink();
                h1.Text = TRAVEL_AGENCY_COUNT.ToString();
                if (h1.Text != "0" && h1.Text != "0.00")
                {
                    h1.NavigateUrl = "TourismEventDtldReport.aspx?Dist=All&fdt=" + FD + "&tdt=" + TD + "&Type=1";
                    e.Row.Cells[2].Controls.Add(h1);
                }
                HyperLink h2 = new HyperLink();
                h2.Text = TRAVEL_AGENCY_AMOUNT.ToString();
                if (h2.Text != "0" && h2.Text != "0.00")
                {
                    h2.NavigateUrl = "TourismEventDtldReport.aspx?Dist=All&fdt=" + FD + "&tdt=" + TD + "&Type=1";
                    e.Row.Cells[3].Controls.Add(h2);
                }
                HyperLink h3 = new HyperLink();
                h3.Text = TOUR_OPERATOR_COUNT.ToString();
                if (h3.Text != "0" && h3.Text != "0.00")
                {
                    h3.NavigateUrl = "TourismEventDtldReport.aspx?Dist=All&fdt=" + FD + "&tdt=" + TD + "&Type=2";
                    e.Row.Cells[4].Controls.Add(h3);
                }
                HyperLink h4 = new HyperLink();
                h4.Text = TOUR_OPERATOR_AMOUNT.ToString();
                if (h4.Text != "0" && h4.Text != "0.00")
                {
                    h4.NavigateUrl = "TourismEventDtldReport.aspx?Dist=All&fdt=" + FD + "&tdt=" + TD + "&Type=2";
                    e.Row.Cells[5].Controls.Add(h4);
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void gvTravel_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            TableHeaderCell HeaderCell = new TableHeaderCell();
            HeaderCell.ColumnSpan = 2;
            HeaderCell.RowSpan = 1;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "";
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);


            HeaderCell = new TableHeaderCell();
            HeaderCell.ColumnSpan = 2;
            HeaderCell.RowSpan = 1;
            HeaderCell.Font.Bold = true;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "Travel Agency";
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableHeaderCell();
            HeaderCell.ColumnSpan = 2;
            HeaderCell.RowSpan = 1;
            HeaderCell.Font.Bold = true;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "Tour Operator";
            HeaderGridRow.Cells.Add(HeaderCell);

            gvTravel.Controls[0].Controls.AddAt(0, HeaderGridRow);
        }
    }

    protected void btnData_Click(object sender, EventArgs e)
    {
        header.InnerHtml = "Data from " + txtFromDate.Text + " to " + txtTodate.Text;
        BindData();
    }
    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        PrintPdf();
    }
    protected void BtnExcel_Click(object sender, EventArgs e)
    {
        ExportToExcel();

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void ExportToExcel()
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            string FileName = "Travel Agency";
            string Heading = header.InnerHtml.ToString();
            FileName = FileName.Replace(" ", "");
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName + "_" + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvTravel.RenderControl(hw);

                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='6'><h4>" + Heading + "</h4></td></td></tr><tr><td align='center' colspan='6'></td></td></tr></table>";
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
    protected void PrintPdf()
    {
        try
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {

                    gvTravel.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    gvTravel.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                    gvTravel.FooterRow.ForeColor = System.Drawing.Color.Black;
                    gvTravel.FooterStyle.ForeColor = System.Drawing.Color.Black;


                    gvTravel.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    string FileName = "Travel Agency";
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=" + FileName + "_" + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
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
}