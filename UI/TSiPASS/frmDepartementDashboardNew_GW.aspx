<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmDepartementDashboardNew_GW.aspx.cs"  MasterPageFile="~/UI/TSiPASS/CCMaster.master" Inherits="UI_TSIPASS_frmDepartementDashboardNew_GW" %>

  
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
    <script type="text/javascript" language="javascript">
</script>
    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="HomeDashboard.aspx">Dashboard</a> </li>
                </ol>

            </div>
            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">Ground water Dashboard</h3>
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
                                                                    <a href="frmViewAppl_groundwaterDepartmentuser.aspx?Stg=1&lbl=Pre-Scrutiny Applications Received" target="_blank" class="list-group-item">
                                                                        <span class="badge">
                                                                            <asp:Label ID="lbl_noofapplicationreceived" runat="server"></asp:Label></span>
                                                                        <i class="fa fa-fw fa-calendar"></i>No of Application Received
                                                                    </a>
                                                                    <a class="list-group-item" href="#">
                                                                        <i class="fa fa-fw fa-check"></i><b>Pre-Scrutiny(QUERY Details)</b>
                                                                    </a>
                                                                    <a href="frmViewAppl_groundwaterDepartmentuser.aspx?Stg=6&lbl=Total Query Raised for Applications" target="_blank"  class="list-group-item">
                                                                        <span class="badge">
                                                                            <asp:Label ID="lbl_totalqueryraised" runat="server"></asp:Label></span>
                                                                        <i class="fa fa-fw fa-calendar"></i>Total Query Raised for Applications 
                                                                    </a>
                                                                    <a href="frmViewAppl_groundwaterDepartmentuser.aspx?Stg=7&lbl=Total Query Responded Applications" target="_blank"  class="list-group-item">
                                                                        <span class="badge">
                                                                            <asp:Label ID="lbl_queryresponded" runat="server"></asp:Label></span>
                                                                        <i class="fa fa-fw fa-calendar"></i>Total Query Responded Applications
                                                                    </a>
                                                                    <a class="list-group-item" href="#"><i class="fa fa-fw fa-check"></i>
                                                                        <b>Pre-Scrutiny-Pending(Recommend/Not recommend to MRO)</b>
                                                                    </a>
                                                                    <a class="list-group-item" target="_blank"  href="frmViewAppl_groundwaterDepartmentuser.aspx?Stg=2&Pre-Scrutiny-Pending Within 7 Days">
                                                                        <span class="badge" style="background-color: #87D37C;">
                                                                            <asp:Label ID="lbl_fwdtogwwithin3days" runat="server"></asp:Label>
                                                                        </span>
                                                                        <i class="fa fa-fw fa-calendar"></i>Within 7 Days
                                                                    </a>
                                                                    <a class="list-group-item" target="_blank"  href="frmViewAppl_groundwaterDepartmentuser.aspx?Stg=3&Pre-Scrutiny-Pending Beyond 7 Days">
                                                                        <span class="badge" style="background-color: #d9534f;">
                                                                            <asp:Label ID="lbl_fwdtogwbeyond3days" runat="server"></asp:Label>
                                                                        </span>
                                                                        <i class="fa fa-fw fa-calendar"></i>Beyond 7 Days 
                                                                    </a>
                                                                    <a class="list-group-item" target="_blank"  href="frmViewAppl_groundwaterDepartmentuser.aspx?Stg=4&lbl=Pre-Scrutiny-Pending Total Applications">
                                                                        <span class="badge">
                                                                            <asp:Label ID="lbl_fwdtogwtotal" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Total 
                                                                    </a>
                                                                      <a target="_blank"  href="frmViewAppl_groundwaterDepartmentuser.aspx?Stg=5&lbl=No of Application Awaiting for Query Response" class="list-group-item">
                                                                        <span class="badge">
                                                                            <asp:Label ID="lbl_queryresponsepending" runat="server"></asp:Label></span>
                                                                        <i class="fa fa-fw fa-calendar"></i>No of Application Awaiting for Query Response
                                                                    </a>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">&nbsp;
                                                            </td>
                                                            <td valign="top" style="width: 395px" runat="server">
                                                                <div class="list-group">
                                                                    <a class="list-group-item" href="#">
                                                                        <b><i class="fa fa-fw fa-check"></i>Approval Stages
                                                                        </b></a>         
                                                                     <a class="list-group-item" href="#">
                                                                         <b><i class="fa fa-fw fa-check"></i>(Application Recommended/<br />Not recommended to MRO)
                                                                         </b></a>
                                                                     <a class="list-group-item" target="_blank"  href="frmViewAppl_groundwaterDepartmentuser.aspx?Stg=8&lbl=Recommended to MRO Within 7 Days">
                                                                        <span class="badge" style="background-color: #87D37C;">
                                                                            <asp:Label ID="lbl_completedwithin3days" runat="server"></asp:Label>
                                                                        </span>
                                                                        <i class="fa fa-fw fa-calendar"></i>Recommended to MRO Within 7 Days
                                                                    </a>
                                                                    <a class="list-group-item" target="_blank"  href="frmViewAppl_groundwaterDepartmentuser.aspx?Stg=9&lbl=Recommended to MRO Beyond 7 Days">
                                                                        <span class="badge" style="background-color: #d9534f;">
                                                                            <asp:Label ID="lbl_completedbeyond3days" runat="server"></asp:Label>
                                                                        </span>
                                                                        <i class="fa fa-fw fa-calendar"></i>Recommended to MRO Beyond 7 Days 
                                                                    </a>
                                                                    <a class="list-group-item" target="_blank"  href="frmViewAppl_groundwaterDepartmentuser.aspx?Stg=10&lbl=Total Recommended to MRO">
                                                                        <span class="badge">
                                                                            <asp:Label ID="lbl_completedtotal" runat="server"></asp:Label>
                                                                        </span>
                                                                        <i class="fa fa-fw fa-calendar"></i>Total Recommended to MRO
                                                                    </a>
                                                                    <a class="list-group-item" target="_blank"  href="frmViewAppl_groundwaterDepartmentuser.aspx?Stg=11&lbl=No of Applications Not Recommend to MRO">
                                                                        <span class="badge">
                                                                            <asp:Label ID="lblrejectedatprescrutiny" runat="server"></asp:Label>
                                                                        </span>
                                                                        <i class="fa fa-fw fa-calendar"></i>No of Applications Not Recommend to MRO 
                                                                    </a>    
                                                                     <a class="list-group-item" href="#"><b><i class="fa fa-fw fa-check"></i>Approval Issued by MRO</b></a>
                                                                    <a class="list-group-item" target="_blank"  href="frmViewAppl_groundwaterDepartmentuser.aspx?Stg=12&lbl=Awaiting for Approval Near MRO">
                                                                        <span class="badge" style="background-color: #87D37C;">
                                                                            <asp:Label ID="lbl_awaitingforapprovalnearmro" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Awaiting for Approval Near MRO
                                                                    </a>

                                                                    <a class="list-group-item" target="_blank"  href="frmViewAppl_groundwaterDepartmentuser.aspx?Stg=13&lbl=Approval Issued by MRO">
                                                                            <span class="badge" style="background-color: #d9534f;">
                                                                                <asp:Label ID="lbl_approvalissuedbyMRO" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>Approval Issued by MRO</a> 

                                                                    <a class="list-group-item" target="_blank"  href="frmViewAppl_groundwaterDepartmentuser.aspx?Stg=16&lbl=No of Applications Rejected by MRO">
                                                                                    <span class="badge">
                                                                                        <asp:Label ID="lbl_approvalisssuedrejectedbyMRO" runat="server"></asp:Label>
                                                                                    </span><i class="fa fa-fw fa-calendar"></i>No of Applications Rejected by MRO
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
                                                                    OnRowDataBound="GridView1_RowDataBound"  ShowFooter="True" Width="100%">
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

                                                                        <asp:HyperLinkField DataTextField="ApplicationsReceived" Target="_blank" HeaderText="Applications Received">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>

                                                                        <asp:HyperLinkField DataTextField="TotalQueryraised" Target="_blank" HeaderText="Total Query raised">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>

                                                                        <asp:HyperLinkField DataTextField="QueryResponsePending" Target="_blank" HeaderText="Query Response Pending">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>

                                                                        <asp:HyperLinkField DataTextField="TotalQueryRespoded" Target="_blank" HeaderText="Query Responded">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>

                                                                        <asp:HyperLinkField DataTextField="Approved" Target="_blank" HeaderText="Recommeded to MRO">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>

                                                                        <asp:HyperLinkField DataTextField="Rejected" Target="_blank" HeaderText="Not Recommeded to MRO">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>

                                                                        <asp:HyperLinkField DataTextField="ApprovalPending_Within" Target="_blank" HeaderText="Recommeded to MRO Within Limit">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:HyperLinkField>

                                                                        <asp:HyperLinkField DataTextField="ApprovalPending_Beyond" Target="_blank" HeaderText="Recommeded to MRO Beyond Limit">
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

