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

public partial class UI_TSiPASS_TsipassFeedbackRpt : System.Web.UI.Page
{
    General Gen = new General();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");

        }

    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
               
    }

    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        int valid = 0;
        lblmsg0.Text = "";
        Failure.Visible = false;
        string FromdateforDB = "", TodateforDB = "";

        if (txtFromDate.Text == "" || txtFromDate.Text == null)
        {
            lblmsg0.Text = "Please Enter From Date <br/>";
            valid = 1;
        }
        if (txtTodate.Text == "" || txtTodate.Text == null)
        {
            lblmsg0.Text += "Please Enter To Date <br/>";
            valid = 1;
        }
        if (valid == 0)
        {
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        }

        if (valid == 0)
        {
            FillGridDetails(FromdateforDB, TodateforDB);
        }
        else
        {
            Failure.Visible = true;
        }
    }

    public void FillGridDetails(string fromdate, string todate)
    {
        lblmsg0.Text = "";
        DataSet ds = new DataSet();
        ds = Gen.GetTsipassFeedbackCount(fromdate, todate);
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
            }

            Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
        }

        else
        {
            lblmsg0.Text = "No Records Found ";
            Failure.Visible = true;
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
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
            Response.AddHeader("content-disposition", "attachment;filename=R1.1Abstract-FinancialYearwise" + DateTime.Now.ToString("MM-dd-yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                div_Print.RenderControl(hw);

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


    protected void grdDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblmsg0.Text = "";
        if (e.CommandName == "PostAppln")
        {
            DataSet ds = new DataSet();
            grdDetails2.DataSource = null;
            grdDetails2.DataBind();
            ds = Gen.GETPostApplnTotalDtls("PostAppln");
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdDetails2.DataSource = ds;
                    grdDetails2.DataBind();
                    lblgrdDetails2.Text = "Post Application Details";
                }
                else
                {
                    lblmsg0.Text = "No Records Found ";
                    Failure.Visible = true;
                    grdDetails.DataSource = null;
                    grdDetails.DataBind();
                }
            }
        }
        if (e.CommandName == "PostCertificate")
        {
            DataSet ds3 = new DataSet();
            grdDetails2.DataSource = null;
            grdDetails2.DataBind();
            ds3 = Gen.GETPostApplnTotalDtls("PostCertificate");
            grdDetails2.DataSource = ds3;
            grdDetails2.DataBind();
            lblgrdDetails2.Text = "Post Download Certificate Details";
        }

        //if (e.CommandName == "Total")
        //{
        //    DataSet ds3 = new DataSet();
        //    grdDetails2.DataSource = null;
        //    grdDetails2.DataBind();
        //    ds3 = Gen.GETPostApplnTotalDtls("Total");
        //    grdDetails2.DataSource = ds3;
        //    grdDetails2.DataBind();
        //   lblgrdDetails2.Text = "Total Application Details";
        //}    

    }

    protected void grdDetails2_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
       
    }

    protected void grdDetails2_RowDataBound(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void btnprocess_Click(object sender, EventArgs e)
    {          
        int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
        Label POSTAPPLNSLNO = ((Label)grdDetails2.Rows[indexing].FindControl("lblPOSTAPPLNSLNO"));  // lblPOSTAPPLNSLNO
        if (lblgrdDetails2.Text == "Post Application Details")
        {
            Response.Redirect("~/UI/TSiPASS/TSipassfeedbackPostApplnDraft.aspx?postapplslno=" + POSTAPPLNSLNO.Text);
        }
        else if (lblgrdDetails2.Text == "Post Download Certificate Details")
        {
            Response.Redirect("~/UI/TSiPASS/TSipassfeedbackPostCertificateDraft.aspx?postapplslno=" + POSTAPPLNSLNO.Text);
        }
    }

    protected void btnclear_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UI/TSiPASS/TsipassFeedbackRpt.aspx");
    }
}