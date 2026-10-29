<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Show_AttachmentsNew.aspx.cs" Inherits="UI_TSiPASS_Show_AttachmentsNew" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .padding {
            margin: 10px 10px 10px 10px;
            padding-left: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <table style="padding-left: 25px; width: 600px;">
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <th style="text-align: center;">Documents / Attachments Submitted
                    </th>
                </tr>
                <tr>
                    <td align="left">
                        <asp:GridView ID="gvAttachments" runat="server" AutoGenerateColumns="False"
                            Width="100%" HorizontalAlign="Left" ShowHeader="false">
                            <Columns>
                                <asp:TemplateField HeaderText="Attachments">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl" runat="server" Text='<%# Eval("AttachmentName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="View">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" Text="view" NavigateUrl='<%#Eval("FilePath") %>' Target="_blank" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="tdStyle" align="center">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>


