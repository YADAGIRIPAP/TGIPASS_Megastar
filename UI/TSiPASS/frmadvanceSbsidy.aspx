<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="frmadvanceSbsidy.aspx.cs" Inherits="TSTBDCReg1" %>

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
        .style5
        {
            width: 17px;
        }
        .style6
        {
            width: 186px;
        }
        .style7
        {
            width: 4px;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupfrmadvanceSbsidy.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

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
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    REPORT 5: ADVANCE SUBSIDY
                                </h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:Label ID="Label424" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="210px">Advance Subsidy<font 
                                                            color="red" id="fn1" runat="server"></font></asp:Label>
                                                </td>
                                                <td style="width: 27px" runat="server" visible="true">
                                                    &nbsp;<asp:Button ID="BtnSave2" runat="server" CssClass="btn btn-primary" Height="32px"
                                                        OnClientClick="OpenPopup();" TabIndex="10" Text="Lookup" Width="90px" />
                                                </td>
                                                <td valign="top">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                       <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                1 &nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                               whether any cases registered this month or not.</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:RadioButtonList ID="rbtcasesregmonth" AutoPostBack="true" OnSelectedIndexChanged="rbtcasesregmonth_SelectedIndexChanged" RepeatDirection="Horizontal" runat="server" >
                            <asp:ListItem Value="Y" Selected="True">YES</asp:ListItem>
                            <asp:ListItem Value="N" >NO</asp:ListItem>
                        </asp:RadioButtonList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                2
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style5">
                                                                <asp:Label ID="Label350" runat="server" CssClass="LBLBLACK" Width="165px">Name of the IPO</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:DropDownList ID="ddlIPOname" runat="server" Visible="false" class="form-control txtbox"
                                                                    Height="33px" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" TabIndex="1"
                                                                    Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:Label ID="lblIPOname" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="ddlIPOname"
                                                                    ErrorMessage="Please select IPO Name" Visible="false" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                3
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label439" runat="server" CssClass="LBLBLACK" Width="165px">Month<font 
                                                            color="red" id="fn2" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlMonth" runat="server" class="form-control txtbox" Height="33px"
                                                                    OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" TabIndex="1" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="1">January</asp:ListItem>
                                                                    <asp:ListItem Value="2">February</asp:ListItem>
                                                                    <asp:ListItem Value="3">March</asp:ListItem>
                                                                    <asp:ListItem Value="4">April</asp:ListItem>
                                                                    <asp:ListItem Value="5">May</asp:ListItem>
                                                                    <asp:ListItem Value="6">June</asp:ListItem>
                                                                    <asp:ListItem Value="7">July</asp:ListItem>
                                                                    <asp:ListItem Value="8">August</asp:ListItem>
                                                                    <asp:ListItem Value="9">September</asp:ListItem>
                                                                    <asp:ListItem Value="10">October</asp:ListItem>
                                                                    <asp:ListItem Value="11">November</asp:ListItem>
                                                                    <asp:ListItem Value="12">December</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="ddlMonth"
                                                                    ErrorMessage="Please select Month" InitialValue="--Select--" ValidationGroup="group" Visible="false">*</asp:RequiredFieldValidator>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                4
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label440" runat="server" CssClass="LBLBLACK" Width="165px">Year<font 
                                                            color="red" id="fn3" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlYear" runat="server" class="form-control txtbox" Height="33px"
                                                                    TabIndex="1" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                    <asp:ListItem>2021</asp:ListItem>
                                                                    <asp:ListItem>2022</asp:ListItem>
                                                                    <asp:ListItem>2023</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="ddlYear"
                                                                    ErrorMessage="Please select Year" ValidationGroup="group" Visible="false">*</asp:RequiredFieldValidator>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                5
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label437" runat="server" CssClass="LBLBLACK" Width="165px">Promoter Name<font 
                                                            color="red" id="fn4" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtPromoterName" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="100" onkeypress="Names()" TabIndex="1" ValidationGroup="group" AutoComplete="off"
                                                                    Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtPromoterName"
                                                                    ErrorMessage="Please enter Promoter Name" Visible="false" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                6
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label431" runat="server" CssClass="LBLBLACK" Width="165px">Name of the Unit<font 
                                                            color="red" id="fn5" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtBeneficaryName" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="100" onkeypress="Names()" TabIndex="1" AutoComplete="off" ValidationGroup="group"
                                                                    Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtBeneficaryName"
                                                                    ErrorMessage="Please enter Unti Name" Visible="false" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                7&nbsp;
                                                            </td>
                                                            <td style="width: 200px;">
                                                                District<span  id="fn6" runat="server" style="font-weight: bold; color: Red;">*</span>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlUnitDIst" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlUnitDIst_SelectedIndexChanged"
                                                                    class="form-control txtbox" Height="33px" TabIndex="3" Visible="true" Width="180px">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator70" runat="server" ControlToValidate="ddlUnitDIst"
                                                                    ErrorMessage="Please Enter Unit District" SetFocusOnError="true" Visible="false" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">
                                                                8
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                Mandal<span style="font-weight: bold; color: Red;" id="fn7" runat="server">*</span>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlUnitMandal" runat="server" class="form-control txtbox" Visible="true"
                                                                    TabIndex="3" Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlUnitMandal_SelectedIndexChanged">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ControlToValidate="ddlUnitMandal"
                                                                    SetFocusOnError="true" ErrorMessage="Please Select Unit Mandal" InitialValue="--Select--"
                                                                    ValidationGroup="group" Visible="false">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                9
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                Village<span style="font-weight: bold; color: Red;" id="fn8" runat="server">*</span>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlVillageunit" runat="server" class="form-control txtbox"
                                                                    Visible="true" TabIndex="3" Height="33px" Width="180px">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ControlToValidate="ddlVillageunit"
                                                                    SetFocusOnError="true" ErrorMessage="Please Select Unit Village" InitialValue="--Select--"
                                                                    Visible="false" ValidationGroup="group" >*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 27px">
                                                    <asp:Label ID="Label348" runat="server" CssClass="LBLBLACK" Width="50px"></asp:Label>
                                                </td>
                                                <td valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                10
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="165px">Address of the Unit<font 
                                                            color="red" id="fn9" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtbeneficiaryAddress" runat="server" class="form-control txtbox"
                                                                    Height="28px" TabIndex="1" ValidationGroup="group" Width="180px" TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtbeneficiaryAddress"
                                                                    ErrorMessage="Please enter Unit address" Visible="false" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: middle;" valign="middle">
                                                                11
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label441" runat="server" CssClass="LBLBLACK" Width="200px">Social Status<font 
                                                            color="red" id="fn10" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlCaste" runat="server" class="form-control txtbox" Height="33px"
                                                                    OnSelectedIndexChanged="ddlCaste_SelectedIndexChanged" TabIndex="1" Width="180px">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="1">SC</asp:ListItem>
                                                                    <asp:ListItem Value="2">ST</asp:ListItem>
                                                                    <%--<asp:ListItem Value="3">SC</asp:ListItem>
                                                                    <asp:ListItem Value="4">ST</asp:ListItem>--%>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlCaste"
                                                                    ErrorMessage="Please select Caste" Visible="false" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: top;">
                                                                12
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label429" runat="server" CssClass="LBLBLACK" Width="165px">Date of release of Advanced Subsidy(1st Instalment)(dd-mm-yyyy)<font 
                                                            color="red" id="fn11" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txtFirstDate" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" onchange="return txtDOB();"
                                                                    AutoComplete="off" onkeypress="NumberhyphenOnly()" Width="180px"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="Calendarextender1" runat="server" Format="dd-MM-yyyy" PopupButtonID="txtFirstDate"
                                                                    TargetControlID="txtFirstDate">
                                                                </cc1:CalendarExtender>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstDate"
                                                                    ErrorMessage="Please enter First Instalment Date" Visible="false" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: top;">
                                                                13
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="200px">1st Instalment Amount<font 
                                                            color="red" id="fn12" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txtFirstAmount" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="8" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                                    AutoComplete="off" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtFirstAmount"
                                                                    ErrorMessage="Please enter 1st Instalment Amont" Visible="false" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: top;">
                                                                14
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label435" runat="server" CssClass="LBLBLACK" Width="165px">Date of release of Advanced Subsidy(2nd Instalment)(dd-mm-yyyy)<font 
                                                            color="red" id="fn13" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txtSecondDate" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" onchange="return txtDOB();"
                                                                    AutoComplete="off" onkeypress="NumberhyphenOnly()" Width="180px"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="Calendarextender2" runat="server" Format="dd-MM-yyyy" PopupButtonID="txtSecondDate"
                                                                    TargetControlID="txtSecondDate">
                                                                </cc1:CalendarExtender>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                &nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSecondDate"
                                                                    ErrorMessage="Please enter Second Instalment Date" Visible="false" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                15
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label436" runat="server" CssClass="LBLBLACK" Width="165px">2nd Instalment Amount<font 
                                                            color="red" id="fn14" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtSecondAmount" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="8" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                                    AutoComplete="off" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSecondAmount"
                                                                    ErrorMessage="Please enter Second instalment Amount" Visible="false" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                16
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label434" runat="server" CssClass="LBLBLACK" Width="200px">Current Status<font 
                                                            color="red" id="fn15" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlStatus" runat="server" class="form-control txtbox" Height="33px"
                                                                    TabIndex="1" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="1">Final Stages</asp:ListItem>
                                                                    <asp:ListItem Value="2">Under Implementation</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlStatus"
                                                                    ErrorMessage="Please select Status" Visible="false" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                17
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="200px">Remarks<font 
                                                            color="red" id="fn16" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtRemarks" runat="server" class="form-control txtbox" Height="28px"
                                                                    TabIndex="1" ValidationGroup="group" Width="180px" TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtRemarks"
                                                                    ErrorMessage="Please Enter Remarks" Visible="false" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px;" valign="top" align="left" colspan="3">
                                                    <table width="100%">
                                                        <tr>
                                                            <td class="style5" style="padding: 5px; margin: 5px">
                                                                18
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label395" runat="server" CssClass="LBLBLACK" Width="187px">Line of Activity<font 
                                                            color="red" id="fn17" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td class="style7" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlintLineofActivity" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                    Height="33px" OnSelectedIndexChanged="ddlintLineofActivity_SelectedIndexChanged"
                                                                    Width="600px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="ddlintLineofActivity"
                                                                    ErrorMessage="Please Select Line of Activity" Visible="false" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <td style="width: 27px">
                                                        &nbsp;
                                                    </td>
                                                    <td valign="top">
                                                        &nbsp;
                                                    </td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 27px">
                                                    &nbsp;
                                                </td>
                                                <td valign="top">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                                        OnClick="BtnSave_Click" TabIndex="10" Text="Save" Width="90px" ValidationGroup="group" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                                        CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                                        Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px">
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
                    <div style="z-index: 1000; margin-left: 350px; margin-top: 200px; opacity: 1; -moz-opacity: 1;">
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
