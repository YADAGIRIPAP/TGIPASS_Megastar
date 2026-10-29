<%@ page title="" language="C#" masterpagefile="~/UI/TSIPASS/CCMaster.master" autoeventwireup="true" codefile="frmrptGlance2Newfin.aspx.cs" enableeventvalidation="false" inherits="UI_TSIPASS_frmrptGlance2Newfin" %>

<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function Panel1() {

            document.getElementById('<%=Button2.ClientID %>').style.display = "none";
            document.getElementById('<%=tblselection.ClientID %>').style.display = "none";

            var panel = document.getElementById("<%=TRGRID.ClientID %>");
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
    <style>
        .GridviewScrollC1Header TH, .GridviewScrollC1Header TD {
            vertical-align: middle !important;
        }
    </style>
    <style>
        .width {
            width: 100%;
        }
    </style>
    <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <div class="panel panel-default" style="font-family: Helvetica Neue, Helvetica, Arial, sans-serif; font-size: 16px; line-height: 1.42857143;">
                    <div class="panel-heading" style="text-align: center">
                        <h3 visible="false" id="Government" runat="server" class="panel-title" style="font-weight: bold;">Government of Telangana</h3>
                        <h2 class="panel-title" style="font-weight: bold;">
                            <asp:label id="lblHeading" runat="server">Glance Report-Year Wise Abstract</asp:label>
                            <a id="btnPrnt" href="#" onclick="javascript:return Panel1();" runat="server">
                                <%--<asp:Button ID="Button1" runat="server" Text="Print" OnClientClick="doPrint()" />--%>
                                <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/pdf-printer-icon.jpg" width="30px;" height="40px;" style="float: right;"
                                    alt="PDF" /></a>
                            <a id="Button2" href="#" onclick="javascript:return Panel1();"
                                runat="server">
                                <%--<img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" />--%></a>
                            <%--<a id="Button1" href="#" onserverclick="BtnSave2_Click" runat="server">
                                        <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a>--%>
                            <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="Excel" /></a>
                        </h2>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 50%; font-family: 'Trebuchet MS'">
                            <tr>
                                <td>
                                    <table runat="server" id="tblselection" cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                <asp:hyperlink cssclass="btn btn-link" id="BtnBack" runat="server" navigateurl="~/UI/TSiPASS/ReportsDashboardNew.aspx"
                                                    text="<< Back">
                                                </asp:hyperlink>
                                            </td>
                                            <td class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px" colspan="5">
                                                <b>
                                                    <asp:label id="Label3" runat="server" cssclass="LBLBLACK">Report as on date</asp:label></b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px"></td>
                            </tr>
                            <tr runat="server" id="div_Print">
                                <td colspan="2" style="padding: 5px;" valign="top">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td colspan="2" style="padding: 10px; margin: 5px; text-align: center; font-weight: bold;">
                                                <asp:label id="Label12" font-size="Large" runat="server">Glance Report-Year Wise Abstract </asp:label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding: 10px; margin: 5px; text-align: right; font-weight: bold;">
                                                <asp:button id="btnbdf" runat="server" cssclass="btn btn-primary" height="32px" tabindex="10" text="Generate Pdf" onclick="btnbdf_Click" />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding: 10px; margin: 5px; text-align: center; font-weight: bold;">
                                                <asp:label id="Label1" runat="server" cssclass="LBLBLACK"></asp:label>
                                            </td>
                                        </tr>

                                        <tr id="TRGRID" runat="server">
                                            <td colspan="2" style="padding: 5px;" valign="top">

                                                <asp:gridview id="grdDetails" runat="server" autogeneratecolumns="false" cellpadding="5"
                                                    showfooter="false" width="100%" onrowcreated="grdDetails_RowCreated">
                                                    <headerstyle forecolor="#FFFFFF" backcolor="#009688" height="50px" cssclass="GridviewScrollC1HeaderWrap" font-bold="true" />
                                                    <rowstyle height="40px" cssclass="GridviewScrollC1Item" />
                                                    <pagerstyle cssclass="GridviewScrollC1Pager" />
                                                    <footerstyle forecolor="#FFFFFF" backcolor="#009688" height="40px" cssclass="GridviewScrollC1Footer" />
                                                    <alternatingrowstyle height="40px" cssclass="GridviewScrollC1Item2" />

                                                    <rowstyle wrap="true" />
                                                    <columns>
                                                        <asp:templatefield headerstyle-horizontalalign="Center" headertext="S.No">
                                                            <itemtemplate>
                                                                <%# Container.DataItemIndex +1 %>
                                                            </itemtemplate>
                                                            <headerstyle horizontalalign="Center" />
                                                        </asp:templatefield>
                                                        <asp:boundfield datafield="Particulars" headertext="Particulars"></asp:boundfield>
                                                        <asp:boundfield headertext="Live Units" datafield="2014 - 2015 WORKING"></asp:boundfield>
                                                        <asp:boundfield headertext="Dropped Units" datafield="2014 - 2015 DROP"></asp:boundfield>
                                                        <asp:boundfield headertext="Live Units" datafield="2015 - 2016 WORKING"></asp:boundfield>
                                                        <asp:boundfield headertext="Dropped Units" datafield="2015 - 2016 DROP"></asp:boundfield>
                                                        <asp:boundfield headertext="Live Units" datafield="2016 - 2017 WORKING"></asp:boundfield>
                                                        <asp:boundfield headertext="Dropped Units" datafield="2016 - 2017 DROP"></asp:boundfield>
                                                        <asp:boundfield headertext="Live Units" datafield="2017 - 2018 WORKING"></asp:boundfield>
                                                        <asp:boundfield headertext="Dropped Units" datafield="2017 - 2018 DROP"></asp:boundfield>
                                                        <asp:boundfield headertext="Live Units" datafield="2018 - 2019 WORKING"></asp:boundfield>
                                                        <asp:boundfield headertext="Dropped Units" datafield="2018 - 2019 DROP"></asp:boundfield>
                                                        <asp:boundfield headertext="Live Units" datafield="2019 - 2020 WORKING"></asp:boundfield>
                                                        <asp:boundfield headertext="Dropped Units" datafield="2019 - 2020 DROP"></asp:boundfield>
                                                        <asp:boundfield headertext="Live Units" datafield="2020 - 2021 WORKING"></asp:boundfield>
                                                        <asp:boundfield headertext="Dropped Units" datafield="2020 - 2021 DROP"></asp:boundfield>

                                                        <asp:boundfield headertext="Live Units" datafield="2021 - 2022 WORKING"></asp:boundfield>
                                                        <asp:boundfield headertext="Dropped Units" datafield="2021 - 2022 DROP"></asp:boundfield>
                                                        <asp:boundfield headertext="Live Units" datafield="2022 - 2023 WORKING"></asp:boundfield>
                                                        <asp:boundfield headertext="Dropped Units" datafield="2022 - 2023 DROP"></asp:boundfield>
                                                        <asp:boundfield headertext="Live Units" datafield="2023 - 2024 WORKING"></asp:boundfield>
                                                        <asp:boundfield headertext="Dropped Units" datafield="2023 - 2024 DROP"></asp:boundfield>

                                                        <asp:boundfield headertext="Live Units" datafield="2024 - 2025 WORKING"></asp:boundfield>
                                                        <asp:boundfield headertext="Dropped Units" datafield="2024 - 2025 DROP"></asp:boundfield>
                                                        <asp:boundfield headertext="Live Units" datafield="2025 - 2026 WORKING"></asp:boundfield>
                                                        <asp:boundfield headertext="Dropped Units" datafield="2025 - 2026 DROP"></asp:boundfield>
                                                        <asp:boundfield headertext="Live Units" datafield="2026 - 2027 WORKING"></asp:boundfield>
                                                        <asp:boundfield headertext="Dropped Units" datafield="2026 - 2027 DROP"></asp:boundfield>

                                                        <asp:boundfield headertext="Live Units" datafield="Cumulative(Since Jan-2015) WORKING"></asp:boundfield>
                                                        <asp:boundfield headertext="Dropped Units" datafield="Cumulative(Since Jan-2015) DROP"></asp:boundfield>
                                                    </columns>
                                                </asp:gridview>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="Tr1" runat="server">
                                <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                    <asp:label id="Label2" runat="server" visible="false" cssclass="LBLBLACK"></asp:label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">

                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                        <strong>Success!</strong><asp:label id="lblmsg" runat="server"></asp:label>
                                    </div>


                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                        <strong>Warning!</strong>
                                        <asp:label id="lblError" runat="server"></asp:label>
                                    </div>
                                </td>

                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center" style="padding: 5px; margin: 5px">&nbsp;
            </td>
        </tr>
    </table>

    <style>
        .GridviewScrollC1Header TH, .GridviewScrollC1Header TD {
            vertical-align: middle !important;
        }

        .GridviewScrollC1HeaderWrap TH, .GridviewScrollC1HeaderWrap TD {
            vertical-align: middle !important;
            text-align: center !important;
        }
    </style>
</asp:content>

