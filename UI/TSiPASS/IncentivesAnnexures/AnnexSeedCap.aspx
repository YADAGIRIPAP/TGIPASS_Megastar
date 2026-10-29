<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AnnexSeedCap.aspx.cs" Inherits="UI_TSiPASS_IncentivesAnnexures_AnnexSeedCap" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <div align="center" style="text-align: center">
                <div align="center">
                    <center>
                        <img src="../telanganalogo.png" width="75px" height="75px" />
                    </center>
                </div>
                <div align="center">
                    <br />
                    <div align="center" id="divCommonAppli" runat="server" visible="false">
                        <div align="center">
                            <table bgcolor="White" width="800" border="2px"
                                style="font-family: Verdana; font-size: small;">
                                <tr>ss
                                    <td align="center" colspan="4"
                                        style="text-align: center; background-color: #339966;">
                                        <asp:Label ID="lblIndustries1" runat="server" Font-Bold="True" Font-Size="15px"
                                            ForeColor="White">ANNEXURE: X<br /><br />
                                            APPLICATION CUM VERIFICATION FOR <br /><span style="color:black">GRANT OF SEED CAPITAL
                                            ASSISTANCE UNDER T-PRIDE—TELANGANA STATE</span> <br />PROGRAM FOR RAPID
                                            INCUBATION OF DALIT ENTREPRENEURS INCENTIVE SCHEME.<br />
                                            (G.O.Ms.No.29 Industries and Commerce (IP & INF) Department. dated.29/11/2014)<br /></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: left; height: 32px">
                                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="15px" ForeColor="Black">1.0. Details of Enterprise/Industry</asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: left; height: 32px">1.1. Name of the Enterprise</td>
                                    <td colspan="2" style="text-align: left; height: 32px">
                                        <span>
                                            <asp:Label ID="txtUnitname" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: left; height: 32px">1.2. Name of the Proprietor/Managing Partner / Managing Director</td>
                                    <td colspan="2" style="text-align: left; height: 32px">
                                        <span>
                                            <asp:Label ID="txtApplicantName" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: left; height: 32px">1.3. TIN No. of the Enterprise/Industry/Proprietor/Managing Partner/Managing Director</td>
                                    <td colspan="2" style="text-align: left; height: 32px">
                                        <span>
                                            <asp:Label ID="txtTinNumber" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: left; height: 32px">1.4. PAN No. of the Proprietor / Managing Partner /  Managing Director</td>
                                    <td colspan="2" style="text-align: left; height: 32px">
                                        <span>
                                            <asp:Label ID="txtPanNumber" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                1.5. Constitution of the Entrepreneur
                                <tr>
                                    <td colspan="4"></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: left; height: 32px;">
                                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="15px"
                                            ForeColor="Black">2.0. Address of the Enterprise</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: left; height: 32px;">
                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="15px" ForeColor="Black">2.1 Factory Location</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; height: 32px;">District</td>
                                    <td style="text-align: left; height: 32px;">
                                        <span>
                                            <asp:Label ID="ddldistrictunit" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td style="text-align: left; height: 32px;">Survey No
                                    </td>
                                    <td style="text-align: left; height: 32px;">
                                        <span>
                                            <asp:Label ID="txtunitaddhno" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; height: 32px;">Mandal</td>
                                    <td style="text-align: left; height: 32px;">
                                        <span>
                                            <asp:Label ID="ddlUnitMandal" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td style="text-align: left; height: 32px;">Street</td>
                                    <td style="text-align: left; height: 32px;">
                                        <span>
                                            <asp:Label ID="txtstreetunit" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; height: 32px;">Village</td>
                                    <td style="text-align: left; height: 32px;">
                                        <span>
                                            <asp:Label ID="ddlVillageunit" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td style="text-align: left; height: 32px;">Mobile Number
                                    </td>
                                    <td style="text-align: left; height: 32px;">
                                        <span>
                                            <asp:Label ID="txtunitmobileno" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; height: 32px;">Email Id</td>
                                    <td style="text-align: left; height: 32px;">
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
                                    <td colspan="4" style="text-align: left;">
                                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="15px"
                                            ForeColor="Black">2.2 Office location</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; height: 32px;">District</td>
                                    <td style="text-align: left; height: 32px;">
                                        <span>
                                            <asp:Label ID="ddldistrictoffc" runat="server"></asp:Label>
                                        </span>s
                                    </td>
                                    <td style="text-align: left; height: 32px;">Survey No
                                    </td>
                                    <td style="text-align: left; height: 32px;">
                                        <span>
                                            <asp:Label ID="txtoffaddhnno" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; height: 32px;">Mandal</td>
                                    <td style="text-align: left; height: 32px;">
                                        <span>
                                            <asp:Label ID="ddloffcmandal" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td style="text-align: left; height: 32px;">Street
                                    </td>
                                    <td style="text-align: left; height: 32px;">
                                        <span>
                                            <asp:Label ID="txtstreetoffice" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; height: 32px;">Village</td>
                                    <td style="text-align: left; height: 32px;">
                                        <span>
                                            <asp:Label ID="ddlvilloffc" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td style="text-align: left; height: 32px;">Mobile Number
                                    </td>
                                    <td style="text-align: left; height: 32px;">
                                        <span>
                                            <asp:Label ID="txtOffcMobileNO" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; height: 32px;">Email Id</td>
                                    <td style="text-align: left; height: 32px;">
                                        <span>
                                            <asp:Label ID="txtOffcEmail" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td></td>
                                    <td>
                                        <span></span>

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: left;">
                                        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="15px"
                                            ForeColor="Black">3.0 Status</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: left; height: 32px">3.1 Type of Organization</td>
                                    <td colspan="2" style="text-align: left; height: 32px">
                                        <span>
                                            <asp:Label ID="ddltypeofOrg" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: left; height: 32px">3.2 Date of Commencement of Production</td>
                                    <td colspan="2" style="text-align: left; height: 32px">
                                        <span>
                                            <asp:Label ID="txtDateofCommencement" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: left; height: 32px">3.3 EM Part - II/IEM/IL No. 
                                        <br />
                                        &nbsp;&nbsp;&nbsp;(Date of Commencement of Production is the date of First Sale Bill/Invoice)</td>
                                    <td colspan="2" style="text-align: left; height: 32px">
                                        <span>
                                            <asp:Label ID="lblEMPartNo" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"></td>
                                </tr>
                                <tr>
                                    <td colspan="4"
                                        style="font-size: medium; text-align: left; font-weight: bold;">4.0 Line Of Activity</td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: left"><strong>Line of Activity</strong></td>
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
                                <tr>
                                    <td colspan="4"></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: left;">
                                        <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="15px"
                                            ForeColor="Black">5.0 Social Status</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: left; height: 32px">5.1 Caste</td>
                                    <td colspan="2" style="text-align: left; height: 32px">
                                        <span>
                                            <asp:Label ID="lblcaste" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: left;">
                                        <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="15px"
                                            ForeColor="Black">6.0 Details of the Director(s) / Partner(s)</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:GridView ID="GridViewdirectors" runat="server" AutoGenerateColumns="False"
                                            Font-Names="Verdana" Font-Size="12px" SkinID="gridviewSkin" Width="800px">
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
                                <tr>
                                    <td colspan="4"></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: left;">
                                        <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="15px"
                                            ForeColor="Black">7.0 Power</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">7.1 Power Released Date</td>
                                    <td style="text-align: left">
                                        <asp:Label ID="txtNewPowerReleaseDate" runat="server"></asp:Label>
                                    </td>
                                    <td style="text-align: left">7.3 Contracted load 
                                        <br />
                                        (in HP)</td>
                                    <td style="text-align: left">
                                        <asp:Label ID="txtNewContractedLoad" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">7.2 Connected load 
                                        <br />
                                        (in HP)</td>
                                    <td style="text-align: left">
                                        <asp:Label ID="txtNewConnectedLoad" runat="server"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="4">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4" style="text-align: center; color: black; font-size: medium; font-weight: bold;">Approved/Estimated projected cost, term loan sanctioned and released, assets acquired etc
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                            <tr>
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
                                                <td style="text-align: center">Value of assets  (as
                                                                                                    <br />
                                                    certified by financial<br />
                                                    institution)
                                                </td>
                                                <td style="text-align: center">Value of assets certified
                                                                                                    <br />
                                                    by Chartered Accoutant                                                                                         
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">1</td>
                                                <td style="text-align: center">2</td>
                                                <td style="text-align: center">3</td>
                                                <td style="text-align: center">4</td>
                                                <td style="text-align: center">5</td>
                                                <td style="text-align: center">6</td>
                                                <td style="text-align: center">7</td>
                                            </tr>
                                            <tr>
                                                <td style="height: 25px; text-align: left">Land</td>
                                                <td>
                                                    <asp:Label ID="txtLand2" runat="server"></asp:Label></td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtLand3" runat="server"></asp:Label>
                                                </td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtLand4" runat="server"></asp:Label></td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtLand5" runat="server"></asp:Label></td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtLand6" runat="server"></asp:Label></td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtLand7" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="height: 25px; text-align: left">Buildings</td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtBuilding2" runat="server"></asp:Label></td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtBuilding3" runat="server"></asp:Label>
                                                </td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtBuilding4" runat="server"></asp:Label></td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtBuilding5" runat="server"></asp:Label></td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtBuilding6" runat="server"></asp:Label></td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtBuilding7" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="height: 25px; text-align: left">Plant & Machinery</td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtPM2" runat="server"></asp:Label></td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtPM3" runat="server"></asp:Label>
                                                </td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtPM4" runat="server"></asp:Label></td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtPM5" runat="server"></asp:Label></td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtPM6" runat="server"></asp:Label></td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtPM7" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="height: 25px; text-align: left">Machinery Contingencies</td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtMCont2" runat="server"></asp:Label></td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtMCont3" runat="server"></asp:Label>
                                                </td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtMCont4" runat="server"></asp:Label></td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtMCont5" runat="server"></asp:Label></td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtMCont6" runat="server"></asp:Label></td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtMCont7" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="height: 25px; text-align: left">Erection</td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtErec2" runat="server"></asp:Label></td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtErec3" runat="server"></asp:Label>
                                                </td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtErec4" runat="server"></asp:Label></td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtErec5" runat="server"></asp:Label></td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtErec6" runat="server"></asp:Label></td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtErec7" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="height: 25px; text-align: left">Technical know-how,<br />
                                                    feasibility study</td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtTFS2" runat="server"></asp:Label></td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtTFS3" runat="server"></asp:Label>
                                                </td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtTFS4" runat="server"></asp:Label></td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtTFS5" runat="server"></asp:Label></td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtTFS6" runat="server"></asp:Label></td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtTFS7" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="height: 25px; text-align: left">Working Capital</td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtWC2" runat="server"></asp:Label></td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtWC3" runat="server"></asp:Label>
                                                </td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtWC4" runat="server"></asp:Label></td>
                                                <td style="height: 25px">
                                                    <asp:Label ID="txtWC5" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="txtWC6" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="txtWC7" runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"></td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4" style="text-align: left; font-size: medium; font-weight: bold;">Registration with Commercial taxes Department Registration
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">VAT No</td>
                                    <td style="text-align: left">
                                        <asp:Label ID="txtvatno" runat="server"></asp:Label></td>
                                    <td style="text-align: left">Registration Date</td>
                                    <td style="text-align: left">
                                        <span>
                                            <asp:Label ID="txtCSTRegDate" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">CST No</td>
                                    <td style="text-align: left">
                                        <asp:Label ID="txtcstno" runat="server"></asp:Label></td>
                                    <td style="text-align: left">Registring Authority Address</td>
                                    <td style="text-align: left">
                                        <span>
                                            <asp:Label ID="txtCSTRegAuthAddress" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">Registring Authority</td>
                                    <td style="text-align: left">
                                        <asp:Label ID="txtCSTRegAuthority" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="4"></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <br />
                    <input id="btnPrint" onclick="window.print()" style="border-right: thin solid; border-top: thin solid; width: 80px; border-left: thin solid; border-bottom: thin solid"
                        type="button" value="Print" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
