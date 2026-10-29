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

public partial class TSHOMEDRILLDOWN : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        //lblHeading.Text = "View Applications";
        if (!IsPostBack)
        {
            //Label1.Text = "Report from 1st April to " + System.DateTime.Now.ToString("dd-MMM-yyyy");

            BindDistricts();
            //getdistricts();
            DataSet ds = new DataSet();
            string status = Request.QueryString["STATUS"].ToString().Trim();
            string financialyear = Request.QueryString["FINANCIALYEAR"].ToString().Trim();
            
            if(status=="A")
            {
                lblHeading.Text = "Total no of Industries for the Financial Year "+ financialyear;
            }
            if (status == "B")
            {
                lblHeading.Text = "Total no of Manufacturing Sector Units for the Financial Year " + financialyear;
            }
            if (status == "C")
            {
                lblHeading.Text = "Total no of Service Sector Units for the Financial Year " + financialyear;
            }
            if (status == "D")
            {
                lblHeading.Text = "Total Investment(In Crores) for the Financial Year " + financialyear;
            }
            if (status == "E")
            {
                lblHeading.Text = "Total Employment for the Financial Year " + financialyear;
            }
            if (status == "F")
            {
                lblHeading.Text = "Total no of Manufacturing Sector Micro Units for the Financial Year " + financialyear;
            }
            if (status == "G")
            {
                lblHeading.Text = "Total no of Manufacturing Sector Small Units for the Financial Year " + financialyear;
            }
            if (status == "H")
            {
                lblHeading.Text = "Total no of Manufacturing Sector Medium Units for the Financial Year " + financialyear;
            }
            if (status == "I")
            {
                lblHeading.Text = "Total no of Manufacturing Sector Large Units for the Financial Year " + financialyear;
            }
            if (status == "J")
            {
                lblHeading.Text = "Total no of Manufacturing Sector Mega Units for the Financial Year " + financialyear;
            }
            if (status == "K")
            {
                lblHeading.Text = "Total no of Service Sector Micro Units for the Financial Year " + financialyear;
            }
            if (status == "L")
            {
                lblHeading.Text = "Total no of Service Sector Small Units for the Financial Year " + financialyear;
            }
            if (status == "M")
            {
                lblHeading.Text = "Total no of Service Sector Medium Units for the Financial Year " + financialyear;
            }
            if (status == "N")
            {
                lblHeading.Text = "Total no of Service Sector Large Units for the Financial Year " + financialyear;
            }
            if (status == "O")
            {
                lblHeading.Text = "Total no of Service Sector Mega Units for the Financial Year " + financialyear;
            }
            if (ddldistrict.SelectedItem.Text != "" || ddldistrict.SelectedItem.Text != null)
            {
                ds = homepagedatadrilldown(status, financialyear, ddldistrict.SelectedItem.Text.Trim().ToString(),"%");
            }
            else
            {
                ds = homepagedatadrilldown(status, financialyear, "%", "%");
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
                //string fromdt = Convert.ToDateTime(txtFromDate.Text.Trim()).ToString("dd-MMM-yyyy");
                //string Todt = Convert.ToDateTime(txtTodate.Text.Trim()).ToString("dd-MMM-yyyy"); Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();

            }
            else
            {
                //Label1.Text = "No Records Found ";
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }
            HyperLink1.NavigateUrl = "tshome.aspx";

        }
    }
    public DataSet GetDistricts()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[GETDISTRICTSFORHOMEPAGEDRILLDOWN]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            
            da.SelectCommand.CommandTimeout = 3600;
            da.Fill(ds);
            return ds;


        }
        catch (Exception ex)
        {
            //throw ex;
            return null;
        }
        finally
        {
            con.CloseConnection();
        }
    }
    public void BindDistricts()
    {
        try
        {
            //DataSet dsd = new DataSet();
            //ddlProp_intDistrictid.Items.Clear();
            //dsd = Gen.GetDistrictsWithoutHYD();
            Cls_MasterofTsipass obj_newdistrictwargnal = new Cls_MasterofTsipass();

            DataSet dsd = new DataSet();
            ddldistrict.Items.Clear();
            // dsd = Gen.GetDistrictsWithoutHYD();
            dsd = GetDistricts();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddldistrict.DataSource = dsd.Tables[0];
                ddldistrict.DataValueField = "District_Id";
                ddldistrict.DataTextField = "District_Name";
                ddldistrict.DataBind();
                ddldistrict.Items.Insert(0, "--District--");
            }
            else
            {
                ddldistrict.Items.Insert(0, "--District--");
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
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
    public DataSet homepagedatadrilldown(string status, string financialyaer, string District, string lineofactivity)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[USP_GET_PUBLICVIEWDASHBOARD_DRILLDOWN]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (status.Trim() == "" || status.Trim() == null)
                da.SelectCommand.Parameters.Add("@status", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@status", SqlDbType.VarChar).Value = status.ToString();
            if (financialyaer.Trim() == "" || financialyaer.Trim() == null)
                da.SelectCommand.Parameters.Add("@FINACIALYEAR", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@FINACIALYEAR", SqlDbType.VarChar).Value = financialyaer.ToString();
            if (lineofactivity.Trim() == "" || lineofactivity.Trim() == null || lineofactivity.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@lineofactivity", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@lineofactivity", SqlDbType.VarChar).Value = lineofactivity.ToString();

            if (District.Trim() == "" || District.Trim() == null || District.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@District", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@District", SqlDbType.VarChar).Value = District.ToString();

            da.SelectCommand.CommandTimeout = 3600;
            da.Fill(ds);
            return ds;


        }
        catch (Exception ex)
        {
            //throw ex;
            return null;
        }
        finally
        {
            con.CloseConnection();
        }
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
    //protected void BtnSave1_Click(object sender, EventArgs e)
    //{
    //    DataSet ds = new DataSet();
    //    string status = Request.QueryString["STATUS"].ToString().Trim();
    //    string financialyear = Request.QueryString["FINANCIALYEAR"].ToString().Trim();
    //    string FromdateforDB = "", TodateforDB = "";
    //    if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
    //    {
    //        FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
    //        TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
    //    }

    //    if (Session["DistrictID"].ToString().Trim() != "")
    //    {
    //        ds = Gen.RetriveStatusByTypeDistrictNew(status, type, "%", Request.QueryString[0].ToString().Trim(), "%", FromdateforDB, TodateforDB);
    //    }
    //    else
    //    {
    //        ds = Gen.RetriveStatusByTypeDistrictNew(status, type, "%", Request.QueryString[0].ToString().Trim(), Session["DistrictID"].ToString().Trim(), FromdateforDB, TodateforDB);
    //    }
    //    //ds = Gen.RetriveStatusByTypeDistrict(status, type, "%", Request.QueryString[0].ToString().Trim());
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
            
    //        grdDetails.DataSource = ds.Tables[0];
    //        grdDetails.DataBind();
    //        //string fromdt = Convert.ToDateTime(txtFromDate.Text.Trim()).ToString("dd-MMM-yyyy");
    //        //string Todt = Convert.ToDateTime(txtTodate.Text.Trim()).ToString("dd-MMM-yyyy");
    //        Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();

    //    }
    //    else
    //    {
    //        Label1.Text = "No Records Found ";
    //        grdDetails.DataSource = null;
    //        grdDetails.DataBind();
    //    }

    //}
    public void fillgrid()
    {
        DataSet ds = new DataSet();
        string status = Request.QueryString["STATUS"].ToString().Trim();
        string financialyear = Request.QueryString["FINANCIALYEAR"].ToString().Trim();
        //string fromdate = Request.QueryString[2].ToString().Trim();
        //string todate = Request.QueryString[3].ToString().Trim();


        if (ddldistrict.SelectedItem.Text != "" || ddldistrict.SelectedItem.Text != null)
        {
            ds = homepagedatadrilldown(status, financialyear, ddldistrict.SelectedItem.Text.Trim().ToString(),"%");
        }
        else
        {
            ds = homepagedatadrilldown(status, financialyear, "%", "%");
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            //ds.Tables[0].Columns.Remove("DOA");
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
            //string fromdt = Convert.ToDateTime(txtFromDate.Text.Trim()).ToString("dd-MMM-yyyy");
            //string Todt = Convert.ToDateTime(txtTodate.Text.Trim()).ToString("dd-MMM-yyyy");

        }
        else
        {
           // Label1.Text = "No Records Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
        HyperLink1.NavigateUrl = "TSHOME.aspx";
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
                divPrint.RenderControl(hw);

                //string label1text = Label1.Text;
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='6'><h4>" + lblHeading.Text + "</h4></td></td></tr></table>";
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
    //protected void ExportToExcel()
    //{
    //    try
    //    {


    //        Response.Clear();
    //        Response.Buffer = true;

    //        //string FileName = lblHeading.Text;
    //        //FileName = FileName.Replace(" ", "");
    //        //Response.AddHeader("content-disposition", "attachment;filename=" + FileName + DateTime.Now.ToString("M/d/yyyy") + ".xls");

    //        Response.Charset = "";
    //        Response.ContentType = "application/vnd.ms-excel";
    //        using (StringWriter sw = new StringWriter())
    //        {
    //            DataSet ds = new DataSet();
    //            string status = Request.QueryString["STATUS"].ToString().Trim();
    //            string financialyear = Request.QueryString["FINANCIALYEAR"].ToString().Trim();

    //            //string fromdate = Request.QueryString[2].ToString().Trim();
    //            //string todate = Request.QueryString[3].ToString().Trim();

    //            //if (Session["DistrictID"].ToString().Trim() != "")
    //            //{
    //            //    ds = homepagedatadrilldown(status, financialyear, "%", "%");
    //            //}
    //            //else
    //            //{
    //                ds = homepagedatadrilldown(status, financialyear, "%", "%");
    //            //}

    //            //ds.Tables[0].Columns.Remove("DOA");
    //            HtmlTextWriter hw = new HtmlTextWriter(sw);
    //            grdExport.DataSource = ds.Tables[0];
    //            grdExport.DataBind();
    //            grdExport.RenderControl(hw);
    //            //string label1text = Label1.Text;
    //            //string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='10'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='10'><h4>" + label1text + "</h4></td></td></tr></table>";
    //            //HttpContext.Current.Response.Write(headerTable);

    //            Response.Output.Write(sw.ToString());
    //            Response.Flush();
    //            Response.End();
    //        }
    //    }
    //    catch (Exception e)
    //    {

    //    }
    //}
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    //protected void PrintPdf()
    //{
    //    try
    //    {
    //        using (StringWriter sw = new StringWriter())
    //        {
    //            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
    //            {
    //                //To Export all pages
    //                //trLogo.Visible = true;
    //                grdDetails.AllowPaging = false;
    //                this.fillgrid();
    //                grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
    //                grdDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
    //                grdDetails.Columns[1].Visible = false;
    //                grdDetails.RenderControl(hw);
    //                StringReader sr = new StringReader(sw.ToString());
    //                Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
    //                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
    //                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
    //                pdfDoc.Open();
    //                htmlparser.Parse(sr);
    //                pdfDoc.Close();

    //                Response.ContentType = "application/pdf";
    //                Response.AddHeader("content-disposition", "attachment;filename= TotalApplicationsReceived.pdf");
    //                Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //                Response.Write(pdfDoc);
    //                Response.Flush();
    //                Response.End();
    //            }
    //        }
    //    }
    //    catch (Exception e)
    //    {

    //    }
    //}
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
                    // this.fillgrid();
                    //grdDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
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
                    string FileName = lblHeading.Text;
                    FileName = FileName.Replace(" ", "");
                    Response.AddHeader("content-disposition", "attachment;filename=  " + FileName + ".pdf");
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

    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        fillgrid();
        grdDetails.PageIndex = e.NewPageIndex;
        grdDetails.DataBind();
    }

    protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
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
}