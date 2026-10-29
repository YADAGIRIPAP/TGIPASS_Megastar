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

//created by suresh as on 1-17-2016 for county adm lookup 
//tables td_CountyAdmDet,getCASearch

public partial class LookupCA : System.Web.UI.Page
{
    decimal NumberofApprovalsappliedfor1, Completed1, Pendinglessthan3days1, Pendingmorthan3days1, QueryRaised1, Numberofpaymentreceivedfor1, Status1;
    #region Declaration
    General gen = new General();
    General Gen = new General();
    int Sno = 0;

    DataSet ds;
    DataTable dt;


    DataSet dslist;
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");

        }
        if (!IsPostBack)
        {
            getdistricts();
            DataSet dsd = new DataSet();
            dsd = Gen.GetDepartment();
            ddlDepartment.DataSource = dsd.Tables[0];
            ddlDepartment.DataValueField = "Dept_Id";
            ddlDepartment.DataTextField = "Dept_Name";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, "--Select--");
            fillgrid();

        }
    }
    #endregion

    protected void getdistricts()
    {
        //DataSet dsnew = new DataSet();

        //dsnew = Gen.GetDistricts1();
        //ddldistrict.DataSource = dsnew.Tables[0];
        //ddldistrict.DataTextField = "District_Name";
        //ddldistrict.DataValueField = "District_Id";
        //ddldistrict.DataBind();
        //ddldistrict.Items.Insert(0, "--Select--");

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    void fillgrid()
    {
        if (Session["DistrictID"].ToString().Trim() != null)
        {
            ds = Gen.RetriveApprovalsPendingBeyondTimeLimit((ddlDepartment.SelectedItem.Text.ToLower() == "--select--" ? "" : ddlDepartment.SelectedValue), Session["DistrictID"].ToString().Trim());
        }
        else
        {
            ds = Gen.RetriveApprovalsPendingBeyondTimeLimit((ddlDepartment.SelectedItem.Text.ToLower() == "--select--" ? "" : ddlDepartment.SelectedValue), "%");
        }
        //ds=Gen.RetriveApprovalsPendingBeyondTimeLimit(ddlDepartment.SelectedValue);
        //ds = Gen.sp_GetDepartmentNameReport(ddlDepartment.SelectedValue, ddldistrict.SelectedValue);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
            Label1.Text = "Report from 1st April 2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
        }
        else
        {
            Label1.Text = "No Recards Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {

    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
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

            decimal NumberofApprovalsappliedfor = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Investment"));
            NumberofApprovalsappliedfor1 = NumberofApprovalsappliedfor + NumberofApprovalsappliedfor1;

            string intUid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID Number")).Trim();
            LinkButton btn = (LinkButton)e.Row.FindControl("LinkButton1");

            btn.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID Number")).Trim();

            btn.OnClientClick = "javascript:return Popup('" + intUid + "')";

            //decimal NumberofApprovalsappliedfor = Convert.ToDecimal((e.Row.Cells[4].Text.Trim() == "" ? "0" : e.Row.Cells[4].Text));
            //NumberofApprovalsappliedfor1 = NumberofApprovalsappliedfor + NumberofApprovalsappliedfor1;

        }


        if (e.Row.RowType == DataControlRowType.Footer)
        {

            e.Row.Cells[4].Text = "Total";
            e.Row.Cells[5].Text = NumberofApprovalsappliedfor1.ToString();

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
   
    protected void ddlCounties_SelectedIndexChanged(object sender, EventArgs e)
    {

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
            Response.AddHeader("content-disposition", "attachment;filename= R4 Approvals pending Beyond Time Limit Report " + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                if (Session["DistrictID"].ToString().Trim() != null)
                {
                    ds = Gen.RetriveApprovalsPendingBeyondTimeLimit((ddlDepartment.SelectedItem.Text.ToLower() == "--select--" ? "" : ddlDepartment.SelectedValue), Session["DistrictID"].ToString().Trim());
                }
                else
                {
                    ds = Gen.RetriveApprovalsPendingBeyondTimeLimit((ddlDepartment.SelectedItem.Text.ToLower() == "--select--" ? "" : ddlDepartment.SelectedValue), "%");
                }

                //ds.Tables[0].Columns.Remove("DOA");
                grdExport.DataSource = ds.Tables[0];
                grdExport.DataBind();
                grdExport.RenderControl(hw);

                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
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
                    this.fillgrid();
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
                    Response.AddHeader("content-disposition", "attachment;filename= R4 Approvals pending Beyond Time Limit Report.pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
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
    protected void Button2_Click(object sender, EventArgs e)
    {
        PrintPdf();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {

    }
}
