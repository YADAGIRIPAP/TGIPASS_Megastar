<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="RankingTool.aspx.cs" Inherits="UI_TSiPASS_RankingTool" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <style type="text/css">
        .overlay {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 112px;
            background-color: Gray;
            filter: alpha(opacity=60);
            opacity: 0.9;
            -moz-opacity: 0.9;
        }

        .style8 {
            color: #FF0000;
            font-weight: bold;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("rptR1Print.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <script language="javascript" type="text/javascript">
        function Panel1() {

            document.getElementById('<%=Button2.ClientID %>').style.display = "none";
            document.getElementById('<%=btnGet.ClientID %>').style.display = "none";

            var panel = document.getElementById("<%=divPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=500,width=800');
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


    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title" style="font-weight: bold">
                            <asp:Label ID="lblHeading" runat="server"></asp:Label>
                            &nbsp; <a id="Button2" href="#" onclick="javascript:return Panel1();"
                                runat="server">
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
                        <table id="divPrint" runat="server" border="0" cellpadding="10" cellspacing="5" style="width: 100%">
                            <%-- <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top" class="style8"
                                                    align="center">
                                                    <asp:DropDownList ID="ddlProp_intDistrictid" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                        Height="33px" OnSelectedIndexChanged="ddlProp_intDistrictid_SelectedIndexChanged"
                                                        Width="180px" Visible="False">
                                                        <asp:ListItem>--District--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="padding: 5px; margin: 5px; text-align: right; vertical-align: top;"
                                                    valign="top">
                                                    <asp:ImageButton ID="Image4" Visible="false" runat="server" Height="40px" ImageUrl="~/images/pdf-icon4.jpg"
                                                        OnClientClick="window.print();return false" Width="40px" />
                                                    &nbsp;&nbsp; <a onclick="javascript:return OpenPopup()">
                                                        <asp:ImageButton ID="ImageButton1" runat="server" Height="40px" ImageUrl="~/images/printimage.jpg"
                                                            Width="40px" /></a> &nbsp;
                                                </td>
                                            </tr>--%>
                            <tr>
                                <td>
                                    <div id="PrintPDF" runat="server">
                                        <table width="100%" style="font-family: 'Trebuchet MS'">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" align="left">
                                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboardNew.aspx" Text="<< Back">
                                                    </asp:HyperLink>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: right;" valign="top">
                                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table width="100%">

                                                        <tr>
                                                            <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                                <div class="input-group">
                                                                    <div class="input-group-addon">
                                                                        Type
                                                                    </div>
                                                                    <asp:DropDownList ID="ddlinvestment" runat="server" class="form-control txtbox" Height="33px"
                                                                        Width="180px">
                                                                        <asp:ListItem Value="1">ALL</asp:ListItem>
                                                                        <asp:ListItem Value="2">Department - Wise</asp:ListItem>
                                                                        <%--<asp:ListItem Value="3">District- Wise</asp:ListItem>--%>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">From Date:   
                                                
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                                </cc1:CalendarExtender>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">To Date:  
                                            
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                                                </cc1:CalendarExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px" align="left"></td>
                                                            <td style="padding: 5px; margin: 5px" align="left" colspan="3"></td>
                                                            <td></td>
                                                            <td></td>
                                                        </tr>
                                                        <tr align="center">
                                                            <td style="padding: 5px; margin: 5px" colspan="8" align="center">
                                                                <asp:Button ID="btnGet" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Generate Report" Width="180px" OnClick="btnGet_Click" />

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px" align="left"></td>
                                                            <td style="padding: 5px; margin: 5px" align="left" colspan="3"></td>
                                                            <td></td>
                                                            <td></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="div_Print">
                                                <td colspan="2" style="padding: 5px;" valign="top">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td colspan="2" style="padding: 10px; margin: 5px; text-align: center; font-weight: bold;">
                                                                <asp:Label ID="Label12" Font-Size="Large" runat="server">RANKING of DEPTs - TSiPASS</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="padding: 10px; margin: 5px; text-align: center; font-weight: bold;">
                                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK"></asp:Label>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td colspan="2" style="padding: 5px;" valign="top">
                                                                <%-- <table border="solid" style="width: 100%; border: 1px solid #929090;">
                                <tr style="background-color: #286090;">
                                    <td colspan="2" style="padding: 10px; margin: 5px; text-align: center; color: White; font-weight: bold;">
                                        <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK">AT A GLANCE REPORT</asp:Label>
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: center; color: White; font-weight: bold; width: 120px">
                                        <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: center; color: White; font-weight: bold; width: 120px">
                                        <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK">Cumulative(Since Jan-2015)</asp:Label>
                                    </td>

                                </tr>
                                <tr>
                                    <td style="padding: 10px; margin: 5px; text-align: left;">1
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: right;">
                                        <asp:Label ID="lblnumber1617" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: right;">
                                        <asp:Label ID="lblnumber" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>

                                </tr>
                                <tr>
                                    <td style="padding: 10px; margin: 5px; text-align: left;">2
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK">Investment (Rs. in Crores)</asp:Label>
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: right;">
                                        <asp:Label ID="lblInv1617" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: right;">
                                        <asp:Label ID="lblinv" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>

                                </tr>
                                <tr>
                                    <td style="padding: 10px; margin: 5px; text-align: left;">3
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK">Employment</asp:Label>
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: right;">
                                        <asp:Label ID="lblem1617" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: right;">
                                        <asp:Label ID="lblEmp" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>

                                </tr>
                                <tr>
                                    <td style="padding: 10px; margin: 5px; text-align: left;">4
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK">Number of Industries - Commenced Operations</asp:Label>
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: right;">
                                        <asp:Label ID="lblCom1617" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: right;">
                                        <asp:Label ID="lblCO" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>

                                </tr>
                                <tr>
                                    <td style="padding: 10px; margin: 5px; text-align: left;">5
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK">Number of Industries - Advanced Stage</asp:Label>
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: right;">
                                        <asp:Label ID="lblads1617" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: right;">
                                        <asp:Label ID="lblas" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>

                                </tr>
                                <tr>
                                    <td style="padding: 10px; margin: 5px; text-align: left;">6
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK">Number of Industries - Initial Stage</asp:Label>
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: right;">
                                        <asp:Label ID="lblIns1617" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: right;">
                                        <asp:Label ID="lblis" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>

                                </tr>
                                <tr>
                                    <td style="padding: 10px; margin: 5px; text-align: left;">7
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK">Number of Industries - Yet to Start Construction</asp:Label>
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: right;">
                                        <asp:Label ID="lblYet1617" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>
                                    <td style="padding: 10px; margin: 5px; text-align: right;">
                                        <asp:Label ID="lblyet" Font-Bold="true" runat="server" CssClass="LBLBLACK"></asp:Label>
                                    </td>

                                </tr>
                            </table>--%>

                                                                <asp:GridView ID="grdDetails" CssClass="floatingTable" runat="server" AutoGenerateColumns="true" CellPadding="5"
                                                                    ShowFooter="True" Width="100%">
                                                                    <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="50px" CssClass="GridviewScrollC1HeaderWrap" Font-Bold="true" />
                                                                    <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                    <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                                                    <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                                    <Columns>
                                                                    </Columns>
                                                                    <RowStyle Wrap="true" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr1" runat="server" visible="false">
                                                <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                                    <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="5" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">

                                                    <div id="success" style="width: 100%" runat="server" visible="false" class="alert alert-success">
                                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                                        <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                    </div>


                                                    <div id="Failure" style="width: 100%" runat="server" visible="false" class="alert alert-danger">
                                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                                        <strong>Warning!</strong>
                                                        <asp:Label ID="lblError" runat="server"></asp:Label>
                                                    </div>
                                                </td>

                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <asp:HiddenField ID="hdfID" runat="server" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                        ShowSummary="False" ValidationGroup="group" />
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                        ShowSummary="False" ValidationGroup="child" />
                    <asp:HiddenField ID="hdfFlagID" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

