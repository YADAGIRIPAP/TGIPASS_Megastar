<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmfailedpayments.aspx.cs" Inherits="UI_TSiPASS_frmfailedpayments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TextBox ID="txtdata" runat="server" class="form-control txtbox"
                                    Height="28px" TabIndex="1" Width="150px"></asp:TextBox>
        <asp:Button ID="btnupdate" Text="Update Payment" runat="server" OnClick="btnupdate_Click" />
</asp:Content>

