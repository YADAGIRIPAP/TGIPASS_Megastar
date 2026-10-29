<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="frmAbstractanasisreportNew.aspx.cs" Inherits="UI_TSiPASS_frmAbstractanasisreportNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
   <%-- <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>--%>
    <%--    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>--%>
   
    <style type="text/css">
        .ui-datepicker
        {
            font-size: 8pt !important;
           
            padding: 0.2em 0.2em 0;
            width: 250px;
            color: Black;
            z-index:9999 !important;
        }
        select
        {
            color: Black !important;
        }
    </style>
    <style>
        .algnCenter
        {
            text-align: right;
        }
    </style>
    <div class="col-lg-12">
        <div class="panel panel-default">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <%-- <tr>
                    <td colspan="4">
                        <div class="panel-heading" align="center">
                            <h2 class="panel-title" style="font-weight: bold;">R1.6 TSIPASS APPROVAL ANALYSIS
                               
                                <a id="Button2" href="#" onserverclick="BtnPDF_Click"
                                    runat="server">
                                    <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                        alt="PDF" /></a>
                                <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                    <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                        alt="Excel" /></a> </h2>
                        </div>

                    </td>
                </tr>--%>
                <tr style="width: 40%; margin-right: 80px; height: 30px;">
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table width="100%">
                            <tr>
                                <td style="padding: 5px; margin: 5px; padding-left: 0px; width: 5px; font-weight: bold"
                                    align="left">
                                    &nbsp;&nbsp;&nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:HyperLink CssClass="btn btn-link" ID="BtnBack" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboardNew.aspx"
                                        Text="<< Back"> </asp:HyperLink>
                                </td>
                                <td style="padding: 5px; margin: 5px; padding-left: 0px; width: 180px; font-weight: bold"
                                    align="left">
                                    Select Search Critiria :
                                </td>
                                <td style="padding: 5px; margin: 5px; padding-left: 0px; width: 200px;" align="center">
                                    <asp:DropDownList ID="ddlFinancialYear" runat="server" class="form-control txtbox"
                                        Height="33px" Width="220px">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">Application Applied Date</asp:ListItem>
                                        <asp:ListItem Value="2">Application Approved Date</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="padding: 5px; margin: 5px; text-align: right; width: 105px; font-weight: bold">
                                    From Date:
                                </td>
                                <td style="width: 130px;">
                                    <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px"
                                        MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                        Width="125px"></asp:TextBox>
                                    <%-- <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                    </cc1:CalendarExtender>--%>
                                </td>
                                <td style="padding: 5px; margin: 5px; text-align: right; width: 105px; font-weight: bold">
                                    To Date:
                                </td>
                                <td style="width: 130px;">
                                    <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px"
                                        MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                        Width="125px"></asp:TextBox>
                                   <%-- <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                    </cc1:CalendarExtender>--%>
                                </td>
                                <td style="padding: 5px; margin: 5px" align="center">
                                    <asp:Button ID="Button3" runat="server" CssClass="btn btn-primary" Height="32px"
                                        Style="margin-right: 45px;" TabIndex="10" Text="Generate Report" Width="180px"
                                        OnClick="Button3_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr style="height: 30px">
                    <td>
                    </td>
                </tr>
                <tr style="height: 30px" align="right">
                    <td>
                        <asp:Button ID="btnKeyhilights" runat="server" CssClass="btn btn-primary" Height="32px"
                            TabIndex="10" Text="Key Highlights" OnClick="btnKeyhilights_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnbdf" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10"
                            Text="Generate Pdf" OnClick="btnbdf_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
                <tr style="height: 30px">
                    <td>
                        <h2 class="panel-title" style="font-weight: bold;">
                            1). TSIPASS APPROVAL ANALYSIS :
                        </h2>
                    </td>
                </tr>
                <tr style="height: 10px" align="right">
                    <td style="font-weight: bold">
                        Report Generated On :
                        <asp:Label ID="lbldate" runat="server" Text=""></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center" style="padding: 5px; margin: 5px" id="divPrint" runat="server">
                        <asp:GridView ID="grdDetails" CssClass="floatingTable1" runat="server" AutoGenerateColumns="False"
                            CellPadding="4" OnRowDataBound="grdDetails_RowDataBound" Width="100%" AllowSorting="false"
                            ShowFooter="false" OnRowCreated="grdDetails_RowCreated">
                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" VerticalAlign="Top"
                                CssClass="GridviewScrollC1HeaderWrap" />
                            <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                            <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                            <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex +1 %>
                                        <%--  <asp:Label ID="lblyear" runat="server" Text='<%# Eval("YEAR") %>' Visible="false"></asp:Label>--%>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("intDeptid") %>'></asp:Label>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("DrillDownType") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderStyle-Width="200px" DataField="DEPARTMENTNAMEShow" HeaderText="Department Name">
                                </asp:BoundField>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Right" HeaderText="Applications Applied Since 1/1/15"
                                    DataTextField="Total_approvals_applied_since">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Right" />
                                </asp:HyperLinkField>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Right" HeaderText="Applications Disposed Online Since 1/4/16"
                                    DataTextField="Numberofapplicationshandledonlinesince">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Right" />
                                </asp:HyperLinkField>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Right" HeaderText="No of Applications Rejected in Pre-Scrutiny"
                                    DataTextField="No_approvals_rejected_PSC">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Right" />
                                </asp:HyperLinkField>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Right" HeaderText="No of Applications In-Progress"
                                    DataTextField="No_approvals_Progress">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Right" />
                                </asp:HyperLinkField>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Right" HeaderText="Applications Disposed off Within due Date"
                                    DataTextField="Applicationsdisposedoffwithinduedate">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Right" />
                                </asp:HyperLinkField>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Right" HeaderText="Applications Disposed off Beyond due Date"
                                    DataTextField="ApplicationsdisposedoffBeyondduedate">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Right" />
                                </asp:HyperLinkField>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Right" HeaderText="Applications Disposed on the Same Day"
                                    DataTextField="Noofapplicationsdisposedonthesameday">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Right" />
                                </asp:HyperLinkField>
                                <%--                                 <asp:BoundField DataField="Total_approvals_applied_since" HeaderStyle-Width="150px" HeaderText="Total Approvals Applied since 1/1/15"></asp:BoundField>
                                <asp:BoundField DataField="Numberofapplicationshandledonlinesince" HeaderStyle-Width="150px" HeaderText="Number of Approvals Handled Online Since 1/4/16"></asp:BoundField>
                                <asp:BoundField DataField="No_approvals_rejected_PSC" HeaderText="No of Applications Rejected in Pre-Scrutiny"></asp:BoundField>
                                <asp:BoundField DataField="No_approvals_Progress" HeaderText="No of Applications In-Progress"></asp:BoundField>
                                <asp:BoundField DataField="Applicationsdisposedoffwithinduedate" HeaderStyle-Width="200px" HeaderText="Applications Disposed off Within due Date"></asp:BoundField>
                                <asp:BoundField DataField="ApplicationsdisposedoffBeyondduedate" HeaderStyle-Width="200px" HeaderText="Applications Disposed off Beyond due Date"></asp:BoundField>
                                <asp:BoundField DataField="Noofapplicationsdisposedonthesameday" HeaderText="No of Applications Disposed on the Same Day"></asp:BoundField>--%>
                                <%--<asp:BoundField DataField="per_of_Applications_disposedoffwithinduedate" HeaderText="% of Applications Disposed off Within due Date"></asp:BoundField>--%>
                                <%--<asp:BoundField DataField="per_of_Applications_disposedoffbeyonduedate" HeaderText="% of Applications Disposed off Beyond due Date"></asp:BoundField>--%>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr style="height: 30px">
                    <td>
                    </td>
                </tr>
            </table>
        </div>
    </div>
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
        });

        $(function () {

            $('#MstLftMenu').remove();

        });
    </script>

     <script type="text/javascript">
         function pageLoad() {
             var date = new Date();
             var yrRange = "2015:" + (date.getFullYear() + 1);

             var currentMonth = date.getMonth();
             var currentDate = date.getDate();
             var currentYear = date.getFullYear();

             $("input[id$='txtFromDate']").datepicker(
               {
                   dateFormat: "dd-mm-yy",
                   changeMonth: true,
                   changeYear: true,
                   yearRange: yrRange

                   //  maxDate: new Date(currentYear, currentMonth, currentDate)
               }); // Will run at every postback/AsyncPostback
             $("input[id$='txtTodate']").datepicker(
               {
                   dateFormat: "dd-mm-yy",
                   changeMonth: true,
                   changeYear: true,
                   yearRange: yrRange

                   //  maxDate: new Date(currentYear, currentMonth, currentDate)
               }); // Will run at every postback/AsyncPostback
         }
         $(function () {
             var date = new Date();
             var yrRange = "2015:" + (date.getFullYear() + 1);
             var currentMonth = date.getMonth();
             var currentDate = date.getDate();
             var currentYear = date.getFullYear();
             $("input[id$='txtFromDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange
                });
             $("input[id$='txtTodate']").datepicker(
               {
                   dateFormat: "dd-mm-yy",
                   changeMonth: true,
                   changeYear: true,
                   yearRange: yrRange

                   //  maxDate: new Date(currentYear, currentMonth, currentDate)
               }); // Will run at every postback/AsyncPostback
         });
    </script>



</asp:Content>
