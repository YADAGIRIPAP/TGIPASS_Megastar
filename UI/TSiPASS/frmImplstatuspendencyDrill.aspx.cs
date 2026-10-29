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


public partial class UI_TSIPASS_frmImplstatuspendencyDrill : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {
            DataSet dsnew = new DataSet();
            string ONLINEFLAG = "", District = "", TSiPASSType = "", status = "", Year="";
            Label1.Text = "Report as on date " + DateTime.Now;

            status = Request.QueryString["status"].ToString();
            ONLINEFLAG = Request.QueryString["ApprovalType"].ToString();
            District = Request.QueryString["Dist"].ToString();
            TSiPASSType = Request.QueryString["Appltype"].ToString();
            Year = Request.QueryString["Year"].ToString();

            dsnew = GetAppealApplications(ONLINEFLAG, District, TSiPASSType, status, Year);
            if (dsnew.Tables[0].Rows.Count > 0)
            {
                lblmsg0.Text = "Total Records Found :" + dsnew.Tables[0].Rows.Count.ToString();
                grdDetails.DataSource = dsnew.Tables[0];
                grdDetails.DataBind();
            }
            else
            {
                lblmsg0.Text = "Total Records Found : 0";
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }

            if (status == "A")
            {
                lblHeading.Text = "Within The One Month - YET TO START CONSTRUCTION";
            }
            else if (status == "B")
            {
                lblHeading.Text = "One Month above - YET TO START CONSTRUCTION";
            }
            else if (status == "C")
            {
                lblHeading.Text = "Two Months above - YET TO START CONSTRUCTION";
            }
            if (status == "D")
            {
                lblHeading.Text = "Tree Months above - YET TO START CONSTRUCTION";
            }
            else if (status == "E")
            {
                lblHeading.Text = "Four Months above - YET TO START CONSTRUCTION";
            }
            else if (status == "F")
            {
                lblHeading.Text = "Five Months above - YET TO START CONSTRUCTION";
            }
            if (status == "G")
            {
                lblHeading.Text = "Six Months above - YET TO START CONSTRUCTION";
            }
          //---------------------------------------------------------------------------------------------------
            else if (status == "H")
            {
                lblHeading.Text = "Within The One Month - INITIAL STAGE";
            }
            else if (status == "I")
            {
                lblHeading.Text = "One Month above - INITIAL STAGE";
            }
            if (status == "J")
            {
                lblHeading.Text = "Two Months above - INITIAL STAGE";
            }
            else if (status == "K")
            {
                lblHeading.Text = "Tree Months above - INITIAL STAGE";
            }
            else if (status == "L")
            {
                lblHeading.Text = "Four Months above - INITIAL STAGE";
            }
            else if (status == "M")
            {
                lblHeading.Text = "Five Months above - INITIAL STAGE";
            }
            else if (status == "N")
            {
                lblHeading.Text = "Six Months above - INITIAL STAGE";
            }

            // -----------------------------------------------------------------------------------------------------
            else if (status == "P")
            {
                lblHeading.Text = "Within The One Month - ADVANCED STAGE";
            }
            else if (status == "Q")
            {
                lblHeading.Text = "One Month above - ADVANCED STAGE";
            }
            if (status == "R")
            {
                lblHeading.Text = "Two Months above - ADVANCED STAGE";
            }
            else if (status == "S")
            {
                lblHeading.Text = "Tree Months above - ADVANCED STAGE";
            }
            else if (status == "T")
            {
                lblHeading.Text = "Four Months above - ADVANCED STAGE";
            }
            else if (status == "U")
            {
                lblHeading.Text = "Five Months above - ADVANCED STAGE";
            }
            else if (status == "V")
            {
                lblHeading.Text = "Six Months above - ADVANCED STAGE";
            }
            // -----------------------------------------------------------------------------------------------------
            else if (status == "W")
            {
                lblHeading.Text = "COMMENCED OPERATIONS";
            }
            else if (status == "X")
            {
                lblHeading.Text = "DROPPED";
            }
            else if (status == "Y")
            {
                lblHeading.Text = "";
            }
            // HyperLink1.NavigateUrl = "frmR1ReportKMRNew.aspx?status=" + "" + "&lbl=Total Applications Received&fromdate=" + txtFromDate + "&todate=" + txtTodate;
        }
    }

    public DataSet GetAppealApplications(string ONLINEFLAG, string District, string TSiPASSType, string status, string Year)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@ONLINEFLAG",SqlDbType.VarChar),
               new SqlParameter("@District",SqlDbType.VarChar),
               new SqlParameter("@TSiPASSType",SqlDbType.VarChar),
               new SqlParameter("@status",SqlDbType.VarChar),
               new SqlParameter("@Year",SqlDbType.VarChar)
           };
        pp[0].Value = ONLINEFLAG;
        pp[1].Value = District;
        pp[2].Value = TSiPASSType;
        pp[3].Value = status;
        pp[4].Value = Year;
        Dsnew = Gen.GenericFillDs("USP_GET_IMPLIMENTAION_STATUS_ABSTRACT_DRILL", pp);
        return Dsnew;
    }

    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
         ExportToExcel();

    }
    protected void ExportToExcel()
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Report.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            //  Government.Visible = true;
            divPrint.Style["width"] = "680px";
            // Button1.Visible = false;
            //Button2.Visible = false;
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                grdDetails.HeaderRow.BackColor = System.Drawing.Color.White;
                foreach (TableCell cell in grdDetails.HeaderRow.Cells)
                {
                    cell.BackColor = grdDetails.HeaderStyle.BackColor;
                    cell.ForeColor = System.Drawing.Color.Black;
                }
                foreach (TableCell cell in grdDetails.FooterRow.Cells)
                {
                    cell.BackColor = System.Drawing.Color.Black;
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
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string status = DataBinder.Eval(e.Row.DataItem, "Imagestatus").ToString();
          
           if (status == "Y")
           {
               (e.Row.FindControl("HyperLink1") as HyperLink).Visible = true;
              
           }
           else
           {
               (e.Row.FindControl("HyperLink5") as HyperLink).Visible = false;
           }
        }
    }
}