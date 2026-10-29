<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSIPASS/CCMaster.master" AutoEventWireup="true" CodeFile="QueryResponse.aspx.cs" Inherits="UI_QueryResponse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="container">
        <div class="row">
            <div class="col-md-10">

                <div class="panel panel-default">
                    <div class="panel-heading">
                        Queries
                    </div>
                    <div class="panel-body">
                        <asp:GridView ID="gvdetailsnew" runat="server" AutoGenerateColumns="False"
                            CellPadding="4" Height="62px" EmptyDataText="No Queries Found" ShowHeaderWhenEmpty="True"
                            PageSize="20" Width="100%" Font-Names="Verdana" Font-Size="12px">
                            <HeaderStyle VerticalAlign="Middle" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                            <RowStyle CssClass="GridviewScrollC1Item" />
                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                            <FooterStyle BackColor="#013161" Height="40px" CssClass="GridviewScrollC1Header" />
                            <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                            <Columns>
                                <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1%>
                                        <asp:HiddenField ID="HdfQueid" runat="server" />
                                        <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="50px" />
                                </asp:TemplateField>--%>

                                <asp:TemplateField HeaderText="Application No" ItemStyle-Width="80">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRMId" runat="server" Text='<%# Eval("Appid") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--    <asp:TemplateField HeaderText="Application No">
                                                    <ItemTemplate>
                                                        <label id="lblrmid" runat="server" text='<%#Eval("RMId")%>'></label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                <%--<asp:BoundField DataField="RMId" ItemStyle-HorizontalAlign="Center" HeaderText="Application No">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>--%>
                              
                                <asp:BoundField DataField="DistrictName" ItemStyle-HorizontalAlign="Center" HeaderText="District">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                  <asp:BoundField DataField="firmname" ItemStyle-HorizontalAlign="Center" HeaderText="Unit Name">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                <asp:BoundField DataField="indparkid" ItemStyle-HorizontalAlign="Center" HeaderText="IndustrialPark Name">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                              


                               <asp:BoundField DataField="plotno" ItemStyle-HorizontalAlign="Center" HeaderText="Plot No">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                              

                                
                                <asp:BoundField DataField="querydes" ItemStyle-HorizontalAlign="Center" HeaderText="Query Description">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>


                                  <asp:BoundField DataField="Queryraisedate" ItemStyle-HorizontalAlign="Center" HeaderText="Query Raised Date">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                               
                              
                                <asp:TemplateField HeaderText="Respond" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkQueryCount" runat="server" Text="Respond to Query" OnClick="lnkQueryCount_Click"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                          
                            </Columns>
                        </asp:GridView>


                    </div>

                </div>



            </div>
        </div>
    </div>
</asp:Content>

