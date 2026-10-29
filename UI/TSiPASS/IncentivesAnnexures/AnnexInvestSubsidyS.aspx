<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AnnexInvestSubsidyS.aspx.cs" Inherits="UI_TSiPASS_IncentivesAnnexures_AnnexInvestSubsidyS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 27px;
        }

        .auto-style2 {
            height: 22px;
        }

        .auto-style3 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="align-content: center">
            <div style="align-content: center">
                <div style="align-content: center">
                    <center>
                    <img src="../../../Resource/Images/telanganalogo.png" width="75px" height="75px" />
                        </center>
                </div>

                <div align="center">
                    <center>

                         <table bgcolor="White" width="800" 
                                style="font-family: Verdana; font-size: small;">
                         <tr>
                                    <td colspan="4"></td>
                                </tr>
                          <tr>
                                     <td>
                                        <asp:Label ID="lblheadTPRIDE" runat="server" Visible="false" >
                                        </asp:Label>
                                         <asp:Label ID="lblheadTIDEA" runat="server" Visible="false">
                                        </asp:Label>
                                     </td>
                                 </tr>
                    </table>
                  </center>

                </div>

                <br />
                <div style="align-content: center">
                    <div align="center" id="divCommonAppli" runat="server" visible="false">
                        <div align="center">
                            <table bgcolor="White" width="600px" border="2px"
                                style="font-family: Verdana; font-size: small; text-align: left">

                                <tr>
                                    <td colspan="4"></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 30px;">
                                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="15px"
                                            ForeColor="Black">1.0. Details of Industry</asp:Label>:</td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 25px;">1.1. Name of the Enterprise:</td>
                                    <td colspan="2" style="height: 25px;">
                                        <span>
                                            <asp:Label ID="txtUnitname" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 25px;">1.2. Name of the Proprietor/Managing Partner / Managing Director</td>
                                    <td colspan="2" style="height: 25px;">
                                        <span>
                                            <asp:Label ID="txtApplicantName" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 25px;">1.3. TIN No. of the Enterprise/Industry/Proprietor/Managing Partner/Managing Director</td>
                                    <td colspan="2" style="height: 25px;">
                                        <span>
                                            <asp:Label ID="txtTinNumber" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 25px;">1.4. PAN No. of the Proprietor / Managing Partner /  Managing Director</td>
                                    <td colspan="2" style="height: 25px;">
                                        <span>
                                            <asp:Label ID="txtPanNumber" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"></td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4" style="text-align: left;">
                                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="15px"
                                            ForeColor="Black">2.0. Address of the Enterprise:</asp:Label>
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
                                    <td style="text-align: left; width: 200px">
                                        <span>
                                            <asp:Label ID="ddldistrictunit" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td>Survey No
                                    </td>
                                    <td style="text-align: left; width: 200px">
                                        <span>
                                            <asp:Label ID="txtunitaddhno" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td>Mandal</td>
                                    <td style="text-align: left; width: 200px">
                                        <span>
                                            <asp:Label ID="ddlUnitMandal" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td>Street</td>
                                    <td style="text-align: left; width: 200px">
                                        <span>
                                            <asp:Label ID="txtstreetunit" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td>Village</td>
                                    <td style="text-align: left; width: 200px">
                                        <span>
                                            <asp:Label ID="ddlVillageunit" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td>Mobile Number
                                    </td>
                                    <td style="text-align: left; width: 200px">
                                        <span>
                                            <asp:Label ID="txtunitmobileno" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td>Email Id</td>
                                    <td style="text-align: left; width: 200px">
                                        <span>
                                            <asp:Label ID="txtunitemailid" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td style="text-align: left; width: 200px">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4"></td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4" style="text-align: left;">
                                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="15px"
                                            ForeColor="Black">2.2 </asp:Label>
                                        Office Location</td>
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
                                <tr>
                                    <td colspan="4"></td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4" style="text-align: left;">
                                        <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="15px"
                                            ForeColor="Black">3.0 Status</asp:Label>
                                    </td>
                                </tr>
                                <tr>

                                    <%--<td colspan="4" style="text-align:left;">
                                        <table style="width:100%">
                                            <tr>--%>
                                                <td colspan="2" style="height: 25px;">3.1 Category</td>
                                                <td colspan="2" style="height: 25px;"><span>
                                                    <asp:Label ID="ddlCategory" runat="server"></asp:Label>
                                                </span></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="height: 25px;">3.2  Constitution of the Organisation   </td>
                                                <td colspan="2" style="height: 25px;">
                                                    <span>
                                                        <asp:Label ID="ddltypeofOrg" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="height: 25px;">3.3 Industry Status </td>
                                                <td colspan="2" style="height: 25px;">
                                                    <asp:Label ID="ddlindustryStatus" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="height: 25px;">3.4 Date of Commencement of Production
                                        <br />
                                                    (Date of Commencement of Production is the date of First Sale Bill/Invoice) 
                                                </td>
                                                <td colspan="2" style="height: 25px;">
                                                    <span>
                                                        <asp:Label ID="txtDateofCommencement" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="height: 25px;">3.5 EM Part - II/IEM/IL No.<br />
                                                    (copy to be enclosed)</td>
                                                <td colspan="2" style="height: 25px;">
                                                    <span>
                                                        <asp:Label ID="lblEMPartNo" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                       <%-- </table>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td colspan="4"></td>
                                </tr>
                                <tr id="tr2" runat="server" visible="true">
                                    <td colspan="4" style="font-size: 15px; text-align: left; font-weight: bold;">
                                        <asp:Label ID="Label9" runat="server" Text="4.0 "></asp:Label>&nbsp;
                                        Project details</td>
                                </tr>
                                <tr id="trexpansion1" runat="server" visible="true">
                                    <td colspan="4" style="font-size: small; text-align: left; font-weight: bold;">
                                        <asp:Label ID="lblIndustryStatus2" runat="server" Text="4.1 New Enterprise"></asp:Label>.&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"
                                        style="font-size: small; text-align: left; font-weight: bold;">LINE OF ACTIVITY</td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:GridView ID="gvLOA" runat="server" AutoGenerateColumns="False"
                                            Font-Names="Verdana" Font-Size="12px" SkinID="gridviewSkin" Width="80%">
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
                                    <td colspan="4"
                                        style="font-size: medium; text-align: left; font-weight: bold;" class="auto-style1">4.2 Expansion/Diversification Project (in Rs.)</td>
                                </tr>
                                <tr id="trexpansion" runat="server" visible="false">
                                    <td colspan="9">
                                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">

                                            <tr id="tr1" runat="server" visible="false">
                                                <td colspan="9">
                                                    <table bgcolor="White" width="1000" border="2px" style="font-family: Verdana; font-size: small;">
                                                        <tr>
                                                            <td></td>
                                                            <td style="text-align: center">Line Of Activity</td>
                                                            <td style="text-align: center">Installed Capacity<br />
                                                                (in Enterprises)</td>
                                                            <td style="text-align: center">% of increase under
                                                        <br />
                                                                <asp:Label ID="Label15" runat="server"></asp:Label></td>
                                                            <%--Expansion--%>
                                                        </tr>
                                                        <tr>
                                                            <td>Existing Enterprise</td>
                                                            <td>
                                                                <asp:Label ID="txteeploa" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <%--<asp:Label ID="txteepinscap" runat="server"      ></asp:Label>--%>
                                                                <table bgcolor="White" width="100%" border="2px" style="font-family: Verdana; font-size: small;">
                                                                    <tr>
                                                                        <td style="text-align: center">Quantity</td>
                                                                        <td style="text-align: center">Unit</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="txteepinscap" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="ddleepinscap" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txteeppercentage" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblexpan3" runat="server"></asp:Label>
                                                                <br />
                                                                Expansion/ Diversification Project</td>
                                                            <td>
                                                                <asp:Label ID="txtedploa" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <table bgcolor="White" width="100%" border="2px" style="font-family: Verdana; font-size: small;">
                                                                    <tr>
                                                                        <td style="text-align: center">Quantity</td>
                                                                        <td style="text-align: center">Unit</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="txtedpinscap" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="ddledpinscap" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtedppercentage" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4"
                                                    style="font-size: medium; text-align: left; font-weight: bold;">Fixed Capital Investment(in Rs.)</td>
                                            </tr>
                                            <%--<tr id="tr4" runat="server" visible="false">
                                                <td colspan="9">
                                                    <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                                        <tr>
                                                            <td style="text-align: center">Nature of Assets</td>
                                                            <td style="text-align: center">Existing Enterprise</td>
                                                            <td style="text-align: center">Under Expansion/Diversification<br />
                                                                Project</td>
                                                            <td>% of increase under<br />
                                                                Expansion/Diversification</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Land</td>
                                                            <td>
                                                                <asp:Label ID="txtlandexisting" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtlandexpandiver" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtlandpercentage" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Building</td>
                                                            <td>
                                                                <asp:Label ID="txtbuildingexisting" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtbuildingexpandiver" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtbuildingpercentage" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Plant & Machinery
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtplantexisting" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtplantexpandiver" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtplantpercentage" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>--%>
                                            <tr id="tr4" runat="server" visible="false">
                                                <td colspan="9">
                                                    <table bgcolor="White" width="1000" border="2px" style="font-family: Verdana; font-size: small;">
                                                        <tr>
                                                            <td style="text-align: center">Nature of Assets</td>
                                                            <td style="text-align: center">Existing Enterprise</td>
                                                            <td style="text-align: center">Under Expansion/Diversification<br />
                                                                Project</td>
                                                            <td>% of increase under<br />
                                                                Expansion/Diversification</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Land</td>
                                                            <td>
                                                                <asp:Label ID="txtlandexisting" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtlandexpandiver" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtlandpercentage" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style2">Building</td>
                                                            <td class="auto-style2">
                                                                <asp:Label ID="txtbuildingexisting" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="auto-style2">
                                                                <asp:Label ID="txtbuildingexpandiver" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="auto-style2">
                                                                <asp:Label ID="txtbuildingpercentage" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Plant & Machinery
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtplantexisting" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtplantexpandiver" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtplantpercentage" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Total
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblTotExisting" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblTotExpanEpan" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblTotPercentage" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <br />

                                            <tr>
                                                <td colspan="4"></td>
                                            </tr>

                                            <tr id="tr3" runat="server" visible="true">
                                                <td colspan="2" style="font-size: 15px; text-align: left; font-weight: bold;">5.0 Social Status</td>
                                                <td colspan="2" style="height: 25px;">
                                                    <asp:Label ID="rblCaste" runat="server"></asp:Label>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="4"
                                                    style="font-size: medium; text-align: center; font-weight: bold; width: 800px;">5.1 Details of the Director(s)/ Partner(s)</td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="height: 25px; text-align: center; grid-row-align: center">
                                                    <asp:GridView ID="GridViewdirectors" runat="server" AutoGenerateColumns="False"
                                                        Font-Names="Verdana" Font-Size="12px" SkinID="gridviewSkin" Width="1000px">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sl No.">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Name" HeaderText="Name" />
                                                            <asp:BoundField DataField="Community" HeaderText="Community" />
                                                            <asp:BoundField DataField="Share" HeaderText="Share%" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr id="tr5" runat="server" visible="true">
                                                <td align="center" colspan="4" style="text-align: left; font-size: medium; font-weight: bold;">6.0 Power</td>
                                            </tr>
                                            <tr id="tr6" runat="server" visible="true">
                                                <td style="text-align: left;">6.1 Power released Date</td>
                                                <td style="font-size: small; text-align: left;">
                                                    <asp:Label ID="txtNewPowerReleaseDate" runat="server"></asp:Label>&nbsp;
                                                </td>
                                                <td style="text-align: left;">6.2 Contracted load  </td>
                                                <td style="font-size: small; text-align: left;">
                                                    <asp:Label ID="txtNewContractedLoad" runat="server"></asp:Label>&nbsp;
                                                </td>
                                            </tr>
                                            <tr id="tr7" runat="server" visible="true">
                                                <td style="text-align: left;">6.3 Connected load   </td>
                                                <td style="font-size: small; text-align: left;">
                                                    <asp:Label ID="txtNewConnectedLoad" runat="server"></asp:Label>&nbsp;
                                                </td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                            <tr>

                                                <td align="center" colspan="4" style="text-align: left; font-size: medium; font-weight: bold;">
                                                    <asp:Label ID="lblIndustries6" runat="server">6.4 Employment</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <table bgcolor="White" width="1000" border="2px" style="font-family: Verdana; font-size: small;">
                                                        <tr>
                                                            <td></td>
                                                            <td></td>
                                                            <td>Male(Nos)
                                                            </td>
                                                            <td>Female(Nos)
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>a
                                                            </td>
                                                            <td>Management & Staff 
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtstaffMale" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtStaffFemale" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>b
                                                            </td>
                                                            <td>Supervisory 
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtSuprMale" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtSuperFemale" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>c
                                                            </td>
                                                            <td>Skilled workers
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtSkilledWorkersMale" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtSkilledWorkersFemale" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>d
                                                            </td>
                                                            <td>Semi-skilled workers
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtSemiSkilledWorkersMale" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtSemiSkilledWorkersFemale" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="4"
                                                    style="text-align: left; font-size: medium; font-weight: bold;">
                                                    <asp:Label ID="lblIndustries7" runat="server">7.0 Implementation Steps Taken</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left">7.1 Project Finance:</td>
                                                <td>
                                                    <asp:Label ID="Label17" runat="server"></asp:Label>

                                                    &nbsp;</td>
                                                <td style="text-align: left"></td>
                                                <td style="text-align: left"></td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left">7.2 Date of application for Term Loan</td>
                                                <td>
                                                    <asp:Label ID="txtTermloan" runat="server"></asp:Label>

                                                    &nbsp;</td>
                                                <td style="text-align: left"><span>7.3 Name of the Institution (with lead Institution in the event of joint or consortium financing)</span></td>
                                                <td style="text-align: left">
                                                    <span>
                                                        <asp:Label ID="txtnmofinstitution" runat="server"></asp:Label>
                                                    </span>

                                                </td>

                                            </tr>

                                            <tr>
                                                <td style="text-align: left">7.4 Term Loan Sanctioned reference No</td>
                                                <td style="text-align: left">
                                                    <span>
                                                        <asp:Label ID="txtsactionedloan" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                                <td style="text-align: left">7.5 Date:</td>
                                                <td style="text-align: left">
                                                    <span>
                                                        <asp:Label ID="txtdatesanctioned" runat="server"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="4"
                                                    style="text-align: center; font-size: medium; font-weight: bold;">8.0
                                        <asp:Label ID="lblIndustries9" runat="server" Font-Bold="True" Font-Size="14px">Approved/Estimated projected cost, term loan sanctioned and released, assets acquired etc</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <table bgcolor="White" width="1000" border="2px" style="font-family: Verdana; font-size: small;">
                                                        <tr>
                                                            <td></td>
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
                                                            <td></td>
                                                            <td style="text-align: center">1</td>
                                                            <td style="text-align: center">2</td>
                                                            <td style="text-align: center">3</td>
                                                            <td style="text-align: center">4</td>
                                                            <td style="text-align: center">5</td>
                                                            <td style="text-align: center">6</td>
                                                            <td style="text-align: center">7</td>
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
                                                            <td>
                                                                <asp:Label ID="txtLand6" runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="txtLand7" runat="server"></asp:Label></td>
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
                                                            <td>
                                                                <asp:Label ID="txtBuilding6" runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="txtBuilding7" runat="server"></asp:Label></td>
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
                                                            <td>
                                                                <asp:Label ID="txtPM6" runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="txtPM7" runat="server"></asp:Label></td>
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
                                                            <td>
                                                                <asp:Label ID="txtMCont6" runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="txtMCont7" runat="server"></asp:Label></td>
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
                                                            <td>
                                                                <asp:Label ID="txtErec6" runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="txtErec7" runat="server"></asp:Label></td>
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
                                                            <td>
                                                                <asp:Label ID="txtTFS6" runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="txtTFS7" runat="server"></asp:Label></td>
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
                                                            <td>
                                                                <asp:Label ID="txtWC6" runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="txtWC7" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td>Total</td>
                                                            <td>
                                                                <asp:Label ID="lblApprovedProjCost" runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lblLoanSanct" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblEquityPromoters" runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lblLoanAmtReleased" runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lblValueAssetsFI" runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lblValueAssetsCA" runat="server"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="padding: 5px; margin: 5px; text-align: left; width: 100%" valign="top"><strong>Note :</strong> The data on the above should be prior to date of filing of claim or within 6 months of Commencement of Production, whichever is earlier in case of aided Enterprise/Industry. If it is self financed Enterprise/Industry, the data on the above should be prior to date of commencement of Commercial Production.
                                                </td>
                                            </tr>
                                            <tr id="trsubidy1" runat="server" visible="false">
                                                <td colspan="4" style="padding: 5px; margin: 5px; text-align: left;"><strong>9.0 Total Amount of subsidy already availed:</strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <table style="width: 100%">
                                                        <tr id="trsubidy2" runat="server" visible="false">
                                                            <td>9.1</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Scheme
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 1px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="txtschema" runat="server"></asp:Label>

                                                            </td>
                                                            <td>9.2</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Amount
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px;" class="auto-style1">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="txtamount" runat="server"></asp:Label>

                                                            </td>
                                                        </tr>

                                                        <tr id="trSecondhandmachinery" runat="server" visible="false">
                                                            <td colspan="8">
                                                                <table style="width: 100%" bgcolor="White" width="800" border="2px"
                                                                    style="font-family: Verdana; font-size: small;">
                                                                    <tr>
                                                                        <td>10.0</td>
                                                                        <td align="center">
                                                                            <span>Second hand machinery
                                                                                                    <br />
                                                                                value in Rs</span></td>
                                                                        <td>New machinery value in Rs</td>
                                                                        <td>Total value in Rs<br />
                                                                            (1+2)</td>
                                                                        <td>% of second hand machinery
                                                                                        <br />
                                                                            value in total machinery value</td>
                                                                        <td>Value of the machinery
                                                                                        <br />
                                                                            purchaced from TSIDC<br />
                                                                            (Telangana unit)/TSSFC
                                                                                        <br />
                                                                            (Telangana unit)/Bank in Rs</td>
                                                                        <td>Total value in Rs
                                                                                        <br />
                                                                            (2+5)</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td></td>
                                                                        <td align="center">1</td>
                                                                        <td align="center">2</td>
                                                                        <td align="center">3</td>
                                                                        <td align="center">4</td>
                                                                        <td align="center">5</td>
                                                                        <td align="center">6</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td></td>
                                                                        <td>
                                                                            <asp:Label ID="txtsecondhndmachine" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="txtnewmachine" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="txtTotalvalue12" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="txtpercentage12" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="txtmachinepucr" runat="server"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="txttotal25" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="6"></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="8"
                                                                style="text-align: left; font-size: medium; font-weight: bold;">
                                                                <asp:Label ID="lblIndustries12" runat="server">11.0 Registration with Commercial taxes Department Registration</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="8">
                                                                <table class="auto-style3" style="width: 100%;">
                                                                    <tr>
                                                                        <td colspan="2">VAT No</td>
                                                                        <td>
                                                                            <asp:Label ID="txtvatno" runat="server"></asp:Label></td>
                                                                        <td>Registration Date</td>
                                                                        <td>
                                                                            <span>
                                                                                <asp:Label ID="txtVatDate" runat="server"></asp:Label>
                                                                            </span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">CST No</td>
                                                                        <td>
                                                                            <asp:Label ID="txtcstno" runat="server"></asp:Label></td>
                                                                        <td>Registration Date</td>
                                                                        <td>
                                                                            <span>
                                                                                <asp:Label ID="txtCSTRegDate" runat="server"></asp:Label>
                                                                            </span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">Registring Authority</td>
                                                                        <td>
                                                                            <asp:Label ID="txtCSTRegAuthority" runat="server"></asp:Label></td>
                                                                        <td>Registring Authority Address</td>
                                                                        <td>
                                                                            <span>
                                                                                <asp:Label ID="txtCSTRegAuthAddress" runat="server"></asp:Label>
                                                                            </span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" style="text-align: right"><strong>Total:</strong></td>
                                                                        <td colspan="6">
                                                                            <span>Rs. &nbsp;<asp:Label ID="Label19" runat="server"></asp:Label>
                                                                            </span>
                                                                        </td>
                                                                    </tr>

                                                                    <tr>
                                                                        <td colspan="8"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="8"
                                                                            style="text-align: left; font-size: medium; font-weight: bold;">
                                                                            <asp:Label ID="Label1" runat="server">12.0 Incentives Applied for (in Rs.) on fixed capital investment</asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="text-align: left" colspan="4">12.1 Investment Subsidy</td>
                                                                        <td style="text-align: left" colspan="4">
                                                                            <asp:Label ID="txtAppldInvestSubsidy" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="text-align: left" colspan="4">12.2 An additional investment subsidy for Women entrepreneurs.</td>
                                                                        <td style="text-align: left" colspan="4">
                                                                            <asp:Label ID="txtAppldAddlAmtWomen" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="text-align: left" colspan="4">12.3 An additional investment subsidy for SC/ST entrepreneurs</td>
                                                                        <td style="text-align: left" colspan="4">
                                                                            <asp:Label ID="txtISCSCT" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="text-align: left" colspan="4">12.4 An additional investment subsidy for Women entrepreneurs set up in Scheduled areas</td>
                                                                        <td style="text-align: left" colspan="4">
                                                                            <asp:Label ID="txtScheduledAreas" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="text-align: right" colspan="4"><strong>Total :</strong> </td>
                                                                        <td style="text-align: left" colspan="4">
                                                                            <asp:Label ID="txtAppldTotInvestSubsidy" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <br />
                                                    <center>
                                                    <input id="btnPrint" onclick="window.print()" style="border-right: thin solid; border-top: thin solid; width: 80px; border-left: thin solid; border-bottom: thin solid"
                                                        type="button" value="Print" />
                                                    &nbsp;&nbsp;&nbsp;
                                       </center>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </form>


</body>
</html>
