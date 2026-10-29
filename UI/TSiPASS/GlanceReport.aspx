<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/EmptyMaster.master" AutoEventWireup="true" CodeFile="GlanceReport.aspx.cs" Inherits="UI_TSiPASS_GlanceReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
        function Panel1() {

            document.getElementById('<%=Button2.ClientID %>').style.display = "none";
            document.getElementById('<%=tblselection.ClientID %>').style.display = "none";

            var panel = document.getElementById("<%=divPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><h3 style="width: 100%;text-align: center;">Government of Telangana</h3>');

            printWindow.document.write('</head><body style="width: 100%;text-align: center;">');
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
        .width {
            width: 85%;
        }
    </style>
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
    <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <div class="panel panel-default" style="font-family: Helvetica Neue, Helvetica, Arial, sans-serif; font-size: 16px; line-height: 1.42857143;">
                    <div class="panel-heading" style="text-align: center">
                        <h3 visible="false" id="Government" runat="server" class="panel-title" style="font-weight: bold;">Government of Telangana</h3>
                        <h2 class="panel-title" style="font-weight: bold;">
                            <asp:Label ID="lblHeading" runat="server">TSiPASS AT A GLANCE REPORT</asp:Label>
                            <a id="Button2" href="#" onclick="javascript:return Panel1();"
                                runat="server">
                                <%--<img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" />--%></a>
                            <%--<a id="Button1" href="#" onserverclick="BtnSave2_Click" runat="server">
                                        <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a>--%>
                            <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="Excel" /></a>
                        </h2>
                    </div>
                    <div class="panel-body">
                        <table align="center" class="width" cellspacing="5" style="font-family: 'Trebuchet MS';">
                            <tr>
                                <td>
                                    <table runat="server" id="tblselection" cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                <%--<asp:HyperLink CssClass="btn btn-link" ID="BtnBack" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboardNew.aspx"
                                                    Text="<< Back"> </asp:HyperLink>--%>
                                            </td>
                                            <td visible="false" class="col-xs-3" style="padding: 5px; margin: 5px">
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
                                            <td visible="false" style="padding: 5px; margin: 5px" align="right">
                                                <asp:Button ID="Button3" runat="server" CssClass="btn btn-default" TabIndex="10"
                                                    Text="Submit" OnClick="BtnSave1_Click" />
                                            </td>
                                        </tr>

                                    </table>
                                </td>
                                <td class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px"></td>
                            </tr>
                            <%--<tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    &nbsp;
                                </td>
                            </tr>--%>
                            <tr>
                                <td colspan="2">
                                    <table width="100%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" align="left">Input Type</td>
                                            <td style="padding: 5px; margin: 5px" colspan="3" align="left">
                                                <asp:RadioButtonList ID="rbtnlstInputType" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rbtnlstInputType_SelectedIndexChanged">
                                                    <asp:ListItem Value="F">Financial Years</asp:ListItem>
                                                    <asp:ListItem Value="N" Selected="True">Between Dates</asp:ListItem>
                                                </asp:RadioButtonList></td>

                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" align="left"></td>
                                            <td style="padding: 5px; margin: 5px" align="left" colspan="3"></td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr runat="server" id="trFinYears" visible="false">
                                            <td style="padding: 5px; margin: 5px" align="left">Financial Year</td>
                                            <td style="padding: 5px; margin: 5px" align="left" colspan="3">
                                                <asp:DropDownList ID="ddlFinancialYear" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList></td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr runat="server" id="trBetweenDates" visible="true">
                                            <td style="padding: 5px; margin: 5px">From Date:   
                                                
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                 <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                </cc1:CalendarExtender>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">To Date:  
                                            
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                 <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                                </cc1:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" align="left"></td>
                                            <td style="padding: 5px; margin: 5px" align="left" colspan="3"></td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr align="center">
                                            <td style="padding: 5px; margin: 5px" colspan="4" align="center">
                                                <asp:Button ID="btnGet" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Generate Report" Width="180px" OnClick="btnGet_Click" />

                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
        </tr>

        <tr runat="server" id="div_Print">
            <td colspan="2" style="padding: 5px;" valign="top">
                <table style="width: 100%;">
                    <tr>
                        <td colspan="2" style="padding: 10px; margin: 5px; text-align: center; font-weight: bold;">
                            <asp:Label ID="Label12" Font-Size="Large" runat="server">AT A GLANCE REPORT</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="padding: 10px; margin: 5px; text-align: right; font-weight: bold;">
                            <asp:Button ID="btnbdf" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Generate Pdf" OnClick="btnbdf_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="padding: 10px; margin: 5px; text-align: center; font-weight: bold;">
                            <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2" style="padding: 5px;" valign="top">
                            <%-- <table border="solid" style="width: 100%; border: 1px solid #929090;">
                                <tr style="background-color: #286090;">
                                    <td colspan="2" style="padding: 10px; margin: 5px; text-align: center; color: White; font-weight: bold;">
                                        <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK">AT A GLANCE REPORT</asp:Label>
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: center; color: White; font-weight: bold; width: 120px">
                                        <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: center; color: White; font-weight: bold; width: 120px">
                                        <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK">Cumulative(Since Jan-2015)</asp:Label>
                                    </td>

                                </tr>
                                <tr>
                                    <td style="padding: 10px; margin: 5px; text-align: left;">1
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: right;">
                                        <asp:Label ID="lblnumber1617" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: right;">
                                        <asp:Label ID="lblnumber" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>

                                </tr>
                                <tr>
                                    <td style="padding: 10px; margin: 5px; text-align: left;">2
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK">Investment (Rs. in Crores)</asp:Label>
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: right;">
                                        <asp:Label ID="lblInv1617" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: right;">
                                        <asp:Label ID="lblinv" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>

                                </tr>
                                <tr>
                                    <td style="padding: 10px; margin: 5px; text-align: left;">3
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK">Employment</asp:Label>
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: right;">
                                        <asp:Label ID="lblem1617" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: right;">
                                        <asp:Label ID="lblEmp" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>

                                </tr>
                                <tr>
                                    <td style="padding: 10px; margin: 5px; text-align: left;">4
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK">Number of Industries - Commenced Operations</asp:Label>
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: right;">
                                        <asp:Label ID="lblCom1617" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: right;">
                                        <asp:Label ID="lblCO" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>

                                </tr>
                                <tr>
                                    <td style="padding: 10px; margin: 5px; text-align: left;">5
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK">Number of Industries - Advanced Stage</asp:Label>
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: right;">
                                        <asp:Label ID="lblads1617" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: right;">
                                        <asp:Label ID="lblas" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>

                                </tr>
                                <tr>
                                    <td style="padding: 10px; margin: 5px; text-align: left;">6
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK">Number of Industries - Initial Stage</asp:Label>
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: right;">
                                        <asp:Label ID="lblIns1617" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: right;">
                                        <asp:Label ID="lblis" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>

                                </tr>
                                <tr>
                                    <td style="padding: 10px; margin: 5px; text-align: left;">7
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK">Number of Industries - Yet to Start Construction</asp:Label>
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: right;">
                                        <asp:Label ID="lblYet1617" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: right;">
                                        <asp:Label ID="lblyet" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>

                                </tr>
                            </table>--%>

                            <asp:GridView ID="grdDetails" CssClass="floatingTable" runat="server" AutoGenerateColumns="true" CellPadding="5"
                                ShowFooter="True" Width="1000px">
                                <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="50px" CssClass="GridviewScrollC1HeaderWrap" Font-Bold="true" />
                                <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />

                                <RowStyle Wrap="true" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="Tr1" runat="server">
            <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">

                <div id="success" runat="server" visible="false" class="alert alert-success">
                    <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                    <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                </div>


                <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                    <strong>Warning!</strong>
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </div>
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
            <td align="center" style="padding: 5px; margin: 5px">&nbsp;
            </td>
        </tr>
    </table>
    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

