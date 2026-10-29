<%@ Page Title="" Language="VB" MasterPageFile="~/DealerMstInner.master" AutoEventWireup="false"
    CodeFile="CompleteRegInfo.aspx.vb" Inherits="CompleteRegInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript">

        function printSelection() {

            document.getElementById('<%=ImageButton2.ClientID%>').style.visibility = "hidden";
            document.getElementById('<%=ImageButton1.ClientID%>').style.visibility = "hidden";

            var content = document.getElementById("ContentPlaceHolder1_divPrnt").innerHTML;
            var pwin = window.open('', 'print_content', 'width=100');

            pwin.document.open();
            pwin.document.write('<html><head><link rel="stylesheet" type="text/css" media="print" href="../../App_Themes/PortalTheme/CommonPrint.css" /><link rel="stylesheet" type="text/css" media="print" href="../../css/print.css" /></head><body onload="window.print()">' + content + '</body></html>');
            pwin.document.close();

            setTimeout(function () { pwin.close(); }, 1000);

            document.getElementById('<%=ImageButton2.ClientID%>').style.visibility = "visible";
            document.getElementById('<%=ImageButton1.ClientID%>').style.visibility = "visible";

        }
     
    </script>
    <div id="divPrnt" runat="server" style="margin: auto; overflow: auto">
        <div style="width: 940px; margin: auto;">
            <table width="900" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="DivTitle">
                        Complete Registration Summary
                    </td>
                </tr>
            </table>
            <asp:ImageButton ID="ImageButton2" runat="server" OnClientClick="printSelection();"
                ImageUrl="../../images/printer.jpg" Style="float: right" />
            <fieldset class="step">
                <legend>Registration Details</legend>
                <table width="900" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <table width="900" border="0" align="center" cellpadding="8" cellspacing="0">
                                <tr>
                                    <td width="120" align="right" class="formText">
                                        RNR
                                    </td>
                                    <td width="140" align="left" class="RegistrationTxt">
                                        <asp:Label ID="LblRnr" runat="server" class="RegistrationTxt" CssClass="formTextBold"></asp:Label>
                                    </td>
                                    <td align="right" class="formText">
                                        TIN
                                    </td>
                                    <td align="left" class="RegistrationTxt">
                                        <asp:Label ID="LblTIN" runat="server" CssClass="formTextBold"></asp:Label>
                                    </td>
                                    <td width="100" align="left" class="formText">
                                        Application&nbsp;Date
                                    </td>
                                    <td align="left" class="RegistrationTxt">
                                        <asp:Label ID="LblAppDt" runat="server" CssClass="formTextBold"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="formText">
                                        Registration&nbsp;Type/Act
                                    </td>
                                    <td align="left" class="RegistrationTxt">
                                        <asp:Label ID="LblRegType" runat="server" CssClass="formTextBold"></asp:Label>
                                        /<asp:Label ID="LblAct" runat="server" CssClass="formTextBold"></asp:Label>
                                    </td>
                                    <td width="140" align="right" class="formText">
                                        CST
                                    </td>
                                    <td width="140" align="left" class="RegistrationTxt">
                                        <asp:Label ID="LblCst" runat="server" CssClass="formTextBold"></asp:Label>
                                    </td>
                                    <td align="left" class="formText">
                                        Data&nbsp;Entry&nbsp;Date
                                    </td>
                                    <td align="left" class="RegistrationTxt">
                                        <asp:Label ID="LblEntryDt" runat="server" CssClass="formTextBold"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="formText">
                                        CT&nbsp;Division
                                    </td>
                                    <td align="left" class="RegistrationTxt">
                                        <asp:Label ID="LblDivision" runat="server" CssClass="formTextBold"></asp:Label>
                                    </td>
                                    <td align="right" class="formText">
                                        CT&nbsp;Circle
                                    </td>
                                    <td align="left" class="RegistrationTxt">
                                        <asp:Label ID="LblCircle" runat="server" CssClass="formTextBold"></asp:Label>
                                    </td>
                                    <td align="right" class="formText">
                                        First Tax Period
                                    </td>
                                    <td align="left" class="RegistrationTxt">
                                        <asp:Label ID="LblFirstTaxDt" runat="server" CssClass="formTextBold"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <fieldset class="fieldSet2">
                                <legend>Enterprise Details</legend>
                                <table width="860" border="0" align="center" cellpadding="6" cellspacing="0">
                                    <tr>
                                        <td width="200" align="right" valign="top" class="formText">
                                            Name
                                        </td>
                                        <td align="left" class="RegistrationTxt">
                                            <asp:Label ID="LblEName" runat="server" CssClass="formTextBold"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top" class="formText">
                                            Address
                                        </td>
                                        <td align="left" class="RegistrationTxt">
                                            <asp:Label ID="LblEAddress" runat="server" CssClass="formTextBold"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="860" border="0" align="center" cellpadding="6" cellspacing="0">
                                <tr>
                                    <td width="204" align="right" valign="top" class="formText">
                                        Enterprise Occupancy Status
                                    </td>
                                    <td align="left" class="RegistrationTxt">
                                        <asp:Label ID="LblEoccStatus" runat="server" CssClass="formTextBold"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="top" class="formText">
                                        Estimated Total Turnover Sales in<br />
                                        First 12 Months
                                    </td>
                                    <td align="left" class="RegistrationTxt">
                                        <asp:Label ID="LblETurnOver" runat="server" CssClass="formTextBold"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <fieldset class="fieldSet2">
                                <legend>Owner Details </legend>
                                <table width="860" border="0" align="center" cellpadding="6" cellspacing="0">
                                    <tr>
                                        <td width="200" align="right" valign="top" class="formText">
                                            Owner Name
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="LblOname" runat="server" CssClass="formTextBold"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top" class="formText">
                                            UID
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="LblOUid" runat="server" CssClass="formTextBold"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top" class="formText">
                                            Father Name
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="LblOFatherName" runat="server" CssClass="formTextBold"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top" class="formText">
                                            Owner Address
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="LblOAddress" runat="server" CssClass="formTextBold"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="860" border="0" align="center" cellpadding="6" cellspacing="0">
                                <tr>
                                    <td width="204" align="right" valign="top" class="formText">
                                        Status Of Business
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="LblOBusinessStatus" runat="server" CssClass="formTextBold"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="top" class="formText">
                                        Principal Business Activity
                                    </td>
                                    <td align="left" class="RegistrationTxt">
                                        <asp:GridView ID="grdPBusinessActy" GridLines="None" runat="server" Width="100%"
                                            AutoGenerateColumns="False" ShowHeader="false" SkinID="Go" CssClass="formTextBold">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblPrplBusiness" runat="server" Text='<%# Eval("activity")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="top" class="formText">
                                        Principal Commodities
                                    </td>
                                    <td align="left" class="RegistrationTxt">
                                        <asp:GridView ID="grdPrincipalCommd" runat="server" Width="100%" AutoGenerateColumns="False"
                                            ShowHeader="false" GridLines="None" SkinID="Go" CssClass="formTextBold">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblPrplBusiness" runat="server" Text='<%# Eval("commodity")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <fieldset class="fieldSet2">
                                <legend>Bank Details </legend>
                                <table width="860" border="0" align="center" cellpadding="6" cellspacing="0">
                                    <tr>
                                        <td width="200" align="right" valign="top" class="formText">
                                            Bank Name
                                        </td>
                                        <td align="left" class="RegistrationTxt">
                                            <asp:Label ID="LblBankName" runat="server" CssClass="formTextBold"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top" class="formText">
                                            Account Number
                                        </td>
                                        <td align="left" class="RegistrationTxt">
                                            <asp:Label ID="LblBankAcctNo" runat="server" CssClass="formTextBold"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top" class="formText">
                                            IFSC Code
                                        </td>
                                        <td align="left" class="RegistrationTxt">
                                            <asp:Label ID="LblBankBranchCd" runat="server" CssClass="formTextBold"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top" class="formText">
                                            Branch Address
                                        </td>
                                        <td align="left" class="RegistrationTxt">
                                            <asp:Label ID="LblBankBranchAdd" runat="server" CssClass="formTextBold"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="860" border="0" align="center" cellpadding="6" cellspacing="0">
                                <tr>
                                    <td width="204" align="right" valign="top" class="formText">
                                        PAN
                                    </td>
                                    <td align="left" class="RegistrationTxt">
                                        <asp:Label ID="LblPanNo" runat="server" CssClass="formTextBold"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="top" class="formText">
                                        Profession Tax Number
                                    </td>
                                    <td align="left" class="RegistrationTxt">
                                        <asp:Label ID="LblPtaxNo" runat="server" CssClass="formTextBold"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="top" class="formText">
                                        PhoneNumber
                                    </td>
                                    <td align="left" class="RegistrationTxt">
                                        <asp:Label ID="LblPhNo" runat="server" CssClass="formTextBold"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="top" class="formText">
                                        MobileNumber
                                    </td>
                                    <td align="left" class="RegistrationTxt">
                                        <asp:Label ID="LblMobileNo" runat="server" CssClass="formTextBold"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="top" class="formText">
                                        Email
                                    </td>
                                    <td align="left" class="RegistrationTxt">
                                        <asp:Label ID="LblEmail" runat="server" CssClass="formTextBold"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="top" class="formText">
                                        Accounts Computerized
                                    </td>
                                    <td align="left" class="RegistrationTxt">
                                        <asp:Label ID="LblPAcctComp" runat="server" CssClass="formTextBold"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <fieldset class="fieldSet2" runat="server" id="AddBus">
                                <legend>Business Details </legend>
                                <table width="860" border="0" align="center" cellpadding="6" cellspacing="1">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="grdCompBusinessDtls" runat="server" Width="830px" AutoGenerateColumns="False"
                                                GridLines="None" SkinID="Go">
                                                <Columns>
                                                    <asp:BoundField DataField="serial_no" HeaderText="S.No" />
                                                    <asp:BoundField DataField="Address" HeaderText="Address" />
                                                    <asp:BoundField DataField="type" HeaderText="Type" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px;">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <fieldset class="fieldSet2" runat="server" id="Partners">
                                <legend>Partners Details </legend>
                                <table width="860" border="0" align="center" cellpadding="6" cellspacing="1">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="grdCompPartnerDtls" runat="server" Width="830px" AutoGenerateColumns="False"
                                                GridLines="None" SkinID="Go">
                                                <Columns>
                                                    <asp:BoundField DataField="serial_no" HeaderText="S.No" />
                                                    <asp:BoundField DataField="name" HeaderText="Name" />
                                                    <asp:BoundField DataField="uid" HeaderText="Uid" />
                                                    <asp:BoundField DataField="father_name" HeaderText="Father Name" />
                                                    <asp:BoundField DataField="Paddress" HeaderText="Address" />
                                                    <asp:BoundField DataField="email_id" HeaderText="Email Address" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px;">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <fieldset class="fieldSet2" runat="server" id="Fieldset1">
                                <legend>Document Checklist Details </legend>
                                <table width="860" border="0" align="center" cellpadding="6" cellspacing="1">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="grdChecklist" runat="server" Width="830px" AutoGenerateColumns="False"
                                                GridLines="None" SkinID="Go" EmptyDataText="Since you are a Proprietory concern and are dealing in Sensitive commodities,
                                    you are advised to submit all supporting documents together with a signed copy of the application
                                    physically before the concerned registering authority." >
                                                
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkSelect" runat="server" Checked="true" Enabled="false" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="checklist_name" HeaderText="" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            &nbsp;<asp:Button ID="ButEdit" runat="server" Text="Edit" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="ButSub" runat="server" Text="Submit" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="ImageButton1" runat="server" OnClientClick="printSelection();"
                                ImageUrl="../../images/printer.jpg" />
                        </td>
                    </tr>
                </table>
                <br />
            </fieldset>
        </div>
    </div>
</asp:Content>
