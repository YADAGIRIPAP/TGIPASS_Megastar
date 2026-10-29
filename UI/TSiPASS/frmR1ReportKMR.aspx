<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" EnableEventValidation="false"
    AutoEventWireup="true" CodeFile="frmR1ReportKMR.aspx.cs" Inherits="TSTBDCReg1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <style type="text/css">
        .overlay
        {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 112px;
            background-color: Gray;
            filter: alpha(opacity=60);
            opacity: 0.9;
            -moz-opacity: 0.9;
        }
        .style8
        {
            color: #FF0000;
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

    

    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title" style="font-weight: bold">
                            <asp:Label ID="lblHeading" runat="server"></asp:Label> &nbsp;<a id="A1" href="#" onclick="javascript:return OpenPopup()" runat="server"> <%--onserverclick="btnExport_Click"--%>
                                <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="BtnSave2_Click" /></a></h3>
                    </div>
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
                                            </tr>
                                            <tr>
                                                <td align="right" style="padding: 5px; margin: 5px; text-align: right; vertical-align: top;"
                                                    valign="top">
                                                    <asp:ImageButton ID="Image4" Visible="false" runat="server" Height="40px" ImageUrl="~/images/pdf-icon4.jpg"
                                                        OnClientClick="window.print();return false" Width="40px" />
                                                    &nbsp;&nbsp; <a onclick="javascript:return OpenPopup()">
                                                        <asp:ImageButton ID="ImageButton1" runat="server" Height="40px" ImageUrl="~/images/printimage.jpg"
                                                            Width="40px" /></a> &nbsp;
                                                </td>
                                            </tr>--%>
                            <tr>
                                <td>
                                    <div id="PrintPDF" runat="server">
                                        <table width="100%">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" align="right">
                                             <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboard.aspx" Text="<< Back" >
                                </asp:HyperLink>
                                            </td>
                                                <td style="padding: 5px; margin: 5px; text-align: right;" valign="top">
                                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                        OnRowDataBound="grdDetails_RowDataBound" ShowFooter="True" Width="100%">
                                                        <HeaderStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                        <PagerStyle Height="40px" CssClass="GridviewScrollC1Pager" />
                                                        <FooterStyle Height="30px" CssClass="GridviewScrollC1Header" />
                                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                    <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                    <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                            </asp:TemplateField>
                                                            <asp:HyperLinkField DataTextField="No of Application" HeaderText="No of Applications"
                                                                NavigateUrl="frmstatus.aspx?status=A">
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="150px" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="No of Approvals Required" HeaderText="Approvals required as per Questionnaire">
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="No of Approvals Taken offline" HeaderText="Approvals already obtained">
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="Net Approvals required" HeaderText="Department Approvals required(Net)">
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="No of Approvals Applied for" HeaderText="Approvals Applied">
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                            </asp:HyperLinkField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="left" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                    <asp:Label ID="LblProjCost" Font-Size="14px" runat="server" CssClass="LBLBLACK">Total Capital Investment (Rs. in Crores)</asp:Label>
                                                    <asp:LinkButton Font-Underline="false" ID="lbtProjCost" runat="server" Font-Size="14px"
                                                         PostBackUrl="frmstatus1.aspx" target="_blank"></asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                    <asp:Label ID="Label482" runat="server" CssClass="LBLBLACK" Font-Size="14px" Width="621px">PRESCRUTINY STAGE : STATUS</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                    <asp:GridView ID="grdDetails0" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                        OnRowDataBound="grdDetails0_RowDataBound" ShowFooter="True" Width="100%">
                                                        <HeaderStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                        <PagerStyle Height="40px" CssClass="GridviewScrollC1Pager" />
                                                        <FooterStyle Height="30px" CssClass="GridviewScrollC1Header" />
                                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
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
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="150px" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="Query Raised" HeaderText="Query Raised">
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="150px" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="Completed" HeaderText="Completed">
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="150px" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="Total" HeaderText="Total">
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="150px" />
                                                            </asp:HyperLinkField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                    <asp:GridView ID="grdDetails3" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                        OnRowDataBound="grdDetails3_RowDataBound" ShowFooter="True" Width="100%">
                                                        <HeaderStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                        <PagerStyle Height="40px" CssClass="GridviewScrollC1Pager" />
                                                        <FooterStyle Height="30px" CssClass="GridviewScrollC1Header" />
                                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
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
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="Query Raised" HeaderText="Query Raised">
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="Total" HeaderText="Total">
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                            </asp:HyperLinkField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                    <asp:Label ID="Label483" runat="server" CssClass="LBLBLACK" Font-Size="14px" Width="400px">APPROVAL STAGE : STATUS</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                    <asp:GridView ID="grdDetails1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                        OnRowDataBound="grdDetails1_RowDataBound" ShowFooter="True" Width="100%">
                                                        <HeaderStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                        <PagerStyle Height="40px" CssClass="GridviewScrollC1Pager" />
                                                        <FooterStyle Height="30px" CssClass="GridviewScrollC1Header" />
                                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
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
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="Under Process" HeaderText="Under Process">
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="Rejected" HeaderText="Rejected">
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="Total" HeaderText="Total">
                                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                            </asp:HyperLinkField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label484" runat="server" CssClass="LBLBLACK" Font-Size="14px" Width="400px">TS-iPASS APPROVAL : UNIT WISE STATUS</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:GridView ID="grdDetails2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                        CssClass="GRD" ForeColor="#333333" Height="62px" OnRowDataBound="grdDetails2_RowDataBound"
                                                        PageSize="15" ShowFooter="True" Width="100%">
                                                        <HeaderStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                        <PagerStyle Height="40px" CssClass="GridviewScrollC1Pager" />
                                                        <FooterStyle Height="30px" CssClass="GridviewScrollC1Header" />
                                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
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
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center" style="padding: 5px; margin: 5px">
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
                </div>
            </div>
        </div>
    </div>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>
