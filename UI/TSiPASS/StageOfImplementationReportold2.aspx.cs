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
using System.Drawing;
using System.Collections.Generic;

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
        //if (Session.Count <= 0)
        //{
        //    Response.Redirect("../../frmUserLogin.aspx");
        //}
        DataSet ds = new DataSet();
        ds = Gen.GetmodifiedDate();
        Label2.Text = "Last Updated on : " + ds.Tables[0].Rows[0]["ModifiedDate"].ToString().Trim();
        if (!IsPostBack)
        {
            //BindGraphChart();
            BindPieChart();
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

        dsnew = Gen.FetchStageOfImplementationwise_New(ddlType.SelectedValue);
       // lblMsg.Text = "";
        if (dsnew.Tables[0].Rows.Count > 0)
        {
           // lblMsg.Text = "Total Records :" +dsnew.Tables[0].Rows.Count.ToString();
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

    private void BindPieChart()
    {
        DataTable dsChartData = new DataTable();
        StringBuilder strScript = new StringBuilder();

        try
        {

            dsChartData = Gen.FetchStageOfImplementationwise_New(ddlType.SelectedValue).Tables[0];

            strScript.Append(@"<script type='text/javascript'>  
                    google.load('visualization', '1', {packages: ['corechart']}); </script>  
                      
                    <script type='text/javascript'>  
                     
                    function drawChart() {         
                    var data = google.visualization.arrayToDataTable([  
                    ['Progress', 'Number'],");

            foreach (DataRow row in dsChartData.Rows)
            {
                strScript.Append("['" + row["Progress"] + "'," + row["Number"] + "],");
            }
            strScript.Remove(strScript.Length - 1, 1);
            strScript.Append("]);");

            strScript.Append(@" var options = {     
                                         title: 'No of Industries/ Stage',        
                                    pieHole: 0.4,          
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

    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        fillgrid();
    }

//    private void BindGraphChart()
//    {
//        DataTable dsChartData = new DataTable();
//        StringBuilder strScript = new StringBuilder();

//        try
//        {
//            dsChartData = Gen.FetchStageOfImplementationwise_Old().Tables[0];

//            strScript.Append(@"<script type='text/javascript'>  
//                    google.load('visualization', '1', {packages: ['corechart']});</script>  
//  
//                    <script type='text/javascript'>  
//                    function drawVisualization() {         
//                    var data = google.visualization.arrayToDataTable([  
//                    ['Progress', 'Number', 'Investment', 'Employment'],");

//            foreach (DataRow row in dsChartData.Rows)
//            {
//                strScript.Append("['" + row["Progress"] + "'," + row["Number"] + "," +
//                    row["Investment"] + "," + row["Employment"] + "],");
//            }
//            strScript.Remove(strScript.Length - 1, 1);
//            strScript.Append("]);");

//            strScript.Append("var options = { title : 'Progress', width: 600,  height: 400,bar: {groupWidth: '95%' },legend: { position: 'none' };");
//            strScript.Append(" var chart = new google.visualization.ColumnChart(document.getElementById('columnchart_values')); chart.draw(view, options)");
//            strScript.Append(" </script>");

//            ltrGraph.Text = strScript.ToString();
//        }
//        catch
//        {
//        }
//        finally
//        {
//            dsChartData.Dispose();

//        }
//    }

   
   
 
  
    //protected void BtnSave1_Click(object sender, EventArgs e)
    //{
    //    ds = Gen.FetchInspectionProgressRpt();
    //    grdDetails.DataSource = ds.Tables[0];
    //    grdDetails.DataBind();
    //}
   
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
            h1.NavigateUrl = "FrmStageDrilldownold2.aspx?status=" + ddlType.SelectedValue.ToString() + "&lbl=Application Received&Stage=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Progress")).Trim();

            HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
            h2.NavigateUrl = "FrmStageDrilldownold2.aspx?status=" + ddlType.SelectedValue.ToString() + "&lbl=Application Received&Stage=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Progress")).Trim();

            HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
            h3.NavigateUrl = "FrmStageDrilldownold2.aspx?status=" + ddlType.SelectedValue.ToString() + "&lbl=Application Received&Stage=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Progress")).Trim();

           


        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {

            e.Row.Cells[1].Text = "Total";
            HyperLink Total = new HyperLink();
            Total.ForeColor = System.Drawing.Color.White;
            Total.NavigateUrl = "FrmStageDrilldownold2.aspx?status=" + ddlType.SelectedValue.ToString() + "&lbl=Total Applications Received&dist=%";
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
            Response.AddHeader("content-disposition", "attachment;filename=R6.3: TSiPASS - Progress Of Implementation Report.xls");
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
            //Response.Clear();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment;filename=Report " + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-excel";
            //using (StringWriter sw = new StringWriter())
            //{
            //    Button2.Visible = false;
            //    Button1.Visible = false;
            //    HtmlTextWriter hw = new HtmlTextWriter(sw);
            //    divPrint.RenderControl(hw);
            //    Response.Output.Write(sw.ToString());
            //    Response.Flush();
            //    Response.End();
            //}
        }
        catch (Exception e)
        {

        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    } 
}
