using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;


public partial class UI_TSiPASS_DIPCSanctionedDtlsEntryScreenNew : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    Fetch objFetch = new Fetch();
    IncentivesVOs objvo = new IncentivesVOs();
    IncentiveVosA objvoA = new IncentiveVosA();
    comFunctions objCmf = new comFunctions();

    static DataTable dt1;
    static DataTable dt2;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Session["uid"] != null)
                {
                    objCmf.BindCtlto(true, ddlcategory, objFetch.FetchCategory(), 1, 0, false);
                    objCmf.BindCtlto(true, ddlBank, objFetch.FetchBankMst(), 1, 0, false);
                    BindBankAccountType();

                    if (Session["UIDNO"] != null && Session["UIDNO"].ToString() != "")
                    {
                        objvo.UidNoInc = Session["UIDNO"].ToString();

                        DataSet dsuiddetails = new DataSet();
                        dsuiddetails = Gen.GetSLCDetailsByUIDNO(objvo.UidNoInc);

                        if (dsuiddetails != null && dsuiddetails.Tables.Count > 0 && dsuiddetails.Tables[0].Rows.Count > 0)
                        {
                            txtName_Unit.Text = dsuiddetails.Tables[0].Rows[0]["NameofUnit"].ToString();
                            txtApplciantName.Text = dsuiddetails.Tables[0].Rows[0]["ApplicantName"].ToString();
                            ddlgender.SelectedItem.Text = dsuiddetails.Tables[0].Rows[0]["Gender"].ToString();
                            ddlpride.SelectedItem.Text = dsuiddetails.Tables[0].Rows[0]["Pride"].ToString();
                            ddlsector.SelectedValue = dsuiddetails.Tables[0].Rows[0]["Sector"].ToString();
                            ddlcategory.SelectedValue = dsuiddetails.Tables[0].Rows[0]["IndsCategory"].ToString();
                            rblCaste.SelectedItem.Text = dsuiddetails.Tables[0].Rows[0]["Caste"].ToString();
                            txtDateofCommencement.Text = dsuiddetails.Tables[0].Rows[0]["DateofCommencementNew"].ToString();

                            ddlUnitstate.SelectedValue = "31";
                            ddlUnitstate.Enabled = false;
                            ddlUnitstate_SelectedIndexChanged(sender, e);
                            getdistrictsUnit();
                            ddlUnitDIst.SelectedValue = dsuiddetails.Tables[0].Rows[0]["Distid"].ToString();
                            ddldistrictunit_SelectedIndexChanged(sender, e);
                            ddlUnitMandal.SelectedValue = dsuiddetails.Tables[0].Rows[0]["MandalId"].ToString();
                            ddlUnitMandal_SelectedIndexChanged(sender, e);
                                                       
                            ddlVillageunit.SelectedValue = dsuiddetails.Tables[0].Rows[0]["VillageId"].ToString();
                            txtUnitStreet.Text = dsuiddetails.Tables[0].Rows[0]["Street"].ToString();
                            txtSurveyNo.Text = dsuiddetails.Tables[0].Rows[0]["SurveyNo"].ToString();
                            txtunitmobileno.Text = dsuiddetails.Tables[0].Rows[0]["MobileNo"].ToString();
                            txtunitemailid.Text = dsuiddetails.Tables[0].Rows[0]["EmailId"].ToString();
                            ddlBank.SelectedItem.Text = dsuiddetails.Tables[0].Rows[0]["BankName"].ToString();
                            txtbranchName.Text = dsuiddetails.Tables[0].Rows[0]["BranchName"].ToString();
                            ddlAccountType.SelectedItem.Text = dsuiddetails.Tables[0].Rows[0]["TypeOfAcount"].ToString();
                            txtIFSCCode.Text = dsuiddetails.Tables[0].Rows[0]["IFSCCode"].ToString();
                        }
                    }
                    else
                    {
                        objvo.UidNoInc = "";
                    }
                    objvo.User_Id = Session["uid"].ToString();
                    string uname = Session["username"].ToString();
                    if (!IsPostBack)
                    {
                        //trdipc.Visible = true;
                        DataSet ds = new DataSet();
                        ddlCommittee.SelectedValue = "2";
                        ddlCommittee_SelectedIndexChanged(sender, e);
                        ddlCommittee.Enabled = false;
                        getstatesUnit();
                        ddlUnitstate.SelectedValue = "31";
                        ddlUnitstate.Enabled = false;
                        ddlUnitstate_SelectedIndexChanged(sender, e);

                        BtnClear.Visible = true;
                        getIncentivesMasterList();

                        if (Request.QueryString["IncentiveId"] != null && Request.QueryString["IncentiveId"].ToString() != "")
                        {
                            ddlIncentiveType.SelectedValue = Request.QueryString["IncentiveId"].ToString();
                            ddlIncentiveType.Enabled = false;
                        }
                        ddlIncentiveType_SelectedIndexChanged(sender, e);                        

                        if (Request.QueryString["UnitName"].ToString() != null && Request.QueryString["UnitName"].ToString() != "")
                        {
                            lblunitname.Text = Request.QueryString["UnitName"].ToString();
                        }
                        if (Request.QueryString["Scheme"].ToString() != null && Request.QueryString["Scheme"].ToString() != "")
                        {
                            ddlSchemeName.SelectedValue = Request.QueryString["Scheme"].ToString();
                        }
                        //if (Request.QueryString[9].ToString() != null && Request.QueryString[9].ToString() != "")
                        //{
                        //    objvo.UidNoInc = Request.QueryString[9].ToString();
                        //}
                        //else
                        //{
                        //    objvo.UidNoInc = null;
                        //}
                    }
                }

                dt1 = OneTimeDt();
                Session["OneTime"] = dt1;

                dt2 = RegularDt();
                Session["Regular"] = dt2;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
    }
    protected void txtDateofCommencement_TextChanged(object sender, EventArgs e)
    {
        try
        {
            comFunctions ddd = new comFunctions();
            //DateTime dat = Convert.ToDateTime((txtDateofCommencement.Text).ToString()
            if (txtDateofCommencement.Text != string.Empty)
            {
                DateTime dat = ddd.convertDateIndia(txtDateofCommencement.Text);

                if (dat > DateTime.Now)
                {
                    lblmsg0.Text = "Future Date cannot be selected.";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Future Date cannot be selected');", true);
                    txtDateofCommencement.Text = "";
                    txtDateofCommencement.Focus();
                }
            }
        }
        catch (Exception ex)
        {
            Errors.ErrorLog(ex);
            txtDateofCommencement.Focus();
            lblmsg0.Text = "Please Select Valid Date(dd-MMM-yyyy).";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Select Valid Date(dd-MMM-yyyy)');", true);
        }
    }
    protected void txtDIPCDate_TextChanged(object sender, EventArgs e)
    {
        try
        {
            comFunctions ddd = new comFunctions();
            //DateTime dat = Convert.ToDateTime((txtDateofCommencement.Text).ToString()
            if (txtDIPCDate.Text != string.Empty)
            {
                DateTime dat = ddd.convertDateIndia(txtDIPCDate.Text);

                if (dat > DateTime.Now)
                {
                    lblmsg0.Text = "Future Date cannot be selected.";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Future Date cannot be selected');", true);
                    txtDIPCDate.Text = "";
                    txtDIPCDate.Focus();
                }
            }
        }
        catch (Exception ex)
        {
            Errors.ErrorLog(ex);
            txtDateofCommencement.Focus();
            lblmsg0.Text = "Please Select Valid Date(dd-MMM-yyyy).";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Select Valid Date(dd-MMM-yyyy)');", true);
        }
    }
    protected void txtslcdate_TextChanged(object sender, EventArgs e)
    {
        try
        {
            comFunctions ddd = new comFunctions();
            //DateTime dat = Convert.ToDateTime((txtDateofCommencement.Text).ToString()
            if (txtslcdate.Text != string.Empty)
            {
                DateTime dat = ddd.convertDateIndia(txtslcdate.Text);

                if (dat > DateTime.Now)
                {
                    lblmsg0.Text = "Future Date cannot be selected.";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Future Date cannot be selected');", true);
                    txtslcdate.Text = "";
                    txtslcdate.Focus();
                }
            }
        }
        catch (Exception ex)
        {
            Errors.ErrorLog(ex);
            txtDateofCommencement.Focus();
            lblmsg0.Text = "Please Select Valid Date(dd-MMM-yyyy).";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Select Valid Date(dd-MMM-yyyy)');", true);
        }
    }
    protected void getdistrictsUnit()
    {
        try
        {
            DataSet dsnew = new DataSet();

            dsnew = Gen.GetDistrictsbystate(ddlUnitstate.SelectedValue.ToString());
            ddlUnitDIst.DataSource = dsnew.Tables[0];
            ddlUnitDIst.DataTextField = "District_Name";
            ddlUnitDIst.DataValueField = "District_Id";
            ddlUnitDIst.DataBind();
            ddlUnitDIst.Items.Insert(0, "--Select--");
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }

    }
    public void getstatesUnit()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = Gen.getStates();

            ddlUnitstate.DataSource = ds.Tables[0];
            ddlUnitstate.DataTextField = "State_Name";
            ddlUnitstate.DataValueField = "State_id";
            ddlUnitstate.DataBind();
            ddlUnitstate.Items.Insert(0, "--Select--");
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    public void Getmandalsunit()
    {
        try
        {
            ddlUnitMandal.Items.Clear();
            DataSet dsm = new DataSet();
            dsm = Gen.GetMandals(ddlUnitDIst.SelectedValue);
            if (dsm.Tables[0].Rows.Count > 0)
            {
                ddlUnitMandal.DataSource = dsm.Tables[0];
                ddlUnitMandal.DataValueField = "Mandal_Id";
                ddlUnitMandal.DataTextField = "Manda_lName";
                ddlUnitMandal.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    public void Getvillagesunit()
    {
        try
        {
            if (ddlUnitMandal.SelectedIndex == 0)
            {
                ddlVillageunit.Items.Clear();
                ddlVillageunit.Items.Insert(0, "--Village--");
            }
            else
            {
                ddlVillageunit.Items.Clear();
                DataSet dsv = new DataSet();
                dsv = Gen.GetVillages(ddlUnitMandal.SelectedValue);
                if (dsv.Tables[0].Rows.Count > 0)
                {
                    ddlVillageunit.DataSource = dsv.Tables[0];
                    ddlVillageunit.DataValueField = "Village_Id";
                    ddlVillageunit.DataTextField = "Village_Name";
                    ddlVillageunit.DataBind();
                }
                else
                {
                    ddlVillageunit.Items.Clear();
                    ddlVillageunit.Items.Insert(0, "--Village--");
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void ddlUnitstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlUnitstate.SelectedValue.ToString() != "--Select--")
            {
                getdistrictsUnit();

                ddlUnitDIst.Visible = true;
                ddlUnitMandal.Visible = true;
                ddlVillageunit.Visible = true;
            }
            else
            {
                ddlUnitstate.Items.Clear();
                ddlUnitstate.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void ddldistrictunit_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet dsm = new DataSet();
            dsm = Gen.GetMandals(ddlUnitDIst.SelectedValue);
            if (dsm.Tables[0].Rows.Count > 0)
            {
                ddlUnitMandal.DataSource = dsm.Tables[0];
                ddlUnitMandal.DataValueField = "Mandal_Id";
                ddlUnitMandal.DataTextField = "Manda_lName";
                ddlUnitMandal.DataBind();
                ddlUnitMandal.Items.Insert(0, "--Mandal--");
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void ddlUnitMandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlVillageunit.Items.Clear();
            DataSet dsv = new DataSet();
            dsv = Gen.GetVillages(ddlUnitMandal.SelectedValue);
            if (dsv.Tables[0].Rows.Count > 0)
            {
                ddlVillageunit.DataSource = dsv.Tables[0];
                ddlVillageunit.DataValueField = "Village_Id";
                ddlVillageunit.DataTextField = "Village_Name";
                ddlVillageunit.DataBind();
                ddlVillageunit.Items.Insert(0, "--Village--");
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    public void getIncentivesMasterList()
    {
        try
        {
            DataSet dsgrid = new DataSet();
            dsgrid = Gen.getIncentivesMasterList();
            if (dsgrid != null && dsgrid.Tables.Count > 0 && dsgrid.Tables[0].Rows.Count > 0)
            {
                ddlIncentiveType.DataSource = dsgrid.Tables[0];
                ddlIncentiveType.DataValueField = "IncentiveID";
                ddlIncentiveType.DataTextField = "IncentiveName";
                ddlIncentiveType.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    public void getIncentiveNamebyId(string incentiveid)
    {
        try
        {
            DataSet dsgrid = new DataSet();
            //gvincentivedtls.DataSource = null;
            //gvincentivedtls.DataBind();
            dsgrid = Gen.getIncentiveNamebyID(incentiveid);
            if (dsgrid != null && dsgrid.Tables.Count > 0 && dsgrid.Tables[0].Rows.Count > 0)
            {
                //gvincentivedtls.DataSource = dsgrid.Tables[0];
                //gvincentivedtls.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void ddlCommittee_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCommittee.SelectedValue == "1")
            {
                trdipc.Visible = true;
                trslc.Visible = false;
                txtDIPCNo.Text = "";
                txtDIPCDate.Text = "";
                txtslcNo.Text = "";
                txtslcdate.Text = "";
                lblds.Text = "DIPC";
            }
            else if (ddlCommittee.SelectedValue == "2")
            {
                trslc.Visible = true;
                trdipc.Visible = false;
                txtDIPCNo.Text = "";
                txtDIPCDate.Text = "";
                txtslcNo.Text = "";
                txtslcdate.Text = "";
                lblds.Text = "SLC";

                if (Request.QueryString["SLCNumber"].ToString() != null && Request.QueryString["SLCNumber"].ToString() != "")
                {
                    txtslcNo.Text = Request.QueryString["SLCNumber"].ToString();
                }
                //if (Request.QueryString[5].ToString() != null && Request.QueryString[5].ToString() != "")
                //{
                //    txtslcdate.Text = Request.QueryString[5].ToString();
                //}

            }
            else
            {
                trslc.Visible = false;
                trdipc.Visible = false;
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    public void AssignValuestoVosFromcontrols()
    {
        try
        {
            if (Session["UIDNO"] != null && Session["UIDNO"].ToString() != "")
            {
                objvo.UidNoInc = Session["UIDNO"].ToString();
            }
            else
            {
                objvo.UidNoInc = "";
            }
            objvo.User_Id = Session["uid"].ToString();
            objvo.UnitName = txtName_Unit.Text.ToUpper();
            objvo.ApplciantName = txtApplciantName.Text.ToUpper();

            objvo.UnitStateId = ddlUnitstate.SelectedValue;
            objvo.UnitDIstId = ddlUnitDIst.SelectedValue;
            objvo.UnitMandalId = ddlUnitMandal.SelectedValue;
            objvo.UnitVillId = ddlVillageunit.SelectedValue;

            objvo.UnitState = ddlUnitstate.SelectedItem.Text;
            objvo.UnitDIst = ddlUnitDIst.SelectedItem.Text;
            objvo.UnitMandal = ddlUnitMandal.SelectedItem.Text;
            objvo.UnitVill = ddlVillageunit.SelectedItem.Text;

            objvo.UnitHNO = txtSurveyNo.Text.ToUpper();
            objvo.UnitStreet = txtUnitStreet.Text.ToUpper();
            objvo.SocialStatus = rblCaste.SelectedItem.Text;
            objvo.SCHEMEName = ddlSchemeName.SelectedItem.Text;
            objvo.Committee = ddlCommittee.SelectedItem.Text;
            objvo.Status = "Y";
            objvo.Remarks = txtremarks.Text;
            objvo.Pride = ddlpride.SelectedItem.Text;

            objvo.Sector = ddlsector.SelectedValue;
            objvo.Gender = ddlgender.SelectedItem.Text;
            objvo.Category = ddlcategory.SelectedValue;
            objvo.BankName = ddlBank.SelectedItem.Text;
            objvo.TypeOfAccount = ddlAccountType.SelectedItem.Text;
            objvo.IFSCCode = txtIFSCCode.Text;

            string[] Ld4 = null;
            string ConvertedDt7 = "";

            string[] Ld3 = null;
            string ConvertedDt6 = "";

            if (ddlCommittee.SelectedValue == "1")
            {
                objvo.DIPCNO = txtDIPCNo.Text;
                if (txtDIPCDate.Text != "")
                {
                    Ld4 = txtDIPCDate.Text.Split('/');
                    ConvertedDt7 = Ld4[1].ToString() + "/" + Ld4[0].ToString() + "/" + Ld4[2].ToString();

                    objvo.DIPCDate = ConvertedDt7;
                }
                else
                {
                    objvo.DIPCDate = "01/01/1900";
                }

            }
            else
            {
                objvo.SLCNO = txtslcNo.Text;
                if (txtslcdate.Text != "")
                {
                    Ld3 = txtslcdate.Text.Split('/');
                    ConvertedDt6 = Ld3[1].ToString() + "/" + Ld3[0].ToString() + "/" + Ld3[2].ToString();

                    objvo.SLCDate = ConvertedDt6;
                }
                else
                {
                    objvo.SLCDate = "01/01/1900";
                }
            }


            string[] Ld2 = null;
            string ConvertedDt5 = "";

            if (txtDateofCommencement.Text != "")
            {
                Ld2 = txtDateofCommencement.Text.Split('/');
                ConvertedDt5 = Ld2[1].ToString() + "/" + Ld2[0].ToString() + "/" + Ld2[2].ToString();

                objvo.DateOfComm = ConvertedDt5;
            }
            else
            {
                objvo.DateOfComm = "01/01/1900";
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    public void BindBankAccountType()
    {
        DataSet ds = new DataSet();
        ds = Gen.getBankAccountTypeMaster();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlAccountType.DataSource = ds.Tables[0];
            ddlAccountType.DataTextField = "AccountTypeName";
            ddlAccountType.DataValueField = "AccountTypeID";
            ddlAccountType.DataBind();

            ddlAccountType.Items.Insert(0, "--Select--");
        }
    }
    protected void ddlIncentiveType_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvincentivedtls.DataSource = null;
        gvincentivedtls.DataBind();
        gvincentivedtlsRep.DataSource = null;
        gvincentivedtlsRep.DataBind();

        DataSet dsgrid = new DataSet();
        try
        {
            dsgrid = Gen.getIncentiveNamebyID(ddlIncentiveType.SelectedValue);

            if (dsgrid != null && dsgrid.Tables.Count > 0 && dsgrid.Tables[0].Rows.Count > 0)
            {
                if (dsgrid.Tables[0].Rows[0]["Incentive_Type"].ToString() == "2")
                {
                    trinc1.Visible = true;
                    trinc2.Visible = false;
                    BindFinancialYears(ddlFinYear1, "10", "");

                    if (Request.QueryString["FinYear"].ToString() != null && Request.QueryString["FinYear"].ToString() != "")
                    {
                        ddlFinYear1.SelectedItem.Text = Request.QueryString["FinYear"].ToString();
                    }
                    if (Request.QueryString["SanctionedAmount"].ToString() != null && Request.QueryString["SanctionedAmount"].ToString() != "")
                    {
                        txtsanctionAmount.Text = Request.QueryString["SanctionedAmount"].ToString();
                        txtRecommendedAmount.Text = Request.QueryString["SanctionedAmount"].ToString();
                    }
                    if (Request.QueryString["SanctionedDate"].ToString() != null && Request.QueryString["SanctionedDate"].ToString() != "")
                    {
                        txtsanctionDate.Text = Request.QueryString["SanctionedDate"].ToString();
                    }
                    if (Request.QueryString["SanctionSLNo"].ToString() != null && Request.QueryString["SanctionSLNo"].ToString() != "")
                    {
                        txtSeriatumNo.Text = Request.QueryString["SanctionSLNo"].ToString();
                    }
                }
                else if (dsgrid.Tables[0].Rows[0]["Incentive_Type"].ToString() == "3")
                {
                    trinc1.Visible = false;
                    trinc2.Visible = true;
                    BindFinancialYears(ddlFinYear2, "10", "");

                    if (Request.QueryString["FinYear"].ToString() != null && Request.QueryString["FinYear"].ToString() != "")
                    {
                        ddlFinYear2.SelectedItem.Text = Request.QueryString["FinYear"].ToString();
                    }
                    if (Request.QueryString["SanctionedAmount"].ToString() != null && Request.QueryString["SanctionedAmount"].ToString() != "")
                    {
                        txtsanctionAmount2.Text = Request.QueryString["SanctionedAmount"].ToString();
                        txtRecommendedAmount2.Text = Request.QueryString["SanctionedAmount"].ToString();
                    }
                    if (Request.QueryString["SanctionedDate"].ToString() != null && Request.QueryString["SanctionedDate"].ToString() != "")
                    {
                        txtsanctionDate2.Text = Request.QueryString["SanctionedDate"].ToString();
                    }
                    if (Request.QueryString["SanctionSLNo"].ToString() != null && Request.QueryString["SanctionSLNo"].ToString() != "")
                    {
                        txtSeriatumNo2.Text = Request.QueryString["SanctionSLNo"].ToString();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    private void BindFinancialYears(DropDownList ddl, string Count, string incentiveid)
    {
        PCBClass objPCB = new PCBClass();
        comFunctions cmf = new comFunctions();
        General Gen = new General();
        DataSet dsYears = new DataSet();

        dsYears = Gen.GetFinYearsDIPCScreen(Count);
        if (dsYears != null && dsYears.Tables.Count > 0 && dsYears.Tables[0].Rows.Count > 0)
        {
            ddl.DataSource = dsYears.Tables[0];
            ddl.DataTextField = "FinancialYear";
            ddl.DataValueField = "SlNo";
            ddl.DataBind();
        }
        ddl.Items.Insert(0, "--Select--");

    }

    protected void btnAdd1_Click(object sender, EventArgs e)
    {
        int valid = 0;
        try
        {
            if (ddlFinYear1.SelectedItem.Text == "--Select--")
            {
                //lblmsg0.Text = "Please Select Financial Year" + "<br/>";
                //Failure.Visible = true;
                string message = "alert('Please Select Financial Year')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                ddlFinYear1.Focus();
                valid = 1;
            }
            if (txtRecommendedAmount.Text == "" || txtRecommendedAmount.Text == null)
            {
                //lblmsg0.Text = "Please Enter Final Recommended Amount (in Rs.)" + "<br/>";
                //Failure.Visible = true;
                string message = "alert('Please Enter Final Recommended Amount (in Rs.)')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                txtRecommendedAmount.Focus();
                valid = 1;
            }
            if (txtsanctionAmount.Text == "" || txtsanctionAmount.Text == null)
            {
                //lblmsg0.Text = "Please Enter Sanctioned Amount (in Rs)" + "<br/>";
                //Failure.Visible = true;
                string message = "alert('Please Enter Sanctioned Amount (in Rs)')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                txtsanctionAmount.Focus();
                valid = 1;
            }
            if (txtsanctionDate.Text == "" || txtsanctionDate.Text == null)
            {
                //lblmsg0.Text = "Please Select Sanctioned Date" + "<br/>";
                //Failure.Visible = true;
                string message = "alert('Please Select Sanctioned Date')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                txtsanctionDate.Focus();
                valid = 1;
            }
            if (txtSeriatumNo.Text == "" || txtSeriatumNo.Text == null)
            {
                //lblmsg0.Text = "Please Enter Seriatum No." + "<br/>";
                //Failure.Visible = true;
                string message = "alert('Please Enter Seriatum No.')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                txtSeriatumNo.Focus();
                valid = 1;
            }

            if (valid == 0)
            {
                AddDataToOneTime(ddlIncentiveType.SelectedItem.Text, ddlFinYear1.SelectedItem.Text, txtRecommendedAmount.Text, txtsanctionAmount.Text, txtsanctionDate.Text, txtSeriatumNo.Text, "", (DataTable)Session["OneTime"]);

                this.gvincentivedtls.DataSource = ((DataTable)Session["OneTime"]).DefaultView;
                this.gvincentivedtls.DataBind();

                //ddlIncentiveType.SelectedValue = "--Select--";
                //ddlFinYear1.SelectedValue = "--Select--";
                txtRecommendedAmount.Text = "";
                txtsanctionAmount.Text = "";
                txtsanctionDate.Text = "";
                txtSeriatumNo.Text = "";
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void gvincentivedtls_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = new DataTable();
        try
        {
            if (Session["OneTime"] != null)
            {
                dt = (DataTable)Session["OneTime"];
                if (dt.Rows.Count > 0)
                {
                    ((DataTable)Session["OneTime"]).Rows.RemoveAt(e.RowIndex);

                    this.gvincentivedtls.DataSource = ((DataTable)Session["OneTime"]).DefaultView;
                    this.gvincentivedtls.DataBind();
                }
                else
                {
                    this.gvincentivedtls.DataSource = null;
                    this.gvincentivedtls.DataBind();
                }
            }
            else
            {
                this.gvincentivedtls.DataSource = null;
                this.gvincentivedtls.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void gvincentivedtls_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void btnAdd2_Click(object sender, EventArgs e)
    {
        int valid = 0;
        try
        {
            if (ddlFinYear2.SelectedItem.Text == "--Select--")
            {
                //lblmsg0.Text = "Please Select Financial Year" + "<br/>";
                //Failure.Visible = true;
                string message = "alert('Please Select Financial Year')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                ddlFinYear1.Focus();
                valid = 1;
            }
            if (ddlFinHalfYear.SelectedItem.Text == "--Select--")
            {
                //lblmsg0.Text = "Please Select 1stHalf/2ndHalf" + "<br/>";
                //Failure.Visible = true;
                string message = "alert('Please Select 1stHalf/2ndHalf')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                ddlFinHalfYear.Focus();
                valid = 1;
            }
            if (txtRecommendedAmount2.Text == "" || txtRecommendedAmount2.Text == null)
            {
                //lblmsg0.Text = "Please Enter Final Recommended Amount (in Rs.)" + "<br/>";
                //Failure.Visible = true;
                string message = "alert('Please Enter Final Recommended Amount (in Rs.)')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                txtRecommendedAmount2.Focus();
                valid = 1;
            }
            if (txtsanctionAmount2.Text == "" || txtsanctionAmount2.Text == null)
            {
                //lblmsg0.Text = "Please Enter Sanctioned Amount (in Rs)" + "<br/>";
                //Failure.Visible = true;
                string message = "alert('Please Enter Sanctioned Amount (in Rs)')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                txtsanctionAmount2.Focus();
                valid = 1;
            }
            if (txtsanctionDate2.Text == "" || txtsanctionDate2.Text == null)
            {
                //lblmsg0.Text = "Please Select Sanctioned Date" + "<br/>";
                //Failure.Visible = true;
                string message = "alert('Please Select Sanctioned Date')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                txtsanctionDate2.Focus();
                valid = 1;
            }
            if (txtSeriatumNo2.Text == "" || txtSeriatumNo2.Text == null)
            {
                //lblmsg0.Text = "Please Enter Seriatum No." + "<br/>";
                //Failure.Visible = true;
                string message = "alert('Please Enter Seriatum No.')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                txtSeriatumNo2.Focus();
                valid = 1;
            }

            if (valid == 0)
            {
                AddDataToRegular(ddlIncentiveType.SelectedItem.Text, ddlFinYear2.SelectedItem.Text, ddlFinHalfYear.SelectedItem.Text, txtRecommendedAmount2.Text, txtsanctionAmount2.Text, txtsanctionDate2.Text, txtSeriatumNo2.Text, "", (DataTable)Session["Regular"]);

                this.gvincentivedtlsRep.DataSource = ((DataTable)Session["Regular"]).DefaultView;
                this.gvincentivedtlsRep.DataBind();

                //ddlIncentiveType.SelectedValue = "--Select--";
                //ddlFinYear2.SelectedValue = "--Select--";
                //ddlFinHalfYear.SelectedItem.Text = "--Select--";
                txtRecommendedAmount2.Text = "";
                txtsanctionAmount2.Text = "";
                txtsanctionDate2.Text = "";
                txtSeriatumNo2.Text = "";
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void gvincentivedtlsRep_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = new DataTable();
        try
        {
            if (Session["Regular"] != null)
            {
                dt = (DataTable)Session["Regular"];
                if (dt.Rows.Count > 0)
                {
                    ((DataTable)Session["Regular"]).Rows.RemoveAt(e.RowIndex);

                    this.gvincentivedtlsRep.DataSource = ((DataTable)Session["Regular"]).DefaultView;
                    this.gvincentivedtlsRep.DataBind();
                }
                else
                {
                    this.gvincentivedtlsRep.DataSource = null;
                    this.gvincentivedtlsRep.DataBind();
                }
            }
            else
            {
                this.gvincentivedtlsRep.DataSource = null;
                this.gvincentivedtlsRep.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void gvincentivedtlsRep_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected DataTable OneTimeDt()
    {
        dt1 = new DataTable("OneTime");

        dt1.Columns.Add("new", typeof(string));
        dt1.Columns.Add("IncentiveType", typeof(string));
        dt1.Columns.Add("FinancialYear", typeof(string));
        dt1.Columns.Add("RecommendedAmount", typeof(string));
        dt1.Columns.Add("SanctionedAmount", typeof(string));
        dt1.Columns.Add("SanctionedDate", typeof(string));
        dt1.Columns.Add("SeriatumNo", typeof(string));
        dt1.Columns.Add("IncentiveId", typeof(string));
        dt1.Columns.Add("Created_by", typeof(string));

        dt1.Columns.Add("intLineofActivityMid", typeof(string));

        return dt1;
    }
    private void AddDataToOneTime(string IncentiveType, string FinancialYear, string RecommendedAmount, string SanctionedAmount, string SanctionedDate, string SeriatumNo, string IncentiveId, DataTable myTable)
    {
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dt1 = new DataTable("OneTime");

            Row["new"] = "0";
            Row["IncentiveType"] = IncentiveType;
            Row["FinancialYear"] = FinancialYear;
            Row["RecommendedAmount"] = RecommendedAmount;
            Row["SanctionedAmount"] = SanctionedAmount;
            Row["SanctionedDate"] = SanctionedDate;
            Row["SeriatumNo"] = SeriatumNo;
            Row["IncentiveId"] = IncentiveId;
            Row["Created_by"] = Session["uid"].ToString().Trim();

            Row["intLineofActivityMid"] = "0";

            myTable.Rows.Add(Row);
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected DataTable RegularDt()
    {
        dt2 = new DataTable("Regular");

        dt2.Columns.Add("new", typeof(string));
        dt2.Columns.Add("IncentiveType", typeof(string));
        dt2.Columns.Add("FinancialYear", typeof(string));
        dt2.Columns.Add("1stHalf2ndHalf", typeof(string));
        //dt2.Columns.Add("RecommendedAmount", typeof(string));
        //dt2.Columns.Add("SanctionedAmount", typeof(string));
        dt2.Columns.Add("RecommendedAmount", typeof(decimal));
        dt2.Columns.Add("SanctionedAmount", typeof(decimal));
        dt2.Columns.Add("SanctionedDate", typeof(string));
        dt2.Columns.Add("SeriatumNo", typeof(string));
        dt2.Columns.Add("IncentiveId", typeof(string));
        dt2.Columns.Add("Created_by", typeof(string));

        dt2.Columns.Add("intLineofActivityMid", typeof(string));

        return dt2;
    }
    private void AddDataToRegular(string IncentiveType, string FinancialYear, string fstHalf2ndHalf, string RecommendedAmount, string SanctionedAmount, string SanctionedDate, string SeriatumNo, string IncentiveId, DataTable myTable)
    {
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dt1 = new DataTable("Regular");

            Row["new"] = "0";
            Row["IncentiveType"] = IncentiveType;
            Row["FinancialYear"] = FinancialYear;
            Row["1stHalf2ndHalf"] = fstHalf2ndHalf;
            Row["RecommendedAmount"] = RecommendedAmount;
            Row["SanctionedAmount"] = SanctionedAmount;
            Row["SanctionedDate"] = SanctionedDate;
            Row["SeriatumNo"] = SeriatumNo;
            Row["IncentiveId"] = IncentiveId;
            Row["Created_by"] = Session["uid"].ToString().Trim();

            Row["intLineofActivityMid"] = "0";

            myTable.Rows.Add(Row);
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void btnClear1_Click(object sender, EventArgs e)
    {
        try
        {
            txtRecommendedAmount.Text = "";
            txtsanctionAmount.Text = "";
            txtsanctionDate.Text = "";
            txtSeriatumNo.Text = "";
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void btnClear2_Click(object sender, EventArgs e)
    {
        try
        {
            //ddlFinHalfYear.SelectedItem.Text = "--Select--";
            txtRecommendedAmount2.Text = "";
            txtsanctionAmount2.Text = "";
            txtsanctionDate2.Text = "";
            txtSeriatumNo2.Text = "";
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        string output = "";
        Failure.Visible = false;
        int valid = 0;
        try
        {
            if (rblCaste.SelectedItem.Text.Contains("--"))
            {
                lblmsg0.Text = "Please select Social Status";
                Failure.Visible = true;
                valid = 1;
                lblmsg0.Focus();
            }
            if (valid == 0)
            {
                AssignValuestoVosFromcontrols();

                if (gvincentivedtls.Rows.Count > 0)
                {
                    for (int i = 0; i < gvincentivedtls.Rows.Count; i++)
                    {
                        string incentiveID = ddlIncentiveType.SelectedValue;
                        string incentiveType = ddlIncentiveType.SelectedItem.Text;
                        string financialYear = gvincentivedtls.Rows[i].Cells[2].Text;

                        decimal recommendedAnount = Math.Round(Convert.ToDecimal(gvincentivedtls.Rows[i].Cells[3].Text), 2);
                        decimal sanctionAmount = Math.Round(Convert.ToDecimal(gvincentivedtls.Rows[i].Cells[4].Text), 2);

                        string sanctionDate = gvincentivedtls.Rows[i].Cells[5].Text;
                        string SeriatumNo = gvincentivedtls.Rows[i].Cells[6].Text;

                        objvo.incentiveTypeID = incentiveID;
                        objvo.incentiveTypename = incentiveType;
                        objvo.financialyear = financialYear;

                        objvo.SeriatumNo = SeriatumNo;

                        objvo.recommendedAnount = recommendedAnount;
                        objvo.sanctionAmount = sanctionAmount;

                        string[] sanctionDateSplit = null;
                        string ConvertedDt6 = "";

                        if (sanctionDate != "")
                        {
                            sanctionDateSplit = sanctionDate.Split('/');
                            ConvertedDt6 = sanctionDateSplit[1].ToString() + "/" + sanctionDateSplit[0].ToString() + "/" + sanctionDateSplit[2].ToString();
                            objvo.sanctionDate = ConvertedDt6;
                        }

                        if (ddlCommittee.SelectedValue == "1")
                        {
                            output = Gen.InsertCOIDIPCDetails(objvo);
                        }
                        else
                        {
                            output = Gen.InsertCOISLCDetails(objvo);
                        }

                        if (output == "1")
                        {
                            lblmsg.Text = "Successfully Submitted";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Successfully Submitted');", true);
                            lblmsg.Focus();

                        }
                        else if (output == "2")
                        {
                            lblmsg.Text = "Details Already Exists";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Details Already Exists');", true);
                            lblmsg.Focus();
                        }
                    }
                }
                if (gvincentivedtlsRep.Rows.Count > 0)
                {
                    for (int i = 0; i < gvincentivedtlsRep.Rows.Count; i++)
                    {
                        string incentiveID = ddlIncentiveType.SelectedValue;
                        string incentiveType = ddlIncentiveType.SelectedItem.Text;
                        string financialYear = gvincentivedtlsRep.Rows[i].Cells[2].Text;
                        string FinHalfYear = gvincentivedtlsRep.Rows[i].Cells[3].Text;

                        decimal recommendedAnount = Math.Round(Convert.ToDecimal(gvincentivedtlsRep.Rows[i].Cells[4].Text), 2);
                        decimal sanctionAmount = Math.Round(Convert.ToDecimal(gvincentivedtlsRep.Rows[i].Cells[5].Text), 2);

                        string sanctionDate = gvincentivedtlsRep.Rows[i].Cells[6].Text;
                        string SeriatumNo = gvincentivedtlsRep.Rows[i].Cells[7].Text;

                        objvo.incentiveTypeID = incentiveID;
                        objvo.incentiveTypename = incentiveType;
                        objvo.financialyear = financialYear;
                        objvo.SeriatumNo = SeriatumNo;
                        objvo.recommendedAnount = recommendedAnount;
                        objvo.sanctionAmount = sanctionAmount;
                        objvo.FinHalfYear = FinHalfYear;

                        string[] sanctionDateSplit = null;
                        string ConvertedDt6 = "";

                        if (sanctionDate != "")
                        {
                            sanctionDateSplit = sanctionDate.Split('/');
                            ConvertedDt6 = sanctionDateSplit[1].ToString() + "/" + sanctionDateSplit[0].ToString() + "/" + sanctionDateSplit[2].ToString();
                            objvo.sanctionDate = ConvertedDt6;
                        }

                        if (ddlCommittee.SelectedValue == "1")
                        {
                            output = Gen.InsertCOIDIPCDetails(objvo);
                        }
                        else
                        {
                            output = Gen.InsertCOISLCDetails(objvo);
                        }

                        if (output == "1")
                        {
                            lblmsg.Text = "Successfully Submitted";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Successfully Submitted');", true);
                            lblmsg.Focus();
                        }
                        else if (output == "2")
                        {
                            lblmsg.Text = "Details Already Exists";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Details Already Exists');", true);
                            lblmsg.Focus();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
}