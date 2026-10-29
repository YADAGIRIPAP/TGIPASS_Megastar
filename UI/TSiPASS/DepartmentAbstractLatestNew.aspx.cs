//By Srikanth on 13-05-2013
// For: Abstract for All Zone
// Tables Used: COMPLAINT_MASTER,COMPLAINT_TRANS,DEPT,SERVICE,LOCALITY,SERVICE_USERS,USERS
///Storedprocedure Name : Queries also used.

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;


public partial class FrmUsers : System.Web.UI.Page
{
    HtmlTableRow tRow;
    HtmlTableCell tcell1;
    DataSet ds = new DataSet();
    comFunctions cmf = new comFunctions();
    int cnt = 0;
    string Dept = "";
    DB.DB con1 = new DB.DB();
    General tran1 = new General();
    General csRegComplaint = new General();
    int pendingafter, pendingbefore, closedafter, closedbefore, total, Reject, QueryRaised, QueryRaiseda, Pending, Pendinga, Approved, Approveda, payment;
    int pendingaftera, pendingbeforea, closedaftera, closedbeforea, totala, Rejecta, paymentda;
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
                //FillGrid();
                //tbl1.Width = "750";
                //TTotal("Gr");
                if (Request.QueryString["fromdate"] != null && Request.QueryString["fromdate"] != "" && Request.QueryString["todate"] != null && Request.QueryString["todate"] != "")
                {
                    // Label1.Text = "Report from " + Request.QueryString["fromdate"].ToString().Trim() + " To " + Request.QueryString["todate"].ToString().Trim();
                    txtFromDate.Text = Request.QueryString["fromdate"].ToString().Trim();
                    txtTodate.Text = Request.QueryString["todate"].ToString().Trim();

                    BtnSave2_Click(sender, e);
                }
                else
                {
                    txtFromDate.Text = "01-04-2016";
                    DateTime today = DateTime.Today;
                    txtTodate.Text = today.ToString("dd-MM-yyyy");
                    BtnSave2_Click(sender, e);

                }
            }

        }
    }


    public void FillGrid()
    {
        string FromdateforDB = "", TodateforDB = "";
        FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        DataSet vehicleDS = new DataSet();

        if (Session["DistrictID"].ToString().Trim() != null)
        {
            vehicleDS = tran1.DeptReportDepartmentWise_New1(Session["DistrictID"].ToString().Trim(), "%", FromdateforDB, TodateforDB );
        }
        else
        {
            vehicleDS = tran1.DeptReportDepartmentWise_New1("%", "%", FromdateforDB, TodateforDB );
        }
        GridView1.DataSource = vehicleDS;
        GridView1.DataBind();
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
            Response.AddHeader("content-disposition", "attachment;filename=R5-1-DepartmentwiseperformanceTracker" + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                //GridView1.Columns[1].Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                string FromdateforDB = "", TodateforDB = "";
                if (txtFromDate.Text != "" && txtFromDate.Text.Contains("-"))
                {
                    FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                    TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                }

                DataSet vehicleDS = new DataSet();
                if (Session["DistrictID"].ToString().Trim() != null)
                {
                    //vehicleDS = tran1.DeptReportDepartmentWise_New_export(Session["DistrictID"].ToString().Trim(), "%");
                    vehicleDS = tran1.DeptReportDepartmentWise_New1(Session["DistrictID"].ToString().Trim(), "%", FromdateforDB, TodateforDB);
                }
                else
                {
                    vehicleDS = tran1.DeptReportDepartmentWise_New1("%", "%", FromdateforDB, TodateforDB);
                    //vehicleDS = tran1.DeptReportDepartmentWise_New_export("%", "%");
                }
                BtnSave2_Click(this, EventArgs.Empty);
                //grdExport.DataSource = vehicleDS.Tables[0];
                //grdExport.DataBind();

                tbl1.RenderControl(hw);
                //GridView1.Columns.RemoveAt("View");
                string label1text = Label1.Text;
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='10'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='10'><h4>" + label1text + "</h4></td></td></tr></table>";
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

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TChildHead(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Department Name")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Department Name")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "NoofapplicationsApplied")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CompletedWithinDays")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CompletedBeyondDays")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Pending Less than 3 Days")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Pending More than 3 Days")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Rejected")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Completed")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "QueryRaised")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Number of payment received for")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Approved")));


            if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MobileNumber")).Trim() != "" && hdfsms.Value == "1")
            {

                if ((Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CompletedBeyondDays")) + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Pending More than 3 Days"))) > 5)
                {
                    cmf.SendSingleSMS(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MobileNumber")).Trim(), " " + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Department Name")) + " - Madam/Sir, CFE : Pendency beyond due date - Pre-scrutiny stage  : " + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Pending More than 3 Days")).ToString().Trim() + "  and Approvals stage : " + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CompletedBeyondDays")).ToString().Trim().ToString().Trim() + " . Application status informed for perusal and necessary action. TS-iPASS (" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ")");




                    //cmf.SendSingleSMS("9848080271", " " + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Department Name")) + " - Madam/Sir, CFE : Pendency beyond due date - Pre-scrutiny stage  : " + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Pending More than 3 Days")).ToString().Trim() + "  and Approvals stage : " + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CompletedBeyondDays")).ToString().Trim().ToString().Trim() + " . Application status informed for perusal and necessary action. TS-iPASS (" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ")");

                    cmf.SendSingleSMS("9885696486", " " + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Department Name")) + " - Madam/Sir, CFE : Pendency beyond due date - Pre-scrutiny stage  : " + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Pending More than 3 Days")).ToString().Trim() + "  and Approvals stage : " + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CompletedBeyondDays")).ToString().Trim().ToString().Trim() + " . Application status informed for perusal and necessary action. TS-iPASS (" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ")");

                    cmf.SendSingleSMS("9247492919", " " + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Department Name")) + " - Madam/Sir, CFE : Pendency beyond due date - Pre-scrutiny stage  : " + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Pending More than 3 Days")).ToString().Trim() + "  and Approvals stage : " + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CompletedBeyondDays")).ToString().Trim().ToString().Trim() + " . Application status informed for perusal and necessary action. TS-iPASS (" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ")");

                }
                //cmf.SendSingleSMS("98665 84550", "Madam/Sir, CFE : Pendency beyond due date - Pre-scrutiny stage  : " + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Pending More than 3 Days")).ToString().Trim() + "  and Approvals stage : " + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CompletedBeyondDays")).ToString().Trim().ToString().Trim() + ".Application status informed for perusal and necessary action. TS-iPASS (" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ")");





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

            int payment1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Number of payment received for"));
            payment = payment1 + payment;
            paymentda = payment1 + paymentda;

        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            //e.Row.Cells[1].Text = "Total: ";
            //e.Row.Cells[2].Text = total.ToString().Trim();
            //e.Row.Cells[3].Text = closedbefore.ToString().Trim();
            //e.Row.Cells[4].Text = closedafter.ToString().Trim();
            //e.Row.Cells[5].Text = pendingbefore.ToString().Trim();
            //e.Row.Cells[6].Text = pendingafter.ToString().Trim();
            //e.Row.Cells[7].Text = Pending.ToString().Trim();
            //e.Row.Cells[8].Text = QueryRaised.ToString().Trim();
            //e.Row.Cells[9].Text = Reject.ToString().Trim();

            //e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Center;
            //e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Center;
            //e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
            //e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
            //e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
            //e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Center;
            //e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;

            e.Row.Font.Bold = true;

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
        tcell1.InnerHtml = "<font color=white><b>Pre-Scrutiny-Completed & Payment Pending</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tcell1.RowSpan = 2;

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
        tRow.BgColor = "#286090";
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


        tRow.BgColor = "#286090";
        tRow.BorderColor = "#ffffff";

        tbl1.Rows.Add(tRow);

        #endregion

    }
    protected void PrintPdf()
    {
        try
        {
            string FromdateforDB = "", TodateforDB = "";
            if (txtFromDate.Text != "" && txtFromDate.Text.Contains("-"))
            {
                FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {


                   // grdExport.AllowPaging = false;
                    DataSet vehicleDS = new DataSet();
                    if (Session["DistrictID"].ToString().Trim() != null)
                    {
                        //vehicleDS = tran1.DeptReportDepartmentWise_New_export(Session["DistrictID"].ToString().Trim(), "%");
                        vehicleDS = tran1.DeptReportDepartmentWise_New1(Session["DistrictID"].ToString().Trim(), "%", FromdateforDB, TodateforDB );
                    }
                    else
                    {
                        vehicleDS = tran1.DeptReportDepartmentWise_New1("%", "%", FromdateforDB, TodateforDB );
                        //vehicleDS = tran1.DeptReportDepartmentWise_New_export("%", "%");
                    }

                    //grdExport.DataSource = vehicleDS.Tables[0];
                    //grdExport.DataBind();

                    //grdExport.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    //grdExport.FooterRow.ForeColor = System.Drawing.Color.Black;
                    //// grdExport.Columns[1].Visible = false;
                    //grdExport.RenderControl(hw);
                    BtnSave2_Click(this, EventArgs.Empty);

                    tbl1.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename= TotalApplicationsReceived.pdf");
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
    public void TChildHead(string Service_id, string Department, string Service, string totalReceived, string beforeclose, string afterclose, string beforeopen, string afteropen, string Rejected, string PPending, string QQueryRaised, string Payment, string Approvals)
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
        tcell1.InnerHtml = "<a href='frmDeptstatusbytypeNew.aspx?Id=" + Service_id.Trim() + "&Status=4&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&Type=Total'> " + totalReceived.Trim() + "</a>";
        tcell1.Align = "Right";

        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<a href='frmDeptstatusbytypeNew.aspx?Id=" + Service_id.Trim() + "&Status=2&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&Type=Total'> " + QQueryRaised.Trim() + "</a>";
        tcell1.Align = "Right";

        tRow.Cells.Add(tcell1);
        tbl1.Rows.Add(tRow);

        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<a href='frmDeptstatusbytypeNew.aspx?Id=" + Service_id.Trim() + "&Status=1&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&Type=Within Three Days'> " + beforeopen.Trim() + "</a>";
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);





        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<a href='frmDeptstatusbytypeNew.aspx?Id=" + Service_id.Trim() + "&Status=1&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&Type=Beyond Three Days'> " + afteropen.Trim() + "</a>";
        tcell1.Align = "Right";



        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<a href='frmDeptstatusbytypeNew.aspx?Id=" + Service_id.Trim() + "&Status=5&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&Type=Total'> " + Payment.ToString() + "</a>";
        tcell1.Align = "Right";


        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<a href='frmDeptstatusbytypeNew.aspx?Id=" + Service_id.Trim() + "&Status=3&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&Type=Total'> " + PPending.ToString() + "</a>";
        tcell1.Align = "Right";

        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<a href='frmDeptstatusbytype1New.aspx?Id=" + Service_id.Trim() + "&Status=2&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&Type=Within time limits'> " + beforeclose.Trim() + "</a>";
        tcell1.Align = "Right";

        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<a href='frmDeptstatusbytype1New.aspx?Id=" + Service_id.Trim() + "&Status=2&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&Type=Beyond time limits'> " + afterclose.Trim() + "</a>";
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
        tcell1.InnerHtml = "<a href='frmDeptstatusbytype1New.aspx?Id=" + Service_id.Trim() + "&Status=1&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&Type=Total'> " + Approvals + "</a>";
        tcell1.Align = "Right";

        tRow.Cells.Add(tcell1);
        tbl1.Rows.Add(tRow);


        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<a href='frmDeptstatusbytype1New.aspx?Id=" + Service_id.Trim() + "&Status=3&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&Type=Total'> " + Rejected.Trim() + "</a>";
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
            tcell1.InnerHtml = "<font color=white><b>" + payment.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + paymentda.ToString().Trim() + "</b>";
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
            tRow.BgColor = "#286090";
        else
            tRow.BgColor = "#286090";
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

        THeader();
        FillGrid();
        tbl1.Width = "750";
        //  TTotal("Sr");
        TTotal("Gr");
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        hdfsms.Value = "1";


        THeader();
        FillGrid();
        tbl1.Width = "750";
        //  TTotal("Sr");
        TTotal("Gr");
        // 7702542727

        cmf.SendSingleSMS("9866584550", "Madam/Sir, CFE : Pendency beyond due date - Pre-scrutiny stage  : " + pendingafter.ToString().Trim() + "  and Approvals stage : " + closedafter.ToString().Trim() + " . Application status informed for perusal and necessary action. TSiPASS (" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ")");





        cmf.SendSingleSMS("9885696486", "Madam/Sir, CFE : Pendency beyond due date - Pre-scrutiny stage  : " + pendingafter.ToString().Trim() + "  and Approvals stage : " + closedafter.ToString().Trim() + " . Application status informed for perusal and necessary action. TSiPASS (" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ")");


        cmf.SendSingleSMS("9247492919", "Madam/Sir, CFE : Pendency beyond due date - Pre-scrutiny stage  : " + pendingafter.ToString().Trim() + "  and Approvals stage : " + closedafter.ToString().Trim() + " . Application status informed for perusal and necessary action. TSiPASS (" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ")");

        cmf.SendSingleSMS("9908077333", "Madam/Sir, CFE : Pendency beyond due date - Pre-scrutiny stage  : " + pendingafter.ToString().Trim() + "  and Approvals stage : " + closedafter.ToString().Trim() + " . Application status informed for perusal and necessary action. TSiPASS (" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ")");



        cmf.SendSingleSMS("9100986717", "Madam/Sir, CFE : Pendency beyond due date - Pre-scrutiny stage  : " + pendingafter.ToString().Trim() + "  and Approvals stage : " + closedafter.ToString().Trim() + " . Application status informed for perusal and necessary action. TSiPASS (" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ")");

        cmf.SendSingleSMS("8331029999", "Madam/Sir, CFE : Pendency beyond due date - Pre-scrutiny stage  : " + pendingafter.ToString().Trim() + "  and Approvals stage : " + closedafter.ToString().Trim() + " . Application status informed for perusal and necessary action. TSiPASS (" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ")");


        //cmf.SendSingleSMS("9848080271", "Madam/Sir, CFE : Pendency beyond due date - Pre-scrutiny stage  : " + pendingafter.ToString().Trim() + "  and Approvals stage : " + closedafter.ToString().Trim() + " . Application status informed for perusal and necessary action. TSiPASS (" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ")");

        cmf.SendSingleSMS("8008007748", "Madam/Sir, CFE : Pendency beyond due date - Pre-scrutiny stage  : " + pendingafter.ToString().Trim() + "  and Approvals stage : " + closedafter.ToString().Trim() + " . Application status informed for perusal and necessary action. TSiPASS (" + System.DateTime.Now.ToString("dd-MMM-yyyy") + ")");


        hdfsms.Value = "0";

    }
    protected void BtnSave2_Click(object sender, EventArgs e)
    {
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
            THeader();
            FillGrid();
            tbl1.Width = "750";
            TTotal("Gr");
            //string fromdt = Convert.ToDateTime(txtFromDate.Text.Trim()).ToString("dd-MMM-yyyy");
            //string Todt = Convert.ToDateTime(txtTodate.Text.Trim()).ToString("dd-MMM-yyyy");
            Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();

        }
    }
    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        PrintPdf();
    }
}
