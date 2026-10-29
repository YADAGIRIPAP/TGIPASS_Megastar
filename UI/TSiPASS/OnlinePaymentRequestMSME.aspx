<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OnlinePaymentRequestMSME.aspx.cs" Inherits="OnlinePaymentRequest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>SBI PaymentGateway</title>
    <script>
			function generateAction()
			{		
			    var chkStatus1 = document.getElementById("chkConfirm");
			    if(	chkStatus1.checked){	
				document.frmPost.EncryptTrans.value = document.getElementById("requestparams").value;
				document.frmPost.merchIdVal.value = document.getElementById("merchantId").value;				
				document.frmPost.EncryptbillingDetails.value = document.getElementById("billingDtls").value;				
                document.frmPost.EncryptshippingDetais.value = document.getElementById("shippingDtls").value;
				document.frmPost.action = "https://www.sbiepay.com/secure/MerchantHostedListener";
				document.frmPost.submit();
				}
				else
                {  
                   alert('please select the checkbox below');              
                   chkStatus1.setAttribute("ForeColor","Red");
                }
			}			
		</script>
</head>
<body>
    <form id="form1" runat="server">    
    <div>
        <div>
            <table width="300px">
                <tr>
                    <td>
                        <asp:Label ID="lblMerchantId" runat="server">Merchant Id</asp:Label></td>
                    <td width="20px">
                        <b>:</b></td>
                    <td>
                        <asp:TextBox ID="merchantId" Text="1000105" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblColloboratorId" runat="server">Aggregator Id</asp:Label></td>
                    <td>
                        <b>:</b></td>
                    <td>
                        <asp:TextBox ID="collaboratorId" Text="SBIEPAY" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblOperatingMode" runat="server">Operating Mode</asp:Label></td>
                    <td>
                        <b>:</b></td>
                    <td>
                        <asp:TextBox ID="operatingMode" Text="DOM" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCountry" runat="server">Country</asp:Label></td>
                    <td>
                        <b>:</b></td>
                    <td>
                        <asp:TextBox ID="CountryCode" Text="IN" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCurrency" runat="server">Currency</asp:Label></td>
                    <td>
                        <b>:</b></td>
                    <td>
                        <asp:TextBox ID="currency_Code" Text="INR" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAmount" runat="server" >Amount</asp:Label></td>
                    <td>
                        <b>:</b></td>
                    <td>
                        <asp:TextBox ID="amt" Text="2" runat="server" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblOrderNumber" runat="server">Order Number</asp:Label></td>
                    <td>
                        <b>:</b></td>
                    <td>
                        <asp:TextBox ID="orderNumber" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblOtherDetails" runat="server">TSIPASS UID</asp:Label></td>
                    <td>
                        <b>:</b></td>
                    <td>
                        <asp:TextBox ID="otherDetails" Text="Other" runat="server" Enabled="false"></asp:TextBox></td>ss
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSuccessUrl" runat="server">Success URL</asp:Label></td>
                    <td>
                        <b>:</b></td>
                    <td>
                        <asp:TextBox ID="successUrl" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFailureUrl" runat="server">Failure URL</asp:Label></td>
                    <td>
                        <b>:</b></td>
                    <td>
                        <asp:TextBox ID="failureUrl" runat="server" Enabled="false"></asp:TextBox></td>
                        
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server">Customer ID</asp:Label></td>
                    <td>
                        <b>:</b></td>
                    <td>
                        <asp:TextBox ID="txtMerCustomerId" Text="2" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server">PayMode</asp:Label></td>
                    <td>
                        <b>:</b></td>
                    <td>
                        <asp:TextBox ID="txtpayMode" Text="NB" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server">Accessmedium</asp:Label></td>
                    <td>
                        <b>:</b></td>
                    <td>
                        <asp:TextBox ID="txtAccessmedium" Text="ONLINE" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server">Transaction Source</asp:Label></td>
                    <td>
                        <b>:</b></td>
                    <td>
                        <asp:TextBox ID="txtTransSource" Text="ONLINE" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:HiddenField ID="requestparams" runat="server"></asp:HiddenField>
                        <asp:HiddenField ID="billingDtls" runat="server"></asp:HiddenField>
                        <asp:HiddenField ID="shippingDtls" runat="server"></asp:HiddenField>
                    </td>
                </tr>
            </table>
            <br />
          
            <br />
            
            <br />
          
          
            <asp:Button ID="btnProceedToPay" runat="server" Text="Proceed To Pay" OnClick="btnProceedToPay_Click"/>           
        </div>
    </div>     
    </form>
    
 
</body>
</html>
