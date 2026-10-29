using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class UI_TSiPASS_Reports_Page : System.Web.UI.Page
{
    decimal unitsapplied, allaprovals, approvalsbeyonds, Investmentapprove, Employementapprove, approvalapplied, Approvalwithin, approvalbeyond;

    #region Declaration
    General gen = new General();
    General Gen = new General();
    int Sno = 0;

    DataSet ds;
    DataTable dt;


    DataSet dslist;


    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/tsHome.aspx");

        }
        if (!IsPostBack)
        {
            getdistricts();
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["fromdate"] != null && Request.QueryString["fromdate"] != "" && Request.QueryString["todate"] != null && Request.QueryString["todate"] != "")
                {
                    txtFromDate.Text = Request.QueryString["fromdate"].ToString().Trim();
                    txtTodate.Text = Request.QueryString["todate"].ToString().Trim();
                    if (Convert.ToString(Request.QueryString["Selected"]) == "YES")
                    {

                        string districid = Request.QueryString["Districtid"];

                        if (districid == "%")
                            ddldistrict.SelectedItem.Value = "0";

                        else if (districid != "%")
                        {
                            string Distname = Convert.ToString(Request.QueryString["dist"]);
                            System.Web.UI.WebControls.ListItem District = ddldistrict.Items.FindByValue(districid);
                            District.Selected = true;
                        }
                    }
                    else
                        ddldistrict.SelectedItem.Value = "0";
                }
            }
            else
            {
                txtFromDate.Text = "01-01-2015";
                DateTime today = DateTime.Today;
                txtTodate.Text = today.ToString("dd-MM-yyyy");
                //fillgrid();
            }
            if (txtFromDate.Text.Trim() != "" && txtTodate.Text.Trim() != "")
                Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + DateTime.Now;
            if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
            {
                ddldistrict.SelectedValue = Session["DistrictID"].ToString().Trim();

                ddldistrict.Enabled = false;
            }
            fillgrid();

        }
    }
    protected void getdistricts()
    {
        DataSet dsnew = new DataSet();

        dsnew = Gen.GetDistricts();
        ddldistrict.DataSource = dsnew.Tables[0];
        ddldistrict.DataTextField = "District_Name";
        ddldistrict.DataValueField = "District_Id";
        ddldistrict.DataBind();
        ddldistrict.Items.Insert(0, "--Select--");
        if (Session["DistrictID"].ToString().Trim() != "")
        {
            ddldistrict.SelectedValue = Session["DistrictID"].ToString().Trim();
            ddldistrict.Enabled = false;
        }
        else
        {
            ddldistrict.Enabled = true;
        }
    }
    public void fillgrid()
    {
        string District;

        if (ddldistrict.SelectedItem.Text == "" || ddldistrict.SelectedItem.Text == null || ddldistrict.SelectedItem.Text == "--Select--" || ddldistrict.SelectedValue == "0")
        {
            District = "%";
            ViewState["District"] = District;
        }
        else
        {
            District = ddldistrict.SelectedItem.Value;
            ViewState["District"] = District;
        }
        try
        {
            Label1.Text = "";
            DataSet dsnew = new DataSet();
            int valid = 0;
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
            if (valid == 1)
            {
                Failure.Visible = true;
            }
            if (valid == 0)
            {
                string FromdateforDB = "", TodateforDB = "";
                if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
                {
                    FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                    TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                }
                dsnew = Gen.GetApplandApprovalslist(FromdateforDB, TodateforDB, District);
                DataSet ds = new DataSet();
                ds = Gen.GetmodifiedDate();
                Label2.Text = "Last Updated on : " + ds.Tables[0].Rows[0]["ModifiedDate"].ToString().Trim();
                // lblMsg.Text = "";
                if (dsnew.Tables[0].Rows.Count > 0)
                {
                    // lblMsg.Text = "Total Records :" +dsnew.Tables[0].Rows.Count.ToString();
                    if (ddlType.SelectedValue == "3")
                    {
                        Label1.Text = "Report from 01-April-2016 to " + System.DateTime.Now;//.ToString("dd-MMM-yyyy");
                    }
                    else
                    {
                        if (txtFromDate.Text.Trim() != "" && txtTodate.Text.Trim() != "")
                            Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
                        // Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + DateTime.Now;
                        else
                            Label1.Text = "Report from 01-Jan-2015 to " + System.DateTime.Now;//.ToString("dd-MMM-yyyy");
                    }
                    grddistric.DataSource = dsnew.Tables[0];
                    grddistric.DataBind();
                    // BindPieChart();

                }
                else
                {

                    Label1.Text = "No Records Found ";
                    grddistric.DataSource = null;
                    grddistric.DataBind();
                    // BindPieChart();

                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }




    }

    protected void grddistric_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string Distselection = "";
        if (ddldistrict.SelectedItem.Text == "--Select--")
            Distselection = "NO";
        else
            Distselection = "YES";

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal Units = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NoofApplication"));
            unitsapplied = Units + unitsapplied;

            decimal Approvesissued = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Applapprovedwithin"));
            allaprovals = Approvesissued + allaprovals;

            decimal Approvalbeyond = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Applapprovedbeyond"));
            approvalsbeyonds = Approvalbeyond + approvalsbeyonds;

            decimal investment = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Investment"));
            Investmentapprove = investment + Investmentapprove;

            decimal Employement = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Employment"));
            Employementapprove = Employement + Employementapprove;

            decimal Approvalapplied = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "totalApprovals"));
            approvalapplied = Approvalapplied + approvalapplied;

            decimal Approvalwith = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Approvalswithin"));
            Approvalwithin = Approvalwith + Approvalwithin;

            decimal beyondtime = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Approvalsbeyond"));
            approvalbeyond = beyondtime + approvalbeyond;            


            HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
            h2.NavigateUrl = "DistricReportDrilldown.aspx?dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District")).Trim() + "&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&type=Applapprovedwithin" + "&Districtid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Distid")).Trim()+"&Selected="+ Distselection;
            //h2.Target = "_blank";

            HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
            h3.NavigateUrl = "DistricReportDrilldown.aspx?dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District")).Trim() + "&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&type=Applapprovedbeyond" + "&Districtid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Distid")).Trim() + "&Selected=" + Distselection;
            //h3.Target = "_blank";
            HyperLink h1 = (HyperLink)e.Row.Cells[5].Controls[0];
            h1.NavigateUrl = "DistricReportDrilldown.aspx?dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District")).Trim() + "&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&type=NoofApplication" + "&DistricId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Distid")).Trim() + "&Selected=" + Distselection;
            //h1.Target = "_blank";
            //HyperLink h4 = (HyperLink)e.Row.Cells[6].Controls[0];
            //h4.NavigateUrl = "DistricReportDrilldown.aspx?dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District")).Trim() + "&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&type=Investment" + "&Districtid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Distid")).Trim();
            //h4.Target = "_blank";

            //HyperLink h5 = (HyperLink)e.Row.Cells[7].Controls[0];
            //h5.NavigateUrl = "DistricReportDrilldown.aspx?dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District")).Trim() + "&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&type=Employment" + "&Districtid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Distid")).Trim();
            //h5.Target = "_blank";



            HyperLink h7 = (HyperLink)e.Row.Cells[8].Controls[0];
            h7.NavigateUrl = "DistricReportDrilldown.aspx?dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District")).Trim() + "&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&type=Approvalswithin" + "&Districtid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Distid")).Trim() + "&Selected=" + Distselection;
            //h7.Target = "_blank";

            HyperLink h8 = (HyperLink)e.Row.Cells[9].Controls[0];
            h8.NavigateUrl = "DistricReportDrilldown.aspx?dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District")).Trim() + "&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&type=Approvalsbeyond" + "&Districtid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Distid")).Trim() + "&Selected=" + Distselection;
            //h8.Target = "_blank";

            HyperLink h6 = (HyperLink)e.Row.Cells[10].Controls[0];
            h6.NavigateUrl = "DistricReportDrilldown.aspx?dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District")).Trim() + "&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&type=totalApprovals" + "&Districtid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Distid")).Trim() + "&Selected=" + Distselection;
            //h6.Target = "_blank";

            e.Row.Cells[3].BackColor = System.Drawing.Color.LightYellow;
            e.Row.Cells[4].BackColor = System.Drawing.Color.LightYellow;
            e.Row.Cells[5].BackColor = System.Drawing.Color.LightYellow;

            //e.Row.Cells[8].BackColor = System.Drawing.Color.LightSteelBlue;
            //e.Row.Cells[9].BackColor = System.Drawing.Color.LightSteelBlue;
            //e.Row.Cells[10].BackColor = System.Drawing.Color.LightSteelBlue;
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            string district, distid;

            if (ddldistrict.SelectedItem.Text == "" || ddldistrict.SelectedItem.Text == null || ddldistrict.SelectedItem.Text == "--Select--" || ddldistrict.SelectedValue == "0")
            {
                district = "%";
                distid = "%";

            }
            else
            {
                district = ddldistrict.SelectedItem.Text;
                distid = ddldistrict.SelectedItem.Value;
            }

            e.Row.Cells[2].Text = "Total";
            HyperLink Total = new HyperLink();
            Total.ForeColor = System.Drawing.Color.White;
            Total.NavigateUrl = "DistricReportDrilldown.aspx?dist=" + district + "&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&type=NoofApplication" + "&Districtid=" + distid+"&Selected=" + Distselection;
            Total.Target = "_blank";
            Total.Text = unitsapplied.ToString();
            e.Row.Cells[5].Text = unitsapplied.ToString();
            e.Row.Cells[5].Controls.Add(Total);


            HyperLink Approvedwithin = new HyperLink();
            Approvedwithin.ForeColor = System.Drawing.Color.White;

            Approvedwithin.NavigateUrl = "DistricReportDrilldown.aspx?dist=" + district + "&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&type=Applapprovedwithin" + "&Districtid=" + distid + "&Selected=" + Distselection;
            Approvedwithin.Target = "_blank";
            Approvedwithin.Text = allaprovals.ToString();
            e.Row.Cells[3].Text = allaprovals.ToString();
            e.Row.Cells[3].Controls.Add(Approvedwithin);


            HyperLink Beyond = new HyperLink();

            Beyond.ForeColor = System.Drawing.Color.White;
            Beyond.NavigateUrl = "DistricReportDrilldown.aspx?dist=" + district + "&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&type=Applapprovedbeyond" + "&Districtid=" + distid + "&Selected=" + Distselection;
            //Beyond.Target = "_blank";
            Beyond.Text = approvalsbeyonds.ToString();
            e.Row.Cells[4].Text = approvalsbeyonds.ToString();
            e.Row.Cells[4].Controls.Add(Beyond);

            HyperLink applied = new HyperLink();
            applied.ForeColor = System.Drawing.Color.White;
            applied.NavigateUrl = "DistricReportDrilldown.aspx?dist=" + district + "&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&type=totalApprovals" + "&Districtid=" + distid + "&Selected=" + Distselection;
            //applied.Target = "_blank";
            applied.Text = approvalapplied.ToString();
            e.Row.Cells[10].Text = approvalapplied.ToString();
            e.Row.Cells[10].Controls.Add(applied);

            HyperLink Approval = new HyperLink();
            Approval.ForeColor = System.Drawing.Color.White;
            Approval.NavigateUrl = "DistricReportDrilldown.aspx?dist=" + district + "&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&type=Approvalswithin" + "&Districtid=" + distid + "&Selected=" + Distselection;
            //Approval.Target = "_blank";
            Approval.Text = Approvalwithin.ToString();
            e.Row.Cells[8].Text = Approvalwithin.ToString();
            e.Row.Cells[8].Controls.Add(Approval);

            HyperLink beyondtime = new HyperLink();
            beyondtime.ForeColor = System.Drawing.Color.White;
            beyondtime.NavigateUrl = "DistricReportDrilldown.aspx?dist=" + district + "&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&type=Approvalsbeyond" + "&Districtid=" + distid + "&Selected=" + Distselection;
            //beyondtime.Target = "_blank";
            beyondtime.Text = approvalbeyond.ToString();
            e.Row.Cells[9].Text = approvalbeyond.ToString();
            e.Row.Cells[9].Controls.Add(beyondtime);

            e.Row.Cells[6].Text = Investmentapprove.ToString();
            e.Row.Cells[7].Text = Employementapprove.ToString();

        }
    }

    protected void grddistric_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grddistric.PageIndex = e.NewPageIndex;
        fillgrid();
    }

    protected void grddistric_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow gvHeaderRow = e.Row;
            GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            this.grddistric.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

            int headerCellCount = gvHeaderRow.Cells.Count;
            int cellIndex = 0;

            for (int i = 0; i < headerCellCount; i++)
            {
                if (i == 3 || i == 4 || i == 5 || i == 8 || i == 9 || i == 10)
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
            tcMergePackage.Text = "Total no.of Industries";
            tcMergePackage.CssClass = "GridviewScrollC1Header";
            tcMergePackage.ColumnSpan = 3;

            TableCell tcMergePackage1 = new TableCell();
            tcMergePackage1.Text = "Total no.of Approvals";
            tcMergePackage1.CssClass = "GridviewScrollC1Header";
            tcMergePackage1.ColumnSpan = 3;

            gvHeaderRowCopy.Cells.AddAt(5, tcMergePackage);
            gvHeaderRowCopy.Cells.AddAt(6, tcMergePackage1);

        }
    }

    protected void grddistric_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button2_ServerClick(object sender, EventArgs e)
    {
        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                grddistric.AllowPaging = false;

                this.fillgrid();

                grddistric.HeaderRow.ForeColor = System.Drawing.Color.Black;
                grddistric.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                grddistric.FooterRow.ForeColor = System.Drawing.Color.Black;
                // grdExport.Columns[1].Visible = false;
                grddistric.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=R6.12:TSiPASS-" + "DistricReports.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.Flush();
                Response.End();
            }
        }
    }

    protected void Button1_ServerClick(object sender, EventArgs e)
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
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
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
            grddistric.DataSource = null;
            grddistric.DataBind();
        }
    }
    protected void ExportToExcel(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=R6.12:TSiPASS-DistrictWiseReport.xls");
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
            grddistric.AllowPaging = false;
            //this.fillgrid();


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

    protected void btnNewPdf_Click(object sender, EventArgs e)
    {
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

            //if (ddlEnterPriseType.SelectedItem.Text != "--Select--")
            //{
            //    phrase = new Phrase();
            //    phrase.Add(new Chunk("Type of Enterprise :" + ddlEnterPriseType.SelectedItem.Text.Trim(), FontFactory.GetFont("trebuchet ms", 12, Font.NORMAL, Color.BLACK)));
            //    cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
            //    cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
            //    cell.HorizontalAlignment = PdfCell.ALIGN_RIGHT;
            //    cell.Colspan = 3;
            //    cell.PaddingTop = 10f;
            //    cell.PaddingBottom = 0f;
            //    table.AddCell(cell);
            //}

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

            foreach (DataControlFieldCell cellnew in grddistric.Rows[0].Cells)
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

                cellText = Server.HtmlDecode(grddistric.Columns[i].HeaderText);

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

            for (int i = 0; i < grddistric.Rows.Count; i++)
            {
                if (grddistric.Rows[i].RowType == DataControlRowType.DataRow)
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
                            cellText = Server.HtmlDecode(grddistric.Rows[i].Cells[j].Text);
                        }
                        else
                        {
                            if (grddistric.Rows[i].Cells[j].Controls[0].Visible == true)
                            {
                                h4 = (HyperLink)grddistric.Rows[i].Cells[j].Controls[0];
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
                            string cellTextnew1 = Server.HtmlDecode(grddistric.Rows[i].Cells[1].Text);
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
                        if (grddistric.Rows[i].RowState == DataControlRowState.Alternate)
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

                        cellText = Server.HtmlDecode(grddistric.Columns[k].HeaderText);

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

                cellText = Server.HtmlDecode(grddistric.FooterRow.Cells[i].Text);
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

    protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}