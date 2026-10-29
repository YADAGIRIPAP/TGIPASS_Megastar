using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_TSiPASS_CinematographicLicensePrint : System.Web.UI.Page
{
    int cinemlicenseid = 0;
    General Gen = new General();
    Cls_Multiplex objmultiplex = new Cls_Multiplex();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("../../frmUserLogin.aspx");
        }

        if (Request.QueryString["cinemlicenseid"] != null && Request.QueryString["cinemlicenseid"].ToString() != "")
        {
            cinemlicenseid = Convert.ToInt16(Request.QueryString["cinemlicenseid"]);
        }
        else
        {

            if (Request.QueryString[0] != null && Request.QueryString[0].ToString() != "")
            {
                cinemlicenseid = Convert.ToInt16(Request.QueryString[0].ToString());
            }
        }
        if (!IsPostBack)
        {

        }
        DataSet ds = objmultiplex.GetCinemaLicensedetails(cinemlicenseid);
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                Convert.ToString(ds.Tables[0].Rows[0]["cinemalicenseid"]);
                lblstatusandexperience.Text = ds.Tables[0].Rows[0]["noofexpyears"].ToString();
                lbl9bfileno.Text = ds.Tables[0].Rows[0]["Fileno_9B"].ToString();
                lblbyildingreferancedate.Text = ds.Tables[0].Rows[0]["Rererancedate"].ToString();
                lbllongevitydate.Text = ds.Tables[0].Rows[0]["LongevityCertificateDate"].ToString();
                lblelectricalcertificatedate.Text = ds.Tables[0].Rows[0]["ElectricalCertificateDate"].ToString();

                lblnocfiredate.Text = ds.Tables[0].Rows[0]["NocDate"].ToString();
                lbllicenseperiod.Text = ds.Tables[0].Rows[0]["LicensePeriod"].ToString();
                if (ds.Tables[0].Rows[0]["TheatreType"].ToString() == "N")
                {
                    lbltheatretype.Text = "Multiplex";
                }
                else
                {
                    lbltheatretype.Text = "Single Screen Theatre";
                }
               
                lblnoofscreens.Text = ds.Tables[0].Rows[0]["Noofscreens"].ToString();
                lblnoofshows.Text = ds.Tables[0].Rows[0]["Noofshows"].ToString();

                lbl_applicantname.Text= ds.Tables[0].Rows[0]["ApplicantName"].ToString();
                lbl_district.Text= ds.Tables[0].Rows[0]["ApplicantDistrict_Name"].ToString();
                lbl_mandal.Text= ds.Tables[0].Rows[0]["ApplicantManda_lName"].ToString();
                lbl_village.Text= ds.Tables[0].Rows[0]["ApplicantVillage_Name"].ToString();
                lbl_plotno.Text= ds.Tables[0].Rows[0]["ApplicantPlotNo"].ToString();
                lblpincode.Text= ds.Tables[0].Rows[0]["ApplicantPINCODE"].ToString();
                
                lblownername.Text= ds.Tables[0].Rows[0]["OwnerName"].ToString();
                lbldistrict_owner.Text= ds.Tables[0].Rows[0]["District_Name"].ToString();
                lblmandal_owner.Text= ds.Tables[0].Rows[0]["Manda_lName"].ToString();
                lblvillage_owner.Text= ds.Tables[0].Rows[0]["Village_Name"].ToString();
                lblplotno_owner.Text= ds.Tables[0].Rows[0]["OwnerPlotNo"].ToString();
                lblpincode_owner.Text= ds.Tables[0].Rows[0]["OwnerPINCODE"].ToString();

                lblcommissionerate.Text = ds.Tables[0].Rows[0]["Commissionerate_Name"].ToString();
                lblzone.Text = ds.Tables[0].Rows[0]["zone_name"].ToString();
                lbldivision.Text = ds.Tables[0].Rows[0]["division_name"].ToString();
                lblpolicestation.Text = ds.Tables[0].Rows[0]["policestation_name"].ToString();
                lbltrafficzone.Text = ds.Tables[0].Rows[0]["Traffic_zone_name"].ToString();
                lbltrafficdivision.Text = ds.Tables[0].Rows[0]["Traffic_division_name"].ToString();
                lbltrafficpolicestation.Text = ds.Tables[0].Rows[0]["Traffic_policestation_name"].ToString();

                Convert.ToString(ds.Tables[0].Rows[0]["UID_no"]);
                //Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                //Convert.ToString(ds.Tables[0].Rows[0]["MobileNumber"]);

                Convert.ToString(ds.Tables[0].Rows[0]["App_Status"]);
                //Convert.ToString(ds.Tables[0].Rows[0]["PaymentDate"]);
                //Convert.ToString(ds.Tables[0].Rows[0]["Mandal"]);
                //Convert.ToString(ds.Tables[0].Rows[0]["Taluk"]);
                //Convert.ToString(ds.Tables[0].Rows[0]["District"]);
                //Convert.ToString(ds.Tables[0].Rows[0]["CreatedDate"]);
                //Convert.ToString(ds.Tables[0].Rows[0]["CreatedBy"]);

            }
        }
    }
}