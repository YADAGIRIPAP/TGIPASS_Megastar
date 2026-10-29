using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UI_TSiPASS_frmLabourDetails_Act4 : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    List<ContractorDetails> lstContractorVo = new List<ContractorDetails>();
    int totalContractEmployees = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("~/Index.aspx");
            }
            if (!IsPostBack)
            {


                DataSet dscheck = new DataSet();
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

                dsver = Gen.GetverifyofqueLabour(Session["Applid"].ToString());

                if (dsver.Tables[0].Rows.Count > 0)
                {
                    string res = Gen.RetriveStatus(Session["Applid"].ToString());
                    ////string res = Gen.RetriveStatus("1002");


                    if (res == "3" || Convert.ToInt32(res) >= 3)
                    {
                        ResetFormControl(this);
                    }

                }
                DataSet dsCategory = new DataSet();

                dsCategory = Gen.GetLabourActCategoryMaster();
                if (dsCategory != null && dsCategory.Tables.Count > 0 && dsCategory.Tables[0].Rows.Count > 0)
                {
                    ddlCatEstbAct4.DataSource = dsCategory.Tables[0];
                    ddlCatEstbAct4.DataTextField = "Category_Desc";
                    ddlCatEstbAct4.DataValueField = "Category_Id";
                    ddlCatEstbAct4.DataBind();
                }
                AddSelect(ddlCatEstbAct4);

                gvContractorAct4.DataSource = BindContractorGridAdd();
                gvContractorAct4.DataBind();

                BindDistricts(ddlDirDistrict);
                BindDistricts(ddlMgrDistrict);
                BindDistricts(ddlDistrictEstbAct4);
                BindDistricts(ddlDistrictPermAct4);
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
    protected void btnNext_Click(object sender, EventArgs e)
    {
        string number = "";

        if (hdfFlagID0.Value != "")
        {

            number = hdfpencode.Value;
        }

        if (btnNext.Text == "Next")
        {
            DataSet ds = new DataSet();
            //Response.Write(hdfFlagID0.Value.ToString());
            //return;
            //ds = Gen.GetdataofPowerenterprenuer(hdfFlagID0.Value.ToString());

            int valid = 0;
            valid = SaveLabourDetails();

            Response.Redirect("frmAttachmentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
            //ResetFormControl(this);
            lblmsg.Text = "<font color='green'>Labour Details Added Successfully..!</font>";
            //this.Clear();
            success.Visible = true;
            Failure.Visible = false;
            // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
            //fillNews(userid);

        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmLabourDetails_Act4.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
    }
    protected void btnNext0_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmPCBDetails.aspx?intApplicationId=" + hdfFlagID0.Value + "&Previous=" + "P");
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int valid = 0;
            valid = SaveLabourDetails();
            lblmsg.Text = "<font color='green'>Labour Details Added Successfully..!</font>";
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
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

                String[] arraydata = new String[7];

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

                    dt.Rows[i].ItemArray = arraydata;
                    DataRow dRow;
                    dRow = null;
                    dRow = dt.NewRow();
                    dt.Rows.Add(dRow);
                }


                if (valid == 0)
                {
                    ViewState["dtContractorDtls"] = dt;
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
                    String[] arraydata = new String[7];

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

                            if (j == 0)
                                dt.Rows[i - 1].ItemArray = arraydata;
                            else
                                dt.Rows[i].ItemArray = arraydata;


                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);
                        }
                    }
                    dt.Rows.RemoveAt(i - 1);
                    ViewState["dtContractorDtls"] = dt;
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
                DataTable dt = (DataTable)ViewState["dtContractorDtls"];

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

                        txtContractor.Text = dt.Rows[e.Row.RowIndex]["Contractor_Name"].ToString();
                        txtAddress.Text = dt.Rows[e.Row.RowIndex]["Contractor_Address"].ToString();
                        txtMobileNo.Text = dt.Rows[e.Row.RowIndex]["Contractor_MobileNo"].ToString();
                        txtWorkNature.Text = dt.Rows[e.Row.RowIndex]["Contractor_Work_Nature"].ToString();
                        txtNoWorkmen.Text = dt.Rows[e.Row.RowIndex]["Contractor_MaxWorkers"].ToString();
                        txtCommenceDate.Text = dt.Rows[e.Row.RowIndex]["Contractor_Est_Commence_Dt"].ToString();
                        txtCompleteDate.Text = dt.Rows[e.Row.RowIndex]["Contractor_Est_Compltd_Dt"].ToString();

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
    public void BindDistricts(DropDownList ddlDistrict)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlDistrict.Items.Clear();
            dsd = Gen.GetDistrictsWithoutHYD();
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
    protected void ddlDistrictEstbAct4_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindMandals(ddlDistrictEstbAct4, ddlMandalEstbAct4);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void ddlMandalEstbAct4_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindVillages(ddlMandalEstbAct4, ddlVillageEstbAct4);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void ddlDistrictPermAct4_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindMandals(ddlDistrictPermAct4, ddlMandalPermAct4);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void ddlMandalPermAct4_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindVillages(ddlMandalPermAct4, ddlVillagePermAct4);
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
    protected void ddlMgrDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindMandals(ddlMgrDistrict, ddlMgrMandal);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void ddlMgrMandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindVillages(ddlMgrMandal, ddlMgrVillage);
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
    private int SaveLabourDetails()
    {
        LabourActVO labouractvo = new LabourActVO();

        labouractvo.QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
        labouractvo.intCFEEnterpid = Convert.ToInt32(Request.QueryString[0].ToString());
        labouractvo.CategoryofEstablishment = ddlCatEstbAct4.SelectedValue;
        labouractvo.NameofShopAct1 = txtEstbName.Text;
        labouractvo.EstdLocation = txtEstbLoc.Text;
        labouractvo.CreatedBy = Convert.ToInt32(Session["uid"].ToString().Trim());

        labouractvo.EstdDoorNo = txtEstdDoorNoEstbAct4.Text;
        labouractvo.EstdDistrict = ddlDistrictEstbAct4.SelectedValue;
        labouractvo.EstdMandal = ddlMandalEstbAct4.SelectedValue;
        labouractvo.EstdVillage = ddlVillageEstbAct4.SelectedValue;

        labouractvo.FullNamePrincipalAct4 = txtFullNamePermAct4.Text;
        labouractvo.FatherNamePrincipalAct4 = txtFatherNamePermAct4.Text;
        labouractvo.MobileNoPrincipalAct4 = txtMobileNoPermAct4.Text;
        labouractvo.EmailIdPrincipalAct4 = txtEmailPermAct4.Text;
        labouractvo.DoorNoPrincipalAct4 = txtDoorNoPermAct4.Text;
        labouractvo.VillagePrincipalAct4 = ddlVillagePermAct4.SelectedValue;
        labouractvo.MandalPrincipalAct4 = ddlMandalPermAct4.SelectedValue;
        labouractvo.DistrictPrincipalAct4 = ddlDistrictPermAct4.SelectedValue;

        labouractvo.DirNameAct4 = txtDirFullName.Text;
        labouractvo.DirDoorNoAct4 = txtDirDoorNo.Text;
        labouractvo.DirVillageAct4 = ddlDirVillage.SelectedValue;
        labouractvo.DirMandalAct4 = ddlDirMandal.SelectedValue;
        labouractvo.DirDistrictAct4 = ddlDirDistrict.SelectedValue;

        labouractvo.ManagerFullNameAct4 = txtManagerFullName.Text;
        labouractvo.ManagerDoorNoAct4 = txtMgrDoorNo.Text;
        labouractvo.ManagerDistrictAct4 = ddlMgrDistrict.SelectedValue;
        labouractvo.ManagerMandalAct4 = ddlMgrMandal.SelectedValue;
        labouractvo.ManagerVillageAct4 = ddlMgrVillage.SelectedValue;

        labouractvo.NatureofBusinessAct4 = txtNatureofWorkAct4.Text;
        labouractvo.ContractEmployeesAct4 = txtTotalContractors.Text;

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

            ContractorVo.ContractorName = txtContractor.Text;
            ContractorVo.ContractorAddress = txtAddress.Text;
            ContractorVo.ContractorMobileNo = txtMobileNo.Text;
            ContractorVo.ContractorWorkNature = txtWorkNature.Text;
            ContractorVo.ContractorWorkMen = txtNoWorkmen.Text;
            ContractorVo.ContractorCommence = txtCommenceDate.Text;
            ContractorVo.ContractorComplete = txtCompleteDate.Text;

            lstContractorVo.Add(ContractorVo);
        }

        int valid = Gen.InsertLabourDetailsAct4(labouractvo, lstContractorVo);
        return valid;
    }
    void FillDetails()
    {

        hdfFlagID.Value = "1";
        DataSet ds = new DataSet();

        try
        {
            int QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
            ds = Gen.getLabourDetails(hdfFlagID0.Value.ToString(), QuestionnaireId);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtEstbName.Text = ds.Tables[0].Rows[0]["Form1_Estb_Name"].ToString();
                txtEstbLoc.Text = ds.Tables[0].Rows[0]["Form1_Location"].ToString();
                ddlCatEstbAct4.SelectedValue = ds.Tables[0].Rows[0]["Form1_1_Estb_Category"].ToString();

                txtEstdDoorNoEstbAct4.Text = ds.Tables[0].Rows[0]["Form1_Estd_DoorNo"].ToString();

                ddlDistrictEstbAct4.SelectedValue = ds.Tables[0].Rows[0]["Form1_Estd_District"].ToString();
                ddlDistrictEstbAct4_SelectedIndexChanged(this, EventArgs.Empty);

                ddlMandalEstbAct4.SelectedValue = ds.Tables[0].Rows[0]["Form1_Estd_Mandal"].ToString();
                ddlMandalEstbAct4_SelectedIndexChanged(this, EventArgs.Empty);

                ddlVillageEstbAct4.SelectedValue = ds.Tables[0].Rows[0]["Form1_Estd_Village"].ToString();
                txtFullNamePermAct4.Text = ds.Tables[0].Rows[0]["Form1_Employer_Name"].ToString();
                txtFatherNamePermAct4.Text = ds.Tables[0].Rows[0]["Form1_Empolyer_FatherName"].ToString();
                txtMobileNoPermAct4.Text = ds.Tables[0].Rows[0]["Form1_Employer_MobileNo"].ToString();
                txtEmailPermAct4.Text = ds.Tables[0].Rows[0]["Form1_Employer_EmailID"].ToString();
                txtDoorNoPermAct4.Text = ds.Tables[0].Rows[0]["Form1_Employer_DoorNo"].ToString();

                ddlDistrictPermAct4.SelectedValue = ds.Tables[0].Rows[0]["Form1_Employer_District"].ToString();
                ddlDistrictPermAct4_SelectedIndexChanged(this, EventArgs.Empty);

                ddlMandalPermAct4.SelectedValue = ds.Tables[0].Rows[0]["Form1_Employer_Mandal"].ToString();
                ddlMandalPermAct4_SelectedIndexChanged(this, EventArgs.Empty);

                ddlVillagePermAct4.SelectedValue = ds.Tables[0].Rows[0]["Form1_Employer_Village"].ToString();
                txtDirFullName.Text = ds.Tables[0].Rows[0]["Form1_4_Dir_FullName"].ToString();
                txtDirDoorNo.Text = ds.Tables[0].Rows[0]["Form1_4_Dir_DoorNo"].ToString();

                ddlDirDistrict.SelectedValue = ds.Tables[0].Rows[0]["Form1_4_Dir_District"].ToString();
                ddlDirDistrict_SelectedIndexChanged(this, EventArgs.Empty);

                ddlDirMandal.SelectedValue = ds.Tables[0].Rows[0]["Form1_4_Dir_Mandal"].ToString();
                ddlDirMandal_SelectedIndexChanged(this, EventArgs.Empty);

                ddlDirVillage.SelectedValue = ds.Tables[0].Rows[0]["Form1_4_Dir_Village"].ToString();
                txtManagerFullName.Text = ds.Tables[0].Rows[0]["Form1_Manager_Name"].ToString();
                txtMgrDoorNo.Text = ds.Tables[0].Rows[0]["Form1_Manager_DoorNo"].ToString();

                ddlMgrDistrict.SelectedValue = ds.Tables[0].Rows[0]["Form1_Manager_District"].ToString();
                ddlMgrDistrict_SelectedIndexChanged(this, EventArgs.Empty);

                ddlMgrMandal.SelectedValue = ds.Tables[0].Rows[0]["Form1_Manager_Mandal"].ToString();
                ddlMgrMandal_SelectedIndexChanged(this, EventArgs.Empty);

                ddlMgrVillage.SelectedValue = ds.Tables[0].Rows[0]["Form1_Manager_Village"].ToString();
                txtNatureofWorkAct4.Text = ds.Tables[0].Rows[0]["Form1_Nature_of_Business"].ToString();


                //ddlEstClassification.SelectedValue = ds.Tables[0].Rows[0]["Form1_1_Estb_Classification"].ToString();


            }
            if (ds.Tables.Count > 1 && ds.Tables[4].Rows.Count > 0)
            {
                ViewState["dtContractorDtls"] = ds.Tables[4];

                gvContractorAct4.DataSource = ds.Tables[4];
                gvContractorAct4.DataBind();
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
}