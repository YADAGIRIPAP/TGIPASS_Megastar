<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/CCMaster.master" CodeFile="frmPaymentTravelAgent.aspx.cs" Inherits="UI_TSiPASS_frmPaymentTravelAgent" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <style type="text/css">
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

        .CS {
            background-color: #abcdef;
            color: Yellow;
            border: 1px solid #1d9a5b;
            font: Verdana 10px;
            padding: 1px 4px;
            font-family: Palatino Linotype, Arial, Helvetica, sans-serif;
        }

        .update {
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
            border: 1px solid #1d9a5b;
            color: #1d9a5b;
            vertical-align: middle;
            text-align: center;
            height: 25px;
            width: 50px;
            padding: 10px;
            font-size: 12px;
            font-weight: bold;
            text-transform: capitalize;
            font-family: Verdana;
            background-image: url('../../Resource/Styles/images/bg_blue_grd.gif');
        }

        .GRDITEM {
            /*background-color: WHITE;*/
            color: black;
            font-size: 12px;
            font-weight: normal;
            font-family: Verdana;
            padding: 10px; /*text-decoration:none;*/ /*border-color:#013161;*/ /*border-style:solid;*/
            text-transform: uppercase; /*border-width:1px;*/ /*height:23px;*/ /*text-indent:5px;*/ /*BACKGROUND-IMAGE: url(../images/grid_bg_.gif);*/
        }

        .LBLBLACK {
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <script type="text/javascript">
        function showModal() {
            $("#ctl00_ContentPlaceHolder1_txtmarketvalue").val('');
            $("#myModal").modal({ backdrop: 'static', keyboard: false });
        }

    </script>
    <script language="javascript" type="text/javascript">
        var hexvalues
            = Array("A", "B", "C", "D", "E", "F", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9");

        function flashtext() {

            var colour = '#';
            for (var counter = 1; counter <= 6; counter++) {
                var hexvalue = hexvalues[Math.floor(hexvalues.length * Math.random())];

                colour = colour + hexvalue;

            }
            document.getElementById("flashingtext").style.color = colour;
        }

        setInterval("flashtext()", 500);
        function flashtext1() {

            var colour = '#';
            for (var counter = 1; counter <= 6; counter++) {
                var hexvalue = hexvalues[Math.floor(hexvalues.length * Math.random())];

                colour = colour + hexvalue;

            }
            document.getElementById("flashingtext1").style.color = colour;
        }

        setInterval("flashtext1()", 500);
        function flashtext2() {

            var colour = '#';
            for (var counter = 1; counter <= 6; counter++) {
                var hexvalue = hexvalues[Math.floor(hexvalues.length * Math.random())];

                colour = colour + hexvalue;

            }
            document.getElementById("flashingtext2").style.color = colour;
        }

        setInterval("flashtext2()", 500);


    </script>
    <%-- <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>--%>
    <link href="assets/css/basic.css" rel="stylesheet" />
    <%--  <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>--%>
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
            <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
            <li class="active"><i class="fa fa-edit"></i>&nbsp; &nbsp;<a href="#">Departments</a>
            </li>
        </ol>
    </div>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-12">
                <%--<div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">Departments</h3>
                            </div>--%>
                <table>
                    <tr>
                        <td>
                            <div class="col-md-12">
                                <h1 class="page-head-line" align="left" style="font-size: x-large">Departments and Approvals for Travel Agency</h1>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="left" cellpadding="10" cellspacing="5" style="width: 100%">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; font-size: 13pt" valign="top" class="style8">
                                                The following are the Approvals required for Travel Agent.
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="panel panel-default" id="dvfeedetails" runat="server" visible="false">
                                                        <div class="panel-heading">
                                                            Fee Details(in Rs.)
                                                        </div>
                                                        <div class="panel-body">
                                                            <table style="width: 90%">
                                                                <tr>
                                                                    <td align="center">
                                                                        <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                            CssClass="GRD" ForeColor="#333333" Height="62px" PageSize="15" Width="100%" OnRowDataBound="grdDetails_RowDataBound"
                                                                            ShowFooter="True">
                                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                                    <ItemTemplate>
                                                                                        <%# Container.DataItemIndex + 1%>
                                                                                        <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                                        <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                                        <asp:HiddenField ID="HdfAmount" runat="server" />
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                    <ItemStyle Width="50px" />
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="ApprovalName" HeaderText="Approval Required ">
                                                                                    <ItemStyle Width="450px" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Dept_Full_name" HeaderText="Department">
                                                                                    <ItemStyle Width="180px" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Fees" FooterStyle-HorizontalAlign="Right" HeaderText="Fees (Rs.)"
                                                                                    DataFormatString="{0:0}">
                                                                                    <FooterStyle CssClass="GRDITEM2" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
                                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                                    <ItemStyle CssClass="GRDITEM2" Width="150px" HorizontalAlign="Right" />
                                                                                </asp:BoundField>
                                                                            </Columns>
                                                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                            <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                                            <EditRowStyle BackColor="#B9D684" />
                                                                            <AlternatingRowStyle BackColor="White" />
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </div>

                                                </td>
                                            </tr>

                                        </table>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <%--   </div>--%>
                        </td>
                    </tr>
                    <tr id="input" runat="server" visible="false">
                        <td align="center" style="padding: 5px; margin: 5px; text-align: left;">
                            <div class="panel panel-primary">
                                <div class="panel-heading" align="center">
                                    <h4 class="panel-title">Note</h4>
                                </div>
                                <div class="panel-body">
                                    <div id="flashingtext" style="font-size: 15px;">
                                        <b>
                                            <h4>
                                            1. Initial Department fee has to be paid through TS-iPASS online system.</b>
                                        <br />
                                        <br />
                                        <b>2. Any Additional payment raised by the department has to be paid through TS-iPASS
                                            online system.</b>
                                        <br />
                                        <br />
                                        <b>3. If any payment done through the respective department will not be considered and
                                            stage of the application will not be escalated.</b></h4>
                                    </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                              <asp:HiddenField ID="hdnTransactionNumber" runat="server" />
                            <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                Width="90px" />&nbsp;&nbsp;
                            <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Height="32px"
                                OnClick="BtnSave_Click" TabIndex="10" Text="PAY NOW" ValidationGroup="group" Width="90px"
                                Visible="False" />
                           
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px" align="center" class="style7"></td>
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
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
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
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>
