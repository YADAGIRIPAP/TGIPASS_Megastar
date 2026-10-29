<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CentralInspectionPrint.aspx.cs" Inherits="UI_TSiPASS_CentralInspectionPrint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>CentralInspectionPrint</title>

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
                                    <table border="1" align="center" cellpadding="1" cellspacing="2" style="border-color: Black; width: 595px; height: 842px;">
                                        <%--style="width: 595px;  height: 642px;"   border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid;
                                            border-bottom: #000000 thin solid--%>
                                        <tr>
                                            <td colspan="4" align="center">
                                                <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/tsSmalllogo.png" height="60px"
                                                    width="60px" />
                                                <%-- <img src="F:/Property_Tax/RBS/RBS/Images/ghmclogo.png" />--%>
                                                <br />
                                                <div>
                                                    <font size="2"><strong style="font-family: Arial">GOVERNMENT OF TELANGANA<br />
                                                        OFFICE OF THE <asp:Label ID="lblofficename" runat="server" Text="lblofficename"></asp:Label><br />
                                                        PRIOR INTIMATION OF INSPECTION
                                                                   </strong></font>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="left">
                                                <strong style="font-weight: bold" class="tdStyle">Registration No.<asp:Label ID="lblregno" runat="server" Text="lblregno"></asp:Label></strong></td>
                                            <td colspan="2" align="right">
                                                <strong style="font-weight: bold" class="tdStyle">Date:<asp:Label ID="lbldate" runat="server" Text="Label"></asp:Label></strong></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" valign="top">
                                                <table align="center" border="1" style="width: 100%; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid; border-collapse: collapse;">

                                                    <tr>
                                                        <td colspan="4" class="tdStyle">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">1. Name &amp; Address of the Establishment:</td>
                                                        <td colspan="2">
                                                            <asp:Label ID="lblNameaddress" runat="server" Text="Label"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">2.Registration / License No:</td>
                                                        <td colspan="2">
                                                            <asp:Label ID="lbllicno" runat="server" Text="Label"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">3. Name of the Employer:</td>
                                                        <td colspan="2">
                                                            <asp:Label ID="lblemp" runat="server" Text="lblemp" EnableViewState="false"></asp:Label></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="left" class="tdStyle">You are hereby informed that your establishment is scheduled for inspection on <asp:Label ID="lblinspdt" runat="server" Text="Label"></asp:Label> under all relevant enactments, by way of a single joint inspection. The Inspection procedure and inspection checklist under various laws is made available on the Web Portal of the <asp:Label ID="lbldeptname" runat="server" Text="Label"></asp:Label> for guidance.<br />
                                                <br />

                                                Therefore you are requested to produce the relevant records to the inspecting officer at the time of inspection.</td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="left" class="tdStyle">
                                                <strong>Note: The inspection procedure /checklist can be viewed by clicking on online inspection system in <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                                <asp:HyperLink ID="HyperLink2" Text="" Target="_blank" NavigateUrl='<%# Eval("link") %>'  runat="server"></asp:HyperLink>
                                                 <br /> </strong>This is a computer generated notice and does not require physical signature.</td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" class="tdStyle" align="right">
                                                <asp:Label ID="lbloffice" runat="server" Text="" Visible="true"></asp:Label>
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
                    <asp:Button ID="btnprint" runat="server" CssClass="NoPrint" Text=" Print " OnClick="btnprint_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
