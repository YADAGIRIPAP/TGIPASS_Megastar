<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="RptYEARWISEPROGRESS.aspx.cs" Inherits="LookupCA" Title=":: TSiPASS Online Management System ::" %>

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

            document.getElementById('<%=A1.ClientID %>').style.display = "none";
            document.getElementById('<%=A2.ClientID %>').style.display = "none";
            document.getElementById('<%=trFilter.ClientID %>').style.display = "none";

            var panel = document.getElementById("<%=divPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title>');

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

   

    <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <div class="panel panel-default">
                    <div class="panel-heading" style="text-align: center">
                        <h3 class="panel-title" style="font-weight:bold;">
                            R1.3 Abstract -Financial Year wise&nbsp;<a id="A1" href="#" onclick="javascript:return Panel1();"
                                runat="server">
                                <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" /></a> <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                        <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a></h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5">
                            <tr id="trFilter" runat="server">
                                <td style="padding: 5px; margin: 5px" align="right">
                                             <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboard.aspx" Text="<< Back" >
                                </asp:HyperLink>
                                            </td>
                                <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            District</div>
                                        <asp:DropDownList ID="ddldistrict" runat="server" class="form-control txtbox" Width="180px">
                                            <asp:ListItem>--Select--</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Category</div>
                                        <asp:DropDownList ID="ddlCategory" runat="server" class="form-control txtbox" Height="33px"
                                            Width="180px">
                                            <asp:ListItem>--Select--</asp:ListItem>
                                            <asp:ListItem Value="1">MEGA</asp:ListItem>
                                            <asp:ListItem Value="2">LARGE</asp:ListItem>
                                            <asp:ListItem Value="3">MEDIUM</asp:ListItem>
                                            <asp:ListItem Value="4">SMALL</asp:ListItem>
                                            <asp:ListItem Value="5">MICRO</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td style="padding: 5px; margin: 5px" align="right">
                                    <asp:Button ID="Button3" runat="server" CssClass="btn btn-default" TabIndex="10"
                                        Text="Submit" OnClick="BtnSave1_Click" />
                                </td>
                                <td class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4" style="padding: 5px; margin: 5px">
                                    <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="13px"
                                        ForeColor="#006600"></asp:Label>
                                </td>
                            </tr>
                            <%--<tr id="trBtns" runat="server">
                                <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                        TabIndex="10" Text="Search" Width="90px" OnClick="BtnSave1_Click" />
                                    <asp:Button Visible="false" ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                        Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="Cancel" ToolTip="To Clear  the Screen"
                                        Width="90px" />
                                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-warning" Height="32px"
                                        TabIndex="10" Text="PDF" Width="90px" OnClick="BtnPDF_Click" />
                                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Height="32px"
                                        TabIndex="10" Text="Export" Width="90px" OnClick="BtnSave2_Click" />
                                </td>
                            </tr>--%>
                            <tr id="div_Print" runat="server">
                                <td align="center" colspan="6" style="padding: 5px; margin: 5px">
                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        OnRowDataBound="grdDetails_RowDataBound" Width="100%" OnPageIndexChanging="grdDetails_PageIndexChanging"
                                        ShowFooter="True" OnRowCreated="grdDetails_RowCreated">
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
                                            </asp:TemplateField>
                                            <asp:HyperLinkField HeaderText="Year" DataTextField="FinYear" />
                                            <asp:HyperLinkField HeaderText="Application received" DataTextField="Total Application received">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Total Investments (Rs Crores)" DataTextField="Total Investments">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <%--<asp:HyperLinkField HeaderText="Approvals Required" DataTextField="Total deptl Approvals Required">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Approvals already taken by applicant" DataTextField="Deptl Approvals already taken by applicant">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Net Approvals required" DataTextField="Net Approvals required">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>--%>
                                            <asp:HyperLinkField HeaderText="Approvals Applied by applicant" DataTextField="Deptl Approvals Applied by applicant">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                              <asp:HyperLinkField HeaderText="Query Raised" DataTextField="Query Raised">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Approvals Pending" DataTextField="Deptl Approvals Pending">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="Approvals Issued" DataTextField="Deptl Approvals Issued">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField Visible="false" HeaderText="TS-iPASS Approvals" DataTextField="TS-iPASS Approvals">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                           
                                        </Columns>
                                        
                                    </asp:GridView>
                                </td>
                            </tr>
                           <%-- <tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    &nbsp;
                                </td>
                            </tr>--%>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
