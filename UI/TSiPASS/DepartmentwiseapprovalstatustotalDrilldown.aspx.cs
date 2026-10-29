using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_DepartmentwiseapprovalstatustotalDrilldown : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        
            if (!IsPostBack)
            {
                if (Request.QueryString.Count >= 2)
                {                  
                    string Dept_Id = Request.QueryString[0];
                    string status = Request.QueryString[1];

                    binddata(Dept_Id, status);
                }
            }
        
    }
    protected void binddata( string Dept_Id, string status)
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter("SP_SVCDEPTPROCESSEDAPPLICATIONS_New_drilldown", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;                   
            da.SelectCommand.Parameters.Add("@deptid", SqlDbType.VarChar).Value = Dept_Id.Trim();
            da.SelectCommand.Parameters.Add("@type", SqlDbType.VarChar).Value = status.Trim();
            da.Fill(ds);
            lblHeading.Visible = true;

            //324563" Text="TSSPDCL"></asp:L
            //324565" Text="TSNPDCL"></asp:L
            //324566" Text="COMMERCIAL TAX">
            //324567" Text="TSFC"></asp:List
            //324568" Text="IGRS"></asp:List
            //324569" Text="TSIIC"></asp:Lis
            //324570" Text="REVENUE"></asp:L




            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
                grdDetails.Columns[5].Visible = false;
                grdDetails.Columns[6].Visible = false;
                if (status == "total")
                {

                    if (Dept_Id == "324563")
                    {
                        lblHeading.Text = "Incentives Applications TSSPDCL Total Applications ";

                    }
                    else if (Dept_Id == "324565")
                    {

                        lblHeading.Text = "Incentives Applications TSNPDCL Total Applications";
                    }
                    else if (Dept_Id == "324566")
                    {
                        lblHeading.Text = "Incentives Applications COMMERCIAL Total Applications ";
                    }

                    else if (Dept_Id == "324567")
                    {
                        lblHeading.Text = "Incentives Applications-TSFC Total Applications ";
                    }
                    else if (Dept_Id == "324568")
                    {

                        lblHeading.Text = "Incentives Applications IGRS Total Applications ";
                    }
                    else if (Dept_Id == "324569")
                    {
                        lblHeading.Text = "Incentives Applications TSIIC Total Applications ";
                    }

                    else if (Dept_Id == "324570")
                    {
                        lblHeading.Text = "Incentives Applications REVENUE Total Applications ";
                    }

                }
                else // (Approvals == "pending")
                {

                    if (Dept_Id == "324563")
                    {
                        lblHeading.Text = "Incentives Applications TSSPDCL Pending Applications ";
                    }
                    else if (Dept_Id == "324565")
                    {

                        lblHeading.Text = "Incentives Applications TSNPDCL Pending Applications ";
                    }
                    else if (Dept_Id == "324566")
                    {
                        lblHeading.Text = "Incentives Applications COMMERCIAL Pending Applications ";
                    }
                    else if (Dept_Id == "324567")
                    {
                        lblHeading.Text = "Incentives Applications TSFC Pending Applications ";
                    }
                    else if (Dept_Id == "324568")
                    {

                        lblHeading.Text = "Incentives Applications IGRS Pending Applications ";
                    }
                    else if (Dept_Id == "324569")
                    {
                        lblHeading.Text = "Incentives Applications TSIIC Pending Applications";
                    }
                    else if (Dept_Id == "324570")
                    {
                        lblHeading.Text = "Incentives Applications REVENUE Pending Applications ";
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
        catch (Exception ex)    
        {
            throw ex;
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
}