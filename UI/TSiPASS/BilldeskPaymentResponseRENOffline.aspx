<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BilldeskPaymentResponseRENOffline.aspx.cs" Inherits="UI_TSiPASS_BilldeskPaymentResponseRENOffline" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
              <table style="width: 550px; border-collapse: collapse;" border="1" align="center">
                <tr>
                    <td class="GRD" style="height: 23px; font-weight: bold;" colspan="2" align="center">Renewal Transaction Details
                    </td>
                </tr>
                 <tr style="height:40px">

                    <td align="left">
                        <span style="font-size: 11pt; font-family: 'Calibri','sans-serif'; mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">1. IPASS UID NO:</span></td>
                    <td align="left">
                        <asp:TextBox ID="txtUidNo" runat="server" Height="28px" Width="262px" ></asp:TextBox></td>
                </tr>
                <tr style="height:40px">
                    <td align="left">
                        <span style="font-size: 11pt; font-family: 'Calibri','sans-serif'; mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">2. TS-IPASS Online Transaction</span>:</td>
                    <td align="left">
                        <asp:TextBox ID="txtipasstr" runat="server" Width="262px" Height="28px"></asp:TextBox></td>
                </tr>
                <tr style="height:40px">
                    <td align="left">
                        <span style="font-size: 11pt; font-family: 'Calibri','sans-serif'; mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">3. Bank Trannsation No</span>:</td>
                    <td align="left">
                        <asp:TextBox ID="txtBankTransactionNo" runat="server" Width="262px" Height="28px"></asp:TextBox></td>
                </tr>
                <tr style="height:40px">
                    <td align="left">
                        <span style="font-size: 11pt; font-family: 'Calibri','sans-serif'; mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">4. Transaction Date</span> :</td>
                    <td align="left">
                        <asp:TextBox ID="txtTransadate" runat="server" Width="262px" Height="28px"></asp:TextBox> <br /> DD-MM-YYYY(Ex. 23-08-2017)</td>
                </tr>
                <tr style="height:40px">
                    <td align="left">
                        <span style="font-size: 11pt; font-family: 'Calibri','sans-serif'; mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">5. Total Amount</span> :</td>
                    <td align="left">
                        <asp:TextBox ID="txtAmountpaid" runat="server" Width="262px" Height="28px"></asp:TextBox></td>
                </tr>
                <tr style="height:40px">
                    <td align="left">
                        <span style="font-size: 11pt; font-family: 'Calibri','sans-serif'; mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">6. Bank Id</span></td>
                    <td align="left">
                        <asp:TextBox ID="txtBankId" runat="server" Width="262px" Height="28px"></asp:TextBox></td>
                </tr>
                <tr style="height:40px">
                    <td align="left">
                        7 Additional Payment Flag</td>
                    <td align="left">
                        <asp:TextBox ID="txtadditional5" runat="server" Width="262px" Height="28px"></asp:TextBox></td>
                </tr>
                <tr style="height:40px">
                    <td colspan="2" align="center">
                        <asp:Button ID="btn_Request" Height="30" runat="server" OnClick="btn_Request_Click" Text=" Submit Payment" />
                        <br />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
