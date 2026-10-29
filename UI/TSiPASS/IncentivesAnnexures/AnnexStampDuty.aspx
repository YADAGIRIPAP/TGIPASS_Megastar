<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AnnexStampDuty.aspx.cs" Inherits="UI_TSiPASS_IncentivesAnnexures_AnnexStampDuty" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
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
                            <table bgcolor="White" width="800" border="2px"
                                style="font-family: Verdana; font-size: small;">
                           
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
                                            ForeColor="Black">2.2 Offices location</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>District</td>
                                    <td style="text-align: left; width: 200px">
                                        <span>
                                            <asp:Label ID="ddldistrictoffc" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td>Survey No
                                    </td>
                                    <td style="text-align: left; width: 200px">
                                        <span>
                                            <asp:Label ID="txtoffaddhnno" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td>Mandal</td>
                                    <td style="text-align: left; width: 200px">
                                        <span>
                                            <asp:Label ID="ddloffcmandal" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td>Street
                                    </td>
                                    <td style="text-align: left; width: 200px">
                                        <span>
                                            <asp:Label ID="txtstreetoffice" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td>Village</td>
                                    <td style="text-align: left; width: 200px">
                                        <span>
                                            <asp:Label ID="ddlvilloffc" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td>Mobile Number
                                    </td>
                                    <td style="text-align: left; width: 200px">
                                        <span>
                                            <asp:Label ID="txtOffcMobileNO" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td>Email Id</td>
                                    <td style="text-align: left; width: 200px">
                                        <span>
                                            <asp:Label ID="txtOffcEmail" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td></td>
                                    <td style="text-align: left; width: 200px">
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
                                    <td colspan="2">3.2.  Constitution of the Organisation</td>
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
                                    <td align="center" colspan="4" style="text-align: left;">
                                        <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="15px"
                                            ForeColor="Black">4.0 Status of the Industry</asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="2">4.1 Status of the Industry</td>
                                    <td colspan="2">
                                        <span>
                                            <asp:Label ID="ddlindustryStatus" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"></td>
                                </tr>
                                <tr id="trexpansion1" runat="server" visible="true">
                                    <td colspan="4" style="font-size: large; text-align: left; font-weight: bold;">
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
                                        style="font-size: medium; text-align: left; font-weight: bold;">FIXED CAPITAL INVESTMENT(in Rs.)</td>
                                </tr>
                                <tr id="tr1" runat="server" visible="true">
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
                                        style="font-size: medium; font-weight: bold;">LINE OF ACTIVITY</td>
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
                            </table>
                        </div>
                    </div>
                    <div align="center" id="divStampDuty" runat="server" visible="true">
                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                            <tr>
                                <td align="center" colspan="4"
                                    style="text-align: center; font-size: medium; font-weight: bold;">
                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="14px">Reimbursement of Stamp Duty, Transfer Duty, Mortgage Duty, Land Conversion Charges & Land Cost</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="font-size: medium">
                                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="13px" ForeColor="Black">1   Land purchased details</asp:Label></td>
                                <td colspan="2" style="font-size: medium">
                                    <asp:Label ID="Label18" runat="server" Font-Bold="True" Font-Size="13px" ForeColor="Black">2   Registered Deed Details</asp:Label></td>
                            </tr>
                            <tr>
                                <td>1.1  Area as per registered sale deed in Sq Mts</td>
                                <td>
                                    <asp:Label ID="txtAreaRegdSaledeed" runat="server"></asp:Label></td>
                                <td>2.1  Nature of transaction / deed registered for industrial use Sale deed / lease deed / Mortgage</td>
                                <td>
                                    <asp:Label ID="txtNatureofTrans" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>1.2  Plinth area of the building as per approved plan By HUDA / DT&CP / IALA in Sq. Mts</td>
                                <td>
                                    <asp:Label ID="txtPlnthAreaBuild" runat="server"></asp:Label></td>
                                <td>2.2  Sub Registrar office</td>
                                <td>
                                    <asp:Label ID="txtSubRegOffc" runat="server"></asp:Label></td>
                            </tr>

                            <tr>
                                <td>1.3  5 times of the plinth area of factory building in Sq. Mts</td>
                                <td>
                                    <asp:Label ID="txtFivePlnthAreaBuild" runat="server"></asp:Label></td>
                                <td>2.3  Registered deed number</td>
                                <td>
                                    <asp:Label ID="txtRegdDeedNo" runat="server"></asp:Label></td>
                            </tr>

                            <tr>
                                <td>1.4  Area required for the factory as per the appraisal in Sq. Mts.</td>
                                <td>
                                    <asp:Label ID="txtAreaReqdAppraisal" runat="server"></asp:Label></td>
                                <td>2.4  Date Of Registration</td>
                                <td>
                                    <asp:Label ID="txtRegDate" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>1.5  Area required for the factory as per the norms of TSPCB or any other state govt. department in Sq. Mts.</td>
                                <td>
                                    <asp:Label ID="txtAreaReqdTSPCB" runat="server"></asp:Label></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td colspan="4" style="padding: 5px; margin: 5px; text-align: center;">
                                    <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                        <tr>
                                            <td colspan="4" style="font-weight: bold; text-align: left">3   Details of duty paid and claimed</td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td><strong>Nature Of Payment</strong></td>
                                            <td><strong>Amount Paid</strong></td>
                                            <td><strong>Amount Claimed</strong></td>
                                        </tr>
                                        <tr>
                                            <td>3.1</td>
                                            <td>Stamp Duty / transfer duty</td>
                                            <td align="center">
                                                <asp:Label ID="txtStampTranfrDutyAP" runat="server"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="txtStampTranfrDutyAC" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>3.2</td>
                                            <td>Mortgage & Hypothecations Duty</td>
                                            <td align="center">
                                                <asp:Label ID="txtMortgageHypothDutyAP" runat="server"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="txtMortgageHypothDutyAC" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>3.3</td>
                                            <td>Land Conversion charges</td>
                                            <td align="center">
                                                <asp:Label ID="txtLandConvrChrgAP" runat="server"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="txtLandConvrChrgAC" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>3.4</td>
                                            <td>Cost of land in case of purchase in IE / IDA / IP</td>
                                            <td align="center">
                                                <asp:Label ID="txtLandCostIeIdaIpAP" runat="server"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="txtLandCostIeIdaIpAC" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
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
