<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="Searchaaprovalname.aspx.cs" Inherits="TSTBDCReg1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

      <script type="text/javascript" language="JavaScript" src="../../Resource/Scripts/js/FusionCharts.js"></script>
    <style type="text/css">
        .overlay
        {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 112px;
            background-color: Gray;
            filter: alpha(opacity=60);
            opacity: 0.9;
            -moz-opacity: 0.9;
        }
        .algnCenter
        {
            text-align:center;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupfrmClosedUnits.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>

    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    Month Wise Statistics</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                                            <tr>
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                    &nbsp;
                                                </td>
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                    &nbsp;</td>
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                    :
                                                </td>
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                    &nbsp;</td>
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                    &nbsp;
                                                </td>
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:Label ID="Label444" runat="server" CssClass="LBLBLACK">Approval</asp:Label>
                                                </td>
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                    :
                                                </td>
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:DropDownList ID="ddlcategory" runat="server" class="form-control txtbox" Height="33px"
                                                        TabIndex="1" Width="180px" >
                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="8" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:Button ID="BtnSave4" runat="server" CssClass="btn btn-default" Height="32px"
                                                        OnClick="BtnSave4_Click" TabIndex="10" Text="Search" Width="90px" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="BtnClear1" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                        Height="32px" OnClick="BtnClear1_Click" TabIndex="10" Text="Clear" ToolTip="To Clear  the Screen"
                                                        Width="90px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="8" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:GridView ID="gvCertificate0" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                        CellPadding="4" CssClass="GRD" ForeColor="#333333" Height="62px" OnPageIndexChanging="grdDetails_PageIndexChanging"
                                                        OnRowCreated="grdDetails_RowCreated" OnRowDataBound="grdDetails_RowDataBound"
                                                        OnSelectedIndexChanged="grdDetails_SelectedIndexChanged" PageSize="20" ShowFooter="True"
                                                        Width="100%">
                                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex +1 %>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="20px" />
                                                            </asp:TemplateField>
                                                            <%--<asp:BoundField DataField="SLNo" HeaderText="SLNo" />--%>
                                                            <%-- <asp:BoundField DataField="incentive" HeaderText="Type of Incentive" />--%>
                                                            <asp:BoundField DataField="MonthNames" HeaderText="Month Name" />
                                                            <asp:BoundField DataField="Number of Applications submitted" HeaderText="Applications" />
                                                            <%-- <asp:BoundField DataField="UID_No" HeaderText="UID No" />--%>
                                                            <asp:BoundField DataField="Number of approvals submitted" HeaderText="Approvals" />
                                                            <asp:BoundField DataField="Pre-ScrutinyCompleted" HeaderText="Pre-ScrutinyCompleted" />
                                                            <asp:BoundField DataField="Number of approvals - query raised" HeaderText="Query raised" />
                                                            <asp:BoundField DataField="Number of approvals approved" HeaderText="Approved" />
                                                            <asp:BoundField DataField="Number of approvals rejected" HeaderText="Rejected" />
                                                            <%--<asp:BoundField DataField="Pending More than 3 Days" HeaderText="More than 3 Days" />  
                                                            <asp:BoundField DataField="Approved with in days" HeaderText="with in days" />
                                                            <asp:BoundField DataField="Approved Beyond days" HeaderText="Beyond days" />
                                                            <asp:BoundField DataField="Under Process Within Days" HeaderText="Within Days" />
                                                            <asp:BoundField DataField="Under Process Beyond Days" HeaderText="Beyond Days" />
                                                            <asp:BoundField DataField="Rejected With in Days" HeaderText="With in Days" />
                                                            <asp:BoundField DataField="Rejected Beyond Days" HeaderText="Beyond Days" />
                                                            <asp:BoundField DataField="Number of payment received for" HeaderText="Number of payment received for" />--%>
                                                        </Columns>
                                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                            <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                            <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                            <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="8" style="padding: 5px; margin: 5px">
                                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">
                                                            &times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                    </div>
                                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>
                                                            Warning!</strong>
                                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="8" style="padding: 5px; margin: 5px"> <asp:Literal ID="FCLiteral1" runat="server"></asp:Literal> </td>
                                            </tr>
                                        </table>
                                        <asp:HiddenField ID="hdfID" runat="server" />
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="group" />
                                        <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="group1" />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="child" />
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                                        <asp:HiddenField ID="hdfFlagID0" runat="server" />
                                        <asp:HiddenField ID="hdfpencode" runat="server" />
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
                        <div style="z-index: 1000; margin-left: -210px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
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
    <script type="text/javascript">
        $(document).ready(function () {
            fusionchart.callFunction();
        });
    </script>
</asp:Content>
