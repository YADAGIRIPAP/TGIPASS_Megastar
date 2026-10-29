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
using System.Data.SqlClient;

public partial class UI_TSiPASS_frmCFOFinancialYear : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    decimal NumberTotal, InvestmnetTotal, EmploymentTotal, manumicro, manusmall, manumedium, manularge, manumega, sersmall, sermicro, sermedium, serlarge, sermega;
    #region Declaration
    General gen = new General();
    General Gen = new General();
    int Sno = 0;

    DataSet ds;
    DataTable dt;


    DataSet dslist;


    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Label3.Text = "Report as on date " + DateTime.Now;

            FillGridDetails();
        }
    }
    #endregion


    protected void BtnClear_Click(object sender, EventArgs e)
    {
        //  ddldistrict.SelectedIndex = 0;
        //  txtRegDate.Text = "";
        //  ddlCategory.SelectedIndex = 0;

    }
    public void FillGridDetails()
    {

        ds = GetPublicViewReport();
        if (ds.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            Label1.Text = "No Records Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
    }


    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal NumberTotal1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total Application received"));
            NumberTotal = NumberTotal1 + NumberTotal;

            decimal InvestmnetTotal1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total Investments"));
            InvestmnetTotal = InvestmnetTotal1 + InvestmnetTotal;


            decimal EmploymentTotal1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total Empolyment"));
            EmploymentTotal = EmploymentTotal1 + EmploymentTotal;

            decimal manumicro1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ManufacturingMicro"));
            manumicro = manumicro1 + manumicro;

            decimal manusmall1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ManufacturingSmall"));
            manusmall = manusmall1 + manusmall;

            decimal manumedium1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ManufacturingMedium"));
            manumedium = manumedium1 + manumedium;

            decimal manularge1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ManufacturingLarge"));
            manularge = manularge1 + manularge;

            decimal manumega1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ManufacturingMega"));
            manumega = manumega1 + manumega;

            decimal sermicro1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ServiceMicro"));
            sermicro = sermicro1 + sermicro;

            decimal sersmall1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ServiceSmall"));
            sersmall = sersmall1 + sersmall;

            decimal sermedium1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ServiceMedium"));
            sermedium = sermedium1 + sermedium;

            decimal serlarge1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ServiceLarge"));
            serlarge = serlarge1 + serlarge;

            decimal sermega1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ServiceMega"));
            sermega = sermega1 + sermega;

            HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
            h1.NavigateUrl = "frmCFOFinancialYearDrill.aspx?status=A&FinancialYear="+Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FinYearCD")).Trim();

            HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
            h2.NavigateUrl = "frmCFOFinancialYearDrill.aspx?status=A&FinancialYear=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FinYearCD")).Trim();

            HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
            h3.NavigateUrl = "frmCFOFinancialYearDrill.aspx?status=A&FinancialYear=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FinYearCD")).Trim();

            HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
            h4.NavigateUrl = "frmCFOFinancialYearDrill.aspx?status=D&FinancialYear=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FinYearCD")).Trim();

            HyperLink h5 = (HyperLink)e.Row.Cells[6].Controls[0];
            h5.NavigateUrl = "frmCFOFinancialYearDrill.aspx?status=E&FinancialYear=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FinYearCD")).Trim();

            HyperLink h6 = (HyperLink)e.Row.Cells[7].Controls[0];
            h6.NavigateUrl = "frmCFOFinancialYearDrill.aspx?status=F&FinancialYear=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FinYearCD")).Trim();

            HyperLink h7 = (HyperLink)e.Row.Cells[8].Controls[0];
            h7.NavigateUrl = "frmCFOFinancialYearDrill.aspx?status=G&FinancialYear=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FinYearCD")).Trim();

            HyperLink h8 = (HyperLink)e.Row.Cells[9].Controls[0];
            h8.NavigateUrl = "frmCFOFinancialYearDrill.aspx?status=H&FinancialYear=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FinYearCD")).Trim();

            HyperLink h9 = (HyperLink)e.Row.Cells[10].Controls[0];
            h9.NavigateUrl = "frmCFOFinancialYearDrill.aspx?status=I&FinancialYear=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FinYearCD")).Trim();

            HyperLink h10 = (HyperLink)e.Row.Cells[11].Controls[0];
            h10.NavigateUrl = "frmCFOFinancialYearDrill.aspx?status=J&FinancialYear=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FinYearCD")).Trim();

            HyperLink h11 = (HyperLink)e.Row.Cells[12].Controls[0];
            h11.NavigateUrl = "frmCFOFinancialYearDrill.aspx?status=K&FinancialYear=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FinYearCD")).Trim();

            HyperLink h12 = (HyperLink)e.Row.Cells[13].Controls[0];
            h12.NavigateUrl = "frmCFOFinancialYearDrill.aspx?status=L&FinancialYear=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FinYearCD")).Trim();

            HyperLink h13 = (HyperLink)e.Row.Cells[14].Controls[0];
            h13.NavigateUrl = "frmCFOFinancialYearDrill.aspx?status=M&FinancialYear=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FinYearCD")).Trim();
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total";
            e.Row.Cells[2].Text = NumberTotal.ToString();
            e.Row.Cells[3].Text = InvestmnetTotal.ToString();
            e.Row.Cells[4].Text = EmploymentTotal.ToString();

            e.Row.Cells[5].Text = manumicro.ToString();
            e.Row.Cells[6].Text = manusmall.ToString();
            e.Row.Cells[7].Text = manumedium.ToString();
            e.Row.Cells[8].Text = manularge.ToString();
            e.Row.Cells[9].Text = manumega.ToString();

            e.Row.Cells[10].Text = sermicro.ToString();
            e.Row.Cells[11].Text = sersmall.ToString();
            e.Row.Cells[12].Text = sermedium.ToString();
            e.Row.Cells[13].Text = serlarge.ToString();
            e.Row.Cells[14].Text = sermega.ToString();
        }
    }

    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow gvHeaderRow = e.Row;
            GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            this.grdDetails.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

            int headerCellCount = gvHeaderRow.Cells.Count;
            int cellIndex = 0;

            for (int i = 0; i < headerCellCount; i++)
            {
                if (i == 5 || i == 6 || i == 7 || i == 8 || i == 9 || i == 10 || i == 11 || i == 12 || i == 13 || i == 14 || i == 15)
                {
                    cellIndex++;
                }
                else
                {
                    TableCell tcHeader = gvHeaderRow.Cells[cellIndex];
                    tcHeader.RowSpan = 2;
                    gvHeaderRowCopy.Cells.Add(tcHeader);
                }
            }

            TableCell tcMergePackage = new TableCell();
            tcMergePackage.Text = "Service";
            tcMergePackage.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage.ColumnSpan = 5;
            gvHeaderRowCopy.Cells.AddAt(5, tcMergePackage);

            TableCell tcMergePackage1 = new TableCell();
            tcMergePackage1.Text = "Manufacturing";
            tcMergePackage1.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage1.ColumnSpan = 5;
            gvHeaderRowCopy.Cells.AddAt(5, tcMergePackage1);

        }
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
            Response.AddHeader("content-disposition", "attachment;filename=R1.1Abstract-FinancialYearwise" + DateTime.Now.ToString("MM-dd-yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                div_Print.RenderControl(hw);

                string label1text = Label1.Text;
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='6'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='6'><h4>" + label1text + "</h4></td></td></tr></table>";
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
                    //To Export all pages
                    //trLogo.Visible = true;
                    grdDetails.AllowPaging = false;
                    //this.FillGridDetails(rbtnlstInputType.SelectedValue.ToString().Trim(), ddlFinancialYear.SelectedValue.ToString().Trim(), FromdateforDB, TodateforDB);
                    grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.FooterRow.Visible = false;
                    grdDetails.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename= R6.CFO Abstract-FinancialYearwise" + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
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


    protected void btnbdf_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        //  ds = (DataSet)Session["dtdataset"];

        // DataRow dr = GetData("SELECT * FROM Employees where EmployeeId = " + ddlEmployees.SelectedItem.Value).Rows[0]; ;
        // Document document = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
        Document document = new Document(PageSize.A4.Rotate(), 20f, 20f, 20f, 50f);
        Font NormalFont = FontFactory.GetFont("trebuchet ms", 12, Font.NORMAL, Color.BLACK);

        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
        {
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

            Phrase phrase = null;
            PdfPCell cell = null;
            PdfPTable table = null;
            PdfPTable tablenew = null;
            Color color = null;

            document.Open();
            writer.PageEvent = new Footer();
            //Header Table
            PdfContentByte contentBytenew = writer.DirectContent;
            table = new PdfPTable(3);
            table.TotalWidth = document.PageSize.Width - 60f;
            table.SetWidths(new float[] { 0.1f, 0.8f, 0.1f });
            table.LockedWidth = true;


            cell = ImageCell("~/images/ipasslogopsr.png", 20f, PdfPCell.ALIGN_LEFT);
            cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            table.AddCell(cell);


            phrase = new Phrase();
            phrase.Add(new Chunk("Telangana State Industrial Project Approval &	Self- Certification System (TS-iPASS)\n\n", FontFactory.GetFont("trebuchet ms", 14, Font.BOLD, Color.BLACK)));
            phrase.Add(new Chunk("government of telangana".ToUpper(), FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));

            cell = PhraseCell(phrase, PdfPCell.ALIGN_CENTER);
            cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            // cell.PaddingBottom = 30f;
            table.AddCell(cell);

            cell = ImageCell("~/images/logoTG.gif", 20f, PdfPCell.ALIGN_RIGHT);
            cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            table.AddCell(cell);

            //------------------------------------------------------------------------------------------------------------------------------------------------------
            string strDuration = "";
            string FromdateforDB = "", TodateforDB = "", monthName = "", monthName1 = "";
            string FromdateforDB1 = "", TodateforDB1 = "";
            int monthday1 = 0, monthday2 = 0;
            //  txtFromDate = Session["FromdateforDB"].ToString();



            strDuration = DisplayWithSuffix(monthday1) + " " + monthName + " " + FromdateforDB1 + " to " + DisplayWithSuffix(monthday2) + " " + monthName1 + " " + TodateforDB1;
            // string fullMonthName = new DateTime( FromdateforDB).ToString("MMMM", System.Globalization.CultureInfo.CreateSpecificCulture("es"));

            string tcMergePackage = ""; //"Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
            //------------------------------------------------------------------------------------------------------------------------------------------------------
            phrase = new Phrase();
            phrase.Add(new Chunk("R6. TS-iPASS CFO Abstract -Financial Year Wise \n\n", FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));
            phrase.Add(new Chunk(tcMergePackage, FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
            cell.VerticalAlignment = PdfCell.ALIGN_CENTER;
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            cell.Colspan = 3;
            cell.PaddingTop = 20f;
            cell.PaddingBottom = 0f;
            table.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk("Report Generated On :" + DateTime.Now.ToString("dd/MM/yyyy"), FontFactory.GetFont("trebuchet ms", 12, Font.NORMAL, Color.BLACK)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = PdfCell.ALIGN_RIGHT;
            cell.Colspan = 3;
            cell.PaddingTop = 10f;
            cell.PaddingBottom = 0f;
            table.AddCell(cell);

            document.Add(table);

            color = new Color(6, 170, 26);
            DrawLineMiddleline(writer, 2f, document.Top - 60f, document.PageSize.Width - 2f, document.Top - 60f, color);

            int CountColumns = 0;

            foreach (DataControlFieldCell cellnew in grdDetails.Rows[0].Cells)
            {
                if (cellnew.Visible == true)
                {
                    CountColumns += 1;
                }
            }

            //CountColumns = grdDetails.Columns.Count;

            tablenew = new PdfPTable(CountColumns);
            //  tablenew.SetWidths(new float[] { 0.15f, 0.05f, 0.70f, 0.25f });
            float[] terms = new float[CountColumns];
            for (int runs = 0; runs < CountColumns; runs++)
            {
                if (runs == 0)
                {
                    terms[runs] = 4f;
                }
                else if (runs == 1)
                {
                    terms[runs] = 10f;
                }
                else
                {
                    double valus = 75 / CountColumns;
                    terms[runs] = (float)valus;
                }
            }
            tablenew.SetWidths(terms);
            tablenew.TotalWidth = document.PageSize.Width - 60f;

            tablenew.LockedWidth = true;
            tablenew.SpacingBefore = 5f;
            tablenew.HorizontalAlignment = Element.ALIGN_MIDDLE;
            // CountColumns = grdDetails.Columns.Count;

            string cellTextnew = "";
            phrase = new Phrase();
            phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails.HeaderStyle.BackColor);  //#009688
            cell.PaddingBottom = 5;
            cell.Colspan = 5;
            cell.MinimumHeight = 30f;
            tablenew.AddCell(cell);

            phrase = new Phrase();
            cellTextnew = "Manufacturing";
            phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails.HeaderStyle.BackColor);  //#009688
            cell.PaddingBottom = 5;
            cell.Colspan = 5;
            cell.MinimumHeight = 30f;
            tablenew.AddCell(cell);

            phrase = new Phrase();
            cellTextnew = "Service";
            phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails.HeaderStyle.BackColor);  //#009688
            cell.PaddingBottom = 5;
            cell.Colspan = 5;
            cell.MinimumHeight = 30f;
            tablenew.AddCell(cell);



            for (int i = 0; i < CountColumns; i++)
            {
                string cellText = "";

                cellText = Server.HtmlDecode(grdDetails.Columns[i].HeaderText);

                phrase = new Phrase();
                phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails.HeaderStyle.BackColor);  //#009688
                cell.PaddingBottom = 5;
                cell.MinimumHeight = 30f;
                tablenew.AddCell(cell);
            }

            for (int i = 0; i < grdDetails.Rows.Count; i++)
            {
                if (grdDetails.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    for (int j = 0; j < CountColumns; j++)
                    {
                        string cellText = "";
                        HyperLink h4 = null;
                        phrase = new Phrase();

                        if (j == 0)
                        {
                            cellText = (i + 1).ToString();
                        }
                        //else if (j == 1)
                        //{
                        //    cellText = Server.HtmlDecode(grdDetails.Rows[i].Cells[j].Text);
                        //}
                        else
                        {
                            if (grdDetails.Rows[i].Cells[j].Controls[0].Visible == true)
                            {
                                h4 = (HyperLink)grdDetails.Rows[i].Cells[j].Controls[0];
                                cellText = h4.Text;
                            }
                            else
                                continue;
                        }
                        cellText = Server.HtmlDecode(cellText);

                        // h4 = (HyperLink)grdDetails.Rows[i].Controls[j];
                        if (j == 0 && (cellText == "CFE - Total" || cellText == "CFO - Total" || cellText == "CFE + CFO TOTAL" || cellText == "GRAND TOTAL"))
                        {
                            cellText = "";
                            phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.BOLD, Color.BLACK)));
                        }
                        else
                        {
                            string cellTextnew1 = Server.HtmlDecode(grdDetails.Rows[i].Cells[1].Text);
                            if ((cellTextnew1 == "CFE - Total" || cellTextnew1 == "CFO - Total" || cellTextnew1 == "CFE + CFO TOTAL" || cellTextnew1 == "GRAND TOTAL"))
                            {
                                phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.BOLD, Color.BLACK)));
                            }
                            else
                            {
                                phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.BLACK)));
                            }
                        }


                        if (j == 0)
                        {
                            cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        }
                        else if (j == 1)
                        {
                            cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                        }
                        else
                        {
                            cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
                            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        }


                        //cell.Border = 2;
                        //cell.BorderColor = Color.BLACK;
                        if (grdDetails.Rows[i].RowState == DataControlRowState.Alternate)
                        {
                            cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA"));
                            cell.BorderWidthRight = 0.5f;
                            cell.BorderWidthLeft = 0.5f;
                            cell.BorderWidthTop = 0.5f;
                            cell.BorderWidthBottom = 0.5f;

                            cell.BorderColorBottom = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));  //#E5E5E5
                            cell.BorderColorTop = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));
                            cell.BorderColorLeft = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));
                            cell.BorderColorRight = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));
                        }
                        else
                        {
                            cell.BorderWidthRight = 0.5f;
                            cell.BorderWidthLeft = 0.5f;
                            cell.BorderWidthTop = 0.5f;
                            cell.BorderWidthBottom = 0.5f;

                            cell.BorderColorBottom = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));  //#E5E5E5
                            cell.BorderColorTop = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));
                            cell.BorderColorLeft = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));
                            cell.BorderColorRight = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));
                        }

                        //cell.BackgroundColor = Color.GRAY;

                        cell.PaddingBottom = 5;
                        cell.MinimumHeight = 30f;
                        tablenew.AddCell(cell);
                    }
                }
                var remainingPageSpace = writer.GetVerticalPosition(false) - document.BottomMargin;
                var initialPosition = writer.GetVerticalPosition(false);
                var tablehiht = tablenew.TotalHeight;

                if (remainingPageSpace >= tablehiht && remainingPageSpace - 40 <= tablehiht)
                {
                    contentBytenew.SetColorStroke(color);
                    contentBytenew.Circle(document.PageSize.Width - 23f, document.PageSize.Bottom + 23f, 10f);
                    contentBytenew.Stroke();

                    ColumnText.ShowTextAligned(contentBytenew, Element.ALIGN_RIGHT, new Phrase((writer.PageNumber).ToString(), FontFactory.GetFont("Trebuchet MS", 12, Font.BOLD, Color.BLACK)), document.PageSize.Width - 20f, document.PageSize.Bottom + 20f, 2);

                    document.Add(tablenew);
                    document.NewPage();
                    tablenew.DeleteBodyRows();

                    for (int k = 0; k < CountColumns; k++)
                    {
                        string cellText = "";

                        cellText = Server.HtmlDecode(grdDetails.Columns[k].HeaderText);

                        phrase = new Phrase();
                        phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
                        cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                        cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails.HeaderStyle.BackColor);  //#009688
                        cell.PaddingBottom = 5;
                        cell.MinimumHeight = 30f;
                        tablenew.AddCell(cell);
                    }
                }
            }
            for (int i = 0; i < CountColumns; i++)
            {
                string cellText = "";

                cellText = Server.HtmlDecode(grdDetails.FooterRow.Cells[i].Text);

                phrase = new Phrase();
                phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                if (i == 1)
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                else
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails.HeaderStyle.BackColor);  //#009688
                cell.PaddingBottom = 5;
                cell.MinimumHeight = 30f;
                tablenew.AddCell(cell);
            }
            document.Add(tablenew);

            contentBytenew.SetColorStroke(color);
            contentBytenew.Circle(document.PageSize.Width - 23f, document.PageSize.Bottom + 23f, 10f);
            contentBytenew.Stroke();
            ColumnText.ShowTextAligned(contentBytenew, Element.ALIGN_RIGHT, new Phrase((writer.PageNumber).ToString(), FontFactory.GetFont("Trebuchet MS", 12, Font.BOLD, Color.BLACK)), document.PageSize.Width - 20f, document.PageSize.Bottom + 20f, 2);




            document.Close();
            byte[] bytes = memoryStream.ToArray();
            memoryStream.Close();
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=R5.1_Department_wise_performance_Tracker" + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
            Response.ContentType = "application/pdf";



            Response.Buffer = true;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(bytes);
            Response.End();
            Response.Close();


        }
    }

    public partial class Footer : PdfPageEventHelper
    {
        //new Color(127, 127, 127)
        public override void OnEndPage(PdfWriter writer, Document doc)
        {
            Paragraph footer = new Paragraph(char.ConvertFromUtf32(169).ToString() + " Industry Chasing Cell.  Government of Telangana.", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD, Color.BLACK));
            footer.Alignment = Element.ALIGN_LEFT;
            PdfPTable footerTbl = new PdfPTable(1);
            footerTbl.TotalWidth = 500f;
            footerTbl.HorizontalAlignment = Element.ALIGN_LEFT;
            PdfPCell cell = new PdfPCell(footer);
            cell.Border = 0;
            cell.PaddingLeft = 10;
            footerTbl.AddCell(cell);
            footerTbl.WriteSelectedRows(0, -1, 30, 40, writer.DirectContent);
        }
    }
    private static void DrawLine(PdfWriter writer, float x1, float y1, float x2, float y2, Color color)
    {
        PdfContentByte contentByte = writer.DirectContent;
        contentByte.SetColorStroke(color);
        contentByte.MoveTo(x1, y1);
        contentByte.LineTo(x2, y2);
        contentByte.SetLineWidth(1f);
        contentByte.Stroke();
    }
    private static void DrawLineMiddleline(PdfWriter writer, float x1, float y1, float x2, float y2, Color color)
    {
        PdfContentByte contentByte = writer.DirectContent;
        contentByte.SetColorStroke(color);
        contentByte.MoveTo(x1, y1);
        contentByte.LineTo(x2, y2);
        contentByte.SetLineWidth(2f);
        contentByte.Stroke();
    }
    private static PdfPCell PhraseCell(Phrase phrase, int align)
    {
        PdfPCell cell = new PdfPCell(phrase);
        cell.BorderColor = Color.WHITE;
        cell.VerticalAlignment = PdfCell.ALIGN_TOP;
        cell.HorizontalAlignment = align;
        cell.PaddingBottom = 2f;
        cell.PaddingTop = 0f;
        return cell;
    }
    private static PdfPCell PhraseCellnew(Phrase phrase, int align)
    {
        PdfPCell cell = new PdfPCell(phrase);
        cell.BorderColor = Color.WHITE;
        cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
        cell.HorizontalAlignment = align;
        //cell.PaddingBottom = 5f;
        //cell.PaddingTop = 5f;
        cell.BorderWidthRight = 0.5f;
        cell.BorderWidthLeft = 0.5f;
        cell.BorderWidthTop = 0.5f;
        cell.BorderWidthBottom = 0.5f;
        cell.BorderColorBottom = Color.BLACK;
        cell.BorderColorTop = Color.BLACK;
        cell.BorderColorLeft = Color.BLACK;
        cell.BorderColorRight = Color.BLACK;
        cell.MinimumHeight = 30f;

        return cell;
    }
    private static PdfPCell ImageCell(string path, float scale, int align)
    {
        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));
        image.ScalePercent(scale);
        PdfPCell cell = new PdfPCell(image);
        cell.BorderColor = Color.WHITE;
        cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
        cell.HorizontalAlignment = align;
        cell.PaddingBottom = 0f;
        cell.PaddingTop = 0f;
        return cell;
    }

    public string DisplayWithSuffix(int num)
    {
        if (num.ToString().EndsWith("11")) return num.ToString() + "th";
        if (num.ToString().EndsWith("12")) return num.ToString() + "th";
        if (num.ToString().EndsWith("13")) return num.ToString() + "th";
        if (num.ToString().EndsWith("1")) return num.ToString() + "st";
        if (num.ToString().EndsWith("2")) return num.ToString() + "nd";
        if (num.ToString().EndsWith("3")) return num.ToString() + "rd";
        return num.ToString() + "th";
    }

    public DataSet GetPublicViewReport()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_PUBLICVIEWDASHBOARD_CFO", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(ds);
            return ds;


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
    }
}