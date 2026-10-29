using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IncentiveSanctionMISPendencyReportDrill : System.Web.UI.Page
{


    General Gen = new General();
    string status, dist;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count == 0)
        {
            Response.Redirect("~/IpassLogin.aspx");
        }

        if (!IsPostBack)
        {

            BindDistricts();
           
            if (Request.QueryString["intDistid"] != null && Request.QueryString["intDistid"] != "")
            {
                ddlDistrict.SelectedValue = Request.QueryString["intDistid"].ToString();


                if (Request.QueryString["status"] != null && Request.QueryString["status"] != "")
                {
                    status = Request.QueryString["status"].ToString();
                }

                FillGridDetails();
            }
        }
    }


    public void FillGridDetails()
    {
        DataSet ds = new DataSet();

        if (Request.QueryString["status"] != null && Request.QueryString["status"] != "")
        {
            status = Request.QueryString["status"].ToString();
        }
        if (status != "") {
            ds = Gen.GetIncentiveSanctionMISPendencyReportDrill(status, ddlDistrict.SelectedValue);
        }
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            Label1.Text = "No Records Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
    }

    public void BindDistricts()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlDistrict.Items.Clear();
            dsd = Gen.GetDistrictsWithoutHYD();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlDistrict.DataSource = dsd.Tables[0];
                ddlDistrict.DataValueField = "District_Id";
                ddlDistrict.DataTextField = "District_Name";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlDistrict.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }


    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        int valid = 0;

        //if (txtFromDate.Text == "" || txtFromDate.Text == null)
        //{
        //    lblmsg0.Text = "Please Enter From Date <br/>";
        //    valid = 1;
        //}
        //if (txtTodate.Text == "" || txtTodate.Text == null)
        //{
        //    lblmsg0.Text += "Please Enter To Date <br/>";
        //    valid = 1;
        //}
        //if (ddlCaste.SelectedItem.Text== "--Select--")
        //{
        //    lblmsg0.Text += "Please Select Caste <br/>";
        //    valid = 1;
        //}
        if (valid == 1)
        {
            Failure.Visible = true;
        }

        if (valid == 0)
        {
            Failure.Visible = false;
            FillGridDetails();
        }
    }

    protected void A2_ServerClick(object sender, EventArgs e)
    {
        ExportToExcel();
    }

    protected void A1_ServerClick(object sender, EventArgs e)
    {
        PrintPdf();
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







}