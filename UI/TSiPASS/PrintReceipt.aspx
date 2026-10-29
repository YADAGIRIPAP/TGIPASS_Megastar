<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="PrintReceipt.aspx.cs" Inherits="InterfaceNetBanking_PrintReceipt" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Payment Receipt</title>
  
</head>
<body>
    <form id="form1" runat="server">
        <table align="center">
            <tr>
                <td>
                    <div id="Receipt" runat="server" style="width: 595px;">
                        <table style="width: 595px; height: 842px;">
                            <tr>
                                <td>
                                    <table border="1" align="center" cellpadding="1" cellspacing="2" style="border-color: Black;
                                        width: 595px; height: 842px;">
                                        <%--style="width: 595px;  height: 642px;"   border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid;
                                            border-bottom: #000000 thin solid--%>
                                        <tr>
                                            <td colspan="4" align="center"> 
                                                <img src="D:/TS-iPASSFinal/telanganalogo.png" height="60px" 
                                                    width="60px" />
                                                <%-- <img src="F:/Property_Tax/RBS/RBS/Images/ghmclogo.png" />--%>
                                                <br />
                                                <div>
                                                    <font size="2"><strong style="font-family: Arial">Telangana Industries<br />
                                                        Industries Online Payment Receipt </strong></font>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="left">
                                                <strong style="font-weight: bold" class="tdStyle">Receipt &nbsp;Details</strong></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" valign="top">
                                                <table align="center" border="1" style="width: 100%; border-right: #000000 thin solid;
                                                    border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid;
                                                    border-collapse: collapse;">
                                                    <tr>
                                                        <td align="right" visible="false" style="width: 120px" class="tdStyle">
                                                            Paid At:</td>
                                                        <td align="left" class="tdStyle">
                                                            <asp:Label ID="lblPaidat" runat="server"></asp:Label></td>
                                                        <td class="tdStyle" align="right" style="width: 120px">
                                                            <asp:Label ID="Label2" runat="server" Text="Reference No.:"></asp:Label></td>
                                                        <td class="tdStyle" align="left">
                                                            <asp:Label ID="txtasmtno" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tdStyle" align="right" style="width: 120px">
                                                            Receipt&nbsp; No:</td>
                                                        <td class="tdStyle" align="left">
                                                            <asp:Label ID="txtrcptno" runat="server" CssClass="input"></asp:Label></td>
                                                        <td class="tdStyle" align="right" style="width: 120px">
                                                            Receipt Date:</td>
                                                        <td class="tdStyle" align="left">
                                                            <asp:Label ID="txtrcptdt" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tdStyle" align="right" style="width: 120px">
                                                            Unit Name:</td>
                                                        <td class="tdStyle" align="left">
                                                            <asp:Label ID="txtname" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="tdStyle" align="right" style="width: 120px">
                                                            Door Number:</td>
                                                        <td class="tdStyle" align="left">
                                                            <asp:Label ID="txtaddress" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tdStyle" align="right" style="width: 120px">
                                                            Mobile Number:
                                                        </td>
                                                        <td class="tdStyle" align="left">
                                                            <asp:Label ID="lblMobileNumber" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="tdStyle" align="right" style="width: 120px">
                                                            Email Id:</td>
                                                        <td class="tdStyle" align="left">
                                                            &nbsp;<asp:Label ID="txtEmailId" runat="server" Font-Bold="True"></asp:Label></td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td align="right" style="width: 120px" class="tdStyle">
                                                            Paid From:
                                                        </td>
                                                        <td class="tdStyle" align="left">
                                                            <asp:Label ID="txtfrmdt" runat="server"></asp:Label></td>
                                                        <td align="right" style="width: 120px" class="tdStyle">
                                                            To:</td>
                                                        <td class="tdStyle" align="left">
                                                            <asp:Label ID="txttodt" runat="server"></asp:Label></td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="right" style="width: 120px" class="tdStyle">
                                                            Amount Paid(Rs):
                                                        </td>
                                                        <td class="tdStyle" align="left">
                                                            <asp:Label ID="txttotal" runat="server" Font-Bold="true"></asp:Label></td>
                                                        <td align="right" style="width: 120px">
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" class="tdStyle">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr><td colspan="4" align="left" class="tdStyle"> <asp:Label id="lblnum2wrds" runat="server" Visible="true" Text=""></asp:Label></td></tr>
                                        <tr>
                                            <td colspan="4" align="left" class="tdStyle">
                                                <strong>Note:- Print this payment receipt for further reference.</strong></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" class="tdStyle">
                                                <asp:Label ID="LblNote2" runat="server" Text="" Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center" class="tdStyle">
                                                <strong>*************************************************</strong></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
        <br />
        <table border="0" align="center" cellpadding="1" cellspacing="2" style="width: 595px">
            <tr>
                <td align="center" colspan="4">
                    <asp:Button ID="btnclose" runat="server" CssClass="NoPrint" PostBackUrl="~/UI/TSiPASS/Dashboard.aspx"
                        Text="Close" onclick="btnclose_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnprint" runat="server" CssClass="NoPrint" Text=" Print " OnClick="btnprint_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
