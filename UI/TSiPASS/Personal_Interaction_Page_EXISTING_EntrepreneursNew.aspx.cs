using AjaxControlToolkit;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
//using System.Threading;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_Personal_Interaction_Page_EXISTING_EntrepreneursNew : System.Web.UI.Page
{
    string Enterpreneur_ID;
    General gen = new General();
    DB.DB con = new DB.DB();
    DataSet dsvacanplots = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["uid"] == null || Session["uid"].ToString() == "")
            {
                Response.Redirect("~/TSHome.aspx");

            }
            else
            {
                if (Session["Role_Code"].ToString() == "GM" || Session["Role_Code"].ToString() == "IPO"
                || Session["Role_Code"].ToString() == "AD" || Session["Role_Code"].ToString() == "DD")
                {
                    UID_SEARCH_GRID.Visible = true;
                    Page.MaintainScrollPositionOnPostBack = true;

                    if (!IsPostBack)
                    {
                        ViewState["ExtResult"] = "0";
                        //Grievance_Types();
                        //Marketing_Grievance();
                        //Financial_Grievance();
                        //Marketing_Schemes_Types();
                        MEESHO_Platform_Details();
                        JUST_DIAL_Platform_Details();
                        TS_GLOBAL_Platform_Details();
                        WALMART_VRIDDI_Platform_Details();
                        Marketing_Assistance_Scheme_Details();
                        Schemes_PMS_Details();
                        Scheme_SMAS_Details();
                        Grievance_Status_Dropdown();
                        Mandal_List();
                        UID_Mandal_List();
                        Social_Category_Types();
                        Sector_Name_Details();
                        Line_Department_List();
                        if (Request.QueryString["HdnEnterpreneur_ID"] != null)
                        {
                            Enterpreneur_ID = Request.QueryString["HdnEnterpreneur_ID"].ToString();
                            //Session["PIEEId"]= Request.QueryString["HdnEnterpreneur_ID"].ToString();
                            binddata(Enterpreneur_ID, sender, e);
                        }

                    }
                    //if (IsPostBack)
                    //{
                    //GeneratePlatformTable();

                    //}
                }
                else { Response.Redirect("~/TSHome.aspx"); }
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    public void binddata(string EnterpreneurID, object sender, EventArgs e)
    {
        try
        {
            DataSet dsdept = new DataSet();
            {
                SqlParameter[] pp = new SqlParameter[]
                {
                new SqlParameter("@HdnEnterpreneur_ID", SqlDbType.VarChar)
                };
                pp[0].Value = EnterpreneurID;
                dsdept = gen.GenericFillDs("sp_EXISTING_Entrepreneurs_print", pp);
                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                {
                    ListItem InteractionType = ModeOfInteraction.Items.FindByText(Convert.ToString(dsdept.Tables[0].Rows[0]["InteractionType"]));
                    InteractionType.Selected = true;
                    //  ModeOfInteraction.Enabled = false;
                    intrctiondt.Value = Convert.ToString(dsdept.Tables[0].Rows[0]["DateofInteraction"]);
                    if (Convert.ToString(dsdept.Tables[0].Rows[0]["ThroughWomenCell"]) == "No")
                    {
                        Women_Cell.SelectedValue = "1";
                        Women_Cell_SelectedIndexChanged(sender, e);
                        Women_Cell.Enabled = false;
                    }
                    else
                    {
                        Women_Cell.SelectedValue = "0";
                        Women_Cell_SelectedIndexChanged(sender, e);
                        Women_Cell.Enabled = false;

                        ListItem WomenCellIntrlevel = Interaction_Level_Existing.Items.FindByText(Convert.ToString(dsdept.Tables[0].Rows[0]["WomenCellIntrlevel"]));
                        WomenCellIntrlevel.Selected = true;
                        Interaction_Level_Existing.Enabled = false;
                        Interaction_Level_Existing_SelectedIndexChanged(sender, e);
                        if (Interaction_Level_Existing.SelectedItem.Text == "District Level")
                        {
                            Text1.Value = Convert.ToString(dsdept.Tables[0].Rows[0]["DistLevlIntractionDate"]);
                            TextBox4.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["DislevlIntractionVenue"]);
                            TextBox4.Enabled = false;
                        }
                        else if (Interaction_Level_Existing.SelectedItem.Text == "Mandal Level")
                        {
                            Mandal_List();
                            ListItem MandlLevlMandalName = ddl_Mandal.Items.FindByText(Convert.ToString(dsdept.Tables[0].Rows[0]["MandlLevlMandalName"]));
                            MandlLevlMandalName.Selected = true;
                            ddl_Mandal.Enabled = false;
                            ListItem MandllevlIntractionVenue = ddlvenuemandl.Items.FindByText(Convert.ToString(dsdept.Tables[0].Rows[0]["MandllevlIntractionVenue"]));
                            MandllevlIntractionVenue.Selected = true;
                            ddlvenuemandl.Enabled = false;
                            Interaction_Venue.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["MandllevlIntractionOtherVenue"]);
                            Interaction_Venue.Enabled = false;
                            Interaction_Date.Value = Convert.ToString(dsdept.Tables[0].Rows[0]["MandlLevlIntractionDate"]);
                        }
                    }

                    if (Convert.ToString(dsdept.Tables[0].Rows[0]["TSiPASSReg"]) == "Yes")
                    {
                        ViewState["UIDNO"] = Convert.ToString(dsdept.Tables[0].Rows[0]["UIDno"]);
                        ViewState["IsMajorExist"] = Convert.ToString(dsdept.Tables[0].Rows[0]["IsMajor"]);
                        ViewState["LOAID"] = Convert.ToString(dsdept.Tables[0].Rows[0]["LineofActivityID"]);
                        TS_IPASS_REGISTERED_Unit.SelectedValue = "0";
                        TS_IPASS_REGISTERED_Unit.Enabled = false;
                        TS_IPASS_REGISTERED_Unit_SelectedIndexChanged(sender, e);

                        txtemailExistng.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["mobileExistng"]);
                        txtemailExistng.Enabled = false;
                        txtemailExistng.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["emailExistng"]);
                        txtemailExistng.Enabled = false;
                        UID_SEARCH_GRID.DataSource = dsdept.Tables[1].Rows[0];
                        UID_SEARCH_GRID.DataBind();
                        UID_SEARCH_GRID.Visible = true;
                    }
                    else
                    {
                        TS_IPASS_REGISTERED_Unit.SelectedValue = "1";
                        TS_IPASS_REGISTERED_Unit.Enabled = false;
                        TS_IPASS_REGISTERED_Unit_SelectedIndexChanged(sender, e);
                        UID_Mandal_List();
                        string address = Convert.ToString(dsdept.Tables[0].Rows[0]["Address"]);
                        string[] adrs = address.Split(',');
                        ListItem Mandal = ddladrsmandal.Items.FindByText(adrs[0].Trim());
                        Mandal.Selected = true;
                        ddladrsmandal.Enabled = false;
                        ddladrsmandal_SelectedIndexChanged(sender, e);
                        ListItem Village = ddladrsvlg.Items.FindByText(adrs[1].Trim());
                        Village.Selected = true;
                        ddladrsvlg.Enabled = false;
                        //UID_Village_List(Convert.ToInt32(ddladrsmandal.SelectedValue));
                        //ddladrsvlg.SelectedItem.Text = adrs[1].Trim();   
                        Applicant_Name.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["Name"]);
                        Applicant_Name.Enabled = false;
                        Applicant_Contact.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["Contact"]);
                        Applicant_Contact.Enabled = false;
                        Applicant_Email.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["EmailId"]);
                        Applicant_Email.Enabled = false;
                        // Applicant_caste.SelectedItem.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["SocialCategory"]);
                        Social_Category_Types();
                        ListItem SocialCategory = Applicant_caste.Items.FindByText(Convert.ToString(dsdept.Tables[0].Rows[0]["SocialCategory"]));
                        SocialCategory.Selected = true;
                        Applicant_caste.Enabled = false;
                        if (Convert.ToString(dsdept.Tables[0].Rows[0]["Gender"]) == "--Select--")
                        {
                            Applicant_Gender.SelectedValue = "0";
                            Applicant_Gender.Enabled = false;
                            Applicant_Gender_SelectedIndexChanged(sender, e);
                        }
                        else if (Convert.ToString(dsdept.Tables[0].Rows[0]["Gender"]) == "Male")
                        {
                            Applicant_Gender.SelectedValue = "1";
                            Applicant_Gender.Enabled = false;
                            Applicant_Gender_SelectedIndexChanged(sender, e);
                        }
                        else if (Convert.ToString(dsdept.Tables[0].Rows[0]["Gender"]) == "Female")
                        {
                            Applicant_Gender.SelectedValue = "2";
                            Applicant_Gender.Enabled = false;
                            Applicant_Gender_SelectedIndexChanged(sender, e);
                        }
                        // Applicant_Gender.SelectedItem.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["Gender"]);
                        //ListItem Gender = Applicant_Gender.Items.FindByText(Convert.ToString(dsdept.Tables[0].Rows[0]["Gender"]));
                        //Gender.Selected = true;
                        if (Convert.ToString(dsdept.Tables[0].Rows[0]["Differentlyabled"]) == "Yes")
                        {
                            Differently_able.SelectedValue = "0";
                            Differently_able.Enabled = false;
                        }
                        else
                        {
                            Differently_able.SelectedValue = "1";
                            Differently_able.Enabled = false;
                        }
                        Applicant_Investment.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["Investment"]);
                        Applicant_Investment.Enabled = false;
                        Applicant_Employees.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["Employment"]);
                        Applicant_Employees.Enabled = false;
                        //sector_dropdown.SelectedItem.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["LineOfActivity"]);
                        Sector_Name_Details();
                        ListItem LineOfActivity = sector_dropdown.Items.FindByText(Convert.ToString(dsdept.Tables[0].Rows[0]["LineOfActivity"]));
                        LineOfActivity.Selected = true;
                        sector_dropdown.Enabled = false;
                        //  Enterprise_Sector.SelectedItem.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["EnterpriseSector"]);
                        ListItem EnterpriseSector = Enterprise_Sector.Items.FindByText(Convert.ToString(dsdept.Tables[0].Rows[0]["EnterpriseSector"]));
                        EnterpriseSector.Selected = true;
                        Enterprise_Sector.Enabled = false;
                        ViewState["IsMajorNew"] = Convert.ToString(dsdept.Tables[0].Rows[0]["IsMajor"]);
                    }

                    if (Convert.ToString(dsdept.Tables[0].Rows[0]["isMSMEreg"]) == "Yes")
                    {
                        rblMSMEreg.SelectedValue = "0";
                        rblMSMEreg.Enabled = false;
                        rblMSMEreg_SelectedIndexChanged(sender, e);
                    }
                    else
                    {
                        rblMSMEreg.SelectedValue = "1";
                        rblMSMEreg.Enabled = false;
                        rblMSMEreg_SelectedIndexChanged(sender, e);
                    }

                    if (Convert.ToString(dsdept.Tables[0].Rows[0]["IsUnderODOP"]) == "Yes")
                    {
                        LineOfActivity.SelectedValue = "0";
                        LineOfActivity.Enabled = false;
                        LineOfActivity_SelectedIndexChanged(sender, e);
                    }
                    else
                    {
                        LineOfActivity.SelectedValue = "1";
                        LineOfActivity.Enabled = false;
                        LineOfActivity_SelectedIndexChanged(sender, e);
                    }

                    if (Convert.ToString(dsdept.Tables[0].Rows[0]["ODOPEXPORT"]) == "Yes")
                    {
                        rdodpexport.SelectedValue = "0";
                        rdodpexport.Enabled = false;
                        rdodpexport_SelectedIndexChanged(sender, e);
                    }
                    else
                    {
                        rdodpexport.SelectedValue = "1";
                        rdodpexport.Enabled = false;
                        rdodpexport_SelectedIndexChanged(sender, e);
                    }
                    if (Convert.ToString(dsdept.Tables[0].Rows[0]["IsSick"]) == "Yes")
                    {
                        rblsick.SelectedValue = "0";
                        rblsick.Enabled = false;
                        rblsick_SelectedIndexChanged(sender, e);
                    }
                    else
                    {
                        rblsick.SelectedValue = "1";
                        rblsick.Enabled = false;
                        rblsick_SelectedIndexChanged(sender, e);
                    }
                    if (Convert.ToString(dsdept.Tables[0].Rows[0]["IsUnderPMEGP"]) == "Yes")
                    {
                        rblPMEGP.SelectedValue = "0";
                        rblPMEGP.Enabled = false;
                    }
                    else
                    {
                        rblPMEGP.SelectedValue = "1";
                        rblPMEGP.Enabled = false;
                    }
                    txtPAN.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["PANno"]);
                    txtPAN.Enabled = false;
                    if (Convert.ToString(dsdept.Tables[0].Rows[0]["IsGrvnceIdentfd"]) == "Yes")
                    {
                        Grievance_Identified.SelectedValue = "0";
                        Grievance_Identified.Enabled = false;
                        Grievance_Identified_SelectedIndexChanged(sender, e);
                        Grievance_Details.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrievanceDetails"]);
                        Grievance_Details.Enabled = false;
                        TextBox3.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrievanceResolution"]);
                        TextBox3.Enabled = false;
                        ListItem GrievanceStatus = GrievanceStatus_dropdown.Items.FindByText(Convert.ToString(dsdept.Tables[0].Rows[0]["GrievanceStatus"]));
                        GrievanceStatus.Selected = true;
                        if (Convert.ToString(Request.QueryString["Status"]) == "Grievance")
                            GrievanceStatus_dropdown.Enabled = true;
                        else
                            GrievanceStatus_dropdown.Enabled = false;
                    }
                    else
                    {
                        Grievance_Identified.SelectedValue = "1";
                        Grievance_Identified.Enabled = false;
                        Grievance_Identified_SelectedIndexChanged(sender, e);
                    }
                    if (Convert.ToString(dsdept.Tables[0].Rows[0]["rdboardgrivance"]) != "")
                    {
                        ListItem Broadtype = rdboardgrivance.Items.FindByText(Convert.ToString(dsdept.Tables[0].Rows[0]["rdboardgrivance"]));
                        Broadtype.Selected = true;
                    }

                    if (dsdept.Tables[0].Rows[0]["Gr_Technical"].ToString() == "Yes")
                    {
                        chkTechnical.Checked = true;
                        chkTechnical.Enabled = false;
                        ListItem Brdgrvnc = rdboardgrivance.Items.FindByText("1.Department Implemented Schemes");
                        Brdgrvnc.Selected = true;
                        // string S = rdboardgrivance.SelectedItem.Text;
                        rdboardgrivance.Enabled = false;
                        rdboardgrivance_SelectedIndexChanged(sender, e);
                        chkTechnical_CheckedChanged(sender, e);
                        if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrT_SchemeType"]) == "TSIPASS")
                        {
                            rblTechnSchms.SelectedValue = "0";
                            rblTechnSchms.Enabled = false;
                            rblTechnSchms_SelectedIndexChanged(sender, e);
                            if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrT_Type"]) == "S/W Related")
                            {
                                TechnicalType_Grievance.SelectedValue = "0";
                                TechnicalType_Grievance.Enabled = false;
                                TechnicalType_Grievance_SelectedIndexChanged(sender, e);
                            }
                            else if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrT_Type"]) == "Line Departments Related")
                            {
                                TechnicalType_Grievance.SelectedValue = "1";
                                TechnicalType_Grievance.Enabled = false;
                                TechnicalType_Grievance_SelectedIndexChanged(sender, e);
                                ListItem GrT_LineDeptName = ddlLineDepartment.Items.FindByText(Convert.ToString(dsdept.Tables[0].Rows[0]["GrT_LineDeptName"]));
                                GrT_LineDeptName.Selected = true;
                                ddlLineDepartment.Enabled = false;
                            }
                            else if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrT_Type"]) == "Others")
                            {
                                TechnicalType_Grievance.SelectedValue = "2";
                                TechnicalType_Grievance.Enabled = false;
                                TechnicalType_Grievance_SelectedIndexChanged(sender, e);
                                Technical_Others.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrT_Others"]);
                            }
                        }
                        else if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrT_SchemeType"]) == "Incentives")
                        {
                            rblTechnSchms.SelectedValue = "1";
                            rblTechnSchms.Enabled = false;
                            rblTechnSchms_SelectedIndexChanged(sender, e);
                            if (Convert.ToString(dsdept.Tables[0].Rows[0]["IncentiveIssue"]) == "S/W Related")
                            {
                                rdincentives.SelectedValue = "0";
                                rdincentives.Enabled = false;
                                rdincentives_SelectedIndexChanged(sender, e);
                            }
                            else if (Convert.ToString(dsdept.Tables[0].Rows[0]["IncentiveIssue"]) == "Sanction Pending")
                            {
                                rdincentives.SelectedValue = "1";
                                rdincentives.Enabled = false;
                                rdincentives_SelectedIndexChanged(sender, e);
                            }
                            else if (Convert.ToString(dsdept.Tables[0].Rows[0]["IncentiveIssue"]) == "Release Pending")
                            {
                                rdincentives.SelectedValue = "2";
                                rdincentives.Enabled = false;
                                rdincentives_SelectedIndexChanged(sender, e);

                            }
                        }
                        else if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrT_SchemeType"]) == "Raw-Material")
                        {
                            rblTechnSchms.SelectedValue = "2";
                            rblTechnSchms.Enabled = false;
                            rblTechnSchms_SelectedIndexChanged(sender, e);
                            ListItem RawmaterialIssue = rdrawmaterial.Items.FindByText(Convert.ToString(dsdept.Tables[0].Rows[0]["RawmaterialIssue"]));
                            RawmaterialIssue.Selected = true;
                            rdrawmaterial.Enabled = false;
                            if (Convert.ToString(dsdept.Tables[0].Rows[0]["Raw-Material"]) == "S/W Related")
                            {
                                rdrawmaterial.SelectedValue = "0";
                                rdrawmaterial.Enabled = false;
                                rdrawmaterial_SelectedIndexChanged(sender, e);
                            }
                            else if (Convert.ToString(dsdept.Tables[0].Rows[0]["Raw-Material"]) == "Application Status")
                            {
                                rdrawmaterial.SelectedValue = "1";
                                rdrawmaterial.Enabled = false;
                                rdrawmaterial_SelectedIndexChanged(sender, e);
                            }

                        }
                        else if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrT_SchemeType"]) == "MSEFC")
                        {
                            rblTechnSchms.SelectedValue = "3";
                            rblTechnSchms.Enabled = false;
                            rblTechnSchms_SelectedIndexChanged(sender, e);
                            if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrFDptIssue_CaseunderMSME"]) == "Yes")
                            {
                                MSEFCCase_Filed.SelectedValue = "0";
                                MSEFCCase_Filed.Enabled = false;
                                MSEFCCase_Filed_SelectedIndexChanged(sender, e);
                                MSEFC_Case_Details.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrFDptIssue_CaseMSMEdetails"]);
                            }
                            else
                            {
                                MSEFCCase_Filed.SelectedValue = "1";
                                MSEFCCase_Filed.Enabled = false;
                                MSEFCCase_Filed_SelectedIndexChanged(sender, e);
                                if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrFDptIssue_GivenFcltionCouncil"]) == "Yes")
                                {
                                    MSEFCCase_Filed_No.SelectedValue = "0";
                                    MSEFCCase_Filed_No.Enabled = false;
                                    MSEFCCase_Filed_No_SelectedIndexChanged(sender, e);
                                }
                                else
                                {
                                    MSEFCCase_Filed_No.SelectedValue = "1";
                                    MSEFCCase_Filed_No.Enabled = false;
                                    MSEFCCase_Filed_No_SelectedIndexChanged(sender, e);

                                }
                            }
                            ListItem GrFDptIssue_CaseunderMSME = MSEFCCase_Filed.Items.FindByText(Convert.ToString(dsdept.Tables[0].Rows[0]["GrFDptIssue_CaseunderMSME"]));
                            GrFDptIssue_CaseunderMSME.Selected = true;
                            MSEFCCase_Filed.Enabled = false;

                        }
                        else if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrT_SchemeType"]) == "PMEGP")
                        {
                            rblTechnSchms.SelectedValue = "4";
                            rblTechnSchms.Enabled = false;
                            rblTechnSchms_SelectedIndexChanged(sender, e);
                        }
                        else if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrT_SchemeType"]) == "PMFME")
                        {
                            rblTechnSchms.SelectedValue = "5";
                            rblTechnSchms.Enabled = false;
                            rblTechnSchms_SelectedIndexChanged(sender, e);
                        }
                        else if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrT_SchemeType"]) == "Udyam Registration")
                        {
                            rblTechnSchms.SelectedValue = "6";
                            rblTechnSchms.Enabled = false;
                            rblTechnSchms_SelectedIndexChanged(sender, e);
                        }
                        else if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrT_SchemeType"]) == "IE's/IL's")
                        {
                            rblTechnSchms.SelectedValue = "7";
                            rblTechnSchms.Enabled = false;
                            rblTechnSchms_SelectedIndexChanged(sender, e);
                        }
                        else if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrT_SchemeType"]) == "Others")
                        {
                            rblTechnSchms.SelectedValue = "8";
                            rblTechnSchms.Enabled = false;
                            rblTechnSchms_SelectedIndexChanged(sender, e);
                            txttechschmsothrs.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrT_OtherScheme"]);
                            txttechschmsothrs.Enabled = false;
                        }
                    }
                    else
                    {
                        chkTechnical.Checked = false;
                        chkTechnical.Enabled = false;
                    }


                    if (dsdept.Tables[0].Rows[0]["Gr_Marketing"].ToString() == "Yes")
                    {
                        chkMarketing.Checked = true;
                        chkMarketing.Enabled = false;
                        ListItem Brdgrvnc = rdboardgrivance.Items.FindByText("2.Marketing");
                        rdboardgrivance.Enabled = false;
                        Brdgrvnc.Selected = true;
                        rdboardgrivance_SelectedIndexChanged(sender, e);
                        chkMarketing_CheckedChanged(sender, e);

                        if (dsdept.Tables[0].Rows[0]["GrM_ECommerce"].ToString() == "Yes")
                        {
                            chkecommrce.Checked = true; chkecommrce_CheckedChanged(sender, e);
                            if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_Meesho"]) == "Yes")
                            {
                                rblMeesho.SelectedValue = "0";
                                rblMeesho.Enabled = false;
                                rblMeesho_SelectedIndexChanged(sender, e);
                                if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_MeeshorefbyOffcr"]) == "Yes")
                                {
                                    rblmeeshoofcrref.SelectedValue = "0";
                                    rblmeeshoofcrref.Enabled = false;
                                }
                                else
                                {
                                    rblmeeshoofcrref.SelectedValue = "1";
                                    rblmeeshoofcrref.Enabled = false;
                                }
                                if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_Meeshorefbycamp"]) == "Yes")
                                {
                                    rblMSaftrCamps.SelectedValue = "0";
                                    rblMSaftrCamps.Enabled = false;
                                    rblMSaftrCamps_SelectedIndexChanged(sender, e);
                                }
                                else
                                {
                                    rblMSaftrCamps.SelectedValue = "1";
                                    rblMSaftrCamps.Enabled = false;
                                    rblMSaftrCamps_SelectedIndexChanged(sender, e);
                                }
                                txtMScampdate.Text = Convert.ToDateTime(dsdept.Tables[0].Rows[0]["GrMEC_Meeshorefbycampdate"]).ToString("dd-MM-yyyy");
                                txtMScampdate.Enabled = false;
                                Meesho_Unique_ID.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_MeeshoId"]);
                                Meesho_Unique_ID.Enabled = false;
                                Meesho_Registration_Date.Value = Convert.ToDateTime(dsdept.Tables[0].Rows[0]["GrMEC_MeeshoRegDt"]).ToString("dd-MM-yyyy");
                                txtmeeshocount.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_MeeshoTranscount"]);
                                txtmeeshocount.Enabled = false;
                                txtmeeshovalue.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_MeeshoTransvalue"]);
                                txtmeeshovalue.Enabled = false;

                            }
                            else if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_Meesho"]) == "No")
                            {
                                if (Convert.ToString(Request.QueryString["Meesho"]) == "No")
                                { rblMeesho.Enabled = true; }
                                else { rblMeesho.Enabled = false; }
                                rblMeesho.SelectedValue = "1";

                                rblMeesho_SelectedIndexChanged(sender, e);

                                if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_MeeshoAwareness"]) == "Yes")
                                {
                                    Meesho_NO.SelectedValue = "0";
                                    Meesho_NO.Enabled = false;
                                    Meesho_NO_SelectedIndexChanged(sender, e);
                                    ListItem GrMEC_MeeshoAwareness = Meesho_NO.Items.FindByText(Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_MeeshoAwareness"]));
                                    GrMEC_MeeshoAwareness.Selected = true;
                                    Meesho_NO.Enabled = false;

                                    if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_MeeshoIntrsted"]) == "Yes")
                                    {
                                        rblMSintrsted.SelectedValue = "0";
                                        rblMSintrsted.Enabled = false;
                                        rblMSintrsted_SelectedIndexChanged(sender, e);
                                    }
                                    else
                                    {
                                        rblMSintrsted.SelectedValue = "0";
                                        rblMSintrsted.Enabled = false;
                                        rblMSintrsted_SelectedIndexChanged(sender, e);
                                    }
                                }
                            }
                            else if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_Meesho"]) == "NA")
                            {
                                rblMeesho.SelectedValue = "2";
                                rblMeesho.Enabled = false;
                                rblMeesho_SelectedIndexChanged(sender, e);

                            }

                            if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_JustDial"]) == "Yes")
                            {
                                rblJustDial.SelectedValue = "0";
                                rblJustDial.Enabled = false;
                                rblJustDial_SelectedIndexChanged(sender, e);
                                ListItem GrMEC_JustDialrefbyOffcr = rbljustdialofcrref.Items.FindByText(Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_JustDialrefbyOffcr"]));
                                GrMEC_JustDialrefbyOffcr.Selected = true;
                                rbljustdialofcrref.Enabled = false;
                                if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_JustDialrefbyOffcr"]) == "Yes")
                                {
                                    rbljustdialofcrref.SelectedValue = "0";
                                    rbljustdialofcrref.Enabled = false;
                                }
                                else
                                {
                                    rbljustdialofcrref.SelectedValue = "1";
                                    rbljustdialofcrref.Enabled = false;
                                }
                                if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_JustDialrefbycamp"]) == "Yes")
                                {
                                    rblJDaftrCamps.SelectedValue = "0";
                                    rblJDaftrCamps.Enabled = false;
                                }
                                else
                                {
                                    rblJDaftrCamps.SelectedValue = "1";
                                    rblJDaftrCamps.Enabled = false;
                                }
                                txtJDcampdate.Text = Convert.ToDateTime(dsdept.Tables[0].Rows[0]["GrMEC_JustDialrefbycampdate"]).ToString("dd-MM-yyyy");
                                txtJDcampdate.Enabled = false;
                                Just_Dial_ID.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_JustDialId"]);
                                Just_Dial_ID.Enabled = false;
                                Just_Dial_Registration_Date.Value = Convert.ToDateTime(dsdept.Tables[0].Rows[0]["GrMEC_JustDialRegDt"]).ToString("dd-MM-yyyy");
                                Just_Dial_Registration_Date.Disabled = true;
                                txtjstdialcount.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_JustDialTranscount"]);
                                txtjstdialcount.Enabled = false;
                            }
                            else if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_JustDial"]) == "No")
                            {
                                if (Convert.ToString(Request.QueryString["JustDial"]) == "No")
                                { rblJustDial.Enabled = true; }
                                else { rblJustDial.Enabled = false; }
                                rblJustDial.SelectedValue = "1";
                                rblJustDial_SelectedIndexChanged(sender, e);
                                ListItem GrMEC_JustDialAwareness = rbljustdialofcrref.Items.FindByText(Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_JustDialAwareness"]));
                                GrMEC_JustDialAwareness.Selected = true;
                                rbljustdialofcrref.Enabled = false;
                                if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_JustDialAwareness"]) == "Yes")
                                {
                                    JustDialNOBtn.SelectedValue = "0";
                                    JustDialNOBtn.Enabled = false;
                                    JustDialNOBtn_SelectedIndexChanged(sender, e);
                                    ListItem GrMEC_JustDialIntrsted = rbljustdialofcrref.Items.FindByText(Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_JustDialIntrsted"]));
                                    GrMEC_JustDialIntrsted.Selected = true;
                                    rbljustdialofcrref.Enabled = false;
                                    if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_JustDialIntrsted"]) == "Yes")
                                    {
                                        rblJDintrsted.SelectedValue = "0";
                                        rblJDintrsted.Enabled = false;
                                        rblJDintrsted_SelectedIndexChanged(sender, e);
                                    }
                                    else
                                    {
                                        rblJDintrsted.SelectedValue = "1";
                                        rblJDintrsted.Enabled = false;
                                        rblJDintrsted_SelectedIndexChanged(sender, e);
                                    }
                                }
                            }
                            else if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_JustDial"]) == "NA")
                            {
                                rblJustDial.SelectedValue = "2";
                                rblJustDial.Enabled = false;
                                rblJustDial_SelectedIndexChanged(sender, e);
                            }

                            if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_TSGlobal"]) == "Yes")
                            {
                                rblTSGlobal.SelectedValue = "0";
                                rblTSGlobal.Enabled = false;
                                rblTSGlobal_SelectedIndexChanged(sender, e);
                                if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_TSGlobalrefbyOffcr"]) == "Yes")
                                {
                                    rblTSGofcrref.SelectedValue = "0";
                                    rblTSGofcrref.Enabled = false;
                                }
                                else
                                {
                                    rblTSGofcrref.SelectedValue = "1";
                                    rblTSGofcrref.Enabled = false;
                                }

                                if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_TSGlobalrefbyOffcr"]) == "Yes")
                                {
                                    rblTSGaftrCamps.SelectedValue = "0";
                                    rblTSGaftrCamps.Enabled = false;
                                    rblTSGaftrCamps_SelectedIndexChanged(sender, e);
                                }
                                else
                                {
                                    rblTSGaftrCamps.SelectedValue = "1";
                                    rblTSGaftrCamps.Enabled = false;
                                    rblTSGaftrCamps_SelectedIndexChanged(sender, e);
                                }
                                txtTSGcampdate.Text = Convert.ToDateTime(dsdept.Tables[0].Rows[0]["GrMEC_TSGlobalrefbycampdate"]).ToString("dd-MM-yyyy");
                                txtTSGcampdate.Enabled = false;
                                TS_Global_UNIQUE_ID.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_TSGlobalId"]);
                                TS_Global_UNIQUE_ID.Enabled = false;
                                TS_Global_Registration_Date.Value = Convert.ToDateTime(dsdept.Tables[0].Rows[0]["GrMEC_TSGlobalRegDt"]).ToString("dd-MM-yyyy");
                                txttsglobalcount.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_TSGlobalTranscount"]);
                                txttsglobalcount.Enabled = false;
                                txttsglobalvalue.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_TSGlobalTransvalue"]);
                                txttsglobalvalue.Enabled = false;
                            }
                            else if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_TSGlobal"]) == "No")
                            {
                                if (Convert.ToString(Request.QueryString["TSGlobal"]) == "No")
                                { rblTSGlobal.Enabled = true; }
                                else { rblTSGlobal.Enabled = false; }
                                rblTSGlobal.SelectedValue = "1";
                                rblTSGlobal_SelectedIndexChanged(sender, e);
                                ListItem GrMEC_TSGlobalAwareness = TS_Global_NO_BTN.Items.FindByText(Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_TSGlobalAwareness"]));
                                GrMEC_TSGlobalAwareness.Selected = true;
                                TS_Global_NO_BTN.Enabled = false;
                                if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_TSGlobalAwareness"]) == "Yes")
                                {
                                    TS_Global_NO_BTN.SelectedValue = "0";
                                    TS_Global_NO_BTN.Enabled = false;
                                    TS_Global_NO_BTN_SelectedIndexChanged(sender, e);
                                    ListItem GrMEC_TSGlobalIntrsted = rblTSGintrsted.Items.FindByText(Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_TSGlobalIntrsted"]));
                                    GrMEC_TSGlobalIntrsted.Selected = true;
                                    rblTSGintrsted.Enabled = false;
                                    if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_TSGlobalIntrsted"]) == "Yes")
                                    {
                                        rblTSGintrsted.SelectedValue = "0";
                                        rblTSGintrsted.Enabled = false;
                                        rblTSGintrsted_SelectedIndexChanged(sender, e);
                                    }
                                    else
                                    {
                                        rblTSGintrsted.SelectedValue = "1";
                                        rblTSGintrsted.Enabled = false;
                                        rblTSGintrsted_SelectedIndexChanged(sender, e);
                                    }
                                }
                            }
                            else if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_TSGlobal"]) == "NA")
                            {
                                rblTSGlobal.SelectedValue = "2";
                                rblTSGlobal.Enabled = false;
                                rblTSGlobal_SelectedIndexChanged(sender, e);
                            }

                            if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_Wallmart"]) == "Yes")
                            {
                                rblWallmart.SelectedValue = "0";
                                rblWallmart_SelectedIndexChanged(sender, e);
                                if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_WallmartrefbyOffcr"]) == "Yes")
                                {
                                    rblwallmartofcrref.SelectedValue = "Yes";
                                    rblwallmartofcrref.Enabled = false;
                                }
                                else
                                {
                                    rblwallmartofcrref.SelectedValue = "No";
                                    rblwallmartofcrref.Enabled = false;
                                }

                                if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_Wallmartrefbycamp"]) == "Yes")
                                {
                                    rblWMVaftrCamps.SelectedValue = "0";
                                    rblWMVaftrCamps.Enabled = false;
                                    rblWMVaftrCamps_SelectedIndexChanged(sender, e);
                                }
                                else
                                {
                                    rblWMVaftrCamps.SelectedValue = "1";
                                    rblWMVaftrCamps.Enabled = false;
                                    rblWMVaftrCamps_SelectedIndexChanged(sender, e);

                                }
                                txtWMVcampdate.Text = Convert.ToDateTime(dsdept.Tables[0].Rows[0]["GrMEC_Wallmartrefbycampdate"]).ToString("dd-MM-yyyy");
                                txtWMVcampdate.Enabled = false;
                                Walmart_Vriddi_UNIQUE_ID.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_WallmartId"]);
                                Walmart_Vriddi_UNIQUE_ID.Enabled = false;
                                Walmart_Vriddi_Registration_Date.Value = Convert.ToDateTime(dsdept.Tables[0].Rows[0]["GrMEC_WallmartRegDt"]).ToString("dd-MM-yyyy");
                                Walmart_Vriddi_Registration_Date.Disabled = true;
                                txtwallmartcount.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_WallmartTranscount"]);
                                txtwallmartcount.Enabled = false;
                                txtwallmartvalue.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_WallmartTransvalue"]);
                                txtwallmartvalue.Enabled = false;
                            }
                            else if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_Wallmart"]) == "No")
                            {
                                if (Convert.ToString(Request.QueryString["TSGlobal"]) == "No")
                                { rblWallmart.Enabled = true; }
                                else { rblWallmart.Enabled = false; }
                                rblWallmart.SelectedValue = "1";
                                rblWallmart_SelectedIndexChanged(sender, e);
                                ListItem GrMEC_WallmartAwareness = rblwallmartofcrref.Items.FindByText(Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_WallmartAwareness"]));
                                GrMEC_WallmartAwareness.Selected = true;
                                rblwallmartofcrref.Enabled = false;
                                if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_WallmartAwareness"]) == "Yes")
                                {
                                    Walmart_Vriddi_NO_Btn.SelectedValue = "0";
                                    Walmart_Vriddi_NO_Btn.Enabled = false;
                                    Walmart_Vriddi_NO_Btn_SelectedIndexChanged(sender, e);
                                    ListItem GrMEC_WallmartIntrsted = rblWMVintrsted.Items.FindByText(Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_WallmartIntrsted"]));
                                    GrMEC_WallmartIntrsted.Selected = true;
                                    rblWMVintrsted.Enabled = false;

                                    if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_WallmartIntrsted"]) == "Yes")
                                    {
                                        rblWMVintrsted.SelectedValue = "0";
                                        rblWMVintrsted.Enabled = false;
                                        rblWMVintrsted_SelectedIndexChanged(sender, e);
                                    }
                                    else
                                    {
                                        rblWMVintrsted.SelectedValue = "1";
                                        rblWMVintrsted.Enabled = false;
                                        rblWMVintrsted_SelectedIndexChanged(sender, e);
                                    }
                                }
                            }
                            else if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMEC_Wallmart"]) == "NA")
                            {
                                rblWallmart.SelectedValue = "2";
                                rblWallmart.Enabled = false;
                                rblWallmart_SelectedIndexChanged(sender, e);
                            }
                        }
                        else
                        {
                            chkecommrce.Checked = false;
                        }
                        if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrM_OtherSchemes"]) == "Yes")
                        {
                            chkOtherSchms.Checked = true; chkOtherSchms_CheckedChanged(sender, e);
                            if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMOS_MarktngAsstScheme"]) == "Yes")
                            {
                                rblMAS.SelectedValue = "0";
                                rblMAS.Enabled = false;
                                rblMAS_SelectedIndexChanged(sender, e);
                                ListItem GrMOS_MASawarness = rblMASawrns.Items.FindByText(Convert.ToString(dsdept.Tables[0].Rows[0]["GrMOS_MASawarness"]));
                                GrMOS_MASawarness.Selected = true;
                                rblMASawrns.Enabled = false;
                                if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMOS_MASawarness"]) == "Yes")
                                {
                                    rblMASawrns.SelectedValue = "0";
                                    rblMASawrns.Enabled = false;
                                    rblMASawrns_SelectedIndexChanged(sender, e);
                                    ListItem GrMOS_MASinterested = rblMASintrsted.Items.FindByText(Convert.ToString(dsdept.Tables[0].Rows[0]["GrMOS_MASinterested"]));
                                    GrMOS_MASinterested.Selected = true;
                                    rblMASintrsted.Enabled = false;
                                    if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMOS_MASinterested"]) == "Yes")
                                    {
                                        rblMASintrsted.SelectedValue = "0";
                                        rblMASintrsted.Enabled = false;
                                        rblMASintrsted_SelectedIndexChanged(sender, e);

                                    }
                                    else
                                    {
                                        rblMASintrsted.SelectedValue = "1";
                                        rblMASintrsted.Enabled = false;
                                        rblMASintrsted_SelectedIndexChanged(sender, e);
                                    }
                                }


                            }
                            else
                            {
                                rblMAS.SelectedValue = "1";
                                rblMAS.Enabled = false;
                                rblMAS_SelectedIndexChanged(sender, e);

                            }
                            if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMOS_PandMS"]) == "Yes")
                            {
                                rblPMS.SelectedValue = "0";
                                rblPMS.Enabled = false;
                                rblPMS_SelectedIndexChanged(sender, e);
                                ListItem GrMOS_PandMSawarness = rblPMSawrns.Items.FindByText(Convert.ToString(dsdept.Tables[0].Rows[0]["GrMOS_PandMSawarness"]));
                                GrMOS_PandMSawarness.Selected = true;
                                rblPMSawrns.Enabled = false;
                                if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMOS_PandMSawarness"]) == "Yes")
                                {
                                    rblPMSawrns.SelectedValue = "0";
                                    rblPMSawrns.Enabled = false;
                                    rblPMSawrns_SelectedIndexChanged(sender, e);
                                    ListItem GrMOS_PandMSinterested = rblPMSawrns.Items.FindByText(Convert.ToString(dsdept.Tables[0].Rows[0]["GrMOS_PandMSinterested"]));
                                    GrMOS_PandMSinterested.Selected = true;
                                    rblPMSawrns.Enabled = false;
                                    if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMOS_PandMSinterested"]) == "Yes")
                                    {
                                        rblPMSintrsted.SelectedValue = "0";
                                        rblPMSintrsted.Enabled = false;
                                        rblPMSintrsted_SelectedIndexChanged(sender, e);
                                    }
                                    else
                                    {
                                        rblPMSintrsted.SelectedValue = "1";
                                        rblPMSintrsted.Enabled = false;
                                        rblPMSintrsted_SelectedIndexChanged(sender, e);
                                    }
                                }
                            }
                            else
                            {
                                rblPMS.SelectedValue = "1";
                                rblPMS.Enabled = false;
                                rblPMS_SelectedIndexChanged(sender, e);
                            }

                            if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMOS_SMAS"]) == "Yes")
                            {
                                rblSMAS.SelectedValue = "0";
                                rblSMAS.Enabled = false;
                                rblSMAS_SelectedIndexChanged(sender, e);
                                ListItem GrMOS_SMASawarness = rblSMASawrns.Items.FindByText(Convert.ToString(dsdept.Tables[0].Rows[0]["GrMOS_SMASawarness"]));
                                GrMOS_SMASawarness.Selected = true;
                                rblSMASawrns.Enabled = false;
                                if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMOS_SMASawarness"]) == "Yes")
                                {
                                    rblSMASawrns.SelectedValue = "0";
                                    rblSMASawrns.Enabled = false;
                                    rblSMASawrns_SelectedIndexChanged(sender, e);
                                    ListItem GrMOS_SMASinterested = rblSMASintrsted.Items.FindByText(Convert.ToString(dsdept.Tables[0].Rows[0]["GrMOS_SMASinterested"]));
                                    GrMOS_SMASinterested.Selected = true;
                                    rblSMASintrsted.Enabled = false;
                                    if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrMOS_SMASinterested"]) == "Yes")
                                    {
                                        rblSMASintrsted.SelectedValue = "0";
                                        rblSMASintrsted.Enabled = false;
                                        rblSMASintrsted_SelectedIndexChanged(sender, e);
                                    }
                                    else
                                    {
                                        rblSMASintrsted.SelectedValue = "1";
                                        rblSMASintrsted.Enabled = false;
                                        rblSMASintrsted_SelectedIndexChanged(sender, e);
                                    }
                                }
                            }
                            else
                            {
                                rblSMAS.SelectedValue = "1";
                                rblSMAS.Enabled = false;
                                rblSMAS_SelectedIndexChanged(sender, e);
                            }
                        }
                        else
                        {
                            chkOtherSchms.Checked = false;
                        }
                        if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrM_Others"]) == "Yes")
                        {
                            chkmrkOthrs.Checked = true;
                            chkmrkOthrs.Enabled = false;
                            chkmrkOthrs_CheckedChanged(sender, e);
                            Marketing_Others_Text_Box.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrM_OthersDetails"]);
                        }
                        else
                        {
                            chkmrkOthrs.Checked = false;
                            chkmrkOthrs_CheckedChanged(sender, e);
                        }
                    }
                    else
                    {
                        chkMarketing.Checked = false;
                        chkMarketing.Enabled = false;
                    }

                    if (dsdept.Tables[0].Rows[0]["Gr_Financial"].ToString() == "Yes")
                    {
                        ListItem Brdgrvnc = rdboardgrivance.Items.FindByText("3.Financial");
                        Brdgrvnc.Selected = true;
                        rdboardgrivance.Enabled = false;
                        chkFinancial.Checked = true;
                        chkFinancial.Enabled = false;
                        chkFinancial_CheckedChanged(sender, e);

                        if (dsdept.Tables[0].Rows[0]["GrF_Type"].ToString() == "Online Platforms")
                        {
                            chckonlineplatforms.Checked = true;
                            chckonlineplatforms.Enabled = false;
                            chckonlineplatforms_CheckedChanged(sender, e);
                            ListItem GrFOLP_InvoiceMart = Invoice_Mart.Items.FindByText(Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_InvoiceMart"]));
                            GrFOLP_InvoiceMart.Selected = true;

                            if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_InvoiceMart"]) == "Yes")
                            {
                                Invoice_Mart.SelectedValue = "0";
                                Invoice_Mart.Enabled = false;
                                Invoice_Mart_SelectedIndexChanged(sender, e);
                                ListItem GrFOLP_InvoiceMartrefbyOffcr = rblIMofcrref.Items.FindByText(Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_InvoiceMartrefbyOffcr"]));
                                GrFOLP_InvoiceMartrefbyOffcr.Selected = true;
                                rblIMofcrref.Enabled = false;

                                if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_InvoiceMartrefbycamp"]) == "Yes")
                                {
                                    rblIMaftrCamps.SelectedValue = "0";
                                    rblIMaftrCamps.Enabled = false;
                                    rblIMaftrCamps_SelectedIndexChanged(sender, e);
                                }
                                else
                                {
                                    rblIMaftrCamps.SelectedValue = "1";
                                    rblIMaftrCamps.Enabled = false;
                                    rblIMaftrCamps_SelectedIndexChanged(sender, e);
                                }
                                txtIMcampdate.Text = Convert.ToDateTime(dsdept.Tables[0].Rows[0]["GrFOLP_InvoiceMartrefbycampdate"]).ToString("dd-MM-yyyy");
                                txtIMcampdate.Enabled = false;
                                InvoiceMartID.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_InvoiceMartID"]);
                                InvoiceMartID.Enabled = false;
                                INVOICE_MART_Registration_DATE.Value = Convert.ToDateTime(dsdept.Tables[0].Rows[0]["GrFOLP_InvoiceMartRegDt"]).ToString("dd-MM-yyyy");
                                INVOICE_MART_Registration_DATE.Disabled = true;
                                No_of_Orders_received_Invoice_Mart.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_InvoiceMartOrdrsRcvdCount"]);
                                No_of_Orders_received_Invoice_Mart.Enabled = false;
                                Order_Value_Invoice_Mart.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_InvoiceMartOrdrsRcvdCost"]);
                                Order_Value_Invoice_Mart.Enabled = false;
                                No_of_Bills_Invoice_Mart.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_InvoiceMartBlsUploadedCount"]);
                                No_of_Bills_Invoice_Mart.Enabled = false;
                                Bills_Value_Invoice_Mart.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_InvoiceMartBlsUploadedCost"]);
                                Bills_Value_Invoice_Mart.Enabled = false;
                                No_of_Bills_Sold_Invoice_Mart.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_InvoiceMartBlsSoldCount"]);
                                No_of_Bills_Sold_Invoice_Mart.Enabled = false;
                            }
                            else if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_InvoiceMart"]) == "No")
                            {
                                Invoice_Mart.SelectedValue = "1";
                                if (Convert.ToString(Request.QueryString["InvoiceMart"]) == "No")
                                { Invoice_Mart.Enabled = true; }
                                else { Invoice_Mart.Enabled = false; }
                                Invoice_Mart_SelectedIndexChanged(sender, e);
                                ListItem GrFOLP_InvoiceMartAwrnsgvn = rblIMawrns.Items.FindByText(Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_InvoiceMartAwrnsgvn"]));
                                GrFOLP_InvoiceMartAwrnsgvn.Selected = true;
                                rblIMawrns.Enabled = false;
                                if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_InvoiceMartAwrnsgvn"]) == "Yes")
                                {
                                    rblIMawrns.SelectedValue = "0";
                                    rblIMawrns.Enabled = false;
                                    rblIMawrns_SelectedIndexChanged(sender, e);
                                    if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_InvoiceMartIntrsted"]) == "Yes")
                                    {
                                        rblIMintrsted.SelectedValue = "0";
                                        rblIMintrsted.Enabled = false;
                                    }
                                    else
                                    {
                                        rblIMintrsted.SelectedValue = "1";
                                        rblIMintrsted.Enabled = false;
                                    }
                                }
                            }
                            else if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_InvoiceMart"]) == "NA")
                            {
                                Invoice_Mart.SelectedValue = "2";
                                Invoice_Mart.Enabled = false;
                                Invoice_Mart_SelectedIndexChanged(sender, e);
                            }

                            if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_NSE"]) == "Yes")
                            {
                                NSE.SelectedValue = "0";
                                NSE.Enabled = false;
                                NSE_SelectedIndexChanged(sender, e);
                                if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_NSErefbyOffcr"]) == "Yes")
                                {
                                    rblNSEofcrref.SelectedValue = "0";
                                    rblNSEofcrref.Enabled = false;
                                }
                                else
                                {
                                    rblNSEofcrref.SelectedValue = "1";
                                    rblNSEofcrref.Enabled = false;
                                }

                                if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_NSErefbycamp"]) == "Yes")
                                {
                                    rblNSEaftrCamps.SelectedValue = "0";
                                    rblNSEaftrCamps.Enabled = false;
                                    rblNSEaftrCamps_SelectedIndexChanged(sender, e);
                                    txtNSEcampdate.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_NSErefbycampdate"]);
                                    txtNSEcampdate.Enabled = false;
                                }
                                else
                                {
                                    rblNSEaftrCamps.SelectedValue = "1";
                                    rblNSEaftrCamps.Enabled = false;
                                    rblNSEaftrCamps_SelectedIndexChanged(sender, e);

                                }
                                if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_NSEFiled"]) == "Yes")
                                {
                                    rblNSEFiled.SelectedValue = "0";
                                    rblNSEFiled.Enabled = false;
                                }
                                else
                                {
                                    rblNSEFiled.SelectedValue = "1";
                                    rblNSEFiled.Enabled = false;
                                }
                                if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_NSEListedAbout"]) == "Yes")
                                {
                                    rblNSElisted.SelectedValue = "0";
                                    rblNSElisted.Enabled = false;
                                }
                                else
                                {
                                    rblNSElisted.SelectedValue = "1";
                                    rblNSElisted.Enabled = false;

                                }
                                if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_NSEAudit"]) == "Yes")
                                {
                                    rblNSEAudit.SelectedValue = "0";
                                    rblNSEAudit.Enabled = false;
                                }
                                else
                                {
                                    rblNSEAudit.SelectedValue = "1";
                                    rblNSEAudit.Enabled = false;
                                }
                            }
                            else if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_NSE"]) == "No")
                            {
                                if (Convert.ToString(Request.QueryString["NSE"]) == "No")
                                { NSE.Enabled = true; }
                                else { NSE.Enabled = false; }
                                NSE.SelectedValue = "1";

                                NSE_SelectedIndexChanged(sender, e);
                                ListItem GrFOLP_NSEAwarnessgiven = rblNSEawrns.Items.FindByText(Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_NSEAwarnessgiven"]));
                                GrFOLP_NSEAwarnessgiven.Selected = true;
                                rblNSEawrns.Enabled = false;
                                if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_NSEAwarnessgiven"]) == "Yes")
                                {
                                    rblNSEawrns.SelectedValue = "0";
                                    rblNSEawrns.Enabled = false;
                                    rblNSEawrns_SelectedIndexChanged(sender, e);
                                    if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_NSEIntrsted"]) == "Yes")
                                    {
                                        rblNSEintrsted.SelectedValue = "0";
                                        rblNSEintrsted.Enabled = false;
                                    }
                                    else
                                    {
                                        rblNSEintrsted.SelectedValue = "1";
                                        rblNSEintrsted.Enabled = false;
                                    }
                                }
                            }
                            else if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_NSE"]) == "NA")
                            {
                                NSE.SelectedValue = "2";
                                NSE.Enabled = false;
                                NSE_SelectedIndexChanged(sender, e);
                            }
                        }
                        else
                        {
                            chckonlineplatforms.Checked = false;
                            chckonlineplatforms.Enabled = false;
                            chckonlineplatforms_CheckedChanged(sender, e);
                        }
                        if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrF_Type_Others"]) == "Yes")
                        {
                            chckfinothers.Checked = true;
                            chckfinothers.Enabled = false;
                            chckfinothers_CheckedChanged(sender, e);
                            txtFinancialOthers.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrF_Others"]);
                            txtFinancialOthers.Enabled = false;
                        }
                        else
                        {
                            chckfinothers.Checked = false;
                            chckfinothers.Enabled = false;
                            chckfinothers_CheckedChanged(sender, e);
                        }
                    }
                    else
                    {
                        chkFinancial.Checked = false;
                        chkFinancial.Enabled = false;
                    }

                    //SIDBI.SelectedItem.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_SIDBI"]);
                    //rblSIDBIofcrref.SelectedItem.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_SIDBIrefbyOffcr"]);
                    //rblSIDBIaftrCamps.SelectedItem.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_SIDBIrefbycamp"]);
                    //txtSIDBIcampdate.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_SIDBIrefbycampdate"]);
                    //rblSIDBIawrns.SelectedItem.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_SIDBIAwarnessgiven"]);
                    //rblSIDBIintrsted.SelectedItem.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrFOLP_SIDBIntrsted"]);

                    if (dsdept.Tables[0].Rows[0]["Gr_Land"].ToString() == "Yes")
                    {
                        ListItem Brdgrvnc = rdboardgrivance.Items.FindByText("4.Land");
                        Brdgrvnc.Selected = true;
                        rdboardgrivance.Enabled = false;
                        chkLand.Checked = true;
                        chkLand.Enabled = false;
                        chkLand_CheckedChanged(sender, e);
                        txtLand.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["InteractionType"]);
                        txtLand.Enabled = false;

                        if (Convert.ToString(dsdept.Tables[0].Rows[0]["GrL_Type"]) == "TSIIC Land")
                        {
                            Land_Grievance.SelectedValue = "0";
                            Land_Grievance.Enabled = false;
                            Land_Grievance_SelectedIndexChanged(sender, e);
                        }
                        else
                        {
                            Land_Grievance.SelectedValue = "1";
                            Land_Grievance.Enabled = false;
                            Land_Grievance_SelectedIndexChanged(sender, e);
                            TextBox1.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrL_Others"]);
                            TextBox1.Enabled = false;
                        }
                    }
                    else
                    {
                        chkLand.Checked = false;
                        chkLand.Enabled = false;
                    }

                    if (dsdept.Tables[0].Rows[0]["Gr_Others"].ToString() == "Yes")
                    {
                        ListItem Brdgrvnc = rdboardgrivance.Items.FindByText("5.Others");
                        Brdgrvnc.Selected = true;
                        rdboardgrivance.Enabled = false;
                        chkOthers.Checked = true;
                        chkOthers.Enabled = false;
                        chkOthers_CheckedChanged(sender, e);
                        TextBox2.Text = Convert.ToString(dsdept.Tables[0].Rows[0]["GrOthersDetails"]);
                        TextBox2.Enabled = false;
                    }
                    else
                    {
                        chkOthers.Checked = false;
                        chkOthers.Enabled = false;
                    }

                }
            }

        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;

        }
    }
    ////private void Grievance_Types()
    ////{
    ////    try
    ////    {
    ////        DataTable dataTable = new DataTable();
    ////        con.OpenConnection();
    ////        {
    ////            using (SqlCommand command = new SqlCommand("GetGrievancetype", con.GetConnection))
    ////            {
    ////                command.CommandType = CommandType.StoredProcedure;

    ////                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
    ////                {
    ////                    adapter.Fill(dataTable);
    ////                    TypeOfGrievance.DataSource = dataTable;
    ////                    TypeOfGrievance.DataTextField = "GrievanceType";
    ////                    TypeOfGrievance.DataValueField = "ID";
    ////                    TypeOfGrievance.DataBind();
    ////                }
    ////                con.CloseConnection();
    ////            }
    ////        }
    ////    }
    ////    catch (Exception ex)
    ////    { lblmsg0.Text = ex.Message;  Failure.Visible = true; }
    ////}
    private void Marketing_Grievance()
    {
        try
        {
            DataTable dataTable = new DataTable();
            con.OpenConnection();
            {
                using (SqlCommand command = new SqlCommand("GetMarketingGrievancetypes", con.GetConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                        ////dataTable.Rows.InsertAt(dataTable.NewRow(), 0);
                        ////dataTable.Rows[0]["Id"] = 0;
                        ////dataTable.Rows[0]["MarketingType"] = "--Select--";
                        Marketing_Types.DataSource = dataTable;
                        Marketing_Types.DataTextField = "MarketingType";
                        Marketing_Types.DataValueField = "ID";
                        Marketing_Types.DataBind();
                    }
                    con.CloseConnection();
                }
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void Financial_Grievance()
    {
        try
        {
            DataTable dataTable = new DataTable();
            con.OpenConnection();
            {
                using (SqlCommand command = new SqlCommand("GetFinancialGrievancetypes", con.GetConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                        dataTable.Rows.InsertAt(dataTable.NewRow(), 0);
                        dataTable.Rows[0]["Id"] = 0;
                        dataTable.Rows[0]["FinancialType"] = "--Select--";
                        Financial_Types.DataSource = dataTable;
                        Financial_Types.DataTextField = "FinancialType";
                        Financial_Types.DataValueField = "ID";
                        Financial_Types.DataBind();
                    }
                    con.CloseConnection();
                }
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    //private void Marketing_Schemes_Types()
    //{
    //    try
    //    {
    //        DataTable dataTable = new DataTable();
    //        con.OpenConnection();
    //        {
    //            using (SqlCommand command = new SqlCommand("GetOtherSchemestypes", con.GetConnection))
    //            {
    //                command.CommandType = CommandType.StoredProcedure;

    //                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
    //                {
    //                    adapter.Fill(dataTable);
    //                    OtherSchemesChkList.DataSource = dataTable;
    //                    OtherSchemesChkList.DataTextField = "OtherScheme";
    //                    OtherSchemesChkList.DataValueField = "ID";
    //                    OtherSchemesChkList.DataBind();
    //                }
    //                con.CloseConnection();
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    { lblmsg0.Text = ex.Message;  Failure.Visible = true; }
    //}
    private void MEESHO_Platform_Details()
    {
        try
        {
            DataTable dataTable = new DataTable();
            con.OpenConnection();
            {
                using (SqlCommand command = new SqlCommand("GetMeeshowBenifits", con.GetConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                        Meesho_Awareness_No_List.DataSource = dataTable;
                        Meesho_Awareness_No_List.DataTextField = "MeeshowBenifits";
                        Meesho_Awareness_No_List.DataValueField = "ID";
                        Meesho_Awareness_No_List.DataBind();
                    }
                    con.CloseConnection();
                }
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void JUST_DIAL_Platform_Details()
    {
        try
        {
            DataTable dataTable = new DataTable();
            con.OpenConnection();
            {
                using (SqlCommand command = new SqlCommand("GetJustDialBenifits", con.GetConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                        Just_Dial_Awareness_No_List.DataSource = dataTable;
                        Just_Dial_Awareness_No_List.DataTextField = "JustDialBenifits";
                        Just_Dial_Awareness_No_List.DataValueField = "ID";
                        Just_Dial_Awareness_No_List.DataBind();
                    }
                    con.CloseConnection();
                }
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void TS_GLOBAL_Platform_Details()
    {
        try
        {
            DataTable dataTable = new DataTable();
            con.OpenConnection();
            {
                using (SqlCommand command = new SqlCommand("GetTSGlobalLinkerBenifits", con.GetConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                        TS_GLOBAL_DETAILS_LIST.DataSource = dataTable;
                        TS_GLOBAL_DETAILS_LIST.DataTextField = "TSGLBenifits";
                        TS_GLOBAL_DETAILS_LIST.DataValueField = "ID";
                        TS_GLOBAL_DETAILS_LIST.DataBind();
                    }
                    con.CloseConnection();
                }
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void WALMART_VRIDDI_Platform_Details()
    {
        try
        {
            DataTable dataTable = new DataTable();
            con.OpenConnection();
            {
                using (SqlCommand command = new SqlCommand("GetWallmartVriddiBenifits", con.GetConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                        WALMART_VRIDDI_DETAILS_LIST.DataSource = dataTable;
                        WALMART_VRIDDI_DETAILS_LIST.DataTextField = "WVBenifits";
                        WALMART_VRIDDI_DETAILS_LIST.DataValueField = "ID";
                        WALMART_VRIDDI_DETAILS_LIST.DataBind();
                    }
                    con.CloseConnection();
                }
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void Marketing_Assistance_Scheme_Details()
    {
        try
        {
            DataTable dataTable = new DataTable();
            con.OpenConnection();
            {
                using (SqlCommand command = new SqlCommand("GetMASBenifits", con.GetConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                        BulletedList1.DataSource = dataTable;
                        BulletedList1.DataTextField = "MASBenefits";
                        BulletedList1.DataValueField = "ID";
                        BulletedList1.DataBind();
                    }
                    con.CloseConnection();
                }
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void Schemes_PMS_Details()
    {
        try
        {
            DataTable dataTable = new DataTable();
            con.OpenConnection();
            {
                using (SqlCommand command = new SqlCommand("GetPMSBenifits", con.GetConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                        BulletedList2.DataSource = dataTable;
                        BulletedList2.DataTextField = "PMSBenefits";
                        BulletedList2.DataValueField = "ID";
                        BulletedList2.DataBind();
                    }
                    con.CloseConnection();
                }
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void Scheme_SMAS_Details()
    {
        try
        {
            DataTable dataTable = new DataTable();
            con.OpenConnection();
            {
                using (SqlCommand command = new SqlCommand("GetSMASBenifits", con.GetConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                        BulletedList3.DataSource = dataTable;
                        BulletedList3.DataTextField = "SMASBenefits";
                        BulletedList3.DataValueField = "ID";
                        BulletedList3.DataBind();
                    }
                    con.CloseConnection();
                }
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void Grievance_Status_Dropdown()
    {
        try
        {
            DataTable dataTable = new DataTable();
            con.OpenConnection();
            {
                using (SqlCommand command = new SqlCommand("GetGrievanceStatus", con.GetConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (Session["Role_Code"] != null)
                    {
                        string roleCode = Session["Role_Code"].ToString().TrimEnd();
                        command.Parameters.Add(new SqlParameter("@RoleCode", SqlDbType.VarChar, 50)).Value = roleCode;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                            dataTable.Rows.InsertAt(dataTable.NewRow(), 0);
                            dataTable.Rows[0]["Id"] = 0;
                            dataTable.Rows[0]["GrStatusType"] = "--Select--";
                            GrievanceStatus_dropdown.DataSource = dataTable;
                            GrievanceStatus_dropdown.DataTextField = "GrStatusType";
                            GrievanceStatus_dropdown.DataValueField = "ID";
                            GrievanceStatus_dropdown.DataBind();
                        }
                    }
                    else
                    {
                        Response.Redirect("~/tsHome.aspx");
                    }
                    con.CloseConnection();
                }
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void Mandal_List()
    {
        try
        {
            DataTable dataTable = new DataTable();
            con.OpenConnection();
            {
                using (SqlCommand command = new SqlCommand("GETMandal_EXISTING_ENTREPRENEURS", con.GetConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    int district = Convert.ToInt32(Session["DistrictID"].ToString().TrimEnd());
                    command.Parameters.Add(new SqlParameter("@District_ID", SqlDbType.Int)).Value = district;


                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                        dataTable.Rows.InsertAt(dataTable.NewRow(), 0);
                        dataTable.Rows[0]["Manda_lName"] = "--Select--";
                        ddl_Mandal.DataSource = dataTable;
                        ddl_Mandal.DataTextField = "Manda_lName";
                        ddl_Mandal.DataValueField = "Mandal_Id";
                        ddl_Mandal.DataBind();
                        //DropDownList1.DataSource = dataTable;
                        //DropDownList1.DataTextField = "Manda_lName";
                        //DropDownList1.DataValueField = "Mandal_Id";
                        //DropDownList1.DataBind();



                    }
                    con.CloseConnection();
                }
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void UID_Mandal_List()
    {
        DataTable dataTable = new DataTable();
        con.OpenConnection();
        {
            using (SqlCommand command = new SqlCommand("GetMandals", con.GetConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                int district = Convert.ToInt32(Session["DistrictID"].ToString().TrimEnd());
                command.Parameters.Add(new SqlParameter("@intDistrictid", SqlDbType.Int)).Value = district;


                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                    dataTable.Rows.InsertAt(dataTable.NewRow(), 0);
                    dataTable.Rows[0]["Manda_lName"] = "--Select--";
                    DropDownList1.DataSource = dataTable;
                    DropDownList1.DataTextField = "Manda_lName";
                    DropDownList1.DataValueField = "Mandal_Id";
                    DropDownList1.DataBind();
                    ddladrsmandal.DataSource = dataTable;
                    ddladrsmandal.DataTextField = "Manda_lName";
                    ddladrsmandal.DataValueField = "Mandal_Id";
                    ddladrsmandal.DataBind();
                }
                con.CloseConnection();
            }
        }
    }
    private DataTable UID_Village_List(int mandalid)
    {
        try
        {
            DataTable VillagedataTable = new DataTable();
            con.OpenConnection();
            {
                using (SqlCommand command = new SqlCommand("GETVillage_EXISTING_ENTREPRENEURS", con.GetConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Mandal_ID", mandalid);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(VillagedataTable);
                        VillagedataTable.Rows.InsertAt(VillagedataTable.NewRow(), 0);
                        VillagedataTable.Rows[0]["village_name"] = "--Select--";

                        //DropDownList2.DataSource = VillagedataTable;
                        //DropDownList2.DataTextField = "village_name";
                        //DropDownList2.DataValueField = "Village_Id";
                        //DropDownList2.DataBind();
                    }
                    con.CloseConnection();
                }
            }
            return VillagedataTable;
        }
        catch (Exception ex) { throw ex; }
    }
    private void Social_Category_Types()
    {
        try
        {
            DataTable dataTable = new DataTable();
            con.OpenConnection();
            {
                using (SqlCommand command = new SqlCommand("getsocialcategorylist", con.GetConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                        dataTable.Rows.InsertAt(dataTable.NewRow(), 0);
                        dataTable.Rows.InsertAt(dataTable.NewRow(), 6);
                        dataTable.Rows[0]["Caste_Name"] = "--Select--";
                        dataTable.Rows[6]["Caste_Name"] = "Minority";
                        Applicant_caste.DataSource = dataTable;
                        Applicant_caste.DataTextField = "Caste_Name";
                        Applicant_caste.DataBind();
                    }
                    con.CloseConnection();
                }
            }
        }
        catch (Exception ex) { throw ex; }
    }
    private void Sector_Name_Details()
    {
        try
        {
            DataTable dataTable = new DataTable();
            con.OpenConnection();
            {
                using (SqlCommand command = new SqlCommand("getSectorNames_LOA", con.GetConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                        dataTable.Rows.InsertAt(dataTable.NewRow(), 0);
                        dataTable.Rows[0]["LineofActivity_Name"] = "--Select--";
                        sector_dropdown.DataSource = dataTable;
                        sector_dropdown.DataTextField = "LineofActivity_Name";
                        sector_dropdown.DataValueField = "intLineofActivityid";
                        sector_dropdown.DataBind();
                    }
                    con.CloseConnection();
                }
            }
        }
        catch (Exception ex) { throw ex; }
    }
    private void Line_Department_List()
    {
        try
        {
            DataTable dataTable = new DataTable();
            con.OpenConnection();
            {
                using (SqlCommand command = new SqlCommand("getLineDepartments", con.GetConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                        dataTable.Rows.InsertAt(dataTable.NewRow(), 0);
                        dataTable.Rows[0]["Dept_Full_name"] = "--Select--";
                        ddlLineDepartment.DataSource = dataTable;
                        ddlLineDepartment.DataTextField = "Dept_Full_name";
                        ddlLineDepartment.DataBind();
                    }
                    con.CloseConnection();
                }
            }
        }
        catch (Exception ex) { throw ex; }
    }

    //private void GeneratePlatformTable()
    //{
    //    DataTable dataTable = ECOMMERCE_PLATFORM_LIST();

    //    if (dataTable != null && dataTable.Rows.Count > 0)
    //    {
    //        Table platformTable = new Table();

    //        for (int i = 0; i < dataTable.Rows.Count; i++)
    //        {
    //            DataRow row = dataTable.Rows[i];

    //            TableRow tableRow = new TableRow();

    //            TableCell idCell = new TableCell();
    //            idCell.Text = row["ID"].ToString();
    //            idCell.CssClass = "platform-id-cell";

    //            TableCell platformNameCell = new TableCell();
    //            platformNameCell.Text = row["PlatformName"].ToString();
    //            platformNameCell.CssClass = "platform-name-cell";

    //            TableCell yesCell = new TableCell();
    //            TableCell noCell = new TableCell();

    //            RadioButton radioButtonYes = new RadioButton();
    //            radioButtonYes.ID = "RadioButtonYes_" + i;
    //            radioButtonYes.Text = "Yes";
    //            radioButtonYes.GroupName = "PlatformGroup_" + i;
    //            radioButtonYes.AutoPostBack = true;
    //            radioButtonYes.CheckedChanged += new EventHandler((sender, e) => RadioButtonYes_CheckedChanged(sender, e, idCell.Text));
    //            radioButtonYes.CssClass = "platform-name-cell";

    //            RadioButton radioButtonNo = new RadioButton();
    //            radioButtonNo.ID = "RadioButtonNo_" + i;
    //            radioButtonNo.Text = "No";
    //            radioButtonNo.GroupName = "PlatformGroup_" + i;
    //            radioButtonNo.AutoPostBack = true;
    //            radioButtonNo.CheckedChanged += new EventHandler((sender, e) => RadioButtonNo_CheckedChanged(sender, e, idCell.Text));

    //            yesCell.Controls.Add(radioButtonYes);
    //            noCell.Controls.Add(radioButtonNo);

    //            tableRow.Cells.Add(idCell);
    //            tableRow.Cells.Add(platformNameCell);
    //            tableRow.Cells.Add(yesCell);
    //            tableRow.Cells.Add(noCell);

    //            platformTable.Rows.Add(tableRow);
    //        }
    //        PlatformTablePlaceholder.Controls.Add(platformTable);
    //    }
    //}
    //private DataTable ECOMMERCE_PLATFORM_LIST()
    //{
    //    DataTable dataTable = new DataTable();
    //    con.OpenConnection();
    //    dataTable.Columns.Add("SelectedOption", typeof(string));

    //    using (SqlCommand command = new SqlCommand("GetEcommercePlatformtypes", con.GetConnection))
    //    {
    //        command.CommandType = CommandType.StoredProcedure;

    //        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
    //        {
    //            adapter.Fill(dataTable);
    //        }
    //        con.CloseConnection();
    //    }
    //    return dataTable;
    //}
    protected void Women_Cell_SelectedIndexChanged(object sender, EventArgs e)
    {
        string Gender = Convert.ToString(ViewState["Gender"]);
        if (Women_Cell.SelectedValue == "0" || Gender == "FEMALE" || Applicant_Gender.Text == "Female")
        { trwehub.Visible = true; }
        if (Women_Cell.SelectedValue == "0")
        {
            Interaction_Id.Visible = true;
        }
        else
        {
            trwehub.Visible = false;
            chkwehub.Checked = false;
            Interaction_Id.Visible = false;
            Interaction_Block.Visible = false;
            Interaction_Level_Existing.ClearSelection();
            Interaction_block_District.Visible = false;
            Interaction_Date.Value = "";
            Interaction_Venue.Text = "";
            ddl_Mandal.ClearSelection();
            Text1.Value = "";
            TextBox4.Text = "";

        }
        //if (Women_Cell.SelectedValue == "1")
        //{ tronlydate.Visible = true; }

    }
    protected void Interaction_Level_Existing_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Interaction_Level_Existing.SelectedValue == "0")
        {
            Interaction_block_District.Visible = true;
            Interaction_Date.Value = "";
            Interaction_Venue.Text = "";
            ddl_Mandal.ClearSelection();
            ddlvenuemandl.ClearSelection(); ddlvenuemandl_SelectedIndexChanged(sender, e);
        }
        else
        {
            Interaction_block_District.Visible = false;
            Text1.Value = "";
            TextBox4.Text = "";
        }
        if (Interaction_Level_Existing.SelectedValue == "1")
        {
            Interaction_Block.Visible = true;
            Text1.Value = "";
            TextBox4.Text = "";

        }
        else
        {
            Interaction_Block.Visible = false;
            Interaction_Date.Value = "";
            Interaction_Venue.Text = "";
            ddl_Mandal.ClearSelection();
            ddlvenuemandl.ClearSelection();
        }
    }
    protected void ddl_Mandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Village_List();
    }
    protected void ddlvenuemandl_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlvenuemandl.SelectedItem.Text == "Others")
            {
                lblothrvenue.Visible = true;
                Interaction_Venue.Visible = true;
            }
            else
            {
                lblothrvenue.Visible = false;
                Interaction_Venue.Visible = false;
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void TS_IPASS_REGISTERED_Unit_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (TS_IPASS_REGISTERED_Unit.SelectedValue == "0")
        {

            TS_IPASS_SEARCH_BLOCK.Visible = true;
            trmsmeqsn.Visible = false; rblMSMEreg.ClearSelection();

            trmsmeunits.Visible = false; ddlmapunits.ClearSelection();
            Applicant_Name.Text = "";
            // Applicant_Address.Text = "";
            ddladrsmandal.ClearSelection(); ddladrsmandal_SelectedIndexChanged(sender, e);
            ddladrsvlg.ClearSelection(); ddladrsvlg.Enabled = false;
            //ddladrsvlg.Items.Clear;
            Applicant_Contact.Text = "";
            Applicant_Email.Text = "";
            Applicant_caste.ClearSelection();
            Applicant_Gender.ClearSelection(); Applicant_Gender_SelectedIndexChanged(sender, e);
            Differently_able.ClearSelection();
            Applicant_Investment.Text = "";
            Applicant_Employees.Text = "";
            sector_dropdown.ClearSelection();
            Enterprise_Sector.ClearSelection();
            if (rdboardgrivance.SelectedIndex != -1)
            {
                chkMarketing.Checked = false; chkMarketing_CheckedChanged(sender, e);
                chkFinancial.Checked = false; chkFinancial_CheckedChanged(sender, e);
                chkTechnical.Checked = false; chkTechnical_CheckedChanged(sender, e);
                chkLand.Checked = false; chkLand_CheckedChanged(sender, e);
                chkOthers.Checked = false; chkOthers_CheckedChanged(sender, e);
            }
            if (Women_Cell.SelectedIndex == 0 || Convert.ToString(ViewState["Gender"]) == "FEMALE" || Applicant_Gender.SelectedIndex == 1)
            { trwehub.Visible = true; }
            if (Women_Cell.SelectedIndex != 0 && Convert.ToString(ViewState["Gender"]) != "FEMALE" && Applicant_Gender.SelectedIndex != 1)
            { trwehub.Visible = false; }
        }
        else
        {
            TS_IPASS_SEARCH_BLOCK.Visible = false;
            UID_SEARCHGRID.Visible = false;
            ViewState["UIDNO"] = "";

            Financial_Grievance();
        }
        if (TS_IPASS_REGISTERED_Unit.SelectedValue == "1")
        {
            //Grievance_Identified.Enabled = true;
            TS_IPASS_REGISTRATION.Visible = true;
            trmsmeqsn.Visible = true; rblMSMEreg.ClearSelection();
            trmsmeunits.Visible = false; ddlmapunits.ClearSelection();
            //rblMSMEreg_SelectedIndexChanged(sender, e); 
            ddlmapunits.ClearSelection();
            DropDownList1.ClearSelection();
            DropDownList2.ClearSelection();
            TS_IPASS_UID_SEARCH.Text = ""; ViewState["Gender"] = ""; ViewState["UIDNO"] = "";
            if (Women_Cell.SelectedIndex == 0 || Convert.ToString(ViewState["Gender"]) == "FEMALE" || Applicant_Gender.SelectedIndex == 1)
            { trwehub.Visible = true; }
            if (Women_Cell.SelectedIndex != 0 && Convert.ToString(ViewState["Gender"]) != "FEMALE" && Applicant_Gender.SelectedIndex != 1)
            { trwehub.Visible = false; }
            Financial_Grievance();
            if (rdboardgrivance.SelectedIndex != -1)
            {
                chkMarketing.Checked = false; chkMarketing_CheckedChanged(sender, e);
                chkFinancial.Checked = false; chkFinancial_CheckedChanged(sender, e);
                chkTechnical.Checked = false; chkTechnical_CheckedChanged(sender, e);
                chkLand.Checked = false; chkLand_CheckedChanged(sender, e);
                chkOthers.Checked = false; chkOthers_CheckedChanged(sender, e);
            }
        }
        else
        {
            TS_IPASS_REGISTRATION.Visible = false;
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.Text == "--Select--")
        {

            DropDownList2.Enabled = false;
        }
        else
        {
            UID_SEARCHGRID.Visible = false;
            DropDownList2.DataSource = UID_Village_List(Convert.ToInt32(DropDownList1.SelectedValue));
            //DropDownList2.DataSource = VillagedataTable;
            DropDownList2.DataTextField = "village_name";
            DropDownList2.DataValueField = "Village_Id";
            DropDownList2.DataBind();
            DropDownList2.Enabled = true;
        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        UID_SEARCHGRID.Visible = false;

    }
    //protected void TS_IPASS_UID_SEARCH_TextChanged(object sender, EventArgs e)
    //{
    //    if (TS_IPASS_UID_SEARCH.Text.Length > 6)
    //    { SearchButton.Enabled = true; }
    //    else { SearchButton.Enabled = false; }
    //    if (TS_IPASS_UID_SEARCH.Text == "")
    //    {
    //        SearchButton.Enabled = false;
    //        UID_SEARCHGRID.Visible = false;
    //    }
    //}
    protected void SearchButton_Click(object sender, EventArgs e)
    {
        if (TS_IPASS_UID_SEARCH.Text != "" && TS_IPASS_UID_SEARCH.Text.Length > 6 && DropDownList2.SelectedItem.Text != "--Select--")
        {
            fillGrid();
            //fillMSMEUnits(DropDownList1.SelectedItem.Value, DropDownList2.SelectedItem.Value);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Mandal, Village and enter minimum 6 Characters about UID');", true);
        }
    }
    void fillGrid()
    {
        try
        {
            DataSet dsn = new DataSet();
            dsn = GetUIDDetails(TS_IPASS_UID_SEARCH.Text.TrimStart().TrimEnd());
            {
                if (dsn.Tables[0].Rows.Count > 0)
                {
                    UID_SEARCHGRID.Visible = true;
                    UID_SEARCH_GRID.Visible = true;
                    UID_SEARCH_GRID.DataSource = dsn.Tables[0];
                    UID_SEARCH_GRID.DataBind();
                    trmsmeqsn.Visible = true;
                }
                else
                {
                    UID_SEARCHGRID.Visible = true;
                    UID_SEARCH_GRID.Visible = true;
                    UID_SEARCH_GRID.DataSource = dsn.Tables[0];
                    UID_SEARCH_GRID.DataBind();
                    trmsmeqsn.Visible = true;
                }
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Internal error has occured. Please try after some time.');", true);
        }

    }
    public void fillMSMEUnits(string mandalid, string unitname, string lineofactvty)
    {
        try
        {
            DB.DB con = new DB.DB();
            con.OpenConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SP_GET_MSMEMAPPEDUNITDETAILS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@mandalid", SqlDbType.VarChar).Value = mandalid;
            da.SelectCommand.Parameters.Add("@Districtid", SqlDbType.VarChar).Value = Session["DistrictID"].ToString();
            da.SelectCommand.Parameters.Add("@unitname", SqlDbType.VarChar).Value = unitname;
            da.SelectCommand.Parameters.Add("@lineofactvty", SqlDbType.VarChar).Value = lineofactvty;
            da.Fill(ds);
            con.CloseConnection();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlmapunits.DataSource = ds.Tables[0];
                ddlmapunits.DataTextField = "UNIT_NAME";
                ddlmapunits.DataValueField = "MSME_NO";
                ddlmapunits.DataBind();
                trmsmeunits.Visible = true;
            }
            else
            {
                trmsmeunits.Visible = false;
                rblMSMEreg.SelectedIndex = 1;
                trMSMEmap.Visible = true;
                lblnomsmeunits.Visible = true;
                lblnomsmeunits.Text = "No units were found with the given Unit Name";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('No units were found with the given Unit Name);", true);

            }

        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Internal error has occured. Please try after some time.');", true);
        }

    }
    public DataSet GetUIDDetails(string Unitname_UID)
    {
        DataSet Dsnew = new DataSet();
        try
        {
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UnitName_UID",SqlDbType.VarChar),
               new SqlParameter("@Village_id", SqlDbType.Int)
           };

            pp[0].Value = (Unitname_UID == "") ? "%" : "%" + Unitname_UID.ToString() + "%";
            pp[1].Value = DropDownList2.SelectedValue;

            Dsnew = gen.GenericFillDs("[USP_GET_GetUID_DETAILS]", pp);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Internal error has occured. Please try after some time.');", true);
        }
        return Dsnew;
    }
    protected void SelectCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = ((GridViewRow)((CheckBox)sender).NamingContainer);
            int index = row.RowIndex;

            CheckBox chk = (CheckBox)row.FindControl("SelectCheckBox");
            if (chk != null & chk.Checked)
            {
                Label Name = (Label)row.FindControl("Applicant_Name");
                Label UID = (Label)row.FindControl("UIDNo");
                Label applcantemail = (Label)row.FindControl("applEmail");
                Label LOAID = (Label)row.FindControl("Lineofactivity");
                Label applGender = (Label)row.FindControl("applGender");
                Label applCaste = (Label)row.FindControl("applCaste");

                ViewState["UIDNO"] = UID.Text;
                ViewState["ApplEmail"] = applcantemail.Text;
                ViewState["LOAID"] = LOAID.Text;
                ViewState["Gender"] = applGender.Text;
                ViewState["caste"] = applCaste.Text;
                string WomanGender = "";
                if (Women_Cell.SelectedIndex != -1)
                {
                    WomanGender = Convert.ToString(Women_Cell.SelectedItem.Text);
                }
                if (applGender.Text == "FEMALE" || WomanGender == "Yes")
                { trwehub.Visible = true; }

                if ((UID.Text != "" && UID.Text.Contains("LRG")) || (UID.Text != "" && UID.Text.Contains("MEG")))
                {
                    ViewState["IsMajorExist"] = "Yes";
                    chkecommrce.Visible = false; chkecommrce.Checked = false; chkecommrce_CheckedChanged(sender, e);
                    chkOtherSchms.Visible = false; chkOtherSchms.Checked = false; chkOtherSchms_CheckedChanged(sender, e);
                    Financial_Types.Items.RemoveAt(1);
                    //lbltchNA.Visible = true;
                    //Technical_block.Visible = false;
                }
                else
                {
                    ViewState["IsMajorExist"] = "No";
                    chkecommrce.Visible = true; chkecommrce.Checked = false;
                    chkOtherSchms.Visible = true; chkOtherSchms.Checked = false;
                    Financial_Grievance();
                    //Technical_block.Visible = true;
                    //lbltchNA.Visible = false;
                }
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void ddladrsmandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddladrsmandal.SelectedItem.Text == "--Select--")
        {
            ddladrsvlg.DataSource = null; ddladrsvlg.DataBind();
        }
        else
        {
            ddladrsvlg.DataSource = UID_Village_List(Convert.ToInt32(ddladrsmandal.SelectedValue));
            ddladrsvlg.DataTextField = "village_name";
            ddladrsvlg.DataValueField = "Village_Id";
            ddladrsvlg.DataBind();
            ddladrsvlg.Enabled = true;

        }

    }
    protected void Applicant_caste_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Applicant_caste.SelectedItem.Text == "OBC" || Applicant_caste.SelectedItem.Text == "ST" || Applicant_caste.SelectedItem.Text == "SC" || Applicant_caste.SelectedItem.Text == "Minority")
        {
            landdesc.Text = "a-1. Whether information on vacant plots mandated to Weaker Section is informed :";
            grdvacantplots.Visible = true;
        }
        else
        {
            landdesc.Text = "a-1. Whether information on vacant plots informed :";
            grdvacantplots.Visible = false;
        }
    }
    protected void Applicant_Gender_SelectedIndexChanged(object sender, EventArgs e)
    {
        string WomanGender = "";
        if (Women_Cell.SelectedIndex != -1)
        {
            WomanGender = Convert.ToString(Women_Cell.SelectedItem.Text);
        }
        if (Applicant_Gender.SelectedItem.Text == "Female" || WomanGender == "Yes")
        { trwehub.Visible = true; }
    }
    protected void Applicant_Investment_TextChanged(object sender, EventArgs e)
    {
        if (Applicant_Investment.Text != "")
        {
            //Grievance_Identified.Enabled = true;
            if (Convert.ToInt64(Applicant_Investment.Text) > 100000000)
            {
                ViewState["IsMajorNew"] = "Yes";
                if (chkMarketing.Checked)
                {
                    chkecommrce.Visible = false; chkecommrce.Checked = false; chkecommrce_CheckedChanged(sender, e);
                    chkOtherSchms.Visible = false; chkOtherSchms.Checked = false; chkOtherSchms_CheckedChanged(sender, e);
                }
                Financial_Types.Items.RemoveAt(1);
                //lbltchNA.Visible = true;
                //Technical_block.Visible = false;
            }
            else
            {
                ViewState["IsMajorNew"] = "No";
                if (chkMarketing.Checked)
                {
                    chkecommrce.Visible = true; chkecommrce.Checked = false;
                    chkOtherSchms.Visible = true; chkOtherSchms.Checked = false;
                }
                //Financial_Grievance();
                //Technical_block.Visible = true;
                //lbltchNA.Visible = false;
            }

        }
    }
    protected void LineOfActivity_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (LineOfActivity.SelectedValue == "0")
            {
                trodopexport.Visible = true;
                trodoplink.Visible = false;
            }
            else
            {
                trodopexport.Visible = false;
                trodoplink.Visible = false;
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void rblMSMEreg_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblMSMEreg.SelectedItem.Text == "No")
        {
            trMSMEmap.Visible = true;
        }
        else
            trMSMEmap.Visible = false;
        //if (rblMSMEreg.SelectedItem.Text == "Yes")
        //{

        //    if (TS_IPASS_REGISTERED_Unit.SelectedItem.Text == "Yes")
        //    {
        //        if (Convert.ToString(ViewState["LOAID"]) != "" && DropDownList1.SelectedItem.Text != "--Select--" && TS_IPASS_UID_SEARCH.Text != "")
        //        {
        //            fillMSMEUnits(DropDownList1.SelectedValue, TS_IPASS_UID_SEARCH.Text, ViewState["LOAID"].ToString());
        //            //trmsmeunits.Visible = true;
        //        }
        //        else { }

        //    }
        //    else
        //    {
        //        if (ddladrsmandal.SelectedItem.Text != "--Select--" && Applicant_Name.Text != "" && sector_dropdown.SelectedItem.Text != "--Select--")
        //        {
        //            fillMSMEUnits(ddladrsmandal.SelectedValue, Applicant_Name.Text, sector_dropdown.SelectedValue);
        //            //trmsmeunits.Visible = true;
        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please fill all the above details ');", true);
        //            return;
        //        }
        //    }
        //}
        //else
        //{
        //    trmsmeunits.Visible = false;
        //    ddlmapunits.ClearSelection();
        //}

    }
    protected void rblsick_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblsick.SelectedValue == "0")
        {
            trHealthclinic.Visible = true;
        }
        else
        {
            chkhlthclinc.Checked = false;
            trHealthclinic.Visible = false;
        }
    }
    protected void rdodpexport_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rdodpexport.SelectedValue == "0")
            {
                trodopexport.Visible = true;
                trodoplink.Visible = true;
            }
            else
            {
                //trodopexport.Visible = false;
                trodoplink.Visible = false;
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void Grievance_Identified_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (TS_IPASS_REGISTERED_Unit.SelectedIndex != -1)
        {
            if (Grievance_Identified.SelectedValue == "0")
            {
                Grievance_Details_TXT_BOX.Visible = false;
                Grievance_Type_Block.Visible = true;
                lblmrkgrv.Visible = true; lblmrkgdnc.Visible = false;
                lblmrkgrvA2.Visible = true; lblmrkgdncA2.Visible = false;
                lblmrkgrvA3.Visible = true; lblmrkgdncA3.Visible = false;
                lbl2.Visible = true; chkFinancial.Visible = true;
                lblfncgrv.Visible = true; lblfncgdnc.Visible = false;
                lblfncgrvA3.Visible = true; lblfncgdncA3.Visible = false;
                lbl3.Visible = true; chkTechnical.Visible = true;
                lbltechgrv.Visible = true;
                //lbltechgdnc.Visible = false;
                lbltechgrvA2.Visible = true; lbltechgdncA2.Visible = false;
                lbltechgrvA3.Visible = true; lbltechgdncA3.Visible = false;

                lbl4.Visible = true; chkLand.Visible = true;
                lbllandgrv.Visible = true; lbllandgdnc.Visible = false;
                lbllandgrvA2.Visible = true; lbllandgdncA2.Visible = false;

                lbl5.Visible = true; chkOthers.Visible = true; lblothrs.Visible = true; lblothrs.InnerText = "Grievance";
                lblothrgrv.Visible = true; lblothrgdnc.Visible = false;
                Broad_Grievance.Visible = true;
                Broad_Guidance.Visible = false;
                Grievance_Resolution.Visible = true;
                Grievance_Status.Visible = true;
                chkMarketing.Checked = false;
                if (rdboardgrivance.SelectedIndex != -1)
                {
                    chkMarketing_CheckedChanged(sender, e);
                    chkFinancial_CheckedChanged(sender, e);
                    chkTechnical_CheckedChanged(sender, e);
                    chkLand_CheckedChanged(sender, e);
                    chkOthers_CheckedChanged(sender, e);
                }

                rdboardgrivance.ClearSelection();
                //rdboardgrivance_SelectedIndexChanged(sender, e);

                //lblwehub.Text = "14. Do you want to forward to We-Hub";
                //lblhlthclnc.Text = "15. Do you want to forawrd to Health Clinic";
                //TypeOfGrievance.ClearSelection();
                //TypeOfGrievance_SelectedIndexChanged(sender, e);
            }
            //else
            //{ Grievance_Details_TXT_BOX.Visible = false; Grievance_Type_Block.Visible = false; Broad_Grievance.Visible = false; Grievance_Resolution.Visible = false; Grievance_Status.Visible = false; Grievance_Identified_Marketing_ECOMMERCE.Visible = false; }
            if (Grievance_Identified.SelectedValue == "1")
            {
                Grievance_Details_TXT_BOX.Visible = false;
                Grievance_Details.Text = "";
                TextBox3.Text = "";
                GrievanceStatus_dropdown.ClearSelection();
                Grievance_Type_Block.Visible = true;
                lblmrkgrv.Visible = false; lblmrkgdnc.Visible = true;
                lblmrkgrvA2.Visible = false; lblmrkgdncA2.Visible = true;
                lblmrkgrvA3.Visible = false; lblmrkgdncA3.Visible = true;
                lbl2.Visible = true; chkFinancial.Visible = true;
                lblfncgrv.Visible = false; lblfncgdnc.Visible = true;
                lblfncgrvA3.Visible = false; lblfncgdncA3.Visible = true;

                lbl3.Visible = true; chkTechnical.Visible = true; chkTechnical.Checked = true;
                // lbltchNA.Visible = true;
                //lbltechgrv.Visible = false;
                //lbltechgdnc.Visible = true;
                lbltechgrvA2.Visible = false; lbltechgdncA2.Visible = true;
                lbltechgrvA3.Visible = false; lbltechgdncA3.Visible = true;

                lbl4.Visible = true; chkLand.Visible = true;
                lbllandgrv.Visible = false; lbllandgdnc.Visible = true;
                lbllandgrvA2.Visible = false; lbllandgdncA2.Visible = true;

                lbl5.Visible = true; chkOthers.Visible = true; lblothrs.Visible = true; lblothrs.InnerText = "Guidance";
                lblothrgrv.Visible = false; lblothrgdnc.Visible = true;
                chkFinancial.Visible = true;
                chkTechnical.Visible = true;
                chkLand.Visible = true;
                chkOthers.Visible = true;

                chkMarketing.Checked = false;
                chkFinancial.Checked = false;
                chkTechnical.Checked = false;
                chkLand.Checked = false;
                chkOthers.Checked = false;

                if (rdboardgrivance.SelectedIndex != -1)
                {
                    chkMarketing_CheckedChanged(sender, e);
                    chkFinancial_CheckedChanged(sender, e);
                    chkTechnical_CheckedChanged(sender, e);
                    chkLand_CheckedChanged(sender, e);
                    chkOthers_CheckedChanged(sender, e);
                }

                rdboardgrivance.ClearSelection();
                //rdboardgrivance_SelectedIndexChanged(sender, e);

                Broad_Guidance.Visible = true;
                Broad_Grievance.Visible = false;
                Grievance_Resolution.Visible = false;
                Grievance_Status.Visible = false;

                //lblwehub.Text = "11. Do you want to forward to We-Hub";
                //lblhlthclnc.Text = "12. Do you want to forawrd to Health Clinic";
                //TypeOfGrievance.ClearSelection();
                //TypeOfGrievance_SelectedIndexChanged(sender, e);
            }
            //else { Grievance_Type_Block.Visible = false; Broad_Guidance.Visible = false; Grievance_Identified_Marketing_ECOMMERCE.Visible = false; }
        }
        else
        {
            Grievance_Identified.ClearSelection();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select TS-IPASS registered unit or not to proceed further');", true);
            return;
        }
    }
    //protected void TypeOfGrievance_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (TypeOfGrievance.Items[0].Selected)
    //    {
    //        MarketingTypes.Visible = true;
    //        Marketing_BLOCK_OFF.Visible = true;
    //    }
    //    else
    //    {
    //        MarketingTypes.Visible = false;
    //        Marketing_Types.ClearSelection();
    //        Marketing_BLOCK_OFF.Visible = false;
    //        clearecommercefeilds();
    //        clearotherchemesfeilds();
    //        Marketing_Others_Text_Box.Text = "";
    //    }

    //    if (TypeOfGrievance.Items[1].Selected)
    //    {
    //        FinancialTypes.Visible = true;
    //        Financial_Block_OFF.Visible = true;
    //    }
    //    else
    //    {
    //        FinancialTypes.Visible = false;
    //        Financial_Block_OFF.Visible = false;
    //        Financial_Types.ClearSelection();
    //        department_issues_type.ClearSelection();
    //        MSEFCCase_Filed.ClearSelection();
    //        MSEFC_Case_Details.Text = "";
    //        MSEFCCase_Filed_No.ClearSelection();
    //        Invoice_Mart.ClearSelection();
    //        INVOICE_MART_Registration_DATE.Value = "";
    //        No_of_Orders_received_Invoice_Mart.Text = "";
    //        Order_Value_Invoice_Mart.Text = "";
    //        No_of_Bills_Invoice_Mart.Text = "";
    //        Bills_Value_Invoice_Mart.Text = "";
    //        No_of_Bills_Sold_Invoice_Mart.Text = "";
    //        NSE.ClearSelection();
    //        RadioButtonList8.ClearSelection();
    //        RadioButtonList9.ClearSelection();
    //        SIDBI.ClearSelection();
    //        RadioButtonList19.ClearSelection();
    //    }

    //    if (TypeOfGrievance.Items[2].Selected)
    //    {
    //        Technical_block.Visible = true;
    //    }
    //    else
    //    {
    //        Technical_block.Visible = false;
    //        TechnicalType_Grievance.ClearSelection();
    //        ddlLineDepartment.ClearSelection();
    //        Technical_Others.Text = "";
    //    }

    //    if (TypeOfGrievance.Items[3].Selected)
    //    {
    //        Land_Block.Visible = true;
    //    }
    //    else
    //    {
    //        Land_Block.Visible = false;
    //        Land_Grievance.ClearSelection();
    //        RadioButtonList10.ClearSelection();
    //        TextBox1.Text = "";
    //    }

    //    if (TypeOfGrievance.Items[4].Selected)
    //    {
    //        Other_Grievance_Block.Visible = true;
    //    }
    //    else
    //    {
    //        Other_Grievance_Block.Visible = false;
    //        TextBox2.Text = "";
    //    }
    //}

    //protected void RadioButtonYes_CheckedChanged(object sender, EventArgs e, string id)
    //{
    //    if (id == "1")
    //    { Meesho_Details.Visible = true; Meesho_Details_NO.Visible = false; Meesho_Awareness_Yes.Visible = false; }
    //    else if (id == "2")
    //    { Just_Dial_Details.Visible = true; Just_Dial_NO.Visible = false; Just_Dial_Awareness_Yes.Visible = false; }
    //    else if (id == "3")
    //    { TS_Global_Details.Visible = true; TS_Global_No.Visible = false; TS_GLOBAL_Awareness_Yes.Visible = false; }
    //    else if (id == "4")
    //    { Walmart_Vriddi_Details.Visible = true; Walmart_Vriddi_NO.Visible = false; WALMART_VRIDDI_Awareness_Yes.Visible = false; }
    //}
    //protected void RadioButtonNo_CheckedChanged(object sender, EventArgs e, string id)
    //{
    //    if (id == "1")
    //    { Meesho_Details_NO.Visible = true; Meesho_Details.Visible = false; }
    //    else if (id == "2")
    //    { Just_Dial_NO.Visible = true; Just_Dial_Details.Visible = false; }
    //    else if (id == "3")
    //    { TS_Global_No.Visible = true; TS_Global_Details.Visible = false; }
    //    else if (id == "4")
    //    { Walmart_Vriddi_NO.Visible = true; Walmart_Vriddi_Details.Visible = false; }
    //}

    //private void Village_List()
    //{ 
    //    DataTable VillagedataTable = new DataTable();
    //    con.OpenConnection();
    //    {
    //        using (SqlCommand command = new SqlCommand("GETVillage_EXISTING_ENTREPRENEURS", con.GetConnection))
    //        {
    //            command.CommandType = CommandType.StoredProcedure;
    //            command.Parameters.AddWithValue("@Mandal_ID", ddl_Mandal.SelectedValue);

    //            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
    //            {
    //                adapter.Fill(VillagedataTable);
    //                VillagedataTable.Rows.InsertAt(VillagedataTable.NewRow(), 0);
    //                VillagedataTable.Rows[0]["village_name"] = "--Select--";
    //                ddl_Village.DataSource = VillagedataTable;
    //                ddl_Village.DataTextField = "village_name";
    //                ddl_Village.DataValueField = "Village_Id";
    //                ddl_Village.DataBind();
    //            }
    //            con.CloseConnection();
    //        }
    //    }
    //}


    //private void Grievance_Status_Dropdown()
    //{
    //    DataTable dataTable = new DataTable();
    //    con.OpenConnection();
    //    {
    //        using (SqlCommand command = new SqlCommand("GetGrievanceStatus", con.GetConnection))
    //        {
    //            command.CommandType = CommandType.StoredProcedure;
    //            string roleCode = Session["Role_Code"].ToString().TrimEnd();
    //            command.Parameters.Add(new SqlParameter("@RoleCode", SqlDbType.VarChar, 50)).Value = roleCode;

    //            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
    //            {
    //                adapter.Fill(dataTable);
    //                dataTable.Rows.InsertAt(dataTable.NewRow(), 0);
    //                dataTable.Rows[0]["Id"] = 0;
    //                dataTable.Rows[0]["GrStatusType"] = "--Select--";
    //                GrievanceStatus_dropdown.DataSource = dataTable;
    //                GrievanceStatus_dropdown.DataTextField = "GrStatusType";
    //                GrievanceStatus_dropdown.DataValueField = "ID";
    //                GrievanceStatus_dropdown.DataBind();
    //            }
    //            con.CloseConnection();
    //        }
    //    }
    //}

    protected void rdboardgrivance_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (TS_IPASS_REGISTERED_Unit.SelectedIndex != -1)
            {
                if (rdboardgrivance.SelectedIndex != -1)
                {
                    if (rdboardgrivance.SelectedIndex == 0)
                    {
                        Trdepartmentissues.Visible = true;
                        trmarketing.Visible = false;
                        trFinancial.Visible = false;
                        trLand.Visible = false;
                        chkTechnical.Enabled = true;
                        chkTechnical.Checked = true;
                        chkTechnical_CheckedChanged(sender, e);
                    }
                    else
                    {
                        chkTechnical.Checked = false;
                        chkTechnical_CheckedChanged(sender, e);
                        chkTechnical.Enabled = false;
                    }
                    if (rdboardgrivance.SelectedIndex == 1)
                    {
                        Trdepartmentissues.Visible = false;
                        trmarketing.Visible = true;
                        trFinancial.Visible = false;
                        chkMarketing.Checked = true;
                        trLand.Visible = false;
                        chkMarketing_CheckedChanged(sender, e);
                    }
                    else
                    {
                        chkMarketing.Checked = false;
                        chkMarketing_CheckedChanged(sender, e);

                    }
                    if (rdboardgrivance.SelectedIndex == 2)
                    {
                        Trdepartmentissues.Visible = false;
                        trmarketing.Visible = false;
                        trFinancial.Visible = true;
                        trLand.Visible = false;
                        chkFinancial.Checked = true;
                        chkFinancial_CheckedChanged(sender, e);
                    }
                    else
                    {
                        chkFinancial.Checked = false;
                        chkFinancial_CheckedChanged(sender, e);

                    }
                    if (rdboardgrivance.SelectedIndex == 3)
                    {
                        Trdepartmentissues.Visible = false;
                        trmarketing.Visible = false;
                        trFinancial.Visible = false;
                        trLand.Visible = true;
                        chkLand.Checked = true;
                        chkLand_CheckedChanged(sender, e);
                    }
                    else
                    {
                        chkLand.Checked = false;
                        chkLand_CheckedChanged(sender, e);
                    }
                    if (rdboardgrivance.SelectedIndex == 4)
                    {
                        Trdepartmentissues.Visible = false;
                        trmarketing.Visible = false;
                        trFinancial.Visible = false;
                        trLand.Visible = false;
                        chkOthers.Checked = true;
                        chkOthers_CheckedChanged(sender, e);
                    }
                    else
                    {
                        chkOthers.Checked = false;
                        chkOthers_CheckedChanged(sender, e);

                    }
                }
            }
            else 
            {
                rdboardgrivance.ClearSelection();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select TS-IPASS registered unit or not to proceed further');", true);
                return;
            }
        }
        catch (Exception ex)
        {
            throw ex;

        }
    }
    protected void chkTechnical_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            ////if (Convert.ToString(ViewState["UIDNO"]) != "" || Applicant_Investment.Text != "")
            ////{
            ///
            if (rdboardgrivance.SelectedValue == "")
            {
                chkTechnical.Checked = false;
                rdboardgrivance.Focus();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Broad Type of Guidance');", true);
                return;
            }
            if (chkTechnical.Checked)
            {
                Techblock.Visible = true;
                Technical_block.Visible = true;
                ////string UID = Convert.ToString(ViewState["UIDNO"]);
                //////if (UID.Contains("LRG") || UID.Contains("MEG"))
                ////if (Grievance_Identified.SelectedItem.Text == "No" || (UID != "" && UID.Contains("LRG")) || (UID != "" && UID.Contains("MEG") || (Applicant_Investment.Text != "" && Convert.ToInt64(Applicant_Investment.Text) > 100000000)))
                ////{
                ////    lbltchNA.Visible = true;
                ////    Technical_block.Visible = false;
                ////}
                ////else
                ////{
                ////    lbltchNA.Visible = false;
                ////    Technical_block.Visible = true;
                ////}
            }
            else
            {
                Techblock.Visible = false;
                rblTechnSchms.ClearSelection();
                rblTechnSchms_SelectedIndexChanged(sender, e);
                Technical_block.Visible = false;
                trtechissue.Visible = false;
                Technical_Others_TXT_BOX.Visible = false; Technical_Others.Text = "";
                trtechschmsothrs.Visible = false;
                TechnicalType_Grievance.ClearSelection();
                TechnicalType_Grievance_SelectedIndexChanged(sender, e);
                Line_department_block.Visible = false;
                ddlLineDepartment.ClearSelection();
                Financial_Departmental_Issues.Visible = false;
                //department_issues_type.ClearSelection(); department_issues_type_SelectedIndexChanged(sender, e);
                MSEFCCase_Filed_No.ClearSelection(); MSEFCCase_Filed_SelectedIndexChanged(sender, e);
                MSEFC_Case_Details.Text = "";
            }
            ////}
            ////else
            ////{
            ////    chkTechnical.Checked = false;
            ////    //ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select/Fill all details under the unit registered under TS-IPASS');", true);
            ////    return;
            ////}
        }
        catch (Exception ex)
        { throw ex; }

    }
    protected void rblTechnSchms_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblTechnSchms.SelectedIndex != -1)
            {
                if (rblTechnSchms.SelectedIndex == 0)
                {
                    Trdepartmentissues.Visible = true;
                    trtechissue.Visible = true;
                    trtechschmsothrs.Visible = false;
                    txttechschmsothrs.Text = "";
                    Financial_Departmental_Issues.Visible = false;
                    //department_issues_type.ClearSelection(); department_issues_type_SelectedIndexChanged(sender, e);
                    MSEFCCase_Filed_No.ClearSelection(); MSEFCCase_Filed_SelectedIndexChanged(sender, e);
                    MSEFC_Case_Details.Text = "";
                    trincentives.Visible = false;
                    trRawmaterial.Visible = false;

                }
                else if (rblTechnSchms.SelectedIndex == 1)
                {
                    Trdepartmentissues.Visible = true;
                    trincentives.Visible = true;
                    trRawmaterial.Visible = false;
                    trtechissue.Visible = false;
                    trtechschmsothrs.Visible = false;
                    txttechschmsothrs.Text = "";
                    Financial_Departmental_Issues.Visible = false;
                    department_issues_type.ClearSelection(); department_issues_type_SelectedIndexChanged(sender, e);
                    MSEFCCase_Filed_No.ClearSelection(); MSEFCCase_Filed_SelectedIndexChanged(sender, e);
                    MSEFC_Case_Details.Text = "";
                }
                else if (rblTechnSchms.SelectedIndex == 2)
                {
                    Trdepartmentissues.Visible = true;
                    trincentives.Visible = false;
                    trRawmaterial.Visible = true;
                    trtechissue.Visible = false;
                    trtechschmsothrs.Visible = false;
                    txttechschmsothrs.Text = "";
                    Financial_Departmental_Issues.Visible = false;
                    department_issues_type.ClearSelection(); department_issues_type_SelectedIndexChanged(sender, e);
                    MSEFCCase_Filed_No.ClearSelection(); MSEFCCase_Filed_SelectedIndexChanged(sender, e);
                    MSEFC_Case_Details.Text = "";
                }
                else if (rblTechnSchms.SelectedItem.Text == "MSEFC")
                {
                    Trdepartmentissues.Visible = true;
                    trincentives.Visible = false;
                    Financial_Departmental_Issues.Visible = true;
                    MSEFC_Case_Filed_Yes.Visible = true;
                    trtechissue.Visible = false; TechnicalType_Grievance.ClearSelection();
                    Line_department_block.Visible = false; ddlLineDepartment.ClearSelection();
                    trtechschmsothrs.Visible = false; trRawmaterial.Visible = false;
                    Technical_Others_TXT_BOX.Visible = false; Technical_Others.Text = "";
                    txttechschmsothrs.Text = "";
                }
                else if (rblTechnSchms.SelectedItem.Text == "Others")
                {
                    Trdepartmentissues.Visible = true;
                    trtechschmsothrs.Visible = true; trRawmaterial.Visible = false;
                    Technical_Others_TXT_BOX.Visible = false; Technical_Others.Text = "";
                    trtechissue.Visible = false; trincentives.Visible = false;
                    TechnicalType_Grievance.ClearSelection();
                    TechnicalType_Grievance_SelectedIndexChanged(sender, e);
                    Line_department_block.Visible = false;
                    ddlLineDepartment.ClearSelection();
                    Technical_Others.Text = "";
                    Financial_Departmental_Issues.Visible = false;
                    department_issues_type.ClearSelection(); department_issues_type_SelectedIndexChanged(sender, e);
                    MSEFCCase_Filed_No.ClearSelection(); MSEFCCase_Filed_SelectedIndexChanged(sender, e);
                    MSEFC_Case_Details.Text = "";
                    lblmarketing.Visible = true;
                    //lblmarketing.Attributes.Add("class", "blink");

                }
                else
                {
                    Trdepartmentissues.Visible = true; trRawmaterial.Visible = false;
                    trtechissue.Visible = false; trincentives.Visible = false;
                    Technical_Others_TXT_BOX.Visible = false; Technical_Others.Text = "";
                    trtechschmsothrs.Visible = false;
                    TechnicalType_Grievance.ClearSelection();
                    TechnicalType_Grievance_SelectedIndexChanged(sender, e);
                    Line_department_block.Visible = false;
                    ddlLineDepartment.ClearSelection();
                    Technical_Others.Text = "";
                    Financial_Departmental_Issues.Visible = false;
                    department_issues_type.ClearSelection(); department_issues_type_SelectedIndexChanged(sender, e);
                    MSEFCCase_Filed_No.ClearSelection(); MSEFCCase_Filed_SelectedIndexChanged(sender, e);
                    MSEFC_Case_Details.Text = "";
                    lblmarketing.Visible = true;

                }
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void TechnicalType_Grievance_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (TechnicalType_Grievance.SelectedValue == "1")
            {
                Line_department_block.Visible = true;
                Technical_Others.Text = "";
            }
            else
            {
                Line_department_block.Visible = false;
                ddlLineDepartment.ClearSelection();
            }
            if (TechnicalType_Grievance.SelectedValue == "2")
            {
                Technical_Others_TXT_BOX.Visible = true; ddlLineDepartment.ClearSelection();
            }
            else
            { Technical_Others_TXT_BOX.Visible = false; Technical_Others.Text = ""; }
            if (TechnicalType_Grievance.SelectedIndex != -1)
            {
                lblmarketing.Visible = true;
                //lblmarketing.Attributes.Add("style", "text-decoration:blink");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Explain about Marketing related schemes to applicant if applicable');", true);
            }

        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void department_issues_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (department_issues_type.SelectedValue == "1")
            {
                MSEFC_Case_Filed_Yes.Visible = true;
            }
            else
            {
                MSEFC_Case_Filed_Yes.Visible = false;
                MSEFCCase_Filed.ClearSelection(); MSEFCCase_Filed_SelectedIndexChanged(sender, e);
                MSEFC_Case_Details.Text = "";
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void MSEFCCase_Filed_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (MSEFCCase_Filed.SelectedValue == "0")
            { CaseDetails.Visible = true; }
            else { CaseDetails.Visible = false; MSEFC_Case_Filed_No.Visible = false; MSEFC_Case_Details.Text = ""; }
            if (MSEFCCase_Filed.SelectedValue == "1")
            { MSEFC_Case_Filed_No.Visible = true; }
            else { MSEFC_Case_Filed_No.Visible = false; MSEFCCase_Filed_No.ClearSelection(); }
            if (MSEFCCase_Filed.SelectedValue == "0")
            {
                lblmarketing.Visible = true;
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void MSEFCCase_Filed_No_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (MSEFCCase_Filed_No.SelectedValue == "1")
        {
            trmsefc.Visible = true;
        }
        else
        {
            trmsefc.Visible = false;
        }
    }
    protected void rdincentives_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblmarketing.Visible = true;
    }
    protected void rdrawmaterial_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblmarketing.Visible = true;
    }
    protected void chkMarketing_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
           
            if (rdboardgrivance.SelectedIndex == -1)
            {
                chkMarketing.Checked = false;
                rdboardgrivance.Focus();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Broad Type of Guidance');", true);
                return;
            }
            if (chkMarketing.Checked)
            {
                //mrktngpanel.Visible = true;
                lblFinancial.Visible = true;
                MarketingTypes.Visible = true; Marketing_BLOCK_OFF.Visible = true;
                //trmarketing.Visible = true;

                if (TS_IPASS_REGISTERED_Unit.SelectedIndex != -1)
                {
                    chkmrkOthrs.Visible = true;
                    if (TS_IPASS_REGISTERED_Unit.SelectedItem.Text == "Yes")
                    {
                        string UID = Convert.ToString(ViewState["UIDNO"]);
                        if (UID != "")
                        {
                            if ((UID.Contains("LRG")) || (UID != "" && UID.Contains("MEG")))
                            {
                                chkecommrce.Visible = false;
                                chkOtherSchms.Visible = false;
                            }
                            else
                            {
                                chkecommrce.Visible = true;
                                chkOtherSchms.Visible = true;
                            }
                        }
                    }
                    else if (TS_IPASS_REGISTERED_Unit.SelectedItem.Text == "No")
                    {
                        if (Applicant_Investment.Text != "")
                        {
                            if (Convert.ToInt64(Applicant_Investment.Text) > 100000000)
                            {
                                chkecommrce.Visible = false;
                                chkOtherSchms.Visible = false;
                            }
                            else
                            {
                                chkecommrce.Visible = true;
                                chkOtherSchms.Visible = true;
                            }
                        }
                        else 
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter Investment of the Unit to proceed further');", true);
                            return;
                        }
                    }
                   
                }
                else
                {
                    chkMarketing.Checked = false;
                    MarketingTypes.Visible = false;
                    lblFinancial.Visible = false;

                    //lblmsg0.Text = "Please select TS-IPASS registered unit or not and then select marketing";
                    //Failure.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select TS-IPASS registered unit or not and then select marketing');", true);
                    return;
                }

            }
            else
            {
                //mrktngpanel.Visible = false;
                Grievance_Identified_Marketing_ECOMMERCE.Visible = false;
                MarketingTypes.Visible = false; Marketing_BLOCK_OFF.Visible = false;
                chkecommrce.Checked = false; chkecommrce_CheckedChanged(sender, e);
                chkOtherSchms.Checked = false; chkOtherSchms_CheckedChanged(sender, e);
                chkmrkOthrs.Checked = false; chkmrkOthrs_CheckedChanged(sender, e);
                //Marketing_Types.ClearSelection(); Marketing_Types_SelectedIndexChanged(sender, e);
                clearecommercefeilds(); rblMeesho_SelectedIndexChanged(sender, e); rblJustDial_SelectedIndexChanged(sender, e);
                rblTSGlobal_SelectedIndexChanged(sender, e); rblWallmart_SelectedIndexChanged(sender, e);
                clearotherchemesfeilds();
                Marketing_Others_Text_Box.Text = "";
            }
            ////}
            ////else
            ////{
            ////    chkMarketing.Checked = false;
            ////    //ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select/Fill all details under the unit registered under TS-IPASS');", true);
            ////    return;
            ////}
        }
        catch (Exception ex)
        {
            throw ex;
            //lblmsg0.Text = ex.Message;  Failure.Visible = true;

        }
    }
    protected void clearecommercefeilds()
    {
        // PlatformTablePlaceholder.ClearSelection();
        rblMeesho.ClearSelection();
        rblmeeshoofcrref.ClearSelection();
        Meesho_Unique_ID.Text = "";
        Meesho_Registration_Date.Value = "";
        Meesho_Awareness_No_List.ClearSelection();
        Meesho_NO.ClearSelection();
        rblMSintrsted.ClearSelection();

        rblJustDial.ClearSelection();
        rbljustdialofcrref.ClearSelection();
        Just_Dial_ID.Text = "";
        Just_Dial_Registration_Date.Value = "";
        Just_Dial_Awareness_No_List.ClearSelection();
        JustDialNOBtn.ClearSelection();
        rblJDintrsted.ClearSelection();

        rblTSGlobal.ClearSelection();
        rblTSGofcrref.ClearSelection();
        TS_Global_UNIQUE_ID.Text = "";
        TS_Global_Registration_Date.Value = "";
        TS_GLOBAL_DETAILS_LIST.ClearSelection();
        TS_Global_NO_BTN.ClearSelection();
        rblTSGintrsted.ClearSelection();

        rblWallmart.ClearSelection();
        rblwallmartofcrref.ClearSelection();
        Walmart_Vriddi_UNIQUE_ID.Text = "";
        Walmart_Vriddi_Registration_Date.Value = "";
        WALMART_VRIDDI_DETAILS_LIST.ClearSelection();
        Walmart_Vriddi_NO_Btn.ClearSelection();
        rblWMVintrsted.ClearSelection();
    }
    protected void clearotherchemesfeilds()
    {
        chkMAS.Checked = false;
        chkPMS.Checked = false;
        chkSMAS.Checked = false;
        //OtherSchemesChkList.ClearSelection();
        rblMASawrns.ClearSelection();
        rblMASintrsted.ClearSelection();
        rblPMSawrns.ClearSelection();
        rblPMSintrsted.ClearSelection();
        rblSMASawrns.ClearSelection();
        rblSMASintrsted.ClearSelection();
    }
    protected void chkecommrce_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkecommrce.Checked)
            {
                Marketing_BLOCK_OFF.Visible = true;
                Grievance_Identified_Marketing_ECOMMERCE.Visible = true;
            }
            else
            {
                clearecommercefeilds();
                Grievance_Identified_Marketing_ECOMMERCE.Visible = false;
                rblMeesho_SelectedIndexChanged(sender, e);
                rblJustDial_SelectedIndexChanged(sender, e);
                rblTSGlobal_SelectedIndexChanged(sender, e);
                rblWallmart_SelectedIndexChanged(sender, e);

            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void rblMeesho_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblMeesho.SelectedIndex == -1 || rblMeesho.SelectedItem.Text == "NA")
            {
                Meesho_Details_NO.Visible = false;
                Meesho_Details.Visible = false;
                Meesho_NO.ClearSelection(); Meesho_NO_SelectedIndexChanged(sender, e);
                rblMSintrsted.ClearSelection();
                rblmeeshoofcrref.ClearSelection();
                Meesho_Unique_ID.Text = ""; Meesho_Registration_Date.Value = "";
                rblMSaftrCamps.ClearSelection(); rblMSaftrCamps_SelectedIndexChanged(sender, e);
                txtMScampdate.Text = "";
                txtmeeshocount.Text = ""; txtmeeshovalue.Text = "";
            }
            else if (rblMeesho.SelectedItem.Text == "Yes")
            {
                Meesho_Details_NO.Visible = false;
                Meesho_Details.Visible = true;
                Meesho_NO.ClearSelection(); Meesho_NO_SelectedIndexChanged(sender, e);
                rblMSintrsted.ClearSelection();
            }
            else if (rblMeesho.SelectedItem.Text == "No")
            {
                Meesho_Details.Visible = false;
                Meesho_Details_NO.Visible = true;
                rblmeeshoofcrref.ClearSelection();
                Meesho_Unique_ID.Text = ""; Meesho_Registration_Date.Value = "";
                rblMSaftrCamps.ClearSelection(); rblMSaftrCamps_SelectedIndexChanged(sender, e);
                txtMScampdate.Text = "";
                txtmeeshocount.Text = ""; txtmeeshovalue.Text = "";
                Meesho_NO.Enabled = true;

            }

        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void rblMSaftrCamps_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblMSaftrCamps.SelectedValue == "0")
        { trMScampdate.Visible = true; }
        else { trMScampdate.Visible = false; txtMScampdate.Text = ""; }
    }
    protected void Meesho_NO_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Meesho_NO.SelectedValue == "0")
            { Meesho_Awareness_Yes.Visible = true; }
            else { Meesho_Awareness_Yes.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void rblMSintrsted_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblMSintrsted.SelectedValue == "0")
            { Div4.Visible = true; }
            else { Div4.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void rblJustDial_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblJustDial.SelectedIndex == -1 || rblJustDial.SelectedItem.Text == "NA")
            {
                Just_Dial_NO.Visible = false;
                Just_Dial_Details.Visible = false;
                Just_Dial_Awareness_No_List.ClearSelection();
                JustDialNOBtn.ClearSelection();
                JustDialNOBtn_SelectedIndexChanged(sender, e);
                rblJDintrsted.ClearSelection();
                rbljustdialofcrref.ClearSelection();
                rblJDaftrCamps.ClearSelection(); rblJDaftrCamps_SelectedIndexChanged(sender, e);
                txtJDcampdate.Text = "";
                Just_Dial_ID.Text = ""; Just_Dial_Registration_Date.Value = "";
                txtjstdialcount.Text = ""; txtjstdialvalue.Text = "";
            }
            else if (rblJustDial.SelectedItem.Text == "Yes")
            {
                Just_Dial_Details.Visible = true; Just_Dial_NO.Visible = false;
                Just_Dial_Awareness_No_List.ClearSelection();
                JustDialNOBtn.ClearSelection();
                JustDialNOBtn_SelectedIndexChanged(sender, e);
                rblJDintrsted.ClearSelection();
            }
            else if (rblJustDial.SelectedItem.Text == "No")
            {
                Just_Dial_Details.Visible = false;
                Just_Dial_NO.Visible = true;
                rbljustdialofcrref.ClearSelection();
                rblJDaftrCamps.ClearSelection(); rblJDaftrCamps_SelectedIndexChanged(sender, e);
                txtJDcampdate.Text = "";
                Just_Dial_ID.Text = ""; Just_Dial_Registration_Date.Value = "";
                txtjstdialcount.Text = ""; txtjstdialvalue.Text = "";
            }
            //else
            //{
            //    Just_Dial_NO.Visible = false;
            //    Just_Dial_Details.Visible = false;
            //}
        }
        catch (Exception ex)
        { throw ex; }

    }
    protected void rblJDaftrCamps_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblJDaftrCamps.SelectedValue == "0")
        { trJDcampdate.Visible = true; }
        else { trJDcampdate.Visible = false; txtJDcampdate.Text = ""; }
    }
    protected void JustDialNOBtn_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (JustDialNOBtn.SelectedValue == "0")
            { Just_Dial_Awareness_Yes.Visible = true; }
            else { Just_Dial_Awareness_Yes.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void rblJDintrsted_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblJDintrsted.SelectedValue == "0")
            { Div5.Visible = true; }
            else { Div5.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void rblTSGlobal_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblTSGlobal.SelectedIndex == -1 || rblTSGlobal.SelectedItem.Text == "NA")
            {
                TS_Global_No.Visible = false;
                TS_Global_Details.Visible = false;
                TS_GLOBAL_DETAILS_LIST.ClearSelection();
                TS_Global_NO_BTN.ClearSelection();
                TS_Global_NO_BTN_SelectedIndexChanged(sender, e);
                rblTSGintrsted.ClearSelection();
                rblTSGofcrref.ClearSelection();
                rblTSGaftrCamps.ClearSelection(); rblTSGaftrCamps_SelectedIndexChanged(sender, e);
                txtTSGcampdate.Text = "";
                TS_Global_UNIQUE_ID.Text = ""; TS_Global_Registration_Date.Value = "";
                txttsglobalcount.Text = ""; txttsglobalvalue.Text = "";
            }
            else if (rblTSGlobal.SelectedItem.Text == "Yes")
            {
                TS_Global_Details.Visible = true; TS_Global_No.Visible = false;
                TS_GLOBAL_DETAILS_LIST.ClearSelection();
                TS_Global_NO_BTN.ClearSelection();
                TS_Global_NO_BTN_SelectedIndexChanged(sender, e);
                rblTSGintrsted.ClearSelection();
            }
            else if (rblTSGlobal.SelectedItem.Text == "No")
            {
                TS_Global_Details.Visible = false;
                TS_Global_No.Visible = true;
                rblTSGofcrref.ClearSelection();
                rblTSGaftrCamps.ClearSelection(); rblTSGaftrCamps_SelectedIndexChanged(sender, e);
                txtTSGcampdate.Text = "";
                TS_Global_UNIQUE_ID.Text = ""; TS_Global_Registration_Date.Value = "";
                txttsglobalcount.Text = ""; txttsglobalvalue.Text = "";
            }
            //else
            //{
            //    TS_Global_No.Visible = false;
            //    TS_Global_Details.Visible = false;
            //}
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void rblTSGaftrCamps_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblTSGaftrCamps.SelectedValue == "0")
        { trTSGcampdate.Visible = true; }
        else { trTSGcampdate.Visible = false; txtTSGcampdate.Text = ""; }

    }
    protected void TS_Global_NO_BTN_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (TS_Global_NO_BTN.SelectedValue == "0")
            { TS_GLOBAL_Awareness_Yes.Visible = true; }
            else { TS_GLOBAL_Awareness_Yes.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void rblTSGintrsted_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblTSGintrsted.SelectedValue == "0")
            { Div6.Visible = true; }
            else { Div6.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void rblWallmart_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblWallmart.SelectedIndex == -1 || rblWallmart.SelectedItem.Text == "NA")
            {
                Walmart_Vriddi_NO.Visible = false;
                Walmart_Vriddi_Details.Visible = false;
                WALMART_VRIDDI_DETAILS_LIST.ClearSelection();
                Walmart_Vriddi_NO_Btn.ClearSelection();
                Walmart_Vriddi_NO_Btn_SelectedIndexChanged(sender, e);
                rblWMVintrsted.ClearSelection();
                rblwallmartofcrref.ClearSelection(); rblWMVaftrCamps.ClearSelection();
                rblWMVaftrCamps_SelectedIndexChanged(sender, e);
                txtTSGcampdate.Text = "";
                Walmart_Vriddi_UNIQUE_ID.Text = "";
                Walmart_Vriddi_Registration_Date.Value = "";
                txtwallmartcount.Text = ""; txtwallmartvalue.Text = "";
            }

            else if (rblWallmart.SelectedItem.Text == "Yes")
            {
                Walmart_Vriddi_Details.Visible = true;
                Walmart_Vriddi_NO.Visible = false;
                WALMART_VRIDDI_DETAILS_LIST.ClearSelection();
                Walmart_Vriddi_NO_Btn.ClearSelection();
                Walmart_Vriddi_NO_Btn_SelectedIndexChanged(sender, e);
                rblWMVintrsted.ClearSelection();
            }
            else if (rblWallmart.SelectedItem.Text == "No")
            {
                Walmart_Vriddi_Details.Visible = false;
                Walmart_Vriddi_NO.Visible = true;
                wlmrtbnfts.Visible = true;
                wlmrtbnftslst.Visible = true;
                wlmrtNorbl.Visible = true;
                //Thread.Sleep(10000);
                rblwallmartofcrref.ClearSelection(); rblWMVaftrCamps.ClearSelection();
                rblWMVaftrCamps_SelectedIndexChanged(sender, e);
                txtTSGcampdate.Text = "";
                Walmart_Vriddi_UNIQUE_ID.Text = "";
                Walmart_Vriddi_Registration_Date.Value = "";
                txtwallmartcount.Text = ""; txtwallmartvalue.Text = "";
            }
            //else
            //{
            //    Walmart_Vriddi_NO.Visible = false;
            //    Walmart_Vriddi_Details.Visible = false;
            //}
        }
        catch (Exception ex)
        { throw ex; }

    }
    protected void rblWMVaftrCamps_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblWMVaftrCamps.SelectedValue == "0")
        { trWMVcampdate.Visible = true; }
        else { trWMVcampdate.Visible = false; txtWMVcampdate.Text = ""; }

    }
    protected void Walmart_Vriddi_NO_Btn_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Walmart_Vriddi_NO_Btn.SelectedValue == "0")
            { WALMART_VRIDDI_Awareness_Yes.Visible = true; }
            else { WALMART_VRIDDI_Awareness_Yes.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void rblWMVintrsted_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblWMVintrsted.SelectedValue == "0")
            { Div7.Visible = true; }
            else { Div7.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void chkOtherSchms_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkOtherSchms.Checked)
            {
                Marketing_BLOCK_OFF.Visible = true;
                Grievance_Identified_Marketing_Schemes.Visible = true;

                //divMAS.Visible = true;
                //divPMS.Visible = true;
                //divSMAS.Visible = true;
            }
            else
            {
                Grievance_Identified_Marketing_Schemes.Visible = false;
                clearotherchemesfeilds();
                chkMAS.Checked = false; chkMAS_CheckedChanged(sender, e);
                chkSMAS.Checked = false; chkSMAS_CheckedChanged(sender, e);
                chkPMS.Checked = false; chkPMS_CheckedChanged(sender, e);
                rblMAS.ClearSelection();
                rblPMS.ClearSelection();
                rblSMAS.ClearSelection();
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void chkMAS_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkMAS.Checked)
            { SCHEME_MAS_BLOCK.Visible = true; }
            else
            {
                SCHEME_MAS_BLOCK.Visible = false;
                rblMASawrns.ClearSelection(); rblMASawrns_SelectedIndexChanged(sender, e);
                rblMASintrsted.ClearSelection(); rblMASintrsted_SelectedIndexChanged(sender, e);
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void rblMAS_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblMAS.SelectedItem.Text == "Yes")
            { SCHEME_MAS_BLOCK.Visible = true; }
            else
            {
                SCHEME_MAS_BLOCK.Visible = false;
                rblMASawrns.ClearSelection(); rblMASawrns_SelectedIndexChanged(sender, e);
                rblMASintrsted.ClearSelection(); rblMASintrsted_SelectedIndexChanged(sender, e);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void rblMASawrns_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblMASawrns.SelectedValue == "0")
            { Div1.Visible = true; }
            else { Div1.Visible = false; NSIC_LINK.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void rblMASintrsted_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblMASintrsted.SelectedValue == "0")
            { NSIC_LINK.Visible = true; }
            else { NSIC_LINK.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void chkPMS_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkPMS.Checked)
            { SCHEME_PMS_BLOCK.Visible = true; }
            else
            {
                SCHEME_PMS_BLOCK.Visible = false;
                rblPMSawrns.ClearSelection(); rblPMSawrns_SelectedIndexChanged(sender, e);
                rblPMSintrsted.ClearSelection(); rblPMSintrsted_SelectedIndexChanged(sender, e);
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void rblPMS_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblPMS.SelectedItem.Text == "Yes")
            { SCHEME_PMS_BLOCK.Visible = true; }
            else
            {
                SCHEME_PMS_BLOCK.Visible = false;
                rblPMSawrns.ClearSelection(); rblPMSawrns_SelectedIndexChanged(sender, e);
                rblPMSintrsted.ClearSelection(); rblPMSintrsted_SelectedIndexChanged(sender, e);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void rblPMSawrns_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblPMSawrns.SelectedValue == "0")
            { Div2.Visible = true; }
            else { Div2.Visible = false; MSME_LINK.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void rblPMSintrsted_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblPMSintrsted.SelectedValue == "0")
            { MSME_LINK.Visible = true; }
            else { MSME_LINK.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void chkSMAS_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkPMS.Checked)
            { SCHEME_SMAS_BLOCK.Visible = true; }
            else
            {
                SCHEME_SMAS_BLOCK.Visible = false;
                rblSMASawrns.ClearSelection(); rblSMASawrns_SelectedIndexChanged(sender, e);
                rblSMASintrsted.ClearSelection(); rblSMASintrsted_SelectedIndexChanged(sender, e);
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void rblSMAS_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblSMAS.SelectedItem.Text == "Yes")
            { SCHEME_SMAS_BLOCK.Visible = true; }
            else
            {
                SCHEME_SMAS_BLOCK.Visible = false;
                rblSMASawrns.ClearSelection(); rblSMASawrns_SelectedIndexChanged(sender, e);
                rblSMASintrsted.ClearSelection(); rblSMASintrsted_SelectedIndexChanged(sender, e);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void rblSMASawrns_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblSMASawrns.SelectedValue == "0")
            { Div3.Visible = true; }
            else { Div3.Visible = false; SMAS_LINK.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }

    }
    protected void rblSMASintrsted_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblSMASintrsted.SelectedValue == "0")
            { SMAS_LINK.Visible = true; }
            else { SMAS_LINK.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void chkmrkOthrs_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkmrkOthrs.Checked)
            {
                Grievance_Identified_Marketing_Others.Visible = true;
            }
            else
            {
                Grievance_Identified_Marketing_Others.Visible = false;
                Marketing_Others_Text_Box.Text = "";
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    //protected void OtherSchemesChkList_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (OtherSchemesChkList.Items[0].Selected)
    //    { SCHEME_MAS_BLOCK.Visible = true; }
    //    else { SCHEME_MAS_BLOCK.Visible = false; Div1.Visible = false; NSIC_LINK.Visible = false; }

    //    if (OtherSchemesChkList.Items[1].Selected)
    //    { SCHEME_PMS_BLOCK.Visible = true; }
    //    else { SCHEME_PMS_BLOCK.Visible = false; Div2.Visible = false; MSME_LINK.Visible = false; }

    //    if (OtherSchemesChkList.Items[2].Selected)
    //    { SCHEME_SMAS_BLOCK.Visible = true; }
    //    else { SCHEME_SMAS_BLOCK.Visible = false; Div3.Visible = false; SMAS_LINK.Visible = false; }
    //}

    protected void chkFinancial_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            //if (Convert.ToString(ViewState["UIDNO"]) != "" || Applicant_Investment.Text != "")
            //{
            if (rdboardgrivance.SelectedValue == "")
            {
                chkFinancial.Checked = false;
                rdboardgrivance.Focus();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Broad Type of Guidance');", true);
                return;
            }
            if (chkFinancial.Checked)
            {
                if (TS_IPASS_REGISTERED_Unit.SelectedIndex != -1)
                {
                    lblfncgrv.Visible = false;
                    lblfncgdnc.Visible = false;
                    Financial_Types.Visible = false;

                    chckfinothers.Visible = true;

                    FinancialTypes.Visible = true; Financial_Block_OFF.Visible = true;
                    string UID = Convert.ToString(ViewState["UIDNO"]);
                    if ((UID != "" && UID.Contains("LRG")) || (UID != "" && UID.Contains("MEG") || (Applicant_Investment.Text != "" && Convert.ToInt64(Applicant_Investment.Text) > 100000000)))
                    {
                        chckonlineplatforms.Visible = false;
                    }
                    else
                    {
                        chckonlineplatforms.Visible = true;
                    }
                }
                else
                {
                    chkFinancial.Checked = false;
                    FinancialTypes.Visible = false;
                  

                    //lblmsg0.Text = "Please select TS-IPASS registered unit or not and then select marketing";
                    //Failure.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select TS-IPASS registered unit or not and then select Financial');", true);
                    return;
                }

            }
            else
            {
                FinancialTypes.Visible = false;
                Financial_Block_OFF.Visible = false;
                //Financial_Types.ClearSelection();
                //Financial_Types_SelectedIndexChanged(sender, e);

                department_issues_type.ClearSelection();
                MSEFCCase_Filed.ClearSelection();
                MSEFC_Case_Details.Text = "";
                MSEFCCase_Filed_No.ClearSelection();
                Invoice_Mart.ClearSelection();
                InvoiceMartID.Text = "";
                INVOICE_MART_Registration_DATE.Value = "";
                No_of_Orders_received_Invoice_Mart.Text = "";
                Order_Value_Invoice_Mart.Text = "";
                No_of_Bills_Invoice_Mart.Text = "";
                Bills_Value_Invoice_Mart.Text = "";
                No_of_Bills_Sold_Invoice_Mart.Text = "";
                NSE.ClearSelection();
                rblNSEawrns.ClearSelection();
                rblNSElisted.ClearSelection();
                SIDBI.ClearSelection();
                rblSIDBIofcrref.ClearSelection();

            }
            //}
            //else
            //{
            //    chkFinancial.Checked = false;
            //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select/Fill all details under the unit registered under TS-IPASS');", true);
            //    return;
            //}
        }
        catch (Exception ex)
        { throw ex; }

    }
    protected void Financial_Types_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Financial_Types.SelectedItem.Text == "Issues related to Department")
            {
                lblLand.Visible = true;
                Financial_Departmental_Issues.Visible = true;
                Invoice_Mart.ClearSelection(); Invoice_Mart_SelectedIndexChanged(sender, e);
                NSE.ClearSelection(); NSE_SelectedIndexChanged(sender, e);
                SIDBI.ClearSelection(); SIDBI_SelectedIndexChanged(sender, e);
                txtFinancialOthers.Text = "";
            }
            else
            {
                Financial_Departmental_Issues.Visible = false;
            }
            if (Financial_Types.SelectedItem.Text == "Online Platforms")
            {
                lblLand.Visible = true;
                Online_Financial_Platforms_Block.Visible = true;
                department_issues_type.ClearSelection(); department_issues_type_SelectedIndexChanged(sender, e);
                txtFinancialOthers.Text = "";
            }
            else
            {
                Online_Financial_Platforms_Block.Visible = false;
            }
            if (Financial_Types.SelectedItem.Text == "Others")
            {
                lblLand.Visible = true;
                divfinancialOthers.Visible = true;
            }
            else
            {
                divfinancialOthers.Visible = false; txtFinancialOthers.Text = "";
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void chckonlineplatforms_CheckedChanged(object sender, EventArgs e)
    {
        if (chckonlineplatforms.Checked == true)
        {
            lblLand.Visible = true;
            Online_Financial_Platforms_Block.Visible = true;
            department_issues_type.ClearSelection();
            department_issues_type_SelectedIndexChanged(sender, e);
        }
        else
        {
            Online_Financial_Platforms_Block.Visible = false;
        }
    }
    protected void Invoice_Mart_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Invoice_Mart.SelectedValue == "0")
            { Invoice_Mart_Yes.Visible = true; }

            else
            {
                rblIMofcrref.ClearSelection();
                Invoice_Mart_Yes.Visible = false;
                InvoiceMartID.Text = "";
                INVOICE_MART_Registration_DATE.Value = "";
                No_of_Orders_received_Invoice_Mart.Text = "";
                Order_Value_Invoice_Mart.Text = "";
                No_of_Bills_Invoice_Mart.Text = "";
                Bills_Value_Invoice_Mart.Text = "";
                No_of_Bills_Sold_Invoice_Mart.Text = "";
            }
            if (Invoice_Mart.SelectedValue == "1")
            {
                Invoice_Mart_No.Visible = true;
            }
            else
            {
                Invoice_Mart_No.Visible = false;
                rblIMawrns.ClearSelection();
                rblIMawrns_SelectedIndexChanged(sender, e);
                rblIMintrsted.ClearSelection();
                rblIMintrsted_SelectedIndexChanged(sender, e);
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void rblIMaftrCamps_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblIMaftrCamps.SelectedValue == "0")
        { trIMcampdate.Visible = true; }
        else { trIMcampdate.Visible = false; txtIMcampdate.Text = ""; }
    }
    protected void rblIMawrns_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblIMawrns.SelectedValue == "0")
            { trIMrtonbord.Visible = true; }
            else { trIMrtonbord.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void rblIMintrsted_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (rblIMintrsted.SelectedValue == "0")
            { trIMrtonbordlink.Visible = true; }
            else { trIMrtonbordlink.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }

    }
    protected void NSE_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (NSE.SelectedValue == "0")
            {
                NSE_YES.Visible = true;
                rblNSEawrns.ClearSelection(); rblNSEawrns_SelectedIndexChanged(sender, e);
                rblNSEintrsted.ClearSelection(); rblNSEintrsted_SelectedIndexChanged(sender, e);
            }
            else
            {
                NSE_YES.Visible = false; rblNSEofcrref.ClearSelection();
                rblNSEaftrCamps.ClearSelection(); txtNSEcampdate.Text = "";
                rblNSEFiled.ClearSelection();
                rblNSElisted.ClearSelection();
                rblNSEAudit.ClearSelection();
            }
            if (NSE.SelectedValue == "1")
            {
                NSE_No.Visible = true;
                rblNSEofcrref.ClearSelection();
                rblNSEaftrCamps.ClearSelection(); txtNSEcampdate.Text = "";
                rblNSEFiled.ClearSelection();
                rblNSElisted.ClearSelection();
                rblNSEAudit.ClearSelection();

            }
            else
            {
                NSE_No.Visible = false; rblNSEawrns.ClearSelection(); rblNSEawrns_SelectedIndexChanged(sender, e);
                rblNSEintrsted.ClearSelection(); rblNSEintrsted_SelectedIndexChanged(sender, e);
                txtNSEcampdate.Text = "";
                rblNSEFiled.ClearSelection();
                rblNSElisted.ClearSelection();
                rblNSEAudit.ClearSelection();
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void rblNSEaftrCamps_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblNSEaftrCamps.SelectedValue == "0")
        { trNSEcampdate.Visible = true; }
        else { trNSEcampdate.Visible = false; txtNSEcampdate.Text = ""; }
    }
    protected void rblNSEawrns_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblNSEawrns.SelectedValue == "0")
            { trNSEonbord.Visible = true; }
            else { trNSEonbord.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void rblNSEintrsted_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblNSEintrsted.SelectedValue == "0")
            { trNSEonbordlink.Visible = true; }
            else { trNSEonbordlink.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void SIDBI_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (SIDBI.SelectedValue == "0")
            { tblSidbiYes.Visible = true; }
            else
            {
                tblSidbiYes.Visible = false;
                rblSIDBIofcrref.ClearSelection(); rblSIDBIaftrCamps.ClearSelection();
                rblSIDBIaftrCamps_SelectedIndexChanged(sender, e);
            }
            if (SIDBI.SelectedValue == "1")
            { trsidbiawrns.Visible = true; }
            else
            {
                trsidbiawrns.Visible = false;
                rblSIDBIawrns.ClearSelection(); rblSIDBIawrns_SelectedIndexChanged(sender, e);
                rblSIDBIintrsted.ClearSelection(); rblSIDBIintrsted_SelectedIndexChanged(sender, e);
            }
            if (SIDBI.SelectedValue == "2")
            {
                tblSidbiYes.Visible = false;
                rblSIDBIofcrref.ClearSelection();
                rblSIDBIaftrCamps.ClearSelection();
                rblSIDBIaftrCamps_SelectedIndexChanged(sender, e);
                trsidbiawrns.Visible = false;
                rblSIDBIawrns.ClearSelection(); rblSIDBIawrns_SelectedIndexChanged(sender, e);
                rblSIDBIintrsted.ClearSelection(); rblSIDBIintrsted_SelectedIndexChanged(sender, e);

            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void rblSIDBIaftrCamps_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblSIDBIaftrCamps.SelectedValue == "0")
        { trSIDBIcampdate.Visible = true; }
        else { trSIDBIcampdate.Visible = false; txtSIDBIcampdate.Text = ""; }
    }
    protected void rblSIDBIawrns_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblSIDBIawrns.SelectedValue == "0")
            { trsidbiintrst.Visible = true; }
            else { trsidbiintrst.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void rblSIDBIintrsted_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblSIDBIintrsted.SelectedValue == "0")
            { trsidblink.Visible = true; }
            else { trsidblink.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }

    }
    protected void chckfinothers_CheckedChanged(object sender, EventArgs e)
    {
        if (chckfinothers.Checked == true)
        {
            lblLand.Visible = true;
            divfinancialOthers.Visible = true;
        }
        else
        {
            divfinancialOthers.Visible = false; txtFinancialOthers.Text = "";
        }
    }

    protected void chkLand_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (TS_IPASS_REGISTERED_Unit.SelectedIndex != -1)
            {
                if (rdboardgrivance.SelectedValue == "")
                {
                    chkLand.Checked = false;
                    rdboardgrivance.Focus();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Broad Type of Guidance');", true);
                    return;

                }
                if (chkLand.Checked)
                {
                    Land_Block.Visible = true;
                }
                else
                {
                    Land_Block.Visible = false;
                    Land_Grievance.ClearSelection();
                    Land_Grievance_SelectedIndexChanged(sender, e);
                    rblvacantplots.ClearSelection();
                    grdvacantplots.Visible = false;
                    TextBox1.Text = "";
                }
            }
            else 
            {
                Land_Block.Visible = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select TS-IPASS registered unit or not and then select marketing');", true);
                return;
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void Land_Grievance_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            
                if (Land_Grievance.SelectedValue == "0")
                {
                    TSIIC_LAND_Select.Visible = true;
                    getVacanplots();
                    TextBox1.Text = "";
                }
                else
                {
                    TSIIC_LAND_Select.Visible = false;
                    rblvacantplots.ClearSelection();
                }
                if (Land_Grievance.SelectedValue == "1")
                {
                    Land_Text_Box.Visible = true;
                    rblvacantplots.ClearSelection();
                    grdvacantplots.Visible = false;
                }
                else
                {
                    Land_Text_Box.Visible = false;
                    TextBox1.Text = "";
                }
           
        }
        catch (Exception ex)
        { throw ex; }
    }
    public void getVacanplots()
    {
        if (chkLand.Checked)
        {
            if (TS_IPASS_REGISTERED_Unit.SelectedIndex != -1)
            {
                if (TS_IPASS_REGISTERED_Unit.SelectedItem.Text == "No")
                {
                    if (Applicant_Gender.SelectedItem.Text != "--Select--" && Applicant_caste.SelectedItem.Text != "--Select--")
                    {
                        
                            DataSet ds = new DataSet();
                            con.OpenConnection();
                            SqlDataAdapter da = new SqlDataAdapter("Sp_GetVacanplots", con.GetConnection);
                            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand.Parameters.Add("@Districtid", SqlDbType.Int).Value = Convert.ToInt32(Convert.ToString(Session["DistrictID"]));
                            if (Applicant_Gender.Text == "Female")
                            {
                                da.SelectCommand.Parameters.Add("@GENDER", SqlDbType.VarChar).Value = "FEMALE";
                            }
                            else
                            { da.SelectCommand.Parameters.Add("@CATEGORY", SqlDbType.VarChar).Value = Applicant_caste.SelectedItem.Text.Trim(); }

                            da.Fill(ds);
                            con.CloseConnection();
                            grdvacantplots.DataSource = ds;
                            grdvacantplots.DataBind();
                            grdvacantplots.Visible = true;                        
                    }
                    else
                    {
                        TSIIC_LAND_Select.Visible = false; Land_Grievance.ClearSelection();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Gender and Social Status');", true);
                        return;
                    }
                }
                else
                {
                    DataSet ds = new DataSet();
                    con.OpenConnection();
                    SqlDataAdapter da = new SqlDataAdapter("Sp_GetVacanplots", con.GetConnection);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Districtid", SqlDbType.Int).Value = Convert.ToInt32(Convert.ToString(Session["DistrictID"]));
                    if (Convert.ToString(ViewState["Gender"]) == "Female")
                    {
                        da.SelectCommand.Parameters.Add("@GENDER", SqlDbType.VarChar).Value = "FEMALE";
                    }
                    else
                    { da.SelectCommand.Parameters.Add("@CATEGORY", SqlDbType.VarChar).Value = Convert.ToString(ViewState["caste"]); }

                    da.Fill(ds);
                    con.CloseConnection();
                    grdvacantplots.DataSource = ds;
                    grdvacantplots.DataBind();
                    grdvacantplots.Visible = true;
                }
            }
            else
            {
                chkLand.Checked = false;
                Land_Block.Visible = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select TS-IPASS registered unit or not and then select Land Type');", true);
                return;
            }
        }
    }
    protected void chkOthers_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (rdboardgrivance.SelectedValue == "")
            {
                chkOthers.Checked = false;
                rdboardgrivance.Focus();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Broad Type of Guidance');", true);
                return;
            }
            if (chkOthers.Checked)
            {
                Other_Grievance_Block.Visible = true;
            }
            else { Other_Grievance_Block.Visible = false; TextBox2.Text = ""; }
        }
        catch (Exception ex)
        { throw ex; }

    }
    protected void SubmitBtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (ModeOfInteraction.SelectedIndex != -1 && Women_Cell.SelectedIndex != -1 && TS_IPASS_REGISTERED_Unit.SelectedIndex != -1
                && LineOfActivity.SelectedIndex != -1 && rblsick.SelectedIndex != -1 && rblPMEGP.SelectedIndex != -1 &&
                Grievance_Identified.SelectedIndex != -1)
            {
                if (Women_Cell.SelectedValue == "0")
                {

                    if (Women_Cell.SelectedValue == "0" && Interaction_Level_Existing.SelectedValue == "0")
                    {

                        if (TextBox4.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please fill all details in women cell interatction');", true);
                            return;
                        }
                    }
                    else if (Women_Cell.SelectedValue == "0" && Interaction_Level_Existing.SelectedValue == "1")//district level
                    {
                        if (ddl_Mandal.SelectedIndex == -1 || ddlvenuemandl.SelectedIndex == 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please fill all details women cell interatction');", true);
                            return;
                        }
                        else
                        {
                            if (ddlvenuemandl.SelectedItem.Text == "Others")
                            {
                                if (Interaction_Venue.Text == "")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please enter Other Venue details women cell interatction');", true);
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please fill all details women cell interatction District level or Mandal level');", true);
                        return;
                    }
                }

                if (TS_IPASS_REGISTERED_Unit.SelectedValue == "0")
                {
                    if (DropDownList1.SelectedIndex == -1 || DropDownList2.SelectedIndex == -1 || TS_IPASS_UID_SEARCH.Text == "" || UID_SEARCH_GRID.Rows.Count == 0 || rblMSMEreg.SelectedIndex == -1 || txtemailExistng.Text == "" || txtmobileExistng.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please fill all details in unit regestered in TS-iPASS ');", true);
                        return;
                    }
                }
                else
                {
                    if (Applicant_Name.Text == "" || ddladrsmandal.SelectedIndex == 0 || ddladrsvlg.SelectedIndex == 0 || Applicant_Contact.Text == "" || Applicant_Email.Text == "" ||
                    Applicant_caste.SelectedIndex == -1 || Applicant_Gender.SelectedIndex == -1 || Applicant_Investment.Text == "" ||
                    Applicant_Employees.Text == "" || sector_dropdown.SelectedIndex == -1 || Enterprise_Sector.SelectedIndex == -1 || rblMSMEreg.SelectedIndex == -1 || Differently_able.SelectedIndex == -1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please fill all details of the unit');", true);
                        return;
                    }
                }
                if (Grievance_Identified.SelectedValue == "0")
                {
                    if (Grievance_Details.Text == "" || TextBox3.Text == "" || GrievanceStatus_dropdown.SelectedIndex == -1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please fill all details in Identified Grievance');", true);
                        return;
                    }
                }
                if (chkTechnical.Checked)
                {

                    if (rblTechnSchms.SelectedIndex == -1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Technical Grievance Type');", true);
                        return;
                    }
                    else if (rblTechnSchms.SelectedItem.Text == "TSIPASS" || rblTechnSchms.SelectedItem.Text == "Incentives" || rblTechnSchms.SelectedItem.Text == "Raw-Material")
                    {
                        if (TechnicalType_Grievance.SelectedIndex == 1)
                        {
                            if (ddlLineDepartment.SelectedItem.Text == "--Select--")
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Line Department Technical Grievance Type');", true);
                                return;
                            }
                        }
                        if (TechnicalType_Grievance.SelectedIndex == 2)
                        {
                            if (Technical_Others.Text == "")
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Other Technical Grievance Type');", true);
                                return;

                            }
                        }
                    }
                    else if (rblTechnSchms.SelectedItem.Text == "MSEFC")
                    {
                        //if (department_issues_type.SelectedIndex == -1)
                        //{
                        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Issues related to department');", true);
                        //    return;
                        //}
                        //else if (department_issues_type.SelectedIndex == 1)
                        //{
                        if (MSEFCCase_Filed.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select unit filed case under MSEFC or not');", true);
                            return;
                        }
                        else if (MSEFCCase_Filed.SelectedIndex == 0)
                        {
                            if (MSEFC_Case_Details.Text == "")
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter Details of  Case filed under MSEFC');", true);
                                return;
                            }
                        }
                        else if (MSEFCCase_Filed.SelectedIndex == 1)
                        {
                            if (MSEFCCase_Filed_No.SelectedIndex == -1)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Whether Awareness on Facilitation Council is given or not');", true);
                                return;
                            }
                        }

                        //}
                    }
                    else if (rblTechnSchms.SelectedItem.Text == "Others")
                    {
                        if (Technical_Others.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter Other Scheme details');", true);
                            return;
                        }
                    }
                }

                if (chkMarketing.Checked)
                {
                    if (!chkecommrce.Checked && !chkOtherSchms.Checked && !chkmrkOthrs.Checked)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Marketing Grievance Type');", true);
                        return;
                    }
                    if (chkecommrce.Checked)
                    {
                        if (rblMeesho.SelectedIndex != -1)
                        {
                            if (rblMeesho.SelectedItem.Text == "Yes")
                            {
                                if (rblmeeshoofcrref.SelectedIndex == -1 || rblMSaftrCamps.SelectedIndex == -1 || Meesho_Unique_ID.Text == "" || Meesho_Registration_Date.Value == "" || txtmeeshocount.Text == "" || txtmeeshovalue.Text == "")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter Meesho Platform details');", true);
                                    return;
                                }
                                if (rblMSaftrCamps.SelectedValue == "0" && txtMScampdate.Text == "")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter camp date in Meesho Platform details');", true);
                                    return;
                                }
                            }
                            else if (rblMeesho.SelectedItem.Text == "No")
                            {
                                if (Meesho_Awareness_No_List.SelectedIndex == -1 || Meesho_NO.SelectedIndex == -1 || rblMSintrsted.SelectedIndex == -1)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter Meesho Platform details');", true);
                                    return;

                                }
                            }
                            //else if (rblMeesho.SelectedItem.Text == "NA") { }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select onboarded on Meesho or not');", true);
                            return;
                        }
                        if (rblJustDial.SelectedIndex != -1)
                        {
                            if (rblJustDial.SelectedItem.Text == "Yes")
                            {
                                if (rbljustdialofcrref.SelectedIndex == -1 || rblJDaftrCamps.SelectedIndex == -1 || Just_Dial_ID.Text == "" || Just_Dial_Registration_Date.Value == "" || txtjstdialcount.Text == "" || txtjstdialvalue.Text == "")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter JustDial Platform details');", true);
                                    return;
                                }
                                if (rblJDaftrCamps.SelectedValue == "0" && txtJDcampdate.Text == "")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter camp date in JustDial Platform details');", true);
                                    return;
                                }
                            }
                            else if (rblJustDial.SelectedItem.Text == "No")
                            {
                                if (Just_Dial_Awareness_No_List.SelectedIndex == -1 || JustDialNOBtn.SelectedIndex == -1 || rblJDintrsted.SelectedIndex == -1)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter JustDial Platform details');", true);
                                    return;

                                }
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select onboarded on JustDial or not');", true);
                            return;
                        }
                        if (rblTSGlobal.SelectedIndex != -1)
                        {
                            if (rblTSGlobal.SelectedItem.Text == "Yes")
                            {
                                if (rblTSGofcrref.SelectedIndex == -1 || rblTSGaftrCamps.SelectedIndex == -1 || TS_Global_UNIQUE_ID.Text == "" || TS_Global_Registration_Date.Value == "" || txttsglobalcount.Text == "" || txttsglobalvalue.Text == "")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter TS_Global Linker Platform details');", true);
                                    return;
                                }
                                if (rblTSGaftrCamps.SelectedValue == "0" && txtTSGcampdate.Text == "")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter camp date in TSGlobal Linker Platform details');", true);
                                    return;
                                }
                            }
                            else if (rblTSGlobal.SelectedItem.Text == "No")
                            {
                                if (TS_GLOBAL_DETAILS_LIST.SelectedIndex == -1 || TS_Global_NO_BTN.SelectedIndex == -1 || rblTSGintrsted.SelectedIndex == -1)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter TS_Global Linker Platform details');", true);
                                    return;

                                }
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select onboarded on TS_Global Linker or not');", true);
                            return;
                        }
                        if (rblWallmart.SelectedIndex != -1)
                        {
                            if (rblWallmart.SelectedItem.Text == "Yes")
                            {
                                if (rblwallmartofcrref.SelectedIndex == -1 || rblWMVaftrCamps.SelectedIndex == -1 || Walmart_Vriddi_UNIQUE_ID.Text == "" || Walmart_Vriddi_Registration_Date.Value == "" || txtwallmartcount.Text == "" || txtwallmartvalue.Text == "")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter WallMart Vriddi Platform details');", true);
                                    return;
                                }
                                if (rblWMVaftrCamps.SelectedValue == "0" && txtWMVcampdate.Text == "")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter camp date in TSGlobal Linker Platform details');", true);
                                    return;
                                }
                            }
                            else if (rblWallmart.SelectedItem.Text == "No")
                            {
                                if (WALMART_VRIDDI_DETAILS_LIST.SelectedIndex == -1 || Walmart_Vriddi_NO_Btn.SelectedIndex == -1 || rblWMVintrsted.SelectedIndex == -1)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter WallMart Vriddi Platform details');", true);
                                    return;

                                }
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select onboarded on WallMart Vriddi or not');", true);
                            return;
                        }

                    }
                    if (chkOtherSchms.Checked)
                    {
                        if (rblMAS.SelectedIndex != -1)
                        {
                            if (rblMAS.SelectedItem.Text == "Yes")
                            {
                                if (rblMASawrns.SelectedIndex == 0)
                                {
                                    if (rblMASintrsted.SelectedIndex == -1)
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select interested to onBoard onto Marketing Assistance Scheme or not');", true);
                                        return;
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Awareness provided about the Marketing Assistance Scheme or not');", true);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Marketing Assistance Scheme (NSIC) is applicable or not');", true);
                            return;
                        }
                        if (rblPMS.SelectedIndex != -1)
                        {
                            if (rblPMS.SelectedItem.Text == "Yes")
                            {
                                if (rblPMSawrns.SelectedIndex != -1)
                                {
                                    if (rblPMSawrns.SelectedIndex == 0)
                                    {
                                        if (rblPMSintrsted.SelectedIndex == -1)
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select interested to onBoard onto Procurement and Marketing Assistance Scheme or not');", true);
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Awareness provided about the Procurement and Marketing Support Scheme or not');", true);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Procurement and Marketing Support Scheme (P&MS)-(MSME) is applicable or not');", true);
                            return;
                        }
                        if (rblSMAS.SelectedIndex != -1)
                        {
                            if (rblPMS.SelectedItem.Text == "Yes")
                            {
                                if (rblSMASawrns.SelectedIndex != -1)
                                {
                                    if (rblSMASawrns.SelectedIndex == 0)
                                    {
                                        if (rblSMASintrsted.SelectedIndex == -1)
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select interested to onBoard onto Special Marketing Assistance Scheme or not');", true);
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Awareness provided about the Special Marketing Support Scheme or not');", true);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Special Marketing Assistance Scheme (SMAS) is applicable or not');", true);
                            return;
                        }
                    }
                    if (chkmrkOthrs.Checked)
                    {
                        if (Marketing_Others_Text_Box.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter Other Type Marketing Grievance');", true);
                            return;
                        }
                    }

                }
                if (chkFinancial.Checked)
                {
                    if (chckonlineplatforms.Checked == false && chckfinothers.Checked == false)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Financial type');", true);
                        return;
                    }
                    else if (chckonlineplatforms.Checked == true)
                    {
                        if (Invoice_Mart.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select unit OnBoarded onto Invoice Mart or not');", true);
                            return;

                        }
                        else
                        {
                            if (Invoice_Mart.SelectedIndex == 0)
                            {
                                if (rblIMofcrref.SelectedIndex == -1 || rblIMaftrCamps.SelectedIndex == -1 || InvoiceMartID.Text == "" || INVOICE_MART_Registration_DATE.Value == "" || No_of_Orders_received_Invoice_Mart.Text == "" ||
                                    Order_Value_Invoice_Mart.Text == "" || No_of_Bills_Invoice_Mart.Text == "" || Bills_Value_Invoice_Mart.Text == ""
                                    || No_of_Bills_Sold_Invoice_Mart.Text == "")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter all details about Invoice Mart');", true);
                                    return;
                                }
                                if (rblIMaftrCamps.SelectedValue == "0" && txtIMcampdate.Text == "")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter camp date in Invoice Mart Platform details');", true);
                                    return;
                                }

                            }
                            else if (Invoice_Mart.SelectedIndex == 1)
                            {
                                if (rblIMawrns.SelectedIndex != -1)
                                {
                                    if (rblIMawrns.SelectedItem.Text == "Yes")
                                    {
                                        if (rblIMintrsted.SelectedIndex == -1)
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select unit is interested to onboard onto InvoiceMart or not');", true);
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select awarenss provided about Factoring/ inreverse Factoring');", true);
                                    return;
                                }
                            }

                        }
                        if (NSE.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select unit OnBoarded onto NSE or not');", true);
                            return;

                        }
                        else
                        {
                            if (NSE.SelectedIndex == 0)
                            {
                                if (rblNSEofcrref.SelectedIndex == -1 || rblNSEaftrCamps.SelectedIndex == -1 || rblNSEFiled.SelectedIndex == -1 || rblNSElisted.SelectedIndex == -1 || rblNSEAudit.SelectedIndex == -1)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please enter all details of NSE Platform');", true);
                                    return;
                                }
                                if (rblNSEaftrCamps.SelectedValue == "0" && txtNSEcampdate.Text == "")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter camp date in NSE details');", true);
                                    return;
                                }
                            }
                            else if (NSE.SelectedIndex == 1)
                            {
                                if (rblNSEawrns.SelectedIndex != -1)
                                {
                                    if (rblNSEawrns.SelectedItem.Text != "Yes")
                                    {
                                        if (rblNSEintrsted.SelectedIndex == -1)
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select unit is intersted to onboard on to NSE or not');", true);
                                        return;
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Awareness Provided on Listing NSE  or not');", true);
                                    return;
                                }
                            }
                        }
                        //if (SIDBI.SelectedIndex != -1)
                        //{
                        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select unit OnBoarded onto NSE or not');", true);
                        //    return;
                        //}
                        //else
                        //{
                        //    if (SIDBI.SelectedItem.Text == "Yes")
                        //    {
                        //        if (rblSIDBIofcrref.SelectedIndex == -1 || rblSIDBIaftrCamps.SelectedIndex == -1)
                        //        {
                        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select unit OnBoarded into SIDBI with officer reference or not');", true);
                        //            return;
                        //        }
                        //        if (rblSIDBIaftrCamps.SelectedValue == "0" && txtSIDBIcampdate.Text == "")
                        //        {
                        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter camp date in SIDBI details');", true);
                        //            return;
                        //        }
                        //    }
                        //    else if (SIDBI.SelectedItem.Text == "No")
                        //    {
                        //        if (rblSIDBIawrns.SelectedIndex != -1)
                        //        {
                        //            if (rblSIDBIintrsted.SelectedIndex == -1)
                        //            {
                        //                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select unit is intersted to onboard on to SIDBI or not');", true);
                        //                return;
                        //            }
                        //        }
                        //        else
                        //        {
                        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Awareness Provided on Listing SIDBI  or not');", true);
                        //            return;
                        //        }
                        //    }
                        //}
                    }
                }

                if (chkLand.Checked)
                {
                    if (Land_Grievance.SelectedIndex == -1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Land Type of Grievance related to');", true);
                        return;

                    }
                    else
                    {
                        if (TSIIC_LAND_Select.Visible == true && rblvacantplots.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select about TSIIC land');", true);
                            return;
                        }
                        if (Land_Text_Box.Visible == true && TextBox1.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please enter other type of land grievance');", true);
                            return;
                        }
                    }
                }
                if (Other_Grievance_Block.Visible == true && TextBox2.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please enter other grievance type');", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please fill all details');", true);
                return;
            }

            if (ViewState["ExtResult"].ToString() == "0")
            {

                string PiEEID = "", status = "", Meeshostatus = "", JustDialstatus = "", TSGlobalstatus = "", Wallmartstatus = "", Invoicemartstatus = "", NSEstatus = "";
                if (Request.QueryString.Count > 0)
                {
                    PiEEID = Convert.ToString(Request.QueryString["HdnEnterpreneur_ID"]);
                    status = Convert.ToString(Request.QueryString["Status"]);
                    Meeshostatus = Convert.ToString(Request.QueryString["HdnEnterpreneur_ID"]);
                    JustDialstatus = Convert.ToString(Request.QueryString["HdnEnterpreneur_ID"]);
                    TSGlobalstatus = Convert.ToString(Request.QueryString["HdnEnterpreneur_ID"]);
                    Wallmartstatus = Convert.ToString(Request.QueryString["HdnEnterpreneur_ID"]);
                    Invoicemartstatus = Convert.ToString(Request.QueryString["HdnEnterpreneur_ID"]);
                    NSEstatus = Convert.ToString(Request.QueryString["HdnEnterpreneur_ID"]);
                }

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString); ;
                conn.Open();
                SqlCommand command = new SqlCommand("DataBind_tbl_Existing_ENTREPRENEURS", conn);
                command.CommandType = CommandType.StoredProcedure;
                //DataTable EXISTING_ENTREPRENEUR_DATA = new DataTable();
                //con.OpenConnection();
                //using (SqlCommand command = new SqlCommand("DataBind_tbl_Existing_ENTREPRENEURS", con.GetConnection))      
                command.Parameters.AddWithValue("@ExistingID", PiEEID);
                command.Parameters.AddWithValue("@status", status);
                command.Parameters.AddWithValue("@Meeshostatus", Meeshostatus);
                command.Parameters.AddWithValue("@JustDialstatus", JustDialstatus);
                command.Parameters.AddWithValue("@TSGlobalstatus", TSGlobalstatus);
                command.Parameters.AddWithValue("@Invoicemartstatus", Invoicemartstatus);
                command.Parameters.AddWithValue("@NSEstatus", NSEstatus);

                command.Parameters.AddWithValue("@InteractionType", GetSelectedValue(ModeOfInteraction));
                command.Parameters.AddWithValue("@DateofInteraction", ToDBValue(intrctiondt.Value));
                string onlydt = intrctiondt.Value.Substring(0, 10);
                command.Parameters.AddWithValue("@onlyDateofInteraction", SqlDbType.Date).Value = DateTime.ParseExact(onlydt, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                command.Parameters.AddWithValue("@ThroughWomenCell", GetSelectedValue(Women_Cell));
                command.Parameters.AddWithValue("@forwdedtoWehub", chkwehub.Checked ? "Yes" : "No");

                command.Parameters.AddWithValue("@WomenCellIntrlevel", GetSelectedValue(Interaction_Level_Existing));
                command.Parameters.AddWithValue("@DistLevlIntractionDate", ToDBValue(Text1.Value));
                command.Parameters.AddWithValue("@DislevlIntractionVenue", ToDBValue(TextBox4.Text));
                command.Parameters.AddWithValue("@MandlLevlMandalName", GetSelectedValueddl(ddl_Mandal));
                //command.Parameters.AddWithValue("@Village", GetSelectedValue(ddl_Village));
                command.Parameters.AddWithValue("@MandlLevlIntractionDate", ToDBValue(Interaction_Date.Value));
                command.Parameters.AddWithValue("@MandllevlIntractionVenue", GetSelectedValueddl(ddlvenuemandl));
                command.Parameters.AddWithValue("@MandllevlIntractionOtherVenue", ToDBValue(Interaction_Venue.Text));
                command.Parameters.AddWithValue("@wmncellIntractionDate", ToDBValue(intrctiondt.Value));
                command.Parameters.AddWithValue("@TSiPASSReg", GetSelectedValue(TS_IPASS_REGISTERED_Unit));
                if (TS_IPASS_REGISTERED_Unit.SelectedItem.Text == "Yes")
                {
                    command.Parameters.AddWithValue("@mobileExistng", ToDBValue(txtmobileExistng.Text));
                    command.Parameters.AddWithValue("@emailExistng", ToDBValue(txtemailExistng.Text));
                    if (UID_SEARCH_GRID.Rows.Count > 0)
                    {
                        foreach (GridViewRow gvrow in UID_SEARCH_GRID.Rows)
                        {
                            CheckBox chk = (CheckBox)gvrow.FindControl("SelectCheckBox");

                            if (chk != null & chk.Checked)
                            {
                                Label Name = (Label)gvrow.FindControl("Applicant_Name");
                                Label UID = (Label)gvrow.FindControl("UIDNo");
                                Label ContactNo = (Label)gvrow.FindControl("applContact");
                                Label email = (Label)gvrow.FindControl("applEmail");
                                Label Caste = (Label)gvrow.FindControl("applCaste");
                                Label Gender = (Label)gvrow.FindControl("applGender");

                                command.Parameters.AddWithValue("@UIDno", UID.Text);
                                //command.Parameters.AddWithValue("@Name", gvrow.Cells[2].Text);
                                command.Parameters.AddWithValue("@Name", Name.Text);
                                command.Parameters.AddWithValue("@Address", gvrow.Cells[3].Text);
                                command.Parameters.AddWithValue("@Contact", ContactNo.Text);
                                command.Parameters.AddWithValue("@EmailId", email.Text);
                                command.Parameters.AddWithValue("@SocialCategory", Caste.Text);
                                command.Parameters.AddWithValue("@Gender", Gender.Text);
                                command.Parameters.AddWithValue("@Differentlyabled", gvrow.Cells[8].Text);
                                command.Parameters.AddWithValue("@Investment", gvrow.Cells[9].Text);
                                command.Parameters.AddWithValue("@Employment", gvrow.Cells[10].Text);
                                command.Parameters.AddWithValue("@LineOfActivity", gvrow.Cells[11].Text);
                                command.Parameters.AddWithValue("@LineOfActivityID", Convert.ToString(ViewState["LOAID"]));
                                command.Parameters.AddWithValue("@EnterpriseSector", gvrow.Cells[12].Text);
                                command.Parameters.AddWithValue("@IsMajor", Convert.ToString(ViewState["IsMajorExist"]));
                            }
                        }
                    }

                }
                else
                {
                    command.Parameters.AddWithValue("@mobileExistng", ToDBValue(txtmobileExistng.Text));
                    command.Parameters.AddWithValue("@emailExistng", ToDBValue(txtemailExistng.Text));
                    command.Parameters.AddWithValue("@UIDno", ToDBValue(""));
                    command.Parameters.AddWithValue("@Name", ToDBValue(Applicant_Name.Text));
                    command.Parameters.AddWithValue("@Address", GetSelectedValueddl(ddladrsmandal) + "," + GetSelectedValueddl(ddladrsvlg));
                    command.Parameters.AddWithValue("@Contact", ToDBValue(Applicant_Contact.Text));
                    command.Parameters.AddWithValue("@EmailId", ToDBValue(Applicant_Email.Text));
                    command.Parameters.AddWithValue("@SocialCategory", GetSelectedValueddl(Applicant_caste));
                    command.Parameters.AddWithValue("@Gender", GetSelectedValueddl(Applicant_Gender));
                    command.Parameters.AddWithValue("@Differentlyabled", Differently_able.SelectedItem.Text);
                    command.Parameters.AddWithValue("@Investment", ToDBValue(Applicant_Investment.Text));
                    command.Parameters.AddWithValue("@Employment", ToDBValue(Applicant_Employees.Text));
                    command.Parameters.AddWithValue("@LineOfActivity", GetSelectedValueddl(sector_dropdown));
                    command.Parameters.AddWithValue("@LineOfActivityID", sector_dropdown.SelectedValue);
                    command.Parameters.AddWithValue("@EnterpriseSector", GetSelectedValueddl(Enterprise_Sector));
                    command.Parameters.AddWithValue("@IsMajor", Convert.ToString(ViewState["IsMajorNew"]));
                }

                command.Parameters.AddWithValue("@isMSMEreg", GetSelectedValue(rblMSMEreg));
                command.Parameters.AddWithValue("@IsUnderODOP", GetSelectedValue(LineOfActivity));
                command.Parameters.AddWithValue("@IsSick", GetSelectedValue(rblsick));
                command.Parameters.AddWithValue("@forwdedtoHlthclinic", chkhlthclinc.Checked ? "Yes" : "No");

                command.Parameters.AddWithValue("@IsUnderPMEGP", GetSelectedValue(rblPMEGP));
                command.Parameters.AddWithValue("@PANno", ToDBValue(txtPAN.Text));
                command.Parameters.AddWithValue("@IsGrvnceIdentfd", GetSelectedValue(Grievance_Identified));
                command.Parameters.AddWithValue("@GrievanceDetails", ToDBValue(Grievance_Details.Text));
                command.Parameters.AddWithValue("@rdboardgrivance", GetSelectedValue(rdboardgrivance));


                //-------------------Marketring-----------------------------//
                command.Parameters.AddWithValue("@Gr_Marketing", chkMarketing.Checked ? "Yes" : "No");
                command.Parameters.AddWithValue("@GrM_ECommerce", chkecommrce.Checked ? "Yes" : "No");

                command.Parameters.AddWithValue("@GrMEC_Meesho", GetSelectedValue(rblMeesho));
                command.Parameters.AddWithValue("@GrMEC_MeeshorefbyOffcr", GetSelectedValue(rblmeeshoofcrref));
                command.Parameters.AddWithValue("@GrMEC_Meeshorefbycamp", GetSelectedValue(rblMSaftrCamps));
                if (txtMScampdate.Text == "")
                    command.Parameters.Add("@GrMEC_Meeshorefbycampdate", SqlDbType.Date).Value = ToDBValue(txtMScampdate.Text);
                else
                    command.Parameters.AddWithValue("@GrMEC_Meeshorefbycampdate", SqlDbType.Date).Value = DateTime.ParseExact(txtMScampdate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

                //command.Parameters.Add("@GrMEC_Meeshorefbycampdate", SqlDbType.Date).Value = DateTime.ParseExact(txtMScampdate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                command.Parameters.AddWithValue("@GrMEC_MeeshoId", ToDBValue(Meesho_Unique_ID.Text));
                if (Meesho_Registration_Date.Value == "")
                    command.Parameters.Add("@GrMEC_MeeshoRegDt", SqlDbType.Date).Value = ToDBValue(Meesho_Registration_Date.Value);
                else
                    command.Parameters.Add("@GrMEC_MeeshoRegDt", SqlDbType.Date).Value = DateTime.ParseExact(Meesho_Registration_Date.Value, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

                command.Parameters.AddWithValue("@GrMEC_MeeshoTranscount", ToDBValue(txtmeeshocount.Text));
                command.Parameters.AddWithValue("@GrMEC_MeeshoTransvalue", ToDBValue(txtmeeshovalue.Text));

                command.Parameters.AddWithValue("@GrMEC_MeeshobnftsIDs", ToDBValue(""));
                command.Parameters.AddWithValue("@GrMEC_MeeshoAwareness", GetSelectedValue(Meesho_NO));
                command.Parameters.AddWithValue("@GrMEC_MeeshoIntrsted", GetSelectedValue(rblMSintrsted));

                command.Parameters.AddWithValue("@GrMEC_JustDial", GetSelectedValue(rblJustDial));
                command.Parameters.AddWithValue("@GrMEC_JustDialrefbyOffcr", GetSelectedValue(rbljustdialofcrref));
                command.Parameters.AddWithValue("@GrMEC_JustDialrefbycamp", GetSelectedValue(rblJDaftrCamps));
                if (txtJDcampdate.Text == "")
                    command.Parameters.AddWithValue("@GrMEC_JustDialrefbycampdate", SqlDbType.Date).Value = ToDBValue(txtJDcampdate.Text);
                else
                    command.Parameters.AddWithValue("@GrMEC_JustDialrefbycampdate", SqlDbType.Date).Value = DateTime.ParseExact(txtJDcampdate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

                command.Parameters.AddWithValue("@GrMEC_JustDialId", ToDBValue(Just_Dial_ID.Text));
                if (Just_Dial_Registration_Date.Value == "")
                    command.Parameters.AddWithValue("@GrMEC_JustDialRegDt", SqlDbType.Date).Value = ToDBValue(Just_Dial_Registration_Date.Value);
                else
                    command.Parameters.AddWithValue("@GrMEC_JustDialRegDt", SqlDbType.Date).Value = DateTime.ParseExact(Just_Dial_Registration_Date.Value, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

                command.Parameters.AddWithValue("@GrMEC_JustDialTranscount", ToDBValue(txtjstdialcount.Text));
                command.Parameters.AddWithValue("@GrMEC_JustDialTransvalue", ToDBValue(txtjstdialvalue.Text));

                command.Parameters.AddWithValue("@GrMEC_JustDialbnftsIDs", ToDBValue(""));
                command.Parameters.AddWithValue("@GrMEC_JustDialAwareness", GetSelectedValue(JustDialNOBtn));
                command.Parameters.AddWithValue("@GrMEC_JustDialIntrsted", GetSelectedValue(rblJDintrsted));

                command.Parameters.AddWithValue("@GrMEC_TSGlobal", GetSelectedValue(rblTSGlobal));
                command.Parameters.AddWithValue("@GrMEC_TSGlobalrefbyOffcr", GetSelectedValue(rblTSGofcrref));
                command.Parameters.AddWithValue("@GrMEC_TSGlobalrefbycamp", GetSelectedValue(rblTSGaftrCamps));
                if (txtTSGcampdate.Text == "")
                    command.Parameters.AddWithValue("@GrMEC_TSGlobalrefbycampdate", SqlDbType.Date).Value = ToDBValue(txtTSGcampdate.Text);
                else
                    command.Parameters.AddWithValue("@GrMEC_TSGlobalrefbycampdate", SqlDbType.Date).Value = DateTime.ParseExact(txtTSGcampdate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

                command.Parameters.AddWithValue("@GrMEC_TSGlobalId", ToDBValue(TS_Global_UNIQUE_ID.Text));
                if (TS_Global_Registration_Date.Value == "")
                    command.Parameters.AddWithValue("@GrMEC_TSGlobalRegDt", SqlDbType.Date).Value = ToDBValue(TS_Global_Registration_Date.Value);
                else
                    command.Parameters.AddWithValue("@GrMEC_TSGlobalRegDt", SqlDbType.Date).Value = DateTime.ParseExact(TS_Global_Registration_Date.Value, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

                command.Parameters.AddWithValue("@GrMEC_TSGlobalTranscount", ToDBValue(txttsglobalcount.Text));
                command.Parameters.AddWithValue("@GrMEC_TSGlobalTransvalue", ToDBValue(txttsglobalvalue.Text));

                command.Parameters.AddWithValue("@GrMEC_TSGlobalbnftsIDs", ToDBValue(""));
                command.Parameters.AddWithValue("@GrMEC_TSGlobalAwareness", GetSelectedValue(TS_Global_NO_BTN));
                command.Parameters.AddWithValue("@GrMEC_TSGlobalIntrsted", GetSelectedValue(rblTSGintrsted));

                command.Parameters.AddWithValue("@GrMEC_Wallmart", GetSelectedValue(rblWallmart));
                command.Parameters.AddWithValue("@GrMEC_WallmartrefbyOffcr", GetSelectedValue(rblwallmartofcrref));
                command.Parameters.AddWithValue("@GrMEC_Wallmartrefbycamp", GetSelectedValue(rblWMVaftrCamps));
                if (txtWMVcampdate.Text == "")
                    command.Parameters.AddWithValue("@GrMEC_Wallmartrefbycampdate", SqlDbType.Date).Value = ToDBValue(txtWMVcampdate.Text);
                else
                    command.Parameters.AddWithValue("@GrMEC_Wallmartrefbycampdate", SqlDbType.Date).Value = DateTime.ParseExact(txtWMVcampdate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

                command.Parameters.AddWithValue("@GrMEC_WallmartId", ToDBValue(Walmart_Vriddi_UNIQUE_ID.Text));
                if (Walmart_Vriddi_Registration_Date.Value == "")
                    command.Parameters.AddWithValue("@GrMEC_WallmartRegDt", SqlDbType.Date).Value = ToDBValue(Walmart_Vriddi_Registration_Date.Value);
                else
                    command.Parameters.AddWithValue("@GrMEC_WallmartRegDt", SqlDbType.Date).Value = DateTime.ParseExact(Walmart_Vriddi_Registration_Date.Value, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                command.Parameters.AddWithValue("@GrMEC_WallmartTranscount", ToDBValue(txtwallmartcount.Text));
                command.Parameters.AddWithValue("@GrMEC_WallmartTransvalue", ToDBValue(txtwallmartvalue.Text));
                command.Parameters.AddWithValue("@GrMEC_WallmartbnftsIDs", ToDBValue(""));
                command.Parameters.AddWithValue("@GrMEC_WallmartAwareness", GetSelectedValue(Walmart_Vriddi_NO_Btn));
                command.Parameters.AddWithValue("@GrMEC_WallmartIntrsted", GetSelectedValue(rblWMVintrsted));

                command.Parameters.AddWithValue("@GrMEC_Others", ToDBValue(""));
                command.Parameters.AddWithValue("@GrMEC_OthersDetails", ToDBValue(""));

                command.Parameters.AddWithValue("@GrM_OtherSchemes", chkOtherSchms.Checked ? "Yes" : "No");

                command.Parameters.AddWithValue("@GrMOS_MarktngAsstScheme", GetSelectedValue(rblMAS));
                command.Parameters.AddWithValue("@GrMOS_MASawarness", GetSelectedValue(rblMASawrns));
                command.Parameters.AddWithValue("@GrMOS_MASinterested", GetSelectedValue(rblMASintrsted));

                command.Parameters.AddWithValue("@GrMOS_PandMS", GetSelectedValue(rblPMS));
                command.Parameters.AddWithValue("@GrMOS_PandMSawarness", GetSelectedValue(rblPMSawrns));
                command.Parameters.AddWithValue("@GrMOS_PandMSinterested", GetSelectedValue(rblPMSintrsted));

                command.Parameters.AddWithValue("@GrMOS_SMAS", GetSelectedValue(rblSMAS));
                command.Parameters.AddWithValue("@GrMOS_SMASawarness", GetSelectedValue(rblSMASawrns));
                command.Parameters.AddWithValue("@GrMOS_SMASinterested", GetSelectedValue(rblSMASintrsted));

                command.Parameters.AddWithValue("@GrM_Others", chkmrkOthrs.Checked ? "Yes" : "No");
                command.Parameters.AddWithValue("@GrM_OthersDetails", ToDBValue(Marketing_Others_Text_Box.Text));

                //-------------------Financial-----------------------------//
                command.Parameters.AddWithValue("@Gr_Financial", chkFinancial.Checked ? "Yes" : "No");
                //command.Parameters.AddWithValue("@GrF_Type", GetSelectedValueddl(Financial_Types));
                if (chckonlineplatforms.Checked == true)
                {
                    command.Parameters.AddWithValue("@GrF_Type", chckonlineplatforms.Text.Trim());
                }
                else
                {
                    command.Parameters.AddWithValue("@GrF_Type", null);
                }
                if (chckfinothers.Checked == true)
                {
                    command.Parameters.AddWithValue("@GrF_Type_Others", chckfinothers.Text.Trim());
                }
                else
                {
                    command.Parameters.AddWithValue("@GrF_Type_Others", null);
                }
                command.Parameters.AddWithValue("@GrFOLP_InvoiceMart", GetSelectedValue(Invoice_Mart));
                command.Parameters.AddWithValue("@GrFOLP_InvoiceMartrefbyOffcr", GetSelectedValue(rblIMofcrref));
                command.Parameters.AddWithValue("@GrFOLP_InvoiceMartID", ToDBValue(InvoiceMartID.Text));
                command.Parameters.AddWithValue("@GrFOLP_InvoiceMartrefbycamp", GetSelectedValue(rblIMaftrCamps));
                if (txtIMcampdate.Text == "")
                    command.Parameters.AddWithValue("@GrFOLP_InvoiceMartrefbycampdate", ToDBValue(txtIMcampdate.Text));
                else
                    command.Parameters.AddWithValue("@GrFOLP_InvoiceMartrefbycampdate", SqlDbType.Date).Value = DateTime.ParseExact(txtIMcampdate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

                if (INVOICE_MART_Registration_DATE.Value == "")
                    command.Parameters.AddWithValue("@GrFOLP_InvoiceMartRegDt", ToDBValue(INVOICE_MART_Registration_DATE.Value));
                else
                    command.Parameters.AddWithValue("@GrFOLP_InvoiceMartRegDt", DateTime.ParseExact(INVOICE_MART_Registration_DATE.Value, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));

                command.Parameters.AddWithValue("@GrFOLP_InvoiceMartOrdrsRcvdCount", ToDBValue(No_of_Orders_received_Invoice_Mart.Text));
                command.Parameters.AddWithValue("@GrFOLP_InvoiceMartOrdrsRcvdCost", ToDBValue(Order_Value_Invoice_Mart.Text));
                command.Parameters.AddWithValue("@GrFOLP_InvoiceMartBlsUploadedCount", ToDBValue(No_of_Bills_Invoice_Mart.Text));
                command.Parameters.AddWithValue("@GrFOLP_InvoiceMartBlsUploadedCost", ToDBValue(Bills_Value_Invoice_Mart.Text));
                command.Parameters.AddWithValue("@GrFOLP_InvoiceMartBlsSoldCount", ToDBValue(No_of_Bills_Sold_Invoice_Mart.Text));
                command.Parameters.AddWithValue("@GrFOLP_InvoiceMartAwrnsgvn", GetSelectedValue(rblIMawrns));
                command.Parameters.AddWithValue("@GrFOLP_InvoiceMartIntrsted", GetSelectedValue(rblIMintrsted));

                command.Parameters.AddWithValue("@GrFOLP_NSE", GetSelectedValue(NSE));
                command.Parameters.AddWithValue("@GrFOLP_NSErefbyOffcr", GetSelectedValue(rblNSEofcrref));
                command.Parameters.AddWithValue("@GrFOLP_NSErefbycamp", GetSelectedValue(rblNSEaftrCamps));
                if (txtNSEcampdate.Text == "")
                    command.Parameters.AddWithValue("@GrFOLP_NSErefbycampdate", ToDBValue(txtNSEcampdate.Text));
                else
                    //command.Parameters.AddWithValue("@GrFOLP_NSErefbycampdate", DateTime.ParseExact(txtNSEcampdate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                    command.Parameters.Add("@GrFOLP_NSErefbycampdate", SqlDbType.Date).Value = DateTime.ParseExact(txtNSEcampdate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");



                command.Parameters.AddWithValue("@GrFOLP_NSEFiled", GetSelectedValue(rblNSEFiled));
                command.Parameters.AddWithValue("@GrFOLP_NSEListedAbout", GetSelectedValue(rblNSElisted));
                command.Parameters.AddWithValue("@GrFOLP_NSEAudit", GetSelectedValue(rblNSEAudit));

                command.Parameters.AddWithValue("@GrFOLP_NSEAwarnessgiven", GetSelectedValue(rblNSEawrns));
                command.Parameters.AddWithValue("@GrFOLP_NSEIntrsted", GetSelectedValue(rblNSEintrsted));

                command.Parameters.AddWithValue("@GrFOLP_SIDBI", GetSelectedValue(SIDBI));
                command.Parameters.AddWithValue("@GrFOLP_SIDBIrefbyOffcr", GetSelectedValue(rblSIDBIofcrref));
                command.Parameters.AddWithValue("@GrFOLP_SIDBIrefbycamp", GetSelectedValue(rblSIDBIaftrCamps));
                if (txtSIDBIcampdate.Text == "")
                    command.Parameters.AddWithValue("@GrFOLP_SIDBIrefbycampdate", ToDBValue(txtSIDBIcampdate.Text));
                else
                    command.Parameters.AddWithValue("@GrFOLP_SIDBIrefbycampdate", DateTime.ParseExact(txtSIDBIcampdate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));


                command.Parameters.AddWithValue("@GrFOLP_SIDBIAwarnessgiven", GetSelectedValue(rblSIDBIawrns));
                command.Parameters.AddWithValue("@GrFOLP_SIDBIntrsted", GetSelectedValue(rblSIDBIintrsted));

                command.Parameters.AddWithValue("@GrF_Others", ToDBValue(txtFinancialOthers.Text));

                //----------------------Technacal-----------------------------//
                command.Parameters.AddWithValue("@Gr_Technical", chkTechnical.Checked ? "Yes" : "No");
                command.Parameters.AddWithValue("@GrT_SchemeType", GetSelectedValue(rblTechnSchms));
                command.Parameters.AddWithValue("@GrT_OtherScheme", ToDBValue(txttechschmsothrs.Text));

                command.Parameters.AddWithValue("@GrT_Type", GetSelectedValue(TechnicalType_Grievance));
                command.Parameters.AddWithValue("@GrT_LineDeptName", GetSelectedValueddl(ddlLineDepartment));
                command.Parameters.AddWithValue("@GrFDptIssue", GetSelectedValue(department_issues_type));
                command.Parameters.AddWithValue("@GrFDptIssue_CaseunderMSME", GetSelectedValue(MSEFCCase_Filed));
                command.Parameters.AddWithValue("@GrFDptIssue_CaseMSMEdetails", ToDBValue(MSEFC_Case_Details.Text));
                command.Parameters.AddWithValue("@GrFDptIssue_GivenFcltionCouncil", GetSelectedValue(MSEFCCase_Filed_No));

                command.Parameters.AddWithValue("@GrT_Others", ToDBValue(Technical_Others.Text));
                if (lbltchNA.Visible == true)
                    command.Parameters.AddWithValue("@GrT_NA", ToDBValue("Yes"));
                else
                    command.Parameters.AddWithValue("@GrT_NA", ToDBValue(""));

                //-------------------Land-----------------------------//
                command.Parameters.AddWithValue("@Gr_Land", chkLand.Checked ? "Yes" : "No");
                command.Parameters.AddWithValue("@GrL_Type", GetSelectedValue(Land_Grievance));
                command.Parameters.AddWithValue("@GrL_isInfrmdabtVacantPlts", GetSelectedValue(rblvacantplots));
                command.Parameters.AddWithValue("@GrL_Others", ToDBValue(TextBox1.Text));

                //-------------------Other Grievance-----------------------------//
                command.Parameters.AddWithValue("@Gr_Others", chkOthers.Checked ? "Yes" : "No");
                command.Parameters.AddWithValue("@GrOthersDetails", ToDBValue(TextBox2.Text));

                command.Parameters.AddWithValue("@GrievanceResolution", ToDBValue(TextBox3.Text));
                command.Parameters.AddWithValue("@GrievanceStatus", GetSelectedValueddl(GrievanceStatus_dropdown));
                command.Parameters.AddWithValue("@createdby", Convert.ToInt32(Session["uid"].ToString()));
                command.Parameters.AddWithValue("@DistrictID", Convert.ToInt32(Session["DistrictID"].ToString()));
                command.Parameters.AddWithValue("@ODOPEXPORT", GetSelectedValue(rdodpexport));
                command.Parameters.AddWithValue("@IncentiveIssue", GetSelectedValue(rdincentives));
                command.Parameters.AddWithValue("@RawmaterialIssue", GetSelectedValue(rdrawmaterial));
                command.Parameters.Add("@Result", SqlDbType.Int);
                command.Parameters["@Result"].Direction = ParameterDirection.Output;
                command.ExecuteNonQuery();
                int i = Convert.ToInt32(command.Parameters["@Result"].Value);
                ViewState["ExtResult"] = command.Parameters["@Result"].Value;
                con.CloseConnection();
                if (i > 0)
                {

                    SubmitBtn.Enabled = false; SubmitBtn.BackColor = Color.DarkGray;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('All Details are Submitted Successfully');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Some Internal Error occured,Details are not saved');", true);
                }
            }
        }
        catch (Exception ex)
        { throw ex; }

    }
    protected string ValidateControls()
    {
        string ErrorMsg = "";
        if (ModeOfInteraction.SelectedIndex == -1)
        {
            ErrorMsg = ErrorMsg + "Please Select Mode of Interaction \\n";
        }
        if (intrctiondt.Value == "")
        {
            ErrorMsg = ErrorMsg + "Please Select Date of Interaction \\n";
        }
        if (Women_Cell.SelectedIndex == -1)
        {
            ErrorMsg = ErrorMsg + "Please Select Interaction at Women cell or not \\n";
        }
        else if (Women_Cell.SelectedValue == "0")
        {
            if (Women_Cell.SelectedValue == "0" && Interaction_Level_Existing.SelectedValue == "0")
            {
                if (TextBox4.Text == "")
                {
                    ErrorMsg = ErrorMsg + "Please Enter Venue of Interaction at Women cell \\n";
                }
            }
            else if (Women_Cell.SelectedValue == "0" && Interaction_Level_Existing.SelectedValue == "1")
            {
                if (ddl_Mandal.SelectedIndex == -1 || ddlvenuemandl.SelectedIndex == 0)
                {
                    ErrorMsg = ErrorMsg + "Please Select Mandal and Venue of Interaction at Women cell \\n";
                }
                else
                {
                    if (ddlvenuemandl.SelectedItem.Text == "Others")
                    {
                        if (Interaction_Venue.Text == "")
                        {
                            ErrorMsg = ErrorMsg + "Please Enter other Venue details at Women cell \\n";
                        }
                    }
                }
            }
        }

        if (TS_IPASS_REGISTERED_Unit.SelectedIndex == -1)
        {
            ErrorMsg = ErrorMsg + "Please Select Whether the unit registered under TS-IPASS  \\n";
        }
        else if (TS_IPASS_REGISTERED_Unit.SelectedValue == "0")
        {
            if (DropDownList1.SelectedIndex == -1)
            {
                ErrorMsg = ErrorMsg + "Please Select Mandal of the unit registered under TS-IPASS  \\n";
            }
            if (DropDownList2.SelectedIndex == -1)
            {
                ErrorMsg = ErrorMsg + "Please Select Village the unit registered under TS-IPASS  \\n";
            }
            if (TS_IPASS_UID_SEARCH.Text == "")
            {
                ErrorMsg = ErrorMsg + "Please Enter UID/Unit Name of the unit registered under TS-IPASS  \\n";
            }
            if (UID_SEARCH_GRID.Rows.Count == 0)
            {
                //ErrorMsg = ErrorMsg + "Please Enter UID/Unit Name of the unit registered under TS-IPASS  \\n";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please fill all details in unit regestered in TS-iPASS ');", true);
            }
        }
        else if (TS_IPASS_REGISTERED_Unit.SelectedValue == "0")
        {
            if (Applicant_Name.Text == "")
            {
                ErrorMsg = ErrorMsg + "Please Enter Unit Name  \\n";
            }
            if (ddladrsmandal.SelectedItem.Text == "--Select--")
            {
                ErrorMsg = ErrorMsg + "Please select Address: Mandal of the unit   \\n";
            }
            if (ddladrsvlg.SelectedItem.Text == "--Select--")
            {
                ErrorMsg = ErrorMsg + "Please select Address: Village of the unit  \\n";
            }
            if (Applicant_Contact.Text == "")
            {
                ErrorMsg = ErrorMsg + "Please Enter Contact Number  \\n";
            }
            if (Applicant_Email.Text == "")
            {
                ErrorMsg = ErrorMsg + "Please Enter E-mail ID  \\n";
            }
            if (Applicant_caste.SelectedItem.Text == "--Select--")
            {
                ErrorMsg = ErrorMsg + "Please Select Social Category  \\n";
            }
            if (Applicant_Gender.SelectedItem.Text == "--Select--")
            {
                ErrorMsg = ErrorMsg + "Please Select Gender  \\n";
            }
            if (Applicant_Investment.Text == "")
            {
                ErrorMsg = ErrorMsg + "Please Enter Investment  \\n";
            }
            if (Applicant_Employees.Text == "")
            {
                ErrorMsg = ErrorMsg + "Please Enter Employment  \\n";
            }
            if (sector_dropdown.SelectedItem.Text == "--Select--")
            {
                ErrorMsg = ErrorMsg + "Please Select Line of Activity  \\n";
            }
            if (Enterprise_Sector.SelectedItem.Text == "--Select--")
            {
                ErrorMsg = ErrorMsg + "Please Select Enterprise Sector  \\n";
            }
        }
        if (LineOfActivity.SelectedIndex == -1)
        {
            ErrorMsg = ErrorMsg + "Please Select Whether  Line of Activity falls under ODOP or not  \\n";
        }
        if (LineOfActivity.SelectedIndex != -1)
        {
            if (rdodpexport.SelectedIndex == -1)
            {
                ErrorMsg = ErrorMsg + "Please Select Whether interest to Export or not  \\n";
            }
        }
        if (rblsick.SelectedIndex == -1)
        {
            ErrorMsg = ErrorMsg + "Please Select  Whether the unit is Sick or not  \\n";
        }
        if (rblPMEGP.SelectedIndex == -1)
        {
            ErrorMsg = ErrorMsg + "Please Select  Whether the unit established under PMEGP  or not  \\n";
        }
        if (Grievance_Identified.SelectedIndex == -1)
        {
            ErrorMsg = ErrorMsg + "Please Select  Whether any Grievance identified  or not  \\n";

        }

        //if (txtPAN.Text != "")
        //{
        //    ErrorMsg = ErrorMsg + "Please Enter Pan Card Details  \\n";
        //}     

        if (Grievance_Identified.SelectedValue == "0")
        {
            if (Grievance_Details.Text == "" || TextBox3.Text == "" || GrievanceStatus_dropdown.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please fill all details in Identified Grievance');", true);

            }
        }

        if (chkMarketing.Checked)
        {
            if (!chkecommrce.Checked && !chkOtherSchms.Checked && !chkmrkOthrs.Checked)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Marketing Grievance Type');", true);

            }
            if (chkecommrce.Checked)
            {
                if (rblMeesho.SelectedIndex != -1)
                {
                    if (rblMeesho.SelectedItem.Text == "Yes")
                    {
                        if (rblmeeshoofcrref.SelectedIndex == -1 || rblMSaftrCamps.SelectedIndex == -1 || Meesho_Unique_ID.Text == "" || Meesho_Registration_Date.Value == "" || txtmeeshocount.Text == "" || txtmeeshovalue.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter Meesho Platform details');", true);

                        }
                        if (rblMSaftrCamps.SelectedValue == "0" && txtMScampdate.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter camp date in Meesho Platform details');", true);

                        }
                    }
                    else if (rblMeesho.SelectedItem.Text == "No")
                    {
                        if (Meesho_Awareness_No_List.SelectedIndex == -1 || Meesho_NO.SelectedIndex == -1 || rblMSintrsted.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter Meesho Platform details');", true);


                        }
                    }
                    //else if (rblMeesho.SelectedItem.Text == "NA") { }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select onboarded on Meesho or not');", true);

                }
                if (rblJustDial.SelectedIndex != -1)
                {
                    if (rblJustDial.SelectedItem.Text == "Yes")
                    {
                        if (rbljustdialofcrref.SelectedIndex == -1 || rblJDaftrCamps.SelectedIndex == -1 || Just_Dial_ID.Text == "" || Just_Dial_Registration_Date.Value == "" || txtjstdialcount.Text == "" || txtjstdialvalue.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter JustDial Platform details');", true);

                        }
                        if (rblJDaftrCamps.SelectedValue == "0" && txtJDcampdate.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter camp date in JustDial Platform details');", true);

                        }
                    }
                    else if (rblJustDial.SelectedItem.Text == "No")
                    {
                        if (Just_Dial_Awareness_No_List.SelectedIndex == -1 || JustDialNOBtn.SelectedIndex == -1 || rblJDintrsted.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter JustDial Platform details');", true);


                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select onboarded on JustDial or not');", true);

                }
                if (rblTSGlobal.SelectedIndex != -1)
                {
                    if (rblTSGlobal.SelectedItem.Text == "Yes")
                    {
                        if (rblTSGofcrref.SelectedIndex == -1 || rblTSGaftrCamps.SelectedIndex == -1 || TS_Global_UNIQUE_ID.Text == "" || TS_Global_Registration_Date.Value == "" || txttsglobalcount.Text == "" || txttsglobalvalue.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter TS_Global Linker Platform details');", true);

                        }
                        if (rblTSGaftrCamps.SelectedValue == "0" && txtTSGcampdate.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter camp date in TSGlobal Linker Platform details');", true);

                        }
                    }
                    else if (rblTSGlobal.SelectedItem.Text == "No")
                    {
                        if (TS_GLOBAL_DETAILS_LIST.SelectedIndex == -1 || TS_Global_NO_BTN.SelectedIndex == -1 || rblTSGintrsted.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter TS_Global Linker Platform details');", true);


                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select onboarded on TS_Global Linker or not');", true);

                }
                if (rblWallmart.SelectedIndex != -1)
                {
                    if (rblWallmart.SelectedItem.Text == "Yes")
                    {
                        if (rblwallmartofcrref.SelectedIndex == -1 || rblWMVaftrCamps.SelectedIndex == -1 || Walmart_Vriddi_UNIQUE_ID.Text == "" || Walmart_Vriddi_Registration_Date.Value == "" || txtwallmartcount.Text == "" || txtwallmartvalue.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter WallMart Vriddi Platform details');", true);

                        }
                        if (rblWMVaftrCamps.SelectedValue == "0" && txtWMVcampdate.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter camp date in TSGlobal Linker Platform details');", true);

                        }
                    }
                    else if (rblWallmart.SelectedItem.Text == "No")
                    {
                        if (WALMART_VRIDDI_DETAILS_LIST.SelectedIndex == -1 || Walmart_Vriddi_NO_Btn.SelectedIndex == -1 || rblWMVintrsted.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter WallMart Vriddi Platform details');", true);


                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select onboarded on WallMart Vriddi or not');", true);

                }

            }
            if (chkOtherSchms.Checked)
            {
                if (!chkMAS.Checked && !chkPMS.Checked && !chkSMAS.Checked)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Marketing Grievance-Other Schemes Type');", true);

                }
                if (chkMAS.Checked)
                {
                    if (rblMASawrns.SelectedIndex != -1)
                    {
                        if (rblMASawrns.SelectedIndex == 0)
                        {
                            if (rblMASintrsted.SelectedIndex == -1)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select interested to onBoard onto Marketing Assistance Scheme or not');", true);

                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Awareness provided about the Marketing Assistance Scheme or not');", true);

                    }
                }
                if (chkPMS.Checked)
                {
                    if (rblPMSawrns.SelectedIndex != -1)
                    {
                        if (rblPMSawrns.SelectedIndex == 0)
                        {
                            if (rblPMSintrsted.SelectedIndex == -1)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select interested to onBoard onto Procurement and Marketing Assistance Scheme or not');", true);

                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Awareness provided about the Procurement and Marketing Support Scheme or not');", true);

                    }
                }
                if (chkSMAS.Checked)
                {
                    if (rblSMASawrns.SelectedIndex != -1)
                    {
                        if (rblSMASawrns.SelectedIndex == 0)
                        {
                            if (rblSMASintrsted.SelectedIndex == -1)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select interested to onBoard onto Special Marketing Assistance Scheme or not');", true);

                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Awareness provided about the Special Marketing Support Scheme or not');", true);

                    }
                }
            }
            if (chkmrkOthrs.Checked)
            {
                if (Marketing_Others_Text_Box.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter Other Type Marketing Grievance');", true);

                }
            }

        }
        if (chkFinancial.Checked)
        {
            if (Financial_Types.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Financial Grievance type');", true);

            }
            else if (Financial_Types.SelectedItem.Text == "Issues related to Department")
            {
                if (department_issues_type.SelectedIndex == -1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Issues related to department');", true);

                }
                else if (department_issues_type.SelectedIndex == 1)
                {
                    if (MSEFCCase_Filed.SelectedIndex == -1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select unit filed case under MSEFC or not');", true);

                    }
                    else if (MSEFCCase_Filed.SelectedIndex == 0)
                    {
                        if (MSEFC_Case_Details.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter Details of  Case filed under MSEFC');", true);

                        }
                    }
                    else if (MSEFCCase_Filed.SelectedIndex == 1)
                    {
                        if (MSEFCCase_Filed_No.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Whether Awareness on Facilitation Council is given or not');", true);

                        }
                    }

                }
            }
            else if (Financial_Types.SelectedItem.Text == "Online Platforms")
            {
                if (Invoice_Mart.SelectedIndex == -1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select unit OnBoarded onto Invoice Mart or not');", true);


                }
                else
                {
                    if (Invoice_Mart.SelectedIndex == 0)
                    {
                        if (rblIMofcrref.SelectedIndex == -1 || rblIMaftrCamps.SelectedIndex == -1 || InvoiceMartID.Text == "" || INVOICE_MART_Registration_DATE.Value == "" || No_of_Orders_received_Invoice_Mart.Text == "" ||
                            Order_Value_Invoice_Mart.Text == "" || No_of_Bills_Invoice_Mart.Text == "" || Bills_Value_Invoice_Mart.Text == ""
                            || No_of_Bills_Sold_Invoice_Mart.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter all details about Invoice Mart');", true);

                        }
                        if (rblIMaftrCamps.SelectedValue == "0" && txtIMcampdate.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter camp date in Invoice Mart Platform details');", true);

                        }

                    }
                    else if (Invoice_Mart.SelectedIndex == 1)
                    {
                        if (rblIMawrns.SelectedIndex != -1)
                        {
                            if (rblIMawrns.SelectedItem.Text == "Yes")
                            {
                                if (rblIMintrsted.SelectedIndex == -1)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select unit is interested to onboard onto InvoiceMart or not');", true);

                                }
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select awarenss provided about Factoring/ inreverse Factoring');", true);

                        }
                    }

                }
                if (NSE.SelectedIndex == -1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select unit OnBoarded onto NSE or not');", true);

                }
                else
                {
                    if (NSE.SelectedIndex == 0)
                    {
                        if (rblNSElisted.SelectedIndex == -1 || rblNSEofcrref.SelectedIndex == -1 || rblNSEaftrCamps.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Whether Listed about NSE Platform');", true);

                        }
                        if (rblNSEaftrCamps.SelectedValue == "0" && txtNSEcampdate.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter camp date in NSE details');", true);

                        }
                    }
                    else if (NSE.SelectedIndex == 1)
                    {
                        if (rblNSEawrns.SelectedIndex != -1)
                        {
                            if (rblNSEawrns.SelectedItem.Text == "Yes")
                            {
                                if (rblNSEintrsted.SelectedIndex == -1)
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select unit is intersted to onboard on to NSE or not');", true);

                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Awareness Provided on Listing NSE  or not');", true);

                        }
                    }
                }
                if (SIDBI.SelectedIndex == -1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select unit OnBoarded onto NSE or not');", true);

                }
                else
                {
                    if (SIDBI.SelectedItem.Text == "Yes")
                    {
                        if (rblSIDBIofcrref.SelectedIndex == -1 || rblSIDBIaftrCamps.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select unit OnBoarded into SIDBI with officer reference or not');", true);

                        }
                        if (rblSIDBIaftrCamps.SelectedValue == "0" && txtSIDBIcampdate.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter camp date in SIDBI details');", true);

                        }
                    }
                    else if (SIDBI.SelectedItem.Text == "No")
                    {
                        if (rblSIDBIawrns.SelectedIndex != -1)
                        {
                            if (rblSIDBIintrsted.SelectedIndex == -1)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select unit is intersted to onboard on to SIDBI or not');", true);

                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Awareness Provided on Listing SIDBI  or not');", true);

                        }
                    }
                }
            }
        }
        if (chkTechnical.Checked)
        {
            if (lbltchNA.Visible == false)
            {
                if (TechnicalType_Grievance.SelectedIndex == -1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Technical Grievance Type');", true);

                }
                else
                {
                    if (rblTechnSchms.SelectedIndex == 0)
                    {
                        if (TechnicalType_Grievance.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Issue Related');", true);
                        }
                        if (TechnicalType_Grievance.SelectedIndex == 1)
                        {
                            if (ddlLineDepartment.SelectedItem.Text == "--Select--")
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Line Department Technical Grievance Type');", true);

                            }
                        }
                        if (TechnicalType_Grievance.SelectedIndex == 2)
                        {
                            if (Technical_Others.Text == "")
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Other Technical Grievance Type');", true);
                            }
                        }
                    }
                    else if (rblTechnSchms.SelectedIndex == 1)
                    {
                        if (rdincentives.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Issue Related');", true);
                        }
                    }
                    else if (rblTechnSchms.SelectedIndex == 3)
                    {
                        if (rdrawmaterial.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Issue Related');", true);
                        }
                    }
                    else if (rblTechnSchms.SelectedIndex == 4)
                    {
                        if (MSEFCCase_Filed.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Whether Unit filed case under MSEFC');", true);
                        }
                    }
                }
            }
        }
        if (chkLand.Checked)
        {
            if (Land_Grievance.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Land Type of Grievance related to');", true);


            }
            else
            {
                if (TSIIC_LAND_Select.Visible == true && rblvacantplots.SelectedIndex == -1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select about TSIIC land');", true);

                }
                if (Land_Text_Box.Visible == true && TextBox1.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please enter other type of land grievance');", true);

                }
            }
        }
        if (Other_Grievance_Block.Visible == true && TextBox2.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please enter other grievance type');", true);

        }

        return ErrorMsg;
    }
    protected void ClearBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UI/TSIPASS/Personal_Interaction_Page_EXISTING_Entrepreneurs.aspx");
    }
    private object GetSelectedValue(ListControl control)
    {
        return control.SelectedItem != null ? (object)control.SelectedItem.Text : DBNull.Value;
    }
    private object GetSelectedValueddl(ListControl control)
    {
        return control.SelectedItem.Text != "--Select--" ? (object)control.SelectedItem.Text : DBNull.Value;
    }
    object ToDBValue(string str)
    {
        return string.IsNullOrEmpty(str) ? DBNull.Value : (object)str;
    }
    protected void Marketing_Types_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (Marketing_Types.Items[0].Selected)
            {
                Marketing_BLOCK_OFF.Visible = true;
                Grievance_Identified_Marketing_ECOMMERCE.Visible = true;
            }
            else
            {
                Grievance_Identified_Marketing_ECOMMERCE.Visible = false;
                clearecommercefeilds();
            }
            if (Marketing_Types.Items[1].Selected)
            {

                Marketing_BLOCK_OFF.Visible = true;
                Grievance_Identified_Marketing_Schemes.Visible = true;
            }
            else
            {
                Grievance_Identified_Marketing_Schemes.Visible = false;
                clearotherchemesfeilds();
            }
            if (Marketing_Types.Items[2].Selected)
            {

                Grievance_Identified_Marketing_Others.Visible = true;
                //clearecommercefeilds();
                //clearotherchemesfeilds();

            }
            else
            {
                Grievance_Identified_Marketing_Others.Visible = false;
                Marketing_Others_Text_Box.Text = "";
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void linkMSMECatlg_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://ipass.telangana.gov.in/UI/TSiPASS/frmcapturemsmenew.aspx";
            sendLinkbymail("MSME Catalogue", link);
            linkMSMECatlg.ForeColor = System.Drawing.Color.Gray;
            linkMSMECatlg.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }

    }
    protected void LinkMeesho_Click(object sender, EventArgs e)
    {
        try
        {
            //string link = "< a href = 'https://www.meesho.com/' target = '_blank' > Meeshow </ a >.";
            string link = "https://www.meesho.com/";

            sendLinkbymail("Meesho Online Platform", link);
            LinkMeesho.ForeColor = Color.DarkGray;
            LinkMeesho.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }

    }
    protected void LinkJustdial_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://www.justdial.com/";
            sendLinkbymail("Justdial Online Platform", link);
            LinkJustdial.ForeColor = Color.DarkGray;
            LinkJustdial.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void LinkTSGlobal_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://ts-msme.globallinker.com/' ";
            sendLinkbymail("TSGlobalLinker Online Platform", link);
            LinkTSGlobal.ForeColor = Color.DarkGray;
            LinkTSGlobal.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void LinkWallmart_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://www.walmartvriddhi.org/'";
            sendLinkbymail("walmartVriddhi Online Platform", link);
            LinkWallmart.ForeColor = Color.DarkGray;
            LinkWallmart.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void LinkMAS_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://www.nsic.co.in/schemes/MarketingAssistance' ";
            sendLinkbymail("Marketing Assistance Scheme", link);
            LinkMAS.ForeColor = Color.DarkGray;
            LinkMAS.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void LinkPMS_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://msme.gov.in/1-marketing-promotion-schemes' ";
            sendLinkbymail("Procurement and Marketing Support Scheme", link);
            LinkPMS.ForeColor = Color.DarkGray;
            LinkPMS.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void LinkSMAS_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://msme.gov.in/special-marketing-assistance-scheme' ";
            sendLinkbymail("Special Marketing Assistance Scheme", link);
            LinkSMAS.ForeColor = Color.DarkGray;
            LinkSMAS.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void LinkInvoice_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://www.invoicemart.com";
            sendLinkbymail("InvoiceMart Online Platform", link);
            LinkInvoice.ForeColor = Color.DarkGray;
            LinkInvoice.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void LinkNSE_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://www.nseindia.com";
            sendLinkbymail("NSE Online Platform", link);
            LinkNSE.ForeColor = Color.DarkGray;
            LinkNSE.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void SidbiLink_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://www.sidbi.in/en' ";
            sendLinkbymail("SIDBI Online Platform", link);
            SidbiLink.ForeColor = Color.DarkGray;
            SidbiLink.Enabled = false;

        }
        catch (Exception ex)
        { throw ex; }

    }
    protected void linkwehub_Click(object sender, EventArgs e)
    {
        try
        {
            chkwehub.Checked = true; chkwehub.Enabled = false;
            string link = "https://wehub.telangana.gov.in/ ";
            sendLinkbymail("WeHub", link);
            linkwehub.ForeColor = System.Drawing.Color.Gray;
            linkwehub.Enabled = false;
            chkwehub.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }

    }
    protected void chkhlthclinc_CheckedChanged(object sender, EventArgs e)
    {
        linkhealthclinic_Click(sender, e);

    }
    protected void chkwehub_CheckedChanged(object sender, EventArgs e)
    {
        linkwehub_Click(sender, e);
    }
    protected void linkhealthclinic_Click(object sender, EventArgs e)
    {
        try
        {
            chkhlthclinc.Checked = true; chkhlthclinc.Enabled = false;
            string link = "https://tihcl.telangana.gov.in ";
            sendLinkbymail("Health Clinic", link);
            linkhealthclinic.ForeColor = System.Drawing.Color.Gray;
            linkhealthclinic.Enabled = false;
            chkhlthclinc.Enabled = false;
            chkhlthclinc.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }

    }
    protected void lnkodop_Click(object sender, EventArgs e)
    {
        try
        {
            try
            {
                string link = "https://www.dgft.gov.in/CP/ ";
                sendLinkbymail("DGFT", link);
                lnkodop.ForeColor = System.Drawing.Color.Gray;
                lnkodop.Enabled = false;
            }
            catch (Exception ex)
            { throw ex; }
        }
        catch (Exception ex)
        {

        }
    }
    protected void lnkmsefc_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://esamadhan.nic.in/ ";
            sendLinkbymail("MSEFC", link);
            string message = "";
            //sendLinkbySMS("");
            lnkodop.ForeColor = System.Drawing.Color.Gray;
            lnkodop.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void sendLinkbymail(string platformname, string link)
    {
        try
        {
            string to = "";
            if (TS_IPASS_REGISTERED_Unit.SelectedIndex != -1)
            {
                if (TS_IPASS_REGISTERED_Unit.SelectedItem.Text == "Yes")
                { to = txtemailExistng.Text; }
                else if (TS_IPASS_REGISTERED_Unit.SelectedItem.Text == "No")
                { to = Applicant_Email.Text; }
            }
            if (to != "")
            {
                //< a href = 'https://www.sidbi.in/en' target = '_blank' > SIDBI </ a >.
                string from = "tsipass.telangana@gmail.com"; //Replace this with your own correct Gmail Address

                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.To.Add(to);
                mail.From = new MailAddress(from, ":: TSiPASS ::", System.Text.Encoding.UTF8);
                mail.Subject = platformname + "Link";
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.Body = "Dear Sir/madam, <br><br> This is the link of " + platformname + ": -" + "<a href = '" + link + "' target = '_blank' >" + platformname + "</a>" + " <br> Please click on the above link to know about " + platformname + "<br> <br>Regards,<br>Commissionerate of Industries,<br>MSME WING.";
                mail.BodyEncoding = System.Text.Encoding.UTF8;

                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                SmtpClient client = new SmtpClient();
                //Add the Creddentials- use your own email id and password

               // client.Credentials = new System.Net.NetworkCredential(from, "lrefskmlxnoowqtc");
                client.Credentials = new System.Net.NetworkCredential(from, "fqeq nive azke giwb");

                client.Port = 587; // Gmail works on this port lrefskmlxnoowqtc
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true; //Gmail works on Server Secured Layer tsipass@2016
                try
                {
                    client.Send(mail);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('An e-mail has been sent');", true);
                    //Session.Remove("File");
                    //Session.Remove("FileName");
                }
                catch (Exception ex)
                {
                    Exception ex2 = ex;
                    string errorMessage = string.Empty;
                    while (ex2 != null)
                    {
                        errorMessage += ex2.ToString();
                        ex2 = ex2.InnerException;
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Error occured, EMail not sent');", true);

                    //HttpContext.Current.Response.Write(errorMessage);
                } // end try
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected string sendLinkbySMS(string platformname, string link)
    {
        string username = "TSIPASS", password = "kcsb@786", senderid = "TSIPAS",
                secureKey = "e8750728-53e8-4f29-9bc9-9f06975accb0", message = "",
                templID = "", mobileno = "";
        message = "తేదీ:" + DateTime.Now.ToString("dd/MM/yyyy") + "న  జిల్లా పరిశ్రమల  కేంద్రంతో జరిగిన\r\n సంభాషణ ప్రకారం, మీరు అడిగిన" + platformname + " వివరాల కోసం ఇక్కడ క్లిక్ చేయండి" + link + "\r\nఇట్లు\r\nజిల్లా పరిశ్రమల  కేంద్రం\r\n" + "";
        if (TS_IPASS_REGISTERED_Unit.SelectedIndex != -1)
        {
            if (TS_IPASS_REGISTERED_Unit.SelectedItem.Text == "Yes")
            { mobileno = txtmobileExistng.Text; }
            else if (TS_IPASS_REGISTERED_Unit.SelectedItem.Text == "No")
            { mobileno = Applicant_Contact.Text; }
        }

        Stream dataStream;
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequestDLT");
        request.ProtocolVersion = HttpVersion.Version10;
        request.KeepAlive = false;
        request.ServicePoint.ConnectionLimit = 1;
        ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
        request.Method = "POST";

        string encryptedPassword = encryptedPasswod(password);
        string NewsecureKey = hashGenerator(username.Trim(), senderid.Trim(), message.Trim(), secureKey.Trim());
        string smsservicetype = "singlemsg";
        string query = "username=" + HttpUtility.UrlEncode(username.Trim()) +
            "&password=" + HttpUtility.UrlEncode(encryptedPassword) +
            "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +
            "&content=" + HttpUtility.UrlEncode(message.Trim()) +
            "&mobileno=" + HttpUtility.UrlEncode(mobileno) +
            "&senderid=" + HttpUtility.UrlEncode(senderid.Trim()) +
            "&key=" + HttpUtility.UrlEncode(NewsecureKey.Trim()) +
            "&templateid=" + HttpUtility.UrlEncode(templID.Trim());
        byte[] byteArray = Encoding.ASCII.GetBytes(query);
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = byteArray.Length;
        dataStream = request.GetRequestStream();
        dataStream.Write(byteArray, 0, byteArray.Length);
        dataStream.Close();
        WebResponse response = request.GetResponse();
        string Status = ((HttpWebResponse)response).StatusDescription;
        dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        string responseFromServer = reader.ReadToEnd();
        reader.Close();
        dataStream.Close();
        response.Close();
        return responseFromServer;
    }
    protected string hashGenerator(string Username, string sender_id, string message, string secure_key)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Username).Append(sender_id).Append(message).Append(secure_key);
        byte[] genkey = Encoding.UTF8.GetBytes(sb.ToString());
        HashAlgorithm sha1 = HashAlgorithm.Create("SHA512");
        byte[] sec_key = sha1.ComputeHash(genkey);
        StringBuilder sb1 = new StringBuilder();
        for (int i = 0; i < sec_key.Length; i++)
        {
            sb1.Append(sec_key[i].ToString("x2"));
        }
        return sb1.ToString();
    }
    protected string encryptedPasswod(string password)
    {
        byte[] encPwd = Encoding.UTF8.GetBytes(password);
        HashAlgorithm sha1 = HashAlgorithm.Create("SHA1");
        byte[] pp = sha1.ComputeHash(encPwd);
        StringBuilder sb = new StringBuilder();
        foreach (byte b in pp)
        {
            sb.Append(b.ToString("x2"));
        }
        return sb.ToString();
    }

}