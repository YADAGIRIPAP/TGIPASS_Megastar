<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AnnexCleanerProduction.aspx.cs" Inherits="UI_TSiPASS_IncentivesAnnexures_AnnexCleanerProduction" %>

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
                <div align="center" id="divCommonAppli" runat="server" visible="false">
                    <div align="center">
                        <table bgcolor="White" width="800" border="2" style="font-family: Verdana; font-size: small; text-align: left">
                            
                          
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
                                <td style="width: 200px">
                                    <span>
                                        <asp:Label ID="ddldistrictunit" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>Survey No
                                </td>
                                <td style="width: 200px">
                                    <span>
                                        <asp:Label ID="txtunitaddhno" runat="server"></asp:Label>
                                    </span>

                                </td>
                            </tr>
                            <tr>
                                <td>Mandal</td>
                                <td style="width: 200px">
                                    <span>
                                        <asp:Label ID="ddlUnitMandal" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>Street</td>
                                <td style="width: 200px">
                                    <span>
                                        <asp:Label ID="txtstreetunit" runat="server"></asp:Label>
                                    </span>

                                </td>
                            </tr>
                            <tr>
                                <td>Village</td>
                                <td style="width: 200px">
                                    <span>
                                        <asp:Label ID="ddlVillageunit" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>Mobile Number
                                </td>
                                <td style="width: 200px">
                                    <span>
                                        <asp:Label ID="txtunitmobileno" runat="server"></asp:Label>
                                    </span>

                                </td>
                            </tr>
                            <tr>
                                <td>Email Id</td>
                                <td style="width: 200px">
                                    <span>
                                        <asp:Label ID="txtunitemailid" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>&nbsp;</td>
                                <td style="width: 200px">&nbsp;</td>
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
                                <td style="width: 200px">
                                    <span>
                                        <asp:Label ID="ddldistrictoffc" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>Survey No
                                </td>
                                <td style="width: 200px">
                                    <span>
                                        <asp:Label ID="txtoffaddhnno" runat="server"></asp:Label>
                                    </span>

                                </td>
                            </tr>
                            <tr>
                                <td>Mandal</td>
                                <td style="width: 200px">
                                    <span>
                                        <asp:Label ID="ddloffcmandal" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>Street
                                </td>
                                <td style="width: 200px">
                                    <span>
                                        <asp:Label ID="txtstreetoffice" runat="server"></asp:Label>
                                    </span>

                                </td>
                            </tr>
                            <tr>
                                <td>Village</td>
                                <td style="width: 200px">
                                    <span>
                                        <asp:Label ID="ddlvilloffc" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>Mobile Number
                                </td>
                                <td style="width: 200px">
                                    <span>
                                        <asp:Label ID="txtOffcMobileNO" runat="server"></asp:Label>
                                    </span>

                                </td>
                            </tr>
                            <tr>
                                <td>Email Id</td>
                                <td style="width: 200px">
                                    <span>
                                        <asp:Label ID="txtOffcEmail" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td></td>
                                <td style="width: 200px">
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
                                    (Date of Commencement of Production is the<br />
                                    date of First Sale Bill/Invoice)</td>
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
                                <td colspan="4"
                                    style="font-size: medium; text-align: left; font-weight: bold;">5 FIXED CAPITAL INVESTMENT(in Rs.)</td>
                            </tr>
                            <tr id="tr4" runat="server" visible="true">
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
                            <tr>
                                <td colspan="4"
                                    style="font-size: small; text-align: left; font-weight: bold;">6.&nbsp; LINE OF ACTIVITY</td>
                            </tr>
                            <tr id="trexpansion1" runat="server" visible="true">
                                <td colspan="4" style="font-size: small; text-align: left; font-weight: bold;">
                                    <asp:Label ID="lblIndustryStatus2" runat="server" Text=" New Enterprise/Industry"></asp:Label>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:GridView ID="gvLOA" runat="server" AutoGenerateColumns="False"
                                        Font-Names="Verdana" Font-Size="12px" SkinID="gridviewSkin" Width="800px">
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
                                    <table  bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" valign="top" colspan="9">
                                                <asp:Label ID="lblexpan1" runat="server"></asp:Label>
                                                &nbsp; Project(in Rs.)
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center"></td>
                                            <td style="text-align: center">Line Of Activity</td>
                                            <td style="text-align: center">Installed Capacity</td>
                                            <td style="text-align: center">% of increase under
                                                        <br />
                                                <asp:Label ID="lblexpan2" runat="server"></asp:Label></td>
                                            <%--Expansion--%>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">Existing Enterprise</td>
                                            <td style="text-align: left">
                                                <asp:Label ID="txteeploa" runat="server"></asp:Label>
                                            </td>
                                            <td style="text-align: center">
                                                <%--<asp:Label ID="txteepinscap" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="DecimalOnly()" TabIndex="1" ValidationGroup="group"></asp:Label>--%>
                                                <table  bgcolor="White" border="2px" style="font-family: Verdana; font-size: small;">
                                                    <tr>
                                                        <td style="width: 150px">Quantity</td>
                                                        <td style="width: 150px">Unit</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="text-align: left; width: 150px">
                                                            <asp:Label ID="txteepinscap" runat="server"></asp:Label></td>
                                                        <td align="center" style="text-align: left; width: 150px">
                                                            <asp:Label ID="ddleepinscap" runat="server">
                                                              
                                                            </asp:Label>

                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="txteeppercentage" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblexpan3" runat="server"></asp:Label>
                                                <br />
                                                Project</td>
                                            <td style="text-align: left">
                                                <asp:Label ID="txtedploa" runat="server"></asp:Label>
                                            </td>
                                            <td style="text-align: center">
                                                <table  bgcolor="White" border="2px" style="font-family: Verdana; font-size: small;">
                                                    <tr>
                                                        <td style="width: 150px">Quantity</td>
                                                        <td style="width: 150px">Unit</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="text-align: left; width: 150px">
                                                            <asp:Label ID="txtedpinscap" runat="server"></asp:Label></td>
                                                        <td align="center" style="text-align: left; width: 150px">
                                                            <asp:Label ID="ddledpinscap" runat="server">                                                                
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="txtedppercentage" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                        </table>
                         <table id="divCleanerProduction" runat="server" visible="false" bgcolor="White" width="800" border="2" style="font-family: Verdana; font-size: small;">
                        <tr style="height:50px">
                            <td align="center" colspan="4" style="text-align: left; font-size: medium; font-weight: bold;">
                                <asp:Label ID="Label23" runat="server" Font-Bold="True" Font-Size="14px">Reimbursement on equipment purchased for cleaner production measures.</asp:Label>
                            </td>
                        </tr>
                             <%-- <tr>
                            <td align="center" colspan="4" style="text-align: left; font-size: medium; font-weight: bold;"></td></tr>--%>
                        <tr>
                            <td style="font-weight: bold; text-align: left">7. Details of equipment purchased for the purpose</td>
                        </tr>
                        <tr>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:GridView ID="gvCertificate" runat="server" AutoGenerateColumns="False"
                                    Font-Names="Verdana" Font-Size="12px" SkinID="gridviewSkin" Width="800px" CellPadding="1" CellSpacing="1">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sl No.">
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Nameoftheequipment" HeaderText="Name of the equipment" />
                                        <asp:BoundField DataField="Nameaddressofsupplier" HeaderText="Name & address of supplier" />
                                        <asp:BoundField DataField="BillNo" HeaderText="Bill No" />
                                        <asp:BoundField DataField="BillDate" HeaderText="Bill Date" />
                                        <asp:BoundField DataField="Costoftheequipment" HeaderText="Cost of the equipment in Rs." />
                                        <asp:BoundField DataField="VATCST" HeaderText="VAT/CST in Rs." />
                                        <asp:BoundField DataField="ExciseDuty" HeaderText="Excise Duty in Rs." />
                                        <asp:BoundField DataField="FreightCharge" HeaderText="Freight Charge in Rs." />
                                        <asp:BoundField DataField="Othercharges" HeaderText="Other charges in Rs." />
                                        <asp:BoundField DataField="TotalinRs" HeaderText="Total in Rs." />
                                        <%--<asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblid" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">8. Amount of subsidy claimed in Rs.:  Rs.(25% limited to Rs. 5.00 Lakhs)                     
                                <asp:Label ID="txtsubsidyclaimed" runat="server" Style="font-weight: 700"></asp:Label></td>
                        </tr>
                    </table>
                        <%--</table>--%>
                    </div>

                </div>
                <div align="center" >
                   
                    <br />
                    <input id="btnPrint" onclick="window.print()" style="border-right: thin solid; border-top: thin solid; width: 80px; border-left: thin solid; border-bottom: thin solid"
                        type="button" value="Print" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
