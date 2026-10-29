<%@ Page Language="C#" AutoEventWireup="true" CodeFile="comReportDrillNew.aspx.cs"
    MasterPageFile="~/UI/TSiPASS/CCMaster.master" Inherits="UI_TSiPASS_comReportDrillNew" %>

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

      <script type="text/javascript">
          function printGrid() {
              var gridData = document.getElementById('<%= printest.ClientID %>');
              var windowUrl = ' ';
              //set print document name for gridview
              var uniqueName = new Date();
              var windowName = 'Print_' + uniqueName.getTime();
              var prtWindow = window.open('', '',
                  'left=100,top=100,right=100,bottom=100,width=700,height=500,toolbar=0,scrollbars=1,status=0,resizable=1');
              prtWindow.document.write('<html><head></head>');
              prtWindow.document.write('<body style=”background:none !important”>');
              prtWindow.document.write(gridData.outerHTML);
              prtWindow.document.write('</body></html>');
              prtWindow.document.close();
              prtWindow.focus();
              prtWindow.print();
              prtWindow.close();
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
            //System.out.println(java.time.LocalDate.now());  
        }
    </script>
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
    <div class="col-lg-12">
        <div class="panel panel-default">
            <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px;" valign="top"
                        align="center">
                        <div class="panel panel-default">
                            <div class="panel-heading" style="text-align: center">
                                <h3 class="panel-title" style="font-weight: bold;">
                                    <asp:Label ID="lblHeading" runat="server">COI Dashboard </asp:Label>&nbsp;&nbsp;
                                    <%--<a id="A1" href="#"  onclick="doPrint()"  runat="server">--%>
                                    <a id="A1" href="#" visible="true" runat="server" onclick="printGrid()">
                                        <img src="../../images/png-for-print-1.png" width="50px;" height="20px;" style="float: right;"
                                            alt="PDF" /></a>
                                    <%-- <a id="btnPrnt" href="#" onclick="doPrint()" runat="server">
                                             
                                              <img src="../../images/png-for-print-1.png" width="50px;" height="20px;" style="float: right;"
                                                  alt="PDF" /></a>--%>
                                    <a id="Button2" href="#" onclick="javascript:return Panel1();" runat="server" visible="false">
                                        <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="PDF" /></a>
                                    <%--<a id="Button1" href="#" onserverclick="BtnSave2_Click" runat="server">
                                        <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a>--%>
                                    <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                        <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a>
                                </h3>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 100%; font-family: 'Trebuchet MS'">
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" align="left">
                                        </td>
                                        <td style="padding: 5px; margin: 5px; margin-left: 149px;" colspan="3" align="center">
                                            <asp:RadioButtonList ID="rbtnlstInputType" runat="server" RepeatDirection="Horizontal"
                                                AutoPostBack="True" OnSelectedIndexChanged="rbtnlstInputType_SelectedIndexChanged">
                                                <asp:ListItem Value="F">Financial Years</asp:ListItem>
                                                <asp:ListItem Value="N" Selected="True">Between Dates</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td>
                                             <b>
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label></b>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="trFinYears" visible="false">
                                        <td style="padding: 5px; margin: 5px" align="left">
                                        </td>
                                        <td style="padding: 5px; margin: 5px" align="center" colspan="3">
                                            <asp:DropDownList ID="ddlFinancialYear" runat="server" class="form-control txtbox"
                                                Height="33px" Width="180px" AutoPostBack="true" OnSelectedIndexChanged="ddlFinancialYear_SelectedIndexChanged">
                                                <asp:ListItem>--Select--</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="trBetweenDates" visible="true">
                                        <td style="padding: 5px; margin: 5px; float: right; margin-left: 135px; margin-bottom: 10px;"
                                            align="right">
                                            <%--  <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                </cc1:CalendarExtender>--%>
                                            From Date:
                                        </td>
                                        <td style="padding: 5px; margin: 5px" align="left">
                                            <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px"
                                                MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                Width="125px"></asp:TextBox>
                                        </td>
                                        <td style="padding: 5px; margin: 5px" align="right">
                                            <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                                </cc1:CalendarExtender>--%>
                                            To Date:
                                            <%--<asp:Label ID="Label352" Visible="false" runat="server" data-balloon-length="large" data-balloon="Please Select Proposed Location"
                                                data-balloon-pos="down" CssClass="LBLBLACK">District : </asp:Label>--%>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; float: left;" align="right">
                                            <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px"
                                                MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                Width="125px"></asp:TextBox>
                                        </td>
                                        <td class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td style="padding: 5px; margin: 5px" align="center">
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td style="padding: 5px; text-align: center; margin: 5px" colspan="2">
                                            <asp:Button ID="Button3" runat="server" CssClass="btn btn-primary" TabIndex="10"
                                                Text="Submit" OnClick="BtnSave1_Click" />
                                        </td>
                                        <td class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                            <asp:Button ID="btnNewPdf" runat="server" CssClass="btn btn-primary" Height="32px"
                                                TabIndex="10" Text="Generate Pdf" OnClick="btnNewPdf_Click" />
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td style="text-align: right" colspan="6" align="right">
                                            &nbsp;<asp:Button ID="btnNewPdf" runat="server" CssClass="btn btn-primary" Height="32px"
                                                TabIndex="10" Text="Generate Pdf" OnClick="btnNewPdf_Click"/>
                                        </td>

                                    </tr>--%>
                                    <tr id="div_Print1" runat="server">
                                       
                                        <td align="center" style="width: 33%; padding: 5px; margin: 5px" colspan="2">
                                    
                                            <asp:GridView ID="grdDetails1" AutoGenerateColumns="false" runat="server" CellPadding="2"
                                                Width="80%" OnRowDataBound="grdDetails1_RowDataBound" ShowFooter="True">
                                                <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:BoundField DataField="Sno" HeaderText="Sno">
                                                        <ItemStyle />
                                                    </asp:BoundField>
                                                    <%-- <asp:HyperLinkField DataTextField="Sno" HeaderText="Sno">
                                                        <ItemStyle CssClass="text-center" Font-Bold="true" />
                                                    </asp:HyperLinkField>--%>
                                                    <%-- <asp:BoundField DataField="Type" HeaderText="Type">
                                                                            <ItemStyle Font-Bold="true" HorizontalAlign="Center" CssClass="text-center"  />
                                                                        </asp:BoundField>--%>
                                                    <asp:HyperLinkField DataTextField="Type" HeaderText="Type">
                                                        <ItemStyle Font-Bold="true" />
                                                    </asp:HyperLinkField>
                                                    <%--  <asp:TemplateField HeaderText="Type">
                                                        <ItemTemplate>
                                                            <asp:Label ID="statusLabel" runat="server" Text='<%#Bind("Type") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <%--<asp:BoundField DataField="PENDINGCOUNT" HeaderText="Types">
                                                                            <ItemStyle Width="150px" />
                                                                        </asp:BoundField>--%>
                                                    <asp:HyperLinkField DataTextField="Count" HeaderText="Count">
                                                        <ItemStyle CssClass="text-center" Font-Bold="true" />
                                                    </asp:HyperLinkField>
                                                </Columns>
                                            </asp:GridView>
                                           
                                        </td>
                                        <%--     <td align="center" style="  width:33%; padding: 5px; margin: 5px" colspan="2">
                                            <asp:GridView ID="GridView1" AutoGenerateColumns="false"
                                                runat="server" CellPadding="2" Width="100%" OnRowDataBound="GridView1_RowDataBound"
                                                ShowFooter="True">
                                                <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:BoundField DataField="Sno" HeaderText="Sno">
                                                        <ItemStyle />
                                                    </asp:BoundField>
                                                   
                                                     <asp:HyperLinkField DataTextField="Type" HeaderText="Type">
                                                        <ItemStyle CssClass="text-center" Font-Bold="true" />
                                                    </asp:HyperLinkField>

                                                  
                                                    <asp:HyperLinkField DataTextField="Count" HeaderText="Count">
                                                        <ItemStyle CssClass="text-center" Font-Bold="true" />
                                                    </asp:HyperLinkField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>--%>
                                        <td align="center" style="width: 10%; padding: 5px; margin: 5px" colspan="1">
                                        </td>
                                        <td align="center" style="width: 33%; padding: 5px; margin: 5px" colspan="2">
                                            <asp:GridView ID="GridView2" AutoGenerateColumns="false" runat="server" CellPadding="2"
                                                Width="60%" OnRowDataBound="GridView2_RowDataBound" ShowFooter="True">
                                                <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <%--<asp:BoundField DataField="Sno" HeaderText="Sno">
                                                        <ItemStyle />
                                                    </asp:BoundField>--%>
                                                    <asp:HyperLinkField DataTextField="Sno" HeaderText="Sno">
                                                        <ItemStyle CssClass="text-center" Font-Bold="true" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Type" HeaderText="Type">
                                                        <ItemStyle Font-Bold="true" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField DataTextField="Count" HeaderText="Count">
                                                        <ItemStyle CssClass="text-center" Font-Bold="true" />
                                                    </asp:HyperLinkField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr id="div_Print" runat="server">
                                        <td align="center" colspan="6" style="padding: 5px; margin: 5px">
                                             <div runat="server" id="printest">
                                          <b>
                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label></b>
                                            <asp:GridView ID="grdDetails" AutoGenerateColumns="false" runat="server" CellPadding="2"
                                                Width="60%" ShowFooter="True" OnRowDataBound="grdDetails_RowDataBound">
                                                <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:BoundField DataField="Sno" HeaderText="Sno">
                                                        <ItemStyle />
                                                    </asp:BoundField>
                                                    <%--
                                                    <asp:HyperLinkField DataTextField="Sno" HeaderText="Sno">
                                                        <ItemStyle CssClass="text-center" Font-Bold="true" />
                                                    </asp:HyperLinkField>--%>
                                                    <asp:HyperLinkField DataTextField="Type" HeaderText="Type">
                                                        <ItemStyle CssClass="text-right" Font-Bold="true" />
                                                    </asp:HyperLinkField>
                                                    <%--  <asp:TemplateField HeaderText="Type">
                                                        <ItemTemplate>
                                                            <asp:Label ID="statusLabel" runat="server" Text='<%#Bind("Type") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <%--<asp:BoundField DataField="PENDINGCOUNT" HeaderText="Types">
                                                                            <ItemStyle Width="150px" />
                                                                        </asp:BoundField>--%>
                                                    <asp:HyperLinkField DataTextField="Count" HeaderText="Count">
                                                        <ItemStyle CssClass="text-center" Font-Bold="true" />
                                                    </asp:HyperLinkField>
                                                </Columns>
                                            </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px">
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
