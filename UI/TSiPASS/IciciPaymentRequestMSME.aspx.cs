using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DotNetIntegrationKit;
using System.Text;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using System.Data.SqlClient;
public partial class IciciPaymentRequest : System.Web.UI.Page
{
    #region "Global Variables"
    RequestURL objRequestURL = new RequestURL();
    string con = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ToString();
    #endregion
    #region "Page_Load"
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Request.QueryString[1].ToString() != null && Request.QueryString[2].ToString() != null && Request.QueryString[0].ToString() != null)
                {
                    txtMerTransRefNumber.Text = Request.QueryString[0].ToString();//"9892381157";                   
                  //  txtAmount.Text = Session["Amount"].ToString();
                    txtAmount.Text = Request.QueryString[2].ToString();

                  //  txtAmount.Text = "1.00";
                    txtUniqueCustId.Text = Request.QueryString[1].ToString();                    
                    txtReturnUrl.Text = "https://ipass.telangana.gov.in/UI/TSiPASS/IciciPaymentResponse.aspx";
                    txtReturnS2s.Text = "NA";
                    txtTpslTxnId.Text = "NA";
                    txtShoppingCartDtls.Text = "COI_" + Convert.ToDecimal(txtAmount.Text).ToString("f0") + ".0" + "_0.0";
                    txtDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                    txtCustomerName.Text = "";
                    txtpropertypath.Text = "D:\\PropertyFile\\Merchant.property";

                 
                    txtITC.Text = "NA";

                    txtCustomerName.Text = Request.QueryString[1].ToString();
                 txtMobileNumber.Text="9999999999";
            String response = objRequestURL.SendRequest(TxtReqType.Text.Trim(), txtMarchantCode.Text.Trim(), txtMerTransRefNumber.Text.Trim(), txtITC.Text.Trim(), txtAmount.Text.Trim(), txtCurrancyCode.Text.Trim(), txtUniqueCustId.Text.Trim(), txtReturnUrl.Text.Trim(), txtReturnS2s.Text.Trim(), txtTpslTxnId.Text, txtShoppingCartDtls.Text.Trim(), txtDate.Text.Trim(), txtEmailId.Text.Trim(), txtMobileNumber.Text.Trim(), txtBankCode.Text.Trim(), txtCustomerName.Text.Trim(), txtpropertypath.Text.Trim());
            String strResponse = response.ToUpper();
            if (strResponse.StartsWith("ERROR"))
            {
                lblError.Text = response;
            }
            else
            {
                Response.Write("<form name='s1_2' id='s1_2' action='" + response + "' method='post'> ");

                Response.Write("<script type='text/javascript' language='javascript' >document.getElementById('s1_2').submit();");

                Response.Write("</script>");
                Response.Write("<script language='javascript' >");
                Response.Write("</script>");
                Response.Write("</form> ");

            }


        


                }
                //else
                //{
                //    Response.Redirect("../../Index.aspx");
                //}
            }
            else
            {
                
            }
        }
        catch(Exception ex)
        {

        }
        finally
        {
            //objDs = null;
        }

    }
    #region "Commented"
    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (!Page.IsPostBack)
    //        {
    //        if (Request.QueryString["PTIN"] != null && Request.QueryString["Amount"] != null)
    //        {
    //            _objDs = objBankerPayementBL.GetTransactionIDICICI();
    //            if (_objDs != null && _objDs.Tables.Count > 0 && _objDs.Tables[0].Rows.Count > 0)
    //            {
    //                txttranxid.Text = _objDs.Tables[0].Rows[0][0].ToString();//"9892381157";
    //            }
    //            else
    //            {
    //                txttranxid.Text = "0";
    //            }
    //            txttranxid.Text="12345";
    //            txtmarketcode.Text = "T3192";//"12345";
    //            txtaccountno.Text = "100000001";//"100001";
    //            txttranxamt.Text = "1";
    //            txtbankcode.Text = "470";
    //            txtpropertypath.Text = "F:\\MerchantDetails.property";

    //            if (Request.QueryString["Amount"] != null) // 
    //            {
    //                //string deAmount = Request.QueryString["Amount"].ToString();
    //                txttranxamt.Text = Request.QueryString["Amount"].ToString();// Request.QueryString["value2"].ToString();
    //            }
    //            else
    //            {
    //                txttranxamt.Text = "0";
    //            }
    //            if (Request.QueryString["PTIN"] != null)
    //            {
    //                //string dePtin = Request.QueryString["PTIN"].ToString();
    //                // txtaccountno.Text = dePtin;
    //                txtmarketcode.Text = Request.QueryString["PTIN"].ToString();
    //            }
    //            else
    //            {
    //                //redirect to login page
    //            }
    //        }
    //      }
    //    }
    //    catch
    //    {
    //    }
    //    finally
    //    {
    //        _objDs = null;
    //    }

    //}
    #endregion
    #endregion
    #region "btn_Request_Click"
    protected void btn_Request_Click(object sender, EventArgs e)
    {
        
    }
    #endregion
    #region "Decrypt Text"
    public string DecryptText(string encryptText)
    {
        try
        {
            string decryptpassword = string.Empty;
            UTF8Encoding encodepassword = new UTF8Encoding();
            Decoder Decode = encodepassword.GetDecoder();
            encryptText = encryptText.Replace(' ', '+');
            int len = encryptText.Length;
            byte[] decode_to_byte = Convert.FromBase64String(encryptText);
            int passwordCount = Decode.GetCharCount(decode_to_byte, 0, decode_to_byte.Length);
            char[] decoded_char = new char[passwordCount];
            Decode.GetChars(decode_to_byte, 0, decode_to_byte.Length, decoded_char, 0);
            decryptpassword = new String(decoded_char);
            return decryptpassword;
            //return  DecryptString(encryptPassword, sKey);
        }
        catch
        {

        }
        return null;

    }
    #endregion
}
