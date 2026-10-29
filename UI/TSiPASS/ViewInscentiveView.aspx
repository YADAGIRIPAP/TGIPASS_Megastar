<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewInscentiveView.aspx.cs"
    Inherits="InscentiveView_Attachments" Title="Incentive View Attachments" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .padding
        {
            margin: 10px 10px 10px 10px;
            padding-left: 10px;
        }
        .style2
        {
            width: 487px;
        }
        .style3
        {
            height: 106px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <table style="padding-left: 25px; width: 800px;">
            <tr>
                <td>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <table align="center" cellpadding="1" cellspacing="2" style="border-color: Black;
                                    width: 100%;">
                                    <tr>
                                        <td align="center">
                                            <br />
                                            <img src="telanganalogo.png" height="60px" width="60px" alt="TSiPASS" />
                                            <br />
                                            <div>
                                                <font size="2"><strong style="font-family: Arial">Incentive Details - Telangana Industries<br />
                                                </strong></font>
                                            </div>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" align="left" width="100%">
                                            <table width="100%" bgcolor="White" border="2px" style="font-family: Verdana; font-size: small;">
                                                <tr>
                                                    <td class="style2">
                                                        EM / UDYOG AADHAAR No
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblEmNo" runat="server"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style2">
                                                        NAME OF INDUSTRIAL UNDERTAKING
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblUnitName" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style2">
                                                        NAME OF PROMOTER
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblApplicantname" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style2">
                                                        CASTE
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblCaste" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style2">
                                                        GENDER
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblGender" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style2">
                                                        DATE OF APPLICATION
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblDate" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                            </td>
                        </tr>
                        <br />
                        <tr>
                            <td class="style3">
                                <table border="2px" cellpadding="1" cellspacing="2" style="border-color: Black; width: 100%;">
                                    <tr>
                                        <td align="center" colspan="4" style="text-align: center; background-color: #0066FF;">
                                            <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="15px" ForeColor="White">INDUSTRY DETAILS</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <tr>
                                            <td>
                                                CATEGORY
                                            </td>
                                            <td>
                                                <span>
                                                    <asp:Label ID="lblCategory" runat="server"></asp:Label>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                LAND VALUE: (In Lakhs)
                                            </td>
                                            <td>
                                                <span>
                                                    <asp:Label ID="lblLandValue" runat="server"></asp:Label>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                BUILDING VALUE (In Lakhs)
                                            </td>
                                            <td>
                                                <span>
                                                    <asp:Label ID="lblBuldingValue" runat="server"></asp:Label>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                PLANT &amp; MACHINERY (In Lakhs)
                                            </td>
                                            <td>
                                                <span>
                                                    <asp:Label ID="lblPlantValue" runat="server"></asp:Label>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                EQUIPMENT VALUE (In Lakhs)
                                            </td>
                                            <td>
                                                <span>
                                                    <asp:Label ID="lblEuipmentvalue" runat="server"></asp:Label>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                TYPE OF SECTOR
                                            </td>
                                            <td>
                                                <span>
                                                    <asp:Label ID="lblSector" runat="server"></asp:Label>
                                                </span>
                                            </td>
                                        </tr>
                                    </tr>
                                </table>
                                <br />
                            </td>
                        </tr>
                        <br />
                        <tr>
                            <td class="style3">
                                <table bgcolor="White" width="100%" border="2px" style="font-family: Verdana; font-size: small;">
                                    <tr>
                                        <td align="center" colspan="4" style="text-align: center; background-color: #0066FF;">
                                            <asp:Label ID="lblIndustries1" runat="server" Font-Bold="True" Font-Size="15px" ForeColor="White">ADDRESS FOR COMMUNICATION</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            VILLAGE/TOWN
                                        </td>
                                        <td>
                                            <span>
                                                <asp:Label ID="lblvillage" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                        <td>
                                            MANDAL
                                        </td>
                                        <td>
                                            <span>
                                                <asp:Label ID="lblMandal" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            DISTRICT
                                        </td>
                                        <td>
                                            <span>
                                                <asp:Label ID="lblDistrict" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                        <td>
                                            STATE
                                        </td>
                                        <td>
                                            <span>
                                                <asp:Label ID="lblState" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            EMAIL-ID
                                        </td>
                                        <td>
                                            <span>
                                                <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                        <td>
                                            MOBILE NUMBER
                                        </td>
                                        <td>
                                            <span>
                                                <asp:Label ID="lblMobileNumber" runat="server"></asp:Label>
                                            </span>
                                        </td>
                                    </tr>
                                </table>
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                        <br />
                        <tr>
                            <td align="left">
                                <table bgcolor="White" width="100%" border="2px" style="font-family: Verdana; font-size: small;">
                                    <tr>
                                        <td align="center" style="text-align: center; background-color: #0066FF;">
                                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="15px" ForeColor="White">Incentives Applied for</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <asp:GridView ID="gvIncetiveTypes" runat="server" AutoGenerateColumns="False" Width="100%"
                                            ShowHeader="false">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Incentives">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIncentiveName" runat="server" Text='<%# Eval("IncentiveName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </tr>
                                </table>
                                <br />
                            </td>
                        </tr>
                        <tr>
                        </tr>
                        <tr>
                            <td align="left">
                                <table bgcolor="White" width="100%" border="2px" style="font-family: Verdana; font-size: small;">
                                    <tr>
                                        <td align="center" style="text-align: center; background-color: #0066FF;">
                                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="15px" ForeColor="White">Documents / Attachments Submitted</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <asp:GridView ID="gvAttachments" runat="server" AutoGenerateColumns="False" Width="100%"
                                            HorizontalAlign="Left" ShowHeader="false">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Attachments">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl" runat="server" Text='<%# Eval("AttachmentName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        </td> </tr>
        <tr>
            <td colspan="4" class="tdStyle" align="center">
                <span>
                    <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="window.print();" /></span>
            </td>
        </tr>
        </table>
    </div>
    </form>
</body>
</html>
