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

using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Data.SqlClient;
//created by suresh as on 1-17-2016 for county adm lookup 
//tables td_CountyAdmDet,getCASearch

public partial class UI_TSiPASS_IncentiveAbstractReport : System.Web.UI.Page
{

    int Yet_to_Start1, Yet_to_Start2, Yet_to_Start3, Yet_to_Start4, Yet_to_Start5, Yet_to_Start6, Yet_to_Start7, Yet_to_Start8;


    General gen = new General();
    General Gen = new General();
    int Sno = 0;

    DataSet ds;
    DataTable dt;
    int valid = 0;
    string FromdateforDB = "", TodateforDB = "";
    DataSet dslist;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {
            //if (Session["DistrictID"] != null && Session["DistrictID"].ToString() != "")
            //{
            //  ddlProp_intDistrictid.SelectedValue = Session["DistrictID"].ToString();
            //ddlProp_intDistrictid.Enabled = false;
            //}
            //else
            //{
            //  ddlProp_intDistrictid.Enabled = true;
            //}
            BindDistricts();
            getdistricts();
            txtFromDate.Text = "01-04-2016";
            DateTime today = DateTime.Today;
            txtTodate.Text = today.ToString("dd-MM-yyyy");
            if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
            {
                FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }
            if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
            {
                ddlProp_intDistrictid.SelectedValue = Session["DistrictID"].ToString().Trim();
                ddlProp_intDistrictid.Enabled = false;
            }
            else
            {
                ddlProp_intDistrictid.SelectedIndex = 0;
            }
            fillgrid();
        }
    }
    private void getdistricts()
    {
        DataSet dsnew = new DataSet();

        dsnew = Gen.GetDistricts();
        //ddlProp_intDistrictid.DataSource = dsnew.Tables[0];
        //ddlProp_intDistrictid.DataTextField = "District_Name";
        //ddlProp_intDistrictid.DataValueField = "District_Id";
        //ddlProp_intDistrictid.DataBind();
        //ddlProp_intDistrictid.Items.Insert(0, "--ALL--");

    }
    protected void btnGet_Click(object sender, EventArgs e)
    {
        fillgrid();
    }

    protected void BtnSave1_Click(object sender, EventArgs e)
    {

        lblmsg0.Text = "";
        Failure.Visible = false;


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
            fillgrid();
        }
        else
        {
            Failure.Visible = true;
        }
    }
    public void fillgrid()
    {
        DataSet dsnew = new DataSet();
        string ReleaseProceedingNo = "";
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
        dsnew = GetAppealApplications(FromdateforDB, TodateforDB,ddlProp_intDistrictid.SelectedValue);
        // lblMsg.Text = "";
        if (dsnew.Tables[0].Rows.Count > 0)
        {
            // lblMsg.Text = "Total Records :" +dsnew.Tables[0].Rows.Count.ToString();
            grdDetails.DataSource = dsnew.Tables[0];
            grdDetails.DataBind();
            bindgrdDetailsfooter(dsnew.Tables[0]);
        }
        else
        {
            //lblMsg.Text = "";
            // Label1.Text = "No Recards Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
    }


    public void bindgrdDetailsfooter(DataTable dtt)
    {
        decimal TOTALAPP = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Total Application")));
        decimal TOTREJECTED = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Total Rejected")));
        decimal SCRUTINYPENDINGWITHIN = dtt.AsEnumerable().Sum(rows => Convert.ToInt32(rows.Field<object>("Scrutiny Completed Within")));
        decimal SCRUTINYPENDINGBEYOND = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Scrutiny Completed Beyond")));
        decimal SCRUTINYPENDINGTOTAL = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Total Scrutiny Completed")));
        decimal SCRUTINYPENWITHIN = dtt.AsEnumerable().Sum(rows => Convert.ToInt32(rows.Field<object>("Scrutiny Pending Within")));
        decimal SCRUTINYBEYOND = dtt.AsEnumerable().Sum(rows => Convert.ToInt32(rows.Field<object>("Scrutiny Pending Beyond")));
        decimal TOTALSCRUTINYCOMPLETED = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Scrutiny Total Pending")));

        decimal INSPECTIONPENDINGWITHIN = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Inspection Completed Within")));
        decimal INSPECTIONPENDINGBEYOND = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Inspection Completed Beyond")));
        decimal INSPECTIONPENDINGTOTAL = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Inspection Completed Total")));
        decimal INSPECTIONWITHIN = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Inspection Pending Within")));
        decimal INSPECTIONBEYOND = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Inspection Pending Beyond")));
        decimal INSPECTIONTOTAL = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Inspection Pending Total")));

        decimal REFEREDPENDINGWITHIN = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Refered COI Within")));
        decimal REFEREDPENDINGBEYOND = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Refered COI Beyond")));
        decimal REFEREDPENDINGTOTAL = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Refered COI Total")));
        decimal REFEREDCOIWITHIN = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Refered Pending COI Within")));
        decimal REFEREDCOIBEYOND = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Refered Pending COI Beyond")));
        decimal REFERREDCOITOTAL = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Refered Pending COI Total")));

        decimal DLCPENDINGWITHIN = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("DLC Approved Within")));
        decimal DLCPENDINGBEYOND = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("DLC Approved Beyond")));
        decimal DLCPENDINGTOTAL = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Total DLC Approved")));
        decimal TOTALDLCWITHIN = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("DLC Pending Within")));
        decimal TOTALDLCBEYOND = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("DLC Pending Beyond")));
        decimal TOTALDLCAPPROVED = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Total DLC Pending")));
        //decimal NO_of_UnitsPER = decimal.Round((Working_Units_SLC / (NO_UNITS_SLC == 0 ? 1 : NO_UNITS_SLC)) * 100, 2, MidpointRounding.AwayFromZero);
        //decimal NO_of_Units_amountPER = decimal.Round((UC_Not_Updated_AMOUNT_SLC / (AMOUNT_RELEASED_SLC == 0 ? 1 : AMOUNT_RELEASED_SLC)) * 100, 2, MidpointRounding.AwayFromZero);

        grdDetails.FooterRow.HorizontalAlign = HorizontalAlign.Right;
        grdDetails.FooterRow.Font.Bold = true;
        grdDetails.FooterRow.Cells[1].Text = "Total";
        grdDetails.FooterRow.Cells[2].Text = TOTALAPP.ToString();
        grdDetails.FooterRow.Cells[3].Text = TOTREJECTED.ToString();
        grdDetails.FooterRow.Cells[4].Text = SCRUTINYPENDINGWITHIN.ToString();
        grdDetails.FooterRow.Cells[5].Text = SCRUTINYPENDINGBEYOND.ToString();
        grdDetails.FooterRow.Cells[6].Text = SCRUTINYPENDINGTOTAL.ToString();
        grdDetails.FooterRow.Cells[7].Text = SCRUTINYPENWITHIN.ToString();
        grdDetails.FooterRow.Cells[8].Text = SCRUTINYBEYOND.ToString();
        grdDetails.FooterRow.Cells[9].Text = TOTALSCRUTINYCOMPLETED.ToString();

        grdDetails.FooterRow.Cells[10].Text = INSPECTIONPENDINGWITHIN.ToString();
        grdDetails.FooterRow.Cells[11].Text = INSPECTIONPENDINGBEYOND.ToString();
        grdDetails.FooterRow.Cells[12].Text = INSPECTIONPENDINGTOTAL.ToString();
        grdDetails.FooterRow.Cells[13].Text = INSPECTIONWITHIN.ToString();
        grdDetails.FooterRow.Cells[14].Text = INSPECTIONBEYOND.ToString();
        grdDetails.FooterRow.Cells[15].Text = INSPECTIONTOTAL.ToString();

        grdDetails.FooterRow.Cells[16].Text = REFEREDPENDINGWITHIN.ToString();
        grdDetails.FooterRow.Cells[17].Text = REFEREDPENDINGBEYOND.ToString();
        grdDetails.FooterRow.Cells[18].Text = REFEREDPENDINGTOTAL.ToString();
        grdDetails.FooterRow.Cells[19].Text = REFEREDCOIWITHIN.ToString();
        grdDetails.FooterRow.Cells[20].Text = REFEREDCOIBEYOND.ToString();
        grdDetails.FooterRow.Cells[21].Text = REFERREDCOITOTAL.ToString();

        grdDetails.FooterRow.Cells[22].Text = DLCPENDINGWITHIN.ToString();
        grdDetails.FooterRow.Cells[23].Text = DLCPENDINGBEYOND.ToString();
        grdDetails.FooterRow.Cells[24].Text = DLCPENDINGTOTAL.ToString();
        grdDetails.FooterRow.Cells[25].Text = TOTALDLCWITHIN.ToString();
        grdDetails.FooterRow.Cells[26].Text = TOTALDLCBEYOND.ToString();
        grdDetails.FooterRow.Cells[27].Text = TOTALDLCAPPROVED.ToString();
    }

    public DataSet GetAppealApplications(string fromdate, string todate,string district)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
             new SqlParameter("@FROMDATE",SqlDbType.VarChar),
                new SqlParameter("@TODATE",SqlDbType.VarChar),
               new SqlParameter("@DISTRICT",SqlDbType.VarChar)
               
           };
        pp[0].Value = fromdate;
        pp[1].Value = todate;
        pp[2].Value = district;


        Dsnew = gen.GenericFillDs("USP_GET_Incentives_ReportCompleted", pp);
        return Dsnew;
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
            Response.AddHeader("content-disposition", "attachment;filename=Report.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            //  Government.Visible = true;
            divPrint.Style["width"] = "680px";
            // Button1.Visible = false;
            //Button2.Visible = false;
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                grdDetails.AllowPaging = false;
                this.fillgrid();

                grdDetails.HeaderRow.BackColor = System.Drawing.Color.White;
                foreach (TableCell cell in grdDetails.HeaderRow.Cells)
                {
                    cell.BackColor = grdDetails.HeaderStyle.BackColor;
                    cell.ForeColor = System.Drawing.Color.White;
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
            //Response.Clear();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment;filename=Report " + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-excel";
            //using (StringWriter sw = new StringWriter())
            //{
            //    Button2.Visible = false;
            //    Button1.Visible = false;
            //    HtmlTextWriter hw = new HtmlTextWriter(sw);
            //    divPrint.RenderControl(hw);
            //    Response.Output.Write(sw.ToString());
            //    Response.Flush();
            //    Response.End();
            //}
        }
        catch (Exception e)
        {

        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    //protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.Header)
    //    {
    //        GridViewRow gvHeaderRow = e.Row;
    //        GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

    //        this.grdDetails.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

    //        int headerCellCount = gvHeaderRow.Cells.Count;
    //        int cellIndex = 0;

    //        for (int i = 0; i < headerCellCount; i++)
    //        {
    //            if (i == 5 || i == 6)
    //            {
    //                cellIndex++;
    //            }
    //            else
    //            {
    //                TableCell tcHeader = gvHeaderRow.Cells[cellIndex];
    //                tcHeader.RowSpan = 2;
    //                gvHeaderRowCopy.Cells.Add(tcHeader);
    //            }
    //        }

    //        TableCell tcMergePackage = new TableCell();
    //        tcMergePackage.Text = "UC Updated";
    //        tcMergePackage.CssClass = "GridviewScrollC1Headerwrap";
    //        tcMergePackage.ColumnSpan = 2;
    //        gvHeaderRowCopy.Cells.AddAt(5, tcMergePackage);
    //    }
    //}

    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        PrintPdf();
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

            string tcMergePackage = "";
            //------------------------------------------------------------------------------------------------------------------------------------------------------
            phrase = new Phrase();
            phrase.Add(new Chunk("R2.2: Release Proceedings Abstarct - District Wise - SLC\n\n", FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));
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
                    terms[runs] = 10f;
                }
                else if (runs == 2)
                {
                    terms[runs] = 20f;
                }
                else
                {
                    double valus = 65 / CountColumns;
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
            cellTextnew = "UC UPADTED";
            phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails.HeaderStyle.BackColor);  //#009688
            cell.PaddingBottom = 5;
            cell.Colspan = 2;
            cell.MinimumHeight = 30f;
            tablenew.AddCell(cell);



            phrase = new Phrase();
            cellTextnew = "";
            phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails.HeaderStyle.BackColor);  //#009688
            cell.PaddingBottom = 5;
            cell.Colspan = 1;
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
                        else if (j == 1 || j == 2 || j == 4)
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
                        else if (j == 1 || j == 2)
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
                    cellTextnew = "UC UPADTED";
                    phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                    cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails.HeaderStyle.BackColor);  //#009688
                    cell.PaddingBottom = 5;
                    cell.Colspan = 2;
                    cell.MinimumHeight = 30f;
                    tablenew.AddCell(cell);



                    phrase = new Phrase();
                    cellTextnew = "";
                    phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                    cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails.HeaderStyle.BackColor);  //#009688
                    cell.PaddingBottom = 5;
                    cell.Colspan = 1;
                    cell.MinimumHeight = 30f;
                    tablenew.AddCell(cell);

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

                cellText = Server.HtmlDecode(grdDetails.Columns[i].FooterText);

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
            Response.AddHeader("Content-Disposition", "attachment; filename=Report" + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
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

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //decimal NumberofApprovalsappliedfor = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total Application received"));
            //NumberofApprovalsappliedfor1 = NumberofApprovalsappliedfor + NumberofApprovalsappliedfor1;

            //decimal Completed = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total Investments"));
            //Completed1 = Completed + Completed1;


            //decimal QueryRaised = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total deptl Approvals Required"));
            //QueryRaised1 = QueryRaised + QueryRaised1;


            //decimal Pendinglessthan3days = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Deptl Approvals already taken by applicant"));
            //Pendinglessthan3days1 = Pendinglessthan3days + Pendinglessthan3days1;

            //decimal Pendingmorthan3days = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Deptl Approvals Applied by applicant"));
            //Pendingmorthan3days1 = Pendingmorthan3days + Pendingmorthan3days1;


            //decimal Numberofpaymentreceivedfor = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Net Approvals required"));
            //Numberofpaymentreceivedfor1 = Numberofpaymentreceivedfor + Numberofpaymentreceivedfor1;

            //decimal Numberofpaymentreceivedfor11 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Deptl Approvals Pending"));
            //Numberofpaymentreceivedfor12 = Numberofpaymentreceivedfor11 + Numberofpaymentreceivedfor12;

            //decimal Numberofpaymentreceivedfor21 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Deptl Approvals Issued"));
            //Numberofpaymentreceivedfor22 = Numberofpaymentreceivedfor21 + Numberofpaymentreceivedfor22;

            //decimal Numberofpaymentreceivedfor23 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TS-iPASS Approvals"));
            //Numberofpaymentreceivedfor24 = Numberofpaymentreceivedfor23 + Numberofpaymentreceivedfor24;



            //Label lblDistId = (e.Row.FindControl("lblDistId") as Label);

            //HyperLink h1 = (HyperLink)e.Row.Cells[1].Controls[0];
            ////HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            ////HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            ////h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            //h1.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=1&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;

            ////HyperLink h2 = (HyperLink)e.Row.Cells[4].Controls[0];
            //////HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //////HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            ////h2.Target = "_blank";
            //////h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            ////h2.NavigateUrl = "frmYearstatusNew.aspx?status=B&lbl=Approvals Required&dist=" + ddldistrict.SelectedValue + "&cate=" + ddlCategory.SelectedItem.Text;// +Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intmandalId")).Trim();

            ////HyperLink h3 = (HyperLink)e.Row.Cells[5].Controls[0];
            //////HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //////HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            ////h3.Target = "_blank";
            //////h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            ////h3.NavigateUrl = "frmYearstatusNew.aspx?status=C&lbl=Approvals Already Taken By Applicant&dist=" + ddldistrict.SelectedValue + "&cate=" + ddlCategory.SelectedItem.Text;// +Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intmandalId")).Trim();

            ////HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
            //////HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //////HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            ////h4.Target = "_blank";
            //////h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            ////h4.NavigateUrl = "frmYearstatusNew.aspx?status=D&lbl=Net Approvals Required&dist=" + ddldistrict.SelectedValue+"&cate="+ddlCategory.SelectedItem.Text;// +Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intmandalId")).Trim();

            //HyperLink h5 = (HyperLink)e.Row.Cells[1].Controls[0];
            ////HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            ////HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            ////h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            //h5.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=2&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text; //+"&District=" + lblDistId;

            //HyperLink h5a = (HyperLink)e.Row.Cells[2].Controls[0];
            ////HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            ////HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            ////h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            //h5a.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=3&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text; // +"&District=" + lblDistId;

            //HyperLink h5b = (HyperLink)e.Row.Cells[3].Controls[0];
            ////HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            ////HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            ////h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            //h5b.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=4&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text; //+"&District=" + lblDistId;

            //HyperLink h6 = (HyperLink)e.Row.Cells[4].Controls[0];
            ////HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            ////HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            ////h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            //h6.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=5&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text; //+"&District=" + lblDistId;

            //HyperLink h6a = (HyperLink)e.Row.Cells[5].Controls[0];
            //h6a.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=6&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;// +"&District=" + lblDistId;

            //HyperLink h6b = (HyperLink)e.Row.Cells[7].Controls[0];
            //h6b.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=7&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;// +"&District=" + lblDistId;

            //HyperLink h6c = (HyperLink)e.Row.Cells[8].Controls[0];
            //h6c.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=8&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;// +"&District=" + lblDistId;

            //HyperLink h6kl = (HyperLink)e.Row.Cells[9].Controls[0];
            //h6kl.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=9&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;// +"&District=" + lblDistId;

            //HyperLink h6ml = (HyperLink)e.Row.Cells[6].Controls[0];
            //h6ml.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=10&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;// +"&District=" + lblDistId;

            //HyperLink h6Nl = (HyperLink)e.Row.Cells[10].Controls[0];
            //h6Nl.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=11&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;// +"&District=" + lblDistId;

            ////HyperLink h6a = (HyperLink)e.Row.Cells[5].Controls[0];
            ////HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            ////HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            ////h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            ////h6a.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=6&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;

            ////HyperLink h6b = (HyperLink)e.Row.Cells[6].Controls[0];
            ////HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            ////HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            ////h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            ////h6b.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=7&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;

            ////HyperLink h6c = (HyperLink)e.Row.Cells[7].Controls[0];
            ////HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            ////HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            ////h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            ////h6c.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=8&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;

            //// HyperLink h5c = (HyperLink)e.Row.Cells[10].Controls[0];
            ////HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            ////HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            ////h5c.Target = "_blank";
            //////h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            ////h5c.NavigateUrl = "frmYearstatusNew.aspx?status=I&lbl=TS-IPASS Approvals&dist=" + ddldistrict.SelectedValue+"&cate="+ddlCategory.SelectedItem.Text;// +Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intmandalId")).Trim();


        }
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            // dynamic clr = ColorTranslator.FromHtml("#006");
            // HeaderRow.BackColor = Color.White;
            HeaderRow.Font.Bold = true;
            HeaderRow.Font.Size = 11;
            //HeaderRow.ForeColor = clr;
            //  "#B2BECD"
            TableCell Cell_Header = new TableCell();
            Cell_Header.Text = "";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 4;
            Cell_Header.Font.Bold = false;
            HeaderRow.Cells.Add(Cell_Header);


            Cell_Header = new TableCell();
            Cell_Header.Text = "SCRUTINY STAGE";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 6;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "INSPECTION STAGE";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 6;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "COI STAGE";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 6;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "DLC STAGE";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 6;
            HeaderRow.Cells.Add(Cell_Header);

            grdDetails.Controls[0].Controls.AddAt(0, HeaderRow);
        }
    }

    protected void grdDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string divid = e.CommandArgument.ToString();
        if (e.CommandName == "TOTALAPP")
        {
            Response.Redirect("IncentiveAbstractionRptDrill.aspx?type=1&status=1&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + divid);
        }
        else if (e.CommandName == "TOTREJECTED")
        {
            Response.Redirect("IncentiveAbstractionRptDrill.aspx?type=1&status=11&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + divid);
        }
        else if (e.CommandName == "SCRUTINYPENWITHIN")
        {
            Response.Redirect("IncentiveAbstractionRptDrill.aspx?type=1&status=5&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + divid);
        }
        else if (e.CommandName == "SCRUTINYBEYOND")
        {
            Response.Redirect("IncentiveAbstractionRptDrill.aspx?type=1&status=6&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + divid);
        }
        else if (e.CommandName == "TOTALSCRUTINYCOMPLETED")
        {
            Response.Redirect("IncentiveAbstractionRptDrill.aspx?type=1&status=7&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + divid);
        }
        else if (e.CommandName == "SCRUTINYPENDINGWITHIN")
        {
            Response.Redirect("IncentiveAbstractionRptDrill.aspx?type=1&status=2&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + divid);
        }
        else if (e.CommandName == "SCRUTINYPENDINGBEYOND")
        {
            Response.Redirect("IncentiveAbstractionRptDrill.aspx?type=1&status=3&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + divid);
        }
        else if (e.CommandName == "SCRUTINYPENDINGTOTAL")
        {
            Response.Redirect("IncentiveAbstractionRptDrill.aspx?type=1&status=4&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + divid);
        }
        else if (e.CommandName == "INSPECTIONWITHIN")
        {
            Response.Redirect("IncentiveAbstractionRptDrill.aspx?type=2&status=8&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + divid);
        }
        else if (e.CommandName == "INSPECTIONBEYOND")
        {
            Response.Redirect("IncentiveAbstractionRptDrill.aspx?type=2&status=9&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + divid);
        }
        else if (e.CommandName == "INSPECTIONTOTAL")
        {
            Response.Redirect("IncentiveAbstractionRptDrill.aspx?type=2&status=10&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + divid);
        }
        else if (e.CommandName == "INSPECTIONPENDINGWITHIN")
        {
            Response.Redirect("IncentiveAbstractionRptDrill.aspx?type=2&status=5&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + divid);
        }
        else if (e.CommandName == "INSPECTIONPENDINGBEYOND")
        {
            Response.Redirect("IncentiveAbstractionRptDrill.aspx?type=2&status=6&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + divid);
        }
        else if (e.CommandName == "INSPECTIONPENDINGTOTAL")
        {
            Response.Redirect("IncentiveAbstractionRptDrill.aspx?type=2&status=7&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + divid);
        }
        else if (e.CommandName == "REFEREDCOIWITHIN")
        {
            Response.Redirect("IncentiveAbstractionRptDrill.aspx?type=3&status=2&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + divid);
        }
        else if (e.CommandName == "REFEREDCOIBEYOND")
        {
            Response.Redirect("IncentiveAbstractionRptDrill.aspx?type=3&status=3&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + divid);
        }
        else if (e.CommandName == "REFERREDCOITOTAL")
        {
            Response.Redirect("IncentiveAbstractionRptDrill.aspx?type=3&status=4&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + divid);
        }
        else if (e.CommandName == "REFEREDPENDINGWITHIN")
        {
            Response.Redirect("IncentiveAbstractionRptDrill.aspx?type=3&status=7&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + divid);
        }
        else if (e.CommandName == "REFEREDPENDINGBEYOND")
        {
            Response.Redirect("IncentiveAbstractionRptDrill.aspx?type=3&status=8&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + divid);
        }
        else if (e.CommandName == "REFEREDPENDINGTOTAL")
        {
            Response.Redirect("IncentiveAbstractionRptDrill.aspx?type=3&status=9&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + divid);
        }
        else if (e.CommandName == "TOTALDLCWITHIN")
        {
            Response.Redirect("IncentiveAbstractionRptDrill.aspx?type=4&status=1&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + divid);
        }
        else if (e.CommandName == "TOTALDLCBEYOND")
        {
            Response.Redirect("IncentiveAbstractionRptDrill.aspx?type=4status=2&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + divid);
        }
        else if (e.CommandName == "TOTALDLCAPPROVED")
        {
            Response.Redirect("IncentiveAbstractionRptDrill.aspx?type=4status=3&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + divid);
        }
        else if (e.CommandName == "DLCPENDINGWITHIN")
        {
            Response.Redirect("IncentiveAbstractionRptDrill.aspx?type=4&status=4&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + divid);
        }
        else if (e.CommandName == "DLCPENDINGBEYOND")
        {
            Response.Redirect("IncentiveAbstractionRptDrill.aspx?type=4&status=5&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + divid);
        }
        else if (e.CommandName == "DLCPENDINGTOTAL")
        {
            Response.Redirect("IncentiveAbstractionRptDrill.aspx?type=4&status=6&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + divid);
        }
    }

    public void BindDistricts()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlProp_intDistrictid.Items.Clear();
            dsd = Gen.GetDistrictsWithoutHYD();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlProp_intDistrictid.DataSource = dsd.Tables[0];
                ddlProp_intDistrictid.DataValueField = "District_Id";
                ddlProp_intDistrictid.DataTextField = "District_Name";
                ddlProp_intDistrictid.DataBind();
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("--All--", "%");
                ddlProp_intDistrictid.Items.Insert(0, li);
            }
            else
            {
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("--All--", "%");
                ddlProp_intDistrictid.Items.Insert(0, li);
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }
}
 