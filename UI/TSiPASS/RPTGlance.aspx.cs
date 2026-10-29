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
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

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
        Label2.Text = "Last Updated by CoI on " + ds.Tables[0].Rows[0]["ModifiedDate"].ToString().Trim();
        if (!IsPostBack)
        {
            //BindGraphChart();
            //BindPieChart();
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
        
        dsnew = Gen.GetRptGlance();
       // lblMsg.Text = "";
        if (dsnew.Tables[0].Rows.Count > 0)
        {
           // lblMsg.Text = "Total Records :" +dsnew.Tables[0].Rows.Count.ToString();
            Label1.Text = "Report from 01-Jan-2015 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
            //grdDetails.DataSource = dsnew.Tables[0];
            //grdDetails.DataBind();
            lblnumber.Text = dsnew.Tables[4].Rows[0]["Number"].ToString().Trim();
            lblinv.Text = dsnew.Tables[4].Rows[0]["Investment"].ToString().Trim();
            lblEmp.Text = dsnew.Tables[4].Rows[0]["Employment"].ToString().Trim();

            lblCO.Text = dsnew.Tables[0].Rows[0]["cmo"].ToString().Trim();
            lblas.Text = dsnew.Tables[1].Rows[0]["advstg"].ToString().Trim();
            lblis.Text = dsnew.Tables[2].Rows[0]["instg"].ToString().Trim();
            lblyet.Text = dsnew.Tables[3].Rows[0]["yetstart"].ToString().Trim();
            
        }
        else
        {
            //lblMsg.Text = "";
            Label1.Text = "No Recards Found ";
            //grdDetails.DataSource = null;
            //grdDetails.DataBind();

        }

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

    protected void BtnSave2_Click(object sender, EventArgs e)
    {
      //  ExportToExcel();

    }

    //protected void ExportToExcel()
    //{
    //    try
    //    {
    //        Response.Clear();
    //        Response.Buffer = true;
    //        Response.AddHeader("content-disposition", "attachment;filename=R7.3: TSiPASS - Progress Of Implementation Report.xls");
    //        Response.Charset = "";
    //        Response.ContentType = "application/vnd.ms-excel";
    //        Government.Visible = true;
    //        divPrint.Style["width"] = "680px";
    //        Button1.Visible = false;
    //        Button2.Visible = false;
    //        using (StringWriter sw = new StringWriter())
    //        {
    //            HtmlTextWriter hw = new HtmlTextWriter(sw);

    //            To Export all pages
    //            grdDetails.AllowPaging = false;
    //            this.fillgrid();

    //            grdDetails.HeaderRow.BackColor = System.Drawing.Color.White;
    //            foreach (TableCell cell in grdDetails.HeaderRow.Cells)
    //            {
    //                //cell.BackColor = grdDetails.HeaderStyle.BackColor;
    //                cell.ForeColor = System.Drawing.Color.Black;
    //            }
    //            foreach (TableCell cell in grdDetails.FooterRow.Cells)
    //            {
    //                cell.BackColor = System.Drawing.Color.White;
    //                cell.ForeColor = System.Drawing.Color.Black;
    //                // cell.
    //            }


    //            foreach (TableCell cell in grdDetails.FooterRow.Cells)
    //            {

    //                cell.CssClass = "textmode";
    //                List<Control> controls = new List<Control>();
    //                foreach (Control control in cell.Controls)
    //                {
    //                    switch (control.GetType().Name)
    //                    {
    //                        case "HyperLink":
    //                            controls.Add(control);
    //                            break;
    //                        case "TextBox":
    //                            controls.Add(control);
    //                            break;
    //                        case "LinkButton":
    //                            controls.Add(control);
    //                            break;
    //                        case "CheckBox":
    //                            controls.Add(control);
    //                            break;
    //                        case "RadioButton":
    //                            controls.Add(control);
    //                            break;
    //                    }
    //                }
    //                foreach (Control control in controls)
    //                {
    //                    switch (control.GetType().Name)
    //                    {
    //                        case "HyperLink":
    //                            cell.Controls.Add(new Literal { Text = (control as HyperLink).Text });
    //                            break;
    //                        case "TextBox":
    //                            cell.Controls.Add(new Literal { Text = (control as TextBox).Text });
    //                            break;
    //                        case "LinkButton":
    //                            cell.Controls.Add(new Literal { Text = (control as LinkButton).Text });
    //                            break;
    //                        case "CheckBox":
    //                            cell.Controls.Add(new Literal { Text = (control as CheckBox).Text });
    //                            break;
    //                        case "RadioButton":
    //                            cell.Controls.Add(new Literal { Text = (control as RadioButton).Text });
    //                            break;
    //                    }
    //                    cell.Controls.Remove(control);
    //                }
    //            }
    //            foreach (GridViewRow row in grdDetails.Rows)
    //            {
    //                row.BackColor = System.Drawing.Color.White;
    //                foreach (TableCell cell in row.Cells)
    //                {
    //                    if (row.RowIndex % 2 == 0)
    //                    {
    //                        cell.BackColor = grdDetails.AlternatingRowStyle.BackColor;
    //                    }
    //                    else
    //                    {
    //                        cell.BackColor = grdDetails.RowStyle.BackColor;
    //                    }
    //                    cell.CssClass = "textmode";
    //                    List<Control> controls = new List<Control>();
    //                    foreach (Control control in cell.Controls)
    //                    {
    //                        switch (control.GetType().Name)
    //                        {
    //                            case "HyperLink":
    //                                controls.Add(control);
    //                                break;
    //                            case "TextBox":
    //                                controls.Add(control);
    //                                break;
    //                            case "LinkButton":
    //                                controls.Add(control);
    //                                break;
    //                            case "CheckBox":
    //                                controls.Add(control);
    //                                break;
    //                            case "RadioButton":
    //                                controls.Add(control);
    //                                break;
    //                        }
    //                    }
    //                    foreach (Control control in controls)
    //                    {
    //                        switch (control.GetType().Name)
    //                        {
    //                            case "HyperLink":
    //                                cell.Controls.Add(new Literal { Text = (control as HyperLink).Text });
    //                                break;
    //                            case "TextBox":
    //                                cell.Controls.Add(new Literal { Text = (control as TextBox).Text });
    //                                break;
    //                            case "LinkButton":
    //                                cell.Controls.Add(new Literal { Text = (control as LinkButton).Text });
    //                                break;
    //                            case "CheckBox":
    //                                cell.Controls.Add(new Literal { Text = (control as CheckBox).Text });
    //                                break;
    //                            case "RadioButton":
    //                                cell.Controls.Add(new Literal { Text = (control as RadioButton).Text });
    //                                break;
    //                        }
    //                        cell.Controls.Remove(control);
    //                    }
    //                }
    //            }

    //            divPrint.RenderControl(hw);

    //            style to format numbers to string
    //            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
    //            Response.Write(style);
    //            Response.Output.Write(sw.ToString());
    //            Response.Flush();
    //            Response.End();
    //        }
    //        Response.Clear();
    //        Response.Buffer = true;
    //        Response.AddHeader("content-disposition", "attachment;filename=Report " + DateTime.Now.ToString("M/d/yyyy") + ".xls");
    //        Response.Charset = "";
    //        Response.ContentType = "application/vnd.ms-excel";
    //        using (StringWriter sw = new StringWriter())
    //        {
    //            Button2.Visible = false;
    //            Button1.Visible = false;
    //            HtmlTextWriter hw = new HtmlTextWriter(sw);
    //            divPrint.RenderControl(hw);
    //            Response.Output.Write(sw.ToString());
    //            Response.Flush();
    //            Response.End();
    //        }
    //    }
    //    catch (Exception e)
    //    {

    //    }
    //}

    

    public override void VerifyRenderingInServerForm(Control control)
    {
    } 
}
