<%@ page title="" language="C#" masterpagefile="~/UI/TSiPASS/EmptyMaster.master"
    autoeventwireup="true" codefile="MisreportDashboard.aspx.cs" inherits="UI_TSiPASS_MisreportDashboard" %>

<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
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
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <table style="width: 100%" cellpadding="10" cellspacing="10">
                    <tr>
                        <td colspan="3">
                            <div align="left">
                                <ol class="breadcrumb">
                                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                                    <li><i></i><a href="Home.aspx">Home</a></li>
                                    <%--<li class=""><i class="fa fa-fw fa-edit">CFE</i> </li>--%>
                                    <li class="active"><i></i>EODB Reports </li>
                                </ol>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 30px; font-size: 30px; text-align: center" colspan="5">
                            <asp:label id="Label437" runat="server" cssclass="LBLBLACK" font-bold="True" font-names="Verdana"
                                width="410px">EODB REPORTS</asp:label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px"></td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">
                            <asp:button id="btnsinglewindow" runat="server" cssclass="btn btn-warning" forecolor="Black" bordercolor="black" height="91px"
                                tabindex="10" text="Single Window" validationgroup="group" font-bold="True" font-names="Verdana"
                                font-size="18px" onclick="btnsinglewindow_Click" width="450px" />
                        </td>
                        <td></td>
                        <td align="center" style="text-align: center">
                            <asp:button id="btngranted" runat="server" cssclass="btn btn-info" forecolor="Black" bordercolor="black" height="91px"
                                tabindex="10" text="Granted" validationgroup="group" font-bold="True" font-names="Verdana"
                                font-size="18px" onclick="btngranted_Click" width="450px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px"></td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">
                            <asp:button id="btnIncentivedashboard" runat="server" backcolor="#ff9933"
                                height="91px" tabindex="10" text="Incentives Granted Dashboard" validationgroup="group"
                                font-bold="True" font-names="Verdana" font-size="18px" onclick="btnIncentivedashboard_Click"
                                width="450px" />
                        </td>
                        <td></td>
                        <td align="center" style="text-align: center">
                            <asp:button id="btnquery" runat="server" backcolor="#0099ff" height="91px" tabindex="10"
                                text="Grievance Handled Dashboard" validationgroup="group" font-bold="True" font-names="Verdana"
                                font-size="18px" onclick="btnquery_Click" width="450px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px"></td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">
                            <asp:button id="btntourism" runat="server" backcolor="#ff6600" height="91px"
                                tabindex="10" text="Tourism Event Dashboard" validationgroup="group" font-bold="True"
                                font-names="Verdana" font-size="18px" onclick="btntourism_Click" width="450px" />
                        </td>
                        <td></td>
                        <td align="center" style="text-align: center">
                            <asp:button id="btnTravelAgency" runat="server" backcolor="#0066cc" height="91px"
                                tabindex="10" text="Travel Agency Dashboard" validationgroup="group" font-bold="True"
                                font-names="Verdana" font-size="18px" onclick="btnTravelAgency_Click" width="450px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px"></td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">
                            <asp:button id="btnhotelcfe" runat="server" backcolor="#cc6600" height="91px"
                                tabindex="10" text="Hotel CFE Dashboard" validationgroup="group" font-bold="True"
                                font-names="Verdana" font-size="18px" onclick="btnhotelcfe_Click" width="450px" />
                        </td>
                        <td></td>
                        <td align="center" style="text-align: center">
                            <asp:button id="btnhotelcfo" runat="server" backcolor="#0000cc" height="91px"
                                tabindex="10" text="Hotel CFO Dashboard" validationgroup="group" font-bold="True"
                                font-names="Verdana" font-size="18px" onclick="btnhotelcfo_Click" width="450px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px"></td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">
                            <asp:button id="btngrievancemis" runat="server" cssclass="btn btn-warning" forecolor="Black" bordercolor="black" height="91px"
                                tabindex="10" text="GRIEVANCE/FEEDBACK/GENERALQUERY" validationgroup="group"
                                font-bold="True" font-names="Verdana" font-size="18px" onclick="btngrievancemis_Click"
                                width="450px" />
                        </td>
                        <td></td>
                        <td align="center" style="text-align: center">
                            <asp:button id="btnregulationmis" runat="server" cssclass="btn btn-info" forecolor="Black" bordercolor="black" height="91px"
                                tabindex="10" text="BUSINESS REGULATION" validationgroup="group" font-bold="True"
                                font-names="Verdana" font-size="18px" onclick="btnregulationmis_Click" width="450px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px"></td>
                    </tr>
                    <tr id="trcfe" runat="server" visible="true">
                        <td align="center" style="text-align: center">
                            <asp:button id="btncfemis" runat="server" backcolor="#ff9933" height="91px"
                                tabindex="10" text="TG-iPASS" validationgroup="group" width="450px" font-bold="True"
                                font-names="Verdana" font-size="18px" onclick="btncfemis_Click" />
                        </td>
                        <td></td>
                        <td align="center" style="text-align: center">
                            <asp:button id="btnIncentive" runat="server" backcolor="#0099ff" height="91px"
                                tabindex="10" text="INCENTIVES" font-bold="True" width="450px" validationgroup="group"
                                font-names="Verdana" font-size="18px" onclick="btnIncentive_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px"></td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">
                            <asp:button id="btncentral" runat="server" backcolor="#ff6600" height="91px"
                                tabindex="10" text="CENTRAL INSPECTION AGENCY" validationgroup="group" width="450px"
                                font-bold="True" font-names="Verdana" font-size="18px" onclick="btncentralinspectionmis_Click" />
                        </td>
                        <td></td>
                        <td align="center" style="text-align: center">
                            <asp:button id="BTNHELPDESK" runat="server" backcolor="#0066cc" height="91px" tabindex="10"
                                text="Queries(Helpdesk) Handled Dashboard" validationgroup="group" font-bold="True" font-names="Verdana"
                                font-size="18px" onclick="BTNHELPDESK_Click" width="450px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px"></td>
                    </tr>
                    <tr runat="server">
                        <td align="center" style="text-align: center">
                            <asp:button id="btnallaaprwithfeedetails" runat="server" backcolor="#cc6600" height="91px"
                                tabindex="10" text="Firm wise Approvals" validationgroup="group" width="450px"
                                font-bold="True" font-names="Verdana" font-size="18px" onclick="btnallaaprwithfeedetails_Click" />
                        </td>
                        <td></td>
                        <td align="center" style="text-align: center">
                            <asp:button id="btnDecrim" runat="server" cssclass="btn btn-warning" backcolor="#0000cc" height="91px"
                                tabindex="10" text="Criminal provisions under various legislations" validationgroup="group" width="450px"
                                font-bold="True" font-names="Verdana" font-size="15px" onclick="btnDecrim_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px"></td>
                    </tr>
                    <tr runat="server">
                        <td align="center" style="text-align: center">
                            <asp:button id="btnfeedback" runat="server" backcolor="#ff9933" height="91px"
                                tabindex="10" text="Feed Back Report" validationgroup="group" width="450px"
                                font-bold="True" font-names="Verdana" font-size="18px" onclick="btnfeedback_Click" />
                        </td>
                        <td></td>
                        <td align="center" style="text-align: center">
                            <asp:button id="btnAIML" runat="server" cssclass="btn btn-info" forecolor="Black" bordercolor="black" height="91px"
                                tabindex="10" text="AI/ML Dashboard" validationgroup="group" font-bold="True" font-names="Verdana"
                                font-size="18px" onclick="btnAIML_Click" width="450px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:content>
