<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="WebserviceUpdate.aspx.cs" Inherits="UI_TSiPASS_WebserviceUpdate" %>

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
                            <td>Uid No:
                            </td>
                            <td>
                                <asp:textbox id="txtuidno" runat="server" class="form-control txtbox"
                                    height="28px" tabindex="1"></asp:textbox>
                            </td>
                            <td>
                                <asp:button id="btnupdate" runat="server" cssclass="btn btn-primary" height="32px" onclick="btnupdate_Click" tabindex="15" text="Update" validationgroup="group" width="90px" />
                            </td>

                        </tr>
                        <tr>
                            <td colspan="3"></td>

                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>

                        </tr>

                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
