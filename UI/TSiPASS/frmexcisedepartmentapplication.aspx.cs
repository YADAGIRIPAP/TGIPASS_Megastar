using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_TSiPASS_frmexcisedepartmentapplication : System.Web.UI.Page
{
    General Gen = new General();
    Cls_exciseliquoruser obj_data = new Cls_exciseliquoruser();
    comFunctions ddd = new comFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("../../frmUserLogin.aspx");
        }

        if (!IsPostBack)
        {
            BindexciseDistrict();
            BindDistrict();
            FillDetails();
        }
    }

    #region Master
    public void BindexciseDistrict()
    {
        DataSet dsTypes = new DataSet();
        dsTypes = Gen.GetDistricts();
        if (dsTypes.Tables[0].Rows.Count > 0)
        {
            ddl_excisedistrict.DataSource = dsTypes.Tables[0];
            ddl_excisedistrict.DataTextField = "District_Name";
            ddl_excisedistrict.DataValueField = "District_Id";
            ddl_excisedistrict.DataBind();
            ddl_excisedistrict.Items.Insert(0, new ListItem("Select", "0"));

        }
    }
    public void BindDistrict()
    {
        DataSet dsTypes = new DataSet();
        dsTypes = Gen.GetDistricts();
        if (dsTypes.Tables[0].Rows.Count > 0)
        {
            ddl_district.DataSource = dsTypes.Tables[0];
            ddl_district.DataTextField = "District_Name";
            ddl_district.DataValueField = "District_Id";
            ddl_district.DataBind();
            ddl_district.Items.Insert(0, new ListItem("Select", "0"));

        }
    }
    public void BindMandal()
    {
        ddl_mandal.Items.Clear();
        DataSet dsm = new DataSet();
        dsm = Gen.GetMandals(ddl_district.SelectedValue);
        if (dsm.Tables[0].Rows.Count > 0)
        {
            ddl_mandal.DataSource = dsm.Tables[0];
            ddl_mandal.DataValueField = "Mandal_Id";
            ddl_mandal.DataTextField = "Manda_lName";
            ddl_mandal.DataBind();
            ddl_mandal.Items.Insert(0, "--Mandal--");
        }
        else
        {
            ddl_mandal.Items.Clear();
            ddl_mandal.Items.Insert(0, "--Mandal--");
        }
    }
    public void BindVillage()
    {
        ddl_village.Items.Clear();
        DataSet dsv = new DataSet();
        dsv = Gen.GetVillages(ddl_mandal.SelectedValue);
        if (dsv.Tables[0].Rows.Count > 0)
        {
            ddl_village.DataSource = dsv.Tables[0];
            ddl_village.DataValueField = "Village_Id";
            ddl_village.DataTextField = "Village_Name";
            ddl_village.DataBind();
            ddl_village.Items.Insert(0, "--Village--");
        }
        else
        {
            ddl_village.Items.Clear();
            ddl_village.Items.Insert(0, "--Village--");
        }
    }
    protected void ddl_district_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_district.SelectedIndex == 0)
        {
            ddl_mandal.Items.Clear();
            ddl_mandal.Items.Insert(0, "--Mandal--");
        }
        else
        {
            BindMandal();
        }
    }
    protected void ddl_mandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_mandal.SelectedIndex == 0)
        {

            ddl_village.Items.Clear();
            ddl_village.Items.Insert(0, "--Village--");
        }
        else
        {
            BindVillage();
        }
    }

    #endregion


    #region Get data
    public void FillDetails()
    {
        string createdby = Convert.ToString(Session["uid"].ToString());
        DataSet ds = obj_data.getdatabyapplicantid(createdby);
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                string App_status = Convert.ToString(ds.Tables[0].Rows[0]["StageID"]);
                if (App_status == "2")
                {
                    trUploads.Visible = true;
                    Session["Applid"] = Convert.ToString(ds.Tables[0].Rows[0]["ExciseliquorID"]);
                    hf_exciseliquorid.Value = Convert.ToString(ds.Tables[0].Rows[0]["ExciseliquorID"]);
                    txt_gazetteserialno.Text = Convert.ToString(ds.Tables[0].Rows[0]["gazetteserialno"]);
                    txt_Location.Text = Convert.ToString(ds.Tables[0].Rows[0]["Location"]);
                    txt_ExciseStation.Text = Convert.ToString(ds.Tables[0].Rows[0]["ExciseStation"]);         
                    ddl_excisedistrict.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["exciseDistrictID"]);
                    txt_RetailExciseTaxSlabperyearinLakhs.Text = Convert.ToString(ds.Tables[0].Rows[0]["retailtaxslabyearinlakhs"]);

                    txt_applicantname.Text = Convert.ToString(ds.Tables[0].Rows[0]["applicantname"]);
                    txt_applicantfathusname.Text = Convert.ToString(ds.Tables[0].Rows[0]["applicationfathername"]);
                    txt_applicantdateofbirth.Text = Convert.ToString(ds.Tables[0].Rows[0]["applicantdateofbirth"]);
                    txt_applicantage.Text = Convert.ToString(ds.Tables[0].Rows[0]["applicantage"]);
                    txt_HouseNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["houseno"]);
                    txt_RoadStreetLocality.Text = Convert.ToString(ds.Tables[0].Rows[0]["streetno"]);
                    ddl_district.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ApplDistrictID"]);
                    if (ddl_district.SelectedIndex == 0)
                    {
                        ddl_mandal.Items.Clear();
                        ddl_mandal.Items.Insert(0, "--Mandal--");
                    }
                    else
                    {
                        BindMandal();
                    }
                    ddl_mandal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ApplicantMandal"]);
                    if (ddl_mandal.SelectedIndex == 0)
                    {
                        ddl_village.Items.Clear();
                        ddl_village.Items.Insert(0, "--Village--");
                    }
                    else
                    {
                        BindVillage();
                    }
                    ddl_village.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Applicantvillage"]);

                    txt_pincode.Text = Convert.ToString(ds.Tables[0].Rows[0]["pincode"]);
                    txt_mobileno1.Text = Convert.ToString(ds.Tables[0].Rows[0]["mobileno1"]);
                    txt_mobileno2.Text = Convert.ToString(ds.Tables[0].Rows[0]["mobileno2"]);
                    txt_emailid.Text = Convert.ToString(ds.Tables[0].Rows[0]["EmailID"]);
                    txt_Nameofthefirmcompany.Text = Convert.ToString(ds.Tables[0].Rows[0]["nameoffirmregistration"]);
                    txt_RegistrationNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["registrationno"]);
                    txt_RegistrationDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["registrationdate"]);
                    txt_gstin.Text = Convert.ToString(ds.Tables[0].Rows[0]["gistin"]);
                    txtPanFinacial.Text = Convert.ToString(ds.Tables[0].Rows[0]["pancard"]);
                    txt_adharno.Text = Convert.ToString(ds.Tables[0].Rows[0]["Aadharno"]);
                    rd_certificatea4.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["isa4certificate"]);
                    trUploads.Visible = false;
                    if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {
                        trUploads.Visible = true;
                        FillAttachmentsDetails(ds);
                        if (rd_certificatea4.SelectedValue == "Y")
                        {
                            trcertdoc.Visible = true;
                        }
                        else
                        {
                            trcertdoc.Visible = false;
                        }
                    }

                    btnNext.Visible = true;

                }
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
                sen2 = ds.Tables[1].Rows[i]["FilePath"].ToString();
                sen1 = sen2.Replace(@"\", @"/");
                if (sen1.ToUpper().Contains("PHOTO")) //SelfCertification
                {
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("PHOTO"))
                    {
                        HyperLinkfupPhoto.Visible = true;
                        HyperLinkfupPhoto.Text = ds.Tables[1].Rows[i]["FileDescription"].ToString();
                        HyperLinkfupPhoto.NavigateUrl = sen;
                        lblfupPhoto.Text = ds.Tables[1].Rows[i]["FileDescription"].ToString();
                    }
                }
                else if (sen1.ToUpper().Contains("PANCARD")) //SelfCertification
                {
                    // sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/Exciseliquor")), "~/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("PANCARD"))
                    {
                        HyperLinkpancardDoc.Visible = true;
                        HyperLinkpancardDoc.Text = ds.Tables[1].Rows[i]["FileDescription"].ToString();
                        HyperLinkpancardDoc.NavigateUrl = sen;
                        lblpancardDoc.Text = ds.Tables[1].Rows[i]["FileDescription"].ToString();
                    }
                }
                if (sen1.ToUpper().Contains("AADHAR")) //SelfCertification
                {
                    //sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/Exciseliquor")), "~/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("AADHAR"))
                    {
                        HyperLinkAadharCardDoc.Visible = true;
                        HyperLinkAadharCardDoc.Text = ds.Tables[1].Rows[i]["FileDescription"].ToString();
                        HyperLinkAadharCardDoc.NavigateUrl = sen;
                        lblAadharCardDoc.Text = ds.Tables[1].Rows[i]["FileDescription"].ToString();
                    }
                }
                if (sen1.ToUpper().Contains("CERTIFICATE")) //SelfCertification
                {
                    // sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/Exciseliquor")), "~/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("CERTIFICATE"))
                    {
                        HyperLinkfupEncloseAuditorsCertificate.Visible = true;
                        HyperLinkfupEncloseAuditorsCertificate.Text = ds.Tables[1].Rows[i]["FileDescription"].ToString();
                        HyperLinkfupEncloseAuditorsCertificate.NavigateUrl = sen;
                        lblfupEncloseAuditorsCertificate.Text = ds.Tables[1].Rows[i]["FileDescription"].ToString();
                    }
                }
               

                i++;
            }

        }

    }

    #endregion

    #region insert updata data
    public string ValidateControls()
    {
        int slno = 1;
        string ErrorMsg = "";
        if (txt_gazetteserialno.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter gazetteserialno \\n";
            slno = slno + 1;
        }
        if (txt_Location.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Location \\n";
            slno = slno + 1;
        }
        if (txt_ExciseStation.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter ExciseStation \\n";
            slno = slno + 1;
        }
        if (ddl_excisedistrict.SelectedValue == "" || ddl_excisedistrict.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select excisedistrict. \\n";
            slno = slno + 1;
        }
        if (txt_RetailExciseTaxSlabperyearinLakhs.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter RetailExciseTaxSlabperyearinLakhs \\n";
            slno = slno + 1;
        }
         if (txt_applicantname.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter applicantname \\n";
            slno = slno + 1;
        }
        if (txt_applicantfathusname.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter applicantfathusname \\n";
            slno = slno + 1;
        }
        if (txt_applicantdateofbirth.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter applicantdateofbirth \\n";
            slno = slno + 1;
        }
        if (txt_applicantage.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter applicantage \\n";
            slno = slno + 1;
        }
        if (txt_HouseNo.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter HouseNo \\n";
            slno = slno + 1;
        }
        if (txt_RoadStreetLocality.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter RoadStreetLocality \\n";
            slno = slno + 1;
        }
        if (ddl_district.SelectedValue == "--Select--" || ddl_district.SelectedValue == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select district. \\n";
            slno = slno + 1;
        }
        if (ddl_mandal.SelectedValue == "0" || ddl_mandal.SelectedValue == "--Select--" || ddl_mandal.SelectedValue == "--Mandal--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select mandal. \\n";
            slno = slno + 1;
        }
        if (ddl_village.SelectedValue == "0" || ddl_village.SelectedValue == "--Select--" || ddl_village.SelectedValue == "--Village--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select village. \\n";
            slno = slno + 1;
        }
        if (txt_pincode.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter pincode \\n";
            slno = slno + 1;
        }
        if (txt_mobileno1.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter mobileno1 \\n";
            slno = slno + 1;
        }
        if (txt_mobileno2.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter txt_mobileno2 \\n";
            slno = slno + 1;
        }
        if (txt_emailid.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter emailid \\n";
            slno = slno + 1;
        }
        if (txt_Nameofthefirmcompany.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enterNameofthefirmcompany \\n";
            slno = slno + 1;
        }
        if (txt_RegistrationNo.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter RegistrationNo \\n";
            slno = slno + 1;
        }
        if (txt_RegistrationDate.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter RegistrationDate \\n";
            slno = slno + 1;
        }
        if (txt_gstin.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter GSTIN \\n";
            slno = slno + 1;
        }
        if (txtPanFinacial.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter PanCard \\n";
            slno = slno + 1;
        }
        if (txt_adharno.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Aadhar Card \\n";
            slno = slno + 1;
        }
        return ErrorMsg;
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        string errormsg = ValidateControls();
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        try
        {
            string ApplicationID = insertupdatedataofliqour();
            Session["Applid"] = ApplicationID;
            if (ApplicationID!= "" && ApplicationID != "0")
            {
                FillDetails();

                hf_exciseliquorid.Value = ApplicationID.ToString();
                Response.Write("Submitted Successfully.....");
                BtnSave.Enabled = false;
                BtnClear.Enabled = false;
                btnNext.Enabled = true;
                trUploads.Visible = true;
               // trcertdoc.Visible = false;

            }
        }
        catch (Exception ex)
        {

        }
    }

    public string insertupdatedataofliqour()
    {
        string ApplicationID = "";
        try
        {
            trcertdoc.Visible = false;
            Exciseliquorobj obj = new Exciseliquorobj();

            if (hf_exciseliquorid.Value != "" && hf_exciseliquorid.Value != "0")
            {
                obj.ExciseliquorID = Convert.ToInt32(hf_exciseliquorid.Value);
            }

            obj.gazetteserialno = Convert.ToString(txt_gazetteserialno.Text);
            obj.Location = Convert.ToString(txt_Location.Text);
            obj.ExciseStation = Convert.ToString(txt_ExciseStation.Text);
            obj.exciseDistrictID = Convert.ToString(ddl_excisedistrict.SelectedValue);
            obj.exciseDistrictName = Convert.ToString(ddl_excisedistrict.SelectedItem.Text);
            obj.retailtaxslabyearinlakhs = Convert.ToString(txt_RetailExciseTaxSlabperyearinLakhs.Text);
            obj.applicantname = Convert.ToString(txt_applicantname.Text);
            obj.applicationfathername = Convert.ToString(txt_applicantfathusname.Text);
            // obj.applicantdateofbirth = Convert.ToDateTime(txt_applicantdateofbirth.Text);
            obj.applicantdateofbirth = ddd.convertDateIndia(txt_applicantdateofbirth.Text);
            obj.applicantage = Convert.ToInt32(txt_applicantage.Text);
            obj.houseno = Convert.ToString(txt_HouseNo.Text);
            obj.streetno = Convert.ToString(txt_RoadStreetLocality.Text);
            obj.ApplDistrictID = Convert.ToString(ddl_district.SelectedValue);
            obj.ApplicantMandal = Convert.ToString(ddl_mandal.SelectedValue);
            obj.Applicantvillage = Convert.ToString(ddl_village.SelectedValue);
            obj.pincode = Convert.ToString(txt_pincode.Text);
            obj.mobileno1 = Convert.ToString(txt_mobileno1.Text);
            obj.mobileno2 = Convert.ToString(txt_mobileno2.Text);
            obj.EmailID = Convert.ToString(txt_emailid.Text);
            obj.nameoffirmregistration = Convert.ToString(txt_Nameofthefirmcompany.Text);
            obj.registrationno = Convert.ToString(txt_RegistrationNo.Text);
            //obj.registrationdate = Convert.ToDateTime(txt_RegistrationDate.Text);
            obj.registrationdate = ddd.convertDateIndia(txt_RegistrationDate.Text);
            obj.gistin = Convert.ToString(txt_gstin.Text);
            obj.pancard = Convert.ToString(txtPanFinacial.Text);
            obj.Aadharno = Convert.ToString(txt_adharno.Text);
            obj.isa4certificate = Convert.ToString(rd_certificatea4.SelectedValue);
            obj.CreatedBy = Convert.ToString(Session["uid"]);
            obj.CreatedIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            ApplicationID = obj_data.Insertupdateexciseliquor(obj);
            if (obj.isa4certificate == "Y")
            {
                trcertdoc.Visible = true;
            }
        }
        catch(Exception ex)
        {

        }
       
        return ApplicationID;
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        if (hf_exciseliquorid.Value.ToString().Trim() == "" || hf_exciseliquorid.Value.Trim() == "0")
        {
            Response.Redirect("frmexcisedepartmentapplication.aspx");
        }
        else
        {
            string errormsg = ValidateControls();
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            try
            {
             
                string ApplicationID = insertupdatedataofliqour(); ;
                Session["Applid"] = ApplicationID;
                if (ApplicationID != "" && ApplicationID != "0")
                {
                    hf_exciseliquorid.Value = ApplicationID.ToString();
                    Response.Write("Submitted Successfully.....");
                    BtnSave.Enabled = false;
                    BtnClear.Enabled = false;
                    btnNext.Enabled = true;
                    trUploads.Visible = true;                  
                    //Payment
                }
            }
            catch (Exception ex)
            {

            }
            if (!string.IsNullOrEmpty(Convert.ToString(Session["Applid"])))
            {
                Response.Redirect("frmpaymentExciseliquor.aspx?intCFEEnterpid=" + Convert.ToString(Session["Applid"]));
            }
        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {

    }
    #endregion


    #region file upload
    protected void btnfupPhoto_Click(object sender, EventArgs e)
    {

        string SubFolder = @"\Exciseliquor\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        General.FileResult objfileResult = new General.FileResult();

        string[] extensions = { ".pdf", ".jpg", ".jpeg" };
        objfileResult = Gen.SaveFile(fupPhoto, SubFolder, "Photo");

        if (objfileResult.Result == true)
        {
            lblfupPhoto.Text = objfileResult.FileName;
            fupPhoto.Visible = false;
            btnfupPhoto.Visible = false;
            BtnSave.Focus();
            int result = 0;
            result =obj_data.SaveAttachmentsofExciseliquorID(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "Photo", Session["uid"].ToString());
            if (result > 0)
            {
                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                HyperLinkfupPhoto.Visible = true;
                HyperLinkfupPhoto.Text = objfileResult.FileName;

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

            HyperLinkfupPhoto.NavigateUrl = objfileResult.FilePath;
            lblfupPhoto.Text = objfileResult.Message;
        }
    }
    protected void btnpancardDoc_Click(object sender, EventArgs e)
    {
        string SubFolder = @"\Exciseliquor\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        General.FileResult objfileResult = new General.FileResult();

        string[] extensions = { ".pdf", ".jpg", ".jpeg" };
        objfileResult = Gen.SaveFile(fuppancardDoc, SubFolder, "PanCardDocument");

        if (objfileResult.Result == true)
        {
            lblpancardDoc.Text = objfileResult.FileName;
            fuppancardDoc.Visible = false;
            btnpancardDoc.Visible = false;
            BtnSave.Focus();
            int result = 0;
            result = obj_data.SaveAttachmentsofExciseliquorID(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "OwnedDocument", Session["uid"].ToString());
            if (result > 0)
            {
                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                HyperLinkpancardDoc.Visible = true;
                HyperLinkpancardDoc.Text = objfileResult.FileName;
                BtnSave.Focus();
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

            HyperLinkpancardDoc.NavigateUrl = objfileResult.FilePath;
            lblpancardDoc.Text = objfileResult.Message;
        }
    }
    protected void btnAadharCardDoc_Click(object sender, EventArgs e)
    {
        string SubFolder = @"\Exciseliquor\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        General.FileResult objfileResult = new General.FileResult();

        string[] extensions = { ".pdf", ".jpg", ".jpeg" };
        objfileResult = Gen.SaveFile(fupAadharCardDoc, SubFolder, "AadharCardDocument");

        if (objfileResult.Result == true)
        {
            HyperLinkAadharCardDoc.Visible = true;
            HyperLinkAadharCardDoc.Text = objfileResult.FileName;
            fupAadharCardDoc.Visible = false;
            btnAadharCardDoc.Visible = false;
            BtnSave.Focus();
            int result = 0;
            result = obj_data.SaveAttachmentsofExciseliquorID(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "LeasedDocument", Session["uid"].ToString());
            if (result > 0)
            {
                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
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

            HyperLinkAadharCardDoc.NavigateUrl = objfileResult.FilePath;
            lblAadharCardDoc.Text = objfileResult.Message;
        }
    }
    protected void btnfupEncloseAuditorsCertificate_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string SubFolder = @"\Exciseliquor\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        General.FileResult objfileResult = new General.FileResult();

        string[] extensions = { ".pdf", ".jpg", ".jpeg" };
        objfileResult = Gen.SaveFile(fupEncloseAuditorsCertificate, SubFolder, "EncloseAuditorsCertificate");

        if (objfileResult.Result == true)
        {
            HyperLinkfupEncloseAuditorsCertificate.Visible = true;
            HyperLinkfupEncloseAuditorsCertificate.Text = objfileResult.FileName;
            lblfupEncloseAuditorsCertificate.Text = objfileResult.FileName;
            fupEncloseAuditorsCertificate.Visible = false;
            btnfupEncloseAuditorsCertificate.Visible = false;
            BtnSave.Focus();
            int result = 0;
            result = obj_data.SaveAttachmentsofExciseliquorID(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "EncloseAuditorsCertificate", Session["uid"].ToString());
            if (result > 0)
            {
                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
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

            HyperLinkfupEncloseAuditorsCertificate.NavigateUrl = objfileResult.FilePath;
            lblfupEncloseAuditorsCertificate.Text = objfileResult.Message;
        }
    }

    #endregion

    protected void rd_certificatea4_SelectedIndexChanged(object sender, EventArgs e)
    {
        trcertdoc.Visible = false;
        if (hf_exciseliquorid.Value != "" && hf_exciseliquorid.Value != "0")
        {          
            if (rd_certificatea4.SelectedValue == "Y")
            {
                trcertdoc.Visible = true;
            }
        }
    }
}