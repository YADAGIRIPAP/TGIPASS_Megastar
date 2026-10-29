using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_TSiPASS_waltaform6A : System.Web.UI.Page
{
    string Applicantid = "";
    string downloadfilename = "Form6A";
    Cls_OSGroundWater obj = new Cls_OSGroundWater();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("~/tshome.aspx");
            }
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString[0] != null)
                {
                    if (!IsPostBack)
                    {
                        Applicantid = Convert.ToString(Request.QueryString[0]);
                        DataSet ds = obj.DB_getformapprovalrejectdata(Convert.ToInt32(Applicantid));
                        if (ds != null)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                lbl_nameofapplicant.Text = Convert.ToString(ds.Tables[0].Rows[0]["ApplicantName"]);
                                lbl_address.Text = Convert.ToString(ds.Tables[0].Rows[0]["AddressApplicant"]);
                                lbl_location.Text = Convert.ToString(ds.Tables[0].Rows[0]["LocationOfWell"]);
                                lbl_rejectedreason.Text = Convert.ToString(Request.QueryString["Reason"]);
                                lbl_currentdate.Text = Convert.ToString(DateTime.Now);
                                if (Convert.ToString(ds.Tables[0].Rows[0]["ApplicationType_IndusorAgri"]) == "2")
                                {
                                    lbl_depthofwater.Text = Convert.ToString(ds.Tables[0].Rows[0]["ApplicationType_IndusorAgriName"]) + "    Well";
                                    lbl_typeofappl.Text = Convert.ToString(ds.Tables[0].Rows[0]["ApplicationType_IndusorAgriName"]) + "    Well";
                                }
                                else
                                {
                                    lbl_depthofwater.Text = Convert.ToString(ds.Tables[0].Rows[0]["ApplicationType_IndusorAgriName"]);
                                    lbl_typeofappl.Text = Convert.ToString(ds.Tables[0].Rows[0]["ApplicationType_IndusorAgriName"]) + "    Well";
                                }
                                //lbl_typeofappl
                            }
                        }
                    }

                }
            }


        }
        catch (Exception ex)
        {

        }
    }
}