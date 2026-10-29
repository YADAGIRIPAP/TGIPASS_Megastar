<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="Appraisalnoteprint.aspx.cs" Inherits="UI_TSiPASS_Appraisalnoteprint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="divprint">
        <table style="width: 100%">
            <tr id="tideaTr" runat="server">
                <td style="text-align: left; font-weight: bold;">
                    <asp:Label ID="lblTideaTpride" runat="server" Visible="false" Text="Label"></asp:Label>
                    Telangana State Industrial Development and Entrepreneur Advancement - G.O M.S. NO 28, Industries &amp; Commerce (IP &amp; INF) Department,
                    <br />
                    Dated : 29/11/2014
                </td>
            </tr>
            <tr id="tprideTr" runat="server">
                <td style="text-align: left; font-weight: bold;">Telangana State Program for Rapid Incubation of Dalit Entrepreneurs - G.O M.S. NO 28, Industries &amp; Commerce (IP &amp; INF) Department,
                    <br />
                    Dated : 29/11/2014
                </td>
            </tr>
            <tr>
                <td style="text-align: center; font-weight: bold;">
                    <u>Sanction of Investment Subsidy - Appraisal Note</u></td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>Enter Incentive Application no
                            </td>
                            <td></td>
                            <td>

                                <asp:TextBox ID="txtINCNoEntry" class="form-control txtbox" Height="28px" MaxLength="80"
                                    TabIndex="2" runat="server" Width="150px"></asp:TextBox>

                            </td>
                            <td></td>
                           <%-- <td>
                                <asp:Button ID="btnINCSearch" CssClass="btn btn-xs btn-warning" runat="server" Text="Search" Height="30px" OnClick="btnINCSearch_Click" />
                            </td>--%>
                            <td colspan="5px"></td>
                            <td>Print Application no
                            </td>
                            <td></td>
                            <td>

                                <asp:TextBox ID="txtPrintINCID" Visible="false" class="form-control txtbox" Height="28px" MaxLength="80"
                                    TabIndex="2" runat="server" Width="150px"></asp:TextBox>


                            </td>
                            <td id="printTD" runat="server" visible="false">Please select incentive type
                                        <asp:DropDownList ID="ddlIcnetiveName" Height="30px" runat="server" Width="89px"></asp:DropDownList>
                            </td>
                            <td>

                                <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-xs btn-warning" Height="30px" Text="Print" OnClick="btnPrint_Click" />

                            </td>
                        </tr>
                    </table>

                </td>


            </tr>
            <tr>
                <td style="height: 30px" colspan="2"></td>
            </tr>
        </table>
    </div>
</asp:Content>

