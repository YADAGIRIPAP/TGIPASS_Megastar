<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AnnexSkillIUpg.aspx.cs" Inherits="UI_TSiPASS_IncentivesAnnexures_AnnexSkillIUpg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 22px;
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
                    
                </div>
                <br />

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

                <div align="center" id="divCommonAppli" runat="server" visible="false">
                    <div align="center">
                        <table bgcolor="White" width="800" border="2px"
                            style="font-family: Verdana; font-size: small; text-align: left">
                          
                            <tr>
                                <td colspan="4"></td>
                            </tr>
                            <tr>
                                <td colspan="4">
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
                                <td colspan="2">3.1 Category </td>
                                <td colspan="2">
                                    <span>
                                        <asp:Label ID="ddlCategory" runat="server"></asp:Label>
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
                                <td colspan="2">3.3 Date of Commencement of Production
                                    <br />
                                    <span>(Date of Commencement of Production is
                                        <br />
                                        the date of First Sale Bill/Invoice) </span></td>
                                <td colspan="2">
                                    <span>
                                        <asp:Label ID="txtDateofCommencement" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">3.4 EM Part - II/IEM/IL No.<br />
                                </td>
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
                                <td colspan="2">4 Status of the Industry :</td>
                                <td colspan="2">
                                    <asp:Label ID="ddlindustryStatus" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4"></td>
                            </tr>
                            <tr>
                                <td colspan="4"
                                    style="font-size: medium; text-align: left; font-weight: bold;">5 Fixed Capital Investment(in Rs.)</td>
                            </tr>
                            <tr id="tr4" runat="server" visible="true">
                                <td colspan="9">
                                    <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                        <tr>
                                            <td style="text-align: center">Nature of Assets</td>
                                            <td style="text-align: center">New/Existing Enterprise</td>
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
                            <tr id="trexpansion" runat="server" visible="true">
                                <td colspan="9">
                                    <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">

                                        <tr id="tr1" runat="server" visible="true">
                                            <td colspan="9">6. Line of activity.
                                                <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
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
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div align="center" id="divSkillupgradation" runat="server" visible="false">
                    <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                        <tr>
                            <td align="center" colspan="4"
                                style="text-align: left; font-size: medium; font-weight: bold;">
                                <asp:Label ID="Label41" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="White">Reimbursement of costs involved in Skill upgradation and training</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left;">7 <span>The industry/Enterprise are availed the training infrastructure of any Government agency like DRDA etc. ? </span></td>
                            <td colspan="2">
                                <asp:Label ID="Label7" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left;">8 Name of the skill development programme</td>
                            <td colspan="2">
                                <asp:Label ID="txtNameoftheskilldevelopmentprogramme" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left;">9  Name of the institute given the training:</td>
                            <td colspan="2" style="text-align: left;">
                                <asp:Label ID="txtagencyName1" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left;">10 &nbsp;&nbsp; Number of skilled employement trained by the industry                                    
                            </td>
                            <td colspan="2" style="text-align: left;">
                                <asp:Label ID="txtNumberskilledemployees" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left;">11 Expenditure incurred for training programme</td>
                            <td colspan="2" style="text-align: left;">
                                <asp:Label ID="txtExpenditureincurredfortrainingprogramme" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left;">12 &nbsp;&nbsp; Amount claimed in Rs.
                            </td>
                            <td colspan="2" style="text-align: left;">
                                <asp:Label ID="txtAmountclaimedinRs" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4"></td>
                        </tr>
                    </table>
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
