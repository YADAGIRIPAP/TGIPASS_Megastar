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
using System.Text;

public partial class UI_TSiPASS_CommissionerReportDashboard : System.Web.UI.Page
{
    decimal NumberTotal, InvestmnetTotal, EmploymentTotal, CFOApplied, InsentiveApplied,claim;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CFE_CFO_INC();
            Barchart();
        }
        lbllabel.Text = DateTime.Now.ToString("dd-MM-yyyy");

      
    }
    public void CFE_CFO_INC()
    {
        string conString = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        SqlDataAdapter da = new SqlDataAdapter("sp_CFE_CFO_INCApplied", conString);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grdDetails.DataSource = ds.Tables[0];
        grdDetails.DataBind();
    }

    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        ExportToExcel();
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
                    grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.Columns[1].Visible = false;
                    grdDetails.RenderControl(hw);
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

    protected void Button2_ServerClick(object sender, EventArgs e)
    {
        PrintPdf();
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

        }
        catch (Exception e)
        {

        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

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
           

            decimal Total = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CFE"));
            NumberTotal = Total + NumberTotal;

            decimal investment = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Investment"));
            InvestmnetTotal = investment + InvestmnetTotal;

            decimal employee = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Employment"));
            EmploymentTotal = employee + EmploymentTotal;

            decimal CFO = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CFO"));
            CFOApplied = CFO + CFOApplied;

            decimal insentive = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "INC")); 
             InsentiveApplied = insentive + InsentiveApplied;

            decimal claims = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Claims"));
            claim = claims + claim;



            HyperLink h1 = (HyperLink)e.Row.Cells[3].Controls[0];

            string districtid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Distid")).Trim();
            string districtname = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtname")).Trim();

            if (h1.Text != "0")
            {
                h1.NavigateUrl = "CommissionerReportDashboardDrillDown.aspx?Distid=" + districtid + " & Districtname="+ districtname + " & Type = " + "CFE";
            }

           
            HyperLink h4 = (HyperLink)e.Row.Cells[6].Controls[0];

            string districtid1 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Distid")).Trim();
            string districtname1 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtname")).Trim();

            if (h4.Text != "0")
            {
                h4.NavigateUrl = "CommissionerReportDashboardDrillDown.aspx?Distid=" + districtid1 + " & Districtname=" + districtname1 + " & Type = " + "CFO";
            }

            HyperLink h6 = (HyperLink)e.Row.Cells[7].Controls[0];

            string districtid3 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Distid")).Trim();
            string districtname3 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtname")).Trim();

            if (h6.Text != "0")
            {
                h6.NavigateUrl = "CommissionerReportDashboardDrillDown.aspx?Distid=" + districtid3 + " & Districtname=" + districtname3 + " & Type = " + "INC";

            }



            HyperLink h5 = (HyperLink)e.Row.Cells[8].Controls[0];

            string districtid2 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Distid")).Trim();
            string districtname2 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Districtname")).Trim();

            if (h5.Text != "0")
            {
                h5.NavigateUrl = "CommissionerReportDashboardDrillDown.aspx?Distid=" + districtid2 + " & Districtname=" + districtname2 + " & Type = " + "Claims";

            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            string districtid = "%";
            string districtname = "%";


            e.Row.Cells[1].Text = "Total";
            HyperLink Total = new HyperLink();
            Total.ForeColor = System.Drawing.Color.White;

            if (Total.Text != "0")
            {
                Total.NavigateUrl = "CommissionerReportDashboardDrillDown.aspx?Distid=" + districtid + " & Districtname=" + districtname + " & Type = " + "CFE";
            }
            Total.Text = NumberTotal.ToString();
            e.Row.Cells[3].Text = NumberTotal.ToString();
            e.Row.Cells[3].Controls.Add(Total);                     

            HyperLink CFOAppli = new HyperLink();
            CFOAppli.ForeColor = System.Drawing.Color.White;

            if (CFOAppli.Text != "0")
            {
                CFOAppli.NavigateUrl = "CommissionerReportDashboardDrillDown.aspx?Distid=" + districtid + " & Districtname=" + districtname + " & Type = " + "CFO";
            }
            CFOAppli.Text = CFOApplied.ToString();
            e.Row.Cells[6].Text = CFOApplied.ToString(); 
            e.Row.Cells[6].Controls.Add(CFOAppli);

            HyperLink insetive = new HyperLink();
            insetive.ForeColor = System.Drawing.Color.White;
            if (insetive.Text != "0")
            {
                insetive.NavigateUrl = "CommissionerReportDashboardDrillDown.aspx?Distid=" + districtid + " & Districtname=" + districtname + " & Type = " + "Claims";
            }
            insetive.Text = claim.ToString();
            e.Row.Cells[8].Text = claim.ToString();
            e.Row.Cells[8].Controls.Add(insetive);

            e.Row.Cells[4].Text = InvestmnetTotal.ToString();
            e.Row.Cells[5].Text = EmploymentTotal.ToString();        

            HyperLink INC = new HyperLink();
            INC.ForeColor = System.Drawing.Color.White;

            if (INC.Text != "0")
            {
                INC.NavigateUrl = "CommissionerReportDashboardDrillDown.aspx?Distid=" + districtid + " & Districtname=" + districtname + " & Type = " + "INC";
            }
            INC.Text = InsentiveApplied.ToString();
            e.Row.Cells[7].Text = InsentiveApplied.ToString();
            e.Row.Cells[7].Controls.Add(INC);

        }
    }
    public void Barchart()
    {
        DataTable dsChartData = new DataTable();
        StringBuilder strScript = new StringBuilder();

        try
        {

          
            string conString = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
            SqlDataAdapter da = new SqlDataAdapter("sp_CFE_CFO_INCApplied", conString);
            DataSet ds = new DataSet();
            da.Fill(ds);         
            dsChartData = ds.Tables[0];

            strScript.Append(@"<script type='text/javascript'>  
                    google.load('visualization', '1', {packages: ['corechart']}); </script>  
                      
                    <script type='text/javascript'>  
                     
                    function drawChart() {         
                    var data = google.visualization.arrayToDataTable([  
                    ['Distid', 'CFE'],");

            foreach (DataRow row in dsChartData.Rows)
            {
                strScript.Append("['" + row["Distid"] + "'," + row["CFE"] + "],");
            }
            strScript.Remove(strScript.Length - 1, 1);
            strScript.Append("]);");

            strScript.Append(@" var options = {     
                                       title: 'CFE No of Industries/ Dist',  
                                   pieSliceText: 'value',
                                    legend: { position: 'bottom', maxLines: 5 },
                                    tooltip: {textStyle: {color: '#FF0000'}, showColorCode: true},    
                                    chartArea:{left:20,top:30,width:'100%',height:'75%'}   
                                                  
                                    };   ");

            strScript.Append(@"var chart = new google.visualization.PieChart(document.getElementById('piechart_3d'));          
                                chart.draw(data, options);        
                                }    
                            google.setOnLoadCallback(drawChart);  
                            ");
            strScript.Append(" </script>");


         //   ltrPie.Text = strScript.ToString();




            //strScript.Append(@"<script type='text/javascript'>  
            //        google.load('visualization', '1', {packages: ['corechart']}); 
            //      </script>  
            //      <script type='text/javascript'>  
            //        function drawChart() {         
            //          var data = google.visualization.arrayToDataTable([  
            //            ['Districtname', 'Distid', { role: 'style' }],");

            //foreach (DataRow row in dsChartData.Rows)
            //{
            //    strScript.Append("['" + row["Distid"] + "'," + row["Districtname"] + ", 'color: blue'],");
            //}
            //strScript.Remove(strScript.Length - 1, 1);
            //strScript.Append("]);");

            //strScript.Append(@" var options = {     
            //            title: 'Distid / Districtname', 
            //            pieslicetext:'value',
            //            legend: { position: 'bottom', maxLines: 5 },
            //            chartArea: { left: 20, top: 30, width: '70%', height: '60%' }                        
            //            };      ");
            ////bars: 'vertical', // This specifies vertical bars
            //hAxis: {
            //    title: 'Distid'
            //},
            //vAxis: {
            //    title: 'Districtname'

            //strScript.Append(@"var chart = new google.visualization.PieChart(document.getElementById('piechart_3d'));          
            //        chart.draw(data, options);        
            //      }    
            //      google.setOnLoadCallback(drawChart)");
            //strScript.Append("</script>");

            //ltrPie.Text = strScript.ToString();

        }
        catch
        {
            
        }
        finally
        {
            dsChartData.Dispose();
        }
    }
   
}