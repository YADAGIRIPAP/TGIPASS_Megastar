<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/EmptyMaster.master"
    AutoEventWireup="true" CodeFile="IncentiveMis.aspx.cs" Inherits="UI_TSiPASS_frmTsipassMis" %>

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
        
        .style21
        {
            height: 35px;
        }
        
        .style26
        {
            height: 21px;
        }
        
        .style27
        {
            height: 21px;
        }
        
        .style34
        {
            height: 21px;
            width: 261px;
        }
        
        .style35
        {
            height: 35px;
            width: 261px;
        }
        
        .style36
        {
            width: 261px;
        }
        
        .style41
        {
            height: 29px;
        }
        
        .style42
        {
            width: 261px;
            height: 29px;
        }
        
        .style46
        {
            height: 44px;
        }
        
        .style47
        {
            height: 44px;
            width: 261px;
        }
        
        .style48
        {
            width: 10px;
            height: 44px;
        }
        
        .style49
        {
            width: 206px;
            height: 44px;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <script language="javascript" type="text/javascript">
        function confirmMAUD() {
            if (confirm("Are you sure you want to send the record to MA & UD"))
                return true;
            return false;
        }
    </script>
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
            <li><i></i><a href="Home.aspx">Home</a></li>
            &nbsp; /
            <%--<li class=""><i class="fa fa-fw fa-edit">CFE</i> </li>--%>
            <i></i><a href="MisreportDashboard.aspx">Mis Reports </a>&nbsp;/
            <li class="active"><i></i>Incentive MIS Report</li>
        </ol>
    </div>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">
                            <asp:Label ID="lblHead2" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="199px"></asp:Label>
                        </h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr id="trcfereport" runat="server" visible="true">
                                <td>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <td align="left" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:HyperLink ID="HyperLink5" NavigateUrl="~/UI/TSiPASS/SanctionedIncentives.aspx"
                                                        runat="server" Font-Size="Large" Target="_blank">Industry wise Incentives Sanctioned by SLC</asp:HyperLink>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table width="80%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                From Date:
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                                    Width="125px"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                                </cc1:CalendarExtender>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                To Date:
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                                    Width="125px"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                                                </cc1:CalendarExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px" align="left">
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" align="left" colspan="3">
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr align="center">
                                                            <td style="padding: 5px; margin: 5px" colspan="4" align="center">
                                                                <asp:Button ID="btnGet" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10"
                                                                    Text="Generate Report" Width="180px" OnClick="btnGet_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px" align="left">
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" align="left" colspan="3">
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: right;" valign="top">
                                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <strong>Incetive Report</strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td>
                                                                <strong>Total Application Received : &nbsp
                                                                    <asp:Label ID="lblcfetotal" Font-Size="14px" runat="server" CssClass="LBLBLACK"></asp:Label>
                                                                </strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px;" align="center">
                                                                <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                    CssClass="GRD" ForeColor="#333333" Height="62px" PageSize="40" Width="100%" ShowFooter="True"
                                                                    OnRowDataBound="grdDetails_RowDataBound">
                                                                    <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex + 1%>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle Width="50px" />
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="Description" HeaderText="Description" />
                                                                        <asp:BoundField DataField="Total" HeaderText="Total" ItemStyle-HorizontalAlign="Right" />
                                                                        <asp:BoundField DataField="Within Time Lines" HeaderText="Within Time Lines" ItemStyle-HorizontalAlign="Right" />
                                                                        <asp:BoundField DataField="Beyond Time Lines" HeaderText="Beyond Time Lines" ItemStyle-HorizontalAlign="Right" />
                                                                        <asp:BoundField DataField="About to Breach (90% of Within Time Lines)" HeaderText="About to Breach (90% of Within Time Lines)"
                                                                            ItemStyle-HorizontalAlign="Right" />
                                                                        <%-- <asp:HyperLinkField DataTextField="total" HeaderText="Total Grievances"
                                                                    NavigateUrl="GreivanceStatusDetails.aspx?Status=All" />
                                                                <asp:HyperLinkField DataTextField="pending" HeaderText="Pending Grievances"
                                                                    NavigateUrl="GreivanceStatusDetails.aspx?Status=Pending" />
                                                                <asp:HyperLinkField DataTextField="redress" HeaderText="Redressed Grievances"
                                                                    NavigateUrl="GreivanceStatusDetails.aspx?Status=Redress" />
                                                                <asp:HyperLinkField DataTextField="reject" HeaderText="Rejected Grievances"
                                                                    NavigateUrl="GreivanceStatusDetails.aspx?Status=Reject" />--%>
                                                                    </Columns>
                                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                    <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                                    <EditRowStyle BackColor="#B9D684" />
                                                                    <AlternatingRowStyle BackColor="White" />
                                                                </asp:GridView>
                                                                <tr>
                                                                    <td align="center" style="padding: 5px; margin: 5px">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <caption>
                                                                    <b>&nbsp;Intent Letter</b></caption>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td>
                                                                <strong>Total Application Received : &nbsp
                                                                    <asp:Label ID="lblcfototal" Font-Size="14px" runat="server" CssClass="LBLBLACK"></asp:Label>
                                                                </strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px;" align="center">
                                                                <asp:GridView ID="grddetailscfo" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                    CssClass="GRD" ForeColor="#333333" Height="62px" PageSize="40" Width="100%" ShowFooter="True"
                                                                    OnRowDataBound="grddetailscfo_RowDataBound">
                                                                    <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex + 1%>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle Width="50px" />
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="Description" HeaderText="Description" />
                                                                        <asp:BoundField DataField="Total" HeaderText="Total" ItemStyle-HorizontalAlign="Right" />
                                                                        <asp:BoundField DataField="Within Time Lines" HeaderText="Within Time Lines" ItemStyle-HorizontalAlign="Right" />
                                                                        <asp:BoundField DataField="Beyond Time Lines" HeaderText="Beyond Time Lines" ItemStyle-HorizontalAlign="Right" />
                                                                        <asp:BoundField DataField="About to Breach (90% of Within Time Lines)" HeaderText="About to Breach (90% of Within Time Lines)"
                                                                            ItemStyle-HorizontalAlign="Right" />
                                                                        <%-- <asp:HyperLinkField DataTextField="total" HeaderText="Total Grievances"
                                                                    NavigateUrl="GreivanceStatusDetails.aspx?Status=All" />
                                                                <asp:HyperLinkField DataTextField="pending" HeaderText="Pending Grievances"
                                                                    NavigateUrl="GreivanceStatusDetails.aspx?Status=Pending" />
                                                                <asp:HyperLinkField DataTextField="redress" HeaderText="Redressed Grievances"
                                                                    NavigateUrl="GreivanceStatusDetails.aspx?Status=Redress" />
                                                                <asp:HyperLinkField DataTextField="reject" HeaderText="Rejected Grievances"
                                                                    NavigateUrl="GreivanceStatusDetails.aspx?Status=Reject" />--%>
                                                                    </Columns>
                                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                    <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                                    <EditRowStyle BackColor="#B9D684" />
                                                                    <AlternatingRowStyle BackColor="White" />
                                                                </asp:GridView>
                                                                <tr>
                                                                    <td align="center" style="padding: 5px; margin: 5px">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <caption>
                                                                    <b>&nbsp;Sanction Letter</b></caption>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td>
                                                                <strong>Total Application Received : &nbsp
                                                                    <asp:Label ID="Label1" Font-Size="14px" runat="server" CssClass="LBLBLACK"></asp:Label>
                                                                </strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px;" align="center">
                                                                <asp:GridView ID="grDisbursment" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                    CssClass="GRD" ForeColor="#333333" Height="62px" PageSize="40" Width="100%" ShowFooter="True"
                                                                    OnRowDataBound="grddetailscfo_RowDataBound">
                                                                    <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex + 1%>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle Width="50px" />
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="Description" HeaderText="Description" />
                                                                        <asp:BoundField DataField="Total" HeaderText="Total" ItemStyle-HorizontalAlign="Right" />
                                                                        <asp:BoundField DataField="Within Time Lines" HeaderText="Within Time Lines" ItemStyle-HorizontalAlign="Right" />
                                                                        <asp:BoundField DataField="Beyond Time Lines" HeaderText="Beyond Time Lines" ItemStyle-HorizontalAlign="Right" />
                                                                        <asp:BoundField DataField="About to Breach (90% of Within Time Lines)" HeaderText="About to Breach (90% of Within Time Lines)"
                                                                            ItemStyle-HorizontalAlign="Right" />
                                                                        <%-- <asp:HyperLinkField DataTextField="total" HeaderText="Total Grievances"
                                                                    NavigateUrl="GreivanceStatusDetails.aspx?Status=All" />
                                                                <asp:HyperLinkField DataTextField="pending" HeaderText="Pending Grievances"
                                                                    NavigateUrl="GreivanceStatusDetails.aspx?Status=Pending" />
                                                                <asp:HyperLinkField DataTextField="redress" HeaderText="Redressed Grievances"
                                                                    NavigateUrl="GreivanceStatusDetails.aspx?Status=Redress" />
                                                                <asp:HyperLinkField DataTextField="reject" HeaderText="Rejected Grievances"
                                                                    NavigateUrl="GreivanceStatusDetails.aspx?Status=Reject" />--%>
                                                                    </Columns>
                                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                    <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                                    <EditRowStyle BackColor="#B9D684" />
                                                                    <AlternatingRowStyle BackColor="White" />
                                                                </asp:GridView>
                                                                <tr>
                                                                    <td align="center" style="padding: 5px; margin: 5px">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <caption>
                                                                    <b>&nbsp;Disbursment</b></caption>
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
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                        <td colspan="5" align="center" style="padding: 5px; margin: 5px">
                                            <div id="DIVUPDATEDDATE" runat="server" class="alert alert-success" >
                                                 <b><asp:Label ID="LBLDATETEXT" runat="server" Text="The data in the dashboards is updated on a real time basis."></asp:Label>
                                                 </br><asp:Label  ID="lbllastupdate" runat="server" Text="Last update:"></asp:Label>
                                                 <asp:Label ID="LBLDATETIME" runat="server"></asp:Label></b>
                                            </div>
                                            
                                        </td>
                                    </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                    &nbsp;
                                </td>
                            </tr>
                            <%--   <tr>
                                <td align="center" colspan="2" style="padding: 5px; margin: 5px">
                                    <div id="success" runat="server" class="alert alert-success">
                                        <a aria-label="close" class="close" data-dismiss="alert"
                                            href="AddQualification.aspx">×</a> <strong></strong>
                                        <asp:Label
                                            ID="lblmsg" runat="server"></asp:Label>
                                    </div>
                                    <div id="Failure" runat="server" class="alert alert-danger">
                                        <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                    </div>

                                    <asp:HiddenField ID="hdfID" runat="server" />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server"
                                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="child" />
                                    <asp:HiddenField ID="hdfFlagID" runat="server" />
                                </td>
                            </tr>--%>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>
