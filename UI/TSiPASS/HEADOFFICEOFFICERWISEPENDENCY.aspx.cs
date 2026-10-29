using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections.Generic;


public partial class UI_TSiPASS_HEADOFFICEOFFICERWISEPENDENCY : System.Web.UI.Page
{
    int WITHINCOUNT, BEYONDCOUNT, WITHINCOUNTQUERY, BEYONDCOUNTQUERY;

    DB.DB con = new DB.DB();
    int Sno = 0;

    DataSet ds;
    DataTable dt;


    DataSet dslist;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgrid();
        }

    }

    public void fillgrid()
    {
        DataSet dsnew = new DataSet();
       
        DataSet vehicleDS = new DataSet();


            vehicleDS = GETHEADOFFICEOFFICERWISEPENDENCY();
        grdDetails.DataSource = vehicleDS;
        grdDetails.DataBind();

    }
    public DataSet GETHEADOFFICEOFFICERWISEPENDENCY()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_INCENTIVE_PENDENCY_HEADOFFICE_NEW_TEST10022025", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


           
            da.Fill(ds);
            return ds;


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string USERID1 = "";
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int WITHINCOUNT1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "WITHINCOUNT"));
            WITHINCOUNT = WITHINCOUNT1 + WITHINCOUNT;

            int BEYONDCOUNT1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "BEYONDCOUNT"));
            BEYONDCOUNT = BEYONDCOUNT1 + BEYONDCOUNT;

            int WITHINCOUNTQUERY1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "WITHINCOUNTQUERY"));
            WITHINCOUNTQUERY = WITHINCOUNTQUERY + WITHINCOUNTQUERY1;

            int BEYONDCOUNTQUERY1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "BEYONDCOUNTQUERY"));
            BEYONDCOUNTQUERY = BEYONDCOUNTQUERY1 + BEYONDCOUNTQUERY;
           
            USERID1 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "USERID"));

            HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
            if (h1.Text != "0")
            {
                h1.NavigateUrl = "HEADOFFICEPENDENCYDRILLDOWN.aspx?Id=" + USERID1 + "&Status=A";
            }
            HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
            if (h2.Text != "0")
            {
                h2.NavigateUrl = "HEADOFFICEPENDENCYDRILLDOWN.aspx?Id=" + USERID1 + "&Status=B";
            }
            HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
            if (h3.Text != "0")
            {
                h3.NavigateUrl = "HEADOFFICEPENDENCYDRILLDOWN.aspx?Id=" + USERID1 + "&Status=C";
            }
            HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
            if (h4.Text != "0")
            {
                h4.NavigateUrl = "HEADOFFICEPENDENCYDRILLDOWN.aspx?Id=" + USERID1 + "&Status=D";
            }

        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {

            e.Row.Cells[1].Text = "Grand Total";
            e.Row.Cells[2].Text = WITHINCOUNT.ToString();
            e.Row.Cells[3].Text = BEYONDCOUNT.ToString();
            e.Row.Cells[4].Text = WITHINCOUNTQUERY.ToString();
            e.Row.Cells[5].Text = BEYONDCOUNTQUERY.ToString();
            e.Row.Cells[6].Text = (WITHINCOUNT+WITHINCOUNTQUERY).ToString();
            e.Row.Cells[7].Text = (BEYONDCOUNT+BEYONDCOUNTQUERY).ToString();

            USERID1 = "%";
            HyperLink h1 = new HyperLink();
            h1.Text = WITHINCOUNT.ToString();
            if (h1.Text != "0")
            {
                // h1.NavigateUrl = "HEADOFFICEPENDENCYDRILLDOWN.aspx?Id=" + USERID1 + "&Status=A";
                e.Row.Cells[2].Controls.Add(h1);
            }
            HyperLink h2 = new HyperLink();
            h2.Text = BEYONDCOUNT.ToString();
            if (h2.Text != "0")
            {
                // h2.NavigateUrl = "HEADOFFICEPENDENCYDRILLDOWN.aspx?Id=" + USERID1 + "&Status=B";
                e.Row.Cells[3].Controls.Add(h2);
            }
            HyperLink h3 = new HyperLink();
            h3.Text = WITHINCOUNTQUERY.ToString();
            if (h3.Text != "0")
            {
                // h3.NavigateUrl = "HEADOFFICEPENDENCYDRILLDOWN.aspx?Id=" + USERID1 + "&Status=C";
                e.Row.Cells[4].Controls.Add(h3);
            }
            HyperLink h4 = new HyperLink();
            h4.Text = BEYONDCOUNTQUERY.ToString();
            if (h4.Text != "0")
            {
                // h4.NavigateUrl = "HEADOFFICEPENDENCYDRILLDOWN.aspx?Id=" + USERID1 + "&Status=D";
                e.Row.Cells[5].Controls.Add(h4);
            }


            h1.ForeColor = System.Drawing.Color.White;
            h2.ForeColor = System.Drawing.Color.White;
            h3.ForeColor = System.Drawing.Color.White;
            h4.ForeColor = System.Drawing.Color.White;

        }
    }
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;

            GridViewRow HeaderGridRow = new GridViewRow(1, 2, DataControlRowType.Header, DataControlRowState.Insert);
            HeaderGridRow.HorizontalAlign = HorizontalAlign.Center;

            TableCell HeaderCell0 = new TableCell();
            HeaderCell0.Text = "";
            HeaderCell0.ColumnSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell0);

            TableCell HeaderCell1 = new TableCell();
            HeaderCell1.Text = "Applications";
            HeaderCell1.ColumnSpan = 2;
            HeaderCell1.HorizontalAlign = HorizontalAlign.Center;
            HeaderGridRow.Cells.Add(HeaderCell1);
            HeaderGridRow.Controls.Add(HeaderCell1);

            TableCell HeaderCell2 = new TableCell();
            HeaderCell2.Text = "Query Applications";
            HeaderCell2.ColumnSpan = 2;
            HeaderCell2.HorizontalAlign = HorizontalAlign.Center;
            HeaderGridRow.Cells.Add(HeaderCell2);
            HeaderGridRow.Controls.Add(HeaderCell2);

            TableCell HeaderCell3 = new TableCell();
            HeaderCell3.Text = "Total";
            HeaderCell3.ColumnSpan = 2;
            HeaderCell3.HorizontalAlign = HorizontalAlign.Center;
            HeaderGridRow.Cells.Add(HeaderCell3);
            HeaderGridRow.Controls.Add(HeaderCell3);

            HeaderGridRow.HorizontalAlign = HorizontalAlign.Center;
            grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);


        }
    }
    protected void BtnSave2_Click(object sender, EventArgs e)
    {

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
            divPrint.Style["width"] = "680px";
            // Button1.Visible = false;
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