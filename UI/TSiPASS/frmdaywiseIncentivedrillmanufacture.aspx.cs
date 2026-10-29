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


public partial class UI_TSiPASS_frmdaywiseIncentivedrillmanufacture : System.Web.UI.Page
{
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    decimal NumberofApprovalsappliedfor1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");

        }

        //lblHeading.Text = Request.QueryString[1].ToString().Trim();
        if (!IsPostBack)
        {
            string fromdate = "", Todate = "";
            //getdistricts();
            //BindFinancialYears(ddlFinancialYear);
            //if (Request.QueryString["input"] != null && Request.QueryString["input"] != "")
            //{
            //    rbtnlstInputType.SelectedValue = Request.QueryString["input"].ToString();
            //    rbtnlstInputType_SelectedIndexChanged(sender, e);

            //    if (Request.QueryString["FinYear"] != null && Request.QueryString["FinYear"] != "" && Request.QueryString["FinYear"] != "--Select--")
            //    {
            //        ddlFinancialYear.SelectedValue = Request.QueryString["FinYear"].ToString();
            //    }
            //}
            if (Request.QueryString["fromdate"] != null && Request.QueryString["fromdate"] != "" && Request.QueryString["todate"] != null && Request.QueryString["todate"] != "")
            {
                Label1.Text = "Report from " + Request.QueryString["fromdate"].ToString().Trim() + " To " + Request.QueryString["todate"].ToString().Trim();
                txtFromDate.Text = Request.QueryString["fromdate"].ToString().Trim();
                txtTodate.Text = Request.QueryString["todate"].ToString().Trim();
            }
            else
                Label1.Text = "Report from 1st April 2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
            //if (Request.QueryString["cate"] != null && Request.QueryString["cate"].ToString() != "")
            //   {
            //       //ddlCategory.SelectedValue = Request.QueryString["cate"].ToString().Trim();
            //       ddlCategory.SelectedIndex = ddlCategory.Items.IndexOf(ddlCategory.Items.FindByText(Request.QueryString["cate"].ToString().Trim()));
            //   }
            //   if (Request.QueryString["dist"] != null && Request.QueryString["dist"].ToString() != "")
            //       ddldistrict.SelectedValue = Request.QueryString["dist"].ToString().Trim();
            FillDetails();
            HyperLink1.NavigateUrl = "frmCalenderReportCOI.aspx";//?status=A&lbl=Application Received&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;

        }
    }
    private void ClearFields()
    {
        Label1.Text = "";
        // Label8.Text = "";
        txtFromDate.Text = "";
        txtTodate.Text = "";
        //System.Web.UI.WebControls.ListItem item = ddlFinancialYear.Items.FindByText("--Select--");
        //if (item != null)
        //{
        //    ddlFinancialYear.SelectedValue = "--Select--";
        //}
    }
    //private void getdistricts()
    //{
    //    DataSet dsnew = new DataSet();

    //    dsnew = Gen.GetDistricts();
    //    ddldistrict.DataSource = dsnew.Tables[0];
    //    ddldistrict.DataTextField = "District_Name";
    //    ddldistrict.DataValueField = "District_Id";
    //    ddldistrict.DataBind();
    //    ddldistrict.Items.Insert(0, "--Select--");
    //    if (Session["DistrictID"].ToString().Trim() != "")
    //    {
    //        ddldistrict.SelectedValue = Session["DistrictID"].ToString().Trim();
    //        ddldistrict.Enabled = false;
    //    }
    //    else
    //    {
    //        ddldistrict.Enabled = true;
    //    }
    //}


    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {



    }
    void clear()
    {




    }
    protected void btnGet_Click(object sender, EventArgs e)
    {
        int valid = 0;
        lblmsg0.Text = "";
        Failure.Visible = false;
        //if (rbtnlstInputType.SelectedValue == "N")
        //{
        if (txtFromDate.Text == "" || txtFromDate.Text == null)
        {
            lblmsg0.Text = "Please Enter From Date <br/>";
            valid = 1;
        }
        if (txtTodate.Text == "" || txtTodate.Text == null)
        {
            lblmsg0.Text += "Please Enter To Date <br/>";
            valid = 1;
        }
        //}
        //else
        //{
        //    if (ddlFinancialYear.SelectedItem.ToString() == "--Select--")
        //    {
        //        lblmsg0.Text = "Please Select Financial Year";
        //        valid = 1;
        //    }
        //}
        if (valid == 0)
        {
            FillDetails();
        }
        else
        {
            Failure.Visible = true;
        }
    }

    protected void BtnClear0_Click(object sender, EventArgs e)
    {


    }
    //public void BindFinancialYears(DropDownList ddlFinYear)
    //{
    //    try
    //    {
    //        DataSet dsd = new DataSet();
    //        ddlFinYear.Items.Clear();
    //        dsd = Gen.GetFinancialYearsForReports();
    //        //ListItem ITEM=new ListItem
    //        if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
    //        {
    //            ddlFinYear.DataSource = dsd.Tables[0];
    //            ddlFinYear.DataValueField = "SlNo";
    //            ddlFinYear.DataTextField = "FinancialYear";
    //            ddlFinYear.DataBind();
    //            //if (Session["Role_Code"] != null && Session["Role_Code"].ToString() != "" && Session["Role_Code"].ToString() == "COMM")
    //            //{
    //            //    AddAll(ddlFinYear);
    //            //}
    //        }


    //        ddlFinYear.Items.Insert(0, "--Select--");

    //    }
    //    catch (Exception ex)
    //    {
    //        //lblmsg0.Text = ex.Message;
    //        //lblmsg0.CssClass = "errormsg";
    //    }
    //}
    void FillDetails()
    {

        DataSet ds = new DataSet();
        // ds = Gen.getR1Drildownbyidfin(status, ddlCategory.SelectedItem.Text, ddldistrict.SelectedValue);
        string[] date = Request.QueryString[1].ToString().Trim().Split(' ');
        //string[] newdate = date[0].ToString().Split('-');

        txtFromDate.Text = date[0].ToString();
        string status = date[1].ToString();
        string FromdateforDB = "", TodateforDB = "";
        //if (txtFromDate.Text != "" && txtFromDate.Text.Contains('/'))
        //{
        lblHeading.Text = "Incentives Applications for Dated " + txtFromDate.Text.Trim();

        string input, financial, fromdate, todate;
        //string status = Request.QueryString[1].ToString().Trim();
        string type = Request.QueryString[2].ToString().Trim();

        //input = rbtnlstInputType.SelectedValue.ToString().Trim();
        //financial = ddlFinancialYear.SelectedValue.ToString().Trim();
        //fromdate = txtFromDate.Text;
        //todate = txtTodate.Text;
        //string FromdateforDB = "", TodateforDB = "";
        if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
        {
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            //TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        }

        string Districts = Request.QueryString["intApplicationId"].ToString().Trim();
        string SECTOR = Request.QueryString["TYPE"].ToString().Trim();

        if (Session["DistrictID"].ToString().Trim() != "")
        {
            ds = GetIncentiveDashBoardDrill(Session["DistrictID"].ToString().Trim(), txtFromDate.Text, status,SECTOR);
        }
        else
        {
            ds = GetIncentiveDashBoardDrill(Request.QueryString[0].ToString().Trim(), txtFromDate.Text,status, SECTOR);
        }

        //ds = GetIncentiveDashBoardDrill(Districts,FromdateforDB,SECTOR);
        //  ds = Gen.GetIncentiveDashBoardDrill(type, status, FromdateforDB, TodateforDB);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            // Label1.Text = "Report from 1st April 2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
            string fromdt = "", Todt = "";
            //if (rbtnlstInputType.SelectedValue == "N")
            //{
            Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
            //}
            //else
            //{
            // Label1.Text = "Report of Financial Year : " + ddlFinancialYear.SelectedItem.Text;
            //}
            //ds.Tables[0].Columns.Remove("CRTDDT");
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            Label1.Text = "No Records Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
        HyperLink1.NavigateUrl = "IncentiveAbstractReport.aspx?status=A&lbl=Application Received&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;

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
    //protected void BtnSave2_Click(object sender, EventArgs e)
    //{

    //    try
    //    {



    //    }
    //    catch (Exception ex)
    //    {
    //        // lblmsg.Text = ex.ToString();
    //    }
    //    finally
    //    {

    //    }

    //}



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

            //decimal NumberofApprovalsappliedfor = Convert.ToDecimal(DataBinder.Eval(e.Row.Cells[5].Text, "Total Investment (in Crores)"));
            //decimal NumberofApprovalsappliedfor = Convert.ToDecimal((e.Row.Cells[6].Text.Trim() == "" ? "0" : e.Row.Cells[6].Text));
            //NumberofApprovalsappliedfor1 = NumberofApprovalsappliedfor + NumberofApprovalsappliedfor1;

            //decimal NumberofApprovalsappliedfor = Convert.ToDecimal((e.Row.Cells[6].Text.Trim() == "" ? "0" : e.Row.Cells[6].Text));
            //NumberofApprovalsappliedfor1 = NumberofApprovalsappliedfor + NumberofApprovalsappliedfor1;

            //string intUid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID Number")).Trim();
            //LinkButton btn = (LinkButton)e.Row.FindControl("LinkButton1");

            //btn.Text = "View";


            //btn.OnClientClick = "javascript:return Popup('" + intUid + "')";



        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {

            //e.Row.Cells[5].Text = "Total";
            //e.Row.Cells[5].ForeColor = System.Drawing.Color.White;
            //e.Row.Cells[6].Text = NumberofApprovalsappliedfor1.ToString();
            //e.Row.Cells[6].ForeColor = System.Drawing.Color.White;

        }
    }



    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        //string status = Request.QueryString[0].ToString().Trim();
        //DataSet ds = new DataSet();
        //string input, financial, fromdate, todate;
        //input = rbtnlstInputType.SelectedValue.ToString().Trim();
        //financial = ddlFinancialYear.SelectedValue.ToString().Trim();
        //fromdate = txtFromDate.Text;
        //todate = txtTodate.Text;
        //ds = Gen.getR1DrildownbyidfinNew(status, ddlCategory.SelectedItem.Text, ddldistrict.SelectedValue, input, financial, fromdate, todate);

        //if (ds != null && ds.Tables[0].Rows.Count > 0)
        //{
        //    Label1.Text = "Report from 1st April 2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
        //    ds.Tables[0].Columns.Remove("DOA");
        //    grdDetails.DataSource = ds.Tables[0];
        //    grdDetails.DataBind();
        //}
        //else
        //{
        //    Label1.Text = "No Records Found ";
        //    grdDetails.DataSource = ds.Tables[0];
        //    grdDetails.DataBind();
        //}
        int valid = 0;
        lblmsg0.Text = "";
        Failure.Visible = false;
        //if (rbtnlstInputType.SelectedValue == "N")
        //{
        if (txtFromDate.Text == "" || txtFromDate.Text == null)
        {
            lblmsg0.Text = "Please Enter From Date <br/>";
            valid = 1;
        }
        if (txtTodate.Text == "" || txtTodate.Text == null)
        {
            lblmsg0.Text += "Please Enter To Date <br/>";
            valid = 1;
        }
        //}
        //else
        //{
        //    if (ddlFinancialYear.SelectedItem.ToString() == "--Select--")
        //    {
        //        lblmsg0.Text = "Please Select Financial Year";
        //        valid = 1;
        //    }
        //}
        if (valid == 0)
        {
            FillDetails();
        }
        else
        {
            Failure.Visible = true;
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
                // grdDetails.Columns[1].Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                string status = Request.QueryString[0].ToString().Trim();
                string type = Request.QueryString[1].ToString().Trim();
                DataSet ds = new DataSet();
                string input, financial, fromdate, todate;
                //input = rbtnlstInputType.SelectedValue.ToString().Trim();
                //financial = ddlFinancialYear.SelectedValue.ToString().Trim();
                string FromdateforDB = "", TodateforDB = "";
                if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
                {
                    FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                    TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                }
                string Districts = Request.QueryString["District"].ToString().Trim();
                ds = Gen.GetIncentiveDashBoardDrill(type, status, FromdateforDB, TodateforDB, Districts);
                //ds = Gen.getR1DrildownbyidfinNew(status, ddlCategory.SelectedItem.Text, ddldistrict.SelectedValue, input, financial, FromdateforDB, TodateforDB);
                //ds = Gen.GetIncentiveDashBoardDrill(type, status, FromdateforDB, TodateforDB);
                // ds.Tables[0].Columns.Remove("DOA");

                grdExport.DataSource = ds.Tables[0];
                grdExport.DataBind();

                grdExport.RenderControl(hw);
                //grdDetails.Columns.RemoveAt("View");
                string label1text = Label1.Text;
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='6'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='6'><h4>" + label1text + "</h4></td></td></tr></table>";
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

    private void AssignGridRowStyle(GridViewRow gr, string cssName)
    {
        try
        {
            if (gr.RowType == DataControlRowType.Header)
            {
                for (int cellIndex = 0; cellIndex < gr.Cells.Count; cellIndex++) gr.Cells[cellIndex].CssClass = "GridviewScrollC1Header";
            }
            else if (gr.RowType == DataControlRowType.Footer)
            {
                gr.CssClass = cssName;

                for (int cellIndex = 0; cellIndex < gr.Cells.Count; cellIndex++)
                {
                    gr.Cells[cellIndex].CssClass = cssName;

                    try
                    {
                        double d;
                        if (Double.TryParse(gr.Cells[cellIndex].Text, out d)) gr.Cells[cellIndex].CssClass = "algnCenter";
                    }
                    catch (Exception) { }
                }
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
                        if (Double.TryParse(gr.Cells[cellIndex].Text, out d)) gr.Cells[cellIndex].CssClass = "algnCenter";
                    }
                    catch (Exception) { }
                }
            }
        }
        catch (Exception) { }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
        ExportToExcel();
    }
    protected void BtnSave3_Click(object sender, EventArgs e)
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
                    grdDetails.AllowPaging = false;

                    // this.FillDetails();
                    grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.FooterRow.Visible = false;
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
                    Response.AddHeader("content-disposition", "attachment;filename= R1.3ApplicationReceived" + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
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

    public DataSet GetIncentiveDashBoardDrill(string DISTRICTID, string AppnId, string status, string SECTOR)
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
            da = new SqlDataAdapter("USP_GET_DAYWISE_INCENTIVEMANUFACTURE_COI", osqlConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (DISTRICTID.Trim() == "" || DISTRICTID.Trim() == null || DISTRICTID.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@District", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@District", SqlDbType.VarChar).Value = DISTRICTID.ToString();

            if (AppnId.Trim() == "" || AppnId.Trim() == null)
                da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = AppnId.ToString();

            if (SECTOR.Trim() == "" || SECTOR.Trim() == null || SECTOR.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@SECTOR", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@SECTOR", SqlDbType.VarChar).Value = SECTOR.ToString();

            if (status.Trim() == "" || status.Trim() == null || status.Trim() == "--Select--")
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