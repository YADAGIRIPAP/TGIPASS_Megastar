<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="CinSave.aspx.cs" Inherits="UI_TSiPASS_CinSave" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                <div id="success" runat="server" visible="false" class="alert alert-success">
                    <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                </div>
                <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                    <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                <asp:GridView ID="grdcindata1" runat="server" AutoGenerateColumns="True"
                    CellPadding="5" ForeColor="#333333" Height="62px"
                    ShowFooter="True" Width="80%" OnRowDataBound="grdcindata1_RowDataBound">
                    <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EBF2FE" HorizontalAlign="Left" VerticalAlign="Middle" />
                    <Columns>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Width="50px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CIN">
                            <ItemTemplate>
                                <asp:Label ID="CINLabel" runat="server" Text='<%# Eval("CIN") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Company Name">
                            <ItemTemplate>
                                <asp:Label ID="CompanyNameLabel" runat="server" Text='<%# Eval("companyName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="incorporationDate">
                            <ItemTemplate>
                                <asp:Label ID="incorporationDateLabel" runat="server" Text='<%# Eval("incorporationDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="companyStatus">
                            <ItemTemplate>
                                <asp:Label ID="companyStatusLabel" runat="server" Text='<%# Eval("companyStatus") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ROCName">
                            <ItemTemplate>
                                <asp:Label ID="ROCNameLabel" runat="server" Text='<%# Eval("ROCName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="addressType">
                            <ItemTemplate>
                                <asp:Label ID="addressTypeLabel" runat="server" Text='<%# Eval("addressType") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="addressLine1">
                            <ItemTemplate>
                                <asp:Label ID="addressLine1" runat="server" Text='<%# Eval("addressLine1") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="addressLine2">
                            <ItemTemplate>
                                <asp:Label ID="addressLine2Label" runat="server" Text='<%# Eval("addressLine2") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="area">
                            <ItemTemplate>
                                <asp:Label ID="areaLabel" runat="server" Text='<%# Eval("area") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="city">
                            <ItemTemplate>
                                <asp:Label ID="cityLabel" runat="server" Text='<%# Eval("city") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="district">
                            <ItemTemplate>
                                <asp:Label ID="districtLabel" runat="server" Text='<%# Eval("district") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="pincode">
                            <ItemTemplate>
                                <asp:Label ID="pincodeLabel" runat="server" Text='<%# Eval("pincode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="state">
                            <ItemTemplate>
                                <asp:Label ID="stateLabel" runat="server" Text='<%# Eval("state") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="country">
                            <ItemTemplate>
                                <asp:Label ID="countryLabel" runat="server" Text='<%# Eval("country") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="emailAddress">
                            <ItemTemplate>
                                <asp:Label ID="emailAddressLabel" runat="server" Text='<%# Eval("emailAddress") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="contactNumber">
                            <ItemTemplate>
                                <asp:Label ID="contactNumberLabel" runat="server" Text='<%# Eval("contactNumber") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="financialYear">
                            <ItemTemplate>
                                <asp:Label ID="financialYearLabel" runat="server" Text='<%# Eval("financialYear") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="profitLoss">
                            <ItemTemplate>
                                <asp:Label ID="profitLossLabel" runat="server" Text='<%# Eval("profitLoss") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="turnover">
                            <ItemTemplate>
                                <asp:Label ID="turnoverLabel" runat="server" Text='<%# Eval("turnover") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="financialRange">
                            <ItemTemplate>
                                <asp:Label ID="financialRangeLabel" runat="server" Text='<%# Eval("financialRange") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="isAuditStatusApplicable">
                            <ItemTemplate>
                                <asp:Label ID="isAuditStatusApplicableLabel" runat="server" Text='<%# Eval("isAuditStatusApplicable") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="auditStatus">
                            <ItemTemplate>
                                <asp:Label ID="auditStatusLabel" runat="server" Text='<%# Eval("auditStatus") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="type">
                            <ItemTemplate>
                                <asp:Label ID="typeLabel" runat="server" Text='<%# Eval("type") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#B9D684" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdcindata2" runat="server" AutoGenerateColumns="True"
                    CellPadding="5" ForeColor="#333333" Height="62px"
                    ShowFooter="True" Width="100%" OnRowDataBound="grdcindata2_RowDataBound">
                    <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EBF2FE" HorizontalAlign="Left" VerticalAlign="Middle" />
                    <Columns>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Width="50px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CIN">
                            <ItemTemplate>
                                <asp:Label ID="CINLabel" runat="server" Text='<%# Eval("CIN") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CompanyName">
                            <ItemTemplate>
                                <asp:Label ID="CompanyNamelabel" runat="server" Text='<%# Eval("CompanyName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FirstName">
                            <ItemTemplate>
                                <asp:Label ID="FirstNamelabel" runat="server" Text='<%# Eval("FirstName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MiddleName">
                            <ItemTemplate>
                                <asp:Label ID="MiddleNamelabel" runat="server" Text='<%# Eval("MiddleName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="LastName">
                            <ItemTemplate>
                                <asp:Label ID="LastNamelabel" runat="server" Text='<%# Eval("LastName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CompanyName">
                            <ItemTemplate>
                                <asp:Label ID="DINlabel" runat="server" Text='<%# Eval("DIN") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DOB">
                            <ItemTemplate>
                                <asp:Label ID="DOBlabel" runat="server" Text='<%# Eval("DOB") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FatherFirstName">
                            <ItemTemplate>
                                <asp:Label ID="FatherFirstNamelabel" runat="server" Text='<%# Eval("FatherFirstName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FatherMidName">
                            <ItemTemplate>
                                <asp:Label ID="FatherMidNamelabel" runat="server" Text='<%# Eval("FatherMidName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FatherLastName">
                            <ItemTemplate>
                                <asp:Label ID="FatherLastNamelabel" runat="server" Text='<%# Eval("FatherLastName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DINStatus">
                            <ItemTemplate>
                                <asp:Label ID="DINStatuslabel" runat="server" Text='<%# Eval("DINStatus") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="AssociationStatus">
                            <ItemTemplate>
                                <asp:Label ID="AssociationStatuslabel" runat="server" Text='<%# Eval("AssociationStatus") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#B9D684" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grddindetails" runat="server" AutoGenerateColumns="True"
                    CellPadding="5" ForeColor="#333333" Height="62px"
                    ShowFooter="True" Width="100%" OnRowDataBound="grddindetails_RowDataBound">
                    <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EBF2FE" HorizontalAlign="Left" VerticalAlign="Middle" />
                    <Columns>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Width="50px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FirstName">
                            <ItemTemplate>
                                <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MiddleName">
                            <ItemTemplate>
                                <asp:Label ID="MiddleNamelabel" runat="server" Text='<%# Eval("MiddleName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="LastName">
                            <ItemTemplate>
                                <asp:Label ID="LastNamelabel" runat="server" Text='<%# Eval("LastName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DOBName">
                            <ItemTemplate>
                                <asp:Label ID="DOBlabel" runat="server" Text='<%# Eval("DOB") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FatherFirstName">
                            <ItemTemplate>
                                <asp:Label ID="FatherFirstNamelabel" runat="server" Text='<%# Eval("FatherFirstName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FatherMiddleName">
                            <ItemTemplate>
                                <asp:Label ID="FatherMiddleNamelabel" runat="server" Text='<%# Eval("FatherMiddleName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FatherLastName">
                            <ItemTemplate>
                                <asp:Label ID="FatherLastNamelabel" runat="server" Text='<%# Eval("FatherLastName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DINStatus">
                            <ItemTemplate>
                                <asp:Label ID="DINStatuslabel" runat="server" Text='<%# Eval("DINStatus") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#B9D684" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>

        </tr>
    </table>
</asp:Content>

