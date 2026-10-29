<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="FrmCommissionerReportDrillDown.aspx.cs" Inherits="UI_TSiPASS_FrmCommissionerReportDrillDown" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

        <%--<script type="text/javascript" src="../../js/jquery.min.js"></script>

    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>

    <script type="text/javascript" src="../../js/gridviewScroll.min.js"></script>--%>

  <script language="javascript" type="text/javascript">
      //      function pageLoad() {
      //          $('#<%=grdDetails.ClientID%>').gridviewScroll({
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
      //            $('#<%=grdDetails.ClientID%>').gridviewScroll({

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


    <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px;" valign="top"
                align="center">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading" style="text-align: center">
                            <h3 visible="false" id="Government" runat="server" class="panel-title" style="font-weight: bold;">Government of Telangana</h3>
                            <h2 id="H1" runat="server" class="panel-title" style="font-weight: bold;">
                                <asp:Label ID="lblHeader" runat="server">TSiPASS- Abstract Report </asp:Label>
                                <a id="Button2" href="#" onserverclick="BtnPDF_Click"
                                    runat="server">
                                    <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                        alt="PDF" /></a> <a id="A1" href="#" onserverclick="BtnSave2_Click1" runat="server">
                                            <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                                alt="Excel" /></a></h2>
                        </div>
                        <div class="panel-body">
                            <table align="center" cellpadding="10" cellspacing="5" style="width: 80%; font-family: 'Trebuchet MS'">

                                <tr>
                                    <td>
                                        <table runat="server" id="tblselection" cellpadding="4" cellspacing="5" style="width: 100%">
                                            <tr>
                                                <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/frmCommissionerReportDashboard.aspx"
                                                        Text="<< Back">
                                                    </asp:HyperLink>
                                                </td>
                                                <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            Year
                                                        </div>
                                                        <asp:DropDownList ID="ddlFinYear" runat="server" class="form-control txtbox" Height="33px"
                                                            Width="180px" Enabled="false">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td id="Td1" style="padding: 5px; margin: 5px" align="center" runat="server">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            District
                                                        </div>
                                                        <asp:DropDownList ID="ddlProp_intDistrictid" runat="server" class="form-control txtbox" Height="33px"
                                                            Width="180px" Enabled="false">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td id="Td2" style="padding: 5px; margin: 5px" runat="server">

                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            Pollution Category
                                                        </div>
                                                        <asp:DropDownList ID="ddlcolor" runat="server" class="form-control txtbox" Width="180px" Enabled="false">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <%-- <asp:ListItem>All</asp:ListItem>--%>
                                                            <asp:ListItem Value="R">Red</asp:ListItem>
                                                            <asp:ListItem Value="O">Orange</asp:ListItem>
                                                            <asp:ListItem Value="G">Green</asp:ListItem>
                                                            <asp:ListItem Value="W">White</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            Type of Enterprise
                                                        </div>
                                                        <asp:DropDownList ID="ddlEnterPriseType" runat="server" class="form-control txtbox" Width="180px" Enabled="false">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <%-- <asp:ListItem>All</asp:ListItem>--%>
                                                            <asp:ListItem Value="MIC">Micro</asp:ListItem>
                                                            <asp:ListItem Value="SML">Small</asp:ListItem>
                                                            <asp:ListItem Value="MED">Medium</asp:ListItem>
                                                            <asp:ListItem Value="LRG">Large</asp:ListItem>
                                                            <asp:ListItem Value="MEG">Mega</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            Sector
                                                        </div>
                                                        <asp:DropDownList ID="ddlsector" runat="server" class="form-control txtbox" Height="33px"
                                                            Width="180px" Enabled="false">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            Type of Enterprise
                                                        </div>
                                                        <asp:DropDownList ID="ddlSector_Ent" runat="server" class="form-control txtbox" Height="33px"
                                                            Width="180px" Enabled="false">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                
                                            </tr>
                                            <tr>
                                                <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            Industry Status
                                                        </div>
                                                        <asp:DropDownList ID="ddlStatus" runat="server" Width="220px" class="form-control txtbox"  Enabled="false">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem>COMMENCED OPERATIONS</asp:ListItem>
                                                            <asp:ListItem>YET TO START CONSTRUCTION</asp:ListItem>
                                                            <asp:ListItem>ADVANCED STAGE</asp:ListItem>
                                                            <asp:ListItem>INITIAL STAGE</asp:ListItem>
                                                            <asp:ListItem>DROPPED</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            Incentive Eligibility
                                                        </div>
                                                        <asp:DropDownList ID="ddlEligibility" runat="server" class="form-control txtbox" Height="33px"
                                                            Width="180px" Enabled="false">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem>YES</asp:ListItem>
                                                            <asp:ListItem>NO</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                 <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            Incentive Applied or not
                                                        </div>
                                                        <asp:DropDownList ID="ddlincentiveapplied" runat="server" class="form-control txtbox" Height="33px"
                                                            Width="180px" Enabled="false">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem>YES</asp:ListItem>
                                                            <asp:ListItem>NO</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td style="padding: 5px; margin: 5px" align="right">
                                                    <asp:Button ID="Button3" runat="server" CssClass="btn btn-default" TabIndex="10"
                                                        Text="Submit" OnClick="BtnSave1_Click" />
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
                                        <asp:GridView ID="grdDetails" CssClass="floatingTable" runat="server" AutoGenerateColumns="true" CellPadding="4"
                                            OnRowDataBound="grdDetails_RowDataBound" Width="100%" OnPageIndexChanging="grdDetails_PageIndexChanging"
                                            ShowFooter="True" OnRowCreated="grdDetails_RowCreated" OnSelectedIndexChanged="grdDetails_SelectedIndexChanged">
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
