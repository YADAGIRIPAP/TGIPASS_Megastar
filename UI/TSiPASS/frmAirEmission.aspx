<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="frmAirEmission.aspx.cs" Inherits="UI_TSiPASS_frmAirEmission" %>


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


                <div align="left">
                    <div class="row" align="left">
                        <div class="col-lg-11">
                            <div class="panel panel-primary">
                                <div class="panel-heading" align="center">
                                    <h3 class="panel-title">Air Emission</h3>
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="panel-body">
                                            <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">

                                                <%--  <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:Label ID="Label422" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                        Width="510px">Details for Pollution Control Board<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                            </tr>--%>


                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">Air Emission</td>

                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">Stack Details</td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <asp:Label ID="lblStackDetails" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="13px" ForeColor="Green" Style="position: static"></asp:Label>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <asp:GridView ID="gvStackDetails" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvStackDetails_RowCommand" OnRowDataBound="gvStackDetails_RowDataBound">
                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sl No.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Stack Attached To D.G Set/Boilers/Furnace/Cupolas/Others*">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtStackAttached" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Stack Height above the roof(In mts)*">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtStackHeight" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Temperature('C)">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtTemperature" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Expected Quantity">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtQuantity" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Air Pollution Control System">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtControlSystem" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Diameter(In mts)">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtDiameter" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Flow Rate">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtFlow" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Stack Height above Ground Level(In mts)">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtHeightGround" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Stack Top">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlStackTop" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                            <asp:ListItem Value="Round/Circular">Round/Circular</asp:ListItem>
                                                                            <asp:ListItem Value="Inside Dimension at Top">Inside Dimension at Top</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Are any Standard of Emission prescribed for or adopted by your Industry?">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlEmission" runat="server" Height="33px">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Number of Stack :">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtNumber" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
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
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <asp:Button ID="btnSaveStackDetails" runat="server" CssClass="btn btn-primary" Height="32px" OnClick="btnSaveStackDetails_Click" Text="Save Stack Details" ValidationGroup="group" Width="200px" />
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">Composition of emissions(Nature of Dust)</td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <asp:Label ID="lblDust" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="13px" ForeColor="Green" Style="position: static"></asp:Label>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <asp:GridView ID="gvCompDust" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvCompDust_RowCommand" OnRowDataBound="gvCompDust_RowDataBound">
                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sl No.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Stack Name*">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlStackNameDust" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Nature of Dust :">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtNature" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Quantity:">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtQuantity" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
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
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <asp:Button ID="btnSaveStackDust" runat="server" CssClass="btn btn-primary" Height="32px" OnClick="btnSaveStackDust_Click" Text="Save Stack Nature of Dust Details" ValidationGroup="group" Width="250px" />
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">Composition of emissions For Process(Gases)</td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <asp:Label ID="lblGases" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="13px" ForeColor="Green" Style="position: static"></asp:Label>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <asp:GridView ID="gvCompGases" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvCompGases_RowCommand" OnRowDataBound="gvCompGases_RowDataBound">
                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sl No.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Stack Name*">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlStackNameGases" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Gases:">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlCompGases" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Quantity:">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtQuantity" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
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
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <asp:Button ID="btnSaveNatureofGases" runat="server" CssClass="btn btn-primary" Height="32px" OnClick="btnSaveNatureofGases_Click" Text="Save Stack Gases Details" ValidationGroup="group" Width="200px" />
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">Emission from Process Fugitive Sources</td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <asp:Label ID="lblFug" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="13px" ForeColor="Green" Style="position: static"></asp:Label>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <asp:GridView ID="gvFugitive" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvFugitive_RowCommand" OnRowDataBound="gvFugitive_RowDataBound">
                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sl No.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Stack Attached To D.G Set/Boilers/Furnace/Cupolas/Others*">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtFugStackAttached" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Stack Height above the roof(In mts)*">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtFugStackHeight" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Temperature('C)">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtFugTemperature" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Expected Quantity">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtFugQuantity" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Air Pollution Control System">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtFugControlSystem" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Diameter(In mts)">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtFugDiameter" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Flow Rate">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtFugFlow" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Stack Height above Ground Level(In mts)">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtFugHeightGround" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Stack Top">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlFugStackTop" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                            <asp:ListItem>Round/Circular</asp:ListItem>
                                                                            <asp:ListItem>Inside Dimension at Top</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Are any Standard of Emission prescribed for or adopted by your Industry?">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlFugEmission" runat="server" Height="33px">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                            <asp:ListItem>Yes</asp:ListItem>
                                                                            <asp:ListItem>No</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Number of Stack :">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtFugNumber" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
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
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <asp:Button ID="btnSaveFugitive" runat="server" CssClass="btn btn-primary" Height="32px" OnClick="btnSaveFugitive_Click" Text="Save Fugitive Stack Sources Details" ValidationGroup="group" Width="200px" />
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">Composition of emissions(Emissions from fuel burning)
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <asp:Label ID="lblFuelBurning" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="13px" ForeColor="Green" Style="position: static"></asp:Label>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <asp:GridView ID="gvFDust" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvFDust_RowCommand" OnRowDataBound="gvFDust_RowDataBound">
                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sl No.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Stack Name*">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlFStackNameDust" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Nature of Dust :">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtFNature" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Quantity:">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtFQuantity" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
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
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <asp:Button ID="btnSaveFuelBurning" runat="server" CssClass="btn btn-primary" Height="32px" OnClick="btnSaveFuelBurning_Click" Text="Save Emissions from fuel burning" ValidationGroup="group" Width="282px" />
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">Composition of emissions of Fuel Burning(Gases)
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <asp:Label ID="lblFuelBurnGas" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="13px" ForeColor="Green" Style="position: static"></asp:Label>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <asp:GridView ID="gvFGases" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvFGases_RowCommand" OnRowDataBound="gvFGases_RowDataBound">
                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sl No.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Stack Name*">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlFStackNameGases" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Gases:">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlFCompGases" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Quantity:">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtFQuantity" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
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
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <asp:Button ID="btnSaveFuelBurnGas" runat="server" CssClass="btn btn-primary" Height="32px" OnClick="btnSaveFuelBurnGas_Click" Text="Save Emissions of Fuel Burning(Gases)" ValidationGroup="group" Width="301px" />
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">Fuel used Details:
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <asp:Label ID="lblFuel" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="13px" ForeColor="Green" Style="position: static"></asp:Label>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <asp:GridView ID="gvFuel" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvFuel_RowCommand" OnRowDataBound="gvFuel_RowDataBound">
                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sl No.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Name of Fuel">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtFuelName" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Daily Consumption">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtFuelConsump" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Purpose">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlFuelPurpose" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <ItemStyle CssClass="scroll_td" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Unit">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlFuelCharUnits" runat="server" class="form-control txtbox" Height="33px" Width="180px">
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
                                                    <td style="padding: 5px; margin: 5px; text-align: center; font-weight: bold">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                                        <asp:Button ID="btnSaveFuelUsed" runat="server" CssClass="btn btn-primary" Height="32px" OnClick="btnSaveFuelUsed_Click" Text="Save Fuel used Details" ValidationGroup="group" Width="200px" />
                                                    </td>

                                                </tr>


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
                                                    <td align="center" style="padding: 5px; margin: 5px">


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

