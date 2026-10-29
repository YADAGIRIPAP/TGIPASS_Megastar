<%@ page title="" language="C#" masterpagefile="~/UI/TSiPASS/EmptyMaster.master" autoeventwireup="true" codefile="frmIncentiveDashboardEODB.aspx.cs" inherits="UI_TSiPASS_frmIncentiveDashboardEODB" %>

<%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function GetRowValue(val) {
            if (val != '&nbsp;') {
                val1 = 0;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdfID').value = val;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdfFlagID').value = val1;

            }
            window.opener.document.forms[0].submit();
            self.close();

        }

    </script>
    <script language="javascript" type="text/javascript">
        function Panel1() {
            document.getElementById('<%=A1.ClientID %>').style.display = "none";
            document.getElementById('<%=A2.ClientID %>').style.display = "none";
            var panel = document.getElementById("<%=divPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>newTable</title>');

            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();

            setTimeout(function () {
                printWindow.print();
                location.reload(true);
                printWindow.close();
            }, 1000);
            return false;

        }


        $(function () {

            $('#MstLftMenu').remove();

        });

    </script>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var yrRange = "2020:" + (date.getFullYear() + 1);

            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtFromDate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange,
                    minDate: new Date(2020, 11 - 1, 1)

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtTodate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
        }
        $(function () {
            var date = new Date();
            var yrRange = "2020:" + (date.getFullYear() + 1);
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtFromDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange,
                    minDate: new Date(2020, 11 - 1, 1)
                });
            $("input[id$='txtTodate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
        });
    </script>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>



    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <style type="text/css">
        .ui-datepicker {
            font-size: 8pt !important;
            padding: 0.2em 0.2em 0;
            width: 250px;
            color: Black;
            z-index: 9999 !important;
        }

        select {
            color: Black !important;
        }
    </style>
    <style>
        .algnCenter {
            text-align: center;
        }
    </style>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var yrRange = "2015:" + (date.getFullYear() + 1);

            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtFromDate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtTodate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
        }
        $(function () {
            var date = new Date();
            var yrRange = "2015:" + (date.getFullYear() + 1);
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtFromDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange
                });
            $("input[id$='txtTodate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
        });
    </script>
    <div class="col-lg-12">
        <div class="panel panel-default">
            <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 80%">
                <tr>
                    <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px;" valign="top"
                        align="center">
                        <div class="panel panel-default">
                            <div class="panel-heading" style="text-align: center">
                                <h3 class="panel-title" style="font-weight: bold;">
                                    <asp:label id="lblHeading" runat="server">Incentives Granted Dashboard</asp:label>&nbsp;
                                    <a id="A1" href="#" onserverclick="BtnPDF_Click" runat="server">
                                        <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="PDF" /></a> <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                                <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;" /></a></h3>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 90%; font-family: 'Trebuchet MS'">
                                    <tr>
                                        <td style="text-align: left">
                                            <%--<asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboardNew.aspx"
                                                Text="<< Back">
                                            </asp:HyperLink>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left">
                                            <b>
                                                <asp:label id="lblHeadingText" runat="server"></asp:label>
                                            </b></td>
                                    </tr>
                                    <tr id="tr1" runat="server">
                                        <td colspan="6" align="center">
                                            <table>

                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">From Date:
                                                    </td>
                                                    <td>
                                                        <asp:textbox id="txtFromDate" runat="server" class="form-control txtbox" height="28px"
                                                            maxlength="40" onkeypress="NumberOnly()" tabindex="1" validationgroup="group"
                                                            width="150px">
                                                        </asp:textbox>

                                                        <%--<cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                </cc1:CalendarExtender>--%>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">To Date:
                                                    </td>
                                                    <td>
                                                        <asp:textbox id="txtTodate" runat="server" class="form-control txtbox" height="28px"
                                                            maxlength="40" onkeypress="NumberOnly()" tabindex="1" validationgroup="group"
                                                            width="150px">
                                                        </asp:textbox>
                                                        <%-- <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                                </cc1:CalendarExtender>--%>
                                                    </td>

                                                </tr>
                                                <tr align="center">
                                                    <td style="padding: 5px; margin: 5px" colspan="4" align="center">
                                                        <%--<asp:Button ID="btnGet" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Generate Report" Width="180px" OnClick="btnGet_Click" />--%>
                                                        <asp:button id="Button3" runat="server" cssclass="btn btn-primary" tabindex="10"
                                                            text="Submit" onclick="BtnSave1_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>

                                    <tr id="div_Print" runat="server">
                                        <td align="center" colspan="6" style="padding: 5px; margin: 5px">
                                            <asp:gridview id="grdDetails" cssclass="floatingTable" runat="server" autogeneratecolumns="False"
                                                cellpadding="4" onrowdatabound="grdDetails_RowDataBound" onpageindexchanging="grdDetails_PageIndexChanging"
                                                showfooter="false">
                                                <headerstyle forecolor="#FFFFFF" backcolor="#009688" height="40px" cssclass="GridviewScrollC1HeaderWrap" />
                                                <rowstyle height="40px" cssclass="GridviewScrollC1Item" />
                                                <pagerstyle cssclass="GridviewScrollC1Pager" />
                                                <footerstyle forecolor="#FFFFFF" backcolor="#009688" height="40px" cssclass="GridviewScrollC1Footer" />
                                                <alternatingrowstyle height="40px" cssclass="GridviewScrollC1Item2" />
                                                <columns>
                                                    <asp:templatefield headerstyle-horizontalalign="Center" headertext="Sl.No">
                                                        <itemtemplate>
                                                            <%# Container.DataItemIndex +1 %>
                                                        </itemtemplate>
                                                        <headerstyle horizontalalign="Center" />
                                                        <itemstyle width="20px" />
                                                    </asp:templatefield>
                                                    <asp:boundfield datafield="ApprovalName" headertext="Particulars" />
                                                    <asp:boundfield datafield="TimelimitPrescribed" headertext="TimelimitPrescribed" />
                                                    <asp:boundfield datafield="TotalNumberofApplicationsReceived" headertext="Total Number of Applications Received" />
                                                    <asp:boundfield datafield="TotalNumberofapplicationsprocessed" headertext="Total Number of applications Approved" />
                                                    <asp:boundfield datafield="Averagetimetakentograntapproval" headertext="Average time taken to grant approval" />
                                                    <asp:boundfield datafield="Mediantimetakentograntapproval" headertext="Median time taken to grant approval" />
                                                    <asp:boundfield datafield="Minimumtimetograntapproval" headertext="Minimum time taken to grant approval" />
                                                    <asp:boundfield datafield="Maximumtimetograntapproval" headertext="Maximum time taken to grant approval" />
                                                    <%--<asp:BoundField DataField="TOTAL" HeaderText="TOTAL" />--%>
                                                </columns>
                                            </asp:gridview>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5" align="center" style="padding: 5px; margin: 5px">
                                            <div id="DIVUPDATEDDATE" runat="server" class="alert alert-success">
                                                <b>
                                                    <asp:label id="LBLDATETEXT" runat="server" text="The data in the dashboard is updated on a real time basis."></asp:label>
                                                    </br><asp:label id="lbllastupdate" runat="server" text="Last update:"></asp:label>
                                                    <asp:label id="LBLDATETIME" runat="server"></asp:label>
                                                </b>
                                            </div>

                                        </td>
                                    </tr>
                                    <tr>

                                        <td colspan="6" align="center" style="padding: 5px; margin: 5px">
                                            <div id="DIV1" runat="server">
                                                <b>
                                                    <h4>
                                                        <asp:label id="Label1" runat="server" text="Note: No fee/cost is charged by the government to enterprises for submitting the incentive application."></asp:label>
                                                        <asp:label id="Label3" runat="server"></asp:label>
                                                    </h4>
                                                </b>
                                            </div>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6" align="center" style="padding: 5px; margin: 5px">
                                            <div id="success" runat="server" class="alert alert-success" visible="false">
                                                <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:label id="Label2" runat="server"></asp:label>
                                            </div>
                                            <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                                <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                                <asp:label id="lblmsg0" runat="server"></asp:label>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:content>


