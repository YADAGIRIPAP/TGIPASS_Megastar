<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="PrintReceipt_MeeSeva.aspx.cs"
    Inherits="InterfaceNetBanking_PrintReceipt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
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
                                    <tr>
                                        <td align="center">
                                            <img src="telanganalogo.png" height="60px" width="60px" alt="TSiPASS" />
                                            <br />
                                            <div>
                                                <font size="2"><strong style="font-family: Arial">Telangana Industries<br />
                                                    Industries Meeseva Payment Receipt </strong></font>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <strong style="font-weight: bold" class="tdStyle">Incentive Meeseva Receipt &nbsp;Details</strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <table align="left" border="1" style="width: 100%; border-right: #000000 thin solid;
                                                border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid;
                                                border-collapse: collapse; text-align: left;">
                                                <tr>
                                                    <td align="right" visible="false" style="width: 120px; text-align: left;" class="tdStyle">
                                                        Date of Application:</td>
                                                    <td align="left" class="tdStyle">
                                                        <asp:Label ID="lblDateofissue" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="tdStyle" align="right" style="width: 120px; text-align: left;">
                                                        &nbsp;</td>
                                                    <td class="tdStyle" align="left">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="right" visible="false" style="width: 120px; text-align: left;" class="tdStyle">
                                                        EM / Udyog Aadhar No :
                                                    </td>
                                                    <td align="left" class="tdStyle">
                                                        <asp:Label ID="lblEmNo" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="tdStyle" align="right" style="width: 120px; text-align: left;">
                                                        <asp:Label ID="Label2" runat="server" Text="Category :"></asp:Label>
                                                    </td>
                                                    <td class="tdStyle" align="left">
                                                        <asp:Label ID="lblCategory" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tdStyle" align="right" style="width: 120px; text-align: left;">
                                                        Unit Name:
                                                    </td>
                                                    <td class="tdStyle" align="left">
                                                        <asp:Label ID="lblUnitName" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="tdStyle" align="right" style="width: 120px; text-align: left;">
                                                        Land Value: (In Lakhs):
                                                    </td>
                                                    <td class="tdStyle" align="left">
                                                        <asp:Label ID="lblLandValue" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tdStyle" align="right" style="width: 120px; text-align: left;">
                                                        Applicant Name:
                                                    </td>
                                                    <td class="tdStyle" align="left">
                                                        <asp:Label ID="lblApplicantname" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="tdStyle" align="right" style="width: 120px; text-align: left;">
                                                        Building Value (In Lakhs):
                                                    </td>
                                                    <td class="tdStyle" align="left">
                                                        <asp:Label ID="lblBuldingValue" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tdStyle" align="right" style="width: 120px; text-align: left;">
                                                        Gender:
                                                    </td>
                                                    <td class="tdStyle" align="left">
                                                        <asp:Label ID="lblGender" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td class="tdStyle" align="right" style="width: 120px; text-align: left;">
                                                        Plant &amp; Machinery (In Lakhs) :
                                                    </td>
                                                    <td class="tdStyle" align="left">
                                                        <asp:Label ID="lblPlantValue" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tdStyle" align="right" style="width: 120px; text-align: left;">
                                                        Caste
                                                    </td>
                                                    <td class="tdStyle" align="left">
                                                        <asp:Label ID="lblCaste" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td class="tdStyle" align="right" style="width: 120px; text-align: left;">
                                                        Equipment Value (In Lakhs)
                                                    </td>
                                                    <td class="tdStyle" align="left">
                                                        <asp:Label ID="lblEuipmentvalue" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tdStyle" align="right" style="width: 120px; text-align: left;">
                                                        Email Id:
                                                    </td>
                                                    <td class="tdStyle" align="left">
                                                        <asp:Label ID="lblEmailId" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td class="tdStyle" align="right" style="width: 120px; text-align: left;">
                                                        Type of Sector:
                                                    </td>
                                                    <td class="tdStyle" align="left">
                                                        <asp:Label ID="lblSector" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                </tr>                                                
                                                <tr>
                                                    <td class="tdStyle" align="right" style="width: 120px; text-align: left;">
                                                        Mobile Number:
                                                    </td>
                                                    <td class="tdStyle" align="left">
                                                        <asp:Label ID="lblMobileNumber" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="tdStyle" align="right" style="width: 120px">
                                                        &nbsp;
                                                    </td>
                                                    <td class="tdStyle" align="left" style="text-align: left">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tdStyle" align="right" style="width: 120px; text-align: left;">
                                                        Challan Amount:
                                                    </td>
                                                    <td class="tdStyle" align="left">
                                                        <asp:Label ID="Label1" runat="server" Text="0"></asp:Label>
                                                    </td>
                                                    <td class="tdStyle" align="right" style="width: 120px">
                                                        User Charges:
                                                    </td>
                                                    <td class="tdStyle" align="left" style="text-align: left">
                                                        <asp:Label ID="Label3" runat="server" Text="35"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tdStyle" align="right" style="width: 120px; text-align: left;">
                                                        Courier Charges:
                                                    </td>
                                                    <td class="tdStyle" align="left">
                                                        <asp:Label ID="Label4" runat="server" Text="0"></asp:Label>
                                                    </td>
                                                    <td class="tdStyle" align="right" style="width: 120px">
                                                        Total Amount:
                                                    </td>
                                                    <td class="tdStyle" align="left" style="text-align: left">
                                                        <asp:Label ID="Label5" runat="server" Text="35"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" class="tdStyle">
                                                        Mee Seva Transaction Number :<asp:Label ID="lblMeeSevaTransacNo" runat="server"/>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        TSiPass Transaction Number :<asp:Label ID="lblTsiPassTransacNo" runat="server"/>
                                                    </td>
                                                </tr>
                                                <tr>
                                        <td colspan="4" class="tdStyle" align="center">
                                            <span><asp:Button ID="btnPrint" runat="server" Text="Print" 
                                                OnClientClick="window.print();" /></span>
                                        </td>
                                    </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="tdStyle">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="tdStyle">
                                            <strong>Note:- Print this payment receipt for further reference.</strong>
                                        </td>
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
                &nbsp;&nbsp;
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
