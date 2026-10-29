<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="frmInspRepDrft.aspx.cs" Inherits="UI_TSiPASS_frmInspRepDrft" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="align-content: center">
            <div style="align-content: center">
                <table>
                    <tr>
                        <td style="width: 60%;" border="1px">
                            <div style="align-content: center">
                                <table bgcolor="White" width="60%" border="1px" style="font-size: xx-small; text-align: center" align="center">
                                    <tr>
                                        <td>
                                            <div align="center">
                                                <br />
                                                <center>
                        <img src="telanganalogo.png" width="75px" height="75px" />
                    </center>
                                                <br />
                                               <asp:Label ID="lblheadTPRIDE" Font-Size="X-Large" Font-Bold="true" runat="server"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center; font-size: 15px">
                                            <b>
                                                
                                                <br />
                                                <asp:Label ID="lblheadTIDEA"  Font-Bold="true" runat="server">Investment Subsidy</asp:Label></b>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="align-content: center">
                                <div align="center" id="divCommonAppli" runat="server">
                                    <div align="center">
                                        <table bgcolor="White" width="60%" border="2px" style="font-size: xx-small; text-align: center">
                                            <tr>
                                                <td>
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td colspan="8"></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 40px; text-align: center"><b>1.0</b></td>
                                                            <td colspan="7" style="height: 40px; text-align: left">
                                                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="15px" ForeColor="Black">Details of Industry</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="8" style="width: 100%">
                                                                <table style="width: 100%">
                                                                    <tr>
                                                                        <td style="height: 40px; text-align: center">1.1</td>
                                                                        <td style="height: 25px;">Udyog Aadhar/ IEM</td>
                                                                        <td>:</td>
                                                                        <td style="height: 25px;" colspan="4">
                                                                            <b>
                                                                                <asp:Label ID="lblUID" runat="server"></asp:Label>
                                                                            </b>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 40px; text-align: center">1.2</td>
                                                                        <td style="height: 25px;">Name of the Enterprise:</td>
                                                                        <td>:</td>
                                                                        <td style="height: 25px;">
                                                                            <b>
                                                                                <asp:Label ID="txtUnitname" runat="server"></asp:Label>
                                                                            </b>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 40px; text-align: center; vertical-align: top">1.3</td>
                                                                        <td style="height: 25px;">Name of the Proprietor/Managing Partner / Managing Director</td>
                                                                        <td>:</td>
                                                                        <td style="height: 25px;">
                                                                            <b>
                                                                                <asp:Label ID="txtApplicantName" runat="server"></asp:Label>
                                                                            </b>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 40px; text-align: center; vertical-align: top">1.4</td>
                                                                        <td style="height: 25px;">TIN No. of the Enterprise/Industry/Proprietor/Managing Partner/Managing Director</td>
                                                                        <td>:</td>
                                                                        <td style="height: 25px;">
                                                                            <b>
                                                                                <asp:Label ID="txtTinNumber" runat="server"></asp:Label>
                                                                            </b>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 40px; text-align: center; vertical-align: top">1.5</td>
                                                                        <td style="height: 25px;">PAN No. of the Proprietor / Managing Partner /  Managing Director</td>
                                                                        <td>:</td>
                                                                        <td style="height: 25px;">
                                                                            <b>
                                                                                <asp:Label ID="txtPanNumber" runat="server"></asp:Label>
                                                                            </b>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 40px; text-align: center"><b>2.0</b></td>
                                                            <td align="center" colspan="7" style="text-align: left; height: 40px;">
                                                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="15px" ForeColor="Black">Factory Location</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td>District</td>
                                                            <td>:</td>
                                                            <td>
                                                                <b>
                                                                    <asp:Label ID="ddldistrictoffc" runat="server"></asp:Label>
                                                                </b>
                                                            </td>
                                                            <td></td>
                                                            <td>Survey No
                                                            </td>
                                                            <td>:</td>
                                                            <td>
                                                                <b>
                                                                    <asp:Label ID="txtoffaddhnno" runat="server"></asp:Label>
                                                                </b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td>Mandal</td>
                                                            <td>:</td>
                                                            <td>
                                                                <b>
                                                                    <asp:Label ID="ddloffcmandal" runat="server"></asp:Label>
                                                                </b>
                                                            </td>
                                                            <td></td>
                                                            <td>Street
                                                            </td>
                                                            <td>:</td>
                                                            <td>
                                                                <b>
                                                                    <asp:Label ID="txtstreetoffice" runat="server"></asp:Label>
                                                                </b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td>Village</td>
                                                            <td>:</td>
                                                            <td>
                                                                <b>
                                                                    <asp:Label ID="ddlvilloffc" runat="server"></asp:Label>
                                                                </b>
                                                            </td>
                                                            <td></td>
                                                            <td style="width: 150px">Mobile Number
                                                            </td>
                                                            <td>:</td>
                                                            <td>
                                                                <b>
                                                                    <asp:Label ID="txtOffcMobileNO" runat="server"></asp:Label>
                                                                </b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td>Email Id</td>
                                                            <td>:</td>
                                                            <td>
                                                                <b>
                                                                    <asp:Label ID="txtOffcEmail" runat="server"></asp:Label>
                                                                </b>
                                                            </td>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="8"></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 100%" colspan="8">
                                                                <table style="width: 100%">
                                                                    <tr>
                                                                        <td style="text-align: center; height: 40px;"><b>3.0</b></td>
                                                                        <td align="center" colspan="7" style="text-align: left; height: 30px;">
                                                                            <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="15px"
                                                                                ForeColor="Black">Status</asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 40px; text-align: center">3.1</td>
                                                                        <td style="height: 25px;">Category</td>
                                                                        <td>:</td>
                                                                        <td style="height: 25px;"><b>
                                                                            <asp:Label ID="ddlCategory" runat="server"></asp:Label>
                                                                        </b></td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 40px; text-align: center">3.2</td>
                                                                        <td style="height: 25px;">Constitution of the Organisation</td>
                                                                        <td>:</td>
                                                                        <td style="height: 25px;">
                                                                            <b>
                                                                                <asp:Label ID="ddltypeofOrg" runat="server"></asp:Label>
                                                                            </b>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 40px; text-align: center">3.3</td>
                                                                        <td style="height: 25px;">Industry Status </td>
                                                                        <td>:</td>
                                                                        <td style="height: 25px;">
                                                                            <b>
                                                                                <asp:Label ID="ddlindustryStatus" runat="server"></asp:Label></b>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 40px; text-align: center">3.4</td>
                                                                        <td style="height: 25px;">Date of Commencement of Production
                                        <br />
                                                                            (Date of Commencement of Production is the date of First Sale Bill/Invoice) 
                                                                        </td>
                                                                        <td>:</td>
                                                                        <td style="height: 25px;">
                                                                            <b>
                                                                                <asp:Label ID="txtDateofCommencement" runat="server"></asp:Label>
                                                                            </b>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 40px; text-align: center">3.5</td>
                                                                        <td style="height: 25px;">EM Part - II/IEM/IL No.(copy to be enclosed)</td>
                                                                        <td>:</td>
                                                                        <td style="height: 25px;">
                                                                            <b>
                                                                                <asp:Label ID="lblEMPartNo" runat="server"></asp:Label>
                                                                            </b>
                                                                        </td>

                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td align="center" colspan="8" style="text-align: left; height: 50px;">
                                                                <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="Black">Inspection Details</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td style="height: 25px;">Name of Inspection Officer , Designation.</td>
                                                            <td>:</td>
                                                            <td style="height: 25px;">
                                                                <b>
                                                                    <asp:Label ID="lblInspectr" runat="server"></asp:Label>
                                                                </b>
                                                            </td>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td style="height: 25px;">Date of Inspection</td>
                                                            <td>:</td>
                                                            <td style="height: 25px;">
                                                                <b>
                                                                    <asp:Label ID="lblDateofIns" runat="server"></asp:Label>
                                                                </b>
                                                            </td>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td style="height: 25px;">Name of Person at Industry, while inspection</td>
                                                            <td>:</td>
                                                            <td style="height: 25px;">
                                                                <b>
                                                                    <asp:Label ID="lblPerson" runat="server"></asp:Label>
                                                                </b>
                                                            </td>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                        </tr>
                                                    </table>
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td style="font-size: medium; text-align: left; font-weight: bold; height: 50px">Project details</td>
                                                        </tr>
                                                        <tr>
                                                            <td><b>Expansion/Diversification Project (in Rs.)<br />
                                                            </b></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center" align="center">
                                                                <asp:GridView ID="gvLOA" runat="server" AutoGenerateColumns="False"
                                                                    Font-Names="Verdana" Font-Size="12px" SkinID="gridviewSkin" Width="80%">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Sl No.">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="column1" HeaderText="Line Of Activity" />
                                                                        <asp:BoundField DataField="column2" HeaderText="Installed Capacity" />
                                                                        <asp:BoundField DataField="column3" HeaderText="Unit" />
                                                                        <asp:BoundField DataField="column4" HeaderText="Value" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td style="height: 50px; text-align: left" colspan="4"><b>Dates of Application</b></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center; vertical-align: top">1.
                                                            </td>
                                                            <td style="text-align: left; vertical-align: top">Date of commencement of Production
                                                            </td>
                                                            <td style="text-align: center; vertical-align: top">:</td>
                                                            <td style="text-align: left; vertical-align: top">
                                                                <b>
                                                                    <asp:Label ID="txtDateofCommencementTxt" runat="server" class="form-control txtbox" Height="30px" TabIndex="1" ValidationGroup="group" Visible="false" Width="150px"></asp:Label>
                                                                    <asp:Label ID="lblDCP" runat="server"></asp:Label></b>

                                                            </td>
                                                            <td style="text-align: center; vertical-align: top"></td>
                                                            <td style="text-align: center; vertical-align: top">3.
                                                            </td>
                                                            <td style="text-align: left; vertical-align: top">Date of issue of Regd. Notice calling shortfall documents/information
                                                            </td>
                                                            <td style="text-align: center; vertical-align: top">:</td>
                                                            <td style="text-align: left; vertical-align: top">&nbsp;<b><asp:Label ID="txtDateShrtfall" runat="server" class="form-control txtbox" Height="30px"
                                                                TabIndex="1" ValidationGroup="group" Width="150px"></asp:Label></b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center; vertical-align: top">2.</td>
                                                            <td style="text-align: left; vertical-align: top">Date of receipt of claim application
                                                            </td>
                                                            <td style="text-align: left; vertical-align: top">:</td>
                                                            <td style="text-align: left; vertical-align: top">
                                                                <b>
                                                                    <asp:Label ID="txtRcptAppln" runat="server" class="form-control txtbox" TabIndex="1"
                                                                        Width="150px" ValidationGroup="group" Height="30px"></asp:Label></b>
                                                            </td>
                                                            <td style="text-align: center; vertical-align: top">&nbsp;</td>
                                                            <td style="text-align: center; vertical-align: top">4.
                                                            </td>
                                                            <td style="text-align: left; vertical-align: top">Date of receipt of shortfall documents/information
                                                            </td>
                                                            <td style="text-align: center; vertical-align: top">:
                                                            </td>
                                                            <td style="text-align: left; vertical-align: top">
                                                                <b>
                                                                    <asp:Label ID="txtDtShrtFallRcvd" runat="server" class="form-control txtbox" TabIndex="1"
                                                                        Width="150px" ValidationGroup="group" Height="30px"></asp:Label></b>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td colspan="8" style="height: 60px" align="left">(if, the Enterprise submitted the claim applications for sanction of 25% Land cost, the GM, DIC concerned should not consider the land value for computation of fixed capital investment)</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center">1.
                                                            </td>
                                                            <td style="text-align: left;">Land cost
                                                            </td>
                                                            <td style="padding: 3px; margin: 3px">:</td>
                                                            <td style="text-align: left;">
                                                                <b>
                                                                    <asp:Label ID="txtLndCst25Prcnt" runat="server" class="form-control txtbox" Height="30px" TabIndex="1" ValidationGroup="group" Width="150px"></asp:Label></b>
                                                            </td>

                                                            <td style="text-align: center;">5.
                                                            </td>
                                                            <td style="text-align: left;">Total
                                                            </td>
                                                            <td style="padding: 3px; margin: 3px">:</td>
                                                            <td style="text-align: left;">
                                                                <b>
                                                                    <asp:Label ID="txtTotal25Prcnt" runat="server" class="form-control txtbox" Height="30px" TabIndex="1" ValidationGroup="group" Width="150px"></asp:Label></b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center;">2.</td>
                                                            <td style="text-align: left;">Stamp Duty<br>
                                                                Regn. Fees
                                                            </td>
                                                            <td style="text-align: left;">:</td>
                                                            <td style="text-align: left;">
                                                                <b>
                                                                    <asp:Label ID="txtRegnFee25Prcnt" runat="server" class="form-control txtbox" Height="30px" TabIndex="1" ValidationGroup="group" Width="150px"></asp:Label></b>
                                                            </td>
                                                            <td style="text-align: center;">6.
                                                            </td>
                                                            <td style="text-align: left;">Approved Project cost
                                                            </td>
                                                            <td style="text-align: left;">:</td>
                                                            <td style="text-align: left;">
                                                                <b>
                                                                    <asp:Label ID="txtAprdPjCst25Prcnt" runat="server" class="form-control txtbox" Height="30px" TabIndex="1" ValidationGroup="group" Width="150px"></asp:Label></b>
                                                            </td>
                                                        </tr>


                                                        <tr>
                                                            <td style="text-align: center;">3.</td>
                                                            <td style="text-align: left;">Proportionate eligible value<br>
                                                                Regn. Fees

                                                            </td>
                                                            <td style="text-align: left;">:</td>
                                                            <td style="text-align: left;">
                                                                <b>
                                                                    <asp:Label ID="txtProprtn25Prcnt" runat="server" class="form-control txtbox" Height="30px"
                                                                        TabIndex="1" ValidationGroup="group" Width="150px"></asp:Label></b>

                                                            </td>
                                                            <td style="text-align: center;">7.</td>
                                                            <td style="text-align: left;">Computed Total

                                                            </td>
                                                            <td style="text-align: left;">:</td>
                                                            <td style="text-align: left;">
                                                                <b>
                                                                    <asp:Label ID="txtComputedcost" runat="server" class="form-control txtbox" Height="30px" TabIndex="1" ValidationGroup="group" Width="150px"></asp:Label></b>
                                                            </td>

                                                        </tr>

                                                        <tr>
                                                            <td style="text-align: center;">4.</td>
                                                            <td style="text-align: left;">Building and other civil works

                                                            </td>
                                                            <td style="text-align: left;">:</td>
                                                            <td style="text-align: left;">
                                                                <b>
                                                                    <asp:Label ID="txt25BldCvl" runat="server" class="form-control txtbox" Height="30px" TabIndex="1" ValidationGroup="group" Width="150px"></asp:Label></b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="border: solid thin white; color: black; text-align: left;"></td>
                                                        </tr>
                                                    </table>
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td><b>4.2</b></td>
                                                            <td colspan="7" style="height: 50px" align="left" class="fa-inverse"><b>Valuations</b></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center">1.
                                                            </td>
                                                            <td style="text-align: left;">Value of the items 8.2.2 to 8.2.10 of guideline
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="text-align: left;">
                                                                <b>
                                                                    <asp:Label ID="txtTotVal1" runat="server" class="form-control txtbox" Height="30px" TabIndex="1" ValidationGroup="group" Width="150px"></asp:Label></b>
                                                            </td>
                                                            <td style="text-align: left;">4.
                                                            </td>
                                                            <td style="text-align: left;">Value 
                                                            </td>
                                                            <td style="text-align: left;">:
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <b>
                                                                    <asp:Label ID="txtTotVal4" runat="server" class="form-control txtbox" Height="30px" TabIndex="1" ValidationGroup="group" Width="150px"></asp:Label></b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center;">2.</td>
                                                            <td style="text-align: left;">Plinth area

                                                            </td>
                                                            <td style="text-align: center;">:</td>
                                                            <td style="text-align: left;">
                                                                <b>
                                                                    <asp:Label ID="txtTotVal2" runat="server" class="form-control txtbox" Height="30px" TabIndex="1" ValidationGroup="group" Width="150px"></asp:Label></b>
                                                            </td>
                                                            <td style="text-align: center;">5.
                                                            </td>
                                                            <td style="text-align: left;">Total value of 100 % Items 
                                                            </td>
                                                            <td style="text-align: center;">:
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <b>
                                                                    <asp:Label ID="txtTotVal10" runat="server" class="form-control txtbox" Height="30px" TabIndex="1" ValidationGroup="group" Width="150px"></asp:Label></b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center;">3.</td>
                                                            <td style="text-align: left;">Rate as per the TSSFC norms

                                                            </td>
                                                            <td style="text-align: center;">:</td>
                                                            <td style="text-align: left;">
                                                                <b>
                                                                    <asp:Label ID="txtTotVal3" runat="server" class="form-control txtbox" Height="30px"
                                                                        TabIndex="1" ValidationGroup="group" Width="150px"></asp:Label></b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="border: solid thin white; color: black; text-align: left;"></td>
                                                        </tr>
                                                    </table>
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td colspan="8" style="height: 40px" align="left" class="fa-inverse">Value of the items 8.2.11 to 8.2.17 and similar items of guidelines not to exceed 10% of the total value of the civil works. </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">1.
                                                            </td>
                                                            <td style="text-align: left;">Value of the items 8.2.2 to 8.2.10 of guideline
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <b>
                                                                    <asp:Label ID="txtValofItems" runat="server" class="form-control txtbox" Height="30px" TabIndex="1" ValidationGroup="group" Width="150px"></asp:Label></b>
                                                            </td>

                                                            <td style="text-align: center;">4.
                                                            </td>
                                                            <td style="text-align: left;">Value 
                                                            </td>
                                                            <td style="text-align: center;">:
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <b>
                                                                    <asp:Label ID="txtAprvPJVal" runat="server" class="form-control txtbox" Height="30px" TabIndex="1" ValidationGroup="group" Width="150px"></asp:Label></b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center;">2.</td>
                                                            <td style="text-align: left;">Plinth area

                                                            </td>
                                                            <td style="text-align: center;">:
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <b>
                                                                    <asp:Label ID="txtPlnthArea" runat="server" class="form-control txtbox" Height="30px" TabIndex="1" ValidationGroup="group" Width="150px"></asp:Label></b>
                                                            </td>
                                                            <td style="text-align: center;">5.
                                                            </td>
                                                            <td style="text-align: left;">Total Value 10% Items&nbsp; 
                                                            </td>
                                                            <td style="text-align: center;">:
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <b>
                                                                    <asp:Label ID="txtAppJTot" runat="server" class="form-control txtbox" Height="30px" TabIndex="1" ValidationGroup="group" Width="150px"></asp:Label></b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center;">3.</td>
                                                            <td style="text-align: left;">Rate as per the TSSFC norms
                                                            </td>
                                                            <td style="text-align: center;">:
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <b>
                                                                    <asp:Label ID="txtTSSFC" runat="server" class="form-control txtbox" Height="30px" TabIndex="1" ValidationGroup="group" Width="150px"></asp:Label></b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="border: solid thin white; color: black; text-align: left;"></td>
                                                        </tr>
                                                    </table>
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style42">Grand Total Value 100% + 10% Items
                                                            </td>
                                                            <td>:</td>
                                                            <td>
                                                                <b>
                                                                    <asp:Label ID="txtGrndTotVal" runat="server" class="form-control txtbox" Height="30px"
                                                                        TabIndex="1" ValidationGroup="group" Width="150px"></asp:Label></b>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td><b>4.3</b></td>
                                                            <td colspan="7" style="height: 50px" align="left" class="fa-inverse"><span><b>Valuation of Project</b></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">1.</td>
                                                            <td style="text-align: left;">As per approved project cost
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <b>
                                                                    <asp:Label ID="txtAsperApprvdCost" runat="server" class="form-control txtbox" Height="30px" TabIndex="1" ValidationGroup="group" Width="150px" Enabled="true"></asp:Label></b>
                                                            </td>
                                                            <td style="text-align: left;">3.
                                                            </td>
                                                            <td style="text-align: left;">Computed value by the GM 
                                                            </td>
                                                            <td style="text-align: left;">:
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <b>
                                                                    <asp:Label ID="txtComptdGm" runat="server" class="form-control txtbox" Height="30px" TabIndex="1" ValidationGroup="group" Width="150px" Enabled="true"></asp:Label></b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center;">2.</td>
                                                            <td style="text-align: left;">As per Civil Engineer Certificate 
                                                            </td>
                                                            <td style="text-align: center;">:
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <b>
                                                                    <asp:Label ID="txtAsperCivilEngr" runat="server" class="form-control txtbox" Height="30px" TabIndex="1" ValidationGroup="group" Width="150px" Enabled="true"></asp:Label></b>
                                                            </td>
                                                            <td style="text-align: center;">4.
                                                            </td>
                                                            <td style="text-align: left;">Computed cost
                                                            </td>
                                                            <td style="text-align: center;">:
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <b>
                                                                    <asp:Label ID="txtComputedCostApprPrj" runat="server" class="form-control txtbox" Height="30px" TabIndex="1" ValidationGroup="group" Width="150px"></asp:Label></b>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td><b>4.4</b></td>
                                                            <td colspan="7" style="height: 50px" align="left" class="fa-inverse"><span><b>Total Cost computed</b></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="border: solid thin white; color: black; text-align: left;"></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center">1.</td>
                                                            <td style="text-align: left;">Land (4.1.5)&nbsp; 
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: center">:
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <b>
                                                                    <asp:Label ID="txtTotCstCmptdLand" runat="server" class="form-control txtbox" Enabled="true" Height="30px" TabIndex="1" ValidationGroup="group" Width="100px"></asp:Label></b>
                                                            </td>
                                                            <td style="text-align: center;">3.
                                                            </td>
                                                            <td style="text-align: left;">Plant &amp; Machinery (4.3.2)
                                                            </td>
                                                            <td style="text-align: center;">:
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <b>
                                                                    <asp:Label ID="txtTotCstCmptdPlntMach" runat="server" class="form-control txtbox" Enabled="true" Height="30px" OnTextChanged="txtTotCstCmptdPlntMach_TextChanged" TabIndex="1" ValidationGroup="group" Width="100px"></asp:Label></b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center;">2.</td>
                                                            <td style="text-align: left;">Buildings (4.2.7) 

                                                            </td>
                                                            <td style="text-align: center;">:
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <b>
                                                                    <asp:Label ID="txtTotCstCmptdBldg" runat="server" class="form-control txtbox" Enabled="true" Height="30px" TabIndex="1" ValidationGroup="group" Width="100px"></asp:Label></b>
                                                            </td>
                                                            <td style="text-align: center;">4.
                                                            </td>
                                                            <td style="text-align: left;">Total 
                                                            </td>
                                                            <td style="text-align: center;">:
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <b>
                                                                    <asp:Label ID="txtTotCstCmptdTotal" runat="server" class="form-control txtbox" Enabled="true" Height="30px" TabIndex="1" ValidationGroup="group" Width="100px"></asp:Label></b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="color: black; text-align: left;"></td>
                                                        </tr>
                                                    </table>
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td><b>4.4.1</b></td>
                                                            <td colspan="7" style="height: 50px" align="left" class="fa-inverse"><span><b>Subsidy Recommendation</b></span> </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">1.</td>
                                                            <td style="text-align: left;"><span lang="EN-US">Investment Subsidy</span>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <b>
                                                                    <asp:Label ID="txtInvSubsidyVal" runat="server" class="form-control txtbox" Enabled="true" Height="30px" TabIndex="1" ValidationGroup="group" Width="100px" CssClass="auto-style41"></asp:Label></b>
                                                            </td>

                                                           

                                                             <td style="text-align: left;">3.
                                                            </td>
                                                            <td style="text-align: left;"><span lang="EN-US">An additional investment subsidy for Women entrepreneurs set up in Scheduled areas @10% </span>
                                                            </td>
                                                            <td style="text-align: left;">:
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <b>
                                                                    <asp:Label ID="txtAddnInvSbsdySc10Prcnt" runat="server" class="form-control txtbox" Enabled="true" Height="30px" TabIndex="1" ValidationGroup="group" Width="100px"></asp:Label></b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center;">2.</td>
                                                            <td style="text-align: justify; text-wrap: initial; color: black; text-align: left;"><span lang="EN-US">An Additional Investment Subsidy for Women entrepreneurs</span>

                                                            </td>
                                                            <td style="text-align: center;">:
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <b>
                                                                    <asp:Label ID="txtAddnInvSubsdyWmn" runat="server" class="form-control txtbox" Enabled="true" Height="30px" TabIndex="1" ValidationGroup="group" Width="100px"></asp:Label></b>
                                                            </td>
                                                            <td style="text-align: center;">
                                                                4</td>
                                                            <td style="text-align: justify; text-wrap: initial; color: black; text-align: left;">
                                                                Total
                                                            </td>
                                                            <td style="text-align: center;">:
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <b>
                                                                    <asp:Label ID="txtInvSubsdySCST" runat="server" class="form-control txtbox" Enabled="true" Height="30px" Visible="false" TabIndex="1" ValidationGroup="group" Width="100px"></asp:Label>
                                                                    <asp:Label ID="txtPower" runat="server" Visible="false" class="form-control txtbox" Enabled="true" Height="30px" TabIndex="1" ValidationGroup="group" Width="100px"></asp:Label></b>
                                                                <asp:Label ID="lbltotalinvestsubsidy" runat="server" class="form-control txtbox" Enabled="true" Height="30px" TabIndex="1" ValidationGroup="group" Width="100px"></asp:Label></b>
                                                            </td>
                                                        </tr>
                                                        <%--<tr>
                                                <td style="text-align: left;">4
                                        </td>
                                        <td style="text-align: left;">Total <span lang="EN-US">&nbsp;</span>
                                        </td>
                                        <td style="text-align: left;">:
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:Label ID="txtTotalInv" runat="server" class="form-control txtbox" Enabled="true" Height="30px"  TabIndex="1" ValidationGroup="group" Width="100px"></asp:Label>
                                        </td>
                                            </tr>--%>
                                                        <tr>
                                                            <td style="border: solid thin white; color: black; text-align: left;"></td>
                                                        </tr>
                                                    </table>
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td class="auto-style1"><b>4.1.1</b></td>
                                                            <td style="font-size: 15px; text-align: left; font-weight: bold; height: 50px">Land: Capital cost computed &amp; recommended.</td>
                                                        </tr>
                                                    </table>
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td align="center">1.
                                                            </td>
                                                            <td style="text-align: left;">Extent in Sq.Mtrs
                                                            </td>

                                                            <td style="text-align: left;">
                                                                <b>
                                                                    <asp:Label ID="txtExtent" runat="server" class="form-control txtbox" TabIndex="68" Width="180px"></asp:Label></b>
                                                            </td>

                                                            <td style="text-align: left;">3.
                                                            </td>
                                                            <td style="text-align: left;">Built up area in Sq.Mtrs 
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <b>
                                                                    <asp:Label ID="txtBuiltupAra" runat="server" class="txtalignright" Height="28px" TabIndex="69" ValidationGroup="group" onkeypress="DecimalOnly()" Width="180px"></asp:Label></b>

                                                                &nbsp;</td>

                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center;">2.</td>
                                                            <td style="text-align: left;">5 times built up area in Sq.Mtrs
                                                            </td>
                                                            <td style="text-align: left;">&nbsp;<b><asp:Label ID="txt5TtimesBltup" runat="server" class="form-control txtbox" TabIndex="70"
                                                                Width="180px" onkeypress="DecimalOnly()" ValidationGroup="group"></asp:Label></b>
                                                            </td>
                                                            <td style="text-align: center;">4.</td>
                                                            <td style="text-align: left;">&nbsp;Extent eligible in Sq.Mtrs
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <b>
                                                                    <asp:Label ID="txtExtentElgble" runat="server" class="form-control txtbox" TabIndex="71"
                                                                        Width="180px" ValidationGroup="group"></asp:Label></b>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td></td>
                                                        </tr>
                                                        <tr id="trsubidy1" runat="server" visible="false">
                                                            <%--<td colspan="4" style="padding: 5px; margin: 5px; text-align: left;"><strong>9.0 Total Amount of subsidy already availed:</strong>
                                                </td>--%>
                                                        </tr>
                                                        <%--<tr>
                                                            <td colspan="4"></td>
                                                        </tr>--%>
                                                        <tr>
                                                            <td>
                                                                <table style="width: 100%">
                                                                    <tr>
                                                                        <td style="width:300px;"><b>Inspecting Officer Remarks: </b></td>
                                                                        <td colspan="3" style="text-align:left">
                                                                            <asp:Label ID="lblIPORemarks" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <br />
                                                                <center>
                                                    <input id="btnPrint" onclick="window.print()" style="border-right: thin solid; border-top: thin solid; width: 80px; border-left: thin solid; border-bottom: thin solid"
                                                        type="button" value="Print" />
                                                    </center>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" style="height: 10px"></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>


