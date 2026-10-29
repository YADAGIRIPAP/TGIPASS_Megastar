using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Data.SqlClient;
public partial class UI_TSiPASS_FeedbackReport : System.Web.UI.Page
{
    General Gen = new General();
    int valid = 0;
    string FromdateforDB = "", TodateforDB = "";
    decimal NOOFAPPLICATIONSAPPROVED, TOTALNOOFFEEDBACKGIVEN, EXCELLENT, GOOD, SATISFIED, NOTSATISFIED;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            txtFromDate.Text = "22-09-2020";
            DateTime today = DateTime.Today;
            txtTodate.Text = today.ToString("dd-MM-yyyy");

            Label1.Text = "Report as on date " + DateTime.Now;
            fillgrid();
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
        dsnew = GetDepartmentWiseFeedBacks(FromdateforDB, TodateforDB, ddlApplicationType.SelectedItem.Text, ddldepartment.SelectedValue);

        if (dsnew.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = dsnew.Tables[0];
            grdDetails.DataBind();

        }
        else
        {

            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
    }
    public DataSet GetDepartmentWiseFeedBacks(string fromdate, string todate, string applicationtype, string department)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
             new SqlParameter("@FromDate",SqlDbType.VarChar),
                new SqlParameter("@ToDate",SqlDbType.VarChar),
               new SqlParameter("@APPLTYPE",SqlDbType.VarChar),
               new SqlParameter("@DEPARTMENTID",SqlDbType.VarChar),

           };
        pp[0].Value = fromdate;
        pp[1].Value = todate;
        pp[2].Value = applicationtype;
        pp[3].Value = department;

        //Dsnew = Gen.GenericFillDs("USP_GET_DISTRICTREPORT_ENTERPRISETYPE", pp);
        Dsnew = Gen.GenericFillDs("USP_GET_FEEDBACK_REPORT_COI", pp);
        return Dsnew;
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            decimal NOOFAPPLICATIONSAPPROVED1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "No Units Approved"));
            NOOFAPPLICATIONSAPPROVED = NOOFAPPLICATIONSAPPROVED1 + NOOFAPPLICATIONSAPPROVED;

            decimal TOTALNOOFFEEDBACKGIVEN1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TOTALFEEDBACKGIVEN"));
            TOTALNOOFFEEDBACKGIVEN = TOTALNOOFFEEDBACKGIVEN1 + TOTALNOOFFEEDBACKGIVEN;

            decimal EXCELLENT1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "EXCELLENTCOUNT"));
            EXCELLENT = EXCELLENT1 + EXCELLENT;

            decimal GOOD1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "GOODCOUNT"));
            GOOD = GOOD1 + GOOD;

            decimal SATISFIED1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SATISFIEDCOUNT"));
            SATISFIED = SATISFIED1 + SATISFIED;

            decimal NOTSATISFIED1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOTSATISFIEDCOUNT"));
            NOTSATISFIED = NOTSATISFIED1 + NOTSATISFIED;


            string departmentname = DataBinder.Eval(e.Row.DataItem, "DEPT Name").ToString();
            string approvalname = DataBinder.Eval(e.Row.DataItem, "APPROVALID Name").ToString();

            HyperLink h1 = (HyperLink)e.Row.Cells[3].Controls[0];
            if (h1.Text != "0")
            {
                h1.NavigateUrl = "feedbackreport_drilldown.aspx?deptName=" + departmentname + "&fromDate=" + txtFromDate.Text + "&toDate=" + txtTodate.Text + "&applType=" + ddlApplicationType.SelectedItem.Text + "&feedbacktype=all";
            }
            HyperLink h2 = (HyperLink)e.Row.Cells[4].Controls[0];
            if (h2.Text != "0")
            {
                h2.NavigateUrl = "feedbackreport_drilldown.aspx?deptName=" + departmentname + "&fromDate=" + txtFromDate.Text + "&toDate=" + txtTodate.Text + "&applType=" + ddlApplicationType.SelectedItem.Text + "&feedbacktype=totalFeedback";
            }

            HyperLink h3 = (HyperLink)e.Row.Cells[5].Controls[0];
            if (h3.Text != "0")
            {
                h3.NavigateUrl = "feedbackreport_drilldown.aspx?deptName=" + departmentname + "&fromDate=" + txtFromDate.Text + "&toDate=" + txtTodate.Text + "&applType=" + ddlApplicationType.SelectedItem.Text + "&feedbacktype=EXCELLENT";
            }
            HyperLink h4 = (HyperLink)e.Row.Cells[6].Controls[0];
            if (h4.Text != "0")
            {
                h4.NavigateUrl = "feedbackreport_drilldown.aspx?deptName=" + departmentname + "&fromDate=" + txtFromDate.Text + "&toDate=" + txtTodate.Text + "&applType=" + ddlApplicationType.SelectedItem.Text + "&feedbacktype=GOOD";
            }
            HyperLink h5 = (HyperLink)e.Row.Cells[7].Controls[0];
            if (h5.Text != "0")
            {
                h5.NavigateUrl = "feedbackreport_drilldown.aspx?deptName=" + departmentname + "&fromDate=" + txtFromDate.Text + "&toDate=" + txtTodate.Text + "&applType=" + ddlApplicationType.SelectedItem.Text + "&feedbacktype=SATISFIED";
            }
            HyperLink h6 = (HyperLink)e.Row.Cells[8].Controls[0];
            if (h6.Text != "0")
            {
                h6.NavigateUrl = "feedbackreport_drilldown.aspx?deptName=" + departmentname + "&fromDate=" + txtFromDate.Text + "&toDate=" + txtTodate.Text + "&applType=" + ddlApplicationType.SelectedItem.Text + "&feedbacktype=NOTSATISFIED";
            }

        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total";

            HyperLink Total = new HyperLink();
            Total.ForeColor = System.Drawing.Color.White;
            Total.NavigateUrl = "feedbackreport_drilldown.aspx?deptName=d&fromDate=" + txtFromDate.Text + "&toDate=" + txtTodate.Text + "&applType=" + ddlApplicationType.SelectedItem.Text + "&feedbacktype=all";
            Total.Text = NOOFAPPLICATIONSAPPROVED.ToString();
            //e.Row.Cells[2].Controls.RemoveAt(0);
            e.Row.Cells[3].Text = NOOFAPPLICATIONSAPPROVED.ToString();
            e.Row.Cells[3].Controls.Add(Total);



            HyperLink TOTALAPPLNS = new HyperLink();
            TOTALAPPLNS.ForeColor = System.Drawing.Color.White;
            TOTALAPPLNS.NavigateUrl = "feedbackreport_drilldown.aspx?deptName=d&fromDate=" + txtFromDate.Text + "&toDate=" + txtTodate.Text + "&applType=" + ddlApplicationType.SelectedItem.Text + "&feedbacktype=totalFeedback";
            TOTALAPPLNS.Text = TOTALNOOFFEEDBACKGIVEN.ToString();
            //e.Row.Cells[2].Controls.RemoveAt(0);
            e.Row.Cells[4].Text = TOTALNOOFFEEDBACKGIVEN.ToString();
            e.Row.Cells[4].Controls.Add(TOTALAPPLNS);

            HyperLink TOTAEXCELLENT = new HyperLink();
            TOTAEXCELLENT.ForeColor = System.Drawing.Color.White;
            TOTAEXCELLENT.NavigateUrl = "feedbackreport_drilldown.aspx?deptName=d&fromDate=" + txtFromDate.Text + "&toDate=" + txtTodate.Text + "&applType=" + ddlApplicationType.SelectedItem.Text + "&feedbacktype=EXCELLENT";
            TOTAEXCELLENT.Text = EXCELLENT.ToString();
            //e.Row.Cells[2].Controls.RemoveAt(0);
            e.Row.Cells[5].Text = EXCELLENT.ToString();
            e.Row.Cells[5].Controls.Add(TOTAEXCELLENT);

            HyperLink TOTALGOOD = new HyperLink();
            TOTALGOOD.ForeColor = System.Drawing.Color.White;
            TOTALGOOD.NavigateUrl = "feedbackreport_drilldown.aspx?deptName=d&fromDate=" + txtFromDate.Text + "&toDate=" + txtTodate.Text + "&applType=" + ddlApplicationType.SelectedItem.Text + "&feedbacktype=GOOD";
            TOTALGOOD.Text = GOOD.ToString();
            //e.Row.Cells[2].Controls.RemoveAt(0);
            e.Row.Cells[6].Text = GOOD.ToString();
            e.Row.Cells[6].Controls.Add(TOTALGOOD);

            HyperLink TOTALSATISFIED = new HyperLink();
            TOTALSATISFIED.ForeColor = System.Drawing.Color.White;
            TOTALSATISFIED.NavigateUrl = "feedbackreport_drilldown.aspx?deptName=d&fromDate=" + txtFromDate.Text + "&toDate=" + txtTodate.Text + "&applType=" + ddlApplicationType.SelectedItem.Text + "&feedbacktype=SATISFIED";
            TOTALSATISFIED.Text = SATISFIED.ToString();
            //e.Row.Cells[2].Controls.RemoveAt(0);
            e.Row.Cells[7].Text = SATISFIED.ToString();
            e.Row.Cells[7].Controls.Add(TOTALSATISFIED);

            HyperLink TOTALNOTSATISFIED = new HyperLink();
            TOTALNOTSATISFIED.ForeColor = System.Drawing.Color.White;
            TOTALNOTSATISFIED.NavigateUrl = "feedbackreport_drilldown.aspx?deptName=d&fromDate=" + txtFromDate.Text + "&toDate=" + txtTodate.Text + "&applType=" + ddlApplicationType.SelectedItem.Text + "&feedbacktype=NOTSATISFIED";
            TOTALNOTSATISFIED.Text = NOTSATISFIED.ToString();
            //e.Row.Cells[2].Controls.RemoveAt(0);
            e.Row.Cells[8].Text = NOTSATISFIED.ToString();
            e.Row.Cells[8].Controls.Add(TOTALNOTSATISFIED);


            //e.Row.Cells[3].Text = NOOFAPPLICATIONSAPPROVED.ToString();
            //e.Row.Cells[4].Text = TOTALNOOFFEEDBACKGIVEN.ToString();
            //e.Row.Cells[5].Text = EXCELLENT.ToString();

            // e.Row.Cells[6].Text = GOOD.ToString();
            //e.Row.Cells[7].Text = SATISFIED.ToString();
            // e.Row.Cells[8].Text = NOTSATISFIED.ToString();






        }
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void ddlApplicationType_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds = DepartmentNamesByApplicationType(ddlApplicationType.SelectedValue);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddldepartment.DataSource = ds.Tables[0];
            ddldepartment.DataValueField = "Dept_Id";
            ddldepartment.DataTextField = "Dept_Name";
            ddldepartment.DataBind();
            System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("--Select--", "%");
            ddldepartment.Items.Insert(0, li);
        }
        else
        {
            System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("--Select--", "%");
            ddldepartment.Items.Insert(0, li);
        }
    }
    protected void BtnSave1_Click(object sender, EventArgs e)
    {

        int valid = 0;
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
            fillgrid();
        }
        else
        {
            Failure.Visible = true;
        }
    }
    public DataSet DepartmentNamesByApplicationType(string applicationtype)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
        
               new SqlParameter("@APPLICATIONTYPEID",SqlDbType.VarChar)
         

           };

        pp[0].Value = applicationtype;


        //Dsnew = Gen.GenericFillDs("USP_GET_DISTRICTREPORT_ENTERPRISETYPE", pp);
        Dsnew = Gen.GenericFillDs("GETDEPARTMENTSBYAPPLICATIONID", pp);
        return Dsnew;
    }

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

                    //this.FillGridDetails();

                    //grdDetails.RenderControl(hw);
                    //StringReader sr = new StringReader(sw.ToString());
                    //Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    //pdfDoc.Open();
                    //htmlparser.Parse(sr);
                    //pdfDoc.Close();
                    grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                    grdDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.FooterStyle.ForeColor = System.Drawing.Color.Black;

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
                    Response.AddHeader("content-disposition", "attachment;filename= FeedBack Report.pdf");
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
    public override void VerifyRenderingInServerForm(Control control)
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
}