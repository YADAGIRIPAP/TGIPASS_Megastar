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

public partial class UI_TSiPASS_frmIncentiveProceedingabstractcastwise_slcdrilldown : System.Web.UI.Page
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
            DataSet ds = new DataSet();
            string status = Request.QueryString[0].ToString().Trim();
            string Dist = Request.QueryString[1].ToString().Trim();
            string caste = Request.QueryString["caste"].ToString().Trim();
            string type = Request.QueryString["type"].ToString().Trim();
            string txtFromDate = "", txtTodate = "";
            if (Request.QueryString["fromdate"] != null && Request.QueryString["fromdate"] != "" && Request.QueryString["todate"] != null && Request.QueryString["todate"] != "")
            {
                // Label1.Text = "Report from " + Request.QueryString["fromdate"].ToString().Trim() + " To " + Request.QueryString["todate"].ToString().Trim();
                txtFromDate = Request.QueryString["fromdate"].ToString().Trim();
                txtTodate = Request.QueryString["todate"].ToString().Trim();
                Label1.Text = "Report from " + txtFromDate.Trim() + " To " + txtTodate.Trim();
            }
            else
                Label1.Text = "Report from 1st April 2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
            string FromdateforDB = "", TodateforDB = "";
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));

            ds = GET_ABSTRACT_INCENTIVEPROCEEDINGSCASTWIESE_SLC_DRILL(Dist, FromdateforDB, TodateforDB, status, caste, type);
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
                lblHeading.Text = "No of Units for which release proceedings are issued (DLC)";
            }
            else if (status == "B")
            {
                lblHeading.Text = "No of Units for which release proceedings are issued (SLC)";
            }
            else if (status == "C")
            {
                lblHeading.Text = "Total No. of Units for which release proceedings are issued (DLC & SLC)";
            }
            if (status == "D")
            {
                lblHeading.Text = "UC Updated - Working Units(DLC) ";
            }
            else if (status == "E")
            {
                lblHeading.Text = "UC Updated - Working Units(SLC)";
            }
            else if (status == "F")
            {
                lblHeading.Text = "Total No. of Units for which UC Updated - Working Units(DLC & SLC)";
            }
            if (status == "G")
            {
                lblHeading.Text = "UC Updated - Closed Units(DLC) ";
            }
            else if (status == "H")
            {
                lblHeading.Text = "UC Updated - Closed Units(SLC)";
            }
            else if (status == "I")
            {
                lblHeading.Text = "Total No. of Units for which UC Updated - Closed Units(DLC & SLC)";
            }
            if (status == "G")
            {
                lblHeading.Text = "UC Not Updated Units(DLC) ";
            }
            else if (status == "H")
            {
                lblHeading.Text = "UC Not Updated Units(SLC)";
            }
            else if (status == "I")
            {
                lblHeading.Text = "Total No. of Units for which UC Not Updated Units(DLC & SLC)";
            }
            // HyperLink1.NavigateUrl = "frmR1ReportKMRNew.aspx?status=" + "" + "&lbl=Total Applications Received&fromdate=" + txtFromDate + "&todate=" + txtTodate;
        }
    }
    public DataSet GET_ABSTRACT_INCENTIVEPROCEEDINGSCASTWIESE_SLC_DRILL(string Distid, string fromdate, string Todate, string Status,string caste,string type1)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@DISTRICTCD",SqlDbType.VarChar),
               new SqlParameter("@Fromdate",SqlDbType.VarChar),
               new SqlParameter("@Todate",SqlDbType.VarChar),
               new SqlParameter("@Status",SqlDbType.VarChar),
               new SqlParameter("@Cast",SqlDbType.VarChar),
               new SqlParameter("@TYPE",SqlDbType.VarChar)

           };
        pp[0].Value = Distid;
        pp[1].Value = fromdate;
        pp[2].Value = Todate;
        pp[3].Value = Status;
        pp[4].Value = caste;
        pp[5].Value = type1;
        Dsnew = Gen.GenericFillDs("USP_GET_ABSTRACT_INCENTIVEPROCEEDINGSCASTWIESE_SLC_DRILL", pp);
        return Dsnew;
    }

    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
        // ExportToExcel();

    }
}