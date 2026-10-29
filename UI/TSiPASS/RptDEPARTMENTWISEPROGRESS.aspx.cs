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
    decimal NumberofApprovalsappliedfor1, Completed1, Pendinglessthan3days1, Pendingmorthan3days1, QueryRaised1, Numberofpaymentreceivedfor1;
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


    protected void getdistricts()
    {
        DataSet dsnew = new DataSet();

        dsnew = Gen.GetDistricts();
        ddldistrict.DataSource = dsnew.Tables[0];
        ddldistrict.DataTextField = "District_Name";
        ddldistrict.DataValueField = "District_Id";
        ddldistrict.DataBind();
        ddldistrict.Items.Insert(0, "--Select--");

    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        ddldistrict.SelectedIndex = 0;
      //  txtRegDate.Text = "";
        ddlCategory.SelectedIndex = 0;
        
    }
 
  
    protected void BtnSave1_Click(object sender, EventArgs e)
    {

 //ds = (ddldistrict.SelectedIndex > 0 ?
   //         Gen.sp_DepartmentWiseProgress((ddlCategory.SelectedIndex > 0 ? ddlCategory.SelectedItem.Text : ""), ddldistrict.SelectedValue)
     //       :
       //     null
         //   );
        //grdDetails.DataSource = (ds != null ? ds.Tables[0] : null);
        //grdDetails.DataBind();

        FillGridDetails();
    }
    public void FillGridDetails()
    {
        ds = Gen.sp_DepartmentWiseProgress( ddlCategory.SelectedItem.Text, ddldistrict.SelectedValue);
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
   
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string ctg = (ddlCategory.SelectedIndex > 0 ? ddlCategory.SelectedValue : "%");
            string dis = (ddldistrict.SelectedIndex > 0 ? ddldistrict.SelectedValue : "%");

            HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];            
            h1.Target = "_blank";
            h1.NavigateUrl = "DepartmentWiseDetailReport.aspx?status=1&intDeptid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Dept_Id")).Trim();



            HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
            h2.Target = "_blank";
            h2.NavigateUrl = "DepartmentWiseDetailReport.aspx?status=2&intDeptid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Dept_Id")).Trim();

            HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
            h3.Target = "_blank";
            h3.NavigateUrl = "DepartmentWiseDetailReport.aspx?status=3&intDeptid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Dept_Id")).Trim();

            HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
            h4.Target = "_blank";
            h4.NavigateUrl = "DepartmentWiseDetailReport.aspx?status=4&intDeptid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Dept_Id")).Trim();



            e.Row.Cells[6].Text = e.Row.Cells[6].Text + "%";

            decimal NumberofApprovalsappliedfor = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total Approvals"));
            NumberofApprovalsappliedfor1 = NumberofApprovalsappliedfor + NumberofApprovalsappliedfor1;

            decimal Completed = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Approved"));
            Completed1 = Completed + Completed1;


            decimal QueryRaised = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Pending"));
            QueryRaised1 = QueryRaised + QueryRaised1;


            decimal Pendinglessthan3days = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Rejected"));
            Pendinglessthan3days1 = Pendinglessthan3days + Pendinglessthan3days1;

            //decimal Pendingmorthan3days = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Pendinglessthan3days"));
            //Pendingmorthan3days1 = Pendingmorthan3days + Pendingmorthan3days1;


            //decimal Numberofpaymentreceivedfor = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Numberofpaymentreceivedfor"));
            //Numberofpaymentreceivedfor1 = Numberofpaymentreceivedfor + Numberofpaymentreceivedfor1;

            
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total";

            HyperLink Total = new HyperLink();
            Total.ForeColor = System.Drawing.Color.White;
            Total.Target = "_blank";
            Total.NavigateUrl = "DepartmentWiseDetailReport.aspx?status=1&intDeptid=%";
            Total.Text = NumberofApprovalsappliedfor1.ToString();
            //e.Row.Cells[2].Controls.RemoveAt(0);
            e.Row.Cells[2].Controls.Add(Total);

            HyperLink TotalComp = new HyperLink();
            TotalComp.ForeColor = System.Drawing.Color.White;
            TotalComp.Target = "_blank";
            TotalComp.NavigateUrl = "DepartmentWiseDetailReport.aspx?status=2&intDeptid=%";
            TotalComp.Text = Completed1.ToString();
            //e.Row.Cells[2].Controls.RemoveAt(0);
            e.Row.Cells[3].Controls.Add(TotalComp);

            HyperLink TotalQuery = new HyperLink();
            TotalQuery.ForeColor = System.Drawing.Color.White;
            TotalQuery.Target = "_blank";
            TotalQuery.NavigateUrl = "DepartmentWiseDetailReport.aspx?status=3&intDeptid=%";
            TotalQuery.Text = QueryRaised1.ToString();
            //e.Row.Cells[2].Controls.RemoveAt(0);
            e.Row.Cells[4].Controls.Add(TotalQuery);

            HyperLink TotalPending = new HyperLink();
            TotalPending.ForeColor = System.Drawing.Color.White;
            TotalPending.Target = "_blank";
            TotalPending.NavigateUrl = "DepartmentWiseDetailReport.aspx?status=4&intDeptid=%";
            TotalPending.Text = Pendinglessthan3days1.ToString();
            //e.Row.Cells[2].Controls.RemoveAt(0);
            e.Row.Cells[5].Controls.Add(TotalPending);
            
            //e.Row.Cells[2].Text = NumberofApprovalsappliedfor1.ToString();
            //e.Row.Cells[3].Text = Completed1.ToString();
            //e.Row.Cells[4].Text = QueryRaised1.ToString();
            //e.Row.Cells[5].Text = Pendinglessthan3days1.ToString();
           //e.Row.Cells[6].Text = Pendingmorthan3days1.ToString();
            //e.Row.Cells[7].Text = Numberofpaymentreceivedfor1.ToString();
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
            Response.AddHeader("content-disposition", "attachment;filename=Report " + DateTime.Now.ToString("M/d/yyyy") + ".xls");
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
                    //grdDetails.AllowPaging = false;
                    this.FillGridDetails();
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

    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        PrintPdf();
    }
}
