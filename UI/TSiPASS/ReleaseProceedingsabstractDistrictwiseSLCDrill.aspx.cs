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

public partial class UI_TSIPASS_ReleaseProceedingsabstractDistrictwiseSLCDrill : System.Web.UI.Page
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
            Response.Redirect("../../Index.aspx");
        }

        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            string status = Request.QueryString[0].ToString().Trim();
            string Procdno = Request.QueryString[1].ToString().Trim();
            string Dist = Request.QueryString[2].ToString().Trim();

            ds = GetAbstractdrill(Dist, Procdno, status);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
            }
            else
            {
                Label1.Text = "No Records Found ";
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }

            if (status == "A")
            {
                lblHeading.Text = "No of Units for which release proceedings are issued (SLC)";
            }
            else if (status == "B")
            {
                lblHeading.Text = "UC Updated - Working Units(SLC)";
            }
            else if (status == "C")
            {
                lblHeading.Text = "UC Updated - Closed Units(SLC)";
            }
            else if (status == "D")
            {
                lblHeading.Text = "UC Not Updated Units(SLC)";
            }
           
            // HyperLink1.NavigateUrl = "frmR1ReportKMRNew.aspx?status=" + "" + "&lbl=Total Applications Received&fromdate=" + txtFromDate + "&todate=" + txtTodate;
        }
    }

    public DataSet GetAbstractdrill(string Distid, string ProcdNo, string Status)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@DISTRICTCD",SqlDbType.VarChar),
               new SqlParameter("@ReleaseProceedingNo",SqlDbType.VarChar),
               new SqlParameter("@Status",SqlDbType.VarChar)
           };
        pp[0].Value = Distid;
        pp[1].Value = ProcdNo;
        pp[2].Value = Status;
        Dsnew = Gen.GenericFillDs("USP_GET_Release_Proceedings_abstract_District_wise_Drill", pp);
        return Dsnew;
    }

    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
        // ExportToExcel();

    }
}