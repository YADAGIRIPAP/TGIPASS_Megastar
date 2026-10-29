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
public partial class UI_TSiPASS_frmMobileTowerApplication : System.Web.UI.Page
{
    string cdmaflag;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    Cls_UserMobileTower objmobile = new Cls_UserMobileTower();
    GHMCTEST.WebService objghmc = new GHMCTEST.WebService();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }

        if (!IsPostBack)
        {
            BindDistricts();
            FillDetails();
        }
    }

    public void BindDistricts()
    {
        try
        {
            //DataSet dsd = new DataSet();
            //ddldistrict.Items.Clear();
            //dsd = Gen.GetDistrictsWithoutHYD();
            Cls_MasterofTsipass obj_newdistrictwargnal = new Cls_MasterofTsipass();
            DataSet dsd = new DataSet();
            ddldistrict.Items.Clear();
            dsd = obj_newdistrictwargnal.GetallDistrictswithoutWarangal(Convert.ToString(Session["uid"]), "MOBILETOWER");
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddldistrict.DataSource = dsd.Tables[0];
                ddldistrict.DataValueField = "District_Id";
                ddldistrict.DataTextField = "District_Name";
                ddldistrict.DataBind();
                ddldistrict.Items.Insert(0, "--District--");
            }
            else
            {
                ddldistrict.Items.Insert(0, "--District--");
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

    protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (ddldistrict.SelectedIndex == 0)
            {
                ddlmandal.Items.Clear();
                ddlmandal.Items.Insert(0, "--Mandal--");

                //ChkWater_reg_from.Items.Clear();
                //ChkWater_reg_from.Items.Insert(0, new ListItem("New Bore well", "New Bore well"));
                //ChkWater_reg_from.Items.Insert(1, new ListItem("HMWS & SB", "HMWS & SB"));
                //ChkWater_reg_from.Items.Insert(2, new ListItem("Rivers/Canals", "Rivers/Canals"));
            }
            else
            {


                ddlmandal.Items.Clear();
                DataSet dsm = new DataSet();
                dsm = Gen.GetMandals(ddldistrict.SelectedValue);
                if (dsm.Tables[0].Rows.Count > 0)
                {
                    ddlmandal.DataSource = dsm.Tables[0];
                    ddlmandal.DataValueField = "Mandal_Id";
                    ddlmandal.DataTextField = "Manda_lName";
                    ddlmandal.DataBind();
                    ddlmandal.Items.Insert(0, "--Mandal--");
                }
                else
                {
                    ddlmandal.Items.Clear();
                    ddlmandal.Items.Insert(0, "--Mandal--");
                }
            }
            if (ddldistrict.SelectedValue == "5")
            {
                traddressoftheapplicationheader.Visible = true;
                traddressoftheapplicationdetails.Visible = true;
                trLocationOfTheProposedSiteheader.Visible = true;
                trLocationOfTheProposedSitedetails.Visible = true;
                trDetailsOfTheProposedTITheader.Visible = true;
                trDetailsOfTheProposedTITdetails.Visible = true;
                trSetBacksofRoomheader.Visible = true;
                trSetBacksofRoomdetails.Visible = true;
                trLicenseTechnicalPersonalheader.Visible = true;
                trLicenseTechnicalPersonaldetails.Visible = true;
                divsaveclearbuttons.Visible = true;
                divuploadforms.Visible = false;


            }
            else
            {
                traddressoftheapplicationheader.Visible = false;
                traddressoftheapplicationdetails.Visible = false;
                trLocationOfTheProposedSiteheader.Visible = false;
                trLocationOfTheProposedSitedetails.Visible = false;
                trDetailsOfTheProposedTITheader.Visible = false;
                trDetailsOfTheProposedTITdetails.Visible = false;
                trSetBacksofRoomheader.Visible = false;
                trSetBacksofRoomdetails.Visible = false;
                trLicenseTechnicalPersonalheader.Visible = false;
                trLicenseTechnicalPersonaldetails.Visible = false;
                divsaveclearbuttons.Visible = false;
                divnextbuttons.Visible = false;
                divuploadforms.Visible = false;



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

    void FillDetails()
    {
        int CreatedBy = Convert.ToInt32(Session["uid"]);

        DataSet ds = new DataSet();

        try
        {
            //ds = Gen.getTraineeDetails(hdfID.Value.ToString());
            //if (Request.QueryString[0].ToString() != "")
            //{
            //    ds = objmobile.RetriveMobileTowerApplicationDetails(CreatedBy.ToString(), hdfFlagID0.Value.ToString());
            //}
            //else
            //{
            ds = objmobile.RetriveMobileTowerApplicationDetails("",CreatedBy.ToString());
            //}
            //ds = objmobile.RetriveMobileTowerApplicationDetails(hdfFlagID0.Value.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                string App_Status = Convert.ToString(ds.Tables[0].Rows[0]["App_Status"]);
                if (App_Status == "2")
                {
                    divnextbuttons.Visible = true;
                    divuploadforms.Visible = true;
                    //Session["Applid"] = Convert.ToString(ds.Tables[0].Rows[0]["cinemalicenseid"]);
                    //hdnTransactionNumber.Value = Convert.ToString(ds.Tables[0].Rows[0]["cinemalicenseid"]);
                    ddldistrict.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Proposeddistrict"]);
                    if (ddldistrict.SelectedValue == "5")
                    {
                        traddressoftheapplicationheader.Visible = true;
                        traddressoftheapplicationdetails.Visible = true;
                        trLocationOfTheProposedSiteheader.Visible = true;
                        trLocationOfTheProposedSitedetails.Visible = true;
                        trDetailsOfTheProposedTITheader.Visible = true;
                        trDetailsOfTheProposedTITdetails.Visible = true;
                        trSetBacksofRoomheader.Visible = true;
                        trSetBacksofRoomdetails.Visible = true;
                        trLicenseTechnicalPersonalheader.Visible = true;
                        trLicenseTechnicalPersonaldetails.Visible = true;
                        divsaveclearbuttons.Visible = true;
                        //divuploadforms.Visible = false;
                    }
                    hdnidentityid.Value = Convert.ToString(ds.Tables[0].Rows[0]["mobiletowerid"]);
                    txtname.Text = Convert.ToString(ds.Tables[0].Rows[0]["ProviderCompanyname"]);

                    txtdoor.Text = Convert.ToString(ds.Tables[0].Rows[0]["Door"]);
                    txtroad.Text = Convert.ToString(ds.Tables[0].Rows[0]["Road"]);
                    txtarea.Text = Convert.ToString(ds.Tables[0].Rows[0]["Area"]);
                    txtmandal.Text = Convert.ToString(ds.Tables[0].Rows[0]["Mandal"]);
                    txtdistrct.Text = Convert.ToString(ds.Tables[0].Rows[0]["Distrct"]);
                    txtpin.Text = Convert.ToString(ds.Tables[0].Rows[0]["Pincode"]);
                    txtmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                    txtplot.Text = Convert.ToString(ds.Tables[0].Rows[0]["Plotno"]);
                    txtlayout.Text = Convert.ToString(ds.Tables[0].Rows[0]["Layoutno"]);
                    txtsurvey.Text = Convert.ToString(ds.Tables[0].Rows[0]["Surveyno"]);
                    txtrevward.Text = Convert.ToString(ds.Tables[0].Rows[0]["Wardno"]);
                    txtrevblock.Text = Convert.ToString(ds.Tables[0].Rows[0]["Blockno"]);
                    txtdoorno.Text = Convert.ToString(ds.Tables[0].Rows[0]["Doorno"]);
                    txtstreetroad.Text = Convert.ToString(ds.Tables[0].Rows[0]["Streetroad"]);
                    txtward.Text = Convert.ToString(ds.Tables[0].Rows[0]["Eelectionwardno"]);
                    txtblock.Text = Convert.ToString(ds.Tables[0].Rows[0]["Electionblockno"]);

                    ddlcircle.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Circle"]);
                    ddlloc.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Locality"]);
                    txtaarea.Text = Convert.ToString(ds.Tables[0].Rows[0]["Proposedarea"]);

                    ddlmandal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Proposedmandal"]);
                    txtgpsdd.Text = Convert.ToString(ds.Tables[0].Rows[0]["Gpsddegree"]);
                    txtgpsmm.Text = Convert.ToString(ds.Tables[0].Rows[0]["Gpsmminit"]);
                    txtgpsss.Text = Convert.ToString(ds.Tables[0].Rows[0]["Gpsseconds"]);

                    txtdocument.Text = Convert.ToString(ds.Tables[0].Rows[0]["Siteareaasperdocment_cdma"]);
                    txtsubplan.Text = Convert.ToString(ds.Tables[0].Rows[0]["Siteareaasperplan_cdma"]);
                    txtwidenarea.Text = Convert.ToString(ds.Tables[0].Rows[0]["Roadwideningarea_cdma"]);
                    txtnet.Text = Convert.ToString(ds.Tables[0].Rows[0]["Netarea_cdma"]);
                    txteast.Text = Convert.ToString(ds.Tables[0].Rows[0]["East"]);
                    txtwest.Text = Convert.ToString(ds.Tables[0].Rows[0]["West"]);
                    txtnorth.Text = Convert.ToString(ds.Tables[0].Rows[0]["North"]);
                    txtsouth.Text = Convert.ToString(ds.Tables[0].Rows[0]["South"]);
                    ddlproposal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Proposals_cdma"]);
                    rdaccroom.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Accessoryroom"]);
                    rdgenroom.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Genaretorroom"]);
                    ddlproposed.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Proposedonbilding_cdma"]);
                    txtvltno.Text = Convert.ToString(ds.Tables[0].Rows[0]["Vacantlandtaxidno"]);
                    txtptino.Text = Convert.ToString(ds.Tables[0].Rows[0]["propertytaxidno"]);
                    txtperno.Text = Convert.ToString(ds.Tables[0].Rows[0]["Buildingpermissionno_cdma"]);
                    txtocccer.Text = Convert.ToString(ds.Tables[0].Rows[0]["Occpancycertificateno_cdma"]);

                    rdtbtncon.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Towerconstruction"]);
                    txtowner.Text = Convert.ToString(ds.Tables[0].Rows[0]["Ownername"]);
                    ddlnet.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Networkagency"]);

                    rdnlessee.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Licenseagreement"]);
                    txtleaseyears.Text = Convert.ToString(ds.Tables[0].Rows[0]["Leaseyears"]);
                    rdnauagent.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["AuthorisedAgent"]);
                    txtauagentname.Text = Convert.ToString(ds.Tables[0].Rows[0]["AuthorisedAgentName"]);
                    txtarchitectname.Text = Convert.ToString(ds.Tables[0].Rows[0]["Architectname"]);
                    txtarchitectno.Text = Convert.ToString(ds.Tables[0].Rows[0]["Architectno"]);
                    txtarchitectaddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["Architectaddress"]);
                    txtengname.Text = Convert.ToString(ds.Tables[0].Rows[0]["Engineername"]);
                    txtengno.Text = Convert.ToString(ds.Tables[0].Rows[0]["Engineerlicesenceno"]);
                    txtengaddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["Engineeraddress"]);
                    txtsurvename.Text = Convert.ToString(ds.Tables[0].Rows[0]["Surveyorname"]);
                    txtsurveno.Text = Convert.ToString(ds.Tables[0].Rows[0]["Surveyorno"]);
                    txtsurveaddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["Surveyoraddress"]);
                    txtstreng.Text = Convert.ToString(ds.Tables[0].Rows[0]["Structuralengneer"]);
                    txtstrenglicno.Text = Convert.ToString(ds.Tables[0].Rows[0]["Structuralengneerlicno"]);

                }

            }



            DataSet dsattachment = new DataSet();
            dsattachment = objmobile.ViewAttachmetsmobiltowerdata(hdfFlagID0.Value.ToString());

            if (dsattachment.Tables[0].Rows.Count > 0)
            {
                int c = dsattachment.Tables[0].Rows.Count;
                string sen, sen1, sen2;
                int i = 0;

                while (i < c)
                {
                    sen2 = dsattachment.Tables[0].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

                    if (sen.Contains("Location"))
                    {
                        hyperlocation.NavigateUrl = sen;
                        hyperlocation.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblloction.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("SitePlan"))
                    {
                        hyperSitePlan.NavigateUrl = sen;
                        hyperSitePlan.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblSitePlan.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("ElevationPlan"))
                    {
                        hyperelevationplan.NavigateUrl = sen;
                        hyperelevationplan.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblelevationplan.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("Sections"))
                    {
                        hyperSections.NavigateUrl = sen;
                        hyperSections.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblSections.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }

                    if (sen.Contains("StabilityCertificate"))
                    {
                        hyperstabilitycertificate.NavigateUrl = sen;
                        hyperstabilitycertificate.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblstabilitycertificate.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("SPBOcertificate"))
                    {
                        hyperSPBOcertificate.NavigateUrl = sen;
                        hyperSPBOcertificate.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblSPBOcertificate.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }

                    if (sen.Contains("OwnershipDocument"))
                    {
                        hyperownershipdocment.NavigateUrl = sen;
                        hyperownershipdocment.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblownershipdocment.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("LeasedAgreementDeed"))
                    {
                        hyperleaseagreementdeed.NavigateUrl = sen;
                        hyperleaseagreementdeed.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblleaseagreementdeed.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("Agreement"))
                    {
                        hyperagreement.NavigateUrl = sen;
                        hyperagreement.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblagreement.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("Towerdetails"))
                    {
                        hypertowerdetails.NavigateUrl = sen;
                        hypertowerdetails.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lbltowerdetails.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("IndemnityBond"))
                    {
                        hyperindemnitybond.NavigateUrl = sen;
                        hyperindemnitybond.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblindemnitybond.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("NoObjectionCertificate"))
                    {
                        hypernoobjectioncertificate.NavigateUrl = sen;
                        hypernoobjectioncertificate.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblnoobjectioncertificate.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("IssuePermission"))
                    {
                        hyperissuepermission.NavigateUrl = sen;
                        hyperissuepermission.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblissuepermission.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("NOCATCAAI"))
                    {
                        hyperNOCATCAAI.NavigateUrl = sen;
                        hyperNOCATCAAI.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblNOCATCAAI.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("CertificatefromDOT"))
                    {
                        hyperCertificatefromDOT.NavigateUrl = sen;
                        hyperCertificatefromDOT.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblCertificatefromDOT.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("Permitfee"))
                    {
                        Hyperpermitfee.NavigateUrl = sen;
                        Hyperpermitfee.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblpermitfee.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("NOCfrombuildowner"))
                    {
                        Hypernocfrombuildowner.NavigateUrl = sen;
                        Hypernocfrombuildowner.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblnocfrombuildowner.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("CertificateissuedARAI"))
                    {
                        HypercertificateissuedARAI.NavigateUrl = sen;
                        HypercertificateissuedARAI.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblcertificateissuedARAI.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    i++;
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
    protected void rbtproposedonbilding_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (rbtproposedonbilding.SelectedValue == "Y")
        //{
        //    trbuildingpermissionnumber.Visible = true;
        //    troccupancycertificatenumber.Visible = true;
        //    trbuildingpermissiondate.Visible = true;
        //    troccupancycertificatedate.Visible = true;
        //}
        //else
        //{
        //    trbuildingpermissionnumber.Visible = false;
        //    troccupancycertificatenumber.Visible = false;
        //    trbuildingpermissiondate.Visible = false;
        //    troccupancycertificatedate.Visible = false;
        //}
    }
    public string ValidateControls()
    {
        int slno = 1;
        string ErrorMsg = "";

        //if (ddlulb.SelectedValue == "0" || ddlulb.SelectedValue == "--Select--")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please select ULB type \\n";
        //    slno = slno + 1;
        //}
        //if (txtblockno.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please enter block number \\n";
        //    slno = slno + 1;
        //}

        //if (txtsiteareaasperdocument.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please enter site area  in Sqm As Per Document \\n";
        //    slno = slno + 1;
        //}
        //if (txtsiteareaasperplan.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please enter site area  in Sqm As Per Submitted Plan \\n";
        //    slno = slno + 1;
        //}

        //if (txtroadwideningarea.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please enter road widening area \\n";
        //    slno = slno + 1;
        //}

        //if (txtnetarea.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please enter net area \\n";
        //    slno = slno + 1;
        //}
        //if (ddlproposals.SelectedValue == "0" || ddlproposals.SelectedValue == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Select proposels \\n";
        //    slno = slno + 1;
        //}
        //if (rbtproposedonbilding.SelectedValue == "" || rbtproposedonbilding.SelectedValue == "null")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Select wheather If Proposed On Building(Building Permission & Occupancy Certificate ) \\n";
        //    slno = slno + 1;
        //}
        //if (rbtproposedonbilding.SelectedValue == "Y")
        //{
        //    if (txtbuildingpermissionno.Text == "")
        //    {
        //        ErrorMsg = ErrorMsg + slno + ". Please enter bilding permission no. \\n";
        //        slno = slno + 1;
        //    }

        //    if (txtoccupancycertificateno.Text == "")
        //    {
        //        ErrorMsg = ErrorMsg + slno + ". Please enter occupancy certificate no. \\n";
        //        slno = slno + 1;
        //    }

        //    if (txtbuildingpermissiondate.Text == "")
        //    {
        //        ErrorMsg = ErrorMsg + slno + ". Please enter bilding permission date. \\n";
        //        slno = slno + 1;
        //    }
        //    if (txtoccupancycertificatedate.Text == "")
        //    {
        //        ErrorMsg = ErrorMsg + slno + ". Please enter occupancy certificate date. \\n";
        //        slno = slno + 1;
        //    }

        //}
        //if (rbtproposedpoltorsite.SelectedValue == "" || rbtproposedpoltorsite.SelectedValue == "null")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Select Whether proposed on an open Plot/site ) \\n";
        //    slno = slno + 1;
        //}

        //if (rbtproposedpoltorsite.SelectedValue == "Y")
        //{
        //    if (txtplotorsitedocumentno.Text == "")
        //    {
        //        ErrorMsg = ErrorMsg + slno + ". Please enter plot/site document number  \\n";
        //        slno = slno + 1;
        //    }
        //}
        //if (lbllocationorsiteplan.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please upload location and site plan. \\n";
        //    slno = slno + 1;
        //}

        //if (lblelevationplan.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please upload elevation plan and sections. \\n";
        //    slno = slno + 1;
        //}

        //if (lblstabilitycertificate.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please upload structural stability certificate. \\n";
        //    slno = slno + 1;
        //}

        //if (lblownershipdocment.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please upload ownership docment. \\n";
        //    slno = slno + 1;
        //}

        //if (lblleaseagreementdeed.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please upload Lease Agreement Deed. \\n";
        //    slno = slno + 1;
        //}

        //if (lblagreement.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please upload Agreement copy. \\n";
        //    slno = slno + 1;
        //}

        //if (lblvicinitycertificate.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please upload verification certificate. \\n";
        //    slno = slno + 1;
        //}

        //if (lblindemnitybond.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please upload indemnity bond. \\n";
        //    slno = slno + 1;
        //}

        //if (lblnoobjectioncertificate.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please upload No objection certificate. \\n";
        //    slno = slno + 1;
        //}

        //if (lblissuepermission.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please upload Issue Permission Base On the copy Of SACFA. \\n";
        //    slno = slno + 1;
        //}
        return ErrorMsg;
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {

        if (BtnSave.Text == "Save")
        {
            string errormsg = ValidateControls();
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }



            Response objResp = new Response();
            int result = 0;
            int mobileid = 0;
            objResp = objmobile.InsertMobileTowerApplicationDetails("0", "0",
                txtname.Text, txtdoor.Text, txtroad.Text, txtarea.Text, txtmandal.Text, txtdistrct.Text, txtpin.Text, txtmail.Text,
                txtplot.Text, txtlayout.Text, txtsurvey.Text, txtrevward.Text, txtrevblock.Text, txtdoorno.Text, txtstreetroad.Text, txtward.Text,
                txtblock.Text, ddlcircle.SelectedValue, ddlloc.SelectedValue, txtaarea.Text, ddldistrict.SelectedValue, ddlmandal.SelectedValue,
                txtgpsdd.Text, txtgpsmm.Text, txtgpsss.Text,
                txtdocument.Text, txtsubplan.Text, txtwidenarea.Text, txtnet.Text,
               txteast.Text, txtwest.Text, txtnorth.Text, txtsouth.Text, ddlproposal.SelectedValue, rdaccroom.SelectedValue, rdgenroom.SelectedValue, ddlproposed.SelectedValue, txtvltno.Text,
               txtptino.Text, txtperno.Text, txtocccer.Text, rdtbtncon.SelectedValue, txtowner.Text, ddlnet.SelectedValue, rdnlessee.SelectedValue, txtleaseyears.Text, rdnauagent.SelectedValue,
               txtauagentname.Text, txtarchitectname.Text, txtarchitectno.Text, txtarchitectaddress.Text, txtengname.Text, txtengno.Text, txtengaddress.Text, txtsurvename.Text, txtsurveno.Text,
               txtsurveaddress.Text, txtstreng.Text, txtstrenglicno.Text, hdnidentityid.Value, Session["uid"].ToString(), out mobileid);

            //result = Gen.InsertMobileTowerApplicationDetails(Session["ApplidA"].ToString(), Request.QueryString[0], ddlulb.SelectedValue, txtblockno.Text, txtsiteareaasperdocument.Text,
            //txtsiteareaasperplan.Text, txtroadwideningarea.Text, txtnetarea.Text, ddlproposals.SelectedValue, rbtproposedonbilding.SelectedValue, rbtproposedpoltorsite.SelectedValue,
            //txtplotorsitedocumentno.Text, txtbuildingpermissionno.Text, txtoccupancycertificateno.Text, txtbuildingpermissiondate.Text, txtoccupancycertificatedate.Text,
            //   cdmaflag, hdnidentityid.Value, Session["uid"].ToString());

            Session["Applid"] = mobileid;
            if (objResp.ResponseVal == true)
            {
                hdnapplicationid.Value = mobileid.ToString();
                divuploadforms.Visible = true;
                //btnNext.Visible = true;
                divnextbuttons.Visible = true;
                //lblmsg.Text = "<font color='green'>Mobile Tower Application Details Saved Successfully..!</font>";
                //success.Visible = true;
                //Failure.Visible = false;
            }

        }


    }

    protected void btnlocation_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\MobileAttachments");

            General t1 = new General();
            if (fuplocation.HasFile)
            {
                if ((fuplocation.PostedFile != null) && (fuplocation.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fuplocation.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fuplocation.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["Applid"].ToString() + "\\Location");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fuplocation.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fuplocation.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = objmobile.InsertImagedatamobiletower(Session["Applid"].ToString(), Session["Applid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Location", "", Session["uid"].ToString(), DateTime.Now.ToString(), hdnidentityid.Value);


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                hyperlocation.Text = fuplocation.FileName;
                                lblloction.Text = fuplocation.FileName;
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
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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

    protected void btnsiteplan_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\MobileAttachments");

            General t1 = new General();
            if (fusiteplan.HasFile)
            {
                if ((fusiteplan.PostedFile != null) && (fusiteplan.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fusiteplan.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fusiteplan.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["Applid"].ToString() + "\\SitePlan");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fusiteplan.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fusiteplan.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = objmobile.InsertImagedatamobiletower(Session["Applid"].ToString(), Session["Applid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "SitePlan", "", Session["uid"].ToString(), DateTime.Now.ToString(), hdnidentityid.Value);


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                hyperSitePlan.Text = fusiteplan.FileName;
                                lblSitePlan.Text = fusiteplan.FileName;
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
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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

    protected void btnelevationplan_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\MobileAttachments");

            General t1 = new General();
            if (fupelevationplan.HasFile)
            {
                if ((fupelevationplan.PostedFile != null) && (fupelevationplan.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupelevationplan.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupelevationplan.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["Applid"].ToString() + "\\ElevationPlan");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupelevationplan.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupelevationplan.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = objmobile.InsertImagedatamobiletower(Session["Applid"].ToString(), Session["Applid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "ElevationPlan", "", Session["uid"].ToString(), DateTime.Now.ToString(), hdnidentityid.Value);


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                hyperelevationplan.Text = fupelevationplan.FileName;
                                lblelevationplan.Text = fupelevationplan.FileName;
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
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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

    protected void btnSections_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\MobileAttachments");

            General t1 = new General();
            if (fupSections.HasFile)
            {
                if ((fupSections.PostedFile != null) && (fupSections.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupSections.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupSections.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["Applid"].ToString() + "\\Sections");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupSections.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupSections.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = objmobile.InsertImagedatamobiletower(Session["Applid"].ToString(), Session["Applid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Sections", "", Session["uid"].ToString(), DateTime.Now.ToString(), hdnidentityid.Value);


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                hyperSections.Text = fupSections.FileName;
                                lblSections.Text = fupSections.FileName;
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
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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

    protected void btnstabilitycertificate_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\MobileAttachments");

            General t1 = new General();
            if (fupstabilitycertificate.HasFile)
            {
                if ((fupstabilitycertificate.PostedFile != null) && (fupstabilitycertificate.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupstabilitycertificate.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupstabilitycertificate.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["Applid"].ToString() + "\\StabilityCertificate");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupstabilitycertificate.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupstabilitycertificate.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = objmobile.InsertImagedatamobiletower(Session["Applid"].ToString(), Session["Applid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "StabilityCertificate", "", Session["uid"].ToString(), DateTime.Now.ToString(), hdnidentityid.Value);


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                hyperstabilitycertificate.Text = fupstabilitycertificate.FileName;
                                lblstabilitycertificate.Text = fupstabilitycertificate.FileName;
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
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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

    protected void btnSPBOC_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = Server.MapPath("~\\MobileAttachments");

            General t1 = new General();
            if (fupSPBOcertificate.HasFile)
            {
                if ((fupSPBOcertificate.PostedFile != null) && (fupSPBOcertificate.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupSPBOcertificate.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupSPBOcertificate.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["Applid"].ToString() + "\\SPBOcertificate");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupSPBOcertificate.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupSPBOcertificate.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = objmobile.InsertImagedatamobiletower(Session["Applid"].ToString(), Session["Applid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "SPBOcertificate", "", Session["uid"].ToString(), DateTime.Now.ToString(), hdnidentityid.Value);


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                hyperSPBOcertificate.Text = fupSPBOcertificate.FileName;
                                lblSPBOcertificate.Text = fupSPBOcertificate.FileName;
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
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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


    protected void btnownershipdocment_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\MobileAttachments");

            General t1 = new General();
            if (fupownershipdocment.HasFile)
            {
                if ((fupownershipdocment.PostedFile != null) && (fupownershipdocment.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupownershipdocment.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupownershipdocment.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["Applid"].ToString() + "\\OwnershipDocument");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupownershipdocment.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupownershipdocment.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = objmobile.InsertImagedatamobiletower(Session["Applid"].ToString(), Session["Applid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "OwnershipDocument", "", Session["uid"].ToString(), DateTime.Now.ToString(), hdnidentityid.Value);


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                hyperownershipdocment.Text = fupownershipdocment.FileName;
                                lblownershipdocment.Text = fupownershipdocment.FileName;
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
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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

    protected void btnleaseagreementdeed_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\MobileAttachments");

            General t1 = new General();
            if (fupleaseagreementdeed.HasFile)
            {
                if ((fupleaseagreementdeed.PostedFile != null) && (fupleaseagreementdeed.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupleaseagreementdeed.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupleaseagreementdeed.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["Applid"].ToString() + "\\LeasedAgreementDeed");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupleaseagreementdeed.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupleaseagreementdeed.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = objmobile.InsertImagedatamobiletower(Session["Applid"].ToString(), Session["Applid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "LeasedAgreementDeed", "", Session["uid"].ToString(), DateTime.Now.ToString(), hdnidentityid.Value);


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                hyperleaseagreementdeed.Text = fupleaseagreementdeed.FileName;
                                lblleaseagreementdeed.Text = fupleaseagreementdeed.FileName;
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
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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

    protected void btnagreement_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\MobileAttachments");

            General t1 = new General();
            if (fupagreement.HasFile)
            {
                if ((fupagreement.PostedFile != null) && (fupagreement.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupagreement.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupagreement.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["Applid"].ToString() + "\\Agreement");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupagreement.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupagreement.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = objmobile.InsertImagedatamobiletower(Session["Applid"].ToString(), Session["Applid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Agreement", "", Session["uid"].ToString(), DateTime.Now.ToString(), hdnidentityid.Value);


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                hyperagreement.Text = fupagreement.FileName;
                                lblagreement.Text = fupagreement.FileName;
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
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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

    protected void btntowerdetails_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\MobileAttachments");

            General t1 = new General();
            if (fuptowerdetails.HasFile)
            {
                if ((fuptowerdetails.PostedFile != null) && (fuptowerdetails.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fuptowerdetails.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fuptowerdetails.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["Applid"].ToString() + "\\Towerdetails");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fuptowerdetails.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fuptowerdetails.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = objmobile.InsertImagedatamobiletower(Session["Applid"].ToString(), Session["Applid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Towerdetails", "", Session["uid"].ToString(), DateTime.Now.ToString(), hdnidentityid.Value);


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                hypertowerdetails.Text = fuptowerdetails.FileName;
                                lbltowerdetails.Text = fuptowerdetails.FileName;
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
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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

    protected void btnindemnitybond_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\MobileAttachments");

            General t1 = new General();
            if (fupindemnitybond.HasFile)
            {
                if ((fupindemnitybond.PostedFile != null) && (fupindemnitybond.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupindemnitybond.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupindemnitybond.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["Applid"].ToString() + "\\IndemnityBond");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupindemnitybond.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupindemnitybond.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = objmobile.InsertImagedatamobiletower(Session["ApplidA"].ToString(), Session["Applid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "IndemnityBond", "", Session["uid"].ToString(), DateTime.Now.ToString(), hdnidentityid.Value);


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                hyperindemnitybond.Text = fupindemnitybond.FileName;
                                lblindemnitybond.Text = fupindemnitybond.FileName;
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
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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

    protected void btnnoobjectioncertificate_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\MobileAttachments");

            General t1 = new General();
            if (fupnoobjectioncertificate.HasFile)
            {
                if ((fupnoobjectioncertificate.PostedFile != null) && (fupnoobjectioncertificate.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupnoobjectioncertificate.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupnoobjectioncertificate.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["Applid"].ToString() + "\\NoObjectionCertificate");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupnoobjectioncertificate.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupnoobjectioncertificate.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = objmobile.InsertImagedatamobiletower(Session["Applid"].ToString(), Session["Applid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "NoObjectionCertificate", "", Session["uid"].ToString(), DateTime.Now.ToString(), hdnidentityid.Value);


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                hypernoobjectioncertificate.Text = fupnoobjectioncertificate.FileName;
                                lblnoobjectioncertificate.Text = fupnoobjectioncertificate.FileName;
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
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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

    protected void btnissuepermission_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\MobileAttachments");

            General t1 = new General();
            if (fupissuepermission.HasFile)
            {
                if ((fupissuepermission.PostedFile != null) && (fupissuepermission.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupissuepermission.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupissuepermission.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["Applid"].ToString() + "\\IssuePermission");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupissuepermission.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupissuepermission.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = objmobile.InsertImagedatamobiletower(Session["Applid"].ToString(), Session["Applid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "IssuePermission", "", Session["uid"].ToString(), DateTime.Now.ToString(), hdnidentityid.Value);


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                hyperissuepermission.Text = fupissuepermission.FileName;
                                lblissuepermission.Text = fupissuepermission.FileName;
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
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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

    protected void btnNOCATCAAI_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";

            string sFileDir = Server.MapPath("~\\MobileAttachments");

            General t1 = new General();
            if (fupNOCATCAAI.HasFile)
            {
                if ((fupNOCATCAAI.PostedFile != null) && (fupNOCATCAAI.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupNOCATCAAI.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupNOCATCAAI.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["Applid"].ToString() + "\\NOCATCAAI");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupNOCATCAAI.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupNOCATCAAI.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = objmobile.InsertImagedatamobiletower(Session["Applid"].ToString(), Session["Applid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "NOCATCAAI", "", Session["uid"].ToString(), DateTime.Now.ToString(), hdnidentityid.Value);


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                hyperNOCATCAAI.Text = fupNOCATCAAI.FileName;
                                lblNOCATCAAI.Text = fupNOCATCAAI.FileName;
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
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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

    protected void btnCertificatefromDOT_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";

            string sFileDir = Server.MapPath("~\\MobileAttachments");

            General t1 = new General();
            if (fupCertificatefromDOT.HasFile)
            {
                if ((fupCertificatefromDOT.PostedFile != null) && (fupCertificatefromDOT.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupCertificatefromDOT.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupCertificatefromDOT.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["Applid"].ToString() + "\\CertificatefromDOT");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupCertificatefromDOT.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupCertificatefromDOT.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = objmobile.InsertImagedatamobiletower(Session["Applid"].ToString(), Session["Applid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "CertificatefromDOT", "", Session["uid"].ToString(), DateTime.Now.ToString(), hdnidentityid.Value);


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                hyperCertificatefromDOT.Text = fupCertificatefromDOT.FileName;
                                lblCertificatefromDOT.Text = fupCertificatefromDOT.FileName;
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
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                            //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                        }

                    }
                    catch (Exception ex)//in case of an error
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

    protected void btnpermitfee_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";

            string sFileDir = Server.MapPath("~\\MobileAttachments");

            General t1 = new General();
            if (fuppermitfee.HasFile)
            {
                if ((fuppermitfee.PostedFile != null) && (fuppermitfee.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fuppermitfee.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fuppermitfee.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["Applid"].ToString() + "\\Permitfee");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fuppermitfee.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fuppermitfee.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = objmobile.InsertImagedatamobiletower(Session["Applid"].ToString(), Session["Applid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Permitfee", "", Session["uid"].ToString(), DateTime.Now.ToString(), hdnidentityid.Value);


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                Hyperpermitfee.Text = fuppermitfee.FileName;
                                lblpermitfee.Text = fuppermitfee.FileName;
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
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                            //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                        }

                    }
                    catch (Exception ex)//in case of an error
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

    protected void btnnocfrombuildowner_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";

            string sFileDir = Server.MapPath("~\\MobileAttachments");

            General t1 = new General();
            if (fupnocfrombuildowner.HasFile)
            {
                if ((fupnocfrombuildowner.PostedFile != null) && (fupnocfrombuildowner.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupnocfrombuildowner.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupnocfrombuildowner.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["Applid"].ToString() + "\\NOCfrombuildowner");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupnocfrombuildowner.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupnocfrombuildowner.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = objmobile.InsertImagedatamobiletower(Session["Applid"].ToString(), Session["Applid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "NOCfrombuildowner", "", Session["uid"].ToString(), DateTime.Now.ToString(), hdnidentityid.Value);


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                Hypernocfrombuildowner.Text = fupnocfrombuildowner.FileName;
                                lblnocfrombuildowner.Text = fupnocfrombuildowner.FileName;
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
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                            //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                        }

                    }
                    catch (Exception ex)//in case of an error
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

    protected void btncertificateissuedARAI_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";

            string sFileDir = Server.MapPath("~\\MobileAttachments");

            General t1 = new General();
            if (fupcertificateissuedARAI.HasFile)
            {
                if ((fupcertificateissuedARAI.PostedFile != null) && (fupcertificateissuedARAI.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupcertificateissuedARAI.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupcertificateissuedARAI.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["Applid"].ToString() + "\\CertificateissuedARAI");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupcertificateissuedARAI.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupcertificateissuedARAI.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = objmobile.InsertImagedatamobiletower(Session["Applid"].ToString(), Session["Applid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "CertificateissuedARAI", "", Session["uid"].ToString(), DateTime.Now.ToString(), hdnidentityid.Value);


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                HypercertificateissuedARAI.Text = fupcertificateissuedARAI.FileName;
                                lblcertificateissuedARAI.Text = fupcertificateissuedARAI.FileName;
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
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                            //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                        }

                    }
                    catch (Exception ex)//in case of an error
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

    protected void rbtproposedpoltorsite_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (rbtproposedpoltorsite.SelectedValue == "Y")
        //{
        //    trplotorsitedocumentno.Visible = true;
        //}
        //else
        //{
        //    trplotorsitedocumentno.Visible = false;
        //}

    }

    protected void btnNext0_Click(object sender, EventArgs e)
    {

        txtname.Text = "";
        txtdoor.Text = "";
        txtroad.Text = "";
        txtarea.Text = "";
        txtmandal.Text = "";
        txtdistrct.Text = "";
        txtpin.Text = "";
        txtmail.Text = "";
        txtplot.Text = "";
        txtlayout.Text = "";
        txtsurvey.Text = "";
        txtrevward.Text = "";
        txtrevblock.Text = "";
        txtdoorno.Text = "";
        txtstreetroad.Text = "";
        txtward.Text = "";
        txtblock.Text = "";
        ddlcircle.SelectedValue = "0";
        ddlloc.SelectedValue = "0";
        txtaarea.Text = "";
        ddldistrict.SelectedValue = "";
        ddlmandal.SelectedValue = "";
        txtgpsdd.Text = "";
        txtgpsmm.Text = "";
        txtgpsss.Text = "";
        txtdocument.Text = "";
        txtsubplan.Text = "";
        txtwidenarea.Text = "";
        txtnet.Text = "";
        txteast.Text = "";
        txtwest.Text = "";
        txtnorth.Text = "";
        txtsouth.Text = "";
        ddlproposal.SelectedValue = "0";
        rdaccroom.ClearSelection();
        rdgenroom.ClearSelection();
        ddlproposed.SelectedValue = "0";
        txtvltno.Text = "";
        txtptino.Text = "";
        txtperno.Text = "";
        txtocccer.Text = "";
        rdtbtncon.ClearSelection();
        txtowner.Text = "";
        ddlnet.SelectedValue = "0";
        rdnlessee.ClearSelection();
        txtleaseyears.Text = "";
        rdnauagent.ClearSelection();
        txtauagentname.Text = "";
        txtarchitectname.Text = "";
        txtarchitectno.Text = "";
        txtarchitectaddress.Text = "";
        txtengname.Text = "";
        txtengno.Text = "";
        txtengaddress.Text = "";
        txtsurvename.Text = "";
        txtsurveno.Text = "";
        txtsurveaddress.Text = "";
        txtstreng.Text = "";
        txtstrenglicno.Text = "";


        divnextbuttons.Visible = false;

    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        string errormsg = ValidateControls();
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        Response objResp = new Response();
        int result = 0;
        int mobileid = 0;
        objResp = objmobile.InsertMobileTowerApplicationDetails("0", "0", txtname.Text, txtdoor.Text, txtroad.Text, txtarea.Text, txtmandal.Text, txtdistrct.Text, txtpin.Text, txtmail.Text,
              txtplot.Text, txtlayout.Text, txtsurvey.Text, txtrevward.Text, txtrevblock.Text, txtdoorno.Text, txtstreetroad.Text, txtward.Text,
              txtblock.Text, ddlcircle.SelectedValue, ddlloc.SelectedValue, txtaarea.Text, ddldistrict.SelectedValue, ddlmandal.SelectedValue,
              txtgpsdd.Text, txtgpsmm.Text, txtgpsss.Text,
              txtdocument.Text, txtsubplan.Text, txtwidenarea.Text, txtnet.Text,
             txteast.Text, txtwest.Text, txtnorth.Text, txtsouth.Text, ddlproposal.SelectedValue, rdaccroom.SelectedValue, rdgenroom.SelectedValue, ddlproposed.SelectedValue, txtvltno.Text,
             txtptino.Text, txtperno.Text, txtocccer.Text, rdtbtncon.SelectedValue, txtowner.Text, ddlnet.SelectedValue, rdnlessee.SelectedValue, txtleaseyears.Text, rdnauagent.SelectedValue,
             txtauagentname.Text, txtarchitectname.Text, txtarchitectno.Text, txtarchitectaddress.Text, txtengname.Text, txtengno.Text, txtengaddress.Text, txtsurvename.Text, txtsurveno.Text,
             txtsurveaddress.Text, txtstreng.Text, txtstrenglicno.Text, hdnidentityid.Value, Session["uid"].ToString(), out mobileid);

        Session["Applid"] = mobileid;
        if (objResp.ResponseVal == true)
        {
            hdnapplicationid.Value = mobileid.ToString();
            lblmsg.Text = "<font color='green'>Mobile Tower Application Details Saved Successfully..!</font>";
            success.Visible = true;
            Failure.Visible = false;
        }
        if (hdnapplicationid.Value.ToString().Trim() == "" || hdnapplicationid.Value.Trim() == "0")
        {
            Response.Redirect("frmMobileTowerApplication.aspx");
        }
        else
        {
            Response.Redirect("frmPaymentMobileTower.aspx?intApplicationId=" + hdnapplicationid.Value);
        }

    }

    protected void ddlcircle_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlcircle.SelectedValue != "0")
            {
                DataSet dscat = new DataSet();
                dscat = objghmc.CELLOCALITYLIST(ddlcircle.SelectedValue);
                if (dscat != null && dscat.Tables.Count > 0 && dscat.Tables[0].Rows.Count > 0)
                {
                    ddlloc.DataSource = dscat.Tables[0];
                    ddlloc.DataTextField = "BB";
                    ddlloc.DataValueField = "AA";
                    ddlloc.DataBind();
                    AddSelect(ddlloc);
                }
                else
                {
                    ddlloc.Items.Clear();
                    AddSelect(ddlloc);
                }

            }
        }
        catch (Exception ex)
        {
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
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }

    public void BindWhetherProposed()
    {
        DataSet dscircle = new DataSet();

        dscircle = objghmc.CELPROPOSALLIST();
        if (dscircle != null && dscircle.Tables.Count > 0 && dscircle.Tables[0].Rows.Count > 0)
        {
            ddlproposal.DataSource = dscircle.Tables[0];
            ddlproposal.DataTextField = "CIRCLE_NAME";
            ddlproposal.DataValueField = "CIRCLE_NO";
            ddlproposal.DataBind();
            AddSelect(ddlcircle);
        }
        else
        {
            ddlcircle.Items.Clear();
            AddSelect(ddlcircle);
        }
    }

    protected void ddlproposal_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlproposal.SelectedValue != "0")
            {
                DataSet dscat = new DataSet();
                dscat = objghmc.CELWHETHERPROPOSEDLIST(ddlproposal.SelectedValue);
                if (dscat != null && dscat.Tables.Count > 0 && dscat.Tables[0].Rows.Count > 0)
                {
                    ddlproposed.DataSource = dscat.Tables[0];
                    ddlproposed.DataTextField = "BB";
                    ddlproposed.DataValueField = "AA";
                    ddlproposed.DataBind();
                    AddSelect(ddlproposed);
                }
                else
                {
                    ddlloc.Items.Clear();
                    AddSelect(ddlproposed);
                }

            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void ddlProp_intMandalid_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlmandal.SelectedIndex == 0)
            {

                ddlProp_intVillageid.Items.Clear();
                ddlProp_intVillageid.Items.Insert(0, "--Village--");
            }
            else
            {
                ddlProp_intVillageid.Items.Clear();
                DataSet dsv = new DataSet();
                dsv = Gen.GetVillages(ddlmandal.SelectedValue);
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
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }

    }

}

