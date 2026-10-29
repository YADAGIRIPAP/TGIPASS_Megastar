<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSIPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmHelpdescrpt.aspx.cs" Inherits="UI_TSIPASS_frmHelpdescrpt" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-lg-12">
        <div class="panel panel-default">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td colspan="4">
                        <div class="panel-heading" align="center">
                            <h2 class="panel-title" style="font-weight: bold;">Help Desk Report</h2>
                        </div>

                    </td>
                </tr>
                <tr>
                    <td style="text-align: left" colspan="2">
                       <%-- <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboardNew1.aspx" Text="<< Back">
                        </asp:HyperLink>--%>
                    </td>
                </tr>
                <tr align="center">
                    <td style="padding: 5px; margin: 5px" valign="top" align="center" colspan="2">
                        <table width="80%">
                            <tr align="center">
                                <td style="padding: 5px; margin: 5px" align="center">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            From Date
                                        </div>
                                         <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="13" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                        <%--<asp:TextBox ID="" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>--%>
                                      <%--  <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                        </cc1:CalendarExtender>--%>
                                    </div>
                                </td>
                                <td style="padding: 5px; margin: 5px">

                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            To Date
                                        </div>
                                        <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="13" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                        <%--<asp:TextBox ID="" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>--%>
                                      <%--  <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                        </cc1:CalendarExtender>--%>
                                    </div>
                                </td>
                                <td style="padding: 5px; margin: 5px" align="right">
                                    <asp:Button ID="Button3" runat="server" CssClass="btn btn-primary" TabIndex="10"
                                        Text="Submit" OnClick="BtnSave2_Click" />
                                </td>
                                <td class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px" colspan="5">
                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr style="height: 30px">
                    <td align="right" colspan="2">
                        <asp:Button ID="btnbdf" Visible="false" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Generate Pdf" OnClick="btnbdf_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>

                </tr>
                <tr>
                    <td align="center" style="padding: 5px; margin: 5px ; width:50%" id="divPrint" runat="server">
                        <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            OnRowDataBound="grdDetails_RowDataBound"  Width="90%" OnRowCreated="grdDetails_RowCreated"
                            ShowFooter="True">
                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                            <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                            <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                            <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex +1 %>
                                        <asp:Label ID="lblintfb_id" runat="server" Text='<%# Eval("intfb_id") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                     <ItemStyle HorizontalAlign="Left" Width="20px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Fb_Type" HeaderText="Query Type">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Pending"
                                    DataTextField="Scount">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" Width="80px" />
                                </asp:HyperLinkField>
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td align="center" style="padding: 5px; margin: 5px ; width:50%" id="divPrintnew" runat="server" valign="top">
                        <asp:GridView ID="grdDetails1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            OnRowDataBound="grdDetails1_RowDataBound" Width="90%" OnRowCreated="grdDetails1_RowCreated"
                            ShowFooter="True" >
                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                            <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                            <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                            <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex +1 %>
                                        <asp:Label ID="lblSOLVED_BY" runat="server" Text='<%# Eval("SOLVED_BY") %>' Visible="false"></asp:Label>
                                         
                                    </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Left" Width="20px" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="User_name" HeaderText="Name">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Solved"
                                    DataTextField="Scount">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" Width="50px" />
                                </asp:HyperLinkField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr style="height:30px">
                    <td colspan="2"></td>
                </tr>
                <tr >
                      <td align="center" style="padding: 5px; margin: 5px" id="Td1" runat="server" >
                        <asp:GridView ID="grdDetails2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            OnRowDataBound="grdDetails2_RowDataBound" Width="60%"
                            ShowFooter="True" OnRowCreated="grdDetails2_RowCreated">
                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                            <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                            <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                            <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex +1 %>
                                        <asp:Label ID="lblintfb_idnew" runat="server" Text='<%# Eval("intfb_id") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                     <ItemStyle HorizontalAlign="Left" Width="20px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Fb_Type" HeaderText="Query Type">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Total Posted"
                                    DataTextField="POSTEDCNT">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" Width="80px" />
                                </asp:HyperLinkField>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Solved"
                                    DataTextField="SOLVEDCOUNT">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" Width="80px" />
                                </asp:HyperLinkField>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Pending"
                                    DataTextField="PENDING">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" Width="50px" />
                                </asp:HyperLinkField>
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td align="center" style="padding: 5px; margin: 5px" id="Td2" runat="server" >
                        <asp:GridView ID="gvw_up" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            OnRowDataBound="gvw_up_RowDataBound" Width="60%"
                            ShowFooter="True" OnRowCreated="gvw_up_RowCreated">
                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                            <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                            <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                            <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex +1 %>
                                        <asp:Label ID="lblintfb_id" runat="server" Text='<%# Eval("intfb_id") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                     <ItemStyle HorizontalAlign="Left" Width="20px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Fb_Type" HeaderText="Query Type">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Pending"
                                    DataTextField="Scount">
                                    <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" Width="80px" />
                                </asp:HyperLinkField>
                            </Columns>
                        </asp:GridView>
                    </td>
                  
                </tr>
            </table>
        </div>
    </div>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtFromDate']").datepicker(
               {
                   dateFormat: "dd-mm-yy",
                   //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtTodate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtFromDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtTodate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
        });
    </script>
    <style type="text/css">
        .ui-datepicker
        {
            font-size: 8pt !important;
            height: 250px;
            padding: 0.2em 0.2em 0;
            width: 250px;
        }
    </style>
</asp:Content>
