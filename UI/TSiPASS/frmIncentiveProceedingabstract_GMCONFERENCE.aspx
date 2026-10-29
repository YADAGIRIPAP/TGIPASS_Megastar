<%@ Page Language="C#"  MasterPageFile="~/UI/TSIPASS/CCMaster.master"  AutoEventWireup="true" CodeFile="frmIncentiveProceedingabstract_GMCONFERENCE.aspx.cs" Inherits="UI_TSiPASS_frmIncentiveProceedingabstract_GMCONFERENCE" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <script language="javascript" type="text/javascript">
         function Panel1() {


            <%--document.getElementById('<%=trFilter.ClientID %>').style.display = "none";--%>

            var panel = document.getElementById("<%=divPrint.ClientID %>");
             var printWindow = window.open('', '', 'height=400,width=800');
             printWindow.document.write('<html><head><title></title>');

             printWindow.document.write('</head><body >');
             printWindow.document.write(panel.innerHTML);
             printWindow.document.write
                 ('</body></html>');
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

         });
     </script>
     <script language="javascript" type="text/javascript">
         function Panel2() {


            <%--document.getElementById('<%=trFilter.ClientID %>').style.display = "none";--%>

            var panel = document.getElementById("<%=Td1.ClientID %>");
             var printWindow = window.open('', '', 'height=400,width=800');
             printWindow.document.write('<html><head><title></title>');

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

         });
     </script>
    <script language="javascript" type="text/javascript">
        function Panel3() {


            <%--document.getElementById('<%=trFilter.ClientID %>').style.display = "none";--%>

            var panel = document.getElementById("<%=Td2.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title>');

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

        });
    </script>
    <style>
        .algnCenter
        {
            text-align: right;
        }
        
        /*body {
            font: normal 10px Verdana, Arial, sans-serif;
        }*/
    </style>
    <%--Added datepicker on 18/01/2019--%>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <style type="text/css">
        .ui-datepicker
        {
            font-size: 8pt !important;
            padding: 0.2em 0.2em 0;
            width: 250px;
            color: Black;
            z-index: 9999 !important;
        }
        select
        {
            color: Black !important;
        }
    </style>
    <style>
        .algnCenter
        {
            text-align: center;
        }
    </style>
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
    <div class="col-lg-12" >
        <div class="panel panel-default">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr runat="server" visible="false">
                    <td colspan="4">
                        <div class="panel-heading" align="center">
                            <h2 class="panel-title" style="font-weight: bold;">
                                R1.4 Post Approval - Stage Wise Abstract
                                <%-- <a id="Button2" href="#" onclick="javascript:return Panel1();"
                                runat="server">--%>
                                <a id="Button2" href="#" onserverclick="BtnPDF_Click" runat="server" visible="false">
                                    <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                        alt="PDF" /></a> <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server"
                                            visible="false">
                                            <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                                alt="Excel" />
                                                </a>
                                                <a id="pdfPrint" href="#" onclick="javascript:return Panel1();"
                                                    runat="server">
                                                    <img src="../../Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                                                        style="float: right;" /></a>
                            </h2>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left">
                        <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" Visible="false" runat="server" NavigateUrl="~/UI/TSiPASS/IncentiveReportsDashboard.aspx"
                            Text="<< Back">
                        </asp:HyperLink>
                    </td>
                </tr>
                <div class="panel-body">
                    <tr align="center">
                        <td colspan="3">
                            <table style="width: 100%">
                                <tr>
                                    <td style="padding: 5px; margin: 5px">
                                        From Date:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px" Width="125px"
                                            MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" ></asp:TextBox>
                                        <%--<cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                    </cc1:CalendarExtender>--%>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">
                                        To Date:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px"
                                            MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                            Width="125px"></asp:TextBox>
                                        <%--  <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                    </cc1:CalendarExtender>--%>
                                    </td>
                                    <td>
                                        Category :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlcategory" class="form-control txtbox" runat="server" Width="125px">
                                            <asp:ListItem Text="All" Value="ALL"></asp:ListItem>
                                            <asp:ListItem Text="General" Value="General"></asp:ListItem>
                                            <asp:ListItem Text="ST" Value="ST"></asp:ListItem>
                                            <asp:ListItem Text="SC" Value="SC"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="padding: 5px; margin: 5px" colspan="2" align="left">
                                        <asp:Button ID="btnGet" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10"
                                            Text="Generate Report" Width="180px" OnClick="btnGet_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height: 30px" runat="server" visible="false">
                        <td align="right">
                        
                            <asp:Button ID="btnbdf" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10"
                                Text="Download Pdf" OnClick="btnbdf_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Height="32px"
                                TabIndex="10" Text="Download Excel" OnClick="BtnSave2_Click" />
                        </td>
                    </tr>
                    <tr style="height: 50px"   runat="server" visible="false">
                        <td>
                            <h2 class="panel-title" style="font-weight: bold;">
                                1). No of Units for which release proceedings are issued :
                            </h2>
                        </td>
                        <td style="padding: 5px; text-align: right; margin: 5px" colspan="5">
                                            <b>
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label></b>
                                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" style="padding: 5px; margin: 5px" id="divPrint" runat="server">
                            <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                OnRowDataBound="grdDetails_RowDataBound" ShowFooter="True" OnRowCreated="grdDetails_RowCreated"
                                >
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
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="NO of Units" DataTextField="NO UNITS DLC">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:BoundField DataField="AMOUNT RELEASED DLC" HeaderText="Amount (in Lakhs)" ItemStyle-HorizontalAlign="Right">
                                    </asp:BoundField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="NO of Units" DataTextField="NO UNITS SLC">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:BoundField DataField="AMOUNT RELEASED SLC" HeaderText="Amount (in Lakhs)" ItemStyle-HorizontalAlign="Right">
                                    </asp:BoundField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Total Units" DataTextField="TOTAL UNITS">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:BoundField DataField="TOTAL AMOUNT" HeaderText="Amount (in Lakhs)" ItemStyle-HorizontalAlign="Right">
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr style="height: 50px"  runat="server" visible="false">
                        <td>
                            <h2 class="panel-title" style="font-weight: bold;">
                                2). UC Updated :
                            </h2>
                        </td>
                        <td  style="padding: 5px; text-align: right; margin: 5px" colspan="5">
                                            <b>
                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label></b>
                                        </td>
                    </tr>
                    <tr style="height: 30px" runat="server" visible="false">
                        <td align="right">
                        <a id="A1" href="#" onclick="javascript:return Panel2();"
                                                    runat="server">
                                                    <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                                                        style="float: right;" /></a>
                            <asp:Button ID="Button3" runat="server" CssClass="btn btn-primary" Height="32px"
                                TabIndex="10" Text="Download Pdf" OnClick="Button3_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Button4" runat="server" CssClass="btn btn-primary" Height="32px"
                                TabIndex="10" Text="Download Excel" OnClick="Button4_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" style="padding: 5px; margin: 5px" id="Td1" runat="server">
                            <asp:GridView ID="grdDetails1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                OnRowDataBound="grdDetails1_RowDataBound" CssClass="floatingTable2"
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
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Right" HeaderText="Working Units"
                                        DataTextField="Working Units DLC">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:BoundField DataField="Working AMOUNT DLC" HeaderText="Amount (in Lakhs)" ItemStyle-HorizontalAlign="Right">
                                    </asp:BoundField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Right" HeaderText="Working Units"
                                        DataTextField="Working Units SLC">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:BoundField DataField="Working AMOUNT SLC" HeaderText="Amount (in Lakhs)" ItemStyle-HorizontalAlign="Right">
                                    </asp:BoundField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Right" HeaderText="Total Working Units"
                                        DataTextField="TOTAL Working Units">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:BoundField DataField="Working TOTAL AMOUNT" HeaderText="Total Amount (in Lakhs)"
                                        ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Closed Units"
                                        DataTextField="Closed Units DLC">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:BoundField DataField="Closed AMOUNT DLC" HeaderText="Amount (in Lakhs)" ItemStyle-HorizontalAlign="Right">
                                    </asp:BoundField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Closed Units"
                                        DataTextField="Closed Units SLC">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:BoundField DataField="Closed AMOUNT SLC" HeaderText="Amount (in Lakhs)" ItemStyle-HorizontalAlign="Right">
                                    </asp:BoundField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Closed Units"
                                        DataTextField="TOTAL Closed Units">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:BoundField DataField="Closed TOTAL AMOUNT" HeaderText="Amount (in Lakhs)" ItemStyle-HorizontalAlign="Right">
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr style="height: 50px">
                        <td>
                            <h2 class="panel-title" style="font-weight: bold;">
                                1). UC Not Updated :
                            </h2>
                        </td>
                        <td style="padding: 5px; text-align: right; margin: 5px" colspan="4">
                                            <b>
                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label></b>
                                        </td>
                    </tr>
                    <tr style="height: 30px">
                        <td align="right">
                        <a id="A3" href="#" onclick="javascript:return Panel3();"
                                                    runat="server">
                                                    <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                                                        style="float: right;" /></a>
                            <asp:Button ID="Button5" runat="server" CssClass="btn btn-primary" Height="32px"
                                TabIndex="10" Text="Download Pdf" OnClick="Button5_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Button6" runat="server" CssClass="btn btn-primary" Height="32px"
                                TabIndex="10" Text="Download Excel" OnClick="Button6_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" style="padding: 5px; margin: 5px" id="Td2" runat="server">
                            <asp:GridView ID="grdDetails2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                OnRowDataBound="grdDetails2_RowDataBound" CssClass="floatingTable1"
                                ShowFooter="True" OnRowCreated="grdDetails2_RowCreated">
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
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="NO of Units" DataTextField="UC Not Updated DLC">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:BoundField DataField="UC Not Updated AMOUNT DLC" HeaderText="Amount (in Lakhs)"
                                        ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="NO of Units" DataTextField="UC Not Updated SLC">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:BoundField DataField="UC Not Updated AMOUNT SLC" HeaderText="Amount (in Lakhs)"
                                        ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                    <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Total Units" DataTextField="TOTAL UC Not Updated Units">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:BoundField DataField="UC Not Updated TOTAL AMOUNT" HeaderText="Amount (in Lakhs)"
                                        ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:HyperLink CssClass="btn btn-link" ID="HyperLink2" runat="server" NavigateUrl="~/UI/TSiPASS/IncentiveReportsDashboard_GMCONFERENCE.aspx"
                                Text="<< Back">
                            </asp:HyperLink>
                        </td>
                    </tr>
                </div>
            </table>
        </div>
    </div>
</asp:Content>


