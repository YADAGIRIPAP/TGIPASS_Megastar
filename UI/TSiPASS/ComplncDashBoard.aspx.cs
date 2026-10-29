using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_ComplncDashBoard : System.Web.UI.Page
{
    General gen = new General();
    General Gen = new General();
    int Sno = 0;
    DB.DB con = new DB.DB();
    DataSet ds;
    


    DataSet dslist;
    string created_by;
    int userid;
    protected void Page_Load(object sender, EventArgs e)
    {
        
                         
        created_by = Session["uid"].ToString();
        ds = ApplicationWiseDetailedTrakerREN(created_by.ToString());
        

        if (ds.Tables[0].Rows.Count > 0)
        {
            //labUidNumber.Text = ds.Tables[0].Rows[0]["UID Number"].ToString();
            labNameandAddress.Text = ds.Tables[0].Rows[0]["INDUSNAME"].ToString();
            labLineofActivity.Text = ds.Tables[0].Rows[0]["LineofActivity_Name"].ToString();
            labTotalInvestment.Text = ds.Tables[0].Rows[0]["Tot_PrjCost"].ToString();
           
            labNameandAddress0.Text = ds.Tables[0].Rows[0]["ADDRES"].ToString();
            lblindustryscale.Text = ds.Tables[0].Rows[0]["Ent_is"].ToString();
            lblriskcategory.Text = ds.Tables[0].Rows[0]["Pol_Category"].ToString();
        }

        getNewActiveLicensedetails();
        getRenActvLicensedetails();
        getInspectiondetails();

    }



    public DataSet ApplicationWiseDetailedTrakerREN(string created_by)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_CMPLNC_DETAILS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (created_by.Trim() == "" || created_by.Trim() == null)
                da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = created_by.ToString();

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

    

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Label enterid = (e.Row.FindControl("lblRENENTERPID") as Label);
            Label lblApplApprRejection = (e.Row.FindControl("lblApplApprRejection") as Label);
            HyperLink lblanchortaglinkPendingQueriesAtLevel = (e.Row.FindControl("hplQueries") as HyperLink);
            HyperLink anchortaglinkStatus = (e.Row.FindControl("anchortaglinkStatus") as HyperLink);
            HyperLink anchortaglink = (e.Row.FindControl("anchortaglink") as HyperLink);
            Label lblRENINTQNREID = (e.Row.FindControl("lblRENINTQNREID") as Label);

            lblanchortaglinkPendingQueriesAtLevel.NavigateUrl = "frmDashboardRedirectRenewal.aspx?id=" + lblRENINTQNREID.Text.Trim() +
                "&status=" + "Queries -Yet to Respond" + "&check=" + "A";

            anchortaglink.NavigateUrl = "RenewalDashboard.aspx?Qnreid=" + lblRENINTQNREID.Text.Trim();


            HyperLink lblanchortaghplRejectionAtLevel = (e.Row.FindControl("hplRejection") as HyperLink);
            if (lblanchortaghplRejectionAtLevel.Text != "0")

                lblanchortaghplRejectionAtLevel.NavigateUrl = "frmDashboardRedirectRenewal.aspx?id=" + lblRENINTQNREID.Text.Trim() +
                    "&status=" + "Pre-Scrutiny - Rejected" + "&check=" + "A";
            if (lblApplApprRejection.Text != "0")
            {
                lblanchortaghplRejectionAtLevel.NavigateUrl = "frmDashboardRedirectRenewal.aspx?id=" + lblRENINTQNREID.Text.Trim() +
                "&status=" + "Approval - Rejected" + "&check=" + "A";
                lblanchortaghplRejectionAtLevel.Text = lblApplApprRejection.Text;
            }

            Label lblApprovalStatus = (e.Row.FindControl("lblApprovalStatus") as Label);
            if (lblApprovalStatus.Text == "3")
            {

                string intqnreid = lblRENINTQNREID.Text.ToString();
                anchortaglinkStatus.NavigateUrl = "RptApplicationWiseDetailedTrakerREN.aspx?intqnreid=" + intqnreid.ToString();
            }
            else if (lblApprovalStatus.Text == "2")
            {
                //Label lblRENINTQNREID = (e.Row.FindControl("lblRENINTQNREID") as Label);
                string intqnreid = lblRENINTQNREID.Text.ToString();
                anchortaglinkStatus.NavigateUrl = "frmRenewalService.aspx?status=B" + "&intqnreid=" + intqnreid.ToString();
                anchortaglinkStatus.Text = "Incomplete Application";
                
            }

        }

    }

    public void getNewActiveLicensedetails()
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
            DataSet oDataSet = new DataSet();
            oSqlDataAdapter = new SqlDataAdapter("USP_GET_RENEWAL_DASHBOARD_HISTORY", con.GetConnection);
            oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Session["uid"] != null)
            {
                string text = Session["uid"].ToString();
                oSqlDataAdapter.SelectCommand.Parameters.Add("@UserID", SqlDbType.VarChar).Value = Session["uid"].ToString();
                oSqlDataAdapter.Fill(oDataSet);
                if (oDataSet.Tables.Count >= 1)
                {
                    if (oDataSet.Tables[0].Rows.Count == 0)
                    {
                        
                        Response.Redirect("frmRenewalService.aspx?status=B", false);
                    }
                    else
                    {
                        grdDetails.DataSource = oDataSet.Tables[0];
                        grdDetails.DataBind();
                    }
                }

                else if (oDataSet.Tables.Count == 0)
                {
                    
                    Response.Redirect("frmRenewalService.aspx?status=B", false);
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
            con.CloseConnection();
        }
    }

    public void getRenActvLicensedetails()
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
            DataSet oDataSet = new DataSet();

            // Specify the stored procedure
            oSqlDataAdapter = new SqlDataAdapter("SP_COMPLIANCERENEWALDASHBOARD", con.GetConnection);
            oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (Session["uid"] != null)
            {
                string text = Session["uid"].ToString();

                // For testing purposes, you are using a hardcoded user ID.
                // You should replace this with the actual user ID from the session.
                oSqlDataAdapter.SelectCommand.Parameters.Add("@USERID", SqlDbType.VarChar).Value = Session["uid"].ToString();

                // Fill the DataSet with the results from the stored procedure
                oSqlDataAdapter.Fill(oDataSet);

                // Check if any data is returned
                if (oDataSet.Tables.Count > 0 && oDataSet.Tables[0].Rows.Count > 0)
                {
                    // Bind the DataSet to the GridView
                    ActvlRenGridView.DataSource = oDataSet.Tables[0];
                    ActvlRenGridView.DataBind();
                }
                else
                {
                    // If no records, redirect to another page
                    Response.Redirect("frmRenewalService.aspx?status=B", false);
                }
            }
            else
            {
                // If no session is found, redirect to home dashboard
                Response.Redirect("HomeDashboard.aspx");
            }
        }
        catch (Exception ex)
        {
            // Handle exception (optional logging)
            Response.Redirect("HomeDashboard.aspx");
        }
        finally
        {
            // Close the database connection
            con.CloseConnection();
        }
    }


    public void getInspectiondetails()
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
            DataSet oDataSet = new DataSet();

            // Specify the stored procedure
            oSqlDataAdapter = new SqlDataAdapter("SP_COMPLIANCEINSPECTIONDASHBOARD", con.GetConnection);
            oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (Session["uid"] != null)
            {
                string text = Session["uid"].ToString();

                // For testing purposes, you are using a hardcoded user ID.
                // You should replace this with the actual user ID from the session.
                oSqlDataAdapter.SelectCommand.Parameters.Add("@USERID", SqlDbType.VarChar).Value = Session["uid"].ToString();

                // Fill the DataSet with the results from the stored procedure
                oSqlDataAdapter.Fill(oDataSet);

                // Check if any data is returned
                if (oDataSet.Tables.Count > 0 && oDataSet.Tables[0].Rows.Count > 0)
                {
                    // Bind the DataSet to the GridView
                    InspCmplncGridView.DataSource = oDataSet.Tables[0];
                    InspCmplncGridView.DataBind();
                }
                else
                {
                    // If no records, redirect to another page
                    Response.Redirect("frmRenewalService.aspx?status=B", false);
                }
            }
            else
            {
                // If no session is found, redirect to home dashboard
                Response.Redirect("HomeDashboard.aspx");
            }
        }
        catch (Exception ex)
        {
            // Handle exception (optional logging)
            Response.Redirect("HomeDashboard.aspx");
        }
        finally
        {
            // Close the database connection
            con.CloseConnection();
        }
    }



    int totalRows = 0;
    int complianceCount = 0;
    int nonComplianceCount = 0;
    protected void ActvlRenGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Find the Compliance Status label in the row
            Label lblComplianceStatus = (Label)e.Row.FindControl("lblComplianceStatus");

            if (lblComplianceStatus != null)
            {
                string complianceValue = lblComplianceStatus.Text.Trim();

                // Change numeric values to corresponding text
                if (complianceValue == "13")
                {
                    lblComplianceStatus.Text = "Compliant";
                    lblComplianceStatus.ForeColor = System.Drawing.Color.Green;
                    complianceCount++; // Increment Compliance count
                }
                else if (complianceValue == "16")
                {
                    lblComplianceStatus.Text = "NON-Compliant";
                    lblComplianceStatus.ForeColor = System.Drawing.Color.Red;
                    nonComplianceCount++; // Increment Non-Compliance count
                }
            }

            // Track total rows
            totalRows++;
        }
    }

    // Event triggered after GridView data binding is complete
    protected void ActvlRenGridView_DataBound(object sender, EventArgs e)
    {
        UpdateComplianceRating();
    }

    // Method to calculate compliance percentage and update the label
    private void UpdateComplianceRating()
    {
        if (totalRows > 0) // Avoid division by zero
        {
            // Calculate Compliance Score
            double compliancePercentage = ((double)complianceCount / totalRows) * 100;
            string organizationRating = GetComplianceRating(compliancePercentage);

            // Update label with Compliance Rating
            lblCmplncRtg.Text = organizationRating+" - "+compliancePercentage+"%";
        }
        else
        {
            lblCmplncRtg.Text = "No records found.";
        }
    }

    // Function to determine Compliance Rating based on score
    private string GetComplianceRating(double complianceScore)
    {
        if (complianceScore >= 95)
            return "AAA";
        else if (complianceScore >= 90)
            return "AA";
        else if (complianceScore >= 80)
            return "B+";
        else
            return "B";
    }
}