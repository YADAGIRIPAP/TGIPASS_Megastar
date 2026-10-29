<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AnnexPavalaVaddi.aspx.cs" Inherits="UI_TSiPASS_IncentivesAnnexures_AnnexPavalaVaddi" %>

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
                    <center>

                        <table bgcolor="White" width="800"
                            style="font-family: Verdana; font-size: small;">
                            <tr>
                                <td colspan="4"></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblheadTPRIDE" runat="server" Visible="false">
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




                            <table bgcolor="White" width="800" border="2px"
                                style="font-family: Verdana; font-size: small;">
                                <tr>
                                </tr>
                                <tr>
                                    <td colspan="4"></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: left; height: 30px">
                                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="15px"
                                            ForeColor="Black">1.0. Details of Enterprise/Industry</asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: left; height: 28px;">1.1. Name of the Enterprise</td>
                                    <td colspan="2" style="text-align: left; height: 28px;">
                                        <span>
                                            <asp:Label ID="txtUnitname" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: left; height: 28px;">1.2. Name of the Proprietor/Managing Partner / Managing Director</td>
                                    <td colspan="2" style="text-align: left; height: 28px;">
                                        <span>
                                            <asp:Label ID="txtApplicantName" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: left; height: 28px;">1.3. TIN No. of the Enterprise/Industry/Proprietor/Managing Partner/Managing Director</td>
                                    <td colspan="2" style="text-align: left; height: 28px;">
                                        <span>
                                            <asp:Label ID="txtTinNumber" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: left; height: 28px;">1.4. PAN No. of the Proprietor / Managing Partner /  Managing Director</td>
                                    <td colspan="2" style="text-align: left; height: 28px;">
                                        <span>
                                            <asp:Label ID="txtPanNumber" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: left; height: 28px;">1.5. Constitution of the Entrepreneur</td>
                                    <td colspan="2" style="text-align: left; height: 28px;">
                                        <span>
                                            <asp:Label ID="ddltypeofOrg" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: left; height: 30px">
                                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="15px"
                                            ForeColor="Black">2.0. Address of the Enterprise</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4" style="text-align: left; height: 30px">
                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="15px" ForeColor="Black">2.1 Factory Location</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; height: 28px;">District</td>
                                    <td style="text-align: left; height: 28px;width:200px;">
                                        <span>
                                            <asp:Label ID="ddldistrictunit" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td style="text-align: left; height: 28px;">Survey No
                                    </td>
                                    <td style="text-align: left; height: 28px;width:200px;">
                                        <span>
                                            <asp:Label ID="txtunitaddhno" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; height: 28px;">Mandal</td>
                                    <td style="text-align: left; height: 28px;">
                                        <span>
                                            <asp:Label ID="ddlUnitMandal" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td style="text-align: left; height: 28px;">Street</td>
                                    <td style="text-align: left; height: 28px;">
                                        <span>
                                            <asp:Label ID="txtstreetunit" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; height: 28px;">Village</td>
                                    <td style="text-align: left; height: 28px;">
                                        <span>
                                            <asp:Label ID="ddlVillageunit" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td style="text-align: left; height: 28px;">Mobile Number
                                    </td>
                                    <td style="text-align: left; height: 28px;">
                                        <span>
                                            <asp:Label ID="txtunitmobileno" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; height: 28px;">Email Id</td>
                                    <td style="text-align: left; height: 28px;">
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
                                    <td colspan="4" style="text-align: left; height: 30px">
                                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="15px"
                                            ForeColor="Black">2.2 Office location</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; height: 28px;">District</td>
                                    <td style="text-align: left; height: 28px;width:200px;">
                                        <span>
                                            <asp:Label ID="ddldistrictoffc" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td style="text-align: left; height: 28px;">Survey No
                                    </td>
                                    <td style="text-align: left; height: 28px;width:200px;">
                                        <span>
                                            <asp:Label ID="txtoffaddhnno" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; height: 28px;">Mandal</td>
                                    <td style="text-align: left; height: 28px;">
                                        <span>
                                            <asp:Label ID="ddloffcmandal" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td style="text-align: left; height: 28px;">Street
                                    </td>
                                    <td style="text-align: left; height: 28px;">
                                        <span>
                                            <asp:Label ID="txtstreetoffice" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; height: 28px;">Village</td>
                                    <td style="text-align: left; height: 28px;">
                                        <span>
                                            <asp:Label ID="ddlvilloffc" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td style="text-align: left; height: 28px;">Mobile Number
                                    </td>
                                    <td style="text-align: left; height: 28px;">
                                        <span>
                                            <asp:Label ID="txtOffcMobileNO" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; height: 28px;">Email Id</td>
                                    <td style="text-align: left; height: 28px;">
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
                                    <td colspan="4" style="text-align: left; height: 30px">
                                        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="15px"
                                            ForeColor="Black">3.0 Social Status</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: left; height: 28px;">3.1 Caste</td>
                                    <td colspan="2" style="text-align: left; height: 28px;">
                                        <asp:Label ID="rblCaste" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: left; height: 30px">
                                        <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="15px"
                                            ForeColor="Black">4.0 Details of the Director(s) / Partner(s)</asp:Label>
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
                                                <asp:BoundField DataField="Share" HeaderText="Share %" />

                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: left; height: 30px">
                                        <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="15px"
                                            ForeColor="Black">5.0 New Enterprise Details</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: left; height: 28px;">5.1 Date of Commencement of Production</td>
                                    <td colspan="2" style="text-align: left; height: 28px;">
                                        <span>
                                            <asp:Label ID="txtDateofCommencement" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: left; height: 28px;">5.2 EM Part - II/IEM/IL No. 
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp; (Date of Commencement of Production is the date of First Sale Bill/Invoice)</td>
                                    <td colspan="2" style="text-align: left; height: 28px;">
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
                                        style="font-size: medium; text-align: left; font-weight: bold;">6.0 Fixed Capital Investment(in Rs.)</td>
                                </tr>
                                <tr id="tr1" runat="server" visible="true">
                                    <td colspan="4">
                                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                            <tr>
                                                <td style="text-align: center"><strong>Nature of Assets</strong></td>
                                                <td style="text-align: center"><strong>Existing Enterprise</strong></td>
                                                <td style="text-align: center"><strong>Under Expansion/Diversification<br />
                                                    Project</strong></td>
                                                <td><strong>% of increase under<br />
                                                    Expansion/Diversification</strong></td>
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
                                        style="font-size: medium; text-align: left; font-weight: bold;">7.0 Line Of Activity</td>
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
                            </table>
                        </div>
                    </div>
                    <div align="center" id="divPavalaVaddi" runat="server" visible="false">
                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                            <tr>
                                <td align="center" colspan="4"
                                    style="text-align: left; color: black; font-size: medium; font-weight: bold;">8.0 Details of Term Loan Sanctioned and Availed</td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; text-align: left">1.  Interest paid details from DCP</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvInterestDCP" runat="server" AutoGenerateColumns="False"
                                        Font-Names="Verdana" Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                        <HeaderStyle Width="100px" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="FinancialYear" HeaderText="Financial year" />
                                            <asp:BoundField DataField="IntrestPaid" HeaderText="Interest paid on Term Loan on half yearly basis" />
                                            <asp:BoundField DataField="RateofIntrest" HeaderText="Rate of interest %" />
                                            <asp:BoundField DataField="IntrestPenaltyPaid" HeaderText="Interest paid (Rs.) excluding penal interest" />
                                            <asp:BoundField DataField="Eligible" HeaderText="Eligible % (Max 9%)" />
                                            <asp:BoundField DataField="AmountClaimed" HeaderText="Amount claimed (Rs.)" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
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
