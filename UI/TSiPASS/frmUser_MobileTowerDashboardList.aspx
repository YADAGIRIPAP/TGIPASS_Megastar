<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmUser_MobileTowerDashboardList.aspx.cs" Inherits="UI_TSiPASS_frmUser_MobileTowerDashboardList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       
         <asp:UpdatePanel ID="upd1" runat="server">
             <ContentTemplate>
                 <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    Mobile Tower DASHBOARD&nbsp;</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top" class="style8"
                                                    align="center">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="style8" style="padding: 5px; margin: 5px; text-align: center;"
                                                    valign="top">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                        Height="62px"   Width="100%" Font-Names="Verdana"
                                                        Font-Size="12px" OnRowDataBound="grdDetails_RowDataBound">
                                                        <HeaderStyle VerticalAlign="Middle" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                        <RowStyle CssClass="GridviewScrollC1Item" />
                                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                        <FooterStyle BackColor="#013161" Height="40px" CssClass="GridviewScrollC1Header" />
                                                        <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                    <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                    <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="UIDNO" ItemStyle-HorizontalAlign="Left" HeaderText="Application No" />
                                                             <asp:BoundField DataField="ApplicationFiledDate" ItemStyle-HorizontalAlign="Left"
                                                                HeaderText="Applied Date" />
                                                             <asp:TemplateField HeaderText="View Dashboard">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="anchortaglink" runat="server" Text="View" Font-Bold="true" ForeColor="Green"
                                                                        Target="_blank" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                           
                                                           <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="anchortaglinkStatus" runat="server" Text="Track" Font-Bold="true"
                                                                        ForeColor="Green" Target="_blank" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField> 
                                                            <asp:TemplateField HeaderText="Print">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="anchortaglinkprint" runat="server" Text="View" Font-Bold="true"
                                                                        ForeColor="Green" Target="_blank" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField> 
                                                            <asp:TemplateField HeaderText="PaymentDetails">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="anchortaglinkpayment" runat="server" Text="View" Font-Bold="true"
                                                                        ForeColor="Green" Target="_blank" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField> 
                                                             </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                                <tr id="trApplyAgainNote" runat="server">
                                                <td align="left" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                    &nbsp;<b>Note:</b> To Apply Again for another application, Please Click on &#39;Apply Again&#39; and click on Next, Next..&nbsp;&nbsp; Fill other details again as applicable.In the final page you will get new application number and new acknowledgement after payment of necessary fee.
                                                </td>
                                            </tr>
                                            <tr align="center" id="trApplyAgainbtn" runat="server">
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: left;" valign="middle">
                                                    &nbsp;
                                                    <asp:Button ID="btnApplyAgain" runat="server" CssClass="btn btn-primary"  Height="32px"
                                                        TabIndex="10" Text="Apply Again" Width="150px" OnClick="btnApplyAgain_Click"  />
                                                </td>
                                            </tr>
                                            <tr id="trprintack" runat="server" visible="false">
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>

             </ContentTemplate>

             
             </asp:UpdatePanel>
                    
</asp:Content>

