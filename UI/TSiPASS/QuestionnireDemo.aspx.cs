using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
//created by suresh as on 13-1-2016 
//tables is td_BDCDet,tbl_Users
//procedures CheckUserid,insrtBDC,deleteBDC,getBDCbyID

public partial class UI_TSiPASS_QuestionnireDemo : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    CommonBL objcommon = new CommonBL();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    decimal TotalFee = Convert.ToDecimal("0");
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet dscheck = new DataSet();
        if (Session.Count <= 0)
        {
            Response.Redirect("../../Index.aspx");
        }
        if (!IsPostBack)
        {
            Label7.Visible = false;
            RdPol_Indus.Visible = false;

            dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
            if (dscheck.Tables[0].Rows.Count > 0)
            {
                Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
            }
            else
            {
                Session["Applid"] = "0";
            }
            DataSet dsver = new DataSet();
            dsver = Gen.Getverifyofque9(Session["Applid"].ToString());
            if (dsver != null && dsver.Tables.Count > 0 && dsver.Tables[0].Rows.Count > 0)
            {
                // string res = Gen.RetriveStatus(Session["Applid"].ToString()); Commented By CMS
                string res = dsver.Tables[0].Rows[0]["Appl_Status"].ToString();
                ////string res = Gen.RetriveStatus("1002");
                if (res == "3" || Convert.ToInt32(res) >= 3)
                {
                    ResetFormControl(this);
                    BtnClear.Visible = false;
                    BtnSave.Visible = false;
                    BtnSave1.Visible = false;
                }
            }

            BindConstitutionunit();
            BindenterpriseSectors();
            BindDistricts();
            BindLineofActivityName();
            BindHPPowerddl();
            Bindmesurments();
            BinCurrencyType();
            BindLabourApplication();

            Session["Applid"] = "0";

            ddlLoc_of_unit.Items.Clear();
            AddSelect(ddlLoc_of_unit);
            //ddlLoc_of_unit.Items.Insert(0, "--Select--");
            BtnSave.Visible = false;
            fillDetails(dscheck);
            // CalcFees();
            hdnfocus.Value = ddlConst_of_unit.ClientID;
        }

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {

        }
    }

    #region Methods
    public void BindConstitutionunit()
    {
        try
        {
            ddlConst_of_unit.Items.Clear();
            DataSet dsConstofunit = new DataSet();
            dsConstofunit = objcommon.GetConstitutionunit();
            if (dsConstofunit != null && dsConstofunit.Tables.Count > 0 && dsConstofunit.Tables[0].Rows.Count > 0)
            {
                ddlConst_of_unit.DataSource = dsConstofunit.Tables[0];
                ddlConst_of_unit.DataTextField = "ConstitutionUnit";
                ddlConst_of_unit.DataValueField = "CunitId";
                ddlConst_of_unit.DataBind();
                AddSelect(ddlConst_of_unit);
            }
            else
            {
                ddlConst_of_unit.Items.Clear();
                AddSelect(ddlConst_of_unit);
            }
        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }
    public void BindenterpriseSectors()
    {
        try
        {
            ddlSector_Ent.Items.Clear();
            DataSet dsSector = new DataSet();
            dsSector = objcommon.GetenterpriseSectors();
            if (dsSector != null && dsSector.Tables.Count > 0 && dsSector.Tables[0].Rows.Count > 0)
            {
                ddlSector_Ent.DataSource = dsSector.Tables[0];
                ddlSector_Ent.DataTextField = "EnterpriseSector";
                ddlSector_Ent.DataValueField = "EsectorId";
                ddlSector_Ent.DataBind();
                AddSelect(ddlSector_Ent);
            }
            else
            {
                ddlSector_Ent.Items.Clear();
                AddSelect(ddlSector_Ent);
            }
        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }
    public void BindApplicationType(int Loc_of_unit)
    {
        try
        {
            ddlAppl_Type.Items.Clear();
            DataSet dsApplicationType = new DataSet();
            dsApplicationType = objcommon.GetApplicationType(Loc_of_unit);
            if (dsApplicationType != null && dsApplicationType.Tables.Count > 0 && dsApplicationType.Tables[0].Rows.Count > 0)
            {
                ddlAppl_Type.DataSource = dsApplicationType.Tables[0];
                ddlAppl_Type.DataTextField = "ApplicationType";
                ddlAppl_Type.DataValueField = "AtypeId";
                ddlAppl_Type.DataBind();
                if (dsApplicationType.Tables[0].Rows.Count > 1)
                    AddSelect(ddlAppl_Type);
                trApplType.Visible = true;
            }
            else
            {
                trApplType.Visible = false;
                ddlAppl_Type.Items.Clear();
                AddSelect(ddlAppl_Type);
            }
        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }
    public void BindDistricts()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlProp_intDistrictid.Items.Clear();
            dsd = Gen.GetDistrictsWithoutHYD();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlProp_intDistrictid.DataSource = dsd.Tables[0];
                ddlProp_intDistrictid.DataValueField = "District_Id";
                ddlProp_intDistrictid.DataTextField = "District_Name";
                ddlProp_intDistrictid.DataBind();
                ddlProp_intDistrictid.Items.Insert(0, "--District--");
            }
            else
            {
                ddlProp_intDistrictid.Items.Insert(0, "--District--");
            }
        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
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
    public void BindHPPowerddl()
    {
        try
        {
            ddlPower_Req.Items.Clear();
            DataSet dsApplicationType = new DataSet();
            dsApplicationType = objcommon.GetHPPowerdetails();
            if (dsApplicationType != null && dsApplicationType.Tables.Count > 0 && dsApplicationType.Tables[0].Rows.Count > 0)
            {
                ddlPower_Req.DataSource = dsApplicationType.Tables[0];
                ddlPower_Req.DataTextField = "HP_PowerReq";
                ddlPower_Req.DataValueField = "Id";
                ddlPower_Req.DataBind();
                AddSelect(ddlPower_Req);
            }
            else
            {
                ddlPower_Req.Items.Clear();
                AddSelect(ddlPower_Req);
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
            }
            else
            {
                AddSelect(ddlcurrencytype);
            }
        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }
    public void Bindmesurments()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddllandmesurements.Items.Clear();
            dsd = objcommon.GetMeasureMents();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddllandmesurements.DataSource = dsd.Tables[0];
                ddllandmesurements.DataValueField = "InSquareMeters";
                ddllandmesurements.DataTextField = "measurement";
                ddllandmesurements.DataBind();
                AddSelect(ddllandmesurements);
            }
            else
            {
                AddSelect(ddllandmesurements);
            }
        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
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
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";

        }
    }
    #endregion
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

                    case "System.Web.UI.WebControls.CheckBoxList":
                        ((CheckBoxList)c).Enabled = false;
                        break;
                }
            }
        }
    }
    public void fillDetails(DataSet dscheck)
    {
        //DataSet dscheck = new DataSet();  Commented by CMS
        //dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());   Commented by CMS
        if (dscheck.Tables[0].Rows.Count > 0)
        {
            ddlConst_of_unit.SelectedValue = ddlConst_of_unit.Items.FindByValue(dscheck.Tables[0].Rows[0]["Const_of_unit"].ToString().Trim()).Value;
            ddlSector_Ent.SelectedValue = ddlSector_Ent.Items.FindByValue(dscheck.Tables[0].Rows[0]["Sector_Ent"].ToString().Trim()).Value;
            if (dscheck.Tables[0].Rows[0]["Tot_Extent"].ToString().Trim() != "" && dscheck.Tables[0].Rows[0]["Tot_Extent"].ToString().Trim() != "0" && dscheck.Tables[0].Rows[0]["TypeofMesurement"].ToString() != "")
            {
                ddllandmesurements.SelectedValue = ddllandmesurements.Items.FindByText(dscheck.Tables[0].Rows[0]["TypeofMesurement"].ToString().Trim()).Value;
                ddllandmesurements_SelectedIndexChanged(this, EventArgs.Empty);
                TxtTot_ExtentNew.Text = dscheck.Tables[0].Rows[0]["LandActual_Value"].ToString().Trim();
                txtgunthas.Text = dscheck.Tables[0].Rows[0]["Gunthas_Value"].ToString().Trim();
                //if (TxtTot_ExtentNew.Text != "")
                //{
                //    TxtTot_ExtentNew.Text = TxtTot_ExtentNew.Text.Substring(0, TxtTot_ExtentNew.Text.IndexOf('.')) + TxtTot_ExtentNew.Text.Substring(TxtTot_ExtentNew.Text.IndexOf('.'), 4);
                //}
            }
            TxtTot_Extent.Text = dscheck.Tables[0].Rows[0]["Tot_Extent"].ToString().Trim();
            //lavanya
            string IALA_Flag = dscheck.Tables[0].Rows[0]["IALA_Flag"].ToString().Trim(); //lavanya
            string Iala_Code = dscheck.Tables[0].Rows[0]["Iala_Code"].ToString().Trim();
            if (IALA_Flag != null && IALA_Flag == "Y")
            {
                rdIaLa_Lst.SelectedValue = "Y";
                trIndustries.Visible = true;
                rdIaLa_Lst_SelectedIndexChanged(this, EventArgs.Empty);
            }
            else
            {
                rdIaLa_Lst.SelectedValue = "N";
                trIndustries.Visible = true;
                rdIaLa_Lst_SelectedIndexChanged(this, EventArgs.Empty);
            }
            ddlProp_intDistrictid.SelectedValue = dscheck.Tables[0].Rows[0]["Prop_intDistrictid"].ToString().Trim();
            EventArgs e = new EventArgs();
            object sender = new object();
            ddlProp_intDistrictid_SelectedIndexChanged(this, EventArgs.Empty);
            if (Iala_Code != null && Iala_Code != "0" && rdIaLa_Lst.SelectedValue == "Y") //lavanya
                ddlIndustrialParkName.SelectedValue = Iala_Code;
            string LabourAct_Id = dscheck.Tables[0].Rows[0]["LabourAct_Id"].ToString().Trim();
            if (LabourAct_Id != null && LabourAct_Id != "")
            {
                string[] values = LabourAct_Id.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    for (int j = 0; j < ChkLabour_Application.Items.Count; j++)
                    {
                        if (ChkLabour_Application.Items[j].Value == values[i].Trim())
                        {
                            ChkLabour_Application.Items[j].Selected = true;
                        }
                    }
                }
            }
            //if (ddlProp_intDistrictid.SelectedIndex == 0)
            //{
            //    ddlProp_intMandalid.Items.Clear();
            //    ddlProp_intMandalid.Items.Insert(0, "--Mandal--");
            //    ChkWater_reg_from.Items.Clear();
            //    ChkWater_reg_from.Items.Insert(0, new ListItem("New Bore well", "New Bore well"));
            //    ChkWater_reg_from.Items.Insert(1, new ListItem("HMWS & SB", "HMWS & SB"));
            //    ChkWater_reg_from.Items.Insert(2, new ListItem("Rivers/Canals", "Rivers/Canals"));
            //}
            //else
            //{
            //    ddlProp_intMandalid.Items.Clear();
            //    DataSet dsm = new DataSet();
            //    dsm = Gen.GetMandals(ddlProp_intDistrictid.SelectedValue);
            //    if (dsm.Tables[0].Rows.Count > 0)
            //    {
            //        ddlProp_intMandalid.DataSource = dsm.Tables[0];
            //        ddlProp_intMandalid.DataValueField = "Mandal_Id";
            //        ddlProp_intMandalid.DataTextField = "Manda_lName";
            //        ddlProp_intMandalid.DataBind();
            //        ddlProp_intMandalid.Items.Insert(0, "--Mandal--");
            //    }
            //    else
            //    {
            //        ddlProp_intMandalid.Items.Clear();
            //        ddlProp_intMandalid.Items.Insert(0, "--Mandal--");
            //    }
            //}
            ddlProp_intMandalid.SelectedValue = ddlProp_intMandalid.Items.FindByValue(dscheck.Tables[0].Rows[0]["Prop_intMandalid"].ToString().Trim()).Value;
            ddlProp_intMandalid_SelectedIndexChanged(sender, e);
            //if (ddlProp_intMandalid.SelectedIndex == 0)
            //{

            //    ddlProp_intVillageid.Items.Clear();
            //    ddlProp_intVillageid.Items.Insert(0, "--Village--");
            //}
            //else
            //{
            //    ddlProp_intVillageid.Items.Clear();
            //    DataSet dsv = new DataSet();
            //    dsv = Gen.GetVillages(ddlProp_intMandalid.SelectedValue);
            //    if (dsv.Tables[0].Rows.Count > 0)
            //    {
            //        ddlProp_intVillageid.DataSource = dsv.Tables[0];
            //        ddlProp_intVillageid.DataValueField = "Village_Id";
            //        ddlProp_intVillageid.DataTextField = "Village_Name";
            //        ddlProp_intVillageid.DataBind();
            //        ddlProp_intVillageid.Items.Insert(0, "--Village--");
            //    }
            //    else
            //    {
            //        ddlProp_intVillageid.Items.Clear();
            //        ddlProp_intVillageid.Items.Insert(0, "--Village--");
            //    }

            //    DataSet dsss = new DataSet();
            //    dsss = Gen.GetShowLOcationofUnit(ddlProp_intDistrictid.SelectedValue, ddlProp_intMandalid.SelectedValue);
            //    if (dsss.Tables[0].Rows.Count > 0)
            //    {
            //        if (dsss.Tables[0].Rows[0][0].ToString().Trim() == "1")
            //        {
            //            ddlLoc_of_unit.Items.Clear();
            //            ddlLoc_of_unit.Items.Insert(0, "--Select--");
            //            ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of HMDA (HMDA list of villages link)", "1"));
            //            ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));

            //            //ChkWater_reg_from.Items[1].Selected = true;
            //            //ChkWater_reg_from.Items[1].Enabled = true;





            //        }
            //        else if (dsss.Tables[0].Rows[0][0].ToString().Trim() == "2")
            //        {
            //            ddlLoc_of_unit.Items.Clear();
            //            ddlLoc_of_unit.Items.Insert(0, "--Select--");
            //            ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of DT&CP", "2"));
            //            ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
            //            //ChkWater_reg_from.Items[1].Selected = false;
            //            //ChkWater_reg_from.Items[1].Enabled = false;



            //        }
            //        else if (dsss.Tables[0].Rows[0][0].ToString().Trim() == "3")
            //        {
            //            ddlLoc_of_unit.Items.Clear();
            //            ddlLoc_of_unit.Items.Insert(0, "--Select--");
            //            ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of KUDA", "3"));
            //            ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
            //            //ChkWater_reg_from.Items[1].Selected = false;
            //            //ChkWater_reg_from.Items[1].Enabled = false;

            //            if (ddlProp_intDistrictid.SelectedValue.ToString() == "9" || ddlProp_intDistrictid.SelectedValue.ToString() == "3")
            //            {
            //                ddlLoc_of_unit.Items.Insert(3, new ListItem("Within the purview of DT&CP", "2"));

            //            }



            //        }
            //        else if (dsss.Tables[0].Rows[0][0].ToString().Trim() == "5")
            //        {
            //            ddlLoc_of_unit.Items.Clear();
            //            ddlLoc_of_unit.Items.Insert(0, "--Select--");
            //            ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of GM DIC,HYD", "5"));
            //            ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
            //            //ChkWater_reg_from.Items[1].Selected = false;
            //            //ChkWater_reg_from.Items[1].Enabled = false;



            //        }
            //        else
            //        {
            //            ddlLoc_of_unit.Items.Clear();
            //            ddlLoc_of_unit.Items.Insert(0, "--Select--");
            //            ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of DT&CP", "2"));
            //            ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
            //        }
            //    }
            //    else
            //    {
            //        ddlLoc_of_unit.Items.Clear();
            //        ddlLoc_of_unit.Items.Insert(0, "--Select--");
            //    }
            //    DataSet dscess = Gen.getGWMCVillages(ddlProp_intVillageid.SelectedValue);
            //    if (dscess.Tables[0].Rows.Count > 0)
            //    {
            //        ddlLoc_of_unit.Items.Clear();
            //        ddlLoc_of_unit.Items.Insert(0, "--Select--");
            //        ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of KUDA", "3"));
            //        ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));

            //    }
            //}
            ddlProp_intVillageid.SelectedValue = ddlProp_intVillageid.Items.FindByValue(dscheck.Tables[0].Rows[0]["Prop_intVillageid"].ToString().Trim()).Value;
            ddlProp_intVillageid_SelectedIndexChanged(this, EventArgs.Empty); //lavanya
            TxtProp_Emp.Text = dscheck.Tables[0].Rows[0]["Prop_Emp"].ToString().Trim();
            if (dscheck.Tables[0].Rows[0]["CurrencyType"].ToString() != "")
            {
                ddlcurrencytype.SelectedValue = ddlcurrencytype.Items.FindByText(dscheck.Tables[0].Rows[0]["CurrencyType"].ToString().Trim()).Value;
            }
            if (dscheck.Tables[0].Rows[0]["ProposalForQue"].ToString() != "")
            {
                ddlproposal.SelectedValue = ddlproposal.Items.FindByText(dscheck.Tables[0].Rows[0]["ProposalForQue"].ToString().Trim()).Value;
                ddlproposal_SelectedIndexChanged(sender, e);
            }
            else
            {
                ddlproposal.SelectedValue = "1";
                ddlproposal_SelectedIndexChanged(sender, e);
            }

            TxtVal_Land_Actual.Text = dscheck.Tables[0].Rows[0]["Val_Land_Actul"].ToString().Trim();
            TxtVal_Build_Actual.Text = dscheck.Tables[0].Rows[0]["Val_Build_Actul"].ToString().Trim();
            TxtVal_Plant_Actual.Text = dscheck.Tables[0].Rows[0]["Val_Plant_Actul"].ToString().Trim();

            TxtVal_Land.Text = dscheck.Tables[0].Rows[0]["Val_Land"].ToString().Trim();
            TxtVal_Build.Text = dscheck.Tables[0].Rows[0]["Val_Build"].ToString().Trim();
            TxtVal_Plant.Text = dscheck.Tables[0].Rows[0]["Val_Plant"].ToString().Trim();

            TxtTot_PrjCost.Text = dscheck.Tables[0].Rows[0]["Tot_PrjCost"].ToString().Trim();

            //Expansion
            TxtVal_Land_ActualExpansion.Text = dscheck.Tables[0].Rows[0]["Val_Land_ActulExpansion"].ToString().Trim();
            TxtVal_Build_ActualExpn.Text = dscheck.Tables[0].Rows[0]["Val_Build_ActulExpansion"].ToString().Trim();
            TxtVal_Plant_ActualExpansion.Text = dscheck.Tables[0].Rows[0]["Val_Plant_ActulExpansion"].ToString().Trim();

            TxtVal_LandExpansion.Text = dscheck.Tables[0].Rows[0]["Val_LandExpansion"].ToString().Trim();
            TxtVal_BuildExpanstion.Text = dscheck.Tables[0].Rows[0]["Val_BuildExpansion"].ToString().Trim();
            TxtVal_PlantExpanstion.Text = dscheck.Tables[0].Rows[0]["Val_PlantExpansion"].ToString().Trim();

            txtlbltotalprojectcostexpanstion.Text = dscheck.Tables[0].Rows[0]["Tot_PrjCostExpansion"].ToString().Trim();
            //end

            HdfLblEnt_is.Value = dscheck.Tables[0].Rows[0]["Ent_is"].ToString().Trim();
            CalculatationEnterprisePrjCost();
            CalculatationEnterprise();
            CalculatationEnterprisePrjCostExpansion();
            ddlintLineofActivity.SelectedValue = ddlintLineofActivity.Items.FindByValue(dscheck.Tables[0].Rows[0]["intLineofActivity"].ToString().Trim()).Value;



            if (ddlintLineofActivity.SelectedIndex == 0)
            {
                HdfLblPol_Category.Value = "";
                LblPol_Category.Text = "";
                //   trFallinPolution.Visible = false;
                RdPol_Indus.Enabled = false;
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
                            //   trFallinPolution.Visible = true;
                        }
                        else
                        {
                            //     trFallinPolution.Visible = false;
                        }

                    }
                    else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "R")
                    {
                        HdfLblPol_Category.Value = "Red";
                        LblPol_Category.Text = "<font color=Red>Red</font>";
                        //  trFallinPolution.Visible = false;
                    }
                    else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "G")
                    {
                        HdfLblPol_Category.Value = "Green";
                        // trFallinPolution.Visible = true;
                        LblPol_Category.Text = "<font color=Green>Green</font>";
                    }
                    else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "W")
                    {
                        HdfLblPol_Category.Value = "White";
                        //   trFallinPolution.Visible = true;
                        LblPol_Category.Text = "White";
                    }
                    //if (HdfLblEnt_is.Value == "Small" || HdfLblEnt_is.Value == "Micro")
                    //{
                    //    if (dsct.Tables[0].Rows[0]["Flag"].ToString().Trim() == "Y")
                    //    {
                    //        RdPol_Indus.SelectedValue = "Y";

                    //    }
                    //    else
                    //    {
                    //        RdPol_Indus.SelectedValue = "N";

                    //    }
                    //}
                    //else
                    //{ RdPol_Indus.SelectedValue = "Y"; }
                    RdPol_Indus.Enabled = false;
                }

                else
                {
                    HdfLblPol_Category.Value = "";
                    LblPol_Category.Text = "";
                    RdPol_Indus.Enabled = false;
                    trFallinPolution.Visible = false;
                }

            }
            if (dscheck.Tables[0].Rows[0]["Pol_Indus"].ToString().Trim() != "")
            {

                RdPol_Indus.SelectedValue = RdPol_Indus.Items.FindByValue(dscheck.Tables[0].Rows[0]["Pol_Indus"].ToString().Trim()).Value;
            }
            //  HdfLblPol_Category.Value=dscheck.Tables[0].Rows[0]["Tot_Extent"].ToString().Trim();
            if (dscheck.Tables[0].Rows[0]["Power_Req"].ToString().Trim() != "")
            {
                ddlPower_Req.SelectedValue = ddlPower_Req.Items.FindByValue(dscheck.Tables[0].Rows[0]["Power_Req"].ToString().Trim()).Value;
            }
            if (dscheck.Tables[0].Rows[0]["Loc_of_unit"].ToString().Trim() != "")
            {
                //ListItem li = new ListItem();
                //li.Value = ddlLoc_of_unit.Items.FindByValue(dscheck.Tables[0].Rows[0]["Loc_of_unit"].ToString().Trim()).Value;
                //li.Text
                ListItem item = ddlLoc_of_unit.Items.FindByText(dscheck.Tables[0].Rows[0]["Loc_of_unit"].ToString().Trim());
                if (item != null)
                {
                    //ddlProductGrp.Items.FindByText("Product").Selected = true;
                    ddlLoc_of_unit.SelectedValue = ddlLoc_of_unit.Items.FindByValue(dscheck.Tables[0].Rows[0]["Loc_of_unit"].ToString().Trim()).Value;
                    ddlLoc_of_unit_SelectedIndexChanged(sender, e);
                }

            }

            TxtWater_req_Perday.Text = dscheck.Tables[0].Rows[0]["Water_req_Perday"].ToString().Trim();
            if (dscheck.Tables[0].Rows[0]["Water_reg_from1"].ToString().Trim() != "")
            {
                ChkWater_reg_from.Items[0].Selected = true;
            }
            if (dscheck.Tables[0].Rows[0]["Water_reg_from2"].ToString().Trim() != "")
            {
                ChkWater_reg_from.Items[1].Selected = true;
            }
            if (dscheck.Tables[0].Rows[0]["Water_reg_from3"].ToString().Trim() != "")
            {
                ChkWater_reg_from.Items[2].Selected = true;
            }
            //  chkwatera=dscheck.Tables[0].Rows[0]["Tot_Extent"].ToString().Trim(); 
            //  chkwaterb=dscheck.Tables[0].Rows[0]["Tot_Extent"].ToString().Trim(); 
            //  chkwaterc=dscheck.Tables[0].Rows[0]["Tot_Extent"].ToString().Trim();

            RdDo_Store_Kerosine.SelectedValue = RdDo_Store_Kerosine.Items.FindByValue(dscheck.Tables[0].Rows[0]["Do_Store_Kerosine"].ToString().Trim()).Value;

            RdGen_Reqired.SelectedValue = RdGen_Reqired.Items.FindByValue(dscheck.Tables[0].Rows[0]["Gen_Reqired"].ToString().Trim()).Value;
            TxtHight_Build.Text = dscheck.Tables[0].Rows[0]["Hight_Build"].ToString().Trim();
            TxtBuilt_up_Area.Text = dscheck.Tables[0].Rows[0]["Built_up_Area"].ToString().Trim();
            RdFall_in_Municipal.SelectedValue = RdFall_in_Municipal.Items.FindByValue(dscheck.Tables[0].Rows[0]["Fall_in_Municipal"].ToString().Trim()).Value;
            RdProp_Site.SelectedValue = RdProp_Site.Items.FindByValue(dscheck.Tables[0].Rows[0]["Prop_Site"].ToString().Trim()).Value;
            if (RdProp_Site.SelectedValue.ToString().Trim() == "Y")
            {
                trtrees.Visible = true;
                tr4.Visible = true;
                Txt_NoofTrees.Text = "";
                if (dscheck.Tables[0].Rows[0]["NonExmTrees"].ToString().Trim() != "")
                {
                    RdbExecpted.SelectedValue = RdbExecpted.Items.FindByValue(dscheck.Tables[0].Rows[0]["NonExmTrees"].ToString().Trim()).Value;
                }
            }
            else
            {
                Txt_NoofTrees.Text = "";
                trtrees.Visible = false;
                tr4.Visible = false;
                if (dscheck.Tables[0].Rows[0]["NonExmTrees"].ToString().Trim() != "")
                {
                    RdbExecpted.SelectedValue = RdbExecpted.Items.FindByValue(dscheck.Tables[0].Rows[0]["NonExmTrees"].ToString().Trim()).Value;
                }
            }

            Txt_NoofTrees.Text = dscheck.Tables[0].Rows[0]["NoofTrees"].ToString().Trim();
            TxtnameofUnit.Text = dscheck.Tables[0].Rows[0]["nameofunit"].ToString();
            if (dscheck.Tables[0].Rows[0]["Appl_Type"].ToString().Trim() != "")
            {
                ListItem itemAPPLITYPE = ddlAppl_Type.Items.FindByText(dscheck.Tables[0].Rows[0]["Appl_Type"].ToString().Trim());
                if (itemAPPLITYPE != null)
                {
                    //ddlProductGrp.Items.FindByText("Product").Selected = true;
                    ddlAppl_Type.SelectedValue = ddlAppl_Type.Items.FindByValue(dscheck.Tables[0].Rows[0]["Appl_Type"].ToString().Trim()).Value;
                }
            }


            if (dscheck.Tables[1].Rows.Count > 0)
            {
                dvfeedetails.Visible = true;
                grdDetails.DataSource = dscheck.Tables[1];
                grdDetails.DataBind();
            }
            else
            {
                dvfeedetails.Visible = false;
            }
            Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
            BtnClear.Visible = false;
            if (ddlLoc_of_unit.SelectedIndex != 0)
            {
                if (ddlLoc_of_unit.SelectedValue.ToString().Trim() == "1")
                {
                    trApplType.Visible = true;
                }
                else
                {
                    trApplType.Visible = false;
                }
            }
            else
            {
                trApplType.Visible = false;
            }
            CalcFeesNewDepartment();
        }
        else
        {
        }
    }

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {

        string res1 = Gen.RetriveStatus(Session["Applid"].ToString());
        ////string res = Gen.RetriveStatus("1002");
        if (res1 == "3" || Convert.ToInt32(res1) >= 3)
        {
            Response.Redirect("frmQuesstionniareReg.aspx");
        }

        Label7.Visible = false;
        RdPol_Indus.Visible = false;
        BtnSave.Visible = true;
        CalcFees();
        // ClientScript.RegisterStartupScript(GetType(), "hwa", "paginationClickHandler(event)", true);
    }

    public void CalcFees()
    {

        try
        {

            DataSet dss = new DataSet();
            string Enterpriseid = "0";
            dss = Gen.GetEnterprisebyID(HdfLblEnt_is.Value);
            if (dss.Tables[0].Rows.Count > 0)
            {
                Enterpriseid = dss.Tables[0].Rows[0]["intEnterpriseType"].ToString();
            }

            string SearchVerfi = "";
            DataSet dsa = new DataSet();
            DataSet dsv = new DataSet();
            dsv = null;

            dsv = Gen.GetShowApprovalandFees("0", Enterpriseid);
            DataSet dsMunicial = new DataSet();
            if (RdFall_in_Municipal.SelectedValue.ToString().Trim() == "R")
            {
                dsMunicial = Gen.GetShowApprovalandFees("2", Enterpriseid);
                dsv.Tables[0].Merge(dsMunicial.Tables[0]);
            }
            DataSet dsv1 = new DataSet();
            //if (ddlPower_Req.SelectedIndex == 1)
            //{

            //    dsv1 = Gen.GetShowApprovalandFees("21", Enterpriseid);
            //    dsv.Tables[0].Merge(dsv1.Tables[0]);
            //}
            //else 

            if (ddlPower_Req.SelectedIndex == 2)
            {

                dsv1 = Gen.GetShowApprovalandFees("5", Enterpriseid);
                dsv.Tables[0].Merge(dsv1.Tables[0]);
            }
            else if (ddlPower_Req.SelectedIndex == 3)
            {

                dsv1 = Gen.GetShowApprovalandFees("21", Enterpriseid);
                dsv.Tables[0].Merge(dsv1.Tables[0]);

            }
            DataSet dsv2 = new DataSet();
            if (ddlProp_intDistrictid.SelectedValue == "1" || ddlProp_intDistrictid.SelectedValue == "2" || ddlProp_intDistrictid.SelectedValue == "3" || ddlProp_intDistrictid.SelectedValue == "9" || ddlProp_intDistrictid.SelectedValue == "10" || ddlProp_intDistrictid.SelectedValue == "11" || ddlProp_intDistrictid.SelectedValue == "12" || ddlProp_intDistrictid.SelectedValue == "14" || ddlProp_intDistrictid.SelectedValue == "15" || ddlProp_intDistrictid.SelectedValue == "16" || ddlProp_intDistrictid.SelectedValue == "17" || ddlProp_intDistrictid.SelectedValue == "18" || ddlProp_intDistrictid.SelectedValue == "19" || ddlProp_intDistrictid.SelectedValue == "22" || ddlProp_intDistrictid.SelectedValue == "23" || ddlProp_intDistrictid.SelectedValue == "26" || ddlProp_intDistrictid.SelectedValue == "30")
            {

                dsv2 = Gen.GetShowApprovalandFees("4", Enterpriseid);
                dsv.Tables[0].Merge(dsv2.Tables[0]);

                DataSet dscess = Gen.getCESSVillages(ddlProp_intVillageid.SelectedValue);
                if (dscess.Tables[0].Rows.Count > 0)
                {
                    dsv2 = Gen.GetShowApprovalandFees("41", Enterpriseid);
                    dsv.Tables[0].Merge(dsv2.Tables[0]);
                }
            }
            else if (ddlProp_intDistrictid.SelectedValue == "4" || ddlProp_intDistrictid.SelectedValue == "5" || ddlProp_intDistrictid.SelectedValue == "6" || ddlProp_intDistrictid.SelectedValue == "7" || ddlProp_intDistrictid.SelectedValue == "8" || ddlProp_intDistrictid.SelectedValue == "13" || ddlProp_intDistrictid.SelectedValue == "20" || ddlProp_intDistrictid.SelectedValue == "21" || ddlProp_intDistrictid.SelectedValue == "24" || ddlProp_intDistrictid.SelectedValue == "25" || ddlProp_intDistrictid.SelectedValue == "27" || ddlProp_intDistrictid.SelectedValue == "28" || ddlProp_intDistrictid.SelectedValue == "29" || ddlProp_intDistrictid.SelectedValue == "31")
            {
                dsv2 = Gen.GetShowApprovalandFees("25", Enterpriseid);
                dsv.Tables[0].Merge(dsv2.Tables[0]);
            }
            DataSet dsv3 = new DataSet();
            string strTot_PrjCost = "0";
            if (ddlproposal.SelectedValue == "1")
            {
                strTot_PrjCost = TxtTot_PrjCost.Text;
            }
            else if (ddlproposal.SelectedValue == "2")
            {
                strTot_PrjCost = txtlbltotalprojectcostexpanstion.Text;
            }
            if (HdfLblPol_Category.Value == "Red")
            {

                dsv3 = Gen.GetShowApprovalandFeesPCB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost);

                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }
            else if (HdfLblPol_Category.Value == "Green")
            {
                if (HdfLblEnt_is.Value == "Small" || HdfLblEnt_is.Value == "Micro")
                {
                    if (RdPol_Indus.SelectedValue.ToString().Trim() == "Y")
                    {
                        dsv3 = Gen.GetShowApprovalandFeesPCB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost);
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                    else if (RdPol_Indus.SelectedValue.ToString().Trim() == "N")
                    {
                        dsv3 = Gen.GetShowApprovalandFeesPCB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost);
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                }
                else
                {
                    dsv3 = Gen.GetShowApprovalandFeesPCB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
            }
            else if (HdfLblPol_Category.Value == "Orange")
            {
                if (HdfLblEnt_is.Value == "Small" || HdfLblEnt_is.Value == "Micro")
                {
                    if (RdPol_Indus.SelectedValue.ToString().Trim() == "Y")
                    {

                        dsv3 = Gen.GetShowApprovalandFeesPCB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost);
                        dsv.Tables[0].Merge(dsv3.Tables[0]);

                    }
                    else if (RdPol_Indus.SelectedValue.ToString().Trim() == "N")
                    {
                        dsv3 = Gen.GetShowApprovalandFeesPCB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost);
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                }
                else
                {
                    dsv3 = Gen.GetShowApprovalandFeesPCB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
            }

            if (ChkWater_reg_from.Items[0].Selected == true)
            {
                dsv3 = Gen.GetShowApprovalandFeesGroundWater("9", Enterpriseid, TxtWater_req_Perday.Text, TxtTot_Extent.Text);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }
            if (ChkWater_reg_from.Items[1].Selected == true)
            {
                dsv3 = Gen.GetShowApprovalandFeesHWS("10", Enterpriseid);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }
            if (ChkWater_reg_from.Items[2].Selected == true)
            {
                dsv3 = Gen.GetShowApprovalandFees("11", Enterpriseid);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }
            if (RdDo_Store_Kerosine.SelectedValue == "Y")
            {
                dsv3 = Gen.GetShowApprovalandFeesDistincts("32", Enterpriseid, ddlProp_intDistrictid.SelectedValue);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }
            if (TxtHight_Build.Text.Trim() == "")
            {
                TxtHight_Build.Text = "0";
            }
            if (Convert.ToDecimal(TxtHight_Build.Text.Trim()) >= Convert.ToDecimal("15"))
            {
                dsv3 = Gen.GetShowApprovalandFeesFire("8", Enterpriseid, TxtBuilt_up_Area.Text);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }

            if (RdProp_Site.SelectedValue.ToString() == "Y")
            {
                dsv3 = Gen.GetShowApprovalandFeesEnterPriseAmount("28", Enterpriseid, TxtVal_Plant.Text, strTot_PrjCost, Txt_NoofTrees.Text);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }
            if (ddlLoc_of_unit.SelectedValue == "2")
            {
                dsv3 = Gen.GetShowApprovalandFeesDTCP("7", Enterpriseid, RdFall_in_Municipal.SelectedValue);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }
            if (ddlLoc_of_unit.SelectedValue == "3")
            {
                dsv3 = Gen.GetShowApprovalandFees("30", Enterpriseid);
                dsv.Tables[0].Merge(dsv3.Tables[0]);

            }
            if (ddlLoc_of_unit.SelectedValue == "4")
            {
                dsv3 = Gen.GetShowApprovalandFees("31", Enterpriseid);
                dsv.Tables[0].Merge(dsv3.Tables[0]);

            }
            if (ddlLoc_of_unit.SelectedValue == "5")
            {
                dsv3 = Gen.GetShowApprovalandFees("38", Enterpriseid);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }
            //if (ddlLoc_of_unit.SelectedValue == "6")
            //{
            //    dsv3 = Gen.GetShowApprovalandFees("43", Enterpriseid);
            //    dsv.Tables[0].Merge(dsv3.Tables[0]);
            //}
            DataSet dsv4 = new DataSet();
            dsv4 = Gen.GetShowApprovalandFeesEnterPriseAmount("33", Enterpriseid, TxtVal_Plant.Text, strTot_PrjCost, "0");
            dsv.Tables[0].Merge(dsv4.Tables[0]);
            if (ddlLoc_of_unit.SelectedValue == "1")
            {
                if (ddlAppl_Type.SelectedValue == "1")
                {
                    dsv3 = Gen.GetShowApprovalandFeesHMDACLUandBuilding("6", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
                else if (ddlAppl_Type.SelectedValue == "2")
                {
                    dsv3 = Gen.GetShowApprovalandFeesHMDACLUandBuilding("35", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
                else if (ddlAppl_Type.SelectedValue == "3")
                {
                    dsv3 = Gen.GetShowApprovalandFeesHMDACLUandBuildingBoth("6", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
                else
                {
                    dsv3 = Gen.GetShowApprovalandFeesHMDACLUandBuildingBoth("6", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
            }

            if (ddlLoc_of_unit.SelectedValue != "4")  // No use of this method
            {
                dsv3 = Gen.GetShowApprovalandFeesNALA("34", Enterpriseid, ddlProp_intDistrictid.SelectedValue,null, ddlcurrencytype.SelectedItem.Text,ddlProp_intMandalid.SelectedValue);
                dsv.Tables[0].Merge(dsv3.Tables[0]);

            }
            DataSet dsLabour = new DataSet();//lavanya
            string LabourActId = "", EmployeeCount = "0";
            if (TxtProp_Emp.Text.Trim() == "")
            {
                EmployeeCount = "0";
            }
            else
            {
                EmployeeCount = TxtProp_Emp.Text.Trim();
            }

            for (int i = 0; i < ChkLabour_Application.Items.Count; i++)
            {
                if (ChkLabour_Application.Items[i].Selected == true)
                {
                    if (LabourActId == "")
                    {
                        if (ChkLabour_Application.Items[i].Value == "2" && rdbact2.SelectedValue == "Y")
                        {
                            LabourActId = ChkLabour_Application.Items[i].Value;
                        }
                        else if (ChkLabour_Application.Items[i].Value != "2")
                        {
                            LabourActId = ChkLabour_Application.Items[i].Value;
                        }
                    }
                    else
                    {
                        if (ChkLabour_Application.Items[i].Value == "2" && rdbact2.SelectedValue == "Y")
                        {
                            LabourActId += "," + ChkLabour_Application.Items[i].Value;
                        }
                        else if (ChkLabour_Application.Items[i].Value != "2")
                        {
                            LabourActId += "," + ChkLabour_Application.Items[i].Value;
                        }
                    }
                }
            }

            dsLabour = Gen.GetShowApprovalandFeesLabour("0", Enterpriseid, ddlProp_intDistrictid.SelectedValue, LabourActId, EmployeeCount);
            dsv.Tables[0].Merge(dsLabour.Tables[0]);

            if (dsv.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = dsv.Tables[0];
                grdDetails.DataBind();
                dvfeedetails.Visible = true;
            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
                dvfeedetails.Visible = false;
            }


        }
        catch (Exception ex)
        {


        }
        finally
        {
        }

    }

    public void CalcFeesNewDepartment()
    {

        try
        {

            DataSet dss = new DataSet();
            string Enterpriseid = "0";
            dss = Gen.GetEnterprisebyID(HdfLblEnt_is.Value);
            if (dss.Tables[0].Rows.Count > 0)
            {
                Enterpriseid = dss.Tables[0].Rows[0]["intEnterpriseType"].ToString();
            }

            string SearchVerfi = "";
            DataSet dsa = new DataSet();
            DataSet dsv = new DataSet();
            dsv = null;

            dsv = Gen.GetShowApprovalandFees("0", Enterpriseid);
            DataSet dsMunicial = new DataSet();
            if (RdFall_in_Municipal.SelectedValue.ToString().Trim() == "R")
            {

                dsMunicial = Gen.GetShowApprovalandFees("2", Enterpriseid);
                dsv.Tables[0].Merge(dsMunicial.Tables[0]);

            }
            DataSet dsv1 = new DataSet();
            //if (ddlPower_Req.SelectedIndex == 1)
            //{

            //    dsv1 = Gen.GetShowApprovalandFees("21", Enterpriseid);
            //    dsv.Tables[0].Merge(dsv1.Tables[0]);
            //}
            //else 

            if (ddlPower_Req.SelectedIndex == 2)
            {

                dsv1 = Gen.GetShowApprovalandFees("5", Enterpriseid);
                dsv.Tables[0].Merge(dsv1.Tables[0]);
            }
            else if (ddlPower_Req.SelectedIndex == 3)
            {

                dsv1 = Gen.GetShowApprovalandFees("21", Enterpriseid);
                dsv.Tables[0].Merge(dsv1.Tables[0]);

            }
            DataSet dsv2 = new DataSet();
            if (ddlProp_intDistrictid.SelectedValue == "1" || ddlProp_intDistrictid.SelectedValue == "2" || ddlProp_intDistrictid.SelectedValue == "3" || ddlProp_intDistrictid.SelectedValue == "9" || ddlProp_intDistrictid.SelectedValue == "10" || ddlProp_intDistrictid.SelectedValue == "11" || ddlProp_intDistrictid.SelectedValue == "12" || ddlProp_intDistrictid.SelectedValue == "14" || ddlProp_intDistrictid.SelectedValue == "15" || ddlProp_intDistrictid.SelectedValue == "16" || ddlProp_intDistrictid.SelectedValue == "17" || ddlProp_intDistrictid.SelectedValue == "18" || ddlProp_intDistrictid.SelectedValue == "19" || ddlProp_intDistrictid.SelectedValue == "22" || ddlProp_intDistrictid.SelectedValue == "23" || ddlProp_intDistrictid.SelectedValue == "26" || ddlProp_intDistrictid.SelectedValue == "30")
            {

                dsv2 = Gen.GetShowApprovalandFees("4", Enterpriseid);
                dsv.Tables[0].Merge(dsv2.Tables[0]);

                DataSet dscess = Gen.getCESSVillages(ddlProp_intVillageid.SelectedValue);
                if (dscess.Tables[0].Rows.Count > 0)
                {
                    dsv2 = Gen.GetShowApprovalandFees("41", Enterpriseid);
                    dsv.Tables[0].Merge(dsv2.Tables[0]);
                }
            }
            else if (ddlProp_intDistrictid.SelectedValue == "4" || ddlProp_intDistrictid.SelectedValue == "5" || ddlProp_intDistrictid.SelectedValue == "6" || ddlProp_intDistrictid.SelectedValue == "7" || ddlProp_intDistrictid.SelectedValue == "8" || ddlProp_intDistrictid.SelectedValue == "13" || ddlProp_intDistrictid.SelectedValue == "20" || ddlProp_intDistrictid.SelectedValue == "21" || ddlProp_intDistrictid.SelectedValue == "24" || ddlProp_intDistrictid.SelectedValue == "25" || ddlProp_intDistrictid.SelectedValue == "27" || ddlProp_intDistrictid.SelectedValue == "28" || ddlProp_intDistrictid.SelectedValue == "29" || ddlProp_intDistrictid.SelectedValue == "31")
            {
                dsv2 = Gen.GetShowApprovalandFees("25", Enterpriseid);
                dsv.Tables[0].Merge(dsv2.Tables[0]);
            }
            DataSet dsv3 = new DataSet();
            string strTot_PrjCost = "0";
            if (ddlproposal.SelectedValue == "1")
            {
                strTot_PrjCost = TxtTot_PrjCost.Text;
            }
            else if (ddlproposal.SelectedValue == "2")
            {
                strTot_PrjCost = txtlbltotalprojectcostexpanstion.Text;
            }
            if (HdfLblPol_Category.Value == "Red")
            {
                dsv3 = Gen.GetShowApprovalandFeesPCBNewDB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }
            else if (HdfLblPol_Category.Value == "Green")
            {
                if (HdfLblEnt_is.Value == "Small" || HdfLblEnt_is.Value == "Micro")
                {
                    if (RdPol_Indus.SelectedValue.ToString().Trim() == "Y")
                    {

                        dsv3 = Gen.GetShowApprovalandFeesPCBNewDB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost);
                        dsv.Tables[0].Merge(dsv3.Tables[0]);

                    }
                    else if (RdPol_Indus.SelectedValue.ToString().Trim() == "N")
                    {

                        //dsv3 = Gen.GetShowApprovalandFeesPCBDIC("3", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, TxtTot_PrjCost.Text, ddlProp_intDistrictid.SelectedValue);
                        //dsv.Tables[0].Merge(dsv3.Tables[0]);
                        dsv3 = Gen.GetShowApprovalandFeesPCBNewDB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost);
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                }
                else
                {
                    dsv3 = Gen.GetShowApprovalandFeesPCBNewDB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);

                    //dsv3 = Gen.GetShowApprovalandFeesPCB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, TxtVal_Plant.Text);
                    //dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
                ////if (HdfLblEnt_is.Value == "Small" || HdfLblEnt_is.Value == "Micro")
                ////{

                ////}
                ////else
                ////{
                ////    if (RdPol_Indus.SelectedValue.ToString().Trim() == "Y")
                ////    {

                ////        dsv3 = Gen.GetShowApprovalandFeesPCB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, TxtTot_PrjCost.Text);
                ////        dsv.Tables[0].Merge(dsv3.Tables[0]);

                ////    }
                ////    else if (RdPol_Indus.SelectedValue.ToString().Trim() == "N")
                ////    {
                ////        if (HdfLblEnt_is.Value == "Green")
                ////        {
                ////            dsv3 = Gen.GetShowApprovalandFeesPCB("3", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, TxtTot_PrjCost.Text);
                ////            dsv.Tables[0].Merge(dsv3.Tables[0]);
                ////        }

                ////    }
                ////    //dsv3 = Gen.GetShowApprovalandFeesPCB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, TxtVal_Plant.Text);
                ////    //dsv.Tables[0].Merge(dsv3.Tables[0]);
                ////}
            }
            else if (HdfLblPol_Category.Value == "Orange")
            {
                if (HdfLblEnt_is.Value == "Small" || HdfLblEnt_is.Value == "Micro")
                {
                    if (RdPol_Indus.SelectedValue.ToString().Trim() == "Y")
                    {

                        dsv3 = Gen.GetShowApprovalandFeesPCBNewDB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost);
                        dsv.Tables[0].Merge(dsv3.Tables[0]);

                    }
                    else if (RdPol_Indus.SelectedValue.ToString().Trim() == "N")
                    {

                        //dsv3 = Gen.GetShowApprovalandFeesPCBDIC("3", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, TxtTot_PrjCost.Text, ddlProp_intDistrictid.SelectedValue);
                        //dsv.Tables[0].Merge(dsv3.Tables[0]);

                        dsv3 = Gen.GetShowApprovalandFeesPCBNewDB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost);
                        dsv.Tables[0].Merge(dsv3.Tables[0]);


                    }
                }
                else
                {
                    dsv3 = Gen.GetShowApprovalandFeesPCBNewDB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                    //dsv3 = Gen.GetShowApprovalandFeesPCB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, TxtVal_Plant.Text);
                    //dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
                //dsv3 = Gen.GetShowApprovalandFeesPCB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, TxtTot_PrjCost.Text);
                //dsv.Tables[0].Merge(dsv3.Tables[0]);
            }

            if (ChkWater_reg_from.Items[0].Selected == true)
            {
                dsv3 = Gen.GetShowApprovalandFeesGroundWater("9", Enterpriseid, TxtWater_req_Perday.Text, TxtTot_Extent.Text);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }
            if (ChkWater_reg_from.Items[1].Selected == true)
            {
                dsv3 = Gen.GetShowApprovalandFeesHWS("10", Enterpriseid);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }
            if (ChkWater_reg_from.Items[2].Selected == true)
            {
                dsv3 = Gen.GetShowApprovalandFees("11", Enterpriseid);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }
            if (RdDo_Store_Kerosine.SelectedValue == "Y")
            {
                dsv3 = Gen.GetShowApprovalandFeesDistincts("32", Enterpriseid, ddlProp_intDistrictid.SelectedValue);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }
            if (TxtHight_Build.Text.Trim() == "")
            {
                TxtHight_Build.Text = "0";
            }
            if (Convert.ToDecimal(TxtHight_Build.Text.Trim()) >= Convert.ToDecimal("15"))
            {
                dsv3 = Gen.GetShowApprovalandFeesFire("8", Enterpriseid, TxtBuilt_up_Area.Text);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }
            if (RdProp_Site.SelectedValue.ToString() == "Y")
            {
                //dsv3 = Gen.GetShowApprovalandFees("28", Enterpriseid);
                dsv3 = Gen.GetShowApprovalandFeesEnterPriseAmount("28", Enterpriseid, TxtVal_Plant.Text, strTot_PrjCost, Txt_NoofTrees.Text);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }

            //if (ddlLoc_of_unit.SelectedValue == "1")
            //{
            //    dsv3 = Gen.GetShowApprovalandFees("6", Enterpriseid);
            //    dsv.Tables[0].Merge(dsv3.Tables[0]);
            //    dsv3 = Gen.GetShowApprovalandFees("29", Enterpriseid);
            //    dsv.Tables[0].Merge(dsv3.Tables[0]);
            //}

            if (ddlLoc_of_unit.SelectedValue == "2")
            {
                dsv3 = Gen.GetShowApprovalandFeesDTCP("7", Enterpriseid, RdFall_in_Municipal.SelectedValue);
                dsv.Tables[0].Merge(dsv3.Tables[0]);

            }
            if (ddlLoc_of_unit.SelectedValue == "3")
            {
                dsv3 = Gen.GetShowApprovalandFees("30", Enterpriseid);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }
            if (ddlLoc_of_unit.SelectedValue == "4")
            {
                dsv3 = Gen.GetShowApprovalandFees("31", Enterpriseid);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }
            if (ddlLoc_of_unit.SelectedValue == "5")
            {
                dsv3 = Gen.GetShowApprovalandFees("38", Enterpriseid);
                dsv.Tables[0].Merge(dsv3.Tables[0]);

            }
            //if (ddlLoc_of_unit.SelectedValue == "6")
            //{
            //    dsv3 = Gen.GetShowApprovalandFees("43", Enterpriseid);
            //    dsv.Tables[0].Merge(dsv3.Tables[0]);

            //}
            DataSet dsv4 = new DataSet();
            dsv4 = Gen.GetShowApprovalandFeesEnterPriseAmount("33", Enterpriseid, TxtVal_Plant.Text, strTot_PrjCost, "0");
            dsv.Tables[0].Merge(dsv4.Tables[0]);
            if (ddlLoc_of_unit.SelectedValue == "1")
            {
                if (ddlAppl_Type.SelectedValue == "1")
                {
                    dsv3 = Gen.GetShowApprovalandFeesHMDACLUandBuilding("6", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
                else if (ddlAppl_Type.SelectedValue == "2")
                {

                    dsv3 = Gen.GetShowApprovalandFeesHMDACLUandBuilding("35", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);

                }
                else if (ddlAppl_Type.SelectedValue == "3")
                {
                    dsv3 = Gen.GetShowApprovalandFeesHMDACLUandBuildingBoth("6", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                    //dsv3 = Gen.GetShowApprovalandFeesHMDACLUandBuildingBoth("35", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                    //dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
                //if (ddlAppl_Type.SelectedValue == "3")
                //{
                //    dsv3 = Gen.GetShowApprovalandFeesHMDACLUandBuildingBoth("6", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                //    dsv.Tables[0].Merge(dsv3.Tables[0]);
                //    //dsv3 = Gen.GetShowApprovalandFeesHMDACLUandBuildingBoth("35", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                //    //dsv.Tables[0].Merge(dsv3.Tables[0]);
                //}
                else
                {
                    dsv3 = Gen.GetShowApprovalandFeesHMDACLUandBuildingBoth("6", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                    //dsv3 = Gen.GetShowApprovalandFeesHMDACLUandBuildingBoth("35", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                    //dsv.Tables[0].Merge(dsv3.Tables[0]);
                }

            }

            if (ddlLoc_of_unit.SelectedValue != "4")
            {
                dsv3 = Gen.GetShowApprovalandFeesNALA("34", Enterpriseid, ddlProp_intDistrictid.SelectedValue, null, ddlcurrencytype.SelectedItem.Text, ddlProp_intMandalid.SelectedValue);
                dsv.Tables[0].Merge(dsv3.Tables[0]);

            }
            //dsv3 = Gen.GetShowApprovalandFees("37", Enterpriseid);
            //dsv.Tables[0].Merge(dsv3.Tables[0]);
            DataSet dsLabour = new DataSet();//lavanya
            string LabourActId = "", EmployeeCount = "0";
            if (TxtProp_Emp.Text.Trim() == "")
            {
                EmployeeCount = "0";
            }
            else
            {
                EmployeeCount = TxtProp_Emp.Text.Trim();
            }

            for (int i = 0; i < ChkLabour_Application.Items.Count; i++)
            {
                if (ChkLabour_Application.Items[i].Selected == true)
                {
                    if (LabourActId == "")
                        LabourActId = ChkLabour_Application.Items[i].Value;
                    else
                        LabourActId += "," + ChkLabour_Application.Items[i].Value;
                }
            }
            dsLabour = Gen.GetShowApprovalandFeesLabour("0", Enterpriseid, ddlProp_intDistrictid.SelectedValue, LabourActId, EmployeeCount);
            dsv.Tables[0].Merge(dsLabour.Tables[0]);
            TotalFee = Convert.ToDecimal("0");
            if (dsv.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = dsv.Tables[0];
                grdDetails.DataBind();
                dvfeedetails.Visible = true;
            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
                dvfeedetails.Visible = false;
            }

            //if (dsv.Tables[0].Rows.Count > 0)
            //{
            //    grdDetails.DataSource = dsv.Tables[0];
            //    grdDetails.DataBind();
            //}
            //else
            //{
            //    grdDetails.DataSource = null;
            //    grdDetails.DataBind();
            //}
            //int s = Gen.insertQuetieneroes("0", ddlConst_of_unit.SelectedValue, ddlSector_Ent.SelectedValue, TxtTot_Extent.Text, ddlProp_intDistrictid.SelectedValue,
            //           ddlProp_intMandalid.SelectedValue, ddlProp_intVillageid.SelectedValue, TxtProp_Emp.Text, TxtVal_Land.Text, TxtVal_Build.Text, TxtVal_Plant.Text, TxtTot_PrjCost.Text, HdfLblEnt_is.Value, ddlintLineofActivity.SelectedValue, RdPol_Indus.SelectedValue, HdfLblPol_Category.Value, ddlPower_Req.SelectedValue, ddlLoc_of_unit.SelectedValue, TxtWater_req_Perday.Text,
            //           ChkWater_reg_from.SelectedItem.Text, ChkWater_reg_from.SelectedItem.Text, ChkWater_reg_from.SelectedItem.Text, RdDo_Store_Kerosine.SelectedValue, RdGen_Reqired.SelectedValue, TxtHight_Build.Text, TxtBuilt_up_Area.Text, RdFall_in_Municipal.SelectedValue, RdProp_Site.SelectedValue, "1", "1000", "1000");

            //if (s >= 0)
            //{
            //    success.Visible = true;
            //    Failure.Visible = false;
            //    lblmsg.Text = "Questionnaire - Consent for Establishment is Succesfully Saved";
            //    cmf.ResetFormControl(this);
            //    Session["Applid"] = s.ToString();
            //}
            //else
            //{
            //    success.Visible = false;
            //    Failure.Visible = true;
            //    lblmsg0.Text = "Questionnaire - Consent for Establishment is Registration Failed";
            //}
        }
        catch (Exception ex)
        {


        }
        finally
        {
        }

    }
    void clear()
    {




    }




    protected void BtnClear_Click(object sender, EventArgs e)
    {
        cmf.ResetFormControl(this);
        grdDetails.DataSource = null;
        grdDetails.DataBind();
        HdfLblEnt_is.Value = "";
        HdfLblPol_Category.Value = "";
        LblEnt_is.Text = "";
        LblPol_Category.Text = "";
        BtnSave.Visible = false;
        Txt_NoofTrees.Text = "";
        dvfeedetails.Visible = false;
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ddlState_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void ddlCounties_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void BtnSave2_Click(object sender, EventArgs e)
    {

        try
        {



        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
        finally
        {

        }

    }

    private void fillTrademappingGriddr(DataTable tmpTabledr, string MemType, string authorised, string designation, string gender, string mobile, string email2, string Created_by)
    {




    }

    protected void BtnClear0_Click1(object sender, EventArgs e)
    {

    }
    protected void gvpractical0_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {


        }
        finally
        {
        }
    }



    protected void GetNewRectoInsertdr()
    {

    }
    protected void ddlProp_intDistrictid_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProp_intDistrictid.SelectedIndex == 0)
        {
            ddlProp_intMandalid.Items.Clear();
            ddlProp_intMandalid.Items.Insert(0, "--Mandal--");
            ChkWater_reg_from.Items.Clear();
            ChkWater_reg_from.Items.Insert(0, new ListItem("New Bore well", "New Bore well"));
            ChkWater_reg_from.Items.Insert(1, new ListItem("HMWS & SB", "HMWS & SB"));
            ChkWater_reg_from.Items.Insert(2, new ListItem("Rivers/Canals", "Rivers/Canals"));
        }
        else
        {
            ddlProp_intMandalid.Items.Clear();
            DataSet dsm = new DataSet();
            dsm = Gen.GetMandals(ddlProp_intDistrictid.SelectedValue);
            if (dsm.Tables[0].Rows.Count > 0)
            {
                ddlProp_intMandalid.DataSource = dsm.Tables[0];
                ddlProp_intMandalid.DataValueField = "Mandal_Id";
                ddlProp_intMandalid.DataTextField = "Manda_lName";
                ddlProp_intMandalid.DataBind();
                ddlProp_intMandalid.Items.Insert(0, "--Mandal--");
            }
            else
            {
                ddlProp_intMandalid.Items.Clear();
                ddlProp_intMandalid.Items.Insert(0, "--Mandal--");
            }
        }
        hdnfocus.Value = ddlProp_intDistrictid.ClientID;
        if (rdIaLa_Lst.SelectedValue == "Y") //lavanya
        {
            BindIndustrialParks();
        }
        //   ddlProp_intDistrictid.Focus();
    }
    protected void ddlProp_intMandalid_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProp_intMandalid.SelectedIndex == 0)
        {

            ddlProp_intVillageid.Items.Clear();
            ddlProp_intVillageid.Items.Insert(0, "--Village--");
        }
        else
        {
            ddlProp_intVillageid.Items.Clear();
            DataSet dsv = new DataSet();
            dsv = Gen.GetVillages(ddlProp_intMandalid.SelectedValue);
            if (dsv.Tables[0].Rows.Count > 0)
            {
                ddlProp_intVillageid.DataSource = dsv.Tables[0];
                ddlProp_intVillageid.DataValueField = "Village_Id";
                ddlProp_intVillageid.DataTextField = "Village_Name";
                ddlProp_intVillageid.DataBind();
                ddlProp_intVillageid.Items.Insert(0, "--Village--");
            }
            else
            {
                ddlProp_intVillageid.Items.Clear();
                ddlProp_intVillageid.Items.Insert(0, "--Village--");
            }
            #region commented by lavanya . need to show based on village master
            /*
            DataSet dsss = new DataSet();
            dsss = Gen.GetShowLOcationofUnit(ddlProp_intDistrictid.SelectedValue, ddlProp_intMandalid.SelectedValue);
            if (dsss.Tables[0].Rows.Count > 0)
            {
                if (dsss.Tables[0].Rows[0][0].ToString().Trim() == "1")
                {
                    ddlLoc_of_unit.Items.Clear();
                    ddlLoc_of_unit.Items.Insert(0, "--Select--");
                    ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of HMDA (HMDA list of villages link)", "1"));
                    ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));

                    //ChkWater_reg_from.Items[1].Selected = true;
                    //ChkWater_reg_from.Items[1].Enabled = true;





                }
                else if (dsss.Tables[0].Rows[0][0].ToString().Trim() == "2")
                {
                    ddlLoc_of_unit.Items.Clear();
                    ddlLoc_of_unit.Items.Insert(0, "--Select--");
                    ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of DT&CP", "2"));
                    ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
                    //ChkWater_reg_from.Items[1].Selected = false;
                    //ChkWater_reg_from.Items[1].Enabled = false;
                }
                else if (dsss.Tables[0].Rows[0][0].ToString().Trim() == "3")
                {
                    ddlLoc_of_unit.Items.Clear();
                    ddlLoc_of_unit.Items.Insert(0, "--Select--");
                    ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of KUDA", "3"));
                    ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
                    //ChkWater_reg_from.Items[1].Selected = false;
                    //ChkWater_reg_from.Items[1].Enabled = false;

                    if (ddlProp_intDistrictid.SelectedValue.ToString() == "9" || ddlProp_intDistrictid.SelectedValue.ToString() == "3")
                    {
                        ddlLoc_of_unit.Items.Insert(3, new ListItem("Within the purview of DT&CP", "2"));
                    }
                }
                else if (dsss.Tables[0].Rows[0][0].ToString().Trim() == "5")
                {
                    ddlLoc_of_unit.Items.Clear();
                    ddlLoc_of_unit.Items.Insert(0, "--Select--");
                    ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of GM DIC,HYD", "5"));
                    ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
                    //ChkWater_reg_from.Items[1].Selected = false;
                    //ChkWater_reg_from.Items[1].Enabled = false;
                }
                if (ddlProp_intDistrictid.SelectedValue == "5")
                {
                    //  ChkWater_reg_from.Items[1].Enabled = true;
                }
            }
            else
            {
                ddlLoc_of_unit.Items.Clear();
                ddlLoc_of_unit.Items.Insert(0, "--Select--");
            }*/
            #endregion
        }
        // ddlProp_intMandalid.Focus();

        hdnfocus.Value = ddlProp_intMandalid.ClientID;
    }
    protected void ddlintLineofActivity_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlintLineofActivity.SelectedIndex == 0)
        {
            HdfLblPol_Category.Value = "";
            LblPol_Category.Text = "";
            //  trFallinPolution.Visible = false;
            RdPol_Indus.Enabled = false;
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
                        //   trFallinPolution.Visible = true;
                    }
                    else
                    {
                        //     trFallinPolution.Visible = false;
                    }

                }
                else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "R")
                {
                    HdfLblPol_Category.Value = "Red";
                    LblPol_Category.Text = "<font color=Red>Red</font>";
                    //  trFallinPolution.Visible = false;
                }
                else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "G")
                {
                    HdfLblPol_Category.Value = "Green";
                    // trFallinPolution.Visible = true;
                    LblPol_Category.Text = "<font color=Green>Green</font>";
                }
                else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "W")
                {
                    HdfLblPol_Category.Value = "White";
                    //   trFallinPolution.Visible = true;
                    LblPol_Category.Text = "White";
                }
                //if (HdfLblEnt_is.Value == "Small" || HdfLblEnt_is.Value == "Micro")
                //{
                //    if (dsct.Tables[0].Rows[0]["Flag"].ToString().Trim() == "Y")
                //    {
                //        RdPol_Indus.SelectedValue = "Y";

                //    }
                //    else
                //    {
                //        RdPol_Indus.SelectedValue = "N";

                //    }
                //}
                //else
                //{ RdPol_Indus.SelectedValue = "Y"; }
                RdPol_Indus.Enabled = false;
            }

            else
            {
                HdfLblPol_Category.Value = "";
                LblPol_Category.Text = "";
                RdPol_Indus.Enabled = false;
                trFallinPolution.Visible = false;
            }

        }
        hdnfocus.Value = ddlintLineofActivity.ClientID;
    }
    protected void TxtVal_Plant_TextChanged(object sender, EventArgs e)
    {
        CalculatationEnterprisePrjCost();
        CalculatationEnterprise();
        hdnfocus.Value = TxtVal_Plant.ClientID;
        // lblPlant.Text = "= Rs " + Decimal.Parse(TxtVal_Plant.Text.ToString()) / 100 + " Crores";
        // lblPlant.Text = "= Rs " + (Decimal.Parse(TxtVal_Plant_Actual.Text.ToString()) * Decimal.Parse(ddlcurrencytype.SelectedValue)) / 100 + " Crores";
        ProjectCostFinal();
    }

    public void CalculatationEnterprisePrjCost()
    {
        if (ddlSector_Ent.SelectedIndex != 0)
        {
            if (TxtVal_Build.Text.Trim() == "")
            {
                TxtVal_Build.Text = "0";
            }

            if (TxtVal_Land.Text.Trim() == "")
            {
                TxtVal_Land.Text = "0";
            }

            if (TxtVal_Plant.Text.Trim() == "")
            {
                TxtVal_Plant.Text = "0";
            }
            TxtTot_PrjCost.Text = Convert.ToString((Convert.ToDecimal(TxtVal_Build.Text) + Convert.ToDecimal(TxtVal_Land.Text) + Convert.ToDecimal(TxtVal_Plant.Text)));
            lblmsg.Text = "";
        }
        else
        {
            TxtTot_PrjCost.Text = "0";
            lblmsg.Text = "Please Select Sector of Enterprise";
        }
    }
    public void CalculatationEnterprisePrjCostExpansion()
    {
        if (ddlSector_Ent.SelectedIndex != 0)
        {
            if (TxtVal_BuildExpanstion.Text.Trim() == "")
            {
                TxtVal_BuildExpanstion.Text = "0";
            }

            if (TxtVal_LandExpansion.Text.Trim() == "")
            {
                TxtVal_LandExpansion.Text = "0";
            }

            if (TxtVal_PlantExpanstion.Text.Trim() == "")
            {
                TxtVal_PlantExpanstion.Text = "0";
            }
            txtlbltotalprojectcostexpanstion.Text = Convert.ToString((Convert.ToDecimal(TxtVal_BuildExpanstion.Text) + Convert.ToDecimal(TxtVal_LandExpansion.Text) + Convert.ToDecimal(TxtVal_PlantExpanstion.Text)));
            lblmsg.Text = "";
        }
        else
        {
            txtlbltotalprojectcostexpanstion.Text = "0";
            lblmsg.Text = "Please Select Sector of Enterprise";
        }
    }
    public void CalculatationEnterprise()
    {
        if (ddlSector_Ent.SelectedIndex != 0)
        {

            if (TxtProp_Emp.Text.Trim() == "")
            {
                TxtProp_Emp.Text = "0";
            }

            lblmsg.Text = "";
            DataSet dsEnter = new DataSet();
            if (ddlSector_Ent.SelectedValue == "2")
            {
                if (Convert.ToDecimal(TxtTot_PrjCost.Text) >= Convert.ToDecimal("20000"))
                {
                    HdfLblEnt_is.Value = "Mega";

                    LblEnt_is.Text = "Mega";
                }
                else
                {
                    dsEnter = Gen.GetEnterPriseIs(TxtVal_Plant.Text, ddlSector_Ent.SelectedValue);
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
            else if (ddlSector_Ent.SelectedValue == "1")
            {
                if (Convert.ToDecimal(TxtTot_PrjCost.Text) >= Convert.ToDecimal("20000"))
                {
                    HdfLblEnt_is.Value = "Mega";

                    LblEnt_is.Text = "Mega";
                }
                else
                {
                    dsEnter = Gen.GetEnterPriseIs(TxtVal_Plant.Text, ddlSector_Ent.SelectedValue);
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

            if (Convert.ToDecimal(TxtProp_Emp.Text) >= Convert.ToDecimal("1000"))
            {
                HdfLblEnt_is.Value = "Mega";
                LblEnt_is.Text = "Mega";
            }
            success.Visible = false;
        }
        else
        {
            HdfLblEnt_is.Value = "";
            LblEnt_is.Text = "";
            success.Visible = true;
            lblmsg.Text = "Please Select Sector of Enterprise";
        }


        if (ddlintLineofActivity.SelectedIndex == 0)
        {
            HdfLblPol_Category.Value = "";
            LblPol_Category.Text = "";
            //   trFallinPolution.Visible = false;
            RdPol_Indus.Enabled = false;
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
                        //   trFallinPolution.Visible = true;
                    }
                    else
                    {
                        //     trFallinPolution.Visible = false;
                    }

                }
                else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "R")
                {
                    HdfLblPol_Category.Value = "Red";
                    LblPol_Category.Text = "<font color=Red>Red</font>";
                    //  trFallinPolution.Visible = false;
                }
                else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "G")
                {
                    HdfLblPol_Category.Value = "Green";
                    // trFallinPolution.Visible = true;
                    LblPol_Category.Text = "<font color=Green>Green</font>";
                }
                else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "W")
                {
                    HdfLblPol_Category.Value = "White";
                    //   trFallinPolution.Visible = true;
                    LblPol_Category.Text = "White";
                }
                //if (HdfLblEnt_is.Value == "Small" || HdfLblEnt_is.Value == "Micro")
                //{
                //    if (dsct.Tables[0].Rows[0]["Flag"].ToString().Trim() == "Y")
                //    {
                //        RdPol_Indus.SelectedValue = "Y";

                //    }
                //    else
                //    {
                //        RdPol_Indus.SelectedValue = "N";

                //    }
                //}
                //else
                //{ RdPol_Indus.SelectedValue = "Y"; }
                RdPol_Indus.Enabled = false;
            }

            else
            {
                HdfLblPol_Category.Value = "";
                LblPol_Category.Text = "";
                RdPol_Indus.Enabled = false;
                trFallinPolution.Visible = false;
            }

        }

        //if (TxtVal_Plant.Text == "" || TxtVal_Plant.Text == "0")
        //{
        //    HdfLblEnt_is.Value = "";
        //    LblEnt_is.Text = "";
        //}
    }
    protected void TxtVal_Land_TextChanged(object sender, EventArgs e)
    {
        CalculatationEnterprisePrjCost();
        CalculatationEnterprise();
        if (ddlSector_Ent.SelectedIndex == 0)
        {
            HdfLblEnt_is.Value = "";
            LblEnt_is.Text = "";
        }
        // lblLand.Text = "= Rs " + Decimal.Parse(TxtVal_Land.Text.ToString()) / 100 + " Crores";
        // lblLand.Text = "= Rs " + (Decimal.Parse(TxtVal_Land_Actual.Text.ToString()) * Decimal.Parse(ddlcurrencytype.SelectedValue)) / 100 + " Crores";
        hdnfocus.Value = TxtVal_Build.ClientID;
        ProjectCostFinal();
    }
    protected void TxtVal_Build_TextChanged(object sender, EventArgs e)
    {
        CalculatationEnterprisePrjCost();
        CalculatationEnterprise();
        if (ddlSector_Ent.SelectedIndex == 0)
        {
            HdfLblEnt_is.Value = "";
            LblEnt_is.Text = "";
        }
        //lblBuild.Text = "= Rs " + Decimal.Parse(TxtVal_Build.Text.ToString()) / 100 + " Crores";
        // lblBuild.Text = "= Rs " + (Decimal.Parse(TxtVal_Build_Actual.Text.ToString()) * Decimal.Parse(ddlcurrencytype.SelectedValue)) / 100 + " Crores";
        hdnfocus.Value = TxtVal_Plant.ClientID;
        ProjectCostFinal();
    }
    protected void ddlSector_Ent_SelectedIndexChanged(object sender, EventArgs e)
    {
        CalculatationEnterprisePrjCost();
        CalculatationEnterprise();
        if (ddlSector_Ent.SelectedIndex == 0)
        {
            HdfLblEnt_is.Value = "";
            LblEnt_is.Text = "";
        }

        hdnfocus.Value = ddlSector_Ent.ClientID;
    }
    protected void BtnApprovalFees_Click(object sender, EventArgs e)
    {
        //string SearchVerfi = "";

        //if (RdFall_in_Municipal.SelectedValue.ToString().Trim() == "N")
        //{
        //    SearchVerfi = "2";
        //}
        //DataSet dsv = new DataSet();
        //dsv = Gen.GetShowApprovalandFees(SearchVerfi);
        //if (dsv.Tables[0].Rows.Count > 0)
        //{
        //    grdDetails.DataSource = dsv.Tables[0];
        //    grdDetails.DataBind();
        //}
        //else
        //{
        //    grdDetails.DataSource = null;
        //    grdDetails.DataBind();
        //}
    }
    protected void TxtProp_Emp_TextChanged(object sender, EventArgs e)
    {
        CalculatationEnterprise();
        hdnfocus.Value = TxtVal_Land.ClientID;
    }
    protected void RdProp_Site_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdProp_Site.SelectedValue.ToString().Trim() == "Y")
        {
            trtrees.Visible = true;
            Txt_NoofTrees.Text = "";
            tr4.Visible = true;
        }
        else
        {
            Txt_NoofTrees.Text = "";
            trtrees.Visible = false;
            tr4.Visible = false;
        }
        hdnfocus.Value = RdProp_Site.ClientID;
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
            decimal TotalFee1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fees"));
            TotalFee = TotalFee + TotalFee1;



            HiddenField HdfApprovalid = (HiddenField)e.Row.Cells[0].FindControl("HdfApprovalid");
            HdfApprovalid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ApprovalId")).Trim();

            HiddenField HdfQueid = (HiddenField)e.Row.Cells[0].FindControl("HdfQueid");
            HdfQueid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Dept_Id")).Trim();

            e.Row.Cells[3].Text = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fees")).ToString("#,##0");
        }
        if ((e.Row.RowType == DataControlRowType.Footer))
        {
            e.Row.Cells[2].Text = "Total Fee";
            e.Row.Cells[3].Text = TotalFee.ToString("f0");
        }
    }
    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        try
        {
            string chkwatera = "", chkwaterb = "", chkwaterc = "";
            if (ChkWater_reg_from.Items[0].Selected == true)
            {
                chkwatera = ChkWater_reg_from.Items[0].Text;
            }
            if (ChkWater_reg_from.Items[1].Selected == true)
            {
                chkwaterb = ChkWater_reg_from.Items[1].Text;
            }

            if (ChkWater_reg_from.Items[2].Selected == true)
            {
                chkwaterc = ChkWater_reg_from.Items[2].Text;
            }


            CalcFees();


            //shankar
            QuesionerVO quesionervoobj = new QuesionerVO();

            quesionervoobj.intQuessionaireid = Session["Applid"].ToString().Trim();
            quesionervoobj.Const_of_unit = ddlConst_of_unit.SelectedValue;
            quesionervoobj.Sector_Ent = ddlSector_Ent.SelectedValue;
            quesionervoobj.Tot_Extent = TxtTot_Extent.Text;
            quesionervoobj.Prop_intDistrictid = ddlProp_intDistrictid.SelectedValue;
            quesionervoobj.Prop_intMandalid = ddlProp_intMandalid.SelectedValue;
            quesionervoobj.Prop_intVillageid = ddlProp_intVillageid.SelectedValue;
            quesionervoobj.Prop_Emp = TxtProp_Emp.Text;
            quesionervoobj.Val_Land = TxtVal_Land.Text.Trim();
            quesionervoobj.Val_Build = TxtVal_Build.Text.Trim();
            quesionervoobj.Val_Plant = TxtVal_Plant.Text.Trim();
            quesionervoobj.Val_Land_Actul = TxtVal_Land_Actual.Text.Trim();
            quesionervoobj.Val_Build_Actul = TxtVal_Build_Actual.Text.Trim();
            quesionervoobj.Val_Plant_Actul = TxtVal_Plant_Actual.Text.Trim();
            quesionervoobj.Tot_PrjCost = TxtTot_PrjCost.Text;
            quesionervoobj.Ent_is = HdfLblEnt_is.Value;
            quesionervoobj.intLineofActivity = ddlintLineofActivity.SelectedValue;
            quesionervoobj.Pol_Indus = RdPol_Indus.SelectedValue;
            quesionervoobj.Pol_Category = HdfLblPol_Category.Value;
            quesionervoobj.Power_Req = ddlPower_Req.SelectedValue;
            quesionervoobj.Loc_of_unit = ddlLoc_of_unit.SelectedValue;
            quesionervoobj.Water_req_Perday = TxtWater_req_Perday.Text;
            quesionervoobj.Water_reg_from1 = chkwatera;
            quesionervoobj.Water_reg_from2 = chkwaterb;
            quesionervoobj.Water_reg_from3 = chkwaterc;
            quesionervoobj.Do_Store_Kerosine = RdDo_Store_Kerosine.SelectedValue;
            quesionervoobj.Gen_Reqired = RdGen_Reqired.SelectedValue;
            quesionervoobj.Hight_Build = TxtHight_Build.Text;
            quesionervoobj.Built_up_Area = TxtBuilt_up_Area.Text;
            quesionervoobj.Fall_in_Municipal = RdFall_in_Municipal.SelectedValue;
            quesionervoobj.Prop_Site = RdProp_Site.SelectedValue;
            quesionervoobj.Appl_Status = "2";
            quesionervoobj.Appl_no = "1000";
            quesionervoobj.Created_by = Session["uid"].ToString().Trim();
            quesionervoobj.NoofTrees = Txt_NoofTrees.Text;
            quesionervoobj.Non_Exempted = RdbExecpted.SelectedValue;
            quesionervoobj.Appl_Type = ddlAppl_Type.SelectedValue;
            quesionervoobj.nameofunit = TxtnameofUnit.Text.Trim();
            quesionervoobj.TypeofMesurement = ddllandmesurements.SelectedItem.Text;
            quesionervoobj.TxtTot_ExtentNew = TxtTot_ExtentNew.Text;
            quesionervoobj.TxtTot_Gunthas = txtgunthas.Text;
            quesionervoobj.CurrencyType = ddlcurrencytype.SelectedItem.Text;

            //Expansion
            quesionervoobj.Val_LandExpansion = TxtVal_LandExpansion.Text.Trim();
            quesionervoobj.Val_BuildExpansion = TxtVal_BuildExpanstion.Text.Trim();
            quesionervoobj.Val_PlantExpansion = TxtVal_PlantExpanstion.Text.Trim();
            quesionervoobj.Val_Land_ActulExpansion = TxtVal_Land_ActualExpansion.Text.Trim();
            quesionervoobj.Val_Build_ActulExpansion = TxtVal_Build_ActualExpn.Text.Trim();
            quesionervoobj.Val_Plant_ActulExpansion = TxtVal_Plant_ActualExpansion.Text.Trim();
            quesionervoobj.Tot_PrjCostExpansion = txtlbltotalprojectcostexpanstion.Text;
            quesionervoobj.ProposalFor = ddlproposal.SelectedItem.Text;
            //end shankar
            //lavanya
            quesionervoobj.IALAFlag = rdIaLa_Lst.SelectedValue;
            if (quesionervoobj.IALAFlag == "Y")
                quesionervoobj.IALA_Code = ddlIndustrialParkName.SelectedValue;
            quesionervoobj.LabourActID = "";
            for (int i = 0; i < ChkLabour_Application.Items.Count; i++)
            {
                if (ChkLabour_Application.Items[i].Selected == true)
                {
                    if (quesionervoobj.LabourActID == "")
                        quesionervoobj.LabourActID = ChkLabour_Application.Items[i].Value;
                    else
                        quesionervoobj.LabourActID += "," + ChkLabour_Application.Items[i].Value;
                }
            }//lavanya
            //ddllandmesurements.SelectedItem.Text
            int s = Gen.insertQuetieneroes(quesionervoobj);
            Session["Applid"] = s.ToString();

            if (s >= 0)
            {
                for (int iii = 0; iii < grdDetails.Rows.Count; iii++)
                {
                    HiddenField HdfApprovalid = (HiddenField)grdDetails.Rows[iii].Cells[0].FindControl("HdfApprovalid");
                    HiddenField HdfQueid = (HiddenField)grdDetails.Rows[iii].Cells[0].FindControl("HdfQueid");
                    int a = Gen.insertQuetieneroesDept(s.ToString(), HdfQueid.Value, HdfApprovalid.Value, "1000", grdDetails.Rows[iii].Cells[3].Text);
                }
                success.Visible = true;
                Failure.Visible = false;
                lblmsg.Text = "Questionnaire - Consent for Establishment is Succesfully Submitted";


                cmf.ResetFormControl(this);
                grdDetails.DataSource = null;
                grdDetails.DataBind();
                HdfLblEnt_is.Value = "";
                HdfLblPol_Category.Value = "";
                LblEnt_is.Text = "";
                LblPol_Category.Text = "";
                BtnSave.Visible = false;
                Response.Redirect("TS-iPASS.aspx?id=" + Session["Applid"].ToString().Trim());
            }
            else
            {
                success.Visible = false;
                Failure.Visible = true;
                lblmsg0.Text = "Questionnaire - Consent for Establishment is Registration Failed";
            }
        }
        catch (Exception ex)
        {


        }
        finally
        {
        }
    }
    protected void ddlLoc_of_unit_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLoc_of_unit.SelectedIndex != 0)
        {
            BindApplicationType(Convert.ToInt32(ddlLoc_of_unit.SelectedValue));
        }
        else
        {
            trApplType.Visible = false;
            //ChkWater_reg_from.Items[1].Selected = false;
            //ChkWater_reg_from.Items[1].Enabled = false;
        }
        hdnfocus.Value = ddlLoc_of_unit.ClientID;
        #region commentedcode
        //if (ddlLoc_of_unit.SelectedIndex != 0)
        //{
        //    if (ddlLoc_of_unit.SelectedValue.ToString().Trim() == "1")
        //    {
        //        trApplType.Visible = true;

        //        ddlAppl_Type.Items.Clear();
        //        ddlAppl_Type.Items.Insert(0, new ListItem("--Select--", "0"));
        //        ddlAppl_Type.Items.Insert(1, new ListItem("Change of Land Use", "1"));
        //        ddlAppl_Type.Items.Insert(2, new ListItem("Industrial Building Approval", "2"));
        //        ddlAppl_Type.Items.Insert(3, new ListItem("Both", "3"));
        //        //ChkWater_reg_from.Items[1].Selected = true;
        //        //ChkWater_reg_from.Items[1].Enabled = false;
        //    }
        //    else if (ddlLoc_of_unit.SelectedValue.ToString().Trim() == "5")
        //    {
        //        trApplType.Visible = true;
        //        ddlAppl_Type.Items.Clear();
        //        ddlAppl_Type.Items.Insert(0, new ListItem("Industrial Building Approval", "2"));

        //        //ChkWater_reg_from.Items[1].Selected = true;
        //        //ChkWater_reg_from.Items[1].Enabled = true;
        //    }
        //    else if (ddlLoc_of_unit.SelectedValue.ToString().Trim() == "3")
        //    {
        //        trApplType.Visible = true;
        //        ddlAppl_Type.Items.Clear();
        //        ddlAppl_Type.Items.Insert(0, new ListItem("--Select--", "0"));
        //        ddlAppl_Type.Items.Insert(1, new ListItem("Change of Land Use", "1"));
        //        ddlAppl_Type.Items.Insert(2, new ListItem("Industrial Building Approval", "2"));
        //        ddlAppl_Type.Items.Insert(3, new ListItem("Both", "3"));
        //        //ChkWater_reg_from.Items[1].Selected = false;
        //        //ChkWater_reg_from.Items[1].Enabled = false;
        //    }

        //    else
        //    {
        //        trApplType.Visible = false;
        //        //ChkWater_reg_from.Items[1].Selected = false;
        //        //ChkWater_reg_from.Items[1].Enabled = false;
        //    }
        //}
        //else
        //{
        //    trApplType.Visible = false;
        //}
        // hdnfocus.Value = ddlLoc_of_unit.ClientID;
        // ddlLoc_of_unit.Focus();
        #endregion
    }
    protected void ddlProp_intVillageid_SelectedIndexChanged(object sender, EventArgs e)
    {
        trApplType.Visible = false;
        if (ddlProp_intVillageid.SelectedIndex != 0)
        {
            ddlLoc_of_unit.Items.Clear();
            DataSet dsss = new DataSet();
            /* commented by lavanya
         dsss = objcommon.GetLOcationofUnitNew(ddlProp_intDistrictid.SelectedValue, ddlProp_intMandalid.SelectedValue);

         if (dsss != null && dsss.Tables.Count > 0 && dsss.Tables[0].Rows.Count > 0)
         {
             ddlLoc_of_unit.DataSource = dsss.Tables[0];
             ddlLoc_of_unit.DataValueField = "UnitLocationId";
             ddlLoc_of_unit.DataTextField = "UnitLocation";
             ddlLoc_of_unit.DataBind();
             AddSelect(ddlLoc_of_unit);
         }
         else
         {
             ddlLoc_of_unit.Items.Clear();
             AddSelect(ddlLoc_of_unit);
         }
         DataSet dscess = Gen.getGWMCVillages(ddlProp_intVillageid.SelectedValue);
         if (dscess.Tables[0].Rows.Count > 0)
         {
             ddlLoc_of_unit.Items.Clear();
             ddlLoc_of_unit.Items.Insert(0, "--Select--");
             ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of KUDA", "3"));
             ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
         }
         #region commentedcode
         // dsss = Gen.GetShowLOcationofUnit(ddlProp_intDistrictid.SelectedValue, ddlProp_intMandalid.SelectedValue);

         //if (dsss.Tables[0].Rows.Count > 0)
         //{
         //    if (dsss.Tables[0].Rows[0][0].ToString().Trim() == "1")
         //    {
         //        ddlLoc_of_unit.Items.Clear();
         //        ddlLoc_of_unit.Items.Insert(0, "--Select--");
         //        ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of HMDA (HMDA list of villages link)", "1"));
         //        ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));

         //        //ChkWater_reg_from.Items[1].Selected = true;
         //        //ChkWater_reg_from.Items[1].Enabled = true;
         //    }
         //    else if (dsss.Tables[0].Rows[0][0].ToString().Trim() == "2")
         //    {
         //        ddlLoc_of_unit.Items.Clear();
         //        ddlLoc_of_unit.Items.Insert(0, "--Select--");
         //        ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of DT&CP", "2"));
         //        ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
         //        //ChkWater_reg_from.Items[1].Selected = false;
         //        //ChkWater_reg_from.Items[1].Enabled = false;
         //    }
         //    else if (dsss.Tables[0].Rows[0][0].ToString().Trim() == "3")
         //    {
         //        ddlLoc_of_unit.Items.Clear();
         //        ddlLoc_of_unit.Items.Insert(0, "--Select--");
         //        ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of KUDA", "3"));
         //        ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
         //        //ChkWater_reg_from.Items[1].Selected = false;
         //        //ChkWater_reg_from.Items[1].Enabled = false;

         //        if (ddlProp_intDistrictid.SelectedValue.ToString() == "9" || ddlProp_intDistrictid.SelectedValue.ToString() == "3")
         //        {
         //            ddlLoc_of_unit.Items.Insert(3, new ListItem("Within the purview of DT&CP", "2"));
         //        }
         //    }
         //    else if (dsss.Tables[0].Rows[0][0].ToString().Trim() == "5")
         //    {
         //        ddlLoc_of_unit.Items.Clear();
         //        ddlLoc_of_unit.Items.Insert(0, "--Select--");
         //        ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of GM DIC,HYD", "5"));
         //        ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
         //        //ChkWater_reg_from.Items[1].Selected = false;
         //        //ChkWater_reg_from.Items[1].Enabled = false;
         //    }
         //    if (ddlProp_intDistrictid.SelectedValue == "5")
         //    {
         //        //ChkWater_reg_from.Items[1].Enabled = true;
         //    }
         //}
         //else
         //{
         //    ddlLoc_of_unit.Items.Clear();
         //    ddlLoc_of_unit.Items.Insert(0, "--Select--");
         //}
         //DataSet dscess = Gen.getGWMCVillages(ddlProp_intVillageid.SelectedValue);*/
            DataSet dscess = Gen.GetUnderLimitsOfVillage(ddlProp_intVillageid.SelectedValue);
            string Muncipal_Flag = "", GHMC_FLG = "", HMR_FLG = "", HMDA_FLG = "", KUDA_FLAG = "", DTCPFLAG = "", YTDA = "";
            //if (dscess.Tables[0].Rows.Count > 0)
            //{
            //    ddlLoc_of_unit.Items.Clear();
            //    ddlLoc_of_unit.Items.Insert(0, "--Select--");
            //    ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of KUDA", "3"));
            //    ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
            //}
            //#endregionlavanya
            if (rdIaLa_Lst.SelectedValue != "Y")
            {
                if (dscess.Tables[0].Rows.Count > 0)//added lavanya
                {
                    Muncipal_Flag = dscess.Tables[0].Rows[0]["Muncipal_Flag"].ToString();
                    GHMC_FLG = dscess.Tables[0].Rows[0]["GHMC_FLG"].ToString();
                    HMR_FLG = dscess.Tables[0].Rows[0]["HMR_FLG"].ToString();
                    HMDA_FLG = dscess.Tables[0].Rows[0]["HMDA_FLG"].ToString();
                    KUDA_FLAG = dscess.Tables[0].Rows[0]["KUDA_FLAG"].ToString();
                    DTCPFLAG = dscess.Tables[0].Rows[0]["DTCPFLAG"].ToString();
                    YTDA = dscess.Tables[0].Rows[0]["YTD"].ToString();

                    if (GHMC_FLG != null && GHMC_FLG == "Y")
                    {
                        ddlLoc_of_unit.Items.Clear();
                        ddlLoc_of_unit.Items.Insert(0, new ListItem("--Select--", "0"));
                        ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of GM DIC,HYD", "5"));
                        //ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
                        ddlLoc_of_unit.SelectedValue = "5";
                    }
                    if ((Muncipal_Flag != null && Muncipal_Flag == "Y") || (DTCPFLAG == "Y"))
                    {
                        ddlLoc_of_unit.Items.Clear();
                        ddlLoc_of_unit.Items.Insert(0, new ListItem("--Select--", "0"));//"--Select--"); //new ListItem("--Select--", "0")
                        ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of DT&CP", "2"));
                        //ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
                        ddlLoc_of_unit.SelectedValue = "2";
                    }
                    if (HMDA_FLG != null && HMDA_FLG == "Y")
                    {
                        ddlLoc_of_unit.Items.Clear();
                        ddlLoc_of_unit.Items.Insert(0, new ListItem("--Select--", "0"));
                        ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of HMDA (HMDA list of villages link)", "1"));
                        //ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
                        ddlLoc_of_unit.SelectedValue = "1";
                        ddlLoc_of_unit_SelectedIndexChanged(sender, e);
                    }
                    if (KUDA_FLAG != null && KUDA_FLAG == "Y")
                    {
                        ddlLoc_of_unit.Items.Clear();
                        ddlLoc_of_unit.Items.Insert(0, new ListItem("--Select--", "0"));
                        ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of KUDA", "3"));
                        //ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
                        ddlLoc_of_unit.SelectedValue = "3";
                    }
                    if (YTDA != null && YTDA == "Y")
                    {
                        ddlLoc_of_unit.Items.Clear();
                        ddlLoc_of_unit.Items.Insert(0, new ListItem("--Select--", "0"));
                        ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of YTDA", "8"));
                        //ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
                        ddlLoc_of_unit.SelectedValue = "8";
                    }
                }
            }
            else
            {
                ddlLoc_of_unit.Items.Clear();
                ddlLoc_of_unit.Items.Insert(0, new ListItem("--Select--", "0"));

                ddlLoc_of_unit.Items.Insert(1, new ListItem("IALA (TSIIC)", "4"));
                ddlLoc_of_unit.SelectedValue = "4";
            }
            if (dscess.Tables.Count > 1 && dscess.Tables[1].Rows.Count > 0) //lavanya
            {
                string municipalFlag = "", UnderLimits = "";
                UnderLimits = dscess.Tables[1].Rows[0]["UnderLimits"].ToString();
                municipalFlag = dscess.Tables[1].Rows[0]["Muncipal_Flag"].ToString();
                if (municipalFlag == "Y")
                {
                    lblLimits.Text = "Municipality";
                    RdFall_in_Municipal.SelectedValue = "M";
                    RdFall_in_Municipal.Enabled = false;
                }
                else
                {
                    RdFall_in_Municipal.SelectedValue = "R";
                    RdFall_in_Municipal.Enabled = true;
                }
                if (UnderLimits != null && UnderLimits != "")
                    lblLimits.Text = UnderLimits;

            }
            if (rdIaLa_Lst.SelectedValue == "Y")
            {
                ddlLoc_of_unit.SelectedValue = "4";
                ddlLoc_of_unit.Enabled = false;
            }
        }
    }
    protected void TxtTot_ExtentNew_TextChanged(object sender, EventArgs e)
    {
        if (TxtTot_ExtentNew.Text.Trim().TrimStart() == "")
        {
            TxtTot_ExtentNew.Text = "0";
        }
        if (txtgunthas.Text.TrimStart().TrimEnd() == "")
        {
            txtgunthas.Text = "0";
        }
        if (ddllandmesurements.SelectedValue != "0")
        {
            if (txtgunthas.Text.TrimStart().TrimEnd() != "")
            {
                TxtTot_Extent.Text = ((Convert.ToDecimal(ddllandmesurements.SelectedValue) * Convert.ToDecimal(TxtTot_ExtentNew.Text.TrimStart().TrimEnd())) + (Convert.ToDecimal(101.17) * Convert.ToDecimal(txtgunthas.Text.TrimStart().TrimEnd()))).ToString();
            }
            else
            {
                if (TxtTot_ExtentNew.Text.TrimStart().TrimEnd() != "")
                {
                    TxtTot_Extent.Text = (Convert.ToDecimal(ddllandmesurements.SelectedValue) * Convert.ToDecimal(TxtTot_ExtentNew.Text.TrimStart().TrimEnd())).ToString();
                }
            }
            //if (TxtTot_ExtentNew.Text.TrimStart().TrimEnd() != "" && TxtTot_ExtentNew.Text.TrimStart().TrimEnd() != "0" && TxtTot_ExtentNew.Text.TrimStart().TrimEnd().Contains("."))
            //{
            //    TxtTot_ExtentNew.Text = TxtTot_ExtentNew.Text.Substring(0, TxtTot_ExtentNew.Text.IndexOf('.')) + TxtTot_ExtentNew.Text.Substring(TxtTot_ExtentNew.Text.IndexOf('.'), 4);
            //}
            //if (TxtTot_ExtentNew.Text.TrimStart().TrimEnd() != "" && TxtTot_ExtentNew.Text.TrimStart().TrimEnd() != "0" && TxtTot_ExtentNew.Text.TrimStart().TrimEnd().Contains("."))
            //{
            //    if (TxtTot_Extent.Text.Substring(0, TxtTot_Extent.Text.IndexOf('.')).Length > 3)
            //    {
            //        TxtTot_Extent.Text = TxtTot_Extent.Text.Substring(0, TxtTot_Extent.Text.IndexOf('.')) + TxtTot_Extent.Text.Substring(TxtTot_Extent.Text.IndexOf('.'), 4);
            //    }
            //}
        }

    }
    protected void ddllandmesurements_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddllandmesurements.SelectedItem.Text.ToUpper() == "ACRE")
        {
            trtxtgunthas.Visible = true;
            TxtTot_ExtentNew.Attributes.Add("placeholder", "Acre");
            tdTxtTot_ExtentNew.InnerHtml = "Acres&nbsp;&nbsp;&nbsp";
        }
        else
        {
            tdTxtTot_ExtentNew.InnerHtml = ddllandmesurements.SelectedItem.Text + "&nbsp;&nbsp;&nbsp";
            TxtTot_ExtentNew.Attributes.Add("placeholder", "");
            trtxtgunthas.Visible = false;
        }

        TxtTot_Extent.Text = "";
        TxtTot_ExtentNew.Text = "";
        ddllandmesurements.Focus();
    }
    protected void ddlcurrencytype_SelectedIndexChanged(object sender, EventArgs e)
    {
        TxtVal_Land.Text = "0";
        TxtVal_Build.Text = "0";
        TxtVal_Plant.Text = "0";
        TxtVal_Land_Actual.Text = "0";
        TxtVal_Build_Actual.Text = "0";
        TxtVal_Plant_Actual.Text = "0";

        TxtVal_Land_ActualExpansion.Text = "0";
        TxtVal_Build_ActualExpn.Text = "0";
        TxtVal_Plant_ActualExpansion.Text = "0";

        TxtVal_LandExpansion.Text = "0";
        TxtVal_BuildExpanstion.Text = "0";
        TxtVal_PlantExpanstion.Text = "0";
    }

    protected void btnShowEnclosers_Click(object sender, EventArgs e)
    {
        // ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Key", "PopupCenter('EncloserList.aspx','popUpWindow','1050','600');", true);
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<Script>window.open('EncloserList.aspx','popUpWindow','height=600,width=850,status=no,toolbar=no,menubar=no,location=no');</Script>", false);
    }
    protected void txtgunthas_TextChanged(object sender, EventArgs e)
    {
        if (ddllandmesurements.SelectedValue != "0")
        {
            if (TxtTot_ExtentNew.Text.Trim().TrimStart() == "")
            {
                TxtTot_ExtentNew.Text = "0";
            }
            if (txtgunthas.Text.TrimStart().TrimEnd() == "")
            {
                txtgunthas.Text = "0";
            }
            if (TxtTot_ExtentNew.Text.Trim().TrimStart() != "")
            {
                if (txtgunthas.Text.TrimStart().TrimEnd() != "")
                {
                    TxtTot_Extent.Text = ((Convert.ToDecimal(101.17) * Convert.ToDecimal(txtgunthas.Text.TrimStart().TrimEnd())) + (Convert.ToDecimal(ddllandmesurements.SelectedValue) * Convert.ToDecimal(TxtTot_ExtentNew.Text.TrimStart().TrimEnd()))).ToString();
                }
            }
            else
            {
                if (txtgunthas.Text.TrimStart().TrimEnd() != "")
                {
                    TxtTot_Extent.Text = (Convert.ToDecimal(101.17) * Convert.ToDecimal(txtgunthas.Text.TrimStart().TrimEnd())).ToString();
                }
            }
            //if (TxtTot_ExtentNew.Text.TrimStart().TrimEnd() != "" && TxtTot_ExtentNew.Text.TrimStart().TrimEnd() != "0" && TxtTot_ExtentNew.Text.TrimStart().TrimEnd().Contains("."))
            //{
            //    if (TxtTot_Extent.Text.Substring(0, TxtTot_Extent.Text.IndexOf('.')).Length > 3)
            //    {
            //        TxtTot_Extent.Text = TxtTot_Extent.Text.Substring(0, TxtTot_Extent.Text.IndexOf('.')) + TxtTot_Extent.Text.Substring(TxtTot_Extent.Text.IndexOf('.'), 4);
            //    }
            //}
        }
    }
    protected void rdIaLa_Lst_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rdIaLa_Lst.SelectedValue.ToString().Trim() == "Y")
            {
                lblIndusText.Visible = true;
                ddlIndustrialParkName.Visible = true;
                //ddlProp_intDistrictid.Enabled = false;
                ddlProp_intDistrictid.Items.Clear();
                BindDistricts();
                // AddSelect(ddlProp_intDistrictid);

                ddlProp_intMandalid.Items.Clear();
                AddSelect(ddlProp_intMandalid);

                ddlProp_intVillageid.Items.Clear();
                AddSelect(ddlProp_intVillageid);
                ddlProp_intMandalid.Enabled = false;
                ddlProp_intVillageid.Enabled = false;
                trIndustries.Visible = true;
                ListItem item = ddlLoc_of_unit.Items.FindByText("4");
                if (item != null)
                {
                    ddlLoc_of_unit.Items.FindByText("4").Selected = true;
                    ddlLoc_of_unit.Enabled = false;

                }
                AddSelect(ddlIndustrialParkName);
            }
            else
            {
                lblIndusText.Visible = false;
                ddlIndustrialParkName.Visible = false;
                ddlProp_intDistrictid.Enabled = true;
                ddlProp_intMandalid.Enabled = true;
                ddlProp_intVillageid.Enabled = true;
                ddlProp_intDistrictid.Items.Clear();
                BindDistricts();
                // AddSelect(ddlProp_intDistrictid);

                ddlProp_intMandalid.Items.Clear();
                AddSelect(ddlProp_intMandalid);

                ddlProp_intVillageid.Items.Clear();
                AddSelect(ddlProp_intVillageid);
                ddlIndustrialParkName.Items.Clear();
                ddlLoc_of_unit.Enabled = true;
                trIndustries.Visible = false;

                ListItem item = ddlLoc_of_unit.Items.FindByText("0");
                if (item != null)
                {
                    ddlLoc_of_unit.Items.FindByText("0").Selected = true;
                }
                // ddlLoc_of_unit.SelectedValue = "2";
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }

    private void BindIndustrialParks()
    {
        try
        {
            DataSet dsParks = new DataSet();
            int DistrictCd = Convert.ToInt32(ddlProp_intDistrictid.SelectedValue);
            ddlIndustrialParkName.Items.Clear();
            dsParks = objcommon.GetIALAParks(0, DistrictCd);
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
            lblmsg.Text = ex.Message;
        }
    }
    protected void ddlIndustrialParkName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet dsParks = new DataSet();
            int IALACode = Convert.ToInt32(ddlIndustrialParkName.SelectedValue);
            dsParks = objcommon.GetIALAParks(IALACode, 0);
            if (dsParks != null && dsParks.Tables.Count > 0 && dsParks.Tables[0].Rows.Count > 0)
            {
                string districtCd = "0", MandalCd = "0", VillageCd = "0";
                districtCd = dsParks.Tables[0].Rows[0]["Districtcd"].ToString();
                MandalCd = dsParks.Tables[0].Rows[0]["Mandalcd"].ToString();
                VillageCd = dsParks.Tables[0].Rows[0]["Villagecd"].ToString();
                //ddlProp_intDistrictid.SelectedValue = ddlProp_intDistrictid.Items.FindByValue(districtCd).Value;

                //ddlProp_intDistrictid_SelectedIndexChanged(sender, e);
                ddlProp_intMandalid.SelectedValue = ddlProp_intMandalid.Items.FindByValue(MandalCd).Value;
                ddlProp_intMandalid_SelectedIndexChanged(sender, e);

                ddlProp_intVillageid.SelectedValue = ddlProp_intVillageid.Items.FindByValue(VillageCd).Value;
                ddlProp_intVillageid_SelectedIndexChanged(sender, e);
            }
        }

        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }
    public void BindLabourApplication()
    {
        try
        {
            DataSet dsd = new DataSet();
            dsd = Gen.GetLabourApplicationType();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ChkLabour_Application.DataSource = dsd.Tables[0];
                ChkLabour_Application.DataTextField = "Qname";
                ChkLabour_Application.DataValueField = "Application_Id";
                ChkLabour_Application.DataBind();
            }
        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }
    public void ProjectCostFinal()
    {
        if (Convert.ToDecimal(TxtTot_PrjCost.Text.Trim()) > 10000)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Your project cost mentioned above 100 crores. please proceede if this is correct..!');", true);
        }
    }
    protected void ddlproposal_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlproposal.SelectedValue == "1")
        {
            tdprojectcostname.InnerHtml = "<u>New Enterprice</u>";
            tblexpansion.Visible = false;
        }
        else
        {
            tdprojectcostname.InnerHtml = "<u>Existing Enterprice</u>";
            tblexpansion.Visible = true;

        }
    }
    protected void TxtVal_Land_Actual_TextChanged(object sender, EventArgs e)
    {
        if (ddlcurrencytype.SelectedValue != "0")
        {
            if (TxtVal_Land_Actual.Text.TrimStart().TrimEnd() != "" && TxtVal_Land_Actual.Text.TrimStart().TrimEnd() != "0")
            {
                TxtVal_Land.Text = (Convert.ToDecimal(TxtVal_Land_Actual.Text.Trim()) * Convert.ToDecimal(ddlcurrencytype.SelectedValue)).ToString();
                TxtVal_Land_TextChanged(sender, e);
            }
        }
    }
    protected void TxtVal_Build_Actual_TextChanged(object sender, EventArgs e)
    {
        if (ddlcurrencytype.SelectedValue != "0")
        {
            if (TxtVal_Build_Actual.Text.TrimStart().TrimEnd() != "" && TxtVal_Build_Actual.Text.TrimStart().TrimEnd() != "0")
            {
                TxtVal_Build.Text = (Convert.ToDecimal(TxtVal_Build_Actual.Text.Trim()) * Convert.ToDecimal(ddlcurrencytype.SelectedValue)).ToString();
                TxtVal_Build_TextChanged(sender, e);
            }
        }
    }
    protected void TxtVal_Plant_Actual_TextChanged(object sender, EventArgs e)
    {
        if (ddlcurrencytype.SelectedValue != "0")
        {
            if (TxtVal_Plant_Actual.Text.TrimStart().TrimEnd() != "" && TxtVal_Plant_Actual.Text.TrimStart().TrimEnd() != "0")
            {
                TxtVal_Plant.Text = (Convert.ToDecimal(TxtVal_Plant_Actual.Text.Trim()) * Convert.ToDecimal(ddlcurrencytype.SelectedValue)).ToString();
                TxtVal_Plant_TextChanged(sender, e);
            }
        }
    }
    protected void TxtVal_Land_ActualExpansion_TextChanged(object sender, EventArgs e)
    {
        if (ddlcurrencytype.SelectedValue != "0")
        {
            if (TxtVal_Land_ActualExpansion.Text.TrimStart().TrimEnd() != "" && TxtVal_Land_ActualExpansion.Text.TrimStart().TrimEnd() != "0")
            {
                TxtVal_LandExpansion.Text = (Convert.ToDecimal(TxtVal_Land_ActualExpansion.Text.Trim()) * Convert.ToDecimal(ddlcurrencytype.SelectedValue)).ToString();
                TxtVal_LandExpansion_TextChanged(sender, e);
            }
        }
    }

    protected void TxtVal_LandExpansion_TextChanged(object sender, EventArgs e)
    {
        CalculatationEnterprisePrjCostExpansion();
    }
    protected void TxtVal_Build_ActualExpn_TextChanged(object sender, EventArgs e)
    {
        if (ddlcurrencytype.SelectedValue != "0")
        {
            if (TxtVal_Build_ActualExpn.Text.TrimStart().TrimEnd() != "" && TxtVal_Build_ActualExpn.Text.TrimStart().TrimEnd() != "0")
            {
                TxtVal_BuildExpanstion.Text = (Convert.ToDecimal(TxtVal_Build_ActualExpn.Text.Trim()) * Convert.ToDecimal(ddlcurrencytype.SelectedValue)).ToString();
                TxtVal_BuildExpanstion_TextChanged(sender, e);
            }
        }
    }
    protected void TxtVal_BuildExpanstion_TextChanged(object sender, EventArgs e)
    {
        CalculatationEnterprisePrjCostExpansion();
    }
    protected void TxtVal_Plant_ActualExpansion_TextChanged(object sender, EventArgs e)
    {
        if (ddlcurrencytype.SelectedValue != "0")
        {
            if (TxtVal_Plant_ActualExpansion.Text.TrimStart().TrimEnd() != "" && TxtVal_Plant_ActualExpansion.Text.TrimStart().TrimEnd() != "0")
            {
                TxtVal_PlantExpanstion.Text = (Convert.ToDecimal(TxtVal_Plant_ActualExpansion.Text.Trim()) * Convert.ToDecimal(ddlcurrencytype.SelectedValue)).ToString();
                TxtVal_PlantExpanstion_TextChanged(sender, e);
            }
        }
    }
    protected void TxtVal_PlantExpanstion_TextChanged(object sender, EventArgs e)
    {
        CalculatationEnterprisePrjCostExpansion();
    }
    protected void ChkLabour_Application_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ChkLabour_Application.SelectedValue == "2")
        {
            tract4.Visible = true;
        }
        else
        {
            tract4.Visible = false;
        }
    }

}