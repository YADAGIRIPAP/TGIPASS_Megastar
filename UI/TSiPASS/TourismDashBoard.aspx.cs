using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Web.Configuration;
using System.Threading;
using System.ComponentModel;
using System.Text;


public partial class UI_TSiPASS_TourismDashBoard : System.Web.UI.Page
{
    General Gen = new General();
    string Qnreid;
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("../../Index.aspx");
        }

        if (!IsPostBack)
        {
            //Qnreid=Request.QueryString[0].ToString();
            //Session["mainQnreid"]= Request.QueryString[0].ToString();
            //DataSet dscheck = new DataSet();
            //dscheck = Gen.GetShowRenewalQuestionaries(Qnreid);
            //if (dscheck.Tables[0].Rows.Count > 0)
            //{
            //    Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
            //}
            //else
            //{
            //    Session["Applid"] = "0";
            //}

            //if (Session.Count <= 0)
            //{
            //    Response.Redirect("../../Index.aspx");
            //}
            Qnreid = Request.QueryString[0].ToString();
            Session["mainQnreid"] = Request.QueryString[0].ToString();

            osqlConnection.Open();
            SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
            DataSet dscheck = new DataSet();
            oSqlDataAdapter = new SqlDataAdapter("GetShow_TourismQuestionaries_ques", osqlConnection);
            oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            string text = Session["uid"].ToString();
            oSqlDataAdapter.SelectCommand.Parameters.Add("@Quesstionaireid", SqlDbType.VarChar).Value = Qnreid;
            oSqlDataAdapter.Fill(dscheck);




            if (dscheck.Tables[0].Rows.Count > 0)
            {
                Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
            }
            else
            {
                Session["Applid"] = "0";
            }

            if (!IsPostBack)
            {
                FillDetails();
            }
        }
    }
    public DataSet GetEnterpreneourDashboardDetails_TourismEvent(string intEntid)
    {
        if (osqlConnection.State != ConnectionState.Open)
            osqlConnection.Open();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("sp_GetEnterpreneourDashboardDetails_TourismEvent", osqlConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;



            if (intEntid.Trim() == "" || intEntid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intEntid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intEntid", SqlDbType.VarChar).Value = intEntid.ToString();

            da.Fill(ds);
            return ds;


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (osqlConnection.State != ConnectionState.Closed)
                osqlConnection.Close();
        }
    }
    void FillDetails()
    {
        DataSet ds = new DataSet();
        ds = GetEnterpreneourDashboardDetails_TourismEvent(Qnreid);
        if (ds.Tables[0].Rows.Count > 0)
        {
            
            Label4.Text = ds.Tables[0].Rows[0]["Quessionaire"].ToString(); 
            if (ds.Tables[0].Rows[0]["Submitted"].ToString() == "No")
            {
                Label6.Text = "Draft";
            }
            else
            {
                Label6.Text = "Submitted";
            }
            Label7.Text = ds.Tables[0].Rows[0]["Approvals Required as per TS-iPASS"].ToString();
            Label8.Text = ds.Tables[0].Rows[0]["Approvals already Obtained"].ToString();
            Label10.Text = ds.Tables[0].Rows[0]["Approvals - Applied now"].ToString();
            //  Label9.Text =  ds.Tables[0].Rows[0]["Approvals - Payment Done"].ToString();
            Label12.Text = ds.Tables[0].Rows[0]["Approvals - Payment not required"].ToString();
            Label11.Text = ds.Tables[0].Rows[0]["Approvals - Yet to be applied"].ToString();
            Label3.Text = ds.Tables[0].Rows[0]["Queries Raised"].ToString();
            Label13.Text = ds.Tables[0].Rows[0]["Queries Responded"].ToString();
            Label14.Text = ds.Tables[0].Rows[0]["Queries -Yet to Respond"].ToString();
            lblpreRejected.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny - Rejected"].ToString();
            Label15.Text = ds.Tables[0].Rows[0]["Approval - Payment Required"].ToString();
            Label16.Text = ds.Tables[0].Rows[0]["Approval - Paid for"].ToString();
            Label17.Text = ds.Tables[0].Rows[0]["Approvals - Awaiting Payment"].ToString();
            Label1.Text = ds.Tables[0].Rows[0]["Approval - Issued"].ToString();
            Label2.Text = ds.Tables[0].Rows[0]["Approval - Pending"].ToString();
            lblaprRejected.Text = ds.Tables[0].Rows[0]["Approval - Rejected"].ToString();
            lblPreScrutinyCompleted.Text = ds.Tables[0].Rows[0]["PreScrutinyCompleted"].ToString();
            //lblbPreScrPndg.Text=
        }
        //commented Lavanya
        //BusinessLogic.Fetch objFetch = new BusinessLogic.Fetch();
        //DataSet dsEntpDtls = objFetch.GETEntrepreneurDetailsRenewals(Session["uid"].ToString().Trim());

        //if (dsEntpDtls != null && dsEntpDtls.Tables.Count > 0 && dsEntpDtls.Tables[0].Rows.Count > 0)
        //{
        //    string str = "http://tsocmms.nic.in/TELPCB/industryRegMaster/doLoginWithDetails?indName=" + dsEntpDtls.Tables[0].Rows[0]["IndustryName"].ToString() + "&indDistrict=" + dsEntpDtls.Tables[0].Rows[0]["DistrictName"].ToString() + "&indAddress= " + dsEntpDtls.Tables[0].Rows[0]["StreetName"].ToString() + " " + dsEntpDtls.Tables[0].Rows[0]["DoorNo"].ToString() + "&indPhoneNo=" + dsEntpDtls.Tables[0].Rows[0]["Telephone"].ToString() + "&industryEmail=" + dsEntpDtls.Tables[0].Rows[0]["Emailid"].ToString() + "&caf_unique_no=" + Session["uid"].ToString().Trim() + "&pinCode=" + dsEntpDtls.Tables[0].Rows[0]["Pincode"].ToString() + "&firstName=" + dsEntpDtls.Tables[0].Rows[0]["PromoterName"].ToString() + "&lastName=" + dsEntpDtls.Tables[0].Rows[0]["PromoterName"].ToString() + " &occName=" + dsEntpDtls.Tables[0].Rows[0]["PromoterName"].ToString() + " &mobile=" + dsEntpDtls.Tables[0].Rows[0]["CellNo"].ToString() + "&email=" + dsEntpDtls.Tables[0].Rows[0]["Emailid"].ToString() + "&custId=" + dsEntpDtls.Tables[0].Rows[0]["UID"].ToString() + "&village=" + dsEntpDtls.Tables[0].Rows[0]["VillageName"].ToString();

        //    hplPCB.Visible = false;
        //    TSSPDCL.Visible = false;

        //    DataTable dtDept = new DataTable();
        //    dtDept = objFetch.IsTSSPDCLTSNPDCL(Convert.ToInt32(dsEntpDtls.Tables[0].Rows[0]["intCFEEnterpid"].ToString()));
        //    if (dtDept.Rows.Count > 0)
        //    {
        //        if (dtDept.Rows[0]["PCB"].ToString().Trim() == "Y")
        //        {
        //            if (dtDept.Rows[0]["PCB"].ToString().ToUpper() == "Y") hplPCB.Visible = true;
        //        }
        //        else
        //        {
        //            hplPCB.Visible = false;
        //        }
        //        if (dtDept.Rows[0]["TSSPDCL"].ToString().ToUpper() == "Y")
        //        {
        //            if (dtDept.Rows[0]["TSSPDCL"].ToString().ToUpper() == "Y") TSSPDCL.Visible = true;
        //        }
        //        else
        //        {
        //            TSSPDCL.Visible = false;
        //        }
        //        if (dtDept.Rows[0]["TSNPDCL"].ToString().ToUpper() == "Y")
        //        {
        //            if (dtDept.Rows[0]["TSNPDCL"].ToString().ToUpper() == "Y") TSNPDCL.Visible = true;
        //        }
        //        else
        //        {
        //            TSNPDCL.Visible = false;
        //        }
        //        hplPCB.NavigateUrl = str;
        //        //Response.Redirect(str, false);
        //    }
        //}
        //commented Lavanya end

        // DataSet ds = Gen.YearwiseDashboardforAdmin("2016");
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    lbl0.Text = ds.Tables[0].Rows[0]["cnt"].ToString();
        //    lbl1.Text = ds.Tables[1].Rows[0]["cnt"].ToString();
        //    lbl2.Text = ds.Tables[2].Rows[0]["cnt"].ToString();
        //    lbl3.Text = ds.Tables[3].Rows[0]["cnt"].ToString();
        //    lbl4.Text = ds.Tables[4].Rows[0]["cnt"].ToString();
        //    lbl5.Text = ds.Tables[5].Rows[0]["cnt"].ToString();
        //    lbl6.Text = ds.Tables[6].Rows[0]["cnt"].ToString();
        //    lbl7.Text = ds.Tables[7].Rows[0]["cnt"].ToString();
        //    lbl8.Text = ds.Tables[8].Rows[0]["cnt"].ToString();
        //    lbl9.Text = ds.Tables[9].Rows[0]["cnt"].ToString();
        //    lbl10.Text = ds.Tables[10].Rows[0]["cnt"].ToString();
        //    lbl11.Text = ds.Tables[11].Rows[0]["cnt"].ToString();
        //    lbl12.Text = ds.Tables[12].Rows[0]["cnt"].ToString();
        //    lbl13.Text = ds.Tables[13].Rows[0]["cnt"].ToString();   
        //}
    }
}