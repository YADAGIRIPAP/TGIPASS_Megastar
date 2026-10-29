using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Globalization;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;


public partial class UI_TSiPASS_CFECFODrilldownpage_print : System.Web.UI.Page
{
    General Gen = new General();

    string conString = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

        lblHeading.Text = "View Applications";
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            string dept = Request.QueryString[0].ToString().Trim();
            string status = Request.QueryString[1].ToString().Trim();
            txtFromDate.Text = Request.QueryString[2].ToString().Trim();
            txtTodate.Text = Request.QueryString[3].ToString().Trim();
            string type = Request.QueryString[4].ToString().Trim();
            string approval = Request.QueryString[5].ToString().Trim();
            lbllable.Text = type;
            string FromdateforDB = "", TodateforDB = "";

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("DeptReportDepartmentWise_New1_CFE_FORAGENDA_drilldown", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
            {
                da.SelectCommand.Parameters.AddWithValue("@status", SqlDbType.VarChar).Value = status;
                da.SelectCommand.Parameters.AddWithValue("@type", SqlDbType.VarChar).Value = type;
                da.SelectCommand.Parameters.AddWithValue("@dept", SqlDbType.VarChar).Value = dept;
                da.SelectCommand.Parameters.AddWithValue("@approvalid", SqlDbType.VarChar).Value = approval;
                FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                da.SelectCommand.Parameters.AddWithValue("@FromDate", SqlDbType.Date).Value = FromdateforDB;
                da.SelectCommand.Parameters.AddWithValue("@ToDate", SqlDbType.Date).Value = TodateforDB;
                da.SelectCommand.CommandTimeout = 3600;
            }

            da.Fill(ds);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ds.Tables[0].Columns.Remove("DOA");
                if (type == "CFO")
                {
                    grdExport.DataSource = ds.Tables[0];
                    grdExport.DataBind();
                    Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
                    divExport.Visible = true;
                }
                else if (type == "CFE")
                {
                    grdDetails.DataSource = ds.Tables[0];
                    grdDetails.DataBind();
                    Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
                }

            }
            else
            {
                Label1.Text = "No Records Found ";
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }
            HyperLink1.NavigateUrl = "frmcfecfoReviewPendency.aspx?status=" + status + "&lbl=Total Applications Received&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;


        }
    }



    protected void Button3_Click(object sender, EventArgs e)
    {



    }

    private void AssignGridRowStyle(GridViewRow gr, string cssName)
    {
        try
        {
            if (gr.RowType == DataControlRowType.Header)
            {
                for (int cellIndex = 0; cellIndex < gr.Cells.Count; cellIndex++) gr.Cells[cellIndex].CssClass = "GridviewScrollC1Header";
            }
            else
            {
                gr.CssClass = cssName;

                for (int cellIndex = 0; cellIndex < gr.Cells.Count; cellIndex++)
                {
                    gr.Cells[cellIndex].CssClass = cssName;

                    try
                    {
                        double d;
                        if (Double.TryParse(gr.Cells[cellIndex].Text, out d)) gr.Cells[cellIndex].CssClass = "algnRight";
                    }
                    catch (Exception) { }
                }
            }
        }
        catch (Exception) { }
    }

    protected void Button2_ServerClick(object sender, EventArgs e)
    {
        ExportToExcel();
    }

    protected void Button1_ServerClick(object sender, EventArgs e)
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
                    // this.fillgrid();
                    grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.Columns[1].Visible = false;
                    grdDetails.RenderControl(hw);
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
    protected void ExportToExcel()
    {
        try
        {

            string FromdateforDB = "", TodateforDB = "";
            if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
            {
                FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }
            Response.Clear();
            Response.Buffer = true;

            string FileName = lblHeading.Text;
            FileName = FileName.Replace(" ", "");
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName + DateTime.Now.ToString("M/d/yyyy") + ".xls");

            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                DataSet ds = new DataSet();
                string status = Request.QueryString[1].ToString().Trim();
                string type = Request.QueryString[4].ToString().Trim();
                string fromdate = Request.QueryString[2].ToString().Trim();
                string todate = Request.QueryString[3].ToString().Trim();

                SqlConnection con = new SqlConnection(conString);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("DeptReportDepartmentWise_New1_CFE_FORAGENDA_drilldown", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //if (Session["DistrictID"].ToString().Trim() != "")
                //{
                //    ds = Gen.RetriveStatusByTypeDistrictNew(status, type, "%", Request.QueryString[0].ToString().Trim(), Session["DistrictID"].ToString().Trim(), FromdateforDB, TodateforDB);
                //}
                //else
                //{
                //    ds = Gen.RetriveStatusByTypeDistrictNew(status, type, "%", Request.QueryString[0].ToString().Trim(), "%", FromdateforDB, TodateforDB);
                //}

                ds.Tables[0].Columns.Remove("DOA");
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
                grdDetails.RenderControl(hw);
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

    protected void grdDetails_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Header");
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Item");
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Item");
            e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[0].CssClass = "text-center";


            string intUid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim();
            LinkButton btn = (LinkButton)e.Row.FindControl("LinkButton1");

            btn.Text = "View";
            btn.OnClientClick =

            btn.OnClientClick = "javascript:return Popup('" + intUid + "')";

            //string intUid1 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireCFOid")).Trim();
            //LinkButton btn1 = (LinkButton)e.Row.FindControl("LinkButton2");

            //btn.Text = "View";
            //btn.OnClientClick =

            //btn.OnClientClick = "javascript:return Popup('" + intUid + "')";
        }
    }

    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[2].Visible = false;
    }

    protected void grdExport_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Header");
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Item");
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Item");
            e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[0].CssClass = "text-center";

            string intUid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireCFOid")).Trim();
            LinkButton btn = (LinkButton)e.Row.FindControl("LinkButton2");

            btn.Text = "View";
            btn.OnClientClick =

            btn.OnClientClick = "javascript:return PopupCFO('" + intUid + "')";
        }
    }
    protected void grdExport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[2].Visible = false;
    }
}