<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IpassPrintReceiptTourismEvent.aspx.cs" Inherits="UI_TSiPASS_IpassPrintReceiptTourismEvent" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Payment Receipt</title>
    <script type="text/javascript">
        function CallPrint(strid) {
            var prtContent = document.getElementById(strid);
            var WinPrint = window.open('', '', 'letf=0,top=0,width=0,height=0,toolbar=0,scrollbars=1,status=0');
            var strOldOne = prtContent.innerHTML;
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
            prtContent.innerHTML = strOldOne;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table align="center">
            <tr>
                <td>
                    <div id="Receipt" runat="server" style="width: 650px;">
                        <table style="width: 595px;">
                            <tr>
                                <td>
                                    <table border="1" align="center" cellpadding="1" cellspacing="2" style="border-color: Black; width: 650px;">
                                        <%--style="width: 595px;  height: 642px;"   border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid;
                                            border-bottom: #000000 thin solid--%>
                                        <tr>
                                            <td colspan="4" align="center">
                                                <%-- <img src="D:/TS-iPASSFinal/telanganalogo.png" height="60px" 
                                                    width="60px" />--%>
                                                <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/telanganalogo.png" height="60px" width="60px" />
                                                <%-- <img src="F:/Property_Tax/RBS/RBS/Images/ghmclogo.png" />--%>
                                                <br />
                                                <div>
                                                    <font size="2"><strong style="font-family: Arial">
                                                        Commissioner of Industries,<br />
                                                        Chirag Ali Lane, Abids,<br />
                                                        Hyderabad - 500 001<br />
                                                        Phone : 040-23441636<br />
                                                          </strong></font>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="left">
                                                <strong style="font-weight: bold" class="tdStyle">Online Payment Receipt</strong></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" valign="top">
                                                <table align="center" border="1" style="width: 100%; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid; border-collapse: collapse;">
                                                    <tr style="height: 40px">
                                                        <%--<td align="right" visible="false" style="width: 120px" class="tdStyle">Paid At:</td>
                                                        <td align="left" class="tdStyle">
                                                            <asp:Label ID="lblPaidat" runat="server"></asp:Label></td>--%>
                                                        <td class="tdStyle" align="left" style="width: 120px">
                                                            <asp:Label ID="Label2" runat="server" Text="UID No.:"></asp:Label></td>
                                                        <td class="tdStyle" align="left" style="width: 150px">
                                                            <asp:Label ID="txtasmtno" runat="server"></asp:Label></td>
                                                        <td class="tdStyle" align="left" style="width: 120px">Unit Name:</td>
                                                        <td class="tdStyle" align="left">
                                                            <asp:Label ID="txtname" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 40px">
                                                        <td class="tdStyle" align="left" style="width: 120px">Transaction No:</td>
                                                        <td class="tdStyle" align="left">
                                                            <asp:Label ID="txtrcptno" runat="server" CssClass="input"></asp:Label></td>
                                                        <td class="tdStyle" align="left" style="width: 120px">Transaction Date:</td>
                                                        <td class="tdStyle" align="left">
                                                            <asp:Label ID="txtrcptdt" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr style="height: 40px">

                                                        <td class="tdStyle" align="left" style="width: 120px">Communication Address:</td>
                                                        <td class="tdStyle" align="left" colspan="3">
                                                            <asp:Label ID="txtaddress" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr style="height: 40px">
                                                        <td class="tdStyle" align="left" style="width: 120px">Mobile Number:
                                                        </td>
                                                        <td class="tdStyle" align="left">
                                                            <asp:Label ID="lblMobileNumber" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="tdStyle" align="left" style="width: 120px">Email Id:</td>
                                                        <td class="tdStyle" align="left">&nbsp;<asp:Label ID="txtEmailId" runat="server" Font-Bold="True"></asp:Label></td>
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
                                                    <tr style="height: 40px">
                                                        <td align="lft" style="width: 120px" class="tdStyle">Amount Paid(Rs):
                                                        </td>
                                                        <td class="tdStyle" align="left">
                                                            <asp:Label ID="txttotal" runat="server" Font-Bold="true"></asp:Label></td>
                                                        <td align="right" style="width: 120px"></td>
                                                        <td align="left"></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" class="tdStyle">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4"></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="left" class="tdStyle">
                                                <asp:Label ID="lblnum2wrds" runat="server" Visible="true" Text=""></asp:Label></td>
                                        </tr>
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
                        Text="Close" OnClick="btnclose_Click" />
                    &nbsp;&nbsp;

                    <asp:Button ID="btnprint" runat="server" CssClass="NoPrint" Text=" Print " OnClientClick="javascript:CallPrint('Receipt')" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

