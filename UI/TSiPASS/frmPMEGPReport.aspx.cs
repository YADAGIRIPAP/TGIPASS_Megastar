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

public partial class UI_TSiPASS_frmPMEGPReport : System.Web.UI.Page
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

        { binddata(ddldistrict.SelectedValue); }

    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UI/TSIPASS/frmPMEGPREPORT.aspx");
    }
    protected void binddata(string district)
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter("SP_REJECTEDUNITS_DATA_PMEGP", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (district == null || district == "" || district == "-Select" || district == "0")
            {
                da.SelectCommand.Parameters.Add("@DISTRICTID", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                da.SelectCommand.Parameters.Add("@DISTRICTID", SqlDbType.VarChar).Value = district;
            }
            da.Fill(ds);
            con.CloseConnection();
            grdwomencells.DataSource = ds;
            grdwomencells.DataBind();

        }
        catch (Exception Ex)
        { throw Ex; }

    }


    protected void grdwomencells_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink h2 = (HyperLink)e.Row.Cells[2].Controls[0];
            if (h2.Text != "0")
            {
                h2.NavigateUrl = "frmPMEGPReportDrilldown.aspx?ID=13&DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim();

            }

            HyperLink h3 = (HyperLink)e.Row.Cells[3].Controls[0];
            if (h3.Text != "0")
            {
                h3.NavigateUrl = "frmPMEGPReportDrilldown.aspx?ID=14&DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim();

            }
            HyperLink h4 = (HyperLink)e.Row.Cells[4].Controls[0];
            if (h4.Text != "0")
            {
                h4.NavigateUrl = "frmPMEGPReportDrilldown.aspx?ID=15&DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim();

            }
            HyperLink h5 = (HyperLink)e.Row.Cells[5].Controls[0];
            if (h5.Text != "0")
            {
                h5.NavigateUrl = "frmPMEGPReportDrilldown.aspx?ID=1&DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim();

            }
            HyperLink h6 = (HyperLink)e.Row.Cells[6].Controls[0];
            if (h6.Text != "0")
            {
                h6.NavigateUrl = "frmPMEGPReportDrilldown.aspx?ID=2&DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim();

            }
            HyperLink h7 = (HyperLink)e.Row.Cells[7].Controls[0];
            if (h7.Text != "0")
            {
                h7.NavigateUrl = "frmPMEGPReportDrilldown.aspx?ID=3&DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim();

            }
            HyperLink h8 = (HyperLink)e.Row.Cells[8].Controls[0];
            if (h8.Text != "0")
            {
                h8.NavigateUrl = "frmPMEGPReportDrilldown.aspx?ID=4&DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim();

            }
            HyperLink h9 = (HyperLink)e.Row.Cells[9].Controls[0];
            if (h9.Text != "0")
            {
                h9.NavigateUrl = "frmPMEGPReportDrilldown.aspx?ID=5&DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim();

            }
            HyperLink h10 = (HyperLink)e.Row.Cells[10].Controls[0];
            if (h10.Text != "0")
            {
                h10.NavigateUrl = "frmPMEGPReportDrilldown.aspx?ID=6&DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim();

            }
            HyperLink h11 = (HyperLink)e.Row.Cells[11].Controls[0];
            if (h11.Text != "0")
            {
                h11.NavigateUrl = "frmPMEGPReportDrilldown.aspx?ID=7&DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim();

            }
            HyperLink h12 = (HyperLink)e.Row.Cells[12].Controls[0];
            if (h12.Text != "0")
            {
                h12.NavigateUrl = "frmPMEGPReportDrilldown.aspx?ID=8&DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim();

            }
            HyperLink h13 = (HyperLink)e.Row.Cells[13].Controls[0];
            if (h13.Text != "0")
            {
                h13.NavigateUrl = "frmPMEGPReportDrilldown.aspx?ID=9&DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim();

            }
            HyperLink h14 = (HyperLink)e.Row.Cells[14].Controls[0];
            if (h14.Text != "0")
            {
                h14.NavigateUrl = "frmPMEGPReportDrilldown.aspx?ID=10&DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim();

            }
            HyperLink h15 = (HyperLink)e.Row.Cells[15].Controls[0];
            if (h15.Text != "0")
            {
                h15.NavigateUrl = "frmPMEGPReportDrilldown.aspx?ID=11&DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim();

            }
            HyperLink h16 = (HyperLink)e.Row.Cells[16].Controls[0];
            if (h16.Text != "0")
            {
                h16.NavigateUrl = "frmPMEGPReportDrilldown.aspx?ID=12&DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim();

            }



        }
    }

    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        ExportToExcel();
    }
    protected void ExportToExcel()
    {
        try
        {
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
                grdwomencells.Style["width"] = "680px";
                Button1.Visible = false;
                Button2.Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                grdwomencells.RenderControl(hw);
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
        // Handle exceptions appropriately, e.g., log or display an error message
    }

    protected void Button2_ServerClick1(object sender, EventArgs e)
    {
        //  GrdwmenEntpnrdtls.Columns[6].Visible = false;
        using (StringWriter sw = new StringWriter())
        {

            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                grdwomencells.AllowPaging = false;

                // this.fillgrid();

                grdwomencells.HeaderRow.ForeColor = System.Drawing.Color.Black;
                grdwomencells.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                grdwomencells.FooterRow.ForeColor = System.Drawing.Color.Black;
                // grdExport.Columns[1].Visible = false;
                grdwomencells.RenderControl(hw);
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
}