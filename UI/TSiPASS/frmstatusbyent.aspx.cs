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
using iTextSharp.text.pdf;//created by suresh as on 13-1-2016 
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

        DataSet dist = new DataSet();
            dist = Gen.GetDistrictbyID(Request.QueryString[1].ToString().Trim());



            lblHeading.Text = "Total Capital Investment " + dist.Tables[0].Rows[0]["District_Name"].ToString()+ " - " + Request.QueryString[2].ToString().Trim();
        if (!IsPostBack)
        {

            
            string status = Request.QueryString[0].ToString().Trim();
            DataSet ds = new DataSet();
            ds = Gen.RetriveStatusForViewApplication(Request.QueryString[0].ToString().Trim(), Request.QueryString[2].ToString().Trim(), Request.QueryString[1].ToString().Trim());

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ds.Tables[0].Columns.Remove("Activity Proposed");
                ds.Tables[0].Columns.Remove("DOA");
               
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
            decimal NumberofApprovalsappliedfor = Convert.ToDecimal((e.Row.Cells[5].Text.Trim() == "" ? "0" : e.Row.Cells[5].Text));
            NumberofApprovalsappliedfor1 = NumberofApprovalsappliedfor + NumberofApprovalsappliedfor1;

            //decimal NumberofApprovalsappliedfor = Convert.ToDecimal((e.Row.Cells[6].Text.Trim() == "" ? "0" : e.Row.Cells[6].Text));
            //NumberofApprovalsappliedfor1 = NumberofApprovalsappliedfor + NumberofApprovalsappliedfor1;

            string intUid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID Number")).Trim();
            LinkButton btn = (LinkButton)e.Row.FindControl("LinkButton1");

            btn.Text = "View";


            btn.OnClientClick = "javascript:return Popup('" + intUid + "')";

        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {

            e.Row.Cells[4].Text = "Total";
            e.Row.Cells[4].ForeColor = System.Drawing.Color.White;
            e.Row.Cells[5].Text = NumberofApprovalsappliedfor1.ToString();
            e.Row.Cells[5].ForeColor = System.Drawing.Color.White;

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

    public void fillgrid()
    {
        string status = Request.QueryString[0].ToString().Trim();
        DataSet ds = new DataSet();
        ds = Gen.RetriveStatusForViewApplication(Request.QueryString[0].ToString().Trim(), Request.QueryString[2].ToString().Trim(), Request.QueryString[1].ToString().Trim());

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            ds.Tables[0].Columns.Remove("DOA");
            //ds.Tables[0].Columns.Remove("Activity Proposed");
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
            Label1.Text = "Report from 1st April 2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
        }
        else
        {
            Label1.Text = "No Recards Found ";
            grdDetails.DataSource = null;
        }
    }
    

    //protected void grdExport_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
        
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
            
    //        //decimal NumberofApprovalsappliedfor = Convert.ToDecimal(DataBinder.Eval(e.Row.Cells[5].Text, "Total Investment (in Crores)"));
    //        decimal NumberofApprovalsappliedfor = Convert.ToDecimal((e.Row.Cells[6].Text.Trim() == "" ? "0" : e.Row.Cells[6].Text));
    //        NumberofApprovalsappliedfor1 = NumberofApprovalsappliedfor + NumberofApprovalsappliedfor1;

            

    //    }

    //    if (e.Row.RowType == DataControlRowType.Footer)
    //    {

    //        e.Row.Cells[5].Text = "Total";
    //       // e.Row.Cells[5].ForeColor = System.Drawing.Color.White;
    //        e.Row.Cells[6].Text = NumberofApprovalsappliedfor1.ToString();
    //       // e.Row.Cells[6].ForeColor = System.Drawing.Color.White;

    //    }
    //}

    protected void ExportToExcel()
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Total Applications Received " + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                //grdDetails.Columns[1].Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                string status = Request.QueryString[0].ToString().Trim();
                DataSet ds = new DataSet();
                ds = Gen.RetriveStatusForViewApplication(Request.QueryString[0].ToString().Trim(), Request.QueryString[2].ToString().Trim(), Request.QueryString[1].ToString().Trim());
                ds.Tables[0].Columns.Remove("DOA");

                //ds.Tables[0].Columns.Remove("Activity Proposed");
                grdExport.DataSource = ds.Tables[0];
                grdExport.DataBind();

                grdExport.RenderControl(hw);
                //grdDetails.Columns.RemoveAt("View");
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
                    grdDetails.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename= Total Applications Received.pdf");
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
}
