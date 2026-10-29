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
//using System.Drawing;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
// using Microsoft.Office.Interop.Word;

public partial class UI_TSiPASS_frmAbstractanasisreport : System.Web.UI.Page
{
    General Gen = new General();
    int Slnorow = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ddlFinancialYear.SelectedValue = "1";

                txtFromDate.Text = "01-01-2015";
                DateTime today = DateTime.Today;
                txtTodate.Text = today.ToString("dd-MM-yyyy");


                fillgrid();
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
        }
    }
    protected void btnGet_Click(object sender, EventArgs e)
    {
        try
        {

            fillgrid();
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
        }

    }
    public void fillgrid()
    {
        try
        {
            DataSet dsnew = new DataSet();

            string FromdateforDB = "", TodateforDB = "";
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));

            dsnew = Gen.FetchAnalisReport(ddlFinancialYear.SelectedValue, FromdateforDB, TodateforDB);
            Session["dtdataset"] = dsnew;
            // lblMsg.Text = "";
            if (dsnew.Tables[2].Rows.Count > 0)
            {
                // lblMsg.Text = "Total Records :" +dsnew.Tables[0].Rows.Count.ToString();

                if (ddlFinancialYear.SelectedValue == "1")
                {
                    grdDetails.Columns[4].Visible = true;
                    grdDetails.Columns[5].Visible = true;
                }
                else
                {
                    grdDetails.Columns[4].Visible = false;
                    grdDetails.Columns[5].Visible = false;
                }

                grdDetails.DataSource = dsnew.Tables[4];
                grdDetails.DataBind();

                grdDetails.HeaderRow.Cells[0].Text = "Applications Applied Since " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();

                grdDetails.HeaderRow.Cells[1].Text = "Applications Disposed Online Since " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();

                lbldate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                //GridView1.DataSource = dsnew.Tables[0];
                //GridView1.DataBind();

                //GridView2.DataSource = dsnew.Tables[1];
                //GridView2.DataBind();


            }
            else
            {
                //lblMsg.Text = "";
                // Label1.Text = "No Recards Found ";
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
        }
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = (Label)e.Row.FindControl("Label1");
                Label lbl2 = (Label)e.Row.FindControl("Label2");
                e.Row.Cells[0].Text = (Slnorow + 1).ToString();
                Slnorow = (Slnorow + 1);
                if (e.Row.Cells[1].Text == "CFO - Total" || e.Row.Cells[1].Text == "CFE + CFO TOTAL" || e.Row.Cells[1].Text == "GRAND TOTAL" || e.Row.Cells[1].Text == "CFE - Total")
                {
                    Slnorow = 0;
                    e.Row.Cells[0].Text = e.Row.Cells[1].Text;
                    e.Row.Cells[1].Visible = false;
                    e.Row.Cells[0].ColumnSpan = 2;
                    e.Row.Cells[0].Attributes.CssStyle["text-align"] = "center";
                    e.Row.Font.Bold = true;
                    e.Row.BackColor = System.Drawing.Color.Yellow;
                }

                string FromdateforDB = "", TodateforDB = "", deptid = "", departmentname = "", DrillDownType = "";
                FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));

                departmentname = e.Row.Cells[1].Text;
                deptid = lbl.Text;
                DrillDownType = lbl2.Text;
                HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
                if (h1.Text != "0")
                {
                    h1.NavigateUrl = "frmanalasysdrilldown.aspx?status=A&Fromdate=" + FromdateforDB.Trim() + "&Todate=" + TodateforDB.Trim() + "&Dept=" + deptid + "&deptname=" + departmentname + "&DrillDownType=" + DrillDownType + "&SearchType=" + ddlFinancialYear.SelectedValue;
                }
                HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
                if (h2.Text != "0")
                {
                    h2.NavigateUrl = "frmanalasysdrilldown.aspx?status=B&Fromdate=" + FromdateforDB.Trim() + "&Todate=" + TodateforDB.Trim() + "&Dept=" + deptid + "&deptname=" + departmentname + "&DrillDownType=" + DrillDownType + "&SearchType=" + ddlFinancialYear.SelectedValue;
                }
                if (ddlFinancialYear.SelectedValue == "1" && (HyperLink)e.Row.Cells[4].Controls[0] != null && (HyperLink)e.Row.Cells[5].Controls[0] != null)
                {
                    HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
                    if (h3.Text != "0")
                    {
                        h3.NavigateUrl = "frmanalasysdrilldown.aspx?status=C&Fromdate=" + FromdateforDB.Trim() + "&Todate=" + TodateforDB.Trim() + "&Dept=" + deptid + "&deptname=" + departmentname + "&DrillDownType=" + DrillDownType + "&SearchType=" + ddlFinancialYear.SelectedValue;
                    }
                    HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
                    if (h4.Text != "0")
                    {
                        h4.NavigateUrl = "frmanalasysdrilldown.aspx?status=D&Fromdate=" + FromdateforDB.Trim() + "&Todate=" + TodateforDB.Trim() + "&Dept=" + deptid + "&deptname=" + departmentname + "&DrillDownType=" + DrillDownType + "&SearchType=" + ddlFinancialYear.SelectedValue;
                    }
                }
                HyperLink h5 = (HyperLink)e.Row.Cells[6].Controls[0];
                if (h5.Text != "0")
                {
                    h5.NavigateUrl = "frmanalasysdrilldown.aspx?status=E&Fromdate=" + FromdateforDB.Trim() + "&Todate=" + TodateforDB.Trim() + "&Dept=" + deptid + "&deptname=" + departmentname + "&DrillDownType=" + DrillDownType + "&SearchType=" + ddlFinancialYear.SelectedValue;
                }
                HyperLink h6 = (HyperLink)e.Row.Cells[7].Controls[0];
                if (h6.Text != "0")
                {
                    h6.NavigateUrl = "frmanalasysdrilldown.aspx?status=F&Fromdate=" + FromdateforDB.Trim() + "&Todate=" + TodateforDB.Trim() + "&Dept=" + deptid + "&deptname=" + departmentname + "&DrillDownType=" + DrillDownType + "&SearchType=" + ddlFinancialYear.SelectedValue;
                }
                HyperLink h7 = (HyperLink)e.Row.Cells[8].Controls[0];
                if (h7.Text != "0")
                {
                    h7.NavigateUrl = "frmanalasysdrilldown.aspx?status=G&Fromdate=" + FromdateforDB.Trim() + "&Todate=" + TodateforDB.Trim() + "&Dept=" + deptid + "&deptname=" + departmentname + "&DrillDownType=" + DrillDownType + "&SearchType=" + ddlFinancialYear.SelectedValue;
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
        }
    }

    protected void BtnSave2_Click(object sender, EventArgs e)
    {
        try
        {
            ExportToExcel();
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
        }
    }

    protected void ExportToExcel()
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=R6.3: TSiPASS - Progress Of Implementation Report.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            //  Government.Visible = true;
            divPrint.Style["width"] = "680px";
            // Button1.Visible = false;
            // Button2.Visible = false;
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                grdDetails.AllowPaging = false;
                this.fillgrid();

                grdDetails.HeaderRow.BackColor = System.Drawing.Color.White;
                foreach (TableCell cell in grdDetails.HeaderRow.Cells)
                {
                    //cell.BackColor = grdDetails.HeaderStyle.BackColor;
                    cell.ForeColor = System.Drawing.Color.Black;
                }
                foreach (TableCell cell in grdDetails.FooterRow.Cells)
                {
                    cell.BackColor = System.Drawing.Color.White;
                    cell.ForeColor = System.Drawing.Color.Black;
                    // cell.
                }


                foreach (TableCell cell in grdDetails.FooterRow.Cells)
                {

                    cell.CssClass = "textmode";
                    List<Control> controls = new List<Control>();
                    foreach (Control control in cell.Controls)
                    {
                        switch (control.GetType().Name)
                        {
                            case "HyperLink":
                                controls.Add(control);
                                break;
                            case "TextBox":
                                controls.Add(control);
                                break;
                            case "LinkButton":
                                controls.Add(control);
                                break;
                            case "CheckBox":
                                controls.Add(control);
                                break;
                            case "RadioButton":
                                controls.Add(control);
                                break;
                        }
                    }
                    foreach (Control control in controls)
                    {
                        switch (control.GetType().Name)
                        {
                            case "HyperLink":
                                cell.Controls.Add(new Literal { Text = (control as HyperLink).Text });
                                break;
                            case "TextBox":
                                cell.Controls.Add(new Literal { Text = (control as TextBox).Text });
                                break;
                            case "LinkButton":
                                cell.Controls.Add(new Literal { Text = (control as LinkButton).Text });
                                break;
                            case "CheckBox":
                                cell.Controls.Add(new Literal { Text = (control as CheckBox).Text });
                                break;
                            case "RadioButton":
                                cell.Controls.Add(new Literal { Text = (control as RadioButton).Text });
                                break;
                        }
                        cell.Controls.Remove(control);
                    }
                }
                foreach (GridViewRow row in grdDetails.Rows)
                {
                    row.BackColor = System.Drawing.Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = grdDetails.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = grdDetails.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                        List<Control> controls = new List<Control>();
                        foreach (Control control in cell.Controls)
                        {
                            switch (control.GetType().Name)
                            {
                                case "HyperLink":
                                    controls.Add(control);
                                    break;
                                case "TextBox":
                                    controls.Add(control);
                                    break;
                                case "LinkButton":
                                    controls.Add(control);
                                    break;
                                case "CheckBox":
                                    controls.Add(control);
                                    break;
                                case "RadioButton":
                                    controls.Add(control);
                                    break;
                            }
                        }
                        foreach (Control control in controls)
                        {
                            switch (control.GetType().Name)
                            {
                                case "HyperLink":
                                    cell.Controls.Add(new Literal { Text = (control as HyperLink).Text });
                                    break;
                                case "TextBox":
                                    cell.Controls.Add(new Literal { Text = (control as TextBox).Text });
                                    break;
                                case "LinkButton":
                                    cell.Controls.Add(new Literal { Text = (control as LinkButton).Text });
                                    break;
                                case "CheckBox":
                                    cell.Controls.Add(new Literal { Text = (control as CheckBox).Text });
                                    break;
                                case "RadioButton":
                                    cell.Controls.Add(new Literal { Text = (control as RadioButton).Text });
                                    break;
                            }
                            cell.Controls.Remove(control);
                        }
                    }
                }

                divPrint.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                Response.Write(style);
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
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
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
                    if (i == 2 || i == 3 || i == 4 || i == 5 || i == 6 || i == 7 || i == 8 || i == 9)
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

                string FromdateforDB = "", TodateforDB = "", monthName = "", monthName1 = "";
                string FromdateforDB1 = "", TodateforDB1 = "";
                if (txtFromDate.Text.Trim() != "" && txtTodate.Text.Trim() != "")
                {
                    FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM"));
                    TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM"));


                    FromdateforDB1 = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("yyyy"));
                    TodateforDB1 = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("yyyy"));

                    monthName = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(FromdateforDB));
                    monthName1 = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(TodateforDB));
                }
                // string fullMonthName = new DateTime( FromdateforDB).ToString("MMMM", System.Globalization.CultureInfo.CreateSpecificCulture("es"));
                string tcMergePackageNEW = "Analytics From " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();

                TableCell tcMergePackage = new TableCell();
                // tcMergePackage.Text = "Analytics from April 2016 to September 2017";
                // tcMergePackage.Text = "Analytics From " + monthName + " " + FromdateforDB1 + " TO " + monthName1 + " " + TodateforDB1;
                tcMergePackage.Text = "Analytics From " + tcMergePackageNEW;
                tcMergePackage.CssClass = "GridviewScrollC1Headerwrap";
                tcMergePackage.ColumnSpan = 7;
                gvHeaderRowCopy.Cells.AddAt(2, tcMergePackage);
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
        }
    }

    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        try
        {
            PrintPdf();
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
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
                    //To Export all pages
                    //trLogo.Visible = true;
                    grdDetails.AllowPaging = false;
                    //this.FillGridDetails(rbtnlstInputType.SelectedValue.ToString().Trim(), ddlFinancialYear.SelectedValue.ToString().Trim(), FromdateforDB, TodateforDB);
                    grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.FooterRow.Visible = true;
                    grdDetails.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename= R1.5_Month_wise_Applications_Received" + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
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

    protected void Button3_Click(object sender, EventArgs e)
    {
        fillgrid();
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

            string tcMergePackage = "Analytics From " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
            //------------------------------------------------------------------------------------------------------------------------------------------------------
            phrase = new Phrase();
            phrase.Add(new Chunk("TSIPASS APPROVAL ANALYSIS\n\n", FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));
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
            cell.PaddingTop = 0f;
            cell.PaddingBottom = 0f;
            table.AddCell(cell);

            document.Add(table);

            color = new Color(6, 170, 26);
            DrawLineMiddleline(writer, 2f, document.Top - 60f, document.PageSize.Width - 2f, document.Top - 60f, color);

            int CountColumns = 0;
            if (ddlFinancialYear.SelectedValue == "2")
            {
                CountColumns = grdDetails.Columns.Count - 2;
            }
            else
            {
                CountColumns = grdDetails.Columns.Count;
            }

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
            CountColumns = grdDetails.Columns.Count;
            for (int i = 0; i < CountColumns; i++)
            {
                string cellText = "";
                if (ddlFinancialYear.SelectedValue == "2" && (i == 4 || i == 5))
                {
                    continue;
                }
                else
                {
                    cellText = Server.HtmlDecode(grdDetails.Columns[i].HeaderText);
                }
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
                        if (ddlFinancialYear.SelectedValue == "2" && (j == 4 || j == 5))
                        {
                            continue;
                        }
                        else
                        {
                            if (j == 0 || j == 1)
                            {
                                cellText = Server.HtmlDecode(grdDetails.Rows[i].Cells[j].Text);
                            }
                            else
                            {
                                h4 = (HyperLink)grdDetails.Rows[i].Cells[j].Controls[0];
                                cellText = h4.Text;
                            }
                            cellText = Server.HtmlDecode(cellText);
                        }
                        // h4 = (HyperLink)grdDetails.Rows[i].Controls[j];
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
                        string cellTexta = "";
                        // HyperLink h4 = (HyperLink)grdDetails.Rows[i].Controls[k];
                        if (ddlFinancialYear.SelectedValue == "2" && (k == 4 || k == 5))
                        {
                            continue;
                        }
                        else
                        {
                            cellTexta = Server.HtmlDecode(grdDetails.Columns[k].HeaderText);
                        }
                        phrase = new Phrase();
                        phrase.Add(new Chunk(cellTexta, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
                        cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                        cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.BackgroundColor = new Color(grdDetails.HeaderStyle.BackColor);
                        cell.PaddingBottom = 5;

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

    protected void btnKeyhilights_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds = (DataSet)Session["dtdataset"];

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
            //table.TotalWidth = document.PageSize.Width - 10f;
            //table.SetWidths(new float[] { 0.2f, 0.6f, 0.2f });
            table.TotalWidth = document.PageSize.Width - 60f;
            table.SetWidths(new float[] { 0.1f, 0.8f, 0.1f });
            table.LockedWidth = true;

            cell = ImageCell("~/images/ipasslogopsr.png", 20f, PdfPCell.ALIGN_CENTER);
            cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            table.AddCell(cell);

            //phrase = new Phrase();
            //phrase.Add(new Chunk("Telangana State Industrial Project Approval &	Self- Certification System (TS-iPASS)\n\n", FontFactory.GetFont("trebuchet ms", 13, Font.BOLD, Color.BLACK)));
            //phrase.Add(new Chunk("government of telangana".ToUpper(), FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));

            //cell = PhraseCell(phrase, PdfPCell.ALIGN_CENTER);
            //cell.VerticalAlignment = PdfCell.ALIGN_TOP;

            phrase = new Phrase();
            phrase.Add(new Chunk("Telangana State Industrial Project Approval\n\n", FontFactory.GetFont("trebuchet ms", 13, Font.BOLD, Color.BLACK)));
            phrase.Add(new Chunk("&	Self- Certification System (TS-iPASS)\n\n", FontFactory.GetFont("trebuchet ms", 13, Font.BOLD, Color.BLACK)));
            phrase.Add(new Chunk("government of telangana".ToUpper(), FontFactory.GetFont("trebuchet ms", 11, Font.BOLD, Color.BLACK)));

            cell = PhraseCell(phrase, PdfPCell.ALIGN_CENTER);
            cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            // cell.PaddingBottom = 30f;
            table.AddCell(cell);

            cell = ImageCell("~/images/logoTG.gif", 20f, PdfPCell.ALIGN_CENTER);
            cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            table.AddCell(cell);

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

            string tcMergePackage = "Analytics From " + strDuration;

            phrase = new Phrase();
            phrase.Add(new Chunk("TSiPASS PERFORMANCE: KEY HIGHLIGHTS\n", FontFactory.GetFont("trebuchet ms", 13, Font.BOLD, Color.RED)));
            // phrase.Add(new Chunk("\n" + tcMergePackage, FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
            cell.VerticalAlignment = PdfCell.ALIGN_CENTER;
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            cell.Colspan = 3;
            cell.PaddingTop = 15f;
            cell.PaddingBottom = 10f;
            table.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk("Report Generated On :" + DateTime.Now.ToString("dd/MM/yyyy"), FontFactory.GetFont("trebuchet ms", 12, Font.NORMAL, Color.BLACK)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = PdfCell.ALIGN_RIGHT;
            cell.Colspan = 3;
            cell.PaddingTop = 2f;
            cell.PaddingBottom = 2f;
            table.AddCell(cell);

            document.Add(table);

            color = new Color(6, 170, 26);
            DrawLineMiddleline(writer, 2f, document.Top - 70f, document.PageSize.Width - 2f, document.Top - 70f, color);

            //	Count of approvals handled: 

            tablenew = new PdfPTable(3);
            tablenew.TotalWidth = document.PageSize.Width - 60f;
            tablenew.LockedWidth = true;
            tablenew.SetWidths(new float[] { 0.05f, 0.65f, 0.3f });

            string Totalapprovalshandled = "", Morethan1000 = "", Approvalper = "", Rejectedper = "";

            Totalapprovalshandled = ds.Tables[5].Rows[0]["Numberofapplicationshandledonlinesince"].ToString();
            // Morethan1000 = ds.Tables[5].Rows[0]["Departmentshandlingmorethan1000approvals"].ToString() + ",\n\n" + ds.Tables[5].Rows[0]["departments"].ToString();
            Morethan1000 = ds.Tables[5].Rows[0]["departments"].ToString();
            Approvalper = ds.Tables[5].Rows[0]["ApprovedPer"].ToString();
            Rejectedper = ds.Tables[5].Rows[0]["RejectedPer"].ToString();

            cell = PhraseCell(new Phrase("Number of approvals handled :", FontFactory.GetFont("trebuchet ms", 13, Font.BOLD, Color.BLACK)), PdfPCell.ALIGN_LEFT);
            cell.Colspan = 3;
            cell.PaddingTop = 5f;
            cell.PaddingBottom = 15f;
            cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            tablenew.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk("1. ", FontFactory.GetFont("Trebuchet MS", 13, Font.NORMAL, Color.BLACK)));
            cell = PhraseCellnew(phrase, PdfPCell.ALIGN_LEFT);
            tablenew.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk("Approvals handled since the launch on 01/01/2015", FontFactory.GetFont("Trebuchet MS", 12, Font.NORMAL, Color.BLACK)));
            cell = PhraseCellnew(phrase, PdfPCell.ALIGN_LEFT);
            tablenew.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk(Totalapprovalshandled + " \n", FontFactory.GetFont("Trebuchet MS", 12, Font.NORMAL, Color.BLACK)));
            cell = PhraseCellnew(phrase, PdfPCell.ALIGN_RIGHT);
            tablenew.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk("2. ", FontFactory.GetFont("Trebuchet MS", 13, Font.NORMAL, Color.BLACK)));
            cell = PhraseCellnew(phrase, PdfPCell.ALIGN_LEFT);
            tablenew.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk("Departments handling more than 1000 approvals each", FontFactory.GetFont("Trebuchet MS", 12, Font.NORMAL, Color.BLACK)));
            cell = PhraseCellnew(phrase, PdfPCell.ALIGN_LEFT);

            tablenew.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk(Morethan1000, FontFactory.GetFont("Trebuchet MS", 12, Font.NORMAL, Color.BLACK)));
            cell = PhraseCellnew(phrase, PdfPCell.ALIGN_LEFT);
            cell.PaddingTop = 10f;
            cell.PaddingBottom = 10f;
            cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            tablenew.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk("3. ", FontFactory.GetFont("Trebuchet MS", 13, Font.NORMAL, Color.BLACK)));
            cell = PhraseCellnew(phrase, PdfPCell.ALIGN_LEFT);
            tablenew.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk("% Approved ", FontFactory.GetFont("Trebuchet MS", 12, Font.NORMAL, Color.BLACK)));
            cell = PhraseCellnew(phrase, PdfPCell.ALIGN_LEFT);
            tablenew.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk(Approvalper + " \n", FontFactory.GetFont("Trebuchet MS", 12, Font.NORMAL, Color.BLACK)));
            cell = PhraseCellnew(phrase, PdfPCell.ALIGN_RIGHT);
            tablenew.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk("4. ", FontFactory.GetFont("Trebuchet MS", 13, Font.NORMAL, Color.BLACK)));
            cell = PhraseCellnew(phrase, PdfPCell.ALIGN_LEFT);
            tablenew.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk("% Rejected ", FontFactory.GetFont("Trebuchet MS", 12, Font.NORMAL, Color.BLACK)));
            cell = PhraseCellnew(phrase, PdfPCell.ALIGN_LEFT);
            tablenew.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk(Rejectedper + " \n", FontFactory.GetFont("Trebuchet MS", 12, Font.NORMAL, Color.BLACK)));
            cell = PhraseCellnew(phrase, PdfPCell.ALIGN_RIGHT);
            tablenew.AddCell(cell);

            document.Add(tablenew);
            // -------------------------------------------------------------------------------------------------------------------------------

            PdfPTable tablenew1 = new PdfPTable(3);
            tablenew1.TotalWidth = document.PageSize.Width - 60f;
            tablenew1.LockedWidth = true;
            tablenew1.SetWidths(new float[] { 0.05f, 0.75f, 0.25f });

            string Approvalsdisposedwithinduedate = "", Countofapprovalsgiveninsameday = "", Departmentswithdisposalrateof90above = "";

            Approvalsdisposedwithinduedate = ds.Tables[6].Rows[0]["Approvalsdisposedwithinduedate"].ToString();
            Countofapprovalsgiveninsameday = ds.Tables[6].Rows[0]["Countofapprovalsgiveninsameday"].ToString();
            Departmentswithdisposalrateof90above = ds.Tables[6].Rows[0]["Departments90"].ToString();


            cell = PhraseCell(new Phrase("Analytics on disposal within due date : (" + strDuration + ")", FontFactory.GetFont("trebuchet ms", 13, Font.BOLD, Color.BLACK)), PdfPCell.ALIGN_LEFT);
            cell.Colspan = 3;
            cell.PaddingTop = 20f;
            cell.PaddingBottom = 20f;
            cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            tablenew1.AddCell(cell);


            phrase = new Phrase();
            phrase.Add(new Chunk("1. ", FontFactory.GetFont("Trebuchet MS", 13, Font.NORMAL, Color.BLACK)));
            cell = PhraseCellnew(phrase, PdfPCell.ALIGN_LEFT);
            tablenew1.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk("Approvals disposed within due date", FontFactory.GetFont("Trebuchet MS", 12, Font.NORMAL, Color.BLACK)));
            cell = PhraseCellnew(phrase, PdfPCell.ALIGN_LEFT);
            tablenew1.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk(Approvalsdisposedwithinduedate + " \n", FontFactory.GetFont("Trebuchet MS", 12, Font.NORMAL, Color.BLACK)));
            cell = PhraseCellnew(phrase, PdfPCell.ALIGN_RIGHT);
            tablenew1.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk("2. ", FontFactory.GetFont("Trebuchet MS", 13, Font.NORMAL, Color.BLACK)));
            cell = PhraseCellnew(phrase, PdfPCell.ALIGN_LEFT);
            tablenew1.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk("Number of approvals given in same day", FontFactory.GetFont("Trebuchet MS", 12, Font.NORMAL, Color.BLACK)));
            cell = PhraseCellnew(phrase, PdfPCell.ALIGN_LEFT);
            tablenew1.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk(Countofapprovalsgiveninsameday + " \n", FontFactory.GetFont("Trebuchet MS", 12, Font.NORMAL, Color.BLACK)));
            cell = PhraseCellnew(phrase, PdfPCell.ALIGN_RIGHT);
            tablenew1.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk("3. ", FontFactory.GetFont("Trebuchet MS", 13, Font.NORMAL, Color.BLACK)));
            cell = PhraseCellnew(phrase, PdfPCell.ALIGN_LEFT);
            tablenew1.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk("Departments with disposal rate of 90% & above", FontFactory.GetFont("Trebuchet MS", 12, Font.NORMAL, Color.BLACK)));
            cell = PhraseCellnew(phrase, PdfPCell.ALIGN_LEFT);
            tablenew1.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk(Departmentswithdisposalrateof90above + " \n", FontFactory.GetFont("Trebuchet MS", 12, Font.NORMAL, Color.BLACK)));
            cell = PhraseCellnew(phrase, PdfPCell.ALIGN_RIGHT);
            tablenew1.AddCell(cell);

            document.Add(tablenew1);


            //--------------------------------------------------------------------------------------------------------------------------------------------------

            PdfPTable tablenew2 = new PdfPTable(5);
            tablenew2.TotalWidth = document.PageSize.Width - 60f;
            tablenew2.LockedWidth = true;
            tablenew2.SetWidths(new float[] { 0.05f, 0.35f, 0.2f, 0.2f, 0.2f });
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[5].Rows.Count > 0)
            {
                cell = PhraseCell(new Phrase("Top 5 performing Departments (disposal rate of 90%) :", FontFactory.GetFont("trebuchet ms", 13, Font.BOLD, Color.BLACK)), PdfPCell.ALIGN_LEFT);
                cell.Colspan = 5;
                cell.PaddingTop = 20f;
                cell.PaddingBottom = 20f;
                cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                tablenew2.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk("Sl No ", FontFactory.GetFont("Trebuchet MS", 13, Font.NORMAL, Color.BLACK)));
                cell = PhraseCellnew(phrase, PdfPCell.ALIGN_LEFT);
                tablenew2.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk("Department Name", FontFactory.GetFont("Trebuchet MS", 12, Font.NORMAL, Color.BLACK)));
                cell = PhraseCellnew(phrase, PdfPCell.ALIGN_LEFT);
                tablenew2.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk("Approvals applied online", FontFactory.GetFont("Trebuchet MS", 12, Font.NORMAL, Color.BLACK)));
                cell = PhraseCellnew(phrase, PdfPCell.ALIGN_RIGHT);
                tablenew2.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk("Approvals disposed (%)", FontFactory.GetFont("Trebuchet MS", 12, Font.NORMAL, Color.BLACK)));
                cell = PhraseCellnew(phrase, PdfPCell.ALIGN_RIGHT);
                tablenew2.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk("Number of approvals given in same day (%)", FontFactory.GetFont("Trebuchet MS", 12, Font.NORMAL, Color.BLACK)));
                cell = PhraseCellnew(phrase, PdfPCell.ALIGN_RIGHT);
                tablenew2.AddCell(cell);

                string DepartmentName = "", Approvalsappliedonline = "", Approvalsdisposedper = "", approvalsgiveninsamedayper = "";
                for (int i = 0; i < ds.Tables[7].Rows.Count; i++)
                {
                    DepartmentName = ds.Tables[7].Rows[i]["DEPARTMENTNAME"].ToString();
                    Approvalsappliedonline = ds.Tables[7].Rows[i]["Total_approvals_applied_since"].ToString();
                    Approvalsdisposedper = ds.Tables[7].Rows[i]["per_of_Applications_disposedoffwithinduedatenew"].ToString();
                    approvalsgiveninsamedayper = ds.Tables[7].Rows[i]["Noofapplicationsdisposedonthesameday"].ToString();

                    phrase = new Phrase();
                    phrase.Add(new Chunk((i + 1).ToString(), FontFactory.GetFont("Trebuchet MS", 13, Font.NORMAL, Color.BLACK)));
                    cell = PhraseCellnew(phrase, PdfPCell.ALIGN_LEFT);
                    tablenew2.AddCell(cell);

                    phrase = new Phrase();
                    phrase.Add(new Chunk(DepartmentName, FontFactory.GetFont("Trebuchet MS", 12, Font.NORMAL, Color.BLACK)));
                    cell = PhraseCellnew(phrase, PdfPCell.ALIGN_LEFT);
                    tablenew2.AddCell(cell);

                    phrase = new Phrase();
                    phrase.Add(new Chunk(Approvalsappliedonline, FontFactory.GetFont("Trebuchet MS", 12, Font.NORMAL, Color.BLACK)));
                    cell = PhraseCellnew(phrase, PdfPCell.ALIGN_RIGHT);
                    tablenew2.AddCell(cell);

                    phrase = new Phrase();
                    phrase.Add(new Chunk(Approvalsdisposedper, FontFactory.GetFont("Trebuchet MS", 12, Font.NORMAL, Color.BLACK)));
                    cell = PhraseCellnew(phrase, PdfPCell.ALIGN_RIGHT);
                    tablenew2.AddCell(cell);

                    phrase = new Phrase();
                    phrase.Add(new Chunk(approvalsgiveninsamedayper, FontFactory.GetFont("Trebuchet MS", 12, Font.NORMAL, Color.BLACK)));
                    cell = PhraseCellnew(phrase, PdfPCell.ALIGN_RIGHT);
                    tablenew2.AddCell(cell);
                }

                var remainingPageSpace = writer.GetVerticalPosition(false) - document.BottomMargin;
                var initialPosition = writer.GetVerticalPosition(false);
                var tablehiht = tablenew2.TotalHeight;
                // ColumnText.ShowTextAligned(PdfStamper.GetUnderContent(document.PageNumber), Element.ALIGN_RIGHT, new Phrase(i.ToString(), blackFont), 568f, 15f, 0);


                if (remainingPageSpace >= tablehiht && remainingPageSpace - 40 <= tablehiht)
                {
                    document.NewPage();
                    contentBytenew.SetColorStroke(color);
                    contentBytenew.Circle(document.PageSize.Width - 23f, document.PageSize.Bottom + 23f, 10f);
                    contentBytenew.Stroke();
                    ColumnText.ShowTextAligned(contentBytenew, Element.ALIGN_RIGHT, new Phrase((writer.PageNumber).ToString(), FontFactory.GetFont("Trebuchet MS", 12, Font.BOLD, Color.BLACK)), document.PageSize.Width - 20f, document.PageSize.Bottom + 20f, 2);
                    document.Add(tablenew2);
                }
                else
                {
                    contentBytenew.SetColorStroke(color);
                    contentBytenew.Circle(document.PageSize.Width - 23f, document.PageSize.Bottom + 23f, 10f);
                    contentBytenew.Stroke();
                    ColumnText.ShowTextAligned(contentBytenew, Element.ALIGN_RIGHT, new Phrase((writer.PageNumber).ToString(), FontFactory.GetFont("Trebuchet MS", 12, Font.BOLD, Color.BLACK)), document.PageSize.Width - 20f, document.PageSize.Bottom + 20f, 2);
                    document.Add(tablenew2);
                }
            }
            document.Close();
            byte[] bytes = memoryStream.ToArray();
            memoryStream.Close();
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=KeyHighlightsCFE.pdf");
            Response.ContentType = "application/pdf";
            Response.Buffer = true;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(bytes);
            Response.End();
            Response.Close();
        }
    }
}



