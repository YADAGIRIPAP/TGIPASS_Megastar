<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="RptDEPARTMENTWISEPROGRESS.aspx.cs" Inherits="LookupCA" Title=":: TSiPASS Online Management System ::" %>

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
     

    <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <div class="panel panel-default">
                    <div class="panel-heading"  style="text-align:center">
                        <h3 class="panel-title" style="font-weight:bold;">
                          R5:  Department Wise Progress&nbsp;<a id="A1" href="#"
                                onserverclick="BtnPDF_Click" runat="server">
                                <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" /></a> <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                        <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a></h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                            <tr id="trFilters" runat="server">
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5">
                                        <tr>
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
                                            <td class="col-xs-5" style="padding: 5px; text-align:right; margin: 5px">
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="13px"
                                        ForeColor="#006600"></asp:Label>
                                </td>
                            </tr>
                            <%--<tr id="trButtons" runat="server">
                                <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                        TabIndex="10" Text="Search" Width="90px" OnClick="BtnSave1_Click" />
                                    <asp:Button Visible="false" ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                        Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="Cancel" ToolTip="To Clear  the Screen"
                                        Width="90px" />
                                        <asp:Button ID="Button2" runat="server" CssClass="btn btn-warning" Height="32px"
                                        TabIndex="10" Text="Print" Width="90px" OnClientClick="return Panel1();" />
                                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Height="32px"
                                        TabIndex="10" Text="Export" Width="90px" OnClick="BtnSave2_Click" />
                                </td>
                            </tr>--%>
                            <tr id="div_Print" runat="server" >
                                <td align="center" style="padding: 5px; margin: 5px">
                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        OnRowDataBound="grdDetails_RowDataBound" Width="100%" OnPageIndexChanging="grdDetails_PageIndexChanging"
                                        ShowFooter="True" OnRowCreated="grdDetails_RowCreated">
                                        <HeaderStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                        <RowStyle CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                        <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>                                            
                                            <%--<asp:HyperLinkField HeaderText="" DataTextField="Name of the Department" />--%>
                                            <asp:TemplateField HeaderText="Department Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldept" runat="server" Text='<%#Eval("Name of the Department") %>'></asp:Label>
                                                    <asp:Label ID="lbldeptid" runat="server" Text='<%#Eval("Dept_Id") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:HyperLinkField FooterStyle-CssClass="text-center" HeaderText="Approvals Applied" DataTextField="Total Approvals">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center"/>
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField FooterStyle-CssClass="text-center" HeaderText="Approved" DataTextField="Approved">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center"/>
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField FooterStyle-CssClass="text-center" HeaderText="Pending" DataTextField="Pending">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center"/>
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField FooterStyle-CssClass="text-center" HeaderText="Rejected" DataTextField="Rejected">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center"/>
                                            </asp:HyperLinkField>
                                            <asp:BoundField FooterStyle-CssClass="text-center" HeaderText="% of Approval" DataField="Approval Persentage">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center"/>
                                            </asp:BoundField>
                                            <asp:HyperLinkField FooterStyle-CssClass="text-center" HeaderText="Average time taken for approval" 
                                                DataTextField="Average time taken for approval" Visible="False">
                                                <FooterStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center"/>
                                            </asp:HyperLinkField>
                                        </Columns>
                                        
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
