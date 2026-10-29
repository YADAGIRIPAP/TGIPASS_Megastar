using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;

public partial class UI_TSiPASS_CFEALLAPPROVALSVERIFICATIONBYCOI : System.Web.UI.Page
{
    General gen = new General();
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        MaintainScrollPositionOnPostBack = true;

        if (!IsPostBack)
        {
            txtFromDate.Text = "15-07-2024";
            txtTodate.Text = System.DateTime.Now.ToString("d-MM-yyyy");
            //Getlist_Click(sender, e);

        }
    }
    protected void Getlist_Click(object sender, EventArgs e)
    {
        int valid = 0;
        Label2.Text = "";
        ERROR.Visible = false;
        if (txtFromDate.Text == "" || txtFromDate.Text == null)
        {
            Label2.Text = "<br/> Please Enter 'From Date'";
            valid = 1;
        }
        if (txtTodate.Text == "" || txtTodate.Text == null)
        {
            Label2.Text += "<br/> Please Enter 'To Date'";
            valid = 1;
        }
        if (valid == 0)
        {
            SqlParameter[] pp = new SqlParameter[]
                 {
                    new SqlParameter("@FromDate", SqlDbType.Date),
                    new SqlParameter("@ToDate", SqlDbType.Date)
                 };

            pp[0].Value = txtFromDate.Text;
            pp[1].Value = txtTodate.Text;
            DataSet ds2 = new DataSet();
            ds2 = gen.GenericFillDs("SP_GET_ALLAPPROVAL_ISSUEDUNITSDATA_LATEST", pp);
            if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
                grdDetails.Visible = true;
                grdDetails.DataSource = ds2.Tables[0];
                grdDetails.DataBind();
                //trupdate.Visible = true;
            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
                grdDetails.Visible = false;
            }
        }
        else
        {
            ERROR.Visible = true;
        }
    }

    protected void Update_Click(object sender, EventArgs e)
    {



        Button BtnSave = (Button)sender;
        GridViewRow row = (GridViewRow)BtnSave.NamingContainer;


        Label intCFEEnterpid = (Label)row.FindControl("INTCFEENTERPID");

        Label intquestid = (Label)row.FindControl("intQuessionaireid");
        Label intDeptid = (Label)row.FindControl("INTDEPTID");
        Label intApprovalid = (Label)row.FindControl("INTAPPROVALID");
        Label latestapprovaldate = (Label)row.FindControl("lbllatestapprovaldate");

        TextBox remarks = (TextBox)row.FindControl("txtremarks");
        RadioButtonList rbtverified = (RadioButtonList)row.FindControl("rbtverified");

        //if(rbtverified.SelectedValue==""|| rbtverified.SelectedValue == null)
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Verify the record')", true);
        //    rbtverified.Focus();
        //}
        //else if (rbtverified.SelectedValue == "N" && (remarks.Text == "" || remarks.Text == null))
        //{

        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter reason')", true);
        //    remarks.Focus();


        //}
        //else
        //{

        int returnValue = updateallapprovals_cfe(intCFEEnterpid.Text, intDeptid.Text, intApprovalid.Text, Session["uid"].ToString(), intquestid.Text, "Y", getclientIP(), remarks.Text, latestapprovaldate.Text);
        if (returnValue > 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Application Verified Successfully');", true);
            Getlist_Click(this, EventArgs.Empty);
        }
        //}

    }
    public int updateallapprovals_cfe(string intCFEEnterpid, string intDeptid, string intApprovalid, string Created_by, string intQuessionaireid, string VERIFIEDFLAG, string IPAddress, string remarks, string latestapprovaldate)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[UpdCommissionerApprovalNew_COIVERIFICATION]";

        if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();

        if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();

        if (Created_by.Trim() == "" || Created_by.Trim() == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
            com.Parameters.Add("@intQid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intQid", SqlDbType.VarChar).Value = intQuessionaireid.Trim();

        if (VERIFIEDFLAG.Trim() == "" || VERIFIEDFLAG.Trim() == null)
            com.Parameters.Add("@VERIFIEDFLAG", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@VERIFIEDFLAG", SqlDbType.VarChar).Value = VERIFIEDFLAG.Trim();

        if (IPAddress.Trim() == "" || IPAddress.Trim() == null)
            com.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = IPAddress.Trim();

        if (remarks.Trim() == "" || remarks.Trim() == null)
            com.Parameters.Add("@remarks", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@remarks", SqlDbType.VarChar).Value = remarks.Trim();
        if (latestapprovaldate.Trim() == "" || latestapprovaldate.Trim() == null)
            com.Parameters.Add("@latestapprovaldate", SqlDbType.DateTime).Value = DBNull.Value;
        else
            com.Parameters.Add("@latestapprovaldate", SqlDbType.DateTime).Value = Convert.ToDateTime(latestapprovaldate.Trim());



        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            return com.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }

    public static string getclientIP()
    {
        string result = string.Empty;
        string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (!string.IsNullOrEmpty(ip))
        {
            string[] ipRange = ip.Split(',');
            int le = ipRange.Length - 1;
            result = ipRange[0];
        }
        else
        {
            result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        return result;
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // HyperLink h1 = (HyperLink)e.Row.Cells[12].Controls[0];
            // HyperLink h2 = (HyperLink)e.Row.Cells[13].Controls[0];
            // HyperLink h3 = (HyperLink)e.Row.Cells[14].Controls[0];

            string intUid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();
            LinkButton btn = (LinkButton)e.Row.FindControl("LinkButton1");
            btn.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();
            btn.OnClientClick = "javascript:return Popup('" + intUid + "')";


        }
    }



    protected void rbtverified_SelectedIndexChanged(object sender, EventArgs e)
    {
        RadioButtonList verifiedyesorno = (RadioButtonList)sender;
        GridViewRow row = (GridViewRow)verifiedyesorno.NamingContainer;
        RadioButtonList rbtverified = (RadioButtonList)row.FindControl("rbtverified");
        TextBox remarks = (TextBox)row.FindControl("txtremarks");
        if (rbtverified.SelectedValue == "N")
        {
            remarks.Visible = true;
        }
        else
        {
            remarks.Visible = false;
        }
        rbtverified.Focus();
    }

    protected void BtnReject_Click(object sender, EventArgs e)
    {
        Button BtnReject = (Button)sender;
        GridViewRow row = (GridViewRow)BtnReject.NamingContainer;
        TextBox TxtRemarks = (TextBox)row.FindControl("TxtReject");
        if (!TxtRemarks.Visible)
            TxtRemarks.Visible = true;

        if ((TxtRemarks.Visible) && (TxtRemarks.Text != ""))
        {
            //ScriptManager.RegisterStartupScript(this, GetType(), "RejectValidate", "RejectValidate();", true);
            //return;
        }
        else
        {
            //Response.Write("<script>alert('Please enter remarks');</script>");
            ScriptManager.RegisterStartupScript(this, GetType(), "RejectValidate1", "RejectValidate1();", true);
            TxtRemarks.Focus();
            return;
        }

       


        Label intCFEEnterpid = (Label)row.FindControl("INTCFEENTERPID");

        Label intquestid = (Label)row.FindControl("intQuessionaireid");
        Label intDeptid = (Label)row.FindControl("INTDEPTID");
        Label intApprovalid = (Label)row.FindControl("INTAPPROVALID");
        Label latestapprovaldate = (Label)row.FindControl("lbllatestapprovaldate");

        TextBox remarks = (TextBox)row.FindControl("TxtReject");
        RadioButtonList rbtverified = (RadioButtonList)row.FindControl("rbtverified");

        if (remarks.Text == "" || remarks.Text == null)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter reason')", true);
            remarks.Focus();
        }
        else
        {
            int returnValue = updateallapprovals_cfe(intCFEEnterpid.Text, intDeptid.Text, intApprovalid.Text, Session["uid"].ToString(), intquestid.Text,"N", getclientIP(), remarks.Text, latestapprovaldate.Text);
            if (returnValue > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Application Verified Successfully');", true);
                Getlist_Click(this, EventArgs.Empty);
            }
        }
    }
}