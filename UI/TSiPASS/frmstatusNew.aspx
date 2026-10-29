<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmstatusNew.aspx.cs" Inherits="UI_TSiPASS_frmstatusNew" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <style type="text/css">
        .overlay
        {
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

        .style8
        {
            color: #FF0000;
            font-weight: bold;
        }

        .algnCenter
        {
            text-align: center;
        }
        
        table td:nth-child(3) { text-align:left;}
        table td:nth-child(5) { text-align:left;}
        
    </style>

  <%--  <script type="text/javascript" src="../../js/jquery.min.js"></script>

    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>

    <script type="text/javascript" src="../../js/gridviewScroll.min.js"></script>--%>
    <script language="javascript" type="text/javascript">
       // function removescrolling() {
       //     $('#<%=divPrint.ClientID %>').addClass('removescroll');
       //     $('#<%=grdDetails.ClientID%>').gridviewScroll({
       //
       //     });
       // }
//        function pageLoad() {
//            $('#<%=grdDetails.ClientID%>').gridviewScroll({
//                width: "1024px",
//                height: "100%",
//                arrowsize: 30,
//                varrowtopimg: "../../images/arrowvt.png",
//                varrowbottomimg: "../../images/arrowvb.png",
//                harrowleftimg: "../../images/arrowhl.png",
//                harrowrightimg: "../../images/arrowhr.png"
//            });
//            //loadfirstRow();
//        }

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }

    </script>
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
    <script type="text/javascript" language="javascript">
        var win = new Object();
        function Popup(intval) {

            win = window.open("CFEPopup.aspx?UID=" + intval, "List", "scrollbars=yes,resizable=yes,width=780,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");
            //win = window.open("RptVillageOraganisationNameClickDetails.aspx?id="+intval, "List", "scrollbars=yes,resizable=yes,width=600,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");

        }
    </script>
<%--
    <script type="text/javascript" src="../../js/jquery.min.js"></script>

    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>

    <script type="text/javascript" src="../../js/gridviewScroll.min.js"></script>--%>
    <script language="javascript" type="text/javascript">
        function Panel1() {

            document.getElementById('<%=Button1.ClientID %>').style.display = "none";


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
    </script>

    <%--<script type="text/javascript">

        function pageLoad() {
            $('#<%=grdDetails.ClientID%>').gridviewScroll({
            width: "100%",
                height: "100%",
                arrowsize: 30,
                varrowtopimg: "../../images/arrowvt.png",
                varrowbottomimg: "../../images/arrowvb.png",
                harrowleftimg: "../../images/arrowhl.png",
                harrowrightimg: "../../images/arrowhr.png"
            });
        } 
           
    </script>--%>
    <script type="text/javascript">


        function GridHeaderFixed() {
            console.log('called');
            var scroll = $(window).scrollTop();
            var anchor_top = $('#<%=grdDetails.ClientID%>').offset().top;
            var anchor_bottom = $("#bottom_anchor").offset().top;
            if (scroll > anchor_top && scroll < anchor_bottom) {
                clone_table = $("#clone1");
                if (clone_table.length == 0) {
                    console.log('called inner');
                    clone_table = $('#<%=grdDetails.ClientID%>').clone().find('tr+tr').remove().end();
                    clone_table.attr('id', 'clone1');
                    clone_table.css({
                        position: 'fixed',
                        'pointer-events': 'none',
                        top: 0
                    });
                    clone_table.width($('#<%=grdDetails.ClientID%>').width());
                    $("#table-container").append(clone_table);
                    $("#clone1").css({ visibility: 'hidden' });
                    $("#clone1 tbody").css({ visibility: 'visible' });

                    $.each($('#<%=grdDetails.ClientID%> tr:first th'), function (i, v) {
                        $("#clone1").find("tr th").eq(i).width($(v).width()); //.addClass('GridviewScrollC1HeaderWrap');
                    });
                }
            } else {
                $("#clone1").remove();
            }
        }
      //  $(window).scroll(GridHeaderFixed);


        $(function () {

            $('#MstLftMenu').remove();

        });


    </script>
     <%--datepicker added on 17/01/2019--%>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
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
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
            <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit"></i></li>
            <li class="active"><i class="fa fa-edit"></i><a href="#">View Applications</a> </li>
        </ol>
    </div>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title" style="font-weight: bold;">
                            <asp:Label ID="lblHeading" runat="server"></asp:Label>&nbsp; &nbsp; <a id="Button2" href="#" onserverclick="BtnPDF_Click"
                                runat="server">
                                <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" /></a> <a id="A2" href="#" onserverclick="BtnSave2_Click1" runat="server">
                                        <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a>
                                            <a id="btnPrnt" href="#"  onclick="doPrint()"  runat="server">
                               <%--<asp:Button ID="Button1" runat="server" Text="Print" OnClientClick="doPrint()" />--%>  
                              <%--  <img src="../../images/png-for-print-1.png" width="50px;" height="40px;" style="float: right;"
                                    alt="PDF" />--%>
                                     <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                                                        style="float: right;" />
                                    </a>
                                            </h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                            <%--<tr>
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/frmR1ReportKMR.aspx"
                                    Text="Back">
                                </asp:HyperLink>
                            </tr>--%>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 80%; font-family: 'Trebuchet MS'">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" Text="<< Back">
                                                </asp:HyperLink>
                                            </td>
                                            <td class="col-xs-3" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px" align="center">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px" align="right">&nbsp;</td>
                                            <td class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="col-xs-3" style="padding: 5px; margin: 5px">
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
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="center">
                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        From Date
                                                    </div>

                                                    <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                   <%-- <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                    </cc1:CalendarExtender>--%>
                                                </div>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">

                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        To Date
                                                    </div>
                                                    <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                    <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                                    </cc1:CalendarExtender>--%>
                                                </div>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="right">
                                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-default" TabIndex="10"
                                                    Text="Submit" OnClick="BtnSave1_Click" />
                                            </td>
                                            <td class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px"></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%--<tr>
                                <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="13px"
                                        ForeColor="#006600"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                        TabIndex="10" Text="Search" Width="90px" OnClick="BtnSave1_Click" />
                                    <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                        Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="Cancel" ToolTip="To Clear  the Screen"
                                        Width="90px" Visible="False" />
                                    <asp:Button ID="BtnSave2" runat="server" CssClass="btn btn-primary" Height="32px"
                                        TabIndex="10" Text="Export" Width="90px" OnClick="BtnSave2_Click1" />
                                    <asp:Button ID="BtnPDF" runat="server" CssClass="btn btn-warning" Height="32px" OnClick="BtnPDF_Click"
                                        TabIndex="10" Text="PDF" Width="90px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="style8" style="padding: 5px; margin: 5px; text-align: right;"
                                    valign="top">
                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                    &nbsp;
                                </td>
                            </tr>--%>
                            <tr id="divPrint" runat="server">
                                <td>
                                    <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td align="center" style="text-align: center;" valign="top">
                                                <asp:Label ID="Label12" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label></td>
                                        </tr>
                                        <tr>

                                            <td align="center" style="text-align: center;" valign="top">
                                            <div id="table-container">
                                                <asp:GridView ID="grdDetails"  runat="server" AutoGenerateColumns="true" CellPadding="5"
                                                    ShowFooter="True" OnRowDataBound="grdDetails_RowDataBound" Width="100%" OnPreRender="grdDetails_PreRender">
                                                    <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                                <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                <asp:HiddenField ID="HdfApprovalid" runat="server" />

                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="text-center" HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Eval("UID Number") %>'></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <RowStyle Wrap="true" />
                                                </asp:GridView>
                                                <div id="bottom_anchor"></div>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                            <tr id="divExport" visible="false" runat="server">
                                <td>
                                    <table>

                                        <tr>
                                            <td align="center" style="text-align: center;" valign="top">
                                                <asp:Label ID="lblReportDt" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
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
                                    </table>
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
                        <asp:HiddenField ID="hdfID" runat="server" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="group" />
                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="child" />
                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>


