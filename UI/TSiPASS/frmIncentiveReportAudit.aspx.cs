using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Drawing;
using System.Reflection.Emit;

public partial class UI_TSiPASS_frmIncentiveReportAudit : System.Web.UI.Page
{
    General gen = new General();
    List<officerRemarks> lstremarks = new List<officerRemarks>();
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("../../ipasslogin.aspx");
        }

        if (!IsPostBack)
        {
            GetIncentives();
            //h1heading.InnerHtml = "Applications";
            txtFromDate.Text = "01-04-2021";
            txtTodate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            //Submit_Click(sender, e);
        }
    }
    protected void GetIncentives()
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            da = new SqlDataAdapter("GetIncentiveNames", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(ds);
            ddlIncType.DataSource = ds.Tables[0];
            ddlIncType.DataTextField = "IncentiveName";
            ddlIncType.DataValueField = "IncentiveID";
            ddlIncType.DataBind();
            ddlIncType.Items.Insert(0, "--Select--");
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
    protected void Submit_Click(object sender, EventArgs e)
    {    
        try
        {
            Filldata();
        }
        catch (Exception ex)
        {

        }
    }

    protected void Button2_ServerClick(object sender, EventArgs e)
    {
        lblHeading.Visible = true;
        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                grdDetails.AllowPaging = false;

                // Make headers Bold and set colors
                if (grdDetails.HeaderRow != null)
                {
                    grdDetails.HeaderRow.Font.Bold = true;
                    grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.HeaderStyle.ForeColor = System.Drawing.Color.Black;
                    grdDetails.HeaderStyle.Font.Bold = true;
                }

                if (grdDetails.FooterRow != null)
                {
                    grdDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
                }

                // Loop through columns to apply an explicit width and prevent ugly vertical squishing
                foreach (TableCell cell in grdDetails.HeaderRow.Cells)
                {
                    cell.Attributes.Add("style", "width:180px; min-width:180px; font-weight:bold; white-space:nowrap;");
                }
                foreach (GridViewRow row in grdDetails.Rows)
                {
                    foreach (TableCell cell in row.Cells)
                    {
                        cell.Attributes.Add("style", "width:180px; min-width:180px; white-space:nowrap;");
                    }
                }

                // Render the control into HTML string
                grdDetails.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());

                // CRITICAL: Added .Rotate() to turn A3 into Landscape so your wide grid fits perfectly
                Document pdfDoc = new Document(PageSize.A3.Rotate(), 10f, 10f, 10f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=Incentive_Applications_Details.pdf");
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
                grdDetails.Style["width"] = "680px";
                Button1.Visible = false;
                Button2.Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                grdDetails.RenderControl(hw);
               // string label1text = Label1.Text;
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='5'><h4>" + lblHeading.Text + "</h4></td></td></tr></table>";
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
    void Filldata()
    {
        string FromdateforDB = "", TodateforDB = "";
        if (txtFromDate.Text != "")
        {
            string[] fmdate = txtFromDate.Text.Split('-');
            string[] todate = txtTodate.Text.Split('-');

            FromdateforDB = fmdate[2].ToString() + "/" + fmdate[1].ToString() + "/" + fmdate[0].ToString();
            TodateforDB = todate[2].ToString() + "/" + todate[1].ToString() + "/" + todate[0].ToString();


        }
        grdDetails.DataSource = null;
        grdDetails.DataBind();
        DataSet ds = new DataSet();
        ds = GetIncentiveAudit(FromdateforDB, TodateforDB);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            Label2.Text = "";

            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
        else 
        {
            Label2.Text = "No Records Found";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
    }

    protected void Unnamed_Click(object sender, EventArgs e)
    {
        //LinkButton lb = (LinkButton)sender;
        //GridViewRow row = (GridViewRow)lb.NamingContainer;
        //if (row != null)
        //{
        //    string name = row.Cells[2].Text.Trim();
        //    Response.Redirect("ApplicantIncentiveDtlsDraftView.aspx?EntrpId=" + name + "&Sts=1");
        //}
        LinkButton lb = (LinkButton)sender;
        GridViewRow row = (GridViewRow)lb.NamingContainer;

        if (row != null)
        {
            string name = row.Cells[2].Text.Trim();
            string url = "ApplicantIncentiveDtlsDraftView.aspx?EntrpId=" + name + "&Sts=1";

            // Open in new tab
            string script = "window.open('" + url + "', '_blank');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenNewTab", script, true);
        }
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    public DataSet GetIncentiveAudit(string fromdate, string todate)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            //da = new SqlDataAdapter("USP_GET_DATA_AUDITPURPOSE", con.GetConnection); USP_GET_DATA_AUDITPURPOSE_AGAUDIT
            da = new SqlDataAdapter("USP_GET_DATA_AUDITPURPOSE_AGAUDIT", con.GetConnection); 
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (fromdate.Trim() == "" || fromdate.Trim() == null || fromdate.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@fromdate", SqlDbType.VarChar).Value = DBNull.Value;
            else
                //  da.SelectCommand.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = cmf.convertDateIndia(fromdate);
                da.SelectCommand.Parameters.Add("@fromdate", SqlDbType.VarChar).Value = (fromdate);

            if (todate.Trim() == "" || todate.Trim() == null || todate.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@todate", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@todate", SqlDbType.VarChar).Value = (todate);

            if (ddlCaste.SelectedValue == "Select" || ddlCaste.SelectedValue == "" || ddlCaste.SelectedValue == "0")
                da.SelectCommand.Parameters.Add("@Caste", SqlDbType.VarChar).Value = "All";
            else
                da.SelectCommand.Parameters.Add("@Caste", SqlDbType.VarChar).Value = ddlCaste.SelectedValue.Trim();

            if (ddlEntType.SelectedValue == "Select" || ddlEntType.SelectedValue == "" || ddlEntType.SelectedValue == "0")

                da.SelectCommand.Parameters.Add("@EnterPriseType", SqlDbType.VarChar).Value = "All";
            else
                da.SelectCommand.Parameters.Add("@EnterPriseType", SqlDbType.VarChar).Value = ddlEntType.SelectedValue.Trim();

            if (ddlIncType.SelectedItem.Text.Trim() == "--Select--" || ddlIncType.SelectedValue == "" || ddlIncType.SelectedValue == "0")
                da.SelectCommand.Parameters.Add("@IncentiveType", SqlDbType.VarChar).Value = "All";
            else
                da.SelectCommand.Parameters.Add("@IncentiveType", SqlDbType.VarChar).Value = ddlIncType.SelectedValue.Trim();


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

    
}