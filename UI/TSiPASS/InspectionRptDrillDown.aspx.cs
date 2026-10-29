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
        //if (Session["user"] != null && Session["user"] != "")
        //{ }
        //else
        //{
        //    Response.Redirect("/Account/Login.aspx?link=" + System.Web.HttpContext.Current.Request.Url.PathAndQuery);
        //}
        DataSet ds = new DataSet();
        string status = Request.QueryString[0].ToString().Trim();
        string type = Request.QueryString[1].ToString().Trim();

        string fromdate="" , todate = "";
        if (Request.QueryString.Count ==4)
        {
            fromdate = Request.QueryString[2].ToString().Trim();
            todate = Request.QueryString[3].ToString().Trim();
        }
        if (!IsPostBack)
        {
            ds = Gen.InspectionRptDrilown(status, type,fromdate,todate);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Label1.Text = "Report from 1st April 2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
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

        string fromdate, todate;
        //if (txtFromDate.Text.Trim() == "")
        //{
        //    fromdate = "";

        //}

        //else
        //{

        //    fromdate = Convert.ToDateTime(txtFromDate.Text.Trim()).ToString("yyyy-MM-dd");
        //}

        //if (txtToDate.Text.Trim() == "")
        //{
        //    todate = "";

        //}

        //else
        //{

        //    todate = Convert.ToDateTime(txtToDate.Text.Trim()).ToString("yyyy-MM-dd");
        //}

        todate = "";
        fromdate = "";
        DataSet ds = new DataSet();
        string status = Request.QueryString[0].ToString().Trim();
        string type = Request.QueryString[1].ToString().Trim();
                
        
            ds = Gen.InspectionRptDrilown(status, type, fromdate, todate);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Label1.Text = "Report from 1st April 2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
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

            HyperLink h1 = (HyperLink)e.Row.Cells[9].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
           
            h1.Target = "_blank";

            //h1.NavigateUrl = "InspectionRptDrillDown.aspx?status=1&type=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Department")).Trim();
            h1.NavigateUrl = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Web Path")).Trim();
            h1.Text = "View";

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
            Response.AddHeader("content-disposition", "attachment;filename= Inspection Progress Details " + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                grdDetails.RenderControl(hw);
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
                    Document pdfDoc = new Document(PageSize.A4, 50f, 50f, 50f, 50f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=Inspection Progress Details  " + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
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
