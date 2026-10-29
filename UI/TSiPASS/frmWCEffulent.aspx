<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="frmWCEffulent.aspx.cs" Inherits="UI_TSiPASS_frmWCEffulent" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
     <script src="../../Resource/Styles/SideMenu/script.js" type="text/javascript"></script>

    <link href="../../Resource/Styles/SideMenu/styles.css" rel="stylesheet" type="text/css" />


    <link href="../../Masterfiles/css/StyleSheetMaster.css" rel="stylesheet" />
    <script src="../../Resource/Scripts/js/jquery.js" type="text/javascript"></script>

    <script src="../../Resource/Scripts/js/bootstrap.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="../../Resource/Scripts/js/plugins/morris/raphael.min.js"></script>

    <script src="../../Resource/Scripts/js/plugins/morris/morris.min.js" type="text/javascript"></script>

    <script src="../../Resource/Scripts/js/plugins/morris/morris-data.js" type="text/javascript"></script>

    <%--<script src="../../Resource/js/bootstrap.min.js"></script>   
    <script src="../../Resource/js/plugins/morris/raphael.min.js"></script>
    <script src="../../Resource/js/plugins/morris/morris.min.js"></script>
    <script src="../../Resource/js/plugins/morris/morris-data.js"></script>--%>
    <link href="../../Resource/Styles/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/css/sb-admin.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/css/plugins/morris.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/font-awesome/css/font-awesome.css" rel="stylesheet"
        type="text/css" />
    <%--<link href="../../Resource/css/bootstrap.min.css"rel="stylesheet" type="text/css" />   
    <link href="../../Resource/css/sb-admin.css" rel="stylesheet" type="text/css" />   
    <link href="../../Resource/css/plugins/morris.css" rel="stylesheet" type="text/css" />--%>
    <%--<link href="../../Resource/font-awesome/css/font-awesome.css" rel="stylesheet" type="text/css" />--%>
    <%--<link href="assets/css/basic.css" rel="stylesheet" />--%>
    <link href="../../Resource/Styles/GridViewStyles.css" rel="stylesheet" />
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

        .style6
        {
            width: 192px;
        }

        .style7
        {
            color: #FF3300;
        }

        .style8
        {
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
        function SavedWaterSourceDtls() {

            alert('Water Source Details Saved Successfully');
        }
    </script>
    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>

    <script type="text/javascript">
        function inputOnlyNumbers(evt) {
            var e = window.event || evt; // for trans-browser compatibility  
            var charCode = e.which || e.keyCode;
            if ((charCode > 45 && charCode < 58) || charCode == 8) {
                return true;
            }
            return false;
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="scmRTOPermit">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="upd1" runat="server">
            <ContentTemplate>
               <%-- <div align="left">
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
                            <i class="fa fa-edit"></i><a href="#">PCB Details</a>
                        </li>
                    </ol>
                </div>--%>

                <div align="left">
                    <div class="row" align="left">
                        <div class="col-lg-11">
                            <div class="panel panel-primary">
                                <div class="panel-heading" align="center">
                                    <h3 class="panel-title">Water Consumption/Effluent</h3>
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="panel-body">
                                            <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">

                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" valign="top" colspan="3">
                                                        <asp:Label ID="Label422" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                            Width="510px">Details for Pollution Control Board<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                </tr>


<%--                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" colspan="4">Water Consumption/Effluent</td>

                                                </tr>--%>
                                                <tr>
                                                    <td colspan="4" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">Water Source Details <font 
                                                            color="red">*</font>
                                                     
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <%--<asp:Label ID="Label1" runat="server"></asp:Label>--%>
                                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="13px"
                                                            ForeColor="Green" Style="position: static"></asp:Label>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" colspan="4">
                                                        <asp:GridView ID="gvWaterSourceDtls" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvWaterSourceDtls_RowCommand" OnRowDataBound="gvWaterSourceDtls_RowDataBound">
                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sl No.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>


                                                                <asp:TemplateField HeaderText="Source Type">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlSourceType" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Source Name">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtSourceName" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Quantity (KLD)<br/>(only Numeric/Decimal)">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtSourceQuantity" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:ButtonField CommandName="Add" Text="Add">
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:ButtonField>
                                                                <asp:ButtonField CommandName="Remove" Text="Delete">
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:ButtonField>
                                                            </Columns>
                                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#B9D684" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td colspan="4" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <asp:Button ID="btnSaveWaterSourceDtls" runat="server" CssClass="btn btn-primary" Height="32px" Text="Save Water Source Details" ValidationGroup="group" Width="200px" OnClick="btnSaveWaterSourceDtls_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">Average Daily consumption of water <font 
                                                            color="red">*</font></td>

                                                </tr>
                                                <tr>
                                                    <%-- <td colspan="4" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" class="alert alert-success">
                                                    <asp:Label ID="lblConsumption" runat="server"></asp:Label>
                                                </td>--%>
                                                    <td colspan="4" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <%-- <asp:Label ID="lblConsumption" runat="server"></asp:Label>--%>
                                                        <asp:Label ID="lblConsumption" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="13px"
                                                            ForeColor="Green" Style="position: static"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <asp:GridView ID="gvWaterConsumption" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvWaterConsumption_RowCommand" OnRowDataBound="gvWaterConsumption_RowDataBound">
                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sl No.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Purpose">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlWaterConsumpPurpose" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Quantity (KLD)<br/>(only Numeric/Decimal)">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtWaterQuantity" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:ButtonField CommandName="Add" Text="Add">
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:ButtonField>
                                                                <asp:ButtonField CommandName="Remove" Text="Delete">
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:ButtonField>
                                                            </Columns>
                                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#B9D684" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <asp:Button ID="btnWaterConsumption" runat="server" CssClass="btn btn-primary" Height="32px" Text="Save Consumption of Water" ValidationGroup="group" Width="222px" OnClick="btnWaterConsumption_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">Waste Water Discharge Details</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <%-- <asp:Label ID="lblWasteWater" runat="server"></asp:Label>--%>
                                                        <asp:Label ID="lblWasteWater" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="13px"
                                                            ForeColor="Green" Style="position: static"></asp:Label>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" colspan="4">
                                                        <asp:GridView ID="gvWasteWaterDtls" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvWasteWaterDtls_RowCommand" OnRowDataBound="gvWasteWaterDtls_RowDataBound">
                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sl No.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Source">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlWasteWaterSource" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Quantity (KLD)<br/>(only Numeric/Decimal)">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtWasteWaterQuantity" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:ButtonField CommandName="Add" Text="Add">
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:ButtonField>
                                                                <asp:ButtonField CommandName="Remove" Text="Delete">
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:ButtonField>
                                                            </Columns>
                                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#B9D684" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <asp:Button ID="btnWasteWaterDtls" runat="server" CssClass="btn btn-primary" Height="32px" Text="Save Waste Water Discharge Details" ValidationGroup="group" Width="266px" OnClick="btnWasteWaterDtls_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">Other specific toxic substance is discharged? </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <%--<asp:Label ID="lblToxic" runat="server"></asp:Label>--%>
                                                        <asp:Label ID="lblToxic" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="13px"
                                                            ForeColor="Green" Style="position: static"></asp:Label>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" colspan="4">
                                                        <asp:GridView ID="gvToxic" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvToxic_RowCommand" OnRowDataBound="gvToxic_RowDataBound">
                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sl No.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Source">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlToxicSource" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Toxic Substance">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlToxicSubstance" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Name">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtToxicName" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Quantity (KLD)">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtToxicQuantity" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:ButtonField CommandName="Add" Text="Add">
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:ButtonField>
                                                                <asp:ButtonField CommandName="Remove" Text="Delete">
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:ButtonField>
                                                            </Columns>
                                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#B9D684" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td colspan="4" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <asp:Button ID="btnToxicDtls" runat="server" CssClass="btn btn-primary" Height="32px" Text="Save Toxic Substance Discharge Details" ValidationGroup="group" Width="287px" OnClick="btnToxicDtls_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">Point of Final Discharge </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <%--<asp:Label ID="lblFinalDischarge" runat="server"></asp:Label>--%>
                                                        <asp:Label ID="lblFinalDischarge" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="13px"
                                                            ForeColor="Green" Style="position: static"></asp:Label>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" colspan="4">
                                                        <asp:GridView ID="gvFinalDischarge" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvFinalDischarge_RowCommand" OnRowDataBound="gvFinalDischarge_RowDataBound">
                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sl No.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Source">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlDischrgeSource" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Point of Discharge">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlPointofDischarge" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>

                                                                <asp:ButtonField CommandName="Add" Text="Add">
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:ButtonField>
                                                                <asp:ButtonField CommandName="Remove" Text="Delete">
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:ButtonField>
                                                            </Columns>
                                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#B9D684" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <asp:Button ID="btnFinalDischargeDtls" runat="server" CssClass="btn btn-primary" Height="32px" Text="Save Final Discharge Details" ValidationGroup="group" Width="226px" OnClick="btnFinalDischargeDtls_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">Physical Characteristics Details </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <%--<asp:Label ID="lblPhysicalChar" runat="server"></asp:Label>--%>
                                                        <asp:Label ID="lblPhysicalChar" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="13px"
                                                            ForeColor="Green" Style="position: static"></asp:Label>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" colspan="4">
                                                        <asp:GridView ID="gvPhysicalChars" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvPhysicalChars_RowCommand" OnRowDataBound="gvPhysicalChars_RowDataBound">
                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sl No.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Source">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlPhyCharSource" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Temperature(degree C):">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtPhyCharTemperature" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="PH:">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtPhyCharPH" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Colour:">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtPhyCharColour" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Turbidity(JTU/NTU):">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtPhyCharTurbidity" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Odour:">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtPhyCharOdour" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total Solids(mg/L):">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtPhyCharTotalSolids" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total Suspended Solids(mg/L):">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtPhyCharSuspendSolids" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total Volatile Solids(mg/L):">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtPhyCharVolatileSolids" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:ButtonField CommandName="Add" Text="Add">
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:ButtonField>
                                                                <asp:ButtonField CommandName="Remove" Text="Delete">
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:ButtonField>
                                                            </Columns>
                                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#B9D684" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <asp:Button ID="btnPhysicalCharDtls" runat="server" CssClass="btn btn-primary" Height="32px" Text="Save Physical Characteristics Details" ValidationGroup="group" Width="274px" OnClick="btnPhysicalCharDtls_Click" />
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td colspan="4" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">Chemical Characteristics Details </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <%--  <asp:Label ID="lblChemicalChar" runat="server"></asp:Label>--%>
                                                        <asp:Label ID="lblChemicalChar" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="13px"
                                                            ForeColor="Green" Style="position: static"></asp:Label>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" colspan="4">
                                                        <asp:GridView ID="gvChemicalChars" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvChemicalChars_RowCommand" OnRowDataBound="gvChemicalChars_RowDataBound">
                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sl No.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Source">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlChemicalCharSource" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Acidity(mg/L): ">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtAcidity" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Alkalinity(mg/L):">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtAlkalinity" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Hardness(ppm): ">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtHardness" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="B.O.D.(mg/L): ">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtBOD" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="C.O.D.(mg/L):">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtCOD" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Oil & Greases(mg/L):">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtOilGreases" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total Nitrogen Phosphate(mg/L):">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtTotalNitrogen" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Sulphates(mg/L):">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtSulphates" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total Phosphates(mg/L):">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtPhosphate" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total Chloride(mg/L):">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtChloride" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Sodium(%):">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtSodium" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Potassium(mg/L):">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtPotassium" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Calcium(mg/L):">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtCalcium" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Magnesium(mg/L):">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtMagnesium" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:ButtonField CommandName="Add" Text="Add">
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:ButtonField>
                                                                <asp:ButtonField CommandName="Remove" Text="Delete">
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:ButtonField>
                                                            </Columns>
                                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#B9D684" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td colspan="4" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <asp:Button ID="btnChemicalChar" runat="server" CssClass="btn btn-primary" Height="32px" Text="Save Chemical Characteristics Details" ValidationGroup="group" Width="294px" OnClick="btnChemicalChar_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">Other Characteristics Details </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <%--<asp:Label ID="lblOtherChar" runat="server"></asp:Label>--%>
                                                        <asp:Label ID="lblOtherChar" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="13px"
                                                            ForeColor="Green" Style="position: static"></asp:Label>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" colspan="4">
                                                        <asp:GridView ID="gvOtherCharacterstics" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvOtherCharacterstics_RowCommand" OnRowDataBound="gvOtherCharacterstics_RowDataBound">
                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sl No.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Source">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlOtherCharSource" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Item">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtOtherCharItemName" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Quantity">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtOtherCharQuantity" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Units">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlOtherCharUnits" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:ButtonField CommandName="Add" Text="Add">
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:ButtonField>
                                                                <asp:ButtonField CommandName="Remove" Text="Delete">
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:ButtonField>
                                                            </Columns>
                                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#B9D684" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td colspan="4" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <asp:Button ID="btnOtherCharDtls" runat="server" CssClass="btn btn-primary" Height="32px" Text="Save Other Characteristics Details" ValidationGroup="group" Width="273px" OnClick="btnOtherCharDtls_Click" />
                                                    </td>
                                                </tr>

                                                <%--                                             <tr>
                                                <td colspan="4" style="padding: 5px; margin: 5px; text-align: center; font-weight: bold">
                                                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Height="32px" Text="Save Details" ValidationGroup="group" Width="233px" OnClick="btnSave_Click"  />
                                                </td>
                                            </tr>--%>
                                                <%--  <tr>
                                                <td align="center" colspan="3"
                                                    style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary"
                                                        Height="32px" OnClick="BtnSave_Click" TabIndex="10" Text="Save"
                                                        Width="90px" ValidationGroup="group" />
                                                    &nbsp;
                                            <asp:Button ID="BtnDelete0" runat="server"
                                                CssClass="btn btn-danger" Height="32px" OnClick="BtnDelete0_Click" TabIndex="10"
                                                Text="Previous" Width="90px" CausesValidation="False" />

                                                    &nbsp;&nbsp;<asp:Button ID="BtnDelete" runat="server"
                                                        CssClass="btn btn-danger" Height="32px" OnClick="BtnClear0_Click" TabIndex="10"
                                                        Text="Next" Width="90px"
                                                        ValidationGroup="group" />

                                                    &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                                        CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                                        Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />
                                                </td>
                                            </tr>--%>
                                                <tr>
                                                    <td align="center" colspan="3" style="padding: 5px; margin: 5px">


                                                        <div id="success" runat="server" visible="false" class="alert alert-success">
                                                            <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                                            <strong>Success!</strong><asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                        </div>


                                                        <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                                            <strong>Warning!</strong>
                                                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
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
                                            <asp:HiddenField ID="hdfFlagID0" runat="server" />
                                            <asp:HiddenField ID="hdfpencode" runat="server" />
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
    </form>
</body>
</html>


