<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="MonthwiseStatusrptDrill.aspx.cs" Inherits="UI_TSiPASS_MonthwiseStatusrptDrill" %>

 
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function GetRowValue(val) {
            if (val != '&nbsp;') {
                val1 = 0;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdfID').value = val;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdfFlagID').value = val1;

            }
            window.opener.document.forms[0].submit();
            self.close();

        }


        $(function () {

            $('#MstLftMenu').remove();

        });

    </script>

    <script language="javascript" type="text/javascript">
        function Panel1() {
            document.getElementById('<%=trFilter.ClientID %>').style.display = "none";
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
    </script>

    

    <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px;" valign="top"
                align="center">
                <div class="panel panel-default">
                    <div class="panel-heading" style="text-align: center">
                        <h3 class="panel-title" style="font-weight: bold;">
                            <asp:Label ID="lblHeading" runat="server">Month wise Applications</asp:Label>&nbsp; <a id="A1" href="#"
                                onserverclick="BtnPDF_Click" runat="server">
                                <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" /></a>
                            <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;" /></a></h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 95%; font-family: 'Trebuchet MS'">
                            <tr id="trFilter" runat="server">
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                       
                                        <tr>
                                            <%--<td align="right">--%>
                                                <%--<asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/IncentiveClaimsReport.aspx"
                                                    Text="<< Back">
                                                </asp:HyperLink>--%>
                                            <%--</td>--%>
                                            <td style="text-align:left">
                                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/MonthwiseStatusrpt.aspx" Text="<< Back">
                                                    </asp:HyperLink>
                                            </td>
                                            <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        Year
                                                    </div>
                                                   <asp:DropDownList ID="ddlFinancialYear" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="2017">2017</asp:ListItem>
                                                        <asp:ListItem Value="2016">2016</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        Month
                                                    </div>
                                                    <asp:DropDownList ID="ddlMonth" runat="server" class="form-control txtbox" Width="180px">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
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
                                             
                                            <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" align="center" colspan="6">
                                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-default" TabIndex="10"
                                                    Text="Submit" OnClick="BtnSave1_Click" />
                                               </td>
                                          
                                        </tr>
                                        <tr>
                                            <td class="col-xs-5" style="padding: 5px; text-align: left; margin: 5px" colspan="6">
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" align="left"></td>
                                            <td style="padding: 5px; margin: 5px" align="left" colspan="4"></td>
                                            <td></td>
                                        </tr>

                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="6" style="padding: 5px; margin: 5px">
                                    <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="13px"
                                        ForeColor="red"></asp:Label>
                                </td>
                            </tr>
                            <tr id="div_Print" runat="server">
                                <td align="center" style="text-align: center;" valign="top"> 
                                    <asp:GridView ID="grdDetails" CssClass="floatingTable" runat="server" AutoGenerateColumns="true" CellPadding="5"
                                            ShowFooter="True" Width="100%" EmptyDataText="No Results Found">
                                            <HeaderStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                            <RowStyle CssClass="GridviewScrollC1Item" />
                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                            <FooterStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                            <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1%>
                                                        <asp:HiddenField ID="HdfQueid" runat="server" />
                                                        <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                       <%-- <asp:HiddenField ID="HDFIncentiveID" runat="server" Value='<%# Eval("ENTERPERINCENTIVEID") %>' /> --%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                  <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="View">
                                                <ItemTemplate>
                                                   <asp:HyperLink CssClass="btn btn-link" ID="HyperLink2" runat="server" Text="View" Target="_blank" NavigateUrl='<%# Eval("ENTERPERINCENTIVEID", "IncetivesDraft.aspx?ENTERPERINCENTIVEID={0}") %>'>
                                                    </asp:HyperLink>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>--%>
                                            </Columns>
                                        </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" align="center" style="padding: 5px; margin: 5px">
                                    <div id="success" runat="server" class="alert alert-success" visible="false">
                                        <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">×</a> <strong></strong><asp:Label ID="Label2" runat="server"></asp:Label>
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
</asp:Content>
