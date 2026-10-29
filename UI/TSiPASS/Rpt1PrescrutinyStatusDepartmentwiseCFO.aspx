<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="Rpt1PrescrutinyStatusDepartmentwiseCFO.aspx.cs"
    Inherits="LookupCA" Title=":: TSiPASS Online Management System ::" %>

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
    <script type="text/javascript" language="javascript">
        var win = new Object();
        function Popup(intval) {

            win = window.open("CFOPopup.aspx?UID=" + intval, "List", "scrollbars=yes,resizable=yes,width=780,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");
            //win = window.open("RptVillageOraganisationNameClickDetails.aspx?id="+intval, "List", "scrollbars=yes,resizable=yes,width=600,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");

        }
    </script>
    <%-- <script type="text/javascript" src="../../js/jquery.min.js"></script>

    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>

    <script type="text/javascript" src="../../js/gridviewScroll.min.js"></script>--%>
    <%--<script type="text/javascript">

        function pageLoad() {
            $('#<%=grdDetails.ClientID%>').gridviewScroll({
                width: 1090,
                height: "100%",
                arrowsize: 30,
                varrowtopimg: "../../images/arrowvt.png",
                varrowbottomimg: "../../images/arrowvb.png",
                harrowleftimg: "../../images/arrowhl.png",
                harrowrightimg: "../../images/arrowhr.png"
            });
        }

    </script>--%>
    <style>
        .algnRight
        {
            text-align: center;
        }
    </style>
    <%--datepicker added on 17/01/2019--%>
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
    <table runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-right: 10px; padding-top: 10px; padding-bottom: 20px; padding-left: 9px;
                height: 675px;" valign="top" align="center">
                <div class="panel panel-default">
                    <div class="panel-heading" style="text-align: center">
                        <h3 class="panel-title" style="font-weight: bold;">
                            CFO R2.2 Scrutiny - Query Details&nbsp;<a id="A1" href="#" onserverclick="BtnPDF_Click"
                                runat="server">
                                <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" /></a> <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                        <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a> <a id="pdfPrint" href="#" onclick="javascript:return Panel1();"
                                                runat="server">
                                                <img src="../../Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                                                    style="float: right;" /></a>
                        </h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 60%">
                            <tr id="trFilter" runat="server">
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboardCFO.aspx"
                                                    Text="<< Back">
                                                </asp:HyperLink>
                                            </td>
                                            <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        Status
                                                    </div>
                                                    <asp:DropDownList ID="ddlStatus" runat="server" class="form-control txtbox" Height="33px"
                                                        Width="180px">
                                                        <asp:ListItem Value="A">ALL</asp:ListItem>
                                                        <asp:ListItem Value="R">Query Raised</asp:ListItem>
                                                        <asp:ListItem Value="Y">Query Responded</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="center">
                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        From Date
                                                    </div>
                                                    <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                        Width="125px"></asp:TextBox>
                                                    <%--<cc1:calendarextender id="CalendarExtender2" runat="server" format="dd-MM-yyyy" targetcontrolid="txtFromDate">
                                                    </cc1:calendarextender>--%>
                                                </div>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        To Date
                                                    </div>
                                                    <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                        Width="125px"></asp:TextBox>
                                                    <%-- <cc1:calendarextender id="CalendarExtender1" runat="server" format="dd-MM-yyyy" targetcontrolid="txtTodate">
                                                    </cc1:calendarextender>--%>
                                                </div>
                                            </td>
                                            <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        District
                                                    </div>
                                                    <asp:DropDownList ID="ddldistrict" runat="server" class="form-control txtbox" Width="180px">
                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        Department
                                                    </div>
                                                    <asp:DropDownList ID="ddlDepartment" runat="server" class="form-control txtbox" Height="33px"
                                                        Width="180px">
                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="right">
                                                <%-- <asp:Button ID="Button2" runat="server" CssClass="btn btn-default" TabIndex="10"
                                                    Text="Submit" OnClick="BtnSave_Click" />--%>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%--<tr>
                                <td colspan="5">
                                    <table width="80%">

                                        <tr>
                                            <td style="padding: 5px; margin: 5px">From Date:   
                                                
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                </cc1:CalendarExtender>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">To Date:  
                                            
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                                </cc1:CalendarExtender>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>--%>
                            <tr align="center">
                                <td id="Td1" style="padding: 5px; margin: 5px" colspan="5" align="center" runat="server">
                                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-default" TabIndex="10"
                                        Text="Submit" OnClick="BtnSave_Click" />
                                </td>
                            </tr>
                            <%--<tr>
                                <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                    <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="13px"
                                        ForeColor="#006600"></asp:Label>
                                </td>
                            </tr>
                            <tr id="trBtns" runat="server">
                                <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                        OnClick="BtnSave_Click" TabIndex="10" Text="Search" Width="90px" />
                                    <asp:Button Visible="false" ID="BtnClear" runat="server" CausesValidation="False"
                                        CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                        Text="Cancel" ToolTip="To Clear  the Screen" Width="90px" />
                                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Height="32px"
                                        TabIndex="10" Text="Export" Width="90px" OnClick="BtnSave2_Click" />
                                    <asp:Button ID="BtnPDF" runat="server" CssClass="btn btn-warning" Height="32px" OnClick="BtnPDF_Click"
                                        TabIndex="10" Text="PDF" Width="90px" />
                                </td>
                            </tr>--%>
                            <tr>
                                <td align="center" class="style8" style="padding: 5px; margin: 5px; text-align: right;"
                                    valign="top">
                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 30px">
                                <td align="right">
                                    <asp:Button ID="btnbdf" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10"
                                        Text="Generate Pdf" OnClick="btnbdf_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                            <%--<tr>
                                <td align="left" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                    &nbsp;
                                </td>
                            </tr>--%>
                            <tr id="divPrint" runat="server">
                                <td align="center" colspan="3" style="padding: 5px; width: 100%; margin: 5px">
                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        ShowFooter="true" Width="100%" OnPageIndexChanging="grdDetails_PageIndexChanging"
                                        OnRowDataBound="grdDetails_RowDataBound" CssClass="floatingTable">
                                        <HeaderStyle Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                        <RowStyle CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                        <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="UID Number">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Name of the Unit" DataField="nameofunit" />
                                            <asp:BoundField HeaderText="Investment (Rs. in Cr)" DataField="Investment">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Category of Industry" DataField="PLoutionCategorys" />
                                            <asp:BoundField DataField="Approval Name" HeaderText="Approval Name" />
                                            <asp:BoundField HeaderText="Date Of Application" DataField="DateofApplication" />
                                            <asp:BoundField HeaderText="Date Of QueryRaise" DataField="DateOfQueryRaise" />
                                            <asp:BoundField HeaderText="Delay (Number of days)" DataField="DelayNumberOfDays">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Details of Query Raised" DataField="DetailsofQueryRaised" />
                                            <asp:BoundField HeaderText="Date of Response To Query" DataField="dateofresponsetoquery" />
                                            <%-- <asp:BoundField  HeaderText="Status"  DataField="Status" />--%>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr id="divExport" runat="server">
                                <td align="center" colspan="3" style="padding: 5px; width: 100%; margin: 5px">
                                    <asp:GridView ID="grdExport" runat="server" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="UID Number" DataField="UID_No" />
                                            <asp:BoundField HeaderText="Name of the Unit" DataField="nameofunit" />
                                            <asp:BoundField HeaderText="Investment (Rs. in Cr)" DataField="Investment">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Category of Industry" DataField="PLoutionCategorys" />
                                            <asp:BoundField DataField="Approval Name" HeaderText="Approval Name" />
                                            <asp:BoundField HeaderText="Date Of Application" DataField="DateofApplication" />
                                            <asp:BoundField HeaderText="Date Of QueryRaise" DataField="DateOfQueryRaise" />
                                            <asp:BoundField HeaderText="Delay (Number of days)" DataField="DelayNumberOfDays">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Details of Query Raised" DataField="DetailsofQueryRaised" />
                                            <asp:BoundField HeaderText="Date of Response To Query" DataField="dateofresponsetoquery" />
                                            <%-- <asp:BoundField  HeaderText="Status"  DataField="Status" />--%>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
