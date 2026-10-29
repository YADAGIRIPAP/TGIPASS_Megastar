<%@ page language="C#" masterpagefile="CCMaster.master" autoeventwireup="true" codefile="HomeCoIDashboard.aspx.cs" inherits="UI_TSiPASS_HomeCoIDashboard" title=":: TS-iPass Govenrnment of Telengana :: Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;" valign="top" align="center">
                <table style="width: 100%">
                    <tr>
                        <td>
                            <asp:Label ID="Label437" runat="server"
                                CssClass="LBLBLACK" Font-Bold="True"
                                Font-Names="Verdana" Width="350px" Font-Size="20px" Height="40px">Dashboard</asp:Label>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">&nbsp;</td>
                        <td align="center" style="text-align: center">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>

                    <tr>
                        <td align="center" style="text-align: center" width="470px">
                            <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary"
                                Height="105px" OnClick="BtnSave1_Click" TabIndex="10" Text="NEW - INCENTIVE"
                                ValidationGroup="group" Width="268px" Font-Bold="True"
                                Font-Names="Verdana" Font-Size="18px" />
                        </td>
                        <td align="center" style="text-align: center" width="470px">
                            <asp:Button ID="btnTTAP" runat="server" CssClass="btn btn-primary"
                                Height="105px" OnClick="btnTTAP_Click" TabIndex="10" Text="TTAP - INCENTIVE"
                                ValidationGroup="group" Width="268px" Font-Bold="True"
                                Font-Names="Verdana" Font-Size="18px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">&nbsp;</td>
                        <td align="center" style="text-align: center">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center" width="470px">
                            <asp:Button target="_blank" ID="btnbulk" runat="server" CssClass="btn btn-primary"
                                Height="105px" OnClick="btnbulk_Click" Text="BULK PRINT APPRAISAL"
                                ValidationGroup="group" Width="268px" Font-Bold="True"
                                Font-Names="Verdana" Font-Size="18px" />
                        </td>
                        <td id="tdrelease" runat="server" visible="false" align="center" style="text-align: center" width="470px">
                            <asp:Button ID="btnReleasepending" runat="server" CssClass="btn btn-primary"
                                Height="105px" OnClick="btnReleasepending_Click" TabIndex="10" Text="Search Release Pending Unit"
                                ValidationGroup="group" Width="310px" Font-Bold="True"
                                Font-Names="Verdana" Font-Size="18px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center">&nbsp;</td>
                        <td align="center" style="text-align: center">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" style="text-align: center" width="470px">
                            <asp:Button ID="BTNPRINT" runat="server" CssClass="btn btn-primary"
                                Height="105px" OnClick="BTNPRINT_Click" TabIndex="10" Text="PRINT APPRAISAL"
                                ValidationGroup="group" Width="268px" Font-Bold="True"
                                Font-Names="Verdana" Font-Size="18px" />
                        </td>
                        <td align="center" style="text-align: center" width="470px"></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
