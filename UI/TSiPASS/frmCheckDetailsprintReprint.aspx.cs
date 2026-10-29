using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UI_TSiPASS_frmCheckDetailsprintReprint : System.Web.UI.Page
{
    private SqlConnection connSqlHelper = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    DB.DB con = new DB.DB();

    General gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlReleaseProceedingNo.Items.Insert(0, "--Select--");
            ddlReleaseProceedingNo.SelectedItem.Text = "--Select--";
            string DIPCFlag = "", UCSTATUS = "";
            if (Request.QueryString["workingstatus"] != null && Request.QueryString["workingstatus"].ToString() != "")
            {
                HDNWORKINGSTATUS.Value = Request.QueryString["workingstatus"].ToString();

            }
            else
            {
                HDNWORKINGSTATUS.Value = "%";
            }
            if (Request.QueryString["DIPCFlag"] != null && Request.QueryString["DIPCFlag"].ToString() != "")
            {
                DIPCFlag = Request.QueryString["DIPCFlag"].ToString();
                DIPCFlag = "Y";
            }
            //else if (Request.QueryString["Stg"] != null && Request.QueryString["Stg"].ToString() != "")
            //{
            //    DIPCFlag = Request.QueryString["Stg"].ToString();
            //    DIPCFlag = "Y";
            //}
            else
            {
                DIPCFlag = null;
            }

            if (Request.QueryString["Status"] != null && Request.QueryString["Status"].ToString() != "")
            {
                UCSTATUS = Request.QueryString["Status"].ToString();
            }
            if (UCSTATUS == "NUC")
            {
                tdworkstatus.Visible = false;
                ddlworkingstatus.Visible = false;
            }
            DataSet ds2 = new DataSet();

            ds2 =GetReleaseProceedingNosListRePrint(Session["DistrictID"].ToString().Trim(), DIPCFlag, UCSTATUS);

            if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
            {
                ddlReleaseProceedingNo.DataSource = ds2.Tables[0];
                ddlReleaseProceedingNo.DataValueField = "ReleaseProceedingNo";
                ddlReleaseProceedingNo.DataTextField = "ReleaseProceedingNo";
                ddlReleaseProceedingNo.DataBind();

                AddSelect(ddlReleaseProceedingNo);

            }
            ddlReleaseProceedingNo_SelectedIndexChanged(sender, e);

        }
    }
    public void AddSelect(DropDownList ddl)
    {
        try
        {
            ListItem li = new ListItem();
            li.Text = "--All--";
            li.Value = "0";
            ddl.Items.Insert(0, li);
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
            //success.Visible = false;
        }
    }
    // SC CAtegory
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string DIPCFlag = "", UCSTATUS = "";
            if (Request.QueryString["DIPCFlag"] != null && Request.QueryString["DIPCFlag"].ToString() != "")
            {
                DIPCFlag = Request.QueryString["DIPCFlag"].ToString();
                DIPCFlag = "Y";
            }
            else
            {
                DIPCFlag = null;
            }

            if (Request.QueryString["Status"] != null && Request.QueryString["Status"].ToString() != "")
            {
                UCSTATUS = Request.QueryString["Status"].ToString();
            }

            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            string lblMstIncentiveId = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("Label3")).Text;
            //string Sactionnumber = Request.QueryString[0].ToString();
            // Response.Redirect("Finalsactionamount.aspx?Sactionnumber=" + Sactionnumber + "&MstIncentiveId=" + lblMstIncentiveId);
            string lblCategory1 = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("lblCategory1")).Text;

            string lblsubInctypeid = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("lblInctypeId")).Text;
            string txtsvcdate = System.DateTime.Now.ToString("dd/MM/yyyy");

            //Response.Redirect("CheckListPrint.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&Date=" + txtsvcdate.Text + "&SubIncTypeId=" + lblsubInctypeid);

            Response.Redirect("CheckListPrintRePrint.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&Date=" + txtsvcdate + "&SubIncTypeId=" + lblsubInctypeid + "&RlsProceedNo=" + ddlReleaseProceedingNo.Text
                + "&FromDate=" + ViewState["FromDate"].ToString() + "&ToDate=" + ViewState["ToDate"].ToString() + "&DIPCFlag=" + DIPCFlag + "&UCSTATUS=" + UCSTATUS + "&WORKINGSTATUS=" + HDNWORKINGSTATUS.Value
                );


        }
        catch (Exception ex)
        {

        }
    }

    protected void grdDetailsPavallavaddiSC_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label enterid = (e.Row.FindControl("Label3") as Label);
            Button Button1 = (e.Row.FindControl("Button1") as Button);

            if (enterid.Text == "")
            {
                Button1.Visible = false;
            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        lblmsg0.Text = "";
        if (ddlReleaseProceedingNo.Text.Trim() == "--Select--")
        {
            lblmsg0.Text = "Please Select Release Proceeding Number";
            lblmsg0.Visible = true;
            Failure.Visible = true;
            return;
        }
        else
        {
            lblmsg0.Text = "";
        }

        if (txtFromDate.Text.Trim() == null && txtFromDate.Text.Trim() == "")
        {
            lblmsg0.Text = "Please Select From Date";
        }
        if (txtFromDate.Text.Trim() == null && txtFromDate.Text.Trim() == "")
        {
            lblmsg0.Text += "Please Select To Date";
        }
        if (lblmsg0.Text.Trim() != null && lblmsg0.Text.Trim() != "")
        {
            lblmsg0.Visible = true;
            Failure.Visible = true;
            return;

        }
        else
        {
            lblmsg0.Visible = false;
            Failure.Visible = false;
        }

        string DIPCFlag = "", UCSTATUS = "";
        if (Request.QueryString["DIPCFlag"] != null && Request.QueryString["DIPCFlag"].ToString() != "")
        {
            DIPCFlag = Request.QueryString["DIPCFlag"].ToString();
            DIPCFlag = "Y";
        }
        else
        {
            DIPCFlag = null;
        }

        if (Request.QueryString["Status"] != null && Request.QueryString["Status"].ToString() != "")
        {
            UCSTATUS = Request.QueryString["Status"].ToString();
        }

        string ProposedDate = "";

        string FromDate = "";
        String ToDate = "";

        ViewState["FromDate"] = "";
        ViewState["ToDate"] = "";
        if (txtFromDate.Text.Trim().Contains('/'))
        {
            string[] datett = txtFromDate.Text.Trim().Split('/');
            FromDate = datett[2] + "/" + datett[1] + "/" + datett[0];

        }
        else if (txtFromDate.Text.Trim().Contains('-'))
        {
            string[] datett1 = txtFromDate.Text.Trim().Split('-');
            FromDate = datett1[2] + "/" + datett1[1] + "/" + datett1[0];
        }
        ViewState["FromDate"] = FromDate;

        if (txtToDate.Text.Trim().Contains('/'))
        {
            string[] datett2 = txtToDate.Text.Trim().Split('/');
            ToDate = datett2[2] + "/" + datett2[1] + "/" + datett2[0];
        }
        else if (txtToDate.Text.Trim().Contains('-'))
        {
            string[] datett3 = txtToDate.Text.Trim().Split('-');
            ToDate = datett3[2] + "/" + datett3[1] + "/" + datett3[0];
        }
        ViewState["ToDate"] = ToDate;

        ProposedDate = ddlReleaseProceedingNo.SelectedItem.Text.Trim();

        DataSet ds = new DataSet();

        ds = getincentiveslclistWorkigngListcheckReprint(ProposedDate, DIPCFlag, FromDate, ToDate, Session["DistrictID"].ToString().Trim(), UCSTATUS, HDNWORKINGSTATUS.Value);

        int i = 0;
        int j = 0;
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            grdDetailsPavallavaddiSC.DataSource = ds.Tables[0];
            grdDetailsPavallavaddiSC.DataBind();

            //txtFromDate.Enabled = false;
            //txtToDate.Enabled = false;
            //ddlReleaseProceedingNo.Enabled = false;
            //ddlworkingstatus.Enabled = false;
            Failure.Visible = false;

        }
        else
        {
            lblmsg0.Text = "";
            lblmsg0.Text = "No Records Found";
            lblmsg0.Visible = true;
            Failure.Visible = true;
        }
    }

    protected void ddlReleaseProceedingNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlReleaseProceedingNo.SelectedItem.Text.ToUpper() != "--SELECT--")
        {
            trdates.Visible = true;
            txtFromDate.Text = "01-08-2017";//System.DateTime.Now.ToString("dd/MM/yyyy");
            txtToDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            lblmsg0.Visible = false;
            Failure.Visible = false;
            Button2_Click(sender, e);
        }
        else
        {
            trdates.Visible = false;
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UI/TSIPASS/frmCheckDetailsprintReprint.aspx");
    }

    public DataSet GetReleaseProceedingNosListRePrint(string distid, string DIPCFlag, string UCSTATUS)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_RELEASE_PROCEEDING_NOS_LIST_REPRINT", con.GetConnection);

            if (distid != null && distid != "")
            {
                da.SelectCommand.Parameters.Add("@distid", SqlDbType.VarChar).Value = distid;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@distid", SqlDbType.VarChar).Value = null;
            }

            if (DIPCFlag != null && DIPCFlag != "")
            {
                da.SelectCommand.Parameters.Add("@DIPCflag", SqlDbType.VarChar).Value = DIPCFlag;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@DIPCflag", SqlDbType.VarChar).Value = null;
            }
            if (UCSTATUS != null && UCSTATUS != "")
            {
                da.SelectCommand.Parameters.Add("@UCSTATUS", SqlDbType.VarChar).Value = UCSTATUS;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@UCSTATUS", SqlDbType.VarChar).Value = null;
            }
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.CommandTimeout = 3600;
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

    public DataSet getincentiveslclistWorkigngListcheckReprint(string date, string DIPCFlag, string fromdate, string todate, string distid, string UCSTATUS, string WORKINGSTATUS)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_LIST_INCENTIVEWISE_WORKING_ABSTRACT_PRINTEDDATE_Working_REPRINT", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@date", SqlDbType.VarChar).Value = date;
            if (DIPCFlag != null && DIPCFlag != "")
            {
                da.SelectCommand.Parameters.Add("@DIPCflag", SqlDbType.VarChar).Value = DIPCFlag;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@DIPCflag", SqlDbType.VarChar).Value = null;
            }

            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = fromdate;
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = todate;

            if (distid != null && distid != "")
            {
                da.SelectCommand.Parameters.Add("@distid", SqlDbType.VarChar).Value = distid;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@distid", SqlDbType.VarChar).Value = null;
            }
            if (UCSTATUS != null && UCSTATUS != "")
            {
                da.SelectCommand.Parameters.Add("@UCSTATUS", SqlDbType.VarChar).Value = UCSTATUS;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@UCSTATUS", SqlDbType.VarChar).Value = null;
            }

            da.SelectCommand.Parameters.Add("@WORKINGSTATUS", SqlDbType.VarChar).Value = WORKINGSTATUS;
            da.SelectCommand.CommandTimeout = 3600;
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
    //public DataSet GetReleaseProceedingNosListRePrint(string distid)
    //{
    //    con.OpenConnection();
    //    SqlDataAdapter da;
    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        da = new SqlDataAdapter("USP_GET_RELEASE_PROCEEDING_NOS_LIST_REPRINT", con.GetConnection);
    //        da.SelectCommand.Parameters.Add("@distid", SqlDbType.VarChar).Value = distid;

    //        da.SelectCommand.CommandType = CommandType.StoredProcedure;

    //        da.Fill(ds);
    //        return ds;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        con.CloseConnection();
    //    }
    //}

    //public DataSet getincentiveslclistWorkigngListcheckReprint(string date, string DIPCFlag, string fromdate, string todate, string distid)
    //{
    //    con.OpenConnection();
    //    SqlDataAdapter da;
    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        da = new SqlDataAdapter("USP_GET_LIST_INCENTIVEWISE_WORKING_ABSTRACT_PRINTEDDATE_Working_REPRINT", con.GetConnection);
    //        da.SelectCommand.CommandType = CommandType.StoredProcedure;
    //        da.SelectCommand.Parameters.Add("@date", SqlDbType.VarChar).Value = date;
    //        da.SelectCommand.Parameters.Add("@DIPCFlag", SqlDbType.VarChar).Value = DIPCFlag;

    //        da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = fromdate;
    //        da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = todate;

    //        da.SelectCommand.Parameters.Add("@distid", SqlDbType.VarChar).Value = distid;

    //        da.Fill(ds);
    //        return ds;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        con.CloseConnection();
    //    }
    //}
}