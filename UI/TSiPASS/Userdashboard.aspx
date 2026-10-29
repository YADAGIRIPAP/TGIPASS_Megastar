<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSIPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="Userdashboard.aspx.cs" Inherits="UI_TSIPASS_Userdashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .LabelGrey
        {
            font-weight: bold;
            color: red;
        }
        .labelgreen
        {
            font-weight: bold;
            color: green;
        }
        .labelblue
        {
            font-weight: bold;
            color: blue;
        }
        
        
        .labeldark
        {
            font-weight: bold;
            color: lightpink;
        }
    </style>
    <div class="container">
        <div class="row">
            <div class="col-md-10">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Dashboard
                    </div>
                    <div class="panel-body">
                        <asp:GridView ID="gvdetailsnew" CssClass="" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                            CellPadding="4" Height="62px" OnRowDataBound="gvdetailsnew_RowDataBound" PageSize="20"
                            Width="100%" Font-Names="Verdana" Font-Size="12px" GridLines="Both">
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
                                <asp:BoundField DataField="Appid" ItemStyle-HorizontalAlign="Center" HeaderText="Application No">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <%--   <asp:BoundField DataField="intstageid" ItemStyle-HorizontalAlign="Center" Visible="false"  HeaderText="Application No">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>--%>
                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRmTypeid" Text='<%#Eval("intstageid") %>' runat="server" Visible="false" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="firmname" ItemStyle-HorizontalAlign="Center" HeaderText="Unit Name">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DistrictName" ItemStyle-HorizontalAlign="Center" HeaderText="District Name">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="indparkid" ItemStyle-HorizontalAlign="Center" HeaderText="Industrialpark Name">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="plotno" ItemStyle-HorizontalAlign="Center" HeaderText="Plot No">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Applicationfileddate" DataFormatString="{0:dd-MM-yyyy}"
                                    ItemStyle-HorizontalAlign="Center" HeaderText="Application Filed Date">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Queries Count" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkQueryCount" runat="server" Text='<%#Eval("QueryCount")%>'
                                            PostBackUrl='<%#Eval("Appid","QueryResponse.aspx?Appid={0}")%>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <center>
                                                        <asp:Button ID="anchortaglink" runat="server"  Text="View" CssClass="btn btn-primary" OnClick="anchortaglink_Click"  CommandArgument=" <%# Container.DataItemIndex + 1%>" />
                                                            </center>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <center>
                                            <asp:Button ID="anchortaglin" runat="server" Text='<%#("ColumnName") %>' Visible="false"
                                                CssClass="btn btn-primary" OnClick="anchortaglin_Click" CommandArgument=" <%# Container.DataItemIndex + 1%>" />
                                        </center>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="STATUS" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <center>
                                            <asp:Label runat="server" ID="lblname"></asp:Label>
                                            <br />
                                            <asp:HyperLink ID="lnk_downloadcert" runat="server" Visible="false" Text="Download Certificate" Target="_blank"></asp:HyperLink>
                                        </center>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
