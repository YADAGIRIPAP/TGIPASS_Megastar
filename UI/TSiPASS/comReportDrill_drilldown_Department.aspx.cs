using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Data.SqlClient;

public partial class UI_TSiPASS_comReportDrill_drilldown_Department : System.Web.UI.Page
{
    string codes, dists="", DepartmentID="", appltype="";
    string FromdateforDB = "", TodateforDB = "", fromdate = "", todate = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString.Count>=3)
            {
                codes = Request.QueryString["Code"].ToString();
                fromdate = Request.QueryString["fromdate"].ToString().Trim();
                todate = Request.QueryString["todate"].ToString().Trim();

                if (fromdate != "" && todate != "" && codes !="")
                {
                    lblheadingtext.Text = codes;

                    if (Request.QueryString.Count == 3)
                    {
                        getdetails(codes, "", fromdate, todate, "", "");
                    }
                    else
                    {
                        if (Request.QueryString.Count == 6)
                        {
                            DepartmentID = Request.QueryString["DepartmentID"].ToString().Trim();
                            dists = Request.QueryString["Dist"].ToString();
                            lbldists.Text = dists;
                            getdetails(codes, dists, fromdate, todate, DepartmentID, "");
                        }
                        else
                        {
                            if (Request.QueryString.Count == 5)
                            {
                                appltype = Request.QueryString["appltype"].ToString();
                                if (appltype == "District")
                                {
                                    dists = Request.QueryString["Dist"].ToString();
                                    getdetails(codes, dists, fromdate, todate, "", appltype);
                                }
                                else
                                {
                                    if (appltype == "Department")
                                    {
                                        DepartmentID = Request.QueryString["DepartmentID"].ToString().Trim();
                                        getdetails(codes, "", fromdate, todate, DepartmentID, appltype);
                                    }
                                }
                            }
                        }
                    }
                }

            }                
        }

    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }


    private void getdetails(string codes1, string dists1, string FromdateforDB1, string TodateforDB1, string deptid1,string appltype)
    {
        SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
        SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
        DataSet oDataSet = new DataSet();
        osqlConnection.Open();
        oSqlDataAdapter = new SqlDataAdapter("USP_GET_COI_DASHBOARD_ALL_DRILLDOWN_Department", osqlConnection);      
        oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        oSqlDataAdapter.SelectCommand.Parameters.Add("@CODE", SqlDbType.VarChar).Value = codes1.ToString(); 
        oSqlDataAdapter.SelectCommand.Parameters.Add("@FROMDATE", SqlDbType.VarChar).Value = FromdateforDB1.ToString();
        oSqlDataAdapter.SelectCommand.Parameters.Add("@TODATE", SqlDbType.VarChar).Value = TodateforDB1.ToString();
       
        if (string.IsNullOrWhiteSpace(dists1))
        {
            oSqlDataAdapter.SelectCommand.Parameters.Add("@DIST", SqlDbType.VarChar).Value = DBNull.Value;
        }
        else
        {
            oSqlDataAdapter.SelectCommand.Parameters.Add("@DIST", SqlDbType.VarChar).Value = dists1.ToString();
        }
        if (string.IsNullOrWhiteSpace(deptid1))
        {
            oSqlDataAdapter.SelectCommand.Parameters.Add("@DeptID", SqlDbType.VarChar).Value = DBNull.Value;
        }
        else
        {
            oSqlDataAdapter.SelectCommand.Parameters.Add("@DeptID", SqlDbType.VarChar).Value = deptid1.ToString();
        }
        if (string.IsNullOrWhiteSpace(appltype))
        {
            oSqlDataAdapter.SelectCommand.Parameters.Add("@APPLTYPE", SqlDbType.VarChar).Value = DBNull.Value;
        }
        else
        {
            oSqlDataAdapter.SelectCommand.Parameters.Add("@APPLTYPE", SqlDbType.VarChar).Value = appltype.ToString();
        }
        oDataSet = new DataSet();
        oSqlDataAdapter.Fill(oDataSet);
        grdDetails.DataSource = oDataSet.Tables[0];
        grdDetails.DataBind();
    }
    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        PrintPdf();
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
    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
        ExportGridToExcel();
    }
    private void ExportGridToExcel()
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "Vithal" + DateTime.Now + ".xls";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        grdDetails.GridLines = GridLines.Both;
        grdDetails.HeaderStyle.Font.Bold = true;
        grdDetails.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.End();

    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void btnbdf_Click(object sender, EventArgs e)
    {
    }
}