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
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    CommonBL objcommon = new CommonBL();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    decimal TotalFee = Convert.ToDecimal("0");
    DataSet oDataSet;
    LabourCFOService.TSLabourServiceImplService labourcfo = new LabourCFOService.TSLabourServiceImplService();
    LabourShopServiceVo labourservicevo = new LabourShopServiceVo();
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);

    Cls_nswswebapiafterpayment objnswsdata = new Cls_nswswebapiafterpayment();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DataSet dscheck = new DataSet();
            if (Session.Count <= 0)
            {
                Response.Redirect("../../Index.aspx");
            }
            if (hdnUserID.Value == "")
            {
                hdnUserID.Value = Session["uid"].ToString().Trim();
                // LogErrorFile.LogData(Convert.ToString( "IN QUESTIONNEIRE REG 1 PAGE USER ID as: " + Session["uid"].ToString().Trim();));
            }
            else
            {
                string Valid = objcommon.ValidateUser(hdnUserID.Value, Session["uid"].ToString().Trim());
                if (Valid == "1")
                {
                    Session.RemoveAll();
                    Session.Clear();
                    Session.Abandon();
                    Response.Redirect("~/tshome.aspx");
                }
            }
            if (!IsPostBack)
            {
                //insert into nsws data to cfe quessinere,enterprenur,land details tables
                if (Convert.ToString(Session["RedirectfromNSWSURL"]) == "Y")
                {
                    objnswsdata.DB_insertnswscafdatacfedata(Convert.ToString(Session["uid"]).Trim());
                }

                int count = 0;
                if (rdo_borewell.SelectedValue == "Y")
                {
                    count = 4;
                }
                else
                {
                    count = 5;
                }
                gvmodelsnames.DataSource = BindModelsData(Convert.ToInt32(count));
                gvmodelsnames.DataBind();
                DataTable dt = new DataTable();
                dt = BindBasicMethod();
                foreach (GridViewRow gvrTEMPVehMstr in gvmodelsnames.Rows)
                {
                    Label txtMakerGvV = (Label)gvrTEMPVehMstr.FindControl("lblModelname");
                    txtMakerGvV.Text = dt.Rows[gvrTEMPVehMstr.RowIndex]["Name"].ToString();
                }
                MainView.ActiveViewIndex = 0;

                Label7.Visible = false;
                RdPol_Indus.Visible = false;
                TxtBuilt_up_Area.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                TxtHight_Build.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                txtmarketvalue.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");

                dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
                if (dscheck.Tables[0].Rows.Count > 0)
                {
                    Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();

                }
                else
                {
                    Session["Applid"] = "0";
                }
                if (dscheck.Tables[6].Rows.Count > 0)
                {
                    HDNDATEOFPAYMENT.Value = dscheck.Tables[6].Rows[0]["PAYMENTDATE"].ToString().Trim();
                    HDNCESSAPPROVED.Value = dscheck.Tables[6].Rows[0]["CESSAPPROVED"].ToString().Trim();
                    HDNCESSQUESTIONNAIREID.Value = dscheck.Tables[6].Rows[0]["CESSQUESTIONNAIREID"].ToString().Trim();
                }
                BindConstitutionunit();
                BindenterpriseSectors();
                BindDistricts();
                BindLineofActivityName();
                BindHPPowerddl();
                Bindmesurments();
                BinCurrencyType();
                BindRegulations(ddlregulation);
                BindPlant(ddlplant);
                BindVoltage(ddlvoltage);
                rdo_borewell_SelectedIndexChanged(sender, e);
                DataSet dsver = new DataSet();
                dsver = Gen.Getverifyofque9(Session["Applid"].ToString());
                if (dsver != null && dsver.Tables.Count > 0 && dsver.Tables[0].Rows.Count > 0)
                {
                    // string res = Gen.RetriveStatus(Session["Applid"].ToString()); Commented By CMS
                    string res = dsver.Tables[0].Rows[0]["Appl_Status"].ToString();
                    HDNAPPLNSTATUS.Value = res.ToString();

                    hdres.Value = res.ToString();
                    ////string res = Gen.RetriveStatus("1002");
                    if (res == "3" || Convert.ToInt32(res) >= 3)
                    {
                        ResetFormControl(this);

                        if (TxtTot_ExtentNew.Text.Trim().TrimStart() == "")
                        {
                            ddllandmesurements.Enabled = true;
                            TxtTot_ExtentNew.ReadOnly = false;
                            txtgunthas.ReadOnly = false;
                        }
                        if (ddlproposal.SelectedValue == "0")
                        {
                            ddlproposal.Enabled = true;
                        }
                        if (ddlcurrencytype.SelectedValue == "0")
                        {
                            ddlcurrencytype.Enabled = true;
                            TxtVal_Land_Actual.ReadOnly = false;
                            TxtVal_Land_ActualExpansion.ReadOnly = false;
                            txtmarketvalue.ReadOnly = false;
                            TxtVal_Build_Actual.ReadOnly = false;
                            TxtVal_Build_ActualExpn.ReadOnly = false;
                            TxtVal_Plant_Actual.ReadOnly = false;
                            TxtVal_Plant_ActualExpansion.ReadOnly = false;
                        }

                        BtnClear.Visible = false;
                        BtnSave.Visible = false;
                        BtnSave1.Visible = false;
                        ChkWater_reg_from.Enabled = false;

                        //ChkLabour_Application.Enabled = false;
                    }
                }


                // BindLabourApplication();

                Session["Applid"] = "0";

                ddlLoc_of_unit.Items.Clear();
                AddSelect(ddlLoc_of_unit);
                //ddlLoc_of_unit.Items.Insert(0, "--Select--");
                //BtnSave.Visible = false; commented by madhuri on 15/12/2022
                fillDetails(dscheck);
                // CalcFees();
                dsver = Gen.Getverifyofque9(Session["Applid"].ToString());
                if (dsver != null && dsver.Tables.Count > 0 && dsver.Tables[0].Rows.Count > 0)
                {
                    // string res = Gen.RetriveStatus(Session["Applid"].ToString()); Commented By CMS
                    string res = dsver.Tables[0].Rows[0]["Appl_Status"].ToString();
                    hdres.Value = res.ToString();
                    ////string res = Gen.RetriveStatus("1002");
                    if (res == "3" || Convert.ToInt32(res) >= 3)
                    {
                        ResetFormControl(this);

                        if (TxtTot_ExtentNew.Text.Trim().TrimStart() == "")
                        {
                            ddllandmesurements.Enabled = true;
                            TxtTot_ExtentNew.ReadOnly = false;
                            txtgunthas.ReadOnly = false;
                        }
                        if (ddlproposal.SelectedValue == "0")
                        {
                            ddlproposal.Enabled = true;
                        }
                        if (ddlcurrencytype.SelectedValue == "0")
                        {
                            ddlcurrencytype.Enabled = true;
                            TxtVal_Land_Actual.ReadOnly = false;
                            TxtVal_Land_ActualExpansion.ReadOnly = false;
                            txtmarketvalue.ReadOnly = false;
                            TxtVal_Build_Actual.ReadOnly = false;
                            TxtVal_Build_ActualExpn.ReadOnly = false;
                            TxtVal_Plant_Actual.ReadOnly = false;
                            TxtVal_Plant_ActualExpansion.ReadOnly = false;
                        }

                        BtnClear.Visible = false;
                        BtnSave.Visible = false;
                        BtnSave1.Visible = false;
                        ChkWater_reg_from.Enabled = false;

                        //ChkLabour_Application.Enabled = false;
                    }
                }
                hdnfocus.Value = TxtnameofUnit.ClientID;
                if (hdres.Value == "3")
                {

                    if (RdpIndustry.SelectedValue == "N")
                    {
                        RdpIndustry.Enabled = true;
                        ddlregulation.Enabled = true;
                        ddlvoltage.Enabled = true;
                        txtagrcapacity.Enabled = true;
                        txtagrcapacity.ReadOnly = false;
                        BtnSave1.Enabled = true;
                        BtnSave.Enabled = true;

                        BtnSave1.Visible = true;
                        BtnSave.Visible = true;
                    }
                    else
                    {
                        txtagrcapacity.ReadOnly = true;
                        txtagrcapacity.Enabled = false;
                        ddlvoltage.Enabled = false;
                        ddlregulation.Enabled = false;
                        txtagrcapacity.Enabled = false;
                        RdpIndustry.Enabled = false;
                        BtnSave1.Enabled = false;
                        BtnSave.Enabled = false;

                        BtnSave1.Visible = false;
                        BtnSave.Visible = false;
                    }
                }
            }

            if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
            {

            }

            if (txtmarketvalue.Text.Trim().TrimStart() == "")
            {
                txtmarketvalue.ReadOnly = false;
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
    public DataTable BindBasicMethod()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Name", typeof(string));

        DataRow dr = dt.NewRow();
        dr["Name"] = "New Bore well";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["Name"] = "HMWS & SB";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["Name"] = "Rivers/Canals";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["Name"] = "CDMA";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["Name"] = "Mission Bhagiratha";
        dt.Rows.Add(dr);

        return dt;
    }
    protected void fnSetNewControls_Click(object sender, EventArgs e)
    {
        Response.Write("<script>alert('test')</script>");
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
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
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
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
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
                // ddlAppl_Type.Items.Clear();
                AddSelect(ddlAppl_Type);
            }

            if (rdIaLa_Lst.SelectedValue == "Y" && (Loc_of_unit == 1 || Loc_of_unit == 3 || Loc_of_unit == 5))
            {
                ddlAppl_Type.Items.Remove(ddlAppl_Type.Items.FindByValue("1"));
                ddlAppl_Type.Items.Remove(ddlAppl_Type.Items.FindByValue("3"));

                ddlAppl_Type.SelectedValue = "2";
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
            // dsd = Gen.GetDistrictsWithoutHYD();
            dsd = obj_newdistrictwargnal.GetallDistrictswithoutWarangal(Convert.ToString(Session["uid"]), "CFE");
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
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
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
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
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
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
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
                //ddlcurrencytype.Enabled = false;
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
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
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
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
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
                            //if (((DropDownList)c).Items.Count > 0)
                            //{
                            ((DropDownList)c).Enabled = false;
                            // }
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
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    public void fillDetails(DataSet dscheck)
    {
        try
        {
            //DataSet dscheck = new DataSet();  Commented by CMS
            //dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());   Commented by CMS
            if (dscheck.Tables[0].Rows.Count > 0)
            {
                //if (dscheck.Tables[0].Rows[0]["LabelConfirmation"].ToString() != "")
                //    rbtnLstLabel.SelectedValue = rbtnLstLabel.Items.FindByValue(dscheck.Tables[0].Rows[0]["LabelConfirmation"].ToString().Trim()).Value;
                if (dscheck.Tables[0].Rows[0]["Created_dt"].ToString() != "")
                {
                    if (Convert.ToDateTime(dscheck.Tables[0].Rows[0]["Created_dt"].ToString()) > Convert.ToDateTime("06/03/2017"))
                    {
                        hdfFapplicationdate.Value = "Y";
                    }
                    else
                    {
                        hdfFapplicationdate.Value = "N";
                    }
                }
                else
                {
                    hdfFapplicationdate.Value = "N";
                }
                SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
                DataSet oDataSet = new DataSet();
                string gmID = Session["uid"].ToString();
                osqlConnection.Open();
                oSqlDataAdapter = new SqlDataAdapter("GETcheckInsertCFOCFE", osqlConnection);
                oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                oSqlDataAdapter.SelectCommand.Parameters.Add("@createdBy", SqlDbType.VarChar).Value = Session["uid"].ToString().Trim();
                oDataSet = new DataSet();
                oSqlDataAdapter.Fill(oDataSet);

                txtCFEUID.Text = oDataSet.Tables[0].Rows[0]["PreviousCFEUID"].ToString();
                txtCFOUID.Text = oDataSet.Tables[0].Rows[0]["PreviousCFOUID"].ToString();
                txtCFEUID.Enabled = false;
                txtCFOUID.Enabled = false;
                //if (Session["uid"].ToString() == "11007")
                //{
                //    ddlproposal.Enabled = true;
                //}
                //else
                //{

                //    ddlproposal.Enabled = false;
                //}

                if (dscheck.Tables[0].Rows[0]["BuildingWorker"].ToString() != "")
                    txtNoofworkers.Text = dscheck.Tables[0].Rows[0]["BuildingWorker"].ToString().Trim();

                if (dscheck.Tables[0].Rows[0]["ContractWorker"].ToString() != "")
                    txtContractLabourAct.Text = dscheck.Tables[0].Rows[0]["ContractWorker"].ToString().Trim();

                if (dscheck.Tables[0].Rows[0]["MigrantWorker"].ToString() != "")
                    txtMigrantWorkmanAct.Text = dscheck.Tables[0].Rows[0]["MigrantWorker"].ToString().Trim();
                //20d
                if (dscheck.Tables[0].Rows[0]["InterStateContractWorker"].ToString() != "")
                    txtNoofworkers20d.Text = dscheck.Tables[0].Rows[0]["InterStateContractWorker"].ToString().Trim();

                if (dscheck.Tables[0].Rows[0]["ContractWorkerLicense"].ToString() != "")
                    txtact5emp.Text = dscheck.Tables[0].Rows[0]["ContractWorkerLicense"].ToString().Trim();


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
                {
                    ddlIndustrialParkName.SelectedValue = Iala_Code;
                    ddlIndustrialParkName_SelectedIndexChanged(this, EventArgs.Empty);
                }
                txttsiixplotno.Text = dscheck.Tables[0].Rows[0]["TsiicPlotno"].ToString().Trim();
                if (dscheck.Tables[0].Rows[0]["VicitnyWaterBodyFlag"].ToString().Trim() != "")
                    rdvicinitywaterbody.SelectedValue = rdvicinitywaterbody.Items.FindByValue(dscheck.Tables[0].Rows[0]["VicitnyWaterBodyFlag"].ToString().Trim()).Value;
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
                            RdbExecpted2.SelectedValue = "Y";
                            RdbExecpted2_SelectedIndexChanged(sender, e);
                            rdbact2_SelectedIndexChanged(sender, e);
                        }
                        if (values[i] == "5")
                        {
                            Rdb20d.SelectedValue = "Y";
                            Rdb20d_SelectedIndexChanged(sender, e);
                        }
                        if (values[i] == "6")
                        {
                            Rdbact5License.SelectedValue = "Y";
                            Rdbact5License_SelectedIndexChanged(sender, e);
                        }
                        if (values[i] == "7")
                        {
                            RdbExecptedactShop.SelectedValue = "Y";
                            RdbExecptedactShop_SelectedIndexChanged(sender, e);
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
                // ddlProp_intVillageid.SelectedValue = ddlProp_intVillageid.Items.FindByValue(dscheck.Tables[0].Rows[0]["Prop_intVillageid"].ToString().Trim()).Value;
                string valueFromDS = dscheck.Tables[0].Rows[0]["Prop_intVillageid"].ToString().Trim();

                ListItem foundItem = ddlProp_intVillageid.Items.FindByValue(valueFromDS);

                if (foundItem != null)
                {
                    ddlProp_intVillageid.SelectedValue = valueFromDS;
                }
                else
                {
                    ddlProp_intVillageid.SelectedIndex = -1;
                }
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

                TextBox1.Text = dscheck.Tables[0].Rows[0]["annualTurnover_act"].ToString().Trim();
                TextBox2.Text = dscheck.Tables[0].Rows[0]["annualTurnover"].ToString().Trim();
                TextBox3.Text = dscheck.Tables[0].Rows[0]["annualTurnover_Exp"].ToString().Trim();
                TextBox4.Text = dscheck.Tables[0].Rows[0]["annualTurnover_Exp_act"].ToString().Trim();

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
                    ListItem item = ddlLoc_of_unit.Items.FindByValue(dscheck.Tables[0].Rows[0]["Loc_of_unit"].ToString().Trim());
                    if (item != null)
                    {
                        //ddlProductGrp.Items.FindByText("Product").Selected = true;
                        ddlLoc_of_unit.SelectedValue = ddlLoc_of_unit.Items.FindByValue(dscheck.Tables[0].Rows[0]["Loc_of_unit"].ToString().Trim()).Value;
                        ddlLoc_of_unit_SelectedIndexChanged(sender, e);
                    }
                }

                TxtWater_req_Perday.Text = dscheck.Tables[0].Rows[0]["Water_req_Perday"].ToString().Trim();
                //if (dscheck.Tables[0].Rows[0]["Water_reg_from1"].ToString().Trim() != "")
                //{
                //    ChkWater_reg_from.Items[0].Selected = true;
                //}
                //if (dscheck.Tables[0].Rows[0]["Water_reg_from2"].ToString().Trim() != "")
                //{
                //    ChkWater_reg_from.Items[1].Selected = true;
                //}
                //if (dscheck.Tables[0].Rows[0]["Water_reg_from3"].ToString().Trim() != "")
                //{
                //    ChkWater_reg_from.Items[2].Selected = true;
                //}
                if (dscheck.Tables[0].Rows[0]["BorewellFlagVALUE"].ToString().Trim() != "")
                {
                    rdo_borewell.SelectedValue = rdo_borewell.Items.FindByValue(dscheck.Tables[0].Rows[0]["BorewellFlagVALUE"].ToString().Trim()).Value;
                    rdo_borewell_SelectedIndexChanged(sender, e);
                }
                if (rdo_borewell.SelectedValue != "Y")
                {
                    foreach (GridViewRow gvrTEMPVehMstr in gvmodelsnames.Rows)
                    {
                        TextBox txtwaterrequirednew = (TextBox)gvrTEMPVehMstr.FindControl("txtwaterrequired");
                        txtwaterrequirednew.ReadOnly = false;
                        if (dscheck.Tables[0].Rows[0]["Water_reg_from1"].ToString().Trim() != "" && gvrTEMPVehMstr.RowIndex == 0)
                        {
                            CheckBox txtMakerGvV = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                            TextBox txtwaterrequired = (TextBox)gvrTEMPVehMstr.FindControl("txtwaterrequired");
                            txtMakerGvV.Checked = true;
                            txtwaterrequired.Text = dscheck.Tables[0].Rows[0]["Water_req_Perday_Borewell"].ToString().Trim();
                            if (txtwaterrequired.Text.Trim().TrimStart() == "")
                            {
                                txtwaterrequired.Text = dscheck.Tables[0].Rows[0]["Water_req_Perday"].ToString().Trim();
                            }
                        }
                        if (dscheck.Tables[0].Rows[0]["Water_reg_from2"].ToString().Trim() != "" && gvrTEMPVehMstr.RowIndex == 1)
                        {
                            CheckBox txtMakerGvV1 = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                            TextBox txtwaterrequired = (TextBox)gvrTEMPVehMstr.FindControl("txtwaterrequired");
                            txtMakerGvV1.Checked = true;
                            txtwaterrequired.Text = dscheck.Tables[0].Rows[0]["Water_req_Perday_HMWS"].ToString().Trim();
                        }
                        if (dscheck.Tables[0].Rows[0]["Water_reg_from3"].ToString().Trim() != "" && gvrTEMPVehMstr.RowIndex == 2)
                        {
                            CheckBox txtMakerGvV2 = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                            TextBox txtwaterrequired = (TextBox)gvrTEMPVehMstr.FindControl("txtwaterrequired");
                            txtMakerGvV2.Checked = true;
                            txtwaterrequired.Text = dscheck.Tables[0].Rows[0]["Water_req_Perday_RiversCanals"].ToString().Trim();
                        }
                        if (dscheck.Tables[0].Rows[0]["Water_reg_from4"].ToString().Trim() != "" && gvrTEMPVehMstr.RowIndex == 3)
                        {
                            CheckBox txtMakerGvV3 = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                            TextBox txtwaterrequired = (TextBox)gvrTEMPVehMstr.FindControl("txtwaterrequired");
                            txtMakerGvV3.Checked = true;
                            txtwaterrequired.Text = dscheck.Tables[0].Rows[0]["Water_req_Perday_CDMA"].ToString().Trim();
                        }
                        if (dscheck.Tables[0].Rows[0]["Water_reg_from5"].ToString().Trim() != "" && gvrTEMPVehMstr.RowIndex == 4)
                        {
                            CheckBox txtMakerGvV4 = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                            TextBox txtwaterrequired = (TextBox)gvrTEMPVehMstr.FindControl("txtwaterrequired");
                            txtMakerGvV4.Checked = true;
                            txtwaterrequired.Text = dscheck.Tables[0].Rows[0]["Water_req_Perday_MissionBhagi"].ToString().Trim();
                        }
                    }
                }
                else
                {
                    foreach (GridViewRow gvrTEMPVehMstr in gvmodelsnames.Rows)
                    {
                        TextBox txtwaterrequirednew = (TextBox)gvrTEMPVehMstr.FindControl("txtwaterrequired");
                        txtwaterrequirednew.ReadOnly = false;
                        //if (dscheck.Tables[0].Rows[0]["Water_reg_from1"].ToString().Trim() != "" && gvrTEMPVehMstr.RowIndex == 0)
                        //{
                        //    CheckBox txtMakerGvV = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                        //    TextBox txtwaterrequired = (TextBox)gvrTEMPVehMstr.FindControl("txtwaterrequired");
                        //    txtMakerGvV.Checked = true;
                        //    txtwaterrequired.Text = dscheck.Tables[0].Rows[0]["Water_req_Perday_Borewell"].ToString().Trim();
                        //    if (txtwaterrequired.Text.Trim().TrimStart() == "")
                        //    {
                        //        txtwaterrequired.Text = dscheck.Tables[0].Rows[0]["Water_req_Perday"].ToString().Trim();
                        //    }
                        //}
                        if (dscheck.Tables[0].Rows[0]["Water_reg_from2"].ToString().Trim() != "" && gvrTEMPVehMstr.RowIndex == 0)
                        {
                            CheckBox txtMakerGvV1 = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                            TextBox txtwaterrequired = (TextBox)gvrTEMPVehMstr.FindControl("txtwaterrequired");
                            txtMakerGvV1.Checked = true;
                            txtwaterrequired.Text = dscheck.Tables[0].Rows[0]["Water_req_Perday_HMWS"].ToString().Trim();
                        }
                        if (dscheck.Tables[0].Rows[0]["Water_reg_from3"].ToString().Trim() != "" && gvrTEMPVehMstr.RowIndex == 1)
                        {
                            CheckBox txtMakerGvV2 = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                            TextBox txtwaterrequired = (TextBox)gvrTEMPVehMstr.FindControl("txtwaterrequired");
                            txtMakerGvV2.Checked = true;
                            txtwaterrequired.Text = dscheck.Tables[0].Rows[0]["Water_req_Perday_RiversCanals"].ToString().Trim();
                        }
                        if (dscheck.Tables[0].Rows[0]["Water_reg_from4"].ToString().Trim() != "" && gvrTEMPVehMstr.RowIndex == 2)
                        {
                            CheckBox txtMakerGvV3 = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                            TextBox txtwaterrequired = (TextBox)gvrTEMPVehMstr.FindControl("txtwaterrequired");
                            txtMakerGvV3.Checked = true;
                            txtwaterrequired.Text = dscheck.Tables[0].Rows[0]["Water_req_Perday_CDMA"].ToString().Trim();
                        }
                        if (dscheck.Tables[0].Rows[0]["Water_reg_from5"].ToString().Trim() != "" && gvrTEMPVehMstr.RowIndex == 3)
                        {
                            CheckBox txtMakerGvV4 = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                            TextBox txtwaterrequired = (TextBox)gvrTEMPVehMstr.FindControl("txtwaterrequired");
                            txtMakerGvV4.Checked = true;
                            txtwaterrequired.Text = dscheck.Tables[0].Rows[0]["Water_req_Perday_MissionBhagi"].ToString().Trim();
                        }
                    }

                }
                //  chkwatera=dscheck.Tables[0].Rows[0]["Tot_Extent"].ToString().Trim(); 
                //  chkwaterb=dscheck.Tables[0].Rows[0]["Tot_Extent"].ToString().Trim(); 
                //  chkwaterc=dscheck.Tables[0].Rows[0]["Tot_Extent"].ToString().Trim();

                RdDo_Store_Kerosine.SelectedValue = RdDo_Store_Kerosine.Items.FindByValue(dscheck.Tables[0].Rows[0]["Do_Store_Kerosine"].ToString().Trim()).Value;
                if (dscheck.Tables[0].Rows[0]["petrolDieselflag"].ToString() != "")
                    RdDo_Store_Kerosine0.SelectedValue = RdDo_Store_Kerosine0.Items.FindByValue(dscheck.Tables[0].Rows[0]["petrolDieselflag"].ToString().Trim()).Value;
                else
                    RdDo_Store_Kerosine0.SelectedValue = "N";
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
                if (dscheck.Tables[0].Rows[0]["Appl_Type"].ToString().Trim() != "" && dscheck.Tables[0].Rows[0]["Appl_Type"].ToString().Trim() != "0")
                {
                    ListItem itemAPPLITYPE = ddlAppl_Type.Items.FindByValue(dscheck.Tables[0].Rows[0]["Appl_Type"].ToString().Trim());
                    if (itemAPPLITYPE != null)
                    {
                        //ddlProductGrp.Items.FindByText("Product").Selected = true;
                        ddlAppl_Type.SelectedValue = ddlAppl_Type.Items.FindByValue(dscheck.Tables[0].Rows[0]["Appl_Type"].ToString().Trim()).Value;
                        trApplType.Visible = true;
                    }
                    else
                    {
                        trApplType.Visible = false;
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
                }
                else
                {
                    trApplType.Visible = false;
                }
                if (dscheck.Tables[0].Rows[0]["MarketValue"].ToString() != "")
                {
                    txtmarketvalue.Text = dscheck.Tables[0].Rows[0]["MarketValue"].ToString().Trim();
                }
                if (dscheck.Tables[0].Rows[0]["CEIG"].ToString() != "")
                {
                    if (dscheck.Tables[0].Rows[0]["CEIG"].ToString().Trim() == "Y")
                    {
                        RdpIndustry.SelectedValue = "Y";
                        trregulation.Visible = true;
                        trvoltage.Visible = true;
                        if (dscheck.Tables[0].Rows[0]["Regulation_type"].ToString() != "")
                        {
                            ddlregulation.SelectedValue = dscheck.Tables[0].Rows[0]["Regulation_type"].ToString();
                        }
                        if (dscheck.Tables[0].Rows[0]["Voltage_Slno"].ToString() != "")
                        {
                            ddlvoltage.SelectedValue = dscheck.Tables[0].Rows[0]["Voltage_Slno"].ToString();
                            //if (ddlvoltage.SelectedValue == "1")
                            //{
                            trvolcapacity.Visible = true;
                            txtagrcapacity.Text = dscheck.Tables[0].Rows[0]["AggregateCapacity"].ToString().Trim();
                            //}
                        }
                    }
                    //txtmarketvalue.Text = dscheck.Tables[0].Rows[0]["AggregateCapacity"].ToString().Trim();
                }
                if (dscheck.Tables[0].Rows[0]["professiontaxflag"].ToString().Trim() != "")
                {
                    rdprofessiontax.SelectedValue = rdprofessiontax.Items.FindByValue(dscheck.Tables[0].Rows[0]["professiontaxflag"].ToString().Trim()).Value;
                }
                if (dscheck.Tables[0].Rows[0]["Exciseflag"].ToString().Trim() != "")
                {
                    rdexcise.SelectedValue = rdexcise.Items.FindByValue(dscheck.Tables[0].Rows[0]["Exciseflag"].ToString().Trim()).Value;
                }
                CalcFeesNewDepartment();
                //   CalcFees();
            }
            else
            {
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

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (TxtHight_Build.Text.Trim().All(c => c == '0'))
            {

                lblmsg0.Text = "Building Height Should not be zero";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Building Height Should not be zero..!');", true);
                Failure.Visible = true;
                return;
            }
            if (ddlintLineofActivity.SelectedValue == "1032" || ddlintLineofActivity.SelectedValue == "1139" || ddlintLineofActivity.SelectedValue == "1314" || ddlintLineofActivity.SelectedValue == "1000" || ddlintLineofActivity.SelectedValue == "1124" || ddlintLineofActivity.SelectedValue == "1303" || ddlintLineofActivity.SelectedValue == "1150" || ddlintLineofActivity.SelectedValue == "1178" || ddlintLineofActivity.SelectedValue == "1207" || ddlintLineofActivity.SelectedValue == "1295" || ddlintLineofActivity.SelectedValue == "1078" || ddlintLineofActivity.SelectedValue == "1209" || ddlintLineofActivity.SelectedValue == "1315")
            {

                //ddlintLineofActivity.SelectedValue == "1195" commented on 01.12.2017
                decimal strTot_PrjCost = 0;   // laks
                decimal strTot_PrjCostCrors = 0;   // laks
                if (ddlproposal.SelectedValue == "1")
                {
                    strTot_PrjCost = Convert.ToDecimal(TxtTot_PrjCost.Text);
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
            string res1 = Gen.RetriveStatus(Session["Applid"].ToString());
            ////string res = Gen.RetriveStatus("1002"); COMMENTED BY MADHURI ON 15.12.2022
            //if (res1 == "3" || Convert.ToInt32(res1) >= 3)
            //{
            //    Response.Redirect("frmQuesstionniareReg.aspx");
            //}
            foreach (GridViewRow gvrTEMPVehMstr in gvmodelsnames.Rows)
            {
                CheckBox txtMakerGvV = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                TextBox txtwaterrequired = (TextBox)gvrTEMPVehMstr.FindControl("txtwaterrequired");
                if (txtMakerGvV.Checked == true && (txtwaterrequired.Text.Trim().TrimStart() == "" || Convert.ToDecimal(txtwaterrequired.Text.Trim().TrimStart()) == 0))
                {
                    string message = "alert('Water required per day( in KLD) Shold not be empty/zero')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
            }
            Label7.Visible = false;
            RdPol_Indus.Visible = false;
            BtnSave.Visible = true;
            CalcFees();

            BtnSave1.CssClass = "btn-primary";
            BtnSave.CssClass = "button";
            // ClientScript.RegisterStartupScript(GetType(), "hwa", "paginationClickHandler(event)", true);
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

                //dsMunicial = Gen.GetShowApprovalandFeesGpFees("2", Enterpriseid, TxtBuilt_up_Area.Text.Trim());
                // dsv.Tables[0].Merge(dsMunicial.Tables[0]);
            }
            DataSet dsv1 = new DataSet();
            //if (ddlPower_Req.SelectedIndex == 1)
            //{

            //    dsv1 = Gen.GetShowApprovalandFees("21", Enterpriseid);
            //    dsv.Tables[0].Merge(dsv1.Tables[0]);
            //}
            //else 
            //Director of Factories - Hozordas
            //if (RdGen_Reqired.SelectedValue == "Y")
            //{
            //    //Director of Factories - Hozordas
            //    dsv1 = Gen.GetShowApprovalandFees("21", Enterpriseid);
            //    dsv.Tables[0].Merge(dsv1.Tables[0]);
            //}
            //else
            //{
            //    if (ddlPower_Req.SelectedIndex == 1 || ddlPower_Req.SelectedIndex == 2)
            //    {
            //        dsv1 = Gen.GetShowApprovalandFees("5", Enterpriseid);
            //        dsv.Tables[0].Merge(dsv1.Tables[0]);
            //    }
            //    else
            //    { 

            //    }
            //}

            //if (ddlPower_Req.SelectedIndex == 2)  //commented nikhil
            //{

            //    dsv1 = Gen.GetShowApprovalandFees("5", Enterpriseid);
            //    dsv.Tables[0].Merge(dsv1.Tables[0]);
            //}
            //else if (ddlPower_Req.SelectedIndex == 3)   //commented nikhil
            //{

            //    dsv1 = Gen.GetShowApprovalandFees("21", Enterpriseid);
            //    dsv.Tables[0].Merge(dsv1.Tables[0]);

            //}
            //else if (ddlPower_Req.SelectedIndex == 3)   //commented nikhil
            //{

            //}

            if (ddlPower_Req.SelectedIndex == 2 || ddlPower_Req.SelectedIndex == 3)
            {

                dsv1 = Gen.GetShowApprovalandFeesFactory("5", Enterpriseid, Convert.ToString(ddlPower_Req.SelectedIndex), Session["uid"].ToString().Trim());
                dsv.Tables[0].Merge(dsv1.Tables[0]);
            }
            else if (ddlPower_Req.SelectedIndex == 5 || ddlPower_Req.SelectedIndex == 6)
            {

                dsv1 = Gen.GetShowApprovalandFeesFactory("21", Enterpriseid, Convert.ToString(ddlPower_Req.SelectedIndex), Session["uid"].ToString().Trim());
                dsv.Tables[0].Merge(dsv1.Tables[0]);

            }
            else if (ddlPower_Req.SelectedIndex == 4)
            {
                dsv1 = Gen.GetShowApprovalandFeesFactory("44", Enterpriseid, Convert.ToString(ddlPower_Req.SelectedIndex), Session["uid"].ToString().Trim());
                dsv.Tables[0].Merge(dsv1.Tables[0]);
            }

            DataSet dsv2 = new DataSet();
            if (ddlProp_intDistrictid.SelectedValue == "1" || ddlProp_intDistrictid.SelectedValue == "2" || ddlProp_intDistrictid.SelectedValue == "3" || ddlProp_intDistrictid.SelectedValue == "9" || ddlProp_intDistrictid.SelectedValue == "10" || ddlProp_intDistrictid.SelectedValue == "11" || ddlProp_intDistrictid.SelectedValue == "12" || ddlProp_intDistrictid.SelectedValue == "14" || ddlProp_intDistrictid.SelectedValue == "15" || ddlProp_intDistrictid.SelectedValue == "16" || ddlProp_intDistrictid.SelectedValue == "17" || ddlProp_intDistrictid.SelectedValue == "18" || ddlProp_intDistrictid.SelectedValue == "19" || ddlProp_intDistrictid.SelectedValue == "22" || ddlProp_intDistrictid.SelectedValue == "23" || ddlProp_intDistrictid.SelectedValue == "26" || ddlProp_intDistrictid.SelectedValue == "30" || ddlProp_intDistrictid.SelectedValue == "32" || ddlProp_intDistrictid.SelectedValue == "34" || ddlProp_intDistrictid.SelectedValue == "35")
            {
                //DataSet dscess = Gen.getCESSVillages(ddlProp_intVillageid.SelectedValue);
                //if (dscess.Tables[0].Rows.Count > 0)
                //{
                //    dsv2 = Gen.GetShowApprovalandFees("41", Enterpriseid);
                //    dsv.Tables[0].Merge(dsv2.Tables[0]);
                //}
                //else
                //{
                //    dsv2 = Gen.GetShowApprovalandFees("4", Enterpriseid);
                //    dsv.Tables[0].Merge(dsv2.Tables[0]);
                //}
                DataSet dscess = Gen.getCESSVillages(ddlProp_intVillageid.SelectedValue);
                //if (ddlPower_Req.SelectedIndex == 1 || ddlPower_Req.SelectedIndex == 2)
                if (ddlPower_Req.SelectedIndex == 1 || ddlPower_Req.SelectedIndex == 2 || ddlPower_Req.SelectedIndex == 3 || ddlPower_Req.SelectedIndex == 4 || ddlPower_Req.SelectedIndex == 5 || ddlPower_Req.SelectedIndex == 6)//added on 23.12.20. KCS 
                {
                    // if (dscess.Tables[0].Rows.Count > 0 && (HDNAPPLNSTATUS.Value == "3" && DateTime.ParseExact(HDNDATEOFPAYMENT.Value, "dd-MM-yyyy", CultureInfo.InvariantCulture) <= DateTime.ParseExact("06-06-2026", "dd-MM-yyyy", CultureInfo.InvariantCulture)))

                    //  if (dscess.Tables[0].Rows.Count > 0) commented on 08062026
                    if (dscess.Tables[0].Rows.Count > 0 && (HDNDATEOFPAYMENT.Value != null && HDNDATEOFPAYMENT.Value != "" && DateTime.ParseExact(HDNDATEOFPAYMENT.Value, "dd-MM-yyyy", CultureInfo.InvariantCulture) <= DateTime.ParseExact("07-06-2026", "dd-MM-yyyy", CultureInfo.InvariantCulture))
                            && (HDNCESSAPPROVED.Value != "" && HDNCESSAPPROVED.Value != null) && !new[] { "155520", "155444", "155395", "155384", "155390", "155077", "154688", "154572" }.Contains(HDNCESSQUESTIONNAIREID.Value))

                    {
                        dsv2 = Gen.GetShowApprovalandFees("41", Enterpriseid);
                        dsv.Tables[0].Merge(dsv2.Tables[0]);
                    }
                    else
                    {
                        dsv2 = Gen.GetShowApprovalandFees("4", Enterpriseid);
                        dsv.Tables[0].Merge(dsv2.Tables[0]);
                    }
                }

                else
                {
                    dsv2 = Gen.GetShowApprovalandFees("4", Enterpriseid);
                    dsv.Tables[0].Merge(dsv2.Tables[0]);
                }
            }
            else if (ddlProp_intDistrictid.SelectedValue == "4" || ddlProp_intDistrictid.SelectedValue == "5" || ddlProp_intDistrictid.SelectedValue == "6" || ddlProp_intDistrictid.SelectedValue == "7" || ddlProp_intDistrictid.SelectedValue == "8" || ddlProp_intDistrictid.SelectedValue == "13" || ddlProp_intDistrictid.SelectedValue == "20" || ddlProp_intDistrictid.SelectedValue == "21" || ddlProp_intDistrictid.SelectedValue == "24" || ddlProp_intDistrictid.SelectedValue == "25" || ddlProp_intDistrictid.SelectedValue == "27" || ddlProp_intDistrictid.SelectedValue == "28" || ddlProp_intDistrictid.SelectedValue == "29" || ddlProp_intDistrictid.SelectedValue == "31" || ddlProp_intDistrictid.SelectedValue == "33")
            {
                dsv2 = Gen.GetShowApprovalandFees("25", Enterpriseid);
                dsv.Tables[0].Merge(dsv2.Tables[0]);
            }
            //

            string TxtTot_PrjCostNewfinal = "0";

            if (ddlproposal.SelectedValue == "2")
            {
                // TxtTot_PrjCostNewfinal = lblfinaltotalvalue.Text;
                TxtTot_PrjCostNewfinal = txtlbltotalprojectcostexpanstion.Text;
            }
            else
            {
                TxtTot_PrjCostNewfinal = TxtTot_PrjCost.Text;

            }

            //
            DataSet dsv3 = new DataSet();
            string strTot_PrjCost = "0";
            string TxtVal_Plantnewfinal = "0";
            if (ddlproposal.SelectedValue == "1")
            {
                strTot_PrjCost = TxtTot_PrjCost.Text;
                TxtVal_Plantnewfinal = TxtVal_Plant.Text;
            }
            else if (ddlproposal.SelectedValue == "2")
            {
                strTot_PrjCost = txtlbltotalprojectcostexpanstion.Text;
                TxtVal_Plantnewfinal = lblplantotalexp.Text;
            }
            if (HdfLblPol_Category.Value == "Red")
            {

                //dsv3 = Gen.GetShowApprovalandFeesPCB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost);
                dsv3 = Gen.GetShowApprovalandFeesPCBNew("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost, Session["Applid"].ToString());
                //Gen.GetShowApprovalandFeesPCBNewDB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost, Session["Applid"].ToString());
                //GetShowApprovalandFeesPCBNewDB


                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }
            else if (HdfLblPol_Category.Value == "Green")
            {
                if (HdfLblEnt_is.Value == "Small" || HdfLblEnt_is.Value == "Micro")
                {
                    if (RdPol_Indus.SelectedValue.ToString().Trim() == "Y")
                    {
                        //dsv3 = Gen.GetShowApprovalandFeesPCB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost);
                        dsv3 = Gen.GetShowApprovalandFeesPCBNew("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost, Session["Applid"].ToString());
                        //Gen.GetShowApprovalandFeesPCBNewDB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost, Session["Applid"].ToString());
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                    else if (RdPol_Indus.SelectedValue.ToString().Trim() == "N")
                    {
                        //dsv3 = Gen.GetShowApprovalandFeesPCB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost);
                        dsv3 = Gen.GetShowApprovalandFeesPCBNew("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost, Session["Applid"].ToString());
                        //Gen.GetShowApprovalandFeesPCBNewDB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost, Session["Applid"].ToString());
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                }
                else
                {
                    //dsv3 = Gen.GetShowApprovalandFeesPCB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost);
                    dsv3 = Gen.GetShowApprovalandFeesPCBNew("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost, Session["Applid"].ToString());
                    //Gen.GetShowApprovalandFeesPCBNewDB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost, Session["Applid"].ToString());
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
            }
            else if (HdfLblPol_Category.Value == "Orange")
            {
                if (HdfLblEnt_is.Value == "Small" || HdfLblEnt_is.Value == "Micro")
                {
                    if (RdPol_Indus.SelectedValue.ToString().Trim() == "Y")
                    {

                        //dsv3 = Gen.GetShowApprovalandFeesPCB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost);
                        dsv3 = Gen.GetShowApprovalandFeesPCBNew("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost, Session["Applid"].ToString());
                        //Gen.GetShowApprovalandFeesPCBNewDB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost, Session["Applid"].ToString());
                        dsv.Tables[0].Merge(dsv3.Tables[0]);

                    }
                    else if (RdPol_Indus.SelectedValue.ToString().Trim() == "N")
                    {
                        //dsv3 = Gen.GetShowApprovalandFeesPCB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost);
                        dsv3 = Gen.GetShowApprovalandFeesPCBNew("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost, Session["Applid"].ToString());
                        // Gen.GetShowApprovalandFeesPCBNewDB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost, Session["Applid"].ToString());
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                }
                else
                {
                    //dsv3 = Gen.GetShowApprovalandFeesPCB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost);
                    dsv3 = Gen.GetShowApprovalandFeesPCBNew("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost, Session["Applid"].ToString());
                    //Gen.GetShowApprovalandFeesPCBNewDB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost, Session["Applid"].ToString());
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
            }
            // commented by shankar
            //if (ChkWater_reg_from.Items[0].Selected == true)
            //{
            //    dsv3 = Gen.GetShowApprovalandFeesGroundWater("9", Enterpriseid, TxtWater_req_Perday.Text, TxtTot_Extent.Text);
            //    dsv.Tables[0].Merge(dsv3.Tables[0]);
            //}
            //if (ChkWater_reg_from.Items[1].Selected == true)
            //{
            //    dsv3 = Gen.GetShowApprovalandFeesHWS("10", Enterpriseid);
            //    dsv.Tables[0].Merge(dsv3.Tables[0]);
            //}
            //if (ChkWater_reg_from.Items[2].Selected == true)
            //{
            //    dsv3 = Gen.GetShowApprovalandFees("11", Enterpriseid);
            //    dsv.Tables[0].Merge(dsv3.Tables[0]);
            //}
            if (rdo_borewell.SelectedValue != "Y")
            {
                foreach (GridViewRow gvrTEMPVehMstr in gvmodelsnames.Rows)
                {
                    CheckBox txtMakerGvV = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                    TextBox txtwaterrequired = (TextBox)gvrTEMPVehMstr.FindControl("txtwaterrequired");

                    if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 0)
                    {
                        dsv3 = Gen.GetShowApprovalandFeesGroundWater("9", Enterpriseid, txtwaterrequired.Text, TxtTot_Extent.Text);
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                    if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 1)
                    {
                        dsv3 = Gen.GetShowApprovalandFeesHWS("10", Enterpriseid);
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                    if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 2)
                    {
                        dsv3 = Gen.GetShowApprovalandFees("11", Enterpriseid, Session["Applid"].ToString());
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                    if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 3)
                    {
                        //dsv3 = Gen.GetShowApprovalandFees("70", Enterpriseid);
                        //dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                    if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 4)
                    {
                        dsv3 = Gen.GetShowApprovalandFees("71", Enterpriseid);
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                }
            }
            else
            {
                foreach (GridViewRow gvrTEMPVehMstr in gvmodelsnames.Rows)
                {
                    CheckBox txtMakerGvV = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                    TextBox txtwaterrequired = (TextBox)gvrTEMPVehMstr.FindControl("txtwaterrequired");

                    //if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 0)
                    //{
                    //    dsv3 = Gen.GetShowApprovalandFeesGroundWater("9", Enterpriseid, txtwaterrequired.Text, TxtTot_Extent.Text);
                    //    dsv.Tables[0].Merge(dsv3.Tables[0]);
                    //}
                    if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 0)
                    {
                        dsv3 = Gen.GetShowApprovalandFeesHWS("10", Enterpriseid);
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                    if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 1)
                    {
                        dsv3 = Gen.GetShowApprovalandFees("11", Enterpriseid, Session["Applid"].ToString());
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                    if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 2)
                    {
                        //dsv3 = Gen.GetShowApprovalandFees("70", Enterpriseid);
                        //dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                    if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 3)
                    {
                        dsv3 = Gen.GetShowApprovalandFees("71", Enterpriseid);
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                }
            }
            if (RdDo_Store_Kerosine.SelectedValue == "Y")
            {


                if (ddlProp_intDistrictid.SelectedItem.Text == "Rangareddy")
                {

                    if (ddlProp_intMandalid.SelectedItem.Text == "Rajendranagar" || ddlProp_intMandalid.SelectedItem.Text == "Moinabad" || ddlProp_intMandalid.SelectedItem.Text == "Shamshabad" || ddlProp_intMandalid.SelectedItem.Text == "Chevella" || ddlProp_intMandalid.SelectedItem.Text == "Shankarpalle" || ddlProp_intMandalid.SelectedItem.Text == "Shabad" ||
                        ddlProp_intMandalid.SelectedItem.Text == "Farooqnagar" || ddlProp_intMandalid.SelectedItem.Text == "Keshampet" ||
                        ddlProp_intMandalid.SelectedItem.Text == "Kondurg" || ddlProp_intMandalid.SelectedItem.Text == "Kothur" ||
                        ddlProp_intMandalid.SelectedItem.Text == "Nandigama" || ddlProp_intMandalid.SelectedItem.Text == "Amangal" ||
                        ddlProp_intMandalid.SelectedItem.Text == "Kadthal" || ddlProp_intMandalid.SelectedItem.Text == "Serilingampally"
                        || ddlProp_intMandalid.SelectedItem.Text == "Gandipet")
                    {
                        dsv1 = Gen.GetShowApprovalandFeesFactory("32", "21", "6", Session["uid"].ToString().Trim());
                        dsv.Tables[0].Merge(dsv1.Tables[0]);
                    }
                    else if (ddlProp_intMandalid.SelectedItem.Text == "Saroornagar" || ddlProp_intMandalid.SelectedItem.Text == "Hayathnagar" || ddlProp_intMandalid.SelectedItem.Text == "Abdullapurmet" || ddlProp_intMandalid.SelectedItem.Text == "Balapur" || ddlProp_intMandalid.SelectedItem.Text == "Ibrahimpatnam" || ddlProp_intMandalid.SelectedItem.Text == "Manchal" ||
                        ddlProp_intMandalid.SelectedItem.Text == "Yacharam" || ddlProp_intMandalid.SelectedItem.Text == "Maheswaram" ||
                        ddlProp_intMandalid.SelectedItem.Text == "Kandukur" || ddlProp_intMandalid.SelectedItem.Text == "Madgul")
                    {
                        dsv1 = Gen.GetShowApprovalandFeesFactory("32", "22", "6", Session["uid"].ToString().Trim());
                        dsv.Tables[0].Merge(dsv1.Tables[0]);
                    }
                    else
                    {
                        dsv3 = Gen.GetShowApprovalandFeesDistincts("32", Enterpriseid, ddlProp_intDistrictid.SelectedValue);
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                }
                else
                {
                    dsv3 = Gen.GetShowApprovalandFeesDistincts("32", Enterpriseid, ddlProp_intDistrictid.SelectedValue);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
            }
            if (RdDo_Store_Kerosine0.SelectedValue == "Y")
            {
                if (ddlProp_intDistrictid.SelectedItem.Text == "Rangareddy")
                {

                    if (ddlProp_intMandalid.SelectedItem.Text == "Rajendranagar" || ddlProp_intMandalid.SelectedItem.Text == "Moinabad" || ddlProp_intMandalid.SelectedItem.Text == "Shamshabad" || ddlProp_intMandalid.SelectedItem.Text == "Chevella" || ddlProp_intMandalid.SelectedItem.Text == "Shankarpalle" || ddlProp_intMandalid.SelectedItem.Text == "Shabad" ||
                        ddlProp_intMandalid.SelectedItem.Text == "Farooqnagar" || ddlProp_intMandalid.SelectedItem.Text == "Keshampet" ||
                        ddlProp_intMandalid.SelectedItem.Text == "Kondurg" || ddlProp_intMandalid.SelectedItem.Text == "Kothur" ||
                        ddlProp_intMandalid.SelectedItem.Text == "Nandigama" || ddlProp_intMandalid.SelectedItem.Text == "Amangal" ||
                        ddlProp_intMandalid.SelectedItem.Text == "Kadthal" || ddlProp_intMandalid.SelectedItem.Text == "Serilingampally"
                        || ddlProp_intMandalid.SelectedItem.Text == "Gandipet")
                    {
                        dsv1 = Gen.GetShowApprovalandFeesFactory("102", "21", "6", Session["uid"].ToString().Trim());
                        if (dsv1.Tables.Count > 0) dsv.Tables[0].Merge(dsv1.Tables[0]);
                    }
                    else if (ddlProp_intMandalid.SelectedItem.Text == "Saroornagar" || ddlProp_intMandalid.SelectedItem.Text == "Hayathnagar" || ddlProp_intMandalid.SelectedItem.Text == "Abdullapurmet" || ddlProp_intMandalid.SelectedItem.Text == "Balapur" || ddlProp_intMandalid.SelectedItem.Text == "Ibrahimpatnam" || ddlProp_intMandalid.SelectedItem.Text == "Manchal" ||
                        ddlProp_intMandalid.SelectedItem.Text == "Yacharam" || ddlProp_intMandalid.SelectedItem.Text == "Maheswaram" ||
                        ddlProp_intMandalid.SelectedItem.Text == "Kandukur" || ddlProp_intMandalid.SelectedItem.Text == "Madgul")
                    {
                        dsv1 = Gen.GetShowApprovalandFeesFactory("102", "22", "6", Session["uid"].ToString().Trim());
                        dsv.Tables[0].Merge(dsv1.Tables[0]);
                    }
                    else
                    {
                        dsv3 = Gen.GetShowApprovalandFeesDistincts("102", Enterpriseid, ddlProp_intDistrictid.SelectedValue);
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                }
                else
                {
                    dsv3 = Gen.GetShowApprovalandFeesDistincts("102", Enterpriseid, ddlProp_intDistrictid.SelectedValue);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
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
                dsv3 = Gen.GetShowApprovalandFeesEnterPriseAmount("28", Enterpriseid, TxtVal_Plantnewfinal, strTot_PrjCost, Txt_NoofTrees.Text);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }
            if (ddlLoc_of_unit.SelectedValue == "2")
            {
                dsv3 = Gen.GetShowApprovalandFeesDTCP("7", Enterpriseid, RdFall_in_Municipal.SelectedValue);
                dsv.Tables[0].Merge(dsv3.Tables[0]);

                dsv3 = Gen.GetShowApprovalandFeesGpFees("57", Enterpriseid, TxtBuilt_up_Area.Text.Trim(), ddlProp_intVillageid.SelectedValue, ddlLoc_of_unit.SelectedValue, Session["uid"].ToString().Trim());
                if (dsv3 != null && dsv3.Tables.Count > 0 && dsv3.Tables[0].Rows.Count > 0)
                {
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
            }
            if (ddlLoc_of_unit.SelectedValue == "9")
            {
                dsv3 = Gen.GetShowApprovalandFeesSUDA("150", Enterpriseid, RdFall_in_Municipal.SelectedValue);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
                dsv3 = Gen.GetShowApprovalandFeesGpFees("57", Enterpriseid, TxtBuilt_up_Area.Text.Trim(), ddlProp_intVillageid.SelectedValue, ddlLoc_of_unit.SelectedValue, Session["uid"].ToString().Trim());
                if (dsv3 != null && dsv3.Tables.Count > 0 && dsv3.Tables[0].Rows.Count > 0)
                {
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
            }
            if (ddlLoc_of_unit.SelectedValue == "10")
            {
                dsv3 = GetShowApprovalandFeesNUDA("156", Enterpriseid, RdFall_in_Municipal.SelectedValue);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
                dsv3 = Gen.GetShowApprovalandFeesGpFees("57", Enterpriseid, TxtBuilt_up_Area.Text.Trim(), ddlProp_intVillageid.SelectedValue, ddlLoc_of_unit.SelectedValue, Session["uid"].ToString().Trim());
                if (dsv3 != null && dsv3.Tables.Count > 0 && dsv3.Tables[0].Rows.Count > 0)
                {
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
            }
            if (ddlLoc_of_unit.SelectedValue == "11")
            {
                dsv3 = GetShowApprovalandFeesSUDAKHAMMAM("157", Enterpriseid, RdFall_in_Municipal.SelectedValue);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
                dsv3 = Gen.GetShowApprovalandFeesGpFees("57", Enterpriseid, TxtBuilt_up_Area.Text.Trim(), ddlProp_intVillageid.SelectedValue, ddlLoc_of_unit.SelectedValue, Session["uid"].ToString().Trim());
                if (dsv3 != null && dsv3.Tables.Count > 0 && dsv3.Tables[0].Rows.Count > 0)
                {
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
            }
            if (ddlLoc_of_unit.SelectedValue == "12")
            {
                dsv3 = GetShowApprovalandFeesSUDASIDDIPET("158", Enterpriseid, RdFall_in_Municipal.SelectedValue);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
                dsv3 = Gen.GetShowApprovalandFeesGpFees("57", Enterpriseid, TxtBuilt_up_Area.Text.Trim(), ddlProp_intVillageid.SelectedValue, ddlLoc_of_unit.SelectedValue, Session["uid"].ToString().Trim());
                if (dsv3 != null && dsv3.Tables.Count > 0 && dsv3.Tables[0].Rows.Count > 0)
                {
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
            }
            //if (ddlLoc_of_unit.SelectedValue == "13")
            //{
            //    dsv3 = GetShowApprovalandFeesFCDA("174", Enterpriseid, RdFall_in_Municipal.SelectedValue);
            //    dsv.Tables[0].Merge(dsv3.Tables[0]);
            //    dsv3 = Gen.GetShowApprovalandFeesGpFees("57", Enterpriseid, TxtBuilt_up_Area.Text.Trim(), ddlProp_intVillageid.SelectedValue, ddlLoc_of_unit.SelectedValue, Session["uid"].ToString().Trim());
            //    if (dsv3 != null && dsv3.Tables.Count > 0 && dsv3.Tables[0].Rows.Count > 0)
            //    {
            //        dsv.Tables[0].Merge(dsv3.Tables[0]);
            //    }
            //}
            //if (ddlLoc_of_unit.SelectedValue == "13")
            //{
            //    dsv3 = GetShowApprovalandFeesFCDAIBP("174", Enterpriseid, "2", TxtTot_Extent.Text, TxtHight_Build.Text);
            //    dsv.Tables[0].Merge(dsv3.Tables[0]);  // commented on 25/09/2024 - 05:09

            //    dsv3 = Gen.GetShowApprovalandFeesGpFees("57", Enterpriseid, TxtBuilt_up_Area.Text.Trim(), ddlProp_intVillageid.SelectedValue, ddlLoc_of_unit.SelectedValue, Session["uid"].ToString().Trim());
            //    if (dsv3 != null && dsv3.Tables.Count > 0 && dsv3.Tables[0].Rows.Count > 0)
            //    {
            //        dsv.Tables[0].Merge(dsv3.Tables[0]);
            //    }
            //}
            if (ddlLoc_of_unit.SelectedValue == "13" && (ddlAppl_Type.SelectedValue != "0" && ddlAppl_Type.SelectedItem.Text != "--Select--"))
            {
                if (ddlAppl_Type.SelectedValue == "1")
                {
                    dsv3 = Gen.GetShowApprovalandFeesHMDACLUandBuilding("6", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
                else if (ddlAppl_Type.SelectedValue == "2")
                {
                    dsv3 = GetShowApprovalandFeesFCDAIBP("174", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);  // commented on 25/09/2024 - 05:09

                    dsv3 = Gen.GetShowApprovalandFeesGpFees("57", Enterpriseid, TxtBuilt_up_Area.Text.Trim(), ddlProp_intVillageid.SelectedValue, ddlLoc_of_unit.SelectedValue, Session["uid"].ToString().Trim());
                    if (dsv3 != null && dsv3.Tables.Count > 0 && dsv3.Tables[0].Rows.Count > 0)
                    {
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                }
                else if (ddlAppl_Type.SelectedValue == "3")
                {
                    dsv3 = Gen.GetShowApprovalandFeesHMDACLUandBuilding("6", Enterpriseid, "1", TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);

                    dsv3 = GetShowApprovalandFeesFCDAIBP("174", Enterpriseid, "2", TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);  // commented on 25/09/2024 - 05:09

                    dsv3 = Gen.GetShowApprovalandFeesGpFees("57", Enterpriseid, TxtBuilt_up_Area.Text.Trim(), ddlProp_intVillageid.SelectedValue, ddlLoc_of_unit.SelectedValue, Session["uid"].ToString().Trim());
                    if (dsv3 != null && dsv3.Tables.Count > 0 && dsv3.Tables[0].Rows.Count > 0)
                    {
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                }


            }

            if (ddlLoc_of_unit.SelectedValue == "14" && (ddlAppl_Type.SelectedValue != "0" && ddlAppl_Type.SelectedItem.Text != "--Select--"))
            {
                if (ddlAppl_Type.SelectedValue == "1")
                {
                    dsv3 = Gen.GetShowApprovalandFeesHMDACLUandBuilding("6", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
                else if (ddlAppl_Type.SelectedValue == "2")
                {
                    dsv3 = GetShowApprovalandFeesCMCIBP("175", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);  // commented on 25/09/2024 - 05:09

                    dsv3 = Gen.GetShowApprovalandFeesGpFees("57", Enterpriseid, TxtBuilt_up_Area.Text.Trim(), ddlProp_intVillageid.SelectedValue, ddlLoc_of_unit.SelectedValue, Session["uid"].ToString().Trim());
                    if (dsv3 != null && dsv3.Tables.Count > 0 && dsv3.Tables[0].Rows.Count > 0)
                    {
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                }
                else if (ddlAppl_Type.SelectedValue == "3")
                {
                    dsv3 = Gen.GetShowApprovalandFeesHMDACLUandBuilding("6", Enterpriseid, "1", TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);

                    dsv3 = GetShowApprovalandFeesCMCIBP("175", Enterpriseid, "2", TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);  // commented on 25/09/2024 - 05:09

                    dsv3 = Gen.GetShowApprovalandFeesGpFees("57", Enterpriseid, TxtBuilt_up_Area.Text.Trim(), ddlProp_intVillageid.SelectedValue, ddlLoc_of_unit.SelectedValue, Session["uid"].ToString().Trim());
                    if (dsv3 != null && dsv3.Tables.Count > 0 && dsv3.Tables[0].Rows.Count > 0)
                    {
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                }


            }

            if (ddlLoc_of_unit.SelectedValue == "15" && (ddlAppl_Type.SelectedValue != "0" && ddlAppl_Type.SelectedItem.Text != "--Select--"))
            {
                if (ddlAppl_Type.SelectedValue == "1")
                {
                    dsv3 = Gen.GetShowApprovalandFeesHMDACLUandBuilding("6", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
                else if (ddlAppl_Type.SelectedValue == "2")
                {
                    dsv3 = GetShowApprovalandFeesMMCIBP("176", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);  // commented on 25/09/2024 - 05:09

                    dsv3 = Gen.GetShowApprovalandFeesGpFees("57", Enterpriseid, TxtBuilt_up_Area.Text.Trim(), ddlProp_intVillageid.SelectedValue, ddlLoc_of_unit.SelectedValue, Session["uid"].ToString().Trim());
                    if (dsv3 != null && dsv3.Tables.Count > 0 && dsv3.Tables[0].Rows.Count > 0)
                    {
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                }
                else if (ddlAppl_Type.SelectedValue == "3")
                {
                    dsv3 = Gen.GetShowApprovalandFeesHMDACLUandBuilding("6", Enterpriseid, "1", TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);

                    dsv3 = GetShowApprovalandFeesMMCIBP("176", Enterpriseid, "2", TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);  // commented on 25/09/2024 - 05:09

                    dsv3 = Gen.GetShowApprovalandFeesGpFees("57", Enterpriseid, TxtBuilt_up_Area.Text.Trim(), ddlProp_intVillageid.SelectedValue, ddlLoc_of_unit.SelectedValue, Session["uid"].ToString().Trim());
                    if (dsv3 != null && dsv3.Tables.Count > 0 && dsv3.Tables[0].Rows.Count > 0)
                    {
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                }


            }
            if (ddlLoc_of_unit.SelectedValue == "3")
            {
                dsv3 = Gen.GetShowApprovalandFees("30", Enterpriseid);
                dsv.Tables[0].Merge(dsv3.Tables[0]);

            }
            if (ddlLoc_of_unit.SelectedValue == "4")
            {
                //dsv3 = Gen.GetShowApprovalandFees("31", Enterpriseid);
                dsv3 = Gen.GetShowApprovalandFeesTSIIC("31", Enterpriseid, Session["Applid"].ToString(), TxtBuilt_up_Area.Text.Trim(), TxtTot_Extent.Text.Trim());
                dsv.Tables[0].Merge(dsv3.Tables[0]);

            }
            if (ddlLoc_of_unit.SelectedValue == "5")
            {
                if (ddlAppl_Type.SelectedValue == "1")
                {
                    dsv3 = Gen.GetShowApprovalandFeesHMDACLUandBuilding("6", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
                else if (ddlAppl_Type.SelectedValue == "2")
                {
                    dsv3 = Gen.GetShowApprovalandFees("38", Enterpriseid);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
                else if (ddlAppl_Type.SelectedValue == "3")
                {
                    dsv3 = Gen.GetShowApprovalandFeesHMDACLUandGHMCBuildingBoth("6", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
                else
                {
                    dsv3 = Gen.GetShowApprovalandFeesHMDACLUandGHMCBuildingBoth("6", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
            }
            //if (ddlLoc_of_unit.SelectedValue == "6")
            //{
            //    dsv3 = Gen.GetShowApprovalandFees("43", Enterpriseid);
            //    dsv.Tables[0].Merge(dsv3.Tables[0]);
            //}
            DataSet dsv4 = new DataSet();
            dsv4 = Gen.GetShowApprovalandFeesEnterPriseAmount("33", Enterpriseid, TxtVal_Plantnewfinal, strTot_PrjCost, "0");
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
                    dsv.Tables[0].Merge(dsv3.Tables[0]);  // commented on 25/09/2024 - 05:09

                    dsv3 = Gen.GetShowApprovalandFeesGpFees("57", Enterpriseid, TxtBuilt_up_Area.Text.Trim(), ddlProp_intVillageid.SelectedValue, ddlLoc_of_unit.SelectedValue, Session["uid"].ToString().Trim());
                    if (dsv3 != null && dsv3.Tables.Count > 0 && dsv3.Tables[0].Rows.Count > 0)
                    {
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                }
                else if (ddlAppl_Type.SelectedValue == "3")
                {
                    dsv3 = Gen.GetShowApprovalandFeesHMDACLUandBuildingBoth("6", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);

                    dsv3 = Gen.GetShowApprovalandFeesGpFees("57", Enterpriseid, TxtBuilt_up_Area.Text.Trim(), ddlProp_intVillageid.SelectedValue, ddlLoc_of_unit.SelectedValue, Session["uid"].ToString().Trim());
                    if (dsv3 != null && dsv3.Tables.Count > 0 && dsv3.Tables[0].Rows.Count > 0)
                    {
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                }
                else
                {
                    dsv3 = Gen.GetShowApprovalandFeesHMDACLUandBuildingBoth("6", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
            }

            if (ddlLoc_of_unit.SelectedValue != "4")  // No use of this method
            {
                if (rdIaLa_Lst.SelectedValue == "N")
                {
                    //28 feb 2022
                    if (ddlProp_intDistrictid.SelectedValue != "--District--")
                    {
                        //dsv3 = Gen.GetShowApprovalandFeesNALA_newdharani("34", Enterpriseid, ddlProp_intDistrictid.SelectedValue, txtmarketvalue.Text.Trim(), ddlcurrencytype.SelectedItem.Text, ddlProp_intMandalid.SelectedValue, Convert.ToString(Session["uid"]));
                        ////dsv3 = Gen.GetShowApprovalandFeesNALA("34", Enterpriseid, ddlProp_intDistrictid.SelectedValue, txtmarketvalue.Text.Trim(), ddlcurrencytype.SelectedItem.Text, ddlProp_intMandalid.SelectedValue);
                        //dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                }
            }
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

            //if (RdbExecpted0.SelectedValue == "Y")
            //{
            //    dsLabour = Gen.GetShowApprovalandFeesLabour("48", Enterpriseid, ddlProp_intDistrictid.SelectedValue, "3", txtContractLabourAct.Text.Trim().TrimStart());
            //    dsv.Tables[0].Merge(dsLabour.Tables[0]);
            //}
            //DataSet dsLabour1 = new DataSet();
            //if (RdbExecpted1.SelectedValue == "Y")
            //{
            //    dsLabour1 = Gen.GetShowApprovalandFeesLabour("49", Enterpriseid, ddlProp_intDistrictid.SelectedValue, "4", txtMigrantWorkmanAct.Text.Trim().TrimStart());
            //    dsv.Tables[0].Merge(dsLabour1.Tables[0]);
            //}
            //DataSet dsLabour3 = new DataSet();
            //if (RdbExecpted2.SelectedValue == "Y")
            //{
            //    dsLabour3 = Gen.GetShowApprovalandFeesLabour("47", Enterpriseid, ddlProp_intDistrictid.SelectedValue, "2", txtNoofworkers.Text.Trim().TrimStart());
            //    dsv.Tables[0].Merge(dsLabour3.Tables[0]);
            //}
            //ADEED BY MADHURI ON 11/10/2022 FOR harithaNIDHI
            DataSet dslabourharitha = new DataSet();
            DataSet dslabourharitha1 = new DataSet();
            DataSet dslabourharitha2 = new DataSet();
            if (RdbExecpted0.SelectedValue == "Y")
            {
                dsLabour = Gen.GetShowApprovalandFeesLabour("48", Enterpriseid, ddlProp_intDistrictid.SelectedValue, "3", txtContractLabourAct.Text.Trim().TrimStart());
                dsv.Tables[0].Merge(dsLabour.Tables[0]);
                if (dsLabour.Tables[1].Rows.Count > 0)
                {
                    dslabourharitha = Gen.GetShowApprovalandFeesLabour("48", Enterpriseid, ddlProp_intDistrictid.SelectedValue, "3", txtContractLabourAct.Text.Trim().TrimStart());
                    dsv.Tables[0].Merge(dslabourharitha.Tables[1]);
                }

            }
            DataSet dsLabour1 = new DataSet();
            if (RdbExecpted1.SelectedValue == "Y")
            {
                dsLabour1 = Gen.GetShowApprovalandFeesLabour("49", Enterpriseid, ddlProp_intDistrictid.SelectedValue, "4", txtMigrantWorkmanAct.Text.Trim().TrimStart());
                dsv.Tables[0].Merge(dsLabour1.Tables[0]);
                if (dsLabour1.Tables[1].Rows.Count > 0)
                {
                    dslabourharitha1 = Gen.GetShowApprovalandFeesLabour("49", Enterpriseid, ddlProp_intDistrictid.SelectedValue, "4", txtMigrantWorkmanAct.Text.Trim().TrimStart());
                    dsv.Tables[0].Merge(dslabourharitha1.Tables[1]);
                }
            }
            DataSet dsLabour3 = new DataSet();
            if (RdbExecpted2.SelectedValue == "Y")
            {
                dsLabour3 = Gen.GetShowApprovalandFeesLabour("47", Enterpriseid, ddlProp_intDistrictid.SelectedValue, "2", txtNoofworkers.Text.Trim().TrimStart());
                dsv.Tables[0].Merge(dsLabour3.Tables[0]);
                if (dsLabour3.Tables[1].Rows.Count > 0)
                {
                    dslabourharitha2 = Gen.GetShowApprovalandFeesLabour("47", Enterpriseid, ddlProp_intDistrictid.SelectedValue, "2", txtNoofworkers.Text.Trim().TrimStart());
                    dsv.Tables[0].Merge(dslabourharitha2.Tables[1]);
                }
            }
            ///////////////END OF ADDED CODE BY MADHURI ON 11/10/2022
            DataSet dsLabour2 = new DataSet();
            if (RdbExecptedactShop.SelectedValue == "Y")
            {
                // yyyy-MM-dd
                //string[] newdate = txtDateofCommenceAct1.Text.ToString().Split('-');
                //string date = newdate[1].ToString() + "/" + newdate[2].ToString() + "/" + newdate[0].ToString();
                //dsLabour2 = Gen.GetShowApprovalandFeesLabouract1("52", Enterpriseid, ddlProp_intDistrictid.SelectedValue, "1", txtNoofworkers.Text.Trim().TrimStart(), date);
                //dsv.Tables[0].Merge(dsLabour2.Tables[0]);
                string[] newdate = txtDateofCommenceAct1.Text.ToString().Split('-');
                string date = newdate[0].ToString() + "/" + newdate[1].ToString() + "/" + newdate[2].ToString();
                string date1 = newdate[1].ToString() + "/" + newdate[0].ToString() + "/" + newdate[2].ToString();
                int empcount = Convert.ToInt32(txtliccontractor.Text.Trim());
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

                    string valid = InsertLabourShopServiceDetails(labourservicevo, output);
                }
                dsLabour2 = Gen.GetShowApprovalandFeesLabouract1("66", Enterpriseid, ddlProp_intDistrictid.SelectedValue, "7", txtliccontractor.Text.Trim().TrimStart(), date1, Session["uid"].ToString().Trim());
                dsv.Tables[0].Merge(dsLabour2.Tables[0]);
            }

            //20d

            ///added by madhuri on 27/10/2017 for new approval///
            ///
            if (rdvicinitywaterbody.SelectedValue == "Y")
            {
                dsv3 = Gen.GetShowApprovalandFees("59", Enterpriseid);
                //dsv3 = Gen.GetShowApprovalandFeesDistincts("60", Enterpriseid, ddlProp_intDistrictid.SelectedValue);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }
            if (rdvicinitywaterbody.SelectedValue == "Y")
            {
                //dsv3 = Gen.GetShowApprovalandFees("59", Enterpriseid);
                dsv3 = Gen.GetShowApprovalandFeesDistincts("60", Enterpriseid, ddlProp_intDistrictid.SelectedValue);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }

            DataSet dsLabour8 = new DataSet();
            if (Rdb20d.SelectedValue == "Y")
            {
                dsLabour8 = Gen.GetShowApprovalandFeesLabour("58", Enterpriseid, ddlProp_intDistrictid.SelectedValue, "5", txtNoofworkers20d.Text.Trim().TrimStart());
                dsv.Tables[0].Merge(dsLabour8.Tables[0]);
            }

            //DataSet dsLabour4 = new DataSet();
            //if (Rdbact5License.SelectedValue == "Y")
            //{
            //    dsLabour4 = Gen.GetShowApprovalandFeesLabour("66", Enterpriseid, ddlProp_intDistrictid.SelectedValue, "6", txtact5emp.Text.Trim().TrimStart());
            //    dsv.Tables[0].Merge(dsLabour4.Tables[0]);
            //}
            DataSet dsLegal = new DataSet();

            //if (rbtnLstLabel.SelectedValue == "Y")
            //{
            //    dsLegal = Gen.GetShowApprovalandFeesLegal("0", Enterpriseid, ddlProp_intDistrictid.SelectedValue);
            //    dsv.Tables[0].Merge(dsLegal.Tables[0]);
            //}

            DataSet dsceigdrawings = new DataSet();
            if (RdpIndustry.SelectedValue == "Y")
            {
                dsceigdrawings = Gen.GetShowApprovalandFeesCEIGCFE("65", Enterpriseid, ddlregulation.SelectedValue, ddlvoltage.SelectedValue, ddlproposal.SelectedItem.Text, txtagrcapacity.Text.Trim());
                dsv.Tables[0].Merge(dsceigdrawings.Tables[0]);
            }

            DataSet dsprofessiontax = new DataSet();
            if (rdprofessiontax.SelectedValue == "Y")
            {
                dsprofessiontax = Gen.GetShowApprovalandFees("72", Enterpriseid);
                dsv.Tables[0].Merge(dsprofessiontax.Tables[0]);
            }

            DataSet dsexcise = new DataSet();
            if (rdexcise.SelectedValue == "Y")
            {
                dsexcise = Gen.GetShowApprovalandFees("75", Enterpriseid);
                dsv.Tables[0].Merge(dsexcise.Tables[0]);
            }

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
            //    dvfeedetails.Visible = true;
            //}
            //else
            //{
            //    grdDetails.DataSource = null;
            //    grdDetails.DataBind();
            //    dvfeedetails.Visible = false;
            //}


        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
        finally
        {
        }

    }
    //20d
    protected void Rdb20d_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Rdb20d.SelectedValue == "Y")
        {
            tr20d.Visible = true;
        }
        else
        {
            tr20d.Visible = false;
            txtNoofworkers20d.Text = "";
        }
    }
    public void CalcFeesNewDepartment()
    {

        try
        {
            if (Session["uid"].ToString() == "259911")
            {
                HdfLblPol_Category.Value = "Red";
            }
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

                // dsMunicial = Gen.GetShowApprovalandFees("2", Enterpriseid);  //commented as GP NOC is not necessary.
                // dsv.Tables[0].Merge(dsMunicial.Tables[0]);

            }
            DataSet dsv1 = new DataSet();
            //if (ddlPower_Req.SelectedIndex == 1)
            //{

            //    dsv1 = Gen.GetShowApprovalandFees("21", Enterpriseid);
            //    dsv.Tables[0].Merge(dsv1.Tables[0]);
            //}
            //else 

            //if (ddlPower_Req.SelectedIndex == 2)    //commented nikhil
            //{

            //    dsv1 = Gen.GetShowApprovalandFees("5", Enterpriseid);
            //    dsv.Tables[0].Merge(dsv1.Tables[0]);
            //}
            //else if (ddlPower_Req.SelectedIndex == 3)   //commented nikhil
            //{

            //    dsv1 = Gen.GetShowApprovalandFees("21", Enterpriseid);
            //    dsv.Tables[0].Merge(dsv1.Tables[0]);

            //}

            if (ddlPower_Req.SelectedIndex == 2 || ddlPower_Req.SelectedIndex == 3)
            {

                dsv1 = Gen.GetShowApprovalandFeesFactory("5", Enterpriseid, Convert.ToString(ddlPower_Req.SelectedIndex), Session["uid"].ToString().Trim());
                dsv.Tables[0].Merge(dsv1.Tables[0]);
            }
            else if (ddlPower_Req.SelectedIndex == 5 || ddlPower_Req.SelectedIndex == 6)
            {

                dsv1 = Gen.GetShowApprovalandFeesFactory("21", Enterpriseid, Convert.ToString(ddlPower_Req.SelectedIndex), Session["uid"].ToString().Trim());
                dsv.Tables[0].Merge(dsv1.Tables[0]);

            }
            else if (ddlPower_Req.SelectedIndex == 4)
            {
                dsv1 = Gen.GetShowApprovalandFeesFactory("44", Enterpriseid, Convert.ToString(ddlPower_Req.SelectedIndex), Session["uid"].ToString().Trim());
                dsv.Tables[0].Merge(dsv1.Tables[0]);
            }



            DataSet dsv2 = new DataSet();
            if (ddlProp_intDistrictid.SelectedValue == "1" || ddlProp_intDistrictid.SelectedValue == "2" || ddlProp_intDistrictid.SelectedValue == "3" || ddlProp_intDistrictid.SelectedValue == "9" || ddlProp_intDistrictid.SelectedValue == "10" || ddlProp_intDistrictid.SelectedValue == "11" || ddlProp_intDistrictid.SelectedValue == "12" || ddlProp_intDistrictid.SelectedValue == "14" || ddlProp_intDistrictid.SelectedValue == "15" || ddlProp_intDistrictid.SelectedValue == "16" || ddlProp_intDistrictid.SelectedValue == "17" || ddlProp_intDistrictid.SelectedValue == "18" || ddlProp_intDistrictid.SelectedValue == "19" || ddlProp_intDistrictid.SelectedValue == "22" || ddlProp_intDistrictid.SelectedValue == "23" || ddlProp_intDistrictid.SelectedValue == "26" || ddlProp_intDistrictid.SelectedValue == "30")
            {

                dsv2 = Gen.GetShowApprovalandFees("4", Enterpriseid);
                dsv.Tables[0].Merge(dsv2.Tables[0]);

                DataSet dscess = Gen.getCESSVillages(ddlProp_intVillageid.SelectedValue);
                //   if (dscess.Tables[0].Rows.Count > 0) commented on 08062026
                if (dscess.Tables[0].Rows.Count > 0 && (HDNDATEOFPAYMENT.Value != null && HDNDATEOFPAYMENT.Value != "" && DateTime.ParseExact(HDNDATEOFPAYMENT.Value, "dd-MM-yyyy", CultureInfo.InvariantCulture) <= DateTime.ParseExact("07-06-2026", "dd-MM-yyyy", CultureInfo.InvariantCulture))
                       && (HDNCESSAPPROVED.Value != "" && HDNCESSAPPROVED.Value != null) && !new[] { "155520", "155444", "155395", "155384", "155390", "155077", "154688", "154572" }.Contains(HDNCESSQUESTIONNAIREID.Value))



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
            string TxtVal_Plantnewfinal = "0";
            if (ddlproposal.SelectedValue == "1")
            {
                strTot_PrjCost = TxtTot_PrjCost.Text;
                TxtVal_Plantnewfinal = TxtVal_Plant.Text;
            }
            else if (ddlproposal.SelectedValue == "2")
            {
                strTot_PrjCost = txtlbltotalprojectcostexpanstion.Text;
                TxtVal_Plantnewfinal = lblplantotalexp.Text;
            }
            if (HdfLblPol_Category.Value == "Red")
            {
                dsv3 = Gen.GetShowApprovalandFeesPCBNew("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost, Session["Applid"].ToString());
                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }
            else if (HdfLblPol_Category.Value == "Green")
            {
                if (HdfLblEnt_is.Value == "Small" || HdfLblEnt_is.Value == "Micro")
                {
                    if (RdPol_Indus.SelectedValue.ToString().Trim() == "Y")
                    {

                        dsv3 = Gen.GetShowApprovalandFeesPCBNew("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost, Session["Applid"].ToString());
                        dsv.Tables[0].Merge(dsv3.Tables[0]);

                    }
                    else if (RdPol_Indus.SelectedValue.ToString().Trim() == "N")
                    {

                        //dsv3 = Gen.GetShowApprovalandFeesPCBDIC("3", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, TxtTot_PrjCost.Text, ddlProp_intDistrictid.SelectedValue);
                        //dsv.Tables[0].Merge(dsv3.Tables[0]);
                        dsv3 = Gen.GetShowApprovalandFeesPCBNew("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost, Session["Applid"].ToString());
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                }
                else
                {
                    dsv3 = Gen.GetShowApprovalandFeesPCBNew("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost, Session["Applid"].ToString());
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

                        dsv3 = Gen.GetShowApprovalandFeesPCBNew("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost, Session["Applid"].ToString());
                        dsv.Tables[0].Merge(dsv3.Tables[0]);

                    }
                    else if (RdPol_Indus.SelectedValue.ToString().Trim() == "N")
                    {

                        //dsv3 = Gen.GetShowApprovalandFeesPCBDIC("3", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, TxtTot_PrjCost.Text, ddlProp_intDistrictid.SelectedValue);
                        //dsv.Tables[0].Merge(dsv3.Tables[0]);

                        dsv3 = Gen.GetShowApprovalandFeesPCBNew("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost, Session["Applid"].ToString());
                        dsv.Tables[0].Merge(dsv3.Tables[0]);


                    }
                }
                else
                {
                    dsv3 = Gen.GetShowApprovalandFeesPCBNew("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, strTot_PrjCost, Session["Applid"].ToString());
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                    //dsv3 = Gen.GetShowApprovalandFeesPCB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, TxtVal_Plant.Text);
                    //dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
                //dsv3 = Gen.GetShowApprovalandFeesPCB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, TxtTot_PrjCost.Text);
                //dsv.Tables[0].Merge(dsv3.Tables[0]);
            }

            // commented by shankar
            //if (ChkWater_reg_from.Items[0].Selected == true)
            //{
            //    dsv3 = Gen.GetShowApprovalandFeesGroundWater("9", Enterpriseid, TxtWater_req_Perday.Text, TxtTot_Extent.Text);
            //    dsv.Tables[0].Merge(dsv3.Tables[0]);
            //}
            //if (ChkWater_reg_from.Items[1].Selected == true)
            //{
            //    dsv3 = Gen.GetShowApprovalandFeesHWS("10", Enterpriseid);
            //    dsv.Tables[0].Merge(dsv3.Tables[0]);
            //}
            //if (ChkWater_reg_from.Items[2].Selected == true)
            //{
            //    dsv3 = Gen.GetShowApprovalandFees("11", Enterpriseid);
            //    dsv.Tables[0].Merge(dsv3.Tables[0]);
            //}
            if (rdo_borewell.SelectedValue != "Y")
            {
                foreach (GridViewRow gvrTEMPVehMstr in gvmodelsnames.Rows)
                {
                    CheckBox txtMakerGvV = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                    TextBox txtwaterrequired = (TextBox)gvrTEMPVehMstr.FindControl("txtwaterrequired");
                    if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 0)
                    {
                        dsv3 = Gen.GetShowApprovalandFeesGroundWater("9", Enterpriseid, txtwaterrequired.Text, TxtTot_Extent.Text);
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                    if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 1)
                    {
                        dsv3 = Gen.GetShowApprovalandFeesHWS("10", Enterpriseid);
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                    if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 2)
                    {
                        dsv3 = Gen.GetShowApprovalandFees("11", Enterpriseid, Session["Applid"].ToString());
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                    if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 3)
                    {
                        //dsv3 = Gen.GetShowApprovalandFees("70", Enterpriseid);
                        //dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                    if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 4)
                    {
                        dsv3 = Gen.GetShowApprovalandFees("71", Enterpriseid);
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                    txtMakerGvV = null;
                }
            }
            else
            {
                foreach (GridViewRow gvrTEMPVehMstr in gvmodelsnames.Rows)
                {
                    CheckBox txtMakerGvV = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                    TextBox txtwaterrequired = (TextBox)gvrTEMPVehMstr.FindControl("txtwaterrequired");
                    //if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 0)
                    //{
                    //    dsv3 = Gen.GetShowApprovalandFeesGroundWater("9", Enterpriseid, txtwaterrequired.Text, TxtTot_Extent.Text);
                    //    dsv.Tables[0].Merge(dsv3.Tables[0]);
                    //}
                    if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 0)
                    {
                        dsv3 = Gen.GetShowApprovalandFeesHWS("10", Enterpriseid);
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                    if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 1)
                    {
                        dsv3 = Gen.GetShowApprovalandFees("11", Enterpriseid, Session["Applid"].ToString());
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                    if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 2)
                    {
                        //dsv3 = Gen.GetShowApprovalandFees("70", Enterpriseid);
                        //dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                    if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 3)
                    {
                        dsv3 = Gen.GetShowApprovalandFees("71", Enterpriseid);
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                    txtMakerGvV = null;
                }
            }
            if (RdDo_Store_Kerosine.SelectedValue == "Y")
            {
                if (ddlProp_intDistrictid.SelectedItem.Text == "Rangareddy")
                {

                    if (ddlProp_intMandalid.SelectedItem.Text == "Rajendranagar" || ddlProp_intMandalid.SelectedItem.Text == "Moinabad" || ddlProp_intMandalid.SelectedItem.Text == "Shamshabad" || ddlProp_intMandalid.SelectedItem.Text == "Chevella" || ddlProp_intMandalid.SelectedItem.Text == "Shankarpalle" || ddlProp_intMandalid.SelectedItem.Text == "Shabad" ||
                        ddlProp_intMandalid.SelectedItem.Text == "Farooqnagar" || ddlProp_intMandalid.SelectedItem.Text == "Keshampet" ||
                        ddlProp_intMandalid.SelectedItem.Text == "Kondurg" || ddlProp_intMandalid.SelectedItem.Text == "Kothur" ||
                        ddlProp_intMandalid.SelectedItem.Text == "Nandigama" || ddlProp_intMandalid.SelectedItem.Text == "Amangal" ||
                        ddlProp_intMandalid.SelectedItem.Text == "Kadthal" || ddlProp_intMandalid.SelectedItem.Text == "Serilingampally"
                        || ddlProp_intMandalid.SelectedItem.Text == "Gandipet")
                    {
                        dsv1 = Gen.GetShowApprovalandFeesFactory("32", "21", "6", Session["uid"].ToString().Trim());
                        dsv.Tables[0].Merge(dsv1.Tables[0]);
                    }
                    else if (ddlProp_intMandalid.SelectedItem.Text == "Saroornagar" || ddlProp_intMandalid.SelectedItem.Text == "Hayathnagar" || ddlProp_intMandalid.SelectedItem.Text == "Abdullapurmet" || ddlProp_intMandalid.SelectedItem.Text == "Balapur" || ddlProp_intMandalid.SelectedItem.Text == "Ibrahimpatnam" || ddlProp_intMandalid.SelectedItem.Text == "Manchal" ||
                        ddlProp_intMandalid.SelectedItem.Text == "Yacharam" || ddlProp_intMandalid.SelectedItem.Text == "Maheswaram" ||
                        ddlProp_intMandalid.SelectedItem.Text == "Kandukur" || ddlProp_intMandalid.SelectedItem.Text == "Madgul")
                    {
                        dsv1 = Gen.GetShowApprovalandFeesFactory("32", "22", "6", Session["uid"].ToString().Trim());
                        dsv.Tables[0].Merge(dsv1.Tables[0]);
                    }
                    else
                    {
                        dsv3 = Gen.GetShowApprovalandFeesDistincts("32", Enterpriseid, ddlProp_intDistrictid.SelectedValue);
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                }
                else
                {
                    dsv3 = Gen.GetShowApprovalandFeesDistincts("32", Enterpriseid, ddlProp_intDistrictid.SelectedValue);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
            }
            if (RdDo_Store_Kerosine0.SelectedValue == "Y")
            {
                if (ddlProp_intDistrictid.SelectedItem.Text == "Rangareddy")
                {

                    if (ddlProp_intMandalid.SelectedItem.Text == "Rajendranagar" || ddlProp_intMandalid.SelectedItem.Text == "Moinabad" || ddlProp_intMandalid.SelectedItem.Text == "Shamshabad" || ddlProp_intMandalid.SelectedItem.Text == "Chevella" || ddlProp_intMandalid.SelectedItem.Text == "Shankarpalle" || ddlProp_intMandalid.SelectedItem.Text == "Shabad" ||
                        ddlProp_intMandalid.SelectedItem.Text == "Farooqnagar" || ddlProp_intMandalid.SelectedItem.Text == "Keshampet" ||
                        ddlProp_intMandalid.SelectedItem.Text == "Kondurg" || ddlProp_intMandalid.SelectedItem.Text == "Kothur" ||
                        ddlProp_intMandalid.SelectedItem.Text == "Nandigama" || ddlProp_intMandalid.SelectedItem.Text == "Amangal" ||
                        ddlProp_intMandalid.SelectedItem.Text == "Kadthal" || ddlProp_intMandalid.SelectedItem.Text == "Serilingampally"
                        || ddlProp_intMandalid.SelectedItem.Text == "Gandipet")
                    {
                        dsv1 = Gen.GetShowApprovalandFeesFactory("102", "21", "6", Session["uid"].ToString().Trim());
                        dsv.Tables[0].Merge(dsv1.Tables[0]);
                    }
                    else if (ddlProp_intMandalid.SelectedItem.Text == "Saroornagar" || ddlProp_intMandalid.SelectedItem.Text == "Hayathnagar" || ddlProp_intMandalid.SelectedItem.Text == "Abdullapurmet" || ddlProp_intMandalid.SelectedItem.Text == "Balapur" || ddlProp_intMandalid.SelectedItem.Text == "Ibrahimpatnam" || ddlProp_intMandalid.SelectedItem.Text == "Manchal" ||
                        ddlProp_intMandalid.SelectedItem.Text == "Yacharam" || ddlProp_intMandalid.SelectedItem.Text == "Maheswaram" ||
                        ddlProp_intMandalid.SelectedItem.Text == "Kandukur" || ddlProp_intMandalid.SelectedItem.Text == "Madgul")
                    {
                        dsv1 = Gen.GetShowApprovalandFeesFactory("102", "22", "6", Session["uid"].ToString().Trim());
                        dsv.Tables[0].Merge(dsv1.Tables[0]);
                    }
                    else
                    {
                        dsv3 = Gen.GetShowApprovalandFeesDistincts("102", Enterpriseid, ddlProp_intDistrictid.SelectedValue);
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                }
                else
                {
                    dsv3 = Gen.GetShowApprovalandFeesDistincts("102", Enterpriseid, ddlProp_intDistrictid.SelectedValue);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
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
                dsv3 = Gen.GetShowApprovalandFeesEnterPriseAmount("28", Enterpriseid, TxtVal_Plantnewfinal, strTot_PrjCost, Txt_NoofTrees.Text);
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
                dsv.Tables[0].Merge(dsv3.Tables[0]); //commented on 25 / 09 / 2024 - 05:09

                dsv3 = Gen.GetShowApprovalandFeesGpFees("57", Enterpriseid, TxtBuilt_up_Area.Text.Trim(), ddlProp_intVillageid.SelectedValue, ddlLoc_of_unit.SelectedValue, Session["uid"].ToString().Trim());
                if (dsv3 != null && dsv3.Tables.Count > 0 && dsv3.Tables[0].Rows.Count > 0)
                {
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
            }
            if (ddlLoc_of_unit.SelectedValue == "9")
            {
                dsv3 = Gen.GetShowApprovalandFeesSUDA("150", Enterpriseid, RdFall_in_Municipal.SelectedValue);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
                dsv3 = Gen.GetShowApprovalandFeesGpFees("57", Enterpriseid, TxtBuilt_up_Area.Text.Trim(), ddlProp_intVillageid.SelectedValue, ddlLoc_of_unit.SelectedValue, Session["uid"].ToString().Trim());
                if (dsv3 != null && dsv3.Tables.Count > 0 && dsv3.Tables[0].Rows.Count > 0)
                {
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
            }
            if (ddlLoc_of_unit.SelectedValue == "10")
            {
                dsv3 = GetShowApprovalandFeesNUDA("156", Enterpriseid, RdFall_in_Municipal.SelectedValue);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
                dsv3 = Gen.GetShowApprovalandFeesGpFees("57", Enterpriseid, TxtBuilt_up_Area.Text.Trim(), ddlProp_intVillageid.SelectedValue, ddlLoc_of_unit.SelectedValue, Session["uid"].ToString().Trim());
                if (dsv3 != null && dsv3.Tables.Count > 0 && dsv3.Tables[0].Rows.Count > 0)
                {
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
            }
            if (ddlLoc_of_unit.SelectedValue == "11")
            {
                dsv3 = GetShowApprovalandFeesSUDAKHAMMAM("157", Enterpriseid, RdFall_in_Municipal.SelectedValue);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
                dsv3 = Gen.GetShowApprovalandFeesGpFees("57", Enterpriseid, TxtBuilt_up_Area.Text.Trim(), ddlProp_intVillageid.SelectedValue, ddlLoc_of_unit.SelectedValue, Session["uid"].ToString().Trim());
                if (dsv3 != null && dsv3.Tables.Count > 0 && dsv3.Tables[0].Rows.Count > 0)
                {
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
            }
            if (ddlLoc_of_unit.SelectedValue == "12")
            {
                dsv3 = GetShowApprovalandFeesSUDASIDDIPET("158", Enterpriseid, RdFall_in_Municipal.SelectedValue);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
                dsv3 = Gen.GetShowApprovalandFeesGpFees("57", Enterpriseid, TxtBuilt_up_Area.Text.Trim(), ddlProp_intVillageid.SelectedValue, ddlLoc_of_unit.SelectedValue, Session["uid"].ToString().Trim());
                if (dsv3 != null && dsv3.Tables.Count > 0 && dsv3.Tables[0].Rows.Count > 0)
                {
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
            }
            //if (ddlLoc_of_unit.SelectedValue == "13")
            //{
            //    dsv3 = GetShowApprovalandFeesFCDA("174", Enterpriseid, RdFall_in_Municipal.SelectedValue);
            //    dsv.Tables[0].Merge(dsv3.Tables[0]);
            //    dsv3 = Gen.GetShowApprovalandFeesGpFees("57", Enterpriseid, TxtBuilt_up_Area.Text.Trim(), ddlProp_intVillageid.SelectedValue, ddlLoc_of_unit.SelectedValue, Session["uid"].ToString().Trim());
            //    if (dsv3 != null && dsv3.Tables.Count > 0 && dsv3.Tables[0].Rows.Count > 0)
            //    {
            //        dsv.Tables[0].Merge(dsv3.Tables[0]);
            //    }
            //}
            //if (ddlLoc_of_unit.SelectedValue == "13")
            //{
            //    dsv3 = GetShowApprovalandFeesFCDAIBP("174", Enterpriseid, "2", TxtTot_Extent.Text, TxtHight_Build.Text);
            //    dsv.Tables[0].Merge(dsv3.Tables[0]);  // commented on 25/09/2024 - 05:09

            //    dsv3 = Gen.GetShowApprovalandFeesGpFees("57", Enterpriseid, TxtBuilt_up_Area.Text.Trim(), ddlProp_intVillageid.SelectedValue, ddlLoc_of_unit.SelectedValue, Session["uid"].ToString().Trim());
            //    if (dsv3 != null && dsv3.Tables.Count > 0 && dsv3.Tables[0].Rows.Count > 0)
            //    {
            //        dsv.Tables[0].Merge(dsv3.Tables[0]);
            //    }
            //}
            if (ddlLoc_of_unit.SelectedValue == "13" && (ddlAppl_Type.SelectedValue != "0" && ddlAppl_Type.SelectedItem.Text != "--Select--"))
            {
                if (ddlAppl_Type.SelectedValue == "1")
                {
                    dsv3 = Gen.GetShowApprovalandFeesHMDACLUandBuilding("6", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
                else if (ddlAppl_Type.SelectedValue == "2")
                {
                    dsv3 = GetShowApprovalandFeesFCDAIBP("174", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);  // commented on 25/09/2024 - 05:09

                    dsv3 = Gen.GetShowApprovalandFeesGpFees("57", Enterpriseid, TxtBuilt_up_Area.Text.Trim(), ddlProp_intVillageid.SelectedValue, ddlLoc_of_unit.SelectedValue, Session["uid"].ToString().Trim());
                    if (dsv3 != null && dsv3.Tables.Count > 0 && dsv3.Tables[0].Rows.Count > 0)
                    {
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                }
                else if (ddlAppl_Type.SelectedValue == "3")
                {
                    dsv3 = Gen.GetShowApprovalandFeesHMDACLUandBuilding("6", Enterpriseid, "1", TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);

                    dsv3 = GetShowApprovalandFeesFCDAIBP("174", Enterpriseid, "2", TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);  // commented on 25/09/2024 - 05:09

                    dsv3 = Gen.GetShowApprovalandFeesGpFees("57", Enterpriseid, TxtBuilt_up_Area.Text.Trim(), ddlProp_intVillageid.SelectedValue, ddlLoc_of_unit.SelectedValue, Session["uid"].ToString().Trim());
                    if (dsv3 != null && dsv3.Tables.Count > 0 && dsv3.Tables[0].Rows.Count > 0)
                    {
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                }


            }
            if (ddlLoc_of_unit.SelectedValue == "14" && (ddlAppl_Type.SelectedValue != "0" && ddlAppl_Type.SelectedItem.Text != "--Select--"))
            {
                if (ddlAppl_Type.SelectedValue == "1")
                {
                    dsv3 = Gen.GetShowApprovalandFeesHMDACLUandBuilding("6", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
                else if (ddlAppl_Type.SelectedValue == "2")
                {
                    dsv3 = GetShowApprovalandFeesCMCIBP("175", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);  // commented on 25/09/2024 - 05:09

                    dsv3 = Gen.GetShowApprovalandFeesGpFees("57", Enterpriseid, TxtBuilt_up_Area.Text.Trim(), ddlProp_intVillageid.SelectedValue, ddlLoc_of_unit.SelectedValue, Session["uid"].ToString().Trim());
                    if (dsv3 != null && dsv3.Tables.Count > 0 && dsv3.Tables[0].Rows.Count > 0)
                    {
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                }
                else if (ddlAppl_Type.SelectedValue == "3")
                {
                    dsv3 = Gen.GetShowApprovalandFeesHMDACLUandBuilding("6", Enterpriseid, "1", TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);

                    dsv3 = GetShowApprovalandFeesCMCIBP("175", Enterpriseid, "2", TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);  // commented on 25/09/2024 - 05:09

                    dsv3 = Gen.GetShowApprovalandFeesGpFees("57", Enterpriseid, TxtBuilt_up_Area.Text.Trim(), ddlProp_intVillageid.SelectedValue, ddlLoc_of_unit.SelectedValue, Session["uid"].ToString().Trim());
                    if (dsv3 != null && dsv3.Tables.Count > 0 && dsv3.Tables[0].Rows.Count > 0)
                    {
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                }


            }

            if (ddlLoc_of_unit.SelectedValue == "15" && (ddlAppl_Type.SelectedValue != "0" && ddlAppl_Type.SelectedItem.Text != "--Select--"))
            {
                if (ddlAppl_Type.SelectedValue == "1")
                {
                    dsv3 = Gen.GetShowApprovalandFeesHMDACLUandBuilding("6", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
                else if (ddlAppl_Type.SelectedValue == "2")
                {
                    dsv3 = GetShowApprovalandFeesMMCIBP("176", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);  // commented on 25/09/2024 - 05:09

                    dsv3 = Gen.GetShowApprovalandFeesGpFees("57", Enterpriseid, TxtBuilt_up_Area.Text.Trim(), ddlProp_intVillageid.SelectedValue, ddlLoc_of_unit.SelectedValue, Session["uid"].ToString().Trim());
                    if (dsv3 != null && dsv3.Tables.Count > 0 && dsv3.Tables[0].Rows.Count > 0)
                    {
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                }
                else if (ddlAppl_Type.SelectedValue == "3")
                {
                    dsv3 = Gen.GetShowApprovalandFeesHMDACLUandBuilding("6", Enterpriseid, "1", TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);

                    dsv3 = GetShowApprovalandFeesMMCIBP("176", Enterpriseid, "2", TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);  // commented on 25/09/2024 - 05:09

                    dsv3 = Gen.GetShowApprovalandFeesGpFees("57", Enterpriseid, TxtBuilt_up_Area.Text.Trim(), ddlProp_intVillageid.SelectedValue, ddlLoc_of_unit.SelectedValue, Session["uid"].ToString().Trim());
                    if (dsv3 != null && dsv3.Tables.Count > 0 && dsv3.Tables[0].Rows.Count > 0)
                    {
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                }


            }

            if (ddlLoc_of_unit.SelectedValue == "3")
            {
                dsv3 = Gen.GetShowApprovalandFees("30", Enterpriseid);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }
            if (ddlLoc_of_unit.SelectedValue == "4")
            {
                //dsv3 = Gen.GetShowApprovalandFees("31", Enterpriseid);
                //dsv.Tables[0].Merge(dsv3.Tables[0]);
                dsv3 = Gen.GetShowApprovalandFeesTSIIC("31", Enterpriseid, Session["Applid"].ToString(), TxtBuilt_up_Area.Text.Trim(), TxtTot_Extent.Text.Trim());
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
            dsv4 = Gen.GetShowApprovalandFeesEnterPriseAmount("33", Enterpriseid, TxtVal_Plantnewfinal, strTot_PrjCost, "0");
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

                    dsv3 = Gen.GetShowApprovalandFeesGpFees("57", Enterpriseid, TxtBuilt_up_Area.Text.Trim(), ddlProp_intVillageid.SelectedValue, ddlLoc_of_unit.SelectedValue, Session["uid"].ToString().Trim());
                    if (dsv3 != null && dsv3.Tables.Count > 0 && dsv3.Tables[0].Rows.Count > 0)
                    {
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }
                }
                else if (ddlAppl_Type.SelectedValue == "3")
                {
                    dsv3 = Gen.GetShowApprovalandFeesHMDACLUandBuildingBoth("6", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);

                    dsv3 = Gen.GetShowApprovalandFeesGpFees("57", Enterpriseid, TxtBuilt_up_Area.Text.Trim(), ddlProp_intVillageid.SelectedValue, ddlLoc_of_unit.SelectedValue, Session["uid"].ToString().Trim());
                    if (dsv3 != null && dsv3.Tables.Count > 0 && dsv3.Tables[0].Rows.Count > 0)
                    {
                        dsv.Tables[0].Merge(dsv3.Tables[0]);
                    }  //added on 03.09.2019
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
                if (rdIaLa_Lst.SelectedValue == "N")
                {
                    //dsv3 = Gen.GetShowApprovalandFeesNALA_newdharani("34", Enterpriseid, ddlProp_intDistrictid.SelectedValue, txtmarketvalue.Text.Trim(), ddlcurrencytype.SelectedItem.Text, ddlProp_intMandalid.SelectedValue, Convert.ToString(Session["uid"]));
                    ////dsv3 = Gen.GetShowApprovalandFeesNALA("34", Enterpriseid, ddlProp_intDistrictid.SelectedValue, txtmarketvalue.Text.Trim(), ddlcurrencytype.SelectedItem.Text, ddlProp_intMandalid.SelectedValue);
                    //dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
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

            //for (int i = 0; i < ChkLabour_Application.Items.Count; i++)
            //{
            //    if (ChkLabour_Application.Items[i].Selected == true)
            //    {
            //        if (LabourActId == "")
            //            LabourActId = ChkLabour_Application.Items[i].Value;
            //        else
            //            LabourActId += "," + ChkLabour_Application.Items[i].Value;
            //    }
            //}
            //dsLabour = Gen.GetShowApprovalandFeesLabour("0", Enterpriseid, ddlProp_intDistrictid.SelectedValue, LabourActId, EmployeeCount);
            //dsv.Tables[0].Merge(dsLabour.Tables[0]);
            //if (RdbExecpted0.SelectedValue == "Y")
            //{
            //    dsLabour = Gen.GetShowApprovalandFeesLabour("48", Enterpriseid, ddlProp_intDistrictid.SelectedValue, "3", txtContractLabourAct.Text.Trim().TrimStart());
            //    dsv.Tables[0].Merge(dsLabour.Tables[0]);
            //}
            //DataSet dsLabour1 = new DataSet();
            //if (RdbExecpted1.SelectedValue == "Y")
            //{
            //    dsLabour1 = Gen.GetShowApprovalandFeesLabour("49", Enterpriseid, ddlProp_intDistrictid.SelectedValue, "4", txtMigrantWorkmanAct.Text.Trim().TrimStart());
            //    dsv.Tables[0].Merge(dsLabour1.Tables[0]);
            //}
            //DataSet dsLabour2 = new DataSet();
            //if (RdbExecpted2.SelectedValue == "Y")
            //{
            //    dsLabour2 = Gen.GetShowApprovalandFeesLabour("47", Enterpriseid, ddlProp_intDistrictid.SelectedValue, "2", txtNoofworkers.Text.Trim().TrimStart());
            //    dsv.Tables[0].Merge(dsLabour2.Tables[0]);
            //}
            // ADDED NEW CODE BY MADHURI ON 11/10/2022
            DataSet dslabourharitha = new DataSet();
            DataSet dslabourharitha1 = new DataSet();
            DataSet dslabourharitha2 = new DataSet();
            if (RdbExecpted0.SelectedValue == "Y")
            {
                dsLabour = Gen.GetShowApprovalandFeesLabour("48", Enterpriseid, ddlProp_intDistrictid.SelectedValue, "3", txtContractLabourAct.Text.Trim().TrimStart());
                dsv.Tables[0].Merge(dsLabour.Tables[0]);
                if (dsLabour.Tables[1].Rows.Count > 0)
                {
                    dslabourharitha = Gen.GetShowApprovalandFeesLabour("48", Enterpriseid, ddlProp_intDistrictid.SelectedValue, "3", txtContractLabourAct.Text.Trim().TrimStart());
                    dsv.Tables[0].Merge(dsLabour.Tables[1]);
                }

            }
            DataSet dsLabour1 = new DataSet();
            if (RdbExecpted1.SelectedValue == "Y")
            {
                dsLabour1 = Gen.GetShowApprovalandFeesLabour("49", Enterpriseid, ddlProp_intDistrictid.SelectedValue, "4", txtMigrantWorkmanAct.Text.Trim().TrimStart());
                dsv.Tables[0].Merge(dsLabour1.Tables[0]);
                if (dsLabour1.Tables[1].Rows.Count > 0)
                {
                    dslabourharitha1 = Gen.GetShowApprovalandFeesLabour("49", Enterpriseid, ddlProp_intDistrictid.SelectedValue, "4", txtMigrantWorkmanAct.Text.Trim().TrimStart());
                    dsv.Tables[0].Merge(dsLabour1.Tables[1]);
                }
            }
            DataSet dsLabour2 = new DataSet();
            if (RdbExecpted2.SelectedValue == "Y")
            {
                dsLabour2 = Gen.GetShowApprovalandFeesLabour("47", Enterpriseid, ddlProp_intDistrictid.SelectedValue, "2", txtNoofworkers.Text.Trim().TrimStart());
                dsv.Tables[0].Merge(dsLabour2.Tables[0]);
                if (dsLabour2.Tables[1].Rows.Count > 0)
                {
                    dslabourharitha2 = Gen.GetShowApprovalandFeesLabour("47", Enterpriseid, ddlProp_intDistrictid.SelectedValue, "2", txtNoofworkers.Text.Trim().TrimStart());
                    dsv.Tables[0].Merge(dsLabour2.Tables[1]);
                }
            }
            DataSet dsLabour3 = new DataSet();
            if (Rdb20d.SelectedValue == "Y")
            {
                dsLabour3 = Gen.GetShowApprovalandFeesLabour("58", Enterpriseid, ddlProp_intDistrictid.SelectedValue, "5", txtNoofworkers20d.Text.Trim().TrimStart());
                dsv.Tables[0].Merge(dsLabour3.Tables[0]);
            }

            DataSet dsLabour4 = new DataSet();
            if (Rdbact5License.SelectedValue == "Y")
            {
                dsLabour4 = Gen.GetShowApprovalandFeesLabour("66", Enterpriseid, ddlProp_intDistrictid.SelectedValue, "6", txtact5emp.Text.Trim().TrimStart());
                dsv.Tables[0].Merge(dsLabour4.Tables[0]);
            }
            //sowjanya
            DataSet dsLabour7 = new DataSet();
            if (RdbExecptedactShop.SelectedValue == "Y")
            {

                dsLabour7 = Gen.GetShowApprovalandFeesLabouract1("66", Enterpriseid, ddlProp_intDistrictid.SelectedValue, "7", txtliccontractor.Text.Trim().TrimStart(), txtDateofCommenceAct1.Text, Session["uid"].ToString().Trim());
                if (dsLabour7.Tables.Count > 0)
                { dsv.Tables[0].Merge(dsLabour7.Tables[0]); }
            }
            if (rdvicinitywaterbody.SelectedValue == "Y")
            {
                dsv3 = Gen.GetShowApprovalandFees("59", Enterpriseid);
                //dsv3 = Gen.GetShowApprovalandFeesDistincts("60", Enterpriseid, ddlProp_intDistrictid.SelectedValue);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }
            if (rdvicinitywaterbody.SelectedValue == "Y")
            {
                //dsv3 = Gen.GetShowApprovalandFees("59", Enterpriseid);
                dsv3 = Gen.GetShowApprovalandFeesDistincts("60", Enterpriseid, ddlProp_intDistrictid.SelectedValue);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }
            //sowjanya
            DataSet dsceigdrawings = new DataSet();
            if (RdpIndustry.SelectedValue == "Y")
            {
                dsceigdrawings = Gen.GetShowApprovalandFeesCEIGCFE("65", Enterpriseid, ddlregulation.SelectedValue, ddlvoltage.SelectedValue, ddlproposal.SelectedItem.Text, txtagrcapacity.Text.Trim());
                dsv.Tables[0].Merge(dsceigdrawings.Tables[0]);
            }

            DataSet dsprofessiontax = new DataSet();
            if (rdprofessiontax.SelectedValue == "Y")
            {
                dsprofessiontax = Gen.GetShowApprovalandFees("72", Enterpriseid);
                dsv.Tables[0].Merge(dsprofessiontax.Tables[0]);
            }

            DataSet dsexcise = new DataSet();
            if (rdexcise.SelectedValue == "Y")
            {
                dsexcise = Gen.GetShowApprovalandFees("75", Enterpriseid);
                dsv.Tables[0].Merge(dsexcise.Tables[0]);
            }

            DataSet dsLegal = new DataSet();

            //if (rbtnLstLabel.SelectedValue == "Y")
            //{
            //    dsLegal = Gen.GetShowApprovalandFeesLegal("0", Enterpriseid, ddlProp_intDistrictid.SelectedValue);
            //    dsv.Tables[0].Merge(dsLegal.Tables[0]);
            //}

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
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
        finally
        {
        }

    }
    public DataSet GetShowApprovalandFeesFCDAIBP(string SerchVer, string EnterpriseType, string ApplType, string TotExtent, string TotHight)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetShowApprovalandFees_FCDAIBP", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (SerchVer.Trim() == "" || SerchVer.Trim() == null)
                da.SelectCommand.Parameters.Add("@SerchVer", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@SerchVer", SqlDbType.VarChar).Value = SerchVer.ToString();


            if (EnterpriseType.Trim() == "" || EnterpriseType.Trim() == null)
                da.SelectCommand.Parameters.Add("@EnterpriseType", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@EnterpriseType", SqlDbType.VarChar).Value = EnterpriseType.ToString();


            if (ApplType.Trim() == "" || ApplType.Trim() == null)
                da.SelectCommand.Parameters.Add("@ApplType", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@ApplType", SqlDbType.VarChar).Value = ApplType.ToString();


            if (TotExtent.Trim() == "" || TotExtent.Trim() == null)
                da.SelectCommand.Parameters.Add("@TotExtent", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@TotExtent", SqlDbType.Decimal).Value = Convert.ToDecimal(TotExtent.ToString());



            if (TotHight.Trim() == "" || TotHight.Trim() == null)
                da.SelectCommand.Parameters.Add("@TotHight", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@TotHight", SqlDbType.Decimal).Value = Convert.ToDecimal(TotHight.ToString());






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

    public DataSet GetShowApprovalandFeesCMCIBP(string SerchVer, string EnterpriseType, string ApplType, string TotExtent, string TotHight)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetShowApprovalandFees_CMCIBP", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (SerchVer.Trim() == "" || SerchVer.Trim() == null)
                da.SelectCommand.Parameters.Add("@SerchVer", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@SerchVer", SqlDbType.VarChar).Value = SerchVer.ToString();


            if (EnterpriseType.Trim() == "" || EnterpriseType.Trim() == null)
                da.SelectCommand.Parameters.Add("@EnterpriseType", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@EnterpriseType", SqlDbType.VarChar).Value = EnterpriseType.ToString();


            if (ApplType.Trim() == "" || ApplType.Trim() == null)
                da.SelectCommand.Parameters.Add("@ApplType", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@ApplType", SqlDbType.VarChar).Value = ApplType.ToString();


            if (TotExtent.Trim() == "" || TotExtent.Trim() == null)
                da.SelectCommand.Parameters.Add("@TotExtent", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@TotExtent", SqlDbType.Decimal).Value = Convert.ToDecimal(TotExtent.ToString());



            if (TotHight.Trim() == "" || TotHight.Trim() == null)
                da.SelectCommand.Parameters.Add("@TotHight", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@TotHight", SqlDbType.Decimal).Value = Convert.ToDecimal(TotHight.ToString());






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

    public DataSet GetShowApprovalandFeesMMCIBP(string SerchVer, string EnterpriseType, string ApplType, string TotExtent, string TotHight)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetShowApprovalandFees_MMCIBP", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (SerchVer.Trim() == "" || SerchVer.Trim() == null)
                da.SelectCommand.Parameters.Add("@SerchVer", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@SerchVer", SqlDbType.VarChar).Value = SerchVer.ToString();


            if (EnterpriseType.Trim() == "" || EnterpriseType.Trim() == null)
                da.SelectCommand.Parameters.Add("@EnterpriseType", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@EnterpriseType", SqlDbType.VarChar).Value = EnterpriseType.ToString();


            if (ApplType.Trim() == "" || ApplType.Trim() == null)
                da.SelectCommand.Parameters.Add("@ApplType", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@ApplType", SqlDbType.VarChar).Value = ApplType.ToString();


            if (TotExtent.Trim() == "" || TotExtent.Trim() == null)
                da.SelectCommand.Parameters.Add("@TotExtent", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@TotExtent", SqlDbType.Decimal).Value = Convert.ToDecimal(TotExtent.ToString());



            if (TotHight.Trim() == "" || TotHight.Trim() == null)
                da.SelectCommand.Parameters.Add("@TotHight", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@TotHight", SqlDbType.Decimal).Value = Convert.ToDecimal(TotHight.ToString());






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

    public DataSet GetShowApprovalandFeesNUDA(string SerchVer, string EnterpriseType, string RUType)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetShowApprovalandFeesNUDA", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (SerchVer.Trim() == "" || SerchVer.Trim() == null)
                da.SelectCommand.Parameters.Add("@SerchVer", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@SerchVer", SqlDbType.VarChar).Value = SerchVer.ToString();


            if (EnterpriseType.Trim() == "" || EnterpriseType.Trim() == null)
                da.SelectCommand.Parameters.Add("@EnterpriseType", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@EnterpriseType", SqlDbType.VarChar).Value = EnterpriseType.ToString();




            if (RUType.Trim() == "" || RUType.Trim() == null)
                da.SelectCommand.Parameters.Add("@RUType", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@RUType", SqlDbType.VarChar).Value = RUType.ToString();





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

    public DataSet GetShowApprovalandFeesSUDAKHAMMAM(string SerchVer, string EnterpriseType, string RUType)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetShowApprovalandFeesSUDA_KHAMMAM", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (SerchVer.Trim() == "" || SerchVer.Trim() == null)
                da.SelectCommand.Parameters.Add("@SerchVer", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@SerchVer", SqlDbType.VarChar).Value = SerchVer.ToString();


            if (EnterpriseType.Trim() == "" || EnterpriseType.Trim() == null)
                da.SelectCommand.Parameters.Add("@EnterpriseType", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@EnterpriseType", SqlDbType.VarChar).Value = EnterpriseType.ToString();




            if (RUType.Trim() == "" || RUType.Trim() == null)
                da.SelectCommand.Parameters.Add("@RUType", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@RUType", SqlDbType.VarChar).Value = RUType.ToString();





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
    public DataSet GetShowApprovalandFeesSUDASIDDIPET(string SerchVer, string EnterpriseType, string RUType)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetShowApprovalandFeesSUDA_SIDDIPET", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (SerchVer.Trim() == "" || SerchVer.Trim() == null)
                da.SelectCommand.Parameters.Add("@SerchVer", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@SerchVer", SqlDbType.VarChar).Value = SerchVer.ToString();


            if (EnterpriseType.Trim() == "" || EnterpriseType.Trim() == null)
                da.SelectCommand.Parameters.Add("@EnterpriseType", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@EnterpriseType", SqlDbType.VarChar).Value = EnterpriseType.ToString();




            if (RUType.Trim() == "" || RUType.Trim() == null)
                da.SelectCommand.Parameters.Add("@RUType", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@RUType", SqlDbType.VarChar).Value = RUType.ToString();





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
    //public DataSet GetShowApprovalandFeesFCDA(string SerchVer, string EnterpriseType, string RUType)
    //{
    //    con.OpenConnection();
    //    SqlDataAdapter da;
    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        da = new SqlDataAdapter("GetShowApprovalandFeesFCDA", con.GetConnection);
    //        da.SelectCommand.CommandType = CommandType.StoredProcedure;


    //        if (SerchVer.Trim() == "" || SerchVer.Trim() == null)
    //            da.SelectCommand.Parameters.Add("@SerchVer", SqlDbType.VarChar).Value = "%";
    //        else
    //            da.SelectCommand.Parameters.Add("@SerchVer", SqlDbType.VarChar).Value = SerchVer.ToString();


    //        if (EnterpriseType.Trim() == "" || EnterpriseType.Trim() == null)
    //            da.SelectCommand.Parameters.Add("@EnterpriseType", SqlDbType.VarChar).Value = "%";
    //        else
    //            da.SelectCommand.Parameters.Add("@EnterpriseType", SqlDbType.VarChar).Value = EnterpriseType.ToString();




    //        if (RUType.Trim() == "" || RUType.Trim() == null)
    //            da.SelectCommand.Parameters.Add("@RUType", SqlDbType.VarChar).Value = "%";
    //        else
    //            da.SelectCommand.Parameters.Add("@RUType", SqlDbType.VarChar).Value = RUType.ToString();





    //        da.Fill(ds);
    //        return ds;


    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        con.CloseConnection();
    //    }
    //}

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
        try
        {
            hdnfldtsiic.Value = "";
            ddlLoc_of_unit.Items.Clear();
            ddlLoc_of_unit.Items.Insert(0, new ListItem("--Select--", "0"));
            if (ddlProp_intDistrictid.SelectedIndex == 0)
            {
                ddlProp_intMandalid.Items.Clear();
                ddlProp_intMandalid.Items.Insert(0, "--Mandal--");
                ddlProp_intVillageid.Items.Clear();
                ddlProp_intVillageid.Items.Insert(0, "--Village--");

                //ChkWater_reg_from.Items.Clear();
                //ChkWater_reg_from.Items.Insert(0, new ListItem("New Bore well", "New Bore well"));
                //ChkWater_reg_from.Items.Insert(1, new ListItem("HMWS & SB", "HMWS & SB"));
                //ChkWater_reg_from.Items.Insert(2, new ListItem("Rivers/Canals", "Rivers/Canals"));
            }
            else
            {
                ddlProp_intVillageid.Items.Clear();
                ddlProp_intVillageid.Items.Insert(0, "--Village--");

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
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void ddlProp_intMandalid_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlLoc_of_unit.Items.Clear();
            ddlLoc_of_unit.Items.Insert(0, new ListItem("--Select--", "0"));
            if (ddlProp_intMandalid.SelectedIndex == 0)
            {

                ddlProp_intVillageid.Items.Clear();
                ddlProp_intVillageid.Items.Insert(0, "--Village--");
            }
            else
            {
                //commented by rajinikar on 31-05-2025

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
                //if (HDNAPPLNSTATUS.Value == "3" && DateTime.ParseExact(HDNDATEOFPAYMENT.Value, "dd-MM-yyyy", CultureInfo.InvariantCulture) <= DateTime.ParseExact("31-05-2025", "dd-MM-yyyy", CultureInfo.InvariantCulture))
                //{
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
                    //  dsv = Gen.GetVillages(ddlProp_intMandalid.SelectedValue);
                    dsv = GetVillagesWITHOUT111GMVILLAGES(ddlProp_intMandalid.SelectedValue);
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
                //}
                //else
                //{
                //    ddlProp_intVillageid.Items.Clear();
                //    DataSet dsv = new DataSet();
                //    dsv = GetVillagesOTHERTHANFCDA(ddlProp_intMandalid.SelectedValue);
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
                //}
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
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    public DataSet GetVillagesWITHOUT111GMVILLAGES(string Mandal)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetVillages_WITHOUT111GMVILLAGES", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (Mandal.Trim() == "" || Mandal.Trim() == null || Mandal.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@inMandalid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@inMandalid", SqlDbType.VarChar).Value = Mandal.ToString();

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

    public DataSet GetVillagesOTHERTHANFCDA(string Mandal)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetVillages_OTHERTHANFCDA", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (Mandal.Trim() == "" || Mandal.Trim() == null || Mandal.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@inMandalid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@inMandalid", SqlDbType.VarChar).Value = Mandal.ToString();

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

    protected void ddlintLineofActivity_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void TxtVal_Plant_TextChanged(object sender, EventArgs e)
    {
        try
        {
            CalculatationEnterprisePrjCost();
            CalculatationEnterprise();
            hdnfocus.Value = TxtVal_Plant.ClientID;
            // lblPlant.Text = "= Rs " + Decimal.Parse(TxtVal_Plant.Text.ToString()) / 100 + " Crores";
            // lblPlant.Text = "= Rs " + (Decimal.Parse(TxtVal_Plant_Actual.Text.ToString()) * Decimal.Parse(ddlcurrencytype.SelectedValue)) / 100 + " Crores";
            ProjectCostFinal();
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
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    public void CalculatationEnterprisePrjCost()
    {
        try
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
                if (TextBox2.Text.Trim() == "")
                {
                    TextBox2.Text = "0";
                }
                //TxtTot_PrjCost.Text = Convert.ToString((Convert.ToDecimal(TxtVal_Build.Text) + Convert.ToDecimal(TxtVal_Land.Text) + Convert.ToDecimal(TxtVal_Plant.Text)));
                TxtTot_PrjCost.Text = Convert.ToString((Convert.ToDecimal(TxtVal_Build.Text) + Convert.ToDecimal(TxtVal_Land.Text) + Convert.ToDecimal(TxtVal_Plant.Text)));
                //Convert.ToDecimal(TextBox2.Text)
                lblmsg.Text = "";
            }
            else
            {
                TxtTot_PrjCost.Text = "0";
                lblmsg0.Text = "Please Select Sector of Enterprise";
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
    public void CalculatationEnterprisePrjCostExpansion()
    {
        try
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
                if (TextBox4.Text.Trim() == "")
                {
                    TextBox4.Text = "0";
                }
                //txtlbltotalprojectcostexpanstion.Text = Convert.ToString((Convert.ToDecimal(TxtVal_BuildExpanstion.Text) + Convert.ToDecimal(TxtVal_LandExpansion.Text) + Convert.ToDecimal(TxtVal_PlantExpanstion.Text)));
                txtlbltotalprojectcostexpanstion.Text = Convert.ToString((Convert.ToDecimal(TxtVal_BuildExpanstion.Text) + Convert.ToDecimal(TxtVal_LandExpansion.Text) + Convert.ToDecimal(TxtVal_PlantExpanstion.Text)));
                lblmsg.Text = "";
                //+ Convert.ToDecimal(TextBox4.Text)
            }
            else
            {
                txtlbltotalprojectcostexpanstion.Text = "0";
                lblmsg0.Text = "Please Select Sector of Enterprise";
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

    public void CalculatationEnterprise()
    {
        try
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
                TxtTot_PrjCostNewfinal = TxtTot_PrjCost.Text;
                TxtVal_Plantnewfinal = TxtVal_Plant.Text;
            }
            if (TxtTot_PrjCostNewfinal == "")
            {
                TxtTot_PrjCostNewfinal = "0";
            }
            if (TxtVal_Plantnewfinal == "")
            {
                TxtVal_Plantnewfinal = "0";
            }
            if (ddlSector_Ent.SelectedIndex != 0)
            {

                if (TxtProp_Emp.Text.Trim() == "")
                {
                    TxtProp_Emp.Text = "1";
                }

                lblmsg.Text = "";
                DataSet dsEnter = new DataSet();
                if (ddlSector_Ent.SelectedValue == "2")
                {
                    if (Convert.ToDecimal(TxtTot_PrjCostNewfinal) >= Convert.ToDecimal("20000"))
                    {
                        HdfLblEnt_is.Value = "Mega";

                        LblEnt_is.Text = "Mega";
                    }
                    else
                    {
                        //dsEnter = Gen.GetEnterPriseIs(TxtVal_Plantnewfinal, ddlSector_Ent.SelectedValue);
                        //if (dsEnter.Tables[0].Rows.Count > 0)
                        //{
                        //    HdfLblEnt_is.Value = dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
                        //    LblEnt_is.Text = dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
                        //}
                        //else
                        //{
                        //    HdfLblEnt_is.Value = "";
                        //    LblEnt_is.Text = "";
                        //}
                        try
                        {
                            osqlConnection.Open();
                            SqlDataAdapter myDataAdapter;
                            myDataAdapter = new SqlDataAdapter("GetEnterPriseIs_Turnover", osqlConnection);
                            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                            oDataSet = new DataSet();
                            if (TxtTot_PrjCostNewfinal.Trim() != "" || TxtTot_PrjCostNewfinal.Trim() != null || TxtTot_PrjCostNewfinal.Trim() != "--Select--")
                            {
                                myDataAdapter.SelectCommand.Parameters.Add("@EnterpriseCost", SqlDbType.VarChar).Value = TxtVal_Plantnewfinal.ToString();
                                myDataAdapter.SelectCommand.Parameters.Add("@EnterpriseTurnover", SqlDbType.VarChar).Value = TextBox2.Text.ToString();
                                myDataAdapter.SelectCommand.Parameters.Add("@EnterPriseType", SqlDbType.VarChar).Value = ddlSector_Ent.SelectedValue.ToString();
                                myDataAdapter.Fill(oDataSet);

                                //LblEnt_is.Text=
                                if (oDataSet.Tables[0].Rows.Count > 0)
                                {
                                    HdfLblEnt_is.Value = oDataSet.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
                                    LblEnt_is.Text = oDataSet.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
                                }
                                else
                                {
                                    HdfLblEnt_is.Value = "";
                                    LblEnt_is.Text = "";
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            osqlConnection.Close();
                            throw ex;

                        }
                        finally
                        {
                            osqlConnection.Close();
                        }
                    }
                }
                else if (ddlSector_Ent.SelectedValue == "1")
                {
                    if (Convert.ToDecimal(TxtTot_PrjCostNewfinal) >= Convert.ToDecimal("20000"))
                    {
                        HdfLblEnt_is.Value = "Mega";

                        LblEnt_is.Text = "Mega";
                    }

                    else
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "alert('" + txtturnOver_read.Text + "');", true);
                        if (TextBox2.Text != "0" && TextBox2.Text != "")
                        {
                            //dsEnter = Gen.GetEnterPriseIs(TxtVal_Plantnewfinal, ddlSector_Ent.SelectedValue);
                            //if (dsEnter.Tables[0].Rows.Count > 0)
                            //{
                            //    HdfLblEnt_is.Value = dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
                            //    LblEnt_is.Text = dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
                            //}

                            //else
                            //{
                            //    HdfLblEnt_is.Value = "";
                            //    LblEnt_is.Text = "";
                            //}
                            try
                            {
                                osqlConnection.Open();
                                SqlDataAdapter myDataAdapter;
                                myDataAdapter = new SqlDataAdapter("GetEnterPriseIs_Turnover", osqlConnection);
                                myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                                oDataSet = new DataSet();
                                if (TxtTot_PrjCostNewfinal.Trim() != "" || TxtTot_PrjCostNewfinal.Trim() != null || TxtTot_PrjCostNewfinal.Trim() != "--Select--")
                                {
                                    myDataAdapter.SelectCommand.Parameters.Add("@EnterpriseCost", SqlDbType.VarChar).Value = TxtVal_Plantnewfinal.ToString();
                                    myDataAdapter.SelectCommand.Parameters.Add("@EnterpriseTurnover", SqlDbType.VarChar).Value = TextBox2.Text.ToString();
                                    myDataAdapter.SelectCommand.Parameters.Add("@EnterPriseType", SqlDbType.VarChar).Value = ddlSector_Ent.SelectedValue.ToString();
                                    myDataAdapter.Fill(oDataSet);

                                    //LblEnt_is.Text=
                                    if (oDataSet.Tables[0].Rows.Count > 0)
                                    {
                                        HdfLblEnt_is.Value = oDataSet.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
                                        LblEnt_is.Text = oDataSet.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
                                    }
                                    else
                                    {
                                        HdfLblEnt_is.Value = "";
                                        LblEnt_is.Text = "";
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                osqlConnection.Close();
                                throw ex;

                            }
                            finally
                            {
                                osqlConnection.Close();
                            }
                        }
                        else if (TextBox2.Text != "0" && TextBox2.Text != "")
                        {
                            try
                            {
                                osqlConnection.Open();
                                SqlDataAdapter myDataAdapter;
                                myDataAdapter = new SqlDataAdapter("GetEnterPriseIs_Turnover", osqlConnection);
                                myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                                oDataSet = new DataSet();
                                if (TxtTot_PrjCostNewfinal.Trim() != "" || TxtTot_PrjCostNewfinal.Trim() != null || TxtTot_PrjCostNewfinal.Trim() != "--Select--")
                                {
                                    myDataAdapter.SelectCommand.Parameters.Add("@EnterpriseCost", SqlDbType.VarChar).Value = TxtVal_Plantnewfinal.ToString();
                                    myDataAdapter.SelectCommand.Parameters.Add("@EnterpriseTurnover", SqlDbType.VarChar).Value = TextBox2.Text.ToString();
                                    myDataAdapter.SelectCommand.Parameters.Add("@EnterPriseType", SqlDbType.VarChar).Value = ddlSector_Ent.SelectedValue.ToString();
                                    myDataAdapter.Fill(oDataSet);

                                    //LblEnt_is.Text=
                                    if (oDataSet.Tables[0].Rows.Count > 0)
                                    {
                                        HdfLblEnt_is.Value = oDataSet.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
                                        LblEnt_is.Text = oDataSet.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
                                    }
                                    else
                                    {
                                        HdfLblEnt_is.Value = "";
                                        LblEnt_is.Text = "";
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                osqlConnection.Close();
                                throw ex;

                            }
                            finally
                            {
                                osqlConnection.Close();
                            }
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
                Failure.Visible = true;
                lblmsg0.Text = "Please Select Sector of Enterprise";
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
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
        //if (TxtVal_Plant.Text == "" || TxtVal_Plant.Text == "0")
        //{
        //    HdfLblEnt_is.Value = "";
        //    LblEnt_is.Text = "";
        //}
    }
    protected void TxtVal_Land_TextChanged(object sender, EventArgs e)
    {
        try
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
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void TxtVal_Build_TextChanged(object sender, EventArgs e)
    {
        try
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
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void ddlSector_Ent_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
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
        try
        {
            //CalculatationEnterprise();
            //hdnfocus.Value = TxtVal_Land.ClientID;
            if (TxtProp_Emp.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Sir-Proposed Employment count should not be ZERO(0) ');", true);
                TxtProp_Emp.Text = "";
                TxtProp_Emp.Focus();
            }
            else
            {
                CalculatationEnterprise();
                hdnfocus.Value = TxtVal_Land.ClientID;
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
    protected void RdProp_Site_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (RdProp_Site.SelectedValue.ToString().Trim() == "Y")
            {
                trtrees.Visible = true;
                Txt_NoofTrees.Text = "";
                tr4.Visible = true;
                trlink.Visible = true;
            }
            else
            {
                Txt_NoofTrees.Text = "";
                trtrees.Visible = false;
                tr4.Visible = false;
                trlink.Visible = false;
            }
            hdnfocus.Value = RdProp_Site.ClientID;
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
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
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
                e.Row.Cells[3].Text = TotalFee.ToString("#,##0");
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
    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        try
        {
            if (TxtHight_Build.Text.Trim().All(c => c == '0'))
            {
                lblmsg0.Text = "Building Height Should not be zero";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Building Height Should not be zero..!');", true);
                Failure.Visible = true;
                return;
            }
            if (RdbExecpted0.SelectedValue == "Y")
            {
                if (txtContractLabourAct.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter No of Workers(20a)!.');", true);
                    return;
                }
            }

            string chkwatera = "", chkwaterb = "", chkwaterc = "", chkwaterd = "", chkwatere = "";
            decimal chkwaterreqa = 0, chkwaterreqb = 0, chkwaterreqc = 0, chkwaterreqd = 0, chkwaterreqe = 0;
            if (rdo_borewell.SelectedValue != "Y")
            {
                foreach (GridViewRow gvrTEMPVehMstr in gvmodelsnames.Rows)
                {
                    CheckBox txtMakerGvV = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                    TextBox txtwaterrequired = (TextBox)gvrTEMPVehMstr.FindControl("txtwaterrequired");
                    Label lblModelname = (Label)gvrTEMPVehMstr.FindControl("lblModelname");


                    if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 0)
                    {
                        chkwatera = lblModelname.Text;
                        if (txtwaterrequired.Text.Trim() != "")
                            chkwaterreqa = Convert.ToDecimal(txtwaterrequired.Text);
                    }
                    if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 1)
                    {
                        chkwaterb = lblModelname.Text;
                        if (txtwaterrequired.Text.Trim() != "")
                            chkwaterreqb = Convert.ToDecimal(txtwaterrequired.Text);
                    }
                    if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 2)
                    {
                        chkwaterc = lblModelname.Text;
                        if (txtwaterrequired.Text.Trim() != "")
                            chkwaterreqc = Convert.ToDecimal(txtwaterrequired.Text);
                    }
                    if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 3)
                    {
                        chkwaterd = lblModelname.Text;
                        if (txtwaterrequired.Text.Trim() != "")
                            chkwaterreqd = Convert.ToDecimal(txtwaterrequired.Text);
                    }
                    if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 4)
                    {
                        chkwatere = lblModelname.Text;
                        if (txtwaterrequired.Text.Trim() != "")
                            chkwaterreqe = Convert.ToDecimal(txtwaterrequired.Text);
                    }
                }
            }
            else
            {
                foreach (GridViewRow gvrTEMPVehMstr in gvmodelsnames.Rows)
                {
                    CheckBox txtMakerGvV = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                    TextBox txtwaterrequired = (TextBox)gvrTEMPVehMstr.FindControl("txtwaterrequired");
                    Label lblModelname = (Label)gvrTEMPVehMstr.FindControl("lblModelname");


                    //if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 0)
                    //{
                    //    chkwatera = lblModelname.Text;
                    //    if (txtwaterrequired.Text.Trim() != "")
                    //        chkwaterreqa = Convert.ToDecimal(txtwaterrequired.Text);
                    //}
                    if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 0)
                    {
                        chkwaterb = lblModelname.Text;
                        if (txtwaterrequired.Text.Trim() != "")
                            chkwaterreqb = Convert.ToDecimal(txtwaterrequired.Text);
                    }
                    if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 1)
                    {
                        chkwaterc = lblModelname.Text;
                        if (txtwaterrequired.Text.Trim() != "")
                            chkwaterreqc = Convert.ToDecimal(txtwaterrequired.Text);
                    }
                    if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 2)
                    {
                        chkwaterd = lblModelname.Text;
                        if (txtwaterrequired.Text.Trim() != "")
                            chkwaterreqd = Convert.ToDecimal(txtwaterrequired.Text);
                    }
                    if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 3)
                    {
                        chkwatere = lblModelname.Text;
                        if (txtwaterrequired.Text.Trim() != "")
                            chkwaterreqe = Convert.ToDecimal(txtwaterrequired.Text);
                    }
                }
            }
            //if (ChkWater_reg_from.Items[0].Selected == true)
            //{
            //    chkwatera = ChkWater_reg_from.Items[0].Text;
            //}
            //if (ChkWater_reg_from.Items[1].Selected == true)
            //{
            //    chkwaterb = ChkWater_reg_from.Items[1].Text;
            //}

            //if (ChkWater_reg_from.Items[2].Selected == true)
            //{
            //    chkwaterc = ChkWater_reg_from.Items[2].Text;
            //}


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
            //  quesionervoobj.Water_req_Perday = TxtWater_req_Perday.Text;
            quesionervoobj.Water_req_Perday = (chkwaterreqa + chkwaterreqb + chkwaterreqc).ToString();
            quesionervoobj.Water_req_Perday1 = chkwaterreqa.ToString();
            quesionervoobj.Water_req_Perday2 = chkwaterreqb.ToString();
            quesionervoobj.Water_req_Perday3 = chkwaterreqc.ToString();
            quesionervoobj.Water_req_Perday4 = chkwaterreqd.ToString();
            quesionervoobj.Water_req_Perday5 = chkwaterreqe.ToString();

            quesionervoobj.Water_reg_from1 = chkwatera;
            quesionervoobj.Water_reg_from2 = chkwaterb;
            quesionervoobj.Water_reg_from3 = chkwaterc;
            quesionervoobj.Water_reg_from4 = chkwaterd;
            quesionervoobj.Water_reg_from5 = chkwatere;

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
            quesionervoobj.annualTurnover = TextBox2.Text;
            quesionervoobj.annualTurnover_act = TextBox1.Text;

            //Expansion
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
            //20d
            quesionervoobj.TotalNoofWorkesformigrantact20d = txtNoofworkers20d.Text;
            quesionervoobj.TotalNoofWorkesContractLabourAct_Lisense = txtact5emp.Text.Trim();
            quesionervoobj.annualTurnover_Exp = TextBox4.Text;
            quesionervoobj.annualTurnover_Exp_act = TextBox3.Text;

            //end shankar

            //lavanya
            quesionervoobj.IALAFlag = rdIaLa_Lst.SelectedValue;
            if (quesionervoobj.IALAFlag == "Y")
                quesionervoobj.IALA_Code = ddlIndustrialParkName.SelectedValue;
            quesionervoobj.petrolDieselFlag = RdDo_Store_Kerosine0.SelectedValue;
            if (quesionervoobj.IALAFlag == "Y")
            {
                if (txttsiixplotno.Text != "" && txttsiixplotno.Text != "0")
                {
                    quesionervoobj.TsiicPlotno = txttsiixplotno.Text.Trim();
                }
                else
                {
                    lblmsg0.Text = "Please Enter TSIIC Plot Number";
                    Failure.Visible = true;
                    success.Visible = false;
                    txttsiixplotno.Enabled = true;
                    txttsiixplotno.ReadOnly = false;
                    return;
                }
            }
            quesionervoobj.LabourActID = "";

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
            if (Rdb20d.SelectedValue == "Y")
            {
                if (quesionervoobj.LabourActID == "")
                    quesionervoobj.LabourActID = "5";
                else
                    quesionervoobj.LabourActID += "," + "5";
            }
            if (RdbExecpted2.SelectedValue == "Y")
            {
                if (quesionervoobj.LabourActID == "")
                    quesionervoobj.LabourActID = "2";
                else
                    quesionervoobj.LabourActID += "," + "2";
            }

            if (Rdbact5License.SelectedValue == "Y")
            {
                if (quesionervoobj.LabourActID == "")
                    quesionervoobj.LabourActID = "6";
                else
                    quesionervoobj.LabourActID += "," + "6";
            }
            if (RdbExecptedactShop.SelectedValue == "Y")
            {
                if (quesionervoobj.LabourActID == "")
                    quesionervoobj.LabourActID = "7";
                else
                    quesionervoobj.LabourActID += "," + "7";
            }

            if (txtmarketvalue.Text.Trim() != "" && txtmarketvalue.Text.Trim() != "0")
            {
                quesionervoobj.MarketValue = txtmarketvalue.Text.Trim();
            }
            if (rdvicinitywaterbody.SelectedValue == "Y")
            {
                quesionervoobj.VicinityWater = "Y";
            }
            else
            {
                quesionervoobj.VicinityWater = "N";
            }

            if (RdpIndustry.SelectedValue == "Y")
            {
                quesionervoobj.CEIG = "Y";
            }
            else
            {
                quesionervoobj.CEIG = "N";
            }
            if (ddlregulation.Text.Trim() != "--Select--")
            {
                quesionervoobj.RegulationType = ddlregulation.SelectedValue;
            }
            else
            {
                quesionervoobj.RegulationType = "NULL";
            }
            if (ddlvoltage.Text.Trim() != "--Select--")
            {
                quesionervoobj.VoltageType = ddlvoltage.SelectedValue;
                if (ddlvoltage.SelectedValue == "1")
                {
                    if (txtagrcapacity.Text == "0")
                    {

                        lblmsg0.Text = "Please Enter Aggregate Capacity";
                        Failure.Visible = true;
                        success.Visible = false;
                        txtagrcapacity.Enabled = true;
                        txtagrcapacity.ReadOnly = false;
                        return;

                    }
                }
            }
            else
            {
                quesionervoobj.VoltageType = "NULL";
            }
            if (txtagrcapacity.Text != null && txtagrcapacity.Text.Trim() != "0")
            {
                quesionervoobj.AggregateCapacity = txtagrcapacity.Text.Trim();
            }
            if (rdo_borewell.SelectedValue == "Y")
            {
                quesionervoobj.Borewellflag = "Y";
            }
            else
            {
                quesionervoobj.Borewellflag = "N";
            }
            if (rdprofessiontax.SelectedValue == "Y")
            {
                quesionervoobj.professiontaxflag = "Y";
            }
            else
            {
                quesionervoobj.professiontaxflag = "N";
            }

            if (rdexcise.SelectedValue == "Y")
            {
                quesionervoobj.Exciseflag = "Y";
            }
            else
            {
                quesionervoobj.Exciseflag = "N";
            }

            //  quesionervoobj.LabelConfirmation = rbtnLstLabel.SelectedValue;
            //ddllandmesurements.SelectedItem.Text
            success.Visible = true;
            lblmsg.Visible = true;
            lblmsg.Text = grdDetails.Rows.Count.ToString();


            int s = Gen.insertQuetieneroes(quesionervoobj);

            Session["Applid"] = s.ToString();



            if (s != 999)
            {
                for (int iii = 0; iii < grdDetails.Rows.Count; iii++)
                {
                    HiddenField HdfApprovalid = (HiddenField)grdDetails.Rows[iii].Cells[0].FindControl("HdfApprovalid");
                    HiddenField HdfQueid = (HiddenField)grdDetails.Rows[iii].Cells[0].FindControl("HdfQueid");
                    int a = Gen.insertQuetieneroesDept(s.ToString(), HdfQueid.Value, HdfApprovalid.Value, "1000", grdDetails.Rows[iii].Cells[3].Text);
                    // int a = Gen.insertQuetieneroesDept(s.ToString(), HdfQueid.Value, HdfApprovalid.Value, Session["uid"].ToString().Trim(), grdDetails.Rows[iii].Cells[3].Text);

                }

                if (ddlproposal.SelectedValue == "2")
                {
                    if (Convert.ToString(ViewState["checkCFOCFE"]) == "Yes" && Convert.ToString(ViewState["checkCFOCFE"]) != null)
                    {
                        SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);

                        osqlConnection.Open();
                        SqlTransaction transaction = null;

                        transaction = osqlConnection.BeginTransaction();

                        SqlCommand com = new SqlCommand();
                        com.CommandType = CommandType.StoredProcedure;
                        com.CommandText = "checkInsertCFOCFE";
                        com.Transaction = transaction;
                        com.Connection = osqlConnection;

                        com.Parameters.AddWithValue("@cfe", txtCFEUID.Text.ToString());
                        com.Parameters.AddWithValue("@Cfo", txtCFOUID.Text.ToString());
                        com.Parameters.AddWithValue("@createdBy", Session["uid"].ToString().Trim());
                        com.ExecuteNonQuery();



                        transaction.Commit();
                        osqlConnection.Close();
                    }
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('test');", true);
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
                Response.Redirect("TS-iPASS.aspx?id=" + Session["Applid"].ToString().Trim(), false);
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
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
        finally
        {
        }
    }
    protected void ddlLoc_of_unit_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void ddlProp_intVillageid_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlLoc_of_unit.Items.Clear();
            ddlLoc_of_unit.Items.Insert(0, new ListItem("--Select--", "0"));
            trApplType.Visible = false;
            if (ddlProp_intVillageid.SelectedIndex != 0)
            {
                ddlLoc_of_unit.Items.Clear();
                DataSet dsss = new DataSet();
                DataSet dscess = new DataSet();

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
                string[] villageIds =
                    {
                     "5811","5812","5820","5821","5822","5823","5824","5825","5826","5827",
                     "5828","5829","5830","5831","5836","5838","5839","5840","5841","5842",
                     "5863","5864","5865","5866","5867","5868","5869","5870","5872",
                     "5882","5883","5896","5897","5899","5900","5901","5902","5903",
                     "5904","5905","5906","5907","5908","5909","5910","5911","5912",
                     "6302","6303","20241","20281",
                     "25106","25117","25118","25119","25120","25121"
                    };
                if (HDNAPPLNSTATUS.Value == "3" && DateTime.ParseExact(HDNDATEOFPAYMENT.Value, "dd-MM-yyyy", CultureInfo.InvariantCulture) <= DateTime.ParseExact("31-05-2025", "dd-MM-yyyy", CultureInfo.InvariantCulture) && Session["uid"].ToString().Trim() != "332457")
                {
                    dscess = Gen.GetUnderLimitsOfVillage(ddlProp_intVillageid.SelectedValue);
                }
                //else
                //{
                //    dscess = GetUnderLimitsOfVillagenew(ddlProp_intVillageid.SelectedValue);

                //}
                else if (HDNAPPLNSTATUS.Value == "3" && DateTime.ParseExact(HDNDATEOFPAYMENT.Value, "dd-MM-yyyy", CultureInfo.InvariantCulture) <= DateTime.ParseExact("17-12-2025", "dd-MM-yyyy", CultureInfo.InvariantCulture)
                    && villageIds.Contains(ddlProp_intVillageid.SelectedValue))

                {
                    dscess = GetUnderLimitsOfVillagenew(ddlProp_intVillageid.SelectedValue);

                }
                //else
                //{
                //    dscess = GetUnderLimitsOfVillagenew_WITHFCDA(ddlProp_intVillageid.SelectedValue);
                //}
                else if (HDNAPPLNSTATUS.Value == "3" && DateTime.ParseExact(HDNDATEOFPAYMENT.Value, "dd-MM-yyyy", CultureInfo.InvariantCulture) <= DateTime.ParseExact("29-09-2026", "dd-MM-yyyy", CultureInfo.InvariantCulture))
                {
                    dscess = GetUnderLimitsOfVillagenew_WITHFCDA(ddlProp_intVillageid.SelectedValue);
                }
                else
                {
                    dscess = GetUnderLimitsOfVillagenew_WITHCMCMMC(ddlProp_intVillageid.SelectedValue);

                }
                // DataSet dscess = Gen.GetUnderLimitsOfVillage(ddlProp_intVillageid.SelectedValue);
                string Muncipal_Flag = "", GHMC_FLG = "", HMR_FLG = "", HMDA_FLG = "", KUDA_FLAG = "", DTCPFLAG = "", YTDA = "", Hmwssbflg = "", CDMAFLAG = "", RWSFLAG = "";
                string SUDAFLAG = ""; string NUDAFLAG = "";
                string SUDAKHAMMAM = ""; string SUDASIDDIPET = ""; string FCDAFLAG = "";
                string CMCFLAG = ""; string MMCFLAG = "";
                //if (dscess.Tables[0].Rows.Count > 0)
                //{
                //    ddlLoc_of_unit.Items.Clear();
                //    ddlLoc_of_unit.Items.Insert(0, "--Select--");
                //    ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of KUDA", "3"));
                //    ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
                //}
                //#endregionlavanya
                if (rdIaLa_Lst.SelectedValue != "Y" || (rdIaLa_Lst.SelectedValue == "Y" && hdnfldtsiic.Value != "Y"))
                {
                    trmarketvalue.Visible = true;
                    trmarketurl.Visible = true;
                    if (dscess.Tables[0].Rows.Count > 0)//added lavanya
                    {
                        Muncipal_Flag = dscess.Tables[0].Rows[0]["Muncipal_Flag"].ToString();
                        GHMC_FLG = dscess.Tables[0].Rows[0]["GHMC_FLG"].ToString();
                        HMR_FLG = dscess.Tables[0].Rows[0]["HMR_FLG"].ToString();
                        HMDA_FLG = dscess.Tables[0].Rows[0]["HMDA_FLG"].ToString();
                        KUDA_FLAG = dscess.Tables[0].Rows[0]["KUDA_FLAG"].ToString();
                        DTCPFLAG = dscess.Tables[0].Rows[0]["DTCPFLAG"].ToString();
                        YTDA = dscess.Tables[0].Rows[0]["YTD"].ToString();
                        Hmwssbflg = dscess.Tables[0].Rows[0]["Hmwssb_Flg"].ToString();
                        CDMAFLAG = dscess.Tables[0].Rows[0]["CDMA_FLAG"].ToString().Trim();
                        RWSFLAG = dscess.Tables[0].Rows[0]["RWSFLAG"].ToString().Trim();
                        SUDAFLAG = dscess.Tables[0].Rows[0]["SUDAFLAG"].ToString().Trim();
                        NUDAFLAG = dscess.Tables[0].Rows[0]["NUDAFLAG"].ToString().Trim();


                        SUDASIDDIPET = dscess.Tables[0].Rows[0]["SUDASIDDIPET"].ToString().Trim();
                        SUDAKHAMMAM = dscess.Tables[0].Rows[0]["SUDAKHAMMAM"].ToString().Trim();
                        FCDAFLAG = dscess.Tables[0].Rows[0]["FCDAFLAG"].ToString().Trim();
                        CMCFLAG = dscess.Tables[0].Rows[0]["CMCFLAG"].ToString().Trim();
                        MMCFLAG = dscess.Tables[0].Rows[0]["MMCFLAG"].ToString().Trim();


                        HDNNUDANIZAMABAD.Value = NUDAFLAG.ToString();
                        HDNSUDASIDDIPET.Value = SUDASIDDIPET.ToString();
                        HDNSUDAKHAMMAM.Value = SUDAKHAMMAM.ToString();
                        HDNSUDAKARIMNAGAR.Value = SUDAFLAG.ToString();

                        if (MMCFLAG != null && MMCFLAG == "Y")
                        {
                            ddlLoc_of_unit.Items.Clear();
                            ddlLoc_of_unit.Items.Insert(0, new ListItem("--Select--", "0"));
                            ddlLoc_of_unit.Items.Insert(1, new ListItem("Purview of MMC", "15"));
                            ddlLoc_of_unit.SelectedValue = "15";
                        }

                        if (CMCFLAG != null && CMCFLAG == "Y")
                        {
                            ddlLoc_of_unit.Items.Clear();
                            ddlLoc_of_unit.Items.Insert(0, new ListItem("--Select--", "0"));
                            ddlLoc_of_unit.Items.Insert(1, new ListItem("Purview of CMC", "14"));
                            ddlLoc_of_unit.SelectedValue = "14";
                        }
                        if (FCDAFLAG != null && FCDAFLAG == "Y")
                        {
                            ddlLoc_of_unit.Items.Clear();
                            ddlLoc_of_unit.Items.Insert(0, new ListItem("--Select--", "0"));
                            ddlLoc_of_unit.Items.Insert(1, new ListItem("Purview of FCDA", "13"));
                            ddlLoc_of_unit.SelectedValue = "13";
                        }
                        if (SUDASIDDIPET != null && SUDASIDDIPET == "Y")
                        {
                            ddlLoc_of_unit.Items.Clear();
                            ddlLoc_of_unit.Items.Insert(0, new ListItem("--Select--", "0"));
                            ddlLoc_of_unit.Items.Insert(1, new ListItem("Purview of SUDA_SIDDIPET", "12"));
                            //ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
                            ddlLoc_of_unit.SelectedValue = "12";
                        }
                        if (SUDAKHAMMAM != null && SUDAKHAMMAM == "Y")
                        {
                            ddlLoc_of_unit.Items.Clear();
                            ddlLoc_of_unit.Items.Insert(0, new ListItem("--Select--", "0"));
                            ddlLoc_of_unit.Items.Insert(1, new ListItem("Purview of SUDA_KHAMMAM", "11"));
                            //ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
                            ddlLoc_of_unit.SelectedValue = "11";
                        }
                        if (NUDAFLAG != null && NUDAFLAG == "Y")
                        {
                            ddlLoc_of_unit.Items.Clear();
                            ddlLoc_of_unit.Items.Insert(0, new ListItem("--Select--", "0"));
                            ddlLoc_of_unit.Items.Insert(1, new ListItem("Purview of NUDA", "10"));
                            //ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
                            ddlLoc_of_unit.SelectedValue = "10";
                        }
                        if (SUDAFLAG != null && SUDAFLAG == "Y")
                        {
                            ddlLoc_of_unit.Items.Clear();
                            ddlLoc_of_unit.Items.Insert(0, new ListItem("--Select--", "0"));
                            ddlLoc_of_unit.Items.Insert(1, new ListItem("Purview of SUDA_KARIMNAGAR", "9"));
                            //ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
                            ddlLoc_of_unit.SelectedValue = "9";
                        }
                        if (GHMC_FLG != null && GHMC_FLG == "Y")
                        {
                            ddlLoc_of_unit.Items.Clear();
                            ddlLoc_of_unit.Items.Insert(0, new ListItem("--Select--", "0"));
                            ddlLoc_of_unit.Items.Insert(1, new ListItem("Purview of GHMC", "5"));
                            //ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
                            ddlLoc_of_unit.SelectedValue = "5";
                        }
                        if ((Muncipal_Flag != null && Muncipal_Flag == "Y") || (DTCPFLAG == "Y"))
                        {
                            ddlLoc_of_unit.Items.Clear();
                            ddlLoc_of_unit.Items.Insert(0, new ListItem("--Select--", "0"));//"--Select--"); //new ListItem("--Select--", "0")
                            ddlLoc_of_unit.Items.Insert(1, new ListItem("Purview of DT&CP", "2"));
                            //ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
                            ddlLoc_of_unit.SelectedValue = "2";
                        }
                        if (HMDA_FLG != null && HMDA_FLG == "Y")
                        {
                            ddlLoc_of_unit.Items.Clear();
                            ddlLoc_of_unit.Items.Insert(0, new ListItem("--Select--", "0"));
                            ddlLoc_of_unit.Items.Insert(1, new ListItem("Purview of HMDA", "1"));
                            //ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
                            ddlLoc_of_unit.SelectedValue = "1";
                        }
                        if (KUDA_FLAG != null && KUDA_FLAG == "Y")
                        {
                            ddlLoc_of_unit.Items.Clear();
                            ddlLoc_of_unit.Items.Insert(0, new ListItem("--Select--", "0"));
                            ddlLoc_of_unit.Items.Insert(1, new ListItem("Purview of KUDA", "3"));
                            //ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
                            ddlLoc_of_unit.SelectedValue = "3";
                        }
                        if (YTDA != null && YTDA == "Y")
                        {
                            ddlLoc_of_unit.Items.Clear();
                            ddlLoc_of_unit.Items.Insert(0, new ListItem("--Select--", "0"));
                            ddlLoc_of_unit.Items.Insert(1, new ListItem("Purview of YTDA", "8"));
                            //ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
                            ddlLoc_of_unit.SelectedValue = "8";
                        }

                        if (Hmwssbflg == "Y" && hdfFapplicationdate.Value == "Y")
                        {
                            // int asb = 0;
                            foreach (GridViewRow gvrTEMPVehMstr in gvmodelsnames.Rows)
                            {
                                CheckBox txtMakerGvV = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                                if (rdo_borewell.SelectedValue != "Y")
                                {
                                    if (gvrTEMPVehMstr.RowIndex == 1)
                                    {
                                        txtMakerGvV.Checked = true;
                                        //asb = asb + 1;
                                    }
                                }
                                else
                                {
                                    if (gvrTEMPVehMstr.RowIndex == 0)
                                    {
                                        txtMakerGvV.Checked = true;
                                        //asb = asb + 1;
                                    }
                                }
                                // txtMakerGvV.Enabled = false;
                            }
                            //foreach (GridViewRow gvrTEMPVehMstr in gvmodelsnames.Rows)
                            //{
                            //    CheckBox txtMakerGvV = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                            //    if (asb == 0)
                            //    {
                            //        txtMakerGvV.Enabled = true;
                            //    }
                            //}
                        }
                        else if (CDMAFLAG == "Y")
                        {
                            // int asb = 0;
                            foreach (GridViewRow gvrTEMPVehMstr in gvmodelsnames.Rows)
                            {
                                CheckBox txtMakerGvV = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                                if (rdo_borewell.SelectedValue != "Y")
                                {
                                    if (gvrTEMPVehMstr.RowIndex == 1)
                                    {
                                        txtMakerGvV.Checked = false;
                                        txtMakerGvV.Enabled = false;
                                        //asb = asb + 1;
                                    }

                                    if (gvrTEMPVehMstr.RowIndex == 3)
                                    {
                                        txtMakerGvV.Checked = true;
                                        //asb = asb + 1;
                                    }
                                }
                                else
                                {
                                    if (gvrTEMPVehMstr.RowIndex == 0)
                                    {
                                        txtMakerGvV.Checked = false;
                                        txtMakerGvV.Enabled = false;
                                        //asb = asb + 1;
                                    }

                                    if (gvrTEMPVehMstr.RowIndex == 2)
                                    {
                                        txtMakerGvV.Checked = true;
                                        //asb = asb + 1;
                                    }
                                }
                                // txtMakerGvV.Enabled = false;
                            }
                            //foreach (GridViewRow gvrTEMPVehMstr in gvmodelsnames.Rows)
                            //{
                            //    CheckBox txtMakerGvV = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                            //    if (asb == 0)
                            //    {
                            //        txtMakerGvV.Enabled = true;
                            //    }
                            //}
                        }
                        else if (RWSFLAG == "Y")
                        {
                            // int asb = 0;
                            foreach (GridViewRow gvrTEMPVehMstr in gvmodelsnames.Rows)
                            {
                                CheckBox txtMakerGvV = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                                if (rdo_borewell.SelectedValue != "Y")
                                {
                                    if (gvrTEMPVehMstr.RowIndex == 1)
                                    {
                                        txtMakerGvV.Checked = false;
                                        txtMakerGvV.Enabled = false;
                                        //asb = asb + 1;
                                    }

                                    if (gvrTEMPVehMstr.RowIndex == 4)
                                    {
                                        txtMakerGvV.Checked = true;
                                        //asb = asb + 1;
                                    }
                                }
                                else
                                {
                                    if (gvrTEMPVehMstr.RowIndex == 0)
                                    {
                                        txtMakerGvV.Checked = false;
                                        txtMakerGvV.Enabled = false;
                                        //asb = asb + 1;
                                    }

                                    if (gvrTEMPVehMstr.RowIndex == 3)
                                    {
                                        txtMakerGvV.Checked = true;
                                        //asb = asb + 1;
                                    }
                                }
                                // txtMakerGvV.Enabled = false;
                            }
                            //foreach (GridViewRow gvrTEMPVehMstr in gvmodelsnames.Rows)
                            //{
                            //    CheckBox txtMakerGvV = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                            //    if (asb == 0)
                            //    {
                            //        txtMakerGvV.Enabled = true;
                            //    }
                            //}
                        }
                        else
                        {
                            foreach (GridViewRow gvrTEMPVehMstr in gvmodelsnames.Rows)
                            {
                                CheckBox txtMakerGvV = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                                if (rdo_borewell.SelectedValue != "Y")
                                {
                                    if (gvrTEMPVehMstr.RowIndex == 1)
                                    {
                                        txtMakerGvV.Checked = false;
                                        txtMakerGvV.Enabled = false;
                                        //asb = asb + 1;
                                    }
                                    //if (gvrTEMPVehMstr.RowIndex == 2)
                                    //{
                                    //    txtMakerGvV.Checked = false;
                                    //    txtMakerGvV.Enabled = false;
                                    //    //asb = asb + 1;
                                    //}
                                    if (gvrTEMPVehMstr.RowIndex == 3)
                                    {
                                        txtMakerGvV.Checked = false;
                                        txtMakerGvV.Enabled = false;
                                        //asb = asb + 1;
                                    }
                                    if (gvrTEMPVehMstr.RowIndex == 4)
                                    {
                                        txtMakerGvV.Checked = false;
                                        txtMakerGvV.Enabled = false;
                                        //asb = asb + 1;
                                    }
                                }
                                else
                                {
                                    if (gvrTEMPVehMstr.RowIndex == 0)
                                    {
                                        txtMakerGvV.Checked = false;
                                        txtMakerGvV.Enabled = false;
                                        //asb = asb + 1;
                                    }
                                    //if (gvrTEMPVehMstr.RowIndex ==1)
                                    //{
                                    //    txtMakerGvV.Checked = false;
                                    //    txtMakerGvV.Enabled = false;
                                    //    //asb = asb + 1;
                                    //}
                                    if (gvrTEMPVehMstr.RowIndex == 2)
                                    {
                                        txtMakerGvV.Checked = false;
                                        txtMakerGvV.Enabled = false;
                                        //asb = asb + 1;
                                    }
                                    if (gvrTEMPVehMstr.RowIndex == 3)
                                    {
                                        txtMakerGvV.Checked = false;
                                        txtMakerGvV.Enabled = false;
                                        //asb = asb + 1;
                                    }
                                }
                                // txtMakerGvV.Enabled = false;
                            }
                        }
                        if (hdfFapplicationdate.Value == "N")
                        {
                            hdfFapplicationdate.Value = "Y";
                        }
                        //ChkWater_reg_from.Items.Clear();
                        //ChkWater_reg_from.Items.Insert(0, new ListItem("New Bore well"));
                        //ChkWater_reg_from.Items.Insert(0, new ListItem("HMWS &amp; SB"));
                        //ChkWater_reg_from.Items.Insert(0, new ListItem("Rivers/Canals"));
                    }
                }
                else
                {
                    ddlLoc_of_unit.Items.Clear();
                    ddlLoc_of_unit.Items.Insert(0, new ListItem("--Select--", "0"));

                    ddlLoc_of_unit.Items.Insert(1, new ListItem("IALA (TSIIC)", "4"));
                    ddlLoc_of_unit.SelectedValue = "4";
                    ddlLoc_of_unit.Enabled = false;
                    trmarketvalue.Visible = false;
                    trmarketurl.Visible = false;
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
                        trunderlimits.Visible = true;
                    }
                    else
                    {
                        RdFall_in_Municipal.SelectedValue = "R";
                        RdFall_in_Municipal.Enabled = true;
                        trunderlimits.Visible = false;
                    }
                    if (UnderLimits != null && UnderLimits != "")
                        lblLimits.Text = UnderLimits;

                }
                //if (rdIaLa_Lst.SelectedValue == "Y")
                //{
                //    ddlLoc_of_unit.SelectedValue = "4";
                //    ddlLoc_of_unit.Enabled = false;
                //}
                if (ddlLoc_of_unit.SelectedValue != "0")
                    ddlLoc_of_unit_SelectedIndexChanged(sender, e);
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
    public DataSet GetUnderLimitsOfVillagenew(string intVillageid)
    {

        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[GET_UNDERLIMITSOF_VILLAGE_NEW]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;



            if (intVillageid.Trim().ToString() == "" || intVillageid.ToString().Trim() == null || intVillageid.ToString().Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@intVillageid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@intVillageid", SqlDbType.VarChar).Value = intVillageid.Trim();
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
    public DataSet GetUnderLimitsOfVillagenew_WITHFCDA(string intVillageid)
    {

        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[GET_UNDERLIMITSOF_VILLAGE_NEW_WITHFCDA]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;



            if (intVillageid.Trim().ToString() == "" || intVillageid.ToString().Trim() == null || intVillageid.ToString().Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@intVillageid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@intVillageid", SqlDbType.VarChar).Value = intVillageid.Trim();
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

    public DataSet GetUnderLimitsOfVillagenew_WITHCMCMMC(string intVillageid)
    {

        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[GET_UNDERLIMITSOF_VILLAGE_NEW_WITHCMCMMC]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;



            if (intVillageid.Trim().ToString() == "" || intVillageid.ToString().Trim() == null || intVillageid.ToString().Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@intVillageid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@intVillageid", SqlDbType.VarChar).Value = intVillageid.Trim();
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
    protected void TxtTot_ExtentNew_TextChanged(object sender, EventArgs e)
    {
        try
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
                if (ddllandmesurements.SelectedItem.Text.ToUpper() != "ACRE")
                {
                    if (TxtTot_ExtentNew.Text.TrimStart().TrimEnd() != "")
                    {
                        TxtTot_Extent.Text = (Convert.ToDecimal(ddllandmesurements.SelectedValue) * Convert.ToDecimal(TxtTot_ExtentNew.Text.TrimStart().TrimEnd())).ToString();
                    }

                }
                else
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
                }
                if (ddllandmesurements.SelectedItem.Text.ToUpper() != "ACRE")
                {
                    //string test = "22.362525";
                    //string ttt = test.Substring(0, test.IndexOf('.'));
                    if (TxtTot_Extent.Text.Substring(TxtTot_Extent.Text.IndexOf('.') + 1).Length > 2 && TxtTot_Extent.Text.Contains('.'))
                    {
                        TxtTot_Extent.Text = TxtTot_Extent.Text.Substring(0, TxtTot_Extent.Text.IndexOf('.')) + TxtTot_Extent.Text.Substring(TxtTot_Extent.Text.IndexOf('.'), 3);
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
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }

    }
    protected void ddllandmesurements_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            txtgunthas.Text = "";
            TxtTot_ExtentNew.Text = "";
            TxtTot_Extent.Text = "";

            if (ddllandmesurements.SelectedItem.Text.ToUpper() == "ACRE")
            {
                // TxtTot_ExtentNew.MaxLength = 4;
                trtxtgunthas.Visible = true;
                TxtTot_ExtentNew.Attributes.Add("placeholder", "Acre");
                tdTxtTot_ExtentNew.InnerHtml = "Acres&nbsp;&nbsp;&nbsp";
                TxtTot_ExtentNew.Attributes.Add("onKeyPress", "javascript:return ValidateNumberWithoutSpaceAdhar(event);");
                txtgunthas.Attributes.Add("onKeyPress", "javascript:return ValidateNumberWithoutSpaceOnlyrestrictedNumbers(event,this);");
                txtgunthas.Attributes.Add("onKeyUp", "javascript:return restrictNumberonly(event,this );");
            }
            else
            {
                tdTxtTot_ExtentNew.InnerHtml = ddllandmesurements.SelectedItem.Text + "&nbsp;&nbsp;&nbsp";
                TxtTot_ExtentNew.Attributes.Add("placeholder", "");
                TxtTot_ExtentNew.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");

                trtxtgunthas.Visible = false;
            }

            TxtTot_Extent.Text = "";
            TxtTot_ExtentNew.Text = "";
            ddllandmesurements.Focus();
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
        //if (ddllandmesurements.SelectedItem.Text.ToUpper() == "ACRE" || ddllandmesurements.SelectedItem.Text.ToUpper() == "HECTARE")
        //{
        //    TxtTot_ExtentNew.MaxLength = 4;

        //}
        //else
        //{
        //    TxtTot_ExtentNew.MaxLength = 6;
        //}
    }
    protected void ddlcurrencytype_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
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

            CalculatationEnterprisePrjCost();
            CalculatationEnterprise();

            hdnfocus.Value = TxtVal_Build.ClientID;
            ProjectCostFinal();
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
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void btnShowEnclosers_Click(object sender, EventArgs e)
    {
        // ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Key", "PopupCenter('EncloserList.aspx','popUpWindow','1050','600');", true);
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<Script>window.open('EncloserList.aspx','popUpWindow','height=600,width=850,status=no,toolbar=no,menubar=no,location=no');</Script>", false);
    }
    protected void txtgunthas_TextChanged(object sender, EventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void rdIaLa_Lst_SelectedIndexChanged(object sender, EventArgs e)
    {
        hdnfldtsiic.Value = "";
        try
        {
            if (rdIaLa_Lst.SelectedValue.ToString().Trim() == "Y")
            {
                lblIndusText.Visible = true;
                ddlIndustrialParkName.Visible = true;
                trtsiicplotno.Visible = true;
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
                ddlLoc_of_unit.Items.Clear();
                ddlLoc_of_unit.Items.Insert(0, new ListItem("--Select--", "0"));
                AddSelect(ddlIndustrialParkName);
            }
            else
            {
                lblIndusText.Visible = false;
                trtsiicplotno.Visible = false;
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

                ddlLoc_of_unit.Items.Clear();
                ddlLoc_of_unit.Items.Insert(0, new ListItem("--Select--", "0"));
                // ddlLoc_of_unit.SelectedValue = "2";
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
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void ddlIndustrialParkName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlLoc_of_unit.Items.Clear();
            ddlLoc_of_unit.Items.Insert(0, new ListItem("--Select--", "0"));
            hdnfldtsiic.Value = "";
            DataSet dsParks = new DataSet();
            int IALACode = Convert.ToInt32(ddlIndustrialParkName.SelectedValue);
            dsParks = objcommon.GetIALAParks(IALACode, 0);
            if (dsParks != null && dsParks.Tables.Count > 0 && dsParks.Tables[0].Rows.Count > 0)
            {
                string districtCd = "0", MandalCd = "0", VillageCd = "0";
                districtCd = dsParks.Tables[0].Rows[0]["Districtcd"].ToString();
                MandalCd = dsParks.Tables[0].Rows[0]["Mandalcd"].ToString();
                VillageCd = dsParks.Tables[0].Rows[0]["Villagecd"].ToString();
                hdnfldtsiic.Value = dsParks.Tables[0].Rows[0]["Is_IALA_Exists"].ToString();

                //ddlProp_intDistrictid.SelectedValue = ddlProp_intDistrictid.Items.FindByValue(districtCd).Value;

                //ddlProp_intDistrictid_SelectedIndexChanged(sender, e);
                if (MandalCd != "")
                {
                    ddlProp_intMandalid.SelectedValue = ddlProp_intMandalid.Items.FindByValue(MandalCd).Value;
                    ddlProp_intMandalid_SelectedIndexChanged(sender, e);
                }
                else
                {
                    ddlProp_intMandalid.SelectedIndex = 0;
                    ddlProp_intVillageid.SelectedIndex = 0;
                }
                if (VillageCd != "")
                {
                    ddlProp_intVillageid.SelectedValue = ddlProp_intVillageid.Items.FindByValue(VillageCd).Value;
                    ddlProp_intVillageid_SelectedIndexChanged(sender, e);
                }
                else
                {
                    ddlProp_intVillageid.SelectedIndex = 0;
                }
            }
            else
            {
                hdnfldtsiic.Value = "";
                ddlProp_intMandalid.SelectedIndex = 0;
                ddlProp_intVillageid.SelectedIndex = 0;
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
    //public void BindLabourApplication()
    //{
    //    try
    //    {
    //        DataSet dsd = new DataSet();
    //        dsd = Gen.GetLabourApplicationType();
    //        if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
    //        {
    //            ChkLabour_Application.DataSource = dsd.Tables[0];
    //            ChkLabour_Application.DataTextField = "Qname";
    //            ChkLabour_Application.DataValueField = "Application_Id";
    //            ChkLabour_Application.DataBind();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        //lblerror.Text = ex.Message;
    //        //lblerror.CssClass = "errormsg";
    //    }
    //}
    public void ValidationOnProjectCostSelection()
    {
        string Msg = "";
        if (ddlproposal.SelectedItem.Text == "--Select--")
        {
            Msg = "Please Select Project Proposal";
            ddlproposal.Focus();
        }
        if (ddlcurrencytype.SelectedValue == "--Select--")
        {
            Msg = "Please Select Project Cost Currency";
            ddlcurrencytype.Focus();
        }
        if (Msg != "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Msg + "');", true);
            return;
        }
    }
    public void ProjectCostFinal()
    {
        string Msg = "";
        if (Convert.ToDecimal(TxtTot_PrjCost.Text.Trim()) < 1)
        {
            Msg = "Your project cost mentioned below 1 Lakhs. please correct the same..!";
            ddlproposal.Focus();
        }
        if (Msg != "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Msg + "');", true);
            return;
        }
        if (Convert.ToDecimal(TxtTot_PrjCost.Text.Trim()) > 10000)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Your project cost mentioned above 100 crores. please proceede if this is correct..!');", true);
        }
    }
    protected void ddlproposal_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlproposal.SelectedValue == "1")
        {
            tdprojectcostname.InnerHtml = "<u>New Investment</u>";
            tblexpansion.Visible = false;
            trCFECFO.Visible = false;

        }
        else if (ddlproposal.SelectedValue == "2")
        {
            tdprojectcostname.InnerHtml = "<u>Existing Investment</u>";
            tblexpansion.Visible = true;
            trCFECFO.Visible = true;
            //tblexpansion.Visible = false;
            if (txtCFEUID.Text == "")
                txtCFEUID.Enabled = true;
            ddlcurrencytype_SelectedIndexChanged(sender, e);

        }
        else
        {
            tdprojectcostname.InnerHtml = "<u>New Investment</u>";
            tblexpansion.Visible = false;
        }
    }
    protected void TxtVal_Land_Actual_TextChanged(object sender, EventArgs e)
    {
        try
        {
            ValidationOnProjectCostSelection();
            if (ddlcurrencytype.SelectedValue != "0")
            {
                if (TxtVal_Land_Actual.Text.TrimStart().TrimEnd() != "" && TxtVal_Land_Actual.Text.TrimStart().TrimEnd() != "0")
                {
                    TxtVal_Land.Text = (Convert.ToDecimal(TxtVal_Land_Actual.Text.Trim()) * Convert.ToDecimal(ddlcurrencytype.SelectedValue)).ToString();
                    TxtVal_Land_TextChanged(sender, e);
                    TextBox1.Text = "";
                }
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
    protected void TxtVal_Build_Actual_TextChanged(object sender, EventArgs e)
    {
        try
        {
            ValidationOnProjectCostSelection();
            if (ddlcurrencytype.SelectedValue != "0")
            {
                if (TxtVal_Build_Actual.Text.TrimStart().TrimEnd() != "" && TxtVal_Build_Actual.Text.TrimStart().TrimEnd() != "0")
                {
                    TxtVal_Build.Text = (Convert.ToDecimal(TxtVal_Build_Actual.Text.Trim()) * Convert.ToDecimal(ddlcurrencytype.SelectedValue)).ToString();
                    TxtVal_Build_TextChanged(sender, e);
                    TextBox1.Text = "";
                }
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
    protected void TxtVal_Plant_Actual_TextChanged(object sender, EventArgs e)
    {
        try
        {
            ValidationOnProjectCostSelection();
            if (ddlcurrencytype.SelectedValue != "0")
            {
                if (TxtVal_Plant_Actual.Text.TrimStart().TrimEnd() != "" && TxtVal_Plant_Actual.Text.TrimStart().TrimEnd() != "0")
                {
                    TxtVal_Plant.Text = (Convert.ToDecimal(TxtVal_Plant_Actual.Text.Trim()) * Convert.ToDecimal(ddlcurrencytype.SelectedValue)).ToString();
                    TxtVal_Plant_TextChanged(sender, e);
                    TextBox1.Text = "";
                }
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
                    TextBox3.Text = "";
                }
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

    protected void TxtVal_LandExpansion_TextChanged(object sender, EventArgs e)
    {
        try
        {
            CalculatationEnterprisePrjCostExpansion();

            CalculatationEnterprisevalueLandExpansion();
            CalculatationEnterprisevalueBildExpansion();
            CalculatationEnterprisevaluePlantExpansion();
            CalculatationEnterprisefinalTotalvalue();
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
    protected void TxtVal_Build_ActualExpn_TextChanged(object sender, EventArgs e)
    {
        try
        {
            ValidationOnProjectCostSelection();
            if (ddlcurrencytype.SelectedValue != "0")
            {
                if (TxtVal_Build_ActualExpn.Text.TrimStart().TrimEnd() != "" && TxtVal_Build_ActualExpn.Text.TrimStart().TrimEnd() != "0")
                {
                    TxtVal_BuildExpanstion.Text = (Convert.ToDecimal(TxtVal_Build_ActualExpn.Text.Trim()) * Convert.ToDecimal(ddlcurrencytype.SelectedValue)).ToString();
                    TxtVal_BuildExpanstion_TextChanged(sender, e);
                    TextBox3.Text = "";
                }
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
    protected void TxtVal_BuildExpanstion_TextChanged(object sender, EventArgs e)
    {
        try
        {
            CalculatationEnterprisePrjCostExpansion();

            CalculatationEnterprisevalueLandExpansion();
            CalculatationEnterprisevalueBildExpansion();
            CalculatationEnterprisevaluePlantExpansion();
            CalculatationEnterprisefinalTotalvalue();
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
    protected void TxtVal_Plant_ActualExpansion_TextChanged(object sender, EventArgs e)
    {
        try
        {
            ValidationOnProjectCostSelection();
            if (ddlcurrencytype.SelectedValue != "0")
            {
                if (TxtVal_Plant_ActualExpansion.Text.TrimStart().TrimEnd() != "" && TxtVal_Plant_ActualExpansion.Text.TrimStart().TrimEnd() != "0")
                {
                    TxtVal_PlantExpanstion.Text = (Convert.ToDecimal(TxtVal_Plant_ActualExpansion.Text.Trim()) * Convert.ToDecimal(ddlcurrencytype.SelectedValue)).ToString();
                    TxtVal_PlantExpanstion_TextChanged(sender, e);
                    TextBox3.Text = "";
                }
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
    protected void TxtVal_PlantExpanstion_TextChanged(object sender, EventArgs e)
    {
        try
        {
            CalculatationEnterprisePrjCostExpansion();

            CalculatationEnterprisevalueLandExpansion();
            CalculatationEnterprisevalueBildExpansion();
            CalculatationEnterprisevaluePlantExpansion();
            CalculatationEnterprisefinalTotalvalue();
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
    protected void ChkLabour_Application_SelectedIndexChanged(object sender, EventArgs e)
    {
        //foreach (ListItem li in ChkLabour_Application.Items)
        //{
        //    if (li.Selected == true)
        //    {
        //        if (li.Value == "2")
        //        {
        //            tract4.Visible = true;
        //            trnoofworkers.Visible = true;
        //        }
        //    }
        //}

        //if (ChkLabour_Application.SelectedValue == "2")
        //{
        //    tract4.Visible = true;
        //    trnoofworkers.Visible = true;
        //}
        //else
        //{
        //    tract4.Visible = false;
        //    trnoofworkers.Visible = false;
        //}

    }

    protected void TxtBuilt_up_Area_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (TxtTot_Extent.Text.Trim().TrimStart() != "" && TxtBuilt_up_Area.Text.Trim().TrimStart() != "")
            {
                if (Convert.ToDecimal(TxtTot_Extent.Text.Trim().TrimStart()) <= Convert.ToDecimal(TxtBuilt_up_Area.Text.Trim().TrimStart()))
                {
                    ////comment on 21/11/2017 as per instruction of chandrashekar sir///
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Built up Area should not be greater then Total Extent of Land!!.');", true);
                    //TxtBuilt_up_Area.Text = "";
                    //return;
                    ///end of comment code//
                }
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
    public void CalculatationEnterprisevalueLandExpansion()
    {
        try
        {
            if (ddlSector_Ent.SelectedIndex != 0)
            {
                if (TxtVal_Land.Text.Trim() == "")
                {
                    TxtVal_Land.Text = "0";
                }

                if (TxtVal_LandExpansion.Text.Trim() == "")
                {
                    TxtVal_LandExpansion.Text = "0";
                }

                lbltotalexpvalulandexp.Text = Convert.ToString((Convert.ToDecimal(TxtVal_Land.Text) + Convert.ToDecimal(TxtVal_LandExpansion.Text)));
                lblmsg.Text = "";
                CalculatationEnterprisefinalTotalvalue();
            }
            else
            {
                txtlbltotalprojectcostexpanstion.Text = "0";
                lblmsg0.Text = "Please Select Sector of Enterprise";
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
    public void CalculatationEnterprisevalueBildExpansion()
    {
        try
        {
            if (ddlSector_Ent.SelectedIndex != 0)
            {
                if (TxtVal_Build.Text.Trim() == "")
                {
                    TxtVal_Build.Text = "0";
                }

                if (TxtVal_BuildExpanstion.Text.Trim() == "")
                {
                    TxtVal_BuildExpanstion.Text = "0";
                }

                lblbuildtotalexpvavalue.Text = Convert.ToString((Convert.ToDecimal(TxtVal_Build.Text) + Convert.ToDecimal(TxtVal_BuildExpanstion.Text)));
                lblmsg.Text = "";
                CalculatationEnterprisefinalTotalvalue();
            }
            else
            {
                txtlbltotalprojectcostexpanstion.Text = "0";
                lblmsg0.Text = "Please Select Sector of Enterprise";
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
    public void CalculatationEnterprisevaluePlantExpansion()
    {
        try
        {
            if (ddlSector_Ent.SelectedIndex != 0)
            {
                if (TxtVal_Plant.Text.Trim() == "")
                {
                    TxtVal_Plant.Text = "0";
                }

                if (TxtVal_PlantExpanstion.Text.Trim() == "")
                {
                    TxtVal_PlantExpanstion.Text = "0";
                }

                lblplantotalexp.Text = Convert.ToString((Convert.ToDecimal(TxtVal_Plant.Text) + Convert.ToDecimal(TxtVal_PlantExpanstion.Text)));
                lblmsg.Text = "";
                CalculatationEnterprisefinalTotalvalue();
            }
            else
            {
                txtlbltotalprojectcostexpanstion.Text = "0";
                lblmsg0.Text = "Please Select Sector of Enterprise";
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

    public void CalculatationEnterprisefinalTotalvalue()
    {
        try
        {
            if (ddlSector_Ent.SelectedIndex != 0)
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
                lblmsg0.Text = "Please Select Sector of Enterprise";
            }
            CalculatationEnterprise();
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
    protected void RdbExecpted2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (RdbExecpted2.SelectedValue == "Y")
            {
                // txtNoofworkers.Visible = true;
                tract4.Visible = true;
                rdbact2_SelectedIndexChanged(sender, e);
            }
            else
            {
                // txtNoofworkers.Visible = false;
                tract4.Visible = false;
                rdbact2.SelectedValue = "N";
                rdbact2_SelectedIndexChanged(sender, e);
                //tract2.Visible = false;
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
    protected void rdbact2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbact2.SelectedValue == "Y")
        {
            tract2.Visible = true;

        }
        else
        {
            tract2.Visible = false;
            txtNoofworkers.Text = "";
            // txtNoofworkers.Visible = false;
        }
    }

    //protected void Tab1_Click(object sender, EventArgs e)
    //{
    //    Tab1.CssClass = "Clicked";
    //    Tab2.CssClass = "Initial";
    //    Tab3.CssClass = "Initial";
    //    MainView.ActiveViewIndex = 0;
    //}

    //protected void Tab2_Click(object sender, EventArgs e)
    //{
    //    Tab1.CssClass = "Initial";
    //    Tab2.CssClass = "Clicked";
    //    Tab3.CssClass = "Initial";
    //    MainView.ActiveViewIndex = 1;
    //}

    //protected void Tab3_Click(object sender, EventArgs e)
    //{
    //    Tab1.CssClass = "Initial";
    //    Tab2.CssClass = "Initial";
    //    Tab3.CssClass = "Clicked";
    //    MainView.ActiveViewIndex = 2;
    //}

    protected void btntab1next_Click(object sender, EventArgs e)
    {

        //DataSet dscheck = new DataSet();
        //dscheck = checkcfealreadyexists(ddlProp_intDistrictid.SelectedValue, ddlProp_intMandalid.SelectedValue, ddlProp_intVillageid.SelectedValue, TxtnameofUnit.Text.Trim(), Session["uid"].ToString());
        //if (dscheck != null && dscheck.Tables.Count > 0 && dscheck.Tables[0].Rows.Count > 0)
        //{
        //    string msg = "Unit already exists with user id -" + dscheck.Tables[0].Rows[0]["UERNAME"].ToString().Trim();
        //    lblmsg0.Text = msg;
        //    Failure.Visible = true;
        //    success.Visible = false;
        //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert(msg);", true);
        //    return;
        //}

        if (Convert.ToDecimal(TxtTot_Extent.Text.Trim().TrimStart()) <= 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Total Extent of Land should not be Zero!!.');", true);
            return;
        }
        if (ddlSector_Ent.SelectedItem.Text == "--Select--")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please select sector of enterprise!!.');", true);
            return;
        }

        if (ddllandmesurements.SelectedItem.Text != "--Select--")
        {
            if (txtgunthas.Text.Trim() != "" && txtgunthas.Text.Trim() != "0.00")
            {
                lblnalavalue.Text = TxtTot_ExtentNew.Text + " " + ddllandmesurements.SelectedItem.Text + " " + txtgunthas.Text + " Gunthas";
            }
            else
            {
                lblnalavalue.Text = TxtTot_ExtentNew.Text + " " + ddllandmesurements.SelectedItem.Text;
            }
            lblnalavalue.Text = "for (" + lblnalavalue.Text + ")";
        }
        Tab2.Attributes.Add("class", "active");
        Tab1.Attributes.Add("class", "");
        Tab3.Attributes.Add("class", "");
        MainView.ActiveViewIndex = 1;
        //txtCFOUID_TextChanged(sender, e);
    }
    protected void btntab3privious_Click(object sender, EventArgs e)
    {
        Tab2.Attributes.Add("class", "active");
        Tab1.Attributes.Add("class", "");
        Tab3.Attributes.Add("class", "");
        MainView.ActiveViewIndex = 1;
        if (txtCFEUID.Text != "")
            txtCFEUID.Enabled = false;
        if (txtCFOUID.Text != "")
            txtCFOUID.Enabled = false;
    }
    protected void btntab2next_Click(object sender, EventArgs e)
    {
        DataSet dscheck = new DataSet();
        dscheck = checkcfealreadyexists(ddlProp_intDistrictid.SelectedValue, ddlProp_intMandalid.SelectedValue, ddlProp_intVillageid.SelectedValue, TxtnameofUnit.Text.Trim(), Session["uid"].ToString(), ddlproposal.SelectedItem.Text);
        if (dscheck != null && dscheck.Tables.Count > 0 && dscheck.Tables[0].Rows.Count > 0)
        {
            if (dscheck.Tables[0].Rows[0]["UERNAME"].ToString() != "chandraquarry" && dscheck.Tables[0].Rows[0]["UERNAME"].ToString() != "SPMSKZR"
                && dscheck.Tables[0].Rows[0]["UERNAME"].ToString() != "IPPL" && dscheck.Tables[0].Rows[0]["UERNAME"].ToString() != "ITAAN"
                && dscheck.Tables[0].Rows[0]["UERNAME"].ToString() != "BSWML002" && dscheck.Tables[0].Rows[0]["UERNAME"].ToString() != "jankimproducts"
                && dscheck.Tables[0].Rows[0]["UERNAME"].ToString() != "kondapally123" && dscheck.Tables[0].Rows[0]["UERNAME"].ToString() != "blendcolours3"
                && dscheck.Tables[0].Rows[0]["UERNAME"].ToString() != "kamakshi123" && dscheck.Tables[0].Rows[0]["UERNAME"].ToString() != "BAMCO"
                && dscheck.Tables[0].Rows[0]["UERNAME"].ToString() != "nipl555")
            {
                string msg = "Unit already exists with user id -" + dscheck.Tables[0].Rows[0]["UERNAME"].ToString().Trim();
                lblmsg0.Text = msg;
                Failure.Visible = true;
                success.Visible = false;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert(msg);", true);
                return;
            }

        }
        DataSet dsEXPANZERO = new DataSet();
        dsEXPANZERO = CHECKEXPANSIONUSERWITHZERINVESTMENT_EXIST(Session["uid"].ToString());
        if (dsEXPANZERO != null && dsEXPANZERO.Tables.Count > 0 && dsEXPANZERO.Tables[0].Rows.Count > 0)
        {
            HDNEXPANSIONUSER.Value = dsEXPANZERO.Tables[0].Rows[0]["USERID"].ToString().Trim();

        }
        if (ddlproposal.SelectedValue == "1")
        {
            if (Convert.ToDecimal(TxtTot_PrjCost.Text) <= 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Total Project Cost Should not be Zero(0).');", true);
                // lblmsg0.Text = "Total Project Cost Should not be Zero";
                Failure.Visible = true;
                success.Visible = false;
                return;
            }
        }
        else
        {

            if (Convert.ToDecimal(TxtVal_Plant.Text) <= 0)
            {
                lblmsg0.Text = "Plant and Machinery cost Should not be Zero";
                Failure.Visible = true;
                success.Visible = false;
                return;
            }

            if (Convert.ToDecimal(TxtTot_PrjCost.Text) <= 0)
            {
                lblmsg0.Text = "Total Existing Investment Should not be Zero";
                Failure.Visible = true;
                success.Visible = false;
                return;
            }
            if (Convert.ToDecimal(txtlbltotalprojectcostexpanstion.Text) <= 0)
            {
                if (txtCFEUID.Text == "" && txtCFOUID.Text == "")
                {
                    lblmsg0.Text = "Please check once and enter proper existing units CFE,CFO UID No's.";
                    ddlproposal.Enabled = true;
                    Failure.Visible = true;
                    success.Visible = false;
                }

                if (txtCFEUID.Text != "" && txtCFOUID.Text != "")
                {
                    if (HDNEXPANSIONUSER.Value == Session["uid"].ToString())
                    {

                    }
                    else
                    {
                        lblmsg0.Text = "Total Expansion Investment Should not be Zero.";
                        ddlproposal.Enabled = false;
                        Failure.Visible = true;
                        success.Visible = false;
                        return;
                    }
                }

            }
        }

        if (trmarketvalue.Visible == true && Convert.ToDecimal(txtmarketvalue.Text) <= 0)
        {
            lblmsg0.Text = "Land Market Value Should not be Zero";
            Failure.Visible = true;
            success.Visible = false;
            return;
        }
        if (TextBox1.Text == "0" && tblexpansion.Visible == false)
        {
            lblmsg0.Text = "Turnover cannot be zero";
            Failure.Visible = true;
            success.Visible = false;
            TextBox1.Text = "";
            TextBox1.Focus();
            return;
        }
        if (Convert.ToDecimal(TxtTot_PrjCost.Text.Trim()) <= 1)
        {
            lblmsg0.Text = "Your project cost mentioned below 1 Lakhs. please correct the same..!";
            Failure.Visible = true;
            success.Visible = false;
            lblmsg0.Focus();
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Your project cost mentioned below 5 Lakhs. please correct the same..!');", true);
            return;
        }
        if (ddlproposal.SelectedValue == "2")
        {
            if (txtCFEUID.Text == "" && txtCFOUID.Text == "")
            {
                lblmsg0.Text = "Please check once and enter proper existing units CFE,CFO UID No's.";
                ddlproposal.Enabled = true;
                Failure.Visible = true;
                success.Visible = false;
            }
            else
            {
                Tab2.Attributes.Add("class", "");
                Tab1.Attributes.Add("class", "");
                Tab3.Attributes.Add("class", "active");
                MainView.ActiveViewIndex = 2;
            }
        }
        else
        {
            if (Convert.ToDecimal(TxtVal_Plant.Text) <= 0)
            {
                lblmsg0.Text = "Plant and Machinery cost Should not be Zero";
                Failure.Visible = true;
                success.Visible = false;
                return;
            }
            else
            {


                Tab2.Attributes.Add("class", "");
                Tab1.Attributes.Add("class", "");
                Tab3.Attributes.Add("class", "active");
                MainView.ActiveViewIndex = 2;
            }
        }

        //Tab2.Attributes.Add("class", "");
        //Tab1.Attributes.Add("class", "");
        //Tab3.Attributes.Add("class", "active");
        //MainView.ActiveViewIndex = 2;

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Tab2.Attributes.Add("class", "");
        Tab1.Attributes.Add("class", "active");
        Tab3.Attributes.Add("class", "");
        MainView.ActiveViewIndex = 0;
    }

    public DataTable BindModelsData(int iRowIndexx)
    {
        DataTable dtReff = new DataTable();
        DataRow drReff;
        try
        {
            gvmodelsnames.DataSource = null;
            gvmodelsnames.DataBind();


            DataColumn dc = new DataColumn();
            dtReff.Columns.Add("Water required from");
            dtReff.Columns.Add("Water Required per day( in KLD)");
            drReff = dtReff.NewRow();
            if (drReff.ItemArray[0] == null)
            {
                drReff.ItemArray[0] = "";
            }
            dtReff.Rows.Add(drReff);

            for (int i = 0; i < iRowIndexx - 1; i++)
            {
                drReff = dtReff.NewRow();
                dtReff.Rows.Add(drReff);
            }

        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
        return dtReff;
    }

    protected void Rdbact5License_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Rdbact5License.SelectedValue == "Y")
        {
            tract5Licenseemp.Visible = true;
            //  txtContractLabourAct.Visible = true;
        }
        else
        {
            tract5Licenseemp.Visible = false;
            txtact5emp.Text = "";
            // txtContractLabourAct.Visible = false;
        }
    }

    protected void ddlregulation_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ddlregulation.Items.Clear();
        //ddlregulation.Items.Insert(0, new ListItem("--Select--", "0"));
        //ddlvoltage.Items.Clear();
        //ddlvoltage.Items.Insert(0, new ListItem("--Select--", "0"));
        if (ddlregulation.SelectedItem.Text.Trim() == "43(3)" || ddlregulation.SelectedItem.Text.Trim() == "43(4)" || ddlregulation.SelectedItem.Text.Trim() == "36")
        {
            // BindVoltage();
            trvoltage.Visible = true;
            trPlant.Visible = false;
            ddlplant.ClearSelection(); txtagrcapacity.Text = "";
        }
        else if (ddlregulation.SelectedItem.Text.Trim() == "43(4) & 32" || ddlregulation.SelectedItem.Text.Trim() == "32")
        {
            trPlant.Visible = true;

            trvoltage.Visible = false;
            ddlvoltage.ClearSelection();
            txtagrcapacity.Text = "";
        }

    }

    public void BindPlant(DropDownList ddl)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlplant.Items.Clear();
            dsd = Gen.GetPlants("");
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlplant.DataSource = dsd.Tables[0];
                ddlplant.DataValueField = "Plant_Id";
                ddlplant.DataTextField = "Plant_Name";
                ddlplant.DataBind();
                ddlplant.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlplant.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }

    public void BindRegulations(DropDownList ddl)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlregulation.Items.Clear();
            dsd = Gen.GetRegulations();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlregulation.DataSource = dsd.Tables[0];
                ddlregulation.DataValueField = "Regulation_Id";
                ddlregulation.DataTextField = "Regulation_Name";
                ddlregulation.DataBind();
                ddlregulation.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlregulation.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }

    public void BindVoltage(DropDownList ddl)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlvoltage.Items.Clear();
            dsd = Gen.GetVolations("");
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlvoltage.DataSource = dsd.Tables[0];
                ddlvoltage.DataValueField = "Voltage_Id";
                ddlvoltage.DataTextField = "Voltage_Name";
                ddlvoltage.DataBind();
                ddlvoltage.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlvoltage.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }

    protected void RdpIndustry_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (RdpIndustry.SelectedValue == "Y")
            {
                trregulation.Visible = true;
            }
            else
            {
                trregulation.Visible = false;
                trvoltage.Visible = false;
                trPlant.Visible = false;
                trvolcapacity.Visible = false;

                ddlregulation.ClearSelection();
                ddlvoltage.ClearSelection();
                ddlplant.ClearSelection();
                txtagrcapacity.Text = "";
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void rdo_borewell_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            if (rdo_borewell.SelectedValue == "Y")
            {
                gvmodelsnames.DataSource = BindModelsData(Convert.ToInt32(4));
                gvmodelsnames.DataBind();
                dt = BindBasicMethodwithoutborewell();

                //dt = BindBasicMethod();
                foreach (GridViewRow gvrTEMPVehMstr in gvmodelsnames.Rows)
                {
                    Label txtMakerGvV = (Label)gvrTEMPVehMstr.FindControl("lblModelname");
                    txtMakerGvV.Text = dt.Rows[gvrTEMPVehMstr.RowIndex]["Name"].ToString();
                }

            }
            else
            {
                //if (rdo_borewell.SelectedValue == "Y")
                //{
                //    count = 2;
                //}
                //else
                //{
                //    count = 3;
                //}
                gvmodelsnames.DataSource = BindModelsData(Convert.ToInt32(5));
                gvmodelsnames.DataBind();
                dt = BindBasicMethod();
                foreach (GridViewRow gvrTEMPVehMstr in gvmodelsnames.Rows)
                {
                    Label txtMakerGvV = (Label)gvrTEMPVehMstr.FindControl("lblModelname");
                    txtMakerGvV.Text = dt.Rows[gvrTEMPVehMstr.RowIndex]["Name"].ToString();
                }

            }

            ddlProp_intVillageid_SelectedIndexChanged(sender, e);
        }
        catch (Exception ex)
        {
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    public DataTable BindBasicMethodwithoutborewell()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Name", typeof(string));

        DataRow dr = dt.NewRow();
        //dr["Name"] = "New Bore well";
        //dt.Rows.Remove(dr);

        dr = dt.NewRow();
        dr["Name"] = "HMWS & SB";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["Name"] = "Rivers/Canals";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["Name"] = "CDMA";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["Name"] = "Mission Bhagiratha";
        dt.Rows.Add(dr);

        return dt;
    }

    protected void ddlvoltage_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //if (ddlvoltage.SelectedValue == "1")
            //{
            trvolcapacity.Visible = true;
            txtagrcapacity.Enabled = true;
            //}
            //else
            //{
            //    trvolcapacity.Visible = false;
            //}
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void txtCFEUID_TextChanged(object sender, EventArgs e)
    {
        string errormsg = Gen.CHECKVALIDCFECFO(txtCFEUID.Text, "CFE");
        if (errormsg != null && errormsg != "" && errormsg != "VALID UID NUMBER")
        {
            string message = "alert(" + errormsg + ")";
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "alert('" + errormsg + "');", true);
            txtCFEUID.Text = "";
            lblmsg0.Text = "";


        }
        if (errormsg != null && errormsg != "" && errormsg != "PLEASE ENTER VALID UID NUMBER")
        {
            string message = "alert(" + errormsg + ")";
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "alert('" + errormsg + "');", true);
            //txtcfeuidno.Text = "";
            txtCFEUID.Enabled = false;
            txtCFOUID.Enabled = true;
            ViewState["checkCFOCFE"] = "No";
        }
    }

    protected void txtCFOUID_TextChanged(object sender, EventArgs e)
    {
        string errormsg = Gen.CHECKVALIDCFECFO(txtCFOUID.Text, "CFO");
        if (errormsg != null && errormsg != "" && errormsg != "VALID UID NUMBER")
        {
            string message = "alert(" + errormsg + ")";
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "alert('" + errormsg + "');", true);
            txtCFOUID.Text = "";
            lblmsg0.Text = "";
        }
        if (errormsg != null && errormsg != "" && errormsg != "PLEASE ENTER VALID UID NUMBER")
        {
            string message = "alert(" + errormsg + ")";
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "alert('" + errormsg + "');", true);
            //txtcfeuidno.Text = "";
            txtCFOUID.Enabled = false;
            tblexpansion.Visible = true;
            ViewState["checkCFOCFE"] = "Yes";

        }
    }



    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToDecimal(TxtVal_Plant.Text) <= 0 || Convert.ToDecimal(TxtVal_Plant_Actual.Text) <= 0)
            {
                string message = "alert('Plant and Machinery cost should not be zero for Manufacturing Activity')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                lblmsg0.Text = "Plant and Machinery cost Should not be Zero";
                Failure.Visible = true;
                success.Visible = false;
                TxtVal_Plant.Focus();
                return;
            }
            else
            {
                if (TextBox1.Text.TrimStart().TrimEnd() != "" && TextBox1.Text.TrimStart().TrimEnd() != "0")
                {
                    TextBox2.Text = (Convert.ToDecimal(TextBox1.Text.Trim()) * Convert.ToDecimal(ddlcurrencytype.SelectedValue)).ToString();
                    TextBox2_TextChanged(sender, e);
                }
                else
                {
                    string message = "Turnover cannot be Zero";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "alert('" + message + "');", true);
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox1.Focus();
                }
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

    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        try
        {
            CalculatationEnterprise();

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
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (TextBox3.Text.TrimStart().TrimEnd() != "" && TextBox3.Text.TrimStart().TrimEnd() != "0")
            {
                TextBox4.Text = (Convert.ToDecimal(TextBox3.Text.Trim()) * Convert.ToDecimal(ddlcurrencytype.SelectedValue)).ToString();
                TextBox4_TextChanged(sender, e);
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
    protected void TextBox4_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToDecimal(TextBox4.Text) > Convert.ToDecimal(TextBox2.Text))
                CalculatationEnterprise_Expansion();
            else
            {
                TextBox4.Text = (Convert.ToDecimal(TextBox3.Text.Trim()) * Convert.ToDecimal(ddlcurrencytype.SelectedValue)).ToString();

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
    public void CalculatationEnterprise_Expansion()
    {
        try
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
                TxtTot_PrjCostNewfinal = TxtTot_PrjCost.Text;
                TxtVal_Plantnewfinal = TxtVal_Plant.Text;
            }
            if (TxtTot_PrjCostNewfinal == "")
            {
                TxtTot_PrjCostNewfinal = "0";
            }
            if (TxtVal_Plantnewfinal == "")
            {
                TxtVal_Plantnewfinal = "0";
            }
            if (ddlSector_Ent.SelectedIndex != 0)
            {

                if (TxtProp_Emp.Text.Trim() == "")
                {
                    TxtProp_Emp.Text = "1";
                }

                lblmsg.Text = "";
                DataSet dsEnter = new DataSet();
                if (ddlSector_Ent.SelectedValue == "2")
                {
                    if (Convert.ToDecimal(txtlbltotalprojectcostexpanstion.Text) >= Convert.ToDecimal("20000"))
                    {
                        HdfLblEnt_is.Value = "Mega";

                        LblEnt_is.Text = "Mega";
                    }
                    else
                    {
                        //DataSet odsExp = new DataSet();
                        //odsExp = Gen.GetEnterPriseIs(txtlbltotalprojectcostexpanstion.Text, ddlSector_Ent.SelectedValue);
                        //if (odsExp.Tables[0].Rows.Count > 0)
                        //{
                        //    HdfLblEnt_is.Value = odsExp.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
                        //    LblEnt_is.Text = odsExp.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
                        //}
                        //else
                        //{
                        //    HdfLblEnt_is.Value = "";
                        //    LblEnt_is.Text = "";
                        //}
                        try
                        {
                            osqlConnection.Open();
                            SqlDataAdapter myDataAdapter;
                            myDataAdapter = new SqlDataAdapter("GetEnterPriseIs_Turnover", osqlConnection);
                            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                            oDataSet = new DataSet();
                            if (TxtTot_PrjCostNewfinal.Trim() != "" || TxtTot_PrjCostNewfinal.Trim() != null || TxtTot_PrjCostNewfinal.Trim() != "--Select--")
                            {
                                myDataAdapter.SelectCommand.Parameters.Add("@EnterpriseCost", SqlDbType.VarChar).Value = txtlbltotalprojectcostexpanstion.Text.ToString();
                                myDataAdapter.SelectCommand.Parameters.Add("@EnterpriseTurnover", SqlDbType.VarChar).Value = TextBox4.Text.ToString();
                                myDataAdapter.SelectCommand.Parameters.Add("@EnterPriseType", SqlDbType.VarChar).Value = ddlSector_Ent.SelectedValue.ToString();
                                myDataAdapter.Fill(oDataSet);

                                //LblEnt_is.Text=
                                if (oDataSet.Tables[0].Rows.Count > 0)
                                {
                                    HdfLblEnt_is.Value = oDataSet.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
                                    LblEnt_is.Text = oDataSet.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
                                }
                                else
                                {
                                    HdfLblEnt_is.Value = "";
                                    LblEnt_is.Text = "";
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            osqlConnection.Close();
                            throw ex;

                        }
                        finally
                        {
                            osqlConnection.Close();
                        }
                    }
                }
                else if (ddlSector_Ent.SelectedValue == "1")
                {
                    if (Convert.ToDecimal(txtlbltotalprojectcostexpanstion.Text) >= Convert.ToDecimal("20000"))
                    {
                        HdfLblEnt_is.Value = "Mega";

                        LblEnt_is.Text = "Mega";
                    }

                    else
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "alert('" + txtturnOver_read.Text + "');", true);
                        if (TextBox4.Text == "0" || TextBox4.Text == "")
                        {
                            //DataSet odsEnter1 = new DataSet();
                            //odsEnter1 = Gen.GetEnterPriseIs(txtlbltotalprojectcostexpanstion.Text, ddlSector_Ent.SelectedValue);
                            //if (odsEnter1.Tables[0].Rows.Count > 0)
                            //{
                            //    HdfLblEnt_is.Value = odsEnter1.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
                            //    LblEnt_is.Text = odsEnter1.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
                            //}

                            //else
                            //{
                            //    HdfLblEnt_is.Value = "";
                            //    LblEnt_is.Text = "";
                            //}
                            try
                            {
                                osqlConnection.Open();
                                SqlDataAdapter myDataAdapter;
                                myDataAdapter = new SqlDataAdapter("GetEnterPriseIs_Turnover", osqlConnection);
                                myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                                oDataSet = new DataSet();
                                if (TxtTot_PrjCostNewfinal.Trim() != "" || TxtTot_PrjCostNewfinal.Trim() != null || TxtTot_PrjCostNewfinal.Trim() != "--Select--")
                                {
                                    myDataAdapter.SelectCommand.Parameters.Add("@EnterpriseCost", SqlDbType.VarChar).Value = txtlbltotalprojectcostexpanstion.Text.ToString();
                                    myDataAdapter.SelectCommand.Parameters.Add("@EnterpriseTurnover", SqlDbType.VarChar).Value = TextBox4.Text.ToString();
                                    myDataAdapter.SelectCommand.Parameters.Add("@EnterPriseType", SqlDbType.VarChar).Value = ddlSector_Ent.SelectedValue.ToString();
                                    myDataAdapter.Fill(oDataSet);

                                    //LblEnt_is.Text=
                                    if (oDataSet.Tables[0].Rows.Count > 0)
                                    {
                                        HdfLblEnt_is.Value = oDataSet.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
                                        LblEnt_is.Text = oDataSet.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
                                    }
                                    else
                                    {
                                        HdfLblEnt_is.Value = "";
                                        LblEnt_is.Text = "";
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                osqlConnection.Close();
                                throw ex;

                            }
                            finally
                            {
                                osqlConnection.Close();
                            }
                        }
                        else if (TextBox4.Text != "0")
                        {
                            try
                            {
                                osqlConnection.Open();
                                SqlDataAdapter myDataAdapter;
                                myDataAdapter = new SqlDataAdapter("GetEnterPriseIs_Turnover", osqlConnection);
                                myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                                oDataSet = new DataSet();
                                if (TxtTot_PrjCostNewfinal.Trim() != "" || TxtTot_PrjCostNewfinal.Trim() != null || TxtTot_PrjCostNewfinal.Trim() != "--Select--")
                                {
                                    myDataAdapter.SelectCommand.Parameters.Add("@EnterpriseCost", SqlDbType.VarChar).Value = txtlbltotalprojectcostexpanstion.Text.ToString();
                                    myDataAdapter.SelectCommand.Parameters.Add("@EnterpriseTurnover", SqlDbType.VarChar).Value = TextBox4.Text.ToString();
                                    myDataAdapter.SelectCommand.Parameters.Add("@EnterPriseType", SqlDbType.VarChar).Value = ddlSector_Ent.SelectedValue.ToString();
                                    myDataAdapter.Fill(oDataSet);

                                    //LblEnt_is.Text=
                                    if (oDataSet.Tables[0].Rows.Count > 0)
                                    {
                                        HdfLblEnt_is.Value = oDataSet.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
                                        LblEnt_is.Text = oDataSet.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
                                    }
                                    else
                                    {
                                        HdfLblEnt_is.Value = "";
                                        LblEnt_is.Text = "";
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                osqlConnection.Close();
                                throw ex;

                            }
                            finally
                            {
                                osqlConnection.Close();
                            }
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
                Failure.Visible = true;
                lblmsg0.Text = "Please Select Sector of Enterprise";
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

    protected void RdDo_Store_Kerosine_TextChanged(object sender, EventArgs e)
    {

    }
    protected void RdDo_Store_Kerosine0_TextChanged(object sender, EventArgs e)
    {

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
            com.CommandText = "USP_INS_CFELabourShopService_Detailss";
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

    protected void RdbExecptedactShop_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (RdbExecptedactShop.SelectedValue == "Y")
            {
                tr3.Visible = true;
                tract2dateofcommencement.Visible = true;
                //  txtContractLabourAct.Visible = true;
            }
            else
            {
                tr3.Visible = false;
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

    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (trPlant.Visible == true)
        {
            trvolcapacity.Visible = true;
            lblaggregate.Text = "Aggregate Generators/Generating Capacity(AGC) (in KVA)";

        }
        else
        {
            trvolcapacity.Visible = true;
            lblaggregate.Text = "Aggregate Transformer Capacity(ATC) (in KVA)";
        }
        trvolcapacity.Visible = true;
    }
    protected void TxtnameofUnit_TextChanged(object sender, EventArgs e)
    {
        if ((TxtnameofUnit.Text.Contains("poultry") || TxtnameofUnit.Text.Contains("POULTRY") || TxtnameofUnit.Text.Contains("Poultr")) && Session["uid"].ToString().Trim() != "369288")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Attention-Approvals for all types of Poultry Farms and Poultry Feed units will not be processed under TS-iPASS. f applied with other line of activity the application will be rejected by the concerned department and fee paid will not be refunded.');", true);
            ddlConst_of_unit.Enabled = false;
            rdIaLa_Lst.Enabled = false;
            ddlProp_intDistrictid.Enabled = false;
            ddllandmesurements.Enabled = false;
            ddlIndustrialParkName.Enabled = false;
            ddlProp_intMandalid.Enabled = false;
            TxtTot_ExtentNew.Enabled = false;
            txtgunthas.Enabled = false;
            ddlProp_intVillageid.Enabled = false;
            TxtTot_Extent.Enabled = false;
            txttsiixplotno.Enabled = false;
            ddlLoc_of_unit.Enabled = false;
            TxtBuilt_up_Area.Enabled = false;
            ddlAppl_Type.Enabled = false;
            ddlintLineofActivity.Enabled = false;
            ddlSector_Ent.Enabled = false;
            btntab1next.Enabled = false;
        }
        else
        {
            ddlConst_of_unit.Enabled = true;
            rdIaLa_Lst.Enabled = true;
            ddlProp_intDistrictid.Enabled = true;
            ddllandmesurements.Enabled = true;
            ddlIndustrialParkName.Enabled = true;
            ddlProp_intMandalid.Enabled = true;
            TxtTot_ExtentNew.Enabled = true;
            txtgunthas.Enabled = true;
            ddlProp_intVillageid.Enabled = true;
            TxtTot_Extent.Enabled = true;
            txttsiixplotno.Enabled = true;
            ddlLoc_of_unit.Enabled = true;
            TxtBuilt_up_Area.Enabled = true;
            ddlAppl_Type.Enabled = true;
            ddlintLineofActivity.Enabled = true;
            ddlSector_Ent.Enabled = true;
            btntab1next.Enabled = true;
        }
    }

    public DataSet checkcfealreadyexists(string DISTRICT, string MANDAL, string VILLAGE, string NAMEOFUNIT, string createdby, string Proposalfor)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_CHECK_CFE_APPLIED", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (DISTRICT.Trim() == "" || DISTRICT.Trim() == null)
                da.SelectCommand.Parameters.Add("@DISTRICT", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@DISTRICT", SqlDbType.VarChar).Value = DISTRICT.ToString();

            if (MANDAL.Trim() == "" || MANDAL.Trim() == null)
                da.SelectCommand.Parameters.Add("@MANDAL", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@MANDAL", SqlDbType.VarChar).Value = MANDAL.ToString();

            if (VILLAGE.Trim() == "" || VILLAGE.Trim() == null)
                da.SelectCommand.Parameters.Add("@VILLAGE", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@VILLAGE", SqlDbType.VarChar).Value = VILLAGE.ToString();

            if (NAMEOFUNIT.Trim() == "" || NAMEOFUNIT.Trim() == null)
                da.SelectCommand.Parameters.Add("@NAMEOFUNIT", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@NAMEOFUNIT", SqlDbType.VarChar).Value = NAMEOFUNIT.ToString();

            if (Proposalfor.Trim() == "" || Proposalfor.Trim() == null)
                da.SelectCommand.Parameters.Add("@Proposalfor", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@Proposalfor", SqlDbType.VarChar).Value = Proposalfor.ToString();

            if (createdby.Trim() == "" || createdby.Trim() == null)
                da.SelectCommand.Parameters.Add("@createdby", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@createdby", SqlDbType.VarChar).Value = createdby.ToString();

            da.Fill(ds);
            return ds;


        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {

        }

    }
    public DataSet CHECKEXPANSIONUSERWITHZERINVESTMENT_EXIST(string USERID)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_GET_expansion_users_zero_investment", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (USERID.Trim() == "" || USERID.Trim() == null)
                da.SelectCommand.Parameters.Add("@USERID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@USERID", SqlDbType.VarChar).Value = USERID.ToString();


            da.Fill(ds);
            return ds;


        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {

        }

    }
}
