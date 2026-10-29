<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AnnexQualityCertification.aspx.cs" Inherits="UI_TSiPASS_IncentivesAnnexures_AnnexQualityCertification" %>

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
                                    <td colspan="2">1.3 EM Part – II/IEM/IL/EOU No.</td>
                                    <td colspan="2">
                                        <span>
                                            <asp:Label ID="lblEMPartNo" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">1.4 Item(s) of manufacture/processing as indicated in the
                                        EM Part – II/IEM/IL/EOU registration</td>
                                    <td colspan="2">
                                        <asp:Label ID="lblEMPartNo1" runat="server"></asp:Label></td>
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
                                            ForeColor="Black">2.2 Office location</asp:Label>
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
                                    <td colspan="4" style="text-align: left;  font-size: medium; font-weight: bold;">
                                        <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Size="15px" ForeColor="black">Reimbursement of Quality Certification Charges</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="font-size: medium">
                                        <asp:Label ID="Label21" runat="server" Font-Bold="True" Font-Size="13px" ForeColor="Black">Details of ISO 9000 / ISO 14001 / HACCP Certificate</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>1 Name of certifying agency</td>
                                    <td>
                                        <asp:Label ID="txtagencyName" runat="server"></asp:Label></td>
                                    <td>2 Certificate Number</td>
                                    <td>
                                        <asp:Label ID="txtCertificatNumber" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>3  Date of Issue</td>
                                    <td>
                                        <asp:Label ID="txtDateofIssue" runat="server"></asp:Label>
                                    </td>
                                    <td valign="top">4  Period of Validity</td>
                                    <td>
                                        <asp:Label ID="txtPeriodofValidity" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><strong>Address of certifying agency</strong></td>
                                </tr>
                                <tr>
                                    <td>5  State</td>
                                    <td>
                                        <asp:Label ID="ddlstate" runat="server"></asp:Label>
                                    </td>
                                    <td valign="top">6  District</td>
                                    <td>
                                        <asp:Label ID="ddlDistrict" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>7  Mandal</td>
                                    <td>
                                        <asp:Label ID="ddlmandal" runat="server"></asp:Label>
                                    </td>
                                    <td valign="top">8  Village/Town</td>
                                    <td>
                                        <asp:Label ID="ddlvillage" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>9  Door No</td>
                                    <td>
                                        <asp:Label ID="txtdoorno" runat="server"></asp:Label>
                                    </td>
                                    <td valign="top">10  Pin Code</td>
                                    <td>
                                        <asp:Label ID="txtpincode" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="font-size: medium">
                                        <asp:Label ID="Label22" runat="server" Font-Bold="True" Font-Size="13px" ForeColor="Black">Subsidy already received for the certification in Rs.</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>11 From Central Government</td>
                                    <td>
                                        <asp:Label ID="txtFromCentralGovernment" runat="server"></asp:Label></td>
                                    <td valign="top">12  From Financing Institution</td>
                                    <td>
                                        <asp:Label ID="txtFinancingInstitution" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>13  From State Government</td>
                                    <td>
                                        <asp:Label ID="txtFromStateGovernment" runat="server"></asp:Label>
                                    </td>

                                    <td>14 Amount spent in acquiring the certification</td>
                                    <td>
                                        <asp:Label ID="txtAmountspentinacquiringthecertification" runat="server"></asp:Label>
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
