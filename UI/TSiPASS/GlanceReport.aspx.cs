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
// using System.Drawing;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

using System.Data.SqlClient;

public partial class UI_TSiPASS_GlanceReport : System.Web.UI.Page
{

    decimal NumberTotal, InvestmnetTotal, EmploymentTotal;
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
        //if (Session.Count <= 0)
        //{
        //    Response.Redirect("~/Index.aspx");

        //}
        DataSet ds = new DataSet();
        ds = Gen.GetmodifiedDate();
        Label2.Text = "Last Updated by CoI on " + ds.Tables[0].Rows[0]["ModifiedDate"].ToString().Trim();
        if (!IsPostBack)
        {
            //BindGraphChart();
            //BindPieChart();
            //fillgrid();
            BindFinancialYears(ddlFinancialYear);
           

            txtFromDate.Text = "01-01-2014";
            DateTime today = DateTime.Today;
            txtTodate.Text = today.ToString("dd-MM-yyyy");
            fillgrid(rbtnlstInputType.SelectedValue.ToString().Trim(), ddlFinancialYear.SelectedValue.ToString().Trim(), "", "", "");

            //foreach (GridViewRow row in grdDetails.Rows)
            //{
            //   // cell.Width = new Unit("350px");
            //    row.Cells[1].Width = new Unit("2000px");
            //    row.Cells[2].Width = new Unit("350px");
            //    row.Cells[3].Width = new Unit("350px");
            //    row.Cells[4].Width = new Unit("350px");
            //    row.Cells[5].Width = new Unit("350px");
            //}
        }

    }
    #endregion


    //public void fillgrid(string input, string financial, string fromdate, string todate)
    //{

    //    DataSet dsnew = new DataSet();

    //    dsnew = Gen.GetRptGlance_New1(input, financial, fromdate, todate);
    //    // lblMsg.Text = "";
    //    if (dsnew.Tables[0].Rows.Count > 0)
    //    {

    //        string fromdt = "", Todt = "";
    //        if (rbtnlstInputType.SelectedValue == "N")
    //        {
    //            Label387.Text = "Number of Industries given Approvals";
    //            Label1.Text = "Report from " + txtFromDate.Text.Trim() + " to " + txtTodate.Text.Trim();

    //        }
    //        else
    //        {
    //            Label1.Text = "Report of Financial Year : " + ddlFinancialYear.SelectedItem.Text;
    //            Label387.Text = "Number of Industries given Approvals";
    //        }
    //        if (rbtnlstInputType.SelectedValue == "N")
    //        {
    //            Label8.Text = "From <br/>" + txtFromDate.Text + "<br/>To<br/>" + txtTodate.Text;
    //        }
    //        else
    //        {
    //            Label8.Text = ddlFinancialYear.SelectedItem.ToString();
    //        }

    //        lblnumber.Text = dsnew.Tables[4].Rows[0]["Number"].ToString().Trim();
    //        lblinv.Text = dsnew.Tables[4].Rows[0]["Investment"].ToString().Trim();
    //        lblEmp.Text = dsnew.Tables[4].Rows[0]["Employment"].ToString().Trim();

    //        lblnumber1617.Text = dsnew.Tables[9].Rows[0]["Number1617"].ToString().Trim();
    //        lblInv1617.Text = dsnew.Tables[9].Rows[0]["Investment1617"].ToString().Trim();
    //        lblem1617.Text = dsnew.Tables[9].Rows[0]["Employment1617"].ToString().Trim();

    //        lblCO.Text = dsnew.Tables[0].Rows[0]["cmo"].ToString().Trim();
    //        lblas.Text = dsnew.Tables[1].Rows[0]["advstg"].ToString().Trim();
    //        lblis.Text = dsnew.Tables[2].Rows[0]["instg"].ToString().Trim();
    //        lblyet.Text = dsnew.Tables[3].Rows[0]["yetstart"].ToString().Trim();

    //        lblCom1617.Text = dsnew.Tables[5].Rows[0]["cmo1617"].ToString().Trim();
    //        lblads1617.Text = dsnew.Tables[6].Rows[0]["advstg1617"].ToString().Trim();
    //        lblIns1617.Text = dsnew.Tables[7].Rows[0]["instg1617"].ToString().Trim();
    //        lblYet1617.Text = dsnew.Tables[8].Rows[0]["yetstart1617"].ToString().Trim();
    //    }
    //    else
    //    {
    //        Label1.Text = "No Records Found ";
    //        ClearFields();
    //        Failure.Visible = true;
    //    }

    //}
    void ClearFields()
    {
        //lblnumber.Text = "--";
        //lblinv.Text = "--";
        //lblEmp.Text = "--";
        //lblCO.Text = "--";
        //lblas.Text = "--";
        //lblis.Text = "--";
        //lblyet.Text = "--";
        //lblnumber1617.Text = "--";
        //lblInv1617.Text = "--";
        //lblem1617.Text = "--";
        //lblCom1617.Text = "--";
        //lblads1617.Text = "--";
        //lblIns1617.Text = "--";
        //lblYet1617.Text = "--";
        //Label8.Text = "";
        Label1.Text = "";

        txtFromDate.Text = "";
        txtTodate.Text = "";
        System.Web.UI.WebControls.ListItem item = ddlFinancialYear.Items.FindByText("--Select--");
        if (item != null)
        {

            ddlFinancialYear.SelectedValue = "--Select--";
        }
    }

    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        //fillgrid();
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
                    //this.fillgrid();
                    grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    string FileName = lblHeading.Text;
                    FileName = FileName.Replace(" ", "");
                    Response.AddHeader("content-disposition", "attachment;filename=  " + FileName + ".pdf");

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
            Response.AddHeader("content-disposition", "attachment;filename=R1.1AtaGlanceReport" + DateTime.Now.ToString("MM-dd-yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                div_Print.RenderControl(hw);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
            //GridView[] gvList = null;
            //gvList = new GridView[] { grdDetails, grdDetails0, grdDetails1 };
            //ExportAv("R1.2Report.xls", gvList);
        }
        catch (Exception e)
        {

        }
    }
    public void ExportAv(string fileName, GridView[] gvs)
    {

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", fileName));
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        //Label1.Text = "";

        foreach (GridView gv in gvs)
        {
            gv.AllowPaging = false;

            //   Create a form to contain the grid
            System.Web.UI.WebControls.Table table = new System.Web.UI.WebControls.Table();

            table.GridLines = gv.GridLines;
            //   add the header row to the table
            if (!(gv.Caption == null))
            {

                TableCell cell = new TableCell();
                cell.Text = gv.Caption;
                cell.ColumnSpan = 6;
                TableRow tr = new TableRow();
                tr.Controls.Add(cell);
                table.Rows.Add(tr);
            }

            if (!(gv.HeaderRow == null))
            {
                table.Rows.Add(gv.HeaderRow);
            }
            //   add each of the data rows to the table
            foreach (GridViewRow row in gv.Rows)
            {
                table.Rows.Add(row);
            }
            //   add the footer row to the table
            if (!(gv.FooterRow == null))
            {
                table.Rows.Add(gv.FooterRow);
            }

            //   render the table into the htmlwriter
            table.RenderControl(htw);
        }
        //   render the htmlwriter into the response

        string label1text = Label1.Text;
        string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='left' colspan='6'><h4>" + label1text + "</h4></td></td></tr><tr><td align='left' colspan='6'><h4>R1.1: TSiPASS AT A GLANCE REPORT</h4></td></td></tr></table>";
        HttpContext.Current.Response.Write(headerTable);
        HttpContext.Current.Response.Write(sw.ToString());
        HttpContext.Current.Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void rbtnlstInputType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtnlstInputType.SelectedValue == "N")
        {
            trBetweenDates.Visible = true;
            trFinYears.Visible = false;
            ClearFields();
        }
        else
        {
            trBetweenDates.Visible = false;
            trFinYears.Visible = true;
            ClearFields();
        }
    }
    public void BindFinancialYears(DropDownList ddlFinYear)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlFinYear.Items.Clear();
            dsd = Gen.GetFinancialYearsForReports();
            //ListItem ITEM=new ListItem
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
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
    protected void btnGet_Click(object sender, EventArgs e)
    {
        int valid = 0;
        lblError.Text = "";
        Failure.Visible = false;
        string FromdateforDB = "", TodateforDB = "";

        if (rbtnlstInputType.SelectedValue == "N")
        {
            if (txtFromDate.Text == "" || txtFromDate.Text == null)
            {
                lblError.Text = "Please Enter From Date <br/>";
                valid = 1;
            }
            if (txtTodate.Text == "" || txtTodate.Text == null)
            {
                lblError.Text += "Please Enter To Date <br/>";
                valid = 1;
            }
            if (valid == 0)
            {
                FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }
        }
        else
        {
            if (ddlFinancialYear.SelectedItem.ToString() == "--Select--")
            {
                lblError.Text = "Please Select Financial Year";
                valid = 1;
            }
        }
        if (valid == 0)
        {
            fillgrid(rbtnlstInputType.SelectedValue.ToString().Trim(), ddlFinancialYear.SelectedValue.ToString().Trim(), FromdateforDB, TodateforDB, "G");
        }
        else
        {
            Failure.Visible = true;
        }
    }

    private void fillgrid(string input, string financial, string fromdate, string todate, string Flag)
    {
        DataSet ds = new DataSet();
        if (rbtnlstInputType.SelectedValue == "N")
        {
            if (txtFromDate.Text.Trim() != "")
                Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();

        }
        else if (rbtnlstInputType.SelectedValue == "F")
        {
            Label1.Text = "Report of Financial Year : " + ddlFinancialYear.SelectedItem.Text;
        }

        string dist = "";
        //dist = Session["DistrictID"].ToString().Trim();
        if (string.IsNullOrEmpty(dist))
        {
            ds = Gen.GetRptGlance2_New1(input, financial, fromdate, todate, Flag);
        }
        //else if (!string.IsNullOrEmpty(dist))
        //{
        //    ds = GetRptGlance2_New1_DIST(input, financial, fromdate, todate, Flag, Session["DistrictID"].ToString().Trim());
        //}

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            // ds.Tables[0].Columns.Remove("DOA");
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            Label1.Text = "No Record Found ";
            grdDetails.DataSource = null;
        }
    }

    //protected void BtnPDF_Click(object sender, EventArgs e)
    //{
    //   // PrintPdf();
    //}

    protected void btnbdf_Click(object sender, EventArgs e)
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
            phrase.Add(new Chunk("Telangana State Industrial Project Approval\n\n", FontFactory.GetFont("trebuchet ms", 13, Font.BOLD, Color.BLACK)));
            phrase.Add(new Chunk("&	Self- Certification System (TS-iPASS)\n\n", FontFactory.GetFont("trebuchet ms", 13, Font.BOLD, Color.BLACK)));
            phrase.Add(new Chunk("government of telangana".ToUpper(), FontFactory.GetFont("trebuchet ms", 11, Font.BOLD, Color.BLACK)));

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

            if (txtFromDate.Text.Trim() != "" && txtTodate.Text.Trim() != "")
            {
                FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM"));
                TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM"));
                monthday1 = Convert.ToInt32(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("dd"));
                monthday2 = Convert.ToInt32(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("dd"));

                FromdateforDB1 = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("yyyy"));
                TodateforDB1 = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("yyyy"));

                monthName = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(FromdateforDB));
                monthName1 = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(TodateforDB));
            }

            strDuration = DisplayWithSuffix(monthday1) + " " + monthName + " " + FromdateforDB1 + " to " + DisplayWithSuffix(monthday2) + " " + monthName1 + " " + TodateforDB1;
            // string fullMonthName = new DateTime( FromdateforDB).ToString("MMMM", System.Globalization.CultureInfo.CreateSpecificCulture("es"));

            string tcMergePackage = "Report From " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
            //------------------------------------------------------------------------------------------------------------------------------------------------------
            phrase = new Phrase();
            phrase.Add(new Chunk("TSiPASS AT A GLANCE REPORT\n\n", FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));
            if (txtFromDate.Text.Trim() != "")
            {
                phrase.Add(new Chunk(tcMergePackage, FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));
            }
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
            cell.PaddingBottom = 20f;
            table.AddCell(cell);

            document.Add(table);

            color = new Color(6, 170, 26);
            DrawLineMiddleline(writer, 2f, document.Top - 70f, document.PageSize.Width - 2f, document.Top - 70f, color);

            int CountColumns = 0;

            CountColumns = grdDetails.Rows[0].Cells.Count; ;

            tablenew = new PdfPTable(CountColumns);
            //  tablenew.SetWidths(new float[] { 0.15f, 0.05f, 0.70f, 0.25f });
            float[] terms = new float[CountColumns];
            for (int runs = 0; runs < CountColumns; runs++)
            {
                if (runs == 0)
                {
                    terms[runs] = 5f;
                }
                else if (runs == 1)
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

            for (int i = 0; i < CountColumns; i++)
            {
                string cellText = "";

                cellText = Server.HtmlDecode(grdDetails.HeaderRow.Cells[i].Text);

                phrase = new Phrase();
                phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.BackgroundColor = new Color(grdDetails.HeaderStyle.BackColor);
                cell.PaddingBottom = 5;

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


                        cellText = Server.HtmlDecode(grdDetails.Rows[i].Cells[j].Text);
                        cellText = Server.HtmlDecode(cellText);

                        if (j == 0 && (cellText == "CFE - Total" || cellText == "CFO - Total" || cellText == "CFE + CFO TOTAL" || cellText == "GRAND TOTAL"))
                        {
                            cellText = "";
                            phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.BOLD, Color.BLACK)));
                        }
                        else
                        {
                            string cellTextnew = Server.HtmlDecode(grdDetails.Rows[i].Cells[1].Text);
                            if ((cellTextnew == "CFE - Total" || cellTextnew == "CFO - Total" || cellTextnew == "CFE + CFO TOTAL" || cellTextnew == "GRAND TOTAL"))
                            {
                                phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.BOLD, Color.BLACK)));
                            }
                            else
                            {
                                phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.BLACK)));
                            }
                        }


                        if (j == 1)
                        {
                            cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                        }
                        else if (j == 0)
                        {
                            cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
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
            }
            contentBytenew.SetColorStroke(color);
            contentBytenew.Circle(document.PageSize.Width - 23f, document.PageSize.Bottom + 23f, 10f);
            contentBytenew.Stroke();
            ColumnText.ShowTextAligned(contentBytenew, Element.ALIGN_RIGHT, new Phrase((writer.PageNumber).ToString(), FontFactory.GetFont("Trebuchet MS", 12, Font.BOLD, Color.BLACK)), document.PageSize.Width - 20f, document.PageSize.Bottom + 20f, 2);
            document.Add(tablenew);
            document.Close();
            byte[] bytes = memoryStream.ToArray();
            memoryStream.Close();
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=DepartmentwiseCFE.pdf");
            Response.ContentType = "application/pdf";

            //Response.ContentType = "application/vnd.ms-excel";
            //Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
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

    public DataSet GetRptGlance2_New1_DIST(string input, string financial, string fromdate, string todate, string Flag, string dist)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();

        try
        {
            //  da = new SqlDataAdapter("GetRptGlance2_New1", con.GetConnection);
            da = new SqlDataAdapter("GetRptGlance2_New1_DIST", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@InputFlg", SqlDbType.VarChar).Value = input.ToString();
            da.SelectCommand.Parameters.Add("@FinancialYearCd", SqlDbType.VarChar).Value = financial.ToString();
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = fromdate.ToString();
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = todate.ToString();
            da.SelectCommand.Parameters.Add("@Flag", SqlDbType.VarChar).Value = Flag.ToString();
            da.SelectCommand.Parameters.Add("@DISTcd", SqlDbType.VarChar).Value = dist.ToString();


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