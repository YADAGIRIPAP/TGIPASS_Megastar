using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text;
using System.IO;

public partial class UI_TSiPASS_DepartmentwiseapprovalstatusDrilldown : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count >= 4)
                {
                    
                    string txtFromDate = Request.QueryString[0];
                    string txtTodate = Request.QueryString[1];
                    string DepartmentName = Request.QueryString[2];
                    string Approvals = Request.QueryString[3];
                                     

                    binddata(txtFromDate, txtTodate, DepartmentName, Approvals);

                }

            }

           
        }
        catch (Exception ex) { throw ex; }
    }

    protected void binddata(string txtFromDate, string txtTodate, string DepartmentName, string Approvals)
    {
        try
        {
            DateTime frmdt = Convert.ToDateTime(DateTime.ParseExact(txtFromDate.Trim(), "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
            DateTime todt = Convert.ToDateTime(DateTime.ParseExact(txtTodate.Trim(), "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));

            con.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter("SP_GENERATEAGENDA_DEPARTMENTWISE_Processed_New", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            //da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.Date).Value = Convert.ToDateTime(DateTime.ParseExact(txtFromDate.Trim(), "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
            //da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.Date).Value = Convert.ToDateTime(DateTime.ParseExact(txtTodate.Trim(), "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.Date).Value = frmdt;
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.Date).Value= todt;
            da.SelectCommand.Parameters.Add("@INTUSERID", SqlDbType.VarChar).Value = DepartmentName;
            da.SelectCommand.Parameters.Add("@ProcFlag", SqlDbType.VarChar).Value = Approvals;
                      
            da.Fill(ds);
            lblHeading.Visible = true;

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
              

                if (Approvals == "A")
                {
                    grdDetails.Columns[15].Visible = false;
                    if (DepartmentName == "324563")
                    {
                        lblHeading.Text = "Incentives Applications-TSSPDCL Approved Applications ";

                    }
                    else if (DepartmentName == "324565")
                    {

                        lblHeading.Text = "Incentives Applications-TSNPDCL Approved Applications";
                    }
                    else if (DepartmentName == "324566")
                    {
                        lblHeading.Text = "Incentives Applications-COMMERCIAL Approved Applications ";
                    }

                    else if (DepartmentName == "324567")
                    {
                        lblHeading.Text = "Incentives Applications-TSFC Approved Applications ";
                    }
                    else if (DepartmentName == "324568")
                    {

                        lblHeading.Text = "Incentives Applications-IGRS Approved Applications ";
                    }
                    else if (DepartmentName == "324569")
                    {
                        lblHeading.Text = "Incentives Applications-TSIIC Approved Applications ";
                    }

                    else if (DepartmentName == "324570")
                    {
                        lblHeading.Text = "Incentives Applications-REVENUE Approved Applications ";
                    }

                }
                else // (Approvals == "R")
                {
                    grdDetails.Columns[8].Visible = false;
                    if (DepartmentName == "324563")
                    {
                        lblHeading.Text = "Incentives Applications-TSSPDCL Returned Applications ";
                    }
                    else if (DepartmentName == "324565")
                    {

                        lblHeading.Text = "Incentives Applications-TSNPDCL Returned Applications ";
                    }
                    else if (DepartmentName == "324566")
                    {
                        lblHeading.Text = "Incentives Applications-COMMERCIAL Returned Applications ";
                    }
                    else if (DepartmentName == "324567")
                    {
                        lblHeading.Text = "Incentives Applications-TSFC Returned Applications ";
                    }
                    else if (DepartmentName == "324568")
                    {

                        lblHeading.Text = "Incentives Applications-IGRS Returned Applications ";
                    }
                    else if (DepartmentName == "324569")
                    {
                        lblHeading.Text = "Incentives Applications-TSIIC Returned Applications";
                    }
                    else if (DepartmentName == "324570")
                    {
                        lblHeading.Text = "Incentives Applications-REVENUE Returned Applications ";
                    }
                }

            }
            else
            {
               // Label1.Text = "No Records Found ";

                grdDetails.DataSource = null;
                grdDetails.DataBind();
                //grdDetails.ShowHeaderWhenEmpty = true;

            }
            con.CloseConnection();


        }
        catch (Exception Ex)
        { throw Ex; }


    }
    protected void ExportToExcel()
    {
        try
        {
            lblHeading.Visible = true;
            // grdsupport.Columns[6].Visible = false;
            Response.Clear();
            Response.Buffer = true;
            string FileName = lblHeading.Text;
            FileName = FileName.Replace(" ", "");
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                Government.Visible = true;
                grdDetails.Style["width"] = "680px";
                Button1.Visible = false;
                Button2.Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                grdDetails.RenderControl(hw);
                string label1text = Label1.Text;
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='5'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='5'><h4>" + label1text + "</h4></td></td></tr></table>";
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

    protected void Button2_ServerClick1(object sender, EventArgs e)
    {
        lblHeading.Visible = true;
        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                grdDetails.AllowPaging = false;

                // this.fillgrid();

                grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                grdDetails.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                grdDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
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
                Response.AddHeader("content-disposition", "attachment;filename= Department Wise Approval Progress" + ".pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.Flush();
                Response.End();
            }
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void Button1_ServerClick1(object sender, EventArgs e)
    {
        ExportToExcel();
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink hpViewAppl = (HyperLink)e.Row.Cells[1].Controls[0];
                HyperLink hpAppraisal = (HyperLink)e.Row.Cells[2].Controls[0];
                Label EnterperIncentiveID = (Label)e.Row.Cells[10].FindControl("lblEnterperIncentiveID");
                EnterperIncentiveID.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EnterperIncentiveID")).Trim();
                Label MasterIncentiveID = (Label)e.Row.Cells[11].FindControl("lblIncentiveId");
                MasterIncentiveID.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IncentiveId")).Trim();
                hpAppraisal.Target = "_blank";
                hpAppraisal.NavigateUrl = "appraisalNote2.aspx?incid=" + EnterperIncentiveID.Text + "&mstid=" + MasterIncentiveID.Text;
                hpViewAppl.Target = "_blank";
                hpViewAppl.NavigateUrl = "ApplicantIncentiveDtlsDraftView.aspx?EntrpId=" + EnterperIncentiveID.Text + "&Sts=1";
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
            throw ex;
        }

    }
}