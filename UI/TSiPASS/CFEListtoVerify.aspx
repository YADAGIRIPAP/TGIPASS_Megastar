<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="CFEListtoVerify.aspx.cs" Inherits="UI_TSiPASS_CFEListtoVerify" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">

        $(function () {

            $('#MstLftMenu').remove();

        });
    </script>
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    <li>
                        <i class="fa fa-dashboard"></i><a href="Home.aspx"></a>
                    </li>
                </ol>
            </div>

            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-12">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">CFE Applications</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 98%">

                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:GridView ID="grdCFEDetails" runat="server"
                                                        AutoGenerateColumns="False" CellPadding="5" ForeColor="#333333"
                                                        Height="62px" OnRowDataBound="grdCFEDetails_RowDataBound"
                                                        ShowFooter="True" Width="100%">
                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle BackColor="#EBF2FE" HorizontalAlign="Left"
                                                            VerticalAlign="Middle" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="UID">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="hplUID" runat="server" Text='<%#Eval("UID_No") %>'></asp:HyperLink>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="NameofIndustrialUnder" HeaderText="Name of Unit" />
                                                            <asp:BoundField DataField="NameofthePromoter" HeaderText="Name of Promoter" />
                                                            <asp:BoundField DataField="DISTRICT" HeaderText="Unit District" />
                                                            <asp:BoundField DataField="MANDAL" HeaderText="Unit Mandal" />
                                                            <asp:BoundField DataField="VILLAGE" HeaderText="Unit Village" />
                                                            <asp:BoundField DataField="EntrpType" HeaderText="Enterprise Type" />
                                                            <asp:BoundField DataField="LineofActivity_Name" HeaderText="Line of Activity" />
                                                            <asp:BoundField DataField="Applicationdate" HeaderText="Application Date" /> 

                                                            <asp:BoundField DataField="ProposalForQue" HeaderText="New / Expansion" />
                                                            <asp:BoundField DataField="Investment" HeaderText="Investment (Cr)"  />
                                                            <asp:BoundField DataField="Prop_Emp" HeaderText="Employment" />
                                                            <asp:BoundField DataField="DirectMale" HeaderText="Male Employee " />
                                                            <asp:BoundField DataField="DirectFemale" HeaderText="Female Employee" />
                                                            <asp:TemplateField HeaderText="CFEEnterpid" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblintCFEEnterpid" Text='<%#Eval("intCFEEnterpid") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Quessionaireid" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblintQuessionaireid" Text='<%#Eval("intQuessionaireid") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Quessionaireid" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblintUserid" Text='<%#Eval("Created_by") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Verify">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnVerify" Text="Verify" BackColor="Blue" ForeColor="White" Font-Bold="true" runat="server" OnClick="btnVerify_Click"></asp:Button>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True"
                                                            ForeColor="White" />
                                                        <EditRowStyle BackColor="#B9D684" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" align="center">&nbsp;<tr>
                                                    <td align="center" style="padding: 5px; margin: 5px">&nbsp;</td>
                                                </tr>
                                                    <caption>
                                                        &nbsp;</caption>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" align="center">
                                                    <div id="success" runat="server" class="alert alert-success" visible="false">
                                                        <a aria-label="close" class="close" data-dismiss="alert"
                                                            href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:Label
                                                                ID="lblmsg" runat="server"></asp:Label>
                                                    </div>
                                                    <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                                        <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:HiddenField ID="hdfID" runat="server" />
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server"
                                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="child" />
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>

            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                    <div class="overlay">
                        <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
                        <div style="z-index: 1000; margin-left: 250px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
                            <img alt="" src="../../Resource/Images/Processing.gif" />

                        </div>

                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>

            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />


        </ContentTemplate>
    </asp:UpdatePanel>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>


