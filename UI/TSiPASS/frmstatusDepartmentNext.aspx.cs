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
//created by suresh as on 13-1-2016 
//tables is td_BDCDet,tbl_Users
//procedures CheckUserid,insrtBDC,deleteBDC,getBDCbyID
public partial class TSTBDCReg1 : System.Web.UI.Page
{
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

        if (!IsPostBack)
        {
            GetDepartment();
            getdistricts();
            string status = Request.QueryString[0].ToString().Trim();
            string distrinct = Request.QueryString[3].ToString().Trim();
            string Category = Request.QueryString[2].ToString().Trim();
            ddldistrict.SelectedValue = ddldistrict.Items.FindByValue(Request.QueryString[3].ToString().Trim()).Value;

            ddlCategory.SelectedValue = ddlCategory.Items.FindByValue(Request.QueryString[2].ToString().Trim()).Value;
            DataSet ds = new DataSet();
            ds = Gen.RetriveStatusForViewApplicationDepartmentwise(Request.QueryString[0].ToString().Trim(), ddlCategory.SelectedItem.Text, ddldistrict.SelectedValue, Request.QueryString[1].ToString().Trim());
           
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                Label1.Text = "Report from 1st April 2016 to  " + System.DateTime.Now.ToString("dd-MMM-yyyy");
                ds.Tables[0].Columns.Remove("DOA");
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
            }
            else
            {
                Label1.Text = "No Recards Found ";
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }
        }


    }

    protected void GetDepartment()
    {
        DataSet dsd = new DataSet();

        dsd = Gen.GetDepartmentbyid(Request.QueryString[1].ToString().Trim());
        if (Request.QueryString[0].ToString().Trim() == "A")
        {
            lblHeading.Text = "Total Applications - " + dsd.Tables[0].Rows[0]["Dept_Name"].ToString();
            lblLink.Text = "Total Applications - " + dsd.Tables[0].Rows[0]["Dept_Name"].ToString();
        }
        if (Request.QueryString[0].ToString().Trim() == "B")
        {
            lblHeading.Text = "Prescrutiny Completed - " + dsd.Tables[0].Rows[0]["Dept_Name"].ToString();
            lblLink.Text = "Prescrutiny Completed - " + dsd.Tables[0].Rows[0]["Dept_Name"].ToString();
        }
        if (Request.QueryString[0].ToString().Trim() == "C")
        {
            lblHeading.Text = "Prescrutiny - Query Raised - " + dsd.Tables[0].Rows[0]["Dept_Name"].ToString();
            lblLink.Text = "Prescrutiny - Query Raised  - " + dsd.Tables[0].Rows[0]["Dept_Name"].ToString();
        }
        if (Request.QueryString[0].ToString().Trim() == "D")
        {
            lblHeading.Text = "Prescrutiny - Pending within 3 days - " + dsd.Tables[0].Rows[0]["Dept_Name"].ToString();
            lblLink.Text = "Prescrutiny - Pending within 3 days - " + dsd.Tables[0].Rows[0]["Dept_Name"].ToString();
        }
        if (Request.QueryString[0].ToString().Trim() == "E")
        {
            lblHeading.Text = "Prescrutiny - Pending Raised More Than 3 days - " + dsd.Tables[0].Rows[0]["Dept_Name"].ToString();
            lblLink.Text = "Prescrutiny - Pending Raised More Than 3 days - " + dsd.Tables[0].Rows[0]["Dept_Name"].ToString();
        }
        if (Request.QueryString[0].ToString().Trim() == "F")
        {
            lblHeading.Text = "Approval Payment Status - " + dsd.Tables[0].Rows[0]["Dept_Name"].ToString();
            lblLink.Text = "Approval Payment Status - " + dsd.Tables[0].Rows[0]["Dept_Name"].ToString();
        }

    }

    private void getdistricts()
    {
        DataSet dsnew = new DataSet();

        dsnew = Gen.GetDistricts();
        ddldistrict.DataSource = dsnew.Tables[0];
        ddldistrict.DataTextField = "District_Name";
        ddldistrict.DataValueField = "District_Id";
        ddldistrict.DataBind();
        ddldistrict.Items.Insert(0, "--Select--");
        if (Session["DistrictID"].ToString().Trim() != "")
        {
            ddldistrict.SelectedValue = Session["DistrictID"].ToString().Trim();
            ddldistrict.Enabled = false;
        }
        else
        {
            ddldistrict.Enabled = true;
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

    protected void ddlProp_intDistrictid_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       // AssignGridRowStyle(e.Row, "GRDITEM");
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

            string intUid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID Number")).Trim();
            LinkButton btn = (LinkButton)e.Row.FindControl("LinkButton1");

            btn.Text = "View";


            btn.OnClientClick = "javascript:return Popup('" + intUid + "')";


        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {

            //e.Row.Cells[4].Text = "Total";
            //e.Row.Cells[4].ForeColor = System.Drawing.Color.White;
            //e.Row.Cells[5].Text = NumberofApprovalsappliedfor1.ToString();
            //e.Row.Cells[5].ForeColor = System.Drawing.Color.White;
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
    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        string status = Request.QueryString[0].ToString().Trim();
        string distrinct = Request.QueryString[3].ToString().Trim();
        string Category = Request.QueryString[2].ToString().Trim();
       
        DataSet ds = new DataSet();
        ds = Gen.RetriveStatusForViewApplicationDepartmentwise(Request.QueryString[0].ToString().Trim(), ddlCategory.SelectedItem.Text, ddldistrict.SelectedValue, Request.QueryString[1].ToString().Trim());

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            Label1.Text = "Report from 1st April 2016 to  " + System.DateTime.Now.ToString("dd-MMM-yyyy");
            ds.Tables[0].Columns.Remove("DOA");
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            Label1.Text = "No Recards Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
    }

    public void fillgrid()
    {
        string status = Request.QueryString[0].ToString().Trim();
        string distrinct = Request.QueryString[3].ToString().Trim();
        string Category = Request.QueryString[2].ToString().Trim();
        
        DataSet ds = new DataSet();
        ds = Gen.RetriveStatusForViewApplicationDepartmentwise(Request.QueryString[0].ToString().Trim(), ddlCategory.SelectedItem.Text, ddldistrict.SelectedValue, Request.QueryString[1].ToString().Trim());
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            Label1.Text = "Report from 1st April 2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
            ds.Tables[0].Columns.Remove("DOA");
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            Label1.Text = "No Recards Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
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
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("content-disposition", "attachment;filename="+lblHeading.Text + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            this.EnableViewState = false;

            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            DataSet ds = new DataSet();
            ds = Gen.RetriveStatusForViewApplicationDepartmentwise(Request.QueryString[0].ToString().Trim(), ddlCategory.SelectedItem.Text, ddldistrict.SelectedValue, Request.QueryString[1].ToString().Trim());
            ds.Tables[0].Columns.Remove("DOA");
            grdExport.DataSource = ds.Tables[0];
            grdExport.DataBind();

            grdExport.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();



        }
        catch (Exception e)
        {

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
                    grdDetails.AllowPaging = false;
                    this.fillgrid();
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
                    Response.AddHeader("content-disposition", "attachment;filename= " + lblHeading.Text + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
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


    protected void BtnSave3_Click1(object sender, EventArgs e)
    {
        PrintPdf();
    }
}
