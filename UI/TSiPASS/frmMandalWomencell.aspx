<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmMandalWomencell.aspx.cs" Inherits="UI_TSiPASS_frmMandalWomencell" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">

    </script>
    <style type="text/css">
    .col-lg-10 {
        width: 1050px;
    }
        .auto-style1 {
            width: 76%;
        }
    </style>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-10">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">
                            <asp:Label ID="lblHead2" runat="server" CssClass="LBLBLACK" Font-Bold="True" Visible="false"
                                Width="500px"></asp:Label>
                        </h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td colspan="6" align="center" style="text-decoration: underline; padding-bottom:30px">
                                    <asp:Label ID="lblhdng" runat="server" Font-Bold="true" Font-Size="25px"> Report on Women Cells</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            
                                            <td class="style3" align="right" style="width: 178px">
                                                <asp:Label ID="Label1" runat="server">District </asp:Label>
                                            </td>
                                            <td style="width: 11px">:</td>
                                            <td style="width:200px">
                                                <div>
                                                    <asp:DropDownList ID="ddldistrict" runat="server" class="form-control" style="width:150px" >
                                                        <asp:ListItem Value="0">-Select-</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </td>

                                        
                                       
                                            <td align="center" style="padding: 5px; margin: 5px; text-align: left; height: 50px" colspan="10">&nbsp;&nbsp;
                                                <asp:Button ID="BtnGetData" runat="server" CssClass="btn btn-primary"
                                                    Height="32px" TabIndex="10" Text="Get Report" ValidationGroup="group"
                                                    Width="120px" OnClick="BtnGetData_Click" />
                                                &nbsp;
                                            <asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                                CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                                Text="Cancel" ToolTip="To Clear  the Screen" Width="90px" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="10" style="height:30px;text-align:center"> <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/frmdistwomencell.aspx"
                                                        Text="<< Back">
                                                    </asp:HyperLink></td>
                            </tr>
                        </table>
                        <table align="center" cellpadding="10" cellspacing="5" class="auto-style1" style="width:900px">
                            <tr>
                                <td colspan="8" style="width: 883px">
                                    <asp:Label ID="lblForGrid" Text="District wise Womencells" Visible="false" runat="server" Font-Bold="true"></asp:Label>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="grdwomencells" runat="server" AutoGenerateColumns="false" Width="100%"
                                        BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333"
                                        CssClass="HeaderFloat" OnRowDataBound="grdwomencells_RowDataBound" >
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                        <RowStyle HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="20px" />
                                                <%--Districtid--%>
                                            </asp:TemplateField>
                                        <asp:BoundField HeaderText="District Name" DataField="DISTRICTNAME"  ItemStyle-HorizontalAlign="Center"  /> 
                                            <asp:BoundField HeaderText="Mandal Name" DataField="MANDALNAME" ItemStyle-HorizontalAlign="Center"   />                                            
                                            <asp:BoundField HeaderText="Day of Operation" DataField="DAYOFOPERATION" ItemStyle-HorizontalAlign="Center"   />   
                                            <asp:BoundField HeaderText="Time of Operation" DataField="TIMEOFOPERATION" ItemStyle-HorizontalAlign="Center"  />                                            <asp:BoundField HeaderText="Place of Operation" DataField="PLACEOFOPETAION"   ItemStyle-HorizontalAlign="Center" />                                            
                                            <asp:BoundField HeaderText="Women Cell Constituted Date" DataField="WOMENCELLCONSTITUTEDDATE"  ItemStyle-HorizontalAlign="Center"  />
                                            
                                               <asp:HyperLinkField HeaderText="No of facilitators in Mandal" DataTextField="Fecilitatorcount_MANDAL" />
                                           

                                            <asp:BoundField HeaderText="Mandal ID" DataField="MANDALID" Visible="false" />
                                                                                        <asp:BoundField HeaderText="District Id" DataField="DISTRICTID" Visible="false" />

                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>

                    </div>

                </div>

            </div>
        </div>

    </div>
</asp:Content>




