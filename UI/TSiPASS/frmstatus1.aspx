<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    EnableEventValidation="false" AutoEventWireup="true" CodeFile="frmstatus1.aspx.cs"
    Inherits="TSTBDCReg1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }



        $(function () {
            $('#MstLftMenu').remove();

        });

    </script>

    <script language="javascript" type="text/javascript">
        function Panel1() {

            var panel = document.getElementById("<%=divPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>Investment by District wise</title>');

            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();

            setTimeout(function() {
                printWindow.print();
                location.reload(true);
                printWindow.close();
            }, 1000);
            return false;

        }

        
    </script>

    <style>
        .algnRight
        {
            text-align: center;
        }
    </style>
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
            <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit"></i></li>
            <li class="active"><i class="fa fa-edit"></i><a href="#">CM's DASH BOARD - Investment
                by District wise</a> </li>
        </ol>
    </div>
    <div id="div_Print" runat="server" align="left">
        <div class="row" align="left">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title" style="font-weight: bold;">
                            Total Capital Investment by District wise&nbsp; <a id="A1" href="#" onclick="javascript:return Panel1();"
                                runat="server">
                                <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" /></a> <a id="A2" href="#" onserverclick="BtnSave2_Click1" runat="server">
                                        <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a></h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                            <%--<tr id="trBtns" runat="server">
                                               <td align="center" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/frmR1ReportKMR.aspx"
                                                        Text="Back">
                                                    </asp:HyperLink>
                                                </td>
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: right;">
                                                    <asp:Button ID="BtnSave2" runat="server" CssClass="btn btn-primary" Height="32px"
                                                        TabIndex="10" Text="Export" Width="90px" OnClick="BtnSave2_Click1" />
                                                    <asp:Button ID="BtnPDF" runat="server" CssClass="btn btn-warning" Height="32px" OnClientClick="return Panel1();"
                                                        TabIndex="10" Text="Print" Width="90px" />
                                                </td>
                                            </tr>--%>
                            <tr>
                                <td colspan="3" align="center" class="style8" style="padding: 5px; margin: 5px; text-align: right;"
                                    valign="top">
                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
                                </td>
                            </tr>
                             <tr>
                                                          <td>
                                                              <table style="width:100%">
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
                                                              </table>
                                                          </td>
                                                        </tr>
                            <tr>
                                <td align="left" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr id="divPrint" runat="server" style="width: 90%">
                                <td colspan="3" align="center" style="padding: 5px; margin: 5px; text-align: center;"
                                    valign="top">
                                    <asp:GridView ID="grdDetails" CssClass="floatingTable" runat="server" CellPadding="5" OnRowCreated="grdDetails_RowCreated"
                                        AutoGenerateColumns="false" ShowFooter="True" Width="100%" OnRowDataBound="grdDetails_RowDataBound">
                                        <HeaderStyle Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                        <PagerStyle Height="40px" CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                    <asp:HiddenField ID="HdfQueid" runat="server" />
                                                    <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="District Name" HeaderText="District Name">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:HyperLinkField DataTextField="MNo of Units" HeaderText="Units" ControlStyle-Font-Underline="false"
                                                ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:BoundField DataField="MTotal Investment" HeaderText="Total Investment (Rs

Crores)">
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:BoundField>
                                            <asp:HyperLinkField DataTextField="LNo of Units" HeaderText="Units" ControlStyle-Font-Underline="false"
                                                ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:BoundField DataField="LTotal Investment" HeaderText="Total Investment (Rs

Crores)">
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:BoundField>
                                            <asp:HyperLinkField DataTextField="MeNo of Units" HeaderText="Units"  ControlStyle-Font-Underline="false"
                                                ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:BoundField DataField="MeTotal Investment" HeaderText="Total Investment (Rs

Crores)">
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:BoundField>
                                            <asp:HyperLinkField DataTextField="SNo of Units" HeaderText="Units"  ControlStyle-Font-Underline="false"
                                                ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:BoundField DataField="STotal Investment" HeaderText="Total Investment (Rs

Crores)">
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:BoundField>
                                            <asp:HyperLinkField DataTextField="MiNo of Units" HeaderText="Units"  ControlStyle-Font-Underline="false"
                                                ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:BoundField DataField="MiTotal Investment" HeaderText="Total Investment (Rs

Crores)">
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:BoundField>
                                            <asp:HyperLinkField DataTextField="TNo of Units" HeaderText="Units"  ControlStyle-Font-Underline="false"
                                                ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:BoundField DataField="TTotal Investment" HeaderText="Total Investment (Rs

Crores)">
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center" style="padding: 5px; margin: 5px">
                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">
                                            &times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                    </div>
                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>
                                            Warning!</strong>
                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                        </table>
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
    </div>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>
