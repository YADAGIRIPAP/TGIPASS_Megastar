using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_MobileTowerApplicationPrint : System.Web.UI.Page
{
    int TourismPerformanceLicenseID = 17083;
    General Gen = new General();
    Cls_UserMobileTower objmobile = new Cls_UserMobileTower();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session.Count <= 0)
        //{
        //    Response.Redirect("../../frmUserLogin.aspx");
        //}
        //if (Request.QueryString["MobileTowerId"] != null && Request.QueryString["MobileTowerId"].ToString() != "")
        //{
        //    TourismPerformanceLicenseID = Convert.ToInt16(Request.QueryString["MobileTowerId"]);
        //}
        if (!IsPostBack)
        {

        }
        DataSet ds = new DataSet();


        //ds = Gen.getTraineeDetails(hdfID.Value.ToString());
        DataSet dsd = new DataSet();
        //ddldistrict.Items.Clear();
        dsd = Gen.GetDistrictsWithoutHYD();


        ds = objmobile.RetriveMobileTowerApplicationDetails(TourismPerformanceLicenseID.ToString(), Session["uid"].ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {

            lblname.Text = Convert.ToString(ds.Tables[0].Rows[0]["ProviderCompanyname"]);

            lbldoor.Text = Convert.ToString(ds.Tables[0].Rows[0]["Door"]);
            lblroad.Text = Convert.ToString(ds.Tables[0].Rows[0]["Road"]);
            lblarea.Text = Convert.ToString(ds.Tables[0].Rows[0]["Area"]);
            lblmandal.Text = Convert.ToString(ds.Tables[0].Rows[0]["Mandal"]);
            lbldistrct.Text = Convert.ToString(ds.Tables[0].Rows[0]["Distrct"]);
            lblpin.Text = Convert.ToString(ds.Tables[0].Rows[0]["Pincode"]);
            lblmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
            lblplot.Text = Convert.ToString(ds.Tables[0].Rows[0]["Plotno"]);
            lbllayout.Text = Convert.ToString(ds.Tables[0].Rows[0]["Layoutno"]);
            lblsurvey.Text = Convert.ToString(ds.Tables[0].Rows[0]["Surveyno"]);
            lblrevward.Text = Convert.ToString(ds.Tables[0].Rows[0]["Wardno"]);
            lblrevblock.Text = Convert.ToString(ds.Tables[0].Rows[0]["Blockno"]);
            lbldoorno.Text = Convert.ToString(ds.Tables[0].Rows[0]["Doorno"]);
            lblstreetroad.Text = Convert.ToString(ds.Tables[0].Rows[0]["Streetroad"]);
            lblward.Text = Convert.ToString(ds.Tables[0].Rows[0]["Eelectionwardno"]);
            lblblock.Text = Convert.ToString(ds.Tables[0].Rows[0]["Electionblockno"]);

            ddlcircle.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Circle"]);
            lblcircle.Text = ddlcircle.SelectedItem.Text;
            // ddlloc.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Locality"]);
            if (Convert.ToString(ds.Tables[0].Rows[0]["Locality"]) == "--Select--")
            {
                txtloc.Text = "";
            }

            lblaarea.Text = Convert.ToString(ds.Tables[0].Rows[0]["Proposedarea"]);

            for (int i = 0; i < dsd.Tables[0].Rows.Count; i++)
            {
                if (Convert.ToString(ds.Tables[0].Rows[0]["Proposeddistrict"]) == Convert.ToString(dsd.Tables[0].Rows[i]["District_Id"]))
                {
                    lbldistrict.Text = Convert.ToString(dsd.Tables[0].Rows[i]["District_Name"]);
                }
            }
            DataSet dsm = new DataSet();
            dsm = Gen.GetMandals(ds.Tables[0].Rows[0]["Proposeddistrict"].ToString());
            if (Convert.ToString(ds.Tables[0].Rows[0]["Proposedmandal"]) == "--Mandal--")
            {
                lblproposedmandal.Text = "";
            }
            else
            {
                for (int i = 0; i < dsm.Tables[0].Rows.Count; i++)
                {
                    if (Convert.ToString(ds.Tables[0].Rows[0]["Proposedmandal"]) == Convert.ToString(dsm.Tables[0].Rows[i]["Mandal_Id"]))
                    {
                        lblproposedmandal.Text = Convert.ToString(dsm.Tables[0].Rows[i]["Manda_lName"]);
                    }
                }
            }

            lblgpsdd.Text = Convert.ToString(ds.Tables[0].Rows[0]["Gpsddegree"]);
            lblgpsmm.Text = Convert.ToString(ds.Tables[0].Rows[0]["Gpsmminit"]);
            lblgpsss.Text = Convert.ToString(ds.Tables[0].Rows[0]["Gpsseconds"]);

            lbldocument.Text = Convert.ToString(ds.Tables[0].Rows[0]["Siteareaasperdocment_cdma"]);
            lblsubplan.Text = Convert.ToString(ds.Tables[0].Rows[0]["Siteareaasperplan_cdma"]);
            lblwidenarea.Text = Convert.ToString(ds.Tables[0].Rows[0]["Roadwideningarea_cdma"]);
            lblnet.Text = Convert.ToString(ds.Tables[0].Rows[0]["Netarea_cdma"]);
            lbleast.Text = Convert.ToString(ds.Tables[0].Rows[0]["East"]);
            lblwest.Text = Convert.ToString(ds.Tables[0].Rows[0]["West"]);
            lblnorth.Text = Convert.ToString(ds.Tables[0].Rows[0]["North"]);
            lblsouth.Text = Convert.ToString(ds.Tables[0].Rows[0]["South"]);
            ddlproposal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Proposals_cdma"]);
            lblproposal.Text = ddlproposal.SelectedItem.Text;
            //rdaccroom.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Accessoryroom"]);
            if (Convert.ToString(ds.Tables[0].Rows[0]["Accessoryroom"]) == "Y")
            {
                lblaccroom.Text = "YES";
            }
            else
            {
                lblaccroom.Text = "NO";
            }
            if (Convert.ToString(ds.Tables[0].Rows[0]["Genaretorroom"]) == "Y")
            {
                lblgenroom.Text = "YES";
            }
            else
            {
                lblgenroom.Text = "NO";
            }
            //rdgenroom.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Genaretorroom"]);
            ddlproposed.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Proposedonbilding_cdma"]);
            if (ds.Tables[0].Rows[0]["Proposedonbilding_cdma"].ToString() == "--Select--")
            {
                lblproposed.Text = "";
            }
            lblvltno.Text = Convert.ToString(ds.Tables[0].Rows[0]["Vacantlandtaxidno"]);
            lblptino.Text = Convert.ToString(ds.Tables[0].Rows[0]["propertytaxidno"]);
            lblperno.Text = Convert.ToString(ds.Tables[0].Rows[0]["Buildingpermissionno_cdma"]);
            lblocccer.Text = Convert.ToString(ds.Tables[0].Rows[0]["Occpancycertificateno_cdma"]);

            // rdtbtncon.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Towerconstruction"]);
            if (Convert.ToString(ds.Tables[0].Rows[0]["Towerconstruction"]) == "E")
            {
                lbltbtncon.Text = "Existing";
            }
            else
            {
                lbltbtncon.Text = "New";
            }

            lblowner.Text = Convert.ToString(ds.Tables[0].Rows[0]["Ownername"]);
            ddlnet.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Networkagency"]);
            lblnetwork.Text = ddlnet.SelectedItem.Text;

            if (Convert.ToString(ds.Tables[0].Rows[0]["Licenseagreement"]) == "Y")
            {
                lbllessee.Text = "YES";
            }
            else
            {
                lbllessee.Text = "NO";
            }
            lblleaseyears.Text = Convert.ToString(ds.Tables[0].Rows[0]["Leaseyears"]);
            // rdnauagent.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["AuthorisedAgent"]);

            if (Convert.ToString(ds.Tables[0].Rows[0]["AuthorisedAgent"]) == "Y")
            {
                lblnauagent.Text = "YES";
            }
            else
            {
                lblnauagent.Text = "NO";
            }
            lblauagentname.Text = Convert.ToString(ds.Tables[0].Rows[0]["AuthorisedAgentName"]);
            lblarchitectname.Text = Convert.ToString(ds.Tables[0].Rows[0]["Architectname"]);
            lblarchitectno.Text = Convert.ToString(ds.Tables[0].Rows[0]["Architectno"]);
            lblarchitectaddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["Architectaddress"]);
            lblengname.Text = Convert.ToString(ds.Tables[0].Rows[0]["Engineername"]);
            lblengno.Text = Convert.ToString(ds.Tables[0].Rows[0]["Engineerlicesenceno"]);
            lblengaddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["Engineeraddress"]);
            lblsurvename.Text = Convert.ToString(ds.Tables[0].Rows[0]["Surveyorname"]);
            lblsurveno.Text = Convert.ToString(ds.Tables[0].Rows[0]["Surveyorno"]);
            lblsurveaddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["Surveyoraddress"]);
            lblstreng.Text = Convert.ToString(ds.Tables[0].Rows[0]["Structuralengneer"]);
            lblstrenglicno.Text = Convert.ToString(ds.Tables[0].Rows[0]["Structuralengneerlicno"]);



        }


    }
}