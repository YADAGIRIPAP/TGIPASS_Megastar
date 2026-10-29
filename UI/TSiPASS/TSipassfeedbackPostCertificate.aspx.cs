using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class UI_TSiPASS_TSipassfeedbackPostCertificate : System.Web.UI.Page
{
    General Gen = new General();
    TsipassFeedbackFormVOs objvo = new TsipassFeedbackFormVOs();

    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    static DataTable dtMyTable;
    static DataTable dtMyTableCertificate;
    List<Stairecases> lststire = new List<Stairecases>();
    static DataTable dtMyTable1;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["uid"] != null)
                {
                    GetDepartment1();

                    dtMyTableCertificate = createtablecrtificate1();
                    Session["CertificateTb2"] = dtMyTableCertificate;

                    dtMyTableCertificate = createtablecrtificate1();
                    Session["CertificateTb4"] = dtMyTableCertificate;
                }
                else
                {
                    Response.Redirect("~/tshome.aspx");
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        AssignControlstoVOs();
        int feedbackid = 0;
        feedbackid = Gen.InsertTsipassFeedbackPostCertificate(objvo);
        if (feedbackid > 0)
        {
            int valid = 0;

            Session["feedbackid"] = "";
            Session["feedbackid"] = feedbackid;

            valid = SaveIssuesFacedFromGridViewToTable(feedbackid);
            if (valid > 0)
            {
                string message = "alert('Thank you for taking time to participate in our survey. We truly value the information you have provided.')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }
        }
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UI/TSiPASS/TSipassfeedbackPostCertificate.aspx");
    }

    public void AssignControlstoVOs()
    {
        // Post Download Certficate
        objvo.PDgivenlicensewithintimelines = rblLicenseApproval.SelectedValue.ToString();
        objvo.PDgivenlicensewithintimelinesissues = txtLicenseApprovalIssuesFaced.Text.Trim();

        objvo.PDtrackapplnstatus = rblTrackstatus.SelectedValue.ToString();
        objvo.PDtrackapplnstatusissues = txtTrackStatusIssuesFaced.Text.Trim();

        objvo.PDaskedOfflineinfodocs = rblOfflineInfoasked.SelectedValue.ToString();
        objvo.PDaskedOfflineinfodocsissues = txtOfflineInfoaskedIssuesFaced.Text.Trim();

        objvo.PDInspectionpremisesfeedback = Convert.ToInt16(rblInspectionFeedback.SelectedValue);
        objvo.PDInspectionpremisesfeedbackissues = txtInspectionFeedbackIssuesfaced.Text.Trim();

        objvo.PDfinalqltyofexp = rblrateQltyPost.SelectedValue;
        objvo.PDFfnalqltyofexpissues = txtrateqltyPostIssuesfaced.Text.Trim();

        objvo.createdby = Convert.ToInt16(Session["uid"].ToString());
    }


    // bulk insert
    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
        gvCertificate.Visible = true;
        try
        {
            int valid = 0;
            if (ddlDeptlist.SelectedItem.Text.ToUpper() == "--Select--")
            {
                lblmsg0.Text = "Department Name Cannot be blank" + "<br/>";
                Failure.Visible = true;
                ddlDeptlist.Focus();
                valid = 1;
            }
            if (ddldeptApprovals.SelectedItem.Text.ToUpper() == "--Select--")
            {
                lblmsg0.Text = "Approval Cannot be blank" + "<br/>";
                Failure.Visible = true;
                ddldeptApprovals.Focus();
                valid = 1;
            }
            if (txtThirdissuesfaced.Text == "" || txtThirdissuesfaced.Text == null)
            {
                lblmsg0.Text = "Issues faced Cannot be blank" + "<br/>";
                Failure.Visible = true;
                txtThirdissuesfaced.Focus();
                valid = 1;
            }
            if (valid == 0)
            {
                string questionid = "1";
                string createdby = Session["uid"].ToString();

                AddDataToTableCeertificate(questionid, ddlDeptlist.SelectedValue, ddlDeptlist.SelectedItem.Text, ddldeptApprovals.SelectedValue, ddldeptApprovals.SelectedItem.Text, txtThirdissuesfaced.Text.Trim(), createdby, (DataTable)Session["CertificateTb2"]);
                this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                this.gvCertificate.DataBind();
                // lblmsg.Text = "";
            }
        }
        catch (Exception ee)
        {
            ////lbldtvalid.Text = "Please enter correct Date.";
            ////lbldtvalid.ForeColor = System.Drawing.Color.DarkRed;
        }

        gvCertificate.Visible = true;
    }

    private void AddDataToTableCeertificate(string questionid, string deptid, string deptname, string approvalid, string approvalname, string issuesfaced, string createdby, DataTable myTable)
    {
        try
        {

            DataRow Row;
            Row = myTable.NewRow();
            dtMyTable = new DataTable("CertificateTb2");

            Row["questionid"] = questionid;
            Row["deptid"] = deptid;
            Row["deptname"] = deptname;
            Row["approvalid"] = approvalid;
            Row["approvalname"] = approvalname;
            Row["issuesfaced"] = issuesfaced;
            Row["createdby"] = createdby;
            // Row["id"] = "";
            myTable.Rows.Add(Row);
        }
        catch (Exception ee)
        {
            //  ((DataTable)Session["myDatatable"]).Rows.Clear();
            //  Response.Redirect("~/EmpFacility.aspx");
        }
    }

    private void AddDataToTableCeertificate4(string questionid, string deptid, string deptname, string approvalid, string approvalname, string issuesfaced, string createdby, DataTable myTable)
    {
        try
        {

            DataRow Row;
            Row = myTable.NewRow();
            dtMyTable = new DataTable("CertificateTb4");

            Row["questionid"] = questionid;
            Row["deptid"] = deptid;
            Row["deptname"] = deptname;
            Row["approvalid"] = approvalid;
            Row["approvalname"] = approvalname;
            Row["issuesfaced"] = issuesfaced;
            Row["createdby"] = createdby;
            // Row["id"] = "";
            myTable.Rows.Add(Row);
        }
        catch (Exception ee)
        {
            //  ((DataTable)Session["myDatatable"]).Rows.Clear();
            //  Response.Redirect("~/EmpFacility.aspx");
        }
    }

    protected void GetNewRectoInsertdr()
    {
        myDtNewRecdr = (DataTable)Session["CertificateTb2"];
        DataView dvdr = new DataView(myDtNewRecdr);
        myDtNewRecdr = dvdr.ToTable();
    }

    protected void GetNewRectoInsertdr4()
    {
        myDtNewRecdr = (DataTable)Session["CertificateTb4"];
        DataView dvdr = new DataView(myDtNewRecdr);
        myDtNewRecdr = dvdr.ToTable();
    }
    protected void BtnClear0_Click2(object sender, EventArgs e)
    {

    }
    protected void gvCertificate_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {

            ((DataTable)Session["CertificateTb2"]).Rows.RemoveAt(e.RowIndex);

            this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
            this.gvCertificate.DataBind();
        }
        catch (Exception ex)
        {
            //  lblmsg.Text = "Please enter correct data";// ex.ToString();

        }
        finally
        {

        }
    }
    protected void gvCertificate_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void gvCertificate4_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {

            ((DataTable)Session["CertificateTb4"]).Rows.RemoveAt(e.RowIndex);

            this.gvCertificate4.DataSource = ((DataTable)Session["CertificateTb4"]).DefaultView;
            this.gvCertificate4.DataBind();
        }
        catch (Exception ex)
        {
            //  lblmsg.Text = "Please enter correct data";// ex.ToString();

        }
        finally
        {

        }
    }
    protected void gvCertificate4_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    public int SaveIssuesFacedFromGridViewToTable(int feedbackid)
    {
        int status = 0;

        if (((DataTable)Session["CertificateTb2"]).Rows.Count > 0)
        {
            GetNewRectoInsertdr();
            status = Gen.bulkInsertFeedbackPostCertificate(myDtNewRecdr, feedbackid);          
        }
        if (((DataTable)Session["CertificateTb4"]).Rows.Count > 0)
        {
            GetNewRectoInsertdr4();
            status = Gen.bulkInsertFeedbackPostCertificate(myDtNewRecdr, feedbackid);
        }
        return status;
    }

    protected DataTable createtablecrtificate1()
    {
        dtMyTable1 = new DataTable("CertificateTb1");

        // dtMyTable1.Columns.Add("new", typeof(string));

        dtMyTable1.Columns.Add("feedbackid", typeof(string));
        dtMyTable1.Columns.Add("questionid", typeof(string));
        dtMyTable1.Columns.Add("deptid", typeof(string));
        dtMyTable1.Columns.Add("deptname", typeof(string));
        dtMyTable1.Columns.Add("approvalid", typeof(string));
        dtMyTable1.Columns.Add("approvalname", typeof(string));
        dtMyTable1.Columns.Add("issuesfaced", typeof(string));
        dtMyTable1.Columns.Add("createdby", typeof(string));

        return dtMyTable1;
    }


    protected void BtnSave4_Click1(object sender, EventArgs e)
    {
        gvCertificate4.Visible = true;
        try
        {
            int valid = 0;
            if (ddlDeptlist4.SelectedItem.Text.ToUpper() == "--Select--")
            {
                lblmsg0.Text = "Department Name Cannot be blank" + "<br/>";
                Failure.Visible = true;
                ddlDeptlist4.Focus();
                valid = 1;
            }
            if (ddldeptApprovals4.SelectedItem.Text.ToUpper() == "--Select--")
            {
                lblmsg0.Text = "Approval Cannot be blank" + "<br/>";
                Failure.Visible = true;
                ddldeptApprovals4.Focus();
                valid = 1;
            }
            if (txtFourthIssuesFaced.Text == "" || txtFourthIssuesFaced.Text == null)
            {
                lblmsg0.Text = "Issues faced Cannot be blank" + "<br/>";
                Failure.Visible = true;
                txtFourthIssuesFaced.Focus();
                valid = 1;
            }
            if (valid == 0)
            {
                string questionid = "4";
                string createdby = Session["uid"].ToString();

                AddDataToTableCeertificate4(questionid, ddlDeptlist4.SelectedValue, ddlDeptlist4.SelectedItem.Text, ddldeptApprovals4.SelectedValue, ddldeptApprovals4.SelectedItem.Text, txtFourthIssuesFaced.Text.Trim(), createdby, (DataTable)Session["CertificateTb4"]);
                this.gvCertificate4.DataSource = ((DataTable)Session["CertificateTb4"]).DefaultView;
                this.gvCertificate4.DataBind();
                // lblmsg.Text = "";
            }
        }
        catch (Exception ee)
        {
            ////lbldtvalid.Text = "Please enter correct Date.";
            ////lbldtvalid.ForeColor = System.Drawing.Color.DarkRed;
        }

        gvCertificate4.Visible = true;

    }
    protected void BtnClear4_Click2(object sender, EventArgs e)
    {

    }

    protected void GetDepartment1()
    {
        DataSet dsd = new DataSet();
        dsd = Gen.GetDepartmentFeedback();
        ddlDeptlist.DataSource = dsd.Tables[0];
        ddlDeptlist.DataValueField = "Dept_Id";
        ddlDeptlist.DataTextField = "Dept_Full_name";
        ddlDeptlist.DataBind();
        ddlDeptlist.Items.Insert(0, "--Select--");

        ddlDeptlist4.DataSource = dsd.Tables[0];
        ddlDeptlist4.DataValueField = "Dept_Id";
        ddlDeptlist4.DataTextField = "Dept_Full_name";
        ddlDeptlist4.DataBind();
        ddlDeptlist4.Items.Insert(0, "--Select--");
    }


    protected void ddlDeptlist_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDeptApprovalsListFeedback( Convert.ToInt16(ddlDeptlist.SelectedValue.ToString()) );
    }

    protected void GetDeptApprovalsListFeedback(int deptid)
    {
        DataSet dsd = new DataSet();
        dsd = Gen.GetDeptApprovalsListFeedback(deptid);
        ddldeptApprovals.DataSource = dsd.Tables[0];
        ddldeptApprovals.DataValueField = "ApprovalId";
        ddldeptApprovals.DataTextField = "ApprovalName";
        ddldeptApprovals.DataBind();
        ddldeptApprovals.Items.Insert(0, "--Select--");
        ddldeptApprovals.Focus();

    }

    protected void ddlDeptlist4_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDeptApprovalsListFeedback4(Convert.ToInt16(ddlDeptlist4.SelectedValue.ToString()));
    }
    protected void GetDeptApprovalsListFeedback4(int deptid)
    {
        DataSet dsd = new DataSet();
        dsd = Gen.GetDeptApprovalsListFeedback(deptid);
        ddldeptApprovals4.DataSource = dsd.Tables[0];
        ddldeptApprovals4.DataValueField = "ApprovalId";
        ddldeptApprovals4.DataTextField = "ApprovalName";
        ddldeptApprovals4.DataBind();
        ddldeptApprovals4.Items.Insert(0, "--Select--");
        ddldeptApprovals4.Focus();
    }


}