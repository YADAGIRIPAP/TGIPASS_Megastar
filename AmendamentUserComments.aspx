<%@ Page Title="" Language="C#" MasterPageFile="~/EmptyMaster2.master" AutoEventWireup="true"
    CodeFile="AmendamentUserComments.aspx.cs" Inherits="AmendamentUserComments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <table style="width: 100%">
            <tr>
                <td style="width: 49%">
                    <asp:Panel runat="server" ID="Panel1">
                        <iframe runat="server" id="IframePanel" width="100%" height="360px"></iframe>
                    </asp:Panel>
                </td>
                <td>
                    <asp:Label runat="server" Width="50px" ID="lblwidth" Visible="false"></asp:Label>
                </td>
                <td style="width: 49%; border: 2px solid">
                    <asp:Panel runat="server" ID="Panel2">
                        <table style="text-align: center; width: 100%" align="center">
                            <tr runat="server" id="trComments" visible="false">
                                <td>
                                    <table cellpadding="4" cellspacing="5" align="center">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 150px">
                                                User Name
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtUserName" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="50" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUserName"
                                                    ErrorMessage="Please Enter User Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                District
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                    Height="33px" Width="180px">
                                                    <asp:ListItem>--District--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlDistrict"
                                                    InitialValue="--District--" ErrorMessage="Please select District" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                Mobile Number
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtMobileNo" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="10" TabIndex="0" ToolTip="text" onkeypress="NumberOnly()" ValidationGroup="group"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMobileNo"
                                                    ErrorMessage="Please Enter Mobile Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                Mail Id
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEmailId" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                Department
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlDepartments" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                    Height="33px" Width="180px" OnSelectedIndexChanged="ddlDepartments_SelectedIndexChanged">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlDepartments"
                                                    InitialValue="--Select--" ErrorMessage="Please select Department" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                Amendment
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlAmendment" runat="server" class="form-control txtbox" Height="33px"
                                                    Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlAmendment"
                                                    InitialValue="--Select--" ErrorMessage="Please select Amendment" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                Comments
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" colspan="4">
                                                <asp:TextBox ID="txtComments" runat="server" class="form-control txtbox" Height="91px"
                                                    MaxLength="50" TabIndex="0" TextMode="MultiLine" ValidationGroup="group" Width="500px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtComments"
                                                    ErrorMessage="Please enter Comments" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                            <%--<td></td>
                                                            <td></td>--%>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="text-align: center; height: 20px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="text-align: center">
                                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-warning" Height="32px"
                                                    OnClick="btnSave_Click" Text="SUBMIT USER COMMENTS" ValidationGroup="group" Width="200px" />
                                                &nbsp;
                                                <asp:Button ID="btnClear" runat="server" CssClass="btn btn-warning" Height="32px"
                                                    OnClick="btnClear_Click" Text="CLEAR" Width="120px" />
                                            </td>
                                            <%--  <td colspan="4" style="text-align: center">&nbsp;</td>--%>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="text-align: center">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="text-align: center">
                                                <asp:Button ID="btnviewcomments" runat="server" CssClass="btn btn-warning" Height="32px"
                                                    OnClick="btnviewcomments_Click" Text="VEIW PUBLIC COMMENTS" Width="200px" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center;" align="center">
                                    <table style="width: 100%">
                                        <tr id="Tr1" runat="server">
                                            <td align="center" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                                vertical-align: middle; padding-top: 5px; text-align: center" valign="middle">
                                                <asp:Label ID="lblresult" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="11px"
                                                    ForeColor="Green" Style="position: static"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="Reject">
                                            <td align="center" style="padding: 5px; vertical-align: middle; text-align: center"
                                                valign="middle">
                                                <asp:Label ID="lblerrMsg" runat="server" Font-Bold="True" ForeColor="Red" Width="270px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="Close">
                                            <td align="center" style="padding: 5px; vertical-align: middle; text-align: center"
                                                valign="middle">
                                                <asp:Label ID="lblStatus" runat="server" Font-Bold="True" ForeColor="Red" Width="272px"></asp:Label>
                                                <%--<a target="_blank" style="font-family: fantasy; font-size: larger; font-weight: bold; font-style: normal; color: #8B0000; text-underline-position: auto">AAAA</a>--%>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
