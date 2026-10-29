<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"  AutoEventWireup="true" CodeFile="updateCFOWebservice.aspx.cs" Inherits="UI_TSiPASS_updateCFOWebservice" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center">
        <tr>
            <td>
                UID No:
            </td>
            <td>
                <asp:TextBox ID="txtUIDno" class="form-control txtbox" Width="150px" runat="server"></asp:TextBox>
            </td>
            <td colspan="10px">

            </td>
            <td>
                <asp:Button ID="txtUpdate"  CssClass="btn btn-primary" Height="32px"
                   Text="Update" Width="90px"  runat="server" OnClick="txtUpdate_Click"  />
            </td>
        </tr>
    </table>

</asp:Content>

