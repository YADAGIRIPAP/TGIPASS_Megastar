<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TSipassfeedbackPostAppln.aspx.cs" Inherits="UI_TSiPASS_TSipassfeedbackPostAppln" %>

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
                    <img src="telanganalogo.png" width="75px" height="65px" />
                </td>
            </tr>
            <tr style="padding: 0px; margin: 0px; border: 1px solid #000000; font-family: Verdana; font-size: 18px;">
                <td align="center" style="text-align: center; font-family: Verdana; font-weight: bold; font-size: 18px; border: 1px solid #000000;" class="auto-style1">TS-iPASS FEEDBACK FORM</td>
            </tr>
            <tr>
                <td align="center" class="auto-style1">
                    <table bgcolor="White" width="900" border="2px" cellpadding="22"
                        style="font-family: Verdana; font-size: 14px;">

                        <tr style="background-color: #6699FF">
                            <td colspan="2" style="padding: 5px; margin: 5px" valign="top"><b><span>Post Application Form Filling</span></b></td>

                        </tr>
                        <tr>
                            <td colspan="2">
                                <table>
                                    <tr>
                                        <td colspan="2" style="padding: 5px; margin: 5px" valign="top" align="left"><b>1. Rate the overall quality of your experience using the system</b> </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top" colspan="2" align="left">
                                            <asp:RadioButtonList ID="rblOverallquality" runat="server" Height="60px" Width="720px" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="1" Text="Poor"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Fair"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Good"></asp:ListItem>
                                                <asp:ListItem Value="4" Text="Very Good"></asp:ListItem>
                                                <asp:ListItem Value="5" Text="Excellent"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="left" colspan="2">Issues Faced and Recommendations :  </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: left" align="left">
                                            <asp:TextBox ID="txtOverallQltyIssuesFaced" runat="server" Width="500px" Height="50px" TextMode="MultiLine"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table>
                                    <tr>
                                        <td colspan="2" align="left"><b>2.  Rate the information (Procedure, documents, fees or charges applicable for availing the service) on this website</b> </td>
                                    </tr>
                                    <tr>                                        
                                        <td colspan="2" align="left"><br /><b>a.	Ease of finding information</b></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left">
                                            <asp:RadioButtonList ID="rblEasefindInfo" runat="server" Height="60px" Width="720px" RepeatDirection="Vertical">
                                                <asp:ListItem Value="1" Text="Not available"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Had to reach out for assistance"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Information available but difficult to navigate"></asp:ListItem>
                                                <asp:ListItem Value="4" Text="Easily available"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td colspan="2" align="left"><b>b.	Quality and Completeness of the information</b></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:RadioButtonList ID="rblQltyCompInfo" runat="server" Height="60px" Width="720px" RepeatDirection="Vertical">
                                                <asp:ListItem Value="1" Text="Not available"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Had to reach out for clarification and assistance"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Information available but difficult to understand"></asp:ListItem>
                                                <asp:ListItem Value="4" Text="Easily understandable and complete"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left">Issues Faced and Recommendations :  </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left">
                                            <asp:TextBox ID="txtRateInformationIssuesFaced" runat="server" MaxLength="2000" Width="500px" Height="50px" TextMode="MultiLine"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                <table>
                                    <tr>
                                        <td colspan="2" align="left"><b>3. If you have sought any clarification or support needed for online filing of the application, was such support provided through the help desk or other means sufficient?</b>
                                            <br />
                                            <br />
                                            <asp:RadioButtonList ID="rblIsclarificationsSufficient" runat="server" Height="60px" Width="720px" RepeatDirection="Vertical">
                                                <asp:ListItem Value="1" Text="Help desk or other means of support was adequate for online application submission"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Help desk or other means of support was inadequate for online application submission"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="No help desk or other support was available to enable in online application submission"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left">Issues Faced and Recommendations :  </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtIsclarificationsSufficientissues" runat="server" MaxLength="2000" Width="500px" Height="50px" TextMode="MultiLine"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                <table>
                                    <tr>
                                        <td align="left" colspan="2"><b>4. Are you aware of the timelines within which the department has to fulfill this service <br /> </b>
                                            <br />
                                            <asp:RadioButtonList ID="rblTimeLines" runat="server" Height="60px" Width="720px" RepeatDirection="Vertical">
                                                <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="2">Issues Faced and Recommendations :  </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left">
                                            <asp:TextBox ID="txtTimeLinesIssuesFaced" runat="server" MaxLength="2000" Width="500px" Height="50px" TextMode="MultiLine"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                <table>
                                    <tr>
                                        <td colspan="2" align="left"><b>5.	Were you able to submit the entire application online, including payment and uploading of documents <br /></b>
                                            <br />
                                            <asp:RadioButtonList ID="rblApplnpymnt" runat="server" Height="60px" Width="720px" RepeatDirection="Vertical">
                                                <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left">Issues Faced and Recommendations :  </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left">
                                            <asp:TextBox ID="txtApplnpymntIssuesfcaed" runat="server" MaxLength="2000" Width="500px" Height="50px" TextMode="MultiLine"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                <table>
                                    <tr>
                                        <td colspan="2" align="left"><b>6.	Are you aware of the TS-iPASS Act, its provisions and rights conferred to industries / business <br /></b>
                                            <br />
                                            <asp:RadioButtonList ID="rblAwareTsipassAct" runat="server" Height="60px" Width="720px" RepeatDirection="Vertical">
                                                <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left">Issues Faced and Recommendations :  </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left">
                                            <asp:TextBox ID="txtTsipassActIssuesFaced" runat="server" MaxLength="2000" Width="500px" Height="50px" TextMode="MultiLine"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                <table>
                                    <tr>
                                        <td colspan="2" align="left"><b>7.	Are you aware of the TS-iPASS online single window system and its services <br /> </b>
                                            <br />
                                            <asp:RadioButtonList ID="rblAwareSingleWindow" runat="server" Height="60px" Width="720px" RepeatDirection="Vertical">
                                                <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left">Issues Faced and Recommendations :  </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left">
                                            <asp:TextBox ID="txtrblAwareSingleWindowIssuesFaced" runat="server" MaxLength="2000" Width="500px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                                            <br />
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
                                <asp:Button ID="btnSubmit" runat="server" Height="40px" Text="Submit"  Width="120px" OnClick="btnSubmit_Click"></asp:Button>
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
