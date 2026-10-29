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

public partial class UI_TSiPASS_IPO_DrilldownReport : System.Web.UI.Page
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
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");

        }
        if (!IsPostBack)
        {
           
            if (Request.QueryString["dist"] != null && Request.QueryString["dist"] != "" && Request.QueryString["User"] != null && Request.QueryString["User"] != "")
            {
                string dist = Request.QueryString["dist"].ToString().Trim();
                
                string year= Request.QueryString["year"].ToString().Trim();
                string month= Request.QueryString["month"].ToString().Trim();
            }

            string User = Request.QueryString["User"].ToString().Trim();
            if (User == "IPO")
            {
                lblHeading1.Visible = true;
            }
            else if (User == "AD")
            {
                lblHeading2.Visible = true;
            }
            else if (User == "DD")
            {
                lblHeading3.Visible = true;
            }
            else if (User == "TOTAL")
            {
                lblHeading4.Visible = true;
            }






            //if (Request.QueryString["fromdate"] != null && Request.QueryString["fromdate"] != "" && Request.QueryString["todate"] != null && Request.QueryString["todate"] != "")
            //{
            //    txtFromDate.Text = Request.QueryString["fromdate"].ToString().Trim();
            //    txtTodate.Text = Request.QueryString["todate"].ToString().Trim();

            //}
            //else
            //{
            //    txtFromDate.Text = "15-02-2020";
            //    DateTime today = DateTime.Today;
            //    txtTodate.Text = today.ToString("dd-MM-yyyy");
            //    //fillgrid();
            //}

            //if (txtFromDate.Text.Trim() != "" && txtTodate.Text.Trim() != "")
            //    Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();


            fillgrid();
        }

    }
    #endregion

    public void fillgrid()
    {
        Label1.Text = "";
        DataSet dsnew = new DataSet();
        string FromdateforDB = "", TodateforDB = "", UserId = "", Month = "", Year = "", DistrictId = "";
        //if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
        //{
        //    FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        //    TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        //}
        // dsnew = Gen.FetchTotalDistrictwise_New_New(ddlType.SelectedValue, FromdateforDB , TodateforDB);
        dsnew = Gen.FetchTotalDistrictwise_IPO(Request.QueryString["month"].ToString().Trim(), Request.QueryString["year"].ToString().Trim(), Request.QueryString["dist"].ToString().Trim(), Request.QueryString["User"].ToString().Trim(), Request.QueryString["View"].ToString().Trim());
        //DataSet ds = new DataSet();
        //ds = Gen.GetmodifiedDate();
        //Label2.Text = "Last Updated on : " + ds.Tables[0].Rows[0]["ModifiedDate"].ToString().Trim();
        // lblMsg.Text = "";
        if (dsnew.Tables[0].Rows.Count > 0)
        {
            if(Request.QueryString["View"].ToString().Trim()== "NOTUPDATED")
            {
                grdDetails.DataSource = dsnew.Tables[0];
                grdDetails.DataBind();
                GridPrint.Visible = true;
                Button2.Visible = true;
            }

            else
            {
                GridView1.DataSource = dsnew.Tables[0];
                GridView1.DataBind();
                grid2.Visible = true;
                grd2pdf.Visible = true;
            }
           
           
           

        }
        else
        {
            
            Label1.Text = "No Records Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
            

        }

    }
    private void BindPieChart()
    {
        DataTable dsChartData = new DataTable();
        StringBuilder strScript = new StringBuilder();

        try
        {
            string FromdateforDB = "", TodateforDB = "";
            if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
            {
                FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }
            dsChartData = Gen.FetchTotalDistrictwise_New_New(ddlType.SelectedValue, FromdateforDB, TodateforDB, ddlEnterPriseType.SelectedValue, Request.QueryString["dist"].ToString().Trim()).Tables[0];

            strScript.Append(@"<script type='text/javascript'>  
                    google.load('visualization', '1', {packages: ['corechart']}); </script>  
                      
                    <script type='text/javascript'>  
                     
                    function drawChart() {         
                    var data = google.visualization.arrayToDataTable([  
                    ['District', 'Number'],");

            foreach (DataRow row in dsChartData.Rows)
            {
                strScript.Append("['" + row["District"] + "'," + row["Number"] + "],");
            }
            strScript.Remove(strScript.Length - 1, 1);
            strScript.Append("]);");

            strScript.Append(@" var options = {     
                                    title: 'No of Industries/ District',            
                                    pieSliceText: 'value',
                                    legend: { position: 'bottom', maxLines: 5 },
                                    tooltip: {textStyle: {color: '#FF0000'}, showColorCode: true},    
                                    chartArea:{left:20,top:30,width:'100%',height:'75%'}             
                                    };   ");

            strScript.Append(@"var chart = new google.visualization.PieChart(document.getElementById('piechart_3d'));          
                                chart.draw(data, options);        
                                }    
                            google.setOnLoadCallback(drawChart);  
                            ");
            strScript.Append(" </script>");


            ltrPie.Text = strScript.ToString();

        }
        catch
        {
        }
        finally
        {
            dsChartData.Dispose();

        }

    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //decimal NumberTotal1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Number"));
            //NumberTotal = NumberTotal1 + NumberTotal;

            //decimal InvestmnetTotal1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Investment"));
            //InvestmnetTotal = InvestmnetTotal1 + InvestmnetTotal;


            //decimal EmploymentTotal1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Employment"));
            //EmploymentTotal = EmploymentTotal1 + EmploymentTotal;


            //HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];

            //h1.NavigateUrl = "FrmDistDrilldownold2New.aspx?status=" + ddlType.SelectedValue.ToString() + "&lbl=Application Received&dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District")).Trim() + "&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&Enttype=" + ddlEnterPriseType.SelectedValue;

            //HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];

            //h2.NavigateUrl = "FrmDistDrilldownold2New.aspx?status=" + ddlType.SelectedValue.ToString() + "&lbl=Application Received&dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District")).Trim() + "&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&Enttype=" + ddlEnterPriseType.SelectedValue;

            //HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];

            //h3.NavigateUrl = "FrmDistDrilldownold2New.aspx?status=" + ddlType.SelectedValue.ToString() + "&lbl=Application Received&dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District")).Trim() + "&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&Enttype=" + ddlEnterPriseType.SelectedValue;



        }

        //if (e.Row.RowType == DataControlRowType.Footer)
        //{

        //    e.Row.Cells[1].Text = "Total";
        //    // Label lblTotal = new Label();
        //    HyperLink Total = new HyperLink();
        //    Total.ForeColor = System.Drawing.Color.White;
        //    Total.NavigateUrl = "FrmDistDrilldownold2New.aspx?status=" + ddlType.SelectedValue.ToString() + "&lbl=Total Applications Received&dist=%" + "&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;
        //    Total.Text = NumberTotal.ToString();
        //    //e.Row.Cells[2].Controls.RemoveAt(0);
        //    //lblTotal.Text = NumberTotal.ToString();
        //    e.Row.Cells[2].Text = NumberTotal.ToString();
        //    e.Row.Cells[2].Controls.Add(Total);
        //    // e.Row.Cells[2].Controls.Add(lblTotal);
        //    //e.Row.Cells[2].Text = NumberTotal.ToString();
        //    e.Row.Cells[3].Text = InvestmnetTotal.ToString();
        //    e.Row.Cells[4].Text = EmploymentTotal.ToString();
        //    //lblTotal.Visible = false;
        //}
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grdDetails.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    { }

    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
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
                Government.Visible = true;
                divPrint1.Style["width"] = "680px";
                Button1.Visible = false;
                Button2.Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                divPrint1.RenderControl(hw);
                string label1text = Label1.Text;
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='5'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='5'><h4>" + label1text + "</h4></td></td></tr></table>";
                HttpContext.Current.Response.Write(headerTable);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
            //Button1.Visible = true;
            //Button2.Visible = true;
        }
        catch (Exception e)
        {

        }
    }

    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        int valid = 0;
        lblmsg0.Text = "";
        Failure.Visible = false;
        if (ddlType.SelectedValue == "--Select--")//!= "3" && ddlType.SelectedValue == "1")
        {
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
        }
        if (valid == 0)
        {
            fillgrid();
        }
        else
        {
            Failure.Visible = true;
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
    }

    protected void ExportToExcel(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=R6.1:TSiPASS-DistrictWiseReport.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        Government.Visible = true;
        divPrint1.Style["width"] = "680px";
        Button1.Visible = false;
        Button2.Visible = false;
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            grdDetails.AllowPaging = false;
            //this.fillgrid();

            //grdDetails.HeaderRow.BackColor = System.Drawing.Color.White;
            //foreach (TableCell cell in grdDetails.HeaderRow.Cells)
            //{
            //    cell.ForeColor = System.Drawing.Color.Black;
            //}
            //foreach (TableCell cell in grdDetails.FooterRow.Cells)
            //{
            //    cell.BackColor = System.Drawing.Color.White;
            //    cell.ForeColor = System.Drawing.Color.Black;
            //}


            //foreach (TableCell cell in grdDetails.FooterRow.Cells)
            //{

            //    cell.CssClass = "textmode";
            //    List<Control> controls = new List<Control>();
            //    foreach (Control control in cell.Controls)
            //    {
            //        switch (control.GetType().Name)
            //        {
            //            case "HyperLink":
            //                controls.Add(control);
            //                break;
            //            case "TextBox":
            //                controls.Add(control);
            //                break;
            //            case "LinkButton":
            //                controls.Add(control);
            //                break;
            //            case "CheckBox":
            //                controls.Add(control);
            //                break;
            //            case "RadioButton":
            //                controls.Add(control);
            //                break;
            //        }
            //    }
            //    foreach (Control control in controls)
            //    {
            //        switch (control.GetType().Name)
            //        {
            //            case "HyperLink":
            //                cell.Controls.Add(new Literal { Text = (control as HyperLink).Text });
            //                break;
            //            case "TextBox":
            //                cell.Controls.Add(new Literal { Text = (control as TextBox).Text });
            //                break;
            //            case "LinkButton":
            //                cell.Controls.Add(new Literal { Text = (control as LinkButton).Text });
            //                break;
            //            case "CheckBox":
            //                cell.Controls.Add(new Literal { Text = (control as CheckBox).Text });
            //                break;
            //            case "RadioButton":
            //                cell.Controls.Add(new Literal { Text = (control as RadioButton).Text });
            //                break;
            //        }
            //        cell.Controls.Remove(control);
            //    }
            //}
            //foreach (GridViewRow row in grdDetails.Rows)
            //{
            //    row.BackColor = System.Drawing.Color.White;
            //    foreach (TableCell cell in row.Cells)
            //    {
            //        if (row.RowIndex % 2 == 0)
            //        {
            //            cell.BackColor = grdDetails.AlternatingRowStyle.BackColor;
            //        }
            //        else
            //        {
            //            cell.BackColor = grdDetails.RowStyle.BackColor;
            //        }
            //        cell.CssClass = "textmode";
            //        List<Control> controls = new List<Control>();
            //        foreach (Control control in cell.Controls)
            //        {
            //            switch (control.GetType().Name)
            //            {
            //                case "HyperLink":
            //                    controls.Add(control);
            //                    break;
            //                case "TextBox":
            //                    controls.Add(control);
            //                    break;
            //                case "LinkButton":
            //                    controls.Add(control);
            //                    break;
            //                case "CheckBox":
            //                    controls.Add(control);
            //                    break;
            //                case "RadioButton":
            //                    controls.Add(control);
            //                    break;
            //            }
            //        }
            //        foreach (Control control in controls)
            //        {
            //            switch (control.GetType().Name)
            //            {
            //                case "HyperLink":
            //                    cell.Controls.Add(new Literal { Text = (control as HyperLink).Text });
            //                    break;
            //                case "TextBox":
            //                    cell.Controls.Add(new Literal { Text = (control as TextBox).Text });
            //                    break;
            //                case "LinkButton":
            //                    cell.Controls.Add(new Literal { Text = (control as LinkButton).Text });
            //                    break;
            //                case "CheckBox":
            //                    cell.Controls.Add(new Literal { Text = (control as CheckBox).Text });
            //                    break;
            //                case "RadioButton":
            //                    cell.Controls.Add(new Literal { Text = (control as RadioButton).Text });
            //                    break;
            //            }
            //            cell.Controls.Remove(control);
            //        }
            //    }
            //}

            divPrint1.RenderControl(hw);

            //style to format numbers to string
            //string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            //Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
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
                Response.AddHeader("content-disposition", "attachment;filename=R6.1:TSiPASS-TotalReportold2NewReport" + ".pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.Flush();
                Response.End();
            }
        }
    }

    protected void BtnPDF1_Click(object sender, EventArgs e)
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
                GridView1.AllowPaging = false;

                this.fillgrid();

                GridView1.HeaderRow.ForeColor = System.Drawing.Color.Black;
                GridView1.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                GridView1.FooterRow.ForeColor = System.Drawing.Color.Black;
                // grdExport.Columns[1].Visible = false;
                GridView1.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=R6.1:TSiPASS-TotalReportold2NewReport" + ".pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.Flush();
                Response.End();
            }
        }
    }
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlType.SelectedValue != "--Select--")
        {
            tdFromDate.Visible = false;
            tdToDate.Visible = false;
            txtFromDate.Text = "";
            txtTodate.Text = "";
        }
        else
        {
            tdFromDate.Visible = true;
            tdToDate.Visible = true;
            txtFromDate.Text = "";
            txtTodate.Text = "";
        }
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
            string FromdateforDB = "", TodateforDB = "", monthName = "", monthName1 = "";
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
            phrase.Add(new Chunk("R6.1 District wise Abstract Report \n\n", FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));
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


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        HyperLink h3 = (HyperLink)e.Row.FindControl("hprlink");

        string hyperLnk1 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ATTACHMENT"));

        if (hyperLnk1 != "")
        {
            h3.Text = "View";
            h3.Visible = true;

        }
      
    }
}
