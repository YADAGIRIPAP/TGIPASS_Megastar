<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="EODBReports.aspx.cs" Inherits="UI_EODBReports" Title="EODB Reports" %>

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
        .GRD
        {
            height: auto;
            border-color: #013161;
            border-style: solid;
            border-width: 1px;
            text-transform: capitalize;
            padding: 10px;
        }
        .GRDITEM
        {
            /*background-color: WHITE;*/
            color: black;
            font-size: 12px;
            font-weight: normal;
            font-family: Verdana;
            padding: 10px; /*text-decoration:none;*/ /*border-color:#013161;*/ /*border-style:solid;*/
            text-transform: uppercase; /*border-width:1px;*/ /*height:23px;*/ /*text-indent:5px;*/
            padding: 10px; /*BACKGROUND-IMAGE: url(../images/grid_bg_.gif);*/
        }
        .GRDHEADER
        {
            color: #0E2A46;
            vertical-align: middle;
            text-align: center;
            height: 25px;
            width: 50px;
            padding: 10px;
            font-size: 12px;
            font-weight: bold;
            text-transform: capitalize;
            font-family: Verdana;
            background-image: url(../images/bg_blue_grd.gif);
            border-color: #ffffff;
            border-style: solid;
            border-width: 1px;
        }
    </style>
    <div style="padding-left: 10px; width: 85%;">
        <table style="padding-left: 10px; width: 85%;">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td style="padding-left: 10px;">
                    &nbsp;
                </td>
            </tr>
            <tr align="center" style="text-align: center;">
                <td width="200px" align="center" style="text-align: center;" colspan="3">
                    <asp:Label ID="Label401" runat="server" CssClass="LBLBLACK" Width="330px" Font-Bold="True"
                        Font-Size="18px">Department Wise EODB Reports</asp:Label>
                </td>
            </tr>
            <tr align="center" style="text-align: center;">
                <td width="200px" align="center" style="text-align: center;" colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <th align="center" colspan="3" style="font-weight: 500;">
                    <table style="width: 60%">
                        <tr>
                            <td width="200px">
                                <asp:Label ID="Label400" runat="server" CssClass="LBLBLACK" Width="165px">Department</asp:Label>
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDepartments" runat="server" class="form-control txtbox"
                                    Height="33px" Width="180px" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartments_SelectedIndexChanged">
                                    <asp:ListItem>--Select--</asp:ListItem>
                                    <asp:ListItem Value="Boilers">Boilers</asp:ListItem>
                                    <asp:ListItem Value="Factories">Factories</asp:ListItem>
                                    <asp:ListItem Value="Forest">Forest</asp:ListItem>
                                    <asp:ListItem Value="Labour">Labour</asp:ListItem>
                                    <asp:ListItem Value="Fire">Fire</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="200px">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </th>
            </tr>
            <tr align="center" style="text-align: center">
                <th align="center" colspan="3" style="font-weight: 500;">
                    <asp:Label ID="lblProgress" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                        Font-Size="14px"> </asp:Label>
                </th>
            </tr>
            <tr>
                <th align="center" colspan="3" style="font-weight: 500;">
                    &nbsp;
                </th>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="gvEodbReports" runat="server" CellPadding="1" ForeColor="#333333"
                        GridLines="Both" CellSpacing="1" Width="100%" CssClass="GRD" OnRowDataBound="gvEodbReports_OnRowDataBound">
                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#B9D684" />
                        <AlternatingRowStyle BackColor="White" />
                        <%--<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />--%>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <br />
                </td>
            </tr>
            <tr id="trLabourRenewals" runat="server" visible="false">
                <td colspan="3">
                    <asp:Label ID="lblLabourRenewals" runat="server" CssClass="LBLBLACK" Width="330px"
                        Font-Bold="True" Font-Size="14px"> </asp:Label><br />
                    <asp:GridView ID="gvRenewals" runat="server" CellPadding="1" ForeColor="#333333"
                        GridLines="Both" CellSpacing="1" Width="100%" CssClass="GRD" OnRowDataBound="gvEodbReports_OnRowDataBound">
                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#B9D684" />
                        <AlternatingRowStyle BackColor="White" />
                        <%--<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />--%>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <th align="center" colspan="3" style="font-weight: 500;">
                    &nbsp;
                </th>
            </tr>
            <tr align="center" style="text-align: center">
                <th align="center" colspan="3" style="font-weight: 500;">
                    <asp:Label ID="lblInspection" runat="server" CssClass="LBLBLACK" Width="330px" Font-Bold="True"
                        Font-Size="14px"></asp:Label>
                </th>
            </tr>
            <tr>
                <th align="center" colspan="3" style="font-weight: 500;">
                    &nbsp;
                </th>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="gvEodbinspection" runat="server" CellPadding="1" ForeColor="#333333"
                        GridLines="Both" CellSpacing="1" Width="100%" CssClass="GRD" OnRowDataBound="gvEodbReports_OnRowDataBound">
                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#B9D684" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
