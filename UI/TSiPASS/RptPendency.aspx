<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="RptPendency.aspx.cs" Inherits="LookupCA" Title=":: TSiPASS Online Management System ::" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function GetRowValue(val) {
            if (val != '&nbsp;') {
                val1 = 0;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdfID').value = val;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdfFlagID').value = val1;

            }
            window.opener.document.forms[0].submit();
            self.close();

        }
    
    </script>

    <script language="javascript" type="text/javascript">
        function Panel1() {

            document.getElementById('<%=A1.ClientID %>').style.display = "none";
            var panel = document.getElementById("<%=divPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>newTable</title>');

            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();

            setTimeout(function() {
                printWindow.print();
                location.reload(true);
                printWindow.close();
            }, 1000);
            return false;

        }
    </script>


<%--<script type="text/javascript" src="../../js/jquery.min.js"></script>

    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>

    <script type="text/javascript" src="../../js/gridviewScroll.min.js"></script>

    <script type="text/javascript">

        function pageLoad() {
            $('#<%=grdDetails.ClientID%>').gridviewScroll({

                height: "100%",
                arrowsize: 30,
                varrowtopimg: "../../images/arrowvt.png",
                varrowbottomimg: "../../images/arrowvb.png",
                harrowleftimg: "../../images/arrowhl.png",
                harrowrightimg: "../../images/arrowhr.png"
            });
        } 
           
    </script>
--%>  
  <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <div class="panel panel-default">
                    <div class="panel-heading" style="text-align: center">
                        <h3 class="panel-title" style="font-weight: bold;">
                            R4.2: Department wise Pendency Report - Abstract<a id="A1" href="#" onclick="return Panel1();" runat="server">
                                <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" /></a>
                        </h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                            <tr>
                                <td style="padding: 5px; margin: 5px" align="right">
                                                <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboard.aspx" Text="<< Back">
                                                </asp:HyperLink>
                                            </td>
                                <td style="padding: 5px; text-align: right; margin: 5px; width: 100%">
                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK"></asp:Label>
                                </td>
                            </tr>
                            <tr id="div_Print" runat="server">
                                <td colspan="2" align="center" style="padding: 5px; margin: 5px">
                                    <asp:GridView ID="grdDetails" CssClass="floatingTable1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        OnRowDataBound="grdDetails_RowDataBound" Width="100%" OnRowCreated="grdDetails_RowCreated"
                                        ShowFooter="True">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="#FFFFFF" BackColor="#009688" Wrap="true"
                                            Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                        <RowStyle Height="40px" Wrap="true" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Header" />
                                        <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:HyperLinkField HeaderText="Department Name" DataTextField="DepartmentName">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="left"  />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:HyperLinkField>
                                            <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="CFE" DataField="CFEQuery">
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                <FooterStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="CFO" DataField="CFOQuery">
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                <FooterStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="CFE" DataField="CFEPreBeyond">
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                <FooterStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="CFO" DataField="CFOPreBeyond">
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                <FooterStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="CFE" DataField="CFEApprovalBeyond">
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                <FooterStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="CFO" DataField="CFOApprovalBeyond">
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                <FooterStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <script type="text/javascript">


        $(function () {



            if ($('table.floatingTable1').not('thead')) {
                var len = $('table.floatingTable1 tr').has('th').length;
                $('table.floatingTable1').prepend('<thead></thead>')
                for (i = 0; i < len; i += 1) {
                    $('table.floatingTable1').find('thead').append($('table.floatingTable1').find("tr:eq(" + i + ")"));
                }
            }



            var $table = $('table.floatingTable1');
            $table.floatThead();
            $table.floatThead({ position: 'fixed' });
            $table.floatThead({ autoReflow: 'true' });
            var $test = $('table.floatingTable1').width();
            // $('div[id="grid-table-container"]').width($test + 100);





           


        });

    </script>
</asp:Content>
