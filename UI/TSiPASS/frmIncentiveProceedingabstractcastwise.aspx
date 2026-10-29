<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSIPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmIncentiveProceedingabstractcastwise.aspx.cs" Inherits="UI_TSiPASS_frmIncentiveProceedingabstractcastwise" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <script language="javascript" type="text/javascript">
        function Panel1() {
            document.getElementById('<%=btnGet.ClientID %>').style.display = "none";
            document.getElementById('<%=Button2.ClientID %>').style.display = "none";

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

            if ($('table.floatingTable2').not('thead')) {
                var len = $('table.floatingTable2 tr').has('th').length;
                $('table.floatingTable2').prepend('<thead></thead>')
                for (i = 0; i < len; i += 1) {
                    $('table.floatingTable2').find('thead').append($('table.floatingTable2').find("tr:eq(" + i + ")"));
                }
            }

            var $table = $('table.floatingTable2');
            $table.floatThead();
            $table.floatThead({ position: 'fixed' });
            $table.floatThead({ autoReflow: 'true' });


            if ($('table.floatingTable1').not('thead')) {
                var len1 = $('table.floatingTable1 tr').has('th').length;
                $('table.floatingTable1').prepend('<thead></thead>')
                for (i = 0; i < len1; i += 1) {
                    $('table.floatingTable1').find('thead').append($('table.floatingTable1').find("tr:eq(" + i + ")"));
                }
            }

            var $table1 = $('table.floatingTable1');
            $table1.floatThead();
            $table1.floatThead({ position: 'fixed' });
            $table1.floatThead({ autoReflow: 'true' });
        });

    </script>

    <style>
        .algnCenter {
            text-align: right;
        }

        /*body {
            font: normal 10px Verdana, Arial, sans-serif;
        }*/
    </style>
    <div class="col-lg-12">
        <div class="panel panel-default">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td colspan="4">
                        <div class="panel-heading" align="center">
                            <h2 class="panel-title" style="font-weight: bold;">R2.1 Release Proceedings - Abstract of SLC & DLC    
                                <%-- <a id="Button2" href="#" onclick="javascript:return Panel1();"
                                runat="server">--%>
                                <a id="Button2" href="#" onserverclick="BtnPDF_Click"
                                    runat="server" visible="false">
                                    <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                        alt="PDF" /></a>
                                <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server" visible="false">
                                    <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                        alt="Excel" /></a> </h2>
                        </div>

                    </td>
                </tr>
                <tr>
                    <td><br /></td>
                </tr>
                <br />
                <tr>
                    <td style="text-align: left">
                        <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/IncentiveReportsDashboard.aspx" Text="<< Back">
                        </asp:HyperLink>
                    </td>
                </tr>
                <tr align="center">
                    <td colspan="3">
                        <table style="width: 80%">
                            <tr>
                                   <td style="padding: 5px; margin: 5px">Cast:   
                                                
                                </td>
                                <td> 
                                    <asp:DropDownList ID="ddl_cast" runat="server" Height="28px" Width="125px" ValidationGroup="group">
                                       <%-- <asp:ListItem Value="-1" Text="-Select-"></asp:ListItem>--%>
                                        <asp:ListItem Value="0" Text="SC"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="ST"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="OTHERS"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="ALL"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="padding: 5px; margin: 5px">From Date:   
                                                
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                    <cc1:calendarextender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                    </cc1:calendarextender>
                                </td>
                                <td style="padding: 5px; margin: 5px">To Date:  
                                            
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                    <cc1:calendarextender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                    </cc1:calendarextender>
                                </td>
                            </tr>
                            </table>
                      <br /><br />
                         <table style="width: 80%">
                            <tr>
                          <td style="padding: 5px; margin: 5px" align="center">
                                    <asp:Button ID="btnGet" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Generate Report" Width="180px" OnClick="btnGet_Click" />

                                </td>
                                </tr>
                        </table>
                    </td>
                </tr>
                <tr style="height: 30px">
                    <td align="right">
                    <%--    <asp:Button ID="btnbdf" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Download Pdf" OnClick="btnbdf_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                         <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Download Excel" OnClick="BtnSave2_Click" />
                    </td>
                </tr>
                <tr style="height: 50px">
                    <td>
                        <h2 class="panel-title" style="font-weight: bold;">1). SLC : </h2>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center" style="padding: 5px; margin: 5px" id="divPrint" runat="server">
                        <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="100%"
                            ShowFooter="True" OnRowCreated="grdDetails_RowCreated" CssClass="floatingTable" OnRowCommand="grdDetails_RowCommand">
                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                            <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                            <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                            <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex +1 %>
                                        <asp:Label ID="lblDistId" runat="server" Text='<%# Eval("DistId") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="District" HeaderText="District Name"></asp:BoundField>
                              <%--  <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="NO of Units"
                                    DataTextField="NO UNITS SLC">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                </asp:HyperLinkField>--%>
                                <asp:TemplateField HeaderText="NO of Units">
                                    <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="Lb1" Font-Underline="False" runat="server" Text='<%# Eval("NO UNITS SLC") %>'
                                                                CommandName="NOUNITS_SLC" CommandArgument='<%# Eval("DistId")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                <asp:BoundField DataField="AMOUNT RELEASED SLC" HeaderText="Amount" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                <%--<asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Working Units"
                                    DataTextField="Working Units SLC">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                </asp:HyperLinkField>--%>
                                <asp:TemplateField HeaderText="Working Units">
                                    <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="Lb2" Font-Underline="False" runat="server" Text='<%# Eval("Working Units SLC") %>'
                                                                CommandName="WorkingUnits_SLC" CommandArgument='<%# Eval("DistId")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                <asp:BoundField DataField="Working AMOUNT SLC" HeaderText="Amount" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                <%--<asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="UC Not Updated"
                                    DataTextField="UC Not Updated SLC">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                </asp:HyperLinkField>--%>
                                 <asp:TemplateField HeaderText="UC Not Updated">
                                    <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="Lb3" Font-Underline="False" runat="server" Text='<%# Eval("UC Not Updated SLC") %>'
                                                                CommandName="UCNotUpdated_SLC" CommandArgument='<%# Eval("DistId")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                <asp:BoundField DataField="UC Not Updated AMOUNT SLC" HeaderText="AMOUNt" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                             <%--   <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Closed Units"
                                    DataTextField="Closed Units SLC">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                </asp:HyperLinkField>--%>
                                <asp:TemplateField HeaderText="Closed Units">
                                    <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="Lb4" Font-Underline="False" runat="server" Text='<%# Eval("Closed Units SLC") %>'
                                                                CommandName="ClosedUnits_SLC" CommandArgument='<%# Eval("DistId")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                <asp:BoundField DataField="Closed AMOUNT SLC" HeaderText="AMOUNT" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                <asp:BoundField DataField="% NO of Units" HeaderText="% NO of Units" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                 <asp:BoundField DataField="% NO of Units amount" HeaderText="% NO of Units amount" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr style="height: 50px">
                    <td>
                        <h2 class="panel-title" style="font-weight: bold;">2). DLC : </h2>
                    </td>
                </tr>
                <tr style="height: 30px">
                    <td align="right">
                     <%--   <asp:Button ID="Button3" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Download Pdf" OnClick="Button3_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                         <asp:Button ID="Button4" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Download Excel" OnClick="Button4_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center" style="padding: 5px; margin: 5px" id="Td1" runat="server">
                        <asp:GridView ID="grdDetails1" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="100%" CssClass="floatingTable2" OnRowCommand="grdDetails1_RowCommand"
                            ShowFooter="True" OnRowCreated="grdDetails1_RowCreated">
                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                            <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                            <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                            <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                          <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex +1 %>
                                        <asp:Label ID="lblDistId" runat="server" Text='<%# Eval("DistId") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="District" HeaderText="District Name"></asp:BoundField>
                              <%--  <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="NO of Units"
                                    DataTextField="NO UNITS SLC">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                </asp:HyperLinkField>--%>
                                <asp:TemplateField HeaderText="NO of Units">
                                    <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="Lb1" Font-Underline="False" runat="server" Text='<%# Eval("NO UNITS DLC") %>'
                                                                CommandName="NOUNITS_DLC" CommandArgument='<%# Eval("DistId")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                <asp:BoundField DataField="AMOUNT RELEASED DLC" HeaderText="Amount" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                <%--<asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Working Units"
                                    DataTextField="Working Units SLC">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                </asp:HyperLinkField>--%>
                                <asp:TemplateField HeaderText="Working Units">
                                    <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="Lb2" Font-Underline="False" runat="server" Text='<%# Eval("Working Units DLC") %>'
                                                                CommandName="WorkingUnits_DLC" CommandArgument='<%# Eval("DistId")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                <asp:BoundField DataField="Working AMOUNT DLC" HeaderText="Amount" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                <%--<asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="UC Not Updated"
                                    DataTextField="UC Not Updated SLC">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                </asp:HyperLinkField>--%>
                                 <asp:TemplateField HeaderText="UC Not Updated">
                                    <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="Lb3" Font-Underline="False" runat="server" Text='<%# Eval("UC Not Updated DLC") %>'
                                                                CommandName="UCNotUpdated_DLC" CommandArgument='<%# Eval("DistId")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                <asp:BoundField DataField="UC Not Updated AMOUNT DLC" HeaderText="AMOUNt" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                             <%--   <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Closed Units"
                                    DataTextField="Closed Units SLC">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                </asp:HyperLinkField>--%>
                                <asp:TemplateField HeaderText="Closed Units">
                                    <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="Lb4" Font-Underline="False" runat="server" Text='<%# Eval("Closed Units DLC") %>'
                                                                CommandName="ClosedUnits_DLC" CommandArgument='<%# Eval("DistId")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                <asp:BoundField DataField="Closed AMOUNT DLC" HeaderText="AMOUNT" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                <asp:BoundField DataField="% NO of Units" HeaderText="% NO of Units" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                 <asp:BoundField DataField="% NO of Units amount" HeaderText="% NO of Units amount" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>

                 <tr>
                    <td style="text-align: left">
                        <asp:HyperLink CssClass="btn btn-link" ID="HyperLink2" runat="server" NavigateUrl="~/UI/TSiPASS/IncentiveReportsDashboard.aspx" Text="<< Back">
                        </asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

