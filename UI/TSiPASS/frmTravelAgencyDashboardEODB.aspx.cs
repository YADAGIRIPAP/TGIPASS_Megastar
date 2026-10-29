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

public partial class UI_TSiPASS_frmTravelAgencyDashboardEODB : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    General Gen = new General();
    int valid = 0;
    string FromdateforDB = "", TodateforDB = "";

    decimal Nounits, IncipientSick, Sick, WillfulDefaulters, TEVStudyDone, Restructuringundertaken, SARFAESI, AccountClosed;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session.Count <= 0)
        //{
        //    Response.Redirect("~/Index.aspx");
        //}
        if (!IsPostBack)
        {
            txtFromDate.Text = "01-11-2020";
            txtTodate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
            DataSet dsd = new DataSet();
            dsd = Gen.GetDepartment();
            ddlDepartment.DataSource = dsd.Tables[0];
            ddlDepartment.DataValueField = "Dept_Id";
            ddlDepartment.DataTextField = "Dept_Name";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, "--Select--");
            LBLDATETIME.Text = System.DateTime.Now.ToString();
            //fillgrid();
        }
    }



    public void fillgrid(string fromDate, string toDate)
    {
        LBLDATETIME.Text = System.DateTime.Now.ToString();
        DataSet dsnew = new DataSet();
        string ReleaseProceedingNo = "";
        if (ddlDepartment.SelectedValue == "--Select--")
        {
            lblmsg0.Text = "Please Select Department <br/>";
            valid = 1;
        }
        //if (txtTodate.Text == "" || txtTodate.Text == null)
        //{
        //    lblmsg0.Text += "Please Enter To Date <br/>";
        //    valid = 1;
        //}
        if (valid == 0)
        {
            //FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            //TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        }
        dsnew = GetReleaseDashboardApplications(ddlDepartment.SelectedValue, ddlapprovalname.SelectedValue, "", fromDate, toDate);
        // lblMsg.Text = "";
        if (dsnew.Tables[0].Rows.Count > 0)
        {
            // lblMsg.Text = "Total Records :" +dsnew.Tables[0].Rows.Count.ToString();
            grdDetails.DataSource = dsnew.Tables[0];
            grdDetails.DataBind();
            //bindgrdDetailsfooter(dsnew.Tables[0]);
        }
        else
        {
            //lblMsg.Text = "";
            // Label1.Text = "No Recards Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
        lblHeadingText.Text = "Travel Agency Dashboard from " + txtFromDate.Text + " to " + txtTodate.Text + "";
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {


    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //decimal Nounits1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Micro"));
            //Nounits = Nounits1 + Nounits;

            //decimal IncipientSick1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ADCOUNT"));
            //IncipientSick = IncipientSick1 + IncipientSick;

            //decimal Sick1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "DDCOUNT"));
            //Sick = Sick1 + Sick;

            //decimal WillfulDefaulters1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "GMCOUNT"));
            //WillfulDefaulters = WillfulDefaulters1 + WillfulDefaulters;


            //HyperLink h1 = (HyperLink)e.Row.FindControl("HyNoofClaimsFiled");
            //h1.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim();

            //HyperLink h2 = (HyperLink)e.Row.FindControl("HyperLink2");
            //h2.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=AD&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim();

            //HyperLink h3 = (HyperLink)e.Row.FindControl("HyperLink3");
            //h3.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=DD&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim();

            //HyperLink h4 = (HyperLink)e.Row.FindControl("HyperLink10");
            //h4.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=GM&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim();


        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            //e.Row.Cells[1].Text = "Total";

            //Label nounitstotal = new Label();
            //nounitstotal.Text = Nounits.ToString();
            //e.Row.Cells[2].Text = Nounits.ToString();
            //e.Row.Cells[2].Controls.Add(nounitstotal);


            //Label IncipientSicktotal = new Label();
            //IncipientSicktotal.Text = IncipientSick.ToString();
            //e.Row.Cells[3].Text = IncipientSick.ToString();
            //e.Row.Cells[3].Controls.Add(IncipientSicktotal);

            ////Label Claims = new Label();
            ////Claims.Text = NoOfClaims.ToString();
            ////e.Row.Cells[2].Text = NoOfClaims.ToString();
            ////e.Row.Cells[2].Controls.Add(Claims);


            //Label Sick1 = new Label();
            //Sick1.Text = Sick.ToString();
            //e.Row.Cells[4].Text = Sick.ToString();
            //e.Row.Cells[4].Controls.Add(Sick1);

            //Label WillfulDefaulters1 = new Label();
            //WillfulDefaulters1.Text = WillfulDefaulters.ToString();
            //e.Row.Cells[5].Text = WillfulDefaulters.ToString();
            //e.Row.Cells[5].Controls.Add(WillfulDefaulters1);



        }
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                grdDetails.RenderControl(hw);

                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='6'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='6'></td></td></tr></table>";
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
                    Response.AddHeader("content-disposition", "attachment;filename= Banker Report.pdf");
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

    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        PrintPdf();
    }

    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        //string status = Request.QueryString[0].ToString().Trim();
        //DataSet ds = new DataSet();
        //string input, financial, fromdate, todate;
        //input = rbtnlstInputType.SelectedValue.ToString().Trim();
        //financial = ddlFinancialYear.SelectedValue.ToString().Trim();
        //fromdate = txtFromDate.Text;
        //todate = txtTodate.Text;
        //ds = Gen.getR1DrildownbyidfinNew(status, ddlCategory.SelectedItem.Text, ddldistrict.SelectedValue, input, financial, fromdate, todate);

        //if (ds != null && ds.Tables[0].Rows.Count > 0)
        //{
        //    Label1.Text = "Report from 1st April 2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
        //    ds.Tables[0].Columns.Remove("DOA");
        //    grdDetails.DataSource = ds.Tables[0];
        //    grdDetails.DataBind();
        //}
        //else
        //{
        //    Label1.Text = "No Records Found ";
        //    grdDetails.DataSource = ds.Tables[0];
        //    grdDetails.DataBind();
        //}
        int valid = 0;
        lblmsg0.Text = "";
        Failure.Visible = false;

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
        //if (rbtnlstInputType.SelectedValue == "N")
        //{
        //if (txtFromDate.Text == "" || txtFromDate.Text == null)
        //{
        //    lblmsg0.Text = "Please Enter From Date <br/>";
        //    valid = 1;
        //}
        //if (txtTodate.Text == "" || txtTodate.Text == null)
        //{
        //    lblmsg0.Text += "Please Enter To Date <br/>";
        //    valid = 1;
        //}
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
            fillgrid(FromdateforDB, TodateforDB);
        }
        else
        {
            Failure.Visible = true;
        }
    }

    public DataSet GetReleaseDashboardApplications(string deptid, string approvalid, string appltype, string fromDate, string toDate)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
             new SqlParameter("@DEPTID",SqlDbType.VarChar),
                new SqlParameter("@APPROVALID",SqlDbType.VarChar),              
               new SqlParameter("@TYPEOFAPPLICATION",SqlDbType.VarChar),
               new SqlParameter("@fromDate",SqlDbType.VarChar),
               new SqlParameter("@toDate",SqlDbType.VarChar)

           };
        pp[0].Value = deptid;
        pp[1].Value = approvalid;
        pp[2].Value = appltype;
        pp[3].Value = fromDate;
        pp[4].Value = toDate;


        Dsnew = Gen.GenericFillDs("USP_GET_DASHBOARD_EODB_TRAVELAGENCY", pp);
        return Dsnew;

    }

    protected void ddlDepartment_TextChanged(object sender, EventArgs e)
    {
        DataSet dsdept = new DataSet();
        dsdept = Gen.GetDeptApprovalsListFeedback(Convert.ToInt32(ddlDepartment.SelectedValue));
        ddlapprovalname.DataSource = dsdept.Tables[0];
        ddlapprovalname.DataValueField = "ApprovalId";
        ddlapprovalname.DataTextField = "ApprovalName";
        ddlapprovalname.DataBind();
        ddlapprovalname.Items.Insert(0, "--Select--");
    }
}