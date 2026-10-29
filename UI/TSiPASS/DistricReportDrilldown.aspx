<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="DistricReportDrilldown.aspx.cs" Inherits="UI_TSiPASS_Report_PageDrilldown" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <script language="javascript" type="text/javascript">
//      function pageLoad() {
//          $('#<%=grdReports.ClientID%>').gridviewScroll({
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
//            $('#<%=grdReports.ClientID%>').gridviewScroll({

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

              window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1500,height=950;display = block;position=absolute");


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


    <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px;" valign="top"
                align="center">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading" style="text-align: center">
                            <h3 visible="false" id="Government" runat="server" class="panel-title" style="font-weight: bold;">Government of Telangana</h3>
                            <h2 id="H1" runat="server" class="panel-title" style="font-weight: bold;">
                                <asp:Label ID="lblHeader" runat="server">R6.11: TGiPASS-Distric Report: </asp:Label>
                                <asp:Label ID="LblGet" runat="server" Visible="false"></asp:Label>
                                <a id="Button2" href="#" onserverclick="Button2_ServerClick"
                                    runat="server">
                                    <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                        alt="PDF" /></a> <a id="A1" href="#" onserverclick="A1_ServerClick" runat="server">
                                            <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                                alt="Excel" /></a></h2>
                        </div>
                        <div class="panel-body">
                            <table align="center" cellpadding="10" cellspacing="5" style="width: 80%; font-family: 'Trebuchet MS'">

                                <tr>
                                    <td>
                                        <table runat="server" id="tblselection" cellpadding="4" cellspacing="5" style="width: 100%">
                                            <tr>
                                                <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/DistricReport.aspx"
                                                        Text="<< Back">
                                                    </asp:HyperLink>
                                                </td>
                                          <td class="col-xs-3" style="padding: 5px; margin: 5px" id="ddtype" runat="server" visible="false">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            Type
                                                        </div>
                                                        <asp:DropDownList ID="ddlType" runat="server" class="form-control txtbox" Height="33px"
                                                            Width="180px" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem>--Select--</asp:ListItem>                                                    
                                                            <asp:ListItem Value="3">2016-17</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td style="padding: 5px; margin: 5px" align="center" runat="server" id="tdFromDate" visible="false">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            From Date
                                                        </div>

                                                        <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                        </cc1:CalendarExtender>
                                                    </div>
                                                </td>
                                                <td style="padding: 5px; margin: 5px" runat="server" id="tdToDate" visible="false">

                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            To Date
                                                        </div>
                                                        <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                                        </cc1:CalendarExtender>
                                                    </div>
                                                </td>                                             
                                            </tr>

                                        </table>
                                    </td>
                                    <td style="padding: 5px; text-align: right; margin: 5px; width: 100%;"></td>
                                </tr>
                                <tr runat="server" visible="false" id="rptdate">
                                    <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                        <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                        <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
                                    </td>
                                </tr>
                                 <tr id="GridPrint" runat="server">
                                    <td colspan="2" align="center" style="padding: 5px; margin: 5px" id="divPrint1" runat="server">
                                        <asp:GridView ID="grdReports" CssClass="floatingTable" runat="server" AutoGenerateColumns="false" CellPadding="4"
                                            OnRowDataBound="grdReports_RowDataBound" Width="100%" OnPageIndexChanging="grdReports_PageIndexChanging"
                                            ShowFooter="True" OnRowCreated="grdReports_RowCreated" OnSelectedIndexChanged="grdReports_SelectedIndexChanged">
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
                                                  <asp:TemplateField HeaderText="View">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1"  runat="server" Text='<%# Eval("intQuessionaireid") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                                 <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                            FooterStyle-CssClass="text-center" DataTextField="intQuessionaireid" HeaderText="intQuessionaire id">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>
                                                 <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                            FooterStyle-CssClass="text-center" DataTextField="UID_No" HeaderText="UID NO">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>
                                                 <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                            FooterStyle-CssClass="text-center" DataTextField="NameofIndustry" HeaderText="Name of Industry">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>
                                                 <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                            FooterStyle-CssClass="text-center" DataTextField="District" HeaderText="District">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>
                                                      <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                            FooterStyle-CssClass="text-center" DataTextField="Address" HeaderText="Address">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>
                                                 <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                            FooterStyle-CssClass="text-center" DataTextField="lineofActivity" HeaderText="Line of Activity">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>
                                                 <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                            FooterStyle-CssClass="text-center" DataTextField="Sector" HeaderText="Sector">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>
                                                      <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                            FooterStyle-CssClass="text-center" DataTextField="Investment" HeaderText="Investment">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>
                                                <%-- <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                            FooterStyle-CssClass="text-center" DataTextField="Male" HeaderText="Male">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>--%>
                                                <%-- <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                            FooterStyle-CssClass="text-center" DataTextField="Female" HeaderText="Female">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>--%>
                                                      <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                            FooterStyle-CssClass="text-center" DataTextField="Employment" HeaderText="Employment">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>
                                                 <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                            FooterStyle-CssClass="text-center" DataTextField="ApplicationDate" HeaderText="ApplicationDate">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>
                                                 <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                            FooterStyle-CssClass="text-center" DataTextField="ApprovalDate" HeaderText="ApprovalDate">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>
                                                      <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                            FooterStyle-CssClass="text-center" DataTextField="Progress" HeaderText="Progress">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>
                                                 <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                            FooterStyle-CssClass="text-center" DataTextField="Is_online" HeaderText="IsOnline">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>
                                                 <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                            FooterStyle-CssClass="text-center" DataTextField="SocialStatus" HeaderText="SocialStatus">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>
                                                  <asp:BoundField DataField="Dept_Full_name" HeaderText="Department name" Visible="true">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle CssClass="text-uppercase" />
                                                </asp:BoundField>
                                                  <asp:BoundField DataField="ApprovalName" HeaderText="Approval Name" Visible="true">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle CssClass="text-uppercase" />
                                                </asp:BoundField>
                                                
                                            </Columns>
                                        </asp:GridView>
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
                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

