<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/CCMaster.master" CodeFile="frmIncentivePendencyHeadOfficeDrillDown.aspx.cs" Inherits="UI_TSiPASS_frmIncentivePendencyHeadOfficeDrillDown" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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


    <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px;" valign="top"
                align="center">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading" style="text-align: center">
                            <h3 visible="false" id="Government" runat="server" class="panel-title" style="font-weight: bold;">Government of Telangana</h3>
                            <h2 id="H1" runat="server" class="panel-title" style="font-weight: bold;">
                                <asp:Label ID="lblHeader" runat="server">R5.3 TSiPASS-INCENTIVES SANCTIONED FINANCIAL YEARWISE REPORT</asp:Label>
                                <asp:Label ID="lbllabel" runat="server" Visible="false"></asp:Label>
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
                                            <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/frmIncentives_Sanctioned_Yearwise.aspx"
                                                Text="<< Back">
                                            </asp:HyperLink>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="padding: 5px; text-align: right; margin: 5px; width: 100%;"></td>
                        </tr>
                        <tr runat="server" visible="false" id="rptdate">
                            <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: center; margin: 5px">
                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">Report as on date:
                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK"></asp:Label>
                            </td>
                        </tr>
                        <tr id="GridPrint" runat="server" visible="false"> <%--CssClass="floatingTable"--%>
                            <td colspan="2" style="padding: 5px; margin: 5px;" id="divPrint1" runat="server">
                                <asp:GridView ID="grdSanctioned"  runat="server" AutoGenerateColumns="true" 
                                    Width="100%" GridLines="None"    ShowFooter="True" HorizontalAlign="Center" >
                                    <HeaderStyle Height="40px" HorizontalAlign="Center" CssClass="GridviewScrollC1HeaderWrap" />
                                    <RowStyle CssClass="GridviewScrollC1Item" HorizontalAlign="Center" />
                                    <AlternatingRowStyle  HorizontalAlign="Center"  BackColor="LightGray" />
                                    <PagerStyle CssClass="GridviewScrollC1Pager" HorizontalAlign="Center" />

                                    <FooterStyle Height="40px" CssClass="GridviewScrollC1Header" />

                                    <Columns>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="SlNo">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex +1 %>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
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
</asp:Content>
