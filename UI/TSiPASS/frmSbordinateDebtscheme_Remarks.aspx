<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmSbordinateDebtscheme_Remarks.aspx.cs" MasterPageFile="~/UI/TSiPASS/BankMaster.master" Inherits="UI_TSIPASS_frmSbordinateDebtscheme_Remarks" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:UpdatePanel ID="upd1" runat="server"> 
    <ContentTemplate>
         <table id="gridDiv" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
             <tr>
                 <td style="width:10px">
                     Remarks
                 </td>
                 <td >
                     <asp:TextBox ID="txtRemarks"  runat="server" TextMode="MultiLine" class="form-control txtbox" Height="125px" Width="397px"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>

                 </td>
             </tr>
             <tr>
                 <td>

                 </td>
                 <td>
                      <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                                        TabIndex="11" Text="Save" Width="90px" ValidationGroup="group" OnClick="BtnSave1_Click" />
                 </td>
             </tr>
         </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>