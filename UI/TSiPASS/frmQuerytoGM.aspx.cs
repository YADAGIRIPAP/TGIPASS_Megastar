using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Threading;
using System.Security.Cryptography;
public partial class UI_TSiPASS_frmQuerytoGM : System.Web.UI.Page
{
    General Gen = new General();
    DataSet ds = new DataSet();
    DataSet odds = new DataSet();
    comFunctions cmf = new comFunctions();
    comFunctions obcmf = new comFunctions();
    Fetch objFetch = new Fetch();
    static DataTable dtMyTable;
    static DataTable dtMyTableCertificate;
    static DataTable dtMyTableAmount;
    static DataTable dtMyTableReject;
    static DataTable dtMyTableCertificateAmount;
    string LoanAggrementCheck = "0";
    string casteGenderGmUpdate = "0";
    List<officerRemarks> lstremarksad = new List<officerRemarks>();
    List<officerRemarks> lstremarks = new List<officerRemarks>();
    List<officerRemarks> lstremarksamount = new List<officerRemarks>();
    List<officerForwarded> lstincentives = new List<officerForwarded>();
    static DataTable dtMyTable1;
    DataSet dsCAF = new DataSet();
    DataSet dsCAF_Rej = new DataSet();
    string Incids = "";
    DB.DB con = new DB.DB();
    string txtUnitname1, txtApplicantName1, txtunitemailid1, txtunitmobileno1, ddldistrictunit1, querydesc, incentivename;
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds = GetQueryHistory();

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtUnitname1 = ds.Tables[0].Rows[0]["UnitName"].ToString();
            txtApplicantName1 = ds.Tables[0].Rows[0]["ApplciantName"].ToString();
            txtunitemailid1 = ds.Tables[0].Rows[0]["UnitEmail"].ToString();
            txtunitmobileno1 = ds.Tables[0].Rows[0]["UnitMObileNo"].ToString();
            ddldistrictunit1 = ds.Tables[0].Rows[0]["District_Name"].ToString();
            querydesc = ds.Tables[0].Rows[0]["Remarks"].ToString();
            incentivename = ds.Tables[0].Rows[0]["IncentiveName"].ToString();
            SendSmsEmail(querydesc, incentivename, txtUnitname1, txtunitmobileno1, txtunitemailid1, txtApplicantName1, ddldistrictunit1);
        }
    }

    public void SendSmsEmail(string qquerydesc, string qincentivename, string qUnitName, string qUnitMobileNo, string qUnitEmail, string qApplicantName, string qDistrictName)
    {
        try
        {
            DataSet dsAppliedIncentives = new DataSet();
            string UnitName = "", UnitMobileNo = "", UnitEmail = "", ApplicantName = "", DistrictName = "", QueryRaisedDate = "";

            UnitName = txtUnitname1;
            ApplicantName = txtApplicantName1;
            UnitEmail = txtunitemailid1;
            UnitMobileNo = txtunitmobileno1;
            DistrictName = ddldistrictunit1;
            QueryRaisedDate = DateTime.Now.ToString("dd/MM/yyyy");

            string nameuid = UnitEmail.Replace("@", "(at)");
            try
            {
                cmf.SendMailIncentive(UnitEmail, "Dear " + UnitName + ", Query is raised for Your incentives application on " + QueryRaisedDate + ", and Query raised incentives : " + incentivename + ", and query description is  " + querydesc + ". If you fail to furnish the information within 45 Days from the date of query raise the application will be rejected. <br /> Thank You, GM, DIC -" + DistrictName + ",<br />  Govt. of Telangana.");

            }
            catch (Exception ex)
            {
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
            try
            {
                cmf.SendSingleSMSnew(UnitMobileNo, "Dear " + UnitName + ", Query is raised for Your incentives application on " + QueryRaisedDate + ", and Query raised incentives : " + incentivename + ",If you fail to furnish the information within 45 Days from the date of query raise the application will be rejected. A detail mail is sent to " + nameuid + "," + '\n' + "Thank You," + '\n' + "GM, DIC -" + DistrictName + "," + '\n' + "Govt. of Telangana.", "1007693722296639652");	

            }
            catch (Exception ex)
            {
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
        }
    }

    public DataSet GetQueryHistory()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            //da = new SqlDataAdapter("USP_GET_IOQuery_History", con.GetConnection);
            da = new SqlDataAdapter("USP_GET_GMQUERYDETAILS", con.GetConnection);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            //if (IncentiveID == null)
            //{
            //    da.SelectCommand.Parameters.Add("@IncentiveID", SqlDbType.VarChar).Value = null;
            //}
            //else
            //{
            //    da.SelectCommand.Parameters.Add("@IncentiveID", SqlDbType.VarChar).Value = IncentiveID.ToString();
            //}
            //da.SelectCommand.Parameters.Add("@RoleCode", SqlDbType.VarChar).Value = RoleCode.ToString();
            //da.SelectCommand.Parameters.Add("@MSTINCENTVEID", SqlDbType.VarChar).Value = Incids;
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
}