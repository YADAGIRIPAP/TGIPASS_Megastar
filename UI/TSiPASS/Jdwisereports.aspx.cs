using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;


public partial class UI_TSiPASS_Jdwisereports : System.Web.UI.Page
{
    public int s { get; set; }
    General Common = new General();
    public string dist { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["uid"] != null)
        {


            if (!IsPostBack)
            {
                Label3.Text = "Report as on date " + DateTime.Now;
                Session["s"] = Request.QueryString["status"].ToString();
                s = Convert.ToInt32(Session["s"]);
                Session["dist"] = Request.QueryString["intDistid"].ToString();
                dist = Session["dist"].ToString();

                Bind_Data(s, dist);


            }

        }

        else
        {
            Response.Redirect("~/Home.aspx");
        }


    }




    public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
    {
        //required to avoid the runtime error "  
        //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
    }
    private void Bind_Data(int Status, string Dist)
    {
        try
        {
            SqlParameter[] p = new SqlParameter[] {
               new SqlParameter("@STATUS",SqlDbType.Int),
                new SqlParameter("@DIST",SqlDbType.VarChar),

                              };
            p[0].Value = Status;
            p[1].Value = Dist;




            DataTable DT = Common.GenericFillDataTable("USP_GET_RM_JDDASHBOARDss4_DRILL_BYROLE", p);

            gvdetailsnew.DataSource = DT;
            gvdetailsnew.DataBind();




        }
        catch (Exception ex)
        {


            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }



    protected void BtnSave2_Click(object sender, EventArgs e)
    {
        //ExportToExcel();

        ExportGridToExcel();



    }

    private void ExportGridToExcel()
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "Vithal" + DateTime.Now + ".xls";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        gvdetailsnew.GridLines = GridLines.Both;
        gvdetailsnew.HeaderStyle.Font.Bold = true;
        gvdetailsnew.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.End();

    }

    protected void BtnSaved_Click(object sender, EventArgs e)
    {
        ExportGridToPDF();
    }
    private void ExportGridToPDF()
    {

        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Vithal_Wadje.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        gvdetailsnew.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        iTextSharp.text.html.simpleparser.HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
        gvdetailsnew.AllowPaging = true;
        gvdetailsnew.DataBind();
    }

    //protected void ExportToExcel()
    //{
    //    try
    //    {




    //        Response.Clear();
    //        Response.Buffer = true;
    //        Response.AddHeader("content-disposition", "attachment;filename=R1.1Abstract-FinancialYearwise" + DateTime.Now.ToString("MM-dd-yyyy") + ".xls");
    //        Response.Charset = "";
    //        Response.ContentType = "application/vnd.ms-excel";
    //        using (StringWriter sw = new StringWriter())
    //        {
    //            HtmlTextWriter hw = new HtmlTextWriter(sw);
    //            div_Print.RenderControl(hw);

    //            string label1text = Label1.Text;
    //            string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='6'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='6'><h4>" + label1text + "</h4></td></td></tr></table>";
    //            HttpContext.Current.Response.Write(headerTable);

    //            Response.Output.Write(sw.ToString());
    //            Response.Flush();
    //            Response.End();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;

    //        //LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
    //    }
    //}




    public string formdate(string date)
    {
        string dd = "";
        if (date != "")
        {
            string[] dt = date.Split('-');
            dd = dt[2].ToString() + "-" + dt[1].ToString() + "-" + dt[0].ToString();
        }
        return dd;
    }
    //protected void btnLogin_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        SqlParameter[] p = new SqlParameter[] {

    //            new SqlParameter("@STATUS",SqlDbType.Int),
    //            new SqlParameter("@DIST",SqlDbType.VarChar),
    //              new SqlParameter("@fromdate",SqlDbType.DateTime),
    //                new SqlParameter("@todate",SqlDbType.DateTime),
    //                          };


    //        p[0].Value = Convert.ToInt32(Session["s"]);
    //        p[1].Value = Session["dist"].ToString();







    //        DataTable DT = Common.GenericFillDataTable("USP_GET_RM_DASHBOARDss4_DRILL_BYROLE", p);

    //        gvdetailsnew.DataSource = DT;
    //        gvdetailsnew.DataBind();

    //        Label1.Text = "Report from " + txtfromdate.Text.Trim() + " To " + txttodate.Text.Trim();
    //    }
    //    catch (Exception ex)
    //    {


    //        LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
    //    }

    //}

}