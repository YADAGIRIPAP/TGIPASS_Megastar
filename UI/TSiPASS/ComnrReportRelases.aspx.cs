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
using System.Text;

using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Data.SqlClient;
public partial class UI_TSIPASS_ComnrReportRelases : System.Web.UI.Page
{
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    decimal total_releasedCount, total_releasedCountValue, total_uploaded_applicantCount, total_uploaded_applicantValue, total_processed_gmCount, total_processed_gmValue, total_processed_not_gmCount, total_processed_not_gmValue, total_yettoUploadCount, total_yettoUploadValue = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getReleasePRoceedings(ddlCaste.SelectedItem.Text);
            getGridData();
            Label1.Text = "Report as on date " + DateTime.Now;
        }



    }

    protected void BtnSave2_Click(object sender, EventArgs e)
    {
        getGridData_Excel();

    }

    protected void getGridData()
    {
        try
        {
            string FromdateforDB, TodateforDB;
            if (txtFromDate.Text == "")
            {
                txtFromDate.Text = "09-10-2020";
                txtTodate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
            }
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("yyyy-MM-dd"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("yyyy-MM-dd"));

            osqlConnection.Open();
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            da = new SqlDataAdapter("USP_RELEASEPROC_GETDATA", osqlConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@ReleaseProceedingNo", SqlDbType.VarChar).Value = ddlReleaseProceeding.SelectedItem.Text.ToString();
            da.SelectCommand.Parameters.Add("@CASTE", SqlDbType.VarChar).Value = ddlCaste.SelectedItem.Text.ToString();
            da.SelectCommand.Parameters.Add("@INCENTIVEID", SqlDbType.VarChar).Value = "6";
            da.SelectCommand.Parameters.Add("@type", SqlDbType.VarChar).Value = "B";
            da.SelectCommand.Parameters.Add("@SLCDLC", SqlDbType.VarChar).Value = ddlslcDIPC.SelectedItem.Text;
            da.SelectCommand.Parameters.Add("@FROMDATE", SqlDbType.VarChar).Value = FromdateforDB;
            da.SelectCommand.Parameters.Add("@TODATE", SqlDbType.VarChar).Value = TodateforDB;
            da.SelectCommand.CommandTimeout = 3600;

            da.Fill(ds);

            grdDetails.DataSource = ds.Tables[0];

            Session["ExportData_Excel"] = ds.Tables[0];

            grdDetails.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            osqlConnection.Close();
        }
    }

    public DataTable getGridData_Excel()
    {
        try
        {
            string FromdateforDB, TodateforDB;
            if (txtFromDate.Text == "")
            {
                txtFromDate.Text = "09-10-2020";
                txtTodate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
            }
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("yyyy-MM-dd"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("yyyy-MM-dd"));

            osqlConnection.Open();
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            da = new SqlDataAdapter("USP_RELEASEPROC_GETDATA", osqlConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@ReleaseProceedingNo", SqlDbType.VarChar).Value = ddlReleaseProceeding.SelectedItem.Text.ToString();
            da.SelectCommand.Parameters.Add("@CASTE", SqlDbType.VarChar).Value = ddlCaste.SelectedItem.Text.ToString();
            da.SelectCommand.Parameters.Add("@INCENTIVEID", SqlDbType.VarChar).Value = "6";
            da.SelectCommand.Parameters.Add("@type", SqlDbType.VarChar).Value = "B";
            da.SelectCommand.Parameters.Add("@SLCDLC", SqlDbType.VarChar).Value = ddlslcDIPC.SelectedItem.Text;
            da.SelectCommand.Parameters.Add("@FROMDATE", SqlDbType.VarChar).Value = FromdateforDB;
            da.SelectCommand.Parameters.Add("@TODATE", SqlDbType.VarChar).Value = TodateforDB;
            da.SelectCommand.CommandTimeout = 3600;

            da.Fill(ds);

            return ds.Tables[0];


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            osqlConnection.Close();
        }
    }
    protected void getReleasePRoceedings(string caste)
    {
        try
        {
            osqlConnection.Open();
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            da = new SqlDataAdapter("USP_RELEASEPROC_GETDATA", osqlConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@type", SqlDbType.VarChar).Value = "A";
            da.SelectCommand.Parameters.Add("@caste", SqlDbType.VarChar).Value = ddlCaste.SelectedItem.Text.ToString();
            da.SelectCommand.Parameters.Add("@SLCDLC", SqlDbType.VarChar).Value = ddlslcDIPC.SelectedItem.Text.ToString();
            da.SelectCommand.CommandTimeout = 3600;
            da.Fill(ds);
            ddlReleaseProceeding.DataSource = ds.Tables[0];
            ddlReleaseProceeding.DataValueField = "ReleaseProceedingNo";
            ddlReleaseProceeding.DataTextField = "ReleaseProceedingNo";
            ddlReleaseProceeding.DataBind();

            //ddlReleaseProceeding.SelectedIndex = 0;

        }
        catch
        {

        }

        finally
        {
            osqlConnection.Close();
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        getGridData();

    }

    protected void ddlCaste_SelectedIndexChanged(object sender, EventArgs e)
    {
        getReleasePRoceedings(ddlCaste.SelectedItem.Text);
    }

    protected void ddlslcDIPC_SelectedIndexChanged(object sender, EventArgs e)
    {
        getReleasePRoceedings(ddlCaste.SelectedItem.Text);
    }

    //protected void ExportToExcel()
    //{

    //    // Let's bind data to GridView
    //    this.getGridData();

    //    // Let's output HTML of GridView
    //    Response.Clear();
    //    Response.ContentType = "application/vnd.xls";
    //    Response.AddHeader("content-disposition",
    //            "attachment;filename=ReleaseDocUpload.xls");
    //    Response.Charset = "";
    //    StringWriter swriter = new StringWriter();
    //    HtmlTextWriter hwriter = new HtmlTextWriter(swriter);
    //    grdDetails.RenderControl(hwriter);
    //    Response.Write(swriter.ToString());
    //    Response.End();
    //}



    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal total_releasedCount1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "total_releasedCount"));
            total_releasedCount = total_releasedCount1 + total_releasedCount;

            decimal total_releasedCountValue1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "total_releasedCountValue"));
            total_releasedCountValue = total_releasedCountValue1 + total_releasedCountValue;

            decimal total_uploaded_applicantCount1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "total_uploaded_applicantCount"));
            total_uploaded_applicantCount = total_uploaded_applicantCount1 + total_uploaded_applicantCount;

            decimal total_uploaded_applicantValue1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "total_uploaded_applicantValue"));
            total_uploaded_applicantValue = total_uploaded_applicantValue1 + total_uploaded_applicantValue;

            decimal total_processed_gmCount1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "total_processed_gmCount"));
            total_processed_gmCount = total_processed_gmCount1 + total_processed_gmCount;


            decimal total_processed_gmValue1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "total_processed_gmValue"));
            total_processed_gmValue = total_processed_gmValue1 + total_processed_gmValue;

            decimal total_processed_not_gmCount1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "total_processed_not_gmCount"));
            total_processed_not_gmCount = total_processed_not_gmCount1 + total_processed_not_gmCount;

            decimal total_processed_not_gmValue1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "total_processed_not_gmValue"));
            total_processed_not_gmValue = total_processed_not_gmValue1 + total_processed_not_gmValue;

            decimal total_yettoUploadCount1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "total_yettoUploadCount"));
            total_yettoUploadCount = total_yettoUploadCount1 + total_yettoUploadCount;

            decimal total_yettoUploadValue1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "total_yettoUploadValue"));
            total_yettoUploadValue = total_yettoUploadValue1 + total_yettoUploadValue;


        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {

            e.Row.Cells[1].Text = "Total";
            e.Row.Cells[2].Text = total_releasedCount.ToString();
            e.Row.Cells[3].Text = total_releasedCountValue.ToString();

            e.Row.Cells[4].Text = total_uploaded_applicantCount.ToString();
            e.Row.Cells[5].Text = total_uploaded_applicantValue.ToString();
            e.Row.Cells[6].Text = total_processed_gmCount.ToString();
            e.Row.Cells[7].Text = total_processed_gmValue.ToString();
            e.Row.Cells[8].Text = total_processed_not_gmCount.ToString();
            e.Row.Cells[9].Text = total_processed_not_gmValue.ToString();
            e.Row.Cells[10].Text = total_yettoUploadCount.ToString();
            e.Row.Cells[11].Text = total_yettoUploadValue.ToString();

        }

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
                if (i == 2 || i == 3)
                {
                    cellIndex++;
                }
                else if (i == 4 || i == 5)
                {
                    cellIndex++;
                }
                else if (i == 6 || i == 7)
                {
                    cellIndex++;
                }
                else if (i == 8 || i == 9)
                {
                    cellIndex++;
                }
                else if (i == 10 || i == 11)
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
            tcMergePackage.Text = "Total Releases";
            tcMergePackage.CssClass = "GridviewScrollC1Header";
            tcMergePackage.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(2, tcMergePackage);


            TableCell tcMergePackage1 = new TableCell();
            tcMergePackage1.Text = "Documents uploaded by Applicant";
            tcMergePackage1.CssClass = "GridviewScrollC1Header";
            tcMergePackage1.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(3, tcMergePackage1);

            TableCell tcMergePackage2 = new TableCell();
            tcMergePackage2.Text = "Forwarded by GM";
            tcMergePackage2.CssClass = "GridviewScrollC1Header";
            tcMergePackage2.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(4, tcMergePackage2);

            TableCell tcMergePackage3 = new TableCell();
            tcMergePackage3.Text = "Pending with GM";
            tcMergePackage3.CssClass = "GridviewScrollC1Header";
            tcMergePackage3.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(5, tcMergePackage3);

            TableCell tcMergePackage4 = new TableCell();
            tcMergePackage4.Text = "Total Yet to Upload by Applicant";
            tcMergePackage4.CssClass = "GridviewScrollC1Header";
            tcMergePackage4.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(6, tcMergePackage4);

        }

    }
}