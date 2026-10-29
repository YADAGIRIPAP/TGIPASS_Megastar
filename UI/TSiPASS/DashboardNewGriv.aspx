<%@ Page Title=":: TSiPASS : Grievance Dashboard " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="DashboardNewGriv.aspx.cs" Inherits="Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">




    </script>


    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i><a href="Home.aspx">Dashboard</a>
                            </li>


                </ol>
            </div>

            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">&nbsp;Grivence Dashboard</h3>
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
                                                                <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Small"
                                                                    NavigateUrl="~/UI/TSiPASS/HomeDeptDashboard.aspx">Back</asp:HyperLink>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px; font-size: 16px;">
                                                                <b>&nbsp;Grievance Dashboard </b></td>
                                                            <td style="width: 30px">&nbsp;</td>
                                                            <td style="width: 395px" valign="top">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px; font-size: 16px;">&nbsp;</td>
                                                            <td style="width: 30px">&nbsp;</td>
                                                            <td style="width: 395px" valign="top">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px" valign="top">
                                                                <div class="list-group">
                                                                    <%--GreivanceStatusDetails.aspx?Status=All&intDeptid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")--%>
                                                                    <a class="list-group-item" href='GreivanceStatusDetails.aspx?Status=All'>
                                                                        <span class="badge">
                                                                            <asp:Label ID="Label4" runat="server"></asp:Label></span>
                                                                        <i class="fa fa-fw fa-calendar"></i>No of Grievances Received
                                                                    </a>



                                                                    <%--<a class="list-group-item" href="frmEntrepreneurDetails.aspx">
                                                <span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label5" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i> In Complete (Draft) </a>--%>


                                                                    

                                                                    <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b> Pending </b></a>
                                                                    <a class="list-group-item" href="GreivanceStatusDetails.aspx?Status=PendingW">
                                                                        <span class="badge">
                                                                           <asp:Label ID="Label6" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Within 5 Days </a><a class="list-group-item"
                                                                            href="GreivanceStatusDetails.aspx?Status=PendingB"><span class="badge"
                                                                                style="background-color: #d9534f;">
                                                                                <asp:Label ID="Label2" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>Beyond 5 Days </a>
                                                                    <a class="list-group-item" href="GreivanceStatusDetails.aspx?Status=PendingT">
                                                                        <span class="badge">
                                                                            <asp:Label ID="Label8" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Total </a>


                                                                    &nbsp;<%--<a class="list-group-item" href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approvals - Payment Done'>
                                                <span class="badge">
                                                <asp:Label ID="Label9" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Approvals - Payment Done </a>--%>&nbsp;&nbsp;
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">&nbsp;</td>
                                                            <td valign="top" style="width: 395px">
                                                                <div class="list-group">
                                                                    <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Redressed</b> </a>
                                                                    <a class="list-group-item" href='GreivanceStatusDetails.aspx?Status=RedressedW'>
                                                                        <span class="badge">
                                                                            <asp:Label ID="Label12" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Within 5 days</a>
                                                                    <a class="list-group-item" href='GreivanceStatusDetails.aspx?Status=RedressedB'>
                                                                        <span class="badge" style="background-color: #d9534f;">
                                                                            <asp:Label ID="Label3" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Beyond 5 days</a>
                                                                     <a class="list-group-item" href='GreivanceStatusDetails.aspx?Status=RedressedT'>
                                                                        <span class="badge">
                                                                            <asp:Label ID="Label5" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Total</a>

                                                                    <a class="list-group-item" href='GreivanceStatusDetails.aspx?Status=Reject'>
                                                                        <span class="badge" style="background-color: #d9534f;">
                                                                            <asp:Label ID="Label15" runat="server"></asp:Label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i><b>Rejected Grievances</b></a>&nbsp;&nbsp;
                                              
                                                                </div>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px">&nbsp;</td>
                                                            <td style="width: 30px">&nbsp;</td>
                                                            <td>&nbsp;</td>
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
                                                    <td style="width: 417px">&nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" align="center">
                                            <asp:GridView ID="grdDetails" runat="server"
                                                AutoGenerateColumns="False" CellPadding="4" CssClass="GRD"
                                                ForeColor="#333333" Height="62px" PageSize="15" Width="100%"
                                                Visible="False">
                                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left"
                                                    VerticalAlign="Middle" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No"
                                                        Visible="True">
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
                                                <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True"
                                                    ForeColor="White" />
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

