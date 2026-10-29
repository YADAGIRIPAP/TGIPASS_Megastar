using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_GrievanceUserDashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["uid"] != null)
            {
                if (!IsPostBack)
                {
                    BindGrievance();
                }
            }
            else
            {
                Response.Redirect("~/tsHome.aspx");
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void BindGrievance()
    {
        try
        {
            DataSet ds = new DataSet();

            ds = GetGrievanceDashboard(Session["uid"].ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    gvGrvncTotal.DataSource = ds.Tables[0];
                    gvGrvncTotal.DataBind();
                }
                else
                {
                    gvGrvncTotal.DataSource = null;
                    gvGrvncTotal.DataBind();
                }
                if (ds != null && ds.Tables[1].Rows.Count > 0)
                {
                    gvGrvncPending.DataSource = ds.Tables[1];
                    gvGrvncPending.DataBind();
                }
                else
                {
                    gvGrvncPending.DataSource = null;
                    gvGrvncPending.DataBind();
                }
                if (ds != null && ds.Tables[2].Rows.Count > 0)
                {
                    gvGrvncRedressed.DataSource = ds.Tables[2];
                    gvGrvncRedressed.DataBind();
                }
                else
                {
                    gvGrvncRedressed.DataSource = null;
                    gvGrvncRedressed.DataBind();
                }
                if (ds != null && ds.Tables[3].Rows.Count > 0)
                {
                    gvGrvncRejected.DataSource = ds.Tables[3];
                    gvGrvncRejected.DataBind();
                }
                else
                {
                    gvGrvncRejected.DataSource = null;
                    gvGrvncRejected.DataBind();
                }
            }
            else
            {
                lblmsg0.Text = "No Records Found";
                Failure.Visible = true;
                // Response.Redirect("~/User/Grievance/Grievance.aspx");

            }

        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    public DataSet GetGrievanceDashboard(string userid)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString))
        {
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter("USP_GETUSERGRIEVANCES", connection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Transaction = transaction;

                    da.SelectCommand.Parameters.AddWithValue("@CREATEDBY", userid);

                    da.Fill(ds);
                }

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        return ds;
    }
}