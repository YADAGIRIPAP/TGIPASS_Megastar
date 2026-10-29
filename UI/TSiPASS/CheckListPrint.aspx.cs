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
using System.Data.SqlClient;
using System.Globalization;
using Org.BouncyCastle.Asn1.Ocsp;

public partial class UI_TSiPASS_CheckListPrint : System.Web.UI.Page
{
    General gen = new General();
    string Cast = "";
    string Investmentid = "";
    string SubInctypeid = "";
    string rlsproceedNO = "";
    string DIPCFlag = "";
    string WORKINGSTATUS = "";
    string fromdate = "";
    string todate = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                //    string Cast = Request.QueryString["Cast"].ToString();
                //    string Investmentid = Request.QueryString["MstIncentiveId"].ToString();
                //    h1heading.InnerHtml = Cast + " Category";
                //    TXTCHEQUEGENERATEPRINTDATE.Text = Request.QueryString["Date"].ToString();
                //    string SubInctypeid = Request.QueryString["SubIncTypeId"].ToString();
                //    string rlsproceedNO = Request.QueryString["RlsProceedNo"].ToString();
                //    lblRlsProceedNo.Text = rlsproceedNO;
                //    if (rlsproceedNO.Trim().TrimStart() == "0")
                //    {
                //        lblRlsProceedNo.Text = "All";

                //    }
                //    else
                //    {
                //        lblRlsProceedNo.Text = rlsproceedNO;
                //    }
                //    string DIPCFlag = "";
                //    if (Request.QueryString["DIPC"] != null && Request.QueryString["DIPC"].ToString() != "")
                //    {
                //        DIPCFlag = Request.QueryString["DIPC"].ToString();
                //        DIPCFlag = "Y";
                //    }
                //    else
                //    {
                //        DIPCFlag = null;
                //    }
                //    string WORKINGSTATUS = "";

                //    if (Request.QueryString["WORKINGSTATUS"] != null && Request.QueryString["WORKINGSTATUS"].ToString() != "")
                //    {
                //        WORKINGSTATUS = Request.QueryString["WORKINGSTATUS"].ToString();
                //    }

                //    string fromdate = Request.QueryString["FromDate"].ToString();
                //    string todate = Request.QueryString["ToDate"].ToString();

                //    DataSet ds = new DataSet();

                //    SqlParameter[] pp = new SqlParameter[] {
                //    new SqlParameter("@IncentiveTypID",SqlDbType.VarChar),
                //    new SqlParameter("@Cast",SqlDbType.VarChar),
                //    new SqlParameter("@date",SqlDbType.VarChar),
                //    new SqlParameter("@SubIncTypeId",SqlDbType.VarChar),
                //    new SqlParameter("@DIPCFlag",SqlDbType.VarChar),

                //     new SqlParameter("@WORKINGSTATUS",SqlDbType.VarChar),
                //      new SqlParameter("@FromDate",SqlDbType.VarChar),
                //       new SqlParameter("@ToDate",SqlDbType.VarChar)
                //};
                //    pp[0].Value = Investmentid;
                //    pp[1].Value = Cast;
                //    pp[2].Value = rlsproceedNO;
                //    pp[3].Value = SubInctypeid;
                //    pp[4].Value = DIPCFlag;
                //    pp[5].Value = WORKINGSTATUS;
                //    pp[6].Value = fromdate;
                //    pp[7].Value = todate;

                //    ds = gen.GenericFillDs("USP_GET_UNIT_INCENTIVEWISE_CheckLIst", pp);


                //    //  ds = gen.getReleaseProceedingsCheckListprint(Cast, Investmentid, rlsproceedNO, SubInctypeid);
                //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                //    {
                //        tdinvestments.InnerHtml = "--> " + ds.Tables[1].Rows[0]["IncentiveName"].ToString();
                //        grdDetails.DataSource = ds.Tables[0];
                //        grdDetails.DataBind();
                //    }
                bindgrid();
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    public void bindgrid()
    {
        Cast = Request.QueryString["Cast"].ToString();
        Investmentid = Request.QueryString["MstIncentiveId"].ToString();
        h1heading.InnerHtml = Cast + " Category";
        TXTCHEQUEGENERATEPRINTDATE.Text = Request.QueryString["Date"].ToString();
        SubInctypeid = Request.QueryString["SubIncTypeId"].ToString();
        rlsproceedNO = Request.QueryString["RlsProceedNo"].ToString();
        lblRlsProceedNo.Text = rlsproceedNO;
        if (rlsproceedNO.Trim().TrimStart() == "0")
        {
            lblRlsProceedNo.Text = "All";

        }
        else
        {
            lblRlsProceedNo.Text = rlsproceedNO;
        }
        if (Request.QueryString["DIPC"] != null && Request.QueryString["DIPC"].ToString() != "")
        {
            DIPCFlag = Request.QueryString["DIPC"].ToString();
            DIPCFlag = "Y";
        }
        else
        {
            DIPCFlag = null;
        }

        if (Request.QueryString["WORKINGSTATUS"] != null && Request.QueryString["WORKINGSTATUS"].ToString() != "")
        {
            WORKINGSTATUS = Request.QueryString["WORKINGSTATUS"].ToString();
        }

        fromdate = Request.QueryString["FromDate"].ToString();
        todate = Request.QueryString["ToDate"].ToString();

        DataSet ds = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
                new SqlParameter("@IncentiveTypID",SqlDbType.VarChar),
                new SqlParameter("@Cast",SqlDbType.VarChar),
                new SqlParameter("@date",SqlDbType.VarChar),
                new SqlParameter("@SubIncTypeId",SqlDbType.VarChar),
                new SqlParameter("@DIPCFlag",SqlDbType.VarChar),

                 new SqlParameter("@WORKINGSTATUS",SqlDbType.VarChar),
                  new SqlParameter("@FromDate",SqlDbType.VarChar),
                   new SqlParameter("@ToDate",SqlDbType.VarChar)
            };
        pp[0].Value = Investmentid;
        pp[1].Value = Cast;
        pp[2].Value = rlsproceedNO;
        pp[3].Value = SubInctypeid;
        pp[4].Value = DIPCFlag;
        pp[5].Value = WORKINGSTATUS;
        pp[6].Value = fromdate;
        pp[7].Value = todate;

        ds = gen.GenericFillDs("USP_GET_UNIT_INCENTIVEWISE_CheckLIst", pp);


        //  ds = gen.getReleaseProceedingsCheckListprint(Cast, Investmentid, rlsproceedNO, SubInctypeid);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            tdinvestments.InnerHtml = "--> " + ds.Tables[1].Rows[0]["IncentiveName"].ToString();
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
    }

    protected void PrintPdf()
    {
        //try
        //{
        //    using (StringWriter sw = new StringWriter())
        //    {
        //        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
        //        {

        //            grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
        //            grdDetails.HeaderStyle.ForeColor = System.Drawing.Color.Black;

        //            grdDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
        //            grdDetails.FooterStyle.ForeColor = System.Drawing.Color.Black;

        //            // grdExport.Columns[1].Visible = false;
        //            grdDetails.RenderControl(hw);
        //            StringReader sr = new StringReader(sw.ToString());
        //            Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
        //            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //            pdfDoc.Open();
        //            htmlparser.Parse(sr);
        //            pdfDoc.Close();


        //            Response.ContentType = "application/pdf";
        //            Response.AddHeader("content-disposition", "attachment;filename= SLCAgenda.pdf");
        //            Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //            Response.Write(pdfDoc);
        //            Response.Flush();
        //            Response.End();
        //        }
        //    }
        //}
        //catch (Exception ex)
        //{
        //    //lblmsg0.Text = "Internal error has occured. Please try after some time";
        //    lblmsg0.Text = ex.Message;
        //    Failure.Visible = true;
        //}

        try
        {
            bool isAnyRowSelected = false;

            foreach (GridViewRow row in grdDetails.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chkRow");
                if (chk != null && chk.Checked)
                {
                    isAnyRowSelected = true;
                    break;
                }
            }

            if (!isAnyRowSelected)
            {
                lblmsg0.Text = "Please select at least one row to download the PDF.";
                Failure.Visible = true;
                return;
            }

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    foreach (GridViewRow row in grdDetails.Rows)
                    {
                        CheckBox chk = (CheckBox)row.FindControl("chkRow");
                        if (chk != null && !chk.Checked)
                        {
                            row.Visible = false;
                        }
                    }

                    grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                    grdDetails.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());

                    using (MemoryStream ms = new MemoryStream())
                    {
                        Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, ms);
                        pdfDoc.Open();

                        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        htmlparser.Parse(sr);

                        pdfDoc.Close();

                        byte[] file = ms.ToArray();
                        Response.Clear();
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename=SLCAgenda.pdf");
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.BinaryWrite(file);
                        Response.End();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }

    }


    public override void VerifyRenderingInServerForm(Control control)
    {

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            int valid = 0;
            string isDipc = Request.QueryString[5].ToString();
            foreach (GridViewRow gvrow in grdDetails.Rows)
            {
                var checkbox = gvrow.FindControl("chkRow") as CheckBox;
                if (checkbox.Checked)
                {
                    int rowIndex = gvrow.RowIndex;
                    string EnterperIncentiveID = ((Label)gvrow.FindControl("lblEnterperIncentiveID")).Text.ToString();
                    // string[] datett = TXTCHEQUEGENERATEPRINTDATE.Text.Trim().Split('/');
                    //frmvo.Slcdate = datett[2] + "/" + datett[1] + "/" + datett[0];
                    //string ProposedDate = datett[2] + "/" + datett[1] + "/" + datett[0];
                    string ProposedDate = "";
                    if (TXTCHEQUEGENERATEPRINTDATE.Text.Trim().Contains('/'))
                    {
                        string[] datett = TXTCHEQUEGENERATEPRINTDATE.Text.Trim().Split('/');
                        ProposedDate = datett[2] + "/" + datett[1] + "/" + datett[0];
                    }
                    else if (TXTCHEQUEGENERATEPRINTDATE.Text.Trim().Contains('-'))
                    {
                        string[] datett1 = TXTCHEQUEGENERATEPRINTDATE.Text.Trim().Split('-');
                        ProposedDate = datett1[2] + "/" + datett1[1] + "/" + datett1[0];
                    }
                    string MstIncentiveId = ((Label)gvrow.FindControl("lblIncentiveID")).Text.ToString();

                    SqlParameter[] pp = new SqlParameter[] {
                new SqlParameter("@EnterperIncentiveID",SqlDbType.VarChar),
                new SqlParameter("@MstIncentiveId",SqlDbType.VarChar),
                new SqlParameter("@CreatedByid",SqlDbType.VarChar),
                new SqlParameter("@ProposedSVCDate",SqlDbType.VarChar),
                new SqlParameter("@RlsProceedNo",SqlDbType.VarChar),
                new SqlParameter("@Dipc",SqlDbType.VarChar),
                new SqlParameter("@Valid",SqlDbType.Int)
            };
                    pp[0].Value = EnterperIncentiveID;
                    pp[1].Value = MstIncentiveId;
                    pp[2].Value = Session["uid"].ToString();
                    pp[3].Value = ProposedDate;
                    pp[4].Value = lblRlsProceedNo.Text;
                    pp[5].Value = isDipc;
                    pp[6].Direction = ParameterDirection.Output;

                    valid = gen.GenericExecuteNonQuery("USP_UPD_UPDATECHeckLIst_COI", pp);

                    //valid = gen.UpdateincentiveProposedSLCCheckListdate(EnterperIncentiveID, MstIncentiveId, ProposedDate,lblRlsProceedNo.Text, Session["uid"].ToString());
                }
            }
            if (valid == 1)
            {
                string message = "alert('Updated Successfully')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                bindgrid();
                Button6.Visible = true;
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        try
        {
            PrintPdf();
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }

    }


    protected void BtnSave2_Click(object sender, EventArgs e)
    {
        try
        {
            ExportToExcel();
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        foreach (TableCell cell in e.Row.Cells)
        {
            cell.Style.Add("mso-style-parent", "style0");
            cell.Style.Add("mso-number-format", "\\@");
        }
    }


    protected void ExportToExcel()
    {
        try
        {
            Button6.Visible = false;
            Response.Clear();
            Response.Buffer = true;
            string FileName = lblHeading.Text;
            string Grid = "";
            FileName = FileName.Replace(" ", "");
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName + DateTime.Now.ToString("dd/M/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                Government.Visible = true;
                divPrint.Style["width"] = "680px";
                Button1.Visible = false;
                Button2.Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                divPrint.RenderControl(hw);
                string label1text = TXTCHEQUEGENERATEPRINTDATE.Text;
                //Grid = sw.ToString();
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='5'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='5'><h4>" + label1text + "</h4></td></td></tr></table>";
                HttpContext.Current.Response.Write(headerTable);
                Response.Write(@"<style>.text { mso-number-format:\@; } </style>");
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();

            }
            //Button1.Visible = true;
            //Button2.Visible = true;
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
        finally
        {
            Button6.Visible = true;
        }
    }
    protected void ExportToExcel(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=PendingGenerateCheckList.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            Government.Visible = true;
            divPrint.Style["width"] = "680px";
            Button1.Visible = false;
            Button2.Visible = false;
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                grdDetails.AllowPaging = false;

                divPrint.RenderControl(hw);

                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
}