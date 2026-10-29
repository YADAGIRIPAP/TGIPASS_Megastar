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
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using ListItem = System.Web.UI.WebControls.ListItem;

public partial class UI_TSiPASS_reportoninteractionwithexistent : System.Web.UI.Page
{
    General Gen = new General();

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
           
                if (!IsPostBack)
                {
                BindDistricts();

                if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
                {
                    ddldistrict.SelectedValue = Session["DistrictID"].ToString().Trim();

                    ddldistrict.Enabled = false;
                }
                txtfrmdate.Text = "01-10-2023";
                    txttodate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                BtnGetData_Click(sender, e);

            }

        }

    }
    public void AddSelect(DropDownList ddl)
    {
        try
        {
            ListItem li = new ListItem();
            li.Text = "--Select--";
            li.Value = "0";
            ddl.Items.Insert(0, li);
        }
        catch (Exception ex)
        {

        }
    }

    public void BindDistricts()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddldistrict.Items.Clear();
            dsd = Gen.GetDistrictsWithoutHYD();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddldistrict.DataSource = dsd.Tables[0];
                ddldistrict.DataValueField = "District_Id";
                ddldistrict.DataTextField = "District_Name";
                ddldistrict.DataBind();
                // ddlProp_intDistrictid.Items.Insert(0, "--Select--");
                AddSelect(ddldistrict);
            }
            else
            {
                // ddlProp_intDistrictid.Items.Insert(0, "--Select--");
                AddSelect(ddldistrict);
            }
        }
        catch (Exception ex)
        {

            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void BtnGetData_Click(object sender, EventArgs e)
    {
        if (txttodate.Text != "" && txtfrmdate.Text != "")
        { binddata(txtfrmdate.Text, txttodate.Text,ddldistrict.SelectedValue); }

    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UI/TSIPASS/reportoninteractionwithexistent.aspx");
    }
    protected void binddata(string fromdate, string todate, string district)
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter("sp_ExistingEntr", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.Date).Value = DateTime.ParseExact(fromdate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.Date).Value = DateTime.ParseExact(todate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            if (district == null || district == "" || district == "-Select" || district == "0")
            {
                da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = district;
            }

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
            HyperLink visited = (HyperLink)e.Row.Cells[2].Controls[0];
            if (visited.Text != "0")
               visited.NavigateUrl = "reportoninteractionwithexistentDrillDown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictID")).Trim() + "& Type=VisitedCount" + "& From=" + txtfrmdate.Text + "& To=" + txttodate.Text;

            HyperLink existingENTPNR = (HyperLink)e.Row.Cells[3].Controls[0];
            if (existingENTPNR.Text != "0")
                existingENTPNR.NavigateUrl = "reportoninteractionwithexistentDrillDown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictID")).Trim() + "& Type=ExstCount" + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text;

            HyperLink newENTPNR = (HyperLink)e.Row.Cells[4].Controls[0];
            if (newENTPNR.Text != "0")
                newENTPNR.NavigateUrl = "reportoninteractionwithexistentDrillDown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictID")).Trim() + "& Type=NewCount" + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text;

            HyperLink repotedgrvnce = (HyperLink)e.Row.Cells[5].Controls[0];
            if (repotedgrvnce.Text != "0")
                repotedgrvnce.NavigateUrl = "reportoninteractionwithexistentDrillDown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictID")).Trim() + "& Type=GrvncSubmtd" + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text;

            HyperLink pndingwththeofcer = (HyperLink)e.Row.Cells[6].Controls[0];
            if (pndingwththeofcer.Text != "0")
                pndingwththeofcer.NavigateUrl = "reportoninteractionwithexistentDrillDown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictID")).Trim() + "& Type=ofcrpending" + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text;

            HyperLink resolvedatofcerlvl = (HyperLink)e.Row.Cells[7].Controls[0];
            if (resolvedatofcerlvl.Text != "0")
                resolvedatofcerlvl.NavigateUrl = "reportoninteractionwithexistentDrillDown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictID")).Trim() + "& Type=ofcrResolved" + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text;

            HyperLink eskltedtoGM = (HyperLink)e.Row.Cells[8].Controls[0];
            if (eskltedtoGM.Text != "0")
                eskltedtoGM.NavigateUrl = "reportoninteractionwithexistentDrillDown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictID")).Trim() + "& Type=escalatedtoGM" + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text;

            HyperLink pendngvthgm = (HyperLink)e.Row.Cells[9].Controls[0];
            if (pendngvthgm.Text != "0")
                pendngvthgm.NavigateUrl = "reportoninteractionwithexistentDrillDown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictID")).Trim() + "& Type=GMpending" + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text;

            HyperLink resolevbyGM = (HyperLink)e.Row.Cells[10].Controls[0];
            if (resolevbyGM.Text != "0")
                resolevbyGM.NavigateUrl = "reportoninteractionwithexistentDrillDown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictID")).Trim() + "& Type=GMResolved" + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text;



            HyperLink eskltedtoDIPC = (HyperLink)e.Row.Cells[11].Controls[0];
            if (eskltedtoDIPC.Text != "0")
                eskltedtoDIPC.NavigateUrl = "reportoninteractionwithexistentDrillDown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictID")).Trim() + "& Type=escalatedtoDIPC" + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text;

            HyperLink pndngvthDIPC = (HyperLink)e.Row.Cells[12].Controls[0];
            if (pndngvthDIPC.Text != "0")
                pndngvthDIPC.NavigateUrl = "reportoninteractionwithexistentDrillDown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictID")).Trim() + "& Type=DIPCpending" + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text;

            HyperLink resolvedbyDIPC = (HyperLink)e.Row.Cells[13].Controls[0];
            if (resolvedbyDIPC.Text != "0")
                resolvedbyDIPC.NavigateUrl = "reportoninteractionwithexistentDrillDown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictID")).Trim() + "& Type=DIPCResolved" + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text;

            HyperLink eskltedDOI = (HyperLink)e.Row.Cells[14].Controls[0];
            if (eskltedDOI.Text != "0")
                eskltedDOI.NavigateUrl = "reportoninteractionwithexistentDrillDown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictID")).Trim() + "& Type=escalatedtoDOI" + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text;


            HyperLink pndngvthDOI = (HyperLink)e.Row.Cells[15].Controls[0];
            if (pndngvthDOI.Text != "0")
                pndngvthDOI.NavigateUrl = "reportoninteractionwithexistentDrillDown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictID")).Trim() + "& Type=DOIpending" + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text;

            HyperLink reslvedbyDOI = (HyperLink)e.Row.Cells[16].Controls[0];
            if (reslvedbyDOI.Text != "0")
                reslvedbyDOI.NavigateUrl = "reportoninteractionwithexistentDrillDown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictID")).Trim() + "& Type=DOIResolved" + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text;

            //HyperLink Grvnceonline = (HyperLink)e.Row.Cells[16].Controls[0];
            //if (Grvnceonline.Text != "0")
            //    Grvnceonline.NavigateUrl = "reportoninteractionwithexistentDrillDown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictID")).Trim() + "& Type=grvncOnline" + "& Form=" + txtfrmdate.Text + "& To=" + txttodate.Text;




        }
    }
    protected void Button2_ServerClick(object sender, EventArgs e)
    {
        lblHeading.Visible = true;
        //  GrdwmenEntpnrdtls.Columns[6].Visible = false;
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


    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        ExportToExcel();
    }
    protected void ExportToExcel()
    {
        try
        {
            lblHeading.Visible = true;
            //  GrdwmenEntpnrdtls.Columns[6].Visible = false;
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
}