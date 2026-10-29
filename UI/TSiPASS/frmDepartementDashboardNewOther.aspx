<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmDepartementDashboardNewOther.aspx.cs" Inherits="UI_TSiPASS_frmDepartementDashboardNewOther" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript">




    </script>
    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx">Dashboard</a> </li>
                </ol>
            </div>
            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">
                                    Department Dashboard</h3>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                                    <tr>
                                        <td style="padding: 5px; margin: 5px">
                                            <div class="panel panel-default">
                                                <div class="panel-body" align="center">
                                                    <table cellpadding="3" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td style="font-size: 16px; text-align: center;" colspan="3">
                                                                <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Small" NavigateUrl="~/UI/TSiPASS/HomeDeptDashboard.aspx">Back</asp:HyperLink>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px; font-size: 16px;">
                                                                <b></b>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 395px" valign="top">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px; font-size: 16px;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 395px" valign="top">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px" valign="top">
                                                                <div class="list-group">
                                                                    <a href="#" class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Pre-Scrutiny
                                                                        Stage </b></a><a href="frmOtherServiceDepartmentsViewAppl.aspx?Stg=1&lbl=Pre-Scrutiny Applications Received"
                                                                            class="list-group-item"><span class="badge">
                                                                                <asp:Label ID="Label4" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                                </i>No of Application Received </a><a class="list-group-item" href="#"><i class="fa fa-fw fa-check">
                                                                                </i><b>Pre-Scrutiny-Completed</b> </a><a class="list-group-item" href="frmOtherServiceDepartmentsViewAppl.aspx?Stg=2&lbl=Pre-Scrutiny Applications Within 3 Days">
                                                                                    <span class="badge" style="background-color: #87D37C;">
                                                                                        <asp:Label ID="Label12" runat="server"></asp:Label>
                                                                                    </span><i class="fa fa-fw fa-calendar"></i>Within 3 Days</a> <a class="list-group-item"
                                                                                        href="frmOtherServiceDepartmentsViewAppl.aspx?Stg=3&lbl=Pre-Scrutiny Applications Beyond 3 Days">
                                                                                        <span class="badge" style="background-color: #d9534f;">
                                                                                            <asp:Label ID="Label18" runat="server"></asp:Label>
                                                                                        </span><i class="fa fa-fw fa-calendar"></i>Beyond 3 Days </a>
                                                                    <a class="list-group-item" href="frmOtherServiceDepartmentsViewAppl.aspx?Stg=4&lbl=Pre-Scrutiny Total Applications">
                                                                        <span class="badge">
                                                                            <asp:Label ID="Label3" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Total </a><a class="list-group-item" href="frmOtherServiceDepartmentsViewAppl.aspx?Stg=20">
                                                                            <span class="badge">
                                                                                <asp:Label ID="lblrejectedatprescrutiny" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>No of Applications Rejected </a>
                                                                    <a class="list-group-item" href="frmOtherServiceDepartmentsViewAppl.aspx?Stg=12&lbl=Applications Awaiting Payment">
                                                                        <span class="badge" style="background-color: #87D37C;">
                                                                            <asp:Label ID="Label11" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>No of Approvals Awaiting Payment
                                                                    </a><a class="list-group-item" href="#"><i class="fa fa-fw fa-check"></i><b>Pre-Scrutiny-Pending</b>
                                                                    </a><a class="list-group-item" href="frmOtherServiceDepartmentsViewAppl.aspx?Stg=5&Pre-Scrutiny-Pending Within 3 Days">
                                                                        <span class="badge" style="background-color: #87D37C;">
                                                                            <asp:Label ID="Label21" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Within 3 Days</a> <a class="list-group-item"
                                                                            href="frmOtherServiceDepartmentsViewAppl.aspx?Stg=6&Pre-Scrutiny-Pending Beyond 3 Days"><span
                                                                                class="badge" style="background-color: #d9534f;">
                                                                                <asp:Label ID="Label22" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>Beyond 3 Days </a><a class="list-group-item"
                                                                                href="frmOtherServiceDepartmentsViewAppl.aspx?Stg=7&lbl=Pre-Scrutiny-Pending Total Applications">
                                                                                <span class="badge">
                                                                                    <asp:Label ID="Label6" runat="server"></asp:Label>
                                                                                </span><i class="fa fa-fw fa-calendar"></i>Total </a><a class="list-group-item" href="frmOtherServiceDepartmentsViewAppl.aspx?Stg=8&lbl=Applications Awaiting Query Response">
                                                                                    <span class="badge" style="background-color: #87D37C;">
                                                                                        <asp:Label ID="Label8" runat="server"></asp:Label>
                                                                                    </span><i class="fa fa-fw fa-calendar"></i>No of Applications Awaiting Query Response</a>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top" style="width: 395px">
                                                                <div class="list-group">
                                                                    <a class="list-group-item" href="#"><b><i class="fa fa-fw fa-check"></i>Approval Stages</b></a>
                                                                    <a class="list-group-item" href="#"><b><i class="fa fa-fw fa-check"></i>Approval Under
                                                                        Process</b></a> <a class="list-group-item" href="frmDepartmentsApprovalProcessOtherServices.aspx?stg=1&lbl=Approval Under Process Within Time Limits">
                                                                            <span class="badge" style="background-color: #87D37C;">
                                                                                <asp:Label ID="Label1" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>Within Time Limits </a><a class="list-group-item"
                                                                                href="frmDepartmentsApprovalProcessOtherServices.aspx?stg=2&lbl=Approval Under Process Beyond Time Limits">
                                                                                <span class="badge" style="background-color: #d9534f;">
                                                                                    <asp:Label ID="Label2" runat="server"></asp:Label>
                                                                                </span><i class="fa fa-fw fa-calendar"></i>Beyond Time Limits</a> <a class="list-group-item">
                                                                                    <span class="badge">
                                                                                        <asp:Label ID="Label5" runat="server"></asp:Label>
                                                                                    </span><i class="fa fa-fw fa-calendar"></i>Total</a>
                                                                    <%--href="frmCFEDepartmentsApprovalProcess.aspx?stg=3&lbl=Total Approval Under Process"--%>
                                                                    <a class="list-group-item" href="#"><i class="fa fa-fw fa-check"></i><b>Approval Issued</b></a>
                                                                    <a class="list-group-item" href="frmOtherServiceDepartmentsViewAppl.aspx?Stg=13&lbl=Approval Issued Within Time Limit">
                                                                        <span class="badge" style="background-color: #87D37C;">
                                                                            <asp:Label ID="Label7" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Within Time Limits </a><a class="list-group-item"
                                                                            href="frmOtherServiceDepartmentsViewAppl.aspx?Stg=14&lbl=Approval Issued Beyond Time Limit">
                                                                            <span class="badge" style="background-color: #d9534f;">
                                                                                <asp:Label ID="Label9" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>Beyond Time Limits</a> <a class="list-group-item"
                                                                                href="frmOtherServiceDepartmentsViewAppl.aspx?Stg=15&lbl=Total Approval Issued"><span class="badge">
                                                                                    <asp:Label ID="Label10" runat="server"></asp:Label>
                                                                                </span><i class="fa fa-fw fa-calendar"></i>Total</a> <a class="list-group-item" href="frmOtherServiceDepartmentsViewAppl.aspx?Stg=16&lbl=Applications Rejected">
                                                                                    <span class="badge">
                                                                                        <asp:Label ID="Label17" runat="server"></asp:Label>
                                                                                    </span><i class="fa fa-fw fa-calendar"></i>No of Applications Rejected
                                                                    </a><a class="list-group-item" href="frmOtherServiceDepartmentsViewAppl.aspx?Stg=17&lbl=Applications appeal against Rejection">
                                                                        <span class="badge">
                                                                            <asp:Label ID="Label13" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>No of Applications appeal against Rejection
                                                                    </a>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px">
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                           <tr id="trgrid" runat="server" visible="false">
                                                            <td colspan="3" align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                    OnRowDataBound="GridView1_RowDataBound" OnRowCreated="GridView1_RowCreated" ShowFooter="True" Width="100%">
                                                                    <HeaderStyle Height="40px" CssClass="GridviewScrollC1Header" VerticalAlign="Middle" />
                                                                    <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                                    <PagerStyle Height="40px" CssClass="GridviewScrollC1Pager" />
                                                                    <FooterStyle Height="30px" CssClass="GridviewScrollC1Header" />
                                                                    <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No" HeaderStyle-Width="20px">
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex + 1%>
                                                                                <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                                <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:TemplateField>
                                                                        <asp:HyperLinkField DataTextField="ApplicationsReceived" HeaderText="No. of Applications Received">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>
                                                                        <asp:HyperLinkField DataTextField="Approved" HeaderText="Approved">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>
                                                                        <asp:HyperLinkField DataTextField="Rejected" HeaderText="Rejected">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>
                                                                        <asp:HyperLinkField DataTextField="PaymenPending" HeaderText="Payment Pending">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>
                                                                        <asp:HyperLinkField DataTextField="QueryResponsePending" HeaderText="Query Response Pending">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>
                                                                        <asp:HyperLinkField DataTextField="PreScrutinyPending_Within" HeaderText="Within">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>
                                                                        <asp:HyperLinkField DataTextField="PreScrutinyPending_Beyond" HeaderText="Beyond">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>
                                                                        <asp:HyperLinkField DataTextField="ApprovalPending_Within" HeaderText="Within">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>
                                                                        <asp:HyperLinkField DataTextField="ApprovalPending_Beyond" HeaderText="Beyond">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    &nbsp;
                                                    <div class="text-right">
                                                        <a href="#">View All Activity <i class="fa fa-arrow-circle-right"></i></a>
                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px">
                                            <table cellpadding="2" style="width: 100%">
                                                <tr>
                                                    <td style="width: 417px">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" align="center">
                                            <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                CssClass="GRD" ForeColor="#333333" Height="62px" PageSize="15" Width="100%" Visible="False">
                                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No" Visible="True">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex +1 %>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="IPName" HeaderText="IP Name" />
                                                    <asp:BoundField DataField="TotalWorkProposed" HeaderText="Total Works Proposed" />
                                                    <asp:BoundField DataField="TotalApproved" HeaderText="Total Approved" />
                                                    <asp:BoundField DataField="TotalInProgress" HeaderText="Total InProgress" />
                                                    <asp:BoundField DataField="TotalCompleted" HeaderText="Total Completed" />
                                                </Columns>
                                                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#B9D684" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                                <asp:HiddenField ID="hdfID" runat="server" />
                                <asp:HiddenField ID="hdfFlagID" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
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

