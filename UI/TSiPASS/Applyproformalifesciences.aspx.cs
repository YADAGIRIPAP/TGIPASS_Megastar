using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;


public partial class UI_TSiPASS_Applyproformalifesciences : System.Web.UI.Page
{
    string MSMENO = "";
    Cls_MSMEProformalifesciences obj_insert = new Cls_MSMEProformalifesciences();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] != null)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["MSMENO"] != null && Request.QueryString["MSMENO"] != "")
                {
                    MSMENO = Request.QueryString["MSMENO"].ToString().Trim();
                    hf_msmeno.Value = Request.QueryString["MSMENO"].ToString().Trim();
                    BindPDLSLegalStatusOfOrgMaster();
                    BindPDLSOrganizationtypeMaster();
                    BindPDLSFocusSectorMaster();
                    BindPDLSCoreCapabilitiesmaster();
                    BindPDLSGlobalPartnershipMaster();
                    FillDetails();
                }
            }
        }
    }
    #region Master
    public void BindPDLSLegalStatusOfOrgMaster()
    {
        try
        {
            ddl_LegalStatusofOrganization.Items.Clear();
            DataTable dsd = obj_insert.DB_PDLSLegalStatusOfOrgMaster();
            if (dsd != null && dsd.Rows.Count > 0)
            {
                ddl_LegalStatusofOrganization.DataSource = dsd;
                ddl_LegalStatusofOrganization.DataValueField = "LegalStatusOrgID";
                ddl_LegalStatusofOrganization.DataTextField = "LegalStatusOrgName";
                ddl_LegalStatusofOrganization.DataBind();
                AddSelect(ddl_LegalStatusofOrganization);
            }
            else
            {
                AddSelect(ddl_LegalStatusofOrganization);
            }
        }
        catch (Exception ex)
        {

        }
    }
    public void BindPDLSOrganizationtypeMaster()
    {
        try
        {
            ddl_fsOrganizationType.Items.Clear();
            DataTable dsd = obj_insert.DB_PDLSOrganizationtypeMaster();
            if (dsd != null && dsd.Rows.Count > 0)
            {
                ddl_fsOrganizationType.DataSource = dsd;
                ddl_fsOrganizationType.DataValueField = "OrganizationtypeID";
                ddl_fsOrganizationType.DataTextField = "OrganizationtypeName";
                ddl_fsOrganizationType.DataBind();
                AddSelect(ddl_fsOrganizationType);
            }
            else
            {
                AddSelect(ddl_fsOrganizationType);
            }
        }
        catch (Exception ex)
        {

        }
    }
    public void BindPDLSFocusSectorMaster()
    {
        try
        {
            ddl_FocusSectors.Items.Clear();
            DataTable dsd = obj_insert.DB_PDLSFocusSectorMaster();
            if (dsd != null && dsd.Rows.Count > 0)
            {
                ddl_FocusSectors.DataSource = dsd;
                ddl_FocusSectors.DataValueField = "FocusSectorId";
                ddl_FocusSectors.DataTextField = "FocusSectorName";
                ddl_FocusSectors.DataBind();
                AddSelect(ddl_FocusSectors);
            }
            else
            {
                AddSelect(ddl_FocusSectors);
            }
        }
        catch (Exception ex)
        {

        }
    }
    public void BindPDLSCoreCapabilitiesmaster()
    {
        try
        {
            ddl_cmocorecapabilities.Items.Clear();
            DataTable dsd = obj_insert.DB_PDLSCoreCapabilitiesmaster();
            if (dsd != null && dsd.Rows.Count > 0)
            {
                ddl_cmocorecapabilities.DataSource = dsd;
                ddl_cmocorecapabilities.DataValueField = "CoreCapabilitiesID";
                ddl_cmocorecapabilities.DataTextField = "CoreCapabilitiesName";
                ddl_cmocorecapabilities.DataBind();
                AddSelect(ddl_cmocorecapabilities);
            }
            else
            {
                AddSelect(ddl_cmocorecapabilities);
            }
        }
        catch (Exception ex)
        {

        }
    }
    public void BindPDLSGlobalPartnershipMaster()
    {
        try
        {
            ddl_ctrInterestedinGlobalPartnership.Items.Clear();
            DataTable dsd = obj_insert.DB_PDLSGlobalPartnershipMaster();
            if (dsd != null && dsd.Rows.Count > 0)
            {
                ddl_ctrInterestedinGlobalPartnership.DataSource = dsd;
                ddl_ctrInterestedinGlobalPartnership.DataValueField = "GlobalPartnershipID";
                ddl_ctrInterestedinGlobalPartnership.DataTextField = "GlobalPartnershipName";
                ddl_ctrInterestedinGlobalPartnership.DataBind();
                AddSelect(ddl_ctrInterestedinGlobalPartnership);
            }
            else
            {
                AddSelect(ddl_ctrInterestedinGlobalPartnership);
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
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }


    #endregion

    #region fill incomplete details
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
    public void FillDetails()
    {
        DataSet ds = obj_insert.getdetailsproformaofdirectorlifesciencesbymsmeno(Convert.ToString(MSMENO));
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    try
                    {

                        hf_PDLSID.Value = Convert.ToString(ds.Tables[0].Rows[0]["PDLSID"]);
                        hf_msmeno.Value = Convert.ToString(ds.Tables[0].Rows[0]["MSMENO"]);
                        txt_NameofOrganization.Text = Convert.ToString(ds.Tables[0].Rows[0]["Organizationname"]);
                        txt_TelephoneNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["Telephonenumber"]);
                        txt_Fax.Text = Convert.ToString(ds.Tables[0].Rows[0]["fax"]);
                        txt_Website.Text = Convert.ToString(ds.Tables[0].Rows[0]["website"]);
                        txt_Yearofestablishment.Text = Convert.ToString(ds.Tables[0].Rows[0]["yearofest"]);
                        txt_NumbertofEmployeesTotal.Text = Convert.ToString(ds.Tables[0].Rows[0]["noofemptot"]);
                        txt_NumberofemployeesTelangana.Text = Convert.ToString(ds.Tables[0].Rows[0]["noofempintelangana"]);
                        txt_ScientificWorkforceMasters.Text = Convert.ToString(ds.Tables[0].Rows[0]["scirntificworkforce"]);
                        txt_HeadQuarterAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["headquarteraddress"]);
                        txt_HeadQuarterAddressPinCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["headquarterpincode"]);
                        txt_plantAddress1.Text = Convert.ToString(ds.Tables[0].Rows[0]["plantaddress1"]);
                        txt_Address1PinCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["plantaddress1pincode"]);
                        txt_PlantAddress2.Text = Convert.ToString(ds.Tables[0].Rows[0]["plantaddress2"]);
                        txt_PlantAddress2pincode.Text = Convert.ToString(ds.Tables[0].Rows[0]["plantaddress2pincode"]);
                        txt_plantaddress3.Text = Convert.ToString(ds.Tables[0].Rows[0]["plantaddress3"]);
                        txt_Address3PinCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["plantaddress3pincode"]);
                        txt_AdditionalAddresses.Text = Convert.ToString(ds.Tables[0].Rows[0]["additionaladdresses"]);
                        txt_slcdname1.Text = Convert.ToString(ds.Tables[0].Rows[0]["senleadercontactnname1"]);
                        txt_slcdDesignation1.Text = Convert.ToString(ds.Tables[0].Rows[0]["senleadercontactndesignation1"]);
                        txt_slcdmobileno1.Text = Convert.ToString(ds.Tables[0].Rows[0]["senleadercontactmobileno1"]);
                        txt_slcdEmailID1.Text = Convert.ToString(ds.Tables[0].Rows[0]["senleadercontactemailid1"]);
                        txt_slcdname2.Text = Convert.ToString(ds.Tables[0].Rows[0]["senleadercontactnname2"]);
                        txt_slcdDesignation2.Text = Convert.ToString(ds.Tables[0].Rows[0]["senleadercontactndesignation2"]);
                        txt_slcdmobileno2.Text = Convert.ToString(ds.Tables[0].Rows[0]["senleadercontactmobileno2"]);
                        txt_slcdEmailID2.Text = Convert.ToString(ds.Tables[0].Rows[0]["senleadercontactemailid2"]);
                        txt_slcdname3.Text = Convert.ToString(ds.Tables[0].Rows[0]["senleadercontactnname3"]);
                        txt_slcdDesignation3.Text = Convert.ToString(ds.Tables[0].Rows[0]["senleadercontactndesignation3"]);
                        txt_slcdmobileno3.Text = Convert.ToString(ds.Tables[0].Rows[0]["senleadercontactmobileno3"]);
                        txt_slcdEmailID3.Text = Convert.ToString(ds.Tables[0].Rows[0]["senleadercontactemailid3"]);
                        txt_cpname.Text = Convert.ToString(ds.Tables[0].Rows[0]["Contactpersonname"]);
                        txt_cpdesignation.Text = Convert.ToString(ds.Tables[0].Rows[0]["Contactpersondesignation"]);
                        txt_CpMobileNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["Contactpersonmobileo"]);
                        txt_cpEmailID.Text = Convert.ToString(ds.Tables[0].Rows[0]["Contactpersonemailid"]);
                        txt_odFY202021INRinCr.Text = Convert.ToString(ds.Tables[0].Rows[0]["finicalyear1turnoverincr"]);
                        txt_odFY201920INRinCr.Text = Convert.ToString(ds.Tables[0].Rows[0]["finicalyear2turnoverincr"]);
                        txt_odFY201819INRinCr.Text = Convert.ToString(ds.Tables[0].Rows[0]["finicalyear3turnoverincr"]);
                        div_WhetherregisteredMSMEother.Visible = false;
                        ddl_odWhetherregisteredasMSME.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["IsregisteredinmsmeID"]);
                        if (ddl_odWhetherregisteredasMSME.SelectedValue == "Y")
                        {
                            div_WhetherregisteredMSMEother.Visible = true;
                            txt_odUdyogAadharNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["udyogaadharnumber"]);
                        }
                        div_LegalStatusofOrganizationother.Visible = false;
                        ddl_LegalStatusofOrganization.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["legalstatusoforgid"]);
                        if (ddl_LegalStatusofOrganization.SelectedItem.Text.ToLower().Contains("other"))
                        {
                            div_LegalStatusofOrganizationother.Visible = true;
                            txt_LegalStatusofOrganizationother.Text = Convert.ToString(ds.Tables[0].Rows[0]["legalstatusoforgname"]);
                        }
                        div_fsOrganizationTypeothers.Visible = false;
                        ddl_fsOrganizationType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["fsorganizationtypeid"]);
                        if (ddl_fsOrganizationType.SelectedItem.Text.ToLower().Contains("other"))
                        {
                            div_fsOrganizationTypeothers.Visible = true;
                            txt_fsOrganizationTypeothers.Text = Convert.ToString(ds.Tables[0].Rows[0]["fsorganizationtypename"]);
                        }
                        div_FocusSectorsothers.Visible = false;
                        ddl_FocusSectors.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["fsfocussectorid"]);
                        if (ddl_FocusSectors.SelectedItem.Text.ToLower().Contains("other"))
                        {
                            div_FocusSectorsothers.Visible = true;
                            txt_FocusSectorsothers.Text = Convert.ToString(ds.Tables[0].Rows[0]["fsfocussectorname"]);
                        }

                        txt_DefsubSectorapprofocussector.Text = Convert.ToString(ds.Tables[0].Rows[0]["fssubsectordefine"]);
                        txt_rdFocusTherapeuticAreas.Text = Convert.ToString(ds.Tables[0].Rows[0]["rdfocustherapeuticareas"]);
                        txt_rdcontracrresearchorgservices.Text = Convert.ToString(ds.Tables[0].Rows[0]["rdcroservices"]);
                        txt_rdcontracrresearchorgcapabilites.Text = Convert.ToString(ds.Tables[0].Rows[0]["rdocrocapabilities"]);
                        txt_mscmAreasofFocus.Text = Convert.ToString(ds.Tables[0].Rows[0]["manfservicmareaoffocus"]);
                        txt_mscmCapacity.Text = Convert.ToString(ds.Tables[0].Rows[0]["manfservicmcapacity"]);
                        txt_mscmAccreditationsCertificationsfdamhra.Text = Convert.ToString(ds.Tables[0].Rows[0]["manfservicaccreditationscertificationfdamhra"]);
                        txt_mscmExportValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["manfservexportvalueincr"]);
                        txt_exportvalueintonnes.Text = Convert.ToString(ds.Tables[0].Rows[0]["manfservexportvalueintonnes"]);
                        txt_cmoservices.Text = Convert.ToString(ds.Tables[0].Rows[0]["manfservcmoservices"]);
                        ddl_cmocorecapabilities.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["manfservcmocorecapabilitiesID"]);
                        div_cmocorecapabilitiesothers.Visible = false;
                        if (ddl_cmocorecapabilities.SelectedItem.Text.ToLower().Contains("other"))
                        {
                            div_cmocorecapabilitiesothers.Visible = true;
                            txt_cmocorecapabilitiesothers.Text = Convert.ToString(ds.Tables[0].Rows[0]["manfservcmocorecapabilitiesname"]);
                        }

                        txt_cmoInfrastructureHighlights.Text = Convert.ToString(ds.Tables[0].Rows[0]["manfservcmoinfrastructurehighlighrs"]);
                        txt_cmoAccreditationsCertifications.Text = Convert.ToString(ds.Tables[0].Rows[0]["manfservcmoaccreditationscertifications"]);
                        txt_cmonoofinternationalClients.Text = Convert.ToString(ds.Tables[0].Rows[0]["manfservcmonoofinternationalclient"]);
                        hf_ancillaryinndustires.Value = Convert.ToString(ds.Tables[0].Rows[0]["listofancillaryexcelfilepath"]);
                        hyp_ancillaryinndustires.NavigateUrl = Convert.ToString(ds.Tables[0].Rows[0]["listofancillaryexcelfilepath"]);
                        hyp_ancillaryinndustires.Visible = true;
                        txt_gpcountrynames.Text = Convert.ToString(ds.Tables[0].Rows[0]["Glopresencecountrynames"]);
                        txt_gpnoofemployees.Text = Convert.ToString(ds.Tables[0].Rows[0]["Glopresencenoofempoutsideindia"]);
                        txt_ctruniqueofferingpast5years.Text = Convert.ToString(ds.Tables[0].Rows[0]["Comtrackrecordofferachievements"]);
                        div_ctrInterestedinGlobalPartnershipothers.Visible = false;
                        ddl_ctrInterestedinGlobalPartnership.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Comtrackrecordglobalparthershipid"]);
                        if (ddl_ctrInterestedinGlobalPartnership.SelectedItem.Text.ToLower().Contains("other"))
                        {
                            div_ctrInterestedinGlobalPartnershipothers.Visible = true;
                            txt_ctrInterestedinGlobalPartnershipothers.Text = Convert.ToString(ds.Tables[0].Rows[0]["Comtrackrecordglobalparthershipname"]);
                        }
                        txt_ctrdescription.Text = Convert.ToString(ds.Tables[0].Rows[0]["Comtrackrecorddescription"]);
                        hf_OrganizationLogopath.Value = Convert.ToString(ds.Tables[0].Rows[0]["organizationlogopath"]);
                        hyp_OrganizationLogo.NavigateUrl = Convert.ToString(ds.Tables[0].Rows[0]["organizationlogopath"]);
                        hyp_OrganizationLogo.Visible = true;
                        txt_ctrAnyPolicySuggestionStateGovernment.Text = Convert.ToString(ds.Tables[0].Rows[0]["Comtrackrecordpolicysuggstategovt"]);
                        chk_fordeclaration.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["isdeclared"]);

                    }
                    catch (Exception ex)
                    {
                        lblmsg0.Text = ex.Message;
                        Failure.Visible = true;
                    }
                }


            }
        }
    }

    #endregion

    #region dropdownvadliations

    protected void ddl_odWhetherregisteredasMSME_SelectedIndexChanged(object sender, EventArgs e)
    {
        //div_WhetherregisteredMSMEother
        //txt_odUdyogAadharNumber
        div_WhetherregisteredMSMEother.Visible = false;
        if (ddl_odWhetherregisteredasMSME.SelectedValue == "Y")
        {
            div_WhetherregisteredMSMEother.Visible = true;
        }
    }
    protected void ddl_LegalStatusofOrganization_SelectedIndexChanged(object sender, EventArgs e)
    {
        //div_LegalStatusofOrganizationother
        //txt_LegalStatusofOrganizationother
        div_LegalStatusofOrganizationother.Visible = false;
        if (ddl_LegalStatusofOrganization.SelectedItem.Text.ToLower().Contains("other"))
        {
            div_LegalStatusofOrganizationother.Visible = true;
        }
    }
    protected void ddl_fsOrganizationType_SelectedIndexChanged(object sender, EventArgs e)
    {
        //div_fsOrganizationTypeothers
        //txt_fsOrganizationTypeothers
        div_fsOrganizationTypeothers.Visible = false;
        if (ddl_fsOrganizationType.SelectedItem.Text.ToLower().Contains("other"))
        {
            div_fsOrganizationTypeothers.Visible = true;
        }
    }
    protected void ddl_FocusSectors_SelectedIndexChanged(object sender, EventArgs e)
    {
        //div_FocusSectorsothers
        //txt_FocusSectorsothers
        div_FocusSectorsothers.Visible = false;
        if (ddl_FocusSectors.SelectedItem.Text.ToLower().Contains("other"))
        {
            div_FocusSectorsothers.Visible = true;
        }
    }
    protected void ddl_cmocorecapabilities_SelectedIndexChanged(object sender, EventArgs e)
    {
        //div_cmocorecapabilitiesothers
        //txt_cmocorecapabilitiesothers
        div_cmocorecapabilitiesothers.Visible = false;
        if (ddl_cmocorecapabilities.SelectedItem.Text.ToLower().Contains("other"))
        {
            div_cmocorecapabilitiesothers.Visible = true;
        }
    }
    protected void ddl_ctrInterestedinGlobalPartnership_SelectedIndexChanged(object sender, EventArgs e)
    {
        //txt_ctrInterestedinGlobalPartnershipothers
        //div_ctrInterestedinGlobalPartnershipothers
        div_ctrInterestedinGlobalPartnershipothers.Visible = false;
        if (ddl_ctrInterestedinGlobalPartnership.SelectedItem.Text.ToLower().Contains("other"))
        {
            div_ctrInterestedinGlobalPartnershipothers.Visible = true;
        }
    }

    #endregion

    #region fileupload



    protected void btn_uploadancillaryinndustires_Click(object sender, EventArgs e)
    {
        hyp_ancillaryinndustires.Visible = false;
        //file_ancillaryinndustires
        //hyp_ancillaryinndustires
        //hf_ancillaryinndustires
        if (file_ancillaryinndustires.HasFile)
        {
            string extension = System.IO.Path.GetExtension(file_ancillaryinndustires.FileName).ToLower();

            if (extension.ToLower() == ".xls" || extension.ToLower() == ".xlsx")
            {
                if (file_ancillaryinndustires.FileContent.Length <= 10000000)
                {
                    try
                    {
                        //string subfoldername = Convert.ToString(Session["uid"]);
                        //string filename = file_ancillaryinndustires.FileName;
                        string subfoldername = Convert.ToString(hf_msmeno.Value);
                        string filename = "";
                        filename = "ancillaryIndustries" + extension;
                        if (!Directory.Exists(Server.MapPath(@"~\Attachments\MSMEPerformaDLS\" + subfoldername)))
                        {
                            Directory.CreateDirectory(Server.MapPath(@"~\Attachments\MSMEPerformaDLS\" + subfoldername));
                        }
                        filename = filename.Trim();
                        filename = filename.Replace(' ', '_');
                        filename = filename.Replace('/', '_');
                        String filepath = Server.MapPath(@"~\Attachments\MSMEPerformaDLS\" + subfoldername + @"\" + filename);
                        file_ancillaryinndustires.SaveAs(filepath);
                        string Uploaddetails = @"~\Attachments\MSMEPerformaDLS\" + subfoldername + @"\" + filename;
                        hf_ancillaryinndustires.Value = Uploaddetails;
                        hyp_ancillaryinndustires.NavigateUrl = Uploaddetails;
                        hyp_ancillaryinndustires.Visible = true;
                        if (string.IsNullOrEmpty(hf_ancillaryinndustires.Value))
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Upload Failed')", true);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Upload Successfully')", true);
                        }
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Upload Failed')", true);
                    }
                }
                else
                {
                    //lbl_msg.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Maximum Size Exceeded 10KB')", true);
                }
            }
            else
            {
                //lbl_msg.ForeColor = System.Drawing.Color.Red;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('File Format not Supported')", true);
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error : Please choose file again')", true);
        }
    }

    protected void btn_uplogorglogo_Click(object sender, EventArgs e)
    {
        //fpdOrganizationLogo
        //hyp_OrganizationLogo
        //hf_OrganizationLogopath
        if (fpdOrganizationLogo.HasFile)
        {
            string extension = System.IO.Path.GetExtension(fpdOrganizationLogo.FileName).ToLower();

            if (extension.ToLower() == ".png" || extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg")
            {
                if (fpdOrganizationLogo.FileContent.Length <= 10000000)
                {
                    try
                    {
                        //string subfoldername = Convert.ToString(Session["uid"]);
                        //string filename = fpdOrganizationLogo.FileName;
                        string subfoldername = Convert.ToString(hf_msmeno.Value);
                        string filename = "";
                        filename = "organizationlogo" + extension;
                        if (!Directory.Exists(Server.MapPath(@"~\Attachments\MSMEPerformaDLS\" + subfoldername)))
                        {
                            Directory.CreateDirectory(Server.MapPath(@"~\Attachments\MSMEPerformaDLS\" + subfoldername));
                        }
                        filename = filename.Trim();
                        filename = filename.Replace(' ', '_');
                        filename = filename.Replace('/', '_');
                        String filepath = Server.MapPath(@"~\Attachments\MSMEPerformaDLS\" + subfoldername + @"\" + filename);
                        fpdOrganizationLogo.SaveAs(filepath);
                        string Uploaddetails = @"~\Attachments\MSMEPerformaDLS\" + subfoldername + @"\" + filename;
                        hf_OrganizationLogopath.Value = Uploaddetails;
                        hyp_OrganizationLogo.NavigateUrl = Uploaddetails;
                        hyp_OrganizationLogo.Visible = true;
                        if (string.IsNullOrEmpty(hf_OrganizationLogopath.Value))
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Upload Failed')", true);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Upload Successfully')", true);
                        }
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Upload Failed')", true);
                    }
                }
                else
                {
                    //lbl_msg.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Maximum Size Exceeded 10KB')", true);
                }
            }
            else
            {
                //lbl_msg.ForeColor = System.Drawing.Color.Red;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('File Format not Supported')", true);
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error : Please choose file again')", true);
        }


    }


    #endregion

    #region Submit
    protected void chk_fordeclaration_CheckedChanged(object sender, EventArgs e)
    {
        btnsubmit.Visible = false;
        if (chk_fordeclaration.Checked == true)
        {
            btnsubmit.Visible = true;
        }
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string errormsg = ValidateControls();
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        else
        {
            string result = "";
            msmeproformalifesciencesproperties obj_msmeproformaproDetails = new msmeproformalifesciencesproperties();
            try
            {
                obj_msmeproformaproDetails.PDLSID = 0;
                if (!string.IsNullOrEmpty(hf_PDLSID.Value))
                {
                    obj_msmeproformaproDetails.PDLSID = Convert.ToInt32(hf_PDLSID.Value);
                }

                obj_msmeproformaproDetails.MSMENO = Convert.ToInt32(hf_msmeno.Value);
                obj_msmeproformaproDetails.Createdby = Convert.ToString(Session["uid"]);
                obj_msmeproformaproDetails.CreatedIP = Request.ServerVariables["Remote_Addr"];
                obj_msmeproformaproDetails.Organizationname = Convert.ToString(txt_NameofOrganization.Text);
                obj_msmeproformaproDetails.Telephonenumber = Convert.ToString(txt_TelephoneNumber.Text);
                obj_msmeproformaproDetails.fax = Convert.ToString(txt_Fax.Text);
                obj_msmeproformaproDetails.website = Convert.ToString(txt_Website.Text);
                obj_msmeproformaproDetails.yearofest = Convert.ToInt32(txt_Yearofestablishment.Text);
                obj_msmeproformaproDetails.noofemptot = Convert.ToInt32(txt_NumbertofEmployeesTotal.Text);
                obj_msmeproformaproDetails.noofempintelangana = Convert.ToInt32(txt_NumberofemployeesTelangana.Text);
                obj_msmeproformaproDetails.scirntificworkforce = Convert.ToString(txt_ScientificWorkforceMasters.Text);
                obj_msmeproformaproDetails.headquarteraddress = Convert.ToString(txt_HeadQuarterAddress.Text);
                obj_msmeproformaproDetails.headquarterpincode = Convert.ToString(txt_HeadQuarterAddressPinCode.Text);
                obj_msmeproformaproDetails.plantaddress1 = Convert.ToString(txt_plantAddress1.Text);
                obj_msmeproformaproDetails.plantaddress1pincode = Convert.ToString(txt_Address1PinCode.Text);
                obj_msmeproformaproDetails.plantaddress2 = Convert.ToString(txt_PlantAddress2.Text);
                obj_msmeproformaproDetails.plantaddress2pincode = Convert.ToString(txt_PlantAddress2pincode.Text);
                obj_msmeproformaproDetails.plantaddress3 = Convert.ToString(txt_plantaddress3.Text);
                obj_msmeproformaproDetails.plantaddress3pincode = Convert.ToString(txt_Address3PinCode.Text);
                obj_msmeproformaproDetails.additionaladdresses = Convert.ToString(txt_AdditionalAddresses.Text);
                obj_msmeproformaproDetails.senleadercontactnname1 = Convert.ToString(txt_slcdname1.Text);
                obj_msmeproformaproDetails.senleadercontactndesignation1 = Convert.ToString(txt_slcdDesignation1.Text);
                obj_msmeproformaproDetails.senleadercontactmobileno1 = Convert.ToString(txt_slcdmobileno1.Text);
                obj_msmeproformaproDetails.senleadercontactemailid1 = Convert.ToString(txt_slcdEmailID1.Text);
                obj_msmeproformaproDetails.senleadercontactnname2 = Convert.ToString(txt_slcdname2.Text);
                obj_msmeproformaproDetails.senleadercontactndesignation2 = Convert.ToString(txt_slcdDesignation2.Text);
                obj_msmeproformaproDetails.senleadercontactmobileno2 = Convert.ToString(txt_slcdmobileno2.Text);
                obj_msmeproformaproDetails.senleadercontactemailid2 = Convert.ToString(txt_slcdEmailID2.Text);
                obj_msmeproformaproDetails.senleadercontactnname3 = Convert.ToString(txt_slcdname3.Text);
                obj_msmeproformaproDetails.senleadercontactndesignation3 = Convert.ToString(txt_slcdDesignation3.Text);
                obj_msmeproformaproDetails.senleadercontactmobileno3 = Convert.ToString(txt_slcdmobileno3.Text);
                obj_msmeproformaproDetails.senleadercontactemailid3 = Convert.ToString(txt_slcdEmailID3.Text);
                obj_msmeproformaproDetails.Contactpersonname = Convert.ToString(txt_cpname.Text);
                obj_msmeproformaproDetails.Contactpersondesignation = Convert.ToString(txt_cpdesignation.Text);
                obj_msmeproformaproDetails.Contactpersonmobileo = Convert.ToString(txt_CpMobileNumber.Text);
                obj_msmeproformaproDetails.Contactpersonemailid = Convert.ToString(txt_cpEmailID.Text);
                obj_msmeproformaproDetails.finicalyear1turnoverincr = Convert.ToDecimal(txt_odFY202021INRinCr.Text);
                obj_msmeproformaproDetails.finicalyear2turnoverincr = Convert.ToDecimal(txt_odFY201920INRinCr.Text);
                obj_msmeproformaproDetails.finicalyear3turnoverincr = Convert.ToDecimal(txt_odFY201819INRinCr.Text);
                obj_msmeproformaproDetails.IsregisteredinmsmeID = Convert.ToString(ddl_odWhetherregisteredasMSME.SelectedValue);
                obj_msmeproformaproDetails.Isregisteredinmsmename = Convert.ToString(ddl_odWhetherregisteredasMSME.SelectedItem.Text);
                if (ddl_odWhetherregisteredasMSME.SelectedValue == "Y")
                {
                    obj_msmeproformaproDetails.udyogaadharnumber = Convert.ToString(txt_odUdyogAadharNumber.Text);
                }

                obj_msmeproformaproDetails.legalstatusoforgid = Convert.ToInt32(ddl_LegalStatusofOrganization.SelectedValue);
                obj_msmeproformaproDetails.legalstatusoforgname = Convert.ToString(ddl_LegalStatusofOrganization.SelectedItem.Text);//txt_LegalStatusofOrganizationother
                if (ddl_LegalStatusofOrganization.SelectedItem.Text.ToLower().Contains("other"))
                {
                    obj_msmeproformaproDetails.legalstatusoforgname = Convert.ToString(txt_LegalStatusofOrganizationother.Text);
                }
                obj_msmeproformaproDetails.fsorganizationtypeid = Convert.ToInt32(ddl_fsOrganizationType.SelectedValue);
                obj_msmeproformaproDetails.fsorganizationtypename = Convert.ToString(ddl_fsOrganizationType.SelectedItem.Text);//txt_fsOrganizationTypeothers
                if (ddl_fsOrganizationType.SelectedItem.Text.ToLower().Contains("other"))
                {
                    obj_msmeproformaproDetails.fsorganizationtypename = Convert.ToString(txt_fsOrganizationTypeothers.Text);
                }

                obj_msmeproformaproDetails.fsfocussectorid = Convert.ToInt32(ddl_FocusSectors.SelectedValue);
                obj_msmeproformaproDetails.fsfocussectorname = Convert.ToString(ddl_FocusSectors.SelectedItem.Text);//txt_FocusSectorsothers

                if (ddl_FocusSectors.SelectedItem.Text.ToLower().Contains("other"))
                {
                    obj_msmeproformaproDetails.fsfocussectorname = Convert.ToString(txt_FocusSectorsothers.Text);
                }

                obj_msmeproformaproDetails.fssubsectordefine = Convert.ToString(txt_DefsubSectorapprofocussector.Text);
                obj_msmeproformaproDetails.rdfocustherapeuticareas = Convert.ToString(txt_rdFocusTherapeuticAreas.Text);
                obj_msmeproformaproDetails.rdcroservices = Convert.ToString(txt_rdcontracrresearchorgservices.Text);
                obj_msmeproformaproDetails.rdocrocapabilities = Convert.ToString(txt_rdcontracrresearchorgcapabilites.Text);
                obj_msmeproformaproDetails.manfservicmareaoffocus = Convert.ToString(txt_mscmAreasofFocus.Text);
                obj_msmeproformaproDetails.manfservicmcapacity = Convert.ToString(txt_mscmCapacity.Text);
                obj_msmeproformaproDetails.manfservicaccreditationscertificationfdamhra = Convert.ToString(txt_mscmAccreditationsCertificationsfdamhra.Text);
                obj_msmeproformaproDetails.manfservexportvalueincr = Convert.ToDecimal(txt_mscmExportValue.Text);
                obj_msmeproformaproDetails.manfservexportvalueintonnes = Convert.ToDecimal(txt_exportvalueintonnes.Text);
                obj_msmeproformaproDetails.manfservcmoservices = Convert.ToString(txt_cmoservices.Text);
                obj_msmeproformaproDetails.manfservcmocorecapabilitiesID = Convert.ToInt32(ddl_cmocorecapabilities.SelectedValue);
                obj_msmeproformaproDetails.manfservcmocorecapabilitiesname = Convert.ToString(ddl_cmocorecapabilities.SelectedItem.Text);//txt_cmocorecapabilitiesothers
                if (ddl_cmocorecapabilities.SelectedItem.Text.ToLower().Contains("other"))
                {
                    obj_msmeproformaproDetails.manfservcmocorecapabilitiesname = Convert.ToString(txt_cmocorecapabilitiesothers.Text);
                }

                obj_msmeproformaproDetails.manfservcmoinfrastructurehighlighrs = Convert.ToString(txt_cmoInfrastructureHighlights.Text);
                obj_msmeproformaproDetails.manfservcmoaccreditationscertifications = Convert.ToString(txt_cmoAccreditationsCertifications.Text);
                obj_msmeproformaproDetails.manfservcmonoofinternationalclient = Convert.ToInt32(txt_cmonoofinternationalClients.Text);
                obj_msmeproformaproDetails.listofancillaryexcelfilepath = Convert.ToString(hf_ancillaryinndustires.Value);
                obj_msmeproformaproDetails.Glopresencecountrynames = Convert.ToString(txt_gpcountrynames.Text);
                obj_msmeproformaproDetails.Glopresencenoofempoutsideindia = Convert.ToInt32(txt_gpnoofemployees.Text);
                obj_msmeproformaproDetails.Comtrackrecordofferachievements = Convert.ToString(txt_ctruniqueofferingpast5years.Text);
                obj_msmeproformaproDetails.Comtrackrecordglobalparthershipid = Convert.ToInt32(ddl_ctrInterestedinGlobalPartnership.SelectedValue);
                obj_msmeproformaproDetails.Comtrackrecordglobalparthershipname = Convert.ToString(ddl_ctrInterestedinGlobalPartnership.SelectedItem.Text);//txt_ctrInterestedinGlobalPartnershipothers
                if (ddl_ctrInterestedinGlobalPartnership.SelectedItem.Text.ToLower().Contains("other"))
                {
                    obj_msmeproformaproDetails.Comtrackrecordglobalparthershipname = Convert.ToString(txt_ctrInterestedinGlobalPartnershipothers.Text);
                }
                obj_msmeproformaproDetails.Comtrackrecorddescription = Convert.ToString(txt_ctrdescription.Text);
                obj_msmeproformaproDetails.organizationlogopath = Convert.ToString(hf_OrganizationLogopath.Value);
                obj_msmeproformaproDetails.Comtrackrecordpolicysuggstategovt = Convert.ToString(txt_ctrAnyPolicySuggestionStateGovernment.Text);
                obj_msmeproformaproDetails.isdeclared = false;
                if (chk_fordeclaration.Checked == true)
                {
                    obj_msmeproformaproDetails.isdeclared = true;
                }
                result = obj_insert.insertupdatemsmeproformaofdirectorlifesciences(obj_msmeproformaproDetails);
                if (result.ToUpper().ToString() != "" || result.ToUpper().ToString() != "0")
                {
                    hf_PDLSID.Value = result;
                    lblmsg.Text = "Submitted Successfully";
                    success.Visible = true;
                    string message = "alert('Application Submitted Successfully')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    BindPDLSLegalStatusOfOrgMaster();
                    BindPDLSOrganizationtypeMaster();
                    BindPDLSFocusSectorMaster();
                    BindPDLSCoreCapabilitiesmaster();
                    BindPDLSGlobalPartnershipMaster();
                    FillDetails();
                }
                else
                {
                    lblmsg.Text = "Submitted Failed";
                    Failure.Visible = true;
                    string message = "alert('Application Submitted Failed')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }


    }

    #endregion

    #region validate
    public static bool valid_isnumeric(string Numericvalue)
    {
        bool Isnumeric = true;
        int Value;
        if (!int.TryParse(Convert.ToString(Numericvalue), out Value))
        {
            Isnumeric = false;
        }
        else
        {
            //if (Value <= 0)
            //{
            //    Isnumeric = false;
            //}
        }
        return Isnumeric;
    }
    public static bool valid_isdecimal(string Numericvalue)
    {
        bool Isdecimal = true;
        decimal Value;
        if (!decimal.TryParse(Convert.ToString(Numericvalue), out Value))
        {
            Isdecimal = false;
        }
        else
        {
            if (Value <= 0)
            {
                Isdecimal = false;
            }
        }
        return Isdecimal;
    }
    public static bool valid_isdouble(string Numericvalue)
    {
        bool Isdouble = true;
        double Value;
        if (!double.TryParse(Convert.ToString(Numericvalue), out Value))
        {
            Isdouble = false;
        }
        else
        {
            if (Value <= 0)
            {
                Isdouble = false;
            }
        }
        return Isdouble;
    }
    public static bool valid_isemail(string Email)
    {
        bool Isnumeric = true;
        if (!Regex.IsMatch(Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
        {
            Isnumeric = false;
        }
        return Isnumeric;
    }
    public static bool valid_ismobile(string MobileNo)
    {
        bool Isnumeric = true;
        if (!Regex.IsMatch(MobileNo, @"^\d{10}$"))
        {
            Isnumeric = false;
        }
        return Isnumeric;
    }
    public string ValidateControls()
    {
        int slno = 1;
        string ErrorMsg = "";

        if (hf_msmeno.Value == "" || hf_msmeno.Value == null || hf_msmeno.Value == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter MSME NO \\n";
            slno = slno + 1;
        }
        else
        {
            if (valid_isnumeric(Convert.ToString(hf_msmeno.Value)) == false)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric MSME NO \\n";
                slno = slno + 1;
            }
        }
        if (Convert.ToString(Session["uid"]) == "" || Convert.ToString(Session["uid"]) == null || Convert.ToString(Session["uid"]) == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter userid\\n";
            slno = slno + 1;
        }
        if (txt_NameofOrganization.Text == "" || txt_NameofOrganization.Text == null || txt_NameofOrganization.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Name of Organization\\n";
            slno = slno + 1;
        }
        if (txt_TelephoneNumber.Text == "" || txt_TelephoneNumber.Text == null || txt_TelephoneNumber.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Telephone Number\\n";
            slno = slno + 1;
        }
        else
        {
            if (valid_isnumeric(Convert.ToString(txt_TelephoneNumber.Text)) == false)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Telephone Number \\n";
                slno = slno + 1;
            }
        }
        if (txt_Fax.Text == "" || txt_Fax.Text == null || txt_Fax.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Fax \\n";
            slno = slno + 1;
        }
        if (txt_Website.Text == "" || txt_Website.Text == null || txt_Website.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Website \\n";
            slno = slno + 1;
        }
        if (txt_Yearofestablishment.Text == "" || txt_Yearofestablishment.Text == null || txt_Yearofestablishment.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Year of establishment\\n";
            slno = slno + 1;
        }
        else
        {
            if (valid_isnumeric(Convert.ToString(txt_Yearofestablishment.Text)) == false)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Year of establishment\\n";
                slno = slno + 1;
            }
        }
        if (txt_NumbertofEmployeesTotal.Text == "" || txt_NumbertofEmployeesTotal.Text == null || txt_NumbertofEmployeesTotal.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Number of Employees(Total)\\n";
            slno = slno + 1;
        }
        else
        {
            if (valid_isnumeric(Convert.ToString(txt_NumbertofEmployeesTotal.Text)) == false)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Number of Employees(Total)\\n";
                slno = slno + 1;
            }
        }

        if (txt_NumberofemployeesTelangana.Text == "" || txt_NumberofemployeesTelangana.Text == null || txt_NumberofemployeesTelangana.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Number of employees (Telangana)\\n";
            slno = slno + 1;
        }
        else
        {
            if (valid_isnumeric(Convert.ToString(txt_NumberofemployeesTelangana.Text)) == false)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter NumericNumber of employees (Telangana)\\n";
                slno = slno + 1;
            }
        }
        if (txt_ScientificWorkforceMasters.Text == "" || txt_ScientificWorkforceMasters.Text == null || txt_ScientificWorkforceMasters.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Scientific Workforce(Masters and above)\\n";
            slno = slno + 1;
        }
        if (txt_HeadQuarterAddress.Text == "" || txt_HeadQuarterAddress.Text == null || txt_HeadQuarterAddress.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Head Quarter Address\\n";
            slno = slno + 1;
        }
        if (txt_HeadQuarterAddressPinCode.Text == "" || txt_HeadQuarterAddressPinCode.Text == null || txt_HeadQuarterAddressPinCode.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Head Quarter Address Pin Code\\n";
            slno = slno + 1;
        }

        if (txt_plantAddress1.Text == "" || txt_plantAddress1.Text == null || txt_plantAddress1.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Plant Address 1\\n";
            slno = slno + 1;
        }
        if (txt_Address1PinCode.Text == "" || txt_Address1PinCode.Text == null || txt_Address1PinCode.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Plant Address 1 PinCode\\n";
            slno = slno + 1;
        }
        if (txt_PlantAddress2.Text == "" || txt_PlantAddress2.Text == null || txt_PlantAddress2.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Plant Address 2\\n";
            slno = slno + 1;
        }
        if (txt_PlantAddress2pincode.Text == "" || txt_PlantAddress2pincode.Text == null || txt_PlantAddress2pincode.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Plant Address 2 Pincode\\n";
            slno = slno + 1;
        }
        if (txt_plantaddress3.Text == "" || txt_plantaddress3.Text == null || txt_plantaddress3.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Plant Address 3\\n";
            slno = slno + 1;
        }
        if (txt_Address3PinCode.Text == "" || txt_Address3PinCode.Text == null || txt_Address3PinCode.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Plant Address 3 PinCode\\n";
            slno = slno + 1;
        }
        if (txt_AdditionalAddresses.Text == "" || txt_AdditionalAddresses.Text == null || txt_AdditionalAddresses.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Plant Additional Address(es)\\n";
            slno = slno + 1;
        }
        if (txt_slcdname1.Text == "" || txt_slcdname1.Text == null || txt_slcdname1.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Senior Leadership and Contact Details Name 1\\n";
            slno = slno + 1;
        }
        if (txt_slcdDesignation1.Text == "" || txt_slcdDesignation1.Text == null || txt_slcdDesignation1.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Senior Leadership and Contact Details Designation (1)\\n";
            slno = slno + 1;
        }
        if (txt_slcdmobileno1.Text == "" || txt_slcdmobileno1.Text == null || txt_slcdmobileno1.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Senior Leadership and Contact Details Mobile No(1)\\n";
            slno = slno + 1;
        }
        else
        {
            if (valid_ismobile(Convert.ToString(txt_slcdmobileno1.Text)) == false)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Correct Senior Leadership and Contact Details Mobile No(1)\\n";
                slno = slno + 1;
            }
        }
        if (txt_slcdEmailID1.Text == "" || txt_slcdEmailID1.Text == null || txt_slcdEmailID1.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Senior Leadership and Contact Details Email ID (1)\\n";
            slno = slno + 1;
        }
        else
        {
            if (valid_isemail(Convert.ToString(txt_slcdEmailID1.Text)) == false)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Correct Senior Leadership and Contact Details Email ID (1) \\n";
                slno = slno + 1;
            }
        }
        if (txt_slcdname2.Text == "" || txt_slcdname2.Text == null || txt_slcdname2.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Senior Leadership and Contact Details Name 2\\n";
            slno = slno + 1;
        }
        if (txt_slcdDesignation2.Text == "" || txt_slcdDesignation2.Text == null || txt_slcdDesignation2.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Senior Leadership and Contact Details Designation (2)\\n";
            slno = slno + 1;
        }
        if (txt_slcdmobileno2.Text == "" || txt_slcdmobileno2.Text == null || txt_slcdmobileno2.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Senior Leadership and Contact Details Mobile No(2)\\n";
            slno = slno + 1;
        }
        else
        {
            if (valid_ismobile(Convert.ToString(txt_slcdmobileno2.Text)) == false)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Correct Senior Leadership and Contact Details Mobile No(2)\\n";
                slno = slno + 1;
            }
        }
        if (txt_slcdEmailID2.Text == "" || txt_slcdEmailID2.Text == null || txt_slcdEmailID2.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Senior Leadership and Contact Details Email ID (2)\\n";
            slno = slno + 1;
        }
        else
        {
            if (valid_isemail(Convert.ToString(txt_slcdEmailID2.Text)) == false)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Correct Senior Leadership and Contact Details Email ID (2) \\n";
                slno = slno + 1;
            }
        }
        if (txt_slcdname3.Text == "" || txt_slcdname3.Text == null || txt_slcdname3.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Senior Leadership and Contact Details Name 3\\n";
            slno = slno + 1;
        }
        if (txt_slcdDesignation3.Text == "" || txt_slcdDesignation3.Text == null || txt_slcdDesignation3.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Senior Leadership and Contact Details Designation (3)\\n";
            slno = slno + 1;
        }
        if (txt_slcdmobileno3.Text == "" || txt_slcdmobileno3.Text == null || txt_slcdmobileno3.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Senior Leadership and Contact Details Mobile No(3)\\n";
            slno = slno + 1;
        }
        else
        {
            if (valid_ismobile(Convert.ToString(txt_slcdmobileno3.Text)) == false)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Correct Senior Leadership and Contact Details Mobile No(3)\\n";
                slno = slno + 1;
            }
        }
        if (txt_slcdEmailID3.Text == "" || txt_slcdEmailID3.Text == null || txt_slcdEmailID3.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Senior Leadership and Contact Details Email ID (3)\\n";
            slno = slno + 1;
        }
        else
        {
            if (valid_isemail(Convert.ToString(txt_slcdEmailID3.Text)) == false)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Correct Senior Leadership and Contact Details Email ID (3) \\n";
                slno = slno + 1;
            }
        }
        if (txt_cpname.Text == "" || txt_cpname.Text == null || txt_cpname.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Contact Person Name\\n";
            slno = slno + 1;
        }
        if (txt_cpdesignation.Text == "" || txt_cpdesignation.Text == null || txt_cpdesignation.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter  Contact Person Designation\\n";
            slno = slno + 1;
        }
        if (txt_CpMobileNumber.Text == "" || txt_CpMobileNumber.Text == null || txt_CpMobileNumber.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Contact Person Mobile No\\n";
            slno = slno + 1;
        }
        else
        {
            if (valid_ismobile(Convert.ToString(txt_CpMobileNumber.Text)) == false)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Correct Contact Person MobileNo\\n";
                slno = slno + 1;
            }
        }
        if (txt_cpEmailID.Text == "" || txt_cpEmailID.Text == null || txt_cpEmailID.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Contact Person Email ID\\n";
            slno = slno + 1;
        }
        else
        {
            if (valid_isemail(Convert.ToString(txt_cpEmailID.Text)) == false)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Correct Contact Person Email ID\\n";
                slno = slno + 1;
            }
        }
        if (txt_odFY202021INRinCr.Text == "" || txt_odFY202021INRinCr.Text == null || txt_odFY202021INRinCr.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter FY 2020-21 (INR in Cr)\\n";
            slno = slno + 1;
        }
        else
        {
            if (valid_isdecimal(Convert.ToString(txt_odFY202021INRinCr.Text)) == false)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter FY 2020-21 (INR in Cr)\\n";
                slno = slno + 1;
            }
        }
        if (txt_odFY201920INRinCr.Text == "" || txt_odFY201920INRinCr.Text == null || txt_odFY201920INRinCr.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter  FY 2019-20 (INR in Cr)\\n";
            slno = slno + 1;
        }
        else
        {
            if (valid_isdecimal(Convert.ToString(txt_odFY201920INRinCr.Text)) == false)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric  FY 2019-20 (INR in Cr)\\n";
                slno = slno + 1;
            }
        }

        if (txt_odFY201819INRinCr.Text == "" || txt_odFY201819INRinCr.Text == null || txt_odFY201819INRinCr.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter FY 2018-19 (INR in Cr)\\n";
            slno = slno + 1;
        }
        else
        {
            if (valid_isdecimal(Convert.ToString(txt_odFY201819INRinCr.Text)) == false)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric FY 2018-19 (INR in Cr)\\n";
                slno = slno + 1;
            }
        }
        if (ddl_odWhetherregisteredasMSME.SelectedIndex <= 0 || ddl_odWhetherregisteredasMSME.SelectedValue == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Whether registered as MSME\\n";
            slno = slno + 1;
        }
        else
        {
            if (ddl_odWhetherregisteredasMSME.SelectedValue == "Y")
            {
                if (txt_odUdyogAadharNumber.Text == "" || txt_odUdyogAadharNumber.Text == null || txt_odUdyogAadharNumber.Text == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter if yes,Provide Udyog Aadhar Number\\n";
                    slno = slno + 1;
                }
            }
        }
        if (ddl_LegalStatusofOrganization.SelectedIndex <= 0 || ddl_LegalStatusofOrganization.SelectedValue == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Legal Status of Organization\\n";
            slno = slno + 1;
        }
        else
        {
            if (ddl_LegalStatusofOrganization.SelectedItem.Text.ToLower().Contains("other"))
            {
                if (txt_LegalStatusofOrganizationother.Text == "" || txt_LegalStatusofOrganizationother.Text == null || txt_LegalStatusofOrganizationother.Text == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Legal Status of Organization others\\n";
                    slno = slno + 1;
                }
            }
        }
        if (ddl_fsOrganizationType.SelectedIndex <= 0 || ddl_fsOrganizationType.SelectedValue == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Organization Type \\n";
            slno = slno + 1;
        }
        else
        {
            if (ddl_fsOrganizationType.SelectedItem.Text.ToLower().Contains("other"))
            {
                if (txt_fsOrganizationTypeothers.Text == "" || txt_fsOrganizationTypeothers.Text == null || txt_fsOrganizationTypeothers.Text == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Organization Type others\\n";
                    slno = slno + 1;
                }
            }
        }
        if (ddl_FocusSectors.SelectedIndex <= 0 || ddl_FocusSectors.SelectedValue == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter  Focus Sectors\\n";
            slno = slno + 1;
        }
        else
        {
            if (ddl_FocusSectors.SelectedItem.Text.ToLower().Contains("other"))
            {
                if (txt_FocusSectorsothers.Text == "" || txt_FocusSectorsothers.Text == null || txt_FocusSectorsothers.Text == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Focus Sectors others\\n";
                    slno = slno + 1;
                }
            }
        }
        if (txt_DefsubSectorapprofocussector.Text == "" || txt_DefsubSectorapprofocussector.Text == null || txt_DefsubSectorapprofocussector.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Define the sub-Sector that appropriately defines your focus sector\\n";
            slno = slno + 1;
        }
        if (txt_rdFocusTherapeuticAreas.Text == "" || txt_rdFocusTherapeuticAreas.Text == null || txt_rdFocusTherapeuticAreas.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Focus Therapeutic Areas(Like Orals,Nasals,MABs,etc.)\\n";
            slno = slno + 1;
        }
        if (txt_rdcontracrresearchorgservices.Text == "" || txt_rdcontracrresearchorgservices.Text == null || txt_rdcontracrresearchorgservices.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Contract Research Organization Services\\n";
            slno = slno + 1;
        }
        if (txt_rdcontracrresearchorgcapabilites.Text == "" || txt_rdcontracrresearchorgcapabilites.Text == null || txt_rdcontracrresearchorgcapabilites.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Contract Research Organization Capabilities\\n";
            slno = slno + 1;
        }
        if (txt_mscmAreasofFocus.Text == "" || txt_mscmAreasofFocus.Text == null || txt_mscmAreasofFocus.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Areas of Focus\\n";
            slno = slno + 1;
        }
        if (txt_mscmCapacity.Text == "" || txt_mscmCapacity.Text == null || txt_mscmCapacity.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Capacity\\n";
            slno = slno + 1;
        }
        if (txt_mscmAccreditationsCertificationsfdamhra.Text == "" || txt_mscmAccreditationsCertificationsfdamhra.Text == null || txt_mscmAccreditationsCertificationsfdamhra.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Accreditations/Certifications(FDA,MHRA,etc.)\\n";
            slno = slno + 1;
        }
        if (txt_mscmExportValue.Text == "" || txt_mscmExportValue.Text == null || txt_mscmExportValue.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Export Value (INR Cr)\\n";
            slno = slno + 1;
        }
        else
        {
            if (valid_isdecimal(Convert.ToString(txt_mscmExportValue.Text)) == false)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Export Value (INR Cr)\\n";
                slno = slno + 1;
            }
        }
        if (txt_exportvalueintonnes.Text == "" || txt_exportvalueintonnes.Text == null || txt_exportvalueintonnes.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Export Value (in Tonnes)\\n";
            slno = slno + 1;
        }
        else
        {
            if (valid_isdecimal(Convert.ToString(txt_exportvalueintonnes.Text)) == false)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Export Value (in Tonnes)\\n";
                slno = slno + 1;
            }
        }
        if (txt_cmoservices.Text == "" || txt_cmoservices.Text == null || txt_cmoservices.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Contract Manufacturing Organizations Services\\n";
            slno = slno + 1;
        }
        if (ddl_cmocorecapabilities.SelectedIndex <= 0 || ddl_cmocorecapabilities.SelectedValue == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Core Capabilities\\n";
            slno = slno + 1;
        }
        else
        {
            if (ddl_cmocorecapabilities.SelectedItem.Text.ToLower().Contains("other"))
            {
                if (txt_cmocorecapabilitiesothers.Text == "" || txt_cmocorecapabilitiesothers.Text == null || txt_cmocorecapabilitiesothers.Text == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Core Capabilities Others\\n";
                    slno = slno + 1;
                }
            }
        }
        if (txt_cmoInfrastructureHighlights.Text == "" || txt_cmoInfrastructureHighlights.Text == null || txt_cmoInfrastructureHighlights.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Infrastructure Highlights\\n";
            slno = slno + 1;
        }
        if (txt_cmoAccreditationsCertifications.Text == "" || txt_cmoAccreditationsCertifications.Text == null || txt_cmoAccreditationsCertifications.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Accreditations/Certifications\\n";
            slno = slno + 1;
        }
        if (txt_cmonoofinternationalClients.Text == "" || txt_cmonoofinternationalClients.Text == null || txt_cmonoofinternationalClients.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Number of international Clients\\n";
            slno = slno + 1;
        }
        else
        {
            if (valid_isnumeric(Convert.ToString(txt_cmonoofinternationalClients.Text)) == false)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Number of international Clients\\n";
                slno = slno + 1;
            }
        }
        if (hf_ancillaryinndustires.Value == "" || hf_ancillaryinndustires.Value == null || hf_ancillaryinndustires.Value == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Upload  List of ancillary Industries in excel only \\n";
            slno = slno + 1;
        }
        if (txt_gpcountrynames.Text == "" || txt_gpcountrynames.Text == null || txt_gpcountrynames.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Country Names(Specify all Country names)\\n";
            slno = slno + 1;
        }
        if (txt_gpnoofemployees.Text == "" || txt_gpnoofemployees.Text == null || txt_gpnoofemployees.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter No of Employees(Outside India)\\n";
            slno = slno + 1;
        }
        else
        {
            if (valid_isnumeric(Convert.ToString(txt_gpnoofemployees.Text)) == false)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric No of Employees(Outside India)\\n";
                slno = slno + 1;
            }
        }
        if (txt_ctruniqueofferingpast5years.Text == "" || txt_ctruniqueofferingpast5years.Text == null || txt_ctruniqueofferingpast5years.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Unique Offering/Recent Achievements during past 5 Years\\n";
            slno = slno + 1;
        }
        if (ddl_ctrInterestedinGlobalPartnership.SelectedIndex <= 0 || ddl_ctrInterestedinGlobalPartnership.SelectedValue == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Interested in Global Partnership\\n";
            slno = slno + 1;
        }
        else
        {
            if (ddl_ctrInterestedinGlobalPartnership.SelectedItem.Text.ToLower().Contains("other"))
            {
                if (txt_ctrInterestedinGlobalPartnershipothers.Text == "" || txt_ctrInterestedinGlobalPartnershipothers.Text == null || txt_ctrInterestedinGlobalPartnershipothers.Text == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Interested in Global Partnership Others\\n";
                    slno = slno + 1;
                }
            }
        }
        if (txt_ctrdescription.Text == "" || txt_ctrdescription.Text == null || txt_ctrdescription.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Description\\n";
            slno = slno + 1;
        }
        if (hf_OrganizationLogopath.Value == "" || hf_OrganizationLogopath.Value == null || hf_OrganizationLogopath.Value == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Upload Organization Logo\\n";
            slno = slno + 1;
        }
        if (txt_ctrAnyPolicySuggestionStateGovernment.Text == "" || txt_ctrAnyPolicySuggestionStateGovernment.Text == null || txt_ctrAnyPolicySuggestionStateGovernment.Text == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Any Policy Suggestion to the State Government\\n";
            slno = slno + 1;
        }
        if (chk_fordeclaration.Checked == false)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Confirm\\n";
            slno = slno + 1;
        }

        return ErrorMsg;
    }


    #endregion
}