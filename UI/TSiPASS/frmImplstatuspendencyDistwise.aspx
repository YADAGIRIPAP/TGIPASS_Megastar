<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSIPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="frmImplstatuspendencyDistwise.aspx.cs" Inherits="UI_TSIPASS_frmImplstatuspendencyDistwise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function Panel1() {
            document.getElementById('<%=btnGet.ClientID %>').style.display = "none";

            var panel = document.getElementById("<%=divPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><h3 style="width: 100%;text-align: center;">Government of Telangana</h3>');

            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();

            setTimeout(function () {
                printWindow.print();
                location.reload(true);
                printWindow.close();
            }, 1000);
            return false;

        }

        $(function () {

            $('#MstLftMenu').remove();



            //:nth-child(1)):not(:nth-child(2))
            //    $("[id$=grdDetails] tbody tr:not(:last)").each(function () {
            //        $(this).find("td:eq(3)").addClass('green');
            //        $(this).find("td:eq(4)").addClass('green');
            //        $(this).find("td:eq(5)").addClass('green');
            //        $(this).find("td:eq(6)").addClass('green');
            //        $(this).find("td:eq(7)").addClass('green');
            //        $(this).find("td:eq(8)").addClass('green');
            //        $(this).find("td:eq(9)").addClass('green');


            //        $(this).find("td:eq(17)").addClass('green');
            //        $(this).find("td:eq(18)").addClass('green');
            //        $(this).find("td:eq(19)").addClass('green');
            //        $(this).find("td:eq(20)").addClass('green');
            //        $(this).find("td:eq(21)").addClass('green');
            //        $(this).find("td:eq(22)").addClass('green');
            //        $(this).find("td:eq(23)").addClass('green');
            //    });

        });

    </script>
    <style>
        .algnCenter
        {
            text-align: right;
        }
        
        .yellow
        {
            background-color: yellow !important;
        }
        
        .green
        {
            background-color: #ceffee !important;
        }
    </style>
    <div class="col-lg-12">
        <div class="panel panel-default">
            <div class="panel-heading" align="center">
                <h2 class="panel-title" style="font-weight: bold;">
                    R6.9 : Status of Implementation Abstract - District wise Pendency
                    <%-- <a id="Button2" href="#" onclick="javascript:return Panel1();"
                                runat="server">--%>
                    <a id="pdfPrint" href="#" onclick="javascript:return Panel1();" runat="server">
                        <img src="../../Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                            style="float: right;" /></a> <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="Excel" /></a>
                </h2>
            </div>
            <div class="panel-body">
                <table align="center" cellpadding="10" cellspacing="5" style="width: 50%; font-family: 'Trebuchet MS'">
                    <tr>
                        <td colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboardNew.aspx"
                                Text="<< Back">
                            </asp:HyperLink>
                        </td>
                        <td  style="padding: 5px; text-align: right; margin: 5px" >
                                            <b>
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label></b>
                                        </td>
                    </tr>
                    <tr align="center">
                        <td colspan="3">
                            <table style="width: 80%">
                                <tr>
                                    <td align="center" style="padding: 5px; margin: 5px">
                                        <table style="width: 100%">
                                            <tr>
                                                <td align="center" style="text-align: left; width: 150px" valign="middle">
                                                    Type of Approval
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddltypeapps" runat="server" class="form-control txtbox" Height="33px"
                                                        Width="180px" TabIndex="1">
                                                        <asp:ListItem Value="A">--All--</asp:ListItem>
                                                        <asp:ListItem Value="Y">Online Approvals</asp:ListItem>
                                                        <asp:ListItem Value="N">Offline Approvals</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="center" style="text-align: left; width: 150px" valign="middle">
                                                    Application Type
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlTSiPASSType" runat="server" class="form-control txtbox"
                                                        Height="33px" Width="180px" TabIndex="1">
                                                        <asp:ListItem Value="A">--All--</asp:ListItem>
                                                        <asp:ListItem Value="State">State</asp:ListItem>
                                                        <asp:ListItem Value="district">District</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            Year
                                                        </div>
                                                        <asp:DropDownList ID="ddlType" runat="server" class="form-control txtbox" Height="33px"
                                                            Width="180px">
                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                            <%--<asp:ListItem Value="1">Cumulative</asp:ListItem>--%>
                                                            <asp:ListItem Value="2014">2014-15</asp:ListItem>
                                                            <asp:ListItem Value="2015">2015-16</asp:ListItem>
                                                            <asp:ListItem Value="2016">2016-17</asp:ListItem>
                                                            <asp:ListItem Value="2017">2017-18</asp:ListItem>
                                                            <asp:ListItem Value="2018">2018-19</asp:ListItem>
                                                            <asp:ListItem Value="2019">2019-20</asp:ListItem>
                                                            <asp:ListItem Value="2020">2020-21</asp:ListItem>
                                                            <asp:ListItem Value="2021">2021-22</asp:ListItem>
                                                            <asp:ListItem Value="2022">2022-23</asp:ListItem>
                                                            <asp:ListItem Value="2023">2023-24</asp:ListItem>
                                                            <asp:ListItem Value="2024">2024-25</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr id="trappstype" runat="server" visible="false">
                                                <td align="center" style="text-align: left; width: 100px" valign="middle">
                                                    District
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlConnectLoad" runat="server" class="form-control txtbox"
                                                        Height="33px" Width="180px" TabIndex="1">
                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr style="height: 60px">
                                                <td colspan="10" align="center" valign="bottom">
                                                    <asp:Button ID="btnGet" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10"
                                                        Text="Generate Report" Width="180px" OnClick="btnGet_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="10" align="center">
                                                    <asp:Label ID="lblMsg0" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="13px"
                                                        ForeColor="#006600"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height: 30px">
                        <td align="right">
                            <asp:Button ID="btnbdf" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10"
                                Text="Generate Pdf" OnClick="btnbdf_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" style="padding: 5px; margin: 5px" id="divPrint" runat="server">
                            <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                OnRowDataBound="grdDetails_RowDataBound" Width="100%" ShowFooter="True">
                                <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex +1 %>
                                            <asp:Label ID="lblDISRICT" runat="server" Text='<%# Eval("DISRICT") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="DISRICT" HeaderText="District Name"></asp:BoundField>
                                    <asp:BoundField DataField="LastUpdated" HeaderText="Last Updated"></asp:BoundField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Yet to Start Construction"
                                        DataTextField="ONEMONTHBELOW_YETSTART">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Initial Stage"
                                        DataTextField="ONEMONTHBELOW_INI">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Advanced Stage"
                                        DataTextField="ONEMONTHBELOW_ADV">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Commenced Operations"
                                        DataTextField="COMMENCED_OPERATIONS">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Dropped" DataTextField="DROPPED">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Total" DataTextField="TotalInds">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
