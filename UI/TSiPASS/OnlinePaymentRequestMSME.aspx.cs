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
using com.toml.dp.util;
public partial class OnlinePaymentRequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            if (Request.QueryString[0].ToString() != null && Request.QueryString[1].ToString() != null)
            {
                successUrl.Text = "https://ipass.telangana.gov.in/UI/TSiPASS/PaymentResponse.aspx";
                orderNumber.Text = Request.QueryString[0].ToString();
                successUrl.Enabled = false;
                failureUrl.Text = "https://ipass.telangana.gov.in/UI/TSiPASS/PaymenterrorPage.aspx";
                amt.Text ="1";//"1.00"; //
                otherDetails.Text = Request.QueryString[1].ToString();
                amt.Enabled = false;
                encriptData();
               
            }			
           
        }
    }

    public void encriptData()
    {
        try
        {
            string MID = merchantId.Text;
            string Collaborator_Id = collaboratorId.Text;
            string Operating_Mode = operatingMode.Text;
            string Country = CountryCode.Text;
            string Currency = currency_Code.Text;
            string Amount = amt.Text;
            string Order_Number = orderNumber.Text;
            string Other_Details = otherDetails.Text;
            string Success_URL = successUrl.Text;
            string Failure_URL = failureUrl.Text;
            string EncodedKey = "drnsAzyQ03VDnbXO2kk11Q==";//"wImKoNvsqbSswM/bO0FT4A==";  
            int keysize = 128;
            string Requestparameter = MID + "|" + Operating_Mode + "|" + Country + "|" + Currency + "|" + Amount + "|" + Other_Details + "|" + Success_URL + "|" + Failure_URL + "|" + Collaborator_Id + "|" + orderNumber.Text + "|" + txtMerCustomerId.Text + "|" + txtpayMode.Text + "|" + txtAccessmedium.Text + "|" + txtTransSource.Text;

            string EncryptedParam = AES128Bit.Encrypt(Requestparameter, EncodedKey, keysize);
            Session["TransValue"] = EncryptedParam;
            string actualParm = AES128Bit.Decrypt(EncryptedParam, EncodedKey, keysize);
            string reqBill = "NA|NA|NA|NA|NA|NA|NA|NA|NA|NA|N";
            string enBill = AES128Bit.Encrypt(reqBill, EncodedKey, keysize);
            Session["Billing"] = enBill;

            string reqShipping = "NA|NA|NA|NA|NA|NA|NA|NA|NA|NA|N";
            string EnShipp = AES128Bit.Encrypt(reqShipping, EncodedKey, keysize);
            Session["Shipping"] = EnShipp;

            Response.Redirect("Paynow.aspx");
        }
        catch
        {

        }

    }

    protected void btnProceedToPay_Click(object sender, EventArgs e)
    {
        try
        {
            encriptData();
        }
        catch
        {

        }
    }
}
