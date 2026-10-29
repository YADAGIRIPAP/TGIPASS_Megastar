<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    CodeFile="frmPattadarDashboard.aspx.cs" Inherits="UI_TSiPASS_frmPattadarDashboard" %>

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
                                    &nbsp; Pattadar Dashboard</h3>
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
                                                                <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Small" NavigateUrl="~/UI/TSiPASS/ADMandGDashboard.aspx">Back</asp:HyperLink>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 468px; font-size: 16px;">
                                                                <b>Consent for PattadarLand APPLICATIONS</b>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 395px" valign="top">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 468px; font-size: 16px;">
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
                                                            <td style="width: 468px" valign="top">
                                                                <div class="list-group">
                                                                    <a href="ViewPattadarAppliactions.aspx?Stg=3" class="list-group-item"><span class="badge">
                                                                        <asp:Label ID="lblTotAppl" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                        </i>No of Total Applications&nbsp; </a></a> <a class="list-group-item" href="ViewPattadarAppliactions.aspx?Stg=12">
                                                                            <span class="badge" style="background-color: #d9534f;">
                                                                                <asp:Label ID="LblPendng" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>No of Appliactions pending </a>
                                                                    <a class="list-group-item" href="ViewPattadarAppliactions.aspx?Stg=13"><span class="badge">
                                                                        <asp:Label ID="lblApproved" runat="server"></asp:Label>
                                                                    </span><i class="fa fa-fw fa-calendar"></i>No of Applications Approved </a><a class="list-group-item"
                                                                        href="ViewPattadarAppliactions.aspx?Stg=16"><span class="badge" style="background-color: #d9534f;">
                                                                            <asp:Label ID="lblRejctd" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>No.Of Applications Rejected</a>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top" style="width: 395px">
                                                                <%--href="frmCFEDepartmentsApprovalProcessCFO.aspx?stg=3"--%>
                                                                <%--<a class="list-group-item" href="#"><i class="fa fa-fw fa-check"></i><b> Approval Issued</b></a>
                                               
                                             
                                                
                                                <a class="list-group-item" href="frmCFEDepartmentsViewApplCFO.aspx?Stg=13"><span class="badge" style=" background-color:#87D37C;">
                                                <asp:Label ID="Label7" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i> Within Time Limits </a>
                                                
                                                 <a class="list-group-item" href="frmCFEDepartmentsViewApplCFO.aspx?Stg=14"><span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label9" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i> Beyond Time Limits</a>
                                                
                                                   <a class="list-group-item" href="frmCFEDepartmentsViewApplCFO.aspx?Stg=15"><span class="badge">
                                                <asp:Label ID="Label10" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i> Total</a>
                                               
                                                <a class="list-group-item" href="frmCFEDepartmentsViewApplCFO.aspx?Stg=16"><span class="badge">
                                                <asp:Label ID="Label17" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i> No of Applications Rejected </a>
                                                
                                                 <a class="list-group-item" href="frmCFEDepartmentsViewApplCFO.aspx?Stg=17"><span class="badge">
                                                <asp:Label ID="Label13" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i> No of Applications appeal against Rejection </a>
                                                
                                               
                                            </div>--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 468px">
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
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
                                            <%--<asp:GridView ID="grdDetails" runat="server" 
                                                AutoGenerateColumns="False" CellPadding="4" CssClass="GRD" 
                                                ForeColor="#333333" Height="62px" PageSize="15" Width="100%" 
                                                Visible="False">
                                                <footerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                                <rowstyle backcolor="#EBF2FE" cssclass="GRDITEM" horizontalalign="Left" 
                                                    verticalalign="Middle" />
                                                <columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No" 
                                                                Visible="True">
                                                                    <ItemTemplate >
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
                                                    
                                                </columns>
                                                <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                                <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                                                <headerstyle backcolor="#013161" cssclass="GRDHEADER" font-bold="True" 
                                                    forecolor="White" />
                                                <editrowstyle backcolor="#B9D684" />
                                                <alternatingrowstyle backcolor="White" />
                                            </asp:GridView>--%>
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
