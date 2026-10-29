using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Globalization;
using System.Collections.Generic;

public partial class UI_TSIPASS_FrmSendalltoSVC : System.Web.UI.Page
{
    General gen = new General();
    List<officerRemarks> lstremarks = new List<officerRemarks>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
             Response.Redirect("../../ipasslogin.aspx");
        }
        if (!IsPostBack)
        {

            string Cast = Request.QueryString[0].ToString();
            string Investmentid = Request.QueryString[1].ToString();
            h1heading.InnerHtml = "Scrutiny Pending - Applications";
            DataSet ds = new DataSet();
            ds = gen.fetchIncentivedetIPONewIncTypeAddlDirector(Session["uid"].ToString(), Request.QueryString[0].ToString().Trim(), "", "");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
            }
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        int valid = 0;
        lstremarks.Clear();
        string Role_Code = Session["Role_Code"].ToString().Trim().TrimStart();
        foreach (GridViewRow gvrow in grdDetails.Rows)
        {
            CheckBox chkcheck = ((CheckBox)gvrow.FindControl("chkRow"));
            if (chkcheck.Checked == true)
            {
                officerRemarks fromvo = new officerRemarks();
                int rowIndex = gvrow.RowIndex;
                fromvo.EnterperIncentiveID = ((Label)gvrow.FindControl("lblEnterperIncentiveID")).Text.ToString();
                fromvo.MstIncentiveId = ((Label)gvrow.FindControl("lblIncentiveID")).Text.ToString();
                fromvo.status = "File in full shape";
                fromvo.Remarks = ((Label)gvrow.FindControl("lblRecommendedAmount")).Text.ToString();
                fromvo.CreatedByid = Session["uid"].ToString();
                fromvo.id = "0";
                fromvo.Designation = Role_Code.Trim();
                lstremarks.Add(fromvo);
            }
        }
        if (Request.QueryString["SVCStatus"].ToString() == "PRESVC")  // send to post SVC
        {
            valid = gen.InsertincentiveOfficerCommentsAdditionalPOSTSVC(lstremarks, null, "PRESVC", getclientIP());
        }
        if (valid == 1)
        {
            string message = "alert('Applications are Submitted Successfully')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            Button1.Enabled = false;
        }
    }

    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkAll = (CheckBox)grdDetails.HeaderRow.FindControl("chkAll");

        if (checkAll.Checked)
        {
            foreach (GridViewRow row in grdDetails.Rows)
            {
                CheckBox checkone = (CheckBox)row.FindControl("chkRow");
                checkone.Checked = true;
            }

        }
        else
        {
            foreach (GridViewRow row in grdDetails.Rows)
            {
                CheckBox checkone = (CheckBox)row.FindControl("chkRow");
                checkone.Checked = false;
            }
        }
    }
}