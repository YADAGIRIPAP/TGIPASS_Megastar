<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmDepartmentApprovalDetailsCFO.aspx.cs" Inherits="TSTBDCReg1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <style type="text/css">
        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../../Images/ajax-loaderblack.gif");
            /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat;
            /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }

        .overlay {
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

        .style7 {
            color: #FF3300;
        }

        .style8 {
            color: #FF0000;
            font-weight: bold;
        }



        .GRD {
            width: 800px;
            height: auto;
            border-color: #013161;
            border-style: solid;
            border-width: 1px;
            text-transform: capitalize;
            padding: 5px;
        }

        .GRDHEADER {
            border: 1px solid #ffffff;
            color: #0E2A46;
            vertical-align: middle;
            text-align: center;
            height: 25px;
            width: 50px;
            padding: 10px;
            font-size: 12px;
            font-weight: bold;
            text-transform: capitalize;
            font-family: Verdana;
            BACKGROUND-IMAGE: url('../../Resource/Styles/images/bg_blue_grd.gif');
        }

        .GRDITEM {
            /*background-color: WHITE;*/
            color: black;
            font-size: 12px;
            font-weight: normal;
            font-family: Verdana;
            padding: 10px;
            /*text-decoration:none;*/
            /*border-color:#013161;*/
            /*border-style:solid;*/
            text-transform: uppercase;
            /*border-width:1px;*/
            /*height:23px;*/
            /*text-indent:5px;*/
            /*BACKGROUND-IMAGE: url(../images/grid_bg_.gif);*/
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
                    You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i><a href="Home.aspx"></a>
                            </li>
                    <li class="">
                        <i class="fa fa-fw fa-edit">CAF</i>
                    </li>
                    <li class="active">
                        <i class="fa fa-edit"></i><a href="#">Departments</a>
                    </li>
                </ol>
            </div>

            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">Departments</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">

                                            <tr id="rrr" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px" valign="top" class="style8">The following are the Approvals required for   your Unit.please 
                                            select the Approvals for which you intend to apply for.</td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <div class="GRD" style="width: 100%">
                                                        <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False"
                                                            CellPadding="4" CssClass="GRD" ForeColor="#333333" Height="62px"
                                                            OnRowDataBound="grdDetails_RowDataBound" PageSize="15" ShowFooter="True"
                                                            Width="100%" CellSpacing="4">
                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left"
                                                                VerticalAlign="Middle" />
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
                                                                <asp:BoundField DataField="ApprovalName" HeaderText="Approval Required">
                                                                    <ItemStyle Width="450px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Dept_Full_name" HeaderText="Issuing Department">
                                                                    <ItemStyle Width="180px" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Whether you have already taken approval">
                                                                    <ItemTemplate>
                                                                        <asp:RadioButtonList ID="RdWhetherAlreadyApproved" runat="server"
                                                                            AutoPostBack="True"
                                                                            OnSelectedIndexChanged="RdWhetherAlreadyApproved_SelectedIndexChanged"
                                                                            RepeatDirection="Horizontal">
                                                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                            <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                        <asp:HiddenField ID="HdfAmount" runat="server"
                                                                            OnValueChanged="HdfAmount_ValueChanged" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Fees" DataFormatString="{0:0}" ControlStyle-CssClass="col-md-6" ItemStyle-HorizontalAlign="Right"
                                                                    FooterStyle-HorizontalAlign="Right" HeaderText="Fees(Rs.)" Visible="false">
                                                                    <ControlStyle CssClass="col-md-6" />
                                                                    <FooterStyle HorizontalAlign="Right" />
                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                    <ItemStyle HorizontalAlign="Right" Width="150px" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Apply for Approval">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="ChkApproval" runat="server" AutoPostBack="True"
                                                                            OnCheckedChanged="ChkApproval_CheckedChanged" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="Amount(Rs.)" Visible="false" />
                                                            </Columns>
                                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True"
                                                                ForeColor="White" />
                                                            <EditRowStyle BackColor="#B9D684" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" align="center" class="style7">&nbsp;<tr>
                                                    <td style="padding: 5px; margin: 5px" align="center">&nbsp;</td>
                                                </tr>
                                                    <caption>
                                                        &nbsp;</caption>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center"
                                                    style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary"
                                                        Height="32px" OnClick="BtnSave_Click" TabIndex="10" Text="Save"
                                                        ValidationGroup="group" Width="90px" Visible="False" />
                                                    &nbsp;&nbsp;<asp:Button ID="BtnDelete" runat="server" CausesValidation="False"
                                                        CssClass="btn btn-danger" Height="32px" OnClick="BtnClear0_Click" TabIndex="10"
                                                        Text="Proceed" Width="90px" />
                                                    &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                                        CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                                        Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding: 5px; margin: 5px">


                                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                                        <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                    </div>


                                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                                        <strong>Warning!</strong>
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
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="upd1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>


        </ContentTemplate>
    </asp:UpdatePanel>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>

