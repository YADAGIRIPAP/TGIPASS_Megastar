<%@ Page Title=":: TSiPASS : Works wise Report " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>

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
                                <h3 class="panel-title">Entrepreneur Dashboard</h3>
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
                                                                <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Small" NavigateUrl="~/UI/TSiPASS/HomeDashboard.aspx">Back</asp:HyperLink>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px; font-size: 16px;">
                                                                <b>Consent for Establishment</b>
                                                            </td>
                                                            <td style="width: 30px">&nbsp;
                                                            </td>
                                                            <td style="width: 395px" valign="top">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px; font-size: 16px;">&nbsp;
                                                            </td>
                                                            <td style="width: 30px">&nbsp;
                                                            </td>
                                                            <td style="width: 395px" valign="top">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px" valign="top">
                                                                <div class="list-group">
                                                                    <a href="frmQuesstionniareReg.aspx" class="list-group-item"><span class="badge">
                                                                        <asp:Label ID="Label4" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar"></i>Questionnaire </a>
                                                                    <%--<a class="list-group-item" href="frmEntrepreneurDetails.aspx">
                                                <span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label5" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i> In Complete (Draft) </a>--%>
                                                                    <a class="list-group-item" href="frmDepartmentApprovalDetails.aspx"><span class="badge">
                                                                        <asp:Label ID="Label6" runat="server"></asp:Label>
                                                                    </span><b><i class="fa fa-fw fa-check"></i>Common Application Form </b></a><a class="list-group-item"
                                                                        href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approvals Required as per TS-iPASS'>
                                                                        <span class="badge">
                                                                            <asp:Label ID="Label7" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Approvals Required as per TS-iPASS</a>
                                                                    <a class="list-group-item" href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approvals already Obtained'>
                                                                        <span class="badge">
                                                                            <asp:Label ID="Label8" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Approvals already obtained</a><a class="list-group-item"
                                                                            href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approvals - Applied now'>
                                                                            <i class="fa fa-fw fa-calendar"></i>Approvals - Applied now <span class="badge">
                                                                                <asp:Label ID="Label10" runat="server"></asp:Label>
                                                                            </span></a>
                                                                    <%--<a class="list-group-item" href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approvals - Payment Done'>
                                                <span class="badge">
                                                <asp:Label ID="Label9" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Approvals - Payment Done </a>--%>
                                                                    <a class="list-group-item" href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approvals - Yet to be applied'>
                                                                        <span class="badge" style="background-color: #d9534f;">
                                                                            <asp:Label ID="Label11" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Approvals - Yet to be applied</a>
                                                                    <a class="list-group-item" href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approvals already Obtained'>
                                                                        <b><i class="fa fa-fw fa-check"></i>Queries </b></a><a class="list-group-item" href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Queries Raised'>
                                                                            <%--                                              frmCFEDepartmentsViewApplStatus.aspx--%>
                                                                            <span class="badge" style="background-color: #d9534f;">
                                                                                <asp:Label ID="Label3" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>Raised </a><a class="list-group-item"
                                                                                href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Queries Responded'>
                                                                                <span class="badge">
                                                                                    <asp:Label ID="Label13" runat="server"></asp:Label>
                                                                                </span><i class="fa fa-fw fa-calendar"></i>Responded </a><%--<a class="list-group-item"
                                                                                    href="frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Queries -Yet to Respond"><span class="badge" style="background-color: #d9534f;">--%>
                                                                    <a class="list-group-item"
                                                                        href="frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Queries -Yet to Respond"><span class="badge" style="background-color: #d9534f;">
                                                                            <asp:Label ID="Label14" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Yet to Respond</a>
                                                                    <a class="list-group-item" href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Pre-Scrutiny - Rejected'>
                                                                        <%--                                              frmCFEDepartmentsViewApplStatus.aspx--%>
                                                                        <span class="badge" style="background-color: #d9534f;">
                                                                            <asp:Label ID="lblpreRejected" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Pre-Scrutiny - Rejected</a>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">&nbsp;
                                                            </td>
                                                            <td valign="top" style="width: 395px">
                                                                <div class="list-group">
                                                                    <a class="list-group-item" href="frmCFEDepartmentsViewApplStatus.aspx"><b><i class="fa fa-fw fa-check"></i>Payment </b></a><a class="list-group-item" href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approvals - Payment not required'>
                                                                        <span class="badge">
                                                                            <asp:Label ID="Label12" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Payment not required </a><a class="list-group-item"
                                                                            href="frmDepartmentApprovalPaymentDetails.aspx"><span class="badge">
                                                                                <asp:Label ID="Label15" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>Pre-Scrutiny Completed - Payment required</a><a
                                                                                class="list-group-item" href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approval - Paid for'><span
                                                                                    class="badge"><asp:Label ID="Label16" runat="server"></asp:Label>
                                                                                </span><i class="fa fa-fw fa-calendar"></i>Pre-Scrutiny Completed - Paid for
                                                                            </a><a class="list-group-item" href="frmDepartmentApprovalPaymentDetails.aspx">
                                                                                <span class="badge" style="background-color: #d9534f;">
                                                                                    <asp:Label ID="Label17" runat="server"></asp:Label>
                                                                                </span><i class="fa fa-fw fa-calendar"></i>Pre-Scrutiny Completed - Awaiting Payment</a>
                                                                    <a class="list-group-item" href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approvals already Obtained'>
                                                                        <b><i class="fa fa-fw fa-check"></i>Approvals Stage</b></a> <a class="list-group-item"
                                                                            href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approval - Issued'>
                                                                            <span class="badge">
                                                                                <asp:Label ID="Label1" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>Approval - Issued</a><a class="list-group-item"
                                                                                href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approval - Pending'>
                                                                                <span class="badge" style="background-color: #d9534f;">
                                                                                    <asp:Label ID="Label2" runat="server"></asp:Label>
                                                                                </span><i class="fa fa-fw fa-calendar"></i>Approval - Pending</a>

                                                                    <a class="list-group-item"
                                                                        href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approval - Rejected'>
                                                                        <span class="badge" style="background-color: #d9534f;">
                                                                            <asp:Label ID="lblaprRejected" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Approval - Rejected</a>
                                                                </div>
                                                                <br />
                                                                <div class="text-right">
                                                                    <img src="../../gif-new.gif" />
                                                                    <a href="RptApplicationWiseDetailedTraker.aspx" style="font-size: 16px">Track your application
                                                                        <i class="fa fa-arrow-circle-right"></i><i class="fa fa-arrow-circle-right"></i>
                                                                        <i class="fa fa-arrow-circle-right"></i></a>
                                                                </div>
                                                                <br />
                                                                <div class="text-right" id="TSSPDCL" runat="server">
                                                                    <img src="../../gif-new.gif" alt="" />
                                                                    <a href="RPTTSSPDCLforEntrep.aspx" style="font-size: 16px" target="_blank">TSSPDCL Feasibility
                                                                        Report <i class="fa fa-arrow-circle-right"></i><i class="fa fa-arrow-circle-right"></i><i class="fa fa-arrow-circle-right"></i></a>
                                                                </div>
                                                                <br />
                                                                <div class="text-right" id="Div1" runat="server">
                                                                    <img src="../../gif-new.gif" alt="" />
                                                                    <asp:HyperLink ID="hplPCB" runat="server" Target="_blank">Click here for Online Submission to PCB for CFE/CFO</asp:HyperLink>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px">&nbsp;
                                                            </td>
                                                            <td style="width: 30px">&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    &nbsp;
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px">
                                            <table cellpadding="2" style="width: 100%">
                                                <tr>
                                                    <td style="width: 417px">&nbsp;
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
