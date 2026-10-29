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
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Net;

public partial class UI_TSiPASS_frmBoilerRenewals : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    WebClient wc = new WebClient();
    BoilerService.renewalPaymentDetails BoilerPaymentRenewal = new BoilerService.renewalPaymentDetails();
    BoilerService.TSBoilerServiceImplService BoilerRenewal = new BoilerService.TSBoilerServiceImplService();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }

        if (!IsPostBack)
        {
            DataSet dsnew = new DataSet();
            dsnew = Gen.getdataofidentityRENAPPROVALID(Request.QueryString[0].ToString(), "55");//Session["Applid"].ToString()
            if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
            {

                if (!IsPostBack)
                {
                    
                    getstates();
                    BindDistricts();
                    DataSet ds = new DataSet();
                    ds = Gen.GetdataofRENEWALBoiler(Request.QueryString[0].ToString());

                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        FillDetails();

                    }
                }
            }
            else
            {
                if (Request.QueryString[1].ToString() == "N")
                {
                    //Response.Redirect("frmDepartmentRenewalPaymentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                    Response.Redirect("frmFactoryRenewal.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                }
                else
                {
                   // Response.Redirect("frmLabourShopRenewal.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");
                    Response.Redirect("frmRenWaterDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");
                }
            }
        }
        if (!IsPostBack)
        {
            //Session["Applid"] = "0";
            if (!IsPostBack)
            {
                DataSet dscheck = new DataSet();
                dscheck = Gen.GetShowRenewalQuestionaries(Session["uid"].ToString().Trim(), Request.QueryString[0].ToString());
                if (dscheck != null && dscheck.Tables.Count > 0 && dscheck.Tables[0].Rows.Count > 0)
                {
                    Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
                }
                else
                {
                    Session["Applid"] = "0";
                }
                if (dscheck != null && dscheck.Tables.Count > 0 && dscheck.Tables[0].Rows.Count > 0)
                {

                    if (Convert.ToInt32(dscheck.Tables[0].Rows[0]["Approval_Status"].ToString()) >= 3)
                    {

                        // ResetFormControl(this);

                    }
                }

                //DataSet ds = new DataSet();
                //ds = Gen.ViewAttachmentCFO(Session["uid"].ToString());

                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    FillDetails();
                //}
            }
            

            
        }

        if (!IsPostBack)
        {

            //DataSet dsver = new DataSet();

            //dsver = Gen.GetverifyofqueBoiler9CFO(Session["ApplidA"].ToString());

            //if (dsver.Tables[0].Rows.Count > 0)
            //{
            //    string res = Gen.RetriveStatusCFO(Session["ApplidA"].ToString());
            //    ////string res = Gen.RetriveStatus("1002");


            //    if (res == "3" || Convert.ToInt32(res) >= 3)
            //    {
            //        ResetFormControl(this);
            //        ViewState["Enable"] = "Y";
            //    }

            //}

        }


        if (!IsPostBack)
        {
            //string res = Gen.RetriveStatusBoilersCFO(Session["ApplidA"].ToString());

            //if (res == "Y")
            //{

            //}
            //DataSet dsnew = new DataSet();
            //dsnew = Gen.getdataofidentityCFONew(Session["ApplidA"].ToString(), "56");
            //if (dsnew.Tables[0].Rows.Count > 0)
            //{

            //}
            //else
            //{
            //    if (Request.QueryString[1].ToString() == "N")
            //    {

            //        Response.Redirect("frmCFOPCBDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");

            //    }
            //    else
            //    {
            //        Response.Redirect("frmCAFFactoryDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&Previous=" + "P");

            //    }

            //}



        }

        

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {

        }
    }

    protected void getstates()
    {
        DataSet ds = new DataSet();
        ds = Gen.getStates();

        ddlState.DataSource = ds.Tables[0];
        ddlState.DataTextField = "State_Name";
        ddlState.DataValueField = "State_id";
        ddlState.DataBind();
        ddlState.Items.Insert(0, "--Select--");

    }


    //public void ResetFormControl(Control parent)
    //{
    //    foreach (Control c in parent.Controls)
    //    {
    //        if (c.Controls.Count > 0)
    //        {
    //            ResetFormControl(c);
    //        }
    //        else
    //        {
    //            switch (c.GetType().ToString())
    //            {
    //                case "System.Web.UI.WebControls.TextBox":
    //                    ((TextBox)c).ReadOnly = true;
    //                    break;

    //                case "System.Web.UI.WebControls.DropDownList":

    //                    if (((DropDownList)c).Items.Count > 0)
    //                    {
    //                        ((DropDownList)c).Enabled = false;
    //                    }
    //                    break;
    //                case "System.Web.UI.WebControls.FileUpload":
    //                    ((FileUpload)c).Enabled = false;
    //                    break;
    //                case "System.Web.UI.WebControls.RadioButtonList":
    //                    ((RadioButtonList)c).Enabled = false;
    //                    break;

    //                case "System.Web.UI.WebControls.CheckBoxList":
    //                    ((CheckBoxList)c).Enabled = false;
    //                    break;
    //            }
    //        }
    //    }
    //}

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {

        if (BtnSave1.Text == "Save")
        {
            //if (Convert.ToInt32(Convert.ToString(txtBoilerRatingSurface.Text)) < 5)
            //{
            //    lblmsg0.Text = "<font color='red'>Boiler Rating/Heating Surface should not be less than 5..!</font>";
            //    success.Visible = false;
            //    Failure.Visible = true;
            //    return;
            //}
            if (trerector.Visible && trerector.Visible)// if new registration
            {
                if (LabelErector.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload Erector Attachment..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
            if (trreqdoc.Visible)
            {
                if (LabelRequiredDoc.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload Required Document Attachment..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
            if (trotherdoc.Visible)
            {
                if (LabelOtherDoc.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload Other Document Attachment..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
            if (trformvi.Visible)
            {
                if (LabelFormVI.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload FormVI Attachment..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
            if (trformv.Visible)
            {
                if (LabelFormV.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload FormV Attachment..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
            if (trdrawing.Visible)
            {
                if (LabelDrawing.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload Drawing Attachment..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
            if (trcbb.Visible)
            {
                if (LabelCBB.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload CBB Attachment..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
            if (trAnnexure.Visible)
            {
                if (LabelAnexure.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload Annexure Attachment..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
            if (trrepairers.Visible)
            {
                if (labelrepairer.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload Repairer Attachment..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }



            if (trboequalification.Visible)
            {
                //if (labelboequalification.Text == "")
                //{
                //    lblmsg0.Text = "<font color='red'>Please Upload BOE Qualification..!</font>";
                //    success.Visible = false;
                //    Failure.Visible = true;
                //    return;
                //}
            }
            DataSet ds = new DataSet();
            BoilerPaymentRenewal.boiler_rating = txtBoilerRatingSurface.Text.Trim();
            BoilerPaymentRenewal.length_pipeline = txtTotalLengthOfStreamPipeLine.Text.Trim();
            BoilerPaymentRenewal.typeOfBoiler = ddlTypeofBoiler.SelectedValue;
            BoilerPaymentRenewal.inspectingauthority = ddlinspector.SelectedValue;
            if (ddlthirdparty.SelectedValue != "--Select--")
            {
                BoilerPaymentRenewal.thirdpartytype = ddlthirdparty.SelectedValue;
            }
            else
            {
                BoilerPaymentRenewal.thirdpartytype = "0";
            }

            string Amount = BoilerRenewal.calculateAmount(BoilerPaymentRenewal);

            if (Amount =="0$0")
            {

                lblmsg0.Text = "<font color='red'>Renewal Fee Amount Cannot be Zero..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
                 
            }

            ds = Gen.GetdataofCFOBoiler(Session["uid"].ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                int result = 0;

                result = Gen.insertRenewalBoiler(Session["uid"].ToString(), Request.QueryString[0].ToString(), Session["uid"].ToString(), "", "",
                    txtRegistrationNumber.Text, txtNameOfOwner.Text, txtWhereStudied.Text, txtDateOfInspection.Text, txtDescriptionofboilersAge.Text,
                    txtMakersName.Text, ddlTypeofBoiler.SelectedValue, ddlBoilersUsedfor.SelectedValue, txtMakersNumber.Text, txtPlace.Text,
                    txtYear.Text, txtAllowedMaximumPresure.Text, txtEconomiserMarker.Text, txtBoilerRatingSurface.Text,

                    txtMaximumContinousEvapration.Text, txtClassofErector.Text, txtNameOfErector.Text, ddlState.SelectedValue.ToString(),
                    txtMaximumPresureofEconomiser.Text, txtTotalLengthOfStreamPipeLine.Text, Session["uid"].ToString(), Session["uid"].ToString(),
                    txtcomponentperson.Text.Trim(), ddlinspector.SelectedValue, TxtnameofUnit.Text.Trim(), ddlProp_intDistrictid.SelectedValue,
                    ddlProp_intMandalid.SelectedValue, ddlProp_intVillageid.SelectedValue, txtregnsteampipeline.Text.Trim(), rdur376.SelectedValue,
                    Convert.ToString(Amount), rdrepairers.SelectedValue, txtrepairername.Text.Trim(), txtrepairerclass.Text.Trim(),
                    ddlthirdparty.SelectedValue, txtfeedetails.Text.Trim(), txtmodeofpayment.Text.Trim(), ddlboename.SelectedValue, txtboecertificateno.Text.Trim(), txtboeaddress.Text.Trim(),
                    txtboemobileno.Text.Trim(), txtboeEmailid.Text.Trim());
                if (result == 1)
                {

                    lblmsg.Text = "<font color='green'>CFO Boiler Details Saved Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;

                }
                else if (result == 2)
                {
                    lblmsg.Text = "<font color='green'>Boiler Details Updated Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;
                }
            }
            else
            {
                int result = 0;
                result = Gen.insertRenewalBoiler(Session["uid"].ToString(), Request.QueryString[0].ToString(), Session["uid"].ToString(), "", "", txtRegistrationNumber.Text,
                    txtNameOfOwner.Text, txtWhereStudied.Text, txtDateOfInspection.Text, txtDescriptionofboilersAge.Text, txtMakersName.Text,
                    ddlTypeofBoiler.SelectedValue, ddlBoilersUsedfor.SelectedValue, txtMakersNumber.Text, txtPlace.Text, txtYear.Text,
                    txtAllowedMaximumPresure.Text, txtEconomiserMarker.Text, txtBoilerRatingSurface.Text, txtMaximumContinousEvapration.Text,
                    txtClassofErector.Text, txtNameOfErector.Text, ddlState.SelectedValue.ToString(), txtMaximumPresureofEconomiser.Text,
                    txtTotalLengthOfStreamPipeLine.Text, Session["uid"].ToString(), Session["uid"].ToString(), txtcomponentperson.Text.Trim(),
                    ddlinspector.SelectedValue, TxtnameofUnit.Text.Trim(), ddlProp_intDistrictid.SelectedValue, ddlProp_intMandalid.SelectedValue,
                    ddlProp_intVillageid.SelectedValue, txtregnsteampipeline.Text.Trim(), rdur376.SelectedValue, Convert.ToString(Amount),
                    rdrepairers.SelectedValue, txtrepairername.Text.Trim(), txtrepairerclass.Text.Trim(), ddlthirdparty.SelectedValue,
                    txtfeedetails.Text.Trim(), txtmodeofpayment.Text.Trim(), ddlboename.SelectedValue, txtboecertificateno.Text.Trim(), txtboeaddress.Text.Trim(),
                    txtboemobileno.Text.Trim(), txtboeEmailid.Text.Trim());

                if (result > 0)
                {
                    lblmsg.Text = "<font color='green'>Boiler Details Saved Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;

                }
                else
                {
                    lblmsg.Text = "<font color='green'>Boiler Details Submission Failed..!</font>";
                }
            }
        }



    }
    void clear()
    {

        txtRegistrationNumber.Text = ""; txtNameOfOwner.Text = ""; txtWhereStudied.Text = ""; txtDateOfInspection.Text = ""; txtDescriptionofboilersAge.Text = ""; txtMakersName.Text = "";
        ddlTypeofBoiler.SelectedIndex = 0; ddlBoilersUsedfor.SelectedIndex = 0; txtMakersNumber.Text = ""; txtPlace.Text = ""; txtYear.Text = "";
        txtAllowedMaximumPresure.Text = ""; txtEconomiserMarker.Text = ""; txtBoilerRatingSurface.Text = ""; txtMaximumContinousEvapration.Text = "";
        txtClassofErector.Text = ""; txtNameOfErector.Text = ""; ddlState.SelectedIndex = 0; txtMaximumPresureofEconomiser.Text = "";
        txtTotalLengthOfStreamPipeLine.Text = "";


    }


    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        if (BtnDelete.Text == "Next")
        {
            if (ViewState["Enable"] != null && ViewState["Enable"] != "" && ViewState["Enable"] == "Y")
            {
                if (trerector.Visible && trerector.Visible)// if new registration
                {
                    if (LabelErector.Text == "")
                    {
                        lblmsg0.Text = "<font color='red'>Please Upload Erector Attachment..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        FileUploadErector.Enabled = true;
                        return;
                    }
                }
                if (trreqdoc.Visible)
                {
                    if (LabelRequiredDoc.Text == "")
                    {
                        lblmsg0.Text = "<font color='red'>Please Upload Required Document Attachment..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        return;
                    }
                }
                if (trotherdoc.Visible)
                {
                    if (LabelOtherDoc.Text == "")
                    {
                        lblmsg0.Text = "<font color='red'>Please Upload Other Document Attachment..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        return;
                    }
                }
                if (trformvi.Visible)
                {
                    if (LabelFormVI.Text == "")
                    {
                        lblmsg0.Text = "<font color='red'>Please Upload FormVI Attachment..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        return;
                    }
                }
                if (trformv.Visible)
                {
                    if (LabelFormV.Text == "")
                    {
                        lblmsg0.Text = "<font color='red'>Please Upload FormV Attachment..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        return;
                    }
                }
                if (trdrawing.Visible)
                {
                    if (LabelDrawing.Text == "")
                    {
                        lblmsg0.Text = "<font color='red'>Please Upload Drawing Attachment..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        return;
                    }
                }
                if (trcbb.Visible)
                {
                    if (LabelCBB.Text == "")
                    {
                        lblmsg0.Text = "<font color='red'>Please Upload CBB Attachment..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        return;
                    }
                }
                if (trAnnexure.Visible)
                {
                    if (LabelAnexure.Text == "")
                    {
                        lblmsg0.Text = "<font color='red'>Please Upload Annexure Attachment..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        return;
                    }
                }
                if (trrepairers.Visible)
                {
                    if (labelrepairer.Text == "")
                    {
                        lblmsg0.Text = "<font color='red'>Please Upload Repairer Attachment..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        return;
                    }
                }

            }
            DataSet ds = new DataSet();
            BoilerPaymentRenewal.boiler_rating = txtBoilerRatingSurface.Text.Trim();
            if (txtTotalLengthOfStreamPipeLine.Text.Trim() != "")
            {
                BoilerPaymentRenewal.length_pipeline = txtTotalLengthOfStreamPipeLine.Text.Trim();
            }
            else
            {
                BoilerPaymentRenewal.length_pipeline = "0";
            }
            BoilerPaymentRenewal.typeOfBoiler = ddlTypeofBoiler.SelectedValue;
            BoilerPaymentRenewal.inspectingauthority = ddlinspector.SelectedValue;
            if (ddlthirdparty.SelectedValue != "--Select--")
            {
                BoilerPaymentRenewal.thirdpartytype = ddlthirdparty.SelectedValue;
            }
            else
            {
                BoilerPaymentRenewal.thirdpartytype = "0";
            }

            string Amount = BoilerRenewal.calculateAmount(BoilerPaymentRenewal);
            if (Amount == "0$0")
            {

                lblmsg0.Text = "<font color='red'>Renewal Fee Amount Cannot be Zero..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;

            }

            ds = Gen.GetdataofRENEWALBoiler(Session["uid"].ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                int result = 0;

                result = Gen.insertRenewalBoiler(Session["uid"].ToString(), Request.QueryString[0].ToString(), Session["uid"].ToString(), "", "",
                    txtRegistrationNumber.Text, txtNameOfOwner.Text, txtWhereStudied.Text, txtDateOfInspection.Text, txtDescriptionofboilersAge.Text,
                    txtMakersName.Text, ddlTypeofBoiler.SelectedValue, ddlBoilersUsedfor.SelectedValue, txtMakersNumber.Text, txtPlace.Text,
                    txtYear.Text, txtAllowedMaximumPresure.Text, txtEconomiserMarker.Text, txtBoilerRatingSurface.Text,
                    txtMaximumContinousEvapration.Text, txtClassofErector.Text, txtNameOfErector.Text, ddlState.SelectedValue.ToString(),
                    txtMaximumPresureofEconomiser.Text, txtTotalLengthOfStreamPipeLine.Text, Session["uid"].ToString(), Session["uid"].ToString(),
                    txtcomponentperson.Text.Trim(), ddlinspector.SelectedValue, TxtnameofUnit.Text.Trim(), ddlProp_intDistrictid.SelectedValue,
                    ddlProp_intMandalid.SelectedValue, ddlProp_intVillageid.SelectedValue, txtregnsteampipeline.Text.Trim(), rdur376.SelectedValue,
                    Convert.ToString(Amount), rdrepairers.SelectedValue, txtrepairername.Text.Trim(), txtrepairerclass.Text.Trim(),
                    ddlthirdparty.SelectedValue, txtfeedetails.Text.Trim(), txtmodeofpayment.Text.Trim(), ddlboename.SelectedValue,
                    txtboecertificateno.Text.Trim(), txtboeaddress.Text.Trim(),
                    txtboemobileno.Text.Trim(), txtboeEmailid.Text.Trim());
                //if (result > 0)
                //{

                //    Response.Redirect("frmCFOPCBDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
                //    lblmsg.Text = "<font color='green'>CFO Boiler Details Saved Successfully..!</font>";
                //    success.Visible = true;
                //    Failure.Visible = false;

                //}
                //else if (result == 0)
                //{
                //    Response.Redirect("frmCFOPCBDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
                //    lblmsg.Text = "<font color='green'>Boiler Details Updated Successfully..!</font>";
                //    success.Visible = true;
                //    Failure.Visible = false;
                //}
            }
            else
            {
                int result = 0;
                result = Gen.insertRenewalBoiler(Session["uid"].ToString(), Request.QueryString[0].ToString(), Session["uid"].ToString(), "", "",
                    txtRegistrationNumber.Text, txtNameOfOwner.Text, txtWhereStudied.Text, txtDateOfInspection.Text, txtDescriptionofboilersAge.Text,
                    txtMakersName.Text, ddlTypeofBoiler.SelectedValue, ddlBoilersUsedfor.SelectedValue, txtMakersNumber.Text, txtPlace.Text,
                    txtYear.Text, txtAllowedMaximumPresure.Text, txtEconomiserMarker.Text, txtBoilerRatingSurface.Text,
                    txtMaximumContinousEvapration.Text, txtClassofErector.Text, txtNameOfErector.Text, ddlState.SelectedValue.ToString(),
                    txtMaximumPresureofEconomiser.Text, txtTotalLengthOfStreamPipeLine.Text, Session["uid"].ToString(), Session["uid"].ToString(),
                    txtcomponentperson.Text.Trim(), ddlinspector.SelectedValue, TxtnameofUnit.Text.Trim(), ddlProp_intDistrictid.SelectedValue,
                    ddlProp_intMandalid.SelectedValue, ddlProp_intVillageid.SelectedValue, txtregnsteampipeline.Text.Trim(), rdur376.SelectedValue,
                    Convert.ToString(Amount), rdrepairers.SelectedValue, txtrepairername.Text.Trim(), txtrepairerclass.Text.Trim(),
                    ddlthirdparty.SelectedValue, txtfeedetails.Text.Trim(), txtmodeofpayment.Text.Trim(), ddlboename.SelectedValue, txtboecertificateno.Text.Trim(), txtboeaddress.Text.Trim(),
                    txtboemobileno.Text.Trim(), txtboeEmailid.Text.Trim());

                //if (result > 0)
                //{
                //    Response.Redirect("frmCFOPCBDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
                //    lblmsg.Text = "<font color='green'>CFO Boiler Details Saved Successfully..!</font>";
                //    success.Visible = true;
                //    Failure.Visible = false;

                //}
                //else
                //{
                //    lblmsg.Text = "<font color='green'>CFO Boiler Details Submission Failed..!</font>";
                //}
            }

            try
            {
                //Response.Redirect("frmBoilerRenewalApproval.aspx?intApplicationId=" + Session["uid"].ToString().Trim());
                Response.Redirect("frmFactoryRenewal.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
                lblmsg.CssClass = "errormsg";
            }


        }


    }
    void FillDetails()
    {

        DataSet ds = new DataSet();
        ds = Gen.GetdataofRENEWALBoiler(Request.QueryString[0].ToString());//Session["Applid"].ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {
            //TxtnameofUnit.Text = ds.Tables[0].Rows[0]["nameofunit"].ToString();
            //BindDistricts();
            //if (ds.Tables[0].Rows[0]["Prop_intDistrictid"].ToString().Trim() != "")
            //{

            //    //ddlDistrict.SelectedValue = ds.Tables[0].Rows[0]["Petrolium_District"].ToString();
            //    ddlProp_intDistrictid.SelectedValue = ddlProp_intDistrictid.Items.FindByValue(ds.Tables[0].Rows[0]["Prop_intDistrictid"].ToString().Trim()).Value;
            //}
            //getmandals();
            //if (ds.Tables[0].Rows[0]["Prop_intMandalid"].ToString().Trim() != "")
            //{
            //    //ddlMandal.SelectedValue =  ds.Tables[0].Rows[0]["Petrolium_Mandal"].ToString();

            //    ddlProp_intMandalid.SelectedValue = ddlProp_intMandalid.Items.FindByValue(ds.Tables[0].Rows[0]["Prop_intMandalid"].ToString().Trim()).Value;
            //}
            //getvillages();
            //if (ds.Tables[0].Rows[0]["Prop_intVillageid"].ToString().Trim() != "")
            //{
            //    //ddlVillage.SelectedValue = ds.Tables[0].Rows[0]["Petrolium_Village"].ToString();

            //    ddlProp_intVillageid.SelectedValue = ddlProp_intVillageid.Items.FindByValue(ds.Tables[0].Rows[0]["Prop_intVillageid"].ToString().Trim()).Value;
            //}

            txtRegistrationNumber.Text = ds.Tables[0].Rows[0]["Reg_No_Boiler"].ToString();
            //txtNameOfOwner.Text = ds.Tables[0].Rows[0]["Name_Owner"].ToString();
            //txtWhereStudied.Text = ds.Tables[0].Rows[0]["Location"].ToString();
            //if (ds.Tables[0].Rows[0]["Date_Inpec_Desirable"].ToString().Trim() != "")
            //{
            //    txtDateOfInspection.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Date_Inpec_Desirable"]).ToString("dd-MMM-yyyy");
            //}
            //txtDescriptionofboilersAge.Text = ds.Tables[0].Rows[0]["Desc_Boiler_Age"].ToString();
            //txtMakersName.Text = ds.Tables[0].Rows[0]["Makers_name"].ToString();
            ddlTypeofBoiler.SelectedValue = ds.Tables[0].Rows[0]["Type_Boiler"].ToString();
            ddlBoilersUsedfor.SelectedValue = ds.Tables[0].Rows[0]["Boiler_User_for"].ToString();
            //txtMakersNumber.Text = ds.Tables[0].Rows[0]["Boiler_ration"].ToString();
            txtPlace.Text = ds.Tables[0].Rows[0]["Place_Manfacture"].ToString();
            txtYear.Text = ds.Tables[0].Rows[0]["Year_Manfacture"].ToString();
            txtAllowedMaximumPresure.Text = ds.Tables[0].Rows[0]["Allowed_Max_Presure"].ToString();
            // txtEconomiserMarker.Text = ds.Tables[0].Rows[0]["Econ_Maker_Number"].ToString();
            txtBoilerRatingSurface.Text = ds.Tables[0].Rows[0]["Heating_Surface_boiler"].ToString();
            txtMaximumContinousEvapration.Text = ds.Tables[0].Rows[0]["Max_Conti_Evapron"].ToString();
            //txtClassofErector.Text = ds.Tables[0].Rows[0]["Class_Erector"].ToString();
            //txtNameOfErector.Text = ds.Tables[0].Rows[0]["Name_of_Erector"].ToString();
            //getstates();
            //ddlState.SelectedValue = ds.Tables[0].Rows[0]["State_Erector"].ToString();
            //txtMaximumPresureofEconomiser.Text = ds.Tables[0].Rows[0]["Max_Presure_Econ"].ToString();
            txtTotalLengthOfStreamPipeLine.Text = ds.Tables[0].Rows[0]["Tot_Lenght_Steam_PipeLine"].ToString();
            txtregnsteampipeline.Text = ds.Tables[0].Rows[0]["SteamRegno"].ToString();
            //txtstreetName.Text = ds.Tables[0].Rows[0]["Location"].ToString();

            if (ds.Tables[0].Rows[0]["InspectingAuthorityType"].ToString().Trim() != "")
            {
                ddlinspector.SelectedValue = ddlinspector.Items.FindByValue(ds.Tables[0].Rows[0]["InspectingAuthorityType"].ToString().Trim()).Value;
            }
            if (ds.Tables[0].Rows[0]["InspectingAuthorityType"].ToString().Trim() != "")
            {

                if (ds.Tables[0].Rows[0]["InspectingAuthorityType"].ToString().Trim() == "2")
                {
                    trthirdpratydetails.Visible = true;

                    trthirdpraty.Visible = true;
                    //Label12.Text = "Component Person Details";
                    trcbb.Visible = true;
                    trformvi.Visible = true;
                    //trformv.Visible = true;
                    trAnnexure.Visible = true;
                    //trdrawing.Visible = true;

                    trfeedetails.Visible = true;
                    trmodeofpayment.Visible = true;
                    trboecertification.Visible = false;
                    trboequalification.Visible = false;
                    EventArgs e = new EventArgs();
                    object sender = new object();
                    if (ds.Tables[0].Rows[0]["Thirdparttype"].ToString().Trim() != "")
                    {
                        ddlthirdparty.SelectedValue = ddlthirdparty.Items.FindByValue(ds.Tables[0].Rows[0]["Thirdparttype"].ToString().Trim()).Value;
                        ddlthirdparty_SelectedIndexChanged(this, EventArgs.Empty);

                    }
                    if (ds.Tables[0].Rows[0]["Thirdparttype"].ToString().Trim() != "" && ds.Tables[0].Rows[0]["Thirdparttype"].ToString().Trim() == "2")
                    {
                        Label12.Text = "Component Person Details";
                        if (ds.Tables[0].Rows[0]["ComponentPerson"].ToString().Trim() != "")
                        {
                            txtcomponentperson.Text = ds.Tables[0].Rows[0]["ComponentPerson"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["Feedetails"].ToString().Trim() != "")
                        {
                            txtfeedetails.Text = ds.Tables[0].Rows[0]["Feedetails"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["Modeofpayment"].ToString().Trim() != "")
                        {
                            txtmodeofpayment.Text = ds.Tables[0].Rows[0]["Modeofpayment"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["RepairerFlag"].ToString().Trim() != "" && ds.Tables[0].Rows[0]["RepairerFlag"].ToString().Trim() == "Y")
                        {
                            rdrepairers.SelectedValue = "Y";
                            trrepairers.Visible = true;
                            trrepairerdoc.Visible = true;
                            if (ds.Tables[0].Rows[0]["RepairerName"].ToString().Trim() != "")
                            {
                                txtrepairername.Text = ds.Tables[0].Rows[0]["RepairerName"].ToString();
                            }
                            if (ds.Tables[0].Rows[0]["RepairerClass"].ToString().Trim() != "")
                            {
                                txtrepairerclass.Text = ds.Tables[0].Rows[0]["RepairerClass"].ToString();
                            }
                        }
                        else
                        {
                            rdrepairers.SelectedValue = "N";
                            trrepairers.Visible = false;
                            trrepairerdoc.Visible = false;
                        }
                    }
                    else
                    {

                        trboenamedropdown.Visible = true;
                        trboeexistedlist.Visible = false;
                        if (ds.Tables[0].Rows[0]["Boename"].ToString().Trim() != "")
                        {

                            ddlboename.SelectedValue = ds.Tables[0].Rows[0]["Boename"].ToString().Trim();
                            trboecertificateno.Visible = true;
                            txtboecertificateno.Text = ds.Tables[0].Rows[0]["CertificateNo"].ToString().Trim();
                            trboeaddress.Visible = true;
                            txtboeaddress.Text = ds.Tables[0].Rows[0]["Address"].ToString().Trim();
                            trboemobileno.Visible = true;
                            txtboemobileno.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString().Trim();
                            trboeemailid.Visible = true;
                            txtboeEmailid.Text = ds.Tables[0].Rows[0]["Emailid"].ToString().Trim();
                        }
                        // trexperience.Visible = true;
                        //ddlboeexperience.SelectedValue= ds.Tables[0].Rows[0]["BoeExperience"].ToString().Trim();
                        Label12.Text = "BOE Person";
                        if (ds.Tables[0].Rows[0]["ComponentPerson"].ToString().Trim() != "")
                        {
                            txtcomponentperson.Text = ds.Tables[0].Rows[0]["ComponentPerson"].ToString();
                        }
                        //trboecertification.Visible = true;
                        //trboequalification.Visible = true;
                    }
                }

            }
            DataSet dsattachment = new DataSet();
            dsattachment = Gen.ViewAttachmentREN(Request.QueryString[0].ToString());// (Session["uid"].ToString());

            if (dsattachment.Tables[0].Rows.Count > 0)
            {
                int c = dsattachment.Tables[0].Rows.Count;
                string sen, sen1, sen2;
                int i = 0;

                while (i < c)
                {
                    sen2 = dsattachment.Tables[0].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");



                    //  sen = sen1.Replace(@"C:/TSiPASS/Attachments/1192/", "~/");//"C:/TSiPASS/Attachments/1192/B1Form\CateogryofRegistration.jpg"
                    //sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/Attachments")), "~/");
                    if (sen1.Contains("RENAttachments"))
                    {
                        sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/RENAttachments")), "~/");

                        if (sen.Contains("ErectorLicense"))
                        {
                            lblFileNameErector.NavigateUrl = sen;
                            lblFileNameErector.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                            LabelErector.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                            //HyperLink1.NavigateUrl = sen;
                            //HyperLink1.Text = 
                        }

                        if (sen.Contains("BoilerRequiredDoc"))
                        {
                            HyperLinkRequiredDoc.NavigateUrl = sen;
                            HyperLinkRequiredDoc.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                            LabelRequiredDoc.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        }

                        if (sen.Contains("BoilerOtherDoc"))
                        {
                            HyperLinkOtherDoc.NavigateUrl = sen;
                            HyperLinkOtherDoc.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                            LabelOtherDoc.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        }

                        if (sen.Contains("BoilerFormVI"))
                        {
                            HyperLinkFormVI.NavigateUrl = sen;
                            HyperLinkFormVI.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                            LabelFormVI.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        }

                        if (sen.Contains("BoilerFormV"))
                        {
                            HyperLinkFormV.NavigateUrl = sen;
                            HyperLinkFormV.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                            LabelFormV.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        }

                        if (sen.Contains("BoilerDrawing"))
                        {
                            HyperLinkDrawing.NavigateUrl = sen;
                            HyperLinkDrawing.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                            LabelDrawing.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        }


                        if (sen.Contains("BoilerCBB"))
                        {
                            HyperLinkCBB.NavigateUrl = sen;
                            HyperLinkCBB.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                            LabelCBB.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        }

                        if (sen.Contains("BoilerAnexure"))
                        {
                            HyperLinkAnexure.NavigateUrl = sen;
                            HyperLinkAnexure.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                            LabelAnexure.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        }

                        if (sen.Contains("BoilerRepairerDoc"))
                        {
                            hyperlinkrepairer.NavigateUrl = sen;
                            hyperlinkrepairer.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                            labelrepairer.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        }

                        if (sen.Contains("BoilerBOECertification"))
                        {
                            hyperlinkboecertification.NavigateUrl = sen;
                            hyperlinkboecertification.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                            labelboecertification.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        }

                        if (sen.Contains("BoilerBOEqualification"))
                        {
                            hyperlinkboequalification.NavigateUrl = sen;
                            hyperlinkboequalification.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                            labelboequalification.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        }
                        i++;
                    }
                }

            }

        }
    }

    void FillDetailsCommonData()
    {

        DataSet ds = new DataSet();
        ds = Gen.GetdataofBoilerCommon(Session["uid"].ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {

            TxtnameofUnit.Text = ds.Tables[0].Rows[0]["nameofunit"].ToString();
            BindDistricts();
            if (ds.Tables[0].Rows[0]["Prop_intDistrictid"].ToString().Trim() != "")
            {

                //ddlDistrict.SelectedValue = ds.Tables[0].Rows[0]["Petrolium_District"].ToString();
                ddlProp_intDistrictid.SelectedValue = ddlProp_intDistrictid.Items.FindByValue(ds.Tables[0].Rows[0]["Prop_intDistrictid"].ToString().Trim()).Value;
            }
            //getMandals();
            if (ds.Tables[0].Rows[0]["Prop_intMandalid"].ToString().Trim() != "")
            {
                //ddlMandal.SelectedValue =  ds.Tables[0].Rows[0]["Petrolium_Mandal"].ToString();

                ddlProp_intMandalid.SelectedValue = ddlProp_intMandalid.Items.FindByValue(ds.Tables[0].Rows[0]["Prop_intMandalid"].ToString().Trim()).Value;
            }
            //getVillages();
            if (ds.Tables[0].Rows[0]["Prop_intVillageid"].ToString().Trim() != "")
            {
                //ddlVillage.SelectedValue = ds.Tables[0].Rows[0]["Petrolium_Village"].ToString();

                ddlProp_intVillageid.SelectedValue = ddlProp_intVillageid.Items.FindByValue(ds.Tables[0].Rows[0]["Prop_intVillageid"].ToString().Trim()).Value;
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
    protected void ddlstatus28_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void BtnDelete0_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmLabourShopRenewal.aspx?intApplicationId=" + Session["uid"].ToString() + "&Previous=" + "P");
    }
    protected void ddlinspector_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlinspector.SelectedValue == "2")
            {
                trthirdpratydetails.Visible = true;
            }
            else
            {
                trthirdpratydetails.Visible = false;
            }
        }
        catch (Exception ex)
        {

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

    protected void BtnErector_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];
        //Session["Applid"] = "0";
        General t1 = new General();
        if (FileUploadErector.HasFile)
        {
            if ((FileUploadErector.PostedFile != null) && (FileUploadErector.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadErector.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadErector.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "//" + Session["Applid"].ToString() + "\\ErectorLicense");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadErector.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadErector.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertRenewalAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ErectorLicense");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblFileNameErector.Text = FileUploadErector.FileName;
                            LabelErector.Text = FileUploadErector.FileName;
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

    protected void btnreqdoc_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];

        General t1 = new General();
        if (FileUploadRequiredDoc.HasFile)
        {
            if ((FileUploadRequiredDoc.PostedFile != null) && (FileUploadRequiredDoc.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadRequiredDoc.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadRequiredDoc.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "//" + Session["Applid"].ToString() + "\\BoilerRequiredDoc");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadRequiredDoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadRequiredDoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertRenewalAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "BoilerRequiredDocuments");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLinkRequiredDoc.Text = FileUploadRequiredDoc.FileName;
                            LabelRequiredDoc.Text = FileUploadRequiredDoc.FileName;
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
    protected void btnanyotherdoc_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];

        General t1 = new General();
        if (FileUploadOtherDoc.HasFile)
        {
            if ((FileUploadOtherDoc.PostedFile != null) && (FileUploadOtherDoc.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadOtherDoc.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadOtherDoc.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "//" + Session["Applid"].ToString() + "\\BoilerOtherDoc\\");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadOtherDoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadOtherDoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertRenewalAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "BoilerOtherDocument");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLinkOtherDoc.Text = FileUploadOtherDoc.FileName;
                            LabelOtherDoc.Text = FileUploadOtherDoc.FileName;
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
    protected void btnformvi_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];

        General t1 = new General();
        if (FileUploadFormVI.HasFile)
        {
            if ((FileUploadFormVI.PostedFile != null) && (FileUploadFormVI.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadFormVI.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadFormVI.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "//" + Session["Applid"].ToString() + "\\BoilerFormVI");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadFormVI.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadFormVI.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertRenewalAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "BoilerFormVI");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLinkFormVI.Text = FileUploadFormVI.FileName;
                            LabelFormVI.Text = FileUploadFormVI.FileName;
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
    protected void btnformv_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];

        General t1 = new General();
        if (FileUploadFormV.HasFile)
        {
            if ((FileUploadFormV.PostedFile != null) && (FileUploadFormV.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadFormV.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadFormV.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "//" + Session["Applid"].ToString() + "\\BoilerFormV");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadFormV.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadFormV.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertRenewalAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "BoilerFormV");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLinkFormV.Text = FileUploadFormV.FileName;
                            LabelFormV.Text = FileUploadFormV.FileName;
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
    protected void btndrawing_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];

        General t1 = new General();
        if (FileUploadDrawing.HasFile)
        {
            if ((FileUploadDrawing.PostedFile != null) && (FileUploadDrawing.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadDrawing.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadDrawing.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "//" + Session["Applid"].ToString() + "\\Drawings");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadDrawing.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadDrawing.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertRenewalAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "Drawings");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLinkDrawing.Text = FileUploadDrawing.FileName;
                            LabelDrawing.Text = FileUploadDrawing.FileName;
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
    protected void btnuploadcbb_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];

        General t1 = new General();
        if (FileUploadCBB.HasFile)
        {
            if ((FileUploadCBB.PostedFile != null) && (FileUploadCBB.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadCBB.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadCBB.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "//" + Session["Applid"].ToString() + "\\BoilerCBB");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadCBB.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadCBB.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertRenewalAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "BoilerCBB");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLinkCBB.Text = FileUploadCBB.FileName;
                            LabelCBB.Text = FileUploadCBB.FileName;
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
    protected void Btnanexure_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];

        General t1 = new General();
        if (FileUploadAnexure.HasFile)
        {
            if ((FileUploadAnexure.PostedFile != null) && (FileUploadAnexure.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadAnexure.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadAnexure.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "//" + Session["Applid"].ToString() + "\\BoilerAnexure\\");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadAnexure.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadAnexure.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertRenewalAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "BoilerAnexure");


                        if (result > 0)
                        {


                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLinkAnexure.Text = FileUploadAnexure.FileName;
                            LabelAnexure.Text = FileUploadAnexure.FileName;
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
    protected void ddlProp_intDistrictid_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //hdnfldtsiic.Value = "";
            //ddlLoc_of_unit.Items.Clear();
            //ddlLoc_of_unit.Items.Insert(0, new ListItem("--Select--", "0"));
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
            //hdnfocus.Value = ddlProp_intDistrictid.ClientID;
            //if (rdIaLa_Lst.SelectedValue == "Y") //lavanya
            //{
            //    BindIndustrialParks();
            //}
            //   ddlProp_intDistrictid.Focus();
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }
    protected void ddlProp_intMandalid_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //ddlLoc_of_unit.Items.Clear();
            //ddlLoc_of_unit.Items.Insert(0, new ListItem("--Select--", "0"));
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

            //hdnfocus.Value = ddlProp_intMandalid.ClientID;
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }
    public void BindBoeExperience()
    {
        DataSet dsboeexp = new DataSet();
        dsboeexp = getboeexperience();
        if (dsboeexp.Tables[0].Rows.Count > 0)
        {
            ddlboeexperience.DataSource = dsboeexp.Tables[0];
            ddlboeexperience.DataTextField = "boeexperience";
            ddlboeexperience.DataValueField = "boeexp_id";
            ddlboeexperience.DataBind();

            ddlboeexperience.Items.Insert(0, new ListItem("Select", "0"));

        }
    }
    public DataSet getboeexperience()
    {
        DataSet Dsnew = new DataSet();

        Dsnew = Gen.GenericFillDs("GetExperience");
        return Dsnew;
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
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }
    protected void rdur376_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdur376.SelectedValue == "Y")
        {
            trotherdoc.Visible = true;
        }
        else
        {
            trotherdoc.Visible = false;
        }
    }
    protected void btnFormXIX_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];

        General t1 = new General();
        if (FileUploadFormXIX.HasFile)
        {
            if ((FileUploadFormXIX.PostedFile != null) && (FileUploadFormXIX.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadFormXIX.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadFormXIX.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "//" + Session["Applid"].ToString() + "\\BoilerFormXIX");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadFormXIX.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadFormXIX.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertRenewalAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "BoilerFormXIX");


                        if (result > 0)
                        {


                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLinkFormXIX.Text = FileUploadFormXIX.FileName;
                            LabelFormXIX.Text = FileUploadFormXIX.FileName;
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

    void getmandals()
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

    void getvillages()
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
    protected void rdrepairers_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rdrepairers.SelectedValue == "Y")
            {
                trrepairerdoc.Visible = true;
                trrepairername.Visible = true;
                trrepairerclass.Visible = true;
            }
            else
            {
                trrepairerdoc.Visible = false;
                trrepairername.Visible = false;
                trrepairerclass.Visible = false;
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnrepairer_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];

        General t1 = new General();
        if (fileuploadrepairer.HasFile)
        {
            if ((fileuploadrepairer.PostedFile != null) && (fileuploadrepairer.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(fileuploadrepairer.PostedFile.FileName);
                try
                {

                    string[] fileType = fileuploadrepairer.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "//" + Session["Applid"].ToString() + "\\BoilerRepairerDoc");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fileuploadrepairer.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fileuploadrepairer.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertRenewalAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "BoilerRepairerDoc");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            hyperlinkrepairer.Text = fileuploadrepairer.FileName;
                            labelrepairer.Text = fileuploadrepairer.FileName;
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
    protected void ddlthirdparty_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlthirdparty.SelectedValue == "1")
            {
                trboeexistedlist.Visible = true;
                trboenamedropdown.Visible = true;
                DataSet ds = new DataSet();
                ds = GetBoenames();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlboename.DataSource = ds.Tables[0];
                    ddlboename.DataTextField = "BOEName";
                    ddlboename.DataValueField = "BOEID";
                    ddlboename.DataBind();

                    ddlboename.Items.Insert(0, new ListItem("Select", "0"));
                }

                //trthirdpraty.Visible = true;
                trthirdpraty.Visible = false;
                Label12.Text = "BOE Person";
                trcbb.Visible = false;
                trformvi.Visible = false;
                trformv.Visible = false;
                trAnnexure.Visible = false;
                trdrawing.Visible = false;
                trrepairers.Visible = false;
                trfeedetails.Visible = false;
                trfeedetails.Visible = false;
                trmodeofpayment.Visible = false;
                trboecertification.Visible = false;
                trboequalification.Visible = false;

            }
            else
            {
                trboenamedropdown.Visible = false;
                trboeexistedlist.Visible = false;
                trboecertificateno.Visible = false;
                trboeaddress.Visible = false;
                trboemobileno.Visible = false;
                trboeemailid.Visible = false;
                trexperience.Visible = false;
                trthirdpraty.Visible = true;
                Label12.Text = "Component Person Details";
                trcbb.Visible = true;
                trformvi.Visible = false;
                //trformv.Visible = true;
                trAnnexure.Visible = false;
                //trdrawing.Visible = true;
                trrepairers.Visible = true;
                trfeedetails.Visible = true;
                trmodeofpayment.Visible = true;
                trboecertification.Visible = false;
                trboequalification.Visible = false;
            }
        }
        catch (Exception ex)
        {
        }
    }
    public DataSet GetBoenames()
    {
        DataSet dsboenames = new DataSet();

        dsboenames = Gen.GenericFillDs("GetBoenames");
        return dsboenames;
    }
    protected void btnboecertification_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];

        General t1 = new General();
        if (fileuploadboecertification.HasFile)
        {
            if ((fileuploadboecertification.PostedFile != null) && (fileuploadboecertification.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(fileuploadboecertification.PostedFile.FileName);
                try
                {

                    string[] fileType = fileuploadboecertification.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "//" + Session["Applid"].ToString() + "\\BoilerBOECertification\\");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fileuploadboecertification.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fileuploadboecertification.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertRenewalAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "BoilerBOECertification");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            hyperlinkboecertification.Text = fileuploadboecertification.FileName;
                            labelboecertification.Text = fileuploadboecertification.FileName;
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
    protected void btnboequalification_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];

        General t1 = new General();
        if (fileuploadboequalification.HasFile)
        {
            if ((fileuploadboequalification.PostedFile != null) && (fileuploadboequalification.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(fileuploadboequalification.PostedFile.FileName);
                try
                {

                    string[] fileType = fileuploadboequalification.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "//" + Session["Applid"].ToString() + "\\BoilerBOEqualification\\");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fileuploadboequalification.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fileuploadboequalification.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertRenewalAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "BoilerBOEqualification");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            hyperlinkboequalification.Text = fileuploadboequalification.FileName;
                            labelboequalification.Text = fileuploadboequalification.FileName;
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

    protected void ddlboename_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dsboename = new DataSet();
        dsboename = GetBoeDetails(ddlboename.SelectedValue);
        if (dsboename.Tables[0].Rows.Count > 0)
        {
            trboename.Visible = false;
            trboeexistedlist.Visible = false;
            trboecertificateno.Visible = true;
            trboeaddress.Visible = true;
            trboemobileno.Visible = true;
            trboeemailid.Visible = true;
            txtboecertificateno.Enabled = false;
            txtboecertificateno.Text = Convert.ToString(dsboename.Tables[0].Rows[0]["CertificateNo"].ToString());
            txtboeaddress.Enabled = false;
            txtboeaddress.Text = Convert.ToString(dsboename.Tables[0].Rows[0]["PermanentAddress"].ToString());
            txtboemobileno.Enabled = false;
            txtboemobileno.Text = Convert.ToString(dsboename.Tables[0].Rows[0]["MobileNo"].ToString());
            txtboeEmailid.Enabled = false;
            txtboeEmailid.Text = Convert.ToString(dsboename.Tables[0].Rows[0]["EmailID"].ToString());
        }

    }
    public DataSet GetBoeDetails(string boenameid)
    {
        DataSet dsboedetails = new DataSet();
        SqlParameter[] pp = new SqlParameter[]
       {
             new SqlParameter("@boeid",SqlDbType.VarChar)
       };
        pp[0].Value = boenameid;
        dsboedetails = Gen.GenericFillDs("GetDetailsbyBOEID", pp);
        return dsboedetails;
    }
    public string ValidateControls()
    {
        int slno = 1;
        string ErrorMsg = "";

        if (txtboename.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter BOE Name \\n";
            slno = slno + 1;
        }
        if (txtboecertificateno.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter BOE certificate number \\n";
            slno = slno + 1;
        }
        if (txtboeaddress.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter BOE Permanent Address \\n";
            slno = slno + 1;
        }
        if (txtboemobileno.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter BOE mobile number \\n";
            slno = slno + 1;
        }
        if (txtboeEmailid.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter BOE Email Id \\n";
            slno = slno + 1;
        }
        if (labelboecertification.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Upload BOE certification \\n";
            slno = slno + 1;
        }
        if (labelboequalification.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Upload BOE Experience Certificate \\n";
            slno = slno + 1;
        }
        return ErrorMsg;
    }

    protected void btnregister_Click(object sender, EventArgs e)
    {
        string errormsg = ValidateControls();
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }

        //if (labelboecertification.Text == "")
        //{
        //    lblmsg0.Text = "<font color='red'>Please Upload BOE certification ..!</font>";
        //    success.Visible = false;
        //    Failure.Visible = true;
        //    return;
        //}

        DataSet ds = new DataSet();

        ds = InsertBoeRegistrationDetails(txtboename.Text, txtboecertificateno.Text, txtboeaddress.Text, txtboemobileno.Text, txtboeEmailid.Text);
        if (ds.Tables[0].Rows.Count > 0)
        {

            //ResetFormControl(this);
            lblmsg1.Text = "<font color='green'>Registered Successfully..!</font>";
            //  this.Clear();
            // BtnSave1.Enabled = false;
            success.Visible = true;
            Failure.Visible = false;
            trregister.Visible = false;
            trboename.Visible = false;
            //ddlthirdparty.ClearSelection();
            trboename.Visible = false;
            trboecertificateno.Visible = false;
            trboeaddress.Visible = false;
            trboemobileno.Visible = false;
            trboeemailid.Visible = false;
            rbtboeexistedinlist.ClearSelection();
            trboeexistedlist.Visible = false;
            ddlthirdparty_SelectedIndexChanged(this, EventArgs.Empty);
            trboecertification.Visible = false;
            trboequalification.Visible = false;
            trexperience.Visible = false;
            trboenamedropdown.Visible = true;
            trboeexistedlist.Visible = false;
        }
        else
        {
            lblmsg2.Text = "<font color='green'>Registration Failed..!</font>";
            //  this.Clear();
            // BtnSave1.Enabled = false;
            success.Visible = true;
            Failure.Visible = false;

        }
    }

    public DataSet InsertBoeRegistrationDetails(string boename,
string boecertificateno,
string boeaddress,
String boemobileno,
string boeemailid)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
             new SqlParameter("@boename",SqlDbType.VarChar),
                new SqlParameter("@boecertificateno",SqlDbType.VarChar),
               new SqlParameter("@boeaddress",SqlDbType.VarChar),
               new SqlParameter("@boemobileno",SqlDbType.VarChar),
               new SqlParameter("@boeemailid",SqlDbType.VarChar)

           };

        pp[0].Value = boename;
        pp[1].Value = boecertificateno;
        pp[2].Value = boeaddress;
        pp[3].Value = boemobileno;
        pp[4].Value = boeemailid;

        Dsnew = Gen.GenericFillDs("Sp_InsertintoBoeMaster", pp);
        return Dsnew;
    }


    protected void rbtboeexistedinlist_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (rbtboeexistedinlist.SelectedValue == "Y")
        // trboeexistedlist.Visible = true;
        {
            trboecertificateno.Visible = true;
            trboename.Visible = true;
            trboecertification.Visible = true;
            trboequalification.Visible = true;
            trboenamedropdown.Visible = false;

            trboeaddress.Visible = true;
            trboemobileno.Visible = true;
            trboeemailid.Visible = true;
            txtboecertificateno.Enabled = true;
            txtboeaddress.Enabled = true;
            txtboemobileno.Enabled = true;
            txtboeEmailid.Enabled = true;
            trregister.Visible = true;
            txtboename.Text = "";
            txtboecertificateno.Text = "";
            txtboeaddress.Text = "";
            txtboeEmailid.Text = "";
            txtboemobileno.Text = "";
            trexperience.Visible = true;
            ddlboeexperience.ClearSelection();
        }
        else
        {
            trboecertification.Visible = false;
            trboequalification.Visible = false;
            trboename.Visible = false;
            trboecertificateno.Visible = false;
            trboeaddress.Visible = false;
            trboemobileno.Visible = false;
            trboeemailid.Visible = false;
            txtboecertificateno.Enabled = false;

            txtboeaddress.Enabled = false;
            txtboemobileno.Enabled = false;
            txtboeEmailid.Enabled = false;
            trregister.Visible = false;
            txtboename.Text = "";
            txtboecertificateno.Text = "";
            txtboeaddress.Text = "";
            txtboeEmailid.Text = "";
            txtboemobileno.Text = "";
            trboenamedropdown.Visible = true;
            trexperience.Visible = false;

        }

    }

    protected void txtRegistrationNumber_TextChanged(object sender, EventArgs e)
    {
        txtRegistrationNumber.Text = txtRegistrationNumber.Text.ToUpper();
    }
}