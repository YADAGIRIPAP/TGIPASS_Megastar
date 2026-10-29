using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
//using static TSIPASSPropertiesModel;
using System.Drawing;
//using static TSIPASSPropertiesModel;
using System.Globalization;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
//using static TSIPASSPropertiesModel;
//using static TSIPASSPropertiesModel;
//using static TSIPASSPropertiesModel;

public partial class _Default : System.Web.UI.Page
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
            if (Session["Role_Code"].ToString() == "GM")
            {
                if (!IsPostBack)
                {
                    Binddata(Request.QueryString[0], Request.QueryString[1], Request.QueryString[2], Request.QueryString[3]);
                }
            }
            else { Response.Redirect("~/TSHome.aspx"); }
        }

    }
    protected void Binddata(string Districtid, string type, string fromdate, string todate)
    {
        try
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter("GetEntrepreneurData", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.Date).Value = DateTime.ParseExact(fromdate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.Date).Value = DateTime.ParseExact(todate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            da.SelectCommand.Parameters.Add("@Type", SqlDbType.VarChar).Value = type;
            da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = Districtid;
            da.Fill(ds);
            connection.Close();
            // lblForGrid.Visible = true;

            GrdEntpnrdtls.DataSource = ds.Tables[0];
            GrdEntpnrdtls.DataBind();


        }
        catch (Exception Ex)
        { throw Ex; }

    }
   

    protected void GrdEntpnrdtls_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataSet dss = new DataSet();
            Label entrpurID = (Label)e.Row.FindControl("lblentrpurID");
            HyperLink print = (HyperLink)e.Row.Cells[6].Controls[0];
            print.NavigateUrl = "Personal_Interaction_Page_EXISTING_Entrepreneurs_print.aspx?HdnEnterpreneur_ID="+ entrpurID.Text;
        }
    }
    protected void Button2_ServerClick(object sender, EventArgs e)
    {
        lblHeading.Visible = true;
        GrdEntpnrdtls.Columns[6].Visible = false;
        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                GrdEntpnrdtls.AllowPaging = false;

                // this.fillgrid();

                GrdEntpnrdtls.HeaderRow.ForeColor = System.Drawing.Color.Black;
                GrdEntpnrdtls.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                GrdEntpnrdtls.FooterRow.ForeColor = System.Drawing.Color.Black;
                // grdExport.Columns[1].Visible = false;
                GrdEntpnrdtls.RenderControl(hw);
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
            GrdEntpnrdtls.Columns[6].Visible = false;
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
                GrdEntpnrdtls.Style["width"] = "680px";
                Button1.Visible = false;
                Button2.Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GrdEntpnrdtls.RenderControl(hw);
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

    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        ExportToExcel();
    }

   
    //protected void lnkbutn_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("SupporttoExistingEntrepreneurs.aspx");
    //}
}


