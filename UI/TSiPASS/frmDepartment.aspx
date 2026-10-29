<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmDepartment.aspx.cs" Inherits="UI_TSiPASS_frmDepartment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 70%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="left">--%>
    <div class="col-lg-12">
        <div class="panel panel-default">
            <div class="panel-heading" style="text-align: center">
                <h3 visible="true" id="Government" runat="server" class="panel-title" style="font-weight: bold;">Department Processed Incentive Applications</h3>
            </div>
            <div class="panel-body">
                <table align="left" cellpadding="10" cellspacing="5" style="width: 100%; font-family: 'Trebuchet MS'">
                    <tr>
                        <td>
                            <table runat="server" id="tblselection" cellpadding="4" cellspacing="5" style="width: 100%">
                                <tr>
                                    <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                        <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/frmAddlashboard.aspx"
                                            Text="<< Back">
                                        </asp:HyperLink>
                                    </td>
                                    <td style="padding: 5px; margin: 5px" align="center" runat="server" id="tdFromDate">
                                        <div class="input-group">
                                            <div class="input-group-addon">
                                                From Date
                                            </div>
                                            <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="175px"></asp:TextBox>
                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                            </cc1:CalendarExtender>
                                        </div>
                                    </td>
                                    <td style="padding: 5px; margin: 5px" runat="server" id="tdToDate">

                                        <div class="input-group">
                                            <div class="input-group-addon">
                                                To Date
                                            </div>
                                            <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="175px"></asp:TextBox>
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                            </cc1:CalendarExtender>
                                        </div>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td class="col-xs-3" style="padding: 5px; margin: 5px" runat="server">
                                        <div class="input-group">
                                            <div class="input-group-addon">
                                                Approvals
                                            </div>
                                            <asp:DropDownList ID="ddlApprove" runat="server" class="form-control txtbox" Height="33px"
                                                Width="180px" AutoPostBack="true" style="left: 0px; top: 0px">
                                                <asp:ListItem>--Select--</asp:ListItem>
                                                <asp:ListItem Value="A" Text="Approved"></asp:ListItem>
                                                <asp:ListItem Value="R" Text="Returned"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                    <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                        <div class="input-group">
                                            <div class="input-group-addon">
                                                Department
                                            </div>
                                            <asp:DropDownList ID="ddlname" runat="server" class="form-control txtbox" Width="150px" AutoPostBack="true">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <asp:ListItem Value="324563" Text="TSSPDCL"></asp:ListItem>
                                                <asp:ListItem Value="324565" Text="TSNPDCL"></asp:ListItem>
                                                <asp:ListItem Value="324566" Text="COMMERCIAL TAX"></asp:ListItem>
                                                <asp:ListItem Value="324567" Text="TSFC"></asp:ListItem>
                                                <asp:ListItem Value="324568" Text="IGRS"></asp:ListItem>
                                                <asp:ListItem Value="324569" Text="TSIIC"></asp:ListItem>
                                                <asp:ListItem Value="324570" Text="REVENUE"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                    </tr>
                                <tr >
                                    <td style="padding: 5px; margin: 5px" align="Center" colspan="4">
                                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-default" TabIndex="10"
                                            Text="Submit" OnClick="btnSubmit_Click" BackColor="Green" ForeColor="White" />
                                    </td>
                                </tr>

                            </table>
                        </td>
                        <%--<td style="padding: 5px; text-align: right; margin: 5px; width: 100%;"></td>--%>
                    </tr>
                    <tr runat="server" id="rptdate">
                        <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                            <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: center; margin: 5px">
                            <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
                        </td>
                    </tr>
                    <%--  <tr>
                                    <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                         <asp:Button ID="btnNewPdf" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Generate Pdf" OnClick="btnNewPdf_Click" />
                                    </td>
                                </tr>--%>
                    <tr id="GridPrint" runat="server">
                        <td colspan="2" align="left" style="padding: 5px; margin: 5px" id="divPrint1" runat="server">
                            <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="false" CellPadding="4"
                                ShowHeaderWhenEmpty="true" ShowFooter="True"
                                OnRowDataBound="grdDetails_RowDataBound" Width="100%">
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
                                        <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:TemplateField>
                                    <asp:HyperLinkField HeaderText="View Application" Text="View Application"  />
                                    <asp:HyperLinkField HeaderText="Appraisal Note" Text="View Appraisal Note"  />
                                     <asp:BoundField DataField="UnitName" HeaderText="Name of Unit" Visible="true" />
                                    <asp:BoundField DataField="EMiUdyogAadhar" HeaderText="UdyogAadhar No." />
                                    <asp:BoundField DataField="IncentiveName" HeaderText="Incentive Name" />
                                     <%--  <asp:BoundField DataField="CLAIMPERIOD" HeaderText="Claimperiod" />--%>
                                    <asp:BoundField DataField="CASTE" HeaderText="Social Category" />
                                    <asp:BoundField DataField="DateofReceipt" HeaderText="Application Received Date" />
                                    <asp:BoundField DataField="RecommendedAmount" HeaderText="Recommended Amount" />                                   
                                    <asp:BoundField DataField="ApplciantName" HeaderText="Applciant Name" Visible="false" />
                                    <asp:TemplateField HeaderText="Applciant Incentive ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEnterperIncentiveID" runat="server" Text='<%# Eval("EnterperIncentiveID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Master Incentive ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIncentiveId" runat="server" Text='<%# Eval("IncentiveId") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Dept" HeaderText=" Processed by Department" />
                                     <asp:BoundField DataField="Processeddate" HeaderText="ProcessDate" />
                                     <asp:BoundField DataField="Status" HeaderText="Status" />                                    
                                    <asp:BoundField DataField="RejectedReason" HeaderText="Returned Reason" />
                                </Columns>
                               <%-- <EmptyDataTemplate>
                                    <div style="text-align: Center">
                                        No Records Found.

                                    </div>
                                </EmptyDataTemplate>--%>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding: 5px; margin: 5px">
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
    </div>
    <%-- </td>
        </tr>
    </table>--%>
</asp:Content>

