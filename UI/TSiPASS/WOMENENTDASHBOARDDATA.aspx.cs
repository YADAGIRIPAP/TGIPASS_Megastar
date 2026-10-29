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
using System.Text;


public partial class UI_TSiPASS_WOMENENTDASHBOARDDATA : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    comFunctions cmf = new comFunctions();
    CommonBL objcommon = new CommonBL();
    DataSet ds = new DataSet();
    decimal NumberTotal, manufacturingtotal, servicetotal, InvestmnetTotal, EmploymentTotal, micro, small, medium, large, mega;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            


            FillGridDetails();
        }
    }

    public void FillGridDetails()
    {

        ds = GetPublicViewReport();
        if (ds.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            //Label1.Text = "No Records Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
    }


    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string FINANCIALYEAR = "";
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal NumberTotal1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total Application received"));
            NumberTotal = NumberTotal1 + NumberTotal;

            decimal InvestmnetTotal1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total Investments"));
            InvestmnetTotal = InvestmnetTotal1 + InvestmnetTotal;


            decimal EmploymentTotal1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total Empolyment"));
            EmploymentTotal = EmploymentTotal1 + EmploymentTotal;

            decimal micro1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Micro"));
            micro = micro1 + micro;

            decimal small1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Small"));
            small = small1 + small;

            decimal medium1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Medium"));
            medium = medium1 + medium;

            decimal large1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Large"));
            large = large1 + large;

            decimal mega1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Mega"));
            mega = mega1 + mega;



            //decimal manufacturingtotal1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ManufacturingTotal"));
            //manufacturingtotal = manufacturingtotal1 + manufacturingtotal;

            //decimal servicetotal1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ServiceTotal"));
            //servicetotal = servicetotal1 + servicetotal;

            FINANCIALYEAR = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FinYear"));
            HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
            if (h1.Text != "0")
            {
                h1.NavigateUrl = "WOMENDATADRILLDOWN.aspx?STATUS=A&FINANCIALYEAR=" + FINANCIALYEAR;
            }
            //HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
            //if (h2.Text != "0")
            //{
            //    h2.NavigateUrl = "WOMENDATADRILLDOWN.aspx?STATUS=B&FINANCIALYEAR=" + FINANCIALYEAR;
            //}
            //HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
            //if (h3.Text != "0")
            //{
            //    h3.NavigateUrl = "WOMENDATADRILLDOWN.aspx?STATUS=C&FINANCIALYEAR=" + FINANCIALYEAR;
            //}
            HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
            if (h2.Text != "0")
            {
                h2.NavigateUrl = "WOMENDATADRILLDOWN.aspx?STATUS=D&FINANCIALYEAR=" + FINANCIALYEAR;
            }
            HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
            if (h3.Text != "0")
            {
                h3.NavigateUrl = "WOMENDATADRILLDOWN.aspx?STATUS=E&FINANCIALYEAR=" + FINANCIALYEAR;
            }
            HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
            if (h4.Text != "0")
            {
                h4.NavigateUrl = "WOMENDATADRILLDOWN.aspx?STATUS=F&FINANCIALYEAR=" + FINANCIALYEAR;
            }
            HyperLink h5 = (HyperLink)e.Row.Cells[6].Controls[0];
            if (h5.Text != "0")
            {
                h5.NavigateUrl = "WOMENDATADRILLDOWN.aspx?STATUS=G&FINANCIALYEAR=" + FINANCIALYEAR;
            }
            HyperLink h6 = (HyperLink)e.Row.Cells[7].Controls[0];
            if (h6.Text != "0")
            {
                h6.NavigateUrl = "WOMENDATADRILLDOWN.aspx?STATUS=H&FINANCIALYEAR=" + FINANCIALYEAR;
            }
            HyperLink h7 = (HyperLink)e.Row.Cells[8].Controls[0];
            if (h7.Text != "0")
            {
                h7.NavigateUrl = "WOMENDATADRILLDOWN.aspx?STATUS=I&FINANCIALYEAR=" + FINANCIALYEAR;
            }
            HyperLink h8 = (HyperLink)e.Row.Cells[9].Controls[0];
            if (h8.Text != "0")
            {
                h8.NavigateUrl = "WOMENDATADRILLDOWN.aspx?STATUS=J&FINANCIALYEAR=" + FINANCIALYEAR;
            }



        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total";
            e.Row.Cells[2].Text = NumberTotal.ToString();

            e.Row.Cells[3].Text = InvestmnetTotal.ToString();
            e.Row.Cells[4].Text = EmploymentTotal.ToString();

            e.Row.Cells[5].Text = micro.ToString();
            e.Row.Cells[6].Text = small.ToString();
            e.Row.Cells[7].Text = medium.ToString();
            e.Row.Cells[8].Text = large.ToString();
            e.Row.Cells[9].Text = mega.ToString();

            FINANCIALYEAR = "%";
            HyperLink h1 = new HyperLink();
            h1.Text = NumberTotal.ToString();
            if (h1.Text != "0")
            {
                h1.NavigateUrl = "WOMENDATADRILLDOWN.aspx?STATUS=A&FINANCIALYEAR=" + FINANCIALYEAR;
                e.Row.Cells[2].Controls.Add(h1);
            }
            //HyperLink h2 = new HyperLink();
            //h2.Text = manufacturingtotal.ToString();
            //if (h2.Text != "0")
            //{
            //    h2.NavigateUrl = "WOMENDATADRILLDOWN.aspx?STATUS=B&FINANCIALYEAR=" + FINANCIALYEAR;
            //    e.Row.Cells[3].Controls.Add(h2);
            //}
            //HyperLink h3 = new HyperLink();
            //h3.Text = servicetotal.ToString();
            //if (h3.Text != "0")
            //{
            //    h3.NavigateUrl = "WOMENDATADRILLDOWN.aspx?STATUS=C&FINANCIALYEAR=" + FINANCIALYEAR;
            //    e.Row.Cells[4].Controls.Add(h3);
            //}
            HyperLink h2 = new HyperLink();
            h2.Text = InvestmnetTotal.ToString();
            if (h2.Text != "0")
            {
                h2.NavigateUrl = "WOMENDATADRILLDOWN.aspx?STATUS=D&FINANCIALYEAR=" + FINANCIALYEAR;
                e.Row.Cells[3].Controls.Add(h2);
            }
            HyperLink h3 = new HyperLink();
            h3.Text = EmploymentTotal.ToString();
            if (h3.Text != "0")
            {
                h3.NavigateUrl = "WOMENDATADRILLDOWN.aspx?STATUS=E&FINANCIALYEAR=" + FINANCIALYEAR;
                e.Row.Cells[4].Controls.Add(h3);
            }
            HyperLink h4 = new HyperLink();
            h4.Text = micro.ToString();
            if (h4.Text != "0")
            {
                h4.NavigateUrl = "WOMENDATADRILLDOWN.aspx?STATUS=F&FINANCIALYEAR=" + FINANCIALYEAR;
                e.Row.Cells[5].Controls.Add(h4);
            }
            HyperLink h5 = new HyperLink();
            h5.Text = small.ToString();
            if (h5.Text != "0")
            {
                h5.NavigateUrl = "WOMENDATADRILLDOWN.aspx?STATUS=G&FINANCIALYEAR=" + FINANCIALYEAR;
                e.Row.Cells[6].Controls.Add(h5);
            }
            HyperLink h6 = new HyperLink();
            h6.Text = medium.ToString();
            if (h6.Text != "0")
            {
                h6.NavigateUrl = "WOMENDATADRILLDOWN.aspx?STATUS=H&FINANCIALYEAR=" + FINANCIALYEAR;
                e.Row.Cells[7].Controls.Add(h6);
            }
            HyperLink h7 = new HyperLink();
            h7.Text = large.ToString();
            if (h7.Text != "0")
            {
                h7.NavigateUrl = "WOMENDATADRILLDOWN.aspx?STATUS=I&FINANCIALYEAR=" + FINANCIALYEAR;
                e.Row.Cells[8].Controls.Add(h7);
            }
            HyperLink h8 = new HyperLink();
            h8.Text = mega.ToString();
            if (h8.Text != "0")
            {
                h8.NavigateUrl = "WOMENDATADRILLDOWN.aspx?STATUS=J&FINANCIALYEAR=" + FINANCIALYEAR;
                e.Row.Cells[9].Controls.Add(h8);
            }

        }
    }
    

    public DataSet GetPublicViewReport()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_WOMANENTDATA", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
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

                    //this.FillGridDetails();

                    //grdDetails.RenderControl(hw);
                    //StringReader sr = new StringReader(sw.ToString());
                    //Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    //pdfDoc.Open();
                    //htmlparser.Parse(sr);
                    //pdfDoc.Close();
                    grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                    grdDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.FooterStyle.ForeColor = System.Drawing.Color.Black;

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
                    Response.AddHeader("content-disposition", "attachment;filename= women entrepreneurs data.pdf");
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
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        PrintPdf();
    }
    protected void BtnSave2_Click(object sender, EventArgs e)
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
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                grdDetails.RenderControl(hw);

                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='6'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='6'></td></td></tr></table>";
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
}