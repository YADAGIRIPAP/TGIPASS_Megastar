<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSIPASS/CCMaster.master" AutoEventWireup="true" CodeFile="IncentiveQueryReport.aspx.cs" Inherits="UI_TSIPASS_IncentiveQueryReport" %>

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
    </script>

    <script language="javascript" type="text/javascript">
        function Panel1() {

            <%--document.getElementById('<%=A1.ClientID %>').style.display = "none";--%>
            document.getElementById('<%=A2.ClientID %>').style.display = "none";
            <%--document.getElementById('<%=trFilter.ClientID %>').style.display = "none";--%>

            var panel = document.getElementById("<%=divPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title>');

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
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <div class="panel panel-default">
                    <div class="panel-heading" style="text-align: center">
                        <h3 class="panel-title" style="font-weight: bold;">
                            <asp:Label ID="lblHeading" runat="server">Query-Data</asp:Label>
                            &nbsp;<%--<a id="A1" href="#" onclick="javascript:return Panel1();"
                                runat="server">
                                <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" /></a>--%> <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                        <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a></h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="font-family: 'Trebuchet MS'">

                            <%--<tr>
                                <td align="center" colspan="4" style="padding: 5px; margin: 5px">
                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
                                </td>
                            </tr>--%>

                            <tr>
                                <td style="text-align: left">
                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboardNew.aspx"
                                        Text="<< Back">
                                    </asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" align="left">
                                    <table width="80%">
                                        <tr runat="server" id="trBetweenDates" visible="false">
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

                                        <tr align="center" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" colspan="4" align="center">
                                                <asp:Button ID="Button3" runat="server" CssClass="btn btn-default" TabIndex="10"
                                                    Text="Submit" OnClick="BtnSave1_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                            <tr>
                                <td align="left">
                                    <b>Queries</b>
                                </td>
                            </tr>

                            <tr id="div_Print11" runat="server" style="width: 900px;">
                                <td align="left" colspan="6" style="padding: 5px; margin: 5px">
                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        OnRowDataBound="grdDetails_RowDataBound" OnPageIndexChanging="grdDetails_PageIndexChanging"
                                        ShowFooter="true" OnRowCommand="grdDetails_RowCommand">
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" Width="120px" />
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
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="DISTID" HeaderText="DISTID" Visible="false"></asp:BoundField>
                                            <asp:BoundField DataField="DISTCD" HeaderText="District Name"></asp:BoundField>

                                            <asp:TemplateField HeaderText="Pavalla vaddi">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb2" Font-Underline="False" runat="server" Text='<%# Eval("INS1") %>' CommandName="INS1" CommandArgument='<%# Eval("DISTID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Application For Transport Vehicle Under T-Pride">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb3" Font-Underline="False" runat="server" Text='<%# Eval("INS2") %>' CommandName="INS2" CommandArgument='<%# Eval("DISTID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Power Cost Reimbursement">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb4" Font-Underline="False" runat="server" Text='<%# Eval("INS3") %>' CommandName="INS3" CommandArgument='<%# Eval("DISTID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Specific Cleaner Production measures">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb5" Font-Underline="False" runat="server" Text='<%# Eval("INS4") %>' CommandName="INS4" CommandArgument='<%# Eval("DISTID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sales TAX(VAT/GST/SGST) Reimbursement">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb6" Font-Underline="False" runat="server" Text='<%# Eval("INS5") %>' CommandName="INS5" CommandArgument='<%# Eval("DISTID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Investment Subsidy">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb7" Font-Underline="False" runat="server" Text='<%# Eval("INS6") %>' CommandName="INS6" CommandArgument='<%# Eval("DISTID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Industrial Infrastructure Development Fund(IIDF)">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb8" Font-Underline="False" runat="server" Text='<%# Eval("INS7") %>' CommandName="INS7" CommandArgument='<%# Eval("DISTID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Reimbursement of cost involved in skill upgradation and training">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb9" Font-Underline="False" runat="server" Text='<%# Eval("INS8") %>' CommandName="INS8" CommandArgument='<%# Eval("DISTID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Reimbursement of stamp Duty/Transfer Duty/Mortgage/Land Conversion/Land Cost">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb10" Font-Underline="False" runat="server" Text='<%# Eval("INS9") %>' CommandName="INS9" CommandArgument='<%# Eval("DISTID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Seed Capital Assistance for 1st generation Entrepreneur for Micro Enterprise">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb11" Font-Underline="False" runat="server" Text='<%# Eval("INS10") %>' CommandName="INS10" CommandArgument='<%# Eval("DISTID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Reimbursement of all expenses incurred for Quality Certification/Patent Registration">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb12" Font-Underline="False" runat="server" Text='<%# Eval("INS11") %>' CommandName="INS11" CommandArgument='<%# Eval("DISTID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Advance Subsidy before DCP for SC/ST Enterprises">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lb13" Font-Underline="False" runat="server" Text='<%# Eval("INS12") %>' CommandName="INS12" CommandArgument='<%# Eval("DISTID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>

                            <tr id="div_Print" visible="false" runat="server" style="width: 900px;">
                                <td align="left" colspan="6" style="padding: 5px; margin: 5px">
                                    <asp:GridView ID="grdData" runat="server" AutoGenerateColumns="true" CellPadding="4"
                                        ShowFooter="true">
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" Width="120px" />
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                    </asp:GridView>

                                </td>
                            </tr>

                            <tr>
                                <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                        <strong>Success!</strong><asp:Label ID="Label2" runat="server"></asp:Label>
                                    </div>
                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                        <strong>Warning!</strong>
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



