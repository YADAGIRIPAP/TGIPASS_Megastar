<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="MSWSPRECHECK.aspx.cs" Inherits="UI_TSiPASS_MSWSPRECHECK" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr align="center">
                    <td>Username:
                    </td>
                    <td>
                        <asp:TextBox ID="txtusername" runat="server" class="form-control txtbox"
                            Height="28px" TabIndex="1" Width="150px"></asp:TextBox>
                    </td>
                    <td>Password:
                    </td>
                    <td>
                        <asp:TextBox ID="txtpassword" runat="server" class="form-control txtbox"
                            Height="28px" TabIndex="2" Width="150px"></asp:TextBox></td>
                    <td>
                        <asp:Button ID="btnupdate" runat="server" CssClass="btn btn-primary" Height="32px" OnClick="btnupdate_Click" TabIndex="15" Text="Update" ValidationGroup="group" Width="90px" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>