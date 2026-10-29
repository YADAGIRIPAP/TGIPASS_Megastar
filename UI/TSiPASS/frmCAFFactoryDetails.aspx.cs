using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;
using System.IO;

//created by suresh as on 13-1-2016 
//tables is td_BDCDet,tbl_Users
//procedures CheckUserid,insrtBDC,deleteBDC,getBDCbyID
public partial class TSTBDCReg1 : System.Web.UI.Page
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



            DataSet dscheck1 = new DataSet();
            dscheck1 = Gen.GetShowQuestionariesCFO(Session["uid"].ToString().Trim());
            if (dscheck1.Tables[0].Rows.Count > 0)
            {
                Session["ApplidA"] = dscheck1.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
            }
            else
            {
                Session["ApplidA"] = "0";
            }



        }
        if (!IsPostBack)
        {

            DataSet dsver = new DataSet();

            dsver = Gen.GetverifyofqueFactory9CFO(Session["ApplidA"].ToString());

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
            //string res = Gen.RetriveStatusFactorydataCFO(Session["ApplidA"].ToString());

            //if (res == "Y")
            //{

            //}

            DataSet dsnew = new DataSet();
            dsnew = Gen.getdataofidentityCFONew(Session["ApplidA"].ToString(), "9");
            if (dsnew.Tables[0].Rows.Count > 0)
            {
                if(dsnew.Tables[0].Rows[0]["intStageid"].ToString() != ""&& dsnew.Tables[0].Rows[0]["intStageid"].ToString() != null)
                {
                    HDNFACTSTAGEID.Value = dsnew.Tables[0].Rows[0]["intStageid"].ToString();

                }
            }

            else
            {
                if (Request.QueryString[1].ToString() == "N")
                {

                    Response.Redirect("frmCAFBoilersDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");

                }   
                else
                {
                    Response.Redirect("frmCAFPowerDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&Previous=" + "P");

                }

            }



        }



        if (!IsPostBack)
        {
            getdistricts();
            getdistrictsmanager();
            getdistrictsOccupier();
            getdistrictsOwner();

            DataSet ds = new DataSet();
            ds = Gen.GetdataofCFOFactoriesDet(Session["uid"].ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                FillDetails();
            }

            if (ddlLicenseYear.Text.Trim() == "--Select--")
            {
                ddlLicenseYear.Enabled = true;
            }

            if (txtregularinhp.Text.Trim() == "")
            {
                txtregularinhp.ReadOnly = false;
            }
            if (txtstandbyHP.Text.Trim() == "")
            {
                txtstandbyHP.ReadOnly = false;
            }
            if (txtMngrFullNm.Text.Trim() == "")
            {
                txtMngrFullNm.ReadOnly = false;
            }
            if (ddlMngrdistrict.Text.Trim() == "--Select--")
            {
                ddlMngrdistrict.Enabled = true;
            }
            if (ddlMngrMandal.Text.Trim() == "--Select--")
            {
                ddlMngrMandal.Enabled = true;
            }
            if (ddlMngrVillage.Text.Trim() == "--Select--")
            {
                ddlMngrVillage.Enabled = true;
            }
            if (txtMngrDoorNo.Text.Trim() == "")
            {
                txtMngrDoorNo.ReadOnly = false;
            }
            if (txtMngrstreetName.Text.Trim() == "")
            {
                txtMngrstreetName.ReadOnly = false;
            }
            if (txtMngrpincode.Text.Trim() == "")
            {
                txtMngrpincode.ReadOnly = false;
            }
            if (txtMngrMobileNo.Text.Trim() == "")
            {
                txtMngrMobileNo.ReadOnly = false;
            }
            if (txtMngrEmail.Text.Trim() == "")
            {
                txtMngrEmail.ReadOnly = false;
            }

            if (txtOccupierFullNm.Text.Trim() == "")
            {
                txtOccupierFullNm.ReadOnly = false;
            }
            if (ddlOccupierDistrict.Text.Trim() == "--Select--")
            {
                ddlOccupierDistrict.Enabled = true;
            }
            if (ddlOccupierMandal.Text.Trim() == "--Select--")
            {
                ddlOccupierMandal.Enabled = true;
            }
            if (ddlOccupierVillage.Text.Trim() == "--Select--")
            {
                ddlOccupierVillage.Enabled = true;
            }
            if (txtOccupierDoorNo.Text.Trim() == "")
            {
                txtOccupierDoorNo.ReadOnly = false;
            }
            if (txtOccupierStreetNm.Text.Trim() == "")
            {
                txtOccupierStreetNm.ReadOnly = false;
            }
            if (txtOccupierpincode.Text.Trim() == "")
            {
                txtOccupierpincode.ReadOnly = false;
            }
            if (txtOccupuierMobileNo.Text.Trim() == "")
            {
                txtOccupuierMobileNo.ReadOnly = false;
            }
            if (txtoccupierEmail.Text.Trim() == "")
            {
                txtoccupierEmail.ReadOnly = false;
            }


            if (txtownerFullNm.Text.Trim() == "")
            {
                txtownerFullNm.ReadOnly = false;
            }
            if (ddlOwnerDistrict.Text.Trim() == "--Select--")
            {
                ddlOwnerDistrict.Enabled = true;
            }
            if (ddlOwnerMandal.Text.Trim() == "--Select--")
            {
                ddlOwnerMandal.Enabled = true;
            }
            if (ddlOwnerVillage.Text.Trim() == "--Select--")
            {
                ddlOwnerVillage.Enabled = true;
            }
            if (txtOwnerDoorNo.Text.Trim() == "")
            {
                txtOwnerDoorNo.ReadOnly = false;
            }
            if (txtOwnerStreetNm.Text.Trim() == "")
            {
                txtOwnerStreetNm.ReadOnly = false;
            }
            if (txtOwnerPinCode.Text.Trim() == "")
            {
                txtOwnerPinCode.ReadOnly = false;
            }
            if (txtOwnerMobile.Text.Trim() == "")
            {
                txtOwnerMobile.ReadOnly = false;
            }
            if (txtOwnerEmail.Text.Trim() == "")
            {
                txtOwnerEmail.ReadOnly = false;
            }
            if (HyperLink4.Text.Trim() == "")
            {
                FileUpload13.Enabled = true;
            }  if (HyperLink4.Text.Trim() == "")
            {
                FileUpload13.Enabled = true;
            }
            if (HyperLink3.Text.Trim() == "")
            {
                FileUpload10.Enabled = true;
            }
            if (HyperLink2.Text.Trim() == "")
            {
                FileUpload11.Enabled = true;
            }
            if (HyperLink1.Text.Trim() == "")
            {
                FileUpload15.Enabled = true;
            }
        }

        //DataSet ds = new DataSet();
        //ds = Gen.GetdataofCFOFactoriesDet(Session["uid"].ToString());

        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    FillDetails();
        //}

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {

        }
    }

    #region states, district, mandals


    protected void getdistricts()
    {
        //DataSet ds = new DataSet();
        //ds = Gen.GetDistricts();

        Cls_MasterofTsipass obj_newdistrictwargnal = new Cls_MasterofTsipass();
        DataSet ds = new DataSet();
        ds = obj_newdistrictwargnal.GetallDistrictswithoutWarangal(Convert.ToString(Session["uid"]), "CFO");
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
        ds = Gen.GetVillages(ddlMandal.SelectedValue.ToString());
        ddlVillage.DataSource = ds.Tables[0];
        ddlVillage.DataTextField = "Village_Name";
        ddlVillage.DataValueField = "Village_Id";
        ddlVillage.DataBind();
        ddlVillage.Items.Insert(0, "--Select--");
    }

    protected void getdistrictsmanager()
    {
        //DataSet ds = new DataSet();
        //ds = Gen.GetDistricts();

        Cls_MasterofTsipass obj_newdistrictwargnal = new Cls_MasterofTsipass();
        DataSet ds = new DataSet();
        ds = obj_newdistrictwargnal.GetallDistrictswithoutWarangal(Convert.ToString(Session["uid"]), "CFO");
        ddlMngrdistrict.DataSource = ds.Tables[0];
        ddlMngrdistrict.DataTextField = "District_Name";
        ddlMngrdistrict.DataValueField = "District_Id";
        ddlMngrdistrict.DataBind();
        ddlMngrdistrict.Items.Insert(0, "--Select--");

    }

    protected void getMandalsmanager()
    {
        DataSet ds = new DataSet();
        ds = Gen.Getmandalsbydistrict(ddlMngrdistrict.SelectedValue.ToString());
        ddlMngrMandal.DataSource = ds.Tables[0];
        ddlMngrMandal.DataTextField = "Manda_lName";
        ddlMngrMandal.DataValueField = "Mandal_Id";
        ddlMngrMandal.DataBind();
        ddlMngrMandal.Items.Insert(0, "--Select--");
    }

    protected void getVillagesmanager()
    {
        DataSet ds = new DataSet();
        ds = Gen.GetVillagesWithGHMC(ddlMngrMandal.SelectedValue.ToString());
        ddlMngrVillage.DataSource = ds.Tables[0];
        ddlMngrVillage.DataTextField = "Village_Name";
        ddlMngrVillage.DataValueField = "Village_Id";
        ddlMngrVillage.DataBind();
        ddlMngrVillage.Items.Insert(0, "--Select--");
    }

    protected void getdistrictsOccupier()
    {
        //DataSet ds = new DataSet();
        //ds = Gen.GetDistricts();

        Cls_MasterofTsipass obj_newdistrictwargnal = new Cls_MasterofTsipass();
        DataSet ds = new DataSet();
        ds = obj_newdistrictwargnal.GetallDistrictswithoutWarangal(Convert.ToString(Session["uid"]), "CFO");
        ddlOccupierDistrict.DataSource = ds.Tables[0];
        ddlOccupierDistrict.DataTextField = "District_Name";
        ddlOccupierDistrict.DataValueField = "District_Id";
        ddlOccupierDistrict.DataBind();
        ddlOccupierDistrict.Items.Insert(0, "--Select--");

    }

    protected void getMandalsOccupier()
    {
        DataSet ds = new DataSet();
        ds = Gen.Getmandalsbydistrict(ddlOccupierDistrict.SelectedValue.ToString());
        ddlOccupierMandal.DataSource = ds.Tables[0];
        ddlOccupierMandal.DataTextField = "Manda_lName";
        ddlOccupierMandal.DataValueField = "Mandal_Id";
        ddlOccupierMandal.DataBind();
        ddlOccupierMandal.Items.Insert(0, "--Select--");
    }

    protected void getVillagesOccupier()
    {
        DataSet ds = new DataSet();
        ds = Gen.GetVillagesWithGHMC(ddlOccupierMandal.SelectedValue.ToString());
        ddlOccupierVillage.DataSource = ds.Tables[0];
        ddlOccupierVillage.DataTextField = "Village_Name";
        ddlOccupierVillage.DataValueField = "Village_Id";
        ddlOccupierVillage.DataBind();
        ddlOccupierVillage.Items.Insert(0, "--Select--");
    }

    protected void getdistrictsOwner()
    {
        //DataSet ds = new DataSet();
        //ds = Gen.GetDistricts();

        Cls_MasterofTsipass obj_newdistrictwargnal = new Cls_MasterofTsipass();
        DataSet ds = new DataSet();
        ds = obj_newdistrictwargnal.GetallDistrictswithoutWarangal(Convert.ToString(Session["uid"]), "CFO");
        ddlOwnerDistrict.DataSource = ds.Tables[0];
        ddlOwnerDistrict.DataTextField = "District_Name";
        ddlOwnerDistrict.DataValueField = "District_Id";
        ddlOwnerDistrict.DataBind();
        ddlOwnerDistrict.Items.Insert(0, "--Select--");

    }

    protected void getMandalsOwner()
    {
        DataSet ds = new DataSet();
        ds = Gen.Getmandalsbydistrict(ddlOwnerDistrict.SelectedValue.ToString());
        ddlOwnerMandal.DataSource = ds.Tables[0];
        ddlOwnerMandal.DataTextField = "Manda_lName";
        ddlOwnerMandal.DataValueField = "Mandal_Id";
        ddlOwnerMandal.DataBind();
        ddlOwnerMandal.Items.Insert(0, "--Select--");
    }

    protected void getVillagesOwner()
    {
        DataSet ds = new DataSet();
        ds = Gen.GetVillagesWithGHMC(ddlOwnerMandal.SelectedValue.ToString());
        ddlOwnerVillage.DataSource = ds.Tables[0];
        ddlOwnerVillage.DataTextField = "Village_Name";
        ddlOwnerVillage.DataValueField = "Village_Id";
        ddlOwnerVillage.DataBind();
        ddlOwnerVillage.Items.Insert(0, "--Select--");
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

        if (BtnSave1.Text == "Save")
        {

            string number = txtregularinhp.Text.Trim();
          
            Regex regex = new Regex(@"^[0-9]+$");

            if (regex.IsMatch(number))
            {
                // valid number;
            }
            else
            {

                lblmsg0.Text = "<font color='red'>Please Enter Numeric value in Regular HP..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                txtregularinhp.Enabled = true;
                txtregularinhp.ReadOnly = false;
                return;
            }

            string number1 = txtstandbyHP.Text.Trim();
            if (regex.IsMatch(number1))
            {
                // valid number;
            }
            else
            {

                lblmsg0.Text = "<font color='red'>Please Enter Numeric value in StandBy HP..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                txtstandbyHP.Enabled = true;
                txtstandbyHP.ReadOnly = false;
                return;
            }

            //if (Label461.Text == "")
            //{
            //    lblmsg0.Text = "<font color='red'>Please Upload List Of Directors Attachment..!</font>";
            //    success.Visible = false;
            //    Failure.Visible = true;
            //    return;
            //}
            //if (Label460.Text == "")
            //{
            //    lblmsg0.Text = "<font color='red'>Please Upload Partnership deed Attachment..!</font>";
            //    success.Visible = false;
            //    Failure.Visible = true;
            //    return;
            //}
            //if (Label470.Text == "")
            //{
            //    lblmsg0.Text = "<font color='red'>Please Upload PlanLayout Attachment..!</font>";
            //    success.Visible = false;
            //    Failure.Visible = true;
            //    return;
            //}
            if (HyperLink4.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload Land OwnerShip Deed Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            if (HyperLink3.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload Partnership deed Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            if (HyperLink2.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload List Of Directors Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            if (HyperLink1.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload Plant Layout Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            if ((HYPLISTOFWORKERS.Text == ""|| HYPMACHINERYINSTALLED.Text == ""|| HYPSELFCOMP.Text == "")&& HDNFACTSTAGEID.Value=="2")
            {
                lblmsg0.Text = "<font color='red'>Please Upload List of actual number of workers employed both Contract and Regular, Upload Photographs of Machinery installed and Upload Self Compliance check list</font>";
                success.Visible = false;
                Failure.Visible = true;
                FUPLISTOFWORKERS.Enabled = true;
                FUPMACHINERYINSTALLED.Enabled = true;
                FUPSELFCOMP.Enabled = true;
                return;
            }
            //if (HYPMACHINERYINSTALLED.Text == "")
            //{
            //    lblmsg0.Text = "<font color='red'>Please Upload Photographs of Machinery installed..!</font>";
            //    success.Visible = false;
            //    Failure.Visible = true;

            //    return;
            //}
            //if (HYPSELFCOMP.Text == "")
            //{
            //    lblmsg0.Text = "<font color='red'>Please Upload Self Compliance check list..!</font>";
            //    success.Visible = false;
            //    Failure.Visible = true;

            //    return;
            //}

            DataSet ds = new DataSet();

            ds = Gen.GetdataofCFOFactoriesDet(Session["uid"].ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                int result = 0;
                //result = Gen.insetEnterprenuerdataCFO(Session["uid"].ToString(), "1", "1", txtNameOfIndustrialUndertaking.Text, txtNameOfPromoter.Text, txtSonOfDOWO.Text, txtage.Text, txtOccupation.Text, ddlState.SelectedValue, ddlDistrict.SelectedValue, ddlMandal.SelectedValue, ddlVillage.SelectedValue, txtStreetName.Text, txtDoorNo.Text, txtLandmark.Text, "0", txtMobileNo.Text, txtEmail.Text, txtFax.Text, ddlNatureofOrg.SelectedValue, txtTelephone.Text, txtAdultMale.Text, txtAdultFemale.Text, txtAdoleMale.Text, txtAdoleFemale.Text, txtChildMale.Text, txtChildFemale.Text, ddlCateORg.SelectedValue, txtRegNo.Text, txtRegDate.Text, txtRegExpDate.Text, ddlProject.SelectedValue, txtRegNo.Text, "0", Session["uid"].ToString(), Session["uid"].ToString());
                result = Gen.insetCFOFactoriesDet(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", RadioButtonList1.SelectedValue, txtRefNo.Text, txtRefDate.Text, txtFullAddr.Text, txtDateOccu.Text, txtOccuAddr.Text, txtOwnerAddr.Text, ddlDistrict.SelectedValue, ddlMandal.SelectedValue, ddlVillage.SelectedValue, txtPS.Text, txtNearRail.Text, txtProsPetorlClassA.Text, txtPropPetolClassB.Text, txtPropPetrolClassC.Text, txtPropPetrolTotal.Text, txtNotPropPetrolClassA.Text, txtNotPropPetrolClassB.Text, txtNotPropPetrolClassC.Text, txtNotPropPetrolTot.Text, txtProsPetrolTotClassA.Text, txtProsPetrolTotClassB.Text, txtProsPetrolTotClassC.Text, txtProsPetrolGrandTot.Text, txtStorPetrolClassA.Text, txtStorPetrolClassB.Text, txtStorPetrolClassc.Text, txtStorPetrolTot.Text, txtNotStorPetrolClassA.Text, txtNotStorPetrolClassB.Text, txtNotStorPetrolClassC.Text, txtNotStorPetrolTot.Text, txtStorPetrolTotClassA.Text, txtStorPetrolTotClassB.Text, txtStorPetrolTotClassC.Text, txtStorPetrolGrandTot.Text, txtSalesTaxRegDet.Text, txtExpLicDet.Text, Session["uid"].ToString(), Session["uid"].ToString(), ddlLicenseYear.SelectedValue,
                    txtregularinhp.Text.Trim(), txtstandbyHP.Text.Trim(), txtMngrFullNm.Text.Trim(), ddlMngrdistrict.SelectedValue, ddlMngrMandal.SelectedValue, ddlMngrVillage.SelectedValue, txtMngrDoorNo.Text.Trim(), txtMngrstreetName.Text.Trim(),
txtMngrpincode.Text.Trim(), txtMngrMobileNo.Text.Trim(), txtMngrEmail.Text.Trim(), txtOccupierFullNm.Text.Trim(), ddlOccupierDistrict.SelectedValue, ddlOccupierMandal.SelectedValue, ddlOccupierVillage.SelectedValue,
txtOccupierDoorNo.Text.Trim(), txtOccupierStreetNm.Text.Trim(), txtOccupierpincode.Text.Trim(), txtOccupuierMobileNo.Text.Trim(), txtoccupierEmail.Text.Trim(), txtownerFullNm.Text.Trim(), ddlOwnerDistrict.SelectedValue, ddlOwnerMandal.SelectedValue,
ddlOwnerVillage.SelectedValue, txtOwnerDoorNo.Text.Trim(), txtOwnerStreetNm.Text.Trim(), txtOwnerPinCode.Text.Trim(), txtOwnerMobile.Text.Trim(), txtOwnerEmail.Text.Trim());

                if (result > 0)
                {
                    lblmsg.Text = "<font color='green'>CFO Factory Details Saved Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;

                }
                else if (result == 0)
                {
                    lblmsg.Text = "<font color='green'>Factory Details Updated Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;
                }
            }
            else
            {
                int result = 0;
                result = Gen.insetCFOFactoriesDet(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", RadioButtonList1.SelectedValue, txtRefNo.Text, txtRefDate.Text, txtFullAddr.Text, txtDateOccu.Text, txtOccuAddr.Text, txtOwnerAddr.Text, ddlDistrict.SelectedValue, ddlMandal.SelectedValue, ddlVillage.SelectedValue, txtPS.Text, txtNearRail.Text, txtProsPetorlClassA.Text, txtPropPetolClassB.Text, txtPropPetrolClassC.Text, txtPropPetrolTotal.Text, txtNotPropPetrolClassA.Text, txtNotPropPetrolClassB.Text, txtNotPropPetrolClassC.Text, txtNotPropPetrolTot.Text, txtProsPetrolTotClassA.Text, txtProsPetrolTotClassB.Text, txtProsPetrolTotClassC.Text, txtProsPetrolGrandTot.Text, txtStorPetrolClassA.Text, txtStorPetrolClassB.Text, txtStorPetrolClassc.Text, txtStorPetrolTot.Text, txtNotStorPetrolClassA.Text, txtNotStorPetrolClassB.Text, txtNotStorPetrolClassC.Text, txtNotStorPetrolTot.Text, txtStorPetrolTotClassA.Text, txtStorPetrolTotClassB.Text, txtStorPetrolTotClassC.Text, txtStorPetrolGrandTot.Text, txtSalesTaxRegDet.Text, txtExpLicDet.Text, Session["uid"].ToString(), Session["uid"].ToString(), ddlLicenseYear.SelectedValue,
                    txtregularinhp.Text.Trim(), txtstandbyHP.Text.Trim(), txtMngrFullNm.Text.Trim(), ddlMngrdistrict.SelectedValue, ddlMngrMandal.SelectedValue, ddlMngrVillage.SelectedValue, txtMngrDoorNo.Text.Trim(), txtMngrstreetName.Text.Trim(),
txtMngrpincode.Text.Trim(), txtMngrMobileNo.Text.Trim(), txtMngrEmail.Text.Trim(), txtOccupierFullNm.Text.Trim(), ddlOccupierDistrict.SelectedValue, ddlOccupierMandal.SelectedValue, ddlOccupierVillage.SelectedValue,
txtOccupierDoorNo.Text.Trim(), txtOccupierStreetNm.Text.Trim(), txtOccupierpincode.Text.Trim(), txtOccupuierMobileNo.Text.Trim(), txtoccupierEmail.Text.Trim(), txtownerFullNm.Text.Trim(), ddlOwnerDistrict.SelectedValue, ddlOwnerMandal.SelectedValue,
ddlOwnerVillage.SelectedValue, txtOwnerDoorNo.Text.Trim(), txtOwnerStreetNm.Text.Trim(), txtOwnerPinCode.Text.Trim(), txtOwnerMobile.Text.Trim(), txtOwnerEmail.Text.Trim());

                if (result > 0)
                {
                    lblmsg.Text = "<font color='green'>CFO Factory Details Saved Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;

                }
                else
                {
                    lblmsg.Text = "<font color='green'>CFO Enterprenuer Details Submission Failed..!</font>";
                }
            }
        }


    }
    void clear()
    {


        RadioButtonList1.SelectedValue = ""; txtRefNo.Text = ""; txtRefDate.Text = ""; txtFullAddr.Text = ""; txtDateOccu.Text = ""; txtOccuAddr.Text = ""; txtOwnerAddr.Text = ""; ddlDistrict.SelectedValue = ""; ddlMandal.SelectedValue = ""; ddlVillage.SelectedValue = ""; txtPS.Text = ""; txtNearRail.Text = ""; txtProsPetorlClassA.Text = ""; txtPropPetolClassB.Text = ""; txtPropPetrolClassC.Text = ""; txtPropPetrolTotal.Text = ""; txtNotPropPetrolClassA.Text = ""; txtNotPropPetrolClassB.Text = ""; txtNotPropPetrolClassC.Text = ""; txtNotPropPetrolTot.Text = ""; txtProsPetrolTotClassA.Text = ""; txtProsPetrolTotClassB.Text = ""; txtProsPetrolTotClassC.Text = ""; txtProsPetrolGrandTot.Text = ""; txtStorPetrolClassA.Text = ""; txtStorPetrolClassB.Text = ""; txtStorPetrolClassc.Text = ""; txtStorPetrolTot.Text = ""; txtNotStorPetrolClassA.Text = ""; txtNotStorPetrolClassB.Text = ""; txtNotStorPetrolClassC.Text = ""; txtNotStorPetrolTot.Text = ""; txtStorPetrolTotClassA.Text = ""; txtStorPetrolTotClassB.Text = ""; txtStorPetrolTotClassC.Text = ""; txtStorPetrolGrandTot.Text = ""; txtSalesTaxRegDet.Text = ""; txtExpLicDet.Text = "";

    }


    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        //Response.Redirect("frmCAFAttachmentDetails.aspx");

        if (BtnDelete.Text == "Next")
        {

            string number = txtregularinhp.Text.Trim();

            Regex regex = new Regex(@"^[0-9]+$");

            if (regex.IsMatch(number))
            {
                // valid number;
            }
            else
            {

                lblmsg0.Text = "<font color='red'>Please Enter Numeric value in Regular HP..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                txtregularinhp.Enabled = true;
                txtregularinhp.ReadOnly = false;
                return;
            }

            string number1 = txtstandbyHP.Text.Trim();
            if (regex.IsMatch(number1))
            {
                // valid number;
            }
            else
            {

                lblmsg0.Text = "<font color='red'>Please Enter Numeric value in StandBy HP..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                txtstandbyHP.Enabled = true;
                txtstandbyHP.ReadOnly = false;
                return;
            }
            if (HyperLink4.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload Land OwnerShip Deed Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            if (HyperLink3.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload Partnership deed Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            if (HyperLink2.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload List Of Directors Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            if (HyperLink1.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload Plant Layout Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            if ((HYPLISTOFWORKERS.Text == "" || HYPMACHINERYINSTALLED.Text == "" || HYPSELFCOMP.Text == "")&& HDNFACTSTAGEID.Value == "2")
            {
                lblmsg0.Text = "<font color='red'>Please Upload List of actual number of workers employed both Contract and Regular, Upload Photographs of Machinery installed and Upload Self Compliance check list</font>";
                success.Visible = false;
                Failure.Visible = true;
                FUPLISTOFWORKERS.Enabled = true;
                FUPMACHINERYINSTALLED.Enabled = true;
                FUPSELFCOMP.Enabled = true;
                return;
            }
            //if (HYPMACHINERYINSTALLED.Text == "")
            //{
            //    lblmsg0.Text = "<font color='red'>Please Upload Photographs of Machinery installed..!</font>";
            //    success.Visible = false;
            //    Failure.Visible = true;
            //    FUPMACHINERYINSTALLED.Enabled = true;

            //    return;
            //}
            //if (HYPSELFCOMP.Text == "")
            //{
            //    lblmsg0.Text = "<font color='red'>Please Upload Self Compliance check list..!</font>";
            //    success.Visible = false;
            //    Failure.Visible = true;
            //    FUPSELFCOMP.Enabled = true;

            //    return;
            //}
            DataSet ds = new DataSet();

            ds = Gen.GetdataofCFOFactoriesDet(Session["uid"].ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                int result = 0;
                //result = Gen.insetEnterprenuerdataCFO(Session["uid"].ToString(), "1", "1", txtNameOfIndustrialUndertaking.Text, txtNameOfPromoter.Text, txtSonOfDOWO.Text, txtage.Text, txtOccupation.Text, ddlState.SelectedValue, ddlDistrict.SelectedValue, ddlMandal.SelectedValue, ddlVillage.SelectedValue, txtStreetName.Text, txtDoorNo.Text, txtLandmark.Text, "0", txtMobileNo.Text, txtEmail.Text, txtFax.Text, ddlNatureofOrg.SelectedValue, txtTelephone.Text, txtAdultMale.Text, txtAdultFemale.Text, txtAdoleMale.Text, txtAdoleFemale.Text, txtChildMale.Text, txtChildFemale.Text, ddlCateORg.SelectedValue, txtRegNo.Text, txtRegDate.Text, txtRegExpDate.Text, ddlProject.SelectedValue, txtRegNo.Text, "0", Session["uid"].ToString(), Session["uid"].ToString());
                //result = Gen.insetCFOFactoriesDet(Session["uid"].ToString(),Session["ApplidA"].ToString(),Session["uid"].ToString(),"1","1", RadioButtonList1.SelectedValue, txtRefNo.Text, txtRefDate.Text, txtFullAddr.Text, txtDateOccu.Text, txtOccuAddr.Text, txtOwnerAddr.Text, ddlDistrict.SelectedValue, ddlMandal.SelectedValue, ddlVillage.SelectedValue, txtPS.Text, txtNearRail.Text, txtProsPetorlClassA.Text, txtPropPetolClassB.Text, txtPropPetrolClassC.Text, txtPropPetrolTotal.Text, txtNotPropPetrolClassA.Text, txtNotPropPetrolClassB.Text, txtNotPropPetrolClassC.Text, txtNotPropPetrolTot.Text, txtProsPetrolTotClassA.Text, txtProsPetrolTotClassB.Text, txtProsPetrolTotClassC.Text, txtProsPetrolGrandTot.Text, txtStorPetrolClassA.Text, txtStorPetrolClassB.Text, txtStorPetrolClassc.Text, txtStorPetrolTot.Text, txtNotStorPetrolClassA.Text, txtNotStorPetrolClassB.Text, txtNotStorPetrolClassC.Text, txtNotStorPetrolTot.Text, txtStorPetrolTotClassA.Text, txtStorPetrolTotClassB.Text, txtStorPetrolTotClassC.Text, txtStorPetrolGrandTot.Text, txtSalesTaxRegDet.Text, txtExpLicDet.Text, Session["uid"].ToString(), Session["uid"].ToString());

                result = Gen.insetCFOFactoriesDet(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", RadioButtonList1.SelectedValue, txtRefNo.Text, txtRefDate.Text, txtFullAddr.Text, txtDateOccu.Text, txtOccuAddr.Text, txtOwnerAddr.Text, ddlDistrict.SelectedValue, ddlMandal.SelectedValue, ddlVillage.SelectedValue, txtPS.Text, txtNearRail.Text, txtProsPetorlClassA.Text, txtPropPetolClassB.Text, txtPropPetrolClassC.Text, txtPropPetrolTotal.Text, txtNotPropPetrolClassA.Text, txtNotPropPetrolClassB.Text, txtNotPropPetrolClassC.Text, txtNotPropPetrolTot.Text, txtProsPetrolTotClassA.Text, txtProsPetrolTotClassB.Text, txtProsPetrolTotClassC.Text, txtProsPetrolGrandTot.Text, txtStorPetrolClassA.Text, txtStorPetrolClassB.Text, txtStorPetrolClassc.Text, txtStorPetrolTot.Text, txtNotStorPetrolClassA.Text, txtNotStorPetrolClassB.Text, txtNotStorPetrolClassC.Text, txtNotStorPetrolTot.Text, txtStorPetrolTotClassA.Text, txtStorPetrolTotClassB.Text, txtStorPetrolTotClassC.Text, txtStorPetrolGrandTot.Text, txtSalesTaxRegDet.Text, txtExpLicDet.Text, Session["uid"].ToString(), Session["uid"].ToString(), ddlLicenseYear.SelectedValue,
                    txtregularinhp.Text.Trim(), txtstandbyHP.Text.Trim(), txtMngrFullNm.Text.Trim(), ddlMngrdistrict.SelectedValue, ddlMngrMandal.SelectedValue, ddlMngrVillage.SelectedValue, txtMngrDoorNo.Text.Trim(), txtMngrstreetName.Text.Trim(),
txtMngrpincode.Text.Trim(), txtMngrMobileNo.Text.Trim(), txtMngrEmail.Text.Trim(), txtOccupierFullNm.Text.Trim(), ddlOccupierDistrict.SelectedValue, ddlOccupierMandal.SelectedValue, ddlOccupierVillage.SelectedValue,
txtOccupierDoorNo.Text.Trim(), txtOccupierStreetNm.Text.Trim(), txtOccupierpincode.Text.Trim(), txtOccupuierMobileNo.Text.Trim(), txtoccupierEmail.Text.Trim(), txtownerFullNm.Text.Trim(), ddlOwnerDistrict.SelectedValue, ddlOwnerMandal.SelectedValue,
ddlOwnerVillage.SelectedValue, txtOwnerDoorNo.Text.Trim(), txtOwnerStreetNm.Text.Trim(), txtOwnerPinCode.Text.Trim(), txtOwnerMobile.Text.Trim(), txtOwnerEmail.Text.Trim());

                if (result > 0)
                {
                    Response.Redirect("frmCAFBoilersDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
                    lblmsg.Text = "<font color='green'>CFO Factory Details Saved Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;

                }
                else if (result == 0)
                {
                    Response.Redirect("frmCAFBoilersDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
                    lblmsg.Text = "<font color='green'>Factory Details Updated Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;
                }
            }
            else
            {

                int result = 0;
                result = Gen.insetCFOFactoriesDet(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", RadioButtonList1.SelectedValue, txtRefNo.Text, txtRefDate.Text, txtFullAddr.Text, txtDateOccu.Text, txtOccuAddr.Text, txtOwnerAddr.Text, ddlDistrict.SelectedValue, ddlMandal.SelectedValue, ddlVillage.SelectedValue, txtPS.Text, txtNearRail.Text, txtProsPetorlClassA.Text, txtPropPetolClassB.Text, txtPropPetrolClassC.Text, txtPropPetrolTotal.Text, txtNotPropPetrolClassA.Text, txtNotPropPetrolClassB.Text, txtNotPropPetrolClassC.Text, txtNotPropPetrolTot.Text, txtProsPetrolTotClassA.Text, txtProsPetrolTotClassB.Text, txtProsPetrolTotClassC.Text, txtProsPetrolGrandTot.Text, txtStorPetrolClassA.Text, txtStorPetrolClassB.Text, txtStorPetrolClassc.Text, txtStorPetrolTot.Text, txtNotStorPetrolClassA.Text, txtNotStorPetrolClassB.Text, txtNotStorPetrolClassC.Text, txtNotStorPetrolTot.Text, txtStorPetrolTotClassA.Text, txtStorPetrolTotClassB.Text, txtStorPetrolTotClassC.Text, txtStorPetrolGrandTot.Text, txtSalesTaxRegDet.Text, txtExpLicDet.Text, Session["uid"].ToString(), Session["uid"].ToString(), ddlLicenseYear.SelectedValue,
                    txtregularinhp.Text.Trim(), txtstandbyHP.Text.Trim(), txtMngrFullNm.Text.Trim(), ddlMngrdistrict.SelectedValue, ddlMngrMandal.SelectedValue, ddlMngrVillage.SelectedValue, txtMngrDoorNo.Text.Trim(), txtMngrstreetName.Text.Trim(),
txtMngrpincode.Text.Trim(), txtMngrMobileNo.Text.Trim(), txtMngrEmail.Text.Trim(), txtOccupierFullNm.Text.Trim(), ddlOccupierDistrict.SelectedValue, ddlOccupierMandal.SelectedValue, ddlOccupierVillage.SelectedValue,
txtOccupierDoorNo.Text.Trim(), txtOccupierStreetNm.Text.Trim(), txtOccupierpincode.Text.Trim(), txtOccupuierMobileNo.Text.Trim(), txtoccupierEmail.Text.Trim(), txtownerFullNm.Text.Trim(), ddlOwnerDistrict.SelectedValue, ddlOwnerMandal.SelectedValue,
ddlOwnerVillage.SelectedValue, txtOwnerDoorNo.Text.Trim(), txtOwnerStreetNm.Text.Trim(), txtOwnerPinCode.Text.Trim(), txtOwnerMobile.Text.Trim(), txtOwnerEmail.Text.Trim());

                if (result > 0)
                {
                    Response.Redirect("frmCAFBoilersDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
                    lblmsg.Text = "<font color='green'>CFO Factory Details Saved Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;

                }
                else
                {
                    lblmsg.Text = "<font color='green'>CFO Enterprenuer Details Submission Failed..!</font>";
                }
            }

        }



    }
    void FillDetails()
    {

        DataSet dsattachment = new DataSet();
        dsattachment = Gen.ViewAttachmentCFO(Session["uid"].ToString());

        if (dsattachment.Tables[0].Rows.Count > 0)
            {
                int c = dsattachment.Tables[0].Rows.Count;
                string sen, sen1, sen2, sennew;
                int i = 0;

                while (i < c)
                {
                    sen2 = dsattachment.Tables[0].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                sennew = dsattachment.Tables[0].Rows[i]["linkview"].ToString();// LINKNEW
                string encpassword = Gen.Encrypt(sennew, "SYSTIME");
                //  sen = sen1.Replace(@"C:/TSiPASS/Attachments/1192/", "~/");//"C:/TSiPASS/Attachments/1192/B1Form\CateogryofRegistration.jpg"
                //sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/Attachments")), "~/");
                if (sen1.Contains("CFOAttachments"))
                    {
                        sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/CFOAttachments")), "~/");
                        if (sen.Contains("PartDeedForm"))
                        {
                            HyperLink3.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink3.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                            Label460.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        }

                        if (sen.Contains("ListofDirForm"))
                        {
                            HyperLink2.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink2.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                            Label461.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        }
                        if (sen.Contains("PlantLayout"))
                        {
                            HyperLink1.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink1.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                            Label14.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        }
                        if (sen.Contains("LandDeedForm"))
                        {
                            HyperLink4.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink4.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                            Label463.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        }
                    if (sen.Contains("WORKERSEMP"))
                    {
                        HYPLISTOFWORKERS.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HYPLISTOFWORKERS.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        LBLLISTOFWORKERS.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                    }
                    if (sen.Contains("PHOTOGRAPH"))
                    {
                        HYPMACHINERYINSTALLED.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HYPMACHINERYINSTALLED.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        LBLMACHINERYINSTALLED.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                    }
                    if (sen.Contains("CHECKLIST"))
                    {
                        HYPSELFCOMP.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HYPSELFCOMP.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        LBLSELFCOMP.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                    }
                }
                    i++;
                }
            }

        DataSet ds = new DataSet();

        ds = Gen.GetdataofCFOFactoriesDet(Session["uid"].ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {
            RadioButtonList1.SelectedValue = ds.Tables[0].Rows[0]["Nature_Manfacture"].ToString();
            txtRefNo.Text = ds.Tables[0].Rows[0]["Plans_Chief_Inspector_RefNo"].ToString();
            if (ds.Tables[0].Rows[0]["Plans_Chief_Inspector_RefDt"].ToString().Trim() != "")
            {
                txtRefDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Plans_Chief_Inspector_RefDt"]).ToString("dd-MMM-yyyy");
            }
            if (ds.Tables[0].Rows[0]["FullN_Res_Address"].ToString() != "")
            {
                trmangrold.Visible = true;
                txtFullAddr.Text = ds.Tables[0].Rows[0]["FullN_Res_Address"].ToString();
            }
            else
            {
                trmangrold.Visible = false;
            }
            if (ds.Tables[0].Rows[0]["Date_Occupation"].ToString().Trim() != "")
            {
                txtDateOccu.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Date_Occupation"]).ToString("dd-MMM-yyyy");
            }
            if (ds.Tables[0].Rows[0]["FullN_Addres_LocalLadFund"].ToString() != "")
            {
                troccupierold.Visible = true;
                txtOccuAddr.Text = ds.Tables[0].Rows[0]["FullN_Addres_LocalLadFund"].ToString();
            }
            else
            {
                troccupierold.Visible = false;
            }
            if (ds.Tables[0].Rows[0]["FullN_Addres_Owner"].ToString() != "")
            {
                trresidentalold.Visible = true;
                txtOwnerAddr.Text = ds.Tables[0].Rows[0]["FullN_Addres_Owner"].ToString();
            }
            else
            {
                trresidentalold.Visible = false;
            }
            getdistricts();
            if (ds.Tables[0].Rows[0]["Petrolium_District"].ToString().Trim() != "")
            {

                //ddlDistrict.SelectedValue = ds.Tables[0].Rows[0]["Petrolium_District"].ToString();
                ddlDistrict.SelectedValue = ddlDistrict.Items.FindByValue(ds.Tables[0].Rows[0]["Petrolium_District"].ToString().Trim()).Value;
            }
            getMandals();
            if (ds.Tables[0].Rows[0]["Petrolium_Mandal"].ToString().Trim() != "")
            {
                //ddlMandal.SelectedValue =  ds.Tables[0].Rows[0]["Petrolium_Mandal"].ToString();

                ddlMandal.SelectedValue = ddlMandal.Items.FindByValue(ds.Tables[0].Rows[0]["Petrolium_Mandal"].ToString().Trim()).Value;
            }
            getVillages();
            if (ds.Tables[0].Rows[0]["Petrolium_Village"].ToString().Trim() != "")
            {
                //ddlVillage.SelectedValue = ds.Tables[0].Rows[0]["Petrolium_Village"].ToString();

                ddlVillage.SelectedValue = ddlVillage.Items.FindByValue(ds.Tables[0].Rows[0]["Petrolium_Village"].ToString().Trim()).Value;
            }
            txtPS.Text = ds.Tables[0].Rows[0]["Petrolium_PoliceStation"].ToString();
            txtNearRail.Text = ds.Tables[0].Rows[0]["Nearest_RailwayStation"].ToString();
            txtProsPetorlClassA.Text = ds.Tables[0].Rows[0]["InBulk_ClassA"].ToString();
            txtPropPetolClassB.Text = ds.Tables[0].Rows[0]["InBulk_ClassB"].ToString();
            txtPropPetrolClassC.Text = ds.Tables[0].Rows[0]["InBulk_CalssC"].ToString();
            txtPropPetrolTotal.Text = ds.Tables[0].Rows[0]["InBulk_Total"].ToString();
            txtNotPropPetrolClassA.Text = ds.Tables[0].Rows[0]["NotinBulk_ClassA"].ToString();
            txtNotPropPetrolClassB.Text = ds.Tables[0].Rows[0]["NotinBulk_ClassB"].ToString();
            txtNotPropPetrolClassC.Text = ds.Tables[0].Rows[0]["NotinBulk_ClassC"].ToString();
            txtNotPropPetrolTot.Text = ds.Tables[0].Rows[0]["NotinBulk_ClassTotal"].ToString();
            txtProsPetrolTotClassA.Text = ds.Tables[0].Rows[0]["Total_Class_A"].ToString();
            txtProsPetrolTotClassB.Text = ds.Tables[0].Rows[0]["Total_Class_B"].ToString();
            txtProsPetrolTotClassC.Text = ds.Tables[0].Rows[0]["Total_Class_C"].ToString();
            txtProsPetrolGrandTot.Text = ds.Tables[0].Rows[0]["Total_Totals"].ToString();
            txtStorPetrolClassA.Text = ds.Tables[0].Rows[0]["Stored_InBulk_ClassA"].ToString();
            txtStorPetrolClassB.Text = ds.Tables[0].Rows[0]["Stored_InBulk_ClassB"].ToString();
            txtStorPetrolClassc.Text = ds.Tables[0].Rows[0]["Stored_InBulk_CalssC"].ToString();
            txtStorPetrolTot.Text = ds.Tables[0].Rows[0]["Stored_InBulk_Total"].ToString();
            txtNotStorPetrolClassA.Text = ds.Tables[0].Rows[0]["Stored_NotinBulk_ClassA"].ToString();
            txtNotStorPetrolClassB.Text = ds.Tables[0].Rows[0]["Stored_NotinBulk_ClassB"].ToString();
            txtNotStorPetrolClassC.Text = ds.Tables[0].Rows[0]["Stored_NotinBulk_ClassC"].ToString();
            txtNotStorPetrolTot.Text = ds.Tables[0].Rows[0]["Stored_NotinBulk_ClassTotal"].ToString();
            txtStorPetrolTotClassA.Text = ds.Tables[0].Rows[0]["Stored_Total_Class_A"].ToString();
            txtStorPetrolTotClassB.Text = ds.Tables[0].Rows[0]["Stored_Total_Class_B"].ToString();
            txtStorPetrolTotClassC.Text = ds.Tables[0].Rows[0]["Stored_Total_Class_C"].ToString();
            txtStorPetrolGrandTot.Text = ds.Tables[0].Rows[0]["Stored_Total_Totals"].ToString();
            txtSalesTaxRegDet.Text = ds.Tables[0].Rows[0]["SalesTaxDetails"].ToString();
            txtExpLicDet.Text = ds.Tables[0].Rows[0]["Exploside_LicenseDetails"].ToString();
            if (ds.Tables[0].Rows[0]["LicenseYear"].ToString().Trim() != "" && ds.Tables[0].Rows[0]["LicenseYear"].ToString().Trim() != "0")
            {
                ddlLicenseYear.SelectedValue = ddlLicenseYear.Items.FindByValue(ds.Tables[0].Rows[0]["LicenseYear"].ToString().Trim()).Value;
            }
            if (ds.Tables[0].Rows[0]["RegularHp"].ToString().Trim() != "")
            {
                txtregularinhp.Text = ds.Tables[0].Rows[0]["RegularHp"].ToString().Trim();
            }
            if (ds.Tables[0].Rows[0]["StandbyHp"].ToString().Trim() != "")
            {
                txtstandbyHP.Text = ds.Tables[0].Rows[0]["StandbyHp"].ToString().Trim();
            }
            if (ds.Tables[0].Rows[0]["Mangr_Full_Name"].ToString().Trim() != "")
            {
                txtMngrFullNm.Text = ds.Tables[0].Rows[0]["Mangr_Full_Name"].ToString();
            }
            if (ds.Tables[0].Rows[0]["Mangr_DoorNo"].ToString().Trim() != "")
            {
                txtMngrDoorNo.Text = ds.Tables[0].Rows[0]["Mangr_DoorNo"].ToString().Trim();
            }
            if (ds.Tables[0].Rows[0]["Mangr_Locality"].ToString().Trim() != "")
            {
                txtMngrstreetName.Text = ds.Tables[0].Rows[0]["Mangr_Locality"].ToString().Trim();
            }
            if (ds.Tables[0].Rows[0]["Mangr_District"].ToString().Trim() != "")
            {
                ddlMngrdistrict.SelectedValue = ddlMngrdistrict.Items.FindByValue(ds.Tables[0].Rows[0]["Mangr_District"].ToString().Trim()).Value;
            }
            getMandalsmanager();
            if (ds.Tables[0].Rows[0]["Mangr_Mandal"].ToString().Trim() != "")
            {
                ddlMngrMandal.SelectedValue = ddlMngrMandal.Items.FindByValue(ds.Tables[0].Rows[0]["Mangr_Mandal"].ToString().Trim()).Value;
            }
            getVillagesmanager();
            if (ds.Tables[0].Rows[0]["Mangr_Village"].ToString().Trim() != "")
            {
                ddlMngrVillage.SelectedValue = ddlMngrVillage.Items.FindByValue(ds.Tables[0].Rows[0]["Mangr_Village"].ToString().Trim()).Value;
            }
            if (ds.Tables[0].Rows[0]["Mangr_PinCode"].ToString().Trim() != "")
            {
                txtMngrpincode.Text = ds.Tables[0].Rows[0]["Mangr_PinCode"].ToString().Trim();
            }
            if (ds.Tables[0].Rows[0]["Mangr_EmailId"].ToString().Trim() != "")
            {
                txtMngrEmail.Text = ds.Tables[0].Rows[0]["Mangr_EmailId"].ToString().Trim();
            }
            if (ds.Tables[0].Rows[0]["Mangr_MobileNo"].ToString().Trim() != "")
            {
                txtMngrMobileNo.Text = ds.Tables[0].Rows[0]["Mangr_MobileNo"].ToString().Trim();
            }
            if (ds.Tables[0].Rows[0]["Occupier_Full_Name"].ToString().Trim() != "")
            {
                txtOccupierFullNm.Text = ds.Tables[0].Rows[0]["Occupier_Full_Name"].ToString().Trim();
            }

            if (ds.Tables[0].Rows[0]["Occupier_DoorNo"].ToString().Trim() != "")
            {
                txtOccupierDoorNo.Text = ds.Tables[0].Rows[0]["Occupier_DoorNo"].ToString().Trim();
            }
            if (ds.Tables[0].Rows[0]["Occupier_Locality"].ToString().Trim() != "")
            {
                txtOccupierStreetNm.Text = ds.Tables[0].Rows[0]["Occupier_Locality"].ToString().Trim();
            }
            if (ds.Tables[0].Rows[0]["Occupier_District"].ToString().Trim() != "")
            {
                ddlOccupierDistrict.SelectedValue = ddlOccupierDistrict.Items.FindByValue(ds.Tables[0].Rows[0]["Occupier_District"].ToString().Trim()).Value;
            }
            getMandalsOccupier();
            if (ds.Tables[0].Rows[0]["Occupier_Mandal"].ToString().Trim() != "")
            {
                ddlOccupierMandal.SelectedValue = ddlOccupierMandal.Items.FindByValue(ds.Tables[0].Rows[0]["Occupier_Mandal"].ToString().Trim()).Value;
            }
            getVillagesOccupier();
            if (ds.Tables[0].Rows[0]["Occupier_Village"].ToString().Trim() != "")
            {
                ddlOccupierVillage.SelectedValue = ddlOccupierVillage.Items.FindByValue(ds.Tables[0].Rows[0]["Occupier_Village"].ToString().Trim()).Value;
            }
            if (ds.Tables[0].Rows[0]["Occupier_PinCode"].ToString().Trim() != "")
            {
                txtOccupierpincode.Text = ds.Tables[0].Rows[0]["Occupier_PinCode"].ToString().Trim();
            }
            if (ds.Tables[0].Rows[0]["Occupier_EmailId"].ToString().Trim() != "")
            {
                txtoccupierEmail.Text = ds.Tables[0].Rows[0]["Occupier_EmailId"].ToString().Trim();
            }
            if (ds.Tables[0].Rows[0]["Occupier_MobileNo"].ToString().Trim() != "")
            {
                txtOccupuierMobileNo.Text = ds.Tables[0].Rows[0]["Occupier_MobileNo"].ToString().Trim();
            }
            if (ds.Tables[0].Rows[0]["Owner_Full_Name"].ToString().Trim() != "")
            {
                txtownerFullNm.Text = ds.Tables[0].Rows[0]["Owner_Full_Name"].ToString().Trim();
            }
            if (ds.Tables[0].Rows[0]["Owner_DoorNo"].ToString().Trim() != "")
            {
                txtOwnerDoorNo.Text = ds.Tables[0].Rows[0]["Owner_DoorNo"].ToString().Trim();
            }
            if (ds.Tables[0].Rows[0]["Owner_Locality"].ToString().Trim() != "")
            {
                txtOwnerStreetNm.Text = ds.Tables[0].Rows[0]["Owner_Locality"].ToString().Trim();
            }
            if (ds.Tables[0].Rows[0]["Owner_District"].ToString().Trim() != "")
            {
                ddlOwnerDistrict.SelectedValue = ddlOwnerDistrict.Items.FindByValue(ds.Tables[0].Rows[0]["Owner_District"].ToString().Trim()).Value;
            }
            getMandalsOwner();
            if (ds.Tables[0].Rows[0]["Owner_Mandal"].ToString().Trim() != "")
            {
                ddlOwnerMandal.SelectedValue = ddlOwnerMandal.Items.FindByValue(ds.Tables[0].Rows[0]["Owner_Mandal"].ToString().Trim()).Value;
            }
            getVillagesOwner();
            if (ds.Tables[0].Rows[0]["Owner_Village"].ToString().Trim() != "")
            {
                ddlOwnerVillage.SelectedValue = ddlOwnerVillage.Items.FindByValue(ds.Tables[0].Rows[0]["Owner_Village"].ToString().Trim()).Value;
            }
            if (ds.Tables[0].Rows[0]["Owner_PinCode"].ToString().Trim() != "")
            {
                txtOwnerPinCode.Text = ds.Tables[0].Rows[0]["Owner_PinCode"].ToString().Trim();
            }
            if (ds.Tables[0].Rows[0]["Owner_EmailId"].ToString().Trim() != "")
            {
                txtOwnerEmail.Text = ds.Tables[0].Rows[0]["Owner_EmailId"].ToString().Trim();
            }
            if (ds.Tables[0].Rows[0]["Owner_MobileNo"].ToString().Trim() != "")
            {
               txtOwnerMobile.Text = ds.Tables[0].Rows[0]["Owner_MobileNo"].ToString().Trim();
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
    protected void ddlstatus32_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlstatus31_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMandal.SelectedValue.ToString() != "")
        {
            getVillages();
        }
        else
        {
            ddlMandal.Items.Clear();
            ddlMandal.Items.Insert(0, "--Select--");
        }
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDistrict.SelectedValue.ToString() != "")
        {
            getMandals();
        }
        else
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Insert(0, "--Select--");
        }
    }
    protected void txtProsPetrolTotClassA_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtProsPetorlClassA_TextChanged(object sender, EventArgs e)
    {
        if (txtProsPetorlClassA.Text == "")
        {

            txtProsPetorlClassA.Text = "0";
        }
        if (txtPropPetolClassB.Text == "")
        {
            txtPropPetolClassB.Text = "0";
        }
        if (txtPropPetrolClassC.Text == "")
        {
            txtPropPetrolClassC.Text = "0";
        }
        if (txtNotPropPetrolClassA.Text == "")
        {
            txtNotPropPetrolClassA.Text = "0";
        }

        if (txtNotPropPetrolTot.Text == "")
        {
            txtNotPropPetrolTot.Text = "0";
        }
        txtPropPetrolTotal.Text = (Convert.ToDecimal(txtProsPetorlClassA.Text) + Convert.ToDecimal(txtPropPetolClassB.Text) + Convert.ToDecimal(txtPropPetrolClassC.Text)).ToString();
        txtProsPetrolTotClassA.Text = (Convert.ToDecimal(txtProsPetorlClassA.Text) + Convert.ToDecimal(txtNotPropPetrolClassA.Text)).ToString();
        txtProsPetrolGrandTot.Text = (Convert.ToDecimal(txtPropPetrolTotal.Text) + Convert.ToDecimal(txtNotPropPetrolTot.Text)).ToString();
    }
    protected void txtPropPetolClassB_TextChanged(object sender, EventArgs e)
    {
        if (txtProsPetorlClassA.Text == "")
        {
            txtProsPetorlClassA.Text = "0";

        }
        if (txtPropPetolClassB.Text == "")
        {

            txtPropPetolClassB.Text = "0";
        }
        if (txtPropPetrolClassC.Text == "")
        {
            txtPropPetrolClassC.Text = "0";
        }
        if (txtNotPropPetrolClassB.Text == "")
        {
            txtNotPropPetrolClassB.Text = "0";
        }
        if (txtNotPropPetrolTot.Text == "")
        {
            txtNotPropPetrolTot.Text = "0";
        }
        txtPropPetrolTotal.Text = (Convert.ToDecimal(txtProsPetorlClassA.Text) + Convert.ToDecimal(txtPropPetolClassB.Text) + Convert.ToDecimal(txtPropPetrolClassC.Text)).ToString();
        txtProsPetrolTotClassB.Text = (Convert.ToDecimal(txtPropPetolClassB.Text) + Convert.ToDecimal(txtNotPropPetrolClassB.Text)).ToString();
        txtProsPetrolGrandTot.Text = (Convert.ToDecimal(txtPropPetrolTotal.Text) + Convert.ToDecimal(txtNotPropPetrolTot.Text)).ToString();
    }
    protected void txtPropPetrolClassC_TextChanged(object sender, EventArgs e)
    {

        if (txtProsPetorlClassA.Text == "")
        {
            txtProsPetorlClassA.Text = "0";
        }
        if (txtPropPetolClassB.Text == "")
        {
            txtPropPetolClassB.Text = "0";

        }
        if (txtPropPetrolClassC.Text == "")
        {
            txtPropPetrolClassC.Text = "0";
        }

        if (txtNotPropPetrolClassC.Text == "")
        {

            txtNotPropPetrolClassC.Text = "0";
        }
        if (txtNotPropPetrolTot.Text == "")
        {
            txtNotPropPetrolTot.Text = "0";
        }

        txtPropPetrolTotal.Text = (Convert.ToDecimal(txtProsPetorlClassA.Text) + Convert.ToDecimal(txtPropPetolClassB.Text) + Convert.ToDecimal(txtPropPetrolClassC.Text)).ToString();
        txtProsPetrolTotClassC.Text = (Convert.ToDecimal(txtPropPetrolClassC.Text) + Convert.ToDecimal(txtNotPropPetrolClassC.Text)).ToString();
        txtProsPetrolGrandTot.Text = (Convert.ToDecimal(txtPropPetrolTotal.Text) + Convert.ToDecimal(txtNotPropPetrolTot.Text)).ToString();
    }
    protected void txtNotPropPetrolClassA_TextChanged(object sender, EventArgs e)
    {
        if (txtNotPropPetrolClassA.Text == "")
        {
            txtNotPropPetrolClassA.Text = "0";
        }
        if (txtNotPropPetrolClassB.Text == "")
        {
            txtNotPropPetrolClassB.Text = "0";

        }
        if (txtNotPropPetrolClassC.Text == "")
        {
            txtNotPropPetrolClassC.Text = "0";
        }

        if (txtProsPetorlClassA.Text == "")
        {
            txtProsPetorlClassA.Text = "0";
        }

        if (txtPropPetrolTotal.Text == "")
        {
            txtPropPetrolTotal.Text = "0";
        }
        txtNotPropPetrolTot.Text = (Convert.ToDecimal(txtNotPropPetrolClassA.Text) + Convert.ToDecimal(txtNotPropPetrolClassB.Text) + Convert.ToDecimal(txtNotPropPetrolClassC.Text)).ToString();
        txtProsPetrolTotClassA.Text = (Convert.ToDecimal(txtProsPetorlClassA.Text) + Convert.ToDecimal(txtNotPropPetrolClassA.Text)).ToString(); ;
        txtProsPetrolGrandTot.Text = (Convert.ToDecimal(txtPropPetrolTotal.Text) + Convert.ToDecimal(txtNotPropPetrolTot.Text)).ToString();
    }
    protected void txtNotPropPetrolClassB_TextChanged(object sender, EventArgs e)
    {

        if (txtNotPropPetrolClassA.Text == "")
        {
            txtNotPropPetrolClassA.Text = "0";
        }
        if (txtNotPropPetrolClassB.Text == "")
        {
            txtNotPropPetrolClassB.Text = "0";

        }
        if (txtNotPropPetrolClassC.Text == "")
        {
            txtNotPropPetrolClassC.Text = "0";
        }
        if (txtPropPetolClassB.Text == "")
        {
            txtPropPetolClassB.Text = "0";
        }
        if (txtPropPetrolTotal.Text == "")
        {
            txtPropPetrolTotal.Text = "0";
        }

        txtNotPropPetrolTot.Text = (Convert.ToDecimal(txtNotPropPetrolClassA.Text) + Convert.ToDecimal(txtNotPropPetrolClassB.Text) + Convert.ToDecimal(txtNotPropPetrolClassC.Text)).ToString();
        txtProsPetrolTotClassB.Text = (Convert.ToDecimal(txtPropPetolClassB.Text) + Convert.ToDecimal(txtNotPropPetrolClassB.Text)).ToString();
        txtProsPetrolGrandTot.Text = (Convert.ToDecimal(txtPropPetrolTotal.Text) + Convert.ToDecimal(txtNotPropPetrolTot.Text)).ToString();
    }
    protected void txtNotPropPetrolClassC_TextChanged(object sender, EventArgs e)
    {
        if (txtNotPropPetrolClassA.Text == "")
        {
            txtNotPropPetrolClassA.Text = "0";
        }
        if (txtNotPropPetrolClassB.Text == "")
        {
            txtNotPropPetrolClassB.Text = "0";

        }
        if (txtNotPropPetrolClassC.Text == "")
        {
            txtNotPropPetrolClassC.Text = "0";
        }
        if (txtPropPetrolClassC.Text == "")
        {
            txtPropPetrolClassC.Text = "0";
        }

        if (txtPropPetrolTotal.Text == "")
        {
            txtPropPetrolTotal.Text = "0";
        }

        txtNotPropPetrolTot.Text = (Convert.ToDecimal(txtNotPropPetrolClassA.Text) + Convert.ToDecimal(txtNotPropPetrolClassB.Text) + Convert.ToDecimal(txtNotPropPetrolClassC.Text)).ToString();
        txtProsPetrolTotClassC.Text = (Convert.ToDecimal(txtPropPetrolClassC.Text) + Convert.ToDecimal(txtNotPropPetrolClassC.Text)).ToString();
        txtProsPetrolGrandTot.Text = (Convert.ToDecimal(txtPropPetrolTotal.Text) + Convert.ToDecimal(txtNotPropPetrolTot.Text)).ToString();
    }
    protected void txtStorPetrolClassA_TextChanged(object sender, EventArgs e)
    {
        if (txtStorPetrolClassA.Text == "")
        {
            txtStorPetrolClassA.Text = "0";
        }

        if (txtStorPetrolClassB.Text == "")
        {
            txtStorPetrolClassB.Text = "0";
        }
        if (txtStorPetrolClassc.Text == "")
        {
            txtStorPetrolClassc.Text = "0";
        }
        if (txtNotStorPetrolClassA.Text == "")
        {
            txtNotStorPetrolClassA.Text = "0";
        }
        if (txtNotStorPetrolTot.Text == "")
        {
            txtNotStorPetrolTot.Text = "0";
        }
        txtStorPetrolTot.Text = (Convert.ToDecimal(txtStorPetrolClassA.Text) + Convert.ToDecimal(txtStorPetrolClassB.Text) + Convert.ToDecimal(txtStorPetrolClassc.Text)).ToString();
        txtStorPetrolTotClassA.Text = (Convert.ToDecimal(txtStorPetrolClassA.Text) + Convert.ToDecimal(txtNotStorPetrolClassA.Text)).ToString();
        txtStorPetrolGrandTot.Text = (Convert.ToDecimal(txtStorPetrolTot.Text) + Convert.ToDecimal(txtNotStorPetrolTot.Text)).ToString();
    }
    protected void txtStorPetrolClassB_TextChanged(object sender, EventArgs e)
    {
        if (txtStorPetrolClassA.Text == "")
        {
            txtStorPetrolClassA.Text = "0";
        }

        if (txtStorPetrolClassB.Text == "")
        {
            txtStorPetrolClassB.Text = "0";
        }
        if (txtStorPetrolClassc.Text == "")
        {
            txtStorPetrolClassc.Text = "0";
        }

        if (txtNotStorPetrolTot.Text == "")
        {
            txtNotStorPetrolTot.Text = "0";
        }
        if (txtNotStorPetrolClassB.Text == "")
        {
            txtNotStorPetrolClassB.Text = "0";
        }
        txtStorPetrolTot.Text = (Convert.ToDecimal(txtStorPetrolClassA.Text) + Convert.ToDecimal(txtStorPetrolClassB.Text) + Convert.ToDecimal(txtStorPetrolClassc.Text)).ToString();
        txtStorPetrolGrandTot.Text = (Convert.ToDecimal(txtStorPetrolTot.Text) + Convert.ToDecimal(txtNotStorPetrolTot.Text)).ToString();
        txtStorPetrolTotClassB.Text = (Convert.ToDecimal(txtStorPetrolClassB.Text) + Convert.ToDecimal(txtNotStorPetrolClassB.Text)).ToString();
    }
    protected void txtStorPetrolClassc_TextChanged(object sender, EventArgs e)
    {
        if (txtStorPetrolClassA.Text == "")
        {
            txtStorPetrolClassA.Text = "0";
        }

        if (txtStorPetrolClassB.Text == "")
        {
            txtStorPetrolClassB.Text = "0";
        }
        if (txtStorPetrolClassc.Text == "")
        {
            txtStorPetrolClassc.Text = "0";
        }
        if (txtNotStorPetrolTot.Text == "")
        {
            txtNotStorPetrolTot.Text = "0";
        }
        if (txtNotStorPetrolClassC.Text == "")
        {
            txtNotStorPetrolClassC.Text = "0";
        }
        txtStorPetrolTot.Text = (Convert.ToDecimal(txtStorPetrolClassA.Text) + Convert.ToDecimal(txtStorPetrolClassB.Text) + Convert.ToDecimal(txtStorPetrolClassc.Text)).ToString();
        txtStorPetrolGrandTot.Text = (Convert.ToDecimal(txtStorPetrolTot.Text) + Convert.ToDecimal(txtNotStorPetrolTot.Text)).ToString();
        txtStorPetrolTotClassC.Text = (Convert.ToDecimal(txtStorPetrolClassc.Text) + Convert.ToDecimal(txtNotStorPetrolClassC.Text)).ToString();
    }
    protected void txtNotStorPetrolClassA_TextChanged(object sender, EventArgs e)
    {

        if (txtNotStorPetrolClassA.Text == "")
        {
            txtNotStorPetrolClassA.Text = "0";
        }
        if (txtNotStorPetrolClassB.Text == "")
        {
            txtNotStorPetrolClassB.Text = "0";
        }
        if (txtNotStorPetrolClassC.Text == "")
        {
            txtNotStorPetrolClassC.Text = "0";
        }
        if (txtStorPetrolClassA.Text == "")
        {
            txtStorPetrolClassA.Text = "0";
        }
        if (txtStorPetrolTot.Text == "")
        {
            txtStorPetrolTot.Text = "0";
        }
        txtNotStorPetrolTot.Text = (Convert.ToDecimal(txtNotStorPetrolClassA.Text) + Convert.ToDecimal(txtNotStorPetrolClassB.Text) + Convert.ToDecimal(txtNotStorPetrolClassC.Text)).ToString();
        txtStorPetrolTotClassA.Text = (Convert.ToDecimal(txtStorPetrolClassA.Text) + Convert.ToDecimal(txtNotStorPetrolClassA.Text)).ToString();
        txtStorPetrolGrandTot.Text = (Convert.ToDecimal(txtStorPetrolTot.Text) + Convert.ToDecimal(txtNotStorPetrolTot.Text)).ToString();
    }
    protected void txtNotStorPetrolClassB_TextChanged(object sender, EventArgs e)
    {

        if (txtNotStorPetrolClassA.Text == "")
        {
            txtNotStorPetrolClassA.Text = "0";
        }
        if (txtNotStorPetrolClassB.Text == "")
        {
            txtNotStorPetrolClassB.Text = "0";
        }
        if (txtNotStorPetrolClassC.Text == "")
        {
            txtNotStorPetrolClassC.Text = "0";
        }

        if (txtStorPetrolTot.Text == "")
        {
            txtStorPetrolTot.Text = "0";
        }
        if (txtStorPetrolClassB.Text == "")
        {
            txtStorPetrolClassB.Text = "0";
        }
        txtNotStorPetrolTot.Text = (Convert.ToDecimal(txtNotStorPetrolClassA.Text) + Convert.ToDecimal(txtNotStorPetrolClassB.Text) + Convert.ToDecimal(txtNotStorPetrolClassC.Text)).ToString();
        txtStorPetrolGrandTot.Text = (Convert.ToDecimal(txtStorPetrolTot.Text) + Convert.ToDecimal(txtNotStorPetrolTot.Text)).ToString();
        txtStorPetrolTotClassB.Text = (Convert.ToDecimal(txtStorPetrolClassB.Text) + Convert.ToDecimal(txtNotStorPetrolClassB.Text)).ToString();
    }
    protected void txtNotStorPetrolClassC_TextChanged(object sender, EventArgs e)
    {
        if (txtNotStorPetrolClassA.Text == "")
        {
            txtNotStorPetrolClassA.Text = "0";
        }
        if (txtNotStorPetrolClassB.Text == "")
        {
            txtNotStorPetrolClassB.Text = "0";
        }
        if (txtNotStorPetrolClassC.Text == "")
        {
            txtNotStorPetrolClassC.Text = "0";
        }

        if (txtStorPetrolTot.Text == "")
        {
            txtStorPetrolTot.Text = "0";
        }
        if (txtStorPetrolClassc.Text == "")
        {
            txtStorPetrolClassc.Text = "0";
        }
        txtNotStorPetrolTot.Text = (Convert.ToDecimal(txtNotStorPetrolClassA.Text) + Convert.ToDecimal(txtNotStorPetrolClassB.Text) + Convert.ToDecimal(txtNotStorPetrolClassC.Text)).ToString();
        txtStorPetrolGrandTot.Text = (Convert.ToDecimal(txtStorPetrolTot.Text) + Convert.ToDecimal(txtNotStorPetrolTot.Text)).ToString();
        txtStorPetrolTotClassC.Text = (Convert.ToDecimal(txtStorPetrolClassc.Text) + Convert.ToDecimal(txtNotStorPetrolClassC.Text)).ToString();
    }
    protected void BtnDelete0_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmCAFPowerDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&Previous=" + "P");
    }
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlMngrdistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMngrdistrict.SelectedValue.ToString() != "")
        {
            getMandalsmanager();
        }
        else
        {
            ddlMngrdistrict.Items.Clear();
            ddlMngrdistrict.Items.Insert(0, "--Select--");
        }
    }
    protected void ddlOccupierDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlOccupierDistrict.SelectedValue.ToString() != "")
        {
            getMandalsOccupier();
        }
        else
        {
            ddlOccupierDistrict.Items.Clear();
            ddlOccupierDistrict.Items.Insert(0, "--Select--");
        }
    }
    protected void ddlOwnerDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlOwnerDistrict.SelectedValue.ToString() != "")
        {
            getMandalsOwner();
        }
        else
        {
            ddlOwnerDistrict.Items.Clear();
            ddlOwnerDistrict.Items.Insert(0, "--Select--");
        }
    }
    protected void ddlOccupierMandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlOccupierMandal.SelectedValue.ToString() != "")
        {
            getVillagesOccupier();
        }
        else
        {
            ddlOccupierMandal.Items.Clear();
            ddlOccupierMandal.Items.Insert(0, "--Select--");
        }
    }
    protected void ddlOwnerMandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlOwnerMandal.SelectedValue.ToString() != "")
        {
            getVillagesOwner();
        }
        else
        {
            ddlOwnerMandal.Items.Clear();
            ddlOwnerMandal.Items.Insert(0, "--Select--");
        }
    }
    protected void ddlMngrMandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMngrMandal.SelectedValue.ToString() != "")
        {
            getVillagesmanager();
        }
        else
        {
            ddlMngrMandal.Items.Clear();
            ddlMngrMandal.Items.Insert(0, "--Select--");
        }
    }
    protected void BtnListofDir1_Click(object sender, EventArgs e)
    {


        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if (FileUpload15.HasFile)
        {
            if ((FileUpload15.PostedFile != null) && (FileUpload15.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload15.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUpload15.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\PlantLayout");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload15.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload15.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "PlantLayout");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink1.Text = FileUpload15.FileName;
                            HyperLink1.Text = FileUpload15.FileName;
                            Label18.Visible = true;
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

    protected void BtnListofDir_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if (FileUpload11.HasFile)
        {
            if ((FileUpload11.PostedFile != null) && (FileUpload11.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload11.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUpload11.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\ListofDirForm");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload11.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload11.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ListofDirFORM");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink2.Text = FileUpload11.FileName;
                            HyperLink2.Text = FileUpload11.FileName;
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

    protected void BtnPartDeed_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

            General t1 = new General();
            if (FileUpload10.HasFile)
            {
                if ((FileUpload10.PostedFile != null) && (FileUpload10.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(FileUpload10.PostedFile.FileName);
                    try
                    {

                        string[] fileType = FileUpload10.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\PartDeedForm");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload10.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload10.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;

                            result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "PartDeedFORM");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                HyperLink3.Text = FileUpload10.FileName;
                                HyperLink3.Text = FileUpload10.FileName;
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void BtnLandDeed_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

            General t1 = new General();
            if (FileUpload13.HasFile)
            {
                if ((FileUpload13.PostedFile != null) && (FileUpload13.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(FileUpload13.PostedFile.FileName);
                    try
                    {

                        string[] fileType = FileUpload13.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\LandDeedForm");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload13.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload13.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;

                            result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "LandDeedFORM");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                HyperLink4.Text = FileUpload13.FileName;
                                HyperLink4.Text = FileUpload13.FileName;
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void BTNLISTOFWORKERS_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

            General t1 = new General();
            if (FUPLISTOFWORKERS.HasFile)
            {
                if ((FUPLISTOFWORKERS.PostedFile != null) && (FUPLISTOFWORKERS.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(FUPLISTOFWORKERS.PostedFile.FileName);
                    try
                    {

                        string[] fileType = FUPLISTOFWORKERS.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                        {
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\LISTOFWORKERSEMPLOYED");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FUPLISTOFWORKERS.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FUPLISTOFWORKERS.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;

                            result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "LISTOFWORKERSEMPLOYED");


                            if (result > 0)
                            {
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                HYPLISTOFWORKERS.Text = FUPLISTOFWORKERS.FileName;
                                HYPLISTOFWORKERS.Text = FUPLISTOFWORKERS.FileName;
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
                    catch (Exception)
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }

    }

    protected void BTNMACHINERYINSTALLED_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

            General t1 = new General();
            if (FUPMACHINERYINSTALLED.HasFile)
            {
                if ((FUPMACHINERYINSTALLED.PostedFile != null) && (FUPMACHINERYINSTALLED.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(FUPMACHINERYINSTALLED.PostedFile.FileName);
                    try
                    {

                        string[] fileType = FUPMACHINERYINSTALLED.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                        {
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\MACHINERYINSTALLEDPHOTOGRAPH");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FUPMACHINERYINSTALLED.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FUPMACHINERYINSTALLED.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;

                            result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "MACHINERYINSTALLEDPHOTOGRAPH");


                            if (result > 0)
                            {
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                HYPMACHINERYINSTALLED.Text = FUPMACHINERYINSTALLED.FileName;
                                HYPMACHINERYINSTALLED.Text = FUPMACHINERYINSTALLED.FileName;
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
                    catch (Exception)
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }

    }

    protected void BTNSELFCOMP_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

            General t1 = new General();
            if (FUPSELFCOMP.HasFile)
            {
                if ((FUPSELFCOMP.PostedFile != null) && (FUPSELFCOMP.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(FUPSELFCOMP.PostedFile.FileName);
                    try
                    {

                        string[] fileType = FUPSELFCOMP.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                        {
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\SELFCOMPLIANCECHECKLIST");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FUPSELFCOMP.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FUPSELFCOMP.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;

                            result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "SELFCOMPLIANCECHECKLIST");


                            if (result > 0)
                            {
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                HYPSELFCOMP.Text = FUPSELFCOMP.FileName;
                                HYPSELFCOMP.Text = FUPSELFCOMP.FileName;
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
                    catch (Exception)
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
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }

    }
}
