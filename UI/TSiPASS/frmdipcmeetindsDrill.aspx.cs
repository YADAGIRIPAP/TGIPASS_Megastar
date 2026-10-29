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


public partial class UI_TSIPASS_frmdipcmeetindsDrill : System.Web.UI.Page
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
            string DistNo = Request.QueryString[1].ToString().Trim();
            string Year = Request.QueryString[2].ToString().Trim();

            ds = GetAbstractdrill(DistNo, status, Year);
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
                lblHeading.Text = "DIPC Meeting Information";
            }
            else if (status == "AA")
            {
                lblHeading.Text = "SLC Pendency (Within Timelines)";
            }
            else if (status == "B")
            {
                lblHeading.Text = "SLC Pendency (Beyond Timelines)";
            }
            else if (status == "C")
            {
                lblHeading.Text = "DLC Pendency (Within Timelines)";
            }
            else if (status == "D")
            {
                lblHeading.Text = "DLC Pendency (Beyond Timelines)";
            }
            else if (status == "E")
            {
                lblHeading.Text = "Total Pendency (Within Timelines)";
            }
            else if (status == "F")
            {
                lblHeading.Text = "Total Pendency (Beyond Timelines)";
            }

            // HyperLink1.NavigateUrl = "frmR1ReportKMRNew.aspx?status=" + "" + "&lbl=Total Applications Received&fromdate=" + txtFromDate + "&todate=" + txtTodate;
        }
    }

    public DataSet GetAbstractdrill(string Dist, string Status,string year)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@District",SqlDbType.VarChar),
               new SqlParameter("@Status",SqlDbType.VarChar),
               new SqlParameter("@financialYear",SqlDbType.VarChar)
           };
        pp[0].Value = Dist;
        pp[1].Value = Status;
        pp[2].Value = year;
        //Dsnew = Gen.GenericFillDs("USP_GET_DIPC_MEETINGS_ABSTRACT_DRILL", pp);
        if (Status == "A")
        {
            Dsnew = Gen.GenericFillDs("USP_GET_DIPC_MEETINGS_ABSTRACT_DRILL", pp);
        }
        else
        {
            Dsnew = Gen.GenericFillDs("USP_GET_DIPC_MEETINGS_ABSTRACT_NEW_PENDENCYWISE_DRILLDOWN", pp);
        }
        return Dsnew;
    }

    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
        // ExportToExcel();

    }
}