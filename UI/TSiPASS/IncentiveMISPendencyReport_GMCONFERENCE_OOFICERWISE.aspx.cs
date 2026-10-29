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
using System.Globalization;
using System.Data.SqlClient;
using System.Drawing;

public partial class UI_TSiPASS_IncentiveMISPendencyReport_GMCONFERENCE_OOFICERWISE : System.Web.UI.Page
{
    General Gen = new General();
    DB.DB con = new DB.DB();

    decimal IPO1COUNT, IPO2COUNT, IPO3COUNT, IPO4COUNT,GMINSPECTIONCOUNT, AD1COUNT, AD2COUNT, DD1COUNT, GMCOUNT, TOTAL;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {
            
            FillGridDetails();
        }
    }

    public void FillGridDetails()
    {
        DataSet ds = new DataSet();

        ds = GetIncentivesMISPendingReport_OFFICERWISE();

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
    }
    public DataSet GetIncentivesMISPendingReport_OFFICERWISE()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            //da = new SqlDataAdapter("sp_GetDistriciWiseReport", con.GetConnection);
            //da = new SqlDataAdapter("USP_GET_INCENTIVEOFFICERWISE_PENDENCY", con.GetConnection);
            da = new SqlDataAdapter("USP_GET_INCENTIVEOFFICERWISE_PENDENCY_WITHINANDBEYOND", con.GetConnection);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.CommandTimeout = 3600;
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

    protected void BtnClear_Click(object sender, EventArgs e)
    {


    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal IPO1COUNT1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "IPO1COUNT"));
            IPO1COUNT = IPO1COUNT1 + IPO1COUNT;

            decimal IPO2COUNT1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "IPO2COUNT"));
            IPO2COUNT = IPO2COUNT1 + IPO2COUNT;

            decimal IPO3COUNT1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "IPO3COUNT"));
            IPO3COUNT = IPO3COUNT1 + IPO3COUNT;

            decimal IPO4COUNT1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "IPO4COUNT"));
            IPO4COUNT = IPO4COUNT1 + IPO4COUNT;

            decimal GMINSPECTIONCOUNT1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "GM-INSPECTION-COUNT"));
            GMINSPECTIONCOUNT = GMINSPECTIONCOUNT1 + GMINSPECTIONCOUNT;


            decimal AD1COUNT1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "AD1COUNT"));
            AD1COUNT = AD1COUNT1 + AD1COUNT;

            decimal AD2COUNT1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "AD2COUNT"));
            AD2COUNT = AD2COUNT1 + AD2COUNT;

            decimal DD1COUNT1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "DD1COUNT"));
            DD1COUNT = DD1COUNT1 + DD1COUNT;

            decimal GMCOUNT1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "GMCOUNT"));
            GMCOUNT = GMCOUNT1 + GMCOUNT;

            decimal TOTAL1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TOTAL"));
            TOTAL = TOTAL1 + TOTAL;



            
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total";



            e.Row.Cells[3].Text = IPO1COUNT.ToString();
            e.Row.Cells[5].Text = IPO2COUNT.ToString();

            e.Row.Cells[7].Text = IPO3COUNT.ToString();

            e.Row.Cells[9].Text = IPO4COUNT.ToString();

            e.Row.Cells[11].Text = GMINSPECTIONCOUNT.ToString();


            e.Row.Cells[13].Text = AD1COUNT.ToString();

            e.Row.Cells[15].Text = AD2COUNT.ToString();

            e.Row.Cells[17].Text = DD1COUNT.ToString();

            e.Row.Cells[19].Text = GMCOUNT.ToString();
            e.Row.Cells[20].Text = TOTAL.ToString();

        }
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow gvHeaderRow = e.Row;
            GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            this.grdDetails.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

            int headerCellCount = gvHeaderRow.Cells.Count;
            int cellIndex = 0;

            for (int i = 0; i < headerCellCount; i++)
            {
                if (i == 4 || i == 5)
                {
                    cellIndex++;
                }
                else if (i == 6 || i == 7 || i == 8)
                {
                    cellIndex++;
                }
                else if (i == 9 || i == 10 || i == 11)
                {
                    cellIndex++;
                }
                else if (i == 12 || i == 13 || i == 14 || i == 15)
                {
                    cellIndex++;
                }
                else
                {
                    TableCell tcHeader = gvHeaderRow.Cells[cellIndex];
                    tcHeader.RowSpan = 2;
                    gvHeaderRowCopy.Cells.Add(tcHeader);
                }
            }


            TableCell tcMergePackage = new TableCell();
            tcMergePackage.Text = "Pending to Assign Inspection at GM";
            tcMergePackage.CssClass = "GridviewScrollC1Header";
            tcMergePackage.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(4, tcMergePackage);


            TableCell tcMergePackage1 = new TableCell();
            tcMergePackage1.Text = "Pending to Assign Inspection Date";
            tcMergePackage1.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage1.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(5, tcMergePackage1);

            TableCell tcMergePackage2 = new TableCell();
            tcMergePackage2.Text = "Pending to Upload Inspection Report";
            tcMergePackage2.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage2.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(6, tcMergePackage2);

            TableCell tcMergePackage20 = new TableCell();
            tcMergePackage20.Text = "Pending to Forward to COI/DIPC";
            tcMergePackage20.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage20.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(7, tcMergePackage20);
        }


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
    public override void VerifyRenderingInServerForm(Control control)
    {
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
                    Response.AddHeader("content-disposition", "attachment;filename= R2-1-STATUS-OF-PRESCRUTINY-DEPARTMENT-WISE.pdf");
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

    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        PrintPdf();
    }

    public void BindDistricts()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlProp_intDistrictid.Items.Clear();
            dsd = Gen.GetDistrictsWithoutHYD();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlProp_intDistrictid.DataSource = dsd.Tables[0];
                ddlProp_intDistrictid.DataValueField = "District_Id";
                ddlProp_intDistrictid.DataTextField = "District_Name";
                ddlProp_intDistrictid.DataBind();
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("--All--", "%");
                ddlProp_intDistrictid.Items.Insert(0, li);
            }
            else
            {
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("--All--", "%");
                ddlProp_intDistrictid.Items.Insert(0, li);
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }
}