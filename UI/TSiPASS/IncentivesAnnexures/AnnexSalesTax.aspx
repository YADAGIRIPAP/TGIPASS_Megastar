<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AnnexSalesTax.aspx.cs" Inherits="UI_TSiPASS_IncentivesAnnexures_AnnexSalesTax" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style>
        .div3 {
            /*-webkit-column-count: 3;
    -moz-column-count: 3; 
    column-count: 3; */
            -webkit-column-gap: 40px; /* Chrome, Safari, Opera */
            -moz-column-gap: 40px; /* Firefox */
            column-gap: 40px;
        }

        .w3-code {
            border-left: 5px solid #73AD21 !important;
            font-size: 17px;
            padding: 5px;
            font-weight: bold;
            color: #082ea2;
        }

        .w4-code {
            border-left: 5px solid #73AD21 !important;
            font-size: 14px;
            padding: 5px;
            font-weight: bold;
            color: #082ea2;
        }

        ol.u {
            list-style-type: none;
            ;
            font-size: 13px;
            padding: 10px 10px 10px 10px;
        }

        ol.v {
            list-style-type: inherit;
            font-size: 17px;
            font-weight: bold;
            padding: 10px 10px 10px 10px;
        }

        .table {
            border-collapse: collapse;
            width: 100%;
        }

        th, td {
            text-align: left;
            border: 2px solid ActiveCaptionText;
            padding: 8px;
        }
    </style>
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
                                    <td colspan="4">
                                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="15px"
                                            ForeColor="Black">1.0. Details of Enterprise/Industry</asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="2">1.1. Name of the Enterprise</td>
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
                                <tr>
                                    <td colspan="4"></td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4" style="text-align: left;">
                                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="15px"
                                            ForeColor="Black">2.0. Address of the Enterprise</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4"
                                        style="text-align: left;">
                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="15px"
                                            ForeColor="Black">2.1 Factory Location</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>District</td>
                                    <td style="text-align: left; width: 200px;">
                                        <span>
                                            <asp:Label ID="ddldistrictunit" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td>Survey No
                                    </td>
                                    <td style="text-align: left; width: 200px;">
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
                                            ForeColor="Black">2.2 Office location</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>District</td>
                                    <td style="text-align:left;width:200px;">
                                        <span>
                                            <asp:Label ID="ddldistrictoffc" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td>Survey No
                                    </td>
                                    <td style="text-align:left;width:200px;">
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
                                        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="15px"
                                            ForeColor="Black">3.0 Status</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">3.1 Category</td>
                                    <td colspan="2">
                                        <asp:Label ID="ddlCategory" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">3.2  Constitution of the Organisation</td>
                                    <td colspan="2">
                                        <span>
                                            <asp:Label ID="ddltypeofOrg" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">3.3 Date of Commencement of Production</td>
                                    <td colspan="2">
                                        <span>
                                            <asp:Label ID="txtDateofCommencement" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">3.4 EM Part - II/IEM/IL No.</td>
                                    <td colspan="2">
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
                                    <td colspan="4"
                                        style="font-size: large; text-align: center; background-color: #0066FF; color: #FFFFFF; font-weight: bold;">FIXED CAPITAL INVESTMENT(in Rs.)</td>
                                </tr>
                                <tr id="tr1" runat="server" visible="false">
                                    <td colspan="4">
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
                                    <td colspan="2"><strong>Line of Activity</strong>  :  
                                        <asp:Label ID="lblLineofActiivity" runat="server"></asp:Label></td>
                                    <td colspan="2"></td>
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
                                    <td align="center" colspan="4"
                                        style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                        <asp:Label ID="Label19" runat="server" Font-Bold="True" Font-Size="18px"
                                            ForeColor="White">Reimbursement of Sales Tax</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="font-weight: bold; text-align: left">1.  Production Details preceeding 3 years before expansion / diversification 
                                            <br />
                                        &nbsp;&nbsp;&nbsp; certified by the financial institution / CA
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:GridView ID="gvProductiondtls" runat="server" AutoGenerateColumns="False"
                                            Font-Names="Verdana" Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sl No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="FinancialYearNew" HeaderText="Financial year" />
                                                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                                <asp:BoundField DataField="Unit" HeaderText="Unit" />
                                                <asp:BoundField DataField="Value" HeaderText="Value In Rs" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"></td>
                                </tr>
                                <tr>
                                    <td style="font-weight: bold; text-align: left" colspan="4">2. Sales Tax paid since DCP as certified by CTO</td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:GridView ID="gvSalesTax" runat="server" AutoGenerateColumns="False"
                                            Font-Names="Verdana" Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sl No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="FinancialYearNew" HeaderText="Financial year" />
                                                <asp:BoundField DataField="F_AmountPaid" HeaderText="1st Half Year Amount Paid in Rs." />
                                                <asp:BoundField DataField="F_AmountClaimed" HeaderText="1st Half Year Amount claimed in Rs." />
                                                <asp:BoundField DataField="S_AmountPaid" HeaderText="2nd Half Year Amount Paid in Rs." />
                                                <asp:BoundField DataField="S_AmountClaimed" HeaderText="2nd Half Year Amount claimed in Rs." />
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

                    <br />
                    <input id="btnPrint" onclick="window.print()" style="border-right: thin solid; border-top: thin solid; width: 80px; border-left: thin solid; border-bottom: thin solid"
                        type="button" value="Print" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
