using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using System.IO;


public partial class TSTBDCReg1 : System.Web.UI.Page
{
    string createdby;
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    int hp;
    DB.DB con = new DB.DB();
    decimal TotalFee = Convert.ToDecimal("0");

    protected void Page_Load(object sender, EventArgs e)
    {
        //createdby = Session["uid"].ToString();
        if (Session.Count <= 0)
        {
            Response.Redirect("../../frmUserLogin.aspx");
        }

        if (!IsPostBack)
        {
            BindTravelAgentConstitutionoftheAgency();
            BindDistrict();
            FillDetails();
        }

    }

    public void FillDetails()
    {
        int createdby = Convert.ToInt32(Session["uid"].ToString());
        DataSet ds = Gen.GetregtravelagentbytravelagentID(createdby);
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                string App_status = Convert.ToString(ds.Tables[0].Rows[0]["App_Status"]);
                if (App_status == "2")
                {
                    trUploads.Visible = true;
                    Session["Applid"] = Convert.ToString(ds.Tables[0].Rows[0]["TravelAgentID"]);
                    hdnTransactionNumber.Value = Convert.ToString(ds.Tables[0].Rows[0]["TravelAgentID"]);
                    txtNameoftheAgency.Text = Convert.ToString(ds.Tables[0].Rows[0]["NameoftheAgency"]);
                    txtNameoftheOwner.Text = Convert.ToString(ds.Tables[0].Rows[0]["NameoftheOwner"]);
                    txtMobileNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["MobileNo"]);
                    txtEmailID.Text = Convert.ToString(ds.Tables[0].Rows[0]["EmailID"]);
                    traadhar.Visible = false;
                    // aadhar.Text = Convert.ToString(ds.Tables[0].Rows[0]["AadhaarNo"]);
                    ddlAppliedFor.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Appliedfor"]);

                    rbtAgencyArrangementsTravel.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Agencyarrangementsoftickets"]);
                    rbtAgencyArrangementsTransport.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Agencyarrangementstransport"]);
                    // rbtAgencyProvidingTouristTransport.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["AgencyAdventureTourism"]);
                    rbtAgencyProvidingTouristTransport.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Agencyprovidingtouristtransport"]);
                    rbtApplyingFor.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Applyingfor"]);
                    txtDateCommencementBusiness.Text = Convert.ToString(ds.Tables[0].Rows[0]["DateofCommencementoftheBusiness"]);

                    ddlConstitutionodAgency.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ConstitutionoftheAgency"]);
                    rbtPremises.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Whetherthepremisesis"]);
                    if (rbtPremises.SelectedValue == "O")
                    {
                        trowneddoc.Visible = true;
                        trleaseddoc.Visible = false;
                    }
                    else
                    {
                        trleaseddoc.Visible = true;
                        trowneddoc.Visible = false;

                    }
                    txtOfficeSpace.Text = Convert.ToString(ds.Tables[0].Rows[0]["OfficeSpace"]);
                    txtReceptionArea.Text = Convert.ToString(ds.Tables[0].Rows[0]["ReceptionArea"]);
                    rbtLOcationArea.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["LocationArea"]);
                    txtAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["Address"]);
                    ddlDistrictOffice.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["District"]);
                    ddlDistrictOffice_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlProp_intMandalid.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["mandal"]);
                    ddlProp_intMandalid_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlProp_intVillageid.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["taluk"]);
                    txtPinCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["PINCode"]);
                    txtPhoneNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["PhoneNo"]);
                    txtFAXNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["FAXNo"]);
                    txtMobileNumberOffice.Text = Convert.ToString(ds.Tables[0].Rows[0]["MobileNoOffice"]);
                    txtEmailIDOffice.Text = Convert.ToString(ds.Tables[0].Rows[0]["EmailIDOffice"]);
                    txtWebSite.Text = Convert.ToString(ds.Tables[0].Rows[0]["Website"]);


                    txtqualifiedStaff.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoofqualifiedStaff"]);
                    txtExperiencedStaff.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoofexperiencedStaff"]);
                    txtStaffEmployed.Text = Convert.ToString(ds.Tables[0].Rows[0]["TotalNoofStaffEmployed"]);
                    txtPaidUpCapital.Text = Convert.ToString(ds.Tables[0].Rows[0]["Paidupcapital"]);
                    txtPreviousTurnover.Text = Convert.ToString(ds.Tables[0].Rows[0]["PreviousTurnover"]);
                    txtPanFinacial.Text = Convert.ToString(ds.Tables[0].Rows[0]["PANNoFinancial"]);
                    rbtPreviousYearITReturns.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PreviousYearITReturns"]);
                    if (rbtPreviousYearITReturns.SelectedValue == "Y")
                    {
                        tritreturns.Visible = true;
                    }
                    else
                    {
                        tritreturns.Visible = false;
                    }
                    txtGSTNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["GSTNoFinancial"]);
                    txtBankAccountDtls.Text = Convert.ToString(ds.Tables[0].Rows[0]["BankAccountDetails"]);
                    txtBranchName.Text = Convert.ToString(ds.Tables[0].Rows[0]["Branchname"]);
                    txtBankAccountNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["accountnumber"]);
                    txtIFSC.Text = Convert.ToString(ds.Tables[0].Rows[0]["IFSC"]);
                    txtMICR.Text = Convert.ToString(ds.Tables[0].Rows[0]["MICR"]);
                    rbtEncloseReferenceLetter.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["EnclosereferenceletterfromBank"]);
                    rbtRequiredTradeLicense.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["DoyourequireTradeLicense"]);
                    rbtRequiredTradeLicense_SelectedIndexChanged(this, EventArgs.Empty);
                    rbtRequireShopsEstablishment.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["DoyourequireShopsEstablishmentLicense"]);
                    rbtRequireShopsEstablishment_SelectedIndexChanged(this, EventArgs.Empty);
                    rbtregisteredwithanyTourismDepartment.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["WhetherregisteredwithanyTourismDepartment"]);
                    if (rbtregisteredwithanyTourismDepartment.SelectedValue == "Y")
                    {
                        trencloseddoc.Visible = true;
                    }
                    else
                    {
                        trencloseddoc.Visible = false;
                    }
                    txtNoofTouristVehicles.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoofTouristVehicles"]);
                    Convert.ToString(ds.Tables[0].Rows[0]["CreatedBy"]);
                    Convert.ToString(ds.Tables[0].Rows[0]["CreatedDate"]);
                    if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {
                        FillAttachmentsDetails(ds);
                    }
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
                sen2 = ds.Tables[1].Rows[i][0].ToString();
                sen1 = sen2.Replace(@"\", @"/");

                //  sen = sen1.Replace(@"C:/TSiPASS/Attachments/1192/", "~/");//"C:/TSiPASS/Attachments/1192/B1Form\CateogryofRegistration.jpg"
                //sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/Attachments")), "~/");
                if (sen1.ToUpper().Contains("PHOTO")) //SelfCertification
                {
                    // sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/TOURISMEVENT")), "~/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("PHOTO"))
                    {
                        HyperLinkfupPhoto.Visible = true;
                        HyperLinkfupPhoto.Text = ds.Tables[1].Rows[i][1].ToString();
                        HyperLinkfupPhoto.NavigateUrl = sen;
                        lblfupPhoto.Text = ds.Tables[1].Rows[i][1].ToString();
                    }
                }
                else if (sen1.ToUpper().Contains("OWNED")) //SelfCertification
                {
                    // sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/TOURISMEVENT")), "~/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("OWNED"))
                    {
                        HyperLinkOwnedDoc.Visible = true;
                        HyperLinkOwnedDoc.Text = ds.Tables[1].Rows[i][1].ToString();
                        HyperLinkOwnedDoc.NavigateUrl = sen;
                        lblOwnedDoc.Text = ds.Tables[1].Rows[i][1].ToString();
                    }
                }
                if (sen1.ToUpper().Contains("LEASED")) //SelfCertification
                {
                    //sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/TOURISMEVENT")), "~/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("LEASED"))
                    {
                        HyperLinkLeasedDoc.Visible = true;
                        HyperLinkLeasedDoc.Text = ds.Tables[1].Rows[i][1].ToString();
                        HyperLinkLeasedDoc.NavigateUrl = sen;
                        lblLeasedDoc.Text = ds.Tables[1].Rows[i][1].ToString();
                    }
                }
                if (sen1.ToUpper().Contains("YEAR")) //SelfCertification
                {
                    //sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/TOURISMEVENT")), "~/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("YEAR"))
                    {
                        HyperLinkPreviousYearITReturns.Visible = true;
                        HyperLinkPreviousYearITReturns.Text = ds.Tables[1].Rows[i][1].ToString();
                        HyperLinkPreviousYearITReturns.NavigateUrl = sen;
                        lblPreviousYearITReturns.Text = ds.Tables[1].Rows[i][1].ToString();
                    }
                }

                if (sen1.ToUpper().Contains("ENCLOSED")) //SelfCertification
                {
                    //sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/TOURISMEVENT")), "~/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("ENCLOSED"))
                    {
                        HyperLinkfupEnclosedDoc.Visible = true;
                        HyperLinkfupEnclosedDoc.Text = ds.Tables[1].Rows[i][1].ToString();
                        HyperLinkfupEnclosedDoc.NavigateUrl = sen;
                        lblfupEnclosedDoc.Text = ds.Tables[1].Rows[i][1].ToString();
                    }
                }

                if (sen1.ToUpper().Contains("SELF")) //SelfCertification
                {
                    // sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/TOURISMEVENT")), "~/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("SELF"))
                    {
                        HyperLinkfupSelfDeclaration.Visible = true;
                        HyperLinkfupSelfDeclaration.Text = ds.Tables[1].Rows[i][1].ToString();
                        HyperLinkfupSelfDeclaration.NavigateUrl = sen;
                        lblfupSelfDeclaration.Text = ds.Tables[1].Rows[i][1].ToString();

                    }
                }

                if (sen1.ToUpper().Contains("CERTIFICATE")) //SelfCertification
                {
                    // sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/TOURISMEVENT")), "~/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("CERTIFICATE"))
                    {
                        HyperLinkfupEncloseAuditorsCertificate.Visible = true;
                        HyperLinkfupEncloseAuditorsCertificate.Text = ds.Tables[1].Rows[i][1].ToString();
                        HyperLinkfupEncloseAuditorsCertificate.NavigateUrl = sen;
                        lblfupEncloseAuditorsCertificate.Text = ds.Tables[1].Rows[i][1].ToString();
                    }
                }
                if (sen1.ToUpper().Contains("BANK"))
                {
                    // sen = sen1.ToUpper().Replace(sen1.Substring(0, sen1.ToUpper().IndexOf(@"/TOURISMEVENT")), "~/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("BANK"))
                    {
                        HyperLinkEnclosereferenceletterfromBank.Visible = true;
                        HyperLinkEnclosereferenceletterfromBank.Text = ds.Tables[1].Rows[i][1].ToString();
                        HyperLinkEnclosereferenceletterfromBank.NavigateUrl = sen;
                        lblEnclosereferenceletterfromBank.Text = ds.Tables[1].Rows[i][1].ToString();
                    }
                }

                i++;
            }

        }

    }
    public void BindTravelAgentConstitutionoftheAgency()
    {
        DataSet dsTypes = new DataSet();
        dsTypes = Gen.GetTravelAgentConstitutionoftheAgency();
        if (dsTypes.Tables[0].Rows.Count > 0)
        {
            ddlConstitutionodAgency.DataSource = dsTypes.Tables[0];
            ddlConstitutionodAgency.DataTextField = "ConstitutionoftheAgency_Name";
            ddlConstitutionodAgency.DataValueField = "ConstitutionoftheAgency_ID";
            ddlConstitutionodAgency.DataBind();

            ddlConstitutionodAgency.Items.Insert(0, new ListItem("Select", "0"));

        }
    }

    public void BindDistrict()
    {
        //DataSet dsTypes = new DataSet();
        //dsTypes = Gen.GetDistricts();
        Cls_MasterofTsipass obj_newdistrictwargnal = new Cls_MasterofTsipass();
        DataSet dsTypes = new DataSet();
        dsTypes = obj_newdistrictwargnal.GetallDistrictswithoutWarangal(Convert.ToString(Session["uid"]), "TA");
        if (dsTypes.Tables[0].Rows.Count > 0)
        {
            ddlDistrictOffice.DataSource = dsTypes.Tables[0];
            ddlDistrictOffice.DataTextField = "District_Name";
            ddlDistrictOffice.DataValueField = "District_Id";
            ddlDistrictOffice.DataBind();

            ddlDistrictOffice.Items.Insert(0, new ListItem("Select", "0"));

        }
    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {

    }
    public string ValidateControls()
    {
        int slno = 1;
        string ErrorMsg = "";
        if (ddlConstitutionodAgency.SelectedValue == "0" || ddlConstitutionodAgency.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Constitution of the Agency. \\n";
            slno = slno + 1;
        }
        if (ddlDistrictOffice.SelectedValue == "--Select--" || ddlDistrictOffice.SelectedValue == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select district. \\n";
            slno = slno + 1;
        }
        if (ddlProp_intMandalid.SelectedValue == "0" || ddlProp_intMandalid.SelectedValue == "--Select--" || ddlProp_intMandalid.SelectedValue == "--Mandal--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select mandal. \\n";
            slno = slno + 1;
        }
        if (ddlProp_intVillageid.SelectedValue == "0" || ddlProp_intVillageid.SelectedValue == "--Select--" || ddlProp_intVillageid.SelectedValue == "--Village--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select village. \\n";
            slno = slno + 1;
        }


        return ErrorMsg;
    }
    protected void btnSave_Click(object sender, EventArgs e)
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
            Response objResp = new Response();
            //string AdharCardno = "";
            //if (txtadhar1.Text.Trim() != "" && txtadhar2.Text.Trim() != "" && txtadhar3.Text.Trim() != "")
            //{
            //    AdharCardno = txtadhar1.Text.Trim() + txtadhar2.Text.Trim() + txtadhar3.Text.Trim();
            //}
            DraftQuestionnaireTravelAgent obj = new DraftQuestionnaireTravelAgent();
            obj.NameoftheAgency = txtNameoftheAgency.Text.ToString();
            obj.NameoftheOwner = txtNameoftheOwner.Text.ToString();
            obj.MobileNo = txtMobileNumber.Text.ToString();
            obj.EmailID = txtEmailID.Text.ToString();
            obj.AadhaarNo = "123412341234";
            obj.Appliedfor = ddlAppliedFor.SelectedValue.ToString();
            obj.Agencyarrangementsoftickets = rbtAgencyArrangementsTravel.SelectedValue.ToString();
            obj.Agencyarrangementstransport = rbtAgencyArrangementsTransport.SelectedValue.ToString();
            obj.AgencyAdventureTourism = rbtAgencyProvidingTouristTransport.SelectedValue.ToString();
            obj.Agencyprovidingtouristtransport = rbtAgencyProvidingTouristTransport.SelectedValue.ToString();
            // obj.Agencyprovidingtouristtransport = "Yes";
            obj.Applyingfor = rbtApplyingFor.SelectedValue.ToString();
            obj.DateofCommencementoftheBusiness = Convert.ToDateTime(txtDateCommencementBusiness.Text);
            obj.ConstitutionoftheAgency = ddlConstitutionodAgency.SelectedValue.ToString();
            obj.Whetherthepremisesis = rbtPremises.SelectedValue.ToString();
            obj.OfficeSpace = txtOfficeSpace.Text.ToString();
            obj.ReceptionArea = txtReceptionArea.Text.ToString();
            obj.LocationArea = rbtLOcationArea.SelectedValue.ToString();
            obj.Address = txtAddress.Text.ToString();
            obj.District = ddlDistrictOffice.SelectedValue.ToString();

            obj.Mandal = ddlProp_intMandalid.SelectedValue.ToString();
            obj.Village = ddlProp_intVillageid.SelectedValue.ToString();

            obj.PINCode = txtPinCode.Text.ToString();
            obj.PhoneNo = txtPhoneNumber.Text.ToString();
            obj.FAXNo = txtFAXNo.Text.ToString();
            obj.MobileNoOffice = txtMobileNumberOffice.Text.ToString();
            obj.EmailIDOffice = txtEmailIDOffice.Text.ToString();
            obj.Website = txtWebSite.Text.ToString();
            obj.NoofqualifiedStaff = txtqualifiedStaff.Text.ToString();
            obj.NoofexperiencedStaff = txtExperiencedStaff.Text.ToString();
            obj.TotalNoofStaffEmployed = txtStaffEmployed.Text.ToString();
            obj.Paidupcapital = txtPaidUpCapital.Text.ToString();
            obj.PreviousTurnover = txtPreviousTurnover.Text.ToString();
            obj.PANNoFinancial = txtPanFinacial.Text.ToString();
            obj.PreviousYearITReturns = rbtPreviousYearITReturns.SelectedValue.ToString();
            obj.GSTNoFinancial = txtGSTNumber.Text.ToString();
            obj.BankAccountDetails = txtBankAccountDtls.Text.ToString();
            obj.Branchname = txtBranchName.Text.ToString();
            obj.Accountnumber = txtBankAccountNumber.Text.ToString();
            obj.IFSC = txtIFSC.Text.ToString();
            obj.MICR = txtMICR.Text.ToString();
            obj.EnclosereferenceletterfromBank = rbtEncloseReferenceLetter.SelectedValue.ToString();
            obj.DoyourequireTradeLicense = rbtRequiredTradeLicense.SelectedValue.ToString();
            obj.DoyourequireShopsEstablishmentLicense = rbtRequireShopsEstablishment.SelectedValue.ToString();
            obj.WhetherregisteredwithanyTourismDepartment = rbtregisteredwithanyTourismDepartment.SelectedValue.ToString();
            obj.NoofTouristVehicles = txtNoofTouristVehicles.Text.ToString();
            obj.CreatedBy = Convert.ToInt32(Session["uid"]);
            obj.FileUploadPaths = GetFiles();
            int TravelAgentID = 0;

            objResp = Gen.InsertDraftQuestionnaireTravelAgent(obj, out TravelAgentID);
            Session["Applid"] = TravelAgentID;

            if (objResp.ResponseVal = true)
            {
                hdnTransactionNumber.Value = TravelAgentID.ToString();
                Response.Write("Submitted Successfully.....");
                BtnSave.Enabled = false;
                BtnClear.Enabled = false;
                btnNext.Enabled = true;
                trUploads.Visible = true;
                BindFees();

            }
        }
        catch (Exception ex)
        {

        }
    }
    public void BindFees()
    {
        //try
        //{
        //    DataSet dsv = new DataSet();
        //    dsv = null;

        //    //   DataSet dsTourism = new DataSet();
        //    dsv = Gen.GetShowApprovalandFees_TravelAgent("114");
        //    //  dsv.Tables[0].Merge(dsTourism.Tables[0]);

        //    DataSet dsPolice = new DataSet();
        //    if (rbtRequiredTradeLicense.SelectedValue == "0")
        //    {
        //        dsPolice = Gen.GetShowApprovalandFees_TravelAgent("112");
        //        dsv.Tables[0].Merge(dsPolice.Tables[0]);
        //    }

        //    DataSet dsFire = new DataSet();
        //    if (rbtRequireShopsEstablishment.SelectedValue == "0")
        //    {
        //        dsFire = Gen.GetShowApprovalandFees_TravelAgent("113");
        //        dsv.Tables[0].Merge(dsFire.Tables[0]);
        //    }

        //    if (dsv.Tables[0].Rows.Count > 0)
        //    {
        //        grdDetails.DataSource = dsv.Tables[0];
        //        grdDetails.DataBind();

        //        // gvitems.DataSource= dsv.Tables[0];
        //        // gvitems.DataBind();
        //        dvfeedetails.Visible = true;
        //    }
        //    else
        //    {
        //        grdDetails.DataSource = null;
        //        grdDetails.DataBind();
        //        dvfeedetails.Visible = false;
        //    }
        //}
        //catch (Exception ex)
        //{

        //}

    }
    protected void ShowMessage(string Message, string type)
    {
        //ClientScript.RegisterStartupScript(this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    public DataTable GetFiles()
    {
        DataTable dt = new DataTable();

        dt.TableName = "FileUploadPaths";


        dt.Columns.Add("FileType");
        dt.Columns.Add("FilePath");
        dt.Columns.Add("UploadFileName");
        dt.Columns.Add("DocumentName");
        if (!string.IsNullOrWhiteSpace(HyperLinkfupPhoto.NavigateUrl))
        {
            // !string.IsNullOrWhiteSpace(btnDeleteSitePlan.CommandArgument)
            DataRow dr = dt.NewRow();
            dr["FileType"] = hdnPhotoDoc.Value.ToString();
            dr["UploadFileName"] = hdnPhotoDocFilename.Value.ToString();
            dr["FilePath"] = HyperLinkfupPhoto.NavigateUrl.Trim();
            dr["DocumentName"] = "Photo";
            dt.Rows.Add(dr);
        }
        if (!string.IsNullOrWhiteSpace(HyperLinkOwnedDoc.NavigateUrl))
        {
            // !string.IsNullOrWhiteSpace(btnDeleteSitePlan.CommandArgument)
            DataRow dr = dt.NewRow();
            dr["FileType"] = hdnOwnedDoc.Value.ToString();
            dr["UploadFileName"] = hdnOwnedDocFileName.Value.ToString();
            dr["FilePath"] = HyperLinkOwnedDoc.NavigateUrl.Trim();
            dr["DocumentName"] = "Owned Document";
            dt.Rows.Add(dr);
        }
        if (!string.IsNullOrWhiteSpace(HyperLinkLeasedDoc.NavigateUrl))
        {
            // !string.IsNullOrWhiteSpace(btnDeleteSitePlan.CommandArgument)
            DataRow dr = dt.NewRow();
            dr["FileType"] = hdnLeasedDoc.Value.ToString();
            dr["UploadFileName"] = hdnLeasedDocFileName.Value.ToString();
            dr["FilePath"] = HyperLinkLeasedDoc.NavigateUrl.Trim();
            dr["DocumentName"] = "Leased Document";
            dt.Rows.Add(dr);
        }
        if (!string.IsNullOrWhiteSpace(HyperLinkPreviousYearITReturns.NavigateUrl))
        {
            // !string.IsNullOrWhiteSpace(btnDeleteSitePlan.CommandArgument)
            DataRow dr = dt.NewRow();
            dr["FileType"] = hdnPreviousYearITReturns.Value.ToString();
            dr["UploadFileName"] = hdnPreviousYearITReturnsFileName.Value.ToString();
            dr["FilePath"] = HyperLinkPreviousYearITReturns.NavigateUrl.Trim();
            dr["DocumentName"] = "Privious Year IT Returns";
            dt.Rows.Add(dr);
        }
        if (!string.IsNullOrWhiteSpace(HyperLinkfupEnclosedDoc.NavigateUrl))
        {
            // !string.IsNullOrWhiteSpace(btnDeleteSitePlan.CommandArgument)
            DataRow dr = dt.NewRow();
            dr["FileType"] = hdnEnclosedDoc.Value.ToString();
            dr["UploadFileName"] = hdnEnclosedDocFileName.Value.ToString();
            dr["FilePath"] = HyperLinkfupEnclosedDoc.NavigateUrl.Trim();
            dr["DocumentName"] = "Enclosed Document";
            dt.Rows.Add(dr);
        }
        if (!string.IsNullOrWhiteSpace(HyperLinkfupSelfDeclaration.NavigateUrl))
        {
            // !string.IsNullOrWhiteSpace(btnDeleteSitePlan.CommandArgument)
            DataRow dr = dt.NewRow();
            dr["FileType"] = hdnSelfDeclaration.Value.ToString();
            dr["UploadFileName"] = hdnSelfDeclarationFileName.Value.ToString();
            dr["FilePath"] = HyperLinkfupSelfDeclaration.NavigateUrl.Trim();
            dr["DocumentName"] = "Self Declaration";
            dt.Rows.Add(dr);
        }
        if (!string.IsNullOrWhiteSpace(HyperLinkfupEncloseAuditorsCertificate.NavigateUrl))
        {
            // !string.IsNullOrWhiteSpace(btnDeleteSitePlan.CommandArgument)
            DataRow dr = dt.NewRow();
            dr["FileType"] = hdnencloserauditorscertificate.Value.ToString();
            dr["UploadFileName"] = hdnencloserauditorscertificatefilename.Value.ToString();
            dr["FilePath"] = HyperLinkfupEncloseAuditorsCertificate.NavigateUrl.Trim();
            dr["DocumentName"] = "Encloser Auditor Certificate";
            dt.Rows.Add(dr);
        }
        if (!string.IsNullOrWhiteSpace(HyperLinkEnclosereferenceletterfromBank.NavigateUrl))
        {
            // !string.IsNullOrWhiteSpace(btnDeleteSitePlan.CommandArgument)
            DataRow dr = dt.NewRow();
            dr["FileType"] = hdnencloserreferanceletterfrombank.Value.ToString();
            dr["UploadFileName"] = hdnencloserreferanceletterfrombankfilename.Value.ToString();
            dr["FilePath"] = HyperLinkEnclosereferenceletterfromBank.NavigateUrl.Trim();
            dr["DocumentName"] = "Encloser reference letter from bank ";
            dt.Rows.Add(dr);
        }
        if (dt.Rows.Count == 0)
        {
            //DataRow dr = dt.NewRow();
            //dr["Module_Id"] = "-";
            //dt.Rows.Add(dr);
            dt = null;
        }

        return dt;
    }
    public int SaveAttachments(string intTravelAgentID, string FileType, string FilePath, string FileName, string FileDescription, string Created_by)
    {
        int n = 0;
        try
        {

            con.OpenConnection();

            SqlCommand cmdFiles = new SqlCommand("usp_Insert_TravelAgent_attachments", con.GetConnection);
            cmdFiles.CommandType = CommandType.StoredProcedure;

            cmdFiles.Parameters.AddWithValue("@TravelAgent_ID", Convert.ToInt32(intTravelAgentID));
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

    protected void btnfupPhoto_Click(object sender, EventArgs e)
    {

        string SubFolder = @"\TravelAgent\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        General.FileResult objfileResult = new General.FileResult();

        string[] extensions = { ".pdf", ".jpg", ".jpeg" };
        objfileResult = Gen.SaveFile(fupPhoto, SubFolder, "Photo");

        if (objfileResult.Result == true)
        {
            //HyperLinkfupPhoto.Visible = true;
            //HyperLinkfupPhoto.NavigateUrl = objfileResult.FilePath;
            lblfupPhoto.Text = objfileResult.FileName;
            hdnPhotoDoc.Value = objfileResult.FileType;
            hdnPhotoDocFilename.Value = objfileResult.FileName;
            fupPhoto.Visible = false;
            btnfupPhoto.Visible = false;
            BtnSave.Focus();
            int result = 0;
            result = SaveAttachments(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "Photo", Session["uid"].ToString());
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

    protected void btnOwnedDoc_Click(object sender, EventArgs e)
    {
        string SubFolder = @"\TravelAgent\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        General.FileResult objfileResult = new General.FileResult();

        string[] extensions = { ".pdf", ".jpg", ".jpeg" };
        objfileResult = Gen.SaveFile(fupOwnedDoc, SubFolder, "OwnedDocument");

        if (objfileResult.Result == true)
        {
            //HyperLinkOwnedDoc.Visible = true;
            // HyperLinkOwnedDoc.NavigateUrl = objfileResult.FilePath;
            lblOwnedDoc.Text = objfileResult.FileName;
            hdnOwnedDoc.Value = objfileResult.FileType;
            hdnOwnedDocFileName.Value = objfileResult.FileName;
            fupOwnedDoc.Visible = false;
            btnOwnedDoc.Visible = false;
            BtnSave.Focus();
            int result = 0;
            result = SaveAttachments(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "OwnedDocument", Session["uid"].ToString());
            if (result > 0)
            {
                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                HyperLinkOwnedDoc.Visible = true;
                HyperLinkOwnedDoc.Text = objfileResult.FileName;
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

            HyperLinkOwnedDoc.NavigateUrl = objfileResult.FilePath;
            lblOwnedDoc.Text = objfileResult.Message;
        }
    }

    protected void btnLeasedDoc_Click(object sender, EventArgs e)
    {
        string SubFolder = @"\TravelAgent\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        General.FileResult objfileResult = new General.FileResult();

        string[] extensions = { ".pdf", ".jpg", ".jpeg" };
        objfileResult = Gen.SaveFile(fupLeasedDoc, SubFolder, "LeasedDocument");

        if (objfileResult.Result == true)
        {
            HyperLinkLeasedDoc.Visible = true;
            //HyperLinkLeasedDoc.NavigateUrl = objfileResult.FilePath;
            HyperLinkLeasedDoc.Text = objfileResult.FileName;
            //lblLeasedDoc.Text = objfileResult.FileName;
            hdnLeasedDoc.Value = objfileResult.FileType;
            hdnLeasedDocFileName.Value = objfileResult.FileName;
            fupLeasedDoc.Visible = false;
            btnLeasedDoc.Visible = false;
            BtnSave.Focus();
            int result = 0;
            result = SaveAttachments(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "LeasedDocument", Session["uid"].ToString());
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

            HyperLinkLeasedDoc.NavigateUrl = objfileResult.FilePath;
            lblLeasedDoc.Text = objfileResult.Message;
        }
    }

    protected void btnPreviousYearITReturns_Click(object sender, EventArgs e)
    {
        string SubFolder = @"\TravelAgent\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        General.FileResult objfileResult = new General.FileResult();

        string[] extensions = { ".pdf", ".jpg", ".jpeg" };
        objfileResult = Gen.SaveFile(fupPreviousYearITReturns, SubFolder, "PreviousYearITReturns");

        if (objfileResult.Result == true)
        {
            HyperLinkPreviousYearITReturns.Visible = true;
            // HyperLinkPreviousYearITReturns.NavigateUrl = objfileResult.FilePath;
            HyperLinkPreviousYearITReturns.Text = objfileResult.FileName;
            lblPreviousYearITReturns.Text = objfileResult.FileName;
            hdnPreviousYearITReturns.Value = objfileResult.FileType;
            hdnPreviousYearITReturnsFileName.Value = objfileResult.FileName;
            fupPreviousYearITReturns.Visible = false;
            btnPreviousYearITReturns.Visible = false;
            BtnSave.Focus();
            int result = 0;
            result = SaveAttachments(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "PreviousYearITReturns", Session["uid"].ToString());
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

            HyperLinkPreviousYearITReturns.NavigateUrl = objfileResult.FilePath;
            lblPreviousYearITReturns.Text = objfileResult.Message;
        }
    }

    protected void btnfupEnclosedDoc_Click(object sender, EventArgs e)
    {
        string SubFolder = @"\TravelAgent\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        General.FileResult objfileResult = new General.FileResult();

        string[] extensions = { ".pdf", ".jpg", ".jpeg" };
        objfileResult = Gen.SaveFile(fupEnclosedDoc, SubFolder, "EnclosedDocument");

        if (objfileResult.Result == true)
        {
            HyperLinkfupEnclosedDoc.Visible = true;
            // HyperLinkfupEnclosedDoc.NavigateUrl = objfileResult.FilePath;
            HyperLinkfupEnclosedDoc.Text = objfileResult.FileName;
            lblfupEnclosedDoc.Text = objfileResult.FileName;
            hdnEnclosedDoc.Value = objfileResult.FileType;
            hdnEnclosedDocFileName.Value = objfileResult.FileName;
            fupEnclosedDoc.Visible = false;
            btnfupEnclosedDoc.Visible = false;
            BtnSave.Focus();
            int result = 0;
            result = SaveAttachments(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "EnclosedDocument", Session["uid"].ToString());
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

            HyperLinkfupEnclosedDoc.NavigateUrl = objfileResult.FilePath;
            lblfupEnclosedDoc.Text = objfileResult.Message;
        }
    }

    protected void btnfupSelfDeclaration_Click(object sender, EventArgs e)
    {
        string SubFolder = @"\TravelAgent\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        General.FileResult objfileResult = new General.FileResult();

        string[] extensions = { ".pdf", ".jpg", ".jpeg" };
        objfileResult = Gen.SaveFile(fupSelfDeclaration, SubFolder, "SelfDeclaration");

        if (objfileResult.Result == true)
        {
            HyperLinkfupSelfDeclaration.Visible = true;
            // HyperLinkfupSelfDeclaration.NavigateUrl = objfileResult.FilePath;
            HyperLinkfupSelfDeclaration.Text = objfileResult.FileName;
            lblfupSelfDeclaration.Text = objfileResult.FileName;
            hdnSelfDeclaration.Value = objfileResult.FileType;
            hdnSelfDeclarationFileName.Value = objfileResult.FileName;
            fupSelfDeclaration.Visible = false;
            btnfupSelfDeclaration.Visible = false;
            BtnSave.Focus();
            int result = 0;
            result = SaveAttachments(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "SelfDeclaration", Session["uid"].ToString());
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

            HyperLinkfupSelfDeclaration.NavigateUrl = objfileResult.FilePath;
            lblfupSelfDeclaration.Text = objfileResult.Message;
        }
    }
    protected void btnEnclosereferenceletterfromBank_Click(object sender, EventArgs e)
    {
        string SubFolder = @"\TravelAgent\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        General.FileResult objfileResult = new General.FileResult();

        string[] extensions = { ".pdf", ".jpg", ".jpeg" };
        objfileResult = Gen.SaveFile(fupEnclosereferenceletterfromBank, SubFolder, "EnclosereferenceletterfromBank");

        if (objfileResult.Result == true)
        {
            HyperLinkEnclosereferenceletterfromBank.Visible = true;
            //HyperLinkEnclosereferenceletterfromBank.NavigateUrl = objfileResult.FilePath;
            HyperLinkEnclosereferenceletterfromBank.Text = objfileResult.FileName;
            lblEnclosereferenceletterfromBank.Text = objfileResult.FileName;
            hdnencloserreferanceletterfrombank.Value = objfileResult.FileType;
            hdnencloserreferanceletterfrombankfilename.Value = objfileResult.FileName;
            fupEnclosereferenceletterfromBank.Visible = false;
            btnEnclosereferenceletterfromBank.Visible = false;
            BtnSave.Focus();
            int result = 0;
            result = SaveAttachments(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "EnclosereferenceletterfromBank", Session["uid"].ToString());
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

            HyperLinkEnclosereferenceletterfromBank.NavigateUrl = objfileResult.FilePath;
            lblEnclosereferenceletterfromBank.Text = objfileResult.Message;
        }
    }
    protected void btnfupEncloseAuditorsCertificate_Click(object sender, EventArgs e)
    {
        string newPath = "";
        // string sFileDir = @"D:\TS-iPASSFinal\Attachments";
        string SubFolder = @"\TourismEvent\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
        General.FileResult objfileResult = new General.FileResult();

        string[] extensions = { ".pdf", ".jpg", ".jpeg" };
        objfileResult = Gen.SaveFile(fupEncloseAuditorsCertificate, SubFolder, "EncloseAuditorsCertificate");

        if (objfileResult.Result == true)
        {
            HyperLinkfupEncloseAuditorsCertificate.Visible = true;
            //HyperLinkfupEncloseAuditorsCertificate.NavigateUrl = objfileResult.FilePath;
            HyperLinkfupEncloseAuditorsCertificate.Text = objfileResult.FileName;
            lblfupEncloseAuditorsCertificate.Text = objfileResult.FileName;
            hdnencloserauditorscertificate.Value = objfileResult.FileType;
            hdnencloserauditorscertificatefilename.Value = objfileResult.FileName;
            fupEncloseAuditorsCertificate.Visible = false;
            btnfupEncloseAuditorsCertificate.Visible = false;
            BtnSave.Focus();
            int result = 0;
            result = SaveAttachments(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "EncloseAuditorsCertificate", Session["uid"].ToString());
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
    protected void rbtPremises_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtPremises.SelectedValue == "O")
        {

            trowneddoc.Visible = true;
            trleaseddoc.Visible = false;
        }
        else
        {
            trleaseddoc.Visible = true;
            trowneddoc.Visible = false;

        }

    }

    protected void rbtPreviousYearITReturns_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtPreviousYearITReturns.SelectedValue == "Y")
        {
            tritreturns.Visible = true;

        }
        else
        {
            tritreturns.Visible = false;
        }

    }

    protected void rbtregisteredwithanyTourismDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtregisteredwithanyTourismDepartment.SelectedValue == "Y")
        {
            trencloseddoc.Visible = true;

        }
        else
        {
            trencloseddoc.Visible = false;
        }

    }
    public string ValidateFileUploads()
    {
        int slno = 1;
        string ErrorMsg = "";
        //if (lblfupFabricationMaterialDoc.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please upload Fabrication Material Plan. \\n";
        //    slno = slno + 1;
        //}
        if (lblfupPhoto.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Passport Size Photo. \\n";
            slno = slno + 1;
        }
        if (trowneddoc.Visible == true)
        {
            if (lblOwnedDoc.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please upload upload the relevant Documents with self declaration stating that the premises being used for Agency purpose only. \\n";
                slno = slno + 1;
            }

        }
        if (trleaseddoc.Visible == true)
        {
            if (lblLeasedDoc.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please upload the lease agreement. \\n";
                slno = slno + 1;
            }

        }
        if (lblfupEncloseAuditorsCertificate.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Enclose Auditors Certificate. \\n";
            slno = slno + 1;
        }
        if (tritreturns.Visible == true)
        {
            if (lblPreviousYearITReturns.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please upload Previos year IT returns. \\n";
                slno = slno + 1;
            }

        }
        if (lblEnclosereferenceletterfromBank.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Enclose reference letter from Bank. \\n";
            slno = slno + 1;
        }

        if (trencloseddoc.Visible == true)
        {
            if (lblfupEnclosedDoc.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please upload Enclosed Documents. \\n";
                slno = slno + 1;
            }

        }
        if (lblfupSelfDeclaration.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Self Declaration. \\n";
            slno = slno + 1;
        }
        if (trshopcopy.Visible == true)
        {
            if (lblshop.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please upload Shops & Establishment License Copy. \\n";
                slno = slno + 1;
            }
        }
        if (trtradecopy.Visible == true)
        {
            if (lbltrade.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please upload Trade License Copy. \\n";
                slno = slno + 1;
            }
        }
        return ErrorMsg;
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        string errormsg = ValidateFileUploads();
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        try
        {
            if (hdnTransactionNumber.Value.ToString().Trim() == "" || hdnTransactionNumber.Value.Trim() == "0")
            {
                Response.Redirect("frmDraftQuestionnaireRegistrationOfTravelAgent.aspx");
            }
            else
            {
                //if (rbtRequireShopsEstablishment.SelectedValue == "Y")
                //{
                //    Response.Redirect("frmlabourshops_tourismagent.aspx?intCFEEnterpid=" + Convert.ToString(Session["Applid"]) + "&Query=Y" + "&intApplicationId=" + Convert.ToString(Session["Applid"]) + "&intApprovalid=113");
                //    //"~/Reports/frmlabourshops_tourismagent.aspx?Query=Y"+ "&ApplidA=" + Session["Applid"].Tostring()"+ "&intApprovalid=113" ;

                //    // "~/Reports/frmlabourshops_tourismagent.aspx?intCFEEnterpid=" + Convert.ToString(Session["Applid"]) + "&Query=Y" + "&intApplicationId=" + Convert.ToString(Session["Applid"]);

                //}
                //else
                //{
                //    Response.Redirect("frmPaymentTravelAgent.aspx?intCFEEnterpid=" + Convert.ToString(Session["Applid"]));
                //}
                if (!string.IsNullOrEmpty(Convert.ToString(Session["Applid"])))
                {
                    string labourapproval = "N";
                    string tradelicenseapproval = "N";
                    if (rbtRequiredTradeLicense.SelectedValue == "Y")
                    {
                        tradelicenseapproval = "Y";
                    }
                    if (rbtRequireShopsEstablishment.SelectedValue == "Y")
                    {
                        labourapproval = "Y";
                    }

                    //if (labourapproval == "N" && tradelicenseapproval == "N")
                    //{
                    //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('PLEASE SELECT ONE APPROVAL TRADE LICENSE(13) OR SHOPS AND ESTABLISHMENT LICENSE(14)')", true);
                    //    //BtnSave.Enabled = false;
                    //    return;
                    //}
                    //else
                    //{
                    //if (rbtRequiredTradeLicense.SelectedValue == "Y")
                    //{
                    //    Response.Redirect("frmTradeLicense_Travelagent.aspx?intCFEEnterpid=" + Convert.ToString(Session["Applid"]) + "&Query=Y" + "&intApplicationId=" + Convert.ToString(Session["Applid"]) + "&intApprovalid=118");
                    //}
                    //else
                    if (rbtRequireShopsEstablishment.SelectedValue == "Y")
                    {
                        Response.Redirect("frmlabourshops_tourismagent.aspx?intCFEEnterpid=" + Convert.ToString(Session["Applid"]) + "&Query=Y" + "&intApplicationId=" + Convert.ToString(Session["Applid"]) + "&intApprovalid=113");
                    }
                    else
                    {
                        Response.Redirect("frmPaymentTravelAgent.aspx?intCFEEnterpid=" + Convert.ToString(Session["Applid"]));
                    }
                    //}
                }
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void ddlDistrictOffice_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlDistrictOffice.SelectedIndex == 0)
            {
                ddlProp_intMandalid.Items.Clear();
                ddlProp_intMandalid.Items.Insert(0, "--Mandal--");
                //   ChkWater_reg_from.Items.Clear();
                // ChkWater_reg_from.Items.Insert(0, new ListItem("New Bore well", "New Bore well"));
                //ChkWater_reg_from.Items.Insert(1, new ListItem("HMWS & SB", "HMWS & SB"));
                //ChkWater_reg_from.Items.Insert(2, new ListItem("Rivers/Canals", "Rivers/Canals"));
            }
            else
            {
                ddlProp_intMandalid.Items.Clear();
                DataSet dsm = new DataSet();
                dsm = Gen.GetMandals(ddlDistrictOffice.SelectedValue);
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
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void ddlProp_intMandalid_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
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
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }

    }

    protected void rbtRequireShopsEstablishment_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rbtRequireShopsEstablishment.SelectedValue == "N")
            {
                trshopcopy.Visible = true;
            }
            else
            {
                trshopcopy.Visible = false;
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnshop_Click(object sender, EventArgs e)
    {
        try
        {
            string SubFolder = @"\TravelAgent\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
            General.FileResult objfileResult = new General.FileResult();

            string[] extensions = { ".pdf", ".jpg", ".jpeg" };
            objfileResult = Gen.SaveFile(fushops, SubFolder, "ShopLabourLicnese");

            if (objfileResult.Result == true)
            {
                HyperLinkshop.Visible = true;
                //HyperLinkEnclosereferenceletterfromBank.NavigateUrl = objfileResult.FilePath;
                HyperLinkshop.Text = objfileResult.FileName;
                lblshop.Text = objfileResult.FileName;
                hdnshop.Value = objfileResult.FileType;
                hdnshopfilename.Value = objfileResult.FileName;
                fushops.Visible = false;
                btnshop.Visible = false;
                BtnSave.Focus();
                int result = 0;
                result = SaveAttachments(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "ShopLabourLicnese", Session["uid"].ToString());
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

                HyperLinkshop.NavigateUrl = objfileResult.FilePath;
                lblshop.Text = objfileResult.Message;
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btntrade_Click(object sender, EventArgs e)
    {
        try
        {
            string SubFolder = @"\TravelAgent\" + Session["uid"].ToString() + @"\" + Session["Applid"].ToString();
            General.FileResult objfileResult = new General.FileResult();

            string[] extensions = { ".pdf", ".jpg", ".jpeg" };
            objfileResult = Gen.SaveFile(futrade, SubFolder, "TradeLicnese");

            if (objfileResult.Result == true)
            {
                HyperLinktrade.Visible = true;
                //HyperLinkEnclosereferenceletterfromBank.NavigateUrl = objfileResult.FilePath;
                HyperLinktrade.Text = objfileResult.FileName;
                lbltrade.Text = objfileResult.FileName;
                hdntrade.Value = objfileResult.FileType;
                hdntradefilename.Value = objfileResult.FileName;
                futrade.Visible = false;
                btntrade.Visible = false;
                BtnSave.Focus();
                int result = 0;
                result = SaveAttachments(Session["Applid"].ToString(), objfileResult.FileType, objfileResult.FilePath, objfileResult.FileName, "TradeLicnese", Session["uid"].ToString());
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

                HyperLinktrade.NavigateUrl = objfileResult.FilePath;
                lbltrade.Text = objfileResult.Message;
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void rbtRequiredTradeLicense_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rbtRequiredTradeLicense.SelectedValue == "N")
            {
                trtradecopy.Visible = true;
            }
            else
            {
                trtradecopy.Visible = false;
            }
        }
        catch (Exception ex)
        {
        }
    }
}
