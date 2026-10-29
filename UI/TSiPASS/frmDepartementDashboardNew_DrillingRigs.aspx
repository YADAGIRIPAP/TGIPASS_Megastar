<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmDepartementDashboardNew_DrillingRigs.aspx.cs" Inherits="UI_TSiPASS_frmDepartementDashboardNew_DrillingRigs" %>

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
                                <h3 class="panel-title">Drilling Rigs and Hand Bore Sets Dashboard</h3>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                                    <tr>
                                        <td style="padding: 5px; margin: 5px">
                                            <div class="panel panel-default">
                                                <div class="panel-body" align="center">
                                                    <table cellpadding="3" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td style="font-size: 16px; text-align: right;" colspan="3">
                                                                <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Small" NavigateUrl="~/UI/TSiPASS/HomeDeptDashboard.aspx">Back</asp:HyperLink>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px; font-size: 16px;">
                                                                <b>Drilling Rigs</b>
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
                                                                    <a href="#" class="list-group-item">
                                                                        <i class="fa fa-fw fa-check"></i><b>Pre-Scrutiny Stage </b>
                                                                    </a>
                                                                    <a href="frmViewAppl_DrillingRigsDepartmentuser.aspx?Stg=1&lbl=Pre-Scrutiny Applications Received" class="list-group-item">
                                                                        <span class="badge">
                                                                            <asp:Label ID="lbl_noofapplicationreceived" runat="server"></asp:Label></span>
                                                                        <i class="fa fa-fw fa-calendar"></i>No of Application Received

                                                                    </a>
                                                                    <a href="frmViewAppl_DrillingRigsDepartmentuser.aspx?Stg=2&lbl=Total Query Raised" class="list-group-item">
                                                                        <span class="badge">
                                                                            <asp:Label ID="lbl_totalqueryraised" runat="server"></asp:Label></span>
                                                                        <i class="fa fa-fw fa-calendar"></i>Total Query Raised for no of Application 

                                                                    </a>
                                                                    <a href="frmViewAppl_DrillingRigsDepartmentuser.aspx?Stg=6&lbl=Total Query Pending" class="list-group-item">
                                                                        <span class="badge">
                                                                            <asp:Label ID="lbl_queryresponsepending" runat="server"></asp:Label></span>
                                                                        <i class="fa fa-fw fa-calendar"></i>No of Application Awaiting for Query Response
                                                                    </a>
                                                                    <a href="frmViewAppl_DrillingRigsDepartmentuser.aspx?Stg=9&lbl=Total Query Responded" class="list-group-item">
                                                                        <span class="badge">
                                                                            <asp:Label ID="lbl_queryresponded" runat="server"></asp:Label></span>
                                                                        <i class="fa fa-fw fa-calendar"></i>No of Application Query Responded

                                                                    </a>
                                                                    <a class="list-group-item" href="#">
                                                                        <i class="fa fa-fw fa-check"></i><b>Approval Stages</b>

                                                                    </a>

                                                                    <a class="list-group-item" href="#"><b><i class="fa fa-fw fa-check"></i>Approval Under Process</b></a>
                                                                    <a class="list-group-item" href="frmViewAppl_DrillingRigsDepartmentuser.aspx?stg=11&lbl=Approval Under Process Within Time Limits">
                                                                        <span class="badge" style="background-color: #87D37C;">
                                                                            <asp:Label ID="lbl_approvalwithintimelimits" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Within Time Limits </a>
                                                                    <a class="list-group-item" href="frmViewAppl_DrillingRigsDepartmentuser.aspx?stg=12&lbl=Approval Under Process Beyond Time Limits">
                                                                        <span class="badge" style="background-color: #d9534f;">
                                                                            <asp:Label ID="lbl_approvalbeyondtimelimits" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Beyond Time Limits</a>
                                                                    <a class="list-group-item">
                                                                        <span class="badge">
                                                                            <asp:Label ID="lbl_approvalundertotal" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Total</a>
                                                                 
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">&nbsp;
                                                            </td>
                                                            <td valign="top" style="width: 395px" runat="server">

                                                                 <div class="list-group">
                                                                    <a class="list-group-item" href="#"><b><i class="fa fa-fw fa-check"></i>Approval Issued</b></a>
                                                                      <a class="list-group-item" href="frmViewAppl_DrillingRigsDepartmentuser.aspx?Stg=13&lbl=Approval Issued Within Time Limit">
                                                                        <span class="badge" style="background-color: #87D37C;">
                                                                            <asp:Label ID="lbl_approvalissuedwithintimelimits" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Within Time Limits </a>
                                                                    <a class="list-group-item" href="frmViewAppl_DrillingRigsDepartmentuser.aspx?Stg=14&lbl=Approval Issued Beyond Time Limit">
                                                                        <span class="badge" style="background-color: #d9534f;">
                                                                            <asp:Label ID="lbl_approvalissuedbeyondtimelimits" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Beyond Time Limits</a>
                                                                    <a class="list-group-item" href="frmViewAppl_DrillingRigsDepartmentuser.aspx?Stg=15&lbl=Total Approval Issued"><span class="badge">
                                                                        <asp:Label ID="lbl_approvalissuedtotal" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Total</a>
                                                                    <a class="list-group-item" href="frmViewAppl_DrillingRigsDepartmentuser.aspx?Stg=16&lbl=Applications Rejected">
                                                                        <span class="badge">
                                                                            <asp:Label ID="lbl_approvalisssuedrejected" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>No of Applications Rejected
                                                                    </a>

                                                             
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
                                                        <tr>
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
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:TemplateField>

                                                                        <asp:HyperLinkField DataTextField="ApplicationsReceived" Target="_blank" HeaderText="No. of Applications Received">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>

                                                                        <asp:HyperLinkField DataTextField="TotalQueryraised" Target="_blank" HeaderText="Total Query raised for Applications">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>

                                                                        <asp:HyperLinkField DataTextField="QueryResponsePending" Target="_blank" HeaderText="No. of Applications Awaiting for Response">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>

                                                                        <asp:HyperLinkField DataTextField="TotalQueryRespoded" Target="_blank" HeaderText="Total Applications Responded">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>

                                                                        <asp:HyperLinkField DataTextField="Approved" Target="_blank" HeaderText="Approved">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>

                                                                        <asp:HyperLinkField DataTextField="Rejected" Target="_blank" HeaderText="Rejected">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>

                                                                        <asp:HyperLinkField DataTextField="ApprovalPending_Within" Target="_blank" HeaderText="Within Approval Limit">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>

                                                                        <asp:HyperLinkField DataTextField="ApprovalPending_Beyond" Target="_blank" HeaderText="Beyond  Approval Limit">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    &nbsp;
                                                    <div class="text-right">
                                                       <%-- <a href="#">View All Activity <i class="fa fa-arrow-circle-right"></i></a>--%>
                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>

                                </table>

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
</asp:Content>

