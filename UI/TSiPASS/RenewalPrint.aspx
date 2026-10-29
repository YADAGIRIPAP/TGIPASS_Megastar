<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RenewalPrint.aspx.cs" Inherits="UI_TSiPASS_RenewalPrint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>:: TS-iPASS ::</title>
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
            padding: 10px10px10px10px;
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
                        <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/telanganalogo.png" width="75px" height="75px" />
                    </center>
                    <h3>TS-iPASS COMMON APPLICATION FORM(Renewal)</h3>
                </div>
                <br />
                <div align="center">
                    <div align="center">
                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                            <tr>
                                <td>UID No:
                                </td>
                                <td>
                                    <asp:Label ID="lblUidNo" runat="server"></asp:Label>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>NAME OF INDUSTRIAL UNDERTAKING
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblNameOfUndertaker" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>NAME OF PROMOTER
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblNameOfPromoter" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>S/o. D/o. W/o
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblSonOf" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>Age</td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblEntAge" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                        </table>
                        <div align="center">
                            <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                <tr>
                                    <td>Survey No
                                    </td>
                                    <td>
                                        <asp:Label ID="lblSurveyNo" runat="server"></asp:Label>
                                        &nbsp;
                                    </td>
                                    <td>District
                                    </td>
                                    <td>
                                        <span>
                                            <asp:Label ID="lblDistrict0" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Village/Town
                                    </td>
                                    <td>
                                        <span>
                                            <asp:Label ID="lblvillage0" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td>Mandal
                                    </td>
                                    <td>
                                        <span>
                                            <asp:Label ID="lblMandal0" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Street
                                    </td>
                                    <td>
                                        <span>
                                            <asp:Label ID="lblExtentofSightArea" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td>PinCode
                                    </td>
                                    <td>
                                        <span>
                                            <asp:Label ID="lblPincode0" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Designation
                                    </td>
                                    <td><span>
                                        <asp:Label ID="lblDesignation" runat="server"></asp:Label>
                                    </span></td>
                                    <td>Cell No</td>
                                    <td><span>
                                        <asp:Label ID="lblCellNo" runat="server"></asp:Label>
                                    </span></td>
                                </tr>
                                <tr>
                                    <td>Email Id</td>
                                    <td><span>
                                        <asp:Label ID="lblEmailId" runat="server"></asp:Label>
                                    </span></td>
                                    <td></td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div align="center">
                        <div align="center">
                            <div align="center">
                                <br />
                                <div align="center" id="divfactory" runat="server" visible="false">
                                    <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                        <tr>
                                            <td align="center" colspan="4" style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                                <asp:Label ID="lblIndustries5" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="White">Factory Details</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Registration Number</td>
                                            <td><span>
                                                <asp:Label ID="lblregnno" runat="server"></asp:Label>
                                            </span>
                                            </td>
                                            <td>License Number</td>
                                            <td><span>
                                                <asp:Label ID="lbllicno" runat="server"></asp:Label>
                                            </span></td>
                                        </tr>
                                        <tr>
                                            <td>Circle </td>
                                            <td><span>
                                                <asp:Label ID="lblCircle" runat="server"></asp:Label>
                                            </span></td>
                                            <td>Installed horse power</td>
                                            <td><span>
                                                <asp:Label ID="lblhp" runat="server"></asp:Label>
                                            </span></td>
                                        </tr>
                                        <tr>
                                            <td>Calendar Year</td>
                                            <td><span>
                                                <asp:Label ID="lblcalYear" runat="server"></asp:Label>
                                            </span></td>
                                            <td>No: of years for which renewal is required and agreeable for payment of fee</td>
                                            <td><span>
                                                <asp:Label ID="lblnoofyear" runat="server"></asp:Label>
                                            </span></td>
                                        </tr>
                                    </table>
                                </div>
                                <br />
                                <br />
                                <div align="center">
                                    <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                        <tr>
                                            <td align="center" colspan="4" style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                                <asp:Label ID="lblIndustries6" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="White">Boiler Details</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Type Of Boiler</td>
                                            <td>
                                                <span>
                                                    <asp:Label ID="lblTypeOfBoiler" runat="server"></asp:Label>
                                                </span>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>Registration Number of the Boiler
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBoilerRegNo" runat="server"></asp:Label>
                                                &nbsp;
                                            </td>
                                            <td>Boiler Used for&nbsp;
                                            </td>
                                            <td>
                                                <span>
                                                    <asp:Label ID="lblBoilerUsedFor" runat="server"></asp:Label>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Name of the Owner/Agent
                                            </td>
                                            <td>
                                                <span>
                                                    <asp:Label ID="lblNameOfAgent" runat="server"></asp:Label>
                                                </span>
                                            </td>
                                            <td>Where situated
                                            </td>
                                            <td>
                                                <span>
                                                    <asp:Label ID="lblBoilerLocation" runat="server"></asp:Label>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Maximum Continous Evaporation
                                            </td>
                                            <td>
                                                <span>
                                                    <asp:Label ID="lblMaxEvaporation" runat="server"></asp:Label>
                                                </span>
                                            </td>
                                            <td>&nbsp;Boiler Rating/Heating Surface
                                            </td>
                                            <td>
                                                <span>
                                                    <asp:Label ID="lblBoilerRating" runat="server"></asp:Label>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Allowed maximum working pressure (W.P)</td>
                                            <td><span>
                                                <asp:Label ID="lblWP" runat="server"></asp:Label>
                                            </span></td>
                                            <td>Whether certificate of boiler U/R 376(ff)/396/ff is required</td>
                                            <td><span>
                                                <asp:Label ID="lblcertificateofboiler" runat="server"></asp:Label>
                                            </span></td>
                                        </tr>
                                        <tr>
                                            <td>Expiry date</td>
                                            <td><span>
                                                <asp:Label ID="lblExpirydate" runat="server"></asp:Label>
                                            </span></td>
                                            <td>Inspection required</td>
                                            <td><span>
                                                <asp:Label ID="lblInspectionrequired" runat="server"></asp:Label>
                                            </span></td>
                                        </tr>
                                        <tr>
                                            <td>Registration number of steam pipeline</td>
                                            <td><span>
                                                <asp:Label ID="lblregnnopipeline" runat="server"></asp:Label>
                                            </span></td>
                                            <td>Total length of steam pipeline</td>
                                            <td>
                                                <span>
                                                    <asp:Label ID="lbllengthOfSteamPipeline" runat="server"></asp:Label>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Exemption of boiler under section 34-2 is required</td>
                                            <td><span>
                                                <asp:Label ID="lblExemptionofboiler" runat="server"></asp:Label>
                                            </span></td>
                                            <td>choose the inspecting authority</td>
                                            <td><span>
                                                <asp:Label ID="lblinspectingauthority" runat="server"></asp:Label>
                                            </span></td>
                                        </tr>
                                        <tr>
                                            <td>Remarks</td>
                                            <td><span>
                                                <asp:Label ID="lblRemarks" runat="server"></asp:Label>
                                            </span></td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                                <br />
                                <br />
                                <div align="center">
                                    <table bgcolor="White" border="2px" style="font-family: Verdana; font-size: small;" width="800">
                                        <tr>
                                            <td colspan="2"
                                                style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="15px"
                                                    ForeColor="White">Labour Details</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Labour registration number</td>
                                            <td><span>
                                                <asp:Label ID="lblLabourregistrationno" runat="server"></asp:Label>
                                            </span></td>
                                        </tr>
                                        <tr>
                                            <td>Previous renewal date</td>
                                            <td><span>
                                                <asp:Label ID="lblPreviousrenewaldate" runat="server"></asp:Label>
                                            </span></td>
                                        </tr>
                                        <tr>
                                            <td>Category of Establishment</td>
                                            <td>
                                                <asp:Label ID="lblCategory" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="font-size: medium">
                                                <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="13px"
                                                    ForeColor="Black">Manager Details:</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Name</td>
                                            <td>
                                                <asp:Label ID="lblMangerName" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>S/D/W/o</td>
                                            <td>
                                                <asp:Label ID="lblFatherName" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Age</td>
                                            <td>
                                                <asp:Label ID="lblMgrAge" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <br />
                                <div align="center" id="div" runat="server" visible="false">
                                    <table bgcolor="White" border="2px" style="font-family: Verdana; font-size: small;" width="800">
                                        <tr>
                                            <td colspan="2" style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="15px"
                                                    ForeColor="White">TSPCB (CFO Renewals)</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>1. B1(Form XIII under Water Act)(Attachment)</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>2. B2(Form-I under Air Act)(Attachment)</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>3. Form-1 under HW(M,H &TM) Rules for HWA(Attachment)</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                                <input id="btnPrint" onclick="window.print()" style="border-right: thin solid; border-top: thin solid; border-left: thin solid; border-bottom: thin solid; width: 80px"
                                    type="button" value="Print" /><br />
                                <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" NavigateUrl="~/UI/TSiPASS/HomeDashboard.aspx"
                                    ForeColor="#3366CC">Home</asp:HyperLink>
                                <br />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
