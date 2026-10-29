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
using System.Text;

using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Data.SqlClient;


public partial class UI_TSiPASS_frmGMDelayReasonReportCOI : System.Web.UI.Page
{
    General Gen = new General();
    int valid = 0;
    string FromdateforDB = "", TodateforDB = "";

    decimal within, beyond, totalexplaination, explainationaccepted, explainationnotaccepted, showcausereplied, pendingataddl, pendingatgm,explanationgiven;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {
            BindDistricts();
            txtFromDate.Text = "01-03-2020";
            DateTime today = DateTime.Today;
            txtTodate.Text = today.ToString("dd-MM-yyyy");
            if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
            {
                ddlProp_intDistrictid.SelectedValue = Session["DistrictID"].ToString().Trim();
                ddlProp_intDistrictid.Enabled = false;
            }
            else
            {
                ddlProp_intDistrictid.SelectedIndex = 0;
            }
            fillgrid();
            Label3.Text = "Report as on date " + DateTime.Now;
        }
    }

    public void BindDistricts()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlProp_intDistrictid.Items.Clear();
            dsd = Gen.GetDistrictsWithoutHYD();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlProp_intDistrictid.DataSource = dsd.Tables[0];
                ddlProp_intDistrictid.DataValueField = "District_Id";
                ddlProp_intDistrictid.DataTextField = "District_Name";
                ddlProp_intDistrictid.DataBind();
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("--All--", "%");
                ddlProp_intDistrictid.Items.Insert(0, li);
            }
            else
            {
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("--All--", "%");
                ddlProp_intDistrictid.Items.Insert(0, li);
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }

    public void fillgrid()
    {
        DataSet dsnew = new DataSet();
        string ReleaseProceedingNo = "";
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
        dsnew = GetGMDelayApplications(FromdateforDB, TodateforDB, ddlProp_intDistrictid.SelectedValue, "");
        // lblMsg.Text = "";
        if (dsnew.Tables[0].Rows.Count > 0)
        {
            // lblMsg.Text = "Total Records :" +dsnew.Tables[0].Rows.Count.ToString();
            grdDetails.DataSource = dsnew.Tables[0];
            grdDetails.DataBind();
            //bindgrdDetailsfooter(dsnew.Tables[0]);
        }
        else
        {
            //lblMsg.Text = "";
            // Label1.Text = "No Recards Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {


    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //decimal within, beyond, totalexplaination, explainationaccepted, explainationnotaccepted, showcausereplied, pendingataddl, pendingatgm;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal within1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "WITHINTIMELIMITS"));
            within = within1 + within;

            decimal beyond1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "BEYONDTIMELIMITS"));
            beyond = beyond1 + beyond;

            decimal totalexplaination1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFDELAYAPP"));
            totalexplaination = totalexplaination1 + totalexplaination;

            decimal explainationaccepted1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NODELAYRESONACCEPTED"));
            explainationaccepted = explainationaccepted1 + explainationaccepted;

            decimal explainationnotaccepted1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NODELAYREASONNOTACCEPTED"));
            explainationnotaccepted = explainationnotaccepted1 + explainationnotaccepted;

            decimal showcausereplied1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFSHOWCAUSEREPLIED"));
            showcausereplied = showcausereplied1 + showcausereplied;

            decimal pendingataddl1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFDELAYPENDING"));
            pendingataddl = pendingataddl1 + pendingataddl;


            decimal pendingatgm1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFSHOWCAUSENOTREPLIED"));
            pendingatgm = pendingatgm1 + pendingatgm;


            decimal explanationgiven1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFEXPLAINATION"));
            explanationgiven = explanationgiven1 + explanationgiven;



            HyperLink h9 = (HyperLink)e.Row.FindControl("HyNONOOFEXPLAINATION");
            h9.NavigateUrl = "frmGMDelayResonseDrillDownCOI.aspx?district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&StatusFlag=9";

            HyperLink h7 = (HyperLink)e.Row.FindControl("HyNOOFWITHINTIMELIMITS");
            h7.NavigateUrl = "frmGMDelayResonseDrillDownCOI.aspx?district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&StatusFlag=1";

            HyperLink h8 = (HyperLink)e.Row.FindControl("HyNOOFBEYONDTIMELIMITS");
            h8.NavigateUrl = "frmGMDelayResonseDrillDownCOI.aspx?district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&StatusFlag=2";


            HyperLink h1 = (HyperLink)e.Row.FindControl("HyNOOFDELAYAPP");
            h1.NavigateUrl = "frmGMDelayResonseDrillDownCOI.aspx?district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&StatusFlag=3";

           

            HyperLink h3 = (HyperLink)e.Row.FindControl("HyNODELAYRESONACCEPTED");
            h3.NavigateUrl = "frmGMDelayResonseDrillDownCOI.aspx?district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&StatusFlag=4";

            HyperLink H4 = (HyperLink)e.Row.FindControl("HyNODELAYREASONNOTACCEPTED");
            H4.NavigateUrl = "frmGMDelayResonseDrillDownCOI.aspx?district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&StatusFlag=5";

            HyperLink h5 = (HyperLink)e.Row.FindControl("HyNOOFSHOWCAUSEREPLIED");
            h5.NavigateUrl = "frmGMDelayResonseDrillDownCOI.aspx?district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&StatusFlag=6";


            HyperLink h2 = (HyperLink)e.Row.FindControl("HyNOOFDELAYPENDING");
            h2.NavigateUrl = "frmGMDelayResonseDrillDownCOI.aspx?district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&StatusFlag=7";

            HyperLink h6 = (HyperLink)e.Row.FindControl("HyNOOFSHOWCAUSENOTREPLIED");
            h6.NavigateUrl = "frmGMDelayResonseDrillDownCOI.aspx?district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&StatusFlag=8";




            //HyperLink h2 = (HyperLink)e.Row.FindControl("HyperLink2");
            //h2.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=AD&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim();

            //HyperLink h3 = (HyperLink)e.Row.FindControl("HyperLink3");
            //h3.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=DD&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim();

            //HyperLink h4 = (HyperLink)e.Row.FindControl("HyperLink10");
            //h4.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=GM&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim();


        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
             //decimal within, beyond, totalexplaination, explainationaccepted, explainationnotaccepted, showcausereplied, pendingataddl, pendingatgm;
            e.Row.Cells[1].Text = "Total";

            HyperLink withintotal = new HyperLink();
            withintotal.Text = within.ToString();
            e.Row.Cells[2].Text = within.ToString();
            e.Row.Cells[2].Controls.Add(withintotal);
            //withintotal.NavigateUrl = "frmGMDelayResonseDrillDownCOI.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&StatusFlag=1";
            withintotal.NavigateUrl = "frmGMDelayResonseDrillDownCOI.aspx?district=ALL"+ "&StatusFlag=1";
            withintotal.ForeColor = System.Drawing.Color.White;

            HyperLink  beyondtotal= new HyperLink();
            beyondtotal.Text = beyond.ToString();
            e.Row.Cells[3].Text = beyond.ToString();
            e.Row.Cells[3].Controls.Add(beyondtotal);
            //withintotal.NavigateUrl = "frmGMDelayResonseDrillDownCOI.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&StatusFlag=1";
            beyondtotal.NavigateUrl = "frmGMDelayResonseDrillDownCOI.aspx?district=ALL" + "&StatusFlag=2";
            beyondtotal.ForeColor = System.Drawing.Color.White;

            HyperLink  totalexplainationtotal= new HyperLink();
            totalexplainationtotal.Text = totalexplaination.ToString();
            e.Row.Cells[4].Text = totalexplaination.ToString();
            e.Row.Cells[4].Controls.Add(totalexplainationtotal);
            //withintotal.NavigateUrl = "frmGMDelayResonseDrillDownCOI.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&StatusFlag=1";
            totalexplainationtotal.NavigateUrl = "frmGMDelayResonseDrillDownCOI.aspx?district=ALL" + "&StatusFlag=3";
            totalexplainationtotal.ForeColor = System.Drawing.Color.White;

            HyperLink pendingataddltotal = new HyperLink();
            pendingataddltotal.Text = pendingataddl.ToString();
            e.Row.Cells[8].Text = pendingataddl.ToString();
            e.Row.Cells[8].Controls.Add(pendingataddltotal);
            //withintotal.NavigateUrl = "frmGMDelayResonseDrillDownCOI.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&StatusFlag=1";
            pendingataddltotal.NavigateUrl = "frmGMDelayResonseDrillDownCOI.aspx?district=ALL" + "&StatusFlag=7";
            pendingataddltotal.ForeColor = System.Drawing.Color.White;


            HyperLink  explainationacceptedtotal= new HyperLink();
            explainationacceptedtotal.Text = explainationaccepted.ToString();
            e.Row.Cells[6].Text = explainationaccepted.ToString();
            e.Row.Cells[6].Controls.Add(explainationacceptedtotal);
            //withintotal.NavigateUrl = "frmGMDelayResonseDrillDownCOI.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&StatusFlag=1";
            explainationacceptedtotal.NavigateUrl = "frmGMDelayResonseDrillDownCOI.aspx?district=ALL" + "&StatusFlag=4";
            explainationacceptedtotal.ForeColor = System.Drawing.Color.White;

            HyperLink explainationnotacceptedtotal = new HyperLink();
            explainationnotacceptedtotal.Text = explainationnotaccepted.ToString();
            e.Row.Cells[7].Text =explainationnotaccepted .ToString();
            e.Row.Cells[7].Controls.Add(explainationnotacceptedtotal);
            //withintotal.NavigateUrl = "frmGMDelayResonseDrillDownCOI.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&StatusFlag=1";
            explainationnotacceptedtotal.NavigateUrl = "frmGMDelayResonseDrillDownCOI.aspx?district=ALL" + "&StatusFlag=5";
            explainationnotacceptedtotal.ForeColor = System.Drawing.Color.White;

            HyperLink explanationgiventotal = new HyperLink();
            explanationgiventotal.Text = explanationgiven.ToString();
            e.Row.Cells[5].Text = explanationgiven.ToString();
            e.Row.Cells[5].Controls.Add(explanationgiventotal);
            //withintotal.NavigateUrl = "frmGMDelayResonseDrillDownCOI.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&StatusFlag=1";
            explanationgiventotal.NavigateUrl = "frmGMDelayResonseDrillDownCOI.aspx?district=ALL" + "&StatusFlag=9";
            explanationgiventotal.ForeColor = System.Drawing.Color.White;

            HyperLink showcauserepliedtotal  = new HyperLink();
            showcauserepliedtotal.Text = showcausereplied.ToString();
            e.Row.Cells[9].Text = showcausereplied.ToString();
            e.Row.Cells[9].Controls.Add(showcauserepliedtotal);
            //withintotal.NavigateUrl = "frmGMDelayResonseDrillDownCOI.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&StatusFlag=1";
            showcauserepliedtotal.NavigateUrl = "frmGMDelayResonseDrillDownCOI.aspx?district=ALL" + "&StatusFlag=6";
            showcauserepliedtotal.ForeColor = System.Drawing.Color.White;

            

            HyperLink pendingatgmtotal = new HyperLink();
            pendingatgmtotal.Text = pendingatgm.ToString();
            e.Row.Cells[10].Text = pendingatgm.ToString();
            e.Row.Cells[10].Controls.Add(pendingatgmtotal);
            //withintotal.NavigateUrl = "frmGMDelayResonseDrillDownCOI.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&StatusFlag=1";
            pendingatgmtotal.NavigateUrl = "frmGMDelayResonseDrillDownCOI.aspx?district=ALL" + "&StatusFlag=8";
            pendingatgmtotal.ForeColor = System.Drawing.Color.White;

            
        }
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
            string FileName = lblHeading.Text;
            FileName = FileName.Replace(" ", "");
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                grdDetails.RenderControl(hw);

                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='6'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='6'></td></td></tr></table>";
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
                    Response.AddHeader("content-disposition", "attachment;filename= GMExplanation Report.pdf");
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

    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        //string status = Request.QueryString[0].ToString().Trim();
        //DataSet ds = new DataSet();
        //string input, financial, fromdate, todate;
        //input = rbtnlstInputType.SelectedValue.ToString().Trim();
        //financial = ddlFinancialYear.SelectedValue.ToString().Trim();
        //fromdate = txtFromDate.Text;
        //todate = txtTodate.Text;
        //ds = Gen.getR1DrildownbyidfinNew(status, ddlCategory.SelectedItem.Text, ddldistrict.SelectedValue, input, financial, fromdate, todate);

        //if (ds != null && ds.Tables[0].Rows.Count > 0)
        //{
        //    Label1.Text = "Report from 1st April 2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
        //    ds.Tables[0].Columns.Remove("DOA");
        //    grdDetails.DataSource = ds.Tables[0];
        //    grdDetails.DataBind();
        //}
        //else
        //{
        //    Label1.Text = "No Records Found ";
        //    grdDetails.DataSource = ds.Tables[0];
        //    grdDetails.DataBind();
        //}
        int valid = 0;
        lblmsg0.Text = "";
        Failure.Visible = false;
        //if (rbtnlstInputType.SelectedValue == "N")
        //{
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
        //}
        //else
        //{
        //    if (ddlFinancialYear.SelectedItem.ToString() == "--Select--")
        //    {
        //        lblmsg0.Text = "Please Select Financial Year";
        //        valid = 1;
        //    }
        //}
        if (valid == 0)
        {
            fillgrid();
        }
        else
        {
            Failure.Visible = true;
        }
    }

    public DataSet GetGMDelayApplications(string fromdate, string todate, string districtid, string designation)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
             new SqlParameter("@FromDate",SqlDbType.VarChar),
                new SqlParameter("@ToDate",SqlDbType.VarChar),
               new SqlParameter("@DISTRICTID",SqlDbType.VarChar),
                new SqlParameter("@DESIGNATION",SqlDbType.VarChar)
               
           };
        pp[0].Value = fromdate;
        pp[1].Value = todate;
        pp[2].Value = districtid;
        pp[3].Value = designation;


        Dsnew = Gen.GenericFillDs("USP_GET_GMEXPLAINATION_DETAILS_COI", pp);
        return Dsnew;
    }
}