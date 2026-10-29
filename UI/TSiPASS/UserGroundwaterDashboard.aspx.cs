using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class UI_TSiPASS_UserGroundwaterDashboard : System.Web.UI.Page
{
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

            Qnreid = Request.QueryString[0].ToString();
            Session["mainQnreid"] = Request.QueryString[0].ToString();
            if (Request.QueryString.Count > 0)
            {
                Session["Applid"] = Request.QueryString[0].ToString();
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


    public DataSet GetEnterpreneourDashboardDetails_Groundwater(string intEntid)
    {
        if (osqlConnection.State != ConnectionState.Open)
            osqlConnection.Open();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GW_GetEnterpreneourDashboardDetails_groundwater", osqlConnection);
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
        ds = GetEnterpreneourDashboardDetails_Groundwater(Qnreid);
        if (ds.Tables[0].Rows.Count > 0)
        {
//Quessionaire,Submitted,Approvals Required as per TS - iPASS,Approvals already Obtained,Approvals -Applied now,Approvals -Yet to be applied, 
//PreScrutinyPending,TotalQueryraised,yettoQueryresponse,TotalQueryresponded,QueryraisedbyMRO,QueryrespondedtoMRO, PreScrutinyCompleted,    
//Pre-Scrutiny-Rejected,QueryraisedbyGroundwater,Queryrespondedtogroundwater,Recommended by Groundwater,NotRecommended by Groundwater,
//Approval-Issued,Approval-Pending,Approval-Rejected,In Complete(Draft),Approvals-Payment Done,Approvals-Payment not required,intQuessionaireid


            lbl_applicationstatus.Text = ds.Tables[0].Rows[0]["Quessionaire"].ToString();
            if (ds.Tables[0].Rows[0]["Submitted"].ToString() == "No")
            {
                lbl_commonappformstatus.Text = "Draft";
            }
            else
            {
                lbl_commonappformstatus.Text = "Submitted";
            }

            lbl_approvalrequriedbytsipass.Text = ds.Tables[0].Rows[0]["Approvals Required as per TS-iPASS"].ToString();
            lbl_approvalsalreadyobtanied.Text = ds.Tables[0].Rows[0]["Approvals already Obtained"].ToString();
            lbl_appappliedapprovalsstatus.Text = ds.Tables[0].Rows[0]["Approvals - Applied now"].ToString();
            lbl_yettobeapplied.Text = ds.Tables[0].Rows[0]["Approvals - Yet to be applied"].ToString();

            lbl_PreScrutinyPending.Text = ds.Tables[0].Rows[0]["PreScrutinyPending"].ToString();
            lbl_totalqueryraised.Text = ds.Tables[0].Rows[0]["TotalQueryraised"].ToString();
            lbl_yettprespond.Text = ds.Tables[0].Rows[0]["yettoQueryresponse"].ToString();
            lbl_totqueryresponded.Text = ds.Tables[0].Rows[0]["TotalQueryresponded"].ToString();
            lbl_QueryRaisedbyMRO.Text = ds.Tables[0].Rows[0]["QueryraisedbyMRO"].ToString();
            lbl_QueryRespondedtoMRO.Text = ds.Tables[0].Rows[0]["QueryrespondedtoMRO"].ToString();

            lbl_forwardtogroundwater.Text = ds.Tables[0].Rows[0]["PreScrutinyCompleted"].ToString();
            lbl_rejectedbymro.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny - Rejected"].ToString();
            lbl_QueryRaisedbyGroundWater.Text = ds.Tables[0].Rows[0]["QueryraisedbyGroundwater"].ToString();
            lbl_QueryRespondedbyGroundWater.Text = ds.Tables[0].Rows[0]["Queryrespondedtogroundwater"].ToString();

            lbl_recommendedbygroundwater.Text = ds.Tables[0].Rows[0]["Recommended by Groundwater"].ToString();
            lblnotrecommenedbygroundwater.Text = ds.Tables[0].Rows[0]["NotRecommended by Groundwater"].ToString();

           
        
            lbl_approvalissued.Text = ds.Tables[0].Rows[0]["Approval - Issued"].ToString();
            lbl_approvalpending.Text = ds.Tables[0].Rows[0]["Approval - Pending"].ToString();
            lblaprRejected.Text = ds.Tables[0].Rows[0]["Approval - Rejected"].ToString();


            lbl_forwardtoTRANSCODEPARTMENT.Text = Convert.ToString(ds.Tables[0].Rows[0]["PreScrutinyCompleted"]);
            lbl_QueryRaisedbyTranscodept.Text = Convert.ToString(ds.Tables[0].Rows[0]["QueryraisedbyTranscoDept"]);
            lbl_QueryRespondedbyTranscoDept.Text = Convert.ToString(ds.Tables[0].Rows[0]["QueryrespondedtoTranscoDept"]);

            lbl_recommendedbyTranscoDept.Text = Convert.ToString(ds.Tables[0].Rows[0]["Recommended by TRANSCO DEPT"]);
            lblnotrecommenedbyTranscoDept.Text = Convert.ToString(ds.Tables[0].Rows[0]["NotRecommended by TRANSCO DEPT"]);
        }

    }




}