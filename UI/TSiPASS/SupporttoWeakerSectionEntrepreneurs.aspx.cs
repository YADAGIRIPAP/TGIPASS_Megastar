using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class UI_TSiPASS_SupporttoWeakerSectionEntrepreneurs : System.Web.UI.Page
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
                    txtfrmdate.Text = "01-10-2023";
                    txttodate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                    binddata(txtfrmdate.Text, txttodate.Text);

                }
            }
            else { Response.Redirect("~/TSHome.aspx"); }
        }

    }

    protected void BtnGetData_Click(object sender, EventArgs e)
    {
        if (txttodate.Text != "" && txtfrmdate.Text != "")
        { binddata(txtfrmdate.Text, txttodate.Text); }

    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UI/TSIPASS/SupporttoWeakerSectionEntrepreneurs.aspx");
    }
    protected void binddata(string fromdate, string todate)
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter("USP_GetSupportForWSEntrepreneur", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.Date).Value = DateTime.ParseExact(fromdate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.Date).Value = DateTime.ParseExact(todate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            if (Session["Role_Code"].ToString() == "JD")
            {
                da.SelectCommand.Parameters.Add("@DISTRICTID", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                da.SelectCommand.Parameters.Add("@DISTRICTID", SqlDbType.VarChar).Value = Convert.ToString(Session["DistrictID"]);
            }
            da.Fill(ds);
            con.CloseConnection();
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdsupport.DataSource = ds.Tables[0].DefaultView;
                grdsupport.DataBind();
            }

        }
        catch (Exception Ex)
        { throw Ex; }

    }

    protected void grdsupport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(2, 2, DataControlRowType.EmptyDataRow, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            HeaderCell.Text = "District Name";
            HeaderCell.ColumnSpan = 5;
            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderGridRow.BackColor = ColorTranslator.FromHtml("#009688");
            HeaderGridRow.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
            HeaderGridRow.BorderStyle = BorderStyle.Solid;
            HeaderGridRow.BorderColor = ColorTranslator.FromHtml("#FFFFFF");
            HeaderGridRow.HorizontalAlign = HorizontalAlign.Center;

            HeaderCell = new TableCell();
            HeaderCell.Text = "Total No.of Plots";
            HeaderCell.ColumnSpan = 5;
            HeaderGridRow.Cells.Add(HeaderCell);

            ////HeaderCell = new TableCell();
            ////HeaderCell.Text = "No.of Plots";
            ////HeaderCell.ColumnSpan = 2;
            ////HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Total No.of Plots Mandated";
            HeaderCell.ColumnSpan = 6;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Total No.of Plots Actually alloted";
            HeaderCell.ColumnSpan = 6;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Total No.of Plots Vacant";
            HeaderCell.ColumnSpan = 6;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Total No.of Plots Allotable";
            HeaderCell.ColumnSpan = 6;
            HeaderGridRow.Cells.Add(HeaderCell);

            grdsupport.Controls[0].Controls.AddAt(0, HeaderGridRow);

        }
    }

    protected void grdsupport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink HIEcount = (HyperLink)e.Row.Cells[2].Controls[0];
            if (HIEcount.Text != "0")
                HIEcount.NavigateUrl = "WeakerSectionPlotDetails.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Id")).Trim() + "& Type=IE" + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text;

            HyperLink HSCAllotable = (HyperLink)e.Row.Cells[28].Controls[0];
            if (HSCAllotable.Text != "0")
                HSCAllotable.NavigateUrl = "WeakerSectionPlotDetails.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Id")).Trim() + "& Type=AllotableSC" + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text;

            HyperLink HSTAllotable = (HyperLink)e.Row.Cells[29].Controls[0];
            if (HSTAllotable.Text != "0")
                HSTAllotable.NavigateUrl = "WeakerSectionPlotDetails.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Id")).Trim() + "& Type=AllotableST" + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text;

            HyperLink HBCAllotable = (HyperLink)e.Row.Cells[30].Controls[0];
            if (HBCAllotable.Text != "0") 
                HBCAllotable.NavigateUrl = "WeakerSectionPlotDetails.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Id")).Trim() + "& Type=AllotableBC" + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text;

            HyperLink HMinAllotable = (HyperLink)e.Row.Cells[31].Controls[0];
            if (HMinAllotable.Text != "0")
                HMinAllotable.NavigateUrl = "WeakerSectionPlotDetails.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Id")).Trim() + "& Type=AllotableMinority" + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text;

            HyperLink HWomenAllotable = (HyperLink)e.Row.Cells[32].Controls[0];
            if (HWomenAllotable.Text != "0")
                HWomenAllotable.NavigateUrl = "WeakerSectionPlotDetails.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Id")).Trim() + "& Type=AllotableWomen" + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text;

            HyperLink HGeneralAllotable = (HyperLink)e.Row.Cells[33].Controls[0];
            if (HGeneralAllotable.Text != "0")
                HGeneralAllotable.NavigateUrl = "WeakerSectionPlotDetails.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Id")).Trim() + "& Type=AllotableGeneral" + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text;

        }
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