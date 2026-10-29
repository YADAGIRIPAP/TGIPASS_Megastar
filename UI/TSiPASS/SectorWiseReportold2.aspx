<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="SectorWiseReportold2.aspx.cs" Inherits="LookupCA"
    Title=":: TSiPASS Online Management System ::" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

   <script type="text/javascript" src="../../js/jquery.min.js"></script>

    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>

    <script type="text/javascript" src="../../js/gridviewScroll.min.js"></script>
    <script language="javascript" type="text/javascript">
        function removescrolling() {
            $('#<%=divPrint.ClientID %>').addClass('removescroll');
            $('#<%=grdDetails.ClientID%>').gridviewScroll({

            });
        }
        function pageLoad() {
            $('#<%=grdDetails.ClientID%>').gridviewScroll({
                width: "1024px",
                height: "100%",
                arrowsize: 30,
                varrowtopimg: "../../images/arrowvt.png",
                varrowbottomimg: "../../images/arrowvb.png",
                harrowleftimg: "../../images/arrowhl.png",
                harrowrightimg: "../../images/arrowhr.png"
            });
            //loadfirstRow();
        }
        function Panel1() {
            document.getElementById('<%=Button1.ClientID %>').style.display = "none";
            document.getElementById('<%=Button2.ClientID %>').style.display = "none";
            document.getElementById('<%=GraphPrint.ClientID %>').style.display = "none";
            document.getElementById('<%=HyperLink1.ClientID %>').style.display = "none";
            removescrolling();
            var panel = document.getElementById("<%=divPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><h3 style="width: 100%;text-align: center;">Government of Telangana</h3>');

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
    
    <script language="javascript" type="text/javascript">
        function Panel2() {
            document.getElementById('<%=Button1.ClientID %>').style.display = "none";
            document.getElementById('<%=Button2.ClientID %>').style.display = "none";
            document.getElementById('<%=A1.ClientID %>').style.display = "none";
            document.getElementById('<%=GridPrint.ClientID %>').style.display = "none";
            document.getElementById('<%=HyperLink1.ClientID %>').style.display = "none";

            var panel = document.getElementById("<%=divPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><h3 style="width: 100%;text-align: center;">Government of Telangana</h3>');

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

    <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading" style="text-align: center">
                            <h3 visible="false" id="Government" runat="server" class="panel-title" style="font-weight: bold;">
                                Government of Telangana</h3>
                            <h2 class="panel-title">
                                R6.2: TSiPASS - Sector Wise Report<a id="Button2" href="#" onclick="javascript:return Panel1();"
                                    runat="server">
                                    <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                        alt="PDF" /></a> <a id="Button1" href="#" onserverclick="BtnSave2_Click" runat="server">
                                            <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                                alt="Excel" /></a></h2>
                        </div>
                        <div class="panel-body">
                            <table align="center" cellpadding="10" cellspacing="5" style="width: 80%">
                                <tr>
                                    <td>
                                        <table runat="server" id="tblselection" cellpadding="4" cellspacing="5" style="width: 100%">
                                            <tr>
                                                <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboard.aspx"
                                                        Text="<< Back">
                                                    </asp:HyperLink>
                                                </td>
                                                <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            Type
                                                        </div>
                                                        <asp:DropDownList ID="ddlType" runat="server" class="form-control txtbox" Height="33px"
                                                            Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem Value="1">Cumulative</asp:ListItem>
                                                            <%--<asp:ListItem Value="2">2015-16</asp:ListItem>--%>
                                                            <asp:ListItem Value="3">2016-17</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td style="padding: 5px; margin: 5px" align="right">
                                                    <asp:Button ID="Button3" runat="server" CssClass="btn btn-default" TabIndex="10"
                                                        Text="Submit" OnClick="BtnSave1_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="padding: 5px; text-align: right; margin: 5px; width: 100%;">
                                        <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                        <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="GridPrint" runat="server">
                                    <td colspan="2" align="center" style="padding: 5px; margin: 5px">
                                        <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                            OnRowDataBound="grdDetails_RowDataBound" Width="100%" OnPageIndexChanging="grdDetails_PageIndexChanging"
                                            ShowFooter="True" OnRowCreated="grdDetails_RowCreated" OnSelectedIndexChanged="grdDetails_SelectedIndexChanged">
                                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                            <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                            <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                            <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Sectorandmajor" HeaderText="Sector-Major">
                                                    <ItemStyle Wrap="true" CssClass="text-uppercase" />
                                                </asp:BoundField>
                                                <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="Number" HeaderText="No of Industries">
                                                    <FooterStyle HorizontalAlign="Center" Font-Bold="true" Font-Underline="false" CssClass="text-center" />
                                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <asp:HyperLinkField FooterStyle-CssClass="text-center" DataTextField="Investment"
                                                    ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black" HeaderText="Investment (Rs. in Cr)">
                                                    <FooterStyle HorizontalAlign="Center" Font-Bold="true" Font-Underline="false" CssClass="text-center" />
                                                    <ItemStyle Font-Underline="false" Wrap="true" HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <asp:HyperLinkField FooterStyle-CssClass="text-center" DataTextField="Employment"
                                                    ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black" HeaderText="Total Employment">
                                                    <FooterStyle HorizontalAlign="Center" Font-Bold="true" Font-Underline="false" CssClass="text-center" />
                                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr id="GraphPrint" runat="server">
                                    <td colspan="2" align="center" style="padding: 5px; margin: 5px">
                                    <a id="A1" href="#" onclick="javascript:return Panel2();" runat="server">
                                                    <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                                        alt="PDF" /></a> 
                                        <div>
                                            <br />
                                            <br />
                                                

                                            <script type="text/javascript" src="../../js/googleapi.js"></script>

                                            <asp:Literal ID="ltrPie" runat="server"></asp:Literal>
                                            <div id="piechart_3d" style="border-style: solid; border-width: 1px; width: 100%;
                                                height: 600px;">
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
