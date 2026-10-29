<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/webmasterpage.master" AutoEventWireup="true" CodeFile="FrmHDResultNew.aspx.cs" Inherits="FrmUsers" Title=":: TSiPASS TSiPASS ::  Result" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div style="width: 90%; text-align: center; margin:0 auto;">
    <table style="width: 100%; position: static; text-align: center;">
                    <tr>
                        <td style="width: 127px">
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: center">
                            <asp:Label ID="lblresult" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="11px"
                                ForeColor="Green" Style="position: static">Registered Successfully...! </asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            </td>
                    </tr>
                  <%--  <tr>
                        <td colspan="3" style="padding-bottom: 20px; padding-top: 20px" align="center">
                         <a href="print_new.aspx" target="_blank" style="color: blue">PRINT</a></td>
                    </tr>--%>
                     <tr>
                        <td colspan="3" 
                             style="padding-bottom: 20px; padding-top: 20px; text-align: center; vertical-align: middle;" 
                             align="center">
                         <a href="../../Index.aspx" target="_self" style="color: blue">Click Here to Login</a></td>
                    </tr>
                </table>
</div>
</asp:Content>

