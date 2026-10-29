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

public partial class UI_TSiPASS_DistrictWiseApprovedDrillDown : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DB.DB con = new DB.DB();
    string conString = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["uid"] == null || Session["uid"].ToString() == "")
        //{
        //    Response.Redirect("~/TSHome.aspx");

        //}
        //else
        //{
        //    if (Request.QueryString.Count >= 4)
        //    {
        //        string district = Request.QueryString[0];
        //        string txtFromDate = Request.QueryString[1];
        //        string txtTodate = Request.QueryString[2];
        //        string Status = Request.QueryString[3];
        //        string distid = Request.QueryString[4];
        //        Binddata(district, txtFromDate, txtTodate, Status);


        //    }
        //    else
        //    {
        //        Response.Redirect("~/TSHome.aspx");
        //    }
        // }
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            string Districtname = Request.QueryString[0].ToString().Trim();
           string  txtFromDate = Request.QueryString[1].ToString().Trim();
            string  txtTodate = Request.QueryString[2].ToString().Trim();
            string status = Request.QueryString[3].ToString().Trim();
            string distid = Request.QueryString[4];
            string FromdateforDB = "", TodateforDB = "";

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Sp_DistApprovalDatewiseTotalAppldrilldown", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (txtFromDate != "" && txtFromDate.Contains('-'))
            {
                da.SelectCommand.Parameters.AddWithValue("@District", SqlDbType.VarChar).Value = Districtname;
                FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                da.SelectCommand.Parameters.AddWithValue("@FromDate", SqlDbType.Date).Value = FromdateforDB;
                da.SelectCommand.Parameters.AddWithValue("@ToDate", SqlDbType.Date).Value = TodateforDB;
                da.SelectCommand.Parameters.AddWithValue("@status", SqlDbType.VarChar).Value = status;

            }

            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                // lblMsg.Text = "Total Records :" +dsnew.Tables[0].Rows.Count.ToString();

                GrdEntpnrdtls.DataSource = ds.Tables[0];
                GrdEntpnrdtls.DataBind();
               

                  LblGet.Visible = true;
                    if (status == "Appliedwithinperiod")
                    {
                        LblGet.Text = "No Of Industries Applied Within Selected Period (" + txtFromDate.ToString() + " To " + txtTodate.ToString() + ") In " + Districtname;
                    }
                    else if (status == "Approvedwithinperiod")
                    {
                        LblGet.Text = "No Of Industries Approved Within Selected Period (" + txtFromDate.ToString() + " To " + txtTodate.ToString()+ ") In " + Districtname;

                    }
                    else if (status == "Approvedoutofperiod")
                    {
                        LblGet.Text = "No Of Industries Approved Beyond Selected Period (" + txtFromDate.ToString() + " To " + txtTodate.ToString() + ") In " + Districtname;

                    }
                    else if (status == "Investment")
                    {
                        LblGet.Text = "Investment Approved (" + txtFromDate.ToString() + " To " + txtTodate.ToString() + ") In " + Districtname;
                    }
                

            }
            else
            {
                Label1.Text = "No Records Found ";
                GrdEntpnrdtls.DataSource = null;
                GrdEntpnrdtls.DataBind();
            }

            HyperLink1.NavigateUrl = "Districtwiseapproved.aspx?status=" + status + "&lbl=Application Received&dist=" + Districtname + " &fromdate=" + txtFromDate.ToString().Trim() + "&todate=" + txtTodate.ToString().Trim() + "&Districtid=" + distid;

        }

    }
    //protected void Binddata(string district, string txtFromDate, string txtTodate, string Status)
    //{
    //    string distid = "";
    //    distid=Request.QueryString[4];

    //    try
    //    {
    //        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    //        connection.Open();
    //        SqlDataAdapter da = new SqlDataAdapter("Sp_DistApprovalDatewiseTotalAppldrilldown", connection);
    //        da.SelectCommand.CommandType = CommandType.StoredProcedure;
    //        // Assuming da is your SqlDataAdapter or SqlCommand
    //        da.SelectCommand.Parameters.Add("@District", SqlDbType.VarChar).Value = district;
    //        //da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.Date).Value= Convert.ToString(DateTime.ParseExact(txtFromDate, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
    //        da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.Date).Value = DateTime.ParseExact(txtFromDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
    //        da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.Date).Value = DateTime.ParseExact(txtTodate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
    //        da.SelectCommand.Parameters.Add("@status", SqlDbType.VarChar).Value = Status;
    //        //da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = distid;



    //        da.Fill(ds);
    //        connection.Close();
    //        GrdEntpnrdtls.DataSource = ds.Tables[0];
    //        GrdEntpnrdtls.DataBind();
    //        LblGet.Visible = true;

    //        if (district == "%")
    //        { district = "All Districts"; }
           

    //        if (Status == "Approvedwithinperiod")
    //        {

    //            LblGet.Text = "No Of Industries Applied Within Selected Period (" + txtFromDate.ToString() + " To " + txtTodate.ToString() + ") In " + district;
    //        }
    //        else if(Status == "Appliedwithinperiod")
    //        {

    //            LblGet.Text = "Number Of Industries Applied Within Selected Period (" + txtFromDate.ToString() + " To " + txtTodate.ToString() + ") In " + district;
    //        }
    //        else if (Status == "Appliedoutofperiod")
    //        {

    //            LblGet.Text = "Number Of Industries Applied Before selected From Date (" + txtFromDate.ToString() + " To " + txtTodate.ToString() + ") In " + district;
    //        }



    //    }
    //    catch (Exception Ex)
    //    { throw Ex; }
    //    HyperLink1.NavigateUrl = "Districtwiseapproved.aspx?Status=" + Status + "&lbl=Application Received&District=" + district + " & From=" + txtFromDate.ToString().Trim() + "& To=" + txtTodate.ToString().Trim()+ "&DistrictID="+distid;


    //}

    protected void GrdEntpnrdtls_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string intUid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim();
            LinkButton btn = (LinkButton)e.Row.FindControl("LinkButton1");
            if (intUid != "0")
            {
                btn.Text = "View";
                btn.OnClientClick = "javascript:return Popup('" + intUid + "')";
            }
            else
            {
                btn.Text = "";
                btn.Enabled = false;
            }
        }
    }

    protected void GrdEntpnrdtls_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[2].Visible = false;
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
                    GrdEntpnrdtls.AllowPaging = false;
                    // this.fillgrid();
                    GrdEntpnrdtls.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    GrdEntpnrdtls.FooterRow.ForeColor = System.Drawing.Color.Black;
                    GrdEntpnrdtls.Columns[1].Visible = false;
                    GrdEntpnrdtls.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename= TotalApplicationsReceived.pdf");
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


    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        ExportToExcel();
    }
    protected void ExportToExcel()
    {
        try
        {
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
                divPrint1.Style["width"] = "680px";
                Button1.Visible = false;
                Button2.Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                divPrint1.RenderControl(hw);
                string label1text = lbllabel.Text;
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
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
}


