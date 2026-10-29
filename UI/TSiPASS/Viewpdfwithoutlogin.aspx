<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Viewpdfwithoutlogin.aspx.cs" Inherits="UI_TSiPASS_Viewpdfwithoutlogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-sm-3 form-group">
                <label>Enter URL</label>
                <asp:TextBox ID="txturl" runat="server" placeholder="URL" class="form-control" OnTextChanged="txturl_TextChanged" AutoPostBack="true"></asp:TextBox>
            </div>
        </div>
    </form>
</body>
</html>
