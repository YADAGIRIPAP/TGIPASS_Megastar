<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="IncentiveAbstractReport.aspx.cs" Inherits="UI_TSiPASS_IncentiveAbstractReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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

        //        $(function () {

        //            $('#MstLftMenu').remove();

        //        });
    </script>
    <script language="javascript" type="text/javascript">
        function Panel1() {

            document.getElementById('<%=A1.ClientID %>').style.display = "none";
            document.getElementById('<%=A2.ClientID %>').style.display = "none";
            <%--document.getElementById('<%=trFilter.ClientID %>').style.display = "none";--%>

            var panel = document.getElementById("<%=divPrint.ClientID %>");
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
    <%--Added datepicker on 18/01/2019--%>
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
    <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <div class="panel panel-default">
                    <div class="panel-heading" style="text-align: center">
                        <h3 class="panel-title" style="font-weight: bold;">
                            <asp:Label ID="lblHeading" runat="server">Abstract</asp:Label>
                            &nbsp;<a id="A1" href="#" onclick="javascript:return Panel1();" runat="server">
                                <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" /></a> <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                        <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a></h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="font-family: 'Trebuchet MS'">
                            <tr>
                                <td align="center" colspan="4" style="padding: 5px; margin: 5px">
                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboardNew.aspx"
                                        Text="<< Back">
                                    </asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" align="left">
                                    <table width="80%">
                                        <tr runat="server" id="trBetweenDates" visible="true">
                                            <td style="padding: 5px; margin: 5px">
                                                From Date:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                    Width="125px"></asp:TextBox>
                                                <%--<cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                </cc1:CalendarExtender>--%>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                To Date:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                    Width="125px"></asp:TextBox>
                                                <%-- <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                                </cc1:CalendarExtender>--%>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label352" runat="server" data-balloon-length="large" data-balloon="Please Select Proposed Location"
                                                    data-balloon-pos="down" CssClass="LBLBLACK">District : </asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlProp_intDistrictid" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" AutoPostBack="false">
                                                    <asp:ListItem Value="%">--ALL--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr align="center">
                                            <td style="padding: 5px; margin: 5px" colspan="4" align="center">
                                                <%--<asp:Button ID="btnGet" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Generate Report" Width="180px" OnClick="btnGet_Click" />--%>
                                                <asp:Button ID="Button3" runat="server" CssClass="btn btn-default" TabIndex="10"
                                                    Text="Submit" OnClick="BtnSave1_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <b>Srcutiny Stage</b>
                                </td>
                            </tr>
                            <tr id="div_Print" runat="server" style="width: 900px;">
                                <td align="left" colspan="6" style="padding: 5px; margin: 5px">
                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        OnRowDataBound="grdDetails_RowDataBound" OnPageIndexChanging="grdDetails_PageIndexChanging"
                                        ShowFooter="true" OnRowCreated="grdDetails_RowCreated" OnRowCommand="grdDetails_RowCommand">
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" Width="120px" />
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                    <%--<asp:Label ID="lblDistId" runat="server" Text='<%# Eval("DistId") %>' Visible="false"></asp:Label>--%>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <%--<asp:HyperLinkField HeaderText="District Name" DataTextField="District_Name">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>--%>
                                            <%--<asp:TemplateField HeaderText="District Name">
                                                <ItemStyle HorizontalAlign="left" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb1" Font-Underline="False" runat="server" Text='<%# Eval("District_Name") %>'
                                                        CommandName="DISTRICT" CommandArgument='<%# Eval("DISTCD")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:BoundField DataField="District_Name" HeaderText="District Name"></asp:BoundField>
                                            <asp:TemplateField HeaderText="Total Application">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb2" Font-Underline="False" runat="server" Text='<%# Eval("Total Application") %>'
                                                        CommandName="TOTALAPP" CommandArgument='<%# Eval("DISTCD")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Rejected">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb3" Font-Underline="False" runat="server" Text='<%# Eval("Total Rejected") %>'
                                                        CommandName="TOTREJECTED" CommandArgument='<%# Eval("DISTCD")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Scrutiny Completed Within">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb4" Font-Underline="False" runat="server" Text='<%# Eval("Scrutiny Completed Within") %>'
                                                        CommandName="SCRUTINYPENWITHIN" CommandArgument='<%# Eval("DISTCD")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Scrutiny Completed Beyond">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb5" Font-Underline="False" runat="server" Text='<%# Eval("Scrutiny Completed Beyond") %>'
                                                        CommandName="SCRUTINYBEYOND" CommandArgument='<%# Eval("DISTCD")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Scrutiny Completed">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb6" Font-Underline="False" runat="server" Text='<%# Eval("Total Scrutiny Completed") %>'
                                                        CommandName="TOTALSCRUTINYCOMPLETED" CommandArgument='<%# Eval("DISTCD")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Scrutiny Pending Within">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb7" Font-Underline="False" runat="server" Text='<%# Eval("Scrutiny Pending Within") %>'
                                                        CommandName="SCRUTINYPENDINGWITHIN" CommandArgument='<%# Eval("DISTCD")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Scrutiny Pending Beyond">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb8" Font-Underline="False" runat="server" Text='<%# Eval("Scrutiny Pending Beyond") %>'
                                                        CommandName="SCRUTINYPENDINGBEYOND" CommandArgument='<%# Eval("DISTCD")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Scrutiny Total Pending">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb9" Font-Underline="False" runat="server" Text='<%# Eval("Scrutiny Total Pending") %>'
                                                        CommandName="SCRUTINYPENDINGTOTAL" CommandArgument='<%# Eval("DISTCD")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Inspection Completed Within">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb10" Font-Underline="False" runat="server" Text='<%# Eval("Inspection Completed Within") %>'
                                                        CommandName="INSPECTIONWITHIN" CommandArgument='<%# Eval("DISTCD")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Inspection Completed Beyond">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb11" Font-Underline="False" runat="server" Text='<%# Eval("Inspection Completed Beyond") %>'
                                                        CommandName="INSPECTIONBEYOND" CommandArgument='<%# Eval("DISTCD")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Inspection Completed Total">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb12" Font-Underline="False" runat="server" Text='<%# Eval("Inspection Completed Total") %>'
                                                        CommandName="INSPECTIONTOTAL" CommandArgument='<%# Eval("DISTCD")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Inspection Pending Within">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb13" Font-Underline="False" runat="server" Text='<%# Eval("Inspection Pending Within") %>'
                                                        CommandName="INSPECTIONPENDINGWITHIN" CommandArgument='<%# Eval("DISTCD")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Inspection Pending Beyond">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb14" Font-Underline="False" runat="server" Text='<%# Eval("Inspection Pending Beyond") %>'
                                                        CommandName="INSPECTIONPENDINGBEYOND" CommandArgument='<%# Eval("DISTCD")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Inspection Pending Total">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb15" Font-Underline="False" runat="server" Text='<%# Eval("Inspection Pending Total") %>'
                                                        CommandName="INSPECTIONPENDINGTOTAL" CommandArgument='<%# Eval("DISTCD")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Refered COI Within">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb16" Font-Underline="False" runat="server" Text='<%# Eval("Refered COI Within") %>'
                                                        CommandName="REFEREDCOIWITHIN" CommandArgument='<%# Eval("DISTCD")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Refered COI Beyond">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb17" Font-Underline="False" runat="server" Text='<%# Eval("Refered COI Beyond") %>'
                                                        CommandName="REFEREDCOIBEYOND" CommandArgument='<%# Eval("DISTCD")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Refered COI Total">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb18" Font-Underline="False" runat="server" Text='<%# Eval("Refered COI Total") %>'
                                                        CommandName="REFERREDCOITOTAL" CommandArgument='<%# Eval("DISTCD")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Refered Pending COI Within">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb19" Font-Underline="False" runat="server" Text='<%# Eval("Refered Pending COI Within") %>'
                                                        CommandName="REFEREDPENDINGWITHIN" CommandArgument='<%# Eval("DISTCD")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Refered Pending COI Beyond">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb20" Font-Underline="False" runat="server" Text='<%# Eval("Refered Pending COI Beyond") %>'
                                                        CommandName="REFEREDPENDINGBEYOND" CommandArgument='<%# Eval("DISTCD")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Refered Pending COI Total">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb21" Font-Underline="False" runat="server" Text='<%# Eval("Refered Pending COI Total") %>'
                                                        CommandName="REFEREDPENDINGTOTAL" CommandArgument='<%# Eval("DISTCD")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DLC Approved Within">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb22" Font-Underline="False" runat="server" Text='<%# Eval("DLC Approved Within") %>'
                                                        CommandName="TOTALDLCWITHIN" CommandArgument='<%# Eval("DISTCD")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DLC Approved Beyond">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb23" Font-Underline="False" runat="server" Text='<%# Eval("DLC Approved Beyond") %>'
                                                        CommandName="TOTALDLCBEYOND" CommandArgument='<%# Eval("DISTCD")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total DLC Approved">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb24" Font-Underline="False" runat="server" Text='<%# Eval("Total DLC Approved") %>'
                                                        CommandName="TOTALDLCAPPROVED" CommandArgument='<%# Eval("DISTCD")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DLC Pending Within">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb25" Font-Underline="False" runat="server" Text='<%# Eval("DLC Pending Within") %>'
                                                        CommandName="DLCPENDINGWITHIN" CommandArgument='<%# Eval("DISTCD")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DLC Pending Beyond">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb26" Font-Underline="False" runat="server" Text='<%# Eval("DLC Pending Beyond") %>'
                                                        CommandName="DLCPENDINGBEYOND" CommandArgument='<%# Eval("DISTCD")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total DLC Pending">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb27" Font-Underline="False" runat="server" Text='<%# Eval("Total DLC Pending") %>'
                                                        CommandName="DLCPENDINGTOTAL" CommandArgument='<%# Eval("DISTCD")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">
                                            &times;</a> <strong>Success!</strong><asp:Label ID="Label2" runat="server"></asp:Label>
                                    </div>
                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>
                                            Warning!</strong>
                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                    </div>
                                </td>
                                   </tr>
                                <tr>
                                    <td align="left" style="font-size: 12pt; font-weight: bold">
                                        <b>Overal Applications Status(Time limit - 30 days from Application filed to SLC Approved
                                            date)</b>
                                    </td>
                                </tr>
                            </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
