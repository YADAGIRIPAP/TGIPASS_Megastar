<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="RptEODBReport.aspx.cs" Inherits="UI_EODBReports"
    Title=":: TSiPASS EODB Reports ::" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function GetRowValue(val) {
            if (val != '&nbsp;') {
                val1 = 0;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdfID').value = val;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdfFlagID').value = val1;

            }
            window.opener.document.forms[0].submit();
            self.close();

        }
    
    </script>

    <style type="text/css">
        .algnRight
        {
            text-align: center;
            padding-right: 5px;
        }
    </style>
    <table runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <div class="panel panel-default">
                    <div class="panel-heading" style="text-align: center">
                        <h3 class="panel-title" style="font-weight: bold">
                            <asp:Label ID="lblHeading" runat="server"></asp:Label></h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr id="trFilter" runat="server">
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <%--<td visible="false" class="col-xs-3" style="padding: 5px; margin: 5px">
                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        Department</div>
                                                    <asp:DropDownList ID="ddlDepartments" class="form-control txtbox" runat="server">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="Boilers">Boilers</asp:ListItem>
                                                    <asp:ListItem Value="Factories">Factories</asp:ListItem>
                                                    <asp:ListItem Value="Forest">Forest</asp:ListItem>
                                                    <asp:ListItem Value="Labour">Labour</asp:ListItem>
                                                    <asp:ListItem Value="Fire">Fire</asp:ListItem>
                                                </asp:DropDownList>
                                                </div>
                                            </td>--%>
                                            <%--<td style="padding: 5px; margin: 5px" align="right">
                                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-default" TabIndex="10"
                                                    Text="Submit" OnClick="BtnSave1_Click" />
                                            </td>--%>
                                            <td class="col-xs-12" style="padding: 5px; text-align: right; margin: 5px">
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%-- <tr align="center" style="text-align: center">
                                <td style="padding: 5px; margin: 5px">
                                </td>
                            </tr>--%>
                            <tr visible="false" align="center" style="text-align: center">
                                <td align="center" style="font-weight: 500;">
                                    <asp:Label ID="lblProgress" runat="server" CssClass="LBLBLACK" Font-Bold="True" Font-Size="14px"> </asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="text-align: center; width: 90%" valign="top">
                                    <asp:GridView ID="gvEodbReports" runat="server" AutoGenerateColumns="true" CellPadding="4"
                                        ShowFooter="True" Width="100%" OnRowDataBound="grdDetails_RowDataBound">
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    <asp:Label ID="lblLabourRenewals" runat="server" CssClass="LBLBLACK" Width="330px"
                                        Font-Bold="True" Font-Size="14px"> </asp:Label>
                                </td>
                            </tr>
                            <tr id="trLabourRenewals" runat="server" visible="false">
                                <td align="center" style="text-align: center; width: 90%" valign="top">
                                    <asp:GridView ID="gvRenewals" runat="server" AutoGenerateColumns="true" ShowFooter="True"
                                        Width="100%" OnRowDataBound="grdDetails_RowDataBound" BorderColor="Black">
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr align="center" style="text-align: center">
                                <th align="center" style="font-weight: 500;">
                                    <asp:Label ID="lblInspection" runat="server" CssClass="LBLBLACK" Width="330px" Font-Bold="True"
                                        Font-Size="14px"></asp:Label>
                                </th>
                            </tr>
                            <tr>
                                <th align="center" style="font-weight: 500;">
                                    &nbsp;
                                </th>
                            </tr>
                            <tr>
                                <td align="center" style="text-align: center; width: 90%" valign="top">
                                    <asp:GridView ID="gvEodbinspection" runat="server" AutoGenerateColumns="true" ShowFooter="True"
                                        Width="100%" OnRowDataBound="grdDetails_RowDataBound" BorderColor="Black">
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
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
</asp:Content>
