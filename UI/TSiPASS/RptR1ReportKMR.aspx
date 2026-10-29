<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="RptR1ReportKMR.aspx.cs" Inherits="TSTBDCReg1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <style type="text/css">
        .style8
        {
            color: #FF0000;
            font-weight: bold;
        }
        .GridviewScrollC1Header TH, .GridviewScrollC1Header TD
        {
            padding: 5px;
            font-weight: bold;
            white-space: nowrap;
            border-right: 1px solid #F0F0F0;
            border-bottom: 1px solid #F0F0F0;
            background-color: #999999;
            color: #FFFFFF;
            text-align: left;
            vertical-align: bottom;
        }
        .GridviewScrollC1Item TD
        {
            padding: 5px;
            white-space: nowrap;
            border-right: 1px solid #F0F0F0;
            border-bottom: 1px solid #F0F0F0;
            background-color: #FFFFFF;
        }
        .GridviewScrollC1Pager
        {
            border-top: 1px solid #AAAAAA;
            background-color: #FFFFFF;
        }
        .GridviewScrollC1Pager TD
        {
            padding-top: 3px;
            font-size: 14px;
            padding-left: 5px;
            padding-right: 5px;
        }
        .GridviewScrollC1Pager A
        {
            color: #666666;
        }
        .GridviewScrollC1Pager SPAN
        {
            font-size: 16px;
            font-weight: bold;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("rptR1Print.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>

    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    R1: CM's DASHBOARD</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                                            <%-- <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top" class="style8"
                                                    align="center">
                                                    <asp:DropDownList ID="ddlProp_intDistrictid" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                        Height="33px" OnSelectedIndexChanged="ddlProp_intDistrictid_SelectedIndexChanged"
                                                        Width="180px" Visible="False">
                                                        <asp:ListItem>--District--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td align="right" style="padding: 5px; margin: 5px; text-align: right; vertical-align: top;"
                                                    valign="top">
                                                    <asp:ImageButton ID="Image4" Visible="false" runat="server" Height="40px" ImageUrl="~/images/pdf-icon4.jpg"
                                                        OnClientClick="window.print();return false" Width="40px" />
                                                    &nbsp;&nbsp; <a onclick="javascript:return OpenPopup()">
                                                        <asp:ImageButton ID="ImageButton1" runat="server" Height="40px" ImageUrl="~/images/printimage.jpg"
                                                            Width="40px" /></a> &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div id="PrintPDF" runat="server">
                                                        <table width="100%">
                                                            <tr>
                                                                <td align="center" class="style8" style="padding: 5px; margin: 5px; text-align: center;"
                                                                    valign="top">
                                                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="350px">Report as on: 30.03.2016</asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                        OnRowDataBound="grdDetails_RowDataBound" PageSize="15" ShowFooter="True" Width="100%">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                                                <ItemTemplate>
                                                                                    <%# Container.DataItemIndex + 1%>
                                                                                    <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                                    <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <ItemStyle Width="50px" />
                                                                            </asp:TemplateField>
                                                                            <asp:HyperLinkField DataTextField="No of Application" HeaderText="No of Applications"
                                                                                NavigateUrl="frmstatus.aspx?status=A">
                                                                                <ItemStyle HorizontalAlign="Center" Font-Bold="true" CssClass="text-center" Width="150px" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataTextField="No of Approvals Required" HeaderText="Approvals required as per Questionnaire">
                                                                                <ItemStyle HorizontalAlign="Center" Font-Bold="true" CssClass="text-center" Width="180px" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataTextField="No of Approvals Taken offline" HeaderText="Approvals already obtained">
                                                                                <ItemStyle HorizontalAlign="Center" Font-Bold="true" CssClass="text-center" Width="180px" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataTextField="Net Approvals required" HeaderText="Department Approvals required(Net)">
                                                                                <ItemStyle HorizontalAlign="Center" Font-Bold="true" CssClass="text-center" Width="180px" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataTextField="No of Approvals Applied for" HeaderText="Approvals Applied">
                                                                                <ItemStyle HorizontalAlign="Center" Font-Bold="true" CssClass="text-center" Width="180px" />
                                                                            </asp:HyperLinkField>
                                                                        </Columns>
                                                                        <HeaderStyle CssClass="GridviewScrollC1Header" />
                                                                        <RowStyle CssClass="GridviewScrollC1Item" />
                                                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                    <asp:Label ID="LblProjCost" Font-Size="14px" runat="server" CssClass="LBLBLACK" Font-Bold="True">Total Capital Investment (Rs. in Crores)</asp:Label>
                                                                    <asp:LinkButton Font-Underline="false" ID="lbtProjCost" runat="server" Font-Size="14px"
                                                                        Font-Bold="true" PostBackUrl="frmstatus1.aspx" target="_blank"></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                    <asp:Label ID="Label482" runat="server" CssClass="LBLBLACK" Font-Size="16px" Font-Bold="True"
                                                                        Width="621px">PRESCRUTINY STAGE : STATUS</asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                                    <asp:GridView ID="grdDetails0" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                        CssClass="GRD" ForeColor="#333333" Height="62px" OnRowDataBound="grdDetails0_RowDataBound"
                                                                        PageSize="15" ShowFooter="True" Width="100%">
                                                                        <FooterStyle CssClass="text-center" Height="40px" BackColor="#013161" Font-Bold="True"
                                                                            HorizontalAlign="Center" ForeColor="White" Font-Size="14px" />
                                                                        <RowStyle Height="40px" BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left"
                                                                            VerticalAlign="Middle" Font-Size="14px" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                                <ItemTemplate>
                                                                                    <%# Container.DataItemIndex + 1%>
                                                                                    <asp:HiddenField ID="HdfQueid0" runat="server" />
                                                                                    <asp:HiddenField ID="HdfApprovalid0" runat="server" />
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <ItemStyle Width="50px" />
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="DType" HeaderText="Description">
                                                                                <ItemStyle Width="150px" />
                                                                            </asp:BoundField>
                                                                            <asp:HyperLinkField DataTextField="No Query but Pending" HeaderText="Pending">
                                                                                <ItemStyle HorizontalAlign="Center" Font-Bold="true" CssClass="text-center" Width="150px" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataTextField="Query Raised" HeaderText="Query Raised">
                                                                                <ItemStyle HorizontalAlign="Center" Font-Bold="true" CssClass="text-center" Width="150px" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataTextField="Completed" HeaderText="Completed">
                                                                                <ItemStyle HorizontalAlign="Center" Font-Bold="true" CssClass="text-center" Width="150px" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataTextField="Total" HeaderText="Total">
                                                                                <ItemStyle HorizontalAlign="Center" Font-Bold="true" CssClass="text-center" Width="150px" />
                                                                            </asp:HyperLinkField>
                                                                        </Columns>
                                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                        <HeaderStyle Height="40px" BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True"
                                                                            ForeColor="White" Font-Size="14px" />
                                                                        <EditRowStyle BackColor="#B9D684" />
                                                                        <AlternatingRowStyle BackColor="White" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                    <asp:GridView ID="grdDetails3" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                        CssClass="GRD" ForeColor="#333333" Height="62px" OnRowDataBound="grdDetails3_RowDataBound"
                                                                        PageSize="15" ShowFooter="True" Width="100%">
                                                                        <FooterStyle CssClass="text-center" Height="40px" BackColor="#013161" Font-Bold="True"
                                                                            HorizontalAlign="Center" ForeColor="White" Font-Size="14px" />
                                                                        <RowStyle Height="40px" BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left"
                                                                            VerticalAlign="Middle" Font-Size="14px" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                                <ItemTemplate>
                                                                                    <%# Container.DataItemIndex + 1%>
                                                                                    <asp:HiddenField ID="HdfQueid3" runat="server" />
                                                                                    <asp:HiddenField ID="HdfApprovalid3" runat="server" />
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <ItemStyle Width="50px" />
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="DType" HeaderText="Description">
                                                                                <ItemStyle HorizontalAlign="Right" Width="220px" />
                                                                            </asp:BoundField>
                                                                            <asp:HyperLinkField DataTextField="Completed" HeaderText="Completed">
                                                                                <ItemStyle HorizontalAlign="Center" Font-Bold="true" CssClass="text-center" Width="180px" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataTextField="Query Raised" HeaderText="Query Raised">
                                                                                <ItemStyle HorizontalAlign="Center" Font-Bold="true" CssClass="text-center" Width="180px" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataTextField="Total" HeaderText="Total">
                                                                                <ItemStyle HorizontalAlign="Center" Font-Bold="true" CssClass="text-center" Width="180px" />
                                                                            </asp:HyperLinkField>
                                                                            <%--  <asp:BoundField DataField="DType" HeaderText="Description">
                                                        <ItemStyle Width="220px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Completed" HeaderText="Completed">
                                                        <ItemStyle Width="180px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Query Raised" HeaderText="Query Raised">
                                                        <ItemStyle Width="150px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="No Query but Pending" 
                                                        HeaderText="No querry, but Pending" />
                                                    <asp:BoundField DataField="Total" HeaderText="Total" />--%>
                                                                        </Columns>
                                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                        <HeaderStyle Height="40px" BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True"
                                                                            ForeColor="White" Font-Size="14px" />
                                                                        <EditRowStyle BackColor="#B9D684" />
                                                                        <AlternatingRowStyle BackColor="White" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                    <asp:Label ID="Label483" runat="server" CssClass="LBLBLACK" Font-Size="16px" Font-Bold="True"
                                                                        Width="400px">APPROVAL STAGE : STATUS</asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                                    <asp:GridView ID="grdDetails1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                        CssClass="GRD" ForeColor="#333333" Height="62px" OnRowDataBound="grdDetails1_RowDataBound"
                                                                        PageSize="15" ShowFooter="True" Width="100%">
                                                                        <FooterStyle CssClass="text-center" Height="40px" BackColor="#013161" Font-Bold="True"
                                                                            HorizontalAlign="Center" ForeColor="White" Font-Size="14px" />
                                                                        <RowStyle Height="40px" BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Center"
                                                                            VerticalAlign="Middle" Font-Size="14px" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                                <ItemTemplate>
                                                                                    <%# Container.DataItemIndex + 1%>
                                                                                    <asp:HiddenField ID="HdfQueid1" runat="server" />
                                                                                    <asp:HiddenField ID="HdfApprovalid1" runat="server" />
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <ItemStyle Width="50px" />
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="DType" HeaderText="Description">
                                                                                <ItemStyle HorizontalAlign="Left" Width="220px" />
                                                                            </asp:BoundField>
                                                                            <asp:HyperLinkField DataTextField="Approved" HeaderText="Approved">
                                                                                <ItemStyle HorizontalAlign="Center" Font-Bold="true" CssClass="text-center" Width="180px" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataTextField="Under Process" HeaderText="Under Process">
                                                                                <ItemStyle HorizontalAlign="Center" Font-Bold="true" CssClass="text-center" Width="180px" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataTextField="Rejected" HeaderText="Rejected">
                                                                                <ItemStyle HorizontalAlign="Center" Font-Bold="true" CssClass="text-center" Width="180px" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataTextField="Total" HeaderText="Total">
                                                                                <ItemStyle HorizontalAlign="Center" Font-Bold="true" CssClass="text-center" Width="180px" />
                                                                            </asp:HyperLinkField>
                                                                            <%-- <asp:BoundField HeaderText="Description" DataField="DType">
                                                        <ItemStyle Width="220px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Approved" DataField="Approved">
                                                        <ItemStyle Width="180px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Under Process" DataField="Under Process">
                                                        <ItemStyle Width="150px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Rejected" DataField="Rejected" />
                                                    <asp:BoundField HeaderText="Total" DataField="Total" />--%>
                                                                        </Columns>
                                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                        <HeaderStyle Height="40px" BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True"
                                                                            ForeColor="White" Font-Size="14px" />
                                                                        <EditRowStyle BackColor="#B9D684" />
                                                                        <AlternatingRowStyle BackColor="White" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="Label484" runat="server" CssClass="LBLBLACK" Font-Size="16px" Font-Bold="True"
                                                                        Width="400px">TS-iPASS APPROVAL : UNIT WISE STATUS</asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                                    <asp:GridView ID="grdDetails2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                        CssClass="GRD" ForeColor="#333333" Height="62px" OnRowDataBound="grdDetails2_RowDataBound"
                                                                        PageSize="15" ShowFooter="True" Width="100%">
                                                                        <FooterStyle CssClass="text-center" Height="40px" BackColor="#013161" Font-Bold="True"
                                                                            HorizontalAlign="Center" ForeColor="White" Font-Size="14px" />
                                                                        <RowStyle Height="40px" BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left"
                                                                            VerticalAlign="Middle" Font-Size="14px" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                                <ItemTemplate>
                                                                                    <%# Container.DataItemIndex + 1%>
                                                                                    <asp:HiddenField ID="HdfQueid2" runat="server" />
                                                                                    <asp:HiddenField ID="HdfApprovalid2" runat="server" />
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <ItemStyle Width="50px" />
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="DType" HeaderText="Description">
                                                                                <ItemStyle HorizontalAlign="Right" Width="220px" />
                                                                            </asp:BoundField>
                                                                            <asp:HyperLinkField DataTextField="Total Appliacations Fully Paid" HeaderText="Units">
                                                                                <ItemStyle HorizontalAlign="Right" Width="180px" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataTextField="Total Appliacations Approved with in Time Limits"
                                                                                HeaderText="% Approvals within time limits">
                                                                                <ItemStyle HorizontalAlign="Right" Width="180px" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataTextField="TotalAppliacationsApprovedbeyondTimeLimits" HeaderText="% Approvals beyond time limits">
                                                                                <ItemStyle HorizontalAlign="Right" Width="180px" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataTextField="Grand Total" HeaderText="Total">
                                                                                <ItemStyle Width="180px" />
                                                                            </asp:HyperLinkField>
                                                                            <%--  <asp:BoundField HeaderText="Description" DataField="DType">
                                                        <ItemStyle Width="220px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Total Applications fully paid" 
                                                        DataField="Total Appliacations Fully Paid">
                                                        <ItemStyle Width="180px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Total Applications Appd within time limits" 
                                                        DataField="Total Appliacations Approved with in Time Limits">
                                                        <ItemStyle Width="150px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Total Applications Appd beyond time limits" 
                                                        DataField="TotalAppliacationsApprovedbeyondTimeLimits" />
                                                    <asp:BoundField HeaderText="Grand Total " DataField="Grand Total" />--%>
                                                                        </Columns>
                                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                        <HeaderStyle Height="40px" BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True"
                                                                            ForeColor="White" Font-Size="14px" />
                                                                        <EditRowStyle BackColor="#B9D684" />
                                                                        <AlternatingRowStyle BackColor="White" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" style="padding: 5px; margin: 5px">
                                                                    <div id="success" runat="server" class="alert alert-success" visible="false">
                                                                        <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">
                                                                            ×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                                    </div>
                                                                    <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                                                        <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <asp:HiddenField ID="hdfID" runat="server" />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" ValidationGroup="group" />
                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" ValidationGroup="child" />
                                    <asp:HiddenField ID="hdfFlagID" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                    <div class="overlay">
                        <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
                        <div style="z-index: 1000; margin-left: -210px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
                            <img alt="" src="../../Resource/Images/Processing.gif" />
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>
