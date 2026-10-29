<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmKotakReversalResponseToken.aspx.cs" Inherits="UI_TSiPASS_frmKotakReversalResponseToken" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr align="center">
            <td>
                Online Order Number:
            </td>
            <td>
                <asp:TextBox ID="txtordernumber" runat="server" class="form-control txtbox" Height="28px"
                    TabIndex="1" Width="150px"></asp:TextBox>
            </td>
            <td>
                Date(YYYY-MM-DD):
            </td>
            <td>
                <asp:TextBox ID="txtdate" runat="server" class="form-control txtbox" Height="28px"
                    TabIndex="1" Width="150px"></asp:TextBox>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:Button ID="btnupdate" runat="server" CssClass="btn btn-primary" Height="32px"
                    OnClick="btnupdate_Click" TabIndex="15" Text="Update" ValidationGroup="group"
                    Width="90px" />
            </td>
        </tr>
        <tr>
            <td align="center" style="padding: 5px; margin: 5px">
                <div id="success" runat="server" class="alert alert-success" visible="false">
                    <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">
                        ×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                </div>
                <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                    <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                    <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

