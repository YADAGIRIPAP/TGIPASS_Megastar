<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSIPASS/EmptyMaster.master"
    CodeFile="ComnrReportRelases.aspx.cs" Inherits="UI_TSIPASS_ComnrReportRelases" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script language="javascript" type="text/javascript">
        function Panel1() {
        
            var panel = document.getElementById("<%=divPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title>');

            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write
            ('</body></html>');
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

        

        if ($('table.floatingTable1').not('thead')) {
            var len1 = $('table.floatingTable1 tr').has('th').length;
            $('table.floatingTable1').prepend('<thead></thead>')
            for (i = 0; i < len1; i += 1) {
                $('table.floatingTable1').find('thead').append($('table.floatingTable1').find("tr:eq(" + i + ")"));
            }
        }

        var $table1 = $('table.floatingTable1');
        $table1.floatThead();
        $table1.floatThead({ position: 'fixed' });
        $table1.floatThead({ autoReflow: 'true' });
    });

    </script>
    
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <style type="text/css">
        .ui-datepicker
        {
            font-size: 8pt !important;
            padding: 0.2em 0.2em 0;
            width: 250px;
            color: Black;
            z-index: 9999 !important;
        }
        select
        {
            color: Black !important;
        }
    </style>
    <style>
        .algnCenter
        {
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
                <table  border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px;  padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <div class="panel panel-default">
                    <div class="panel-heading" style="text-align: center">
                        <h3 class="panel-title" style="font-weight: bold;">
                            <asp:Label ID="lblHeading" runat="server">RELEASES DOCUMENTS UPLOAD STATUS REPORT</asp:Label>
                            <a id="Button2" href="#" onclick="javascript:return Panel1();" runat="server">
                               <%-- <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" /> --%>
                                    <img src="../../Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                                                        style="float: right;" /></a> <a id="Button1" href="#" onserverclick="BtnSave2_Click" runat="server">
                                      <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /> </a>
                                            </h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%; font-family: 'Trebuchet MS'">
                            <tr id="trFilter" runat="server">
                                <td align="right">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" align="right">
                                    <table runat="server" id="tblselection" cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        Caste
                                                    </div>
                                                    <asp:DropDownList ID="ddlCaste" runat="server" class="form-control txtbox" Height="33px"
                                                        Width="180px" AutoPostBack="true" CssClass="auto-style1" OnSelectedIndexChanged="ddlCaste_SelectedIndexChanged">
                                                        <asp:ListItem>SC</asp:ListItem>
                                                        <asp:ListItem>ST</asp:ListItem>
                                                        <asp:ListItem>PHC</asp:ListItem>
                                                        <asp:ListItem>GENERAL</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        Release proceeding No
                                                    </div>
                                                    <asp:DropDownList ID="ddlReleaseProceeding" runat="server" class="form-control txtbox"
                                                        Height="33px" Width="180px" AutoPostBack="true" CssClass="auto-style1">
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            <td>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="center" runat="server" id="tdFromDate">
                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        From Date
                                                    </div>
                                                    <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                        Width="125px"></asp:TextBox>
                                                    <%--  <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                    </cc1:CalendarExtender>--%>
                                                </div>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" runat="server" id="tdToDate">
                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        To Date
                                                    </div>
                                                    <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                        Width="125px"></asp:TextBox>
                                                    <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                                    </cc1:CalendarExtender>--%>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        SLC/DIPC
                                                    </div>
                                                    <asp:DropDownList ID="ddlslcDIPC" runat="server" class="form-control txtbox" Height="33px"
                                                        Width="180px" AutoPostBack="true" CssClass="auto-style1" OnSelectedIndexChanged="ddlslcDIPC_SelectedIndexChanged">
                                                        <asp:ListItem>SLC</asp:ListItem>
                                                        <asp:ListItem>DIPC</asp:ListItem>
                                                        <asp:ListItem>ALL</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="right">
                                                <asp:Button ID="Button3" runat="server" CssClass="btn btn-default" TabIndex="10"
                                                    Text="Submit" OnClick="Button3_Click" />
                                            </td>
                                            <td  style="padding: 5px; text-align: right; margin: 5px" colspan="5">
                                            <b>
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label></b>
                                        </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                    <%--<asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>--%>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                    &nbsp;</td>
                            </tr>
                            <tr >
                                <td id="divPrint" runat="server"  colspan="2" align="center"  style="padding: 5px; margin: 5px">
                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        Width="100%" ShowFooter="True" OnRowDataBound="grdDetails_RowDataBound" OnRowCreated="grdDetails_RowCreated">
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="floatingTable2" />
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:BoundField DataField="Sno" HeaderText="Sno"></asp:BoundField>
                                            <asp:BoundField DataField="District" HeaderText="District Name"></asp:BoundField>
                                            <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                FooterStyle-CssClass="text-center" DataTextField="total_releasedCount" HeaderText="Units">
                                                <FooterStyle HorizontalAlign="Center" Font-Bold="true" Font-Underline="false" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                FooterStyle-CssClass="text-center" DataTextField="total_releasedCountValue" HeaderText="Amount(Rs)">
                                                <FooterStyle HorizontalAlign="Center" Font-Bold="true" Font-Underline="false" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                FooterStyle-CssClass="text-center" DataTextField="total_uploaded_applicantCount"
                                                HeaderText="Units">
                                                <FooterStyle HorizontalAlign="Center" Font-Bold="true" Font-Underline="false" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                FooterStyle-CssClass="text-center" DataTextField="total_uploaded_applicantValue"
                                                HeaderText="Amount(Rs)">
                                                <FooterStyle HorizontalAlign="Center" Font-Bold="true" Font-Underline="false" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                FooterStyle-CssClass="text-center" DataTextField="total_processed_gmCount" HeaderText="Units">
                                                <FooterStyle HorizontalAlign="Center" Font-Bold="true" Font-Underline="false" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                FooterStyle-CssClass="text-center" DataTextField="total_processed_gmValue" HeaderText="Amount(Rs)">
                                                <FooterStyle HorizontalAlign="Center" Font-Bold="true" Font-Underline="false" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                FooterStyle-CssClass="text-center" DataTextField="total_processed_not_gmCount"
                                                HeaderText="Units">
                                                <FooterStyle HorizontalAlign="Center" Font-Bold="true" Font-Underline="false" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                FooterStyle-CssClass="text-center" DataTextField="total_processed_not_gmValue"
                                                HeaderText="Amount(Rs)">
                                                <FooterStyle HorizontalAlign="Center" Font-Bold="true" Font-Underline="false" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                FooterStyle-CssClass="text-center" DataTextField="total_yettoUploadCount" HeaderText="Units">
                                                <FooterStyle HorizontalAlign="Center" Font-Bold="true" Font-Underline="false" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                FooterStyle-CssClass="text-center" DataTextField="total_yettoUploadValue" HeaderText="Amount(Rs)">
                                                <FooterStyle HorizontalAlign="Center" Font-Bold="true" Font-Underline="false" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">
                                            &times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                    </div>
                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>
                                            Warning!</strong>
                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
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

</asp:Content>
