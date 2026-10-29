using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class UI_TSiPASS_EntrpreneurDetailsOnPlatforms : System.Web.UI.Page
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
            if (Session["Role_Code"].ToString() == "GM" || Session["Role_Code"].ToString() == "JD")
            {
                if (!IsPostBack)
                {
                    Binddata(Request.QueryString[0], Request.QueryString[1], Request.QueryString[2], Request.QueryString[3]);
                }
            }
            else { Response.Redirect("~/TSHome.aspx"); }
        }
    }
    protected void Binddata(string Districtid, string type, string fromdate, string todate)
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter("SP_EntrpreneurDetailsOnPlatforms", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.Date).Value = DateTime.ParseExact(fromdate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.Date).Value = DateTime.ParseExact(todate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = Districtid;
            da.SelectCommand.Parameters.Add("@Type", SqlDbType.VarChar).Value = type;
            da.Fill(ds);
            con.CloseConnection();
            lblForGrid.Visible = true;
            if (type == "Meesho")
            {
                lblForGrid.Text = "Entrepreneur Details On Meesho Platform";

                grdMeeshoDetails.DataSource = ds.Tables[0];
                grdMeeshoDetails.DataBind();
            }
            else if(type == "JustDial")
            {
                lblForGrid.Text = "Entrepreneur Details On Just-Dial Platform";
                grdJustdialDetails.DataSource = ds.Tables[0];
                grdJustdialDetails.DataBind();
            }
            else if (type == "TSGlobal")
            {
                lblForGrid.Text = "Entrepreneur Details On TS-Global Linker Platform";
                grdTSGlobalDetails.DataSource = ds.Tables[0];
                grdTSGlobalDetails.DataBind();
            }
            else if (type == "Wallmart")
            {
                lblForGrid.Text = "Entrepreneur Details On WallMart Vriddi Platform";
                grdwallmartDetails.DataSource = ds.Tables[0];
                grdwallmartDetails.DataBind();
            }
            else if (type == "InvoiceMart")
            {
                lblForGrid.Text = "Entrepreneur Details On InvoiceMart Platform";
                grdInvoiceMartDetails.DataSource = ds.Tables[0];
                grdInvoiceMartDetails.DataBind();
            }
            else if (type == "NSE")
            {
                lblForGrid.Text = "Entrepreneur Details On NSE Platform";
                grdNSEandSIDBI.DataSource = ds.Tables[0];
                grdNSEandSIDBI.DataBind();
                grdNSEandSIDBI.Columns[4].Visible = false;
                grdNSEandSIDBI.Columns[19].Visible = false;
                grdNSEandSIDBI.Columns[20].Visible = false;
                grdNSEandSIDBI.Columns[21].Visible = false;
            }
            else if (type == "SIDBI")
            {
                lblForGrid.Text = "Entrepreneur Details On SIDBI Platform";
                grdNSEandSIDBI.DataSource = ds.Tables[0];
                grdNSEandSIDBI.DataBind();
                grdNSEandSIDBI.Columns[3].Visible = false;
                grdNSEandSIDBI.Columns[13].Visible = false;
                grdNSEandSIDBI.Columns[14].Visible = false;
                grdNSEandSIDBI.Columns[15].Visible = false;
                grdNSEandSIDBI.Columns[16].Visible = false;
                grdNSEandSIDBI.Columns[17].Visible = false;
                grdNSEandSIDBI.Columns[18].Visible = false;
            }
            else if(type == "Meeshointrsted")
            {
                lblForGrid.Text = "Meesho Platform interested Entrepreneur Details";
                grdinterested.DataSource = ds.Tables[0];
                grdinterested.DataBind();               
            }
            else if (type == "JustDialintrsted")
            {
                lblForGrid.Text = "JustDial Platform interested Entrepreneur Details";
                grdinterested.DataSource = ds.Tables[0];
                grdinterested.DataBind();

            }
            else if (type == "TSGlobalintrsted")
            {
                lblForGrid.Text = "TSGlobal-Linker Platform interested Entrepreneur Details";
                grdinterested.DataSource = ds.Tables[0];
                grdinterested.DataBind();

            }
            else if (type == "Wallmartintrsted")
            {
                lblForGrid.Text = "WallmartVriddi Platform interested Entrepreneur Details";
                grdinterested.DataSource = ds.Tables[0];
                grdinterested.DataBind();

            }
            else if (type == "InvoiceMartintrsted")
            {
                lblForGrid.Text = "InvoiceMart Platform interested Entrepreneur Details";
                grdinterested.DataSource = ds.Tables[0];
                grdinterested.DataBind();

            }
            else if (type == "NSEintrsted")
            {
                lblForGrid.Text = "NSE Platform interested Entrepreneur Details";
                grdinterested.DataSource = ds.Tables[0];
                grdinterested.DataBind();

            }
            else if (type == "SIDBIintrsted")
            {
                lblForGrid.Text = "SIDBI Platform interested Entrepreneur Details";
                grdinterested.DataSource = ds.Tables[0];
                grdinterested.DataBind();

            }
        }
        catch (Exception Ex)
        { throw Ex; }
    }
    
    protected void grdMeeshoDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.Header)
        //{
        //    AssignGridRowStyle(e.Row, "GridviewScrollC1Header");
        //}
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    AssignGridRowStyle(e.Row, "GridviewScrollC1Item");
           

           
        //}

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
        lblHeading.Visible = true;
        //  GrdwmenEntpnrdtls.Columns[6].Visible = false;
        using (StringWriter sw = new StringWriter())
        {

            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                grdMeeshoDetails.AllowPaging = false;

                // this.fillgrid();

                grdMeeshoDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                grdMeeshoDetails.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                grdMeeshoDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
                // grdExport.Columns[1].Visible = false;
                grdMeeshoDetails.RenderControl(hw);
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


    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        ExportToExcel();
    }
    protected void ExportToExcel()
    {
        try
        {
            lblHeading.Visible = true;
            //  GrdwmenEntpnrdtls.Columns[6].Visible = false;
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
                grdMeeshoDetails.Style["width"] = "680px";
                Button1.Visible = false;
                Button2.Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                grdMeeshoDetails.RenderControl(hw);
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
        // Handle exceptions appropriately, e.g., log or display an error message
    }


}