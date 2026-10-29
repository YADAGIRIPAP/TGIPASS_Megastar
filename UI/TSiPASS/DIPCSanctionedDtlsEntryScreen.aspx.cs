using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;

public partial class UI_TSiPASS_DIPCSanctionedDtlsEntryScreen : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    Fetch objFetch = new Fetch();
    IncentivesVOs objvo = new IncentivesVOs();
    IncentiveVosA objvoA = new IncentiveVosA();
    comFunctions objCmf = new comFunctions();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Session["uid"] != null)
                {
                    objvo.User_Id = Session["uid"].ToString();
                    string uname = Session["username"].ToString();
                    if (!IsPostBack)
                    {
                        //trdipc.Visible = true;
                        DataSet ds = new DataSet();
                        getstatesUnit();
                        ddlUnitstate.SelectedValue = "31";
                        ddlUnitstate.Enabled = false;

                        ddlUnitstate_SelectedIndexChanged(sender, e);
                        //ddlCommittee.SelectedValue = "1"; 
                        //ddlCommittee_SelectedIndexChanged(sender, e);

                        BtnClear.Visible = true;
                        getIncentivesMasterList();

                        BindBankAccountType();
                        objCmf.BindCtlto(true, ddlBank, objFetch.FetchBankMst(), 1, 0, false);
                        objCmf.BindCtlto(true, ddlcategory, objFetch.FetchCategory(), 1, 0, false);
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
            gvincentivedtls.DataSource = null;
            gvincentivedtls.DataBind();

            DataSet dsgrid = new DataSet();
            dsgrid = Gen.getIncentivesMasterList();
            if (dsgrid != null && dsgrid.Tables.Count > 0 && dsgrid.Tables[0].Rows.Count > 0)
            {
                gvincentivedtls.DataSource = dsgrid.Tables[0];
                gvincentivedtls.DataBind();
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
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        string output = "";
        try
        {
            AssignValuestoVosFromcontrols();

            for (int i = 0; i < gvincentivedtls.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gvincentivedtls.Rows[i].FindControl("ChkSelect");

                if (chk.Checked)
                {
                    Label lblincentiveType = (Label)gvincentivedtls.Rows[i].FindControl("lblincentiveType");
                    Label lblincentiveID = (Label)gvincentivedtls.Rows[i].FindControl("lblincentiveID");
                    TextBox txtrecommendedAnount = (TextBox)gvincentivedtls.Rows[i].FindControl("txtrecommendedAnount");
                    TextBox txtsanctionAmount = (TextBox)gvincentivedtls.Rows[i].FindControl("txtsanctionAmount");
                    TextBox txtsanctionDate = (TextBox)gvincentivedtls.Rows[i].FindControl("txtsanctionDate");

                    objvo.incentiveTypeID = lblincentiveID.Text;
                    objvo.incentiveTypename = lblincentiveType.Text;
                    objvo.recommendedAnount =Convert.ToDecimal( txtrecommendedAnount.Text);
                    objvo.sanctionAmount = Convert.ToDecimal( txtsanctionAmount.Text);

                    string[] sanctionDateSplit = null;
                    string ConvertedDt6 = "";

                    if (txtsanctionDate.Text != "")
                    {
                        sanctionDateSplit = txtsanctionDate.Text.Split('/');
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
                        //success.Visible = true;
                        lblmsg.Focus();
                    }
                    else if (output == "2")
                    {
                        lblmsg.Text = "Details Already Exists";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Details Already Exists');", true);
                        //success.Visible = true;
                        lblmsg.Focus();
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
            objvo.User_Id = Session["uid"].ToString();
            objvo.UnitName = txtName_Unit.Text.ToUpper();
            objvo.ApplciantName = txtApplciantName.Text.ToUpper();
            //objvo.UnitState = ddlUnitstate.SelectedValue;
            //objvo.UnitDIst = ddlUnitDIst.SelectedValue;
            //objvo.UnitMandal = ddlUnitMandal.SelectedValue;
            //objvo.UnitVill = ddlVillageunit.SelectedValue;

            objvo.UnitState = ddlUnitstate.SelectedItem.Text.ToString();
            objvo.UnitDIst = ddlUnitDIst.SelectedItem.Text.ToString();
            objvo.UnitMandal = ddlUnitMandal.SelectedItem.Text.ToString();
            objvo.UnitVill = ddlVillageunit.SelectedItem.Text.ToString();

            objvo.UnitHNO = txtSurveyNo.Text.ToUpper();
            objvo.UnitStreet = txtUnitStreet.Text.ToUpper();
            objvo.SocialStatus = rblCaste.SelectedItem.Text.ToString();
            objvo.SCHEMEName = ddlSchemeName.SelectedItem.Text;
            objvo.Committee = ddlCommittee.SelectedItem.Text;
            objvo.Status = "Y";
            objvo.Remarks = "";
            objvo.IsDifferentlyAbled = rdl_isph.SelectedValue;

            objvo.Sector = ddlsector.SelectedValue;
            objvo.Gender = ddlgender.SelectedItem.Text.ToString();
            objvo.Category = ddlcategory.SelectedValue;
            objvo.BankName = ddlBank.SelectedItem.Text.ToString();
            objvo.TypeOfAccount = ddlAccountType.SelectedValue;
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
            throw ex;
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
        }
    }
}