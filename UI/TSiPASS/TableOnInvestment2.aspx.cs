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

//created by suresh as on 1-17-2016 for county adm lookup 
//tables td_CountyAdmDet,getCASearch


public partial class LookupCA : System.Web.UI.Page
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
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");

        }
        DataSet ds = new DataSet();
        ds = Gen.GetmodifiedDate();
        Label2.Text = "Last Updated on : " + ds.Tables[0].Rows[0]["ModifiedDate"].ToString().Trim();
        if (!IsPostBack)
        {
           // BindChart();
            fillgrid();
        }
        
    }
    #endregion

//    private void BindChart()
//    {
//        DataTable dsChartData = new DataTable();
//        StringBuilder strScript = new StringBuilder();

//        try
//        {
//            dsChartData = Gen.FetchTableOnInvestment().Tables[0];

//            strScript.Append(@"<script type='text/javascript'>  
//                    google.load('visualization', '1', {packages: ['corechart', 'line']});</script>  
//  
//                    <script type='text/javascript'>  
//                    function drawVisualization() {         
//                    var data = google.visualization.arrayToDataTable([  
//                    ['Investment Range (Rs. in Cr)',  'Investment (Rs. in Cr)','Total Employment'],");

//            foreach (DataRow row in dsChartData.Rows)
//            {
//                strScript.Append("['" + row["InvestmentRange"] + "'," + row["Investment"] + "," + row["Employment"] + "],");
//            }
//            strScript.Remove(strScript.Length - 1, 1);
//            strScript.Append("]);");

//            strScript.Append("var options = { title : 'Table On Investment', vAxis: {title: 'Investment (Rs. in Cr)'},  hAxis: {title: 'Investment Range (Rs. in Cr)'}};");
//            strScript.Append(" var chart = new google.visualization.LineChart(document.getElementById('chart_div'));  chart.draw(data, options); } google.setOnLoadCallback(drawVisualization);");
//            strScript.Append(" </script>");

//            ltScripts.Text = strScript.ToString();
//        }
//        catch
//        {
//        }
//        finally
//        {
//            dsChartData.Dispose();
//            // strScript.Clear();
//        }
//    } 
    public void fillgrid()
    {

        DataSet dsnew = new DataSet();

        dsnew = Gen.FetchTableOnInvestment_New(ddlType.SelectedValue);
       // lblMsg.Text = "";
        if (dsnew.Tables[0].Rows.Count > 0)
        {
           // lblMsg.Text = "Total Label1.Text = "Report from 1st April 2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");Records :" +dsnew.Tables[0].Rows.Count.ToString();
            if (ddlType.SelectedValue == "3")
            {
                Label1.Text = "Report from 01-April-2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
            }
            else
            {
                Label1.Text = "Report from 01-Jan-2015 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
            }
            grdDetails.DataSource = dsnew.Tables[0];
            grdDetails.DataBind();


        }
        else
        {
            //lblMsg.Text = "";
            Label1.Text = "No Recards Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }

    }

    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
   
 
  
    //protected void BtnSave1_Click(object sender, EventArgs e)
    //{
    //    ds = Gen.FetchInspectionProgressRpt();
    //    grdDetails.DataSource = ds.Tables[0];
    //    grdDetails.DataBind();
    //}

    private void AssignGridRowStyle(GridViewRow gr, string cssName)
    {
        try
        {
            if (gr.RowType == DataControlRowType.Header)
            {
                for (int cellIndex = 0; cellIndex < gr.Cells.Count; cellIndex++) gr.Cells[cellIndex].CssClass = "GridviewScrollC1Header";
            }
            else if (gr.RowType == DataControlRowType.Footer)
            {
                gr.CssClass = cssName;

                for (int cellIndex = 0; cellIndex < gr.Cells.Count; cellIndex++)
                {
                    gr.Cells[cellIndex].CssClass = cssName;

                    try
                    {
                        double d;
                        if (Double.TryParse(gr.Cells[cellIndex].Text, out d)) gr.Cells[cellIndex].CssClass = "algnCenter";
                    }
                    catch (Exception) { }
                }
            }
            else
            {
                gr.CssClass = cssName;

                for (int cellIndex = 0; cellIndex < gr.Cells.Count; cellIndex++)
                {
                    gr.Cells[cellIndex].CssClass = cssName;

                    try
                    {
                        double d;

                        if (Double.TryParse(gr.Cells[cellIndex].Text, out d)) gr.Cells[cellIndex].CssClass = "algnCenter";

                    }
                    catch (Exception) { }
                }
            }
        }
        catch (Exception) { }
    }
   
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Header");
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Item");
            
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal NumberTotal1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Number"));
            NumberTotal = NumberTotal1 + NumberTotal;

            decimal InvestmnetTotal1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Investment"));
            InvestmnetTotal = InvestmnetTotal1 + InvestmnetTotal;


            decimal EmploymentTotal1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Employment"));
            EmploymentTotal = EmploymentTotal1 + EmploymentTotal;


            HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
            h1.NavigateUrl = "TableOnInvestmentDill2.aspx?status=" + ddlType.SelectedValue.ToString() + "&lbl=Application Received&Stage=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "InvestmentRange")).Trim();

            HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
            h2.NavigateUrl = "TableOnInvestmentDill2.aspx?status=" + ddlType.SelectedValue.ToString() + "&lbl=Application Received&Stage=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "InvestmentRange")).Trim();

            HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
            h3.NavigateUrl = "TableOnInvestmentDill2.aspx?status=" + ddlType.SelectedValue.ToString() + "&lbl=Application Received&Stage=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "InvestmentRange")).Trim();



        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {

            e.Row.Cells[1].Text = "Total";
            HyperLink Total = new HyperLink();
            Total.ForeColor = System.Drawing.Color.White;
            Total.NavigateUrl = "TableOnInvestmentDill2.aspx?status=" + ddlType.SelectedValue.ToString() + "&lbl=Total Applications Received&Stage=%";
            Total.Text = NumberTotal.ToString();
            //e.Row.Cells[2].Controls.RemoveAt(0);
            e.Row.Cells[2].Controls.Add(Total);
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
                Button1.Visible = false;
                Button2.Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                divPrint.RenderControl(hw);
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
}
