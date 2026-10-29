using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class UI_TSiPASS_frmdaywiserawmaterialdrill : System.Web.UI.Page
{
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

        //lblHeading.Text = "CFE Applications for Dated " + txtFromDate.Text.Trim();
        if (!IsPostBack)
        {
            //Label1.Text = "Report from 1st April to " + System.DateTime.Now.ToString("dd-MMM-yyyy");

            // getdistricts();
            DataSet ds = new DataSet();
            if (Request.QueryString[1].ToString().Trim() != "")
            {
                string[] date = Request.QueryString[1].ToString().Trim().Split(' ');
                //string[] newdate = date[0].ToString().Split('-');

                txtFromDate.Text = date[0].ToString();
                string status = date[1].ToString();
                string FromdateforDB = "", TodateforDB = "";
                //if (txtFromDate.Text != "" && txtFromDate.Text.Contains('/'))
                //{
                lblHeading.Text = "Rawmaterial Applications for Dated " + txtFromDate.Text.Trim();

                FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                if (Session["DistrictID"].ToString().Trim() != "")
                {
                    ds = GetDayWiseStatusDRILL(Session["DistrictID"].ToString().Trim(), txtFromDate.Text, status);
                }
                else
                {
                    ds = GetDayWiseStatusDRILL(Request.QueryString[0].ToString().Trim(), txtFromDate.Text, status);
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //ds.Tables[0].Columns.Remove("DOA");
                    grdDetails.DataSource = ds.Tables[0];
                    grdDetails.DataBind();
                    //string fromdt = Convert.ToDateTime(txtFromDate.Text.Trim()).ToString("dd-MMM-yyyy");
                    //string Todt = Convert.ToDateTime(txtTodate.Text.Trim()).ToString("dd-MMM-yyyy");
                    //Label1.Text = 

                }
                else
                {
                    Label1.Text = "No Records Found ";
                    grdDetails.DataSource = null;
                    grdDetails.DataBind();
                }
                // HyperLink1.NavigateUrl = "DepartmentAbstractLatestNew1.aspx?status=" + status + "&lbl=Total Applications Received&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;

            }
        }

    }




    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {



    }
    void clear()
    {




    }


    protected void BtnClear0_Click(object sender, EventArgs e)
    {


    }
    void FillDetails()
    {


    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {

    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    void getcounties()
    {

    }
    protected void ddlCounties_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    void getPayams()
    {

    }
    protected void ddlState_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void ddlCounties_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void BtnSave2_Click(object sender, EventArgs e)
    {

        try
        {

            fillgrid();

        }
        catch (Exception ex)
        {
            // lblmsg.Text = ex.ToString();
        }
        finally
        {

        }

    }



    protected void ddlProp_intDistrictid_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Header");
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Item");
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Item");
            e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[0].CssClass = "text-center";

            //string intUid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID")).Trim();
            //LinkButton btn = (LinkButton)e.Row.FindControl("LinkButton1");

            //btn.Text = "View";

            //btn.OnClientClick = "javascript:return Popup('" + intUid + "')";
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

    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string status = Request.QueryString[1].ToString().Trim();
        string type = Request.QueryString[4].ToString().Trim();
        string FromdateforDB = "", TodateforDB = "";
        if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
        {
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        }

        if (Session["DistrictID"].ToString().Trim() != "")
        {
            ds = Gen.RetriveStatusByTypeDistrictNew(status, type, "%", Request.QueryString[0].ToString().Trim(), "%", FromdateforDB, TodateforDB);
        }
        else
        {
            ds = Gen.RetriveStatusByTypeDistrictNew(status, type, "%", Request.QueryString[0].ToString().Trim(), Session["DistrictID"].ToString().Trim(), FromdateforDB, TodateforDB);
        }
        //ds = Gen.RetriveStatusByTypeDistrict(status, type, "%", Request.QueryString[0].ToString().Trim());
        if (ds.Tables[0].Rows.Count > 0)
        {
            ds.Tables[0].Columns.Remove("DOA");
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
            //string fromdt = Convert.ToDateTime(txtFromDate.Text.Trim()).ToString("dd-MMM-yyyy");
            //string Todt = Convert.ToDateTime(txtTodate.Text.Trim()).ToString("dd-MMM-yyyy");
            Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();

        }
        else
        {
            Label1.Text = "No Records Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }

    }

    public void fillgrid()
    {
        DataSet ds = new DataSet();
        string status = Request.QueryString[1].ToString().Trim();
        string type = Request.QueryString[4].ToString().Trim();
        //string fromdate = Request.QueryString[2].ToString().Trim();
        //string todate = Request.QueryString[3].ToString().Trim();

        string FromdateforDB = "", TodateforDB = "";
        if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
        {
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        }
        if (Session["DistrictID"].ToString().Trim() != "")
        {
            ds = Gen.RetriveStatusByTypeDistrictNew(status, type, "%", Request.QueryString[0].ToString().Trim(), "%", FromdateforDB, TodateforDB);
        }
        else
        {
            ds = Gen.RetriveStatusByTypeDistrictNew(status, type, "%", Request.QueryString[0].ToString().Trim(), Session["DistrictID"].ToString().Trim(), FromdateforDB, TodateforDB);
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            ds.Tables[0].Columns.Remove("DOA");
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
            //string fromdt = Convert.ToDateTime(txtFromDate.Text.Trim()).ToString("dd-MMM-yyyy");
            //string Todt = Convert.ToDateTime(txtTodate.Text.Trim()).ToString("dd-MMM-yyyy");
            Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();

        }
        else
        {
            Label1.Text = "No Records Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
        HyperLink1.NavigateUrl = "DepartmentAbstractLatestNew.aspx?status=" + status + "&lbl=Total Applications Received&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;
    }

    protected void ExportToExcel()
    {
        try
        {

            string FromdateforDB = "", TodateforDB = "";
            if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
            {
                FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }
            Response.Clear();
            Response.Buffer = true;

            string FileName = lblHeading.Text;
            FileName = FileName.Replace(" ", "");
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName + DateTime.Now.ToString("M/d/yyyy") + ".xls");

            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                DataSet ds = new DataSet();
                string status = Request.QueryString[1].ToString().Trim();
                string type = Request.QueryString[4].ToString().Trim();
                string fromdate = Request.QueryString[2].ToString().Trim();
                string todate = Request.QueryString[3].ToString().Trim();

                if (Session["DistrictID"].ToString().Trim() != "")
                {
                    ds = Gen.RetriveStatusByTypeDistrictNew(status, type, "%", Request.QueryString[0].ToString().Trim(), Session["DistrictID"].ToString().Trim(), FromdateforDB, TodateforDB);
                }
                else
                {
                    ds = Gen.RetriveStatusByTypeDistrictNew(status, type, "%", Request.QueryString[0].ToString().Trim(), "%", FromdateforDB, TodateforDB);
                }

                ds.Tables[0].Columns.Remove("DOA");
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                grdExport.DataSource = ds.Tables[0];
                grdExport.DataBind();
                grdExport.RenderControl(hw);
                string label1text = Label1.Text;
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='10'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='10'><h4>" + label1text + "</h4></td></td></tr></table>";
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
                    grdDetails.AllowPaging = false;
                    this.fillgrid();
                    grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.Columns[1].Visible = false;
                    grdDetails.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename= TotalApplicationsReceived.pdf");
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
        ExportToExcel();
    }

    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        PrintPdf();
    }

    public DataSet GetDayWiseStatusDRILL(string DISTRICTID, string AppnId, string status)
    {
        SqlDataAdapter da;
        osqlConnection.Open();
        DataSet ds = new DataSet();
        string[] date = AppnId.Split('-');
        //string[] newdate = date[0].ToString().Split('-');
        //string staus = date[1].ToString();
        AppnId = date[1].ToString() + "/" + date[0].ToString() + "/" + date[2].ToString();
        try
        {
            da = new SqlDataAdapter("[USP_GET_DAYWISE_RAWMATERIAL_COI]", osqlConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (DISTRICTID.Trim() == "" || DISTRICTID.Trim() == null || DISTRICTID.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@District", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@District", SqlDbType.VarChar).Value = DISTRICTID.ToString();

            if (AppnId.Trim() == "" || AppnId.Trim() == null)
                da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = AppnId.ToString();

            if (status.Trim() == "" || status.Trim() == null)
                da.SelectCommand.Parameters.Add("@status", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@status", SqlDbType.VarChar).Value = status.ToString();

            da.Fill(ds);
            return ds;


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
}