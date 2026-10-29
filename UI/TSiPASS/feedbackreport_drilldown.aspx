<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="feedbackreport_drilldown.aspx.cs" Inherits="UI_TSIPASS_feedbackreport_drilldown" %>

 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <script language="javascript" type="text/javascript">
        function Panel1() {
            document.getElementById('<%=A1.ClientID %>').style.display = "none";
            document.getElementById('<%=A2.ClientID %>').style.display = "none";
            var panel = document.getElementById("<%=grdDetails.ClientID %>");
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
        function Panel2() {
            document.getElementById('<%=A1.ClientID %>').style.display = "none";
            document.getElementById('<%=A2.ClientID %>').style.display = "none";
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
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <style type="text/css">
        .ui-datepicker
        {
            font-size: 8pt !important;
            padding: 0.2em 0.2em 0;
            width: 250px;
            color: Black;
            z-index: 9999 !important;
        }
        
        select
        {
            color: Black !important;
        }
    </style>
    <style>
        .algnCenter
        {
            text-align: center;
        }
    </style>
        <div class="col-lg-12">
        <div class="panel panel-default">
            <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%" >
                <tr>
                    <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px;" valign="top"
                        align="center">
                        <div class="panel-heading" style="text-align: center">
                <h3 class="panel-title" style="font-weight: bold;">
                    <asp:Label ID="Label1" runat="server">FEED BACK REPORT</asp:Label>&nbsp;&nbsp;::&nbsp;&nbsp;<asp:Label ID="lblheading" runat="server" Font-Bold="true"></asp:Label> 
                    </h3>
            </div>
                        
                         <div class="panel-heading" align="center">

                         <h3 class="panel-title" style="font-weight:bold;">
                        
                             <a id="A1" href="#" onserverclick="BtnPDF_Click" runat="server">
                        <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                            alt="PDF" /></a> <%--<a id="pdfPrint" href="#" onclick="javascript:return Panel1();"
                                runat="server">
                                <img src="../../Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                                    style="float: right;" /></a>--%> <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                        <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;" /></a>
                                        <a id="pdfPrint" href="#" onclick="javascript:return Panel2();"
                                                    runat="server">
                                                    <img src="../../Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                                                        style="float: right;" /></a>
                         </h3>
                    </div>
                        <div class="panel panel-default">
                         
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 50%; font-family: 'Trebuchet MS'">
                                    
                                    <tr>
                                        <td colspan="4" align="left">
                                            &nbsp;</td>
                                            <td  style="padding: 5px; text-align: right; margin: 5px" colspan="4">
                                            <b>
                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label></b>
                                        </td>
                </tr>

                <tr id="div_Print"  >
                    <td align="center" colspan="6" style="padding: 5px; margin: 5px">
                        <asp:GridView ID="grdDetails"  runat="server" AutoGenerateColumns="False"
                            CellPadding="4" Width="100%" 
                            ShowFooter="True" OnRowDataBound="grdDetails_RowDataBound">
                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                            <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                            <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                            <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex +1 %>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="20px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="UID_Number" HeaderText="UID No">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle CssClass="text-uppercase" />
                                </asp:BoundField>
                                  <asp:BoundField DataField="NameofIndustrialUnder" HeaderText="Unit Name">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle CssClass="text-uppercase" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Dept_Name" HeaderText="Department Name">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle CssClass="text-uppercase" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ApprovalName" HeaderText="Approval Name">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle CssClass="text-uppercase" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="ApprovalDate" HeaderText="Approval Date">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle CssClass="text-uppercase" />
                                </asp:BoundField>
                                  <asp:BoundField DataField="SuggestionRemarks" HeaderText="Suggestions/Remarks">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle CssClass="text-uppercase" />
                                </asp:BoundField>
                                 
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" align="center" style="padding: 5px; margin: 5px">
                        <div id="success" runat="server" class="alert alert-success" visible="false">
                            <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:Label ID="Label2" runat="server"></asp:Label>
                        </div>
                        <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                            <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </td>
                </tr>
            </table>
        </div>
    </div>
    </asp:Content>