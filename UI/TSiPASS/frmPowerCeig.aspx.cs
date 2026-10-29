using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
//created by suresh as on 13-1-2016 
//tables is td_BDCDet,tbl_Users
//procedures CheckUserid,insrtBDC,deleteBDC,getBDCbyID

public partial class UI_TSiPASS_frmPowerCeig : System.Web.UI.Page
{

    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }

        if (!IsPostBack)
        {

            BindRegulations(ddlregulation);
            BindPlant(ddlplant);
            BindVoltage(ddlvoltage);
            DataSet dscheck = new DataSet();
            dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
            if (dscheck.Tables[0].Rows.Count > 0)
            {
                Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
                ddlvoltage.SelectedValue = dscheck.Tables[0].Rows[0]["Voltage_Slno"].ToString().Trim();
                ddlvoltage.Enabled = false;
                ddlregulation.SelectedValue = dscheck.Tables[0].Rows[0]["Regulation_type"].ToString().Trim();
                ddlregulation.Enabled = false;

                txtaggregatecapacity.Text = dscheck.Tables[0].Rows[0]["AggregateCapacity"].ToString().Trim();
                txtaggregatecapacity.Enabled = false;

            }
            else
            {
                Session["Applid"] = "0";
            }       



        }

        if (!IsPostBack)
        {

            DataSet dsver = new DataSet();

            dsver = Gen.Getverifyofqueceigcfe(Session["Applid"].ToString());

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
            DataSet dsnew = new DataSet();

            dsnew = Gen.getdataofidentity(Session["Applid"].ToString(), "6");

            if (dsnew.Tables[0].Rows.Count > 0)
            {




            }
            else
            {


                if (Request.QueryString[1].ToString() == "N")
                {

                    Response.Redirect("frmprofessiontax.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");

                }

                else
                {

                    Response.Redirect("frmLabourDetails_New.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");

                }
            }


        }



        if (!IsPostBack)
        {


            getdistricts();
            if (Request.QueryString["intApplicationId"] != null)
            {
                hdfFlagID0.Value = Request.QueryString["intApplicationId"];
            }
            DataSet ds = new DataSet();
            ds = Gen.getdataofPowerDetailsCEIG(hdfFlagID0.Value);

            if (ds.Tables[0].Rows.Count > 0)
            {
                FillDetails();
            }
          
        }


        //DataSet ds = new DataSet();
        //ds = Gen.GetdataofCFOPowerDet(Session["uid"].ToString());

        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    if (!IsPostBack)
        //    {
        //        FillDetails();
        //    }

        //}


        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {

        }
        if (ddlregulation.Text.Trim() == "--Select--")
        {
            ddlregulation.Enabled = true;
        }

        if (txtaggregatecapacity.Text.Trim() == "")
        {
            txtaggregatecapacity.ReadOnly = false;
        }

        if (ddlregulation.SelectedItem.Text.Trim() == "43(3)" || ddlregulation.SelectedItem.Text.Trim() == "43(4)" || ddlregulation.SelectedItem.Text.Trim() == "36")
        {
            trvoltage.Visible = true;
            trPlant.Visible = false;
            if (ddlvoltage.Text.Trim() == "--Select--")
            {
                ddlvoltage.Enabled = true;
            }
        }
        else if (ddlregulation.SelectedItem.Text.Trim() == "32" || ddlregulation.SelectedItem.Text.Trim() == "43(4) & 32")
        {
            trvoltage.Visible = false;
            trPlant.Visible = true;
            if (ddlplant.Text.Trim() == "--Select--")
            {
                ddlplant.Enabled = true;
            }
        }
        if (LabelAgreement.Text == "")
        {
            FileAgreement.Enabled = true;
        }
        if (lblLicense.Text == "")
        {
            FileUploadLicense.Enabled = true;
        }
        if (lblpermitr.Text == "")
        {
            FileUploadpermit.Enabled = true;
        }
        if (lblFeasibility.Text == "")
        {
            FileUploadFeasibility.Enabled = true;
        }
        if (lblElectricalDiagram.Text == "")
        {
            FileUploadElectricalDiagram.Enabled = true;
        }
        if (lbllayout.Text == "")
        {
            FileUploadlayout.Enabled = true;
        }
        if (lblequipmentdrawing.Text == "")
        {
            FileUploadequipmentdrawing.Enabled = true;
        }
        if (lblearthinglayout.Text == "")
        {
            FileUploadearthinglayout.Enabled = true;
        }
        if (txtConnectProposed.Text == "0")
        {
            txtConnectProposed.ReadOnly = false;
            txtConnectProposed.Enabled = true;
        }
        if (txtKVAProposed.Text == "0")
        {
            txtKVAProposed.ReadOnly = false;
            txtKVAProposed.Enabled = true;
        }
    }

    #region states, district, mandals

    //protected void getstates()
    //{
    //    DataSet ds = new DataSet();
    //    ds = Gen.getStates();

    //    ddlstatus21.DataSource = ds.Tables[0];
    //    ddlstatus21.DataTextField = "State_Name";
    //    ddlstatus21.DataValueField = "State_id";
    //    ddlstatus21.DataBind();
    //    ddlstatus21.Items.Insert(0, "--Select--");

    //}

    protected void getdistricts()
    {
        DataSet ds = new DataSet();
        ds = Gen.GetDistricts();
        ddlDistrict.DataSource = ds.Tables[0];
        ddlDistrict.DataTextField = "District_Name";
        ddlDistrict.DataValueField = "District_Id";
        ddlDistrict.DataBind();
        ddlDistrict.Items.Insert(0, "--Select--");

    }

    protected void getMandals()
    {
        DataSet ds = new DataSet();
        ds = Gen.Getmandalsbydistrict(ddlDistrict.SelectedValue.ToString());
        ddlMandal.DataSource = ds.Tables[0];
        ddlMandal.DataTextField = "Manda_lName";
        ddlMandal.DataValueField = "Mandal_Id";
        ddlMandal.DataBind();
        ddlMandal.Items.Insert(0, "--Select--");
    }

    protected void getVillages()
    {
        DataSet ds = new DataSet();
        ds = Gen.GetVillagebymandal(ddlMandal.SelectedValue.ToString());
        ddlVillage.DataSource = ds.Tables[0];
        ddlVillage.DataTextField = "Village_Name";
        ddlVillage.DataValueField = "Village_Id";
        ddlVillage.DataBind();
        ddlVillage.Items.Insert(0, "--Select--");
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

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (txtConnectProposed.Text == "0")
        {
            lblmsg0.Text = "<font color='red'>Propsed Load should be greater than Zero..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (txtKVAProposed.Text == "0")
        {
            lblmsg0.Text = "<font color='red'>Propsed Load should be greater than Zero..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }

        if (LabelAgreement.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload Agreement letter between Contractor & Owner..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (lblLicense.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload Contractor License copy..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (lblpermitr.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload Contractor/Project electrical supervisor permit copy..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (lblElectricalDiagram.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload Electrical Single line diagram ..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (lbllayout.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload structural layout showing plan and Elevations ..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }

        if (BtnSave1.Text == "Save")
        {

            DataSet ds = new DataSet();

            ds = Gen.getdataofPowerDetailsCEIG(hdfFlagID0.Value);

            if (ds.Tables[0].Rows.Count > 0)
            {
                int result = 0;

                result = Gen.insetCFEPowerDetCeig(Session["uid"].ToString(), Session["Applid"].ToString(), hdfFlagID0.Value, "", "", txtKVAAlreadyInstalled.Text, txtKVAProposed.Text, txtKVATotal.Text, txtConnectedAlreadyInstalled.Text, txtConnectProposed.Text, txtConnectTotal.Text, ddlProject.SelectedValue, ddlDistrict.SelectedValue, ddlMandal.SelectedValue, ddlVillage.SelectedValue, txtStreet.Text, txtPinCode.Text, txtTelephone.Text, txtNearTelephone.Text, txtDateofCommencement.Text, Session["uid"].ToString(), Session["uid"].ToString(), txtExtent.Text, ddlConnectLoad.SelectedValue, txtSurvey.Text, ddlregulation.SelectedValue, ddlplant.SelectedValue, ddlvoltage.SelectedValue, txtaggregatecapacity.Text.Trim());
                if (result > 0)
                {
                    lblmsg.Text = "<font color='green'>CFO Power Details Saved Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;

                }
                else if (result == 0)
                {
                    lblmsg.Text = "<font color='green'>Power Details Updated Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;
                }
            }
            else
            {
                int result = 0;
                result = Gen.insetCFEPowerDetCeig(Session["uid"].ToString(), Session["Applid"].ToString(), hdfFlagID0.Value, "", "", txtKVAAlreadyInstalled.Text, txtKVAProposed.Text, txtKVATotal.Text, txtConnectedAlreadyInstalled.Text, txtConnectProposed.Text, txtConnectTotal.Text, ddlProject.SelectedValue, ddlDistrict.SelectedValue, ddlMandal.SelectedValue, ddlVillage.SelectedValue, txtStreet.Text, txtPinCode.Text, txtTelephone.Text, txtNearTelephone.Text, txtDateofCommencement.Text, Session["uid"].ToString(), Session["uid"].ToString(), txtExtent.Text, ddlConnectLoad.SelectedValue, txtSurvey.Text, ddlregulation.SelectedValue, ddlplant.SelectedValue, ddlvoltage.SelectedValue, txtaggregatecapacity.Text.Trim());

                if (result > 0)
                {
                    lblmsg.Text = "<font color='green'>CFO Power Details Saved Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;

                }
                else
                {
                    lblmsg.Text = "<font color='green'>CFO Power Details Submission Failed..!</font>";
                }
            }
        }


    }
    void clear()
    {

        txtKVAAlreadyInstalled.Text = ""; txtKVAProposed.Text = ""; txtKVATotal.Text = ""; txtConnectedAlreadyInstalled.Text = ""; txtConnectProposed.Text = ""; txtConnectTotal.Text = "";
        ddlProject.SelectedIndex = 0; ddlDistrict.SelectedIndex = 0; ddlMandal.SelectedIndex = 0; ddlVillage.SelectedValue = ""; txtStreet.Text = ""; txtPinCode.Text = "";
        txtTelephone.Text = ""; txtNearTelephone.Text = ""; txtDateofCommencement.Text = ""; txtExtent.Text = ""; ddlConnectLoad.SelectedIndex = 0;


    }


    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        //Response.Redirect("frmCAFFactoryDetails.aspx");

        if (txtConnectProposed.Text == "0")
        {
            lblmsg0.Text = "<font color='red'>Propsed Load should be greater than Zero..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (txtKVAProposed.Text == "0")
        {
            lblmsg0.Text = "<font color='red'>Propsed Load should be greater than Zero..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }

        if (LabelAgreement.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload Agreement letter between Contractor & Owner..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (lblLicense.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload Contractor License copy..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (lblpermitr.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload Contractor/Project electrical supervisor permit copy..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (lblElectricalDiagram.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload Electrical Single line diagram ..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (lbllayout.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload structural layout showing plan and Elevations ..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (BtnDelete.Text == "Next")
        {

            DataSet ds = new DataSet();

            ds = Gen.getdataofPowerDetailsCEIG(hdfFlagID0.Value);

            if (ds.Tables[0].Rows.Count > 0)
            {
                int result = 0;

                result = Gen.insetCFEPowerDetCeig(Session["uid"].ToString(), Session["Applid"].ToString(), hdfFlagID0.Value, "", "", txtKVAAlreadyInstalled.Text, txtKVAProposed.Text, txtKVATotal.Text, txtConnectedAlreadyInstalled.Text, txtConnectProposed.Text, txtConnectTotal.Text, ddlProject.SelectedValue, ddlDistrict.SelectedValue, ddlMandal.SelectedValue, ddlVillage.SelectedValue, txtStreet.Text, txtPinCode.Text, txtTelephone.Text, txtNearTelephone.Text, txtDateofCommencement.Text, Session["uid"].ToString(), Session["uid"].ToString(), txtExtent.Text, ddlConnectLoad.SelectedValue, txtSurvey.Text, ddlregulation.SelectedValue, ddlplant.SelectedValue, ddlvoltage.SelectedValue, txtaggregatecapacity.Text.Trim());
                if (result > 0)
                {


                    Response.Redirect("frmprofessiontax.aspx?intApplicationId="  +Request.QueryString[0].ToString() + "&next=" + "N");
                    lblmsg.Text = "<font color='green'>CFO Power Details Saved Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;

                }
                else if (result == 0)
                {
                    Response.Redirect("frmprofessiontax.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                    lblmsg.Text = "<font color='green'>Power Details Updated Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;
                }
            }
            else
            {
                int result = 0;
                result = Gen.insetCFEPowerDetCeig(Session["uid"].ToString(), Session["Applid"].ToString(), hdfFlagID0.Value, "", "", txtKVAAlreadyInstalled.Text, txtKVAProposed.Text, txtKVATotal.Text, txtConnectedAlreadyInstalled.Text, txtConnectProposed.Text, txtConnectTotal.Text, ddlProject.SelectedValue, ddlDistrict.SelectedValue, ddlMandal.SelectedValue, ddlVillage.SelectedValue, txtStreet.Text, txtPinCode.Text, txtTelephone.Text, txtNearTelephone.Text, txtDateofCommencement.Text, Session["uid"].ToString(), Session["uid"].ToString(), txtExtent.Text, ddlConnectLoad.SelectedValue, txtSurvey.Text, ddlregulation.SelectedValue, ddlplant.SelectedValue, ddlvoltage.SelectedValue, txtaggregatecapacity.Text.Trim());

                if (result > 0)
                {
                    Response.Redirect("frmCAFFactoryDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
                    lblmsg.Text = "<font color='green'>CFO Power Details Saved Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;

                }
                else
                {
                    lblmsg.Text = "<font color='green'>CFO Power Details Submission Failed..!</font>";
                }


            }
        }



    }

    void FillDetails()
    {

        DataSet ds = new DataSet();
        ds = Gen.getdataofPowerDetailsCEIG(hdfFlagID0.Value);

        if (ds.Tables[0].Rows.Count > 0)
        {
            txtKVAAlreadyInstalled.Text = ds.Tables[0].Rows[0]["Cont_Demand_Max_Already"].ToString();
            txtKVAProposed.Text = ds.Tables[0].Rows[0]["Cont_Demand_Max_Proposed"].ToString();
            txtKVATotal.Text = ds.Tables[0].Rows[0]["Cont_Demand_Max_Total"].ToString();
            txtConnectedAlreadyInstalled.Text = ds.Tables[0].Rows[0]["Connect_Load_A"].ToString();
            txtConnectProposed.Text = ds.Tables[0].Rows[0]["Connect_Load_B"].ToString();
            txtConnectTotal.Text = ds.Tables[0].Rows[0]["Connect_Load_C"].ToString();
            ddlProject.SelectedValue = ds.Tables[0].Rows[0]["Prop_Location"].ToString();
            ddlDistrict.SelectedValue = ds.Tables[0].Rows[0]["intDistrictid"].ToString();
            getMandals();
            ddlMandal.SelectedValue = ds.Tables[0].Rows[0]["intMandalid"].ToString();
            getVillages();
            ddlVillage.SelectedValue = ds.Tables[0].Rows[0]["Village_Name"].ToString();
            txtSurvey.Text = ds.Tables[0].Rows[0]["Survey_No"].ToString();
            txtStreet.Text = ds.Tables[0].Rows[0]["Street_Name"].ToString();
            txtPinCode.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
            txtTelephone.Text = ds.Tables[0].Rows[0]["Telephonce_No"].ToString();
            txtNearTelephone.Text = ds.Tables[0].Rows[0]["Nearest_Tel_No"].ToString();

            if (ds.Tables[0].Rows[0]["Date_Comm_Production"].ToString().Trim() != "")
            {
                txtDateofCommencement.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Date_Comm_Production"]).ToString("dd-MMM-yyyy");
            }
            txtExtent.Text = ds.Tables[0].Rows[0]["Extent"].ToString();
            ddlConnectLoad.SelectedValue = ds.Tables[0].Rows[0]["Type_of_connect_Load"].ToString();

            ddlregulation.SelectedValue = ds.Tables[0].Rows[0]["Regulation_type"].ToString();
            ddlvoltage.SelectedValue = ds.Tables[0].Rows[0]["Voltage_Slno"].ToString();
            ddlplant.SelectedValue = ds.Tables[0].Rows[0]["Plant_slno"].ToString();
            txtaggregatecapacity.Text = ds.Tables[0].Rows[0]["AggregateCapacity"].ToString();

            DataSet dsattachments = new DataSet();
            dsattachments = Gen.ViewAttachmetsData(hdfFlagID0.Value.ToString());

            if (dsattachments.Tables[0].Rows.Count > 0)
            {
                int c = dsattachments.Tables[0].Rows.Count;
                string sen, sen1, sen2, sennew;
                int i = 0;

                while (i < c)
                {
                    sen2 = dsattachments.Tables[0].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sennew = dsattachments.Tables[0].Rows[i]["LINKNEW"].ToString();// LINKNEW
                    string encpassword = Gen.Encrypt(sennew, "SYSTIME");
                    //  sen = sen1.Replace(@"C:/TSiPASS/Attachments/1192/", "~/");//"C:/TSiPASS/Attachments/1192/B1Form\CateogryofRegistration.jpg"
                    if (sen1.Contains("Attachments"))
                    {
                        sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/Attachments")), "~/");
                        if (sen.Contains("Agreementletter"))
                        {
                            lblAgreement.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            lblAgreement.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                            LabelAgreement.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                            //HyperLink1.NavigateUrl = sen;
                            //HyperLink1.Text = 
                        }

                        if (sen.Contains("ContractorLicense"))
                        {
                            HpLicense.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            HpLicense.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                            lblLicense.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                        }

                        if (sen.Contains("ContractorProject"))
                        {
                            Hppermit.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            Hppermit.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                            lblpermitr.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                        }

                        if (sen.Contains("Feasibilityreport"))
                        {
                            HpFeasibility.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            HpFeasibility.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                            lblFeasibility.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                        }
                        if (sen.Contains("ElectricalDiagram"))
                        {
                            HpElectricalDiagram.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            HpElectricalDiagram.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                            lblElectricalDiagram.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                        }
                        if (sen.Contains("StructralLayout"))
                        {
                            Hplayout.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            Hplayout.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                            lbllayout.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                        }
                        if (sen.Contains("equipmentdrawing"))
                        {
                            Hpequipmentdrawing.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            Hpequipmentdrawing.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                            lblequipmentdrawing.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                        }
                        if (sen.Contains("earthinglayout"))
                        {
                            hpearthinglayout.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            hpearthinglayout.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                            lblearthinglayout.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                        }
                    }
                    i++;
                }

            }

        }



    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {

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

    protected void txtcontact32_TextChanged(object sender, EventArgs e)
    {

    }

    protected void txtcontact29_TextChanged(object sender, EventArgs e)
    {

    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        getMandals();
    }

    protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        getVillages();
    }

    protected void txtKVAAlreadyInstalled_TextChanged(object sender, EventArgs e)
    {
        if (txtKVAAlreadyInstalled.Text == "")
        {
            txtKVAAlreadyInstalled.Text = "0";
        }
        if (txtKVAProposed.Text == "")
        {
            txtKVAProposed.Text = "0";
        }

        txtKVATotal.Text = (Convert.ToDecimal(txtKVAAlreadyInstalled.Text) + Convert.ToDecimal(txtKVAProposed.Text)).ToString();
    }

    protected void txtKVAProposed_TextChanged(object sender, EventArgs e)
    {
        if (txtKVAAlreadyInstalled.Text == "")
        {
            txtKVAAlreadyInstalled.Text = "0";
        }
        if (txtKVAProposed.Text == "")
        {
            txtKVAProposed.Text = "0";
        }

        txtKVATotal.Text = (Convert.ToDecimal(txtKVAAlreadyInstalled.Text) + Convert.ToDecimal(txtKVAProposed.Text)).ToString();
    }

    protected void txtConnectedAlreadyInstalled_TextChanged(object sender, EventArgs e)
    {
        if (txtConnectedAlreadyInstalled.Text == "")
        {
            txtConnectedAlreadyInstalled.Text = "0";

        }
        if (txtConnectProposed.Text == "")
        {
            txtConnectProposed.Text = "0";
        }

        txtConnectTotal.Text = Convert.ToString(Convert.ToDecimal(txtConnectedAlreadyInstalled.Text) + Convert.ToDecimal(txtConnectProposed.Text));
    }

    protected void txtConnectProposed_TextChanged(object sender, EventArgs e)
    {
        if (txtConnectedAlreadyInstalled.Text == "")
        {
            txtConnectedAlreadyInstalled.Text = "0";

        }
        if (txtConnectProposed.Text == "")
        {
            txtConnectProposed.Text = "0";
        }
       
        txtConnectTotal.Text = (Convert.ToDecimal(txtConnectedAlreadyInstalled.Text) + Convert.ToDecimal(txtConnectProposed.Text)).ToString();
    }

    protected void BtnDelete0_Click(object sender, EventArgs e)
    {

        Response.Redirect("frmLabourDetails_New.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");

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
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }

    protected void ddlregulation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlregulation.SelectedItem.Text.Trim() == "43(3)" || ddlregulation.SelectedItem.Text.Trim() == "43(4)" || ddlregulation.SelectedItem.Text.Trim() == "36")
        {
            trvoltage.Visible = true;
            trPlant.Visible = false;
        }
        else if (ddlregulation.SelectedItem.Text.Trim() == "32" || ddlregulation.SelectedItem.Text.Trim() == "43(4) & 32")
        {
            trvoltage.Visible = false;
            trPlant.Visible = true;
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
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
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
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
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

    protected void BtnAgreement_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

        General t1 = new General();
        if (FileAgreement.HasFile)
        {
            if ((FileAgreement.PostedFile != null) && (FileAgreement.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileAgreement.PostedFile.FileName);
                try
                {

                    string[] fileType = FileAgreement.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\Agreementletter");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileAgreement.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileAgreement.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Agreementletter", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        //result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "Agreementletter");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblAgreement.Text = FileAgreement.FileName;
                            LabelAgreement.Text = FileAgreement.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
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

    protected void btnLicense_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

        General t1 = new General();
        if (FileUploadLicense.HasFile)
        {
            if ((FileUploadLicense.PostedFile != null) && (FileUploadLicense.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadLicense.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadLicense.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\ContractorLicense");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadLicense.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadLicense.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "ContractorLicense", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ContractorLicense");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblLicense.Text = FileUploadLicense.FileName;
                            HpLicense.Text = FileUploadLicense.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
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

    protected void btnpermit_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

        General t1 = new General();
        if (FileUploadpermit.HasFile)
        {
            if ((FileUploadpermit.PostedFile != null) && (FileUploadpermit.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadpermit.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadpermit.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\ContractorProject");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadpermit.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadpermit.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "ContractorProject", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        //result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ContractorProject");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblpermitr.Text = FileUploadpermit.FileName;
                            Hppermit.Text = FileUploadpermit.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
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

    protected void btnFeasibility_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

        General t1 = new General();
        if (FileUploadFeasibility.HasFile)
        {
            if ((FileUploadFeasibility.PostedFile != null) && (FileUploadFeasibility.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadFeasibility.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadFeasibility.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\Feasibilityreport ");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadFeasibility.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadFeasibility.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Feasibilityreport", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        //result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "Feasibilityreport");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblFeasibility.Text = FileUploadFeasibility.FileName;
                            HpFeasibility.Text = FileUploadFeasibility.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
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

    protected void btnElectricalDiagram_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

        General t1 = new General();
        if (FileUploadElectricalDiagram.HasFile)
        {
            if ((FileUploadElectricalDiagram.PostedFile != null) && (FileUploadElectricalDiagram.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadElectricalDiagram.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadElectricalDiagram.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\ElectricalDiagram");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadElectricalDiagram.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadElectricalDiagram.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "ElectricalDiagram", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        //result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ElectricalDiagram");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblElectricalDiagram.Text = FileUploadElectricalDiagram.FileName;
                            HpElectricalDiagram.Text = FileUploadElectricalDiagram.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
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

    protected void btnlayout_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

        General t1 = new General();
        if (FileUploadlayout.HasFile)
        {
            if ((FileUploadlayout.PostedFile != null) && (FileUploadlayout.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadlayout.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadlayout.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\StructralLayout");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadlayout.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadlayout.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "StructralLayout", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "StructralLayout");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lbllayout.Text = FileUploadlayout.FileName;
                            Hplayout.Text = FileUploadlayout.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
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

    protected void btnequipmentdrawing_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

        General t1 = new General();
        if (FileUploadequipmentdrawing.HasFile)
        {
            if ((FileUploadequipmentdrawing.PostedFile != null) && (FileUploadequipmentdrawing.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadequipmentdrawing.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadequipmentdrawing.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\equipmentdrawing");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadequipmentdrawing.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadequipmentdrawing.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "equipmentdrawing", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        //result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "equipmentdrawing");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblequipmentdrawing.Text = FileUploadequipmentdrawing.FileName;
                            Hpequipmentdrawing.Text = FileUploadequipmentdrawing.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
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

    protected void btnearthinglayout_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

        General t1 = new General();
        if (FileUploadearthinglayout.HasFile)
        {
            if ((FileUploadearthinglayout.PostedFile != null) && (FileUploadearthinglayout.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadearthinglayout.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadearthinglayout.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\earthinglayout");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadearthinglayout.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadearthinglayout.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "earthinglayout", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        //result = t1.InsertImagedata(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "earthinglayout");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblearthinglayout.Text = FileUploadearthinglayout.FileName;
                            hpearthinglayout.Text = FileUploadearthinglayout.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
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

}