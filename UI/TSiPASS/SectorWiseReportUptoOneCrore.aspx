<%@ page title="" language="C#" masterpagefile="~/UI/TSiPASS/CCMaster.master" autoeventwireup="true" codefile="SectorWiseReportUptoOneCrore.aspx.cs" inherits="UI_TSiPASS_SectorWiseReportUptoOneCrore" %>

<%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">

        function Panel1() {
            document.getElementById('<%=Button1.ClientID %>').style.display = "none";
            document.getElementById('<%=Button2.ClientID %>').style.display = "none";
            document.getElementById('<%=GraphPrint.ClientID %>').style.display = "none";
            document.getElementById('<%=HyperLink1.ClientID %>').style.display = "none";
            removescrolling();
            var panel = document.getElementById("<%=GridPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><h3 style="width: 100%;text-align: center;">Government of Telangana</h3>');

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

    <script language="javascript" type="text/javascript">
        function Panel2() {
            document.getElementById('<%=Button1.ClientID %>').style.display = "none";
            document.getElementById('<%=Button2.ClientID %>').style.display = "none";
            document.getElementById('<%=A1.ClientID %>').style.display = "none";
            document.getElementById('<%=GridPrint.ClientID %>').style.display = "none";
            document.getElementById('<%=HyperLink1.ClientID %>').style.display = "none";

            var panel = document.getElementById("<%=GridPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><h3 style="width: 100%;text-align: center;">Government of Telangana</h3>');

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
    </script>
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


    <table runat="server" id="divPrint" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading" style="text-align: center">
                            <h3 visible="false" id="Government" runat="server" class="panel-title" style="font-weight: bold;">Government of Telangana</h3>
                            <h2 class="panel-title" style="font-weight: bold;">
                                <asp:label id="lblHeading" runat="server">R6.6: Investment Range Wise - Sector Report </asp:label>
                                <a id="Button2" href="#"
                                    onserverclick="BtnSave3_Click" runat="server">
                                    <%--<img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                        alt="PDF" />--%></a> &nbsp;&nbsp;
                                        <a id="pdfPrint" href="#" onclick="javascript:return Panel2();"
                                            runat="server">
                                            <img src="../../Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                                                style="float: right;" /></a>
                                <a id="Button1" href="#" onserverclick="BtnSave2_Click" runat="server">
                                    <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                        alt="Excel" /></a></h2>
                        </div>
                        <div class="panel-body">
                            <table align="center" cellpadding="10" cellspacing="5" style="width: 80%; font-family: 'Trebuchet MS'">
                                <tr>
                                    <td>
                                        <table runat="server" id="tblselection" cellpadding="4" cellspacing="5" style="width: 100%">
                                            <tr>
                                                <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                    <asp:hyperlink cssclass="btn btn-link" id="HyperLink1" runat="server" navigateurl="~/UI/TSiPASS/ReportsDashboardNew.aspx"
                                                        text="<< Back">
                                                    </asp:hyperlink>
                                                </td>
                                                <td class="col-xs-3" style="padding: 5px; margin: 5px" runat="server" visible="false">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            Type
                                                        </div>
                                                        <asp:dropdownlist id="ddlType" runat="server" class="form-control txtbox" height="33px"
                                                            width="180px" onselectedindexchanged="ddlType_SelectedIndexChanged" autopostback="true">
                                                            <asp:listitem>--Select--</asp:listitem>
                                                            <asp:listitem value="3">2016-17</asp:listitem>
                                                            <asp:listitem value="4">2017-18</asp:listitem>
                                                        </asp:dropdownlist>
                                                    </div>
                                                </td>
                                                <td style="padding: 5px; margin: 5px" align="center" runat="server" id="tdFromDate">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            From Date
                                                        </div>

                                                        <asp:textbox id="txtFromDate" runat="server" class="form-control txtbox" height="28px" maxlength="40" onkeypress="NumberOnly()" tabindex="1" validationgroup="group" width="125px"></asp:textbox>
                                                        <%-- <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                        </cc1:CalendarExtender>--%>
                                                    </div>
                                                </td>
                                                <td style="padding: 5px; margin: 5px" runat="server" id="tdToDate">

                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            To Date
                                                        </div>
                                                        <asp:textbox id="txtTodate" runat="server" class="form-control txtbox" height="28px" maxlength="40" onkeypress="NumberOnly()" tabindex="1" validationgroup="group" width="125px"></asp:textbox>
                                                        <%--  <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                                        </cc1:CalendarExtender>--%>
                                                    </div>
                                                </td>
                                                <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            Investment Range
                                                        </div>
                                                        <asp:dropdownlist id="ddlinvestment" runat="server" class="form-control txtbox" height="33px"
                                                            width="180px">
                                                            <asp:listitem value="1">0-1 Crore</asp:listitem>
                                                            <asp:listitem value="2">1-5 Crore</asp:listitem>
                                                            <asp:listitem value="3">5-10 Crore</asp:listitem>
                                                            <asp:listitem value="4">10-100 Crore</asp:listitem>
                                                            <asp:listitem value="5">100-200 Crore</asp:listitem>
                                                            <asp:listitem value="6">Above 200 Crore</asp:listitem>
                                                        </asp:dropdownlist>
                                                    </div>
                                                </td>
                                                <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            District
                                                        </div>
                                                        <asp:dropdownlist id="ddldistrict" runat="server" class="form-control txtbox" width="180px">
                                                            <asp:listitem value="0">--Select--</asp:listitem>
                                                        </asp:dropdownlist>
                                                    </div>
                                                </td>
                                                <td style="padding: 5px; margin: 5px" align="right">
                                                    <asp:button id="Button3" runat="server" cssclass="btn btn-default" tabindex="10"
                                                        text="Submit" onclick="BtnSave1_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="padding: 5px; text-align: right; margin: 5px; width: 100%;">
                                        <%-- <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                        <asp:label id="Label1" runat="server" cssclass="LBLBLACK">Report as on date</asp:label>
                                    </td>
                                </tr>
                                <tr runat="server" visible="false" id="rptdatef">
                                    <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                        <asp:label id="Label2" runat="server" cssclass="LBLBLACK"></asp:label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:label id="Label3" font-size="Larger" font-bold="true" runat="server"></asp:label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                        <asp:button id="btnNewPdf" runat="server" cssclass="btn btn-primary" height="32px"
                                            tabindex="10" text="Generate Pdf" onclick="btnNewPdf_Click" />
                                    </td>
                                </tr>
                                <tr id="GridPrint" runat="server">
                                    <td colspan="2" align="center" style="padding: 5px; margin: 5px" id="divPrint1" runat="server">
                                        <asp:gridview id="grdDetails" runat="server" autogeneratecolumns="False" cellpadding="4"
                                            onrowdatabound="grdDetails_RowDataBound" width="100%" onpageindexchanging="grdDetails_PageIndexChanging"
                                            showfooter="True" onrowcreated="grdDetails_RowCreated" onselectedindexchanged="grdDetails_SelectedIndexChanged">
                                            <headerstyle forecolor="#FFFFFF" backcolor="#009688" height="40px" cssclass="GridviewScrollC1HeaderWrap" />
                                            <rowstyle height="40px" cssclass="GridviewScrollC1Item" />
                                            <pagerstyle cssclass="GridviewScrollC1Pager" />
                                            <footerstyle forecolor="#FFFFFF" backcolor="#009688" height="40px" cssclass="GridviewScrollC1Footer" />
                                            <alternatingrowstyle height="40px" cssclass="GridviewScrollC1Item2" />
                                            <columns>
                                                <asp:templatefield headerstyle-horizontalalign="Center" headertext="S.No">
                                                    <itemtemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </itemtemplate>
                                                    <headerstyle horizontalalign="Center" />
                                                </asp:templatefield>
                                                <asp:boundfield datafield="Sectorandmajor" headertext="Sector Name">
                                                    <itemstyle wrap="true" cssclass="text-uppercase" />
                                                </asp:boundfield>
                                                <asp:hyperlinkfield controlstyle-font-underline="false" controlstyle-forecolor="Black"
                                                    footerstyle-cssclass="text-center" datatextfield="Number" headertext="No of Units">
                                                    <footerstyle horizontalalign="Center" font-bold="true" font-underline="false" cssclass="text-center" />
                                                    <itemstyle font-underline="false" horizontalalign="Center" cssclass="text-center" />
                                                </asp:hyperlinkfield>
                                                <asp:hyperlinkfield footerstyle-cssclass="text-center" datatextfield="Investment"
                                                    controlstyle-font-underline="false" controlstyle-forecolor="Black" headertext="Investment (Rs. in Cr)">
                                                    <footerstyle horizontalalign="Center" font-bold="true" font-underline="false" cssclass="text-center" />
                                                    <itemstyle font-underline="false" wrap="true" horizontalalign="Center" cssclass="text-center" />
                                                </asp:hyperlinkfield>
                                                <asp:hyperlinkfield footerstyle-cssclass="text-center" datatextfield="Employment"
                                                    controlstyle-font-underline="false" controlstyle-forecolor="Black" headertext="Number Of Employees">
                                                    <footerstyle horizontalalign="Center" font-bold="true" font-underline="false" cssclass="text-center" />
                                                    <itemstyle font-underline="false" horizontalalign="Center" cssclass="text-center" />
                                                </asp:hyperlinkfield>
                                            </columns>
                                        </asp:gridview>
                                    </td>
                                </tr>

                                <tr id="GraphPrint" runat="server">
                                    <td colspan="2" align="center" style="padding: 5px; margin: 5px">
                                        <a id="A1" href="#" onclick="javascript:return Panel2();" runat="server">
                                            <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                                alt="PDF" /></a>
                                        <div>
                                            <br />
                                            <br />


                                            <script type="text/javascript" src="../../js/googleapi.js"></script>

                                            <asp:literal id="ltrPie" runat="server"></asp:literal>
                                            <div id="piechart_3d" style="border-style: solid; border-width: 1px; width: 100%; height: 600px;">
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding: 5px; margin: 5px">
                                        <div id="success" runat="server" visible="false" class="alert alert-success">
                                            <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:label id="lblmsg" runat="server"></asp:label>
                                        </div>
                                        <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                            <asp:label id="lblmsg0" runat="server"></asp:label>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:content>

