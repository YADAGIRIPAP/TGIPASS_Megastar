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


public partial class RptCertificatePendencyNew : System.Web.UI.Page
{
    decimal approveddist, approvedstate, tsipassdist, tsipasstate, tsipasspendingdist, tsipasspendingstate;
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
        //    Response.Redirect("../../frmUserLogin.aspx");
        //}
        if (!IsPostBack)
        {
            grdDetails.DataSource = null;
            grdDetails.DataBind();

            if (!IsPostBack)
            {
                if (Request.QueryString["fromdate"] != null && Request.QueryString["fromdate"] != "" && Request.QueryString["todate"] != null && Request.QueryString["todate"] != "")
                {
                    // Label1.Text = "Report from " + Request.QueryString["fromdate"].ToString().Trim() + " To " + Request.QueryString["todate"].ToString().Trim();
                    txtFromDate.Text = Request.QueryString["fromdate"].ToString().Trim();
                    txtTodate.Text = Request.QueryString["todate"].ToString().Trim();
                    fillgrid();
                    AddHeaders();
                }
                else
                {
                    txtFromDate.Text = "01-04-2016";
                    DateTime today = DateTime.Today;
                    txtTodate.Text = today.ToString("dd-MM-yyyy");
                    fillgrid();
                    AddHeaders();
                }
                Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
            }
            //fillgrid();
        }
    }
    #endregion


    protected void AddHeaders()
    {
        if (grdDetails.Rows.Count > 0)
        {
            //This replaces <td> with <th>    
            grdDetails.UseAccessibleHeader = true;
           // grdDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
          //  grdDetails.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

   


    protected void BtnSave_Click(object sender, EventArgs e)
    {
        //fillgrid();

        fillgrid();

    }
    public void fillgrid()
    {
        string FromdateforDB = "", TodateforDB = "";
        if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
        {
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        }
        ds = Gen.GetDistrictWiseCertificateNew("%", FromdateforDB, TodateforDB);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //Label1.Text = "Report from 1st April 2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            Label1.Text = "No Recards Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            decimal approveddist1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Dept Approved dist"));
            approveddist = approveddist1 + approveddist;

            decimal approvedstate1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Dept Approved state"));
            approvedstate = approvedstate1 + approvedstate;

            decimal tsipassdist1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "tsipass Approved dist"));
            tsipassdist = tsipassdist1 + tsipassdist;

            decimal tsipasstate1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "tsipass Approved State"));
            tsipasstate = tsipasstate1 + tsipasstate;

            decimal tsipasspendingdist1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Pending Approved dist"));
            tsipasspendingdist = tsipasspendingdist1 + tsipasspendingdist;


            decimal tsipasspendingstate1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Pending Approved state"));
            tsipasspendingstate = tsipasspendingstate1 + tsipasspendingstate;




            //HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];


            //if (h1.Text != "0")
            //{
            //    h1.NavigateUrl = "RptcertstatusNew.aspx?status=A&dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim() + "&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;
            //}




            //HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];


            //if (h2.Text != "0")
            //{
            //    h2.NavigateUrl = "RptcertstatusNew.aspx?status=B&dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim() + "&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;
            //}




            HyperLink h3 = (HyperLink)e.Row.Cells[2].Controls[0];


            if (h3.Text != "0")
            {
                h3.NavigateUrl = "RptcertstatusNew.aspx?status=C&dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim() + "&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;
            }

            HyperLink h4 = (HyperLink)e.Row.Cells[3].Controls[0];


            if (h4.Text != "0")
            {
                h4.NavigateUrl = "RptcertstatusNew.aspx?status=D&dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim() + "&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;
            }


            //HyperLink h5 = (HyperLink)e.Row.Cells[6].Controls[0];


            //if (h5.Text != "0")
            //{
            //    h5.NavigateUrl = "RptcertstatusNew.aspx?status=E&dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim() + "&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;
            //}

            //HyperLink h6 = (HyperLink)e.Row.Cells[7].Controls[0];


            //if (h6.Text != "0")
            //{
            //    h6.NavigateUrl = "RptcertstatusNew.aspx?status=F&dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim() + "&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;
            //}


        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {

            e.Row.Cells[1].Text = "Total";

            //HyperLink f1 = new HyperLink();


            //if (f1.Text != "0")
            //{
            //    f1.NavigateUrl = "RptcertstatusNew.aspx?status=A&dist=%" + "&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;
            //}




            //HyperLink f2 = new HyperLink();


            //if (f2.Text != "0")
            //{
            //    f2.NavigateUrl = "RptcertstatusNew.aspx?status=B&dist=%" + "&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;
            //}




            HyperLink f3 = new HyperLink();


            if (f3.Text != "0")
            {
                f3.NavigateUrl = "RptcertstatusNew.aspx?status=C&dist=%" + "&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;
            }

            HyperLink f4 = new HyperLink();


            if (f4.Text != "0")
            {
                f4.NavigateUrl = "RptcertstatusNew.aspx?status=D&dist=%" + "&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;
            }



          //  HyperLink f5 = new HyperLink();


            //if (f5.Text != "0")
            //{
            //    f5.NavigateUrl = "RptcertstatusNew.aspx?status=E&dist=%" + "&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;
            //}

            //HyperLink f6 = new HyperLink();


            //if (f6.Text != "0")
            //{
            //    f6.NavigateUrl = "RptcertstatusNew.aspx?status=F&dist=%" + "&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;
            //}



            //f1.Text = approveddist.ToString();
            //f1.ForeColor = System.Drawing.Color.White;
            //e.Row.Cells[2].Controls.Add(f1);
            //f2.Text = approvedstate.ToString();
            //f2.ForeColor = System.Drawing.Color.White;
            //e.Row.Cells[3].Controls.Add(f2);
            f3.Text = tsipassdist.ToString();
            e.Row.Cells[2].Text = tsipassdist.ToString();
            f3.ForeColor = System.Drawing.Color.White;
            e.Row.Cells[2].Controls.Add(f3);
            f4.Text = tsipasstate.ToString();
            e.Row.Cells[3].Text = tsipasstate.ToString();
            f4.ForeColor = System.Drawing.Color.White;
            e.Row.Cells[3].Controls.Add(f4);
            //f5.Text = tsipasspendingdist.ToString();
            //f5.ForeColor = System.Drawing.Color.White;
            //e.Row.Cells[6].Controls.Add(f5);
            //f6.Text = tsipasspendingstate.ToString();
            //f6.ForeColor = System.Drawing.Color.White;
            //e.Row.Cells[7].Controls.Add(f6);
        }
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
                if (i == 2 || i == 3 || i == 4 || i == 5 || i == 6 || i == 7)
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


            //TableCell tcMergePackage = new TableCell();
            //tcMergePackage.Text = "Numberof application where all approvals are given";
            //tcMergePackage.CssClass = "GridviewScrollC1Headerwrap";
            //tcMergePackage.ColumnSpan = 2;
            //gvHeaderRowCopy.Cells.AddAt(2, tcMergePackage);

            TableCell tcMergePackage1 = new TableCell();
            tcMergePackage1.Text = "Number of applications where TSiPASS approval is generated";
            tcMergePackage1.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage1.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(2, tcMergePackage1);

            //TableCell tcMergePackage2 = new TableCell();
            //tcMergePackage2.Text = "Number of Applications where TSiPASS approvals is yet to be generated";
            //tcMergePackage2.CssClass = "GridviewScrollC1Headerwrap";
            //tcMergePackage2.ColumnSpan = 2;
            //gvHeaderRowCopy.Cells.AddAt(4, tcMergePackage2);

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
            string FileName = lblHeading.Text;
            FileName = FileName.Replace(" ", "");
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName + DateTime.Now.ToString("M/d/yyyy") + ".xls");
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
    protected void btnGet_Click(object sender, EventArgs e)
    {
         int valid = 0;
        Failure.Visible = false;
        lblmsg0.Text = "";
        if (txtFromDate.Text == "" || txtFromDate.Text == null)
        {
            lblmsg0.Text = "Please Enter From Date ";
            valid = 1;
        }
        if (txtTodate.Text == "" || txtTodate.Text == null)
        {
            lblmsg0.Text += "Please Enter To Date";
            valid = 1;
        }
        if (valid == 0)
        {
            string fromdt = "", Todt = "";
            fromdt = Convert.ToDateTime(txtFromDate.Text.Trim()).ToString("dd-MMM-yyyy");
            Todt = Convert.ToDateTime(txtTodate.Text.Trim()).ToString("dd-MMM-yyyy");
            Label1.Text = "Report from " + fromdt + " to " + Todt;
            fillgrid();
        }
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

            string tcMergePackage = "Report From " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
            //------------------------------------------------------------------------------------------------------------------------------------------------------
            phrase = new Phrase();
            phrase.Add(new Chunk("R1.4: TSiPASS Approval Generation Status\n\n", FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));
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

            phrase = new Phrase();
            phrase.Add(new Chunk("Number of applications where TSiPASS approval is generated ", FontFactory.GetFont("trebuchet ms", 12, Font.NORMAL, Color.BLACK)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = PdfCell.ALIGN_LEFT;
            cell.Colspan = 3;
            cell.PaddingTop = 0f;
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
                //else if (runs == 1)
                //{
                //    terms[runs] = 20f;
                //}
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
                        phrase = new Phrase();

                        if (j == 0)
                        {
                            cellText = (i + 1).ToString();
                        }
                        else if (j == 1)
                        {
                            cellText = Server.HtmlDecode(grdDetails.Rows[i].Cells[j].Text);
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

                // cellText = Server.HtmlDecode(grdDetails.Columns[i].FooterText);
                cellText = Server.HtmlDecode(grdDetails.FooterRow.Cells[i].Text);

                phrase = new Phrase();
                phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
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
}
