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

public partial class UI_TSiPASS_frmReportPage : System.Web.UI.Page
{
    string conString = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
    decimal COUNT, SANCTIONED, APPLIED, AMOUNT,COUNTS, TAMOUN, CCOUNT, PHCAM;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            incentive();
        }

        lbllabel.Text = DateTime.Now.ToString("dd-MM-yyyy");
    }
    public void incentive()
    {
        try
        {
            SqlDataAdapter da = new SqlDataAdapter("USP_GET_INCENTIVES_RELEASED_YEARWISE", conString);
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
            COUNT = GeneralCoun + COUNT;

            decimal Gensacn = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "GENERALSANCTIONED"));
            SANCTIONED = Gensacn + SANCTIONED;          

            decimal Appli = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SCCOUNT")); 
            APPLIED = Appli + APPLIED;

            decimal Mount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SCAMOUNT"));
            AMOUNT = Mount + AMOUNT;          

            decimal con = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "STCOUNT"));
            COUNTS = con + COUNTS;  

            decimal amount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "STAMOUNT"));
            TAMOUN = amount + TAMOUN;           

            decimal count = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PHCCOUNT"));
            CCOUNT = count + CCOUNT;

            decimal phcam = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PHCAMOUNT"));
            PHCAM = phcam + PHCAM;


            HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
            h1.NavigateUrl = "frmIncentiveYearwiseDrilldown.aspx?FinYear=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FinYear")).Trim() + "&CASTE=GENERAL";

            HyperLink h2 = (HyperLink)e.Row.Cells[4].Controls[0];
            h2.NavigateUrl = "frmIncentiveYearwiseDrilldown.aspx?FinYear=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FinYear")).Trim() + "&CASTE=SC";

            HyperLink h3 = (HyperLink)e.Row.Cells[6].Controls[0];
            h3.NavigateUrl = "frmIncentiveYearwiseDrilldown.aspx?FinYear=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FinYear")).Trim() + "&CASTE=ST";

            HyperLink h4 = (HyperLink)e.Row.Cells[8].Controls[0];
            h4.NavigateUrl = "frmIncentiveYearwiseDrilldown.aspx?FinYear=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FinYear")).Trim() + "&CASTE=PHC";


        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            string FinYear = "%";

            e.Row.Cells[1].Text = "Total";
            HyperLink Total = new HyperLink();
            Total.ForeColor = System.Drawing.Color.White;
            Total.NavigateUrl = "frmIncentiveYearwiseDrilldown.aspx?FinYear=" + FinYear + "&CASTE=GENERAL";
            Total.Text = COUNT.ToString();
            e.Row.Cells[2].Text = COUNT.ToString();
            e.Row.Cells[2].Controls.Add(Total);
          //  e.Row.Cells[2].Text = COUNT.ToString();


            decimal totalamount = SANCTIONED;
            e.Row.Cells[3].Text = totalamount.ToString()+"Cr";
            HyperLink Approvedwithin = new HyperLink();
            Approvedwithin.ForeColor = System.Drawing.Color.White;
            Approvedwithin.NavigateUrl = "frmIncentiveYearwiseDrilldown.aspx?FinYear=" + FinYear + "&CASTE=SC";
            Approvedwithin.Text = APPLIED.ToString();
            e.Row.Cells[4].Text = APPLIED.ToString();
            e.Row.Cells[4].Controls.Add(Approvedwithin);
          
            decimal totalamount2 = AMOUNT;
            e.Row.Cells[5].Text = totalamount2.ToString()+"Cr";

            HyperLink Beyond = new HyperLink();
            Beyond.ForeColor = System.Drawing.Color.White;
            Beyond.NavigateUrl = "frmIncentiveYearwiseDrilldown.aspx?FinYear=" + FinYear + "&CASTE=ST";
            Beyond.Text = COUNTS.ToString();
            e.Row.Cells[6].Text = COUNTS.ToString();
            e.Row.Cells[6].Controls.Add(Beyond);

         
            decimal totalAmount = TAMOUN;
            e.Row.Cells[7].Text = totalAmount.ToString()+"Cr";

            HyperLink Coun = new HyperLink();
            Coun.ForeColor = System.Drawing.Color.White;
            Coun.NavigateUrl = "frmIncentiveYearwiseDrilldown.aspx?FinYear=" + FinYear + "&CASTE=PHC";
            Coun.Text = CCOUNT.ToString();
            e.Row.Cells[8].Text = CCOUNT.ToString();
            e.Row.Cells[8].Controls.Add(Coun);
          
            decimal totalPhca = PHCAM;
            e.Row.Cells[9].Text = totalPhca.ToString()+"Cr";
          
        }
    }

    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

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

            TableCell HeaderCell2 = new TableCell();
            HeaderCell2.Text = "SC";
            HeaderCell2.ColumnSpan = 2;
            HeaderCell2.HorizontalAlign = HorizontalAlign.Center;
            HeaderGridRow.Cells.Add(HeaderCell2);
            HeaderGridRow.Controls.Add(HeaderCell2);

            TableCell HeaderCell3 = new TableCell();
            HeaderCell3.Text = "ST";
            HeaderCell3.ColumnSpan = 2;
            HeaderCell3.HorizontalAlign = HorizontalAlign.Center;
            HeaderGridRow.Cells.Add(HeaderCell3);
            HeaderGridRow.Controls.Add(HeaderCell3);

            TableCell HeaderCell4 = new TableCell();
            HeaderCell4.Text = "PHC";
            HeaderCell4.ColumnSpan = 2;
            HeaderCell4.HorizontalAlign = HorizontalAlign.Center;
            HeaderGridRow.Cells.Add(HeaderCell4);
            HeaderGridRow.Controls.Add(HeaderCell4);
            grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);


        }
    }

    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

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
                Response.AddHeader("content-disposition", "attachment;filename=TSiPASS-ReportPage" + ".pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.Flush();
                Response.End();
            }
        }
    }

    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        ExportToExcel();
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
            throw ex;;
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
}