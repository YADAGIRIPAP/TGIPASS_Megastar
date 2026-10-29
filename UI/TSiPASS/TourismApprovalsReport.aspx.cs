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

public partial class UI_TSiPASS_TourismApprovalsReport : System.Web.UI.Page
{
    General Gen = new General();
    int Totcfecount, Totcfocount, Totrencount;
    decimal Totcfeamount, Totcfoamount, Totrenamount;
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
            ds = Gen.GetTourismApprovalsAbstract(Session["uid"].ToString(), Fromdate, Todate);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvApprovals.DataSource = ds.Tables[0];
                gvApprovals.DataBind();
            }
            else
            {
                gvApprovals.DataSource = null;
                gvApprovals.DataBind();
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void gvApprovals_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            string FD = txtFromDate.Text;
            string TD = txtTodate.Text;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                Label lblDistId = (Label)e.Row.FindControl("lblDistId");
                HyperLink hypCFE_COUNT = (HyperLink)e.Row.FindControl("hypCFE_COUNT");
                HyperLink hypCFE_AMOUNT = (HyperLink)e.Row.FindControl("hypCFE_AMOUNT");
                HyperLink hypCFO_COUNT = (HyperLink)e.Row.FindControl("hypCFO_COUNT");
                HyperLink hypCFO_AMOUNT = (HyperLink)e.Row.FindControl("hypCFO_AMOUNT");
                HyperLink hypREN_COUNT = (HyperLink)e.Row.FindControl("hypREN_COUNT");
                HyperLink hypREN_AMOUNT = (HyperLink)e.Row.FindControl("hypREN_AMOUNT");

                int Totcfecount1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CFE_COUNT"));
                Totcfecount = Totcfecount1 + Totcfecount;

                int Totcfocount1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CFO_COUNT"));
                Totcfocount = Totcfocount + Totcfocount1;

                int Totrencount1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "REN_COUNT"));
                Totrencount = Totrencount1 + Totrencount;

                decimal Totcfeamount1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CFE_AMOUNT"));
                Totcfeamount = Totcfeamount + Totcfeamount1;

                decimal Totcfoamount1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CFO_AMOUNT"));
                Totcfoamount = Totcfoamount + Totcfoamount1;

                decimal Totrenamount1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "REN_AMOUNT"));
                Totrenamount = Totrenamount + Totrenamount1;

                string Dist = lblDistId.Text.ToString();

                hypCFE_COUNT.NavigateUrl = "TourismApprovalsDtldReport.aspx?Dist="+ Dist+ "&fdt="+ FD+ "&tdt="+ TD+ "&Type=CFE";
                hypCFE_AMOUNT.NavigateUrl = "TourismApprovalsDtldReport.aspx?Dist=" + Dist + "&fdt=" + FD + "&tdt=" + TD + "&Type=CFE";

                hypCFO_AMOUNT.NavigateUrl = "TourismApprovalsDtldReport.aspx?Dist=" + Dist + "&fdt=" + FD + "&tdt=" + TD + "&Type=CFO";
                hypCFO_COUNT.NavigateUrl = "TourismApprovalsDtldReport.aspx?Dist=" + Dist + "&fdt=" + FD + "&tdt=" + TD + "&Type=CFO";

                hypREN_COUNT.NavigateUrl = "TourismApprovalsDtldReport.aspx?Dist=" + Dist + "&fdt=" + FD + "&tdt=" + TD + "&Type=REN";
                hypREN_AMOUNT.NavigateUrl = "TourismApprovalsDtldReport.aspx?Dist=" + Dist + "&fdt=" + FD + "&tdt=" + TD + "&Type=REN";
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "Total ";
                e.Row.Cells[2].Text = Totcfecount.ToString();
                e.Row.Cells[3].Text = Totcfeamount.ToString();
                e.Row.Cells[4].Text = Totcfocount.ToString();
                e.Row.Cells[5].Text = Totcfoamount.ToString();
                e.Row.Cells[6].Text = Totrencount.ToString();
                e.Row.Cells[7].Text = Totrenamount.ToString();

                e.Row.Cells[1].Style.Add("text-align", "right");

                HyperLink h1 = new HyperLink();
                h1.Text = Totcfecount.ToString();
                if (h1.Text != "0" && h1.Text != "0.00")
                {
                    h1.NavigateUrl = "TourismApprovalsDtldReport.aspx?Dist=All&fdt=" + FD + "&tdt=" + TD + "&Type=CFE";
                    e.Row.Cells[2].Controls.Add(h1);
                }
                HyperLink h2 = new HyperLink();
                h2.Text = Totcfeamount.ToString();
                if (h2.Text != "0" && h2.Text != "0.00")
                {
                    h2.NavigateUrl = "TourismApprovalsDtldReport.aspx?Dist=All&fdt=" + FD + "&tdt=" + TD + "&Type=CFE";
                    e.Row.Cells[3].Controls.Add(h2);
                }
                HyperLink h3 = new HyperLink();
                h3.Text = Totcfocount.ToString();
                if (h3.Text != "0" && h3.Text != "0.00")
                {
                    h3.NavigateUrl = "TourismApprovalsDtldReport.aspx?Dist=All&fdt=" + FD + "&tdt=" + TD + "&Type=CFO";
                    e.Row.Cells[4].Controls.Add(h3);
                }
                HyperLink h4 = new HyperLink();
                h4.Text = Totcfoamount.ToString();
                if (h4.Text != "0" && h4.Text != "0.00")
                {
                    h4.NavigateUrl = "TourismApprovalsDtldReport.aspx?Dist=All&fdt=" + FD + "&tdt=" + TD + "&Type=CFO";
                    e.Row.Cells[5].Controls.Add(h4);
                }
                HyperLink h5 = new HyperLink();
                h5.Text = Totrencount.ToString();
                if (h5.Text != "0" && h5.Text != "0.00")
                {
                    h5.NavigateUrl = "TourismApprovalsDtldReport.aspx?Dist=All&fdt=" + FD + "&tdt=" + TD + "&Type=REN";
                    e.Row.Cells[6].Controls.Add(h5);
                }
                HyperLink h6 = new HyperLink();
                h6.Text = Totrenamount.ToString();
                if (h6.Text != "0" && h6.Text != "0.00")
                {
                    h6.NavigateUrl = "TourismApprovalsDtldReport.aspx?Dist=All&fdt=" + FD + "&tdt=" + TD + "&Type=REN";
                    e.Row.Cells[7].Controls.Add(h6);
                }
            }
        }
        catch (Exception ex)
        {
            
        }
    }

    protected void gvApprovals_RowCreated(object sender, GridViewRowEventArgs e)
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
            HeaderCell.Text = "CFE";
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableHeaderCell();
            HeaderCell.ColumnSpan = 2;
            HeaderCell.RowSpan = 1;
            HeaderCell.Font.Bold = true;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "CFO";
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableHeaderCell();
            HeaderCell.ColumnSpan = 2;
            HeaderCell.RowSpan = 1;
            HeaderCell.Font.Bold = true;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "RENEWALS";
            HeaderGridRow.Cells.Add(HeaderCell);

            gvApprovals.Controls[0].Controls.AddAt(0, HeaderGridRow);
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
            string FileName = "Tourism Approvals";
            string Heading = header.InnerHtml.ToString();
            FileName = FileName.Replace(" ", "");
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName + "_" + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvApprovals.RenderControl(hw);

                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='8'><h4>" + Heading + "</h4></td></td></tr><tr><td align='center' colspan='6'></td></td></tr></table>";
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

                    gvApprovals.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    gvApprovals.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                    gvApprovals.FooterRow.ForeColor = System.Drawing.Color.Black;
                    gvApprovals.FooterStyle.ForeColor = System.Drawing.Color.Black;


                    gvApprovals.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    string FileName = "Tourism Approvals";
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