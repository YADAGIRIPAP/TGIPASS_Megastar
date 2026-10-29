<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/EmptyMaster.master" AutoEventWireup="true" CodeFile="frmBillDeskNotUpdated.aspx.cs" Inherits="UI_TSiPASS_frmBillDeskNotUpdated" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <div class="panel panel-default">
                    <%--<div class="panel-heading" style="text-align: center">
                        <h3 class="panel-title" style="font-weight: bold;">R4.2: Department wise Pendency Report - Abstract<a id="A1" href="#" onclick="return Panel1();" runat="server">
                            <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                alt="PDF" /></a>
                        </h3>
                    </div>--%>
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title" style="font-weight: bold;">
                            <asp:Label ID="lblHeading" runat="server">BillDesk Payment Not Updated Report</asp:Label>&nbsp; &nbsp; &nbsp; </h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 100%; font-family: 'Trebuchet MS'">
                            <tr>
                                <td style="padding: 5px; margin: 5px" align="right"></td>
                                <td style="padding: 5px; text-align: right; margin: 5px; width: 100%">
                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" colspan="2">
                                    <table width="80%">
                                        <tr align="center">
                                            <%-- <td style="padding: 5px; margin: 5px" align="right">
                                                <asp:HyperLink CssClass="btn btn-link" ID="HyperLink2" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboard.aspx" Text="<< Back">
                                                </asp:HyperLink>
                                            </td>--%>

                                            <td style="padding: 5px; margin: 5px" align="center">
                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        From Date
                                                    </div>

                                                    <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                    </cc1:CalendarExtender>
                                                </div>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">

                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        To Date
                                                    </div>
                                                    <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                                    </cc1:CalendarExtender>
                                                </div>
                                            </td>


                                            <td style="padding: 5px; margin: 5px" align="right">
                                                <asp:Button ID="Button3" runat="server" CssClass="btn btn-default" TabIndex="10"
                                                    Text="Submit"/>
                                            </td>
                                        </tr>

                                    </table>
                                </td>
                            </tr>

                            <tr id="div_Print" runat="server">
                                <td colspan="2" align="center" style="padding: 5px; margin: 5px">
                                    &nbsp;</td>
                            </tr>

                            <tr id="Trgriddetails" runat="server" visible="false">
                                <td colspan="2" align="center" style="padding: 5px; margin: 5px">
                                    <asp:GridView ID="griddetails" runat="server" AutoGenerateColumns="true" CellPadding="4" Width="100%"
                                        ShowFooter="True">
                                        <HeaderStyle HorizontalAlign="Center" ForeColor="#FFFFFF" BackColor="#009688" Wrap="true"
                                            Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                        <RowStyle Height="40px" Wrap="true" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Header" />
                                        <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />

                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="5" style="padding: 5px; margin: 5px">
                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                    </div>
                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
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

