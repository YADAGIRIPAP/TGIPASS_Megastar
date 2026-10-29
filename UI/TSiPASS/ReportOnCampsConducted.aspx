<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="ReportOnCampsConducted.aspx.cs" Inherits="UI_TSiPASS_ReportOnCampsConducted" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-10">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">
                            <asp:Label ID="lblHead2" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                Width="500px">Camps Conducted</asp:Label>
                        </h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td colspan="6" align="center" style="text-decoration: underline; padding-bottom: 30px">
                                    <asp:Label ID="lblhdng" runat="server" Font-Bold="true" Font-Size="25px"> Report on Camps Conducted</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td class="style3" align="center" style="width: 178px">
                                                <asp:Label ID="lblfromdt" runat="server">From Date :</asp:Label>
                                            </td>
                                            <td style="width: 10px">:</td>
                                            <td style="width: 229px">
                                                <asp:TextBox ID="txtfrmdate" runat="server" class="form-control" Width="200px" TabIndex="1"></asp:TextBox>
                                                <cc1:CalendarExtender ID="txtfrmdate_CalendarExtender" runat="server"
                                                    Format="dd-MM-yyyy" PopupButtonID="txtfrmdate" TargetControlID="txtfrmdate">
                                                </cc1:CalendarExtender>
                                            </td>
                                            <td class="style3" align="center" style="width: 178px">
                                                <asp:Label ID="lbltodate" runat="server">To Date :</asp:Label>
                                            </td>
                                            <td style="width: 11px">:</td>
                                            <td>
                                                <div>
                                                    <asp:TextBox ID="txttodate" runat="server" class="form-control txtbox"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="txttodate_CalendarExtender" runat="server"
                                                        Format="dd-MM-yyyy" PopupButtonID="txttodate" TargetControlID="txttodate">
                                                    </cc1:CalendarExtender>
                                                </div>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td align="center" style="padding: 5px; margin: 5px; text-align: center; height: 50px" colspan="10">&nbsp;&nbsp;
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
                                <td colspan="10"></td>
                            </tr>
                        </table>
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 70%">
                            <tr>
                                <td colspan="8" style="width: 883px">
                                    <asp:Label ID="lblForGrid" Text="District wise Camps Conducted" Visible="false" runat="server" Font-Bold="true"></asp:Label>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="grdsupport" runat="server" AutoGenerateColumns="false" Width="100%"
                                        BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333"
                                        CssClass="HeaderFloat" OnRowDataBound="grdsupport_RowDataBound">
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
                                            <asp:BoundField HeaderText="District" DataField="District_Name" />
                                            <asp:HyperLinkField HeaderText="For New Entrepreneurs" DataTextField="Newcount" />
                                            <asp:HyperLinkField HeaderText="For Existing Entrepreneurs" DataTextField="Extcount" />
                                            <asp:BoundField HeaderText="District ID" DataField="Districtid" Visible="false" />
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

