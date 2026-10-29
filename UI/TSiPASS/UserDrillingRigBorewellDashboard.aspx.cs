using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class UI_TSiPASS_UserDrillingRigBorewellDashboard : System.Web.UI.Page
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

    public DataSet GetEnterpreneourDashboardDetails_DrillingRigs(string intEntid)
    {
        if (osqlConnection.State != ConnectionState.Open)
            osqlConnection.Open();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("Rigs_GetEnterpreneourDashboardDetails_DrillingRigs", osqlConnection);
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
        ds = GetEnterpreneourDashboardDetails_DrillingRigs(Qnreid);
        if (ds.Tables[0].Rows.Count > 0)
        {
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
            lbl_approvalissued.Text = ds.Tables[0].Rows[0]["Approval - Issued"].ToString();
            lbl_approvalpending.Text = ds.Tables[0].Rows[0]["Approval - Pending"].ToString();
            lblaprRejected.Text = ds.Tables[0].Rows[0]["Approval - Rejected"].ToString();

            lbl_presrunitypending.Text = ds.Tables[0].Rows[0]["PreScrutinyPending"].ToString();
            lbl_totalqueryraised.Text = ds.Tables[0].Rows[0]["totalqueryraised"].ToString();
            lbl_totqueryresponded.Text = ds.Tables[0].Rows[0]["totqueryresponded"].ToString();
            lbl_yettprespond.Text = ds.Tables[0].Rows[0]["yettprespond"].ToString();
        }

    }




}