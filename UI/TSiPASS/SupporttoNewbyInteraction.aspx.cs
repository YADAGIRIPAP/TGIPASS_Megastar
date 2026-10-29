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
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text;
//using static TSIPASSPropertiesModel;

public partial class UI_TSiPASS_Reportpage : System.Web.UI.Page
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
        {
            binddata(txtfrmdate.Text, txttodate.Text);

        }

    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UI/TSIPASS/SupporttoNewbyInteraction.aspx");
    }
    protected void binddata(string fromdate, string todate)
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter("sp_NewEntrReport", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.Date).Value = DateTime.ParseExact(fromdate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.Date).Value = DateTime.ParseExact(todate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            if (Session["Role_Code"].ToString() == "GM")
                da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = Session["DistrictId"].ToString();
            else
                da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = "%";
            da.Fill(ds);
            con.CloseConnection();
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
            HyperLink Telponecount = (HyperLink)e.Row.Cells[2].Controls[0];
            if (Telponecount.Text != "0")
                Telponecount.NavigateUrl = "SupporttoNewbyInteractionDrillDown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim() + "& Type=Telephone" + "& From=" + txtfrmdate.Text + "& To=" + txttodate.Text;

            HyperLink physclcount = (HyperLink)e.Row.Cells[3].Controls[0];
            if (physclcount.Text != "0")
                physclcount.NavigateUrl = "SupporttoNewbyInteractionDrillDown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim() + "& Type=Physical" + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text;

            HyperLink maleccount = (HyperLink)e.Row.Cells[4].Controls[0];
            if (maleccount.Text != "0")
                maleccount.NavigateUrl = "SupporttoNewbyInteractionDrillDown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim() + "& Type=Male" + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text;

            HyperLink femaleccount = (HyperLink)e.Row.Cells[5].Controls[0];
            if (femaleccount.Text != "0")
                femaleccount.NavigateUrl = "SupporttoNewbyInteractionDrillDown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim() + "& Type=Female" + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text;

            HyperLink nofpersvitedschms = (HyperLink)e.Row.Cells[6].Controls[0];
            if (nofpersvitedschms.Text != "0")
                nofpersvitedschms.NavigateUrl = "SupporttoNewbyInteractionDrillDown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim() + "& Type=Scheme Yes" + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text;


            HyperLink tringcount = (HyperLink)e.Row.Cells[7].Controls[0];
            if (tringcount.Text != "0")
                tringcount.NavigateUrl = "SupporttoNewbyInteractionDrillDown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim() + "& Type=Trining Yes" + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text;


            HyperLink landcount = (HyperLink)e.Row.Cells[8].Controls[0];
            if (landcount.Text != "0")
                landcount.NavigateUrl = "SupporttoNewbyInteractionDrillDown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim() + "& Type=Land YES" + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text;


            HyperLink otherises = (HyperLink)e.Row.Cells[9].Controls[0];
            if (otherises.Text != "0")
                otherises.NavigateUrl = "SupporttoNewbyInteractionDrillDown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim() + "& Type=Other Issues" + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text;




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
        catch (Exception e)
        {

        }
        // Handle exceptions appropriately, e.g., log or display an error message
    }


    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        ExportToExcel();
    }
}
























