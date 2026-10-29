<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="comRepDrill_dist.aspx.cs" Inherits="UI_TSIPASS_comRepDrill_dist" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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



        $(function () {

            $('#MstLftMenu').remove();

        });

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
           
    </script>--%>
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
    <%--<script language="javascript" type="text/javascript">
        function Panel1() {

            document.getElementById('<%=Button2.ClientID %>').style.display = "none";
            //
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
    </script>--%>
    <script type="text/javascript">
        function doPrint() {
            var prtContent = document.getElementById('<%= grdDetails.ClientID %>');
            prtContent.border = 2; //set no border here
            var WinPrint = window.open('', '', 'left=100,top=100,width=1000,height=1000,toolbar=0,scrollbars=1,status=0,resizable=1');
            WinPrint.document.write(prtContent.outerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
        }
    </script>
    <div class="col-lg-12">
        <div class="panel panel-default">
            <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr runat="server" id="trtype" visible="true">
                    <td>
                        <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/comReportDrillNew.aspx"
                            Text="<< Back">
                        </asp:HyperLink>
                    </td>
                    <td style="padding: 5px; margin: 5px" align="center">
                        <asp:DropDownList ID="ddltype" runat="server" class="form-control txtbox" Height="33px"
                            Width="180px" OnSelectedIndexChanged="ddltype_SelectedIndexChanged" AutoPostBack="true">
                            <%-- <asp:ListItem>--Select--</asp:ListItem>--%>
                            <asp:ListItem Value="District" Selected="True">District</asp:ListItem>
                            <asp:ListItem Value="Department">Department</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px;" valign="top"
                        align="center">
                        <div class="panel panel-default">
                            <div class="panel-heading" style="text-align: center">
                                <h3 class="panel-title" style="font-weight: bold;">
                                    COI Dashboard&nbsp;
                                </h3>
                                <a id="A1" href="#" visible="true" runat="server" onclick="doPrint()">
                                    <img src="../../images/png-for-print-1.png" width="50px;" height="20px;" style="float: right;"
                                        alt="PDF" /></a>
                                <%-- <a id="btnPrnt" href="#" onclick="doPrint()" runat="server">
                                             
                                              <img src="../../images/png-for-print-1.png" width="50px;" height="20px;" style="float: right;"
                                                  alt="PDF" /></a>--%>
                                <a id="A3" href="#" onserverclick="BtnPDF_Click" runat="server">
                                    <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                        alt="PDF" /></a>
                                <%--<a id="Button2" href="#" onclick="javascript:return Panel1();" runat="server">
                                        <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="PDF" /></a>--%>
                                <%--<a id="Button1" href="#" onserverclick="BtnSave2_Click" runat="server">
                                        <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a>--%>
                                <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                    <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                        alt="Excel" /></a>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 50%; font-family: 'Trebuchet MS'">
                                    <tr>
                                        <td style="text-align: center">
                                            <b>
                                                <asp:Label ID="lblheadingtext" runat="server"></asp:Label></b> &nbsp;
                                        </td>
                                        <td class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px" colspan="5">
                                            <b>
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label></b>
                                        </td>
                                    </tr>
                                    <tr id="div_Print" runat="server">
                                        <td align="center" colspan="6" style="padding: 5px; margin: 5px">
                                            <asp:GridView ID="grdDetails" CssClass="floatingTable" AutoGenerateColumns="false"
                                                runat="server" CellPadding="4" Width="100%" ShowFooter="True" OnRowDataBound="grdDetails_RowDataBound">
                                                <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:BoundField DataField="Sno" HeaderText="Sno">
                                                        <ItemStyle />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="DistrictName" HeaderText="District">
                                                        <ItemStyle />
                                                    </asp:BoundField>
                                                    <%--<asp:BoundField DataField="PENDINGCOUNT" HeaderText="Types">
                                                                            <ItemStyle Width="150px" />
                                                                        </asp:BoundField>--%>
                                                    <asp:HyperLinkField DataTextField="pendencyCount" HeaderText="Count">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr id="trdept" runat="server" visible="false">
                                        <td align="center" colspan="6" style="padding: 5px; margin: 5px">
                                            <asp:GridView ID="grddept" CssClass="floatingTable" AutoGenerateColumns="false" runat="server"
                                                CellPadding="4" Width="100%" ShowFooter="True" OnRowDataBound="grddept_RowDataBound">
                                                <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex +1 %>
                                                            <%-- <asp:Label ID="lblyear" runat="server" Text='<%# Eval("YEAR") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblmonth" runat="server" Text='<%# Eval("MonthCode") %>' Visible="false"></asp:Label>--%>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ParticularsID" HeaderText="District" Visible="false">
                                                        <ItemStyle />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Particulars" HeaderText="Department">
                                                        <ItemStyle />
                                                    </asp:BoundField>
                                                    <asp:HyperLinkField DataTextField="TOTAL" HeaderText="TOTAL">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Adilabad-1" HeaderText="Adilabad">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Asifabad-11" HeaderText="Asifabad">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Bhadradri Kothagudem-17" HeaderText="Bhadradri Kothagudem">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Bhupalpally-12" HeaderText="Bhupalpally">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Gadwal-13" HeaderText="Gadwal">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Hyderabad-5" HeaderText="Hyderabad">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Jagtial-14" HeaderText="Jagtial">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Jangaon-15" HeaderText="Jangaon">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Kamareddy-16" HeaderText="Kamareddy">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Karimnagar-3" HeaderText="Karimnagar">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Khammam-10" HeaderText="Khammam">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Mahabubabad-18" HeaderText="Mahabubabad">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Mahbubnagar-7" HeaderText="Mahbubnagar">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Mancherial-19" HeaderText="Mancherial">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Medak-4" HeaderText="Medak">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Medchal-20" HeaderText="Medchal">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Mulugu-32" HeaderText="Mulugu">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Nagarkurnool-21" HeaderText="Nagarkurnool">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Nalgonda-8" HeaderText="Nalgonda">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Narayanpet-33" HeaderText="Narayanpet">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Nirmal-22" HeaderText="Nirmal">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Nizamabad-2" HeaderText="Nizamabad">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Peddapalli-23" HeaderText="Peddapalli">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Rangareddy-6" HeaderText="Rangareddy">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Sangareddy-24" HeaderText="Sangareddy">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Siddipet-25" HeaderText="Siddipet">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Sircilla-26" HeaderText="Sircilla">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Suryapet-27" HeaderText="Suryapet">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Vikarabad-28" HeaderText="Vikarabad">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Wanaparthy-29" HeaderText="Wanaparthy">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Warangal - Rural-9" HeaderText="Warangal - Rural">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Warangal - Urban-30" HeaderText="Warangal - Urban">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Yadadri-31" HeaderText="Yadadri">
                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                    </asp:HyperLinkField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6" align="center" style="padding: 5px; margin: 5px">
                                            <div id="success" runat="server" class="alert alert-success" visible="false">
                                                <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">
                                                    ×</a> <strong>Success!</strong><asp:Label ID="Label2" runat="server"></asp:Label>
                                            </div>
                                            <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                                <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
