<%@ page title="" language="C#" masterpagefile="~/UI/TSiPASS/CCMaster.master" autoeventwireup="true" codefile="frmIncentiveYearwiseDrilldown.aspx.cs" inherits="UI_TSiPASS_frmIncentiveYearwiseDrilldown" %>

<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        //      function pageLoad() {
      //          $('#<%=grdSanctioned.ClientID%>').gridviewScroll({
        //              width: "1024px",
        //              height: "100%",
        //              arrowsize: 30,
        //              varrowtopimg: "../../images/arrowvt.png",
        //              varrowbottomimg: "../../images/arrowvb.png",
        //              harrowleftimg: "../../images/arrowhl.png",
        //              harrowrightimg: "../../images/arrowhr.png"
        //          });
        //          //loadfirstRow();
        //      }
        //      function removescrolling() {
      //          $('#<%=divPrint.ClientID %>').addClass('removescroll');
      //            $('#<%=grdSanctioned.ClientID%>').gridviewScroll({

        //            });
        //        }

        function Panel1() {

            document.getElementById('<%=Button2.ClientID %>').style.display = "none";

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
    </script>

    <script language="javascript" type="text/javascript">
        function Panel2() {

            document.getElementById('<%=Button2.ClientID %>').style.display = "none";
            document.getElementById('<%=A1.ClientID %>').style.display = "none";
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

        $(function () {

            $('#MstLftMenu').remove();

        });


    </script>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");


            return false;
        }
    </script>
    <script type="text/javascript" language="javascript">
        var win = new Object();
        function Popup(intval) {

            win = window.open("ApplicationTrakerDetailed.aspx?UID=" + intval, "List", "scrollbars=yes,resizable=yes,width=780,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");
            //win = window.open("RptVillageOraganisationNameClickDetails.aspx?id="+intval, "List", "scrollbars=yes,resizable=yes,width=600,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");

        }
    </script>
    <script type="text/javascript" language="javascript">
        var win = new Object();
        function PopupCFO(intval) {

            win = window.open("ApplicationTrakerDetailedCFO.aspx?UID=" + intval, "List", "scrollbars=yes,resizable=yes,width=780,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");
            //win = window.open("RptVillageOraganisationNameClickDetails.aspx?id="+intval, "List", "scrollbars=yes,resizable=yes,width=600,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");

        }
    </script>
    <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px;" valign="top"
                align="center">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading" style="text-align: center">
                            <h3 visible="false" id="Government" runat="server" class="panel-title" style="font-weight: bold;">Government of Telangana</h3>
                            <h2 id="H1" runat="server" class="panel-title" style="font-weight: bold;">
                                <asp:label id="lblHeader" runat="server">R5.5 TSiPASS-SANCTIONED RELEASED FINANCIAL YEARWISE REPORT</asp:label>
                                <asp:label id="lbllabel" runat="server" visible="false"></asp:label>
                                <a id="Button2" href="#" onserverclick="Button2_ServerClick"
                                    runat="server">
                                    <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                        alt="PDF" /></a> <a id="A1" href="#" onserverclick="A1_ServerClick" runat="server">
                                            <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                                alt="Excel" /></a></h2>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <table align="center" cellpadding="10" cellspacing="5" style="width: 80%; font-family: 'Trebuchet MS'">

                        <tr>
                            <td>
                                <table runat="server" id="tblselection" cellpadding="4" cellspacing="5" style="width: 100%">
                                    <tr>
                                        <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                            <asp:hyperlink cssclass="btn btn-link" id="HyperLink1" runat="server" navigateurl="~/UI/TSiPASS/frmIncentives_Released_Yearwise.aspx"
                                                text="<< Back">
                                            </asp:hyperlink>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="padding: 5px; text-align: right; margin: 5px; width: 100%;"></td>
                        </tr>
                        <tr runat="server" visible="false" id="rptdate">
                            <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                <asp:label id="Label2" runat="server" cssclass="LBLBLACK"></asp:label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">Report as on date:
                                <asp:label id="Label1" runat="server" cssclass="LBLBLACK"></asp:label>
                            </td>
                        </tr>
                        <tr id="GridPrint" runat="server" visible="false">
                            <td colspan="2" align="center" style="padding: 5px; margin: 5px" id="divPrint1" runat="server">
                                <asp:gridview id="grdSanctioned" cssclass="floatingTable" runat="server" autogeneratecolumns="false" cellpadding="4"
                                    onrowdatabound="grdSanctioned_RowDataBound" width="100%" onpageindexchanging="grdSanctioned_PageIndexChanging"
                                    showfooter="True" onrowcreated="grdSanctioned_RowCreated" onselectedindexchanged="grdSanctioned_SelectedIndexChanged">
                                    <headerstyle height="40px" cssclass="GridviewScrollC1HeaderWrap" />
                                    <rowstyle cssclass="GridviewScrollC1Item" />
                                    <pagerstyle cssclass="GridviewScrollC1Pager" />
                                    <footerstyle height="40px" cssclass="GridviewScrollC1Header" />
                                    <alternatingrowstyle cssclass="GridviewScrollC1Item2" />
                                    <columns>
                                        <asp:templatefield headerstyle-horizontalalign="Center" headertext="SlNo">
                                            <itemtemplate>
                                                <%# Container.DataItemIndex +1 %>
                                            </itemtemplate>
                                            <headerstyle horizontalalign="Center" />
                                        </asp:templatefield>
                                        <asp:hyperlinkfield controlstyle-font-underline="false" controlstyle-forecolor="Black"
                                            footerstyle-cssclass="text-center" datatextfield="NAMEOFUNIT" headertext="NAME OF UNIT">
                                            <footerstyle horizontalalign="Center" font-underline="false" font-bold="true" cssclass="text-center" />
                                            <itemstyle horizontalalign="Center" cssclass="text-center" />
                                        </asp:hyperlinkfield>
                                        <asp:hyperlinkfield controlstyle-font-underline="false" controlstyle-forecolor="Black"
                                            footerstyle-cssclass="text-center" datatextfield="DISTRICT" headertext="DISTRICT">
                                            <footerstyle horizontalalign="Center" font-underline="false" font-bold="true" cssclass="text-center" />
                                            <itemstyle horizontalalign="Center" cssclass="text-center" />
                                        </asp:hyperlinkfield>
                                        <asp:hyperlinkfield controlstyle-font-underline="false" controlstyle-forecolor="Black"
                                            footerstyle-cssclass="text-center" datatextfield="MANDAL" headertext="MANDAL">
                                            <footerstyle horizontalalign="Center" font-underline="false" font-bold="true" cssclass="text-center" />
                                            <itemstyle horizontalalign="Center" cssclass="text-center" />
                                        </asp:hyperlinkfield>
                                        <asp:hyperlinkfield controlstyle-font-underline="false" controlstyle-forecolor="Black"
                                            footerstyle-cssclass="text-center" datatextfield="VILLAGE" headertext="VILLAGE">
                                            <footerstyle horizontalalign="Center" font-underline="false" font-bold="true" cssclass="text-center" />
                                            <itemstyle horizontalalign="Center" cssclass="text-center" />
                                        </asp:hyperlinkfield>
                                        <asp:hyperlinkfield controlstyle-font-underline="false" controlstyle-forecolor="Black"
                                            footerstyle-cssclass="text-center" datatextfield="SANCTIONEDDATE" headertext="SANCTIONED DATE">
                                            <footerstyle horizontalalign="Center" font-underline="false" font-bold="true" cssclass="text-center" />
                                            <itemstyle horizontalalign="Center" cssclass="text-center" />
                                        </asp:hyperlinkfield>
                                        <asp:hyperlinkfield controlstyle-font-underline="false" controlstyle-forecolor="Black"
                                            footerstyle-cssclass="text-center" datatextfield="SLCNUMBER" headertext="SLC NUMBER">
                                            <footerstyle horizontalalign="Center" font-underline="false" font-bold="true" cssclass="text-center" />
                                            <itemstyle horizontalalign="Center" cssclass="text-center" />
                                        </asp:hyperlinkfield>
                                        <asp:hyperlinkfield controlstyle-font-underline="false" controlstyle-forecolor="Black"
                                            footerstyle-cssclass="text-center" datatextfield="SANCTIONEDAMOUNT" headertext="SANCTIONED AMOUNT">
                                            <footerstyle horizontalalign="Center" font-underline="false" font-bold="true" cssclass="text-center" />
                                            <itemstyle horizontalalign="Center" cssclass="text-center" />
                                        </asp:hyperlinkfield>
                                        <asp:hyperlinkfield controlstyle-font-underline="false" controlstyle-forecolor="Black"
                                            footerstyle-cssclass="text-center" datatextfield="CASTE" headertext="CASTE">
                                            <footerstyle horizontalalign="Center" font-underline="false" font-bold="true" cssclass="text-center" />
                                            <itemstyle horizontalalign="Center" cssclass="text-center" />
                                        </asp:hyperlinkfield>
                                        <asp:hyperlinkfield controlstyle-font-underline="false" controlstyle-forecolor="Black"
                                            footerstyle-cssclass="text-center" datatextfield="ALLTYPE" headertext="SLC or DIPC">
                                            <footerstyle horizontalalign="Center" font-underline="false" font-bold="true" cssclass="text-center" />
                                            <itemstyle horizontalalign="Center" cssclass="text-center" />
                                        </asp:hyperlinkfield>
                                        <asp:hyperlinkfield controlstyle-font-underline="false" controlstyle-forecolor="Black"
                                            footerstyle-cssclass="text-center" datatextfield="INCENTIVEID" headertext="INCENTIVEID">
                                            <footerstyle horizontalalign="Center" font-underline="false" font-bold="true" cssclass="text-center" />
                                            <itemstyle horizontalalign="Center" cssclass="text-center" />
                                        </asp:hyperlinkfield>
                                        <asp:hyperlinkfield controlstyle-font-underline="false" controlstyle-forecolor="Black" visible="false"
                                            footerstyle-cssclass="text-center" datatextfield="MASTERINCEITIVEID" headertext="MASTERINCEITIVEID">
                                            <footerstyle horizontalalign="Center" font-underline="false" font-bold="true" cssclass="text-center" />
                                            <itemstyle horizontalalign="Center" cssclass="text-center" />
                                        </asp:hyperlinkfield>
                                        <asp:hyperlinkfield controlstyle-font-underline="false" controlstyle-forecolor="Black"
                                            footerstyle-cssclass="text-center" datatextfield="IncentiveName" headertext="Incentive Name">
                                            <footerstyle horizontalalign="Center" font-underline="false" font-bold="true" cssclass="text-center" />
                                            <itemstyle horizontalalign="Center" cssclass="text-center" />
                                        </asp:hyperlinkfield>
                                    </columns>
                                </asp:gridview>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center" style="padding: 5px; margin: 5px">
                <div id="success" runat="server" visible="false" class="alert alert-success">
                    <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:label id="lblmsg" runat="server"></asp:label>
                </div>
                <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                    <asp:label id="lblmsg0" runat="server"></asp:label>
                </div>
            </td>
        </tr>
    </table>
</asp:content>

