using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class UI_TSiPASS_frmUserFilmShootingDashboard : System.Web.UI.Page
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

            osqlConnection.Open();
            SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
            DataSet dscheck = new DataSet();
            oSqlDataAdapter = new SqlDataAdapter("FS_GetShow_FilmShootingQuestionaries_ques", osqlConnection);
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


    public DataSet GetEnterpreneourDashboardDetails_Advertisment(string intEntid)
    {
        if (osqlConnection.State != ConnectionState.Open)
            osqlConnection.Open();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("FS_GetEnterpreneourDashboardDetails_Filmshooting", osqlConnection);
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
        ds = GetEnterpreneourDashboardDetails_Advertisment(Qnreid);
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
        }

    }







}