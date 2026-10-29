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

public partial class UI_TSiPASS_DepartmentAbstractLatestREN : System.Web.UI.Page
{
    int NumberTotal, Aproved, pending, Yet_to_Start, Initial_Stage, Advanced_Stage, Commenced_Operations, NumberTotalUpto, AprovedUpto, RejectedTotal;

    HtmlTableRow tRow;
    HtmlTableCell tcell1;
    DataSet ds = new DataSet();
    comFunctions cmf = new comFunctions();
    int cnt = 0;

    string Dept = "";
    DB.DB con1 = new DB.DB();
    General tran1 = new General();
    General csRegComplaint = new General();
    int pendingafter, pendingbefore, closedafter, closedbefore, total, Reject, QueryRaised, QueryRaiseda, Pending, Pendinga, Approved, Approveda;
    int pendingaftera, pendingbeforea, closedaftera, closedbeforea, totala, Rejecta;
    string zone = "%";
    protected void Page_Load(object sender, EventArgs e)
    {
        // this.txtFrom.Attributes.Add("onfocus", "popUpCalendarLeft(this,document.getElementById('ctl00_ContentPlaceHolder1_txtFrom'), 'dd-mmm-yyyy')");
        // this.txtTo.Attributes.Add("onfocus", "popUpCalendarLeft(this,document.getElementById('ctl00_ContentPlaceHolder1_txtTo'), 'dd-mmm-yyyy')");


        if (Session.Count == 0)
            Response.Redirect("../../Index.aspx");
        else
        {
            if (Session["user_id"].ToString().Trim().ToLower() == "fruxhelpdesk")
            {
                BtnSave1.Visible = true;
            }
            else
            { BtnSave1.Visible = false; }
            if (!Page.IsPostBack)
            {
                // Modified by Srikanth on 13-05-2013


                hdfsms.Value = "0";

                //THeader();
                txtFromDate.Text = "01-04-2016";
                DateTime today = DateTime.Today;
                txtTodate.Text = today.ToString("dd-MM-yyyy");
                FillGrid();
                tbl1.Width = "750";
                //TTotal("Gr");
            }

        }
    }


    public void FillGrid()
    {

        DataSet vehicleDS = new DataSet();
        string FromdateforDB = "", TodateforDB = "";
        FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));

        if (Session["DistrictID"].ToString().Trim() != null)
        {
            vehicleDS = tran1.DeptReportDepartmentWise_NewpdfREN(Session["DistrictID"].ToString().Trim(), "%", FromdateforDB, TodateforDB);

        }
        else
        {
            vehicleDS = tran1.DeptReportDepartmentWise_NewpdfREN("%", "%", FromdateforDB, TodateforDB);
        }
        Label1.Text = "Report from 1st April 2016 to " + System.DateTime.Now;
        grdDetails.DataSource = vehicleDS;
        grdDetails.DataBind();
    }

    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
        ExportToExcel();
    }

    protected void ExportToExcel()
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=R5: Department wise performance Tracker" + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                //grdDetails.Columns[1].Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);



                string FromdateforDB = "", TodateforDB = "";
                FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));

                DataSet vehicleDS = new DataSet();
                if (Session["DistrictID"].ToString().Trim() != null)
                {
                    vehicleDS = tran1.DeptReportDepartmentWise_NewpdfREN(Session["DistrictID"].ToString().Trim(), "%", FromdateforDB, TodateforDB);
                }
                else
                {
                    vehicleDS = tran1.DeptReportDepartmentWise_NewpdfREN("%", "%", FromdateforDB, TodateforDB);
                }

                grdExport.DataSource = vehicleDS.Tables[0];
                grdExport.DataBind();

                grdExport.RenderControl(hw);
                // CFO R5: Department wise performance Tracker
                string label1text = Label1.Text;
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='10'><h4>" + "CFO R5: Department wise performance Tracker" + "</h4></td></td></tr><tr><td align='center' colspan='10'><h4>" + label1text + "</h4></td></td></tr></table>";
                HttpContext.Current.Response.Write(headerTable);
                //grdDetails.Columns.RemoveAt("View");
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
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow gvHeaderRow = e.Row;
            GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            this.grdDetails.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

            int headerCellCount = gvHeaderRow.Cells.Count;
            int cellIndex = 0;

            for (int i = 0; i < headerCellCount; i++)
            {
                if (i == 4 || i == 5 || i == 8 || i == 9)
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
            tcMergePackage.Text = "Pre-Scrutiny-Under Process";
            tcMergePackage.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(4, tcMergePackage);

            TableCell tcMergePackage1 = new TableCell();
            tcMergePackage1.Text = "Department Approval - Under Process";
            tcMergePackage1.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage1.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(7, tcMergePackage1);

        }
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string Service_id = "";
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //TChildHead(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Department Name")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Department Name")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "NoofapplicationsApplied")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CompletedWithinDays")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CompletedBeyondDays")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Pending Less than 3 Days")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Pending More than 3 Days")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Rejected")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Completed")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "QueryRaised")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Approved")));

            int NumberTotal1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoofapplicationsApplied"));
            NumberTotal = NumberTotal1 + NumberTotal;

            int NumberTotal2 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "QueryRaised"));
            NumberTotalUpto = NumberTotal2 + NumberTotalUpto;

            int Aproved1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Pending Less than 3 Days"));
            Aproved = Aproved + Aproved1;

            int Aproved2 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Pending More than 3 Days"));
            AprovedUpto = Aproved2 + AprovedUpto;

            int pending1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Number of payment received for"));
            pending = pending + pending1;

            int Yet_to_Start1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Completed"));
            Yet_to_Start = Yet_to_Start1 + Yet_to_Start;

            int Initial_Stage1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CompletedWithinDays"));
            Initial_Stage = Initial_Stage + Initial_Stage1;
            int Advanced_Stage1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CompletedBeyondDays"));
            Advanced_Stage = Advanced_Stage + Advanced_Stage1;
            int Commenced_Operations1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Approved"));
            Commenced_Operations = Commenced_Operations + Commenced_Operations1;
            int RejectedTotal1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Rejected"));
            RejectedTotal = RejectedTotal1 + RejectedTotal;


            if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MobileNumber")).Trim() != "" && hdfsms.Value == "1")
            {
                if ((Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CompletedBeyondDays")) + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Pending More than 3 Days"))) > 5)
                {
                    cmf.SendSingleSMS(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MobileNumber")).Trim(), "Madam/Sir, CFO : Pendency beyond due date - Pre-scrutiny stage  : " + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Pending More than 3 Days")).ToString().Trim() + "  and Approvals stage : " + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CompletedBeyondDays")).ToString().Trim().ToString().Trim() + " . Application status informed for perusal and necessary action. TS-iPASS (" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ")");


                    //cmf.SendSingleSMS("9848080271", " " + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Department Name")) + " - Madam/Sir, CFO : Pendency beyond due date - Pre-scrutiny stage  : " + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Pending More than 3 Days")).ToString().Trim() + "  and Approvals stage : " + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CompletedBeyondDays")).ToString().Trim().ToString().Trim() + " . Application status informed for perusal and necessary action. TS-iPASS (" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ")");

                    cmf.SendSingleSMS("9885696486", " " + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Department Name")) + " - Madam/Sir, CFO : Pendency beyond due date - Pre-scrutiny stage  : " + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Pending More than 3 Days")).ToString().Trim() + "  and Approvals stage : " + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CompletedBeyondDays")).ToString().Trim().ToString().Trim() + " . Application status informed for perusal and necessary action. TS-iPASS (" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ")");

                    cmf.SendSingleSMS("9247492919", " " + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Department Name")) + " - Madam/Sir, CFO : Pendency beyond due date - Pre-scrutiny stage  : " + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Pending More than 3 Days")).ToString().Trim() + "  and Approvals stage : " + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CompletedBeyondDays")).ToString().Trim().ToString().Trim() + " . Application status informed for perusal and necessary action. TS-iPASS (" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ")");


                }

                //cmf.SendSingleSMS(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MobileNumber")).Trim(), "Madam/Sir, CFO : Pendency beyond due date - Pre-scrutiny stage  : " + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Pending More than 3 Days")).ToString().Trim() + "  and Approvals stage : " + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CompletedBeyondDays")).ToString().Trim().ToString().Trim() + ".Application status informed for perusal and necessary action. TS-iPASS (" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ")");



                //if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")) == "1")
                //{
                //    //cmf.SendSingleSMS(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MobileNumber")).Trim(), "Respected Sir / Madam, TS-iPASS CFE Status on " + System.DateTime.Now.ToString("dd-MMM-yyyy") + " - Pendency beyond due date - Pre-scrutiny stage  : " + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Pending More than 3 Days")).ToString().Trim() + "  and Approvals stage : " + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CompletedBeyondDays")).ToString().Trim().ToString().Trim() + " .Thank You");

                //    cmf.SendSingleSMS("9247492919", "Respected Sir / Madam, TS-iPASS CFE Status on " + System.DateTime.Now.ToString("dd-MMM-yyyy") + " - Pendency beyond due date - Pre-scrutiny stage  : " + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Pending More than 3 Days")).ToString().Trim() + "  and Approvals stage : " + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CompletedBeyondDays")).ToString().Trim().ToString().Trim() + " .Thank You");
                //}
            }

            int total1 = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "NoofapplicationsApplied")));
            total = total1 + total;
            totala = total1 + totala;

            int pendingafter1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Pending More than 3 Days"));
            pendingafter = pendingafter1 + pendingafter;
            pendingaftera = pendingafter1 + pendingaftera;

            int pendingbefore1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Pending Less than 3 Days"));
            pendingbefore = pendingbefore1 + pendingbefore;
            pendingbeforea = pendingbefore1 + pendingbeforea;

            int closedafter1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CompletedBeyondDays"));
            closedafter = closedafter1 + closedafter;
            closedaftera = closedafter1 + closedaftera;

            int closedbefore1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CompletedWithinDays"));
            closedbefore = closedbefore1 + closedbefore;
            closedbeforea = closedbefore1 + closedbeforea;

            int Reject1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Rejected"));
            Reject = Reject1 + Reject;
            Rejecta = Reject1 + Rejecta;

            int QueryRaised1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "QueryRaised"));
            QueryRaised = QueryRaised1 + QueryRaised;
            QueryRaiseda = QueryRaised1 + QueryRaiseda;


            int Pending1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Completed"));
            Pending = Pending1 + Pending;
            Pendinga = Pending1 + Pendinga;

            int Approved1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Approved"));
            Approved = Approved1 + Approved;
            Approveda = Approved1 + Approveda;

            Service_id = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid"));


            //MonthwiseStatusrptDrill.aspx?year=2017&month=4&status=A

            HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
            if (h1.Text != "0")
            {
                h1.NavigateUrl = "frmDeptstatusbytypeREN.aspx?Id=" + Service_id + "&Status=4&Type=Total";
            }
            HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
            if (h2.Text != "0")
            {
                h2.NavigateUrl = "frmDeptstatusbytypeREN.aspx?Id=" + Service_id + "&Status=2&Type=Total";
            }
            HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
            if (h3.Text != "0")
            {
                h3.NavigateUrl = "frmDeptstatusbytypeREN.aspx?Id=" + Service_id + "&Status=1&Type=Within Three Days";
            }
            HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
            if (h4.Text != "0")
            {
                h4.NavigateUrl = "frmDeptstatusbytypeREN.aspx?Id=" + Service_id + "&Status=1&Type=Beyond Three Days";
            }
            HyperLink h5 = (HyperLink)e.Row.Cells[6].Controls[0];
            if (h5.Text != "0")
            {
                h5.NavigateUrl = "frmDeptstatusbytypeREN.aspx?Id=" + Service_id + "&Status=5&Type=Total";
            }
            HyperLink h6 = (HyperLink)e.Row.Cells[7].Controls[0];
            if (h6.Text != "0")
            {
                h6.NavigateUrl = "frmDeptstatusbytypeREN.aspx?Id=" + Service_id + "&Status=3&Type=Total";
            }
            HyperLink h7 = (HyperLink)e.Row.Cells[8].Controls[0];
            if (h7.Text != "0")
            {

                h7.NavigateUrl = "frmDeptstatusbytype1REN.aspx?Id=" + Service_id + "&Status=2&Type=Within time limits";
            }
            HyperLink h8 = (HyperLink)e.Row.Cells[9].Controls[0];
            if (h8.Text != "0")
            {
                h8.NavigateUrl = "frmDeptstatusbytype1REN.aspx?Id=" + Service_id + "&Status=2&Type=Beyond time limits";
            }
            HyperLink h9 = (HyperLink)e.Row.Cells[10].Controls[0];
            if (h9.Text != "0")
            {
                h9.NavigateUrl = "frmDeptstatusbytype1REN.aspx?Id=" + Service_id + "&Status=1&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&Type=Total";
            }
            HyperLink h10 = (HyperLink)e.Row.Cells[11].Controls[0];
            if (h10.Text != "0")
            {
                h10.NavigateUrl = "frmDeptstatusbytype1REN.aspx?Id=" + Service_id + "&Status=3&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&Type=Total";
            }

        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Grand Total";
            e.Row.Cells[2].Text = NumberTotal.ToString();
            e.Row.Cells[3].Text = NumberTotalUpto.ToString();
            e.Row.Cells[4].Text = Aproved.ToString();
            e.Row.Cells[5].Text = AprovedUpto.ToString();
            e.Row.Cells[6].Text = pending.ToString();
            e.Row.Cells[7].Text = Yet_to_Start.ToString();
            e.Row.Cells[8].Text = Initial_Stage.ToString();
            e.Row.Cells[9].Text = Advanced_Stage.ToString();
            e.Row.Cells[10].Text = Commenced_Operations.ToString();
            e.Row.Cells[11].Text = RejectedTotal.ToString();
            e.Row.Font.Bold = true;

            Service_id = "%";
            HyperLink h1 = new HyperLink();
            h1.Text = NumberTotal.ToString();
            if (h1.Text != "0")
            {
                h1.NavigateUrl = "frmDeptstatusbytypeREN.aspx?Id=" + Service_id + "&Status=4&Type=Total";
                e.Row.Cells[2].Controls.Add(h1);
            }
            HyperLink h2 = new HyperLink();
            h2.Text = NumberTotalUpto.ToString();
            if (h2.Text != "0")
            {
                h2.NavigateUrl = "frmDeptstatusbytypeREN.aspx?Id=" + Service_id + "&Status=2&Type=Total";
                e.Row.Cells[3].Controls.Add(h2);
            }
            HyperLink h3 = new HyperLink();
            h3.Text = Aproved.ToString();
            if (h3.Text != "0")
            {
                h3.NavigateUrl = "frmDeptstatusbytypeREN.aspx?Id=" + Service_id + "&Status=1&Type=Within Three Days";
                e.Row.Cells[4].Controls.Add(h3);
            }
            HyperLink h4 = new HyperLink();
            h4.Text = AprovedUpto.ToString();
            if (h4.Text != "0")
            {
                h4.NavigateUrl = "frmDeptstatusbytypeREN.aspx?Id=" + Service_id + "&Status=1&Type=Beyond Three Days";
                e.Row.Cells[5].Controls.Add(h4);
            }
            HyperLink h5 = new HyperLink();
            h5.Text = pending.ToString();
            if (h5.Text != "0")
            {
                h5.NavigateUrl = "frmDeptstatusbytypeREN.aspx?Id=" + Service_id + "&Status=5&Type=Total";
                e.Row.Cells[6].Controls.Add(h5);
            }
            HyperLink h6 = new HyperLink();
            h6.Text = Yet_to_Start.ToString();
            if (h6.Text != "0")
            {
                h6.NavigateUrl = "frmDeptstatusbytypeREN.aspx?Id=" + Service_id + "&Status=3&Type=Total";
                e.Row.Cells[7].Controls.Add(h6);
            }
            HyperLink h7 = new HyperLink();
            h7.Text = Initial_Stage.ToString();
            if (h7.Text != "0")
            {
                h7.NavigateUrl = "frmDeptstatusbytype1REN.aspx?Id=" + Service_id + "&Status=2&Type=Within time limits";
                e.Row.Cells[8].Controls.Add(h7);
            }
            HyperLink h8 = new HyperLink();
            h8.Text = Advanced_Stage.ToString(); if (h8.Text != "0")
            {
                h8.NavigateUrl = "frmDeptstatusbytype1REN.aspx?Id=" + Service_id + "&Status=2&Type=Beyond time limits";
                e.Row.Cells[9].Controls.Add(h8);
            }
            HyperLink h9 = new HyperLink();
            h9.Text = Commenced_Operations.ToString();
            if (h9.Text != "0")
            {
                h9.NavigateUrl = "frmDeptstatusbytype1REN.aspx?Id=" + Service_id + "&Status=1&Type=Total";
                e.Row.Cells[10].Controls.Add(h9);
            }
            HyperLink h10 = new HyperLink();
            h10.Text = RejectedTotal.ToString();
            if (h10.Text != "0")
            {
                h10.NavigateUrl = "frmDeptstatusbytype1REN.aspx?Id=" + Service_id + "&Status=3&Type=Total";
                e.Row.Cells[11].Controls.Add(h10);
            }

            h1.ForeColor = System.Drawing.Color.White;
            h2.ForeColor = System.Drawing.Color.White;
            h3.ForeColor = System.Drawing.Color.White;
            h4.ForeColor = System.Drawing.Color.White;
            h5.ForeColor = System.Drawing.Color.White;
            h6.ForeColor = System.Drawing.Color.White;
            h7.ForeColor = System.Drawing.Color.White;
            h8.ForeColor = System.Drawing.Color.White;
            h9.ForeColor = System.Drawing.Color.White;
            h10.ForeColor = System.Drawing.Color.White;

        }
    }


    #region Create Dynamic Table

    public void THeader()
    {

        #region First Copy
        tRow = new HtmlTableRow();
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>S.No.</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tcell1.RowSpan = 2;
        tRow.Cells.Add(tcell1);
        tRow.Style.Add("Padding", "3px");
        tRow.Style.Add("Align", "center");
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Department Name</b></font>";
        tcell1.Align = "Left";
        tcell1.ColSpan = 1;
        tcell1.RowSpan = 2;






        tRow.Cells.Add(tcell1);
        tRow.Style.Add("Padding", "3px");
        tRow.Style.Add("Align", "center");
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Approvals Applied</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tcell1.RowSpan = 2;
        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Query Raised</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tcell1.RowSpan = 2;


        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Pre-Scrutiny-Under Process</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 2;


        //tRow.Cells.Add(tcell1);


        //tcell1 = new HtmlTableCell();
        //tcell1.InnerHtml = "<font color=white><b>Total</b></font>";
        //tcell1.Align = "Center";
        //tcell1.ColSpan = 1;


        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Pre-Scrutiny-Completed</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tcell1.RowSpan = 2;


        tRow.Cells.Add(tcell1);
        tRow.Style.Add("Padding", "3px");
        tRow.Style.Add("Align", "center");
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Department Approval - Under Process</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 2;




        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Department-Approved</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tcell1.RowSpan = 2;
        tRow.Cells.Add(tcell1);





        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Rejected</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tcell1.RowSpan = 2;

        tRow.Cells.Add(tcell1);
        tRow.BgColor = "#009688";
        tRow.BorderColor = "#ffffff";
        tbl1.Rows.Add(tRow);

        tRow = new HtmlTableRow();
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Before Due Date</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>After Due Date</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;


        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Before Due Date</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>After Due Date</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        //tRow.Cells.Add(tcell1);

        //tcell1 = new HtmlTableCell();
        //tcell1.InnerHtml = "<font color=white><b>Total</b></font>";
        //tcell1.Align = "Center";
        //tcell1.ColSpan = 1;
        tRow.Cells.Add(tcell1);


        tRow.BgColor = "#009688";
        tRow.BorderColor = "#ffffff";

        tbl1.Rows.Add(tRow);

        #endregion

    }

    public void TChildHead(string Service_id, string Department, string Service, string totalReceived, string beforeclose, string afterclose, string beforeopen, string afteropen, string Rejected, string PPending, string QQueryRaised, string Approvals)
    {
        cnt = cnt + 1;
        ////if (Dept.Trim() != Department.Trim())
        ////{            
        ////    if(cnt>1)
        ////    TTotal("Sr");
        ////totala = 0;
        ////pendingaftera = 0;
        ////pendingbeforea = 0;
        ////closedaftera = 0;
        ////closedbeforea = 0;
        ////    Dept = Department.Trim();
        ////    tRow = new HtmlTableRow();
        ////    tcell1 = new HtmlTableCell();
        ////    tcell1.InnerHtml = "<b>" + Department.Trim() + "</b>";
        ////    tcell1.Align = "Center";
        ////    tcell1.ColSpan = 8;
        ////    tRow.Cells.Add(tcell1);
        ////    tRow.BgColor = "#E6EDF7";
        ////    tbl1.Rows.Add(tRow);
        ////}

        // tRow = new HtmlTableRow();
        //        tRow.Cells.Add(tcell1);
        #region First Copy
        tRow = new HtmlTableRow();
        tcell1 = new HtmlTableCell();
        tcell1.InnerText = cnt.ToString().Trim();
        tcell1.Align = "Center";
        tcell1.Width = "50";

        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerText = Service.Trim().ToUpper();
        tcell1.Align = "Left";


        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<a href='frmDeptstatusbytypeCFO.aspx?Id=" + Service_id.Trim() + "&Status=4&Type=Total'> " + totalReceived.Trim() + "</a>";
        tcell1.Align = "Right";

        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<a href='frmDeptstatusbytypeCFO.aspx?Id=" + Service_id.Trim() + "&Status=2&Type=Total'> " + QQueryRaised.Trim() + "</a>";
        tcell1.Align = "Right";

        tRow.Cells.Add(tcell1);
        tbl1.Rows.Add(tRow);

        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<a href='frmDeptstatusbytypeCFO.aspx?Id=" + Service_id.Trim() + "&Status=1&Type=Within Three Days'> " + beforeopen.Trim() + "</a>";
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);





        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<a href='frmDeptstatusbytypeCFO.aspx?Id=" + Service_id.Trim() + "&Status=1&Type=Beyond Three Days'> " + afteropen.Trim() + "</a>";
        tcell1.Align = "Right";






        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<a href='frmDeptstatusbytypeCFO.aspx?Id=" + Service_id.Trim() + "&Status=3&Type=Total'> " + PPending.ToString() + "</a>";
        tcell1.Align = "Right";

        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<a href='frmDeptstatusbytype1CFO.aspx?Id=" + Service_id.Trim() + "&Status=2&Type=Within time limits'> " + beforeclose.Trim() + "</a>";
        tcell1.Align = "Right";

        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<a href='frmDeptstatusbytype1CFO.aspx?Id=" + Service_id.Trim() + "&Status=2&Type=Beyond time limits'> " + afterclose.Trim() + "</a>";
        tcell1.Align = "Right";



        //tcell1 = new HtmlTableCell();
        //tcell1.InnerHtml = Convert.ToString(Convert.ToInt32(afterclose.Trim()) + Convert.ToInt32(beforeclose));
        //tcell1.Align = "Center";
        //tRow.Cells.Add(tcell1);




        //tcell1 = new HtmlTableCell();
        //tcell1.InnerHtml = Convert.ToString(Convert.ToInt32(beforeopen.Trim()) + Convert.ToInt32(afteropen));
        //tcell1.Align = "Right";
        //tRow.Cells.Add(tcell1);


        tRow.Cells.Add(tcell1);
        tbl1.Rows.Add(tRow);

        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<a href='frmDeptstatusbytype1CFO.aspx?Id=" + Service_id.Trim() + "&Status=1&Type=Total'> " + Approvals + "</a>";
        tcell1.Align = "Right";

        tRow.Cells.Add(tcell1);
        tbl1.Rows.Add(tRow);


        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<a href='frmDeptstatusbytype1CFO.aspx?Id=" + Service_id.Trim() + "&Status=3&Type=Total'> " + Rejected.Trim() + "</a>";
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);
        tbl1.Rows.Add(tRow);


        #endregion

    }

    public void TTotal(string totStatus)
    {
        //tRow = new HtmlTableRow();


        #region First Copy
        tRow = new HtmlTableRow();
        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b> Grand Total </b></font>";
        else
            tcell1.InnerHtml = "<b> Sub Total </b>";
        tcell1.ColSpan = 2;
        tcell1.Align = "Center";
        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + total.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + totala.ToString().Trim() + "</b>";


        tcell1.Align = "Right";

        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + QueryRaised.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + QueryRaiseda.ToString().Trim() + "</b>";
        tcell1.Align = "Right";


        tRow.Cells.Add(tcell1);




        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + pendingbefore.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + pendingbeforea.ToString().Trim() + "</b>";
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + pendingafter.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + pendingaftera.ToString().Trim() + "</b>";
        tcell1.Align = "Right";


        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + Pending.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + Pendinga.ToString().Trim() + "</b>";
        tcell1.Align = "Right";


        tRow.Cells.Add(tcell1);




        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + closedbefore.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + closedbeforea.ToString().Trim() + "</b>";
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + closedafter.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + closedaftera.ToString().Trim() + "</b>";
        tcell1.Align = "Right";
        //tRow.Cells.Add(tcell1);


        //tcell1 = new HtmlTableCell();
        //if (totStatus.Trim() == "Gr")
        //    tcell1.InnerHtml = "<font color=white><b>" + Convert.ToString(Convert.ToInt32(closedbefore.ToString().Trim()) + Convert.ToInt32(closedafter.ToString().Trim())) + "</b></font>";
        //else
        //    tcell1.InnerHtml = "<b>" + Convert.ToString(Convert.ToInt32(closedbeforea.ToString().Trim()) + Convert.ToInt32(closedaftera.ToString().Trim())) + "</b>";
        //tcell1.Align = "Right";


        //tRow.Cells.Add(tcell1);


        //tcell1 = new HtmlTableCell();
        //if (totStatus.Trim() == "Gr")
        //    tcell1.InnerHtml = "<font color=white><b>" + Convert.ToString(Convert.ToInt32(pendingbefore.ToString().Trim()) + Convert.ToInt32(pendingafter.ToString().Trim())) + "</b></font>";
        //else
        //    tcell1.InnerHtml = "<b>" + Convert.ToString(Convert.ToInt32(pendingbeforea.ToString().Trim()) + Convert.ToInt32(pendingaftera.ToString().Trim())) + "</b>";
        //tcell1.Align = "Right";

        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + Approved.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + Approveda.ToString().Trim() + "</b>";
        tcell1.Align = "Right";

        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + Reject.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + Rejecta.ToString().Trim() + "</b>";
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);

        if (totStatus.Trim() == "Gr")
            tRow.BgColor = "#009688";
        else
            tRow.BgColor = "#009688";
        tbl1.Rows.Add(tRow);
        #endregion


        if (total <= 0)
        {
            //tbl1.Visible = false;
            //  LblStatus.Text = " No Records Found ";
        }
    }

    #endregion

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        // Modified by Srikanth on 13-05-2013
        // Tables Used: COMPLAINT_MASTER,COMPLAINT_TRANS,DEPT,SERVICE,LOCALITY,SERVICE_USERS,USERS
        //if (Session["Dept_Code"].ToString().Trim() == "20")
        //{
        //    if (ddlZone.SelectedIndex == 0)
        //    {
        //        zone = "%";
        //    }
        //    else
        //    {
        //        zone = ddlZone.SelectedValue;
        //    }
        //}
        //else
        //{
        //    ddlZone.SelectedValue = ddlZone.Items.FindByValue(Session["Zone"].ToString().Trim()).Value;
        //    ddlZone.Enabled = false;
        //    zone = ddlZone.SelectedValue.ToString().Trim();
        //}
        // Modified by Srikanth on 13-05-2013
        // Tables Used: COMPLAINT_MASTER,COMPLAINT_TRANS,DEPT,SERVICE,LOCALITY,SERVICE_USERS,USERS

        //THeader();
        FillGrid();
        tbl1.Width = "750";
        //  TTotal("Sr");
        // TTotal("Gr");
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        hdfsms.Value = "1";
        //THeader();
        FillGrid();
        tbl1.Width = "750";
        //  TTotal("Sr");
        //TTotal("Gr");

        cmf.SendSingleSMS("9866584550", "Madam/Sir, CFO : Pendency beyond due date - Pre-scrutiny stage  : " + pendingafter.ToString().Trim() + "  and Approvals stage : " + closedafter.ToString().Trim() + " . Application status informed for perusal and necessary action. TSiPASS (" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ")");

        cmf.SendSingleSMS("9885696486", "Madam/Sir, CFO : Pendency beyond due date - Pre-scrutiny stage  : " + pendingafter.ToString().Trim() + "  and Approvals stage : " + closedafter.ToString().Trim() + " . Application status informed for perusal and necessary action. TSiPASS (" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ")");

        cmf.SendSingleSMS("9247492919", "Madam/Sir, CFO : Pendency beyond due date - Pre-scrutiny stage  : " + pendingafter.ToString().Trim() + "  and Approvals stage : " + closedafter.ToString().Trim() + " . Application status informed for perusal and necessary action. TSiPASS (" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ")");


        cmf.SendSingleSMS("9908077333", "Madam/Sir, CFO : Pendency beyond due date - Pre-scrutiny stage  : " + pendingafter.ToString().Trim() + "  and Approvals stage : " + closedafter.ToString().Trim() + " . Application status informed for perusal and necessary action. TSiPASS (" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ")");

        cmf.SendSingleSMS("9100986717", "Madam/Sir, CFO : Pendency beyond due date - Pre-scrutiny stage  : " + pendingafter.ToString().Trim() + "  and Approvals stage : " + closedafter.ToString().Trim() + " . Application status informed for perusal and necessary action. TSiPASS (" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ")");

        cmf.SendSingleSMS("8331029999", "Madam/Sir, CFO : Pendency beyond due date - Pre-scrutiny stage  : " + pendingafter.ToString().Trim() + "  and Approvals stage : " + closedafter.ToString().Trim() + " . Application status informed for perusal and necessary action. TSiPASS (" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ")");

        //cmf.SendSingleSMS("9848080271", "Madam/Sir, CFO : Pendency beyond due date - Pre-scrutiny stage  : " + pendingafter.ToString().Trim() + "  and Approvals stage : " + closedafter.ToString().Trim() + " . Application status informed for perusal and necessary action. TSiPASS (" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ")");

        cmf.SendSingleSMS("8008007748", "Madam/Sir, CFO : Pendency beyond due date - Pre-scrutiny stage  : " + pendingafter.ToString().Trim() + "  and Approvals stage : " + closedafter.ToString().Trim() + " . Application status informed for perusal and necessary action. TSiPASS (" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ")");



        hdfsms.Value = "0";

    }

    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        //PrintPdf();
    }

    protected void BtnSave2_Click(object sender, EventArgs e)
    {
        //ExportToExcel();
        FillGrid();
    }


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

            string tcMergePackage = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
            //------------------------------------------------------------------------------------------------------------------------------------------------------
            phrase = new Phrase();
            phrase.Add(new Chunk("R5.1: Department wise performance Tracker\n\n", FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));
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

            string cellTextnew = "";
            phrase = new Phrase();
            phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails.HeaderStyle.BackColor);  //#009688
            cell.PaddingBottom = 5;
            cell.Colspan = 4;
            cell.MinimumHeight = 30f;
            tablenew.AddCell(cell);

            phrase = new Phrase();
            cellTextnew = "Pre-Scrutiny-Under Process";
            phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails.HeaderStyle.BackColor);  //#009688
            cell.PaddingBottom = 5;
            cell.Colspan = 2;
            cell.MinimumHeight = 30f;
            tablenew.AddCell(cell);

            cellTextnew = "";
            phrase = new Phrase();
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
            cellTextnew = "Department Approval - Under Process";
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
            cell.Colspan = 2;
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
}