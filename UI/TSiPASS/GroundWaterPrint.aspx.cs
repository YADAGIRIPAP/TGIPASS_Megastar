using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_TSiPASS_GroundWaterPrint : System.Web.UI.Page
{

    int GroundwaterID = 0;
    Cls_OSGroundWater obj_gw = new Cls_OSGroundWater();
    protected void Page_Load(object sender, EventArgs e)
    {
        Label8.Text = "Ground water Application";
        if (Session.Count <= 0)
        {
            Response.Redirect("../../frmUserLogin.aspx");
        }

        if (!IsPostBack)
        {
            if (Request.QueryString.Count > 0)
            {
                
                if(!string.IsNullOrEmpty(Convert.ToString(Request.QueryString[0])))
                {
                    if (Convert.ToString(Request.QueryString[0]) != null && Convert.ToString(Request.QueryString[0]) != "")
                    {
                        GroundwaterID = Convert.ToInt16(Request.QueryString[0]);
                    }
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
            }
            if (GroundwaterID > 0)
            {
                DataSet ds = obj_gw.GetGroundwaterDetailsbyGroundwaterIDforprint(GroundwaterID);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Label8.Text = "Application for digging a new well for " + Convert.ToString(ds.Tables[0].Rows[0]["ApplicationType_IndusorAgriName"]) + "  purpose";
                        //Label1.Text = "Form-5";
                        Label1.Text = Convert.ToString(ds.Tables[0].Rows[0]["Applicationheading"]);
                        //if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["ApplicationType_IndusorAgri"])))
                        //{
                        //    if (Convert.ToString(ds.Tables[0].Rows[0]["ApplicationType_IndusorAgri"]) == "2" || Convert.ToString(ds.Tables[0].Rows[0]["ApplicationType_IndusorAgri"]) == "3")
                        //    {
                        //        Label1.Text = "Form-2";
                        //    }
                        //}

                        //ApplicationType_IndusorAgri



                        Convert.ToString(ds.Tables[0].Rows[0]["ID"]);
                        lbl_applicationfordiggingawell.Text = Convert.ToString(ds.Tables[0].Rows[0]["ApplicationType_IndusorAgriName"]);
                        lbl_nameofapplicant.Text = Convert.ToString(ds.Tables[0].Rows[0]["ApplicantName"]);
                        lbl_district.Text = Convert.ToString(ds.Tables[0].Rows[0]["District_Name"]);
                        lbl_mandal.Text = Convert.ToString(ds.Tables[0].Rows[0]["Manda_lName"]);
                        lbl_village.Text = Convert.ToString(ds.Tables[0].Rows[0]["Village_Name"]);
                        
                        lbl_houseno.Text = Convert.ToString(ds.Tables[0].Rows[0]["HouseNo"]);
                        lbl_streetname.Text = Convert.ToString(ds.Tables[0].Rows[0]["Street"]);
                        lbl_Locationofproposedwell.Text = Convert.ToString(ds.Tables[0].Rows[0]["LocationOfWell"]);
                        lbl_typeofwelltodug.Text = Convert.ToString(ds.Tables[0].Rows[0]["TypeofWellName"]);
                        lbl_Modeofdrawingwater.Text = Convert.ToString(ds.Tables[0].Rows[0]["TypeOfDrwngWaterName"]);
                        lbl_SpeificationofPump.Text = Convert.ToString(ds.Tables[0].Rows[0]["SpecifactioncnOFPump"]);
                        lbl_Distancefromexistingfunctionalwell.Text = Convert.ToString(ds.Tables[0].Rows[0]["DistanceFromExistWell"]);
                        lbl_mobilenumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["ApplicantMobileNO"]);
                        lbl_EmailID.Text = Convert.ToString(ds.Tables[0].Rows[0]["ApplicantEmailID"]);
                        lbl_communicationaddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["communicationaddress"]);

                    }
                }
            }
        }
       
    }
}