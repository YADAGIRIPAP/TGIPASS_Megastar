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

public partial class UI_TSiPASS_ReportOnPlatforms : System.Web.UI.Page
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
            SqlDataAdapter da = new SqlDataAdapter("SP_GetOnboardedPlatformsCount", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.Date).Value = DateTime.ParseExact(fromdate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.Date).Value = DateTime.ParseExact(todate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = Districtid;
            da.SelectCommand.Parameters.Add("@Type", SqlDbType.VarChar).Value = type;
            da.Fill(ds);
            con.CloseConnection();
            lblForGrid.Visible = true;

            grdsupport.DataSource = ds.Tables[0];
            grdsupport.DataBind();

            if (type == "Ecommerce")
            {
                lblHead2.Text = "Marketing Platforms";
                lblForGrid.Text = " No.Of Entrepreneurs OnBoarded onto various Marketing Platforms";
                grdsupport.Columns[7].Visible = false;
                grdsupport.Columns[8].Visible = false;
                grdsupport.Columns[9].Visible = false;
                grdsupport.Columns[10].Visible = false;

                grdsupport.Columns[11].Visible = false;
                grdsupport.Columns[12].Visible = false;
                grdsupport.Columns[13].Visible = false;
                grdsupport.Columns[14].Visible = false;
                grdsupport.Columns[15].Visible = false;
                grdsupport.Columns[16].Visible = false;
                grdsupport.Columns[17].Visible = false;
                grdsupport.Columns[18].Visible = false;
                grdsupport.Columns[19].Visible = false;
            }
            else if (type == "Online")
            {
                lblHead2.Text = "Financial Platforms";
                lblForGrid.Text = " No.Of Entrepreneurs OnBoarded onto Various Financial Platforms";
                grdsupport.Columns[2].Visible = false;
                grdsupport.Columns[3].Visible = false;
                grdsupport.Columns[4].Visible = false;
                grdsupport.Columns[5].Visible = false;
                grdsupport.Columns[6].Visible = false;

                grdsupport.Columns[11].Visible = false;
                grdsupport.Columns[12].Visible = false;
                grdsupport.Columns[13].Visible = false;
                grdsupport.Columns[14].Visible = false;
                grdsupport.Columns[15].Visible = false;
                grdsupport.Columns[16].Visible = false;
                grdsupport.Columns[17].Visible = false;
                grdsupport.Columns[18].Visible = false;
                grdsupport.Columns[19].Visible = false;
            }

            if (type == "EcommerceInterested")
            {
                lblHead2.Text = "Marketing Platforms";
                lblForGrid.Text = " No.of Entrepreneurs Interested to OnBoard onto various Marketing Platforms";

                grdsupport.Columns[2].Visible = false;
                grdsupport.Columns[3].Visible = false;
                grdsupport.Columns[4].Visible = false;
                grdsupport.Columns[5].Visible = false;
                grdsupport.Columns[6].Visible = false;

                grdsupport.Columns[7].Visible = false;
                grdsupport.Columns[8].Visible = false;
                grdsupport.Columns[9].Visible = false;
                grdsupport.Columns[10].Visible = false;
                grdsupport.Columns[11].Visible = false;

                grdsupport.Columns[12].Visible = true;
                grdsupport.Columns[13].Visible = true;
                grdsupport.Columns[14].Visible = true;
                grdsupport.Columns[15].Visible = true;

                grdsupport.Columns[16].Visible = false;
                grdsupport.Columns[17].Visible = false;
                grdsupport.Columns[18].Visible = false;
                grdsupport.Columns[19].Visible = false;


            }
            else if (type == "Onlineinterested")
            {
                lblHead2.Text = "Financial Platforms";
                lblForGrid.Text = " No.Of Entrepreneurs Interested to OnBoard onto Various Financial Platforms";
                grdsupport.Columns[2].Visible = false;
                grdsupport.Columns[3].Visible = false;
                grdsupport.Columns[4].Visible = false;
                grdsupport.Columns[5].Visible = false;
                grdsupport.Columns[6].Visible = false;

                grdsupport.Columns[7].Visible = false;
                grdsupport.Columns[8].Visible = false;
                grdsupport.Columns[9].Visible = false;
                grdsupport.Columns[10].Visible = false;

                grdsupport.Columns[11].Visible = false;
                grdsupport.Columns[12].Visible = false;
                grdsupport.Columns[13].Visible = false;
                grdsupport.Columns[14].Visible = false;
                grdsupport.Columns[15].Visible = false;
            }
        }
        catch (Exception Ex)
        { throw Ex; }
    }
    protected void grdsupport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.Header)
        //{
        //    GridView HeaderGrid = (GridView)sender;
        //    GridViewRow HeaderGridRow = new GridViewRow(2, 2, DataControlRowType.EmptyDataRow, DataControlRowState.Insert);
        //    TableCell HeaderCell = new TableCell();
        //    HeaderCell.Text = "Beneficiary Details";

        //    HeaderCell.ColumnSpan = 8;
        //    HeaderGridRow.Cells.Add(HeaderCell);
        //    HeaderGridRow.BackColor = ColorTranslator.FromHtml("#009688");
        //    HeaderGridRow.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
        //    HeaderGridRow.BorderStyle = BorderStyle.Solid;
        //    HeaderGridRow.BorderColor = ColorTranslator.FromHtml("#FFFFFF");
        //    HeaderGridRow.HorizontalAlign = HorizontalAlign.Center;

        //    HeaderCell = new TableCell();
        //    HeaderCell.Text = "Address";
        //    HeaderCell.ColumnSpan = 4;
        //    HeaderGridRow.Cells.Add(HeaderCell);

        //    HeaderCell = new TableCell();
        //    HeaderCell.Text = "Unique Identifiers";
        //    HeaderCell.ColumnSpan = 6;
        //    HeaderGridRow.Cells.Add(HeaderCell);

        //    HeaderCell = new TableCell();
        //    HeaderCell.Text = "Training";
        //    HeaderCell.ColumnSpan = 2;
        //    HeaderGridRow.Cells.Add(HeaderCell);
        //    HeaderCell = new TableCell();
        //    HeaderCell.Text = "Family";
        //    HeaderCell.ColumnSpan = 1;
        //    HeaderGridRow.Cells.Add(HeaderCell);

        //    HeaderCell = new TableCell();
        //    HeaderCell.Text = "Unit Details";
        //    HeaderCell.ColumnSpan = 4;
        //    HeaderGridRow.Cells.Add(HeaderCell);

        //    HeaderCell = new TableCell();
        //    HeaderCell.Text = "Unit Financial Details";
        //    HeaderCell.ColumnSpan = 11;
        //    HeaderGridRow.Cells.Add(HeaderCell);

        //    HeaderCell = new TableCell();
        //    HeaderCell.Text = "Impact Assessment";
        //    HeaderCell.ColumnSpan = 14;
        //    HeaderGridRow.Cells.Add(HeaderCell);

        //    grdsupport.Controls[0].Controls.AddAt(0, HeaderGridRow);
        //}
    }
    protected void grdsupport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Header");
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Item");


            HyperLink Hmeesho = (HyperLink)e.Row.Cells[3].Controls[0];
            if (Hmeesho.Text != "0")
                Hmeesho.NavigateUrl = "EntrpreneurDetailsOnPlatforms.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim() + "& Type=Meesho" + "& Form=" + Request.QueryString[2] + "& To=" + Request.QueryString[3];

            HyperLink HJustDial = (HyperLink)e.Row.Cells[4].Controls[0];
            if (HJustDial.Text != "0")
                HJustDial.NavigateUrl = "EntrpreneurDetailsOnPlatforms.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim() + "& Type=JustDial" + "& Form=" + Request.QueryString[2] + "& To=" + Request.QueryString[3];

            HyperLink HTSGlobal = (HyperLink)e.Row.Cells[5].Controls[0];
            if (HTSGlobal.Text != "0")
                HTSGlobal.NavigateUrl = "EntrpreneurDetailsOnPlatforms.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim() + "& Type=TSGlobal" + "& Form=" + Request.QueryString[2] + "& To=" + Request.QueryString[3];

            HyperLink HWallmart = (HyperLink)e.Row.Cells[6].Controls[0];
            if (HWallmart.Text != "0")
                HWallmart.NavigateUrl = "EntrpreneurDetailsOnPlatforms.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim() + "& Type=Wallmart" + "& Form=" + Request.QueryString[2] + "& To=" + Request.QueryString[3];

            HyperLink HInvoice = (HyperLink)e.Row.Cells[8].Controls[0];
            if (HInvoice.Text != "0")
                HInvoice.NavigateUrl = "EntrpreneurDetailsOnPlatforms.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim() + "& Type=InvoiceMart" + "& Form=" + Request.QueryString[2] + "& To=" + Request.QueryString[3];

            HyperLink HNSE = (HyperLink)e.Row.Cells[9].Controls[0];
            if (HNSE.Text != "0")
                HNSE.NavigateUrl = "EntrpreneurDetailsOnPlatforms.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim() + "& Type=NSE" + "& Form=" + Request.QueryString[2] + "& To=" + Request.QueryString[3];

            HyperLink HSIDBI = (HyperLink)e.Row.Cells[10].Controls[0];
            if (HSIDBI.Text != "0")
                HSIDBI.NavigateUrl = "EntrpreneurDetailsOnPlatforms.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim() + "& Type=SIDBI" + "& Form=" + Request.QueryString[2] + "& To=" + Request.QueryString[3];

            
            HyperLink Hmeeshointrsted = (HyperLink)e.Row.Cells[12].Controls[0];
            if (Hmeeshointrsted.Text != "0")
                Hmeeshointrsted.NavigateUrl = "EntrpreneurDetailsOnPlatforms.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim() + "& Type=Meeshointrsted" + "& Form=" + Request.QueryString[2] + "& To=" + Request.QueryString[3];

            HyperLink HJustDialintrsted = (HyperLink)e.Row.Cells[13].Controls[0];
            if (HJustDialintrsted.Text != "0")
                HJustDialintrsted.NavigateUrl = "EntrpreneurDetailsOnPlatforms.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim() + "& Type=JustDialintrsted" + "& Form=" + Request.QueryString[2] + "& To=" + Request.QueryString[3];

            HyperLink HTSGlobalintrsted = (HyperLink)e.Row.Cells[14].Controls[0];
            if (HTSGlobalintrsted.Text != "0")
                HTSGlobalintrsted.NavigateUrl = "EntrpreneurDetailsOnPlatforms.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim() + "& Type=TSGlobalintrsted" + "& Form=" + Request.QueryString[2] + "& To=" + Request.QueryString[3];

            HyperLink HWallmartintrsted = (HyperLink)e.Row.Cells[15].Controls[0];
            if (HWallmartintrsted.Text != "0")
                HWallmartintrsted.NavigateUrl = "EntrpreneurDetailsOnPlatforms.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim() + "& Type=Wallmartintrsted" + "& Form=" + Request.QueryString[2] + "& To=" + Request.QueryString[3];

            HyperLink HInvoiceintrsted = (HyperLink)e.Row.Cells[17].Controls[0];
            if (HInvoiceintrsted.Text != "0")
                HInvoiceintrsted.NavigateUrl = "EntrpreneurDetailsOnPlatforms.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim() + "& Type=InvoiceMartintrsted" + "& Form=" + Request.QueryString[2] + "& To=" + Request.QueryString[3];

            HyperLink HNSEintrsted = (HyperLink)e.Row.Cells[18].Controls[0];
            if (HNSEintrsted.Text != "0")
                HNSEintrsted.NavigateUrl = "EntrpreneurDetailsOnPlatforms.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim() + "& Type=NSEintrsted" + "& Form=" + Request.QueryString[2] + "& To=" + Request.QueryString[3];

            HyperLink HSIDBIintrsted = (HyperLink)e.Row.Cells[19].Controls[0];
            if (HSIDBIintrsted.Text != "0")
                HSIDBIintrsted.NavigateUrl = "EntrpreneurDetailsOnPlatforms.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim() + "& Type=SIDBIintrsted" + "& Form=" + Request.QueryString[2] + "& To=" + Request.QueryString[3];


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
                grdsupport.AllowPaging = false;

                // this.fillgrid();

                grdsupport.HeaderRow.ForeColor = System.Drawing.Color.Black;
                grdsupport.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                grdsupport.FooterRow.ForeColor = System.Drawing.Color.Black;
                // grdExport.Columns[1].Visible = false;
                grdsupport.RenderControl(hw);
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
                grdsupport.Style["width"] = "680px";
                Button1.Visible = false;
                Button2.Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                grdsupport.RenderControl(hw);
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