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

public partial class UI_TSiPASS_frmIncentivePendencyHeadOfficeDrillDown : System.Web.UI.Page
{
    General Gen = new General();
    string conString = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            string USERID = Request.QueryString[0].ToString().Trim();
            string STATUS = Request.QueryString[1].ToString().Trim();
            // string Type = Request.QueryString[2].ToString().Trim();
            Label1.Text = DateTime.Now.ToString("dd-MM-yyyy");
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("USP_GET_INCENTIVE_PENDENCY_HEADOFFICE_NEW_DRILLDOWN", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@USERID", SqlDbType.VarChar).Value = USERID;
            da.SelectCommand.Parameters.AddWithValue("@STATUS", SqlDbType.VarChar).Value = STATUS;
            // da.SelectCommand.Parameters.AddWithValue("@type", SqlDbType.VarChar).Value = Type;
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridPrint.Visible = true;
                grdSanctioned.DataSource = ds.Tables[0];
                grdSanctioned.DataBind();
            }
            else
            {
                Label1.Text = "No Records Found ";
                grdSanctioned.DataSource = null;
                grdSanctioned.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void grdSanctioned_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void grdSanctioned_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void grdSanctioned_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }

    protected void grdSanctioned_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button2_ServerClick(object sender, EventArgs e)
    {
        try
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {

                    grdSanctioned.AllowPaging = false;

                    grdSanctioned.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdSanctioned.FooterRow.ForeColor = System.Drawing.Color.Black;
                    grdSanctioned.RenderControl(hw);
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
}