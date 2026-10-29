<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="RptCasteType.aspx.cs" Inherits="LookupCA"
    Title=":: TSiPASS Online Management System ::" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- <script type="text/javascript">
        function GetRowValue(val) {
            if (val != '&nbsp;') {
                val1 = 0;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdfID').value = val;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdfFlagID').value = val1;

            }
            window.opener.document.forms[0].submit();
            self.close();

        }
    
    </script>--%>
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h2 id="H1" runat="server" class="panel-title" style="font-weight: bold;">
                            Caste Wise Report
                        </h2>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                            <tr>
                                <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
                                </td>
                            </tr>
                            <tr id="divPrint" runat="server" style="padding: 5px; margin: 5px; ">
                                <td align="center" style="padding: 5px; vertical-align:middle; margin: 5px; width: 40%; height: 600px;">
                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="100%"
                                        OnRowDataBound="grdDetails_RowDataBound" ShowFooter="True">
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Header" />
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <HeaderStyle Width="40px" HorizontalAlign="Center" />
                                                <ItemStyle Width="20px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Caste" HeaderText="Caste">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle CssClass="text-uppercase"  Width="100px"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="No of Applications" HeaderText="No of Applications">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center"  Width="100px"/>
                                            </asp:BoundField>
                                            <%--<asp:BoundField DataField="Investment" HeaderText="Investment (Rs. in Cr)">
                                                        <ItemStyle CssClass="text-center" Width="180px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Employment" HeaderText="Employment">
                                                        <ItemStyle CssClass="text-center" Width="180px" />
                                                    </asp:BoundField>--%>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <%-- </tr>
                            <tr>--%>
                                <td align="center" style="padding: 5px; margin: 5px; width: 60%; height: 600px;">
                                    <div style="width: 100%; ">

                                        <script type="text/javascript" src="../../js/googleapi.js"></script>

                                        <asp:Literal ID="ltrPie" runat="server"></asp:Literal>
                                        <div id="piechart_3d" style="width: 100%; height: 600px;">
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <%--<tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    &nbsp;</td>
                            </tr>
                           <tr>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                   
                                    
                                    
                                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Height="32px"
                                        TabIndex="10" Text="Export" Width="90px" OnClick="BtnSave2_Click" />
                                </td>
                            </tr>--%>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
