<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="RPT_GroundwaterReport.aspx.cs" Inherits="UI_TSiPASS_RPT_GroundwaterReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>

            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">OVER ALL Ground Water REPORT&nbsp;</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top" class="style8"
                                                    align="center">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="style8" style="padding: 5px; margin: 5px; text-align: center;"
                                                    valign="top">&nbsp;
                                                </td>
                                            </tr>
                                           
                                            
                                            

                                             <tr>
                                                <td align="center" class="style8" style="padding: 5px; margin: 5px; text-align: center;"
                                                    valign="top">

                                                    
                                                </td>
                                            </tr>



                                            <tr>
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                               
                                                </td>
                                            </tr>
                                            <tr id="div_Print_state" runat="server">
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                    <asp:GridView ID="grdDetails_state" AutoGenerateColumns="false" OnRowCreated="grdDetails_state_RowCreated"
                                                        runat="server" CellPadding="2" Width="80%" OnRowDataBound="grdDetails_state_RowDataBound"
                                                        ShowFooter="True">
                                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                        <Columns>
                                                            <asp:BoundField DataField="SNO" HeaderText="Sno">
                                                                <ItemStyle />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="StateName" HeaderText="State">
                                                                <ItemStyle />
                                                            </asp:BoundField>
                                                            <asp:HyperLinkField DataTextField="GroundwaterAppl" HeaderText="Well">
                                                                <ItemStyle CssClass="text-center" Font-Bold="true" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="DrillingAppl" HeaderText="Drilling Rigs">
                                                                <ItemStyle CssClass="text-center" Font-Bold="true" />
                                                            </asp:HyperLinkField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>


                                            <tr id="div_Print_district" runat="server">
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                    <asp:GridView ID="grdDetails_district" AutoGenerateColumns="false" OnRowCreated="grdDetails_district_RowCreated"
                                                        runat="server" CellPadding="2" Width="80%" OnRowDataBound="grdDetails_district_RowDataBound"
                                                        ShowFooter="True">
                                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                        <Columns>
                                                            <asp:BoundField DataField="SNO" HeaderText="Sno">
                                                                <ItemStyle />
                                                            </asp:BoundField>
                                                            <%-- DistrictID--%>
                                                            <asp:BoundField DataField="DistrictName" HeaderText="District">
                                                                <ItemStyle />
                                                            </asp:BoundField>
                                                            <asp:HyperLinkField DataTextField="GroundwaterAppl" HeaderText="Well">
                                                                <ItemStyle CssClass="text-center" Font-Bold="true" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="DrillingAppl" HeaderText="Drilling Rigs">
                                                                <ItemStyle CssClass="text-center" Font-Bold="true" />
                                                            </asp:HyperLinkField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>

                                            <tr id="div_Print_GroundwaterType" runat="server">
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                    <asp:GridView ID="grd_groundwaterappltype" AutoGenerateColumns="false" OnRowCreated="grd_groundwaterappltype_RowCreated"
                                                        runat="server" CellPadding="2" Width="80%" OnRowDataBound="grd_groundwaterappltype_RowDataBound"
                                                        ShowFooter="True">
                                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                        <Columns>
                                                            <asp:BoundField DataField="SNO" HeaderText="Sno">
                                                                <ItemStyle />
                                                            </asp:BoundField>
                                                            <%--ApplicationTypeID--%>
                                                            <asp:BoundField DataField="ApplicationType" HeaderText="Well Application Type">
                                                                <ItemStyle />
                                                            </asp:BoundField>
                                                            <asp:HyperLinkField DataTextField="GroundwaterAppl" HeaderText="Well Applications">
                                                                <ItemStyle CssClass="text-center" Font-Bold="true" />
                                                            </asp:HyperLinkField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>

                                            <tr id="div_Print_DrillingRigType" runat="server">
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                    <asp:GridView ID="grd_drillingappltype" AutoGenerateColumns="false" OnRowCreated="grd_drillingappltype_RowCreated"
                                                        runat="server" CellPadding="2" Width="80%" OnRowDataBound="grd_drillingappltype_RowDataBound"
                                                        ShowFooter="True">
                                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                        <Columns>
                                                            <asp:BoundField DataField="ApplicationTypeID" HeaderText="Sno">
                                                                <ItemStyle />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ApplicationType" HeaderText="Application Type">
                                                                <ItemStyle />
                                                            </asp:BoundField>
                                                            <asp:HyperLinkField DataTextField="DrillingAppl" HeaderText="Drilling Rigs Applications">
                                                                <ItemStyle CssClass="text-center" Font-Bold="true" />
                                                            </asp:HyperLinkField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>

                                            <tr id="div_Print_allgwwaterdata" runat="server">
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                    <asp:GridView ID="grd_alldata" AutoGenerateColumns="false" OnRowCreated="grd_alldata_RowCreated"
                                                        runat="server" CellPadding="2" Width="80%" OnRowDataBound="grd_alldata_RowDataBound"
                                                        ShowFooter="True">
                                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                        <Columns>
                                                            <asp:BoundField DataField="SNO" HeaderText="Sno">
                                                                <ItemStyle />
                                                            </asp:BoundField>
                                                            <%-- DistrictID--%>
                                                            <asp:BoundField DataField="DIstrictName" HeaderText="District">
                                                                <ItemStyle />
                                                            </asp:BoundField>
                                                            <asp:HyperLinkField DataTextField="GroundwaterAppl" HeaderText="Total">
                                                                <ItemStyle CssClass="text-center" Font-Bold="true" />
                                                            </asp:HyperLinkField>
                                                            <%-- <asp:HyperLinkField DataTextField="Industrieswater" HeaderText="Industries Well Applications">
                                                        <ItemStyle Font-Bold="true" />
                                                    </asp:HyperLinkField>--%>
                                                            <asp:HyperLinkField DataTextField="Agriculture_IrrigationWater" HeaderText="Agriculture/Irrigation">
                                                                <ItemStyle CssClass="text-center" Font-Bold="true" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="Drinking_DomesticWater" HeaderText="Drinking/Domestic Water">
                                                                <ItemStyle CssClass="text-center" Font-Bold="true" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="Institution_Infrastructure_OthersWater" HeaderText="Institution/Infrastructure/Others">
                                                                <ItemStyle CssClass="text-center" Font-Bold="true" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="DrillingAppl" HeaderText="Total">
                                                                <ItemStyle CssClass="text-center" Font-Bold="true" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="Newrigs" HeaderText="New">
                                                                <ItemStyle CssClass="text-center" Font-Bold="true" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField DataTextField="Renewalrigs" HeaderText="Renewal">
                                                                <ItemStyle CssClass="text-center" Font-Bold="true" />
                                                            </asp:HyperLinkField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
</td>
                                            </tr>
                                               <tr>
                                        <td align="center" style="padding: 5px; margin: 5px">
                                            <div id="success" runat="server" class="alert alert-success" visible="false">
                                                <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Success!</strong><asp:Label ID="Label2" runat="server"></asp:Label>
                                            </div>
                                            <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                                <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>





                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;
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

