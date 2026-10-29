<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="Incentivesold.aspx.cs" Inherits="TSTBDCReg1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <style type="text/css">
        /*Calendar Control CSS*/
        .cal_Theme1 .ajax__calendar_container
        {
            background-color: #DEF1F4;
            border: solid 1px #77D5F7;
        }
        .cal_Theme1 .ajax__calendar_header
        {
            background-color: #ffffff;
            margin-bottom: 4px;
        }
        .cal_Theme1 .ajax__calendar_title, .cal_Theme1 .ajax__calendar_next, .cal_Theme1 .ajax__calendar_prev
        {
            color: #004080;
            padding-top: 3px;
        }
        .cal_Theme1 .ajax__calendar_body
        {
            background-color: #ffffff;
            border: solid 1px #77D5F7;
        }
        .cal_Theme1 .ajax__calendar_dayname
        {
            text-align: center;
            font-weight: bold;
            margin-bottom: 4px;
            margin-top: 2px;
            color: #004080;
        }
        .cal_Theme1 .ajax__calendar_day
        {
            color: #004080;
            text-align: center;
        }
        .cal_Theme1 .ajax__calendar_hover .ajax__calendar_day, .cal_Theme1 .ajax__calendar_hover .ajax__calendar_month, .cal_Theme1 .ajax__calendar_hover .ajax__calendar_year, .cal_Theme1 .ajax__calendar_active
        {
            color: #004080;
            font-weight: bold;
            background-color: #DEF1F4;
        }
        .cal_Theme1 .ajax__calendar_today
        {
            font-weight: bold;
        }
        .cal_Theme1 .ajax__calendar_other, .cal_Theme1 .ajax__calendar_hover .ajax__calendar_today, .cal_Theme1 .ajax__calendar_hover .ajax__calendar_title
        {
            color: #bbbbbb;
        }
        .txtalignright
        {
            display: block;
            text-align: right;
            width: 100%;
            height: 34px;
            padding: 6px 12px;
            font-size: 14px;
            line-height: 1.42857143;
            color: #555;
            background-color: #fff;
            background-image: none;
            border: 1px solid #ccc;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
            box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
            -webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
        }
         .txtalignright[readonly], fieldset[disabled] 
        .txtalignright:[disabled]
        {
            cursor: not-allowed;
            background-color: #eee;
            opacity: 1;
        }
        .overlay
        {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 112px;
            background-color: Gray;
            -moz-opacity: 0.9;
        }
        .style20
        {
            width: 297px;
        }
        .style21
        {
            height: 35px;
        }
        .style22
        {
            height: 58px;
        }
        .style23
        {
            width: 297px;
            height: 35px;
        }
        .style26
        {
            height: 21px;
        }
        .style27
        {
            height: 21px;
        }
        .style32
        {
            width: 206px;
            height: 21px;
        }
        .style33
        {
            width: 206px;
            height: 35px;
        }
        .style34
        {
            height: 21px;
            width: 261px;
        }
        .style35
        {
            height: 35px;
            width: 261px;
        }
        .style36
        {
            width: 261px;
        }
        .style37
        {
            height: 31px;
        }
        .style38
        {
            width: 261px;
            height: 31px;
        }
        .style40
        {
            width: 206px;
            height: 31px;
        }
        .style41
        {
            height: 29px;
        }
        .style42
        {
            width: 261px;
            height: 29px;
        }
        .style44
        {
            width: 206px;
            height: 29px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {
            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");
            return false;
        }

        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>

    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;<li class="active"><a href="#">Incentive Application</a></li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    Incentives</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <td valign="top" align="right">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" align="center">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <th style="padding: 5px; margin: 5px; text-align: left;" class="style26" colspan="5">
                                                                Entrepreneur Details
                                                            </th>
                                                            <th style="padding: 5px; margin: 5px;" class="style27" colspan="4">
                                                                Unit Details
                                                            </th>
                                                        </tr>
                                                        <tr>
                                                            <td class="style26" style="padding: 5px; margin: 5px; text-align: left;">
                                                                1
                                                            </td>
                                                            <td class="style34" style="padding: 5px; margin: 5px; text-align: left;">
                                                                EM / Udyog Aadhar No<span style="font-weight: bold; color: Red;">*</span>
                                                            </td>
                                                            <td class="style26" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style26" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtEmUdgAadhar" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="25" TabIndex="1" ValidationGroup="Save" Width="180px" AutoPostBack="true"
                                                                    OnTextChanged="txtEmUdgAadhar_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td class="style26" style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td class="style26" style="padding: 5px; margin: 5px;">
                                                                15
                                                            </td>
                                                            <td class="style32" style="padding: 5px; margin: 5px; text-align: left;">
                                                                Category<span style="font-weight: bold; color: Red;">*</span>
                                                            </td>
                                                            <td class="style26" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style26" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlCategory" runat="server" class="form-control txtbox" Height="33px"
                                                                    TabIndex="18" Width="180px" ValidationGroup="Save" Enabled="False">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="rfvCtg" runat="server" ControlToValidate="ddlCategory"
                                                                    ErrorMessage="Please select Category" InitialValue="-- SELECT --" SetFocusOnError="true"
                                                                    ValidationGroup="Save" Display="None" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style21">
                                                                2
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style35">
                                                                Unit Name<span style="font-weight: bold; color: Red;">*</span>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" class="style21">
                                                                :
                                                            </td>
                                                            <td class="style21" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtUnitname" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="80" TabIndex="2" ValidationGroup="Save" Width="180px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvUnitName" runat="server" ControlToValidate="txtUnitname"
                                                                    ErrorMessage="Please Enter Unit Name" SetFocusOnError="true" ValidationGroup="Save"
                                                                    Display="None" />
                                                            </td>
                                                            <td class="style21" style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: middle;" class="style22">
                                                                16
                                                            </td>
                                                            <td class="style33" style="padding: 5px; margin: 5px; text-align: left;">
                                                                Land Value: (In Lakhs)<span style="font-weight: bold; color: Red;">*</span>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" class="style21">
                                                                :
                                                            </td>
                                                            <td class="style21" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtLandValue" runat="server" class="txtalignright" Height="28px"
                                                                    MaxLength="40" TabIndex="19" ValidationGroup="group" Width="180px" AutoPostBack="True"
                                                                    OnTextChanged="txtTotalValueCalculation"></asp:TextBox>
                                                                <cc1:FilteredTextBoxExtender ID="fteLandValue" runat="server" FilterMode="ValidChars"
                                                                    FilterType="Custom, Numbers" ValidChars="." TargetControlID="txtLandValue" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style21">
                                                                3
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style35">
                                                                Applicant Name<span style="font-weight: bold; color: Red;">*</span>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" class="style21">
                                                                :
                                                            </td>
                                                            <td class="style21" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtApplicantName" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="100" TabIndex="3" ValidationGroup="Save" Width="180px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfApplName" runat="server" ControlToValidate="txtApplicantName"
                                                                    ErrorMessage="Please Enter Applicant Name" SetFocusOnError="true" ValidationGroup="Save"
                                                                    Display="None" />
                                                            </td>
                                                            <td class="style21" style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: middle;" class="style21">
                                                                17
                                                            </td>
                                                            <td class="style33" style="padding: 5px; margin: 5px; text-align: left;">
                                                                Building Value (In Lakhs)<span style="font-weight: bold; color: Red;">*</span>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" class="style21">
                                                                :
                                                            </td>
                                                            <td class="style21" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtBuildingValue" runat="server" class="txtalignright" Height="28px"
                                                                    MaxLength="40" TabIndex="20" ValidationGroup="group" Width="180px" AutoPostBack="True" 
                                                                    OnTextChanged="txtTotalValueCalculation"></asp:TextBox>
                                                                <cc1:FilteredTextBoxExtender ID="fteBuildingVal" runat="server" FilterMode="ValidChars"
                                                                    FilterType="Custom, Numbers" ValidChars="." TargetControlID="txtBuildingValue" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;"
                                                                valign="top" class="style37">
                                                                4
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style38">
                                                                Gender<span style="font-weight: bold; color: Red;">*</span>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" class="style37">
                                                                :
                                                            </td>
                                                            <td class="style37" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlGender" runat="server" class="form-control txtbox" Height="33px"
                                                                    TabIndex="4" Width="180px" ValidationGroup="Save" AutoPostBack="true" OnSelectedIndexChanged="ddlGender_SelectedIndexChanged">
                                                                    <asp:ListItem>-- SELECT --</asp:ListItem>
                                                                    <asp:ListItem Value="M">Male</asp:ListItem>
                                                                    <asp:ListItem Value="F">Female</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="rfvGender" runat="server" ControlToValidate="ddlGender"
                                                                    InitialValue="-- SELECT --" ErrorMessage="Please Select Gender" SetFocusOnError="true"
                                                                    ValidationGroup="Save" Display="None" />
                                                            </td>
                                                            <td class="style37" style="padding: 5px; margin: 5px; text-align: left;">
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: middle;" class="style37">
                                                                18
                                                            </td>
                                                            <td class="style40" style="padding: 5px; margin: 5px; text-align: left;">
                                                                Plant &amp; Machinery (In Lakhs)<span style="font-weight: bold; color: Red;">*</span>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" class="style37">
                                                                :
                                                            </td>
                                                            <td class="style37" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtPlantandMachinery" runat="server" class="txtalignright" Height="28px"
                                                                    MaxLength="40" TabIndex="21" ValidationGroup="group" Width="180px" AutoPostBack="True"
                                                                    OnTextChanged="txtTotalValueCalculation" />
                                                                <cc1:FilteredTextBoxExtender ID="ftePlantMach" runat="server" FilterMode="ValidChars"
                                                                    FilterType="Custom, Numbers" ValidChars="." TargetControlID="txtPlantandMachinery" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle" class="style41">
                                                                5
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style42">
                                                                Caste<span style="font-weight: bold; color: Red;">*</span>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" class="style41">
                                                                :
                                                            </td>
                                                            <td class="style41" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlCaste" runat="server" class="form-control txtbox" Height="33px"
                                                                    TabIndex="5" Width="180px" ValidationGroup="Save" AutoPostBack="true" OnSelectedIndexChanged="ddlCaste_SelectedIndexChanged">
                                                                    <asp:ListItem>-- SELECT --</asp:ListItem>
                                                                    <asp:ListItem Value="1">General</asp:ListItem>
                                                                    <asp:ListItem Value="2">OBC</asp:ListItem>
                                                                    <asp:ListItem Value="3">SC</asp:ListItem>
                                                                    <asp:ListItem Value="4">ST</asp:ListItem>
                                                                    <asp:ListItem Value="5">Others</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="rfvCaste" runat="server" ControlToValidate="ddlCaste"
                                                                    InitialValue="-- SELECT --" ErrorMessage="Please Select Caste" SetFocusOnError="true"
                                                                    ValidationGroup="Save" Display="None" />
                                                            </td>
                                                            <td class="style41" style="padding: 5px; margin: 5px; text-align: left;">
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: middle;" class="style41">
                                                                19
                                                            </td>
                                                            <td class="style44" style="padding: 5px; margin: 5px; text-align: left;">
                                                                Equipment Value (In Lakhs)<span style="font-weight: bold; color: Red;">*</span>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" class="style41">
                                                                :
                                                            </td>
                                                            <td class="style41" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtEquipment" runat="server" class="txtalignright" Height="28px"
                                                                    MaxLength="40" TabIndex="22" ValidationGroup="group" Width="180px" AutoPostBack="True"
                                                                    OnTextChanged="txtTotalValueCalculation"></asp:TextBox>
                                                                <cc1:FilteredTextBoxExtender ID="fteEqp" runat="server" FilterMode="ValidChars" FilterType="Custom, Numbers"
                                                                    ValidChars="." TargetControlID="txtEquipment" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;"
                                                                valign="middle">
                                                                6
                                                            </td>
                                                            <td class="style36" style="padding: 5px; margin: 5px; text-align: left;">
                                                                Other Details
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:CheckBox ID="cbDiffAbled" runat="server" AutoPostBack="true" OnCheckedChanged="cbDiffAbled_CheckedChanged"
                                                                    TabIndex="7" Text="Physically handicapped" />
                                                                <br />
                                                                <asp:CheckBox ID="cbWomen" runat="server" TabIndex="8" Text="Women" />
                                                                <br />
                                                                <asp:CheckBox ID="cbMinority" runat="server" TabIndex="9" Text="Minority" />
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: middle;">
                                                                20
                                                            </td>
                                                            <td class="style3" style="padding: 5px; margin: 5px; text-align: left;">
                                                                Total (In Lakhs)
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtTotal" runat="server" class="txtalignright" Enabled="false" Height="28px"
                                                                    MaxLength="40" TabIndex="23" ValidationGroup="group" Width="180px" />
                                                                <cc1:FilteredTextBoxExtender ID="fteTotal" runat="server" FilterMode="ValidChars"
                                                                    FilterType="Custom, Numbers" TargetControlID="txtTotal" ValidChars="." />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle" class="style41">
                                                                7
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style42">
                                                                Type of Sector<span style="font-weight: bold; color: Red;">*</span>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" class="style41">
                                                                :
                                                            </td>
                                                            <td class="style41" style="padding: 5px; margin: 5px; text-align: left;" colspan="6">
                                                                <asp:RadioButtonList ID="rblSector" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblSector_SelectedIndexChanged"
                                                                    AutoPostBack="true" TabIndex="6">
                                                                    <asp:ListItem Value="1">Service</asp:ListItem>
                                                                    <asp:ListItem Value="2" Selected="True">Manufacture</asp:ListItem>
                                                                    <asp:ListItem Value="3">Textiles</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr runat="server" id="trSectorVeh">
                                                            <td class="style41" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;"
                                                                valign="middle">
                                                                7.a) &nbsp;
                                                            </td>
                                                            <td class="style42" colspan="4" style="padding: 5px; margin: 5px; text-align: left;
                                                                vertical-align: middle;">
                                                                <asp:RadioButtonList ID="rblVeh" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rblVeh_SelectedIndexChanged"
                                                                    RepeatDirection="Horizontal" Visible="false">
                                                                    <asp:ListItem Value="0">Transport allied activities</asp:ListItem>
                                                                    <asp:ListItem Selected="True" Value="1">Other Service Sector</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;"
                                                                valign="middle">
                                                                7.b)
                                                            </td>
                                                            <td class="style36" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">
                                                                <asp:Label ID="lbldateofCommencement" runat="server" Text="Date of commencement for Production"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtDateofCommencement" runat="server" class="form-control txtbox"
                                                                    Width="180px" AutoPostBack="true" OnTextChanged="txtDateofCommencement_TextChanged"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="cteDateofComm" runat="server" Format="dd-MMM-yyyy" TargetControlID="txtDateofCommencement"
                                                                    CssClass="cal_Theme1" />
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;"
                                                                valign="middle">
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;"
                                                                valign="middle">
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="lblVehivleRegNo" runat="server" Text="Vehicle Registration Number"
                                                                    Visible="false"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtvehicleRegistratioNumber" runat="server" MaxLength="15" class="form-control txtbox"
                                                                    Width="180px" Visible="false" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">
                                                                8&nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style36">
                                                                Email Id<span style="font-weight: bold; color: Red;">*</span>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtEmail" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="10" ValidationGroup="Save" Width="180px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                                                                    ErrorMessage="Please enter Email" ValidationGroup="Save" Display="None">
                                                                </asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                                                                    ErrorMessage="Please Enter Correct Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                    ValidationGroup="Save" SetFocusOnError="true" Display="None" />
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px;">
                                                                21
                                                            </td>
                                                            <td class="style3" style="padding: 5px; margin: 5px; text-align: left;">
                                                                Land Status
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlLandStatus" runat="server" class="form-control txtbox" TabIndex="24"
                                                                    Width="180px" AutoPostBack="true" OnSelectedIndexChanged="ddlLandStatus_SelectedIndexChanged">
                                                                    <asp:ListItem>-- SELECT --</asp:ListItem>
                                                                    <asp:ListItem Value="1">LEASED</asp:ListItem>
                                                                    <asp:ListItem Value="2">RENT</asp:ListItem>
                                                                    <asp:ListItem Value="3">OWNED</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <%--<asp:RequiredFieldValidator ID="rfvLndStatus" runat="server" InitialValue="-- SELECT --"
                                                                    ControlToValidate="ddlLandStatus" ErrorMessage="Please Select Land Status" 
                                                                    ValidationGroup="Save" Display="None"></asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">
                                                                9
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style36">
                                                                Mobile Number<span style="font-weight: bold; color: Red;">*</span>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtMobile" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="10" TabIndex="11" ValidationGroup="Save" Width="180px"></asp:TextBox>
                                                                <cc1:FilteredTextBoxExtender ID="fteMobile" runat="server" FilterMode="ValidChars"
                                                                    FilterType="Numbers" TargetControlID="txtMobile" />
                                                                <asp:RequiredFieldValidator ID="rfvMob" runat="server" ControlToValidate="txtMobile"
                                                                    ErrorMessage="Please Enter Mobile Number" ValidationGroup="Save" Display="None">
                                                                </asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="revMobileNo" runat="server" ErrorMessage="Please Enter Valid Mobile No-Starting with 9 or 8 or 7"
                                                                    SetFocusOnError="True" ControlToValidate="txtMobile" Display="None" ValidationExpression="[9,8,7]{1}[0-9]{9}"
                                                                    ValidationGroup="Save">
                                                                </asp:RegularExpressionValidator>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px;">
                                                                22
                                                            </td>
                                                            <td class="style3" style="padding: 5px; margin: 5px; text-align: left;">
                                                                Building Status
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlBuidingStatus" runat="server" class="form-control txtbox"
                                                                    TabIndex="25" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlBuidingStatus_SelectedIndexChanged">
                                                                    <asp:ListItem>-- SELECT --</asp:ListItem>
                                                                    <asp:ListItem Value="1">LEASED</asp:ListItem>
                                                                    <asp:ListItem Value="2">RENT</asp:ListItem>
                                                                    <asp:ListItem Value="3">OWNED</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <%--<asp:RequiredFieldValidator ID="rfvBuildingStatus" runat="server" 
                                                                    ControlToValidate="ddlBuidingStatus"
                                                                    ErrorMessage="Please select Building Status" ValidationGroup="Save" 
                                                                    InitialValue="-- SELECT --" Display="None" />--%>
                                                            </td>
                                                        </tr>
                                                        <tr id="rem" runat="server">
                                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">
                                                                10
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style36">
                                                                Address Of The Unit<span style="font-weight: bold; color: Red;">*</span>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtAddressoftheUnit" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40" TabIndex="12" TextMode="MultiLine" ValidationGroup="Save"
                                                                    Width="180px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddressoftheUnit"
                                                                    SetFocusOnError="true" ErrorMessage="Please Enter Address of the unit" ValidationGroup="Save"
                                                                    Display="None"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px;">
                                                                23
                                                            </td>
                                                            <td class="style3" style="padding: 5px; margin: 5px; text-align: left;">
                                                                Type of Organization<span style="font-weight: bold; color: Red;">*</span>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddltypeofOrg" runat="server" class="form-control txtbox" Height="33px"
                                                                    TabIndex="26" Width="180px" ValidationGroup="Save">
                                                                    <asp:ListItem>-- SELECT --</asp:ListItem>
                                                                    <asp:ListItem Value="1">Proprietary</asp:ListItem>
                                                                    <asp:ListItem Value="2">Partnership</asp:ListItem>
                                                                    <asp:ListItem Value="3">PVT LTD</asp:ListItem>
                                                                    <asp:ListItem Value="4">Public Limited</asp:ListItem>
                                                                    <asp:ListItem Value="5">Co-Operative</asp:ListItem>
                                                                    <asp:ListItem Value="6">LLP</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="rfvTypofOrg" runat="server" ControlToValidate="ddltypeofOrg"
                                                                    ErrorMessage="Please select Type of Organization" ValidationGroup="Save" SetFocusOnError="true"
                                                                    Display="None"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">
                                                                11
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style36">
                                                                District<span style="font-weight: bold; color: Red;">*</span>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlDistrict" runat="server" class="form-control txtbox" Height="33px"
                                                                    TabIndex="13" Width="180px" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"
                                                                    ValidationGroup="Save">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="rfvDistrict" runat="server" ControlToValidate="ddlDistrict"
                                                                    ErrorMessage="Please select District" ValidationGroup="Save" SetFocusOnError="true"
                                                                    Display="None"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px;">
                                                                24
                                                            </td>
                                                            <td class="style3" style="padding: 5px; margin: 5px; text-align: left;">
                                                                Total Employment<span style="font-weight: bold; color: Red;">*</span>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txttotalEmp" runat="server" class="txtalignright" Height="28px"
                                                                    MaxLength="40" TabIndex="27" ValidationGroup="Save" Width="180px"></asp:TextBox>
                                                                <cc1:FilteredTextBoxExtender ID="fteTotalEmp" runat="server" FilterMode="ValidChars"
                                                                    FilterType="Custom, Numbers" ValidChars="." TargetControlID="txttotalEmp" />
                                                                <asp:RequiredFieldValidator ID="rfvTotEmp" runat="server" ControlToValidate="txttotalEmp"
                                                                    ErrorMessage="Please enter Total Employment" ValidationGroup="Save" SetFocusOnError="true"
                                                                    Display="None"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">
                                                                12
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style36">
                                                                Mandal<span style="font-weight: bold; color: Red;">*</span>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlMandal" runat="server" class="form-control txtbox" Height="33px"
                                                                    TabIndex="14" Width="180px" AutoPostBack="true" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged"
                                                                    ValidationGroup="Save" />
                                                                <asp:RequiredFieldValidator ID="rfvMandal" runat="server" ControlToValidate="ddlMandal"
                                                                    ErrorMessage="Please select Mandal" ValidationGroup="Save" SetFocusOnError="true"
                                                                    Display="None" InitialValue="-- SELECT --"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px;">
                                                                25
                                                            </td>
                                                            <td class="style3" style="padding: 5px; margin: 5px; text-align: left;">
                                                                Village<span style="font-weight: bold; color: Red;">*</span>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlVillage" runat="server" class="form-control txtbox" Height="33px"
                                                                    TabIndex="28" Width="180px" ValidationGroup="Save">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="rfvVillage" runat="server" ControlToValidate="ddlVillage"
                                                                    ErrorMessage="Please select Village" ValidationGroup="Save" SetFocusOnError="true"
                                                                    Display="None" InitialValue="-- SELECT --"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;"
                                                                valign="top">
                                                                13
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style36">
                                                                <asp:Label ID="lblNatureofActitvity" runat="server" Text="Nature of Activity"></asp:Label>
                                                                <span style="font-weight: bold; color: Red;">*</span>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" colspan="6">
                                                                <asp:DropDownList ID="ddlintLineofActivity" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="100%" TabIndex="15" ValidationGroup="Save">
                                                                </asp:DropDownList>
                                                                <asp:TextBox ID="txtBussinessActivity" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="100%" TabIndex="16" MaxLength="250" ValidationGroup="Save"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvLineOfAct" runat="server" InitialValue="-- SELECT --"
                                                                    ControlToValidate="ddlintLineofActivity" ErrorMessage="Please select Nature of Activity"
                                                                    ValidationGroup="Save" SetFocusOnError="true" Display="None">
                                                                </asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                14
                                                            </td>
                                                            <td colspan="9">
                                                                <asp:RadioButtonList ID="rblGHMC" runat="server" TabIndex="17" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="0">GHMC & other Municipal Corporations in the state</asp:ListItem>
                                                                    <asp:ListItem Value="1">
                                                                        Other areas in the state
                                                                    </asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <span style="font-weight: bold;">Bank Details</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td class="style21" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">
                                                                1
                                                            </td>
                                                            <td class="style21" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">
                                                                Name of Bank
                                                            </td>
                                                            <td class="style21" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style21" style="padding: 5px; margin: 5px; text-align: left;" colspan="6">
                                                                <asp:DropDownList ID="ddlBank" runat="server" class="form-control txtbox" TabIndex="29"
                                                                    ValidationGroup="Save">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="rfvBank" runat="server" InitialValue="-- SELECT --"
                                                                    ControlToValidate="ddlBank" ErrorMessage="Please select Bank Name" ValidationGroup="Save"
                                                                    SetFocusOnError="true" Display="None"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">
                                                                2
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                Branch Name<%--<span style="font-weight: bold; color: Red;">*</span>--%></td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtBranchName" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="30" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                <%--<asp:RequiredFieldValidator ID="rfvBranch" runat="server" ControlToValidate="txtBranchName"
                                                                    ErrorMessage="Please enter Branch Name" ValidationGroup="Save" SetFocusOnError="true"
                                                                    Display="None" />--%>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td class="style21" style="padding: 5px; margin: 5px; vertical-align: middle;">
                                                                3
                                                            </td>
                                                            <td class="style23" style="padding: 5px; margin: 5px; text-align: left;">
                                                                Account Number<%--<span style="font-weight: bold; color: Red;">*</span>--%></td>
                                                            <td class="style21" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style21" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtAccNumber" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="25" TabIndex="31" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                <%--<asp:RequiredFieldValidator ID="rfvAcNo" runat="server" ControlToValidate="txtAccNumber"
                                                                    ErrorMessage="Please enter Bank Account Number" ValidationGroup="Save" 
                                                                    SetFocusOnError="true" Display="None" />--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; width: 10px; vertical-align: middle;">
                                                                4
                                                            </td>
                                                            <td class="style20" style="padding: 5px; margin: 5px; text-align: left;">
                                                                IFSC Code<%--<span style="font-weight: bold; color: Red;">*</span>--%></td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtIfscCode" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="12" TabIndex="32" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                <%--<asp:RequiredFieldValidator ID="rfvIFSCCode" runat="server" ControlToValidate="txtIfscCode"
                                                                    ErrorMessage="Please enter IFSC Code" ValidationGroup="Save" SetFocusOnError="true"
                                                                    Display="None" />--%>
                                                            </td>
                                                            <td colspan="3">
                                                                <a href="https://www.bankifsccode.com/" target="_blank">Find IFSC code</a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; width: 10px; vertical-align: middle;">
                                                                &nbsp;</td>
                                                            <td class="style20" style="padding: 5px; margin: 5px; text-align: left;">
                                                                Whether you have Power Connection Incentive</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlPower" runat="server" AutoPostBack="True" 
                                                                    class="form-control txtbox" 
                                                                    OnSelectedIndexChanged="ddlPower_SelectedIndexChanged" TabIndex="25" 
                                                                    Width="180px">
                                                                    <asp:ListItem Selected="True">Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td colspan="3">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr runat="server" id="powertr">
                                                            <td style="padding: 5px; margin: 5px; width: 10px; vertical-align: middle;">
                                                                &nbsp;</td>
                                                            <td class="style20" style="padding: 5px; margin: 5px; text-align: left;">
                                                                Request to Department</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TxtRequesttoDepartment" runat="server" 
                                                                    class="form-control txtbox" Height="72px" MaxLength="450" TabIndex="2" 
                                                                    ValidationGroup="Save" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td colspan="3" style="color: #FF0000">
                                                                Please contact Industry Department for futher process and Register this in help 
                                                                desk</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Height="32px"
                                                        TabIndex="33" Text="Submit" ValidationGroup="Save" Width="90px" OnClick="btnSave_Click" />
                                                    <span style="padding-left: 5px;">
                                                        <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                            Height="32px" TabIndex="34" Text="Cancel" ToolTip="To Clear  the Screen" Width="90px"
                                                            OnClick="BtnClear_Click" />
                                                    </span><span style="padding-left: 5px;">
                                                        <asp:Button ID="btnNext" runat="server" CssClass="btn btn-warning" Height="32px"
                                                            Text="Next" Visible="false" OnClick="btnNext_Click" TabIndex="35" />
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:ValidationSummary ID="vs" runat="server" DisplayMode="BulletList" HeaderText="Please fill the below Mentioned Details"
                                                        ShowMessageBox="true" ShowSummary="true" ValidationGroup="Save" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfvEmNo" runat="server" ControlToValidate="txtEmUdgAadhar"
                                                        Display="None" ErrorMessage="Please Enter EM No / Udyog Aadhar No" SetFocusOnError="true"
                                                        ValidationGroup="Save" />
                                                    <%--<asp:RegularExpressionValidator ID="revUdyog" runat="server" 
                                                        ErrorMessage="Please Enter Valid Udyog Adhar No"
                                                        SetFocusOnError="True" ControlToValidate="txtEmUdgAadhar" ValidationExpression="[0-9]{12}"
                                                        ValidationGroup="Save">
                                                    </asp:RegularExpressionValidator>--%>
                                                    <cc1:FilteredTextBoxExtender ID="fteAccNo" runat="server" FilterMode="ValidChars"
                                                        FilterType="Numbers" TargetControlID="txtAccNumber" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding: 5px; margin: 5px">
                                                    <div id="success0" runat="server" class="alert alert-success" visible="false">
                                                        <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">
                                                            ×</a> <strong>Success!</strong><asp:Label ID="lblmsg1" runat="server"></asp:Label>
                                                    </div>
                                                    <div id="Failure0" runat="server" class="alert alert-danger" visible="false">
                                                        <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                                        <asp:Label ID="lblmsg2" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="alert alert-success">
                                                        <table style="width: 100%; padding: 5px;" cellpadding="2" cellspacing="4">
                                                            <tr>
                                                                <td align="center" style="padding: 5px; margin: 5px" colspan="3">
                                                                    Note:
                                                                    <br />
                                                                    <ul>
                                                                        <li>Large Industries are not Eligible for Land Conversion Incentive</li>
                                                                        <li>Projects Proposed to be set up under T-PRIDE in Municipal Corporation limits of
                                                                            Greater Hyderabad shall obtain pollution clearances where ever neccessary</li>
                                                                        <li>Textile Units other than Large industries may select Sector type as Manufacture
                                                                            for applying eligible Incentives</li>
                                                                        <li>For service sector enter Equipment Value, for others enter Plant & Machinery Value</li>
                                                                        <li>Land or Building status is selected as OWNED then their coreesponding value will 
                                                                            be automatically treated as Zero</li>
                                                                    </ul>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
                                                                    The limit for investment in plant and machinery/equipment for manufacturing / service
                                                                    enterprises are as under:
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
                                                                    <table style="width: 100%; padding: 5px;" cellpadding="3" cellspacing="4" border="1">
                                                                        <tr>
                                                                            <th class="paddingleft">
                                                                                Enterprises
                                                                            </th>
                                                                            <th class="paddingleft">
                                                                                Type
                                                                            </th>
                                                                            <th class="paddingleft">
                                                                                Investment in plant & machinery/equipment
                                                                            </th>
                                                                        </tr>
                                                                        <tr>
                                                                            <td rowspan="2" class="paddingleft">
                                                                                Micro Enterprises
                                                                            </td>
                                                                            <td class="paddingleft">
                                                                                Manufacturing
                                                                            </td>
                                                                            <td class="paddingleft">
                                                                                Does not exceed 25 lakh rupees
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="paddingleft">
                                                                                Service
                                                                            </td>
                                                                            <td class="paddingleft">
                                                                                Does not exceed 10 lakh rupees
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td rowspan="2" class="paddingleft">
                                                                                Small Enterprises
                                                                            </td>
                                                                            <td class="paddingleft">
                                                                                Manufacturing
                                                                            </td>
                                                                            <td class="paddingleft">
                                                                                More than 25 lakh rupees but does not exceed 5 crore rupees
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="paddingleft">
                                                                                Service
                                                                            </td>
                                                                            <td class="paddingleft">
                                                                                More than 10 lakh rupees but does not exceed 2 crore rupees
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td rowspan="2" class="paddingleft">
                                                                                Medium Enterprises
                                                                            </td>
                                                                            <td class="paddingleft">
                                                                                Manufacturing
                                                                            </td>
                                                                            <td class="paddingleft">
                                                                                More than 5 crore rupees but does not exceed 10 crore rupees
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="paddingleft">
                                                                                Service
                                                                            </td>
                                                                            <td class="paddingleft">
                                                                                More than 2 crore rupees but does not exceed 5 crore rupees
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td rowspan="2" class="paddingleft">
                                                                                Large Enterprises
                                                                            </td>
                                                                            <td class="paddingleft">
                                                                                Manufacturing
                                                                            </td>
                                                                            <td class="paddingleft">
                                                                                More than 10 crore rupees but does not exceed 200 crore rupees
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="paddingleft">
                                                                                Service
                                                                            </td>
                                                                            <td class="paddingleft">
                                                                                -
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td rowspan="2" class="paddingleft">
                                                                                Mega Enterprises
                                                                            </td>
                                                                            <td class="paddingleft">
                                                                                Manufacturing
                                                                            </td>
                                                                            <td class="paddingleft">
                                                                                More than 200 crore rupees
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="paddingleft">
                                                                                Service
                                                                            </td>
                                                                            <td class="paddingleft">
                                                                                -
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                    <%--<div class="overlay">
                        <div style="z-index: 1000; margin-left: -210px; margin-top: 100px; -moz-opacity: 1;">
                            <img alt="" src="../../Resource/Images/Processing.gif" />
                        </div>
                    </div>--%>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
