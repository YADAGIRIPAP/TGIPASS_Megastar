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

public partial class UI_TSiPASS_frmDistwomencell : System.Web.UI.Page
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
        Response.Redirect("~/UI/TSIPASS/frmDistwomencell.aspx");
    }
    protected void binddata(string district)
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter("SP_FECILITATORDETAILS_DISTRICTMANDAL", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if(district==null|| district==""|| district=="-Select"|| district=="0")
            {
                da.SelectCommand.Parameters.Add("@district", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                da.SelectCommand.Parameters.Add("@district", SqlDbType.VarChar).Value = district;
            }
            da.Fill(ds);
            con.CloseConnection();
            lblForGrid.Visible = true;
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
            HyperLink h4 = (HyperLink)e.Row.Cells[7].Controls[0];
            if(h4.Text!="0")
            {
                h4.NavigateUrl = "frmdistrictfacilitatorsdrilldown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim();

            }

            HyperLink h6 = (HyperLink)e.Row.Cells[9].Controls[0];
            if (h6.Text != "0")
            {
                h6.NavigateUrl = "frmMandalWomencell.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtid")).Trim();

            }
        }
    }
    protected void Button2_ServerClick(object sender, EventArgs e)
    {
        lblHeading.Visible = true;
       // GrdwmenEntpnrdtls.Columns[6].Visible = false;
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


    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        ExportToExcel();
    }
    protected void ExportToExcel()
    {
        try
        {
            lblHeading.Visible = true;
           // GrdwmenEntpnrdtls.Columns[6].Visible = false;
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
