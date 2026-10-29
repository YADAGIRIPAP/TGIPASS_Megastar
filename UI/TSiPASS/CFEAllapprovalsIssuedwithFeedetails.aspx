<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/EmptyMaster.master" CodeFile="CFEAllapprovalsIssuedwithFeedetails.aspx.cs" Inherits="UI_TSiPASS_CFEAllapprovalsIssuedwithFeedetails" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%--<script type="text/javascript" src="../../js/jquery.min.js"></script>

    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>

    <script type="text/javascript" src="../../js/gridviewScroll.min.js"></script>--%>
    <style type="text/css">
        .formatted-text {
            white-space: pre-wrap;
        }
    </style>
    <script language="javascript" type="text/javascript">
        function Panel1() {


            <%--document.getElementById('<%=trFilter.ClientID %>').style.display = "none";--%>

            var panel = document.getElementById("<%=GridPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title>');

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
            document.getElementById('<%=tblselection.ClientID %>').style.display = "none";
            document.getElementById('<%=GridPrint.ClientID %>').style.display = "none";
            document.getElementById('<%=HyperLink1.ClientID %>').style.display = "none";

            var panel = document.getElementById("<%=divPrint.ClientID %>");
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
    <%--datepicker added on 17/01/2019--%>
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
        /*$(document).ready(function () {
            applyFormatting();
        });*/

        function formatText(text) {
            const items = text.split(',');
            return items.join('<br/>');
        }
        function applyFormatting() {
            $(".formatted-text").each(function () {
                var labelValue = $(this).text();
                $(this).text(formatText(labelValue));
            });
        }
    </script>

    <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading" style="text-align: center">
                            <h3 visible="false" id="Government" runat="server" class="panel-title" style="font-weight: bold;">Government of Telangana</h3>
                            <h2 id="H1" runat="server" class="panel-title" style="font-weight: bold;">
                                <asp:Label ID="lblHeading" runat="server">R6.1 : TSiPASS- District Wise Report </asp:Label>
                                <a id="Button2" href="#" onserverclick="BtnPDF_Click"
                                    runat="server">
                                    <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                        alt="PDF" /></a>
                                <a id="pdfPrint" href="#" onclick="javascript:return Panel1();"
                                    runat="server">
                                    <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                                        style="float: right;" /></a>
                                <a id="Button1" href="#" onserverclick="BtnSave2_Click" runat="server">
                                    <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                        alt="Excel" /></a></h2>
                        </div>
                        <div class="panel-body">
                            <table align="center" cellpadding="10" cellspacing="5" style="width: 80%; font-family: 'Trebuchet MS'">
                                <tr>
                                    <td>
                                        <table runat="server" id="tblselection" cellpadding="4" cellspacing="5" style="width: 80%">
                                            <tr>
                                                <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboardNew.aspx"
                                                        Text="<< Back">
                                                    </asp:HyperLink>
                                                </td>

                                                <td style="padding: 5px; margin: 5px" align="center" runat="server" id="tdFromDate">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            From Date
                                                        </div>

                                                        <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                        <%--<cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                        </cc1:CalendarExtender>--%>
                                                    </div>
                                                </td>
                                                <td style="padding: 5px; margin: 5px" runat="server" id="tdToDate">

                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            To Date
                                                        </div>
                                                        <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                        <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                                        </cc1:CalendarExtender>--%>
                                                    </div>
                                                </td>


                                                <td style="padding: 5px; margin: 5px" align="right">
                                                    <asp:Button ID="Button3" runat="server" CssClass="btn btn-default" TabIndex="10"
                                                        Text="Submit" OnClick="BtnSave1_Click" />
                                                </td>
                                            </tr>

                                        </table>
                                    </td>
                                    <td style="padding: 5px; text-align: right; margin: 5px; width: 100%;"></td>
                                </tr>
                                <tr runat="server" id="rptdate">
                                    <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                        <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                        <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                        <asp:Button ID="btnNewPdf" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Generate Pdf" OnClick="btnNewPdf_Click" />
                                    </td>
                                </tr>
                                <tr id="GridPrint" runat="server">
                                    <td colspan="5" align="center" style="padding: 5px; margin: 5px" id="divPrint1" runat="server">
                                        <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                            Width="100%"
                                            ShowFooter="False" OnRowDataBound="grdDetails_RowDataBound">
                                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                            <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                            <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                            <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="applicationnumber" HeaderText="Application No">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle CssClass="text-uppercase" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="applicationdate" HeaderText="Application Date">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle CssClass="text-uppercase" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Approvaldate" HeaderText="Approval Date">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle CssClass="text-uppercase" Width="100px" />
                                                </asp:BoundField>
                                                <%-- <asp:BoundField DataField="Feedetails" HeaderText="Fee Details">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="formatted-text" />
                                                    <ItemStyle CssClass="text-uppercase" />
                                                </asp:BoundField>--%>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Fee Details">
                                                    <ItemTemplate>
                                                         <asp:Label ID="lblFeedetails" runat="server" Text='<%# Bind("Feedetails") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Totalfee" HeaderText="Total Fee charged">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle CssClass="text-uppercase" />
                                                </asp:BoundField>

                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>

                                <tr>
                                    <td align="center" style="padding: 5px; margin: 5px">
                                        <div id="success" runat="server" visible="false" class="alert alert-success">
                                            <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                        </div>
                                        <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
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
</asp:Content>

