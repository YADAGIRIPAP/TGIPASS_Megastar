<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/EmptyMaster.master" AutoEventWireup="true" CodeFile="frmBussinessRegulationMis.aspx.cs" Inherits="UI_TSiPASS_frmBussinessRegulationMis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <style type="text/css">
        .overlay {
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

        .style21 {
            height: 35px;
        }

        .style26 {
            height: 21px;
        }

        .style27 {
            height: 21px;
        }

        .style34 {
            height: 21px;
            width: 261px;
        }

        .style35 {
            height: 35px;
            width: 261px;
        }

        .style36 {
            width: 261px;
        }

        .style41 {
            height: 29px;
        }

        .style42 {
            width: 261px;
            height: 29px;
        }

        .style46 {
            height: 44px;
        }

        .style47 {
            height: 44px;
            width: 261px;
        }

        .style48 {
            width: 10px;
            height: 44px;
        }

        .style49 {
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
                                    <li><i></i><a href="Home.aspx">Home</a></li>  &nbsp; /
                                    <%--<li class=""><i class="fa fa-fw fa-edit">CFE</i> </li>--%>
                                    <i ></i><a href="MisreportDashboard.aspx">Mis Reports </a>  &nbsp;/
                                    <li class="active"><i ></i>Business Regulation</li>
                                </ol>
                            </div>
    <div class="panel-body">
        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
            <tr>
                <td><strong>Bussiness Regulation Report</strong></td>
            </tr>
            <tr>
                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                    <table cellpadding="4" cellspacing="5" style="width: 83%">

                        <tr>
                            <td style="padding: 5px; margin: 5px;" align="center">
                                <asp:gridview id="grdDetails" runat="server"
                                    autogeneratecolumns="False" cellpadding="4" cssclass="GRD"
                                    forecolor="#333333" height="62px" GridLines="Both"
                                    pagesize="40" width="100%" showfooter="True" onrowdatabound="grdDetails_RowDataBound">
                                                                    <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"/>
                                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left"
                                                                        VerticalAlign="Middle" Height="35px"/>
                                                                    <Columns>

                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex + 1%>
                                                                                <%--<asp:HiddenField ID="HdfQueid" runat="server" />--%>
                                                                                <asp:HiddenField ID="Dept_Id" runat="server" />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle Width="50px" />
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="Dept_Name" HeaderText="Department"/>
                                                                        <asp:BoundField DataField="total" HeaderText="Total" ItemStyle-HorizontalAlign="Center" />
                                                                        <asp:BoundField DataField="Draft" HeaderText="Draft Regulations" ItemStyle-HorizontalAlign="Center" />
                                                                        <asp:BoundField DataField="Fianl" HeaderText="Final Regulations" ItemStyle-HorizontalAlign="Center" />                                                                        
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
                                                                    <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True"
                                                                        ForeColor="White" HorizontalAlign="Center"/>
                                                                    <EditRowStyle BackColor="#B9D684" />
                                                                    <AlternatingRowStyle BackColor="White" />
                                                                </asp:gridview>
                                <tr>
                                    <td align="center" style="padding: 5px; margin: 5px">&nbsp;</td>
                                </tr>
                                <caption>
                                    &nbsp;</caption>
                            </td>
                        </tr>
                        <tr>
                                        <td colspan="5" align="center" style="padding: 5px; margin: 5px">
                                            <div id="DIVUPDATEDDATE" runat="server" class="alert alert-success" >
                                                 <b><asp:Label ID="LBLDATETEXT" runat="server" Text="The data in the dashboard is updated on a real time basis."></asp:Label>
                                                 </br><asp:Label  ID="lbllastupdate" runat="server" Text="Last update:"></asp:Label>
                                                 <asp:Label ID="LBLDATETIME" runat="server"></asp:Label></b>
                                            </div>
                                            
                                        </td>
                                    </tr>

                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

