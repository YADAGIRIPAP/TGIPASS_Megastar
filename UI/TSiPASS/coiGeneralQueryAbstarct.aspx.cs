using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;


public partial class UI_TSIPASS_coiGeneralQueryAbstarct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");

        }

        if (!IsPostBack)
        {
            SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
            SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
            DataSet oDataSet = new DataSet();
            string gmID = Session["uid"].ToString();
            osqlConnection.Open();
            oSqlDataAdapter = new SqlDataAdapter("cfeCfoGrievGenQuqery", osqlConnection);
            oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            oDataSet = new DataSet();
            oSqlDataAdapter.Fill(oDataSet);
            grdDetails.DataSource = oDataSet.Tables[0];
            grdDetails.DataBind();
        }
    

    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {        
            HyperLink h1 = (HyperLink)e.Row.Cells[1].Controls[0];
            HyperLink h2 = (HyperLink)e.Row.Cells[2].Controls[0];
            HyperLink h3 = (HyperLink)e.Row.Cells[3].Controls[0];
            HyperLink h4 = (HyperLink)e.Row.Cells[4].Controls[0];
          
            if (h1.Text != "")
            {
                string text = e.Row.Cells[0].Text.ToString();
                if (text == "CFE Appeal")
                h1.NavigateUrl = "frmcoiGeneralDD.aspx?status=cfeAppeal&code=trc";
                if (text == "CFO Appeal")
                    h1.NavigateUrl = "frmcoiGeneralDD.aspx?status=cfoAppeal&code=trc";
                if (text == "Grievance")
                    h1.NavigateUrl = "frmcoiGeneralDD.aspx?status=Griev&code=trc";
                if (text == "General Query")
                    h1.NavigateUrl = "frmcoiGeneralDD.aspx?status=GenQ&code=trc";
            }
            if (h2.Text != "")
            {
                string text = e.Row.Cells[0].Text.ToString();
                if (text == "CFE Appeal")
                    h2.NavigateUrl = "frmcoiGeneralDD.aspx?status=cfeAppeal&code=tp";
                if (text == "CFO Appeal")
                    h2.NavigateUrl = "frmcoiGeneralDD.aspx?status=cfoAppeal&code=tp";
                if (text == "Grievance")
                    h2.NavigateUrl = "frmcoiGeneralDD.aspx?status=Griev&code=tp";
                if (text == "General Query")
                    h2.NavigateUrl = "frmcoiGeneralDD.aspx?status=GenQ&code=tp";
               
            }
            if (h3.Text != "")
            {
                string text = e.Row.Cells[0].Text.ToString();
                if (text == "CFE Appeal")
                    h3.NavigateUrl = "frmcoiGeneralDD.aspx?status=cfeAppeal&code=tadr";
                if (text == "CFO Appeal")
                    h3.NavigateUrl = "frmcoiGeneralDD.aspx?status=cfoAppeal&code=tadr";
                if (text == "Grievance")
                    h3.NavigateUrl = "frmcoiGeneralDD.aspx?status=Griev&code=tadr";
                if (text == "General Query")
                    h3.NavigateUrl = "frmcoiGeneralDD.aspx?status=GenQ&code=tadr";
            
            }
            if (h4.Text != "")
            {
                string text = e.Row.Cells[0].Text.ToString();
                if (text == "CFE Appeal")
                    h4.NavigateUrl = "frmcoiGeneralDD.aspx?status=cfeAppeal&code=tr";
                if (text == "CFO Appeal")
                    h4.NavigateUrl = "frmcoiGeneralDD.aspx?status=cfoAppeal&code=tr";
                if (text == "Grievance")
                    h4.NavigateUrl = "frmcoiGeneralDD.aspx?status=Griev&code=tr";
                if (text == "General Query")
                    h4.NavigateUrl = "frmcoiGeneralDD.aspx?status=GenQ&code=tr";
            }
     
        }

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
            //string FileName = lblHeading.Text;
            //FileName = FileName.Replace(" ", "");
            //Response.AddHeader("content-disposition", "attachment;filename=" + FileName + DateTime.Now.ToString("M/d/yyyy") + ".xls");

            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
           // Government.Visible = true;
            td1.Style["width"] = "680px";
            Button1.Visible = false;
   
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                grdDetails.AllowPaging = false;
                //this.fillgrid();

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

                td1.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                Response.Write(style);
                //string label1text = Label1.Text;
                //string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='5'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='5'><h4>" + label1text + "</h4></td></td></tr></table>";
                //HttpContext.Current.Response.Write(headerTable);
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
            //    divPrint1.RenderControl(hw);
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