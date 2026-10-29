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


public partial class UI_TSiPASS_TourismEventReport : System.Web.UI.Page
{
    General Gen = new General();
    int TOURSM_EXB_MART_COUNT, PROD_EXB_COUNT, MICE_COUNT, CRAFTS_COUNT, MUSIC_COUNT, CHILDERN_COUNT, OTHERS_COUNT;
    decimal TOURSM_EXB_MART_AMOUNT, PROD_EXB_AMOUNT, MICE_AMOUNT, CRAFTS_AMOUNT, MUSIC_AMOUNT, CHILDERN_AMOUNT, OTHERS_AMOUNT;
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
            ds = Gen.GetTourismEventsAbstract(Session["uid"].ToString(), Fromdate, Todate);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvTourism.DataSource = ds.Tables[0];
                gvTourism.DataBind();
            }
            else
            {
                gvTourism.DataSource = null;
                gvTourism.DataBind();
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void gvTourism_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            string FD = txtFromDate.Text;
            string TD = txtTodate.Text;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblDistId = (Label)e.Row.FindControl("lblDistId");
                HyperLink hypTOURSM_EXB_MART_COUNT = (HyperLink)e.Row.FindControl("hypTOURSM_EXB_MART_COUNT");
                HyperLink hypTOURSM_EXB_MART_AMOUNT = (HyperLink)e.Row.FindControl("hypTOURSM_EXB_MART_AMOUNT");
                HyperLink hypPROD_EXB_COUNT = (HyperLink)e.Row.FindControl("hypPROD_EXB_COUNT");
                HyperLink hypPROD_EXB_AMOUNT = (HyperLink)e.Row.FindControl("hypPROD_EXB_AMOUNT");
                HyperLink hypMICE_COUNT = (HyperLink)e.Row.FindControl("hypMICE_COUNT");
                HyperLink hypMICE_AMOUNT = (HyperLink)e.Row.FindControl("hypMICE_AMOUNT");
                HyperLink hypCRAFTS_COUNT = (HyperLink)e.Row.FindControl("hypCRAFTS_COUNT");
                HyperLink hypCRAFTS_AMOUNT = (HyperLink)e.Row.FindControl("hypCRAFTS_AMOUNT");
                HyperLink hypMUSIC_COUNT = (HyperLink)e.Row.FindControl("hypMUSIC_COUNT");
                HyperLink hypMUSIC_AMOUNT = (HyperLink)e.Row.FindControl("hypMUSIC_AMOUNT");
                HyperLink hypCHILDERN_COUNT = (HyperLink)e.Row.FindControl("hypCHILDERN_COUNT");
                HyperLink hypCHILDERN_AMOUNT = (HyperLink)e.Row.FindControl("hypCHILDERN_AMOUNT");
                HyperLink hypOTHERS_COUNT = (HyperLink)e.Row.FindControl("hypOTHERS_COUNT");
                HyperLink hypOTHERS_AMOUNT = (HyperLink)e.Row.FindControl("hypOTHERS_AMOUNT");

                int TOURSM_EXB_MART_COUNT1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TOURSM_EXB_MART_COUNT"));
                TOURSM_EXB_MART_COUNT = TOURSM_EXB_MART_COUNT1 + TOURSM_EXB_MART_COUNT;

                int PROD_EXB_COUNT1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PROD_EXB_COUNT"));
                PROD_EXB_COUNT = PROD_EXB_COUNT + PROD_EXB_COUNT1;

                int MICE_COUNT1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "MICE_COUNT"));
                MICE_COUNT = MICE_COUNT1 + MICE_COUNT;

                int CRAFTS_COUNT1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CRAFTS_COUNT"));
                CRAFTS_COUNT = CRAFTS_COUNT1 + CRAFTS_COUNT;

                int MUSIC_COUNT1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "MUSIC_COUNT"));
                MUSIC_COUNT = MUSIC_COUNT + MUSIC_COUNT1;

                int CHILDERN_COUNT1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CHILDERN_COUNT"));
                CHILDERN_COUNT = CHILDERN_COUNT1 + CHILDERN_COUNT;

                int OTHERS_COUNT1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "OTHERS_COUNT"));
                OTHERS_COUNT = OTHERS_COUNT1 + OTHERS_COUNT;

               
                decimal TOURSM_EXB_MART_AMOUNT1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TOURSM_EXB_MART_AMOUNT"));
                TOURSM_EXB_MART_AMOUNT = TOURSM_EXB_MART_AMOUNT + TOURSM_EXB_MART_AMOUNT1;

                decimal PROD_EXB_AMOUNT1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PROD_EXB_AMOUNT"));
                PROD_EXB_AMOUNT = PROD_EXB_AMOUNT + PROD_EXB_AMOUNT1;

                decimal MICE_AMOUNT1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MICE_AMOUNT"));
                MICE_AMOUNT = MICE_AMOUNT + MICE_AMOUNT1;

                decimal CRAFTS_AMOUNT1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CRAFTS_AMOUNT"));
                CRAFTS_AMOUNT = CRAFTS_AMOUNT + CRAFTS_AMOUNT1;

                decimal MUSIC_AMOUNT1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MUSIC_AMOUNT"));
                MUSIC_AMOUNT = MUSIC_AMOUNT + MUSIC_AMOUNT1;

                decimal CHILDERN_AMOUNT1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CHILDERN_AMOUNT"));
                CHILDERN_AMOUNT = CHILDERN_AMOUNT + CHILDERN_AMOUNT1;

                decimal OTHERS_AMOUNT1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "OTHERS_AMOUNT"));
                OTHERS_AMOUNT = OTHERS_AMOUNT + OTHERS_AMOUNT1;

                string Dist = lblDistId.Text.ToString();

                hypTOURSM_EXB_MART_COUNT.NavigateUrl = "TourismEventDtldReport.aspx?Dist=" + Dist + "&fdt=" + FD + "&tdt=" + TD + "&Type=1";
                hypTOURSM_EXB_MART_AMOUNT.NavigateUrl = "TourismEventDtldReport.aspx?Dist=" + Dist + "&fdt=" + FD + "&tdt=" + TD + "&Type=1";
                hypPROD_EXB_COUNT.NavigateUrl = "TourismEventDtldReport.aspx?Dist=" + Dist + "&fdt=" + FD + "&tdt=" + TD + "&Type=2";
                hypPROD_EXB_AMOUNT.NavigateUrl = "TourismEventDtldReport.aspx?Dist=" + Dist + "&fdt=" + FD + "&tdt=" + TD + "&Type=2";
                hypMICE_COUNT.NavigateUrl = "TourismEventDtldReport.aspx?Dist=" + Dist + "&fdt=" + FD + "&tdt=" + TD + "&Type=3";
                hypMICE_AMOUNT.NavigateUrl = "TourismEventDtldReport.aspx?Dist=" + Dist + "&fdt=" + FD + "&tdt=" + TD + "&Type=3";
                hypCRAFTS_COUNT.NavigateUrl = "TourismEventDtldReport.aspx?Dist=" + Dist + "&fdt=" + FD + "&tdt=" + TD + "&Type=4";
                hypCRAFTS_AMOUNT.NavigateUrl = "TourismEventDtldReport.aspx?Dist=" + Dist + "&fdt=" + FD + "&tdt=" + TD + "&Type=4";
                hypMUSIC_COUNT.NavigateUrl = "TourismEventDtldReport.aspx?Dist=" + Dist + "&fdt=" + FD + "&tdt=" + TD + "&Type=5";
                hypMUSIC_AMOUNT.NavigateUrl = "TourismEventDtldReport.aspx?Dist=" + Dist + "&fdt=" + FD + "&tdt=" + TD + "&Type=5";
                hypCHILDERN_COUNT.NavigateUrl = "TourismEventDtldReport.aspx?Dist=" + Dist + "&fdt=" + FD + "&tdt=" + TD + "&Type=6";
                hypCHILDERN_AMOUNT.NavigateUrl = "TourismEventDtldReport.aspx?Dist=" + Dist + "&fdt=" + FD + "&tdt=" + TD + "&Type=6";
                hypOTHERS_COUNT.NavigateUrl = "TourismEventDtldReport.aspx?Dist=" + Dist + "&fdt=" + FD + "&tdt=" + TD + "&Type=7";
                hypOTHERS_AMOUNT.NavigateUrl = "TourismEventDtldReport.aspx?Dist=" + Dist + "&fdt=" + FD + "&tdt=" + TD + "&Type=7";

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "Total ";
                e.Row.Cells[2].Text = TOURSM_EXB_MART_COUNT.ToString();
                e.Row.Cells[3].Text = TOURSM_EXB_MART_AMOUNT.ToString();
                e.Row.Cells[4].Text = PROD_EXB_COUNT.ToString();
                e.Row.Cells[5].Text = PROD_EXB_AMOUNT.ToString();
                e.Row.Cells[6].Text = MICE_COUNT.ToString();
                e.Row.Cells[7].Text = MICE_AMOUNT.ToString();
                e.Row.Cells[8].Text = CRAFTS_COUNT.ToString();
                e.Row.Cells[9].Text = CRAFTS_AMOUNT.ToString();
                e.Row.Cells[10].Text = MUSIC_COUNT.ToString();
                e.Row.Cells[11].Text = MUSIC_AMOUNT.ToString();
                e.Row.Cells[12].Text = CHILDERN_COUNT.ToString();
                e.Row.Cells[13].Text = CHILDERN_AMOUNT.ToString();
                e.Row.Cells[14].Text = OTHERS_COUNT.ToString();
                e.Row.Cells[15].Text = OTHERS_AMOUNT.ToString();

                e.Row.Cells[1].Style.Add("text-align", "right");

                HyperLink h1 = new HyperLink();
                h1.Text = TOURSM_EXB_MART_COUNT.ToString();
                if (h1.Text != "0" && h1.Text != "0.00")
                {
                    h1.NavigateUrl = "TourismEventDtldReport.aspx?Dist=All&fdt=" + FD + "&tdt=" + TD + "&Type=1";
                    e.Row.Cells[2].Controls.Add(h1);
                }
                HyperLink h2 = new HyperLink();
                h2.Text = TOURSM_EXB_MART_AMOUNT.ToString();
                if (h2.Text != "0" && h2.Text != "0.00")
                {
                    h2.NavigateUrl = "TourismEventDtldReport.aspx?Dist=All&fdt=" + FD + "&tdt=" + TD + "&Type=1";
                    e.Row.Cells[3].Controls.Add(h2);
                }
                HyperLink h3 = new HyperLink();
                h3.Text = PROD_EXB_COUNT.ToString();
                if (h3.Text != "0" && h3.Text != "0.00")
                {
                    h3.NavigateUrl = "TourismEventDtldReport.aspx?Dist=All&fdt=" + FD + "&tdt=" + TD + "&Type=2";
                    e.Row.Cells[4].Controls.Add(h3);
                }
                HyperLink h4 = new HyperLink();
                h4.Text = PROD_EXB_AMOUNT.ToString();
                if (h4.Text != "0" && h4.Text != "0.00")
                {
                    h4.NavigateUrl = "TourismEventDtldReport.aspx?Dist=All&fdt=" + FD + "&tdt=" + TD + "&Type=2";
                    e.Row.Cells[5].Controls.Add(h4);
                }
                HyperLink h5 = new HyperLink();
                h5.Text = MICE_COUNT.ToString();
                if (h5.Text != "0" && h5.Text != "0.00")
                {
                    h5.NavigateUrl = "TourismEventDtldReport.aspx?Dist=All&fdt=" + FD + "&tdt=" + TD + "&Type=3";
                    e.Row.Cells[6].Controls.Add(h5);
                }
                HyperLink h6 = new HyperLink();
                h6.Text = MICE_AMOUNT.ToString();
                if (h6.Text != "0" && h6.Text != "0.00")
                {
                    h1.NavigateUrl = "TourismEventDtldReport.aspx?Dist=All&fdt=" + FD + "&tdt=" + TD + "&Type=3";
                    e.Row.Cells[7].Controls.Add(h6);
                }
                HyperLink h7 = new HyperLink();
                h7.Text = CRAFTS_COUNT.ToString();
                if (h7.Text != "0" && h7.Text != "0.00")
                {
                    h7.NavigateUrl = "TourismEventDtldReport.aspx?Dist=All&fdt=" + FD + "&tdt=" + TD + "&Type=4";
                    e.Row.Cells[8].Controls.Add(h7);
                }
                HyperLink h8 = new HyperLink();
                h8.Text = CRAFTS_AMOUNT.ToString();
                if (h8.Text != "0" && h8.Text != "0.00")
                {
                    h8.NavigateUrl = "TourismEventDtldReport.aspx?Dist=All&fdt=" + FD + "&tdt=" + TD + "&Type=4";
                    e.Row.Cells[9].Controls.Add(h8);
                }
                HyperLink h9 = new HyperLink();
                h9.Text = MUSIC_COUNT.ToString();
                if (h9.Text != "0" && h9.Text != "0.00")
                {
                    h9.NavigateUrl = "TourismEventDtldReport.aspx?Dist=All&fdt=" + FD + "&tdt=" + TD + "&Type=5";
                    e.Row.Cells[10].Controls.Add(h9);
                }
                HyperLink h10 = new HyperLink();
                h10.Text = MUSIC_AMOUNT.ToString();
                if (h10.Text != "0" && h10.Text != "0.00")
                {
                    h10.NavigateUrl = "TourismEventDtldReport.aspx?Dist=All&fdt=" + FD + "&tdt=" + TD + "&Type=5";
                    e.Row.Cells[11].Controls.Add(h10);
                }
                HyperLink h11 = new HyperLink();
                h11.Text = CHILDERN_COUNT.ToString();
                if (h11.Text != "0" && h11.Text != "0.00")
                {
                    h11.NavigateUrl = "TourismEventDtldReport.aspx?Dist=All&fdt=" + FD + "&tdt=" + TD + "&Type=6";
                    e.Row.Cells[12].Controls.Add(h11);
                }
                HyperLink h12 = new HyperLink();
                h12.Text = CHILDERN_AMOUNT.ToString();
                if (h12.Text != "0" && h12.Text != "0.00")
                {
                    h12.NavigateUrl = "TourismEventDtldReport.aspx?Dist=All&fdt=" + FD + "&tdt=" + TD + "&Type=6";
                    e.Row.Cells[13].Controls.Add(h12);
                }
                HyperLink h13 = new HyperLink();
                h13.Text = OTHERS_COUNT.ToString();
                if (h13.Text != "0" && h13.Text != "0.00")
                {
                    h13.NavigateUrl = "TourismEventDtldReport.aspx?Dist=All&fdt=" + FD + "&tdt=" + TD + "&Type=7";
                    e.Row.Cells[14].Controls.Add(h13);
                }
                HyperLink h14 = new HyperLink();
                h14.Text = OTHERS_AMOUNT.ToString();
                if (h14.Text != "0" && h14.Text != "0.00")
                {
                    h14.NavigateUrl = "TourismEventDtldReport.aspx?Dist=All&fdt=" + FD + "&tdt=" + TD + "&Type=7";
                    e.Row.Cells[15].Controls.Add(h14);
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void gvTourism_RowCreated(object sender, GridViewRowEventArgs e)
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
            HeaderCell.Text = "Tourism Exhibition/Marts";
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableHeaderCell();
            HeaderCell.ColumnSpan = 2;
            HeaderCell.RowSpan = 1;
            HeaderCell.Font.Bold = true;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "Product Exhibition";
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableHeaderCell();
            HeaderCell.ColumnSpan = 2;
            HeaderCell.RowSpan = 1;
            HeaderCell.Font.Bold = true;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "MICE event";
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableHeaderCell();
            HeaderCell.ColumnSpan = 2;
            HeaderCell.RowSpan = 1;
            HeaderCell.Font.Bold = true;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "Crafts Festival/Exhibition";
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableHeaderCell();
            HeaderCell.ColumnSpan = 2;
            HeaderCell.RowSpan = 1;
            HeaderCell.Font.Bold = true;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "Music festival";
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableHeaderCell();
            HeaderCell.ColumnSpan = 2;
            HeaderCell.RowSpan = 1;
            HeaderCell.Font.Bold = true;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "Children’s festival and fun fest";
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableHeaderCell();
            HeaderCell.ColumnSpan = 2;
            HeaderCell.RowSpan = 1;
            HeaderCell.Font.Bold = true;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "Others";
            HeaderGridRow.Cells.Add(HeaderCell);

            gvTourism.Controls[0].Controls.AddAt(0, HeaderGridRow);
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
            string FileName = "Tourism Events";
            string Heading = header.InnerHtml.ToString();
            FileName = FileName.Replace(" ", "");
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName + "_" + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvTourism.RenderControl(hw);

                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='16'><h4>" + Heading + "</h4></td></td></tr><tr><td align='center' colspan='6'></td></td></tr></table>";
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

                    gvTourism.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    gvTourism.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                    gvTourism.FooterRow.ForeColor = System.Drawing.Color.Black;
                    gvTourism.FooterStyle.ForeColor = System.Drawing.Color.Black;


                    gvTourism.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    string FileName = "Tourism Events";
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