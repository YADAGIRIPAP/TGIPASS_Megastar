using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

//created by suresh as on 13-1-2016 
//tables is td_BDCDet,tbl_Users
//procedures CheckUserid,insrtBDC,deleteBDC,getBDCbyID

public partial class TSTBDCReg1 : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    int CFESTATUS;
    int delete = 0;
    comFunctions cmf = new comFunctions();
    CommonBL objcommon = new CommonBL();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    decimal TotalFee;
    LabourCFOService.TSLabourServiceImplService labourcfo = new LabourCFOService.TSLabourServiceImplService();
    LabourShopServiceVo labourservicevo = new LabourShopServiceVo();
    List<Screendetails> lstscreendetails = new List<Screendetails>();
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
                ddlSector.SelectedValue = "1";

                Session["Applid"] = "0";

                if (Session["uid"].ToString() == "17083")
                {
                    trApprovalLblRegn.Visible = true;

                    trExportExcise.Visible = true;
                    trBrandRegn.Visible = true;
                }
                DataSet DSCFE = new DataSet();
                DSCFE = Getverifyofque9(Session["uid"].ToString().Trim());
                if (DSCFE != null && DSCFE.Tables.Count > 0 && DSCFE.Tables[0].Rows.Count > 0)
                {
                    CFESTATUS = 1;
                }
                else
                {
                    CFESTATUS = 0;
                }
                DataSet dscheck = new DataSet();


                DataSet dschecknew = new DataSet();
                dschecknew = Gen.GetShowQuestionariesCFOnew(Session["uid"].ToString().Trim());
                if (dschecknew != null && dschecknew.Tables.Count > 0 && dschecknew.Tables[0].Rows.Count > 0)
                {
                    if(dschecknew != null && dschecknew.Tables.Count > 0 && dschecknew.Tables[4].Rows.Count > 0)
                    {
                        HDNDATEOFPAYMENT.Value = dschecknew.Tables[4].Rows[0]["PAYMENTDATE"].ToString().Trim();

                    }
                    Session["Applid"] = dschecknew.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
                    string res = dschecknew.Tables[0].Rows[0]["Appl_Status"].ToString();
                    HDNAPPLNSTATUS.Value = res.ToString();
                    fillDetails(dschecknew);
                }
                else
                {
                    dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
                  //  Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();

                    if (dscheck != null && dscheck.Tables.Count > 0 && dscheck.Tables[4].Rows.Count > 0)
                    {
                        HDNDATEOFPAYMENT.Value = dscheck.Tables[6].Rows[0]["PAYMENTDATE"].ToString().Trim();
                    }
                    HDNAPPLNSTATUS.Value = "2";
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
                   // HDNAPPLNSTATUS.Value = res.ToString();


                    if (res == "3" || Convert.ToInt32(res) >= 3)
                    {
                        BtnSave2.Visible = false;
                        BtnSave1.Visible = false;
                        BtnClear.Visible = false;
                        ResetFormControl(this);
                    }
                    if (res == "3" || Convert.ToInt32(res) >= 3)
                    {

                        if (RdpIndustry.SelectedValue == "N")
                        {
                            RdpIndustry.Enabled = true;
                            BtnSave2.Visible = true;
                            BtnSave1.Visible = true;
                        }
                        else
                        {
                            RdpIndustry.Enabled = false;
                            BtnSave2.Visible = false;
                            BtnSave1.Visible = false;
                        }
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
            // RdbExecptedact1.Enabled = false;
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    public DataSet Getverifyofque9(string Created_by)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("getdataverifyque_CFEAPPLICATIONSTATUS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (Created_by.Trim() == "" || Created_by.Trim() == null)
                da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.ToString();



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
            //DataSet dsd = new DataSet();
            //ddlProp_intDistrictid.Items.Clear();
            //dsd = Gen.GetDistrictsWithoutHYD();

            Cls_MasterofTsipass obj_newdistrictwargnal = new Cls_MasterofTsipass();
            DataSet dsd = new DataSet();
            ddlProp_intDistrictid.Items.Clear();
            dsd = obj_newdistrictwargnal.GetallDistrictswithoutWarangal(Convert.ToString(Session["uid"]), "CFO");

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
            dsc = GetCategoryDetNew_CFO(Session["uid"].ToString());
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
    public DataSet GetCategoryDetNew_CFO(string createdby)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetCategoryDetNew_CFO", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@CREATEDBY", SqlDbType.VarChar).Value = createdby.ToString();
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
                txtNameOfIndustrialUndertaking.Text = dscheck.Tables[0].Rows[0]["nameofunit"].ToString();
                if (Session["uid"].ToString().Trim() == "255110")
                {
                    txtNameOfIndustrialUndertaking.Text = "ASPIRO PHARMA LIMITED";
                }
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

                ////added by madhuri on 24/05/2022//

                if (dscheck.Tables[0].Rows.Count > 0)
                {
                    ddlcurrencytype.Enabled = false;
                    ddlproposal.Enabled = false;

                    txtlandvalueActul.Enabled = true;
                    txtbuildingvalueActual.Enabled = true;
                    txtPlantvalueActual.Enabled = true;

                    txtlandvalue.Enabled = true;
                    txtbuildingvalue.Enabled = true;
                    txtPlantvalue.Enabled = true;

                    TxtVal_LandExpansion.Enabled = true;
                    TxtVal_PlantExpanstion.Enabled = true;
                    TxtVal_BuildExpanstion.Enabled = true;

                    TxtVal_Land_ActualExpansion.Enabled = true;
                    TxtVal_Plant_ActualExpansion.Enabled = true;
                    TxtVal_Build_ActualExpn.Enabled = true;

                }
                if (dscheck.Tables[0].Rows[0]["CurrencyType"].ToString() != "")
                {
                    ddlcurrencytype.Enabled = false;
                }
                else
                {
                    ddlcurrencytype.Enabled = true;
                }
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
                if (CFESTATUS == 1)
                {
                    txtcfeuidno.Enabled = false;
                    ddlSector.Enabled = false;
                    ddlProp_intDistrictid.Enabled = false;
                    ddlProp_intMandalid.Enabled = false;
                    ddlProp_intVillageid.Enabled = false;
                    ddlcurrencytype.Enabled = false;
                    ddlproposal.Enabled = false;
                    txtNameOfIndustrialUndertaking.Enabled = false;
                    ddlintLineofActivity.Enabled = true;

                }
                else
                {
                    txtcfeuidno.Enabled = true;
                    ddlSector.Enabled = true;
                    ddlProp_intDistrictid.Enabled = true;
                    ddlProp_intMandalid.Enabled = true;
                    ddlProp_intVillageid.Enabled = true;
                    ddlcurrencytype.Enabled = true;
                    ddlproposal.Enabled = true;
                    txtNameOfIndustrialUndertaking.Enabled = true;
                    ddlintLineofActivity.Enabled = true;
                }
                txtcfeuidno.Text = dscheck.Tables[0].Rows[0]["CFE_UID_NO"].ToString();
               // txtcfeuidno.Enabled = false;

                if (dscheck.Tables[0].Rows[0]["Sector_Ent"].ToString().Trim() != "")
                {
                    ddlSector.SelectedValue = ddlSector.Items.FindByValue(dscheck.Tables[0].Rows[0]["Sector_Ent"].ToString().Trim()).Value;
                 //   ddlSector.Enabled = false;
                }
                //ddlSector.SelectedValue = ddlSector.Items.FindByValue(dscheck.Tables[0].Rows[0]["Sector_Ent"].ToString().Trim()).Value;

                ddlProp_intDistrictid.SelectedValue = dscheck.Tables[0].Rows[0]["Prop_intDistrictid"].ToString().Trim();
               // ddlProp_intDistrictid.Enabled = false;
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
               // ddlProp_intMandalid.Enabled = false;
                if (ddlProp_intMandalid.SelectedIndex == 0)
                {

                    ddlProp_intVillageid.Items.Clear();
                    ddlProp_intVillageid.Items.Insert(0, "--Village--");
                }
                else
                {
                    //ddlProp_intVillageid.Items.Clear();
                    //DataSet dsv = new DataSet();
                    //dsv = Gen.GetVillages(ddlProp_intMandalid.SelectedValue);
                    //if (dsv.Tables[0].Rows.Count > 0)
                    //{
                    //    ddlProp_intVillageid.DataSource = dsv.Tables[0];
                    //    ddlProp_intVillageid.DataValueField = "Village_Id";
                    //    ddlProp_intVillageid.DataTextField = "Village_Name";
                    //    ddlProp_intVillageid.DataBind();
                    //    ddlProp_intVillageid.Items.Insert(0, "--Village--");
                    //}
                    //else
                    //{
                    //    ddlProp_intVillageid.Items.Clear();
                    //    ddlProp_intVillageid.Items.Insert(0, "--Village--");
                    //}
                    if (HDNAPPLNSTATUS.Value == "3" && DateTime.ParseExact(HDNDATEOFPAYMENT.Value, "dd-MM-yyyy", CultureInfo.InvariantCulture) <= DateTime.ParseExact("06-12-2025", "dd-MM-yyyy", CultureInfo.InvariantCulture))
                    {
                        ddlProp_intVillageid.Items.Clear();
                        DataSet dsv = new DataSet();
                        dsv = Gen.GetVillagesWithGHMC(ddlProp_intMandalid.SelectedValue);
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
                try
                {
                    ddlProp_intVillageid.SelectedValue = ddlProp_intVillageid.Items.FindByValue(dscheck.Tables[0].Rows[0]["Prop_intVillageid"].ToString().Trim()).Value;
                  //  ddlProp_intVillageid.Enabled = false;
                }
                catch (Exception ex)
                {
                    ddlProp_intVillageid.Enabled = true;
                }
                if (dscheck.Tables[0].Rows[0]["CurrencyType"].ToString() != "")
                {
                   // ddlcurrencytype.Enabled = false;
                    ddlcurrencytype.SelectedValue = ddlcurrencytype.Items.FindByText(dscheck.Tables[0].Rows[0]["CurrencyType"].ToString().Trim()).Value;
                }
                if (dscheck.Tables[0].Rows[0]["ProposalForQue"].ToString() != "")
                {
                    ddlproposal.SelectedValue = ddlproposal.Items.FindByText(dscheck.Tables[0].Rows[0]["ProposalForQue"].ToString().Trim()).Value;
                   // ddlproposal.Enabled = false;
                    ddlproposal_SelectedIndexChanged(this, EventArgs.Empty);
                }
                else
                {
                    ddlproposal.SelectedValue = "1";
                    ddlproposal_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (dscheck.Tables[0].Rows[0]["High_Tension_Meter"].ToString().Trim() != "")
                {
                    RdpIndustry.SelectedValue = RdpIndustry.Items.FindByValue(dscheck.Tables[0].Rows[0]["High_Tension_Meter"].ToString().Trim()).Value;
                }
                if (dscheck.Tables[0].Rows[0]["License_Factory"].ToString().Trim() != "")
                {
                    RdpFactory.SelectedValue = RdpFactory.Items.FindByValue(dscheck.Tables[0].Rows[0]["License_Factory"].ToString().Trim()).Value;
                }
                if (dscheck.Tables[0].Rows[0]["Product_Drugs"].ToString().Trim() != "")
                {
                    RdpDrugs.SelectedValue = RdpDrugs.Items.FindByValue(dscheck.Tables[0].Rows[0]["Product_Drugs"].ToString().Trim()).Value;
                }

                if (dscheck.Tables[0].Rows[0]["Bioler_Industry"].ToString().Trim() != "")
                {
                    RdpBoiler.SelectedValue = RdpBoiler.Items.FindByValue(dscheck.Tables[0].Rows[0]["Bioler_Industry"].ToString().Trim()).Value;
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
               // txtNameOfIndustrialUndertaking.Enabled = false;
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
                //ddlintLineofActivity.Enabled = false;

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
                if (dscheck.Tables[0].Rows[0]["HaveyourTakePolution"].ToString().Trim() != "")
                {
                    rbtnLstLabel.SelectedValue = rbtnLstLabel.Items.FindByValue(dscheck.Tables[0].Rows[0]["LabelConfirmation"].ToString().Trim()).Value;
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

               
                if (dscheck.Tables[0].Rows[0]["SteamPipeline"].ToString().Trim() != "")
                {
                    rbtnLstBoilerSteamPipeline.SelectedValue = RdpBoiler.Items.FindByValue(dscheck.Tables[0].Rows[0]["SteamPipeline"].ToString().Trim()).Value;
                }

                if (dscheck.Tables[0].Rows[0]["BiolerManufactuer_Industry"].ToString().Trim() != "")
                {
                    RdpBoilermanu.SelectedValue = RdpBoilermanu.Items.FindByValue(dscheck.Tables[0].Rows[0]["BiolerManufactuer_Industry"].ToString().Trim()).Value;
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

                for (int j = 0; j < grd_dynamic.Rows.Count; j++)
                {

                    TextBox txt_seatcapcity = grd_dynamic.Rows[j].FindControl("txt_seatcapcity") as TextBox;
                    TextBox txt_screenfee = grd_dynamic.Rows[j].FindControl("txt_screenfee") as TextBox;
                    TextBox txt_totscreenfee = grd_dynamic.Rows[j].FindControl("txt_totscreenfee") as TextBox;
                    try
                    {
                        Screendetails fromvo = new Screendetails();
                        fromvo.ScreenNO = "Screen_" + j + 1;
                        fromvo.SeatCapacity = txt_seatcapcity.Text;
                        fromvo.ScreenFee = txt_screenfee.Text;
                        fromvo.TotalFee = txt_totscreenfee.Text;
                        fromvo.Created_By = Session["uid"].ToString();
                        lstscreendetails.Add(fromvo);
                    }
                    catch (Exception ex)
                    {

                    }
                }
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
                //if (RdbExecptedact1.SelectedValue == "N" && rdpPOLRDP.SelectedValue == "N" && RdpFactory.SelectedValue == "N" && RdpIndustry.SelectedValue == "N" && RdpBuildingHeight.SelectedValue == "N" && RdpDrugs.SelectedValue == "N" && RdpBoiler.SelectedValue == "N")
                //{
                //    success.Visible = false;
                //    Failure.Visible = true;
                //    lblmsg0.Text = "Please Select Atleast One Department";
                //    return;

                //}
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
                //string[] newdate = txtDateofCommenceAct1.Text.ToString().Split('-');
                //string date = newdate[1].ToString() + "/" + newdate[0].ToString() + "/" + newdate[2].ToString();
                //quesionervoobj.txtDateofCommenceAct1 = date;

                if (txtDateofCommenceAct1.Text == "")
                {
                    quesionervoobj.txtDateofCommenceAct1 = null;
                }
                else
                {
                    string[] newdate = txtDateofCommenceAct1.Text.ToString().Split('-');
                    string date = newdate[1].ToString() + "/" + newdate[0].ToString() + "/" + newdate[2].ToString();
                    quesionervoobj.txtDateofCommenceAct1 = date;
                }
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
                if (rbtcontractlabouract.SelectedValue == "Y")
                {
                    if (quesionervoobj.LabourActID == "")
                        quesionervoobj.LabourActID = "5";
                    else
                        quesionervoobj.LabourActID += "," + "5";
                }
                quesionervoobj.LabelConfirmation = rbtnLstLabel.SelectedValue;
                quesionervoobj.SteamPipeline = rbtnLstBoilerSteamPipeline.SelectedValue;
                quesionervoobj.BoilerManufactuer = RdpBoilermanu.SelectedValue;
                quesionervoobj.Occupancyflag = RDOC.SelectedValue;

                quesionervoobj.BPFilenumber = txtfilenumber.Text;
                quesionervoobj.FDC = rbtfdclicense.SelectedValue;
                quesionervoobj.Trade_License = rbttradelicense.SelectedValue;

                quesionervoobj.TourismFlag = "";
                int i = Gen.insertCFOQuestionerrie(Session["Applid"].ToString(), ddlSector.SelectedValue.ToString(), ddlProp_intDistrictid.SelectedValue.ToString(),
                    ddlProp_intMandalid.SelectedValue.ToString(), ddlProp_intVillageid.SelectedValue.ToString(), txtlandvalue.Text, txtbuildingvalue.Text, txtPlantvalue.Text,
                    txttotal.Text, rdpPOLRDP.SelectedValue.ToString(), ddlintLineofActivity.SelectedValue.ToString(), HdfLblPol_Category.Value, RdpFactory.SelectedValue.ToString(),
                    RdpIndustry.SelectedValue.ToString(), RdpBuildingHeight.SelectedValue.ToString(), RdpNOC.SelectedValue.ToString(), RdpDrugs.SelectedValue.ToString(),
                    RdpBoiler.SelectedValue.ToString(), Session["uid"].ToString(), txtNameOfIndustrialUndertaking.Text, HdfLblEnt_is.Value, "2", RdpDrugs0.SelectedValue.ToString(), RdpService.SelectedValue.ToString()
                    , txtlandvalueActul.Text.Trim(), txtbuildingvalueActual.Text.Trim(), txtPlantvalueActual.Text.Trim(), ddlcurrencytype.SelectedItem.Text, quesionervoobj, txtcfeuidno.Text,
                    rbtcinemalicense.SelectedValue, ddllicenseperiod.SelectedValue,
                    txtnoofscreensoftheatre.Text, txtapprovalfeecinemalicense.Text, lstscreendetails);

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


    protected void BtnClear_Click(object sender, EventArgs e)
    {
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
                //DataSet dsvillage = Gen.GetUnderLimitsOfVillage(ddlProp_intVillageid.SelectedValue);
                //string Hmwssbflg = "";
                //if (dsvillage.Tables[0].Rows.Count > 0)//added Madhuri
                //{
                //    Hmwssbflg = dsvillage.Tables[0].Rows[0]["Hmwssb_Flg"].ToString();
                //    if (Hmwssbflg == "Y")
                //    {
                //        trhmwssb.Visible = true;
                //    }
                //    else
                //    {
                //        trhmwssb.Visible = false;
                //    }
                //}

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
                //ddlProp_intVillageid.Items.Clear();
                //DataSet dsv = new DataSet();
                //dsv = Gen.GetVillages(ddlProp_intMandalid.SelectedValue);
                //if (dsv.Tables[0].Rows.Count > 0)
                //{
                //    ddlProp_intVillageid.DataSource = dsv.Tables[0];
                //    ddlProp_intVillageid.DataValueField = "Village_Id";
                //    ddlProp_intVillageid.DataTextField = "Village_Name";
                //    ddlProp_intVillageid.DataBind();
                //    ddlProp_intVillageid.Items.Insert(0, "--Village--");
                //}
                //else
                //{
                //    ddlProp_intVillageid.Items.Clear();
                //    ddlProp_intVillageid.Items.Insert(0, "--Village--");
                //}
                if (HDNAPPLNSTATUS.Value == "3" && DateTime.ParseExact(HDNDATEOFPAYMENT.Value, "dd-MM-yyyy", CultureInfo.InvariantCulture) <= DateTime.ParseExact("06-12-2025", "dd-MM-yyyy", CultureInfo.InvariantCulture))
                {
                    ddlProp_intVillageid.Items.Clear();
                    DataSet dsv = new DataSet();
                    dsv = Gen.GetVillagesWithGHMC(ddlProp_intMandalid.SelectedValue);
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
                RdpNOC.SelectedValue = "N";
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
            if (RdpBuildingHeight.SelectedValue == "Y")
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
            if (trhmdatsiicfileno.Visible == true)
            {
                if (txtfilenumber.Text == "" || txtfilenumber.Text == null)
                {
                    success.Visible = false;
                    Failure.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "alert('Please enter File Number');", true);
                    return;
                }
            }


            if (rdpPOLRDP.SelectedValue == "N" && RdpFactory.SelectedValue == "N" && RdpIndustry.SelectedValue == "N" && RdpNOC.SelectedValue == "N" && RdpDrugs.SelectedValue == "N" && RdpBoiler.SelectedValue == "N")
            {
                lblNOC0.Visible = true;
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


            if (RdpNOC.SelectedValue.ToString() == "Y")
            {
                dsv1 = Gen.GetShowApprovalandFees("18", "%");
                dsv.Tables[0].Merge(dsv1.Tables[0]);


            }
            if (Session["uid"].ToString() == "17083")
            {
                if (rdbLblRegistration.SelectedValue == "Y")
                {
                    dsv1 = Gen.GetShowApprovalandFees("141", "%");
                    dsv.Tables[0].Merge(dsv1.Tables[0]);
                }
                if (rdbExportLic.SelectedValue == "Y")
                {
                    dsv1 = Gen.GetShowApprovalandFees("142", "%");
                    dsv.Tables[0].Merge(dsv1.Tables[0]);
                }

                if (rdbBrandRegn.SelectedValue == "Y")
                {
                    dsv1 = Gen.GetShowApprovalandFees("143", "%");
                    dsv.Tables[0].Merge(dsv1.Tables[0]);
                }
            }
            if (rbtcinemalicense.SelectedValue == "Y")
            {
                dsv1 = Gen.GetShowApprovalandFees_cinemalicense("90", "%", txtapprovalfeecinemalicense.Text, Session["Applid"].ToString());
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
            if (ddlproposal.SelectedValue.ToString() == "1")
                dsv4 = Gen.GetShowApprovalandFeesEnterPriseAmount("33", Enterpriseid, txtPlantvalue.Text, txttotal.Text, "0");
            if (ddlproposal.SelectedValue.ToString() == "2")  //changed on 10.12.2018.. 
                dsv4 = Gen.GetShowApprovalandFeesEnterPriseAmount("33", Enterpriseid, txtPlantvalue.Text, txtlbltotalprojectcostexpanstion.Text, "0");

            dsv.Tables[0].Merge(dsv4.Tables[0]);

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
                    labourservicevo.Approvalid = "52";
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
            //madhuri 23.11.2020
            DataSet dsboilermanufacture = new DataSet();
            if (RdpBoilermanu.SelectedValue == "Y")
            {
                dsboilermanufacture = Gen.GetShowApprovalandFees("103", "%");
                dsv.Tables[0].Merge(dsboilermanufacture.Tables[0]);
            }

            DataSet dsLabour3 = new DataSet();
            if (rbtcontractlabouract.SelectedValue == "Y")
            {
                //dsLabour3 = Gen.GetShowApprovalandFeesLabour("144", Enterpriseid, ddlProp_intDistrictid.SelectedValue, "5", txtnoofworkderscontractor.Text.Trim().TrimStart());
                //dsv.Tables[0].Merge(dsLabour3.Tables[0]);
                string[] newdate = txtcommencementdatecontractor.Text.ToString().Split('-');
                string date = newdate[0].ToString() + "/" + newdate[1].ToString() + "/" + newdate[2].ToString();
                string date1 = newdate[1].ToString() + "/" + newdate[0].ToString() + "/" + newdate[2].ToString();
                int empcount = Convert.ToInt32(txtnoofworkderscontractor.Text.Trim());
                //LabourCFOTest.actsResponse feeout = new LabourCFOTest.actsResponse();
                string output = labourcfo.feeDetails(empcount, date, "CCF");
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
                    labourservicevo.Approvalid = "144";
                    string valid = InsertLabourShopServiceDetails(labourservicevo, output);
                }
                dsLabour2 = Gen.GetShowApprovalandFeesLabouract1("144", Enterpriseid, ddlProp_intDistrictid.SelectedValue, "1", txtnoofworkderscontractor.Text.Trim().TrimStart(), date1, Session["uid"].ToString().Trim());
                dsv.Tables[0].Merge(dsLabour2.Tables[0]);
            }
            DataSet dsvtrade = new DataSet();
            if (rbttradelicense.SelectedValue == "Y")
            {
                dsvtrade = Gen.GetShowApprovalandFees_Tradelicence("Y", ddlProp_intVillageid.SelectedValue);
                dsv.Tables[0].Merge(dsvtrade.Tables[0]);
            }
            if (rbtfdclicense.SelectedValue.ToString() == "Y")
            {
                dsv1 = Gen.GetShowApprovalandFees("140", "%");
                dsv.Tables[0].Merge(dsv1.Tables[0]);
            }
            if (rblIrrgConn.SelectedValue == "Y" && txtirrCFEUID.Text.Trim() != "")
            {
                dsv1 = Gen.GetShowApprovalandFees("171", "%");
                dsv.Tables[0].Merge(dsv1.Tables[0]);
                //DataTable dtirrigation = new DataTable();
                //dtirrigation.Columns.Add("ApprovalName", typeof(string));
                //dtirrigation.Columns.Add("Dept_Full_name", typeof(string));
                //dtirrigation.Columns.Add("Fees", typeof(Decimal));
                //dtirrigation.Columns.Add("ApprovalId", typeof(int));
                //dtirrigation.Columns.Add("Dept_Id", typeof(int));


                //// Adding rows to DataTable
                //dtirrigation.Rows.Add("Permission to draw water from river/public tanks (Irrigation Department)", "Irrigation Department", hdnIrrgAmount.Value, 171, 20);
                //if (dtirrigation.Rows.Count > 0)
                //{ dsv.Tables[0].Merge(dtirrigation); }


            }
            if (rblTransitPrmsn.SelectedValue == "Y")
            {
                dsv1 = Gen.GetShowApprovalandFees("172", "%");
                dsv.Tables[0].Merge(dsv1.Tables[0]);

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
            DataSet dsvillage = Gen.GetUnderLimitsOfVillage(ddlProp_intVillageid.SelectedValue);
            string Hmwssbflg = "";
            if (dsvillage.Tables[0].Rows.Count > 0)//added Madhuri
            {
                Hmwssbflg = dsvillage.Tables[0].Rows[0]["Hmwssb_Flg"].ToString();
                if (Hmwssbflg == "Y")
                {
                    trhmwssb.Visible = true;
                }
                else
                {
                    trhmwssb.Visible = false;
                }
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

        if (ddlintLineofActivity.SelectedItem.Text == "--Select--")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Line of activity')", true);
            ddlintLineofActivity.Enabled = true;
            return;


        }
        else
        {
            Tab2.Attributes.Add("class", "active");
            Tab1.Attributes.Add("class", "");
            Tab3.Attributes.Add("class", "");
            MainView.ActiveViewIndex = 1;
        }

        
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
        //if (txtlandvalueActul.Text == "" || txtlandvalueActul.Text == null)
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter Land Value..!');", true);

        //}
        if (HdfLblPol_Category.Value == "White")
        {
            rdpPOLRDP.SelectedValue = "N";

        }
        Tab2.Attributes.Add("class", "");
        Tab1.Attributes.Add("class", "");
        Tab3.Attributes.Add("class", "active");
        MainView.ActiveViewIndex = 2;
    }
    protected void rdpPOLRDP_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (HdfLblPol_Category.Value == "White")
        {
            rdpPOLRDP.SelectedValue = "N";
            //rdpPOLRDP.Enabled = false();
        }
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
                txtNoofworkers.Text = "";
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
            com.Parameters.AddWithValue("@Approvalid", objvo1.Approvalid);
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

    protected void rbtcontractlabouract_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rbtcontractlabouract.SelectedValue == "Y")
            {
                tr2.Visible = true;
                tr3.Visible = true;
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void rbtcinemalicense_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtcinemalicense.SelectedValue == "Y")
        {
            trtotalfee.Visible = true;
            trlicenseperiod.Visible = true;
            trnoofscreen.Visible = true;
        }
        else
        {
            trtotalfee.Visible = false;
            trlicenseperiod.Visible = false;
            trnoofscreen.Visible = false;
        }
    }

    protected void txtnoofscreensoftheatre_TextChanged(object sender, EventArgs e)
    {
        dynamicgridbind();
    }

    public void dynamicgridbind()
    {
        int count = Convert.ToInt32(txtnoofscreensoftheatre.Text);
        if (count > 0)
        {
            DataTable dtmain = new DataTable();
            dtmain.Columns.Add("number");
            for (int i = 0; i < count; i++)
            {
                DataRow drs = dtmain.NewRow();
                drs["number"] = "Screen-" + (i + 1);
                dtmain.Rows.Add(drs);
            }
            DataSet dsmain = new DataSet();
            dsmain.Tables.Add(dtmain);

            grd_dynamic.DataSource = dsmain;
            grd_dynamic.DataBind();
        }
    }

    protected void txt_seatcapcity_TextChanged(object sender, EventArgs e)
    {
        TextBox lnk_view = (TextBox)sender;
        GridViewRow gvRow = (GridViewRow)lnk_view.Parent.Parent;

        TextBox txt_seatcapcity = (TextBox)gvRow.FindControl("txt_seatcapcity");
        TextBox txt_screenfee = (TextBox)gvRow.FindControl("txt_screenfee");
        TextBox txt_totscreenfee = (TextBox)gvRow.FindControl("txt_totscreenfee");
        if (ddllicenseperiod.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please select License Period..!');", true);
        }
        else
        {
            if (!string.IsNullOrEmpty(txt_seatcapcity.Text))
            {
                int Capcity = Convert.ToInt32(txt_seatcapcity.Text);
                decimal fee;
                if (Capcity <= 500)
                {
                    fee = 500;
                    decimal screenfee = fee * Convert.ToDecimal(ddllicenseperiod.SelectedValue);
                    txt_screenfee.Text = Convert.ToString(fee);
                    txt_totscreenfee.Text = Convert.ToString(screenfee);
                }
                if (Capcity > 500)
                {
                    fee = 1000;
                    decimal screenfee = fee * Convert.ToDecimal(ddllicenseperiod.SelectedValue);
                    txt_screenfee.Text = Convert.ToString(fee);
                    txt_totscreenfee.Text = Convert.ToString(screenfee);
                }



            }
        }

        totalfeeofseatcapcity();
    }


    void totalfeeofseatcapcity()
    {
        decimal conttot = 0;
        if (grd_dynamic.Rows.Count > 0)
        {
            for (int i = 0; i < grd_dynamic.Rows.Count; i++)
            {
                TextBox txt_totscreenfee = grd_dynamic.Rows[i].FindControl("txt_totscreenfee") as TextBox;
                decimal testcount = 0;

                if (!string.IsNullOrEmpty(txt_totscreenfee.Text))
                {
                    testcount = Convert.ToDecimal(txt_totscreenfee.Text);
                }
                conttot = conttot + testcount;
            }
        }
        txtapprovalfeecinemalicense.Text = Convert.ToString(conttot);
    }
    protected void txtNameOfIndustrialUndertaking_TextChanged(object sender, EventArgs e)
    {
        if (txtNameOfIndustrialUndertaking.Text.Contains("poultry") || txtNameOfIndustrialUndertaking.Text.Contains("POULTRY") || txtNameOfIndustrialUndertaking.Text.Contains("Poultr"))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Attention-Approvals for all types of Poultry Farms and Poultry Feed units will not be processed under TS-iPASS. f applied with other line of activity the application will be rejected by the concerned department and fee paid will not be refunded.');", true);

            ddlProp_intDistrictid.Enabled = false;
            ddlProp_intMandalid.Enabled = false;
            ddlProp_intVillageid.Enabled = false;
            ddlintLineofActivity.Enabled = false;
            ddlSector.Enabled = false;
            btntab1next.Enabled = false;
        }
        else
        {
            ddlProp_intDistrictid.Enabled = true;
            ddlProp_intMandalid.Enabled = true;
            ddlProp_intVillageid.Enabled = true;
            ddlintLineofActivity.Enabled = true;
            ddlSector.Enabled = true;
            btntab1next.Enabled = true;
        }

    }

    protected void rdhmwssb_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rdhmwssb.SelectedValue == "Y")
            {
                trhmwssbfileno.Visible = true;
            }
            else
            {
                trhmwssbfileno.Visible = false;
            }
        }
        catch (Exception ex)
        { }
    }
    protected void rblIrrgConn_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblIrrgConn.SelectedValue == "Y")
            {
                trIrrigation.Visible = true;
            }
            else
            {
                trIrrigation.Visible = false;
            }
        }
        catch (Exception ex)
        { }

    }

    protected void txtirrCFEUID_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtirrCFEUID.Text.Trim() != "")
            {


                DataSet dsirr = new DataSet();
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter("usp_getIrrigationApprovalDate", connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@CFEUID", txtirrCFEUID.Text.Trim());
                da.Fill(dsirr);

                if (dsirr.Tables.Count > 0 && dsirr.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(dsirr.Tables[0].Rows[0]["Approval_Date"]) != "")
                    {
                        if (Convert.ToDateTime(Convert.ToString(dsirr.Tables[0].Rows[0]["Approval_Date"])) < System.DateTime.Now.AddYears(-1))
                            hdnIrrgAmount.Value = "10000";
                        else
                            hdnIrrgAmount.Value = "0";

                    }
                }

            }
            else
            {
                Failure.Visible = false;
                lblmsg0.Text = hmdapplicationresponse.ErrorMessage;
            }
        }
        catch (Exception ex)
        { }
    }
}
