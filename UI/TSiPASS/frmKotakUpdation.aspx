<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmKotakUpdation.aspx.cs" Inherits="UI_TSiPASS_frmKotakUpdation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <table style="width: 100%">
            <tr>
                <td></td>
            </tr>
            <tr>
                <td>
                    <table style="text-align: center; width: 100%" align="center">
                        <tr>
                            <td colspan="3"><strong>Data Updation to Departments</strong></td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;</td>
                        </tr>
                        <tr id="Tr1" runat="server">
                            <td colspan="3"></td>

                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>

                        <tr align="center">
                            <td>Enter Response Meesage:
                            </td>
                            <td>
                                <asp:TextBox ID="txtuidno" runat="server" class="form-control txtbox"
                                    Height="28px" TabIndex="1" Width="150px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                      
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Button ID="btnupdate" runat="server" CssClass="btn btn-primary" Height="32px" OnClick="btnupdate_Click" TabIndex="15" Text="Update" ValidationGroup="group" Width="90px" />
                            </td>

                        </tr>
                        <tr>
                            <td colspan="3">&nbsp;</td>

                        </tr>
                        <tr>
                            <td align="center" colspan="5" style="padding: 5px; margin: 5px">
                                <div id="success" runat="server" visible="false" class="alert alert-success">
                                    <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                </div>
                                <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                    <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                </div>
                            </td>
                        </tr>

                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

