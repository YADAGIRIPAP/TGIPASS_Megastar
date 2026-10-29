<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmDistrictReportEnterpriseType.aspx.cs" Inherits="UI_TSiPASS_frmDistrictReportEnterpriseType" %>

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
        function Panel1() {
            document.getElementById('<%=A1.ClientID %>').style.display = "none";
            document.getElementById('<%=A2.ClientID %>').style.display = "none";
            var panel = document.getElementById("<%=divPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>newTable</title>');

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
        .ui-datepicker {
            font-size: 8pt !important;
            padding: 0.2em 0.2em 0;
            width: 250px;
            color: Black;
            z-index: 9999 !important;
        }

        select {
            color: Black !important;
        }
    </style>
    <style>
        .algnCenter {
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
    <div class="col-lg-12">
        <div class="panel panel-default">
            <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px;" valign="top"
                        align="center">
                        <div class="panel panel-default">
                            <div class="panel-heading" style="text-align: center">
                                <h3 class="panel-title" style="font-weight: bold;">
                                    <asp:Label ID="lblHeading" runat="server">District Wise Industry Category Report</asp:Label>&nbsp;
                                    <a id="A1" href="#" onserverclick="BtnPDF_Click" runat="server">
                                        <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="PDF" /></a> <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                                <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;" /></a>
                                                <a id="pdfPrint" href="#" onclick="javascript:return Panel1();"
                                                    runat="server">
                                                    <img src="../../Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                                                        style="float: right;" /></a></h3>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 50%; font-family: 'Trebuchet MS'">
                                    <tr>
                                        <td style="text-align: left">
                                            <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboardNew.aspx"
                                                Text="<< Back">
                                            </asp:HyperLink>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6" align="left">
                                            <table width="100%">
                                                <tr runat="server" id="trBetweenDates" visible="true">
                                                    <td style="padding: 5px; margin: 5px">From Date:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                            Width="125px"></asp:TextBox>
                                                        <%--<cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                </cc1:CalendarExtender>--%>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">To Date:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                            Width="125px"></asp:TextBox>
                                                        <%-- <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                                </cc1:CalendarExtender>--%>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label352" runat="server" data-balloon-length="large" data-balloon="Please Select Proposed Location"
                                                            data-balloon-pos="down" CssClass="LBLBLACK">District : </asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:DropDownList ID="ddlProp_intDistrictid" runat="server" class="form-control txtbox"
                                                            Height="33px" Width="180px" AutoPostBack="false">
                                                            <asp:ListItem Value="%">--ALL--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="trBetweenDates1" visible="false">
                                                    <td style="padding: 5px; margin: 5px">Input Type</td>
                                                    <td>
                                                        <asp:RadioButtonList ID="rbtnlstInputType" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="F">Financial Years</asp:ListItem>
                                                            <asp:ListItem Value="N" Selected="True">Between Dates</asp:ListItem>
                                                        </asp:RadioButtonList></td>
                                                    <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                    <td>Financial Year</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:DropDownList ID="ddlFinancialYear" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                    <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                </tr>
                                                <tr align="center">
                                                    <td style="padding: 5px; margin: 5px" colspan="4" align="center">
                                                        <%--<asp:Button ID="btnGet" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Generate Report" Width="180px" OnClick="btnGet_Click" />--%>
                                                        <asp:Button ID="Button3" runat="server" CssClass="btn btn-default" TabIndex="10"
                                                            Text="Submit" OnClick="BtnSave1_Click" />
                                                    </td>
                                                     <td  style="padding: 5px; text-align:center; margin: 5px" colspan="4">
                                            <b>
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label></b>
                                        </td>
                                                </tr>
                                            </table>
                                        </td>
                </tr>

                <tr id="div_Print" runat="server">
                    <td align="center" colspan="6" style="padding: 5px; margin: 5px">
                        <asp:GridView ID="grdDetails"  runat="server" AutoGenerateColumns="False"
                            CellPadding="4" OnRowDataBound="grdDetails_RowDataBound" Width="100%" OnPageIndexChanging="grdDetails_PageIndexChanging"
                            ShowFooter="True">
                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                            <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                            <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                            <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex +1 %>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="20px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="DISTRICTNAME" HeaderText="District">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle CssClass="text-uppercase" />
                                </asp:BoundField>
                                <%--<asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Visible="false" DataTextField="DISTRICTID" HeaderText="DISTRICTID">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                </asp:HyperLinkField>--%>
                                 <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="MANUFACTURING TYPE"
                                    DataTextField="MANUFACTURINGTYPE">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                </asp:HyperLinkField>                                
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" DataTextField="SERVICETYPE" HeaderText="SERVICE TYPE">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                </asp:HyperLinkField>
           
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" DataTextField="TOTALUNITS" HeaderText="TOTAL UNITS">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                </asp:HyperLinkField>    
                                
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" DataTextField="TotalEmployeement" HeaderText="TOTAL Employeement">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                </asp:HyperLinkField>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" DataTextField="InvestmentCr" HeaderText="Investment in Cr">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                </asp:HyperLinkField>

                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" align="center" style="padding: 5px; margin: 5px">
                        <div id="success" runat="server" class="alert alert-success" visible="false">
                            <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:Label ID="Label2" runat="server"></asp:Label>
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
