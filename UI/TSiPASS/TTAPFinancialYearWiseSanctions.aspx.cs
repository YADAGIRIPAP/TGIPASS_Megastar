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

public partial class UI_TSiPASS_TTAPFinancialYearWiseSanctions : System.Web.UI.Page
{
    string conString = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
    decimal GENCOUNT, GENAMOUNT, OBCCCOUNT, OBCAMOUNT, SCCOUNT, SCAMOUNT, STCOUNT, STAMOUNT, PHCCOUNT,PHCAMOUNT,MINOCOUNT,MINOAMOUNT;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/tshome.aspx");
        }
        if (!IsPostBack)
        {

            Incentive();
        }

        lbllabel.Text = DateTime.Now.ToString("dd-MM-yyyy");
    }
    public void Incentive()
    {
        try
        {
            SqlDataAdapter da = new SqlDataAdapter("USP_GET_TTAP_FINANCIALYEAR_WISE_SANCTIONED", conString);
            DataSet ds = new DataSet();
            da.Fill(ds);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                row["GENERALSANCTIONED"] = Math.Round(Convert.ToDouble(row["GENERALSANCTIONED"]) / 10000000, 2);
                row["SCAMOUNT"] = Math.Round(Convert.ToDouble(row["SCAMOUNT"]) / 10000000, 2);
                row["STAMOUNT"] = Math.Round(Convert.ToDouble(row["STAMOUNT"]) / 10000000, 2);
                row["PHCAMOUNT"] = Math.Round(Convert.ToDouble(row["PHCAMOUNT"]) / 10000000, 2);
            }
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal GeneralCoun = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "GENERALCOUNT"));
            GENCOUNT = GeneralCoun + GENCOUNT;

            decimal Gensacn = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "GENERALSANCTIONED"));
            GENAMOUNT = Gensacn + GENAMOUNT;

            decimal Sc_Count = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SCCOUNT"));
            SCCOUNT = Sc_Count + SCCOUNT;

            decimal Sc_Amount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SCAMOUNT"));
            SCAMOUNT = Sc_Amount + SCAMOUNT;

            decimal St_Count = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "STCOUNT"));
            STCOUNT = St_Count + STCOUNT;

            decimal St_Amount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "STAMOUNT"));
            STAMOUNT = St_Amount + STAMOUNT;

            decimal Phc_Count = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PHCCOUNT"));
            PHCCOUNT = Phc_Count + PHCCOUNT;

            decimal Phc_Amount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PHCAMOUNT"));
            PHCAMOUNT = Phc_Amount + PHCAMOUNT;

            /*HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
            h1.NavigateUrl = "frmSanctionedReleasedDrilldown.aspx?FinYear=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FinYear")).Trim() + "&CASTE=GENERAL";*/
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
           
            e.Row.Cells[1].Text = "Total";
            /*HyperLink Total = new HyperLink();
              Total.ForeColor = System.Drawing.Color.White;
            Total.NavigateUrl = "frmSanctionedReleasedDrilldown.aspx?FinYear=" + FinYear + "&CASTE=GENERAL";
            Total.Text = COUNT.ToString();*/
            e.Row.Cells[2].Text = GENCOUNT.ToString();
            e.Row.Cells[3].Text = GENAMOUNT.ToString() + "Cr";

            e.Row.Cells[4].Text = SCCOUNT.ToString();
            e.Row.Cells[5].Text = SCAMOUNT.ToString() + "Cr";

            e.Row.Cells[6].Text = STCOUNT.ToString();
            e.Row.Cells[7].Text = STAMOUNT.ToString() + "Cr";

            e.Row.Cells[8].Text = PHCCOUNT.ToString();
            e.Row.Cells[9].Text = PHCAMOUNT.ToString() + "Cr";
        }
    }
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(1, 2, DataControlRowType.Header, DataControlRowState.Insert);
            HeaderGridRow.HorizontalAlign = HorizontalAlign.Center;

            TableCell HeaderCell0 = new TableCell();
            HeaderCell0.Text = "";
            HeaderCell0.ColumnSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell0);

            TableCell HeaderCell1 = new TableCell();
            HeaderCell1.Text = "GENERAL";
            HeaderCell1.ColumnSpan = 2;
            HeaderCell1.HorizontalAlign = HorizontalAlign.Center;
            HeaderGridRow.Cells.Add(HeaderCell1);
            HeaderGridRow.Controls.Add(HeaderCell1);

            TableCell HeaderCell3 = new TableCell();
            HeaderCell3.Text = "SC";
            HeaderCell3.ColumnSpan = 2;
            HeaderCell3.HorizontalAlign = HorizontalAlign.Center;
            HeaderGridRow.Cells.Add(HeaderCell3);
            HeaderGridRow.Controls.Add(HeaderCell3);

            TableCell HeaderCell4 = new TableCell();
            HeaderCell4.Text = "ST";
            HeaderCell4.ColumnSpan = 2;
            HeaderCell4.HorizontalAlign = HorizontalAlign.Center;
            HeaderGridRow.Cells.Add(HeaderCell4);
            HeaderGridRow.Controls.Add(HeaderCell4);

            TableCell HeaderCell6 = new TableCell();
            HeaderCell6.Text = "PHC";
            HeaderCell6.ColumnSpan = 2;
            HeaderCell6.HorizontalAlign = HorizontalAlign.Center;
            HeaderGridRow.Cells.Add(HeaderCell6);
            HeaderGridRow.Controls.Add(HeaderCell6);
            grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);

        }
    }
    protected void Button2_ServerClick(object sender, EventArgs e)
    {
        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                grdDetails.AllowPaging = false;
                grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                grdDetails.HeaderStyle.ForeColor = System.Drawing.Color.Black;
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
                Response.AddHeader("content-disposition", "attachment;filename=TTAP-IncentiveReport" + ".pdf");
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
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='10'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='10'><h4>" + label1text + "</h4></td></td></tr></table>";
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
    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        ExportToExcel();
    }
    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
}