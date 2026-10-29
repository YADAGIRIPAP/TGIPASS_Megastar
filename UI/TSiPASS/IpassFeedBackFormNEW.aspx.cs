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
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Xml;


public partial class UI_TSiPASS_IpassFeedBackFormNEW : System.Web.UI.Page
{
    General Gen = new General();
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
    DataSet oDataSet = new DataSet();
    string checkSno;
    string sno;
    string StatusFlag;
    string excellent, Good, Satisfied, NotSatisfied;

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session.Count <= 0)
        //{
        //    // Response.Redirect("../../frmUserLogin.aspx");
        //    Response.Redirect("~/Index.aspx");
        //}

        if (!IsPostBack)
        {
            GetDetails();
        }
    }

    public void GetDetails()
    {

        DataSet dsn = new DataSet();
        //Response.Write(Session["User_Code"].ToString().Trim()  +  "_" +  rstages.ToString().Trim() + "-" + Session["DistrictID"].ToString().Trim());
        //return;
        if (Request.QueryString[0].ToString() != null)
        {
            dsn = FetchData(Request.QueryString[0].ToString(), Request.QueryString[3].ToString(), Request.QueryString[2].ToString());
            if (dsn.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = dsn.Tables[0];
                grdDetails.DataBind();
                TxtnameofUnit.Text = dsn.Tables[0].Rows[0]["Unit_Name"].ToString().Trim();
                txtpromotername.Text = dsn.Tables[0].Rows[0]["NameofthePromoter"].ToString().Trim();
                txtmobileno.Text = dsn.Tables[0].Rows[0]["MobileNumber"].ToString().Trim();
                TXTUIDNO.Text = dsn.Tables[0].Rows[0]["UID_No"].ToString().Trim();
            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }
        }

    }
    protected void SelectCheckBoxNotSatisfied_CheckedChanged(object sender, EventArgs e)
    {
        //CheckBox ddlStatus = (CheckBox)sender;

        //GridViewRow row = (GridViewRow)ddlStatus.NamingContainer;
        //TextBox TxtRemarks = (TextBox)row.FindControl("TxtReject");

        //if (ddlStatus.Checked==true)
        //{
        //    TxtRemarks.Visible = true;
        //}
        //else
        //{
        //    TxtRemarks.Visible = false;
        //}



        CheckBox ddlExcellent = (CheckBox)sender;

        GridViewRow row = (GridViewRow)ddlExcellent.NamingContainer;
        CheckBox SelectCheckBoxExcellent = (CheckBox)row.FindControl("SelectCheckBoxExcellent");
        CheckBox SelectCheckBoxGood = (CheckBox)row.FindControl("SelectCheckBoxGood");
        CheckBox SelectCheckBoxSatisfied = (CheckBox)row.FindControl("SelectCheckBoxSatisfied");
        CheckBox SelectCheckBoxNotSatisfied = (CheckBox)row.FindControl("SelectCheckBoxNotSatisfied");
        TextBox TxtRemarks = (TextBox)row.FindControl("TxtReject");
        if (ddlExcellent.Checked == true)
        {
            SelectCheckBoxExcellent.Checked = false;
            SelectCheckBoxGood.Checked = false;
            SelectCheckBoxSatisfied.Checked = false;
            SelectCheckBoxNotSatisfied.Checked = true;
            TxtRemarks.Visible = true;
        }
        else
        {
            SelectCheckBoxExcellent.Checked = false;
            SelectCheckBoxGood.Checked = false;
            SelectCheckBoxSatisfied.Checked = false;
            SelectCheckBoxNotSatisfied.Checked = false;
            TxtRemarks.Visible = false;
        }


    }

    protected void SelectCheckBoxExcellent_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ddlExcellent = (CheckBox)sender;

        GridViewRow row = (GridViewRow)ddlExcellent.NamingContainer;
        CheckBox SelectCheckBoxExcellent = (CheckBox)row.FindControl("SelectCheckBoxExcellent");
        CheckBox SelectCheckBoxGood = (CheckBox)row.FindControl("SelectCheckBoxGood");
        CheckBox SelectCheckBoxSatisfied = (CheckBox)row.FindControl("SelectCheckBoxSatisfied");
        CheckBox SelectCheckBoxNotSatisfied = (CheckBox)row.FindControl("SelectCheckBoxNotSatisfied");
        TextBox TxtRemarks = (TextBox)row.FindControl("TxtReject");
        if (ddlExcellent.Checked == true)
        {
            SelectCheckBoxExcellent.Checked = true;
            SelectCheckBoxGood.Checked = false;
            SelectCheckBoxSatisfied.Checked = false;
            SelectCheckBoxNotSatisfied.Checked = false;
            TxtRemarks.Visible = false;
        }
        else
        {

        }
    }

    protected void SelectCheckBoxGood_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ddlExcellent = (CheckBox)sender;

        GridViewRow row = (GridViewRow)ddlExcellent.NamingContainer;
        CheckBox SelectCheckBoxExcellent = (CheckBox)row.FindControl("SelectCheckBoxExcellent");
        CheckBox SelectCheckBoxGood = (CheckBox)row.FindControl("SelectCheckBoxGood");
        CheckBox SelectCheckBoxSatisfied = (CheckBox)row.FindControl("SelectCheckBoxSatisfied");
        CheckBox SelectCheckBoxNotSatisfied = (CheckBox)row.FindControl("SelectCheckBoxNotSatisfied");
        TextBox TxtRemarks = (TextBox)row.FindControl("TxtReject");
        if (ddlExcellent.Checked == true)
        {
            SelectCheckBoxExcellent.Checked = false;
            SelectCheckBoxGood.Checked = true;
            SelectCheckBoxSatisfied.Checked = false;
            SelectCheckBoxNotSatisfied.Checked = false;
            TxtRemarks.Visible = false;
        }
        else
        {

        }
    }

    protected void SelectCheckBoxSatisfied_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ddlExcellent = (CheckBox)sender;

        GridViewRow row = (GridViewRow)ddlExcellent.NamingContainer;
        CheckBox SelectCheckBoxExcellent = (CheckBox)row.FindControl("SelectCheckBoxExcellent");
        CheckBox SelectCheckBoxGood = (CheckBox)row.FindControl("SelectCheckBoxGood");
        CheckBox SelectCheckBoxSatisfied = (CheckBox)row.FindControl("SelectCheckBoxSatisfied");
        CheckBox SelectCheckBoxNotSatisfied = (CheckBox)row.FindControl("SelectCheckBoxNotSatisfied");
        TextBox TxtRemarks = (TextBox)row.FindControl("TxtReject");
        if (ddlExcellent.Checked == true)
        {
            SelectCheckBoxExcellent.Checked = false;
            SelectCheckBoxGood.Checked = false;
            SelectCheckBoxSatisfied.Checked = true;
            SelectCheckBoxNotSatisfied.Checked = false;
            TxtRemarks.Visible = false;
        }
        else
        {

        }
    }

    public DataSet FetchData(string userid, string appltype, string approvalid)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
             new SqlParameter("@Created_by",SqlDbType.VarChar),
                new SqlParameter("@APPLTYPE",SqlDbType.VarChar),
                 new SqlParameter("@APPROVALID",SqlDbType.VarChar)

           };
        pp[0].Value = userid;
        pp[1].Value = appltype;
        pp[2].Value = approvalid;

        Dsnew = Gen.GenericFillDs("USP_GET_DATA_FEEDBACK", pp);
        return Dsnew;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {


        int insertCheck = 0;
        int cnt = grdDetails.Rows.Count;
        int cnt1 = grdDetails.Rows.Count;
        int valid = 1;
        if (cnt < cnt1)
        {

            string message = "alert('Please Provide Feedback to All Departments')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        }
        else
        {
            foreach (GridViewRow row in grdDetails.Rows)
            {
                if (((CheckBox)row.FindControl("SelectCheckBoxExcellent")).Checked)
                {
                    excellent = "Y";
                    valid = 0;
                }

                else if (((CheckBox)row.FindControl("SelectCheckBoxGood")).Checked)
                {
                    Good = "Y";
                    valid = 0;
                }

                else if (((CheckBox)row.FindControl("SelectCheckBoxSatisfied")).Checked)
                {
                    Satisfied = "Y";
                    valid = 0;
                }

                else if (((CheckBox)row.FindControl("SelectCheckBoxNotSatisfied")).Checked)
                {
                    NotSatisfied = "Y";
                    valid = 0;
                }

                if (valid == 1)
                {
                    string message = "alert('Please select any one option to give Feedback to Department')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                int Rowindex = row.RowIndex;


                Label lblApprovalId = (Label)grdDetails.Rows[Rowindex].FindControl("lblApprovalId");
                string ApprovalId = lblApprovalId.Text.ToString();

                Label lblDept_Id = (Label)grdDetails.Rows[Rowindex].FindControl("lblDept_Id");
                string Dept_Id = lblDept_Id.Text.ToString();
                TextBox txtTxtNotSatisfyRemarks = (TextBox)grdDetails.Rows[Rowindex].FindControl("TxtReject");
                string Remarks = txtTxtNotSatisfyRemarks.Text;
                Label lblMobileNumber = (Label)grdDetails.Rows[Rowindex].FindControl("lblMobileNumber");
                string mobilenumber = lblMobileNumber.Text.ToString();

                //string mobilenumber = Request.QueryString["Mobile"].ToString();
                //string approvalname = Request.QueryString["APPROVAL"].ToString();
                string suggestions = txtremarks.Text.Trim();

                osqlConnection.Open();
                SqlCommand oSqlCommand = new SqlCommand("SP_TsipassFeedBack");
                oSqlCommand.Connection = osqlConnection;
                oSqlCommand.CommandType = CommandType.StoredProcedure;
                oSqlCommand.CommandText = "SP_TsipassFeedBack";
                oSqlCommand.Parameters.AddWithValue("@ApprovalId", ApprovalId);
                oSqlCommand.Parameters.AddWithValue("@DepartmentId", Dept_Id);
                oSqlCommand.Parameters.AddWithValue("@Excellent", excellent);
                oSqlCommand.Parameters.AddWithValue("@Good", Good);
                oSqlCommand.Parameters.AddWithValue("@Satisfied", Satisfied);
                oSqlCommand.Parameters.AddWithValue("@NotSatisfied", NotSatisfied);
                oSqlCommand.Parameters.AddWithValue("@NotSatisfyRemarks", Remarks);
                oSqlCommand.Parameters.AddWithValue("@UID_Number", TXTUIDNO.Text);
                oSqlCommand.Parameters.AddWithValue("@CreatedBy", Request.QueryString[0].ToString());

                oSqlCommand.Parameters.AddWithValue("@MobileNumber", mobilenumber);
                //oSqlCommand.Parameters.AddWithValue("@ApprovalName", approvalname);
                oSqlCommand.Parameters.AddWithValue("@SuggestionRemarks", suggestions);
                oSqlCommand.Parameters.AddWithValue("@Appltype", Request.QueryString[3].ToString());
                oSqlCommand.Parameters.AddWithValue("@SMSNo", null);
                oSqlCommand.Parameters.Add("@valid", SqlDbType.Int, 500);
                oSqlCommand.Parameters["@valid"].Direction = ParameterDirection.Output;

                oSqlCommand.ExecuteNonQuery();
                osqlConnection.Close();
                insertCheck = (Int32)oSqlCommand.Parameters["@valid"].Value;

                excellent = "";
                Good = "";
                Satisfied = "";
                NotSatisfied = "";





            }
            if (insertCheck == 1)
            {


                string message = "alert('FeedBack Sumbitted successfully! Thank You')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                btnSubmit.Enabled = false;

            }
            else
            {
                string message = "alert('FeedBack Already Sumbitted Thank You!')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                btnSubmit.Enabled = false;
            }

        }
    }
}