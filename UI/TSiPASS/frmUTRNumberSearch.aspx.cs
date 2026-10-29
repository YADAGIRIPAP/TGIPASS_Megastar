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

public partial class UI_TSiPASS_frmUTRNumberSearch : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    decimal NumberofApprovalsappliedfor1;
    DB.DB con = new DB.DB();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        DataSet ds= new DataSet();
        try
        {
            if (txtUserName.Text.Trim() != "")
            {
                ds=GetcfepaydetailsNew(txtUserName.Text.Trim());
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    grdDetails.DataSource = ds.Tables[0];
                    grdDetails.DataBind();
                    //grdDetails.Columns[2].Visible = false;
                    //grdDetails.Columns[3].Visible = false;
                }
                else
                {
                    grdDetails.DataSource = null;
                    grdDetails.DataBind();

                }
            }
            excel_button.Visible = true;
        }
        catch (Exception ex)
        {
        }
    }

    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdDetails.PageIndex = e.NewPageIndex;
        DataSet ds = new DataSet();
        ds = GetcfepaydetailsNew(txtUserName.Text.Trim());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
            //grdDetails.Columns[2].Visible = false;
            //grdDetails.Columns[3].Visible = false;
        }
        else
        {
            grdDetails.DataSource = null;
            grdDetails.DataBind();

        }
    }


    public DataSet GetcfepaydetailsNew(string UTRNO)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_UTRDETAILS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (UTRNO.Trim() == "" || UTRNO.Trim() == null || UTRNO.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@UTRNO", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@UTRNO", SqlDbType.VarChar).Value = UTRNO.ToString();


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
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmUTRNumberSearch.aspx");
    }

    protected void BtnExel_Click(object sender, EventArgs e)
    {
        ExportToExcel();
    }

    protected void ExportToExcel()
    {
        try
        {

            //Response.Clear();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment;filename=Total Applications Received" + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-excel";
            //using (StringWriter sw = new StringWriter())
            //{
            //    HtmlTextWriter hw = new HtmlTextWriter(sw);
            //    grdDetails.RenderControl(hw);
            //    Response.Output.Write(sw.ToString());
            //    HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
            //    HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
            //    HttpContext.Current.ApplicationInstance.CompleteRequest(); // Causes ASP.NET to bypass all events and filtering in the HTTP pipeline chain of execution and directly execute the EndRequest event.
            //    HttpContext.Current.Response.End();
            //}


            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/force-download";
            Response.AddHeader("content-disposition", "attachment;filename=TotalApplicationsReceived" + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                grdDetails.Columns[1].Visible = false;
                grdDetails.AllowPaging = false;
                DataSet ds = new DataSet();
                ds = GetcfepaydetailsNew(txtUserName.Text.Trim());
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    grdDetails.DataSource = ds.Tables[0];
                    grdDetails.DataBind();
                    //grdDetails.Columns[2].Visible = false;
                    //grdDetails.Columns[3].Visible = false;
                }
                else
                {
                    grdDetails.DataSource = null;
                    grdDetails.DataBind();

                }

                grdDetails.RenderControl(hw);
                //grdDetails.Columns.RemoveAt("View");
                Response.Output.Write(sw.ToString());
                //HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
                //HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                //HttpContext.Current.ApplicationInstance.CompleteRequest(); // Causes ASP.NET to bypass all events and filtering in the HTTP pipeline chain of execution and directly execute the EndRequest event.
                //HttpContext.Current.Response.End();
                Response.Flush();
                //Response.SuppressContent = true;
                //Response.Close();
                Response.End();
            }
        }
        catch (Exception e)
        {
            //Response.Write(e.ToString());
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }
}