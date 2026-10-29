using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class UI_TSIPASS_feedbackreport_drilldown : System.Web.UI.Page
{
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
    DataSet oDataSet = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        string deptName = "";
        string fromDate = "";
        string toDate = "";
        string applType = "";
        string feedbacktype = "";
        Label3.Text = "Report as on date " + DateTime.Now;
        if (Request.QueryString["deptName"] != null && Request.QueryString["fromDate"] != null && Request.QueryString["toDate"] != null
        && Request.QueryString["applType"] != null && Request.QueryString["feedbacktype"] != null)
        {
            lblheading.Text = Request.QueryString["applType"] + "--" + Request.QueryString["deptName"] + "--" + Request.QueryString["feedbacktype"];
            if (lblheading.Text == "CFE--d--all")
            {
                lblheading.Text = "CFE--AllDepartments--NoofApplicationsApproved";
            }
            if (lblheading.Text == "CFE--d--totalFeedback")
            {
                lblheading.Text = "CFE--AllDepartments--totalFeedback";
            }
            if (lblheading.Text == "CFE--d--EXCELLENT")
            {
                lblheading.Text = "CFE--AllDepartments--EXCELLENT";
            }
            if (lblheading.Text == "CFE--d--GOOD")
            {
                lblheading.Text = "CFE--AllDepartments--GOOD";
            }
            if (lblheading.Text == "CFE--d--SATISFIED")
            {
                lblheading.Text = "CFE--AllDepartments--SATISFIED";
            }
            if (lblheading.Text == "CFE--d--NOTSATISFIED")
            {
                lblheading.Text = "CFE--AllDepartments--NOT SATISFIED";
            }


            if (lblheading.Text == "CFO--d--all")
            {
                lblheading.Text = "CFO--AllDepartments--NoofApplicationsApproved";
            }
            if (lblheading.Text == "CFO--d--totalFeedback")
            {
                lblheading.Text = "CFO--AllDepartments--totalFeedback";
            }
            if (lblheading.Text == "CFO--d--EXCELLENT")
            {
                lblheading.Text = "CFO--AllDepartments--EXCELLENT";
            }
            if (lblheading.Text == "CFO--d--GOOD")
            {
                lblheading.Text = "CFO--AllDepartments--GOOD";
            }
            if (lblheading.Text == "CFO--d--SATISFIED")
            {
                lblheading.Text = "CFO--AllDepartments--SATISFIED";
            }
            if (lblheading.Text == "CFO--d--NOTSATISFIED")
            {
                lblheading.Text = "CFO--AllDepartments--NOT SATISFIED";
            }
            deptName = Request.QueryString["deptName"].ToString();

            fromDate = Convert.ToString(DateTime.ParseExact(Request.QueryString["fromDate"].ToString(), "dd-MM-yyyy", null).ToString("yyyy-MM-dd"));
            toDate = Convert.ToString(DateTime.ParseExact(Request.QueryString["toDate"].ToString(), "dd-MM-yyyy", null).ToString("yyyy-MM-dd"));


            applType = Request.QueryString["applType"].ToString();
            feedbacktype = Request.QueryString["feedbacktype"].ToString();
            osqlConnection.Open();
            oSqlDataAdapter = new SqlDataAdapter("USP_GETFEEDBACKDRILLDOWN", osqlConnection);
            oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            oSqlDataAdapter.SelectCommand.Parameters.Add("@deptName", SqlDbType.VarChar).Value = deptName;
            oSqlDataAdapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.VarChar).Value = fromDate;
            oSqlDataAdapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.VarChar).Value = toDate;
            oSqlDataAdapter.SelectCommand.Parameters.Add("@applType", SqlDbType.VarChar).Value = applType;
            oSqlDataAdapter.SelectCommand.Parameters.Add("@feedbacktype", SqlDbType.VarChar).Value = feedbacktype;

            oDataSet = new DataSet();
            oSqlDataAdapter.Fill(oDataSet);

            osqlConnection.Close();

            grdDetails.DataSource = oDataSet.Tables[0];
            grdDetails.DataBind();

        }
        else
        {
            Response.Redirect("FeedbackReport.aspx");
        }


    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (Request.QueryString["feedbacktype"].ToString() == "all")
            {
                grdDetails.Columns[6].Visible = false;
            }
        }

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
                grdDetails.RenderControl(hw);
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