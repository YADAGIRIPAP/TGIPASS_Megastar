using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Web.Services.Protocols;
using BusinessLogic;
using System.Xml;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Collections.Generic;

public partial class UI_TSiPASS_frmRenewalDetail : System.Web.UI.Page
{
    //LabourRenewalService.shopRenewalDetails labourrenvo = new LabourRenewalService.shopRenewalDetails();
    ////LabourRenewalService.shopsEstRenewals labourren = new LabourRenewalService.shopsEstRenewals();
    //LabourRenewalService.TSLabourServiceImplService labour = new LabourRenewalService.TSLabourServiceImplService();
    //LabourRenewalService.actsResponse labourresponse = new LabourRenewalService.actsResponse();
    //LabourRenewalService.act act = new LabourRenewalService.act();
    //RenewalVo labourvo = new RenewalVo();
    //LabourRenewalService.shopsEstRenewals shopvo = new LabourRenewalService.shopsEstRenewals();
    General Gen = new General();
    CommonBL objcommon = new CommonBL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {
            DataSet dsnew = new DataSet();
            dsnew = Gen.getdataofidentityRENAPPROVALID(Session["Applid"].ToString(), "117");
            if (dsnew.Tables[0].Rows.Count > 0)
            {
                trpolicedetails.Visible = true;
            }
            else
            {
                trpolicedetails.Visible = false;
            }

            getdistricts();
            BinCurrencyType();
            BindenterpriseSectors();
            BindLineofActivityName();
            ddlSector.SelectedValue = "1";
            ddlcurrencytype.SelectedValue = "";
            DataSet ds = new DataSet();
            ds = Gen.Getenterpreneurdetailsrenewals(Session["uid"].ToString().Trim());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtage.Text = ds.Tables[0].Rows[0]["AGE"].ToString().Trim();
                txtdesignation.Text = ds.Tables[0].Rows[0]["DESIGNATION"].ToString().Trim();
                //txtDoorNo.Text = "";
                txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString().Trim();
                txtPincode0.Text = ds.Tables[0].Rows[0]["Pincode"].ToString().Trim();
                txtPromotor.Text = ds.Tables[0].Rows[0]["NameofthePromoter"].ToString().Trim();
                txtindustrialName.Text = ds.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString().Trim();
                txtSoromoter.Text = ds.Tables[0].Rows[0]["SoWo"].ToString().Trim();
                txtmobileNo.Text = ds.Tables[0].Rows[0]["mobilenumber"].ToString().Trim();
                txtstreetName.Text = ds.Tables[0].Rows[0]["StreetName"].ToString().Trim();
                txtDoorNo.Text = ds.Tables[0].Rows[0]["Door_No"].ToString().Trim();

                ddlcommissionerate.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Commissionerate"]);
                ddlcommissionerate_SelectedIndexChanged(this, EventArgs.Empty);
                ddlzone.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Zone"]);
                ddlzone_SelectedIndexChanged(this, EventArgs.Empty);
                ddldivision.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Division"]);
                ddldivision_SelectedIndexChanged(this, EventArgs.Empty);
                ddlpolicestation.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Policestation"]);
                ddltrafficzone.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["TrafficZone"]);
                ddltrafficzone_SelectedIndexChanged(this, EventArgs.Empty);
                ddltrafficdivision.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["TrafficDivision"]);
                ddltrafficdivision_SelectedIndexChanged(this, EventArgs.Empty);
                ddltrafficpolicestation.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["TrafficPolicestation"]);

                getdistricts();
                if (ds.Tables[0].Rows[0]["intDistrictid"].ToString().Trim() != "")
                {
                    ddldistrict.SelectedValue = ddldistrict.Items.FindByValue(ds.Tables[0].Rows[0]["intDistrictid"].ToString().Trim()).Value;
                }
                getMandals();
                if (ds.Tables[0].Rows[0]["intMandalid"].ToString().Trim() != "")
                {
                    ddlMandal.SelectedValue = ddlMandal.Items.FindByValue(ds.Tables[0].Rows[0]["intMandalid"].ToString().Trim()).Value;
                }
                getVillages();
                if (ds.Tables[0].Rows[0]["intVillageid"].ToString().Trim() != "")
                {
                    ddlvillage.SelectedValue = ddlvillage.Items.FindByValue(ds.Tables[0].Rows[0]["intVillageid"].ToString().Trim()).Value;
                }
                ViewState["uidno"] = ds.Tables[0].Rows[0]["UID_No"].ToString().Trim();
                if (ds.Tables[0].Rows[0]["CurrencyType"].ToString() != "")
                {
                    //  ddlcurrencytype.SelectedValue = ddlcurrencytype.SelectedIndex.(ds.Tables[0].Rows[0]["CurrencyType"].ToString().Trim()).Value;
                    ddlcurrencytype.SelectedValue = ddlcurrencytype.Items.FindByText(ds.Tables[0].Rows[0]["CurrencyType"].ToString().Trim()).Value;
                    //ddlcurrencytype.SelectedIndex = Convert.ToInt32(ds.Tables[0].Rows[0]["CurrencyType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Sector_Ent"].ToString().Trim() != "")
                {
                    ddlSector.SelectedValue = ddlSector.Items.FindByValue(ds.Tables[0].Rows[0]["Sector_Ent"].ToString().Trim()).Value;

                }
                txtlandvalue.Text = ds.Tables[0].Rows[0]["Val_Land"].ToString().Trim();
                txtbuildingvalue.Text = ds.Tables[0].Rows[0]["Val_Build"].ToString().Trim();
                txtPlantvalue.Text = ds.Tables[0].Rows[0]["Val_Plant"].ToString().Trim();
                txttotal.Text = ds.Tables[0].Rows[0]["Tot_PrjCost"].ToString().Trim();

                txtlandvalueActul.Text = ds.Tables[0].Rows[0]["Val_Land_Actul"].ToString().Trim();
                txtbuildingvalueActual.Text = ds.Tables[0].Rows[0]["Val_Build_Actul"].ToString().Trim();
                txtPlantvalueActual.Text = ds.Tables[0].Rows[0]["Val_Plant_Actul"].ToString().Trim();
                HdfLblEnt_is.Value = ds.Tables[0].Rows[0]["Ent_is"].ToString().Trim();
                LblEnt_is.Text = ds.Tables[0].Rows[0]["Ent_is"].ToString().Trim();
                CalculatationEnterprise();
                CalculatationEnterprisePrjCost();
                if (ds.Tables[0].Rows[0]["intLineofActivityid"].ToString().Trim() != "" && ds.Tables[0].Rows[0]["intLineofActivityid"].ToString().Trim() != null)
                {
                    ddlintLineofActivity.SelectedValue = ddlintLineofActivity.Items.FindByValue(ds.Tables[0].Rows[0]["intLineofActivityid"].ToString().Trim()).Value;
                }
                if (ddlintLineofActivity.SelectedIndex == 0)
                {
                    HdfLblPol_Category.Value = "";
                    LblPol_Category.Text = "";
                    //trFallinPolution.Visible = false;
                }
                else
                {
                    DataSet dsct = new DataSet();
                    dsct = Gen.GetCategoryType(ddlintLineofActivity.SelectedValue);
                    if (dsct.Tables[0].Rows.Count > 0)
                    {

                        if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "O")
                        {
                            HdfLblPol_Category.Value = "Orange";
                            LblPol_Category.Text = "<font color=Orange>Orange</font>";
                            // trFallinPolution.Visible = false;

                        }
                        else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "R")
                        {
                            HdfLblPol_Category.Value = "Red";
                            LblPol_Category.Text = "<font color=Red>Red</font>";
                            // trFallinPolution.Visible = false;
                        }
                        else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "G")
                        {
                            HdfLblPol_Category.Value = "Green";
                            //trFallinPolution.Visible = true;
                            LblPol_Category.Text = "<font color=Green>Green</font>";
                        }
                        else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "W")
                        {
                            HdfLblPol_Category.Value = "White";
                            //trFallinPolution.Visible = true;
                            LblPol_Category.Text = "<font color=Green>White</font>";
                        }
                    }
                    else
                    {
                        HdfLblPol_Category.Value = "";
                        LblPol_Category.Text = "";
                        //trFallinPolution.Visible = false;
                    }


                }
            }
            DataSet dscheck = new DataSet();
            dscheck = Gen.GetShowRenewalQuestionaries(Session["uid"].ToString().Trim(),"");
            if (dscheck.Tables[0].Rows.Count > 0)
            {
                Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
            }
            else
            {
                Session["Applid"] = "0";
            }

            if (Convert.ToInt32(dscheck.Tables[0].Rows[0]["Approval_Status"].ToString()) >= 3)
            {

                ResetFormControl(this);

            }
            if (ddlintLineofActivity.SelectedValue == "--Select--")
            {
                ddlintLineofActivity.Enabled = true;
            }
        }

    }

    public void ResetFormControl(Control parent)
    {
        foreach (Control c in parent.Controls)
        {
            if (c.Controls.Count > 0)
            {
                ResetFormControl(c);
            }
            else
            {
                switch (c.GetType().ToString())
                {
                    case "System.Web.UI.WebControls.TextBox":
                        ((TextBox)c).ReadOnly = true;
                        break;

                    case "System.Web.UI.WebControls.DropDownList":

                        if (((DropDownList)c).Items.Count > 0)
                        {
                            ((DropDownList)c).Enabled = false;
                        }
                        break;
                    case "System.Web.UI.WebControls.FileUpload":
                        ((FileUpload)c).Enabled = false;
                        break;
                    case "System.Web.UI.WebControls.RadioButtonList":
                        ((RadioButtonList)c).Enabled = false;
                        break;
                }
            }
        }
    }

    protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddldistrict.SelectedValue.ToString() != "--Select--")
        {
            getMandals();
        }
        else
        {

        }
    }
    protected void ddlvillage_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMandal.SelectedValue.ToString() != "--Select--")
        {
            getVillages();

        }
        else
        {
            ddlvillage.Items.Clear();
            ddlvillage.Items.Insert(0, "--Select--");

        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmRenewalDetail.aspx");
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int result = 0; string policeNoc = "";
            if (trpolicedetails.Visible == true)
            {
                policeNoc = "Y";
            }
            else if (trpolicedetails.Visible == false)
            {
                policeNoc = "N";
            }
            if (ddlcurrencytype.SelectedValue == "0")
            {
                lblmsg0.Text = "Please Select Currency Type";
                Failure.Visible = true;
                return;
            }
            if (txtPincode0.Text.Length.ToString() != "6")
            {
                lblmsg0.Text = "<font color='red'>Pin number length must be exactly 6 characters!</font>";
                //  this.Clear();
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            if (txtmobileNo.Text.Length.ToString() != "10")
            {
                lblmsg0.Text = "<font color='red'>Mobile number length must be exactly 10 characters!</font>";
                //  this.Clear();
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            string uidno = "";
            if (ViewState["uidno"] != null && ViewState["uidno"] != "")
            {
                uidno = ViewState["uidno"].ToString();
            }

            DataSet dsv4 = new DataSet();
            dsv4 = Gen.GetShowApprovalandFeesEnterPriseAmount("33", LblEnt_is.Text, txtPlantvalue.Text, txttotal.Text, "0");
            dsv4.Tables[0].Merge(dsv4.Tables[0]);
            string induamount ="";
            if (dsv4 != null)
            {
                induamount = dsv4.Tables[0].Rows[0]["Fees"].ToString();
            }
            result = Gen.InsertRenewalEnterprenurDetails(txtindustrialName.Text.Trim(), txtPromotor.Text.Trim(), txtSoromoter.Text.Trim(), ddldistrict.SelectedValue, ddlMandal.SelectedValue,
                ddlvillage.SelectedValue, txtstreetName.Text.Trim(), txtDoorNo.Text.Trim(), txtPincode0.Text.Trim(), txtmobileNo.Text.Trim(), txtEmail.Text.Trim(), txtdesignation.Text.Trim(),
                txtage.Text.Trim(), "2", Session["uid"].ToString().Trim(), uidno, Session["uid"].ToString(), Session["Applid"].ToString().Trim(),
                ddlSector.SelectedValue, txttotal.Text.Trim(), txtlandvalue.Text.Trim(), txtbuildingvalue.Text.Trim(), txtPlantvalue.Text.Trim(), LblEnt_is.Text.Trim(),
                ddlcurrencytype.SelectedItem.Text, txtlandvalueActul.Text.Trim(), txtbuildingvalueActual.Text.Trim(),
                txtPlantvalueActual.Text.Trim(), "0", ddlintLineofActivity.SelectedValue.ToString(), HdfLblPol_Category.Value,ddlcommissionerate.SelectedValue.ToString(),ddlzone.SelectedValue.ToString(), ddldivision.SelectedValue.ToString(), ddlpolicestation.SelectedValue.ToString(), ddltrafficzone.SelectedValue.ToString(), ddltrafficdivision.SelectedValue.ToString(), ddltrafficpolicestation.SelectedValue.ToString(),policeNoc);
            if (result > 0)
            {
                lblqueid.Text = Convert.ToString(result);
                lblmsg.Text = "<font color='green'>Submitted SuccessFully....!</font>";
                success.Visible = true;
                Failure.Visible = false;
            }

        }
        catch (Exception ex)
        {

        }
    }

    protected void btnprevious_Click(object sender, EventArgs e)
    {

    }
    protected void btnnext_Click(object sender, EventArgs e)
    {

        //Response.Redirect("frmRenewalService.aspx");
        int result = 0; string policeNoc = "";
        if (trpolicedetails.Visible == true)
        {
            policeNoc = "Y";
        }
        else if (trpolicedetails.Visible == false)
        {
            policeNoc = "N";
        }
        if (ddlcurrencytype.SelectedValue == "0")
        {
            lblmsg0.Text = "Please Select Currency Type";
            Failure.Visible = true;
            return;
        }
        if (txtPincode0.Text.Length.ToString() != "6")
        {
            lblmsg0.Text = "<font color='red'>Pin number length must be exactly 6 characters!</font>";
            //  this.Clear();
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (txtmobileNo.Text.Length.ToString() != "10")
        {
            lblmsg0.Text = "<font color='red'>Mobile number length must be exactly 10 characters!</font>";
            //  this.Clear();
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        string uidno = "";
        if (ViewState["uidno"] != null && ViewState["uidno"] != "")
        {
            uidno = ViewState["uidno"].ToString();
        }

        DataSet dsv4 = new DataSet();
        dsv4 = Gen.GetShowApprovalandFeesEnterPriseAmount("33", LblEnt_is.Text, txtPlantvalue.Text, txttotal.Text, "0");
        dsv4.Tables[0].Merge(dsv4.Tables[0]);
        string induamount = "";
        if (dsv4 != null)
        {
            induamount = dsv4.Tables[0].Rows[0]["Fees"].ToString();
        }
        result = Gen.InsertRenewalEnterprenurDetails(txtindustrialName.Text.Trim(), txtPromotor.Text.Trim(), txtSoromoter.Text.Trim(), ddldistrict.SelectedValue, ddlMandal.SelectedValue,
               ddlvillage.SelectedValue, txtstreetName.Text.Trim(), txtDoorNo.Text.Trim(), txtPincode0.Text.Trim(), txtmobileNo.Text.Trim(), txtEmail.Text.Trim(), txtdesignation.Text.Trim(),
               txtage.Text.Trim(), "2", Session["uid"].ToString().Trim(), uidno, Session["uid"].ToString(), Session["Applid"].ToString().Trim(),
               ddlSector.SelectedValue, txttotal.Text.Trim(), txtlandvalue.Text.Trim(), txtbuildingvalue.Text.Trim(), txtPlantvalue.Text.Trim(), LblEnt_is.Text.Trim(),
               ddlcurrencytype.SelectedItem.Text, txtlandvalueActul.Text.Trim(), txtbuildingvalueActual.Text.Trim(),
               txtPlantvalueActual.Text.Trim(), "0", ddlintLineofActivity.SelectedValue.ToString(), HdfLblPol_Category.Value, ddlcommissionerate.SelectedValue.ToString(), ddlzone.SelectedValue.ToString(), ddldivision.SelectedValue.ToString(), ddlpolicestation.SelectedValue.ToString(), ddltrafficzone.SelectedValue.ToString(), ddltrafficdivision.SelectedValue.ToString(), ddltrafficpolicestation.SelectedValue.ToString(), policeNoc);
        if (result > 0)
        {
            lblqueid.Text = Convert.ToString(result);
            lblmsg.Text = "<font color='green'>Submitted SuccessFully....!</font>";
            success.Visible = true;
            Failure.Visible = false;
        }
        Response.Redirect("frmpcbrenewal.aspx?intApplicationId=" + Session["Applid"].ToString() + "&next=" + "N");// + hdfID.Value

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
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }

    protected void getdistricts()
    {
        DataSet dsnew = new DataSet();

        dsnew = Gen.GetDistrictsbystate("31");
        ddldistrict.DataSource = dsnew.Tables[0];
        ddldistrict.DataTextField = "District_Name";
        ddldistrict.DataValueField = "District_Id";
        ddldistrict.DataBind();
        ddldistrict.Items.Insert(0, "--Select--");

    }

    void getMandals()
    {

        DataSet dsnew = new DataSet();

        dsnew = Gen.Getmandalsbydistrict(ddldistrict.SelectedValue.ToString());
        ddlMandal.DataSource = dsnew.Tables[0];
        ddlMandal.DataTextField = "Manda_lName";
        ddlMandal.DataValueField = "Mandal_Id";
        ddlMandal.DataBind();
        ddlMandal.Items.Insert(0, "--Select--");


    }

    void getVillages()
    {

        DataSet dsnew = new DataSet();

        dsnew = Gen.GetVillagebymandal(ddlMandal.SelectedValue.ToString());
        ddlvillage.DataSource = dsnew.Tables[0];
        ddlvillage.DataTextField = "Village_Name";
        ddlvillage.DataValueField = "Village_Id";
        ddlvillage.DataBind();
        ddlvillage.Items.Insert(0, "--Select--");


    }

    protected void ddlcurrencytype_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtlandvalueActul.Text = "0";
        txtlandvalue.Text = "0";
        txtbuildingvalueActual.Text = "0";
        txtbuildingvalue.Text = "0";
        txtPlantvalueActual.Text = "0";
        txtPlantvalue.Text = "0";
    }

    public void CalculatationEnterprisePrjCost()
    {

        if (txtlandvalue.Text.Trim() == "")
        {
            txtlandvalue.Text = "0";
        }

        if (txtbuildingvalue.Text.Trim() == "")
        {
            txtbuildingvalue.Text = "0";
        }

        if (txtPlantvalue.Text.Trim() == "")
        {
            txtPlantvalue.Text = "0";
        }
        txttotal.Text = Convert.ToString((Convert.ToDecimal(txtlandvalue.Text) + Convert.ToDecimal(txtbuildingvalue.Text) + Convert.ToDecimal(txtPlantvalue.Text)));
    }

    public void CalculatationEnterprise()
    {
        if (ddlSector.SelectedIndex != 0)
        {

            string TxtTot_PrjCostNewfinal = "0";
            string TxtVal_Plantnewfinal = "0";
            //if (lblfinaltotalvalue.Text == "")
            //{
            //    lblfinaltotalvalue.Text = "0";
            //}
            //if (lblplantotalexp.Text == "")
            //{
            //    lblplantotalexp.Text = "0";
            //}

            //if (ddlproposal.SelectedValue == "2")
            //{
            //    TxtTot_PrjCostNewfinal = lblfinaltotalvalue.Text;
            //    TxtVal_Plantnewfinal = lblplantotalexp.Text;
            //}
            //else
            //{
            TxtTot_PrjCostNewfinal = txttotal.Text;
            TxtVal_Plantnewfinal = txtPlantvalue.Text;
            //}
            if (TxtTot_PrjCostNewfinal == "")
            {
                TxtTot_PrjCostNewfinal = "0";
            }
            if (TxtVal_Plantnewfinal == "")
            {
                TxtVal_Plantnewfinal = "0";
            }


            lblmsg.Text = "";
            DataSet dsEnter = new DataSet();
            if (ddlSector.SelectedValue == "2")
            {
                if (Convert.ToDecimal(TxtTot_PrjCostNewfinal) >= Convert.ToDecimal("20000"))
                {
                    HdfLblEnt_is.Value = "Mega";

                    LblEnt_is.Text = "Mega";
                }
                else
                {
                    dsEnter = Gen.GetEnterPriseIs(TxtVal_Plantnewfinal, ddlSector.SelectedValue);
                    if (dsEnter.Tables[0].Rows.Count > 0)
                    {
                        HdfLblEnt_is.Value = dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
                        LblEnt_is.Text = dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
                    }
                    else
                    {
                        HdfLblEnt_is.Value = "";
                        LblEnt_is.Text = "";
                    }
                }
            }
            else if (ddlSector.SelectedValue == "1")
            {
                if (Convert.ToDecimal(TxtTot_PrjCostNewfinal) >= Convert.ToDecimal("20000"))
                {
                    HdfLblEnt_is.Value = "Mega";

                    LblEnt_is.Text = "Mega";
                }
                else
                {
                    dsEnter = Gen.GetEnterPriseIs(TxtVal_Plantnewfinal, ddlSector.SelectedValue);
                    if (dsEnter.Tables[0].Rows.Count > 0)
                    {
                        HdfLblEnt_is.Value = dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
                        LblEnt_is.Text = dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
                    }
                    else
                    {
                        HdfLblEnt_is.Value = "";
                        LblEnt_is.Text = "";
                    }
                }
            }
            else
            {
                HdfLblEnt_is.Value = "";
                LblEnt_is.Text = "";
            }

            //if (Convert.ToDecimal(TxtProp_Emp.Text) >= Convert.ToDecimal("1000"))
            //{
            //    HdfLblEnt_is.Value = "Mega";
            //    LblEnt_is.Text = "Mega";
            //}
            success.Visible = false;
        }
        else
        {
            HdfLblEnt_is.Value = "";
            LblEnt_is.Text = "";
            success.Visible = true;
            lblmsg.Text = "Please Select Sector of Enterprise";
        }


        //if (txtPlantvalue.Text == "" || txtPlantvalue.Text == "0")
        //{
        //    HdfLblEnt_is.Value = "";
        //    LblEnt_is.Text = "";
        //}
    }


    protected void txtlandvalue_TextChanged(object sender, EventArgs e)
    {
        CalculatationEnterprisePrjCost();
        CalculatationEnterprise();

    }
    protected void txtbuildingvalue_TextChanged(object sender, EventArgs e)
    {
        CalculatationEnterprisePrjCost();
        CalculatationEnterprise();

    }
    protected void txtPlantvalue_TextChanged(object sender, EventArgs e)
    {
        CalculatationEnterprisePrjCost();
        CalculatationEnterprise();
    }

    protected void txtlandvalueActul_TextChanged(object sender, EventArgs e)
    {
        if (ddlcurrencytype.SelectedValue != "0")
        {
            if (txtlandvalueActul.Text.TrimStart().TrimEnd() != "" && txtlandvalueActul.Text.TrimStart().TrimEnd() != "0")
            {
                txtlandvalue.Text = (Convert.ToDecimal(txtlandvalueActul.Text.Trim()) * Convert.ToDecimal(ddlcurrencytype.SelectedValue)).ToString();
                txtlandvalue_TextChanged(sender, e);
            }
        }
    }

    protected void txtbuildingvalueActual_TextChanged(object sender, EventArgs e)
    {
        if (ddlcurrencytype.SelectedValue != "0")
        {
            if (txtbuildingvalueActual.Text.TrimStart().TrimEnd() != "" && txtbuildingvalueActual.Text.TrimStart().TrimEnd() != "0")
            {
                txtbuildingvalue.Text = (Convert.ToDecimal(txtbuildingvalueActual.Text.Trim()) * Convert.ToDecimal(ddlcurrencytype.SelectedValue)).ToString();
                txtbuildingvalue_TextChanged(sender, e);
            }
        }
    }
    protected void txtPlantvalueActual_TextChanged(object sender, EventArgs e)
    {
        if (ddlcurrencytype.SelectedValue != "0")
        {
            if (txtPlantvalueActual.Text.TrimStart().TrimEnd() != "" && txtPlantvalueActual.Text.TrimStart().TrimEnd() != "0")
            {
                txtPlantvalue.Text = (Convert.ToDecimal(txtPlantvalueActual.Text.Trim()) * Convert.ToDecimal(ddlcurrencytype.SelectedValue)).ToString();
                txtPlantvalue_TextChanged(sender, e);
            }
        }
    }

    public void BindenterpriseSectors()
    {
        try
        {
            ddlSector.Items.Clear();
            DataSet dsSector = new DataSet();
            dsSector = objcommon.GetenterpriseSectors();
            if (dsSector != null && dsSector.Tables.Count > 0 && dsSector.Tables[0].Rows.Count > 0)
            {
                ddlSector.DataSource = dsSector.Tables[0];
                ddlSector.DataTextField = "EnterpriseSector";
                ddlSector.DataValueField = "EsectorId";
                ddlSector.DataBind();
                AddSelect(ddlSector);
            }
            else
            {
                ddlSector.Items.Clear();
                AddSelect(ddlSector);
            }
        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }

    public void BinCurrencyType()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlcurrencytype.Items.Clear();
            dsd = objcommon.GetCurrencymaster();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlcurrencytype.DataSource = dsd.Tables[0];
                ddlcurrencytype.DataValueField = "EmountInLakhs";
                ddlcurrencytype.DataTextField = "EmountType";
                ddlcurrencytype.DataBind();
                AddSelect(ddlcurrencytype);
                ddlcurrencytype.SelectedValue = "0.00001";
                ddlcurrencytype.Enabled = false;
            }
            else
            {
                AddSelect(ddlcurrencytype);
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }

    protected void ddlintLineofActivity_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlintLineofActivity.SelectedIndex == 0)
        {
            HdfLblPol_Category.Value = "";
            LblPol_Category.Text = "";

        }
        else
        {
            DataSet dsct = new DataSet();
            dsct = Gen.GetCategoryType(ddlintLineofActivity.SelectedValue);
            if (dsct.Tables[0].Rows.Count > 0)
            {
                if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "O")
                {
                    HdfLblPol_Category.Value = "Orange";
                    LblPol_Category.Text = "<font color=Orange>Orange</font>";
                    if (HdfLblEnt_is.Value == "Small" || HdfLblEnt_is.Value == "Micro")
                    {
                        //trFallinPolution.Visible = true;
                    }
                    else
                    {
                        //trFallinPolution.Visible = false;
                    }
                }
                else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "R")
                {
                    HdfLblPol_Category.Value = "Red";
                    LblPol_Category.Text = "<font color=Red>Red</font>";
                    //trFallinPolution.Visible = false;
                }
                else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "G")
                {
                    HdfLblPol_Category.Value = "Green";
                    //trFallinPolution.Visible = true;

                    LblPol_Category.Text = "<font color=Green>Green</font>";
                }
            }
            else
            {
                HdfLblPol_Category.Value = "";
                //trFallinPolution.Visible = false;
                LblPol_Category.Text = "";
            }
        }
        //hdnfocus.Value = ddlintLineofActivity.ClientID;
    }

    public void BindLineofActivityName()
    {
        try
        {
            ddlintLineofActivity.Items.Clear();
            DataSet dsc = new DataSet();
            dsc = Gen.GetCategoryDet();
            if (dsc != null && dsc.Tables.Count > 0 && dsc.Tables[0].Rows.Count > 0)
            {
                ddlintLineofActivity.DataSource = dsc.Tables[0];
                ddlintLineofActivity.DataValueField = "intLineofActivityid";
                ddlintLineofActivity.DataTextField = "LineofActivity_Name";
                ddlintLineofActivity.DataBind();
                ddlintLineofActivity.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlintLineofActivity.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }
    public DataSet GetZones(string commissionerateid)
    {
        DataSet Dsnew = new DataSet();
        SqlParameter[] pp = new SqlParameter[]
        {
             new SqlParameter("@COMMISSIONERATEID",SqlDbType.VarChar)
        };
        pp[0].Value = commissionerateid;
        Dsnew = Gen.GenericFillDs("GETZONES", pp);
        return Dsnew;
    }

    public void BindCommissionerates()
    {
        DataSet dscommission = new DataSet();
        dscommission = GetCommissionerates();
        if (dscommission.Tables[0].Rows.Count > 0)
        {
            ddlcommissionerate.DataSource = dscommission.Tables[0];
            ddlcommissionerate.DataTextField = "Commissionerate_Name";
            ddlcommissionerate.DataValueField = "Commissionerate_Id";
            ddlcommissionerate.DataBind();

            ddlcommissionerate.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }
    public DataSet GetCommissionerates()
    {
        DataSet Dsnew = new DataSet();

        Dsnew = Gen.GenericFillDs("GETCOMMISSIONERATES");
        return Dsnew;
    }
    protected void ddlcommissionerate_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dszone = new DataSet();
        dszone = GetZones(ddlcommissionerate.SelectedValue);
        if (dszone.Tables[0].Rows.Count > 0)
        {
            ddlzone.DataSource = dszone.Tables[0];
            ddlzone.DataTextField = "zone_name";
            ddlzone.DataValueField = "zone_id";
            ddlzone.DataBind();

            ddlzone.Items.Insert(0, new ListItem("--Select--", "0"));

        }
        DataSet dstrafficzone = new DataSet();
        dstrafficzone = GetTrafficZones(ddlcommissionerate.SelectedValue);
        if (dstrafficzone.Tables[0].Rows.Count > 0)
        {
            ddltrafficzone.DataSource = dstrafficzone.Tables[0];
            ddltrafficzone.DataTextField = "Traffic_zone_name";
            ddltrafficzone.DataValueField = "Traffic_zone_id";
            ddltrafficzone.DataBind();

            ddltrafficzone.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }
    public DataSet GetTrafficZones(string commissionerateid)
    {
        DataSet Dsnew = new DataSet();
        SqlParameter[] pp = new SqlParameter[]
        {
             new SqlParameter("@COMMISSIONERATE_ID",SqlDbType.VarChar)
        };
        pp[0].Value = commissionerateid;
        Dsnew = Gen.GenericFillDs("GETTRAFFICZONES", pp);
        return Dsnew;
    }
    protected void ddlzone_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dsdivision = new DataSet();
        dsdivision = GetDivisions(ddlzone.SelectedValue);
        if (dsdivision.Tables[0].Rows.Count > 0)
        {
            ddldivision.DataSource = dsdivision.Tables[0];
            ddldivision.DataTextField = "division_name";
            ddldivision.DataValueField = "division_id";
            ddldivision.DataBind();

            ddldivision.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }

    protected void ddldivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dspolice = new DataSet();
        dspolice = GetPoliceStatioons(ddlcommissionerate.SelectedValue, ddldivision.SelectedValue);
        if (dspolice.Tables[0].Rows.Count > 0)
        {
            ddlpolicestation.DataSource = dspolice.Tables[0];
            ddlpolicestation.DataTextField = "policestation_name";
            ddlpolicestation.DataValueField = "policestation_id";
            ddlpolicestation.DataBind();

            ddlpolicestation.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }
    public DataSet GetPoliceStatioons(string commissionerateid, string divisionid)
    {
        DataSet Dsnew = new DataSet();
        SqlParameter[] pp = new SqlParameter[]
        {
             new SqlParameter("@COMMISSIONERATE_ID",SqlDbType.VarChar),
             new SqlParameter("@DIVISION_ID",SqlDbType.VarChar)
        };
        pp[0].Value = commissionerateid;
        pp[1].Value = divisionid;
        Dsnew = Gen.GenericFillDs("GETPOLICESTATIONS", pp);
        return Dsnew;
    }
    public DataSet GetDivisions(string zoneid)
    {
        DataSet Dsnew = new DataSet();
        SqlParameter[] pp = new SqlParameter[]
        {
             new SqlParameter("@ZONEID",SqlDbType.VarChar)
        };
        pp[0].Value = zoneid;
        Dsnew = Gen.GenericFillDs("GETDIVISIONS", pp);
        return Dsnew;
    }

    protected void ddltrafficzone_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dstrafficdivision = new DataSet();
        dstrafficdivision = GetTrafficDivisions(ddltrafficzone.SelectedValue);
        if (dstrafficdivision.Tables[0].Rows.Count > 0)
        {
            ddltrafficdivision.DataSource = dstrafficdivision.Tables[0];
            ddltrafficdivision.DataTextField = "Traffic_division_name";
            ddltrafficdivision.DataValueField = "Traffic_division_id";
            ddltrafficdivision.DataBind();

            ddltrafficdivision.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }
    public DataSet GetTrafficDivisions(string trafficzoneid)
    {
        DataSet Dsnew = new DataSet();
        SqlParameter[] pp = new SqlParameter[]
        {
             new SqlParameter("@TRAFFICZONE_ID",SqlDbType.VarChar)
        };
        pp[0].Value = trafficzoneid;
        Dsnew = Gen.GenericFillDs("GETTRAFFICDIVISIONS", pp);
        return Dsnew;
    }

    protected void ddltrafficdivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dspolice = new DataSet();
        dspolice = GetTrafficPoliceStatioons(ddlcommissionerate.SelectedValue, ddltrafficdivision.SelectedValue);
        if (dspolice.Tables[0].Rows.Count > 0)
        {
            ddltrafficpolicestation.DataSource = dspolice.Tables[0];
            ddltrafficpolicestation.DataTextField = "Traffic_policestation_name";
            ddltrafficpolicestation.DataValueField = "Traffic_policestation_id";
            ddltrafficpolicestation.DataBind();

            ddltrafficpolicestation.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }
    public DataSet GetTrafficPoliceStatioons(string commissionerateid, string trafficdivisionid)
    {
        DataSet Dsnew = new DataSet();
        SqlParameter[] pp = new SqlParameter[]
        {
             new SqlParameter("@COMMISSIONERATE_ID",SqlDbType.VarChar),
             new SqlParameter("@TRAFFICDIVISION_ID",SqlDbType.VarChar)
        };
        pp[0].Value = commissionerateid;
        pp[1].Value = trafficdivisionid;
        Dsnew = Gen.GenericFillDs("GETTRAFFICPOLICESTATIONS", pp);
        return Dsnew;
    }
}