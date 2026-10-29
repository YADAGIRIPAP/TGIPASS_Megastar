<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="DepartmentWiseCfeAnalasisNew.aspx.cs" Inherits="UI_TSiPASS_DepartmentWiseCfeAnalasisNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript">
        function Panel1() {



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
    </script>

    <style>
        .algnCenter {
            text-align: right;
        }
    </style>
    <div class="col-lg-12">
        <div class="panel panel-default">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">

                <tr align="center">
                    <td colspan="3">
                        <table width="100%">
                            <tr style="width: 40%; margin-right: 80px; height: 30px;">
                                <td></td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; padding-left: 0px; width: 5px; font-weight: bold" align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                <td style="padding: 5px; margin: 5px; padding-left: 0px; width: 180px; font-weight: bold" align="left">Select Search Critiria :</td>
                                <td style="padding: 5px; margin: 5px; padding-left: 0px; width: 200px;" align="center">

                                    <asp:DropDownList ID="ddlFinancialYear" runat="server" class="form-control txtbox" Height="33px" Width="220px">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                       <asp:ListItem Value="1">Application Applied Date</asp:ListItem>
                                        <asp:ListItem Value="2">Application Approved Date</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="padding: 5px; margin: 5px; text-align: right; width: 105px; font-weight: bold">From Date:   
                                                
                                </td>
                                <td style="width: 130px;">
                                    <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                    </cc1:CalendarExtender>
                                </td>
                                <td style="padding: 5px; margin: 5px; text-align: right; width: 105px; font-weight: bold">To Date:  
                                            
                                </td>
                                <td style="width: 130px;">
                                    <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                    </cc1:CalendarExtender>
                                </td>
                                <td style="padding: 5px; margin: 5px" align="center">
                                    <asp:Button ID="Button3" runat="server" CssClass="btn btn-primary" Height="32px" Style="margin-right: 45px;" TabIndex="10" Text="Generate Report" Width="180px" OnClick="Button3_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>


                </tr>
                <tr style="height: 30px">
                    <td style="padding: 5px; margin: 5px" align="left">
                        <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboardNew.aspx" Text="<< Back"> </asp:HyperLink>
                    </td>
                </tr>

                <tr style="height: 30px" align="right">
                    <td>
                        <asp:Button ID="btnbdf" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Width="180px" Text="Generate Detailed Pdf" OnClick="btnbdf_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
                <tr style="height: 50px">
                    <td>
                        <h2 class="panel-title" style="font-weight: bold;">1). Applications Disposed Within Due Date - Department wise : </h2>
                    </td>
                </tr>
                <tr style="height: 10px">
                    <td></td>
                </tr>
                <tr id="divPrint" runat="server">
                    <td colspan="2" align="center" style="padding: 5px; margin: 5px" id="Td1" runat="server">
                        <asp:GridView ID="GridView1" CssClass="floatingTable2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            Width="100%"
                            ShowFooter="True">
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
                                <asp:BoundField DataField="DEPARTMENTNAME" ItemStyle-Width="350px" HeaderText="Department Name"></asp:BoundField>
                                <asp:BoundField DataField="NOOFAPPLICATIONS" ItemStyle-HorizontalAlign="Right" HeaderText="Total number of applications handled"></asp:BoundField>
                                <asp:BoundField DataField="Applications_disposed_within_Duedate" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Right" HeaderText="Applications disposed within due date"></asp:BoundField>
                                <asp:BoundField DataField="Average_Number_of_days_taken_for_approval" ItemStyle-HorizontalAlign="Right" HeaderText="Average number of days taken for approval v/s SLA"></asp:BoundField>
                                <asp:BoundField DataField="No_of_apps_dsd_on_the_same_day_excl_timetaken_PSC" ItemStyle-HorizontalAlign="Right" HeaderText="No of applications disposed on the same day (excluding time taken for Pre-Scrutiny)"></asp:BoundField>
                                <asp:BoundField DataField="No_of_apps_dsd_on_the_same_day_incl_timetaken_PSC" ItemStyle-HorizontalAlign="Right" HeaderText="No of applications disposed on the same day (including time taken for Pre-Scrutiny)"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr style="height: 30px">
                    <td></td>
                </tr>
                <tr style="height: 30px">
                    <td>
                        <h2 class="panel-title" style="font-weight: bold;">2). Applications Disposed Beyond Due Date - Department wise :</h2>
                    </td>
                </tr>
                <tr style="height: 10px">
                    <td></td>
                </tr>
                <tr>
                    <td colspan="2" align="center" style="padding: 5px; margin: 5px" id="Td2" runat="server">
                        <asp:GridView ID="GridView2" CssClass="floatingTable1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            Width="100%"
                            ShowFooter="True">
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
                                <asp:BoundField DataField="DEPARTMENTNAME" ItemStyle-Width="350px" HeaderText="Department Name"></asp:BoundField>
                                <asp:BoundField DataField="NOOFAPPLICATIONS" ItemStyle-HorizontalAlign="Right" HeaderText="Total number of applications handled"></asp:BoundField>
                                <asp:BoundField DataField="Applications_disposed_within_Duedate" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Right" HeaderText="Applications disposed beyond due date"></asp:BoundField>
                                <asp:BoundField DataField="Noofapplicationsdisposedwithin_1_week_fromduedate" ItemStyle-HorizontalAlign="Right" HeaderText="No of applications disposed within 1 week from due date"></asp:BoundField>
                                <asp:BoundField DataField="Noofapplicationsdisposedwithin_2_week_fromduedate" ItemStyle-HorizontalAlign="Right" HeaderText="No of applications disposed within 2 week from due date"></asp:BoundField>
                                <asp:BoundField DataField="Noofapplicationsdisposedwithin_3_week_fromduedate" ItemStyle-HorizontalAlign="Right" HeaderText="No of applications disposed after 2 weeks from due date"></asp:BoundField>
                                <asp:BoundField DataField="Average_Number_of_days_taken_for_approval" ItemStyle-HorizontalAlign="Right" HeaderText="Average number of days taken for approval v/s SLA"></asp:BoundField>
                                <asp:BoundField DataField="Maximum_number_of_days_taken_inanapplication" ItemStyle-HorizontalAlign="Right" HeaderText="Maximum number of days taken in an application"></asp:BoundField>
                                <asp:BoundField DataField="Averagedelaybeyondduedate" ItemStyle-HorizontalAlign="Right" HeaderText="Average delay beyond due date (no. of days)"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <script type="text/javascript">

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
</asp:Content>

