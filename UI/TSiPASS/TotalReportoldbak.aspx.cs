using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.Drawing;

public partial class UI_TotalReportoldbak : System.Web.UI.Page
{
    decimal NumberTotal, InvestmnetTotal, EmploymentTotal;
    #region Declaration
    General gen = new General();
    General Gen = new General();
    int Sno = 0;

    DataSet ds;
    DataTable dt;


    DataSet dslist;


    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session.Count <= 0)
        //{
        //    Response.Redirect("../../frmUserLogin.aspx");
        //}
        if (!IsPostBack)
        {
            //getdistricts();
            fillgrid();
        }

    }
    #endregion

    //protected void getdistricts()
    //{
    //    DataSet dsnew = new DataSet();

    //    dsnew = Gen.GetDistricts();
    //    ddlConnectLoad.DataSource = dsnew.Tables[0];
    //    ddlConnectLoad.DataTextField = "District_Name";
    //    ddlConnectLoad.DataValueField = "District_Name";
    //    ddlConnectLoad.DataBind();
    //    ddlConnectLoad.Items.Insert(0, "--Select--");
    //}
    public void fillgrid()
    {

        DataSet dsnew = new DataSet();

        dsnew = Gen.FetchTotalDistrictwise_Old();

        DataSet ds = new DataSet();
        ds = Gen.GetmodifiedDate();
        Label2.Text = "Last Updated on : " + ds.Tables[0].Rows[0]["ModifiedDate"].ToString().Trim();
        // lblMsg.Text = "";
        if (dsnew.Tables[0].Rows.Count > 0)
        {
            // lblMsg.Text = "Total Records :" +dsnew.Tables[0].Rows.Count.ToString();
            Label1.Text = "Report from 01-Jan-2015 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
            grdDetails.DataSource = dsnew.Tables[0];
            grdDetails.DataBind();
            BindPieChart();

        }
        else
        {
            //lblMsg.Text = "";
            Label1.Text = "No Recards Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }

    }
    private void BindPieChart()
    {
        DataTable dsChartData = new DataTable();
        StringBuilder strScript = new StringBuilder();

        try
        {

            dsChartData = Gen.FetchTotalDistrictwise_Old().Tables[0];

            strScript.Append(@"<script type='text/javascript'>  
                    google.load('visualization', '1', {packages: ['corechart']}); </script>  
                      
                    <script type='text/javascript'>  
                     
                    function drawChart() {         
                    var data = google.visualization.arrayToDataTable([  
                    ['District', 'Number'],");

            foreach (DataRow row in dsChartData.Rows)
            {
                strScript.Append("['" + row["District"] + "'," + row["Number"] + "],");
            }
            strScript.Remove(strScript.Length - 1, 1);
            strScript.Append("]);");

            strScript.Append(@" var options = {     
                                    title: 'No of Industries/ District',            
                                    is3D: true,         
                                    };   ");

            strScript.Append(@"var chart = new google.visualization.PieChart(document.getElementById('piechart_3d'));          
                                chart.draw(data, options);        
                                }    
                            google.setOnLoadCallback(drawChart);  
                            ");
            strScript.Append(" </script>");


            ltrPie.Text = strScript.ToString();

        }
        catch
        {
        }
        finally
        {
            dsChartData.Dispose();

        }

    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal NumberTotal1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Number"));
            NumberTotal = NumberTotal1 + NumberTotal;

            decimal InvestmnetTotal1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Investment"));
            InvestmnetTotal = InvestmnetTotal1 + InvestmnetTotal;


            decimal EmploymentTotal1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Employment"));
            EmploymentTotal = EmploymentTotal1 + EmploymentTotal;


            HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];

            h1.NavigateUrl = "FrmDistDrilldownold.aspx?status=A&lbl=Application Received&dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District")).Trim();

            HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];

            h2.NavigateUrl = "FrmDistDrilldownold.aspx?status=B&lbl=Application Received&dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District")).Trim();

            HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];

            h3.NavigateUrl = "FrmDistDrilldownold.aspx?status=C&lbl=Application Received&dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District")).Trim();



        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {

            e.Row.Cells[1].Text = "Total";
            HyperLink Total = new HyperLink();
            Total.ForeColor = System.Drawing.Color.White;
            Total.NavigateUrl = "FrmDistDrilldownold.aspx?status=C&lbl=Total Applications Received&dist=%";
            Total.Text = NumberTotal.ToString();
            //e.Row.Cells[2].Controls.RemoveAt(0);
            e.Row.Cells[2].Controls.Add(Total);

            //e.Row.Cells[2].Text = NumberTotal.ToString();
            e.Row.Cells[3].Text = InvestmnetTotal.ToString();
            e.Row.Cells[4].Text = EmploymentTotal.ToString();

        }
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grdDetails.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    { }

    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void BtnSave2_Click(object sender, EventArgs e)
    {
        ExportToExcel();

    }

    protected void ExportToExcel()
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Report " + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                Government.Visible = true;
                divPrint.Style["width"] = "680px";
                Button1.Visible = false;
                Button2.Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                divPrint.RenderControl(hw);
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

    protected void ExportToExcel(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=R6.1: TSiPASS- District Wise Report.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        Government.Visible = true;
        divPrint.Style["width"] = "680px";
        Button1.Visible = false;
        Button2.Visible = false;
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            grdDetails.AllowPaging = false;
            this.fillgrid();

            grdDetails.HeaderRow.BackColor = System.Drawing.Color.White;
            foreach (TableCell cell in grdDetails.HeaderRow.Cells)
            {
                //cell.BackColor = grdDetails.HeaderStyle.BackColor;
                cell.ForeColor = System.Drawing.Color.Black;
            }
            foreach (TableCell cell in grdDetails.FooterRow.Cells)
            {
                cell.BackColor = System.Drawing.Color.White;
                cell.ForeColor = System.Drawing.Color.Black;
                // cell.
            }


            foreach (TableCell cell in grdDetails.FooterRow.Cells)
            {

                cell.CssClass = "textmode";
                List<Control> controls = new List<Control>();
                foreach (Control control in cell.Controls)
                {
                    switch (control.GetType().Name)
                    {
                        case "HyperLink":
                            controls.Add(control);
                            break;
                        case "TextBox":
                            controls.Add(control);
                            break;
                        case "LinkButton":
                            controls.Add(control);
                            break;
                        case "CheckBox":
                            controls.Add(control);
                            break;
                        case "RadioButton":
                            controls.Add(control);
                            break;
                    }
                }
                foreach (Control control in controls)
                {
                    switch (control.GetType().Name)
                    {
                        case "HyperLink":
                            cell.Controls.Add(new Literal { Text = (control as HyperLink).Text });
                            break;
                        case "TextBox":
                            cell.Controls.Add(new Literal { Text = (control as TextBox).Text });
                            break;
                        case "LinkButton":
                            cell.Controls.Add(new Literal { Text = (control as LinkButton).Text });
                            break;
                        case "CheckBox":
                            cell.Controls.Add(new Literal { Text = (control as CheckBox).Text });
                            break;
                        case "RadioButton":
                            cell.Controls.Add(new Literal { Text = (control as RadioButton).Text });
                            break;
                    }
                    cell.Controls.Remove(control);
                }
            }
            foreach (GridViewRow row in grdDetails.Rows)
            {
                row.BackColor = System.Drawing.Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = grdDetails.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = grdDetails.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                    List<Control> controls = new List<Control>();
                    foreach (Control control in cell.Controls)
                    {
                        switch (control.GetType().Name)
                        {
                            case "HyperLink":
                                controls.Add(control);
                                break;
                            case "TextBox":
                                controls.Add(control);
                                break;
                            case "LinkButton":
                                controls.Add(control);
                                break;
                            case "CheckBox":
                                controls.Add(control);
                                break;
                            case "RadioButton":
                                controls.Add(control);
                                break;
                        }
                    }
                    foreach (Control control in controls)
                    {
                        switch (control.GetType().Name)
                        {
                            case "HyperLink":
                                cell.Controls.Add(new Literal { Text = (control as HyperLink).Text });
                                break;
                            case "TextBox":
                                cell.Controls.Add(new Literal { Text = (control as TextBox).Text });
                                break;
                            case "LinkButton":
                                cell.Controls.Add(new Literal { Text = (control as LinkButton).Text });
                                break;
                            case "CheckBox":
                                cell.Controls.Add(new Literal { Text = (control as CheckBox).Text });
                                break;
                            case "RadioButton":
                                cell.Controls.Add(new Literal { Text = (control as RadioButton).Text });
                                break;
                        }
                        cell.Controls.Remove(control);
                    }
                }
            }

            divPrint.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }

    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        StringWriter stringWriter = new StringWriter();
        HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
        divPrint.RenderControl(htmlTextWriter);

        StringReader stringReader = new StringReader(stringWriter.ToString());
        Document Doc = new Document(PageSize.A4, 100f, 100f, 100f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(Doc);
        PdfWriter.GetInstance(Doc, Response.OutputStream);

        Doc.Open();
        htmlparser.Parse(stringReader);
        Doc.Close();
        Response.Write(Doc);
        Response.End();
    }
}
