using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class UI_TSiPASS_CommissionerReportDashboardDrillDown : System.Web.UI.Page
{
    General Gen = new General();
    string conString = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                DataSet ds = new DataSet();
                string Distid = Request.QueryString[0].ToString().Trim();
                string Districtname = Request.QueryString[1].ToString().Trim();
                string Type = Request.QueryString[2].ToString().Trim();


                SqlConnection con = new SqlConnection(conString);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("sp_CFE_CFO_INCApplieddrilldown", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Distid", SqlDbType.VarChar).Value = Distid;
                da.SelectCommand.Parameters.AddWithValue("@Districtname", SqlDbType.VarChar).Value = Districtname;
                da.SelectCommand.Parameters.AddWithValue("@type", SqlDbType.VarChar).Value = Type;

                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lbllabel.Visible = true;
                    if (Type == "CFE")
                    {
                        grdDetails.DataSource = ds.Tables[0];
                        grdDetails.DataBind();
                        GridPrint.Visible = true;
                        lbllabel.Text = "CFE No of Industries" + " " + " " + "In" + " " + Districtname;
                    }
                    else if (Type == "CFO")
                    {
                        GridviewCFO.DataSource = ds.Tables[0];
                        GridviewCFO.DataBind();
                        divExport.Visible = true;
                        lbllabel.Text = "" + "CFO Applied" + " " + "In" + " " + Districtname;
                    }
                    else if (Type == "Claims")
                    {
                        GridviewInsentive.DataSource = ds.Tables[0];
                        GridviewInsentive.DataBind();
                        Tr1.Visible = true;
                        lbllabel.Text = "Claims" + " " + "In" + " " + Districtname;
                    }
                    else if (Type == "INC")
                    {
                        GridviewINC.DataSource = ds.Tables[0];
                        GridviewINC.DataBind();
                        Tr2.Visible = true;
                        lbllabel.Text = "INC" + " " + "In" + " " + Districtname;
                    }
                }
                else
                {
                    Label1.Text = "No Records Found ";
                    grdDetails.DataSource = null;
                    grdDetails.DataBind();
                }
                HyperLink1.NavigateUrl = "CommissionerReportDashboard.aspx?Type=" + Type + "&lbl=Application Received&Distid=";

            }
        }
        catch(Exception ex)
        {
            
        }
        finally
        {
            Label1.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }
       
      
    }

    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            string intUid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim();
            LinkButton btn = (LinkButton)e.Row.FindControl("LinkButton1");

            btn.Text = "View";
            if (intUid != "0")
            {
                btn.OnClientClick = "javascript:return Popup('" + intUid + "')";
            }


        }
    }

    protected void A1_ServerClick(object sender, EventArgs e)
    {
        ExportToExcel();
    }
    protected void ExportToExcel()
    {
        try
        {

            Response.Clear();
            Response.Buffer = true;
            string FileName = lblHeader.Text;
            FileName = FileName.Replace(" ", "");
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName + DateTime.Now.ToString("M/d/yyyy") + ".xls");

            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                divPrint1.RenderControl(hw);

                string label1text = Label1.Text;
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='6'><h4>" + lblHeader.Text + "</h4></td></td></tr><tr><td align='center' colspan='6'><h4>" + label1text + "</h4></td></td></tr></table>";
                HttpContext.Current.Response.Write(headerTable);

                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        catch (Exception e)
        {

        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }

    protected void Button2_ServerClick(object sender, EventArgs e)
    {
        PrintPdf();
    }
    protected void PrintPdf()
    {
        try
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    //To Export all pages
                    //trLogo.Visible = true;
                    grdDetails.AllowPaging = false;
                    // this.fillgrid();
                    //grdDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    string FileName = lblHeader.Text;
                    FileName = FileName.Replace(" ", "");
                    Response.AddHeader("content-disposition", "attachment;filename=  " + FileName + ".pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.Flush();
                    Response.End();
                }
            }
        }
        catch (Exception e)
        {

        }
    }

    protected void GridviewCFO_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            string intUid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim();
            LinkButton btn = (LinkButton)e.Row.FindControl("LinkButton2");

            btn.Text = "View";
            if (intUid != "0")
            {
                btn.OnClientClick = "javascript:return PopupCFO('" + intUid + "')";
            }

        }
    }

    protected void GridviewInsentive_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

          
                string IncentveID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IncentveID")).Trim();
                LinkButton btn = (LinkButton)e.Row.FindControl("LinkButton3");

                btn.Text = "View";
                if (IncentveID != "0")
                {
                    btn.OnClientClick = "javascript:return PopupInsentive('" + IncentveID + "')";
                }
          
        }
    }

    protected void GridviewINC_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
}