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
public partial class UI_TSiPASS_frmCinematographLicense : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    General Gen = new General();
    Cls_Multiplex objmultiplex = new Cls_Multiplex();
    List<Screendetails> lstscreendetails = new List<Screendetails>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }

        if (!IsPostBack)
        {
            BindCommissionerates();
            BindDistricts();
            BindOwnerDistricts();
            BindExperienceYears();
            FillDetails();
        }
        
        
    }
    public void BindDistricts()
    {
        //DataSet dsTypes = new DataSet();
        //dsTypes = Gen.GetDistricts();
        Cls_MasterofTsipass obj_newdistrictwargnal = new Cls_MasterofTsipass();
        DataSet dsTypes = new DataSet();
        dsTypes = obj_newdistrictwargnal.GetallDistrictswithoutWarangal(Convert.ToString(Session["uid"]), "CINEMA");
        if (dsTypes.Tables[0].Rows.Count > 0)
        {
            ddldist_applicant.DataSource = dsTypes.Tables[0];
            ddldist_applicant.DataTextField = "District_Name";
            ddldist_applicant.DataValueField = "District_Id";
            ddldist_applicant.DataBind();

            ddldist_applicant.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }
    public void BindOwnerDistricts()
    {
        //DataSet dsTypes = new DataSet();
        //dsTypes = Gen.GetDistricts();
        Cls_MasterofTsipass obj_newdistrictwargnal = new Cls_MasterofTsipass();
        DataSet dsTypes = new DataSet();
        dsTypes = obj_newdistrictwargnal.GetallDistrictswithoutWarangal(Convert.ToString(Session["uid"]), "CINEMA");
        if (dsTypes.Tables[0].Rows.Count > 0)
        {
            ddldistrict_owner.DataSource = dsTypes.Tables[0];
            ddldistrict_owner.DataTextField = "District_Name";
            ddldistrict_owner.DataValueField = "District_Id";
            ddldistrict_owner.DataBind();

            ddldistrict_owner.Items.Insert(0, new ListItem("--Select--", "0"));

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
   public void FillDetails()
    {
        int CreatedBy = Convert.ToInt32(Session["uid"]);
        DataSet ds = new DataSet();
       
            ds = objmultiplex.RetriveCinematographicDetails(CreatedBy,"");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string App_Status = Convert.ToString(ds.Tables[0].Rows[0]["App_Status"]);
                    if (App_Status == "2")
                    {
                        btnPayment.Visible = true;
                        trUploads.Visible = true;
                        Session["Applid"] = Convert.ToString(ds.Tables[0].Rows[0]["cinemalicenseid"]);
                        hdnTransactionNumber.Value = Convert.ToString(ds.Tables[0].Rows[0]["cinemalicenseid"]);

                        //hdnidentityid.Value = Convert.ToString(ds.Tables[0].Rows[0]["cinemalicenseid"]);

                    txtapplicantfllname.Text= Convert.ToString(ds.Tables[0].Rows[0]["ApplicantName"]);

                    ddldist_applicant.SelectedValue= Convert.ToString(ds.Tables[0].Rows[0]["ApplicantDistrict"]);
                    ddldist_applicant_SelectedIndexChanged(this, EventArgs.Empty);

                    ddlmandal_applicant.SelectedValue= Convert.ToString(ds.Tables[0].Rows[0]["ApplicantMandal"]);
                    ddlmandal_applicant_SelectedIndexChanged(this, EventArgs.Empty);

                    ddlvillage_applicant.SelectedValue= Convert.ToString(ds.Tables[0].Rows[0]["ApplicantVillage"]);

                    txtpincode_applicant.Text= Convert.ToString(ds.Tables[0].Rows[0]["ApplicantPlotNo"]);
                    txtplotnumber_applicant.Text= Convert.ToString(ds.Tables[0].Rows[0]["ApplicantPINCODE"]);
                    
                    txtownername.Text = Convert.ToString(ds.Tables[0].Rows[0]["OwnerName"]);

                    ddldistrict_owner.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["OwnerDistrict"]);
                    ddldistrict_owner_SelectedIndexChanged(this, EventArgs.Empty);

                    ddlmandal_owner.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["OwnerMandal"]);
                    ddlmandal_owner_SelectedIndexChanged(this, EventArgs.Empty);

                    ddlvillage_owner.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["OwnerVillage"]);

                    txtpincode_owner.Text = Convert.ToString(ds.Tables[0].Rows[0]["OwnerPlotNo"]);
                    txtplotno_owner.Text = Convert.ToString(ds.Tables[0].Rows[0]["OwnerPINCODE"]);

                    ddlexpyear.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ExpYear"]);

                        txt9Bfileno.Text = Convert.ToString(ds.Tables[0].Rows[0]["Fileno_9B"]);

                        txtreferancedate.Text = Convert.ToString(ds.Tables[0].Rows[0]["Rererancedate"]);

                        txtlongevitydate.Text = Convert.ToString(ds.Tables[0].Rows[0]["LongevityCertificateDate"]);

                        txtelectricalcertificatevaliddate.Text = Convert.ToString(ds.Tables[0].Rows[0]["ElectricalCertificateDate"]);

                        txtfirenocvaliddate.Text = Convert.ToString(ds.Tables[0].Rows[0]["NocDate"]);

                        ddlnoofshows.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Noofshows"]);

                        ddlcommissionerate.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Commissionerate"]);
                        ddlcommissionerate_SelectedIndexChanged(this, EventArgs.Empty);
                        ddlzone.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Zone"]);
                        ddlzone_SelectedIndexChanged(this, EventArgs.Empty);
                        ddldivision.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Division"]);
                        ddldivision_SelectedIndexChanged(this, EventArgs.Empty);
                        ddlpolicestation.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Policestation"]);
                        ddltrafficzone.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["TrafficZone"]);
                        ddltrafficzone_SelectedIndexChanged(this, EventArgs.Empty);
                        ddltrafficdivision.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["TrafficDivision"]);
                        ddltrafficdivision_SelectedIndexChanged(this, EventArgs.Empty);
                        ddltrafficpolicestation.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["TrafficPolicestation"]);
                    
                        ddllicenseperiod.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["LicensePeriod"]);
                        txtnoofscreens.Text = Convert.ToString(ds.Tables[0].Rows[0]["Noofscreens"]);
                        rbttheatretype.SelectedValue = "Y";
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["TheatreType"])))
                        {
                            if (Convert.ToString(ds.Tables[0].Rows[0]["TheatreType"]) == "N")
                            {
                                rbttheatretype.SelectedValue = "N";
                            }

                        }
                        if(ds.Tables[0].Rows[0]["PlaceorBildinLicense"].ToString()=="Y")
                    {
                        rbtlicense.SelectedValue = "Y";
                    }
                        else
                    {
                        rbtlicense.SelectedValue = "N";
                    }
                    if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {
                        FillAttachmentsDetails(ds);
                    }
                }

                    
                }
            }
            

        

    }
    protected void btn8BNOC_Click(object sender, EventArgs e)
    {
        string newPath = "";
        // string sFileDir = @"D:\TS-iPASSFinal\Attachments";
        //  string SubFolder = @"\MULTIPLEX\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        string SubFolder = @"\MULTIPLEX\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        General.FileResult objfileResult = new General.FileResult();

        string[] extensions = { ".pdf", ".jpg", ".jpeg" };
        objfileResult = Gen.SaveFile(fup8BNOC, SubFolder, "8BNOC");

        if (objfileResult.Result == true)
        {
            lbl8BNOC.Text = objfileResult.FileName;
           // hdnSelfCertification.Value = objfileResult.FileType;
           // hdnSelfCertificationFilename.Value = objfileResult.FileName;
            fup8BNOC.Visible = false;
            btn8BNOC.Visible = false;
            BtnSave.Focus();
            int result = 0;
            result = SaveAttachments(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "8BNOC", Session["uid"].ToString());
            if (result > 0)
            {
                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                hyper8BNOC.Visible = true;
                hyper8BNOC.Text = objfileResult.FileName;
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

            hyper8BNOC.NavigateUrl = objfileResult.FilePath;
            lbl8BNOC.Text = objfileResult.Message;
        }
    }

    protected void btn9BNOC_Click(object sender, EventArgs e)
    {
        string newPath = "";
        // string sFileDir = @"D:\TS-iPASSFinal\Attachments";
        //  string SubFolder = @"\MULTIPLEX\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        string SubFolder = @"\MULTIPLEX\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        General.FileResult objfileResult = new General.FileResult();

        string[] extensions = { ".pdf", ".jpg", ".jpeg" };
        objfileResult = Gen.SaveFile(fup9BNOC, SubFolder, "9BNOC");

        if (objfileResult.Result == true)
        {
            lbl9BNOC.Text = objfileResult.FileName;
            // hdnSelfCertification.Value = objfileResult.FileType;
            // hdnSelfCertificationFilename.Value = objfileResult.FileName;
            fup9BNOC.Visible = false;
            btn9BNOC.Visible = false;
            BtnSave.Focus();
            int result = 0;
            result = SaveAttachments(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "9BNOC", Session["uid"].ToString());
            if (result > 0)
            {
                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                hyper9BNOC.Visible = true;
                hyper9BNOC.Text = objfileResult.FileName;
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

            hyper9BNOC.NavigateUrl = objfileResult.FilePath;
            lbl9BNOC.Text = objfileResult.Message;
        }
    }

    protected void btnfireoccupancycertificate_Click(object sender, EventArgs e)
    {
        string newPath = "";
        // string sFileDir = @"D:\TS-iPASSFinal\Attachments";
        //  string SubFolder = @"\MULTIPLEX\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        string SubFolder = @"\MULTIPLEX\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        General.FileResult objfileResult = new General.FileResult();

        string[] extensions = { ".pdf", ".jpg", ".jpeg" };
        objfileResult = Gen.SaveFile(fupfireoccupancycertificate, SubFolder, "fireoccupancycertificate");

        if (objfileResult.Result == true)
        {
            lblfireoccupancycertificate.Text = objfileResult.FileName;
            //hdnSelfCertification.Value = objfileResult.FileType;
            //hdnSelfCertificationFilename.Value = objfileResult.FileName;
            fupfireoccupancycertificate.Visible = false;
            btnfireoccupancycertificate.Visible = false;
            BtnSave.Focus();
            int result = 0;
            result = SaveAttachments(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "fireoccupancycertificate", Session["uid"].ToString());
            if (result > 0)
            {
                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                hyperfireoccupancycertificate.Visible = true;
                hyperfireoccupancycertificate.Text = objfileResult.FileName;
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

            hyperfireoccupancycertificate.NavigateUrl = objfileResult.FilePath;
            lblfireoccupancycertificate.Text = objfileResult.Message;
        }
    }

    protected void btnGHMCoccupancycertificate_Click(object sender, EventArgs e)
    {
        string newPath = "";
        // string sFileDir = @"D:\TS-iPASSFinal\Attachments";
        //  string SubFolder = @"\MULTIPLEX\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        string SubFolder = @"\MULTIPLEX\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        General.FileResult objfileResult = new General.FileResult();

        string[] extensions = { ".pdf", ".jpg", ".jpeg" };
        objfileResult = Gen.SaveFile(fupGHMCoccupancycertificate, SubFolder, "GHMCoccupancycertificate");

        if (objfileResult.Result == true)
        {
            lblGHMCoccupancycertificate.Text = objfileResult.FileName;
            //hdnSelfCertification.Value = objfileResult.FileType;
            //hdnSelfCertificationFilename.Value = objfileResult.FileName;
            fupGHMCoccupancycertificate.Visible = false;
            btnGHMCoccupancycertificate.Visible = false;
            BtnSave.Focus();
            int result = 0;
            result = SaveAttachments(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "GHMCoccupancycertificate", Session["uid"].ToString());
            if (result > 0)
            {
                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                hyperGHMCoccupancycertificate.Visible = true;
                hyperGHMCoccupancycertificate.Text = objfileResult.FileName;
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

            hyperGHMCoccupancycertificate.NavigateUrl = objfileResult.FilePath;
            lblGHMCoccupancycertificate.Text = objfileResult.Message;
        }
    }

    protected void btnTSFTCANDTDCNOC_Click(object sender, EventArgs e)
    {
        string newPath = "";
        // string sFileDir = @"D:\TS-iPASSFinal\Attachments";
        //  string SubFolder = @"\MULTIPLEX\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        string SubFolder = @"\MULTIPLEX\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        General.FileResult objfileResult = new General.FileResult();

        string[] extensions = { ".pdf", ".jpg", ".jpeg" };
        objfileResult = Gen.SaveFile(fupTSFTCANDTDCNOC, SubFolder, "TSFTCANDTDCNOC");

        if (objfileResult.Result == true)
        {
            lblTSFTCANDTDCNOC.Text = objfileResult.FileName;
            // hdnSelfCertification.Value = objfileResult.FileType;
            // hdnSelfCertificationFilename.Value = objfileResult.FileName;
            fupTSFTCANDTDCNOC.Visible = false;
            btnTSFTCANDTDCNOC.Visible = false;
            BtnSave.Focus();
            int result = 0;
            result = SaveAttachments(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "TSFTCANDTDCNOC", Session["uid"].ToString());
            if (result > 0)
            {
                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                hyperTSFTCANDTDCNOC.Visible = true;
                hyperTSFTCANDTDCNOC.Text = objfileResult.FileName;
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

            hyperTSFTCANDTDCNOC.NavigateUrl = objfileResult.FilePath;
            lblTSFTCANDTDCNOC.Text = objfileResult.Message;
        }
    }

    protected void btnfirmchambernoc_Click(object sender, EventArgs e)
    {
        string newPath = "";
        // string sFileDir = @"D:\TS-iPASSFinal\Attachments";
        //  string SubFolder = @"\MULTIPLEX\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        string SubFolder = @"\MULTIPLEX\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        General.FileResult objfileResult = new General.FileResult();

        string[] extensions = { ".pdf", ".jpg", ".jpeg" };
        objfileResult = Gen.SaveFile(fupfirmchambernoc, SubFolder, "firmchambernoc");

        if (objfileResult.Result == true)
        {
            lblfirmchambernoc.Text = objfileResult.FileName;
          //  hdnSelfCertification.Value = objfileResult.FileType;
          //  hdnSelfCertificationFilename.Value = objfileResult.FileName;
            fupfirmchambernoc.Visible = false;
            btnfirmchambernoc.Visible = false;
            BtnSave.Focus();
            int result = 0;
            result = SaveAttachments(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "firmchambernoc", Session["uid"].ToString());
            if (result > 0)
            {
                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                hyperfirmchambernoc.Visible = true;
                hyperfirmchambernoc.Text = objfileResult.FileName;
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

            hyperfirmchambernoc.NavigateUrl = objfileResult.FilePath;
            lblfirmchambernoc.Text = objfileResult.Message;
        }
    }

    protected void btnfirmdivision_Click(object sender, EventArgs e)
    {
        string newPath = "";
        // string sFileDir = @"D:\TS-iPASSFinal\Attachments";
        //  string SubFolder = @"\MULTIPLEX\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        string SubFolder = @"\MULTIPLEX\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        General.FileResult objfileResult = new General.FileResult();

        string[] extensions = { ".pdf", ".jpg", ".jpeg" };
        objfileResult = Gen.SaveFile(fupfirmdivision, SubFolder, "firmdivision");

        if (objfileResult.Result == true)
        {
            lblfirmdivision.Text = objfileResult.FileName;
            //hdnSelfCertification.Value = objfileResult.FileType;
            //hdnSelfCertificationFilename.Value = objfileResult.FileName;
            fupfirmdivision.Visible = false;
            btnfirmdivision.Visible = false;
            BtnSave.Focus();
            int result = 0;
            result = SaveAttachments(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "firmdivision", Session["uid"].ToString());
            if (result > 0)
            {
                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                hyperfirmdivision.Visible = true;
                hyperfirmdivision.Text = objfileResult.FileName;
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

            hyperfirmdivision.NavigateUrl = objfileResult.FilePath;
            lblfirmdivision.Text = objfileResult.Message;
        }
    }

    protected void btnleaseagreement_Click(object sender, EventArgs e)
    {
        string newPath = "";
        // string sFileDir = @"D:\TS-iPASSFinal\Attachments";
        //  string SubFolder = @"\MULTIPLEX\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        string SubFolder = @"\MULTIPLEX\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        General.FileResult objfileResult = new General.FileResult();

        string[] extensions = { ".pdf", ".jpg", ".jpeg" };
        objfileResult = Gen.SaveFile(fupleaseagreement, SubFolder, "leaseagreement");

        if (objfileResult.Result == true)
        {
            lblleaseagreement.Text = objfileResult.FileName;
          //  hdnSelfCertification.Value = objfileResult.FileType;
            //hdnSelfCertificationFilename.Value = objfileResult.FileName;
            fupleaseagreement.Visible = false;
            btnleaseagreement.Visible = false;
            BtnSave.Focus();
            int result = 0;
            result = SaveAttachments(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "leaseagreement", Session["uid"].ToString());
            if (result > 0)
            {
                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                hyperleaseagreement.Visible = true;
                hyperleaseagreement.Text = objfileResult.FileName;
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

            hyperleaseagreement.NavigateUrl = objfileResult.FilePath;
            lblleaseagreement.Text = objfileResult.Message;
        }
    }

    protected void btnblueprint_Click(object sender, EventArgs e)
    {
        string newPath = "";
        // string sFileDir = @"D:\TS-iPASSFinal\Attachments";
        //  string SubFolder = @"\MULTIPLEX\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        string SubFolder = @"\MULTIPLEX\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        General.FileResult objfileResult = new General.FileResult();

        string[] extensions = { ".pdf", ".jpg", ".jpeg" };
        objfileResult = Gen.SaveFile(fupblueprint, SubFolder, "blueprint");

        if (objfileResult.Result == true)
        {
            lblblueprint.Text = objfileResult.FileName;
            //hdnSelfCertification.Value = objfileResult.FileType;
            //hdnSelfCertificationFilename.Value = objfileResult.FileName;
            fupblueprint.Visible = false;
            btnblueprint.Visible = false;
            BtnSave.Focus();
            int result = 0;
            result = SaveAttachments(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "blueprint", Session["uid"].ToString());
            if (result > 0)
            {
                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                hyperblueprint.Visible = true;
                hyperblueprint.Text = objfileResult.FileName;
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

            hyperblueprint.NavigateUrl = objfileResult.FilePath;
            lblblueprint.Text = objfileResult.Message;
        }
    }

    protected void btnseatingdetails_Click(object sender, EventArgs e)
    {
        string newPath = "";
        // string sFileDir = @"D:\TS-iPASSFinal\Attachments";
        //  string SubFolder = @"\MULTIPLEX\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        string SubFolder = @"\MULTIPLEX\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        General.FileResult objfileResult = new General.FileResult();

        string[] extensions = { ".pdf", ".jpg", ".jpeg" };
        objfileResult = Gen.SaveFile(fupseatingdetails, SubFolder, "seatingdetails");

        if (objfileResult.Result == true)
        {
            lblseatingdetails.Text = objfileResult.FileName;
            //hdnSelfCertification.Value = objfileResult.FileType;
            //hdnSelfCertificationFilename.Value = objfileResult.FileName;
            fupseatingdetails.Visible = false;
            btnseatingdetails.Visible = false;
            BtnSave.Focus();
            int result = 0;
            result = SaveAttachments(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "seatingdetails", Session["uid"].ToString());
            if (result > 0)
            {
                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                hyperseatingdetails.Visible = true;
                hyperseatingdetails.Text = objfileResult.FileName;
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

            hyperseatingdetails.NavigateUrl = objfileResult.FilePath;
            lblseatingdetails.Text = objfileResult.Message;
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

    public string ValidateControls()
    {
        int slno = 1;
        string ErrorMsg = "";

        if (ddlexpyear.SelectedValue == "0" || ddlexpyear.SelectedValue == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please select Experience Years \\n";
            slno = slno + 1;
        }
        if (txt9Bfileno.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter 9B file no \\n";
            slno = slno + 1;
        }

        if (txtreferancedate.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please select Date of the Reference in which permission for construction of the building granted \\n";
            slno = slno + 1;
        }
        if (txtlongevitydate.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please select The Date upto which the certificate of longevity of the building issued by the executive engineer (R&B) is valid \\n";
            slno = slno + 1;
        }

        if (txtelectricalcertificatevaliddate.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please select The date upto which the Electrical certificate in form -D is Valid \\n";
            slno = slno + 1;
        }

        if (txtfirenocvaliddate.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please select The date upto which the NOC of Fire Department is Valid \\n";
            slno = slno + 1;
        }
        if (ddlnoofshows.SelectedValue == "0" || ddlnoofshows.SelectedValue == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select no of shows proposed to be screened  \\n";
            slno = slno + 1;
        }

        //if (lbl8BNOC.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please upload 8B NOC. \\n";
        //    slno = slno + 1;
        //}

        //if (lbl9BNOC.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please upload 9B NOC. \\n";
        //    slno = slno + 1;
        //}

        //if (lblfireoccupancycertificate.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please upload fireoccupancy certificate. \\n";
        //    slno = slno + 1;
        //}

        //if (lblGHMCoccupancycertificate.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please upload GHMC occupancy certificate. \\n";
        //    slno = slno + 1;
        //}

        //if (lblTSFTCANDTDCNOC.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please upload >NOC of TSFTV & TDC. \\n";
        //    slno = slno + 1;
        //}

        //if (lblfirmchambernoc.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please upload NOC of Film Chamber of Commerce. \\n";
        //    slno = slno + 1;
        //}

        ////if (lblfirmdivision.Text == "")
        ////{
        ////    ErrorMsg = ErrorMsg + slno + ". Please upload verification certificate. \\n";
        ////    slno = slno + 1;
        ////}

        ////if (lblleaseagreement.Text == "")
        ////{
        ////    ErrorMsg = ErrorMsg + slno + ". Please upload indemnity bond. \\n";
        ////    slno = slno + 1;
        ////}

        //if (lblblueprint.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please upload Blue print of Cinema Theatre/Multiplex with Screens and seating Capacity. \\n";
        //    slno = slno + 1;
        //}

        //if (lblseatingdetails.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please upload Details with regard to Screens, seating and Ticket Rates proposed. \\n";
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
            for (int j = 0; j < grd_dynamic.Rows.Count; j++)
            {

                TextBox txt_seatcapcity = grd_dynamic.Rows[j].FindControl("txt_seatcapcity") as TextBox;
                TextBox txt_screenfee = grd_dynamic.Rows[j].FindControl("txt_screenfee") as TextBox;
                TextBox txt_totscreenfee = grd_dynamic.Rows[j].FindControl("txt_totscreenfee") as TextBox;
                try
                {
                    Screendetails fromvo = new Screendetails();
                    fromvo.ScreenNO = "Screen_" + j + 1;
                    fromvo.SeatCapacity = txt_seatcapcity.Text;
                    fromvo.ScreenFee = txt_screenfee.Text;
                    fromvo.TotalFee = txt_totscreenfee.Text;
                    fromvo.Created_By = Session["uid"].ToString();
                    lstscreendetails.Add(fromvo);
                }
                catch (Exception ex)
                {

                }
            }
            try
            {

                Response objResp = new Response();
                int cinemalicenseid = 0;
                objResp = objmultiplex.InsertCinematographicLicenseDetails( ddlexpyear.SelectedValue, txt9Bfileno.Text,
                    txtreferancedate.Text, txtlongevitydate.Text, txtelectricalcertificatevaliddate.Text, txtfirenocvaliddate.Text, ddllicenseperiod.SelectedValue,
                    rbttheatretype.SelectedValue, txtnoofscreens.Text, ddlnoofshows.SelectedValue, out cinemalicenseid, Session["uid"].ToString(), txtapplicantfllname.Text, ddldist_applicant.SelectedValue, ddlmandal_applicant.SelectedValue, ddlvillage_applicant.SelectedValue, txtplotnumber_applicant.Text,
                txtpincode_applicant.Text, rbtlicense.SelectedValue, txtownername.Text, ddldistrict_owner.SelectedValue,
                ddlmandal_owner.SelectedValue, ddlvillage_owner.SelectedValue, txtplotno_owner.Text, txtpincode_owner.Text, ddlcommissionerate.SelectedValue,
            ddlzone.SelectedValue, ddldivision.SelectedValue, ddlpolicestation.SelectedValue, ddltrafficzone.SelectedValue,
           ddltrafficdivision.SelectedValue, ddltrafficpolicestation.SelectedValue, txtapprovalfeecinemalicense.Text.Trim());

                Session["Applid"] = cinemalicenseid;
                if (objResp.ResponseVal == true)
                {
                    hdnTransactionNumber.Value = cinemalicenseid.ToString();
                    InsertScreenDetails(hdnTransactionNumber.Value, lstscreendetails);
                    Response.Write("Submitted Successfully.....");
                    // BtnSave.Enabled = false;
                    BtnClear.Enabled = false;
                    btnPayment.Enabled = true;
                    btnPayment.Visible = true;
                    trUploads.Visible = true;



                }
            }
            catch (Exception ex)
            {
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }
    }

    void FillAttachmentsDetails(DataSet ds)
    {

        if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
        {
            int c = ds.Tables[1].Rows.Count;
            string sen, sen1, sen2;
            int i = 0;

            while (i < c)
            {
                sen2 = ds.Tables[1].Rows[i][0].ToString();
                sen1 = sen2.Replace(@"\", @"/");

               
                if (sen1.ToUpper().Contains("8BNOC")) 
                {
                   
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen1.ToUpper().Contains("8BNOC"))
                    {
                        hyper8BNOC.Visible = true;
                        hyper8BNOC.Text = ds.Tables[1].Rows[i][1].ToString();
                        hyper8BNOC.NavigateUrl = sen;
                        lbl8BNOC.Text = ds.Tables[1].Rows[i][1].ToString();
                    }
                }
                else if (sen1.ToUpper().Contains("9BNOC")) 
                {

                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen1.ToUpper().Contains("9BNOC"))
                    {
                        hyper9BNOC.Visible = true;
                        hyper9BNOC.Text = ds.Tables[1].Rows[i][1].ToString();
                        hyper9BNOC.NavigateUrl = sen;
                        lbl9BNOC.Text = ds.Tables[1].Rows[i][1].ToString();
                    }
                }
                if (sen1.ToUpper().Contains("FIREOCC")) //SelfCertification
                {
                   
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen1.ToUpper().Contains("FIREOCC"))
                    {
                        hyperfireoccupancycertificate.Visible = true;
                        hyperfireoccupancycertificate.Text = ds.Tables[1].Rows[i][1].ToString();
                        hyperfireoccupancycertificate.NavigateUrl = sen;
                        lblfireoccupancycertificate.Text = ds.Tables[1].Rows[i][1].ToString();
                    }
                }
                if (sen1.ToUpper().Contains("GHMC"))
                {

                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen1.ToUpper().Contains("GHMC"))
                    {
                        hyperGHMCoccupancycertificate.Visible = true;
                        hyperGHMCoccupancycertificate.Text = ds.Tables[1].Rows[i][1].ToString();
                        hyperGHMCoccupancycertificate.NavigateUrl = sen;
                        lblGHMCoccupancycertificate.Text = ds.Tables[1].Rows[i][1].ToString();
                    }
                }

                if (sen1.ToUpper().Contains("TSFTCANDTDCNOC")) 
                {

                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen1.ToUpper().Contains("TSFTCANDTDCNOC"))
                    {
                        hyperTSFTCANDTDCNOC.Visible = true;
                        hyperTSFTCANDTDCNOC.Text = ds.Tables[1].Rows[i][1].ToString();
                        hyperTSFTCANDTDCNOC.NavigateUrl = sen;
                        lblTSFTCANDTDCNOC.Text = ds.Tables[1].Rows[i][1].ToString();
                    }
                }

                if (sen1.ToUpper().Contains("FIRMCHAMBER")) 
                {
                    
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen1.ToUpper().Contains("FIRMCHAMBER"))
                    {
                        hyperfirmchambernoc.Visible = true;
                        hyperfirmchambernoc.Text = ds.Tables[1].Rows[i][1].ToString();
                        hyperfirmchambernoc.NavigateUrl = sen;
                        lblfirmchambernoc.Text = ds.Tables[1].Rows[i][1].ToString();

                    }
                }

                if (sen1.ToUpper().Contains("FIRMDIVISION")) 
                {
                    
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen1.ToUpper().Contains("FIRMDIVISION"))
                    {
                        hyperfirmdivision.Visible = true;
                        hyperfirmdivision.Text = ds.Tables[1].Rows[i][1].ToString();
                        hyperfirmdivision.NavigateUrl = sen;
                        lblfirmchambernoc.Text = ds.Tables[1].Rows[i][1].ToString();
                    }
                }
                if (sen1.ToUpper().Contains("LEASE"))
                {
                    // sen = sen1.ToUpper()Replace(sen1.Substring(0, sen1.ToUpper()IndexOf(@"/TOURISMEVENT")), "~/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen1.ToUpper().Contains("LEASE"))
                    {
                        hyperleaseagreement.Visible = true;
                        hyperleaseagreement.Text = ds.Tables[1].Rows[i][1].ToString();
                        hyperleaseagreement.NavigateUrl = sen;
                        lblleaseagreement.Text = ds.Tables[1].Rows[i][1].ToString();
                    }
                }
                if (sen1.ToUpper().Contains("BLUEPRINT"))
                {
                    // sen = sen1.ToUpper()Replace(sen1.Substring(0, sen1.ToUpper()IndexOf(@"/TOURISMEVENT")), "~/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen1.ToUpper().Contains("BLUEPRINT"))
                    {
                        hyperblueprint.Visible = true;
                        hyperblueprint.Text = ds.Tables[1].Rows[i][1].ToString();
                        hyperblueprint.NavigateUrl = sen;
                        lblblueprint.Text = ds.Tables[1].Rows[i][1].ToString();
                    }
                }
                if (sen1.ToUpper().Contains("SEATING"))
                {
                    // sen = sen1.ToUpper()Replace(sen1.Substring(0, sen1.ToUpper()IndexOf(@"/TOURISMEVENT")), "~/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen1.ToUpper().Contains("SEATING"))
                    {
                        hyperseatingdetails.Visible = true;
                        hyperseatingdetails.Text = ds.Tables[1].Rows[i][1].ToString();
                        hyperseatingdetails.NavigateUrl = sen;
                        lblseatingdetails.Text = ds.Tables[1].Rows[i][1].ToString();
                    }
                }
                i++;
            }

        }

    }

    public int SaveAttachments(string intMultiplexid, string FileType, string FilePath, string FileName, string FileDescription, string Created_by)
    {
        int n = 0;
        try
        {

            con.OpenConnection();

            SqlCommand cmdFiles = new SqlCommand("usp_Insert_Multiplex_attachments", con.GetConnection);
            cmdFiles.CommandType = CommandType.StoredProcedure;

            cmdFiles.Parameters.AddWithValue("@Multiplex_ID", Convert.ToInt32(intMultiplexid));
            cmdFiles.Parameters.AddWithValue("@FileType", FileType);
            cmdFiles.Parameters.AddWithValue("@FilePath", FilePath);
            cmdFiles.Parameters.AddWithValue("@FileName", FileName);
            cmdFiles.Parameters.AddWithValue("@FileDescription", FileDescription);
            cmdFiles.Parameters.AddWithValue("@Created_by", Created_by);
            n = cmdFiles.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            con.CloseConnection();
            throw ex;

        }
        finally
        {

            con.CloseConnection();

        }
        return n;
    }

    protected void btnNext0_Click(object sender, EventArgs e)
    {

        //Response.Redirect("frmPowerDetails.aspx?intApplicationId=" + hdfFlagID0.Value);
        //Response.Redirect("frmAdvertisement.aspx?intApplicationId=" + hdfFlagID0.Value + "&Previous=" + "P");
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            string errormsg = ValidateControls();
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            for (int j = 0; j < grd_dynamic.Rows.Count; j++)
            {

                TextBox txt_seatcapcity = grd_dynamic.Rows[j].FindControl("txt_seatcapcity") as TextBox;
                TextBox txt_screenfee = grd_dynamic.Rows[j].FindControl("txt_screenfee") as TextBox;
                TextBox txt_totscreenfee = grd_dynamic.Rows[j].FindControl("txt_totscreenfee") as TextBox;
                try
                {
                    Screendetails fromvo = new Screendetails();
                    fromvo.ScreenNO = "Screen_" + j + 1;
                    fromvo.SeatCapacity = txt_seatcapcity.Text;
                    fromvo.ScreenFee = txt_screenfee.Text;
                    fromvo.TotalFee = txt_totscreenfee.Text;
                    fromvo.Created_By = Session["uid"].ToString();
                    lstscreendetails.Add(fromvo);
                }
                catch (Exception ex)
                {

                }
            }
            Response objResp = new Response();
            int cinemalicenseid = 0;
            objResp = objmultiplex.InsertCinematographicLicenseDetails( ddlexpyear.SelectedValue, txt9Bfileno.Text, txtreferancedate.Text, txtlongevitydate.Text,
                txtelectricalcertificatevaliddate.Text, txtfirenocvaliddate.Text, ddllicenseperiod.SelectedValue,
                rbttheatretype.SelectedValue, txtnoofscreens.Text, ddlnoofshows.SelectedValue, out cinemalicenseid,
                Session["uid"].ToString(), txtapplicantfllname.Text, ddldist_applicant.SelectedValue, ddlmandal_applicant.SelectedValue, ddlvillage_applicant.SelectedValue, txtplotnumber_applicant.Text,
                txtpincode_applicant.Text, rbtlicense.SelectedValue, txtownername.Text, ddldistrict_owner.SelectedValue,
                ddlmandal_owner.SelectedValue, ddlvillage_owner.SelectedValue, txtplotno_owner.Text, txtpincode_owner.Text, ddlcommissionerate.SelectedValue,
            ddlzone.SelectedValue, ddldivision.SelectedValue, ddlpolicestation.SelectedValue, ddltrafficzone.SelectedValue,
           ddltrafficdivision.SelectedValue, ddltrafficpolicestation.SelectedValue, txtapprovalfeecinemalicense.Text.Trim());

            Session["Applid"] = cinemalicenseid;
            if (objResp.ResponseVal == true)
            {
                hdnTransactionNumber.Value = cinemalicenseid.ToString();
                InsertScreenDetails(hdnTransactionNumber.Value, lstscreendetails);
                Response.Write("Submitted Successfully.....");
                // BtnSave.Enabled = false;
                BtnClear.Enabled = false;
                btnPayment.Enabled = true;
                btnPayment.Visible = true;
                trUploads.Visible = true;



            }
            if (hdnTransactionNumber.Value.ToString().Trim() == "" || hdnTransactionNumber.Value.Trim() == "0")
            {
                Response.Redirect("frmCinematographLicense.aspx");
            }
            else
            {
                Response.Redirect("frmPaymentMultiplex.aspx?intApplicationId=" + hdnTransactionNumber.Value);
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }

}

    public void BindScreenDetails()
    {
        DataSet dsdetails = new DataSet();
        dsdetails = GetScreenDetails(Session["ApplidA"].ToString());
        if (dsdetails.Tables[0].Rows.Count > 0)
        {
            int screencount = 0;
            if(!string.IsNullOrEmpty(Convert.ToString(dsdetails.Tables[0].Rows[0]["Noofscreens"])))
                {
                screencount = Convert.ToInt32(dsdetails.Tables[0].Rows[0]["Noofscreens"]);
            }
            if(screencount== 1 )
            {
                rbttheatretype.SelectedValue = "Y";
                txtnoofscreens.Text = Convert.ToString(screencount);
            }
              else
            {
                rbttheatretype.SelectedValue = "N";
                txtnoofscreens.Text = Convert.ToString(screencount);
            }
            ddllicenseperiod.SelectedValue = Convert.ToString(dsdetails.Tables[0].Rows[0]["LicensePeriod"]); 
        }
    }

    public DataSet GetScreenDetails(string quessionniarecfoid)
    {
        DataSet Dsnew = new DataSet();
        SqlParameter[] pp = new SqlParameter[]
        {
             new SqlParameter("@intQuessionaireCFOid",SqlDbType.VarChar)
        };
        pp[0].Value = quessionniarecfoid;
        Dsnew = Gen.GenericFillDs("GetFeeandSceenDetailsbyid",pp);
        return Dsnew;
    }

    public void BindExperienceYears()
    {
        DataSet dsexp = new DataSet();
        dsexp = GetEXpYearscinema();
        if (dsexp.Tables[0].Rows.Count > 0)
        {
            ddlexpyear.DataSource = dsexp.Tables[0];
            ddlexpyear.DataTextField = "noofexpyears";
            ddlexpyear.DataValueField = "expyearsid";
            ddlexpyear.DataBind();

            ddlexpyear.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }

    public DataSet GetEXpYearscinema()
    {
        DataSet Dsnew = new DataSet();

        Dsnew = Gen.GenericFillDs("GetEXpYears_cinema");
        return Dsnew;
    }

    public void BindCommissionerates()
    {
        DataSet dscommission = new DataSet();
        dscommission = GetCommissionerates();
        if (dscommission.Tables[0].Rows.Count > 0)
        {
            ddlcommissionerate.DataSource = dscommission.Tables[0];
            ddlcommissionerate.DataTextField = "Commissionerate_Name";
            ddlcommissionerate.DataValueField = "Commissionerate_Id";
            ddlcommissionerate.DataBind();

            ddlcommissionerate.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }

    public DataSet GetCommissionerates()
    {
        DataSet Dsnew = new DataSet();

        Dsnew = Gen.GenericFillDs("GETCOMMISSIONERATES");
        return Dsnew;
    }

    protected void ddlcommissionerate_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dszone = new DataSet();
        dszone = GetZones(ddlcommissionerate.SelectedValue);
        if (dszone.Tables[0].Rows.Count > 0)
        {
            ddlzone.DataSource = dszone.Tables[0];
            ddlzone.DataTextField = "zone_name";
            ddlzone.DataValueField = "zone_id";
            ddlzone.DataBind();

            ddlzone.Items.Insert(0, new ListItem("--Select--", "0"));

        }
        DataSet dstrafficzone = new DataSet();
        dstrafficzone = GetTrafficZones(ddlcommissionerate.SelectedValue);
        if (dstrafficzone.Tables[0].Rows.Count > 0)
        {
            ddltrafficzone.DataSource = dstrafficzone.Tables[0];
            ddltrafficzone.DataTextField = "Traffic_zone_name";
            ddltrafficzone.DataValueField = "Traffic_zone_id";
            ddltrafficzone.DataBind();

            ddltrafficzone.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }

    public DataSet GetZones(string commissionerateid)
    {
        DataSet Dsnew = new DataSet();
        SqlParameter[] pp = new SqlParameter[]
        {
             new SqlParameter("@COMMISSIONERATEID",SqlDbType.VarChar)
        };
        pp[0].Value = commissionerateid;
        Dsnew = Gen.GenericFillDs("GETZONES",pp);
        return Dsnew;
    }

    public DataSet GetTrafficZones(string commissionerateid)
    {
        DataSet Dsnew = new DataSet();
        SqlParameter[] pp = new SqlParameter[]
        {
             new SqlParameter("@COMMISSIONERATE_ID",SqlDbType.VarChar)
        };
        pp[0].Value = commissionerateid;
        Dsnew = Gen.GenericFillDs("GETTRAFFICZONES",pp);
        return Dsnew;
    }

    protected void ddlzone_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dsdivision = new DataSet();
        dsdivision = GetDivisions(ddlzone.SelectedValue);
        if (dsdivision.Tables[0].Rows.Count > 0)
        {
            ddldivision.DataSource = dsdivision.Tables[0];
            ddldivision.DataTextField = "division_name"; 
            ddldivision.DataValueField = "division_id";
            ddldivision.DataBind();

            ddldivision.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }

    public DataSet GetDivisions(string zoneid)
    {
        DataSet Dsnew = new DataSet();
        SqlParameter[] pp = new SqlParameter[]
        {
             new SqlParameter("@ZONEID",SqlDbType.VarChar)
        };
        pp[0].Value = zoneid;
        Dsnew = Gen.GenericFillDs("GETDIVISIONS",pp);
        return Dsnew;
    }

    protected void ddldivision_SelectedIndexChanged(object sender, EventArgs e)
    {

        DataSet dspolice= new DataSet();
        dspolice = GetPoliceStatioons(ddlcommissionerate.SelectedValue,ddldivision.SelectedValue);
        if (dspolice.Tables[0].Rows.Count > 0)
        {
            ddlpolicestation.DataSource = dspolice.Tables[0];
            ddlpolicestation.DataTextField = "policestation_name";
            ddlpolicestation.DataValueField = "policestation_id";
            ddlpolicestation.DataBind();

            ddlpolicestation.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }

    public DataSet GetPoliceStatioons(string commissionerateid, string divisionid)
    {
        DataSet Dsnew = new DataSet();
        SqlParameter[] pp = new SqlParameter[]
        {
             new SqlParameter("@COMMISSIONERATE_ID",SqlDbType.VarChar),
             new SqlParameter("@DIVISION_ID",SqlDbType.VarChar)
        };
        pp[0].Value = commissionerateid;
        pp[1].Value = divisionid;
        Dsnew = Gen.GenericFillDs("GETPOLICESTATIONS",pp);
        return Dsnew;
    }

    protected void ddltrafficzone_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dstrafficdivision = new DataSet();
        dstrafficdivision = GetTrafficDivisions(ddltrafficzone.SelectedValue);
        if (dstrafficdivision.Tables[0].Rows.Count > 0)
        {
            ddltrafficdivision.DataSource = dstrafficdivision.Tables[0];
            ddltrafficdivision.DataTextField = "Traffic_division_name";
            ddltrafficdivision.DataValueField = "Traffic_division_id";
            ddltrafficdivision.DataBind();

            ddltrafficdivision.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }

    public DataSet GetTrafficDivisions(string trafficzoneid)
    {
        DataSet Dsnew = new DataSet();
        SqlParameter[] pp = new SqlParameter[]
        {
             new SqlParameter("@TRAFFICZONE_ID",SqlDbType.VarChar)
        };
        pp[0].Value = trafficzoneid;
        Dsnew = Gen.GenericFillDs("GETTRAFFICDIVISIONS",pp);
        return Dsnew;
    }

    protected void ddltrafficdivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dspolice = new DataSet();
        dspolice = GetTrafficPoliceStatioons(ddlcommissionerate.SelectedValue, ddltrafficdivision.SelectedValue);
        if (dspolice.Tables[0].Rows.Count > 0)
        {
            ddltrafficpolicestation.DataSource = dspolice.Tables[0];
            ddltrafficpolicestation.DataTextField = "Traffic_policestation_name";
            ddltrafficpolicestation.DataValueField = "Traffic_policestation_id";
            ddltrafficpolicestation.DataBind();

            ddltrafficpolicestation.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }

    public DataSet GetTrafficPoliceStatioons(string commissionerateid, string trafficdivisionid)
    {
        DataSet Dsnew = new DataSet();
        SqlParameter[] pp = new SqlParameter[]
        {
             new SqlParameter("@COMMISSIONERATE_ID",SqlDbType.VarChar),
             new SqlParameter("@TRAFFICDIVISION_ID",SqlDbType.VarChar)
        };
        pp[0].Value = commissionerateid;
        pp[1].Value = trafficdivisionid;
        Dsnew = Gen.GenericFillDs("GETTRAFFICPOLICESTATIONS",pp);
        return Dsnew;
    }

    protected void ddldist_applicant_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddldist_applicant.SelectedIndex == 0)
            {
                ddlmandal_applicant.Items.Clear();
                ddlmandal_applicant.Items.Insert(0, "--Mandal--");
                //   ChkWater_reg_from.Items.Clear();
                // ChkWater_reg_from.Items.Insert(0, new ListItem("New Bore well", "New Bore well"));
                //ChkWater_reg_from.Items.Insert(1, new ListItem("HMWS & SB", "HMWS & SB"));
                //ChkWater_reg_from.Items.Insert(2, new ListItem("Rivers/Canals", "Rivers/Canals"));
            }
            else
            {
                ddlmandal_applicant.Items.Clear();
                DataSet dsm = new DataSet();
                dsm = Gen.GetMandals(ddldist_applicant.SelectedValue);
                if (dsm.Tables[0].Rows.Count > 0)
                {
                    ddlmandal_applicant.DataSource = dsm.Tables[0];
                    ddlmandal_applicant.DataValueField = "Mandal_Id";
                    ddlmandal_applicant.DataTextField = "Manda_lName";
                    ddlmandal_applicant.DataBind();
                    ddlmandal_applicant.Items.Insert(0, "--Mandal--");
                }
                else
                {
                    ddlmandal_applicant.Items.Clear();
                    ddlmandal_applicant.Items.Insert(0, "--Mandal--");
                }



            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void ddlmandal_applicant_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlmandal_applicant.SelectedIndex == 0)
            {

                ddlvillage_applicant.Items.Clear();
                ddlvillage_applicant.Items.Insert(0, "--Village--");
            }
            else
            {
                ddlvillage_applicant.Items.Clear();
                DataSet dsv = new DataSet();
                dsv = Gen.GetVillages(ddlmandal_applicant.SelectedValue);
                if (dsv.Tables[0].Rows.Count > 0)
                {
                    ddlvillage_applicant.DataSource = dsv.Tables[0];
                    ddlvillage_applicant.DataValueField = "Village_Id";
                    ddlvillage_applicant.DataTextField = "Village_Name";
                    ddlvillage_applicant.DataBind();
                    ddlvillage_applicant.Items.Insert(0, "--Village--");
                }
                else
                {
                    ddlvillage_applicant.Items.Clear();
                    ddlvillage_applicant.Items.Insert(0, "--Village--");
                }
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void ddldistrict_owner_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddldistrict_owner.SelectedIndex == 0)
            {
                ddlmandal_owner.Items.Clear();
                ddlmandal_owner.Items.Insert(0, "--Mandal--");
                //   ChkWater_reg_from.Items.Clear();
                // ChkWater_reg_from.Items.Insert(0, new ListItem("New Bore well", "New Bore well"));
                //ChkWater_reg_from.Items.Insert(1, new ListItem("HMWS & SB", "HMWS & SB"));
                //ChkWater_reg_from.Items.Insert(2, new ListItem("Rivers/Canals", "Rivers/Canals"));
            }
            else
            {
                ddlmandal_owner.Items.Clear();
                DataSet dsm = new DataSet();
                dsm = Gen.GetMandals(ddldistrict_owner.SelectedValue);
                if (dsm.Tables[0].Rows.Count > 0)
                {
                    ddlmandal_owner.DataSource = dsm.Tables[0];
                    ddlmandal_owner.DataValueField = "Mandal_Id";
                    ddlmandal_owner.DataTextField = "Manda_lName";
                    ddlmandal_owner.DataBind();
                    ddlmandal_owner.Items.Insert(0, "--Mandal--");
                }
                else
                {
                    ddlmandal_owner.Items.Clear();
                    ddlmandal_owner.Items.Insert(0, "--Mandal--");
                }



            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void ddlmandal_owner_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlmandal_owner.SelectedIndex == 0)
            {

                ddlvillage_owner.Items.Clear();
                ddlvillage_owner.Items.Insert(0, "--Village--");
            }
            else
            {
                ddlvillage_owner.Items.Clear();
                DataSet dsv = new DataSet();
                dsv = Gen.GetVillages(ddlmandal_owner.SelectedValue);
                if (dsv.Tables[0].Rows.Count > 0)
                {
                    ddlvillage_owner.DataSource = dsv.Tables[0];
                    ddlvillage_owner.DataValueField = "Village_Id";
                    ddlvillage_owner.DataTextField = "Village_Name";
                    ddlvillage_owner.DataBind();
                    ddlvillage_owner.Items.Insert(0, "--Village--");
                }
                else
                {
                    ddlvillage_owner.Items.Clear();
                    ddlvillage_owner.Items.Insert(0, "--Village--");
                }
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    public void dynamicgridbind()
    {
        int count = Convert.ToInt32(txtnoofscreens.Text);
        if (count > 0)
        {
            DataTable dtmain = new DataTable();
            dtmain.Columns.Add("number");
            for (int i = 0; i < count; i++)
            {
                DataRow drs = dtmain.NewRow();
                drs["number"] = "Screen-" + (i + 1);
                dtmain.Rows.Add(drs);
            }
            DataSet dsmain = new DataSet();
            dsmain.Tables.Add(dtmain);

            grd_dynamic.DataSource = dsmain;
            grd_dynamic.DataBind();
        }
    }

    protected void txt_seatcapcity_TextChanged(object sender, EventArgs e)
    {
        TextBox lnk_view = (TextBox)sender;
        GridViewRow gvRow = (GridViewRow)lnk_view.Parent.Parent;

        TextBox txt_seatcapcity = (TextBox)gvRow.FindControl("txt_seatcapcity");
        TextBox txt_screenfee = (TextBox)gvRow.FindControl("txt_screenfee");
        TextBox txt_totscreenfee = (TextBox)gvRow.FindControl("txt_totscreenfee");
        if (ddllicenseperiod.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please select License Period..!');", true);
        }
        else
        {
            if (!string.IsNullOrEmpty(txt_seatcapcity.Text))
            {
                int Capcity = Convert.ToInt32(txt_seatcapcity.Text);
                decimal fee;
                if (Capcity <= 500)
                {
                    fee = 500;
                    decimal screenfee = fee * Convert.ToDecimal(ddllicenseperiod.SelectedValue);
                    txt_screenfee.Text = Convert.ToString(fee);
                    txt_totscreenfee.Text = Convert.ToString(screenfee);
                }
                if (Capcity > 500)
                {
                    fee = 1000;
                    decimal screenfee = fee * Convert.ToDecimal(ddllicenseperiod.SelectedValue);
                    txt_screenfee.Text = Convert.ToString(fee);
                    txt_totscreenfee.Text = Convert.ToString(screenfee);
                }



            }
        }

        totalfeeofseatcapcity();
    }


    void totalfeeofseatcapcity()
    {
        decimal conttot = 0;
        if (grd_dynamic.Rows.Count > 0)
        {
            for (int i = 0; i < grd_dynamic.Rows.Count; i++)
            {
                TextBox txt_totscreenfee = grd_dynamic.Rows[i].FindControl("txt_totscreenfee") as TextBox;
                decimal testcount = 0;

                if (!string.IsNullOrEmpty(txt_totscreenfee.Text))
                {
                    testcount = Convert.ToDecimal(txt_totscreenfee.Text);
                }
                conttot = conttot + testcount;
            }
        }
        txtapprovalfeecinemalicense.Text = Convert.ToString(conttot);
    }

    protected void txtnoofscreens_TextChanged(object sender, EventArgs e)
    {
        trtotalfee.Visible = true;
        dynamicgridbind();
    }

    public void InsertScreenDetails(string multiplexid, List<Screendetails> lstscreendetails)
    {
        try
        {
            int valid = 0;
            con.OpenConnection();
            SqlCommand cmd = null;

            foreach (Screendetails fromvo in lstscreendetails)
            {
                cmd = new SqlCommand("USP_INSERT_ScreenDetails", con.GetConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@intQuessionaireCFOid", Convert.ToString(multiplexid));
                //cmd.Parameters.AddWithValue("@intCFEEnterpid", Convert.ToString(intCFOEnterpid));
                //cmd.Parameters.AddWithValue("@Quessionaireid", Convert.ToString(formvoobj.Quessionaireid));
                cmd.Parameters.AddWithValue("@ScreenNO", Convert.ToString(fromvo.ScreenNO));
                cmd.Parameters.AddWithValue("@SeatCapacity", Convert.ToString(fromvo.SeatCapacity));
                cmd.Parameters.AddWithValue("@ScreenFee", Convert.ToString(fromvo.ScreenFee));
                cmd.Parameters.AddWithValue("@TotalFee", Convert.ToString(fromvo.TotalFee));

                cmd.Parameters.AddWithValue("@Created_By ", Convert.ToString(fromvo.Created_By));
                cmd.Parameters.Add("@Valid", SqlDbType.Int, 500);
                cmd.Parameters["@Valid"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                valid = (Int32)cmd.Parameters["@Valid"].Value;
            }

            // return n;
        }
        catch (Exception ex)
        {

            throw ex;

        }
        finally
        {

            con.CloseConnection();
        }
    }
}