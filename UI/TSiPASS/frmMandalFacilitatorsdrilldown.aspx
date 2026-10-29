<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/CCMaster.master"  CodeFile="frmMandalFacilitatorsdrilldown.aspx.cs" Inherits="UI_TSiPASS_frmMandalFacilitatorsdrilldown" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div allign="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">
                            <asp:Label ID="lblHead2" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                Width="500px">Facilitator Details District Wise</asp:Label>
                        </h3>
                    </div>
                    <div class="panel-body">

                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td colspan="8" style="width: 883px; height: 25px;">
                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/frmMandalWomencell.aspx"
                                                        Text="<< Back">
                                                    </asp:HyperLink>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="overflow-x: auto; width: 900px; max-height: 500px">
                                        <asp:GridView ID="grddistfacilitatordetails" runat="server" AutoGenerateColumns="false" Width="100%"
                                            BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333"
                                            Style="margin: auto; overflow: scroll;" AllowSorting="true"
                                            HeaderStyle-CssClass="FixedHeader" >
                                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" CssClass="GridviewScrollC1HeaderWrap" />
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>
<asp:BoundField HeaderText="DISTRICT NAME" DataField="District_Name" ItemStyle-HorizontalAlign="Center"/>
                                                <asp:BoundField HeaderText="MANDAL NAME" DataField="Manda_lName" ItemStyle-HorizontalAlign="Center"/>
                                                <asp:BoundField HeaderText="FACILITATOR NAME" DataField="FACILITATORNAME" ItemStyle-HorizontalAlign="Center"/>
                                                <asp:BoundField HeaderText="DESIGNATION" DataField="DESIGNATION" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField HeaderText="CONTACT NO" DataField="CONTACTNO" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField HeaderText="EMAIL ID" DataField="EMAILID" ItemStyle-HorizontalAlign="Center" />
                                                
                                               
                                                


                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>

                    </div>

                </div>

            </div>
        </div>

    </div>

</asp:Content>



