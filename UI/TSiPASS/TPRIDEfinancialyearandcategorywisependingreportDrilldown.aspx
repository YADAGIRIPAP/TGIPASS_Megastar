<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="TPRIDEfinancialyearandcategorywisependingreportDrilldown.aspx.cs"
    Inherits="UI_TSiPASS_TPRIDEfinancialyearandcategorywisependingreportDrilldown" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function PrintDrilldownReport() {
            var panel = document.getElementById("<%=divPrint.ClientID %>");
            if (!panel) return false;

            var printWindow = window.open('', '', 'height=600,width=1200');
            printWindow.document.write('<html><head><title>T-PRIDE Financial Year Claim Details</title>');
            printWindow.document.write('<style>table{width:100%;border-collapse:collapse;font-family:Arial;font-size:11px;} th,td{border:1px solid #777;padding:4px;text-align:center;}</style>');
            printWindow.document.write('</head><body>');
            printWindow.document.write('<h3 style="text-align:center;">Government of Telangana</h3>');
            printWindow.document.write('<h4 style="text-align:center;">' + document.getElementById('<%=lblHeading.ClientID %>').innerText + '</h4>');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();

            setTimeout(function () {
                printWindow.print();
                printWindow.close();
            }, 800);
            return false;
        }

        $(function () {
            $('#MstLftMenu').remove();
        });
    </script>

    <style type="text/css">
        .drilldown-grid th,
        .drilldown-grid td {
            font-size: 11px;
            vertical-align: middle;
        }

        .amount-column {
            text-align: right !important;
        }
    </style>

    <table id="Table1" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px;" valign="top" align="center">
                <div class="panel panel-default">
                    <div class="panel-heading" style="text-align: center;">
                        <h3 class="panel-title" style="font-weight: bold;">
                            <asp:Label ID="lblHeading" runat="server"></asp:Label>
                            <a id="lnkPrint" href="#"  visible="false" onclick="javascript:return PrintDrilldownReport();" runat="server">
                                <img src="../../Resource/Images/pdf-printer-icon.jpg" alt="Print" width="30" height="30" style="float: right;" />
                            </a> 
                            <asp:LinkButton ID="btnExportExcel"  visible="false" runat="server" OnClick="btnExportExcel_Click" CausesValidation="false" Style="float: right; margin-right: 8px;">
                                <img src="../../Resource/Images/Excel-icon.png" alt="Excel" width="20" height="20" />
                            </asp:LinkButton>
                        </h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="8" cellspacing="4" style="width: 100%; font-family: 'Trebuchet MS';">
                            <tr>
                                <td align="left">
                                    <asp:HyperLink CssClass="btn btn-link" ID="lnkBack" runat="server"
                                        NavigateUrl="~/UI/TSiPASS/TPRIDEfinancialyearandcategorywisependingreport.aspx" Text="&lt;&lt; Back" />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblReportDate" runat="server" CssClass="LBLBLACK"></asp:Label>
                                </td>
                            </tr>
                            <tr id="divPrint" runat="server">
                                <td align="center" colspan="2" style="padding: 5px;">
                                    <div style="width: 100%; overflow-x: auto;">
                                        <asp:GridView ID="gvClaimDetails" runat="server" Width="100%" AutoGenerateColumns="False"
                                            CssClass="drilldown-grid table table-bordered table-striped" GridLines="None"
                                            ShowHeader="True" CellPadding="4">
                                            <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                            <RowStyle CssClass="GridviewScrollC1Item" />
                                            <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sl.No">
                                                    <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="DISTRICT" HeaderText="District" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NAMEOFUNIT" HeaderText="Name of Unit">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DISTRICTNAME" HeaderText="District Name">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="CASTE" HeaderText="Caste">
     <ItemStyle HorizontalAlign="Left" />
 </asp:BoundField>
                                                <asp:BoundField DataField="SANCTIONED_DATE" HeaderText="Sanctioned Date">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SANCTIONEDAMOUNT" HeaderText="Sanctioned Amount" DataFormatString="{0:N2}" HtmlEncode="false">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle CssClass="amount-column" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="INCENTIVENAME" HeaderText="Incentive Name">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="schemename" HeaderText="Scheme Name"  Visible="false">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CATEGORYID" HeaderText="Category Id" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CATEGORY" HeaderText="Category">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Label ID="lblNoRecords" runat="server" ForeColor="Red" Visible="false" Text="No Records Found"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
