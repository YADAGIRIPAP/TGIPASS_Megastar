using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_TotalReportDrilldown : System.Web.UI.Page
{

    General Gen = new General();

    string conString = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {     
       
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            string Districtname = Request.QueryString[0].ToString().Trim();           
            txtFromDate.Text = Request.QueryString[1].ToString().Trim();
            txtTodate.Text = Request.QueryString[2].ToString().Trim();
            string status = Request.QueryString[3].ToString().Trim();
            string distid = Request.QueryString[4];
            string FromdateforDB = "", TodateforDB = "";

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Sp_DistApplDatewiseTotalAppldrilldown", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
            {
                da.SelectCommand.Parameters.AddWithValue("@District", SqlDbType.VarChar).Value = Districtname;
                FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                da.SelectCommand.Parameters.AddWithValue("@FromDate", SqlDbType.Date).Value = FromdateforDB;
                da.SelectCommand.Parameters.AddWithValue("@ToDate", SqlDbType.Date).Value = TodateforDB;
                da.SelectCommand.Parameters.AddWithValue("@status", SqlDbType.VarChar).Value = status;

            }

            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                // lblMsg.Text = "Total Records :" +dsnew.Tables[0].Rows.Count.ToString();

                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();

                if (ddlType.SelectedValue == "3")
                {
                    Label1.Text = "Report from 01-April-2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
                }
                else
                {
                    if (txtFromDate.Text.Trim() != "" && txtTodate.Text.Trim() != "")
                        Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
                    else
                        Label1.Text = "Report from 01-Jan-2015 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
                }
                if (Request.QueryString[2].ToString().Trim() == "%")
                {
                    lblHeader.Text = "R6.1: TSiPASS- District Wise Report";
                }
                else
                {
                    LblGet.Visible = true;
                    if (status== "Appliedwithinperiod")
                    {
                        LblGet.Text = "No Of Industries Applied Within Selected Period (" + txtFromDate.Text + " To " + txtTodate.Text + ") In " + Districtname;
                    }
                    else if (status== "Approvedwithinperiod")
                    {
                        LblGet.Text = "No Of Industries Approved Within Selected Period (" + txtFromDate.Text + " To " + txtTodate.Text + ") In " + Districtname;

                    }
                    else if (status== "Approvedoutofperiod")
                    {
                        LblGet.Text = "No Of Industries Approved Beyond Selected Period (" + txtFromDate.Text + " To " + txtTodate.Text + ") In " + Districtname;

                    }
                    else if (status== "Investment")
                    {
                        LblGet.Text = "Investment Approved (" + txtFromDate.Text + " To " + txtTodate.Text + ") In " + Districtname;
                    }
                }
                
            }
            else
            {
                Label1.Text = "No Records Found ";
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }

            HyperLink1.NavigateUrl = "TotalReport.aspx?status=" + status + "&lbl=Application Received&dist=" + Districtname + " &fromdate=" + txtFromDate.Text.Trim() + "&todate=" + txtTodate.Text.Trim()+ "&Districtid=" + distid;

        }
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string intUid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim();
            LinkButton btn = (LinkButton)e.Row.FindControl("LinkButton1");
            btn.Text = "View";
            if (intUid != "0")
            {
                btn.OnClientClick = "javascript:return Popup('" + intUid + "')";
            }
            else
                btn.Enabled = false;    

          
        }
    }

    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
       
    }

    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[2].Visible = false;
    }

    protected void Button2_ServerClick(object sender, EventArgs e)
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
        catch (Exception ex)
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

            string FileName = lblHeader.Text;
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
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='10'><h4>" + lblHeader.Text + "</h4></td></td></tr><tr><td align='center' colspan='10'><h4>" + label1text + "</h4></td></td></tr></table>";
                HttpContext.Current.Response.Write(headerTable);

                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        catch (Exception ex)
        {

        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void A1_ServerClick(object sender, EventArgs e)
    {
        ExportToExcel();
    }

    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}