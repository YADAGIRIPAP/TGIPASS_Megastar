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

using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Data.SqlClient;

public partial class UI_TSiPASS_frmIncentiveProceedingabstractcastwise : System.Web.UI.Page
{
    General gen = new General();
    General Gen = new General();
    int Sno = 0;

    DataSet ds;
    DataTable dt;


    DataSet dslist;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");

        }
        if (!IsPostBack)
        {
            txtFromDate.Text = "01-01-2015";
            DateTime today = DateTime.Today;
            txtTodate.Text = today.ToString("dd-MM-yyyy");
            fillgrid();
        }
    }
    protected void btnGet_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    public void fillgrid()
    {
        DataSet dsnew = new DataSet();
        string FromdateforDB = "", TodateforDB = "", DistCode = "";
        DistCode = Session["DistrictID"].ToString().Trim();
        FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        dsnew = GET_ABSTRACT_INCENTIVEPROCEEDINGS_CASTE(DistCode, FromdateforDB, TodateforDB, ddl_cast.SelectedItem.Text.Trim());
        // lblMsg.Text = "";
        if (dsnew != null && dsnew.Tables[1].Rows.Count > 0)
        {
            // lblMsg.Text = "Total Records :" +dsnew.Tables[0].Rows.Count.ToString();
            grdDetails.DataSource = dsnew.Tables[1];
            grdDetails.DataBind();
            bindgrdDetailsfooter(dsnew.Tables[1]);
        }
        else
        {
            //lblMsg.Text = "";
            // Label1.Text = "No Recards Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
          
        }
        if (dsnew != null && dsnew.Tables[2].Rows.Count > 0)
        {
            grdDetails1.DataSource = dsnew.Tables[2];
            grdDetails1.DataBind();
            bindgrdDetails1footer(dsnew.Tables[2]);
        }
        else
        {
            //lblMsg.Text = "";
            // Label1.Text = "No Recards Found ";
            grdDetails1.DataSource = null;
            grdDetails1.DataBind();
        }
    }

    public void bindgrdDetailsfooter(DataTable dtt)
    {
        decimal NO_UNITS_SLC = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("NO UNITS SLC")));
        decimal AMOUNT_RELEASED_SLC = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("AMOUNT RELEASED SLC")));
        decimal Working_Units_SLC = dtt.AsEnumerable().Sum(rows => Convert.ToInt32(rows.Field<object>("Working Units SLC")));
        decimal Working_AMOUNT_SLC = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Working AMOUNT SLC")));
        decimal UC_Not_Updated_SLC = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("UC Not Updated SLC")));
        decimal UC_Not_Updated_AMOUNT_SLC = dtt.AsEnumerable().Sum(rows => Convert.ToInt32(rows.Field<object>("UC Not Updated AMOUNT SLC")));
        decimal Closed_Units_SLC = dtt.AsEnumerable().Sum(rows => Convert.ToInt32(rows.Field<object>("Closed Units SLC")));
        decimal Closed_AMOUNT_SLC = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Closed AMOUNT SLC")));
        decimal NO_of_UnitsPER = decimal.Round((Working_Units_SLC / (NO_UNITS_SLC == 0 ? 1 : NO_UNITS_SLC)) * 100, 2, MidpointRounding.AwayFromZero);
        decimal NO_of_Units_amountPER = decimal.Round((UC_Not_Updated_AMOUNT_SLC / (AMOUNT_RELEASED_SLC == 0 ? 1 : AMOUNT_RELEASED_SLC)) * 100, 2, MidpointRounding.AwayFromZero);

        grdDetails.FooterRow.HorizontalAlign = HorizontalAlign.Right;
        grdDetails.FooterRow.Font.Bold = true;
        grdDetails.FooterRow.Cells[1].Text = "Total";
        grdDetails.FooterRow.Cells[2].Text = NO_UNITS_SLC.ToString();
        grdDetails.FooterRow.Cells[3].Text = AMOUNT_RELEASED_SLC.ToString();
        grdDetails.FooterRow.Cells[4].Text = Working_Units_SLC.ToString();
        grdDetails.FooterRow.Cells[5].Text = Working_AMOUNT_SLC.ToString();
        grdDetails.FooterRow.Cells[6].Text = UC_Not_Updated_SLC.ToString();
        grdDetails.FooterRow.Cells[7].Text = UC_Not_Updated_AMOUNT_SLC.ToString();
        grdDetails.FooterRow.Cells[8].Text = Closed_Units_SLC.ToString();
        grdDetails.FooterRow.Cells[9].Text = Closed_AMOUNT_SLC.ToString();
        grdDetails.FooterRow.Cells[10].Text = NO_of_UnitsPER.ToString();
        grdDetails.FooterRow.Cells[11].Text = NO_of_Units_amountPER.ToString();




        for (int i = 0; i <= grdDetails.Rows.Count - 1; i++)
        {
            for (int k = 2; k <= grdDetails.Rows[0].Cells.Count - 1; k++)
            {
                grdDetails.Rows[i].Cells[k].HorizontalAlign = HorizontalAlign.Right;
            }
        }


    }

    public void bindgrdDetails1footer(DataTable dtt)
    {
        decimal NO_UNITS_DLC = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("NO UNITS DLC")));
        decimal AMOUNT_RELEASED_DLC = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("AMOUNT RELEASED DLC")));
        decimal Working_Units_DLC = dtt.AsEnumerable().Sum(rows => Convert.ToInt32(rows.Field<object>("Working Units DLC")));
        decimal Working_AMOUNT_DLC = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Working AMOUNT DLC")));
        decimal UC_Not_Updated_DLC = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("UC Not Updated DLC")));
        decimal UC_Not_Updated_AMOUNT_DLC = dtt.AsEnumerable().Sum(rows => Convert.ToInt32(rows.Field<object>("UC Not Updated AMOUNT DLC")));
        decimal Closed_Units_DLC = dtt.AsEnumerable().Sum(rows => Convert.ToInt32(rows.Field<object>("Closed Units DLC")));
        decimal Closed_AMOUNT_DLC = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Closed AMOUNT DLC")));
        decimal NO_of_UnitsPER = decimal.Round((Working_Units_DLC / (NO_UNITS_DLC == 0 ? 1 : NO_UNITS_DLC)) * 100, 2, MidpointRounding.AwayFromZero);
        decimal NO_of_Units_amountPER = decimal.Round((UC_Not_Updated_AMOUNT_DLC / (AMOUNT_RELEASED_DLC == 0 ? 1 : AMOUNT_RELEASED_DLC)) * 100, 2, MidpointRounding.AwayFromZero);

        grdDetails1.FooterRow.HorizontalAlign = HorizontalAlign.Right;
        grdDetails1.FooterRow.Font.Bold = true;
        grdDetails1.FooterRow.Cells[1].Text = "Total";
        grdDetails1.FooterRow.Cells[2].Text = NO_UNITS_DLC.ToString();
        grdDetails1.FooterRow.Cells[3].Text = AMOUNT_RELEASED_DLC.ToString();
        grdDetails1.FooterRow.Cells[4].Text = Working_Units_DLC.ToString();
        grdDetails1.FooterRow.Cells[5].Text = Working_AMOUNT_DLC.ToString();
        grdDetails1.FooterRow.Cells[6].Text = UC_Not_Updated_DLC.ToString();
        grdDetails1.FooterRow.Cells[7].Text = UC_Not_Updated_AMOUNT_DLC.ToString();
        grdDetails1.FooterRow.Cells[8].Text = Closed_Units_DLC.ToString();
        grdDetails1.FooterRow.Cells[9].Text = Closed_AMOUNT_DLC.ToString();
        grdDetails1.FooterRow.Cells[10].Text = NO_of_UnitsPER.ToString();
        grdDetails1.FooterRow.Cells[11].Text = NO_of_Units_amountPER.ToString();




        for (int i = 0; i <= grdDetails1.Rows.Count - 1; i++)
        {
            for (int k = 2; k <= grdDetails1.Rows[0].Cells.Count - 1; k++)
            {
                grdDetails1.Rows[i].Cells[k].HorizontalAlign = HorizontalAlign.Right;
            }
        }


    }

    protected void BtnSave2_Click(object sender, EventArgs e)
    {
        ExportToExcel();

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        ExportToExcel1();

    }
    //protected void Button6_Click(object sender, EventArgs e)
    //{
    //    ExportToExcel2();

    //}
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
                    cell.BackColor = grdDetails.HeaderStyle.BackColor;
                    cell.ForeColor = System.Drawing.Color.White;
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

    protected void ExportToExcel1()
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Report1.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            //  Government.Visible = true;
            divPrint.Style["width"] = "680px";
            // Button1.Visible = false;
            Button2.Visible = false;
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                grdDetails1.AllowPaging = false;
                this.fillgrid();

                grdDetails1.HeaderRow.BackColor = System.Drawing.Color.White;
                foreach (TableCell cell in grdDetails1.HeaderRow.Cells)
                {
                    cell.BackColor = grdDetails1.HeaderStyle.BackColor;
                    cell.ForeColor = System.Drawing.Color.White;
                }
                foreach (TableCell cell in grdDetails1.FooterRow.Cells)
                {
                    cell.BackColor = System.Drawing.Color.White;
                    cell.ForeColor = System.Drawing.Color.Black;
                    // cell.
                }
                foreach (TableCell cell in grdDetails1.FooterRow.Cells)
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
                foreach (GridViewRow row in grdDetails1.Rows)
                {
                    row.BackColor = System.Drawing.Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = grdDetails1.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = grdDetails1.RowStyle.BackColor;
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

                Td1.RenderControl(hw);

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

    //protected void ExportToExcel2()
    //{
    //    try
    //    {
    //        Response.Clear();
    //        Response.Buffer = true;
    //        Response.AddHeader("content-disposition", "attachment;filename=Report2.xls");
    //        Response.Charset = "";
    //        Response.ContentType = "application/vnd.ms-excel";
    //        //  Government.Visible = true;
    //        divPrint.Style["width"] = "680px";
    //        // Button1.Visible = false;
    //        Button2.Visible = false;
    //        using (StringWriter sw = new StringWriter())
    //        {
    //            HtmlTextWriter hw = new HtmlTextWriter(sw);

    //            //To Export all pages
    //            grdDetails2.AllowPaging = false;
    //            this.fillgrid();

    //            grdDetails2.HeaderRow.BackColor = System.Drawing.Color.White;
    //            foreach (TableCell cell in grdDetails2.HeaderRow.Cells)
    //            {
    //                cell.BackColor = grdDetails2.HeaderStyle.BackColor;
    //                cell.ForeColor = System.Drawing.Color.White;
    //            }
    //            foreach (TableCell cell in grdDetails2.FooterRow.Cells)
    //            {
    //                cell.BackColor = System.Drawing.Color.White;
    //                cell.ForeColor = System.Drawing.Color.Black;
    //                // cell.
    //            }
    //            foreach (TableCell cell in grdDetails2.FooterRow.Cells)
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
    //            foreach (GridViewRow row in grdDetails2.Rows)
    //            {
    //                row.BackColor = System.Drawing.Color.White;
    //                foreach (TableCell cell in row.Cells)
    //                {
    //                    if (row.RowIndex % 2 == 0)
    //                    {
    //                        cell.BackColor = grdDetails2.AlternatingRowStyle.BackColor;
    //                    }
    //                    else
    //                    {
    //                        cell.BackColor = grdDetails2.RowStyle.BackColor;
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

    //            Td2.RenderControl(hw);

    //            //style to format numbers to string
    //            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
    //            Response.Write(style);
    //            Response.Output.Write(sw.ToString());
    //            Response.Flush();
    //            Response.End();
    //        }
    //        //Response.Clear();
    //        //Response.Buffer = true;
    //        //Response.AddHeader("content-disposition", "attachment;filename=Report " + DateTime.Now.ToString("M/d/yyyy") + ".xls");
    //        //Response.Charset = "";
    //        //Response.ContentType = "application/vnd.ms-excel";
    //        //using (StringWriter sw = new StringWriter())
    //        //{
    //        //    Button2.Visible = false;
    //        //    Button1.Visible = false;
    //        //    HtmlTextWriter hw = new HtmlTextWriter(sw);
    //        //    divPrint.RenderControl(hw);
    //        //    Response.Output.Write(sw.ToString());
    //        //    Response.Flush();
    //        //    Response.End();
    //        //}
    //    }
    //    catch (Exception e)
    //    {

    //    }
    //}
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            // dynamic clr = ColorTranslator.FromHtml("#006");
            // HeaderRow.BackColor = Color.White;
            HeaderRow.Font.Bold = true;
            HeaderRow.Font.Size = 11;
            //HeaderRow.ForeColor = clr;
            //  "#B2BECD"
            TableCell Cell_Header = new TableCell();
            Cell_Header.Text = "";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 2;
            Cell_Header.Font.Bold = false;
            HeaderRow.Cells.Add(Cell_Header);


            Cell_Header = new TableCell();
            Cell_Header.Text = "PROCEEDINGS ISSUED";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 2;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "UCs RECEIVED";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 2;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "UCs NOT RECEIVED";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 2;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "CLOSED";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 2;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "% OF UCs RECEIVED";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 2;
            HeaderRow.Cells.Add(Cell_Header);

            grdDetails.Controls[0].Controls.AddAt(0, HeaderRow);
        }
    }

    protected void grdDetails1_RowCreated(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header)
        {
            //    GridViewRow gvHeaderRow = e.Row;
            //    GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            //    GridViewRow gvHeaderRowCopy2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            //    //this.grdDetails.Controls[0].Controls.AddAt(0, gvHeaderRowCopy2);
            //    //TableCell tcHeader1 = gvHeaderRow.Cells[2];
            //    //tcHeader1.RowSpan = 2;
            //    //gvHeaderRowCopy2.Cells.Add(tcHeader1);

            //    //TableCell tcMergePackage1a = new TableCell();
            //    //tcMergePackage1a.Text = "No of Units for which release proceedings are issued";
            //    //tcMergePackage1a.CssClass = "GridviewScrollC1Headerwrap";
            //    //tcMergePackage1a.ColumnSpan = 2;
            //    //gvHeaderRowCopy2.Cells.AddAt(2, tcMergePackage1a);

            //    this.grdDetails1.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

            //    int headerCellCount = gvHeaderRow.Cells.Count;
            //    int cellIndex = 0;

            //    for (int i = 0; i < headerCellCount; i++)
            //    {
            //        if (i == 2 || i == 3 || i == 4 || i == 5 || i == 8 || i == 9 || i == 10 || i == 11)
            //        {
            //            cellIndex++;
            //        }
            //        else
            //        {
            //            TableCell tcHeader = gvHeaderRow.Cells[cellIndex];
            //            tcHeader.RowSpan = 2;
            //            gvHeaderRowCopy.Cells.Add(tcHeader);
            //        }
            //    }

            //    TableCell tcMergePackage = new TableCell();
            //    tcMergePackage.Text = "DLC";
            //    tcMergePackage.CssClass = "GridviewScrollC1Headerwrap";
            //    tcMergePackage.ColumnSpan = 2;
            //    gvHeaderRowCopy.Cells.AddAt(2, tcMergePackage);

            //    TableCell tcMergePackage1 = new TableCell();
            //    tcMergePackage1.Text = "SLC";
            //    tcMergePackage1.CssClass = "GridviewScrollC1Headerwrap";
            //    tcMergePackage1.ColumnSpan = 2;
            //    gvHeaderRowCopy.Cells.AddAt(3, tcMergePackage1);

            //    TableCell tcMergePackage2 = new TableCell();
            //    tcMergePackage2.Text = "DLC";
            //    tcMergePackage2.CssClass = "GridviewScrollC1Headerwrap";
            //    tcMergePackage2.ColumnSpan = 2;
            //    gvHeaderRowCopy.Cells.AddAt(6, tcMergePackage2);

            //    TableCell tcMergePackage3 = new TableCell();
            //    tcMergePackage3.Text = "SLC";
            //    tcMergePackage3.CssClass = "GridviewScrollC1Headerwrap";
            //    tcMergePackage3.ColumnSpan = 2;
            //    gvHeaderRowCopy.Cells.AddAt(7, tcMergePackage3);
            //}
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            // dynamic clr = ColorTranslator.FromHtml("#006");
            // HeaderRow.BackColor = Color.White;
            HeaderRow.Font.Bold = true;
            HeaderRow.Font.Size = 11;
            //HeaderRow.ForeColor = clr;
            //  "#B2BECD"
            TableCell Cell_Header = new TableCell();
            Cell_Header.Text = "";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 2;
            Cell_Header.Font.Bold = false;
            HeaderRow.Cells.Add(Cell_Header);


            Cell_Header = new TableCell();
            Cell_Header.Text = "PROCEEDINGS ISSUED";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 2;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "UCs RECEIVED";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 2;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "UCs NOT RECEIVED";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 2;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "CLOSED";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 2;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "% OF UCs RECEIVED";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 2;
            HeaderRow.Cells.Add(Cell_Header);

            grdDetails1.Controls[0].Controls.AddAt(0, HeaderRow);
        }
    }

    //protected void grdDetails2_RowCreated(object sender, GridViewRowEventArgs e)
    //{

    //    if (e.Row.RowType == DataControlRowType.Header)
    //    {
    //        GridViewRow gvHeaderRow = e.Row;
    //        GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
    //        GridViewRow gvHeaderRowCopy2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

    //        //this.grdDetails.Controls[0].Controls.AddAt(0, gvHeaderRowCopy2);
    //        //TableCell tcHeader1 = gvHeaderRow.Cells[2];
    //        //tcHeader1.RowSpan = 2;
    //        //gvHeaderRowCopy2.Cells.Add(tcHeader1);

    //        //TableCell tcMergePackage1a = new TableCell();
    //        //tcMergePackage1a.Text = "No of Units for which release proceedings are issued";
    //        //tcMergePackage1a.CssClass = "GridviewScrollC1Headerwrap";
    //        //tcMergePackage1a.ColumnSpan = 2;
    //        //gvHeaderRowCopy2.Cells.AddAt(2, tcMergePackage1a);

    //        this.grdDetails2.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

    //        int headerCellCount = gvHeaderRow.Cells.Count;
    //        int cellIndex = 0;

    //        for (int i = 0; i < headerCellCount; i++)
    //        {
    //            if (i == 2 || i == 3 || i == 4 || i == 5 || i == 8 || i == 9 || i == 10 || i == 11)
    //            {
    //                cellIndex++;
    //            }
    //            else
    //            {
    //                TableCell tcHeader = gvHeaderRow.Cells[cellIndex];
    //                tcHeader.RowSpan = 2;
    //                gvHeaderRowCopy.Cells.Add(tcHeader);
    //            }
    //        }

    //        TableCell tcMergePackage = new TableCell();
    //        tcMergePackage.Text = "DLC";
    //        tcMergePackage.CssClass = "GridviewScrollC1Headerwrap";
    //        tcMergePackage.ColumnSpan = 2;
    //        gvHeaderRowCopy.Cells.AddAt(2, tcMergePackage);

    //        TableCell tcMergePackage1 = new TableCell();
    //        tcMergePackage1.Text = "SLC";
    //        tcMergePackage1.CssClass = "GridviewScrollC1Headerwrap";
    //        tcMergePackage1.ColumnSpan = 2;
    //        gvHeaderRowCopy.Cells.AddAt(3, tcMergePackage1);
    //    }
    //}
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
                    Response.AddHeader("content-disposition", "attachment;filename= R1Release_Proceedings_AbstractSLC_DLC" + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
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

    protected void btnbdf_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        //  ds = (DataSet)Session["dtdataset"];

        // DataRow dr = GetData("SELECT * FROM Employees where EmployeeId = " + ddlEmployees.SelectedItem.Value).Rows[0]; ;
        // Document document = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
        Document document = new Document(PageSize.A4.Rotate(), 20f, 20f, 20f, 50f);
        Font NormalFont = FontFactory.GetFont("trebuchet ms", 12, Font.NORMAL, Color.BLACK);

        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
        {
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

            Phrase phrase = null;
            PdfPCell cell = null;
            PdfPTable table = null;
            PdfPTable tablenew = null;
            Color color = null;

            document.Open();
            writer.PageEvent = new Footer();
            //Header Table
            PdfContentByte contentBytenew = writer.DirectContent;
            table = new PdfPTable(3);
            table.TotalWidth = document.PageSize.Width - 60f;
            table.SetWidths(new float[] { 0.1f, 0.8f, 0.1f });
            table.LockedWidth = true;


            cell = ImageCell("~/images/ipasslogopsr.png", 20f, PdfPCell.ALIGN_LEFT);
            cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            table.AddCell(cell);


            phrase = new Phrase();
            phrase.Add(new Chunk("Telangana State Industrial Project Approval &	Self- Certification System (TS-iPASS)\n\n", FontFactory.GetFont("trebuchet ms", 14, Font.BOLD, Color.BLACK)));
            phrase.Add(new Chunk("government of telangana".ToUpper(), FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));

            cell = PhraseCell(phrase, PdfPCell.ALIGN_CENTER);
            cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            // cell.PaddingBottom = 30f;
            table.AddCell(cell);

            cell = ImageCell("~/images/logoTG.gif", 20f, PdfPCell.ALIGN_RIGHT);
            cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            table.AddCell(cell);

            //------------------------------------------------------------------------------------------------------------------------------------------------------
            string strDuration = "";
            string FromdateforDB = "", TodateforDB = "", monthName = "", monthName1 = "";
            string FromdateforDB1 = "", TodateforDB1 = "";
            int monthday1 = 0, monthday2 = 0;
            //  txtFromDate = Session["FromdateforDB"].ToString();



            strDuration = DisplayWithSuffix(monthday1) + " " + monthName + " " + FromdateforDB1 + " to " + DisplayWithSuffix(monthday2) + " " + monthName1 + " " + TodateforDB1;
            // string fullMonthName = new DateTime( FromdateforDB).ToString("MMMM", System.Globalization.CultureInfo.CreateSpecificCulture("es"));

            string tcMergePackage = "Analytics From " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
            //------------------------------------------------------------------------------------------------------------------------------------------------------
            phrase = new Phrase();
            phrase.Add(new Chunk("R2.1 Release Proceedings - Abstract of SLC & DLC - No of Units for which release proceedings are issued\n\n", FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));
            phrase.Add(new Chunk(tcMergePackage, FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
            cell.VerticalAlignment = PdfCell.ALIGN_CENTER;
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            cell.Colspan = 3;
            cell.PaddingTop = 20f;
            cell.PaddingBottom = 0f;
            table.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk("Report Generated On :" + DateTime.Now.ToString("dd/MM/yyyy"), FontFactory.GetFont("trebuchet ms", 12, Font.NORMAL, Color.BLACK)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = PdfCell.ALIGN_RIGHT;
            cell.Colspan = 3;
            cell.PaddingTop = 10f;
            cell.PaddingBottom = 0f;
            table.AddCell(cell);

            document.Add(table);

            color = new Color(6, 170, 26);
            DrawLineMiddleline(writer, 2f, document.Top - 60f, document.PageSize.Width - 2f, document.Top - 60f, color);

            int CountColumns = 0;

            foreach (DataControlFieldCell cellnew in grdDetails.Rows[0].Cells)
            {
                if (cellnew.Visible == true)
                {
                    CountColumns += 1;
                }
            }

            tablenew = new PdfPTable(CountColumns);
            //  tablenew.SetWidths(new float[] { 0.15f, 0.05f, 0.70f, 0.25f });
            float[] terms = new float[CountColumns];
            for (int runs = 0; runs < CountColumns; runs++)
            {
                if (runs == 0)
                {
                    terms[runs] = 5f;
                }
                //else if (runs == 1)
                //{
                //    terms[runs] = 20f;
                //}
                else
                {
                    double valus = 75 / CountColumns;
                    terms[runs] = (float)valus;
                }
            }
            tablenew.SetWidths(terms);
            tablenew.TotalWidth = document.PageSize.Width - 60f;

            tablenew.LockedWidth = true;
            tablenew.SpacingBefore = 5f;
            tablenew.HorizontalAlignment = Element.ALIGN_MIDDLE;
            // CountColumns = grdDetails.Columns.Count;

            string cellTextnew = "";
            phrase = new Phrase();
            phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails.HeaderStyle.BackColor);  //#009688
            cell.PaddingBottom = 5;
            cell.Colspan = 2;
            cell.MinimumHeight = 30f;
            tablenew.AddCell(cell);

            phrase = new Phrase();
            cellTextnew = "DLC";
            phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails.HeaderStyle.BackColor);  //#009688
            cell.PaddingBottom = 5;
            cell.Colspan = 2;
            cell.MinimumHeight = 30f;
            tablenew.AddCell(cell);

            phrase = new Phrase();
            cellTextnew = "SLC";
            phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails.HeaderStyle.BackColor);  //#009688
            cell.PaddingBottom = 5;
            cell.Colspan = 2;
            cell.MinimumHeight = 30f;
            tablenew.AddCell(cell);

            phrase = new Phrase();
            cellTextnew = "";
            phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails.HeaderStyle.BackColor);  //#009688
            cell.PaddingBottom = 5;
            cell.Colspan = 2;
            cell.MinimumHeight = 30f;
            tablenew.AddCell(cell);

            for (int i = 0; i < CountColumns; i++)
            {
                string cellText = "";

                cellText = Server.HtmlDecode(grdDetails.Columns[i].HeaderText);

                phrase = new Phrase();
                phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails.HeaderStyle.BackColor);  //#009688
                cell.PaddingBottom = 5;
                cell.MinimumHeight = 30f;
                tablenew.AddCell(cell);
            }

            for (int i = 0; i < grdDetails.Rows.Count; i++)
            {
                if (grdDetails.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    for (int j = 0; j < CountColumns; j++)
                    {
                        string cellText = "";
                        HyperLink h4 = null;
                        phrase = new Phrase();

                        if (j == 0)
                        {
                            cellText = (i + 1).ToString();
                        }
                        else if (j == 1 || j == 3 || j == 5 || j == 7)
                        {
                            cellText = Server.HtmlDecode(grdDetails.Rows[i].Cells[j].Text);
                        }
                        else
                        {
                            if (grdDetails.Rows[i].Cells[j].Controls[0].Visible == true)
                            {
                                h4 = (HyperLink)grdDetails.Rows[i].Cells[j].Controls[0];
                                cellText = h4.Text;
                            }
                            else
                                continue;
                        }
                        cellText = Server.HtmlDecode(cellText);

                        h4 = (HyperLink)grdDetails.Rows[i].Controls[j];
                        if (j == 0 && (cellText == "CFE - Total" || cellText == "CFO - Total" || cellText == "CFE + CFO TOTAL" || cellText == "GRAND TOTAL"))
                        {
                            cellText = "";
                            phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.BOLD, Color.BLACK)));
                        }
                        else
                        {
                            string cellTextnew1 = Server.HtmlDecode(grdDetails.Rows[i].Cells[1].Text);
                            if ((cellTextnew1 == "CFE - Total" || cellTextnew1 == "CFO - Total" || cellTextnew1 == "CFE + CFO TOTAL" || cellTextnew1 == "GRAND TOTAL"))
                            {
                                phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.BOLD, Color.BLACK)));
                            }
                            else
                            {
                                phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.BLACK)));
                            }
                        }


                        if (j == 0)
                        {
                            cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        }
                        else if (j == 1)
                        {
                            cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                        }
                        else
                        {
                            cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
                            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        }


                        //cell.Border = 2;
                        //cell.BorderColor = Color.BLACK;
                        if (grdDetails.Rows[i].RowState == DataControlRowState.Alternate)
                        {
                            cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA"));
                            cell.BorderWidthRight = 0.5f;
                            cell.BorderWidthLeft = 0.5f;
                            cell.BorderWidthTop = 0.5f;
                            cell.BorderWidthBottom = 0.5f;

                            cell.BorderColorBottom = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));  //#E5E5E5
                            cell.BorderColorTop = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));
                            cell.BorderColorLeft = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));
                            cell.BorderColorRight = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));
                        }
                        else
                        {
                            cell.BorderWidthRight = 0.5f;
                            cell.BorderWidthLeft = 0.5f;
                            cell.BorderWidthTop = 0.5f;
                            cell.BorderWidthBottom = 0.5f;

                            cell.BorderColorBottom = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));  //#E5E5E5
                            cell.BorderColorTop = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));
                            cell.BorderColorLeft = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));
                            cell.BorderColorRight = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));
                        }

                        //cell.BackgroundColor = Color.GRAY;

                        cell.PaddingBottom = 5;
                        cell.MinimumHeight = 30f;
                        tablenew.AddCell(cell);
                    }
                }
                var remainingPageSpace = writer.GetVerticalPosition(false) - document.BottomMargin;
                var initialPosition = writer.GetVerticalPosition(false);
                var tablehiht = tablenew.TotalHeight;

                if (remainingPageSpace >= tablehiht && remainingPageSpace - 40 <= tablehiht)
                {
                    contentBytenew.SetColorStroke(color);
                    contentBytenew.Circle(document.PageSize.Width - 23f, document.PageSize.Bottom + 23f, 10f);
                    contentBytenew.Stroke();

                    ColumnText.ShowTextAligned(contentBytenew, Element.ALIGN_RIGHT, new Phrase((writer.PageNumber).ToString(), FontFactory.GetFont("Trebuchet MS", 12, Font.BOLD, Color.BLACK)), document.PageSize.Width - 20f, document.PageSize.Bottom + 20f, 2);

                    document.Add(tablenew);
                    document.NewPage();
                    tablenew.DeleteBodyRows();


                    phrase = new Phrase();
                    phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                    cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails.HeaderStyle.BackColor);  //#009688
                    cell.PaddingBottom = 5;
                    cell.Colspan = 2;
                    cell.MinimumHeight = 30f;
                    tablenew.AddCell(cell);

                    phrase = new Phrase();
                    cellTextnew = "DLC";
                    phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                    cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails.HeaderStyle.BackColor);  //#009688
                    cell.PaddingBottom = 5;
                    cell.Colspan = 2;
                    cell.MinimumHeight = 30f;
                    tablenew.AddCell(cell);

                    phrase = new Phrase();
                    cellTextnew = "SLC";
                    phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                    cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails.HeaderStyle.BackColor);  //#009688
                    cell.PaddingBottom = 5;
                    cell.Colspan = 2;
                    cell.MinimumHeight = 30f;
                    tablenew.AddCell(cell);

                    phrase = new Phrase();
                    cellTextnew = "";
                    phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                    cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails.HeaderStyle.BackColor);  //#009688
                    cell.PaddingBottom = 5;
                    cell.Colspan = 2;
                    cell.MinimumHeight = 30f;
                    tablenew.AddCell(cell);
                    for (int k = 0; k < CountColumns; k++)
                    {
                        string cellText = "";

                        cellText = Server.HtmlDecode(grdDetails.Columns[k].HeaderText);

                        phrase = new Phrase();
                        phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
                        cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                        cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails.HeaderStyle.BackColor);  //#009688
                        cell.PaddingBottom = 5;
                        cell.MinimumHeight = 30f;
                        tablenew.AddCell(cell);
                    }
                }
            }
            for (int i = 0; i < CountColumns; i++)
            {
                string cellText = "";

                cellText = Server.HtmlDecode(grdDetails.Columns[i].FooterText);

                phrase = new Phrase();
                phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails.HeaderStyle.BackColor);  //#009688
                cell.PaddingBottom = 5;
                cell.MinimumHeight = 30f;
                tablenew.AddCell(cell);
            }
            document.Add(tablenew);

            contentBytenew.SetColorStroke(color);
            contentBytenew.Circle(document.PageSize.Width - 23f, document.PageSize.Bottom + 23f, 10f);
            contentBytenew.Stroke();
            ColumnText.ShowTextAligned(contentBytenew, Element.ALIGN_RIGHT, new Phrase((writer.PageNumber).ToString(), FontFactory.GetFont("Trebuchet MS", 12, Font.BOLD, Color.BLACK)), document.PageSize.Width - 20f, document.PageSize.Bottom + 20f, 2);

            document.Close();
            byte[] bytes = memoryStream.ToArray();
            memoryStream.Close();
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=Report" + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
            Response.ContentType = "application/pdf";

            //Response.ContentType = "application/vnd.ms-excel";
            //Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            //Response.ContentType = "application/vnd.ms-excel";

            Response.Buffer = true;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(bytes);
            Response.End();
            Response.Close();


        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        //  ds = (DataSet)Session["dtdataset"];

        // DataRow dr = GetData("SELECT * FROM Employees where EmployeeId = " + ddlEmployees.SelectedItem.Value).Rows[0]; ;
        // Document document = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
        Document document = new Document(PageSize.A4.Rotate(), 20f, 20f, 20f, 50f);
        Font NormalFont = FontFactory.GetFont("trebuchet ms", 12, Font.NORMAL, Color.BLACK);

        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
        {
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

            Phrase phrase = null;
            PdfPCell cell = null;
            PdfPTable table = null;
            PdfPTable tablenew = null;
            Color color = null;

            document.Open();
            writer.PageEvent = new Footer();
            //Header Table
            PdfContentByte contentBytenew = writer.DirectContent;
            table = new PdfPTable(3);
            table.TotalWidth = document.PageSize.Width - 60f;
            table.SetWidths(new float[] { 0.1f, 0.8f, 0.1f });
            table.LockedWidth = true;


            cell = ImageCell("~/images/ipasslogopsr.png", 20f, PdfPCell.ALIGN_LEFT);
            cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            table.AddCell(cell);


            phrase = new Phrase();
            phrase.Add(new Chunk("Telangana State Industrial Project Approval &	Self- Certification System (TS-iPASS)\n\n", FontFactory.GetFont("trebuchet ms", 14, Font.BOLD, Color.BLACK)));
            phrase.Add(new Chunk("government of telangana".ToUpper(), FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));

            cell = PhraseCell(phrase, PdfPCell.ALIGN_CENTER);
            cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            // cell.PaddingBottom = 30f;
            table.AddCell(cell);

            cell = ImageCell("~/images/logoTG.gif", 20f, PdfPCell.ALIGN_RIGHT);
            cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            table.AddCell(cell);

            //------------------------------------------------------------------------------------------------------------------------------------------------------
            string strDuration = "";
            string FromdateforDB = "", TodateforDB = "", monthName = "", monthName1 = "";
            string FromdateforDB1 = "", TodateforDB1 = "";
            int monthday1 = 0, monthday2 = 0;
            //  txtFromDate = Session["FromdateforDB"].ToString();



            strDuration = DisplayWithSuffix(monthday1) + " " + monthName + " " + FromdateforDB1 + " to " + DisplayWithSuffix(monthday2) + " " + monthName1 + " " + TodateforDB1;
            // string fullMonthName = new DateTime( FromdateforDB).ToString("MMMM", System.Globalization.CultureInfo.CreateSpecificCulture("es"));

            string tcMergePackage = "Analytics From " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
            //------------------------------------------------------------------------------------------------------------------------------------------------------
            phrase = new Phrase();
            phrase.Add(new Chunk("R2.1 Release Proceedings - Abstract of SLC & DLC - UC Updated \n\n", FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));
            phrase.Add(new Chunk(tcMergePackage, FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
            cell.VerticalAlignment = PdfCell.ALIGN_CENTER;
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            cell.Colspan = 3;
            cell.PaddingTop = 20f;
            cell.PaddingBottom = 0f;
            table.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk("Report Generated On :" + DateTime.Now.ToString("dd/MM/yyyy"), FontFactory.GetFont("trebuchet ms", 12, Font.NORMAL, Color.BLACK)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = PdfCell.ALIGN_RIGHT;
            cell.Colspan = 3;
            cell.PaddingTop = 10f;
            cell.PaddingBottom = 0f;
            table.AddCell(cell);

            document.Add(table);

            color = new Color(6, 170, 26);
            DrawLineMiddleline(writer, 2f, document.Top - 60f, document.PageSize.Width - 2f, document.Top - 60f, color);

            int CountColumns = 0;

            foreach (DataControlFieldCell cellnew in grdDetails1.Rows[0].Cells)
            {
                if (cellnew.Visible == true)
                {
                    CountColumns += 1;
                }
            }

            tablenew = new PdfPTable(CountColumns);
            //  tablenew.SetWidths(new float[] { 0.15f, 0.05f, 0.70f, 0.25f });
            float[] terms = new float[CountColumns];
            for (int runs = 0; runs < CountColumns; runs++)
            {
                if (runs == 0)
                {
                    terms[runs] = 2f;
                }
                //else if (runs == 1)
                //{
                //    terms[runs] = 20f;
                //}
                else
                {
                    double valus = 75 / CountColumns;
                    terms[runs] = (float)valus;
                }
            }
            tablenew.SetWidths(terms);
            tablenew.TotalWidth = document.PageSize.Width - 60f;

            tablenew.LockedWidth = true;
            tablenew.SpacingBefore = 5f;
            tablenew.HorizontalAlignment = Element.ALIGN_MIDDLE;
            // CountColumns = grdDetails1.Columns.Count;

            string cellTextnew = "";
            phrase = new Phrase();
            phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails1.HeaderStyle.BackColor);  //#009688
            cell.PaddingBottom = 5;
            cell.Colspan = 2;
            cell.MinimumHeight = 30f;
            tablenew.AddCell(cell);

            phrase = new Phrase();
            cellTextnew = "DLC";
            phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails1.HeaderStyle.BackColor);  //#009688
            cell.PaddingBottom = 5;
            cell.Colspan = 2;
            cell.MinimumHeight = 30f;
            tablenew.AddCell(cell);

            phrase = new Phrase();
            cellTextnew = "SLC";
            phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails1.HeaderStyle.BackColor);  //#009688
            cell.PaddingBottom = 5;
            cell.Colspan = 2;
            cell.MinimumHeight = 30f;
            tablenew.AddCell(cell);

            phrase = new Phrase();
            cellTextnew = "";
            phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails1.HeaderStyle.BackColor);  //#009688
            cell.PaddingBottom = 5;
            cell.Colspan = 2;
            cell.MinimumHeight = 30f;
            tablenew.AddCell(cell);

            phrase = new Phrase();
            cellTextnew = "DLC";
            phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails1.HeaderStyle.BackColor);  //#009688
            cell.PaddingBottom = 5;
            cell.Colspan = 2;
            cell.MinimumHeight = 30f;
            tablenew.AddCell(cell);

            phrase = new Phrase();
            cellTextnew = "SLC";
            phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails1.HeaderStyle.BackColor);  //#009688
            cell.PaddingBottom = 5;
            cell.Colspan = 2;
            cell.MinimumHeight = 30f;
            tablenew.AddCell(cell);

            phrase = new Phrase();
            cellTextnew = "";
            phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails1.HeaderStyle.BackColor);  //#009688
            cell.PaddingBottom = 5;
            cell.Colspan = 2;
            cell.MinimumHeight = 30f;
            tablenew.AddCell(cell);

            for (int i = 0; i < CountColumns; i++)
            {
                string cellText = "";

                cellText = Server.HtmlDecode(grdDetails1.Columns[i].HeaderText);

                phrase = new Phrase();
                phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails1.HeaderStyle.BackColor);  //#009688
                cell.PaddingBottom = 5;
                cell.MinimumHeight = 30f;
                tablenew.AddCell(cell);
            }

            for (int i = 0; i < grdDetails1.Rows.Count; i++)
            {
                if (grdDetails1.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    for (int j = 0; j < CountColumns; j++)
                    {
                        string cellText = "";
                        HyperLink h4 = null;
                        phrase = new Phrase();

                        if (j == 0)
                        {
                            cellText = (i + 1).ToString();
                        }
                        else if (j == 1 || j == 3 || j == 5 || j == 7 || j == 9 || j == 11 || j == 13 || j == 15)
                        {
                            cellText = Server.HtmlDecode(grdDetails1.Rows[i].Cells[j].Text);
                        }
                        else
                        {
                            if (grdDetails1.Rows[i].Cells[j].Controls[0].Visible == true)
                            {
                                h4 = (HyperLink)grdDetails1.Rows[i].Cells[j].Controls[0];
                                cellText = h4.Text;
                            }
                            else
                                continue;
                        }
                        cellText = Server.HtmlDecode(cellText);

                        // h4 = (HyperLink)grdDetails1.Rows[i].Controls[j];
                        if (j == 0 && (cellText == "CFE - Total" || cellText == "CFO - Total" || cellText == "CFE + CFO TOTAL" || cellText == "GRAND TOTAL"))
                        {
                            cellText = "";
                            phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.BOLD, Color.BLACK)));
                        }
                        else
                        {
                            string cellTextnew1 = Server.HtmlDecode(grdDetails1.Rows[i].Cells[1].Text);
                            if ((cellTextnew1 == "CFE - Total" || cellTextnew1 == "CFO - Total" || cellTextnew1 == "CFE + CFO TOTAL" || cellTextnew1 == "GRAND TOTAL"))
                            {
                                phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.BOLD, Color.BLACK)));
                            }
                            else
                            {
                                phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.BLACK)));
                            }
                        }


                        if (j == 0)
                        {
                            cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        }
                        else if (j == 1)
                        {
                            cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                        }
                        else
                        {
                            cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
                            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        }


                        //cell.Border = 2;
                        //cell.BorderColor = Color.BLACK;
                        if (grdDetails1.Rows[i].RowState == DataControlRowState.Alternate)
                        {
                            cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA"));
                            cell.BorderWidthRight = 0.5f;
                            cell.BorderWidthLeft = 0.5f;
                            cell.BorderWidthTop = 0.5f;
                            cell.BorderWidthBottom = 0.5f;

                            cell.BorderColorBottom = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));  //#E5E5E5
                            cell.BorderColorTop = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));
                            cell.BorderColorLeft = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));
                            cell.BorderColorRight = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));
                        }
                        else
                        {
                            cell.BorderWidthRight = 0.5f;
                            cell.BorderWidthLeft = 0.5f;
                            cell.BorderWidthTop = 0.5f;
                            cell.BorderWidthBottom = 0.5f;

                            cell.BorderColorBottom = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));  //#E5E5E5
                            cell.BorderColorTop = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));
                            cell.BorderColorLeft = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));
                            cell.BorderColorRight = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));
                        }

                        //cell.BackgroundColor = Color.GRAY;

                        cell.PaddingBottom = 5;
                        cell.MinimumHeight = 30f;
                        tablenew.AddCell(cell);
                    }
                }
                var remainingPageSpace = writer.GetVerticalPosition(false) - document.BottomMargin;
                var initialPosition = writer.GetVerticalPosition(false);
                var tablehiht = tablenew.TotalHeight;

                if (remainingPageSpace >= tablehiht && remainingPageSpace - 40 <= tablehiht)
                {
                    contentBytenew.SetColorStroke(color);
                    contentBytenew.Circle(document.PageSize.Width - 23f, document.PageSize.Bottom + 23f, 10f);
                    contentBytenew.Stroke();

                    ColumnText.ShowTextAligned(contentBytenew, Element.ALIGN_RIGHT, new Phrase((writer.PageNumber).ToString(), FontFactory.GetFont("Trebuchet MS", 12, Font.BOLD, Color.BLACK)), document.PageSize.Width - 20f, document.PageSize.Bottom + 20f, 2);

                    document.Add(tablenew);
                    document.NewPage();
                    tablenew.DeleteBodyRows();


                    phrase = new Phrase();
                    phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                    cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails1.HeaderStyle.BackColor);  //#009688
                    cell.PaddingBottom = 5;
                    cell.Colspan = 2;
                    cell.MinimumHeight = 30f;
                    tablenew.AddCell(cell);

                    phrase = new Phrase();
                    cellTextnew = "DLC";
                    phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                    cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails1.HeaderStyle.BackColor);  //#009688
                    cell.PaddingBottom = 5;
                    cell.Colspan = 2;
                    cell.MinimumHeight = 30f;
                    tablenew.AddCell(cell);

                    phrase = new Phrase();
                    cellTextnew = "SLC";
                    phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                    cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails1.HeaderStyle.BackColor);  //#009688
                    cell.PaddingBottom = 5;
                    cell.Colspan = 2;
                    cell.MinimumHeight = 30f;
                    tablenew.AddCell(cell);

                    phrase = new Phrase();
                    cellTextnew = "";
                    phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                    cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails1.HeaderStyle.BackColor);  //#009688
                    cell.PaddingBottom = 5;
                    cell.Colspan = 2;
                    cell.MinimumHeight = 30f;
                    tablenew.AddCell(cell);

                    phrase = new Phrase();
                    cellTextnew = "DLC";
                    phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                    cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails1.HeaderStyle.BackColor);  //#009688
                    cell.PaddingBottom = 5;
                    cell.Colspan = 2;
                    cell.MinimumHeight = 30f;
                    tablenew.AddCell(cell);

                    phrase = new Phrase();
                    cellTextnew = "SLC";
                    phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                    cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails1.HeaderStyle.BackColor);  //#009688
                    cell.PaddingBottom = 5;
                    cell.Colspan = 2;
                    cell.MinimumHeight = 30f;
                    tablenew.AddCell(cell);

                    phrase = new Phrase();
                    cellTextnew = "";
                    phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                    cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails1.HeaderStyle.BackColor);  //#009688
                    cell.PaddingBottom = 5;
                    cell.Colspan = 2;
                    cell.MinimumHeight = 30f;
                    tablenew.AddCell(cell);

                    for (int k = 0; k < CountColumns; k++)
                    {
                        string cellText = "";

                        cellText = Server.HtmlDecode(grdDetails1.Columns[k].HeaderText);

                        phrase = new Phrase();
                        phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
                        cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                        cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails1.HeaderStyle.BackColor);  //#009688
                        cell.PaddingBottom = 5;
                        cell.MinimumHeight = 30f;
                        tablenew.AddCell(cell);
                    }
                }
            }
            for (int i = 0; i < CountColumns; i++)
            {
                string cellText = "";

                cellText = Server.HtmlDecode(grdDetails1.Columns[i].FooterText);

                phrase = new Phrase();
                phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails1.HeaderStyle.BackColor);  //#009688
                cell.PaddingBottom = 5;
                cell.MinimumHeight = 30f;
                tablenew.AddCell(cell);
            }
            document.Add(tablenew);

            contentBytenew.SetColorStroke(color);
            contentBytenew.Circle(document.PageSize.Width - 23f, document.PageSize.Bottom + 23f, 10f);
            contentBytenew.Stroke();
            ColumnText.ShowTextAligned(contentBytenew, Element.ALIGN_RIGHT, new Phrase((writer.PageNumber).ToString(), FontFactory.GetFont("Trebuchet MS", 12, Font.BOLD, Color.BLACK)), document.PageSize.Width - 20f, document.PageSize.Bottom + 20f, 2);

            document.Close();
            byte[] bytes = memoryStream.ToArray();
            memoryStream.Close();
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=Report" + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
            Response.ContentType = "application/pdf";

            //Response.ContentType = "application/vnd.ms-excel";
            //Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            //Response.ContentType = "application/vnd.ms-excel";

            Response.Buffer = true;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(bytes);
            Response.End();
            Response.Close();
        }
    }

    //protected void Button5_Click(object sender, EventArgs e)
    //{
    //    DataSet ds = new DataSet();
    //    //  ds = (DataSet)Session["dtdataset"];

    //    // DataRow dr = GetData("SELECT * FROM Employees where EmployeeId = " + ddlEmployees.SelectedItem.Value).Rows[0]; ;
    //    // Document document = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
    //    Document document = new Document(PageSize.A4.Rotate(), 20f, 20f, 20f, 50f);
    //    Font NormalFont = FontFactory.GetFont("trebuchet ms", 12, Font.NORMAL, Color.BLACK);

    //    using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
    //    {
    //        PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

    //        Phrase phrase = null;
    //        PdfPCell cell = null;
    //        PdfPTable table = null;
    //        PdfPTable tablenew = null;
    //        Color color = null;

    //        document.Open();
    //        writer.PageEvent = new Footer();
    //        //Header Table
    //        PdfContentByte contentBytenew = writer.DirectContent;
    //        table = new PdfPTable(3);
    //        table.TotalWidth = document.PageSize.Width - 60f;
    //        table.SetWidths(new float[] { 0.1f, 0.8f, 0.1f });
    //        table.LockedWidth = true;


    //        cell = ImageCell("~/images/ipasslogopsr.png", 20f, PdfPCell.ALIGN_LEFT);
    //        cell.VerticalAlignment = PdfCell.ALIGN_TOP;
    //        table.AddCell(cell);


    //        phrase = new Phrase();
    //        phrase.Add(new Chunk("Telangana State Industrial Project Approval &	Self- Certification System (TS-iPASS)\n\n", FontFactory.GetFont("trebuchet ms", 14, Font.BOLD, Color.BLACK)));
    //        phrase.Add(new Chunk("government of telangana".ToUpper(), FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));

    //        cell = PhraseCell(phrase, PdfPCell.ALIGN_CENTER);
    //        cell.VerticalAlignment = PdfCell.ALIGN_TOP;
    //        // cell.PaddingBottom = 30f;
    //        table.AddCell(cell);

    //        cell = ImageCell("~/images/logoTG.gif", 20f, PdfPCell.ALIGN_RIGHT);
    //        cell.VerticalAlignment = PdfCell.ALIGN_TOP;
    //        table.AddCell(cell);

    //        //------------------------------------------------------------------------------------------------------------------------------------------------------
    //        string strDuration = "";
    //        string FromdateforDB = "", TodateforDB = "", monthName = "", monthName1 = "";
    //        string FromdateforDB1 = "", TodateforDB1 = "";
    //        int monthday1 = 0, monthday2 = 0;
    //        //  txtFromDate = Session["FromdateforDB"].ToString();



    //        strDuration = DisplayWithSuffix(monthday1) + " " + monthName + " " + FromdateforDB1 + " to " + DisplayWithSuffix(monthday2) + " " + monthName1 + " " + TodateforDB1;
    //        // string fullMonthName = new DateTime( FromdateforDB).ToString("MMMM", System.Globalization.CultureInfo.CreateSpecificCulture("es"));

    //        string tcMergePackage = "Analytics From " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
    //        //------------------------------------------------------------------------------------------------------------------------------------------------------
    //        phrase = new Phrase();
    //        phrase.Add(new Chunk("R2.1 Release Proceedings - Abstract of SLC & DLC -- UC Not Updated\n\n", FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));
    //        phrase.Add(new Chunk(tcMergePackage, FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));
    //        cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
    //        cell.VerticalAlignment = PdfCell.ALIGN_CENTER;
    //        cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
    //        cell.Colspan = 3;
    //        cell.PaddingTop = 20f;
    //        cell.PaddingBottom = 0f;
    //        table.AddCell(cell);

    //        phrase = new Phrase();
    //        phrase.Add(new Chunk("Report Generated On :" + DateTime.Now.ToString("dd/MM/yyyy"), FontFactory.GetFont("trebuchet ms", 12, Font.NORMAL, Color.BLACK)));
    //        cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
    //        cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
    //        cell.HorizontalAlignment = PdfCell.ALIGN_RIGHT;
    //        cell.Colspan = 3;
    //        cell.PaddingTop = 10f;
    //        cell.PaddingBottom = 0f;
    //        table.AddCell(cell);

    //        document.Add(table);

    //        color = new Color(6, 170, 26);
    //        DrawLineMiddleline(writer, 2f, document.Top - 60f, document.PageSize.Width - 2f, document.Top - 60f, color);

    //        int CountColumns = 0;

    //        foreach (DataControlFieldCell cellnew in grdDetails2.Rows[0].Cells)
    //        {
    //            if (cellnew.Visible == true)
    //            {
    //                CountColumns += 1;
    //            }
    //        }

    //        tablenew = new PdfPTable(CountColumns);
    //        //  tablenew.SetWidths(new float[] { 0.15f, 0.05f, 0.70f, 0.25f });
    //        float[] terms = new float[CountColumns];
    //        for (int runs = 0; runs < CountColumns; runs++)
    //        {
    //            if (runs == 0)
    //            {
    //                terms[runs] = 5f;
    //            }
    //            //else if (runs == 1)
    //            //{
    //            //    terms[runs] = 20f;
    //            //}
    //            else
    //            {
    //                double valus = 75 / CountColumns;
    //                terms[runs] = (float)valus;
    //            }
    //        }
    //        tablenew.SetWidths(terms);
    //        tablenew.TotalWidth = document.PageSize.Width - 60f;

    //        tablenew.LockedWidth = true;
    //        tablenew.SpacingBefore = 5f;
    //        tablenew.HorizontalAlignment = Element.ALIGN_MIDDLE;
    //        // CountColumns = grdDetails2.Columns.Count;

    //        string cellTextnew = "";
    //        phrase = new Phrase();
    //        phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
    //        cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
    //        cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
    //        cell.HorizontalAlignment = Element.ALIGN_CENTER;
    //        cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails2.HeaderStyle.BackColor);  //#009688
    //        cell.PaddingBottom = 5;
    //        cell.Colspan = 2;
    //        cell.MinimumHeight = 30f;
    //        tablenew.AddCell(cell);

    //        phrase = new Phrase();
    //        cellTextnew = "DLC";
    //        phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
    //        cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
    //        cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
    //        cell.HorizontalAlignment = Element.ALIGN_CENTER;
    //        cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails2.HeaderStyle.BackColor);  //#009688
    //        cell.PaddingBottom = 5;
    //        cell.Colspan = 2;
    //        cell.MinimumHeight = 30f;
    //        tablenew.AddCell(cell);

    //        phrase = new Phrase();
    //        cellTextnew = "SLC";
    //        phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
    //        cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
    //        cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
    //        cell.HorizontalAlignment = Element.ALIGN_CENTER;
    //        cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails2.HeaderStyle.BackColor);  //#009688
    //        cell.PaddingBottom = 5;
    //        cell.Colspan = 2;
    //        cell.MinimumHeight = 30f;
    //        tablenew.AddCell(cell);

    //        phrase = new Phrase();
    //        cellTextnew = "";
    //        phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
    //        cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
    //        cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
    //        cell.HorizontalAlignment = Element.ALIGN_CENTER;
    //        cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails2.HeaderStyle.BackColor);  //#009688
    //        cell.PaddingBottom = 5;
    //        cell.Colspan = 2;
    //        cell.MinimumHeight = 30f;
    //        tablenew.AddCell(cell);

    //        for (int i = 0; i < CountColumns; i++)
    //        {
    //            string cellText = "";

    //            cellText = Server.HtmlDecode(grdDetails2.Columns[i].HeaderText);

    //            phrase = new Phrase();
    //            phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
    //            cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
    //            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
    //            cell.HorizontalAlignment = Element.ALIGN_CENTER;
    //            cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails2.HeaderStyle.BackColor);  //#009688
    //            cell.PaddingBottom = 5;
    //            cell.MinimumHeight = 30f;
    //            tablenew.AddCell(cell);
    //        }

    //        for (int i = 0; i < grdDetails2.Rows.Count; i++)
    //        {
    //            if (grdDetails2.Rows[i].RowType == DataControlRowType.DataRow)
    //            {
    //                for (int j = 0; j < CountColumns; j++)
    //                {
    //                    string cellText = "";
    //                    HyperLink h4 = null;
    //                    phrase = new Phrase();

    //                    if (j == 0)
    //                    {
    //                        cellText = (i + 1).ToString();
    //                    }
    //                    else if (j == 1 || j == 3 || j == 5 || j == 7)
    //                    {
    //                        cellText = Server.HtmlDecode(grdDetails2.Rows[i].Cells[j].Text);
    //                    }
    //                    else
    //                    {
    //                        if (grdDetails2.Rows[i].Cells[j].Controls[0].Visible == true)
    //                        {
    //                            h4 = (HyperLink)grdDetails2.Rows[i].Cells[j].Controls[0];
    //                            cellText = h4.Text;
    //                        }
    //                        else
    //                            continue;
    //                    }
    //                    cellText = Server.HtmlDecode(cellText);

    //                    // h4 = (HyperLink)grdDetails2.Rows[i].Controls[j];
    //                    if (j == 0 && (cellText == "CFE - Total" || cellText == "CFO - Total" || cellText == "CFE + CFO TOTAL" || cellText == "GRAND TOTAL"))
    //                    {
    //                        cellText = "";
    //                        phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.BOLD, Color.BLACK)));
    //                    }
    //                    else
    //                    {
    //                        string cellTextnew1 = Server.HtmlDecode(grdDetails2.Rows[i].Cells[1].Text);
    //                        if ((cellTextnew1 == "CFE - Total" || cellTextnew1 == "CFO - Total" || cellTextnew1 == "CFE + CFO TOTAL" || cellTextnew1 == "GRAND TOTAL"))
    //                        {
    //                            phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.BOLD, Color.BLACK)));
    //                        }
    //                        else
    //                        {
    //                            phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.BLACK)));
    //                        }
    //                    }


    //                    if (j == 0)
    //                    {
    //                        cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
    //                        cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
    //                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
    //                    }
    //                    else if (j == 1)
    //                    {
    //                        cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
    //                        cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
    //                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
    //                    }
    //                    else
    //                    {
    //                        cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
    //                        cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
    //                        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
    //                    }


    //                    //cell.Border = 2;
    //                    //cell.BorderColor = Color.BLACK;
    //                    if (grdDetails2.Rows[i].RowState == DataControlRowState.Alternate)
    //                    {
    //                        cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA"));
    //                        cell.BorderWidthRight = 0.5f;
    //                        cell.BorderWidthLeft = 0.5f;
    //                        cell.BorderWidthTop = 0.5f;
    //                        cell.BorderWidthBottom = 0.5f;

    //                        cell.BorderColorBottom = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));  //#E5E5E5
    //                        cell.BorderColorTop = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));
    //                        cell.BorderColorLeft = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));
    //                        cell.BorderColorRight = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));
    //                    }
    //                    else
    //                    {
    //                        cell.BorderWidthRight = 0.5f;
    //                        cell.BorderWidthLeft = 0.5f;
    //                        cell.BorderWidthTop = 0.5f;
    //                        cell.BorderWidthBottom = 0.5f;

    //                        cell.BorderColorBottom = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));  //#E5E5E5
    //                        cell.BorderColorTop = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));
    //                        cell.BorderColorLeft = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));
    //                        cell.BorderColorRight = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));
    //                    }

    //                    //cell.BackgroundColor = Color.GRAY;

    //                    cell.PaddingBottom = 5;
    //                    cell.MinimumHeight = 30f;
    //                    tablenew.AddCell(cell);
    //                }
    //            }
    //            var remainingPageSpace = writer.GetVerticalPosition(false) - document.BottomMargin;
    //            var initialPosition = writer.GetVerticalPosition(false);
    //            var tablehiht = tablenew.TotalHeight;

    //            if (remainingPageSpace >= tablehiht && remainingPageSpace - 40 <= tablehiht)
    //            {
    //                contentBytenew.SetColorStroke(color);
    //                contentBytenew.Circle(document.PageSize.Width - 23f, document.PageSize.Bottom + 23f, 10f);
    //                contentBytenew.Stroke();

    //                ColumnText.ShowTextAligned(contentBytenew, Element.ALIGN_RIGHT, new Phrase((writer.PageNumber).ToString(), FontFactory.GetFont("Trebuchet MS", 12, Font.BOLD, Color.BLACK)), document.PageSize.Width - 20f, document.PageSize.Bottom + 20f, 2);

    //                document.Add(tablenew);
    //                document.NewPage();
    //                tablenew.DeleteBodyRows();


    //                phrase = new Phrase();
    //                phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
    //                cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
    //                cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
    //                cell.HorizontalAlignment = Element.ALIGN_CENTER;
    //                cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails2.HeaderStyle.BackColor);  //#009688
    //                cell.PaddingBottom = 5;
    //                cell.Colspan = 2;
    //                cell.MinimumHeight = 30f;
    //                tablenew.AddCell(cell);

    //                phrase = new Phrase();
    //                cellTextnew = "DLC";
    //                phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
    //                cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
    //                cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
    //                cell.HorizontalAlignment = Element.ALIGN_CENTER;
    //                cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails2.HeaderStyle.BackColor);  //#009688
    //                cell.PaddingBottom = 5;
    //                cell.Colspan = 2;
    //                cell.MinimumHeight = 30f;
    //                tablenew.AddCell(cell);

    //                phrase = new Phrase();
    //                cellTextnew = "SLC";
    //                phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
    //                cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
    //                cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
    //                cell.HorizontalAlignment = Element.ALIGN_CENTER;
    //                cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails2.HeaderStyle.BackColor);  //#009688
    //                cell.PaddingBottom = 5;
    //                cell.Colspan = 2;
    //                cell.MinimumHeight = 30f;
    //                tablenew.AddCell(cell);

    //                phrase = new Phrase();
    //                cellTextnew = "";
    //                phrase.Add(new Chunk(cellTextnew, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
    //                cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
    //                cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
    //                cell.HorizontalAlignment = Element.ALIGN_CENTER;
    //                cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails2.HeaderStyle.BackColor);  //#009688
    //                cell.PaddingBottom = 5;
    //                cell.Colspan = 2;
    //                cell.MinimumHeight = 30f;
    //                tablenew.AddCell(cell);
    //                for (int k = 0; k < CountColumns; k++)
    //                {
    //                    string cellText = "";

    //                    cellText = Server.HtmlDecode(grdDetails2.Columns[k].HeaderText);

    //                    phrase = new Phrase();
    //                    phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
    //                    cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
    //                    cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
    //                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
    //                    cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails2.HeaderStyle.BackColor);  //#009688
    //                    cell.PaddingBottom = 5;
    //                    cell.MinimumHeight = 30f;
    //                    tablenew.AddCell(cell);
    //                }
    //            }
    //        }
    //        for (int i = 0; i < CountColumns; i++)
    //        {
    //            string cellText = "";

    //            cellText = Server.HtmlDecode(grdDetails2.Columns[i].FooterText);

    //            phrase = new Phrase();
    //            phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
    //            cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
    //            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
    //            cell.HorizontalAlignment = Element.ALIGN_CENTER;
    //            cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails2.HeaderStyle.BackColor);  //#009688
    //            cell.PaddingBottom = 5;
    //            cell.MinimumHeight = 30f;
    //            tablenew.AddCell(cell);
    //        }
    //        document.Add(tablenew);

    //        contentBytenew.SetColorStroke(color);
    //        contentBytenew.Circle(document.PageSize.Width - 23f, document.PageSize.Bottom + 23f, 10f);
    //        contentBytenew.Stroke();
    //        ColumnText.ShowTextAligned(contentBytenew, Element.ALIGN_RIGHT, new Phrase((writer.PageNumber).ToString(), FontFactory.GetFont("Trebuchet MS", 12, Font.BOLD, Color.BLACK)), document.PageSize.Width - 20f, document.PageSize.Bottom + 20f, 2);

    //        document.Close();
    //        byte[] bytes = memoryStream.ToArray();
    //        memoryStream.Close();
    //        Response.Clear();
    //        Response.ContentType = "application/pdf";
    //        Response.AddHeader("Content-Disposition", "attachment; filename=Report" + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
    //        Response.ContentType = "application/pdf";

    //        //Response.ContentType = "application/vnd.ms-excel";
    //        //Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
    //        //Response.ContentType = "application/vnd.ms-excel";

    //        Response.Buffer = true;
    //        Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //        Response.BinaryWrite(bytes);
    //        Response.End();
    //        Response.Close();


    //    }
    //}
    public partial class Footer : PdfPageEventHelper
    {
        //new Color(127, 127, 127)
        public override void OnEndPage(PdfWriter writer, Document doc)
        {
            Paragraph footer = new Paragraph(char.ConvertFromUtf32(169).ToString() + " Industry Chasing Cell.  Government of Telangana.", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD, Color.BLACK));
            footer.Alignment = Element.ALIGN_LEFT;
            PdfPTable footerTbl = new PdfPTable(1);
            footerTbl.TotalWidth = 500f;
            footerTbl.HorizontalAlignment = Element.ALIGN_LEFT;
            PdfPCell cell = new PdfPCell(footer);
            cell.Border = 0;
            cell.PaddingLeft = 10;
            footerTbl.AddCell(cell);
            footerTbl.WriteSelectedRows(0, -1, 30, 40, writer.DirectContent);
        }
    }
    private static void DrawLine(PdfWriter writer, float x1, float y1, float x2, float y2, Color color)
    {
        PdfContentByte contentByte = writer.DirectContent;
        contentByte.SetColorStroke(color);
        contentByte.MoveTo(x1, y1);
        contentByte.LineTo(x2, y2);
        contentByte.SetLineWidth(1f);
        contentByte.Stroke();
    }
    private static void DrawLineMiddleline(PdfWriter writer, float x1, float y1, float x2, float y2, Color color)
    {
        PdfContentByte contentByte = writer.DirectContent;
        contentByte.SetColorStroke(color);
        contentByte.MoveTo(x1, y1);
        contentByte.LineTo(x2, y2);
        contentByte.SetLineWidth(2f);
        contentByte.Stroke();
    }
    private static PdfPCell PhraseCell(Phrase phrase, int align)
    {
        PdfPCell cell = new PdfPCell(phrase);
        cell.BorderColor = Color.WHITE;
        cell.VerticalAlignment = PdfCell.ALIGN_TOP;
        cell.HorizontalAlignment = align;
        cell.PaddingBottom = 2f;
        cell.PaddingTop = 0f;
        return cell;
    }
    private static PdfPCell PhraseCellnew(Phrase phrase, int align)
    {
        PdfPCell cell = new PdfPCell(phrase);
        cell.BorderColor = Color.WHITE;
        cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
        cell.HorizontalAlignment = align;
        //cell.PaddingBottom = 5f;
        //cell.PaddingTop = 5f;
        cell.BorderWidthRight = 0.5f;
        cell.BorderWidthLeft = 0.5f;
        cell.BorderWidthTop = 0.5f;
        cell.BorderWidthBottom = 0.5f;
        cell.BorderColorBottom = Color.BLACK;
        cell.BorderColorTop = Color.BLACK;
        cell.BorderColorLeft = Color.BLACK;
        cell.BorderColorRight = Color.BLACK;
        cell.MinimumHeight = 30f;

        return cell;
    }
    private static PdfPCell ImageCell(string path, float scale, int align)
    {
        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));
        image.ScalePercent(scale);
        PdfPCell cell = new PdfPCell(image);
        cell.BorderColor = Color.WHITE;
        cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
        cell.HorizontalAlignment = align;
        cell.PaddingBottom = 0f;
        cell.PaddingTop = 0f;
        return cell;
    }

    public string DisplayWithSuffix(int num)
    {
        if (num.ToString().EndsWith("11")) return num.ToString() + "th";
        if (num.ToString().EndsWith("12")) return num.ToString() + "th";
        if (num.ToString().EndsWith("13")) return num.ToString() + "th";
        if (num.ToString().EndsWith("1")) return num.ToString() + "st";
        if (num.ToString().EndsWith("2")) return num.ToString() + "nd";
        if (num.ToString().EndsWith("3")) return num.ToString() + "rd";
        return num.ToString() + "th";
    }

    public DataSet GET_ABSTRACT_INCENTIVEPROCEEDINGS_CASTE(string Distid, string fromdate, string Todate, string cast)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@DISTRICTCD",SqlDbType.VarChar),
               new SqlParameter("@Fromdate",SqlDbType.VarChar),
               new SqlParameter("@Todate",SqlDbType.VarChar),
               new SqlParameter("@Cast",SqlDbType.VarChar)
           };
        pp[0].Value = Distid;
        pp[1].Value = fromdate;
        pp[2].Value = Todate;
        pp[3].Value = cast;
        Dsnew = Gen.GenericFillDs("USP_GET_ABSTRACT_INCENTIVEPROCEEDINGS_CASTE", pp);
        return Dsnew;
    }
    protected void grdDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string DisID = e.CommandArgument.ToString();
        if(e.CommandName== "NOUNITS_SLC")
        {
            Response.Redirect("frmIncentiveProceedingabstractcastwise_slcdrilldown.aspx?status=A&Dist=" + DisID + "&fromdate=" + txtFromDate.Text.Trim() + "&todate=" + txtTodate.Text.Trim() + "&caste=" + ddl_cast.SelectedItem.Text.Trim() + "&type="+"SLC");
        }
        else if (e.CommandName == "WorkingUnits_SLC")
        {
            Response.Redirect("frmIncentiveProceedingabstractcastwise_slcdrilldown.aspx?status=B&Dist=" + DisID + "&fromdate=" + txtFromDate.Text.Trim() + "&todate=" + txtTodate.Text.Trim() + "&caste=" + ddl_cast.SelectedItem.Text.Trim() + "&type=" + "SLC");
        }
        else if (e.CommandName == "UCNotUpdated_SLC")
        {
            Response.Redirect("frmIncentiveProceedingabstractcastwise_slcdrilldown.aspx?status=C&Dist=" + DisID + "&fromdate=" + txtFromDate.Text.Trim() + "&todate=" + txtTodate.Text.Trim() + "&caste=" + ddl_cast.SelectedItem.Text.Trim() + "&type=" + "SLC");
        }
        else if (e.CommandName == "ClosedUnits_SLC")
        {
            Response.Redirect("frmIncentiveProceedingabstractcastwise_slcdrilldown.aspx?status=D&Dist=" + DisID + "&fromdate=" + txtFromDate.Text.Trim() + "&todate=" + txtTodate.Text.Trim() + "&caste=" + ddl_cast.SelectedItem.Text.Trim() + "&type=" + "SLC");
        }
        
    }
    protected void grdDetails1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string DisID = e.CommandArgument.ToString();
        if (e.CommandName == "NOUNITS_DLC")
        {
            Response.Redirect("../frmIncentiveProceedingabstractcastwise_slcdrilldown.aspx?status=A&Dist=" + DisID + "&fromdate=" + txtFromDate.Text.Trim() + "&todate=" + txtTodate.Text.Trim() + "&caste=" + ddl_cast.SelectedItem.Text.Trim() + "&type=" + "DLC");
        }
        else if (e.CommandName == "WorkingUnits_DLC")
        {
            Response.Redirect("frmIncentiveProceedingabstractcastwise_slcdrilldown.aspx?status=B&Dist=" + DisID + "&fromdate=" + txtFromDate.Text.Trim() + "&todate=" + txtTodate.Text.Trim() + "&caste=" + ddl_cast.SelectedItem.Text.Trim() + "&type=" + "DLC");
        }
        else if (e.CommandName == "UCNotUpdated_DLC")
        {
            Response.Redirect("frmIncentiveProceedingabstractcastwise_slcdrilldown.aspx?status=C&Dist=" + DisID + "&fromdate=" + txtFromDate.Text.Trim() + "&todate=" + txtTodate.Text.Trim() + "&caste=" + ddl_cast.SelectedItem.Text.Trim() + "&type=" + "DLC");
        }
        else if (e.CommandName == "ClosedUnits_DLC")
        {
            Response.Redirect("frmIncentiveProceedingabstractcastwise_slcdrilldown.aspx?status=D&Dist=" + DisID + "&fromdate=" + txtFromDate.Text.Trim() + "&todate=" + txtTodate.Text.Trim() + "&caste=" + ddl_cast.SelectedItem.Text.Trim() + "&type=" + "DLC");
        }

    }
}