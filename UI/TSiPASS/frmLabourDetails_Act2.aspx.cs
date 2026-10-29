using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UI_TSiPASS_frmLabourDetails_Act2 : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
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


            }

            if (!IsPostBack)
            {

                BindDistricts(ddlDistrictEstbAct2);
                BindDistricts(ddlDistrictPermAct2);
                BindDistricts(ddlDistrictManagerAct2);

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
                //ds.Tables[0].Rows[0][""].ToString();
                txtEstbName.Text = ds.Tables[0].Rows[0]["Form1_2_Name"].ToString();
                txtEstbLoc.Text = ds.Tables[0].Rows[0]["Form1_Location"].ToString();
                ddlDistrictEstbAct2.SelectedValue = ds.Tables[0].Rows[0]["Form1_Estd_District"].ToString();
                ddlDistrictEstbAct2_SelectedIndexChanged(this, EventArgs.Empty);
                ddlMandalEstbAct2.SelectedValue = ds.Tables[0].Rows[0]["Form1_Estd_Mandal"].ToString();
                ddlMandalEstbAct2_SelectedIndexChanged(this, EventArgs.Empty);
                ddlVillageEstbAct2.SelectedValue = ds.Tables[0].Rows[0]["Form1_Estd_Village"].ToString();
                txtEstdDoorNoEstbAct2.Text = ds.Tables[0].Rows[0]["Form1_Estd_DoorNo"].ToString();
                txtPincodeEstdAct2.Text = ds.Tables[0].Rows[0]["Form1_Estd_PinCode"].ToString();
                txtFullNamePermAct2.Text = ds.Tables[0].Rows[0]["Form1_2_FullName"].ToString();

                txtDoorNoPermAct2.Text = ds.Tables[0].Rows[0]["Form1_2_Per_DoorNo"].ToString();
                txtPinCodePermAct2.Text = ds.Tables[0].Rows[0]["Form1_2_Per_PinCode"].ToString();
                ddlDistrictPermAct2.SelectedValue = ds.Tables[0].Rows[0]["Form1_2_Per_District"].ToString();
                ddlDistrictPermAct2_SelectedIndexChanged(this, EventArgs.Empty);
                ddlMandalPermAct2.SelectedValue = ds.Tables[0].Rows[0]["Form1_2_Per_Mandal"].ToString();
                ddlMandalPermAct2_SelectedIndexChanged(this, EventArgs.Empty);
                ddlVillagePermAct2.SelectedValue = ds.Tables[0].Rows[0]["Form1_2_Per_Village"].ToString();

                txtFullNameManagerAct2.Text = ds.Tables[0].Rows[0]["Form1_Manager_Name"].ToString();
                txtMobileNoManagerAct2.Text = ds.Tables[0].Rows[0]["Form1_Manager_MobileNo"].ToString();
                txtEmailManagerAct2.Text = ds.Tables[0].Rows[0]["Form1_Manager_EMail"].ToString();
                txtStreetManagerAct2.Text = ds.Tables[0].Rows[0]["Form1_Manager_Street"].ToString();
                txtDoorNoManagerAct2.Text = ds.Tables[0].Rows[0]["Form1_Manager_DoorNo"].ToString();
                txtNatureofWorkAct2.Text = ds.Tables[0].Rows[0]["Form1_Nature_of_Business"].ToString();
                txtMaxWorkersAct2.Text = ds.Tables[0].Rows[0]["Form1_2_MaxWorkers"].ToString();
                txtEstDateCommAct2.Text = ds.Tables[0].Rows[0]["Form1_2_Est_Commence_Dt"].ToString();
                txtEstDateCompAct2.Text = ds.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();
               
                ddlDistrictManagerAct2.SelectedValue = ds.Tables[0].Rows[0]["Form1_Manager_District"].ToString();
                ddlDistrictManagerAct2_SelectedIndexChanged(this, EventArgs.Empty);
                ddlMandalManagerAct2.SelectedValue = ds.Tables[0].Rows[0]["Form1_Manager_Mandal"].ToString();
                ddlMandalManagerAct2_SelectedIndexChanged(this, EventArgs.Empty);
                ddlVillageManagerAct2.SelectedValue = ds.Tables[0].Rows[0]["Form1_Manager_Village"].ToString();

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
    private int SaveLabourDetails()
    {
        LabourAct2VO2 labouractvo = new LabourAct2VO2();
        labouractvo.QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
        labouractvo.intCFEEnterpid = Convert.ToInt32(Request.QueryString[0].ToString());

        labouractvo.CreatedBy = Convert.ToInt32(Session["uid"].ToString().Trim());
        labouractvo.NameAct2 = txtEstbName.Text;
        labouractvo.LocationAct2 = txtEstbLoc.Text;
        labouractvo.ShopDistrict = ddlDistrictEstbAct2.SelectedValue;
        labouractvo.ShopMandal = ddlMandalEstbAct2.SelectedValue;
        labouractvo.ShopVillage = ddlVillageEstbAct2.SelectedValue;
        labouractvo.ShopPincode = txtPincodeEstdAct2.Text;
        labouractvo.ShopDoorNo = txtEstdDoorNoEstbAct2.Text;

        labouractvo.FullNamePerAct2 = txtFullNamePermAct2.Text;
        labouractvo.PerDoorNoAct2 = txtDoorNoPermAct2.Text;
        labouractvo.PerPincode = txtPinCodePermAct2.Text;

        labouractvo.ManagerDistrict = ddlDistrictManagerAct2.SelectedValue;
        labouractvo.ManagerMandal = ddlMandalManagerAct2.SelectedValue;
        labouractvo.ManagerVillage = ddlVillageManagerAct2.SelectedValue;
        labouractvo.ManagerFullName = txtFullNameManagerAct2.Text; //manager full name means vo.ManagerName
        labouractvo.ManagerMobile = txtMobileNoManagerAct2.Text;
        labouractvo.ManagerEmail = txtEmailManagerAct2.Text;
        labouractvo.ManagerStreet = txtStreetManagerAct2.Text;
        labouractvo.ManagerDoorNo = txtDoorNoManagerAct2.Text;

        labouractvo.NatureofWork = txtNatureofWorkAct2.Text;
        labouractvo.MaxWorkersAct2 = txtMaxWorkersAct2.Text;
        labouractvo.CommensementDateAct2 = txtEstDateCommAct2.Text;
        labouractvo.CompletionDateAct2 = txtEstDateCompAct2.Text;

        labouractvo.PerDistrict = ddlDistrictPermAct2.SelectedValue;
        labouractvo.PerMandal = ddlMandalPermAct2.SelectedValue;
        labouractvo.PerVillage = ddlVillagePermAct2.SelectedValue;

        int valid = 0;
         valid = Gen.InsertLabourDetailsAct2(labouractvo);
        return valid;
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
    protected void btnNext0_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmPCBDetails.aspx?intApplicationId=" + hdfFlagID0.Value + "&Previous=" + "P");

    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmLabourDetails_Act2.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
    }


    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SaveLabourDetails();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }

    protected void ddlDistrictEstbAct2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindMandals(ddlDistrictEstbAct2, ddlMandalEstbAct2);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void ddlMandalEstbAct2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindVillages(ddlMandalEstbAct2, ddlVillageEstbAct2);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
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
    protected void ddlDistrictManagerAct2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindMandals(ddlDistrictManagerAct2, ddlMandalManagerAct2);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void ddlMandalManagerAct2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindVillages(ddlMandalManagerAct2, ddlVillageManagerAct2);
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
}