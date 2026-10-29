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
    decimal NumberofApprovalsappliedfor1, Completed1, Pendinglessthan3days1, Numberofpaymentreceivedfor24,Numberofpaymentreceivedfor12, Numberofpaymentreceivedfor22, Pendingmorthan3days1, QueryRaised1, Numberofpaymentreceivedfor1;
    int TotalReg1, Closed1, Open1=0;
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
            Response.Redirect("~/Home2.aspx");

        }
        
        if (!IsPostBack)
        {
           // getdistricts();
            FillGridDetails();
          ///  fillgrid();
        }
    }
    #endregion


    //protected void BtnSave_Click(object sender, EventArgs e)
    //{
    //    fillgrid();
    //}
    //void fillgrid()
    //{

    //    string User = "";
    //    if (Session["user_type"].ToString() == "TST")
    //    {
    //        User = Session["uid"].ToString();
    //    }
    //    else
    //    {
    //        User = "%";
    //    }

    //    DataSet ds = Gen.getCASearch(ddlState.SelectedValue, ddlCounties.SelectedValue,txtca.Text,User);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        lblMsg.Text = ds.Tables[0].Rows.Count.ToString() + " Records found.";
    //        grdDetails.DataSource = ds.Tables[0];
    //        grdDetails.DataBind();
    //    }
    //    else
    //    {
    //        lblMsg.Text = "No Records found.";
    //        grdDetails.DataSource = ds.Tables[0];
    //        grdDetails.DataBind();
    //    }
    //}


    //protected void getdistricts()
    //{
    //    DataSet dsnew = new DataSet();

    //    dsnew = Gen.GetDistricts();
    //    ddldistrict.DataSource = dsnew.Tables[0];
    //    ddldistrict.DataTextField = "District_Name";
    //    ddldistrict.DataValueField = "District_Id";
    //    ddldistrict.DataBind();
    //    ddldistrict.Items.Insert(0, "--Select--");
    //    if (Session["DistrictID"].ToString().Trim() != null)
    //    {
    //        ddldistrict.SelectedValue = Session["DistrictID"].ToString().Trim();
    //        ddldistrict.Enabled = false;
    //    }
    //}
    protected void BtnClear_Click(object sender, EventArgs e)
    {
      //  ddldistrict.SelectedIndex = 0;
      //  txtRegDate.Text = "";
      //  ddlCategory.SelectedIndex = 0;
        
    }
    public void FillGridDetails()
    {


        //ds = Gen.sp_YearWiseProgress(ddlCategory.SelectedItem.Text,ddldistrict.SelectedValue);
        ds = Gen.GetHelpdeskReport();
        if (ds.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
            //Label1.Text = "Report from 1st April 2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
        }
        else
        {
           // Label1.Text = "No Recards Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
    }
  
    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        FillGridDetails();
    }
   
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

           // decimal TotalReg1, Closed1, Open1;


            int TotalReg = Convert.ToInt32((DataBinder.Eval(e.Row.DataItem, "TotalReg")));
            TotalReg1 = TotalReg + TotalReg1;

            int Closed = Convert.ToInt32((DataBinder.Eval(e.Row.DataItem, "TotalClosed")));
            Closed1 = Closed + Closed1;

            int Open = Convert.ToInt32((DataBinder.Eval(e.Row.DataItem, "TotalOpen")));
            Open1 = Open + Open1;



            HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];        
            h1.Target = "_blank";
            h1.NavigateUrl = "RptHelpdeskRptDrildown.aspx?id="+ Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intUserid")).Trim() +"&Status=Total";

            HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
            h2.Target = "_blank";
            h2.NavigateUrl = "RptHelpdeskRptDrildown.aspx?id=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intUserid")).Trim() + "&Status=Closed";

            HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
            h3.Target = "_blank";
            h3.NavigateUrl = "RptHelpdeskRptDrildown.aspx?id=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intUserid")).Trim() + "&Status=Open";



            //decimal Completed = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total Investments"));
            //Completed1 = Completed + Completed1;


            //decimal QueryRaised = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total deptl Approvals Required"));
            //QueryRaised1 = QueryRaised + QueryRaised1;


            //decimal Pendinglessthan3days = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Deptl Approvals already taken by applicant"));
            //Pendinglessthan3days1 = Pendinglessthan3days + Pendinglessthan3days1;

            //decimal Pendingmorthan3days = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Deptl Approvals Applied by applicant"));
            //Pendingmorthan3days1 = Pendingmorthan3days + Pendingmorthan3days1;


            //decimal Numberofpaymentreceivedfor = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Net Approvals required"));
            //Numberofpaymentreceivedfor1 = Numberofpaymentreceivedfor + Numberofpaymentreceivedfor1;

            //decimal Numberofpaymentreceivedfor11 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Deptl Approvals Pending"));
            //Numberofpaymentreceivedfor12 = Numberofpaymentreceivedfor11 + Numberofpaymentreceivedfor12;

            //decimal Numberofpaymentreceivedfor21 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Deptl Approvals Issued"));
            //Numberofpaymentreceivedfor22 = Numberofpaymentreceivedfor21 + Numberofpaymentreceivedfor22;

            //decimal Numberofpaymentreceivedfor23 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TS-iPASS Approvals"));
            //Numberofpaymentreceivedfor24 = Numberofpaymentreceivedfor23 + Numberofpaymentreceivedfor24;





     
            
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {

            e.Row.Cells[1].Text = "Total";
            e.Row.Cells[2].Text = TotalReg1.ToString();
            e.Row.Cells[3].Text = Closed1.ToString();
            e.Row.Cells[4].Text = Open1.ToString();


        }
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
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
            Response.AddHeader("content-disposition", "attachment;filename=R1.1 Abstract -Financial Year wise " + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                div_Print.RenderControl(hw);
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
                    this.FillGridDetails();
                    grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.FooterRow.Visible = false;
                    grdDetails.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename= R1.1 Abstract -Financial Year wise " + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
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
    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        PrintPdf();
    }
}
