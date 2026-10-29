<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmCommensedOperation.aspx.cs" Inherits="UI_TSiPASS_frmCommensedOperation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function Panel1() {

<%--            document.getElementById('<%=A1.ClientID %>').style.display = "none";--%>

            <%--document.getElementById('<%=trFilter.ClientID %>').style.display = "none";--%>

            var panel = document.getElementById("<%=GridPrint.ClientID %>");
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
        function Panel2() {
            document.getElementById('<%=Button1.ClientID %>').style.display = "none";
            document.getElementById('<%=Button2.ClientID %>').style.display = "none";
<%--            document.getElementById('<%=A1.ClientID %>').style.display = "none";--%>
<%--            document.getElementById('<%=tblselection.ClientID %>').style.display = "none";--%>
            document.getElementById('<%=GridPrint.ClientID %>').style.display = "none";
<%--            document.getElementById('<%=HyperLink1.ClientID %>').style.display = "none";--%>

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
    <%--datepicker added on 17/01/2019--%>
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

    <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading" style="text-align: center">
                            <h3 visible="false" id="Government" runat="server" class="panel-title" style="font-weight: bold;">Government of Telangana</h3>
                            <h2 id="H1" runat="server" class="panel-title" style="font-weight: bold;">
                                <asp:Label ID="lblHeading" runat="server">R6.12 : TGiPASS- Status of Implementation - Commenced Operations </asp:Label>
                                <a id="Button2" href="#" onserverclick="Button2_ServerClick"
                                    runat="server">
                                    <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                        alt="PDF" /></a>
                                <a id="pdfPrint" href="#" onclick="javascript:return Panel1();"
                                    runat="server">
                                    <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                                        style="float: right;" /></a>
                                <a id="Button1" href="#" onserverclick="Button1_ServerClick" runat="server">
                                    <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                        alt="Excel" /></a></h2>
                        </div>
                        <div class="panel-body">
                            <table align="center" cellpadding="10" cellspacing="5" style="width: 50%; font-family: 'Trebuchet MS'">
                                <tr runat="server" visible="false">
                                    <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                        <div class="input-group">
                                            <div class="input-group-addon">
                                                Year
                                            </div>
                                            <asp:DropDownList ID="ddlYear" runat="server" class="form-control txtbox" Height="33px"
                                                Width="180px" AutoPostBack="true">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <%--<asp:ListItem Value="1">Cumulative</asp:ListItem>--%>
                                                <%--<asp:ListItem Value="2">2015-16</asp:ListItem>--%>
                                                <%-- <asp:ListItem Value="3">2016-17</asp:ListItem>--%>
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnsubmit" runat="server" OnClick="btnsubmit_Click" ForeColor="White" BackColor="Green" Text="Submit" />
                                    </td>
                                </tr>
                                <tr runat="server" id="rptdate">
                                    <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                        <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">Report as on date:
                                        <asp:Label ID="lbllabel" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>
                                </tr>
                                <%--  <tr>
                                    <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                        <asp:Button ID="btnNewPdf" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Generate Pdf" OnClick="btnNewPdf_Click" />
                                    </td>
                                </tr>--%>
                            </table>
                            <table>
                                <tr id="GridPrint" runat="server">
                                    <td colspan="4" align="center" style="padding: 5px; margin: 5px" id="divPrint1" runat="server">
                                        <asp:GridView ID="grdOperation" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                            OnRowDataBound="grdOperation_RowDataBound" Width="100%" OnPageIndexChanging="grdOperation_PageIndexChanging"
                                            ShowFooter="True" OnRowCreated="grdOperation_RowCreated" OnSelectedIndexChanged="grdOperation_SelectedIndexChanged">
                                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                            <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                            <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                            <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No.">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:TemplateField>
                                                <%--   <asp:BoundField DataField="Distid" HeaderText="DistricId" Visible="false">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle CssClass="text-uppercase" />
                                                </asp:BoundField>--%>
                                                <asp:BoundField DataField="DISRICT" HeaderText="District" >
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle CssClass="text-uppercase" />
                                                </asp:BoundField>
                                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Yet to Start Construction" ControlStyle-ForeColor="blue"
                                                    DataTextField="YETTOSTART">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Initial Stage" ControlStyle-ForeColor="blue"
                                                    DataTextField="INITIALSTAGE">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Advanced Stage" ControlStyle-ForeColor="blue"
                                                    DataTextField="ADVANCESTAGE">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="blue"
                                                    FooterStyle-CssClass="text-center" DataTextField="COMMENCED_OPERATIONS" HeaderText="Total Commenced Operations">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="blue"  
                                                    FooterStyle-CssClass="text-center" DataTextField="WITHIN3MONTHS" HeaderText="Within 3 Months">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="blue" 
                                                    FooterStyle-CssClass="text-center" DataTextField="FRM3TO6SIXMONTHS" HeaderText="3 to 6 Months">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="blue" 
                                                    FooterStyle-CssClass="text-center" DataTextField="FRM6MTO1YR" HeaderText="6 Months to 1 Year">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="blue" 
                                                    FooterStyle-CssClass="text-center" DataTextField="FRM1YRTO2YRS" HeaderText="1 Year to 2 Years">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="blue" 
                                                    FooterStyle-CssClass="text-center" DataTextField="FRM2TO3YRS" HeaderText="2 Years to 3 Years">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="blue" ItemStyle-Width="150px"
                                                    FooterStyle-CssClass="text-center" DataTextField="ABOVE3YRS" HeaderText="3 Years Above">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>

                                                 <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="blue" ItemStyle-Width="150px"
                                                    FooterStyle-CssClass="text-center" DataTextField="TotalInd" HeaderText="Total No.of Industries" >
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>

                                                
                                                <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="blue" 

                                                    FooterStyle-CssClass="text-center" DataTextField="OFFLINE" HeaderText="Offline" Visible="false">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>

                                                

                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding: 5px; margin: 5px">
                                        <div id="success" runat="server" visible="false" class="alert alert-success">
                                            <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                        </div>
                                        <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
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

