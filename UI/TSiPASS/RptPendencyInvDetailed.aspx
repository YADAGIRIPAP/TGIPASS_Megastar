<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="RptPendencyInvDetailed.aspx.cs" Inherits="LookupCA" Title=":: TSiPASS Online Management System ::" %>

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
        $(function () {

            $('#MstLftMenu').remove();

        });
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

    <script type="text/javascript" src="../../js/gridviewScroll.min.js"></script>--%>

    <script type="text/javascript">

//        function pageLoad() {
//            $('#<%=grdDetails.ClientID%>').gridviewScroll({
//                width: "100%",
//                height: "100%",
//                arrowsize: 30,
//                varrowtopimg: "../../images/arrowvt.png",
//                varrowbottomimg: "../../images/arrowvb.png",
//                harrowleftimg: "../../images/arrowhl.png",
//                harrowrightimg: "../../images/arrowhr.png"
//            });
//        } 
           
    </script>

    <style>
        .algnCenter
        {
            text-align: center;
        }
    </style>
    <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <div class="panel panel-default">
                    <div class="panel-heading" style="text-align: center">
                        <h3 class="panel-title" style="font-weight: bold;">
                            <asp:Label runat="server" ID="lblHeading"></asp:Label><a id="A1" href="#" onserverclick="BtnSave2_Click"
                                runat="server">
                                <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" /></a>
                        </h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                        
                            <tr>
                                <td style="text-align: left">
                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/RptPendencyinvestmentwise.aspx"
                                        Text="<< Back">
                                    </asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; text-align: right; margin: 5px; width: 100%">
                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK"></asp:Label>
                                </td>
                            </tr>
                            <tr id="div_Print" runat="server">
                                <td align="center" style="padding: 5px; margin: 5px">
                                    <asp:GridView ID="grdDetails" CssClass="floatingTable" runat="server" AutoGenerateColumns="true" CellPadding="4" 
                                        OnRowDataBound="grdDetails_RowDataBound" Width="100%" ShowFooter="True">
                                        <HeaderStyle Wrap="true" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                        <RowStyle Wrap="true" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                        <AlternatingRowStyle Wrap="true" CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <ItemStyle  HorizontalAlign="Center" CssClass="text-center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <%--<asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="Name of the Industry"
                                                DataField="Name of the Industry">
                                               
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="UID Number" DataField="UID Number">
                                                
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="Total Investment (in Crores)" DataField="Total Investment (in Crores)">
                                                
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="Department" DataField="Department">
                                                
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="Type of Service" DataField="Type of Service">
                                                
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="Status" DataField="Status">
                                                
                                            </asp:BoundField>--%>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                             <tr id="divExport" visible="false" runat="server">
                                <td align="center" style="text-align: center;" valign="top">
                                    <asp:GridView ID="grdExport" runat="server" AutoGenerateColumns="true" ShowFooter="true">
                                        
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                    
                                                </ItemTemplate>
                                                <ItemStyle CssClass="text-center" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                           
                                        </Columns>
                                        <RowStyle Wrap="true" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
