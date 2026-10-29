<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmQurieResponseStatus_PlotAllotment.aspx.cs" Inherits="UI_TSiPASS_frmQurieResponseStatus_PlotAllotment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
        .style8
        {
            color: #FF0000;
            font-weight: bold;
        }
        .GRD
        {
            height: auto;
            border-color: #013161;
            border-style: solid;
            border-width: 1px;
            text-transform: capitalize;
            padding: 10px;
        }
        
        .GRDITEM
        {
            /*background-color: WHITE;*/
            color: black;
            font-size: 12px;
            font-weight: normal;
            font-family: Verdana;
            padding: 10px; /*text-decoration:none;*/ /*border-color:#013161;*/ /*border-style:solid;*/
            text-transform: uppercase; /*border-width:1px;*/ /*height:23px;*/ /*text-indent:5px;*/
            padding: 10px; /*BACKGROUND-IMAGE: url(../images/grid_bg_.gif);*/
        }
        
        .GRDHEADER
        {
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
            background-image: url(../images/bg_blue_grd.gif);
            border-color: #ffffff;
            border-style: solid;
            border-width: 1px;
        }
        
        .col-lg-11
        {
            padding-left: 0px !important;
        }
        
        
        .panel
        {
            border: 0px !important;
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

        $(function () {

            $('#MstLftMenu').remove();

        });
    </script>
    <asp:UpdatePanel ID="upd1" runat="server" >
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit"></i></li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">R1: VIEW DETAILS</a> </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary" >
                            <div class="panel-heading" align="center" >
                                <h3 class="panel-title">
                                    Query Raise and Response Details</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="left" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="5"
                                                        Height="62px" PageSize="15" ShowFooter="True" Width="120%" OnRowDataBound="grdDetails_RowDataBound"
                                                        BorderColor="Black">
                                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="50px" CssClass="GridviewScrollC1HeaderWrap"
                                                            Font-Bold="true" />
                                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" VerticalAlign="Top" />
                                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                        <RowStyle Wrap="true" />
                                                        <Columns>
                                                             <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="NameOftheFirm_Applicant" HeaderText="Name of Applicant" />
                                                            <asp:BoundField DataField="Dept_Full_name" HeaderText="Department name" />
                                                            <asp:BoundField DataField="ApprovalName" HeaderText="Approval  name" />
                                                            <asp:BoundField DataField="QueryRaiseDate" HeaderText="Query Raise Date" />
                                                            <asp:BoundField DataField="QueryRespondDate" HeaderText="Query Respond Date" />
                                                            <asp:BoundField DataField="QueryDescription" HeaderText="Query Description" />
                                                            <asp:BoundField DataField="QueryRespondRemarks" HeaderText="Query Respond Remarks" />
                                                            <asp:BoundField DataField="QueryAttachmentFileName" HeaderText="Query Attachment FileName" />
                                                            <asp:BoundField DataField="QueryAttachmentFilePath" Visible="false" HeaderText="Query Attachment FilePath" />
                                                            <asp:HyperLinkField HeaderText="Download" Text="Download" />
                                                        </Columns>
                                  
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding: 5px; margin: 5px">
                                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">
                                                            &times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                    </div>
                                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>
                                                            Warning!</strong>
                                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
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
                    <div class="overlay">
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
</asp:Content>

