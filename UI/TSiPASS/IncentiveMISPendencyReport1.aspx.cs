using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_IncentiveMISPendencyReport1 : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    General Gen = new General();
    decimal GMAssignW, GMAssignB, GMAssign90, InspAssignW, InspAssingB, InspAssign90, InspUploadW, InspUploadB, InspUpload90, GMtoCOIW, GMtoCOIB, GMtoCOI90,
        Query, Total, Total90, Noofappsfiled, Deemed, WITHINPENDING, BEYONDPENDING, WITHINANDBEYONDTOTAL, IPOqueryatGM, IPOqueryRespncatGM, JDqueryRespncatGM;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {
            BindDistricts();
            if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
            {
                ddlProp_intDistrictid.SelectedValue = Session["DistrictID"].ToString().Trim();
                ddlProp_intDistrictid.Enabled = false;
            }
            else
            {
                ddlProp_intDistrictid.SelectedIndex = 0;
            }
            FillGridDetails();
        }
    }

    public void FillGridDetails()
    {
        try
        {
            DataSet ds = new DataSet();

            ds = GetIncentivesMISPendingReport(ddlProp_intDistrictid.SelectedValue);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }
        }
        catch (Exception ex)
        { LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString()); }
    }
    public DataSet GetIncentivesMISPendingReport(string DISTRICT)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            //da = new SqlDataAdapter("sp_GetDistriciWiseReport", con.GetConnection);
            da = new SqlDataAdapter("USP_GET_INCENTIVEMISPENDINGREPORT_NEW21042025", con.GetConnection);
            if (DISTRICT.Trim() == "" || DISTRICT.Trim() == null || DISTRICT.Trim().ToLower() == "--select--")
                da.SelectCommand.Parameters.Add("@DISTRICT", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@DISTRICT", SqlDbType.VarChar).Value = DISTRICT.ToString();
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.CommandTimeout = 3600;
            da.Fill(ds);
            return ds;


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {


    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal GMAssignW1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "GMInspPendingWithin"));
            GMAssignW = GMAssignW1 + GMAssignW;

            decimal GMAssignB1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "GMInspPendingBeyond"));
            GMAssignB = GMAssignB1 + GMAssignB;

            decimal InspAssignW1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "InspAssignDateWithin"));
            InspAssignW = InspAssignW1 + InspAssignW;

            decimal InspAssingB1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "InspAssignDateBeyond"));
            InspAssingB = InspAssingB1 + InspAssingB;


            decimal InspUploadW1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "InspUploadWithin"));
            InspUploadW = InspUploadW1 + InspUploadW;

            decimal InspUploadB1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "InspUploadBeyond"));
            InspUploadB = InspUploadB1 + InspUploadB;


            decimal GMtoCOIW1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "GMtoCOIWithin"));
            GMtoCOIW = GMtoCOIW1 + GMtoCOIW;

            decimal GMtoCOIB1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "GMtoCOIBeyond"));
            GMtoCOIB = GMtoCOIB1 + GMtoCOIB;

            decimal WITHINANDBEYONDTOTAL1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "WITHINANDBEYONDTOTAL"));
            WITHINANDBEYONDTOTAL = WITHINANDBEYONDTOTAL1 + WITHINANDBEYONDTOTAL;

            decimal Query1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "QueryPendingatApplicant"));
            Query = Query1 + Query;

            //decimal Deemed1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Deemed"));
            //Deemed = Deemed1 + Deemed;

            decimal Total1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalQueryPending"));
            Total = Total1 + Total;



            decimal Noofappsfiled1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NoofClaimsFiled"));
            Noofappsfiled = Noofappsfiled1 + Noofappsfiled;


            // e.Row.Cells[11].BackColor = System.Drawing.Color.Aquamarine;
            // e.Row.Cells[12].BackColor = System.Drawing.Color.Aquamarine;
            e.Row.Cells[13].BackColor = System.Drawing.Color.Aquamarine;
            e.Row.Cells[17].BackColor = System.Drawing.Color.Aquamarine;
            HyperLink hplNoofClaimsFiled = (HyperLink)e.Row.FindControl("hplNoofClaimsFiled");
            hplNoofClaimsFiled.NavigateUrl = "IncentiveMISPendencyReportDrill.aspx?status=P&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink hplGMInspPendingWithin = (HyperLink)e.Row.FindControl("hplGMInspPendingWithin");
            hplGMInspPendingWithin.NavigateUrl = "IncentiveMISPendencyReportDrill.aspx?status=A&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink hplGMInspPendingBeyond = (HyperLink)e.Row.FindControl("hplGMInspPendingBeyond");
            hplGMInspPendingBeyond.NavigateUrl = "IncentiveMISPendencyReportDrill.aspx?status=B&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            //HyperLink h9 = (HyperLink)e.Row.FindControl("HyperLink10");
            //h9.NavigateUrl = "IncentiveMISPendencyReportDrill.aspx?status=C&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink hplInspAssignDateWithin = (HyperLink)e.Row.FindControl("hplInspAssignDateWithin");
            hplInspAssignDateWithin.NavigateUrl = "IncentiveMISPendencyReportDrill.aspx?status=D&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink hplInspAssignDateBeyond = (HyperLink)e.Row.FindControl("hplInspAssignDateBeyond");
            hplInspAssignDateBeyond.NavigateUrl = "IncentiveMISPendencyReportDrill.aspx?status=E&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            //HyperLink h10 = (HyperLink)e.Row.FindControl("hplInspUploadWithin");
            //h10.NavigateUrl = "IncentiveMISPendencyReportDrill.aspx?status=F&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink hplInspUploadWithin = (HyperLink)e.Row.FindControl("hplInspUploadWithin");
            hplInspUploadWithin.NavigateUrl = "IncentiveMISPendencyReportDrill.aspx?status=G&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink hplInspUploadBeyond = (HyperLink)e.Row.FindControl("hplInspUploadBeyond");
            hplInspUploadBeyond.NavigateUrl = "IncentiveMISPendencyReportDrill.aspx?status=H&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            //HyperLink h11 = (HyperLink)e.Row.FindControl("HyperLink12");
            //h11.NavigateUrl = "IncentiveMISPendencyReportDrill.aspx?status=I&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink hplGMtoCOIWithin = (HyperLink)e.Row.FindControl("hplGMtoCOIWithin");
            hplGMtoCOIWithin.NavigateUrl = "IncentiveMISPendencyReportDrill.aspx?status=J&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink hplGMtoCOIBeyond = (HyperLink)e.Row.FindControl("hplGMtoCOIBeyond");
            hplGMtoCOIBeyond.NavigateUrl = "IncentiveMISPendencyReportDrill.aspx?status=K&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            //HyperLink h12 = (HyperLink)e.Row.FindControl("HyperLink13");
            //h12.NavigateUrl = "IncentiveMISPendencyReportDrill.aspx?status=L&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink hplQueryPending = (HyperLink)e.Row.FindControl("hplQueryPending");
            hplQueryPending.NavigateUrl = "IncentiveMISPendencyReportDrill.aspx?status=M&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink hplTotalPending = (HyperLink)e.Row.FindControl("hplTotalPending");
            hplTotalPending.NavigateUrl = "IncentiveMISPendencyReportDrill.aspx?status=N&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            //HyperLink h15 = (HyperLink)e.Row.FindControl("HyperLink16");
            //h15.NavigateUrl = "IncentiveMISPendencyReportDrill.aspx?status=O&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();


            //HyperLink h17 = (HyperLink)e.Row.FindControl("HyperLink17");
            //h17.NavigateUrl = "IncentiveMISPendencyReportDrill.aspx?status=Q&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink hplWITHINPENDING = (HyperLink)e.Row.FindControl("hplWITHINPENDING");
            WITHINPENDING = WITHINPENDING + Convert.ToDecimal(hplWITHINPENDING.Text);

            HyperLink hplBEYONDPENDING = (HyperLink)e.Row.FindControl("hplBEYONDPENDING");
            BEYONDPENDING = BEYONDPENDING + Convert.ToDecimal(hplBEYONDPENDING.Text);

            HyperLink hplIPOqryRaisedbtGMnoaction = (HyperLink)e.Row.FindControl("hplIPOqryRaisedbtGMnoaction");
            IPOqueryatGM = IPOqueryatGM + Convert.ToDecimal(hplIPOqryRaisedbtGMnoaction.Text);

            HyperLink hplApplrespondedtoIPOqrybtGMNoaction = (HyperLink)e.Row.FindControl("hplApplrespondedtoIPOqrybtGMNoaction");
            IPOqueryRespncatGM = IPOqueryRespncatGM + Convert.ToDecimal(hplApplrespondedtoIPOqrybtGMNoaction.Text);

            HyperLink hplApplrespondedtoJDqrybtGMNoaction = (HyperLink)e.Row.FindControl("hplApplrespondedtoJDqrybtGMNoaction");
            JDqueryRespncatGM = JDqueryRespncatGM + Convert.ToDecimal(hplApplrespondedtoJDqrybtGMNoaction.Text);

        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total";
            Label lblNoofClaimsFiled = (Label)e.Row.FindControl("lblNoofClaimsFiled");
            lblNoofClaimsFiled.Text = Noofappsfiled.ToString();

            Label lblGMInspPendingWithin = (Label)e.Row.FindControl("lblGMInspPendingWithin");
            lblGMInspPendingWithin.Text = GMAssignW.ToString();

            Label lblGMInspPendingBeyond = (Label)e.Row.FindControl("lblGMInspPendingBeyond");
            lblGMInspPendingBeyond.Text = GMAssignB.ToString();

            Label lblInspAssignDateWithin = (Label)e.Row.FindControl("lblInspAssignDateWithin");
            lblInspAssignDateWithin.Text = InspAssignW.ToString();

            Label lblInspAssignDateBeyond = (Label)e.Row.FindControl("lblInspAssignDateBeyond");
            lblInspAssignDateBeyond.Text = InspAssingB.ToString();

            Label lblInspUploadWithin = (Label)e.Row.FindControl("lblInspUploadWithin");
            lblInspUploadWithin.Text = InspUploadW.ToString();

            Label lblInspUploadBeyond = (Label)e.Row.FindControl("lblInspUploadBeyond");
            lblInspUploadBeyond.Text = InspUploadB.ToString();


            Label lblGMtoCOIWithin = (Label)e.Row.FindControl("lblGMtoCOIWithin");
            lblGMtoCOIWithin.Text = GMtoCOIW.ToString();

            Label lblGMtoCOIBeyond = (Label)e.Row.FindControl("lblGMtoCOIBeyond");
            lblGMtoCOIBeyond.Text = GMtoCOIB.ToString();

            Label lblQueryPending = (Label)e.Row.FindControl("lblQueryPending");
            lblQueryPending.Text = Query.ToString();

            Label lblWITHINPENDING = (Label)e.Row.FindControl("lblWITHINPENDING");
            lblWITHINPENDING.Text = WITHINPENDING.ToString();

            Label lblBEYONDPENDING = (Label)e.Row.FindControl("lblBEYONDPENDING");
            lblBEYONDPENDING.Text = BEYONDPENDING.ToString();

            Label lblWITHINANDBEYONDTOTAL = (Label)e.Row.FindControl("lblWITHINANDBEYONDTOTAL");
            lblWITHINANDBEYONDTOTAL.Text = WITHINANDBEYONDTOTAL.ToString();


            Label lblTotalPending = (Label)e.Row.FindControl("lblTotalPending");
            lblTotalPending.Text = (IPOqueryatGM + IPOqueryRespncatGM + JDqueryRespncatGM ).ToString();


            Label lblIPOqryRaisedbtGMnoaction = (Label)e.Row.FindControl("lblIPOqryRaisedbtGMnoaction");
            lblIPOqryRaisedbtGMnoaction.Text = Convert.ToString(IPOqueryatGM);
            Label lblApplrespondedtoIPOqrybtGMNoaction = (Label)e.Row.FindControl("lblApplrespondedtoIPOqrybtGMNoaction");
            lblApplrespondedtoIPOqrybtGMNoaction.Text = Convert.ToString(IPOqueryRespncatGM);
            Label lblApplrespondedtoJDqrybtGMNoaction = (Label)e.Row.FindControl("lblApplrespondedtoJDqrybtGMNoaction");
            lblApplrespondedtoJDqrybtGMNoaction.Text = Convert.ToString(JDqueryRespncatGM);


        }
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header)
        {

            GridView HeaderGrid = (GridView)sender;

            GridViewRow HeaderGridRow = new GridViewRow(1, 2, DataControlRowType.Header, DataControlRowState.Insert);
            HeaderGridRow.HorizontalAlign = HorizontalAlign.Center;

            TableCell tcMergePackagei = new TableCell();
            tcMergePackagei.Text = "";
            tcMergePackagei.ColumnSpan = 3;
            HeaderGridRow.Cells.Add(tcMergePackagei);

            TableCell tcMergePackage = new TableCell();
            tcMergePackage.Text = "Pending claims to Assign for Inspecting officer by GM";
            tcMergePackage.HorizontalAlign = HorizontalAlign.Center;
            tcMergePackage.ColumnSpan = 2;
            HeaderGridRow.Cells.Add(tcMergePackage);


            TableCell tcMergePackage1 = new TableCell();
            tcMergePackage1.Text = "Pending at Inspecting Officer to Schedule Inspection Date";
            tcMergePackage1.HorizontalAlign = HorizontalAlign.Center;
            tcMergePackage1.ColumnSpan = 2;
            HeaderGridRow.Cells.Add(tcMergePackage1);

            TableCell tcMergePackage2 = new TableCell();
            tcMergePackage2.Text = "Pending to Upload Inspection Report by Inspecting Officer";
            tcMergePackage2.HorizontalAlign = HorizontalAlign.Center;
            tcMergePackage2.ColumnSpan = 2;
            HeaderGridRow.Cells.Add(tcMergePackage2);

            TableCell tcMergePackage20 = new TableCell();
            tcMergePackage20.Text = "Pending to Forward to COI/DIPC";
            tcMergePackage20.HorizontalAlign = HorizontalAlign.Center;
            tcMergePackage20.ColumnSpan = 2;
            HeaderGridRow.Cells.Add(tcMergePackage20);


            TableCell tcMergePackageT = new TableCell();
            tcMergePackageT.Text = "Total Applications Pending at District Level";
            tcMergePackageT.HorizontalAlign = HorizontalAlign.Center;
            tcMergePackageT.ColumnSpan = 3;
            HeaderGridRow.Cells.Add(tcMergePackageT);

            TableCell tcMergePackage4 = new TableCell();
            tcMergePackage4.Text = "Queries Pending at District level";
            tcMergePackage4.HorizontalAlign = HorizontalAlign.Center;
            tcMergePackage4.ColumnSpan = 4;
            HeaderGridRow.Cells.Add(tcMergePackage4);

            TableCell tcMergePackageF = new TableCell();
            tcMergePackageF.Text = "";
            tcMergePackageF.ColumnSpan = 1;
            tcMergePackageF.RowSpan = 2;
            tcMergePackageF.HorizontalAlign = HorizontalAlign.Center;
            HeaderGridRow.Cells.Add(tcMergePackageF);

            grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);
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

    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        PrintPdf();
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


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillGridDetails();
    }
}