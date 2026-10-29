using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class UI_TSiPASS_Report_PageDrilldown : System.Web.UI.Page
{
    General Gen = new General();
    string conString = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                DataSet ds = new DataSet();
                string District = Request.QueryString[0].ToString().Trim();
                txtFromDate.Text = Request.QueryString[1].ToString().Trim();
                txtTodate.Text = Request.QueryString[2].ToString().Trim();
                string type = Request.QueryString[3].ToString().Trim();
                string Distid = Request.QueryString[4];
                string Selected= Request.QueryString[5].ToString().Trim();
                string FromdateforDB = "", TodateforDB = "";

                SqlConnection con = new SqlConnection(conString);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("GetApplandApprovalslistdrilldown", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
                {
                    da.SelectCommand.Parameters.AddWithValue("@District", SqlDbType.VarChar).Value = District;
                    FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                    TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                    da.SelectCommand.Parameters.AddWithValue("@FromDate", SqlDbType.Date).Value = FromdateforDB;
                    da.SelectCommand.Parameters.AddWithValue("@ToDate", SqlDbType.Date).Value = TodateforDB;
                    da.SelectCommand.Parameters.AddWithValue("@type", SqlDbType.VarChar).Value = type;
                    da.SelectCommand.Parameters.AddWithValue("@intDistrictid", SqlDbType.VarChar).Value = Distid;


                }
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    // lblMsg.Text = "Total Records :" +dsnew.Tables[0].Rows.Count.ToString();

                    grdReports.DataSource = ds.Tables[0];
                    grdReports.DataBind();
                    if (type == "NoofApplication" || type== "Applapprovedwithin" || type== "Applapprovedbeyond")
                    {
                        grdReports.Columns[16].Visible = false;
                        grdReports.Columns[17].Visible = false;
                    }
                   

                    if (ddlType.SelectedValue == "3")
                    {
                        Label1.Text = "Report from 01-April-2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
                    }
                    else
                    {
                        if (txtFromDate.Text.Trim() != "" && txtTodate.Text.Trim() != "")
                            Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
                        else
                            Label1.Text = "Report from 01-Jan-2015 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
                    }
                    if (Request.QueryString[2].ToString().Trim() == "%")
                    {
                        lblHeader.Text = "R6.1: TSiPASS- District Wise Report";
                    }
                    else
                    {
                        LblGet.Visible = true;
                        if (District == "%")
                            District = "in all Districts";
                        if (type == "NoofApplication")
                        {
                            LblGet.Text = " Total No of Industries (" + txtFromDate.Text + " To " + txtTodate.Text + ") In " + District;
                           
                        }
                        else if (type == "Applapprovedwithin")
                        {
                            LblGet.Text = " No of Industries for which All approvals Issued with in time lines (" + txtFromDate.Text + " To " + txtTodate.Text + ") In " + District;

                        }
                        else if (type == "Applapprovedbeyond")
                        {
                            LblGet.Text = " No of Industries for which approvals Issued beyond time lines (" + txtFromDate.Text + " To " + txtTodate.Text + ") In " + District;

                        }
                        else if (type == "totalApprovals")
                        {
                            LblGet.Text = " Total Approvals applied  (" + txtFromDate.Text + " To " + txtTodate.Text + ") In " + District;
                        }
                        else if (type == "Approvalswithin")
                        {
                            LblGet.Text = " No of Approvals issued with in time lines (" + txtFromDate.Text + " To " + txtTodate.Text + ") In " + District;
                        }
                        else if (type == "Approvalsbeyond")
                        {
                            LblGet.Text = " No of Approvals issued beyond time lines (" + txtFromDate.Text + " To " + txtTodate.Text + ") In " + District;
                        }
                    }

                }
                else
                {
                    Label1.Text = "No Records Found ";
                    grdReports.DataSource = null;
                    grdReports.DataBind();
                }

                HyperLink1.NavigateUrl = "DistricReport.aspx?type=" + type + "&lbl=Application Received&dist=" + District + " &fromdate=" + txtFromDate.Text.Trim() + "&todate=" + txtTodate.Text.Trim() + "&Districtid=" + Distid+ "&Selected="+ Convert.ToString(Request.QueryString[5]);

            }
            catch (Exception ex)
            {
                throw ex;
            }         


        }
    }    

    protected void grdReports_RowDataBound(object sender, GridViewRowEventArgs e)
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
            else
                btn.Enabled = false;

            
        }
       
    }
    protected void grdReports_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void grdReports_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[2].Visible = false;
       
       
        
    }

    protected void grdReports_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button2_ServerClick(object sender, EventArgs e)
    {
        try
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    //To Export all pages
                    //trLogo.Visible = true;
                    grdReports.AllowPaging = false;
                    // this.fillgrid();
                    grdReports.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdReports.FooterRow.ForeColor = System.Drawing.Color.Black;
                    grdReports.Columns[1].Visible = false;
                    grdReports.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename= DistricReports.pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.Flush();
                    Response.End();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
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
            catch (Exception ex)
            {
                throw ex;
            }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}