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
public partial class UI_TSiPASS_Batuserdashboard : System.Web.UI.Page
{
    General Gen = new General();
    string batdealerid;
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    DB.DB con = new DB.DB();
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
            batdealerid = Request.QueryString[0].ToString();
            Session["batdealerid"] = Request.QueryString[0].ToString();

            osqlConnection.Open();
            SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
            DataSet dscheck = new DataSet();
            oSqlDataAdapter = new SqlDataAdapter("GetShowRenewalQuestionaries_ques", osqlConnection);
            oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            string text = Session["uid"].ToString();
            oSqlDataAdapter.SelectCommand.Parameters.Add("@Quesstionaireid", SqlDbType.VarChar).Value = batdealerid;
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
    void FillDetails()
    {
        DataSet ds = new DataSet();
        ds = GetEnterpreneourDashboardDetailsRenewal(batdealerid);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //labUidNumber.Text = ds.Tables[0].Rows[0]["UID Number"].ToString();
            //labNameandAddress.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            //labLineofActivity.Text = ds.Tables[0].Rows[0]["LineofActivity"].ToString();
            //labTotalInvestment.Text = ds.Tables[0].Rows[0]["Total Investment"].ToString();
            //labCategoryofIndustry.Text = ds.Tables[0].Rows[0]["Category of Industry"].ToString();
            //labDOA.Text = ds.Tables[0].Rows[0]["Date of Application"].ToString();
            //labNameandAddress0.Text = ds.Tables[0].Rows[0]["PropAddress"].ToString();
            Label4.Text = ds.Tables[0].Rows[0]["Applicationstatus"].ToString();
            //  Label5.Text = ds.Tables[0].Rows[0]["In Complete (Draft)"].ToString();
            if (ds.Tables[0].Rows[0]["Submitted"].ToString() == "No")
            {

                Label6.Text = "Draft";
            }
            else
            {
                Label6.Text = "Submitted";
            }

            //Label7.Text = ds.Tables[0].Rows[0]["Approvals Required as per TS-iPASS"].ToString();
            //Label8.Text = ds.Tables[0].Rows[0]["Approvals already Obtained"].ToString();
            Label10.Text = ds.Tables[0].Rows[0]["Approvals - Applied now"].ToString();
            //  Label9.Text =  ds.Tables[0].Rows[0]["Approvals - Payment Done"].ToString();
            Label11.Text = ds.Tables[0].Rows[0]["Approvals - Yet to be applied"].ToString();
            Label3.Text = ds.Tables[0].Rows[0]["Queries Raised"].ToString();
            Label13.Text = ds.Tables[0].Rows[0]["Queries Responded"].ToString();
            Label14.Text = ds.Tables[0].Rows[0]["Queries -Yet to Respond"].ToString();
            lblpreRejected.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny - Rejected"].ToString();
            Label1.Text = ds.Tables[0].Rows[0]["Approval - Issued"].ToString();
            Label2.Text = ds.Tables[0].Rows[0]["Approval - Pending"].ToString();
            lblaprRejected.Text = ds.Tables[0].Rows[0]["Approval - Rejected"].ToString();
            lblPreScrutinyCompleted.Text = ds.Tables[0].Rows[0]["PreScrutinyCompleted"].ToString();
            //lblbPreScrPndg.Text=
        }

        BusinessLogic.Fetch objFetch = new BusinessLogic.Fetch();
        DataSet dsEntpDtls = objFetch.GETEntrepreneurDetailsRenewals(Session["uid"].ToString().Trim());

      

    }

    public DataSet GetEnterpreneourDashboardDetailsRenewal(string batdealerid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[sp_GetEnterpreneourDashboardDetails_Batdealer]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;



            if (batdealerid.Trim() == "" || batdealerid.Trim() == null)
                da.SelectCommand.Parameters.Add("@batdealerid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@batdealerid", SqlDbType.VarChar).Value = batdealerid.ToString();

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