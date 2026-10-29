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
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Data.SqlClient;
using System.Drawing;


public partial class UI_TSiPASS_SANCTIONEDSLCDIPCCLAIMSDRILLDOWN_MANDALWISE : System.Web.UI.Page
{
    decimal NumberTotal, InvestmnetTotal, EmploymentTotal;
    #region Declaration
    General gen = new General();
    General Gen = new General();
    int Sno = 0;
    DB.DB con = new DB.DB();
    DataSet ds;
    DataTable dt;


    DataSet dslist;


    #endregion

    #region Page_Load

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //getdistricts();
            if (Session.Count <= 0)
            {
                Response.Redirect("~/Index.aspx");

            }
            if (Request.QueryString["fromdate"] != null && Request.QueryString["fromdate"] != "" && Request.QueryString["todate"] != null && Request.QueryString["todate"] != "")
            {
                txtFromDate.Text = Request.QueryString["fromdate"].ToString().Trim();
                txtTodate.Text = Request.QueryString["todate"].ToString().Trim();
                Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
            }
            

            fillgrid();
        }
    }
    #endregion

    //protected void getdistricts()
    //{
    //    DataSet dsnew = new DataSet();

    //    dsnew = Gen.GetDistricts();
    //    ddlConnectLoad.DataSource = dsnew.Tables[0];
    //    ddlConnectLoad.DataTextField = "District_Name";
    //    ddlConnectLoad.DataValueField = "District_Name";
    //    ddlConnectLoad.DataBind();
    //    ddlConnectLoad.Items.Insert(0, "--Select--");
    //}
    public void fillgrid()
    {

        string FromdateforDB = "", TodateforDB = "";
        if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
        {
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        }

        DataSet dsnew = new DataSet();
        if (FromdateforDB != "")
            dsnew = FETCHTOTALSANCTIONEdDRILLDOWNDDATA_MANDALWISE( Request.QueryString["MANDAL"].ToString().Trim(), FromdateforDB, TodateforDB,  Request.QueryString["District"].ToString().Trim(), Request.QueryString["CASTE"].ToString().Trim(), Request.QueryString["INCENTIVENAME"].ToString().Trim() );
        else
        {
            dsnew = FETCHTOTALSANCTIONEdDRILLDOWNDDATA_MANDALWISE( Request.QueryString["MANDAL"].ToString().Trim(), FromdateforDB, TodateforDB,  Request.QueryString["District"].ToString().Trim(),Request.QueryString["CASTE"].ToString().Trim(),Request.QueryString["INCENTIVENAME"].ToString().Trim());
        }

        // lblMsg.Text = "";
        if (dsnew.Tables[0].Rows.Count > 0)
        {
            // lblMsg.Text = "Total Records :" +dsnew.Tables[0].Rows.Count.ToString();

            grdDetails.DataSource = dsnew.Tables[0];
            grdDetails.DataBind();

            
                if (txtFromDate.Text.Trim() != "" && txtTodate.Text.Trim() != "")
                    Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
                else
                    Label1.Text = "Report from 01-Jan-2015 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
           
            if (Request.QueryString[2].ToString().Trim() == "%")
            {
                lblHeader.Text = "R21: SANCTIONED CLAIMS-MANDALWISE";
            }
            else
            {
                lblHeader.Text = "R21: SANCTIONED CLAIMS-MANDALWISE - " + Request.QueryString[2].ToString().Trim();
            }
        }
        else
        {
            Label1.Text = "No Records Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }

    }

    public DataSet FETCHTOTALSANCTIONEdDRILLDOWNDDATA_MANDALWISE( string Mandal, string fromdate, string todate,  string District, string Caste, string Incentivename)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();

        try
        {
            da = new SqlDataAdapter("SP_GETSANCTIONEDDRILLDOWNDATA_MANDALWISE", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (Mandal.Trim() == "" || Mandal.Trim() == null || Mandal.Trim() == "%" || Mandal.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@MANDAL", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@MANDAL", SqlDbType.VarChar).Value = Mandal.ToString();
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = fromdate.ToString();
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = todate.ToString();

            if (District.Trim() == "" || District.Trim() == null || District == "--Select--")
                da.SelectCommand.Parameters.Add("@District", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@District", SqlDbType.VarChar).Value = District.ToString();

            if (Caste.Trim() == "" || Caste.Trim() == null || Caste == "--Select--"|| Caste=="0")
                da.SelectCommand.Parameters.Add("@Caste", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@Caste", SqlDbType.VarChar).Value = Caste.ToString();

            if (Incentivename.Trim() == "" || Incentivename.Trim() == null || Incentivename == "--Select--"|| Incentivename == "0")
                da.SelectCommand.Parameters.Add("@Incentivename", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@Incentivename", SqlDbType.VarChar).Value = Incentivename.ToString();

            da.SelectCommand.CommandTimeout = 3600;
            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Header");
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Item");
            e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Right;
        }
        

        if (e.Row.RowType == DataControlRowType.Footer)
        {

            e.Row.Cells[7].Text = "Total";
            //  e.Row.Cells[2].Text = NumberTotal.ToString();
            e.Row.Cells[8].Text = InvestmnetTotal.ToString();
            e.Row.Cells[9].Text = EmploymentTotal.ToString();

        }
    }

    private void AssignGridRowStyle(GridViewRow gr, string cssName)
    {
        try
        {
            if (gr.RowType == DataControlRowType.Header)
            {
                for (int cellIndex = 0; cellIndex < gr.Cells.Count; cellIndex++) gr.Cells[cellIndex].CssClass = "GridviewScrollC1Header";
            }
            else if (gr.RowType == DataControlRowType.Footer)
            {
                gr.CssClass = cssName;

                for (int cellIndex = 0; cellIndex < gr.Cells.Count; cellIndex++)
                {
                    gr.Cells[cellIndex].CssClass = cssName;

                    try
                    {
                        double d;
                        if (Double.TryParse(gr.Cells[cellIndex].Text, out d)) gr.Cells[cellIndex].CssClass = "algnCenter";
                    }
                    catch (Exception) { }
                }
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

                        if (Double.TryParse(gr.Cells[cellIndex].Text, out d)) gr.Cells[cellIndex].CssClass = "algnCenter";

                    }
                    catch (Exception) { }
                }
            }
        }
        catch (Exception) { }
    }

    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grdDetails.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    { }

    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

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
        catch (Exception e)
        {

        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }

    //protected void PrintPdf()
    //{
    //    try
    //    {
    //        using (StringWriter sw = new StringWriter())
    //        {
    //            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
    //            {
    //                //To Export all pages
    //                //trLogo.Visible = true;
    //                grdDetails.AllowPaging = false;
    //                this.fillgrid();
    //                grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
    //                grdDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
    //                grdDetails.RenderControl(hw);
    //                StringReader sr = new StringReader(sw.ToString());
    //                Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
    //                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
    //                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
    //                pdfDoc.Open();
    //                htmlparser.Parse(sr);
    //                pdfDoc.Close();

    //                Response.ContentType = "application/pdf";
    //                string FileName = lblHeader.Text;
    //                FileName = FileName.Replace(" ", "");
    //                Response.AddHeader("content-disposition", "attachment;filename=  " + FileName + ".pdf");
    //                Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //                Response.Write(pdfDoc);
    //                Response.Flush();
    //                Response.End();
    //            }
    //        }
    //    }
    //    catch (Exception e)
    //    {

    //    }
    //}
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
                    //grdDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    string FileName = lblHeader.Text;
                    FileName = FileName.Replace(" ", "");
                    Response.AddHeader("content-disposition", "attachment;filename=  " + FileName + ".pdf");
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
    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
        ExportToExcel();
    }

    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        PrintPdf();
    }
    protected void BtnSave1_Click(object sender, EventArgs e)
    {
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
            fillgrid();
        }
        else
        {
            Failure.Visible = true;
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
    }
}