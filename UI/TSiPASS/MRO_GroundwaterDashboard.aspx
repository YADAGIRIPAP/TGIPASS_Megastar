<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="MRO_GroundwaterDashboard.aspx.cs" Inherits="UI_TSiPASS_MRO_GroundwaterDashboard" %>

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
                                <h3 class="panel-title">MRO Ground water Dashboard</h3>
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
                                                                <b>Ground water</b>
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
                                                                    <a href="frmDepartmentsViewAppl_groundwater.aspx?Stg=1&lbl=No of Application Received" target="_blank" class="list-group-item">
                                                                        <span class="badge">
                                                                            <asp:Label ID="lbl_noofapplicationreceived" runat="server"></asp:Label></span>
                                                                        <i class="fa fa-fw fa-calendar"></i>No of Application Received
                                                                    </a>
                                                                    <a class="list-group-item" href="#">
                                                                        <i class="fa fa-fw fa-check"></i><b>Pre-Scrutiny-Completed</b>
                                                                    </a>
                                                                    <a class="list-group-item" href="frmDepartmentsViewAppl_groundwater.aspx?Stg=2&lbl=Pre-Scrutiny-Completed Within 2 Days" target="_blank">
                                                                        <span class="badge" style="background-color: #87D37C;">
                                                                            <asp:Label ID="lbl_completedwithin3days" runat="server"></asp:Label>
                                                                        </span>
                                                                        <i class="fa fa-fw fa-calendar"></i>Within 2 Days

                                                                    </a>
                                                                    <a class="list-group-item" href="frmDepartmentsViewAppl_groundwater.aspx?Stg=3&lbl=Pre-Scrutiny-Completed Beyond 2 Days" target="_blank">
                                                                        <span class="badge" style="background-color: #d9534f;">
                                                                            <asp:Label ID="lbl_completedbeyond3days" runat="server"></asp:Label>
                                                                        </span>
                                                                        <i class="fa fa-fw fa-calendar"></i>Beyond 2 Days 
                                                                    </a>
                                                                    <a class="list-group-item" href="frmDepartmentsViewAppl_groundwater.aspx?Stg=12&lbl=Pre-Scrutiny Completed Total Applications" target="_blank">
                                                                        <span class="badge">
                                                                            <asp:Label ID="lbl_completedtotal" runat="server"></asp:Label>
                                                                        </span>
                                                                        <i class="fa fa-fw fa-calendar"></i>Total 
                                                                    </a>
                                                                    <a class="list-group-item" href="frmDepartmentsViewAppl_groundwater.aspx?Stg=6&lbl=Total Query Raised  for No of Applications" target="_blank">
                                                                        <span class="badge">
                                                                            <asp:Label ID="lblMROTotalQueryRaisedforNoofApplications" runat="server"></asp:Label>
                                                                        </span>
                                                                        <i class="fa fa-fw fa-calendar"></i>Total Query Raised  for No of Applications
                                                                    </a>
                                                                    <a class="list-group-item" href="frmDepartmentsViewAppl_groundwater.aspx?Stg=9&lbl=No of Applications Query Responded" target="_blank">
                                                                        <span class="badge">
                                                                            <asp:Label ID="lblMRONoofApplicationsQueryResponded" runat="server"></asp:Label>
                                                                        </span>
                                                                        <i class="fa fa-fw fa-calendar"></i>No of Applications Query Responded 
                                                                    </a>
                                                                    <a class="list-group-item" href="frmDepartmentsViewAppl_groundwater.aspx?Stg=16&lbl=No of Applications Rejected" target="_blank">
                                                                        <span class="badge">
                                                                            <asp:Label ID="lblrejectedatprescrutiny" runat="server"></asp:Label>
                                                                        </span>
                                                                        <i class="fa fa-fw fa-calendar"></i>No of Applications Rejected 
                                                                    </a>
                                                                   
                                                                    <a class="list-group-item" href="#"><i class="fa fa-fw fa-check"></i>
                                                                        <b>Pre-Scrutiny-Pending(Forward to Ground water)</b>
                                                                    </a>
                                                                    <a class="list-group-item" href="frmDepartmentsViewAppl_groundwater.aspx?Stg=4&Pre-Scrutiny-Pending Within 2 Days" target="_blank">
                                                                        <span class="badge" style="background-color: #87D37C;">
                                                                            <asp:Label ID="lbl_fwdtogwwithin3days" runat="server"></asp:Label>
                                                                        </span>
                                                                        <i class="fa fa-fw fa-calendar"></i>Within 2 Days
                                                                    </a>
                                                                    <a class="list-group-item" href="frmDepartmentsViewAppl_groundwater.aspx?Stg=7&Pre-Scrutiny-Pending Beyond 2 Days" target="_blank">
                                                                        <span class="badge" style="background-color: #d9534f;">
                                                                            <asp:Label ID="lbl_fwdtogwbeyond3days" runat="server"></asp:Label>
                                                                        </span>
                                                                        <i class="fa fa-fw fa-calendar"></i>Beyond 2 Days 
                                                                    </a>
                                                                    <a class="list-group-item" href="frmDepartmentsViewAppl_groundwater.aspx?Stg=8&lbl=Pre-Scrutiny-Pending Total Applications" target="_blank">
                                                                        <span class="badge">
                                                                            <asp:Label ID="lbl_fwdtogwtotal" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Total 
                                                                    </a>
                                                                    <a class="list-group-item" href="frmDepartmentsViewAppl_groundwater.aspx?Stg=5&lbl=No of Applications Awaiting for Query Response" target="_blank">
                                                                        <span class="badge">
                                                                            <asp:Label ID="lblMRONoofApplicationsAwaitingforQueryResponse" runat="server"></asp:Label>
                                                                        </span>
                                                                        <i class="fa fa-fw fa-calendar"></i>No of Applications Awaiting for Query Response
                                                                    </a>
                                                                     <a class="list-group-item" href="#">
                                                                        <i class="fa fa-fw fa-check"></i><b>Pre-Scrutiny(Ground water Details)</b>
                                                                    </a>
                                                                     <a class="list-group-item" href="frmDepartmentsViewAppl_groundwater.aspx?Stg=27&lbl=No of Applications Forward to Ground water" target="_blank">
                                                                        <span class="badge" style="background-color: #87D37C;">
                                                                            <asp:Label ID="lblgw_NoofApplicationsForwardtoGroundwater" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>No of Applications Forward to Ground water
                                                                    </a>

                                                                    <a class="list-group-item" href="frmDepartmentsViewAppl_groundwater.aspx?Stg=21&lbl=No of Applications Recommended by Ground water" target="_blank">
                                                                        <span class="badge" style="background-color: #87D37C;">
                                                                            <asp:Label ID="lbl_recommendedbygw" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>No of Applications Recommended by Ground water
                                                                    </a>
                                                                    <a class="list-group-item" href="frmDepartmentsViewAppl_groundwater.aspx?Stg=22&lbl=No of Applications Not Recommended by Ground water" target="_blank">
                                                                        <span class="badge" style="background-color: #87D37C;">
                                                                            <asp:Label ID="lbl_notrecommendedbygw" runat="server"></asp:Label>
                                                                        </span>
                                                                        <i class="fa fa-fw fa-calendar"></i>No of Applications Not Recommended by Ground water
                                                                    </a>
                                                                    <a class="list-group-item" href="frmDepartmentsViewAppl_groundwater.aspx?Stg=23&lbl=Total Query Raised for No of Applications by Ground water" target="_blank">
                                                                        <span class="badge" style="background-color: #87D37C;">
                                                                            <asp:Label ID="lblDGWO_TotalQueryRaisedforNoofApplicationsbyGroundwater" runat="server"></asp:Label>
                                                                        </span>
                                                                        <i class="fa fa-fw fa-calendar"></i>Total Query Raised for No of Applications by Ground water
                                                                    </a>
                                                                    <a class="list-group-item" href="frmDepartmentsViewAppl_groundwater.aspx?Stg=24&lbl=No of Applications Query Responded to Ground water" target="_blank">
                                                                        <span class="badge" style="background-color: #87D37C;">
                                                                            <asp:Label ID="lblDGWO_NoofApplicationsQueryRespondedtoGroundwater" runat="server"></asp:Label>
                                                                        </span>
                                                                        <i class="fa fa-fw fa-calendar"></i>No of Applications Query Responded to Ground water
                                                                    </a>
                                                                    <a class="list-group-item" href="frmDepartmentsViewAppl_groundwater.aspx?Stg=25&lbl=No of Applications Awaiting for Query Response by Ground water" target="_blank">
                                                                        <span class="badge" style="background-color: #87D37C;">
                                                                            <asp:Label ID="lblDGWO_NoofApplicationsAwaitingforQueryResponsebyGroundwater" runat="server"></asp:Label>
                                                                        </span>
                                                                        <i class="fa fa-fw fa-calendar"></i>No of Applications Awaiting for Query Response by Ground water
                                                                    </a>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">&nbsp;
                                                            </td>
                                                            <td valign="top" style="width: 395px">
                                                                <div class="list-group">
                                                                    <a class="list-group-item" href="#"><b><i class="fa fa-fw fa-check"></i>Approval Stages</b></a>
                                                                    <a class="list-group-item" href="#"><b><i class="fa fa-fw fa-check"></i>Approval Under Process</b></a>
                                                                    <a class="list-group-item" href="frmDepartmentsViewAppl_groundwater.aspx?stg=11&lbl=Approval Under Process Within Time Limits" target="_blank">
                                                                        <span class="badge" style="background-color: #87D37C;">
                                                                            <asp:Label ID="lbl_approvalwithintimelimits" runat="server"></asp:Label>
                                                                        </span>
                                                                        <i class="fa fa-fw fa-calendar"></i>Within Time Limits 
                                                                    </a>
                                                                    <a class="list-group-item" href="frmDepartmentsViewAppl_groundwater.aspx?stg=10&lbl=Approval Under Process Beyond Time Limits" target="_blank">
                                                                        <span class="badge" style="background-color: #d9534f;">
                                                                            <asp:Label ID="lbl_approvalbeyondtimelimits" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Beyond Time Limits
                                                                    </a>
                                                                    <a class="list-group-item" href="frmDepartmentsViewAppl_groundwater.aspx?stg=17&lbl=Total Applications  Under Approval Process" target="_blank">
                                                                        <span class="badge">
                                                                            <asp:Label ID="lbl_approvalundertotal" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Total
                                                                    </a>

                                                                    <a class="list-group-item" href="frmDepartmentsViewAppl_groundwater.aspx?stg=18&lbl=Total Applications Rejected by District Ground water" target="_blank">
                                                                        <span class="badge" style="background-color: #87D37C;">
                                                                            <asp:Label ID="lblDWGO_totalApplicationsRejectedbyDistrictGroundwater" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Total Applications Rejected by District Ground water
                                                                    </a>

                                                                    <a class="list-group-item" href="frmDepartmentsViewAppl_groundwater.aspx?stg=19&lbl=Total Letters to be upload which rejetced by District Ground Water" target="_blank">
                                                                        <span class="badge" style="background-color: #87D37C;">
                                                                            <asp:Label ID="lblDWGO_TotalLetterstobeuploadwhichrejetcedbyDistrictGroundWater" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Total Letters to be upload which rejetced by District Ground Water
                                                                    </a>
                                                                    <a class="list-group-item" href="#">
                                                                        <i class="fa fa-fw fa-check"></i><b>Approval Issued</b>
                                                                    </a>
                                                                    <a class="list-group-item" href="frmDepartmentsViewAppl_groundwater.aspx?Stg=13&lbl=Approval Issued Within Time Limit" target="_blank">
                                                                        <span class="badge" style="background-color: #87D37C;">
                                                                            <asp:Label ID="lbl_approvalissuedwithintimelimits" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Within Time Limits 
                                                                    </a>
                                                                    <a class="list-group-item" href="frmDepartmentsViewAppl_groundwater.aspx?Stg=14&lbl=Approval Issued Beyond Time Limit" target="_blank">
                                                                        <span class="badge" style="background-color: #d9534f;">
                                                                            <asp:Label ID="lbl_approvalissuedbeyondtimelimits" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Beyond Time Limits
                                                                    </a>
                                                                    <a class="list-group-item" href="frmDepartmentsViewAppl_groundwater.aspx?Stg=15&lbl=Total Approval Issued" target="_blank"><span class="badge">
                                                                        <asp:Label ID="lbl_approvalissuedtotal" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Total
                                                                    </a>
                                                                    <a class="list-group-item" href="frmDepartmentsViewAppl_groundwater.aspx?Stg=20&lbl=Applications Rejected at Approval Stage" target="_blank">
                                                                        <span class="badge">
                                                                            <asp:Label ID="lbl_approvalisssuedrejected" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>No of Applications Rejected
                                                                    </a>
                                                                    <a class="list-group-item" href="frmDepartmentsViewAppl_groundwater.aspx?Stg=26&lbl=Total Uploaded Letters for Rejetced Applications by District Ground Water" target="_blank"><span class="badge">
                                                                        <asp:Label ID="lbl_TotalUploadedLettersforRejetcedApplicationsbyDistrictGroundWater" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>Total Uploaded Letters for Rejetced Applications by District Ground Water 
                                                                    </a>

                                                                    
                                                                    <a class="list-group-item" href="#">
                                                                        <i class="fa fa-fw fa-check"></i><b>Pre-Scrutiny(TRANSCO Department Details)</b>
                                                                    </a>
                                                                    <a class="list-group-item" href="frmDepartmentsViewAppl_groundwater.aspx?Stg=28&lbl=No of Applications Forward to TRANSCO" target="_blank">
                                                                        <span class="badge" style="background-color: #87D37C;">
                                                                            <asp:Label ID="lblTransco_NoofApplicationsForwardtoTransco" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>No of Applications Forward to TRANSCO Department
                                                                    </a>

                                                                    <a class="list-group-item" href="frmDepartmentsViewAppl_groundwater.aspx?Stg=29&lbl=No of Applications Recommended by TRANSCO" target="_blank">
                                                                        <span class="badge" style="background-color: #87D37C;">
                                                                            <asp:Label ID="lbl_recommendedbytransco" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>No of Applications Recommended by TRANSCO Department
                                                                    </a>
                                                                    <a class="list-group-item" href="frmDepartmentsViewAppl_groundwater.aspx?Stg=30&lbl=No of Applications Not Recommended by TRANSCO" target="_blank">
                                                                        <span class="badge" style="background-color: #87D37C;">
                                                                            <asp:Label ID="lbl_notrecommendedbytransco" runat="server"></asp:Label>
                                                                        </span>
                                                                        <i class="fa fa-fw fa-calendar"></i>No of Applications Not Recommended by TRANSCO Department
                                                                    </a>
                                                                    <a class="list-group-item" href="frmDepartmentsViewAppl_groundwater.aspx?Stg=31&lbl=Total Query Raised for No of Applications by TRANSCO" target="_blank">
                                                                        <span class="badge" style="background-color: #87D37C;">
                                                                            <asp:Label ID="lblTRANSCO_TotalQueryRaisedforNoofApplicationsbyTRANSCO" runat="server"></asp:Label>
                                                                        </span>
                                                                        <i class="fa fa-fw fa-calendar"></i>Total Query Raised for No of Applications by TRANSCO Department
                                                                    </a>
                                                                    <a class="list-group-item" href="frmDepartmentsViewAppl_groundwater.aspx?Stg=32&lbl=No of Applications Query Responded to TRANSCO" target="_blank">
                                                                        <span class="badge" style="background-color: #87D37C;">
                                                                            <asp:Label ID="lblTRANSCO_NoofApplicationsQueryRespondedtoTRANSCO" runat="server"></asp:Label>
                                                                        </span>
                                                                        <i class="fa fa-fw fa-calendar"></i>No of Applications Query Responded to TRANSCO Department
                                                                    </a>
                                                                    <a class="list-group-item" href="frmDepartmentsViewAppl_groundwater.aspx?Stg=33&lbl=No of Applications Awaiting for Query Response by TRANSCO" target="_blank">
                                                                        <span class="badge" style="background-color: #87D37C;">
                                                                            <asp:Label ID="lbltransco_NoofApplicationsAwaitingforQueryResponsebytransco" runat="server"></asp:Label>
                                                                        </span>
                                                                        <i class="fa fa-fw fa-calendar"></i>No of Applications Awaiting for Query Response by TRANSCO Department
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
                                                                        <asp:HyperLinkField DataTextField="Approved" Target="_blank" HeaderText="Approved">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>
                                                                        <asp:HyperLinkField DataTextField="Rejected" Target="_blank" HeaderText="Rejected">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>
                                                                        <asp:HyperLinkField DataTextField="RecommenedbyGW" Target="_blank" HeaderText="Recommended by Ground water">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>
                                                                        <asp:HyperLinkField DataTextField="NOTRecommenedbyGW" Target="_blank" HeaderText="Not Recommended by Ground water">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>
                                                                              <asp:HyperLinkField DataTextField="RecommenedbyTRANSCO" Target="_blank" HeaderText="Recommended by TRANSCO">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>
                                                                        <asp:HyperLinkField DataTextField="NOTRecommenedbyTRANSCO" Target="_blank" HeaderText="Not Recommended by TRANSCO">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>
                                                                        <asp:HyperLinkField DataTextField="PreScrutinyPending_Within" Target="_blank" HeaderText="Within">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>
                                                                        <asp:HyperLinkField DataTextField="PreScrutinyPending_Beyond" Target="_blank" HeaderText="Beyond">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>
                                                                        <asp:HyperLinkField DataTextField="ApprovalPending_Within" Target="_blank" HeaderText="Within">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>
                                                                        <asp:HyperLinkField DataTextField="ApprovalPending_Beyond" Target="_blank" HeaderText="Beyond">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>
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

