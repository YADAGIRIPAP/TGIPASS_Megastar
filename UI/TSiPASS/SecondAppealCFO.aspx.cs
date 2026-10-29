using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;


public partial class UI_TSiPASS_SecondAppealCFO : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BTNGETDATA_Click(object sender, EventArgs e)
    {
        DataSet DS = new DataSet();
        DS = GETCREATEDBY_UID(TXTUIDNUMBER.Text.Trim().ToString());
        if (DS != null && DS.Tables.Count > 0)
        {
            HDNCREATEDBY.Value = DS.Tables[0].Rows[0]["Created_by"].ToString();
        }
        DataSet DSAPPROVALS = new DataSet();
        DSAPPROVALS = GETREJECTEDAPPROVALS_CREATEDBY(HDNCREATEDBY.Value);
        if (DSAPPROVALS != null && DSAPPROVALS.Tables.Count > 0)
        {
            DDLREJECTEDAPPROVALS.DataSource = DSAPPROVALS.Tables[0];
            DDLREJECTEDAPPROVALS.DataValueField = "APPROVALID";
            DDLREJECTEDAPPROVALS.DataTextField = "APPROVALNAME";
            DDLREJECTEDAPPROVALS.DataBind();
            DDLREJECTEDAPPROVALS.Items.Insert(0, "--Select--");

        }
    }
    public DataSet GETCREATEDBY_UID(string UID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GETCREATEDBY_BYUID_CFO", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@UID", SqlDbType.VarChar).Value = UID;
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
    public DataSet GETREJECTEDAPPROVALS_CREATEDBY(string CREATEDBY)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USE_GETREJECTEDAPPROVAL_CREATEDBY_CFO", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@CREATED_BY", SqlDbType.VarChar).Value = CREATEDBY;
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


    protected void DDLREJECTEDAPPROVALS_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dsdata = new DataSet();
        dsdata = getapprovaldatabyid(DDLREJECTEDAPPROVALS.SelectedValue, HDNCREATEDBY.Value);
        {
            if (dsdata.Tables[0].Rows[0]["ApprovalName"].ToString() == null || dsdata.Tables[0].Rows[0]["ApprovalName"].ToString() == "")
            {
                lblapprovalname.Text = "NA";
            }
            else
            {
                lblapprovalname.Text = dsdata.Tables[0].Rows[0]["ApprovalName"].ToString();

            }
            if (dsdata.Tables[0].Rows[0]["rejected_reason"].ToString() == null || dsdata.Tables[0].Rows[0]["rejected_reason"].ToString() == "")
            {
                lblrejectedreason.Text = "NA";
            }
            else
            {
                lblrejectedreason.Text = dsdata.Tables[0].Rows[0]["rejected_reason"].ToString();
            }
            if (dsdata.Tables[0].Rows[0]["Dept_Rejected_date"].ToString() == "" || dsdata.Tables[0].Rows[0]["Dept_Rejected_date"].ToString() == null)
            {
                lbldeptrejecteddate.Text = "NA";
            }
            else
            {
                lbldeptrejecteddate.Text = dsdata.Tables[0].Rows[0]["Dept_Rejected_date"].ToString();
            }
            if (dsdata.Tables[0].Rows[0]["Appealdate"].ToString() == null || dsdata.Tables[0].Rows[0]["Appealdate"].ToString() == "")
            {
                lblappealeddate.Text = "NA";
            }
            else
            {
                lblappealeddate.Text = dsdata.Tables[0].Rows[0]["Appealdate"].ToString();
            }
            if (dsdata.Tables[0].Rows[0]["AppealDescription"].ToString() == null || dsdata.Tables[0].Rows[0]["AppealDescription"].ToString() == "")
            {
                lblappealdescription.Text = "NA";
            }
            else
            {
                lblappealdescription.Text = dsdata.Tables[0].Rows[0]["AppealDescription"].ToString();
            }
            if (dsdata.Tables[0].Rows[0]["COIRejectRemarks"].ToString() == null || dsdata.Tables[0].Rows[0]["COIRejectRemarks"].ToString() == "")
            {
                lblcoirejectedremarks.Text = "NA";
            }
            else
            {
                lblcoirejectedremarks.Text = dsdata.Tables[0].Rows[0]["COIRejectRemarks"].ToString();
            }
            if (dsdata.Tables[0].Rows[0]["COIRejectedDate"].ToString() == "" || dsdata.Tables[0].Rows[0]["COIRejectedDate"].ToString() == null)
            {
                lblcoirejecteddate.Text = "NA";
            }
            else
            {
                lblcoirejecteddate.Text = dsdata.Tables[0].Rows[0]["COIRejectedDate"].ToString();
            }

        }

    }
    public DataSet getapprovaldatabyid(string APPROVALID, string CREATEDBY)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USE_getapprovaldatabyid_CFO", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@approvalid", SqlDbType.VarChar).Value = APPROVALID;
            da.SelectCommand.Parameters.Add("@created_by", SqlDbType.VarChar).Value = CREATEDBY;
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

    protected void btnappealprovosion_Click(object sender, EventArgs e)
    {
        if (TXTUIDNUMBER.Text == "" || TXTUIDNUMBER.Text == null)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter UID number')", true);
            return;
        }
        else if (DDLREJECTEDAPPROVALS.SelectedValue == "" || DDLREJECTEDAPPROVALS.SelectedValue == null || DDLREJECTEDAPPROVALS.SelectedValue == "--Select--")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Approval name')", true);
            return;
        }
        else if (TXTAPPEALREMARKS.Text == "" || TXTAPPEALREMARKS.Text == null)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Appeal Remarks')", true);
            return;
        }
        else
        {

            DataSet dsupdate = new DataSet();
            dsupdate = updaterejectedcolumns(DDLREJECTEDAPPROVALS.SelectedValue, HDNCREATEDBY.Value, TXTAPPEALREMARKS.Text);
            if (dsupdate.Tables[0].Rows.Count > 0)
            {
                string a;
                a = dsupdate.Tables[0].Rows[0]["value"].ToString();
                if (a == "1" || a == "2")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Appeal Provision given Successfully')", true);

                    return;
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Filed to give Appeal provision')", true);
                return;
            }

        }

    }
    public DataSet updaterejectedcolumns(string APPROVALID, string CREATEDBY, string APPEALREMARKS)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("usp_updaterejectedcolumns_CFO", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@approvalid", SqlDbType.VarChar).Value = APPROVALID;
            da.SelectCommand.Parameters.Add("@created_by", SqlDbType.VarChar).Value = CREATEDBY;
            da.SelectCommand.Parameters.Add("@APPEALREMARKS", SqlDbType.VarChar).Value = APPEALREMARKS;
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