using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_TSiPASS_FilmShootingPrint : System.Web.UI.Page
{
    int filmshootingid = 0;
    General Gen = new General();
    Cls_Filmshooting objfilm = new Cls_Filmshooting();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("../../frmUserLogin.aspx");
        }

        if (Request.QueryString["filmshootingid"] != null && Request.QueryString["filmshootingid"].ToString() != "")
        {
            filmshootingid = Convert.ToInt16(Request.QueryString["filmshootingid"]);
        }
        else
        {

            if (Request.QueryString[0] != null && Request.QueryString[0].ToString() != "")
            {
                filmshootingid = Convert.ToInt16(Request.QueryString[0].ToString());
            }
        }
        if (!IsPostBack)
        {

        }
        DataSet ds = objfilm.GetFilmShootingDetails(filmshootingid);
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                
                Convert.ToString(ds.Tables[0].Rows[0]["intfilmshootingid"]);
                lblproductionagencname.Text= ds.Tables[0].Rows[0]["ProductionAgencyName"].ToString();
                lblcompGSTN.Text = ds.Tables[0].Rows[0]["CompanyGSTIN"].ToString();

                lblAgency_district.Text = ds.Tables[0].Rows[0]["District_Name_P"].ToString();
                lblAgency_mandal.Text = ds.Tables[0].Rows[0]["Manda_lName_P"].ToString();
                lblAgency_village.Text = ds.Tables[0].Rows[0]["Village_Name_P"].ToString();
                lblAgency_plotno.Text = ds.Tables[0].Rows[0]["Permanent_PlotNo"].ToString();
                lblAgency_pincode.Text = ds.Tables[0].Rows[0]["Permanent_PINCODE"].ToString();
               
                   lbltempdist .Text = ds.Tables[0].Rows[0]["District_Name_T"].ToString();
                lbltempmandal.Text = ds.Tables[0].Rows[0]["Manda_lName_T"].ToString();
                lbltempvillage.Text = ds.Tables[0].Rows[0]["Village_Name_T"].ToString();
                lbltempplotno.Text = ds.Tables[0].Rows[0]["Temperory_PlotNo"].ToString();
                lbltemppincode.Text = ds.Tables[0].Rows[0]["Temperory_PINCODE"].ToString();
                lblagencyphoneno1.Text = ds.Tables[0].Rows[0]["AgencyPhno1"].ToString();
                lblAgency_district.Text = ds.Tables[0].Rows[0]["AgencyPhno2"].ToString();

                lblproducername.Text = ds.Tables[0].Rows[0]["Produccername"].ToString();
                lbldistrict_producer.Text = ds.Tables[0].Rows[0]["District_Name_PR"].ToString();
                lblmandal_producer.Text = ds.Tables[0].Rows[0]["Manda_lName_PR"].ToString();
                lblvillage_producer.Text = ds.Tables[0].Rows[0]["Village_Name_PR"].ToString();
                lblplotno_producer.Text = ds.Tables[0].Rows[0]["ProducerPlotNo"].ToString();
                lblpincode_producer.Text = ds.Tables[0].Rows[0]["ProducerPINCODE"].ToString();
                lblproducerphno1.Text = ds.Tables[0].Rows[0]["ProducerPhno1"].ToString();
                lblprodcerphno2.Text = ds.Tables[0].Rows[0]["ProducerPhno2"].ToString();
                lblemailid.Text = ds.Tables[0].Rows[0]["ProducerEmailId"].ToString();

                if(ds.Tables[0].Rows[0]["Tradebody"].ToString()=="Y")
                {
                    trtradebodydetails.Visible = true;
                    lbltradebody.Text = "YES";
                    lbltradebodydetails.Text= ds.Tables[0].Rows[0]["Tradebodydetails"].ToString();
                }
                else
                {
                    trtradebodydetails.Visible = false;
                    lbltradebody.Text = "NO";
                }
               
                lblfilmtitle.Text = ds.Tables[0].Rows[0]["Filmtitle"].ToString();
                if(ds.Tables[0].Rows[0]["Filmlanguage"].ToString()=="4")
                {
                    trotherlangage.Visible = true;
                    lblotherlanage.Text = ds.Tables[0].Rows[0]["Otherlanguage"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Filmlanguage"].ToString() == "1")
                {
                    lbllanguage.Text = "TELUGU";
                }
                if (ds.Tables[0].Rows[0]["Filmlanguage"].ToString() == "2")
                {
                    lbllanguage.Text = "HINDI";
                }
                if (ds.Tables[0].Rows[0]["Filmlanguage"].ToString() == "3")
                {
                    lbllanguage.Text = "ENGLISH";
                }
                if (ds.Tables[0].Rows[0]["Filmtype"].ToString() == "5")
                {
                    trotherfilmtype.Visible = true;
                    lblothertype.Text = ds.Tables[0].Rows[0]["Othertype"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Filmtype"].ToString() == "1")
                {
                    lblfilmtype.Text = "Children Film";
                }
                if (ds.Tables[0].Rows[0]["Filmtype"].ToString() == "2")
                {
                    lblfilmtype.Text = "Docmentary Film";
                }
                if (ds.Tables[0].Rows[0]["Filmtype"].ToString() == "3")
                {
                    lblfilmtype.Text = "Feature Film";
                }
                if (ds.Tables[0].Rows[0]["Filmtype"].ToString() == "4")
                {
                    lblfilmtype.Text = "TV Serial";
                }
                if(ds.Tables[0].Rows[0]["Shootingtime"].ToString()=="1")
                {
                    lblshootingggTime.Text = "DAY";
                }
                if (ds.Tables[0].Rows[0]["Shootingtime"].ToString() == "2")
                {
                    lblshootingggTime.Text = "Night";
                }
                if (ds.Tables[0].Rows[0]["Shootingtime"].ToString() == "3")
                {
                    lblshootingggTime.Text = "Day and Night";
                }
               
                lbldirector.Text = ds.Tables[0].Rows[0]["Director"].ToString();

                lblcameraman.Text = ds.Tables[0].Rows[0]["Cameraman"].ToString();
                lblmainartists.Text = ds.Tables[0].Rows[0]["Mainartists"].ToString();
                lblcrewno.Text = ds.Tables[0].Rows[0]["Totalcrewno"].ToString();
                lblscheduledetails.Text = ds.Tables[0].Rows[0]["Proposedshootingschedule"].ToString();
                lblapplicantname.Text = ds.Tables[0].Rows[0]["ApplicantName"].ToString();
                lblapplicantmobileno.Text = ds.Tables[0].Rows[0]["ApplicantMobileNo"].ToString();
                
                lbllocationname.Text= ds.Tables[0].Rows[0]["Locationname"].ToString();
                lblfromdate.Text= ds.Tables[0].Rows[0]["Fromdate"].ToString();
                lbltodate.Text = ds.Tables[0].Rows[0]["Todate"].ToString();
                lblblockingdays.Text= ds.Tables[0].Rows[0]["Blockingdays"].ToString();
                lblshootingdays.Text= ds.Tables[0].Rows[0]["Shootingdays"].ToString();
                lblnoofpolicepersions.Text= ds.Tables[0].Rows[0]["Noofpolicepersions"].ToString();
                lblpriceperlocation.Text= ds.Tables[0].Rows[0]["Priceperlocation"].ToString();
                lblshootingfee.Text= ds.Tables[0].Rows[0]["Shootingfee"].ToString();
                lblcationdeposit.Text= ds.Tables[0].Rows[0]["Cautionfee"].ToString();
                lblservicefee.Text= ds.Tables[0].Rows[0]["Servicefee"].ToString();
                lblpolicefee.Text= ds.Tables[0].Rows[0]["Policefee"].ToString();
                lblgst.Text= ds.Tables[0].Rows[0]["Gst"].ToString();
                lblextrahorsamount.Text=ds.Tables[0].Rows[0]["Extrahoursamount"].ToString();
                lbltotalamont.Text= ds.Tables[0].Rows[0]["Totalamount"].ToString();
                //Convert.ToString(ds.Tables[0].Rows[0]["UID_no"]);
                //Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                //Convert.ToString(ds.Tables[0].Rows[0]["MobileNumber"]);

                //Convert.ToString(ds.Tables[0].Rows[0]["App_Status"]);
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