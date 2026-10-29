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
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
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
    string rstages = "0";
    string DistrictID = "0";
    int cnt = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
        }


        if (!IsPostBack)
        {
            GetDetails();


        }


    }
    public void GetDetails()
    {

        DataSet dsn = new DataSet();
        //Response.Write(Session["User_Code"].ToString().Trim()  +  "_" +  rstages.ToString().Trim() + "-" + Session["DistrictID"].ToString().Trim());
        //return;
        dsn = Gen.GetShowSactionedIncentives(ddlConnectLoad0.SelectedValue, txtindustrialName.Text, ddltypeofncentive.SelectedItem.Text.ToString(), txtEMpartnumber.Text);
        if (dsn.Tables[0].Rows.Count > 0)
        {
            Label1.Text = "Report from 1st April 2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
            lblstate11.Text = "Total Records Found : " + dsn.Tables[0].Rows.Count.ToString();
            grdDetails.DataSource = dsn.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            Label1.Text = "No Recards Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
    }

    protected void ExportToExcel()
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Sanctioned incentives(SLC) " + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                //grdDetails.Columns[1].Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                DataSet dsn = new DataSet();
                //Response.Write(Session["User_Code"].ToString().Trim()  +  "_" +  rstages.ToString().Trim() + "-" + Session["DistrictID"].ToString().Trim());
                //return;
                dsn = Gen.GetShowSactionedIncentives(ddlConnectLoad0.SelectedValue, txtindustrialName.Text, ddltypeofncentive.SelectedItem.Text.ToString(), txtEMpartnumber.Text);

                grdExport.DataSource = dsn.Tables[0];
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


    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        GetDetails();


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
        Response.Redirect("SanctionedIncentives.aspx");
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



        }
        catch (Exception ex)
        {
            //lblmsg.Text = ex.ToString();
        }
        finally
        {

        }

    }

    private void fillTrademappingGriddr(DataTable tmpTabledr, string MemType, string authorised, string designation, string gender, string mobile, string email2, string Created_by)
    {




    }

    protected void BtnClear0_Click1(object sender, EventArgs e)
    {

    }
    protected void gvpractical0_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }



    protected void GetNewRectoInsertdr()
    {

    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            //cnt = cnt + 1;
            //e.Row.Cells[0].Text = cnt.ToString();




        }




    }

    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        GetDetails();
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
                    //grdDetails.AllowPaging = false;
                    this.GetDetails();
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
                    Response.AddHeader("content-disposition", "attachment;filename=Sanctioned incentives(SLC) " + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
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
