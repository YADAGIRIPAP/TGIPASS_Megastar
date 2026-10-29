<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmIncentives_Released_Yearwise.aspx.cs" Inherits="UI_TSiPASS_frmReportPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        //      function pageLoad() {
        //          $('#<%=grdDetails.ClientID%>').gridviewScroll({
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
        //        function removescrolling() {
        //            $('#<%=divPrint.ClientID %>').addClass('removescroll');
        //            $('#<%=grdDetails.ClientID%>').gridviewScroll({

        //            });
        //        }

        function Panel1() {
           <%-- document.getElementById('<%=Button1.ClientID %>').style.display = "none";
            document.getElementById('<%=Button2.ClientID %>').style.display = "none";--%>
<%--            document.getElementById('<%=GraphPrint.ClientID %>').style.display = "none";--%>
            document.getElementById('<%=tblselection.ClientID %>').style.display = "none";
            document.getElementById('<%=HyperLink1.ClientID %>').style.display = "none";

            removescrolling();
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




        $(function () {

            $('#MstLftMenu').remove();

        });


    </script>
    <script language="javascript" type="text/javascript">
        function Panel2() {
           <%-- document.getElementById('<%=Button1.ClientID %>').style.display = "none";
            document.getElementById('<%=Button2.ClientID %>').style.display = "none";--%>
<%--            document.getElementById('<%=A1.ClientID %>').style.display = "none";--%>
            document.getElementById('<%=tblselection.ClientID %>').style.display = "none";
            document.getElementById('<%=GridPrint.ClientID %>').style.display = "none";
            document.getElementById('<%=HyperLink1.ClientID %>').style.display = "none";

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
        function Panel1() {

    <%--        document.getElementById('<%=Button2.ClientID %>').style.display = "none";

              document.getElementById('<%=tblselection.ClientID %>').style.display = "none";--%>

             <%--var value1 = document.getElementById('<%=Label1.ClientID%>').value;--%>

            <%-- var vSkill = document.getElementById('<%=ddlOutward.ClientID%>');

             var vSkillText = vSkill.outerHTML;--%>



      <%--  var result1 = document.getElementById('<%=ddlOutward.ClientID%>').innerHTML;--%>

         var panel = document.getElementById("<%=GridPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            //if (vSkillText = '--Select--')
            //    vSkillText = 'Total outward records';
            //else
            //vSkillText = 'Total outward records of "' + value1 + '"';
            printWindow.document.write('<html><head><h3 style="width: 100%;text-align: center;"></h3>');

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
                            <h2 id="H1" runat="server" class="panel-title" style="font-weight: bold; text-align:center">
                                <asp:Label ID="lblHeading" runat="server">R5.5 INCENTIVES RELEASED FINANCIAL YEARWISE REPORT</asp:Label>
                                <a id="Button2" href="#" onserverclick="Button2_ServerClick" runat="server">
                                    <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                        alt="PDF" /></a> &nbsp;<a id="Button1" href="#" onserverclick="Button1_ServerClick" runat="server">
                                            <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                                alt="Excel" /></a>&nbsp; <a id="pdfPrint" href="#" onclick="javascript:return Panel1();"
                                                    runat="server">
                                                    <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                                                        style="float: right;" /></a>
                            </h2>
                        </div>
                        <div class="panel-body">
                            <table align="center" cellpadding="10" cellspacing="5" style="width: 80%; font-family: 'Trebuchet MS'">
                                <tr>
                                    <td>
                                        <table runat="server" id="tblselection" cellpadding="4" cellspacing="5" style="width: 100%">
                                            <tr>
                                                <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboardNew.aspx"
                                                        Text="<< Back">
                                                    </asp:HyperLink>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="12" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">Report as on date: <asp:Label ID="lbllabel" runat="server"></asp:Label></td>
                                  
                                </tr>                                
                                <tr id="GridPrint" runat="server">
                                    <td colspan="2" align="center" style="padding: 5px; margin: 5px" id="divPrint1" runat="server">
                                        <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                            OnRowDataBound="grdDetails_RowDataBound" Width="100%" OnPageIndexChanging="grdDetails_PageIndexChanging"
                                            ShowFooter="True" OnRowCreated="grdDetails_RowCreated" OnSelectedIndexChanged="grdDetails_SelectedIndexChanged">
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
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:TemplateField>
                                                  <asp:BoundField DataField="FinYear" HeaderText="Years">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle CssClass="text-uppercase" />
                                                </asp:BoundField>                                                 
                                                <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Blue"
                                                    FooterStyle-CssClass="text-center" DataTextField="GENERALCOUNT" HeaderText="No of Claims">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="GENERALSANCTIONED" HeaderText="Sanctioned Amount in(Cr)">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>                                              
                                                   <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Blue"
                                                    FooterStyle-CssClass="text-center" DataTextField="SCCOUNT" HeaderText="No of Claims">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                 <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="SCAMOUNT" HeaderText="Sanctioned Amount in(Cr)">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>                                          
                                                 <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Blue"
                                                    FooterStyle-CssClass="text-center" DataTextField="STCOUNT" HeaderText="No of Claims">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                 <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="STAMOUNT" HeaderText="Sanctioned Amount in(Cr)">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>                                             
                                                 <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Blue"
                                                    FooterStyle-CssClass="text-center" DataTextField="PHCCOUNT" HeaderText="No of Claims">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                 <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="PHCAMOUNT" HeaderText="Sanctioned Amount in(Cr)">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>                                            
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <%--      <tr id="GraphPrint" runat="server">
                                    <td colspan="2" align="center" style="padding: 5px; margin: 5px">
                                        <a id="A1" href="#" onclick="javascript:return Panel2();" runat="server">
                                            <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                                alt="PDF" /></a>
                                        <div>
                                            <br />
                                            <br />
                                            <script type="text/javascript" src="../../js/googleapi.js"></script>
                                            <asp:Literal ID="ltrPie" runat="server"></asp:Literal>
                                            <div id="piechart_3d" style="border-style: solid; border-width: 1px; width: 100%;
                                                height: 600px;">
                                            </div>
                                        </div>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td align="center" style="padding: 5px; margin: 5px">
                                        <div id="success" runat="server" visible="false" class="alert alert-success">
                                            <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                        </div>
                                        <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>
                                                Warning!</strong>
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

