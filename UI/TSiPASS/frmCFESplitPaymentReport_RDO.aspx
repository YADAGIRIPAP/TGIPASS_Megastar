<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    CodeFile="frmCFESplitPaymentReport_RDO.aspx.cs" Inherits="UI_TSIPASS_frmCFESplitPaymentReport_RDO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <asp:UpdateProgress ID="UpdateProgress" runat="server">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <div class="panel-heading" align="center">
        <h3 class="panel-title" style="font-weight: bold;">
            <asp:Label ID="lblHeading" runat="server"></asp:Label></h3>
    </div>
    <table>
        <tr>
            <td class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
            </td>
        </tr>
        <tr id="rdoPayments" runat="server" visible="false">
            <td>
                <asp:GridView ID="grdRDOPayments" runat="server" AutoGenerateColumns="false" CellPadding="5"
                    ShowFooter="True" Width="100%" AllowPaging="false" PageSize="20" OnSelectedIndexChanged="grdRDOPayments_SelectedIndexChanged"
                    OnSelectedIndexChanging="grdRDOPayments_SelectedIndexChanging" OnRowDataBound="grdRDOPayments_RowDataBound">
                    <HeaderStyle Height="40px" CssClass="GridviewScrollC1Header" />
                    <RowStyle CssClass="GridviewScrollC1Item" />
                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                    <FooterStyle CssClass="GridviewScrollC1Header" />
                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                    <Columns>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1%>
                                <asp:HiddenField ID="HdfQueid" runat="server" />
                                <asp:HiddenField ID="HdfApprovalid" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="RDO Name" HeaderText="RDO Name">
                            <ItemStyle Wrap="true" CssClass="text-uppercase" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Pending Units"
                            ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyNOOFPendingUnits" runat="server" Text='<%#Eval("Pending Units") %>'>HyperLink</asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="deptID" HeaderText="DistCd" Visible="false" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
