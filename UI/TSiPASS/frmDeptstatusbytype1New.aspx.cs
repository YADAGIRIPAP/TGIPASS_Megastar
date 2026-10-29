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
    protected void Page_Load(object sender, EventArgs e)
    {
        //////if (Session["user"] != null && Session["user"] != "")
        //////{ }
        //////else
        //////{
        //////    Response.Redirect("/Account/Login.aspx?link=" + System.Web.HttpContext.Current.Request.Url.PathAndQuery);
        //////}
        ////if (Request.QueryString[1].ToString().Trim() == "Total")
        ////{
        ////    lblHeading.Text =  Request.QueryString[2].ToString().Trim();
        ////}
        ////else
        ////{
        ////    lblHeading.Text = Request.QueryString[2].ToString().Trim() + " " + Request.QueryString[1].ToString().Trim();
        ////}
        //DataSet ds = new DataSet();
        //string status = Request.QueryString[0].ToString().Trim();
        //string type = Request.QueryString[1].ToString().Trim();
        DataSet ds = new DataSet();
        string status = Request.QueryString[1].ToString().Trim();
        string type = Request.QueryString[4].ToString().Trim();
        //string fromdate = Request.QueryString[2].ToString().Trim();
        //string todate = Request.QueryString[3].ToString().Trim();


        if (!IsPostBack)
        {

            txtFromDate.Text = Request.QueryString[2].ToString().Trim();
            txtTodate.Text = Request.QueryString[3].ToString().Trim();
            string FromdateforDB = "", TodateforDB = "";
            if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
            {
                FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }
            if (Session["DistrictID"].ToString().Trim() != "")
            {
                ds = Gen.RetriveStatusByTypedeptNew(status, type, Request.QueryString[0].ToString().Trim(), Session["DistrictID"].ToString().Trim(), FromdateforDB, TodateforDB);
            }
            else
            {
                ds = Gen.RetriveStatusByTypedeptNew(status, type, Request.QueryString[0].ToString().Trim(), "%", FromdateforDB, TodateforDB);
            }


            if (ds.Tables[0].Rows.Count > 0)
            {
                ds.Tables[0].Columns.Remove("DOA");
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
                Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
            }
            else
            {
                Label1.Text = "No Records Found ";
                grdDetails.DataSource = null;
                grdDetails.DataBind();
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
    public void fillgrid()
    {
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
        DataSet ds = new DataSet();
        if (Session["DistrictID"].ToString().Trim() != "")
        {
            ds = Gen.RetriveStatusByTypedeptNew(status, type, Request.QueryString[0].ToString().Trim(), Session["DistrictID"].ToString().Trim(), FromdateforDB, TodateforDB);
        }
        else
        {
            ds = Gen.RetriveStatusByTypedeptNew(status, type, Request.QueryString[0].ToString().Trim(), "%", FromdateforDB, TodateforDB);
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            ds.Tables[0].Columns.Remove("DOA");
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
            //string fromdt = Convert.ToDateTime(txtFromDate.Text.Trim()).ToString("dd-MMM-yyyy");
            //string Todt = Convert.ToDateTime(txtTodate.Text.Trim()).ToString("dd-MMM-yyyy");
            Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
            //Label1.Text = "Report from 1st April 2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
        }
        else
        {
            Label1.Text = "No Records Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
          
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
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string intUid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID")).Trim();
            LinkButton btn = (LinkButton)e.Row.FindControl("LinkButton1");

            btn.Text = "View";

            btn.OnClientClick = "javascript:return Popup('" + intUid + "')";
        }
    }
    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ExportToExcel()
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=TotalApplicationsReceived-" + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
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
                DataSet ds = new DataSet();
                if (Session["DistrictID"].ToString().Trim() != "")
                {
                    ds = Gen.RetriveStatusByTypedeptNew(status, type, Request.QueryString[0].ToString().Trim(), Session["DistrictID"].ToString().Trim(), FromdateforDB, TodateforDB);
                }
                else
                {
                    ds = Gen.RetriveStatusByTypedeptNew(status, type, Request.QueryString[0].ToString().Trim(), "%", FromdateforDB, TodateforDB);
                }
                ds.Tables[0].Columns.Remove("DOA");
                HtmlTextWriter hw = new HtmlTextWriter(sw);
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

}
