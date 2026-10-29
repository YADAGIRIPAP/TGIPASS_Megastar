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
using System.Data.SqlClient;


public partial class UI_TSIPASS_comReportDrill : System.Web.UI.Page
{
    string FromdateforDB, TodateforDB;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Request.QueryString["fromdate"] != null && Request.QueryString["fromdate"] != "" && Request.QueryString["todate"] != null && Request.QueryString["todate"] != "")
            {
                txtFromDate.Text = Request.QueryString["fromdate"].ToString().Trim();
                txtTodate.Text = Request.QueryString["todate"].ToString().Trim();

            }
            else
            {
                txtFromDate.Text = "01-01-2015";
                DateTime today = DateTime.Today;
                txtTodate.Text = today.ToString("dd-MM-yyyy");
                FromdateforDB = txtFromDate.Text;
                TodateforDB = txtTodate.Text;
                FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                //fillgrid();
            }
            getdetails(FromdateforDB, TodateforDB);
            Label1.Text = "Report as on date " + DateTime.Now;
        }
      
    }
    protected void BtnSave2_Click(object sender, EventArgs e)
    {
        ExportToExcel();

    }
    protected void btnNewPdf_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        //  ds = (DataSet)Session["dtdataset"];

        // DataRow dr = GetData("SELECT * FROM Employees where EmployeeId = " + ddlEmployees.SelectedItem.Value).Rows[0]; ;
        // Document document = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
        Document document = new Document(PageSize.A4, 20f, 20f, 20f, 50f);
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
            string  monthName = "", monthName1 = "";
            string FromdateforDB1 = "", TodateforDB1 = "";
            int monthday1 = 0, monthday2 = 0;
            //  txtFromDate = Session["FromdateforDB"].ToString();



            strDuration = DisplayWithSuffix(monthday1) + " " + monthName + " " + FromdateforDB1 + " to " + DisplayWithSuffix(monthday2) + " " + monthName1 + " " + TodateforDB1;
            // string fullMonthName = new DateTime( FromdateforDB).ToString("MMMM", System.Globalization.CultureInfo.CreateSpecificCulture("es"));

            string tcMergePackage = "";
            //if (ddldistrict.SelectedValue != "--Select--")
            //{
            //    tcMergePackage = "District : " + ddldistrict.SelectedItem.Text;
            //}
            //if (ddlCategory.SelectedValue != "--Select--")
            //{
            //    tcMergePackage = tcMergePackage + "   Category : " + ddlCategory.SelectedItem.Text;
            //}

            //tcMergePackage = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim() + "    " + tcMergePackage;
            //------------------------------------------------------------------------------------------------------------------------------------------------------
            phrase = new Phrase();
            phrase.Add(new Chunk("Pendency Abstract Report \n\n", FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));
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
                    terms[runs] = 5f;
                }
                else if (runs == 1 || runs == 2)
                {
                    terms[runs] = 20f;
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
                        Label l4 = null;
                        phrase = new Phrase();

                        if (j == 0)
                        {
                            //cellText = (i + 1).ToString();
                            cellText = Server.HtmlDecode(grdDetails.Rows[i].Cells[j].Text);
                        }
                        else if (j == 1)
                        {
                            //cellText = Server.HtmlDecode(grdDetails.Rows[i].Cells[j].Text);

                            //Label lblAssId = (Label)grdDetails.Rows[i].FindControl("statusLabel");
                            ////l4 = grdDetails.Rows[i].Cells[j].Controls[0] as Label;
                            //cellText = Server.HtmlDecode(lblAssId.Text);
                            //// cellText = lblAssId.Text;
                            h4 = (HyperLink)grdDetails.Rows[i].Cells[j].Controls[0];
                            cellText = h4.Text;
                        }
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

                if (remainingPageSpace >= tablehiht && remainingPageSpace - 60 <= tablehiht)
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
                //cellText = Server.HtmlDecode(grdDetails.Columns[i].FooterText);

                phrase = new Phrase();
                phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
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
            Response.AddHeader("Content-Disposition", "attachment; filename=R6.1_District_wise_Abstract" + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
            Response.ContentType = "application/pdf";

            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-excel";

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
        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
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

    protected void ExportToExcel()
    {
        ExportGridToExcel();
        //commented by rajinikar on 29 05 2020
        //try
        //{
        //    Response.Clear();
        //    Response.Buffer = true;
        //    Response.AddHeader("content-disposition", "attachment;filename=R1.1AtaGlanceReport" + DateTime.Now.ToString("MM-dd-yyyy") + ".xls");
        //    Response.Charset = "";
        //    Response.ContentType = "application/vnd.ms-excel";
        //    using (StringWriter sw = new StringWriter())
        //    {
        //        HtmlTextWriter hw = new HtmlTextWriter(sw);
        //        div_Print.RenderControl(hw);
        //        Response.Output.Write(sw.ToString());
        //        Response.Flush();
        //        Response.End();
        //    }
        //    //GridView[] gvList = null;
        //    //gvList = new GridView[] { grdDetails, grdDetails0, grdDetails1 };
        //    //ExportAv("R1.2Report.xls", gvList);
        //}
        //catch (Exception e)
        //{

        //}
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

    private void getdetails(string FromdateforDB1, string TodateforDB1)
    {
        SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
        SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
        DataSet oDataSet = new DataSet();
        osqlConnection.Open();
        oSqlDataAdapter = new SqlDataAdapter("USP_GET_COI_DASHBOARD_ALL", osqlConnection);
        oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        oSqlDataAdapter.SelectCommand.Parameters.Add("@FROMDATE", SqlDbType.VarChar).Value = FromdateforDB1.ToString();
        oSqlDataAdapter.SelectCommand.Parameters.Add("@TODATE", SqlDbType.VarChar).Value = TodateforDB1.ToString();
        oDataSet = new DataSet();
        oSqlDataAdapter.Fill(oDataSet);
        grdDetails.DataSource = oDataSet.Tables[0];
        grdDetails.DataBind();
    }

    //protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    string testing = e.Row.Cells[1].Text.ToString();
    //    //if (e.Row.RowType == DataControlRowType.DataRow)
    //    //{               
    //    //    HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
    //    //    h1.NavigateUrl = "comReportDrill_drilldown.aspx?CODE=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Type")).Trim();
    //    //}


    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        if (testing == "CFE PENDENCY BEYOND" || testing == "CFO PENDENCY BEYOND" || testing == "RAW MATERIALS PENDENCY" || testing == "RENEWALS PENDENCY" || testing == "INCENTIVE GM ASSIGN PENDENCY" || testing == "INCENTIVE GM RECOMMEND PENDENCY")
    //        {
    //            HyperLink h2 = (HyperLink)e.Row.Cells[2].Controls[0];
    //            h2.NavigateUrl = "comRepDrill_dist.aspx?CODE=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Type")).Trim();
    //        }
    //        else
    //        {
    //            HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
    //            h1.NavigateUrl = "comReportDrill_drilldown.aspx?CODE=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Type")).Trim();
    //        }

    //    }
    //}

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string testing1 = e.Row.Cells[2].Text.ToString();

        string testing = e.Row.Cells[1].Text.ToString();
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + testing + "');", true);
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink h1 = (HyperLink)e.Row.Cells[1].Controls[0];

            string testing2 = h1.Text.ToString();
            if (testing2 == "CFE PENDENCY BEYOND" || testing2 == "CFO PENDENCY BEYOND" || testing2 == "RAW MATERIALS PENDENCY" || testing2 == "RENEWALS PENDENCY" || testing2 == "NOT ASSIGNED BY GM" || testing2 == "INCENTIVE GM RECOMMEND PENDENCY" || testing2 == "INSPECTION DATE NOT ASSIGNED" || testing2 == "INSPECTION REPORT NOT UPLOADED" || testing2 == "QUERY NOT REPORTED BEYOND 30 DAYS" || testing2 == "REPORT NOT SUBMITTED" || testing2 == "REPORT SUBMITTED" || testing2 == "REPORT NOT SUBMITTED BUT SALARY PROCESSED" || testing2 == "REPORT SUBMITTED BUT SALARY NOT YET PROCESSED" || testing2 == "MSME CATALOGUE DETAILS UPLOADED" || testing2 == "INITIAL STAGE" || testing2 == "Yet to Start Construction" || testing2 == "ADVANCED STAGE")
            {
                //h1.ForeColor = "red";

                h1.Font.Bold = false;
                HyperLink h2 = (HyperLink)e.Row.Cells[2].Controls[0];
                if (testing2 == "CFE PENDENCY BEYOND" || testing2 == "CFO PENDENCY BEYOND" || testing2 == "RAW MATERIALS PENDENCY" || testing2 == "GENERAL QUERY PENDENCY" || testing2 == "RENEWALS PENDENCY" || testing2 == "NOT ASSIGNED BY GM" || testing2 == "INCENTIVE GM RECOMMEND PENDENCY" || testing2 == "INSPECTION DATE NOT ASSIGNED" || testing2 == "INSPECTION REPORT NOT UPLOADED" || testing2 == "QUERY NOT REPORTED BEYOND 30 DAYS" || testing2 == "REPORT NOT SUBMITTED" || testing2 == "INITIAL STAGE" || testing2 == "Yet to Start Construction" || testing2 == "ADVANCED STAGE")
                {
                    h2.Style.Add("color", "#ff4615");
                }
                h2.NavigateUrl = "comRepDrill_dist.aspx?CODE=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Type")).Trim();
            }
            else if (testing2 == "INDUSTRY GRIEVANCES PENDENCY" || testing2 == "GRIEVANCES PENDENCY" || testing2 == "GENERAL QUERY PENDENCY" || testing2 == "APPEAL PENDENCY - CFE" || testing2 == "APPEAL PENDENCY - CFO" || testing2 == "RECIEVED CFO NOT APPLIED FOR INCENTIVES")
            {
                h1.Font.Bold = false;
                HyperLink h12 = (HyperLink)e.Row.Cells[2].Controls[0];
                if (testing2 == "APPEAL PENDENCY - CFE" || testing2 == "APPEAL PENDENCY - CFO" || testing2 == "GENERAL QUERY PENDENCY")
                {
                    h12.Style.Add("color", "#ff4615");
                }
                h12.NavigateUrl = "comReportDrill_drilldown.aspx?CODE=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Type")).Trim();
            }
            //h1.NavigateUrl = "comReportDrill_drilldown.aspx?CODE=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Type")).Trim();
        }


        #region "comm"
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{

        //    if (testing == "CFE PENDENCY BEYOND" || testing == "CFO PENDENCY BEYOND" || testing == "RAW MATERIALS PENDENCY" || testing == "RENEWALS PENDENCY" || testing == "INCENTIVE GM ASSIGN PENDENCY" || testing == "INCENTIVE GM RECOMMEND PENDENCY")
        //    {
        //        HyperLink h2 = (HyperLink)e.Row.Cells[2].Controls[0];
        //        h2.NavigateUrl = "comRepDrill_dist.aspx?CODE=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Type")).Trim();
        //    }
        //    else
        //    {

        //        HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
        //        h1.NavigateUrl = "comReportDrill_drilldown.aspx?CODE=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Type")).Trim();
        //    }

        //}
        #endregion
    }

    protected void grdDetails_PreRender(object sender, EventArgs e)
    {
        foreach (GridViewRow grdrow in grdDetails.Rows)
        {
            //HyperLink statusLabel = (HyperLink)grdrow.Cells[0].FindControl("statusLabel");
            HyperLink statusLabel = (HyperLink)grdrow.Cells[1].Controls[0];
            if (statusLabel.Text == "PENDENCY BEYOND" || statusLabel.Text == "PENDENCY " || statusLabel.Text == "APPEAL PENDENCY" || statusLabel.Text == "INCENTIVE" || statusLabel.Text == "MONTHLY PERFORMANCE REPORT" || statusLabel.Text == "MSME CATALOGUE DETAILS UPLOADED" || statusLabel.Text == "STATUS OF IMPLEMENTATION BEYOND 6 MONTHS ABOVE")
            {
                grdrow.Font.Bold = true;
                grdrow.Font.Underline = false;
            }
            else
            {
                grdrow.Font.Bold = false;
                grdrow.Font.Underline = false;
            }
        }
    }

    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        int valid = 0;
        lblmsg0.Text = "";
        Failure.Visible = false;
        string FromdateforDB = "", TodateforDB = "";

        //if (rbtnlstInputType.SelectedValue == "N")
        //{
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
        //}
        //else
        //{
        //    if (ddlFinancialYear.SelectedItem.ToString() == "--Select--")
        //    {
        //        lblmsg0.Text = "Please Select Financial Year";
        //        valid = 1;
        //    }
        //}
        if (valid == 0)
        {
            getdetails(FromdateforDB, TodateforDB);
            //FillGridDetails(FromdateforDB, TodateforDB, ddlProp_intDistrictid.SelectedValue);
        }
        else
        {
            Failure.Visible = true;
        }
    }


}