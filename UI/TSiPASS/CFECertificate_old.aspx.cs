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
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;


using System.Drawing;

using System.Collections.Generic;
public partial class Default2 : System.Web.UI.Page
{
    General clsGeneral = new General();
    DataSet ds = new DataSet();
   
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


        DataSet ds = new DataSet();
        ds = clsGeneral.GetCFECertificatedata(Request.QueryString[0].ToString());
        //ds = clsGeneral.GetCFEEnterprenuerDetails(ComplaintNo);

        if (ds.Tables[0].Rows.Count != 0)
        {

            lblApprovalNo.Text ="APPROVAL NUMBER: "+ ds.Tables[0].Rows[0]["UID_No"].ToString()  ;
        //    lblBarcode.Text = ds.Tables[0].Rows[0]["UID_No"].ToString();

            lblApprovalNo0.Text="DATED: "+ System.DateTime.Now.ToString("dd-MM-yyyy");
            //string code = lblBarcode.Text;
            //QRCodeGenerator qrGenerator = new QRCodeGenerator();
            //QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            //System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            //imgBarCode.Height = 150;
            //imgBarCode.Width = 150;
            //using (Bitmap bitMap = qrCode.GetGraphic(20))
            //{
            //    using (MemoryStream ms = new MemoryStream())
            //    {
            //        bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            //        byte[] byteImage = ms.ToArray();
            //        imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
            //    }
            //    plBarCode.Controls.Add(imgBarCode);
            //}

         //   lblBarcode.Visible = false;


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
            Image1.ImageUrl = "~/QRCode/" + "TSiPASS" +  ds.Tables[0].Rows[0]["UID_No"].ToString() + ".png";

           
            response.Close();
            remoteStream.Close();
            readStream.Close();





            Label2.Text = "It is to certify that M/s. <b>" + ds.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString() + " </b>,having its Registered Office address at <font color='green'> " + ds.Tables[0].Rows[0]["AddressA"].ToString() + " </font> and proposing to setup industry at <b><font color='red'>" + ds.Tables[0].Rows[0]["SurveyNumber"].ToString() + " , " + ds.Tables[0].Rows[0]["Village_Name"].ToString() + " , " + ds.Tables[0].Rows[0]["Manda_lName"].ToString() + " , " + ds.Tables[0].Rows[0]["District_Name"].ToString() + "</font> ,  </b>for the line of activity  <font color='blue'>" + ds.Tables[0].Rows[0]["LineofActivity_Name"].ToString() + " </font> , has been accorded following approvals through the Telangana State Industrial Project Approval and Self Certification System (TS-iPASS) Act, 2014";
				
           // lblRegistration.Text = ds.Tables[0].Rows[0]["lblRegistration"].ToString();
         
           // lblDated.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
            lblNameOfCertifiedPerson2.Text = "Place :" + Session["username"].ToString().Trim() + "<br/>" + "Date:" + System.DateTime.Now.ToString("dd-MM-yyyy");
            //lblPlace.Text = Session["username"].ToString().Trim();
            //lblDate1.Text = System.DateTime.Now.ToString("dd-MM-yyyy");

            if (Session["userlevel"].ToString().Trim() == "1")
            {
                Label3.Text = "TS-iPASS State Level Committee";
                lblNameOfCertifiedPerson3.Text = "Commissioner of Industries<br/> Telangana";
            }
            else
            {
                Label3.Text = "TS-iPASS District Level Committee";
                lblNameOfCertifiedPerson3.Text = "District Collector<br/> " + ds.Tables[0].Rows[0]["District_Name"].ToString();
            }
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();

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
