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
using BusinessLogic;
public partial class Default2 : System.Web.UI.Page
{
    General clsGeneral = new General();
    DataSet ds = new DataSet();
    comFunctions obcmf = new comFunctions();
    Fetch objFetch = new Fetch();
    String ComplaintNo = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count == 0)
        {
            Response.Redirect("../../Index.aspx");
        }

         //if (Request.QueryString[0].ToString() != "")
         //{
         //    ComplaintNo = Request.QueryString[0].ToString();
         //    FillGrid();
         //}

        if (Request.QueryString.Count > 0)
        {

            FillGrid();
        }
    }
    public void FillGrid()
    {
        Fetch obj = new Fetch();
        DataTable dt = obj.FetchIncentiveDtlsbyIncentiveID(Request.QueryString[0].ToString());
      
        lblUnitName.Text = dt.Rows[0]["UnitName"].ToString();
        Label5.Text = dt.Rows[0]["ApplciantName"].ToString() + ',' + dt.Rows[0]["MobileNo"].ToString() +"<br/> EMI/Udyoga Number" +
            dt.Rows[0]["EMiUdyogAadhar"].ToString();
        Label9.Text = Request.QueryString[1].ToString() + " to " + dt.Rows[0]["UnitName"].ToString() + " Reg";
        Label3.Text="Lr No." +  Request.QueryString[2].ToString().Trim() + ",Dated: " +Request.QueryString[3].ToString().Trim();
        Label11.Text = "With reference o the subject cited, We are Pleased to inform you that you have been sanctioned an amount of Rs. " + Request.QueryString[4].ToString().Trim() + " towards Investment Subsidy under the Scheme of T-PRIDE vide reference 4th cited.";
        //DataSet ds = new DataSet();
        //ds = clsGeneral.GetCFOCertificatedata(Request.QueryString[0].ToString());
        ////ds = clsGeneral.GetCFEEnterprenuerDetails(ComplaintNo);

        //if (ds.Tables[0].Rows.Count != 0)
        //{

        //    lblApprovalNo.Text = ds.Tables[0].Rows[0]["UID_No"].ToString() +" Dated."+ System.DateTime.Now.ToString("dd-MM-yyyy") ;

        //  //  +ds.Tables[0].Rows[0]["SurveyNumber"].ToString() +
        //    Label2.Text = "It is to certify that M/s. <b>" + ds.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString() + " </b>,having its Registered Office address at <font color='green'> " + ds.Tables[0].Rows[0]["AddressA"].ToString() + " </font> and proposing to setup industry at <b><font color='red'> ,. " + ds.Tables[0].Rows[0]["Village_Name"].ToString() + " , " + ds.Tables[0].Rows[0]["Manda_lName"].ToString() + " , " + ds.Tables[0].Rows[0]["District_Name"].ToString() + "</font> ,  </b>for the line of activity  <font color='blue'>" + ds.Tables[0].Rows[0]["LineofActivity_Name"].ToString() + " </font> , has been accorded following approvals through the Telangana State Industrial Project Approval and Self Certification System (TS-iPASS) Act, 2014";
				
        //   // lblRegistration.Text = ds.Tables[0].Rows[0]["lblRegistration"].ToString();
         
        //   // lblDated.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
        //    lblNameOfCertifiedPerson2.Text = "Place :" + Session["username"].ToString().Trim() + "<br/>" + "Date:" + System.DateTime.Now.ToString("dd-MM-yyyy");
        //    //lblPlace.Text = Session["username"].ToString().Trim();
        //    //lblDate1.Text = System.DateTime.Now.ToString("dd-MM-yyyy");

        //    if (Session["userlevel"].ToString().Trim() == "1")
        //    {
        //        Label3.Text = "TS-iPASS State Level Committee";
        //    }
        //    else
        //    {
        //        Label3.Text = "TS-iPASS District Level Committee";
        //    }
        //    grdDetails.DataSource = ds.Tables[0];
        //    grdDetails.DataBind();

        //}

        ////if (ds.Tables[0].Rows.Count != 0)
        ////{



        ////    //lblNameOfCertifiedPerson.Text = ds.Tables[0].Rows[0]["lblNameOfCertifiedPerson"].ToString();
        ////    //lblRegistration.Text = ds.Tables[0].Rows[0]["lblRegistration"].ToString();
        ////    //lblRegistration1.Text = ds.Tables[0].Rows[0]["lblRegistration1"].ToString();
        ////    //lblActivity.Text = ds.Tables[0].Rows[0]["lblActivity"].ToString();





        ////}
    }
}
