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
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Security.Cryptography.X509Certificates;
using System.Security;
using System.Drawing;

public partial class UI_TSiPASS_Default2 : System.Web.UI.Page
{
    General clsGeneral = new General();
    DataSet ds = new DataSet();

    String ComplaintNo = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session.Count == 0)
        //{
        //    Response.Redirect("../../Index.aspx");
        //}

        //if (Request.QueryString[0].ToString() != "")
        //{
        //    ComplaintNo = Request.QueryString[0].ToString();
        //    FillGrid();
        //}
        try
        {
            if (Request.QueryString.Count > 0)
            {

                FillGrid();
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            // lbl.Text = ex.Message;
            //Failure.Visible = true;
        }
    }
    public void FillGrid()
    {
        try
        {

            DataSet ds = new DataSet();
            ds = clsGeneral.GetRENCertificatedata(Request.QueryString[0].ToString());
            //ds = clsGeneral.GetCFEEnterprenuerDetails(ComplaintNo);

            if (ds.Tables[0].Rows.Count != 0)
            {

                //lblApprovalNo.Text = ds.Tables[0].Rows[0]["UID_No"].ToString(); //+" Dated."+ System.DateTime.Now.ToString("dd-MM-yyyy") ;
                lblApprovalNo.Text = "APPLICATION UID: " + ds.Tables[0].Rows[0]["UID_No"].ToString();

                //  +ds.Tables[0].Rows[0]["SurveyNumber"].ToString() +
                Label2.Text = "It is to certify that M/s. <b>" + ds.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString() + " </b>,having its Registered Office address at <font color='green'> " + ds.Tables[0].Rows[0]["AddressA"].ToString() + " </font> and proposing to setup industry at <b><font color='red'> " + ds.Tables[0].Rows[0]["SURVEYNO"].ToString() + ", " + ds.Tables[0].Rows[0]["Village_Name"].ToString() + " , " + ds.Tables[0].Rows[0]["Manda_lName"].ToString() + " , " + ds.Tables[0].Rows[0]["District_Name"].ToString() + "</font> ,  </b>for the line of activity  <font color='blue'>" + ds.Tables[0].Rows[0]["LineofActivity_Name"].ToString() + " </font> , has been accorded following approvals through the Telangana State Industrial Project Approval and Self Certification System (TS-iPASS) Act, 2014";

                // lblRegistration.Text = ds.Tables[0].Rows[0]["lblRegistration"].ToString();

                // lblDated.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                // lblNameOfCertifiedPerson2.Text = "Place :" + Session["username"].ToString().Trim() + "<br/>" + "Date:" + System.DateTime.Now.ToString("dd-MM-yyyy");
                //lblPlace.Text = Session["username"].ToString().Trim();
                //lblDate1.Text = System.DateTime.Now.ToString("dd-MM-yyyy");

                //if (Session["userlevel"].ToString().Trim() == "1")
                //{
                //    Label3.Text = "TS-iPASS State Level Committee";
                //}
                //else
                //{
                //    Label3.Text = "TS-iPASS District Level Committee";
                //}

                if (ds.Tables[0].Rows[0]["UID_No"].ToString().Substring(0, 3) == "MIC" || ds.Tables[0].Rows[0]["UID_No"].ToString().Substring(0, 3) == "SML")
                {

                    grdDetails.DataSource = ds.Tables[0];
                    grdDetails.DataBind();
                }
                else
                {

                    if (Request.QueryString.Count > 1)
                    {
                        if (Request.QueryString["Stage"].ToString() == "5") // District
                        {
                            Label1.Text = "This approval is issued in accordance with the powers vested as per the Section 3(IX) of TS-iPASS Act, No. 3 of 2014 Government of Telangana.";
                        }
                        else if (Request.QueryString["Stage"].ToString() == "6") // State
                        {
                            Label1.Text = "This approval is issued in accordance with the powers vested as per the Section 4(X) of TS-iPASS Act, No. 3 of 2014 Government of Telangana.";
                        }
                    }
                    else
                    {
                        if (ds.Tables[0].Rows[0]["UID_No"].ToString().Substring(0, 3) == "MIC" || ds.Tables[0].Rows[0]["UID_No"].ToString().Substring(0, 3) == "SML")
                        {
                            Label1.Text = "This approval is issued in accordance with the powers vested as per the Section 3(IX) of TS-iPASS Act, No. 3 of 2014 Government of Telangana.";
                        }
                        else
                        {
                            Label1.Text = "This approval is issued in accordance with the powers vested as per the Section 4(X) of TS-iPASS Act, No. 3 of 2014 Government of Telangana.";
                        }
                    }

                    grdDetails.DataSource = ds.Tables[0];
                    grdDetails.DataBind();

                }
                var url = string.Format("http://chart.apis.google.com/chart?cht=qr&chs={1}x{2}&chl={0}", "TSiPASS" + ds.Tables[0].Rows[0]["UID_No"].ToString(), "60", "60");
                WebResponse response = default(WebResponse);
                Stream remoteStream = default(Stream);
                StreamReader readStream = default(StreamReader);
                WebRequest request = WebRequest.Create(url);
                response = request.GetResponse();
                remoteStream = response.GetResponseStream();
                readStream = new StreamReader(remoteStream);
                System.Drawing.Image img = System.Drawing.Image.FromStream(remoteStream);
                img.Save("D:/TS-iPASSFinal/QRCode/" + "TSiPASS" + ds.Tables[0].Rows[0]["UID_No"].ToString() + ".png");
                Image1.ImageUrl = "~/QRCode/" + "TSiPASS" + ds.Tables[0].Rows[0]["UID_No"].ToString() + ".png";


                response.Close();
                remoteStream.Close();
                readStream.Close();
                lblNameOfCertifiedPerson2.Text = "Place : Hyderabad";

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            // lbl.Text = ex.Message;
            //Failure.Visible = true;
        }
        //if (ds.Tables[0].Rows.Count != 0)
        //{



        //    //lblNameOfCertifiedPerson.Text = ds.Tables[0].Rows[0]["lblNameOfCertifiedPerson"].ToString();
        //    //lblRegistration.Text = ds.Tables[0].Rows[0]["lblRegistration"].ToString();
        //    //lblRegistration1.Text = ds.Tables[0].Rows[0]["lblRegistration1"].ToString();
        //    //lblActivity.Text = ds.Tables[0].Rows[0]["lblActivity"].ToString();





        //}
    }
}