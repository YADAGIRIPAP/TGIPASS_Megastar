using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class UI_TSiPASS_MSEFCDrilldown : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] == null || Session["uid"].ToString() == "")
        {
            Response.Redirect("~/TSHome.aspx");

        }
        else
        {

            if (Session["Role_Code"].ToString() == "GM" || Session["Role_Code"].ToString() == "IPO"
                || Session["Role_Code"].ToString() == "AD" || Session["Role_Code"].ToString() == "DD"
                || Session["Role_Code"].ToString() == "JD")
            {
                if (!IsPostBack)
                {
                    binddata();

                }
            }
            else { Response.Redirect("~/TSHome.aspx"); }
        }
    }
    protected void binddata()
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter("GetMSEFCDetails", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@Type", SqlDbType.VarChar).Value = Request.QueryString[1];

            //if (Session["Role_Code"].ToString() == "GM")

            //da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = Convert.ToString(Session["DistrictID"]);
            //else
            da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = Request.QueryString[0];
            da.SelectCommand.Parameters.Add("@Fromdate", SqlDbType.VarChar).Value = DateTime.ParseExact(Request.QueryString[2], "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"); ;
            da.SelectCommand.Parameters.Add("@Todate", SqlDbType.VarChar).Value = DateTime.ParseExact(Request.QueryString[3], "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            da.Fill(ds);
            con.CloseConnection();
            if (Request.QueryString[1].ToString() == "MSEFCcamps")
            {
                lblForGrid.Visible = true;
                lblForGrid.Text = "MESFC Camps Details";
                grdcamps.DataSource = ds;
                grdcamps.DataBind();
            }
            else if (Request.QueryString[1].ToString() == "PaymentIssue")
            {
                lblForGrid.Visible = true;
                lblForGrid.Text = "Entrepreneur Details having Payment Issue";
                grdExisting.DataSource = ds;
                grdExisting.DataBind();
            }
            else if (Request.QueryString[1].ToString() == "Casefiled")
            {
                lblForGrid.Visible = true;
                lblForGrid.Text = "Entrepreneur Filed Case Details";
                grdExisting.DataSource = ds;
                grdExisting.DataBind();
            }

        }
        catch (Exception Ex)
        { throw Ex; }

    }
    protected void Button2_ServerClick(object sender, EventArgs e)
    {
        lblHeading.Visible = true;
        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                grdcamps.AllowPaging = false;

                // this.fillgrid();

                grdcamps.HeaderRow.ForeColor = System.Drawing.Color.Black;
                grdcamps.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                grdcamps.FooterRow.ForeColor = System.Drawing.Color.Black;
                // grdExport.Columns[1].Visible = false;
                grdcamps.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=R6.1:TSiPASS-TotalReportold2NewReport" + ".pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.Flush();
                Response.End();
            }
        }

    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void ExportToExcel()
    {
        try
        {
            lblHeading.Visible = true;
            // grdsupport.Columns[6].Visible = false;
            Response.Clear();
            Response.Buffer = true;
            string FileName = lblHeading.Text;
            FileName = FileName.Replace(" ", "");
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                Government.Visible = true;
                grdcamps.Style["width"] = "680px";
                Button1.Visible = false;
                Button2.Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                grdcamps.RenderControl(hw);
                string label1text = lblForGrid.Text;
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='5'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='5'><h4>" + label1text + "</h4></td></td></tr></table>";
                HttpContext.Current.Response.Write(headerTable);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
            //Button1.Visible = true;
            //Button2.Visible = true;
        }
        catch (Exception e)
        {

        }
    }

    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        ExportToExcel();
    }
}