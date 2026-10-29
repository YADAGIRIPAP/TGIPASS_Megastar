<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IpassFeedBackFormCFO.aspx.cs" Inherits="UI_TSiPASS_IpassFeedBackFormCFO" %>

<!DOCTYPE html>

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

        a {
            color: #337ab7;
            text-decoration: none;
        }

        a {
            background-color: transparent;
        }

        .auto-style1 {
            width: 1317px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function DisableBackButton() {
            window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }
    </script>


</head>
<body>
    <form id="form1" runat="server">
        <table align="center"
            style="border: 1px solid #000000; font-family: Verdana; font-size: 12px; text-align: center; width: 800px;">
            <tr>
                <td align="center" style="padding: 0px; margin: 0px; text-align: center" class="auto-style1">
                    <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/telanganalogo.png" width="75px" height="65px" />
                </td>
            </tr>
            <tr style="padding: 0px; margin: 0px; border: 1px solid #000000; font-family: Verdana; font-size: 18px;">
                <td align="center" style="text-align: center; font-family: Verdana; font-weight: bold; font-size: 18px; border: 1px solid #000000;" class="auto-style1">TS-iPASS FEEDBACK FORM</td>
            </tr>
            <tr>
                <td align="center" class="auto-style1">
                    <table bgcolor="White" width="900" border="2px" cellpadding="22"
                        style="font-family: Verdana; font-size: 14px;">

                        <%--<tr style="background-color: #6699FF">
                            <td colspan="2" style="padding: 5px; margin: 5px" valign="top"><b><span>Short Survey</span></b></td>

                        </tr>--%>


                        <tr>
                            <td colspan="2">
                                <table>
                                    <tr id="tr1" runat="server">
                                        <td style="margin: 5px; font-weight: bold; width:10px" valign="top" >1. </td>
                                        <td align="left"><b>Are you aware of the TS-iPASS Act, its provisions and rights conferred to industries / business and it has been setup to operate as a single point contact for industries / business and an end to end online system has been developed for filing of common application form, payment of all required departments fee and download of approval/clearances ?</b><br />
                                            <br />
                                            <asp:RadioButtonList ID="rdb1" runat="server" Width="207px" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr  id="tr2" runat="server">
                                        <td style="margin: 5px; font-weight: bold;" valign="top">2. </td>
                                        <td align="left"><b>Are you aware that a Common Application Form (CAF) combining applications of all services has been developed as part of TS-iPASS portal ?<br />
                                        </b>
                                            <br />
                                            <asp:RadioButtonList ID="rdb2" runat="server" Width="207px" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                   <%-- <tr>
                                        <td style="margin: 5px; font-weight: bold;" valign="top">4</td>
                                        <td align="left"><b>Are you aware that a Common Application Form (CAF) combining applications of all services has been developed as part of TS-iPASS portal<br />
                                        </b>
                                            <br />
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">a</td>
                                                    <td>Consent to Establish (under Water Act & Air Act)</td>
                                                    <td>
                                                        <asp:RadioButtonList ID="tdb4a" runat="server" Width="207px" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                            <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                        </asp:RadioButtonList></td>
                                                </tr>
                                                 <tr>
                                                    <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">b</td>
                                                    <td>Consent to Operate (under Water Act & Air Act & Hazardous Waste Rules)</td>
                                                    <td>
                                                        <asp:RadioButtonList ID="tdb4b" runat="server" Width="207px" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                            <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                        </asp:RadioButtonList></td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">c&nbsp;</td>
                                                    <td>Registration under Shops and Establishments Act</td>
                                                    <td>
                                                        <asp:RadioButtonList ID="tdb4c" runat="server" Width="207px" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                            <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                        </asp:RadioButtonList></td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">d</td>
                                                    <td>Permission for engaging contractor for labour</td>
                                                    <td>
                                                        <asp:RadioButtonList ID="tdb4d" runat="server" Width="207px" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                            <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                        </asp:RadioButtonList></td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">e</td>
                                                    <td>Factory building plan approval</td>
                                                    <td>
                                                        <asp:RadioButtonList ID="tdb4e" runat="server" Width="207px" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                            <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                        </asp:RadioButtonList></td>
                                                </tr>
                                                 <tr>
                                                    <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">f</td>
                                                    <td>Factories License</td>
                                                    <td>
                                                        <asp:RadioButtonList ID="tdb4f" runat="server" Width="207px" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                            <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                        </asp:RadioButtonList></td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">g</td>
                                                    <td>Registration under Boiler Act</td>
                                                    <td>
                                                        <asp:RadioButtonList ID="tdb4g" runat="server" Width="207px" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                            <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                        </asp:RadioButtonList></td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">h</td>
                                                    <td>Renewal of Consent to operate (under Water Act & Air Act)</td>
                                                    <td>
                                                        <asp:RadioButtonList ID="tdb4h" runat="server" Width="207px" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                            <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                        </asp:RadioButtonList></td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">i</td>
                                                    <td>Renewal of Factories License</td>
                                                    <td>
                                                        <asp:RadioButtonList ID="tdb4i" runat="server" Width="207px" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                            <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                        </asp:RadioButtonList></td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">j</td>
                                                    <td>Renewal of Registration under Boiler Act</td>
                                                    <td>
                                                        <asp:RadioButtonList ID="tdb4j" runat="server" Width="207px" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                            <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                        </asp:RadioButtonList></td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">k</td>
                                                    <td>Electricity Connection</td>
                                                    <td>
                                                        <asp:RadioButtonList ID="tdb4k" runat="server" Width="207px" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                            <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                        </asp:RadioButtonList></td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">l</td>
                                                    <td>Water Connection</td>
                                                    <td>
                                                        <asp:RadioButtonList ID="tdb4l" runat="server" Width="207px" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                            <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                        </asp:RadioButtonList></td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">m</td>
                                                    <td>Incentives Intent Letter, Sanction Letter and Disbursement</td>
                                                    <td>
                                                        <asp:RadioButtonList ID="tdb4m" runat="server" Width="207px" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                            <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                        </asp:RadioButtonList></td>
                                                </tr>  
                                            </table>
                                        </td>
                                    </tr>--%>
                                    <tr  id="tr3" runat="server">
                                        <td style="margin: 5px; font-weight: bold;" valign="top">3. </td>
                                        <td align="left"><b>Were you able to find the required information related to procedures, documents checklist applicable for availing the service on the website is complete and easily understandable ?<br />
                                        </b>
                                            <br />
                                            <asp:RadioButtonList ID="rdb3" runat="server" Width="207px" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr  id="tr4" runat="server">
                                        <td style="margin: 5px; font-weight: bold;" valign="top">4. </td>
                                        <td align="left"><b>Are you aware of the timelines within which the departments have to issue approvals ?<br />
                                        </b>
                                            <br />
                                            <asp:RadioButtonList ID="rdb4" runat="server" Width="207px" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr  id="tr5" runat="server">
                                        <td style="margin: 5px; font-weight: bold;" valign="top">5. </td>
                                        <td align="left"><b>Were you able to submit the entire application online, including payment and uploading of documents ?<br />
                                        </b>
                                            <br />
                                            <asp:RadioButtonList ID="rdb5" runat="server" Width="207px" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr  id="tr6" runat="server">
                                        <td style="margin: 5px; font-weight: bold;" valign="top" id="td6" runat="server">6.</td>
                                        <td align="left"><b>Were you given the license / approval / certificate / renewal within the stipulated timelines and were you able to download the final approval certificate throgh online system ?<br />
                                        </b>
                                            <br />
                                            <asp:RadioButtonList ID="rdb6" runat="server" Width="207px" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr  id="tr7" runat="server">
                                        <td style="margin: 5px; font-weight: bold;" valign="top" id="td7" runat="server">7.</td>
                                        <td align="left"><b>Were you able to track the status of your application through the website ?<br />
                                        </b>
                                            <br />
                                            <asp:RadioButtonList ID="rdb7" runat="server" Width="207px" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr  id="tr8" runat="server">
                                        <td style="margin: 5px; font-weight: bold;" valign="top" id="td8" runat="server">8.</td>
                                        <td align="left"><b>Were you asked for any offline information or documentsfor application processing ?<br />
                                        </b>
                                            <br />
                                            <asp:RadioButtonList ID="rdb8" runat="server" Width="207px" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr  id="tr9" runat="server">
                                        <td style="margin: 5px; font-weight: bold;" valign="top" id="td9" runat="server">9.</td>
                                        <td align="left"><b>Was the inspection of you premises conducted on the scheduled date, if so has the inspection conducted as per the checklist shared* ?<br />
                                        </b>
                                            <br />
                                            <asp:RadioButtonList ID="rdb9" runat="server" Width="207px" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                <asp:ListItem Value="A" Text="NA"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr id="trinspection" runat="server">
                                        <td style="margin: 5px; font-weight: bold;" colspan="2" align="left">
                                            * For the services which require inspection
                                        </td>
                                    </tr>
                                    <tr  id="tr10" runat="server">
                                        <td style="margin: 5px; font-weight: bold;" valign="top" id="td10" runat="server">10. </td>
                                        <td align="left"><b>Were you satisfied with the overall quality of the TS-iPASS system ?<br />
                                        </b>
                                            <br />
                                            <asp:RadioButtonList ID="rdb10" runat="server" Width="207px" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <table style="text-align: center">
                        <tr>
                            <td colspan="2" style="text-align: center" class="auto-style1" align="center">
                                <asp:Button ID="btnSubmit" runat="server" Height="40px" Text="Submit" Width="120px" OnClick="btnSubmit_Click"></asp:Button>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnclear" runat="server" Height="40px" Text="Clear" Width="120px" OnClick="btnclear_Click"></asp:Button>

                            </td>
                        </tr>
                    </table>
                </td>
            </tr>

            <%--<tr>
                <td align="center" class="style2" style="text-align: center">
                    <input id="btnPrint" onclick="window.print()" style="border-right: thin solid; border-top: thin solid; border-left: thin solid; border-bottom: thin solid"
                        type="button" value="Print" />
                </td>
            </tr>--%>
        </table>
    </form>
</body>
</html>
