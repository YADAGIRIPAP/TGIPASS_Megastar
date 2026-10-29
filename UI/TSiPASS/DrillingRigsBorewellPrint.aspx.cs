using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_TSiPASS_DrillingRigsBorewellPrint : System.Web.UI.Page
{
    int GroundwaterID = 0;
    Cls_DrillingRigs obj_gw = new Cls_DrillingRigs();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session.Count <= 0)
        {
            Response.Redirect("../../frmUserLogin.aspx");
        }

        if (!IsPostBack)
        {
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["Qnreid"] != null && Request.QueryString["Qnreid"].ToString() != "")
                {
                    GroundwaterID = Convert.ToInt16(Request.QueryString["Qnreid"]);
                }
                if (Request.QueryString["intApplid"] != null && Request.QueryString["intApplid"].ToString() != "")
                {
                    GroundwaterID = Convert.ToInt16(Request.QueryString["intApplid"]);
                }
                if (Request.QueryString["intApplicationId"] != null && Request.QueryString["intApplicationId"].ToString() != "")
                {
                    GroundwaterID = Convert.ToInt16(Request.QueryString["intApplicationId"]);
                }
            }
            if (GroundwaterID > 0)
            {
                DataSet ds = obj_gw.GetDetailsbyDrillingRigsIDforprint(GroundwaterID);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

//                        a.Applicationtypeid,a.AddDistrictId,a.AddMandalid,a.AddVillageid,a.RTODistrictID,a.Isactive,a.CreatedOn,a.CreatedBy,a.CreatedIP,a.ModifiedOn,  
//a.ModifiedBy,  a.ModifiedIP,  a.AppStatus,  a.Stageid,  a.PaymentDate,  a.UIDNO,  a.DWGODeptid,  a.DWGOApprovalid,  a.FeeAmount,  a.PaymentDone
                        Convert.ToString(ds.Tables[0].Rows[0]["RegRigID"]);
                        lbl_applicationtype.Text = Convert.ToString(ds.Tables[0].Rows[0]["Applicationtype"]);
                        lbl_nameofapplicant.Text = Convert.ToString(ds.Tables[0].Rows[0]["Nameoftheapplicant"]);
                        lbl_district.Text = Convert.ToString(ds.Tables[0].Rows[0]["AddDistrictName"]);
                        lbl_mandal.Text = Convert.ToString(ds.Tables[0].Rows[0]["AddMandalname"]);
                        lbl_village.Text = Convert.ToString(ds.Tables[0].Rows[0]["AddVillagename"]);
                        lbl_houseno.Text = Convert.ToString(ds.Tables[0].Rows[0]["Houseno"]);
                        lbl_streetname.Text = Convert.ToString(ds.Tables[0].Rows[0]["Street"]);
                        lbl_registrationvehicleno.Text = Convert.ToString(ds.Tables[0].Rows[0]["regvehicleno"]);
                        lbl_placeregwithrto.Text = Convert.ToString(ds.Tables[0].Rows[0]["rtoplaceofregvehicle"]);
                        lbl_RTOregistration.Text = Convert.ToString(ds.Tables[0].Rows[0]["RTODistrictName"]);
                        lbl_Descriptionofthedrillingrig.Text = Convert.ToString(ds.Tables[0].Rows[0]["Descofdrillrigs"]);
                        lbl_maxdiameterdepth.Text = Convert.ToString(ds.Tables[0].Rows[0]["maxdiameterdepth"]);
                        lbl_Areaofoperation.Text = Convert.ToString(ds.Tables[0].Rows[0]["Areaofoperation"]);

                        lbl_contactmobileno.Text = Convert.ToString(ds.Tables[0].Rows[0]["ApplicantMobileno"]);
                        lbl_contactemailId.Text = Convert.ToString(ds.Tables[0].Rows[0]["ApplicantEmailID"]);
                    }
                }
            }
        }
    }
}