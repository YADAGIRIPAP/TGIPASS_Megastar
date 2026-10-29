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
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Globalization;
using System.Text;
using System.Data.SqlClient;

public partial class UI_TSiPASS_frmViewApprovalsSWD : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["appid"] != null)
            {
                txtFromDate.Text = Request.QueryString["fdt"].ToString();
                txtTodate.Text = Request.QueryString["tdt"].ToString();
                BindGrid();
            }
        }
    }
    public void BindGrid()
    {
        Label1.Text = "";
        DataSet dsnew = new DataSet();
        string FromdateforDB = "", TodateforDB = "";
        string ApprovalId= Request.QueryString["appid"].ToString();
        if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
        {
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        }
        dsnew = GetData(FromdateforDB, TodateforDB, ApprovalId);
      
        if (dsnew.Tables[0].Rows.Count > 0)
        {  
            grdDetails.DataSource = dsnew.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            //dsnew.Rows.Add(dsnew.NewRow());
            Label1.Text = "No Records Found ";
            grdDetails.DataSource = dsnew;
            grdDetails.DataBind();
           // grdDetails.Rows[0].Visible = false;
        }
        hdnAppName.Value = dsnew.Tables[1].Rows[0]["ApprovalName"].ToString();
        Label1.Text = hdnAppName.Value +" Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
    }
    public DataSet GetData(string fromdate, string todate,string ApprovalId)
    {

        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();

        try
        {
            da = new SqlDataAdapter("USP_GET_APPROVALS_BY_APPROVALID", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = fromdate.ToString();
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = todate.ToString();
            da.SelectCommand.Parameters.Add("@ApprovalId", SqlDbType.VarChar).Value = ApprovalId.ToString();
            da.SelectCommand.CommandTimeout = 3600;
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
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void BtnPDF_Click(object sender, EventArgs e)
    {
       
        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                grdDetails.AllowPaging = false;

                this.BindGrid();

                grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                grdDetails.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                grdDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
               
                grdDetails.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=TGiPASS-Approvals" + ".pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.Flush();
                Response.End();
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
            string FileName = hdnAppName.Value;
            FileName = FileName.Replace(" ", "");
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                divPrint1.Style["width"] = "680px";
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                divPrint1.RenderControl(hw);
                string label1text = Label1.Text;
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='11'><h4>" + FileName + "</h4></td></td></tr><tr><td align='center' colspan='11'><h4>" + label1text + "</h4></td></td></tr></table>";
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
}