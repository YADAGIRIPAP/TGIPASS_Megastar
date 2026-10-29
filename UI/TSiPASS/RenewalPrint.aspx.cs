using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class UI_TSiPASS_RenewalPrint : System.Web.UI.Page
{
    General clsGeneral = new General();
    DataSet ds = new DataSet();
    General Gen = new General();
    String ComplaintNo = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString[0].ToString() != "")
                {
                    ComplaintNo = Request.QueryString[0].ToString();
                    FillGrid();
                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    public void FillGrid()
    {
        try
        {
            ds = clsGeneral.GetApplicationFormRenewalDetails(ComplaintNo);

            //-------- td_EntrepreneurDetRen
            if (ds.Tables[0].Rows.Count != 0)
            {
                lblUidNo.Text = ds.Tables[0].Rows[0]["UID_No"].ToString().ToUpper();
                lblNameOfUndertaker.Text = ds.Tables[0].Rows[0]["INDUSNAME"].ToString().ToUpper();
                lblNameOfPromoter.Text = ds.Tables[0].Rows[0]["PROMOTORNAME"].ToString().ToUpper();
                lblSonOf.Text = ds.Tables[0].Rows[0]["SONOF"].ToString().ToUpper();
                lblEntAge.Text = ds.Tables[0].Rows[0]["AGE"].ToString();

                lblSurveyNo.Text = ds.Tables[0].Rows[0]["SURVEYNO"].ToString().ToUpper();
                if (ds.Tables[0].Rows[0]["DISTRICTT"].ToString().Trim() != "")
                {
                    lblDistrict0.Text = ds.Tables[0].Rows[0]["DISTRICTT"].ToString().ToUpper();
                }
                if (ds.Tables[0].Rows[0]["MANDALL"].ToString().Trim() != "")
                {
                    lblMandal0.Text = ds.Tables[0].Rows[0]["MANDALL"].ToString().ToUpper();
                }
                if (ds.Tables[0].Rows[0]["VILLAGEE"].ToString().Trim() != "")
                {
                    lblvillage0.Text = ds.Tables[0].Rows[0]["VILLAGEE"].ToString().ToUpper();
                }
                lblExtentofSightArea.Text = ds.Tables[0].Rows[0]["EXTENTAREA"].ToString().ToUpper();
                lblPincode0.Text = ds.Tables[0].Rows[0]["PINCODE"].ToString();
                lblDesignation.Text = ds.Tables[0].Rows[0]["DESIGNATION"].ToString().ToUpper();
                lblCellNo.Text = ds.Tables[0].Rows[0]["MOBILENO"].ToString();
                lblEmailId.Text = ds.Tables[0].Rows[0]["EMAILID"].ToString().ToUpper();
            }

            //-------- td_Factory_RenewalDet
            if (ds.Tables[1].Rows.Count != 0)
            {
                divfactory.Visible = true;
                lblregnno.Text = ds.Tables[1].Rows[0]["factoryRegistrationNumber"].ToString();
                lbllicno.Text = ds.Tables[1].Rows[0]["factoryLicenseNumber"].ToString().ToUpper();
                lblCircle.Text = ds.Tables[1].Rows[0]["factoryCircleName"].ToString();
                lblhp.Text = ds.Tables[1].Rows[0]["factoryHP"].ToString();
                lblcalYear.Text = ds.Tables[1].Rows[0]["selectedCalendarYear"].ToString();
                lblnoofyear.Text = ds.Tables[1].Rows[0]["selectedNumberOfLicenseYears"].ToString();
            }
            else
            {
                divfactory.Visible = false;
            }

            //-------- td_Boilers_RenewalDet
            if (ds.Tables[2].Rows.Count != 0)
            {
                lblTypeOfBoiler.Text = ds.Tables[2].Rows[0]["Type_Boiler"].ToString().ToUpper();
                lblBoilerRegNo.Text = ds.Tables[2].Rows[0]["Reg_No_Boiler"].ToString().ToUpper();
                lblBoilerUsedFor.Text = ds.Tables[2].Rows[0]["Boiler_User_for"].ToString().ToUpper();
                lblNameOfAgent.Text = ds.Tables[2].Rows[0]["Name_Owner"].ToString().ToUpper();
                lblBoilerLocation.Text = ds.Tables[2].Rows[0]["Location"].ToString();
                lblMaxEvaporation.Text = ds.Tables[2].Rows[0]["Max_Conti_Evapron"].ToString().ToUpper();

                lblBoilerRating.Text = ds.Tables[2].Rows[0]["Boiler_ration"].ToString().ToUpper();
                lblWP.Text = ds.Tables[2].Rows[0]["Allowed_Max_Presure"].ToString().ToUpper();
                //lblcertificateofboiler.Text = ds.Tables[2].Rows[0][""].ToString().ToUpper();
                //lblExpirydate.Text = ds.Tables[2].Rows[0][""].ToString();
                //lblInspectionrequired.Text = ds.Tables[2].Rows[0][""].ToString().ToUpper();

                lblregnnopipeline.Text = ds.Tables[2].Rows[0]["SteamRegno"].ToString().ToUpper();
                lbllengthOfSteamPipeline.Text = ds.Tables[2].Rows[0]["Tot_Lenght_Steam_PipeLine"].ToString().ToUpper();
                //lblExemptionofboiler.Text = ds.Tables[2].Rows[0][""].ToString().ToUpper();
                //lblinspectingauthority.Text = ds.Tables[2].Rows[0][""].ToString();
                //lblRemarks.Text = ds.Tables[2].Rows[0][""].ToString().ToUpper();
            }

            //-------- tbl_labour_renewal
            if (ds.Tables[3].Rows.Count != 0)
            {
                lblLabourregistrationno.Text = ds.Tables[3].Rows[0]["previous_registration_no"].ToString().ToUpper();
                lblPreviousrenewaldate.Text = ds.Tables[3].Rows[0]["previous_Renewaldate"].ToString().ToUpper();
                //lblCategory.Text = ds.Tables[3].Rows[0][""].ToString().ToUpper();
                lblMangerName.Text = ds.Tables[3].Rows[0]["manager_agent_name"].ToString().ToUpper();
                //lblFatherName.Text = ds.Tables[3].Rows[0][""].ToString();
                lblMgrAge.Text = ds.Tables[3].Rows[0]["manager_agent_age"].ToString().ToUpper();
            }
        }
        catch (Exception ex)
        {
        }
    }
}