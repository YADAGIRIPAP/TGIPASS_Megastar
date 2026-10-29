<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="RptCertificatePendencyNew.aspx.cs" Inherits="RptCertificatePendencyNew" %>

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
        $(function () {
            $('#MstLftMenu').remove();

            //            var len = $('table.floatingTable tr').has('th').length;
            //            $('table.floatingTable').prepend('<thead></thead>')
            //            for (i = 0; i < len; i += 1) {
            //             $('table.floatingTable').find('thead').append($('table.floatingTable').find("tr:eq(" +i+")")); 
            //            }
        });



    </script>

    <script language="javascript" type="text/javascript">
        function Panel1() {

            document.getElementById('<%=A1.ClientID %>').style.display = "none";
            document.getElementById('<%=A2.ClientID %>').style.display = "none";

            document.getElementById('<%=HyperLink1.ClientID %>').style.display = "none";
            var panel = document.getElementById("<%=div_Print.ClientID %>");
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
    <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <div class="panel panel-default">
                    <div class="panel-heading" style="text-align: center">
                        <h3 class="panel-title" style="font-weight: bold;">
                            <asp:Label ID="lblHeading" runat="server">R1.4: TGiPASS Approval Generation Status</asp:Label>
                            <a id="A1" href="#" onclick="javascript:return Panel1();"
                                runat="server">
                                <img src="../../Resource/Images/pdf-printer-icon.jpg" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" /></a>

                            <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="Excel" /></a>
                        </h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 50%; font-family: 'Trebuchet MS'">

                            <tr>
                                <td colspan="2">
                                    <table width="80%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboardNew.aspx" Text="<< Back">
                                                </asp:HyperLink>
                                            </td>
                                            <td style="padding: 5px; text-align: right; margin: 5px;" colspan="8">
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
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

                                            <td style="padding: 5px; margin: 5px" colspan="4" align="left">
                                                <asp:Button ID="btnGet" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Generate Report" Width="180px" OnClick="btnGet_Click" />

                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" align="left"></td>

                                            <td style="padding: 5px; margin: 5px" align="right" colspan="3"></td>
                                            <td align="center">
                                                <asp:Button ID="btnbdf" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Generate Pdf" OnClick="btnbdf_Click" />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        <tr id="div_Print" runat="server">
                                            <td colspan="10" align="center" style="padding: 5px; margin: 5px">
                                                <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    OnRowDataBound="grdDetails_RowDataBound" Width="100%" OnRowCreated="grdDetails_RowCreated"
                                                    ShowFooter="True">
                                                    <HeaderStyle Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex +1 %>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="District" DataField="DistrictName" HeaderStyle-Width="200px">
                                                            <FooterStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <%--<asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="District Level"
                                                DataTextField="Dept Approved dist" >
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="State Level" DataTextField="Dept Approved State" >
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>--%>
                                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="District Level"
                                                            DataTextField="tsipass Approved dist">
                                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                        </asp:HyperLinkField>
                                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="State Level" DataTextField="tsipass Approved State">
                                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                        </asp:HyperLinkField>
                                                        <%--<asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="District Level"
                                                DataTextField="Pending Approved dist">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="State Level" DataTextField="Pending Approved State">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>--%>
                                                    </Columns>
                                                    <RowStyle Wrap="true" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="2" align="center" style="padding: 5px; margin: 5px">
                                    <div id="success" runat="server" class="alert alert-success" visible="false">
                                        <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
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
</asp:Content>

