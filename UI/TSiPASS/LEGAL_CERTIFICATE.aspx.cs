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
using System.Data.SqlClient;

public partial class UI_TSiPASS_LEGAL_CERTIFICATE : System.Web.UI.Page
{
    General clsGeneral = new General();
    DataSet ds = new DataSet();

    String ComplaintNo = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.QueryString.Count > 0)
        //{

        FillGrid();
        //}
    }

    public void FillGrid()
    {


        DataSet ds = new DataSet();
        ds = GetCFECertificatedata(Request.QueryString[0].ToString().Trim());

        if (ds.Tables[0].Rows.Count != 0)
        {

            X509Store store = new X509Store(StoreName.TrustedPeople);
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

            foreach (var c in store.Certificates)
            {
                Console.Out.WriteLine(c.Thumbprint);
                Console.Out.WriteLine(c.Subject);
            }

            // Find by thumbprint
            X509Certificate2Collection scollection =
            store.Certificates.Find(X509FindType.FindByThumbprint, "DD7F690E05EC0962D6C2F2F3636C9AC069427A56", false);

            Response.Write(scollection.Count);

            foreach (X509Certificate2 x509 in scollection)
            {

                try
                {
                    lblNameOfCertifiedPerson3.Text = x509.GetNameInfo(X509NameType.SimpleName, false) + "<br/> Commissioner of Tourism Telangana";
                    lblsigby.Text = "Digitally Signed by : " + x509.GetNameInfo(X509NameType.SimpleName, true);
                    lblSig.Text = "Issued by : " + x509.Subject;

                }
                catch (CryptographicException)
                {

                }

            }
            store.Close();

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
                    //Label4.Text = "O/O. GENERAL MANAGER <br /> DISTRICT INDUSTRIES CENTRE";
                    //Label5.Text = ds.Tables[0].Rows[0]["District_Name"].ToString() + " District.";
                }
                else
                {
                    Label1.Text = "This approval is issued in accordance with the powers vested as per the Section 4(X) of TS-iPASS Act, No. 3 of 2014 Government of Telangana.";
                    //Label4.Text = "COMMISSIONERATE OF INDUSTRIES";
                    //Label5.Text = "Chirag-ali Lane, Abids, Hyderabad – 500 001";
                }
            }
            lblApprovalNo.Text = "APPLICATION UID: " + ds.Tables[0].Rows[0]["UID_No"].ToString();
            //    lblBarcode.Text = ds.Tables[0].Rows[0]["UID_No"].ToString();

            lblApprovalNo0.Text = "DATED: " + ds.Tables[0].Rows[0]["COIDate"].ToString();



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





            Label2.Text = "It is to certify that M/s. <b>" + ds.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString() + " </b>,having its Registered Office address at <font color='green'> " + ds.Tables[0].Rows[0]["AddressA"].ToString() + " </font> and proposing to setup Travel Agency License at <b><font color='red'>" + ds.Tables[0].Rows[0]["SurveyNumber"].ToString() + " , " + ds.Tables[0].Rows[0]["Village_Name"].ToString() + " , " + ds.Tables[0].Rows[0]["Manda_lName"].ToString() + " , " + ds.Tables[0].Rows[0]["District_Name"].ToString() + "</font> ,  </b>for the line of activity  <font color='blue'>" + ds.Tables[0].Rows[0]["LineofActivity_Name"].ToString() + " </font> , has been accorded relevant approvals from the following concerned Departments";

            // lblRegistration.Text = ds.Tables[0].Rows[0]["lblRegistration"].ToString();

            // lblDated.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
            lblNameOfCertifiedPerson2.Text = "Place :" + ds.Tables[0].Rows[0]["District_Name"].ToString();
            //lblPlace.Text = Session["username"].ToString().Trim();
            //lblDate1.Text = System.DateTime.Now.ToString("dd-MM-yyyy");

            if (ds.Tables[0].Rows[0]["UID_No"].ToString().Substring(0, 3) == "MIC" || ds.Tables[0].Rows[0]["UID_No"].ToString().Substring(0, 3) == "SML")
            {

                // Label3.Text = "TS-iPASS District Level Committee";
                lblNameOfCertifiedPerson3.Text = "District Collector<br/> " + ds.Tables[0].Rows[0]["District_Name"].ToString();

                // Label4.Text = "O/O. GENERAL MANAGER <br /> DISTRICT INDUSTRIES CENTRE";
                //  Label5.Text = ds.Tables[0].Rows[0]["District_Name"].ToString() + " District.";

                //lblNameOfCertifiedPerson3.Text = "Commissioner of Industries<br/> Telangana";
            }
            else
            {
                //Label3.Text = "TS-iPASS State Level Committee";
                //Label4.Text = "COMMISSIONERATE OF INDUSTRIES";
                //Label5.Text = "Chirag-ali Lane,Abids, Hyderabad – 500 001";
                lblNameOfCertifiedPerson2.Text = "Place : Hyderabad";
            }
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();

        }


    }

    public DataSet GetCFECertificatedata(string applicationid)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
             new SqlParameter("@intCFEEnterpid",SqlDbType.VarChar)


           };
        pp[0].Value = applicationid;



        Dsnew = clsGeneral.GenericFillDs("getCertificateDetailsdata_LEGAL", pp);
        return Dsnew;
    }
}