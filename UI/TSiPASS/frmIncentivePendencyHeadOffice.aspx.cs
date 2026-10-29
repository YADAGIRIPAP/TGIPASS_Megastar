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

public partial class UI_TSiPASS_frmIncentivePendencyHeadOffice : System.Web.UI.Page
{
    string conString = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;

    decimal WITHINCOUNT, BEYONDCOUNT, WITHINCUNTQUERY, BEYONDCOUNTQUERY;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            INCENTIVE();
        }

        lbllabel.Text = DateTime.Now.ToString("dd-MM-yyyy");
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            decimal WITHINCOUNT1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "WITHINCOUNT"));
            WITHINCOUNT = WITHINCOUNT1 + WITHINCOUNT;

            decimal BEYONDCOUNT1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "BEYONDCOUNT"));
            BEYONDCOUNT = BEYONDCOUNT1 + BEYONDCOUNT;

            decimal WITHINCUNTQUERY1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "WITHINCOUNTQUERY"));
            WITHINCUNTQUERY = WITHINCUNTQUERY1 + WITHINCUNTQUERY;

            decimal BEYONDCOUNTQUERY1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "BEYONDCOUNTQUERY"));
            BEYONDCOUNTQUERY = BEYONDCOUNTQUERY1 + BEYONDCOUNTQUERY;

            

            HyperLink h1 = (HyperLink)e.Row.Cells[3].Controls[0];
            if (h1.Text != "0")
            {
                h1.NavigateUrl = "frmIncentivePendencyHeadOfficeDrillDown.aspx?USERID=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "USERID")).Trim() + "&STATUS=A";
            }
            HyperLink h2 = (HyperLink)e.Row.Cells[4].Controls[0];
            if (h2.Text != "0")
            {
                h2.NavigateUrl = "frmIncentivePendencyHeadOfficeDrillDown.aspx?USERID=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "USERID")).Trim() + "&STATUS=B";
            }
            HyperLink h3 = (HyperLink)e.Row.Cells[5].Controls[0];
            if (h3.Text != "0")
            {
                h3.NavigateUrl = "frmIncentivePendencyHeadOfficeDrillDown.aspx?USERID=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "USERID")).Trim() + "&STATUS=C";
            }
            HyperLink h4 = (HyperLink)e.Row.Cells[6].Controls[0];
            if (h4.Text != "0")
            {
                h4.NavigateUrl = "frmIncentivePendencyHeadOfficeDrillDown.aspx?USERID=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "USERID")).Trim() + "&STATUS=D";
            }

        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            string OFFICERID = "%";

            e.Row.Cells[1].Text = "Total";

            HyperLink HYPWTCOUNT = new HyperLink();
            HYPWTCOUNT.ForeColor = System.Drawing.Color.White;
            HYPWTCOUNT.Text = WITHINCOUNT.ToString();
            if(WITHINCOUNT!=0)
            {
                HYPWTCOUNT.NavigateUrl = "frmIncentivePendencyHeadOfficeDrillDown.aspx?USERID=" + OFFICERID + "&STATUS=A";

            }

            e.Row.Cells[3].Text = WITHINCOUNT.ToString();
            e.Row.Cells[3].Controls.Add(HYPWTCOUNT);

            HyperLink HYPBEYONDCOUNT = new HyperLink();
            HYPBEYONDCOUNT.ForeColor = System.Drawing.Color.White;
            HYPBEYONDCOUNT.Text = BEYONDCOUNT.ToString();
            if (BEYONDCOUNT != 0)
            {
                HYPBEYONDCOUNT.NavigateUrl = "frmIncentivePendencyHeadOfficeDrillDown.aspx?USERID=" + OFFICERID + "&STATUS=B";
            }
            e.Row.Cells[4].Text = BEYONDCOUNT.ToString();
            e.Row.Cells[4].Controls.Add(HYPBEYONDCOUNT);

            HyperLink HYPWITHQUERYCOUNT = new HyperLink();
            HYPWITHQUERYCOUNT.ForeColor = System.Drawing.Color.White;
            HYPWITHQUERYCOUNT.Text = WITHINCUNTQUERY.ToString();
            if (WITHINCUNTQUERY != 0)
            {
                HYPWITHQUERYCOUNT.NavigateUrl = "frmIncentivePendencyHeadOfficeDrillDown.aspx?FinYear=" + OFFICERID + "&STATUS=C";
            }
            e.Row.Cells[5].Text = WITHINCUNTQUERY.ToString();
            e.Row.Cells[5].Controls.Add(HYPWITHQUERYCOUNT);

            HyperLink HYPBEYONDQUERYCOUNT = new HyperLink();
            HYPBEYONDQUERYCOUNT.ForeColor = System.Drawing.Color.White;
            HYPBEYONDQUERYCOUNT.Text = BEYONDCOUNTQUERY.ToString();
            if (BEYONDCOUNTQUERY != 0)
            {
                HYPBEYONDQUERYCOUNT.NavigateUrl = "frmIncentivePendencyHeadOfficeDrillDown.aspx?FinYear=" + OFFICERID + "&STATUS=D";
            }
            e.Row.Cells[6].Text = BEYONDCOUNTQUERY.ToString();
            e.Row.Cells[6].Controls.Add(HYPBEYONDQUERYCOUNT);

        }
    }

    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.Header)
        //{
        //    GridView HeaderGrid = (GridView)sender;

        //    GridViewRow HeaderGridRow = new GridViewRow(1, 2, DataControlRowType.Header, DataControlRowState.Insert);
        //    HeaderGridRow.HorizontalAlign = HorizontalAlign.Center;

        //    TableCell HeaderCell0 = new TableCell();
        //    HeaderCell0.Text = "";
        //    HeaderCell0.ColumnSpan = 2;
        //    HeaderGridRow.Cells.Add(HeaderCell0);

        //    TableCell HeaderCell1 = new TableCell();
        //    HeaderCell1.Text = "GENERAL";
        //    HeaderCell1.ColumnSpan = 2;
        //    HeaderCell1.HorizontalAlign = HorizontalAlign.Center;
        //    HeaderGridRow.Cells.Add(HeaderCell1);
        //    HeaderGridRow.Controls.Add(HeaderCell1);

        //    TableCell HeaderCell2 = new TableCell();
        //    HeaderCell2.Text = "SC";
        //    HeaderCell2.ColumnSpan = 2;
        //    HeaderCell2.HorizontalAlign = HorizontalAlign.Center;
        //    HeaderGridRow.Cells.Add(HeaderCell2);
        //    HeaderGridRow.Controls.Add(HeaderCell2);

        //    TableCell HeaderCell3 = new TableCell();
        //    HeaderCell3.Text = "ST";
        //    HeaderCell3.ColumnSpan = 2;
        //    HeaderCell3.HorizontalAlign = HorizontalAlign.Center;
        //    HeaderGridRow.Cells.Add(HeaderCell3);
        //    HeaderGridRow.Controls.Add(HeaderCell3);

        //    TableCell HeaderCell4 = new TableCell();
        //    HeaderCell4.Text = "PHC";
        //    HeaderCell4.ColumnSpan = 2;
        //    HeaderCell4.HorizontalAlign = HorizontalAlign.Center;
        //    HeaderGridRow.Cells.Add(HeaderCell4);
        //    HeaderGridRow.Controls.Add(HeaderCell4);
        //    grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);


        //}
    }

    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public void INCENTIVE()
    {
        try
        {
            SqlDataAdapter da = new SqlDataAdapter("USP_GET_INCENTIVE_PENDENCY_HEADOFFICE_NEW", conString);
            DataSet ds = new DataSet();
            da.Fill(ds);
            //foreach (DataRow row in ds.Tables[0].Rows)
            //{
            //    row["GENERALSANCTIONED"] = Math.Round(Convert.ToDouble(row["GENERALSANCTIONED"]) / 10000000, 2);
            //    row["SCAMOUNT"] = Math.Round(Convert.ToDouble(row["SCAMOUNT"]) / 10000000, 2);
            //    row["STAMOUNT"] = Math.Round(Convert.ToDouble(row["STAMOUNT"]) / 10000000, 2);
            //    row["PHCAMOUNT"] = Math.Round(Convert.ToDouble(row["PHCAMOUNT"]) / 10000000, 2);
            //}
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    protected void Button2_ServerClick(object sender, EventArgs e)
    {
        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                grdDetails.AllowPaging = false;

                // this.fillgrid();

                grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                grdDetails.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                grdDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
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
                Response.AddHeader("content-disposition", "attachment;filename=TSiPASS-DashboardPage" + ".pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.Flush();
                Response.End();
            }
        }
    }
    protected void ExportToExcel()
    {
        try
        {
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
                divPrint1.Style["width"] = "680px";
                Button1.Visible = false;
                Button2.Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                divPrint1.RenderControl(hw);
                string label1text = lbllabel.Text;
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='5'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='5'><h4>" + label1text + "</h4></td></td></tr></table>";
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

    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        ExportToExcel();
    }
}