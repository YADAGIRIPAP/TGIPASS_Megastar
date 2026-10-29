<%@ page language="C#" masterpagefile="CCMaster.master" autoeventwireup="true" codefile="HomeDeptDashboard.aspx.cs"
    inherits="Default3" title=":: TS-iPass Govenrnment of Telengana :: Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript">



        function OpenPopup() {

            window.open("Lookups/frmcjfslookup.aspx", "List", "scrollbars=yes,resizable=yes,width=550,height=320");

            return false;
        }



        function Names() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue == 46) || (AsciiValue == 32))
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter Alphabets, '.' and Space Only");
            }
        }

        function DecimalOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127) || AsciiValue == 46)
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter DecimalValues Only");
            }
        }


        function AlphaNumericOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue >= 48 && AsciiValue <= 57))
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter Alphabets,  and Characters  Only");
            }
        }

    </script>
    <style type="text/css">
        .copyright {
            clear: both;
            width: 100%;
            margin: 0px auto;
            padding: 0px;
            display: block;
            font-size: 12px;
            text-align: center;
        }

        .container {
            width: 1170px;
            margin: 0 auto;
        }

        .col-1 {
            float: left;
            text-align: left;
            width: 50%;
            color: #fff;
        }

        .col-2 {
            float: right;
            text-align: right;
            width: 50%;
            color: #fff;
        }

        @keyframes blink {
            25% {
                opacity: 0.0;
            }

            50% {
                opacity: 1.0;
            }

            75% {
                opacity: 0.0
            }

            100% {
                opacity: 1.0;
            }
        }

        @-webkit-keyframes blink {
            50% {
                opacity: 1.0;
            }

            75% {
                opacity: 0.0
            }

            100% {
                opacity: 1.0;
            }
        }

        .blink12 {
            animation: blink 2s step-start 0s infinite;
            -webkit-animation: blink 2s step-start 0s infinite;
            color: Yellow;
            font-weight: bold;
            font-size: 14px;
        }

        .blink13 {
            animation: blink 5s step-start 0s infinite;
            -webkit-animation: blink 5s step-start 0s infinite;
            color: Red;
            font-weight: bold;
            font-size: 14px;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $('input[id$=txtration1]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('input[id$=txtration2]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('input[id$=txtsurveynum]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('input[id$=txtExtent]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('input[id$=txtCJFSBeneficiery]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });


    </script>
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr runat="server" id="maintr">
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <table style="width: 100%" cellpadding="10" cellspacing="10">
                    <tr>
                        <td style="height: 30px">
                            <asp:Label ID="Label437" runat="server" CssClass="LBLBLACK" Font-Bold="True" Font-Names="Verdana"
                                Width="210px">Department Dashboard</asp:Label>
                        </td>
                        <td style="height: 30px"></td>
                        <td style="height: 30px"></td>
                    </tr>
                    <tr id="trgm" runat="server" visible="false" style="color: #ff4615;" class="blink12">
                        <td>
                            <div>
                                <span style="font-weight: bold">Note : The release proceedings are issued for the SCP
                                    and TSP on dt: 09.10.2020
                                    <br />
                                    <br />
                                    Vide release proceeding No: 39/1/2020/63428 dt: 09.10.2020 <a href="https://ipass.telangana.gov.in/GoCOIIncentiveAttachments/23/SCP%20Scan%20Proceedings%202020.pdf"
                                        target="_blank">Click here </a>
                                    <br />
                                    <br />
                                    Vide release proceeding No : 39/2/2020/63442 dt: 09.10.2020 <a href="https://ipass.telangana.gov.in/GoCOIIncentiveAttachments/35/TSP%20PROCEDDINGS%2009102020.pdf"
                                        target="_blank">Click here </a>
                                    <br />
                                    <br />
                                    The GM, DIC was requested to guide the applicant to upload the required documents
                                    on the portal within 21 days from the day of issue of the release proceedings. However,
                                    it is observed that many applicants are not uploaded the required documents. GM's
                                    are once again requested to guide the applicants to upload the documents on portal
                                    by dated: 13/11/2020, failing which the amount released to such units will be allocated
                                    to other units as per seriatim. </span>
                                <br />
                                <br />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">&nbsp;
                        </td>
                        <td align="center" style="text-align: center">&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">
                            <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="91px"
                                OnClick="BtnSave1_Click" TabIndex="10" Text="CFE DASHBOARD" ValidationGroup="group"
                                Width="268px" Font-Bold="True" Font-Names="Verdana" Font-Size="18px" />
                        </td>
                        <td align="center" style="text-align: center">
                            <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-danger" Height="91px"
                                OnClick="BtnDelete_Click" TabIndex="10" Text="CFO DASHBOARD" Font-Bold="True"
                                Width="268px" ValidationGroup="group" Font-Names="Verdana" Font-Size="18px" />
                            <asp:LinkButton runat="server" visible="false" CssClass="btn btn-success" OnClick="lnkCommenced_Click"
                                style="text-align: center; align-items: center; justify-content: center; display: inline-flex"
                                ID="lnkCommenced" Width="268px" Height="91px" Font-Size="18px" Font-Bold="True">
                                COMMENCED
                                <br />
                                UNITS LIST
                            </asp:LinkButton>
                        </td>
                        <td align="center" style="text-align: center">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">&nbsp;
                        </td>
                        <td align="center" style="text-align: center">&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">
                            <asp:Button ID="Button1" runat="server" CssClass="btn btn-warning" Height="91px"
                                TabIndex="10" Text="GRIEVANCE" ValidationGroup="group" Width="268px" Font-Bold="True"
                                Font-Names="Verdana" Font-Size="18px" OnClick="Button1_Click" />
                        </td>
                        <td align="center" style="text-align: center">
                            <asp:Button ID="Button2" runat="server" CssClass="btn btn-info" Height="91px" TabIndex="10"
                                Text="INSPECTION" ValidationGroup="group" Width="268px" Font-Bold="True" Font-Names="Verdana"
                                Font-Size="18px" />
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">&nbsp;
                        </td>
                        <td align="center" style="text-align: center">&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr id="trPLOT" runat="server" visible="true">
                        <td align="center" style="text-align: center">
                            <asp:Button ID="btnplot" runat="server" CssClass="btn btn-primary" Height="91px"
                                OnClick="btnplot_Click" TabIndex="10" Text="PLOT DASHBOARD" ValidationGroup="group"
                                Width="268px" Font-Bold="True" Font-Names="Verdana" Font-Size="18px" />
                        </td>
                        <td align="center" style="text-align: center"></td>
                        <td align="center" style="text-align: center">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">
                            <asp:Button ID="BtnDelete0" runat="server" CssClass="btn btn-danger" Height="91px"
                                OnClick="BtnDelete0_Click" TabIndex="10" Text="RAW MATERIAL" Font-Bold="True"
                                Width="268px" ValidationGroup="group" Font-Names="Verdana" Font-Size="18px" />
                        </td>
                        <td align="center" style="text-align: center">
                            <asp:Button ID="btnIncentive" runat="server" CssClass="btn btn-danger" Height="91px"
                                TabIndex="10" Text="INCENTIVES" Font-Bold="True" Width="268px" ValidationGroup="group"
                                Font-Names="Verdana" Font-Size="18px" OnClick="btnIncentive_Click" />
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr id="trnewinc" runat="server" visible="true">
                        <td align="center" style="text-align: center">
                            <asp:Button ID="btnUSERIDPSW" runat="server" Visible="false" CssClass="btn btn-danger"
                                Height="91px" TabIndex="10" Text="USERID&PASSWORDS" Font-Bold="True" Width="268px"
                                ValidationGroup="group" Font-Names="Verdana" Font-Size="18px" OnClick="btnUSERIDPSW_Click" />
                        </td>
                        <td align="center" style="text-align: center">
                            <asp:Button ID="btnincentivenew" runat="server" CssClass="btn btn-warning" Height="91px"
                                TabIndex="10" Width="268px" Text="NEW - INCENTIVE" Font-Bold="True" ValidationGroup="group"
                                Font-Names="Verdana" Font-Size="18px" OnClick="btnincentivenew_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">
                            <asp:Button ID="Button3" runat="server" CssClass="btn btn-info" Height="91px" TabIndex="10"
                                Text="RENEWALS" ValidationGroup="group" Width="268px" Font-Bold="True" Font-Names="Verdana"
                                Font-Size="18px" OnClick="Button3_Click" Visible="False" />
                        </td>
                        <td align="center" style="text-align: center" runat="server" visible="false" id="tdAMENDMENTS">
                            <asp:Button ID="btnAmendments" runat="server" CssClass="btn btn-info" Height="91px"
                                TabIndex="10" Text="AMENDMENTS" ValidationGroup="group" Width="268px" Font-Bold="True"
                                Font-Names="Verdana" Font-Size="18px" OnClick="btnAmendments_Click" />
                        </td>
                        <td align="center" style="text-align: center" runat="server" visible="false" id="tdTTAP">
                            <asp:Button ID="btnViewTTAP" runat="server" CssClass="btn btn-info" Height="91px"
                                TabIndex="10" Text="TTAP Incentives" ValidationGroup="group" Width="268px" Font-Bold="True"
                                Font-Names="Verdana" Font-Size="18px" OnClick="btnViewTTAP_Click" />
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">
                            <asp:Button ID="btnbattery" runat="server" CssClass="btn btn-info" Height="91px"
                                TabIndex="10" Text="BATTERY" ValidationGroup="group" Width="268px" Font-Bold="True"
                                Font-Names="Verdana" Font-Size="18px" OnClick="btnbattery_Click" Visible="False" />
                        </td>
                        <td align="center" style="text-align: center">
                            <asp:Button ID="btnfirm" runat="server" CssClass="btn btn-primary" Height="91px"
                                OnClick="btnfirm_Click" TabIndex="10" Text="Firm Registration" ValidationGroup="group"
                                Width="268px" Font-Bold="True" Font-Names="Verdana" Font-Size="18px" />
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">
                            <asp:Button ID="btnMSME" runat="server" CssClass="btn btn-danger" Height="91px" TabIndex="10"
                                Text="MSME REPORT" Font-Bold="True" Width="268px" ValidationGroup="group" Font-Names="Verdana"
                                Font-Size="18px" OnClick="btnMSME_Click" />
                        </td>
                        <td align="center" style="text-align: center">
                            <asp:Button ID="btnSociety" runat="server" CssClass="btn btn-primary" Height="91px"
                                OnClick="btnSociety_Click" TabIndex="10" Text="Society Registration" ValidationGroup="group"
                                Width="268px" Font-Bold="True" Font-Names="Verdana" Font-Size="18px" />
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">
                            <asp:Button ID="btn_tourismEvent" runat="server" CssClass="btn btn-info" Height="91px"
                                TabIndex="10" Text="Tourism Event" ValidationGroup="group" Width="268px" Font-Bold="True"
                                Font-Names="Verdana" Font-Size="18px" OnClick="btn_tourismEvent_Click" Visible="False" />
                        </td>
                        <td align="center" style="text-align: center">&nbsp;
                            <asp:Button ID="btn_tourismagent" runat="server" CssClass="btn btn-info" Height="91px"
                                TabIndex="10" Text="Travel Agent" ValidationGroup="group" Width="268px" Font-Bold="True"
                                Font-Names="Verdana" Font-Size="18px" Visible="false" OnClick="btn_tourismagent_Click" />
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">
                            <asp:Button ID="btn_mrogroundwater" runat="server" CssClass="btn btn-info" Height="91px"
                                TabIndex="10" Text="Well Applications" ValidationGroup="group" Width="268px"
                                Font-Bold="True" Font-Names="Verdana" Font-Size="18px" OnClick="btn_mrogroundwater_Click"
                                Visible="False" />
                        </td>
                        <td align="center" style="text-align: center"></td>
                        <td align="center" style="text-align: center"></td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">
                            <asp:Button ID="btn_gwdept_groundwater" runat="server" CssClass="btn btn-info" Height="91px"
                                TabIndex="10" Text="Well Applications" ValidationGroup="group" Width="268px"
                                Font-Bold="True" Font-Names="Verdana" Font-Size="18px" Visible="false" OnClick="btn_gwdept_groundwater_Click" />
                        </td>
                        <td align="center" style="text-align: center">
                            <asp:Button ID="btn_drillingsrigs" runat="server" CssClass="btn btn-info" Height="91px"
                                TabIndex="10" Text="Drilling Rigs Application" ValidationGroup="group" Width="268px"
                                Font-Bold="True" Font-Names="Verdana" Font-Size="18px" OnClick="btn_drillingsrigs_Click"
                                Visible="False" />
                        </td>
                        <td align="center" style="text-align: center"></td>
                    </tr>
                    <tr id="tradmg" runat="server" visible="false">
                        <td align="center" style="text-align: center">
                            <asp:Button ID="btnadmg" runat="server" CssClass="btn btn-primary"
                                Height="91px" TabIndex="10" TextMode="Multiline" Text="GOVERNMENT LANDS DASH BOARD"
                                ValidationGroup="group" Width="323px" Font-Bold="True"
                                Font-Names="Verdana" Font-Size="14px" OnClick="btnadmg_Click" />
                        </td>
                        <%--Text="GOVERNMENT LANDS DASHBOARD"--%>
                        <td align="center" style="text-align: center">

                            <asp:Button ID="BtnGovtLands" runat="server" CssClass="btn btn-danger" Font-Bold="True"
                                Font-Names="Verdana" Font-Size="14px" Height="91px" OnClick="BtnGovtLands_Click"
                                TabIndex="10" Text="GOVERNMENT LANDS APPLICATION" ValidationGroup="group" Width="341px" Style="margin-left: 0px" />

                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr id="trPattaDashboard" runat="server" visible="false">
                        <td align="center" style="text-align: center">
                            <asp:Button ID="PattadarDashbrd" runat="server" CssClass="btn btn-primary"
                                Height="89px" TabIndex="10" Text="PATTADAR DASHBOARD"
                                ValidationGroup="group" Width="319px" Font-Bold="True"
                                Font-Names="Verdana" Font-Size="14px" OnClick="PattadarDashbrd_Click" />
                        </td>
                        <td align="center" style="text-align: center">&nbsp;</td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr id="tradmgtahsldar" runat="server" visible="false">
                        <td align="center" style="text-align: center">
                            <asp:Button ID="Btnadmgapll" runat="server" Text="Mines NOC (Government Lands)"
                                CssClass="btn btn-primary" Height="116px" TabIndex="10"
                                ValidationGroup="group" Width="351px" Font-Bold="True"
                                Font-Names="Verdana" Font-Size="18px" OnClick="Btnadmgapll_Click" />
                        </td>
                        <td align="center" style="text-align: center">

                            <asp:Button ID="BtnPattadar" runat="server" CssClass="btn btn-primary"
                                Height="117px" TabIndex="10" Text="Mines NOC (Pattadar Applications)"
                                ValidationGroup="group" Width="376px" Font-Bold="True"
                                Font-Names="Verdana" Font-Size="18px" OnClick="BtnPattadar_Click" />


                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">
                            <asp:Button ID="btnusereodb" runat="server" CssClass="btn btn-primary" Height="91px"
                                OnClick="btnusereodb_Click" TabIndex="10" Text="EODB User Data" ValidationGroup="group"
                                Width="268px" Font-Bold="True" Font-Names="Verdana" Font-Size="18px" />
                        </td>
                        <td align="center" style="text-align: center">
                            <asp:Button ID="btnfialedattachments" runat="server" CssClass="btn btn-primary" Height="91px"
                                OnClick="btnfialedattachments_Click" TabIndex="10" Text="Update Attachments" ValidationGroup="group"
                                Width="268px" Font-Bold="True" Font-Names="Verdana" Font-Size="18px" />
                        </td>
                        <td align="center" style="text-align: center"></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr align="center" runat="server" id="tr_gwcomdas" visible="false">
            <%--  <td align="center" style="text-align: center"></td>--%>
            <td align="center" style="text-align: center">
                <asp:GridView ID="grdDetails_state" AutoGenerateColumns="false" OnRowCreated="grdDetails_state_RowCreated"
                    runat="server" CellPadding="2" Width="80%" OnRowDataBound="grdDetails_state_RowDataBound"
                    ShowFooter="True">
                    <headerstyle forecolor="#FFFFFF" backcolor="#009688" height="40px" cssclass="GridviewScrollC1HeaderWrap" />
                    <rowstyle height="40px" cssclass="GridviewScrollC1Item" />
                    <pagerstyle cssclass="GridviewScrollC1Pager" />
                    <footerstyle forecolor="#FFFFFF" backcolor="#009688" height="40px" cssclass="GridviewScrollC1Footer" />
                    <alternatingrowstyle height="40px" cssclass="GridviewScrollC1Item2" />
                    <columns>
                        <asp:BoundField DataField="SNO" HeaderText="Sno">
                            <itemstyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="StateName" HeaderText="State">
                            <itemstyle />
                        </asp:BoundField>
                        <asp:HyperLinkField DataTextField="GroundwaterAppl" HeaderText="Well">
                            <itemstyle cssclass="text-center" font-bold="true" />
                        </asp:HyperLinkField>
                        <asp:HyperLinkField DataTextField="DrillingAppl" HeaderText="Drilling Rigs">
                            <itemstyle cssclass="text-center" font-bold="true" />
                        </asp:HyperLinkField>
                    </columns>
                </asp:GridView>
            </td>
            <%--<td align="center" style="text-align: center"></td>--%>
        </tr>
        <tr runat="server" id="Tr1" visible="false">
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <table style="width: 100%" cellpadding="10" cellspacing="10">
                    <tr>
                        <td style="height: 30px">
                            <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Font-Bold="True" Font-Names="Verdana"
                                Width="210px">Dashboard</asp:Label>
                        </td>
                        <td style="height: 30px"></td>
                        <td style="height: 30px"></td>
                    </tr>
                    <tr id="tr2" runat="server" visible="true">
                        <td align="center" style="text-align: left">
                            <asp:Button ID="Button4" runat="server" CssClass="btn btn-warning" Height="91px"
                                TabIndex="10" Width="268px" Text="NEW - INCENTIVE" Font-Bold="True" ValidationGroup="group"
                                Font-Names="Verdana" Font-Size="18px" OnClick="btnincentivenew_Click" />
                        </td>
                    </tr>

                </table>
            </td>
        </tr>

        <tr>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
