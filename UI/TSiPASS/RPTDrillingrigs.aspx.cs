using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class UI_TSiPASS_RPTDrillingrigs : System.Web.UI.Page
{
    int totrw_TotalAppl, totrw_pendingprescruityAppl, totrw_QueryRaisedappl, totrw_Queryrespondedappl,
    totrw_approvedappl, totrw_rejectedappl, totrw_QueryRaisedcurrappl, totrw_Queryrespondedcurrappl,
    totrw_applrecievednotaction14days, totrw_Querraisebutnoresp7days, totrw_Querrespondednoaction7days;

    string DistrictID="%";
    Cls_DrillingRigs Gen = new Cls_DrillingRigs(); 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

                if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
                {
                    DistrictID = Convert.ToString(Session["DistrictID"]);
                }
            
            fillgrid();
        }
    }

    protected void btnGet_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    public void fillgrid()
    {
        DataSet vehicleDS = new DataSet();
        vehicleDS = Gen.DB_getrpdistrictwise(DistrictID);
        grdDetails.DataSource = vehicleDS;
        grdDetails.DataBind();
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string DistrictID=Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictID"));
            string DistrictName=Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictName"));
            
                

            HyperLink hyp_totalappl = (HyperLink)e.Row.FindControl("hyp_totalappl");
            hyp_totalappl.NavigateUrl = "RptDrillingApplicationlistReport.aspx?Typedataofappl=totalappl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Total Applications";
           
            HyperLink hyp_pendingprescruityAppl = (HyperLink)e.Row.FindControl("hyp_pendingprescruityAppl");
            hyp_pendingprescruityAppl.NavigateUrl = "RptDrillingApplicationlistReport.aspx?Typedataofappl=pendingprescruityAppl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Presrunity Pending";
           
            HyperLink hyp_applrecievednotaction14days = (HyperLink)e.Row.FindControl("hyp_applrecievednotaction14days");
            hyp_applrecievednotaction14days.NavigateUrl = "RptDrillingApplicationlistReport.aspx?Typedataofappl=applrecievednotaction14days&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Pre-Scrunity Pending after 14 Days";
            
            HyperLink hyp_QueryRaisedappl = (HyperLink)e.Row.FindControl("hyp_QueryRaisedappl");
            hyp_QueryRaisedappl.NavigateUrl = "RptDrillingApplicationlistReport.aspx?Typedataofappl=QueryRaisedappl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Total Query Raised  For Applications";
           
            HyperLink hyp_QueryRaisedcurrappl = (HyperLink)e.Row.FindControl("hyp_QueryRaisedcurrappl");
            hyp_QueryRaisedcurrappl.NavigateUrl = "RptDrillingApplicationlistReport.aspx?Typedataofappl=QueryRaisedcurrappl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Current Query Raised Applications";
            
            HyperLink hyp_Querraisebutnoresp7days = (HyperLink)e.Row.FindControl("hyp_Querraisebutnoresp7days");
            hyp_Querraisebutnoresp7days.NavigateUrl = "RptDrillingApplicationlistReport.aspx?Typedataofappl=Querraisebutnoresp7days&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Query raised, no response within 7 days From Applicants";
           
            HyperLink hyp_Queryrespondedappl = (HyperLink)e.Row.FindControl("hyp_Queryrespondedappl");
            hyp_Queryrespondedappl.NavigateUrl = "RptDrillingApplicationlistReport.aspx?Typedataofappl=Queryrespondedappl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Total Query Responded Application";
           
            HyperLink hyp_Queryrespondedcurrappl = (HyperLink)e.Row.FindControl("hyp_Queryrespondedcurrappl");
            hyp_Queryrespondedcurrappl.NavigateUrl = "RptDrillingApplicationlistReport.aspx?Typedataofappl=Queryrespondedcurrappl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Current Query Responded Application";
           
            HyperLink hyp_Querrespondednoaction7days = (HyperLink)e.Row.FindControl("hyp_Querrespondednoaction7days");
            hyp_Querrespondednoaction7days.NavigateUrl = "RptDrillingApplicationlistReport.aspx?Typedataofappl=Querrespondednoaction7days&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Query Responded,No action Taken within 7 days";
           
            HyperLink hyp_approvedappl = (HyperLink)e.Row.FindControl("hyp_approvedappl");
            hyp_approvedappl.NavigateUrl = "RptDrillingApplicationlistReport.aspx?Typedataofappl=approvedappl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Total Approved Application";
           
            HyperLink hyp_rejectedappl = (HyperLink)e.Row.FindControl("hyp_rejectedappl");
            hyp_rejectedappl.NavigateUrl = "RptDrillingApplicationlistReport.aspx?Typedataofappl=rejectedappl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Total Rejected Applications";

            int TotalAppl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalAppl"));
            totrw_TotalAppl = TotalAppl + totrw_TotalAppl;
            int pendingprescruityAppl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "pendingprescruityAppl"));
            totrw_pendingprescruityAppl = pendingprescruityAppl + totrw_pendingprescruityAppl;
            int QueryRaisedappl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "QueryRaisedappl"));
            totrw_QueryRaisedappl = QueryRaisedappl + totrw_QueryRaisedappl;
            int Queryrespondedappl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Queryrespondedappl"));
            totrw_Queryrespondedappl = Queryrespondedappl + totrw_Queryrespondedappl;
            int approvedappl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "approvedappl"));
            totrw_approvedappl = approvedappl + totrw_approvedappl;
            int rejectedappl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "rejectedappl"));
            totrw_rejectedappl = rejectedappl + totrw_rejectedappl;
            int QueryRaisedcurrappl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "QueryRaisedcurrappl"));
            totrw_QueryRaisedcurrappl = QueryRaisedcurrappl + totrw_QueryRaisedcurrappl;
            int Queryrespondedcurrappl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Queryrespondedcurrappl"));
            totrw_Queryrespondedcurrappl = Queryrespondedcurrappl + totrw_Queryrespondedcurrappl;
            int applrecievednotaction14days = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "applrecievednotaction14days"));
            totrw_applrecievednotaction14days = applrecievednotaction14days + totrw_applrecievednotaction14days;
            int Querraisebutnoresp7days = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Querraisebutnoresp7days"));
            totrw_Querraisebutnoresp7days = Querraisebutnoresp7days + totrw_Querraisebutnoresp7days;
            int Querrespondednoaction7days = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Querrespondednoaction7days"));
            totrw_Querrespondednoaction7days = Querrespondednoaction7days + totrw_Querrespondednoaction7days;

        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Grand Total";
            e.Row.Cells[2].Text = totrw_TotalAppl.ToString();
            e.Row.Cells[3].Text = totrw_pendingprescruityAppl.ToString();
            e.Row.Cells[4].Text = totrw_applrecievednotaction14days.ToString();
            e.Row.Cells[5].Text = totrw_QueryRaisedappl.ToString();
            e.Row.Cells[6].Text = totrw_QueryRaisedcurrappl.ToString();
            e.Row.Cells[7].Text = totrw_Querraisebutnoresp7days.ToString();
            e.Row.Cells[8].Text = totrw_Queryrespondedappl.ToString();
            e.Row.Cells[9].Text = totrw_Queryrespondedcurrappl.ToString();
            e.Row.Cells[10].Text = totrw_Querrespondednoaction7days.ToString();
            e.Row.Cells[11].Text = totrw_approvedappl.ToString();
            e.Row.Cells[12].Text = totrw_rejectedappl.ToString();


            HyperLink h1 = new HyperLink();
            h1.Text = totrw_TotalAppl.ToString();
            if (h1.Text != "0")
            {
                h1.NavigateUrl = "RptDrillingApplicationlistReport.aspx?Typedataofappl=totalappl&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Total Applications";
                e.Row.Cells[2].Controls.Add(h1);
            }

            HyperLink h2 = new HyperLink();
            h2.Text = totrw_pendingprescruityAppl.ToString();
            if (h2.Text != "0")
            {
                h2.NavigateUrl = "RptDrillingApplicationlistReport.aspx?Typedataofappl=pendingprescruityAppl&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Presrunity Pending";
                e.Row.Cells[3].Controls.Add(h2);
            }
            
            HyperLink h3 = new HyperLink();
            h3.Text = totrw_applrecievednotaction14days.ToString();
            if (h3.Text != "0")
            {
                h3.NavigateUrl = "RptDrillingApplicationlistReport.aspx?Typedataofappl=applrecievednotaction14days&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Pre-Scrunity Pending after 14 Days";
                e.Row.Cells[4].Controls.Add(h3);
            }
           
            HyperLink h4 = new HyperLink();
            h4.Text = totrw_QueryRaisedappl.ToString();
            if (h4.Text != "0")
            {
                h4.NavigateUrl = "RptDrillingApplicationlistReport.aspx?Typedataofappl=QueryRaisedappl&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Total Query Raised  For Applications";
                e.Row.Cells[5].Controls.Add(h4);
            }
            
            HyperLink h5 = new HyperLink();
            h5.Text = totrw_QueryRaisedcurrappl.ToString();
            if (h5.Text != "0")
            {
                h5.NavigateUrl = "RptDrillingApplicationlistReport.aspx?Typedataofappl=QueryRaisedcurrappl&DistrictID=ALL"+ "&DistrictName=ALL" + "&Category=Current Query Raised Applications";
                e.Row.Cells[6].Controls.Add(h5);
            }
           
            HyperLink h6 = new HyperLink();
            h6.Text = totrw_Querraisebutnoresp7days.ToString();
            if (h6.Text != "0")
            {
                h6.NavigateUrl = "RptDrillingApplicationlistReport.aspx?Typedataofappl=Querraisebutnoresp7days&DistrictID=ALL"+ "&DistrictName=ALL" + "&Category=Query raised, no response within 7 days From Applicants";
                e.Row.Cells[7].Controls.Add(h6);
            }
           
            HyperLink h7 = new HyperLink();
            h7.Text = totrw_Queryrespondedappl.ToString();
            if (h7.Text != "0")
            {
                h7.NavigateUrl = "RptDrillingApplicationlistReport.aspx?Typedataofappl=Queryrespondedappl&DistrictID=ALL"+ "&DistrictName=ALL" + "&Category=Total Query Responded Application";
                e.Row.Cells[8].Controls.Add(h7);
            }
           
            HyperLink h8 = new HyperLink();
            h8.Text = totrw_Queryrespondedcurrappl.ToString();
            if (h8.Text != "0")
            {
                 h8.NavigateUrl = "RptDrillingApplicationlistReport.aspx?Typedataofappl=Queryrespondedcurrappl&DistrictID=ALL"+ "&DistrictName=ALL" + "&Category=Current Query Responded Application";

                e.Row.Cells[9].Controls.Add(h8);
            }
            
            HyperLink h9 = new HyperLink();
            h9.Text = totrw_Querrespondednoaction7days.ToString();
            if (h9.Text != "0")
            {
                  h9.NavigateUrl = "RptDrillingApplicationlistReport.aspx?Typedataofappl=Querrespondednoaction7days&DistrictID=ALL"+ "&DistrictName=ALL" + "&Category=Query Responded,No action Taken within 7 days";

                e.Row.Cells[10].Controls.Add(h9);
            }
           
            HyperLink h10 = new HyperLink();
            h10.Text = totrw_approvedappl.ToString();
            if (h10.Text != "0")
            {
                 h10.NavigateUrl = "RptDrillingApplicationlistReport.aspx?Typedataofappl=approvedappl&DistrictID=ALL"+ "&DistrictName=ALL" + "&Category=Total Approved Application";

                e.Row.Cells[11].Controls.Add(h10);
            }
          
            HyperLink h11 = new HyperLink();
            h11.Text = totrw_rejectedappl.ToString();
            if (h11.Text != "0")
            {
                 h11.NavigateUrl = "RptDrillingApplicationlistReport.aspx?Typedataofappl=rejectedappl&DistrictID=ALL"+ "&DistrictName=ALL" + "&Category=Total Rejected Applications";
                e.Row.Cells[12].Controls.Add(h11);
            }




            h1.ForeColor = System.Drawing.Color.White;
            h2.ForeColor = System.Drawing.Color.White;
            h3.ForeColor = System.Drawing.Color.White;
            h4.ForeColor = System.Drawing.Color.White;
            h5.ForeColor = System.Drawing.Color.White;
            h6.ForeColor = System.Drawing.Color.White;
            h7.ForeColor = System.Drawing.Color.White;
            h8.ForeColor = System.Drawing.Color.White;
            h9.ForeColor = System.Drawing.Color.White;
            h10.ForeColor = System.Drawing.Color.White;
            h11.ForeColor = System.Drawing.Color.White;
        }
    }
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow gvHeaderRow = e.Row;
            GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            this.grdDetails.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

            int headerCellCount = gvHeaderRow.Cells.Count;
            int cellIndex = 0;

            for (int i = 0; i < headerCellCount; i++)
            {
                if (i >2 &&i<11)
                {
                    cellIndex++;
                }
                else
                {
                    TableCell tcHeader = gvHeaderRow.Cells[cellIndex];
                    //if (i == 0 || i == 1 || i == 2)
                    //{
                        tcHeader.RowSpan = 2;
                        gvHeaderRowCopy.Cells.Add(tcHeader);
                    
                  
                }
            }

            TableCell tcMergePackage = new TableCell();
            tcMergePackage.Text = "Presrunity Pending Applications";
            tcMergePackage.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(3, tcMergePackage);

            TableCell tcMergePackage1 = new TableCell();
            tcMergePackage1.Text = "Query Raised Applications";
            tcMergePackage1.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage1.ColumnSpan = 3;
            gvHeaderRowCopy.Cells.AddAt(4, tcMergePackage1);

            TableCell tcMergePackage2 = new TableCell();
            tcMergePackage2.Text = "Query Responded Applications";
            tcMergePackage2.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage2.ColumnSpan =3;
            gvHeaderRowCopy.Cells.AddAt(5, tcMergePackage2);

        }
    }
    protected void BtnSave2_Click(object sender, EventArgs e)
    {
        ExportToExcel();
        // fillgrid();

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
            //  Government.Visible = true;
            tr1.Style["width"] = "680px";
            // Button1.Visible = false;
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
    protected void BtnPDF_Click(object sender, EventArgs e)
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
                    //this.FillGridDetails(rbtnlstInputType.SelectedValue.ToString().Trim(), ddlFinancialYear.SelectedValue.ToString().Trim(), FromdateforDB, TodateforDB);
                    grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.FooterRow.Visible = true;
                    grdDetails.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename= R1.5_Month_wise_Applications_Received" + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
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

    
  


}