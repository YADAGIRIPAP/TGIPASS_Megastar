<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmDistrictReportSectorDRILLDOWN.aspx.cs" Inherits="UI_TSiPASS_frmDistrictReportSectorDRILLDOWN" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <style type="text/css">
        .overlay {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 112px;
            background-color: Gray;
            filter: alpha(opacity=60);
            opacity: 0.9;
            -moz-opacity: 0.9;
        }

        .style8 {
            color: #FF0000;
            font-weight: bold;
        }

        .algnRight {
            text-align: right;
        }
    </style>

    <style>
        .algnCenter {
            text-align: center;
        }

        body {
            font-family: 'Trebuchet MS';
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <script type="text/javascript" language="javascript">
        var win = new Object();
        function Popup(intval) {

            win = window.open("CFEPopup.aspx?UID=" + intval, "List", "scrollbars=yes,resizable=yes,width=780,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");
            //win = window.open("RptVillageOraganisationNameClickDetails.aspx?id="+intval, "List", "scrollbars=yes,resizable=yes,width=600,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");

        }
    </script>

    <%--<script type="text/javascript" src="../../js/jquery.min.js"></script>

    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>

    <script type="text/javascript" src="../../js/gridviewScroll.min.js"></script>--%>

    <script type="text/javascript">

        //        function pageLoad() {
        //            $('#<%=grdDetails.ClientID%>').gridviewScroll({
        //                width: 1090,
        //                height: "100%",
        //                arrowsize: 30,
        //                varrowtopimg: "../../images/arrowvt.png",
        //                varrowbottomimg: "../../images/arrowvb.png",
        //                harrowleftimg: "../../images/arrowhl.png",
        //                harrowrightimg: "../../images/arrowhr.png"
        //            });
        //        }

        $(function () {

            $('#MstLftMenu').remove();

        });

    </script>
    <%--Added datepicker on 18/01/2019--%>
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
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
            <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit"></i></li>
            <li class="active"><i class="fa fa-edit"></i><a href="#">Application Details</a> </li>
        </ol>
    </div>
    <div class="col-lg-12">
        <div class="panel panel-default">
            <div class="panel-heading" align="center">
                <h3 class="panel-title" style="font-weight: bold;">
                    <asp:Label ID="lblHeading" runat="server"></asp:Label>&nbsp; <a id="A1" href="#"
                        onserverclick="BtnSave3_Click" runat="server">
                        <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                            alt="PDF" /></a>&nbsp;&nbsp; <a id="A2" href="#" onserverclick="BtnSave2_Click1" runat="server">
                                <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="Excel" /></a>
                                    <a id="pdfPrint" href="#" onclick="javascript:return Panel1();"
                                                    runat="server">
                                                    <img src="../../Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                                                        style="float: right;" /></a>
                                    </h3>
            </div>
            <div class="panel-body">
                <table align="center" cellpadding="10" cellspacing="5">
                    <tr>
                        <td style="padding: 5px; margin: 5px" align="left">
                            <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" Text="<< Back">
                            </asp:HyperLink>
                        </td>
                        <%--<td class="col-xs-3" style="padding: 5px; margin: 5px">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            District
                                        </div>
                                        <asp:DropDownList ID="ddldistrict" runat="server" class="form-control txtbox" Width="180px">
                                            <asp:ListItem>--Select--</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Category
                                        </div>
                                        <asp:DropDownList ID="ddlCategory" runat="server" class="form-control txtbox" Height="33px"
                                            Width="180px">
                                            <asp:ListItem>--Select--</asp:ListItem>
                                            <asp:ListItem Value="1">MEGA</asp:ListItem>
                                            <asp:ListItem Value="2">LARGE</asp:ListItem>
                                            <asp:ListItem Value="3">MEDIUM</asp:ListItem>
                                            <asp:ListItem Value="4">SMALL</asp:ListItem>
                                            <asp:ListItem Value="5">MICRO</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </td>--%>
                        <td class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                            <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4" style="padding: 5px; margin: 5px">
                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="13px"
                                ForeColor="#006600"></asp:Label>
                        </td>
                    </tr>
                    <%--<tr>
                                <td align="center" colspan="4" style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                        TabIndex="10" Text="Search" Width="90px" OnClick="BtnSave1_Click" />
                                    <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                        Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="Cancel" ToolTip="To Clear  the Screen"
                                        Width="90px" Visible="False" />
                                    <asp:Button ID="BtnSave2" runat="server" CssClass="btn btn-primary" Height="32px"
                                        TabIndex="10" Text="Export" Width="90px" OnClick="BtnSave2_Click1" />
                                    <asp:Button ID="BtnSave3" runat="server" CssClass="btn btn-warning" Height="32px"
                                        TabIndex="10" Text="PDF" Width="90px" OnClick="BtnSave3_Click" /><%--OnClientClick="return Panel1();"
                                </td>
                            </tr>--%>
                    <tr>
                        <td align="center" colspan="4" class="style8" style="padding: 5px; margin: 5px; text-align: right;"
                            valign="top"></td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <table width="100%">
                                <%--<tr>
                                            <td style="padding: 5px; margin: 5px" align="left">Input Type</td>
                                            <td style="padding: 5px; margin: 5px" colspan="3" align="left">
                                                <asp:RadioButtonList ID="rbtnlstInputType" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rbtnlstInputType_SelectedIndexChanged">
                                                    <asp:ListItem Value="F" Selected="True">Financial Years</asp:ListItem>
                                                    <asp:ListItem Value="N">Between Dates</asp:ListItem>
                                                </asp:RadioButtonList></td>

                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" align="left"></td>
                                            <td style="padding: 5px; margin: 5px" align="left" colspan="3"></td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr runat="server" id="trFinYears" visible="true">
                                            <td style="padding: 5px; margin: 5px" align="left">Financial Year</td>
                                            <td style="padding: 5px; margin: 5px" align="left" colspan="3">
                                                <asp:DropDownList ID="ddlFinancialYear" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList></td>
                                            <td></td>
                                            <td></td>
                                        </tr>--%>
                                <tr runat="server" id="trBetweenDates" visible="false">
                                    <td style="padding: 5px; margin: 5px">From Date:   
                                                
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                        <%-- <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                </cc1:CalendarExtender>--%>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">To Date:  
                                            
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                        <%-- <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                                </cc1:CalendarExtender>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px" align="left"></td>
                                    <td style="padding: 5px; margin: 5px" align="left" colspan="3"></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr align="center">
                                    <td id="Td1" style="padding: 5px; margin: 5px" colspan="4" align="center" runat="server" visible="false">
                                        <asp:Button ID="btnGet" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Generate Report" Width="180px" OnClick="btnGet_Click" />




                                    </td>
                                </tr>
                                <tr align="center" runat="server" id="trsubmit" visible="false">
                                    <td id="Td2" style="padding: 5px; margin: 5px" colspan="4" align="center" runat="server">
                                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-default" TabIndex="10"
                                            Text="Submit" OnClick="BtnSave1_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="divPrint" runat="server">
                        <td align="center" colspan="4" style="padding: 5px; margin: 5px; text-align: center;"
                            valign="top">
                            <asp:GridView ID="grdDetails"  runat="server" AutoGenerateColumns="true" CellPadding="4"
                                            OnRowDataBound="grdDetails_RowDataBound" Width="100%" ShowFooter="True">
                                            <HeaderStyle Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                            <RowStyle CssClass="GridviewScrollC1Item" />
                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                            <FooterStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                            <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="SlNo">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <%--<asp:BoundField DataField="District" HeaderText="District" >
                                               <ItemStyle Width="180px" />
                                               </asp:BoundField>
                                               <asp:BoundField DataField="UnitName" HeaderText="No of Industries">
                                               <ItemStyle CssClass="text-center" Width="180px" />
                                               </asp:BoundField>
                                               <asp:BoundField DataField="lineofActivity" HeaderText="Investment (Rs. in Cr)" >
                                               <ItemStyle CssClass="text-center" Width="180px" />
                                               </asp:BoundField>
                                               <asp:BoundField DataField="Sector" HeaderText="Total Employment" >
                                               <ItemStyle CssClass="text-center" Width="180px" />
                                               </asp:BoundField>
                                                 <asp:BoundField DataField="Investment" HeaderText="Total Employment" >
                                               <ItemStyle CssClass="text-center" Width="180px" />
                                               </asp:BoundField>
                                                 <asp:BoundField DataField="NoofEmployee" HeaderText="Total Employment" >
                                               <ItemStyle CssClass="text-center" Width="180px" />
                                               </asp:BoundField>
                                                <asp:BoundField DataField="ApplicationDate" HeaderText="Total Employment" >
                                               <ItemStyle CssClass="text-center" Width="180px" />
                                               </asp:BoundField>
                                                <asp:BoundField DataField="ApprovalDate" HeaderText="Total Employment" >
                                               <ItemStyle CssClass="text-center" Width="180px" />
                                               </asp:BoundField>--%>
                                            </Columns>
                                        </asp:GridView>
                        </td>
                    </tr>
                    <tr id="divExport" visible="false" runat="server">
                        <td align="center" style="text-align: center;" valign="top">
                            <asp:GridView ID="grdExport" runat="server" AutoGenerateColumns="true" ShowFooter="true">

                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="S.No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1%>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="text-center" HorizontalAlign="Center" />
                                    </asp:TemplateField>

                                </Columns>
                                <RowStyle Wrap="true" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4" style="padding: 5px; margin: 5px">
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
                <asp:HiddenField ID="hdfID" runat="server" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="group" />
                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="child" />
                <asp:HiddenField ID="hdfFlagID" runat="server" />
            </div>
        </div>
    </div>

    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>
