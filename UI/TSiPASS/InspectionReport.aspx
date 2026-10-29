<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    CodeFile="InspectionReport.aspx.cs" Inherits="UI_TSiPASS_InspectionReport" %>

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
    <asp:UpdatePanel ID="updIncInspcRprt" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdfFlagID" runat="server" />
            <asp:HiddenField ID="hdfFlagID0" runat="server" />
            <asp:HiddenField ID="hdfpencode" runat="server" />
            <div class="panel-heading">
                <h3 class="panel-title">
                    Inspection Report for Investment Subsidy</h3>
            </div>
            <table style="width: 100%">
                <tr>
                    <td colspan="10" style="padding: 10px; margin: 5px; font-weight: bold;">
                        A. Unit Inspection Details
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        1.
                    </td>
                    <td style="padding: 5px; margin: 5px; width: 250px">
                        Name of the Inspecting Officer
                    </td>
                    <td>
                        :
                    </td>
                    <td style="padding: 5px; margin: 5px; width: 180px">
                        <asp:TextBox ID="txtIPOName" class="form-control txtbox" Height="28px" MaxLength="80"
                            TabIndex="1" ValidationGroup="group" runat="server" Width="150px"></asp:TextBox>
                    </td>
                    <td style="padding: 10px; margin: 5px; width: 20px">
                    </td>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        2.
                    </td>
                    <td style="padding: 5px; margin: 5px; width: 250px">
                        Designation
                    </td>
                    <td>
                        :
                    </td>
                    <td style="padding: 5px; margin: 5px; width: 180px">
                        <asp:Label ID="lblIPODesignation" runat="server"></asp:Label>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        3.
                    </td>
                    <td style="padding: 5px; margin: 5px;">
                        Date(s) of Inspection
                    </td>
                    <td>
                        :
                    </td>
                    <td style="padding: 5px; margin: 5px;">
                        <asp:TextBox ID="txtInpectedDate" Width="150px" class="form-control txtbox" Height="28px"
                            MaxLength="80" TabIndex="1" ValidationGroup="group" runat="server"></asp:TextBox>
                    </td>
                    <td style="padding: 10px; margin: 5px; width: 20px">
                    </td>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        4.
                    </td>
                    <td style="padding: 5px; margin: 5px;">
                        Person (from Industry) present at the time of Inspection.
                    </td>
                    <td>
                        :
                    </td>
                    <td style="padding: 5px; margin: 5px;">
                        <asp:TextBox ID="txtPersonIndustry" Width="150px" class="form-control txtbox" Height="28px"
                            MaxLength="80" TabIndex="1" ValidationGroup="group" runat="server"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        5.
                    </td>
                    <td style="padding: 5px; margin: 5px;">
                        Status of Industry
                    </td>
                    <td>
                        :
                    </td>
                    <td style="padding: 5px; margin: 5px;">
                        <asp:DropDownList ID="ddlStatus" Enabled="false" class="form-control txtbox" Width="180px"
                            runat="server">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem Value="1">New</asp:ListItem>
                            <asp:ListItem Value="2">Expansion</asp:ListItem>
                            <asp:ListItem Value="3">Diversification</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr style="height: 30px">
                    <td colspan="10">
                    </td>
                </tr>
                <tr>
                    <td colspan="10" style="padding: 10px; margin: 5px; font-weight: bold;">
                        B. Verification Certificate
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px" valign="top">
                        1.
                    </td>
                    <td style="padding: 5px; margin: 5px;" colspan="6">
                        Certified that contents of the claim under Part-A and the document indicated in
                        Part-c of this claim application were verified and found correct. The plant and
                        machinery and equipment was physically verified as per the statement of machinery
                        and found them duly installed and put on work . Further certified that the fixed
                        assets claimed for incentives are essentially required for carrying the production
                        in which the industry is engaged in.
                    </td>
                    <td style="padding: 10px; margin: 5px;" colspan="2" valign="top">
                        <asp:RadioButtonList ID="rdbVerifyCert" runat="server" Height="16px" RepeatDirection="Horizontal"
                            Width="200px">
                            <asp:ListItem Value="1">Yes</asp:ListItem>
                            <asp:ListItem Value="2">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr style="height: 30px">
                    <td colspan="10">
                    </td>
                </tr>
                <tr>
                    <td colspan="10" style="padding: 10px; margin: 5px; font-weight: bold;">
                        C. Project Details
                    </td>
                </tr>
                <tr>
                    <td colspan="10" style="padding: 10px; margin: 5px; font-weight: bold;">
                        &nbsp;&nbsp; &#8594; &nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Underline="True"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td colspan="10" style="padding: 10px; margin: 5px;" align="left">
                        <asp:GridView ID="gvInstalledCap" CssClass="myGridClass" runat="server" AutoGenerateColumns="False"
                            BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" GridLines="Both"
                            OnRowDataBound="gvInstalledCap_RowDataBound" Width="90%" AllowSorting="True"
                            HorizontalAlign="Center">
                            <RowStyle VerticalAlign="Middle" />
                            <Columns>
                                <asp:TemplateField HeaderText="Sl.No" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="10px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Column1" HeaderText="Line Of Activity" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Column3" HeaderText="Installed Capacity" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Column2" HeaderText="Unit" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Column4" HeaderText="Value" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Created_by" HeaderText="Created By" Visible="false" />
                                <asp:BoundField DataField="IncentiveId" HeaderText="Incentive Id" Visible="false" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr style="height: 30px">
                    <td colspan="10">
                    </td>
                </tr>
                <tr>
                    <td colspan="10" style="padding: 10px; margin: 5px; font-weight: bold;">
                        D. Dates of Application
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px" valign="top">
                        1.
                    </td>
                    <td style="padding: 5px; margin: 5px; width: 250px" valign="top">
                        Date of commencement of Production
                    </td>
                    <td>
                        :
                    </td>
                    <td style="padding: 5px; margin: 5px;">
                        <asp:TextBox ID="txtCalenderDCP" runat="server" class="form-control txtbox" Height="30px"
                            MaxLength="80" TabIndex="1" ValidationGroup="group" Visible="false" Width="150px"></asp:TextBox>
                        <asp:Label ID="lblDCP" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td style="padding: 10px; margin: 5px; width: 20px">
                    </td>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px" valign="top">
                        2.
                    </td>
                    <td style="padding: 10px; margin: 5px; text-align: left;" valign="top">
                        Date of receipt of claim application<span style="font-weight: normal; color: Red;">*</span>
                    </td>
                    <td style="padding: 10px; margin: 5px; text-align: left;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px; text-align: left;" valign="top">
                        <asp:TextBox ID="txtRcptAppln" runat="server" class="form-control txtbox" TabIndex="1"
                            Width="150px" ValidationGroup="group" Height="30px" MaxLength="80"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px" valign="top">
                        3.
                    </td>
                    <td style="text-align: left; padding: 10px; margin: 5px;">
                        Date of Query Raised
                    </td>
                    <td style="text-align: left; padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="text-align: left; padding: 10px; margin: 5px;">
                        <%--<cc1:FilteredTextBoxExtender ID="fteLandValue" runat="server" FilterMode="ValidChars"
                                                        FilterType="Custom, Numbers" ValidChars="." TargetControlID="txtLandValue" />--%>
                        <asp:TextBox ID="txtDateShrtfall" runat="server" class="form-control txtbox" Height="30px"
                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                    </td>
                    <td style="padding: 10px; margin: 5px; width: 20px">
                    </td>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px" valign="top">
                        4.
                    </td>
                    <td style="text-align: left; padding: 10px; margin: 5px;" valign="top">
                        Date of Query Responded
                    </td>
                    <td style="text-align: left; padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="text-align: left; padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txtDtShrtFallRcvd" runat="server" class="form-control txtbox" TabIndex="1"
                            Width="150px" ValidationGroup="group" Height="30px" MaxLength="80"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 30px">
                    <td colspan="10">
                    </td>
                </tr>
                <tr>
                    <td colspan="10" style="padding: 10px; margin: 5px; font-weight: bold;">
                        E. Land: Capital cost computed &amp; recommended ( in Rs)
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        1.
                    </td>
                    <td style="text-align: left; padding: 10px; margin: 5px;">
                        Extent in Sq.Mtrs
                    </td>
                    <td style="padding: 5px; margin: 5px">
                        :
                    </td>
                    <td style="text-align: left; padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txtExtent" runat="server" class="form-control txtbox" Height="30px"
                            onkeypress="return inputOnlyNumbers(event)" TabIndex="68" Width="180px"></asp:TextBox>
                        <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtNewPowerReleaseDate"></cc1:CalendarExtender>--%>
                    </td>
                    <td style="padding: 10px; margin: 5px; width: 20px">
                    </td>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        2.
                    </td>
                    <td style="text-align: left; padding: 10px; margin: 5px;">
                        Built up area in Sq.Mtrs <span style="font-weight: normal; color: Red;">*</span>
                    </td>
                    <td style="text-align: left; padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="text-align: left; padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txtBuiltupAra" runat="server" class="form-control txtbox" Height="28px"
                            MaxLength="40" TabIndex="69" ValidationGroup="group" onkeypress="return inputOnlyNumbers(event)"
                            Width="180px" AutoPostBack="True" OnTextChanged="txtBuiltupAra_TextChanged"></asp:TextBox>
                        <%--<cc1:FilteredTextBoxExtender ID="fteLandValue" runat="server" FilterMode="ValidChars"
                                                        FilterType="Custom, Numbers" ValidChars="." TargetControlID="txtLandValue" />--%>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        3.
                    </td>
                    <td style="text-align: left; padding: 10px; margin: 5px;">
                        5 times built up area in Sq.Mtrs<span style="font-weight: normal; color: Red;">*</span>
                    </td>
                    <td style="text-align: left; padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="text-align: left; padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txt5TtimesBltup" runat="server" class="form-control txtbox" TabIndex="70"
                            Height="30px" Width="180px" onkeypress="return inputOnlyNumbers(event)" ValidationGroup="group"></asp:TextBox>
                    </td>
                    <td style="padding: 10px; margin: 5px; width: 20px">
                    </td>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        4.
                    </td>
                    <td style="text-align: left; padding: 10px; margin: 5px;">
                        Extent eligible in Sq.Mtrs<span style="font-weight: normal; color: Red;">*</span>
                    </td>
                    <td style="text-align: left; padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="text-align: left; padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txtExtentElgble" runat="server" class="form-control txtbox" TabIndex="71"
                            Height="30px" onkeypress="return inputOnlyNumbers(event)" Width="180px" ValidationGroup="group"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        5.
                    </td>
                    <td style="padding: 5px; margin: 5px;" colspan="6">
                        Claim application submitted by the Enterprise for reimbursement of Stamp Duty:
                    </td>
                    <td style="padding: 5px; margin: 5px;" colspan="2">
                        <asp:RadioButtonList ID="rdblYesNoClaimSubmn" runat="server" RepeatDirection="Horizontal"
                            Width="200px">
                            <asp:ListItem Value="1">YES</asp:ListItem>
                            <asp:ListItem Value="2">NO</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        6.
                    </td>
                    <td style="padding: 5px; margin: 5px;" colspan="6">
                        Claim application submitted by the Enterprise for reimbursement of Land Cost:
                    </td>
                    <td style="padding: 5px; margin: 5px;" colspan="2">
                        <asp:RadioButtonList ID="rdblClmApplRmbrLandCst" runat="server" RepeatDirection="Horizontal"
                            Width="200px">
                            <asp:ListItem Value="1">YES</asp:ListItem>
                            <asp:ListItem Value="2">NO</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr style="height: 30px">
                    <td colspan="10">
                    </td>
                </tr>
                <tr>
                    <td colspan="10" style="padding: 10px; margin: 5px; font-weight: bold;">
                        F. if, the Enterprise submitted the claim applications for sanction of 25% Land
                        cost, the GM, DIC concerned should not consider the land value for computation of
                        fixed capital investment ( in Rs)
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        1.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        Land cost
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtNewPowerReleaseDate"></cc1:CalendarExtender>--%>
                        <asp:TextBox ID="txtLndCst25Prcnt" runat="server" class="form-control txtbox" Height="30px"
                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px" onkeypress="return inputOnlyNumbers(event)"
                            OnTextChanged="txtLndCst25Prcnt_TextChanged" AutoPostBack="True"></asp:TextBox>
                    </td>
                    <td style="padding: 10px; margin: 5px; width: 20px">
                    </td>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        5.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        Approved Project cost
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txtAprdPjCst25Prcnt" runat="server" class="form-control txtbox"
                            Height="30px" MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"
                            AutoPostBack="True" onkeypress="return inputOnlyNumbers(event)" OnTextChanged="txtAprdPjCst25Prcnt_TextChanged"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        2.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        Stamp Duty
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txtRegnFee25Prcnt" runat="server" onkeypress="return inputOnlyNumbers(event)"
                            class="form-control txtbox" Height="30px" MaxLength="80" TabIndex="1" ValidationGroup="group"
                            Width="150px" OnTextChanged="txtRegnFee25Prcnt_TextChanged" AutoPostBack="True"></asp:TextBox>
                    </td>
                    <td style="padding: 10px; margin: 5px; width: 20px">
                    </td>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        6.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        Proportionate eligible value
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txtProprtn25Prcnt" runat="server" class="form-control txtbox" Height="30px"
                            onkeypress="return inputOnlyNumbers(event)" MaxLength="80" TabIndex="1" ValidationGroup="group"
                            Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        3.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        Regn. fee
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txtRegnfee" runat="server" class="form-control txtbox" Height="30px"
                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px" onkeypress="return inputOnlyNumbers(event)"
                            OnTextChanged="txtRegnfee_TextChanged" AutoPostBack="True"></asp:TextBox>
                    </td>
                    <td style="padding: 10px; margin: 5px; width: 20px">
                    </td>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        7.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        Computed Cost
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txtComputedcost" runat="server" class="form-control txtbox" Height="30px"
                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px" AutoPostBack="True"
                            onkeypress="return inputOnlyNumbers(event)" OnTextChanged="txtComputedcost_TextChanged"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        4.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        Total(1+2+3)
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txtTotal25Prcnt" runat="server" class="form-control txtbox" Height="30px"
                            MaxLength="80" TabIndex="1" ValidationGroup="group" onkeypress="return inputOnlyNumbers(event)"
                            Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="10" style="padding: 10px; margin: 5px; font-weight: bold;">
                        G. Building and other civil works
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        1.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        Approved Project Cost
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txt25BldgCvl" runat="server" class="form-control txtbox" Height="30px"
                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                    </td>
                    <td style="padding: 10px; margin: 5px; width: 20px">
                    </td>
                </tr>
                <%--<tr style="height: 30px">
                                        <td colspan="10"></td>
                                    </tr>--%>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        2.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        Value of the items 8.2.2 to 8.2.10 of guideline
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txtTotVal1" runat="server" class="form-control txtbox" Height="30px"
                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                    </td>
                    <td style="padding: 10px; margin: 5px; width: 20px">
                    </td>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        5.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        Value
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txtTotVal4" runat="server" onkeypress="return inputOnlyNumbers(event)"
                            class="form-control txtbox" Height="30px" MaxLength="80" TabIndex="1" ValidationGroup="group"
                            Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        3.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        Plinth area
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txtTotVal2" runat="server" class="form-control txtbox" Height="30px"
                            MaxLength="80" TabIndex="1" onkeypress="return inputOnlyNumbers(event)" ValidationGroup="group"
                            Width="150px"></asp:TextBox>
                    </td>
                    <td style="padding: 10px; margin: 5px; width: 20px">
                    </td>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        6.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        Total value of 100 % Items
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txtTotVal10" runat="server" onkeypress="return inputOnlyNumbers(event)"
                            class="form-control txtbox" Height="30px" MaxLength="80" TabIndex="1" ValidationGroup="group"
                            Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        4.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        Rate as per the TSSFC norms
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txtTotVal3" runat="server" class="form-control txtbox" Height="30px"
                            onkeypress="return inputOnlyNumbers(event)" MaxLength="80" TabIndex="1" ValidationGroup="group"
                            Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 30px">
                    <td colspan="10">
                    </td>
                </tr>
                <tr>
                    <td colspan="10" style="padding: 10px; margin: 5px; font-weight: bold;">
                        H. Value of the items G.1 to G.6 and similar items of guidelines not to exceed 10%
                        of the total value of the civil works
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        1.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        Value of the items G.1 to G.6 of guideline<span style="font-weight: normal; color: Red;">*</span>
                    </td>
                    <td style="padding: 5px; margin: 5px">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtNewPowerReleaseDate"></cc1:CalendarExtender>--%>
                        <asp:TextBox ID="txtValofItems" runat="server" onkeypress="return inputOnlyNumbers(event)"
                            class="form-control txtbox" Height="30px" MaxLength="80" TabIndex="1" ValidationGroup="group"
                            Width="150px"></asp:TextBox>
                    </td>
                    <td style="padding: 10px; margin: 5px; width: 20px">
                    </td>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        4.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        Value <span style="font-weight: normal; color: Red;">*</span>
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <%--<cc1:FilteredTextBoxExtender ID="fteLandValue" runat="server" FilterMode="ValidChars"
                                                        FilterType="Custom, Numbers" ValidChars="." TargetControlID="txtLandValue" />--%>
                        <asp:TextBox ID="txtAprvPJVal" runat="server" onkeypress="return inputOnlyNumbers(event)"
                            class="form-control txtbox" Height="30px" MaxLength="80" TabIndex="1" ValidationGroup="group"
                            Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        2.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        Plinth area
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txtPlnthArea" runat="server" class="form-control txtbox" Height="30px"
                            onkeypress="return inputOnlyNumbers(event)" MaxLength="80" TabIndex="1" ValidationGroup="group"
                            Width="150px"></asp:TextBox>
                    </td>
                    <td style="padding: 10px; margin: 5px; width: 20px">
                    </td>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        5.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        Total Value 10% Items
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txtAppJTot" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                            Height="30px" MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        3.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        Rate as per the TSSFC norms
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txtTSSFC" runat="server" class="form-control txtbox" Height="30px"
                            onkeypress="return inputOnlyNumbers(event)" MaxLength="80" TabIndex="1" ValidationGroup="group"
                            Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px;" colspan="4">
                        Grand Total Value 100% + 10% Items<span style="font-weight: bold; color: Red;"> *</span>
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;" colspan="5">
                        <asp:TextBox ID="txtGrndTotVal" runat="server" class="form-control txtbox" Height="30px"
                            onkeypress="return inputOnlyNumbers(event)" MaxLength="80" TabIndex="1" ValidationGroup="group"
                            Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="10" style="padding: 10px; margin: 5px; font-weight: bold;">
                        I. Valuation of Project
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        1.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        As per approved project cost
                    </td>
                    <td style="padding: 5px; margin: 5px">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtNewPowerReleaseDate"></cc1:CalendarExtender>--%>
                        <asp:TextBox ID="txtAsperApprvdCost" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                            Height="30px" MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"
                            Enabled="true"></asp:TextBox>
                    </td>
                    <td style="padding: 10px; margin: 5px; width: 20px">
                    </td>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        3.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        Computed value by the GM <span style="font-weight: normal; color: Red;">*</span>
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <%--<cc1:FilteredTextBoxExtender ID="fteLandValue" runat="server" FilterMode="ValidChars"
                                                        FilterType="Custom, Numbers" ValidChars="." TargetControlID="txtLandValue" />--%>
                        <asp:TextBox ID="txtComptdGm" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                            Height="30px" MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"
                            Enabled="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        2.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        As per Civil Engineer Certificate <span style="font-weight: normal; color: Red;">*</span>
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txtAsperCivilEngr" runat="server" class="form-control txtbox" Height="30px"
                            MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px" onkeypress="return inputOnlyNumbers(event)"
                            Enabled="true"></asp:TextBox>
                    </td>
                    <td style="padding: 10px; margin: 5px; width: 20px">
                    </td>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        4.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        Computed cost<span style="font-weight: normal; color: Red;">*</span>
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txtComputedCostApprPrj" runat="server" class="form-control txtbox"
                            onkeypress="return inputOnlyNumbers(event)" Height="30px" MaxLength="80" TabIndex="1"
                            ValidationGroup="group" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="10" style="padding: 10px; margin: 5px; font-weight: bold;">
                        J. Plant and Machinary and Equipment(PM & E)
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        1.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        As per approved project cost<span style="font-weight: normal; color: Red;">*</span>
                    </td>
                    <td style="padding: 5px; margin: 5px">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtNewPowerReleaseDate"></cc1:CalendarExtender>--%>
                        <asp:TextBox ID="txtAsperApprPjCostPM" runat="server" class="form-control txtbox"
                            onkeypress="return inputOnlyNumbers(event)" Height="30px" MaxLength="80" TabIndex="1"
                            ValidationGroup="group" Width="150px" Enabled="true"></asp:TextBox>
                    </td>
                    <td style="padding: 10px; margin: 5px; width: 20px">
                    </td>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        3
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        Tech. Know how and study and turnkey charges not to exceed 10% of PM &amp; E
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <%--<cc1:FilteredTextBoxExtender ID="fteLandValue" runat="server" FilterMode="ValidChars"
                                                        FilterType="Custom, Numbers" ValidChars="." TargetControlID="txtLandValue" />--%>
                        <asp:TextBox ID="txtTechKnowPM" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                            Height="30px" MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"
                            Enabled="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        2.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        As per list of Plant &amp; Machinery
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txtAsperListPM" runat="server" class="form-control txtbox" Height="30px"
                            onkeypress="return inputOnlyNumbers(event)" MaxLength="80" TabIndex="1" ValidationGroup="group"
                            Width="150px" Enabled="true"></asp:TextBox>
                    </td>
                    <td style="padding: 10px; margin: 5px; width: 20px">
                    </td>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        4.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        2nd hand machinery Value
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txt2ndMachPM" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                            Height="30px" MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        5.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        % of 2nd hand Machinery
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txtPrcnt2ndMach" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                            Height="30px" MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"
                            Enabled="true"></asp:TextBox>
                    </td>
                    <td style="padding: 10px; margin: 5px; width: 20px">
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        6
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        Total
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txtTotal2ndHandMach" runat="server" class="form-control txtbox"
                            onkeypress="return inputOnlyNumbers(event)" Height="30px" MaxLength="80" TabIndex="1"
                            ValidationGroup="group" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        7.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        Computed Cost
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txtTot2ndMach" runat="server" class="form-control txtbox" Height="30px"
                            onkeypress="return inputOnlyNumbers(event)" MaxLength="80" TabIndex="1" ValidationGroup="group"
                            Width="150px" Enabled="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="border: solid thin white; color: black; text-align: left;">
                    </td>
                </tr>
                <tr>
                    <td colspan="10" style="padding: 10px; margin: 5px; font-weight: bold;">
                        K. Total Cost computed
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        1.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        Land (4.1.5)
                    </td>
                    <td style="padding: 5px; margin: 5px">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txtTotCstCmptdLand" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                            Enabled="true" Height="30px" MaxLength="80" TabIndex="1" ValidationGroup="group"
                            Width="150px"></asp:TextBox>
                    </td>
                    <td style="padding: 10px; margin: 5px; width: 20px">
                    </td>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        3.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        Plant &amp; Machinery (4.3.2)
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txtTotCstCmptdPlntMach" runat="server" class="form-control txtbox"
                            Enabled="true" Height="30px" MaxLength="80" onkeypress="return inputOnlyNumbers(event)"
                            OnTextChanged="txtTotCstCmptdPlntMach_TextChanged" TabIndex="1" ValidationGroup="group"
                            Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        2.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        Buildings (4.2.7)
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txtTotCstCmptdBldg" runat="server" onkeypress="return inputOnlyNumbers(event)"
                            class="form-control txtbox" Enabled="true" Height="30px" MaxLength="80" TabIndex="1"
                            ValidationGroup="group" Width="150px"></asp:TextBox>
                    </td>
                    <td style="padding: 10px; margin: 5px; width: 20px">
                    </td>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        4.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        Total
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txtTotCstCmptdTotal" runat="server" class="form-control txtbox"
                            onkeypress="return inputOnlyNumbers(event)" Enabled="true" Height="30px" MaxLength="80"
                            TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="10" style="padding: 10px; margin: 5px; font-weight: bold;">
                        L.Recommended for sanction of investment Subsidy
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        1.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <span lang="EN-US">Investment Subsidy</span> <span style="font-weight: normal; color: Red;">
                            *</span>
                    </td>
                    <td style="padding: 5px; margin: 5px">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtNewPowerReleaseDate"></cc1:CalendarExtender>--%>
                        <asp:TextBox ID="txtInvSubsidyVal" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                            Enabled="true" Height="30px" MaxLength="80" TabIndex="1" ValidationGroup="group"
                            Width="150px"></asp:TextBox>
                    </td>
                    <td style="padding: 10px; margin: 5px; width: 20px">
                    </td>
                    <%-- <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">3.
                                        </td>
                                        <td style="padding: 10px; margin: 5px;">
                                            <span lang="EN-US">Investment subsidy for SC/ST</span><span> </span><span lang="EN-US">Entrepreneurs @35%</span><span style="font-weight: normal; color: Red;"><span> </span><span lang="EN-US">*</span></span><span lang="EN-US"> </span>
                                        </td>
                                        <td style="padding: 10px; margin: 5px;">:
                                        </td>
                                        <td style="padding: 10px; margin: 5px;">

                                            <asp:TextBox ID="txtInvSubsdySCST" runat="server" class="form-control txtbox" Enabled="true" Height="30px" MaxLength="80" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                                        </td>--%>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        2.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <span lang="EN-US">An Additional Investment Subsidy for Women entrepreneurs</span><span
                            style="font-weight: normal; color: Red;">*</span>
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txtAddnInvSubsdyWmn" runat="server" class="form-control txtbox"
                            onkeypress="return inputOnlyNumbers(event)" Enabled="true" Height="30px" MaxLength="80"
                            TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                    </td>
                    <td style="padding: 10px; margin: 5px; width: 20px">
                    </td>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        3.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <span lang="EN-US">An additional investment subsidy for Women entrepreneurs set up in
                            Scheduled areas @10% </span><span style="font-weight: normal; color: Red;">*</span>
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txtAddnInvSbsdySc10Prcnt" runat="server" class="form-control txtbox"
                            onkeypress="return inputOnlyNumbers(event)" Enabled="true" Height="30px" MaxLength="80"
                            TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        4.
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        Total
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        :
                    </td>
                    <td style="padding: 10px; margin: 5px;">
                        <asp:TextBox ID="txtTotalInv" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                            Enabled="true" Height="30px" MaxLength="80" TabIndex="1" ValidationGroup="group"
                            Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px; font-weight: bold; width: 10px">
                        5
                    </td>
                    <td style="text-align: left; padding: 10px; margin: 5px; width: 350px" valign="middle">
                        Remarks<font color="red">*</font>
                    </td>
                    <td style="padding: 5px; margin: 5px; width: 10px" valign="top">
                        :
                    </td>
                    <td style="padding: 5px; margin: 5px" valign="top" colspan="4">
                        <asp:TextBox ID="txtremarks" runat="server" class="form-control txtbox" Height="100px"
                            TabIndex="1" TextMode="MultiLine" ValidationGroup="group" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="10" style="padding: 10px; margin: 5px; font-weight: bold;">
                        M. Attachments
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px; margin: 5px;" colspan="12">
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
                                        <asp:CheckBox ID="chkverified" runat="server" Text="Verified" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Attachments" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblatchid" runat="server" Text='<%# Eval("AttachmentId")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="10">
                        <asp:Button ID="btnSubmit" CssClass="btn btn-primary" runat="server" Text="Submit Report"
                            OnClick="btnSubmit_Click" Width="128px" />
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
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtCalenderDCP']").datepicker(
               {
                   dateFormat: "dd/mm/yy",
               }); // Will run at every postback/AsyncPostback

            $("input[id$='txtRcptAppln']").datepicker(
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

            $("input[id$='txtRcptAppln']").datepicker(
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

        });
    </script>
</asp:Content>
