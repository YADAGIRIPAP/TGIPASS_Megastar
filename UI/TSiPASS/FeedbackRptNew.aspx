<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="FeedbackRptNew.aspx.cs" Inherits="UI_TSiPASS_FeedbackRptNew" %>


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

            document.getElementById('<%=A1.ClientID %>').style.display = "none";
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
    </script>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container demo">
                <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                    <div class="panel panel-default">
                        <div class="panel-heading" role="tab" id="headingOne">
                            <h4 class="panel-title">
                                <a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                    <i class="more-less glyphicon glyphicon-plus"></i>
                                    CFE Retrospective Report
                                </a>
                            </h4>
                        </div>
                        <div id="collapseOne" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                            <div class="panel-body">
                                <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px;"
                                            valign="top" align="center">
                                            <div class="panel panel-default">
                                                <div class="panel-heading" style="text-align: center; width: 100%">
                                                    <h3 class="panel-title" style="font-weight: bold;">
                                                        <asp:Label ID="lblHeading" runat="server"></asp:Label>
                                                        &nbsp;<a id="A1" href="#" onclick="javascript:return Panel1();"
                                                            runat="server">
                                                            <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                                                alt="PDF" /></a> <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                                                    <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                                                        alt="Excel" /></a></h3>
                                                </div>
                                                <div class="panel-body">
                                                    <table align="center" style="width: 100%" cellpadding="10" cellspacing="5" style="font-family: 'Trebuchet MS'">
                                                        <tr>
                                                            <td align="center" colspan="4" style="padding: 5px; margin: 5px">
                                                                <b>
                                                                    <asp:Label ID="Label1" Text="CFE Retrospective Report " runat="server" CssClass="LBLBLACK"></asp:Label></b>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                                <table cellpadding="4" cellspacing="5" style="width: 100%">

                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px;" align="center" colspan="2">
                                                                            <asp:GridView ID="GridView1" runat="server" AllowPaging="false"
                                                                                AutoGenerateColumns="False" CellPadding="4" CssClass="GRD"
                                                                                ForeColor="#333333" Height="62px"
                                                                                OnRowDataBound="GridView1_RowDataBound" Width="80%" ShowFooter="True">
                                                                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                                <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left"
                                                                                    VerticalAlign="Middle" Height="75px" />
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No" HeaderStyle-Width="35px">
                                                                                        <ItemTemplate>
                                                                                            <%# Container.DataItemIndex + 1%>
                                                                                            <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                                            <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" Height="50px" />
                                                                                        <ItemStyle Width="50px" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Name" ItemStyle-Width="150" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblApprovalId" runat="server" Text='<%# Eval("APPROVALID") %>' Visible="false" />
                                                                                        </ItemTemplate>

                                                                                        <ItemStyle Width="150px"></ItemStyle>
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField DataField="DEPTID" HeaderText="Department ID" Visible="false" />
                                                                                    <asp:BoundField DataField="DeptName" HeaderText="Department" ItemStyle-Width="1000px" />
                                                                                    <asp:BoundField DataField="APPROVALID" HeaderText="APPROVAL ID" Visible="false" />
                                                                                    <asp:BoundField DataField="APPROVALNAME" HeaderText="APPROVAL NAME" ItemStyle-Width="1000px" />

                                                                                    <asp:TemplateField HeaderText="SMS SENT">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkbtnSMSSent" runat="server" CommandArgument='<%#Eval("RE_TROSMSSENT")%>  ' Text='<%#Eval("RE_TROSMSSENT")%>  ' CommandName="SMS" OnClick="lnkbtnSMSSent_Click" Width="100px"></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                                    </asp:TemplateField>

                                                                                    <asp:TemplateField HeaderText="FEEDBACK RECIEVED">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkbtnFbkRcvd" runat="server" CommandArgument='<%#Eval("RE_TROFBKRECIEVED")%>  ' Text='<%#Eval("RE_TROFBKRECIEVED")%>  ' CommandName="FBK" OnClick="lnkbtnFbkRcvd_Click" Width="100px"></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                                    </asp:TemplateField>

                                                                                </Columns>
                                                                                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                                <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True"
                                                                                    ForeColor="White" />
                                                                                <EditRowStyle BackColor="#B9D684" />
                                                                                <AlternatingRowStyle BackColor="White" />
                                                                            </asp:GridView>

                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                                                <b>
                                                                    <asp:Label ID="lblgrdDetails2" runat="server" CssClass="LBLBLACK"></asp:Label></b>
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
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading" role="tab" id="Div1">
                            <h4 class="panel-title">
                                <a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseOneCFO" aria-expanded="true" aria-controls="collapseOne">
                                    <i class="more-less glyphicon glyphicon-plus"></i>
                                    CFO Retrospective Report
                                </a>
                            </h4>
                        </div>
                        <div id="collapseOneCFO" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                            <div class="panel-body">
                                <table id="Table1" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px;"
                                            valign="top" align="center">
                                            <div class="panel panel-default">
                                                <div class="panel-heading" style="text-align: center; width: 100%">
                                                    <h3 class="panel-title" style="font-weight: bold;">
                                                        <asp:Label ID="Label2" runat="server"></asp:Label>
                                                        &nbsp;<a id="A3" href="#" onclick="javascript:return Panel1();"
                                                            runat="server">
                                                            <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                                                alt="PDF" /></a> <a id="A4" href="#" onserverclick="BtnSave2_Click" runat="server">
                                                                    <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                                                        alt="Excel" /></a></h3>
                                                </div>
                                                <div class="panel-body">
                                                    <table align="center" style="width: 100%" cellpadding="10" cellspacing="5" style="font-family: 'Trebuchet MS'">
                                                        <tr>
                                                            <td align="center" colspan="4" style="padding: 5px; margin: 5px">
                                                                <b>
                                                                    <asp:Label ID="Label3" Text="CFO Retrospective Report " runat="server" CssClass="LBLBLACK"></asp:Label></b>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                                <table cellpadding="4" cellspacing="5" style="width: 80%">
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px;" align="center" colspan="2">
                                                                            <asp:GridView ID="GridView2" runat="server" AllowPaging="false"
                                                                                AutoGenerateColumns="False" CellPadding="4" CssClass="GRD"
                                                                                ForeColor="#333333" Height="62px"
                                                                                OnRowDataBound="GridView2_RowDataBound" Width="100%" ShowFooter="True">
                                                                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                                <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left"
                                                                                    VerticalAlign="Middle" Height="75px" />
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No" HeaderStyle-Width="35px">
                                                                                        <ItemTemplate>
                                                                                            <%# Container.DataItemIndex + 1%>
                                                                                            <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                                            <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" Height="50px" />
                                                                                        <ItemStyle Width="50px" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Name" ItemStyle-Width="150" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblApprovalId" runat="server" Text='<%# Eval("APPROVALID") %>' Visible="false" />
                                                                                        </ItemTemplate>

                                                                                        <ItemStyle Width="150px"></ItemStyle>
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField DataField="DEPTID" HeaderText="Department ID" Visible="false" />
                                                                                    <asp:BoundField DataField="DeptName" HeaderText="Department" ItemStyle-Width="1000px" />
                                                                                    <asp:BoundField DataField="APPROVALID" HeaderText="APPROVAL ID" Visible="false" />
                                                                                    <asp:BoundField DataField="APPROVALNAME" HeaderText="APPROVAL NAME" ItemStyle-Width="1000px" />

                                                                                    <asp:TemplateField HeaderText="SMS SENT">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkbtnSMSSentCFO" runat="server" CommandArgument='<%#Eval("RE_TROSMSSENT")%>  ' Text='<%#Eval("RE_TROSMSSENT")%>  ' CommandName="SMSCFO" OnClick="lnkbtnSMSSentCFO_Click" Width="100px"></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                                    </asp:TemplateField>

                                                                                    <asp:TemplateField HeaderText="FEEDBACK RECIEVED">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkbtnFbkRcvdCFO" runat="server" CommandArgument='<%#Eval("RE_TROFBKRECIEVED")%>  ' Text='<%#Eval("RE_TROFBKRECIEVED")%>  ' CommandName="FBKCFO" OnClick="lnkbtnFbkRcvdCFO_Click" Width="100px"></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                                    </asp:TemplateField>

                                                                                </Columns>
                                                                                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                                <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True"
                                                                                    ForeColor="White" />
                                                                                <EditRowStyle BackColor="#B9D684" />
                                                                                <AlternatingRowStyle BackColor="White" />
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px"></td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="panel panel-default">
                    <div class="panel-heading" role="tab" id="Div2">
                        <h4 class="panel-title">
                            <a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseOneINC" aria-expanded="true" aria-controls="collapseOne">
                                <i class="more-less glyphicon glyphicon-plus"></i>
                                Incentives Retrospective Report
                            </a>
                        </h4>
                    </div>
                    <div id="collapseOneINC" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                        <div class="panel-body">
                            <table id="Table2" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                <tr>
                                    <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px;"
                                        valign="top" align="center">
                                        <div class="panel panel-default">
                                            <div class="panel-heading" style="text-align: center; width: 100%">
                                                <h3 class="panel-title" style="font-weight: bold;">
                                                    <asp:Label ID="Label4" runat="server"></asp:Label>
                                                    &nbsp;<a id="A5" href="#" onclick="javascript:return Panel1();"
                                                        runat="server">
                                                        <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                                            alt="PDF" /></a> <a id="A6" href="#" onserverclick="BtnSave2_Click" runat="server">
                                                                <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                                                    alt="Excel" /></a></h3>
                                            </div>
                                            <div class="panel-body">
                                                <table align="center" style="width: 100%" cellpadding="10" cellspacing="5" style="font-family: 'Trebuchet MS'">
                                                    <tr>
                                                        <td align="center" colspan="4" style="padding: 5px; margin: 5px">
                                                            <b>
                                                                <asp:Label ID="Label5" Text="Incentives Retrospective Report " runat="server" CssClass="LBLBLACK"></asp:Label></b>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                            <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px;" align="center" colspan="2">
                                                                        <asp:GridView ID="GridView3" runat="server" AllowPaging="false"
                                                                            AutoGenerateColumns="False" CellPadding="4" CssClass="GRD"
                                                                            ForeColor="#333333" Height="62px"
                                                                            OnRowDataBound="GridView3_RowDataBound" Width="60%" ShowFooter="True">
                                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left"
                                                                                VerticalAlign="Middle" Height="75px" />
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No" HeaderStyle-Width="35px">
                                                                                    <ItemTemplate>
                                                                                        <%# Container.DataItemIndex + 1%>
                                                                                        <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                                        <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Center" Height="50px" />
                                                                                    <ItemStyle Width="50px" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Name" ItemStyle-Width="150" Visible="false">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblApprovalId" runat="server" Text='<%# Eval("DISTID") %>' Visible="false" />
                                                                                    </ItemTemplate>

                                                                                    <ItemStyle Width="150px"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                                <%-- <asp:BoundField DataField="DEPTID" HeaderText="Department ID" Visible="false" />--%>
                                                                                <asp:BoundField DataField="DISTNAME" HeaderText="DISTRICT" ItemStyle-Width="1000px" />
                                                                                <asp:TemplateField HeaderText="SMS SENT">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkbtnSMSSentINC" runat="server" CommandArgument='<%#Eval("RE_TROSMSSENT")%>  ' Text='<%#Eval("RE_TROSMSSENT")%>  ' CommandName="SMSINC" OnClick="lnkbtnSMSSentINC_Click" Width="100px"></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="FEEDBACK RECIEVED">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkbtnFbkRcvdINC" runat="server" CommandArgument='<%#Eval("RE_TROFBKRECIEVED")%>  ' Text='<%#Eval("RE_TROFBKRECIEVED")%>  ' CommandName="FBKIINC" OnClick="lnkbtnFbkRcvdINC_Click" Width="100px"></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                                </asp:TemplateField>

                                                                            </Columns>
                                                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                            <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True"
                                                                                ForeColor="White" />
                                                                            <EditRowStyle BackColor="#B9D684" />
                                                                            <AlternatingRowStyle BackColor="White" />
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>

                                                        <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px"></td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

