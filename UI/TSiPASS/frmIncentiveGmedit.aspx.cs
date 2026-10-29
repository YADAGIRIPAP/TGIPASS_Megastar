using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using System.Xml;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class UI_TSIPASS_frmIncentiveGmedit : System.Web.UI.Page
{
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Button7.Visible = false ;
            ViewState["Rowid"] = "";
            DataSet ds = new DataSet();
            string Role_Code = Session["Role_Code"].ToString().Trim().TrimStart();
            string Applicantinid = "";
            string Mstid = "";
            string Userid = "";
            Userid = Session["uid"].ToString();
            Applicantinid = Request.QueryString[0].ToString();
            Mstid = Request.QueryString[1].ToString();

            ds = Getchildandparentdata(Applicantinid, Userid, Mstid);
            try
            {
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    BindFinancialYears(ddlFinYearEnergy, "10", Applicantinid);
                    // string mstincentiveid = ds.Tables[0].Rows[i]["IncentiveID"].ToString();  // tm_Incentive --> Master table
                    txtUnitname.Text = ds.Tables[0].Rows[0]["UnitName"].ToString();
                    txtApplicantName.Text = ds.Tables[0].Rows[0]["ApplciantName"].ToString();
                    ddlCategory.Text = ds.Tables[0].Rows[0]["Category"].ToString();
                    ddltypeofOrg.Text = ds.Tables[0].Rows[0]["OrgType2"].ToString();
                    rblCastenew.Text = ds.Tables[0].Rows[0]["Caste"].ToString();
                    rblCastenew.Text = ds.Tables[0].Rows[0]["SocialStatus"].ToString();
                    if (ds.Tables[0].Rows[0]["SubCaste"].ToString() != "")
                    {
                        ViewState["subcasteid"] = ds.Tables[0].Rows[0]["SubCaste"].ToString();
                        if (ds.Tables[0].Rows[0]["SubCaste"].ToString() == "1")
                        {
                            Label2.Text = "(BC-A)";
                        }
                        else if (ds.Tables[0].Rows[0]["SubCaste"].ToString() == "2")
                        {
                            Label2.Text = "(BC-B)";
                        }
                        else if (ds.Tables[0].Rows[0]["SubCaste"].ToString() == "3")
                        {
                            Label2.Text = "(BC-C)";
                        }
                        else if (ds.Tables[0].Rows[0]["SubCaste"].ToString() == "4")
                        {
                            Label2.Text = "(BC-D)";
                        }
                        else if (ds.Tables[0].Rows[0]["SubCaste"].ToString() == "5")
                        {
                            Label2.Text = "(BC-E)";
                        }
                    }
                }
                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    gvinspectionOfficer.DataSource = ds.Tables[1];
                    gvinspectionOfficer.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }

    private void BindFinancialYears(DropDownList ddl, string Count, string incentiveid)
    {
        DataSet dsYears = new DataSet();
        dsYears = Gen.GetFinancialYearIncentives(Count, incentiveid);
        if (dsYears != null && dsYears.Tables.Count > 0 && dsYears.Tables[0].Rows.Count > 0)
        {
            ddl.DataSource = dsYears.Tables[0];
            ddl.DataTextField = "FinancialYear";
            ddl.DataValueField = "SlNo";
            ddl.DataBind();
        }
        ddl.Items.Insert(0, "--Select--");

    }
    protected void ddlselect_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlselect.SelectedValue == "1")
        {
            trcate.Visible = true;
            tr1.Visible = false;
            Button7.Visible = true;
            // int indx = rblCaste.Items.IndexOf(rblCaste.Items.FindByText(rblCastenew.Text));
            if (rblCastenew.Text.Trim() != "OBC")
                rblCaste.Items.Remove(rblCaste.Items.FindByText(rblCastenew.Text));
            else
                ddlsubcaste.Items.Remove(ddlsubcaste.Items.FindByValue(ViewState["subcasteid"].ToString()));
        }
        else if (ddlselect.SelectedValue == "2")
        {
            trcate.Visible = false;
            tr1.Visible = true;
            Button7.Visible = false;
        }
    }

    public DataSet Getchildandparentdata(string incentiveID, string Userid, string Mstid)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentveID",SqlDbType.VarChar),
               new SqlParameter("@Userid",SqlDbType.VarChar),
               new SqlParameter("@Mstid",SqlDbType.VarChar),
           };
        pp[0].Value = incentiveID;
        pp[1].Value = Userid;
        pp[2].Value = Mstid;
        Dsnew = Gen.GenericFillDs("FETCHINC_DETAILS_ID_NEW_EDIT", pp);
        return Dsnew;
    }

    protected void rblCaste_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblCaste.SelectedValue == "2")
            {
                trsubcaste.Visible = true;
            }
            else
            {
                trsubcaste.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Errors.ErrorLog(ex);
        }
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        string Role_Code = Session["Role_Code"].ToString().Trim().TrimStart();
        string Applicantinid = "";
        string Mstid = "";
        string Userid = "";
        Userid = Session["uid"].ToString();
        Applicantinid = Request.QueryString[0].ToString();
        Mstid = Request.QueryString[1].ToString();

        if (ddlselect.SelectedValue == "1")
        {
            int VALID = UpdatechildRecords(Applicantinid, Mstid, rblCaste.SelectedValue, ddlsubcaste.SelectedValue, Userid);

            lblmsg.Text = "<font color='green'>Updated Successfully..!</font>";
            success.Visible = true;
            Failure.Visible = false;

            string message = "alert('Updated Successfully')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        }
    }

    public int UpdatechildRecords(string incentiveID, string mstId, string Caste, string Subcaste, string userid)
    {
        SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentveID",SqlDbType.VarChar),
               new SqlParameter("@Mstid",SqlDbType.VarChar),
               new SqlParameter("@Caste",SqlDbType.VarChar),
               new SqlParameter("@Subcaste",SqlDbType.VarChar),
                new SqlParameter("@Userid",SqlDbType.VarChar),
                new SqlParameter("@Outresponse",SqlDbType.VarChar)
           };
        pp[0].Value = incentiveID;
        pp[1].Value = mstId;
        pp[2].Value = Caste;
        pp[3].Value = Subcaste;
        pp[4].Value = userid;
        pp[5].Value = "0";
        pp[5].Direction = ParameterDirection.Output;
        int valid = 0;
        valid = Gen.GenericExecuteNonQuery("USP_UPD_GMIncentives", pp);
        return valid;
    }
    protected void btnEnergyAdd_Click(object sender, EventArgs e)
    {
        int valid = 0;
        try
        {
            if (ddlFinYearEnergy.SelectedItem.Text == "--Select--")
            {
                lblmsg0.Text = "Please Select Financial Year" + "<br/>";
                Failure.Visible = true;
                btnEnergyAdd.Focus();
                ddlFinYearEnergy.Focus();
                valid = 1;
            }
            if (ddlFin1stOr2ndHalfyear.SelectedItem.Text == "--Select--")
            {
                lblmsg0.Text = "Please Select 1st or 2nd Half of Financial Year" + "<br/>";
                Failure.Visible = true;
                btnEnergyAdd.Focus();
                ddlFin1stOr2ndHalfyear.Focus();
                valid = 1;
            }


            if (valid == 0)
            {
                string createdby = Session["uid"].ToString();
                string Rowid = "";
                string Transatype = "";
                if (ViewState["Rowid"] != null && ViewState["Rowid"].ToString() != "")
                {
                    Rowid = ViewState["Rowid"].ToString();
                }
                if (Rowid == "" || Rowid == "0")
                {
                    Transatype = "INS";
                }
                if (Rowid != "")
                {
                    Transatype = "UPD";
                }
                string Applicantinid = Request.QueryString[0].ToString();
                string Mstid = Request.QueryString[1].ToString();
                
                int updatedflg = Updatefinacilayear(Applicantinid, Mstid, ddlFinYearEnergy.SelectedValue, ddlFin1stOr2ndHalfyear.SelectedValue, createdby, Rowid, Transatype);

                lblmsg.Text = "<font color='green'>Updated Successfully..!</font>";
                success.Visible = true;
                Failure.Visible = false;

                string message = "alert('Updated Successfully')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                ViewState["Rowid"] = "";
                Rowid = "";
                DataSet ds = Getchildandparentdata(Applicantinid, createdby, Mstid);
                try
                {
                    if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {
                        gvinspectionOfficer.DataSource = ds.Tables[1];
                        gvinspectionOfficer.DataBind();
                    }
                }
                catch (Exception ex)
                {

                }
                ddlFinYearEnergy.SelectedIndex = 0;
                ddlFin1stOr2ndHalfyear.SelectedIndex = 0;
            }
        }
        catch (Exception ee)
        {
            //throw ee;
        }
    }

    public int Updatefinacilayear(string incentiveID, string mstId, string finacilayeatid, string storndhalf, string userid, string Rowid, string Transatype)
    {
        SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentveID",SqlDbType.VarChar),
               new SqlParameter("@Mstid",SqlDbType.VarChar),
               new SqlParameter("@finacilayeatid",SqlDbType.VarChar),
               new SqlParameter("@storndhalf",SqlDbType.VarChar),
               new SqlParameter("@Userid",SqlDbType.VarChar),
               new SqlParameter("@Rowid",SqlDbType.VarChar),
               new SqlParameter("@Transatype",SqlDbType.VarChar),
               new SqlParameter("@Outresponse",SqlDbType.VarChar)
           };
        pp[0].Value = incentiveID;
        pp[1].Value = mstId;
        pp[2].Value = finacilayeatid;
        pp[3].Value = storndhalf;
        pp[4].Value = userid;
        pp[5].Value = Rowid;
        pp[6].Value = Transatype;
        pp[7].Value = "0";
        pp[7].Direction = ParameterDirection.Output;
        int valid = 0;
        valid = Gen.GenericExecuteNonQuery("USP_UPDATE_INCENTIVES_CLAIMEDFINYEARS_BYGM", pp);
        return valid;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
        ddlFinYearEnergy.SelectedValue = ((Label)gvinspectionOfficer.Rows[indexing].FindControl("lblFinancialYearId")).Text;
        ddlFin1stOr2ndHalfyear.SelectedValue = ((Label)gvinspectionOfficer.Rows[indexing].FindControl("lblFin1stOr2ndHalfYearID")).Text;
        ViewState["Rowid"] = ((Label)gvinspectionOfficer.Rows[indexing].FindControl("lblfinRowid")).Text;
        btnEnergyAdd.Text = "Update";
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
        string createdby = Session["uid"].ToString();
        string Rowid = "";
        string Transatype = "";
        Rowid = ViewState["Rowid"].ToString();
        Transatype = "DEL";
        Rowid = ((Label)gvinspectionOfficer.Rows[indexing].FindControl("lblfinRowid")).Text;
        string Applicantinid = ((Label)gvinspectionOfficer.Rows[indexing].FindControl("txtiIncentiveIdNew")).Text; ;
        string Mstid = ((Label)gvinspectionOfficer.Rows[indexing].FindControl("lblMstIncentiveId")).Text; ;
        int updatedflg = Updatefinacilayear(Applicantinid, Mstid, ddlFinYearEnergy.SelectedValue, ddlFin1stOr2ndHalfyear.SelectedValue, createdby, Rowid, Transatype);

        lblmsg.Text = "<font color='green'>Deleted Successfully..!</font>";
        success.Visible = true;
        Failure.Visible = false;

        string message = "alert('Updated Successfully')";
        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

        ViewState["Rowid"] = "";
        Rowid = "";
        DataSet ds = Getchildandparentdata(Applicantinid, createdby, Mstid);
        try
        {
            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                gvinspectionOfficer.DataSource = ds.Tables[1];
                gvinspectionOfficer.DataBind();
            }
        }
        catch (Exception ex)
        {

        }
        btnEnergyAdd.Text = "Add New";
        ddlFinYearEnergy.SelectedIndex = 0;
        ddlFin1stOr2ndHalfyear.SelectedIndex = 0;
        ViewState["Rowid"] = "";
        Rowid = "";
    }
    protected void btnEnergyClear_Click(object sender, EventArgs e)
    {
        btnEnergyAdd.Text = "Add New";
        ddlFinYearEnergy.SelectedIndex = 0;
        ddlFin1stOr2ndHalfyear.SelectedIndex = 0;
        ViewState["Rowid"] = "";
    }
}