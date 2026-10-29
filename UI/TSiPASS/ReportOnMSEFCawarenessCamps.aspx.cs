using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class UI_TSiPASS_ReportOnMSEFCawarenessCamps : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] == null || Session["uid"].ToString() == "")
        {
            Response.Redirect("~/TSHome.aspx");

        }
        else
        {
            //if (Session["Role_Code"].ToString() == "GM" || Session["Role_Code"].ToString() == "JD")
            if (Session["Role_Code"].ToString() == "GM" || Session["Role_Code"].ToString() == "IPO"
     || Session["Role_Code"].ToString() == "AD" || Session["Role_Code"].ToString() == "DD"
         || Session["Role_Code"].ToString() == "JD")
            {
                if (!IsPostBack)
                {
                    txtfrmdate.Text = "01-10-2023";
                    txttodate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                    binddata(txtfrmdate.Text, txttodate.Text);

                }
            }
            else { Response.Redirect("~/TSHome.aspx"); }
        }

    }
    protected void BtnGetData_Click(object sender, EventArgs e)
    {
        if (txttodate.Text != "" && txtfrmdate.Text != "")
        { binddata(txtfrmdate.Text, txttodate.Text); }

    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {

    }
    protected void binddata(string fromdate, string todate)
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter("GetMSMECampsandCasedetails", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.Date).Value = Convert.ToDateTime(DateTime.ParseExact(fromdate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.Date).Value = Convert.ToDateTime(DateTime.ParseExact(todate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));

            if (Session["Role_Code"].ToString() == "GM")

                da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = Convert.ToString(Session["DistrictID"]);
            else
                da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = "%";
            da.Fill(ds);
            con.CloseConnection();
            //lblForGrid.Visible = true;
            grdsupport.DataSource = ds;
            grdsupport.DataBind();

        }
        catch (Exception Ex)
        { throw Ex; }

    }
    protected void grdsupport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink MSEFCcamps = (HyperLink)e.Row.Cells[2].Controls[0];
            if (MSEFCcamps.Text != "0")
                MSEFCcamps.NavigateUrl = "MSEFCDrilldown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Distid")).Trim() + "& Type=MSEFCcamps" + "& Fromdate="+txtfrmdate.Text +"& Todate="+txttodate.Text;

            HyperLink PaymentIssue = (HyperLink)e.Row.Cells[4].Controls[0];
            if (PaymentIssue.Text != "0")
                PaymentIssue.NavigateUrl = "MSEFCDrilldown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Distid")).Trim() + "& Type=PaymentIssue" + "& Fromdate=" + txtfrmdate.Text + "& Todate=" + txttodate.Text;

            HyperLink Casefiled = (HyperLink)e.Row.Cells[5].Controls[0];
            if (Casefiled.Text != "0")
                Casefiled.NavigateUrl = "MSEFCDrilldown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Distid")).Trim() + "& Type=Casefiled" + "& Fromdate=" + txtfrmdate.Text + "& Todate=" + txttodate.Text;

            
        }
    }
    protected void Button2_ServerClick(object sender, EventArgs e)
    {
        lblHeading.Visible = true;
        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                grdsupport.AllowPaging = false;

                // this.fillgrid();

                grdsupport.HeaderRow.ForeColor = System.Drawing.Color.Black;
                grdsupport.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                grdsupport.FooterRow.ForeColor = System.Drawing.Color.Black;
                // grdExport.Columns[1].Visible = false;
                grdsupport.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=R6.1:TSiPASS-TotalReportold2NewReport" + ".pdf");
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
                grdsupport.Style["width"] = "680px";
                Button1.Visible = false;
                Button2.Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                grdsupport.RenderControl(hw);
                string label1text = lblForGrid.Text;
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='5'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='5'><h4>" + label1text + "</h4></td></td></tr></table>";
                HttpContext.Current.Response.Write(headerTable);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
            //Button1.Visible = true;
            //Button2.Visible = true;
        }
        catch (Exception e)
        {

        }
    }

    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        ExportToExcel();
    }
}