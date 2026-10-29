<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="InspectionReportNew.aspx.cs" Inherits="UI_TSiPASS_InspectionReportNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <%-- <style type="text/css">
        .GridviewDiv {
            font-size: 100%;
            font-family: 'Lucida Grande', 'Lucida Sans Unicode', Verdana, Arial, Helevetica, sans-serif;
            color: #303933;
        }

        .headerstyle {
            color: #FFFFFF;
            border-right-color: #abb079;
            border-bottom-color: #abb079;
            background-color: #df5015;
            padding: 0.5em 0.5em 0.5em 0.5em;
            text-align: center;
        }

        #content {
            float: left;
            width: 620px;
        }
    </style>

    <style type="text/css">
        .nav-pills.nav-wizard > li {
            position: relative;
            overflow: visible;
            border-right: 15px solid transparent;
            border-left: 15px solid transparent;
        }

            .nav-pills.nav-wizard > li + li {
                margin-left: 0;
            }

            .nav-pills.nav-wizard > li:first-child {
                border-left: 0;
            }

                .nav-pills.nav-wizard > li:first-child a {
                    border-radius: 5px 0 0 5px;
                }

            .nav-pills.nav-wizard > li:last-child {
                border-right: 0;
            }

                .nav-pills.nav-wizard > li:last-child a {
                    border-radius: 0 5px 5px 0;
                }

            .nav-pills.nav-wizard > li a {
                border-radius: 0;
                background-color: #eee;
            }

            .nav-pills.nav-wizard > li:not(:last-child) a:after {
                position: absolute;
                content: "";
                top: 0px;
                right: -20px;
                width: 0px;
                height: 0px;
                border-style: solid;
                border-width: 20px 0 20px 20px;
                border-color: transparent transparent transparent #eee;
                z-index: 150;
            }

            .nav-pills.nav-wizard > li:not(:first-child) a:before {
                position: absolute;
                content: "";
                top: 0px;
                left: -20px;
                width: 0px;
                height: 0px;
                border-style: solid;
                border-width: 20px 0 20px 20px;
                border-color: #eee #eee #eee transparent;
                z-index: 150;
            }

            .nav-pills.nav-wizard > li:hover:not(:last-child) a:after {
                border-color: transparent transparent transparent #aaa;
            }

            .nav-pills.nav-wizard > li:hover:not(:first-child) a:before {
                border-color: #aaa #aaa #aaa transparent;
            }

            .nav-pills.nav-wizard > li:hover a {
                background-color: #aaa;
                color: #fff;
            }

            .nav-pills.nav-wizard > li.active:not(:last-child) a:after {
                border-color: transparent transparent transparent #428bca;
            }

            .nav-pills.nav-wizard > li.active:not(:first-child) a:before {
                border-color: #428bca #428bca #428bca transparent;
            }

            .nav-pills.nav-wizard > li.active a {
                background-color: #428bca;
            }



        .button {
            background-color: #004A7F;
            -webkit-border-radius: 10px;
            border-radius: 10px;
            border: none;
            color: #FFFFFF;
            cursor: pointer;
            display: inline-block;
            font-family: Arial;
            font-size: 15px;
            padding: 5px 10px;
            text-align: center;
            text-decoration: none;
        }

        @-webkit-keyframes glowing {
            0% {
                background-color: #337ab7;
                -webkit-box-shadow: 0 0 1px #337ab7;
            }

            50% {
                background-color: #204d74;
                -webkit-box-shadow: 0 0 20px #204d74;
            }

            100% {
                background-color: #337ab7;
                -webkit-box-shadow: 0 0 1px #337ab7;
            }
        }

        @-moz-keyframes glowing {
            0% {
                background-color: #337ab7;
                -moz-box-shadow: 0 0 1px #337ab7;
            }

            50% {
                background-color: #204d74;
                -moz-box-shadow: 0 0 20px #204d74;
            }

            100% {
                background-color: #337ab7;
                -moz-box-shadow: 0 0 1px #337ab7;
            }
        }



        @keyframes glowing {
            0% {
                background-color: #337ab7;
                box-shadow: 0 0 1px #337ab7;
            }

            50% {
                background-color: #204d74;
                box-shadow: 0 0 20px #204d74;
            }

            100% {
                background-color: #337ab7;
                box-shadow: 0 0 1px #337ab7;
            }
        }

        .button {
            -webkit-animation: glowing 1500ms infinite;
            -moz-animation: glowing 1500ms infinite;
            -o-animation: glowing 1500ms infinite;
            animation: glowing 1500ms infinite;
        }

        .wizard > .content {
            height: 850px;
            width: 1085px;
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

        .lblinv {
            font-weight: bolder;
            color: Red;
        }

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
    <style type="text/css">
        .tooltipDemo {
            position: relative;
            display: inline;
            text-decoration: none;
            left: 0px;
            top: 0px;
        }

            .tooltipDemo:hover:before {
                border: solid;
                border-color: transparent rgb(111, 13, 53);
                border-width: 6px 6px 6px 0px;
                bottom: 21px;
                content: "";
                left: 35px;
                top: 5px;
                position: absolute;
                z-index: 95;
            }

            .tooltipDemo:hover:after {
                /*background: rgb(111, 13, 53);*/
                background: #2184be;
                border-radius: 5px;
                color: #fff;
                width: 300px;
                left: 40px;
                top: -5px;
                content: attr(alt);
                position: absolute;
                padding: 5px 15px;
                z-index: 95;
            }

        .LBLBLACK {
            top: 0px;
            left: 0px;
        }


        /*.auto-style1 {
            width: 288px;
        }

        .auto-style2 {
            width: 277px;
        }*/

        .auto-style41 {
            margin-left: 0px;
        }
    </style>--%>
    <script type="text/javascript">
        function inputOnlyNumbers(evt) {
            var e = window.event || evt; // for trans-browser compatibility  
            var charCode = e.which || e.keyCode;
            if ((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) {
                return true;
            }
            return false;
        }


        function Names() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue == 46) || (AsciiValue == 32))
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter Alphabets, '.' and Space Only");
            }
        }
    </script>
    <style type="text/css">
        .headerStyle
        {
            background-color: #FF6600;
            color: #FFFFFF;
            font-size: 12pt;
            font-weight: bold;
        }
        
        .itemStyle
        {
            background-color: #FFFFEE;
            color: #000000;
            font-size: 8pt;
        }
        
        .alternateItemStyle
        {
            background-color: #FFFFFF;
            color: #000000;
            font-size: 8pt;
        }
    </style>
    <asp:UpdatePanel ID="updIncInspcRprt" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="BtnSave3" />
        </Triggers>
        <ContentTemplate>
            <asp:HiddenField ID="hdfFlagID" runat="server" />
            <asp:HiddenField ID="hdfFlagID0" runat="server" />
            <asp:HiddenField ID="hdfpencode" runat="server" />
            <%--<div class="panel-heading">
                <h3 class="panel-title"> </h3>
            </div>--%>
            <div id="divprint">
                <table style="width: 100%">
                    <tr>
                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: top; font-weight: bold;
                            font-size: medium;">
                            Inspection Report for Investment Subsidy
                        </td>
                        <td colspan="9" style="padding: 5px; margin: 5px; font-weight: bold; text-align: right;
                            font-size: medium;">
                            (All <font color="red">*</font> fields are mandatory)
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 30px" colspan="2">
                        </td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr>
                        <td style="padding: 5px; margin: 5px; vertical-align: top; font-weight: bold; font-size: medium;">
                            1.0
                        </td>
                        <td colspan="9" style="padding: 5px; margin: 5px; font-weight: bold; font-size: medium;">
                            Unit Inspection Details
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top" valign="top">
                            1.1
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top; width: 220px">
                            Name and Address of the Industry <font color="red">*</font>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:Label ID="lblnameofIND" runat="server" Width="150px" TabIndex="1"></asp:Label>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            1.2
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            Name of the Inspecting Officer <font color="red">*</font>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtIPOName" class="form-control txtbox" Height="28px" MaxLength="80"
                                TabIndex="2" ValidationGroup="group" runat="server" Width="150px"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            1.3
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            Designation <font color="red">*</font>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:Label ID="lblIPODesignation" runat="server" Width="150px" TabIndex="3"></asp:Label>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            1.4
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            Date(s) of Inspection <font color="red">*</font>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtInpectedDate" Width="150px" class="form-control txtbox" Height="28px"
                                MaxLength="80" TabIndex="4" ValidationGroup="group" runat="server"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            1.5
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            Constitution. <font color="red">*</font>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:DropDownList ID="ddlUnitCons" class="form-control txtbox" Width="150px" runat="server"
                                TabIndex="5">
                            </asp:DropDownList>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            1.6
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top; width: 220px">
                            Person (from Industry) present at the time of Inspection. <font color="red">*</font>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtPersonIndustry" Width="150px" class="form-control txtbox" Height="28px"
                                MaxLength="100" TabIndex="6" ValidationGroup="group" runat="server"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top" valign="top">
                            1.7
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            Status of Industry <font color="red">*</font>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:DropDownList ID="ddlStatus" TabIndex="7" Enabled="true" class="form-control txtbox"
                                Width="150px" runat="server" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged"
                                AutoPostBack="true">
                                <asp:ListItem>--Select--</asp:ListItem>
                                <asp:ListItem Value="1">New Industry</asp:ListItem>
                                <asp:ListItem Value="2">Expansion</asp:ListItem>
                                <asp:ListItem Value="3">Diversification</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top" valign="top">
                            <asp:Label ID="lblIsDlcSlc" runat="server" Text="1.8"></asp:Label>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:Label ID="lblhIsdlcslc" runat="server" Text="Whether is DLC (or) SLC"></asp:Label>
                            <font color="red">*</font>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:RadioButtonList ID="rblDLCSLC" runat="server" Height="16px" RepeatDirection="Horizontal"
                                Width="200px" TabIndex="7">
                                <asp:ListItem Value="DLC">DLC</asp:ListItem>
                                <asp:ListItem Value="SLC">SLC</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top" valign="top">
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:CheckBox ID="chkMobileUnit" runat="server" TabIndex="7" />
                            <asp:Label AssociatedControlID="chkMobileUnit" ID="lblMobileUnit" runat="server"
                                Text="Is it mobile unit" Style="padding-left: 10px; font-weight: bold"></asp:Label>
                        </td>
                        <td style="margin: 5px; vertical-align: top">
                        </td>
                        <td style="margin: 5px; vertical-align: top">
                        </td>
                        <td style="margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="margin: 5px; font-weight: bold; vertical-align: top" valign="top">
                        </td>
                        <td style="margin: 5px; vertical-align: top">
                        </td>
                        <td style="margin: 5px; vertical-align: top">
                        </td>
                        <td style="margin: 5px; vertical-align: top">
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr style="height: 30px">
                        <td colspan="10">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; font-size: medium">
                            2.0
                        </td>
                        <td colspan="9" style="padding: 5px; margin: 5px; font-weight: bold; font-size: medium">
                            Verification Certificate <font color="red">*</font>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top" valign="top">
                        </td>
                        <td style="padding: 5px; margin: 5px; width: 520px" colspan="6">
                            Certified that contents of the claim under Part-A and the document indicated in
                            Part-c of this claim application were verified and found correct. The plant and
                            machinery and equipment was physically verified as per the statement of machinery
                            and found them duly installed and put on work . Further certified that the fixed
                            assets claimed for incentives are essentially required for carrying the production
                            in which the industry is engaged in.
                        </td>
                        <td style="padding: 5px; margin: 5px; font-weight: bold" colspan="2" valign="top">
                            <asp:RadioButtonList ID="rdbVerifyCert" runat="server" Height="16px" RepeatDirection="Horizontal"
                                Width="200px" TabIndex="8">
                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                <asp:ListItem Value="2">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr style="height: 30px">
                        <td colspan="10">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; font-size: medium">
                            3.0
                        </td>
                        <td colspan="9" style="padding: 5px; margin: 5px; font-weight: bold; font-size: medium">
                            Project Details
                        </td>
                    </tr>
                    <tr>
                        <%--&nbsp;→&nbsp;&nbsp;--%>
                        <td colspan="10" style="padding: 5px; margin: 5px; font-weight: bold;">
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Underline="True"></asp:Label>
                        </td>
                    </tr>
                    <tr align="left" id="trNewindusNew" runat="server" visible="false">
                        <td colspan="10" style="padding: 5px; margin: 5px;" align="left">
                            <asp:GridView ID="gvNewindus" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                GridLines="Both" OnRowDataBound="gvNewindus_RowDataBound" Width="90%" AllowSorting="True"
                                HorizontalAlign="Center">
                                <RowStyle VerticalAlign="Middle" BackColor="#ffffff" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Sl.No" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="10px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Line Of Activity" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtLOA" runat="server" class="form-control txtbox" Height="28px" oncopy="return false" onpaste="return false" oncut="return false"
                                                Text='<%# Eval("LineOfActivity")%>'></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Installed Capacity" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtInstalledCapacity" runat="server" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false"  onkeypress="return inputOnlyNumbers(event)" 
                                                Height="28px" Text='<%# Eval("InstalledCapacity")%>'></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtUnit" runat="server" class="form-control txtbox" Height="28px" oncopy="return false" onpaste="return false" oncut="return false"
                                                Text='<%# Eval("NameOfUnit")%>'></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Value" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtValue" runat="server" class="form-control txtbox" Height="28px" oncopy="return false" onpaste="return false" oncut="return false"  onkeypress="return inputOnlyNumbers(event)" 
                                                Text='<%# Eval("Value")%>'></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                    </asp:TemplateField>
                                    <%--<asp:BoundField DataField="LineOfActivity" HeaderText="Line Of Activity" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="InstalledCapacity" HeaderText="Installed Capacity" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NameOfUnit" HeaderText="Unit" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Value" HeaderText="Value" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>--%>
                                    <%--<asp:BoundField DataField="Created_by" HeaderText="Created By" Visible="false" />
                                <asp:BoundField DataField="IncentiveId" HeaderText="Incentive Id" Visible="false" />--%>
                                </Columns>
                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" BorderColor="#003399" />
                                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px"
                                    HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"
                                    Font-Names="Arial" Font-Size="9px" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="10" style="padding: 5px; margin: 5px; font-weight: bold;">
                            <%--&nbsp;→&nbsp;&nbsp;--%>
                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Underline="True"></asp:Label>
                        </td>
                        <tr id="trExpansionDriverNew" runat="server" align="left" visible="false">
                            <td align="left" colspan="10" style="padding: 5px; margin: 5px 5px 5px 125px;">
                                <asp:GridView ID="gvExpansionDriverNew" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="myGridClass"
                                    GridLines="Both" HorizontalAlign="Center" OnRowDataBound="gvExpansionDriverNew_RowDataBound"
                                    Width="90%">
                                    <RowStyle VerticalAlign="Middle" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sl.No" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="10px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="StatusIndustry" HeaderText="Project" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Left" Width="50px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Line Of Activity" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtLOA" runat="server" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false" Height="28px"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Installed Capacity" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtInstalledCapacity" runat="server" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false"
                                                    Height="28px" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" Width="10px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Units" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtUnits" runat="server" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false" Height="28px"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" Width="10px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="% of increase under Expansion/ Diversification Project"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtExpansionDiversification" runat="server" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false"
                                                    Height="28px" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="10px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                    <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px"
                                        HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"
                                        Font-Names="Arial" Font-Size="9px" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr style="height: 30px">
                        <td colspan="10" style="padding: 5px; margin: 5px; font-weight: bold; font-size: medium">
                            &nbsp;
                        </td>
                    </tr>
                    <tr style="height: 30px">
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top; width: 30px">
                            3.3
                        </td>
                        <td colspan="9" style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top;
                            font-size: medium" align="left">
                            Fixed Capital Investment of the Expansion / Diversification Project (in Rs.)
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; font-size: medium">
                        </td>
                        <td colspan="9" style="padding: 5px; margin: 5px; font-size: medium">
                            <table style="width: 100%">
                                <tr align="left" id="trFixedCapitalInvestment" runat="server" visible="false">
                                    <td colspan="10" style="padding: 5px; margin: 5px;" align="left">
                                        <asp:GridView ID="gvFixedCapitalInvestment" CssClass="myGridClass" runat="server"
                                            AutoGenerateColumns="False" BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px"
                                            CellPadding="4" GridLines="Both" Width="100%" AllowSorting="True" HorizontalAlign="Center">
                                            <RowStyle VerticalAlign="NotSet" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sl.No" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="10px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="NatureofAssets" HeaderText="Nature of Assets" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Existing Enterprise" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtExistingEnterprise" runat="server" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false" AutoCompleteType="Disabled"
    autocomplete="off"
                                                            Height="28px" onkeypress="return inputOnlyNumbers(event)" OnTextChanged="txtExistingEnterprise_TextChanged"
                                                            AutoPostBack="true"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="10px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Expansion/ Diversification Project" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtExpansionDiversification" runat="server" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false" AutoCompleteType="Disabled"
    autocomplete="off"
                                                            Height="28px" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="10px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="% of increase under Expansion/ Diversification Project"
                                                    ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtExpansionDiversificationincreasepercentage" runat="server" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false"  AutoCompleteType="Disabled"
    autocomplete="off"
                                                            Height="28px" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="10px" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                            <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px"
                                                HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                            <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"
                                                Font-Names="Arial" Font-Size="9px" />
                                        </asp:GridView>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px; font-weight: bold; font-size: medium; text-align: left"
                                        valign="top">
                                        Total <font color="red">*</font>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; vertical-align: top; text-align: center">
                                        :
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">
                                        <asp:TextBox ID="txttotalNew" runat="server" class="form-control txtbox" Height="30px"
                                            MaxLength="80" TabIndex="9" ValidationGroup="group" Width="150px" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; font-size: medium">
                        </td>
                        <td colspan="9" style="padding: 5px; margin: 5px; font-weight: bold; font-size: medium">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">
                            3.4
                        </td>
                        <td style="padding: 5px; margin: 5px; width: 220px" valign="top">
                            Date of commencement of Production <font color="red">*</font>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px;">
                            <asp:TextBox ID="lblDCP" runat="server" class="form-control txtbox" Height="30px"
                                MaxLength="80" TabIndex="10" ValidationGroup="group" Placeholder="DD/MM/YYYY"
                                Width="150px"></asp:TextBox>
                            <asp:Label ID="txtCalenderDCP" runat="server" Visible="false" TabIndex="10"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">
                            3.5
                        </td>
                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                            Date of receipt of claim application <span style="font-weight: normal; color: Red;">
                                *</span>
                        </td>
                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                            <asp:TextBox ID="txtRcptAppln" runat="server" class="form-control txtbox" TabIndex="11"
                                Enabled="false" Width="150px" ValidationGroup="group" Height="30px" MaxLength="80"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top" valign="top">
                            3.6
                        </td>
                        <td style="text-align: left; padding: 5px; margin: 5px;" valign="top">
                            Date of Query Raised
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="text-align: left; padding: 5px; margin: 5px;" valign="top">
                            <asp:TextBox ID="txtDateShrtfall" runat="server" class="form-control txtbox" Height="30px"
                                MaxLength="80" TabIndex="12" ValidationGroup="group" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">
                            3.7
                        </td>
                        <td style="text-align: left; padding: 5px; margin: 5px;" valign="top">
                            Date of Query Responded
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="text-align: left; padding: 5px; margin: 5px;">
                            <asp:TextBox ID="txtDtShrtFallRcvd" runat="server" class="form-control txtbox" TabIndex="13"
                                Width="150px" ValidationGroup="group" Height="30px" MaxLength="80"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr style="height: 30px">
                        <td colspan="10" style="padding: 5px; margin: 5px; font-weight: bold; font-size: medium">
                            &nbsp;
                        </td>
                    </tr>
                    <tr style="height: 30px">
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top; font-size: medium">
                            4.0.0
                        </td>
                        <td colspan="9" style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top;
                            font-size: medium" align="left">
                            Capital cost computed & recommended ( in Rs) <font color="red">*</font>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; font-size: medium">
                            4.1.0
                        </td>
                        <td colspan="9" style="padding: 5px; margin: 5px; font-weight: bold; font-size: medium">
                            Land:
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            4.1.1
                        </td>
                        <td style="text-align: left; padding: 5px; margin: 5px; vertical-align: top">
                            Extent in Sq.Mtrs <font color="red">*</font>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="text-align: left; padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtExtent" runat="server" class="form-control txtbox txtcomn" Height="30px"
                                onkeypress="return inputOnlyNumbers(event)" TabIndex="14" Width="180px"></asp:TextBox>
                            <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtNewPowerReleaseDate"></cc1:CalendarExtender>--%>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="text-align: left; padding: 5px; margin: 5px; vertical-align: top">
                            Built up area in Sq.Mtrs <span style="font-weight: normal; color: Red;">*</span>
                        </td>
                        <td style="text-align: left; padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="text-align: left; padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtBuiltupAra" runat="server" class="form-control txtbox txtcomn"
                                Height="28px" MaxLength="40" TabIndex="15" ValidationGroup="group" onkeypress="return inputOnlyNumbers(event)"
                                Width="180px" AutoPostBack="True" OnTextChanged="txtBuiltupAra_TextChanged"></asp:TextBox>
                            <%--<cc1:FilteredTextBoxExtender ID="fteLandValue" runat="server" FilterMode="ValidChars"
                                                        FilterType="Custom, Numbers" ValidChars="." TargetControlID="txtLandValue" />--%>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="text-align: left; padding: 5px; margin: 5px; vertical-align: top">
                            5 times built up area in Sq.Mtrs<span style="font-weight: normal; color: Red;"> *</span>
                        </td>
                        <td style="text-align: left; padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="text-align: left; padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txt5TtimesBltup" runat="server" class="form-control txtbox txtcomn"
                                TabIndex="16" Height="30px" Enabled="false" Width="180px" onkeypress="return inputOnlyNumbers(event)"
                                ValidationGroup="group"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="text-align: left; padding: 5px; margin: 5px; vertical-align: top">
                            Extent eligible in Sq.Mtrs<span style="font-weight: normal; color: Red;"> *</span>
                        </td>
                        <td style="text-align: left; padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="text-align: left; padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtExtentElgble" runat="server" class="form-control txtbox txtcomn"
                                TabIndex="17" Height="30px" onkeypress="return inputOnlyNumbers(event)" Width="180px"
                                ValidationGroup="group"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            4.1.2
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top" colspan="6">
                            Claim application submitted by the Enterprise for reimbursement of Stamp Duty <font
                                color="red">*</font>
                        </td>
                        <td style="text-align: left; padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px 5px 5px 45px; vertical-align: top; font-weight: bold"
                            colspan="2">
                            <asp:RadioButtonList ID="rdblYesNoClaimSubmn" runat="server" RepeatDirection="Horizontal"
                                Width="200px" TabIndex="18">
                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                <asp:ListItem Value="2">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top;">
                            4.1.3
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top" colspan="6">
                            Claim application submitted by the Enterprise for reimbursement of Land Cost <font
                                color="red">*</font>
                        </td>
                        <td style="text-align: left; padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top; font-weight: bold" colspan="2">
                            <asp:RadioButtonList ID="rdblClmApplRmbrLandCst" runat="server" RepeatDirection="Horizontal"
                                Width="200px" TabIndex="19">
                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                <asp:ListItem Value="2">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr style="height: 30px">
                        <td colspan="10">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top;">
                            4.1.4
                        </td>
                        <td colspan="9" style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top;
                            font-size: medium">
                            if, the Enterprise submitted the claim applications for sanction of 25% Land cost,
                            the GM, DIC concerned should not consider the land value for computation of fixed
                            capital investment ( in Rs)
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            Land cost <font color="red">*</font>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtNewPowerReleaseDate"></cc1:CalendarExtender>--%>
                            <asp:TextBox ID="txtLndCst25Prcnt" runat="server" class="form-control txtbox txtcomn"
                                Height="30px" MaxLength="80" TabIndex="20" ValidationGroup="group" Width="150px"
                                onkeypress="return inputOnlyNumbers(event)" OnTextChanged="txtLndCst25Prcnt_TextChanged"
                                AutoPostBack="True"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            Approved Project cost <font color="red">*</font>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtAprdPjCst25Prcnt" runat="server" onkeypress="return inputOnlyNumbers(event)"
                                class="form-control txtbox txtcomn" Height="30px" MaxLength="80" TabIndex="21"
                                ValidationGroup="group" Width="150px" OnTextChanged="txtAprdPjCst25Prcnt_TextChanged"
                                AutoPostBack="True"></asp:TextBox>
                            <%--<asp:TextBox ID="txtRegnFee25Prcnt" runat="server" onkeypress="return inputOnlyNumbers(event)" class="form-control txtbox" Height="30px" MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px" OnTextChanged="txtRegnFee25Prcnt_TextChanged" AutoPostBack="True"></asp:TextBox>--%>
                        </td>
                        <%--<td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">5.
                    </td>
                    <td style="padding: 5px; margin: 5px; vertical-align: top">Approved Project cost</td>
                    <td style="padding: 5px; margin: 5px; vertical-align: top">:
                    </td>
                    <td style="padding: 5px; margin: 5px; vertical-align: top">
                        <asp:TextBox ID="txtAprdPjCst25Prcnt" runat="server" class="form-control txtbox" Height="30px" MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px" AutoPostBack="True" onkeypress="return inputOnlyNumbers(event)" OnTextChanged="txtAprdPjCst25Prcnt_TextChanged"></asp:TextBox>
                    </td>--%>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            Regn. fee <font color="red">*</font>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtRegnfee" runat="server" class="form-control txtbox txtcomn" Height="30px"
                                MaxLength="80" TabIndex="22" ValidationGroup="group" Width="150px" onkeypress="return inputOnlyNumbers(event)"
                                OnTextChanged="txtRegnfee_TextChanged" AutoPostBack="True"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            Proportionate eligible value <font color="red">*</font>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtProprtn25Prcnt" runat="server" class="form-control txtbox txtcomn"
                                Height="30px" onkeypress="return inputOnlyNumbers(event)" MaxLength="80" TabIndex="23"
                                ValidationGroup="group" Width="150px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            Total <font color="red">*</font>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtTotal25Prcnt" runat="server" class="form-control txtbox txtcomn"
                                Height="30px" Enabled="true" MaxLength="80" TabIndex="24" ValidationGroup="group"
                                Width="150px" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            4.1.5
                        </td>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            Computed Cost <font color="red">*</font>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtComputedcost" runat="server" class="form-control txtbox txtcomn"
                                Height="30px" MaxLength="80" TabIndex="25" ValidationGroup="group" Width="150px"
                                onkeypress="return inputOnlyNumbers(event)" OnTextChanged="txtComputedcost_TextChanged"
                                AutoPostBack="True"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr id="troldcontrols1" runat="server" visible="false">
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtPlnthArea" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                Enabled="false" Text="0" Visible="false" ValidationGroup="group" Width="10px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtTotVal4" runat="server" onkeypress="return inputOnlyNumbers(event)"
                                class="form-control txtbox" Enabled="false" Text="0" Visible="false" ValidationGroup="group"
                                Width="10px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtValofItems" runat="server" onkeypress="return inputOnlyNumbers(event)"
                                class="form-control txtbox" Enabled="false" Text="0" Visible="false" ValidationGroup="group"
                                Width="10px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr id="troldcontrols2" runat="server" visible="false">
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtTSSFC" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                Enabled="false" Text="0" Visible="false" ValidationGroup="group" Width="10px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtAprvPJVal" runat="server" onkeypress="return inputOnlyNumbers(event)"
                                class="form-control txtbox" Enabled="false" Text="0" Visible="false" ValidationGroup="group"
                                Width="10px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtRegnFee25Prcnt" runat="server" onkeypress="return inputOnlyNumbers(event)"
                                class="form-control txtbox" Enabled="false" Text="0" Visible="false" ValidationGroup="group"
                                Width="10px"></asp:TextBox>
                            <%--OnTextChanged="txtRegnFee25Prcnt_TextChanged" AutoPostBack="True"--%>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr id="troldcontrols3" runat="server" visible="false">
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtTotVal1" runat="server" class="form-control txtbox" Enabled="false"
                                Text="0" Visible="false" ValidationGroup="group" Width="10px" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtTotVal2" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                Enabled="false" Text="0" Visible="false" ValidationGroup="group" Width="10px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtTotVal3" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                Enabled="false" Text="0" Visible="false" MaxLength="80" ValidationGroup="group"
                                Width="10px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr style="height: 30px">
                        <td colspan="10" style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: middle;">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top; font-size: medium;
                            width: 20px">
                            4.2.0
                        </td>
                        <td colspan="8" style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top;
                            font-size: medium">
                            Building and other civil works
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top;">
                            4.2.1
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            Approved Project Cost <font color="red">*</font>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txt25BldgCvl" runat="server" class="form-control txtbox txtcomn"
                                Height="30px" MaxLength="80" TabIndex="26" ValidationGroup="group" Width="150px"
                                onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                    </tr>
                    <tr id="tr4221" runat="server" visible="true">
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top;">
                            4.2.2
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top; width: 220px">
                            Value of the items 8.2.2 to 8.2.10 of guideline
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <%-- <td style="padding: 5px; margin: 5px; vertical-align: top">
                        <asp:TextBox ID="txt822guideline422" runat="server" class="form-control txtbox txtcomn" Height="30px" MaxLength="80" TabIndex="27" ValidationGroup="group" Width="150px" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                    </td>--%>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txt822guideline422" runat="server" class="form-control txtbox txtcomn"
                                Height="30px" MaxLength="80" TabIndex="27" ValidationGroup="group" Width="150px"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            Plinth area
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <%--<td style="padding: 5px; margin: 5px; vertical-align: top">
                        <asp:TextBox ID="txtPlintharea422" runat="server" class="form-control txtbox txtcomn" Height="30px" MaxLength="80" TabIndex="28" onkeypress="return inputOnlyNumbers(event)" ValidationGroup="group" Width="150px"></asp:TextBox>
                    </td>--%>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtPlintharea422" runat="server" class="form-control txtbox txtcomn"
                                Height="30px" MaxLength="80" TabIndex="28" ValidationGroup="group" Width="150px"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                    </tr>
                    <tr id="tr4222" runat="server" visible="true">
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            Rate as per the TSSFC norms
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtTSSFCnorms422" runat="server" class="form-control txtbox txtcomn"
                                Height="30px" onkeypress="return inputOnlyNumbers(event)" MaxLength="80" TabIndex="29"
                                ValidationGroup="group" Width="150px"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            Value (in Rs)
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtvalue422" runat="server" onkeypress="return inputOnlyNumbers(event)"
                                class="form-control txtbox txtcomn" Height="30px" MaxLength="80" TabIndex="30"
                                ValidationGroup="group" Width="150px"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                    </tr>
                    <tr id="tr4223" runat="server" visible="true">
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:Button ID="btnAdd422New" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                TabIndex="31" Text="Add New" Width="72px" OnClick="btnAdd422New_Click" />
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:Button ID="btnclear422New" runat="server" CausesValidation="False" CssClass="btn btn-xs btn-danger"
                                Height="28px" TabIndex="32" Text="Cancel" ToolTip="To Clear  the Screen" Width="73px"
                                OnClick="btnclear422New_Click" />
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            <asp:Label ID="Label3" runat="server" TabIndex="10" Font-Bold="true"></asp:Label>
                        </td>
                        <td colspan="9" style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            <asp:GridView ID="gv422" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                GridLines="Both" Visible="false" Width="90%" DataKeyNames="intLineofActivityMid"
                                OnRowDataBound="gv422_RowDataBound" OnRowDeleting="gv422_RowDeleting">
                                <RowStyle BackColor="#ffffff" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Sl.No">
                                        <ItemTemplate>
                                            <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Column1" HeaderText="Value of the items 8.2.2 to 8.2.10 of guideline" />
                                    <asp:BoundField DataField="Column2" HeaderText="Plinth area" />
                                    <asp:BoundField DataField="Column3" HeaderText="Rate as per the TSSFC norms" />
                                    <asp:BoundField DataField="Column4" HeaderText="Value (in Rs.)" />
                                    <asp:BoundField DataField="Created_by" HeaderText="Created By" Visible="false" />
                                    <asp:BoundField DataField="IncentiveId" HeaderText="Incentive Id" Visible="false" />
                                    <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                    <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />
                                </Columns>
                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px"
                                    HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"
                                    Font-Names="Arial" Font-Size="9px" />
                            </asp:GridView>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="10" style="padding: 5px; margin: 5px; vertical-align: middle;">
                            <div id="Failure0" runat="server" visible="false" class="alert alert-danger" style="text-align: center">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>
                                    Warning!</strong>
                                <asp:Label ID="lblMsg420_2" runat="server"></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            Total value of 100 % Items <font color="red">*</font>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtTotVal100" runat="server" Enabled="true" onkeypress="return inputOnlyNumbers(event)"
                                class="form-control txtbox txtcomn" Height="30px" MaxLength="80" TabIndex="33"
                                ValidationGroup="group" Width="150px"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr style="height: 30px">
                        <td colspan="10" style="height: 20px">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top; width: 10px">
                            4.2.3
                        </td>
                        <td colspan="9" style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top;
                            font-size: medium">
                            Value of the items 8.2.11 to 8.2.17 and similar items of guidelines not to exceed
                            10% of the total value of the civil works
                        </td>
                    </tr>
                    <tr id="tr4231" runat="server" visible="true">
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top; font-size: medium">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top; width: 220px">
                            Value of the items 8.2.11 to 8.2.17 of guideline
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <%--  <td style="padding: 5px; margin: 5px; vertical-align: top">
                        <asp:TextBox ID="txt423guideline" runat="server" class="form-control txtbox txtcomn" Height="30px" MaxLength="80" TabIndex="34" ValidationGroup="group" Width="150px" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                    </td>--%>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txt423guideline" runat="server" class="form-control txtbox txtcomn"
                                Height="30px" MaxLength="80" TabIndex="34" ValidationGroup="group" Width="150px"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            Plinth area
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <%--  <td style="padding: 5px; margin: 5px; vertical-align: top">
                        <asp:TextBox ID="txtPlintharea423" runat="server" class="form-control txtbox txtcomn" Height="30px" MaxLength="80" TabIndex="35" onkeypress="return inputOnlyNumbers(event)" ValidationGroup="group" Width="150px"></asp:TextBox>
                    </td>--%>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtPlintharea423" runat="server" class="form-control txtbox txtcomn"
                                Height="30px" MaxLength="80" TabIndex="35" ValidationGroup="group" Width="150px"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                    </tr>
                    <tr id="tr4232" runat="server" visible="true">
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            Rate as per the TSSFC norms
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtTSSFCnorms423" runat="server" class="form-control txtbox txtcomn"
                                Height="30px" onkeypress="return inputOnlyNumbers(event)" MaxLength="80" TabIndex="36"
                                ValidationGroup="group" Width="150px"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            Value (in Rs)
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtvalue423" runat="server" onkeypress="return inputOnlyNumbers(event)"
                                class="form-control txtbox txtcomn" Height="30px" MaxLength="80" TabIndex="37"
                                ValidationGroup="group" Width="150px"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                    </tr>
                    <tr id="tr4233" runat="server" visible="true">
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:Button ID="btnAdd423New" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                TabIndex="38" Text="Add New" Width="72px" OnClick="btnAdd423New_Click" />
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:Button ID="btnclear423New" runat="server" CausesValidation="False" CssClass="btn btn-xs btn-danger"
                                Height="28px" TabIndex="39" Text="Cancel" ToolTip="To Clear  the Screen" Width="73px"
                                OnClick="btnclear423New_Click" />
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            <asp:Label ID="Label4" runat="server" TabIndex="10" Font-Bold="true"></asp:Label>
                        </td>
                        <td colspan="9" style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            <asp:GridView ID="gv423" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                GridLines="Both" Visible="false" Width="90%" DataKeyNames="intLineofActivityMid"
                                OnRowDataBound="gv423_RowDataBound" OnRowDeleting="gv423_RowDeleting">
                                <RowStyle BackColor="#ffffff" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Sl.No">
                                        <ItemTemplate>
                                            <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Column1" HeaderText="Value of the items 8.2.11 to 8.2.17 of guideline" />
                                    <asp:BoundField DataField="Column2" HeaderText="Plinth area" />
                                    <asp:BoundField DataField="Column3" HeaderText="Rate as per the TSSFC norms" />
                                    <asp:BoundField DataField="Column4" HeaderText="Value (in Rs.)" />
                                    <asp:BoundField DataField="Created_by" HeaderText="Created By" Visible="false" />
                                    <asp:BoundField DataField="IncentiveId" HeaderText="Incentive Id" Visible="false" />
                                    <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                    <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />
                                </Columns>
                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px"
                                    HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"
                                    Font-Names="Arial" Font-Size="9px" />
                            </asp:GridView>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="10">
                            <div id="Failure" runat="server" visible="false" class="alert alert-danger" style="text-align: center">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>
                                    Warning!</strong>
                                <asp:Label ID="lblMsg423_2" runat="server"></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top;">
                            4.2.4
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            Total Value 10% Items (in Rs) <font color="red">*</font>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtAppJTot" runat="server" Enabled="true" onkeypress="return inputOnlyNumbers(event)"
                                class="form-control txtbox txtcomn" Height="30px" MaxLength="80" TabIndex="40"
                                ValidationGroup="group" Width="150px"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top;">
                            4.2.5
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top; width: 220px">
                            Grand Total Value 100% + 10% Items (in Rs) <font color="red">*</font>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtGrndTotVal" runat="server" Enabled="true" onkeypress="return inputOnlyNumbers(event)"
                                class="form-control txtbox txtcomn" Height="30px" MaxLength="80" TabIndex="41"
                                ValidationGroup="group" Width="150px"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <%--<tr>
                    <td colspan="10" style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top; font-size: medium"></td>
                </tr>--%>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top; width: 30px">
                            4.2.6
                        </td>
                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: top; width: 220px">
                            As per approved project cost <font color="red">*</font>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtNewPowerReleaseDate"></cc1:CalendarExtender>--%>
                            <asp:TextBox ID="txtAsperApprvdCost" runat="server" class="form-control txtbox txtcomn"
                                onkeypress="return inputOnlyNumbers(event)" Height="30px" MaxLength="80" TabIndex="42"
                                ValidationGroup="group" Width="150px" Enabled="true" OnTextChanged="txtAsperApprvdCost_TextChanged"
                                AutoPostBack="true"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: top; width: 220px">
                            Computed value by the GM <span style="font-weight: normal; color: Red;">*</span>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <%--<cc1:FilteredTextBoxExtender ID="fteLandValue" runat="server" FilterMode="ValidChars"
                                                        FilterType="Custom, Numbers" ValidChars="." TargetControlID="txtLandValue" />--%>
                            <asp:TextBox ID="txtComptdGm" runat="server" class="form-control txtbox txtcomn"
                                onkeypress="return inputOnlyNumbers(event)" Height="30px" MaxLength="80" TabIndex="43"
                                ValidationGroup="group" Width="150px" Enabled="true"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: top">
                            As per Civil Engineer Certificate <span style="font-weight: normal; color: Red;">*</span>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtAsperCivilEngr" runat="server" class="form-control txtbox txtcomn"
                                Height="30px" MaxLength="80" TabIndex="44" ValidationGroup="group" Width="150px"
                                onkeypress="return inputOnlyNumbers(event)" Enabled="true"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: top">
                            Computed cost<span style="font-weight: normal; color: Red;"> *</span>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtComputedCostApprPrj" runat="server" class="form-control txtbox txtcomn"
                                onkeypress="return inputOnlyNumbers(event)" Height="30px" MaxLength="80" TabIndex="45"
                                ValidationGroup="group" Width="150px" OnTextChanged="txtComputedCostApprPrj_TextChanged"
                                AutoPostBack="true"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr style="height: 30px">
                        <td style="border: solid thin white; color: black; text-align: left; vertical-align: top;
                            height: 30px" colspan="10">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top; font-size: medium;
                            width: 20px">
                            4.3.0
                        </td>
                        <td colspan="9" style="padding: 5px; margin: 5px; font-weight: bold; text-align: left;
                            vertical-align: top; font-size: medium">
                            Plant and Machinary and Equipment(PM & E) <font color="red">*</font>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top;">
                            4.3.1
                        </td>
                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: top; width: 220px">
                            As per approved project cost <span style="font-weight: normal; color: Red;">*</span>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtNewPowerReleaseDate"></cc1:CalendarExtender>--%>
                            <asp:TextBox ID="txtAsperApprPjCostPM" runat="server" class="form-control txtbox txtcomn"
                                onkeypress="return inputOnlyNumbers(event)" Height="30px" MaxLength="80" TabIndex="46"
                                ValidationGroup="group" Width="150px" Enabled="true" OnTextChanged="txtAsperApprPjCostPM_TextChanged"
                                AutoPostBack="true"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: top; width: 220px">
                            Tech. Know how and study and turnkey charges not to exceed 10% of PM & E <font color="red">
                                *</font>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <%--<cc1:FilteredTextBoxExtender ID="fteLandValue" runat="server" FilterMode="ValidChars"
                                                        FilterType="Custom, Numbers" ValidChars="." TargetControlID="txtLandValue" />--%>
                            <asp:TextBox ID="txtTechKnowPM" runat="server" class="form-control txtbox txtcomn"
                                onkeypress="return inputOnlyNumbers(event)" Height="30px" MaxLength="80" TabIndex="47"
                                ValidationGroup="group" Width="150px" Enabled="true"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: top">
                            As per list of Plant & Machinery <font color="red">*</font>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtAsperListPM" runat="server" class="form-control txtbox txtcomn"
                                Height="30px" onkeypress="return inputOnlyNumbers(event)" MaxLength="80" TabIndex="48"
                                ValidationGroup="group" Width="150px" Enabled="true"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: top">
                            2nd hand machinery Value <font color="red">*</font>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txt2ndMachPM" runat="server" class="form-control txtbox txtcomn"
                                onkeypress="return inputOnlyNumbers(event)" Height="30px" MaxLength="80" TabIndex="49"
                                ValidationGroup="group" Width="150px"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: top">
                            % of 2nd hand Machinery <font color="red">*</font>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top;">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtPrcnt2ndMach" runat="server" class="form-control txtbox txtcomn"
                                onkeypress="return inputOnlyNumbers(event)" Height="30px" MaxLength="80" TabIndex="50"
                                ValidationGroup="group" Width="150px" Enabled="true"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: top">
                            Total <font color="red">*</font>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtTotal2ndHandMach" runat="server" class="form-control txtbox txtcomn"
                                onkeypress="return inputOnlyNumbers(event)" Height="30px" MaxLength="80" TabIndex="51"
                                ValidationGroup="group" Width="150px"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top;">
                            4.3.2
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            Computed Cost <font color="red">*</font>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtTot2ndMach" runat="server" class="form-control txtbox txtcomn"
                                Height="30px" onkeypress="return inputOnlyNumbers(event)" MaxLength="80" TabIndex="52"
                                ValidationGroup="group" Width="150px" Enabled="true" OnTextChanged="txtTot2ndMach_TextChanged"
                                AutoPostBack="true"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr style="height: 30px">
                        <td style="border: solid thin white; color: black; text-align: left; vertical-align: top"
                            colspan="10">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top; font-size: medium">
                            4.4.0
                        </td>
                        <td colspan="9" style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top;
                            font-size: medium">
                            Total Cost computed
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            Land (4.1.5) <font color="red">*</font>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtTotCstCmptdLand" runat="server" class="form-control txtbox txtcomn"
                                onkeypress="return inputOnlyNumbers(event)" Enabled="true" Height="30px" MaxLength="80"
                                TabIndex="53" ValidationGroup="group" Width="150px" OnTextChanged="txtTotCstCmptdLand_TextChanged"
                                AutoPostBack="true"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            Plant & Machinery (4.3.2) <font color="red">*</font>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtTotCstCmptdPlntMach" runat="server" class="form-control txtbox txtcomn"
                                Enabled="true" Height="30px" MaxLength="80" onkeypress="return inputOnlyNumbers(event)"
                                OnTextChanged="txtTotCstCmptdPlntMach_TextChanged" TabIndex="54" ValidationGroup="group"
                                Width="150px" AutoPostBack="true"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            Buildings (4.2.7) <font color="red">*</font>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtTotCstCmptdBldg" runat="server" onkeypress="return inputOnlyNumbers(event)"
                                class="form-control txtbox txtcomn" Enabled="true" Height="30px" MaxLength="80"
                                TabIndex="55" ValidationGroup="group" Width="150px" OnTextChanged="txtTotCstCmptdBldg_TextChanged"
                                AutoPostBack="true"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            Total <font color="red">*</font>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtTotCstCmptdTotal" runat="server" class="form-control txtbox txtcomn"
                                onkeypress="return inputOnlyNumbers(event)" Enabled="false" Height="30px" MaxLength="80"
                                TabIndex="56" ValidationGroup="group" Width="150px"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr style="height: 30px">
                        <td style="border: solid thin white; color: black; text-align: left; vertical-align: top"
                            colspan="10">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top; font-size: medium">
                            5.0
                        </td>
                        <td colspan="9" style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top;
                            font-size: medium">
                            Recommended for sanction of investment Subsidy
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            5.1.
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top; width: 220px">
                            Investment Subsidy (in Rs) <span style="font-weight: normal; color: Red;">*</span>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtNewPowerReleaseDate"></cc1:CalendarExtender>--%>
                            <asp:TextBox ID="txtInvSubsidyVal" runat="server" class="form-control txtbox txtcomn"
                                onkeypress="return inputOnlyNumbers(event)" Enabled="true" Height="30px" MaxLength="80"
                                TabIndex="57" ValidationGroup="group" Width="150px" AutoPostBack="True" OnTextChanged="txtInvSubsidyVal_TextChanged"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px;">
                        </td>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            5.2.
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top; width: 220px">
                            An Additional Investment Subsidy for Women entrepreneurs <span style="font-weight: normal;
                                color: Red;">*</span>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtAddnInvSubsdyWmn" runat="server" class="form-control txtbox txtcomn"
                                onkeypress="return inputOnlyNumbers(event)" Enabled="true" Height="30px" MaxLength="80"
                                TabIndex="58" ValidationGroup="group" Width="150px" AutoPostBack="True" OnTextChanged="txtAddnInvSubsdyWmn_TextChanged"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                        <%-- <td style="padding: 5px; margin: 5px; font-weight: bold;">3.
                                        </td>
                                        <td style="padding: 5px; margin: 5px;">
                                            <span lang="EN-US">Investment subsidy for SC/ST</span><span> </span><span lang="EN-US">Entrepreneurs @35%</span><span style="font-weight: normal; color: Red;"><span> </span><span lang="EN-US">*</span></span><span lang="EN-US"> </span>
                                        </td>
                                        <td style="padding: 5px; margin: 5px;">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px;">

                                            <asp:TextBox ID="txtInvSubsdySCST" runat="server" class="form-control txtbox" Enabled="true" Height="30px" MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                        </td>--%>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            5.3.
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            An additional investment subsidy for SC/ST entrepreneurs <span style="font-weight: normal;
                                color: Red;">*</span>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtInvSubsdySCST" runat="server" class="form-control txtbox txtcomn"
                                Enabled="true" Height="30px" MaxLength="80" TabIndex="59" ValidationGroup="group"
                                Width="150px" AutoPostBack="True" OnTextChanged="txtInvSubsdySCST_TextChanged"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            5.4.
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            An additional investment subsidy for Women entrepreneurs set up in Scheduled areas
                            <span style="font-weight: normal; color: Red;">*</span>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtAddnInvSbsdySc10Prcnt" runat="server" class="form-control txtbox txtcomn"
                                onkeypress="return inputOnlyNumbers(event)" Enabled="true" Height="30px" MaxLength="80"
                                TabIndex="60" ValidationGroup="group" Width="150px" AutoPostBack="True" OnTextChanged="txtAddnInvSbsdySc10Prcnt_TextChanged"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            5.5.
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            Total <font color="red">*</font>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            <asp:TextBox ID="txtTotalInv" runat="server" class="form-control txtbox txtcomn"
                                onkeypress="return inputOnlyNumbers(event)" Enabled="False" Height="30px" MaxLength="80"
                                TabIndex="61" ValidationGroup="group" Width="150px"></asp:TextBox>
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px; vertical-align: top">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            5.6.
                        </td>
                        <td style="text-align: left; padding: 5px; margin: 5px; vertical-align: top" valign="top">
                            Remarks <font color="red">*</font>
                        </td>
                        <td style="padding: 5px; margin: 5px;" valign="top">
                            :
                        </td>
                        <td style="padding: 5px; margin: 5px" valign="top" colspan="4">
                            <asp:TextBox ID="txtremarks" runat="server" class="form-control txtbox" Height="100px"
                                TabIndex="62" TextMode="MultiLine" ValidationGroup="group" Width="300px"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td style="padding: 3px; margin: 3px; text-align: left;" valign="top">
                            Upload Attachment(If any)
                        </td>
                        <td valign="top" align="center">
                            :
                        </td>
                        <td valign="top" align="center" style="padding: 5px; margin: 5px; text-align: left;">
                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="CS" Height="28px" />
                            <asp:HyperLink ID="lblFileName" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                            <br />
                            <asp:Label ID="Label444" runat="server"></asp:Label>
                        </td>
                        <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                            <asp:Button ID="BtnSave3" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                TabIndex="10" Text="Upload" Width="72px" OnClick="BtnSave3_Click" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top">
                            &nbsp;
                        </td>
                        <td style="text-align: left; padding: 5px; margin: 5px; vertical-align: top" valign="top">
                            &nbsp;
                        </td>
                        <td style="padding: 5px; margin: 5px;" valign="top">
                            &nbsp;
                        </td>
                        <td colspan="4" style="padding: 5px; margin: 5px" valign="top">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr style="height: 30px">
                        <td style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top; font-size: medium">
                            M. Attachments
                        </td>
                        <td colspan="9" style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: top;
                            font-size: medium">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px; vertical-align: top" colspan="10">
                            <asp:GridView ID="GridView3att" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView3att_RowDataBound"
                                Width="80%" HorizontalAlign="Left" ShowHeader="true">
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1%>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Type of Attachment">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("Category")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Attachments">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl" runat="server" Text='<%# Eval("AttachmentName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="View">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLinkSubsidy" Text="view" NavigateUrl='<%#Eval("FilePath")%>'
                                                Target="_blank" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Verificationflg" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblVerified" runat="server" Text='<%# Eval("Verified")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Verify Attachment">
                                        <ItemTemplate>
                                           <%-- <asp:CheckBox ID="chkverified" runat="server" Text="Verified" />--%>
                                            <asp:RadioButtonList ID="rbtverified"  runat="server"
                                            RepeatDirection="Horizontal" >
                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                            <asp:ListItem Value="N">No</asp:ListItem>
                                        </asp:RadioButtonList>         
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Attachments" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblatchid" runat="server" Text='<%# Eval("AttachmentId")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Attachment" Visible="false">
                                                                    <itemtemplate>
                                                                        <asp:Label ID="lblFileName" runat="server" Text='<%#Eval("LINKNEW") %>'></asp:Label>
                                                                    </itemtemplate>
                                                                </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 8px">
                            <b>Please enter the following details</b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td class="auto-style3">
                                        Caste
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="rdbCaste" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdbCaste_SelectedIndexChanged"
                                            AutoPostBack="True">
                                            <asp:ListItem>General</asp:ListItem>
                                            <asp:ListItem>SC</asp:ListItem>
                                            <asp:ListItem>ST</asp:ListItem>
                                            <asp:ListItem>PHC</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style3">
                                        Gender
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="rdbGender" AutoPostBack="True" Enabled="false" runat="server"
                                            RepeatDirection="Horizontal" OnSelectedIndexChanged="rdbGender_SelectedIndexChanged">
                                            <asp:ListItem>Male</asp:ListItem>
                                            <asp:ListItem>Female</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style3">
                                        Category
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="rdbCategory" AutoPostBack="True" Enabled="false" runat="server"
                                            RepeatDirection="Horizontal" OnSelectedIndexChanged="rdbCategory_SelectedIndexChanged">
                                            <asp:ListItem>Micro</asp:ListItem>
                                            <asp:ListItem>Small</asp:ListItem>
                                            <asp:ListItem>Medium</asp:ListItem>
                                            <asp:ListItem>Large</asp:ListItem>
                                            <asp:ListItem>Mega</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style3">
                                        Enterprise Type
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="rdbEnterprise" AutoPostBack="True" Enabled="false" runat="server"
                                            RepeatDirection="Horizontal" OnSelectedIndexChanged="rdbEnterprise_SelectedIndexChanged">
                                            <asp:ListItem>New</asp:ListItem>
                                            <asp:ListItem>Expansion</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr id="trlineofactivityexpansion" runat="server" visible="false">
                                                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                                                &nbsp;</td>
                                                                            <td>
                                                                                &nbsp;
                                                                                <table style="width: 100%; font-weight: bold;">
                                                                                    <tr>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">1 </td>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            <asp:Label ID="Label30" runat="server">Line Of Activity<font color="red">*</font></asp:Label>
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px">: </td>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            <asp:TextBox ID="txtLOActivityExpan" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="Names()" TabIndex="5" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                                                        ControlToValidate="txtLOActivity" ErrorMessage="Please enter Line Of Activity"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>--%></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">3 </td>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            <asp:Label ID="Label35" runat="server">Unit<font color="red">*</font></asp:Label>
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px">: </td>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            <asp:DropDownList ID="ddlquantityinExpan" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" OnSelectedIndexChanged="ddlquantityinExpan_SelectedIndexChanged" TabIndex="5" Visible="true" Width="180px">
                                                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                                                <asp:ListItem Value="KG">KG</asp:ListItem>
                                                                                                <asp:ListItem Value="Tone">Tonnes</asp:ListItem>
                                                                                                <asp:ListItem Value="Liters">Litres</asp:ListItem>
                                                                                                <asp:ListItem Value="Others">Others</asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                            <asp:TextBox ID="txtunitExpan" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="Names()" TabIndex="5" ValidationGroup="group" Visible="false" Width="180px"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                                        ControlToValidate="txtunit" ErrorMessage="Please enter Installed Capacity"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>--%></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td valign="top">
                                                                                <table style="width: 100%; font-weight: bold;">
                                                                                    <tr>
                                                                                        <td style="padding: 5px; margin: 5px">
                                                                                            2
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label52" runat="server" CssClass="LBLBLACK" Width="165px">Installed Capacity<font color="red">*</font></asp:Label>
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px">
                                                                                            :
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px">
                                                                                            <asp:TextBox ID="txtinstalledccapExpan" runat="server" class="form-control txtbox"
                                                                                                Height="28px" MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"
                                                                                                Width="180px"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                                                        ControlToValidate="txtinstalledccap" ErrorMessage="Please enter Installed Capacity"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="padding: 5px; margin: 5px">
                                                                                            4
                                                                                        </td>
                                                                                        <td style="width: 200px;">
                                                                                            <asp:Label ID="Label61" runat="server">Value (in Rs.)<font color="red">*</font></asp:Label>
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px">
                                                                                            :
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtvalueExpan" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"
                                                                                                Width="180px" Visible="true"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                                                        ControlToValidate="txtvalue" ErrorMessage="Please enter Value"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            &nbsp;</td>
                                                                                        <td align="right">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        <td>
                                                                                            &nbsp;</td>
                                                                                        <td align="left">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                     <tr id="TRFIXEDCAPITALHEADING" runat="server" visible="false">
                                                                            <td colspan="9" style="padding: 5px; margin: 5px; text-align: left; width: 100%;"
                                                                                valign="top">
                                                                                <asp:Label ID="Label62" runat="server" CssClass="LBLBLACK" Font-Bold="True">FIXED CAPITAL INVESTMENT (In Rs.)<font color="red">*</font></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                        <tr id="trFixedcap" runat="server" visible="false" align="center">
                                                                <td colspan="9" style="width: 80%;">
                                                                    <table style="font-weight: bold;" align="center" width="80%">
                                                                        
                                                                        <tr>
                                                                            <td align="center" style="border: solid thin black; border-left: solid thin black;
                                                                                border-top: solid thin black; background: #013161; color: white" class="auto-style17">
                                                                                Sl.No
                                                                            </td>
                                                                            <td align="center" style="border: solid thin white; border-left: solid thin black;
                                                                                border-top: solid thin black; background: #013161; color: white" class="auto-style17">
                                                                                Nature of Assets
                                                                            </td>
                                                                            <td align="center" style="border: solid thin white; border-top: solid thin black;
                                                                                background: #013161; color: white" class="auto-style17">
                                                                                Value (in Rs.)
                                                                            </td>
                                                                            <td id="trFixedCapitalexpansion" runat="server" align="center" style="border: solid thin white;
                                                                                border-top: solid thin black; background: #013161; color: white"  class="auto-style17">
                                                                                Under Expansion/ Diversification Project
                                                                            </td>
                                                                            <td id="trFixedCapitalexpnPercent" runat="server" align="center" style="border: solid thin black;
                                                                                border-right: solid thin black; border-top: solid thin black; background: #013161;
                                                                                color: white"  class="auto-style17">
                                                                                % of increase under
                                                                                <br />
                                                                                Expansion/Diversification
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="border: solid thin black;">
                                                                                1
                                                                            </td>
                                                                            <td align="left" style="border: solid thin black; border-top: solid thin black; background: white;
                                                                                color: black; text-align: left">
                                                                                Land
                                                                            </td>
                                                                            <td align="center" style="border: solid thin black; text-align: center">
                                                                                <asp:TextBox ID="TXTLANDVALUE_EXISTING" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                                    Height="25px" Width="190px" MaxLength="80" TabIndex="5" ValidationGroup="group"
                                                                                    ></asp:TextBox>
                                                                                
                                                                            </td>
                                                                            <%--<td style="border-bottom: solid thin black; width: 1px">
                                                                    </td>--%>
                                                                            <td id="trFixedCapitalland" runat="server" align="center" style="border: solid thin black"
                                                                               >
                                                                                <asp:TextBox ID="TXTLANDVALUE_EXPANSION" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                                    Height="25px" Width="190px" MaxLength="80" onkeypress="NumberOnly()" TabIndex="5"
                                                                                    ValidationGroup="group" ></asp:TextBox>
                                                                                  </td>
                                                                            <%--<td style="border-bottom: solid thin black; width: 1px">
                                                                    </td>--%>
                                                                            <td id="txtbuildcapacityPercet" runat="server" align="center" style="border: solid thin black"
                                                                                >
                                                                                <asp:TextBox ID="TXTINCPERCENTAGE_LAND" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                                    Height="25px" Width="190px" MaxLength="80" onkeypress="NumberOnly()" TabIndex="5"
                                                                                    ValidationGroup="group"></asp:TextBox>
                                                                                
                                                                            </td>
                                                                            <%--<td style="border-bottom: solid thin black; border-right: solid thin black; width: 1px">
                                                                    </td>--%>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="border: solid thin black;">
                                                                                2
                                                                            </td>
                                                                            <td align="left" style="border: solid thin black; border-top: solid thin black; background: white;
                                                                                color: black">
                                                                                Building
                                                                            </td>
                                                                            <td align="center" style="border: solid thin black; text-align: center">
                                                                                <asp:TextBox ID="TXTBUILDINGVALE_EXISTING" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                                    Height="25px" Width="190px" MaxLength="80" onkeypress="NumberOnly()" TabIndex="5"
                                                                                    ValidationGroup="group" ></asp:TextBox>
                                                                                     </td>
                                                                            <%--<td style="border-bottom: solid thin black">
                                                                        </td>--%>
                                                                            <td id="trFixedCapitalBuilding" runat="server" align="center" style="border: solid thin black"
                                                                                >
                                                                                <asp:TextBox ID="TXTBUILDINGVALUE_EXPANSION" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                                    Height="25px" Width="190px" MaxLength="80" onkeypress="NumberOnly()" TabIndex="5"
                                                                                     ValidationGroup="group" ></asp:TextBox>
                                                                               
                                                                            </td>
                                                                            <%--<td style="border-bottom: solid thin black; width: 1px">
                                                                        </td>--%>
                                                                            <td id="trFixedCapitBuildPercent" runat="server" align="center" style="border: solid thin black"
                                                                                >
                                                                                <asp:TextBox ID="TXTINCRPERCEN_BUILDINGVALUE" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                                    Height="25px" Width="190px" MaxLength="80" onkeypress="NumberOnly()" TabIndex="5"
                                                                                    ValidationGroup="group"></asp:TextBox>
                                                                               
                                                                            </td>
                                                                            <%--<td style="border-bottom: solid thin black; border-right: solid thin black; width: 1px">
                                                                        </td>--%>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="border: solid thin black;">
                                                                                3
                                                                            </td>
                                                                            <td align="left" style="border: solid thin black; border-top: solid thin black; background: white;
                                                                                color: black; text-align: left">
                                                                                Plant &amp; Machinery
                                                                            </td>
                                                                            <td align="center" style="border: solid thin black">
                                                                                <asp:TextBox ID="TXTPLANTANDMACHINAERVALUE_EXISTING" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                                    Height="25px" Width="190px" MaxLength="80" onkeypress="NumberOnly()" TabIndex="5"
                                                                                    ValidationGroup="group" ></asp:TextBox>
                                                                                  </td>
                                                                            <%--<td style="border-bottom: solid thin black">
                                                                        </td>--%>
                                                                            <td id="trFixedCapitalMach" runat="server" align="center" style="border: solid thin black"
                                                                                >
                                                                                <%-- <asp:TextBox ID="txtplantcapacity" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                        Height="25px" Width="190px" MaxLength="80" onkeypress="NumberOnly()" TabIndex="5"
                                                                        ValidationGroup="group" AutoPostBack="True" OnTextChanged="txtplantcapacity_TextChanged"></asp:TextBox>--%>
                                                                                <asp:TextBox ID="TXTPLANTANDMACHINERYVALUE_EXPANSION" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                                    Height="25px" Width="190px" MaxLength="80" onkeypress="NumberOnly()" TabIndex="5"
                                                                                    ValidationGroup="group" ></asp:TextBox>
                                                                                
                                                                            </td>
                                                                            <%--<td style="border-bottom: solid thin black; width: 1px">
                                                                        </td>--%>
                                                                            <td id="trFixedCapitMachPercent" runat="server" align="center" style="border: solid thin black"
                                                                                >
                                                                                <asp:TextBox ID="TXTINCPERCEN_PLANTANDMACHINERY" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                                    Height="25px" Width="190px" MaxLength="80" onkeypress="NumberOnly()" TabIndex="5"
                                                                                    ValidationGroup="group"></asp:TextBox>
                                                                               
                                                                            </td>
                                                                            <%--<td style="border-bottom: solid thin black; border-right: solid thin black; width: 1px">
                                                                        </td>--%>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 20px; font-weight: bold;">
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                <tr>
                                    <td class="auto-style3">
                                        Sector
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="rdbSector" AutoPostBack="True"  runat="server" Enabled="false"
                                            RepeatDirection="Horizontal" OnSelectedIndexChanged="rdbSector_SelectedIndexChanged">
                                            <asp:ListItem>Service</asp:ListItem>
                                            <asp:ListItem>Manufacture</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr id="trServiceType" runat="server" visible="false">
                                    <td>
                                        Service Type
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="rdbServiceType" runat="server" AutoPostBack="True"  
                                            RepeatDirection="Horizontal" OnSelectedIndexChanged="rdbServiceType_SelectedIndexChanged">
                                            <asp:ListItem Value="STT">Transport</asp:ListItem>
                                            <asp:ListItem Value="STNT">Non - Transport(Fixed services like Hospitals,Halls,Poutlry Farms etc)</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr id="trTransNonTrans" runat="server" visible="false">
                                    <td>
                                        Transport/Non-Transport Type
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="rdbTransportNonTrans" runat="server" AutoPostBack="True"
                                            Enabled="false" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdbTransportNonTrans_SelectedIndexChanged">
                                            <asp:ListItem Value="TP">Passenger</asp:ListItem>
                                            <asp:ListItem Value="TG">Goods/Tractor etc</asp:ListItem>
                                            <asp:ListItem Value="TE">Earth Movers/Borewells/JCB etc</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="trsubmit" runat="server" visible="false">
                        <td align="center" colspan="10">
                            <br />
                            <asp:Button ID="btnSubmit" CssClass="btn btn-primary" runat="server" Text="Submit Report"
                                OnClick="btnSubmit_Click" Width="128px" TabIndex="63" />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="10">
                            <br />
                            <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HiddenField ID="hdfID" runat="server" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                ShowSummary="False" ValidationGroup="group" />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="text-align: center" id="divbtnprint" runat="server" visible="false">
                <asp:Button ID="btnprint" runat="server" Height="32px" CausesValidation="False" Width="90px"
                    CssClass="btn btn-warning" UseSubmitBehavior="False" Text="Print " OnClientClick="javascript:CallPrint('divprint');return false;" />
                <br />
                <br />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <link href="../../Masterfiles/css/StyleSheetMaster.css" rel="stylesheet" />
    <script src="../../Resource/Scripts/js/jquery.js" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../Resource/Scripts/js/plugins/morris/raphael.min.js"></script>
    <script src="../../Resource/Scripts/js/plugins/morris/morris.min.js" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/plugins/morris/morris-data.js" type="text/javascript"></script>
    <link href="../../Resource/Styles/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/css/sb-admin.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/css/plugins/morris.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        function CallPrint(strid) {
            var prtContent = document.getElementById(strid);
            var WinPrint = window.open('', '', 'letf=0,top=0,width=0,height=0,toolbar=0,scrollbars=1,status=0');
            var strOldOne = prtContent.innerHTML;
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
            prtContent.innerHTML = strOldOne;
        }
    </script>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtCalenderDCP']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                }); // Will run at every postback/AsyncPostback

            $("input[id$='txtApplClm']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                }); // Will run at every postback/AsyncPostback

            $("input[id$='txtDateShrtfall']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                }); // Will run at every postback/AsyncPostback

            $("input[id$='txtDtShrtFallRcvd']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                }); // Will run at every postback/AsyncPostback

        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtCalenderDCP']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });

            $("input[id$='txtApplClm']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });

            $("input[id$='txtDateShrtfall']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });

            $("input[id$='txtDtShrtFallRcvd']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });

            console.log($(".txtcomn").length);
            var option_all = '';

            $("input[id$='chkMobileUnit']").change(function () {
                if (this.checked) {

                    option_all = $(".txtcomn").map(function () {
                        if ($.trim($(this).val()) == '') {
                            return "#" + $(this).attr('Id');
                        }
                    }).get().join(',');

                    console.log(option_all);

                    if (option_all) {
                        $(option_all).val('0')
                    }

                }
                else {
                    $(option_all).val('')
                }
            });





        });
    </script>
</asp:Content>
