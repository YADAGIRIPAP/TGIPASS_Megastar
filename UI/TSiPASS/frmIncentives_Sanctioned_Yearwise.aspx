<%@ page title="" language="C#" masterpagefile="~/UI/TSiPASS/CCMaster.master" autoeventwireup="true" codefile="frmIncentives_Sanctioned_Yearwise.aspx.cs" inherits="DashboardPage" enableeventvalidation="false" %>

<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
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
                            <h2 id="H1" runat="server" class="panel-title" style="font-weight: bold; text-align: center">
                                <asp:label id="lblHeading" runat="server">R5.3 INCENTIVES SANCTIONED FINANCIAL YEARWISE REPORT</asp:label>
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
                                                    <asp:hyperlink cssclass="btn btn-link" id="HyperLink1" runat="server" navigateurl="~/UI/TSiPASS/ReportsDashboardNew.aspx"
                                                        text="<< Back">
                                                    </asp:hyperlink>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="12" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">Report as on date:
                                        <asp:label id="lbllabel" runat="server"></asp:label>
                                    </td>
                                </tr>
                                <tr id="GridPrint" runat="server">
                                    <td colspan="2" align="center" style="padding: 5px; margin: 5px" id="divPrint1" runat="server">
                                        <asp:gridview id="grdDetails" runat="server" autogeneratecolumns="false" cellpadding="4"
                                            onrowdatabound="grdDetails_RowDataBound" width="100%" onpageindexchanging="grdDetails_PageIndexChanging"
                                            showfooter="True" onrowcreated="grdDetails_RowCreated" onselectedindexchanged="grdDetails_SelectedIndexChanged">
                                            <headerstyle forecolor="#FFFFFF" backcolor="#009688" height="40px" cssclass="GridviewScrollC1HeaderWrap" />
                                            <rowstyle height="40px" cssclass="GridviewScrollC1Item" />
                                            <pagerstyle cssclass="GridviewScrollC1Pager" />
                                            <footerstyle forecolor="#FFFFFF" backcolor="#009688" height="40px" cssclass="GridviewScrollC1Footer" />
                                            <alternatingrowstyle height="40px" cssclass="GridviewScrollC1Item2" />
                                            <columns>
                                                <asp:templatefield headerstyle-horizontalalign="Center" headertext="S.No">
                                                    <itemtemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </itemtemplate>
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" cssclass="text-center" />
                                                </asp:templatefield>
                                                <asp:boundfield datafield="FinYear" headertext="Years">
                                                    <footerstyle horizontalalign="Center" font-underline="false" font-bold="true" cssclass="text-center" />
                                                    <itemstyle cssclass="text-uppercase" />
                                                </asp:boundfield>
                                                <asp:boundfield headertext="No.of Units" datafield="GENERALUNITS" />
                                                <asp:hyperlinkfield controlstyle-font-underline="false" controlstyle-forecolor="Blue"
                                                    footerstyle-cssclass="text-center" datatextfield="GENERALCOUNT" headertext="No of Claims">
                                                    <footerstyle horizontalalign="Center" font-underline="false" font-bold="true" cssclass="text-center" />
                                                    <itemstyle horizontalalign="Center" cssclass="text-center" />
                                                </asp:hyperlinkfield>
                                                <asp:hyperlinkfield controlstyle-font-underline="false" controlstyle-forecolor="Black"
                                                    footerstyle-cssclass="text-center" datatextfield="GENERALSANCTIONED" headertext="Sanctioned Amount in(Cr)">
                                                    <footerstyle horizontalalign="Center" font-underline="false" font-bold="true" cssclass="text-center" />
                                                    <itemstyle horizontalalign="Center" cssclass="text-center" />
                                                </asp:hyperlinkfield>
                                                <asp:boundfield headertext="No.of Units" datafield="SCUNITS" />
                                                <asp:hyperlinkfield controlstyle-font-underline="false" controlstyle-forecolor="Blue"
                                                    footerstyle-cssclass="text-center" datatextfield="SCCOUNT" headertext="No of Claims">
                                                    <footerstyle horizontalalign="Center" font-underline="false" font-bold="true" cssclass="text-center" />
                                                    <itemstyle horizontalalign="Center" cssclass="text-center" />
                                                </asp:hyperlinkfield>
                                                <asp:hyperlinkfield controlstyle-font-underline="false" controlstyle-forecolor="Black"
                                                    footerstyle-cssclass="text-center" datatextfield="SCAMOUNT" headertext="Sanctioned Amount in(Cr)">
                                                    <footerstyle horizontalalign="Center" font-underline="false" font-bold="true" cssclass="text-center" />
                                                    <itemstyle horizontalalign="Center" cssclass="text-center" />
                                                </asp:hyperlinkfield>
                                                <asp:boundfield headertext="No.of Units" datafield="STUNITS" />

                                                <asp:hyperlinkfield controlstyle-font-underline="false" controlstyle-forecolor="Blue"
                                                    footerstyle-cssclass="text-center" datatextfield="STCOUNT" headertext="No of Claims">
                                                    <footerstyle horizontalalign="Center" font-underline="false" font-bold="true" cssclass="text-center" />
                                                    <itemstyle horizontalalign="Center" cssclass="text-center" />
                                                </asp:hyperlinkfield>
                                                <asp:hyperlinkfield controlstyle-font-underline="false" controlstyle-forecolor="Black"
                                                    footerstyle-cssclass="text-center" datatextfield="STAMOUNT" headertext="Sanctioned Amount in(Cr)">
                                                    <footerstyle horizontalalign="Center" font-underline="false" font-bold="true" cssclass="text-center" />
                                                    <itemstyle horizontalalign="Center" cssclass="text-center" />
                                                </asp:hyperlinkfield>
                                                <asp:boundfield headertext="No.of Units" datafield="PHCUNITS" />

                                                <asp:hyperlinkfield controlstyle-font-underline="false" controlstyle-forecolor="Blue"
                                                    footerstyle-cssclass="text-center" datatextfield="PHCCOUNT" headertext="No of Claims">
                                                    <footerstyle horizontalalign="Center" font-underline="false" font-bold="true" cssclass="text-center" />
                                                    <itemstyle horizontalalign="Center" cssclass="text-center" />
                                                </asp:hyperlinkfield>
                                                <asp:hyperlinkfield controlstyle-font-underline="false" controlstyle-forecolor="Black"
                                                    footerstyle-cssclass="text-center" datatextfield="PHCAMOUNT" headertext="Sanctioned Amount in(Cr)">
                                                    <footerstyle horizontalalign="Center" font-underline="false" font-bold="true" cssclass="text-center" />
                                                    <itemstyle horizontalalign="Center" cssclass="text-center" />
                                                </asp:hyperlinkfield>
                                                <asp:boundfield headertext="No.of Units" datafield="TOTALUNITS" />
                                                <asp:hyperlinkfield controlstyle-font-underline="false" controlstyle-forecolor="Black"
                                                    footerstyle-cssclass="text-center" datatextfield="TOTALCLAIMS" headertext="No of Claims">
                                                    <footerstyle horizontalalign="Center" font-underline="false" font-bold="true" cssclass="text-center" />
                                                    <itemstyle horizontalalign="Center" cssclass="text-center" />
                                                </asp:hyperlinkfield>
                                                <asp:boundfield headertext="Sanctioned Amount in(Cr)" datafield="TOTALSANCTIONED" />
                                            </columns>
                                        </asp:gridview>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding: 5px; margin: 5px">
                                        <div id="success" runat="server" visible="false" class="alert alert-success">
                                            <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:label id="lblmsg" runat="server"></asp:label>
                                        </div>
                                        <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>
                                                Warning!</strong>
                                            <asp:label id="lblmsg0" runat="server"></asp:label>
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
</asp:content>

