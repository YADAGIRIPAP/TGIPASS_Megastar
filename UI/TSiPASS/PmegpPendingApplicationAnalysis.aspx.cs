using System;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Globalization;
using Org.BouncyCastle.Crypto.Engines;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.UI;
using System.Web;

public partial class UI_TSiPASS_PmegpPendingApplicationAnalysis : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.MaintainScrollPositionOnPostBack = true;
        if (!IsPostBack) { SUBMIT_CLEAR_BTNS.Visible = false; }
        if (Session["uid"] == null || Session["uid"].ToString() == "")
        {
            Response.Redirect("~/TSHome.aspx");
        }
        else
        {
            if (Session["Role_Code"].ToString() == "GM")
            {
                if (!IsPostBack)
                {
                    //txtfrmdate.Text = "01-10-2023";
                    //txttodate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                }
            }
            else { Response.Redirect("~/TSHome.aspx"); }
        }
    }


    protected void Candidate_Reapply_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(CandidateReapply.SelectedItem.Value == "0") 
        {
            Guidance_Block.Visible = true;
        }
        if(CandidateReapply.SelectedItem.Value == "1")
        {
            ShortFallDocuments.ClearSelection();
            ddlGuidance.ClearSelection();
            Others_Remarks.Text = string.Empty;
            Documents_Block.Visible = false;
            Guidance_Others.Visible = false;
            Guidance_Block.Visible = false;
            SUBMIT_CLEAR_BTNS.Visible = true;
        }
    }

    protected void ddlGuidance_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlGuidance.SelectedItem.Value == "0" || ddlGuidance.SelectedItem.Value == "2" || ddlGuidance.SelectedItem.Value == "3")
        {
            ShortFallDocuments.ClearSelection();
            Others_Remarks.Text = string.Empty;
            Documents_Block.Visible = false;
            Guidance_Others.Visible = false;
        }
            if (ddlGuidance.SelectedItem.Value == "1")
        {
            Others_Remarks.Text = string.Empty;
            Guidance_Others.Visible = false;
            Documents_Block.Visible = true;
        }

        if (ddlGuidance.SelectedItem.Value == "4")
        {
            ShortFallDocuments.ClearSelection();
            Documents_Block.Visible = false;
            Guidance_Others.Visible = true;
        }
        if (ddlGuidance.SelectedItem.Value == "1" || ddlGuidance.SelectedItem.Value == "2" || ddlGuidance.SelectedItem.Value == "3" || ddlGuidance.SelectedItem.Value == "4")
        {
            SUBMIT_CLEAR_BTNS.Visible = true;
        }
        else { SUBMIT_CLEAR_BTNS.Visible = false; }
    }

    
    protected void SubmitBtn_Click(object sender, EventArgs e)
    {
        if (RBTREJECTIONAT.SelectedItem != null && ddlRejectionReason.SelectedItem != null && !string.IsNullOrEmpty(NO_Reapply_Remarks.Text) && CandidateReapply.SelectedItem != null && ddlGuidance.SelectedItem != null)
        {
            string documentValue = string.Empty;
            if (ddlGuidance.SelectedItem.Value == "1")
            {
                if (ShortFallDocuments.SelectedIndex ==-1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Documents to be submitted to proceed further');", true);
                    return;
                }
                
            }
            
            if(ddlGuidance.SelectedItem.Value == "4")
            {
                if(string.IsNullOrEmpty(Others_Remarks.Text))
                {
                    ValidateAndHighlight(Others_Remarks);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Fill all the Highlighted Sections Below to Proceed Further.');", true);
                    return;
                }
            }
            try
            {
                ClearErrorClasses();
                con.OpenConnection();
                using (SqlDataAdapter da = new SqlDataAdapter("USP_PMEGP_PENDING_ANALYSIS", con.GetConnection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@ApplicantID", SqlDbType.VarChar).Value = ViewState["LabelApplicantID"];
                    da.SelectCommand.Parameters.Add("@FinancialYeaR", SqlDbType.VarChar).Value = ddlFinYear.SelectedItem.Text;
                    da.SelectCommand.Parameters.Add("@RejectedatBankORDIC", SqlDbType.VarChar).Value = RBTREJECTIONAT.SelectedItem.Text;
                    da.SelectCommand.Parameters.Add("@ReasonForRejection", SqlDbType.VarChar).Value = ddlRejectionReason.SelectedValue;
                    da.SelectCommand.Parameters.Add("@OfficerRemarks", SqlDbType.VarChar).Value = NO_Reapply_Remarks.Text;
                    da.SelectCommand.Parameters.Add("@ReapplyDecision", SqlDbType.VarChar).Value = CandidateReapply.SelectedItem.Text;
                    da.SelectCommand.Parameters.Add("@GuidanceProvided", SqlDbType.VarChar).Value = ddlGuidance.SelectedItem.Text;
                    if(ShortFallDocuments.Items[0].Selected)
                    {
                        da.SelectCommand.Parameters.Add("@DocstobeSub_ProjectReport", SqlDbType.VarChar).Value = "Y";
                    }
                    else
                    {
                        da.SelectCommand.Parameters.Add("@DocstobeSub_ProjectReport", SqlDbType.VarChar).Value = "N";
                    }
                                     
                    if (ShortFallDocuments.Items[1].Selected)
                    {
                        da.SelectCommand.Parameters.Add("@DocstobeSub_castecert", SqlDbType.VarChar).Value = "Y";
                    }
                    else
                    {
                        da.SelectCommand.Parameters.Add("@DocstobeSub_castecert", SqlDbType.VarChar).Value = "N";
                    }
                   
                    if (ShortFallDocuments.Items[2].Selected)
                    {
                        da.SelectCommand.Parameters.Add("@DocstobeSub_QualifiCert", SqlDbType.VarChar).Value = "Y";
                    }
                    else
                    {
                        da.SelectCommand.Parameters.Add("@DocstobeSub_QualifiCert", SqlDbType.VarChar).Value = "N";
                    }
                   
                    if (ShortFallDocuments.Items[3].Selected)
                    {
                        da.SelectCommand.Parameters.Add("@DocstobeSub_RuralAreaCert", SqlDbType.VarChar).Value = "Y";
                    }
                    else
                    {
                        da.SelectCommand.Parameters.Add("@DocstobeSub_RuralAreaCert", SqlDbType.VarChar).Value = "N";
                    }
                    
                    if (ShortFallDocuments.Items[4].Selected)
                    {
                        da.SelectCommand.Parameters.Add("@DocstobeSub_AadharCert", SqlDbType.VarChar).Value = "Y";
                    }
                    else
                    {
                        da.SelectCommand.Parameters.Add("@DocstobeSub_AadharCert", SqlDbType.VarChar).Value = "N";
                    }

                    da.SelectCommand.Parameters.Add("@OtherRemarks", SqlDbType.VarChar).Value = string.IsNullOrWhiteSpace(Others_Remarks.Text) ? "NULL" : Others_Remarks.Text;                  
                    da.SelectCommand.Parameters.Add("@Rejectedby", SqlDbType.VarChar).Value = Session["uid"].ToString();
                    da.SelectCommand.ExecuteNonQuery();
                }
                con.CloseConnection();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('All Details are Submitted Successfully');", true);
                SUBMIT_CLEAR_BTNS.Visible = true;
                SubmitBtn.Enabled = false;
                Rejectedat.Visible = false;
                RBTREJECTIONAT.ClearSelection();

                ddlRejectionReason.ClearSelection();
                NO_Reapply_Remarks.Text = "";
                CandidateReapply.ClearSelection();
                ddlGuidance.ClearSelection();
                ShortFallDocuments.ClearSelection();
                Others_Remarks.Text = "";
                Readdply_Officer_Remarks.Visible = false;
                Readdply_Officer_Remarks.InnerText = null;
                Readdply_No_Remarks.Visible = false;
             
                Documents_Block.Visible = false;
                Guidance_Others.Visible = false;
                Guidance_Block.Visible = false;
                CandidateReapply_Block.Visible = false;


            }
            catch (Exception ex)
            {
                throw ex;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "errorAlert", "alert('Internal Error Occoured. Data Not Saved. Please Contact Administrator for Resolution');", true);
                //SUBMIT_CLEAR_BTNS.Visible = true;
                //SubmitBtn.Enabled = false;
            }
        }
        else
        {
            ClearErrorClasses();
            ValidateAndHighlightRadioBtn(RBTREJECTIONAT); ValidateAndHighlightdropdown(ddlRejectionReason); ValidateAndHighlight(NO_Reapply_Remarks); ValidateAndHighlightRadioBtn(CandidateReapply); ValidateAndHighlightdropdown(ddlGuidance);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Fill all the Highlighted Sections Below to Proceed Further.');", true);
        }

    }
    public void BindrejectionReasons()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlRejectionReason.Items.Clear();
            dsd = GetRejectionReasons();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlRejectionReason.DataSource = dsd.Tables[0];
                ddlRejectionReason.DataValueField = "REASONID";
                ddlRejectionReason.DataTextField = "REJECTIONREASON";
                ddlRejectionReason.DataBind();
                AddSelect(ddlRejectionReason);
            }
            else
            {
                AddSelect(ddlRejectionReason);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet GetRejectionReasons()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_GETREJECTIONREASONS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;




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
    public void AddSelect(DropDownList ddl)
    {
        try
        {
            ListItem li = new ListItem();
            li.Text = "--Select--";
            li.Value = "0";
            ddl.Items.Insert(0, li);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void binddata()
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter("sp_getrejectedcases_districtwise", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            //da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.Date).Value = DateTime.ParseExact(fromdate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            //da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.Date).Value = DateTime.ParseExact(todate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            da.SelectCommand.Parameters.Add("@FinYear", SqlDbType.VarChar).Value = ddlFinYear.SelectedValue;
            da.SelectCommand.Parameters.Add("@ApplicantIDORNAME", SqlDbType.NVarChar).Value = "%" + Grid_Search.Text + "%";
            da.SelectCommand.Parameters.Add("@districtid", SqlDbType.VarChar).Value = Session["DistrictId"].ToString();
            da.Fill(ds);
            con.CloseConnection();
            if(ds.Tables.Count>0 && ds.Tables[0].Rows.Count > 0)
            {
                grdsupport.DataSource = ds;
                grdsupport.DataBind();

            }
            else
            {
                GridViewBlock.Visible = false;
                grdsupport.DataSource = null;
            }

        }
        catch (Exception Ex)
        { throw Ex; }
    }

    protected void ClearBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UI/TSiPASS/PmegpPendingApplicationAnalysis.aspx");
    }

    protected void BtnGetData_Click(object sender, EventArgs e)
    {
        if (ddlFinYear.SelectedItem.Text != "--Select--")
        {
            GridViewBlock.Visible = true;
            binddata();
        }
        else
        {
           

            ScriptManager.RegisterStartupScript(this, this.GetType(), "errorAlert", "alert('Please Select Financial Year to Fetch Record');", true);
            GridViewBlock.Visible = false;
        }
    }

    protected void ValidateAndHighlight(TextBox textBox)
    {
        if (string.IsNullOrEmpty(textBox.Text))
        { textBox.CssClass = "error-border"; }
        else { textBox.CssClass = ""; }
    }

    protected void ValidateAndHighlightdropdown(DropDownList dropDownlist)
    {
        if (dropDownlist.SelectedItem.Text == "--Select--")
        { dropDownlist.CssClass = "error-border"; }
        else { dropDownlist.CssClass = ""; }
    }
    protected void ValidateAndHighlightRadioBtn(RadioButtonList radioButton)
    {
        if (radioButton.SelectedIndex >= 0)
        { radioButton.CssClass = ""; }
        else { radioButton.CssClass = "error-border"; }
    }
    protected void ClearErrorClasses()
    {
        CandidateReapply.CssClass = ""; ddlGuidance.CssClass = ""; RBTREJECTIONAT.CssClass = ""; Others_Remarks.CssClass = ""; ddlRejectionReason.CssClass = "";
        NO_Reapply_Remarks.CssClass = "";
    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UI/TSiPASS/PmegpPendingApplicationAnalysis.aspx");
    }

    protected void SelectCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((CheckBox)sender).NamingContainer);

        if (row != null)
        {
            CheckBox chk = (CheckBox)row.FindControl("SelectCheckBox");
            if (chk != null && chk.Checked)
            {
                ViewState ["LabelApplicantID"] = ((Label)row.FindControl("LabelApplicantID")).Text;
                //Label LabelApplicantName = ((Label)row.FindControl("LabelApplicantName"));
                //Label LabelApplicantAddress = ((Label)row.FindControl("LabelApplicantAddress"));
                //Label LabelUnitAddress = ((Label)row.FindControl("LabelUnitAddress"));
                //Label LabelFinancingBranchAddress = ((Label)row.FindControl("LabelFinancingBranchAddress"));
                //Label LabelOnlineSubmissionDate = ((Label)row.FindControl("LabelOnlineSubmissionDate"));
                //Label LabelForwardingDatetoBank = ((Label)row.FindControl("LabelForwardingDatetoBank"));
                //Label LabelBankRemarks = ((Label)row.FindControl("LabelBankRemarks"));
                //Label LabelUnderProcess_Rejection = ((Label)row.FindControl("LabelUnderProcess_Rejection"));

                Rejectedat.Visible = true;
                Readdply_No_Remarks.Visible = true;
                CandidateReapply_Block.Visible = true;
                Readdply_Officer_Remarks.Visible = true;
                HideOtherRows(row.RowIndex);
                BindrejectionReasons();
            }
            else
            {
                CandidateReapply.ClearSelection();
                RBTREJECTIONAT.ClearSelection();
                Rejectedat.Visible = false;
                Readdply_Officer_Remarks.Visible = false;
                Readdply_Officer_Remarks.InnerText = null;
                Readdply_No_Remarks.Visible = false;
                ddlRejectionReason.ClearSelection();
                ShortFallDocuments.ClearSelection();
                ddlGuidance.ClearSelection();
                Others_Remarks.Text = string.Empty;
                Documents_Block.Visible = false;
                Guidance_Others.Visible = false;
                Guidance_Block.Visible = false;
                CandidateReapply_Block.Visible = false;
                ClearHiddenState();
            }
        }
    }

    private void HideOtherRows(int selectedIndex)
    {
        for (int i = 0; i < grdsupport.Rows.Count; i++)
        {
            if (i != selectedIndex)
            {
                grdsupport.Rows[i].Visible = false;
            }
        }
    }

    private void ClearHiddenState()
    {
        for (int i = 0; i < grdsupport.Rows.Count; i++)
        {
            grdsupport.Rows[i].Visible = true;
        }
    }

}