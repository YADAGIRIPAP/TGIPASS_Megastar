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
public partial class TSTBDCReg1 : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
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

                dsver = Gen.GetverifyofqueBoiler9CFO(Session["ApplidA"].ToString());

                if (dsver.Tables[0].Rows.Count > 0)
                {
                    string res = Gen.RetriveStatusCFO(Session["ApplidA"].ToString());
                    ////string res = Gen.RetriveStatus("1002");


                    if (res == "3" || Convert.ToInt32(res) >= 3)
                    {
                        ResetFormControl(this);

                    }
                    //else
                    //{
                    //    ViewState["Enable"] = "Y";
                    //}
                }

            }


            if (!IsPostBack)
            {
                //string res = Gen.RetriveStatusBoilersCFO(Session["ApplidA"].ToString());

                //if (res == "Y")
                //{

                //}
                DataSet dsnew = new DataSet();
                dsnew = Gen.getdataofidentityCFONewBoiler(Session["ApplidA"].ToString(), "27");
                if (dsnew.Tables[0].Rows.Count > 0)
                {

                }
                else
                {
                    if (Request.QueryString[1].ToString() == "N")
                    {

                        Response.Redirect("frmCFOPCBDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");

                    }
                    else
                    {
                        Response.Redirect("frmCAFFactoryDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&Previous=" + "P");

                    }

                }



            }

            if (!IsPostBack)
            {

                getstates();
                DataSet ds = new DataSet();
                ds = Gen.GetdataofCFOBoiler(Session["uid"].ToString());

                if (ds.Tables[0].Rows.Count > 0)
                {

                    FillDetails();

                }
            }
            if (trerector.Visible && trerector.Visible)// if new registration
            {
                if (LabelErector.Text == "")
                {
                    FileUploadErector.Enabled = true;
                }
            }
            if (trreqdoc.Visible)
            {
                if (LabelRequiredDoc.Text == "")
                {
                    FileUploadRequiredDoc.Enabled = true;
                }
            }
            if (trotherdoc.Visible)
            {
                if (LabelOtherDoc.Text == "")
                {
                    FileUploadOtherDoc.Enabled = true;
                }
            }
            if (trformvi.Visible)
            {
                if (LabelFormVI.Text == "")
                {
                    FileUploadFormVI.Enabled = true;
                }
            }
            if (trformv.Visible)
            {
                if (LabelFormV.Text == "")
                {
                    FileUploadFormV.Enabled = true;
                }
            }
            if (trdrawing.Visible)
            {
                if (LabelDrawing.Text == "")
                {
                    FileUploadDrawing.Enabled = true;
                }
            }
            if (trcbb.Visible)
            {
                if (LabelCBB.Text == "")
                {
                    FileUploadCBB.Enabled = true;
                }
            }
            if (trAnnexure.Visible)
            {
                if (LabelAnexure.Text == "")
                {
                    FileUploadAnexure.Enabled = true;
                }
            }
            if (ddlerectorclass.SelectedItem.Text == "--Select--")
            {
                ddlerectorclass.Enabled = true;
            }
            if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
            {

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
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
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
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
                DataSet ds = new DataSet();

                ds = Gen.GetdataofCFOBoiler(Session["uid"].ToString());

                if (ds.Tables[0].Rows.Count > 0)
                {
                    int result = 0;

                    result = Gen.insertCFOBoiler(Session["uid"].ToString(), Session["ApplidA"].ToString(), Session["uid"].ToString(), "", "", txtRegistrationNumber.Text, txtNameOfOwner.Text, txtWhereStudied.Text, txtDateOfInspection.Text, txtDescriptionofboilersAge.Text, txtMakersName.Text, ddlTypeofBoiler.SelectedValue, ddlBoilersUsedfor.SelectedValue, txtMakersNumber.Text, txtPlace.Text, txtYear.Text, txtAllowedMaximumPresure.Text, txtEconomiserMarker.Text, txtBoilerRatingSurface.Text, txtMaximumContinousEvapration.Text, txtClassofErector.Text, txtNameOfErector.Text, ddlState.SelectedValue.ToString(), txtMaximumPresureofEconomiser.Text, txtTotalLengthOfStreamPipeLine.Text, Session["uid"].ToString(), Session["uid"].ToString(), txtcomponentperson.Text.Trim(), ddlinspector.SelectedValue, ddlerectorclass.SelectedItem.Text.Trim());
                    if (result > 0)
                    {
                        lblmsg.Text = "<font color='green'>CFO Boiler Details Saved Successfully..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;

                    }
                    else if (result == 0)
                    {
                        lblmsg.Text = "<font color='green'>Boiler Details Updated Successfully..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                    }
                }
                else
                {
                    int result = 0;
                    result = Gen.insertCFOBoiler(Session["uid"].ToString(), Session["ApplidA"].ToString(), Session["uid"].ToString(), "", "", txtRegistrationNumber.Text, txtNameOfOwner.Text, txtWhereStudied.Text, txtDateOfInspection.Text, txtDescriptionofboilersAge.Text, txtMakersName.Text, ddlTypeofBoiler.SelectedValue, ddlBoilersUsedfor.SelectedValue, txtMakersNumber.Text, txtPlace.Text, txtYear.Text, txtAllowedMaximumPresure.Text, txtEconomiserMarker.Text, txtBoilerRatingSurface.Text, txtMaximumContinousEvapration.Text, txtClassofErector.Text, txtNameOfErector.Text, ddlState.SelectedValue, txtMaximumPresureofEconomiser.Text, txtTotalLengthOfStreamPipeLine.Text, Session["uid"].ToString(), Session["uid"].ToString(), txtcomponentperson.Text.Trim(), ddlinspector.SelectedValue, ddlerectorclass.SelectedItem.Text.Trim());

                    if (result > 0)
                    {
                        lblmsg.Text = "<font color='green'>CFO Boiler Details Saved Successfully..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;

                    }
                    else
                    {
                        lblmsg.Text = "<font color='green'>CFO Boiler Details Submission Failed..!</font>";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
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
        try
        {
            if (BtnDelete.Text == "Next")
            {
                //if (ViewState["Enable"] != null && ViewState["Enable"] != "" && ViewState["Enable"].ToString() == "Y")
                //{
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

                //}
                DataSet ds = new DataSet();

                ds = Gen.GetdataofCFOBoiler(Session["uid"].ToString());

                if (ds.Tables[0].Rows.Count > 0)
                {
                    int result = 0;

                    result = Gen.insertCFOBoiler(Session["uid"].ToString(), Session["ApplidA"].ToString(), Session["uid"].ToString(), "", "", txtRegistrationNumber.Text, txtNameOfOwner.Text, txtWhereStudied.Text, txtDateOfInspection.Text, txtDescriptionofboilersAge.Text, txtMakersName.Text, ddlTypeofBoiler.SelectedValue, ddlBoilersUsedfor.SelectedValue, txtMakersNumber.Text, txtPlace.Text, txtYear.Text, txtAllowedMaximumPresure.Text, txtEconomiserMarker.Text, txtBoilerRatingSurface.Text, txtMaximumContinousEvapration.Text, txtClassofErector.Text, txtNameOfErector.Text, ddlState.SelectedValue, txtMaximumPresureofEconomiser.Text, txtTotalLengthOfStreamPipeLine.Text, Session["uid"].ToString(), Session["uid"].ToString(), txtcomponentperson.Text.Trim(), ddlinspector.SelectedValue, ddlerectorclass.SelectedItem.Text.Trim());
                    if (result > 0)
                    {

                        Response.Redirect("frmCFOPCBDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
                        lblmsg.Text = "<font color='green'>CFO Boiler Details Saved Successfully..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;

                    }
                    else if (result == 0)
                    {
                        Response.Redirect("frmCFOPCBDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
                        lblmsg.Text = "<font color='green'>Boiler Details Updated Successfully..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                    }
                }
                else
                {
                    int result = 0;
                    result = Gen.insertCFOBoiler(Session["uid"].ToString(), Session["ApplidA"].ToString(), Session["uid"].ToString(), "", "", txtRegistrationNumber.Text, txtNameOfOwner.Text, txtWhereStudied.Text, txtDateOfInspection.Text, txtDescriptionofboilersAge.Text, txtMakersName.Text, ddlTypeofBoiler.SelectedValue, ddlBoilersUsedfor.SelectedValue, txtMakersNumber.Text, txtPlace.Text, txtYear.Text, txtAllowedMaximumPresure.Text, txtEconomiserMarker.Text, txtBoilerRatingSurface.Text, txtMaximumContinousEvapration.Text, txtClassofErector.Text, txtNameOfErector.Text, ddlState.SelectedValue, txtMaximumPresureofEconomiser.Text, txtTotalLengthOfStreamPipeLine.Text, Session["uid"].ToString(), Session["uid"].ToString(), txtcomponentperson.Text.Trim(), ddlinspector.SelectedValue, ddlerectorclass.SelectedItem.Text.Trim());

                    if (result > 0)
                    {
                        Response.Redirect("frmCFOPCBDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
                        lblmsg.Text = "<font color='green'>CFO Boiler Details Saved Successfully..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;

                    }
                    else
                    {
                        lblmsg.Text = "<font color='green'>CFO Boiler Details Submission Failed..!</font>";
                    }
                }


            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }

    }
    void FillDetails()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = Gen.GetdataofCFOBoiler(Session["uid"].ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {

                txtRegistrationNumber.Text = ds.Tables[0].Rows[0]["Reg_No_Boiler"].ToString();
                txtNameOfOwner.Text = ds.Tables[0].Rows[0]["Name_Owner"].ToString();
                txtWhereStudied.Text = ds.Tables[0].Rows[0]["Location"].ToString();
                if (ds.Tables[0].Rows[0]["Date_Inpec_Desirable"].ToString().Trim() != "")
                {
                    txtDateOfInspection.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Date_Inpec_Desirable"]).ToString("dd-MMM-yyyy");
                }
                txtDescriptionofboilersAge.Text = ds.Tables[0].Rows[0]["Desc_Boiler_Age"].ToString();
                txtMakersName.Text = ds.Tables[0].Rows[0]["Makers_name"].ToString();
                ddlTypeofBoiler.SelectedValue = ds.Tables[0].Rows[0]["Type_Boiler"].ToString();
                ddlBoilersUsedfor.SelectedValue = ds.Tables[0].Rows[0]["Boiler_User_for"].ToString();
                txtMakersNumber.Text = ds.Tables[0].Rows[0]["Boiler_ration"].ToString();
                txtPlace.Text = ds.Tables[0].Rows[0]["Place_Manfacture"].ToString();
                txtYear.Text = ds.Tables[0].Rows[0]["Year_Manfacture"].ToString();
                txtAllowedMaximumPresure.Text = ds.Tables[0].Rows[0]["Allowed_Max_Presure"].ToString();
                txtEconomiserMarker.Text = ds.Tables[0].Rows[0]["Econ_Maker_Number"].ToString();
                txtBoilerRatingSurface.Text = ds.Tables[0].Rows[0]["Heating_Surface_boiler"].ToString();
                txtMaximumContinousEvapration.Text = ds.Tables[0].Rows[0]["Max_Conti_Evapron"].ToString();
                txtClassofErector.Text = ds.Tables[0].Rows[0]["Class_Erector"].ToString();
                txtNameOfErector.Text = ds.Tables[0].Rows[0]["Name_of_Erector"].ToString();
                getstates();
                ddlState.SelectedValue = ds.Tables[0].Rows[0]["State_Erector"].ToString();
                txtMaximumPresureofEconomiser.Text = ds.Tables[0].Rows[0]["Max_Presure_Econ"].ToString();
                txtTotalLengthOfStreamPipeLine.Text = ds.Tables[0].Rows[0]["Tot_Lenght_Steam_PipeLine"].ToString();
                if (ds.Tables[0].Rows[0]["InspectingAuthorityType"].ToString().Trim() != "")
                {
                    ddlinspector.SelectedValue = ddlinspector.Items.FindByValue(ds.Tables[0].Rows[0]["InspectingAuthorityType"].ToString().Trim()).Value;
                }
                if (ds.Tables[0].Rows[0]["ComponentPerson"].ToString().Trim() != "")
                {
                    txtcomponentperson.Text = ds.Tables[0].Rows[0]["ComponentPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ErectorClass"].ToString().Trim() != "")
                {
                    ddlerectorclass.SelectedItem.Text = ds.Tables[0].Rows[0]["ErectorClass"].ToString().Trim();
                }
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
                            sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/CFOAttachments")), "https://ipass.telangana.gov.in/TS-iPASSAttachments/");

                            if (sen.Contains("ErectorLicense"))
                            {
                                lblFileNameErector.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                                lblFileNameErector.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                LabelErector.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                //HyperLink1.NavigateUrl = sen;
                                //HyperLink1.Text = 
                            }

                            if (sen.Contains("BoilerRequiredDoc"))
                            {
                                HyperLinkRequiredDoc.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
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
                                HyperLinkFormVI.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                                HyperLinkFormVI.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                LabelFormVI.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                            }

                            if (sen.Contains("BoilerFormV"))
                            {
                                HyperLinkFormV.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                                HyperLinkFormV.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                LabelFormV.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                            }

                            if (sen.Contains("BoilerDrawing"))
                            {
                                HyperLinkDrawing.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                                HyperLinkDrawing.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                LabelDrawing.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                            }


                            if (sen.Contains("BoilerCBB"))
                            {
                                HyperLinkCBB.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                                HyperLinkCBB.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                LabelCBB.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                            }

                            if (sen.Contains("BoilerAnexure"))
                            {
                                HyperLinkAnexure.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                                HyperLinkAnexure.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                LabelAnexure.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                            }
                        }
                        i++;
                    }

                }

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
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
        Response.Redirect("frmCAFFactoryDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&Previous=" + "P");
    }
    protected void ddlinspector_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlinspector.SelectedValue == "2")
            {
                trthirdpraty.Visible = true;
                trcbb.Visible = true;
                trformvi.Visible = true;
                trformv.Visible = true;
                trAnnexure.Visible = true;
                trdrawing.Visible = true;
            }
            else
            {
                trthirdpraty.Visible = false;
                trcbb.Visible = false;
                trformvi.Visible = false;
                trformv.Visible = false;
                trAnnexure.Visible = false;
                trdrawing.Visible = false;
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
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

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
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\ErectorLicense");
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

                            result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ErectorLicense");


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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void btnreqdoc_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

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
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\BoilerRequiredDoc");
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

                            result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "BoilerRequiredDocuments");


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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void btnanyotherdoc_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

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
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\BoilerOtherDoc");
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

                            result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "BoilerOtherDocument");


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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void btnformvi_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

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
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\BoilerFormVI");
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

                            result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "BoilerFormVI");


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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void btnformv_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

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
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\BoilerFormV");
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

                            result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "BoilerFormV");


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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void btndrawing_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

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
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\BoilerDrawing");
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

                            result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "LandDeedFORM");


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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void btnuploadcbb_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

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
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\BoilerCBB");
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

                            result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "BoilerCBB");


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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void Btnanexure_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

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
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\BoilerAnexure");
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

                            result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "BoilerAnexure");


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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
}
