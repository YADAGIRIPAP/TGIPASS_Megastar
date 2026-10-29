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


public partial class UI_TSiPASS_frmQuesstionniareRegCFOHotel : System.Web.UI.Page
{
    DB.DB con = new DB.DB();

    int delete = 0;
    comFunctions cmf = new comFunctions();
    CommonBL objcommon = new CommonBL();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    decimal TotalFee;
    LabourCFOService.TSLabourServiceImplService labourcfo = new LabourCFOService.TSLabourServiceImplService();
    LabourShopServiceVo labourservicevo = new LabourShopServiceVo();
    HMDAService.tsipass HMDAObj = new HMDAService.tsipass();
    HMDAService.ApplicationFormResponse hmdapplicationresponse = new HMDAService.ApplicationFormResponse();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session.Count <= 0)
            {
                //Response.Redirect("../../Index.aspx");
                Response.Redirect("~/Index.aspx");
            }

            if (!IsPostBack)
            {
                //Tab1.CssClass = "Clicked";
                MainView.ActiveViewIndex = 0;
                BtnSave1.Visible = false;
                BindenterpriseSectors();
                BindDistricts();
                BinCurrencyType();
                BindLineofActivityName();
                BindHotelCategories();
                ddlSector.SelectedValue = "1";

                Session["Applid"] = "0";

                DataSet dscheck = new DataSet();
                string TourismFlag = "";
                if (Session["HOTEL"] != null && Session["HOTEL"].ToString() != "")
                {
                    TourismFlag = Session["HOTEL"].ToString();
                }

                DataSet dschecknew = new DataSet();
                dschecknew = Gen.GetShowQuestionariesCFOnew(Session["uid"].ToString().Trim());
                if (dschecknew != null && dschecknew.Tables.Count > 0 && dschecknew.Tables[0].Rows.Count > 0)
                {
                    ddlHotelType.Enabled = false;
                    ddlintLineofActivity.Enabled = false;
                    fillDetails(dschecknew);
                    if (TourismFlag == "")
                        TourismFlag = dschecknew.Tables[0].Rows[0]["TourismFlag"].ToString().Trim();

                    if (TourismFlag == "Y")
                    {
                        lblSectorofEnterprise.Visible = false;
                        lblHotelLineofActivity.Visible = true;
                        ddlSector.SelectedValue = "2";
                        ddlSector.Visible = false;
                        lblLineofActivity.Text = "Pollution Category of Unit";

                        ViewState["TOURISMFLAG"] = "Y";
                        Session["HOTEL"] = "Y";
                        trhotelcfo.Visible = true;
                        trTradeLicense.Visible = true;
                        trFSSAI.Visible = true;
                        // trTourismClassification.Visible = true;
                        //trfire.Visible = true;
                        //Label2.Text = "Fire Approval";
                        Trsteampipeline.Visible = false;
                        BindHotelCategories();

                    }
                    else
                    {
                        lblSectorofEnterprise.Visible = true;
                        ddlSector.Visible = true;
                        lblHotelLineofActivity.Visible = false;
                        lblLineofActivity.Text = "Line of Activity";

                        trTradeLicense.Visible = false;
                        trFSSAI.Visible = false;
                        // trTourismClassification.Visible = false;
                        Trsteampipeline.Visible = true;

                    }
                }
                else
                {
                    dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());

                    fillDetailsCFE(dscheck);


                }

                if (txtcfeuidno.Text.Trim() == "")
                {
                    dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
                    if (dscheck != null && dscheck.Tables.Count > 0 && dscheck.Tables[0].Rows.Count > 0)
                    {
                        txtcfeuidno.Text = dscheck.Tables[2].Rows[0]["UID_No"].ToString().Trim();
                        txtcfeuidno.Enabled = false;
                    }
                }

            }
            if (!IsPostBack)
            {
                DataSet dsver = new DataSet();
                dsver = Gen.Getverifyofque9CFO(Session["Applid"].ToString());
                if (dsver.Tables[0].Rows.Count > 0)
                {
                    string res = Gen.RetriveStatusCFO(Session["Applid"].ToString());
                    ////string res = Gen.RetriveStatus("1002");


                    if (res == "3" || Convert.ToInt32(res) >= 3)
                    {
                        BtnSave2.Visible = false;
                        BtnSave1.Visible = false;
                        BtnClear.Visible = false;
                        ResetFormControl(this);
                    }

                }

                DataSet dsbp = new DataSet();
                dsbp = Gen.GetBuildingPErmissionNumber(Session["uid"].ToString(), "", "");
                if (dsbp != null && dsbp.Tables.Count > 0 && dsbp.Tables[0].Rows.Count > 0)
                {
                    if (dsbp.Tables[0].Rows[0]["INTAPPROVALID"].ToString() != null)
                    {
                        if (dsbp.Tables[0].Rows[0]["INTAPPROVALID"].ToString() == "31")
                        {
                            RDOC.SelectedValue = "TSIIC";
                            RDOC.Enabled = false;
                            RDOC_SelectedIndexChanged(sender, e);
                        }
                        if (dsbp.Tables[0].Rows[0]["INTAPPROVALID"].ToString() == "35")
                        {
                            RDOC.SelectedValue = "HMDA";
                            RDOC.Enabled = false;
                            RDOC_SelectedIndexChanged(sender, e);
                        }
                    }
                    //if (dsbp.Tables[0].Rows[0]["Filenumber"].ToString() != null)
                    if (dsbp.Tables[0].Rows[0]["Filenumber"].ToString() != "" && dsbp.Tables[0].Rows[0]["Filenumber"].ToString() != null)
                    {
                        txtfilenumber.Text = dsbp.Tables[0].Rows[0]["Filenumber"].ToString();
                        txtfilenumber_TextChanged(sender, e);
                        txtfilenumber.Enabled = false;
                    }
                    if (dsbp.Tables[0].Rows[0]["architectno"].ToString() != null)
                    {
                    }
                }

            }

            if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
            {

            }

            if (ddlProp_intVillageid.SelectedIndex == 0)
            {
                ddlProp_intVillageid.Enabled = true;
            }
            if (txtPlantvalueActual.Text == "0.00")
            {
                txtPlantvalueActual.ReadOnly = false;
                txtPlantvalueActual.Enabled = true;
            }
            if (txtPlantvalue.Text == "0.00")
            {
                txtPlantvalue.ReadOnly = false;
                txtPlantvalue.Enabled = true;
            }
            RdbExecptedact1_SelectedIndexChanged(sender, e);
            RdbExecptedact1.Enabled = false;
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    public void BindHotelCategories()
    {
        try
        {
            ddlHotelType.Items.Clear();
            DataSet dsc = new DataSet();
            dsc = Gen.GetHotelCategories(Session["uid"].ToString());
            if (dsc != null && dsc.Tables.Count > 0 && dsc.Tables[0].Rows.Count > 0)
            {
                ddlHotelType.DataSource = dsc.Tables[0];
                ddlHotelType.DataValueField = "Type_cd";
                ddlHotelType.DataTextField = "Type_Desc";
                ddlHotelType.DataBind();
                ddlHotelType.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlHotelType.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    #region Methods
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
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
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
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
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
            dsc = Gen.GetCategoryDetNew(Session["uid"].ToString());
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
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
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
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }
    #endregion

    public void ResetFormControl(Control parent)
    {
        try
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
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    public void fillDetailsCFE(DataSet dscheck)
    {
        //DataSet dscheck = new DataSet();  Commented by CMS
        //dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());   Commented by CMS
        try
        {
            if (dscheck.Tables[0].Rows.Count > 0)
            {
                //if (dscheck.Tables[0].Rows[0]["LabelConfirmation"].ToString() != "")
                //    rbtnLstLabel.SelectedValue = rbtnLstLabel.Items.FindByValue(dscheck.Tables[0].Rows[0]["LabelConfirmation"].ToString().Trim()).Value;
                // rdPoliceNOC.SelectedValue = rdPoliceNOC.Items.FindByValue(dscheck.Tables[0].Rows[0]["PoliceNOCFlag"].ToString().Trim()).Value;
                //  rdPoliceNOC_SelectedIndexChanged(sender, e);
                ddlHotelType.Enabled = false;
                ddlintLineofActivity.Enabled = false;
                string TourismFlag = dscheck.Tables[0].Rows[0]["TourismFlag"].ToString().Trim();
                if (TourismFlag == "Y")
                {
                    lblSectorofEnterprise.Visible = false;
                    lblHotelLineofActivity.Visible = true;
                    ddlSector.SelectedValue = "2";
                    ddlSector.Visible = false;
                    lblLineofActivity.Text = "Pollution Category of Unit";

                    ViewState["TOURISMFLAG"] = "Y";
                    Session["HOTEL"] = "Y";
                    //trTourismPoliceNOC.Visible = true;
                    trTradeLicense.Visible = true;
                    trFSSAI.Visible = true;
                    Trsteampipeline.Visible = false;
                    BindHotelCategories();
                    trhotelcfo.Visible = true;
                }
                else
                {
                    lblSectorofEnterprise.Visible = true;
                    ddlSector.Visible = true;
                    lblHotelLineofActivity.Visible = false;
                    lblLineofActivity.Text = "Line of Activity";

                    trTradeLicense.Visible = false;
                    trFSSAI.Visible = false;
                    Trsteampipeline.Visible = true;
                }
                if (dscheck.Tables[0].Rows[0]["Hotel_Type"].ToString() != "")
                    ddlHotelType.SelectedValue = dscheck.Tables[0].Rows[0]["Hotel_Type"].ToString().Trim();
                txtNameOfIndustrialUndertaking.Text = dscheck.Tables[0].Rows[0]["nameofunit"].ToString();
                if (dscheck.Tables[0].Rows[0]["Hotel_Type"].ToString() != "")
                    ddlHotelType.SelectedValue = dscheck.Tables[0].Rows[0]["Hotel_Type"].ToString();


                if (dscheck.Tables[0].Rows[0]["BuildingWorker"].ToString() != "")
                    txtNoofworkers.Text = dscheck.Tables[0].Rows[0]["BuildingWorker"].ToString().Trim();

                if (dscheck.Tables[0].Rows[0]["ContractWorker"].ToString() != "")
                    txtContractLabourAct.Text = dscheck.Tables[0].Rows[0]["ContractWorker"].ToString().Trim();

                if (dscheck.Tables[0].Rows[0]["MigrantWorker"].ToString() != "")
                    txtMigrantWorkmanAct.Text = dscheck.Tables[0].Rows[0]["MigrantWorker"].ToString().Trim();

                txtcfeuidno.Text = dscheck.Tables[2].Rows[0]["UID_No"].ToString().Trim();

                ddlSector.SelectedValue = ddlSector.Items.FindByValue(dscheck.Tables[0].Rows[0]["Sector_Ent"].ToString().Trim()).Value;
                ddlProp_intDistrictid.SelectedValue = dscheck.Tables[0].Rows[0]["Prop_intDistrictid"].ToString().Trim();
                EventArgs e = new EventArgs();
                object sender = new object();
                ddlProp_intDistrictid_SelectedIndexChanged(this, EventArgs.Empty);

                string LabourAct_Id = dscheck.Tables[0].Rows[0]["LabourAct_Id"].ToString().Trim();
                if (LabourAct_Id != null && LabourAct_Id != "")
                {
                    string[] values = LabourAct_Id.Split(',');
                    for (int i = 0; i < values.Length; i++)
                    {
                        if (values[i] == "3")
                        {
                            RdbExecpted0.SelectedValue = "Y";
                            RdbExecpted0_SelectedIndexChanged(sender, e);
                        }
                        if (values[i] == "4")
                        {
                            RdbExecpted1.SelectedValue = "Y";
                            RdbExecpted1_SelectedIndexChanged(sender, e);
                        }
                        if (values[i] == "2")
                        {
                            RdbExecptedact1.SelectedValue = "Y";
                            RdbExecptedact1_SelectedIndexChanged(sender, e);
                        }
                    }
                }

                if (ddlProp_intMandalid.Items.FindByValue(dscheck.Tables[0].Rows[0]["Prop_intMandalid"].ToString().Trim()) != null)
                {

                    ddlProp_intMandalid.SelectedValue = ddlProp_intMandalid.Items.FindByValue(dscheck.Tables[0].Rows[0]["Prop_intMandalid"].ToString().Trim()).Value;
                    ddlProp_intMandalid_SelectedIndexChanged(sender, e);
                }
                if (ddlProp_intVillageid.Items.FindByValue(dscheck.Tables[0].Rows[0]["Prop_intVillageid"].ToString().Trim()) != null)
                {
                    try
                    {
                        ddlProp_intVillageid.SelectedValue = ddlProp_intVillageid.Items.FindByValue(dscheck.Tables[0].Rows[0]["Prop_intVillageid"].ToString().Trim()).Value;
                        ddlProp_intVillageid_SelectedIndexChanged(this, EventArgs.Empty);
                    }
                    catch (Exception ex)
                    {
                        ddlProp_intVillageid.Enabled = true;
                    }
                }
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

                txtlandvalueActul.Text = dscheck.Tables[0].Rows[0]["Val_Land_Actul"].ToString().Trim();
                txtbuildingvalueActual.Text = dscheck.Tables[0].Rows[0]["Val_Build_Actul"].ToString().Trim();
                txtPlantvalueActual.Text = dscheck.Tables[0].Rows[0]["Val_Plant_Actul"].ToString().Trim();

                txtlandvalue.Text = dscheck.Tables[0].Rows[0]["Val_Land"].ToString().Trim();
                txtbuildingvalue.Text = dscheck.Tables[0].Rows[0]["Val_Build"].ToString().Trim();
                txtPlantvalue.Text = dscheck.Tables[0].Rows[0]["Val_Plant"].ToString().Trim();

                txttotal.Text = dscheck.Tables[0].Rows[0]["Tot_PrjCost"].ToString().Trim();



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
                if (ddlproposal.SelectedValue == "2")
                {
                    CalculatationEnterprisevalueLandExpansion();
                    CalculatationEnterprisevalueBildExpansion();
                    CalculatationEnterprisevaluePlantExpansion();
                    CalculatationEnterprisefinalTotalvalue();
                }
                if (ddlintLineofActivity.Items.FindByValue(dscheck.Tables[0].Rows[0]["intLineofActivity"].ToString().Trim()) != null)
                {
                    ddlintLineofActivity.SelectedValue = ddlintLineofActivity.Items.FindByValue(dscheck.Tables[0].Rows[0]["intLineofActivity"].ToString().Trim()).Value;
                    ddlintLineofActivity_SelectedIndexChanged(sender, e);
                }

                if (dscheck.Tables[0].Rows[0]["Pol_Indus"].ToString().Trim() != "")
                {
                    RdPol_Indus.SelectedValue = RdPol_Indus.Items.FindByValue(dscheck.Tables[0].Rows[0]["Pol_Indus"].ToString().Trim()).Value;
                }
                //  HdfLblPol_Category.Value=dscheck.Tables[0].Rows[0]["Tot_Extent"].ToString().Trim();

                if (ddlSector.SelectedItem.Text != "--Select--")
                    ddlSector.Enabled = false;
                else
                    ddlSector.Enabled = true;

                if (ddlProp_intDistrictid.SelectedItem.Text != "--District--")
                    ddlProp_intDistrictid.Enabled = false;
                else
                    ddlProp_intDistrictid.Enabled = true;

                if (ddlProp_intMandalid.SelectedItem.Text != "--Mandal--")
                    ddlProp_intMandalid.Enabled = false;
                else
                    ddlProp_intMandalid.Enabled = true;

                if (ddlProp_intVillageid.SelectedItem.Text != "--Village--")
                    ddlProp_intVillageid.Enabled = false;
                else
                    ddlProp_intVillageid.Enabled = true;

                // RdbExecptedact1.Enabled = false;
                if (ddlcurrencytype.SelectedItem.Text != "--Select--")
                    ddlcurrencytype.Enabled = false;
                else
                    ddlcurrencytype.Enabled = true;

                if (ddlproposal.SelectedItem.Text != "--Select--")
                    ddlproposal.Enabled = false;
                else
                    ddlproposal.Enabled = true;
                if (txtlandvalueActul.Text.Trim().TrimStart() != "")
                    txtlandvalueActul.Enabled = false;
                else
                    txtlandvalueActul.Enabled = true;

                if (txtbuildingvalueActual.Text.Trim().TrimStart() != "")
                    txtbuildingvalueActual.Enabled = false;
                else
                    txtbuildingvalueActual.Enabled = true;
                if (txtPlantvalueActual.Text.Trim().TrimStart() != "")
                    txtPlantvalueActual.Enabled = false;
                else
                    txtPlantvalueActual.Enabled = true;
                if (txtlandvalue.Text.Trim().TrimStart() != "")
                    txtlandvalue.Enabled = false;
                else
                    txtlandvalue.Enabled = true;

                if (txtbuildingvalue.Text.Trim().TrimStart() != "")
                    txtbuildingvalue.Enabled = false;
                else
                    txtbuildingvalue.Enabled = true;
                if (txtPlantvalue.Text.Trim().TrimStart() != "")
                    txtPlantvalue.Enabled = false;
                else
                    txtPlantvalue.Enabled = true;

                if (TxtVal_Land_ActualExpansion.Text.Trim().TrimStart() != "")
                    TxtVal_Land_ActualExpansion.Enabled = false;
                else
                    TxtVal_Land_ActualExpansion.Enabled = true;

                if (TxtVal_Build_ActualExpn.Text.Trim().TrimStart() != "")
                    TxtVal_Build_ActualExpn.Enabled = false;
                else
                    TxtVal_Build_ActualExpn.Enabled = true;

                if (TxtVal_Plant_ActualExpansion.Text.Trim().TrimStart() != "")
                    TxtVal_Plant_ActualExpansion.Enabled = false;
                else
                    TxtVal_Plant_ActualExpansion.Enabled = true;

                if (TxtVal_LandExpansion.Text.Trim().TrimStart() != "")
                    TxtVal_LandExpansion.Enabled = false;
                else
                    TxtVal_LandExpansion.Enabled = true;

                if (TxtVal_BuildExpanstion.Text.Trim().TrimStart() != "")
                    TxtVal_BuildExpanstion.Enabled = false;
                else
                    TxtVal_BuildExpanstion.Enabled = true;

                if (TxtVal_PlantExpanstion.Text.Trim().TrimStart() != "")
                    TxtVal_PlantExpanstion.Enabled = false;
                else
                    TxtVal_PlantExpanstion.Enabled = true;

                if (txtlbltotalprojectcostexpanstion.Text.Trim().TrimStart() != "")
                    txtlbltotalprojectcostexpanstion.Enabled = false;
                else
                    txtlbltotalprojectcostexpanstion.Enabled = true;

                if (txtNameOfIndustrialUndertaking.Text.Trim().TrimStart() != "")
                    txtNameOfIndustrialUndertaking.Enabled = false;
                else
                    txtNameOfIndustrialUndertaking.Enabled = true;


                if (ddlintLineofActivity.SelectedItem.Text != "--Select--")
                    ddlintLineofActivity.Enabled = false;
                else
                    ddlintLineofActivity.Enabled = true;

                // RdPol_Indus.Enabled = false;
            }
            else
            {
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    void fillDetails(DataSet dscheck)
    {

        try
        {
            if (dscheck.Tables[0].Rows.Count > 0)
            {
                //Classification_Rating
                EventArgs e = new EventArgs();
                if (dscheck.Tables[0].Rows[0]["PoliceNOCFlag"].ToString() != "")
                {
                    rdPoliceNOC.SelectedValue = dscheck.Tables[0].Rows[0]["PoliceNOCFlag"].ToString();
                    rdPoliceNOC_SelectedIndexChanged(rdPoliceNOC, e);
                }
                if (dscheck.Tables[0].Rows[0]["ParkingCondition_Flag"].ToString() != "")
                {
                    rdParkingCondition.SelectedValue = dscheck.Tables[0].Rows[0]["ParkingCondition_Flag"].ToString();
                    rdParkingCondition_SelectedIndexChanged(rdParkingCondition, e);
                    txtParkingConditionYesRemarks.Text = dscheck.Tables[0].Rows[0]["ParkingCondition"].ToString();
                }
                if (dscheck.Tables[0].Rows[0]["StorageConstruction_Flag"].ToString() != "")
                {
                    rdStorageConstruction.SelectedValue = dscheck.Tables[0].Rows[0]["StorageConstruction_Flag"].ToString();
                    rdStorageConstruction_SelectedIndexChanged(rdStorageConstruction, e);
                    txtStorageConstructionYesRemarks.Text = dscheck.Tables[0].Rows[0]["StorageConstruction"].ToString();

                }
                if (dscheck.Tables[0].Rows[0]["Hotel_Type"].ToString() != "" && dscheck.Tables[0].Rows[0]["Hotel_Type"].ToString() != "-")
                    ddlHotelType.SelectedValue = dscheck.Tables[0].Rows[0]["Hotel_Type"].ToString();

                //quesionervoobj.Classification_Rating = ddlClassification.SelectedValue;
                if (dscheck.Tables[0].Rows[0]["Bar_License"].ToString() != "")
                    rdBarLicense.SelectedValue = dscheck.Tables[0].Rows[0]["Bar_License"].ToString();
                if (dscheck.Tables[0].Rows[0]["Trade_License"].ToString() != "")
                    rbtnTradeLicense.SelectedValue = dscheck.Tables[0].Rows[0]["Trade_License"].ToString();
                if (dscheck.Tables[0].Rows[0]["HealthSDG_License"].ToString() != "")
                    rbtnHealthandSanitary.SelectedValue = dscheck.Tables[0].Rows[0]["HealthSDG_License"].ToString();
                if (dscheck.Tables[0].Rows[0]["FSSAI_Certificate"].ToString() != "")
                    rbtnFSSAI.SelectedValue = dscheck.Tables[0].Rows[0]["FSSAI_Certificate"].ToString();
                if (dscheck.Tables[0].Rows[0]["Built_up_Area_Hotel"].ToString() != "")
                    TxtBuilt_up_Area.Text = dscheck.Tables[0].Rows[0]["Built_up_Area_Hotel"].ToString();


                txtcfeuidno.Text = dscheck.Tables[0].Rows[0]["CFE_UID_NO"].ToString();

                if (dscheck.Tables[0].Rows[0]["Sector_Ent"].ToString().Trim() != "")
                {
                    ddlSector.SelectedValue = ddlSector.Items.FindByValue(dscheck.Tables[0].Rows[0]["Sector_Ent"].ToString().Trim()).Value;

                }
                //ddlSector.SelectedValue = ddlSector.Items.FindByValue(dscheck.Tables[0].Rows[0]["Sector_Ent"].ToString().Trim()).Value;

                ddlProp_intDistrictid.SelectedValue = dscheck.Tables[0].Rows[0]["Prop_intDistrictid"].ToString().Trim();
                if (ddlProp_intDistrictid.SelectedIndex == 0)
                {
                    ddlProp_intMandalid.Items.Clear();
                    ddlProp_intMandalid.Items.Insert(0, "--Mandal--");
                    //ChkWater_reg_from.Items.Clear();
                    //ChkWater_reg_from.Items.Insert(0, new ListItem("New Bore well", "New Bore well"));
                    //ChkWater_reg_from.Items.Insert(1, new ListItem("HMWS & SB", "HMWS & SB"));
                    //ChkWater_reg_from.Items.Insert(2, new ListItem("Rivers/Canals", "Rivers/Canals"));
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
                ddlProp_intMandalid.SelectedValue = ddlProp_intMandalid.Items.FindByValue(dscheck.Tables[0].Rows[0]["Prop_intMandalid"].ToString().Trim()).Value;
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
                }
                try
                {
                    ddlProp_intVillageid.SelectedValue = ddlProp_intVillageid.Items.FindByValue(dscheck.Tables[0].Rows[0]["Prop_intVillageid"].ToString().Trim()).Value;
                }
                catch (Exception ex)
                {
                    ddlProp_intVillageid.Enabled = true;
                }
                if (dscheck.Tables[0].Rows[0]["CurrencyType"].ToString() != "")
                {
                    ddlcurrencytype.SelectedValue = ddlcurrencytype.Items.FindByText(dscheck.Tables[0].Rows[0]["CurrencyType"].ToString().Trim()).Value;
                }
                if (dscheck.Tables[0].Rows[0]["ProposalForQue"].ToString() != "")
                {
                    ddlproposal.SelectedValue = ddlproposal.Items.FindByText(dscheck.Tables[0].Rows[0]["ProposalForQue"].ToString().Trim()).Value;
                    ddlproposal_SelectedIndexChanged(this, EventArgs.Empty);
                }
                else
                {
                    ddlproposal.SelectedValue = "1";
                    ddlproposal_SelectedIndexChanged(this, EventArgs.Empty);
                }
                txtlandvalue.Text = dscheck.Tables[0].Rows[0]["Val_Land"].ToString().Trim();
                txtbuildingvalue.Text = dscheck.Tables[0].Rows[0]["Val_Build"].ToString().Trim();
                txtPlantvalue.Text = dscheck.Tables[0].Rows[0]["Val_Plant"].ToString().Trim();
                txttotal.Text = dscheck.Tables[0].Rows[0]["Tot_PrjCost"].ToString().Trim();

                txtlandvalueActul.Text = dscheck.Tables[0].Rows[0]["Val_Land_Actul"].ToString().Trim();
                txtbuildingvalueActual.Text = dscheck.Tables[0].Rows[0]["Val_Build_Actul"].ToString().Trim();
                txtPlantvalueActual.Text = dscheck.Tables[0].Rows[0]["Val_Plant_Actul"].ToString().Trim();

                //Expansion
                TxtVal_Land_ActualExpansion.Text = dscheck.Tables[0].Rows[0]["Val_Land_ActulExpansion"].ToString().Trim();
                TxtVal_Build_ActualExpn.Text = dscheck.Tables[0].Rows[0]["Val_Build_ActulExpansion"].ToString().Trim();
                TxtVal_Plant_ActualExpansion.Text = dscheck.Tables[0].Rows[0]["Val_Plant_ActulExpansion"].ToString().Trim();

                TxtVal_LandExpansion.Text = dscheck.Tables[0].Rows[0]["Val_LandExpansion"].ToString().Trim();
                TxtVal_BuildExpanstion.Text = dscheck.Tables[0].Rows[0]["Val_BuildExpansion"].ToString().Trim();
                TxtVal_PlantExpanstion.Text = dscheck.Tables[0].Rows[0]["Val_PlantExpansion"].ToString().Trim();

                txtlbltotalprojectcostexpanstion.Text = dscheck.Tables[0].Rows[0]["Tot_PrjCostExpansion"].ToString().Trim();
                //end

                txtNameOfIndustrialUndertaking.Text = dscheck.Tables[0].Rows[0]["nameofunit"].ToString().Trim();

                HdfLblEnt_is.Value = dscheck.Tables[0].Rows[0]["Ent_is"].ToString().Trim();
                CalculatationEnterprisePrjCost();
                CalculatationEnterprise();


                CalculatationEnterprisePrjCostExpansion();
                if (ddlproposal.SelectedValue == "2")
                {
                    CalculatationEnterprisevalueLandExpansion();
                    CalculatationEnterprisevalueBildExpansion();
                    CalculatationEnterprisevaluePlantExpansion();
                    CalculatationEnterprisefinalTotalvalue();
                }
                ddlintLineofActivity.SelectedValue = ddlintLineofActivity.Items.FindByValue(dscheck.Tables[0].Rows[0]["intLineofActivityid"].ToString().Trim()).Value;

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

                if (dscheck.Tables[0].Rows[0]["HaveyourTakePolution"].ToString().Trim() != "")
                {
                    rdpPOLRDP.SelectedValue = rdpPOLRDP.Items.FindByValue(dscheck.Tables[0].Rows[0]["HaveyourTakePolution"].ToString().Trim()).Value;
                }

                if (dscheck.Tables[0].Rows[0]["License_Factory"].ToString().Trim() != "")
                {
                    RdpFactory.SelectedValue = RdpFactory.Items.FindByValue(dscheck.Tables[0].Rows[0]["License_Factory"].ToString().Trim()).Value;
                }


                if (dscheck.Tables[0].Rows[0]["High_Tension_Meter"].ToString().Trim() != "")
                {
                    RdpIndustry.SelectedValue = RdpIndustry.Items.FindByValue(dscheck.Tables[0].Rows[0]["High_Tension_Meter"].ToString().Trim()).Value;
                }



                //if (RdpBuildingHeight.SelectedValue.ToString().Trim() == "Y")
                //{
                //    trNOC.Visible = true;

                //}
                //else
                //{
                //    trNOC.Visible = false;
                //}
                //hdnfocus.Value = RdpBuildingHeight.ClientID;

                if (dscheck.Tables[0].Rows[0]["Building_Height"].ToString().Trim() != "")
                {
                    RdpBuildingHeight.SelectedValue = RdpBuildingHeight.Items.FindByValue(dscheck.Tables[0].Rows[0]["Building_Height"].ToString().Trim()).Value;
                }

                if (RdpBuildingHeight.SelectedValue.ToString().Trim() == "Y")
                {
                    trNOC.Visible = true;

                }
                else
                {
                    trNOC.Visible = false;
                }


                if (dscheck.Tables[0].Rows[0]["NOC_Fire"].ToString().Trim() != "")
                {
                    RdpNOC.SelectedValue = RdpNOC.Items.FindByValue(dscheck.Tables[0].Rows[0]["NOC_Fire"].ToString().Trim()).Value;
                }

                if (dscheck.Tables[0].Rows[0]["Product_Drugs"].ToString().Trim() != "")
                {
                    RdpDrugs.SelectedValue = RdpDrugs.Items.FindByValue(dscheck.Tables[0].Rows[0]["Product_Drugs"].ToString().Trim()).Value;
                }

                if (dscheck.Tables[0].Rows[0]["Bioler_Industry"].ToString().Trim() != "")
                {
                    RdpBoiler.SelectedValue = RdpBoiler.Items.FindByValue(dscheck.Tables[0].Rows[0]["Bioler_Industry"].ToString().Trim()).Value;
                }
                if (dscheck.Tables[0].Rows[0]["SteamPipeline"].ToString().Trim() != "")
                {
                    rbtnLstBoilerSteamPipeline.SelectedValue = RdpBoiler.Items.FindByValue(dscheck.Tables[0].Rows[0]["SteamPipeline"].ToString().Trim()).Value;
                }

                if (dscheck.Tables[0].Rows[0]["fisiability"].ToString().Trim() != "")
                {
                    RdpDrugs0.SelectedValue = RdpDrugs0.Items.FindByValue(dscheck.Tables[0].Rows[0]["fisiability"].ToString().Trim()).Value;
                }
                else
                {
                    RdpDrugs0.SelectedValue = RdpDrugs0.Items.FindByValue("N").Value;
                }

                if (RdpDrugs0.SelectedValue.ToString().Trim() == "Y")
                {
                    servicelat.Visible = true;

                }
                else
                {
                    servicelat.Visible = false;
                }

                if (dscheck.Tables[0].Rows[0]["service"].ToString().Trim() != "")
                {
                    RdpService.SelectedValue = RdpService.Items.FindByValue(dscheck.Tables[0].Rows[0]["service"].ToString().Trim()).Value;
                }
                else
                {
                    RdpService.SelectedValue = RdpService.Items.FindByValue("N").Value;
                }

                if (dscheck.Tables[1].Rows.Count > 0)
                {
                    grdDetails.DataSource = dscheck.Tables[1];
                    grdDetails.DataBind();
                    dvfeedetails.Visible = true;
                }

                Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();

                if (ddlProp_intDistrictid.SelectedValue == "1" || ddlProp_intDistrictid.SelectedValue == "2" || ddlProp_intDistrictid.SelectedValue == "3" || ddlProp_intDistrictid.SelectedValue == "9" || ddlProp_intDistrictid.SelectedValue == "10")
                {
                    Label399.Text = "Do you have feasibility report of TSNPDCL";
                }
                else
                {
                    Label399.Text = "Do you have feasibility report of TSSPDCL";
                }
                string LabourAct_Id = dscheck.Tables[0].Rows[0]["LabourAct_Id"].ToString().Trim();
                if (LabourAct_Id != null && LabourAct_Id != "")
                {
                    string[] values = LabourAct_Id.Split(',');
                    for (int i = 0; i < values.Length; i++)
                    {
                        if (values[i] == "3")
                        {
                            RdbExecpted0.SelectedValue = "Y";
                            RdbExecpted0_SelectedIndexChanged(this, EventArgs.Empty);
                        }
                        if (values[i] == "4")
                        {
                            RdbExecpted1.SelectedValue = "Y";
                            RdbExecpted1_SelectedIndexChanged(this, EventArgs.Empty);
                        }
                        if (values[i] == "1")
                        {
                            RdbExecptedact1.SelectedValue = "Y";
                            RdbExecptedact1_SelectedIndexChanged(this, EventArgs.Empty);
                        }
                    }
                }

                if (dscheck.Tables[0].Rows[0]["BuildingWorker"].ToString() != "")
                    txtNoofworkers.Text = dscheck.Tables[0].Rows[0]["BuildingWorker"].ToString().Trim();

                if (dscheck.Tables[0].Rows[0]["ContractWorker"].ToString() != "")
                    txtContractLabourAct.Text = dscheck.Tables[0].Rows[0]["ContractWorker"].ToString().Trim();

                if (dscheck.Tables[0].Rows[0]["MigrantWorker"].ToString() != "")
                    txtMigrantWorkmanAct.Text = dscheck.Tables[0].Rows[0]["MigrantWorker"].ToString().Trim();

                if (dscheck.Tables[0].Rows[0]["txtDateofCommenceAct1"].ToString() != "")
                {
                    //string[] newdate = dscheck.Tables[0].Rows[0]["txtDateofCommenceAct1"].ToString().Split(' ');
                    //string date = newdate[1].ToString() + "/" + newdate[0].ToString() + "/" + newdate[2].ToString();
                    txtDateofCommenceAct1.Text = Convert.ToDateTime(dscheck.Tables[0].Rows[0]["txtDateofCommenceAct1"].ToString()).ToString("dd-MM-yyyy");
                    //txtDateofCommenceAct1.Text = Convert.ToDateTime(newdate[0].ToString()).ToString("dd-mm-yyyy");
                }
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }


    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (BtnSave1.Text == "Save")
            {
                success.Visible = false;
                Failure.Visible = false;
                lblmsg.Text = "";
                lblmsg0.Text = "";


                //DataSet ds = new DataSet();
                //ds = Gen.GetCFOQuesdetbulogin(Session["uid"].ToString());

                //if (ds.Tables[0].Rows.Count > 0)
                //{

                //    lblmsg.Text = "QuessionneireCFO  Registered Already";

                //    success.Visible = true;
                //    Failure.Visible = false;

                //    return;

                //}
                if (ddlproposal.SelectedValue != "2")
                {
                    if (txtPlantvalueActual.Text.TrimStart().TrimEnd() == "0.00")
                    {
                        success.Visible = false;
                        Failure.Visible = true;
                        lblmsg0.Text = "Plant and Machniery value should not be Zero";
                        lblmsg0.Focus();
                        return;
                    }
                }
                if (rdpPOLRDP.SelectedValue == "N" && RdpFactory.SelectedValue == "N" && RdpIndustry.SelectedValue == "N" && RdpBuildingHeight.SelectedValue == "N" && RdpDrugs.SelectedValue == "N" && RdpBoiler.SelectedValue == "N")
                {
                    success.Visible = false;
                    Failure.Visible = true;
                    lblmsg0.Text = "Please Select Atleast One Department";
                    return;

                }
                //string errormsg = Gen.CHECKVALIDCFECFO(txtcfeuidno.Text, "CFE");
                //if (errormsg != null && errormsg != "")
                //{
                //    success.Visible = false;
                //    Failure.Visible = true;
                //    lblmsg0.Text = errormsg;
                //    return;
                //}

                string errormsg = Gen.CHECKVALIDCFECFO(txtcfeuidno.Text, "CFE");
                if (errormsg != null && errormsg != "" && errormsg != "VALID UID NUMBER")
                {
                    success.Visible = false;
                    Failure.Visible = true;
                    lblmsg0.Text = errormsg;

                }

                if (errormsg != null && errormsg != "" && errormsg != "PLEASE ENTER VALID UID NUMBER")
                {
                    //string message = "alert(" + errormsg + ")";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "alert('" + errormsg + "');", true);
                    ////txtcfeuidno.Text = "";
                    //txtcfouidno.Enabled = false;

                }
                if (ddlintLineofActivity.SelectedValue == "1032" || ddlintLineofActivity.SelectedValue == "1139" || ddlintLineofActivity.SelectedValue == "1314" || ddlintLineofActivity.SelectedValue == "1000" || ddlintLineofActivity.SelectedValue == "1124" || ddlintLineofActivity.SelectedValue == "1303" || ddlintLineofActivity.SelectedValue == "1150" || ddlintLineofActivity.SelectedValue == "1178" || ddlintLineofActivity.SelectedValue == "1207" || ddlintLineofActivity.SelectedValue == "1295" || ddlintLineofActivity.SelectedValue == "1078" || ddlintLineofActivity.SelectedValue == "1209" || ddlintLineofActivity.SelectedValue == "1315")
                {

                    //ddlintLineofActivity.SelectedValue == "1195" commented on 01.12.2017
                    decimal strTot_PrjCost = 0;   // laks
                    decimal strTot_PrjCostCrors = 0;   // laks
                    if (ddlproposal.SelectedValue == "1")
                    {
                        strTot_PrjCost = Convert.ToDecimal(txttotal.Text);
                    }
                    else if (ddlproposal.SelectedValue == "2")
                    {
                        strTot_PrjCost = Convert.ToDecimal(lblfinaltotalvalue.Text);
                    }
                    strTot_PrjCostCrors = strTot_PrjCost / 100;
                    if (strTot_PrjCostCrors < 50)
                    {
                        string message = "alert('Application For Commercial Activity With Project Cost(Land + Building + Plant & Machinery) More Than Rs.50 crores Only Acceeptable Under TS-IPASS')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }
                }
                //Expansion
                //shankar
                QuesionerVO quesionervoobj = new QuesionerVO();

                string TourismFlag = "Y"; //lavanya 20.10.2020
                //if (ViewState["TOURISMFLAG"] != null)
                //    TourismFlag = ViewState["TOURISMFLAG"].ToString();
                if (TourismFlag == "Y")
                {
                    quesionervoobj.TourismFlag = "Y";
                    quesionervoobj.PoliceNOCFlag = rdPoliceNOC.SelectedValue;
                    quesionervoobj.ParkingConditionFlag = rdParkingCondition.SelectedValue;
                    quesionervoobj.StorageConstruction_Flag = rdStorageConstruction.SelectedValue;
                    quesionervoobj.HotelType = ddlHotelType.SelectedValue;
                    quesionervoobj.ParkingCondition = txtParkingConditionYesRemarks.Text.Trim();
                    quesionervoobj.StorageConstruction = txtStorageConstructionYesRemarks.Text.Trim();
                    //quesionervoobj.Classification_Rating = ddlClassification.SelectedValue;
                    quesionervoobj.Bar_License = rdBarLicense.SelectedValue;
                    quesionervoobj.Trade_License = rbtnTradeLicense.SelectedValue;
                    quesionervoobj.HealthSDG_License = rbtnHealthandSanitary.SelectedValue;
                    quesionervoobj.FSSAI_Certificate = rbtnFSSAI.SelectedValue;
                    quesionervoobj.Built_up_Area = TxtBuilt_up_Area.Text.Trim();

                }
                quesionervoobj.Val_LandExpansion = TxtVal_LandExpansion.Text.Trim();
                quesionervoobj.Val_BuildExpansion = TxtVal_BuildExpanstion.Text.Trim();
                quesionervoobj.Val_PlantExpansion = TxtVal_PlantExpanstion.Text.Trim();
                quesionervoobj.Val_Land_ActulExpansion = TxtVal_Land_ActualExpansion.Text.Trim();
                quesionervoobj.Val_Build_ActulExpansion = TxtVal_Build_ActualExpn.Text.Trim();
                quesionervoobj.Val_Plant_ActulExpansion = TxtVal_Plant_ActualExpansion.Text.Trim();
                quesionervoobj.Tot_PrjCostExpansion = txtlbltotalprojectcostexpanstion.Text;
                quesionervoobj.ProposalFor = ddlproposal.SelectedItem.Text;
                quesionervoobj.TotalNoofWorkes = txtNoofworkers.Text;
                quesionervoobj.TotalNoofWorkesforContractLbr = txtContractLabourAct.Text;
                quesionervoobj.TotalNoofWorkesformigrantact = txtMigrantWorkmanAct.Text;
                string[] newdate = txtDateofCommenceAct1.Text.ToString().Split('-');
                string date = newdate[1].ToString() + "/" + newdate[0].ToString() + "/" + newdate[2].ToString();
                quesionervoobj.txtDateofCommenceAct1 = date;
                //end shankar
                quesionervoobj.LabourActID = "";
                if (RdbExecptedact1.SelectedValue == "Y")
                {
                    if (quesionervoobj.LabourActID == "")
                        quesionervoobj.LabourActID = "1";
                    else
                        quesionervoobj.LabourActID += "," + "1";
                }
                if (RdbExecpted0.SelectedValue == "Y")
                {
                    if (quesionervoobj.LabourActID == "")
                        quesionervoobj.LabourActID = "3";
                    else
                        quesionervoobj.LabourActID += "," + "3";
                }

                if (RdbExecpted1.SelectedValue == "Y")
                {
                    if (quesionervoobj.LabourActID == "")
                        quesionervoobj.LabourActID = "4";
                    else
                        quesionervoobj.LabourActID += "," + "4";
                }
                quesionervoobj.LabelConfirmation = rbtnLstLabel.SelectedValue;
                quesionervoobj.SteamPipeline = rbtnLstBoilerSteamPipeline.SelectedValue;
                int i = insertCFOQuestionerrie(Session["Applid"].ToString(), ddlSector.SelectedValue.ToString(), ddlProp_intDistrictid.SelectedValue.ToString(),
                    ddlProp_intMandalid.SelectedValue.ToString(), ddlProp_intVillageid.SelectedValue.ToString(), txtlandvalue.Text, txtbuildingvalue.Text, txtPlantvalue.Text,
                    txttotal.Text, rdpPOLRDP.SelectedValue.ToString(), ddlintLineofActivity.SelectedValue.ToString(), HdfLblPol_Category.Value, RdpFactory.SelectedValue.ToString(),
                    RdpIndustry.SelectedValue.ToString(), RdpBuildingHeight.SelectedValue.ToString(), RdpNOC.SelectedValue.ToString(), RdpDrugs.SelectedValue.ToString(),
                    RdpBoiler.SelectedValue.ToString(), Session["uid"].ToString(), txtNameOfIndustrialUndertaking.Text, HdfLblEnt_is.Value, "2", RdpDrugs0.SelectedValue.ToString(), RdpService.SelectedValue.ToString()
                    , txtlandvalueActul.Text.Trim(), txtbuildingvalueActual.Text.Trim(), txtPlantvalueActual.Text.Trim(), ddlcurrencytype.SelectedItem.Text, quesionervoobj, txtcfeuidno.Text);

                Session["Applid"] = i.ToString();
                if (i != 999)
                {
                    for (int iii = 0; iii < grdDetails.Rows.Count; iii++)
                    {

                        HiddenField HdfApprovalid = (HiddenField)grdDetails.Rows[iii].Cells[0].FindControl("HdfApprovalid");
                        HiddenField HdfQueid = (HiddenField)grdDetails.Rows[iii].Cells[0].FindControl("HdfQueid");

                        HiddenField HDFAmountdd = (HiddenField)grdDetails.Rows[iii].Cells[3].FindControl("HDFAmountdd");
                        int a = Gen.insertQuetieneroesDeptCFO(i.ToString(), HdfQueid.Value, HdfApprovalid.Value, "1000", (grdDetails.Rows[iii].FindControl("lblAmountnew") as Label).Text);//grdDetails.Rows[iii].Cells[3].Text)
                    }


                    Response.Redirect("TS-iPASSCFO.aspx?intApplicationID=" + i.ToString());
                    lblmsg.Text = "Submitted Successfully";

                    success.Visible = true;
                    Failure.Visible = false;

                }
                else
                {

                    lblmsg0.Text = "failed..";
                    Failure.Visible = true;
                    success.Visible = false;
                }


            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }

    }
    void clear()
    {




    }

    public int insertCFOQuestionerrie(string intQuessionaireCFOid, string Sector_Ent, string Prop_intDistrictid, string Prop_intMandalid, string Prop_intVillageid, string Val_Land, string Val_Build, string Val_Plant, string Tot_PrjCost,
                  string HaveyourTakePolution, string intLineofActivityid, string Pol_Category, string License_Factory, string High_Tension_Meter, string Building_Height, string NOC_Fire, string Product_Drugs, string Bioler_Industry, string Created_by, string nameofunit, string enterprisetype, string Appl_Status, string fisiability, string service,
      string Val_Land_Actul, string Val_Build_Actul, string Val_Plant_Actul, string CurrencyType, QuesionerVO quesionervoobj, string CFEUIDNo)
       // , string CinematographicLicense, string LicensePeriod,
       //string Noofscreens, string TotalFee, List<Screendetails> lstscreendetails)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "insertCFOQuessionary";

        if (CFEUIDNo == "")
        {
            com.Parameters.Add("@CFEUIDNo", SqlDbType.VarChar).Value = DBNull.Value;
        }
        else
        {
            com.Parameters.Add("@CFEUIDNo", SqlDbType.VarChar).Value = CFEUIDNo;
        }

        if (intQuessionaireCFOid == "" || intQuessionaireCFOid == null || intQuessionaireCFOid.Trim() == "--Select--")
            com.Parameters.Add("@intQuessionaireCFOid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intQuessionaireCFOid", SqlDbType.VarChar).Value = intQuessionaireCFOid.Trim();


        if (enterprisetype == "" || enterprisetype == null || enterprisetype.Trim() == "--Select--")
            com.Parameters.Add("@Ent_is", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Ent_is", SqlDbType.VarChar).Value = enterprisetype.Trim();

        if (Appl_Status == "" || Appl_Status == null || Appl_Status.Trim() == "--Select--")
            com.Parameters.Add("@Appl_Status", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Appl_Status", SqlDbType.VarChar).Value = Appl_Status.Trim();


        if (fisiability == "" || fisiability == null || fisiability.Trim() == "--Select--")
            com.Parameters.Add("@fisiability", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@fisiability", SqlDbType.VarChar).Value = fisiability.Trim();

        if (service == "" || service == null || service.Trim() == "--Select--")
            com.Parameters.Add("@service", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@service", SqlDbType.VarChar).Value = service.Trim();




        if (nameofunit == "" || nameofunit == null || nameofunit.Trim() == "--Select--")
            com.Parameters.Add("@nameofunit", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@nameofunit", SqlDbType.VarChar).Value = nameofunit.Trim();

        if (Sector_Ent == "" || Sector_Ent == null || Sector_Ent.Trim() == "--Select--")
            com.Parameters.Add("@Sector_Ent", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Sector_Ent", SqlDbType.VarChar).Value = Sector_Ent.Trim();

        if (Prop_intDistrictid == "" || Prop_intDistrictid == null || Prop_intDistrictid.Trim() == "--Select--")
            com.Parameters.Add("@Prop_intDistrictid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Prop_intDistrictid", SqlDbType.VarChar).Value = Prop_intDistrictid.Trim();

        if (Prop_intMandalid == "" || Prop_intMandalid == null || Prop_intMandalid.Trim() == "--Select--")
            com.Parameters.Add("@Prop_intMandalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Prop_intMandalid", SqlDbType.VarChar).Value = Prop_intMandalid.Trim();

        if (Prop_intVillageid == "" || Prop_intVillageid == null || Prop_intVillageid.Trim() == "--Select--")
            com.Parameters.Add("@Prop_intVillageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Prop_intVillageid", SqlDbType.VarChar).Value = Prop_intVillageid.Trim();

        //if (PolCategory == "" || PolCategory == null || PolCategory.Trim()=="--Select--")
        //    com.Parameters.Add("@PolCategory", SqlDbType.VarChar).Value = DBNull.Value;
        //else
        //    com.Parameters.Add("@PolCategory", SqlDbType.VarChar).Value = PolCategory.Trim();

        if (Val_Land == "" || Val_Land == null || Val_Land.Trim() == "--Select--")
            com.Parameters.Add("@Val_Land", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Val_Land", SqlDbType.VarChar).Value = Val_Land.Trim();

        if (Val_Build == "" || Val_Build == null || Val_Build.Trim() == "--Select--")
            com.Parameters.Add("@Val_Build", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Val_Build", SqlDbType.VarChar).Value = Val_Build.Trim();

        if (Val_Plant == "" || Val_Plant == null || Val_Plant.Trim() == "--Select--")
            com.Parameters.Add("@Val_Plant", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Val_Plant", SqlDbType.VarChar).Value = Val_Plant.Trim();


        if (Tot_PrjCost == "" || Tot_PrjCost == null || Tot_PrjCost.Trim() == "--Select--")
            com.Parameters.Add("@Tot_PrjCost", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Tot_PrjCost", SqlDbType.VarChar).Value = Tot_PrjCost.Trim();


        if (HaveyourTakePolution == "" || HaveyourTakePolution == null || HaveyourTakePolution.Trim() == "--Select--")
            com.Parameters.Add("@HaveyourTakePolution", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@HaveyourTakePolution", SqlDbType.VarChar).Value = HaveyourTakePolution.Trim();
        //string intLineofActivityid, string Pol_Category, string License_Factory, string High_Tension_Meter, string NOC_Fire, string Product_Drugs, string Bioler_Industry
        if (intLineofActivityid == "" || intLineofActivityid == null || intLineofActivityid.Trim() == "--Select--")
            com.Parameters.Add("@intLineofActivityid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intLineofActivityid", SqlDbType.VarChar).Value = intLineofActivityid.Trim();

        if (Pol_Category == "" || Pol_Category == null || Pol_Category.Trim() == "--Select--")
            com.Parameters.Add("@Pol_Category", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Pol_Category", SqlDbType.VarChar).Value = Pol_Category.Trim();

        if (License_Factory == "" || License_Factory == null || License_Factory.Trim() == "--Select--")
            com.Parameters.Add("@License_Factory", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@License_Factory", SqlDbType.VarChar).Value = License_Factory.Trim();

        if (High_Tension_Meter == "" || High_Tension_Meter == null || High_Tension_Meter.Trim() == "--Select--")
            com.Parameters.Add("@High_Tension_Meter", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@High_Tension_Meter", SqlDbType.VarChar).Value = High_Tension_Meter.Trim();

        if (Building_Height == "" || Building_Height == null || Building_Height.Trim() == "--Select--")
            com.Parameters.Add("@Building_Height", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Building_Height", SqlDbType.VarChar).Value = NOC_Fire.Trim();

        if (NOC_Fire == "" || NOC_Fire == null || NOC_Fire.Trim() == "--Select--")
            com.Parameters.Add("@NOC_Fire", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@NOC_Fire", SqlDbType.VarChar).Value = NOC_Fire.Trim();

        if (Product_Drugs == "" || Product_Drugs == null || NOC_Fire.Trim() == "--Select--")
            com.Parameters.Add("@Product_Drugs", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Product_Drugs", SqlDbType.VarChar).Value = Product_Drugs.Trim();

        if (Bioler_Industry == "" || Bioler_Industry == null || Bioler_Industry.Trim() == "--Select--")
            com.Parameters.Add("@Bioler_Industry", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Bioler_Industry", SqlDbType.VarChar).Value = Bioler_Industry.Trim();


        if (Created_by == "" || Created_by == null || Created_by.Trim() == "--Select--")
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (Val_Land_Actul == "" || Val_Land_Actul == null || Val_Land_Actul == "--Select--")
            com.Parameters.Add("@Val_Land_Actul", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Val_Land_Actul", SqlDbType.VarChar).Value = Val_Land_Actul.Trim();

        if (Val_Build_Actul == "" || Val_Build_Actul == null || Val_Build_Actul == "--Select--")
            com.Parameters.Add("@Val_Build_Actul", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Val_Build_Actul", SqlDbType.VarChar).Value = Val_Build_Actul.Trim();

        if (Val_Plant_Actul == "" || Val_Plant_Actul == null || Val_Plant_Actul == "--Select--")
            com.Parameters.Add("@Val_Plant_Actul", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Val_Plant_Actul", SqlDbType.VarChar).Value = Val_Plant_Actul.Trim();

        com.Parameters.Add("@CurrencyType", SqlDbType.VarChar).Value = CurrencyType.Trim();

        if (quesionervoobj.LabourActID == "" || quesionervoobj.LabourActID == null || quesionervoobj.LabourActID == "0")
            com.Parameters.Add("@LabourAct_Id", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@LabourAct_Id", SqlDbType.VarChar).Value = quesionervoobj.LabourActID.Trim();

        // expansion
        if (quesionervoobj.Val_LandExpansion == "" || quesionervoobj.Val_LandExpansion == null || quesionervoobj.Val_LandExpansion == "0")
            com.Parameters.Add("@Val_LandExpansion", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Val_LandExpansion", SqlDbType.VarChar).Value = quesionervoobj.Val_LandExpansion;

        if (quesionervoobj.Val_BuildExpansion == "" || quesionervoobj.Val_BuildExpansion == null || quesionervoobj.Val_BuildExpansion == "0")
            com.Parameters.Add("@Val_BuildExpansion", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Val_BuildExpansion", SqlDbType.VarChar).Value = quesionervoobj.Val_BuildExpansion;

        if (quesionervoobj.Val_PlantExpansion == "" || quesionervoobj.Val_PlantExpansion == null || quesionervoobj.Val_PlantExpansion == "0")
            com.Parameters.Add("@Val_PlantExpansion", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Val_PlantExpansion", SqlDbType.VarChar).Value = quesionervoobj.Val_PlantExpansion;

        if (quesionervoobj.Val_Land_ActulExpansion == "" || quesionervoobj.Val_Land_ActulExpansion == null || quesionervoobj.Val_Land_ActulExpansion == "0")
            com.Parameters.Add("@Val_Land_ActulExpansion", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Val_Land_ActulExpansion", SqlDbType.VarChar).Value = quesionervoobj.Val_Land_ActulExpansion;

        if (quesionervoobj.Val_Build_ActulExpansion == "" || quesionervoobj.Val_Build_ActulExpansion == null || quesionervoobj.Val_Build_ActulExpansion == "0")
            com.Parameters.Add("@Val_Build_ActulExpansion", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Val_Build_ActulExpansion", SqlDbType.VarChar).Value = quesionervoobj.Val_Build_ActulExpansion;

        if (quesionervoobj.Val_Plant_ActulExpansion == "" || quesionervoobj.Val_Plant_ActulExpansion == null || quesionervoobj.Val_Plant_ActulExpansion == "0")
            com.Parameters.Add("@Val_Plant_ActulExpansion", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Val_Plant_ActulExpansion", SqlDbType.VarChar).Value = quesionervoobj.Val_Plant_ActulExpansion;

        if (quesionervoobj.Tot_PrjCostExpansion == "" || quesionervoobj.Tot_PrjCostExpansion == null || quesionervoobj.Tot_PrjCostExpansion == "0")
            com.Parameters.Add("@Tot_PrjCostExpansion", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Tot_PrjCostExpansion", SqlDbType.VarChar).Value = quesionervoobj.Tot_PrjCostExpansion;

        if (quesionervoobj.ProposalFor == "" || quesionervoobj.ProposalFor == null || quesionervoobj.ProposalFor == "0")
            com.Parameters.Add("@ProposalFor", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ProposalFor", SqlDbType.VarChar).Value = quesionervoobj.ProposalFor;

        if (quesionervoobj.LabelConfirmation != null && quesionervoobj.LabelConfirmation != "")
            com.Parameters.Add("@LabelConfirmation", SqlDbType.VarChar).Value = quesionervoobj.LabelConfirmation.Trim();

        if (quesionervoobj.TotalNoofWorkes != null && quesionervoobj.TotalNoofWorkes != "")
            com.Parameters.Add("@TotalNoofWorkes", SqlDbType.VarChar).Value = quesionervoobj.TotalNoofWorkes.Trim();

        if (quesionervoobj.TotalNoofWorkesforContractLbr != null && quesionervoobj.TotalNoofWorkesforContractLbr != "")
            com.Parameters.Add("@TotalNoofWorkesforContractLbr", SqlDbType.VarChar).Value = quesionervoobj.TotalNoofWorkesforContractLbr.Trim();

        if (quesionervoobj.TotalNoofWorkesformigrantact != null && quesionervoobj.TotalNoofWorkesformigrantact != "")
            com.Parameters.Add("@TotalNoofWorkesformigrantact", SqlDbType.VarChar).Value = quesionervoobj.TotalNoofWorkesformigrantact.Trim();

        if (quesionervoobj.txtDateofCommenceAct1 == null || quesionervoobj.txtDateofCommenceAct1 == "" || quesionervoobj.txtDateofCommenceAct1 == "0")
            com.Parameters.Add("@txtDateofCommenceAct1", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@txtDateofCommenceAct1", SqlDbType.VarChar).Value = quesionervoobj.txtDateofCommenceAct1.Trim();

        if (quesionervoobj.SteamPipeline != null && quesionervoobj.SteamPipeline != "")
            com.Parameters.Add("@SteamPipeline", SqlDbType.VarChar).Value = quesionervoobj.SteamPipeline.Trim();

        if (quesionervoobj.Occupancyflag != null && quesionervoobj.Occupancyflag != "")
            com.Parameters.Add("@Occupancyflag", SqlDbType.VarChar).Value = quesionervoobj.Occupancyflag.Trim();

        if (quesionervoobj.BPFilenumber != null && quesionervoobj.BPFilenumber != "")
            com.Parameters.Add("@BPFilenumber", SqlDbType.VarChar).Value = quesionervoobj.BPFilenumber.Trim();

        if (quesionervoobj.ArchitectLicNumber != null && quesionervoobj.ArchitectLicNumber != "")
            com.Parameters.Add("@ArchitectLicNumber", SqlDbType.VarChar).Value = quesionervoobj.ArchitectLicNumber.Trim();
        com.Parameters.Add("@TourismFlag", SqlDbType.VarChar).Value = quesionervoobj.TourismFlag.Trim();
        if (quesionervoobj.PoliceNOCFlag == "" || quesionervoobj.PoliceNOCFlag == null)
            com.Parameters.Add("@PoliceNOCFlag", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@PoliceNOCFlag", SqlDbType.VarChar).Value = quesionervoobj.PoliceNOCFlag.Trim();


        if (quesionervoobj.ParkingConditionFlag == "" || quesionervoobj.ParkingConditionFlag == null)
            com.Parameters.Add("@ParkingCondition_Flag", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ParkingCondition_Flag", SqlDbType.VarChar).Value = quesionervoobj.ParkingConditionFlag.Trim();

        if (quesionervoobj.StorageConstruction_Flag == "" || quesionervoobj.StorageConstruction_Flag == null)
            com.Parameters.Add("@StorageConstruction_Flag", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@StorageConstruction_Flag", SqlDbType.VarChar).Value = quesionervoobj.StorageConstruction_Flag.Trim();

        if (quesionervoobj.Classification_Rating == "" || quesionervoobj.Classification_Rating == null)
            com.Parameters.Add("@Classification_Rating", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Classification_Rating", SqlDbType.VarChar).Value = quesionervoobj.Classification_Rating.Trim();

        if (quesionervoobj.Bar_License == "" || quesionervoobj.Bar_License == null)
            com.Parameters.Add("@Bar_License", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Bar_License", SqlDbType.VarChar).Value = quesionervoobj.Bar_License.Trim();

        if (quesionervoobj.Trade_License == "" || quesionervoobj.Trade_License == null)
            com.Parameters.Add("@Trade_License", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Trade_License", SqlDbType.VarChar).Value = quesionervoobj.Trade_License.Trim();

        if (quesionervoobj.HealthSDG_License == "" || quesionervoobj.HealthSDG_License == null)
            com.Parameters.Add("@HealthSDG_License", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@HealthSDG_License", SqlDbType.VarChar).Value = quesionervoobj.HealthSDG_License.Trim();

        if (quesionervoobj.FSSAI_Certificate == "" || quesionervoobj.FSSAI_Certificate == null)
            com.Parameters.Add("@FSSAI_Certificate", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@FSSAI_Certificate", SqlDbType.VarChar).Value = quesionervoobj.FSSAI_Certificate.Trim();

        if (quesionervoobj.Built_up_Area == "" || quesionervoobj.Built_up_Area == null)
            com.Parameters.Add("@Built_up_Area", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Built_up_Area", SqlDbType.VarChar).Value = quesionervoobj.Built_up_Area.Trim();

        if (quesionervoobj.HotelType == "" || quesionervoobj.HotelType == null)
            com.Parameters.Add("@Hotel_Type", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Hotel_Type", SqlDbType.VarChar).Value = quesionervoobj.HotelType.Trim();

        if (quesionervoobj.BoilerManufactuer == "" || quesionervoobj.BoilerManufactuer == null)
            com.Parameters.Add("@BiolerManufactuer_Industry", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@BiolerManufactuer_Industry", SqlDbType.VarChar).Value = quesionervoobj.BoilerManufactuer.Trim();


        if (quesionervoobj.NoofworkersContractor != null && quesionervoobj.NoofworkersContractor != "")
            com.Parameters.Add("@NoofworkersContractor", SqlDbType.VarChar).Value = quesionervoobj.NoofworkersContractor.Trim();

        if (quesionervoobj.CommencemantdateContractor == null || quesionervoobj.CommencemantdateContractor == "" || quesionervoobj.CommencemantdateContractor == "0")
            com.Parameters.Add("@CommencemantdateContractor", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@CommencemantdateContractor", SqlDbType.VarChar).Value = quesionervoobj.CommencemantdateContractor.Trim();

        if (quesionervoobj.HotelClassification == null || quesionervoobj.HotelClassification == "" || quesionervoobj.HotelClassification == "0")
            com.Parameters.Add("@HOTELCLASSIFICATION", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@HOTELCLASSIFICATION", SqlDbType.VarChar).Value = quesionervoobj.HotelClassification.Trim();

        //if (CinematographicLicense == null || CinematographicLicense == "" || CinematographicLicense == "0")
        //    com.Parameters.Add("@CinematographicLicense", SqlDbType.VarChar).Value = DBNull.Value;
        //else
        //    com.Parameters.Add("@CinematographicLicense", SqlDbType.VarChar).Value = CinematographicLicense.Trim();

        //if (LicensePeriod == null || LicensePeriod == "" || LicensePeriod == "0")
        //    com.Parameters.Add("@LicensePeriod", SqlDbType.VarChar).Value = DBNull.Value;
        //else
        //    com.Parameters.Add("@LicensePeriod", SqlDbType.VarChar).Value = LicensePeriod.Trim();

        //if (Noofscreens == null || Noofscreens == "" || Noofscreens == "0")
        //    com.Parameters.Add("@Noofscreens", SqlDbType.VarChar).Value = DBNull.Value;
        //else
        //    com.Parameters.Add("@Noofscreens", SqlDbType.VarChar).Value = Noofscreens.Trim();

        //if (TotalFee == null || TotalFee == "" || TotalFee == "0")
        //    com.Parameters.Add("@TotalFee", SqlDbType.VarChar).Value = DBNull.Value;
        //else
        //    com.Parameters.Add("@TotalFee", SqlDbType.VarChar).Value = TotalFee.Trim();

        if (quesionervoobj.FDC != null && quesionervoobj.FDC != "")
            com.Parameters.Add("@FDC", SqlDbType.VarChar).Value = quesionervoobj.FDC.Trim();

        if (quesionervoobj.ExciseLabel != null && quesionervoobj.ExciseLabel != "")
            com.Parameters.Add("@ExciseLabel", SqlDbType.VarChar).Value = quesionervoobj.ExciseLabel.Trim();

        if (quesionervoobj.ExciseBrand != null && quesionervoobj.ExciseBrand != "")
            com.Parameters.Add("@ExciseBrand", SqlDbType.VarChar).Value = quesionervoobj.ExciseBrand.Trim();

        if (quesionervoobj.ExciseImport != null && quesionervoobj.ExciseImport != "")
            com.Parameters.Add("@ExciseImport", SqlDbType.VarChar).Value = quesionervoobj.ExciseImport.Trim();

        if (quesionervoobj.ExciseExport != null && quesionervoobj.ExciseExport != "")
            com.Parameters.Add("@ExciseImport", SqlDbType.VarChar).Value = quesionervoobj.ExciseExport.Trim();


        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
        //try
        //{
        //    //return com.ExecuteNonQuery();
        //    // return Convert.ToInt32(com.ExecuteScalar());
        //    int n = Convert.ToInt32(com.ExecuteScalar());


        //    if (n > 0)
        //    {
        //        int valid = 0;
        //        con.OpenConnection();
        //        SqlCommand cmd = null;

        //        foreach (Screendetails fromvo in lstscreendetails)
        //        {
        //            cmd = new SqlCommand("USP_INSERT_ScreenDetails", con.GetConnection);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@intQuessionaireCFOid", Convert.ToString(intQuessionaireCFOid));
        //            //cmd.Parameters.AddWithValue("@intCFEEnterpid", Convert.ToString(intCFOEnterpid));
        //            //cmd.Parameters.AddWithValue("@Quessionaireid", Convert.ToString(formvoobj.Quessionaireid));
        //            cmd.Parameters.AddWithValue("@ScreenNO", Convert.ToString(fromvo.ScreenNO));
        //            cmd.Parameters.AddWithValue("@SeatCapacity", Convert.ToString(fromvo.SeatCapacity));
        //            cmd.Parameters.AddWithValue("@ScreenFee", Convert.ToString(fromvo.ScreenFee));
        //            cmd.Parameters.AddWithValue("@TotalFee", Convert.ToString(fromvo.TotalFee));

        //            cmd.Parameters.AddWithValue("@Created_By ", Convert.ToString(fromvo.Created_By));
        //            cmd.Parameters.Add("@Valid", SqlDbType.Int, 500);
        //            cmd.Parameters["@Valid"].Direction = ParameterDirection.Output;
        //            cmd.ExecuteNonQuery();
        //            valid = (Int32)cmd.Parameters["@Valid"].Value;
        //        }


        //    }
        //    //else
        //    //{
        //    //    return 0;
        //    //}
        //    return n;
        //}
        //catch (Exception ex)
        //{

        //    throw ex;
        //    return 0;
        //}
        //finally
        //{
        //    com.Dispose();
        //    con.CloseConnection();
        //}

    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        if (Session["HOTEL"] != null && Session["HOTEL"].ToString() == "Y")
            Response.Redirect("frmQuesstionniareRegCFOHotel.aspx");

        else
            Response.Redirect("frmQuesstionniareRegCFO.aspx");
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    void getcounties()
    {

    }
    protected void ddlCounties_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    void getPayams()
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
            if (BtnSave1.Text == "Save")
            {






            }
            else
            {


            }
        }
        catch (Exception ex)
        {
            //  lblresult.Text = ex.ToString();

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
        try
        {
            if (ddlProp_intDistrictid.SelectedIndex == 0)
            {
                ddlProp_intMandalid.Items.Clear();
                ddlProp_intMandalid.Items.Insert(0, "--Mandal--");
                //   ChkWater_reg_from.Items.Clear();
                // ChkWater_reg_from.Items.Insert(0, new ListItem("New Bore well", "New Bore well"));
                //ChkWater_reg_from.Items.Insert(1, new ListItem("HMWS & SB", "HMWS & SB"));
                //ChkWater_reg_from.Items.Insert(2, new ListItem("Rivers/Canals", "Rivers/Canals"));
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

                if (ddlProp_intDistrictid.SelectedValue == "1" || ddlProp_intDistrictid.SelectedValue == "2" || ddlProp_intDistrictid.SelectedValue == "3" || ddlProp_intDistrictid.SelectedValue == "9" || ddlProp_intDistrictid.SelectedValue == "10")
                {
                    DataSet dscess = Gen.getCESSVillages(ddlProp_intVillageid.SelectedValue);
                    if (dscess.Tables[0].Rows.Count > 0)
                    {
                        Label399.Text = "Do you have feasibility report of TSNPDCL/CESS Sircilla";
                    }
                    else
                    {
                        Label399.Text = "Do you have feasibility report of TSNPDCL";
                    }

                }
                else
                {
                    Label399.Text = "Do you have feasibility report of TSSPDCL";
                }

            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void ddlProp_intMandalid_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
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
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }

    }
    protected void ddlintLineofActivity_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
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
                            trFallinPolution.Visible = true;
                        }
                        else
                        {
                            trFallinPolution.Visible = false;
                        }
                    }
                    else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "R")
                    {
                        HdfLblPol_Category.Value = "Red";
                        LblPol_Category.Text = "<font color=Red>Red</font>";
                        trFallinPolution.Visible = false;
                    }
                    else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "G")
                    {
                        HdfLblPol_Category.Value = "Green";
                        trFallinPolution.Visible = true;

                        LblPol_Category.Text = "<font color=Green>Green</font>";
                    }
                    else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "W")
                    {
                        HdfLblPol_Category.Value = "White";
                        trFallinPolution.Visible = true;

                        LblPol_Category.Text = "<font color=Black>White</font>";
                    }
                }
                else
                {
                    HdfLblPol_Category.Value = "";
                    trFallinPolution.Visible = false;
                    LblPol_Category.Text = "";
                }
            }
            hdnfocus.Value = ddlintLineofActivity.ClientID;
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void RdpBuildingHeight_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (RdpBuildingHeight.SelectedValue.ToString().Trim() == "Y")
            {
                trNOC.Visible = true;

            }
            else
            {
                trNOC.Visible = false;
            }
            hdnfocus.Value = RdpBuildingHeight.ClientID;
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void RdpNOC_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (RdpNOC.SelectedValue.ToString().Trim() == "N")
            {
                lblNOC.Visible = true;
                BtnSave1.Enabled = false;
                lblNOC.Text = "Height of the Building greater than or equal to 15 Metres Fire department NOC is must. Please Contact Industries Department";
            }
            else
            {
                lblNOC.Visible = false;
                BtnSave1.Enabled = true;
            }
            hdnfocus.Value = RdpBuildingHeight.ClientID;
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    public void CalculatationEnterprisePrjCost()
    {
        try
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
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    public void CalculatationEnterprise()
    {
        try
        {
            if (ddlSector.SelectedIndex != 0)
            {

                string TxtTot_PrjCostNewfinal = "0";
                string TxtVal_Plantnewfinal = "0";
                if (lblfinaltotalvalue.Text == "")
                {
                    lblfinaltotalvalue.Text = "0";
                }
                if (lblplantotalexp.Text == "")
                {
                    lblplantotalexp.Text = "0";
                }

                if (ddlproposal.SelectedValue == "2")
                {
                    TxtTot_PrjCostNewfinal = lblfinaltotalvalue.Text;
                    TxtVal_Plantnewfinal = lblplantotalexp.Text;
                }
                else
                {
                    TxtTot_PrjCostNewfinal = txttotal.Text;
                    TxtVal_Plantnewfinal = txtPlantvalue.Text;
                }
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


            if (ddlintLineofActivity.SelectedIndex == 0)
            {
                HdfLblPol_Category.Value = "";
                LblPol_Category.Text = "";
                trFallinPolution.Visible = false;
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
                            trFallinPolution.Visible = true;
                        }
                        else
                        {
                            trFallinPolution.Visible = false;
                        }

                    }
                    else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "R")
                    {
                        HdfLblPol_Category.Value = "Red";
                        LblPol_Category.Text = "<font color=Red>Red</font>";
                        trFallinPolution.Visible = false;
                    }
                    else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "G")
                    {
                        HdfLblPol_Category.Value = "Green";
                        trFallinPolution.Visible = true;
                        LblPol_Category.Text = "<font color=Green>Green</font>";
                    }
                    else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "W")
                    {
                        HdfLblPol_Category.Value = "White";
                        trFallinPolution.Visible = true;
                        LblPol_Category.Text = "<font color=Green>White</font>";
                    }
                }
                else
                {
                    HdfLblPol_Category.Value = "";
                    LblPol_Category.Text = "";
                    trFallinPolution.Visible = false;
                }
            }

            //if (txtPlantvalue.Text == "" || txtPlantvalue.Text == "0")
            //{
            //    HdfLblEnt_is.Value = "";
            //    LblEnt_is.Text = "";
            //}
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }


    protected void txtlandvalue_TextChanged(object sender, EventArgs e)
    {
        try
        {
            CalculatationEnterprisePrjCost();
            CalculatationEnterprise();
            if (ddlSector.SelectedIndex == 0)
            {
                HdfLblEnt_is.Value = "";
                LblEnt_is.Text = "";
            }

            hdnfocus.Value = txtlandvalue.ClientID;
            if (ddlproposal.SelectedValue == "2")
            {
                CalculatationEnterprisevalueLandExpansion();
                CalculatationEnterprisevalueBildExpansion();
                CalculatationEnterprisevaluePlantExpansion();
                CalculatationEnterprisefinalTotalvalue();
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void txtbuildingvalue_TextChanged(object sender, EventArgs e)
    {
        try
        {
            CalculatationEnterprisePrjCost();
            CalculatationEnterprise();
            if (ddlSector.SelectedIndex == 0)
            {
                HdfLblEnt_is.Value = "";
                LblEnt_is.Text = "";
            }

            hdnfocus.Value = txtlandvalue.ClientID;
            if (ddlproposal.SelectedValue == "2")
            {
                CalculatationEnterprisevalueLandExpansion();
                CalculatationEnterprisevalueBildExpansion();
                CalculatationEnterprisevaluePlantExpansion();
                CalculatationEnterprisefinalTotalvalue();
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void txtPlantvalue_TextChanged(object sender, EventArgs e)
    {
        try
        {
            CalculatationEnterprisePrjCost();
            CalculatationEnterprise();
            if (ddlSector.SelectedIndex == 0)
            {
                HdfLblEnt_is.Value = "";
                LblEnt_is.Text = "";
            }

            hdnfocus.Value = txtlandvalue.ClientID;
            if (ddlproposal.SelectedValue == "2")
            {
                CalculatationEnterprisevalueLandExpansion();
                CalculatationEnterprisevalueBildExpansion();
                CalculatationEnterprisevaluePlantExpansion();
                CalculatationEnterprisefinalTotalvalue();
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }


    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
        try
        {
            lblNOC0.Text = "";
            if (ddlproposal.SelectedValue != "2")
            {
                if (txtPlantvalueActual.Text.TrimStart().TrimEnd() == "0.00")
                {
                    success.Visible = false;
                    Failure.Visible = true;
                    lblmsg0.Text = "Plant and Machniery value should not be Zero";
                    lblmsg0.Focus();
                    return;
                }
            }

            if (rdpPOLRDP.SelectedValue == "N" && RdpFactory.SelectedValue == "N" && RdpIndustry.SelectedValue == "N" && RdpNOC.SelectedValue == "N" && RdpDrugs.SelectedValue == "N" && RdpBoiler.SelectedValue == "N")
            {
                lblNOC0.Text = "Please Select Atleast One Department";

                return;
            }


            BtnSave1.Visible = true;

            DataSet dss = new DataSet();
            string Enterpriseid = "0";
            //dss = Gen.GetEnterprisebyID1(HdfLblPol_Category.Value);
            dss = Gen.GetEnterprisebyID1(HdfLblEnt_is.Value);  //changed ..
            if (dss.Tables[0].Rows.Count > 0)
            {
                Enterpriseid = dss.Tables[0].Rows[0]["intEnterpriseType"].ToString();
            }

            string SearchVerfi = "";
            DataSet dsa = new DataSet();
            DataSet dsv = new DataSet();
            dsv = null;

            dsv = Gen.GetShowApprovalandFeesQues("0", Enterpriseid);
            DataSet dsMunicial = new DataSet();

            DataSet dsv1 = new DataSet();


            if (RdpIndustry.SelectedValue.ToString() == "Y")
            {

                dsv1 = Gen.GetShowApprovalandFees("16", "%");
                dsv.Tables[0].Merge(dsv1.Tables[0]);

            }

            if (rdpPOLRDP.SelectedValue.ToString().Trim() == "Y")
            {

                //dsMunicial = Gen.GetShowApprovalandFees("14", "%");
                dsMunicial = Gen.GetShowApprovalandFeesPCBCFO("14", "%", Session["Applid"].ToString());
                if (dsMunicial.Tables.Count >= 1)
                    dsv.Tables[0].Merge(dsMunicial.Tables[0]);

            }

            //if (ddlPower_Req.SelectedIndex == 1)
            //{

            //    dsv1 = Gen.GetShowApprovalandFees("21", Enterpriseid);
            //    dsv.Tables[0].Merge(dsv1.Tables[0]);
            //}
            //else 

            if (RdpFactory.SelectedValue.ToString() == "Y")
            {

                dsv1 = Gen.GetShowApprovalandFees("15", "%");
                dsv.Tables[0].Merge(dsv1.Tables[0]);
            }
            //if (RdpIndustry.SelectedValue.ToString() == "Y")
            //{

            //    dsv1 = Gen.GetShowApprovalandFees("16", "%");
            //    dsv.Tables[0].Merge(dsv1.Tables[0]);

            //}

            //if (rdBarLicense.SelectedValue.ToString() == "Y")
            //{
            //    DataSet dsBarLic = new DataSet();
            //    dsBarLic = Gen.GetShowApprovalandFees("106", "%");
            //    dsv.Tables[0].Merge(dsBarLic.Tables[0]);

            //}
            if (RdpNOC.SelectedValue.ToString() == "Y")
            {
                dsv1 = Gen.GetShowApprovalandFees("18", "%");
                dsv.Tables[0].Merge(dsv1.Tables[0]);


            }

            if (RdpDrugs.SelectedValue.ToString() == "Y")
            {

                dsv1 = Gen.GetShowApprovalandFees("17", "%");
                dsv.Tables[0].Merge(dsv1.Tables[0]);

            }
            if (RdpBoiler.SelectedValue.ToString() == "Y")
            {
                dsv1 = Gen.GetShowApprovalandFees("27", "%");
                dsv.Tables[0].Merge(dsv1.Tables[0]);

            }
            if (rbtnLstBoilerSteamPipeline.SelectedValue.ToString() == "Y")
            {
                dsv1 = Gen.GetShowApprovalandFees("67", "%");
                dsv.Tables[0].Merge(dsv1.Tables[0]);

            }

            //if (RdpService.SelectedValue.ToString() == "Y")
            //{
            //    if (ddlProp_intDistrictid.SelectedValue == "1" || ddlProp_intDistrictid.SelectedValue == "2" || ddlProp_intDistrictid.SelectedValue == "3" || ddlProp_intDistrictid.SelectedValue == "9" || ddlProp_intDistrictid.SelectedValue == "10" || ddlProp_intDistrictid.SelectedValue == "11" || ddlProp_intDistrictid.SelectedValue == "12" || ddlProp_intDistrictid.SelectedValue == "14" || ddlProp_intDistrictid.SelectedValue == "15" || ddlProp_intDistrictid.SelectedValue == "16" || ddlProp_intDistrictid.SelectedValue == "17" || ddlProp_intDistrictid.SelectedValue == "18" || ddlProp_intDistrictid.SelectedValue == "19" || ddlProp_intDistrictid.SelectedValue == "22" || ddlProp_intDistrictid.SelectedValue == "23" || ddlProp_intDistrictid.SelectedValue == "26" || ddlProp_intDistrictid.SelectedValue == "30")
            //    {
            //        dsv1 = Gen.GetShowApprovalandFees("39", "%");
            //        dsv.Tables[0].Merge(dsv1.Tables[0]);
            //        DataSet dscess = Gen.getCESSVillages(ddlProp_intVillageid.SelectedValue);
            //        if (dscess.Tables[0].Rows.Count > 0)
            //        {
            //            dsv1 = Gen.GetShowApprovalandFees("42", Enterpriseid);
            //            dsv.Tables[0].Merge(dsv1.Tables[0]);
            //        }
            //    }
            //    else
            //    {
            //        dsv1 = Gen.GetShowApprovalandFees("40", "%");
            //        dsv.Tables[0].Merge(dsv1.Tables[0]);
            //    }
            //}

            DataSet dsv4 = new DataSet();
            //dsv4 = Gen.GetShowApprovalandFeesEnterPriseAmount("33", Enterpriseid, txtPlantvalue.Text, txttotal.Text, "0");

            string TourismFlag = ""; //lavanya 20.10.2020
            if (ViewState["TOURISMFLAG"] != null)
                TourismFlag = ViewState["TOURISMFLAG"].ToString();
            if (TourismFlag == "Y")
            {
                DataSet dsTourismFees = new DataSet();
                dsTourismFees = Gen.GetShowApprovalandFeesEnterPriseAmount("109", Enterpriseid, txtPlantvalue.Text, txttotal.Text, "0");
                dsv.Tables[0].Merge(dsTourismFees.Tables[0]);

                DataSet dsCommonApprovals = new DataSet();

                dsCommonApprovals = Gen.GetShowApprovalandFees_TOURISMFOR_ALL(Enterpriseid, rdPoliceNOC.SelectedValue, rdBarLicense.SelectedValue, rbtnTradeLicense.SelectedValue, rbtnHealthandSanitary.SelectedValue,
                 rbtnFSSAI.SelectedValue, ddlProp_intVillageid.SelectedValue, ddlProp_intMandalid.SelectedValue);
                if (dsCommonApprovals != null)
                {
                    if (dsCommonApprovals.Tables.Count > 0 && dsCommonApprovals.Tables[0].Rows.Count > 0)
                    {
                        dsv.Tables[0].Merge(dsCommonApprovals.Tables[0]);
                    }
                    if (dsCommonApprovals.Tables.Count > 1 && dsCommonApprovals.Tables[1].Rows.Count > 0)
                    {
                        dsv.Tables[0].Merge(dsCommonApprovals.Tables[1]);
                    }
                    if (dsCommonApprovals.Tables.Count > 2 && dsCommonApprovals.Tables[2].Rows.Count > 0)
                    {
                        dsv.Tables[0].Merge(dsCommonApprovals.Tables[2]);
                    }
                    if (dsCommonApprovals.Tables.Count > 3 && dsCommonApprovals.Tables[3].Rows.Count > 0)
                    {
                        dsv.Tables[0].Merge(dsCommonApprovals.Tables[3]);
                    }
                    if (dsCommonApprovals.Tables.Count > 4 && dsCommonApprovals.Tables[4].Rows.Count > 0)
                    {
                        dsv.Tables[0].Merge(dsCommonApprovals.Tables[4]);
                    }
                }
            }
            else
            {
                if (ddlproposal.SelectedValue.ToString() == "1")
                    dsv4 = Gen.GetShowApprovalandFeesEnterPriseAmount("33", Enterpriseid, txtPlantvalue.Text, txttotal.Text, "0");
                if (ddlproposal.SelectedValue.ToString() == "2")  //changed on 10.12.2018.. 
                    dsv4 = Gen.GetShowApprovalandFeesEnterPriseAmount("33", Enterpriseid, txtPlantvalue.Text, txtlbltotalprojectcostexpanstion.Text, "0");
                dsv.Tables[0].Merge(dsv4.Tables[0]);
            }



            // Labor ACts
            DataSet dsLabour = new DataSet();//lavanya
            string LabourActId = "", EmployeeCount = "0";
            EmployeeCount = txtNoofworkers.Text.Trim().TrimStart();

            if (EmployeeCount == "")
            {
                EmployeeCount = "0";
            }

            //if (TxtProp_Emp.Text.Trim() == "")
            //{
            //    EmployeeCount = "0";
            //}
            //else
            //{
            //    EmployeeCount = TxtProp_Emp.Text.Trim();
            //}

            if (RdbExecpted0.SelectedValue == "Y")
            {
                dsLabour = Gen.GetShowApprovalandFeesLabour("50", Enterpriseid, ddlProp_intDistrictid.SelectedValue, "3", txtContractLabourAct.Text.Trim().TrimStart());
                dsv.Tables[0].Merge(dsLabour.Tables[0]);
            }
            DataSet dsLabour1 = new DataSet();
            if (RdbExecpted1.SelectedValue == "Y")
            {
                dsLabour1 = Gen.GetShowApprovalandFeesLabour("51", Enterpriseid, ddlProp_intDistrictid.SelectedValue, "4", txtMigrantWorkmanAct.Text.Trim().TrimStart());
                dsv.Tables[0].Merge(dsLabour1.Tables[0]);
            }
            DataSet dsLabour2 = new DataSet();
            if (RdbExecptedact1.SelectedValue == "Y")
            {
                // yyyy-MM-dd
                //string[] newdate = txtDateofCommenceAct1.Text.ToString().Split('-');
                //string date = newdate[1].ToString() + "/" + newdate[2].ToString() + "/" + newdate[0].ToString();
                //dsLabour2 = Gen.GetShowApprovalandFeesLabouract1("52", Enterpriseid, ddlProp_intDistrictid.SelectedValue, "1", txtNoofworkers.Text.Trim().TrimStart(), date);
                //dsv.Tables[0].Merge(dsLabour2.Tables[0]);
                string[] newdate = txtDateofCommenceAct1.Text.ToString().Split('-');
                string date = newdate[0].ToString() + "/" + newdate[1].ToString() + "/" + newdate[2].ToString();
                string date1 = newdate[1].ToString() + "/" + newdate[0].ToString() + "/" + newdate[2].ToString();
                int empcount = Convert.ToInt32(txtNoofworkers.Text.Trim());
                //LabourCFOTest.actsResponse feeout = new LabourCFOTest.actsResponse();
                string output = labourcfo.feeDetails(empcount, date, "SEF");
                if (output != "")
                {
                    string[] values = output.Split('|');
                    string[] compound_fee = values[10].Split('=');
                    labourservicevo.compound_fee = compound_fee[1];
                    labourservicevo.Created_by = Session["uid"].ToString().Trim();

                    string[] datecommencement = values[1].Split('=');
                    string[] newdatecommencement = datecommencement[1].Split('/');
                    string commencement = newdatecommencement[1].ToString() + "/" + newdatecommencement[0].ToString() + "/" + newdatecommencement[2].ToString();
                    labourservicevo.date_commencement = commencement;
                    //labourservicevo.Form1_2_Est_Compltd_Dt= values[];
                    labourservicevo.intCFEOnterpid = Session["uid"].ToString().Trim();
                    string[] max_employees_aday = values[0].Split('=');
                    labourservicevo.max_employees_aday = max_employees_aday[1];

                    string[] newPenalityAmount2017 = values[18].Split('=');
                    labourservicevo.newPenalityAmount2017 = newPenalityAmount2017[1];

                    string[] newPenalityYears2017 = values[16].Split('=');
                    labourservicevo.newPenalityYears2017 = newPenalityYears2017[1];

                    string[] newRegistrationAmount2017 = values[20].Split('=');
                    labourservicevo.newRegistrationAmount2017 = newRegistrationAmount2017[1];

                    string[] newRegistrationYears2017 = values[14].Split('=');
                    labourservicevo.newRegistrationYears2017 = newRegistrationYears2017[1];

                    string[] oldPenalityAmount2016 = values[17].Split('=');
                    labourservicevo.oldPenalityAmount2016 = oldPenalityAmount2016[1];

                    string[] oldPenalityYears2016 = values[15].Split('=');
                    labourservicevo.oldPenalityYears2016 = oldPenalityYears2016[1];

                    string[] oldRegistrationAmount2016 = values[19].Split('=');
                    labourservicevo.oldRegistrationAmount2016 = oldRegistrationAmount2016[1];

                    string[] oldRegistrationYears2016 = values[13].Split('=');
                    labourservicevo.oldRegistrationYears2016 = oldRegistrationYears2016[1];

                    string[] penality_percentage = values[9].Split('=');
                    labourservicevo.penality_percentage = penality_percentage[1];

                    string[] penality_years = values[8].Split('=');
                    labourservicevo.penality_years = penality_years[1];

                    //labourservicevo.QuestionnaireCFOId= values[];
                    string[] registration_fee = values[6].Split('=');
                    labourservicevo.registration_fee = registration_fee[1];

                    string[] registration_years = values[7].Split('=');
                    labourservicevo.registration_years = registration_years[1];

                    string[] total_amount_payable = values[2].Split('=');
                    labourservicevo.total_amount_payable = total_amount_payable[1];

                    string[] total_penality_amount = values[12].Split('=');
                    labourservicevo.total_penality_amount = total_penality_amount[1];

                    string[] total_registration_fee = values[11].Split('=');
                    labourservicevo.total_registration_fee = total_registration_fee[1];

                    string[] transaction_date = values[5].Split('=');
                    string[] newdatetransaction = transaction_date[1].Split('/');
                    string datetransaction = newdatetransaction[1].ToString() + "/" + newdatetransaction[0].ToString() + "/" + newdatetransaction[2].ToString();
                    labourservicevo.transaction_date = datetransaction;

                    string[] valid_from_date = values[3].Split('=');
                    string[] newdatevalidfrom = valid_from_date[1].Split('/');
                    string datevalidfrom = newdatevalidfrom[1].ToString() + "/" + newdatevalidfrom[0].ToString() + "/" + newdatevalidfrom[2].ToString();
                    labourservicevo.valid_from_date = datevalidfrom;

                    string[] valid_to_date = values[4].Split('=');
                    string[] newdatevalidto = valid_to_date[1].Split('/');
                    string datevalidto = newdatevalidto[1].ToString() + "/" + newdatevalidto[0].ToString() + "/" + newdatevalidto[2].ToString();
                    labourservicevo.valid_to_date = datevalidto;

                    string valid = InsertLabourShopServiceDetails(labourservicevo, output);
                }
                dsLabour2 = Gen.GetShowApprovalandFeesLabouract1("52", Enterpriseid, ddlProp_intDistrictid.SelectedValue, "1", txtNoofworkers.Text.Trim().TrimStart(), date1, Session["uid"].ToString().Trim());
                dsv.Tables[0].Merge(dsLabour2.Tables[0]);
            }

            DataSet dsLegal = new DataSet();

            if (rbtnLstLabel.SelectedValue == "Y")
            {
                dsLegal = Gen.GetShowApprovalandFeesLegal("0", Enterpriseid, ddlProp_intDistrictid.SelectedValue);
                dsv.Tables[0].Merge(dsLegal.Tables[0]);
            }
            DataSet dsOC = new DataSet();

            if (RDOC.SelectedValue != null)
            {
                if (RDOC.SelectedValue == "HMDA")
                {
                    dsOC = Gen.GetShowApprovalandFees("73", "%");
                    dsv.Tables[0].Merge(dsOC.Tables[0]);
                }
                if (RDOC.SelectedValue == "TSIIC")
                {
                    dsOC = Gen.GetShowApprovalandFees("74", "%");
                    dsv.Tables[0].Merge(dsOC.Tables[0]);
                }
            }
            if (dsv.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = dsv.Tables[0];
                grdDetails.DataBind();
                grdDetails.Columns[3].Visible = false;
                dvfeedetails.Visible = true;
            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }
            BtnSave2.CssClass = "btn-primary";
            BtnSave1.CssClass = "button";
        }



        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
        finally
        {
        }


    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

            if ((e.Row.RowType == DataControlRowType.DataRow))
            {
                // decimal TotalFee1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fees"));
                //TotalFee = TotalFee + TotalFee1;



                HiddenField HdfApprovalid = (HiddenField)e.Row.Cells[0].FindControl("HdfApprovalid");
                HdfApprovalid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ApprovalId")).Trim();

                HiddenField HdfQueid = (HiddenField)e.Row.Cells[0].FindControl("HdfQueid");
                HdfQueid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Dept_Id")).Trim();
            }
            if ((e.Row.RowType == DataControlRowType.Footer))
            {
                e.Row.Cells[2].Text = "";
                e.Row.Cells[3].Text = TotalFee.ToString("f0");
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void RdpDrugs0_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (RdpDrugs0.SelectedValue.ToString().Trim() == "Y")
            {
                servicelat.Visible = true;

            }
            else
            {
                servicelat.Visible = false;
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }

    }
    protected void ddlProp_intVillageid_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlProp_intDistrictid.SelectedValue == "1" || ddlProp_intDistrictid.SelectedValue == "2" || ddlProp_intDistrictid.SelectedValue == "3" || ddlProp_intDistrictid.SelectedValue == "9" || ddlProp_intDistrictid.SelectedValue == "10")
            {
                DataSet dscess = Gen.getCESSVillages(ddlProp_intVillageid.SelectedValue);
                if (dscess.Tables[0].Rows.Count > 0)
                {
                    Label399.Text = "Do you have feasibility report of TSNPDCL/CESS Sircilla";
                }
                else
                {
                    Label399.Text = "Do you have feasibility report of TSNPDCL";
                }

            }
            else
            {
                Label399.Text = "Do you have feasibility report of TSSPDCL";
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void ddlcurrencytype_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtlandvalueActul.Text = "0";
        txtlandvalue.Text = "0";
        txtbuildingvalueActual.Text = "0";
        txtbuildingvalue.Text = "0";
        txtPlantvalueActual.Text = "0";
        txtPlantvalue.Text = "0";

        TxtVal_Land_ActualExpansion.Text = "0";
        TxtVal_Build_ActualExpn.Text = "0";
        TxtVal_Plant_ActualExpansion.Text = "0";

        TxtVal_LandExpansion.Text = "0";
        TxtVal_BuildExpanstion.Text = "0";
        TxtVal_PlantExpanstion.Text = "0";
    }
    protected void txtlandvalueActul_TextChanged(object sender, EventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
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
        try
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
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void Tab1_Click(object sender, EventArgs e)
    {
        MainView.ActiveViewIndex = 0;
    }

    protected void Tab2_Click(object sender, EventArgs e)
    {
        MainView.ActiveViewIndex = 1;
    }

    protected void Tab3_Click(object sender, EventArgs e)
    {
        MainView.ActiveViewIndex = 2;
    }

    protected void btntab1next_Click(object sender, EventArgs e)
    {
        if (txtcfeuidno.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter CFE UID Number')", true);
            txtcfeuidno.Enabled = true;
            return;
        }
        else
        {
            txtcfeuidno.Enabled = false;
        }
        Tab2.Attributes.Add("class", "active");
        Tab1.Attributes.Add("class", "");
        Tab3.Attributes.Add("class", "");
        MainView.ActiveViewIndex = 1;
    }
    protected void btntab3privious_Click(object sender, EventArgs e)
    {
        Tab2.Attributes.Add("class", "active");
        Tab1.Attributes.Add("class", "");
        Tab3.Attributes.Add("class", "");
        MainView.ActiveViewIndex = 1;
    }
    protected void btntab2next_Click(object sender, EventArgs e)
    {
        Tab2.Attributes.Add("class", "");
        Tab1.Attributes.Add("class", "");
        Tab3.Attributes.Add("class", "active");
        MainView.ActiveViewIndex = 2;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Tab2.Attributes.Add("class", "");
        Tab1.Attributes.Add("class", "active");
        Tab3.Attributes.Add("class", "");
        MainView.ActiveViewIndex = 0;
    }

    protected void RdbExecptedact1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (RdbExecptedact1.SelectedValue == "Y")
            {
                tract2.Visible = true;
                tract2dateofcommencement.Visible = true;
                //  txtContractLabourAct.Visible = true;
            }
            else
            {
                tract2.Visible = false;
                txtContractLabourAct.Text = "";
                tract2dateofcommencement.Visible = false;
                // txtContractLabourAct.Visible = false;
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void RdbExecpted0_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbExecpted0.SelectedValue == "Y")
        {
            tract3.Visible = true;
            //  txtContractLabourAct.Visible = true;
        }
        else
        {
            tract3.Visible = false;
            txtContractLabourAct.Text = "";
            // txtContractLabourAct.Visible = false;
        }
    }
    protected void RdbExecpted1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbExecpted1.SelectedValue == "Y")
        {
            tract4new.Visible = true;
        }
        else
        {
            tract4new.Visible = false;
            txtMigrantWorkmanAct.Text = "";
        }
    }

    protected void ddlproposal_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlproposal.SelectedValue == "1")
            {
                tdprojectcostname.InnerHtml = "<u>New Investment</u>";
                tblexpansion.Visible = false;
            }
            else if (ddlproposal.SelectedValue == "2")
            {
                tdprojectcostname.InnerHtml = "<u>Existing Investment</u>";
                tblexpansion.Visible = true;

            }
            else
            {
                tdprojectcostname.InnerHtml = "<u>New Investment</u>";
                tblexpansion.Visible = false;
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void TxtVal_Land_ActualExpansion_TextChanged(object sender, EventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void TxtVal_LandExpansion_TextChanged(object sender, EventArgs e)
    {
        CalculatationEnterprisePrjCostExpansion();

        CalculatationEnterprisevalueLandExpansion();
        CalculatationEnterprisevalueBildExpansion();
        CalculatationEnterprisevaluePlantExpansion();
        CalculatationEnterprisefinalTotalvalue();
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

        CalculatationEnterprisevalueLandExpansion();
        CalculatationEnterprisevalueBildExpansion();
        CalculatationEnterprisevaluePlantExpansion();
        CalculatationEnterprisefinalTotalvalue();
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

        CalculatationEnterprisevalueLandExpansion();
        CalculatationEnterprisevalueBildExpansion();
        CalculatationEnterprisevaluePlantExpansion();
        CalculatationEnterprisefinalTotalvalue();
    }
    public void CalculatationEnterprisePrjCostExpansion()
    {
        try
        {
            if (ddlSector.SelectedIndex != 0)
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
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    public void CalculatationEnterprisevalueLandExpansion()
    {
        try
        {
            if (ddlSector.SelectedIndex != 0)
            {
                if (txtlandvalue.Text.Trim() == "")
                {
                    txtlandvalue.Text = "0";
                }

                if (TxtVal_LandExpansion.Text.Trim() == "")
                {
                    TxtVal_LandExpansion.Text = "0";
                }

                lbltotalexpvalulandexp.Text = Convert.ToString((Convert.ToDecimal(txtlandvalue.Text) + Convert.ToDecimal(TxtVal_LandExpansion.Text)));
                lblmsg.Text = "";
                CalculatationEnterprisefinalTotalvalue();
            }
            else
            {
                txtlbltotalprojectcostexpanstion.Text = "0";
                lblmsg.Text = "Please Select Sector of Enterprise";
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    public void CalculatationEnterprisevalueBildExpansion()
    {
        try
        {
            if (ddlSector.SelectedIndex != 0)
            {
                if (txtbuildingvalue.Text.Trim() == "")
                {
                    txtbuildingvalue.Text = "0";
                }

                if (TxtVal_BuildExpanstion.Text.Trim() == "")
                {
                    TxtVal_BuildExpanstion.Text = "0";
                }

                lblbuildtotalexpvavalue.Text = Convert.ToString((Convert.ToDecimal(txtbuildingvalue.Text) + Convert.ToDecimal(TxtVal_BuildExpanstion.Text)));
                lblmsg.Text = "";
                CalculatationEnterprisefinalTotalvalue();
            }
            else
            {
                txtlbltotalprojectcostexpanstion.Text = "0";
                lblmsg.Text = "Please Select Sector of Enterprise";
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    public void CalculatationEnterprisevaluePlantExpansion()
    {
        try
        {
            if (ddlSector.SelectedIndex != 0)
            {
                if (txtPlantvalue.Text.Trim() == "")
                {
                    txtPlantvalue.Text = "0";
                }

                if (TxtVal_PlantExpanstion.Text.Trim() == "")
                {
                    TxtVal_PlantExpanstion.Text = "0";
                }

                lblplantotalexp.Text = Convert.ToString((Convert.ToDecimal(txtPlantvalue.Text) + Convert.ToDecimal(TxtVal_PlantExpanstion.Text)));
                lblmsg.Text = "";
                CalculatationEnterprisefinalTotalvalue();
            }
            else
            {
                txtlbltotalprojectcostexpanstion.Text = "0";
                lblmsg.Text = "Please Select Sector of Enterprise";
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    public void CalculatationEnterprisefinalTotalvalue()
    {
        try
        {
            if (ddlSector.SelectedIndex != 0)
            {
                if (lbltotalexpvalulandexp.Text.Trim() == "")
                {
                    lbltotalexpvalulandexp.Text = "0";
                }

                if (lblbuildtotalexpvavalue.Text.Trim() == "")
                {
                    lblbuildtotalexpvavalue.Text = "0";
                }
                if (lblplantotalexp.Text.Trim() == "")
                {
                    lblplantotalexp.Text = "0";
                }
                lblfinaltotalvalue.Text = Convert.ToString((Convert.ToDecimal(lbltotalexpvalulandexp.Text) + Convert.ToDecimal(lblbuildtotalexpvavalue.Text) + Convert.ToDecimal(lblplantotalexp.Text)));
                lblmsg.Text = "";
            }
            else
            {
                txtlbltotalprojectcostexpanstion.Text = "0";
                lblmsg.Text = "Please Select Sector of Enterprise";
            }
            CalculatationEnterprise();
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    public string InsertLabourShopServiceDetails(LabourShopServiceVo objvo1, string output)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        string valid = "";
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();
        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "USP_INS_CFOLabourShopService_Detailss";
            com.Transaction = transaction;
            com.Connection = connection;
            com.Parameters.AddWithValue("@QuestionnaireCFOId", objvo1.QuestionnaireCFOId);
            com.Parameters.AddWithValue("@intCFEOnterpid", objvo1.intCFEOnterpid);
            com.Parameters.AddWithValue("@Form1_2_Est_Compltd_Dt", objvo1.Form1_2_Est_Compltd_Dt);
            com.Parameters.AddWithValue("@max_employees_aday", objvo1.max_employees_aday);
            com.Parameters.AddWithValue("@date_commencement", objvo1.date_commencement);
            com.Parameters.AddWithValue("@total_amount_payable", objvo1.total_amount_payable);
            com.Parameters.AddWithValue("@valid_from_date", objvo1.valid_from_date);
            com.Parameters.AddWithValue("@valid_to_date", objvo1.valid_to_date);
            com.Parameters.AddWithValue("@transaction_date", objvo1.transaction_date);
            com.Parameters.AddWithValue("@registration_fee", objvo1.registration_fee);
            com.Parameters.AddWithValue("@registration_years", objvo1.registration_years);
            com.Parameters.AddWithValue("@penality_years", objvo1.penality_years);
            com.Parameters.AddWithValue("@penality_percentage", objvo1.penality_percentage);
            com.Parameters.AddWithValue("@compound_fee", objvo1.compound_fee);
            com.Parameters.AddWithValue("@total_registration_fee", objvo1.total_registration_fee);
            com.Parameters.AddWithValue("@total_penality_amount", objvo1.total_penality_amount);
            com.Parameters.AddWithValue("@oldRegistrationYears2016", objvo1.oldRegistrationYears2016);
            com.Parameters.AddWithValue("@newRegistrationYears2017", objvo1.newRegistrationYears2017);
            com.Parameters.AddWithValue("@oldPenalityYears2016", objvo1.oldPenalityYears2016);
            com.Parameters.AddWithValue("@newPenalityYears2017", objvo1.newPenalityYears2017);
            com.Parameters.AddWithValue("@oldPenalityAmount2016", objvo1.oldPenalityAmount2016);
            com.Parameters.AddWithValue("@newPenalityAmount2017", objvo1.newPenalityAmount2017);
            com.Parameters.AddWithValue("@oldRegistrationAmount2016", objvo1.oldRegistrationAmount2016);
            com.Parameters.AddWithValue("@newRegistrationAmount2017", objvo1.newRegistrationAmount2017);
            com.Parameters.AddWithValue("@Created_by", objvo1.Created_by);
            com.Parameters.AddWithValue("@Outputdata", output);

            com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
            com.Parameters["@Valid"].Direction = ParameterDirection.Output;

            //com.Parameters.Add("@TSipassApplicationNo", SqlDbType.VarChar, 500);
            //com.Parameters["@TSipassApplicationNo"].Direction = ParameterDirection.Output;

            com.ExecuteNonQuery();

            valid = com.Parameters["@Valid"].Value.ToString();
            //ApplicationNumber = com.Parameters["@Valid"].Value.ToString();
            transaction.Commit();
            connection.Close();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw ex;
        }
        finally
        {
            connection.Close();
            connection.Dispose();
        }
        return valid;
    }

    protected void txtfilenumber_TextChanged(object sender, EventArgs e)
    {
        try
        {

            HMDAService.ProposalDetailsResponse hmdaproposaldetailsvo = new HMDAService.ProposalDetailsResponse();
            HMDAService.SanctionBuildingDetailsResponse[] hmdasanctiondetailsvo = null;
            HmdaOcVos hmdvo = new HmdaOcVos();

            if (txtfilenumber.Text.Trim() != "")
            {
                hmdapplicationresponse = HMDAObj.getDetailsforOccupancy(11, txtfilenumber.Text.Trim(), "$$08@213");
                if (hmdapplicationresponse.ResponseStatus == 1)
                {
                    DataSet dsbp = new DataSet();
                    dsbp = Gen.GetBuildingPErmissionNumber(Session["UID"].ToString(), txtfilenumber.Text.Trim(), "");

                    trcanumber.Visible = true;
                    if (dsbp.Tables[0].Rows[0]["architectno"].ToString() != "" && dsbp.Tables[0].Rows[0]["architectno"] != null)
                    {
                        if (dsbp.Tables[0].Rows[0]["architectno"].ToString().Contains("/"))
                        {
                            string[] values = dsbp.Tables[0].Rows[0]["architectno"].ToString().Split('/');
                            txtalic2.Text = values[1].Trim();
                            txtalic3.Text = values[2].Trim();
                            txtalic1.Enabled = false;
                            txtalic2.Enabled = false;
                            txtalic3.Enabled = false;
                        }

                    }
                }
                else
                {
                    Failure.Visible = false;
                    lblmsg0.Text = hmdapplicationresponse.ErrorMessage;
                }

                ////trmaindtlstab1.Visible = true;
                //hmdaproposaldetailsvo = hmdapplicationresponse.ProposalDetailsResponse;
                //hmdasanctiondetailsvo = hmdapplicationresponse.SanctionBuildingList;
                ////hmdasanctiondetailsvo.GetValue
                //HMDAService.SanctionBuildingDetailsResponse sactionvo = new HMDAService.SanctionBuildingDetailsResponse();
                //lstSanctionBuildingDetails.Clear();
                //int hmdabuildingcount = hmdasanctiondetailsvo.Length;
                //for (int b = 0; b < hmdabuildingcount; b++)
                //{
                //    sactionvo = hmdasanctiondetailsvo[b];
                //    SactionBuildingTsipassvo.Buildingid = Convert.ToString(sactionvo.BuildingId);
                //    SactionBuildingTsipassvo.BuildingName = sactionvo.BuildingName;
                //    SactionBuildingTsipassvo.intQuessionaireCFOid = Session["ApplidA"].ToString();
                //    if (sactionvo.PlotId != 0)
                //    {
                //        SactionBuildingTsipassvo.PlotNo = Convert.ToString(sactionvo.PlotId);
                //    }
                //    SactionBuildingTsipassvo.CreatedBy = Session["uid"].ToString();
                //    SactionBuildingTsipassvo.intCFOEnterid = Session["uid"].ToString();
                //    lstSanctionBuildingDetails.Add(SactionBuildingTsipassvo);
                //}
                //hmdvo.intQuessionaireCFOid = Session["ApplidA"].ToString();
                ////int output = insetHMDABuildingDetails(lstSanctionBuildingDetails);
                //int output = Gen.insertbuildinglist(lstSanctionBuildingDetails, hmdvo);
                //txtMobileNo.Text = hmdapplicationresponse.MobileNo;
                //txtOwnerName.Text = hmdapplicationresponse.Name;

                ////string penalty = hmdapplicationresponse.PenaltyAmount;
                ////string totalamount = hmdapplicationresponse.TotalAmount;
                //txtProceedingIssuedOnDate.Text = hmdaproposaldetailsvo.Building_Permit_Date;
                //// hmdaproposaldetailsvo.Building_Permit_No;
                //ddlUnitDIst.SelectedValue = hmdaproposaldetailsvo.District;
                //txtPlotNo.Text = hmdaproposaldetailsvo.Plot_No;
                //txtSurveyNo.Text = hmdaproposaldetailsvo.Survey_No;
                //// hmdaproposaldetailsvo.Tot_Lot_Area;
                //ddldistrictunit_SelectedIndexChanged(sender, e);
                //ddlUnitMandal.SelectedValue = hmdaproposaldetailsvo.Mandal;
                //ddlUnitMandal_SelectedIndexChanged(sender, e);
                //ddlVillageunit.SelectedValue = hmdaproposaldetailsvo.Village;
                ////   hmdaproposaldetailsvo.Ward_No;
                //txtofficezone.Text = hmdaproposaldetailsvo.Zone;

                //txtTechnicalEmailId.Text = hmdaproposaldetailsvo.Email;
                //// hmdaproposaldetailsvo.Locality;
                //// hmdaproposaldetailsvo.Location_Type;

                //txtTechnicalMobileNo.Text = hmdaproposaldetailsvo.MobileNo;
                //txtNoofFloors.Text = hmdaproposaldetailsvo.No_of_Building;
                ////hmdaproposaldetailsvo.Occupancy_Applied_for;
                //txtOwnerName.Text = hmdaproposaldetailsvo.Owner_Name;
                //// hmdaproposaldetailsvo.Parking_Space_Provisions;
                //txtPlotNo.Text = hmdaproposaldetailsvo.Plot_No;
                //txtBuildingProposedBuilding.Text = hmdaproposaldetailsvo.Proposed_Plot_Area;
                //txtBuildingSubUse.Text = hmdaproposaldetailsvo.Proposed_Use;
                //// hmdaproposaldetailsvo.Road_Street;
                //txtRoadAffectedArea.Text = hmdaproposaldetailsvo.Road_Widening;
                //txtRear.Text = hmdaproposaldetailsvo.RWH_Pits;

                // hmdapplicationresponse.UniqueID;
                // }

                //hmdapplicationresponse.
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void RDOC_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (RDOC.SelectedValue == "HMDA")
            {
                trhmdatsiicfileno.Visible = true;
            }
            else if (RDOC.SelectedValue == "TSIIC")
            {
                trhmdatsiicfileno.Visible = true;
            }
            else
            {
                trhmdatsiicfileno.Visible = false;
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void txtcfeuidno_TextChanged(object sender, EventArgs e)
    {
        try
        {
            //string errormsg = Gen.CHECKVALIDCFECFO(txtcfeuidno.Text, "CFE");
            //if (errormsg != null && errormsg != "")
            //{
            //    string message = "alert(" + errormsg + ")";               
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "alert('" + errormsg + "');", true);
            //    txtcfeuidno.Text = "";

            //}
            string errormsg = Gen.CHECKVALIDCFECFO(txtcfeuidno.Text, "CFE");
            if (errormsg != null && errormsg != "" && errormsg != "VALID UID NUMBER")
            {
                success.Visible = false;
                Failure.Visible = true;
                lblmsg0.Text = errormsg;
                txtcfeuidno.Text = "";

            }

            if (errormsg != null && errormsg != "" && errormsg != "PLEASE ENTER VALID UID NUMBER")
            {
                txtcfeuidno.Enabled = false;
                string message = "alert(" + errormsg + ")";
                ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "alert('" + errormsg + "');", true);
                //string message = "alert(" + errormsg + ")";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "alert('" + errormsg + "');", true);
                ////txtcfeuidno.Text = "";
                //txtcfouidno.Enabled = false;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void rdPoliceNOC_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdPoliceNOC.SelectedValue == "Y")
        {
            trTourismPoliceNOCYesCond1.Visible = true;
            trTourismPoliceNOCYesCond2.Visible = false;
            trPoliceBuiltupAreaInput.Visible = true;
            trStorageConstructionYes.Visible = false;

        }
        else
        {
            trTourismPoliceNOCYesCond1.Visible = false;
            trTourismPoliceNOCYesCond2.Visible = false;
            trPoliceBuiltupAreaInput.Visible = false;
        }
    }
    protected void rdBarLicense_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdBarLicense.SelectedValue == "Y")
        {
            lblBarLicense.Visible = true;
        }
        else
        {
            lblBarLicense.Visible = false;
        }
    }
    protected void rbtnTradeLicense_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtnTradeLicense.SelectedValue == "Y")
        {
        }
        else
        {

        }
    }
    protected void rdParkingCondition_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdParkingCondition.SelectedValue == "Y")
            trParkingConditionYes.Visible = true;
        if (rdParkingCondition.SelectedValue == "N")
            trParkingConditionYes.Visible = false;
    }

    protected void rdStorageConstruction_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdStorageConstruction.SelectedValue == "Y")
            trStorageConstructionYes.Visible = true;
        if (rdStorageConstruction.SelectedValue == "N")
            trStorageConstructionYes.Visible = false;
    }

    protected void rdhotelcfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdhotelcfo.SelectedValue == "Y")
        {
            trTourismPoliceNOC.Visible = true;


        }
        else
        {
            trTourismPoliceNOC.Visible = false;

        }
    }

    //protected void ddlClassification_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string classifi = ddlClassification.SelectedValue;
    //    if (Convert.ToInt32(classifi) >= 3)
    //    {

    //    }
    //}
}