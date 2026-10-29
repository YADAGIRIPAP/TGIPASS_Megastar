<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BWMdealerprint.aspx.cs" Inherits="UI_TSiPASS_BWMdealerprint" %>

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

        .auto-style2 {
            width: 236px;
        }

        .auto-style3 {
            width: 195px;
        }

        .auto-style4 {
            width: 332px;
        }

        .auto-style5 {
            width: 129px;
        }

        .auto-style6 {
            width: 171px;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <div align="center">
            <div align="center" style="text-align: center">
                <div align="center">
                    <center>
                        <img src="telanganalogo.png" width="75px" height="75px" />
                    </center>
                    <h3>BWM DEALER APPLICATION FORM</h3>
                </div>
                <br />
                <div align="center">
                    <div align="center">
                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                            <tr>
                                <%--     <td>Battery Dealer ID:
                                </td>
                                <td>
                                    <asp:Label ID="lblbatdealid" runat="server"></asp:Label>
                                    &nbsp;
                                </td>--%>
                            </tr>
                            <tr>
                                <td>Name of the BWM Dealer
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblnameofthebwmdealer" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <%-- <tr>
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
                            </tr>--%>
                        </table>
                        <div align="center">
                            <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">

                                <tr>
                                    <td>PinCode
                                    </td>
                                    <td class="auto-style6">
                                        <span>
                                            <asp:Label ID="lblPincode0" runat="server"></asp:Label>
                                        </span>
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
                                    <td class="auto-style6">
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
                                <%-- <tr>
                                    <td>Extent
                                    </td>
                                    <td>
                                        <span>
                                            <asp:Label ID="lblExtentofSightArea" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    
                                </tr>--%>
                                <%--<tr>
                                    <td>Designation
                                    </td>
                                    <td><span>
                                        <asp:Label ID="lblDesignation" runat="server"></asp:Label>
                                    </span></td>
                                    <td>Cell No</td>
                                    <td><span>
                                        <asp:Label ID="lblCellNo" runat="server"></asp:Label>
                                    </span></td>
                                </tr>--%>
                                <tr>


                                   
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
                                 <div align="center" id="pcbnew" runat="server" visible="true">
                                            <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                                                <tr>
                                                    <td align="center" colspan="4" style="text-align: center; background-color: #0066FF;
                                                        color: #FFFFFF; font-size: large; font-weight: bold;">
                                                        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="White">PCB</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4">
                                                        <asp:HyperLink ID="hylinkpcb" runat="server" Visible="false">PCB OCMMS Common Application Form</asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                <br />
                                <br />

                                <br />
                                <br />

                                <br />

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
