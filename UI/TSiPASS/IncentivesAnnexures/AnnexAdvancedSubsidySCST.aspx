<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AnnexAdvancedSubsidySCST.aspx.cs" Inherits="UI_TSiPASS_IncentivesAnnexures_AnnexAdvancedSubsidySCST" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 800px;
        }

        .auto-style4 {
            width: 232px;
        }

        .auto-style5 {
            width: 166px;
        }

        .auto-style6 {
            width: 130px;
        }

        .auto-style7 {
            width: 242px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <div align="center" style="text-align: center">
                <div align="center">
                    <center>
                        <img src="../../../Resource/Images/telanganalogo.png" width="75px" height="75px" />
                    </center>
                    <h3>TS-iPASS COMMON APPLICATION FORM</h3>
                </div>
                <br />
                <div align="center">
                    <div align="center" id="divCommonAppli" runat="server" visible="false">
                        <div align="center">
                            <table bgcolor="White" width="800" border="2px"
                                style="font-family: Verdana; font-size: small; text-align: left">
                                <tr>
                                    <td align="center" colspan="4"
                                        style="text-align: center; background-color: #0066FF;">
                                        <asp:Label ID="lblIndustries1" runat="server" Font-Bold="True" Font-Size="15px"
                                            ForeColor="White">ANNEXURE: XVI  <br /><br />APPLICATION-CUM-VERIFICATION FOR CLAIMING ADVANCE SUBSIDY UNDER T-PRIDE—TELANGANA STATE PROGRAM FOR RAPID INCUBATION OF DALIT ENTREPRENEURS INCENTIVE SCHEME.  <br />(G.O.Ms.No.29 Industries and Commerce (IP & INF) Department. dated.29/11/2014) </asp:Label>
                                    </td>
                                </tr>
                                <%-- <tr>
                                    <td colspan="4"></td>
                                </tr>--%>
                                <tr style="height: 40px">
                                    <td colspan="4">
                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="15px"
                                            ForeColor="Black">1.0. Details of Industry</asp:Label>:</td>
                                </tr>
                                <tr>
                                    <td colspan="2">1.1. Name of the Enterprise/Industry</td>
                                    <td colspan="2">
                                        <span>
                                            <asp:Label ID="txtUnitname" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">1.2. Name of the Proprietor/Managing Partner / Managing Director</td>
                                    <td colspan="2">
                                        <span>
                                            <asp:Label ID="txtApplicantName" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">1.3. TIN No. of the Enterprise/Industry/Proprietor/Managing Partner/Managing Director</td>
                                    <td colspan="2">
                                        <span>
                                            <asp:Label ID="txtTinNumber" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">1.4. PAN No. of the Proprietor / Managing Partner /  Managing Director</td>
                                    <td colspan="2">
                                        <span>
                                            <asp:Label ID="txtPanNumber" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <%-- <tr>
                                    <td colspan="4"></td>
                                </tr>--%>
                                <tr style="height: 40px">
                                    <td colspan="4" style="text-align: left;">
                                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="15px"
                                            ForeColor="Black">2.0. Address of the Enterprise/Industry</asp:Label>
                                        :</td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4"
                                        style="text-align: left;">
                                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="15px"
                                            ForeColor="Black">2.1 Factory Location</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>District</td>
                                    <td>
                                        <span>
                                            <asp:Label ID="ddldistrictunit" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td>Survey No
                                    </td>
                                    <td>
                                        <span>
                                            <asp:Label ID="txtunitaddhno" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td>Mandal</td>
                                    <td>
                                        <span>
                                            <asp:Label ID="ddlUnitMandal" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td>Street</td>
                                    <td>
                                        <span>
                                            <asp:Label ID="txtstreetunit" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td>Village</td>
                                    <td>
                                        <span>
                                            <asp:Label ID="ddlVillageunit" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td>Mobile Number
                                    </td>
                                    <td>
                                        <span>
                                            <asp:Label ID="txtunitmobileno" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td>Email Id</td>
                                    <td>
                                        <span>
                                            <asp:Label ID="txtunitemailid" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4"></td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4" style="text-align: left;">
                                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="15px"
                                            ForeColor="Black">2.2 Office Location</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>District</td>
                                    <td>
                                        <span>
                                            <asp:Label ID="ddldistrictoffc" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td>Survey No
                                    </td>
                                    <td>
                                        <span>
                                            <asp:Label ID="txtoffaddhnno" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td>Mandal</td>
                                    <td>
                                        <span>
                                            <asp:Label ID="ddloffcmandal" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td>Street
                                    </td>
                                    <td>
                                        <span>
                                            <asp:Label ID="txtstreetoffice" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td>Village</td>
                                    <td>
                                        <span>
                                            <asp:Label ID="ddlvilloffc" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td>Mobile Number
                                    </td>
                                    <td>
                                        <span>
                                            <asp:Label ID="txtOffcMobileNO" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td>Email Id</td>
                                    <td>
                                        <span>
                                            <asp:Label ID="txtOffcEmail" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td></td>
                                    <td>
                                        <span></span>

                                    </td>
                                </tr>
                                <%-- <tr>
                                    <td colspan="4"></td>
                                </tr>--%>
                                <tr style="height: 40px">
                                    <td colspan="4" style="text-align: left;">
                                        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="15px"
                                            ForeColor="Black">3.0 Status</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">3.1. Constitution of the Organisation </td>
                                    <td colspan="2">
                                        <span>
                                            <asp:Label ID="ddltypeofOrg" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">3.2 Industry Status </td>
                                    <td colspan="2">
                                        <asp:Label ID="ddlindustryStatus" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">3.3 Expected Date of Commencement of Production</td>
                                    <td colspan="2">
                                        <span>
                                            <asp:Label ID="txtDateofCommencement" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">3.4 EM Part - II/IEM/IL No.<br />
                                        (copy to be enclosed)</td>
                                    <td colspan="2">
                                        <span>
                                            <asp:Label ID="txtEMPartNo" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <%-- <tr>
                                    <td colspan="4"></td>
                                </tr>--%>
                                <tr style="height: 40px">
                                    <td align="center" colspan="4" style="text-align: left;">
                                        <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="12px"
                                            ForeColor="Black">3.5  PAN Card No              :- </asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="2">i)  Proprietor /Managing Partner/Managing Director :</td>
                                    <td colspan="2">
                                        <span>
                                            <asp:Label ID="lblProperitorPanNo" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">ii)  Company </td>
                                    <td colspan="2">
                                        <span>
                                            <asp:Label ID="lblompanyPanNo" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">3.7&nbsp; I.T Returns (Enclose 3 years returns): </td>
                                    <td colspan="2">
                                        <span>
                                            <asp:Label ID="lblITreturnsYesNo" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr style="height: 40px" id="tr2" runat="server" visible="true">
                                    <td colspan="4" style="font-size: 15px; text-align: left; font-weight: bold;">
                                        <asp:Label ID="Label9" runat="server" Text="4.0 Proposed"></asp:Label>&nbsp;
                                        Project details</td>
                                </tr>
                                <tr id="trexpansion1" runat="server" visible="true">
                                    <td colspan="4" style="font-size: small; text-align: left; font-weight: bold;">
                                        <asp:Label ID="lblIndustryStatus2" runat="server" Text="4.1 New Enterprise/Industry"></asp:Label>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"
                                        style="font-size: small; text-align: left; font-weight: bold;">LINE OF ACTIVITY</td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:GridView ID="gvLOA" runat="server" AutoGenerateColumns="False"
                                            Font-Names="Verdana" Font-Size="12px" SkinID="gridviewSkin" Width="750px">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sl No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="LineofActivity" HeaderText="Line Of Activity" />
                                                <asp:BoundField DataField="InstalledCapacity" HeaderText="Installed Capacity" />
                                                <asp:BoundField DataField="NameofUnit" HeaderText="Unit" />
                                                <asp:BoundField DataField="Value" HeaderText="Value" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <%--  <tr>
                                    <td colspan="4"></td>
                                </tr>--%>
                                <tr style="height: 40px">
                                    <td colspan="4"
                                        style="font-size: medium; text-align: left; font-weight: bold;">4.2 Fixed Capital Investment(in Rs.)</td>
                                </tr>
                                <tr id="tr1" runat="server" visible="false">
                                    <td colspan="9">
                                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                            <tr>
                                                <td style="text-align: left">Nature of Assets</td>
                                                <td style="text-align: center">Rs.</td>
                                                <td style="text-align: center"></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>Land</td>
                                                <td>
                                                    <asp:Label ID="txtlandexisting" runat="server"></asp:Label>
                                                </td>
                                                <td>Building
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtbuildingexpandiver" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Plant & Machinery
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtplantexisting" runat="server"></asp:Label>
                                                </td>
                                                <td>Erection Expenses
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtErectionExpenses" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>

                                                <td>Total
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtTotalNatureAssets" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td colspan="4"></td>
                                </tr>--%>

                                <tr id="tr3" runat="server" visible="true">
                                    <td colspan="2" style="font-size: 15px; text-align: left; font-weight: bold;">5.0 Social Status</td>
                                    <td colspan="2">
                                        <asp:Label ID="rblCaste" runat="server"></asp:Label>&nbsp;</td>
                                </tr>
                                <tr id="tr4" runat="server" visible="true">
                                    <td colspan="2" style="font-size: small; text-align: left;">If  SC, ST& Women please indicate % share in the equity:
                                    </td>
                                    <td colspan="2" style="font-size: small; text-align: left;">
                                        <asp:Label ID="Label10" runat="server"></asp:Label>&nbsp;
                                    </td>
                                </tr>
                            </table>
                            <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                <tr style="height: 40px">
                                    <td colspan="2"
                                        style="text-align: left; font-weight: bold;">5.1 Details of the Director(s)/ Partner(s)  (Deed to be enclosed) </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:GridView ID="GridViewdirectors" runat="server" AutoGenerateColumns="False"
                                            Font-Names="Verdana" Font-Size="12px" SkinID="gridviewSkin" >
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sl No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Name" HeaderText="Name" />
                                                <asp:BoundField DataField="Community" HeaderText="Community" />
                                                <asp:BoundField DataField="Share" HeaderText="Share" />
                                                <asp:BoundField DataField="Percentage" HeaderText="Percentage" />

                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div align="center">
                        </div>
                        <div align="center">
                            <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                <%--<tr>
                                    <td colspan="4"></td>
                                </tr>--%>

                                <tr id="tr5" runat="server" visible="true" style="height: 40px">
                                    <td colspan="4" style="font-size: 15px; text-align: left; font-weight: bold;">6.0 Power</td>
                                </tr>
                                <tr id="tr6" runat="server" visible="true">
                                    <td colspan="2" style="text-align: left;">6.1 Date of Application with TSTRANSCO (copy of certificate to be Enclosed)</td>
                                    <td colspan="2" style="font-size: small; text-align: left;">
                                        <asp:Label ID="txtNewPowerReleaseDate" runat="server"></asp:Label>&nbsp;
                                    </td>
                                </tr>
                                <tr id="tr7" runat="server" visible="true">
                                    <td colspan="2" style="text-align: left;">6.2 Contracted load   (KW /HP) </td>
                                    <td colspan="2" style="font-size: small; text-align: left;">
                                        <asp:Label ID="txtNewContractedLoad" runat="server"></asp:Label>&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div align="center">
                            <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                <%-- <tr>
                                    <td align="center" colspan="4"></td>
                                </tr>--%>
                                <tr style="height: 40px">
                                    <td align="center" colspan="4"
                                        style="text-align: left; font-size: medium; font-weight: bold;">
                                        <asp:Label ID="lblIndustries7" runat="server" Font-Bold="True" Font-Size="14px">7.0 Implementation Steps Taken</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">7.1 Date of application for Term Loan</td>
                                    <td>
                                        <asp:Label ID="txtTermloan" runat="server"></asp:Label>
                                        &nbsp;</td>
                                    <td style="text-align: left">7.2 Term Loan Sanctioned Date</td>
                                    <td style="text-align: left">
                                        <span>
                                            <asp:Label ID="txtdatesanctioned" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">7.3 Term Loan Sanctioned reference No</td>
                                    <td style="text-align: left">
                                        <span>
                                            <asp:Label ID="txtsactionedloan" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td style="text-align: left">7.4 Name of the Institution</td>
                                    <td style="text-align: left">
                                        <span>
                                            <asp:Label ID="txtnmofinstitution" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div align="center">
                            <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                <tr style="height: 40px">

                                    <td align="center" colspan="4"
                                        style="text-align: left; font-size: medium; font-weight: bold;">
                                        <asp:Label ID="lblIndustries9" runat="server" Font-Bold="True" Font-Size="12px"> 8.0 Approved/Estimated projected cost, term loan sanctioned and released, assets acquired etc</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table bgcolor="White" width="100%" border="2px" style="font-family: Verdana; font-size: small;">
                                            <tr>
                                                <td style="text-align: center"></td>
                                                <td style="text-align: center">Name of Asset</td>
                                                <td style="text-align: center">Approved Project
                                                                                                    <br />
                                                    Cost                                                                                                    
                                                </td>
                                                <td style="text-align: center">Loan Sanctioned</td>
                                                <td style="text-align: center">Equity from
                                                                                                    <br />
                                                    the promoters
                                                </td>
                                                <td style="text-align: center">Loan Amount
                                                                                                    <br />
                                                    Released
                                                </td>

                                            </tr>
                                            <tr>
                                                <td style="text-align: center"></td>
                                                <td style="text-align: center">1</td>
                                                <td style="text-align: center">2</td>
                                                <td style="text-align: center">3</td>
                                                <td style="text-align: center">4</td>
                                                <td style="text-align: center">5</td>

                                            </tr>
                                            <tr>
                                                <td>8.1</td>
                                                <td>Land</td>
                                                <td>
                                                    <asp:Label ID="txtLand2" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="txtLand3" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtLand4" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="txtLand5" runat="server"></asp:Label></td>

                                            </tr>
                                            <tr>
                                                <td>8.2</td>
                                                <td>Buildings</td>
                                                <td>
                                                    <asp:Label ID="txtBuilding2" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="txtBuilding3" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtBuilding4" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="txtBuilding5" runat="server"></asp:Label></td>

                                            </tr>
                                            <tr>
                                                <td>8.3</td>
                                                <td>Plant & Machinery</td>
                                                <td>
                                                    <asp:Label ID="txtPM2" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="txtPM3" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtPM4" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="txtPM5" runat="server"></asp:Label></td>

                                            </tr>
                                            <tr>
                                                <td>8.4</td>
                                                <td>Machinery Contingencies</td>
                                                <td>
                                                    <asp:Label ID="txtMCont2" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="txtMCont3" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtMCont4" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="txtMCont5" runat="server"></asp:Label></td>

                                            </tr>
                                            <tr>
                                                <td>8.5</td>
                                                <td>Erection</td>
                                                <td>
                                                    <asp:Label ID="txtErec2" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="txtErec3" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtErec4" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="txtErec5" runat="server"></asp:Label></td>

                                            </tr>
                                            <tr>
                                                <td>8.6</td>
                                                <td>Technical know-how,<br />
                                                    feasibility study</td>
                                                <td>
                                                    <asp:Label ID="txtTFS2" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="txtTFS3" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtTFS4" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="txtTFS5" runat="server"></asp:Label></td>

                                            </tr>
                                            <tr>
                                                <td>8.7</td>
                                                <td>Working Capital</td>
                                                <td>
                                                    <asp:Label ID="txtWC2" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="txtWC3" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtWC4" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="txtWC5" runat="server"></asp:Label></td>

                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td>Total</td>
                                                <td>
                                                    <asp:Label ID="Label12" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label13" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label14" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label15" runat="server"></asp:Label></td>

                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>

                    <div align="center" id="divSCAndST" runat="server" visible="false">
                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                            <tr style="height: 40px">
                                <td align="center" colspan="4"
                                    style="text-align: left; font-size: medium; font-weight: bold;">
                                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="14px">Advance Subsidy for SC / ST Entrepreneurs</asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 30px">
                                <td style="font-weight: bold; text-align: left" colspan="4">9.0 Means of Finance</td>
                            </tr>
                            <tr>
                                <td style="text-align: left;">9.1   Total equity from promotors / share holders / partners to be brought in Rs.</td>
                                <td>
                                    <asp:Label ID="txtTotalEquity" runat="server"></asp:Label>
                                </td>
                                <td style="text-align: left;">9.2  Own capital in Rs.<br />
                                    ( Proof to be submitted) 
                                </td>
                                <td style="text-align: left;">
                                    <asp:Label ID="txtOwnCapital" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left;">9.3   Borrowed from outside Rs.<br />
                                    ( Proof to be submitted) </td>
                                <td style="text-align: left;">
                                    <asp:Label ID="txtBorrowed" runat="server"></asp:Label>
                                </td>
                                <td style="text-align: left;">9.4   Advance Subsidy claimed in Rs.
                                </td>
                                <td style="text-align: left;">
                                    <asp:Label ID="txtAdvSubClaimed" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left;">10.0  Term loan release statement
                                    <br />
                                    ( Proof to be submitted) </td>
                                <td style="text-align: left;">
                                    <asp:Label ID="lbltermloanYESNO" runat="server"></asp:Label>
                                </td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td colspan="4"></td>
                            </tr>
                        </table>
                    </div>

                    <div align="center">
                        <table bgcolor="White" width="800" border="2px"
                            style="font-family: Verdana; font-size: small;" class="auto-style1">
                            <tr style="height: 40px">

                                <td align="center" colspan="4"
                                    style="text-align: left; font-size: medium; font-weight: bold;">
                                    <asp:Label ID="lblIndustries12" runat="server" Font-Bold="True" Font-Size="15px">11.0 Registration with Commercial taxes Department Registration</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left;" class="auto-style6">VAT No</td>
                                <td class="auto-style7">
                                    <asp:Label ID="txtvatno" runat="server"></asp:Label></td>
                                <td style="text-align: left;" class="auto-style4">Registration Date</td>
                                <td style="text-align: left;" class="auto-style5">
                                    <span>
                                        <asp:Label ID="txtVatDate" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left;" class="auto-style6">CST No</td>
                                <td class="auto-style7">
                                    <asp:Label ID="txtcstno" runat="server"></asp:Label></td>
                                <td style="text-align: left;" class="auto-style4">Registration Date</td>
                                <td class="auto-style5">
                                    <span>
                                        <asp:Label ID="txtCSTRegDate" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left;" class="auto-style6">Registring Authority</td>
                                <td class="auto-style7">
                                    <asp:Label ID="txtCSTRegAuthority" runat="server"></asp:Label></td>
                                <td style="text-align: left;" class="auto-style4">Registring Authority Address</td>
                                <td class="auto-style5">
                                    <span>
                                        <asp:Label ID="txtCSTRegAuthAddress" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr style="height: 40px">
                                <td colspan="4" style="text-align: left"><strong>12.0 Advance subsidy applied :- </strong></td>
                            </tr>
                            <tr>
                                <td colspan="3" style="text-align: left">12.1 Advance Subsidy @50 % of the Promoters contribution (or) : 50% of the eligible investment Subsidy (Which ever is less) </td>
                                <td colspan="1" class="auto-style5">
                                    <span>
                                        <asp:Label ID="Label17" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="text-align: right"><strong>Total:</strong></td>
                                <td colspan="1" class="auto-style5">
                                    <span>Rs. &nbsp;<asp:Label ID="Label2" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                           <%-- <tr>
                                <td colspan="4"></td>
                            </tr>
                            <tr>
                                <td colspan="4"></td>
                            </tr>--%>
                        </table>
                    </div>
                    <br />
                    <input id="btnPrint" onclick="window.print()" style="border-right: thin solid; border-top: thin solid; width: 80px; border-left: thin solid; border-bottom: thin solid"
                        type="button" value="Print" />
                    &nbsp;&nbsp;&nbsp;

                                        <a href="HomeDashboard.aspx">HOME</a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
