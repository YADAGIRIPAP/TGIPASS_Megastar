<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="RPT_GroundwaterDistrictwise.aspx.cs" Inherits="UI_TSiPASS_RPT_GroundwaterDistrictwise" %>

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
        .algnCenter {
            text-align: right;
        }
    </style>

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
            <div class="panel-heading" align="center">
                <h2 class="panel-title" style="font-weight: bold;">Ground Water District Wise Report
                    <a id="pdfPrint" href="#" onclick="javascript:return Panel1();" runat="server">
                        <img src="../../Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                            style="float: right;" /></a> <a id="Button2" href="#" onserverclick="BtnPDF_Click"
                                runat="server">
                                <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" /></a> <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                        <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a>
                </h2>
            </div>
            <div class="panel-body">
                <table align="center" cellpadding="10" cellspacing="5" style="width: 50%; font-family: 'Trebuchet MS'">
                    <tr>
                        <td colspan="4"></td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/HomeDeptDashboard.aspx"
                                Text="<< Back">
                            </asp:HyperLink>
                        </td>
                    </tr>

                    <tr style="height: 30px">
                        <td align="right">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="District"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%--DISTRICTID--%>
                                            <%#Eval("DISTRICT") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Total Applications"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TotalApplications" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TotalApplications") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Total"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%--TotalPrescrunitypendinginMROappl--%>
                                            <asp:HyperLink ID="hyp_TotalPrescrunitypendinginMROappl" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TotalPrescrunitypendinginMROappl") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Current"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TotCurr_PrescrunitypendinginMROappl" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TotCurr_PrescrunitypendinginMROappl") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="beyond 14 days"
                                        ItemStyle-HorizontalAlign="Center">
                                        <%--  totalPrescrunitypendingMRObeyond14days--%>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_totalPrescrunitypendingMRObeyond14days" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("totalPrescrunitypendingMRObeyond14days") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Total"
                                        ItemStyle-HorizontalAlign="Center">
                                        <%-- TotalQueryraisedbyMROappl--%>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TotalQueryraisedbyMROappl" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TotalQueryraisedbyMROappl") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Current"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TotCurr_QueryraisedbyMROappl" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TotCurr_QueryraisedbyMROappl") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="beyond 7 days,no response from applicant"
                                        ItemStyle-HorizontalAlign="Center">
                                        <%--TotalMROQueryraisedNoresponsebyapplbeyond7days--%>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TotalMROQueryraisedNoresponsebyapplbeyond7days" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TotalMROQueryraisedNoresponsebyapplbeyond7days") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Total"
                                        ItemStyle-HorizontalAlign="Center">
                                        <%--TotalQueryrespondedtoMROappl--%>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TotalQueryrespondedtoMROappl" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TotalQueryrespondedtoMROappl") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Current"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TotCurr_QueryrespondedtoMROappl" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TotCurr_QueryrespondedtoMROappl") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="beyond 7 days,No action taken"
                                        ItemStyle-HorizontalAlign="Center">
                                        <%-- TotalQueryrespondedapplnoactionbeyond7daysMRO--%>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TotalQueryrespondedapplnoactionbeyond7daysMRO" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TotalQueryrespondedapplnoactionbeyond7daysMRO") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Total"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TotalPrescrunityrejectedMROappl" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TotalPrescrunityrejectedMROappl") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Total"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TotalapplforwardtoDGWOappl" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TotalapplforwardtoDGWOappl") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Current"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TotCurr_applforwardtoDGWOappl" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TotCurr_applforwardtoDGWOappl") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="beyond 7 days"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_totalapplpendinginDGWObeyond7days" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("totalapplpendinginDGWObeyond7days") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Total"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TotalQueryraisedbyDGWOappl" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TotalQueryraisedbyDGWOappl") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Current"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TotCurr_QueryraisedbyDGWOappl" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TotCurr_QueryraisedbyDGWOappl") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="beyond 7 days,No response from applicant"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TotalDGWOQueryraisedNoresponsebyapplbeyond7days" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TotalDGWOQueryraisedNoresponsebyapplbeyond7days") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Total"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TotalQueryrespondedDGwoappl" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TotalQueryrespondedDGwoappl") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Current"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TotCurr_QueryrespondedDGwoappl" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TotCurr_QueryrespondedDGwoappl") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="beyond 7 days,No action taken"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TotalQueryrespondedapplnoactionbeyond7daysDGWO" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TotalQueryrespondedapplnoactionbeyond7daysDGWO") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Total"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TotalApprovedbyDGWOappl" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TotalApprovedbyDGWOappl") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="With in Time limit"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_DGWOApprovedwithintimelimit" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("DGWOApprovedwithintimelimit") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="beyond Time limit"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_DGWOapprovedbeyondtimelimit" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("DGWOapprovedbeyondtimelimit") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Total"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TotalRejectedbyDGWOappl" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TotalRejectedbyDGWOappl") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>



                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Total"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TotalApprovedbyMROappl" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TotalApprovedbyMROappl") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Within Time limit"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_MROApprovedwithintimelimit" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("MROApprovedwithintimelimit") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="beyond Time limit"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_MROapprovedbeyondtimelimit" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("MROapprovedbeyondtimelimit") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Total"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TotalApprovalRejectedbyMROappl" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TotalApprovalRejectedbyMROappl") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="DWGO rejected Doc Uploaded"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_DWGOrejecteddocuploadedbyMRO" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("DWGOrejecteddocuploadedbyMRO") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="DWGO rejected Doc Upload pending"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_DWGOrejecteddocuploadpendingbyMRO" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("DWGOrejecteddocuploadpendingbyMRO") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>

                                    <%--TRANSCO--%>

                                      <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Total"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TotalapplforwardtoTRANSCOappl" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TotalapplforwardtoTRANSCOappl") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Current"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TotCurr_applforwardtoTRANSCOappl" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TotCurr_applforwardtoTRANSCOappl") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="beyond 7 days"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_totalapplpendinginTRANSCObeyond7days" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("totalapplpendinginTRANSCObeyond7days") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Total"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TotalQueryraisedbyTRANSCOappl" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TotalQueryraisedbyTRANSCOappl") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Current"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TotCurr_QueryraisedbyTRANSCOappl" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TotCurr_QueryraisedbyTRANSCOappl") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="beyond 7 days,No response from applicant"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TotalTRANSCOQueryraisedNoresponsebyapplbeyond7days" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TotalTRANSCOQueryraisedNoresponsebyapplbeyond7days") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Total"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TotalQueryrespondedTRANSCOappl" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TotalQueryrespondedTRANSCOappl") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Current"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TotCurr_QueryrespondedTRANSCOappl" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TotCurr_QueryrespondedTRANSCOappl") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="beyond 7 days,No action taken"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TotalQueryrespondedapplnoactionbeyond7daysTRANSCO" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TotalQueryrespondedapplnoactionbeyond7daysTRANSCO") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Total"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TotalApprovedbyTRANSCOappl" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TotalApprovedbyTRANSCOappl") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="With in Time limit"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TRANSCOApprovedwithintimelimit" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TRANSCOApprovedwithintimelimit") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="beyond Time limit"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TRANSCOapprovedbeyondtimelimit" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TRANSCOapprovedbeyondtimelimit") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Total"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hyp_TotalRejectedbyTRANSCOappl" ItemStyle-HorizontalAlign="Center" runat="server" Text='<%#Eval("TotalRejectedbyTRANSCOappl") %>'>HyperLink</asp:HyperLink>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>


                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

