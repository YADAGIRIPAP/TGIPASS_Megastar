<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="DepartmentAbstractLatestNew1.aspx.cs" Inherits="UI_TSiPASS_DepartmentAbstractLatestNew1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function Panel1() {

            document.getElementById('<%=Button2.ClientID %>').style.display = "none";

            var panel = document.getElementById("<%=tr1.ClientID %>");
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
    <style>
        .algnCenter
        {
            text-align: right;
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
    <div class="col-lg-12">
        <div class="panel panel-default">
            <div class="panel-heading" align="center">
                <h2 class="panel-title" style="font-weight: bold;">
                    Department wise performance Tracker
                    <%-- <a id="Button2" href="#" onclick="javascript:return Panel1();"
                                runat="server">--%>
                    <a id="pdfPrint" href="#" onclick="javascript:return Panel1();" runat="server">
                        <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                            style="float: right;" /></a> <a id="Button2" href="#" onserverclick="BtnPDF_Click"
                                runat="server">
                                <%--<img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                        alt="PDF" />--%></a> <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                            <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                                alt="Excel" /></a>
                </h2>
            </div>
            <div class="panel-body">
                <table align="center" cellpadding="10" cellspacing="5" style="width: 50%; font-family: 'Trebuchet MS'">
                    <tr>
                        <td colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboardNew.aspx"
                                Text="<< Back">
                            </asp:HyperLink>
                        </td>
                    </tr>
                    <tr align="center">
                        <td style="padding: 5px; margin: 5px" valign="top" align="center">
                            <table width="100%">
                                <tr align="center">
                                    <td style="padding: 5px; margin: 5px" align="center">
                                        <div class="input-group">
                                            <div class="input-group-addon">
                                                From Date
                                            </div>
                                            <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px"
                                                MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                Width="125px"></asp:TextBox>
                                            <%--<cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                </cc1:CalendarExtender>--%>
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
                                            <%--  <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                                </cc1:CalendarExtender>--%>
                                        </div>
                                    </td>
                                    <td style="padding: 5px; margin: 5px" align="right">
                                        <asp:Button ID="Button3" runat="server" CssClass="btn btn-default" TabIndex="10"
                                            Text="Submit" OnClick="BtnSave2_Click" />
                                    </td>
                                    <td  style="padding: 5px; text-align: right; margin: 5px" >
                                        <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height: 30px">
                        <td align="right">
                            <asp:Button ID="btnbdf" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10"
                                Text="Generate Pdf" OnClick="btnbdf_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr id="tr1" runat="server">
                        <td colspan="2" align="center" style="padding: 5px; margin: 5px" id="divPrint" runat="server">
                            <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                OnRowDataBound="grdDetails_RowDataBound" Width="100%" ShowFooter="True" OnRowCreated="grdDetails_RowCreated">
                                <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex +1 %>
                                            <%-- <asp:Label ID="lblyear" runat="server" Text='<%# Eval("YEAR") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblmonth" runat="server" Text='<%# Eval("MonthCode") %>' Visible="false"></asp:Label>--%>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Department Name" HeaderText="Department Name"></asp:BoundField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Approvals Applied"
                                        DataTextField="NoofapplicationsApplied">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Query Raised"
                                        DataTextField="QueryRaised">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Before Due Date"
                                        DataTextField="Pending Less than 3 Days">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="After Due Date"
                                        DataTextField="Pending More than 3 Days">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Scrutiny-Completed & Payment Pending"
                                        DataTextField="Number of payment received for">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Scrutiny-Completed"
                                        DataTextField="Completed">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Before Due Date"
                                        DataTextField="CompletedWithinDays">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="After Due Date"
                                        DataTextField="CompletedBeyondDays">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Department-Approved"
                                        DataTextField="Approved">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Rejected" DataTextField="Rejected">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <%--<asp:BoundField DataField="NOOFAPPLICATIONSDURING" HeaderText="During the month"></asp:BoundField>
                                <asp:BoundField DataField="NOOFAPPLICATIONSUPTO" HeaderText="Upto the month"></asp:BoundField>
                                <asp:BoundField DataField="APROVALAAREGIVENDURING" HeaderText="During the month"></asp:BoundField>
                                <asp:BoundField DataField="APROVALAAREGIVENUPTO" HeaderText="Upto the month"></asp:BoundField>
                                <asp:BoundField DataField="NoofApplicationsPending" HeaderText="No of Applications Pending"></asp:BoundField>
                                <asp:BoundField DataField="RejectedApplications" HeaderText="No of Applications Rejected"></asp:BoundField>
                                <asp:BoundField DataField="Yet_to_Start" HeaderText="Yet to Start"></asp:BoundField>
                                <asp:BoundField DataField="Initial_Stage" HeaderText="Initial Stage"></asp:BoundField>
                                <asp:BoundField DataField="Advanced_Stage" HeaderText="Advanced Stage"></asp:BoundField>
                                <asp:BoundField DataField="Commenced_Operations" HeaderText="Commenced Operations"></asp:BoundField>--%>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
