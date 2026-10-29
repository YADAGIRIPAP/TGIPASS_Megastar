<%@ Page Title="" Language="C#" MasterPageFile="~/EmptyMaster2.master" AutoEventWireup="true"
    CodeFile="AmendamentUserCommentsFinal.aspx.cs" Inherits="AmendamentUserCommentsFinal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <table style="width: 100%">
            <tr>
                <td style="width: 49%" valign="top">
                    <asp:Panel runat="server" ID="Panel1">
                        <iframe runat="server" id="IframePanel" width="100%" height="400px"></iframe>
                    </asp:Panel>
                </td>
                <td>
                    <asp:Label runat="server" Width="70px" ID="lblwidth" Visible="false"></asp:Label>
                </td>
                <td style="width: 49%; border: 2px solid">
                    <asp:Panel runat="server" ID="Panel2">
                        <table style="text-align: center; width: 100%" align="center">
                            <tr runat="server">
                                <td>
                                    <asp:GridView Width="100%" ID="gvComments" runat="server" AutoGenerateColumns="false"
                                        border="3" CellPadding="4" CellSpacing="1">
                                        <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <RowStyle Height="50px" BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left"
                                            VerticalAlign="top" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="User Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUsername" runat="server" Text='<%# Bind("[User Name]") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Mobile No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMobile" runat="server" Text='<%# Bind("[Mobile No]") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Mail Id">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblmailid" runat="server" Text='<%# Bind("[Mail Id]") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ammendment">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAmmendment" runat="server" Text='<%# Bind("[Ammendment]") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="User Comments">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblusrcomm" runat="server" Width="180px" Text='<%# Bind("[User Comments]") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Department Comments">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldeptcoments" Text='<%# Bind("[Department Comments]") %>' Width="180px"
                                                        runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <table style="width: 100%">
            <tr id="trlegal" runat="server" visible="false">
                <td style="width: 70%" valign="top">
                    <asp:GridView Width="100%" ID="gridlegal" runat="server" AutoGenerateColumns="false"
                        border="3" CellPadding="4" CellSpacing="1">
                        <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                        <RowStyle Height="50px" BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left"
                            VerticalAlign="top" />
                        <Columns>
                            <asp:TemplateField HeaderText="Sl No.">
                                <ItemTemplate>
                                    <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="lblusrcomm" runat="server" Width="180px" Text='<%# Bind("[Comments]") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="scroll_td" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Comments">
                                <ItemTemplate>
                                    <asp:Label ID="lbldeptcoments" Text='<%# Bind("[DeptComments]") %>' Width="180px"
                                        runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="scroll_td" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
