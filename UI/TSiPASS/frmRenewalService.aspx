<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmRenewalService.aspx.cs" Inherits="UI_TSiPASS_frmRenewalService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">




    </script>

    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="#">Renewals Registration</a> </li>
                </ol>
            </div>
            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">Renewals Registration</h3>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                                    <tr>
                                        <td style="padding: 5px; margin: 5px">
                                            <div class="panel panel-default">
                                                <div class="panel-body" align="center">
                                                    <table cellpadding="3" cellspacing="5" style="width: 100%; text-align: center">
                                                        <tr>
                                                            <td colspan="3" align="center">
                                                                <asp:RadioButtonList ID="rdrenewalservice" runat="server" RepeatDirection="Horizontal"
                                                                    AutoPostBack="True" OnSelectedIndexChanged="rdrenewalservice_SelectedIndexChanged">
                                                                    <asp:ListItem Text=" &nbsp; Industrial  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Value="I"></asp:ListItem>
                                                                    <asp:ListItem Text="&nbsp; Hotels &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Value="H"></asp:ListItem>
                                                                    <asp:ListItem Text=" &nbsp; Other services &nbsp;&nbsp;&nbsp;&nbsp;" Value="O"></asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>

                                                        </tr>
                                                        <tr runat="server" visible="false" id="trheading">
                                                            <td style="width: 395px; font-size: 16px;">
                                                                <b>Renewals Registration</b>
                                                            </td>
                                                            <td style="width: 30px">&nbsp;
                                                            </td>
                                                            <td style="width: 395px" valign="top">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px; font-size: 16px;">&nbsp;
                                                            </td>
                                                            <td style="width: 30px">&nbsp;
                                                            </td>
                                                            <td style="width: 395px" valign="top">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr runat="server" visible="false" id ="trgrid">
                                                            <td style="width: 100%" align="center" colspan="3" valign="top">
                                                                <div style="width: 100%">
                                                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                        CssClass="GRD" ForeColor="#333333" Height="62px"
                                                                        PageSize="15" ShowFooter="True" Width="100%" CellSpacing="4" OnRowDataBound="grdDetails_RowDataBound">
                                                                        <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                                <ItemTemplate>
                                                                                    <%# Container.DataItemIndex + 1%>
                                                                                    <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                                    <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                                    <asp:HiddenField ID="HdfDeptid" runat="server" />
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <ItemStyle Width="50px" />
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="ApprovalName" HeaderText="Approval Required for">
                                                                                <ItemStyle Width="450px" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Dept_Name" HeaderText="Department Name">
                                                                                <ItemStyle Width="180px" />
                                                                            </asp:BoundField>
                                                                            <asp:TemplateField HeaderText="Whether approval already obtained">
                                                                                <ItemTemplate>
                                                                                    <asp:RadioButtonList ID="RdWhetherAlreadyApproved" runat="server" AutoPostBack="True"
                                                                                        OnSelectedIndexChanged="RdWhetherAlreadyApproved_SelectedIndexChanged" RepeatDirection="Horizontal">
                                                                                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                                        <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                                                                    </asp:RadioButtonList>
                                                                                    <asp:HiddenField ID="HdfAmount" runat="server"/>
                                                                                    <itemstyle horizontalalign="Center" width="140px" />
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" Width="140px" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Apply for Approval">
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="ChkApproval" runat="server" />
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" Width="140px" />
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                        <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                                        <EditRowStyle BackColor="#B9D684" />
                                                                        <AlternatingRowStyle BackColor="White" />
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 100%" align="center" colspan="3" valign="top"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="3" style="width: 100%" valign="top">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="3" style="width: 100%" valign="top">&nbsp;</td>
                                                        </tr>
                                                        <tr  runat="server" visible="false" id="trbuttons">
                                                            <td style="width: 100%" align="center" colspan="3" valign="top">
                                                                <asp:Button ID="btnnext" runat="server" CssClass="btn btn-danger"
                                                                    Height="32px" TabIndex="10" Text="Next" Width="90px" OnClick="btnnext_Click" />
                                                                &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                                    Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                                                    Width="90px" />
                                                            </td>
                                                        </tr>
                                                        <caption>
                                                            <br />
                                                            <br />
                                                            <tr>
                                                                <td align="center" style="padding: 5px; margin: 5px">
                                                                    <div id="success" runat="server" class="alert alert-success" visible="false">
                                                                        <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                                    </div>
                                                                    <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                                                        <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </caption>
                                                    </table>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                &nbsp;
                            </div>
                        </div>
                        <tr>
                            <td align="center" style="padding: 5px; margin: 5px">
                                <table cellpadding="2" style="width: 100%">
                                    <tr>
                                        <td style="width: 417px">&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="padding: 5px; margin: 5px"></td>
                        </tr>
                        <asp:HiddenField ID="hdfID" runat="server" />
                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>

