<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IciciPaymentResponse.aspx.cs" Inherits="IciciPaymentResponse" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Online Payment</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
    <tr><td>Transaction Status:</td><td><asp:Label ID="lblTrnaStatus" runat="server" Text=""></asp:Label></td></tr>
    <tr><td>Transaction Message:</td><td><asp:Label ID="lblTranMesage" runat="server" Text=""></asp:Label></td></tr>
    <tr><td>Transaction Error Message:</td><td><asp:Label ID="lblTrnsErrormsg" runat="server" Text=""></asp:Label></td></tr>
     <tr><td>Transaction Reference Number:</td><td><asp:Label ID="lblTransRefNumber" runat="server" Text=""></asp:Label></td></tr>
     
      <tr><td>Transaction Bank Code:</td><td><asp:Label ID="lblBankCode" runat="server" Text=""></asp:Label></td></tr>
     <tr><td>Tpsl Transaction Id:</td><td><asp:Label ID="lbltpslTrnsId" runat="server" Text=""></asp:Label></td></tr>
     
       <tr><td>Transaction Amount:</td><td><asp:Label ID="lblAmount" runat="server" Text=""></asp:Label></td></tr>
     <tr><td>Tpsl Transaction Time:</td><td><asp:Label ID="lblTransTime" runat="server" Text=""></asp:Label></td></tr>
     
     <tr><td>Transaction Ref Id:</td><td><asp:Label ID="lblTxnRefId" runat="server" Text=""></asp:Label></td></tr>
     <tr><td>Balance Amount:</td><td><asp:Label ID="lblBalAmount" runat="server" Text=""></asp:Label></td></tr>
     <tr><td>Request Token:</td><td><asp:Label ID="lblReqToken" runat="server" Text=""></asp:Label></td></tr>
    <tr><td></td><td></td></tr>
    
    </table>
    <table><tr><td>
        <asp:Label ID="lblValidate" runat="server" Text=""></asp:Label> </td></tr>
        <tr><td> 
            <asp:Label ID="lblResponseDecrypted" runat="server" Text=""></asp:Label></td></tr>
            <tr><td> 
                <asp:Label ID="LBL_DisplayResult" runat="server" Text=""></asp:Label></td></tr>
        </table>
    </div>
    </form>
</body>
</html>
