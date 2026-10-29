using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Mail;
//using TSIPassBE;
//using TSIPassBL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Text;
using System.Drawing;
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
       
       
        if (Session.Count <= 0)
        {
            Response.Redirect("../../Index.aspx");
        }



        if (!IsPostBack)
        {
            //if (Session["Applid"] != null || Session["Applid"] != "")
            //{
            //    //  Response.Redirect("frmDepartmentApprovalDetails.aspx");

            //}
            //else
            //{
            //    Response.Redirect("frmQuesstionniareReg.aspx");

            //}
            Label1.Text = "Report from 1st April to " + System.DateTime.Now.ToString("dd-MM-yyyy");
            DataSet ds = new DataSet();
            if (Session["DistrictID"].ToString().Trim() != "")
            {
                ds = Gen.GetR1ReportbyDistrictid(Session["DistrictID"].ToString().Trim());
                DataSet dsd = new DataSet();
                dsd = Gen.GetDistrictbyID(Session["DistrictID"].ToString().Trim());


                lblHeading.Text = "R1.2: " + dsd.Tables[0].Rows[0]["District_Name"].ToString().ToUpper() + " DISTRICT DASHBOARD";
            }
            else
            {
                ds = Gen.GetR1ReportbyDistrictid("%");
                lblHeading.Text = "R1.2: CM's DASHBOARD";
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
                LblProjCost.Text = "Total Capital Investment (Rs. in Crores) :";
                lbtProjCost.Text= ds.Tables[1].Rows[0][0].ToString().Trim();
               
                grdDetails0.DataSource = ds.Tables[2];
                grdDetails0.DataBind();
                


                grdDetails3.DataSource = null;
                grdDetails3.DataBind();

                grdDetails1.DataSource = ds.Tables[4];
                grdDetails1.DataBind();

                grdDetails2.DataSource = ds.Tables[5];
                grdDetails2.DataBind();
                grdDetails2.Visible = false;
                Label484.Visible = false;
                
            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
                grdDetails0.DataSource =null;
                grdDetails0.DataBind();
                grdDetails1.DataSource = null;
                grdDetails1.DataBind();
                grdDetails2.DataSource = null;
                grdDetails2.DataBind();
                grdDetails3.DataSource = null;
                grdDetails3.DataBind();
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

            HyperLink h1 = (HyperLink)e.Row.Cells[1].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h1.NavigateUrl = "frmstatus.aspx?status=A&lbl=Total Applications Received";// +Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intmandalId")).Trim();

            HyperLink h2 = (HyperLink)e.Row.Cells[2].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h2.NavigateUrl = "frmstatus.aspx?status=B&lbl=Total Approvals Required As Per Questionnaire";// +Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intmandalId")).Trim();

            HyperLink h3 = (HyperLink)e.Row.Cells[3].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h3.NavigateUrl = "frmstatus.aspx?status=C&lbl=Offline Approvals Taken";// +Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intmandalId")).Trim();

            HyperLink h4 = (HyperLink)e.Row.Cells[4].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h4.NavigateUrl = "frmstatus.aspx?status=D&lbl=Net Approvals Required";// +Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intmandalId")).Trim();

            HyperLink h5 = (HyperLink)e.Row.Cells[5].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h5.NavigateUrl = "frmstatus.aspx?status=E&lbl=Total Approvals Applied";// +Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intmandalId")).Trim();

        }
    }
    protected void grdDetails0_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();

            
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h1.NavigateUrl = "frmstatusbytype.aspx?status=1&type=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DType")).Trim() + "&lbl=Pre-scrutiny: Pending";

            HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h2.NavigateUrl = "frmstatusbytype.aspx?status=2&type=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DType")).Trim() + "&lbl=Pre-scrutiny: Query Raised";
            if ((e.Row.Cells[1].Text) == "Beyond Three Days")  
            {  
                h1.ForeColor = System.Drawing.Color.Red;
                h1.Font.Bold = true;
            }  
           

            HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h3.NavigateUrl = "frmstatusbytype.aspx?status=3&type=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DType")).Trim() + "&lbl=Pre-scrutiny Completed";

            HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h4.NavigateUrl = "frmstatusbytype.aspx?status=4&type=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DType")).Trim() + "&lbl=Pre-scrutiny: Total";

          //  h4.Text = Convert.ToString(Convert.ToInt32(h1.Text) + Convert.ToInt32(h2.Text) + Convert.ToInt32(h3.Text));
            //  h4.ForeColor = System.Drawing.Color.Black;

            h4.Font.Bold = true;

        }
    }
    protected void grdDetails2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h1.NavigateUrl = "frmstatusbyApprovels.aspx?status=1&type=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DType")).Trim();
            
            HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h2.NavigateUrl = "frmstatusbyApprovels.aspx?status=2&type=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DType")).Trim();
            
            HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h3.NavigateUrl = "frmstatusbyApprovels.aspx?status=3&type=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DType")).Trim();

            HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h4.NavigateUrl = "frmstatusbytype.aspx?status=4&type=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DType")).Trim();

          h4.Text = Convert.ToString( Convert.ToInt32(h2.Text) + Convert.ToInt32(h3.Text));
           // h4.ForeColor = System.Drawing.Color.Black;

           h4.Font.Bold = true;
            //HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
            ////HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            ////HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            //h4.Target = "_blank";
            ////h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            //h4.NavigateUrl = "frmstatusbyApprovels.aspx?status=4&type=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DType")).Trim();
        }

    }
    protected void grdDetails1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h1.NavigateUrl = "frmstatusbytype1.aspx?status=1&type=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DType")).Trim() + "&lbl=Approved Applications";

            HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h2.NavigateUrl = "frmstatusbytype1.aspx?status=2&type=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DType")).Trim() + "&lbl=Applications Under Progress";
            if ((e.Row.Cells[1].Text) == "Beyond time limits")
            {
                h2.ForeColor = System.Drawing.Color.Red;
                h2.Font.Bold= true;
            } 
            HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h3.NavigateUrl = "frmstatusbytype1.aspx?status=3&type=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DType")).Trim() + "&lbl=Rejected Applications";

            HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            //  h4.NavigateUrl = "frmstatusbytype.aspx?status=4&type=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DType")).Trim();

           h4.Text = Convert.ToString(Convert.ToInt32(h1.Text) + Convert.ToInt32(h2.Text) + Convert.ToInt32(h3.Text));
            //// h4.ForeColor = System.Drawing.Color.Black;

            h4.Font.Bold = true;
            //HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
            ////HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            ////HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            //h4.Target = "_blank";
            ////h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h4.NavigateUrl = "frmstatusbytype1.aspx?status=4&type=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DType")).Trim() + "&lbl=Total Approvals";
        }



    }
    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grdDetails3_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=R1: CM's DASHBOARD.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        PrintPDF.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }

    protected void BtnBack_Click1(object sender, EventArgs e)
    {
        string jScript = "<script>window.close();</script>";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "keyClientBlock", jScript);
    }
  
}
