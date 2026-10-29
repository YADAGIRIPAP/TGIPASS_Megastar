<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmUTRNumberSearch.aspx.cs" Inherits="UI_TSiPASS_frmUTRNumberSearch" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .overlay {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 1px;
            background-color: Gray;
            filter: alpha(opacity=60);
            opacity: 0.9;
            -moz-opacity: 0.9;
        }

        .textboxPge {
            border: 1px solid #c4c4c4;
            height: 30px;
            width: 140px;
            font-size: 13px;
            padding: 4px 4px 4px 4px;
            border-radius: 4px;
            -moz-border-radius: 4px;
            -webkit-border-radius: 4px;
            box-shadow: 0px 0px 8px #d9d9d9;
            -moz-box-shadow: 0px 0px 8px #d9d9d9;
            -webkit-box-shadow: 0px 0px 8px #d9d9d9;
        }

            .textboxPge:focus {
                outline: none;
                border: 1px solid #7bc1f7;
                box-shadow: 0px 0px 8px #7bc1f7;
                -moz-box-shadow: 0px 0px 8px #7bc1f7;
                -webkit-box-shadow: 0px 0px 8px #7bc1f7;
            }
    </style>
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel_ex" runat="server">
            <div align="left">
                <ol class="breadcrumb">
                    You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i><a href="index.html">ADMIN</a>
                            </li>
                    <li class="">
                        <i class="fa fa-fw fa-table"></i>User Search
                    </li>

                </ol>
            </div>
            <%--<div class="alert alert-warning fade in" id="warning" runat="server" visible="false">
    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
    <strong>Warning!</strong> <asp:Label ID="lbluserid0" runat="server" 
        CssClass="" ></asp:Label>
    &nbsp;
  </div>--%>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="upd1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">USER SEARCH</h3>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 80%">


                                    <tr>
                                        <td align="center"
                                            style="padding: 5px; margin: 5px; text-align: center;">UTR NUMBER :
                                            <asp:TextBox ID="txtUserName" runat="server" MaxLength="100" class="textboxPge" Width="100px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                            <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px" OnClick="BtnSave1_Click" TabIndex="2" Text="Seacrh" ValidationGroup="group" Width="90px" />
                                            <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;
                                    <asp:ImageButton ImageUrl="~/Resource/Images/Excel-icon.png" ID="excel_button" OnClick="BtnExel_Click" Width="30px" Height="30px" Style="float: right;" runat="server" Visible="false" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                            <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="true" CellPadding="5"
                                                ShowFooter="True" Width="100%"
                                                OnPageIndexChanging="grdDetails_PageIndexChanging" AllowPaging="false" PageSize="20">
                                                <HeaderStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Header" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                            <asp:HiddenField ID="HdfQueid" runat="server" />
                                                            <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Eval("UID") %>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <%-- <asp:TemplateField HeaderText="Download">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" Text='<%# Eval("CFEID") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>--%>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                                <asp:HiddenField ID="hdfID" runat="server" />
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                                <asp:HiddenField ID="hdfFlagID" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>

            </div>




            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />

            <br />

                </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="excel_button" />
    </Triggers>
    </asp:UpdatePanel>
</asp:Content>
