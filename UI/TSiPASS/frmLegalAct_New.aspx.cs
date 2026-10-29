using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UI_TSiPASS_frmLegalAct_New : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    comFunctions cmf = new comFunctions();
    General Gen = new General();

    List<LegalBrand> lstBrand = new List<LegalBrand>();
    List<LegalCommodity> lstCommodityVo = new List<LegalCommodity>();
    List<LegalDirectors> lstDirectorsVo = new List<LegalDirectors>();

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            string Registration_cd = "";
            if (Session.Count <= 0)
            {
                Response.Redirect("~/Index.aspx");
            }
            if (!IsPostBack)
            {

                //DataSet dscheck = new DataSet();
                //dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
                DataSet dscheck = new DataSet();
                dscheck = Gen.GetShowQuestionariesCFO(Session["uid"].ToString().Trim());
                if (dscheck.Tables[0].Rows.Count > 0)
                {
                    Session["ApplidA"] = dscheck.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
                    if (dscheck.Tables[0].Rows[0]["LabelConfirmation"].ToString() != null && dscheck.Tables[0].Rows[0]["LabelConfirmation"].ToString() != "")
                    {
                        if (dscheck.Tables[0].Rows[0]["LabelConfirmation"].ToString() != "Y")
                        {
                            if (Request.QueryString[1].ToString() == "N")
                            {
                                //Response.Redirect("frmAttachmentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N"); //lavanya new 
                                Response.Redirect("frmBoilerInspectUpload.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
                               // Response.Redirect("frmDrugInfo.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
                            }
                            else
                            {
                                // Response.Redirect("frmLabourCFO.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "P"); //lavanya new 
                                Response.Redirect("frmLabourCFO.aspx?intApplicationId=" + Session["uid"].ToString() + "&Previous=" + "P");
                            }

                        }
                    }
                    else
                    {
                        if (Request.QueryString[1].ToString() == "N")
                        {
                            // Response.Redirect("frmAttachmentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N"); //lavanya new   
                            Response.Redirect("frmBoilerInspectUpload.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
                        }
                        else
                        {
                            Response.Redirect("frmLabourCFO.aspx?intApplicationId=" + Session["uid"].ToString() + "&Previous=" + "P");
                        }

                    }

                    if (dscheck.Tables[0].Rows[0]["LabourAct_Id"].ToString() != null && dscheck.Tables[0].Rows[0]["LabourAct_Id"].ToString() != "")
                    {
                        ViewState["Registration_cd"] = dscheck.Tables[0].Rows[0]["LabourAct_Id"].ToString();
                        Registration_cd = ViewState["Registration_cd"].ToString();
                    }
                    if (dscheck.Tables.Count > 3 && dscheck.Tables[3].Rows.Count > 0)
                    {

                    }
                }
                else
                {
                    Session["ApplidA"] = "0";
                }

                DataSet dsver = new DataSet();

                dsver = Gen.GetverifyofqueBoiler9CFO(Session["ApplidA"].ToString());

                if (dsver.Tables[0].Rows.Count > 0)
                {
                    string res = Gen.RetriveStatusCFO(Session["ApplidA"].ToString());
                    ////string res = Gen.RetriveStatus("1002");


                    if (res == "3" || Convert.ToInt32(res) >= 3)
                    {
                        ResetFormControl(this);
                    }

                }
            }
            if (!IsPostBack)
            {
                BindDistricts(ddlFirmDistrict);
                BindDistricts(ddlPremisesDistrict);

                BindLegalRegistrations();
                //BindDistricts(ddlManagerDistrictAct1);

                gvBrandDtls.DataSource = BindBrandNameGrid();
                gvBrandDtls.DataBind();

                gvDirector.DataSource = BindDirectorGrid();
                gvDirector.DataBind();

                gvCommodityDtls.DataSource = BindCommodityGrid();
                gvCommodityDtls.DataBind();
            }

            if (Request.QueryString["intApplicationId"] != null)
            {
                hdfFlagID0.Value = Request.QueryString["intApplicationId"];

                if (!IsPostBack)
                {
                    FillDetails();
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void BindLegalRegistrations()
    {
        try
        {
            DataSet dsd = new DataSet();
            lstRegistrationas.Items.Clear();
            dsd = Gen.GetLegalRegistrationMaster();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                lstRegistrationas.DataSource = dsd.Tables[0];
                lstRegistrationas.DataValueField = "LEGALREG_ID";
                lstRegistrationas.DataTextField = "lEGAL_REGISTRATIONTYPE";
                lstRegistrationas.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }

    protected DataTable BindDirectorGridAdd()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Director_Name");
        dt.Columns.Add("Director_DoorNo");
        dt.Columns.Add("Director_Districtcd");
        dt.Columns.Add("Director_MandalCd");
        dt.Columns.Add("Director_VillageCd");
        dt.Columns.Add("Director_Pincode");
        dt.Columns.Add("Director_AadharNo");
        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";
        dr[2] = "";
        dr[3] = "";
        dr[4] = "";
        dr[5] = "";
        dr[6] = "";

        dt.Rows.Add(dr);
        return dt;
    }
    protected DataTable BindBrandNameGridAdd()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("BrandName");

        DataRow dr = dt.NewRow();
        dr[0] = "";


        dt.Rows.Add(dr);
        return dt;
    }
    protected DataTable BindCommodityGridAdd()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Commodity_Name");
        dt.Columns.Add("Quantity");

        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";

        dt.Rows.Add(dr);
        return dt;
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
    protected DataTable BindDirectorGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("");

        DataRow dr = dt.NewRow();
        dr[0] = "";

        dt.Rows.Add(dr);

        return dt;
    }
    protected DataTable BindBrandNameGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("BrandName");

        DataRow dr = dt.NewRow();
        dr[0] = "";

        dt.Rows.Add(dr);

        return dt;
    }
    protected DataTable BindCommodityGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Commodity_Name");

        DataRow dr = dt.NewRow();
        dr[0] = "";

        dt.Rows.Add(dr);

        return dt;
    }
    public void BindMandals(DropDownList ddlDistrict, DropDownList ddlMandal)
    {

        ddlMandal.Items.Clear();
        DataSet dsm = new DataSet();
        dsm = Gen.GetMandals(ddlDistrict.SelectedValue);
        if (dsm.Tables[0].Rows.Count > 0)
        {
            ddlMandal.DataSource = dsm.Tables[0];
            ddlMandal.DataValueField = "Mandal_Id";
            ddlMandal.DataTextField = "Manda_lName";
            ddlMandal.DataBind();
            ddlMandal.Items.Insert(0, "--Mandal--");
        }
        else
        {
            ddlMandal.Items.Clear();
            ddlMandal.Items.Insert(0, "--Mandal--");
        }

    }
    public void BindDistricts(DropDownList ddlDistrict)
    {
        try
        {
            //DataSet dsd = new DataSet();
            //ddlDistrict.Items.Clear();
            //dsd = Gen.GetDistrictsWithoutHYD();
            Cls_MasterofTsipass obj_newdistrictwargnal = new Cls_MasterofTsipass();
            DataSet dsd = new DataSet();
            ddlDistrict.Items.Clear();
            dsd = obj_newdistrictwargnal.GetallDistrictswithoutWarangal(Convert.ToString(Session["uid"]), "CFO");
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlDistrict.DataSource = dsd.Tables[0];
                ddlDistrict.DataValueField = "District_Id";
                ddlDistrict.DataTextField = "District_Name";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, "--District--");
            }
            else
            {
                ddlDistrict.Items.Insert(0, "--District--");
            }
        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }
    void FillDetails()
    {

        hdfFlagID.Value = "1";
        DataSet ds = new DataSet();
        string Registration_cd = "";
        try
        {
            int QuestionnaireId = Convert.ToInt32(Session["ApplidA"].ToString());
            ds = Gen.getLegalDetails(hdfFlagID0.Value.ToString(), QuestionnaireId);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                Registration_cd = ds.Tables[0].Rows[0]["Registration_cd"].ToString();
                string[] values = Registration_cd.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    for (int j = 0; j < lstRegistrationas.Items.Count; j++)
                    {
                        if (lstRegistrationas.Items[j].Value == values[i].Trim())
                        {
                            lstRegistrationas.Items[j].Selected = true;
                        }
                    }
                }


                ddlFirmDistrict.SelectedValue = ds.Tables[0].Rows[0]["Firm_DistrictCd"].ToString();
                ddlFirmDistrict_SelectedIndexChanged(this, EventArgs.Empty);
                txtFirmDoorNo.Text = ds.Tables[0].Rows[0]["Firm_DoorNo"].ToString();
                txtEmailId0.Text = ds.Tables[0].Rows[0]["Firm_EmailId"].ToString();
                txtFirmLandLine0.Text = ds.Tables[0].Rows[0]["Firm_Landline"].ToString();

                ddlFirmMandal0.SelectedValue = ds.Tables[0].Rows[0]["Firm_MandalCd"].ToString();
                ddlFirmMandal_SelectedIndexChanged(this, EventArgs.Empty);
                txtFirmPincode.Text = ds.Tables[0].Rows[0]["Firm_Pincode"].ToString();
                ddlFirmVillage.SelectedValue = ds.Tables[0].Rows[0]["Firm_VillageCd"].ToString();
                txtLabelDetails.Text = ds.Tables[0].Rows[0]["Label_details"].ToString();

                ddlPremisesDistrict.SelectedValue = ds.Tables[0].Rows[0]["Premises_DistrictCd"].ToString();
                ddlPremisesDistrict_SelectedIndexChanged(this, EventArgs.Empty);
                txtPremisesDoorNo.Text = ds.Tables[0].Rows[0]["Premises_DoorNo"].ToString();
                txtPremisesLandLine0.Text = ds.Tables[0].Rows[0]["Premises_LandLineNo"].ToString();
                ddlPremisesMandal.SelectedValue = ds.Tables[0].Rows[0]["Premises_MandalCd"].ToString();
                ddlPremisesMandal_SelectedIndexChanged(this, EventArgs.Empty);
                txtPremisesName0.Text = ds.Tables[0].Rows[0]["Premises_Name"].ToString();
                txtPremisesPincode.Text = ds.Tables[0].Rows[0]["Premises_Pincode"].ToString();
                txtShortAddress.Text = ds.Tables[0].Rows[0]["Premises_ShortAddress"].ToString();
                txtTradeLicense0.Text = ds.Tables[0].Rows[0]["Premises_TradeLicense"].ToString();
                ddlPremisesVillage.SelectedValue = ds.Tables[0].Rows[0]["Premises_VillageCd"].ToString();
                txtDateofCommenceAct1.Text = ds.Tables[0].Rows[0]["DateofCommencement"].ToString();
                txtTinNo0.Text = ds.Tables[0].Rows[0]["Tin_Number"].ToString();


                if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    ViewState["dtDirectorDtls"] = ds.Tables[1];
                    gvDirector.DataSource = ds.Tables[1];
                    gvDirector.DataBind();
                }
                if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                {
                    ViewState["dtBrandDtls"] = ds.Tables[2];
                    gvBrandDtls.DataSource = ds.Tables[2];
                    gvBrandDtls.DataBind();
                }
                if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
                {
                    ViewState["dtCommodity"] = ds.Tables[3];

                    gvCommodityDtls.DataSource = ds.Tables[3];
                    gvCommodityDtls.DataBind();
                }


            }


        }

        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();

        }
        finally
        {
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

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {

            //labouractvo.
            int valid = 0;
            valid = SaveLegalDetails();
            lblmsg.Text = "<font color='green'>Legal Details Added Successfully..!</font>";
            success.Visible = true;
            Failure.Visible = false;
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
            success.Visible = false;
            Failure.Visible = true;
        }
    }
    private int SaveLegalDetails()
    {
        LegalClass legalvo = new LegalClass();
        legalvo.QuestionnaireId = Convert.ToInt32(Session["ApplidA"].ToString());
        legalvo.intCFEEnterpid = Convert.ToInt32(Request.QueryString[0].ToString());
        legalvo.CreatedBy = Convert.ToInt32(Session["uid"].ToString().Trim());
        legalvo.Created_by = Session["uid"].ToString();

        //legalvo.=
        if (ddlFirmDistrict.SelectedValue != "--District--")
            legalvo.Firm_DistrictCd = ddlFirmDistrict.SelectedValue;

        legalvo.Firm_DoorNo = txtFirmDoorNo.Text.Trim();
        legalvo.Firm_EmailId = txtEmailId0.Text.Trim();
        legalvo.Firm_Landline = txtFirmLandLine0.Text.Trim();
        if (ddlFirmMandal0.SelectedValue != "--Mandal--")
            legalvo.Firm_MandalCd = ddlFirmMandal0.SelectedValue;

        legalvo.Firm_Pincode = txtFirmPincode.Text.Trim();
        if (ddlFirmVillage.SelectedValue != "--Village--")
            legalvo.Firm_VillageCd = ddlFirmVillage.SelectedValue;
        legalvo.Label_details = txtLabelDetails.Text.Trim();
        if (ddlPremisesDistrict.SelectedValue != "--District--")
            legalvo.Premises_DistrictCd = ddlPremisesDistrict.SelectedValue;
        legalvo.Premises_DoorNo = txtPremisesDoorNo.Text.Trim();
        legalvo.Premises_LandLineNo = txtPremisesLandLine0.Text.Trim();
        if (ddlPremisesMandal.SelectedValue != "--Mandal--")
            legalvo.Premises_MandalCd = ddlPremisesMandal.SelectedValue;
        legalvo.Premises_Name = txtPremisesName0.Text.Trim();
        legalvo.Premises_Pincode = txtPremisesPincode.Text.Trim();
        legalvo.Premises_ShortAddress = txtShortAddress.Text.Trim();
        legalvo.Premises_TradeLicense = txtTradeLicense0.Text.Trim();
        if (ddlPremisesVillage.SelectedValue != "--Village--")
            legalvo.Premises_VillageCd = ddlPremisesVillage.SelectedValue;
        legalvo.DateofCommencement = txtDateofCommenceAct1.Text.Trim();

        //  legalvo.Reg_Id
        string Registration_cd = "";
        for (int i = 0; i < lstRegistrationas.Items.Count; i++)
        {
            if (lstRegistrationas.Items[i].Selected == true)
            {
                if (Registration_cd == "")
                    Registration_cd = lstRegistrationas.Items[i].Value;
                else
                    Registration_cd += "," + lstRegistrationas.Items[i].Value;
            }
        }

        legalvo.Registration_cd = Registration_cd;
        legalvo.Tin_Number = txtTinNo0.Text.Trim();
        // legalvo.
        foreach (GridViewRow gvrow in gvBrandDtls.Rows)
        {
            LegalBrand brandVo = new LegalBrand();
            TextBox txtBrandName = (TextBox)gvrow.FindControl("txtBrandName");
            brandVo.BrandName = txtBrandName.Text;
            lstBrand.Add(brandVo);
        }
        foreach (GridViewRow gvrow in gvCommodityDtls.Rows)
        {
            LegalCommodity commodityVo = new LegalCommodity();
            TextBox txtCommodityName = (TextBox)gvrow.FindControl("txtCommodityName");
            TextBox txtCommodityQuantity = (TextBox)gvrow.FindControl("txtCommodityQuantity");
            if (txtCommodityName.Text != "" && txtCommodityName.Text != null)
            {
                commodityVo.Commodity_Name = txtCommodityName.Text;
                if (txtCommodityQuantity.Text.Trim() == "")
                    txtCommodityQuantity.Text = "0";
                commodityVo.Quantity = txtCommodityQuantity.Text;
                lstCommodityVo.Add(commodityVo);
            }
        }
        foreach (GridViewRow gvr in gvDirector.Rows)
        {
            LegalDirectors directorVo = new LegalDirectors();
            TextBox txtDirectorName = (TextBox)gvr.FindControl("txtDirectorName");

            TextBox txtDirectorDoorNo = (TextBox)gvr.FindControl("txtDirectorDoorNo");
            DropDownList ddlDirectorDistrict = (DropDownList)gvr.FindControl("ddlDirectorDistrict");

            DropDownList ddlDirectorMandal = (DropDownList)gvr.FindControl("ddlDirectorMandal");

            DropDownList ddlDirectorVillage = (DropDownList)gvr.FindControl("ddlDirectorVillage");

            TextBox txtDirectorPincode = (TextBox)gvr.FindControl("txtDirectorPincode");

            TextBox txtAadhar1 = (TextBox)gvr.FindControl("txtadhar1");
            TextBox txtAadhar2 = (TextBox)gvr.FindControl("txtadhar2");
            TextBox txtAadhar3 = (TextBox)gvr.FindControl("txtadhar3");
            string Aadharno = txtAadhar1.Text.Trim() + txtAadhar2.Text.Trim() + txtAadhar3.Text.Trim();
            if (txtDirectorName.Text != "" && txtDirectorName.Text != null)
            {
                directorVo.Director_Name = txtDirectorName.Text;
                directorVo.Director_DoorNo = txtDirectorDoorNo.Text;
                directorVo.Director_Districtcd = ddlDirectorDistrict.SelectedValue;
                directorVo.Director_MandalCd = ddlDirectorMandal.SelectedValue;
                directorVo.Director_VillageCd = ddlDirectorVillage.SelectedValue;
                directorVo.Director_Pincode = txtDirectorPincode.Text;
                directorVo.Director_AadharNo = Aadharno;
                lstDirectorsVo.Add(directorVo);
            }
        }

        int valid = Gen.InsertLegalDetails(legalvo, lstBrand, lstCommodityVo, lstDirectorsVo);
        return valid;
    }
    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        //Response.Redirect("frmAttachmentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N"); //lavanya new 
        SaveLegalDetails();
        Response.Redirect("frmBoilerInspectUpload.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
    }
    protected void BtnDelete0_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmLabourCFO.aspx?intApplicationId=" + Session["uid"].ToString() + "&Previous=" + "P");

    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmLegalAct_New.aspx?intApplicationId=" + Session["uid"].ToString() + "&Previous=" + "P");

    }
    protected void ddlFirmDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindMandals(ddlFirmDistrict, ddlFirmMandal0);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void ddlFirmMandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindVillages(ddlFirmMandal0, ddlFirmVillage);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    public void BindVillages(DropDownList ddlMandal, DropDownList ddlVillages)
    {
        if (ddlMandal.SelectedIndex == 0)
        {
            ddlVillages.Items.Clear();
            ddlVillages.Items.Insert(0, "--Village--");
        }
        else
        {
            ddlVillages.Items.Clear();
            DataSet dsv = new DataSet();
            dsv = Gen.GetVillages(ddlMandal.SelectedValue);
            if (dsv.Tables[0].Rows.Count > 0)
            {
                ddlVillages.DataSource = dsv.Tables[0];
                ddlVillages.DataValueField = "Village_Id";
                ddlVillages.DataTextField = "Village_Name";
                ddlVillages.DataBind();
                ddlVillages.Items.Insert(0, "--Village--");
            }
            else
            {
                ddlVillages.Items.Clear();
                ddlVillages.Items.Insert(0, "--Village--");
            }
        }

    }
    protected void ddlPremisesDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindMandals(ddlPremisesDistrict, ddlPremisesMandal);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void ddlPremisesMandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindVillages(ddlPremisesMandal, ddlPremisesVillage);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void gvCommodityDtls_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindCommodityGridAdd();
                String[] arraydata = new String[2];

                int gvrcnt = gvCommodityDtls.Rows.Count;
                decimal extent = 0;
                for (int i = 0; i < gvrcnt; i++)
                {

                    GridViewRow gvr = gvCommodityDtls.Rows[i];
                    TextBox txtCommodityName = (TextBox)gvr.FindControl("txtCommodityName");
                    arraydata[0] = txtCommodityName.Text;

                    TextBox txtCommodityQuantity = (TextBox)gvr.FindControl("txtCommodityQuantity");
                    arraydata[1] = txtCommodityQuantity.Text;
                    if (txtCommodityName.Text == "")// || txtEnjExtent.Value == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please enter Commodity Name";
                        lblmsg.CssClass = "errormsg";
                    }
                    dt.Rows[i].ItemArray = arraydata;
                    DataRow dRow;
                    dRow = null;
                    dRow = dt.NewRow();
                    dt.Rows.Add(dRow);
                }


                if (valid == 0)
                {
                    ViewState["dtCommodity"] = dt;
                    gvCommodityDtls.DataSource = dt;
                    gvCommodityDtls.DataBind();
                }
                //SetFocus(gvEnjoyer);
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvCommodityDtls.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindCommodityGridAdd();
                    String[] arraydata = new String[2];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {

                        if (i != j)
                        {
                            GridViewRow gvr = gvCommodityDtls.Rows[i];
                            TextBox txtCommodityName = (TextBox)gvr.FindControl("txtCommodityName");
                            arraydata[0] = txtCommodityName.Text;

                            TextBox txtCommodityQuantity = (TextBox)gvr.FindControl("txtCommodityQuantity");
                            arraydata[1] = txtCommodityQuantity.Text;
                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["dtCommodity"] = dt;
                    gvCommodityDtls.DataSource = dt;
                    gvCommodityDtls.DataBind();
                }
                else
                {
                    lblmsg.Text = "Cannot remove the details, Please modify";
                    lblmsg.CssClass = "errormsg";
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void gvCommodityDtls_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataTable dt = (DataTable)ViewState["dtCommodity"];

            if (dt != null)
            {
                if (e.Row.RowIndex < dt.Rows.Count)
                {
                    GridViewRow gvr = e.Row;
                    TextBox txtCommodityName = (TextBox)gvr.FindControl("txtCommodityName");
                    txtCommodityName.Text = dt.Rows[e.Row.RowIndex]["Commodity_Name"].ToString();

                    TextBox txtCommodityQuantity = (TextBox)gvr.FindControl("txtCommodityQuantity");
                    txtCommodityQuantity.Text = dt.Rows[e.Row.RowIndex]["Quantity"].ToString();
                }
            }
        }
    }
    protected void gvBrandDtls_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindBrandNameGridAdd();
                String[] arraydata = new String[1];

                int gvrcnt = gvBrandDtls.Rows.Count;
                decimal extent = 0;
                for (int i = 0; i < gvrcnt; i++)
                {

                    GridViewRow gvr = gvBrandDtls.Rows[i];
                    TextBox txtBrandName = (TextBox)gvr.FindControl("txtBrandName");
                    arraydata[0] = txtBrandName.Text;
                    if (txtBrandName.Text == "")// || txtEnjExtent.Value == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please enter Brand Name";
                        lblmsg.CssClass = "errormsg";
                    }
                    dt.Rows[i].ItemArray = arraydata;
                    DataRow dRow;
                    dRow = null;
                    dRow = dt.NewRow();
                    dt.Rows.Add(dRow);
                }


                if (valid == 0)
                {
                    ViewState["dtBrandDtls"] = dt;
                    gvBrandDtls.DataSource = dt;
                    gvBrandDtls.DataBind();
                }
                //SetFocus(gvEnjoyer);
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvBrandDtls.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindBrandNameGridAdd();
                    String[] arraydata = new String[1];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {
                        if (i != j)
                        {
                            GridViewRow gvr = gvBrandDtls.Rows[i];
                            TextBox txtBrandName = (TextBox)gvr.FindControl("txtBrandName");
                            arraydata[0] = txtBrandName.Text;
                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["dtBrandDtls"] = dt;
                    gvBrandDtls.DataSource = dt;
                    gvBrandDtls.DataBind();
                }
                else
                {
                    lblmsg.Text = "Cannot remove the details, Please modify";
                    lblmsg.CssClass = "errormsg";
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void gvBrandDtls_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)ViewState["dtBrandDtls"];

                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        GridViewRow gvr = e.Row;
                        TextBox txtBrandName = (TextBox)gvr.FindControl("txtBrandName");
                        txtBrandName.Text = dt.Rows[e.Row.RowIndex]["BrandName"].ToString();
                    }
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }

    }
    protected void gvDirector_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindDirectorGridAdd();
                String[] arraydata = new String[7];

                int gvrcnt = gvDirector.Rows.Count;
                decimal extent = 0;
                for (int i = 0; i < gvrcnt; i++)
                {

                    GridViewRow gvr = gvDirector.Rows[i];
                    TextBox txtDirectorName = (TextBox)gvr.FindControl("txtDirectorName");
                    arraydata[0] = txtDirectorName.Text;

                    TextBox txtDirectorDoorNo = (TextBox)gvr.FindControl("txtDirectorDoorNo");
                    arraydata[1] = txtDirectorDoorNo.Text;

                    DropDownList ddlDirectorDistrict = (DropDownList)gvr.FindControl("ddlDirectorDistrict");
                    arraydata[2] = ddlDirectorDistrict.SelectedValue;

                    DropDownList ddlDirectorMandal = (DropDownList)gvr.FindControl("ddlDirectorMandal");
                    arraydata[3] = ddlDirectorMandal.SelectedValue;

                    DropDownList ddlDirectorVillage = (DropDownList)gvr.FindControl("ddlDirectorVillage");
                    arraydata[4] = ddlDirectorVillage.SelectedValue;

                    TextBox txtDirectorPincode = (TextBox)gvr.FindControl("txtDirectorPincode");
                    arraydata[5] = txtDirectorPincode.Text;

                    TextBox txtAadhar1 = (TextBox)gvr.FindControl("txtadhar1");
                    TextBox txtAadhar2 = (TextBox)gvr.FindControl("txtadhar2");
                    TextBox txtAadhar3 = (TextBox)gvr.FindControl("txtadhar3");
                    string Aadahrno = txtAadhar1.Text + txtAadhar2.Text + txtAadhar3.Text;
                    arraydata[6] = Aadahrno;

                    if (txtDirectorName.Text == "")// || txtEnjExtent.Value == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please enter Director Name";
                        lblmsg.CssClass = "errormsg";
                    }
                    dt.Rows[i].ItemArray = arraydata;
                    DataRow dRow;
                    dRow = null;
                    dRow = dt.NewRow();
                    dt.Rows.Add(dRow);
                }

                if (valid == 0)
                {
                    ViewState["dtDirectorDtls"] = dt;
                    gvDirector.DataSource = dt;
                    gvDirector.DataBind();
                }
                //SetFocus(gvEnjoyer);
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvDirector.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindDirectorGridAdd();
                    String[] arraydata = new String[7];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {
                        if (i != j)
                        {
                            GridViewRow gvr = gvDirector.Rows[i];
                            TextBox txtDirectorName = (TextBox)gvr.FindControl("txtDirectorName");
                            arraydata[0] = txtDirectorName.Text;

                            TextBox txtDirectorDoorNo = (TextBox)gvr.FindControl("txtDirectorDoorNo");
                            arraydata[1] = txtDirectorDoorNo.Text;

                            DropDownList ddlDirectorDistrict = (DropDownList)gvr.FindControl("ddlDirectorDistrict");
                            arraydata[2] = ddlDirectorDistrict.SelectedValue;

                            DropDownList ddlDirectorMandal = (DropDownList)gvr.FindControl("ddlDirectorMandal");
                            arraydata[3] = ddlDirectorMandal.Text;

                            DropDownList ddlDirectorVillage = (DropDownList)gvr.FindControl("ddlDirectorVillage");
                            arraydata[4] = ddlDirectorVillage.SelectedValue;

                            TextBox txtDirectorPincode = (TextBox)gvr.FindControl("txtDirectorPincode");
                            arraydata[5] = txtDirectorPincode.Text;

                            TextBox txtAadhar1 = (TextBox)gvr.FindControl("txtadhar1");
                            TextBox txtAadhar2 = (TextBox)gvr.FindControl("txtadhar2");
                            TextBox txtAadhar3 = (TextBox)gvr.FindControl("txtadhar3");
                            string Aadahrno = txtAadhar1.Text + txtAadhar2.Text + txtAadhar3.Text;
                            arraydata[6] = Aadahrno;

                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["dtDirectorDtls"] = dt;
                    gvDirector.DataSource = dt;
                    gvDirector.DataBind();
                }
                else
                {
                    lblmsg.Text = "Cannot remove the details, Please modify";
                    lblmsg.CssClass = "errormsg";
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void gvDirector_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gvr = e.Row;

                DataTable dt = (DataTable)ViewState["dtDirectorDtls"];
                DropDownList ddlDirectorDistrict = (DropDownList)gvr.FindControl("ddlDirectorDistrict");
                BindDistricts(ddlDirectorDistrict);

                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        TextBox txtDirectorName = (TextBox)gvr.FindControl("txtDirectorName");
                        txtDirectorName.Text = dt.Rows[e.Row.RowIndex]["Director_Name"].ToString();

                        TextBox txtDirectorDoorNo = (TextBox)gvr.FindControl("txtDirectorDoorNo");
                        txtDirectorDoorNo.Text = dt.Rows[e.Row.RowIndex]["Director_DoorNo"].ToString();

                        ddlDirectorDistrict.SelectedValue = dt.Rows[e.Row.RowIndex]["Director_Districtcd"].ToString();
                        //ddlDirectorDistrict_SelectedIndexChanged(sender, e);
                        DropDownList ddlDirectorMandal = (DropDownList)gvr.FindControl("ddlDirectorMandal");
                        BindMandals(ddlDirectorDistrict, ddlDirectorMandal);

                        ddlDirectorMandal.SelectedValue = dt.Rows[e.Row.RowIndex]["Director_MandalCd"].ToString();
                        //ddlDirectorMandal_SelectedIndexChanged(sender, e);
                        DropDownList ddlDirectorVillage = (DropDownList)gvr.FindControl("ddlDirectorVillage");
                        BindVillages(ddlDirectorMandal, ddlDirectorVillage);
                        ddlDirectorVillage.SelectedValue = dt.Rows[e.Row.RowIndex]["Director_VillageCd"].ToString();

                        TextBox txtDirectorPincode = (TextBox)gvr.FindControl("txtDirectorPincode");
                        txtDirectorPincode.Text = dt.Rows[e.Row.RowIndex]["Director_Pincode"].ToString();

                        TextBox txtAadhar1 = (TextBox)gvr.FindControl("txtadhar1");
                        TextBox txtAadhar2 = (TextBox)gvr.FindControl("txtadhar2");
                        TextBox txtAadhar3 = (TextBox)gvr.FindControl("txtadhar3");
                        string Aadahrno = "";
                        Aadahrno = dt.Rows[e.Row.RowIndex]["Director_AadharNo"].ToString();
                        if (Aadahrno.Length == 12)
                        {
                            txtAadhar1.Text = Aadahrno.Substring(0, 4);
                            txtAadhar2.Text = Aadahrno.Substring(4, 4);
                            txtAadhar3.Text = Aadahrno.Substring(8, 4);
                            // ScriptManager.RegisterStartupScript(Page, this.GetType(), "aadhar", "validateVerhoeff();", true);
                        }
                    }
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void ddlDirectorDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow gvrow = (GridViewRow)((DropDownList)sender).Parent.Parent;
            DropDownList ddlDirectorDistrict = (DropDownList)gvrow.FindControl("ddlDirectorDistrict");
            DropDownList ddlDirectorMandal = (DropDownList)gvrow.FindControl("ddlDirectorMandal");
            BindMandals(ddlDirectorDistrict, ddlDirectorMandal);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void ddlDirectorMandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow gvrow = (GridViewRow)((DropDownList)sender).Parent.Parent;
            DropDownList ddlDirectorDistrict = (DropDownList)gvrow.FindControl("ddlDirectorDistrict");
            DropDownList ddlDirectorMandal = (DropDownList)gvrow.FindControl("ddlDirectorMandal");
            DropDownList ddlDirectorVillage = (DropDownList)gvrow.FindControl("ddlDirectorVillage");

            BindVillages(ddlDirectorMandal, ddlDirectorVillage);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
}