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


public partial class UI_TSiPASS_frmEODBUserData : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFromDate.Text = "01-01-2024";
            DateTime today = DateTime.Today;
            txtTodate.Text = today.ToString("dd-MM-yyyy");
            BindDepts();
        }
    }
    public void BindGrid()
    {
        Label1.Text = "";
        DataSet dsnew = new DataSet();
        string FromdateforDB = "", TodateforDB = "";
        int DeptId = Convert.ToInt32(ddlDepartment.SelectedValue.ToString());
        int ApprovalId = Convert.ToInt32(ddlapprovalname.SelectedValue.ToString());
        string AppType = ddlType.SelectedValue.ToString();
        if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
        {
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        }
        dsnew = GetData(FromdateforDB, TodateforDB, ApprovalId, DeptId, AppType);

        if (dsnew.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = dsnew.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            Label1.Text = "No Records Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }

        Label1.Text = " Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
    }
    public DataSet GetData(string fromdate, string todate, int ApprovalId, int DeptId, string AppType)
    {

        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();

        try
        {
            da = new SqlDataAdapter("SP_GETUSERDATA_BYDEPARTMENT", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@FROMDATE", SqlDbType.VarChar).Value = fromdate.ToString();
            da.SelectCommand.Parameters.Add("@TODATE", SqlDbType.VarChar).Value = todate.ToString();
            da.SelectCommand.Parameters.Add("@APPROVALID", SqlDbType.Int).Value = ApprovalId.ToString();
            da.SelectCommand.Parameters.Add("@DEPTID", SqlDbType.Int).Value = DeptId.ToString();
            da.SelectCommand.Parameters.Add("@APPLTYPE", SqlDbType.VarChar).Value = AppType.ToString();
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
    public void BindDepts()
    {
        DataSet dsd = new DataSet();
        dsd = Gen.GetDepartment();
        ddlDepartment.DataSource = dsd.Tables[0];
        ddlDepartment.DataValueField = "Dept_Id";
        ddlDepartment.DataTextField = "Dept_Name";
        ddlDepartment.DataBind();
        ddlDepartment.Items.Insert(0, "--Select--");
        if (Session["user_code"].ToString().Trim() != "")
        {
            ddlDepartment.SelectedValue = Session["user_code"].ToString().Trim();
            ddlDepartment_TextChanged(this, EventArgs.Empty);
            ddlDepartment.Enabled = false;
        }
    }
    protected void ddlDepartment_TextChanged(object sender, EventArgs e)
    {
        DataSet dsdept = new DataSet();
        dsdept = Gen.GetDeptApprovalsListFeedback(Convert.ToInt32(ddlDepartment.SelectedValue));
        ddlapprovalname.DataSource = dsdept.Tables[0];
        ddlapprovalname.DataValueField = "ApprovalId";
        ddlapprovalname.DataTextField = "ApprovalName";
        ddlapprovalname.DataBind();
        ddlapprovalname.Items.Insert(0, "--Select--");
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
                Response.AddHeader("content-disposition", "attachment;filename=EODBUserData" + ".pdf");
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
            string FileName = "EODB User Data";
            FileName = FileName.Replace(" ", "");
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                divPrint1.Style["width"] = "700px";
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                divPrint1.RenderControl(hw);
                string label1text = Label1.Text;
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='9'><h4>" + FileName + "</h4></td></td></tr><tr><td align='center' colspan='9'><h4>" + label1text + "</h4></td></td></tr></table>";
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