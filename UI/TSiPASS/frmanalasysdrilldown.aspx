<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmanalasysdrilldown.aspx.cs" Inherits="UI_TSiPASS_frmanalasysdrilldown" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/frmAbstractanasisreport.aspx" Text="<< Back">
                                                    </asp:HyperLink>
                                            </td>
                                            
                                             
                                            <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                
                                            </td>
                                        </tr>
                                        
                                       
                                        <tr>
                                            <td class="col-xs-5" style="padding: 5px; text-align: left; margin: 5px" colspan="6">
                                                <asp:Label ID="Label1" Font-Bold="True" runat="server" Font-Size="16px" CssClass="LBLBLACK">Report as on date</asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="6" style="padding: 5px; margin: 5px">
                                    <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="18px"></asp:Label>
                                </td>
                            </tr>
                            <tr id="div_Print" runat="server">
                                <td align="center" style="text-align: center;" valign="top"> 
                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False"
                                        OnRowCreated="grdDetails_RowCreated" EnableModelValidation="True" CssClass="Grid" AlternatingRowStyle-CssClass="alt">
                                        <HeaderStyle Height="40px"  BackColor="#363670"  ForeColor="White"/>
                                        <FooterStyle Height="40px"  />
                                        <AlternatingRowStyle  />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Name of the Industry" HeaderText="Name of the Industry" ItemStyle-HorizontalAlign="Left"/>
                                            <asp:BoundField DataField="Approval Application Date" HeaderText="Approval Applied Date" />
                                            <asp:BoundField DataField="Appealed" HeaderText="Appealed (Y/N)" />
                                            <asp:BoundField DataField="Payment Date" HeaderText="Date of Payment" />
                                           
                                            <asp:BoundField DataField="Query Date" HeaderText="Date of Query" />
                                            <asp:BoundField DataField="Query Response Date" HeaderText="Date of Query Response" />
                                            <asp:BoundField DataField="PSC Completion_Rejection Date"
                                                HeaderText="Pre-Scrutiny Completion Date" />
                                          <%--  <asp:BoundField DataField="Query Description" HeaderText="Query Description">
                                                <ItemStyle Width="180px" />
                                            </asp:BoundField>--%>
                                            <asp:BoundField DataField="No of days taken for PSC excluding holidays" HeaderText="Number of days taken" />
                                            <asp:BoundField DataField="AdditionalPayment" HeaderText="Date of Additional Payment" />
                                          <%--  <asp:BoundField DataField="Payment Type" HeaderText="Payment Type" />
                                            <asp:BoundField DataField="Amount Paid" HeaderText="Amount Paid (Rs)" />--%>
                                            <asp:BoundField DataField="Date of Approval received to Approval Stage Max of payment or PSC date" HeaderText="Date Received to Approval Stage" />
                                            <asp:BoundField DataField="Actual Date of Approval Rejection" HeaderText="Date of Completion" />
                                            <asp:BoundField DataField="SLA_Approval No of days" HeaderText="SLA" />
                                            <asp:BoundField DataField="No of days taken for Approval excluding holidays" HeaderText="Number of days taken" />
                                            <asp:BoundField DataField="Status of Approval Approved Rejected" HeaderText="Status" />
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

