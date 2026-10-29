<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AnnexIIDF.aspx.cs" Inherits="UI_TSiPASS_AnnexIIDF" %>

<!DOCTYPE html>

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
                        <img src="../../../Resource/Images/telanganalogo.png" width="75px" height="75px" />
                    </center>
                    <h3>TS-iPASS COMMON APPLICATION FORM</h3>
                </div>
                <br />
                <div align="center" id="divCommonAppli" runat="server" visible="false">
                    <div align="center">
                        <table bgcolor="White" width="800" border="2px"
                            style="font-family: Verdana; font-size: small; text-align: left">
                            <tr>
                                <td align="center" colspan="4"
                                    style="text-align: center; background-color: #0066FF; vertical-align: top">
                                    <asp:Label ID="lblIndustries1" runat="server" Font-Bold="True" Font-Size="15px"
                                        ForeColor="White">ANNEXURE: XV  <br /><br />APPLICATION CUM VERIFICATION FOR SANCTION OF INDUSTRIAL INFRASTRUCTURE DEVELOPMENT FUND (IIDF) UNDER T-PRIDE— TELANGANA STATE PROGRAM FOR RAPID INCUBATION OF DALIT ENTREPRENEURS INCENTIVE SCHEME. <br />(G.O.Ms.No.29 Industries and Commerce (IP & INF) Department. dated.29/11/2014) </asp:Label>
                                </td>
                            </tr>
                           <%-- <tr>
                                <td colspan="4"></td>
                            </tr>--%>
                            <tr>
                                <td colspan="4" style="height:50px">
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="15px"
                                        ForeColor="Black">1.0. Details of Industry</asp:Label>:</td>
                            </tr>
                            <tr>
                                <td colspan="2">1.1. Name of the Enterprise:</td>
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
                                <td colspan="2">1.3. TIN No. of the Enterprise/ Industry/ Proprietor/ Managing Partner/ Managing Director</td>
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
                            <tr style="height:50px">
                                <td align="center" colspan="4" style="text-align: left;">
                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="15px"
                                        ForeColor="Black">2.0. Address of the Enterprise :</asp:Label>
                                </td>
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
                           <%-- <tr>
                                <td colspan="4"></td>
                            </tr>--%>
                            <tr>
                                <td align="center" colspan="4" style="text-align: left;height:50px">
                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="15px"
                                        ForeColor="Black">2.2 Office Location</asp:Label>
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
                           <%-- <tr>
                                <td colspan="4"></td>
                            </tr>--%>
                            <tr>
                                <td align="center" colspan="4" style="text-align: left;height:50px">
                                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="15px"
                                        ForeColor="Black">3.0 Status</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">3.1 Category </td>
                                <td colspan="2">
                                    <span>
                                        <asp:Label ID="rblCaste" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">3.2  Constitution of the Organisation  </td>
                                <td colspan="2">
                                    <span>
                                        <asp:Label ID="ddltypeofOrg" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">3.3 Status of the Industry :</td>
                                <td colspan="2">
                                    <asp:Label ID="ddlindustryStatus" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>

                                <td colspan="2" style="padding: 5px; margin: 5px; text-align: left;">3.4 Whether the unit is located in Industrial Area declared by the Governement
                                </td>

                                <td colspan="2" style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                    <asp:Label ID="txtUnitLocatedinIndustArea" runat="server"></asp:Label>
                                </td>

                            </tr>
                            <tr>

                                <td colspan="2" style="padding: 5px; margin: 5px; text-align: left;">3.5Justification for the location of the Industry, if it is located outside IA declared by the Government
                                </td>

                                <td colspan="2" style="padding: 5px; margin: 5px; text-align: left;">
                                    <asp:Label ID="txtJustLocation" runat="server"></asp:Label>
                                </td>

                            </tr>
                            <tr>
                                <td colspan="2">3.6 Date of Commencement of Production Expected
                                    <br />
                                    date of Commencement of Production :</td>
                                <td colspan="2">
                                    <span>
                                        <asp:Label ID="txtDateofCommencement" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">3.7 EM Part - II/IEM/IL No.<br />
                                    (copy to be enclosed)</td>
                                <td colspan="2">
                                    <span>
                                        <asp:Label ID="lblEMPartNo" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">Date:<br />
                                </td>
                                <td colspan="2">
                                    <span>
                                        <asp:Label ID="Label8" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4"></td>
                            </tr>
                            <tr>
                                <td colspan="4"
                                    style="font-size: large; text-align: left; background-color: #0066FF; color: #FFFFFF; font-weight: bold;">4 FIXED CAPITAL INVESTMENT(in Rs.)</td>
                            </tr>
                            <tr id="tr1" runat="server" visible="false">
                                <td colspan="9">
                                    <table bgcolor="White" width="1000" border="2px" style="font-family: Verdana; font-size: small;">
                                        <tr>
                                            <td style="text-align: left">Nature of Assets</td>
                                            <td style="text-align: center"><span>New /Existing Enterprise</span> </td>
                                            <td style="text-align: center"><span>Expansion/ Diversification Project </span></td>
                                            <td><span>% of increase under Expansion/ Diversification Project </span></td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">(1)</td>
                                            <td style="text-align: center">(2)</td>
                                            <td style="text-align: center">(3)</td>
                                            <td><span>(4) </span></td>
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
                                            <td>
                                                <asp:Label ID="Label17" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label18" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="trexpansion1" runat="server" visible="true">
                                <td colspan="4" style="font-size: small; text-align: left; font-weight: bold;">
                                    <asp:Label ID="lblIndustryStatus2" runat="server" Text=" New Enterprise/Industry"></asp:Label>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4"
                                    style="font-size: small; text-align: left; font-weight: bold;">5.0&nbsp; LINE OF ACTIVITY</td>
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
                            <tr id="trexpansion" runat="server" visible="false">
                                <td colspan="9">
                                    <table style="width: 100%; font-weight: bold;">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" valign="top" colspan="9"></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" valign="top" colspan="9">
                                                <asp:Label ID="lblexpan1" runat="server"></asp:Label>
                                                &nbsp; PROJECT(In Rs.)<font color="red">*</font>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin white; background: #013161; color: white" align="center"></td>
                                            <td align="center" style="border: solid thin white; background: #013161; color: white" class="auto-style6">Line Of Activity</td>
                                            <td align="center" style="border: solid thin white; background: #013161; color: white" class="auto-style7">Installed Capacity</td>
                                            <td align="center" style="border: solid thin white; background: #013161; color: white">% of increase under
                                                        <br />
                                                <asp:Label ID="lblexpan2" runat="server"></asp:Label></td>
                                            <%--Expansion--%>
                                        </tr>
                                        <tr>
                                            <td align="center" style="border: solid thin black; background: white; color: black">Existing Enterprise</td>
                                            <td align="center" style="border: solid thin black" class="auto-style6">
                                                <asp:Label ID="txteeploa" runat="server"></asp:Label>
                                            </td>
                                            <td align="center" style="border: solid thin black" class="auto-style7">
                                                <%--<asp:Label ID="txteepinscap" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="DecimalOnly()" TabIndex="1" ValidationGroup="group"></asp:Label>--%>
                                                <table style="font-weight: bold; width: 70%;">
                                                    <tr>
                                                        <td style="width: 150px">Quantity</td>
                                                        <td style="width: 150px">Unit</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="text-align: center; width: 150px">
                                                            <asp:Label ID="txteepinscap" runat="server"></asp:Label></td>
                                                        <td align="center" style="text-align: center; width: 150px">
                                                            <asp:Label ID="ddleepinscap" runat="server">
                                                              
                                                            </asp:Label>

                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td align="center" style="border: solid thin black">
                                                <asp:Label ID="txteeppercentage" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="border: solid thin black; background: white; color: black">
                                                <asp:Label ID="lblexpan3" runat="server"></asp:Label>
                                                <br />
                                                Project</td>
                                            <td align="center" style="border: solid thin black" class="auto-style6">
                                                <asp:Label ID="txtedploa" runat="server"></asp:Label>
                                            </td>
                                            <td align="center" style="border: solid thin black" class="auto-style7">
                                                <table style="width: 70%; font-weight: bold;">
                                                    <tr>
                                                        <td style="width: 150px">Quantity</td>
                                                        <td style="width: 150px">Unit</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="text-align: center; width: 150px">
                                                            <asp:Label ID="txtedpinscap" runat="server"></asp:Label></td>
                                                        <td align="center" style="text-align: center; width: 150px">
                                                            <asp:Label ID="ddledpinscap" runat="server">                                                                
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td align="center" style="border: solid thin black">
                                                <asp:Label ID="txtedppercentage" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="9">
                                    <table style="width: 100%; ">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold; height: 50px" align="center" colspan="5">Employment
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin white; background: #013161; color: white; border: solid thin black" align="center"></td>
                                            <td style="border: solid thin white; background: #013161; color: white; border: solid thin black" align="center"></td>
                                            <td style="border: solid thin white; background: #013161; color: white; border: solid thin black" align="center">Male(Nos)
                                            </td>
                                            <td style="border: solid thin white; background: #013161; color: white; border: solid thin black" align="center">Female(Nos)
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black">1
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black">Management & Staff 
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black">
                                                <asp:Label ID="txtstaffMale" runat="server" class="form-control txtbox" TabIndex="80"
                                                    Width="180px" onkeypress="NumberOnly()"></asp:Label>

                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black">
                                                <asp:Label ID="txtfemale" runat="server"></asp:Label>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black">2
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black">Supervisory 
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black">
                                                <asp:Label ID="txtsupermalecount" runat="server" class="form-control txtbox" onkeypress="NumberOnly()" Width="180px" TabIndex="82"></asp:Label>

                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black">
                                                <asp:Label ID="txtsuperfemalecount" runat="server"></asp:Label>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black">3
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black">Skilled workers
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black">
                                                <asp:Label ID="txtSkilledWorkersMale" runat="server"></asp:Label>

                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black">
                                                <asp:Label ID="txtSkilledWorkersFemale" runat="server"></asp:Label>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black">4
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black">Semi-skilled workers
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black">
                                                <asp:Label ID="txtSemiSkilledWorkersMale" runat="server"></asp:Label>

                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black">
                                                <asp:Label ID="txtSemiSkilledWorkersFemale" runat="server"></asp:Label>

                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>

                        <%--</table>--%>
                    </div>
                </div>
                <div align="center" id="divIIDF" runat="server" visible="false">
                    <table bgcolor="White" width="1000" border="2px" style="font-family: Verdana; font-size: small;">
                        <tr>
                            <td align="center" colspan="4"
                                style="text-align: left; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                <asp:Label ID="Label7" runat="server">IIDFund</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; text-align: left" colspan="4">1. IIDF Fund</td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">7.   Source of Finance</td>
                            <td>
                                <asp:Label ID="txtFinanceSource" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: left;">8.   Description of the infrastructure facilities required and its objectives
                            </td>
                            <td>
                                <asp:Label ID="txtReqdInfraFacilities" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>

                            <td style="text-align: left;">9.How the proposed infrastructure is critical to the Industrial Enterprise
                            </td>
                            <td>
                                <asp:Label ID="txtProposedInfraCritical" runat="server"></asp:Label>
                            </td>
                            <td>&nbsp;<span>10. Estimates of Infrastructure facilities and name of  the Chartered Engineer/Agency who prepared the Estimates </span></td>
                            <td>
                                <asp:Label ID="txtEstimatesInfra" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">11   Duration of the project
                            </td>
                            <td>
                                <asp:Label ID="txtProjDuration" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: left;">12.  <span>Copy of the Project & its approval report </span>
                            </td>
                            <td>
                                <asp:Label ID="Label9" runat="server"></asp:Label>
                            </td>

                        </tr>
                        <tr>
                            <td style="text-align: left;">13. Measures proposed to maintain the infrastructure created & its maintenance cost per annum</td>
                            <td>
                                <asp:Label ID="txtMaintanCostAnnum" runat="server"></asp:Label>
                            </td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="4"></td>
                        </tr>
                        <tr>
                            <td colspan="4"></td>
                        </tr>
                    </table>
                    <br />
                    <input id="btnPrint" onclick="window.print()" style="border-right: thin solid; border-top: thin solid; width: 80px; border-left: thin solid; border-bottom: thin solid"
                        type="button" value="Print" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
