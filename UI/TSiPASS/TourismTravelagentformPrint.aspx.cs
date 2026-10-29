using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Mail;
//using TSIPassBE;
//using TSIPassBL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Text;

public partial class UI_TSiPASS_TourismTravelagentformPrint : System.Web.UI.Page
{
    int TravelAgentID = 0;
    General Gen = new General();
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("../../frmUserLogin.aspx");
        }
        if (Request.QueryString["TravelAgentID"] != null && Request.QueryString["TravelAgentID"].ToString() != "")
        {
            TravelAgentID = Convert.ToInt16(Request.QueryString["TravelAgentID"]);
        }
        if (Request.QueryString["intApplid"] != null && Request.QueryString["intApplid"].ToString() != "")
        {
            TravelAgentID = Convert.ToInt16(Request.QueryString["intApplid"]);
        }
        if (TravelAgentID == 0)
        {
            int CreatedBy = Convert.ToInt32(Session["uid"]);
            DataSet dsTourismData = Gettouragentfortravagentidforprint(CreatedBy);
            if (dsTourismData != null && dsTourismData.Tables.Count > 0)
            {
                if (dsTourismData.Tables[0].Rows.Count > 0)
                {
                    Session["Applid"] = Convert.ToString(dsTourismData.Tables[0].Rows[0]["TravelAgentID"]);
                    TravelAgentID = Convert.ToInt32(dsTourismData.Tables[0].Rows[0]["TravelAgentID"]);
                }
            }
        }
        if (!IsPostBack)
        {
           
        }
        DataSet ds = Gettouragentfortravagentidforprint(TravelAgentID);
        if(ds.Tables.Count>0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {

                Convert.ToString(ds.Tables[0].Rows[0]["TravelAgentID"]);
                lbl_nameoftheagency.Text=Convert.ToString(ds.Tables[0].Rows[0]["NameoftheAgency"]);
                lbl_nameofowner.Text = Convert.ToString(ds.Tables[0].Rows[0]["NameoftheOwner"]);
                lbl_mobileno.Text = Convert.ToString(ds.Tables[0].Rows[0]["MobileNo"]);
                lbl_emailid.Text = Convert.ToString(ds.Tables[0].Rows[0]["EmailID"]);
                lbl_aadhaar.Text = Convert.ToString(ds.Tables[0].Rows[0]["AadhaarNo"]);
                lbl_appliedfor.Text = Convert.ToString(ds.Tables[0].Rows[0]["Appliedfor"]);
                lbl_tickettravel.Text = Convert.ToString(ds.Tables[0].Rows[0]["Agencyarrangementsoftickets"]);
                lbl_accod.Text = Convert.ToString(ds.Tables[0].Rows[0]["Agencyarrangementstransport"]);
                lbl_sports.Text = Convert.ToString(ds.Tables[0].Rows[0]["AgencyAdventureTourism"]);
                lbl_sightseeing.Text = Convert.ToString(ds.Tables[0].Rows[0]["Agencyprovidingtouristtransport"]);
                lbl_headbranch.Text = Convert.ToString(ds.Tables[0].Rows[0]["Applyingfor"]);
                lbl_DOCOB.Text = Convert.ToString(ds.Tables[0].Rows[0]["DateofCommencementoftheBusiness"]);

                lbl_conofagency.Text = Convert.ToString(ds.Tables[0].Rows[0]["ConstitutionoftheAgency"]);
                lbl_premises.Text = Convert.ToString(ds.Tables[0].Rows[0]["Whetherthepremisesis"]);
                lbl_officedetails.Text = Convert.ToString(ds.Tables[0].Rows[0]["OfficeSpace"]);
                lbl_receptionarea.Text = Convert.ToString(ds.Tables[0].Rows[0]["ReceptionArea"]);
                lbl_locationarea.Text = Convert.ToString(ds.Tables[0].Rows[0]["LocationArea"]);
                lbl_officeaddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["Address"]);
                lbl_district.Text = Convert.ToString(ds.Tables[0].Rows[0]["District"]);
                lbl_pincode.Text = Convert.ToString(ds.Tables[0].Rows[0]["PINCode"]);
                lbl_officephoneno.Text = Convert.ToString(ds.Tables[0].Rows[0]["PhoneNo"]);
                lbl_officefaxno.Text = Convert.ToString(ds.Tables[0].Rows[0]["FAXNo"]);
                lbl_officemobileno.Text = Convert.ToString(ds.Tables[0].Rows[0]["MobileNoOffice"]);
                lbl_officeemailid.Text = Convert.ToString(ds.Tables[0].Rows[0]["EmailIDOffice"]);
                lbl_officewebsite.Text = Convert.ToString(ds.Tables[0].Rows[0]["Website"]);


                lbl_qualifiedstaff.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoofqualifiedStaff"]);
                lbl_experstaff.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoofexperiencedStaff"]);
                lbl_staffemployed.Text = Convert.ToString(ds.Tables[0].Rows[0]["TotalNoofStaffEmployed"]);
                lbl_paidcapital.Text = Convert.ToString(ds.Tables[0].Rows[0]["Paidupcapital"]);
                lbl_preturnover.Text = Convert.ToString(ds.Tables[0].Rows[0]["PreviousTurnover"]);
                lbl_panno.Text = Convert.ToString(ds.Tables[0].Rows[0]["PANNoFinancial"]);
                lbl_preyearitreturns.Text = Convert.ToString(ds.Tables[0].Rows[0]["PreviousYearITReturns"]);
                lbl_gstno.Text = Convert.ToString(ds.Tables[0].Rows[0]["GSTNoFinancial"]);
                lbl_bankaccount.Text = Convert.ToString(ds.Tables[0].Rows[0]["BankAccountDetails"]);
                lbl_bankaddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["EnclosereferenceletterfromBank"]);
                lbl_isavailtradelicense.Text = Convert.ToString(ds.Tables[0].Rows[0]["DoyourequireTradeLicense"]);
                lbl_isavailestlicense.Text = Convert.ToString(ds.Tables[0].Rows[0]["DoyourequireShopsEstablishmentLicense"]);
                lbl_registered.Text = Convert.ToString(ds.Tables[0].Rows[0]["WhetherregisteredwithanyTourismDepartment"]);
                lbl_noofvehicles.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoofTouristVehicles"]);
                Convert.ToString(ds.Tables[0].Rows[0]["CreatedBy"]);
                Convert.ToString(ds.Tables[0].Rows[0]["CreatedDate"]);
            }
        }

    }

    protected void lnk_draftcopy_Click(object sender, EventArgs e)
    {

    }

    public DataSet Gettouragentfortravagentidforprint(int createdby)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("tour_getregtravelagentbytravelagentID_View", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@createdby", SqlDbType.Int).Value = createdby;
            da.Fill(ds);
            return ds;
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