using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class UI_TSiPASS_SWGDashboard : System.Web.UI.Page
{
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] != null)
        {
            if (!IsPostBack)
            {
                getdetails();
            }

        }
        else
            Response.Redirect("~/IpassLogin.aspx");


    }

    public void getdetails()
    {
        try
        {
            osqlConnection.Open();
            SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
            DataSet oDataSet = new DataSet();
            oSqlDataAdapter = new SqlDataAdapter("USP_GET_SWG_DASHB0ARD", osqlConnection);
            oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Session["uid"] != null)
            {
                string text = Session["uid"].ToString();
                oSqlDataAdapter.SelectCommand.Parameters.Add("@CREATEDBY", SqlDbType.VarChar).Value = Session["uid"].ToString();
                oSqlDataAdapter.Fill(oDataSet);
                if (oDataSet.Tables.Count >= 1)
                {
                    if (oDataSet.Tables[0].Rows.Count == 0)
                    {
                        btnApplyAgain.Visible = false;
                        Response.Redirect("SewerageConnection.aspx", false);
                    }
                    else
                    {
                        grdDetails.DataSource = oDataSet.Tables[0];
                        grdDetails.DataBind();
                    }
                }

                else if (oDataSet.Tables.Count == 0)
                {
                    btnApplyAgain.Visible = false;
                    Response.Redirect("SewerageConnection.aspx", false);
                }
            }
            else
            {
                Response.Redirect("HomeDashboard.aspx");
            }

        }
        catch (Exception ex)
        {
            Response.Redirect("HomeDashboard.aspx");
        }
        finally
        {
            osqlConnection.Close();
        }
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            Label lblSWGID = (e.Row.FindControl("lblSWGID") as Label);
            HyperLink hplStatus = (e.Row.FindControl("hplStatus") as HyperLink);

            Label lblAppstatus = (e.Row.FindControl("lblAppstatus") as Label);
            if (lblAppstatus.Text == "3")
            {
                hplStatus.Text = "Tracker";
                hplStatus.NavigateUrl = "SWGApplicationTracker.aspx?intqnreid=" + lblSWGID.Text;
            }
            else if (lblAppstatus.Text == "2")
            {
                hplStatus.Text = "Incomplete Application";
                hplStatus.NavigateUrl = "SewerageConnection.aspx?intqnreid=" + lblSWGID.Text;
                btnApplyAgain.Visible = false;
            }
        }
    }
    protected void btnApplyAgain_Click(object sender, EventArgs e)
    {
        Response.Redirect("SewerageConnection.aspx");
    }
}