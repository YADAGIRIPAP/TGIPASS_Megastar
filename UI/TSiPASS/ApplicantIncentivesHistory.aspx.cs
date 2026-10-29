using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using BusinessLogic;
using System.Data.SqlClient;
using System.Activities.Expressions;

public partial class UI_TSiPASS_ApplicantIncentivesHistory : System.Web.UI.Page
{
    DB.DB con = new DB.DB();

    General Gen = new General();
    comFunctions cmf = new comFunctions();
    comFunctions obcmf = new comFunctions();
    Fetch objFetch = new Fetch();
    string check = "N";

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["uid"] != null)
        {
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            DataSet ds = new DataSet();

            ds = Gen.GetApplicantIncentivesHistory(Session["uid"].ToString());

            try
            {
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    grdDetails.DataSource = ds.Tables[0];
                    grdDetails.DataBind();
                }


                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    trApplyAgainbtn.Visible = true;
                    trApplyAgainNote.Visible = true;
                    tr1.Visible = false;
                }
                else
                {

                    trApplyAgainbtn.Visible = false;
                    trApplyAgainNote.Visible = false;

                    tr1.Visible = true;

                }

            }
            catch (Exception ex)
            {

            }

            SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
            SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
            DataSet oDataSet = new DataSet();
            string gmID = Session["uid"].ToString();
            osqlConnection.Open();
            oSqlDataAdapter = new SqlDataAdapter("USP_GET_APPLICANT_INCENTIVES_HISTORY_testing_nik", osqlConnection);
            oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            oSqlDataAdapter.SelectCommand.Parameters.Add("@UserID", SqlDbType.VarChar).Value = Session["uid"].ToString();
            oDataSet = new DataSet();
            oSqlDataAdapter.Fill(oDataSet);
            int loopCount = 0;
            int rowCount = 0;
            if (oDataSet != null && oDataSet.Tables.Count > 0 && oDataSet.Tables[0].Rows.Count > 0)
            {
                rowCount = oDataSet.Tables[0].Rows.Count;
                string firstRowTest = "";
                String secRowTest = "";

                while (loopCount < rowCount)
                {


                    if (oDataSet.Tables[0].Rows.Count >= 1)
                    {
                        if (oDataSet.Tables[0].Rows[loopCount]["checkFlag"].ToString() == "Y")
                        {
                            if (firstRowTest == "")
                            {
                                firstRowTest = "Y";
                            }
                            trRejection.Visible = true;
                            trRejectioinNotice.Visible = false;
                            lblApplnDate.Text = lblApplnDate.Text + oDataSet.Tables[0].Rows[loopCount]["applicationdate"].ToString();
                            lblPeriod.Text = lblPeriod.Text + oDataSet.Tables[0].Rows[loopCount]["periodDate"].ToString();
                            lblQueryDate.Text = lblQueryDate.Text + oDataSet.Tables[0].Rows[loopCount]["queryDate"].ToString();
                            lblType.Text = lblType.Text + oDataSet.Tables[0].Rows[loopCount]["incentiveType"].ToString();
                        }
                        if (oDataSet.Tables[0].Rows[loopCount]["checkFlag"].ToString() == "NO")
                        {
                            if (secRowTest == "")
                            {
                                secRowTest = "Y";
                            }
                            trRejection.Visible = false;
                            trRejectioinNotice.Visible = false;
                        }

                        if (secRowTest == "Y" && firstRowTest == "Y")
                        {
                            trRejection.Visible = true;
                            trRejectioinNotice.Visible = false;
                        }

                    }
                    else
                    {
                        trRejection.Visible = false;
                        trRejectioinNotice.Visible = false;
                    }

                    loopCount = loopCount + 1;

                }


            }
            else
            {
                mainGrid.Visible = false;
                checkClaim.Visible = true;
            }
            osqlConnection.Close();




        }

    }
    public DataSet GETUNITLATESTDETAILSDATA(string incentiveID, string Applicationstatus)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[SP_UNITLATESTDETAILS_LATEST]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (incentiveID.ToString() != "" || incentiveID.ToString() != null)
            {
                // da.SelectCommand.Parameters.Add("intUserID", SqlDbType.VarChar).Value = userid;
                da.SelectCommand.Parameters.Add("@INCENTIVEID", SqlDbType.VarChar).Value = incentiveID;
                da.SelectCommand.Parameters.Add("@ApplicationStatus", SqlDbType.VarChar).Value = Applicationstatus;

            }

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
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label enterid = (e.Row.FindControl("lblIncentiveID") as Label);
                string enterid_new = enterid.Text;//added newly on 27042023

                Label MstIncentiveId = (e.Row.FindControl("lblMstIncentiveId") as Label);
                Label ApplicationStatus = (e.Row.FindControl("ApplicationStatus") as Label); //added newly on 27042023
                string ApplicationStatus_new = ApplicationStatus.Text;//added newly on 27042023
                Label intStageid = (e.Row.FindControl("lblStageid") as Label);
                int intStageid_inc = Convert.ToInt32(intStageid.Text);
                //   Label lblJdOrGMflag = (e.Row.FindControl("lblJdOrGMflag") as Label);

                Label lblApplicationNo = (e.Row.FindControl("lblApplicationNo") as Label);
                Label lblApplicationFiledDate = (e.Row.FindControl("lblApplicationFiledDate") as Label);
                Label lblanchortaglinkPendingQueriesAtLevel = (e.Row.FindControl("anchortaglinkPendingQueriesAtLevel") as Label);
                HyperLink hplanchortaglinkLatest = (e.Row.FindControl("anchortaglinkLatest") as HyperLink);

                (e.Row.FindControl("anchortaglink") as HyperLink).NavigateUrl = "IncetivesDraft.aspx?EntrpId=" + enterid.Text.Trim();

                // (e.Row.FindControl("anchortaglinkStatus") as HyperLink).NavigateUrl = "ApplicantIncentivesDashBoard.aspx?EntrpId=" + enterid.Text.Trim() + "&Applno=" + lblApplicationNo.Text + "&ApplnDate=" + lblApplicationFiledDate.Text;
                (e.Row.FindControl("anchortaglinkStatus") as HyperLink).NavigateUrl = "IncentivesTracker.aspx?Enterid=" + enterid.Text.Trim();
                (e.Row.FindControl("anchortaglinkAcknowledgement") as HyperLink).NavigateUrl = "InscentiveView_AttachmentsNewIncType.aspx?EntrpId=" + enterid.Text.Trim();

                // (e.Row.FindControl("anchortaglinkPendingQueries") as HyperLink).NavigateUrl = "EnterQueryResponse.aspx?EntrpId=" + enterid.Text.Trim() + "&QueryAt=" + lblanchortaglinkPendingQueriesAtLevel.Text;
                (e.Row.FindControl("anchortaglinkPendingQueries") as HyperLink).NavigateUrl = "EnterQueryResponse.aspx?EntrpId=" + enterid.Text.Trim();

                //   Response.Redirect("EnterQueryResponse.aspx?incentid=" + Request.QueryString[0].ToString());
                hplanchortaglinkLatest.NavigateUrl = "AgreementBondAssignLetter.aspx?EntrpId=" + enterid.Text.Trim();
                Label lblPendingQueries = (e.Row.FindControl("lblPendingQueries") as Label);
                int Pendingqueriescount = 0;
                Pendingqueriescount = Convert.ToInt32(lblPendingQueries.Text.ToString());

                if (Pendingqueriescount > 0)
                {
                    (e.Row.FindControl("anchortaglinkPendingQueries") as HyperLink).Visible = true;
                    //grdDetails.Columns[10].Visible = true;

                    //Label lblRespondtoQuery = (e.Row.FindControl("anchortaglinkPendingQueries") as Label);
                    //lblRespondtoQuery.Visible = true;
                }
                else
                {
                    (e.Row.FindControl("anchortaglinkPendingQueries") as HyperLink).Visible = false;
                    //grdDetails.Columns[10].Visible = false;

                    //Label lblRespondtoQuery = (e.Row.FindControl("anchortaglinkPendingQueries") as Label);
                    //lblRespondtoQuery.Visible = false;
                }
                if (intStageid_inc >= 1)
                {
                    DataSet DSLAPSED = new DataSet();
                    DSLAPSED = GETUNITLATESTDETAILSDATA_LAPSEDCLAIMS(enterid_new, ApplicationStatus_new);
                    if (DSLAPSED != null && DSLAPSED.Tables.Count > 0 && DSLAPSED.Tables[0].Rows.Count > 0)
                    {
                        grdDetails.Columns[12].Visible = false; //ADDED NEW CODE FOR ROLLBACKED CASES ON 24042024

                        check = "Y";
                        hplanchortaglinkLatest.Visible = false;
                    }

                    else
                    {
                        DataSet dsaddlsc = new DataSet();
                        dsaddlsc = GETUNITLATESTDETAILSDATA(enterid_new, ApplicationStatus_new);
                        if (dsaddlsc != null && dsaddlsc.Tables.Count > 0 && dsaddlsc.Tables[0].Rows.Count > 0)
                        {
                            grdDetails.Columns[12].Visible = true; //commented on 13/04/2023 as per JD sir instructions
                                                                   //grdDetails.Columns[12].Visible = false;
                            check = "Y";
                            hplanchortaglinkLatest.Visible = true; //commented on 13/04/2023 as per JD sir instructions
                                                                   //hplanchortaglinkLatest.Visible = false;

                        }
                        else
                        {
                            //grdDetails.Columns[12].Visible = true; commented on 13/04/2023 as per JD sir instructions
                            grdDetails.Columns[12].Visible = true;
                            check = "Y";
                            //hplanchortaglinkLatest.Visible = true; commented on 13/04/2023 as per JD sir instructions
                            hplanchortaglinkLatest.Visible = true;
                        }
                    }
                    //commented on 27042023 as confirmed by maduri madam
                    ////grdDetails.Columns[12].Visible = true; commented on 13/04/2023 as per JD sir instructions
                    //grdDetails.Columns[12].Visible = false;
                    //check = "Y";
                    ////hplanchortaglinkLatest.Visible = true; commented on 13/04/2023 as per JD sir instructions
                    //hplanchortaglinkLatest.Visible = false;


                }
                else if (intStageid_inc == 0)
                {
                    if (check == "Y")
                    {
                        //grdDetails.Columns[12].Visible = true;
                        hplanchortaglinkLatest.Visible = false;
                    }
                    else
                    {
                        grdDetails.Columns[12].Visible = false;
                        hplanchortaglinkLatest.Visible = false;
                    }

                }


            }
        }
        catch (Exception ex)
        {

        }
    }
    public DataSet GETUNITLATESTDETAILSDATA_LAPSEDCLAIMS(string incentiveID, string Applicationstatus)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_UNITLATESTDETAILS_LATEST_LAPSEDDATA", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (incentiveID.ToString() != "" || incentiveID.ToString() != null)
            {
                // da.SelectCommand.Parameters.Add("intUserID", SqlDbType.VarChar).Value = userid;
                da.SelectCommand.Parameters.Add("@INCENTIVEID", SqlDbType.VarChar).Value = incentiveID;
                da.SelectCommand.Parameters.Add("@ApplicationStatus", SqlDbType.VarChar).Value = Applicationstatus;

            }

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

    protected void btnApplyAgain_Click(object sender, EventArgs e)
    {
        Session["applyagain"] = "Y";
        Response.Redirect("~/ui/tsipass/IncentiveFormCFECFO.aspx");
    }

}