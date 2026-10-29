<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="DashboardINC.aspx.cs" Inherits="UI_TSiPASS_DashboardINC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $(function () {

            $('#MstLftMenu').remove();

        });
    </script>
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; padding-top: 50px; height: 675px;" valign="top" align="center">
                <table style="width: 100%">
                    <tr>
                        <td></td>
                        <td colspan="2" align="center">
                            <asp:Label ID="Label437" runat="server"
                                Font-Bold="True" Font-Names="Verdana" Width="350px" Font-Size="20px"
                                Height="40px">Incentive's Dashboard</asp:Label>
                        </td>
                        <td></td>
                    </tr>

                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td></td>
                        <td align="center" style="text-align: center">
                            <asp:Button ID="btnIncentive" runat="server" BackColor="Orange"
                                CssClass="btn btn-danger" Height="91px" TabIndex="10"
                                Text="Incentives" Font-Bold="True" Width="268px"
                                ValidationGroup="group" Font-Names="Verdana" Font-Size="18px"
                                OnClick="btnIncentive_Click" />
                        </td>
                        <td align="center" style="text-align: center">
                            <asp:Button ID="btncmpltd" runat="server"
                                CssClass="btn btn-danger" Height="91px" TabIndex="10" BackColor="Green"
                                Text="Applications Processed" Font-Bold="True" Width="268px"
                                ValidationGroup="group" Font-Names="Verdana" Font-Size="18px"
                                OnClick="btncmpltd_Click" />
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

