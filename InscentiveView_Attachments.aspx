<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InscentiveView_Attachments.aspx.cs"
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
        .style1
        {
            height: 41px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <table style="padding-left: 25px; width: 600px;">
            <tr>
                <td>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <table border="1" align="center" cellpadding="1" cellspacing="2" style="border-color: Black;
                                    width: 100%;">
                                    <tr>
                                        <td align="center">
                                            <br />
                                            <img src="UI/TSiPASS/telanganalogo.png" height="60px" width="60px" alt="TSiPASS" />
                                            <br />
                                            <div>
                                                <font size="2"><strong style="font-family: Arial">Receipt for Incentive - Telangana
                                                    Industries<br />
                                                </strong></font>
                                            </div>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%">
                                            <table align="left" border="1" style="width: 100%; border-right: #000000 thin solid;
                                                border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid;
                                                border-collapse: collapse; text-align: left;">
                                                <tr>
                                                    <td align="right" visible="false" style="width: 120px; text-align: left;" class="tdStyle">
                                                        Application Number</td>
                                                    <td align="left" class="tdStyle">
                                                        <asp:Label ID="lblapplicationnumber" runat="server"></asp:Label>
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
                                                </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="text-align: center;" class="style1">
                                            Incentives Applied for
                                        </th>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:GridView ID="gvIncetiveTypes" runat="server" AutoGenerateColumns="False" Width="100%" ShowHeader="false">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Incentives" >
                                                        <ItemTemplate>
                                                            <asp:Label Width="100%" ID="lblIncentiveName" runat="server" Text='<%# Eval("IncentiveName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                       
                                                    </asp:TemplateField>
                                                     <asp:BoundField ItemStyle-Width="16%" DataField="FDate" HeaderText="From Date" />
                                                    <asp:BoundField ItemStyle-Width="16%" DataField="TDate" HeaderText="To Date" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="text-align: center;">
                                            Documents / Attachments Submitted
                                        </th>
                                    </tr>                                    
                                    <tr>
                                        <td align="left">
                                            <asp:GridView ID="gvAttachments" runat="server" AutoGenerateColumns="False" 
                                                Width="100%" HorizontalAlign="Left" ShowHeader="false">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Attachments">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl" runat="server" Text='<%# Eval("AttachmentName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="4" class="tdStyle" align="center">
                    <span>
                        <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="window.print();" /></span>
                </td>
            </tr>
            <tr>
                <td align="left" class="tdStyle">
                    <strong>Note:- Print this payment receipt for further reference.</strong>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
