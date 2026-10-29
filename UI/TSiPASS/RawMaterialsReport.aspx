<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="RawMaterialsReport.aspx.cs" Inherits="LookupCA" Title=":: TSiPASS Online Management System ::" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function GetRowValue(val) {
            if (val != '&nbsp;') {
                val1 = 0;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdfID').value = val;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdfFlagID').value = val1;

            }
            window.opener.document.forms[0].submit();
            self.close();

        }
    
    </script>

    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">
                            Raw Materials Report</h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 95%">
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:Label ID="Label450" runat="server" CssClass="LBLBLACK" Width="200px">EM Udyog Aadhaar</asp:Label>
                                </td>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                    :
                                </td>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:TextBox ID="txtUdyogNo" runat="server" class="form-control txtbox" Height="28px"
                                        MaxLength="80" TabIndex="2" ValidationGroup="Save" Width="180px"></asp:TextBox>
                                </td>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                    &nbsp;
                                </td>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:Label ID="Label451" runat="server" CssClass="LBLBLACK" Width="200px">Status</asp:Label>
                                </td>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                    :
                                </td>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:DropDownList ID="ddlStatus" runat="server" class="form-control txtbox" Height="33px"
                                        Width="180px" TabIndex="1">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem>Pending</asp:ListItem>
                                        <asp:ListItem>Pre-Scrutiny Done</asp:ListItem>
                                        <asp:ListItem>Inspection Done</asp:ListItem>
                                        <asp:ListItem>Recommended to DIPC</asp:ListItem>
                                        <asp:ListItem>Proceeding COI</asp:ListItem>
                                        <asp:ListItem>Rejected</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" colspan="7">
                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                        OnClick="BtnSave1_Click" TabIndex="10" Text="Search" ValidationGroup="group"
                                        Width="90px" />
                                    &nbsp;
                                    <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                        Height="32px" TabIndex="10" Text="Cancel" ToolTip="To Clear  the Screen" Width="90px"
                                        OnClick="BtnClear_Click" />
                                </td>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" colspan="8">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" colspan="8">
                                    <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="13px"
                                        ForeColor="#006600"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px" colspan="8">
                                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Both">
                                        <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                            CssClass="GRD" ForeColor="#333333" Height="62px" OnRowDataBound="grdDetails_RowDataBound"
                                            PageSize="20" Width="100%" OnPageIndexChanging="grdDetails_PageIndexChanging"
                                            ShowFooter="True" OnRowCreated="grdDetails_RowCreated">
                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="EM Udyog Aadhaar" DataField="EMNoUdyogAadhaar" />
                                                <asp:BoundField HeaderText="Unit Name" DataField="UnitName" />
                                                <asp:BoundField HeaderText="Type of Application" DataField="TypeofApplication" />
                                                <asp:BoundField HeaderText="District Name" DataField="District_Name" />
                                                <asp:BoundField HeaderText="Mandal Name" DataField="Manda_lName" />
                                                <asp:BoundField HeaderText="Raw Meterial" DataField="Rawmetname" />
                                                <asp:BoundField HeaderText="Requirement" DataField="Requirement" />
                                                <asp:BoundField HeaderText="Usagedetails" DataField="Usagedetails" />
                                                <asp:BoundField HeaderText="Requirement Type" DataField="RequirementTypeA" />
                                                <asp:BoundField HeaderText="Date of application" DataField="Date of application" />
                                                <asp:HyperLinkField HeaderText="View" Text="View" />
                                                <asp:BoundField HeaderText="Status" DataField="Status" />
                                                <asp:TemplateField HeaderText="Status">
                                                    <ItemTemplate>
                                                        <table style="width: 100%" cellpadding="4" cellspacing="5">
                                                            <tr>
                                                                <td style="width: 132px; height: 29px">
                                                                    <asp:DropDownList ID="ddlStatus" runat="server" Width="120px" CssClass="DROPDOWN"
                                                                        AutoPostBack="True">
                                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                                        <asp:ListItem>Pre-Scrutiny Done</asp:ListItem>
                                                                        <asp:ListItem>Inspection Done</asp:ListItem>
                                                                        <asp:ListItem>Recommended to DIPC</asp:ListItem>
                                                                        <asp:ListItem>Proceeding COI</asp:ListItem>
                                                                        <asp:ListItem>Rejected</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4" align="center">
                                                                    <asp:Button ID="BtnSaveg" runat="server" CssClass="BUTTON" Height="20px" TabIndex="10"
                                                                        Text="update" ValidationGroup="group" Width="61px" OnClick="BtnSaveg_Click" />
                                                                    <asp:HiddenField ID="HdfintApplicationid" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#B9D684" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px" colspan="8">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" colspan="8">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px" colspan="8">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
