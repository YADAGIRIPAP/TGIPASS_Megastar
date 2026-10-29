using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class UI_TSiPASS_frmdistrictfacilitatorsdrilldown : System.Web.UI.Page
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
            
                if (!IsPostBack)
                {
                    Binddata(Request.QueryString[0]);
                }
           
        }
    }
    protected void Binddata(string Districtid)
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter("SP_GETFECILITATORDETAILS_DISTRICTCELL", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Districtid == null || Districtid == "" || Districtid == "-Select" || Districtid == "0")
            {
                da.SelectCommand.Parameters.Add("@DISTRICT", SqlDbType.VarChar).Value = Districtid;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@DISTRICT", SqlDbType.VarChar).Value = Districtid;
            }

            da.Fill(ds);
            con.CloseConnection();
            
            grddistfacilitatordetails.DataSource = ds.Tables[0];
            grddistfacilitatordetails.DataBind();


        }
        catch (Exception Ex)
        { throw Ex; }
    }
    protected void Button2_ServerClick(object sender, EventArgs e)
    {
        lblHeading.Visible = true;
      //  GrdwmenEntpnrdtls.Columns[6].Visible = false;
        using (StringWriter sw = new StringWriter())
        {

            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                grddistfacilitatordetails.AllowPaging = false;

                // this.fillgrid();

                grddistfacilitatordetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                grddistfacilitatordetails.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                grddistfacilitatordetails.FooterRow.ForeColor = System.Drawing.Color.Black;
                // grdExport.Columns[1].Visible = false;
                grddistfacilitatordetails.RenderControl(hw);
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
                grddistfacilitatordetails.Style["width"] = "680px";
                Button1.Visible = false;
                Button2.Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                grddistfacilitatordetails.RenderControl(hw);
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



    //protected void lnkbutton_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("frmDistwomencell.aspx");
    //}



}