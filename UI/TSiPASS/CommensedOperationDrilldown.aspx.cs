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

public partial class UI_TSiPASS_CommensedOperationDrilldown : System.Web.UI.Page
{
    string conString = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            Response.Redirect("~/tshome.aspx");
        }
        if (!IsPostBack)
        {
            DataSet dsnew = new DataSet();
            string ONLINEFLAG = "", District = "", Status = "", year = "";
            Label1.Text = "Report as on date " + DateTime.Now;

            Status = Request.QueryString["Status"].ToString();
            ONLINEFLAG = Request.QueryString["ONLINEFLAG"].ToString();
            District = Request.QueryString["dist"].ToString();
            year = Request.QueryString["year"].ToString();

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("USP_GET_IMPLIMENTAION_COMMENCED_DRILLDOWN", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.AddWithValue("@District", SqlDbType.VarChar).Value = District;
            da.SelectCommand.Parameters.AddWithValue("@ONLINEFLAG", SqlDbType.VarChar).Value = ONLINEFLAG;
            da.SelectCommand.Parameters.AddWithValue("@Status", SqlDbType.VarChar).Value = Status;
            da.SelectCommand.Parameters.AddWithValue("@year", SqlDbType.VarChar).Value = year;
            da.Fill(dsnew);
            if (dsnew.Tables[0].Rows.Count > 0)
            {
                lblmsg0.Text = "Total Records Found :" + dsnew.Tables[0].Rows.Count.ToString();
                grdReports.DataSource = dsnew.Tables[0];
                grdReports.DataBind();
            }
            else
            {
                lblmsg0.Text = "Total Records Found : 0";
                grdReports.DataSource = null;
                grdReports.DataBind();

            }
            if (District == "%")
                District = "All Districts";
            if (Status == "A")
            {
                LblGet.Text = " - Commenced Operations With in 3 Months in "+ District;
            }
            else if (Status == "B")
            {
                LblGet.Text = " - Commenced Operations from 3 to 6 Months in " + District;
            }
            else if (Status == "C")
            {
                LblGet.Text = " - Commenced Operations from 6 Months 1 Year in " + District;
            }
            if (Status == "D")
            {
                LblGet.Text = " - Commenced Operations from 1 Year TO 2 Years in " + District;
            }
            else if (Status == "E")
            {
                LblGet.Text = " - Commenced Operations from 2 TO 3 Years in " + District;
            }
            else if (Status == "F")
            {
                LblGet.Text = " - Commenced Operations above 3 Years in " + District;
            }
            if (Status == "G")
            {
                LblGet.Text = " - Total Commenced Operations in " + District;
            }
            if (Status == "I")
            {
                LblGet.Text = " - Total Yet to Start Construction in " + District;
            }
            if (Status == "J")
            {
                LblGet.Text = " - Total Initial Stage in " + District;
            }
            if (Status == "K")
            {
                LblGet.Text = " - Total Advanced Stage in " + District;
            }
        }
    }

    protected void Button2_ServerClick(object sender, EventArgs e)
    {
        try
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    //To Export all pages
                    //trLogo.Visible = true;
                    grdReports.AllowPaging = false;
                    // this.fillgrid();
                    grdReports.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdReports.FooterRow.ForeColor = System.Drawing.Color.Black;
                    grdReports.Columns[1].Visible = false;
                    grdReports.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename= DistricReports.pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.Flush();
                    Response.End();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void A1_ServerClick(object sender, EventArgs e)
    {
        ExportToExcel();
    }
    protected void ExportToExcel()
    {



        try
        {

            Response.Clear();
            Response.Buffer = true;
            string FileName = lblHeader.Text;
            FileName = FileName.Replace(" ", "");
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName + DateTime.Now.ToString("M/d/yyyy") + ".xls");

            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                divPrint1.RenderControl(hw);

                string label1text = Label1.Text;
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='6'><h4>" + lblHeader.Text + "</h4></td></td></tr><tr><td align='center' colspan='6'><h4>" + label1text + "</h4></td></td></tr></table>";
                HttpContext.Current.Response.Write(headerTable);

                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void grdReports_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string intUid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();
            LinkButton btn = (LinkButton)e.Row.FindControl("LinkButton1");
          

            btn.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();
            btn.Text = "View";
            if(intUid != "0")
            {
                btn.OnClientClick = "javascript:return Popup('" + intUid + "')";
            }
            //btn.Enabled = false;
        }
    }
    protected void grdReports_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void grdReports_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }

    protected void grdReports_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}