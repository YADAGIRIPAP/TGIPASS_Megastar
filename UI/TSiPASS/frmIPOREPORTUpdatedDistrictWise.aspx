<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmIPOREPORTUpdatedDistrictWise.aspx.cs" Inherits="UI_TSiPASS_frmIPOREPORTUpdatedDistrictWise" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%--<script type="text/javascript" src="../../js/jquery.min.js"></script>

    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>

    <script type="text/javascript" src="../../js/gridviewScroll.min.js"></script>--%>

   <%-- <script language="javascript" type="text/javascript">
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
            document.getElementById('<%=Button1.ClientID %>').style.display = "none";
            document.getElementById('<%=Button2.ClientID %>').style.display = "none";
            document.getElementById('<%=GraphPrint.ClientID %>').style.display = "none";
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


    </script>--%>
    <script language="javascript" type="text/javascript">
        function Panel3() {
            document.getElementById('<%=pdfPrint.ClientID %>').style.display = "none";
           
            var panel = document.getElementById("<%=divPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>newTable</title>');

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
    <%--<script language="javascript" type="text/javascript">
        function Panel2() {
            document.getElementById('<%=Button1.ClientID %>').style.display = "none";
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
    </script>
--%>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading" style="text-align: center">
                            <h3 visible="false" id="Government" runat="server" class="panel-title" style="font-weight: bold;">Government of Telangana</h3>
                            <h3 id="H1" runat="server" class="panel-title" style="font-weight: bold;">
                                <asp:Label ID="lblHeading" runat="server"> TSiPASS- District Wise IPO Report </asp:Label>
                                <a id="Button2" href="#" onserverclick="BtnPDF_Click"
                                    runat="server">
                                    <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                        alt="PDF" /></a> <a id="Button1" href="#" onserverclick="BtnSave2_Click" runat="server">
                                            <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                                alt="Excel" /></a>
                                                <a id="pdfPrint" href="#" onclick="javascript:return Panel3();"
                                                    runat="server">
                                                    <img src="../../Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                                                        style="float: right;" /></a></h3>
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
                                                <td id="Td1" class="col-xs-3" style="padding: 5px; margin: 5px" runat="server" visible="false">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            Year
                                                        </div>
                                                        <asp:DropDownList ID="ddlType" runat="server" class="form-control txtbox" Height="33px"
                                                            Width="180px" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" AutoPostBack="true" Visible="false">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <%--<asp:ListItem Value="1">Cumulative</asp:ListItem>--%>
                                                            <%--<asp:ListItem Value="2">2015-16</asp:ListItem>--%>
                                                            <asp:ListItem Value="3">2016-17</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>

                                                 <td style="padding: 5px; margin: 5px" align="center" runat="server" id="td2">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            Year
                                                        </div>
                                                          <asp:DropDownList ID="ddlYear"  runat="server" class="form-control txtbox" Height="33px"
                                                             TabIndex="4"
                                                            Width="180px" AutoPostBack="True">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                       
                                                    </div>
                                                </td>
                                                <td style="padding: 5px; margin: 5px" runat="server" id="td3">

                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            Month
                                                        </div>
                                                        <asp:DropDownList ID="ddlmonth" runat="server" class="form-control txtbox" TabIndex="3"
                                                            Height="33px" Width="180px" AutoPostBack="True" 
                                                            >
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem Value="1">January</asp:ListItem>
                                                            <asp:ListItem Value="2">February</asp:ListItem>
                                                            <asp:ListItem Value="3">March</asp:ListItem>
                                                            <asp:ListItem Value="4">April</asp:ListItem>
                                                            <asp:ListItem Value="5">May</asp:ListItem>
                                                            <asp:ListItem Value="6">June</asp:ListItem>
                                                            <asp:ListItem Value="7">July</asp:ListItem>
                                                            <asp:ListItem Value="8">August</asp:ListItem>
                                                            <asp:ListItem Value="9">September</asp:ListItem>
                                                            <asp:ListItem Value="10">October</asp:ListItem>
                                                            <asp:ListItem Value="11">November</asp:ListItem>
                                                            <asp:ListItem Value="12">December</asp:ListItem>
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
                                                <td id="Td4" class="col-xs-3" style="padding: 5px; margin: 5px" runat="server" visible="false">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            District
                                                        </div>
                                                         <asp:DropDownList ID="ddlProp_intDistrictid" runat="server" AutoPostBack="True" 
                                                                    class="form-control txtbox" Height="33px" TabIndex="1" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td id="Td5" style="padding: 5px; margin: 5px" align="right" runat="server">
                                                    <asp:Button ID="Button3" runat="server" CssClass="btn btn-default" TabIndex="10"
                                                        Text="Submit" OnClick="BtnSave1_Click" />
                                                </td>
                                                <td class="col-xs-3" style="padding: 5px; text-align: right; margin: 5px" colspan="3">
                                            <b>
                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label></b>
                                        </td>
                                            </tr>

                                        </table>
                                    </td>
                                    <td style="padding: 5px; text-align: right; margin: 5px; width: 100%;"></td>
                                </tr>
                                <tr runat="server" id="rptdate" visible="false">
                                    <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                        <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                        <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                        <asp:Button ID="btnNewPdf" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Generate Pdf" OnClick="btnNewPdf_Click" Visible="false" />
                                    </td>
                                </tr>
                                <tr id="GridPrint" runat="server">
                                    <td colspan="2" align="center" style="padding: 5px; margin: 5px" id="divPrint1" runat="server">
                                        <asp:GridView ID="grdDetails"  runat="server" AutoGenerateColumns="False" CellPadding="4"
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
                                                <asp:BoundField DataField="DISTRICT" HeaderText="District">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle CssClass="text-uppercase" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="DISTRICTID" HeaderText="DistrictID" Visible="false">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle CssClass="text-uppercase" />
                                                </asp:BoundField>
                                                <%--<asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="IPOREPORTNOTUPDATED" HeaderText="Monthly IPO Report Not Updated">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>--%>
                                                <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="IPOREPORTUPDATED" HeaderText="Monthly IPO Report Updated">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <%--<asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="ADREPORTNOTUPDATED" HeaderText="Monthly AD Report Not Updated">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>--%>
                                                <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="ADREPORTUPDATED" HeaderText="Monthly AD Report Updated">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <%--<asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="DDREPORTNOTUPDATED" HeaderText="Monthly DD Report Not Updated">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>--%>
                                                <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="DDREPORTUPDATED" HeaderText="Monthly DD Report Updated">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <%--<asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="TOTALNNOTUPDATED" HeaderText="Salary Not Yet Processed">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>--%>
                                                <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                                    FooterStyle-CssClass="text-center" DataTextField="TOTALUPDATED" HeaderText="Salary Processed">
                                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr id="GraphPrint" runat="server">
                                    <td id="Td6" colspan="2" align="center" style="padding: 5px; margin: 5px" runat="server" visible="false">
                                        <a id="A1" href="#" onclick="javascript:return Panel2();" runat="server">
                                            <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                                alt="PDF" /></a>
                                        <div>
                                            <br />
                                            <br />

                                            <script type="text/javascript" src="../../js/googleapi.js"></script>

                                            <asp:Literal ID="ltrPie" runat="server"></asp:Literal>
                                          <%--  <div id="piechart_3d" style="border-style: solid; border-width: 1px; width: 100%; height: 600px;">
                                            </div>--%>
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
                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
