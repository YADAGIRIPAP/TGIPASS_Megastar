<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompleteApplicationForm.aspx.cs" Inherits="UI_TSiPASS_CompleteApplicationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>DraftPrint</title>
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script type="text/javascript">
        function CallPrint(strid) {
            var prtContent = document.getElementById(strid);
            var WinPrint = window.open('', '', 'letf=0,top=0,width=0,height=0,toolbar=0,scrollbars=1,status=0');
            var strOldOne = prtContent.innerHTML;
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
            prtContent.innerHTML = strOldOne;
        }
    </script>
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

        .auto-style1 {
            height: 37px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <div>
                <table>
                    <tr>
                        <td>
                            <div align="center" style="text-align: center" id="recipet" runat="server">
                                <div align="center" style="width: 1000px">
                                    <center>
                        <img src="telanganalogo.png" width="75px" height="75px" />
                    </center>
                                    <%-- <h3>TS-iPASS COMMON APPLICATION FORM</h3>--%>
                                    <br />
                                    <table style="width: 100%;" align="center">
                                        <tr>
                                            <td width="100%" align="center" style="text-align: center">
                                                <asp:Label Font-Bold="true" Font-Size="X-Large" ID="lblheadTPRIDE" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <br />
                                </div>
                                <div align="center" id="Receipt" runat="server">

                                    <table style="width: 800px">
                                        <tr>
                                            <td>
                                                <div align="center" id="divCommonAppli" runat="server" visible="false">
                                                    <div align="center">
                                                        <table bgcolor="White" width="1000px" border="2px"
                                                            style="font-family: Verdana; font-size: small;">
                                                            <tr>
                                                                <td align="center" colspan="4"
                                                                    style="text-align: center; background-color: #0066FF;">
                                                                    <asp:Label ID="lblIndustries1" runat="server" Font-Bold="True" Font-Size="15px"
                                                                        ForeColor="White">COMMON DETAILS OF THE ENTREPRENUER</asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left; width: 250px">EM/Udyog Aadhar No</td>
                                                                <td style="text-align: left; width: 250px">
                                                                    <asp:Label ID="txtudyogAadharNo" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="text-align: left; width: 250px">Unit Name</td>
                                                                <td style="width: 250px">
                                                                    <span>
                                                                        <asp:Label ID="txtUnitname" runat="server"></asp:Label>
                                                                    </span>

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Name of the  Managing Director /Managing Partner / Proprietor</td>
                                                                <td>
                                                                    <span>
                                                                        <asp:Label ID="txtApplicantName" runat="server"></asp:Label>
                                                                    </span>
                                                                </td>
                                                                <td>VAT / CST / GST/ TIN Number</td>
                                                                <td>
                                                                    <span>
                                                                        <asp:Label ID="txtTinNumber" runat="server"></asp:Label>
                                                                    </span>

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>PAN Number of the  Managing Director /Managing Partner / Proprietor</td>
                                                                <td>
                                                                    <span>
                                                                        <asp:Label ID="txtPanNumber" runat="server"></asp:Label>
                                                                    </span></td>
                                                                <td>Category</td>
                                                                <td>
                                                                    <asp:Label ID="ddlCategory" runat="server"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Type of Organization</td>
                                                                <td>
                                                                    <span>
                                                                        <asp:Label ID="ddltypeofOrg" runat="server"></asp:Label>
                                                                    </span>
                                                                </td>
                                                                <td>Industry Status 
                                                                </td>

                                                                <td><span>
                                                                    <asp:Label ID="ddlindustryStatus" runat="server">                                                      
                                                                    </asp:Label></span>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td>Date of commencement for Production</td>
                                                                <td>
                                                                    <span>
                                                                        <asp:Label ID="txtDateofCommencement" runat="server"></asp:Label>
                                                                    </span>
                                                                </td>
                                                                <td>Social Status</td>
                                                                <td>
                                                                    <span>
                                                                        <asp:Label ID="rblCaste" runat="server"></asp:Label>
                                                                    </span>
                                                                </td>

                                                            </tr>
                                                            <tr id="trempartno" runat="server" visible="false">
                                                                <td><%--EM Part - II/IEM/IL No:--%>
                                                                </td>
                                                                <td>
                                                                    <span>
                                                                        <asp:Label ID="lblEMPartNo" runat="server" Visible="false"> </asp:Label>
                                                                    </span>
                                                                </td>
                                                                <td></td>
                                                                <td></td>
                                                                <%--  <td>Nature of Activity
                                    </td>
                                    <td>
                                        <span>
                                            <asp:Label ID="ddlintLineofActivity" runat="server"></asp:Label>
                                        </span>

                                    </td>--%>
                                                            </tr>
                                                            <%--<tr>
                                    <td>Areas</td>
                                    <td>
                                        <span>
                                            <asp:Label ID="rblGHMC" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                    <td>Type of Sector
                                    </td>
                                    <td>
                                        <span>
                                            <asp:Label ID="rblSector" runat="server"></asp:Label>
                                        </span>

                                    </td>
                                </tr>
                                <tr>
                                    <td>Allied Type</td>
                                    <td>
                                        <span>
                                            <asp:Label ID="rblVeh" runat="server"></asp:Label>
                                        </span>
                                    </td>

                                </tr>--%>

                                                            <tr>
                                                                <td align="center" colspan="4"
                                                                    style="text-align: center;">
                                                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="15px"
                                                                        ForeColor="Black">UNIT ADDRESS</asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left; width: 250px">District</td>
                                                                <td style="text-align: left; width: 250px">
                                                                    <span>
                                                                        <asp:Label ID="ddldistrictunit" runat="server"></asp:Label>
                                                                    </span>
                                                                </td>
                                                                <td style="text-align: left; width: 250px">Survey No
                                                                </td>
                                                                <td style="text-align: left; width: 250px">
                                                                    <span>
                                                                        <asp:Label ID="txtunitaddhno" runat="server"></asp:Label>
                                                                    </span>

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left; width: 250px">Mandal</td>
                                                                <td style="text-align: left; width: 250px">
                                                                    <span>
                                                                        <asp:Label ID="ddlUnitMandal" runat="server"></asp:Label>
                                                                    </span>
                                                                </td>
                                                                <td style="text-align: left; width: 250px">Street</td>
                                                                <td style="text-align: left; width: 250px">
                                                                    <span>
                                                                        <asp:Label ID="txtstreetunit" runat="server"></asp:Label>
                                                                    </span>

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left; width: 250px">Village</td>
                                                                <td style="text-align: left; width: 250px">
                                                                    <span>
                                                                        <asp:Label ID="ddlVillageunit" runat="server"></asp:Label>
                                                                    </span>
                                                                </td>
                                                                <td style="text-align: left; width: 250px">Mobile Number
                                                                </td>
                                                                <td style="text-align: left; width: 250px">
                                                                    <span>
                                                                        <asp:Label ID="txtunitmobileno" runat="server"></asp:Label>
                                                                    </span>

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left; width: 250px">Email Id</td>
                                                                <td style="text-align: left; width: 250px">
                                                                    <span>
                                                                        <asp:Label ID="txtunitemailid" runat="server"></asp:Label>
                                                                    </span>
                                                                </td>
                                                                <td style="text-align: left; width: 250px">&nbsp;</td>
                                                                <td style="text-align: left; width: 250px">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="4"
                                                                    style="text-align: center;">
                                                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="15px"
                                                                        ForeColor="Black">OFFICE ADDRESS</asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left; width: 250px">District</td>
                                                                <td style="text-align: left; width: 250px">
                                                                    <span>
                                                                        <asp:Label ID="ddldistrictoffc" runat="server"></asp:Label>
                                                                    </span>
                                                                </td>
                                                                <td style="text-align: left; width: 250px">Survey No
                                                                </td>
                                                                <td style="text-align: left; width: 250px">
                                                                    <span>
                                                                        <asp:Label ID="txtoffaddhnno" runat="server"></asp:Label>
                                                                    </span>

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left; width: 250px">Mandal</td>
                                                                <td style="text-align: left; width: 250px">
                                                                    <span>
                                                                        <asp:Label ID="ddloffcmandal" runat="server"></asp:Label>
                                                                    </span>
                                                                </td>
                                                                <td style="text-align: left; width: 250px">Street
                                                                </td>
                                                                <td style="text-align: left; width: 250px">
                                                                    <span>
                                                                        <asp:Label ID="txtstreetoffice" runat="server"></asp:Label>
                                                                    </span>

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left; width: 250px">Village</td>
                                                                <td style="text-align: left; width: 250px">
                                                                    <span>
                                                                        <asp:Label ID="ddlvilloffc" runat="server"></asp:Label>
                                                                    </span>
                                                                </td>
                                                                <td style="text-align: left; width: 250px">Mobile Number
                                                                </td>
                                                                <td style="text-align: left; width: 250px">
                                                                    <span>
                                                                        <asp:Label ID="txtOffcMobileNO" runat="server"></asp:Label>
                                                                    </span>

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left; width: 250px">Email Id</td>
                                                                <td style="text-align: left; width: 250px">
                                                                    <span>
                                                                        <asp:Label ID="txtOffcEmail" runat="server"></asp:Label>
                                                                    </span>
                                                                </td>
                                                                <td style="text-align: left; width: 250px"></td>
                                                                <td style="text-align: left; width: 250px">
                                                                    <span></span>

                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div align="center">
                                                        <table bgcolor="White" width="100%" border="2px" style="font-family: Verdana; font-size: small;">
                                                            <tr>
                                                                <td colspan="2"
                                                                    style="font-size: large; text-align: center; background-color: #0066FF; color: #FFFFFF; font-weight: bold;">LINE OF ACTIVITY</td>
                                                            </tr>
                                                            <tr>

                                                                <td>Line of Activity </td>
                                                                <td>
                                                                    <span>
                                                                        <asp:Label ID="lblLineofActiivity" runat="server"></asp:Label>
                                                                    </span>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td id="Td1" colspan="2" runat="server">
                                                                    <asp:GridView ID="gvLOA" runat="server" AutoGenerateColumns="False"
                                                                        Font-Names="Verdana" Font-Size="12px" SkinID="gridviewSkin" Width="100%">
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
                                                            <tr id="trexpansionhead" runat="server" visible="false">
                                                                <td colspan="2"
                                                                    style="font-size: large; text-align: center; background-color: #0066FF; color: #FFFFFF; font-weight: bold;">
                                                                    <asp:Label ID="lblexpan1" Text="Expansion/Diversification" runat="server"></asp:Label>&nbsp;
                                        PROJECT (In Rs.)</td>
                                                            </tr>
                                                            <tr id="trexpansion" runat="server" visible="false">
                                                                <td colspan="9">
                                                                    <table bgcolor="White" width="100%" border="2px" style="font-family: Verdana; font-size: small;">
                                                                        <tr>
                                                                            <td></td>
                                                                            <td style="text-align: center">Line Of Activity</td>
                                                                            <td style="text-align: center">Installed Capacity</td>
                                                                            <td style="text-align: center">% of increase under
                                                        <br />
                                                                                <asp:Label ID="lblexpan2" runat="server"></asp:Label></td>
                                                                            <%--Expansion--%>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Existing</td>
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
                                                                                Project</td>
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
                                                                <td colspan="2"
                                                                    style="font-size: large; text-align: center; background-color: #0066FF; color: #FFFFFF; font-weight: bold;">FIXED CAPITAL INVESTMENT(In Rs.)</td>
                                                            </tr>
                                                            <tr id="tr2" runat="server">
                                                                <td colspan="9">
                                                                    <table bgcolor="White" width="100%" border="2px" style="font-family: Verdana; font-size: small;">
                                                                        <tr>
                                                                            <td style="text-align: left">Nature of Assets</td>
                                                                            <td style="text-align: left">Existing Enterprise</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Land</td>
                                                                            <td>
                                                                                <asp:Label ID="txtlandexistingNew" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Building</td>
                                                                            <td>
                                                                                <asp:Label ID="txtbuildingexistingNew" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Plant & Machinery
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="txtplantexistingNew" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr id="tr1" runat="server">
                                                                <td colspan="9">
                                                                    <table bgcolor="White" width="100%" border="2px" style="font-family: Verdana; font-size: small;">
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


                                                        </table>
                                                    </div>
                                                    <div align="center">
                                                        <table bgcolor="White" width="100%" border="2px" style="font-family: Verdana; font-size: small;">
                                                            <tr>
                                                                <td colspan="2"
                                                                    style="font-size: large; text-align: center; background-color: #0066FF; color: #FFFFFF; font-weight: bold;">Details of the Director(s)/ Partner(s)</td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <asp:GridView ID="GridViewdirectors" runat="server" AutoGenerateColumns="False"
                                                                        Font-Names="Verdana" Font-Size="12px" SkinID="gridviewSkin" Width="100%">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Sl No.">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="Name" HeaderText="Name" />
                                                                            <asp:BoundField DataField="Community" HeaderText="Community" />
                                                                            <asp:BoundField DataField="Share" HeaderText="Share" />
                                                                            <%-- <asp:BoundField DataField="Percentage" HeaderText="Percentage" />--%>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div align="center">
                                                        <table bgcolor="White" width="100%" border="2px" style="font-family: Verdana; font-size: small;">
                                                            <tr>

                                                                <td colspan="4"
                                                                    style="font-size: large; text-align: center; background-color: #0066FF; color: #FFFFFF; font-weight: bold;">POWER</td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblpowerHEAD" Text="POWER TYPE" runat="server"></asp:Label></td>

                                                                <td>
                                                                    <asp:Label ID="ddlPowerStatus" runat="server"></asp:Label>
                                                                </td>
                                                                <td></td>
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Power Released Date</td>
                                                                <td>
                                                                    <asp:Label ID="txtNewPowerReleaseDate" runat="server"></asp:Label>
                                                                </td>
                                                                <td>Contracted load (In HP)</td>
                                                                <td>
                                                                    <asp:Label ID="txtNewContractedLoad" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Service Connection Number</td>
                                                                <td>
                                                                    <asp:Label ID="txtServiceConnectionNumberNew" runat="server"></asp:Label>
                                                                </td>
                                                                <td>Connected load (In HP)</td>
                                                                <td>
                                                                    <asp:Label ID="txtNewConnectedLoad" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table id="tblpower" runat="server" bgcolor="White" width="100%" border="2" style="font-family: Verdana; font-size: small;">
                                                            <tr>
                                                                <td style="height: 10px" colspan="4"></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">
                                                                    <asp:Label ID="lblexistingpower" runat="server"></asp:Label></td>
                                                            </tr>

                                                            <tr>
                                                                <td>Power Released Date</td>
                                                                <td>
                                                                    <asp:Label ID="txtExistPowerReleaseDate" runat="server"></asp:Label>
                                                                </td>
                                                                <td>Contracted load (In HP)</td>
                                                                <td>
                                                                    <asp:Label ID="txtExistContractedLoad" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Service Connection Number</td>
                                                                <td>
                                                                    <asp:Label ID="txtServiceConnectionNumberExist" runat="server"></asp:Label>
                                                                </td>
                                                                <td>Connected load (In HP)</td>
                                                                <td>
                                                                    <asp:Label ID="txtExistConnectedLoad" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 10px" colspan="4"></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">
                                                                    <asp:Label ID="lblexpandiverpower" runat="server"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Power Released Date</td>
                                                                <td>
                                                                    <asp:Label ID="txtExpanPowerReleaseDate" runat="server"></asp:Label>
                                                                </td>
                                                                <td>Contracted load (In HP)</td>
                                                                <td>
                                                                    <asp:Label ID="txtExpanContractedLoad" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Service Connection Number</td>
                                                                <td>
                                                                    <asp:Label ID="txtServiceConnectionNumberExpan" runat="server"></asp:Label>
                                                                </td>
                                                                <td>Connected load (In HP)</td>
                                                                <td>
                                                                    <asp:Label ID="txtExpanConnectedLoad" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div align="center">
                                                        <table bgcolor="White" width="100%" border="2px" style="font-family: Verdana; font-size: small;">
                                                            <tr>

                                                                <td align="center" colspan="4" style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                                                    <asp:Label ID="lblIndustries6" runat="server" Font-Bold="True" Font-Size="18px"
                                                                        ForeColor="White">Employment</asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table bgcolor="White" width="100%" border="2px" style="font-family: Verdana; font-size: small;">
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
                                                                            <td>Management & Staff 
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="txtstaffMale" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="txtStaffFemale" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>2
                                                                            </td>
                                                                            <td>Supervisory 
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="txtSuprMale" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="txtSuperFemale" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>3
                                                                            </td>
                                                                            <td>Skilled workers
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="txtSkilledWorkersMale" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="txtSkilledWorkersFemale" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>4
                                                                            </td>
                                                                            <td>Semi-skilled workers
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="txtSemiSkilledWorkersMale" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="txtSemiSkilledWorkersFemale" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div align="center">
                                                        <table bgcolor="White" width="100%" border="2px" style="font-family: Verdana; font-size: small;">
                                                            <tr>
                                                                <td align="center" colspan="4"
                                                                    style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                                                    <asp:Label ID="lblIndustries7" runat="server" Font-Bold="True" Font-Size="18px"
                                                                        ForeColor="White">Implementation Steps Taken</asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="4"></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Date of application for Term Loan</td>
                                                                <td>
                                                                    <asp:Label ID="txtTermloan" runat="server"></asp:Label>
                                                                    &nbsp;</td>
                                                                <td>Term Loan Sanctioned Date</td>
                                                                <td>
                                                                    <span>
                                                                        <asp:Label ID="txtdatesanctioned" runat="server"></asp:Label>
                                                                    </span>

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Term Loan Sanctioned reference No</td>
                                                                <td>
                                                                    <span>
                                                                        <asp:Label ID="txtsactionedloan" runat="server"></asp:Label>
                                                                    </span>
                                                                </td>
                                                                <td>Name of the Institution</td>
                                                                <td>
                                                                    <span>
                                                                        <asp:Label ID="txtnmofinstitution" runat="server"></asp:Label>
                                                                    </span>

                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div align="center">
                                                        <table bgcolor="White" width="100%" border="2px" style="font-family: Verdana; font-size: small;">
                                                            <tr>

                                                                <td align="center" colspan="4"
                                                                    style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                                                    <asp:Label ID="lblIndustries9" runat="server" Font-Bold="True" Font-Size="18px"
                                                                        ForeColor="White">Approved/Estimated projected cost, term loan sanctioned and released, assets acquired etc</asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table bgcolor="White" width="100%" border="2px" style="font-family: Verdana; font-size: small;">
                                                                        <tr>
                                                                            <td style="text-align: center">Name of Asset</td>
                                                                            <td style="text-align: center">Approved Project
                                                                                                    <br />
                                                                                Cost                                                                                                    
                                                                            </td>
                                                                            <td style="text-align: center">Loan Sanctioned</td>
                                                                            <td style="text-align: center">Equity from
                                                                                                    <br />
                                                                                the promoters
                                                                            </td>
                                                                            <td style="text-align: center">Loan Amount
                                                                                                    <br />
                                                                                Released
                                                                            </td>
                                                                            <td style="text-align: center">Value of assets  (as
                                                                                                    <br />
                                                                                certified by financial<br />
                                                                                institution)
                                                                            </td>
                                                                            <td style="text-align: center">Value of assets certified
                                                                                                    <br />
                                                                                by Chartered Accoutant                                                                                         
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: center">1</td>
                                                                            <td style="text-align: center">2</td>
                                                                            <td style="text-align: center">3</td>
                                                                            <td style="text-align: center">4</td>
                                                                            <td style="text-align: center">5</td>
                                                                            <td style="text-align: center">6</td>
                                                                            <td style="text-align: center">7</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Land</td>
                                                                            <td>
                                                                                <asp:Label ID="txtLand2" runat="server"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="txtLand3" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="txtLand4" runat="server"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="txtLand5" runat="server"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="txtLand6" runat="server"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="txtLand7" runat="server"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Buildings</td>
                                                                            <td>
                                                                                <asp:Label ID="txtBuilding2" runat="server"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="txtBuilding3" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="txtBuilding4" runat="server"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="txtBuilding5" runat="server"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="txtBuilding6" runat="server"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="txtBuilding7" runat="server"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Plant & Machinery</td>
                                                                            <td>
                                                                                <asp:Label ID="txtPM2" runat="server"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="txtPM3" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="txtPM4" runat="server"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="txtPM5" runat="server"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="txtPM6" runat="server"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="txtPM7" runat="server"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Machinery Contingencies</td>
                                                                            <td>
                                                                                <asp:Label ID="txtMCont2" runat="server"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="txtMCont3" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="txtMCont4" runat="server"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="txtMCont5" runat="server"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="txtMCont6" runat="server"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="txtMCont7" runat="server"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Erection</td>
                                                                            <td>
                                                                                <asp:Label ID="txtErec2" runat="server"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="txtErec3" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="txtErec4" runat="server"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="txtErec5" runat="server"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="txtErec6" runat="server"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="txtErec7" runat="server"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Technical know-how,<br />
                                                                                feasibility study</td>
                                                                            <td>
                                                                                <asp:Label ID="txtTFS2" runat="server"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="txtTFS3" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="txtTFS4" runat="server"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="txtTFS5" runat="server"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="txtTFS6" runat="server"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="txtTFS7" runat="server"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Working Capital</td>
                                                                            <td>
                                                                                <asp:Label ID="txtWC2" runat="server"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="txtWC3" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="txtWC4" runat="server"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="txtWC5" runat="server"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="txtWC6" runat="server"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="txtWC7" runat="server"></asp:Label></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div align="center" id="divsecondhandMichinary" runat="server">
                                                        <table bgcolor="White" width="100%" border="2px" style="font-family: Verdana; font-size: small;">
                                                            <tr>
                                                                <td align="center" colspan="6"
                                                                    style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                                                    <asp:Label ID="lblIndustries11" runat="server" Font-Bold="True" Font-Size="18px"
                                                                        ForeColor="White">Approved/Estimated projected cost, term loan sanctioned and released, assets acquired etc</asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr id="trSecondhandmachinery" runat="server">
                                                                <td colspan="4">
                                                                    <table bgcolor="White" width="100%" border="2px" style="font-family: Verdana; font-size: small;">
                                                                        <tr>
                                                                            <td style="text-align: center">Second hand machinery
                                                                                                    <br />
                                                                                value in Rs</td>
                                                                            <td style="text-align: center">New machinery value in Rs</td>
                                                                            <td style="text-align: center">Total value in Rs<br />
                                                                                (1+2)</td>
                                                                            <td style="text-align: center">% of second hand machinery
                                                                                        <br />
                                                                                value in total machinery value</td>
                                                                            <td style="text-align: center">Value of the machinery
                                                                                        <br />
                                                                                purchaced from TSIDC<br />
                                                                                (Telangana unit)/TSSFC
                                                                                        <br />
                                                                                (Telangana unit)/Bank in Rs</td>
                                                                            <td style="text-align: center">Total value in Rs
                                                                                        <br />
                                                                                (2+5)</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: center">1</td>
                                                                            <td style="text-align: center">2</td>
                                                                            <td style="text-align: center">3</td>
                                                                            <td style="text-align: center">4</td>
                                                                            <td style="text-align: center">5</td>
                                                                            <td style="text-align: center">6</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: center">
                                                                                <asp:Label ID="txtsecondhndmachine" runat="server"></asp:Label></td>
                                                                            <td style="text-align: center">
                                                                                <asp:Label ID="txtnewmachine" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: center">
                                                                                <asp:Label ID="txtTotalvalue12" runat="server"></asp:Label></td>
                                                                            <td style="text-align: center">
                                                                                <asp:Label ID="txtpercentage12" runat="server"></asp:Label></td>
                                                                            <td style="text-align: center">
                                                                                <asp:Label ID="txtmachinepucr" runat="server"></asp:Label></td>
                                                                            <td style="text-align: center">
                                                                                <asp:Label ID="txttotal25" runat="server"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6"></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div align="center">
                                                        <table bgcolor="White" width="100%" border="2px"
                                                            style="font-family: Verdana; font-size: small;">
                                                            <tr>

                                                                <td align="center" colspan="4"
                                                                    style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                                                    <asp:Label ID="lblIndustries12" runat="server" Font-Bold="True" Font-Size="15px"
                                                                        ForeColor="White">Registration with Commercial taxes Department Registration</asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>VAT / CST / GST No</td>
                                                                <td>
                                                                    <asp:Label ID="txtvatno" runat="server"></asp:Label></td>
                                                                <td>Registration Date</td>
                                                                <td>
                                                                    <span>
                                                                        <asp:Label ID="txtCSTRegDate" runat="server"></asp:Label>
                                                                    </span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Registring Authority</td>
                                                                <td>
                                                                    <asp:Label ID="txtCSTRegAuthority" runat="server"></asp:Label></td>

                                                                <td>Registring Authority Address</td>
                                                                <td>
                                                                    <span>
                                                                        <asp:Label ID="txtCSTRegAuthAddress" runat="server"></asp:Label>
                                                                    </span>
                                                                </td>
                                                            </tr>
                                                            <tr id="trcst" runat="server" visible="false">
                                                                <td>CST No</td>
                                                                <td>
                                                                    <asp:Label ID="txtcstno" runat="server"></asp:Label></td>
                                                                <td></td>
                                                                <td></td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div align="center" id="divInvestmenSubsidy" runat="server" visible="false">
                                                    <table bgcolor="White" border="2px" style="font-family: Verdana; font-size: small;" width="100%">
                                                        <tr>
                                                            <td colspan="2"
                                                                style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="15px"
                                                                    ForeColor="White">ANNEXURE: VIII - Claiming of Investment Subsidy</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="font-size: medium">
                                                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="13px" ForeColor="Black">1 Subsidy Already availed i.r.o Expansion / Diversification</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>1.1 Scheme</td>
                                                            <td>
                                                                <asp:Label ID="txtAvldSubsidyScheme" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>1.2 Amount in Rs.</td>
                                                            <td>
                                                                <asp:Label ID="txtAvldSubsidyAmt" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="font-size: medium">
                                                                <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="13px" ForeColor="Black">2 Incentives Applied for (in Rs.) on fixed capital investment</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>2.1 Scheme eligible</td>
                                                            <td>
                                                                <asp:Label ID="txtSchemeEligible" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">2.2 Investment Subsidy</td>
                                                            <td>
                                                                <asp:Label ID="txtAppldInvestSubsidy" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>2.3 Additional amount for Women</td>
                                                            <td>
                                                                <asp:Label ID="txtAppldAddlAmtWomen" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>2.4 Total Investment Subsidy</td>
                                                            <td>
                                                                <asp:Label ID="txtAppldTotInvestSubsidy" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div align="center" id="divStampDuty" runat="server" visible="false">
                                                    <table bgcolor="White" width="100%" border="2px" style="font-family: Verdana; font-size: small;">
                                                        <tr>
                                                            <td align="center" colspan="4"
                                                                style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="18px"
                                                                    ForeColor="White">ANNEXURE: VI - Claiming of Stamp Duty, Transfer Duty, Mortgage Duty, Land Conversion Charges & Land Cost Purchased in IE/ IDA / IP’s </asp:Label>
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
                                                                <table bgcolor="White" width="100%" border="2px" style="font-family: Verdana; font-size: small;">
                                                                    <tr>
                                                                        <td colspan="4" style="font-weight: bold; text-align: left">3   Details of duty paid and claimed</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td></td>
                                                                        <td>Nature Of Payment</td>
                                                                        <td>Amount Paid</td>
                                                                        <td>Amount Claimed</td>
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
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div align="center" id="divPowerCost" runat="server" visible="false">
                                                    <table bgcolor="White" width="100%" border="2px" style="font-family: Verdana; font-size: small;">
                                                        <tr>
                                                            <td align="center" colspan="4"
                                                                style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                                                <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="18px"
                                                                    ForeColor="White">ANNEXURE: VII - Reimbursement of Power Cost</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-weight: bold; text-align: left">1.  For Expansion / Diversification</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-weight: bold; text-align: left">1.1 Power utilised during previous 3 years</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="gvPowerIncentives" runat="server" AutoGenerateColumns="False"
                                                                    Font-Names="Verdana" Font-Size="12px" SkinID="gridviewSkin" Width="100%">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Sl No.">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="FinancialYear" HeaderText="Financial year" />
                                                                        <asp:BoundField DataField="UnitsConsumed" HeaderText="Units consumed" />
                                                                        <asp:BoundField DataField="Amount" HeaderText="Amount paid in Rs" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-weight: bold; text-align: left">2. Energy consumption details from DCP</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="gvEnergy" runat="server" AutoGenerateColumns="False"
                                                                    Font-Names="Verdana" Font-Size="12px" SkinID="gridviewSkin" Width="100%">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Sl No.">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="FinancialYear" HeaderText="Financial year" />
                                                                        <asp:BoundField DataField="F_UnitsConsumed" HeaderText="1st Half Year Units consumed" />
                                                                        <asp:BoundField DataField="F_Amount" HeaderText="1st Half Year Amount paid in Rs" />
                                                                        <asp:BoundField DataField="S_UnitsConsumed" HeaderText="2nd Half Year Units consumed" />
                                                                        <asp:BoundField DataField="S_Amount" HeaderText="2nd Half Year Amount paid in Rs" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-weight: bold; text-align: left">Amount Clamed    :&nbsp;   
                                            <asp:Label ID="txtClaimedAmount" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div align="center" id="divPavalaVaddi" runat="server" visible="false">
                                                    <table bgcolor="White" width="100%" border="2px" style="font-family: Verdana; font-size: small;">
                                                        <tr>
                                                            <td align="center" colspan="4"
                                                                style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                                                <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="18px"
                                                                    ForeColor="White">ANNEXURE: IX - Reimbursement of Interest Subsidy under Pavala Vaddi Scheme</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-weight: bold; text-align: left">1.  Interest paid details from DCP</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="gvInterestDCP" runat="server" AutoGenerateColumns="False"
                                                                    Font-Names="Verdana" Font-Size="12px" SkinID="gridviewSkin" Width="100%">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Sl No.">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="FinancialYearNew" HeaderText="Financial year" />
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
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div align="center" id="divSalesTax" runat="server" visible="false">
                                                    <table bgcolor="White" width="100%" border="2px" style="font-family: Verdana; font-size: small;">
                                                        <tr>
                                                            <td align="center" colspan="4"
                                                                style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                                                <asp:Label ID="Label19" runat="server" Font-Bold="True" Font-Size="18px"
                                                                    ForeColor="White">ANNEXURE: XI - Reimbursement of Sales Tax</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-weight: bold; text-align: left">1.  Production Details preceeding 3 years before expansion / diversification 
                                            <br />
                                                                &nbsp;&nbsp;&nbsp; certified by the financial institution / CA
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="gvProductiondtls" runat="server" AutoGenerateColumns="False"
                                                                    Font-Names="Verdana" Font-Size="12px" SkinID="gridviewSkin" Width="100%">
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
                                                            <td class="auto-style1"></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-weight: bold; text-align: left">2. Sales Tax paid since DCP as certified by CTO</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="gvSalesTax" runat="server" AutoGenerateColumns="False"
                                                                    Font-Names="Verdana" Font-Size="12px" SkinID="gridviewSkin" Width="100%">
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
                                                            <td></td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div align="center" id="divQualityCertification" runat="server" visible="false">
                                                    <table bgcolor="White" border="2px" style="font-family: Verdana; font-size: small;" width="100%">
                                                        <tr>
                                                            <td colspan="4"
                                                                style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                                                <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Size="15px"
                                                                    ForeColor="White">ANNEXURE: XII - Reimbursement of Quality Certification Charges for Acquiring Certification Cost                                                    
                                                                </asp:Label>
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
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div align="center" id="divCleanerProduction" runat="server" visible="false">
                                                    <table bgcolor="White" width="100%" border="2px" style="font-family: Verdana; font-size: small;">
                                                        <tr>
                                                            <td align="center" colspan="4"
                                                                style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                                                <asp:Label ID="Label23" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="White">ANNEXURE: XIII - Reimbursement on equipment purchased for cleaner production measures.</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-weight: bold; text-align: left">1. Details of equipment purchased for the purpose</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:GridView ID="gvCertificate" runat="server" AutoGenerateColumns="False"
                                                                    Font-Names="Verdana" Font-Size="12px" SkinID="gridviewSkin" Width="1000px" OnSelectedIndexChanged="gvCertificate_SelectedIndexChanged">
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
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Amount of subsidy claimed in Rs.&nbsp;    
                                    <asp:Label ID="txtsubsidyclaimed" runat="server" Style="font-weight: 700"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div align="center" id="divSkillupgradation" runat="server" visible="false">
                                                    <table bgcolor="White" width="100%" border="2px" style="font-family: Verdana; font-size: small;">
                                                        <tr>
                                                            <td align="center" colspan="4"
                                                                style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                                                <asp:Label ID="Label41" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="White"> ANNEXURE: XIV - Reimbursement of costs involved in Skill upgradation and training</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-weight: bold; text-align: left" colspan="4">1. Training Undergone</td>
                                                        </tr>
                                                        <tr>
                                                            <td>1.1   Name of the training institute</td>
                                                            <td>
                                                                <asp:Label ID="txtagencyName1" runat="server"></asp:Label>
                                                            </td>
                                                            <td>1.2&nbsp;&nbsp; Duration of training                                    
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtDurationoftraining" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>1.3   Name of the skill development programme</td>
                                                            <td>
                                                                <asp:Label ID="txtNameoftheskilldevelopmentprogramme" runat="server"></asp:Label>
                                                            </td>
                                                            <td>1.4&nbsp;&nbsp; Number of skilled employees trained by the industry                                    
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtNumberskilledemployees" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>1.5   Expenditure incurred for training programme</td>
                                                            <td>
                                                                <asp:Label ID="txtExpenditureincurredfortrainingprogramme" runat="server"></asp:Label>
                                                            </td>
                                                            <td>1.6&nbsp;&nbsp; Amount claimed in Rs.
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtAmountclaimedinRs" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4"></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4"></td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div align="center" id="divIIDF" runat="server" visible="false">
                                                    <table bgcolor="White" width="100%" border="2px" style="font-family: Verdana; font-size: small;">
                                                        <tr>
                                                            <td align="center" colspan="4"
                                                                style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                                                <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="White">ANNEXURE: XIV - Claiming for SANCTION OF INDUSTRIAL INFRASTRUCTURE DEVELOPMENT FUND (IIDF) </asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-weight: bold; text-align: left" colspan="4">1. IIDF Fund</td>
                                                        </tr>
                                                        <tr>
                                                            <td>1.1   Whether the unit is located in Industrial Area declared by the Governement</td>
                                                            <td>
                                                                <asp:Label ID="txtUnitLocatedinIndustArea" runat="server"></asp:Label>
                                                            </td>
                                                            <td>1.2  Justification for the location of the Industry, if it is located outside IA declared by the Government                                    
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtJustLocation" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>1.3   Source of Finance</td>
                                                            <td>
                                                                <asp:Label ID="txtFinanceSource" runat="server"></asp:Label>
                                                            </td>
                                                            <td>1.4   Description of the infrastructure facilities required and its objectives
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtReqdInfraFacilities" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>1.5   Estimates of Infrastructure facilities</td>
                                                            <td>
                                                                <asp:Label ID="txtEstimatesInfra" runat="server"></asp:Label>
                                                            </td>
                                                            <td>1.6   How the proposed infrastructure is critical to the Industrial Enterprise
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtProposedInfraCritical" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>1.7   Name of the Chartered Engineer / Agency who prepared the estimates</td>
                                                            <td>
                                                                <asp:Label ID="txtCAName" runat="server"></asp:Label>
                                                            </td>
                                                            <td>1.8   Duration of the project
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtProjDuration" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>1.9   Measures proposed to maintain the infrastructure created & its maintenance cost per annum</td>
                                                            <td>
                                                                <asp:Label ID="txtMaintanCostAnnum" runat="server"></asp:Label>
                                                            </td>
                                                            <td>1.10  Amount claimed in Rs.
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtAmtClaimed" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4"></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4"></td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div align="center" id="divSCAndST" runat="server" visible="false">
                                                    <table bgcolor="White" width="100%" border="2px" style="font-family: Verdana; font-size: small;">
                                                        <tr>
                                                            <td align="center" colspan="4"
                                                                style="text-align: center; background-color: #0066FF; color: #FFFFFF; font-size: large; font-weight: bold;">
                                                                <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="White">ANNEXURE: XVI - Claiming Advance Subsidy for SC / ST Entrepreneurs</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-weight: bold; text-align: left" colspan="4">1. Means of Finance</td>
                                                        </tr>
                                                        <tr>
                                                            <td>1.1   Total equity from promotors / share holders / partners to be brought in Rs.</td>
                                                            <td>
                                                                <asp:Label ID="txtTotalEquity" runat="server"></asp:Label>
                                                            </td>
                                                            <td>1.2  Own capital in Rs.
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtOwnCapital" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>1.3   Borrowed from outside Rs.</td>
                                                            <td>
                                                                <asp:Label ID="txtBorrowed" runat="server"></asp:Label>
                                                            </td>
                                                            <td>1.4   Advance Subsidy claimed in Rs.
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="txtAdvSubClaimed" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4"></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4"></td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td align="center" style="text-align: center">
                                                <asp:Button ID="Button1" runat="server" Height="32px" Width="90px" CssClass="btn btn-warning" Text=" Print " OnClientClick="javascript:CallPrint('Receipt')" />
                                                <asp:Button ID="Button2" runat="server" Height="32px" Width="90px" CssClass="btn btn-warning" Text=" Download Pdf " OnClick="Button2_Click" />
                                                <%-- <input id="btnPrint" onclick="javascript: CallPrint('Receipt')" style="border-right: thin solid; bDownloaforder-top: thin solid; width: 80px; border-left: thin solid; border-bottom: thin solid"
                        type="button" value="Print" />--%>
                    &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="BtnPrevious" runat="server" CssClass="btn btn-danger" Height="32px" Visible="false"
                                    TabIndex="10" Text="Previous" Width="90px" OnClick="BtnPrevious_Click" />
                                                &nbsp;
                                                    &nbsp;&nbsp;<asp:Button ID="BtnNext" runat="server" CssClass="btn btn-danger" Height="32px"
                                                        TabIndex="10" Text="Next" Width="90px" ValidationGroup="group" OnClick="BtnNext_Click" />
                                                <%--<a href="HomeDashboard.aspx">HOME</a>--%>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr runat="server" id="trinvestmentsubsidy">
                        <td>
                            <div align="center" id="Div1" runat="server">
                                <table style="width: 100%" border="1">
                                    <tr>
                                        <td>
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="width: 100%" colspan="5">
                                                        <br />
                                                        <center>
                                                <img src="telanganalogo.png" width="75px" height="75px" />
                                            </center>
                                                        <br />
                                                        <center>
                                                <asp:Label Font-Bold="true" Font-Size="X-Large" ID="Label9" runat="server">GOVERNMENT OF TELANGANA <br />DEPARTMENT OF INDUSTRIES</asp:Label>
                                            </center>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 5%"></td>
                                                    <td style="vertical-align: top; text-align: left">From<br />
                                                        The General Manager,<br />
                                                        District Industries Centre,<br />
                                                        <asp:Label ID="lblletterFrom" runat="server"></asp:Label></td>
                                                    <td style="width: 35%"></td>
                                                    <td style="vertical-align: top; text-align: left">To<br />
                                                        The Commissioner of Industries,<br />
                                                        Government of Telangana,<br />
                                                        Chirag Ali Lane, Abids,<br />
                                                        Hyderabad.</td>
                                                    <td style="width: 2%"></td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center" colspan="5"><u>Letter No :
                                            <asp:Label ID="lblLetterNo" runat="server"></asp:Label>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dated :
                                            <asp:Label ID="lblLetterDate" runat="server"></asp:Label></u></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 2%; text-align: right">Sir,</td>
                                                    <td style="text-align: left" colspan="3"></td>
                                                    <td style="width: 2%"></td>
                                                </tr>

                                                <tr>
                                                    <td style="width: 2%"></td>
                                                    <td colspan="3" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Sub :-
                                            <asp:Label ID="lblTIdeaTPride" runat="server"></asp:Label>
                                                        Incentives Scheme – Claim application of
                                            <asp:Label ID="lblEnterpreneurDetails" runat="server"></asp:Label>
                                                        – Sanction of Incentives – Proposal - Submitted – Reg.
                                                    </td>
                                                    <td style="width: 2%"></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 2%"></td>
                                                    <td colspan="3" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ref :- TS-IPASS Application No. 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplicationNo" runat="server"></asp:Label></span>&nbsp;,  dt: 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplnDate" runat="server"></asp:Label></span></td>
                                                    <td style="width: 2%"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="5" style="text-align: center">*******</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 2%"></td>
                                                    <td colspan="3" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;In the reference cited,&nbsp;<asp:Label ID="lblEnterpreneurDetails2" runat="server"></asp:Label>&nbsp;have applied for the  sanction of incentives under <b>
                                                        <asp:Label ID="lblTIdeaTPride2" runat="server"></asp:Label></b> Incentives Scheme.
                                                    </td>
                                                    <td style="width: 2%"></td>
                                                </tr>

                                                <tr>
                                                    <td style="width: 2%"></td>
                                                    <td colspan="3" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;In this regard it is to submit that the unit is registered vide Udyog Aadhar. No.&nbsp;<asp:Label ID="lblUdyogAadhaarNoDate" runat="server"></asp:Label>&nbsp; with the D.C.P.
                                        <asp:Label ID="lblDCP" runat="server"></asp:Label>&nbsp;for the line of activity&nbsp;<asp:Label ID="lblLineofActivity" runat="server"></asp:Label>&nbsp;the above line of activity is not included in the list of ineligible list of industries.  The unit holder has filed the claim application on
                                        <asp:Label ID="lblClaimApplicationDate" runat="server"></asp:Label>
                                                        &nbsp;Hence there is no delay in filing the claim application.</td>
                                                    <td style="width: 2%"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="5" style="text-align: center"></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 2%"></td>
                                                    <td colspan="3" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The unit has been inspected by the Assistant Director of this office on
                                <asp:Label ID="lblInspectedDate" runat="server"></asp:Label>
                                                        and found working. <%--The unit is financed by
                                <asp:Label ID="lblFinancingBankDtls" runat="server"></asp:Label>
                                            for a Term Loan of Rs.
                                <asp:Label ID="lblTermLoanAmount" runat="server"></asp:Label>--%>.
                            The claim application together with verification report, statement of accounts and required documents are enclosed here with.
                                                    </td>
                                                    <td style="width: 2%"></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 2%"></td>
                                                    <td colspan="3" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The computed cost of the unit is as follows:-</td>
                                                    <td style="width: 2%"></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100%; text-align: center" align="center" colspan="5">
                                                        <table style="width: 40%; text-align: center" align="center">
                                                            <tr>
                                                                <td style="width: 10%">1.</td>
                                                                <td style="text-align: left;" class="auto-style5">Land </td>
                                                                <td style="text-align: left; width: 5px;">:</td>
                                                                <td style="text-align: left; width: 30%;">
                                                                    <asp:Label ID="lblLandCost" runat="server"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>2.</td>
                                                                <td style="text-align: left;" class="auto-style5">Building </td>
                                                                <td style="text-align: left; width: 5px;">:</td>
                                                                <td style="text-align: left; width: 30%;">
                                                                    <asp:Label ID="lblBuildingCost" runat="server"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>3.</td>
                                                                <td style="text-align: left;" class="auto-style2">Plant and Machinery	</td>
                                                                <td style="text-align: left;" class="auto-style3">:</td>
                                                                <td style="text-align: left;" class="auto-style4">
                                                                    <asp:Label ID="lblPlantMachCost" runat="server"></asp:Label></td>
                                                            </tr>
                                                            <tr id="Tr3" runat="server" visible="false">
                                                                <td class="auto-style1"></td>
                                                                <td style="text-align: left;" class="auto-style2">Total	</td>
                                                                <td style="text-align: left;" class="auto-style3">:</td>
                                                                <td style="text-align: left;" class="auto-style4">
                                                                    <asp:Label ID="lblTotal" runat="server"></asp:Label></td>
                                                            </tr>

                                                            <asp:Label ID="lbl" runat="server"></asp:Label>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>

                                            <table style="width: 100%;">
                                                <tr id="Tr4" runat="server" visible="false">
                                                    <td style="width: 2%"></td>
                                                    <td colspan="3" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The unit is eligible for Investment subsidy @ 15% of the computed cost of Rs. &nbsp;
                                <asp:Label ID="lblComputedCost" runat="server">
                                </asp:Label>
                                                        * 15% = Rs.<asp:Label ID="lblComputedCost2" runat="server">
                                                        </asp:Label>/- 
                                                    </td>
                                                    <td style="width: 2%"></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 2%"></td>
                                                    <td colspan="3" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Therefore it is requested the Commissioner of Industries, Telangana, Hyderabad kindly to consider the proposal for
                                            <br />
                                                        sanction Investment subsidy of 
                                    
                                            Rs.
                                        <asp:Label ID="lblAMount" runat="server"></asp:Label>
                                                        (<asp:Label ID="lblApplcationDate" runat="server"></asp:Label>) under New Policy &nbsp;<asp:Label ID="lblTIdeaTPride3" runat="server"></asp:Label>
                                                        Incentives Scheme.               
                                                    </td>
                                                    <td style="width: 2%"></td>
                                                </tr>

                                                <tr>
                                                    <td style="width: 2%; height: 50px">
                                                        <br />
                                                    </td>
                                                    <td colspan="3" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Encl :  As Above                                            
                                            <br />
                                                    </td>
                                                    <td style="width: 2%"></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 2%"></td>
                                                    <td colspan="3" style="text-align: right; font-weight: bold">Your's faithfully,</td>
                                                    <td style="width: 2%"></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 2%"></td>
                                                    <td colspan="3" valign="middle" style="text-align: right;" align="Right">
                                                        <asp:Label ID="lblName" runat="server"></asp:Label>
                                                        <br />
                                                    </td>
                                                    <td style="width: 2%; vertical-align: middle; height: 50px"></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 5%; height: 50px"></td>
                                                </tr>
                                                <%--<tr>
                                    <td colspan="2" style="text-align: right">GENERAL MANAGER
                                    <br />
                                        <asp:Label ID="lblFromOfficerDistrict" runat="server"></asp:Label>
                                        &nbsp;District
                                    </td>
                                    //----------------------///                                    
                                </tr>--%>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr runat="server" id="trpavallavaddi">
                        <td>
                            <div align="center" style="text-align: center">
                                <div align="center">
                                    <center>
                        <img src="telanganalogo.png" width="75px" height="75px" />
                    </center>
                                    <br />
                                    <asp:Label Font-Bold="true" Font-Size="X-Large" ID="Label10" runat="server">GOVERNMENT OF TELANGANA <br />DEPARTMENT OF INDUSTRIES</asp:Label>
                                    <br />
                                    <br />
                                </div>
                                <div align="center" id="Div2" runat="server">
                                    <table style="width: 1000px">
                                        <tr>
                                            <td style="vertical-align: top; width: 400px">From<br />
                                                The General Manager,<br />
                                                District Industries Centre,<br />
                                                <asp:Label ID="lbldist1" runat="server"></asp:Label></td>
                                            <td style="vertical-align: top; width: 400px">To<br />
                                                The Commissioner of Industries,<br />
                                                Government of Telangana,<br />
                                                Chirag Ali Lane, Abids,<br />
                                                Hyderabad.</td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Letter No :
                                <asp:Label ID="lblLetterNo1" runat="server"></asp:Label>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            Dated :
                                <asp:Label ID="lblLetterDate1" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Sir,</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Sub :-  
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblIIPPScheme" runat="server"></asp:Label></span>&nbsp; Incentive Scheme – Claim application for sanction of Reimbursement of Interest Subsidy under Pavala Vaddi Scheme of &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEnterpreneurDetails1" runat="server"></asp:Label></span>&nbsp;Recommended – Proposal – Reg.</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Ref :-  TS-IPASS Application No. 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplicationNo1" runat="server"></asp:Label></span>&nbsp;,  dt: 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplnDate1" runat="server"></asp:Label></span>&nbsp; for the  
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lbl1stOR2nd" runat="server"></asp:Label></span>half year of 
                                 &nbsp;<span style="font-weight: bold"><asp:Label ID="lblFinancialYear1" runat="server"></asp:Label></span>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp; </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">********</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left">Through the reference cited, &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEnterpreneurDetails2pv" runat="server"></asp:Label></span>&nbsp; 
                                have applied for sanction of Reimbursement of Interest Subsidy under Pavala Vaddi Scheme for the &nbsp;<span style="font-weight: bold"><asp:Label ID="lbl1stOR2nd2" runat="server"></asp:Label></span>&nbsp;  half year of &nbsp;<span style="font-weight: bold"><asp:Label ID="lblFinancialYear2" runat="server"></asp:Label></span>&nbsp; under  
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblIIPPScheme2" runat="server"></asp:Label></span>&nbsp; Scheme.</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left">In this regard, it is to submit that the unit has been inspected by the General Manager along with the Deputy Director on 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblinspecteddt" runat="server"></asp:Label></span>&nbsp; and 
                                found the unit is working at the time of Inspection. The unit has obtained EM Part-II vide Ack. No. 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEMPartNOpv" runat="server"></asp:Label></span>&nbsp; dated: 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEMPPartDate" runat="server"></asp:Label></span>&nbsp;  for the line of activity of 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblloa" runat="server"></asp:Label></span>&nbsp; with date of commencement of commercial production w.e.f. 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblDateofCommencement" runat="server"></asp:Label></span>.</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">&nbsp;<span style="font-weight: bold"><asp:Label ID="lbl1stOR2nd3" runat="server"> </asp:Label>
                                                &nbsp;Half Year 
                                <asp:Label ID="lblFinancialYear4" runat="server"></asp:Label></span>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left">&nbsp;&nbsp; The unit holder has paid an amount of Rs. &nbsp;<span style="font-weight: bold"><asp:Label ID="lblamountpaid1" runat="server"></asp:Label></span>&nbsp; 
                                for the &nbsp;<span style="font-weight: bold"><asp:Label ID="lbl1stOR2nd5" runat="server"> </asp:Label>
                                    &nbsp;Half Year of 
                                    &nbsp;
                                    <asp:Label ID="lblFinancialYear3" runat="server"></asp:Label></span>&nbsp; towards Interest. 
                                The eligible reimbursement of Interest Subsidy under Pavala Vaddi is calculated is under:</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left">&nbsp;&nbsp;&nbsp; &nbsp; The rate of interest as per the Bank certificate = 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblBankInterestPercent" runat="server"></asp:Label></span>
                                                But as per G.O. Ms. No. 77, the minimum 3% interest per annum should be borne by the Enterprise. Over and above 3% interest per annum reimbursement will be done to the extent of  9% maximum.  </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Therefore the eligible rate of interest for Pavala Vaddi is 9%</td>
                                        </tr>
                                        <tr id="tr5" runat="server" visible="false">
                                            <td colspan="2">&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;Eligible Pavala Vaddi&nbsp;= (<span style="font-weight: bold"><asp:Label ID="lblamountpaid2" runat="server"></asp:Label></span>&nbsp;* 9)/13.5 = &nbsp;<span style="font-weight: bold"><asp:Label ID="lblpvamount" runat="server"></asp:Label></span>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Therefore, I request the Commissioner of Industries, Telangana, Hyderabad kindly to consider the proposal of the captioned unit for sanction of Reimbursement of Interest subsidy under Pavala Vaddi Scheme for Rs. 
                               &nbsp; <span style="font-weight: bold">
                                   <asp:Label ID="lblSTAmountPaid3" runat="server"></asp:Label></span>&nbsp;
                                       &nbsp;(<asp:Label ID="lblSanctionedAmtDesc" runat="server"></asp:Label>
                                                &nbsp;Rupees only), for the 
                                <span style="font-weight: bold">
                                    <asp:Label ID="lbl1stOR2nd4" runat="server"> </asp:Label>
                                    &nbsp;Half Year 
                                <asp:Label ID="lblFinancialYear5" runat="server"></asp:Label></span>&nbsp;
                                 under  &nbsp; <span style="font-weight: bold">
                                     <asp:Label ID="lblIIPPScheme3" runat="server"></asp:Label></span>&nbsp; Scheme.</td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td style="text-align: center">
                                                <br />
                                                Yours faithfully,
                                <br />
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">Encl : As above.</td>
                                            <td style="text-align: center"><strong>General Manager</strong></td>
                                        </tr>
                                    </table>
                                    <table style="width: 1000px">
                                        <tr>
                                            <td colspan="2">
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="text-align: center">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </td>
                    </tr>

                    <tr id="trpowertarif" runat="server">
                        <td>
                            <div align="center" style="text-align: center">
                                <div align="center">
                                    <center>
                        <img src="telanganalogo.png" width="75px" height="75px" />
                    </center>
                                    <br />
                                    <asp:Label Font-Bold="true" Font-Size="X-Large" ID="Label14" runat="server">GOVERNMENT OF TELANGANA <br />DEPARTMENT OF INDUSTRIES</asp:Label>
                                    <br />
                                    <br />
                                </div>
                                <div align="center" id="Div3" runat="server">
                                    <table style="width: 100%" border="1">
                                        <tr>
                                            <td>
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td style="vertical-align: top; width: 400px">From<br />
                                                            The General Manager,<br />
                                                            District Industries Centre,<br />
                                                            <asp:Label ID="lbldist1pt" runat="server"></asp:Label></td>
                                                        <td style="vertical-align: top; width: 200px">To<br />
                                                            The Commissioner of Industries,<br />
                                                            Government of Telangana,<br />
                                                            Chirag Ali Lane, Abids,<br />
                                                            Hyderabad.</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: center" colspan="2"><u>Letter No :
                                            <asp:Label ID="lblLetterNopt" runat="server"></asp:Label>
                                                            &nbsp;&nbsp;&nbsp;Dated :
                                            <asp:Label ID="lblLetterDatept" runat="server"></asp:Label></u>
                                                        </td>
                                                        <%-- <td style="text-align: left" align="left"></td>--%>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">Sir,</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Sub :- IIPP 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEnterpreneurDetails1pt" runat="server"></asp:Label></span>&nbsp; 
                                Scheme – Claim application for Reimbursement of Power Tariff 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblIIPScheme" runat="server"></asp:Label></span>&nbsp;Recommended – Proposal – Reg.</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="text-align: center">Ref :-  TS-IPASS Application No. 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplicationNopt" runat="server"></asp:Label></span>&nbsp;,  dt: 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplnDatept" runat="server"></asp:Label></span>&nbsp; of the unit holder.
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp; </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="text-align: center">********</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="text-align: center">In the reference cited, &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEnterpreneurDetails2pt" runat="server"></asp:Label></span>&nbsp; 
                                have applied for Reimbursement of Power Tariff for the &nbsp;<span style="font-weight: bold"><asp:Label ID="lbl1stOR2ndpt" runat="server"></asp:Label></span>&nbsp;   half year of 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblFinancialYear1pt" runat="server"></asp:Label></span>&nbsp; under 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblIIPPYearScheme1" runat="server"></asp:Label></span>&nbsp; Scheme.</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="text-align: center">In this connection, it is to submit that the unit has been inspected by the General Manager along with the Deputy Director on 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblinspecteddtpt" runat="server"></asp:Label></span>&nbsp; and 
                                found the unit is working at the time of Inspection. The unit has obtained EM Part-II vide Ack. No. 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEMPartNOpt" runat="server"></asp:Label></span>&nbsp; dated: 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEMPPartDatept" runat="server"></asp:Label></span>&nbsp;  for the line of activity of 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblloapt" runat="server"></asp:Label></span>&nbsp; with date of commencement of commercial production w.e.f. 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblDateofCommencementpt" runat="server"></asp:Label></span>.</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">The Power consumption of the unit is as follows :</td>
                                                    </tr>

                                                    <tr>
                                                        <td colspan="2">&nbsp;<span style="font-weight: bold">&nbsp;<span style="font-weight: bold"><asp:Label ID="lbl1stOR2nd2pt" runat="server"></asp:Label></span>&nbsp;  Half year of &nbsp;
                                <asp:Label ID="lblFinancialYear2pt" runat="server"></asp:Label></span>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="text-align: center" align="center">
                                                            <asp:GridView ID="gvpwtariff" runat="server" AutoGenerateColumns="false">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Sl. No">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblslno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="FinancialYearNew" HeaderText="Month & Year" />
                                                                    <asp:BoundField DataField="TotalUnitsConsumed" HeaderText="No. of Eligible units                                                                                                                     " />

                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="right" style="text-align: right" width="50%">Rate eligible per unit :

                                                        </td>
                                                        <td align="left" style="text-align: left">&nbsp;<span style="font-weight: bold"><asp:Label ID="lblRateEligiblePerUnit" runat="server"></asp:Label></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" style="text-align: right" width="50%">Amount eligible in Rs :

                                                        </td>
                                                        <td align="left" style="text-align: left">&nbsp;<span style="font-weight: bold"><asp:Label ID="lblEligibleAmount" runat="server"></asp:Label></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Therefore, I request the Commissioner of Industries, Telangana, Hyderabad kindly to consider the 
                                            proposal of the captioned unit for sanction of Reimbursement of Power Cost Reimbursement Scheme for Rs. <span style="font-weight: bold">
                                                <asp:Label ID="lblPWAmount2" runat="server"></asp:Label></span>&nbsp;
                                             &nbsp;(<asp:Label ID="lblSanctionedAmtDescpt" runat="server"></asp:Label>
                                                            &nbsp;Rupees only)
                                            for the  &nbsp;
                                 <span style="font-weight: bold">
                                     <asp:Label ID="lbl1stOR2nd3pt" runat="server"></asp:Label></span>&nbsp;half year of  &nbsp; 
                                  <b>
                                      <asp:Label ID="lblFinancialYear3pt" runat="server"></asp:Label></b>&nbsp; under  &nbsp; <span style="font-weight: bold">
                                          <asp:Label ID="lblIIPPYearScheme2" runat="server"></asp:Label></span>&nbsp; Scheme.</td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td style="text-align: center">
                                                            <br />
                                                            <span style="font-weight: bold">Yours faithfully,</span>
                                                            <br />
                                                            <asp:Label ID="lblnamept" runat="server"></asp:Label>
                                                            <br />
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: left">Encl : As above.</td>

                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table style="width: 1000px">
                                        <tr>
                                            <td colspan="2">
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="text-align: center">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </td>
                    </tr>

                    <tr id="trsalestax" runat="server">
                        <td>
                            <div align="center" style="text-align: center">
                                <div align="center">
                                    <center>
                        <img src="telanganalogo.png" width="75px" height="75px" />
                    </center>
                                    <br />
                                    <asp:Label Font-Bold="true" Font-Size="X-Large" ID="Label15" runat="server">GOVERNMENT OF TELANGANA <br />DEPARTMENT OF INDUSTRIES</asp:Label>
                                    <br />
                                    <br />
                                </div>
                                <div align="center" id="Div4" runat="server">
                                    <table style="width: 1000px;" border="1">
                                        <tr>
                                            <td style="vertical-align: top; width: 400px">From<br />
                                                The General Manager,<br />
                                                District Industries Centre,<br />
                                                <asp:Label ID="lblDistrict" runat="server"></asp:Label></td>
                                            <td style="vertical-align: top; width: 400px">To<br />
                                                The Commissioner of Industries,<br />
                                                Government of Telangana,<br />
                                                Chirag Ali Lane, Abids,<br />
                                                Hyderabad.</td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center" colspan="2">Letter No :
                                <asp:Label ID="lblLetterNost" runat="server"></asp:Label>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            Dated :
                                <asp:Label ID="lblLetterDatest" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Sir,</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Sub :- Application of 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEnterpreneurDetails1st" runat="server"></asp:Label></span>&nbsp; for Reimbursement of Sales Tax under 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblTIdeaTPride1st" runat="server"></asp:Label></span>&nbsp; scheme - Proposal submitted – Reg.</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">Ref :-  TS-IPASS Application No. 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplicationNost" runat="server"></asp:Label></span>&nbsp;,  dt: 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplnDatest" runat="server"></asp:Label></span>&nbsp; of the unit holder.
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp; </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">********</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">In the reference cited, 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEnterpreneurDetails2st" runat="server"></asp:Label></span>&nbsp; 
                                have applied for Reimbursement of Sales Tax under 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblTIdeaTPride2st" runat="server"></asp:Label></span>&nbsp; Scheme.</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left">In this connection, i submit that the unit has been inspected by the General Manager along with the Deputy Director on 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblinspecteddtst" runat="server"></asp:Label></span>&nbsp; and 
                                found working and engaged in the line of activity 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblloast" runat="server"></asp:Label></span>.&nbsp;
                                The unit has obtained Udyog Aadhar/EM/IEM/IL/EOU No.
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lbludyogaadharno" runat="server"></asp:Label></span>&nbsp; dated: 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblUdyogAadhaardate" runat="server"></asp:Label></span>&nbsp;  
                                and started commercial production w.e.f. 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblDCPst" runat="server"></asp:Label></span>. 
                                The Commercial Tax Officer, Ladbazar circle has certified in Form-A. The unit has obtained CTO Tin No.
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblTinnost" runat="server"></asp:Label></span>.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">The eligible reimbursement of sales tax is calculated as under :- </td>
                                        </tr>

                                        <tr>
                                            <td colspan="2">&nbsp;<span style="font-weight: bold">&nbsp;<span style="font-weight: bold"><asp:Label ID="lbl1st2nd1" runat="server"></asp:Label></span>&nbsp;  Half year of &nbsp;
                                <asp:Label ID="lblFinancialYear2st" runat="server"></asp:Label></span>&nbsp;</td>
                                        </tr>

                                        <tr>
                                            <td colspan="2">&nbsp; As per form - A the sales tax paid for the 
                                &nbsp;<span style="font-weight: bold">&nbsp;<span style="font-weight: bold"><asp:Label ID="lbl1st2nd2" runat="server"></asp:Label></span>&nbsp;  Half year of &nbsp;
                                <asp:Label ID="lblFinancialYear3st" runat="server"></asp:Label></span>&nbsp;
                                 is Rs. &nbsp; <span style="font-weight: bold">
                                     <asp:Label ID="lblSTAmountPaid" runat="server"></asp:Label></span>.
                                            </td>
                                        </tr>
                                        <tr id="tr6" runat="server" visible="false">
                                            <td colspan="2">&nbsp; The eligible reimbursement of sales tax @ 100% = Rs. &nbsp; <span style="font-weight: bold">
                                                <asp:Label ID="lblSTAmountPaid1" runat="server"></asp:Label></span>.</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">&nbsp; The eligible reimbursement of sales tax = Rs. &nbsp; <span style="font-weight: bold">
                                                <asp:Label ID="lblGMRecommendedAmount" runat="server"></asp:Label></span>.</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left">&nbsp; Hence the unit case is recommended for sanction of 100% Reimbursement of Sales Tax of 
                                &nbsp;<span style="font-weight: bold">
                                    <asp:Label ID="lblSTAmountPaid3st" runat="server"></asp:Label></span>&nbsp;
                                       &nbsp;(<asp:Label ID="Label35" runat="server"></asp:Label>
                                                &nbsp;Rupees only), 
                                for the
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lbl1st2nd3" runat="server"></asp:Label></span>&nbsp;  Half year of &nbsp;
                                &nbsp;<span style="font-weight: bold">
                                    <asp:Label ID="lblFinancialYear4st" runat="server"></asp:Label></span>&nbsp;
                                 under &nbsp; <span style="font-weight: bold">
                                     <asp:Label ID="lblTIdeaTPride3st" runat="server"></asp:Label></span>&nbsp; Scheme.</td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td style="text-align: center">
                                                <br />
                                                <span style="font-weight: bold">Yours faithfully,</span>
                                                <br />
                                                <asp:Label ID="lblNamest" runat="server"></asp:Label>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">Encl : As above.</td>
                                            <td style="text-align: center"></td>
                                        </tr>
                                    </table>
                                    <table style="width: 1000px">
                                        <tr>
                                            <td colspan="2">
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="text-align: center">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </td>
                    </tr>

                    <tr id="Stampduty" runat="server">
                        <td>
                            <div align="center" style="text-align: center">
                                <div align="center">
                                    <center>
                        <img src="telanganalogo.png" width="75px" height="75px" />
                    </center>
                                    <br />
                                    <asp:Label Font-Bold="true" Font-Size="X-Large" ID="Label16" runat="server">GOVERNMENT OF TELANGANA <br />DEPARTMENT OF INDUSTRIES</asp:Label>
                                    <br />
                                    <br />
                                </div>
                                <div align="left" id="Div5" runat="server">
                                    <table style="width: 1000px">
                                        <tr>
                                            <td style="vertical-align: top; width: 400px">From<br />
                                                The General Manager,<br />
                                                District Industries Centre,<br />
                                                <asp:Label ID="lblDistrictsd" runat="server"></asp:Label></td>
                                            <td style="vertical-align: top; width: 400px">To<br />
                                                The Commissioner of Industries,<br />
                                                Government of Telangana,<br />
                                                Chirag Ali Lane, Abids,<br />
                                                Hyderabad.</td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Letter No :
                                <asp:Label ID="lblLetterNosd" runat="server"></asp:Label>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            Dated :
                                <asp:Label ID="lblLetterDatesd" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Sir,</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Sub :- Application of 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEnterpreneurDetails1sd" runat="server"></asp:Label></span>&nbsp; for Reimbursement of Stamp Duty/Transfer Duty / Mortgage Duty / Land Conversion Charges / Land Cost Purchased in IE/IDA/IP’s under 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblTIdeaTPride1" runat="server"></asp:Label></span>&nbsp; scheme - Proposal submitted – Reg.</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">Ref :-  TS-IPASS Application No. 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplicationNosd" runat="server"></asp:Label></span>&nbsp;,  dt: 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplnDatesd" runat="server"></asp:Label></span>&nbsp; of the unit holder.
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp; </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">********</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">In the reference cited, 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEnterpreneurDetails2sd" runat="server"></asp:Label></span>&nbsp; have applied for Reimbursement ofStamp Duty/Transfer Duty / Mortgage Duty / Land Conversion Charges / Land Cost Purchased in IE/IDA/IP’s under 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblTIdeaTPride2sd" runat="server"></asp:Label></span>&nbsp; Scheme.</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">In this connection, i submit that the unit has been inspected by the General Manager along with the Deputy Director on 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblinspecteddtsd" runat="server"></asp:Label></span>&nbsp; and 
                                found working and engaged in the line of activity 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblloasd" runat="server"></asp:Label></span>.&nbsp;
                                The unit has obtained Udyog Aadhar/EM/IEM/IL/EOU No.
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lbludyogaadharnosd" runat="server"></asp:Label></span>&nbsp; dated: 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblUdyogAadhaardatesd" runat="server"></asp:Label></span>&nbsp;  
                                and started commercial production w.e.f. 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblDCPsd" runat="server"></asp:Label></span>. 
                                <%--The Commercial Tax Officer, Ladbazar circle has certified in Form-A. The unit has obtained CTO Tin No.
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblTinno" runat="server"></asp:Label></span>--%>.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">The eligible reimbursement of Stamp Duty/Transfer Duty / Mortgage Duty / Land Conversion Charges / Land Cost Purchased in IE/IDA/IP’s under  is calculated as under :- </td>
                                        </tr>

                                        <tr>
                                            <td colspan="2">&nbsp;<span style="font-weight: bold">&nbsp;<span style="font-weight: bold"><asp:Label ID="lbl1st2nd1sd" runat="server"></asp:Label></span>&nbsp;  Half year of &nbsp;
                                <asp:Label ID="lblFinancialYear2sd" runat="server"></asp:Label></span>&nbsp;</td>
                                        </tr>

                                        <tr>
                                            <td colspan="2">&nbsp; As per form - A the Stamp Duty/Transfer Duty / Mortgage Duty / Land Conversion Charges / Land Cost Purchased in IE/IDA/IP’s under  paid for the 
                                &nbsp;<span style="font-weight: bold">&nbsp;<span style="font-weight: bold"><asp:Label ID="lbl1st2nd2sd" runat="server"></asp:Label></span>&nbsp;  Half year of &nbsp;
                                <asp:Label ID="lblFinancialYear3sd" runat="server"></asp:Label></span>&nbsp;
                                 is Rs. &nbsp; <span style="font-weight: bold">
                                     <asp:Label ID="lblSTAmountPaidsd" runat="server"></asp:Label></span>.
                                            </td>
                                        </tr>

                                        <tr id="trStamptransferDuty" runat="server" visible="false">
                                            <td colspan="2">&nbsp; The eligible reimbursement of Stamp/Transfer Duty  @ 100% = Rs. &nbsp; <span style="font-weight: bold">
                                                <asp:Label ID="lblStampTransferDutyPaid" runat="server"></asp:Label></span>.</td>
                                        </tr>
                                        <tr id="trMortgageDutyPaid" runat="server" visible="false">
                                            <td colspan="2">&nbsp; The eligible reimbursement of Mortgage Duty  @ 100% = Rs. &nbsp; <span style="font-weight: bold">
                                                <asp:Label ID="lblMortgageDutyPaid" runat="server"></asp:Label></span>.</td>
                                        </tr>
                                        <tr id="trLandConversionCharges" runat="server" visible="false">
                                            <td colspan="2">&nbsp; The eligible reimbursement of Land Conversion Charges  @ 100% = Rs. &nbsp; <span style="font-weight: bold">
                                                <asp:Label ID="lblLandConversionCharges" runat="server"></asp:Label></span>.</td>
                                        </tr>
                                        <tr id="trlblLandCostPurchased" runat="server" visible="false">
                                            <td colspan="2">&nbsp; The eligible reimbursement of  Land Cost Purchased in IE/IDA/IP’s  @ 100% = Rs. &nbsp; <span style="font-weight: bold">
                                                <asp:Label ID="lblLandCostPurchased" runat="server"></asp:Label></span>.</td>
                                        </tr>

                                        <tr>
                                            <td colspan="2" style="text-align: left">&nbsp; Hence the unit case is recommended for sanction of 100% Reimbursement of  Stamp Duty/Transfer Duty / Mortgage Duty / Land Conversion Charges / Land Cost Purchased in IE/IDA/IP’s of 
                                &nbsp;<span style="font-weight: bold">
                                    <asp:Label ID="lblSTAmountPaid3sd" runat="server"></asp:Label></span>&nbsp;
                                <br />
                                                &nbsp;(<asp:Label ID="lblSanctionedAmtDescsd" runat="server"></asp:Label>
                                                &nbsp;Rupees only), 
                                for the
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lbl1st2nd3sd" runat="server"></asp:Label></span>&nbsp;  Half year of &nbsp;
                                &nbsp;<span style="font-weight: bold">
                                    <asp:Label ID="lblFinancialYear4sd" runat="server"></asp:Label></span>&nbsp;
                                 under &nbsp; <span style="font-weight: bold">
                                     <asp:Label ID="lblTIdeaTPride3sd" runat="server"></asp:Label></span>&nbsp; Scheme.</td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td style="text-align: center">
                                                <br />
                                                Yours faithfully,
                                <br />
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">Encl : As above.</td>
                                            <td style="text-align: center"><strong>General Manager</strong></td>
                                        </tr>
                                    </table>
                                    <table style="width: 1000px">
                                        <tr>
                                            <td colspan="2">
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="text-align: center">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </td>
                    </tr>

                    <tr id="trseedcap" runat="server">
                        <td>
                            <div align="center" style="text-align: center">
                                <div align="center">
                                    <center>
                        <img src="telanganalogo.png" width="75px" height="75px" />
                    </center>
                                    <br />
                                    <asp:Label Font-Bold="true" Font-Size="X-Large" ID="Label17" runat="server">GOVERNMENT OF TELANGANA <br />DEPARTMENT OF INDUSTRIES</asp:Label>
                                    <br />
                                    <br />
                                </div>
                                <div align="center" id="Div6" runat="server">
                                    <table style="width: 1000px">
                                        <tr>
                                            <td style="vertical-align: top; width: 400px; text-align: left">From<br />
                                                The General Manager,<br />
                                                District Industries Centre,<br />
                                                <asp:Label ID="lblDistrictSC" runat="server"></asp:Label></td>
                                            <td style="vertical-align: top; width: 400px; text-align: left">To<br />
                                                The Commissioner of Industries,<br />
                                                Government of Telangana,<br />
                                                Chirag Ali Lane, Abids,<br />
                                                Hyderabad.</td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Letter No :
                                <asp:Label ID="lblLetterNoSC" runat="server"></asp:Label>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            Dated :
                                <asp:Label ID="lblLetterDateSC" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Sir,</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Sub :- Application of 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEnterpreneurDetails1SC" runat="server"></asp:Label></span>&nbsp; for Reimbursement of Seed Cap 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblTIdeaTPride1SC" runat="server"></asp:Label></span>&nbsp; scheme - Proposal submitted – Reg.</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">Ref :-  TS-IPASS Application No. 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplicationNoSC" runat="server"></asp:Label></span>&nbsp;,  dt: 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplnDateSC" runat="server"></asp:Label></span>&nbsp; of the unit holder.
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp; </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">********</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">In the reference cited, 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEnterpreneurDetails2SC" runat="server"></asp:Label></span>&nbsp; 
                                have applied for Reimbursement of Seed Cap under 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblTIdeaTPride2SC" runat="server"></asp:Label></span>&nbsp; Scheme.</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left">In this connection, i submit that the unit has been inspected by the General Manager along with the Deputy Director on 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblinspecteddtSC" runat="server"></asp:Label></span>&nbsp; and 
                                found working and engaged in the line of activity 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblloaSC" runat="server"></asp:Label></span>.&nbsp;
                                The unit has obtained Udyog Aadhar/EM/IEM/IL/EOU No.
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lbludyogaadharnoSC" runat="server"></asp:Label></span>&nbsp; dated: 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblUdyogAadhaardateSC" runat="server"></asp:Label></span>&nbsp;  
                                and started commercial production w.e.f. 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblDCPSC" runat="server"></asp:Label></span>. 
                                <%--The Commercial Tax Officer, Ladbazar circle has certified in Form-A. The unit has obtained CTO Tin No.
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblTinno" runat="server"></asp:Label></span>.--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left">The eligible reimbursement of Seed Cap is calculated as under :- </td>
                                        </tr>

                                        <tr>
                                            <td colspan="2" style="text-align: left">&nbsp;<span style="font-weight: bold">&nbsp;<span style="font-weight: bold"><asp:Label ID="lbl1st2nd1SC" runat="server"></asp:Label></span>&nbsp;  Half year of &nbsp;
                                <asp:Label ID="lblFinancialYear2SC" runat="server"></asp:Label></span>&nbsp;</td>
                                        </tr>

                                        <tr>
                                            <td colspan="2" style="text-align: left">&nbsp; As per form - A the Seed Cap paid for the 
                                &nbsp;<span style="font-weight: bold">&nbsp;<span style="font-weight: bold"><asp:Label ID="lbl1st2nd2SC" runat="server"></asp:Label></span>&nbsp;  Half year of &nbsp;
                                <asp:Label ID="lblFinancialYear3SC" runat="server"></asp:Label></span>&nbsp;
                                 is Rs. &nbsp; <span style="font-weight: bold">
                                     <asp:Label ID="lblSTAmountPaidSC" runat="server"></asp:Label></span>.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left">&nbsp; The eligible reimbursement of seed cap @ 100% = Rs. &nbsp; <span style="font-weight: bold">
                                                <asp:Label ID="lblSTAmountPaid1SC" runat="server"></asp:Label></span>.</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left">&nbsp; Hence the unit case is recommended for sanction of 100% Reimbursement of Seed Cap of 
                                &nbsp;<span style="font-weight: bold">
                                    <asp:Label ID="lblSTAmountPaid3SC" runat="server"></asp:Label></span>&nbsp;
                                       &nbsp;(<asp:Label ID="lblSanctionedAmtDescSC" runat="server"></asp:Label>
                                                &nbsp;Rupees only), 
                                for the
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lbl1st2nd3SC" runat="server"></asp:Label></span>&nbsp;  Half year of &nbsp;
                                &nbsp;<span style="font-weight: bold">
                                    <asp:Label ID="lblFinancialYear4SC" runat="server"></asp:Label></span>&nbsp;
                                 under &nbsp; <span style="font-weight: bold">
                                     <asp:Label ID="lblTIdeaTPride3SC" runat="server"></asp:Label></span>&nbsp; Scheme.</td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td style="text-align: center">
                                                <br />
                                                Yours faithfully,
                                <br />
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">Encl : As above.</td>
                                            <td style="text-align: center"><strong>General Manager</strong></td>
                                        </tr>
                                    </table>
                                    <table style="width: 1000px">
                                        <tr>
                                            <td colspan="2">
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="text-align: center">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr id="qc" runat="server">
                        <td>
                            <div align="center" style="text-align: center">
                                <div align="center">
                                    <center>
                        <img src="telanganalogo.png" width="75px" height="75px" />
                    </center>
                                    <br />
                                    <asp:Label Font-Bold="true" Font-Size="X-Large" ID="Label24" runat="server">GOVERNMENT OF TELANGANA <br />DEPARTMENT OF INDUSTRIES</asp:Label>
                                    <br />
                                    <br />
                                </div>
                                <div align="center" id="Div7" runat="server">
                                    <table style="width: 1000px">
                                        <tr>
                                            <td style="vertical-align: top; width: 400px; text-align: left">From<br />
                                                The General Manager,<br />
                                                District Industries Centre,<br />
                                                <asp:Label ID="lblDistrictqc" runat="server"></asp:Label></td>
                                            <td style="vertical-align: top; width: 400px; text-align: left">To<br />
                                                The Commissioner of Industries,<br />
                                                Government of Telangana,<br />
                                                Chirag Ali Lane, Abids,<br />
                                                Hyderabad.</td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Letter No :
                                <asp:Label ID="lblLetterNoQC" runat="server"></asp:Label>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            Dated :
                                <asp:Label ID="lblLetterDateQC" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Sir,</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Sub :- Application of 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEnterpreneurDetails1QC" runat="server"></asp:Label></span>&nbsp; for Reimbursement of Quality Certification&nbsp;<span style="font-weight: bold">
                                    <asp:Label ID="lblTIdeaTPride1QC" runat="server"></asp:Label></span>&nbsp; scheme - Proposal submitted – Reg.</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">Ref :-  TS-IPASS Application No. 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplicationNoQC" runat="server"></asp:Label></span>&nbsp;,  dt: 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplnDateQC" runat="server"></asp:Label></span>&nbsp; of the unit holder.
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp; </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">********</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">In the reference cited, 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEnterpreneurDetails2QC" runat="server"></asp:Label></span>&nbsp; 
                                have applied for Reimbursement of Quality Certification under 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblTIdeaTPride2QC" runat="server"></asp:Label></span>&nbsp; Scheme.</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left">In this connection, i submit that the unit has been inspected by the General Manager along with the Deputy Director on 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblinspecteddtQC" runat="server"></asp:Label></span>&nbsp; and 
                                found working and engaged in the line of activity 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblloaQC" runat="server"></asp:Label></span>.&nbsp;
                                The unit has obtained Udyog Aadhar/EM/IEM/IL/EOU No.
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lbludyogaadharnoQC" runat="server"></asp:Label></span>&nbsp; dated: 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblUdyogAadhaardateQC" runat="server"></asp:Label></span>&nbsp;  
                                and started commercial production w.e.f. 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblDCPQC" runat="server"></asp:Label></span>. 
                                <%--The Commercial Tax Officer, Ladbazar circle has certified in Form-A. The unit has obtained CTO Tin No.
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblTinno" runat="server"></asp:Label></span>.--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">The eligible reimbursement of Quality Certification is calculated as under :- </td>
                                        </tr>

                                        <tr>
                                            <td colspan="2">&nbsp;<span style="font-weight: bold">&nbsp;<span style="font-weight: bold"><asp:Label ID="lbl1st2nd1QC" runat="server"></asp:Label></span>&nbsp;  Half year of &nbsp;
                                <asp:Label ID="lblFinancialYear2QC" runat="server"></asp:Label></span>&nbsp;</td>
                                        </tr>

                                        <tr>
                                            <td colspan="2">&nbsp;Quality Certification Amount paid for the 
                                &nbsp;<span style="font-weight: bold">&nbsp;<span style="font-weight: bold"><asp:Label ID="lbl1st2nd2QC" runat="server"></asp:Label></span>&nbsp;  Half year of &nbsp;
                                <asp:Label ID="lblFinancialYear3QC" runat="server"></asp:Label></span>&nbsp;
                                 is Rs. &nbsp; <span style="font-weight: bold">
                                     <asp:Label ID="lblSTAmountPaidQC" runat="server"></asp:Label></span>.
                                            </td>
                                        </tr>
                                        <tr id="tr7" runat="server" visible="false">
                                            <td colspan="2">&nbsp; The eligible reimbursement of Quality Certification @ 100% = Rs. &nbsp; <span style="font-weight: bold">
                                                <asp:Label ID="lblSTAmountPaid1QC" runat="server"></asp:Label></span>.</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left">&nbsp; Hence the unit case is recommended for sanction of 100% Reimbursement of Quality Certification of 
                                &nbsp;<span style="font-weight: bold">
                                    <asp:Label ID="lblSTAmountPaid3QC" runat="server"></asp:Label></span>&nbsp;
                                       &nbsp;(<asp:Label ID="lblSanctionedAmtDescQC" runat="server"></asp:Label>
                                                &nbsp;Rupees only), 
                                for the
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lbl1st2nd3QC" runat="server"></asp:Label></span>&nbsp;  Half year of &nbsp;
                                &nbsp;<span style="font-weight: bold">
                                    <asp:Label ID="lblFinancialYear4QC" runat="server"></asp:Label></span>&nbsp;
                                 under &nbsp; <span style="font-weight: bold">
                                     <asp:Label ID="lblTIdeaTPride3QC" runat="server"></asp:Label></span>&nbsp; Scheme.</td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td style="text-align: center">
                                                <br />
                                                Yours faithfully,
                                <br />
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">Encl : As above.</td>
                                            <td style="text-align: center"><strong>General Manager</strong></td>
                                        </tr>
                                    </table>
                                    <table style="width: 1000px">
                                        <tr>
                                            <td colspan="2">
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="text-align: center">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr id="pcp" runat="server">
                        <td>
                            <div align="center" style="text-align: center">
                                <div align="center">
                                    <center>
                        <img src="telanganalogo.png" width="75px" height="75px" />
                    </center>
                                    <br />
                                    <asp:Label Font-Bold="true" Font-Size="X-Large" ID="Label25" runat="server">GOVERNMENT OF TELANGANA <br />DEPARTMENT OF INDUSTRIES</asp:Label>
                                    <br />
                                    <br />
                                </div>
                                <div align="center" id="Div8" runat="server">
                                    <table style="width: 1000px">
                                        <tr>
                                            <td style="vertical-align: top; width: 400px; text-align: left">From<br />
                                                The General Manager,<br />
                                                District Industries Centre,<br />
                                                <asp:Label ID="lblDistrictPCP" runat="server"></asp:Label></td>
                                            <td style="vertical-align: top; width: 400px; text-align: left">To<br />
                                                The Commissioner of Industries,<br />
                                                Government of Telangana,<br />
                                                Chirag Ali Lane, Abids,<br />
                                                Hyderabad.</td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Letter No :
                                <asp:Label ID="lblLetterNoPCP" runat="server"></asp:Label>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            Dated :
                                <asp:Label ID="lblLetterDatePCP" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Sir,</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Sub :- Application of 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEnterpreneurDetails1PCP" runat="server"></asp:Label></span>&nbsp; for Reimbursement of Cleaner Production 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblTIdeaTPride1CP" runat="server"></asp:Label></span>&nbsp; scheme - Proposal submitted – Reg.</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">Ref :-  TS-IPASS Application No. 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplicationNoPCP" runat="server"></asp:Label></span>&nbsp;,  dt: 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplnDatePCP" runat="server"></asp:Label></span>&nbsp; of the unit holder.
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp; </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">********</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left">In the reference cited, 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEnterpreneurDetails2PCP" runat="server"></asp:Label></span>&nbsp; 
                                have applied for Reimbursement of Cleaner Production under 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblTIdeaTPride2PCP" runat="server"></asp:Label></span>&nbsp; Scheme.</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left">In this connection, i submit that the unit has been inspected by the General Manager along with the Deputy Director on 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblinspecteddtPCP" runat="server"></asp:Label></span>&nbsp; and 
                                found working and engaged in the line of activity 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblloaPCP" runat="server"></asp:Label></span>.&nbsp;
                                The unit has obtained Udyog Aadhar/EM/IEM/IL/EOU No.
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lbludyogaadharnoPCP" runat="server"></asp:Label></span>&nbsp; dated: 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblUdyogAadhaardatePCP" runat="server"></asp:Label></span>&nbsp;  
                                and started commercial production w.e.f. 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblDCPPCP" runat="server"></asp:Label></span>. 
                                <%--The Commercial Tax Officer, Ladbazar circle has certified in Form-A. The unit has obtained CTO Tin No.
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblTinno" runat="server"></asp:Label></span>.--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">The eligible reimbursement of Seed Cap is calculated as under :- </td>
                                        </tr>

                                        <tr>
                                            <td colspan="2">&nbsp;<span style="font-weight: bold">&nbsp;<span style="font-weight: bold"><asp:Label ID="lbl1st2nd1PCP" runat="server"></asp:Label></span>&nbsp;  Half year of &nbsp;
                                <asp:Label ID="lblFinancialYear2PCP" runat="server"></asp:Label></span>&nbsp;</td>
                                        </tr>

                                        <tr>
                                            <td colspan="2">&nbsp; Cleaner Production Amount paid for the 
                                &nbsp;<span style="font-weight: bold">&nbsp;<span style="font-weight: bold"><asp:Label ID="lbl1st2nd2PCP" runat="server"></asp:Label></span>&nbsp;  Half year of &nbsp;
                                <asp:Label ID="lblFinancialYear3PCP" runat="server"></asp:Label></span>&nbsp;
                                 is Rs. &nbsp; <span style="font-weight: bold">
                                     <asp:Label ID="lblSTAmountPaidPCP" runat="server"></asp:Label></span>.
                                            </td>
                                        </tr>
                                        <tr id="tr8" runat="server" visible="false">
                                            <td colspan="2">&nbsp; The eligible reimbursement of Cleaner Production @ 100% = Rs. &nbsp; <span style="font-weight: bold">
                                                <asp:Label ID="lblSTAmountPaid1PCP" runat="server"></asp:Label></span>.</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left">&nbsp; Hence the unit case is recommended for sanction of 100% Reimbursement of Cleaner Production of 
                                &nbsp;<span style="font-weight: bold">
                                    <asp:Label ID="lblSTAmountPaid3PCP" runat="server"></asp:Label></span>&nbsp;
                                  &nbsp;(<asp:Label ID="lblSanctionedAmtDescPCP" runat="server"></asp:Label>
                                                &nbsp;Rupees only) for the
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="Label50" runat="server"></asp:Label></span>&nbsp;  Half year of &nbsp;
                                &nbsp;<span style="font-weight: bold">
                                    <asp:Label ID="lblFinancialYear4PCP" runat="server"></asp:Label></span>&nbsp;
                                 under &nbsp; <span style="font-weight: bold">
                                     <asp:Label ID="lblTIdeaTPride3PCP" runat="server"></asp:Label></span>&nbsp; Scheme.</td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td style="text-align: center">
                                                <br />
                                                Yours faithfully,
                                <br />
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">Encl : As above.</td>
                                            <td style="text-align: center"><strong>General Manager</strong></td>
                                        </tr>
                                    </table>
                                    <table style="width: 1000px">
                                        <tr>
                                            <td colspan="2">
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="text-align: center">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr id="trSU" runat="server">
                        <td>
                            <div align="center" style="text-align: center">
                                <div align="center">
                                    <center>
                        <img src="telanganalogo.png" width="75px" height="75px" />
                    </center>
                                    <br />
                                    <asp:Label Font-Bold="true" Font-Size="X-Large" ID="Label26" runat="server">GOVERNMENT OF TELANGANA <br />DEPARTMENT OF INDUSTRIES</asp:Label>
                                    <br />
                                    <br />
                                </div>
                                <div align="center" id="Div9" runat="server">
                                    <table style="width: 1000px">
                                        <tr>
                                            <td style="vertical-align: top; width: 400px; text-align: left">From<br />
                                                The General Manager,<br />
                                                District Industries Centre,<br />
                                                <asp:Label ID="lblDistrictSU" runat="server"></asp:Label></td>
                                            <td style="vertical-align: top; width: 400px; text-align: left">To<br />
                                                The Commissioner of Industries,<br />
                                                Government of Telangana,<br />
                                                Chirag Ali Lane, Abids,<br />
                                                Hyderabad.</td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Letter No :
                                <asp:Label ID="lblLetterNoSU" runat="server"></asp:Label>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            Dated :
                                <asp:Label ID="lblLetterDateSU" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Sir,</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Sub :- Application of 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEnterpreneurDetails1SU" runat="server"></asp:Label></span>&nbsp; for Reimbursement of Skill Upgradation 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblTIdeaTPride1SU" runat="server"></asp:Label></span>&nbsp; scheme - Proposal submitted – Reg.</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">Ref :-  TS-IPASS Application No. 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplicationNoSU" runat="server"></asp:Label></span>&nbsp;,  dt: 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplnDateSU" runat="server"></asp:Label></span>&nbsp; of the unit holder.
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp; </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">********</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left">In the reference cited, 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEnterpreneurDetails2SU" runat="server"></asp:Label></span>&nbsp; 
                                have applied for Reimbursement of Skill Upgradation under 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblTIdeaTPride2SU" runat="server"></asp:Label></span>&nbsp; Scheme.</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left">In this connection, i submit that the unit has been inspected by the General Manager along with the Deputy Director on 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblinspecteddtSU" runat="server"></asp:Label></span>&nbsp; and 
                                found working and engaged in the line of activity 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblloaSU" runat="server"></asp:Label></span>.&nbsp;
                                The unit has obtained Udyog Aadhar/EM/IEM/IL/EOU No.
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lbludyogaadharnoSU" runat="server"></asp:Label></span>&nbsp; dated: 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblUdyogAadhaardateSU" runat="server"></asp:Label></span>&nbsp;  
                                and started commercial production w.e.f. 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblDCPSU" runat="server"></asp:Label></span>. 
                                <%--The Commercial Tax Officer, Ladbazar circle has certified in Form-A. The unit has obtained CTO Tin No.
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblTinno" runat="server"></asp:Label></span>.--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left">The eligible reimbursement of Skill Upgradation is calculated as under :- </td>
                                        </tr>

                                        <tr>
                                            <td colspan="2" style="text-align: left">&nbsp;<span style="font-weight: bold">&nbsp;<span style="font-weight: bold"><asp:Label ID="lbl1st2nd1SU" runat="server"></asp:Label></span>&nbsp;  Half year of &nbsp;
                                <asp:Label ID="lblFinancialYear2SU" runat="server"></asp:Label></span>&nbsp;</td>
                                        </tr>

                                        <tr>
                                            <td colspan="2" style="text-align: left">&nbsp; As per form - A the Skill Upgradation Amount paid for the 
                                &nbsp;<span style="font-weight: bold">&nbsp;<span style="font-weight: bold"><asp:Label ID="lbl1st2nd2SU" runat="server"></asp:Label></span>&nbsp;  Half year of &nbsp;
                                <asp:Label ID="lblFinancialYear3SU" runat="server"></asp:Label></span>&nbsp;
                                 is Rs. &nbsp; <span style="font-weight: bold">
                                     <asp:Label ID="lblSTAmountPaidSU" runat="server"></asp:Label></span>.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">&nbsp; The eligible reimbursement of Skill Upgradation @ 100% = Rs. &nbsp; <span style="font-weight: bold">
                                                <asp:Label ID="lblSTAmountPaid1SU" runat="server"></asp:Label></span>.</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left">&nbsp; Hence the unit case is recommended for sanction of 100% Reimbursement of Skill Upgradation of 
                                &nbsp;<span style="font-weight: bold">
                                    <asp:Label ID="lblSTAmountPaid3SU" runat="server"></asp:Label></span>&nbsp;<br />
                                                &nbsp;(<asp:Label ID="lblSanctionedAmtDescSU" runat="server"></asp:Label>
                                                &nbsp;Rupees only), 
                                for the
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lbl1st2nd3su" runat="server"></asp:Label></span>&nbsp;  Half year of &nbsp;
                                &nbsp;<span style="font-weight: bold">
                                    <asp:Label ID="lblFinancialYear4SU" runat="server"></asp:Label></span>&nbsp;
                                 under &nbsp; <span style="font-weight: bold">
                                     <asp:Label ID="lblTIdeaTPride3SU" runat="server"></asp:Label></span>&nbsp; Scheme.</td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td style="text-align: center">
                                                <br />
                                                Yours faithfully,
                                <br />
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">Encl : As above.</td>
                                            <td style="text-align: center"><strong>General Manager</strong></td>
                                        </tr>
                                    </table>
                                    <table style="width: 1000px">
                                        <tr>
                                            <td colspan="2">
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="text-align: center">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr id="triidf" runat="server">
                        <td>
                            <div align="center" id="Div10" runat="server">
                                <table style="width: 100%" border="1">
                                    <tr>
                                        <td>
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="width: 100%" colspan="5">
                                                        <br />
                                                        <center>
                                                <img src="telanganalogo.png" width="75px" height="75px" />
                                            </center>
                                                        <br />
                                                        <center>
                                                <asp:Label Font-Bold="true" Font-Size="X-Large" ID="Label27" runat="server">GOVERNMENT OF TELANGANA <br />DEPARTMENT OF INDUSTRIES</asp:Label>
                                            </center>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 5%"></td>
                                                    <td style="vertical-align: top; text-align: left">From<br />
                                                        The General Manager,<br />
                                                        District Industries Centre,<br />
                                                        <asp:Label ID="lbldist1iidf" runat="server"></asp:Label></td>
                                                    <td style="width: 35%"></td>
                                                    <td style="vertical-align: top; text-align: left">To<br />
                                                        The Commissioner of Industries,<br />
                                                        Government of Telangana,<br />
                                                        Chirag Ali Lane, Abids,<br />
                                                        Hyderabad.</td>
                                                    <td style="width: 2%"></td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center" colspan="5"><u>Letter No :
                                            <asp:Label ID="lblLetterNoiidf" runat="server"></asp:Label>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dated :
                                            <asp:Label ID="lblLetterDateiidf" runat="server"></asp:Label></u></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 2%; text-align: right">Sir,</td>
                                                    <td style="text-align: left" colspan="3"></td>
                                                    <td style="width: 2%"></td>
                                                </tr>

                                                <tr>
                                                    <td style="width: 2%"></td>
                                                    <td colspan="3" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Sub :- Application of&nbsp;<span style="font-weight: bold"><asp:Label ID="lblEnterpreneurDetails1iidf" runat="server"></asp:Label></span>&nbsp; for Reimbursement of IIDF Fund&nbsp;<span style="font-weight: bold"><asp:Label ID="Label32" runat="server"></asp:Label></span>&nbsp; scheme - Proposal submitted – Reg.</td>
                                                    <td style="width: 2%"></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 2%"></td>
                                                    <td colspan="3" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ref :- TS-IPASS Application No.&nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplicationNoiidf" runat="server"></asp:Label></span>,  dt:&nbsp;<span style="font-weight: bold"><asp:Label ID="Label34" runat="server"></asp:Label></span>&nbsp; of the unit holder.</td>
                                                    <td style="width: 2%"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="5" style="text-align: center; height: 40px">********</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 2%"></td>
                                                    <td colspan="3" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;In the reference cited,&nbsp;<span style="font-weight: bold"><asp:Label ID="lblEnterpreneurDetails2iidf" runat="server"></asp:Label></span>&nbsp;have applied for Reimbursement of IIDF Fund under&nbsp;<span style="font-weight: bold"><asp:Label ID="Label37" runat="server"></asp:Label></span>&nbsp; Scheme.</td>
                                                    <td style="width: 2%"></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 2%"></td>
                                                    <td colspan="3" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;In this connection, i submit that the unit has been inspected by the General Manager along with the Deputy Director on 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblinspecteddtiidf" runat="server"></asp:Label></span>&nbsp; and 
                                found working and engaged in the line of activity 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblloaiidf" runat="server"></asp:Label></span>.&nbsp; The unit has obtained Udyog Aadhar/EM/IEM/IL/EOU No. <span style="font-weight: bold">
                                    <asp:Label ID="lbludyogaadharnoiidf" runat="server"></asp:Label></span>&nbsp; dated: 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblUdyogAadhaardateiidf" runat="server"></asp:Label></span>&nbsp; and started commercial production w.e.f. <span style="font-weight: bold">
                                    <asp:Label ID="lblDCPiidf" runat="server"></asp:Label></span>.</td>
                                                    <td style="width: 2%"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="5">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 2%"></td>
                                                    <td colspan="3" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The eligible reimbursement of IIDF Fund is calculated as under :- </td>
                                                    <td style="width: 2%"></td>
                                                </tr>
                                                <%--<tr id="tr1sthalf1" runat="server" visible="false">
                                        <td style="width: 2%"></td>
                                        <td colspan="3" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-weight: bold"><span style="font-weight: bold"><asp:Label ID="lbl1st2nd1" runat="server"></asp:Label></span>&nbsp;  Half year of &nbsp;
                                <asp:Label ID="lblFinancialYear2" runat="server"></asp:Label></span>.</td>
                                        <td style="width: 2%"></td>
                                    </tr>

                                    <tr  id="tr1sthalf2" runat="server" visible="false">
                                        <td style="width: 2%"></td>
                                        <td colspan="3" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IIDF Fund paid for the 
                                &nbsp;<span style="font-weight: bold">&nbsp;<span style="font-weight: bold"><asp:Label ID="lbl1st2nd2" runat="server"></asp:Label></span>&nbsp;  Half year of &nbsp;
                                <asp:Label ID="lblFinancialYear3" runat="server"></asp:Label></span>&nbsp; is Rs. <span style="font-weight: bold">
                                    <asp:Label ID="lblSTAmountPaid" runat="server"></asp:Label></span>.
                                        </td>
                                        <td style="width: 2%"></td>
                                    </tr>--%>
                                                <tr id="tr1sthalf3" runat="server" visible="false">
                                                    <td style="width: 2%"></td>
                                                    <td colspan="3" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The eligible reimbursement of IIDF Fund @ 100% = Rs. &nbsp;<span style="font-weight: bold"><asp:Label ID="lblSTAmountPaid1iidf" runat="server"></asp:Label></span>.</td>
                                                    <td style="width: 2%"></td>
                                                </tr>
                                                <%--<tr id="tr1sthalf4" runat="server" visible="false">
                                        <td style="width: 2%">&nbsp;</td>
                                        <td colspan="3" style="text-align: left">&nbsp;</td>
                                        <td style="width: 2%">&nbsp;</td>
                                    </tr>
                                    <tr id="tr2sthalf1" runat="server" visible="false">
                                        <td style="width: 2%"></td>
                                        <td colspan="3" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-weight: bold"><span style="font-weight: bold"><asp:Label ID="lbl1st2nd4" runat="server"></asp:Label></span>&nbsp;Half year of &nbsp;
                                <asp:Label ID="lblFinancialYear5" runat="server"></asp:Label></span>.</td>
                                        <td style="width: 2%"></td>
                                    </tr>
                                    <tr id="tr2sthalf2" runat="server" visible="false">
                                        <td style="width: 2%"></td>
                                        <td colspan="3" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IIDF Fund paid for the 
                                &nbsp;<span style="font-weight: bold">&nbsp;<span style="font-weight: bold"><asp:Label ID="Label4" runat="server"></asp:Label></span>&nbsp;Half year of &nbsp;<asp:Label ID="lblFinancialYear6" runat="server"></asp:Label></span>&nbsp; is Rs. <span style="font-weight: bold">
                                    <asp:Label ID="lblSTAmountPaid2" runat="server"></asp:Label></span>.
                                        </td>
                                        <td style="width: 2%"></td>
                                    </tr>
                                    <tr id="tr2sthalf3" runat="server" visible="false">
                                        <td style="width: 2%"></td>
                                        <td colspan="3" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The eligible reimbursement of IIDF Fund @ 100% = Rs. <span style="font-weight: bold">
                                            <asp:Label ID="lblSTAmountPaid4" runat="server"></asp:Label></span>.</td>
                                        <td style="width: 2%"></td>
                                    </tr>--%>
                                                <tr id="tr2sthalf4" runat="server" visible="false">
                                                    <td style="width: 2%">&nbsp;</td>
                                                    <td colspan="3" style="text-align: left">&nbsp;</td>
                                                    <td style="width: 2%">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 2%"></td>
                                                    <td colspan="3" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Hence the unit case is recommended for sanction of 100% Reimbursement of IIDF Fund of <span style="font-weight: bold">
                                                        <asp:Label ID="lblSTAmountPaid3iidf" runat="server"></asp:Label></span>&nbsp;(<asp:Label ID="lblSanctionedAmtDesciidf" runat="server"></asp:Label>
                                                        &nbsp;Rupees only).</td>
                                                    <%--for the
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lbl1st2nd3" runat="server"></asp:Label></span>&nbsp;Half year of &nbsp;<span style="font-weight: bold"><asp:Label ID="lblFinancialYear4" runat="server"></asp:Label></span>&nbsp; under <span style="font-weight: bold">
                                     <asp:Label ID="lblTIdeaTPride3" runat="server"></asp:Label></span>&nbsp;Scheme.--%>
                                                    <td style="width: 2%"></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 2%; text-align: left">&nbsp;</td>
                                                    <td colspan="3" style="text-align: left">&nbsp;</td>
                                                    <td style="width: 2%; text-align: left">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 2%; text-align: left">&nbsp;</td>
                                                    <td colspan="3" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;I
                                            <asp:Label ID="lblDICName" runat="server"></asp:Label>,
                                            &nbsp;General Manager, DIC&nbsp;<asp:Label ID="lbldist2" runat="server"></asp:Label>,&nbsp;hereby certify that the incentive application has been processed in accordance with the operational guidelines under
                                            <asp:Label ID="Tideaorpride" runat="server"></asp:Label>, if any deviation from guidelinesis foundout, i shall be held responsible for any action deemed fit.
                                                    </td>
                                                    <td style="width: 2%; text-align: left">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 2%; text-align: left">&nbsp;</td>
                                                    <td colspan="3" style="text-align: left">&nbsp;</td>
                                                    <td style="width: 2%; text-align: left">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 2%; text-align: left"></td>
                                                    <td style="text-align: center"></td>
                                                    <td style="text-align: center" colspan="3">Yours faithfully,</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 2%; text-align: left">&nbsp;</td>
                                                    <td style="text-align: center">&nbsp;</td>
                                                    <td style="text-align: center" colspan="3"><strong>
                                                        <asp:Label ID="lblGMname" runat="server"></asp:Label></strong></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 2%; text-align: left">&nbsp;</td>
                                                    <td style="text-align: left">&nbsp;Encl : As above.</td>
                                                    <td style="text-align: center" colspan="3">General Manager</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 2%; text-align: left">&nbsp;</td>
                                                    <td style="text-align: left">&nbsp;</td>
                                                    <td style="text-align: center" colspan="3"><strong>
                                                        <asp:Label ID="lbldist3" runat="server"></asp:Label></strong></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 2%; text-align: left">&nbsp;</td>
                                                    <td style="text-align: left">&nbsp;</td>
                                                    <td style="text-align: left" colspan="3">&nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width: 70%">
                                    <tr>
                                        <td colspan="2">
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="text-align: center">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>

                    <tr id="trass" runat="server">
                        <td>
                            <div align="center" style="text-align: center">
                <div align="center">
                    <center>
                        <img src="telanganalogo.png" width="75px" height="75px" />
                    </center>
                    <br />
                    <asp:Label Font-Bold="true" Font-Size="X-Large" ID="Label28" runat="server">GOVERNMENT OF TELANGANA <br />DEPARTMENT OF INDUSTRIES</asp:Label>
                    <br />
                    <br />
                </div>
                <div align="center" id="Div11" runat="server">
                    <table style="width: 1000px" border="1">
                        <tr>
                            <td style="vertical-align: top; width: 400px; text-align: left">From<br />
                                The General Manager,<br />
                                District Industries Centre,<br />
                                <asp:Label ID="lblDistrictASS" runat="server"></asp:Label></td>
                            <td style="vertical-align: top; width: 400px; text-align: left">To<br />
                                The Commissioner of Industries,<br />
                                Government of Telangana,<br />
                                Chirag Ali Lane, Abids,<br />
                                Hyderabad.</td>
                        </tr>
                        <tr>
                            <td style="text-align: left" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Letter No :
                                <asp:Label ID="lblLetterNoASS" runat="server"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            Dated :
                                <asp:Label ID="lblLetterDateASS" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2">Sir,</td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Sub :- Application of 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEnterpreneurDetails1ASS" runat="server"></asp:Label></span>&nbsp; for Reimbursement of&nbsp; Advanced Subsidy for SCST 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblTIdeaTPride1ASS" runat="server"></asp:Label></span>&nbsp; scheme - Proposal submitted – Reg.</td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">Ref :-  TS-IPASS Application No. 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplicationNoASS" runat="server"></asp:Label></span>&nbsp;,  dt: 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplnDateASS" runat="server"></asp:Label></span>&nbsp; of the unit holder.
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp; </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">********</td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">In the reference cited, 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblEnterpreneurDetails2ass" runat="server"></asp:Label></span>&nbsp; have applied for Reimbursement of Advanced Subsidy for SCST&nbsp; under 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblTIdeaTPride2ass" runat="server"></asp:Label></span>&nbsp; Scheme.</td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left">In this connection, i submit that the unit has been inspected by the General Manager along with the Deputy Director on 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblinspecteddtASS" runat="server"></asp:Label></span>&nbsp; and 
                                found working and engaged in the line of activity 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblloaASS" runat="server"></asp:Label></span>.&nbsp;
                                The unit has obtained Udyog Aadhar/EM/IEM/IL/EOU No.
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lbludyogaadharnoASS" runat="server"></asp:Label></span>&nbsp; dated: 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblUdyogAadhaardateASS" runat="server"></asp:Label></span>&nbsp;  
                                and started commercial production w.e.f. 
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblDCPASS" runat="server"></asp:Label></span>. 
                                <%--The Commercial Tax Officer, Ladbazar circle has certified in Form-A. The unit has obtained CTO Tin No.
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblTinno" runat="server"></asp:Label></span>.--%>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">The eligible reimbursement of Advanced Subsidy for SCST&nbsp; is calculated as under :- </td>
                        </tr>

                        <tr>
                            <td colspan="2">&nbsp;<span style="font-weight: bold">&nbsp;<span style="font-weight: bold"><asp:Label ID="lbl1st2nd1ASS" runat="server"></asp:Label></span>&nbsp;  Half year of &nbsp;
                                <asp:Label ID="lblFinancialYear2ASS" runat="server"></asp:Label></span>&nbsp;</td>
                        </tr>

                        <tr>
                            <td colspan="2">&nbsp; As per form - A the Advanced Subsidy for SC ST Paid for the 
                                &nbsp;<span style="font-weight: bold">&nbsp;<span style="font-weight: bold"><asp:Label ID="lbl1st2nd2ASS" runat="server"></asp:Label></span>&nbsp;  Half year of &nbsp;
                                <asp:Label ID="lblFinancialYear3ASS" runat="server"></asp:Label></span>&nbsp;
                                 is Rs. &nbsp; <span style="font-weight: bold">
                                     <asp:Label ID="lblSTAmountPaidASS" runat="server"></asp:Label></span>.
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp; The eligible reimbursement of Advanced Subsidy for SCST&nbsp; @ 100% = Rs. &nbsp; <span style="font-weight: bold">
                                <asp:Label ID="lblSTAmountPaid1ASS" runat="server"></asp:Label></span>.</td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left">&nbsp; Hence the unit case is recommended for sanction of 100% Reimbursement of Advanced Subsidy for SCST of 
                                &nbsp;<span style="font-weight: bold">
                                    <asp:Label ID="lblSTAmountPaid3ASS" runat="server"></asp:Label></span>&nbsp;
                                <br />
                                &nbsp;(<asp:Label ID="lblSanctionedAmtDescASS" runat="server"></asp:Label>
                                &nbsp;Rupees only), for the
                                &nbsp;<span style="font-weight: bold"><asp:Label ID="lblFinancialYear4ASS" runat="server"></asp:Label></span>&nbsp;  Half year of &nbsp;
                                &nbsp;<span style="font-weight: bold">
                                    <asp:Label ID="lblTIdeaTPride3ASS" runat="server"></asp:Label></span>&nbsp;
                                 under &nbsp; <span style="font-weight: bold">
                                     <asp:Label ID="Label59" runat="server"></asp:Label></span>&nbsp; Scheme.</td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="text-align: center">
                                <br />
                                Yours faithfully,
                                <br />
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">Encl : As above.</td>
                            <td style="text-align: center"><strong>General Manager</strong></td>
                        </tr>
                    </table>
                    <table style="width: 1000px" border="1">
                        <tr>
                            <td colspan="2">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="text-align: center">
                                <asp:Button ID="Button12" runat="server" Height="32px" Width="90px" CssClass="btn btn-warning" Text=" Print " OnClientClick="javascript:CallPrint('Receipt')" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
                        </td>
                    </tr>
                </table>
            </div>
    </form>
</body>
</html>
