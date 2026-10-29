using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class UI_TSiPASS_FeedbackRptNew : System.Web.UI.Page
{
    General Gen = new General();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["uid"] != null)
                {
                    FillGridDetails();
                }
                else
                {
                    Response.Redirect("~/tshome.aspx");
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        FillGridDetails();

    }

    public void FillGridDetails()
    {
       // lblmsg0.Text = "";
        DataSet ds = new DataSet();
        ds = Gen.GetFeedbackRptRestrospectiveCount();
        Session["ds"] = "";
        Session["ds"] = ds;
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                ViewState["grdDetails"] = "";
                ViewState["grdDetails"] = ds;

                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                ViewState["grdDetails2"] = "";
                ViewState["grdDetails2"] = ds;

                GridView2.DataSource = ds.Tables[1];
                GridView2.DataBind();
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                ViewState["grdDetails3"] = "";
                ViewState["grdDetails3"] = ds;

                GridView3.DataSource = ds.Tables[2];
                GridView3.DataBind();
            }

        }

        else
        {
            //lblmsg0.Text = "No Records Found ";
            //Failure.Visible = true;
            GridView1.DataSource = null;
            GridView1.DataBind();

            GridView2.DataSource = null;
            GridView2.DataBind();

            GridView3.DataSource = null;
            GridView3.DataBind();
        }
    }

    protected void BtnSave2_Click(object sender, EventArgs e)
    {
        ExportToExcel();

    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    protected void ExportToExcel()
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            string FileName = Label1.Text;
            FileName = FileName.Replace(" ", "");
            Response.AddHeader("content-disposition", "attachment;filename=" + "R16.FeedbackReport" + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                GridView1.RenderControl(hw);


                string label1text = Label1.Text;
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='6'><h4>" + "R16.FeedbackReport" + "</h4></td></td></tr><tr><td align='center' colspan='6'><h4>" + label1text + "</h4></td></td></tr></table>";
                HttpContext.Current.Response.Write(headerTable);

                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }


        }
        catch (Exception e)
        {
            throw e;
        }
    }


    protected void grdDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {



    }

    protected void btnclear_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UI/TSiPASS/FeedbackRptNew.aspx");
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void lnkbtnSMSSent_Click(object sender, EventArgs e)
    {
        var closeLink = (Control)sender;
        GridViewRow row = (GridViewRow)closeLink.NamingContainer;
        Label lblValue = (Label)row.FindControl("lblApprovalId");
        string id = lblValue.Text;

        Response.Redirect("~/UI/TSIPASS/frmFeedbackReport.aspx?status=SMS&ApprovalId="+id.ToString()+"");      

    }

    protected void lnkbtnFbkRcvd_Click(object sender, EventArgs e)
    {
        var closeLink = (Control)sender;
        GridViewRow row = (GridViewRow)closeLink.NamingContainer;
        Label lblValue = (Label)row.FindControl("lblApprovalId");
        string id = lblValue.Text;

        Response.Redirect("~/UI/TSIPASS/frmFeedbackReport.aspx?status=FBK&ApprovalId=" + id.ToString() + "");    
    }

    
    protected void lnkbtnSMSSentCFO_Click(object sender, EventArgs e)
    {
        var closeLink = (Control)sender;
        GridViewRow row = (GridViewRow)closeLink.NamingContainer;
        Label lblValue = (Label)row.FindControl("lblApprovalId");
        string id = lblValue.Text;

        Response.Redirect("~/UI/TSIPASS/frmFeedbackReport.aspx?status=SMSCFO&ApprovalId=" + id.ToString() + "");

    }

    protected void lnkbtnFbkRcvdCFO_Click(object sender, EventArgs e)
    {
        var closeLink = (Control)sender;
        GridViewRow row = (GridViewRow)closeLink.NamingContainer;
        Label lblValue = (Label)row.FindControl("lblApprovalId");
        string id = lblValue.Text;

        Response.Redirect("~/UI/TSIPASS/frmFeedbackReport.aspx?status=FBKCFO&ApprovalId=" + id.ToString() + "");
    }


    //Incentives retrospective
    protected void lnkbtnSMSSentINC_Click(object sender, EventArgs e)
    {
        var closeLink = (Control)sender;
        GridViewRow row = (GridViewRow)closeLink.NamingContainer;
        Label lblValue = (Label)row.FindControl("lblApprovalId");
        string id = lblValue.Text;

        Response.Redirect("~/UI/TSIPASS/frmFeedbackReport.aspx?status=SMSINC&ApprovalId=" + id.ToString() + "");

    }

    protected void lnkbtnFbkRcvdINC_Click(object sender, EventArgs e)
    {
        var closeLink = (Control)sender;
        GridViewRow row = (GridViewRow)closeLink.NamingContainer;
        Label lblValue = (Label)row.FindControl("lblApprovalId");
        string id = lblValue.Text;

        Response.Redirect("~/UI/TSIPASS/frmFeedbackReport.aspx?status=FBKINC&ApprovalId=" + id.ToString() + "");
    }

}