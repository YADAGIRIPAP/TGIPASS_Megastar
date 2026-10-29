using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Globalization;

public partial class UI_TSiPASS_frmDepartment : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["uid"] == null)
            {
                Response.Redirect("~/IpassLogin.aspx");
            }
            if (!IsPostBack)
            {
                txtFromDate.Text = "01-01-2024";
                txtTodate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                binddata(txtFromDate.Text, txtTodate.Text, "%", "%");
            }
        }
        catch (Exception ex) { throw ex; }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            //DateTime selectedDate = DateTime.Parse(txtTodate.Text);
            string Approvals = ddlApprove.SelectedItem.Value;
            string DepartmentName = ddlname.SelectedItem.Value;

            if (txtTodate.Text != "" && txtFromDate.Text != "" && Approvals != "" && DepartmentName != "")
            { binddata(txtFromDate.Text, txtTodate.Text, Approvals, DepartmentName); }
        }
        catch (Exception ex) { throw ex; }

    }
    protected void binddata(string fromdate, string todate, string Approvals, string DepartmentName)
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter("SP_GENERATEAGENDA_DEPARTMENTWISE_Processed_New", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.Date).Value = Convert.ToDateTime(DateTime.ParseExact(fromdate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.Date).Value = Convert.ToDateTime(DateTime.ParseExact(todate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
            //da.SelectCommand.Parameters.Add("@ProcFlag", SqlDbType.VarChar).Value = "Approvals";
            // da.SelectCommand.Parameters.Add("@INTUSERID", SqlDbType.VarChar).Value = "DepartmentName";

            if (ddlApprove.SelectedItem.Text == "" || ddlApprove.SelectedItem.Text == null || ddlApprove.SelectedItem.Text == "--Select--" || ddlApprove.SelectedValue == "0")
            {
                da.SelectCommand.Parameters.Add("@ProcFlag", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                da.SelectCommand.Parameters.AddWithValue("@ProcFlag", ddlApprove.SelectedItem.Value);
            }

            if (ddlname.SelectedItem.Text == "" || ddlname.SelectedItem.Text == null || ddlname.SelectedItem.Text == "--Select--" || ddlname.SelectedValue == "0")
            {
                da.SelectCommand.Parameters.Add("@INTUSERID", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                da.SelectCommand.Parameters.AddWithValue("@INTUSERID", ddlname.SelectedItem.Value);
            }
            da.Fill(ds);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();

                if (ddlApprove.SelectedItem.Text == "Approved")
                {
                    grdDetails.Columns[15].Visible = false;
                }
            }
            else
            {
                Label1.Text = "No Records Found ";

                grdDetails.DataSource = null;
                grdDetails.DataBind();
                //grdDetails.ShowHeaderWhenEmpty = true;

            }
            con.CloseConnection();


        }
        catch (Exception Ex)
        { throw Ex; }


    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink hpViewAppl = (HyperLink)e.Row.Cells[1].Controls[0];
                HyperLink hpAppraisal = (HyperLink)e.Row.Cells[2].Controls[0];
                Label EnterperIncentiveID = (Label)e.Row.Cells[10].FindControl("lblEnterperIncentiveID");
                EnterperIncentiveID.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EnterperIncentiveID")).Trim();
                Label MasterIncentiveID = (Label)e.Row.Cells[11].FindControl("lblIncentiveId");
                MasterIncentiveID.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IncentiveId")).Trim();
                hpAppraisal.Target = "_blank";
                hpAppraisal.NavigateUrl = "appraisalNote2.aspx?incid=" + EnterperIncentiveID.Text + "&mstid=" + MasterIncentiveID.Text;
                hpViewAppl.Target = "_blank";
                hpViewAppl.NavigateUrl = "ApplicantIncentiveDtlsDraftView.aspx?EntrpId=" + EnterperIncentiveID.Text + "&Sts=1";
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
            throw ex;
        }

    }
}