
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
using System.Data.SqlClient;

using System.Xml.Linq;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Globalization;
using System.Text;
using Org.BouncyCastle.OpenSsl;


public partial class UI_TSiPASS_Departmentwiseapprovalstatus : System.Web.UI.Page
{

    decimal totalapplications, Approved, Returned, Pending, SlcApproved;

    string conString = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = DateTime.Now.ToString("dd-MM-yyyy");
        if (!IsPostBack)
        {
            txtFromDate.Text = "15-02-2024";
            txtFromDate.Enabled = false;

            txtTodate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtTodate.Enabled = false;
        }

        DateTime selectedDate = DateTime.Parse(txtTodate.Text);
        // string applicationType = CFO_Dropdown.SelectedItem.Text;

        if (txtTodate.Text != "" && txtFromDate.Text != "")
        { binddata(txtFromDate.Text, txtTodate.Text); }
        //Button3.Enabled = false;
        // CFO_Dropdown.Enabled = false;
    }

    protected void binddata(string fromdate, string todate)
    {
        try
        {

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SP_SVCDEPTPROCESSEDAPPLICATIONS_New", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.Date).Value = Convert.ToDateTime(DateTime.ParseExact(fromdate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.Date).Value = Convert.ToDateTime(DateTime.ParseExact(todate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetails.DataSource = ds;
            grdDetails.DataBind();
            //  Report.Visible = true;
            con.Close();
            grdDetails.Columns[1].Visible = false;
        }
        catch (Exception Ex)
        { throw Ex; }

    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            e.Row.HorizontalAlign = HorizontalAlign.Center;

            decimal totalapplications1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalApplications"));
            totalapplications = totalapplications1 + totalapplications;

            decimal Approved1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Approved"));
            Approved = Approved1 + Approved;

            decimal Returned1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Returned"));
            Returned = Returned1 + Returned;

            decimal Pending1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Pending"));
            Pending = Pending1 + Pending;
            //District=" 

            decimal SlcApproved1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SlcApproved"));
            SlcApproved = SlcApproved1 + SlcApproved;

            HyperLink h1 = (HyperLink)e.Row.Cells[3].Controls[0];
            if (h1.Text != "0")
            {
                h1.NavigateUrl = "DepartmentwiseapprovalstatustotalDrilldown.aspx?DeptId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DeptId")).Trim() + "&status=total";
            }

            HyperLink h2 = (HyperLink)e.Row.Cells[4].Controls[0];
            if (h2.Text != "0")
            {
                h2.NavigateUrl = "DepartmentwiseapprovalstatusDrilldown.aspx?From=" + txtFromDate.Text + "&To=" + txtTodate.Text + "&DeptId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DeptId")).Trim() + "&Approvals=A";
            }

            HyperLink h3 = (HyperLink)e.Row.Cells[5].Controls[0];
            if (h3.Text != "0")
            {
                h3.NavigateUrl = "DepartmentwiseapprovalstatusDrilldown.aspx?From=" + txtFromDate.Text + "&To=" + txtTodate.Text + "&DeptId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DeptId")).Trim() + "&Approvals=R";

            }

            HyperLink h4 = (HyperLink)e.Row.Cells[6].Controls[0];
            if (h4.Text != "0")
            {
                h4.NavigateUrl = "DepartmentwiseapprovalstatustotalDrilldown.aspx?Dept_Id=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DeptId")).Trim() + "&status=pending";

            }

        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            string DeptId = "%";

            e.Row.Cells[2].Text = "Total";



            HyperLink Total = new HyperLink();
            Total.ForeColor = System.Drawing.Color.White;
            Total.NavigateUrl = "DepartmentwiseapprovalstatustotalDrilldown.aspx?DeptId=" + DeptId + "&status=total";
            Total.Text = totalapplications.ToString();
            e.Row.Cells[3].Text = totalapplications.ToString();
            e.Row.Cells[3].Controls.Add(Total);


            HyperLink hplApproved = new HyperLink();
            hplApproved.ForeColor = System.Drawing.Color.White;
            hplApproved.NavigateUrl = "DepartmentwiseapprovalstatusDrilldown.aspx?From=" + txtFromDate.Text + "&To=" + txtTodate.Text + "&DeptId=" + DeptId + "&Approvals=A";
            hplApproved.Text = Approved.ToString();
            e.Row.Cells[4].Text = Approved.ToString();
            e.Row.Cells[4].Controls.Add(hplApproved);


            HyperLink hplReturned = new HyperLink();
            hplReturned.ForeColor = System.Drawing.Color.White;
            hplReturned.NavigateUrl = "DepartmentwiseapprovalstatusDrilldown.aspx?From=" + txtFromDate.Text + "&To=" + txtTodate.Text + "&DeptId=" + DeptId + "&Approvals=R";
            hplReturned.Text = Returned.ToString();
            e.Row.Cells[5].Text = Returned.ToString();
            e.Row.Cells[5].Controls.Add(hplReturned);



            HyperLink hplPending = new HyperLink();
            hplPending.ForeColor = System.Drawing.Color.White;
            hplPending.NavigateUrl = "DepartmentwiseapprovalstatustotalDrilldown.aspx?Dept_Id=" + DeptId + "&status=pending";
            hplPending.Text = Pending.ToString();
            e.Row.Cells[6].Text = Pending.ToString();
            e.Row.Cells[6].Controls.Add(hplPending);

            HyperLink hplSlcApproved = new HyperLink();
            hplSlcApproved.ForeColor = System.Drawing.Color.White;
            hplSlcApproved.NavigateUrl = "DepartmentwiseapprovalstatustotalDrilldown.aspx?Dept_Id=" + DeptId + "&status=SlcApproved";
            hplSlcApproved.Text = SlcApproved.ToString();
            e.Row.Cells[7].Text = SlcApproved.ToString();
            e.Row.Cells[7].Controls.Add(hplSlcApproved);

        }
    }



    protected void Button2_ServerClick(object sender, EventArgs e)
    {
        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                // grdDetails.AllowPaging = false;

                // this.fillgrid();

                grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                grdDetails.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                grdDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
                // grdExport.Columns[1].Visible = false;
                grdDetails.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 30f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter pdfWriter= PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                pdfDoc.Open();
                PdfContentByte cb = pdfWriter.DirectContent;
                cb.BeginText();
                cb.SetFontAndSize(bf, 12);
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Incentive Applications - Department wise status", pdfDoc.PageSize.Width / 2, pdfDoc.PageSize.Height - 20, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "Report Generated On:" + DateTime.Now.ToString("dd / MM / yyyy"), pdfDoc.PageSize.Width / 4, pdfDoc.PageSize.Height - 20, 0);
                
                cb.EndText();
                htmlparser.Parse(sr);
                pdfDoc.Close();

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=:TSiPASS-Incentives Applications- Department Wise Status" + ".pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.Flush();
                Response.End();
            }
        }
    }

   
   
    protected void ExportToExcel1()
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
                Government.Visible = true;
                divPrint1.Style["width"] = "680px";
                Button1.Visible = false;
                Button2.Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                divPrint1.RenderControl(hw);
                string label1text = Label1.Text;
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='5'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='5'><h4>" + label1text + "</h4></td></td></tr></table>";
                HttpContext.Current.Response.Write(headerTable);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
            //Button1.Visible = true;
            //Button2.Visible = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void Button1_ServerClick3(object sender, EventArgs e)
    {
        ExportToExcel1();
    }

    //protected void linkBack_Click(object sender, EventArgs e)
    //{
    //    //NavigateUrl = "~/UI/TSiPASS/ReportsDashboardNew.aspx"
    //}

    protected void HyperLink1_Click(object sender, EventArgs e)
    {

    }
}