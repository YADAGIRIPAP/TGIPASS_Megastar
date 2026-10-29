<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSIPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="IncentiveApplicationTracker.aspx.cs" Inherits="UI_TSIPASS_Default2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
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
        
        .update
        {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../../Images/ajax-loaderblack.gif"); /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat; /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }
        
        .style7
        {
            width: 42px;
        }
        
        .style8
        {
            height: 30px;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

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
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">Incentive Application Tracker</a>
                    </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    Incentive Application Tracker</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                SearchType
                                                                <asp:DropDownList runat="server" class="form-control txtbox" ID="ddlTypeofsearch"
                                                                    Width="180px" Height="33px">
                                                                    <asp:ListItem Value="select">----Select----</asp:ListItem>
                                                                    <asp:ListItem Value="UnitName">Name of Unit</asp:ListItem>
                                                                    <asp:ListItem Value="ApplicationNo">Application No</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td class="style7" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txtnameofUnit" autocomplete="off" runat="server" class="form-control txtbox"
                                                                    Height="28px" placeholder="Search Here" MaxLength="40" TabIndex="1" ValidationGroup="group"
                                                                    Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtnameofUnit"
                                                                    ErrorMessage="Please ente Name of Unit" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label424" runat="server" CssClass="LBLBLACK" Width="150px">Name of Incentive</asp:Label>
                                                            </td>
                                                            <td class="style7" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:DropDownList ID="ddlquantityper" runat="server" class="form-control txtbox"
                                                                    Height="33px" TabIndex="1" Width="180px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlquantityper"
                                                                    ErrorMessage="Please Select Application Type" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 27px">
                                                    <asp:Label ID="Label348" runat="server" CssClass="LBLBLACK" Width="50px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center;" align="center" colspan="3">
                                                    <asp:Label Visible="false" ForeColor="Red" runat="server" ID="lblError" Text="*Please Enter Unit Name or UID Number"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center;" align="center">
                                                    <asp:Button ID="BtnSearch" runat="server" CssClass="btn btn-primary" Height="32px"
                                                        OnClick="BtnSave_Click" TabIndex="10" Text="Search" ValidationGroup="group" Width="90px" />
                                                    &nbsp;
                                                    <asp:Button ID="BtnCancel" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                        Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="Cancel" ToolTip="To Clear  the Screen"
                                                        Width="90px" />
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                </td>
                                                <td valign="top" class="style8">
                                                </td>
                                            </tr>
                                            <caption>
                                                <br />
                                                <br />
                                                <tr>
                                                    <td align="center" colspan="3" style="text-align: center;">
                                                        <asp:Label ID="lblrecords" runat="server" ForeColor="Red"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="3" style="padding: 5px; margin: 5px" valign="top">
                                                        <asp:GridView ID="grdDetails" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                                            CellPadding="4" CellSpacing="4" CssClass="GRD" EmptyDataText="NO Data Found"
                                                            ForeColor="#333333" Height="62px" OnPageIndexChanging="grdDetails_PageIndexChanging"
                                                            PageSize="50" ShowFooter="True" Width="100%" OnRowDataBound="grdDetails_RowDataBound1">
                                                            <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="SLNo">
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="UnitName" HeaderText="Unit Name" />
                                                                <asp:BoundField DataField="IncentiveID" HeaderText="IncentiveID" />
                                                                <asp:BoundField DataField="IncentiveTypeID" HeaderText="IncentiveTypeID" />
                                                                <asp:BoundField DataField="District" HeaderText="District" />
                                                                <asp:BoundField DataField="Incentive" HeaderText="Type of Incentive" />
                                                                <asp:BoundField DataField="Status" HeaderText="Status" />
                                                                <asp:BoundField DataField="Application Filed Date" HeaderText="Application Filed Date" />
                                                                <asp:TemplateField HeaderText="Application No">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton runat="server" OnClick="Unnamed_Click" Text='<%#Eval("Application No") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="autorejecteDate" HeaderText="Auto Rejected Date" />
                                                                <%--           <asp:TemplateField HeaderText="Auto rejected Details">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton OnClick="Unnamed_Click" Text='<%#Eval("Application No") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                                <%--<asp:HyperLinkField HeaderText="Auto rejected Details" Text="Auto rejected Details" />--%>
                                                                <asp:TemplateField HeaderText="Auto rejected Details">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkAutorej" runat="server" OnClick="Unnamed_Click1" Text='<%#Eval("Application No") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                 <asp:BoundField DataField="FINANCIALYEAR" HeaderText="Financial Year Applied" />
                                                            </Columns>
                                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#B9D684" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="3" style="padding: 5px; margin: 5px" valign="top">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                        &nbsp;<tr>
                                                            <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <caption>
                                                            &nbsp;</caption>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                        <div id="success" runat="server" class="alert alert-success" visible="false">
                                                            <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">
                                                                ×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                        </div>
                                                        <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                                            <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </caption>
                                        </table>
                                        <asp:HiddenField ID="hdfID" runat="server" />
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="group" />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="child" />
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
                    <div class="update">
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
</asp:Content>
