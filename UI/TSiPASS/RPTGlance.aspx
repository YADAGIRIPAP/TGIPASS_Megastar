<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="RPTGlance.aspx.cs" Inherits="LookupCA"
    Title=":: TSiPASS Online Management System ::" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
        function Panel1() {

            document.getElementById('<%=Button2.ClientID %>').style.display = "none";
            document.getElementById('<%=BtnBack.ClientID %>').style.display = "none";

            var panel = document.getElementById("<%=divPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><h3 style="width: 100%;text-align: center;">Government of Telangana</h3>');

            printWindow.document.write('</head><body style="width: 100%;text-align: center;">');
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
    
    <style>
    .width
    {
    width:65%;
    }
    </style>

    <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <div class="panel panel-default" style="font-family: Helvetica Neue, Helvetica, Arial, sans-serif;
                    font-size: 16px; line-height: 1.42857143;">
                    <div class="panel-heading" style="text-align: center">
                        <h3 visible="false" id="Government" runat="server" class="panel-title" style="font-weight: bold;">
                            Government of Telangana</h3>
                        <h2 class="panel-title" style="font-weight: bold;">
                            R1.1: TSiPASS AT A GLANCE REPORT <a id="Button2" href="#" onclick="javascript:return Panel1();"
                                runat="server">
                                <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" /></a>
                            <%--<a id="Button1" href="#" onserverclick="BtnSave2_Click" runat="server">
                                        <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a>--%></h2>
                    </div>
                    <div class="panel-body">
                        <table align="center"  class="width" cellspacing="5">
                            <tr>
                                 <td style="padding: 5px; margin: 5px" align="right">
                                                <asp:HyperLink CssClass="btn btn-link" ID="BtnBack" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboard.aspx" Text="<< Back">
                                                </asp:HyperLink>
                                            </td>
                                <td class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
                                </td>
                            </tr>
                            <%--<tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    &nbsp;
                                </td>
                            </tr>--%>
                            <tr style="width: 100%">
                                <td style="padding: 5px;" valign="top" colspan="2">
                                    <table  border="solid" style="width: 100%; border: 1px solid #929090;">
                                     <%-- <tr class="GridviewScrollC1Header">
                                            <td style="padding: 10px; margin: 5px; font-weight: bold; text-align: left;">
                                               S.No.
                                            </td>
                                            <td style="padding: 10px; margin: 5px; text-align: left;" colspan="2">
                                                <asp:Label ID="Label2" runat="server" Font-Bold="true" CssClass="LBLBLACK">Category</asp:Label>
                                            </td>
                                           
                                        </tr>--%>
                                        <tr style="background-color:#84b2b9;">
                                            
                                            <td colspan="3" style="padding: 10px; margin: 5px; text-align: center; color:White; font-weight:bold;">
                                                <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK">AT A GLANCE REPORT</asp:Label>
                                            </td>
                                           
                                        </tr>
                                        <tr>
                                            <td style="padding: 10px; margin: 5px;  text-align: left;">
                                                1
                                            </td>
                                            <td style="padding: 10px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK">Number of Industries given approvals since 01.01.2015</asp:Label>
                                            </td>
                                            <td style="padding: 10px; margin: 5px;  text-align: right;">
                                                <asp:Label ID="lblnumber" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 10px; margin: 5px;  text-align: left;">
                                                2
                                            </td>
                                            <td style="padding: 10px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label3" runat="server"  CssClass="LBLBLACK">Investment (Rs. in Crores)</asp:Label>
                                            </td>
                                            <td style="padding: 10px; margin: 5px;  text-align: right;">
                                                <asp:Label ID="lblinv" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 10px; margin: 5px; text-align: left;">
                                                3
                                            </td>
                                            <td style="padding: 10px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label5" runat="server"  CssClass="LBLBLACK">Employment</asp:Label>
                                            </td>
                                            <td style="padding: 10px; margin: 5px;  text-align: right;">
                                                <asp:Label ID="lblEmp" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 10px; margin: 5px;  text-align: left;">
                                                4
                                            </td>
                                            <td style="padding: 10px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label9" runat="server"  CssClass="LBLBLACK">Number of Industries - Commenced Operations</asp:Label>
                                            </td>
                                            <td style="padding: 10px; margin: 5px;  text-align: right;">
                                                <asp:Label ID="lblCO" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 10px; margin: 5px;  text-align: left;">
                                                5
                                            </td>
                                            <td style="padding: 10px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label11" runat="server"  CssClass="LBLBLACK">Number of Industries - Advanced Stage</asp:Label>
                                            </td>
                                            <td style="padding: 10px; margin: 5px;  text-align: right;">
                                                <asp:Label ID="lblas" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 10px; margin: 5px;  text-align: left;">
                                                6
                                            </td>
                                            <td style="padding: 10px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label4" runat="server"  CssClass="LBLBLACK">Number of Industries - Initial Stage</asp:Label>
                                            </td>
                                            <td style="padding: 10px; margin: 5px;  text-align: right;">
                                                <asp:Label ID="lblis" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 10px; margin: 5px;  text-align: left;">
                                                7
                                            </td>
                                            <td style="padding: 10px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label7" runat="server"  CssClass="LBLBLACK">Number of Industries - Yet to Start Construction</asp:Label>
                                            </td>
                                            <td style="padding: 10px; margin: 5px;  text-align: right;">
                                                <asp:Label ID="lblyet" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                    <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK"></asp:Label>
                                </td>
                            </tr>
                            <%--<tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="col-xs-5" style="padding: 5px; text-align: center; margin: 5px">
                                    <asp:Label ID="Label2" Font-Bold="true" runat="server" CssClass="LBLBLACK">IMPLEMENTATION STATUS</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        Width="100%" ShowFooter="false">
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
                                            <asp:BoundField DataField="Progress" HeaderText="Stages of Implementation"></asp:BoundField>
                                            <asp:BoundField DataField="Number" HeaderText="Number of Industries">
                                                <ItemStyle Font-Bold="true" HorizontalAlign="Center" CssClass="text-right" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>--%>
                            <%--<tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    <div>

                                        <script type="text/javascript" src="../../js/googleapi.js"></script>

                                        <asp:Literal ID="ltrPie" runat="server"></asp:Literal>
                                        <div id="piechart_3d" style="border-style: solid; border-width: 1px; width: 100%;
                                            height: 500px;">
                                        </div>
                                    </div>
                                </td>
                            </tr>--%>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
