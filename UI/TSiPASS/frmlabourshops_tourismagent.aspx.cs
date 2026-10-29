using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

public partial class UI_TSiPASS_frmlabourshops_tourismagent : System.Web.UI.Page
{

    DataTable dt = new DataTable();
    DropDownList ddlWorkPlace;

    Cls_usertravelagent Gen = new Cls_usertravelagent();

    List<LabourWorkPlace> lstworkplaceVo = new List<LabourWorkPlace>();
    List<FamilyMembersAct1> lstfamilyMembersActVo = new List<FamilyMembersAct1>();
    List<EmployeesDetails> lstemployeeDetailsVo = new List<EmployeesDetails>();
    List<ContractorDetails> lstContractorVoAct3 = new List<ContractorDetails>();
    List<ContractorDetails> lstContractorVoAct4 = new List<ContractorDetails>();

    int totalContractEmployees;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string LabourActid = "";
            if (Session.Count <= 0)
            {
                Response.Redirect("~/Index.aspx");
            }
            if (!IsPostBack)
            {
                DataSet dscheck = new DataSet();
                dscheck = Gen.Tourismagentshops_GetShowQuestionaries(Session["uid"].ToString().Trim());
                if (dscheck.Tables[0].Rows.Count > 0)
                {
                    Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();

                    if (dscheck.Tables.Count > 3 && dscheck.Tables[3].Rows.Count > 0)
                    {
                        txtShopDoorNo.Text = dscheck.Tables[3].Rows[0]["door_no"].ToString();
                        txtShopPincode.Text = dscheck.Tables[3].Rows[0]["pincode"].ToString();
                    }
                }
                else
                {
                    Session["Applid"] = "0";
                }

                DataSet dsver = new DataSet();
                Session["ApplidA"] = Convert.ToString(Session["Applid"]);
                dsver = Gen.Tourismaegntshops_getdatavarifyqueCFO(Session["ApplidA"].ToString());

                if (dsver.Tables[0].Rows.Count > 0)
                {
                    string res = Gen.Tourismagentshops_RetriveStatusCFO(Session["ApplidA"].ToString());

                    string tr = Convert.ToString(Request.QueryString["Query"]);

                    if (Request.QueryString["Query"] != null && Request.QueryString["Query"] == "Y")
                    {
                        trsubmitqury.Visible = true;
                        trsubmitactual.Visible = false;
                        txtDateofCommenceAct1.Enabled = false;
                        txtEstDateCompAct2.Enabled = false;
                        txtTotalEmployees.Enabled = false;
                    }
                    else
                    {
                        trsubmitqury.Visible = false;
                        trsubmitactual.Visible = true;
                        DataSet dsver1 = new DataSet();
                        dsver1 = Gen.GetverifyofqueLabour_tourismagentshops(Session["ApplidA"].ToString());

                        if (dsver1.Tables[0].Rows.Count > 0)
                        {
                            if (res == "3" || Convert.ToInt32(res) >= 3)
                            {
                                ResetFormControl(this);
                            }
                        }
                    }
                }
            }

            if (Request.QueryString["intApplicationId"] != null)
            {
                hdfFlagID0.Value = Request.QueryString["intApplicationId"];
                string labourformvisible = "";
                DataSet dscheck1 = new DataSet();
                dscheck1 = Gen.GetShowQuestionariesCFO_tourismagentshops(Session["uid"].ToString().Trim());
                Session["dscheck"] = dscheck1;
                if (dscheck1.Tables[0].Rows.Count > 0)
                {
                    Session["ApplidA"] = dscheck1.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
                    labourformvisible = dscheck1.Tables[0].Rows[0]["labourformvisible"].ToString().Trim();
                    if (dscheck1.Tables[0].Rows[0]["LabourAct_Id"].ToString() != null && dscheck1.Tables[0].Rows[0]["LabourAct_Id"].ToString() != "")
                    {
                        ViewState["LabourActId"] = dscheck1.Tables[0].Rows[0]["LabourAct_Id"].ToString();
                        LabourActid = ViewState["LabourActId"].ToString();
                    }
                    if (dscheck1 != null && dscheck1.Tables.Count > 0 && dscheck1.Tables[0].Rows.Count > 0)
                    {
                        txtTotalEmployees.Text = dscheck1.Tables[0].Rows[0]["BuildingWorker"].ToString();
                        if (dscheck1.Tables[0].Rows[0]["txtDateofCommenceAct1"].ToString() != null && dscheck1.Tables[0].Rows[0]["txtDateofCommenceAct1"].ToString() != "")
                        {
                            txtEstDateCompAct2.Text = Convert.ToDateTime(dscheck1.Tables[0].Rows[0]["txtDateofCommenceAct1"]).ToString("dd-MM-yyyy");
                        }

                    }
                    if (labourformvisible.Trim() == "N")
                    {
                        if (Request.QueryString[1].ToString() == "N")
                            Response.Redirect("frmPaymentTravelAgent.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
                        
                    }
                }
                else
                {
                    Session["ApplidA"] = "0";
                }
                if (!IsPostBack)
                {
                    if (LabourActid.Contains("1"))
                    {
                        trattachment.Visible = true;
                        trteluguboard.Visible = true;
                        tridproof.Visible = true;
                        trphoto.Visible = true;
                        trrenetaldeed.Visible = true;
                        trClassification.Visible = true;
                        trManagerorNot.Visible = true;
                        DataSet dsClassification = new DataSet();
                        dsClassification = Gen.GetLabourActClassification();
                        if (dsClassification != null && dsClassification.Tables.Count > 0 && dsClassification.Tables[0].Rows.Count > 0)
                        {
                            ddlEstClassification.DataSource = dsClassification.Tables[0];
                            ddlEstClassification.DataTextField = "Classification_Desc";
                            ddlEstClassification.DataValueField = "Classification_Id";
                            ddlEstClassification.DataBind();
                        }
                        AddSelect(ddlEstClassification);
                        trGodown1.Visible = true;
                        trGodown2.Visible = true;

                        gvWorkerDtls.DataSource = BindWorkerPlaceGrid();
                        gvWorkerDtls.DataBind();

                        gvFamilyMembersAct1.DataSource = BindgvFamilyMembersAct1Grid();
                        gvFamilyMembersAct1.DataBind();

                        gvEmployeeNames.DataSource = BindgvEmployeeNamesGrid();
                        gvEmployeeNames.DataBind();
                        lblNatureofBusiness.Text = "8. Nature of business *";
                        trFamilyMembers1.Visible = true;
                        trFamilyMembers2.Visible = true;
                        lblTotalEmps.Text = "11. Total No. of Employees *:";
                        trAgewiseEmployees.Visible = true;
                        trNamesofEmployees1.Visible = true;
                        trNamesofEmployees2.Visible = true;
                        trEmployerAddress1.Visible = true;
                        lblPostalAddress.Text = "3. Address of the Shop/Establishment";
                        lblManagerAddress.Visible = false;

                        trDateofCommencement.Visible = true;
                        trTotalEmps.Visible = true;

                        DataSet dsCategory = new DataSet();
                        dsCategory = Gen.GetLabourActCategoryMaster();
                        if (dsCategory != null && dsCategory.Tables.Count > 0 && dsCategory.Tables[0].Rows.Count > 0)
                        {
                            //ddlCategoryofEstablishment.DataSource = dsCategory.Tables[0];
                            //ddlCategoryofEstablishment.DataTextField = "Category_Desc";
                            //ddlCategoryofEstablishment.DataValueField = "Category_Id";
                            //ddlCategoryofEstablishment.DataBind();
                        }
                        //AddSelect(ddlCategoryofEstablishment);
                        trEmployerDetails1.Visible = true;
                        trEmployerDetails2.Visible = true;

                        trEmployerAddress2.Visible = true;
                        BindDistricts(ddlDistrictResidentialAct1);
                        trCategory.Visible = true;

                        
                        lblPermanentAddress.Text = "7. Full name and Permanent Address of the establishment, if any";
                        lblManagerOrNot.Text = "8. Manager/Agent if any (with residential address):";
                       
                        lblDateofCommencement.Text = "10. Estimated date of commencement of building or other construction work";
                        lblFamily.Text = "11. Name of family members of employees family engaged in Shop / Establishment";
                        
                        lblEmployeeNames.Text = "13. Name of Employees (Optional):";
                        lblCompletionDate.Text = "14. Estimated date of completion of building or other construction work";

                  
                        lblCategoryofEstab.Text = "2. Category of Establishment";
                        lblEmployer.Text = "5. Full name and address of the Principal Employer(furnish father's name in the case of individuals) with Phone No.:";
                        lblDirector.Text = "7.  Name and address of the Director / Partners (in case of companies/firm)";
                        lblContractor.Text = "12. Particulars of Contractors and migrant workmen";
                       
                    }



                    BindDistricts(ddlShopDistrict);
                    BindDistricts(ddlManagerDistrictAct1);
                }
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


    void FillDetails()
    {

        hdfFlagID.Value = "1";
        DataSet ds = new DataSet();
        string LabourActid = "";
        try
        {
            LabourActid = ViewState["LabourActId"].ToString();
            int QuestionnaireId = Convert.ToInt32(Session["ApplidA"].ToString());
            ds = Gen.tourismagentshops_getLabourDetails_CFO(hdfFlagID0.Value.ToString(), QuestionnaireId);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                if (LabourActid.Contains("1") || LabourActid.Contains("3") || LabourActid.Contains("4"))
                {
                    ddlCategoryofEstablishment.SelectedValue = ds.Tables[0].Rows[0]["Form1_1_Estb_Category"].ToString();
                    if (ddlEstClassification.SelectedValue == "3" || ddlEstClassification.SelectedValue == "4")
                    {
                        trMemorandum.Visible = true;
                        trincorportaion.Visible = true;
                    }
                }
                if (LabourActid.Contains("2"))
                {
                    txtEstDateCompAct2.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"]).ToString("dd-MM-yyyy");
                    txtTotalEmployees.Text = ds.Tables[0].Rows[0]["Form1_2_MaxWorkers"].ToString();

                    txtDoorNoPermAct2.Text = ds.Tables[0].Rows[0]["Form1_2_Per_DoorNo"].ToString();
                    txtPinCodePermAct2.Text = ds.Tables[0].Rows[0]["Form1_2_Per_PinCode"].ToString();
                    ddlDistrictPermAct2.SelectedValue = ds.Tables[0].Rows[0]["Form1_2_Per_District"].ToString();
                    ddlDistrictPermAct2_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlMandalPermAct2.SelectedValue = ds.Tables[0].Rows[0]["Form1_2_Per_Mandal"].ToString();
                    ddlMandalPermAct2_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlVillagePermAct2.SelectedValue = ds.Tables[0].Rows[0]["Form1_2_Per_Village"].ToString();

                    txtFullNamePermAct2.Text = ds.Tables[0].Rows[0]["Form1_2_FullName"].ToString();

                }
                if (LabourActid.Contains("3"))
                {
                    ddlSchemAct3.SelectedValue = ds.Tables[0].Rows[0]["Form1_3_Registered_Act"].ToString();
                    ddlSchemAct3_SelectedIndexChanged(this, EventArgs.Empty);
                    txtRegLicAct3.Text = ds.Tables[0].Rows[0]["Form1_3_Reg_Lic"].ToString();
                    txtReRegLicAct3.Text = ds.Tables[0].Rows[0]["Form1_3_Reg_Lic"].ToString();
                }
                if (LabourActid.Contains("4"))
                {
                    ddlSchemAct3.SelectedValue = ds.Tables[0].Rows[0]["Form1_3_Registered_Act"].ToString();
                    ddlSchemAct3_SelectedIndexChanged(this, EventArgs.Empty);
                    txtRegLicAct3.Text = ds.Tables[0].Rows[0]["Form1_3_Reg_Lic"].ToString();
                    txtReRegLicAct3.Text = ds.Tables[0].Rows[0]["Form1_3_Reg_Lic"].ToString();

                }
                if (LabourActid.Contains("3") || LabourActid.Contains("4"))
                {

                    if (ds.Tables.Count > 1 && ds.Tables[4].Rows.Count > 0)
                    {
                        ViewState["dtContractorDtls4"] = ds.Tables[4];
                        gvContractorAct4.DataSource = ds.Tables[4];
                        gvContractorAct4.DataBind();
                    }
                }
                txtMobileNoManagerAct2.Text = ds.Tables[0].Rows[0]["Form1_Manager_MobileNo"].ToString();
                txtEmailManagerAct2.Text = ds.Tables[0].Rows[0]["Form1_Manager_EMail"].ToString();
                txtNameofShopAct1.Text = ds.Tables[0].Rows[0]["Form1_Estb_Name"].ToString();
                txtShopDoorNo.Text = ds.Tables[0].Rows[0]["Form1_Estd_DoorNo"].ToString();
                txtShopLocality.Text = ds.Tables[0].Rows[0]["Form1_Estd_Locality"].ToString();
                ddlShopDistrict.SelectedValue = ds.Tables[0].Rows[0]["Form1_Estd_District"].ToString();
                ddlShopDistrict_SelectedIndexChanged(this, EventArgs.Empty);
                ddlShopMandal.SelectedValue = ds.Tables[0].Rows[0]["Form1_Estd_Mandal"].ToString();
                ddlShopMandal_SelectedIndexChanged(this, EventArgs.Empty);
                ddlShopVillage.SelectedValue = ds.Tables[0].Rows[0]["Form1_Estd_Village"].ToString();

                txtShopPincode.Text = ds.Tables[0].Rows[0]["Form1_Estd_PinCode"].ToString();
                TxtnameofUnitAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_Name"].ToString();
                txtPGNameAct1.Text = ds.Tables[0].Rows[0]["Form1_Empolyer_FatherName"].ToString();
                txtDesigAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_Designation"].ToString();
                txtAgeAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_Age"].ToString();
                txtMobileAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_MobileNo"].ToString();
                txtEmailAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_EmailID"].ToString();
                txtDoorNoResidentialAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_DoorNo"].ToString();
                txtLocalResidentialAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_Locality"].ToString();
                ddlDistrictResidentialAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_Employer_District"].ToString();
                ddlDistrictResidentialAct1_SelectedIndexChanged(this, EventArgs.Empty);
                ddlMandalResidentialAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_Employer_Mandal"].ToString();
                ddlMandalResidentialAct1_SelectedIndexChanged(this, EventArgs.Empty);
                ddlVillageResidentialAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_Employer_Village"].ToString();
                if (LabourActid.Contains("1"))
                {
                    Rd_ManagerResidenceAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_1_Manager_Agent_Flag"].ToString();
                    Rd_ManagerResidenceAct1_SelectedIndexChanged(this, EventArgs.Empty);
                }
                txtManagerNameAct1.Text = ds.Tables[0].Rows[0]["Form1_1_Manager_Name"].ToString();
                txtManagerPGNameAct1.Text = ds.Tables[0].Rows[0]["Form1_1_Manager_FatherName"].ToString();
                txtManagerDesignationAct1.Text = ds.Tables[0].Rows[0]["Form1_1_Manager_Designation"].ToString();
                txtManagerDoorNoAct1.Text = ds.Tables[0].Rows[0]["Form1_1_Manager_DoorNo"].ToString();
                txtManagerLocalityAct1.Text = ds.Tables[0].Rows[0]["Form1_1_Manager_Locality"].ToString();
                ddlManagerDistrictAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_1_Manager_District"].ToString();
                ddlManagerDistrictAct1_SelectedIndexChanged(this, EventArgs.Empty);
                ddlManagerMandalAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_1_Manager_Mandal"].ToString();
                ddlManagerMandalAct1_SelectedIndexChanged(this, EventArgs.Empty);
                ddlManagerVillageAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_1_Manager_Village"].ToString();

                txtNatureofBusinessAct1.Text = ds.Tables[0].Rows[0]["Form1_Nature_of_Business"].ToString();
                if (LabourActid.Contains("1") || LabourActid.Contains("2"))
                {
                    txtDateofCommenceAct1.Text = ds.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                }
                if (LabourActid.Contains("1"))
                {
                    ddlEstClassification.SelectedValue = ds.Tables[0].Rows[0]["Form1_1_Estb_Classification"].ToString();

                    txtAbove18Male.Text = ds.Tables[0].Rows[0]["Form1_1_Employees_Above18_Male"].ToString();
                    txtBelow18Male.Text = ds.Tables[0].Rows[0]["Form1_1_Employees_14_18_Male"].ToString();
                    txtAbove18Female.Text = ds.Tables[0].Rows[0]["Form1_1_Employees_Above18_Female"].ToString();
                    txtBelow18FeMale.Text = ds.Tables[0].Rows[0]["Form1_1_Employees_14_18_Female"].ToString();
                    txtBelow18FeMale_TextChanged(this, EventArgs.Empty);

                    if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {
                        ViewState["dtWorkerDtls"] = ds.Tables[1];

                        gvWorkerDtls.DataSource = ds.Tables[1];
                        gvWorkerDtls.DataBind();
                    }
                    if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                    {
                        ViewState["dtFamilyMembers"] = ds.Tables[2];

                        gvFamilyMembersAct1.DataSource = ds.Tables[2];
                        gvFamilyMembersAct1.DataBind();
                    }
                    if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
                    {
                        ViewState["dtEmplyoees"] = ds.Tables[3];

                        gvEmployeeNames.DataSource = ds.Tables[3];
                        gvEmployeeNames.DataBind();
                    }
                    DataSet dsattachment = new DataSet();
                    dsattachment = Gen.ViewAttachment_tourismagentshops(Session["uid"].ToString());

                    if (dsattachment.Tables[0].Rows.Count > 0)
                    {
                        int c = dsattachment.Tables[0].Rows.Count;
                        string sen, sen1, sen2;
                        int i = 0;

                        while (i < c)
                        {
                            sen2 = dsattachment.Tables[0].Rows[i][0].ToString();
                            sen1 = sen2.Replace(@"\", @"/");

                            if (sen1.Contains("CFOAttachments"))
                            {
                                sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/CFOAttachments")), "~/");

                                if (sen.Contains("TeluguBoard"))
                                {
                                    lblTeluguBoard.NavigateUrl = sen;
                                    lblTeluguBoard.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                    LabelTeluguBoard.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                }
                                if (sen.Contains("IDProofEmployer"))
                                {
                                    HyperLinkidproof.NavigateUrl = sen;
                                    HyperLinkidproof.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                    Labelidproof.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                }
                                if (sen.Contains("PassportSizePhoto"))
                                {
                                    HyperLinkphoto.NavigateUrl = sen;
                                    HyperLinkphoto.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                    Labelphoto.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                }
                                if (sen.Contains("RentalSaleDeed"))
                                {
                                    HyperLinkrenetaldeed.NavigateUrl = sen;
                                    HyperLinkrenetaldeed.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                    Labelrenetaldeed.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                }
                                if (sen.Contains("MemorandumofArticle"))
                                {
                                    trMemorandum.Visible = true;
                                    HyperLinkMemorandum.NavigateUrl = sen;
                                    HyperLinkMemorandum.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                    LabelMemorandum.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                }
                                if (sen.Contains("Incorporation"))
                                {
                                    trincorportaion.Visible = true;
                                    HyperLinkincorportaion.NavigateUrl = sen;
                                    HyperLinkincorportaion.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                    Labelincorportaion.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                }
                            }
                            i++;
                        }
                    }
                }

                try
                {
                    txtDirFullName.Text = ds.Tables[0].Rows[0]["Form1_4_Dir_FullName"].ToString();
                    txtDirDoorNo.Text = ds.Tables[0].Rows[0]["Form1_4_Dir_DoorNo"].ToString();
                    ddlDirDistrict.SelectedValue = ds.Tables[0].Rows[0]["Form1_4_Dir_District"].ToString();
                    ddlDirDistrict_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlDirMandal.SelectedValue = ds.Tables[0].Rows[0]["Form1_4_Dir_Mandal"].ToString();
                    ddlDirMandal_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlDirVillage.SelectedValue = ds.Tables[0].Rows[0]["Form1_4_Dir_Village"].ToString();
                }
                catch (Exception ex)
                {

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
    protected void gvWorkerDtls_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindWorkerPlaceGridAdd();

                DropDownList ddlWorkPlace;
                TextBox txtDoorNo;
                TextBox txtLocality;

                String[] arraydata = new String[3];

                int gvrcnt = gvWorkerDtls.Rows.Count;
                decimal extent = 0;
                for (int i = 0; i < gvrcnt; i++)
                {
                    ddlWorkPlace = (DropDownList)gvWorkerDtls.Rows[i].Cells[1].Controls[1];
                    arraydata[0] = ddlWorkPlace.SelectedValue;
                    GridViewRow gvr = gvWorkerDtls.Rows[i];
                    txtDoorNo = (TextBox)gvr.FindControl("txtDoorNo");
                    arraydata[1] = txtDoorNo.Text;
                    txtLocality = (TextBox)gvr.FindControl("txtLocality");
                    arraydata[2] = txtLocality.Text;

                    if (txtDoorNo.Text == "" || txtLocality.Text == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please enter Work Place details";
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
                    ViewState["dtWorkerDtls"] = dt;
                    gvWorkerDtls.DataSource = dt;
                    gvWorkerDtls.DataBind();
                }
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvWorkerDtls.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindWorkerPlaceGridAdd();
                    DropDownList ddlWorkPlace;
                    TextBox txtDoorNo;
                    TextBox txtLocality;
                    String[] arraydata = new String[3];

                    int j = Convert.ToInt32(e.CommandArgument);
                    decimal extent = 0;
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {

                        if (i != j)
                        {
                            ddlWorkPlace = (DropDownList)gvWorkerDtls.Rows[i].Cells[1].Controls[1];
                            arraydata[0] = ddlWorkPlace.SelectedValue;
                            GridViewRow gvr = gvWorkerDtls.Rows[i];
                            txtDoorNo = (TextBox)gvr.FindControl("txtDoorNo");
                            arraydata[1] = txtDoorNo.Text;
                            txtLocality = (TextBox)gvr.FindControl("txtLocality");
                            arraydata[2] = txtLocality.Text;

                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["dtWorkerDtls"] = dt;
                    gvWorkerDtls.DataSource = dt;
                    gvWorkerDtls.DataBind();
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
    protected void gvWorkerDtls_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            DataSet dsWorkPlace = new DataSet();
            dsWorkPlace = Gen.GetWorkPlaceMaster();
            if (dsWorkPlace != null && dsWorkPlace.Tables.Count > 0 && dsWorkPlace.Tables[0].Rows.Count > 0)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ddlWorkPlace = (DropDownList)e.Row.Cells[1].Controls[1];

                    ddlWorkPlace.DataSource = dsWorkPlace.Tables[0];
                    ddlWorkPlace.DataTextField = "Work_Place";
                    ddlWorkPlace.DataValueField = "WorkPlace_Id";
                    ddlWorkPlace.DataBind();

                    AddSelect(ddlWorkPlace);

                    DataTable dt = (DataTable)ViewState["dtWorkerDtls"];

                    if (dt != null)
                    {
                        if (e.Row.RowIndex < dt.Rows.Count)
                        {
                            GridViewRow gvr = e.Row;
                            TextBox txtDoorNo = (TextBox)gvr.FindControl("txtDoorNo");
                            TextBox txtLocality = (TextBox)gvr.FindControl("txtLocality");

                            txtDoorNo.Text = dt.Rows[e.Row.RowIndex]["Door_No"].ToString();
                            txtLocality.Text = dt.Rows[e.Row.RowIndex]["Locality"].ToString();
                            ddlWorkPlace.SelectedValue = dt.Rows[e.Row.RowIndex]["Work_Place"].ToString();

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
    protected DataTable BindWorkerPlaceGridAdd()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Work_Place");
        dt.Columns.Add("Door_No");
        dt.Columns.Add("Locality");
        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";
        dr[2] = "";

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
    protected DataTable BindWorkerPlaceGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Work_Place");

        DataRow dr = dt.NewRow();
        dr[0] = "";

        dt.Rows.Add(dr);

        return dt;
    }
    protected void gvFamilyMembersAct1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindgvFamilyMembersAct1GridAdd();
                String[] arraydata = new String[4];

                int gvrcnt = gvFamilyMembersAct1.Rows.Count;
                decimal extent = 0;
                for (int i = 0; i < gvrcnt; i++)
                {
                    DropDownList ddlRelationship = (DropDownList)gvFamilyMembersAct1.Rows[i].Cells[2].Controls[1]; //(DropDownList)e.Row.Cells[2].Controls[1];
                    DropDownList ddlGender = (DropDownList)gvFamilyMembersAct1.Rows[i].Cells[3].Controls[1];
                    DropDownList ddlPersonType = (DropDownList)gvFamilyMembersAct1.Rows[i].Cells[4].Controls[1];

                    GridViewRow gvr = gvFamilyMembersAct1.Rows[i];
                    TextBox txtFamilyMemeberName = (TextBox)gvr.FindControl("txtFamilyNameAct1");
                    arraydata[0] = txtFamilyMemeberName.Text;
                    arraydata[1] = ddlRelationship.SelectedValue;
                    arraydata[2] = ddlGender.SelectedValue;
                    arraydata[3] = ddlPersonType.SelectedValue;


                    if (txtFamilyMemeberName.Text == "" || ddlRelationship.SelectedValue == "0")// || txtEnjExtent.Value == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please enter Family Member details";
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
                    ViewState["dtFamilyMembers"] = dt;
                    gvFamilyMembersAct1.DataSource = dt;
                    gvFamilyMembersAct1.DataBind();
                }
                
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvFamilyMembersAct1.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindgvFamilyMembersAct1GridAdd();
                    String[] arraydata = new String[4];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {

                        if (i != j)
                        {
                            DropDownList ddlRelationship = (DropDownList)gvFamilyMembersAct1.Rows[i].Cells[2].Controls[1]; 
                            DropDownList ddlGender = (DropDownList)gvFamilyMembersAct1.Rows[i].Cells[3].Controls[1];
                            DropDownList ddlPersonType = (DropDownList)gvFamilyMembersAct1.Rows[i].Cells[4].Controls[1];

                            GridViewRow gvr = gvFamilyMembersAct1.Rows[i];
                            TextBox txtFamilyMemeberName = (TextBox)gvr.FindControl("txtFamilyNameAct1");
                            arraydata[0] = txtFamilyMemeberName.Text;
                            arraydata[1] = ddlRelationship.SelectedValue;
                            arraydata[2] = ddlGender.SelectedValue;
                            arraydata[3] = ddlPersonType.SelectedValue;

                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["dtFamilyMembers"] = dt;
                    gvFamilyMembersAct1.DataSource = dt;
                    gvFamilyMembersAct1.DataBind();
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
    protected void gvFamilyMembersAct1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            DataSet dsRelations = new DataSet();
            DataSet dsGenders = new DataSet();
            DataSet dsPersonTypes = new DataSet();
            dsRelations = Gen.GetLabourActRelationshipMaster();

            dsGenders = Gen.GetGender();
            dsPersonTypes = Gen.GetLabourActPersonMaster();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlRelationship = (DropDownList)e.Row.Cells[2].Controls[1];
                DropDownList ddlGender = (DropDownList)e.Row.Cells[3].Controls[1];
                DropDownList ddlPersonType = (DropDownList)e.Row.Cells[4].Controls[1];

                if (dsRelations != null && dsRelations.Tables.Count > 0 && dsRelations.Tables[0].Rows.Count > 0)
                {
                    ddlRelationship.DataSource = dsRelations.Tables[0];
                    ddlRelationship.DataTextField = "Relationship_Type";
                    ddlRelationship.DataValueField = "Relationship_Id";
                    ddlRelationship.DataBind();
                }
                if (dsGenders != null && dsGenders.Tables.Count > 0 && dsGenders.Tables[0].Rows.Count > 0)
                {
                    ddlGender.DataSource = dsGenders.Tables[0];
                    ddlGender.DataTextField = "Gender_Type";
                    ddlGender.DataValueField = "Gender_Id";
                    ddlGender.DataBind();
                }
                if (dsPersonTypes != null && dsPersonTypes.Tables.Count > 0 && dsPersonTypes.Tables[0].Rows.Count > 0)
                {
                    ddlPersonType.DataSource = dsPersonTypes.Tables[0];
                    ddlPersonType.DataTextField = "PersonType_Type";
                    ddlPersonType.DataValueField = "PersonType_Id";
                    ddlPersonType.DataBind();
                }

                AddSelect(ddlRelationship);
                AddSelect(ddlGender);
                AddSelect(ddlPersonType);

                DataTable dt = (DataTable)ViewState["dtFamilyMembers"];

                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        GridViewRow gvr = e.Row;
                        TextBox txtFamilyMemberName = (TextBox)gvr.FindControl("txtFamilyNameAct1");

                        txtFamilyMemberName.Text = dt.Rows[e.Row.RowIndex]["Name"].ToString();
                        ddlRelationship.SelectedValue = dt.Rows[e.Row.RowIndex]["RelationShip"].ToString();
                        ddlGender.SelectedValue = dt.Rows[e.Row.RowIndex]["Gender"].ToString();
                        ddlPersonType.SelectedValue = dt.Rows[e.Row.RowIndex]["Adult_Flag"].ToString();
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
    protected DataTable BindgvFamilyMembersAct1GridAdd()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Name");
        dt.Columns.Add("RelationShip");
        dt.Columns.Add("Gender");
        dt.Columns.Add("Adult_Flag");
        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";
        dr[2] = "";
        dr[3] = "";
        dt.Rows.Add(dr);
        return dt;
    }

    protected DataTable BindgvFamilyMembersAct1Grid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Name");

        DataRow dr = dt.NewRow();
        dr[0] = "";

        dt.Rows.Add(dr);

        return dt;
    }
    protected DataTable BindgvEmployeeNamesGridAdd()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Occupation");
        dt.Columns.Add("Name");
        dt.Columns.Add("Gender");
        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";
        dr[2] = "";

        dt.Rows.Add(dr);
        return dt;
    }

    protected DataTable BindgvEmployeeNamesGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Occupation");

        DataRow dr = dt.NewRow();
        dr[0] = "";

        dt.Rows.Add(dr);

        return dt;
    }
    protected void gvEmployeeNames_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            DataSet dsOccupations = new DataSet();
            DataSet dsGenders = new DataSet();
            dsOccupations = Gen.GetLabourActOccupationMaster();

            dsGenders = Gen.GetGender();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlOccupationAct1 = (DropDownList)e.Row.Cells[1].Controls[1];

                DropDownList ddlGender = (DropDownList)e.Row.Cells[3].Controls[1];


                if (dsOccupations != null && dsOccupations.Tables.Count > 0 && dsOccupations.Tables[0].Rows.Count > 0)
                {
                    ddlOccupationAct1.DataSource = dsOccupations.Tables[0];
                    ddlOccupationAct1.DataTextField = "Occupation_Type";
                    ddlOccupationAct1.DataValueField = "Occupation_Id";
                    ddlOccupationAct1.DataBind();
                }
                if (dsGenders != null && dsGenders.Tables.Count > 0 && dsGenders.Tables[0].Rows.Count > 0)
                {
                    ddlGender.DataSource = dsGenders.Tables[0];
                    ddlGender.DataTextField = "Gender_Type";
                    ddlGender.DataValueField = "Gender_Id";
                    ddlGender.DataBind();
                }


                AddSelect(ddlOccupationAct1);
                AddSelect(ddlGender);
                DataTable dt = (DataTable)ViewState["dtEmplyoees"];

                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        GridViewRow gvr = e.Row;
                        TextBox txtEmployeeName = (TextBox)gvr.FindControl("txtEmployeeNameAct1");

                        txtEmployeeName.Text = dt.Rows[e.Row.RowIndex]["Name"].ToString();
                        ddlOccupationAct1.SelectedValue = dt.Rows[e.Row.RowIndex]["Occupation"].ToString();
                        ddlGender.SelectedValue = dt.Rows[e.Row.RowIndex]["Gender"].ToString();

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
    protected void gvEmployeeNames_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindgvEmployeeNamesGridAdd();
                String[] arraydata = new String[3];

                int gvrcnt = gvEmployeeNames.Rows.Count;
                decimal extent = 0;
                for (int i = 0; i < gvrcnt; i++)
                {
                    DropDownList ddlOccupation = (DropDownList)gvEmployeeNames.Rows[i].Cells[1].Controls[1]; 
                 
                    DropDownList ddlGender = (DropDownList)gvEmployeeNames.Rows[i].Cells[3].Controls[1];

                    GridViewRow gvr = gvEmployeeNames.Rows[i];
                    TextBox txtEmployeeName = (TextBox)gvr.FindControl("txtEmployeeNameAct1");
                    arraydata[0] = ddlOccupation.SelectedValue;
                    arraydata[1] = txtEmployeeName.Text;
                    arraydata[2] = ddlGender.SelectedValue;


                    if (txtEmployeeName.Text == "" || ddlOccupation.SelectedValue == "0" || ddlGender.SelectedValue == "0")
                        
                    {
                        valid = 1;
                        lblmsg.Text = "Please enter Employee details";
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
                    ViewState["dtEmplyoees"] = dt;
                    gvEmployeeNames.DataSource = dt;
                    gvEmployeeNames.DataBind();
                }
             
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvEmployeeNames.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindgvEmployeeNamesGridAdd();
                    String[] arraydata = new String[3];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {

                        if (i != j)
                        {
                            DropDownList ddlOccupation = (DropDownList)gvEmployeeNames.Rows[i].Cells[1].Controls[1]; 
                            
                            DropDownList ddlGender = (DropDownList)gvEmployeeNames.Rows[i].Cells[3].Controls[1];

                            GridViewRow gvr = gvEmployeeNames.Rows[i];
                            TextBox txtEmployeeName = (TextBox)gvr.FindControl("txtEmployeeNameAct1");
                            arraydata[0] = ddlOccupation.SelectedValue;
                            arraydata[1] = txtEmployeeName.Text;
                            arraydata[2] = ddlGender.SelectedValue;

                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["dtEmplyoees"] = dt;
                    gvEmployeeNames.DataSource = dt;
                    gvEmployeeNames.DataBind();
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
    protected void Rd_ManagerResidenceAct1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Rd_ManagerResidenceAct1.SelectedValue.ToString().Trim() == "Y")
        {
            trManagerResidenceAct1.Visible = true;
        }
        else
        {
            trManagerResidenceAct1.Visible = false;
        }
    }
    protected DataTable BindgvNoofEmployeesAct1Grid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("");
        dt.Columns.Add("");
        dt.Columns.Add("");

        DataRow dr = dt.NewRow();
        dr[0] = "MALE";
        dr[1] = "FEMALE";
        dr[2] = "TOTAL";
        dt.Rows.Add(dr);

        return dt;
    }
    public void BindDistricts(DropDownList ddlDistrict)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlDistrict.Items.Clear();
            dsd = Gen.GetDistrictsWithoutHYD_Labour();
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
            throw ex;
        }
    }
    protected void ddlShopDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindMandals(ddlShopDistrict, ddlShopMandal);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    public void BindMandals(DropDownList ddlDistrict, DropDownList ddlMandal)
    {

        ddlMandal.Items.Clear();
        DataSet dsm = new DataSet();
        dsm = Gen.GetMandalsLabour(ddlDistrict.SelectedValue);
        if (dsm.Tables[0].Rows.Count > 0)
        {
            ddlMandal.DataSource = dsm.Tables[0];
            ddlMandal.DataValueField = "Mandal_Id";
            ddlMandal.DataTextField = "Mandal_Name";
            ddlMandal.DataBind();
            ddlMandal.Items.Insert(0, "--Mandal--");
        }
        else
        {
            ddlMandal.Items.Clear();
            ddlMandal.Items.Insert(0, "--Mandal--");
        }

    }
    protected void ddlShopMandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindVillages(ddlShopMandal, ddlShopVillage);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void ddlDistrictResidentialAct1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindMandals(ddlDistrictResidentialAct1, ddlMandalResidentialAct1);

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void ddlMandalResidentialAct1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindVillages(ddlMandalResidentialAct1, ddlVillageResidentialAct1);
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
            dsv = Gen.GetVillagesLabour(ddlMandal.SelectedValue);
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

    protected void ddlManagerMandalAct1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindVillages(ddlManagerMandalAct1, ddlManagerVillageAct1);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void ddlManagerDistrictAct1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindMandals(ddlManagerDistrictAct1, ddlManagerMandalAct1);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
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

    protected void txtAbove18Male_TextChanged(object sender, EventArgs e)
    {
        try
        {
            int totalEmp = 0, Above18Male = 0, Above18Female = 0, Below18Male = 0, Below18Female = 0, totalAbove18Emp = 0, totalBelow18Emp = 0;
            if (txtAbove18Male.Text.Trim() != "")
                Above18Male = Convert.ToInt32(txtAbove18Male.Text.Trim());
            if (txtAbove18Female.Text.Trim() != "")
                Above18Female = Convert.ToInt32(txtAbove18Female.Text.Trim());
            if (txtBelow18Male.Text.Trim() != "")
                Below18Male = Convert.ToInt32(txtBelow18Male.Text.Trim());
            if (txtBelow18FeMale.Text.Trim() != "")
                Below18Female = Convert.ToInt32(txtBelow18FeMale.Text.Trim());

            totalAbove18Emp = Above18Male + Above18Female;
            totalBelow18Emp = Below18Male + Below18Female;
            totalEmp = totalAbove18Emp + totalBelow18Emp;

            txtTotalEmployees.Text = totalEmp.ToString();
            txtTotalAbove18.Text = totalAbove18Emp.ToString();
            txtTotalBelow18.Text = totalBelow18Emp.ToString();
            txtBelow18Male.Focus();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void txtAbove18Female_TextChanged(object sender, EventArgs e)
    {
        try
        {
            int totalEmp = 0, Above18Male = 0, Above18Female = 0, Below18Male = 0, Below18Female = 0, totalAbove18Emp = 0, totalBelow18Emp = 0;
            if (txtAbove18Male.Text.Trim() != "")
                Above18Male = Convert.ToInt32(txtAbove18Male.Text.Trim());
            if (txtAbove18Female.Text.Trim() != "")
                Above18Female = Convert.ToInt32(txtAbove18Female.Text.Trim());
            if (txtBelow18Male.Text.Trim() != "")
                Below18Male = Convert.ToInt32(txtBelow18Male.Text.Trim());
            if (txtBelow18FeMale.Text.Trim() != "")
                Below18Female = Convert.ToInt32(txtBelow18FeMale.Text.Trim());

            totalAbove18Emp = Above18Male + Above18Female;
            totalBelow18Emp = Below18Male + Below18Female;
            totalEmp = totalAbove18Emp + totalBelow18Emp;

            txtTotalEmployees.Text = totalEmp.ToString();
            txtTotalAbove18.Text = totalAbove18Emp.ToString();
            txtTotalBelow18.Text = totalBelow18Emp.ToString();
            txtBelow18FeMale.Focus();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }

    protected void txtBelow18FeMale_TextChanged(object sender, EventArgs e)
    {
        try
        {
            int totalEmp = 0, Above18Male = 0, Above18Female = 0, Below18Male = 0, Below18Female = 0, totalAbove18Emp = 0, totalBelow18Emp = 0;
            if (txtAbove18Male.Text.Trim() != "")
                Above18Male = Convert.ToInt32(txtAbove18Male.Text.Trim());
            if (txtAbove18Female.Text.Trim() != "")
                Above18Female = Convert.ToInt32(txtAbove18Female.Text.Trim());
            if (txtBelow18Male.Text.Trim() != "")
                Below18Male = Convert.ToInt32(txtBelow18Male.Text.Trim());
            if (txtBelow18FeMale.Text.Trim() != "")
                Below18Female = Convert.ToInt32(txtBelow18FeMale.Text.Trim());

            totalAbove18Emp = Above18Male + Above18Female;
            totalBelow18Emp = Below18Male + Below18Female;
            totalEmp = totalAbove18Emp + totalBelow18Emp;

            txtTotalEmployees.Text = totalEmp.ToString();
            txtTotalAbove18.Text = totalAbove18Emp.ToString();
            txtTotalBelow18.Text = totalBelow18Emp.ToString();
            txtBelow18FeMale.Focus();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void txtBelow18Male_TextChanged(object sender, EventArgs e)
    {
        try
        {
            int totalEmp = 0, Above18Male = 0, Above18Female = 0, Below18Male = 0, Below18Female = 0, totalAbove18Emp = 0, totalBelow18Emp = 0;
            if (txtAbove18Male.Text.Trim() != "")
                Above18Male = Convert.ToInt32(txtAbove18Male.Text.Trim());
            if (txtAbove18Female.Text.Trim() != "")
                Above18Female = Convert.ToInt32(txtAbove18Female.Text.Trim());
            if (txtBelow18Male.Text.Trim() != "")
                Below18Male = Convert.ToInt32(txtBelow18Male.Text.Trim());
            if (txtBelow18FeMale.Text.Trim() != "")
                Below18Female = Convert.ToInt32(txtBelow18FeMale.Text.Trim());

            totalAbove18Emp = Above18Male + Above18Female;
            totalBelow18Emp = Below18Male + Below18Female;
            totalEmp = totalAbove18Emp + totalBelow18Emp;

            txtTotalEmployees.Text = totalEmp.ToString();
            txtTotalAbove18.Text = totalAbove18Emp.ToString();
            txtTotalBelow18.Text = totalBelow18Emp.ToString();
            txtAbove18Female.Focus();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        try
        {
            int valid = 0;
            if (gvWorkerDtls.Visible == true)
            {
                if (gvWorkerDtls.Rows.Count < 2)
                {
                    lblmsg0.Text = "<font color='red'>Please enter Worker Details..!</font>";
                    lblmsg0.Visible = true;
                    success.Visible = false;
                    Failure.Visible = true;
                    valid = 1;
                }
            }
            if (gvFamilyMembersAct1.Visible == true)
            {
                if (gvFamilyMembersAct1.Rows.Count < 2)
                {
                    lblmsg0.Text = "<font color='red'>" + lblmsg0.Text + "," + "</br>Please enter family members of the Employees Details..!</font>";
                    lblmsg0.Visible = true;
                    success.Visible = false;
                    Failure.Visible = true;
                    valid = 1;
                }
            }
            if (gvEmployeeNames.Visible == true)
            {
                if (gvEmployeeNames.Rows.Count < 2)
                {
                    lblmsg0.Text = "<font color='red'>" + lblmsg0.Text + "," + "</br>Please enter Employees Details..!</font>";
                    lblmsg0.Visible = true;
                    success.Visible = false;
                    Failure.Visible = true;
                    valid = 1;
                }
            }
            if (gvContractorAct4.Visible == true)
            {
                if (gvContractorAct4.Rows.Count < 2)
                {
                    lblmsg0.Text = "<font color='red'>" + lblmsg0.Text + "," + "</br>Please enter Contractor and migrant workmen Details..!</font>";
                    lblmsg0.Visible = true;
                    success.Visible = false;
                    Failure.Visible = true;
                    valid = 1;
                }
            }
            if (trteluguboard.Visible)
            {
                if (LabelTeluguBoard.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload Telugu Board Attachment..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
            if (tridproof.Visible)
            {
                if (Labelidproof.Text == "")
                {
                    FileUploadidproof.Enabled = true;
                    lblmsg0.Text = "<font color='red'>Please Upload Id proof of Employer..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }

            if (trphoto.Visible)
            {
                if (Labelphoto.Text == "")
                {
                    FileUploadphoto.Enabled = true;
                    lblmsg0.Text = "<font color='red'>Please Upload Passport Size of Employee..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }

            if (trrenetaldeed.Visible)
            {
                if (Labelrenetaldeed.Text == "")
                {
                    FileUploadrenetaldeed.Enabled = true;
                    lblmsg0.Text = "<font color='red'>Please Upload Rental Deed/Sale Deed/Ownership Proof..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
            if (ddlEstClassification.SelectedValue == "3" || ddlEstClassification.SelectedValue == "4")
            {
                if (trMemorandum.Visible)
                {
                    if (LabelMemorandum.Text == "")
                    {
                        lblmsg0.Text = "<font color='red'>Please Upload Memorandum of Articles..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        return;
                    }
                }
                if (trincorportaion.Visible)
                {
                    if (Labelincorportaion.Text == "")
                    {
                        lblmsg0.Text = "<font color='red'>Please Upload Certification of Incorporation..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        return;
                    }
                }
            }
            int totalEmp = 0, Above18Male = 0, Above18Female = 0, Below18Male = 0, Below18Female = 0, totalAbove18Emp = 0, totalBelow18Emp = 0;
            if (txtAbove18Male.Text.Trim() != "")
                Above18Male = Convert.ToInt32(txtAbove18Male.Text.Trim());
            if (txtAbove18Female.Text.Trim() != "")
                Above18Female = Convert.ToInt32(txtAbove18Female.Text.Trim());
            if (txtBelow18Male.Text.Trim() != "")
                Below18Male = Convert.ToInt32(txtBelow18Male.Text.Trim());
            if (txtBelow18FeMale.Text.Trim() != "")
                Below18Female = Convert.ToInt32(txtBelow18FeMale.Text.Trim());

            totalAbove18Emp = Above18Male + Above18Female;
            totalBelow18Emp = Below18Male + Below18Female;
            totalEmp = totalAbove18Emp + totalBelow18Emp;

            if (Convert.ToInt32(txtTotalEmployees.Text.Trim()) != Convert.ToInt32(totalEmp))
            {
                lblmsg0.Text = "<font color='red'>" + lblmsg0.Text + "," + "</br>Total of Adults and Young persons should be equal to total number of Employees..!</font>";
                lblmsg0.Visible = true;
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            if (valid == 0)
            {
                valid = SaveLabourDetails();
                lblmsg.Text = "<font color='green'>Labour Details Added Successfully..!</font>";
                success.Visible = true;
                Failure.Visible = false;
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    private int SaveLabourDetails()
    {

        LabourActVO labouractvo = new LabourActVO();
        labouractvo.QuestionnaireId = Convert.ToInt32(Session["ApplidA"].ToString());
        labouractvo.intCFEEnterpid = Convert.ToInt32(Request.QueryString[0].ToString());

        labouractvo.EstClassification = ddlEstClassification.SelectedValue;
        labouractvo.CategoryofEstablishment = ddlCategoryofEstablishment.SelectedValue;
        labouractvo.NameofShopAct1 = txtNameofShopAct1.Text;
        labouractvo.CreatedBy = Convert.ToInt32(Session["uid"].ToString().Trim());
        labouractvo.ShopDoorNo = txtShopDoorNo.Text;
        labouractvo.ShopLocality = txtShopLocality.Text;
        labouractvo.ShopDistrict = ddlShopDistrict.SelectedValue;
        labouractvo.ShopMandal = ddlShopMandal.SelectedValue;
        labouractvo.ShopVillage = ddlShopVillage.SelectedValue;
        labouractvo.ShopPincode = txtShopPincode.Text;

        labouractvo.NameofUnitAct1 = TxtnameofUnitAct1.Text;
        labouractvo.PGNameAct1 = txtPGNameAct1.Text;
        labouractvo.EmpDesignation = txtDesigAct1.Text;
        labouractvo.AgeAct1 = txtAgeAct1.Text;
        labouractvo.MobileAct1 = txtMobileAct1.Text;
        labouractvo.EmailAct1 = txtEmailAct1.Text;

        labouractvo.DoorNoResidentialAct1 = txtDoorNoResidentialAct1.Text;
        labouractvo.LocalResidentialAct1 = txtLocalResidentialAct1.Text;
        labouractvo.DistrictResidentialAct1 = ddlDistrictResidentialAct1.SelectedValue;
        labouractvo.MandalResidentialAct1 = ddlMandalResidentialAct1.SelectedValue;
        labouractvo.VillageResidentialAct1 = ddlVillageResidentialAct1.SelectedValue;

        labouractvo.ManagerResidenceAct1 = Rd_ManagerResidenceAct1.SelectedValue;
        labouractvo.ManagerNameAct1 = txtManagerNameAct1.Text;
        labouractvo.ManagerPGNameAct1 = txtManagerPGNameAct1.Text;
        labouractvo.ManagerDesignationAct1 = txtManagerDesignationAct1.Text;
        labouractvo.ManagerDoorNo = txtManagerDoorNoAct1.Text;
        labouractvo.ManagerLocalityAct1 = txtManagerLocalityAct1.Text;
        labouractvo.ManagerDistrictAct1 = ddlManagerDistrictAct1.SelectedValue;
        labouractvo.ManagerMandalAct1 = ddlManagerMandalAct1.SelectedValue;
        labouractvo.ManagerVillageAct1 = ddlManagerVillageAct1.SelectedValue;
        labouractvo.ManagerMobileNo = txtMobileNoManagerAct2.Text;
        labouractvo.ManagerEmail = txtEmailManagerAct2.Text;

        labouractvo.NatureofBusinessAct1 = txtNatureofBusinessAct1.Text;
        labouractvo.DateofCommenceAct1 = txtDateofCommenceAct1.Text;

        if (txtTotalEmployees.Text.Trim() != "")
            labouractvo.TotalEmployees = Convert.ToInt32(txtTotalEmployees.Text);
        if (txtAbove18Male.Text.Trim() != "")
            labouractvo.Above18Male = Convert.ToInt32(txtAbove18Male.Text);
        if (txtBelow18Male.Text.Trim() != "")
            labouractvo.Below18Male = Convert.ToInt32(txtBelow18Male.Text);
        if (txtAbove18Female.Text.Trim() != "")
            labouractvo.Above18FeMale = Convert.ToInt32(txtAbove18Female.Text);
        if (txtBelow18FeMale.Text.Trim() != "")
            labouractvo.Below18FeMale = Convert.ToInt32(txtBelow18FeMale.Text);
        if (txtTotalAbove18.Text.Trim() != "")
            labouractvo.TotalAbove18 = Convert.ToInt32(txtTotalAbove18.Text);
        if (txtTotalBelow18.Text.Trim() != "")
            labouractvo.TotalBelow18 = Convert.ToInt32(txtTotalBelow18.Text);


        foreach (GridViewRow gvrow in gvWorkerDtls.Rows)
        {
            LabourWorkPlace workplaceVo = new LabourWorkPlace();
            DropDownList ddlWorkPlace = (DropDownList)gvrow.FindControl("ddlWorkPlace");
            TextBox txtDoorNo = (TextBox)gvrow.FindControl("txtDoorNo");
            TextBox txtLocality = (TextBox)gvrow.FindControl("txtLocality");
            workplaceVo.WorkPlace = ddlWorkPlace.SelectedValue;
            workplaceVo.DoorNo = txtDoorNo.Text.Trim();
            workplaceVo.Locality = txtLocality.Text.Trim();

            lstworkplaceVo.Add(workplaceVo);
        }
        foreach (GridViewRow gvrow in gvFamilyMembersAct1.Rows)
        {
            FamilyMembersAct1 familyMembersActVo = new FamilyMembersAct1();

            DropDownList ddlRelationshipAct1 = (DropDownList)gvrow.FindControl("ddlRelationshipAct1");
            DropDownList ddlFamilyGenderAct1 = (DropDownList)gvrow.FindControl("ddlFamilyGenderAct1");
            DropDownList ddlFamilyAdultAct1 = (DropDownList)gvrow.FindControl("ddlFamilyAdultAct1");
            TextBox txtFamilyNameAct1 = (TextBox)gvrow.FindControl("txtFamilyNameAct1");
            familyMembersActVo.RelationshipAct1 = ddlRelationshipAct1.SelectedValue;
            familyMembersActVo.FamilyNameAct1 = txtFamilyNameAct1.Text;
            familyMembersActVo.GenderAct1 = ddlFamilyGenderAct1.SelectedValue;

            familyMembersActVo.AdultAct1 = ddlFamilyAdultAct1.SelectedValue;

            lstfamilyMembersActVo.Add(familyMembersActVo);
        }
        foreach (GridViewRow gvrow in gvEmployeeNames.Rows)
        {
            EmployeesDetails employeeDetailsVo = new EmployeesDetails();

            DropDownList ddlOccupationAct1 = (DropDownList)gvrow.FindControl("ddlOccupationAct1");
            DropDownList ddlEmployeeGenderAct1 = (DropDownList)gvrow.FindControl("ddlEmployeeGenderAct1");

            TextBox txtEmployeeNameAct1 = (TextBox)gvrow.FindControl("txtEmployeeNameAct1");
            employeeDetailsVo.Occupation = ddlOccupationAct1.SelectedValue;
            employeeDetailsVo.EmployeeNameAct1 = txtEmployeeNameAct1.Text.Trim();
            employeeDetailsVo.EmployeeGenderAct1 = ddlEmployeeGenderAct1.SelectedValue;

            lstemployeeDetailsVo.Add(employeeDetailsVo);
        }
        ///////////////////act2 //////////
        labouractvo.FullNamePerAct2 = txtFullNamePermAct2.Text;
        labouractvo.PerDoorNoAct2 = txtDoorNoPermAct2.Text;
        labouractvo.PerPincode = txtPinCodePermAct2.Text;
        labouractvo.PerDistrict = ddlDistrictPermAct2.SelectedValue;
        labouractvo.PerMandal = ddlMandalPermAct2.SelectedValue;
        labouractvo.PerVillage = ddlVillagePermAct2.SelectedValue;
        labouractvo.CompletionDateAct2 = txtEstDateCompAct2.Text;
        ///////////////////act2 completed //////////
        ///////////////////act3 //////////
        labouractvo.RegActId = ddlSchemAct3.SelectedValue;
        labouractvo.LicenseRegNo = txtRegLicAct3.Text;
        labouractvo.ContractEmployeesAct4 = txtTotalContractors.Text;
       
        ///////////////////act4 //////////


        labouractvo.DirNameAct4 = txtDirFullName.Text;
        labouractvo.DirDoorNoAct4 = txtDirDoorNo.Text;
        labouractvo.DirVillageAct4 = ddlDirVillage.SelectedValue;
        labouractvo.DirMandalAct4 = ddlDirMandal.SelectedValue;
        labouractvo.DirDistrictAct4 = ddlDirDistrict.SelectedValue;
        foreach (GridViewRow gvrow in gvContractorAct4.Rows)
        {
            ContractorDetails ContractorVo = new ContractorDetails();

            TextBox txtContractor = (TextBox)gvrow.FindControl("txtContractorNameAct4");
            TextBox txtAddress = (TextBox)gvrow.FindControl("txtContractorAddressAct4");
            TextBox txtMobileNo = (TextBox)gvrow.FindControl("txtContractorMobileNoAct4");
            TextBox txtWorkNature = (TextBox)gvrow.FindControl("txtContractorNatureAct4");
            TextBox txtNoWorkmen = (TextBox)gvrow.FindControl("txtContractorMaximumNoAct4");
            TextBox txtCommenceDate = (TextBox)gvrow.FindControl("txtContractorCommenceAct4");
            TextBox txtCompleteDate = (TextBox)gvrow.FindControl("txtContractorCompAct4");
            TextBox txtManufacturingDepts = (TextBox)gvrow.FindControl("txtManufacturingDepts");
            ContractorVo.ManufacturingDepts = txtManufacturingDepts.Text;

            ContractorVo.ContractorName = txtContractor.Text;
            ContractorVo.ContractorAddress = txtAddress.Text;
            ContractorVo.ContractorMobileNo = txtMobileNo.Text;
            ContractorVo.ContractorWorkNature = txtWorkNature.Text;
            ContractorVo.ContractorWorkMen = txtNoWorkmen.Text;
            ContractorVo.ContractorCommence = txtCommenceDate.Text;
            ContractorVo.ContractorComplete = txtCompleteDate.Text;

            lstContractorVoAct4.Add(ContractorVo);
        }
        ///////////////////act4 completed //////////
        int valid = Gen.InsertLabourDetails_tourismagentshops(labouractvo, lstworkplaceVo, lstemployeeDetailsVo, lstfamilyMembersActVo, lstContractorVoAct3, lstContractorVoAct4);
        return valid;
        //return 0;
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        string number = "";

        if (hdfFlagID0.Value != "")
        {

            number = hdfpencode.Value;
        }
   
        if (gvWorkerDtls.Visible == true)
        {
            if (gvWorkerDtls.Rows.Count < 2)
            {
                lblmsg0.Text = "<font color='red'>Please enter Worker Details..!</font>";
                lblmsg0.Visible = true;
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }
        if (gvFamilyMembersAct1.Visible == true)
        {
            if (gvFamilyMembersAct1.Rows.Count < 2)
            {
                lblmsg0.Text = "<font color='red'>" + lblmsg0.Text + "," + "</br>Please enter family members of the Employees Details..!</font>";
                lblmsg0.Visible = true;
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }
        if (gvEmployeeNames.Visible == true)
        {
            if (gvEmployeeNames.Rows.Count < 2)
            {
                lblmsg0.Text = "<font color='red'>" + lblmsg0.Text + "," + "</br>Please enter Employees Details..!</font>";
                lblmsg0.Visible = true;
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }
        if (gvContractorAct4.Visible == true)
        {
            if (gvContractorAct4.Rows.Count < 2)
            {
                lblmsg0.Text = "<font color='red'>" + lblmsg0.Text + "," + "</br>Please enter Contractor and migrant workmen Details..!</font>";
                lblmsg0.Visible = true;
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }

        if (trteluguboard.Visible)
        {
            if (LabelTeluguBoard.Text == "")
            {
                FileTeluguBoard.Enabled = true;
                lblmsg0.Text = "<font color='red'>Please Upload Telugu Board Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }
        if (tridproof.Visible)
        {
            if (Labelidproof.Text == "")
            {
                FileUploadidproof.Enabled = true;
                lblmsg0.Text = "<font color='red'>Please Upload Id proof of Employer..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }

        if (trphoto.Visible)
        {
            if (Labelphoto.Text == "")
            {
                FileUploadphoto.Enabled = true;
                lblmsg0.Text = "<font color='red'>Please Upload Passport Size of Employee..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }

        if (trrenetaldeed.Visible)
        {
            if (Labelrenetaldeed.Text == "")
            {
                FileUploadrenetaldeed.Enabled = true;
                lblmsg0.Text = "<font color='red'>Please Upload Rental Deed/Sale Deed/Ownership Proof..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }
        if (ddlEstClassification.SelectedValue == "3" || ddlEstClassification.SelectedValue == "4")
        {
            if (trMemorandum.Visible)
            {
                if (LabelMemorandum.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload Memorandum of Articles..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
            if (trincorportaion.Visible)
            {
                if (Labelincorportaion.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload Certification of Incorporation..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
        }
   
        int totalEmp = 0, Above18Male = 0, Above18Female = 0, Below18Male = 0, Below18Female = 0, totalAbove18Emp = 0, totalBelow18Emp = 0;
        if (txtAbove18Male.Text.Trim() != "")
            Above18Male = Convert.ToInt32(txtAbove18Male.Text.Trim());
        if (txtAbove18Female.Text.Trim() != "")
            Above18Female = Convert.ToInt32(txtAbove18Female.Text.Trim());
        if (txtBelow18Male.Text.Trim() != "")
            Below18Male = Convert.ToInt32(txtBelow18Male.Text.Trim());
        if (txtBelow18FeMale.Text.Trim() != "")
            Below18Female = Convert.ToInt32(txtBelow18FeMale.Text.Trim());

        totalAbove18Emp = Above18Male + Above18Female;
        totalBelow18Emp = Below18Male + Below18Female;
        totalEmp = totalAbove18Emp + totalBelow18Emp;

        if (Convert.ToInt32(txtTotalEmployees.Text.Trim()) != Convert.ToInt32(totalEmp))
        {
            lblmsg0.Text = "<font color='red'>" + lblmsg0.Text + "," + "</br>Total of Adults and Young persons should be equal to total number of Employees..!</font>";
            lblmsg0.Visible = true;
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (btnNext.Text == "Next")
        {
            DataSet ds = new DataSet();
      
            int valid = 0;
            valid = SaveLabourDetails();
            Response.Redirect("frmPaymentTravelAgent.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");

            lblmsg.Text = "<font color='green'>Labour Details Added Successfully..!</font>";
            success.Visible = true;
            Failure.Visible = false;
        }

    }
    protected void btnNext0_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmPaymentTravelAgent.aspx?intApplicationId=" + Session["uid"].ToString() + "&Previous=" + "P");
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmDraftQuestionnaireRegistrationOfTravelAgent.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
    }
    protected void ddlDistrictPermAct2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindMandals(ddlDistrictPermAct2, ddlMandalPermAct2);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void ddlMandalPermAct2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindVillages(ddlMandalPermAct2, ddlVillagePermAct2);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    public void BindRegisteredActs()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlSchemAct3.Items.Clear();
            int QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
            dsd = Gen.getLabourRegisteredActs_tourismagentshops(hdfFlagID0.Value.ToString(), QuestionnaireId);
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlSchemAct3.DataSource = dsd.Tables[0];
                ddlSchemAct3.DataValueField = "Application_Id";
                ddlSchemAct3.DataTextField = "Application_Name";
                ddlSchemAct3.DataBind();
                ddlSchemAct3.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlSchemAct3.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    protected DataTable BindContractorAct3GridAdd()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Contractor_Name");
        dt.Columns.Add("Contractor_Address");
        dt.Columns.Add("Contractor_Work_Nature");
        dt.Columns.Add("Contractor_ManufacturingDepts");
        dt.Columns.Add("Contractor_Est_Commence_Dt");
        dt.Columns.Add("Contractor_MaxWorkers");
        dt.Columns.Add("Contractor_Est_Compltd_Dt");
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
   
    protected void gvContractorAct4_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindContractorGridAdd();

                TextBox txtContractor;
                TextBox txtAddress;
                TextBox txtMobileNo;
                TextBox txtWorkNature;
                TextBox txtNoWorkmen;
                TextBox txtCommenceDate;
                TextBox txtCompleteDate;
                TextBox txtManufacturingDepts;

                String[] arraydata = new String[8];

                int gvrcnt = gvContractorAct4.Rows.Count;

                for (int i = 0; i < gvrcnt; i++)
                {
                    GridViewRow gvr = gvContractorAct4.Rows[i];
                    txtContractor = (TextBox)gvr.FindControl("txtContractorNameAct4");
                    arraydata[0] = txtContractor.Text;
                    txtAddress = (TextBox)gvr.FindControl("txtContractorAddressAct4");
                    arraydata[1] = txtAddress.Text;
                    txtMobileNo = (TextBox)gvr.FindControl("txtContractorMobileNoAct4");
                    arraydata[2] = txtMobileNo.Text;
                    txtWorkNature = (TextBox)gvr.FindControl("txtContractorNatureAct4");
                    arraydata[3] = txtWorkNature.Text;
                    txtNoWorkmen = (TextBox)gvr.FindControl("txtContractorMaximumNoAct4");
                    arraydata[4] = txtNoWorkmen.Text;
                    txtCommenceDate = (TextBox)gvr.FindControl("txtContractorCommenceAct4");
                    arraydata[5] = txtCommenceDate.Text;
                    txtCompleteDate = (TextBox)gvr.FindControl("txtContractorCompAct4");
                    arraydata[6] = txtCompleteDate.Text;
                    txtManufacturingDepts = (TextBox)gvr.FindControl("txtManufacturingDepts");
                    arraydata[7] = txtManufacturingDepts.Text;

                    dt.Rows[i].ItemArray = arraydata;
                    DataRow dRow;
                    dRow = null;
                    dRow = dt.NewRow();
                    dt.Rows.Add(dRow);
                }


                if (valid == 0)
                {
                    ViewState["dtContractorDtls4"] = dt;
                    gvContractorAct4.DataSource = dt;
                    gvContractorAct4.DataBind();
                }
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvContractorAct4.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindContractorGridAdd();
                    String[] arraydata = new String[8];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {

                        if (i != j)
                        {
                            TextBox txtContractor;
                            TextBox txtAddress;
                            TextBox txtMobileNo;
                            TextBox txtWorkNature;
                            TextBox txtNoWorkmen;
                            TextBox txtCommenceDate;
                            TextBox txtCompleteDate;
                            TextBox txtManufacturingDepts;

                            GridViewRow gvr = gvContractorAct4.Rows[i];
                            txtContractor = (TextBox)gvr.FindControl("txtContractorNameAct4");
                            arraydata[0] = txtContractor.Text;
                            txtAddress = (TextBox)gvr.FindControl("txtContractorAddressAct4");
                            arraydata[1] = txtAddress.Text;
                            txtMobileNo = (TextBox)gvr.FindControl("txtContractorMobileNoAct4");
                            arraydata[2] = txtMobileNo.Text;
                            txtWorkNature = (TextBox)gvr.FindControl("txtContractorNatureAct4");
                            arraydata[3] = txtWorkNature.Text;
                            txtNoWorkmen = (TextBox)gvr.FindControl("txtContractorMaximumNoAct4");
                            arraydata[4] = txtNoWorkmen.Text;
                            txtCommenceDate = (TextBox)gvr.FindControl("txtContractorCommenceAct4");
                            arraydata[5] = txtCommenceDate.Text;
                            txtCompleteDate = (TextBox)gvr.FindControl("txtContractorCompAct4");
                            arraydata[6] = txtCompleteDate.Text;
                            txtManufacturingDepts = (TextBox)gvr.FindControl("txtManufacturingDepts");
                            arraydata[7] = txtManufacturingDepts.Text;

                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["dtContractorDtls4"] = dt;
                    gvContractorAct4.DataSource = dt;
                    gvContractorAct4.DataBind();
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
    protected void gvContractorAct4_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)ViewState["dtContractorDtls4"];

                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        GridViewRow gvr = e.Row;
                        TextBox txtContractor = (TextBox)gvr.FindControl("txtContractorNameAct4");
                        TextBox txtAddress = (TextBox)gvr.FindControl("txtContractorAddressAct4");
                        TextBox txtMobileNo = (TextBox)gvr.FindControl("txtContractorMobileNoAct4");
                        TextBox txtWorkNature = (TextBox)gvr.FindControl("txtContractorNatureAct4");
                        TextBox txtNoWorkmen = (TextBox)gvr.FindControl("txtContractorMaximumNoAct4");
                        TextBox txtCommenceDate = (TextBox)gvr.FindControl("txtContractorCommenceAct4");
                        TextBox txtCompleteDate = (TextBox)gvr.FindControl("txtContractorCompAct4");
                        TextBox txtManufacturingDepts = (TextBox)gvr.FindControl("txtManufacturingDepts");

                        txtContractor.Text = dt.Rows[e.Row.RowIndex]["Contractor_Name"].ToString();
                        txtAddress.Text = dt.Rows[e.Row.RowIndex]["Contractor_Address"].ToString();
                        txtMobileNo.Text = dt.Rows[e.Row.RowIndex]["Contractor_MobileNo"].ToString();
                        txtWorkNature.Text = dt.Rows[e.Row.RowIndex]["Contractor_Work_Nature"].ToString();
                        txtNoWorkmen.Text = dt.Rows[e.Row.RowIndex]["Contractor_MaxWorkers"].ToString();
                   
                        if (dt.Rows[e.Row.RowIndex]["Contractor_Est_Commence_Dt"].ToString() != null && dt.Rows[e.Row.RowIndex]["Contractor_Est_Commence_Dt"].ToString() != "")
                        {
                            txtCommenceDate.Text = Convert.ToDateTime(dt.Rows[e.Row.RowIndex]["Contractor_Est_Commence_Dt"].ToString()).ToString("yyyy-MM-dd");
                        }
                        if (dt.Rows[e.Row.RowIndex]["Contractor_Est_Compltd_Dt"].ToString() != null && dt.Rows[e.Row.RowIndex]["Contractor_Est_Compltd_Dt"].ToString() != "")
                        {
                            txtCompleteDate.Text = Convert.ToDateTime(dt.Rows[e.Row.RowIndex]["Contractor_Est_Compltd_Dt"].ToString()).ToString("yyyy-MM-dd");
                        }
                        txtManufacturingDepts.Text = dt.Rows[e.Row.RowIndex]["Contractor_ManufacturingDepts"].ToString();

                        if (txtNoWorkmen.Text.Trim() != "")
                        {
                            totalContractEmployees = totalContractEmployees + Convert.ToInt32(txtNoWorkmen.Text.Trim());
                        }
                    }
                }
                txtTotalContractors.Text = totalContractEmployees.ToString();
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void ddlDirDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindMandals(ddlDirDistrict, ddlDirMandal);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected DataTable BindContractorGridAdd()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Contractor_Name");
        dt.Columns.Add("Contractor_Address");
        dt.Columns.Add("Contractor_MobileNo");
        dt.Columns.Add("Contractor_Work_Nature");
        dt.Columns.Add("Contractor_MaxWorkers");
        dt.Columns.Add("Contractor_Est_Commence_Dt");
        dt.Columns.Add("Contractor_Est_Compltd_Dt");
        dt.Columns.Add("Contractor_ManufacturingDepts");
        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";
        dr[2] = "";
        dr[3] = "";
        dr[4] = "";
        dr[5] = "";
        dr[6] = "";
        dr[7] = "";

        dt.Rows.Add(dr);
        return dt;
    }
    protected void ddlDirMandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindVillages(ddlDirMandal, ddlDirVillage);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void ddlSchemAct3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected DataTable BindContractorGridAct3()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Contractor_Name");

        DataRow dr = dt.NewRow();
        dr[0] = "";

        dt.Rows.Add(dr);
        return dt;
    }
    protected void GetTotalWorkMan(object sender, EventArgs e)
    {
        GridViewRow gvrow = (GridViewRow)((TextBox)sender).Parent.Parent;
        TextBox txtContractorMaximumNoAct4 = (TextBox)gvrow.FindControl("txtContractorMaximumNoAct4");
        int gvrcnt = gvContractorAct4.Rows.Count;

        for (int i = 0; i < gvrcnt; i++)
        {
            GridViewRow gvr = gvContractorAct4.Rows[i];
            TextBox txtNoWorkmen;

            txtNoWorkmen = (TextBox)gvr.FindControl("txtContractorMaximumNoAct4");
            if (txtNoWorkmen.Text.Trim() != "")
            {
                totalContractEmployees = totalContractEmployees + Convert.ToInt32(txtNoWorkmen.Text.Trim());
            }
        }
        txtTotalContractors.Text = totalContractEmployees.ToString();
    }

    protected void btnsubmitform_Click(object sender, EventArgs e)
    {
        int valid = 0;
        valid = SaveLabourDetails();
        string intApprovalid = Request.QueryString["intApprovalid"].ToString();
        Callwebservice(intApprovalid);
        lblmsg.Text = "<font color='green'>Labour Details Added Successfully..!</font>";
        success.Visible = true;
        Failure.Visible = false;
    }
    public void Callwebservice(string deptid)
    {
        LabourQueryResponseCFO.TSLabourServiceImplService labourserviceCfo = new LabourQueryResponseCFO.TSLabourServiceImplService();
        string UIDNO = "";
        DataSet dsdatanew = new DataSet();
        dsdatanew = (DataSet)Session["dscheck"];
        if (dsdatanew != null && dsdatanew.Tables.Count > 1 && dsdatanew.Tables[1].Rows.Count > 0)
        {
            UIDNO = dsdatanew.Tables[1].Rows[0]["UID_No"].ToString();
        }

        if (deptid == "113") //shops and establishment
        {
            DataSet dsdept = new DataSet();
            DataSet dsdeptattachments = new DataSet();
            dsdept = Gen.getdepartmentdetailsonuid_tourismagentshops(UIDNO, deptid);

            LabourQueryResponseCFO.act labouract = new LabourQueryResponseCFO.act();
            LabourQueryResponseCFO.actsResponse labourout = new LabourQueryResponseCFO.actsResponse();

            LabourQueryResponseCFO.shopsEstRegistrations shopactobjnew = new LabourQueryResponseCFO.shopsEstRegistrations();

            string actids = "";
            string actid = "";
            if(dsdept!=null)
            {
                if(dsdept.Tables.Count>0)
                {
                     if(dsdept.Tables[0].Rows.Count>0)
                     {
                
            actids = dsdept.Tables[0].Rows[0]["LabourAct_Id"].ToString();
            string[] split = actids.Split(',');
            if (actids.Contains("1"))//The Buildings & Other Construction Workers Act
            {
                labouract.shopRegistrationActSelected = true;
                shopactobjnew.actID = "SEF";
                shopactobjnew.date_commencement = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();   
                shopactobjnew.establishment_name = dsdept.Tables[0].Rows[0]["NAME"].ToString();       
                shopactobjnew.establishment_postal_district = dsdept.Tables[0].Rows[0]["Form1_Estd_District"].ToString();
                shopactobjnew.establishment_postal_door = dsdept.Tables[0].Rows[0]["Form1_Estd_DoorNo"].ToString();
                shopactobjnew.establishment_postal_locality = dsdept.Tables[0].Rows[0]["Form1_Estd_Locality"].ToString();
                shopactobjnew.establishment_postal_mandal = dsdept.Tables[0].Rows[0]["Form1_Estd_Mandal"].ToString();
                shopactobjnew.establishment_postal_pincode = dsdept.Tables[0].Rows[0]["Form1_Estd_PinCode"].ToString();
                shopactobjnew.establishment_postal_village = dsdept.Tables[0].Rows[0]["Form1_Estd_Village"].ToString();
                shopactobjnew.manager_agent_designation = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Designation"].ToString();
                shopactobjnew.manager_agent_district = dsdept.Tables[0].Rows[0]["Form1_1_Manager_District"].ToString();
                shopactobjnew.manager_agent_door = dsdept.Tables[0].Rows[0]["Form1_1_Manager_DoorNo"].ToString();
                shopactobjnew.manager_agent_email = dsdept.Tables[0].Rows[0]["Form1_Manager_EMail"].ToString();
                shopactobjnew.manager_agent_fathername = dsdept.Tables[0].Rows[0]["Form1_1_Manager_FatherName"].ToString();
                shopactobjnew.manager_agent_mandal = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Mandal"].ToString();
                shopactobjnew.manager_agent_mobile = dsdept.Tables[0].Rows[0]["Form1_Manager_MobileNo"].ToString();
                shopactobjnew.manager_agent_name = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Name"].ToString();
                shopactobjnew.manager_agent_street = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Locality"].ToString();
                shopactobjnew.manager_agent_village = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Village"].ToString();
                shopactobjnew.nature_work = dsdept.Tables[0].Rows[0]["Form1_Nature_of_Business"].ToString();  
                shopactobjnew.projectSubmitDate = dsdept.Tables[0].Rows[0]["projectSubmitDate"].ToString();             
                shopactobjnew.stageID = dsdept.Tables[0].Rows[0]["stageID"].ToString();   
                shopactobjnew.uID = dsdept.Tables[0].Rows[0]["UID_NO"].ToString();  
                shopactobjnew.establishment_category = "1";
                shopactobjnew.establishment_classification = "1";
                LabourQueryResponseCFO.shopActsWorkPlaceMultiData[] shopactobj = null;

                if (dsdept.Tables[1].Rows.Count > 0)
                {
                    DataTable dtraw = new DataTable();
                    dtraw = dsdept.Tables[1];
                    shopactobj = new LabourQueryResponseCFO.shopActsWorkPlaceMultiData[dtraw.Rows.Count];

                    for (int k = 0; k < dtraw.Rows.Count; k++)
                    {
                        LabourQueryResponseCFO.shopActsWorkPlaceMultiData workplacevo = new LabourQueryResponseCFO.shopActsWorkPlaceMultiData();
                        workplacevo.workPlacedoorNo = dtraw.Rows[k]["Door_No"].ToString();
                        workplacevo.workPlacelocality = dtraw.Rows[k]["Locality"].ToString();
                        workplacevo.workPlaceType = dtraw.Rows[k]["Work_Place"].ToString();
                        shopactobj[k] = workplacevo;
                    }
                    shopactobjnew.workPlaceDetails = shopactobj;
                }

                LabourQueryResponseCFO.shopActsEmployeesMultiData[] shopactobj1 = null;
                if (dsdept.Tables[2].Rows.Count > 0)
                {
                    DataTable dtraw2 = new DataTable();
                    dtraw2 = dsdept.Tables[2];
                    shopactobj1 = new LabourQueryResponseCFO.shopActsEmployeesMultiData[dtraw2.Rows.Count];

                    for (int k = 0; k < dtraw2.Rows.Count; k++)
                    {
                        LabourQueryResponseCFO.shopActsEmployeesMultiData workplacevo1 = new LabourQueryResponseCFO.shopActsEmployeesMultiData();
                        workplacevo1.employeeGender = dtraw2.Rows[k]["Gender"].ToString();
                        workplacevo1.employeeName = dtraw2.Rows[k]["Name"].ToString();
                        workplacevo1.employeeOccupation = dtraw2.Rows[k]["Occupation"].ToString();
                        shopactobj1[k] = workplacevo1;
                    }
                    shopactobjnew.employeesDetails = shopactobj1;
                }


                LabourQueryResponseCFO.shopActsFamilyMultiData[] shopactobj3 = null;

                if (dsdept.Tables[3].Rows.Count > 0)
                {
                    DataTable dtraw3 = new DataTable();
                    dtraw3 = dsdept.Tables[3];
                    shopactobj3 = new LabourQueryResponseCFO.shopActsFamilyMultiData[dtraw3.Rows.Count];

                    for (int k = 0; k < dtraw3.Rows.Count; k++)
                    {
                        LabourQueryResponseCFO.shopActsFamilyMultiData workplacevo3 = new LabourQueryResponseCFO.shopActsFamilyMultiData();
                        workplacevo3.familyMemberAdultYoung = dtraw3.Rows[k]["Adult_Flag"].ToString();
                        workplacevo3.familyMemberGender = dtraw3.Rows[k]["Gender"].ToString();
                        workplacevo3.familyMemberRelationship = dtraw3.Rows[k]["RelationShip"].ToString();
                        workplacevo3.familyMemeberName = dtraw3.Rows[k]["Name"].ToString();
                        shopactobj3[k] = workplacevo3;
                    }
                    shopactobjnew.familyDetails = shopactobj3;
                }

            }
        }
    }
                DataSet dsdeptattachmentslabour = new DataSet();
                dsdeptattachmentslabour = Gen.getattachmentdetailsonuid_tourismagentshops(UIDNO, "113", "");
                if (dsdeptattachmentslabour != null && dsdeptattachmentslabour.Tables.Count > 0 && dsdeptattachmentslabour.Tables[0].Rows.Count > 0)
                {
                    if (dsdeptattachmentslabour.Tables[0].Rows.Count > 0)
                    {
                        shopactobjnew.employees_proof = dsdeptattachmentslabour.Tables[0].Rows[0]["Filepath"].ToString();
                    }
                    if (dsdeptattachmentslabour.Tables[1].Rows.Count > 0)
                    {
                        shopactobjnew.address_proof = dsdeptattachmentslabour.Tables[1].Rows[0]["Filepath"].ToString();
                    }
                    if (dsdeptattachmentslabour.Tables[2].Rows.Count > 0)
                    {
                        shopactobjnew.authorise_letter_proof = dsdeptattachmentslabour.Tables[2].Rows[0]["Filepath"].ToString();
                    }
                    if (dsdeptattachmentslabour.Tables[3].Rows.Count > 0)
                    {
                        shopactobjnew.certificate_incorporation_proof = dsdeptattachmentslabour.Tables[3].Rows[0]["Filepath"].ToString();
                    }
                }
                labouract.shopRegistrationActData = shopactobjnew;
                labourout = labourserviceCfo.actSelected(labouract);

                if (labourout.status == "SUCCESS")
                {
                    string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                    updatequerystringcfo(Request.QueryString["Queryid"].ToString());
                }
                else
                {
                    string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                }
            }
        }
       
    }

    public void updatequerystringcfo(string Applicantid)
    {
        DataSet ds = new DataSet();
        string intEnterpreniourApprovalid = "", intQuessionaireid = "", intCFEEnterpid = "", intDeptid = "", intApprovalid = "", QueryRaiseDate = "", QueryDescription = "", QueryStatus = "", Created_by = "", Created_dt = "";
        try
        {
            ds = Gen.GetQueryStatusByTransactionID_tourismagentshops(Applicantid);

            if (ds.Tables[0].Rows.Count > 0)
            {
                intEnterpreniourApprovalid = ds.Tables[0].Rows[0]["intEnterpreniourApprovalid"].ToString().Trim();
                intQuessionaireid = ds.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
                intCFEEnterpid = ds.Tables[0].Rows[0]["intCFOEnterpid"].ToString().Trim();
                intDeptid = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
                intApprovalid = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                QueryRaiseDate = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                QueryDescription = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();
                QueryStatus = ds.Tables[0].Rows[0]["QueryStatus"].ToString().Trim();
                Created_by = ds.Tables[0].Rows[0]["Created_by"].ToString().Trim();
                Created_dt = ds.Tables[0].Rows[0]["Created_dt"].ToString().Trim();

                int result = 0;

                result = Gen.InsertQueryDetails_tourismagentshops(intEnterpreniourApprovalid, intQuessionaireid, intCFEEnterpid, intDeptid, intApprovalid, QueryRaiseDate, QueryDescription, QueryStatus, "", "", "", "", Created_by, "", "", "", getclientIP());
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
    public static string getclientIP()
    {
        string result = string.Empty;
        string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (!string.IsNullOrEmpty(ip))
        {
            string[] ipRange = ip.Split(',');
            int le = ipRange.Length - 1;
            result = ipRange[0];
        }
        else
        {
            result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        return result;
    }
    protected void BtnTeluguBoard_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\TravelAgent");

        
        if (FileTeluguBoard.HasFile)
        {
            if ((FileTeluguBoard.PostedFile != null) && (FileTeluguBoard.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileTeluguBoard.PostedFile.FileName);
                try
                {

                    string[] fileType = FileTeluguBoard.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\TeluguBoard");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileTeluguBoard.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileTeluguBoard.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = Gen.InsertCFOAttachement_tourismagentshops(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "TeluguBoard");


                        if (result > 0)
                        {
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblTeluguBoard.Text = FileTeluguBoard.FileName;
                            LabelTeluguBoard.Text = FileTeluguBoard.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }

                }
                catch (Exception)//in case of an error
                {
                    DeleteFile(newPath + "\\" + sFileName);
                }
            }
        }
        else
        {
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
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

    protected void btnidproof_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\TravelAgent");

        
        if (FileUploadidproof.HasFile)
        {
            if ((FileUploadidproof.PostedFile != null) && (FileUploadidproof.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadidproof.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadidproof.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\IDProofEmployer");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadidproof.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadidproof.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = Gen.InsertCFOAttachement_tourismagentshops(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "IDProofEmployer");


                        if (result > 0)
                        {
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLinkidproof.Text = FileUploadidproof.FileName;
                            Labelidproof.Text = FileUploadidproof.FileName;
                            success.Visible = true;
                            Failure.Visible = false;
                            // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            //fillNews(userid);
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                            // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Upload PDF only..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                    }

                }
                catch (Exception)//in case of an error
                {
                    //lblError.Visible = true;
                    //lblError.Text = "An Error Occured. Please Try Again!";
                    DeleteFile(newPath + "\\" + sFileName);
                    // DeleteFile(sFileDir + sFileName);
                }
            }
        }
        else
        {
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }
    protected void btnphoto_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\TravelAgent");

        
        if (FileUploadphoto.HasFile)
        {
            if ((FileUploadphoto.PostedFile != null) && (FileUploadphoto.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadphoto.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadphoto.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\PassportSizePhoto");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadphoto.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadphoto.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = Gen.InsertCFOAttachement_tourismagentshops(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "PassportSizePhoto");


                        if (result > 0)
                        {
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLinkphoto.Text = FileUploadphoto.FileName;
                            Labelphoto.Text = FileUploadphoto.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF only..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }

                }
                catch (Exception)//in case of an error
                {
                    DeleteFile(newPath + "\\" + sFileName);
                }
            }
        }
        else
        {
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
        }
    }
    protected void btnrenetaldeed_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\TravelAgent");

        
        if (FileUploadrenetaldeed.HasFile)
        {
            if ((FileUploadrenetaldeed.PostedFile != null) && (FileUploadrenetaldeed.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadrenetaldeed.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadrenetaldeed.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\RentalSaleDeed");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadrenetaldeed.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadrenetaldeed.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = Gen.InsertCFOAttachement_tourismagentshops(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "RentalSaleDeed");


                        if (result > 0)
                        {
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLinkrenetaldeed.Text = FileUploadrenetaldeed.FileName;
                            Labelrenetaldeed.Text = FileUploadrenetaldeed.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF only..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }

                }
                catch (Exception)//in case of an error
                {
                    DeleteFile(newPath + "\\" + sFileName);
                }
            }
        }
        else
        {
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
        }
    }
    protected void btnMemorandum_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\TravelAgent");

        
        if (FileUploadMemorandum.HasFile)
        {
            if ((FileUploadMemorandum.PostedFile != null) && (FileUploadMemorandum.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadMemorandum.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadMemorandum.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\MemorandumofArticle");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadMemorandum.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadMemorandum.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = Gen.InsertCFOAttachement_tourismagentshops(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "MemorandumofArticle");


                        if (result > 0)
                        {
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLinkMemorandum.Text = FileUploadMemorandum.FileName;
                            LabelMemorandum.Text = FileUploadMemorandum.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF only..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }

                }
                catch (Exception)//in case of an error
                {
                    DeleteFile(newPath + "\\" + sFileName);
                }
            }
        }
        else
        {
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
        }
    }

    protected void ddlEstClassification_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlEstClassification.SelectedValue == "3" || ddlEstClassification.SelectedValue == "4")
            {
                trMemorandum.Visible = true;
                trincorportaion.Visible = true;
            }
            else
            {
                trMemorandum.Visible = false;
                trincorportaion.Visible = false;
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnincorportaion_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\TravelAgent");

        
        if (FileUploadincorportaion.HasFile)
        {
            if ((FileUploadincorportaion.PostedFile != null) && (FileUploadincorportaion.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadincorportaion.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadincorportaion.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\Incorporation");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadincorportaion.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadincorportaion.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = Gen.InsertCFOAttachement_tourismagentshops(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "Incorporation");


                        if (result > 0)
                        {
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLinkincorportaion.Text = FileUploadincorportaion.FileName;
                            Labelincorportaion.Text = FileUploadincorportaion.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF only..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }

                }
                catch (Exception)//in case of an error
                {
                    DeleteFile(newPath + "\\" + sFileName);
                }
            }
        }
        else
        {
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
        }
    }

}