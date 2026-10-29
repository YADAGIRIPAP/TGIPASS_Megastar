using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Net;
using System.Threading;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;



public partial class UI_TSiPASS_districtreforms : System.Web.UI.Page
{
    General Gen = new General();
    CommonBL objcommon = new CommonBL();
    DataSet dsdorg = new DataSet();
    Fetch objFetch = new Fetch();
    DistrictReform objvo = new DistrictReform();
    string ApprovalId;
    string deptId;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count > 0)
        {
            if (Request.QueryString[0].ToString() != "")
            {
                ApprovalId = Request.QueryString["ApprovalId"].ToString();
                deptId = Request.QueryString["deptId"].ToString();
                if (deptId == "412")
                {
                    trcommissionerates.Visible = true;
                }
                else
                {
                    trcommissionerates.Visible = false;
                }
            }
        }

        if (!IsPostBack)
        {
            MainView.ActiveViewIndex = 0;
            getstatesUnit();
            getstatesOffc();
            getUdyogAadharType();
            BindConstitutionUnit();
            BindCommissionerates();
        }


    }

    void getstatesOffc()
    {
        DataSet ds = new DataSet();
        ds = Gen.getStates();

        ddloffcstate.DataSource = ds.Tables[0];
        ddloffcstate.DataTextField = "State_Name";
        ddloffcstate.DataValueField = "State_id";
        ddloffcstate.DataBind();
        //ddloffcstate.Items.Insert(0, "--Select--");
        AddSelect(ddloffcstate);
    }

    void getstatesUnit()
    {
        DataSet ds = new DataSet();
        ds = Gen.getStates();

        ddlUnitstate.DataSource = ds.Tables[0];
        ddlUnitstate.DataTextField = "State_Name";
        ddlUnitstate.DataValueField = "State_id";
        ddlUnitstate.DataBind();
        // ddlUnitstate.Items.Insert(0, "--Select--");
        AddSelect(ddlUnitstate);
    }

    void getUdyogAadharType()
    {
        DataSet ds = new DataSet();
        ds = Gen.getUdyogAadharType();

        ddlUdyogAadharType.DataSource = ds.Tables[0];
        ddlUdyogAadharType.DataTextField = "Name";
        ddlUdyogAadharType.DataValueField = "Slno";
        ddlUdyogAadharType.DataBind();
        AddSelect(ddlUdyogAadharType);
        // ddlUdyogAadharType.Items.Insert(0, "-- Select Udyog Aadhar/EM/IEM/IL/EOU No --");
    }

    protected void rblSector_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlintLineofActivity.Visible = true;
            txtBussinessActivity.Visible = false;
            // rblVeh.Items[0].Enabled = false;

            if (rblSector.SelectedValue != "1")  // Not manufacture
            {
                trrblVeh.Visible = false;
                trvehicleno.Visible = false;
                txtregistrationno.Text = "";
            }
            else if (rblSector.SelectedValue == "1")
            {
                if (rblCaste.SelectedItem.Text.ToUpper() != "SELECT")
                {
                    if (rblCaste.SelectedValue == "3" || rblCaste.SelectedValue == "4" || cbDiffAbled.Checked == true)
                    {
                        trrblVeh.Visible = true;
                        trvehicleno.Visible = true;
                        rblVeh_SelectedIndexChanged(sender, e);
                    }
                    else
                    {
                        trrblVeh.Visible = true;
                        trvehicleno.Visible = false;
                        txtregistrationno.Text = "";
                        rblVeh_SelectedIndexChanged(sender, e);
                    }
                }
            }
        }

        catch (Exception ex) { Errors.ErrorLog(ex); }
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
        }
    }

    protected void ddldistrictunit_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlUnitDIst.SelectedIndex == 0)
        {
            ddlUnitMandal.Items.Clear();
            // ddlUnitMandal.Items.Insert(0, "--Mandal--");
            AddSelect(ddlUnitMandal);
        }
        else
        {
            ddlUnitMandal.Items.Clear();
            DataSet dsm = new DataSet();
            // added newly for testing only

            //if (ddlUnitDIst.SelectedValue == "Medchal")
            //{
            //    ddlUnitDIst.SelectedValue = "20";
            //}

            dsm = Gen.GetMandals(ddlUnitDIst.SelectedValue);
            if (dsm.Tables[0].Rows.Count > 0)
            {
                ddlUnitMandal.DataSource = dsm.Tables[0];
                ddlUnitMandal.DataValueField = "Mandal_Id";
                ddlUnitMandal.DataTextField = "Manda_lName";
                ddlUnitMandal.DataBind();
                // ddlUnitMandal.Items.Insert(0, "--Mandal--");
                AddSelect(ddlUnitMandal);
            }
            else
            {
                ddlUnitMandal.Items.Clear();
                //ddlUnitMandal.Items.Insert(0, "--Mandal--");
                AddSelect(ddlUnitMandal);
            }
        }
    }

    protected void ddlUnitMandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlUnitMandal.SelectedIndex == 0)
        {

            ddlVillageunit.Items.Clear();
            // ddlVillageunit.Items.Insert(0, "--Village--");
            AddSelect(ddlVillageunit);
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
                AddSelect(ddlVillageunit);
                //  ddlVillageunit.Items.Insert(0, "--Village--");
            }
            else
            {
                ddlVillageunit.Items.Clear();
                // ddlVillageunit.Items.Insert(0, "--Village--");
                AddSelect(ddlVillageunit);
            }
        }
    }

    protected void ddlVillageunit_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
            // rblGHMC.Items.Clear();
            if (ddlVillageunit.SelectedIndex != 0)
            {
                DataSet dsss = new DataSet();
                DataSet dscess = Gen.GetUnderLimitsOfVillage(ddlVillageunit.SelectedValue);
                string Muncipal_Flag = "", GHMC_FLG = "", HMR_FLG = "", HMDA_FLG = "", KUDA_FLAG = "", DTCPFLAG = "", YTDA = "", Hmwssbflg = "";

                if (dscess.Tables[0].Rows.Count > 0)
                {
                    Muncipal_Flag = dscess.Tables[0].Rows[0]["Muncipal_Flag"].ToString();
                    GHMC_FLG = dscess.Tables[0].Rows[0]["GHMC_FLG"].ToString();
                    HMR_FLG = dscess.Tables[0].Rows[0]["HMR_FLG"].ToString();
                    HMDA_FLG = dscess.Tables[0].Rows[0]["HMDA_FLG"].ToString();
                    KUDA_FLAG = dscess.Tables[0].Rows[0]["KUDA_FLAG"].ToString();
                    DTCPFLAG = dscess.Tables[0].Rows[0]["DTCPFLAG"].ToString();
                    YTDA = dscess.Tables[0].Rows[0]["YTD"].ToString();
                    Hmwssbflg = dscess.Tables[0].Rows[0]["Hmwssb_Flg"].ToString();

                    if ((GHMC_FLG != null && GHMC_FLG == "Y") || (Muncipal_Flag != null && Muncipal_Flag == "Y"))
                    {
                        rblGHMC.SelectedValue = "1";
                        rblGHMC.Enabled = false;
                    }
                    else
                    {
                        rblGHMC.SelectedValue = "0";
                        rblGHMC.Enabled = false;
                    }
                    rblGHMC_SelectedIndexChanged(sender, e);
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }

    }

    public void BindDistricts1()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlOffcDIst.Items.Clear();
            dsd = Gen.GetDistrictsWithoutHYD();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlOffcDIst.DataSource = dsd.Tables[0];
                ddlOffcDIst.DataValueField = "District_Id";
                ddlOffcDIst.DataTextField = "District_Name";
                ddlOffcDIst.DataBind();
                // ddlOffcDIst.Items.Insert(0, "--District--");
                AddSelect(ddlOffcDIst);
            }
            else
            {
                AddSelect(ddlOffcDIst);
                // ddlOffcDIst.Items.Insert(0, "--District--");
            }
        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }

    protected void ddloffcstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddloffcstate.SelectedValue.ToString() != "--Select--")
            {
                if (ddloffcstate.SelectedValue.ToString() == "31")
                {
                    //getdistrictsOffc();
                    BindDistricts1();

                    txtofficedist.Visible = false;
                    txtoffcicemandal.Visible = false;
                    txtofficeviiage.Visible = false;

                    ddlOffcDIst.Visible = true;
                    ddlOffcMandal.Visible = true;
                    ddlOffcVil.Visible = true;
                }
                else
                {
                    txtofficedist.Visible = true;
                    txtoffcicemandal.Visible = true;
                    txtofficeviiage.Visible = true;

                    ddlOffcDIst.Visible = false;
                    ddlOffcMandal.Visible = false;
                    ddlOffcVil.Visible = false;
                }
            }
            else
            {
                ddlUnitstate.Items.Clear();
                //  ddlUnitstate.Items.Insert(0, "--Select--");
                AddSelect(ddlUnitstate);
            }
        }
        catch (Exception ex)
        {
        }
    }

    public void BindConstitutionUnit()
    {
        try
        {
            dsdorg = objFetch.FetchConstitutionUnit();
            //dsdorg.Tables.Add(dtorg);
            //dsdorg.Tables.Remove(dtorg);
            if (dsdorg != null && dsdorg.Tables.Count > 0 && dsdorg.Tables[0].Rows.Count > 0)
            {
                ddlOrgType.DataSource = dsdorg.Tables[0];
                ddlOrgType.DataValueField = "CunitId";
                ddlOrgType.DataTextField = "ConstitutionUnit";
                ddlOrgType.DataBind();
                ddlOrgType.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlOrgType.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void ddldistrictoffc_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlOffcDIst.SelectedIndex == 0)
        {
            ddlOffcMandal.Items.Clear();
            // ddlOffcMandal.Items.Insert(0, "--Mandal--");
            AddSelect(ddlOffcMandal);
            //ChkWater_reg_from.Items.Clear();
            //ChkWater_reg_from.Items.Insert(0, new ListItem("New Bore well", "New Bore well"));
            //ChkWater_reg_from.Items.Insert(1, new ListItem("HMWS & SB", "HMWS & SB"));
            //ChkWater_reg_from.Items.Insert(2, new ListItem("Rivers/Canals", "Rivers/Canals"));
        }
        else
        {
            ddlOffcMandal.Items.Clear();
            DataSet dsm = new DataSet();
            dsm = Gen.GetMandals(ddlOffcDIst.SelectedValue);
            if (dsm.Tables[0].Rows.Count > 0)
            {
                ddlOffcMandal.DataSource = dsm.Tables[0];
                ddlOffcMandal.DataValueField = "Mandal_Id";
                ddlOffcMandal.DataTextField = "Manda_lName";
                ddlOffcMandal.DataBind();
                //ddlOffcMandal.Items.Insert(0, "--Mandal--");
                AddSelect(ddlOffcMandal);
            }
            else
            {
                ddlOffcMandal.Items.Clear();
                //ddlOffcMandal.Items.Insert(0, "--Mandal--");
                AddSelect(ddlOffcMandal);
            }
        }
    }

    protected void ddloffcmandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlOffcMandal.SelectedIndex == 0)
        {

            ddlOffcVil.Items.Clear();
            // ddlOffcMandal.Items.Insert(0, "--Village--");
            AddSelect(ddlOffcVil);
        }
        else
        {
            ddlOffcVil.Items.Clear();
            DataSet dsv = new DataSet();
            dsv = Gen.GetVillages(ddlOffcMandal.SelectedValue);
            if (dsv.Tables[0].Rows.Count > 0)
            {
                ddlOffcVil.DataSource = dsv.Tables[0];
                ddlOffcVil.DataValueField = "Village_Id";
                ddlOffcVil.DataTextField = "Village_Name";
                ddlOffcVil.DataBind();
                //ddlOffcVil.Items.Insert(0, "--Village--");
                AddSelect(ddlOffcVil);
            }
            else
            {
                ddlOffcVil.Items.Clear();
                //ddlOffcVil.Items.Insert(0, "--Village--");
                AddSelect(ddlOffcVil);
            }
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
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }

    protected void rblGHMC_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblSector.SelectedValue != "1")   // sector is not service 
        {
            if (rblGHMC.SelectedValue == "0")
            {
                trIsIALA.Visible = true;
            }
            else
            {
                trIsIALA.Visible = false;
            }
        }
        else
        {
            trIsIALA.Visible = false;
        }
    }
    protected void rblVeh_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblVeh.SelectedValue == "1")
            {
                trvehicleno.Visible = true;
            }
            else
            {
                trvehicleno.Visible = false;
            }
        }
        catch (Exception ex)
        {

        }
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

            rblSector_SelectedIndexChanged(sender, e);

            if (rblSector.SelectedValue == "1")
            {
                if (rblCaste.SelectedValue == "3" || rblCaste.SelectedValue == "4" || cbDiffAbled.Checked == true)
                {
                    trrblVeh.Visible = true;
                    rblVeh.Items[0].Enabled = true;
                    //ddlOrgType.SelectedValue = "1";
                    //ddlOrgType.Enabled = false;
                    //ddlOrgType_SelectedIndexChanged(sender, e);
                    rblVeh.SelectedValue = "1";
                    rblVeh_SelectedIndexChanged(sender, e);
                    rblVeh.Enabled = true;
                }
                else
                {
                    trrblVeh.Visible = true;
                    rblVeh.Items[0].Enabled = false;
                    rblVeh.SelectedValue = "0";
                    rblVeh_SelectedIndexChanged(sender, e);
                    ddlOrgType.Enabled = true;
                    rblVeh.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {
            Errors.ErrorLog(ex);
        }
    }



    protected void txtDateofCommencement_TextChanged(object sender, EventArgs e)
    {
        try
        {
            comFunctions ddd = new comFunctions();
            //DateTime dat = Convert.ToDateTime((txtDateofCommencement.Text).ToString()
            DateTime dat = ddd.convertDateIndia(txtDateofCommencement.Text);

            if (dat > DateTime.Now)
            {
                txtDateofCommencement.Focus();
                lblmsg0.Text = "Future Date cannot be selected.";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Future Date cannot be selected');", true);
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

    protected void cbDiffAbled_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            //if (cbDiffAbled.Checked == true)
            //{
            if (rblSector.SelectedValue == "1")
            {
                rblCaste_SelectedIndexChanged(sender, e);
            }
            // }
            //if (cbDiffAbled.Checked)
            //{
            //    rblVeh.Visible = true; 
            //    trrblVeh.Visible = true;
            //}
            //else
            //{
            //    rblVeh.Visible = false;
            //    trrblVeh.Visible = false;
            //}
        }
        catch (Exception ex)
        { Errors.ErrorLog(ex); }
    }

    private void BindIndustrialParks()
    {
        try
        {
            DataSet dsParks = new DataSet();
            int DistrictCd = Convert.ToInt32(ddlUnitDIst.SelectedValue);
            ddlIndustrialParkName.Items.Clear();
            dsParks = objcommon.GetIALAParks_Incentives(0, DistrictCd);
            if (dsParks != null && dsParks.Tables.Count > 0 && dsParks.Tables[0].Rows.Count > 0)
            {
                ddlIndustrialParkName.DataSource = dsParks.Tables[0];
                ddlIndustrialParkName.DataValueField = "IALA_Cd";
                ddlIndustrialParkName.DataTextField = "NameofIALA";
                ddlIndustrialParkName.DataBind();
                AddSelect(ddlIndustrialParkName);
            }
            else
            {
                ddlIndustrialParkName.Items.Clear();
                AddSelect(ddlIndustrialParkName);
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }

    protected void rdIaLa_Lst_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdIaLa_Lst.SelectedValue == "Y")
        {
            trIndusParkList.Visible = true;
            BindIndustrialParks();
            //rblGHMC.SelectedValue = "0";
        }
        else
        {
            trIndusParkList.Visible = false;
            ddlIndustrialParkName.Items.Clear();
            // rblGHMC.SelectedValue = "1";
        }
    }

    protected void txtTinNO_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtTinNO.Text.Trim() != null && txtTinNO.Text.Trim() != "" && txtTinNO.Text.Trim() != string.Empty)
            {
                //txtvatno.Text = txtTinNO.Text;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void getdistrictsUnit()
    {
        DataSet dsnew = new DataSet();

        dsnew = Gen.GetDistrictsbystate(ddlUnitstate.SelectedValue.ToString());
        ddlUnitDIst.DataSource = dsnew.Tables[0];
        ddlUnitDIst.DataTextField = "District_Name";
        ddlUnitDIst.DataValueField = "District_Id";
        ddlUnitDIst.DataBind();
        // ddlUnitDIst.Items.Insert(0, "--Select--");
        AddSelect(ddlUnitDIst);

    }

    public string ValidateControls(string Step)
    {
        int slno = 1;
        string ErrorMsg = "";
        if (Step == "1")
        {
            if (rblSector.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Type of Sector \\n";
                slno = slno + 1;

            }
            if (ddlUdyogAadharType.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Udyog Aadhar/EM/IEM/IL/EOU No \\n";
                slno = slno + 1;
            }
            if (txtudyogAadharNo.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Udyog Aadhar No \\n";
                slno = slno + 1;
            }
            if (txtUdyogAadhaarRegdDate.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Date of Registration \\n";
                slno = slno + 1;
            }
            if (txtUser_Id.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Unit Name \\n";
                slno = slno + 1;
            }
            if (txtApplciantName.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Applicant Name \\n";
                slno = slno + 1;
            }
            if (txtTinNO.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter TIN Number \\n";
                slno = slno + 1;
            }
            if (txtPanNo.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter PAN Number \\n";
                slno = slno + 1;
            }
            if (txtDateofCommencement.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Commenecement Date \\n";
                slno = slno + 1;
            }
            if (ddlgender.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Gender \\n";
                slno = slno + 1;
            }
            if (rblCaste.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Caste \\n";
                slno = slno + 1;
            }

            if (ddlsubcaste.SelectedValue == "0" && trsubcaste.Visible == true)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Sub Caste \\n";
                slno = slno + 1;
            }
            if (rblVeh.SelectedIndex <= -1 && trrblVeh.Visible == true)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Transport allied activities \\n";
                slno = slno + 1;
            }
            if (txtregistrationno.Text.TrimStart().TrimEnd().Trim() == "" && trvehicleno.Visible == true)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Vehicle Number \\n";
                slno = slno + 1;
            }

            // Address
            if (ddlUnitstate.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select State Under Unit Address\\n";
                slno = slno + 1;
            }
            if (ddlUnitDIst.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select District Under Unit Address\\n";
                slno = slno + 1;
            }


            if (ddlUnitMandal.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Mandal Under Unit Address\\n";
                slno = slno + 1;
            }

            if (ddlVillageunit.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Village Under Unit Address\\n";
                slno = slno + 1;
            }
            if (txtUnitStreet.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Grampanchayat/IE/IDA Under Unit Address\\n";
                slno = slno + 1;
            }
            if (txtUnitHNO.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Survey/Plot Number  Under Unit Address\\n";
                slno = slno + 1;
            }
            if (txtunitmobileno.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Mobile Number Under Unit Address\\n";
                slno = slno + 1;
            }
            if (txtunitemailid.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Email ID Under Unit Address\\n";
                slno = slno + 1;
            }

            if (ddloffcstate.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select State Under Office Address\\n";
                slno = slno + 1;
            }
            else if (ddloffcstate.SelectedValue == "31")
            {
                if (ddlOffcDIst.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select District Under Office Address\\n";
                    slno = slno + 1;
                }
                if (ddlOffcMandal.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Mandal Under Office Address\\n";
                    slno = slno + 1;
                }
                if (ddlOffcVil.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Village Under Office Address\\n";
                    slno = slno + 1;
                }
            }
            else
            {
                if (txtofficedist.Text.TrimStart().TrimEnd().Trim() == "" && txtofficedist.Visible == true)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter District Name  Under Office Address\\n";
                    slno = slno + 1;
                }

                if (txtoffcicemandal.Text.TrimStart().TrimEnd().Trim() == "" && txtoffcicemandal.Visible == true)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Mandal Name  Under Office Address\\n";
                    slno = slno + 1;
                }

                if (txtofficeviiage.Text.TrimStart().TrimEnd().Trim() == "" && txtofficeviiage.Visible == true)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Village Name  Under Office Address\\n";
                    slno = slno + 1;
                }
            }
            if (txtOffcStreet.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Street Name  Under Office Address\\n";
                slno = slno + 1;
            }
            if (txtoffaddhnno.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Survey/Plot Number Under Office Address\\n";
                slno = slno + 1;
            }
            if (txtOffcMobileNO.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Mobile Number Under Office Address\\n";
                slno = slno + 1;
            }
            if (txtOffcEmail.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Email ID Under Office Address\\n";
                slno = slno + 1;
            }

            if (ddlOrgType.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Type of Organization\\n";
                slno = slno + 1;
            }
            if (rdIaLa_Lst.SelectedIndex <= -1 && trIsIALA.Visible == true)
            {
                ErrorMsg = ErrorMsg + slno + ". Please select whether the unit is located in TSIIC or not \\n";
                slno = slno + 1;
                rdIaLa_Lst.Enabled = true;
            }
            if (ddlIndustrialParkName.SelectedValue == "0" && trIndusParkList.Visible == true)
            {
                ErrorMsg = ErrorMsg + slno + ". Please select Industrial Park \\n";
                slno = slno + 1;
                ddlIndustrialParkName.Enabled = true;
            }
        }
        return ErrorMsg;
    }
    protected void btntab1next_Click(object sender, EventArgs e)
    {
        string errormsg = ValidateControls("1");
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        else
        {
            try
            {

                string userid = txtunitemailid.Text;

                int existing = Gen.ExistingUsers(userid);
                if (existing >=1)
                {
                    string alertmsg = "alert('" + "Already existing user" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", alertmsg, true);
                    return;
                }


                if (FileUpload1.HasFile)
                {
                    string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" ||  fileType[i - 1].ToUpper().Trim() == "DOCX")
                    {
                        AssignValuestoVosFromcontrols("1");
                        FIleUploading(FileUpload1, "OtherServiceDistReforms", lblFileName, ApprovalId, "1000001", "Reforms");
                        FIleUploading(FileUpload2, "OtherServiceDistReforms", lblFileNameOthers, "111", "1000001", "ReformsOtherAttch");
                        lblmsg.Text = "<font color='green'>Application Submitted Successfully..Please Click On Next !!! !</font>";
                        string message = "alert('" + "Application Submitted Successfully!!" + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;

                    }
                    else
                    {
                        string message = "alert('" + "Please Upload  PDF and DOC Format Files Only" + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }
                }

                else
                {
                    string message = "alert('" + "Please Upload a Document" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }








            }
            catch (Exception ex)
            {

            }
        }


       
    }

    private void OTPAfterSubmissionApplcn()
    {
        String Email = "", /*UserID = ""*/ MobileNo = "";
        Email = txtunitemailid.Text;
        MobileNo = txtunitmobileno.Text;
       

        DataSet ds = Gen.ValidateForgotReformsPassword(Email, MobileNo);//,Dept
        if (ds.Tables[0].Rows.Count > 0)
        {
            string userpasword = ds.Tables[0].Rows[0]["Password"].ToString();
            if (ds.Tables[0].Rows[0]["PwdEncryflag"].ToString().Trim() == "Y")
            {
                userpasword = Gen.Decrypt(userpasword, "SYSTIME");
            }
            string msgs = "Dear applecant " + " " + "\r\n" + " your Login Credentials." + "\r\n" + " User Id : " + ds.Tables[0].Rows[0]["UserId"].ToString() + "\r\n" + "Password : " + userpasword + "\r\n";
            msgs = msgs + "Thanks and Regards," + "\r\n" + "Commissionerate of Industries,TS-iPASS Cell";

            string body = msgs;
            string from = "tsipass.telangana@gmail.com"; //Replace this with your own correct Gmail Address

            string to = ds.Tables[0].Rows[0]["UserId"].ToString(); //Replace this with the Email Address to whom you want to send the mail

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(to);
            //mail.CC.Add("kcsbabu@gmail.com");
            //mail.CC.Add("coi.tsipass@gmail.com");
            //mail.CC.Add("support@fruxsoft.com");

            mail.From = new MailAddress(from, ":: TSiPASS ::", System.Text.Encoding.UTF8);

            mail.Subject = "Applicant -Login Credentials -";// + Session["user_id"].ToString()

            mail.SubjectEncoding = System.Text.Encoding.UTF8;  //ds.Tables[0].Rows[0]["Password"].ToString()
            mail.Body = "Dear  applicant " + " " + "<br><br>  <H2>TSiPASS MIS  - Login Credentials</H2><br> Welcome to TS-iPASS. <br/> Dear <b> " + " " + "</b>,<br/> Please use the following credentials to Login. <br><br> USER ID: " + ds.Tables[0].Rows[0]["UserId"].ToString() + "<br> <br> Password : " + userpasword + "<br> <br> URL:  <a href='http://industries.telangana.gov.in' target='_blank' > TSiPASS </a> <br> <br> Please Login by clicking the above link.<br><br>Regards<br>TSiPASS MIS";
            mail.BodyEncoding = System.Text.Encoding.UTF8;

            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            SmtpClient client = new SmtpClient();
            //Add the Creddentials- use your own email id and password

            //client.Credentials = new System.Net.NetworkCredential(from, "tsipass@2016");
            //client.Credentials = new System.Net.NetworkCredential(from, "zwcq vlxk gyor lpeg");
            client.Credentials = new System.Net.NetworkCredential(from, "fqeq nive azke giwb");

            client.Port = 587; // Gmail works on this port
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true; //Gmail works on Server Secured Layer
            try
            {
                client.Send(mail);
                //Session.Remove("File");
                //Session.Remove("FileName");
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
                HttpContext.Current.Response.Write(errorMessage);
            } // end try
            //SendSingleSMSnew(ds.Tables[0].Rows[0]["MobileNo"].ToString(), body);
            
            
            lblmsg.Text = "Login Credentials sent to Registerd E-Mail And Registerd Mobile No ";
            Failure.Visible = false;
            success.Visible = true;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "AnotherFunction();", true);
        }
        else
        {
            lblmsg0.Text = "Please Enter Registerd E-Mail and Mobile and User Name";
            Failure.Visible = true;
            success.Visible = false;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "AnotherFunction();", true);
        }


    }

    protected String encryptedPasswod(String password)
    {
        byte[] encPwd = Encoding.UTF8.GetBytes(password);
        //static byte[] pwd = new byte[encPwd.Length];
        HashAlgorithm sha1 = HashAlgorithm.Create("SHA1");
        byte[] pp = sha1.ComputeHash(encPwd);
        // static string result = System.Text.Encoding.UTF8.GetString(pp);
        StringBuilder sb = new StringBuilder();
        foreach (byte b in pp)
        {
            sb.Append(b.ToString("x2"));
        }
        return sb.ToString();
    }
    public String SendSingleSMSnew(String mobileNo, String message)
    {
        String username = "TSIPASS";
        String password = "kcsb@786";
        String senderid = "TSIPAS";
        String secureKey = "e8750728-53e8-4f29-9bc9-9f06975accb0";
        //Latest Generated Secure Key

        Stream dataStream;
        System.Net.ServicePointManager.SecurityProtocol= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequest");
        request.ProtocolVersion = HttpVersion.Version10;
        request.KeepAlive = false;
        request.ServicePoint.ConnectionLimit = 1;
        //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
        ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
        request.Method = "POST";
        //System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
        //System.Net.ServicePointManager.CertificatePolicy= new 
        String encryptedPassword = encryptedPasswod(password);
        String NewsecureKey = hashGenerator(username.Trim(), senderid.Trim(), message.Trim(), secureKey.Trim());
        String smsservicetype = "singlemsg"; //For single message.
        String query = "username=" + HttpUtility.UrlEncode(username.Trim()) +
            "&password=" + HttpUtility.UrlEncode(encryptedPassword) +
            "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +
            "&content=" + HttpUtility.UrlEncode(message.Trim()) +
            "&mobileno=" + HttpUtility.UrlEncode(mobileNo) +
            "&senderid=" + HttpUtility.UrlEncode(senderid.Trim()) +
            "&key=" + HttpUtility.UrlEncode(NewsecureKey.Trim());
        byte[] byteArray = Encoding.ASCII.GetBytes(query);
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = byteArray.Length;
        dataStream = request.GetRequestStream();
        dataStream.Write(byteArray, 0, byteArray.Length);
        dataStream.Close();
        WebResponse response = request.GetResponse();
        String Status = ((HttpWebResponse)response).StatusDescription;
        dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        String responseFromServer = reader.ReadToEnd();
        reader.Close();
        dataStream.Close();
        response.Close();
        return responseFromServer;
    }

    protected String hashGenerator(String Username, String sender_id, String message, String secure_key)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Username).Append(sender_id).Append(message).Append(secure_key);
        byte[] genkey = Encoding.UTF8.GetBytes(sb.ToString());
        //static byte[] pwd = new byte[encPwd.Length];
        HashAlgorithm sha1 = HashAlgorithm.Create("SHA512");
        byte[] sec_key = sha1.ComputeHash(genkey);
        StringBuilder sb1 = new StringBuilder();
        for (int i = 0; i < sec_key.Length; i++)
        {
            sb1.Append(sec_key[i].ToString("x2"));
        }
        return sb1.ToString();
    }

    public void AssignValuestoVosFromcontrols(string step)
    {
        try
        {
            objvo.AppsLevel = step;
            
            if (step == "1")
            {

                objvo.sector = rblSector.SelectedValue;
                objvo.UdyogAadharType = ddlUdyogAadharType.SelectedValue;
                objvo.EMiUdyogAadhar = txtudyogAadharNo.Text.ToUpper();
                if (txtUdyogAadhaarRegdDate.Text == "" || txtUdyogAadhaarRegdDate.Text == null)
                {
                    objvo.UdyogAadharRegdDate = null;
                }
                else
                {
                    string[] ConvertedDt11 = txtUdyogAadhaarRegdDate.Text.Split('/');
                    objvo.UdyogAadharRegdDate = ConvertedDt11[2].ToString() + "/" + ConvertedDt11[1].ToString() + "/" + ConvertedDt11[0].ToString();
                }
                objvo.UnitName = txtUser_Id.Text.ToUpper();
                objvo.ApplciantName = txtApplciantName.Text.ToUpper();
                objvo.TinNO = txtTinNO.Text.ToUpper();
                objvo.PanNo = txtPanNo.Text.ToUpper();
                if (cbDiffAbled.Checked)
                {
                    objvo.IsDifferentlyAbled = "Y";
                }
                else
                {
                    objvo.IsDifferentlyAbled = "N";
                }
                if (cbMinority.Visible == true)
                {
                    if (cbMinority.Checked)
                    {
                        objvo.IsMinority = "Y";
                    }
                }
                else
                {
                    objvo.IsMinority = null;
                }

                string[] Ld2 = null;
                string ConvertedDt5 = "";

                if (txtDateofCommencement.Text != "")
                {
                    Ld2 = txtDateofCommencement.Text.Split('/');
                    ConvertedDt5 = Ld2[2].ToString() + "/" + Ld2[1].ToString() + "/" + Ld2[0].ToString();

                    objvo.DateOfComm = ConvertedDt5;
                }
                else
                {
                    objvo.DateOfComm = null;
                }
                objvo.Gender = ddlgender.SelectedValue.ToString();
                objvo.SocialStatus = rblCaste.SelectedValue;
                if (ddlsubcaste.SelectedItem.Text.ToUpper() != "SELECT")
                {
                    objvo.SubCaste = ddlsubcaste.SelectedValue;
                }
                else
                {
                    objvo.SubCaste = null;
                }
                if (rblVeh.SelectedIndex > -1 && rblSector.SelectedValue == "1")
                {
                    objvo.isVehicleIncentive = Convert.ToBoolean(Convert.ToInt32(rblVeh.SelectedValue));
                }
                else
                {
                    objvo.isVehicleIncentive = false;
                }
                if (txtregistrationno.Text == "" && txtregistrationno.Text == null)
                {
                    objvo.VehicleNumber = null;
                }
                else
                {
                    objvo.VehicleNumber = txtregistrationno.Text;
                }



                // Unit Address

                objvo.UnitState = ddlUnitstate.SelectedValue;
                objvo.UnitDIst = ddlUnitDIst.SelectedValue;
                objvo.UnitMandal = ddlUnitMandal.SelectedValue;
                objvo.UnitVill = ddlVillageunit.SelectedValue;
                objvo.UnitStreet = txtUnitStreet.Text.ToUpper();
                objvo.UnitHNO = txtUnitHNO.Text.ToUpper();
                objvo.UnitMObileNo = txtunitmobileno.Text.ToUpper();
                objvo.UnitEmail = txtunitemailid.Text.ToUpper();

                //Office Address
                objvo.OffcState = ddloffcstate.SelectedValue;
                if (ddloffcstate.SelectedValue.ToString() != "31")
                {
                    objvo.OffcOtherDist = txtofficedist.Text.ToUpper();
                    objvo.OffcOtherVillage = txtoffcicemandal.Text.ToUpper();
                    objvo.OffcOtherMandal = txtofficeviiage.Text.ToUpper();
                }
                else
                {
                    objvo.OffcDIst = ddlOffcDIst.SelectedValue;
                    objvo.OffcMandal = ddlOffcMandal.SelectedValue;
                    objvo.OffcVil = ddlOffcVil.SelectedValue;
                }

                objvo.OffcHNO = txtoffaddhnno.Text.ToUpper();
                objvo.OffcStreet = txtOffcStreet.Text.ToUpper();
                objvo.OffcEmail = txtOffcEmail.Text.ToUpper();
                objvo.OffcMobileNO = txtOffcMobileNO.Text.ToUpper();
                objvo.TypeofOrg = ddlOrgType.SelectedValue;
                objvo.IsGHMCandOtherMuncpOrp = Convert.ToBoolean(Convert.ToInt32(rblGHMC.SelectedValue));
                if (rdIaLa_Lst.SelectedValue == "Y")
                {
                    objvo.isIALA = "Y";
                    objvo.IndusParkList = Convert.ToInt32(ddlIndustrialParkName.SelectedValue);
                }
                else
                {
                    objvo.isIALA = "N";
                    objvo.IndusParkList = 0;
                }

                objvo.natureOfAct = ddlintLineofActivity.SelectedValue;
                objvo.NatureofBussiness = txtBussinessActivity.Text.ToUpper();
                // IncentiveApplicantSide incentiveApplicantSideVo = new IncentiveApplicantSide();
                try
                {
                    string Validstatus = InsertIncentivCommonData(objvo);
                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        lblmsg.Text = "<font color='green'>Record Successfully Added..!</font>";
                        objvo.IncentveID = Validstatus;
                        Session["CFEEnterpid"] = objvo.IncentveID;
                        Session["Questionaireid"] = objvo.IncentveID;


                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Application Submitted Successfully!!.');", true);
                        //return;

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                    return;
                }
            } // Step 1 End
           
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public void FIleUploading(FileUpload fpd, string Description, HyperLink hlp, string ApprovalID, string DocID, string DocUploadedUserType)
    {

        //Session["Questionaireid"] = "001";
        Session["uid"] = Session["validCreated"].ToString();
        //Session["CFEEnterpid"] = "001";


        string newPath = "";
        string sFileDir = Server.MapPath("~\\OtherServiceDistReformsAttchments");
        General t1 = new General();
        if ((fpd.PostedFile != null) && (fpd.PostedFile.ContentLength > 0))
        {
            string sFileName = System.IO.Path.GetFileName(fpd.PostedFile.FileName);
            // string sFileName = System.IO.Path.GetFileName(fpd.PostedFile.FileName);
            //string sFileName = "";

            string fileExtension = Path.GetExtension(sFileName);
            string sFileNameonly = Path.GetFileNameWithoutExtension(sFileName);
            string Attachmentidnew = Session["uid"].ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();

            sFileName = Description + Attachmentidnew + fileExtension;

            try
            {
                string[] fileType = fpd.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {

                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\" + Description + "\\" + Attachmentidnew);
                    if (!Directory.Exists(newPath))
                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        fpd.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            fpd.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    int result = 0;
                    //  result = t1.InsertCFEUploads(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Description, Session["uid"].ToString(), ApprovalID, DocID, DocUploadedUserType);
                    // result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Description, "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                     result = t1.InsertOtherServicesImagedata(Session["Questionaireid"].ToString(), Session["CFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Description, "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(),deptId, ApprovalId);
                    if (result != 0)
                    {
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        hlp.Text = "View";
                        hlp.NavigateUrl = "~/OtherServiceDistReformsAttchments/" + Session["uid"] + "/" + Description + "/" + Attachmentidnew + "/" + sFileName;
                        ViewState[fpd.ID] = "~/OtherServiceDistReformsAttchments/" + Session["uid"] + "/" + Description + "/" + Attachmentidnew + "/" + sFileName;
                        //   ViewState[fpd.ID] = "~/Attachments/" + "1" + "/" + Description + "/" + Attachmentidnew + "/" + sFileName;
                        success.Visible = true;
                        Failure.Visible = false;

                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }
                }
                else
                {

                    lblmsg0.Text = "<font color='red'>Upload JPEG files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Upload PDF files only..');", true);
                    //return;
                }
            }
            catch (Exception ex)//in case of an error
            {
                throw ex;
            }
        }
    }


    public void DeleteFile(string strFileName)
    {//Delete file from the server
        if (strFileName.Trim().Length > 0)
        {
            FileInfo fi = new FileInfo(strFileName);
            if (fi.Exists)//if file exists delete it
            {
                fi.Delete();
            }
        }
    }

    public string InsertIncentivCommonData(DistrictReform objvo1)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        string validCreated = "";
        string validIncentivId = "";
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();
        try
        {
            SqlCommand COMNew = new SqlCommand();
            COMNew.CommandType = CommandType.StoredProcedure;
            COMNew.CommandText = "SP_InsertReformUserRegestrationdetails";
            COMNew.Transaction = transaction;
            COMNew.Connection = connection;
           
            COMNew.Parameters.AddWithValue("@ApplicantName", objvo1.ApplciantName);
            COMNew.Parameters.AddWithValue("@PanNo", objvo1.PanNo);
            COMNew.Parameters.AddWithValue("@UnitEmail", objvo1.UnitEmail);
            if (objvo1.UnitMObileNo != null)
                COMNew.Parameters.AddWithValue("@UnitMObileNo", objvo1.UnitMObileNo);
            else
                COMNew.Parameters.AddWithValue("@UnitMObileNo", null);

            COMNew.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
            COMNew.Parameters["@Valid"].Direction = ParameterDirection.Output;
            COMNew.ExecuteNonQuery();

            validCreated = COMNew.Parameters["@Valid"].Value.ToString();
            Session["validCreated"] = validCreated;
            if (validCreated != "0")
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "USP_INSERT_ReformsApplicantDetails";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentReformId", objvo1.IncentveID);
                if (objvo1.sector != null)
                    com.Parameters.AddWithValue("@SectorID", objvo1.sector);
                else
                    com.Parameters.AddWithValue("@SectorID", null);

                if (objvo1.UdyogAadharType != null)
                    com.Parameters.AddWithValue("@UdyogAadharType", objvo1.UdyogAadharType);
                else
                    com.Parameters.AddWithValue("@UdyogAadharType", null);

                if (objvo1.EMiUdyogAadhar != null)
                    com.Parameters.AddWithValue("@EMiUdyogAadhar", objvo1.EMiUdyogAadhar);
                else
                    com.Parameters.AddWithValue("@EMiUdyogAadhar", null);
                if (objvo1.UdyogAadharRegdDate != null)
                    com.Parameters.AddWithValue("@UdyogAadharRegdDate", objvo1.UdyogAadharRegdDate);
                else
                    com.Parameters.AddWithValue("@UdyogAadharRegdDate", null);


                if (objvo1.UnitName != null)
                    com.Parameters.AddWithValue("@UnitName", objvo1.UnitName);
                else
                    com.Parameters.AddWithValue("@UnitName", null);
                if (objvo1.ApplciantName != null)
                    com.Parameters.AddWithValue("@ApplicantName", objvo1.ApplciantName);
                else
                    com.Parameters.AddWithValue("@ApplicantName", null);
                if (objvo1.TinNO != null)
                    com.Parameters.AddWithValue("@TinNO", objvo1.TinNO);
                else
                    com.Parameters.AddWithValue("@TinNO", null);
                if (objvo1.PanNo != null)
                    com.Parameters.AddWithValue("@PanNo", objvo1.PanNo);
                else
                    com.Parameters.AddWithValue("@PanNo", null);

                if (objvo1.IsDifferentlyAbled != null)
                    com.Parameters.AddWithValue("@IsDifferentlyAbled", objvo1.IsDifferentlyAbled);
                else
                    com.Parameters.AddWithValue("@IsDifferentlyAbled", null);

                if (objvo1.IsMinority != null)
                    com.Parameters.AddWithValue("@IsMinority", objvo1.IsMinority);
                else
                    com.Parameters.AddWithValue("@IsMinority", null);
                if (objvo1.DateOfComm != null)
                    com.Parameters.AddWithValue("@DCP", objvo1.DateOfComm);
                else
                    com.Parameters.AddWithValue("@DCP", null);
                if (objvo1.Gender != null)
                    com.Parameters.AddWithValue("@Gender", objvo1.Gender);
                else
                    com.Parameters.AddWithValue("@Gender", null);

                if (objvo1.SocialStatus != null)
                    com.Parameters.AddWithValue("@SocialStatus", Convert.ToInt32(objvo1.SocialStatus));
                else
                    com.Parameters.AddWithValue("@SocialStatus", null);
                if (objvo1.SubCaste != null)
                    com.Parameters.AddWithValue("@SubCaste", objvo1.SubCaste);
                else
                    com.Parameters.AddWithValue("@SubCaste", null);
                if (objvo1.isVehicleIncentive != null)
                    com.Parameters.AddWithValue("@isVehicleIncentive", objvo1.isVehicleIncentive);
                else
                    com.Parameters.AddWithValue("@isVehicleIncentive", null);

                if (objvo1.VehicleNumber != null)
                    com.Parameters.AddWithValue("@VehicleNumber", objvo1.VehicleNumber);
                else
                    com.Parameters.AddWithValue("@VehicleNumber", null);
                if (validCreated != null)
                    com.Parameters.AddWithValue("@CreatedBy", validCreated);
                else
                    com.Parameters.AddWithValue("@CreatedBy", null);
                if (objvo1.UnitState != null)
                    com.Parameters.AddWithValue("@UnitState", objvo1.UnitState);
                else
                    com.Parameters.AddWithValue("@UnitState", null);

                if (objvo1.UnitDIst != null)
                    com.Parameters.AddWithValue("@UnitDIst", objvo1.UnitDIst);
                else
                    com.Parameters.AddWithValue("@UnitDIst", null);
                if (objvo1.UnitMandal != null)
                    com.Parameters.AddWithValue("@UnitMandal", objvo1.UnitMandal);
                else
                    com.Parameters.AddWithValue("@UnitMandal", null);
                if (objvo1.UnitVill != null)
                    com.Parameters.AddWithValue("@UnitVill", objvo1.UnitVill);
                else
                    com.Parameters.AddWithValue("@UnitVill", null);
                if (objvo1.UnitStreet != null)
                    com.Parameters.AddWithValue("@UnitStreet", objvo1.UnitStreet);
                else
                    com.Parameters.AddWithValue("@UnitStreet", null);
                if (objvo1.UnitHNO != null)
                    com.Parameters.AddWithValue("@UnitHNO", objvo1.UnitHNO);
                else
                    com.Parameters.AddWithValue("@UnitHNO", null);
                if (objvo1.UnitMObileNo != null)
                    com.Parameters.AddWithValue("@UnitMObileNo", objvo1.UnitMObileNo);
                else
                    com.Parameters.AddWithValue("@UnitMObileNo", null);
                if (objvo1.UnitEmail != null)
                    com.Parameters.AddWithValue("@UnitEmail", objvo1.UnitEmail);
                else
                    com.Parameters.AddWithValue("@UnitEmail", null);
                if (objvo1.OffcState != null)
                    com.Parameters.AddWithValue("@OffcState", objvo1.OffcState);
                else
                    com.Parameters.AddWithValue("@OffcState", null);

                if (objvo1.OffcOtherDist != null)
                    com.Parameters.AddWithValue("@OffcOtherDist", objvo1.OffcOtherDist);
                else
                    com.Parameters.AddWithValue("@OffcOtherDist", null);

                if (objvo1.OffcOtherMandal != null)
                    com.Parameters.AddWithValue("@OffcOtherMandal", objvo1.OffcOtherMandal);
                else
                    com.Parameters.AddWithValue("@OffcOtherMandal", null);

                if (objvo1.OffcOtherVillage != null)
                    com.Parameters.AddWithValue("@OffcOtherVillage", objvo1.OffcOtherVillage);
                else
                    com.Parameters.AddWithValue("@OffcOtherVillage", null);
                if (objvo1.OffcDIst != null)
                    com.Parameters.AddWithValue("@OffcDIst", objvo1.OffcDIst);
                else
                    com.Parameters.AddWithValue("@OffcDIst", null);
                if (objvo1.OffcMandal != null)
                    com.Parameters.AddWithValue("@OffcMandal", objvo1.OffcMandal);
                else
                    com.Parameters.AddWithValue("@OffcMandal", null);
                if (objvo1.OffcVil != null)
                    com.Parameters.AddWithValue("@OffcVill", objvo1.OffcVil);
                else
                    com.Parameters.AddWithValue("@OffcVill", null);
                if (objvo1.OffcHNO != null)
                    com.Parameters.AddWithValue("@OffcHNO", objvo1.OffcHNO);
                else
                    com.Parameters.AddWithValue("@OffcHNO", null);
                if (objvo1.OffcStreet != null)
                    com.Parameters.AddWithValue("@OffcStreet", objvo1.OffcStreet);
                else
                    com.Parameters.AddWithValue("@OffcStreet", null);
                if (objvo1.OffcEmail != null)
                    com.Parameters.AddWithValue("@OffcEmail", objvo1.OffcEmail);
                else
                    com.Parameters.AddWithValue("@OffcEmail", null);
                if (objvo1.OffcMobileNO != null)
                    com.Parameters.AddWithValue("@OffcMobileNO", objvo1.OffcMobileNO);
                else
                    com.Parameters.AddWithValue("@OffcMobileNO", null);

                if (objvo1.TypeofOrg != null)
                    com.Parameters.AddWithValue("@OrgType", objvo1.TypeofOrg);
                else
                    com.Parameters.AddWithValue("@OrgType", null);

                if (objvo1.IsGHMCandOtherMuncpOrp != null)
                    com.Parameters.AddWithValue("@IsGHMCandOtherMuncpOrp", objvo1.IsGHMCandOtherMuncpOrp);
                else
                    com.Parameters.AddWithValue("@IsGHMCandOtherMuncpOrp", null);

                if (objvo1.isIALA != null)
                    com.Parameters.AddWithValue("@isIALA", objvo1.isIALA);
                else
                    com.Parameters.AddWithValue("@isIALA", null);

                if (objvo1.IndusParkList != null)
                    com.Parameters.AddWithValue("@IndusParkList", objvo1.IndusParkList);
                else
                    com.Parameters.AddWithValue("@IndusParkList", null);

                if (objvo1.natureOfAct != null)
                    com.Parameters.AddWithValue("@NatureOfActivity", objvo1.natureOfAct);
                else
                    com.Parameters.AddWithValue("@NatureOfActivity", null);
                if (objvo1.NatureofBussiness != null)
                    com.Parameters.AddWithValue("@NatureofBussiness", objvo1.NatureofBussiness);
                else
                    com.Parameters.AddWithValue("@NatureofBussiness", null);
                if (objvo1.AppsLevel != null)
                    com.Parameters.AddWithValue("@AppsLevel", objvo1.AppsLevel);
                else
                    com.Parameters.AddWithValue("@AppsLevel", null);

                com.Parameters.AddWithValue("@ApprovalId", ApprovalId);


                com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
                com.Parameters["@Valid"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                validIncentivId = com.Parameters["@Valid"].Value.ToString();

            }

            if (validIncentivId != "0")
            {
                SqlCommand Com = new SqlCommand();
                Com.CommandType = CommandType.StoredProcedure;
                Com.CommandText = "SP_InsertReformsDeptFlowdetails";
                Com.Transaction = transaction;
                Com.Connection = connection;
                Com.Parameters.AddWithValue("@ApprovalId", ApprovalId);
                Com.Parameters.AddWithValue("@DeptId", deptId);
                Com.Parameters.AddWithValue("@intCfeId", validIncentivId);
                Com.Parameters.AddWithValue("@CreatedBy", validCreated);              
                Com.ExecuteNonQuery();

            }







            transaction.Commit();
            connection.Close();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw ex;
            //string message = "alert('" + ex.Message+ "')";
            //ScriptManager.RegisterClientScriptBlock((this as Control), this.GetType(), "alert", message, true);
        }
        finally
        {
            connection.Close();
            connection.Dispose();
        }
        return validIncentivId;
    }


    protected void btnNextpayment_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmOtherServicesDepartmentApprovalPaymentDetails.aspx?ApprovalId=" + ApprovalId + "&deptId=" + deptId + "&CFEEnterpid=" + Session["CFEEnterpid"].ToString());
    }
    public void BindCommissionerates()
    {
        try
        {
            dsdorg = objFetch.FetchCommissionerates();
            //dsdorg.Tables.Add(dtorg);
            //dsdorg.Tables.Remove(dtorg);
            if (dsdorg != null && dsdorg.Tables.Count > 0 && dsdorg.Tables[0].Rows.Count > 0)
            {
                ddlcommissionerates.DataSource = dsdorg.Tables[0];
                ddlcommissionerates.DataValueField = "AreaId";
                ddlcommissionerates.DataTextField = "CommissionerateAreaName";
                ddlcommissionerates.DataBind();
                ddlcommissionerates.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlcommissionerates.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
}