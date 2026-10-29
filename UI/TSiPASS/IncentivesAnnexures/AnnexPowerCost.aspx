<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AnnexPowerCost.aspx.cs" Inherits="UI_TSiPASS_IncentivesAnnexures_AnnexPowerCost" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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

                <div align="center">
                    <br />
                    <div align="center" id="divCommonAppli" runat="server" visible="false">
                        <div align="center">
                            <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                             
                                <tr>
                                    <td colspan="4"></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: left;">
                                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="15px"
                                            ForeColor="Black">1.0. Details of Enterprise/Industry</asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: left;">1.1. Name of the Enterprise</td>
                                    <td colspan="2" style="text-align: left;">
                                        <span>
                                            <asp:Label ID="txtUnitname" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: left;">1.2. Name of the Proprietor/Managing Partner / Managing Director</td>
                                    <td colspan="2" style="text-align: left;">
                                        <span>
                                            <asp:Label ID="txtApplicantName" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: left;">1.3. TIN No. of the Enterprise/Industry/Proprietor/Managing Partner/Managing Director</td>
                                    <td colspan="2" style="text-align: left;">
                                        <span>
                                            <asp:Label ID="txtTinNumber" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: left;">1.4. PAN No. of the Proprietor / Managing Partner /  Managing Director</td>
                                    <td colspan="2" style="text-align: left;">
                                        <span>
                                            <asp:Label ID="txtPanNumber" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: left;">
                                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="15px"
                                            ForeColor="Black">2.0. Address of the Enterprise</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4" style="text-align: left;">
                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="15px" ForeColor="Black">2.1 Factory Location</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">District</td>
                                    <td style="text-align: left; width: 200px;">
                                        <span>
                                            <asp:Label ID="ddldistrictunit" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td style="text-align: left;">Survey No
                                    </td>
                                    <td style="text-align: left; width: 200px;">
                                        <span>
                                            <asp:Label ID="txtunitaddhno" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">Mandal</td>
                                    <td style="text-align: left; width: 200px;">
                                        <span>
                                            <asp:Label ID="ddlUnitMandal" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td style="text-align: left;">Street</td>
                                    <td style="text-align: left; width: 200px;">
                                        <span>
                                            <asp:Label ID="txtstreetunit" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">Village</td>
                                    <td style="text-align: left; width: 200px;">
                                        <span>
                                            <asp:Label ID="ddlVillageunit" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td style="text-align: left;">Mobile Number
                                    </td>
                                    <td style="text-align: left; width: 200px;">
                                        <span>
                                            <asp:Label ID="txtunitmobileno" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">Email Id</td>
                                    <td style="text-align: left; width: 200px;">
                                        <span>
                                            <asp:Label ID="txtunitemailid" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td style="text-align: left; width: 200px;">&nbsp;</td>
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
                                    <td style="text-align: left;">District</td>
                                    <td style="text-align: left; width: 200px;">
                                        <span>
                                            <asp:Label ID="ddldistrictoffc" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td style="text-align: left;">Survey No
                                    </td>
                                    <td style="text-align: left; width: 200px;">
                                        <span>
                                            <asp:Label ID="txtoffaddhnno" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">Mandal</td>
                                    <td style="text-align: left; width: 200px;">
                                        <span>
                                            <asp:Label ID="ddloffcmandal" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td style="text-align: left;">Street
                                    </td>
                                    <td style="text-align: left; width: 200px;">
                                        <span>
                                            <asp:Label ID="txtstreetoffice" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">Village</td>
                                    <td style="text-align: left; width: 200px;">
                                        <span>
                                            <asp:Label ID="ddlvilloffc" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td style="text-align: left;">Mobile Number
                                    </td>
                                    <td style="text-align: left; width: 200px;">
                                        <span>
                                            <asp:Label ID="txtOffcMobileNO" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">Email Id</td>
                                    <td style="text-align: left; width: 200px;">
                                        <span>
                                            <asp:Label ID="txtOffcEmail" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td></td>
                                    <td style="text-align: left; width: 200px;">
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
                                    <td colspan="2" style="text-align: left;">3.1 Category</td>
                                    <td colspan="2" style="text-align: left;">
                                        <asp:Label ID="ddlCategory" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: left;">3.2 Constitution of the Organisation</td>
                                    <td colspan="2" style="text-align: left;">
                                        <span>
                                            <asp:Label ID="ddltypeofOrg" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: left;">3.3 Date of Commencement of Production</td>
                                    <td colspan="2" style="text-align: left;">
                                        <span>
                                            <asp:Label ID="txtDateofCommencement" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: left;">3.4 EM Part - II/IEM/IL No.</td>
                                    <td colspan="2" style="text-align: left;">
                                        <span>
                                            <asp:Label ID="lblEMPartNo" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"></td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4" style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                        <asp:Label ID="lblIndustries6" runat="server" Font-Bold="True" Font-Size="18px"
                                            ForeColor="White">Employment</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                            <tr>
                                                <td></td>
                                                <td></td>
                                                <td>Male(Nos)
                                                </td>
                                                <td>Female(Nos)
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>1
                                                </td>
                                                <td style="text-align: left;">Management & Staff 
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="txtstaffMale" runat="server"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="txtStaffFemale" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>2
                                                </td>
                                                <td style="text-align: left;">Supervisory 
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="txtSuprMale" runat="server"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="txtSuperFemale" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>3
                                                </td>
                                                <td style="text-align: left;">Skilled workers
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="txtSkilledWorkersMale" runat="server"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="txtSkilledWorkersFemale" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>4
                                                </td>
                                                <td style="text-align: left;">Semi-skilled workers
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="txtSemiSkilledWorkersMale" runat="server"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="txtSemiSkilledWorkersFemale" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: left;">
                                        <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="15px"
                                            ForeColor="Black">4.0 Status of the Industry</asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="2" style="text-align: left;">4.1 Status of the Industry</td>
                                    <td colspan="2" style="text-align: left;">
                                        <span>
                                            <asp:Label ID="lblIndustryStatus1" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"></td>
                                </tr>                                
                                <tr id="trexpansion1" runat="server" visible="false">
                                    <td colspan="4" style="font-size: large; text-align: center; background-color: #0066FF; color: #FFFFFF; font-weight: bold;">
                                        <asp:Label ID="lblIndustryStatus2" runat="server"></asp:Label>&nbsp;
                                        Project (in Rs.)</td>
                                </tr>
                                <tr id="trexpansion2" runat="server" visible="false">
                                    <td colspan="9">
                                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                            <tr>
                                                <td></td>
                                                <td style="text-align: center"><strong>Line Of Activity</strong></td>
                                                <td style="text-align: center"><strong>Installed Capacity</strong></td>
                                                <td style="text-align: center"><strong>% of increase under
                                                        <br />
                                                    <asp:Label ID="lblexpan2" runat="server"></asp:Label></strong></td>
                                                <%--Expansion--%>
                                            </tr>
                                            <tr>
                                                <td><strong>Existing</strong></td>
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
                                                    <strong>
                                                        <asp:Label ID="lblexpan3" runat="server"></asp:Label>
                                                        <br />
                                                        Project</strong></td>
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
                                    <td colspan="4"></td>
                                </tr>
                                <tr>
                                    <td colspan="4"
                                        style="font-size: large; text-align: center; background-color: #0066FF; color: #FFFFFF; font-weight: bold;">FIXED CAPITAL INVESTMENT(in Rs.)</td>
                                </tr>
                                <tr id="tr1" runat="server" visible="false">
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
                                </tr>
                                <tr>
                                    <td colspan="4"></td>
                                </tr>
                                <tr>
                                    <td colspan="4"
                                        style="font-size: large; text-align: center; background-color: #0066FF; color: #FFFFFF; font-weight: bold;">LINE OF ACTIVITY</td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align:left"><strong>Line of Activity</strong>  :  
                                        <asp:Label ID="lblLineofActiivity" runat="server"></asp:Label></td>
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
                            </table>
                        </div>
                    </div>
                    <br />
                    <br />

                    <div align="center" id="divPowerCost" runat="server" visible="false">
                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                            <tr>
                                <td align="center" colspan="4"
                                    style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="18px"
                                        ForeColor="White">Reimbursement of Power Cost</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:left">
                                    <asp:Label ID="lblpowerHEAD" Text="Power Type" runat="server"></asp:Label></td>

                                <td style="text-align:left">
                                    <asp:Label ID="ddlPowerStatus" runat="server"></asp:Label>
                                </td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td style="text-align:left">Power Released Date</td>
                                <td style="text-align:left">
                                    <asp:Label ID="txtNewPowerReleaseDate" runat="server"></asp:Label>
                                </td>
                                <td style="text-align:left">Existing power connection (in HP)</td>
                                <td style="text-align:left">
                                    <asp:Label ID="txtNewConnectedLoad" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:left">New power connection (in HP)</td>
                                <td style="text-align:left">
                                    <asp:Label ID="txtNewContractedLoad" runat="server"></asp:Label>
                                </td>
                                <td></td>
                                <td></td>
                            </tr>
                           <%-- <tr><td colspan="4"></td></tr>--%>
                            <tr>
                                <td style="font-weight: bold; text-align: left" colspan="4">1.  For Expansion / Diversification</td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; text-align: left;height:50px" colspan="4">1.1 Power utilised during previous 3 years</td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:GridView ID="gvPowerIncentives" runat="server" AutoGenerateColumns="False"
                                        Font-Names="Verdana" Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="FinancialYear" HeaderText="Financial year" />
                                            <asp:BoundField DataField="UnitsConsumed" HeaderText="Total Units consumed" />
                                            <asp:BoundField DataField="Amount" HeaderText="Amount paid in Rs" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <%--<tr>
                                <td colspan="4"></td>
                            </tr>--%>
                            <tr>
                                <td style="font-weight: bold; text-align: left" colspan="4">2. Energy consumption details from DCP</td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:GridView ID="gvEnergy" runat="server" AutoGenerateColumns="False"
                                        Font-Names="Verdana" Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="FinancialYear" HeaderText="Financial year" />
                                            <asp:BoundField DataField="F_UnitsConsumed" HeaderText="1st Half Year Units consumed" />
                                            <asp:BoundField DataField="F_Amount" HeaderText="1st Half Year Amount paid in Rs" />
                                            <asp:BoundField DataField="S_UnitsConsumed" HeaderText="2nd Half Year Units consumed" />
                                            <asp:BoundField DataField="S_Amount" HeaderText="2nd Half Year Amount paid in Rs" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4"></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; text-align: left" colspan="4">Amount Clamed    :&nbsp;   
                                            <asp:Label ID="txtClaimedAmount" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="4"></td>
                            </tr>
                        </table>
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
