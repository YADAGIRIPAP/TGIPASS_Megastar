using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Windows.Forms;

public partial class UI_TSiPASS_SupporttoNewEntrepreneurs : System.Web.UI.Page
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
        { binddata(txtfrmdate.Text, txttodate.Text); }

    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UI/TSIPASS/SupporttoNewEntrepreneurs.aspx");
    }
    protected void binddata(string fromdate, string todate)
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter("USP_GetSupportForEntrepreneur", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.Date).Value = DateTime.ParseExact(fromdate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.Date).Value = DateTime.ParseExact(todate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            da.SelectCommand.Parameters.Add("@SupportType", SqlDbType.VarChar).Value = "New";
            if (Session["Role_Code"].ToString() == "JD")
            {
                da.SelectCommand.Parameters.Add("@DISTRICTID", SqlDbType.VarChar).Value = "%";
                // da.SelectCommand.Parameters.Add("@USERCODE", SqlDbType.VarChar).Value = null;

            }
            else
            {
                da.SelectCommand.Parameters.Add("@DISTRICTID", SqlDbType.VarChar).Value = Convert.ToString(Session["DistrictID"]);

                // da.SelectCommand.Parameters.Add("@USERCODE", SqlDbType.VarChar).Value = Convert.ToString(Session["uid"]);
            }
            da.Fill(ds);
            con.CloseConnection();
            grdsupport.DataSource = ds;
            grdsupport.DataBind();

        }
        catch (Exception Ex)
        { throw Ex; }

    }

    protected void grdsupport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.Header)
        //{
        //    GridView HeaderGrid = (GridView)sender;
        //    GridViewRow HeaderGridRow = new GridViewRow(2, 2, DataControlRowType.EmptyDataRow, DataControlRowState.Insert);
        //    TableCell HeaderCell = new TableCell();
        //    HeaderCell.Text = "District Name";
        //    HeaderCell.ColumnSpan = 2;
        //    HeaderGridRow.Cells.Add(HeaderCell);
        //    HeaderGridRow.BackColor = ColorTranslator.FromHtml("#009688");
        //    HeaderGridRow.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
        //    HeaderGridRow.BorderStyle = BorderStyle.Solid;
        //    HeaderGridRow.BorderColor = ColorTranslator.FromHtml("#FFFFFF");
        //    HeaderGridRow.HorizontalAlign = HorizontalAlign.Center;

        //    HeaderCell = new TableCell();
        //    HeaderCell.Text = "Total No.of Industries";
        //    HeaderCell.ColumnSpan = 3;
        //    HeaderGridRow.Cells.Add(HeaderCell);

        //    HeaderCell = new TableCell();
        //    HeaderCell.Text = "No.of Grievances";
        //    HeaderCell.ColumnSpan = 6;
        //    HeaderGridRow.Cells.Add(HeaderCell);

        //    grdsupport.Controls[0].Controls.AddAt(0, HeaderGridRow);
        //}
    }
    protected void grdsupport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            HyperLink nocolgscoverd = (HyperLink)e.Row.Cells[2].Controls[0];
            if (nocolgscoverd.Text != "0")
                nocolgscoverd.NavigateUrl = "SupporttoNewEntrepreneursDrillDown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_ID")).Trim() + "& Type=College" + "& From=" + txtfrmdate.Text + "& To=" + txttodate.Text;

            HyperLink nofwomscolgcovrd = (HyperLink)e.Row.Cells[4].Controls[0];
            if (nofwomscolgcovrd.Text != "0")
                nofwomscolgcovrd.NavigateUrl = "SupporttoNewEntrepreneursDrillDown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_ID")).Trim() + "& Type=Women's College" + "& From=" + txtfrmdate.Text + "& To=" + txttodate.Text;

            HyperLink trynginstionscovrd = (HyperLink)e.Row.Cells[6].Controls[0];
            if (trynginstionscovrd.Text != "0")
                trynginstionscovrd.NavigateUrl = "SupporttoNewEntrepreneursDrillDown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_ID")).Trim() + "& Type=Training Institutions" + "& From=" + txtfrmdate.Text + "& To=" + txttodate.Text;

            HyperLink newentprenure = (HyperLink)e.Row.Cells[7].Controls[0];
            if (newentprenure.Text != "0")
                newentprenure.NavigateUrl = "SupporttoNewEntrepreneursDrillDown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_ID")).Trim() + "& Type=New" + "& From=" + txtfrmdate.Text + "& To=" + txttodate.Text;

            HyperLink EDPcamps = (HyperLink)e.Row.Cells[10].Controls[0];
            if (EDPcamps.Text != "0")
                EDPcamps.NavigateUrl = "SupporttoNewEntrepreneursDrillDown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_ID")).Trim() + "& Type=EDPCAMP Y" + "& From=" + txtfrmdate.Text + "& To=" + txttodate.Text;

            HyperLink MSEFCcamps = (HyperLink)e.Row.Cells[11].Controls[0];
            if (MSEFCcamps.Text != "0")
                MSEFCcamps.NavigateUrl = "SupporttoNewEntrepreneursDrillDown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_ID")).Trim() + "& Type=MSEFC Y" + "& From=" + txtfrmdate.Text + "& To=" + txttodate.Text;

            HyperLink MSMEcamp = (HyperLink)e.Row.Cells[12].Controls[0];
            if (MSMEcamp.Text != "0")
                MSMEcamp.NavigateUrl = "SupporttoNewEntrepreneursDrillDown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_ID")).Trim() + "& Type=MSME Y" + "& From=" + txtfrmdate.Text + "& To=" + txttodate.Text;


            HyperLink MSEFCndMSMEcamp = (HyperLink)e.Row.Cells[13].Controls[0];
            if (MSEFCndMSMEcamp.Text != "0")
                MSEFCndMSMEcamp.NavigateUrl = "SupporttoNewEntrepreneursDrillDown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_ID")).Trim() + "& Type=MSEFCandMSMEcamps" + "& From=" + txtfrmdate.Text + "& To=" + txttodate.Text;



        }

    }
    protected void Button2_ServerClick(object sender, EventArgs e)
    {

        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                grdsupport.AllowPaging = false;

                lblHeading.Visible = true;
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
    }


    protected void Button1_ServerClick1(object sender, EventArgs e)
    {
        ExportToExcel();
    }
}