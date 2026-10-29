<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentResponse.aspx.cs" Inherits="PaymentResponse" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>TSipass</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr><td colspan="2"> Response Parameters </td></tr>
            <tr>
                <td>Merchant Order Number:
                </td>
                <td>
                    <asp:TextBox ID="txtMerchntOrderNo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                ePay Reference Id:
                </td>
                <td>
                <asp:TextBox ID="txtePayRefId" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                Status:
                </td>
                <td>
                <asp:TextBox ID="txtStatus" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                Amount:
                </td>
                <td>
                <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                Currency:
                </td>
                <td>
                <asp:TextBox ID="txtCurrency" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                PayMode:
                </td>
                <td>
                <asp:TextBox ID="txtPayMode" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                Assessment No:
                </td>
                <td>
                <asp:TextBox ID="txtOthDetails" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                Reason:
                </td>
                <td>
                <asp:TextBox ID="txtReason" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                Bank Code:
                </td>
                <td>
                <asp:TextBox ID="txtBankCode" runat="server"></asp:TextBox>
                </td>
            </tr>
               <tr>
                <td>
                Bank Reference Number:
                </td>
                <td>
                <asp:TextBox ID="txtBankRefNumber" runat="server"></asp:TextBox>
                </td>
            </tr>
               <tr>
                <td>
                Tranction Date:
                </td>
                <td>
                <asp:TextBox ID="txtTransDate" runat="server"></asp:TextBox>
                </td>
            </tr>
               <tr>
                <td>
                Country:
                </td>
                <td>
                <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
