<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="GrivancePendingatOfficer.aspx.cs" Inherits="UI_TSiPASS_GrivancePendingatOfficer" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .col-lg-10 {
            width: 1050px;
        }
    </style>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-12">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">
                            <asp:Label ID="lblHead2" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                Width="500px">Interactions</asp:Label>
                        </h3>
                    </div>
                    <div class="panel-body">

                        <div>
                            <h3 id="lblhdng" align="center" runat="server" font-bold="true" font-size="25px">Gievance Pending Interactions</h3>
                        </div>
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td colspan="8" style="width: 883px">
                                    <asp:Label ID="lblForGrid" Visible="false" runat="server" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="grdUpdate" runat="server" AutoGenerateColumns="false" Width="100%"
                                        BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333" ShowHeaderWhenEmpty="true"
                                        CssClass="HeaderFloat">
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                        <RowStyle Height="30px" />
                                        <AlternatingRowStyle Height="30px" BackColor="LightGray" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="20px" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Interaction Date" DataField="DateofInteraction" Visible="true" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Interaction Type" DataField="InteractionType" Visible="true" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Unit Name" DataField="Name" Visible="true" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Mobile No" DataField="Mobile" Visible="true" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="E-mail" DataField="mail" Visible="true" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Gender" DataField="Gender" Visible="true" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Social Category" DataField="SocialCategory" Visible="true" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Grievance Status" DataField="GrievanceStatus" Visible="true" ItemStyle-HorizontalAlign="Center" />

                                            <asp:TemplateField HeaderText="InteractionID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="InteractionID" runat="server" Text='<%#Eval("PIEEId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--                                            <asp:BoundField HeaderText="InteractionID" DataField="PIEEId" Visible="false" />--%>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Update Grievance Status">
                                                <ItemTemplate>
                                                    <asp:Button ID="UpdateStatus" Text="Update" runat="server" BackColor="DeepSkyBlue" Width="100px" Height="30px" OnClick="UpdateStatus_Click" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div style="text-align: Center">No Records Found</div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>

                        <div>
                            <h3 id="H1" align="center" runat="server" font-bold="true" font-size="25px">Online Platforms On-Boarded Status</h3>
                        </div>
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td colspan="8" style="width: 883px">
                                    <asp:Label ID="Label1" Visible="false" runat="server" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="grdplatforms" runat="server" AutoGenerateColumns="false" Width="100%"
                                        BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333" ShowHeaderWhenEmpty="true"
                                        CssClass="HeaderFloat" >
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                        <RowStyle Height="30px" />
                                        <AlternatingRowStyle Height="30px" BackColor="LightGray" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="20px" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Interaction Date" DataField="DateofInteraction" Visible="true" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Interaction Type" DataField="InteractionType" Visible="true" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Unit Name" DataField="Name" Visible="true" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Mobile No" DataField="Mobile" Visible="true" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="E-mail" DataField="mail" Visible="true" ItemStyle-HorizontalAlign="Center" />
                                            <asp:TemplateField HeaderText="Meesho" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMeesho" runat="server" Text='<%#Eval("GrMEC_Meesho") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Just Dial" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblJustDial" runat="server" Text='<%#Eval("GrMEC_JustDial") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="TS-Global Linker" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTSGlobal" runat="server" Text='<%#Eval("GrMEC_TSGlobal") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="WallMart Vriddi" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblWallMart" runat="server" Text='<%#Eval("GrMEC_Wallmart") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Invoice Mart" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInvoiceMart" runat="server" Text='<%#Eval("GrFOLP_InvoiceMart") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="NSE" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNSE" runat="server" Text='<%#Eval("GrFOLP_NSE") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SIDBI" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSIDBI" runat="server" Text='<%#Eval("GrFOLP_SIDBI") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="InteractionID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="InteractionID" runat="server" Text='<%#Eval("PIEEId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Update Grievance Status">
                                                <ItemTemplate>
                                                    <asp:Button ID="UpdatePlatforms" Text="Update" runat="server" BackColor="DeepSkyBlue" Width="100px" Height="30px" OnClick="UpdatePlatforms_Click" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div style="text-align: Center">No Records Found</div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>

                        <div>
                            <table style="width: 100%">
                                <tr>
                                    <td style="padding: 5px; margin: 5px" align="center" colspan="2">
                                        <div id="success" runat="server" class="alert alert-success" visible="false">
                                            <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                        </div>
                                        <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                            <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>

                </div>

            </div>
        </div>

    </div>
</asp:Content>



