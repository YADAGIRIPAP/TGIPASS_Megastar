using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Windows.Forms;

public partial class UI_TSiPASS_MajorIndustries_Report : System.Web.UI.Page
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
        Response.Redirect("~/UI/TSIPASS/MajorIndustries_Report.aspx");
    }
    protected void binddata(string fromdate, string todate)
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter("USP_GetSupportForEntrepreneur_New", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.Date).Value = DateTime.ParseExact(fromdate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.Date).Value = DateTime.ParseExact(todate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            da.SelectCommand.Parameters.Add("@SupportType", SqlDbType.VarChar).Value = "Major Industries";

            if (Session["Role_Code"].ToString() == "JD")
            {
                da.SelectCommand.Parameters.Add("@DISTRICTID", SqlDbType.VarChar).Value = "%";
                da.SelectCommand.Parameters.Add("@USERCODE", SqlDbType.VarChar).Value = "%";

            }
            else
            {
                da.SelectCommand.Parameters.Add("@DISTRICTID", SqlDbType.VarChar).Value = Convert.ToString(Session["DistrictID"]);

                da.SelectCommand.Parameters.Add("@USERCODE", SqlDbType.VarChar).Value = Convert.ToString(Session["uid"]);
            }
            da.Fill(ds);
            con.CloseConnection();
            grdsupport.DataSource = ds;
            grdsupport.DataBind();

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
        //    HeaderCell.Text = "District Name";
        //    HeaderCell.ColumnSpan = 2;
        //    HeaderGridRow.Cells.Add(HeaderCell);
        //    HeaderGridRow.BackColor = ColorTranslator.FromHtml("#009688");
        //    HeaderGridRow.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
        //    HeaderGridRow.BorderStyle = BorderStyle.Solid;
        //    HeaderGridRow.BorderColor = ColorTranslator.FromHtml("#FFFFFF");
        //    HeaderGridRow.HorizontalAlign = HorizontalAlign.Center;

        //    HeaderCell = new TableCell();
        //    HeaderCell.Text = "Total No.of Industries";
        //    HeaderCell.ColumnSpan = 3;
        //    HeaderGridRow.Cells.Add(HeaderCell);

        //    HeaderCell = new TableCell();
        //    HeaderCell.Text = "No.of Grievances";
        //    HeaderCell.ColumnSpan = 6;
        //    HeaderGridRow.Cells.Add(HeaderCell);

        //    grdsupport.Controls[0].Controls.AddAt(0, HeaderGridRow);
        //}
    }
    protected void grdsupport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           
            HyperLink TelephonicInteraction = (HyperLink)e.Row.Cells[4].Controls[0];
            if (TelephonicInteraction.Text != "0")
                TelephonicInteraction.NavigateUrl = "MajorIndustries_ReportDrilldown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICT_ID")).Trim() + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text + "& Type=TelephonicInteraction";


            HyperLink PhysicalInteraction = (HyperLink)e.Row.Cells[5].Controls[0];
            if (PhysicalInteraction.Text != "0")
                PhysicalInteraction.NavigateUrl = "MajorIndustries_ReportDrilldown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICT_ID")).Trim() + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text + "& Type=PhysicalInteraction";
            HyperLink grvncIdntfd = (HyperLink)e.Row.Cells[6].Controls[0];
            if (grvncIdntfd.Text != "0")
                grvncIdntfd.NavigateUrl = "MajorIndustries_ReportDrilldown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICT_ID")).Trim() + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text + "& Type=grvncIdntfd";


            HyperLink PndingwithOfcr = (HyperLink)e.Row.Cells[7].Controls[0];
            if (PndingwithOfcr.Text != "0")
                PndingwithOfcr.NavigateUrl = "MajorIndustries_ReportDrilldown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICT_ID")).Trim() + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text + "& Type=PndingwithOfcr";

            HyperLink ResbyOfcr = (HyperLink)e.Row.Cells[8].Controls[0];
            if (ResbyOfcr.Text != "0")
                ResbyOfcr.NavigateUrl = "MajorIndustries_ReportDrilldown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICT_ID")).Trim() + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text + "& Type=ResbyOfcr";

            HyperLink EscaletdtoGM = (HyperLink)e.Row.Cells[9].Controls[0];
            if (EscaletdtoGM.Text != "0")
                EscaletdtoGM.NavigateUrl = "MajorIndustries_ReportDrilldown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICT_ID")).Trim() + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text + "& Type=EscaletdtoGM";

            HyperLink PndingwithGM = (HyperLink)e.Row.Cells[10].Controls[0];
            if (PndingwithGM.Text != "0")
                PndingwithGM.NavigateUrl = "MajorIndustries_ReportDrilldown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICT_ID")).Trim() + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text + "& Type=PndingwithGM";

            HyperLink ResbyGM = (HyperLink)e.Row.Cells[11].Controls[0];
            if (ResbyGM.Text != "0")
                ResbyGM.NavigateUrl = "MajorIndustries_ReportDrilldown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICT_ID")).Trim() + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text + "& Type=ResbyGM";

            HyperLink EscaletdtoDIPC = (HyperLink)e.Row.Cells[12].Controls[0];
            if (EscaletdtoDIPC.Text != "0")
                EscaletdtoDIPC.NavigateUrl = "MajorIndustries_ReportDrilldown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICT_ID")).Trim() + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text + "& Type=EscaletdtoDIPC";

            HyperLink PndingwithDIPC = (HyperLink)e.Row.Cells[13].Controls[0];
            if (PndingwithDIPC.Text != "0")
                PndingwithDIPC.NavigateUrl = "MajorIndustries_ReportDrilldown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICT_ID")).Trim() + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text + "& Type=PndingwithDIPC";

            HyperLink ResbyDIPC = (HyperLink)e.Row.Cells[14].Controls[0];
            if (ResbyDIPC.Text != "0")
                ResbyDIPC.NavigateUrl = "MajorIndustries_ReportDrilldown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICT_ID")).Trim() + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text + "& Type=ResbyDIPC";

            HyperLink EscaletdtoDOI = (HyperLink)e.Row.Cells[15].Controls[0];
            if (EscaletdtoDOI.Text != "0")
                EscaletdtoDOI.NavigateUrl = "MajorIndustries_ReportDrilldown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICT_ID")).Trim() + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text + "& Type=EscaletdtoDOI";

            HyperLink PndingwithDOI = (HyperLink)e.Row.Cells[16].Controls[0];
            if (PndingwithDOI.Text != "0")
                PndingwithDOI.NavigateUrl = "MajorIndustries_ReportDrilldown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICT_ID")).Trim() + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text + "& Type=PndingwithDOI";

            HyperLink ResbyDOI = (HyperLink)e.Row.Cells[17].Controls[0];
            if (ResbyDOI.Text != "0")
                ResbyDOI.NavigateUrl = "MajorIndustries_ReportDrilldown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICT_ID")).Trim() + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text + "& Type=ResbyDOI";

        }
    }
    protected void Button2_ServerClick(object sender, EventArgs e)
    {
        lblHeading.Visible = true;
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
    }

    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        ExportToExcel();
    }
}